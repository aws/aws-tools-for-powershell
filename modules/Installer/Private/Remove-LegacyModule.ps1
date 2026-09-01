<#
.Synopsis
    Removes legacy AWSPowerShell modules from a single scope.

.Description
    Discovers and removes legacy AWSPowerShell and AWSPowerShell.NetCore modules in the
    specified scope. This is the single source of truth for legacy cleanup, shared by
    Uninstall-AWSToolsModule (its -CleanUpLegacyScope path) and Install-AWSToolsModule
    (its -CleanUpLegacyModuleScope path).

    The imported-module guard here is scoped to AWSPowerShell* only and never considers
    AWS.Tools modules, so a loaded AWS.Tools module (e.g. AWS.Tools.Common) does not block
    legacy cleanup.

.Parameter Scope
    The installation scope to clean up. Acceptable values are 'CurrentUser' and 'AllUsers'.

.Example
    Remove-LegacyModule -Scope CurrentUser

    Removes all legacy AWSPowerShell modules found in the current user's module scope.

.Notes
    Supports ShouldProcess (WhatIf/Confirm), which is inherited from the calling cmdlet.
#>
function Remove-LegacyModule {
    # ConfirmImpact High matches the original enclosing Uninstall-AWSToolsModule so
    # legacy cleanup still prompts for confirmation interactively (module deletion is
    # destructive); callers pass -Confirm:$false to run unattended.
    [CmdletBinding(SupportsShouldProcess, ConfirmImpact = 'High')]
    param(
        [Parameter(Mandatory)]
        [ValidateSet('CurrentUser', 'AllUsers')]
        [string]$Scope
    )

    Process {
        Write-Verbose ("[$($MyInvocation.MyCommand)] Cleaning up legacy AWSPowerShell modules " +
            "in $Scope scope")

        $legacyPath = Get-PSModulePath -Scope $Scope
        # @(...) because return unrolls a one-element array to a scalar (no .Count on 5.1).
        $legacyModules = @(Get-LegacyModules -TargetPath $legacyPath)

        if (-not $legacyModules) {
            Write-Verbose ("[$($MyInvocation.MyCommand)] No legacy AWSPowerShell modules found " +
                "in $Scope scope")
            Write-Host "Skipped legacy cleanup: No AWSPowerShell modules found in $legacyPath"
            return
        }

        # Block removal of legacy modules that are imported in this session (their DLL files
        # are locked). Scope this guard to AWSPowerShell* only (never AWS.Tools) so a loaded
        # AWS.Tools module does not fail legacy cleanup with modules we were never going to touch.
        $importedLegacyModules = @(Get-Module -Name 'AWSPowerShell*')
        $showWarningAfterShouldProcess = $false
        if ($importedLegacyModules.Count -gt 0) {
            if ($WhatIfPreference) {
                # Don't return early - allow the ShouldProcess preview, then warn afterwards.
                $showWarningAfterShouldProcess = $true
            }
            else {
                $PSCmdlet.ThrowTerminatingError((Get-ModuleInUseErrorRecord -Modules $importedLegacyModules))
            }
        }

        $legacyTarget = Format-ModuleTarget -Modules $legacyModules -TargetPath $legacyPath -ModuleType "Legacy AWSPowerShell"

        # Add WhatIf information message for legacy modules
        if ($WhatIfPreference) {
            Write-Host "What if: Would remove $($legacyModules.Count) legacy AWSPowerShell modules from $legacyPath"
        }

        if ($PSCmdlet.ShouldProcess($legacyTarget, "Clean up legacy AWSPowerShell modules")) {
            # Initialize result tracking for legacy modules
            $legacyResult = [PSCustomObject]@{
                SuccessCount   = 0
                FailureCount   = 0
                RemovedModules = @()
                FailedModules  = @()
            }

            $totalLegacyModules = $legacyModules.Count
            $currentLegacyModule = 0

            # Process each legacy module with progress reporting
            foreach ($module in $legacyModules) {
                $currentLegacyModule++
                $percentComplete = [Math]::Min([Math]::Round(($currentLegacyModule / $totalLegacyModules) * 100), 100)
                $moduleName = $module.Name
                $moduleVersion = $module.Version.ToString()

                # Update progress bar with current module name and progress
                Write-Progress -Activity "Cleaning up legacy AWSPowerShell modules" -Status "Processing $moduleName ($moduleVersion) - Module $currentLegacyModule of $totalLegacyModules" -PercentComplete $percentComplete

                Write-Verbose ("[$($MyInvocation.MyCommand)] Removing legacy module: $moduleName " +
                    "version $moduleVersion")

                # Use Remove-ModuleItem for actual removal
                $moduleResult = Remove-ModuleItem -Module $module -Reason "Clean up legacy AWSPowerShell modules"

                # Consolidate results
                $legacyResult.SuccessCount += $moduleResult.SuccessCount
                $legacyResult.FailureCount += $moduleResult.FailureCount
                $legacyResult.RemovedModules += $moduleResult.RemovedModules
                $legacyResult.FailedModules += $moduleResult.FailedModules
            }

            if ($legacyResult.FailureCount -gt 0) {
                Write-Warning ("Failed to remove $($legacyResult.FailureCount) legacy modules: " +
                    "$($legacyResult.FailedModules -join ', ')")
            }
            elseif ($legacyResult.SuccessCount -gt 0) {
                # Provide legacy removal summary via Write-Host
                Write-Host "Removed $($legacyResult.SuccessCount) legacy AWSPowerShell modules from $legacyPath"
            }
        }

        # Show the imported-module warning after the ShouldProcess preview (WhatIf only).
        if ($showWarningAfterShouldProcess -and $WhatIfPreference) {
            Write-Warning (Get-ModuleInUseErrorRecord -Modules $importedLegacyModules).Exception.Message
        }

        Write-Progress -Activity "Cleaning up legacy AWSPowerShell modules" -Completed
    }
}
