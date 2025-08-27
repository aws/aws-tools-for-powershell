<#
.Synopsis
    Downloads and parses SHA512 hash files from remote URLs.

.Description
    This function downloads .sha512 files from URLs using the existing HTTP infrastructure
    and extracts the hash value. It validates that the hash is in the correct format
    (128 hexadecimal characters) and handles various network errors with appropriate
    retry logic.

.Parameter Url
    The URL of the .sha512 file to download.

.Parameter TimeoutSec
    Timeout in seconds for the download operation. Defaults to the SHA512Validation.TimeoutSec
    value from configuration.

.Example
    $hash = Get-SHA512Hash -Url "https://example.com/file.zip.sha512"
    
    Downloads the SHA512 hash file from the specified URL and returns the hash value.

.Notes
    This function is used internally by Test-FileIntegrity to obtain expected hash values
    for file validation.
#>
function Get-SHA512Hash {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string]$Url,
        
        [Parameter()]
        [int]$TimeoutSec = $script:Config.network.SHA512Validation.TimeoutSec
    )

    Begin {
        Write-Debug "[$($MyInvocation.MyCommand)] Begin - Url=$Url TimeoutSec=$TimeoutSec"
    }

    Process {
        Write-Verbose "[$($MyInvocation.MyCommand)] Downloading SHA512 hash from: $Url"
        
        # Create a temporary file to store the hash content
        $tempPath = [System.IO.Path]::GetTempPath()
        $tempFile = [System.IO.Path]::Combine($tempPath, [System.IO.Path]::GetRandomFileName())
        
        try {
            # Use standard download retry settings for hash files
            $maxRetries = $script:Config.network.SHA512Validation.RetryCount
            $baseDelay = $script:Config.retry.DownloadBaseDelaySeconds
            
            # Use HTTP status code-based retry logic with enhanced error reporting
            $invokeWithRetryParams = @{
                ScriptBlock = {
                    $response = Invoke-WebRequestWithStatusHandling -Uri $Url -OutFile $tempFile -TimeoutSec $TimeoutSec
                    
                    if (-not $response.Success) {
                        # Use custom error messages for download operations
                        $customMessages = @{
                            404 = "SHA512 hash file not found at URL: $Url"
                            403 = "Access denied when downloading SHA512 hash file from: $Url"
                            503 = "Service temporarily unavailable when downloading SHA512 hash file. This is usually temporary."
                        }
                        
                        Get-HttpStatusErrorMessage -Response $response -Operation "downloading SHA512 hash file" -CustomMessages $customMessages
                    }
                    
                    Write-Verbose "[$($MyInvocation.MyCommand)] Successfully downloaded SHA512 hash file (HTTP $($response.StatusCode))"
                    return $response
                }
                MaxRetries = $maxRetries
                BaseDelaySeconds = $baseDelay
                OperationName = "Download SHA512 hash file"
                RetryableExceptions = $script:Config.retry.RetryableExceptions.Network
            }
            
            $response = Invoke-WithRetry @invokeWithRetryParams
            
            # Read the hash content from the temporary file
            if (Test-Path $tempFile) {
                $hashContent = Get-Content -Path $tempFile -Raw
                
                # Remove any whitespace, newlines, or carriage returns
                $hashContent = $hashContent.Trim()
                
                # Validate the hash format (128 hexadecimal characters)
                if ($hashContent -match '^[0-9a-fA-F]{128}$') {
                    Write-Verbose "[$($MyInvocation.MyCommand)] Valid SHA512 hash found: $hashContent"
                    return $hashContent
                }
                else {
                    throw [System.ArgumentException]::new(
                        "Invalid SHA512 hash format in file '$Url'. Expected 128 hexadecimal characters, got: '$hashContent'"
                    )
                }
            }
            else {
                throw [System.IO.FileNotFoundException]::new(
                    "SHA512 hash file not found at temporary location after download: $tempFile"
                )
            }
        }
        finally {
            # Clean up the temporary file
            if (Test-Path $tempFile) {
                Remove-Item -Path $tempFile -Force -ErrorAction SilentlyContinue
            }
        }
    }

    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}
