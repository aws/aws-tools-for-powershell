<#
.Synopsis
    Installs AWS.Tools.Installer module from CloudFront distribution.

.Description
    This cmdlet installs the AWS.Tools.Installer module from the AWS CloudFront-hosted 
    AWS.Tools.Installer.zip file. By default, it installs the latest version and preserves 
    all other versions. Installation is skipped if the target version is already installed 
    unless Force is specified.

.Parameter Version
    Specifies the version to install. Supports exact versions (e.g., 2.0.0) or major 
    version wildcards (e.g., 1.*, 2.*). Minor version wildcards (e.g., 2.0.*, 2.1.*) are 
    not supported. Latest version is installed by default when not specified.

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
    Path to a local AWS.Tools.Installer.zip file for offline/air-gapped installation. Must be a 
    file path, not a directory. Requires either -SourceHashPath for SHA512 validation or 
    -SkipIntegrityCheck to bypass validation.

.Parameter SourceHashPath
    Path to the SHA512 hash file for validating the integrity of the zip file specified with 
    -SourceZipPath. When using -SourceZipPath, you must either provide this parameter for 
    validation or use -SkipIntegrityCheck to bypass validation.

.Parameter SkipIntegrityCheck
    Switch that bypasses SHA512 validation when specified. By default, SHA512 validation is performed
    to ensure the integrity of downloaded files.

.Parameter Path
    Specifies a custom installation path. If not specified, uses the standard PowerShell 
    module path for the specified scope.

.Parameter Force
    Forces installation even if the same version is already installed. Without this parameter, 
    installation is skipped if the target version already exists.

.Parameter Prerelease
    Allows installation of prerelease versions. When specified, the Version parameter can include 
    a prerelease tag (e.g., 2.0.0-preview001). This switch must be specified when installing 
    prerelease versions; otherwise, an error will be thrown.

.Parameter Timeout
    Specifies the timeout in seconds for downloading the AWS.Tools.Installer.zip file. 
    Default is 300 seconds (5 minutes). Increase this value for slower internet connections.

.Notes
    This cmdlet sources the installer module from the AWS CloudFront-hosted 
    AWS.Tools.Installer.zip file for improved speed and reliability. This is separate from 
    the main AWS.Tools.zip file to enable independent versioning and self-update capabilities.

.Example
    Install-AWSToolsInstaller -Version "2.*"

    This example installs the latest AWS.Tools.Installer module with major version 2 from CloudFront.
    Using major version wildcards reduces the risk of breaking changes while still receiving bug fixes 
    and new features within the major version.

.Example
    Install-AWSToolsInstaller -Version "2.0.0"

    This example installs version 2.0.0 of the AWS.Tools.Installer module. Specifying exact 
    versions ensures predictable behavior and is recommended for production workloads.

