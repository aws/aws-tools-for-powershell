BeforeDiscovery {
    Import-Module (Join-Path $PSScriptRoot "../../modules/Installer/AWS.Tools.Installer.psd1") -Force
}

BeforeAll {
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
}

InModuleScope AWS.Tools.Installer {
    Describe -Tag "Smoke", "Low", "Medium", "High" "Installer - Get-ModulesToProcess Unit Tests" {
        
        BeforeAll {
            # Use TestDrive for isolated test directories
            $script:testModulePath = Join-Path $TestDrive "TestModules"
            $script:differentPath = Join-Path $TestDrive "DifferentPath"
            
            # Mock dependencies
            Mock Get-AWSToolsModule {
                return @(
                    (New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                        Name = "AWS.Tools.EC2"
                        Version = [Version]"4.1.850"
                        ModuleBase = Join-Path $script:testModulePath "AWS.Tools.EC2/4.1.850"
                    }),
                    (New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                        Name = "AWS.Tools.S3"
                        Version = [Version]"4.1.850"
                        ModuleBase = Join-Path $script:testModulePath "AWS.Tools.S3/4.1.850"
                    }),
                    (New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                        Name = "AWS.Tools.Installer"
                        Version = [Version]"4.1.850"
                        ModuleBase = Join-Path $script:testModulePath "AWS.Tools.Installer/4.1.850"
                    }),
                    (New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                        Name = "AWS.Tools.Common"
                        Version = [Version]"4.1.851"
                        ModuleBase = Join-Path $script:testModulePath "AWS.Tools.Common/4.1.851"
                    })
                )
            }
        }
        
        Context "Basic Module Discovery" {
            It "Should return modules grouped by type" {
                # Act
                $result = Get-ModulesToProcess -TargetPath $script:testModulePath
                
                # Assert
                $result | Should -Not -BeNullOrEmpty
                $result.Regular | Should -HaveCount 3
                $result.Installer | Should -HaveCount 1
                $result.Installer[0].Name | Should -Be "AWS.Tools.Installer"
            }
            
            It "Should filter modules by target path" {
                # Arrange
                $differentPath = $script:differentPath
                
                # Act
                $result = Get-ModulesToProcess -TargetPath $differentPath
                
                # Assert
                $result.Regular | Should -HaveCount 0
                $result.Installer | Should -HaveCount 0
            }
        }
        
        Context "Name Filtering" {
            It "Should filter by module names with AWS.Tools prefix" {
                # Act
                $result = Get-ModulesToProcess -TargetPath $script:testModulePath -Name @("AWS.Tools.EC2", "AWS.Tools.S3")
                
                # Assert
                $result.Regular | Should -HaveCount 2
                $result.Regular.Name | Should -Contain "AWS.Tools.EC2"
                $result.Regular.Name | Should -Contain "AWS.Tools.S3"
                $result.Regular.Name | Should -Not -Contain "AWS.Tools.Common"
            }
            
            It "Should normalize module names without AWS.Tools prefix" {
                # Act
                $result = Get-ModulesToProcess -TargetPath $script:testModulePath -Name @("EC2", "S3")
                
                # Assert
                $result.Regular | Should -HaveCount 2
                $result.Regular.Name | Should -Contain "AWS.Tools.EC2"
                $result.Regular.Name | Should -Contain "AWS.Tools.S3"
            }
            
            It "Should handle mixed name formats" {
                # Act
                $result = Get-ModulesToProcess -TargetPath $script:testModulePath -Name @("EC2", "AWS.Tools.S3")
                
                # Assert
                $result.Regular | Should -HaveCount 2
                $result.Regular.Name | Should -Contain "AWS.Tools.EC2"
                $result.Regular.Name | Should -Contain "AWS.Tools.S3"
            }
        }
        
        Context "Version Filtering" {
            It "Should filter by specific version" {
                # Act
                $result = Get-ModulesToProcess -TargetPath $script:testModulePath -Version ([Version]"4.1.850.0")
                
                # Assert
                $result.Regular | Should -HaveCount 2  # EC2 and S3 have version 4.1.850
                $result.Installer | Should -HaveCount 1  # Installer has version 4.1.850
                $result.Regular.Name | Should -Not -Contain "AWS.Tools.Common"  # Common has 4.1.851
            }
            
            It "Should filter by except version" {
                # Act
                $result = Get-ModulesToProcess -TargetPath $script:testModulePath -ExceptVersion ([Version]"4.1.850.0")
                
                # Assert
                $result.Regular | Should -HaveCount 1  # Only Common has different version
                $result.Regular[0].Name | Should -Be "AWS.Tools.Common"
                $result.Installer | Should -HaveCount 0  # Installer excluded
            }
        }
        
        Context "Combined Filtering" {
            It "Should apply name and version filters together" {
                # Act
                $result = Get-ModulesToProcess -TargetPath $script:testModulePath -Name @("EC2", "Common") -Version ([Version]"4.1.850.0")
                
                # Assert
                $result.Regular | Should -HaveCount 1  # Only EC2 matches both name and version
                $result.Regular[0].Name | Should -Be "AWS.Tools.EC2"
            }
            
            It "Should apply name and except version filters together" {
                # Act
                $result = Get-ModulesToProcess -TargetPath $script:testModulePath -Name @("EC2", "Common") -ExceptVersion ([Version]"4.1.850.0")
                
                # Assert
                $result.Regular | Should -HaveCount 1  # Only Common matches name but not version
                $result.Regular[0].Name | Should -Be "AWS.Tools.Common"
            }
        }
        
        Context "Edge Cases" {
            It "Should handle empty module list" {
                # Arrange
                Mock Get-AWSToolsModule { return @() }
                
                # Act
                $result = Get-ModulesToProcess -TargetPath $script:testModulePath
                
                # Assert
                $result.Regular | Should -HaveCount 0
                $result.Installer | Should -HaveCount 0
            }
            
            It "Should handle non-existent module names" {
                # Act
                $result = Get-ModulesToProcess -TargetPath $script:testModulePath -Name @("NonExistent")
                
                # Assert
                $result.Regular | Should -HaveCount 0
                $result.Installer | Should -HaveCount 0
            }
            
            It "Should handle non-existent version" {
                # Act
                $result = Get-ModulesToProcess -TargetPath $script:testModulePath -Version ([Version]"9.9.9.9")
                
                # Assert
                $result.Regular | Should -HaveCount 0
                $result.Installer | Should -HaveCount 0
            }
        }
    }
}
