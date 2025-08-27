<#
.Synopsis
    Installs AWS Tools for PowerShell modules and cleans up previous versions.

.Description
    This cmdlet installs AWS Tools for PowerShell modules from the AWS CloudFront-hosted 
    AWS.Tools.zip file. By default, it installs all available AWS Tools modules to the 
    latest version. Installation is skipped if the target version of AWS.Tools.Common is
    already installed unless Force is specified. 
    
    Note: AWS.Tools.Installer is excluded from this cmdlet and must be managed separately 
    using Install-AWSToolsInstaller and Uninstall-AWSToolsInstaller.

.Parameter Name
    Specifies names of the AWS.Tools modules to install. All AWS Tools for PowerShell 
    modules are installed by default. The names can be listed either with or without the 
    "AWS.Tools." prefix (i.e. "AWS.Tools.Common" or simply "Common"). 
    
    Note: AWS.Tools.Common is automatically included when specific modules are requested,
    as it is required for all AWS.Tools modules to function properly.
    
    Note: AWS.Tools.Installer cannot be specified here. Use Install-AWSToolsInstaller 
    to manage the installer module.

.Parameter Version
    Specifies an exact version to install. Latest version is installed by default.

.Parameter Cleanup
    Switch that uninstalls other versions of installed AWS Tools modules after successful installation
    like when using <code>Uninstall-AWSToolsModule -ExceptVersion ...</code>
    
    Otherwise, by default, other versions are preserved. 
    
    Please note that ALL AWS Tools modules (except installer) will be cleaned up even when 
    the Name parameter was use to selectively install modules. 

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
    Alternative installation from a local copy of AWS.Tools.zip to support offline/air-gapped 
    environments.

.Parameter SourceHashPath
    Local path to SHA512 hash file for validating the integrity of a local zip file specified with
    SourceZipPath. When provided, uses this file for validation instead of downloading the hash file.

.Parameter SkipIntegrityCheck
    Switch that bypasses SHA512 validation when specified. By default, SHA512 validation is performed
    to ensure the integrity of downloaded files.

.Parameter Force
    Forces installation even if the same version is already installed. Without this parameter, 
    installation is skipped if the target version already exists.

.Parameter Timeout
    Specifies the timeout in seconds for downloading the AWS.Tools.zip file. Default is 300 
    seconds (5 minutes). Increase this value for slower internet connections or when downloading 
    large files.

.Notes
    This cmdlet sources modules from the AWS CloudFront-hosted AWS.Tools.zip file for improved 
    speed and reliability. There is no support for installing AWSPowerShell or 
    AWSPowerShell.NetCore as these are legacy modules. AWS.Tools.Installer is also excluded 
    and must be managed using Install-AWSToolsInstaller.

    This cmdlet does not support installation from a PSRepository including PSGallery but examples
    to accomplish this using alternative cmdlets are provided below.

.Example
    Install-AWSToolsModule

    This example installs all AWS Tools modules from CloudFront-hosted AWS.Tools.zip.

.Example
    Install-AWSToolsModule -Cleanup -Confirm:$false

    This example installs all AWS Tools modules from CloudFront-hosted AWS.Tools.zip and removes 
    all non-latest AWS Tools for PowerShell modules without requiring interactive confirmation.

.Example
    Install-AWSToolsModule -Version 4.1.754 -Cleanup

    This example installs version 4.1.754 of all AWS Tools modules from AWS.Tools.zip and removes 
    all other versions. Specifying exact versions is helpful to avoid introducing
    unexpected changes in production workloads.

.Example
    Install-AWSToolsModule -Version 4.* -Cleanup

    This example installs the latest module with major version 4 for of all AWS Tools modules from AWS.Tools.zip and removes 
    all other versions. Specifying major versions reduces the risk of breaking changes in production workloads.

.Example
    Install-AWSToolsModule -Name EC2,S3

    This example installs only the EC2 and S3 modules (and their dependencies) but still cleans 
    up all other AWS Tools modules.

.Example
    Install-AWSToolsModule -Timeout 600

    This example installs all AWS Tools modules with a 10-minute download timeout for slower 
    connections.

.Example
    Install-AWSToolsModule -Force

    This example forces reinstallation of AWS Tools modules even if the same version is already 
    installed.


