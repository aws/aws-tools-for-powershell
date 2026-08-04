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
    /// Remove-PSDrive. Step off the drive first (for example, `Set-Location $HOME`) because
    /// PowerShell cannot remove a drive that is the current location. Use Get-PSDrive to list
    /// mounted drives.
    /// </summary>
    /// <example>
    ///   <code>Set-Location $HOME; Dismount-S3PSDrive -Name S3</code>
    ///   <para>Steps off the S3: drive and removes it.</para>
    /// </example>
    [Cmdlet(VerbsData.Dismount, "S3PSDrive")]
    [Amazon.PowerShell.Common.AWSCmdlet("Removes an S3 PowerShell drive created by Mount-S3PSDrive. Step off the drive first if it is your current location.")]
    [Amazon.PowerShell.Common.AWSCmdletOutput("None", "This cmdlet does not generate any output.")]
    public sealed class DismountS3PSDriveCmdlet : PSCmdlet
    {
        /// <summary>Name of the drive to unmount (the -Name given to Mount-S3PSDrive).</summary>
        [Parameter(Mandatory = true, Position = 0)]
        public string Name { get; set; }

        protected override void ProcessRecord()
        {
            if (string.Equals(
                SessionState.Path.CurrentLocation?.Drive?.Name,
                Name,
                System.StringComparison.OrdinalIgnoreCase))
            {
                WriteDriveInUseError(null);
                return;
            }

            using (var ps = System.Management.Automation.PowerShell.Create(RunspaceMode.CurrentRunspace))
            {
                ps.AddCommand("Remove-PSDrive")
                  .AddParameter("Name", Name)
                  .AddParameter("Scope", "Global")
                  .AddParameter("ErrorAction", ActionPreference.Stop);

                ErrorRecord invocationError = null;
                try
                {
                    ps.Invoke();
                }
                catch (RuntimeException e)
                {
                    invocationError = e.ErrorRecord ?? new ErrorRecord(
                        e, "RemovePSDriveFailed", ErrorCategory.InvalidOperation, Name);
                }

                if (IsDriveInUseError(invocationError))
                {
                    WriteDriveInUseError(invocationError.Exception);
                    return;
                }

                foreach (var error in ps.Streams.Error)
                {
                    if (IsDriveInUseError(error))
                    {
                        WriteDriveInUseError(error.Exception);
                        return;
                    }
                }

                // A terminating error can also be present in Streams.Error. Prefer the stream
                // records when available so the same underlying error is not emitted twice.
                if (ps.Streams.Error.Count > 0)
                {
                    foreach (var error in ps.Streams.Error)
                        WriteError(error);
                }
                else if (invocationError != null)
                {
                    WriteError(invocationError);
                }
            }
        }

        private static bool IsDriveInUseError(ErrorRecord error)
        {
            if (error == null)
                return false;

            if (error.CategoryInfo?.Category == ErrorCategory.ResourceBusy)
                return true;

            return ContainsInUse(error.ErrorDetails?.Message) ||
                   ContainsInUse(error.Exception?.Message) ||
                   ContainsInUse(error.Exception?.InnerException?.Message);
        }

        private static bool ContainsInUse(string message)
        {
            return message?.IndexOf(
                "in use", System.StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void WriteDriveInUseError(System.Exception innerException)
        {
            WriteError(new ErrorRecord(
                new PSInvalidOperationException(
                    $"Cannot dismount drive '{Name}' because it is in use. Change to a location outside the drive (for example, Set-Location $HOME), then retry Dismount-S3PSDrive -Name {Name}.",
                    innerException),
                "DismountDriveInUse", ErrorCategory.ResourceBusy, Name));
        }
    }
}
