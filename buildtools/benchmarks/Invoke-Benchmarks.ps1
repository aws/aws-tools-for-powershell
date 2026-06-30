<#
.Synopsis
    Runs the AWS Tools for PowerShell benchmarks for one runtime and emits a Catapult
    PerformanceTestResults document to stdout.
.Description
    Each benchmark is a function in metrics/ returning BenchmarkResult objects. The registry below
    declares which runtimes each benchmark runs on; the driver runs those in scope and emits one
    JSON document. Add a benchmark by adding a metrics/ file and one registry entry.

    Shipped inside powershell.zip and run by the entry scripts (test.sh / test.ps1), which cd into
    the artifact root, so module folders are siblings: ./AWSPowerShell, ./AWSPowerShell.NetCore,
    ./AWS.Tools/*.
#>
[CmdletBinding()]
Param(
    # Runtime label recorded as the "Runtime" dimension on per-runtime metrics.
    [Parameter(Mandatory = $true)]
    [ValidateSet('WindowsPowerShell', 'WindowsPwsh', 'LinuxPwsh')]
    [string]$Runtime,

    # Root folder holding the module subfolders. Defaults to this script's location.
    [Parameter()]
    [string]$DeploymentPath,

    # Cold Import-Module samples per module/runtime.
    [Parameter()]
    [ValidateRange(1, [int]::MaxValue)]
    [int]$Samples = 5,

    [Parameter()]
    [string]$ProductId = 'powershell5'
)

$ErrorActionPreference = 'Stop'

# Progress goes to stderr so it shows in the CodeBuild log without polluting stdout, which the
# framework captures as the results JSON.
function Write-Log { param([string]$Message) [Console]::Error.WriteLine($Message) }

# This script lives in <artifact root>/benchmarks/, so the module folders are in its parent.
if ([string]::IsNullOrEmpty($DeploymentPath)) {
    $DeploymentPath = Split-Path $PSScriptRoot -Parent
}
$DeploymentPath = (Resolve-Path $DeploymentPath).Path

# Load the result contract first (the benchmarks reference the class), then the benchmark functions.
$metricsDir = Join-Path $PSScriptRoot 'metrics'
. (Join-Path $metricsDir 'BenchmarkResult.ps1')
$metricFiles = Get-ChildItem -Path $metricsDir -Filter '*.ps1' -File |
    Where-Object { $_.Name -ne 'BenchmarkResult.ps1' } | Sort-Object Name
foreach ($metric in $metricFiles) {
    . $metric.FullName
}

# Shared context passed to every benchmark.
$BenchmarkContext = @{
    Runtime       = $Runtime
    DeploymentPath = $DeploymentPath
    Samples       = $Samples
    # Epoch seconds, culture-invariant and 64-bit (the result "date" field is [long]).
    Now           = [DateTimeOffset]::UtcNow.ToUnixTimeSeconds()
    # Windows PowerShell 5.1 uses powershell; everything else pwsh.
    Shell         = if ($Runtime -eq 'WindowsPowerShell') { 'powershell' } else { 'pwsh' }
    # The monolithic folders and the modular AWS.Tools tree, for the child's PSModulePath.
    ModuleSearchPaths = @($DeploymentPath, (Join-Path $DeploymentPath 'AWS.Tools')) -join [System.IO.Path]::PathSeparator
    # Catapult unit enum has no "Count"; "Operations/Second" maps to the CloudWatch "None" unit.
    CountUnit     = 'Operations/Second'
    # Single Runtime dimension for per-runtime metrics; runtime-independent metrics pass @().
    RuntimeDimension = @(@{ name = 'Runtime'; value = $Runtime })
}

# Registry: each benchmark and the runtimes it runs on. ModuleSize and CmdletCount are
# runtime-independent, so they run once on Linux.
$Benchmarks = @(
    @{ Name = 'Import';      Runtimes = @('WindowsPowerShell', 'WindowsPwsh', 'LinuxPwsh'); Run = 'Measure-Import' }
    @{ Name = 'ModuleSize';  Runtimes = @('LinuxPwsh');                                     Run = 'Measure-ModuleSize' }
    @{ Name = 'CmdletCount'; Runtimes = @('LinuxPwsh');                                     Run = 'Measure-AWSToolsCmdletCount' }
)

try {
    $results = foreach ($b in $Benchmarks) {
        if ($Runtime -in $b.Runtimes) {
            Write-Log "Running benchmark: $($b.Name)"
            & $b.Run -BenchmarkContext $BenchmarkContext
        }
    }

    # commitId and sdkVersion from build-metadata.json (written into the artifact by the build);
    # both 'unknown' locally where the file is absent.
    $commitId = 'unknown'
    $sdkVersion = 'unknown'
    $metadataPath = Join-Path $DeploymentPath 'build-metadata.json'
    if (Test-Path $metadataPath) {
        $metadata = Get-Content -Raw -Path $metadataPath | ConvertFrom-Json
        if (-not [string]::IsNullOrEmpty($metadata.commitId)) { $commitId = $metadata.commitId }
        if (-not [string]::IsNullOrEmpty($metadata.sdkVersion)) { $sdkVersion = $metadata.sdkVersion }
    }

    $document = [ordered]@{
        productId  = $ProductId
        commitId   = $commitId
        sdkVersion = $sdkVersion
        results    = @($results)
    }

    Write-Log "Completed ${Runtime}: $(@($results).Count) results"

    # Single compressed JSON document to stdout (single-line, required by the framework parser).
    $document | ConvertTo-Json -Depth 10 -Compress
}
catch {
    [Console]::Error.WriteLine("Benchmarks failed (${Runtime}): $($_.Exception.Message)")
    [Console]::Error.WriteLine($_.ScriptStackTrace)
    exit 1
}
