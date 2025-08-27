<#
.Synopsis
    Uninstalls AWS.Tools modules with comprehensive filtering options.

.Description
    This cmdlet removes AWS.Tools modules by deleting their directories from the file system.
    This approach is significantly faster than using Uninstall-Module. The function supports
    filtering by module name and version. AWS.Tools.Installer is excluded and must be managed 
    using Uninstall-AWSToolsInstaller.

.Parameter Name
    Specifies names of the AWS.Tools modules to uninstall. All AWS.Tools modules are uninstalled
    by default. The names can be listed either with or without the "AWS.Tools." prefix
    (i.e. "AWS.Tools.Common" or simply "Common"). 
    
    When this parameter is specified, you will be prompted to confirm the uninstallation of each
    individual module, allowing for more granular control over which modules are removed.
    
    Note: AWS.Tools.Installer cannot be specified here. Use Uninstall-AWSToolsInstaller 
    to manage the installer module.

.Parameter Version
    Specifies exact version number of the module to uninstall.

.Parameter ExceptVersion
    Specifies that you want to uninstall all of the other available versions of AWS Tools except 
    this one.

.Parameter CleanUpLegacyScope
    Runs a separate cleanup of all instances of AWSPowerShell and AWSPowerShell.NetCore 
    found in the specified scope. The acceptable values for this parameter are AllUsers and CurrentUser.

.Parameter Scope
    Specifies the installation scope to target for uninstallation.
    The acceptable values for this parameter are AllUsers and CurrentUser.
    
    The AllUsers scope targets modules in a location that is accessible to all users of the 
    computer.
    
    The CurrentUser targets modules in a location that is accessible only to the current user of 
    the computer.
    
    Default value is 'CurrentUser'. Ignored if Path parameter is specified.

.Parameter Path
    Specifies a custom path where AWS Tools modules are installed.
    When specified, modules will be uninstalled from this location instead of the standard 
    scope-based paths. This is useful for testing scenarios or custom installation locations.

.Notes
    This cmdlet uses Remove-ModuleItem to delete module directories for improved performance
    and consistent error handling.

.Example
    Uninstall-AWSToolsModule -ExceptVersion 4.0.0.0 -Confirm:$false

    This example uninstalls all versions of all AWS.Tools modules except for version 4.0.0.0.

.Example
    Uninstall-AWSToolsModule -Version 4.1.754 -Confirm:$false

    This example uninstalls only version 4.1.754 of all AWS.Tools modules.

.Example
    Uninstall-AWSToolsModule -Name EC2,S3 -Confirm:$false

    This example uninstalls all versions of only the EC2 and S3 modules, with individual
    confirmation prompts for each module.

.Example
    Uninstall-AWSToolsModule -CleanUpLegacyScope CurrentUser -Confirm:$false

    This example uninstalls all AWS.Tools modules and also removes legacy AWSPowerShell modules
    from the current user's scope.

.Example
    Uninstall-AWSToolsModule -Scope AllUsers -Confirm:$false

    This example uninstalls AWS.Tools modules from the system-wide installation location.

.Example
    Uninstall-AWSToolsModule -Path "C:\CustomModules" -Confirm:$false

    This example uninstalls AWS.Tools modules from a custom installation path.

.Example
    Uninstall-AWSToolsModule -WhatIf

    This example performs a what-if analysis to preview what modules would be removed without 
    making changes.

.Example
    Uninstall-AWSToolsModule -Scope AllUsers

    This example removes AWS.Tools modules from the system-wide location with explicit 
    confirmation prompts.
