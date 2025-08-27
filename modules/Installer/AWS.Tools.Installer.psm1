using namespace System
using namespace System.Collections.Generic
using namespace System.IO
using namespace System.IO.Compression
using namespace System.Management.Automation
using namespace System.Net
using namespace System.Net.Http
using namespace System.Threading.Tasks

# Load configuration from PSD1 files inline
$configPath = Join-Path -Path $PSScriptRoot -ChildPath "Config"
$script:Config = @{}

try
{
    $configFiles = Get-ChildItem -Path $configPath -Recurse -Filter "*.psd1"
    
    foreach ($file in $configFiles)
    {
        try
        {
            $configData = Import-PowerShellDataFile -Path $file.FullName
            $configName = $file.BaseName
            $script:Config[$configName] = $configData
        }
        catch
        {
            $PSCmdlet.ThrowTerminatingError(
                [System.Management.Automation.ErrorRecord]::new(
                    ([System.InvalidOperationException]"Failed to load configuration from $($file.Name): $($_.Exception.Message)"),
                    'ConfigLoadFailure',
                    [System.Management.Automation.ErrorCategory]::InvalidOperation,
                    $file
                )
            )
        }
    }
}
catch
{
    $PSCmdlet.ThrowTerminatingError(
        [System.Management.Automation.ErrorRecord]::new(
            ([System.InvalidOperationException]"Failed to get module configuration: $($_.Exception.Message)"),
            'ModuleConfigFailure',
            [System.Management.Automation.ErrorCategory]::InvalidOperation,
            $configPath
        )
    )
}

# Instantiated to be available within the scope of the files dot-sourced below.
$Script:ModuleRoot = $PSScriptRoot
$script:VersionCache = @{}
$script:LatestMajorVersion = $script:Config.versions.LatestMajorVersion

# Dot-source each private and public function during import of module
Get-ChildItem -Path "$PSScriptRoot/Private", "$PSScriptRoot/Public" -Filter *.ps1 -Recurse | 
ForEach-Object { . $_.FullName }

# Helper function to create proper PSModuleInfo mock objects in Pester tests.
function New-MockModule {
    param(
        [string]$Name,
        [Version]$Version,
        [string]$ModuleBase
    )
    
    # Create a real PSModuleInfo object using New-Module
    $module = New-Module -Name $Name -ScriptBlock {} 
    
    # Set default ModuleBase if not provided
    if (-not $ModuleBase) {
        # Use platform-agnostic path for cross-platform compatibility
        $ModuleBase = ([System.IO.Path]::Combine(([System.IO.Path]::GetTempPath()),"Modules", $Name))
    }
    
    # Add the required properties
    $module | Add-Member -MemberType NoteProperty -Name Version -Value $Version -Force
    $module | Add-Member -MemberType NoteProperty -Name Path -Value (Join-Path -Path $ModuleBase -ChildPath "$Name.psm1") -Force
    $module | Add-Member -MemberType NoteProperty -Name ModuleBase -Value $ModuleBase -Force
    
    # Add additional properties that might be expected
    $module | Add-Member -MemberType NoteProperty -Name ExportedFunctions -Value @{} -Force
    $module | Add-Member -MemberType NoteProperty -Name ExportedCmdlets -Value @{} -Force
    $module | Add-Member -MemberType NoteProperty -Name ExportedVariables -Value @{} -Force
    $module | Add-Member -MemberType NoteProperty -Name ExportedAliases -Value @{} -Force
    $module | Add-Member -MemberType NoteProperty -Name PrivateData -Value @{
        PSData = @{
            Tags = @("AWS", "Tools")
            ProjectUri = "https://github.com/aws/aws-tools-for-powershell"
            LicenseUri = "https://github.com/aws/aws-tools-for-powershell/blob/master/LICENSE"
        }
    } -Force
    
    return $module
}

# Version check that runs at import time
try {
    # Get current module version - more reliably than using $MyInvocation
    $moduleInfo = Get-Module -Name 'AWS.Tools.Installer' -ListAvailable | Where-Object { $_.ModuleBase -eq $PSScriptRoot } | Select-Object -First 1
    if (-not $moduleInfo) {
        # Fallback to reading the psd1 file directly
        $psd1Path = Join-Path -Path $PSScriptRoot -ChildPath 'AWS.Tools.Installer.psd1'
        if (Test-Path -Path $psd1Path) {
            $moduleData = Import-PowerShellDataFile -Path $psd1Path
            $currentVersion = [Version]$moduleData.ModuleVersion
        }
    } else {
        $currentVersion = $moduleInfo.Version
    }
    
    # Try to get latest version with fast timeout
    $latestVersion = Resolve-AWSToolsVersion -Name 'AWS.Tools.Installer' -Timeout $script:Config.network.HeadRequestTimeoutFast -ErrorAction SilentlyContinue
    
    # If latestVersion is null (which happens when using the latest endpoint), use the CurrentMinInstallerVersion from config
    if (-not $latestVersion -and $script:Config.versions.CurrentMinInstallerVersion) {
        $latestVersion = [Version]$script:Config.versions.CurrentMinInstallerVersion
    }
    
    # Compare versions and inform if newer version available
    if ($currentVersion -and $latestVersion -and $latestVersion -gt $currentVersion) {
        Write-Host "Note: A newer version of AWS.Tools.Installer is available: $latestVersion (Current: $currentVersion). Run 'Install-AWSToolsInstaller' to update."
    }
}
catch {
    # Silently continue
}
