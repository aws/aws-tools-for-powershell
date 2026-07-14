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

        /// <summary>Mount the drive scoped to a bucket ("my-bucket") or a bucket+prefix
        /// ("my-bucket/data/2026") instead of the account root. `Get-ChildItem <drive>:\` then lists
        /// the contents under that root and navigation is confined beneath it. Omitted/empty mounts
        /// at the account root (lists buckets), the original behavior. The root must exist (a bad
        /// bucket or nonexistent prefix fails the mount). Named, not positional, so it can't be
        /// confused with -Name.</summary>
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
            // Normalize the root to a clean "bucket/prefix" (or "") form BEFORE forwarding, so
            // New-PSDrive stores a tidy root: backslashes -> forward slashes, and split-on-'/'
            // discarding empty segments (trims leading/trailing slashes AND collapses interior
            // "//"). Collapsing doubles is load-bearing, not cosmetic - the engine prepends the
            // stored root verbatim and the provider's ParsePath only trims the ends, so an
            // un-collapsed "bkt//data" would inject an empty segment into the S3 key.
            var normalizedRoot = string.IsNullOrWhiteSpace(Root)
                ? ""
                : string.Join("/", Root.Replace('\\', '/')
                                        .Split(new[] { '/' }, System.StringSplitOptions.RemoveEmptyEntries));

            // Forward to New-PSDrive -PSProvider AWS.S3; the provider's NewDriveDynamicParameters
            // surfaces ProfileName/Region/keys/AWSCredential, so we just pass them through.
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
                // Only forward -StorageClass if the caller set it (SwitchParameter-like: default(S3StorageClass)
                // is null for this reference type, so a plain null check is the "was it specified" test).
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

    /// <summary>
    /// Unmounts an S3 drive previously created with Mount-S3PSDrive. Thin wrapper over
    /// Remove-PSDrive. Step off the drive first (e.g. `Set-Location C:\`) — PowerShell won't
    /// remove a drive that is the current location.
    /// </summary>
    /// <example>
    ///   <code>Set-Location C:\; Dismount-S3PSDrive -Name S3</code>
    ///   <para>Steps off the S3: drive and removes it.</para>
    /// </example>
    [Cmdlet(VerbsData.Dismount, "S3PSDrive")]
    public sealed class DismountS3PSDriveCmdlet : PSCmdlet
    {
        /// <summary>Name of the drive to unmount (the -Name given to Mount-S3PSDrive).</summary>
        [Parameter(Mandatory = true, Position = 0)]
        public string Name { get; set; }

        protected override void ProcessRecord()
        {
            using (var ps = System.Management.Automation.PowerShell.Create(RunspaceMode.CurrentRunspace))
            {
                ps.AddCommand("Remove-PSDrive")
                  .AddParameter("Name", Name)
                  .AddParameter("Scope", "Global");
                ps.Invoke();
                if (ps.HadErrors)
                    foreach (var err in ps.Streams.Error)
                    {
                        // Remove-PSDrive refuses to remove the drive you are standing on, with a
                        // generic "in use" message. Add an actionable hint to step off first.
                        if (err.CategoryInfo?.Category == ErrorCategory.ResourceBusy ||
                            (err.Exception?.Message?.IndexOf("in use", System.StringComparison.OrdinalIgnoreCase) ?? -1) >= 0)
                        {
                            WriteError(new ErrorRecord(
                                new System.Management.Automation.PSInvalidOperationException(
                                    $"Cannot dismount drive '{Name}' because it is in use - it may be your current location. Step off it first (e.g. Set-Location $HOME), then Dismount-S3PSDrive -Name {Name}.",
                                    err.Exception),
                                "DismountDriveInUse", ErrorCategory.ResourceBusy, Name));
                        }
                        else
                        {
                            WriteError(err);
                        }
                    }
            }
        }
    }
}
