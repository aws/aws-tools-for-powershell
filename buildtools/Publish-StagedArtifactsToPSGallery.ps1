<#
.Synopsis
    Publishes the AWSPowerShell and AWSPowerShell.NetCore modules to the PowerShell Gallery.
.DESCRIPTION
    Publishes the AWS Tools for PowerShell modules (AWSPowerShell and AWSPowerShell.NetCore) to
    the PowerShell Gallery.

.NOTES
    The script must be run in a folder that contains subfolders holding the modules to be published
    (i.e. .\AWSPowerShell and .\AWSPowerShell.NetCore).

    Publishing is done using the Publish-Module cmdlet of the PowerShellGet module. This module
    must be installed (either in user scope or globally) before this script can be used.

    After publishing is complete, login to the gallery (aws-dotnet-sdk-team@ email, password
    is in Odin material set com.aws.dr.awsdrtools.PSGallery) and update the release notes from the
    changelog.md file in the repo. Eventually this step will be automated.

    To publish to the gallery an api key, similar to NuGet, is required. The key is available
    in the Odin material set com.aws.dr.awsdrtools.PSGallery-ApiKey.

.EXAMPLE
    Publish-StagedArtifactsToPSGallery -ApiKey abcde-fghi-kjlm-nopq
#>

[CmdletBinding()]
Param
(
    [Parameter(Mandatory=$true, HelpMessage="The API key required for automated publish to the PowerShell Gallery.")]
    [ValidateNotNullOrEmpty()]
    [string]$ApiKey
)

Import-Module -Name "PowerShellGet"

$commonArgs = @{
    'NuGetApiKey'=$ApiKey
    'Repository'="PSGallery"
    'Tags'="AWS"
    'IconUri'="https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png"
}

$currentLocation = (Get-Location).$Path
$awsPowerShellModuleLocation = Join-Path $currentLocation "AWSPowerShell"
$awsPowerShellCoreModuleLocation = Join-Path $currentLocation "AWSPowerShell.NetCore"

if (!(Test-Path $awsPowerShellModuleLocation)) {
    throw "Expected path $awsPowerShellModuleLocation does not exist"
}
if (!(Test-Path $awsPowerShellCoreModuleLocation)) {
    throw "Expected path $awsPowerShellCoreModuleLocation does not exist"
}

Write-Host "Publishing the AWS Tools for Windows PowerShell module from $awsPowerShellModuleLocation"
Publish-Module -Path $awsPowerShellModuleLocation @commonArgs -Verbose -Force

Write-Host "Publishing the AWS Tools for PowerShell module from $awsPowerShellCoreModuleLocation"
Publish-Module -Path $awsPowerShellCoreModuleLocation @commonArgs -Verbose -Force
