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
using System.Net;
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    public sealed partial class S3Provider
    {
        // ---- Existence / container checks (drive path resolution) ------------

        protected override bool ItemExists(string path)
        {
            if (IsDriveRoot(path)) return true;
            ParsePath(path, out var bucket, out var key);
            var drive = DriveForPath(path);
            try
            {
                if (string.IsNullOrEmpty(key)) return BucketExists(drive, bucket);

                // Per-child cache: no network call if this key was just emitted by a listing. Handles
                // the per-item probes fired during a large listing, before its complete entry exists.
                var child = drive.ListingCache.TryGetChild(bucket, key);
                if (child.HasValue) return child.Value.exists;

                // Parent prefix's complete cached listing, if present.
                var resolved = ResolveFromParentCache(drive, bucket, key);
                if (resolved.HasValue)
                {
                    if (resolved.Value.exists) return true;

                    // An external writer may have created this key while the parent listing is still in
                    // its TTL; a newer exact probe must override the stale absence.
                    var exactExists = ExactProbeExists(drive, bucket, key);
                    if (exactExists.HasValue)
                        return exactExists.Value;
                    return false;
                }

                // Folder-wins, so check the prefix first. On denied listing, a returned prefixAccessDenied
                // means "probably exists" so the real op can surface AccessDenied.
                var prefixAccessDenied = (AmazonS3Exception)null;
                if (TryPrefixHasChildren(drive, bucket, key, out prefixAccessDenied))
                    return true;
                if (ObjectExists(drive, bucket, key))
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
            var drive = DriveForPath(path);
            try
            {
                if (string.IsNullOrEmpty(key)) return BucketExists(drive, bucket); // a bucket is a container

                // Cache layers as in ItemExists: per-child, then the parent's complete listing.
                var child = drive.ListingCache.TryGetChild(bucket, key);
                if (child.HasValue) return child.Value.isContainer;

                var resolved = ResolveFromParentCache(drive, bucket, key);
                if (resolved.HasValue)
                {
                    if (resolved.Value.exists) return resolved.Value.isContainer;

                    // A newer exact prefix probe overrides a stale parent-listing absence (see ItemExists).
                    var exactExists = ExactProbeExists(drive, bucket, key);
                    if (exactExists == true)
                        return drive.ListingCache.TryGetExistsProbe(bucket, EnsureTrailingSlash(key), asPrefix: true) == true;
                    if (exactExists == false)
                        return false;
                }

                var prefixAccessDenied = (AmazonS3Exception)null;
                if (TryPrefixHasChildren(drive, bucket, key, out prefixAccessDenied))
                    return true;
                if (prefixAccessDenied != null)
                    return !ObjectExists(drive, bucket, key);
                return false;
            }
            catch (AmazonS3Exception ex) when (IsNotFound(ex)) { return false; }
            // Access-denied: assume container so navigation proceeds (see ItemExists for why).
            catch (AmazonS3Exception ex) when (IsAccessDenied(ex)) { return true; }
        }

        // Resolve exists/isContainer from the parent prefix's complete cached listing, or null if it
        // isn't cached. Splits "a/b/c.txt" into parent "a/b/" + child "c.txt".
        private (bool exists, bool isContainer)? ResolveFromParentCache(S3DriveInfo drive, string bucket, string key)
        {
            var k = key.TrimEnd('/');
            var slash = k.LastIndexOf('/');
            var parentPrefix = slash < 0 ? "" : k.Substring(0, slash + 1);   // "a/b/" or ""
            var childName = slash < 0 ? k : k.Substring(slash + 1);          // "c.txt"
            return drive.ListingCache.TryResolveChild(bucket, parentPrefix, childName);
        }

        private bool? ExactProbeExists(S3DriveInfo drive, string bucket, string key)
        {
            var prefixProbe = drive.ListingCache.TryGetExistsProbe(bucket, EnsureTrailingSlash(key), asPrefix: true);
            if (prefixProbe == true) return true;

            var objectProbe = drive.ListingCache.TryGetExistsProbe(bucket, key, asPrefix: false);
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
            var drive = DriveForPath(path);
            try
            {
                if (string.IsNullOrEmpty(key)) return true; // a bucket is a container

                // A recorded container was a CommonPrefix (has children); a recorded object has none.
                var child = drive.ListingCache.TryGetChild(bucket, key);
                if (child.HasValue) return child.Value.isContainer;

                var prefixAccessDenied = (AmazonS3Exception)null;
                if (TryPrefixHasChildren(drive, bucket, key, out prefixAccessDenied))
                    return true;
                if (prefixAccessDenied != null)
                    return !ObjectExists(drive, bucket, key);
                return false;
            }
            catch (AmazonS3Exception ex) when (IsNotFound(ex)) { return false; }
            // Access-denied: assume children (see ItemExists for why).
            catch (AmazonS3Exception ex) when (IsAccessDenied(ex)) { return true; }
        }

        private bool BucketExists(S3DriveInfo drive, string bucket)
        {
            try
            {
                RunSync(ct => ClientForBucket(drive, bucket).ListObjectsV2Async(
                    new ListObjectsV2Request { BucketName = bucket, MaxKeys = 1 }, ct));
                return true;
            }
            catch (AmazonS3Exception ex) when (IsNotFound(ex)) { return false; }
            catch (AmazonS3Exception ex) when (IsAccessDenied(ex)) { return true; }
        }

        private bool TryPrefixHasChildren(S3DriveInfo drive, string bucket, string key, out AmazonS3Exception accessDenied)
        {
            accessDenied = null;
            try
            {
                return PrefixHasChildren(drive, bucket, key);
            }
            catch (AmazonS3Exception ex) when (IsAccessDenied(ex))
            {
                accessDenied = ex;
                return false;
            }
        }

        // True if bucket/key names an existing folder (a prefix with children). Folder-wins: a name that
        // is both a prefix and an object counts as a folder here. On denied listing this returns false so
        // the caller proceeds and the real op surfaces AccessDenied (matches ItemExists's philosophy).
        // Used to guard content ops (Get-Content/Set-Content) off a prefix; see GetContentReader/Writer.
        private bool PathIsExistingFolder(S3DriveInfo drive, string bucket, string key) =>
            !string.IsNullOrEmpty(key) && TryPrefixHasChildren(drive, bucket, key, out _);

        private bool PrefixHasChildren(S3DriveInfo drive, string bucket, string key)
        {
            var listPrefix = EnsureTrailingSlash(key);

            // Short-TTL listing cache: authoritative for a recent Get-ChildItem / drive-originated write.
            var cached = drive.ListingCache.TryHasChildren(bucket, listPrefix);
            if (cached.HasValue)
                return cached.Value;

            // Longer-TTL existence-probe cache: prefix existence is stable, so a positive result
            // survives a whole command and de-thrashes the engine's repeated deep-ancestor walks.
            var probed = drive.ListingCache.TryGetExistsProbe(bucket, listPrefix, asPrefix: true);
            if (probed.HasValue)
                return probed.Value;

            var req = new ListObjectsV2Request
            {
                BucketName = bucket,
                Prefix = listPrefix,
                Delimiter = "/",
                MaxKeys = 1
            };
            var resp = RunSync(ct => ClientForBucket(drive, bucket).ListObjectsV2Async(req, ct));
            var has = (resp.S3Objects?.Count ?? 0) > 0 || (resp.CommonPrefixes?.Count ?? 0) > 0;

            // Populate both caches.
            drive.ListingCache.PutPartial(bucket, listPrefix, has);
            drive.ListingCache.PutExistsProbe(bucket, listPrefix, asPrefix: true, exists: has);
            return has;
        }

        private bool ObjectExists(S3DriveInfo drive, string bucket, string key)
        {
            // Cache the HEAD outcome (true or false): the engine resolves ItemExists many times per
            // command, so this avoids re-probing the same key. Invalidated on any write/delete at the key.
            var cached = drive.ListingCache.TryGetExistsProbe(bucket, key, asPrefix: false);
            if (cached.HasValue)
                return cached.Value;

            try
            {
                RunSync(ct => ClientForBucket(drive, bucket).GetObjectMetadataAsync(
                    new GetObjectMetadataRequest { BucketName = bucket, Key = key }, ct));
                drive.ListingCache.PutExistsProbe(bucket, key, asPrefix: false, exists: true);
                return true;
            }
            catch (AmazonS3Exception ex) when (IsNotFound(ex))
            {
                drive.ListingCache.PutExistsProbe(bucket, key, asPrefix: false, exists: false);
                return false;
            }
            // AccessDenied is neither cached nor caught: it propagates to the caller, which treats it
            // as "exists" so the real op surfaces the genuine error.
        }

        private static bool IsNotFound(AmazonS3Exception ex) =>
            ex.StatusCode == HttpStatusCode.NotFound
            || string.Equals(ex.ErrorCode, "NoSuchBucket", StringComparison.OrdinalIgnoreCase)
            || string.Equals(ex.ErrorCode, "NoSuchKey", StringComparison.OrdinalIgnoreCase);

        // The credentials themselves are bad (not merely under-permissioned): the key doesn't exist,
        // the signature is wrong, or the session token is bad/expired. These come back as 403s too, so
        // they must be split from IsAccessDenied; otherwise a mount validated against invalid credentials
        // would be treated as "exists but inaccessible" and succeed. Callers let these propagate so the
        // mount (or operation) fails with the real error.
        private static bool IsInvalidCredentials(AmazonS3Exception ex) =>
            string.Equals(ex.ErrorCode, "InvalidAccessKeyId", StringComparison.OrdinalIgnoreCase)
            || string.Equals(ex.ErrorCode, "SignatureDoesNotMatch", StringComparison.OrdinalIgnoreCase)
            || string.Equals(ex.ErrorCode, "InvalidToken", StringComparison.OrdinalIgnoreCase)
            || string.Equals(ex.ErrorCode, "ExpiredToken", StringComparison.OrdinalIgnoreCase)
            || string.Equals(ex.ErrorCode, "TokenRefreshRequired", StringComparison.OrdinalIgnoreCase)
            || string.Equals(ex.ErrorCode, "InvalidSecurity", StringComparison.OrdinalIgnoreCase)
            || string.Equals(ex.ErrorCode, "AccountProblem", StringComparison.OrdinalIgnoreCase);

        // True authorization failure: the caller is valid but lacks permission on the resource. Excludes
        // bad-credential 403s (see IsInvalidCredentials) so those aren't masked as "exists but no access".
        private static bool IsAccessDenied(AmazonS3Exception ex) =>
            !IsInvalidCredentials(ex)
            && (ex.StatusCode == HttpStatusCode.Forbidden
                || string.Equals(ex.ErrorCode, "AccessDenied", StringComparison.OrdinalIgnoreCase));

    }
}
