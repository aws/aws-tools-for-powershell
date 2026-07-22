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

    }
}
