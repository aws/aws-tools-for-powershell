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
using System.Management.Automation;
using System.Management.Automation.Provider;
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    public sealed partial class S3Provider
    {
        // ---- Listing ---------------------------------------------------------

        // Backs Get-ChildItem. Root -> ListBuckets; a bucket/prefix -> immediate children, or with
        // -Recurse every object beneath the prefix.
        protected override void GetChildItems(string path, bool recurse)
        {
            var drive = DriveForPath(path);
            if (IsDriveRoot(path))
            {
                // -Filter matches on the leaf (bucket) name, mirroring FileSystem.
                foreach (var bucket in ListBuckets(drive))
                    if (MatchesFilter(bucket.BucketName))
                        WriteItemObject(S3ItemInfo.Bucket(bucket.BucketName, bucket.CreationDate),
                            MakeItemPath(bucket.BucketName), isContainer: true);
                return;
            }

            ParsePath(path, out var bucket1, out var key);
            try
            {
                // Filter at the emit lambda (not inside StreamChildren) so the ListingCache still records
                // ALL children; filtering must not corrupt the cache used by later existence probes.
                if (recurse)
                    StreamAllUnder(drive, bucket1, key, c => { if (MatchesFilter(LeafName(c.Name))) WriteItemObject(c.Item, c.Path, c.IsContainer); });
                else
                    StreamChildren(drive, bucket1, key, c => { if (MatchesFilter(LeafName(c.Name))) WriteItemObject(c.Item, c.Path, c.IsContainer); });
            }
            catch (AmazonS3Exception ex)
            {
                WriteError(new ErrorRecord(ex, "ListFailed", ErrorCategory.ReadError, path));
            }
        }

        protected override void GetChildNames(string path, ReturnContainers returnContainers)
        {
            var drive = DriveForPath(path);
            if (IsDriveRoot(path))
            {
                foreach (var bucket in ListBuckets(drive))
                    if (MatchesFilter(bucket.BucketName))
                        WriteItemObject(bucket.BucketName, MakeItemPath(bucket.BucketName), isContainer: true);
                return;
            }

            ParsePath(path, out var bucket1, out var key);
            try
            {
                StreamChildren(drive, bucket1, key, c => { if (MatchesFilter(LeafName(c.Name))) WriteItemObject(c.Name, c.Path, c.IsContainer); });
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
            var drive = DriveForPath(path);
            if (IsDriveRoot(path))
            {
                // Get-Item on the drive ROOT returns the SINGLE root item, not the whole listing (that's
                // Get-ChildItem). Resolve the drive's own root: account-root -> a synthesized container
                // named after the drive; bucket-root -> the Bucket; prefix-root -> the Folder. (Rooted
                // drives normally don't reach this branch, since the engine substitutes their root, but
                // resolving drive.Root handles it defensively and drops the old ListBuckets fan-out.)
                var root = NormalizeRoot(drive.Root);   // "bucket/prefix" or "" for the account root
                if (root.Length == 0)
                {
                    // One synthesized container for the account root (no backing S3 resource). The engine
                    // rejects an EMPTY item path ("value of argument 'path' is not valid"), and an
                    // account-root mount hands GetItem an empty path (Root is empty), so echoing `path`
                    // back is not enough. Emit the drive-qualified root ("<drive>:"), a valid, non-empty
                    // path the engine accepts and round-trips, mirroring FileSystem's "C:\" root item.
                    var rootPath = string.IsNullOrEmpty(path) ? drive.Name + ":" + Sep : path;
                    WriteItemObject(S3ItemInfo.Folder(drive.Name), rootPath, isContainer: true);
                    return;
                }

                var slash = root.IndexOf('/');
                var rootBucket = slash < 0 ? root : root.Substring(0, slash);
                var rootKey = slash < 0 ? "" : root.Substring(slash + 1);
                try
                {
                    if (string.IsNullOrEmpty(rootKey))
                    {
                        var rb = FindBucket(drive, rootBucket);
                        if (rb != null)
                            WriteItemObject(S3ItemInfo.Bucket(rb.BucketName, rb.CreationDate),
                                MakeItemPath(rootBucket), isContainer: true);
                        else if (BucketExists(drive, rootBucket))
                            WriteItemObject(S3ItemInfo.Bucket(rootBucket, null),
                                MakeItemPath(rootBucket), isContainer: true);
                        else
                            WriteItemNotFound(path);
                    }
                    else
                    {
                        var name = rootKey.TrimEnd('/');
                        var lastSlash = name.LastIndexOf('/');
                        if (lastSlash >= 0) name = name.Substring(lastSlash + 1);
                        WriteItemObject(S3ItemInfo.Folder(name),
                            MakeChildPath(rootBucket, EnsureTrailingSlash(rootKey)), isContainer: true);
                    }
                }
                catch (AmazonS3Exception ex)
                {
                    WriteError(new ErrorRecord(ex, "GetItemFailed", ErrorCategory.ReadError, path));
                }
                return;
            }

            ParsePath(path, out var bucket1, out var key);
            try
            {
                if (string.IsNullOrEmpty(key))
                {
                    // Find the bucket in ListBuckets to carry its creation date, else fall back to an
                    // existence probe (e.g. ListAllMyBuckets denied but the bucket is reachable).
                    var b = FindBucket(drive, bucket1);
                    if (b != null)
                        WriteItemObject(S3ItemInfo.Bucket(b.BucketName, b.CreationDate),
                            MakeItemPath(bucket1), isContainer: true);
                    else if (BucketExists(drive, bucket1))
                        WriteItemObject(S3ItemInfo.Bucket(bucket1, null),
                            MakeItemPath(bucket1), isContainer: true);
                    else
                        WriteItemNotFound(path);
                    return;
                }

                // Folder wins over a colliding object. If listing is denied, the object HEAD below
                // still lets buckets that deny ListBucket read/delete known keys.
                var prefixAccessDenied = (AmazonS3Exception)null;
                if (TryPrefixHasChildren(drive, bucket1, key, out prefixAccessDenied))
                {
                    var name = key.TrimEnd('/');
                    var slash = name.LastIndexOf('/');
                    if (slash >= 0) name = name.Substring(slash + 1);
                    WriteItemObject(S3ItemInfo.Folder(name),
                        MakeChildPath(bucket1, EnsureTrailingSlash(key)), isContainer: true);
                    return;
                }

                var meta = TryGetObjectMetadata(drive, bucket1, key);
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
        private S3Bucket FindBucket(S3DriveInfo drive, string bucket)
        {
            try
            {
                foreach (var b in ListBuckets(drive))
                    if (string.Equals(b.BucketName, bucket, StringComparison.Ordinal))
                        return b;
            }
            catch (AmazonS3Exception ex) when (IsAccessDenied(ex)) { return null; }
            return null;
        }

        // HEAD a single object for its metadata, or null if it does not exist.
        private GetObjectMetadataResponse TryGetObjectMetadata(S3DriveInfo drive, string bucket, string key)
        {
            try
            {
                return RunSync(ct => ClientForBucket(drive, bucket).GetObjectMetadataAsync(
                    new GetObjectMetadataRequest { BucketName = bucket, Key = key }, ct));
            }
            catch (AmazonS3Exception ex) when (IsNotFound(ex)) { return null; }
        }

        private void WriteItemNotFound(string path) =>
            WriteError(new ErrorRecord(
                new ItemNotFoundException($"Cannot find path '{path}' because it does not exist."),
                "ItemNotFound", ErrorCategory.ObjectNotFound, path));

    }
}
