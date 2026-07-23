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
    /// Credential/region parameters the provider contributes to New-PSDrive (and Mount-S3PSDrive
    /// forwards). NewDrive reads these to build the client; see ResolveRegion/ResolveCredentials for
    /// the fallback order when they're omitted.
    /// </summary>
    public sealed class S3DriveParameters
    {
        [Parameter] public string ProfileName { get; set; }
        [Parameter] public string Region { get; set; }
        [Parameter] public string AccessKey { get; set; }
        [Parameter] public string SecretKey { get; set; }
        [Parameter] public string SessionToken { get; set; }
        /// <summary>
        /// Named -AWSCredential, not -Credential: New-PSDrive already defines a built-in -Credential
        /// (PSCredential), and reusing that name would collide.
        /// </summary>
        [Parameter] public AWSCredentials AWSCredential { get; set; }

        /// <summary>
        /// Default storage class for every upload on this drive. S3 has no server-side default, so this
        /// is the only "set once" option; unset -> STANDARD. Per-upload -StorageClass overrides it.
        /// </summary>
        [Parameter] public S3StorageClass StorageClass { get; set; }
    }
}
