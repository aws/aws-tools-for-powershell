<#
.Synopsis
    Validates an AWS PowerShell module is both Authenticode signed and has the expected version number.

.Description
    Validates that a built AWS PowerShell module (for Windows PowerShell or PowerShell Core)
    is both Authenticode signed and has the expected version number and thus can be safely released.
    This script is used to test artifacts on the build server prior to release as part of the release
    MCM steps.

.Example
    Test-ModuleSignedAndVersioned -ModuleFile .\awspowershell.psd1 -ExpectedVersion 3.3.283.0

.Notes
    The path to the module to test must be fully specified, or the script executed with the
    current working directory set to the extracted module folder.

    The script will automatically remove any loaded AWSPowerShell or AWSPowerShell.NetCore
    module from your shell instance prior to loading the module to be tested.
#>
Param (
    # The path and name of the .psd1 manifest file for the module to be
    # tested
    [Parameter(Mandatory=$true)]
    [string]$ModuleFile,

    # The expected version of the module. This will be verified against
    # the module manifest and the running binary.
    [Parameter(Mandatory=$true)]
    [string]$ExpectedVersion
)

$awsPowerShellModuleName = 'AWSPowerShell'
$awsPowerShellCoreModuleName = 'AWSPowerShell.NetCore'
$authenticodeSignatureStart = 'SIG # Begin signature block'

if ($PSVersionTable['PSEdition'] -eq 'Desktop')
{
    $moduleName = $awsPowerShellModuleName
}
else
{
    $moduleName = $awsPowerShellCoreModuleName
}

Write-Host "Checking for, and unloading, any previously loaded module..."
if (Get-Module -Name $moduleName)
{
    Write-Host "...removing previously loaded $moduleName module"
    Remove-Module -Name $moduleName
}

if (!(Test-Path -Path $ModuleFile))
{
    throw "$ModuleFile does not exist"
}

Write-Host "Importing module to test..."
Import-Module $ModuleFile

Write-Host "...loaded module"
$module = Get-Module -Name $moduleName

# validate that where we loaded from matches what was given
Write-Host "...verifying module load location matches supplied path"
$loadLocation = Split-Path -Path $module.Path
$expectedLoadLocation = Split-Path -Path (Resolve-Path $ModuleFile)

if ($loadLocation -ne $expectedLoadLocation)
{
    throw "Failed to load correct module. Module loaded from $loadLocation, not the supplied location $expectedLoadLocation. Cannot continue."
}

Write-Host "Verifying version..."
$moduleVersion = $module.Version.ToString()
if ($moduleVersion -eq $ExpectedVersion)
{
    Write-Host "...version check - PASS"
}
else
{
    throw "Imported module has version $moduleVersion, not expected version $ExpectedVersion"
}

Write-Host "Verifying module files are Authenticode-signed"
$filter = @("*.ps1","*.psm1","*.psd1","*.ps1xml")
$signableFiles = Get-ChildItem -Path $loadLocation\* -Include $filter | Select-Object -ExpandProperty Name

$signableFiles | ForEach-Object {
    Write-Host "......testing module file $_"
    $fileToTest = Join-Path $loadLocation $_
    if (!(Select-String -Path $fileToTest -Pattern $authenticodeSignatureStart -Quiet))
    {
        throw "Failed to locate start of Authenticode signature, $authenticodeSignatureStart, in module file $_."
    }
}

Write-Host "...module files signing check - PASS"
