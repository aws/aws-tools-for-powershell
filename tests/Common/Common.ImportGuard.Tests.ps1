BeforeAll {
    . "$PSScriptRoot/../../modules/AWSPowerShell/ImportGuard.ps1" -SkipInvocation
}

Describe -Tag "Smoke" "Common.ImportGuard.VersionMismatchCheck" {

    BeforeEach {
        $script:originalPSModulePath = $env:PSModulePath
        Get-ChildItem $TestDrive -Force -ErrorAction SilentlyContinue | Remove-Item -Recurse -Force -ErrorAction SilentlyContinue
        $env:PSModulePath = $TestDrive
    }

    AfterEach {
        $env:PSModulePath = $script:originalPSModulePath
    }

    Context "Versioned layout" {

        It "returns false when all modules are at the same version" {
            $null = New-Item -Path "$TestDrive/AWS.Tools.Common/5.0.206/AWS.Tools.Common.psd1" -Force
            Set-Content -Path "$TestDrive/AWS.Tools.Common/5.0.206/AWS.Tools.Common.psd1" -Value "ModuleVersion = '5.0.206'"
            $null = New-Item -Path "$TestDrive/AWS.Tools.S3/5.0.206/AWS.Tools.S3.psd1" -Force
            Set-Content -Path "$TestDrive/AWS.Tools.S3/5.0.206/AWS.Tools.S3.psd1" -Value "ModuleVersion = '5.0.206'"

            Test-AWSToolsVersionMismatch | Should -Be $false
        }

        It "returns true when a module is missing at the max version" {
            $null = New-Item -Path "$TestDrive/AWS.Tools.Common/5.0.206/AWS.Tools.Common.psd1" -Force
            Set-Content -Path "$TestDrive/AWS.Tools.Common/5.0.206/AWS.Tools.Common.psd1" -Value "ModuleVersion = '5.0.206'"
            $null = New-Item -Path "$TestDrive/AWS.Tools.S3/5.0.205/AWS.Tools.S3.psd1" -Force
            Set-Content -Path "$TestDrive/AWS.Tools.S3/5.0.205/AWS.Tools.S3.psd1" -Value "ModuleVersion = '5.0.205'"

            Test-AWSToolsVersionMismatch | Should -Be $true
        }

        It "returns false when module has multiple versions including the max" {
            $null = New-Item -Path "$TestDrive/AWS.Tools.Common/5.0.205/AWS.Tools.Common.psd1" -Force
            Set-Content -Path "$TestDrive/AWS.Tools.Common/5.0.205/AWS.Tools.Common.psd1" -Value "ModuleVersion = '5.0.205'"
            $null = New-Item -Path "$TestDrive/AWS.Tools.Common/5.0.206/AWS.Tools.Common.psd1" -Force
            Set-Content -Path "$TestDrive/AWS.Tools.Common/5.0.206/AWS.Tools.Common.psd1" -Value "ModuleVersion = '5.0.206'"
            $null = New-Item -Path "$TestDrive/AWS.Tools.S3/5.0.206/AWS.Tools.S3.psd1" -Force
            Set-Content -Path "$TestDrive/AWS.Tools.S3/5.0.206/AWS.Tools.S3.psd1" -Value "ModuleVersion = '5.0.206'"

            Test-AWSToolsVersionMismatch | Should -Be $false
        }

        It "returns true when module only exists at older version" {
            $null = New-Item -Path "$TestDrive/AWS.Tools.Common/5.0.206/AWS.Tools.Common.psd1" -Force
            Set-Content -Path "$TestDrive/AWS.Tools.Common/5.0.206/AWS.Tools.Common.psd1" -Value "ModuleVersion = '5.0.206'"
            $null = New-Item -Path "$TestDrive/AWS.Tools.S3/5.0.205/AWS.Tools.S3.psd1" -Force
            Set-Content -Path "$TestDrive/AWS.Tools.S3/5.0.205/AWS.Tools.S3.psd1" -Value "ModuleVersion = '5.0.205'"
            $null = New-Item -Path "$TestDrive/AWS.Tools.S3/5.0.206/AWS.Tools.S3.psd1" -Force
            Set-Content -Path "$TestDrive/AWS.Tools.S3/5.0.206/AWS.Tools.S3.psd1" -Value "ModuleVersion = '5.0.206'"
            $null = New-Item -Path "$TestDrive/AWS.Tools.EC2/5.0.205/AWS.Tools.EC2.psd1" -Force
            Set-Content -Path "$TestDrive/AWS.Tools.EC2/5.0.205/AWS.Tools.EC2.psd1" -Value "ModuleVersion = '5.0.205'"

            Test-AWSToolsVersionMismatch | Should -Be $true
        }
    }

    Context "Flat layout" {

        It "returns false when all modules are at the same version (flat)" {
            $null = New-Item -Path "$TestDrive/AWS.Tools.Common/AWS.Tools.Common.psd1" -Force
            Set-Content -Path "$TestDrive/AWS.Tools.Common/AWS.Tools.Common.psd1" -Value "ModuleVersion = '5.0.206'"
            $null = New-Item -Path "$TestDrive/AWS.Tools.S3/AWS.Tools.S3.psd1" -Force
            Set-Content -Path "$TestDrive/AWS.Tools.S3/AWS.Tools.S3.psd1" -Value "ModuleVersion = '5.0.206'"

            Test-AWSToolsVersionMismatch | Should -Be $false
        }

        It "returns true when flat layout has version mismatch" {
            $null = New-Item -Path "$TestDrive/AWS.Tools.Common/AWS.Tools.Common.psd1" -Force
            Set-Content -Path "$TestDrive/AWS.Tools.Common/AWS.Tools.Common.psd1" -Value "ModuleVersion = '5.0.206'"
            $null = New-Item -Path "$TestDrive/AWS.Tools.S3/AWS.Tools.S3.psd1" -Force
            Set-Content -Path "$TestDrive/AWS.Tools.S3/AWS.Tools.S3.psd1" -Value "ModuleVersion = '5.0.205'"

            Test-AWSToolsVersionMismatch | Should -Be $true
        }
    }

    Context "Multiple module variants check" {

        It "returns false when only one variant is installed" {
            $null = New-Item -Path "$TestDrive/AWSPowerShell" -ItemType Directory -Force
            Test-MultipleModuleVariantsInstalled @('AWSPowerShell', 'AWSPowerShell.NetCore', 'AWS.Tools.Common') | Should -Be $false
        }

        It "returns true when two variants are in the same directory" {
            $null = New-Item -Path "$TestDrive/AWSPowerShell" -ItemType Directory -Force
            $null = New-Item -Path "$TestDrive/AWS.Tools.Common" -ItemType Directory -Force
            Test-MultipleModuleVariantsInstalled @('AWSPowerShell', 'AWSPowerShell.NetCore', 'AWS.Tools.Common') | Should -Be $true
        }

        It "returns true when two variants are in different PSModulePath entries" {
            $secondPath = Join-Path $TestDrive 'second'
            $null = New-Item -Path "$TestDrive/AWSPowerShell" -ItemType Directory -Force
            $null = New-Item -Path "$secondPath/AWS.Tools.Common" -ItemType Directory -Force
            $env:PSModulePath = "$TestDrive$([System.IO.Path]::PathSeparator)$secondPath"
            Test-MultipleModuleVariantsInstalled @('AWSPowerShell', 'AWSPowerShell.NetCore', 'AWS.Tools.Common') | Should -Be $true
        }

        It "returns false when none are installed" {
            Test-MultipleModuleVariantsInstalled @('AWSPowerShell', 'AWSPowerShell.NetCore', 'AWS.Tools.Common') | Should -Be $false
        }
    }

    Context "Edge cases" {

        It "returns false when PSModulePath is empty" {
            $env:PSModulePath = ''
            Test-AWSToolsVersionMismatch | Should -Be $false
        }

        It "returns false when no AWS.Tools directories exist" {
            $null = New-Item -Path "$TestDrive/SomeOtherModule/SomeOtherModule.psd1" -Force
            Set-Content -Path "$TestDrive/SomeOtherModule/SomeOtherModule.psd1" -Value "ModuleVersion = '1.0.0'"

            Test-AWSToolsVersionMismatch | Should -Be $false
        }

        It "excludes AWS.Tools.Installer from mismatch check" {
            $null = New-Item -Path "$TestDrive/AWS.Tools.Common/5.0.206/AWS.Tools.Common.psd1" -Force
            Set-Content -Path "$TestDrive/AWS.Tools.Common/5.0.206/AWS.Tools.Common.psd1" -Value "ModuleVersion = '5.0.206'"
            $null = New-Item -Path "$TestDrive/AWS.Tools.Installer/1.0.0/AWS.Tools.Installer.psd1" -Force
            Set-Content -Path "$TestDrive/AWS.Tools.Installer/1.0.0/AWS.Tools.Installer.psd1" -Value "ModuleVersion = '1.0.0'"

            Test-AWSToolsVersionMismatch | Should -Be $false
        }

        It "ignores non-version subdirectories" {
            $null = New-Item -Path "$TestDrive/AWS.Tools.Common/5.0.206/AWS.Tools.Common.psd1" -Force
            Set-Content -Path "$TestDrive/AWS.Tools.Common/5.0.206/AWS.Tools.Common.psd1" -Value "ModuleVersion = '5.0.206'"
            $null = New-Item -Path "$TestDrive/AWS.Tools.Common/en-US/about.txt" -Force
            $null = New-Item -Path "$TestDrive/AWS.Tools.S3/5.0.206/AWS.Tools.S3.psd1" -Force
            Set-Content -Path "$TestDrive/AWS.Tools.S3/5.0.206/AWS.Tools.S3.psd1" -Value "ModuleVersion = '5.0.206'"

            Test-AWSToolsVersionMismatch | Should -Be $false
        }

        It "handles invalid psd1 content gracefully" {
            $null = New-Item -Path "$TestDrive/AWS.Tools.Common/5.0.206/AWS.Tools.Common.psd1" -Force
            Set-Content -Path "$TestDrive/AWS.Tools.Common/5.0.206/AWS.Tools.Common.psd1" -Value "ModuleVersion = '5.0.206'"
            $null = New-Item -Path "$TestDrive/AWS.Tools.S3/5.0.206/AWS.Tools.S3.psd1" -Force
            Set-Content -Path "$TestDrive/AWS.Tools.S3/5.0.206/AWS.Tools.S3.psd1" -Value "garbage content no version here"

            # Module with unparseable psd1 is skipped (not added to dictionary),
            # so only AWS.Tools.Common is tracked — no mismatch detected.
            Test-AWSToolsVersionMismatch | Should -Be $false
        }

        It "handles PSModulePath with nonexistent directories" {
            $env:PSModulePath = "/nonexistent/path$([System.IO.Path]::PathSeparator)$TestDrive"
            $null = New-Item -Path "$TestDrive/AWS.Tools.Common/5.0.206/AWS.Tools.Common.psd1" -Force
            Set-Content -Path "$TestDrive/AWS.Tools.Common/5.0.206/AWS.Tools.Common.psd1" -Value "ModuleVersion = '5.0.206'"
            $null = New-Item -Path "$TestDrive/AWS.Tools.S3/5.0.206/AWS.Tools.S3.psd1" -Force
            Set-Content -Path "$TestDrive/AWS.Tools.S3/5.0.206/AWS.Tools.S3.psd1" -Value "ModuleVersion = '5.0.206'"

            Test-AWSToolsVersionMismatch | Should -Be $false
        }
    }
}
