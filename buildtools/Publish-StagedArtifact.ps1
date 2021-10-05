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
    [Parameter(Mandatory = $true, HelpMessage = "The name of the Secrets Manager secret containing the PowerShell Gallery key.")]
    [ValidateNotNullOrEmpty()]
    [string]$SecretId,

    [Parameter(Mandatory = $true, HelpMessage = "The AWS region where the PowerShell Gallery key is available from Secrets Manager.")]
    [ValidateNotNullOrEmpty()]
    [string]$SecretRegion,
    
    [Parameter(Mandatory = $true, HelpMessage = "The AWS profile to use to retrieve the PowerShell Gallery key from Secrets Manager.")]
    [ValidateNotNullOrEmpty()]
    [string]$SecretReaderProfile,
    
    [Parameter(Mandatory = $true, HelpMessage = "The name of entry of the PowerShell Gallery key in the Secret Manager secret.")]
    [ValidateNotNullOrEmpty()]
    [string]$SecretKey,

    [Parameter(Mandatory = $true, HelpMessage = "The AWS profile to use to update and store PowerShell Gallery package information in the ProfileVersions table.")]
    [ValidateNotNullOrEmpty()]
    [string]$UpdatePackageVersionsProfile,

    [Parameter()]
    [string] $RequiredAWSPowerShellVersionToUse = '4.1.14.0',

    [Parameter()]
    [switch]$DryRun
)

$ErrorActionPreference = "Stop"

Import-Module -Name "PowerShellGet"

#Import DynamoDBv2 needed to update the PackageVersions table.
if (-not (Get-Module -ListAvailable -Name AWS.Tools.DynamoDBv2 | Where-Object { $_.Version -eq $RequiredAWSPowerShellVersionToUse })) {
    Write-Host "Installing AWS.Tools.DynamoDBv2 $RequiredAWSPowerShellVersionToUse"
    Install-Module -Name AWS.Tools.DynamoDBv2 -RequiredVersion $RequiredAWSPowerShellVersionToUse -Force
  }
  Import-Module -Name AWS.Tools.DynamoDBv2 -RequiredVersion $RequiredAWSPowerShellVersionToUse

Import-Module $PSScriptRoot/Update-ModulePackageVersion.psm1

$alreadyImportedModules = New-Object System.Collections.Generic.HashSet[string]

$currentLocation = (Get-Location).Path
$awsPowerShellModuleLocation = Join-Path $currentLocation "AWSPowerShell"
$awsPowerShellCoreModuleLocation = Join-Path $currentLocation "AWSPowerShell.NetCore"
$awsPowerShellModularModulesLocation = Join-Path $currentLocation "AWS.Tools"

if (-not $DryRun) {
    $ApiKey = ((Get-SECSecretValue -SecretId $SecretId -Region $SecretRegion -ProfileName $SecretReaderProfile).SecretString | ConvertFrom-Json).$SecretKey
}

$commonArgs = @{
    'NuGetApiKey' = $ApiKey
    'Repository'  = "PSGallery"
}

function PublishRecursive([string]$modulePath) {
    Write-Host "Analyzing $modulePath for publishing"

    if (-not (Test-Path $modulePath)) {
        throw "Expected path $modulePath does not exist"
    }

    $manifest = Get-ChildItem $modulePath -File -Filter *.psd1

    if ($manifest.Count -ne 1) {
        throw "Found $($manifest.Count) .psd1 files in $modulePath"
    }

    if ($alreadyImportedModules.Add($manifest.Name)) {
        $manifestData = Import-PowerShellDataFile $manifest.FullName
        
        foreach ($dependency in $manifestData.RequiredModules.ModuleName) {
            if ($dependency -like 'AWS.Tools.*') {
                $dependencyPath = Resolve-Path "$modulePath/../$dependency"
                PublishRecursive $dependencyPath
            }
        }

        #https://github.com/PowerShell/PowerShellGet/issues/523 Work around PowerShell Gallery eventual consistency
        $maxPublishRetries = 5
        for ($i = 0; $i -lt $maxPublishRetries; $i++) {
            try {
                Write-Host "Publishing $modulePath"
                if ($DryRun) {
                    Write-Host "-DryRun specified, skipped actual publish and PackageVersions update of $modulePath"
                }
                else {
                    Publish-Module -Path $modulePath @commonArgs -Force
                    Update-ModulePackageVersion -modulePath $modulePath -versionNumber $manifestData.ModuleVersion -repository "PSGallery" -profileName $UpdatePackageVersionsProfile
                    Write-Host "Published $modulePath"
                }                
                break
            }
            catch {
                #We could have failed because the module was already published (possible in case we run this script multiple times)
                try {
                    Find-Module ([System.IO.Path]::GetFileNameWithoutExtension($manifest)) -RequiredVersion $manifestData.ModuleVersion
                    Write-Host "Successfully found module $modulePath version $($manifestData.ModuleVersion) already on the gallery"
                    if ($DryRun) {
                        Write-Host "-DryRun specified, skipped PackageVersions update of $modulePath in catch."
                    }
                    else {
                        Update-ModulePackageVersion -modulePath $modulePath -versionNumber $manifestData.ModuleVersion -repository "PSGallery" -profileName $UpdatePackageVersionsProfile
                    }
                    break;
                }
                catch {
                }
                Write-Host $_
                if ($i -lt $maxPublishRetries - 1) {
                    Write-Host "Error publishing $modulePath, retrying"
                    Start-Sleep -Seconds 5
                }
                else {
                    Write-Host "Fatal error publishing $modulePath"
                    throw  $_
                }
            }
        }
    }
    else {
        Write-Host "Skipping, $manifest already published"
    }
}

PublishRecursive $awsPowerShellModuleLocation
PublishRecursive $awsPowerShellCoreModuleLocation

$OldPath = $Env:PSModulePath
$Env:PSModulePath = $Env:PSModulePath + ";$awsPowerShellModularModulesLocation"

foreach ($module in Get-ChildItem $awsPowerShellModularModulesLocation -Directory) {
    PublishRecursive $module.FullName
}

$Env:PSModulePath = $OldPath