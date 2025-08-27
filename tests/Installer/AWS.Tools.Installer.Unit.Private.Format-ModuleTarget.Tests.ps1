BeforeDiscovery {
    $modulePath = [System.IO.Path]::Combine($PSScriptRoot, "../../modules/Installer/AWS.Tools.Installer.psd1")
    Import-Module $modulePath -Force
}

BeforeAll {
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'

    # New-MockModule defined in PSM1 file.
}

InModuleScope AWS.Tools.Installer {
    
    Describe -Tag "Smoke", "Low", "Medium", "High" "Installer - Format-ModuleTarget Unit Tests" {
        
        Context "AWS.Tools Module Type (Default)" {
            
            It "Should format target for single AWS.Tools module with single version" {
                # Arrange
                $mockModule = New-MockModule -Name "AWS.Tools.EC2" -Version ([Version]"4.1.853")
                # Use a platform-agnostic test path
                $targetPath = [System.IO.Path]::Combine([System.IO.Path]::GetDirectoryName($PSHome), "PowerShell", "Modules")
                
                # Act
                $result = Format-ModuleTarget -Modules @($mockModule) -TargetPath $targetPath
                
                # Assert - Use regex to match path regardless of platform
                $result | Should -Match "1 AWS\.Tools modules \(versions: 4\.1\.853\) from .+"
            }
            
            It "Should format target for multiple AWS.Tools modules with same version" {
                # Arrange
                $mockModules = @(
                    (New-MockModule -Name "AWS.Tools.EC2" -Version ([Version]"4.1.853")),
                    (New-MockModule -Name "AWS.Tools.S3" -Version ([Version]"4.1.853"))
                )
                # Use a platform-agnostic test path
                $targetPath = [System.IO.Path]::Combine($HOME, "Documents", "PowerShell", "Modules")
                
                # Act
                $result = Format-ModuleTarget -Modules $mockModules -TargetPath $targetPath
                
                # Assert - Use regex to match path regardless of platform
                $result | Should -Match "2 AWS\.Tools modules \(versions: 4\.1\.853\) from .+"
            }
            
            It "Should format target for multiple AWS.Tools modules with different versions" {
                # Arrange
                $mockModules = @(
                    (New-MockModule -Name "AWS.Tools.EC2" -Version ([Version]"4.1.853")),
                    (New-MockModule -Name "AWS.Tools.S3" -Version ([Version]"4.1.854")),
                    (New-MockModule -Name "AWS.Tools.Common" -Version ([Version]"4.1.853"))
                )
                $targetPath = "/home/user/.local/share/powershell/Modules"
                
                # Act
                $result = Format-ModuleTarget -Modules $mockModules -TargetPath $targetPath
                
                # Assert
                $result | Should -Match "3 AWS\.Tools modules \(versions: (4\.1\.853, 4\.1\.854|4\.1\.854, 4\.1\.853)\) from /home/user/\.local/share/powershell/Modules"
            }
            
            It "Should handle complex version numbers correctly" {
                # Arrange
                $mockModule = New-MockModule -Name "AWS.Tools.CloudFormation" -Version ([Version]"4.1.853.0")
                # Use a platform-agnostic test path
                $targetPath = [System.IO.Path]::Combine($HOME, "CustomPath", "Modules")
                
                # Act
                $result = Format-ModuleTarget -Modules @($mockModule) -TargetPath $targetPath
                
                # Assert - Use regex to match path regardless of platform
                $result | Should -Match "1 AWS\.Tools modules \(versions: 4\.1\.853\.0\) from .+"
            }
        }
        
        Context "AWS.Tools.Installer Module Type" {
            
            It "Should format target for AWS.Tools.Installer module type" {
                # Arrange
                $mockModule = New-MockModule -Name "AWS.Tools.Installer" -Version ([Version]"1.0.2.5")
                # Use a platform-agnostic test path
                $targetPath = [System.IO.Path]::Combine([System.IO.Path]::GetDirectoryName($PSHome), "PowerShell", "Modules")
                
                # Act
                $result = Format-ModuleTarget -Modules @($mockModule) -TargetPath $targetPath -ModuleType "AWS.Tools.Installer"
                
                # Assert - Use regex to match path regardless of platform
                $result | Should -Match "1 AWS\.Tools\.Installer modules \(versions: 1\.0\.2\.5\) from .+"
            }
            
            It "Should format target for multiple AWS.Tools.Installer modules with different versions" {
                # Arrange
                $mockModules = @(
                    (New-MockModule -Name "AWS.Tools.Installer" -Version ([Version]"1.0.2.4")),
                    (New-MockModule -Name "AWS.Tools.Installer" -Version ([Version]"1.0.2.5"))
                )
                # Use a platform-agnostic test path
                $targetPath = [System.IO.Path]::Combine($HOME, "TestPath", "Modules")
                
                # Act
                $result = Format-ModuleTarget -Modules $mockModules -TargetPath $targetPath -ModuleType "AWS.Tools.Installer"
                
                # Assert - Use regex to match path regardless of platform
                $result | Should -Match "2 AWS\.Tools\.Installer modules \(versions: (1\.0\.2\.4, 1\.0\.2\.5|1\.0\.2\.5, 1\.0\.2\.4)\) from .+"
            }
        }
        
        Context "Legacy AWSPowerShell Module Type" {
            
            It "Should format target for single legacy AWSPowerShell module" {
                # Arrange
                $mockModule = New-MockModule -Name "AWSPowerShell" -Version ([Version]"4.1.853")
                # Use a platform-agnostic test path
                $targetPath = [System.IO.Path]::Combine([System.IO.Path]::GetDirectoryName($PSHome), "WindowsPowerShell", "Modules")
                
                # Act
                $result = Format-ModuleTarget -Modules @($mockModule) -TargetPath $targetPath -ModuleType "Legacy AWSPowerShell"
                
                # Assert - Use regex to match path regardless of platform
                $result | Should -Match "1 Legacy AWSPowerShell modules \(AWSPowerShell 4\.1\.853\) from .+"
            }
            
            It "Should format target for multiple legacy AWSPowerShell modules" {
                # Arrange
                $mockModules = @(
                    (New-MockModule -Name "AWSPowerShell" -Version ([Version]"4.1.853")),
                    (New-MockModule -Name "AWSPowerShell.NetCore" -Version ([Version]"4.1.854"))
                )
                # Use a platform-agnostic test path
                $targetPath = [System.IO.Path]::Combine($HOME, "Documents", "WindowsPowerShell", "Modules")
                
                # Act
                $result = Format-ModuleTarget -Modules $mockModules -TargetPath $targetPath -ModuleType "Legacy AWSPowerShell"
                
                # Assert - Use regex to match path regardless of platform
                $result | Should -Match "2 Legacy AWSPowerShell modules \(AWSPowerShell 4\.1\.853, AWSPowerShell\.NetCore 4\.1\.854\) from .+"
            }
            
            It "Should format target for legacy modules with same name but different versions" {
                # Arrange
                $mockModules = @(
                    (New-MockModule -Name "AWSPowerShell" -Version ([Version]"4.1.853")),
                    (New-MockModule -Name "AWSPowerShell" -Version ([Version]"4.1.854"))
                )
                $targetPath = "/usr/local/share/powershell/Modules"
                
                # Act
                $result = Format-ModuleTarget -Modules $mockModules -TargetPath $targetPath -ModuleType "Legacy AWSPowerShell"
                
                # Assert
                $result | Should -Be "2 Legacy AWSPowerShell modules (AWSPowerShell 4.1.853, AWSPowerShell 4.1.854) from /usr/local/share/powershell/Modules"
            }
        }
        
        Context "Cross-Platform Path Handling" {
            
            It "Should handle Windows-style paths correctly" {
                # Arrange
                $mockModule = New-MockModule -Name "AWS.Tools.EC2" -Version ([Version]"4.1.853")
                $targetPath = "C:\Program Files\PowerShell\Modules"
                
                # Act
                $result = Format-ModuleTarget -Modules @($mockModule) -TargetPath $targetPath
                
                # Assert
                $result | Should -Be "1 AWS.Tools modules (versions: 4.1.853) from C:\Program Files\PowerShell\Modules"
            }
            
            It "Should handle Unix-style paths correctly" {
                # Arrange
                $mockModule = New-MockModule -Name "AWS.Tools.S3" -Version ([Version]"4.1.853")
                $targetPath = "/home/user/.local/share/powershell/Modules"
                
                # Act
                $result = Format-ModuleTarget -Modules @($mockModule) -TargetPath $targetPath
                
                # Assert
                $result | Should -Be "1 AWS.Tools modules (versions: 4.1.853) from /home/user/.local/share/powershell/Modules"
            }
            
            It "Should handle macOS-style paths correctly" {
                # Arrange
                $mockModule = New-MockModule -Name "AWS.Tools.CloudWatch" -Version ([Version]"4.1.853")
                $targetPath = "/Users/testuser/.local/share/powershell/Modules"
                
                # Act
                $result = Format-ModuleTarget -Modules @($mockModule) -TargetPath $targetPath
                
                # Assert
                $result | Should -Be "1 AWS.Tools modules (versions: 4.1.853) from /Users/testuser/.local/share/powershell/Modules"
            }
        }
        
        Context "Edge Cases and Error Scenarios" {
            
            It "Should handle null version gracefully" {
                # Arrange
                $mockModule = New-MockModule -Name "AWS.Tools.EC2" -Version $null
                $targetPath = [System.IO.Path]::Combine([System.IO.Path]::GetDirectoryName($PSHome), "PowerShell", "Modules")
                
                # Act & Assert
                { Format-ModuleTarget -Modules @($mockModule) -TargetPath $targetPath } | Should -Not -Throw
            }
            
            It "Should handle custom module type correctly" {
                # Arrange
                $mockModule = New-MockModule -Name "CustomModule" -Version ([Version]"1.0.0")
                $targetPath = [System.IO.Path]::Combine($HOME, "CustomPath", "Modules")
                
                # Act
                $result = Format-ModuleTarget -Modules @($mockModule) -TargetPath $targetPath -ModuleType "Custom Module Type"
                
                # Assert
                $result | Should -Match "1 Custom Module Type modules \(versions: 1\.0\.0\) from .+"
            }
            
            It "Should handle very long target paths" {
                # Arrange
                $mockModule = New-MockModule -Name "AWS.Tools.EC2" -Version ([Version]"4.1.853")
                # Use a platform-agnostic test path with many segments
                $longPath = [System.IO.Path]::Combine($HOME, "Very", "Long", "Path", "That", "Goes", "Deep", "Into", "The", "File", "System", "Structure", "PowerShell", "Modules")
                
                # Act
                $result = Format-ModuleTarget -Modules @($mockModule) -TargetPath $longPath
                
                # Assert
                $result | Should -Be "1 AWS.Tools modules (versions: 4.1.853) from $longPath"
            }
            
            It "Should handle special characters in target path" {
                # Arrange
                $mockModule = New-MockModule -Name "AWS.Tools.EC2" -Version ([Version]"4.1.853")
                # Use a platform-agnostic test path with special characters
                $specialPath = [System.IO.Path]::Combine($HOME, "Path With Spaces", "And-Dashes", "PowerShell_Modules")
                
                # Act
                $result = Format-ModuleTarget -Modules @($mockModule) -TargetPath $specialPath
                
                # Assert
                $result | Should -Be "1 AWS.Tools modules (versions: 4.1.853) from $specialPath"
            }
        }
        
        Context "Version Grouping Logic" {
            
            It "Should group modules by version correctly with multiple versions" {
                # Arrange
                $mockModules = @(
                    (New-MockModule -Name "AWS.Tools.EC2" -Version ([Version]"4.1.853")),
                    (New-MockModule -Name "AWS.Tools.S3" -Version ([Version]"4.1.853")),
                    (New-MockModule -Name "AWS.Tools.CloudWatch" -Version ([Version]"4.1.854")),
                    (New-MockModule -Name "AWS.Tools.Lambda" -Version ([Version]"4.1.855"))
                )
                # Use a platform-agnostic test path
                $targetPath = [System.IO.Path]::Combine([System.IO.Path]::GetDirectoryName($PSHome), "PowerShell", "Modules")
                
                # Act
                $result = Format-ModuleTarget -Modules $mockModules -TargetPath $targetPath
                
                # Assert - Use regex to match path regardless of platform
                $result | Should -Match "4 AWS\.Tools modules \(versions: .*(4\.1\.853|4\.1\.854|4\.1\.855).*\) from .+"
                $result | Should -Match "4\.1\.853"
                $result | Should -Match "4\.1\.854"
                $result | Should -Match "4\.1\.855"
            }
            
            It "Should handle duplicate versions correctly" {
                # Arrange
                $mockModules = @(
                    (New-MockModule -Name "AWS.Tools.EC2" -Version ([Version]"4.1.853")),
                    (New-MockModule -Name "AWS.Tools.S3" -Version ([Version]"4.1.853")),
                    (New-MockModule -Name "AWS.Tools.Common" -Version ([Version]"4.1.853"))
                )
                $targetPath = [System.IO.Path]::Combine([System.IO.Path]::GetDirectoryName($PSHome), "PowerShell", "Modules")
                
                # Act
                $result = Format-ModuleTarget -Modules $mockModules -TargetPath $targetPath
                
                # Assert
                $result | Should -Match "3 AWS\.Tools modules \(versions: 4\.1\.853\) from .+"
            }
        }
    }
}
