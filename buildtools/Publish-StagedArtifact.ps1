<#
.Synopsis
    Publishes the AWSPowerShell, AWSPowerShell.NetCore, and AWS.Tools.* modules 
    to the PowerShell Gallery or a local PowerShell repository.
.DESCRIPTION
    Publishes the AWS Tools for PowerShell modules (AWSPowerShell, 
    AWSPowerShell.NetCore, and AWS.Tools.*) to the PowerShell Gallery or a 
    local PowerShell repository. Updating DDB Package Versions can be skipped by
    passing an empty value to UpdatePackageVersionsProfile parameter.

    AWS.Tools.* modules are published in parallel using ForEach-Object -Parallel,
    respecting the module dependency graph (topological layer ordering).
    Dependencies are loaded from aws-tools-publish-dependency-graph.json which
    is generated during build and copied to Deployment/.

.NOTES
    The script must be run in a folder that contains subfolders holding the 
    modules to be published (i.e. .\AWSPowerShell, .\AWSPowerShell.NetCore, and
    .\AWS.Tools).

    Publishing is done using the Publish-PSResource cmdlet of the PSResourceGet 
    module. This module must be installed either in user scope or globally 
    before this script can be used.

    To publish to the gallery an API key, similar to NuGet, is required. The 
    key is available in Secrets Manager. For a local PowerShell repository the
    API key is passed to this script.

.EXAMPLE
    Publish-StagedArtifact -SecretId the-secret-id 
        -SecretRegion the-secret-region 
        -SecretReaderProfile the-secret-reader-profile 
        -SecretKey the-secret-key-name 
        -UpdatePackageVersionsProfile the-updated-package-versions-profile
    
	Publishes all modules to the PowerShell Gallery.

.EXAMPLE
    Publish-StagedArtifact -SecretId the-secret-id 
        -SecretRegion the-secret-region 
        -SecretReaderProfile the-secret-reader-profile 
        -SecretKey the-secret-key-name 
        -UpdatePackageVersionsProfile the-updated-package-versions-profile
        -DryRun
    	
    Displays the changelog notes and file paths the script would operate on, but does not
    push the modules to the PowerShell Gallery.

.EXAMPLE
    Publish-StagedArtifact -LocalRepositoryName local-repository-name
        -LocalRepositoryNuGetApiKey local-repository-nuget-api-key

	Publishes all modules to the local PowerShell Gallery.

.EXAMPLE
    Publish-StagedArtifact -SecretId dummy -SecretRegion us-west-2 
        -SecretReaderProfile dummy -SecretKey dummy
        -RemoteRepositoryName LocalTestRepo -DryRun

    Tests the parallel publish flow against a local repository without publishing.
#>

[CmdletBinding()]
Param
(
    [Parameter(ParameterSetName="remote", Mandatory = $true, HelpMessage = "The name of the Secrets Manager secret containing the PowerShell Gallery key.")]
    [ValidateNotNullOrEmpty()]
    [string]$SecretId,

    [Parameter(ParameterSetName="remote", Mandatory = $true, HelpMessage = "The AWS region where the PowerShell Gallery key is available from Secrets Manager.")]
    [ValidateNotNullOrEmpty()]
    [string]$SecretRegion,
    
    [Parameter(ParameterSetName="remote", Mandatory = $true, HelpMessage = "The AWS profile to use to retrieve the PowerShell Gallery key from Secrets Manager.")]
    [ValidateNotNullOrEmpty()]
    [string]$SecretReaderProfile,
    
    [Parameter(ParameterSetName="remote", Mandatory = $true, HelpMessage = "The name of entry of the PowerShell Gallery key in the Secret Manager secret.")]
    [ValidateNotNullOrEmpty()]
    [string]$SecretKey,

    [Parameter(ParameterSetName="remote", HelpMessage = "The AWS profile to use to update and store PowerShell Gallery package information in the ProfileVersions table. This should have a value for the latest GA version of AWSPowerShell. This should be empty for older versions and non-GA releases.")]
    [string]$UpdatePackageVersionsProfile,
    
    [Parameter(ParameterSetName="remote")]    
    [string] $RequiredAWSPowerShellVersionToUse = '4.1.14.0',    

    [Parameter(ParameterSetName="remote")]
    [switch]$DryRun,

    [Parameter(ParameterSetName="remote", HelpMessage = "The name of the remote PowerShell repository to publish to. Defaults to PSGallery. Can be set to a local repo name for testing.")]
    [string]$RemoteRepositoryName = "PSGallery",

    [Parameter(ParameterSetName="remote", HelpMessage = "The number of parallel publish workers. Defaults to 3.")]
    [int]$ThrottleLimit = 3,

    [Parameter(ParameterSetName="local", Mandatory = $true, HelpMessage = "The name of the local PowerShell repository to publish to.")]
    [string]$LocalRepositoryName,

    [Parameter(ParameterSetName="local", Mandatory = $true, HelpMessage = "The local repository NuGetApiKey used for publishing to the local repository.")]
    [string]$LocalRepositoryNuGetApiKey
)

