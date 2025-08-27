BeforeDiscovery {
    Import-Module (Join-Path $PSScriptRoot "../../modules/Installer/AWS.Tools.Installer.psd1") -Force
}

BeforeAll {
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
}

Describe -Tag "Smoke", "Low", "Medium", "High" "Installer - Resolve-AWSToolsModuleNames Unit Tests" {
    
    Context "Name Resolution" {
        It "Should return null for empty input" {
            InModuleScope AWS.Tools.Installer {
                # Act
                $result = Resolve-AWSToolsModuleNames -Name @()
                
                # Assert
                $result | Should -BeNullOrEmpty
            }
        }
        
        It "Should add AWS.Tools prefix" {
            InModuleScope AWS.Tools.Installer {
                # Act
                $result = Resolve-AWSToolsModuleNames -Name @('S3', 'EC2')
                
                # Assert
                $result | Should -Contain 'AWS.Tools.S3'
                $result | Should -Contain 'AWS.Tools.EC2'
            }
        }
        
        It "Should validate AWS.Tools modules" {
            InModuleScope AWS.Tools.Installer {
                # Act & Assert
                { Resolve-AWSToolsModuleNames -Name @('NotAWS.InvalidModule') } | Should -Throw "*must contain only AWS.Tools modules*"
            }
        }
        
        It "Should reject AWS.Tools.Installer module" {
            InModuleScope AWS.Tools.Installer {
                # Act & Assert
                { Resolve-AWSToolsModuleNames -Name @('AWS.Tools.Installer') } | Should -Throw "*AWS.Tools.Installer cannot be installed using Install-AWSToolsModule*"
            }
        }
        
        It "Should reject AWS.Tools.Installer with short name" {
            InModuleScope AWS.Tools.Installer {
                # Act & Assert
                { Resolve-AWSToolsModuleNames -Name @('Installer') } | Should -Throw "*AWS.Tools.Installer cannot be installed using Install-AWSToolsModule*"
            }
        }
        
        It "Should reject AWS.Tools.Installer mixed with valid modules" {
            InModuleScope AWS.Tools.Installer {
                # Act & Assert
                { Resolve-AWSToolsModuleNames -Name @('S3', 'AWS.Tools.Installer', 'EC2') } | Should -Throw "*AWS.Tools.Installer cannot be installed using Install-AWSToolsModule*"
            }
        }
        
        It "Should automatically include AWS.Tools.Common when specific modules are requested" {
            InModuleScope AWS.Tools.Installer {
                # Act
                $result = Resolve-AWSToolsModuleNames -Name @('S3', 'EC2')
                
                # Assert
                $result | Should -Contain 'AWS.Tools.Common'
                $result | Should -Contain 'AWS.Tools.S3'
                $result | Should -Contain 'AWS.Tools.EC2'
                $result.Count | Should -Be 3
            }
        }
        
        It "Should not duplicate AWS.Tools.Common when it's already in the list" {
            InModuleScope AWS.Tools.Installer {
                # Act
                $result = Resolve-AWSToolsModuleNames -Name @('Common', 'S3', 'EC2')
                
                # Assert
                $result | Should -Contain 'AWS.Tools.Common'
                $result | Should -Contain 'AWS.Tools.S3'
                $result | Should -Contain 'AWS.Tools.EC2'
                $result.Count | Should -Be 3
            }
        }
    }
}
