param (
    [string]$currentVersion,
    [string]$versionFile
)

$p = Split-Path ([System.IO.Path]::GetFullPath($versionFile))
if (!(Test-Path $p))
{
    New-Item -Path $p -ItemType Directory
}

# use quoted property names, so 'awspowershell.netcore' doesn't
# get interpreted as two property names
$v = @{}
$v."awspowershell" = @{ "latest" = $currentVersion }
$v."awspowershell.netcore" = @{ "latest" = $currentVersion }

$v | ConvertTo-Json -Depth 5 | Out-File $versionFile -Encoding utf8
