<#
.Synopsis
    Builds the standard "module in use" terminating error for locked (imported) modules.

.Description
    Modules that are imported in the current session have locked DLL files and cannot be
    removed. Several code paths detect this and must surface an identical message (either
    thrown as a terminating error or, under -WhatIf, written as a warning after the
    ShouldProcess preview). This is the single source of truth for that error/message so the
    wording stays consistent across Uninstall-AWSToolsModule and Remove-LegacyModule.

.Parameter Modules
    The imported modules that block removal. The error message names each module and version.

.Example
    $PSCmdlet.ThrowTerminatingError((Get-ModuleInUseErrorRecord -Modules $imported))

.Example
    Write-Warning (Get-ModuleInUseErrorRecord -Modules $imported).Exception.Message

.Notes
    Returns an ErrorRecord with FullyQualifiedErrorId 'ModuleInUse'. Access .Exception.Message
    for the plain message when a warning (rather than a throw) is needed.
#>
function Get-ModuleInUseErrorRecord {
    [CmdletBinding()]
    [OutputType([System.Management.Automation.ErrorRecord])]
    param(
        [Parameter(Mandatory)]
        [AllowEmptyCollection()]
        [PSObject[]]$Modules
    )

    $moduleDetails = $Modules | ForEach-Object { "$($_.Name) version $($_.Version)" }
    $errorMessage = "Cannot uninstall module(s): $($moduleDetails -join ', ') because they are currently imported in this PowerShell session. The module's DLL files are locked and cannot be removed. Close this PowerShell session and start a new PowerShell session to uninstall these modules"

    return [System.Management.Automation.ErrorRecord]::new(
        ([System.InvalidOperationException]$errorMessage),
        'ModuleInUse',
        [System.Management.Automation.ErrorCategory]::InvalidOperation,
        $Modules
    )
}
