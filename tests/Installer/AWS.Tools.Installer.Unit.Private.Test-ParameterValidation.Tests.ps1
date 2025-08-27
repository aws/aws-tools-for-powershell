BeforeDiscovery {
    Import-Module (Join-Path $PSScriptRoot "../../modules/Installer/AWS.Tools.Installer.psd1") -Force
}

BeforeAll {
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
}

Describe -Tag "Smoke", "Low", "Medium", "High" "Installer - Test-ParameterValidation Unit Tests" {
    
    Context "Parameter Validation" {
        It "Should validate absolute paths" {
            InModuleScope AWS.Tools.Installer {
                # Act & Assert
                { Test-ParameterValidation -Path "relative\path" } | Should -Throw "*must be an absolute path*"
            }
        }
        
        It "Should validate version minimum for both module types" {
            InModuleScope AWS.Tools.Installer {
                # Act & Assert - Should throw for AWS.Tools modules below 4.0.0
                { Test-ParameterValidation -Version ([Version]"3.0.0") -ModuleName 'AWS.Tools' } | Should -Throw "*must be 4.0.0 or higher*"
                
                # Act & Assert - Should NOT throw for AWS.Tools modules at or above 4.0.0
                { Test-ParameterValidation -Version ([Version]"4.0.0") -ModuleName 'AWS.Tools' } | Should -Not -Throw
                
                # Act & Assert - Should throw for AWS.Tools.Installer modules below 1.0.3
                { Test-ParameterValidation -Version ([Version]"1.0.2") -ModuleName 'AWS.Tools.Installer' } | Should -Throw "*must be 1.0.3 or higher*"
                
                # Act & Assert - Should NOT throw for AWS.Tools.Installer modules at or above 1.0.3
                { Test-ParameterValidation -Version ([Version]"1.0.3") -ModuleName 'AWS.Tools.Installer' } | Should -Not -Throw
            }
        }
        
        It "Should validate path existence when required" {
            InModuleScope AWS.Tools.Installer {
                # Arrange
                $nonExistentPath = Join-Path ([System.IO.Path]::GetTempPath()) "NonExistentPath12345"
                
                # Act & Assert
                { Test-ParameterValidation -Path $nonExistentPath -PathMustExist } | Should -Throw "Path does not exist:*"
            }
        }
        
        It "Should validate timeout range" {
            InModuleScope AWS.Tools.Installer {
                # Act & Assert
                { Test-ParameterValidation -Timeout 5 } | Should -Throw "*must be between 10 and 3600*"
                { Test-ParameterValidation -Timeout 4000 } | Should -Throw "*must be between 10 and 3600*"
            }
        }
    }
}
