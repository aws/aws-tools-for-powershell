<#
.Synopsis
    Tests if a specific AWS Tools version is already installed.

.Description
    Checks if the specified version of AWS Tools modules or AWS.Tools.Installer is already installed
    in the target path. Returns true if installed and Force is not specified.

.Parameter Name
    Specifies which module type to check. Valid values are 'AWS.Tools' or 'AWS.Tools.Installer'.
    Defaults to 'AWS.Tools' for backward compatibility.

.Parameter TargetPath
    The path where modules are installed.

.Parameter Version
    The version to check for. If not specified, checks latest available version.

.Parameter Force
    If specified, always returns false to force reinstallation.

.Parameter Timeout
    Network operation timeout in seconds.
#>
function Test-AWSToolsVersionInstalled {
    [CmdletBinding()]
    param(
        [Parameter()]
        [ValidateSet('AWS.Tools', 'AWS.Tools.Installer')]
        [string]
        $Name = 'AWS.Tools',
        
        [Parameter(Mandatory)]
        [string]$TargetPath,
        
        [Parameter()]
        [Version]$Version,
        
        [Parameter()]
        [switch]$Force,
        
        [Parameter()]
        [int]$Timeout = $script:Config.network.DefaultTimeout
    )
    
    Begin {
        Write-Debug ("[$($MyInvocation.MyCommand)] Begin - Name=$Name TargetPath=$TargetPath " +
            "Version=$Version Force=$Force Timeout=$Timeout")
    }

    Process {
        if ($Force) {
            return $false
        }
        
        # Get module configuration from general.psd1
        $moduleConfig = $script:Config.general.Modules[$Name]
        if (-not $moduleConfig) {
            $PSCmdlet.ThrowTerminatingError(
                [System.Management.Automation.ErrorRecord]::new(
                    ([System.InvalidOperationException]"Configuration not found for module type: $Name"),
                    'ModuleConfigNotFound',
                    [System.Management.Automation.ErrorCategory]::InvalidOperation,
                    $Name
                )
            )
        }
        
        # Validate parameters
        $testParameterValidationParams = @{
            Path = $TargetPath
            Version = $Version
            ModuleName = $Name
            Timeout = $Timeout
        }
        Test-ParameterValidation @testParameterValidationParams
        
        # Check cache first to avoid redundant network calls
        if ($Version) {
            $cacheKey = "$Name-$Version"
        }
        else {
            $cacheKey = "$Name-latest"
        }
        if ($script:VersionCache -and $script:VersionCache.ContainsKey($cacheKey)) {
            $moduleVersion = $script:VersionCache[$cacheKey]
            Write-Verbose ("[$($MyInvocation.MyCommand)] Using cached version: " +
                "$moduleVersion")
        }
        else {
            # Initialize cache if not exists
            if (-not $script:VersionCache) {
                $script:VersionCache = @{}
            }
            
            # Build the URL to check based on module type and version
            $baseUrl = $script:Config.general.CloudFront.BaseUrl
            $path = $script:Config.general.CloudFront.Paths[$Name.Replace('.', '')]
            
            if ($Version) {
                $versionString = "$($Version.Major).$($Version.Minor).$($Version.Build)"
                $majorVersion = $Version.Major
                
                $zipUrl = $moduleConfig.CloudFrontUrls.ZipDownloadUrlVersionPattern `
                    -replace '\{baseUrl\}', $baseUrl `
                    -replace '\{path\}', $path `
                    -replace '\{majorVersion\}', $majorVersion `
                    -replace '\{version\}', $versionString
            }
            else {
                $majorVersion = $moduleConfig.DefaultMajorVersion
                
                $zipUrl = $moduleConfig.CloudFrontUrls.ZipDownloadUrlPattern `
                    -replace '\{baseUrl\}', $baseUrl `
                    -replace '\{path\}', $path `
                    -replace '\{majorVersion\}', $majorVersion
            }
            
            # Use HTTP status code-based retry logic for version check
            try {
                $invokeWithRetryParams = @{
                    ScriptBlock = { 
                        $response = Invoke-WebRequestWithStatusHandling -Uri $zipUrl -Method 'HEAD' -TimeoutSec $Timeout
                        
                        if (-not $response.Success) {
                            # Use custom error messages for version checking
                            $customMessages = @{
                                404 = "Version information not found at CloudFront endpoint."
                                403 = "Access denied when checking version information."
                                503 = "CloudFront service temporarily unavailable."
                            }
                            
                            Get-HttpStatusErrorMessage -Response $response -Operation "checking version information" -CustomMessages $customMessages
                        }
                        
                        return $response.RawResponse
                    }
                    MaxRetries = $script:Config.retry.VersionCheckMaxRetries
                    BaseDelaySeconds = $script:Config.retry.BaseDelaySeconds
                    OperationName = "Check online version"
                    RetryableExceptions = $script:Config.retry.RetryableExceptions.Network
                }
                
                $zipHeaderData = Invoke-WithRetry @invokeWithRetryParams
                
                $moduleVersion = $zipHeaderData.Headers.'Content-Disposition' `
                    -replace "attachment; filename=$($moduleConfig.ModulePrefix).", '' -replace '.zip', ''
                
                
                # Cache the version for future calls
                $script:VersionCache[$cacheKey] = $moduleVersion
                Write-Verbose ("[$($MyInvocation.MyCommand)] Cached version: " +
                    "$moduleVersion (HTTP 200)")
            }
            catch {
                # Only show warning if not in test context
                if (-not $env:PESTER_RUN) {
                    Write-Warning ("Unable to check online version after retries: " +
                        "$($_.Exception.Message). Proceeding with installation.")
                }
                return $false
            }
        }
        
        # Check for installed modules based on module type
        $params = @{ 
            Path = $TargetPath
            Name = $Name
        }
        
        if ($Name -eq 'AWS.Tools') {
            # For AWS.Tools, check for AWS.Tools.Common as the indicator module
            $installedModule = Get-AWSToolsModule @params | 
                Where-Object { $_.Name -eq 'AWS.Tools.Common' } | 
                Sort-Object Version -Descending | 
                Select-Object -First 1
        }
        else {
            # For AWS.Tools.Installer, check for the installer module itself
            $installedModule = Get-AWSToolsModule @params | 
                Sort-Object Version -Descending | 
                Select-Object -First 1
        }
        
        return ($installedModule -and 
            $installedModule.Version.ToString() -eq $moduleVersion)
    }

    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}
