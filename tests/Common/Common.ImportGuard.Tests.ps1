BeforeAll {
    # Load ImportGuard.ps1 with -SkipInvocation to compile the C# AWSToolsModuleVersionChecker type
    # without running the import guard logic.
    . ..\Deployment\AWSPowerShell\ImportGuard.ps1 -SkipInvocation

    if (-not ([System.Management.Automation.PSTypeName]'AWSToolsModuleVersionChecker').Type) {
        throw "AWSToolsModuleVersionChecker type not found. ImportGuard.ps1 may not have been loaded."
    }
}

Describe -Tag "Smoke" "Common.ImportGuard.VersionMismatchCheck" {

    BeforeEach {
        $script:originalPSModulePath = $env:PSModulePath
        # Clean TestDrive between tests to avoid leftover files from previous It blocks
        Get-ChildItem $TestDrive -Force -ErrorAction SilentlyContinue | Remove-Item -Recurse -Force -ErrorAction SilentlyContinue
        $env:PSModulePath = $TestDrive
    }

    AfterEach {
        $env:PSModulePath = $script:originalPSModulePath
    }

    Context "Versioned layout" {

        It "returns false when all modules are at the same version" {
            $null = New-Item -Path "TestDrive:\AWS.Tools.Common\5.0.206\AWS.Tools.Common.psd1" -Force
            Set-Content "TestDrive:\AWS.Tools.Common\5.0.206\AWS.Tools.Common.psd1" "ModuleVersion = '5.0.206'"
            $null = New-Item -Path "TestDrive:\AWS.Tools.S3\5.0.206\AWS.Tools.S3.psd1" -Force
            Set-Content "TestDrive:\AWS.Tools.S3\5.0.206\AWS.Tools.S3.psd1" "ModuleVersion = '5.0.206'"
            $null = New-Item -Path "TestDrive:\AWS.Tools.EC2\5.0.206\AWS.Tools.EC2.psd1" -Force
            Set-Content "TestDrive:\AWS.Tools.EC2\5.0.206\AWS.Tools.EC2.psd1" "ModuleVersion = '5.0.206'"

            [AWSToolsModuleVersionChecker]::HasVersionMismatch() | Should -Be $false
        }

        It "returns true when a module exists only at an older version" {
            $null = New-Item -Path "TestDrive:\AWS.Tools.Common\5.0.206\AWS.Tools.Common.psd1" -Force
            Set-Content "TestDrive:\AWS.Tools.Common\5.0.206\AWS.Tools.Common.psd1" "ModuleVersion = '5.0.206'"
            $null = New-Item -Path "TestDrive:\AWS.Tools.S3\5.0.206\AWS.Tools.S3.psd1" -Force
            Set-Content "TestDrive:\AWS.Tools.S3\5.0.206\AWS.Tools.S3.psd1" "ModuleVersion = '5.0.206'"
            $null = New-Item -Path "TestDrive:\AWS.Tools.EC2\5.0.200\AWS.Tools.EC2.psd1" -Force
            Set-Content "TestDrive:\AWS.Tools.EC2\5.0.200\AWS.Tools.EC2.psd1" "ModuleVersion = '5.0.200'"

            [AWSToolsModuleVersionChecker]::HasVersionMismatch() | Should -Be $true
        }

        It "returns false when module has both old and new version" {
            $null = New-Item -Path "TestDrive:\AWS.Tools.Common\5.0.200\AWS.Tools.Common.psd1" -Force
            Set-Content "TestDrive:\AWS.Tools.Common\5.0.200\AWS.Tools.Common.psd1" "ModuleVersion = '5.0.200'"
            $null = New-Item -Path "TestDrive:\AWS.Tools.Common\5.0.206\AWS.Tools.Common.psd1" -Force
            Set-Content "TestDrive:\AWS.Tools.Common\5.0.206\AWS.Tools.Common.psd1" "ModuleVersion = '5.0.206'"
            $null = New-Item -Path "TestDrive:\AWS.Tools.S3\5.0.206\AWS.Tools.S3.psd1" -Force
            Set-Content "TestDrive:\AWS.Tools.S3\5.0.206\AWS.Tools.S3.psd1" "ModuleVersion = '5.0.206'"
            $null = New-Item -Path "TestDrive:\AWS.Tools.EC2\5.0.200\AWS.Tools.EC2.psd1" -Force
            Set-Content "TestDrive:\AWS.Tools.EC2\5.0.200\AWS.Tools.EC2.psd1" "ModuleVersion = '5.0.200'"
            $null = New-Item -Path "TestDrive:\AWS.Tools.EC2\5.0.206\AWS.Tools.EC2.psd1" -Force
            Set-Content "TestDrive:\AWS.Tools.EC2\5.0.206\AWS.Tools.EC2.psd1" "ModuleVersion = '5.0.206'"

            [AWSToolsModuleVersionChecker]::HasVersionMismatch() | Should -Be $false
        }

        It "returns false with a single module installed" {
            $null = New-Item -Path "TestDrive:\AWS.Tools.Common\5.0.206\AWS.Tools.Common.psd1" -Force
            Set-Content "TestDrive:\AWS.Tools.Common\5.0.206\AWS.Tools.Common.psd1" "ModuleVersion = '5.0.206'"

            [AWSToolsModuleVersionChecker]::HasVersionMismatch() | Should -Be $false
        }

        It "excludes AWS.Tools.Installer from mismatch check" {
            $null = New-Item -Path "TestDrive:\AWS.Tools.Common\5.0.206\AWS.Tools.Common.psd1" -Force
            Set-Content "TestDrive:\AWS.Tools.Common\5.0.206\AWS.Tools.Common.psd1" "ModuleVersion = '5.0.206'"
            $null = New-Item -Path "TestDrive:\AWS.Tools.Installer\1.0.0\AWS.Tools.Installer.psd1" -Force
            Set-Content "TestDrive:\AWS.Tools.Installer\1.0.0\AWS.Tools.Installer.psd1" "ModuleVersion = '1.0.0'"

            [AWSToolsModuleVersionChecker]::HasVersionMismatch() | Should -Be $false
        }
    }

    Context "Flat layout" {

        It "returns false when all flat modules are at the same version" {
            $null = New-Item -Path "TestDrive:\AWS.Tools.Common\AWS.Tools.Common.psd1" -Force
            Set-Content "TestDrive:\AWS.Tools.Common\AWS.Tools.Common.psd1" "ModuleVersion = '5.0.206'"
            $null = New-Item -Path "TestDrive:\AWS.Tools.S3\AWS.Tools.S3.psd1" -Force
            Set-Content "TestDrive:\AWS.Tools.S3\AWS.Tools.S3.psd1" "ModuleVersion = '5.0.206'"

            [AWSToolsModuleVersionChecker]::HasVersionMismatch() | Should -Be $false
        }

        It "returns true when flat modules have mismatched versions" {
            $null = New-Item -Path "TestDrive:\AWS.Tools.Common\AWS.Tools.Common.psd1" -Force
            Set-Content "TestDrive:\AWS.Tools.Common\AWS.Tools.Common.psd1" "ModuleVersion = '5.0.206'"
            $null = New-Item -Path "TestDrive:\AWS.Tools.EC2\AWS.Tools.EC2.psd1" -Force
            Set-Content "TestDrive:\AWS.Tools.EC2\AWS.Tools.EC2.psd1" "ModuleVersion = '5.0.200'"

            [AWSToolsModuleVersionChecker]::HasVersionMismatch() | Should -Be $true
        }
    }

    Context "Edge cases" {

        It "returns false with empty PSModulePath" {
            $env:PSModulePath = ''
            [AWSToolsModuleVersionChecker]::HasVersionMismatch() | Should -Be $false
        }

        It "returns false with non-existent path" {
            $env:PSModulePath = 'C:\NonExistent\Path\That\Does\Not\Exist'
            [AWSToolsModuleVersionChecker]::HasVersionMismatch() | Should -Be $false
        }

        It "returns false when no AWS.Tools modules exist" {
            $null = New-Item -Path "TestDrive:\SomeOtherModule\1.0.0\SomeOtherModule.psd1" -Force
            Set-Content "TestDrive:\SomeOtherModule\1.0.0\SomeOtherModule.psd1" "ModuleVersion = '1.0.0'"

            [AWSToolsModuleVersionChecker]::HasVersionMismatch() | Should -Be $false
        }

        It "skips version directories without a .psd1 file" {
            $null = New-Item -Path "TestDrive:\AWS.Tools.Common\5.0.206\AWS.Tools.Common.psd1" -Force
            Set-Content "TestDrive:\AWS.Tools.Common\5.0.206\AWS.Tools.Common.psd1" "ModuleVersion = '5.0.206'"
            $null = New-Item -Path "TestDrive:\AWS.Tools.S3\5.0.206" -ItemType Directory -Force

            [AWSToolsModuleVersionChecker]::HasVersionMismatch() | Should -Be $false
        }

        It "skips non-version subdirectories" {
            $null = New-Item -Path "TestDrive:\AWS.Tools.Common\5.0.206\AWS.Tools.Common.psd1" -Force
            Set-Content "TestDrive:\AWS.Tools.Common\5.0.206\AWS.Tools.Common.psd1" "ModuleVersion = '5.0.206'"
            $null = New-Item -Path "TestDrive:\AWS.Tools.Common\en-US" -ItemType Directory -Force

            [AWSToolsModuleVersionChecker]::HasVersionMismatch() | Should -Be $false
        }

        It "scans multiple PSModulePath entries" {
            $path1 = Join-Path $TestDrive 'path1'
            $path2 = Join-Path $TestDrive 'path2'
            $null = New-Item -Path "$path1\AWS.Tools.Common\5.0.206\AWS.Tools.Common.psd1" -Force
            Set-Content "$path1\AWS.Tools.Common\5.0.206\AWS.Tools.Common.psd1" "ModuleVersion = '5.0.206'"
            $null = New-Item -Path "$path2\AWS.Tools.EC2\5.0.200\AWS.Tools.EC2.psd1" -Force
            Set-Content "$path2\AWS.Tools.EC2\5.0.200\AWS.Tools.EC2.psd1" "ModuleVersion = '5.0.200'"

            $env:PSModulePath = $path1 + [IO.Path]::PathSeparator + $path2
            [AWSToolsModuleVersionChecker]::HasVersionMismatch() | Should -Be $true
        }
    }
}