.Example
    Install-AWSToolsModule -Scope AllUsers

    This example installs AWS Tools modules to the system-wide location accessible to all users.

.Example
    Install-AWSToolsModule -SourceZipPath "C:\Downloads\AWS.Tools.zip"

    This example installs AWS Tools modules from a local zip file for offline scenarios.

.Example
    Install-AWSToolsModule -Path "C:\DevModules"

    This example installs AWS Tools modules to a custom directory for testing or development.

.Example
    Install-AWSToolsModule -WhatIf

    This example performs a what-if analysis to preview what would be installed without making 
    changes.

.Example
    Install-AWSToolsModule -CleanUpLegacyModuleScope CurrentUser -Confirm:$false

    This example installs AWS Tools modules and cleans up legacy AWSPowerShell modules from the 
    current user scope.

.Example
    $ProgressPreference = 'SilentlyContinue'
    Install-AWSToolsModule
    $ProgressPreference = 'Continue'

    This example suppresses progress bar output during installation, which can significantly reduce 
    execution time, particularly in PowerShell 5.1. The progress preference is restored after 
    installation completes. Currently unable to add support for -ProgressAction.

.Example
    Install-AWSToolsModule -CleanUpLegacyModuleScope CurrentUser -Confirm:$false

    This example installs AWS Tools modules and cleans up legacy AWSPowerShell modules from the 
    current user scope.

.Example
    $common = Install-Module AWS.Tools.Common -PassThru
    Get-AWSService | ForEach-Object {Install-Module -Name $_.ModuleName -RequiredVersion $common.Version}

    This example shows how to install active modules for the latest version from PSGallery. A private repository
    can be specified with the <code>-Repository</code> parameter for both commands. This alternative approach take
    many magnitudes longer to execute than the equivalent <code>Install-AWSToolsModule</code> command and may fail for some
    modules during the daily release. 
    
    Note: PSGallery if not advised as a dependency for production workloads. There is no SLA for the availability of PSGallery.
    
.Example
    $common = Install-PSResource AWS.Tools.Common -PassThru
    Get-AWSService | ForEach-Object {Install-PSResource -Name $_.ModuleName -Version $common.Version -SkipDependencyCheck}

    This example is similar to the previous but uses the <code>Microsoft.PowerShell.PSResourceGet</code>. This is several magnitudes faster
    than the previous example but still several magnitudes slower than the equivalent <code>Install-AWSToolsModule</code> command
    and may fail for some modules during the daily release. 
    
    Note: PSGallery if not advised as a dependency for production workloads. There is no SLA for the availability of PSGallery.
