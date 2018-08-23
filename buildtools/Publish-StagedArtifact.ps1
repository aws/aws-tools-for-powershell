<#
.Synopsis
    Publishes the AWSPowerShell and AWSPowerShell.NetCore modules, with release notes from the
    changelog file, to the PowerShell Gallery.
.DESCRIPTION
    Publishes the AWS Tools for PowerShell modules (AWSPowerShell and AWSPowerShell.NetCore) to
    the PowerShell Gallery. The release notes are read from the changelog file by reading until
    the first blank line is encountered. It is assumed that the validation script, Confirm-StagedArtifact.ps1
    has been run previously to ensure the version indicated in the changelog header line for the
    notes matches the version of the module being published.

.NOTES
    The script must be run in a folder that contains subfolders holding the modules to be published
    (i.e. .\AWSPowerShell and .\AWSPowerShell.NetCore).

    Publishing is done using the Publish-Module cmdlet of the PowerShellGet module. This module
    must be installed (either in user scope or globally) before this script can be used.

    To publish to the gallery an api key, similar to NuGet, is required. The key is available
    in the Odin material set com.aws.dr.awsdrtools.PSGallery-ApiKey.

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
    [Parameter(Mandatory=$true, HelpMessage="The API key required for automated publish to the PowerShell Gallery.")]
    [ValidateNotNullOrEmpty()]
    [string]$ApiKey,

	[Parameter()]
	[switch]$DryRun
)

function _getChangelogNotes([string]$changelog)
{
    $notes = @()

    $allNotes = Get-Content $changelog

    for ($i = 0; $i -le $allNotes.Length; $i++) {
        if ($allNotes[$i].Length -eq 0) {
            break
        } else {
            $notes += $allNotes[$i]
        }
    }

    $notes
}

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

$changelogNotes = _getChangelogNotes (Join-Path $awsPowerShellModuleLocation 'CHANGELOG.md')
Write-Host "Changelog notes for the release:"
$changelogNotes

Write-Host ""

$commonArgs = @{
    'NuGetApiKey'=$ApiKey
    'Repository'="PSGallery"
    'Tags'="AWS"
    'IconUri'="https://sdk-for-net.amazonwebservices.com/images/AWSLogo128x128.png"
    'ReleaseNotes' = $changelogNotes
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
