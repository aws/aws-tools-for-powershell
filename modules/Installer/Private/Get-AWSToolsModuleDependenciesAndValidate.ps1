<#
.Synopsis
    Validates AWS Tools module manifest and extracts dependencies.

.Description
    Validates the digital signature of an AWS Tools module manifest file within a zip archive
    and extracts the list of required module dependencies.

.Parameter Path
    Path to the zip file containing the module manifest to validate.

.Parameter Name
    Name of the module whose manifest should be validated.

.Notes
    This function performs signature validation on Windows systems and checks for minimum
    AWS.Tools.Installer version requirements.
#>
function Get-AWSToolsModuleDependenciesAndValidate {
    Param(
        [Parameter(ValueFromPipelineByPropertyName, Mandatory)]
        [string]
        $Path,

        [Parameter(ValueFromPipelineByPropertyName, Mandatory)]
        [string]
        $Name
    )

    Begin {
        Write-Verbose ("[$($MyInvocation.MyCommand)] ConfirmPreference=$ConfirmPreference " +
            "WhatIfPreference=$WhatIfPreference VerbosePreference=$VerbosePreference " +
            "Name=$Name Path=$Path")
    }

    Process {
        $ErrorActionPreference = 'Stop'

        Add-Type -AssemblyName System.IO.Compression.FileSystem -ErrorAction Stop
        Add-Type -AssemblyName System.IO.Compression -ErrorAction Stop

        [Stream]$manifestFileStream = $null
        [Stream]$entryStream = $null
        [ZipArchive]$zipArchive = $null
        [string]$temporaryManifestFilePath = $null

        try {
            $zipArchive = [ZipFile]::OpenRead($Path)
            [ZipArchiveEntry]$entry = $zipArchive.GetEntry("$($Name).psd1")
            $entryStream = $entry.Open()
            $temporaryManifestFilePath = Join-Path ([Path]::GetTempPath()) 
                "$([Path]::GetRandomFileName()).psd1"
            $manifestFileStream = [File]::OpenWrite($temporaryManifestFilePath)
            $entryStream.CopyTo($manifestFileStream)
            $manifestFileStream.Close();

            if ($PSVersionTable.PSVersion.Major -lt $script:Config.versions.PowerShell.PowerShellCoreMinimumMajorVersion -or $IsWindows) {
                $getAuthenticodeSignatureParams = @{
                    FilePath = $temporaryManifestFilePath
                }
                $manifestSignature = Microsoft.PowerShell.Security\Get-AuthenticodeSignature @getAuthenticodeSignatureParams
                
                $validStatus = ($manifestSignature.Status -eq 'Valid')
                $validSubject = (
                    $manifestSignature.SignerCertificate.Subject -eq $script:Config.signatures.ValidSubjects[0] -or
                    $manifestSignature.SignerCertificate.Subject -eq $script:Config.signatures.ValidSubjects[1] -or
                    $manifestSignature.SignerCertificate.Subject.StartsWith($script:Config.signatures.ValidSubjects[2])
                )
                
                if ($validStatus -and $validSubject) {
                    Write-Verbose "[$($MyInvocation.MyCommand)] Manifest signature correctly validated"
                }
                else {
                    $PSCmdlet.ThrowTerminatingError(
                        [System.Management.Automation.ErrorRecord]::new(
                            ([System.Security.Cryptography.CryptographicException]"Error validating manifest signature for $($Name)"),
                            'ManifestSignatureValidationFailure',
                            [System.Management.Automation.ErrorCategory]::SecurityError,
                            $Name
                        )
                    )
                }
            }
            else {
                Write-Verbose ("[$($MyInvocation.MyCommand)] Authenticode signature can only be " +
                    "verified on Windows, skipping")
            }

            [PSObject]$manifestData = Microsoft.PowerShell.Utility\Import-PowerShellDataFile 
                $temporaryManifestFilePath

            if ($manifestData.PrivateData.ContainsKey('MinAWSToolsInstallerVersion')) {
                [Version]$minVersion = Get-CleanVersion 
                    $manifestData.PrivateData.MinAWSToolsInstallerVersion
                if ($minVersion -gt $script:Config.versions.CurrentMinInstallerVersion) {
                    $PSCmdlet.ThrowTerminatingError(
                        [System.Management.Automation.ErrorRecord]::new(
                            ([System.InvalidOperationException]"$Name version $($manifestData.ModuleVersion) requires at least AWS.Tools.Installer version $minVersion. Run 'Update-Module AWS.Tools.Installer'."),
                            'InsufficientInstallerVersion',
                            [System.Management.Automation.ErrorCategory]::InvalidOperation,
                            $minVersion
                        )
                    )
                }
            }

            $manifestData.RequiredModules | ForEach-Object {
                Write-Verbose "[$($MyInvocation.MyCommand)] Found dependency $($_.ModuleName)"
                $_.ModuleName
            }
        }
        finally {
            if ($manifestFileStream) {
                $manifestFileStream.Dispose()
            }
            if ($entryStream) {
                $entryStream.Dispose()
            }
            if ($zipArchive) {
                $zipArchive.Dispose()
            }
            if ($temporaryManifestFilePath) {
                $removeItemParams = @{
                    Path = $temporaryManifestFilePath
                    WhatIf = $false
                }
                # Temporarily suppress progress just for this operation
                $savedProgressPreference = $ProgressPreference
                $ProgressPreference = 'SilentlyContinue'
                try {
                    Microsoft.PowerShell.Management\Remove-Item @removeItemParams
                }
                finally {
                    $ProgressPreference = $savedProgressPreference
                }
            }
        }
    }

    End {
        Write-Verbose "[$($MyInvocation.MyCommand)] End"
    }
}
