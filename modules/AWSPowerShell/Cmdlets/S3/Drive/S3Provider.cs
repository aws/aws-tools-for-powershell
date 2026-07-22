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
    /// <summary>
    /// Amazon S3 as a navigable PowerShell drive (ships in AWS.Tools.S3). Buckets and prefixes are
    /// folders, objects are files. Calls the AWS SDK directly; does not invoke the S3 cmdlets.
    /// Copy-Item is unsupported (CopyItem is not overridden, so it errors).
    /// </summary>
    [CmdletProvider("AWS.S3", ProviderCapabilities.None)]
    public sealed partial class S3Provider : NavigationCmdletProvider, IContentCmdletProvider
    {
        // Per-drive state (clients, caches). Usually this.PSDriveInfo is our S3DriveInfo, but a
        // provider-qualified path (e.g. a piped PSPath "AWS.Tools.S3\AWS.S3::bucket\key") resolves
        // against the provider's hidden drive, so we fall back to the first drive in ProviderInfo.Drives.
        private S3DriveInfo Drive
        {
            get
            {
                if (PSDriveInfo is S3DriveInfo di) return di;
                if (ProviderInfo?.Drives != null)
                    foreach (var d in ProviderInfo.Drives)
                        if (d is S3DriveInfo s3d) return s3d;
                throw new InvalidOperationException(
                    "No AWS.S3 drive is mounted. Mount one with Mount-S3PSDrive before using an S3 path.");
            }
        }

        // The mount-region client. Used at the drive root, where ListBuckets is account-global.
        private IAmazonS3 Client => Drive.Client;

        // The client for the region a bucket lives in, so one drive spans all regions. Region is
        // resolved on first touch and cached.
        private IAmazonS3 ClientForBucket(string bucket)
        {
            var region = Drive.GetCachedBucketRegion(bucket);
            if (region == null)
            {
                region = ResolveBucketRegion(Client, bucket);
                Drive.CacheBucketRegion(bucket, region);
            }
            return Drive.ClientForRegion(region);
        }

        // Resolver client is a parameter (not the Client property) because this also runs at mount,
        // before this.Drive exists. GetBucketLocation, not HeadBucket: a region-pinned HeadBucket
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

        // Default multipart part size for non-seekable uploads. Without it the SDK falls back to S3's
        // 5 MiB minimum, which hits the 10,000-part limit past ~49 GiB. Set-Content -PartSize overrides it.
        private const long MultipartThreshold = 8 * 1024 * 1024;

        private Amazon.S3.Transfer.TransferUtility TransferUtilityForBucket(string bucket) =>
            new Amazon.S3.Transfer.TransferUtility(ClientForBucket(bucket),
                new Amazon.S3.Transfer.TransferUtilityConfig { MinSizeBeforePartUpload = MultipartThreshold });

    }
}
