<#
.Synopsis
    Benchmark: cold Import-Module time, post-import working-set memory, and exported cmdlet count.
.Description
    For each target module, runs $BenchmarkContext.Samples cold imports, each in a fresh child process so module
    caching does not skew timing. The child verifies the module loaded and exported cmdlets, so a
    silent partial import does not publish bogus low numbers. Runs on every runtime; the cmdlet
    count is also the >0 liveness check for the imported modules.
#>

# One cold import in a fresh child process; returns import ms, working set, and cmdlet count.
function Invoke-ColdImportSample {
    param(
        [hashtable]$BenchmarkContext,
        [string]$ModuleName
    )

    # Double any single quotes so a path containing one stays valid inside the single-quoted
    # assignment in the child script.
    $searchPaths = $BenchmarkContext.ModuleSearchPaths.Replace("'", "''")

    $childScript = @"
`$ErrorActionPreference = 'Stop'
`$env:PSModulePath = '$searchPaths' + [System.IO.Path]::PathSeparator + `$env:PSModulePath
`$sw = [System.Diagnostics.Stopwatch]::StartNew()
Import-Module $ModuleName
`$sw.Stop()
if (-not (Get-Module -Name '$ModuleName')) { throw "Module '$ModuleName' is not loaded after Import-Module." }
`$proc = [System.Diagnostics.Process]::GetCurrentProcess()
`$cmdCount = (Get-Command -Module '$ModuleName' -CommandType Cmdlet | Measure-Object).Count
if (`$cmdCount -le 0) { throw "Module '$ModuleName' exported 0 cmdlets after import." }
[pscustomobject]@{
    ImportMs     = `$sw.Elapsed.TotalMilliseconds
    WorkingSet   = `$proc.WorkingSet64
    CommandCount = `$cmdCount
} | ConvertTo-Json -Compress
"@

    # Capture the child's stderr so a failure surfaces the real error, keeping stdout clean JSON.
    $errFile = [System.IO.Path]::GetTempFileName()
    try {
        $output = & $BenchmarkContext.Shell -NoProfile -NonInteractive -Command $childScript 2>$errFile
        $stderr = (Get-Content -Raw -Path $errFile -ErrorAction SilentlyContinue)
        if ($LASTEXITCODE -ne 0 -or [string]::IsNullOrWhiteSpace($output)) {
            throw "Cold import sample failed for $ModuleName in $($BenchmarkContext.Shell) (exit $LASTEXITCODE): $stderr"
        }
        $sample = ($output | Where-Object { $_.Trim().StartsWith('{') } | Select-Object -Last 1) | ConvertFrom-Json
        # Fail loud if the child exited 0 but produced no parseable sample, so a missing sample is
        # never silently dropped from the measurements array.
        if ($null -eq $sample -or $null -eq $sample.ImportMs) {
            throw "Cold import sample for $ModuleName in $($BenchmarkContext.Shell) produced no parseable result. stdout: $output"
        }
        $sample
    }
    finally {
        Remove-Item -Path $errFile -ErrorAction SilentlyContinue
    }
}

# Benchmark entry point. Returns BenchmarkResult[].
function Measure-Import {
    param([hashtable]$BenchmarkContext)

    # Monolithic module differs by runtime; modular targets are Common + a representative service.
    $monolithic = if ($BenchmarkContext.Runtime -eq 'WindowsPowerShell') { 'AWSPowerShell' } else { 'AWSPowerShell.NetCore' }
    $targets = @(
        @{ Name = $monolithic;        Dir = Join-Path $BenchmarkContext.DeploymentPath $monolithic }
        @{ Name = 'AWS.Tools.Common'; Dir = Join-Path $BenchmarkContext.DeploymentPath 'AWS.Tools/AWS.Tools.Common' }
        @{ Name = 'AWS.Tools.S3';     Dir = Join-Path $BenchmarkContext.DeploymentPath 'AWS.Tools/AWS.Tools.S3' }
    )

    foreach ($target in $targets) {
        if (-not (Test-Path $target.Dir)) {
            Write-Log "Skipping $($target.Name): no module folder at $($target.Dir)"
            continue
        }

        $samples = foreach ($i in 1..$BenchmarkContext.Samples) {
            Write-Log "Sampling import of $($target.Name) ($($BenchmarkContext.Runtime)) [$i/$($BenchmarkContext.Samples)]"
            Invoke-ColdImportSample -BenchmarkContext $BenchmarkContext -ModuleName $target.Name
        }

        [BenchmarkResult]::new("importtime.$($target.Name)", "Cold Import-Module time for $($target.Name).",
            $BenchmarkContext.Now, 'Milliseconds', [double[]]$samples.ImportMs, $BenchmarkContext.RuntimeDimension)
        [BenchmarkResult]::new("importmemory.$($target.Name)", "Process working-set memory after importing $($target.Name).",
            $BenchmarkContext.Now, 'Bytes', [double[]]$samples.WorkingSet, $BenchmarkContext.RuntimeDimension)
        [BenchmarkResult]::new("cmdletcount.$($target.Name)", "Exported cmdlet count for $($target.Name).",
            $BenchmarkContext.Now, $BenchmarkContext.CountUnit, [double[]]$samples.CommandCount, $BenchmarkContext.RuntimeDimension)
    }
}
