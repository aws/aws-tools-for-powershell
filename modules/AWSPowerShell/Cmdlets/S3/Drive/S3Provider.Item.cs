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
    public sealed partial class S3Provider
    {
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

    }
}