#>
function Install-AWSToolsModule {
    [CmdletBinding(SupportsShouldProcess, ConfirmImpact = 'Medium', DefaultParameterSetName = 'ManagedCloudFront')]
    Param(
        [Parameter()]
        [string[]]
        [Alias('ModuleName')]
        $Name,

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
        Write-Progress -Id 1 -Activity "Install-AWSToolsModule" -Status "Initializing..." -PercentComplete 0
        
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
            "VerbosePreference=$VerbosePreference Name=($Name) Version=$Version Cleanup=$Cleanup")
    }

    Process {
        $ErrorActionPreference = 'Stop'

        try {
            # Update progress - starting version check and preparation
            Write-Progress -Id 1 -Activity "Install-AWSToolsModule" -Status "Resolving and downloading required files..." -PercentComplete 10
            
            # Validate and normalize module names
            $resolvedNames = Resolve-AWSToolsModuleNames -Name $Name

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

            # Build target description for ShouldProcess
            if ($PSCmdlet.ParameterSetName -eq 'ManagedCloudFront') {
                $versionText = " version $targetVersionToInstall"
            }
            else {
                $versionText = " from local zip file"
            }
            
            if ($Name) {
                $moduleText = ($Name -join ', ')
            }
            else {
                $moduleText = "all AWS Tools modules"
            }
            
            $target = "$moduleText$versionText to $targetPath"
            
            # Add WhatIf information message
            if ($WhatIfPreference) {
                Write-Host "What if: Would install $moduleText$versionText to $targetPath"
            }
            
            # Initialize installedVersion variable
            $installedVersion = $null
            
            if ($PSCmdlet.ShouldProcess($target, "Install AWS Tools modules")) {
                # Check if version is already installed
                $testVersionParams = @{ 
                    Name = 'AWS.Tools'
                    TargetPath = $targetPath
                    Force = $Force
                    Timeout = $Timeout 
                }
                if ($Version) { $testVersionParams.Version = $Version }
                if (-not $SourceZipPath -and (Test-AWSToolsVersionInstalled @testVersionParams)) {
                    Write-Verbose ("[$($MyInvocation.MyCommand)] AWS Tools version already " +
                        "installed, skipping installation")
                    Write-Host "Skipped installation: AWS.Tools.Common version $targetVersionToInstall already installed in $targetPath. Use -Force to overwrite or add missing modules."
                    return
                }

                # Create temporary directory
                $tempPath = [System.IO.Path]::GetTempPath()
                $randomName = [System.IO.Path]::GetRandomFileName()
                $tempDir = Join-Path $tempPath $randomName
                New-Item -ItemType 'Directory' -Path $tempDir -Force | Out-Null
                
                try {
                    # Update progress - preparing for installation
                    Write-Progress -Id 1 -Activity "Install-AWSToolsModule" -Status "Preparing to install modules..." -PercentComplete 30
                    # Resolve zip source (local file or download)
                    $resolveZipParams = @{ 
                        Name = 'AWS.Tools'
                        SourceZipPath = $SourceZipPath
                        TempDir = $tempDir
                        Timeout = $Timeout
                    }
                    
                    if ($PSBoundParameters.ContainsKey('SkipIntegrityCheck')) {
                        $resolveZipParams.SkipIntegrityCheck = $SkipIntegrityCheck
                    }
                    
                    if ($PSBoundParameters.ContainsKey('SourceHashPath')) {
                        $resolveZipParams.SourceHashPath = $SourceHashPath
                    }
                    if ($Version) { $resolveZipParams.Version = $Version }
                    $zipPath = Resolve-AWSToolsZipSource @resolveZipParams
                    
                    # Debug output to check the value of $zipPath
                    Write-Verbose "[$($MyInvocation.MyCommand)] ZipPath value: $zipPath"
                    
                    # Ensure $zipPath is a string
                    if ($null -eq $zipPath) {
                        $PSCmdlet.ThrowTerminatingError(
                            [System.Management.Automation.ErrorRecord]::new(
                                ([System.InvalidOperationException]"ZipPath is null. Cannot proceed with installation."),
                                'NullZipPath',
                                [System.Management.Automation.ErrorCategory]::InvalidOperation,
                                $null
                            )
                        )
                    }
                    
                    Write-Progress -Id 1 -Activity "Install-AWSToolsModule" -Status "Installing modules..." -PercentComplete 40

                    # Install modules from zip
                    if ($resolvedNames) {
                        Write-Verbose ("[$($MyInvocation.MyCommand)] Installing specified " +
                            "AWS Tools modules: $($resolvedNames -join ', ')")
                    } else {
                        Write-Verbose ("[$($MyInvocation.MyCommand)] Installing all " +
                            "AWS Tools modules")
                    }
                    
                    $installFromZipParams = @{
                        Name = 'AWS.Tools'
                        ZipPath = $zipPath
                        ModuleNames = $resolvedNames
                        TargetPath = $targetPath
                        ErrorAction = 'Stop'
                    }
                    $installedVersion = Install-AWSToolsModuleFromZip @installFromZipParams
                    
                    # For SourceZipPath parameter set, capture the version from the installed modules
                    if ($PSCmdlet.ParameterSetName -eq 'SourceZipPath' -and $installedVersion) {
                        $Version = $installedVersion
                        Write-Verbose ("[$($MyInvocation.MyCommand)] Captured version from local zip: $Version")
                    }
                    
                    Write-Verbose ("[$($MyInvocation.MyCommand)] AWS Tools modules installation " +
                        "completed successfully")
                    
                    # Provide installation summary via Write-Host
                    Write-Host "Installed AWS Tools version $installedVersion to $targetPath"
                    
                    # Update progress - installation complete, preparing for cleanup
                    Write-Progress -Id 1 -Activity "Install-AWSToolsModule" -Status "Installation complete, cleaning up previous versions..." -PercentComplete 70
                }
                finally {
                    # Clean up temporary directory
                    if (Test-Path $tempDir) {
                        Write-Verbose ("[$($MyInvocation.MyCommand)] Cleaning up temporary " +
                            "directory: $tempDir")
                        $removeItemParams = @{
                            Path = $tempDir
                            Recurse = $true
                            Force = $true
                            ErrorAction = 'SilentlyContinue'
                        }
                        # Temporarily suppress progress just for this operation
                        $savedProgressPreference = $ProgressPreference
                        $ProgressPreference = 'SilentlyContinue'
                        try {
                            Remove-Item @removeItemParams
                        }
                        finally {
                            $ProgressPreference = $savedProgressPreference
                        }
                    }
                }
            }
            
            # Determine version to keep for cleanup
            if ($installedVersion) {
                # Use the version that was actually installed
                $versionToKeep = $installedVersion
            }
            elseif ($Version) {
                # Use the specified version
                $versionToKeep = $Version.ToString()
            }
            else {
                # For ManagedCloudFront with "latest", we can't do cleanup without knowing the actual version
                # For SourceZipPath, no cleanup without installed version
                $versionToKeep = $null
            }
            
            # Only call cleanup if we have a valid version to keep and cleanup is requested
            if ($versionToKeep -and $versionToKeep.Trim() -ne '' -and $versionToKeep -ne "latest" -and $versionToKeep -ne "from local zip file" -and $Cleanup) {
                try {
                    # Use Uninstall-AWSToolsModule for cleanup
                    $uninstallParams = @{
                        ExceptVersion = $versionToKeep
                    }
                    
                    # Pass WhatIf preference if it's set
                    if ($PSBoundParameters.ContainsKey('WhatIf')) {
                        $uninstallParams.WhatIf = $WhatIfPreference
                    }
                    
                    # Pass scope or custom path
                    if ($Path) {
                        $uninstallParams.Path = $Path
                    }
                    else {
                        $uninstallParams.Scope = $Scope
                    }
                    
                    # Pass legacy cleanup scope if specified
                    if ($CleanUpLegacyModuleScope) {
                        $uninstallParams.CleanUpLegacyScope = $CleanUpLegacyModuleScope
                    }
                    
                    # Call Uninstall-AWSToolsModule for cleanup
                    Uninstall-AWSToolsModule @uninstallParams
                    
                }
                catch {
                    # Cleanup errors are non-terminating - write error but continue
                    Write-Error ("Failed to clean up previous AWS Tools versions: " +
                        "$($_.Exception.Message)") -ErrorAction Continue
                    Write-Verbose ("[$($MyInvocation.MyCommand)] Cleanup error details: " +
                        "$($_.Exception.ToString())")
                }
            }
            elseif ($CleanUpLegacyModuleScope) {
                try {
                    # If skipping AWS Tools cleanup but still need to clean up legacy modules
                    $uninstallParams = @{
                        CleanUpLegacyScope = $CleanUpLegacyModuleScope
                    }
                    
                    # Pass WhatIf preference if it's set
                    if ($PSBoundParameters.ContainsKey('WhatIf')) {
                        $uninstallParams.WhatIf = $WhatIfPreference
                    }
                    
                    # Call Uninstall-AWSToolsModule for legacy cleanup only
                    Uninstall-AWSToolsModule @uninstallParams
                }
                catch {
                    # Legacy cleanup errors are non-terminating - write error but continue
                    Write-Error ("Failed to clean up legacy AWSPowerShell modules: " +
                        "$($_.Exception.Message)") -ErrorAction Continue
                    Write-Verbose ("[$($MyInvocation.MyCommand)] Legacy cleanup error details: " +
                        "$($_.Exception.ToString())")
                }
            }
        }
        catch {
            $PSCmdlet.ThrowTerminatingError($_)
        }
    }

    End {
        # Complete progress bar
        Write-Progress -Id 1 -Activity "Install-AWSToolsModule" -Completed
        
        Write-Verbose "[$($MyInvocation.MyCommand)] End"
    }
}
