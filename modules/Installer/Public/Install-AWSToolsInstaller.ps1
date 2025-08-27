<#
.Synopsis
    Installs AWS.Tools.Installer module from CloudFront distribution.

.Description
    This cmdlet installs the AWS.Tools.Installer module from the AWS CloudFront-hosted 
    AWS.Tools.Installer.zip file. By default, it installs the latest version and preserves 
    all other versions. Installation is skipped if the target version is already installed 
    unless Force is specified.

.Parameter Version
    Specifies an exact version to install. Latest version is installed by default.

.Parameter Cleanup
    Removes previous versions of the installer after successful installation.
    By default, previous versions are preserved.

.Parameter Scope
    Specifies the installation scope of the module as well as scope for module cleanup.
    The acceptable values for this parameter are AllUsers and CurrentUser.
    
    The AllUsers scope installs modules in a location that is accessible to all users of the 
    computer.
    
    The CurrentUser installs modules in a location that is accessible only to the current user 
    of the computer.
    
    Default value is 'CurrentUser'.

.Parameter SourceZipPath
    Alternative installation from a local copy of AWS.Tools.Installer.zip to support 
    offline/air-gapped environments.

.Parameter SourceHashPath
    Local path to SHA512 hash file for validating the integrity of a local zip file specified with
    SourceZipPath. When provided, uses this file for validation instead of downloading the hash file.

.Parameter SkipIntegrityCheck
    Switch that bypasses SHA512 validation when specified. By default, SHA512 validation is performed
    to ensure the integrity of downloaded files.

.Parameter Path
    Specifies a custom installation path. If not specified, uses the standard PowerShell 
    module path for the specified scope.

.Parameter Force
    Forces installation even if the same version is already installed. Without this parameter, 
    installation is skipped if the target version already exists.

.Parameter Timeout
    Specifies the timeout in seconds for downloading the AWS.Tools.Installer.zip file. 
    Default is 300 seconds (5 minutes). Increase this value for slower internet connections.

.Notes
    This cmdlet sources the installer module from the AWS CloudFront-hosted 
    AWS.Tools.Installer.zip file for improved speed and reliability. This is separate from 
    the main AWS.Tools.zip file to enable independent versioning and self-update capabilities.

.Example
    Install-AWSToolsInstaller

    This example installs the latest AWS.Tools.Installer module from CloudFront and preserves 
    all other versions.

.Example
    Install-AWSToolsInstaller -Version "2.0.0"

    This example installs version 2.0.0 of the AWS.Tools.Installer module.

.Example
    Install-AWSToolsInstaller -Version "2.*" -Cleanup

    This example installs the latest module with major version 1 of the AWS.Tools.Installer module and removes 
    all other versions. Specifying major versions reduces the risk of breaking changes in production workloads.    

.Example
    Install-AWSToolsInstaller -Scope AllUsers

    This example installs the AWS.Tools.Installer module to the system-wide location 
    accessible to all users.

.Example
    Install-AWSToolsInstaller -SourceZipPath "C:\Downloads\AWS.Tools.Installer.zip"

    This example installs the AWS.Tools.Installer module from a local zip file for offline 
    scenarios.

.Example
    Install-AWSToolsInstaller -Path "C:\DevModules"

    This example installs the AWS.Tools.Installer module to a custom directory for testing 
    or development.

.Example
    Install-AWSToolsInstaller -Force

    This example forces reinstallation of the AWS.Tools.Installer module even if the same 
    version is already installed.

.Example
    Install-AWSToolsInstaller -WhatIf

    This example performs a what-if analysis to preview what would be installed without 
    making changes.

.Example
    Install-AWSToolsInstaller -Cleanup -Confirm:$false

    This example installs the latest AWS.Tools.Installer module and removes all other versions.