$ErrorActionPreference = "Stop"
$paramSetRemoteName = "remote"
$paramSetLocalName = "local"

# Pin PSResourceGet 1.1.1 so publishing does not pick up a different version present on the image.
Import-Module Microsoft.PowerShell.PSResourceGet -RequiredVersion 1.1.1

# in pwsh 7.1.0, running Publish-PSResource errors out with
# Cannot retrieve the dynamic parameters for the cmdlet. Loading repository store failed: Could not find file 'C:\Users\ContainerAdministrator\AppData\Local\PSResourceGet\PSResourceRepository.xml'.
# Running Get-PSResourceRepository seems to create the PSResourceRepository.xml file
$allRepos = Get-PSResourceRepository

$shouldUpdatePackageVersions = ![string]::IsNullOrEmpty($UpdatePackageVersionsProfile)
#Import DynamoDBv2 needed to update the PackageVersions table.
if ($PSCmdlet.ParameterSetName -eq $paramSetRemoteName) {
    if ($shouldUpdatePackageVersions) {
        if (-not (Get-Module -ListAvailable -Name AWS.Tools.DynamoDBv2 | Where-Object { $_.Version -eq $RequiredAWSPowerShellVersionToUse })) {
            Write-Host "Installing AWS.Tools.DynamoDBv2 $RequiredAWSPowerShellVersionToUse"
            Install-Module -Name AWS.Tools.DynamoDBv2 -RequiredVersion $RequiredAWSPowerShellVersionToUse -Force
        }
        Import-Module -Name AWS.Tools.DynamoDBv2 -RequiredVersion $RequiredAWSPowerShellVersionToUse

        Import-Module $PSScriptRoot/Update-ModulePackageVersion.psm1
    }
    else {
        Write-Warning 'Skipping updates to the PackageVersions table since UpdatePackageVersionsProfile parameter is either null or empty'
    }
}
elseif($PSCmdlet.ParameterSetName -eq $paramSetLocalName){
    # validate if the LocalRepositoryName exists
    $localRepo = $allRepos | Where-Object {$_.Name -eq $LocalRepositoryName}
    if(-not $localRepo){
        throw "Local repository $LocalRepositoryName does not exist."
    }
}

$currentLocation = (Get-Location).Path
$awsPowerShellModuleLocation = Join-Path $currentLocation "AWSPowerShell"
$awsPowerShellCoreModuleLocation = Join-Path $currentLocation "AWSPowerShell.NetCore"
$awsPowerShellModularModulesLocation = Join-Path $currentLocation "AWS.Tools"
$s3ModularModuleLocation = Join-Path $awsPowerShellModularModulesLocation "AWS.Tools.S3"

# Validate the generated nuget package from Microsoft.PowerShell.PSResourceGet for AWS.Tools.S3 is valid
# It is enough to test a single Tools module since the psd1 template is same for all service modules
# Skip nuget dependency validation for preview builds — RequiredModules is intentionally empty for previews.
if ([string]::IsNullOrEmpty($Env:PreviewLabel)) {
    .\Test-NugetPackageDependencyVersion.ps1 -ModulePath $s3ModularModuleLocation
} else {
    Write-Host "Skipping NuGet dependency version validation for preview build (PreviewLabel: $($Env:PreviewLabel))"
}

if (-not $DryRun -and $PSCmdlet.ParameterSetName -eq $paramSetRemoteName) {
    #Import SecretsManager needed to get the secret key.
    if (-not (Get-Module -ListAvailable -Name AWS.Tools.SecretsManager | Where-Object { $_.Version -eq $RequiredAWSPowerShellVersionToUse })) {
        Write-Host "Installing AWS.Tools.SecretsManager $RequiredAWSPowerShellVersionToUse"
        Install-Module -Name AWS.Tools.SecretsManager -RequiredVersion $RequiredAWSPowerShellVersionToUse -Force
    }
    Import-Module -Name AWS.Tools.SecretsManager -RequiredVersion $RequiredAWSPowerShellVersionToUse

    $ApiKey = ((Get-SECSecretValue -SecretId $SecretId -Region $SecretRegion -ProfileName $SecretReaderProfile).SecretString | ConvertFrom-Json).$SecretKey
}

