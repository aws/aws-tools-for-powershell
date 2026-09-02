BeforeDiscovery {
    . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")
}

BeforeAll {
    . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")

    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
    $WarningPreference = 'SilentlyContinue'
    $InformationPreference = 'Ignore'
}

InModuleScope AWS.Tools.Installer {

    Describe -Skip:$SkipInstallerTests -Tag "Smoke", "Low", "Medium", "High" "Installer - Get-ModuleVersionSummary Unit Tests" {

        It "Should return the single version for one module" {
            # Arrange
            $modules = @( (New-MockModule -Name "AWS.Tools.EC2" -Version ([Version]"5.0.10")) )

            # Act
            $result = Get-ModuleVersionSummary -Modules $modules

            # Assert
            $result.VersionList | Should -Be "5.0.10"
            $result.DistinctCount | Should -Be 1
        }

        It "Should collapse duplicate versions to a single distinct entry" {
            # Arrange - many modules, all on the same version
            $modules = @(
                (New-MockModule -Name "AWS.Tools.EC2" -Version ([Version]"5.0.10")),
                (New-MockModule -Name "AWS.Tools.S3" -Version ([Version]"5.0.10")),
                (New-MockModule -Name "AWS.Tools.Common" -Version ([Version]"5.0.10"))
            )

            # Act
            $result = Get-ModuleVersionSummary -Modules $modules

            # Assert
            $result.VersionList | Should -Be "5.0.10"
            $result.DistinctCount | Should -Be 1
        }

        It "Should list multiple distinct versions" {
            # Arrange
            $modules = @(
                (New-MockModule -Name "AWS.Tools.EC2" -Version ([Version]"5.0.10")),
                (New-MockModule -Name "AWS.Tools.S3" -Version ([Version]"5.0.11"))
            )

            # Act
            $result = Get-ModuleVersionSummary -Modules $modules

            # Assert
            $result.DistinctCount | Should -Be 2
            $result.VersionList | Should -Match "5\.0\.10"
            $result.VersionList | Should -Match "5\.0\.11"
        }

        It "Should truncate with 'and N more' when distinct versions exceed MaxVersionsToShow" {
            # Arrange - 7 distinct versions (MaxVersionsToShow defaults to 5)
            $modules = @(
                (New-MockModule -Name "AWS.Tools.Common" -Version ([Version]"5.0.10")),
                (New-MockModule -Name "AWS.Tools.EC2" -Version ([Version]"5.0.11")),
                (New-MockModule -Name "AWS.Tools.S3" -Version ([Version]"5.0.12")),
                (New-MockModule -Name "AWS.Tools.Lambda" -Version ([Version]"5.0.13")),
                (New-MockModule -Name "AWS.Tools.DynamoDBv2" -Version ([Version]"5.0.14")),
                (New-MockModule -Name "AWS.Tools.CloudWatch" -Version ([Version]"5.0.15")),
                (New-MockModule -Name "AWS.Tools.IAM" -Version ([Version]"5.0.16"))
            )

            # Act
            $result = Get-ModuleVersionSummary -Modules $modules

            # Assert
            $result.DistinctCount | Should -Be 7
            $result.VersionList | Should -Match "and 2 more$"
        }

        It "Should NOT truncate when there are exactly MaxVersionsToShow distinct versions" {
            # Arrange - exactly 5 distinct versions
            $modules = @(
                (New-MockModule -Name "AWS.Tools.Common" -Version ([Version]"5.0.10")),
                (New-MockModule -Name "AWS.Tools.EC2" -Version ([Version]"5.0.11")),
                (New-MockModule -Name "AWS.Tools.S3" -Version ([Version]"5.0.12")),
                (New-MockModule -Name "AWS.Tools.Lambda" -Version ([Version]"5.0.13")),
                (New-MockModule -Name "AWS.Tools.DynamoDBv2" -Version ([Version]"5.0.14"))
            )

            # Act
            $result = Get-ModuleVersionSummary -Modules $modules

            # Assert
            $result.DistinctCount | Should -Be 5
            $result.VersionList | Should -Not -Match "more"
        }

        It "Should return an empty list and zero count for an empty collection" {
            # Act
            $result = Get-ModuleVersionSummary -Modules @()

            # Assert
            $result.VersionList | Should -Be ""
            $result.DistinctCount | Should -Be 0
        }
    }
}
