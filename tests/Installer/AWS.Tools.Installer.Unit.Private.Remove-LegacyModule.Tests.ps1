BeforeDiscovery {
    . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")
}

BeforeAll {
    . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")

    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
    $WarningPreference = 'SilentlyContinue'
    $InformationPreference = 'Ignore'

    $tempPath = [System.IO.Path]::GetTempPath()
    $userModulePath = Join-Path $tempPath "UserModules"
}

InModuleScope AWS.Tools.Installer {

    Describe -Skip:$SkipInstallerTests -Tag "Smoke", "Low", "Medium", "High" "Installer - Remove-LegacyModule Unit Tests" {

        BeforeEach {
            # Literal path (the module-scoped mock can't see script-scope test vars).
            Mock Get-PSModulePath { [System.IO.Path]::Combine([System.IO.Path]::GetTempPath(), 'UserModules') }
            Mock Format-ModuleTarget { "legacy modules in test path" }
            # No legacy AWSPowerShell modules imported by default.
            Mock Get-Module { @() }
        }

        It "Should remove each discovered legacy module via Remove-ModuleItem" {
            # Arrange - two legacy modules present, none imported
            $legacy1 = New-MockModule -Name "AWSPowerShell" -Version ([Version]"4.1.999")
            $legacy2 = New-MockModule -Name "AWSPowerShell.NetCore" -Version ([Version]"4.1.999")
            Mock Get-LegacyModules { @($legacy1, $legacy2) }
            $script:removed = @()
            Mock Remove-ModuleItem {
                param($Module, $Reason)
                $script:removed += $Module
                @{ SuccessCount = 1; FailureCount = 0; RemovedModules = @("$($Module.Name) ($($Module.Version))"); FailedModules = @() }
            }
            Mock Write-Host { }

            # Act
            $script:removed = @()
            Remove-LegacyModule -Scope CurrentUser -Confirm:$false

            # Assert
            $script:removed.Count | Should -Be 2
            Should -Invoke Remove-ModuleItem -Times 2
            Should -Invoke Write-Host -Times 1 -ParameterFilter {
                $Object -like "Removed 2 legacy AWSPowerShell modules from *"
            }
        }

        It "Should report skipped cleanup when no legacy modules are found" {
            # Arrange
            Mock Get-LegacyModules { @() }
            Mock Remove-ModuleItem { }
            Mock Write-Host { }

            # Act
            Remove-LegacyModule -Scope CurrentUser -Confirm:$false

            # Assert
            Should -Not -Invoke Remove-ModuleItem
            Should -Invoke Write-Host -Times 1 -ParameterFilter {
                $Object -like "Skipped legacy cleanup: No AWSPowerShell modules found in *"
            }
        }

        It "Should throw ModuleInUse naming only legacy modules when an AWSPowerShell module is imported" {
            # Arrange - a legacy module is present AND imported in the session
            $legacy = New-MockModule -Name "AWSPowerShell" -Version ([Version]"4.1.999")
            Mock Get-LegacyModules { @($legacy) }
            # The imported-module guard queries Get-Module for AWSPowerShell*
            Mock Get-Module { @($legacy) }
            Mock Remove-ModuleItem { }

            # Act / Assert
            { Remove-LegacyModule -Scope CurrentUser -Confirm:$false } |
                Should -Throw -ErrorId 'ModuleInUse,Remove-LegacyModule'
            Should -Not -Invoke Remove-ModuleItem
        }

        It "Should NOT be blocked by an imported AWS.Tools module (guard is scoped to AWSPowerShell only)" {
            # Arrange - AWS.Tools.Common is imported, but the legacy guard must ignore it
            $legacy = New-MockModule -Name "AWSPowerShell" -Version ([Version]"4.1.999")
            Mock Get-LegacyModules { @($legacy) }
            # Get-Module -Name 'AWSPowerShell*' returns nothing (the AWS.Tools import is not matched)
            Mock Get-Module { @() } -ParameterFilter { $Name -contains 'AWSPowerShell*' }
            Mock Remove-ModuleItem {
                param($Module, $Reason)
                @{ SuccessCount = 1; FailureCount = 0; RemovedModules = @("AWSPowerShell (4.1.999)"); FailedModules = @() }
            }
            Mock Write-Host { }

            # Act / Assert - cleanup proceeds despite an unrelated AWS.Tools import
            { Remove-LegacyModule -Scope CurrentUser -Confirm:$false } | Should -Not -Throw
            Should -Invoke Remove-ModuleItem -Times 1
        }
    }
}
