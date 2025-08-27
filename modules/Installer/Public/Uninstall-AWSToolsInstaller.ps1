<#
.Synopsis
    Uninstalls AWS.Tools.Installer module with comprehensive filtering options.

.Description
    This cmdlet removes AWS.Tools.Installer module by deleting its directories from the file system.
    This approach is significantly faster than using Uninstall-Module. The function supports
    filtering by version and provides proper error handling.

.Parameter Version
    Specifies exact version number of the AWS.Tools.Installer module to uninstall.

.Parameter ExceptVersion
    Specifies that you want to uninstall all of the other available versions of AWS.Tools.Installer 
    except this one.

.Parameter Scope
    Specifies the installation scope to target for uninstallation.
    The acceptable values for this parameter are AllUsers and CurrentUser.
    
    The AllUsers scope targets modules in a location that is accessible to all users of the 
    computer.
    
    The CurrentUser targets modules in a location that is accessible only to the current user of 
    the computer.
    
    Default value is 'CurrentUser'. Ignored if Path parameter is specified.

.Parameter Path
    Specifies a custom path where AWS.Tools.Installer module is installed.
    When specified, the module will be uninstalled from this location instead of the standard 
    scope-based paths. This is useful for testing scenarios or custom installation locations.

.Notes
    This cmdlet uses Remove-ModuleItem to delete module directories for improved performance
    and consistent error handling. This cmdlet is specifically for AWS.Tools.Installer and
    is separate from Uninstall-AWSToolsModule which handles AWS Tools service modules.

.Example
    Uninstall-AWSToolsInstaller -ExceptVersion "1.0.3" -Confirm:$false

    This example uninstalls all versions of AWS.Tools.Installer except for version 1.0.3.

.Example
    Uninstall-AWSToolsInstaller -Version "1.0.2" -Confirm:$false

    This example uninstalls only version 1.0.2 of AWS.Tools.Installer.

.Example
    Uninstall-AWSToolsInstaller -Scope AllUsers -Confirm:$false

    This example uninstalls AWS.Tools.Installer from the system-wide installation location.

.Example
    Uninstall-AWSToolsInstaller -Path "C:\CustomModules" -Confirm:$false

    This example uninstalls AWS.Tools.Installer from a custom installation path.

.Example
    Uninstall-AWSToolsInstaller -WhatIf

    This example performs a what-if analysis to preview what would be removed without 
    making changes.

.Example
    Uninstall-AWSToolsInstaller -Scope AllUsers

    This example removes AWS.Tools.Installer from the system-wide location with explicit 
    confirmation prompts.
