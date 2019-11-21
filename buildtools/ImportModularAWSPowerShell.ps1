$ErrorActionPreference = "Stop"

$modulesDeploymentPath = Resolve-Path "$PSScriptRoot/../Deployment/AWS.Tools"

$OldPath = $Env:PSModulePath

$Env:PSModulePath = $Env:PSModulePath + ';' + $modulesDeploymentPath

Get-ChildItem $modulesDeploymentPath -Filter *.psd1 -Recurse | Import-Module -Verbose

$Env:PSModulePath = $OldPath
