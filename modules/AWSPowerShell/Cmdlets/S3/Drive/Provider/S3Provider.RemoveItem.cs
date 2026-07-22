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


    }
}