#>
function Uninstall-AWSToolsInstaller {
    [CmdletBinding(SupportsShouldProcess, ConfirmImpact = 'High', DefaultParameterSetName = 'Default')]
    Param(
        [Parameter(ParameterSetName = 'Version')]
        [Version]
        $Version,

        [Parameter(ParameterSetName = 'ExceptVersion')]
        [Version]
        $ExceptVersion,

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
            "Scope=$Scope Version=$Version ExceptVersion=$ExceptVersion")
            
        # Initialize progress
        Write-Progress -Activity "Uninstalling AWS.Tools.Installer module" -Status "Initializing..." -PercentComplete 0
    }

    Process {
        $ErrorActionPreference = 'Stop'

        Write-Progress -Activity "Uninstalling AWS.Tools.Installer module" -Status "Searching for modules..." -PercentComplete 20
        
        Write-Verbose "[$($MyInvocation.MyCommand)] Searching for AWS.Tools.Installer modules"
        
        # Get target path - either custom Path or scope-based path
        $targetPath = if ($Path) {
            Write-Verbose "[$($MyInvocation.MyCommand)] Using specified path: $Path"
            $Path
        } else {
            $scopePath = Get-PSModulePath -Scope $Scope
            Write-Verbose "[$($MyInvocation.MyCommand)] Using $Scope scope path: $scopePath"
            $scopePath
        }
        
        # Get modules from target path
        Write-Progress -Activity "Uninstalling AWS.Tools.Installer module" -Status "Retrieving module information..." -PercentComplete 40
        $allModules = if ($targetPath) {
            Get-AWSToolsModule -Path $targetPath -SkipIfInvalidSignature -Name 'AWS.Tools.Installer'
        } else {
            Get-AWSToolsModule -SkipIfInvalidSignature -Name 'AWS.Tools.Installer'
        }
        
        # Filter modules by path and name (only AWS.Tools.Installer)
        $installedModules = $allModules | 
            Where-Object { 
                $_.ModuleBase.StartsWith($targetPath, [System.StringComparison]::OrdinalIgnoreCase) -and
                $_.Name -eq 'AWS.Tools.Installer'
            }

        # Filter by version if specified
        if ($Version -and $installedModules) {
            Write-Verbose "[$($MyInvocation.MyCommand)] Filtering by version: $Version"
            $installedModules = $installedModules | 
                Where-Object { (Get-CleanVersion $_.Version) -eq $Version }
        }
        
        # Filter by except version if specified
        if ($ExceptVersion -and $installedModules) {
            Write-Verbose "[$($MyInvocation.MyCommand)] Filtering by except version: $ExceptVersion"
            $installedModules = $installedModules | 
                Where-Object { (Get-CleanVersion $_.Version) -ne $ExceptVersion }
        }

        # Process AWS.Tools.Installer modules
        if ($installedModules) {
            $target = Format-ModuleTarget -Modules $installedModules -TargetPath $targetPath -ModuleType "AWS.Tools.Installer"
            
            # Add WhatIf information message
            if ($WhatIfPreference) {
                $moduleCount = $installedModules.Count
                $versionInfo = if ($Version) { "version $Version" } elseif ($ExceptVersion) { "all versions except $ExceptVersion" } else { "all versions" }
                Write-Host "What if: Would remove $moduleCount AWS.Tools.Installer modules ($versionInfo) from $targetPath"
            }
            
            if ($PSCmdlet.ShouldProcess($target, "Uninstall AWS.Tools.Installer")) {
                # Initialize result tracking
                $result = [PSCustomObject]@{
                    SuccessCount = 0
                    FailureCount = 0
                    RemovedModules = @()
                    FailedModules = @()
                }
                
                $totalModules = $installedModules.Count
                $currentModule = 0
                
                # Process each module with progress reporting
                foreach ($module in $installedModules) {
                    $currentModule++
                    $percentComplete = [Math]::Min([Math]::Round(($currentModule / $totalModules) * 100), 100)
                    $moduleName = $module.Name
                    $moduleVersion = $module.Version.ToString()
                    
                    # Update progress bar with current module name and progress
                    Write-Progress -Activity "Uninstalling AWS.Tools.Installer module" -Status "Processing $moduleName ($moduleVersion) - Module $currentModule of $totalModules" -PercentComplete $percentComplete
                    
                    Write-Verbose ("[$($MyInvocation.MyCommand)] Removing module: $moduleName " +
                        "version $moduleVersion")
                    
                    # Use Remove-ModuleItem for actual removal
                    $moduleResult = Remove-ModuleItem -Module $module -Reason "Uninstall AWS.Tools.Installer"
                    
                    # Consolidate results
                    $result.SuccessCount += $moduleResult.SuccessCount
                    $result.FailureCount += $moduleResult.FailureCount
                    $result.RemovedModules += $moduleResult.RemovedModules
                    $result.FailedModules += $moduleResult.FailedModules
                }
                
                if ($result.FailureCount -gt 0) {
                    Write-Warning ("Failed to remove $($result.FailureCount) AWS.Tools.Installer modules: " +
                        "$($result.FailedModules -join ', ')")
                }
                else {
                    Write-Verbose ("[$($MyInvocation.MyCommand)] Successfully removed " +
                        "$($result.SuccessCount) AWS.Tools.Installer modules")
                    
                    # Provide removal summary via Write-Host
                    if ($result.SuccessCount -gt 0) {
                        $versionInfo = if ($Version) { "version $Version" } elseif ($ExceptVersion) { "all versions except $ExceptVersion" } else { "all versions" }
                        Write-Host "Removed $($result.SuccessCount) AWS.Tools.Installer modules ($versionInfo) from $targetPath"
                    }
                }
            }
        } else {
            Write-Verbose ("[$($MyInvocation.MyCommand)] No AWS.Tools.Installer modules found " +
                "matching the specified criteria")
            $versionInfo = if ($Version) { "version $Version" } elseif ($ExceptVersion) { "all versions except $ExceptVersion" } else { "all versions" }
            Write-Host "Skipped uninstallation: No AWS.Tools.Installer modules found ($versionInfo) in $targetPath"
        }
    }

    End {
        # Complete the progress bar
        Write-Progress -Activity "Uninstalling AWS.Tools.Installer module" -Completed
        
        Write-Verbose "[$($MyInvocation.MyCommand)] End"
    }
}
