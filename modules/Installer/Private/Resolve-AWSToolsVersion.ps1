<#
.Synopsis
    Resolves AWS Tools version from various input formats.

.Description
    Handles version resolution including wildcard patterns (4.*, 5.*), exact versions,
    preview/prerelease versions (5.0.0-preview001), and null/empty versions. Makes HEAD 
    requests to CloudFront to resolve wildcard patterns to actual version numbers. 
    Supports both AWS.Tools and AWS.Tools.Installer.

.Parameter Name
    Specifies which module type to resolve version for. Valid values are 'AWS.Tools' or 'AWS.Tools.Installer'.
    Defaults to 'AWS.Tools' for backward compatibility.

.Parameter Version
    The version string to resolve. Can be exact version (5.0.0), wildcard pattern (5.*),
    preview version (5.0.0-preview001), or null/empty for latest.

.Parameter Timeout
    Timeout in seconds for network requests when resolving wildcard versions.

.Parameter Prerelease
    Indicates that prerelease versions should be used. When specified without a version,
    returns a marker for "latest preview". When specified with a wildcard (e.g., 5.*),
    returns a marker for "latest preview in major version".

.Returns
    For standard versions: [Version] object
    For preview versions: [PSCustomObject] with Version, PreReleaseTag, IsPreRelease, SemVerString properties
    For latest version requests: $null
    For latest preview requests: [PSCustomObject] with IsLatestPreview=$true and Major property
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
        [int]$Timeout = $script:Config.network.DefaultTimeout,
        
        [Parameter()]
        [switch]
        $Prerelease
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
            if ($Prerelease) {
                # Return marker for latest preview
                $majorVersion = $moduleConfig.DefaultMajorVersion
                Write-Verbose ("[$($MyInvocation.MyCommand)] No version specified with -Prerelease, will use latest preview in major version $majorVersion")
                return [PSCustomObject]@{
                    IsLatestPreview = $true
                    Major = $majorVersion
                }
            }
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
            
            # If -Prerelease is specified with wildcard, return marker for latest preview in that major version
            if ($Prerelease) {
                Write-Verbose ("[$($MyInvocation.MyCommand)] Wildcard pattern $Version with -Prerelease, will use latest preview in major version $majorVersion")
                return [PSCustomObject]@{
                    IsLatestPreview = $true
                    Major = $majorVersion
                }
            }
            
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
                
                # Validate 3-part version format (allow 4-part if Revision is 0)
                if ($resolvedVersion.Revision -ne -1 -and $resolvedVersion.Revision -ne 0) {
                    $PSCmdlet.ThrowTerminatingError(
                        [System.Management.Automation.ErrorRecord]::new(
                            ([System.ArgumentException]"Invalid $Name version format: $actualVersion. $Name versions must be 3-part (Major.Minor.Build) or 4-part with .0 as the last part (Major.Minor.Build.0)."),
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
        
        # Check if this is a preview/prerelease version (contains a hyphen followed by prerelease tag)
        if ($Version -match '^(\d+\.\d+\.\d+)-(.+)$') {
            Write-Verbose ("[$($MyInvocation.MyCommand)] Detected preview/prerelease version: $Version")
            
            # Parse the semver string
            $semver = ConvertTo-AWSToolsSemVer -VersionString $Version
            
            if (-not $semver) {
                $PSCmdlet.ThrowTerminatingError(
                    [System.Management.Automation.ErrorRecord]::new(
                        ([System.ArgumentException]"Invalid preview version format: $Version. Expected format: Major.Minor.Build-prerelease (e.g., 5.0.0-preview001)"),
                        'InvalidPreviewVersionFormat',
                        [System.Management.Automation.ErrorCategory]::InvalidArgument,
                        $Version
                    )
                )
            }
            
            # Build the URL using the preview pattern
            $baseUrl = $script:Config.general.CloudFront.BaseUrl
            $path = $script:Config.general.CloudFront.Paths[$Name.Replace('.', '')]
            
            # Use the preview URL pattern if available, otherwise fall back to version pattern with semver
            $urlPattern = $moduleConfig.CloudFrontUrls.ZipDownloadUrlPreviewPattern
            if (-not $urlPattern) {
                $urlPattern = $moduleConfig.CloudFrontUrls.ZipDownloadUrlVersionPattern
            }
            
            $zipUrl = $urlPattern `
                -replace '\{baseUrl\}', $baseUrl `
                -replace '\{path\}', $path `
                -replace '\{majorVersion\}', $semver.Major `
                -replace '\{version\}', $semver.SemVerString `
                -replace '\{semver\}', $semver.SemVerString
            
            Write-Verbose ("[$($MyInvocation.MyCommand)] Verifying preview version exists: $($semver.SemVerString)")
            
            try {
                $invokeWithRetryParams = @{
                    ScriptBlock = { 
                        $response = Invoke-WebRequestWithStatusHandling -Uri $zipUrl -Method 'HEAD' -TimeoutSec $Timeout
                        
                        if (-not $response.Success) {
                            # Use custom error messages for preview version verification
                            $customMessages = @{
                                404 = "Preview version $($semver.SemVerString) is not available online. Please check the version number."
                                403 = "Preview version $($semver.SemVerString) is not available online. Please check the version number."
                                503 = "CloudFront service temporarily unavailable while verifying preview version."
                            }
                            
                            Get-HttpStatusErrorMessage -Response $response -Operation "verifying preview version $($semver.SemVerString)" -CustomMessages $customMessages
                        }
                        
                        return $response.RawResponse
                    }
                    MaxRetries = $script:Config.retry.VersionCheckMaxRetries
                    BaseDelaySeconds = $script:Config.retry.BaseDelaySeconds
                    OperationName = "Verify preview version availability"
                    RetryableExceptions = $script:Config.retry.RetryableExceptions.Network
                }
                
                $response = Invoke-WithRetry @invokeWithRetryParams
                Write-Verbose ("[$($MyInvocation.MyCommand)] Confirmed preview version exists: $($semver.SemVerString) (HTTP 200)")
            }
            catch {
                # Re-throw the error (it already has appropriate messaging from the status code handling)
                throw
            }
            
            Write-Verbose ("[$($MyInvocation.MyCommand)] Using preview version: $($semver.SemVerString)")
            return $semver
        }
        
        # Handle exact version strings (standard 3-part versions)
        try {
            $exactVersion = [Version]$Version
            
            # Validate 3-part version format (allow 4-part if Revision is 0)
            if ($exactVersion.Revision -ne -1 -and $exactVersion.Revision -ne 0) {
                $PSCmdlet.ThrowTerminatingError(
                    [System.Management.Automation.ErrorRecord]::new(
                        ([System.ArgumentException]"Invalid $Name version format: $Version. $Name versions must be 3-part (Major.Minor.Build) or 4-part with .0 as the last part (Major.Minor.Build.0)."),
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
