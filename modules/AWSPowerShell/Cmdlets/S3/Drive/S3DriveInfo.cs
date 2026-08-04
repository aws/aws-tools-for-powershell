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
        private AWSCredentials _credentials;                     // may be null => SDK default chain
        private readonly RegionEndpoint _mountRegion;

        // Set when the drive was mounted with -ProfileName or profile-backed session defaults. Lets the
        // drive re-resolve the profile when its shared-credentials file is rewritten externally (e.g.
        // `ada` rotating keys), so it doesn't keep a stale one-time credential snapshot. Null for
        // explicit-key, -AWSCredential, and non-profile session-default forms.
        private readonly string _profileName;
        private readonly string _profileLocation;
        private string _credentialsFilePath;                     // the profile's backing file, if any
        private DateTime? _credentialsFileMtimeUtc;              // its mtime when last resolved

        // region system-name -> client. The mount-region client is seeded here.
        private readonly ConcurrentDictionary<string, IAmazonS3> _clientsByRegion =
            new ConcurrentDictionary<string, IAmazonS3>();

        // bucket name -> region system-name. A bucket's region never changes, so cache it.
        private readonly ConcurrentDictionary<string, string> _bucketRegions =
            new ConcurrentDictionary<string, string>();

        /// <summary>Short-TTL listing cache (dedups within-cd/tab prefix probes).</summary>
        internal S3ListingCache ListingCache { get; }

        // Non-secret credential identity used only to decide whether an otherwise drive-independent
        // provider path can safely fall back across several mounted drives.
        internal string CredentialIdentity { get; }

        // Drive-level upload default from -StorageClass at mount; null when unset. Per-upload -StorageClass overrides it.
        internal S3StorageClass DefaultStorageClass { get; }

        internal S3DriveInfo(PSDriveInfo driveInfo, AWSCredentials credentials, RegionEndpoint mountRegion, IAmazonS3 mountClient,
            S3StorageClass defaultStorageClass = null, string credentialIdentity = null,
            string profileName = null, string profileLocation = null)
            : base(driveInfo)
        {
            _credentials = credentials;
            _mountRegion = mountRegion;
            _clientsByRegion[mountRegion.SystemName] = mountClient;
            CredentialIdentity = string.IsNullOrEmpty(credentialIdentity)
                ? BuildCredentialIdentity(credentials)
                : credentialIdentity;
            DefaultStorageClass = defaultStorageClass;
            ListingCache = new S3ListingCache(System.TimeSpan.FromSeconds(1));   // 1s TTL

            _profileName = profileName;
            _profileLocation = profileLocation;
            if (!string.IsNullOrEmpty(_profileName))
                CaptureProfileFileState();
        }

        internal static string BuildCredentialIdentity(AWSCredentials credentials)
        {
            if (credentials == null)
                return "SDKDefaultCredentials";

            try
            {
                var immutable = credentials.GetCredentials();
                if (!string.IsNullOrEmpty(immutable?.AccessKey))
                    return "AccessKey:" + immutable.AccessKey;
            }
            catch { }

            return "CredentialsObject:" + credentials.GetType().FullName + ":" +
                System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(credentials);
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

        // ---- Profile-file re-resolution (PowerShell-608 pattern, for -ProfileName drives) ----------
        // A named-profile drive resolves its credentials once at mount. If the shared-credentials file
        // is rewritten externally (e.g. `ada`/aws-adfs rotating static session keys), the drive would
        // otherwise keep using the stale snapshot and fail "token expired". Re-resolve from disk when
        // the backing file's mtime changes, then rebuild the cached clients so later ops use the fresh
        // keys - no remount needed. Limited to static snapshots (Basic/Session); SSO, assume-role,
        // container, instance-profile, and credential_process credentials self-refresh in the SDK.
        internal void RefreshCredentialsIfProfileChanged()
        {
            if (string.IsNullOrEmpty(_profileName))
                return;   // only profile-backed drives can be re-resolved from disk

            lock (_gate)
            {
                // Don't tear down clients an in-flight streamed transfer is still reading from; a fresh
                // op after it completes will pick up the rotated keys (same rule as deferred Dismount).
                if (_activeContentOps > 0)
                    return;

                if (!ProfileFileChanged())
                    return;

                if (!Amazon.PowerShell.Common.SettingsStore.TryGetAWSCredentials(
                        _profileName, _profileLocation, out var fresh) || fresh == null)
                {
                    // Profile no longer resolvable: keep the current creds and re-snapshot the mtime so
                    // we don't re-probe every op. The next real call surfaces any genuine error.
                    CaptureProfileFileState();
                    return;
                }

                // Only rotate static snapshots. Self-refreshing credential types are left untouched so
                // we don't needlessly rebuild clients (or re-trigger token work) for them.
                if (!IsStaticSnapshot(_credentials))
                {
                    CaptureProfileFileState();
                    return;
                }

                var stale = new System.Collections.Generic.List<IAmazonS3>(_clientsByRegion.Values);
                _clientsByRegion.Clear();
                _credentials = fresh;
                // Re-seed the mount-region client so the Client property stays valid; other regions
                // rebuild lazily via ClientForRegion with the new credentials.
                _clientsByRegion[_mountRegion.SystemName] = new AmazonS3Client(fresh, _mountRegion);
                CaptureProfileFileState();

                foreach (var c in stale)
                    try { c?.Dispose(); } catch { /* best-effort teardown of superseded clients */ }
            }
        }

        private static bool IsStaticSnapshot(AWSCredentials credentials) =>
            credentials is BasicAWSCredentials || credentials is SessionAWSCredentials;

        // Record the profile's backing shared-credentials file and its mtime, so a later external
        // rewrite is detectable. Only shared-credentials-file profiles expose a path; others (SDK
        // store, env, etc.) leave the path null and are treated as never-changing.
        private void CaptureProfileFileState()
        {
            _credentialsFilePath = null;
            _credentialsFileMtimeUtc = null;
            if (Amazon.PowerShell.Common.SettingsStore.TryGetProfile(_profileName, _profileLocation, out var profile))
            {
                _credentialsFilePath =
                    (profile?.CredentialProfileStore as Amazon.Runtime.CredentialManagement.SharedCredentialsFile)?.FilePath;
                _credentialsFileMtimeUtc = SafeGetLastWriteTimeUtc(_credentialsFilePath);
            }
        }

        private bool ProfileFileChanged()
        {
            if (string.IsNullOrEmpty(_credentialsFilePath) || _credentialsFileMtimeUtc == null)
                return false;
            var current = SafeGetLastWriteTimeUtc(_credentialsFilePath);
            return current != null && current != _credentialsFileMtimeUtc;
        }

        private static DateTime? SafeGetLastWriteTimeUtc(string path)
        {
            if (string.IsNullOrEmpty(path))
                return null;
            try
            {
                return System.IO.File.Exists(path) ? System.IO.File.GetLastWriteTimeUtc(path) : (DateTime?)null;
            }
            catch { return null; }
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
