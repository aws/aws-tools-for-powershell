<#
.Synopsis
    Gets installed AWS Tools for PowerShell modules.

.Description
    Retrieves a list of installed AWS.Tools modules, optionally filtering by signature validation
    and searching in a specific path.

.Parameter SkipIfInvalidSignature
    Skip signature validation for modules. When specified, modules with invalid signatures will be 
    included.

.Parameter Path
    Specific path to search for AWS Tools modules. When specified, temporarily adds this path to 
    PSModulePath.

.Parameter Name
    Specifies which module type to retrieve. Valid values are 'AWS.Tools' or 'AWS.Tools.Installer'.
    Default is 'AWS.Tools', which excludes the AWS.Tools.Installer module.
    Use 'AWS.Tools.Installer' to specifically retrieve only the AWS.Tools.Installer module.
#>
function Get-AWSToolsModule {
    Param(
        [Parameter()]
        [Switch]
        $SkipIfInvalidSignature,
        
        [Parameter()]
        [String]
        $Path,
        
        [Parameter()]
        [ValidateSet('AWS.Tools', 'AWS.Tools.Installer')]
        [String]
        $Name = 'AWS.Tools'
    )

    Begin {
        Write-Debug ("[$($MyInvocation.MyCommand)] Begin - " +
            "SkipIfInvalidSignature=$SkipIfInvalidSignature Path=$Path Name=$Name")
    }

    Process {
        # Windows Powershell 5.1 has inconistent behavior where Get-Module could return nothing 
        # in %USERPROFILE%\Documents\WindowsPowerShell\Modules.
        if ($Path) {
            $originalPSModulePath = $env:PSModulePath
            $env:PSModulePath = "$Path$([System.IO.Path]::PathSeparator)$env:PSModulePath"
        }
        
        try {
            $getModuleParams = @{
                Name = 'AWS.Tools.*'
                ListAvailable = $true
                Verbose = $false
            }
            [PSModuleInfo[]]$installedAwsToolsModules = Microsoft.PowerShell.Core\Get-Module @getModuleParams
        }
        finally {
            if ($Path) {
                $env:PSModulePath = $originalPSModulePath
            }
        }

        if ($installedAwsToolsModules -and ($PSVersionTable.PSVersion.Major -lt $script:Config.versions.PowerShell.PowerShellCoreMinimumMajorVersion -or $IsWindows)) {
            $installedAwsToolsModules = $installedAwsToolsModules | 
                Where-Object {
                    $getAuthenticodeSignatureParams = @{
                        FilePath = $_.Path
                    }
                    $signature = Microsoft.PowerShell.Security\Get-AuthenticodeSignature @getAuthenticodeSignatureParams
                    
                    $validStatus = ($signature.Status -eq 'Valid' -or $SkipIfInvalidSignature)
                    $validSubject = (
                        $signature.SignerCertificate.Subject -eq $script:Config.signatures.ValidSubjects[0] -or
                        $signature.SignerCertificate.Subject -eq $script:Config.signatures.ValidSubjects[1] -or
                        $signature.SignerCertificate.Subject.StartsWith($script:Config.signatures.ValidSubjects[2])
                    )
                    
                    $validStatus -and $validSubject
                }
        }

        if($installedAwsToolsModules) {
            if ($Name -eq 'AWS.Tools') {
                Write-Verbose "[$($MyInvocation.MyCommand)] Filtering out AWS.Tools.Installer modules"
                $installedAwsToolsModules = $installedAwsToolsModules | 
                    Where-Object { $_.Name -ne 'AWS.Tools.Installer' }
            }
            elseif ($Name -eq 'AWS.Tools.Installer') {
                Write-Verbose "[$($MyInvocation.MyCommand)] Filtering for only AWS.Tools.Installer modules"
                $installedAwsToolsModules = $installedAwsToolsModules | 
                    Where-Object { $_.Name -eq 'AWS.Tools.Installer' }
            }
        }

        $installedAwsToolsModules
    }

    End {
        Write-Debug "[$($MyInvocation.MyCommand)] End"
    }
}
