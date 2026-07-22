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
        // ---- S3 calls --------------------------------------------------------

        // ListBuckets is paginated: an account past the first page would otherwise silently list only
        // some buckets. Follow ContinuationToken to the end, stopping cleanly on Ctrl+C.
        private List<S3Bucket> ListBuckets()
        {
            var buckets = new List<S3Bucket>();
            var request = new ListBucketsRequest();
            string token = null;
            do
            {
                if (Stopping) break;
                request.ContinuationToken = token;
                var response = RunSync(ct => Client.ListBucketsAsync(request, ct));
                if (response.Buckets != null)
                    buckets.AddRange(response.Buckets);
                token = response.ContinuationToken;
            }
            while (!string.IsNullOrEmpty(token));
            return buckets;
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

    }
}