#>
function Install-AWSToolsInstaller {
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
        Write-Progress -Id 1 -Activity "Install-AWSToolsInstaller" -Status "Initializing..." -PercentComplete 0
        
        # Resolve version using parameter set logic
        if ($PSCmdlet.ParameterSetName -eq 'ManagedCloudFront') {
            $Version = Resolve-AWSToolsVersion -Name 'AWS.Tools.Installer' -Version $Version -Timeout $Timeout
            $targetVersionToInstall = if ($Version) { $Version.ToString() } else { "latest" }
        }
        else {
            # SourceZipPath - version will be determined from zip contents during installation
            $targetVersionToInstall = "from local zip file"
        }
        
        Write-Verbose ("[$($MyInvocation.MyCommand)] ParameterSetName=$($PSCmdlet.ParameterSetName) " +
            "ConfirmPreference=$ConfirmPreference WhatIfPreference=$WhatIfPreference " +
            "VerbosePreference=$VerbosePreference Version=$Version")
    }

    Process {
        $ErrorActionPreference = 'Stop'

        try {
            # Update progress - starting version check and preparation
            Write-Progress -Id 1 -Activity "Install-AWSToolsInstaller" -Status "Resolving and downloading required files..." -PercentComplete 10
            
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
            
            $target = "AWS.Tools.Installer$versionText to $targetPath"
            
            # Add WhatIf information message
            if ($WhatIfPreference) {
                Write-Host "What if: Would install AWS.Tools.Installer$versionText to $targetPath"
            }
            
            # Initialize installedVersion variable
            $installedVersion = $null
            
            if ($PSCmdlet.ShouldProcess($target, "Install AWS.Tools.Installer module")) {
                # Check if version is already installed
                $testVersionParams = @{ 
                    Name = 'AWS.Tools.Installer'
                    TargetPath = $targetPath
                    Force = $Force
                    Timeout = $Timeout 
                }
                if ($Version) { $testVersionParams.Version = $Version }
                if (-not $SourceZipPath -and (Test-AWSToolsVersionInstalled @testVersionParams)) {
                    Write-Verbose ("[$($MyInvocation.MyCommand)] AWS.Tools.Installer version already " +
                        "installed, skipping installation")
                    Write-Host "Skipped installation: AWS.Tools.Installer version $targetVersionToInstall already installed in $targetPath"
                    return
                }

                # Create temporary directory
                $tempPath = [System.IO.Path]::GetTempPath()
                $randomName = [System.IO.Path]::GetRandomFileName()
                $tempDir = Join-Path $tempPath $randomName
                New-Item -ItemType 'Directory' -Path $tempDir -Force | Out-Null
                
                try {
                    # Update progress - preparing for installation
                    Write-Progress -Id 1 -Activity "Install-AWSToolsInstaller" -Status "Preparing to install module..." -PercentComplete 30
                    # Resolve zip source (local file or download)
                    $resolveZipParams = @{ 
                        Name = 'AWS.Tools.Installer'
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
                    
                    # Install module from zip
                    Write-Verbose ("[$($MyInvocation.MyCommand)] Installing AWS.Tools.Installer module")
                    
                    $installFromZipParams = @{
                        Name = 'AWS.Tools.Installer'
                        ZipPath = $zipPath
                        ModuleNames = @('AWS.Tools.Installer')
                        TargetPath = $targetPath
                        ErrorAction = 'Stop'
                    }
                    $installedVersion = Install-AWSToolsModuleFromZip @installFromZipParams
                    
                    # For SourceZipPath parameter set, capture the version from the installed modules
                    if ($PSCmdlet.ParameterSetName -eq 'SourceZipPath' -and $installedVersion) {
                        $Version = $installedVersion
                        Write-Verbose ("[$($MyInvocation.MyCommand)] Captured version from local zip: $Version")
                    }
                    
                    Write-Verbose ("[$($MyInvocation.MyCommand)] AWS.Tools.Installer module installation " +
                        "completed successfully")
                    
                    # Provide installation summary via Write-Host
                    Write-Host "Installed AWS.Tools.Installer version $installedVersion to $targetPath"
                    
                    # Update progress - installation complete, preparing for cleanup
                    Write-Progress -Id 1 -Activity "Install-AWSToolsInstaller" -Status "Installation complete, cleaning up previous versions..." -PercentComplete 70
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
                # For ManagedCloudFront, use the target version; for SourceZipPath, no cleanup without installed version
                if ($PSCmdlet.ParameterSetName -eq 'ManagedCloudFront') {
                    $versionToKeep = $targetVersionToInstall
                }
                else {
                    $versionToKeep = $null
                }
            }
            
            # Clean up previous versions only if Cleanup is specified
            if ($versionToKeep -and $versionToKeep.Trim() -ne '' -and $versionToKeep -ne "from local zip file" -and $Cleanup) {
                try {
                    # Use Uninstall-AWSToolsInstaller for cleanup
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
                    
                    # Call Uninstall-AWSToolsInstaller for cleanup
                    Uninstall-AWSToolsInstaller @uninstallParams
                    
                    # Provide cleanup summary via Write-Host
                    if (-not $WhatIfPreference) {
                        Write-Host "Removed previous AWS.Tools.Installer versions, keeping version $versionToKeep"
                    }
                }
                catch {
                    # Cleanup errors are non-terminating - write error but continue
                    Write-Error ("Failed to clean up previous AWS.Tools.Installer versions: " +
                        "$($_.Exception.Message)") -ErrorAction Continue
                    Write-Verbose ("[$($MyInvocation.MyCommand)] Cleanup error details: " +
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
        Write-Progress -Id 1 -Activity "Install-AWSToolsInstaller" -Completed
        
        Write-Verbose "[$($MyInvocation.MyCommand)] End"
    }
}