$commonArgs = @{
    'ApiKey'                     = $LocalRepositoryNuGetApiKey
    'SkipDependenciesCheck'      = $true
    'SkipModuleManifestValidate' = $true
    'Repository'                 = $LocalRepositoryName
}

if ($PSCmdlet.ParameterSetName -eq $paramSetRemoteName) {
    $commonArgs.ApiKey = $ApiKey
    $commonArgs.Repository = $RemoteRepositoryName
}

Write-Host "Publishing to repository: $($commonArgs.Repository) (parameter set: $($PSCmdlet.ParameterSetName))"

# Resolve module version and prerelease label.
# All AWS.Tools.* modules (except AWS.Tools.Installer) share the same version and prerelease label.
# $Env:Version and $Env:PreviewLabel are set by the CodeBuild project.
# Fall back to reading one psd1 if env vars are not set (backward compat).
$ModuleVersion = $Env:Version
$PreviewLabel = $Env:PreviewLabel  # typically empty for GA releases

if ([string]::IsNullOrEmpty($ModuleVersion)) {
    # Fallback: read from one psd1 (they all share the same version)
    $samplePsd1 = Join-Path $awsPowerShellModularModulesLocation "AWS.Tools.Common" "AWS.Tools.Common.psd1"
    $sampleData = Import-PowerShellDataFile $samplePsd1
    $ModuleVersion = $sampleData.ModuleVersion
    if ($sampleData.PrivateData.PSData.ContainsKey('Prerelease')) {
        $PreviewLabel = $sampleData.PrivateData.PSData.Prerelease
    }
    Write-Host "Resolved version from psd1 fallback: $ModuleVersion (prerelease: '$PreviewLabel')"
} else {
    Write-Host "Using env var version: $ModuleVersion (prerelease: '$PreviewLabel')"
}

$prereleaseLabel = if ($PreviewLabel) { "-$PreviewLabel" } else { '' }
$findVersion = "$ModuleVersion$prereleaseLabel"

# Load dependency graph (pre-computed by generator, copied to Deployment by CopyModularAWSPowerShell.ps1)
$depGraphPath = Join-Path $currentLocation "aws-tools-publish-dependency-graph.json"
if (-not (Test-Path $depGraphPath)) {
    throw "Dependency graph not found at $depGraphPath. This file is generated during build and is required for publishing."
}
$depGraph = Get-Content $depGraphPath -Raw | ConvertFrom-Json -AsHashtable
Write-Host "Loaded dependency graph from $depGraphPath ($($depGraph.Count) modules)"

# Validate that the dependency graph matches the actual module directories on disk.
# The graph contains service modules only (no Common or Installer — those are published separately).
function Confirm-DependencyGraph {
    param(
        [hashtable]$Graph,
        [string]$ModulesPath
    )
    
    # Directory names are already AWS.Tools.* prefixed (e.g. AWS.Tools.S3).
    # Exclude Common and Installer — they are published separately.
    $excludedModules = @('AWS.Tools.Common', 'AWS.Tools.Installer')
    $actualModules = (Get-ChildItem $ModulesPath -Directory).Name | 
        Where-Object { $_ -notin $excludedModules }
    $graphModules = @($Graph.Keys)

    $missingFromGraph = @($actualModules | Where-Object { -not $Graph.ContainsKey($_) })
    $extraInGraph = @($graphModules | Where-Object { $_ -notin $actualModules })

    if ($missingFromGraph.Count -gt 0) {
        Write-Host "ERROR: $($missingFromGraph.Count) module(s) on disk but NOT in dependency graph:"
        $missingFromGraph | ForEach-Object { Write-Host "  $_" }
        throw "Dependency graph is incomplete — $($missingFromGraph.Count) module(s) missing. Graph: $($graphModules.Count), disk: $($actualModules.Count)."
    }

    if ($extraInGraph.Count -gt 0) {
        Write-Host "ERROR: $($extraInGraph.Count) module(s) in dependency graph but NOT on disk:"
        $extraInGraph | ForEach-Object { Write-Host "  $_" }
        throw "Dependency graph has $($extraInGraph.Count) extra module(s) not on disk. Graph: $($graphModules.Count), disk: $($actualModules.Count)."
    }

    Write-Host "Dependency graph validated: $($graphModules.Count) modules match $($actualModules.Count) directories on disk"
}

Confirm-DependencyGraph -Graph $depGraph -ModulesPath $awsPowerShellModularModulesLocation

