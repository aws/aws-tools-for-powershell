BeforeDiscovery {
    Import-Module (Join-Path $PSScriptRoot "../../modules/Installer/AWS.Tools.Installer.psd1") -Force
}

BeforeAll {
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
}

InModuleScope AWS.Tools.Installer {
    Describe -Tag "Smoke", "Low", "Medium", "High" "Installer - Get-CleanVersion Unit Tests" {
    
        Context "Get-CleanVersion" {
            It "Should return null for null input" {
                # Arrange & Act
                $result = Get-CleanVersion -Version $null
                
                # Assert
                $result | Should -BeNullOrEmpty
            }
        
            It "Should return version object for valid input" {
                # Arrange
                $version = [Version]"4.1.853"
                
                # Act
                $result = Get-CleanVersion -Version $version
                
                # Assert
                $result | Should -BeOfType [Version]
                $result.Major | Should -Be 4
                $result.Minor | Should -Be 1
                $result.Build | Should -Be 853
            }
        
            It "Should handle string version input" {
                # Arrange
                $version = [Version]"4.1.853"
                
                # Act
                $result = Get-CleanVersion -Version $version
                
                # Assert
                $result | Should -Be ([Version]"4.1.853.0")
            }
        }
    }
}
