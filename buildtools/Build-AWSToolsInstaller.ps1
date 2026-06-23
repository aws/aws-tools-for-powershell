# Build-AWSToolsInstaller.ps1
#
# Builds AWS.Tools.Installer.dll and stages the module into
# Deployment/AWS.Tools/AWS.Tools.Installer/ ready for the Pester suite.
# Run from the repository root.

$ErrorActionPreference = 'Stop'

if (-not (Test-Path './buildtools/build.proj')) {
    throw "Run this script from the repository root (./buildtools/build.proj not found)."
}

$installerLib    = './modules/Installer/AWS.Tools.Installer.Lib/AWS.Tools.Installer.csproj'
$installerSource = './modules/Installer'
$installerDeploy = './Deployment/AWS.Tools/AWS.Tools.Installer'

Write-Host '[Build-AWSToolsInstaller] dotnet build AWS.Tools.Installer.Lib'
& dotnet build -c Release -f netstandard2.0 --force --no-incremental --verbosity quiet $installerLib
if ($LASTEXITCODE) { throw "dotnet build failed (exit=$LASTEXITCODE)" }

Write-Host "[Build-AWSToolsInstaller] Staging to $installerDeploy"
if (Test-Path $installerDeploy) { Remove-Item -Recurse -Force $installerDeploy }
New-Item -ItemType Directory -Path $installerDeploy -Force | Out-Null

Copy-Item "$installerSource/AWS.Tools.Installer.psd1" $installerDeploy
Copy-Item "$installerSource/AWS.Tools.Installer.psm1" $installerDeploy
Copy-Item "$installerSource/Public"  $installerDeploy -Recurse
Copy-Item "$installerSource/Private" $installerDeploy -Recurse
Copy-Item "$installerSource/Config"  $installerDeploy -Recurse
Copy-Item "$installerSource/AWS.Tools.Installer.Lib/bin/Release/netstandard2.0/AWS.Tools.Installer.dll" $installerDeploy

Write-Host '[Build-AWSToolsInstaller] Done.'
