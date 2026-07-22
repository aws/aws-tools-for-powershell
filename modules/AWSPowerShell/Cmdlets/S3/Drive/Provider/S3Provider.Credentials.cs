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
        // Region precedence: explicit -Region -> session default $StoredAWSRegion (via Common) -> us-east-1.
        private RegionEndpoint ResolveRegion(S3DriveParameters dp)
        {
            if (dp != null && !string.IsNullOrEmpty(dp.Region))
                return ValidRegionOrThrow(dp.Region);

            var sessionRegion = SessionDefaultRegionName();   // $StoredAWSRegion, via Common
            return string.IsNullOrEmpty(sessionRegion)
                ? RegionEndpoint.USEast1
                : ValidRegionOrThrow(sessionRegion);
        }

        // GetBySystemName does NOT throw on an unknown name - it returns a synthetic "Unknown" endpoint
        // that only fails later with an obscure DNS/signing error. Reject it up front instead.
        private static RegionEndpoint ValidRegionOrThrow(string systemName)
        {
            var region = RegionEndpoint.GetBySystemName(systemName);
            if (string.Equals(region.DisplayName, "Unknown", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException(
                    $"'{systemName}' is not a known AWS region. Use a region system name such as 'us-east-1'.");
            return region;
        }

        // Credential precedence: explicit keys -> -ProfileName -> -AWSCredential -> session default
        // $StoredAWSCredentials (via Get-AWSCredential) -> null (SDK default chain).
        private AWSCredentials ResolveCredentials(S3DriveParameters dp)
        {
            if (dp != null)
            {
                if (!string.IsNullOrEmpty(dp.AccessKey) && !string.IsNullOrEmpty(dp.SecretKey))
                {
                    return string.IsNullOrEmpty(dp.SessionToken)
                        ? (AWSCredentials)new BasicAWSCredentials(dp.AccessKey, dp.SecretKey)
                        : new SessionAWSCredentials(dp.AccessKey, dp.SecretKey, dp.SessionToken);
                }

                if (!string.IsNullOrEmpty(dp.ProfileName))
                    return ResolveProfile(dp.ProfileName);

                if (dp.AWSCredential != null)
                    return dp.AWSCredential;
            }

            return SessionDefaultCredentials();   // $StoredAWSCredentials, via Common; null if unset
        }

        private static AWSCredentials ResolveProfile(string profileName)
        {
            var chain = new Amazon.Runtime.CredentialManagement.CredentialProfileStoreChain();
            if (chain.TryGetAWSCredentials(profileName, out var creds))
                return creds;
            throw new ArgumentException($"AWS profile '{profileName}' was not found.");
        }

        // ---- AWS.Tools.Common session defaults ----
        // Invoked through SessionState rather than a compile-time reference to Common. Best-effort:
        // any failure (Common not loaded, no default set) falls through to the next resolution step.

        // $StoredAWSCredentials, unwrapped to raw AWSCredentials by Get-AWSCredential. Null if unset.
        private AWSCredentials SessionDefaultCredentials()
        {
            try
            {
                var results = SessionState.InvokeCommand.InvokeScript("Get-AWSCredential");
                foreach (var o in results)
                    if (o?.BaseObject is AWSCredentials creds)
                        return creds;
            }
            catch { /* Common absent or cmdlet failed -> fall through to the SDK default chain */ }
            return null;
        }

        // $StoredAWSRegion system name via Get-DefaultAWSRegion. Null if unset. The cmdlet writes an
        // AWSRegion whose .Region holds the system name, read reflectively to avoid a Common dependency.
        private string SessionDefaultRegionName()
        {
            try
            {
                var results = SessionState.InvokeCommand.InvokeScript("Get-DefaultAWSRegion");
                foreach (var o in results)
                {
                    if (o == null) continue;
                    var prop = o.Properties["Region"];
                    var name = prop?.Value as string;
                    if (!string.IsNullOrEmpty(name)) return name;
                }
            }
            catch { /* Common absent or cmdlet failed -> fall through to us-east-1 */ }
            return null;
        }

    }
}