.Example
    Install-AWSToolsInstaller -WarningAction SilentlyContinue

    This example installs the latest available version of the AWS.Tools.Installer module from 
    CloudFront and preserves all other installed versions. The WarningAction parameter suppresses the 
    production workload warning when you intentionally want the latest version.

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
        [Alias('RequiredVersion')]
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
        $Timeout = $script:Config.network.DefaultTimeout,

        [Parameter(ParameterSetName = 'ManagedCloudFront')]
        [Alias('AllowPrerelease')]
        [switch]
        $Prerelease
    )

    Begin {
        # Initialize progress bar with ID to prevent it from being overridden by other progress bars
        Write-Progress -Id 1 -Activity "Install-AWSToolsInstaller" -Status "Initializing..." -PercentComplete 0
        
        # Issue warning if version is unspecified (no version constraint at all)
        if ($PSCmdlet.ParameterSetName -eq 'ManagedCloudFront') {
            $isUnspecifiedVersion = [string]::IsNullOrWhiteSpace($Version)

            if ($isUnspecifiedVersion) {
                Write-Warning @"
Installing the latest module without a version constraint may introduce breaking changes or unexpected behavior in production workloads.
For production environments, consider specifying a major version wildcard (e.g., -Version '2.*') or an exact version (e.g., -Version '2.0.0').
To suppress this warning, specify a version constraint. Alternatively, you can suppress ALL warnings using -WarningAction SilentlyContinue.
"@
            }
        }
        
        # Resolve version using parameter set logic
        if ($PSCmdlet.ParameterSetName -eq 'ManagedCloudFront') {
            # Validate prerelease parameter usage
            try {
                $versionFlags = Test-PrereleaseParameterValidation -Version $Version -Prerelease $Prerelease -ModuleName 'AWS.Tools.Installer'
                $isPreReleaseVersion = $versionFlags.IsPreReleaseVersion
                $isWildcardVersion = $versionFlags.IsWildcardVersion
            }
            catch {
                $PSCmdlet.ThrowTerminatingError($_)
            }
            
            $resolveVersionParams = @{
                Name = 'AWS.Tools.Installer'
                Version = $Version
                Timeout = $Timeout
            }
            if ($Prerelease) {
                $resolveVersionParams.Prerelease = $true
            }
            
            try {
                $resolvedVersion = Resolve-AWSToolsVersion @resolveVersionParams
                # Store the resolved version object separately (don't assign to $Version which is typed as [string])
                $resolvedVersionObj = $resolvedVersion
            }
            catch {
                $PSCmdlet.ThrowTerminatingError($_)
            }
            
            # Handle both standard [Version] objects and semver PSCustomObjects (for preview versions)
            if ($resolvedVersionObj) {
                if ($resolvedVersionObj.PSObject.Properties['SemVerString']) {
                    # Preview version - use the full semver string
                    $targetVersionToInstall = $resolvedVersionObj.SemVerString
                }
                else {
                    # Standard version
                    $targetVersionToInstall = $resolvedVersionObj.ToString()
                }
            }
            else {
                $targetVersionToInstall = "latest"
            }
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
            
            # Initialize installedVersion variable
            $installedVersion = $null
            
            if ($PSCmdlet.ShouldProcess($target, "Install AWS.Tools.Installer module")) {
                # Check if version is already installed BEFORE downloading to avoid unnecessary network calls
                # This check happens AFTER ShouldProcess so WhatIf users see what would be installed
                if (-not $SourceZipPath -and -not $Force -and $resolvedVersionObj) {
                    # Check local filesystem first for AWS.Tools.Installer
                    $params = @{ 
                        Path = $targetPath
                        Name = 'AWS.Tools.Installer'
                    }
                    $installedInstaller = Get-InstalledAWSToolsModule @params |
                        Sort-Object Version -Descending | 
                        Select-Object -First 1
                    
                    if ($installedInstaller) {
                        # Compare installed version with target version
                        $installedVersionString = $installedInstaller.Version.ToString()
                        $targetVersionString = if ($resolvedVersionObj.PSObject.Properties['SemVerString']) {
                            $resolvedVersionObj.SemVerString
                        } else {
                            $resolvedVersionObj.ToString()
                        }
                        
                        if ($installedVersionString -eq $targetVersionString) {
                            Write-Verbose ("[$($MyInvocation.MyCommand)] AWS.Tools.Installer version $targetVersionString already installed, skipping installation")
                            Write-Host "Skipped installation: AWS.Tools.Installer version $targetVersionToInstall already installed in $targetPath"
                            return
                        }
                    }
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
                    # Pass the resolved version object (not the original string which might be a wildcard)
                    if ($resolvedVersionObj) { $resolveZipParams.Version = $resolvedVersionObj }
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
                    # Best-effort: PS 7.4+ exposes $PSCmdlet.StoppingToken; older shells
                    # (notably Windows PowerShell 5.1) do not.
                    if ($PSCmdlet.PSObject.Properties['StoppingToken']) {
                        $installFromZipParams.CancellationToken = $PSCmdlet.StoppingToken
                    }
                    $installResult = Install-AWSToolsModuleFromZip @installFromZipParams
                    
                    # Extract version from structured result
                    $installedVersion = $installResult.Version
                    $installedVersionString = if ($installResult.VersionString) { $installResult.VersionString } else { $installedVersion }
                    
                    # For SourceZipPath parameter set, capture the version from the installed modules
                    if ($PSCmdlet.ParameterSetName -eq 'SourceZipPath' -and $installedVersion) {
                        $Version = $installedVersion
                        Write-Verbose ("[$($MyInvocation.MyCommand)] Captured version from local zip: $Version")
                    }
                    
                    Write-Verbose ("[$($MyInvocation.MyCommand)] AWS.Tools.Installer module installation " +
                        "completed successfully")
                    
                    # Provide installation summary via Write-Host
                    Write-Host "Installed AWS.Tools.Installer version $installedVersionString to $targetPath"
                    
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
                $versionToKeep = $installedVersion.ToString()
            }
            elseif ($resolvedVersionObj) {
                # Use the resolved version object
                if ($resolvedVersionObj.PSObject.Properties['SemVerString']) {
                    $versionToKeep = $resolvedVersionObj.SemVerString
                } else {
                    $versionToKeep = $resolvedVersionObj.ToString()
                }
            }
            elseif ($Version) {
                # Use the specified version string
                $versionToKeep = $Version
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
            if ($versionToKeep -and $versionToKeep -ne '' -and $versionToKeep -ne "from local zip file" -and $Cleanup) {
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