# Build topological layers for parallel publishing.
# Each layer contains modules whose dependencies have all been published in previous layers.
function Get-PublishLayers {
    param([hashtable]$Graph)
    
    $published = [System.Collections.Generic.HashSet[string]]::new()
    $published.Add("AWS.Tools.Common") | Out-Null
    
    $remaining = @{}
    foreach ($key in $Graph.Keys) {
        if ($key -ne "AWS.Tools.Common") {
            $remaining[$key] = @($Graph[$key])
        }
    }
    
    $layers = @()
    while ($remaining.Count -gt 0) {
        # Find modules whose dependencies are all published
        $ready = @($remaining.Keys | Where-Object { 
            $deps = $remaining[$_]
            ($deps | Where-Object { -not $published.Contains($_) }).Count -eq 0
        })
        
        if ($ready.Count -eq 0) {
            throw "Circular dependency detected among: $($remaining.Keys -join ', ')"
        }
        
        $layers += ,@($ready)
        foreach ($mod in $ready) {
            $published.Add($mod) | Out-Null
            $remaining.Remove($mod)
        }
    }
    return $layers
}

$layers = Get-PublishLayers -Graph $depGraph
$layerSizes = $layers | ForEach-Object { $_.Count }
Write-Host "Dependency layers: $($layers.Count) (sizes: $($layerSizes -join ', '))"

# Verify all graph modules ended up in a layer (Common and Installer are not in the graph).
$totalInLayers = ($layerSizes | Measure-Object -Sum).Sum
if ($totalInLayers -ne $depGraph.Count) {
    throw "Layer count mismatch: $totalInLayers modules in layers vs $($depGraph.Count) in dependency graph"
}

# Common publish parameters shared by all batch publishes
$parallelPublishScript = Join-Path $PSScriptRoot "Invoke-ParallelPublish.ps1"
$repositoryName = $commonArgs.Repository
$batchParams = @{
    PublishArgs    = $commonArgs
    IsDryRun       = [bool]$DryRun
    ShouldUpdatePV = $shouldUpdatePackageVersions
    UpdatePVProfile = $UpdatePackageVersionsProfile
    ScriptRoot     = $PSScriptRoot
    RepositoryName = $repositoryName
}

# --- Publish independent modules (AWSPowerShell, AWSPowerShell.NetCore, AWS.Tools.Common) in parallel ---
# These have no dependencies on each other. Common must complete before service module layers start.

$independentModules = @(
    $awsPowerShellModuleLocation,
    $awsPowerShellCoreModuleLocation,
    (Join-Path $awsPowerShellModularModulesLocation "AWS.Tools.Common")
)

& $parallelPublishScript -ModulePaths $independentModules -BatchLabel "Independent modules" `
    -Version $ModuleVersion -FindVersion $findVersion -ThrottleLimit $ThrottleLimit @batchParams

# --- Publish AWS.Tools.Installer (independent version) ---

$installerPath = Join-Path $awsPowerShellModularModulesLocation "AWS.Tools.Installer"
if (Test-Path $installerPath) {
    # Installer uses its own version, must read from psd1
    $installerPsd1 = Join-Path $installerPath "AWS.Tools.Installer.psd1"
    $installerData = Import-PowerShellDataFile $installerPsd1
    $installerVersion = $installerData.ModuleVersion
    $installerPrerelease = ''
    if ($installerData.PrivateData.PSData.ContainsKey('Prerelease')) {
        $installerPrerelease = '-' + $installerData.PrivateData.PSData.Prerelease
    }
    $installerFindVersion = "$installerVersion$installerPrerelease"

    & $parallelPublishScript -ModulePaths @($installerPath) -BatchLabel "AWS.Tools.Installer" `
        -Version $installerVersion -FindVersion $installerFindVersion -ThrottleLimit 1 @batchParams
}

# --- Publish AWS.Tools.* service modules in dependency layers ---

$OldPath = $Env:PSModulePath
$Env:PSModulePath = $Env:PSModulePath + [System.IO.Path]::PathSeparator + $awsPowerShellModularModulesLocation

try {

$layerIndex = 0
foreach ($layer in $layers) {
    $layerIndex++

    $modulePaths = @($layer | ForEach-Object {
        # Skip Installer and Common — already published above
        if ($_ -eq 'AWS.Tools.Installer' -or $_ -eq 'AWS.Tools.Common') { return }
        $path = Join-Path $awsPowerShellModularModulesLocation $_
        if (Test-Path $path) { $path }
    } | Where-Object { $_ })

    & $parallelPublishScript -ModulePaths $modulePaths -BatchLabel "Layer $layerIndex/$($layers.Count)" `
        -Version $ModuleVersion -FindVersion $findVersion -ThrottleLimit $ThrottleLimit @batchParams
}

} finally {
    $Env:PSModulePath = $OldPath
}

Write-Host "`n=== Publish complete ==="