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
    /// Mounts an S3 drive so buckets, prefixes, and objects can be explored with the standard
    /// navigation commands (Set-Location, Get-ChildItem, Get-Content, Set-Content, Remove-Item).
    /// Credentials and region resolve the same way as the S3 cmdlets: explicit keys, then
    /// -ProfileName, then -AWSCredential, then the session defaults ($StoredAWSCredentials /
    /// $StoredAWSRegion), then the SDK default chain. A single drive spans all regions.
    ///
    /// Thin wrapper over `New-PSDrive -PSProvider AWS.S3`, which also works directly.
    /// </summary>
    /// <example>
    ///   <code>Mount-S3PSDrive -Name S3 -ProfileName my-profile -Region us-east-1</code>
    ///   <para>Mounts an S3: drive using a named profile, then `Get-ChildItem S3:\` lists buckets.</para>
    /// </example>
    /// <example>
    ///   <code>Set-AWSCredential -ProfileName my-profile; Set-DefaultAWSRegion us-west-2; Mount-S3PSDrive -Name S3</code>
    ///   <para>Mounts using the PowerShell session defaults (no explicit credential/region needed).</para>
    /// </example>
    [Cmdlet(VerbsData.Mount, "S3PSDrive")]
    [OutputType(typeof(PSDriveInfo))]
    public sealed class MountS3PSDriveCmdlet : PSCmdlet
    {
        /// <summary>The drive name used in paths (e.g. -Name S3 -> paths look like S3:\bucket\key).</summary>
        [Parameter(Mandatory = true, Position = 0)]
        public string Name { get; set; }

        /// <summary>Scope the drive to a bucket ("my-bucket") or bucket+prefix ("my-bucket/data/2026")
        /// instead of the account root; navigation is then confined beneath it. Omitted mounts at the
        /// account root. The root must exist, or the mount fails.</summary>
        [Parameter] public string Root { get; set; }

        /// <summary>Named AWS credential profile to authenticate with.</summary>
        [Parameter] public string ProfileName { get; set; }
        /// <summary>AWS region for the mount. Falls back to $StoredAWSRegion, then us-east-1.</summary>
        [Parameter] public string Region { get; set; }
        /// <summary>Explicit AWS access key (use with -SecretKey).</summary>
        [Parameter] public string AccessKey { get; set; }
        /// <summary>Explicit AWS secret key (use with -AccessKey).</summary>
        [Parameter] public string SecretKey { get; set; }
        /// <summary>Session token for temporary credentials (use with -AccessKey/-SecretKey).</summary>
        [Parameter] public string SessionToken { get; set; }
        /// <summary>A resolved AWSCredentials object. Named -AWSCredential (not -Credential, which
        /// New-PSDrive already defines as a PSCredential and would collide with).</summary>
        [Parameter] public AWSCredentials AWSCredential { get; set; }

        /// <summary>Default storage class for objects uploaded to this drive (e.g. STANDARD_IA,
        /// GLACIER). When unset, S3 uses STANDARD. Overridable per upload via -StorageClass on
        /// Set-Content.</summary>
        [Parameter] public S3StorageClass StorageClass { get; set; }

        /// <summary>Return the created PSDriveInfo. By default the cmdlet produces no output.</summary>
        [Parameter] public SwitchParameter PassThru { get; set; }

        protected override void ProcessRecord()
        {
            // Normalize the root to "bucket/prefix" (backslashes -> slashes, empty segments dropped).
            // Collapsing interior "//" is load-bearing: the engine prepends the stored root verbatim and
            // ParsePath only trims the ends, so "bkt//data" would inject an empty segment into the key.
            var normalizedRoot = string.IsNullOrWhiteSpace(Root)
                ? ""
                : string.Join("/", Root.Replace('\\', '/')
                                        .Split(new[] { '/' }, System.StringSplitOptions.RemoveEmptyEntries));

            // Forward to New-PSDrive -PSProvider AWS.S3; the provider's dynamic parameters surface the
            // credential/region params, so we just pass them through.
            using (var ps = System.Management.Automation.PowerShell.Create(RunspaceMode.CurrentRunspace))
            {
                ps.AddCommand("New-PSDrive")
                  .AddParameter("Name", Name)
                  .AddParameter("PSProvider", "AWS.S3")
                  .AddParameter("Root", normalizedRoot)
                  .AddParameter("Scope", "Global");

                if (!string.IsNullOrEmpty(ProfileName))  ps.AddParameter("ProfileName", ProfileName);
                if (!string.IsNullOrEmpty(Region))       ps.AddParameter("Region", Region);
                if (!string.IsNullOrEmpty(AccessKey))    ps.AddParameter("AccessKey", AccessKey);
                if (!string.IsNullOrEmpty(SecretKey))    ps.AddParameter("SecretKey", SecretKey);
                if (!string.IsNullOrEmpty(SessionToken)) ps.AddParameter("SessionToken", SessionToken);
                if (AWSCredential != null)               ps.AddParameter("AWSCredential", AWSCredential);
                if (StorageClass != null)                ps.AddParameter("StorageClass", StorageClass);

                var results = ps.Invoke();

                if (ps.HadErrors)
                {
                    foreach (var err in ps.Streams.Error)
                        WriteError(err);
                    return;
                }

                if (PassThru)
                    foreach (var r in results)
                        WriteObject(r, false);
            }
        }
    }
}
