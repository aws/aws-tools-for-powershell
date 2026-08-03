<#
.Synopsis
    Validates file integrity using SHA512 hash comparison.

.Description
    This function validates the integrity of a file by comparing its SHA512 hash against an expected hash.
    The expected hash can be provided either from a local file (SourceHashPath) or downloaded from a URL
    constructed by appending .sha512 to the BaseUrl. It uses PowerShell's built-in Get-FileHash cmdlet
    to calculate the actual hash of the file.

.Parameter FilePath
    Path to the file to validate.

.Parameter BaseUrl
    Base URL for constructing SHA512 file URL (optional if SourceHashPath provided).
    The SHA512 file URL is constructed by appending .sha512 to this URL.

.Parameter SourceHashPath
    Local path to SHA512 hash file (optional, used instead of downloading).

.Parameter TimeoutSec
    Timeout in seconds for downloading the SHA512 hash file. Defaults to the SHA512Validation.TimeoutSec
    value from configuration.

.Example
    Test-FileIntegrity -FilePath "C:\temp\AWS.Tools.zip" -BaseUrl "https://example.com/AWS.Tools.zip"
    
    Validates the integrity of AWS.Tools.zip by downloading the hash from https://example.com/AWS.Tools.zip.sha512
    and comparing it with the calculated hash of the local file.

.Example
    Test-FileIntegrity -FilePath "C:\temp\AWS.Tools.zip" -SourceHashPath "C:\temp\AWS.Tools.zip.sha512"
    
    Validates the integrity of AWS.Tools.zip using a local hash file instead of downloading.

.Notes
    This function throws descriptive exceptions when validation fails, including both the expected
    and actual hash values for troubleshooting.
#>
function Test-FileIntegrity {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string]$FilePath,
        
        [Parameter(Mandatory = $false)]
        [string]$BaseUrl,
        
        [Parameter(Mandatory = $false)]
        [string]$SourceHashPath,
        
        [Parameter(Mandatory = $false)]
        [int]$TimeoutSec = $script:Config.network.SHA512Validation.TimeoutSec
    )

    Begin {
        Write-Debug ("[$($MyInvocation.MyCommand)] Begin - FilePath=$FilePath BaseUrl=$BaseUrl " +
            "SourceHashPath=$SourceHashPath TimeoutSec=$TimeoutSec")
    }

    Process {
        # Verify the file to validate exists
        if (-not (Test-Path -Path $FilePath)) {
            throw [System.IO.FileNotFoundException]::new(
                "File not found for integrity validation: $FilePath"
            )
        }
        
        # Get the expected hash either from local file or by downloading
        $expectedHash = $null
        
        if ($SourceHashPath) {
            Write-Verbose "[$($MyInvocation.MyCommand)] Reading SHA512 hash from local file: $SourceHashPath"
            
            if (-not (Test-Path -Path $SourceHashPath)) {
                throw [System.IO.FileNotFoundException]::new(
                    "SHA512 hash file not found at specified path: $SourceHashPath"
                )
            }
            
            try {
                $hashContent = Get-Content -Path $SourceHashPath -Raw -ErrorAction Stop
                
                # Remove any whitespace, newlines, or carriage returns
                $hashContent = $hashContent.Trim()
                
                # Validate the hash format (128 hexadecimal characters)
                if ($hashContent -match '^[0-9a-fA-F]{128}$') {
                    $expectedHash = $hashContent
                    Write-Verbose "[$($MyInvocation.MyCommand)] Valid SHA512 hash found in local file: $expectedHash"
                }
                else {
                    throw [System.ArgumentException]::new(
                        "Invalid SHA512 hash format in file '$SourceHashPath'. Expected 128 hexadecimal characters, got: '$hashContent'"
                    )
                }
            }
            catch {
                throw [System.IO.IOException]::new(
                    "Failed to read SHA512 hash from file '$SourceHashPath': $($_.Exception.Message)",
                    $_.Exception
                )
            }
        }
        elseif ($BaseUrl) {
            Write-Verbose "[$($MyInvocation.MyCommand)] Constructing SHA512 hash URL from base URL: $BaseUrl"
            
            # Construct the SHA512 file URL by appending .sha512 to the base URL
            $hashUrl = "$BaseUrl.sha512"
            
            try {
                # Download and parse the SHA512 hash
                $expectedHash = Get-SHA512Hash -Url $hashUrl -TimeoutSec $TimeoutSec
                Write-Verbose "[$($MyInvocation.MyCommand)] Downloaded SHA512 hash: $expectedHash"
            }
            catch {
                throw [System.Net.WebException]::new(
                    "Failed to download SHA512 hash from '$hashUrl': $($_.Exception.Message)",
                    $_.Exception
                )
            }
        }
        else {
            throw [System.ArgumentException]::new(
                "Either BaseUrl or SourceHashPath must be provided for integrity validation"
            )
        }
        
        # Calculate the actual hash of the file
        Write-Verbose "[$($MyInvocation.MyCommand)] Calculating SHA512 hash of file: $FilePath"
        
        try {
            $fileHash = Get-FileHash -Path $FilePath -Algorithm SHA512 -ErrorAction Stop
            $actualHash = $fileHash.Hash.ToLower()
            Write-Verbose "[$($MyInvocation.MyCommand)] Calculated SHA512 hash: $actualHash"
        }
        catch {
            throw [System.IO.IOException]::new(
                "Failed to calculate SHA512 hash for file '$FilePath': $($_.Exception.Message)",
                $_.Exception
            )
        }
        
        # Compare the hashes (case-insensitive)
        if ($actualHash -eq $expectedHash.ToLower()) {
            Write-Verbose "[$($MyInvocation.MyCommand)] SHA512 hash validation successful for file: $FilePath"
            return $true
        }
        else {
            Write-Verbose "[$($MyInvocation.MyCommand)] SHA512 hash validation failed for file: $FilePath"
            throw [System.Security.SecurityException]::new(
                "SHA512 hash validation failed for file '$FilePath'. Expected: $expectedHash, Actual: $actualHash"
            )
        }
    }

    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}
