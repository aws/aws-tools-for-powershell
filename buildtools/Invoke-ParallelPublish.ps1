<#
.Synopsis
    Publishes a batch of PowerShell modules in parallel with error aggregation.
.DESCRIPTION
    Publishes one or more modules in parallel using ForEach-Object -Parallel,
    delegating each module to Invoke-PublishWithRetry.ps1 for retry logic and
    409-conflict idempotency. Errors from parallel workers are collected and
    reported after the batch completes.

    Used by Publish-StagedArtifact.ps1 for all publish batches: independent
    modules (AWSPowerShell, AWSPowerShell.NetCore, AWS.Tools.Common),
    AWS.Tools.Installer, and service module dependency layers.

.PARAMETER ThrottleLimit
    The number of parallel publish workers. Defaults to 3.
    This is I/O-bound (network round-trips to the gallery), not CPU-bound.
    Recommended range: 2-8. Higher values may hit PSGallery rate limits or
    saturate network bandwidth. Lower values are safer but slower.
#>
param(
    [Parameter(Mandatory)]
    [string[]]$ModulePaths,

    [Parameter(Mandatory)]
    [string]$BatchLabel,

    [Parameter(Mandatory)]
    [hashtable]$PublishArgs,

    [Parameter(Mandatory)]
    [string]$Version,

    [Parameter(Mandatory)]
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

    [int]$ThrottleLimit = 3
)

$ErrorActionPreference = "Stop"

if ($ModulePaths.Count -eq 0) {
    throw "No module paths provided for $BatchLabel. This indicates a bug in the caller."
}

Write-Host "`n=== $BatchLabel`: Publishing $($ModulePaths.Count) module(s) (ThrottleLimit=$ThrottleLimit) ==="

$retryScript = Join-Path $ScriptRoot "Invoke-PublishWithRetry.ps1"
# Thread-safe error collection — parallel workers only Add() to this bag.
$publishErrors = [System.Collections.Concurrent.ConcurrentBag[string]]::new()

$ModulePaths | ForEach-Object -ThrottleLimit $ThrottleLimit -Parallel {
    # $ErrorActionPreference does not propagate into -Parallel runspaces; set explicitly.
    $ErrorActionPreference = "Stop"

    $modulePath = $_
    # $using: passes variables from the parent session into the parallel runspace.
    # Variables inside -Parallel blocks run in isolated runspaces with no access to parent scope.
    $script = $using:retryScript
    # Note: $pubArgs is read-only in parallel workers — hashtables are not thread-safe for writes,
    # but concurrent reads are safe.
    $pubArgs = $using:PublishArgs
    $ver = $using:Version
    $findVer = $using:FindVersion
    $dryRun = $using:IsDryRun
    $updatePV = $using:ShouldUpdatePV
    $pvProfile = $using:UpdatePVProfile
    $root = $using:ScriptRoot
    $repo = $using:RepositoryName
    $errBag = $using:publishErrors

    try {
        & $script -ModulePath $modulePath -PublishArgs $pubArgs `
            -Version $ver -FindVersion $findVer `
            -IsDryRun $dryRun -ShouldUpdatePV $updatePV `
            -UpdatePVProfile $pvProfile -ScriptRoot $root `
            -RepositoryName $repo
    } catch {
        # $_ is an ErrorRecord; capture the exception message explicitly.
        $errMsg = if ($_.Exception) { $_.Exception.Message } else { $_.ToString() }
        $errBag.Add("${modulePath}: $errMsg")
    }
}

if ($publishErrors.Count -gt 0) {
    $errorDetails = $publishErrors -join "`n"
    $publishErrors | ForEach-Object { Write-Host "ERROR: $_" }
    throw "Failed to publish $($publishErrors.Count) module(s) in $BatchLabel :`n$errorDetails"
}