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
    Specifies the version to install. Supports exact versions (e.g., 5.0.151) or major 
    version wildcards (e.g., 4.*, 5.*). Minor version wildcards (e.g., 5.0.*, 5.1.*) are 
    not supported. Latest version is installed by default when not specified.

.Parameter MinimumVersion
    Specifies the minimum version of the modules to install. This parameter is deprecated 
    and should no longer be used as it will be removed in the next major version.

.Parameter MaximumVersion
    Specifies the maximum version of the modules to install. This parameter is deprecated 
    and should no longer be used as it will be removed in the next major version.

.Parameter SkipUpdate
    This parameter is deprecated and should no longer be used as it will be removed in the next major version.
    The parameter is ignored and has no effect in AWS.Tools.Installer 2.0.0.

    This version of AWS.Tools.Installer attempts to install all available modules for a version unless the Name parameter is used to specify certain modules.

.Parameter SkipPublisherCheck
    This parameter is deprecated and should no longer be used as it will be removed in the next major version.
    The parameter is ignored and has no effect in AWS.Tools.Installer 2.0.0.

    There is no publisher check applied by this version of AWS.Tools.Installer.

.Parameter AllowClobber
    This parameter is deprecated and should no longer be used as it will be removed in the next major version.
    The parameter is ignored and has no effect in AWS.Tools.Installer 2.0.0.

    Existing cmdlets will be clobbered if their names conflict with cmdlets installed by AWS Tools for PowerShell modules.

.Parameter Proxy
    This parameter is deprecated and should no longer be used as it will be removed in the next major version.
    The parameter is ignored and has no effect in AWS.Tools.Installer 2.0.0.
    Proxy support has been removed in favor of CloudFront-based distribution.

    Previously this parameter specified a proxy server for the request, rather than connecting directly to an internet resource.

.Parameter ProxyCredential
    This parameter is deprecated and should no longer be used as it will be removed in the next major version.
    The parameter is ignored and has no effect in AWS.Tools.Installer 2.0.0.
    Proxy support has been removed in favor of CloudFront-based distribution.

    Previously this parameter specified a user account that had permission to use the proxy server specified by the Proxy parameter.

.Parameter Cleanup
    Switch that uninstalls other versions of installed AWS Tools modules after successful installation
    like when using <code>Uninstall-AWSToolsModule -ExceptVersion ...</code>
    
    Otherwise, by default, other versions remain installed.
    
    When the Name parameter is specified, cleanup only affects the named modules. When Name is not 
    specified, all AWS Tools modules (except installer) are cleaned up.

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
    Path to a local AWS.Tools.zip file for offline/air-gapped installation. Must be a file path, 
    not a directory. Requires either -SourceHashPath for SHA512 validation or -SkipIntegrityCheck 
    to bypass validation.

.Parameter SourceHashPath
    Path to the SHA512 hash file for validating the integrity of the zip file specified with 
    -SourceZipPath. When using -SourceZipPath, you must either provide this parameter for 
    validation or use -SkipIntegrityCheck to bypass validation.

.Parameter SkipIntegrityCheck
    Switch that bypasses SHA512 validation when specified. By default, SHA512 validation is performed
    to ensure the integrity of downloaded files.

.Parameter Force
    Forces installation even if the same version is already installed. Without this parameter, 
    installation is skipped if the target version already exists.

.Parameter Prerelease
    Allows installation of prerelease versions. When specified, the Version parameter can include 
    a prerelease tag (e.g., 5.0.0-preview001). This switch must be specified when installing 
    prerelease versions; otherwise, an error will be thrown.

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
    Install-AWSToolsModule -Version 5.*

    This example installs the latest modules with major version 5 from CloudFront-hosted AWS.Tools.zip.
    Using major version wildcards reduces the risk of breaking changes while still receiving bug fixes 
    and new features within the major version.

.Example
    Install-AWSToolsModule -Version 5.0.0-preview001 -Prerelease

    This example installs a preview/prerelease version of AWS Tools modules. The -Prerelease switch 
    must be specified when installing versions with prerelease tags (e.g., 5.0.0-preview001). This 
    is useful for testing upcoming releases before they are generally available.

.Example
    Install-AWSToolsModule -Version 5.0.103 -Cleanup

    This example installs version 5.0.103 of all AWS Tools modules from AWS.Tools.zip and removes 
    all other versions. Specifying exact versions ensures predictable behavior and is recommended 
    for production workloads.

