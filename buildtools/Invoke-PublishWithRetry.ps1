<#
.Synopsis
    Publishes a single PowerShell module with retry logic and idempotency.
.DESCRIPTION
    Publishes a module using Publish-PSResource with retry support.
    Detects HTTP 409 via PSResourceGet's FullyQualifiedErrorId '409Error' as idempotent success.
    Optionally updates the DynamoDB PackageVersions table on success.
    
    This script is used by both the sequential and parallel publish paths
    in Publish-StagedArtifact.ps1.

.PARAMETER ModulePath
    The path to the module directory containing exactly one .psd1 manifest file.

.PARAMETER PublishArgs
    Hashtable of arguments to splat to Publish-PSResource (e.g. ApiKey, Repository, SkipDependenciesCheck).

.PARAMETER Version
    The module version string used for DDB PackageVersions update.

.PARAMETER FindVersion
    The version string (including prerelease label) used for display in 409-conflict messages.
    Defaults to $Version if not specified.

.PARAMETER IsDryRun
    If $true, skips actual publish and PackageVersions update.

.PARAMETER ShouldUpdatePV
    If $true, updates the DynamoDB PackageVersions table after successful publish.

.PARAMETER UpdatePVProfile
    The AWS profile name to use for the PackageVersions DDB update.

.PARAMETER ScriptRoot
    The directory containing Update-ModulePackageVersion.psm1.

.PARAMETER RepositoryName
    The name of the PowerShell repository being published to (e.g. PSGallery).

.PARAMETER MaxRetries
    Maximum number of publish attempts. Defaults to 5.
#>
param(
    [Parameter(Mandatory)]
    [string]$ModulePath,

    [Parameter(Mandatory)]
    [hashtable]$PublishArgs,

    [Parameter(Mandatory)]
    [string]$Version,

    [string]$FindVersion,

    [Parameter(Mandatory)]
    [bool]$IsDryRun,

    [Parameter(Mandatory)]
    [bool]$ShouldUpdatePV,

    [string]$UpdatePVProfile,

    [Parameter(Mandatory)]
    [string]$ScriptRoot,

    [Parameter(Mandatory)]
    [string]$RepositoryName,

    [int]$MaxRetries = 5
)

$ErrorActionPreference = "Stop"

if (-not (Test-Path $ModulePath)) {
    throw "Expected path $ModulePath does not exist"
}

$manifests = @(Get-ChildItem $ModulePath -File -Filter *.psd1)
if ($manifests.Count -ne 1) {
    throw "Expected exactly 1 .psd1 file in $ModulePath, found $($manifests.Count)"
}
$moduleName = $manifests[0].BaseName

if ([string]::IsNullOrEmpty($FindVersion)) {
    $FindVersion = $Version
}

# Import Update-ModulePackageVersion once (outside the retry loop) if needed
if ($ShouldUpdatePV) {
    Import-Module "$ScriptRoot/Update-ModulePackageVersion.psm1" -ErrorAction Stop
}

#https://github.com/PowerShell/PowerShellGet/issues/523 Work around PowerShell Gallery eventual consistency
$lastError = $null
for ($i = 0; $i -lt $MaxRetries; $i++) {
    try {
        Write-Host "Publishing $ModulePath"
        if ($IsDryRun) {
            Write-Host "-DryRun specified, skipped actual publish and PackageVersions update of $ModulePath"
        }
        else {
            Publish-PSResource -Path $ModulePath @PublishArgs
            if ($ShouldUpdatePV) {
                $null = Update-ModulePackageVersion -modulePath $ModulePath -versionNumber $Version -repository $RepositoryName -profileName $UpdatePVProfile
            }
            Write-Host "Published $ModulePath"
        }
        return  # success
    }
    catch {
        $lastError = $_
        # PSResourceGet sets FullyQualifiedErrorId to '409Error' when the module version already exists (HTTP 409 Conflict).
        # See: PSResourceGet/src/code/PublishHelper.cs — the ErrorRecord ErrorId is '409Error'.
        if ($_.FullyQualifiedErrorId -like '409Error*') {
            Write-Host "Module $moduleName version $FindVersion already exists on $RepositoryName (HTTP 409)"
            if (-not $IsDryRun -and $ShouldUpdatePV) {
                $null = Update-ModulePackageVersion -modulePath $ModulePath -versionNumber $Version -repository $RepositoryName -profileName $UpdatePVProfile
            }
            return  # already published = success
        }

        $lastErrorMsg = if ($lastError.Exception) { $lastError.Exception.Message } else { $lastError.ToString() }
        Write-Host "Error publishing $ModulePath (attempt $($i + 1)/$MaxRetries): $lastErrorMsg"
        if ($i -lt $MaxRetries - 1) {
            Start-Sleep -Seconds 15
        }
    }
}
# All retries exhausted
$finalErrorMsg = if ($lastError.Exception) { $lastError.Exception.Message } else { $lastError.ToString() }
throw "Fatal error publishing $ModulePath after $MaxRetries attempts: $finalErrorMsg"