#>
function Uninstall-AWSToolsModule {
    [CmdletBinding(SupportsShouldProcess, ConfirmImpact = 'High', DefaultParameterSetName = 'Default')]
    Param(
        [Parameter()]
        [string[]]
        [Alias('ModuleName')]
        $Name,

        [Parameter(ParameterSetName = 'Version')]
        [Version]
        $Version,

        [Parameter(ParameterSetName = 'ExceptVersion')]
        [Version]
        $ExceptVersion,

        [Parameter()]
        [ValidateSet('CurrentUser', 'AllUsers')]
        [string]
        $CleanUpLegacyScope,

        [Parameter()]
        [ValidateSet('CurrentUser', 'AllUsers')]
        [string]
        $Scope = 'CurrentUser',

        [Parameter()]
        [string]
        $Path
    )

    Begin {
        $Version = Get-CleanVersion $Version
        $ExceptVersion = Get-CleanVersion $ExceptVersion

        Write-Verbose ("[$($MyInvocation.MyCommand)] ConfirmPreference=$ConfirmPreference " +
            "WhatIfPreference=$WhatIfPreference VerbosePreference=$VerbosePreference " +
            "Scope=$Scope Name=($($Name -join ','))")
            
        # Initialize progress
        Write-Progress -Activity "Uninstalling AWS.Tools modules" -Status "Initializing..." -PercentComplete 0
    }

    Process {
        $ErrorActionPreference = 'Stop'

        # Check for imported modules that would prevent uninstallation
        $importedModules = Get-Module -Name 'AWS.Tools.*', 'AWSPowerShell*' | 
            Where-Object { $_.Name -ne 'AWS.Tools.Installer' }

        # If modules are being uninstalled by name, filter imported modules to only those being uninstalled
        # When using ExceptVersion, we're uninstalling all modules except the specified version, so don't filter
        if ($Name -and -not $ExceptVersion) {
            $normalizedNames = $Name | ForEach-Object {
                if ($_.Contains('.')) {
                    $_
                }
                else {
                    "AWS.Tools.$_"
                }
            }
            
            $importedModules = $importedModules | Where-Object { 
                $moduleName = $_.Name
                $normalizedNames | Where-Object { $moduleName -eq $_ }
            }
        }

        # Check for imported modules that would prevent uninstallation
        $importedAWSToolsModules = $importedModules | Where-Object { $_.Name -like 'AWS.Tools.*' }
        $importedLegacyModules = if ($CleanUpLegacyScope) { 
            $importedModules | Where-Object { $_.Name -like 'AWSPowerShell*' } 
        } else { 
            @() 
        }
        
        # Combine all imported modules that would prevent uninstallation
        $allImportedModules = @()
        if ($importedAWSToolsModules) {
            $allImportedModules += $importedAWSToolsModules
        }
        if ($importedLegacyModules) {
            $allImportedModules += $importedLegacyModules
        }
        
        if ($allImportedModules.Count -gt 0) {
            $moduleDetails = $allImportedModules | ForEach-Object { "$($_.Name) version $($_.Version)" }
            $errorMessage = "Cannot uninstall module(s): $($moduleDetails -join ', ') because they are currently imported in this PowerShell session. The module's DLL files are locked and cannot be removed. Close this PowerShell session and start a new PowerShell session to uninstall these modules"
            
            # If -WhatIf is specified, set a flag to show a warning after ShouldProcess
            if ($WhatIfPreference) {
                # Don't return early - allow the ShouldProcess messages to be displayed
                # We'll skip the actual uninstallation later and show the warning
                $skipUninstallation = $true
                $showWarningAfterShouldProcess = $true
    } else {
        $PSCmdlet.ThrowTerminatingError(
            [System.Management.Automation.ErrorRecord]::new(
                ([System.InvalidOperationException]$errorMessage),
                'ModuleInUse',
                [System.Management.Automation.ErrorCategory]::InvalidOperation,
                $allImportedModules
            )
        )
    }
        }

        # Validate that AWS.Tools.Installer is not specified
        if ($Name) {
            $normalizedNames = $Name | ForEach-Object {
                if ($_.Contains('.')) {
                    $_
                }
                else {
                    "AWS.Tools.$_"
                }
            }
            
            $installerNames = $normalizedNames | Where-Object { $_ -eq 'AWS.Tools.Installer' }
            if ($installerNames) {
                $PSCmdlet.ThrowTerminatingError(
                    [System.Management.Automation.ErrorRecord]::new(
                        ([System.InvalidOperationException]"AWS.Tools.Installer cannot be uninstalled using Uninstall-AWSToolsModule. Use Uninstall-AWSToolsInstaller instead."),
                        'InstallerModuleSpecified',
                        [System.Management.Automation.ErrorCategory]::InvalidOperation,
                        $installerNames
                    )
                )
            }
        }
        
        Write-Progress -Activity "Uninstalling AWS.Tools modules" -Status "Checking for imported modules..." -PercentComplete 10
        
        Write-Verbose "[$($MyInvocation.MyCommand)] Searching installed modules"
        
        # Get target path - either custom Path or scope-based path
        $targetPath = if ($Path) {
            Write-Verbose "[$($MyInvocation.MyCommand)] Using specified path: $Path"
            $Path
        }
        else {
            $scopePath = Get-PSModulePath -Scope $Scope
            Write-Verbose "[$($MyInvocation.MyCommand)] Using $Scope scope path: $scopePath"
            $scopePath
        }
        
        Write-Progress -Activity "Uninstalling AWS.Tools modules" -Status "Searching for installed modules..." -PercentComplete 30
        
        # Get and filter modules (AWS.Tools.Installer is automatically excluded)
        $moduleGroups = Get-ModulesToProcess -TargetPath $targetPath -Name $Name -Version $Version -ExceptVersion $ExceptVersion
        $modules = $moduleGroups.Regular
        
        # Process AWS.Tools modules
        if ($modules) {
            $target = Format-ModuleTarget -Modules $modules -TargetPath $targetPath -ModuleType "AWS.Tools"
            
            # Add WhatIf information message
            if ($WhatIfPreference) {
                $moduleCount = $modules.Count
                $versionInfo = if ($Version) { "version $Version" } elseif ($ExceptVersion) { "all versions except $ExceptVersion" } else { "all versions" }
                Write-Host "What if: Would remove $moduleCount AWS.Tools modules ($versionInfo) from $targetPath"
            }
            
            if ($PSCmdlet.ShouldProcess($target, "Uninstall AWS.Tools modules")) {
                # Skip actual uninstallation if modules are imported and WhatIf is specified
                if (-not $skipUninstallation -or -not $WhatIfPreference) {
                    # Initialize result tracking
                    $result = [PSCustomObject]@{
                        SuccessCount = 0
                        FailureCount = 0
                        RemovedModules = @()
                        FailedModules = @()
                    }
                    
                    $totalModules = $modules.Count
                    $currentModule = 0
                    
                    # Process each module with progress reporting
                    foreach ($module in $modules) {
                        $currentModule++
                        $percentComplete = [Math]::Min([Math]::Round(($currentModule / $totalModules) * 100), 100)
                        $moduleName = $module.Name
                        $moduleVersion = $module.Version.ToString()
                        
                        # Write progress only if PowerShell version is greater than 6
                        if ($PSVersionTable.PSVersion.Major -ge 6) {
                            # Update progress bar with current module name and progress
                            Write-Progress -Activity "Uninstalling AWS.Tools modules" -Status "Processing $moduleName ($moduleVersion) - Module $currentModule of $totalModules" -PercentComplete $percentComplete
                        }
                        
                        Write-Verbose ("[$($MyInvocation.MyCommand)] Removing module: $moduleName " +
                            "version $moduleVersion")
                        
                        # If Name parameter is specified, do an additional ShouldProcess for each module
                        if ($Name) {
                            $moduleTarget = "$moduleName version $moduleVersion at $($module.ModuleBase)"
                            
                            if ($PSCmdlet.ShouldProcess($moduleTarget, "Uninstall module")) {
                                # Use Remove-ModuleItem for actual removal
                                $moduleResult = Remove-ModuleItem -Module $module -Reason "Uninstall module"
                            }
                            else {
                                # Skip this module if user declined
                                $moduleResult = [PSCustomObject]@{
                                    SuccessCount = 0
                                    FailureCount = 0
                                    RemovedModules = @()
                                    FailedModules = @()
                                }
                            }
                        }
                        else {
                            # Use Remove-ModuleItem for actual removal without additional confirmation
                            $moduleResult = Remove-ModuleItem -Module $module -Reason "Uninstall AWS.Tools modules"
                        }
                        
                        # Consolidate results
                        $result.SuccessCount += $moduleResult.SuccessCount
                        $result.FailureCount += $moduleResult.FailureCount
                        $result.RemovedModules += $moduleResult.RemovedModules
                        $result.FailedModules += $moduleResult.FailedModules
                    }
                    
                    if ($result.FailureCount -gt 0) {
                        Write-Warning ("Failed to remove $($result.FailureCount) modules: " +
                            "$($result.FailedModules -join ', ')")
                    }
                    else {
                        Write-Verbose ("[$($MyInvocation.MyCommand)] Successfully removed " +
                            "$($result.SuccessCount) AWS.Tools modules")
                        
                        # Provide removal summary via Write-Host
                        if ($result.SuccessCount -gt 0) {
                            $versionInfo = if ($Version) { "version $Version" } elseif ($ExceptVersion) { "all versions except $ExceptVersion" } else { "all versions" }
                            Write-Host "Removed $($result.SuccessCount) AWS Tools modules ($versionInfo) from $targetPath"
                        }
                    }
                }
            }
        }
        else {
            Write-Verbose ("[$($MyInvocation.MyCommand)] No AWS.Tools modules found " +
                "matching the specified criteria")
            $versionInfo = if ($Version) { "version $Version" } elseif ($ExceptVersion) { "all versions except $ExceptVersion" } else { "all versions" }
            Write-Host "Skipped uninstallation: No AWS.Tools modules found ($versionInfo) in $targetPath"
        }
        
        # Handle legacy module cleanup if requested
        if ($CleanUpLegacyScope) {
            Write-Verbose ("[$($MyInvocation.MyCommand)] Cleaning up legacy AWSPowerShell modules " +
                "in $CleanUpLegacyScope scope")
            
            $legacyPath = Get-PSModulePath -Scope $CleanUpLegacyScope
            $legacyModules = Get-LegacyModules -TargetPath $legacyPath
            
            if ($legacyModules) {
                $legacyTarget = Format-ModuleTarget -Modules $legacyModules -TargetPath $legacyPath -ModuleType "Legacy AWSPowerShell"
                
                # Add WhatIf information message for legacy modules
                if ($WhatIfPreference) {
                    $legacyModuleCount = $legacyModules.Count
                    Write-Host "What if: Would remove $legacyModuleCount legacy AWSPowerShell modules from $legacyPath"
                }
                
                if ($PSCmdlet.ShouldProcess($legacyTarget, "Clean up legacy AWSPowerShell modules")) {
                    # Skip actual uninstallation if modules are imported and WhatIf is specified
                    if (-not $skipUninstallation -or -not $WhatIfPreference) {
                        # Initialize result tracking for legacy modules
                        $legacyResult = [PSCustomObject]@{
                            SuccessCount = 0
                            FailureCount = 0
                            RemovedModules = @()
                            FailedModules = @()
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
                }
            }
            else {
                Write-Verbose ("[$($MyInvocation.MyCommand)] No legacy AWSPowerShell modules found " +
                    "in $CleanUpLegacyScope scope")
                Write-Host "Skipped legacy cleanup: No AWSPowerShell modules found in $legacyPath"
            }
        }
    }

    End {
        # Show the warning after all ShouldProcess messages
        if ($showWarningAfterShouldProcess -and $WhatIfPreference) {
            $moduleDetails = $allImportedModules | ForEach-Object { "$($_.Name) version $($_.Version)" }
            $errorMessage = "Cannot uninstall module(s): $($moduleDetails -join ', ') because they are currently imported in this PowerShell session. The module's DLL files are locked and cannot be removed. Close this PowerShell session and start a new PowerShell session to uninstall these modules"
            Write-Warning $errorMessage
        }
        
        # Complete all progress bars
        Write-Progress -Activity "Uninstalling AWS.Tools modules" -Completed
        Write-Progress -Activity "Cleaning up legacy AWSPowerShell modules" -Completed
        
        Write-Verbose "[$($MyInvocation.MyCommand)] End"
    }
}
