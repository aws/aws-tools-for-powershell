BeforeDiscovery {
    . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")
}

BeforeAll {
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
    $WarningPreference = 'SilentlyContinue'
    $InformationPreference = 'Ignore'
}

# Why this file exists:
#   The .psm1 calls into the precompiled [Amazon.PowerShell.Installer.ModuleInstaller]
#   type with plain types (string[], 4 args / 1 arg). C#-from-C# tests in
#   tests/dotnet/Installer.Tests/ cover the API for C# callers, but they cannot
#   detect a PowerShell overload-resolution regression: PS uses runtime
#   MethodInfo.Invoke and is fragile against C# default-valued parameters.
#
#   These tests invoke the static methods from PowerShell with the same arity
#   and types that the .psm1 uses, so a future refactor that breaks PS binding
#   fails here at unit-test time instead of at install/uninstall time.

Describe -Skip:$SkipInstallerTests -Tag "Smoke", "Low", "Medium", "High" "Installer - Native overload binding from PowerShell" {

    Context "DeleteDirectoriesParallel" {
        It "Binds with single string[] argument" {
            $tmp = Join-Path ([System.IO.Path]::GetTempPath()) ("psbind-del-" + [System.Guid]::NewGuid().ToString("N"))
            New-Item -ItemType Directory -Path $tmp | Out-Null
            try {
                # Wrap with @() because PS unwraps an empty string[] return to $null on assignment.
                $failed = @([Amazon.PowerShell.Installer.ModuleInstaller]::DeleteDirectoriesParallel(@($tmp)))
                $failed.Count | Should -Be 0
                (Test-Path $tmp) | Should -Be $false
            }
            finally {
                if (Test-Path $tmp) { Remove-Item -Recurse -Force $tmp }
            }
        }

        It "Tolerates a path that does not exist" {
            $missing = Join-Path ([System.IO.Path]::GetTempPath()) ("psbind-missing-" + [System.Guid]::NewGuid().ToString("N"))
            $failed = @([Amazon.PowerShell.Installer.ModuleInstaller]::DeleteDirectoriesParallel(@($missing)))
            $failed.Count | Should -Be 0
        }

        It "Binds with the 2-arg shape (explicit CancellationToken) used by Uninstall-AWSToolsModule.ps1" {
            $tmp = Join-Path ([System.IO.Path]::GetTempPath()) ("psbind-del-ct-" + [System.Guid]::NewGuid().ToString("N"))
            New-Item -ItemType Directory -Path $tmp | Out-Null
            try {
                $ct = [System.Threading.CancellationToken]::None
                $failed = @([Amazon.PowerShell.Installer.ModuleInstaller]::DeleteDirectoriesParallel(@($tmp), $ct))
                $failed.Count | Should -Be 0
                (Test-Path $tmp) | Should -Be $false
            }
            finally {
                if (Test-Path $tmp) { Remove-Item -Recurse -Force $tmp }
            }
        }
    }

    Context "ExtractAndInstall" {
        It "Binds with the legacy 4-arg shape (CancellationToken default-valued) for backward compat" {
            $tempRoot = Join-Path ([System.IO.Path]::GetTempPath()) ("psbind-ext-" + [System.Guid]::NewGuid().ToString("N"))
            $srcDir   = Join-Path $tempRoot "src/AWS.Tools.Common/5.0.0"
            $outDir   = Join-Path $tempRoot "out"
            $zipPath  = Join-Path $tempRoot "AWS.Tools.zip"
            New-Item -ItemType Directory -Path $srcDir -Force | Out-Null
            New-Item -ItemType Directory -Path $outDir -Force | Out-Null

            try {
                @"
@{
    ModuleVersion = '5.0.0'
    GUID = '00000000-0000-0000-0000-000000000000'
    Author = 'Amazon'
    CompanyName = 'Amazon'
    Description = 'Synthetic test psd1.'
    Copyright = '(c)'
    CmdletsToExport = @()
    PrivateData = @{ PSData = @{ Tags = @('AWS') } }
}
"@ | Set-Content -Path (Join-Path $srcDir "AWS.Tools.Common.psd1")

                Add-Type -AssemblyName System.IO.Compression.FileSystem -ErrorAction Stop
                [System.IO.Compression.ZipFile]::CreateFromDirectory((Join-Path $tempRoot "src"), $zipPath)

                # The .psm1 caller passes 5 args (with $CancellationToken). PS overload
                # resolution must still accept the 4-arg call against the 5-arg signature
                # because the trailing CancellationToken parameter has a default value.
                $results = [Amazon.PowerShell.Installer.ModuleInstaller]::ExtractAndInstall(
                    $zipPath, $outDir, $null, $null)

                $results.Count | Should -BeGreaterThan 0
                ($results | Where-Object { $_.Name -eq 'AWS.Tools.Common' }).Count | Should -Be 1
            }
            finally {
                if (Test-Path $tempRoot) { Remove-Item -Recurse -Force $tempRoot }
            }
        }

        It "Binds with the 5-arg shape (explicit CancellationToken) used by the .psm1 today" {
            $tempRoot = Join-Path ([System.IO.Path]::GetTempPath()) ("psbind-ext5-" + [System.Guid]::NewGuid().ToString("N"))
            $srcDir   = Join-Path $tempRoot "src/AWS.Tools.Common/5.0.0"
            $outDir   = Join-Path $tempRoot "out"
            $zipPath  = Join-Path $tempRoot "AWS.Tools.zip"
            New-Item -ItemType Directory -Path $srcDir -Force | Out-Null
            New-Item -ItemType Directory -Path $outDir -Force | Out-Null

            try {
                @"
@{
    ModuleVersion = '5.0.0'
    GUID = '00000000-0000-0000-0000-000000000000'
    Author = 'Amazon'
    CompanyName = 'Amazon'
    Description = 'Synthetic test psd1.'
    Copyright = '(c)'
    CmdletsToExport = @()
    PrivateData = @{ PSData = @{ Tags = @('AWS') } }
}
"@ | Set-Content -Path (Join-Path $srcDir "AWS.Tools.Common.psd1")

                Add-Type -AssemblyName System.IO.Compression.FileSystem -ErrorAction Stop
                [System.IO.Compression.ZipFile]::CreateFromDirectory((Join-Path $tempRoot "src"), $zipPath)

                # 5-arg call shape: matches what Install-AWSToolsModuleFromZip.ps1 does
                # when $PSCmdlet.StoppingToken is available.
                $ct = [System.Threading.CancellationToken]::None
                $results = [Amazon.PowerShell.Installer.ModuleInstaller]::ExtractAndInstall(
                    $zipPath, $outDir, $null, $null, $ct)

                $results.Count | Should -BeGreaterThan 0
                ($results | Where-Object { $_.Name -eq 'AWS.Tools.Common' }).Count | Should -Be 1
            }
            finally {
                if (Test-Path $tempRoot) { Remove-Item -Recurse -Force $tempRoot }
            }
        }
    }

    Context "MissingModulesException" {
        It "Is reachable as a typed exception from PowerShell" {
            $missing = New-Object 'System.Collections.Generic.List[string]'
            $missing.Add("AWS.Tools.NotARealModule")
            $ex = [Amazon.PowerShell.Installer.MissingModulesException]::new($missing)
            $ex.MissingModules | Should -Contain "AWS.Tools.NotARealModule"
            $ex.Message | Should -Match "AWS.Tools.NotARealModule"
        }
    }
}
