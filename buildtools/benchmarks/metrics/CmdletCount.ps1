<#
.Synopsis
    Benchmark: exported cmdlet count for the AWS.Tools modules.
.Description
    Emits an AWS.Tools aggregate over all service modules (excludes the standalone AWS.Tools.Installer)
    plus AWS.Tools.Installer on its own. Runs on Linux only; the count does not depend on the runtime.

    Service modules are binary, so their cmdlets are read straight from each manifest's CmdletsToExport
    (a file read, no import). AWS.Tools.Installer is a script module whose commands are functions and
    whose manifest lists no cmdlets, so it is imported and its exported cmdlets and functions are
    counted instead.
#>

# Exported command count for one module, by manifest read or by import.
#   -Psd1Path  : read CmdletsToExport from the manifest (binary modules; no import).
#   -ImportPath: import the manifest and count exported cmdlets + functions (script modules).
function Get-ModuleCmdletCount {
    [CmdletBinding(DefaultParameterSetName = 'Manifest')]
    param(
        [Parameter(Mandatory, ParameterSetName = 'Manifest')]
        [string]$Psd1Path,
        [Parameter(Mandatory, ParameterSetName = 'Import')]
        [string]$ImportPath
    )
    if ($PSCmdlet.ParameterSetName -eq 'Manifest') {
        if (-not (Test-Path $Psd1Path)) { return 0 }
        $data = Import-PowerShellDataFile -Path $Psd1Path
        return @($data.CmdletsToExport | Where-Object { $_ -and $_ -ne '*' }).Count
    }
    if (-not (Test-Path $ImportPath)) { return 0 }
    $name = [System.IO.Path]::GetFileNameWithoutExtension($ImportPath)
    Import-Module $ImportPath -Force | Out-Null
    @(Get-Command -Module $name -CommandType Cmdlet, Function).Count
}

# Benchmark entry point. Returns BenchmarkResult[].
function Measure-AWSToolsCmdletCount {
    param([hashtable]$BenchmarkContext)

    $awsToolsRoot = Join-Path $BenchmarkContext.DeploymentPath 'AWS.Tools'
    if (-not (Test-Path $awsToolsRoot)) { return }

    Write-Log 'Counting exported cmdlets from AWS.Tools manifests'
    $aggregate = 0
    foreach ($dir in (Get-ChildItem -Path $awsToolsRoot -Directory | Where-Object { $_.Name -ne 'AWS.Tools.Installer' })) {
        $aggregate += Get-ModuleCmdletCount -Psd1Path (Join-Path $dir.FullName "$($dir.Name).psd1")
    }
    [BenchmarkResult]::new('cmdletcount.AWS.Tools', 'Declared cmdlet count across all AWS.Tools service modules (excludes AWS.Tools.Installer).',
        $BenchmarkContext.Now, $BenchmarkContext.CountUnit, [double[]]@($aggregate), @())

    $installerCount = Get-ModuleCmdletCount -ImportPath (Join-Path $awsToolsRoot 'AWS.Tools.Installer/AWS.Tools.Installer.psd1')
    [BenchmarkResult]::new('cmdletcount.AWS.Tools.Installer', 'Exported command count for AWS.Tools.Installer.',
        $BenchmarkContext.Now, $BenchmarkContext.CountUnit, [double[]]@($installerCount), @())
}
