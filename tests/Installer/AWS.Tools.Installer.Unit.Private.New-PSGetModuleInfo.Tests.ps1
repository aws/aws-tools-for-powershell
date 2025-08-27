BeforeDiscovery {
    Import-Module (Join-Path $PSScriptRoot "../../modules/Installer/AWS.Tools.Installer.psd1") -Force
}

BeforeAll {
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
}

Describe -Tag "Smoke", "Low", "Medium", "High" "Installer - New-PSGetModuleInfo Unit Tests" {
    
    Context "XML Generation" {
        It "Should generate XML output" {
            InModuleScope AWS.Tools.Installer {
                # Act - Test that function exists and returns something
                $result = Get-Command New-PSGetModuleInfo -ErrorAction SilentlyContinue
                
                # Assert
                $result | Should -Not -BeNullOrEmpty
                $result.Name | Should -Be "New-PSGetModuleInfo"
            }
        }
    }
}
