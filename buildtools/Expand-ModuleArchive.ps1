<#
.Synopsis
    Extracts the AWSPowerShell, AWSPowerShell.NetCore, and AWS.Tools module zips into per-module
    folders for the ADC publisher.
.DESCRIPTION
    Uses [System.IO.Compression.ZipFile]::ExtractToDirectory, which is much faster than Expand-Archive
    on archives with many files. The extracted contents are identical to Expand-Archive.
.PARAMETER ZipDirectory
    Directory containing the module zips (<Module>.zip, or <Module>-<previewLabel>.zip for previews).
.PARAMETER DestinationRoot
    Directory the per-module folders are written under (DestinationRoot/<Module>).
.PARAMETER PreviewLabel
    Optional preview label; when set the zip names are <Module>-<label without trailing digits>.zip.
    Defaults to the PreviewLabel environment variable so callers do not need to pass it explicitly.
#>
[CmdletBinding()]
Param
(
    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string]$ZipDirectory,

    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string]$DestinationRoot,

    [string]$PreviewLabel = $env:PreviewLabel
)

$ErrorActionPreference = 'Stop'

foreach ($moduleName in 'AWSPowerShell', 'AWSPowerShell.NetCore', 'AWS.Tools') {
    $zipName = "$moduleName.zip"
    if ($PreviewLabel) {
        $zipName = $moduleName + '-' + ($PreviewLabel -replace '\d+$', '') + '.zip'
    }
    $zipPath = Join-Path $ZipDirectory $zipName
    $destDir = Join-Path $DestinationRoot $moduleName
    Write-Host "moduleName: $moduleName, moduleZip: $zipName"
    if (Test-Path $destDir) { Remove-Item $destDir -Recurse -Force }
    $null = New-Item -ItemType Directory -Force -Path $destDir
    [System.IO.Compression.ZipFile]::ExtractToDirectory($zipPath, $destDir)
}