.Example
    Install-AWSToolsModule -WarningAction SilentlyContinue

    This example installs the latest available version of all AWS Tools modules from CloudFront-hosted 
    AWS.Tools.zip. The WarningAction parameter suppresses the production workload warning when you 
    intentionally want the latest version.

.Example
    Install-AWSToolsModule -Cleanup -Confirm:$false

    This example installs all AWS Tools modules from CloudFront-hosted AWS.Tools.zip and removes 
    all non-latest AWS Tools for PowerShell modules without requiring interactive confirmation.
    Note: Installing without a version constraint may introduce unexpected changes in production workloads.

.Example
    Install-AWSToolsModule -Name EC2,S3

    This example installs only the EC2 and S3 modules (and their dependencies).

.Example
    Install-AWSToolsModule -Name EC2,S3 -Cleanup

    This example installs only the EC2 and S3 modules (and their dependencies) and removes 
    all other versions of EC2 and S3 only, leaving other AWS Tools modules untouched.

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
        [Parameter(Position = 0)]
        [string[]]
        [Alias('ModuleName')]
        $Name,

        [Parameter(ParameterSetName = 'ManagedCloudFront', Position = 1)]
        [Parameter(ParameterSetName = 'Legacy', Position = 1)]
        [string]
        [Alias('RequiredVersion')]
        $Version,

        [Parameter(ParameterSetName = 'Legacy')]
        [Version]
        $MinimumVersion,

        [Parameter(ParameterSetName = 'Legacy')]
        [Version]
        $MaximumVersion,

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
        $Timeout = $script:Config.network.DefaultTimeout,

        [Parameter()]
        [switch]
        $SkipUpdate,

        [Parameter()]
        [switch]
        $SkipPublisherCheck,

        [Parameter()]
        [switch]
        $AllowClobber,

        [Parameter()]
        [uri]
        $Proxy,

        [Parameter()]
        [pscredential]
        $ProxyCredential,

        [Parameter(ParameterSetName = 'ManagedCloudFront')]
        [Alias('AllowPrerelease')]
        [switch]
        $Prerelease
    )

    Begin {
        # Initialize progress bar with ID to prevent it from being overridden by other progress bars
        Write-Progress -Id 1 -Activity "Install-AWSToolsModule" -Status "Initializing..." -PercentComplete 0
        
        # Parameter validation for version constraints
        if ($PSCmdlet.ParameterSetName -eq 'ManagedCloudFront' -or $PSCmdlet.ParameterSetName -eq 'Legacy') {
            # Deprecation warnings for restored parameters
            if ($MinimumVersion) {
                Write-Warning "The MinimumVersion parameter is deprecated and should no longer be used as it will be removed in the next major version."
            }
            
            if ($MaximumVersion) {
                Write-Warning "The MaximumVersion parameter is deprecated and should no longer be used as it will be removed in the next major version."
            }
            
            # Deprecation warnings for legacy parameters (ignored)
            if ($SkipUpdate) {
                Write-Warning "The SkipUpdate parameter is deprecated and should no longer be used as it will be removed in the next major version."
            }
            
            if ($SkipPublisherCheck) {
                Write-Warning "The SkipPublisherCheck parameter is deprecated and should no longer be used as it will be removed in the next major version."
            }
            
            if ($AllowClobber) {
                Write-Warning "The AllowClobber parameter is deprecated and should no longer be used as it will be removed in the next major version."
            }
            
            if ($Proxy) {
                Write-Warning "The Proxy parameter is deprecated and should no longer be used as it will be removed in the next major version."
            }
            
            if ($ProxyCredential) {
                Write-Warning "The ProxyCredential parameter is deprecated and should no longer be used as it will be removed in the next major version."
            }
            
            # Issue warning if version is unspecified (no version constraint at all)
            $isUnspecifiedVersion = [string]::IsNullOrWhiteSpace($Version)

            if ($isUnspecifiedVersion) {
                Write-Warning @"
Installing the latest module without a version constraint may introduce breaking changes or unexpected behavior in production workloads.
For production environments, consider specifying a major version wildcard (e.g., -Version '5.*') or an exact version (e.g., -Version '5.0.103').
To suppress this warning, specify a version constraint. Alternatively, you can suppress ALL warnings using -WarningAction SilentlyContinue.
"@
            }
            
            # 1.0.3-compatible validation: Parameters can be used together
            if ($MinimumVersion -and $MaximumVersion -and $MinimumVersion -gt $MaximumVersion) {
                $PSCmdlet.ThrowTerminatingError(
                    [System.Management.Automation.ErrorRecord]::new(
                        ([System.ArgumentException]"Parameter MinimumVersion ('$MinimumVersion') cannot be greater than MaximumVersion ('$MaximumVersion')."),
                        'InvalidVersionRange',
                        [System.Management.Automation.ErrorCategory]::InvalidArgument,
                        $MinimumVersion
                    )
                )
            }

            if ($MinimumVersion -and $Version) {
                # Validate MinimumVersion <= Version (1.0.3 behavior)
                # Extract base version for comparison (handle semver strings)
                $versionForComparison = $Version
                if ($Version -match '^(\d+\.\d+\.\d+)') {
                    $versionForComparison = $Matches[1]
                }
                $versionObj = [Version]$versionForComparison
                if ($MinimumVersion -gt $versionObj) {
                    $PSCmdlet.ThrowTerminatingError(
                        [System.Management.Automation.ErrorRecord]::new(
                            ([System.ArgumentException]"Parameter MinimumVersion ('$MinimumVersion') cannot be greater than Version ('$Version')."),
                            'InvalidParameterCombination',
                            [System.Management.Automation.ErrorCategory]::InvalidArgument,
                            $MinimumVersion
                        )
                    )
                }
            }

            if ($MaximumVersion -and $Version) {
                # Validate MaximumVersion >= Version (1.0.3 behavior)
                # Extract base version for comparison (handle semver strings)
                $versionForComparison = $Version
                if ($Version -match '^(\d+\.\d+\.\d+)') {
                    $versionForComparison = $Matches[1]
                }
                $versionObj = [Version]$versionForComparison
                if ($MaximumVersion -lt $versionObj) {
                    $PSCmdlet.ThrowTerminatingError(
                        [System.Management.Automation.ErrorRecord]::new(
                            ([System.ArgumentException]"Parameter MaximumVersion ('$MaximumVersion') cannot be less than Version ('$Version')."),
                            'InvalidParameterCombination',
                            [System.Management.Automation.ErrorCategory]::InvalidArgument,
                            $MaximumVersion
                        )
                    )
                }
            }

            # Handle MaximumVersion without explicit Version (like 1.0.3)
            if ($MaximumVersion -and -not $Version) {
                # Try to get latest for the major version of MaximumVersion
                $majorVersion = $MaximumVersion.Major
                $wildcardVersion = "$majorVersion.*"
                
                try {
                    $latestForMajor = Resolve-AWSToolsVersion -Name 'AWS.Tools' -Version $wildcardVersion -Timeout $Timeout -ErrorAction Stop
                    if ($latestForMajor -and $latestForMajor -le $MaximumVersion) {
                        # Check MinimumVersion constraint if specified
                        if (-not $MinimumVersion -or $latestForMajor -ge $MinimumVersion) {
                            $Version = $latestForMajor
                            Write-Verbose ("[$($MyInvocation.MyCommand)] Using latest version '$Version' within MaximumVersion constraint")
                        } else {
                            $PSCmdlet.ThrowTerminatingError(
                                [System.Management.Automation.ErrorRecord]::new(
                                    ([System.ArgumentException]"Version '$latestForMajor' would be installed but a maximum version of '$MaximumVersion' was specified. The minimum version '$MinimumVersion' requirement is satisfied."),
                                    'NoVersionsInRange',
                                    [System.Management.Automation.ErrorCategory]::ObjectNotFound,
                                    @($MinimumVersion, $MaximumVersion)
                                )
                            )
                        }
                    } else {
                        $PSCmdlet.ThrowTerminatingError(
                            [System.Management.Automation.ErrorRecord]::new(
                                ([System.ArgumentException]"Version '$latestForMajor' would be installed but a maximum version of '$MaximumVersion' was specified."),
                                'MaximumVersionConstraintNotSatisfied',
                                [System.Management.Automation.ErrorCategory]::ObjectNotFound,
                                $MaximumVersion
                            )
                        )
                    }
                } catch {
                    $PSCmdlet.ThrowTerminatingError(
                        [System.Management.Automation.ErrorRecord]::new(
                            ([System.ArgumentException]"Unable to find a version within maximum version constraint '$MaximumVersion': $($_.Exception.Message)"),
                            'MaximumVersionResolutionFailed',
                            [System.Management.Automation.ErrorCategory]::ObjectNotFound,
                            $MaximumVersion
                        )
                    )
                }
            }

            # Handle MinimumVersion without explicit Version or MaximumVersion
            if ($MinimumVersion -and -not $Version -and -not $MaximumVersion) {
                # Just validate MinimumVersion exists, then use latest (1.0.3 behavior)
                try {
                    $minVersionCheck = Resolve-AWSToolsVersion -Name 'AWS.Tools' -Version $MinimumVersion.ToString() -Timeout $Timeout -ErrorAction Stop
                    if (-not $minVersionCheck) {
                        $PSCmdlet.ThrowTerminatingError(
                            [System.Management.Automation.ErrorRecord]::new(
                                ([System.ArgumentException]"The minimum version '$MinimumVersion' is not available online."),
                                'MinimumVersionNotFound',
                                [System.Management.Automation.ErrorCategory]::ObjectNotFound,
                                $MinimumVersion
                            )
                        )
                    }
                    Write-Verbose ("[$($MyInvocation.MyCommand)] MinimumVersion '$MinimumVersion' verified, using latest version")
                    # Leave $Version as null to use latest
                } catch {
                    $PSCmdlet.ThrowTerminatingError(
                        [System.Management.Automation.ErrorRecord]::new(
                            ([System.ArgumentException]"The minimum version '$MinimumVersion' is not available online."),
                            'MinimumVersionNotFound',
                            [System.Management.Automation.ErrorCategory]::ObjectNotFound,
                            $MinimumVersion
                        )
                    )
                }
            }

            # Validate prerelease parameter usage
            try {
                $versionFlags = Test-PrereleaseParameterValidation -Version $Version -Prerelease $Prerelease -ModuleName 'AWS.Tools'
                $isPreReleaseVersion = $versionFlags.IsPreReleaseVersion
                $isWildcardVersion = $versionFlags.IsWildcardVersion
            }
            catch {
                $PSCmdlet.ThrowTerminatingError($_)
            }
            
            # Resolve version using standard logic
            $resolveVersionParams = @{
                Name = 'AWS.Tools'
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
                # Re-throw using ThrowTerminatingError to preserve original error record
                $PSCmdlet.ThrowTerminatingError($_)
            }
            
            # Handle both standard [Version] objects and semver PSCustomObjects (for preview versions)
            if ($resolvedVersionObj) {
                Write-Debug "[$($MyInvocation.MyCommand)] ResolvedVersion type: $($resolvedVersionObj.GetType().FullName)"
                Write-Debug "[$($MyInvocation.MyCommand)] ResolvedVersion value: $resolvedVersionObj"
                $hasSemVerString = $null -ne $resolvedVersionObj.PSObject.Properties['SemVerString']
                Write-Debug "[$($MyInvocation.MyCommand)] Has SemVerString property: $hasSemVerString"
                if ($hasSemVerString) {
                    # Preview version - use the full semver string
                    $targetVersionToInstall = $resolvedVersionObj.SemVerString
                    Write-Debug "[$($MyInvocation.MyCommand)] Set targetVersionToInstall to SemVerString: $targetVersionToInstall (type: $($targetVersionToInstall.GetType().Name))"
                }
                else {
                    # Standard version
                    $targetVersionToInstall = $resolvedVersionObj.ToString()
                    Write-Debug "[$($MyInvocation.MyCommand)] Set targetVersionToInstall to Version.ToString(): $targetVersionToInstall (type: $($targetVersionToInstall.GetType().Name))"
                }
            }
            else {
                $targetVersionToInstall = "latest"
                Write-Debug "[$($MyInvocation.MyCommand)] Set targetVersionToInstall to 'latest'"
            }
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
            
            # Initialize installedVersion variable
            $installedVersion = $null
            
            if ($PSCmdlet.ShouldProcess($target, "Install AWS Tools modules")) {
                # Check if version is already installed BEFORE downloading to avoid unnecessary network calls
                # This check happens AFTER ShouldProcess so WhatIf users see what would be installed
                if (-not $SourceZipPath -and -not $Force -and $resolvedVersionObj) {
                    # Check local filesystem first for AWS.Tools.Common
                    $params = @{ 
                        Path = $targetPath
                        Name = 'AWS.Tools'
                    }
                    $installedCommon = Get-InstalledAWSToolsModule @params |
                        Where-Object { $_.Name -eq 'AWS.Tools.Common' } |
                        Sort-Object Version -Descending |
                        Select-Object -First 1
                    
                    if ($installedCommon) {
                        # Compare installed version with target version
                        $installedVersionString = $installedCommon.Version.ToString()
                        $targetVersionString = if ($resolvedVersionObj.PSObject.Properties['SemVerString']) {
                            $resolvedVersionObj.SemVerString
                        } else {
                            $resolvedVersionObj.ToString()
                        }
                        
                        if ($installedVersionString -eq $targetVersionString) {
                            Write-Verbose ("[$($MyInvocation.MyCommand)] AWS Tools version $targetVersionString already installed, skipping installation")
                            Write-Host "Skipped installation: AWS.Tools.Common version $targetVersionToInstall already installed in $targetPath. Use -Force to overwrite or add missing modules."
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
                    # Best-effort: PS 7.4+ exposes $PSCmdlet.StoppingToken; older shells
                    # (notably Windows PowerShell 5.1) do not. Pass it when present so
                    # Ctrl+C can interrupt the native extract loop.
                    if ($PSCmdlet.PSObject.Properties['StoppingToken']) {
                        $installFromZipParams.CancellationToken = $PSCmdlet.StoppingToken
                    }
                    $installResult = Install-AWSToolsModuleFromZip @installFromZipParams

                    # Extract version and modules from structured result
                    $installedVersion = $installResult.Version
                    $installedVersionString = if ($installResult.VersionString) { $installResult.VersionString } else { $installedVersion }
                    $installedModules = $installResult.Modules
                    
                    $moduleNames = $installedModules | ForEach-Object { $_.Name }
                    Write-Verbose ("[$($MyInvocation.MyCommand)] Installed modules: " +
                        "$($moduleNames -join ', ') with version $installedVersion")
                    
                    # For SourceZipPath parameter set, capture the version from the installed modules
                    if ($PSCmdlet.ParameterSetName -eq 'SourceZipPath' -and $installedVersion) {
                        $Version = $installedVersion
                        Write-Verbose ("[$($MyInvocation.MyCommand)] Captured version from local zip: $Version")
                    }
                    
                    Write-Verbose ("[$($MyInvocation.MyCommand)] AWS Tools modules installation " +
                        "completed successfully")
                    
                    # Provide installation summary via Write-Host
                    Write-Host "Installed AWS Tools version $installedVersionString to $targetPath"
                    
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
                # Use the specified version - handle both [Version] and semver objects
                # Check if it's a string first to avoid triggering type resolution
                if ($Version -is [string]) {
                    # For string versions (including wildcards and semver strings), use directly
                    $versionToKeep = $Version
                }
                elseif ($Version.PSObject.Properties['SemVerString']) {
                    $versionToKeep = $Version.SemVerString
                }
                else {
                    $versionToKeep = $Version.ToString()
                }
            }
            else {
                # For ManagedCloudFront with "latest", we can't do cleanup without knowing the actual version
                # For SourceZipPath, no cleanup without installed version
                $versionToKeep = $null
            }
            
            # Only call cleanup if we have installed modules and cleanup is requested
            if ($installedModules -and $installedModules.Count -gt 0 -and $Cleanup) {
                try {
                    # Use the Modules array directly as ExceptModules (already in correct format)
                    Write-Verbose ("[$($MyInvocation.MyCommand)] Using ExceptModules for cleanup " +
                        "with $($installedModules.Count) module-version pairs")
                    
                    # Use Uninstall-AWSToolsModule for cleanup
                    $uninstallParams = @{
                        ExceptModules = $installedModules
                    }
                    
                    # If Name was specified, only clean up those specific modules
                    # This aligns with V1 behavior and avoids surprising destructive cleanup
                    if ($Name) {
                        $uninstallParams.Name = $Name
                        Write-Verbose ("[$($MyInvocation.MyCommand)] Cleanup constrained to " +
                            "named modules: $($Name -join ', ')")
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
                    Uninstall-AWSToolsModule @uninstallParams | Out-Null
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
