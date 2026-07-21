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

using System.Collections.Concurrent;
using System.Management.Automation;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Per-drive state for the drive's lifetime: resolved credentials, the mount region, and (for
    /// multi-region support) one cached client per region plus each bucket's region. Released at Dismount.
    /// </summary>
    internal sealed class S3DriveInfo : PSDriveInfo
    {
        private readonly AWSCredentials _credentials;            // may be null => SDK default chain
        private readonly RegionEndpoint _mountRegion;

        // region system-name -> client. The mount-region client is seeded here.
        private readonly ConcurrentDictionary<string, IAmazonS3> _clientsByRegion =
            new ConcurrentDictionary<string, IAmazonS3>();

        // bucket name -> region system-name. A bucket's region never changes, so cache it.
        private readonly ConcurrentDictionary<string, string> _bucketRegions =
            new ConcurrentDictionary<string, string>();

        /// <summary>Short-TTL listing cache (dedups within-cd/tab prefix probes).</summary>
        internal S3ListingCache ListingCache { get; }

        // Drive-level upload default from -StorageClass at mount; null when unset. Per-upload -StorageClass overrides it.
        internal S3StorageClass DefaultStorageClass { get; }

        internal S3DriveInfo(PSDriveInfo driveInfo, AWSCredentials credentials, RegionEndpoint mountRegion, IAmazonS3 mountClient, S3StorageClass defaultStorageClass = null)
            : base(driveInfo)
        {
            _credentials = credentials;
            _mountRegion = mountRegion;
            _clientsByRegion[mountRegion.SystemName] = mountClient;
            DefaultStorageClass = defaultStorageClass;
            ListingCache = new S3ListingCache(System.TimeSpan.FromSeconds(1));   // 1s TTL
        }

        /// <summary>The mount-region client. Used at the drive root (ListBuckets is global).</summary>
        internal IAmazonS3 Client => _clientsByRegion[_mountRegion.SystemName];

        // Fallback region when a bucket's own region can't be resolved (GetBucketLocation denied).
        internal string MountRegionName => _mountRegion.SystemName;

        // The client for a region, built once and cached.
        internal IAmazonS3 ClientForRegion(string regionSystemName)
        {
            return _clientsByRegion.GetOrAdd(regionSystemName, name =>
            {
                var region = RegionEndpoint.GetBySystemName(name);
                return _credentials != null
                    ? new AmazonS3Client(_credentials, region)
                    : new AmazonS3Client(region);
            });
        }

        /// <summary>Cached bucket->region lookup; null if not resolved yet.</summary>
        internal string GetCachedBucketRegion(string bucket) =>
            _bucketRegions.TryGetValue(bucket, out var r) ? r : null;

        internal void CacheBucketRegion(string bucket, string regionSystemName) =>
            _bucketRegions[bucket] = regionSystemName;

        // A streamed Get-/Set-Content borrows a cached client and can outlive RemoveDrive. Ref-count
        // active ops so Dismount defers client teardown until the last one finishes, rather than
        // disposing a client mid-transfer. _gate serializes the decrement-vs-dispose check.
        private int _activeContentOps;
        private bool _disposeRequested;
        private readonly object _gate = new object();

        internal void BeginContentOperation()
        {
            lock (_gate) { _activeContentOps++; }
        }

        // Finish a content op; run deferred teardown if this was the last one after a Dismount request.
        internal void EndContentOperation()
        {
            bool dispose;
            lock (_gate)
            {
                _activeContentOps--;
                dispose = _disposeRequested && _activeContentOps == 0;
            }
            if (dispose) DisposeClientsNow();
        }

        // Dispose the cached clients at Dismount, or defer if content ops are still in flight.
        internal void DisposeAllClients()
        {
            lock (_gate)
            {
                if (_activeContentOps > 0)
                {
                    _disposeRequested = true;   // last EndContentOperation() will dispose
                    return;
                }
            }
            DisposeClientsNow();
        }

        private void DisposeClientsNow()
        {
            foreach (var c in _clientsByRegion.Values)
                c?.Dispose();
            _clientsByRegion.Clear();
            _bucketRegions.Clear();
            ListingCache.Clear();
        }
    }
}
