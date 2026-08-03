<#
.Synopsis
    Updates all currently installed AWS.Tools modules from PowerShell Gallery (Legacy compatibility).

.Description
    This cmdlet uses Install-Module to update all AWS.Tools modules from PowerShell Gallery.

    This is a legacy compatibility cmdlet that replicates the behavior of AWS.Tools.Installer 1.0.3.
    For new installations, consider using Update-AWSToolsModule which uses CloudFront distribution for improved reliability.

.Notes
    This cmdlet uses the PSRepository named PSGallery as source.
    Use 'Get-PSRepository -Name PSGallery' for information on the PSRepository used by Update-AWSToolsModuleV1.
    This cmdlet downloads all modules from https://www.powershellgallery.com/api/v2/package/ and considers it a trusted source.

.Example
    Update-AWSToolsModuleV1 -CleanUp

    This example updates all installed AWS.Tools modules to the latest version available on the PSGallery and uninstalls all other versions.
#>
function Update-AWSToolsModuleV1 {
    [CmdletBinding(SupportsShouldProcess, ConfirmImpact = 'High')]
    Param(
        ## Specifies the exact version of the modules to update to.
        [Parameter(ValueFromPipelineByPropertyName, Position = 0)]
        [Version]
        $RequiredVersion,

        ## Specifies the maximum version of the modules to update to.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Version]
        $MaximumVersion,

        ## Specifies that, after a successful install, all other versions of the AWS Tools modules should be uninstalled.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Switch]
        $CleanUp,
		
        ## Allows skipping the publisher validation check.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Switch]
        $SkipPublisherCheck,			

        ## Specifies the installation scope of the module. The acceptable values for this parameter are AllUsers and CurrentUser.
        ## The AllUsers scope installs modules in a location that is accessible to all users of the computer:
        ##  $env:ProgramFiles\PowerShell\Modules
        ## The CurrentUser installs modules in a location that is accessible only to the current user of the computer:
        ##  $home\Documents\PowerShell\Modules
        ## When no Scope is defined, the default is CurrentUser.
        [Parameter(ValueFromPipelineByPropertyName)]
        [ValidateSet('CurrentUser', 'AllUsers')]
        [string]
        $Scope = 'CurrentUser',

        ## Overrides warning messages about installation conflicts about existing commands on a computer.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Switch]
        $AllowClobber,

        ## Specifies a proxy server for the request, rather than connecting directly to an internet resource.
        [Parameter(ValueFromPipelineByPropertyName)]
        [Uri]
        $Proxy,

        ## Specifies a user account that has permission to use the proxy server specified by the Proxy parameter.
        [Parameter(ValueFromPipelineByPropertyName)]
        [PSCredential]
        $ProxyCredential,

        ## Forces an update of each specified module without a prompt to request confirmation
        [Parameter(ValueFromPipelineByPropertyName)]
        [Switch]
        $Force
    )

    Begin {
        # Deprecation warning
        Write-Warning "Update-AWSToolsModuleV1 is deprecated. Please use Update-AWSToolsModule instead, which provides improved reliability through CloudFront distribution and faster installation speeds."
        
        $RequiredVersion = Get-CleanVersion $RequiredVersion
        $MaximumVersion = Get-CleanVersion $MaximumVersion

        Write-Verbose "[$($MyInvocation.MyCommand)] ConfirmPreference=$ConfirmPreference WhatIfPreference=$WhatIfPreference VerbosePreference=$VerbosePreference Force=$Force"
    }

    Process {
        $ErrorActionPreference = 'Stop'

        Write-Verbose "[$($MyInvocation.MyCommand)] Searching installed modules"
        [PSModuleInfo[]]$installedAwsToolsModules = Get-AWSToolsModule -SkipIfInvalidSignature
        [string[]]$installedAwsToolsModuleNames = $installedAwsToolsModules | Select-Object -Expand Name | Sort-Object -Unique

        if ($installedAwsToolsModuleNames) {
            Write-Verbose "[$($MyInvocation.MyCommand)] Found modules ($installedAwsToolsModuleNames)"

            $installAWSToolsModuleParams = @{
                Name            = $installedAwsToolsModuleNames
                RequiredVersion = $RequiredVersion
                MaximumVersion  = $MaximumVersion
                Scope           = $Scope
                AllowClobber    = $AllowClobber
                CleanUp         = $CleanUp
                Force           = $Force
                SkipUpdate      = $true
                Proxy           = $Proxy
                ProxyCredential = $ProxyCredential
				SkipPublisherCheck = $SkipPublisherCheck
            }
            Install-AWSToolsModuleV1 @installAWSToolsModuleParams
        }
    }

    End {
        Write-Verbose "[$($MyInvocation.MyCommand)] End"
    }
}
