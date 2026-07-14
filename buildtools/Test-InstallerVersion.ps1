param
(
    [Parameter(Mandatory, HelpMessage="Start commit reference")]$From,
    [Parameter(HelpMessage="End commit reference")]$To = "HEAD^"
)

function Test-Version ([System.Version]$version) {
    if ($version.Revision -ne -1) {
        throw "Version must be 3-part (major.minor.build) without a revision value. Current version: $version";
    }
    Write-Host "Version is valid 3-part format: $version";
}

function Test-InstallerVersion([string]$from, [string]$to) {
    $response = git diff --name-only $from $to

    # check if there are any changes in the installer
    $isInstallerUpdated = $false
    foreach ($file in $response) {
        if ($file -like "modules/Installer/*") {
            $isInstallerUpdated = $true
        }
    }

    # if there are no changes in the installer, return success
    if ($isInstallerUpdated -eq $false) {
        Write-Host "AWS.Tools.Installer is not updated"
        exit 0
    }

    # get the publicly available version of the installer
    $publicInstallerModule = Find-Module -Name AWS.Tools.Installer
    $publicVersion = $publicInstallerModule.Version
    Write-Host "Public AWS.Tools.Installer version: $publicVersion"

    # get the local version of the installer

    # Read ModuleVersion directly from the manifest as data. We must not Import-Module
    # here: the source-tree manifest declares RequiredAssemblies = @('AWS.Tools.Installer.dll'),
    # a compiled build artifact that does not exist in this source-only checkout, so
    # Import-Module fails. Importability is validated downstream against the built module
    # (see tests/Include/InstallerTestIncludes.ps1). This check only needs the version.
    $installerModulePath = Join-Path  "." "modules" "Installer" "AWS.Tools.Installer.psd1"
    $manifest = Import-PowerShellDataFile $installerModulePath
    [System.Version]$localVersion = $manifest.ModuleVersion
    Write-Host "Local AWS.Tools.Installer version: $localVersion"

    # check if the new version has 0 revision
    Test-Version -Version $localVersion

    if ($localVersion -le $publicVersion) {
        throw "Local AWS.Tools.Installer version is less than or equal to public version.
Bump the version in modules/Installer/AWS.Tools.Installer.psd1 else the installer will not be updated in the PowerShell Gallery."
    }

    Write-Host "Local AWS.Tools.Installer version ($localVersion) is greater than public version ($publicVersion)."
}

Test-InstallerVersion -From $From -To $To
