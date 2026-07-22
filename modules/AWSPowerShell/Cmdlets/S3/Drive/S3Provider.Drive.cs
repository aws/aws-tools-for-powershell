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
        // ---- Drive lifecycle -------------------------------------------------

        // Contributes the credential/region parameters to New-PSDrive when -PSProvider is AWS.S3
        // (Mount-S3PSDrive forwards these).
        protected override object NewDriveDynamicParameters() => new S3DriveParameters();

        // Called by New-PSDrive. Resolves region/credentials and builds the drive's AmazonS3Client.
        protected override PSDriveInfo NewDrive(PSDriveInfo drive)
        {
            if (drive == null)
            {
                WriteError(new ErrorRecord(
                    new ArgumentNullException(nameof(drive)),
                    "NullDrive", ErrorCategory.InvalidArgument, null));
                return null;
            }

            var dp = DynamicParameters as S3DriveParameters;

            try
            {
                var region = ResolveRegion(dp);
                var creds = ResolveCredentials(dp);   // may be null -> SDK default chain

                var client = creds != null
                    ? new AmazonS3Client(creds, region)
                    : new AmazonS3Client(region);

                // Use this local instance and mount client for ValidateRoot below: this.PSDriveInfo
                // (and Drive/Client) stays null until the engine assigns it after NewDrive returns.
                var s3drive = new S3DriveInfo(drive, creds, region, client, dp?.StorageClass);

                // Fail fast on an unreachable root, so a typo errors at mount instead of first listing.
                if (!ValidateRoot(s3drive, client, drive.Root))
                {
                    WriteError(new ErrorRecord(
                        new ItemNotFoundException(
                            $"The S3 drive root '{drive.Root}' was not found or is not reachable."),
                        "InvalidDriveRoot", ErrorCategory.ObjectNotFound, drive));
                    return null;
                }

                return s3drive;
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, "NewDriveFailed", ErrorCategory.OpenError, drive));
                return null;
            }
        }

        // Mount-time reachability check (true = mount, false = reject). Runs against the local drive +
        // mount client since this.Drive is null inside NewDrive. AccessDenied always passes: the
        // resource exists but we can't inspect it, so the real error surfaces on the actual operation.
        private bool ValidateRoot(S3DriveInfo drive, IAmazonS3 mountClient, string root)
        {
            ParsePath(root, out var bucket, out var keyPrefix);

            // Account root: validate credentials with a single ListBuckets.
            if (string.IsNullOrEmpty(bucket))
            {
                try
                {
                    RunSync(ct => mountClient.ListBucketsAsync(new ListBucketsRequest(), ct));
                    return true;
                }
                catch (AmazonS3Exception ex) when (IsAccessDenied(ex))
                {
                    return true;   // valid creds, just lacking s3:ListAllMyBuckets
                }
                // Any other exception (expired/invalid creds) propagates to NewDrive's catch.
            }

            // Bucket root: resolve its region so the probe below uses a region-correct client.
            string regionName;
            try
            {
                regionName = ResolveBucketRegion(mountClient, bucket);
            }
            catch (AmazonS3Exception ex) when (IsNotFound(ex))
            {
                return false;   // no such bucket
            }
            catch (AmazonS3Exception ex) when (IsAccessDenied(ex))
            {
                regionName = drive.MountRegionName;   // can't read location; fall back to mount region
            }

            drive.CacheBucketRegion(bucket, regionName);
            var client = drive.ClientForRegion(regionName);

            try
            {
                if (string.IsNullOrEmpty(keyPrefix))
                {
                    // Bucket-only: an empty bucket is still a valid mount.
                    RunSync(ct => client.ListObjectsV2Async(
                        new ListObjectsV2Request { BucketName = bucket, MaxKeys = 1 }, ct));
                    return true;
                }

                // Prefix root: reject a nonexistent prefix (a directory-marker object counts as a child).
                var listPrefix = EnsureTrailingSlash(keyPrefix);
                var resp = RunSync(ct => client.ListObjectsV2Async(new ListObjectsV2Request
                {
                    BucketName = bucket,
                    Prefix = listPrefix,
                    Delimiter = "/",
                    MaxKeys = 1
                }, ct));
                return (resp.S3Objects?.Count ?? 0) > 0 || (resp.CommonPrefixes?.Count ?? 0) > 0;
            }
            catch (AmazonS3Exception ex) when (IsNotFound(ex)) { return false; }
            catch (AmazonS3Exception ex) when (IsAccessDenied(ex)) { return true; }
            // Other S3 errors propagate to NewDrive's catch.
        }

        protected override PSDriveInfo RemoveDrive(PSDriveInfo drive)
        {
            (drive as S3DriveInfo)?.DisposeAllClients();
            return drive;
        }

    }
}
