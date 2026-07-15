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

using System.Management.Automation;
using Amazon.Runtime;
using Amazon.S3;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Credential/region parameters the provider contributes to New-PSDrive (via
    /// NewDriveDynamicParameters) and that Mount-S3PSDrive forwards. The provider's NewDrive
    /// reads these to build the client. When omitted, NewDrive falls back to the AWS.Tools.Common
    /// session defaults ($StoredAWSCredentials / $StoredAWSRegion), then the SDK default chain.
    /// </summary>
    public sealed class S3DriveParameters
    {
        [Parameter] public string ProfileName { get; set; }
        [Parameter] public string Region { get; set; }
        [Parameter] public string AccessKey { get; set; }
        [Parameter] public string SecretKey { get; set; }
        [Parameter] public string SessionToken { get; set; }
        /// <summary>
        /// Named -AWSCredential, NOT -Credential. New-PSDrive already defines a built-in
        /// -Credential (PSCredential); reusing that name as a dynamic parameter collides
        /// ("parameter defined multiple times") and breaks both New-PSDrive and the wrapper.
        /// </summary>
        [Parameter] public AWSCredentials AWSCredential { get; set; }

        /// <summary>
        /// Default storage class applied to every upload on this drive (e.g. STANDARD_IA, GLACIER).
        /// Unlike encryption (which S3 can default at the bucket) there is NO server-side default for
        /// storage class, so a drive-level default is the only "set once" option. Optional; when unset
        /// S3 uses STANDARD. A per-upload -StorageClass on Set-Content overrides this.
        /// </summary>
        [Parameter] public S3StorageClass StorageClass { get; set; }
    }
}
