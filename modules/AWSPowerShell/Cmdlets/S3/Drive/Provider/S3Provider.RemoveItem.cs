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
using System.Collections.Generic;
using System.Management.Automation;
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
                    $"Remove-Item on the S3 drive requires an object or prefix path (bucket{Sep}key).",
                    "InvalidRemovePath", out var bucket, out var key))
                return;
            var drive = DriveForPath(path);

            try
            {
                // Prefix (folder) when it has children, else a single object. On denied listing the
                // exact-object path still lets a known key be removed without list permission.
                if (TryPrefixHasChildren(drive, bucket, key, out _))
                {
                    if (!recurse)
                    {
                        WriteError(new ErrorRecord(
                            new InvalidOperationException(
                                $"'{path}' is a folder with contents. Use -Recurse to delete it and everything under it."),
                            "PrefixRequiresRecurse", ErrorCategory.InvalidOperation, path));
                        return;
                    }
                    RemovePrefixRecursive(drive, bucket, key, path);
                }
                else
                {
                    // Honor -Filter on the single object too, so it never deletes a non-matching key
                    // the user named explicitly. No filter set => MatchesFilter is true (delete).
                    if (!MatchesFilter(LeafName(key)))
                        return;

                    if (!ShouldProcess(path, "Remove S3 object"))
                        return;

                    RunSync(ct => ClientForBucket(drive, bucket).DeleteObjectAsync(
                        new DeleteObjectRequest { BucketName = bucket, Key = key }, ct));
                    drive.ListingCache.InvalidateForKey(bucket, key);
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

        private void RemovePrefixRecursive(S3DriveInfo drive, string bucket, string key, string displayPath)
        {
            // No extra prompt: -Recurse deletes silently, and the engine's container-recurse prompt
            // (non-empty prefix without -Recurse) was already the confirmation.
            if (!ShouldProcess(displayPath, "Recursively remove S3 prefix and all objects under it"))
                return;

            var client = ClientForBucket(drive, bucket);
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
                            // Honor -Filter: it matches the leaf name, same as the listing path
                            // (GetChildItems -Recurse). Without this a filtered delete would remove
                            // every object under the prefix, not just the matches. No filter set =>
                            // MatchesFilter returns true, so everything is deleted as before.
                            if (!MatchesFilter(LeafName(obj.Key)))
                                continue;
                            batch.Add(new KeyVersion { Key = obj.Key });
                            if (batch.Count == DeleteBatchSize)
                            {
                                DeleteBatch(drive, bucket, batch);
                                batch.Clear();
                            }
                        }
                    }

                    token = resp.NextContinuationToken;
                }
                while (!string.IsNullOrEmpty(token));

                // Also delete the object at the exact key: when a name is both a folder ("key/...") and an
                // object ("key"), the sweep above only covers "key/", so the shadowed object would be left
                // behind. Reads and single-level listings hide it (folder-wins), so a -Confirm user who
                // approved removing the folder may not know it exists; warn when it does so the extra
                // deletion is visible. Filtered the same way, so a filter can't sweep away the shadowed
                // object either.
                var exactKey = key.TrimEnd('/');
                var shadowQueued = false;
                if (exactKey.Length > 0 && MatchesFilter(LeafName(exactKey)))
                {
                    bool? shadowExists;
                    try { shadowExists = ObjectExists(drive, bucket, exactKey); }
                    catch (AmazonS3Exception) { shadowExists = null; }   // can't confirm; delete anyway, real error surfaces
                    if (shadowExists != false)   // exists or unknown: delete (a batched delete no-ops a missing key)
                    {
                        batch.Add(new KeyVersion { Key = exactKey });
                        shadowQueued = true;
                    }
                }

                if (batch.Count > 0)
                {
                    var deleted = DeleteBatch(drive, bucket, batch);
                    // Warn off what S3 actually deleted, not off the probe above: the probe can fail
                    // (HEAD denied while DeleteObject is allowed) and would then leave this silent.
                    if (shadowQueued && deleted.Contains(exactKey))
                        WriteWarning(
                            $"'{displayPath}' matched both a folder and an object with the same name; both were removed.");
                }
            }
            finally
            {
                // In a finally so a mid-sweep failure still refreshes the view for what was deleted.
                drive.ListingCache.InvalidateForKey(bucket, key);
            }
        }

        // Returns the keys S3 reported as deleted.
        private HashSet<string> DeleteBatch(S3DriveInfo drive, string bucket, List<KeyVersion> keys)
        {
            var deleted = new HashSet<string>(StringComparer.Ordinal);
            try
            {
                var resp = RunSync(ct => ClientForBucket(drive, bucket).DeleteObjectsAsync(new DeleteObjectsRequest
                {
                    BucketName = bucket,
                    Objects = keys
                }, ct));
                foreach (var d in resp.DeletedObjects ?? new List<DeletedObject>())
                    deleted.Add(d.Key);
            }
            catch (DeleteObjectsException ex)
            {
                foreach (var d in ex.Response?.DeletedObjects ?? new List<DeletedObject>())
                    deleted.Add(d.Key);

                // Partial failure: report each failed key with its S3 error rather than aborting, so
                // the remaining batches still run and the user sees exactly what could not be removed.
                foreach (var e in ex.Response?.DeleteErrors ?? new List<DeleteError>())
                    WriteError(new ErrorRecord(
                        new AmazonS3Exception($"Failed to delete '{e.Key}': {e.Code} {e.Message}"),
                        "RemoveFailed", ErrorCategory.WriteError, e.Key));
            }
            return deleted;
        }


    }
}
