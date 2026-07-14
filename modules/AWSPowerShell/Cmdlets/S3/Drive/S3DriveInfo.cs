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
    /// Per-drive state, created by <see cref="S3Provider.NewDrive"/> and living for the
    /// drive's lifetime. Holds the SDK connection state (clients, region maps) - never
    /// copies of S3 content.
    ///
    /// Multi-region: a single drive spans all regions. We keep the resolved credentials and
    /// the mount region, then build/cache one client per region on demand and remember each
    /// bucket's region. Both caches are released at Dismount.
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

        /// <summary>
        /// Default storage class for uploads on this drive, from -StorageClass at mount. Null when
        /// unset (S3 then uses STANDARD). A per-upload -StorageClass on Set-Content overrides it.
        /// </summary>
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

        /// <summary>The mount region's system name (e.g. "us-east-1"). Used as the fallback when a
        /// bucket's own region can't be resolved (e.g. GetBucketLocation is access-denied).</summary>
        internal string MountRegionName => _mountRegion.SystemName;

        /// <summary>Get (building once and caching) the client for a given region name.</summary>
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

        // Outstanding content operations (Get-/Set-Content) that borrow a cached client for the
        // whole streamed read/upload, which can outlive the RemoveDrive call that disposes the
        // drive. We ref-count them so Dismount does not dispose a client mid-transfer (which would
        // fail the transfer with ObjectDisposedException): teardown is deferred until the last
        // content op finishes. _disposeRequested records that RemoveDrive has been called while
        // ops were still live. _gate serializes the decrement-vs-dispose check.
        private int _activeContentOps;
        private bool _disposeRequested;
        private readonly object _gate = new object();

        /// <summary>Register the start of a content operation that borrows a cached client.</summary>
        internal void BeginContentOperation()
        {
            lock (_gate) { _activeContentOps++; }
        }

        /// <summary>Mark a content operation finished; perform deferred teardown if Dismount was
        /// requested while this was the last one running.</summary>
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

        /// <summary>Dispose the cached clients when the drive is removed - but if content
        /// operations are still in flight, defer teardown until the last one completes so an
        /// in-progress transfer is never cut off by a disposed client.</summary>
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
