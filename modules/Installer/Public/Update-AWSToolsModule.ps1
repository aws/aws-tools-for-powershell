<#
.Synopsis
    Updates all installed AWS Tools for PowerShell modules to the latest version.

    Note: Users are recommended to use Install-AWSToolsModule which supports installing all modules including
    new modules as they are released. Use Update-AWSToolsModule for a simple invocation that intentionally only updates
    previously installed modules.

    A warning will be output for any module that is not available in the version that is specified or resolved. Such modules
    will still be removed if the -Cleanup parameter switch is specified..

.Description
    This cmdlet updates all installed AWS Tools for PowerShell modules to the latest version
    or a specified version. It identifies installed modules and updates only those modules,
    downloading the AWS.Tools.zip file and extracting only the necessary modules.
    Modules that are not found in the zip file will trigger warnings.
    
    Note: AWS.Tools.Installer is excluded from this cmdlet and must be managed separately 
    using Install-AWSToolsInstaller and Uninstall-AWSToolsInstaller.

.Parameter Version
    Specifies an exact version to update to. Latest version is used by default.

.Parameter Cleanup
    Switch that uninstalls other versions of installed AWS Tools modules after successful update
    like when using <code>Uninstall-AWSToolsModule -ExceptVersion ...</code>
    
    Otherwise, by default, other versions are preserved. 
    
    Please note that ALL AWS Tools modules (except installer) will be uninstalled even when 
    only specific modules were updated. 

.Parameter CleanUpLegacyModuleScope
    Runs a separate cleanup of all instances of AWSPowerShell and AWSPowerShell.NetCore 
    found in the specified scope. Warns on failure. The acceptable values for this 
    parameter are AllUsers and CurrentUser.

.Parameter Scope
    Specifies the installation scope of the module as well as scope for module cleanup.
    The acceptable values for this parameter are AllUsers and CurrentUser.
    
    The AllUsers scope installs modules in a location that is accessible to all users of the 
    computer.
    
    The CurrentUser installs modules in a location that is accessible only to the current user 
    of the computer.
    
    Default value is 'CurrentUser'.

.Parameter SourceZipPath
    Alternative installation from a copy of AWS.Tools.zip to support offline/air-gapped 
    environments.

.Parameter SourceHashPath
    Local path to SHA512 hash file for validating the integrity of a local zip file specified with
    SourceZipPath. When provided, uses this file for validation instead of downloading the hash file.

.Parameter SkipIntegrityCheck
    Switch that bypasses SHA512 validation when specified. By default, SHA512 validation is performed
    to ensure the integrity of downloaded files.

.Parameter Path
    Specifies a custom installation path for the modules.

.Parameter Force
    Forces update even if the same version is already installed. Without this parameter, 
    update is skipped if the target version already exists.

.Parameter Timeout
    Specifies the timeout in seconds for downloading the AWS.Tools.zip file. Default is 300 
    seconds (5 minutes). Increase this value for slower internet connections or when downloading 
    large files.

.Notes
    This cmdlet sources modules from the AWS CloudFront-hosted AWS.Tools.zip file for improved 
    speed and reliability. There is no support for updating AWSPowerShell or 
    AWSPowerShell.NetCore as these are legacy modules. AWS.Tools.Installer is also excluded 
    and must be managed using Install-AWSToolsInstaller.

.Example
    Update-AWSToolsModule

    This example updates all installed AWS Tools modules to the latest version.

.Example
    Update-AWSToolsModule -Cleanup -Confirm:$false

    This example updates all installed AWS Tools modules to the latest version and removes 
    all non-latest AWS Tools for PowerShell modules.

.Example
    Update-AWSToolsModule -Version 4.1.754 -Cleanup

    This example updates all installed AWS Tools modules to version 4.1.754 and removes 
    all other versions.

.Example
    Update-AWSToolsModule -Force

    This example forces update of currently-installed AWS Tools modules even if the same version is already 
    installed.

.Example
    Update-AWSToolsModule -Scope AllUsers

    This example updates AWS Tools modules in the system-wide location accessible to all users.

