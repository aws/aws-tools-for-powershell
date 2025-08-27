<#
.Synopsis
    Resolves AWS Tools version from various input formats.

.Description
    Handles version resolution including wildcard patterns (4.*, 5.*), exact versions,
    and null/empty versions. Makes HEAD requests to CloudFront to resolve wildcard
    patterns to actual version numbers. Supports both AWS.Tools and AWS.Tools.Installer.

.Parameter Name
    Specifies which module type to resolve version for. Valid values are 'AWS.Tools' or 'AWS.Tools.Installer'.
    Defaults to 'AWS.Tools' for backward compatibility.

.Parameter Version
    The version string to resolve. Can be exact version, wildcard pattern, or null/empty.

.Parameter Timeout
    Timeout in seconds for network requests when resolving wildcard versions.

.Returns
    [Version] object for exact versions, $null for latest version requests.
#>
function Resolve-AWSToolsVersion {
    [CmdletBinding()]
    param(
        [Parameter()]
        [ValidateSet('AWS.Tools', 'AWS.Tools.Installer')]
        [string]
        $Name = 'AWS.Tools',
        
        [Parameter()]
        [AllowEmptyString()]
        [string]$Version,
        
        [Parameter()]
        [int]$Timeout = $script:Config.network.DefaultTimeout
    )
    
    Begin {
        Write-Debug ("[$($MyInvocation.MyCommand)] Begin - Name=$Name Version='$Version' Timeout=$Timeout")
    }

    Process {
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
        
        # Handle null or empty version
        if (-not $Version -or $Version.Trim() -eq '') {
            Write-Verbose ("[$($MyInvocation.MyCommand)] No version specified, will use latest")
            return $null
        }
        
        # Handle wildcard patterns like "4.*" or "5.*" for AWS.Tools, "1.*" for AWS.Tools.Installer
        if ($Version -match '^(\d+)\.\*$') {
            if (-not $moduleConfig.SupportsWildcardVersions) {
                $PSCmdlet.ThrowTerminatingError(
                    [System.Management.Automation.ErrorRecord]::new(
                        ([System.ArgumentException]"Wildcard version patterns are not supported for $Name. Please specify an exact version or leave empty for latest."),
                        'WildcardVersionsNotSupported',
                        [System.Management.Automation.ErrorCategory]::InvalidArgument,
                        $Version
                    )
                )
            }
            
            $majorVersion = $matches[1]
            Write-Verbose ("[$($MyInvocation.MyCommand)] Resolving wildcard pattern: $Version")
            
            try {
                # Build the URL using configuration patterns
                $baseUrl = $script:Config.general.CloudFront.BaseUrl
                $path = $script:Config.general.CloudFront.Paths[$Name.Replace('.', '')]
                
                $zipUrl = $moduleConfig.CloudFrontUrls.ZipDownloadUrlPattern `
                    -replace '\{baseUrl\}', $baseUrl `
                    -replace '\{path\}', $path `
                    -replace '\{majorVersion\}', $majorVersion
                
                $invokeWithRetryParams = @{
                    ScriptBlock = { 
                        $response = Invoke-WebRequestWithStatusHandling -Uri $zipUrl -Method 'HEAD' -TimeoutSec $Timeout
                        
                        if (-not $response.Success) {
                            # Use custom error messages for wildcard version resolution
                            $customMessages = @{
                                404 = "Version pattern $Version not found. The major version may not be available."
                                403 = "Version pattern $Version not found. The major version may not be available."
                                503 = "CloudFront service temporarily unavailable."
                            }
                            
                            Get-HttpStatusErrorMessage -Response $response -Operation "resolving version pattern $Version" -CustomMessages $customMessages
                        }
                        
                        return $response.RawResponse
                    }
                    MaxRetries = $script:Config.retry.VersionCheckMaxRetries
                    BaseDelaySeconds = $script:Config.retry.BaseDelaySeconds
                    OperationName = "Resolve wildcard version"
                    RetryableExceptions = $script:Config.retry.RetryableExceptions.Network
                }
                
                $response = Invoke-WithRetry @invokeWithRetryParams
                # Content-Disposition is expected to return a string in the following format: "attachment; filename=AWS.Tools.5.0.12.zip"
                $contentDisposition = $response.Headers.'Content-Disposition'
                
                # Handle array responses from headers
                if ($contentDisposition -is [array]) { 
                    $contentDisposition = $contentDisposition[0] 
                }
                
                $actualVersion = $contentDisposition -replace "attachment; filename=$($moduleConfig.ModulePrefix).", '' 
                $actualVersion = $actualVersion -replace '.zip', ''
                $resolvedVersion = [Version]$actualVersion
                
                # Validate 3-part version format
                if ($resolvedVersion.Revision -ne -1) {
                    $PSCmdlet.ThrowTerminatingError(
                        [System.Management.Automation.ErrorRecord]::new(
                            ([System.ArgumentException]"Invalid $Name version format: $actualVersion. $Name versions must be 3-part (Major.Minor.Build), not 4-part."),
                            'InvalidVersionFormat',
                            [System.Management.Automation.ErrorCategory]::InvalidArgument,
                            $actualVersion
                        )
                    )
                }
                
                Write-Verbose ("[$($MyInvocation.MyCommand)] Resolved $Version to " +
                    "actual version: $resolvedVersion")
                return $resolvedVersion
            }
            catch {
                Write-Verbose ("[$($MyInvocation.MyCommand)] Failed to resolve $Version " +
                    "to actual version: $($_.Exception.Message). Will use latest endpoint")
                return $null
            }
        }
        
        # Handle exact version strings
        try {
            $exactVersion = [Version]$Version
            
            # Validate 3-part version format
            if ($exactVersion.Revision -ne -1) {
                $PSCmdlet.ThrowTerminatingError(
                    [System.Management.Automation.ErrorRecord]::new(
                        ([System.ArgumentException]"Invalid $Name version format: $Version. $Name versions must be 3-part (Major.Minor.Build), not 4-part."),
                        'InvalidVersionFormat',
                        [System.Management.Automation.ErrorCategory]::InvalidArgument,
                        $Version
                    )
                )
            }
            
            # Perform early HEAD check to verify the exact version exists on CloudFront
            $versionString = "$($exactVersion.Major).$($exactVersion.Minor).$($exactVersion.Build)"
            $majorVersion = $exactVersion.Major
            
            # Build the URL using configuration patterns
            $baseUrl = $script:Config.general.CloudFront.BaseUrl
            $path = $script:Config.general.CloudFront.Paths[$Name.Replace('.', '')]
            
            $zipUrl = $moduleConfig.CloudFrontUrls.ZipDownloadUrlVersionPattern `
                -replace '\{baseUrl\}', $baseUrl `
                -replace '\{path\}', $path `
                -replace '\{majorVersion\}', $majorVersion `
                -replace '\{version\}', $versionString
            
            Write-Verbose ("[$($MyInvocation.MyCommand)] Verifying exact version exists: $exactVersion")
            
            try {
                $invokeWithRetryParams = @{
                    ScriptBlock = { 
                        $response = Invoke-WebRequestWithStatusHandling -Uri $zipUrl -Method 'HEAD' -TimeoutSec $Timeout
                        
                        if (-not $response.Success) {
                            # Use custom error messages for exact version verification
                            $customMessages = @{
                                404 = "Version $exactVersion is not available online. Please check the version number or use a wildcard pattern to get the latest available version for that major version."
                                403 = "Version $exactVersion is not available online. Please check the version number or use a wildcard pattern to get the latest available version for that major version."
                                503 = "CloudFront service temporarily unavailable while verifying version."
                            }
                            
                            Get-HttpStatusErrorMessage -Response $response -Operation "verifying version $exactVersion" -CustomMessages $customMessages
                        }
                        
                        return $response.RawResponse
                    }
                    MaxRetries = $script:Config.retry.VersionCheckMaxRetries
                    BaseDelaySeconds = $script:Config.retry.BaseDelaySeconds
                    OperationName = "Verify exact version availability"
                    RetryableExceptions = $script:Config.retry.RetryableExceptions.Network
                }
                
                $response = Invoke-WithRetry @invokeWithRetryParams
                Write-Verbose ("[$($MyInvocation.MyCommand)] Confirmed exact version exists: $exactVersion (HTTP 200)")
            }
            catch {
                # Re-throw the error (it already has appropriate messaging from the status code handling)
                throw
            }
            
            Write-Verbose ("[$($MyInvocation.MyCommand)] Using exact version: $exactVersion")
            return $exactVersion
        }
        catch {
            # Re-throw if it's already our custom validation error
            if ($_.Exception.Message -like "*Invalid * version format*" -or
                $_.Exception.Message -like "*is not available online*" -or
                $_.Exception.Message -like "*Access denied*" -or
                $_.Exception.Message -like "*service temporarily unavailable*") {
                throw
            }
            
            $supportedFormats = if ($Name -eq 'AWS.Tools') {
                "exact version (4.1.754) or major version (4.*, 5.*)"
            } else {
                "exact version (1.0.3) or major version (1.*)"
            }
            
            throw ("Invalid version format: $Version. Use $supportedFormats")
        }
    }

    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}
