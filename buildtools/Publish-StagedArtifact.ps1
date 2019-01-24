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

    To publish to the gallery an api key, similar to NuGet, is required. The key is available
    in Secrets Manager.

.EXAMPLE
    Publish-StagedArtifactsToPSGallery -ApiKey abcde-fghi-kjlm-nopq

	Publishes both modules to the gallery.

.EXAMPLE
    Publish-StagedArtifactsToPSGallery -ApiKey abcde-fghi-kjlm-nopq -DryRun

    Displays the changelog notes and file paths the script would operate on, but does not
    push the modules to the gallery.
#>

[CmdletBinding()]
Param
(
    [Parameter(Mandatory=$true, HelpMessage="The name of the Secrets Manager secret containing the PowerShell Gallery key.")]
    [ValidateNotNullOrEmpty()]
    [string]$SecretId,

    [Parameter(Mandatory=$true, HelpMessage="The AWS region where the PowerShell Gallery key is available from Secrets Manager.")]
    [ValidateNotNullOrEmpty()]
    [string]$SecretRegion,
    
    [Parameter(Mandatory=$true, HelpMessage="The AWS profile to use to retrieve the PowerShell Gallery key from Secrets Manager.")]
    [ValidateNotNullOrEmpty()]
    [string]$SecretReaderProfile,
    
    [Parameter(Mandatory=$true, HelpMessage="The name of entry of the PowerShell Gallery key in the Secret Manager secret.")]
    [ValidateNotNullOrEmpty()]
    [string]$SecretKey,

	[Parameter()]
	[switch]$DryRun
)

Import-Module -Name "PowerShellGet"

$currentLocation = (Get-Location).Path
$awsPowerShellModuleLocation = Join-Path $currentLocation "AWSPowerShell"
$awsPowerShellCoreModuleLocation = Join-Path $currentLocation "AWSPowerShell.NetCore"

if (!(Test-Path $awsPowerShellModuleLocation)) {
    throw "Expected path $awsPowerShellModuleLocation does not exist"
}
if (!(Test-Path $awsPowerShellCoreModuleLocation)) {
    throw "Expected path $awsPowerShellCoreModuleLocation does not exist"
}

$ApiKey = ((Get-SECSecretValue -SecretId $SecretId -Region $SecretRegion -ProfileName $SecretReaderProfile).SecretString | ConvertFrom-Json).$SecretKey

$commonArgs = @{
    'NuGetApiKey'=$ApiKey
    'Repository'="PSGallery"
}

Write-Host "Publishing the AWS Tools for Windows PowerShell module from $awsPowerShellModuleLocation"
if (!($DryRun)) {
	Publish-Module -Path $awsPowerShellModuleLocation @commonArgs -Verbose -Force
} else {
	Write-Host "-DryRun specified, skipped actual publish"
}

Write-Host "Publishing the AWS Tools for PowerShell module from $awsPowerShellCoreModuleLocation"
if (!($DryRun)) {
	Publish-Module -Path $awsPowerShellCoreModuleLocation @commonArgs -Verbose -Force
} else {
	Write-Host "-DryRun specified, skipped actual publish"
}
