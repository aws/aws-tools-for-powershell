BeforeDiscovery {
    Import-Module (Join-Path $PSScriptRoot "../../modules/Installer/AWS.Tools.Installer.psd1") -Force
}

BeforeAll {
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
}

InModuleScope AWS.Tools.Installer {
    Describe -Tag "Smoke", "Low", "Medium", "High" "Installer - Get-LegacyModules Unit Tests" {
        
        BeforeAll {
            # Use TestDrive for isolated test directories
            $script:testModulePath = Join-Path $TestDrive "TestModules"
            $script:differentPath = Join-Path $TestDrive "DifferentPath"
            
            # Mock Get-Module to return test legacy modules
            Mock Get-Module {
                return @(
                    (New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                        Name = "AWSPowerShell"
                        Version = [Version]"3.3.618"
                        ModuleBase = Join-Path $script:testModulePath "AWSPowerShell/3.3.618"
                    }),
                    (New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                        Name = "AWSPowerShell.NetCore"
                        Version = [Version]"3.3.618"
                        ModuleBase = Join-Path $script:testModulePath "AWSPowerShell.NetCore/3.3.618"
                    }),
                    (New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                        Name = "AWSPowerShell"
                        Version = [Version]"4.0.0"
                        ModuleBase = Join-Path $script:testModulePath "AWSPowerShell/4.0.0"
                    }),
                    (New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                        Name = "AWSPowerShell.NetCore"
                        Version = [Version]"4.0.0"
                        ModuleBase = Join-Path $script:differentPath "AWSPowerShell.NetCore/4.0.0"
                    })
                )
            } -ParameterFilter { $Name -eq 'AWSPowerShell*' -and $ListAvailable }
        }
        
        Context "Basic Functionality" {
            It "Should return legacy modules from target path" {
                # Act
                $result = Get-LegacyModules -TargetPath $script:testModulePath
                
                # Assert
                $result | Should -Not -BeNullOrEmpty
                $result | Should -HaveCount 3  # 3 modules in testModulePath, 1 in different path
                $result.Name | Should -Contain "AWSPowerShell"
                $result.Name | Should -Contain "AWSPowerShell.NetCore"
            }
            
            It "Should filter modules by target path" {
                # Act
                $result = Get-LegacyModules -TargetPath $script:testModulePath
                
                # Assert
                $result | ForEach-Object {
                    $_.ModuleBase | Should -BeLike "$($script:testModulePath)*"
                }
            }
            
            It "Should call Get-Module with correct parameters" {
                # Act
                Get-LegacyModules -TargetPath $script:testModulePath
                
                # Assert
                Should -Invoke Get-Module -ParameterFilter { 
                    $Name -eq 'AWSPowerShell*' -and $ListAvailable 
                } -Times 1
            }
        }
        
        Context "Path Filtering" {
            It "Should return empty array when no modules match path" {
                # Arrange
                $nonExistentPath = Join-Path $TestDrive "NonExistent"
                
                # Act
                $result = Get-LegacyModules -TargetPath $nonExistentPath
                
                # Assert
                $result | Should -HaveCount 0
            }
            
            It "Should handle case-insensitive path matching" {
                # Arrange
                $upperCasePath = $script:testModulePath.ToUpper()
                
                # Act
                $result = Get-LegacyModules -TargetPath $upperCasePath
                
                # Assert
                $result | Should -HaveCount 3
            }
        }
        
        Context "Module Types" {
            It "Should return both AWSPowerShell and AWSPowerShell.NetCore modules" {
                # Act
                $result = Get-LegacyModules -TargetPath $script:testModulePath
                
                # Assert
                $awsPowerShellModules = $result | Where-Object { $_.Name -eq "AWSPowerShell" }
                $netCoreModules = $result | Where-Object { $_.Name -eq "AWSPowerShell.NetCore" }
                
                $awsPowerShellModules | Should -HaveCount 2
                $netCoreModules | Should -HaveCount 1
            }
            
            It "Should return modules with different versions" {
                # Act
                $result = Get-LegacyModules -TargetPath $script:testModulePath
                
                # Assert
                $versions = $result | Select-Object -ExpandProperty Version -Unique
                $versions | Should -Contain ([Version]"3.3.618")
                $versions | Should -Contain ([Version]"4.0.0")
            }
        }
        
        Context "No Modules Found" {
            It "Should return empty array when no legacy modules exist" {
                # Arrange
                Mock Get-Module { return @() } -ParameterFilter { $Name -eq 'AWSPowerShell*' }
                
                # Act
                $result = Get-LegacyModules -TargetPath $script:testModulePath
                
                # Assert
                $result | Should -HaveCount 0
            }
        }
    }
}
