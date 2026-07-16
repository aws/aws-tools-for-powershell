<#
.Synopsis
    Performance test runner (Windows). Emits a single results JSON document to stdout.
.Description
    Launched under Windows PowerShell 5.1 by the performance test step from the artifact root.
    Measures one runtime per node: pass -Runtime WindowsPwsh (PowerShell 7) or WindowsPowerShell
    (5.1). Invoke-Benchmarks.ps1 selects the matching shell for the cold-import samples.
#>
[CmdletBinding()]
Param(
    [Parameter(Mandatory = $true)]
    [ValidateSet('WindowsPowerShell', 'WindowsPwsh')]
    [string]$Runtime,

    [Parameter()]
    [ValidateRange(1, [int]::MaxValue)]
    [int]$Samples = 5
)

$ErrorActionPreference = 'Stop'
& (Join-Path $PSScriptRoot 'benchmarks/Invoke-Benchmarks.ps1') -Runtime $Runtime -Samples $Samples
