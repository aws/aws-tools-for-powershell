<#
.Synopsis
    Downloads CloudFront-hosted zip files for AWS Tools module installation.

.Description
    This function downloads zip files from the AWS CloudFront distribution for both AWS.Tools 
    modules and AWS.Tools.Installer. It supports both latest and version-specific downloads.

.Parameter Name
    Specifies which zip file to download. Valid values are 'AWS.Tools' or 'AWS.Tools.Installer'.
    Defaults to 'AWS.Tools' for backward compatibility.

.Parameter Version
    Specifies a version to download. Accepts exact versions (4.1.754) or major versions. Latest 
    version is downloaded by default.

.Parameter Path
    The destination path where the zip file will be saved.

.Parameter Timeout
    Network operation timeout in seconds.

.Parameter SkipIntegrityCheck
    Switch that bypasses SHA512 validation when specified. By default, SHA512 validation is performed
    to ensure the integrity of downloaded files.

.Parameter SourceHashPath
    Local path to SHA512 hash file. When provided, uses this file for validation instead of downloading
    the hash file from the remote server.

.Notes
    This function is used internally by Install-AWSToolsModule and Install-AWSToolsInstaller 
    to acquire zip files. It sources modules from the AWS CloudFront-hosted distribution for 
    improved speed and reliability.

.Example
    Get-AWSToolsZip -Path "C:\temp\AWS.Tools.zip"

    This example downloads the latest AWS.Tools.zip from CloudFront to the specified path.

.Example
    Get-AWSToolsZip -Name "AWS.Tools.Installer" -Path "C:\temp\AWS.Tools.Installer.zip"

    This example downloads the latest AWS.Tools.Installer.zip from CloudFront.

.Example
    Get-AWSToolsZip -Name "AWS.Tools" -Version "4.1.754" -Path "C:\temp\AWS.Tools.zip"

    This example downloads exact version 4.1.754 of AWS.Tools.zip from CloudFront releases endpoint.
