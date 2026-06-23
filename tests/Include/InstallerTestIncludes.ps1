# Gating helper for AWS.Tools.Installer Pester tests.
#
# Why this exists:
#   The Installer module now ships a precompiled AWS.Tools.Installer.dll. The
#   source-tree manifest at modules/Installer/AWS.Tools.Installer.psd1 is no
#   longer self-contained — its RequiredAssemblies expects the DLL alongside.
#   Tests must import from Deployment/AWS.Tools/AWS.Tools.Installer/, which is
#   populated by a modular build (full-build / staging-build with modular
#   components). preview-build does NOT build modular, so Installer tests have
#   nothing to import against on that path.
#
# How it works:
#   Each Installer Pester file dot-sources this script in BeforeDiscovery
#   (and BeforeAll if it needs the imported module). The script reads
#   $env:BuildType and either imports the deployed module or sets a global
#   skip flag. Test files mark every outermost Describe with
#   -Skip:$SkipInstallerTests so PREVIEW (and other build types) cleanly
#   short-circuits at runtime instead of failing on missing types.
#
# Gate logic ($env:BuildType driven):
#   RELEASE / DRY_RUN     → modular build is required. Throw if module missing.
#   <unset>               → local dev. Run only if module exists in Deployment/.
#                           If missing, skip (don't fail — local dev hasn't built).
#   anything else (PREVIEW, etc.) → skip with reason.
#
# Side effects on script scope (consumed by the test files):
#   $module                       → ModuleInfo of the imported AWS.Tools.Installer
#                                   (or $null if skipped). Some integration tests
#                                   call private functions via `& $module Get-AWSToolsZip`.
#   $global:SkipInstallerTests    → $true when the suite must be skipped.
#   $global:SkipInstallerReason   → human-readable reason string. Used only by
#                                   the helper itself to deduplicate the
#                                   "Skipping..." Write-Host across files.
#
# Logging:
#   When tests are skipped, prints one yellow "[InstallerTests] Skipping ..."
#   line per session (deduped by reason), NOT once per file.
#
# Adding a new Installer Pester file:
#   1. In BeforeDiscovery: . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")
#   2. In BeforeAll:       . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")
#                          (only needed if you reference $module)
#   3. On every outermost Describe block: -Skip:$SkipInstallerTests

$installerPath = Join-Path $PSScriptRoot "../../Deployment/AWS.Tools/AWS.Tools.Installer/AWS.Tools.Installer.psd1"
$buildType = $env:BuildType
$installerExists = Test-Path $installerPath

if ($buildType -in @('RELEASE', 'DRY_RUN')) {
    if (-not $installerExists) {
        throw "AWS.Tools.Installer module not found at $installerPath. BuildType=$buildType requires modular build artifacts; run a full or modular build first."
    }
    $module = Import-Module $installerPath -WarningAction Stop -Force -PassThru
    $global:SkipInstallerTests = $false
    $global:SkipInstallerReason = $null
}
elseif ([string]::IsNullOrEmpty($buildType) -and $installerExists) {
    $module = Import-Module $installerPath -WarningAction Stop -Force -PassThru
    $global:SkipInstallerTests = $false
    $global:SkipInstallerReason = $null
}
else {
    $reason = if (-not $installerExists -and [string]::IsNullOrEmpty($buildType)) {
        "AWS.Tools.Installer module not deployed at $installerPath (run a modular build first)."
    } elseif (-not $installerExists) {
        "BuildType=$buildType but AWS.Tools.Installer module not deployed at $installerPath."
    } else {
        "BuildType=$buildType (only RELEASE or DRY_RUN runs Installer tests; unset runs them when the module is deployed)."
    }
    if (-not $global:SkipInstallerTests -or $global:SkipInstallerReason -ne $reason) {
        Write-Host "[InstallerTests] Skipping AWS.Tools.Installer Pester tests: $reason" -ForegroundColor Yellow
    }
    $global:SkipInstallerTests = $true
    $global:SkipInstallerReason = $reason

    # Register a no-op stub module named AWS.Tools.Installer so that
    # `InModuleScope AWS.Tools.Installer { ... }` blocks at script scope (which
    # Pester evaluates during discovery, before -Skip can apply) bind cleanly
    # rather than throwing "No modules named 'AWS.Tools.Installer' are currently
    # loaded." The Describe blocks inside still skip via -Skip:$SkipInstallerTests
    # at run time, so the stub is never asked to do anything.
    if (-not (Get-Module -Name 'AWS.Tools.Installer')) {
        $module = New-Module -Name 'AWS.Tools.Installer' -ScriptBlock {} | Import-Module -PassThru
    }
    else {
        $module = Get-Module -Name 'AWS.Tools.Installer'
    }
}

# Helper function to create PSModuleInfo-shaped mock objects in Pester tests.
# Lives here (test-only) rather than in AWS.Tools.Installer.psm1 so production
# module code stays free of test scaffolding. Declared at global scope so it
# is reachable from inside InModuleScope blocks.
function global:New-MockModule {
    param(
        [string]$Name,
        [Version]$Version,
        [string]$ModuleBase
    )

    # Create a real PSModuleInfo object using New-Module.
    $module = New-Module -Name $Name -ScriptBlock {}

    # Set default ModuleBase if not provided.
    if (-not $ModuleBase) {
        # Use platform-agnostic path for cross-platform compatibility.
        $ModuleBase = ([System.IO.Path]::Combine(([System.IO.Path]::GetTempPath()), "Modules", $Name))
    }

    $module | Add-Member -MemberType NoteProperty -Name Version -Value $Version -Force
    $module | Add-Member -MemberType NoteProperty -Name Path -Value (Join-Path -Path $ModuleBase -ChildPath "$Name.psm1") -Force
    $module | Add-Member -MemberType NoteProperty -Name ModuleBase -Value $ModuleBase -Force

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
