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

namespace Amazon.PowerShell.Cmdlets.S3
{
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
                        // Remove-PSDrive refuses to remove the current-location drive with a generic
                        // "in use" message; replace it with an actionable hint to step off first.
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