.Example
    Update-AWSToolsModule -SourceZipPath "C:\Downloads\AWS.Tools.zip"

    This example updates AWS Tools modules from a local zip file for offline scenarios.

.Example
    Update-AWSToolsModule -Path "C:\DevModules"

    This example updates AWS Tools modules in a custom directory for testing or development.

.Example
    Update-AWSToolsModule -WhatIf

    This example performs a what-if analysis to preview what would be updated without making 
    changes.

.Example
    Update-AWSToolsModule -CleanUpLegacyModuleScope CurrentUser -Confirm:$false

    This example updates AWS Tools modules and cleans up legacy AWSPowerShell modules from the 
    current user scope.
#>
function Update-AWSToolsModule {
    [CmdletBinding(SupportsShouldProcess, ConfirmImpact = 'Medium', DefaultParameterSetName = 'ManagedCloudFront')]
    Param(
        [Parameter(ParameterSetName = 'ManagedCloudFront')]
        [string]
        $Version,

        [Parameter()]
        [Switch]
        $Cleanup,

        [Parameter()]
        [ValidateSet('CurrentUser', 'AllUsers')]
        [string]
        $CleanUpLegacyModuleScope,

        [Parameter()]
        [ValidateSet('CurrentUser', 'AllUsers')]
        [string]
        $Scope = 'CurrentUser',

        [Parameter(ParameterSetName = 'SourceZipPath', Mandatory)]
        [string]
        $SourceZipPath,
        
        [Parameter(ParameterSetName = 'SourceZipPath')]
        [string]
        $SourceHashPath,
        
        [Parameter()]
        [Switch]
        $SkipIntegrityCheck,

        [Parameter()]
        [string]
        $Path,

        [Parameter()]
        [Switch]
        $Force,

        [Parameter()]
        [int]
        $Timeout = $script:Config.network.DefaultTimeout
    )

    Begin {
        # Initialize progress bar with ID to prevent it from being overridden by other progress bars
        Write-Progress -Id 1 -Activity "Update-AWSToolsModule" -Status "Initializing..." -PercentComplete 0
        
        # Resolve version using parameter set logic
        if ($PSCmdlet.ParameterSetName -eq 'ManagedCloudFront') {
            $Version = Resolve-AWSToolsVersion -Name 'AWS.Tools' -Version $Version -Timeout $Timeout
            $targetVersionToInstall = if ($Version) { $Version.ToString() } else { "latest" }
        }
        else {
            # SourceZipPath - version will be determined from zip contents during installation
            $targetVersionToInstall = "from local zip file"
        }
        
        Write-Verbose ("[$($MyInvocation.MyCommand)] ParameterSetName=$($PSCmdlet.ParameterSetName) " +
            "ConfirmPreference=$ConfirmPreference WhatIfPreference=$WhatIfPreference " +
            "VerbosePreference=$VerbosePreference Version=$Version Cleanup=$Cleanup")
    }

    Process {
        $ErrorActionPreference = 'Stop'

        try {
            # Update progress - starting version check and preparation
            Write-Progress -Id 1 -Activity "Update-AWSToolsModule" -Status "Getting installed modules..." -PercentComplete 10
            
            # Get target installation path
            if ($Path) {
                $targetPath = $Path
                Write-Verbose ("[$($MyInvocation.MyCommand)] Using specified installation path: " +
                    "$targetPath")
            }
            else {
                $targetPath = Get-PSModulePath -Scope $Scope
                Write-Verbose ("[$($MyInvocation.MyCommand)] Using $Scope scope installation " +
                    "path: $targetPath")
            }
            
            # Get installed AWS.Tools modules (excluding installer)
            $getAWSToolsModuleParams = @{
                Name = 'AWS.Tools'
            }
            if ($Path) {
                $getAWSToolsModuleParams.Path = $Path
            }
            
            $installedModules = Get-AWSToolsModule @getAWSToolsModuleParams
            
            if (-not $installedModules -or $installedModules.Count -eq 0) {
                Write-Host "No AWS.Tools modules found to update. Use Install-AWSToolsModule to install AWS.Tools modules."
                return
            }
            
            # Get unique module names without regard for version
            $moduleNames = $installedModules | Select-Object -ExpandProperty Name -Unique
            
            Write-Verbose ("[$($MyInvocation.MyCommand)] Found $($moduleNames.Count) installed AWS.Tools modules to update")
            
            # Inform users about the number of modules being updated and that Install-AWSToolsModule is needed for new modules
            Write-Host "Updating $($moduleNames.Count) installed AWS.Tools modules. Note: Use Install-AWSToolsModule to install new AWS modules that may have been released since your last update."
            
            # Build target description for ShouldProcess
            if ($PSCmdlet.ParameterSetName -eq 'ManagedCloudFront') {
                $versionText = " to version $targetVersionToInstall"
            }
            else {
                $versionText = " from local zip file"
            }
            
            $moduleText = "all installed AWS Tools modules"
            
            $target = "$moduleText$versionText in $targetPath"
            
            # Add WhatIf information message
            if ($WhatIfPreference) {
                Write-Host "What if: Would update $moduleText$versionText in $targetPath"
            }
            
            # Initialize installedVersion variable
            $installedVersion = $null
            
            # Prepare parameters for Install-AWSToolsModule
            $installParams = @{
                Name = $moduleNames
            }
            
            # Add common parameters
            if ($PSBoundParameters.ContainsKey('Cleanup')) {
                $installParams.Cleanup = $Cleanup
            }
            
            if ($PSBoundParameters.ContainsKey('CleanUpLegacyModuleScope')) {
                $installParams.CleanUpLegacyModuleScope = $CleanUpLegacyModuleScope
            }
            
            if ($PSBoundParameters.ContainsKey('Scope')) {
                $installParams.Scope = $Scope
            }
            
            if ($PSBoundParameters.ContainsKey('Path')) {
                $installParams.Path = $Path
            }
            
            if ($PSBoundParameters.ContainsKey('Force')) {
                $installParams.Force = $Force
            }
            
            if ($PSBoundParameters.ContainsKey('Timeout')) {
                $installParams.Timeout = $Timeout
            }
            
            if ($PSBoundParameters.ContainsKey('SkipIntegrityCheck')) {
                $installParams.SkipIntegrityCheck = $SkipIntegrityCheck
            }
            
            # Add parameter set specific parameters
            if ($PSCmdlet.ParameterSetName -eq 'ManagedCloudFront' -and $PSBoundParameters.ContainsKey('Version')) {
                $installParams.Version = $Version
            }
            
            if ($PSCmdlet.ParameterSetName -eq 'SourceZipPath') {
                $installParams.SourceZipPath = $SourceZipPath
                
                if ($PSBoundParameters.ContainsKey('SourceHashPath')) {
                    $installParams.SourceHashPath = $SourceHashPath
                }
            }
            
            # Always pass WhatIf and Confirm preferences
            if ($PSBoundParameters.ContainsKey('WhatIf')) {
                $installParams.WhatIf = $WhatIfPreference
            }
            
            if ($PSBoundParameters.ContainsKey('Confirm')) {
                $installParams.Confirm = $ConfirmPreference -ne 'None'
            }
            
            # Always call Install-AWSToolsModule, but ShouldProcess will control actual execution
            # through the -WhatIf parameter that's already been added to $installParams
            Write-Verbose ("[$($MyInvocation.MyCommand)] Calling Install-AWSToolsModule with " +
                "parameters: $($installParams.Keys -join ', ')")
            
            # This will display the ShouldProcess prompt if -WhatIf is not specified
            # If -WhatIf is specified, it will be passed to Install-AWSToolsModule
            $PSCmdlet.ShouldProcess($target, "Update AWS Tools modules")
            
            # Always call Install-AWSToolsModule - the -WhatIf parameter will be passed through
            # and will control whether Install-AWSToolsModule actually makes changes
            Install-AWSToolsModule @installParams
        }
        catch {
            $PSCmdlet.ThrowTerminatingError($_)
        }
    }

    End {
        # Complete progress bar
        Write-Progress -Id 1 -Activity "Update-AWSToolsModule" -Completed
        
        Write-Verbose "[$($MyInvocation.MyCommand)] End"
    }
}