#>
function Get-AWSToolsZip {
    [CmdletBinding()]
    param(
        [Parameter()]
        [ValidateSet('AWS.Tools', 'AWS.Tools.Installer')]
        [string]
        $Name = 'AWS.Tools',

        [Parameter()]
        [Version]
        $Version,

        [Parameter(Mandatory)]
        [string]
        $Path,

        [Parameter()]
        [int]
        $Timeout = $script:Config.network.DefaultTimeout,
        
        [Parameter()]
        [switch]
        $SkipIntegrityCheck,
        
        [Parameter()]
        [string]
        $SourceHashPath
    )

    Begin {
        Write-Debug ("[$($MyInvocation.MyCommand)] Begin - Name=$Name Version=$Version " +
            "Path=$Path Timeout=$Timeout")
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
        
        # Build the download URL based on version and module type
        $baseUrl = $script:Config.general.CloudFront.BaseUrl
        $cloudFrontPath = $script:Config.general.CloudFront.Paths[$Name.Replace('.', '')]
        
        if ($Version) {
            $versionString = "$($Version.Major).$($Version.Minor).$($Version.Build)"
            $majorVersion = $Version.Major
            Write-Verbose ("[$($MyInvocation.MyCommand)] Using CloudFront source for exact " +
                "version: $versionString")
            
            $zipSource = $moduleConfig.CloudFrontUrls.ZipDownloadUrlVersionPattern `
                -replace '\{baseUrl\}', $baseUrl `
                -replace '\{path\}', $cloudFrontPath `
                -replace '\{majorVersion\}', $majorVersion `
                -replace '\{version\}', $versionString
        }
        else {
            $majorVersion = $moduleConfig.DefaultMajorVersion
            Write-Verbose ("[$($MyInvocation.MyCommand)] Using CloudFront source for latest version")
            
            $zipSource = $moduleConfig.CloudFrontUrls.ZipDownloadUrlPattern `
                -replace '\{baseUrl\}', $baseUrl `
                -replace '\{path\}', $cloudFrontPath `
                -replace '\{majorVersion\}', $majorVersion
        }
        
        Write-Verbose "[$($MyInvocation.MyCommand)] Downloading $($moduleConfig.ZipFileName) from CloudFront..."
        
        # Use standard download retry settings for all module types
        $maxRetries = $script:Config.retry.DownloadMaxRetries
        $baseDelay = $script:Config.retry.DownloadBaseDelaySeconds
        
        # Use HTTP status code-based retry logic with enhanced error reporting
        $invokeWithRetryParams = @{
            ScriptBlock = {
                Write-Verbose "[$($MyInvocation.MyCommand)] Downloading from URL: $zipSource to $Path"
                $response = Invoke-WebRequestWithStatusHandling -Uri $zipSource -OutFile $Path -TimeoutSec $Timeout
                
                if (-not $response.Success) {
                    # Use custom error messages for download operations
                    $customMessages = @{
                        404 = "$($moduleConfig.ZipFileName) file not found at CloudFront URL. The specified version may not exist."
                        403 = "Access denied when downloading $($moduleConfig.ZipFileName) from CloudFront."
                        503 = "CloudFront service temporarily unavailable. This is usually temporary."
                    }
                    
                    Get-HttpStatusErrorMessage -Response $response -Operation "downloading $($moduleConfig.ZipFileName)" -CustomMessages $customMessages
                }
                
                # Verify the file was downloaded
                if (-not (Test-Path -Path $Path)) {
                    $PSCmdlet.ThrowTerminatingError(
                        [System.Management.Automation.ErrorRecord]::new(
                            ([System.IO.FileNotFoundException]"Failed to download $($moduleConfig.ZipFileName) to $Path. File does not exist after download."),
                            'DownloadFileNotFound',
                            [System.Management.Automation.ErrorCategory]::ObjectNotFound,
                            $Path
                        )
                    )
                }
                
                Write-Verbose "[$($MyInvocation.MyCommand)] Successfully downloaded $($moduleConfig.ZipFileName) (HTTP $($response.StatusCode))"
            }
            MaxRetries = $maxRetries
            BaseDelaySeconds = $baseDelay
            OperationName = "Download $($moduleConfig.ZipFileName)"
            RetryableExceptions = $script:Config.retry.RetryableExceptions.Network
        }
        Invoke-WithRetry @invokeWithRetryParams
        
        # Perform SHA512 integrity validation if not skipped
        if (-not $SkipIntegrityCheck) {
            Write-Verbose "[$($MyInvocation.MyCommand)] Performing SHA512 integrity validation for $($moduleConfig.ZipFileName)"
            
            try {
                $testIntegrityParams = @{
                    FilePath = $Path
                }
                
                # Use either local hash file or download from URL
                if ($SourceHashPath) {
                    $testIntegrityParams.SourceHashPath = $SourceHashPath
                    Write-Verbose "[$($MyInvocation.MyCommand)] Using local SHA512 hash file: $SourceHashPath"
                }
                else {
                    $testIntegrityParams.BaseUrl = $zipSource
                    Write-Verbose "[$($MyInvocation.MyCommand)] Using remote SHA512 hash URL: $zipSource.sha512"
                }
                
                # Validate file integrity
                Test-FileIntegrity @testIntegrityParams
                
                Write-Verbose "[$($MyInvocation.MyCommand)] SHA512 integrity validation successful for $($moduleConfig.ZipFileName)"
            }
            catch {
                # Delete the downloaded file if validation fails
                if (Test-Path -Path $Path) {
                    Remove-Item -Path $Path -Force -ErrorAction SilentlyContinue
                }
                
                # Rethrow the exception
                throw
            }
        }
        else {
            Write-Verbose "[$($MyInvocation.MyCommand)] Skipping SHA512 integrity validation as requested"
        }
    }

    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}
