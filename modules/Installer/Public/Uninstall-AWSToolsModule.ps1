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

.Parameter MinimumVersion
    Specifies the minimum version of the modules to uninstall. This parameter is deprecated 
    and should no longer be used as it will be removed in the next major version.

.Parameter MaximumVersion
    Specifies the maximum version of the modules to uninstall. This parameter is deprecated 
    and should no longer be used as it will be removed in the next major version.

.Parameter Force
    This parameter is deprecated and should no longer be used as it will be removed in the next major version. Use -ConfirmImpact:False to run without asking for user confirmation.

.Parameter ExceptVersion
    Specifies that you want to uninstall all of the other available versions of AWS Tools except 
    this one.
    
    This parameter is deprecated in favor of ExceptModules. It will be removed in a future major version.

.Parameter ExceptModules
    Specifies an array of hashtables containing module names and versions to exclude from 
    uninstallation. Each hashtable must contain 'Name' and 'Version' keys.
    
    This parameter provides more granular control over which specific module versions to preserve 
    during cleanup operations.
    
    Each hashtable must contain 'Name' and 'Version' keys:
    @{ Name = 'AWS.Tools.Common'; Version = '5.0.8' }
    @{ Name = 'AWS.Tools.S3'; Version = '5.0.8' }
    
    Example: Uninstall-AWSToolsModule -ExceptModules @(
        @{ Name = 'AWS.Tools.Common'; Version = '5.0.8' }
        @{ Name = 'AWS.Tools.S3'; Version = '5.0.8' }
    )

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
    Uninstall-AWSToolsModule -ExceptModules @(
        @{ Name = 'AWS.Tools.Common'; Version = '5.0.8' }
        @{ Name = 'AWS.Tools.S3'; Version = '5.0.8' }
    ) -Confirm:$false

    This example provides granular control over cleanup, preserving specific versions of 
    AWS.Tools.Common and AWS.Tools.S3 while uninstalling all other modules.

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
        [string]
        $Version,

        [Parameter(ParameterSetName = 'Version')]
        [Version]
        $MinimumVersion,

        [Parameter(ParameterSetName = 'Version')]
        [Version]
        $MaximumVersion,

        [Parameter(ParameterSetName = 'ExceptVersion')]
        [string]
        $ExceptVersion,

        [Parameter(ParameterSetName = 'ExceptModules')]
        [hashtable[]]
        $ExceptModules,

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
        $Path,

        [Parameter()]
        [switch]
        $Force,

        [Parameter(ParameterSetName = 'Version')]
        [Parameter(ParameterSetName = 'ExceptVersion')]
        [Alias('AllowPrerelease')]
        [switch]
        $Prerelease
    )

    Begin {
        # Validate prerelease parameter usage for Version and ExceptVersion
        if ($PSCmdlet.ParameterSetName -eq 'Version' -or $PSCmdlet.ParameterSetName -eq 'ExceptVersion') {
            $versionToValidate = if ($PSCmdlet.ParameterSetName -eq 'Version') { $Version } else { $ExceptVersion }
            if ($versionToValidate) {
                try {
                    $versionFlags = Test-PrereleaseParameterValidation -Version $versionToValidate -Prerelease $Prerelease -ModuleName 'AWS.Tools'
                }
                catch {
                    $PSCmdlet.ThrowTerminatingError($_)
                }
            }
        }
        
        # Reject wildcards in Version and ExceptVersion parameters
        if ($Version -and $Version -like '*`**') {
            $PSCmdlet.ThrowTerminatingError(
                [System.Management.Automation.ErrorRecord]::new(
                    ([System.ArgumentException]"Wildcard versions are not supported for uninstall operations. Please specify an exact version (e.g., 5.0.151) or use the ExceptVersion parameter to uninstall all versions except a specific one."),
                    'WildcardNotSupported',
                    [System.Management.Automation.ErrorCategory]::InvalidArgument,
                    $Version
                )
            )
        }
        
        if ($ExceptVersion -and $ExceptVersion -like '*`**') {
            $PSCmdlet.ThrowTerminatingError(
                [System.Management.Automation.ErrorRecord]::new(
                    ([System.ArgumentException]"Wildcard versions are not supported in the ExceptVersion parameter. Please specify an exact version (e.g., 5.0.151)."),
                    'WildcardNotSupported',
                    [System.Management.Automation.ErrorCategory]::InvalidArgument,
                    $ExceptVersion
                )
            )
        }
        
        # Only call Get-CleanVersion on non-semver strings (Get-CleanVersion expects [Version] type)
        # For semver strings (e.g., "5.0.0-preview001"), keep them as-is
        if ($Version -and $Version -notmatch '^\d+\.\d+\.\d+-.+$') {
            $Version = Get-CleanVersion $Version
        }
        $MinimumVersion = Get-CleanVersion $MinimumVersion
        $MaximumVersion = Get-CleanVersion $MaximumVersion
        if ($ExceptVersion -and $ExceptVersion -notmatch '^\d+\.\d+\.\d+-.+$') {
            $ExceptVersion = Get-CleanVersion $ExceptVersion
        }

        # Deprecation warnings for restored parameters
        if ($MinimumVersion) {
            Write-Warning "The MinimumVersion parameter is deprecated and should no longer be used as it will be removed in the next major version."
        }
        
        if ($MaximumVersion) {
            Write-Warning "The MaximumVersion parameter is deprecated and should no longer be used as it will be removed in the next major version."
        }
        
        # Deprecation warning for ExceptVersion parameter
        if ($ExceptVersion) {
            Write-Warning "The ExceptVersion parameter is deprecated in favor of ExceptModules. It will be removed in a future major version."
        }
        
        # Deprecation warnings for ignored legacy parameters
        if ($Force) {
            Write-Warning "The Force parameter is deprecated and should no longer be used as it will be removed in the next major version."
        }

        # Validate ExceptModules parameter
        if ($ExceptModules) {
            if ($ExceptModules.Count -eq 0) {
                $PSCmdlet.ThrowTerminatingError(
                    [System.Management.Automation.ErrorRecord]::new(
                        ([System.ArgumentException]"ExceptModules parameter cannot be an empty array."),
                        'EmptyExceptModules',
                        [System.Management.Automation.ErrorCategory]::InvalidArgument,
                        $ExceptModules
                    )
                )
            }

            foreach ($moduleInfo in $ExceptModules) {
                # Validate hashtable structure
                if (-not $moduleInfo.ContainsKey('Name') -or -not $moduleInfo.ContainsKey('Version')) {
                    $PSCmdlet.ThrowTerminatingError(
                        [System.Management.Automation.ErrorRecord]::new(
                            ([System.ArgumentException]"Invalid hashtable structure in ExceptModules. Each hashtable must contain 'Name' and 'Version' keys. Example: @{ Name = 'AWS.Tools.S3'; Version = '5.0.8' }"),
                            'InvalidExceptModulesStructure',
                            [System.Management.Automation.ErrorCategory]::InvalidArgument,
                            $moduleInfo
                        )
                    )
                }

                # Validate module name format
                $moduleName = $moduleInfo['Name']
                if ($moduleName -notlike 'AWS.Tools*') {
                    $PSCmdlet.ThrowTerminatingError(
                        [System.Management.Automation.ErrorRecord]::new(
                            ([System.ArgumentException]"Invalid module name '$moduleName' in ExceptModules. Module names must start with 'AWS.Tools'"),
                            'InvalidExceptModulesName',
                            [System.Management.Automation.ErrorCategory]::InvalidArgument,
                            $moduleName
                        )
                    )
                }

                # Validate version format (support both standard versions and semver with prerelease tags)
                $moduleVersion = $moduleInfo['Version']
                try {
                    # Check if it's a semver string with prerelease tag
                    if ($moduleVersion -match '^(\d+\.\d+\.\d+)-.+$') {
                        # Validate the base version part
                        [void][Version]::Parse($Matches[1])
                    }
                    else {
                        # Standard version validation
                        [void][Version]::Parse($moduleVersion)
                    }
                }
                catch {
                    $PSCmdlet.ThrowTerminatingError(
                        [System.Management.Automation.ErrorRecord]::new(
                            ([System.ArgumentException]"Invalid version '$moduleVersion' for module '$moduleName' in ExceptModules. Version must be a valid semantic version."),
                            'InvalidExceptModulesVersion',
                            [System.Management.Automation.ErrorCategory]::InvalidArgument,
                            $moduleVersion
                        )
                    )
                }
            }
        }

        # Parameter validation for version ranges
        if ($MinimumVersion -and $MaximumVersion -and $MinimumVersion -gt $MaximumVersion) {
            $PSCmdlet.ThrowTerminatingError(
                [System.Management.Automation.ErrorRecord]::new(
                    ([System.ArgumentException]"Parameter MinimumVersion ($MinimumVersion) cannot be greater than MaximumVersion ($MaximumVersion)."),
                    'InvalidVersionRange',
                    [System.Management.Automation.ErrorCategory]::InvalidArgument,
                    $MinimumVersion
                )
            )
        }

        Write-Verbose ("[$($MyInvocation.MyCommand)] ConfirmPreference=$ConfirmPreference " +
            "WhatIfPreference=$WhatIfPreference VerbosePreference=$VerbosePreference " +
            "Scope=$Scope Name=($($Name -join ',')) MinimumVersion=$MinimumVersion MaximumVersion=$MaximumVersion")
            
        # Initialize progress
        Write-Progress -Activity "Uninstalling AWS.Tools modules" -Status "Initializing..." -PercentComplete 0
    }

    Process {
        $ErrorActionPreference = 'Stop'

        # Check for imported modules that would prevent uninstallation. Get-Module without
        # -ListAvailable is fast (only loaded modules in this session).
        $importedModules = Get-Module -Name 'AWS.Tools*', 'AWSPowerShell*' |
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
        $importedAWSToolsModules = $importedModules | Where-Object { $_.Name -like 'AWS.Tools*' }
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
        
        # Get and filter modules (AWS.Tools.Installer is automatically excluded). This call
        # walks the target path on disk — typically the slowest step in uninstall.
        $moduleGroups = Get-ModulesToProcess -TargetPath $targetPath -Name $Name -Version $Version -ExceptVersion $ExceptVersion -ExceptModules $ExceptModules
        $modules = $moduleGroups.Regular

        # Apply MinimumVersion and MaximumVersion filtering if specified
        if ($MinimumVersion -and $modules) {
            $modules = @($modules | Where-Object { (Get-CleanVersion $_.Version) -ge $MinimumVersion })
            Write-Verbose ("[$($MyInvocation.MyCommand)] Filtered modules by MinimumVersion $($MinimumVersion): $($modules.Count) modules remain")
        }
        if ($MaximumVersion -and $modules) {
            $modules = @($modules | Where-Object { (Get-CleanVersion $_.Version) -le $MaximumVersion })
            Write-Verbose ("[$($MyInvocation.MyCommand)] Filtered modules by MaximumVersion $($MaximumVersion): $($modules.Count) modules remain")
        }
        
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

                    if ($Name) {
                        # Per-module path: -Name was specified, so the user expects per-module
                        # ShouldProcess prompts. Keep Remove-ModuleItem (sequential, with retry).
                        $totalModules = $modules.Count
                        $currentModule = 0
                        foreach ($module in $modules) {
                            $currentModule++
                            $percentComplete = [Math]::Min([Math]::Round(($currentModule / $totalModules) * 100), 100)
                            $moduleName = $module.Name
                            $moduleVersion = Get-ModuleVersionString -Module $module
                            if ($PSVersionTable.PSVersion.Major -ge 6) {
                                Write-Progress -Activity "Uninstalling AWS.Tools modules" -Status "Processing $moduleName ($moduleVersion) - Module $currentModule of $totalModules" -PercentComplete $percentComplete
                            }
                            Write-Verbose ("[$($MyInvocation.MyCommand)] Removing module: $moduleName " +
                                "version $moduleVersion")

                            $moduleTarget = "$moduleName version $moduleVersion at $($module.ModuleBase)"
                            if ($PSCmdlet.ShouldProcess($moduleTarget, "Uninstall module")) {
                                $moduleResult = Remove-ModuleItem -Module $module -Reason "Uninstall module"
                            }
                            else {
                                $moduleResult = [PSCustomObject]@{
                                    SuccessCount = 0
                                    FailureCount = 0
                                    RemovedModules = @()
                                    FailedModules = @()
                                }
                            }
                            $result.SuccessCount += $moduleResult.SuccessCount
                            $result.FailureCount += $moduleResult.FailureCount
                            $result.RemovedModules += $moduleResult.RemovedModules
                            $result.FailedModules += $moduleResult.FailedModules
                        }
                    }
                    else {
                        # Bulk path: no per-module ShouldProcess prompts needed (top-level
                        # ShouldProcess already approved). Hand the full path list to the
                        # precompiled DLL for parallel deletion. Per user direction, do not
                        # report per-module success on this path; only failures are reported.
                        Write-Verbose ("[$($MyInvocation.MyCommand)] Bulk parallel delete via " +
                            "[Amazon.PowerShell.Installer.ModuleInstaller]::DeleteDirectoriesParallel")
                        Write-Progress -Activity "Uninstalling AWS.Tools modules" -Status "Removing $($modules.Count) modules in parallel..." -PercentComplete 50

                        [string[]]$paths = @($modules | ForEach-Object { $_.ModuleBase })
                        $pathToModule = @{}
                        foreach ($m in $modules) { $pathToModule[$m.ModuleBase] = $m }

                        # Best-effort: PS 7.4+ exposes $PSCmdlet.StoppingToken; older shells
                        # (notably Windows PowerShell 5.1) do not.
                        $ct = if ($PSCmdlet.PSObject.Properties['StoppingToken']) {
                            $PSCmdlet.StoppingToken
                        } else {
                            [System.Threading.CancellationToken]::None
                        }
                        $failedPaths = [Amazon.PowerShell.Installer.ModuleInstaller]::DeleteDirectoriesParallel($paths, $ct)

                        $result.SuccessCount = $paths.Count - $failedPaths.Count
                        $result.FailureCount = $failedPaths.Count
                        $result.FailedModules = @($failedPaths | ForEach-Object {
                            $m = $pathToModule[$_]
                            if ($m) { "$($m.Name) ($(Get-ModuleVersionString -Module $m))" } else { $_ }
                        })
                        # RemovedModules left empty on bulk path per user direction (too noisy).
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
            if ($ExceptModules -or $ExceptVersion) {
                Write-Host "Skipped uninstallation: No other AWS.Tools module versions found to remove in $targetPath"
            }
            else {
                $versionInfo = if ($Version) { "version $Version" } else { "all versions" }
                Write-Host "Skipped uninstallation: No AWS.Tools modules found ($versionInfo) in $targetPath"
            }
        }
        
        # Handle legacy module cleanup if requested
        if ($CleanUpLegacyScope) {
            Write-Verbose ("[$($MyInvocation.MyCommand)] Cleaning up legacy AWSPowerShell modules " +
                "in $CleanUpLegacyScope scope")
            
            $legacyPath = Get-PSModulePath -Scope $CleanUpLegacyScope
            # @(...) because return unrolls a one-element array to a scalar (no .Count on 5.1).
            $legacyModules = @(Get-LegacyModules -TargetPath $legacyPath)
            
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
