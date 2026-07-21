/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Management.Automation.Provider;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Amazon S3 as a navigable PowerShell drive (ships in AWS.Tools.S3). Buckets and prefixes are
    /// folders, objects are files. Calls the AWS SDK directly; does not invoke the S3 cmdlets.
    /// Copy-Item is unsupported (CopyItem is not overridden, so it errors).
    /// </summary>
    [CmdletProvider("AWS.S3", ProviderCapabilities.None)]
    public sealed class S3Provider : NavigationCmdletProvider, IContentCmdletProvider
    {
        // Per-drive state (clients, caches). Usually this.PSDriveInfo is our S3DriveInfo, but a
        // provider-qualified path (e.g. a piped PSPath "AWS.Tools.S3\AWS.S3::bucket\key") resolves
        // against the provider's hidden drive, so we fall back to the first drive in ProviderInfo.Drives.
        private S3DriveInfo Drive
        {
            get
            {
                if (PSDriveInfo is S3DriveInfo di) return di;
                if (ProviderInfo?.Drives != null)
                    foreach (var d in ProviderInfo.Drives)
                        if (d is S3DriveInfo s3d) return s3d;
                throw new InvalidOperationException(
                    "No AWS.S3 drive is mounted. Mount one with Mount-S3PSDrive before using an S3 path.");
            }
        }

        // The mount-region client. Used at the drive root, where ListBuckets is account-global.
        private IAmazonS3 Client => Drive.Client;

        // The client for the region a bucket lives in, so one drive spans all regions. Region is
        // resolved on first touch and cached.
        private IAmazonS3 ClientForBucket(string bucket)
        {
            var region = Drive.GetCachedBucketRegion(bucket);
            if (region == null)
            {
                region = ResolveBucketRegion(Client, bucket);
                Drive.CacheBucketRegion(bucket, region);
            }
            return Drive.ClientForRegion(region);
        }

        // Resolver client is a parameter (not the Client property) because this also runs at mount,
        // before this.Drive exists. GetBucketLocation, not HeadBucket: a region-pinned HeadBucket
        // throws MovedPermanently cross-region. us-east-1 buckets return a null/empty location.
        private string ResolveBucketRegion(IAmazonS3 resolver, string bucket)
        {
            var resp = RunSync(ct => resolver.GetBucketLocationAsync(
                new GetBucketLocationRequest { BucketName = bucket }, ct));
            var loc = resp.Location?.Value;
            if (string.IsNullOrEmpty(loc)) return "us-east-1";   // null/"" => us-east-1
            if (loc == "EU") return "eu-west-1";                 // legacy alias
            return loc;
        }

        // Default multipart part size for non-seekable uploads. Without it the SDK falls back to S3's
        // 5 MiB minimum, which hits the 10,000-part limit past ~49 GiB. Set-Content -PartSize overrides it.
        private const long MultipartThreshold = 8 * 1024 * 1024;

        private Amazon.S3.Transfer.TransferUtility TransferUtilityForBucket(string bucket) =>
            new Amazon.S3.Transfer.TransferUtility(ClientForBucket(bucket),
                new Amazon.S3.Transfer.TransferUtilityConfig { MinSizeBeforePartUpload = MultipartThreshold });

        // ---- Drive lifecycle -------------------------------------------------

        // Contributes the credential/region parameters to New-PSDrive when -PSProvider is AWS.S3
        // (Mount-S3PSDrive forwards these).
        protected override object NewDriveDynamicParameters() => new S3DriveParameters();

        // Called by New-PSDrive. Resolves region/credentials and builds the drive's AmazonS3Client.
        protected override PSDriveInfo NewDrive(PSDriveInfo drive)
        {
            if (drive == null)
            {
                WriteError(new ErrorRecord(
                    new ArgumentNullException(nameof(drive)),
                    "NullDrive", ErrorCategory.InvalidArgument, null));
                return null;
            }

            var dp = DynamicParameters as S3DriveParameters;

            try
            {
                var region = ResolveRegion(dp);
                var creds = ResolveCredentials(dp);   // may be null -> SDK default chain

                var client = creds != null
                    ? new AmazonS3Client(creds, region)
                    : new AmazonS3Client(region);

                // Use this local instance and mount client for ValidateRoot below: this.PSDriveInfo
                // (and Drive/Client) stays null until the engine assigns it after NewDrive returns.
                var s3drive = new S3DriveInfo(drive, creds, region, client, dp?.StorageClass);

                // Fail fast on an unreachable root, so a typo errors at mount instead of first listing.
                if (!ValidateRoot(s3drive, client, drive.Root))
                {
                    WriteError(new ErrorRecord(
                        new ItemNotFoundException(
                            $"The S3 drive root '{drive.Root}' was not found or is not reachable."),
                        "InvalidDriveRoot", ErrorCategory.ObjectNotFound, drive));
                    return null;
                }

                return s3drive;
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, "NewDriveFailed", ErrorCategory.OpenError, drive));
                return null;
            }
        }

        // Mount-time reachability check (true = mount, false = reject). Runs against the local drive +
        // mount client since this.Drive is null inside NewDrive. AccessDenied always passes: the
        // resource exists but we can't inspect it, so the real error surfaces on the actual operation.
        private bool ValidateRoot(S3DriveInfo drive, IAmazonS3 mountClient, string root)
        {
            ParsePath(root, out var bucket, out var keyPrefix);

            // Account root: validate credentials with a single ListBuckets.
            if (string.IsNullOrEmpty(bucket))
            {
                try
                {
                    RunSync(ct => mountClient.ListBucketsAsync(new ListBucketsRequest(), ct));
                    return true;
                }
                catch (AmazonS3Exception ex) when (IsAccessDenied(ex))
                {
                    return true;   // valid creds, just lacking s3:ListAllMyBuckets
                }
                // Any other exception (expired/invalid creds) propagates to NewDrive's catch.
            }

            // Bucket root: resolve its region so the probe below uses a region-correct client.
            string regionName;
            try
            {
                regionName = ResolveBucketRegion(mountClient, bucket);
            }
            catch (AmazonS3Exception ex) when (IsNotFound(ex))
            {
                return false;   // no such bucket
            }
            catch (AmazonS3Exception ex) when (IsAccessDenied(ex))
            {
                regionName = drive.MountRegionName;   // can't read location; fall back to mount region
            }

            drive.CacheBucketRegion(bucket, regionName);
            var client = drive.ClientForRegion(regionName);

            try
            {
                if (string.IsNullOrEmpty(keyPrefix))
                {
                    // Bucket-only: an empty bucket is still a valid mount.
                    RunSync(ct => client.ListObjectsV2Async(
                        new ListObjectsV2Request { BucketName = bucket, MaxKeys = 1 }, ct));
                    return true;
                }

                // Prefix root: reject a nonexistent prefix (a directory-marker object counts as a child).
                var listPrefix = EnsureTrailingSlash(keyPrefix);
                var resp = RunSync(ct => client.ListObjectsV2Async(new ListObjectsV2Request
                {
                    BucketName = bucket,
                    Prefix = listPrefix,
                    Delimiter = "/",
                    MaxKeys = 1
                }, ct));
                return (resp.S3Objects?.Count ?? 0) > 0 || (resp.CommonPrefixes?.Count ?? 0) > 0;
            }
            catch (AmazonS3Exception ex) when (IsNotFound(ex)) { return false; }
            catch (AmazonS3Exception ex) when (IsAccessDenied(ex)) { return true; }
            // Other S3 errors propagate to NewDrive's catch.
        }

        protected override PSDriveInfo RemoveDrive(PSDriveInfo drive)
        {
            (drive as S3DriveInfo)?.DisposeAllClients();
            return drive;
        }

        // Region precedence: explicit -Region -> session default $StoredAWSRegion (via Common) -> us-east-1.
        private RegionEndpoint ResolveRegion(S3DriveParameters dp)
        {
            if (dp != null && !string.IsNullOrEmpty(dp.Region))
                return ValidRegionOrThrow(dp.Region);

            var sessionRegion = SessionDefaultRegionName();   // $StoredAWSRegion, via Common
            return string.IsNullOrEmpty(sessionRegion)
                ? RegionEndpoint.USEast1
                : ValidRegionOrThrow(sessionRegion);
        }

        // GetBySystemName does NOT throw on an unknown name - it returns a synthetic "Unknown" endpoint
        // that only fails later with an obscure DNS/signing error. Reject it up front instead.
        private static RegionEndpoint ValidRegionOrThrow(string systemName)
        {
            var region = RegionEndpoint.GetBySystemName(systemName);
            if (string.Equals(region.DisplayName, "Unknown", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException(
                    $"'{systemName}' is not a known AWS region. Use a region system name such as 'us-east-1'.");
            return region;
        }

        // Credential precedence: explicit keys -> -ProfileName -> -AWSCredential -> session default
        // $StoredAWSCredentials (via Get-AWSCredential) -> null (SDK default chain).
        private AWSCredentials ResolveCredentials(S3DriveParameters dp)
        {
            if (dp != null)
            {
                if (!string.IsNullOrEmpty(dp.AccessKey) && !string.IsNullOrEmpty(dp.SecretKey))
                {
                    return string.IsNullOrEmpty(dp.SessionToken)
                        ? (AWSCredentials)new BasicAWSCredentials(dp.AccessKey, dp.SecretKey)
                        : new SessionAWSCredentials(dp.AccessKey, dp.SecretKey, dp.SessionToken);
                }

                if (!string.IsNullOrEmpty(dp.ProfileName))
                    return ResolveProfile(dp.ProfileName);

                if (dp.AWSCredential != null)
                    return dp.AWSCredential;
            }

            return SessionDefaultCredentials();   // $StoredAWSCredentials, via Common; null if unset
        }

        private static AWSCredentials ResolveProfile(string profileName)
        {
            var chain = new Amazon.Runtime.CredentialManagement.CredentialProfileStoreChain();
            if (chain.TryGetAWSCredentials(profileName, out var creds))
                return creds;
            throw new ArgumentException($"AWS profile '{profileName}' was not found.");
        }

        // ---- AWS.Tools.Common session defaults ----
        // Invoked through SessionState rather than a compile-time reference to Common. Best-effort:
        // any failure (Common not loaded, no default set) falls through to the next resolution step.

        // $StoredAWSCredentials, unwrapped to raw AWSCredentials by Get-AWSCredential. Null if unset.
        private AWSCredentials SessionDefaultCredentials()
        {
            try
            {
                var results = SessionState.InvokeCommand.InvokeScript("Get-AWSCredential");
                foreach (var o in results)
                    if (o?.BaseObject is AWSCredentials creds)
                        return creds;
            }
            catch { /* Common absent or cmdlet failed -> fall through to the SDK default chain */ }
            return null;
        }

        // $StoredAWSRegion system name via Get-DefaultAWSRegion. Null if unset. The cmdlet writes an
        // AWSRegion whose .Region holds the system name, read reflectively to avoid a Common dependency.
        private string SessionDefaultRegionName()
        {
            try
            {
                var results = SessionState.InvokeCommand.InvokeScript("Get-DefaultAWSRegion");
                foreach (var o in results)
                {
                    if (o == null) continue;
                    var prop = o.Properties["Region"];
                    var name = prop?.Value as string;
                    if (!string.IsNullOrEmpty(name)) return name;
                }
            }
            catch { /* Common absent or cmdlet failed -> fall through to us-east-1 */ }
            return null;
        }

        // ---- Listing ---------------------------------------------------------

        // Backs Get-ChildItem. Root -> ListBuckets; a bucket/prefix -> immediate children, or with
        // -Recurse every object beneath the prefix.
        protected override void GetChildItems(string path, bool recurse)
        {
            if (IsDriveRoot(path))
            {
                foreach (var bucket in ListBuckets())
                    WriteItemObject(S3ItemInfo.Bucket(bucket.BucketName, bucket.CreationDate),
                        MakeItemPath(bucket.BucketName), isContainer: true);
                return;
            }

            ParsePath(path, out var bucket1, out var key);
            try
            {
                if (recurse)
                    StreamAllUnder(bucket1, key, c => WriteItemObject(c.Item, c.Path, c.IsContainer));
                else
                    StreamChildren(bucket1, key, c => WriteItemObject(c.Item, c.Path, c.IsContainer));
            }
            catch (AmazonS3Exception ex)
            {
                WriteError(new ErrorRecord(ex, "ListFailed", ErrorCategory.ReadError, path));
            }
        }

        protected override void GetChildNames(string path, ReturnContainers returnContainers)
        {
            if (IsDriveRoot(path))
            {
                foreach (var bucket in ListBuckets())
                    WriteItemObject(bucket.BucketName, MakeItemPath(bucket.BucketName), isContainer: true);
                return;
            }

            ParsePath(path, out var bucket1, out var key);
            try
            {
                StreamChildren(bucket1, key, c => WriteItemObject(c.Name, c.Path, c.IsContainer));
            }
            catch (AmazonS3Exception ex)
            {
                WriteError(new ErrorRecord(ex, "ListFailed", ErrorCategory.ReadError, path));
            }
        }

        // ---- Get-Item --------------------------------------------------------

        // Backs Get-Item: the single item for the exact path. A name that is both prefix and object
        // resolves to the Folder (folder-wins, as in listing).
        protected override void GetItem(string path)
        {
            if (IsDriveRoot(path))
            {
                foreach (var bucket in ListBuckets())
                    WriteItemObject(S3ItemInfo.Bucket(bucket.BucketName, bucket.CreationDate),
                        MakeItemPath(bucket.BucketName), isContainer: true);
                return;
            }

            ParsePath(path, out var bucket1, out var key);
            try
            {
                if (string.IsNullOrEmpty(key))
                {
                    // Find the bucket in ListBuckets to carry its creation date, else fall back to an
                    // existence probe (e.g. ListAllMyBuckets denied but the bucket is reachable).
                    var b = FindBucket(bucket1);
                    if (b != null)
                        WriteItemObject(S3ItemInfo.Bucket(b.BucketName, b.CreationDate),
                            MakeItemPath(bucket1), isContainer: true);
                    else if (BucketExists(bucket1))
                        WriteItemObject(S3ItemInfo.Bucket(bucket1, null),
                            MakeItemPath(bucket1), isContainer: true);
                    else
                        WriteItemNotFound(path);
                    return;
                }

                // Folder wins over a colliding object. If listing is denied, the object HEAD below
                // still lets buckets that deny ListBucket read/delete known keys.
                var prefixAccessDenied = (AmazonS3Exception)null;
                if (TryPrefixHasChildren(bucket1, key, out prefixAccessDenied))
                {
                    var name = key.TrimEnd('/');
                    var slash = name.LastIndexOf('/');
                    if (slash >= 0) name = name.Substring(slash + 1);
                    WriteItemObject(S3ItemInfo.Folder(name),
                        MakeChildPath(bucket1, EnsureTrailingSlash(key)), isContainer: true);
                    return;
                }

                var meta = TryGetObjectMetadata(bucket1, key);
                if (meta != null)
                {
                    var name = key.TrimEnd('/');
                    var slash = name.LastIndexOf('/');
                    if (slash >= 0) name = name.Substring(slash + 1);
                    WriteItemObject(S3ItemInfo.File(name, meta.ContentLength, meta.LastModified),
                        MakeChildPath(bucket1, key), isContainer: false);
                    return;
                }

                if (prefixAccessDenied != null)
                    throw prefixAccessDenied;
                WriteItemNotFound(path);
            }
            catch (AmazonS3Exception ex)
            {
                WriteError(new ErrorRecord(ex, "GetItemFailed", ErrorCategory.ReadError, path));
            }
        }

        // Find a bucket by name in the account-global ListBuckets result, or null if absent.
        private S3Bucket FindBucket(string bucket)
        {
            try
            {
                foreach (var b in ListBuckets())
                    if (string.Equals(b.BucketName, bucket, StringComparison.Ordinal))
                        return b;
            }
            catch (AmazonS3Exception ex) when (IsAccessDenied(ex)) { return null; }
            return null;
        }

        // HEAD a single object for its metadata, or null if it does not exist.
        private GetObjectMetadataResponse TryGetObjectMetadata(string bucket, string key)
        {
            try
            {
                return RunSync(ct => ClientForBucket(bucket).GetObjectMetadataAsync(
                    new GetObjectMetadataRequest { BucketName = bucket, Key = key }, ct));
            }
            catch (AmazonS3Exception ex) when (IsNotFound(ex)) { return null; }
        }

        private void WriteItemNotFound(string path) =>
            WriteError(new ErrorRecord(
                new ItemNotFoundException($"Cannot find path '{path}' because it does not exist."),
                "ItemNotFound", ErrorCategory.ObjectNotFound, path));

        // ---- Existence / container checks (drive path resolution) ------------

        protected override bool ItemExists(string path)
        {
            if (IsDriveRoot(path)) return true;
            ParsePath(path, out var bucket, out var key);
            try
            {
                if (string.IsNullOrEmpty(key)) return BucketExists(bucket);

                // Per-child cache: no network call if this key was just emitted by a listing. Handles
                // the per-item probes fired during a large listing, before its complete entry exists.
                var child = Drive.ListingCache.TryGetChild(bucket, key);
                if (child.HasValue) return child.Value.exists;

                // Parent prefix's complete cached listing, if present.
                var resolved = ResolveFromParentCache(bucket, key);
                if (resolved.HasValue)
                {
                    if (resolved.Value.exists) return true;

                    // An external writer may have created this key while the parent listing is still in
                    // its TTL; a newer exact probe must override the stale absence.
                    var exactExists = ExactProbeExists(bucket, key);
                    if (exactExists.HasValue)
                        return exactExists.Value;
                    return false;
                }

                // Folder-wins, so check the prefix first. On denied listing, a returned prefixAccessDenied
                // means "probably exists" so the real op can surface AccessDenied.
                var prefixAccessDenied = (AmazonS3Exception)null;
                if (TryPrefixHasChildren(bucket, key, out prefixAccessDenied))
                    return true;
                if (ObjectExists(bucket, key))
                    return true;
                return prefixAccessDenied != null;
            }
            catch (AmazonS3Exception ex) when (IsNotFound(ex)) { return false; }
            // Access-denied returns true (not throw): the engine turns any throw from ItemExists into a
            // misleading "Cannot find path", so we let the real op surface the AccessDenied instead.
            catch (AmazonS3Exception ex) when (IsAccessDenied(ex)) { return true; }
        }

        protected override bool IsItemContainer(string path)
        {
            if (IsDriveRoot(path)) return true;
            ParsePath(path, out var bucket, out var key);
            try
            {
                if (string.IsNullOrEmpty(key)) return BucketExists(bucket); // a bucket is a container

                // Cache layers as in ItemExists: per-child, then the parent's complete listing.
                var child = Drive.ListingCache.TryGetChild(bucket, key);
                if (child.HasValue) return child.Value.isContainer;

                var resolved = ResolveFromParentCache(bucket, key);
                if (resolved.HasValue)
                {
                    if (resolved.Value.exists) return resolved.Value.isContainer;

                    // A newer exact prefix probe overrides a stale parent-listing absence (see ItemExists).
                    var exactExists = ExactProbeExists(bucket, key);
                    if (exactExists == true)
                        return Drive.ListingCache.TryGetExistsProbe(bucket, EnsureTrailingSlash(key), asPrefix: true) == true;
                    if (exactExists == false)
                        return false;
                }

                var prefixAccessDenied = (AmazonS3Exception)null;
                if (TryPrefixHasChildren(bucket, key, out prefixAccessDenied))
                    return true;
                if (prefixAccessDenied != null)
                    return !ObjectExists(bucket, key);
                return false;
            }
            catch (AmazonS3Exception ex) when (IsNotFound(ex)) { return false; }
            // Access-denied: assume container so navigation proceeds (see ItemExists for why).
            catch (AmazonS3Exception ex) when (IsAccessDenied(ex)) { return true; }
        }

        // Resolve exists/isContainer from the parent prefix's complete cached listing, or null if it
        // isn't cached. Splits "a/b/c.txt" into parent "a/b/" + child "c.txt".
        private (bool exists, bool isContainer)? ResolveFromParentCache(string bucket, string key)
        {
            var k = key.TrimEnd('/');
            var slash = k.LastIndexOf('/');
            var parentPrefix = slash < 0 ? "" : k.Substring(0, slash + 1);   // "a/b/" or ""
            var childName = slash < 0 ? k : k.Substring(slash + 1);          // "c.txt"
            return Drive.ListingCache.TryResolveChild(bucket, parentPrefix, childName);
        }

        private bool? ExactProbeExists(string bucket, string key)
        {
            var prefixProbe = Drive.ListingCache.TryGetExistsProbe(bucket, EnsureTrailingSlash(key), asPrefix: true);
            if (prefixProbe == true) return true;

            var objectProbe = Drive.ListingCache.TryGetExistsProbe(bucket, key, asPrefix: false);
            if (objectProbe == true) return true;
            if (prefixProbe == false && objectProbe == false) return false;
            return null;
        }

        protected override bool IsValidPath(string path) => true; // accept anything (S3 keys are near-arbitrary)

        // Must be overridden: the base default throws "not supported", which would break Remove-Item.
        protected override bool HasChildItems(string path)
        {
            if (IsDriveRoot(path)) return true;
            ParsePath(path, out var bucket, out var key);
            try
            {
                if (string.IsNullOrEmpty(key)) return true; // a bucket is a container

                // A recorded container was a CommonPrefix (has children); a recorded object has none.
                var child = Drive.ListingCache.TryGetChild(bucket, key);
                if (child.HasValue) return child.Value.isContainer;

                var prefixAccessDenied = (AmazonS3Exception)null;
                if (TryPrefixHasChildren(bucket, key, out prefixAccessDenied))
                    return true;
                if (prefixAccessDenied != null)
                    return !ObjectExists(bucket, key);
                return false;
            }
            catch (AmazonS3Exception ex) when (IsNotFound(ex)) { return false; }
            // Access-denied: assume children (see ItemExists for why).
            catch (AmazonS3Exception ex) when (IsAccessDenied(ex)) { return true; }
        }

        // ---- Remove ----------------------------------------------------------

        private const int DeleteBatchSize = 1000;   // S3 DeleteObjects caps at 1000 keys/call

        // Backs Remove-Item (object -> DeleteObject; -Recurse prefix -> batched DeleteObjects). Gated
        // by ShouldProcess, so -WhatIf/-Confirm work but there is no prompt by default, like FileSystem.
        protected override void RemoveItem(string path, bool recurse)
        {
            if (!TryParseObjectPath(path,
                    "Remove-Item on the S3 drive requires an object or prefix path (bucket\\key).",
                    "InvalidRemovePath", out var bucket, out var key))
                return;

            try
            {
                // Prefix (folder) when it has children, else a single object. On denied listing the
                // exact-object path still lets a known key be removed without list permission.
                if (TryPrefixHasChildren(bucket, key, out _))
                {
                    if (!recurse)
                    {
                        WriteError(new ErrorRecord(
                            new InvalidOperationException(
                                $"'{path}' is a folder with contents. Use -Recurse to delete it and everything under it."),
                            "PrefixRequiresRecurse", ErrorCategory.InvalidOperation, path));
                        return;
                    }
                    RemovePrefixRecursive(bucket, key, path);
                }
                else
                {
                    if (!ShouldProcess(path, "Remove S3 object"))
                        return;

                    RunSync(ct => ClientForBucket(bucket).DeleteObjectAsync(
                        new DeleteObjectRequest { BucketName = bucket, Key = key }, ct));
                    Drive.ListingCache.InvalidateForKey(bucket, key);
                }
            }
            catch (AmazonS3Exception ex) when (IsNotFound(ex))
            {
                WriteError(new ErrorRecord(ex, "RemoveTargetNotFound", ErrorCategory.ObjectNotFound, path));
            }
            catch (AmazonS3Exception ex)
            {
                WriteError(new ErrorRecord(ex, "RemoveFailed", ErrorCategory.WriteError, path));
            }
        }

        private void RemovePrefixRecursive(string bucket, string key, string displayPath)
        {
            // No extra prompt: -Recurse deletes silently, and the engine's container-recurse prompt
            // (non-empty prefix without -Recurse) was already the confirmation.
            if (!ShouldProcess(displayPath, "Recursively remove S3 prefix and all objects under it"))
                return;

            var client = ClientForBucket(bucket);
            var prefix = EnsureTrailingSlash(key);
            var request = new ListObjectsV2Request { BucketName = bucket, Prefix = prefix };  // no delimiter

            try
            {
                string token = null;
                var batch = new List<KeyVersion>(DeleteBatchSize);
                do
                {
                    request.ContinuationToken = token;
                    var resp = RunSync(ct => client.ListObjectsV2Async(request, ct));

                    if (resp.S3Objects != null)
                    {
                        foreach (var obj in resp.S3Objects)
                        {
                            batch.Add(new KeyVersion { Key = obj.Key });
                            if (batch.Count == DeleteBatchSize)
                            {
                                DeleteBatch(bucket, batch);
                                batch.Clear();
                            }
                        }
                    }

                    token = resp.NextContinuationToken;
                }
                while (!string.IsNullOrEmpty(token));

                // Also delete the object at the exact key: when a name is both folder ("key/...") and
                // object ("key"), the sweep above only covers "key/", leaving the shadowed object behind.
                var exactKey = key.TrimEnd('/');
                if (exactKey.Length > 0)
                    batch.Add(new KeyVersion { Key = exactKey });

                if (batch.Count > 0)
                    DeleteBatch(bucket, batch);
            }
            finally
            {
                // In a finally so a mid-sweep failure still refreshes the view for what was deleted.
                Drive.ListingCache.InvalidateForKey(bucket, key);
            }
        }

        private void DeleteBatch(string bucket, List<KeyVersion> keys)
        {
            try
            {
                RunSync(ct => ClientForBucket(bucket).DeleteObjectsAsync(new DeleteObjectsRequest
                {
                    BucketName = bucket,
                    Objects = keys
                }, ct));
            }
            catch (DeleteObjectsException ex)
            {
                // Partial failure: report each failed key with its S3 error rather than aborting, so
                // the remaining batches still run and the user sees exactly what could not be removed.
                foreach (var e in ex.Response?.DeleteErrors ?? new List<DeleteError>())
                    WriteError(new ErrorRecord(
                        new AmazonS3Exception($"Failed to delete '{e.Key}': {e.Code} {e.Message}"),
                        "RemoveFailed", ErrorCategory.WriteError, e.Key));
            }
        }


        // ---- Content: download / upload (IContentCmdletProvider) -------------

        // Backs Get-Content (download). Opens the object via TransferUtility.OpenStream (parallel
        // multipart + ranged retries) and returns a reader that pulls blocks lazily, so any size
        // streams back with bounded memory.
        public IContentReader GetContentReader(string path)
        {
            if (!TryParseObjectPath(path,
                    "Get-Content requires a path to an S3 object (bucket\\key).",
                    "InvalidContentPath", out var bucket, out var key))
                return null;

            // -AsByteStream / -Raw / -Encoding are dynamic parameters. On a pipeline bind
            // (Get-ChildItem | Get-Content) the engine hands us FileSystem's dynamic-params object, not
            // ours, so ReadContentReaderParams reads them by name off either type rather than casting.
            bool asByteStream, raw;
            System.Text.Encoding encoding;
            try
            {
                ReadContentReaderParams(DynamicParameters, out asByteStream, out raw, out encoding);
            }
            catch (ArgumentException ex)
            {
                WriteError(new ErrorRecord(ex, "BadEncoding", ErrorCategory.InvalidArgument, path));
                return null;
            }

            // The CTS must outlive this method: multipart OpenStream fetches parts on background tasks
            // as the reader reads, so the token stays live for the whole read. The reader owns it and
            // disposes it on Close; StopProcessing cancels it via the content-CTS set.
            var readerCts = new CancellationTokenSource();
            RegisterContentCts(readerCts);
            Drive.BeginContentOperation();   // keep the drive's clients alive for the whole read
            var handedOff = false;   // true once the reader owns readerCts (success path)
            try
            {
                // TU is only needed to open the stream (dispose eagerly); disposing it leaves our
                // shared client and the opened multipart stream intact.
                Stream stream;
                using (var tu = TransferUtilityForBucket(bucket))
                {
                    var req = new Amazon.S3.Transfer.TransferUtilityOpenStreamRequest
                    {
                        BucketName = bucket,
                        Key = key,
                        MultipartDownloadType = Amazon.S3.Transfer.MultipartDownloadType.PART,
                    };
                    stream = tu.OpenStreamAsync(req, readerCts.Token).GetAwaiter().GetResult();
                }
                var reader = new S3ContentReader(stream, readerCts, asByteStream, raw, encoding,
                    onDispose: () => { UnregisterContentCts(readerCts); Drive.EndContentOperation(); });
                handedOff = true;   // reader now owns readerCts; the finally must NOT dispose it
                return reader;
            }
            catch (AmazonS3Exception ex) when (IsNotFound(ex))
            {
                WriteError(new ErrorRecord(ex, "ObjectNotFound", ErrorCategory.ObjectNotFound, path));
                return null;
            }
            catch (AmazonS3Exception ex)
            {
                WriteError(new ErrorRecord(ex, "GetContentFailed", ErrorCategory.ReadError, path));
                return null;
            }
            finally
            {
                // On any non-success exit, release readerCts and end the content op. On success the
                // reader owns it (via onDispose), so leave it alone.
                if (!handedOff)
                {
                    UnregisterContentCts(readerCts);
                    readerCts.Dispose();
                    Drive.EndContentOperation();
                }
            }
        }

        public object GetContentReaderDynamicParameters(string path) =>
            new S3ContentReaderDynamicParameters();

        // Read AsByteStream / Raw / Encoding off our dynamic-params type or, on a pipeline bind,
        // FileSystem's (same property names, but its Encoding is a System.Text.Encoding, not a string).
        private static void ReadContentReaderParams(object dp, out bool asByteStream, out bool raw, out System.Text.Encoding encoding)
        {
            asByteStream = false; raw = false; encoding = ResolveEncoding(null);   // default UTF-8 no-BOM
            if (dp == null) return;

            if (dp is S3ContentReaderDynamicParameters ours)
            {
                asByteStream = ours.AsByteStream.IsPresent;
                raw = ours.Raw.IsPresent;
                encoding = ResolveEncoding(ours.Encoding);
                return;
            }

            // Foreign params object (e.g. FileSystem's): read by property name.
            var t = dp.GetType();
            asByteStream = ReadSwitchLike(dp, t, "AsByteStream");
            raw = ReadSwitchLike(dp, t, "Raw");
            var enc = t.GetProperty("Encoding")?.GetValue(dp);
            if (enc is System.Text.Encoding realEnc)
                encoding = realEnc;                          // FileSystem hands a ready Encoding object
            else if (enc is string encName && encName.Length > 0)
                encoding = ResolveEncoding(encName);         // our shape: a friendly name
            // else: leave the UTF-8 default
        }

        // As ReadContentReaderParams, for the writer. S3-only params (PartSize, StorageClass) stay
        // available only from our native type.
        private static void ReadContentWriterParams(object dp, out bool asByteStream, out bool noNewline, out System.Text.Encoding encoding)
        {
            asByteStream = false; noNewline = false; encoding = ResolveEncoding(null);   // default UTF-8 no-BOM
            if (dp == null) return;

            if (dp is S3ContentWriterDynamicParameters ours)
            {
                asByteStream = ours.AsByteStream.IsPresent;
                noNewline = ours.NoNewline.IsPresent;
                encoding = ResolveEncoding(ours.Encoding);
                return;
            }

            // Foreign params object (e.g. FileSystem's): read by property name.
            var t = dp.GetType();
            asByteStream = ReadSwitchLike(dp, t, "AsByteStream");
            noNewline = ReadSwitchLike(dp, t, "NoNewline");
            encoding = ReadEncodingLike(t.GetProperty("Encoding")?.GetValue(dp), encoding);
        }

        // True if property 'name' on dp is a set SwitchParameter or a true bool.
        private static bool ReadSwitchLike(object dp, Type t, string name)
        {
            var val = t.GetProperty(name)?.GetValue(dp);
            if (val == null) return false;
            if (val is SwitchParameter sw) return sw.IsPresent;
            if (val is bool b) return b;
            return false;
        }

        private static System.Text.Encoding ReadEncodingLike(object val, System.Text.Encoding defaultEncoding)
        {
            if (val == null) return defaultEncoding;
            if (val is System.Text.Encoding realEnc) return realEnc;

            var encName = val as string;
            if (encName == null && val.GetType().IsEnum)
                encName = val.ToString();   // Windows PowerShell 5.1 FileSystem dynamic params use an enum.

            if (string.IsNullOrWhiteSpace(encName))
                return defaultEncoding;

            // FileSystem's Windows PowerShell enum uses String/Unknown as unspecified sentinels.
            if (string.Equals(encName, "String", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(encName, "Unknown", StringComparison.OrdinalIgnoreCase))
                return defaultEncoding;

            return ResolveEncoding(encName);
        }

        // Backs Set-Content (upload). The writer feeds TU a non-seekable bridge stream, so every upload
        // takes TU's multipart path: the object is replaced only at CompleteMultipartUpload, and TU
        // aborts on failure/cancellation. Bounded memory (the bridge applies backpressure), no temp file.
        public IContentWriter GetContentWriter(string path)
        {
            if (!TryParseObjectPath(path,
                    "Set-Content requires a path to an S3 object (bucket\\key).",
                    "InvalidContentPath", out var bucket, out var key))
                return null;

            bool asByteStream, noNewline;
            System.Text.Encoding encoding;
            try
            {
                ReadContentWriterParams(DynamicParameters, out asByteStream, out noNewline, out encoding);
            }
            catch (ArgumentException ex)
            {
                WriteError(new ErrorRecord(ex, "BadEncoding", ErrorCategory.InvalidArgument, path));
                return null;
            }

            var writerParams = DynamicParameters as S3ContentWriterDynamicParameters;
            // Per-upload -StorageClass wins, else the drive default, else null (nothing set on the request).
            var storageClass = writerParams?.StorageClass ?? Drive.DefaultStorageClass;
            var partSize = writerParams != null && writerParams.PartSize > 0
                ? writerParams.PartSize
                : MultipartThreshold;
            var cache = Drive.ListingCache;

            // Register the writer's CTS in the content-CTS set so Ctrl+C cancels the in-flight upload.
            // On success the writer owns the CTS + TU; otherwise the finally releases them (handedOff guard).
            var writerCts = new CancellationTokenSource();
            RegisterContentCts(writerCts);
            Drive.BeginContentOperation();   // keep the drive's clients alive for the whole upload
            Amazon.S3.Transfer.TransferUtility tu = null;
            var handedOff = false;
            try
            {
                tu = TransferUtilityForBucket(bucket);
                var writer = new S3TransferContentWriter(tu, bucket, key, asByteStream, writerCts,
                    onComplete: () => cache.InvalidateForKey(bucket, key),
                    onFault: ex => WriteError(new ErrorRecord(ex, "UploadFailed",
                        ErrorCategory.WriteError, $"{bucket}\\{key}")),
                    onDispose: () => { UnregisterContentCts(writerCts); Drive.EndContentOperation(); },
                    partSize: partSize,
                    storageClass: storageClass,
                    encoding: encoding,
                    noNewline: noNewline);
                handedOff = true;   // writer now owns tu + writerCts
                return writer;
            }
            finally
            {
                if (!handedOff)
                {
                    UnregisterContentCts(writerCts);
                    tu?.Dispose();
                    writerCts.Dispose();
                    Drive.EndContentOperation();
                }
            }
        }

        public object GetContentWriterDynamicParameters(string path) =>
            new S3ContentWriterDynamicParameters();

        public void ClearContent(string path)
        {
            throw new PSNotSupportedException(
                "Clear-Content is not supported by the S3 drive.");
        }

        public object ClearContentDynamicParameters(string path) => null;

        // ---- S3 calls --------------------------------------------------------

        private List<S3Bucket> ListBuckets()
        {
            var response = RunSync(ct => Client.ListBucketsAsync(new ListBucketsRequest(), ct));
            return response.Buckets ?? new List<S3Bucket>();
        }

        // Cap on entries accumulated for a COMPLETE cache entry. Past it we drop the accumulator and
        // stream without caching, so a huge prefix stays O(1) memory. Listing output is never capped.
        private const int ListingCacheMaxItems = 10000;

        // One level of children under bucket/key via a delimited, paginated ListObjectsV2:
        // CommonPrefixes -> folders, objects -> files, and the prefix's own directory-marker is
        // filtered out. Streams each child to <paramref name="emit"/> as its page arrives (bounded
        // memory) and stops between pages on Ctrl+C.
        private void StreamChildren(string bucket, string key, Action<ChildEntry> emit)
        {
            var listPrefix = string.IsNullOrEmpty(key) ? "" : EnsureTrailingSlash(key);

            var cached = Drive.ListingCache.TryGetComplete(bucket, listPrefix);
            if (cached != null)
            {
                foreach (var c in cached) emit(c);
                return;
            }

            var client = ClientForBucket(bucket);
            // Folder names seen this listing, used to shadow a colliding object (folder-wins). Only
            // reliable when the object and its CommonPrefix share a page; across a page boundary the
            // object may list once alongside the folder - accepted, to keep the listing streaming.
            var folderNames = new HashSet<string>(StringComparer.Ordinal);

            // Accumulate to upgrade the cache to COMPLETE, but only if we finish uninterrupted and under
            // the cap - a truncated listing cached as complete would make existence checks read "absent".
            // Null once over the cap => stream without caching.
            var accum = new List<ChildEntry>();
            var prefixMarkerSeen = false;
            var request = new ListObjectsV2Request
            {
                BucketName = bucket,
                Prefix = listPrefix,
                Delimiter = "/"
            };

            string token = null;
            do
            {
                if (Stopping) return;                          // Ctrl+C between pages: stop cleanly, don't cache
                request.ContinuationToken = token;
                var resp = RunSync(ct => client.ListObjectsV2Async(request, ct));

                if (resp.CommonPrefixes != null)
                {
                    foreach (var cp in resp.CommonPrefixes)
                    {
                        var name = cp.Substring(listPrefix.Length).TrimEnd('/');
                        if (name.Length == 0) continue;
                        if (!folderNames.Add(name)) continue;   // already added this folder
                        var entry = new ChildEntry
                        {
                            Name = name,
                            IsContainer = true,
                            Item = S3ItemInfo.Folder(name),    // uniform item: Name/Type, no Size
                            Path = MakeChildPath(bucket, cp)
                        };
                        // Record before emit: the engine may decorate (ItemExists/IsItemContainer)
                        // synchronously during emit, so the record must already be present.
                        Drive.ListingCache.RecordChild(bucket, cp, isContainer: true);
                        emit(entry);
                        accum = Accumulate(accum, entry);
                    }
                }

                if (resp.S3Objects != null)
                {
                    foreach (var obj in resp.S3Objects)
                    {
                        if (obj.Key == listPrefix)
                        {
                            prefixMarkerSeen = true;
                            if (!string.IsNullOrEmpty(listPrefix))
                                Drive.ListingCache.RecordChild(bucket, listPrefix, isContainer: true);
                            continue;   // the folder's own marker, not a child
                        }
                        var name = obj.Key.Substring(listPrefix.Length);
                        if (name.Length == 0) continue;
                        if (folderNames.Contains(name)) continue;  // a folder shadows the colliding object
                        var entry = new ChildEntry
                        {
                            Name = name,
                            IsContainer = false,
                            Item = S3ItemInfo.File(name, obj.Size, obj.LastModified),
                            Path = MakeChildPath(bucket, obj.Key)
                        };
                        Drive.ListingCache.RecordChild(bucket, obj.Key, isContainer: false);
                        emit(entry);
                        accum = Accumulate(accum, entry);
                    }
                }

                token = resp.NextContinuationToken;            // null/empty when not truncated
            }
            while (!string.IsNullOrEmpty(token));

            // Fully enumerated and under the cap -> cache COMPLETE.
            if (accum != null)
            {
                Drive.ListingCache.PutComplete(bucket, listPrefix, accum, prefixMarkerSeen);
                if (prefixMarkerSeen)
                    Drive.ListingCache.PutExistsProbe(bucket, listPrefix, asPrefix: true, exists: true);
            }
        }

        // Append to the accumulator, or return null once over the cap (null in => stays null).
        private static List<ChildEntry> Accumulate(List<ChildEntry> accum, ChildEntry entry)
        {
            if (accum == null) return null;
            if (accum.Count >= ListingCacheMaxItems) return null;
            accum.Add(entry);
            return accum;
        }

        // Backs Get-ChildItem -Recurse: every object beneath a prefix, via a delimiter-less paginated
        // ListObjectsV2 (flat, no CommonPrefixes). Streams like StreamChildren but does not cache, so
        // it stays O(1) memory however large the listing.
        private void StreamAllUnder(string bucket, string key, Action<ChildEntry> emit)
        {
            var client = ClientForBucket(bucket);
            var listPrefix = string.IsNullOrEmpty(key) ? "" : EnsureTrailingSlash(key);
            var request = new ListObjectsV2Request
            {
                BucketName = bucket,
                Prefix = listPrefix          // no Delimiter => fully recursive
            };

            string token = null;
            do
            {
                if (Stopping) return;                          // Ctrl+C between pages
                request.ContinuationToken = token;
                var resp = RunSync(ct => client.ListObjectsV2Async(request, ct));

                if (resp.S3Objects != null)
                {
                    foreach (var obj in resp.S3Objects)
                    {
                        if (obj.Key.EndsWith("/")) continue;   // directory marker, not a real file
                        var name = obj.Key.Substring(listPrefix.Length);
                        if (name.Length == 0) continue;
                        // Record before emit so per-item decoration resolves without a probe.
                        Drive.ListingCache.RecordChild(bucket, obj.Key, isContainer: false);
                        emit(new ChildEntry
                        {
                            Name = name,                       // relative key, may contain "/"
                            IsContainer = false,
                            Item = S3ItemInfo.File(name, obj.Size, obj.LastModified),
                            Path = MakeChildPath(bucket, obj.Key)
                        });
                    }
                }

                token = resp.NextContinuationToken;
            }
            while (!string.IsNullOrEmpty(token));
        }

        private bool BucketExists(string bucket)
        {
            try
            {
                RunSync(ct => ClientForBucket(bucket).ListObjectsV2Async(
                    new ListObjectsV2Request { BucketName = bucket, MaxKeys = 1 }, ct));
                return true;
            }
            catch (AmazonS3Exception ex) when (IsNotFound(ex)) { return false; }
            catch (AmazonS3Exception ex) when (IsAccessDenied(ex)) { return true; }
        }

        private bool TryPrefixHasChildren(string bucket, string key, out AmazonS3Exception accessDenied)
        {
            accessDenied = null;
            try
            {
                return PrefixHasChildren(bucket, key);
            }
            catch (AmazonS3Exception ex) when (IsAccessDenied(ex))
            {
                accessDenied = ex;
                return false;
            }
        }

        private bool PrefixHasChildren(string bucket, string key)
        {
            var listPrefix = EnsureTrailingSlash(key);

            // Short-TTL listing cache: authoritative for a recent Get-ChildItem / drive-originated write.
            var cached = Drive.ListingCache.TryHasChildren(bucket, listPrefix);
            if (cached.HasValue)
                return cached.Value;

            // Longer-TTL existence-probe cache: prefix existence is stable, so a positive result
            // survives a whole command and de-thrashes the engine's repeated deep-ancestor walks.
            var probed = Drive.ListingCache.TryGetExistsProbe(bucket, listPrefix, asPrefix: true);
            if (probed.HasValue)
                return probed.Value;

            var req = new ListObjectsV2Request
            {
                BucketName = bucket,
                Prefix = listPrefix,
                Delimiter = "/",
                MaxKeys = 1
            };
            var resp = RunSync(ct => ClientForBucket(bucket).ListObjectsV2Async(req, ct));
            var has = (resp.S3Objects?.Count ?? 0) > 0 || (resp.CommonPrefixes?.Count ?? 0) > 0;

            // Populate both caches.
            Drive.ListingCache.PutPartial(bucket, listPrefix, has);
            Drive.ListingCache.PutExistsProbe(bucket, listPrefix, asPrefix: true, exists: has);
            return has;
        }

        private bool ObjectExists(string bucket, string key)
        {
            // Cache the HEAD outcome (true or false): the engine resolves ItemExists many times per
            // command, so this avoids re-probing the same key. Invalidated on any write/delete at the key.
            var cached = Drive.ListingCache.TryGetExistsProbe(bucket, key, asPrefix: false);
            if (cached.HasValue)
                return cached.Value;

            try
            {
                RunSync(ct => ClientForBucket(bucket).GetObjectMetadataAsync(
                    new GetObjectMetadataRequest { BucketName = bucket, Key = key }, ct));
                Drive.ListingCache.PutExistsProbe(bucket, key, asPrefix: false, exists: true);
                return true;
            }
            catch (AmazonS3Exception ex) when (IsNotFound(ex))
            {
                Drive.ListingCache.PutExistsProbe(bucket, key, asPrefix: false, exists: false);
                return false;
            }
            // AccessDenied is neither cached nor caught: it propagates to the caller, which treats it
            // as "exists" so the real op surfaces the genuine error.
        }

        private static bool IsNotFound(AmazonS3Exception ex) =>
            ex.StatusCode == HttpStatusCode.NotFound
            || string.Equals(ex.ErrorCode, "NoSuchBucket", StringComparison.OrdinalIgnoreCase)
            || string.Equals(ex.ErrorCode, "NoSuchKey", StringComparison.OrdinalIgnoreCase);

        private static bool IsAccessDenied(AmazonS3Exception ex) =>
            ex.StatusCode == HttpStatusCode.Forbidden
            || string.Equals(ex.ErrorCode, "AccessDenied", StringComparison.OrdinalIgnoreCase);

        // ---- Cancellation ----------------------------------------------------

        private volatile CancellationTokenSource _currentCts;

        // Content reader/writer CTSes span a whole streamed read/upload, outliving the single SDK call
        // that _currentCts tracks. A set, because several can be live at once (e.g. Get-Content |
        // Set-Content) and StopProcessing must cancel all of them.
        private readonly System.Collections.Concurrent.ConcurrentDictionary<CancellationTokenSource, byte> _contentCtses =
            new System.Collections.Concurrent.ConcurrentDictionary<CancellationTokenSource, byte>();

        private void RegisterContentCts(CancellationTokenSource cts) => _contentCtses.TryAdd(cts, 0);
        private void UnregisterContentCts(CancellationTokenSource cts) => _contentCtses.TryRemove(cts, out _);

        protected override void StopProcessing()
        {
            base.StopProcessing();
            S3Cancellation.SafeCancel(_currentCts);
            foreach (var cts in _contentCtses.Keys)
                S3Cancellation.SafeCancel(cts);
        }

        // Block on an async SDK call, wiring its cancellation token to Ctrl+C (StopProcessing).
        private T RunSync<T>(Func<CancellationToken, Task<T>> op)
        {
            using (var cts = new CancellationTokenSource())
            {
                _currentCts = cts;
                try { return op(cts.Token).GetAwaiter().GetResult(); }
                finally { _currentCts = null; }
            }
        }

        // ---- Path helpers ----------------------------------------------------

        private bool IsDriveRoot(string path)
        {
            if (string.IsNullOrEmpty(path)) return true;
            return path.Trim('\\', '/').Length == 0;
        }

        // Split a provider path into bucket + S3 key ("my-bucket\2026\q2" -> "my-bucket", "2026/q2").
        // Strips any "<provider>::" and "<drive>:" qualifier first: the engine sometimes hands us a
        // qualified path (e.g. "AWS.Tools.S3\AWS.S3::S3:\bucket\key"), which would otherwise parse the
        // bucket as "S3:" and probe a garbage bucket.
        private void ParsePath(string path, out string bucket, out string key)
        {
            bucket = "";
            key = "";
            if (string.IsNullOrEmpty(path)) return;

            var p = path;
            string driveQualifier = null;

            // Strip a provider-qualified prefix "Module\Provider::" if present. A key may contain
            // "::", so only treat it as a qualifier when the left side names this provider.
            var sep = p.IndexOf("::", StringComparison.Ordinal);
            if (sep >= 0 && IsProviderQualifier(p.Substring(0, sep)))
                p = p.Substring(sep + 2);

            // Strip a leading drive qualifier "name:" (e.g. "S3:"). A key may contain ':', so the
            // colon is a qualifier only when it appears before the first path separator.
            var colon = p.IndexOf(':');
            var firstSeparator = p.IndexOfAny(new[] { '\\', '/' });
            if (colon >= 0 && (firstSeparator < 0 || colon < firstSeparator))
            {
                driveQualifier = p.Substring(0, colon);
                p = p.Substring(colon + 1);
            }

            var norm = p.Replace('\\', '/').Trim('/');
            norm = ApplyDriveRoot(norm, driveQualifier);
            if (norm.Length == 0) return;

            var idx = norm.IndexOf('/');
            if (idx < 0) { bucket = norm; }
            else { bucket = norm.Substring(0, idx); key = norm.Substring(idx + 1); }
        }

        // For a rooted drive (Root = "bucket/prefix"), the engine sometimes hands a root-relative child
        // path instead of prepending the root. Rebase it onto the real bucket/key so a write/delete
        // stays scoped under the mounted root.
        private string ApplyDriveRoot(string normalizedPath, string driveQualifier)
        {
            if (string.IsNullOrEmpty(normalizedPath)) return normalizedPath;

            var root = ResolveDriveRoot(driveQualifier);
            if (string.IsNullOrWhiteSpace(root)) return normalizedPath;

            var normalizedRoot = root.Replace('\\', '/').Trim('/');
            if (normalizedRoot.Length == 0) return normalizedPath;

            var relative = normalizedPath;
            var rootWithSlash = normalizedRoot + "/";

            if (string.Equals(relative, normalizedRoot, StringComparison.Ordinal))
                relative = "";
            else if (relative.StartsWith(rootWithSlash, StringComparison.Ordinal))
                relative = relative.Substring(rootWithSlash.Length);
            else
            {
                var slash = normalizedRoot.IndexOf('/');
                var rootKey = slash < 0 ? "" : normalizedRoot.Substring(slash + 1);
                if (!string.IsNullOrEmpty(rootKey))
                {
                    var rootKeyWithSlash = rootKey + "/";
                    if (string.Equals(relative, rootKey, StringComparison.Ordinal))
                        relative = "";
                    else if (relative.StartsWith(rootKeyWithSlash, StringComparison.Ordinal))
                        relative = relative.Substring(rootKeyWithSlash.Length);
                }
            }

            // The engine can feed the root back repeated ("bucket/prefix/bucket/prefix/new.txt");
            // collapse the repeats to a single base.
            while (string.Equals(relative, normalizedRoot, StringComparison.Ordinal) ||
                   relative.StartsWith(rootWithSlash, StringComparison.Ordinal))
            {
                relative = relative.Length == normalizedRoot.Length
                    ? ""
                    : relative.Substring(rootWithSlash.Length);
            }

            return string.IsNullOrEmpty(relative)
                ? normalizedRoot
                : normalizedRoot + "/" + relative;
        }

        private string ResolveDriveRoot(string driveQualifier)
        {
            if (!string.IsNullOrEmpty(driveQualifier) && ProviderInfo?.Drives != null)
            {
                foreach (var d in ProviderInfo.Drives)
                    if (string.Equals(d.Name, driveQualifier, StringComparison.OrdinalIgnoreCase))
                        return d.Root;
            }

            if (!string.IsNullOrEmpty(PSDriveInfo?.Root))
                return PSDriveInfo.Root;

            return null;
        }

        private bool IsProviderQualifier(string qualifier)
        {
            if (string.IsNullOrEmpty(qualifier)) return false;

            var providerName = ProviderInfo?.Name ?? "AWS.S3";
            var q = qualifier.Replace('/', '\\');
            return string.Equals(q, providerName, StringComparison.OrdinalIgnoreCase)
                || q.EndsWith("\\" + providerName, StringComparison.OrdinalIgnoreCase);
        }

        // Parse a path that must point at an object (non-empty bucket AND key); on failure WriteErrors
        // with the given message/id and returns false. Shared by RemoveItem/GetContent{Reader,Writer}.
        private bool TryParseObjectPath(string path, string message, string errorId,
            out string bucket, out string key)
        {
            ParsePath(path, out bucket, out key);
            if (string.IsNullOrEmpty(bucket) || string.IsNullOrEmpty(key))
            {
                WriteError(new ErrorRecord(
                    new ArgumentException(message), errorId, ErrorCategory.InvalidArgument, path));
                return false;
            }
            return true;
        }

        private static string EnsureTrailingSlash(string key) =>
            key.EndsWith("/") ? key : key + "/";

        // Map the friendly -Encoding names (matching the built-in cmdlet) to encodings; UTF-8 no-BOM
        // when unspecified.
        private static System.Text.Encoding ResolveEncoding(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return new System.Text.UTF8Encoding(false);

            switch (name.Trim().ToLowerInvariant())
            {
                case "ascii":             return System.Text.Encoding.ASCII;
                case "utf8":
                case "utf8nobom":         return new System.Text.UTF8Encoding(false);
                case "utf8bom":           return new System.Text.UTF8Encoding(true);
                case "utf16":
                case "unicode":           return System.Text.Encoding.Unicode;
                case "bigendianunicode":  return System.Text.Encoding.BigEndianUnicode;
                case "utf32":             return System.Text.Encoding.UTF32;
                case "latin1":            return System.Text.Encoding.GetEncoding("iso-8859-1");
                default:
                    // Fall back to .NET's own lookup (accepts code pages / canonical names).
                    try { return System.Text.Encoding.GetEncoding(name); }
                    catch { throw new ArgumentException($"Unsupported -Encoding value '{name}'."); }
            }
        }

        // Separator to EMIT in paths handed back to the engine: OS-native ('\' on Windows, '/' else).
        // ParsePath accepts both on input, so only path-building is OS-aware.
        private static readonly char Sep =
            System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(
                System.Runtime.InteropServices.OSPlatform.Windows) ? '\\' : '/';

        // Emit the provider-internal, drive-INDEPENDENT path (bucket + key), not "S3:\...". The engine
        // wraps it as "Module\Provider::<path>" and, when that is piped back, re-resolves the remainder
        // against the hidden drive; a "S3:" qualifier here would leave a dangling "S3:" it can't resolve.
        // Built-in providers do the same (FileSystem emits "C:\foo", not a drive-qualified path).
        private string MakeItemPath(string childName) => childName;

        // "b", "2026/q2/x.csv" -> "b\2026\q2\x.csv" (OS-native separator; drive-independent, see MakeItemPath).
        private string MakeChildPath(string bucket, string fullKey)
        {
            var rel = fullKey.TrimEnd('/').Replace('/', Sep);
            return $"{bucket}{Sep}{rel}";
        }
    }
}
