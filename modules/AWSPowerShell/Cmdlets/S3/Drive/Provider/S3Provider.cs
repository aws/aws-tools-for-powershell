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
using System.Management.Automation.Provider;
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Amazon S3 as a navigable PowerShell drive (ships in AWS.Tools.S3). Buckets and prefixes are
    /// folders, objects are files. Calls the AWS SDK directly; does not invoke the S3 cmdlets.
    /// Copy-Item is unsupported (CopyItem is not overridden, so it errors).
    /// </summary>
    [CmdletProvider("AWS.S3", ProviderCapabilities.ShouldProcess | ProviderCapabilities.Filter)]
    public sealed partial class S3Provider : NavigationCmdletProvider, IContentCmdletProvider
    {
        // Per-drive state (clients, caches). Usually this.PSDriveInfo is our S3DriveInfo, but a
        // provider-qualified path (e.g. a piped PSPath "AWS.Tools.S3\AWS.S3::bucket\key") resolves
        // against the provider's hidden drive. Resolve those paths by mounted root, or by a shared
        // credential identity when there is no mounted-root clue.
        // Resolve which mounted drive a path belongs to, then give it a chance to re-resolve rotated
        // credentials from disk (a no-op unless it's a -ProfileName drive whose file changed). Every
        // operation funnels through here, so this is the single place to keep credentials fresh.
        private S3DriveInfo DriveForPath(string path)
        {
            var drive = ResolveDrive(path);
            drive?.RefreshCredentialsIfProfileChanged();
            return drive;
        }

        private S3DriveInfo ResolveDrive(string path)
        {
            if (PSDriveInfo is S3DriveInfo di) return di;

            var drives = MountedS3Drives();
            if (drives.Count == 0)
                throw new InvalidOperationException(
                    "No AWS.S3 drive is mounted. Mount one with Mount-S3PSDrive before using an S3 path.");
            if (drives.Count == 1)
                return drives[0];

            var driveQualifier = GetDriveQualifier(path);
            if (!string.IsNullOrEmpty(driveQualifier))
            {
                foreach (var d in drives)
                    if (string.Equals(d.Name, driveQualifier, StringComparison.OrdinalIgnoreCase))
                        return d;
            }

            ParsePath(path, out var bucket, out var key);
            var rootMatch = BestMountedRootMatch(drives, bucket, key);
            if (rootMatch != null)
                return rootMatch;

            var sameCredentials = SameCredentialFallback(drives);
            if (sameCredentials != null)
                return sameCredentials;

            throw new InvalidOperationException(
                "The S3 path is ambiguous: more than one AWS.S3 drive with different credentials is mounted. " +
                $"Qualify it with a drive (e.g. \"S3:{Sep}bucket{Sep}key\") instead of a provider-qualified path.");
        }

        private List<S3DriveInfo> MountedS3Drives()
        {
            var drives = new List<S3DriveInfo>();
            if (ProviderInfo?.Drives != null)
                foreach (var d in ProviderInfo.Drives)
                    if (d is S3DriveInfo s3d)
                        drives.Add(s3d);
            return drives;
        }

        private S3DriveInfo BestMountedRootMatch(List<S3DriveInfo> drives, string bucket, string key)
        {
            if (string.IsNullOrEmpty(bucket))
                return null;

            var fullPath = string.IsNullOrEmpty(key) ? bucket : bucket + "/" + key;
            S3DriveInfo best = null;
            int bestLength = -1;

            foreach (var drive in drives)
            {
                var root = NormalizeRoot(drive.Root);
                if (root.Length == 0 || !PathMatchesRoot(fullPath, root))
                    continue;

                if (root.Length > bestLength)
                {
                    best = drive;
                    bestLength = root.Length;
                }
                else if (root.Length == bestLength
                         && !string.Equals(best.CredentialIdentity, drive.CredentialIdentity, StringComparison.Ordinal))
                {
                    throw new InvalidOperationException(
                        "The S3 path is ambiguous: it matches more than one AWS.S3 drive with different credentials. " +
                        $"Qualify it with a drive (e.g. \"S3:{Sep}bucket{Sep}key\") instead of a provider-qualified path.");
                }
            }

            return best;
        }

        private static S3DriveInfo SameCredentialFallback(List<S3DriveInfo> drives)
        {
            var first = drives[0];
            for (var i = 1; i < drives.Count; i++)
                if (!string.Equals(first.CredentialIdentity, drives[i].CredentialIdentity, StringComparison.Ordinal))
                    return null;
            return first;
        }

        private static string NormalizeRoot(string root) =>
            string.IsNullOrWhiteSpace(root) ? "" : root.Replace('\\', '/').Trim('/');

        private static bool PathMatchesRoot(string fullPath, string root) =>
            string.Equals(fullPath, root, StringComparison.Ordinal)
            || fullPath.StartsWith(root + "/", StringComparison.Ordinal);

        private string GetDriveQualifier(string path)
        {
            if (string.IsNullOrEmpty(path))
                return null;

            var p = path;
            var sep = p.IndexOf("::", StringComparison.Ordinal);
            if (sep >= 0 && IsProviderQualifier(p.Substring(0, sep)))
                p = p.Substring(sep + 2);

            var colon = p.IndexOf(':');
            var firstSeparator = p.IndexOfAny(new[] { '\\', '/' });
            if (colon >= 0 && (firstSeparator < 0 || colon < firstSeparator))
                return p.Substring(0, colon);

            return null;
        }

        // The client for the region a bucket lives in, so one drive spans all regions. Region is
        // resolved on first touch and cached. When GetBucketLocation is denied we fall back to the
        // mount region (as ValidateRoot does) so browsing works without s3:GetBucketLocation; the real
        // operation still surfaces any genuine access error.
        private IAmazonS3 ClientForBucket(S3DriveInfo drive, string bucket)
        {
            var region = drive.GetCachedBucketRegion(bucket);
            if (region == null)
            {
                try
                {
                    region = ResolveBucketRegion(drive.Client, bucket);
                }
                catch (AmazonS3Exception ex) when (IsAccessDenied(ex))
                {
                    region = drive.MountRegionName;
                }
                drive.CacheBucketRegion(bucket, region);
            }
            return drive.ClientForRegion(region);
        }

        // Resolver client is a parameter because this also runs at mount, before this.PSDriveInfo is
        // assigned. GetBucketLocation, not HeadBucket: a region-pinned HeadBucket
        // throws MovedPermanently cross-region. us-east-1 buckets return a null/empty location.
        private string ResolveBucketRegion(IAmazonS3 resolver, string bucket)
        {
            var resp = RunSync(ct => resolver.GetBucketLocationAsync(
                new GetBucketLocationRequest { BucketName = bucket }, ct));
            var loc = resp.Location?.Value;
            if (string.IsNullOrEmpty(loc)) return "us-east-1";   // null/"" => us-east-1
            if (loc == "EU") return "eu-west-1";                 // legacy alias
            return loc;
        }

        // Default part size for Set-Content's non-seekable stream uploads. TU cannot choose from
        // the final object length, so this keeps streams under S3's 10,000-part limit until ~156 GiB.
        // Set-Content -PartSize overrides it.
        private const long DefaultMultipartUploadPartSize = 16L * 1024 * 1024;

        private Amazon.S3.Transfer.TransferUtility TransferUtilityForBucket(S3DriveInfo drive, string bucket) =>
            new Amazon.S3.Transfer.TransferUtility(ClientForBucket(drive, bucket),
                new Amazon.S3.Transfer.TransferUtilityConfig { MinSizeBeforePartUpload = DefaultMultipartUploadPartSize });

    }
}
