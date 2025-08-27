<#
.Synopsis
    Resolves the source for CloudFront-hosted zip files.

.Description
    Either uses a local zip file path or downloads the zip file from CloudFront
    to a temporary location. Supports both AWS.Tools and AWS.Tools.Installer.

.Parameter Name
    Specifies which zip file to resolve. Valid values are 'AWS.Tools' or 'AWS.Tools.Installer'.
    Defaults to 'AWS.Tools' for backward compatibility.

.Parameter Version
    Specific version to download. If not specified, downloads latest.

.Parameter SourceZipPath
    Path to local zip file. If specified, validates and returns this path.

.Parameter TempDir
    Temporary directory for downloading zip file.

.Parameter Timeout
    Network operation timeout in seconds.

.Parameter SkipIntegrityCheck
    Switch that bypasses SHA512 validation when specified. By default, SHA512 validation is performed
    to ensure the integrity of downloaded files.

.Parameter SourceHashPath
    Local path to SHA512 hash file. When provided, uses this file for validation instead of downloading
    the hash file from the remote server.
#>
function Resolve-AWSToolsZipSource {
    [CmdletBinding()]
    param(
        [Parameter()]
        [ValidateSet('AWS.Tools', 'AWS.Tools.Installer')]
        [string]
        $Name = 'AWS.Tools',
        
        [Parameter()]
        [Version]$Version,
        
        [Parameter()]
        [string]$SourceZipPath,
        
        [Parameter(Mandatory)]
        [string]$TempDir,
        
        [Parameter()]
        [int]$Timeout = $script:Config.network.DefaultTimeout,
        
        [Parameter()]
        [switch]
        $SkipIntegrityCheck,
        
        [Parameter()]
        [string]
        $SourceHashPath
    )
    
    Begin {
        Write-Debug ("[$($MyInvocation.MyCommand)] Begin - Name=$Name Version=$Version " +
            "SourceZipPath=$SourceZipPath TempDir=$TempDir Timeout=$Timeout")
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
        
        if ($SourceZipPath) {
            Test-ParameterValidation -Path $SourceZipPath -PathMustExist -Timeout $Timeout
            
            if ([System.IO.Path]::GetExtension($SourceZipPath) -ne '.zip') {
                $PSCmdlet.ThrowTerminatingError(
                    [System.Management.Automation.ErrorRecord]::new(
                        ([System.ArgumentException]"SourceZipPath must be a .zip file: $SourceZipPath"),
                        'InvalidZipExtension',
                        [System.Management.Automation.ErrorCategory]::InvalidArgument,
                        $SourceZipPath
                    )
                )
            }
            
            # Validate that the zip file name matches expected pattern for the module type
            $expectedFileName = $moduleConfig.ZipFileName
            $actualFileName = [System.IO.Path]::GetFileName($SourceZipPath)
            if ($actualFileName -ne $expectedFileName) {
                Write-Warning "Local zip file name '$actualFileName' does not match expected '$expectedFileName' for module type '$Name'"
            }
            
            return $SourceZipPath
        }
        
        $zipPath = Join-Path $TempDir $moduleConfig.ZipFileName
        
        $getZipParams = @{
            Name = $Name
            Path = $zipPath
            Timeout = $Timeout
        }
        
        if ($Version) {
            $getZipParams.Version = $Version
        }
        
        if ($PSBoundParameters.ContainsKey('SkipIntegrityCheck')) {
            $getZipParams.SkipIntegrityCheck = $SkipIntegrityCheck
        }
        
        if ($SourceHashPath) {
            $getZipParams.SourceHashPath = $SourceHashPath
        }
        
        # Call Get-AWSToolsZip and ensure it completes successfully
        $null = Get-AWSToolsZip @getZipParams
        
        # Verify the zip file exists before returning
        # Use LiteralPath to handle special characters in paths
        if (-not (Test-Path -LiteralPath $zipPath)) {
            $PSCmdlet.ThrowTerminatingError(
                [System.Management.Automation.ErrorRecord]::new(
                    ([System.IO.FileNotFoundException]"Zip file not found at path: $zipPath. Download may have failed."),
                    'ZipFileNotFound',
                    [System.Management.Automation.ErrorCategory]::ObjectNotFound,
                    $zipPath
                )
            )
        }
        
        Write-Verbose "[$($MyInvocation.MyCommand)] Resolved ZIP path: $zipPath"
        return $zipPath
    }

    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}
