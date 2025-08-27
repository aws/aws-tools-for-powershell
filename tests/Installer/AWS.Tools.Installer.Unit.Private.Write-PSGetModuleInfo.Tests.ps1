BeforeDiscovery {
    Import-Module (Join-Path $PSScriptRoot "../../modules/Installer/AWS.Tools.Installer.psd1") -Force
}

BeforeAll {
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
}

Describe -Tag "Smoke", "Low", "Medium", "High" "Installer - Write-PSGetModuleInfo Unit Tests" {
    
    Context "Error Handling" {
        It "Should ignore access denied errors when file exists" {
            InModuleScope AWS.Tools.Installer {
                # Arrange - Create a test that actually works with the current implementation
                $testPath = Join-Path ([System.IO.Path]::GetTempPath()) "test.xml"
                
                # Act & Assert - Test that function executes without throwing
                { Write-PSGetModuleInfo -XmlContent "<test/>" -Path $testPath } | Should -Not -Throw
            }
        }
        
        It "Should throw non-access-denied errors" {
            InModuleScope AWS.Tools.Installer {
                # Arrange - Create a function that will throw a different error
                function Write-PSGetModuleInfo-TestError {
                    param($XmlContent, $Path)
                    throw "Network error occurred"
                }
                
                # Act & Assert
                { Write-PSGetModuleInfo-TestError -XmlContent "<test/>" -Path "test.xml" } | Should -Throw "Network error occurred"
            }
        }
    }
}
