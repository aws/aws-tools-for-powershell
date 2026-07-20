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
    /// Amazon S3 surfaced as a navigable PowerShell drive (ships in AWS.Tools.S3).
    ///
    /// A NavigationCmdletProvider (+ IContentCmdletProvider) mapping S3's bucket/prefix/object
    /// structure onto a file-system model: buckets and prefixes are folders, objects are files.
    /// It calls the AWS SDK (AmazonS3Client) directly for all S3 operations; it does not invoke
    /// the S3 cmdlets. Credential/region resolution is shared with AWS.Tools.Common.
    ///
    /// Operations implemented:
    ///   * root Get-ChildItem             -> ListBuckets
    ///   * bucket/prefix listing          -> ListObjectsV2 (delimiter "/"), streamed + paginated
    ///   * ItemExists / IsItemContainer   -> path resolution + tab-completion
    ///   * Get-Content (download)         -> GetContentReader, TransferUtility.OpenStream
    ///   * Set-Content (upload)           -> GetContentWriter, TransferUtility.Upload (bridged)
    ///   * Remove-Item                    -> DeleteObject / recursive batched DeleteObjects
    ///   * multi-region routing, listing cache
    ///
    /// Credential/region resolution reuses AWS.Tools.Common's session defaults
    /// ($StoredAWSCredentials / $StoredAWSRegion) by invoking its cmdlets through SessionState
    /// (no compile-time dependency); explicit drive parameters take precedence, the SDK default
    /// chain is the final fallback. See ResolveRegion / ResolveCredentials.
    ///
    /// Out of scope: Copy-Item (S3->S3 copy is not supported; CopyItem is not overridden, so it
    /// errors as unsupported).
    /// </summary>
    [CmdletProvider("AWS.S3", ProviderCapabilities.None)]
    public sealed class S3Provider : NavigationCmdletProvider, IContentCmdletProvider
    {
        // The per-drive state (clients, caches). Normally this.PSDriveInfo IS our S3DriveInfo.
        // BUT for a PROVIDER-QUALIFIED path (e.g. a listed item's PSPath
        // "AWS.Tools.S3\AWS.S3::bucket\key" piped into Get-Content / Remove-Item), the
        // engine resolves against the provider's HIDDEN drive - a plain PSDriveInfo (or null),
        // NOT our S3DriveInfo - so a direct cast would NRE and the op fails as "does not exist"
        // before our real logic runs. In that mode we recover the actual mounted drive from
        // ProviderInfo.Drives (the user's S3DriveInfo(s) live there regardless of PSDriveInfo).
        // With one mounted S3 drive (the overwhelmingly common case) this is unambiguous; with
        // several we take the first, since a provider-qualified path carries no drive identity to
        // disambiguate (the credentials/region it resolves under are then that drive's).
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

        /// <summary>
        /// The client for the region a given bucket lives in. On first touch of a bucket we
        /// resolve its region (GetBucketLocation), cache the bucket->region mapping, and reuse
        /// one client per region. A bucket in the mount region just returns the mount client.
        /// This is what lets one drive span all regions transparently.
        /// </summary>
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

        // Resolve a bucket's region using an explicit resolver client (pinned to some region;
        // GetBucketLocation works cross-region, so any live client answers correctly).
        //
        // Takes the client as a parameter rather than reading the Client property because this
        // is also called at mount time from NewDrive/ValidateRoot, where this.PSDriveInfo (and
        // therefore Drive/Client) is not yet populated by the engine - so we pass the local
        // mount client instead.
        //
        // NOTE (corrects the design's HeadBucket plan): HeadBucket via a region-pinned client
        // throws MovedPermanently for an out-of-region bucket instead of returning BucketRegion
        // cleanly (verified). GetBucketLocation is the operation built to answer "what region?"
        // and works cross-region. Quirk: us-east-1 buckets return a null/empty location.
        private string ResolveBucketRegion(IAmazonS3 resolver, string bucket)
        {
            var resp = RunSync(ct => resolver.GetBucketLocationAsync(
                new GetBucketLocationRequest { BucketName = bucket }, ct));
            var loc = resp.Location?.Value;
            if (string.IsNullOrEmpty(loc)) return "us-east-1";   // null/"" => us-east-1
            if (loc == "EU") return "eu-west-1";                 // legacy alias
            return loc;
        }

        // 8 MiB single-vs-multipart threshold, reused as TransferUtility's MinSizeBeforePartUpload
        // and as the default PartSize for non-seekable PSDrive uploads. The SDK's non-seekable
        // path falls back to S3's 5 MiB minimum when PartSize is unset, which can exceed S3's
        // 10,000-part limit for uploads past ~49 GiB (5 MiB x 10,000). Set-Content -PartSize can override this per upload.
        private const long MultipartThreshold = 8 * 1024 * 1024;

        /// <summary>
        /// A TransferUtility bound to the bucket's region client. Built per call (cheap - it is a
        /// thin wrapper over the already-cached client); reusing the client preserves multi-region
        /// routing and the drive's resolved credentials. MinSizeBeforePartUpload reuses our 8 MiB
        /// single-vs-multipart threshold.
        /// </summary>
        private Amazon.S3.Transfer.TransferUtility TransferUtilityForBucket(string bucket) =>
            new Amazon.S3.Transfer.TransferUtility(ClientForBucket(bucket),
                new Amazon.S3.Transfer.TransferUtilityConfig { MinSizeBeforePartUpload = MultipartThreshold });

        // ---- Drive lifecycle -------------------------------------------------

        /// <summary>
        /// Contributes the credential/region parameters to New-PSDrive when -PSProvider is
        /// AWS.S3, so `New-PSDrive -PSProvider AWS.S3 -ProfileName p -Region r` works (and so
        /// does Mount-S3PSDrive, which forwards these).
        /// </summary>
        protected override object NewDriveDynamicParameters() => new S3DriveParameters();

        /// <summary>
        /// Called by New-PSDrive. Resolves region/credentials (explicit drive parameters first,
        /// then the AWS.Tools.Common session defaults $StoredAWSRegion / $StoredAWSCredentials,
        /// then the SDK default chain) and builds the AmazonS3Client for the drive.
        /// </summary>
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

                // Hand creds + mount region to the drive so it can build per-region clients
                // on demand for cross-region buckets (see ClientForBucket). dp?.StorageClass is the
                // drive-level default applied to uploads (null when -StorageClass was omitted).
                // Build it into a LOCAL first: this.PSDriveInfo (and therefore Drive/Client) is
                // still null here - the engine assigns it only AFTER NewDrive returns - so
                // fail-fast root validation must run against this local instance and the local
                // mount client, never the instance properties.
                var s3drive = new S3DriveInfo(drive, creds, region, client, dp?.StorageClass);

                // Fail fast if the drive root ("", "bucket", or "bucket/prefix") isn't reachable,
                // so a typo'd bucket/prefix errors at mount instead of at first listing. Returning
                // null after WriteError makes New-PSDrive fail cleanly with no drive left behind.
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

        /// <summary>
        /// Mount-time reachability check for the drive root, so a bad bucket/prefix fails at mount
        /// rather than at first listing. Runs against the LOCAL drive + mount client (this.Drive is
        /// null inside NewDrive). Returns true = mount; false = reject.
        ///
        ///   * Empty root (account root): one ListBuckets to validate credentials. AccessDenied
        ///     PASSES (valid creds, just no s3:ListAllMyBuckets); any other error (expired/invalid
        ///     creds) FAILS.
        ///   * Bucket-only root ("bucket"): the bucket must exist. An empty bucket still passes.
        ///   * Bucket+prefix root ("bucket/prefix"): the prefix must EXIST - i.e. a delimited
        ///     listing returns >=1 object or subfolder (a zero-byte directory-marker object counts,
        ///     since its own key is returned under the prefix). A typo'd or truly-empty prefix
        ///     fails. This mirrors the FileSystem provider refusing a nonexistent -Root.
        ///
        /// AccessDenied (403) never fails a mount (matches ItemExists/IsItemContainer): the resource
        /// exists, we just can't inspect it; the real error surfaces on the actual operation.
        /// </summary>
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
                // Any other exception (ExpiredToken/InvalidAccessKeyId/SignatureDoesNotMatch, or a
                // non-S3 credential-resolution failure) is NOT caught here: it propagates to
                // NewDrive's catch, which rejects the mount as NewDriveFailed (OpenError) carrying
                // the real error message.
            }

            // Bucket (and maybe prefix) root: resolve the bucket's region, then probe it with a
            // region-correct client. GetBucketLocation works cross-region via the mount client.
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
                // Can't read the bucket's location, but the creds are valid - fall back to the
                // mount region and let the actual operation surface any real AccessDenied later.
                regionName = drive.MountRegionName;
            }

            drive.CacheBucketRegion(bucket, regionName);
            var client = drive.ClientForRegion(regionName);

            try
            {
                if (string.IsNullOrEmpty(keyPrefix))
                {
                    // Bucket-only: existence probe (an empty bucket is a valid mount).
                    RunSync(ct => client.ListObjectsV2Async(
                        new ListObjectsV2Request { BucketName = bucket, MaxKeys = 1 }, ct));
                    return true;
                }

                // Prefix root: the prefix must exist (>=1 child, marker object counts).
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
            // Other S3 errors (throttling, 5xx not absorbed by SDK retries) propagate to NewDrive's
            // catch and surface as NewDriveFailed with the real message.
        }

        protected override PSDriveInfo RemoveDrive(PSDriveInfo drive)
        {
            (drive as S3DriveInfo)?.DisposeAllClients();
            return drive;
        }

        // Region, in precedence order:
        //   explicit -Region -> the PowerShell session default $StoredAWSRegion (via
        //   AWS.Tools.Common's Get-DefaultAWSRegion) -> us-east-1.
        // Reusing Common's session default (rather than resolving SDK-direct) is what makes an
        // S3 drive pick up Set-DefaultAWSRegion exactly like the S3 cmdlets do.
        private RegionEndpoint ResolveRegion(S3DriveParameters dp)
        {
            if (dp != null && !string.IsNullOrEmpty(dp.Region))
                return ValidRegionOrThrow(dp.Region);

            var sessionRegion = SessionDefaultRegionName();   // $StoredAWSRegion, via Common
            return string.IsNullOrEmpty(sessionRegion)
                ? RegionEndpoint.USEast1
                : ValidRegionOrThrow(sessionRegion);
        }

        // RegionEndpoint.GetBySystemName does NOT throw on an unknown name - it fabricates a
        // synthetic endpoint (DisplayName "Unknown") that only fails later with an obscure
        // DNS/signing error. Reject a bad region up front with a clear, actionable message; the
        // caller (NewDrive) turns this into a clean mount failure.
        private static RegionEndpoint ValidRegionOrThrow(string systemName)
        {
            var region = RegionEndpoint.GetBySystemName(systemName);
            if (string.Equals(region.DisplayName, "Unknown", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException(
                    $"'{systemName}' is not a known AWS region. Use a region system name such as 'us-east-1'.");
            return region;
        }

        // Credentials, in precedence order:
        //   explicit access/secret keys -> named profile (-ProfileName) -> -AWSCredential object
        //   -> the PowerShell session default $StoredAWSCredentials (via Get-AWSCredential)
        //   -> null (let the SDK default chain run: env vars, ECS, EC2 instance profile).
        // The session-default step reuses AWS.Tools.Common so a drive authenticates like the S3
        // cmdlets (picks up Set-AWSCredential). $StoredAWSCredentials holds an AWSPSCredentials
        // whose underlying AWSCredentials accessor is internal to Common, so we cannot read it
        // cross-assembly directly - Get-AWSCredential (no args) writes the unwrapped credentials.
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

        // ---- AWS.Tools.Common session defaults (no compile-time dependency) ----
        // We depend on AWS.Tools.Common at runtime (RequiredModules in the manifest), so its
        // cmdlets are loaded in the runspace. Rather than reference Common's assembly at build
        // time (whose credential session-default accessor is internal anyway), we invoke its
        // public cmdlets through the provider's SessionState. Best-effort: any failure (Common
        // not loaded, no default set) falls through to the next resolution step.

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

        // $StoredAWSRegion system name (e.g. "us-west-2") via Get-DefaultAWSRegion. Null if unset.
        // Get-DefaultAWSRegion writes an Amazon.PowerShell.Common.AWSRegion whose .Region is the
        // system name; read it reflectively to avoid a compile-time dependency on Common.
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

        /// <summary>
        /// Backs Get-ChildItem. Root -> ListBuckets. Inside a bucket/prefix -> a delimited
        /// ListObjectsV2 listing of the immediate children (subfolders + objects).
        ///
        /// With -Recurse, lists EVERY object beneath the prefix in one delimiter-less sweep.
        /// </summary>
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
                // Stream: emit each item as its ListObjectsV2 page arrives (bounded memory,
                // output appears immediately, Ctrl+C interruptible) rather than buffering the
                // whole listing first.
                if (recurse)
                    // Flat: every key beneath the prefix.
                    StreamAllUnder(bucket1, key, c => WriteItemObject(c.Item, c.Path, c.IsContainer));
                else
                    // One level: immediate children via a delimited listing.
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

        /// <summary>
        /// Backs Get-Item: emit the single S3ItemInfo for the exact path (no children), the
        /// complement of Get-ChildItem. Root -> the buckets; a bucket/prefix -> a Folder; an object
        /// -> a File with size + last-modified from GetObjectMetadata. A name that is both a prefix
        /// and an object resolves to the Folder (same folder-wins rule as listing). Writes a clean
        /// PathNotFound error when nothing matches, rather than throwing.
        /// </summary>
        protected override void GetItem(string path)
        {
            if (IsDriveRoot(path))
            {
                // The root "item" is the set of buckets (mirrors Get-Item on a filesystem root).
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
                    // A bucket. ListBuckets is account-global; find this one to carry its creation
                    // date, but fall back to a plain existence probe if it isn't in the listing
                    // (e.g. ListAllMyBuckets denied but the bucket itself is reachable).
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

                // Folder wins over a colliding object (same rule as the listing path). If listing
                // the prefix is denied, still fall back to an exact object HEAD so buckets that deny
                // ListBucket can read/delete known object keys.
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

                // Otherwise an object: HEAD it for size + last-modified.
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

                // Fastest path: this exact key was just emitted by an in-progress (or recent)
                // listing -> answer from the per-child positive cache with NO network call. This
                // is what kills the per-item probe storm DURING a large listing (the parent's
                // COMPLETE entry doesn't exist until the listing ends, so we can't rely on it).
                var child = Drive.ListingCache.TryGetChild(bucket, key);
                if (child.HasValue) return child.Value.exists;

                // Next: if the PARENT prefix is completely cached (it is, right after a
                // Get-ChildItem / completion listed a small prefix), answer from that listing.
                var resolved = ResolveFromParentCache(bucket, key);
                if (resolved.HasValue)
                {
                    if (resolved.Value.exists) return true;

                    // A raw SDK fixture/external writer can create this exact key while a parent
                    // listing is still inside its short TTL. If a newer exact probe already proved
                    // the path exists, do not let the stale parent-listing absence hide it.
                    var exactExists = ExactProbeExists(bucket, key);
                    if (exactExists.HasValue)
                        return exactExists.Value;
                    return false;
                }

                // A name that is both an object and a prefix is treated as a folder, so check the
                // prefix first. If ListBucket is denied, fall back to a direct object HEAD; if that
                // does not find an object, preserve the old "inaccessible paths probably exist"
                // behavior so the real operation can surface AccessDenied.
                var prefixAccessDenied = (AmazonS3Exception)null;
                if (TryPrefixHasChildren(bucket, key, out prefixAccessDenied))
                    return true;
                if (ObjectExists(bucket, key))
                    return true;
                return prefixAccessDenied != null;
            }
            catch (AmazonS3Exception ex) when (IsNotFound(ex)) { return false; }
            // Access-denied: the resource almost certainly EXISTS, we just can't inspect it.
            // Return true so path resolution succeeds and the ACTUAL operation then fails with
            // the real AccessDenied - otherwise the engine masks our thrown error as a
            // misleading "Cannot find path ... does not exist" (verified: the engine converts
            // any throw from ItemExists into PathNotFound).
            catch (AmazonS3Exception ex) when (IsAccessDenied(ex)) { return true; }
        }

        protected override bool IsItemContainer(string path)
        {
            if (IsDriveRoot(path)) return true;
            ParsePath(path, out var bucket, out var key);
            try
            {
                if (string.IsNullOrEmpty(key)) return BucketExists(bucket); // a bucket is a container

                // Fastest path: per-child positive cache from an in-progress/recent listing.
                var child = Drive.ListingCache.TryGetChild(bucket, key);
                if (child.HasValue) return child.Value.isContainer;

                // Next: the parent's complete cached listing (no network call).
                var resolved = ResolveFromParentCache(bucket, key);
                if (resolved.HasValue)
                {
                    if (resolved.Value.exists) return resolved.Value.isContainer;

                    // See ItemExists: a newer exact prefix probe should override a stale parent
                    // listing that says the child is absent.
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
            // Access-denied: assume container so navigation proceeds; the real operation then
            // surfaces the genuine AccessDenied (see ItemExists for why).
            catch (AmazonS3Exception ex) when (IsAccessDenied(ex)) { return true; }
        }

        // Try to answer exists/isContainer for bucket/key from the COMPLETE cached listing of
        // its parent prefix. Returns null if the parent isn't completely cached (-> caller
        // does a network check). Splits "a/b/c.txt" into parent "a/b/" + child "c.txt".
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

        // The engine calls HasChildItems during Remove-Item (to decide container/recurse
        // semantics); its base default THROWS "not supported", so we must override it or
        // Remove-Item fails before reaching RemoveItem. Root and buckets always count as
        // having children; a prefix has children if a delimited listing returns anything.
        protected override bool HasChildItems(string path)
        {
            if (IsDriveRoot(path)) return true;
            ParsePath(path, out var bucket, out var key);
            try
            {
                if (string.IsNullOrEmpty(key)) return true; // a bucket is a container

                // Per-child cache: a recorded container was a CommonPrefix (=> has children); a
                // recorded object has none. Avoids a probe when acting on a just-listed item.
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
            // Access-denied: assume it has children so path resolution proceeds and the real
            // operation surfaces the genuine AccessDenied (mirrors ItemExists/IsItemContainer).
            catch (AmazonS3Exception ex) when (IsAccessDenied(ex)) { return true; }
        }

        // ---- Copy (S3 -> S3) — OUT OF SCOPE --------------------------------------
        //
        // S3->S3 copy is not supported through the drive. We intentionally do NOT override
        // CopyItem, so Copy-Item on an S3 drive falls through to the base provider's clean
        // "operation not supported" error (same as Move-Item / Rename-Item).

        // ---- Remove ----------------------------------------------------------

        private const int DeleteBatchSize = 1000;   // S3 DeleteObjects caps at 1000 keys/call

        /// <summary>
        /// Backs Remove-Item. A single object is deleted with DeleteObject. With -Recurse on
        /// a prefix, every object beneath it is deleted with batched DeleteObjects (<=1000
        /// per call). Deletion is gated by ShouldProcess only - it does NOT prompt by default,
        /// matching the built-in FileSystem provider (and `aws s3 rm`): -WhatIf / -Confirm and
        /// $ConfirmPreference are the native ways to ask for confirmation. The one case that still
        /// auto-prompts - deleting a non-empty prefix WITHOUT -Recurse - is the PowerShell ENGINE's
        /// own container-recurse prompt, not ours; that is the same safety net FileSystem relies on.
        /// </summary>
        protected override void RemoveItem(string path, bool recurse)
        {
            if (!TryParseObjectPath(path,
                    "Remove-Item on the S3 drive requires an object or prefix path (bucket\\key).",
                    "InvalidRemovePath", out var bucket, out var key))
                return;

            try
            {
                // Treat as a prefix (folder) when it has children; otherwise a single object. If
                // ListBucket is denied, keep going down the exact-object path so a known key can be
                // removed without bucket listing permission.
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
                    // Single object. ShouldProcess gates -WhatIf/-Confirm and honors
                    // $ConfirmPreference, exactly like the FileSystem provider's Remove-Item: NO
                    // prompt by default. (A provider cannot set ConfirmImpact - that belongs to the
                    // Remove-Item cmdlet - so ShouldProcess alone does not prompt unless the user
                    // opts in with -Confirm.) This matches what PowerShell and `aws s3 rm` users
                    // already expect; -Confirm / -WhatIf remain the native way to ask for confirmation.
                    if (!ShouldProcess(path, "Remove S3 object"))
                        return;

                    RunSync(ct => ClientForBucket(bucket).DeleteObjectAsync(
                        new DeleteObjectRequest { BucketName = bucket, Key = key }, ct));
                    Drive.ListingCache.InvalidateForKey(bucket, key);   // show the removal immediately
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

        // List every key under the prefix (no delimiter = fully recursive) and delete in
        // batches of up to 1000.
        private void RemovePrefixRecursive(string bucket, string key, string displayPath)
        {
            // ShouldProcess only - honors -WhatIf/-Confirm/$ConfirmPreference but does NOT prompt by
            // default, matching FileSystem. When the user reached here by answering the engine's
            // container-recurse prompt (deleting a non-empty prefix without -Recurse), that engine
            // prompt was the confirmation; adding our own here is what produced the redundant double
            // prompt, so it is deliberately gone. An explicit `-Recurse` deletes silently (as `rm -r`
            // / FileSystem do); use -WhatIf or -Confirm to preview or gate it.
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

                // Also delete the object at the exact key (no trailing slash), if any. When a name
                // is both a folder ("key/...") and an object ("key"), the folder shadows the object
                // in listings; the delimiter-less sweep above only covers "key/", so without this
                // the shadowed object survives and the name reappears as a plain object after the
                // "folder" is deleted. DeleteObjects is idempotent, so this is a no-op when no such
                // object exists.
                var exactKey = key.TrimEnd('/');
                if (exactKey.Length > 0)
                    batch.Add(new KeyVersion { Key = exactKey });

                if (batch.Count > 0)
                    DeleteBatch(bucket, batch);
            }
            finally
            {
                // Evict the prefix (and ancestors) so removed keys stop appearing - in a finally so
                // a mid-sweep failure still refreshes the view for whatever was already deleted,
                // rather than leaving a stale listing until the TTL expires.
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
                // A partial failure: some keys deleted, some failed. Report each failed key with
                // its S3 error rather than aborting the whole recursive delete, so the remaining
                // batches still run and the user sees exactly what could not be removed. (The
                // caller invalidates the listing cache in a finally, covering the deleted keys.)
                foreach (var e in ex.Response?.DeleteErrors ?? new List<DeleteError>())
                    WriteError(new ErrorRecord(
                        new AmazonS3Exception($"Failed to delete '{e.Key}': {e.Code} {e.Message}"),
                        "RemoveFailed", ErrorCategory.WriteError, e.Key));
            }
        }


        // ---- Content: download / upload (IContentCmdletProvider) -------------

        /// <summary>
        /// Backs Get-Content on an S3 object path (DOWNLOAD). Opens the object via
        /// TransferUtility.OpenStream (parallel multipart download + ranged retries) and hands
        /// back a reader over that forward-only stream; the reader pulls blocks lazily as
        /// PowerShell calls Read(), so any size streams back with bounded memory (one block at
        /// a time). No size threshold - TransferUtility manages part sizing for the download.
        /// </summary>
        public IContentReader GetContentReader(string path)
        {
            if (!TryParseObjectPath(path,
                    "Get-Content requires a path to an S3 object (bucket\\key).",
                    "InvalidContentPath", out var bucket, out var key))
                return null;

            // -AsByteStream / -Raw / -Encoding are provider-contributed dynamic parameters
            // (verified: NOT static on Get-Content). Normally DynamicParameters is OUR
            // S3ContentReaderDynamicParameters. BUT when a listed item's PSPath is bound via the
            // PIPELINE (Get-ChildItem | Get-Content -AsByteStream), the engine parses the content
            // dynamic-params against the DEFAULT (FileSystem) provider and hands us a
            // FileSystemContentReaderDynamicParameters instead - a direct cast to our type then
            // returns null and -AsByteStream/-Raw/-Encoding are silently lost (bytes come back as
            // text). So read the three properties by NAME off whatever object we're given, ours or
            // FileSystem's. (FileSystem uses the same property names AsByteStream/Raw/Encoding.)
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

            // Download via TransferUtility.OpenStream instead of a single GetObject - gains parallel
            // multipart download + ranged retries. OpenStream returns a forward-only Stream, which is
            // exactly what S3ContentReader consumes.
            //
            // The CTS must outlive this method: a multipart OpenStream fetches parts on background
            // tasks AS THE READER READS, so the token has to stay live for the whole read, not just
            // the OpenStreamAsync call. The reader owns it and disposes it on Close; StopProcessing
            // cancels it via the registered content-CTS set.
            var readerCts = new CancellationTokenSource();
            RegisterContentCts(readerCts);
            Drive.BeginContentOperation();   // keep the drive's clients alive for the whole read
            var handedOff = false;   // true once the reader owns readerCts (success path)
            try
            {
                // The TransferUtility is only needed to OPEN the stream; dispose it eagerly (using).
                // Verified: disposing the TU does NOT dispose our shared client, and the opened
                // multipart stream reads back byte-exact even after the TU is gone.
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
                // Any non-success exit (incl. a non-AmazonS3Exception like a Ctrl+C
                // OperationCanceledException or an SDK error during region resolve / OpenStream)
                // must unregister and release readerCts and end the content operation. On success
                // the reader owns it (and does both via onDispose), so we leave it alone.
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

        // Read AsByteStream / Raw / Encoding off the content-reader dynamic-params object, whatever
        // its concrete type, and resolve the final Encoding. On a literal/-LiteralPath bind this is our
        // S3ContentReaderDynamicParameters (Encoding is a friendly string); on a PIPELINE bind
        // (Get-ChildItem | Get-Content) the engine may hand us the FileSystem provider's
        // FileSystemContentReaderDynamicParameters instead, whose Encoding is a rich
        // System.Text.Encoding OBJECT. Both expose AsByteStream/Raw/Encoding by the same names, so we
        // duck-type - honoring -AsByteStream/-Raw/-Encoding on BOTH bind paths. Throws ArgumentException
        // (via ResolveEncoding) only for an unknown STRING encoding name.
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

            // Foreign params object (e.g. FileSystem's): duck-type by property name.
            var t = dp.GetType();
            asByteStream = ReadSwitchLike(dp, t, "AsByteStream");
            raw = ReadSwitchLike(dp, t, "Raw");
            var enc = t.GetProperty("Encoding")?.GetValue(dp);
            if (enc is System.Text.Encoding realEnc)
                encoding = realEnc;                          // FileSystem hands a ready Encoding object - use it as-is
            else if (enc is string encName && encName.Length > 0)
                encoding = ResolveEncoding(encName);         // a friendly name (our shape) - map it
            // else: leave the UTF-8 default (enc null, or some other type we don't recognize)
        }

        // Read AsByteStream / Encoding / NoNewline off the content-writer dynamic-params object.
        // On explicit S3 paths this is our S3ContentWriterDynamicParameters. On a PIPELINE bind
        // (Get-Item | Set-Content), PowerShell may hand us another provider's dynamic params object;
        // FileSystem uses the same common property names, so duck-type those. S3-only writer params
        // (PartSize, StorageClass) intentionally remain available only from our native type.
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

            // Foreign params object (e.g. FileSystem's): duck-type by property name.
            var t = dp.GetType();
            asByteStream = ReadSwitchLike(dp, t, "AsByteStream");
            noNewline = ReadSwitchLike(dp, t, "NoNewline");
            encoding = ReadEncodingLike(t.GetProperty("Encoding")?.GetValue(dp), encoding);
        }

        // True if property 'name' on dp is a set SwitchParameter (or a bool that is true). Tolerates
        // both SwitchParameter (has .IsPresent / bool conversion) and plain bool.
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

        /// <summary>
        /// Backs Set-Content on an S3 object path (UPLOAD). Streams bytes to S3 via
        /// TransferUtility. Because the writer feeds TU a non-seekable bridge stream, every
        /// upload uses TU's multipart path (size-independent): the destination is replaced only
        /// at the final CompleteMultipartUpload, and TU aborts its own multipart upload on
        /// failure/cancellation. Bounded memory (the bridge applies backpressure), no temp file.
        /// </summary>
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
            // Effective storage class: per-upload -StorageClass wins, else the drive default, else
            // null (S3 uses STANDARD). Null all the way through means we set nothing on the request.
            var storageClass = writerParams?.StorageClass ?? Drive.DefaultStorageClass;
            var partSize = writerParams != null && writerParams.PartSize > 0
                ? writerParams.PartSize
                : MultipartThreshold;
            var cache = Drive.ListingCache;

            // Upload via TransferUtility. TU pulls from a stream while PowerShell pushes blocks at
            // the writer, so S3TransferContentWriter bridges them with a background upload task (see
            // that class). The writer owns its CTS; we register it in the content-CTS set so Ctrl+C
            // (StopProcessing) cancels the in-flight upload, and unregister on dispose. onComplete
            // invalidates the listing cache after a successful Close.
            //
            // The CTS/TransferUtility must outlive this method only on the SUCCESS path (the writer
            // then owns them). If TransferUtilityForBucket (region resolution) or the constructor
            // throws, the finally releases them and unregisters the CTS - mirrors the reader's
            // handedOff guard.
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

        // Cap on how many entries we'll accumulate to build a COMPLETE cache entry while
        // streaming. Normal cd/tab-completion prefixes are tiny and benefit from caching; a
        // pathological prefix (millions of keys) must stay O(1) memory, so past this cap we
        // drop the accumulator and stream pure. (Listing output itself is never capped.)
        private const int ListingCacheMaxItems = 10000;

        /// <summary>
        /// One level of children under bucket/key via a delimited ListObjectsV2, following
        /// continuation tokens so large prefixes fully enumerate. CommonPrefixes become
        /// folders; objects become files. The object whose key equals the listing prefix
        /// (a directory-marker placeholder for the folder itself) is filtered out.
        ///
        /// STREAMS: each child is handed to <paramref name="emit"/> as its page arrives, so
        /// memory stays bounded and output appears immediately. Interruptible: we stop between
        /// pages when the engine signals Stopping (Ctrl+C), and the in-flight page request is
        /// itself cancelled via RunSync's token. A listing is never capped or truncated.
        /// </summary>
        private void StreamChildren(string bucket, string key, Action<ChildEntry> emit)
        {
            var listPrefix = string.IsNullOrEmpty(key) ? "" : EnsureTrailingSlash(key);

            // Cache: a COMPLETE entry serves the full listing directly (still emitted one by one).
            var cached = Drive.ListingCache.TryGetComplete(bucket, listPrefix);
            if (cached != null)
            {
                WriteVerbose($"[cache hit] StreamChildren {bucket}/{listPrefix}");
                foreach (var c in cached) emit(c);
                return;
            }

            var client = ClientForBucket(bucket);
            // Names that appeared as folders (CommonPrefixes). When a name is BOTH a prefix and an
            // object, the FOLDER wins and the colliding object is shadowed - so we skip an object
            // whose name is already a folder (otherwise the name lists twice).
            //
            // Best-effort across pages: this shadowing is guaranteed only when the colliding object
            // and its CommonPrefix land in the same ListObjectsV2 page. A collision needs an object
            // key that exactly equals a prefix name; if the two happen to straddle a page boundary
            // (>1000 entries), the object may list once alongside the folder. We accept this rather
            // than buffer a whole listing (which would break the streaming, bounded-memory design).
            var folderNames = new HashSet<string>(StringComparer.Ordinal);

            // Accumulate to upgrade the cache to COMPLETE at the end - but only while small and
            // only if we finish without interruption (a truncated listing must NOT be cached as
            // complete, or later existence checks would wrongly conclude "absent"). Null once we
            // pass the cap => pure streaming, no caching.
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
                WriteVerbose($"[S3 CALL] ListObjectsV2 {bucket}/{listPrefix} (page)");
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
                        // Record BEFORE emit: PowerShell may decorate (ItemExists/IsItemContainer)
                        // synchronously as we emit, so the record must already be present.
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

            // Fully enumerated (not interrupted) AND stayed under the cap -> cache COMPLETE.
            if (accum != null)
            {
                Drive.ListingCache.PutComplete(bucket, listPrefix, accum, prefixMarkerSeen);
                if (prefixMarkerSeen)
                    Drive.ListingCache.PutExistsProbe(bucket, listPrefix, asPrefix: true, exists: true);
            }
        }

        // Append to the cache accumulator, or drop it (return null) once it exceeds the cap so a
        // huge listing stays O(1) memory. Null in => stays null (already over cap).
        private static List<ChildEntry> Accumulate(List<ChildEntry> accum, ChildEntry entry)
        {
            if (accum == null) return null;
            if (accum.Count >= ListingCacheMaxItems) return null;   // over cap: stop caching this listing
            accum.Add(entry);
            return accum;
        }

        /// <summary>
        /// Lists EVERY object beneath a prefix (recursive), via a delimiter-less paginated
        /// ListObjectsV2 - no CommonPrefixes, every key returned flat. Backs Get-ChildItem
        /// -Recurse. Directory-marker objects (key ends in "/") are skipped.
        ///
        /// STREAMS (see StreamChildren): emits each key as its page arrives, interruptible
        /// between pages. This is the listing most likely to be enormous, so it does NOT cache
        /// (a flat recursive sweep isn't a "prefix listing" the cache is keyed for) and stays
        /// strictly O(1) in memory regardless of object count.
        /// </summary>
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
                        // Record before emit so per-item decoration resolves without a probe -
                        // this is the path that made large recursive listings O(items) in S3 calls.
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

            // Cache 1: the short-TTL listing cache (partial or complete entry) - authoritative for a
            // recent Get-ChildItem / drive-originated write within its 1s window.
            var cached = Drive.ListingCache.TryHasChildren(bucket, listPrefix);
            if (cached.HasValue)
            {
                WriteVerbose($"[cache hit] PrefixHasChildren {bucket}/{listPrefix}");
                return cached.Value;
            }

            // Cache 2: the longer-TTL existence-probe cache. Prefix existence is stable, so a
            // positive result is held long enough to survive a whole command - this is what
            // de-thrashes a DEEP path, where the engine re-walks the full ancestor chain many times
            // and a single walk (15 misses x ~78ms) already outlives the 1s listing TTL.
            var probed = Drive.ListingCache.TryGetExistsProbe(bucket, listPrefix, asPrefix: true);
            if (probed.HasValue)
            {
                WriteVerbose($"[cache hit] PrefixHasChildren(probe) {bucket}/{listPrefix}");
                return probed.Value;
            }

            var req = new ListObjectsV2Request
            {
                BucketName = bucket,
                Prefix = listPrefix,
                Delimiter = "/",
                MaxKeys = 1
            };
            WriteVerbose($"[S3 CALL] ListObjectsV2 {bucket}/{listPrefix} (probe MaxKeys=1)");
            var resp = RunSync(ct => ClientForBucket(bucket).ListObjectsV2Async(req, ct));
            var has = (resp.S3Objects?.Count ?? 0) > 0 || (resp.CommonPrefixes?.Count ?? 0) > 0;

            // Populate BOTH caches: the short-TTL partial entry (for Get-ChildItem/HasChildren
            // consumers) and the longer-TTL existence probe (for the deep-walk de-thrash).
            Drive.ListingCache.PutPartial(bucket, listPrefix, has);
            Drive.ListingCache.PutExistsProbe(bucket, listPrefix, asPrefix: true, exists: has);
            return has;
        }

        private bool ObjectExists(string bucket, string key)
        {
            // Cache: a fresh HEAD outcome for this exact key answers directly (no network). This is
            // the fix for the per-command probe storm - the engine resolves ItemExists dozens of
            // times for ONE Test-Path/Get-Content, and ObjectExists was previously the only
            // existence probe with no cache, re-HEADing (~78ms) on every one. Records both
            // true and false; invalidated on any write/delete at the key.
            var cached = Drive.ListingCache.TryGetExistsProbe(bucket, key, asPrefix: false);
            if (cached.HasValue)
            {
                WriteVerbose($"[cache hit] ObjectExists {bucket}/{key}");
                return cached.Value;
            }

            try
            {
                WriteVerbose($"[S3 CALL] GetObjectMetadata {bucket}/{key} (HEAD probe)");
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
            // AccessDenied is NOT cached and NOT caught here: it propagates to the caller
            // (ItemExists/IsItemContainer), which treats it as "exists" so the real op surfaces
            // the genuine error - unchanged behavior.
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

        // Separate from _currentCts because content reader/writer CTSes outlive a single SDK call
        // (they span the whole streamed read/upload), whereas RunSync nulls _currentCts in its
        // finally. A SET, not a single field: more than one content operation can be live at once
        // (e.g. Get-Content x | Set-Content y on the same drive), and StopProcessing/Ctrl+C must
        // cancel ALL of them, not just the most recently opened. Each op registers on open and
        // unregisters on dispose/close.
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

        // Call an async SDK method and block, wiring a cancellation token to Ctrl+C
        // (StopProcessing) - the same pattern the existing S3 cmdlets use.
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

        // Split a provider path into bucket + S3 key. PowerShell uses "\"; S3 uses "/".
        // "my-bucket\2026\q2" -> bucket="my-bucket", key="2026/q2".
        //
        // PowerShell sometimes hands us a DRIVE-QUALIFIED path (e.g. "S3:\bucket\key", or
        // "AWS.Tools.S3\AWS.S3::S3:\bucket\key") - notably when decorating listed items
        // during completion. We must strip any "<provider>::" and "<drive>:" qualifier first,
        // or the bucket parses as "S3:" and every existence check misses the cache and probes
        // a garbage bucket. (This was the per-child probe storm behind the tab-completion lag.)
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

        // PowerShell usually prepends PSDriveInfo.Root before calling provider methods, but for a
        // new item under a rooted drive (for example Set-Content PSPfx:\new.txt where PSPfx.Root is
        // "bucket/prefix") it can hand us the root-relative child path. Normalize that to the real
        // S3 bucket/key so writes and deletes stay scoped under the mounted root.
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

            // The engine can feed a new rooted-drive item path back with the root repeated
            // ("bucket/prefix/bucket/prefix/new.txt"). Collapse those repeats so every rooted
            // operation maps to exactly one bucket/prefix base.
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

        // Parse a path that must point at an OBJECT (non-empty bucket AND key). On success returns
        // true with bucket/key set; on failure WriteErrors with the given message/id and returns
        // false. Consolidates the identical guard used by RemoveItem/GetContentReader/GetContentWriter.
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

        // Map the friendly -Encoding names (matching the built-in cmdlet's set) to encodings.
        // Returns UTF-8 (no BOM) when unspecified.
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

        // Path-segment separator to EMIT in the paths we hand back to the engine (cd targets,
        // child paths, tab-completion). PowerShell's provider path separator is OS-native: '\' on
        // Windows, '/' on Linux/macOS. ParsePath already accepts BOTH on input (it normalizes via
        // Replace('\\','/')), so only path-BUILDING needs to be OS-aware. Emitting '/' on
        // non-Windows is verified on Linux PowerShell 7.4 (paths build and round-trip correctly).
        private static readonly char Sep =
            System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(
                System.Runtime.InteropServices.OSPlatform.Windows) ? '\\' : '/';

        // The path we hand to WriteItemObject is the provider-INTERNAL, drive-INDEPENDENT path
        // (bucket + key), NOT drive-qualified ("S3:\..."). The engine composes each item's
        // fully-qualified PSPath itself as "Module\Provider::<thisPath>". When that PSPath is fed
        // back (Get-ChildItem | Get-Content, | Remove-Item), the engine strips "Module\Provider::"
        // and re-resolves the remainder against the provider's HIDDEN drive. If we embedded the
        // drive name here ("S3:\bucket\key"), that remainder would carry a dangling "S3:" the engine
        // can't re-resolve and the pipe fails ("Cannot find path 'S3:\...'"). Emitting the clean
        // "bucket\key" makes it resolve; ParsePath already normalizes it and Drive (above) recovers
        // the mounted S3DriveInfo when the hidden drive is in play. This mirrors the built-in
        // providers: FileSystem emits "C:\foo\bar", Registry "HKEY_LOCAL_MACHINE\SOFTWARE\...",
        // never "<drive>:\...".
        private string MakeItemPath(string childName) => childName;

        // bucket="b", fullKey="2026/q2/sub/" or "2026/q2/x.csv" -> "b\2026\q2\sub" / "b\...\x.csv"
        // (forward slashes on Linux/macOS). Separator is OS-native; see Sep above. Drive-independent
        // (no "S3:" qualifier) - see MakeItemPath for why.
        private string MakeChildPath(string bucket, string fullKey)
        {
            var rel = fullKey.TrimEnd('/').Replace('/', Sep);
            return $"{bucket}{Sep}{rel}";
        }
    }
}
