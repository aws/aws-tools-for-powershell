<#
.Synopsis
    Benchmark: on-disk size and file count per module.
.Description
    Runtime-independent (a module's bytes and file count do not depend on which PowerShell loads it),
    so this runs once, on Linux. Emits per-module size plus an AWS.Tools aggregate over all service
    modules (every AWS.Tools.* except the standalone AWS.Tools.Installer, matching how
    Confirm-StagedArtifact treats it). AWS.Tools.Installer is reported on its own.
#>

# Every file under a module folder.
function Get-ModuleFile {
    param([string]$Dir)
    Get-ChildItem -Path $Dir -Recurse -File -ErrorAction SilentlyContinue
}

# Size (bytes) and file count for one module folder, as BenchmarkResult[].
function Get-ModuleSize {
    param(
        [hashtable]$BenchmarkContext,
        [string]$Name,
        [System.IO.FileInfo[]]$Files
    )
    $bytes = ($Files | Measure-Object -Property Length -Sum).Sum
    if ($null -eq $bytes) { $bytes = 0 }
    [BenchmarkResult]::new("size.$Name", "On-disk size of $Name.", $BenchmarkContext.Now, 'Bytes', [double[]]@([long]$bytes), @())
    [BenchmarkResult]::new("filecount.$Name", "File count of $Name.", $BenchmarkContext.Now, $BenchmarkContext.CountUnit, [double[]]@($Files.Count), @())
}

# Benchmark entry point. Returns BenchmarkResult[].
function Measure-ModuleSize {
    param([hashtable]$BenchmarkContext)

    foreach ($name in @('AWSPowerShell', 'AWSPowerShell.NetCore')) {
        $dir = Join-Path $BenchmarkContext.DeploymentPath $name
        if (Test-Path $dir) {
            Get-ModuleSize -BenchmarkContext $BenchmarkContext -Name $name -Files (Get-ModuleFile -Dir $dir)
        }
    }

    $awsToolsRoot = Join-Path $BenchmarkContext.DeploymentPath 'AWS.Tools'
    if (Test-Path $awsToolsRoot) {
        $moduleDirs = Get-ChildItem -Path $awsToolsRoot -Directory

        # AWS.Tools aggregate over all service modules (excludes Installer); dashboard graphs this total.
        $serviceFiles = $moduleDirs | Where-Object { $_.Name -ne 'AWS.Tools.Installer' } |
            ForEach-Object { Get-ModuleFile -Dir $_.FullName }
        Get-ModuleSize -BenchmarkContext $BenchmarkContext -Name 'AWS.Tools' -Files $serviceFiles

        # Per-module size (including Installer) for ad-hoc queries.
        foreach ($dir in $moduleDirs) {
            Get-ModuleSize -BenchmarkContext $BenchmarkContext -Name $dir.Name -Files (Get-ModuleFile -Dir $dir.FullName)
        }
    }
}
