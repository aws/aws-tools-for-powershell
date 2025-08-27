BeforeDiscovery {
    Import-Module (Join-Path $PSScriptRoot "../../modules/Installer/AWS.Tools.Installer.psd1") -Force
}

BeforeAll {
    # Create cross-platform paths
    $tempPath = [System.IO.Path]::GetTempPath()
    $userModulePath = Join-Path $tempPath "UserModules"
    $systemModulePath = Join-Path $tempPath "SystemModules"
    
    # Set preference variables to suppress verbose, progress, and warning output
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
    $WarningPreference = 'SilentlyContinue'
    $InformationPreference = 'Ignore'
    
    # Mock the higher-level functions instead of the data producers
    Mock -ModuleName AWS.Tools.Installer Get-ModulesToProcess {
        return @{
            Regular   = @()
            Installer = @()
        }
    }
    
    Mock -ModuleName AWS.Tools.Installer Get-LegacyModules {
        return @()
    }
    
    Mock -ModuleName AWS.Tools.Installer Format-ModuleTarget {
        return "Test modules in test path"
    }
    
    Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { 
        param($Scope)
        if ($Scope -eq 'AllUsers') {
            return $systemModulePath
        }
        else {
            return $userModulePath
        }
    }
}

Describe -Tag "Smoke", "Low", "Medium", "High" "Installer - Uninstall-AWSToolsModule Unit Tests" {
    
    Context "Parameter Validation" {
        It "Should validate Scope parameter values" {
            # Arrange & Act & Assert
            { Uninstall-AWSToolsModule -Scope 'InvalidScope' -Confirm:$false } | Should -Throw
            { Uninstall-AWSToolsModule -Scope 'CurrentUser' -Confirm:$false } | Should -Not -Throw
            { Uninstall-AWSToolsModule -Scope 'AllUsers' -Confirm:$false } | Should -Not -Throw
        }
        
        It "Should default to CurrentUser scope" {
            # Act
            Uninstall-AWSToolsModule -Confirm:$false
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Get-PSModulePath -Times 1 -ParameterFilter { $Scope -eq 'CurrentUser' }
        }
        
        It "Should not allow both Version and ExceptVersion" {
            # Arrange & Act & Assert
            { Uninstall-AWSToolsModule -Version "4.1.850" -ExceptVersion "4.1.851" -Confirm:$false } | Should -Throw
        }
        
        It "Should validate CleanUpLegacyScope parameter values" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-Module { @() } -ParameterFilter { $Name -contains 'AWSPowerShell*' }
            
            # Act & Assert
            { Uninstall-AWSToolsModule -CleanUpLegacyScope 'InvalidScope' -Confirm:$false } | Should -Throw
            { Uninstall-AWSToolsModule -CleanUpLegacyScope 'CurrentUser' -Confirm:$false } | Should -Not -Throw
            { Uninstall-AWSToolsModule -CleanUpLegacyScope 'AllUsers' -Confirm:$false } | Should -Not -Throw
        }
        
        It "Should accept Version as string or Version object" {
            # Act & Assert
            { Uninstall-AWSToolsModule -Version "4.1.850" -Confirm:$false } | Should -Not -Throw
            { Uninstall-AWSToolsModule -Version ([Version]"4.1.850") -Confirm:$false } | Should -Not -Throw
        }
        
        It "Should accept ExceptVersion as string or Version object" {
            # Act & Assert
            { Uninstall-AWSToolsModule -ExceptVersion "4.1.850" -Confirm:$false } | Should -Not -Throw
            { Uninstall-AWSToolsModule -ExceptVersion ([Version]"4.1.850") -Confirm:$false } | Should -Not -Throw
        }
        
        It "Should handle custom Path parameter" {
            # Arrange
            $customPath = Join-Path $tempPath "CustomModules"
            
            # Act
            Uninstall-AWSToolsModule -Path $customPath -Confirm:$false
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Get-ModulesToProcess -Times 1 -ParameterFilter { $TargetPath -eq $customPath }
            Should -Not -Invoke -ModuleName AWS.Tools.Installer Get-PSModulePath
        }
    }
    
    Context "Module Processing" {
        It "Should call Get-ModulesToProcess with correct parameters" {
            # Arrange
            $testVersion = [Version]"4.1.850"
            $expectedVersion = [Version]"4.1.850.0"  # Get-CleanVersion normalizes to 4-part version
            
            # Act
            Uninstall-AWSToolsModule -Version $testVersion -Confirm:$false
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Get-ModulesToProcess -Times 1 -ParameterFilter { 
                $Version -eq $expectedVersion 
            }
        }
        
        It "Should call Get-ModulesToProcess with ExceptVersion" {
            # Arrange
            $testVersion = [Version]"4.1.850"
            $expectedVersion = [Version]"4.1.850.0"  # Get-CleanVersion normalizes to 4-part version
            
            # Act
            Uninstall-AWSToolsModule -ExceptVersion $testVersion -Confirm:$false
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Get-ModulesToProcess -Times 1 -ParameterFilter { 
                $ExceptVersion -eq $expectedVersion 
            }
        }
        
        It "Should call Get-ModulesToProcess with module names" {
            # Arrange
            $testNames = @("EC2", "S3")
            
            # Act
            Uninstall-AWSToolsModule -Name $testNames -Confirm:$false
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Get-ModulesToProcess -Times 1 -ParameterFilter { 
                $Name -and ($Name -contains "EC2") -and ($Name -contains "S3")
            }
        }
    }
    
    Context "Installer Exclusion" {
        It "Should reject AWS.Tools.Installer module name" {
            # Act & Assert
            { Uninstall-AWSToolsModule -Name @('AWS.Tools.Installer') -Confirm:$false } | Should -Throw "*AWS.Tools.Installer cannot be uninstalled using Uninstall-AWSToolsModule*"
        }
        
        It "Should reject AWS.Tools.Installer with short name" {
            # Act & Assert
            { Uninstall-AWSToolsModule -Name @('Installer') -Confirm:$false } | Should -Throw "*AWS.Tools.Installer cannot be uninstalled using Uninstall-AWSToolsModule*"
        }
        
        It "Should reject AWS.Tools.Installer mixed with valid modules" {
            # Act & Assert
            { Uninstall-AWSToolsModule -Name @('S3', 'AWS.Tools.Installer', 'EC2') -Confirm:$false } | Should -Throw "*AWS.Tools.Installer cannot be uninstalled using Uninstall-AWSToolsModule*"
        }
        
        It "Should provide helpful error message for installer exclusion" {
            # Act & Assert
            { Uninstall-AWSToolsModule -Name @('AWS.Tools.Installer') -Confirm:$false } | Should -Throw "*Use Uninstall-AWSToolsInstaller instead*"
        }
    }
    
    Context "Import Checking" {
        BeforeEach {
            # Reset mocks before each test
            Mock -ModuleName AWS.Tools.Installer Get-Module { @() }
            Mock -ModuleName AWS.Tools.Installer Write-Warning { }
        }
        
        It "Should throw an error when AWS.Tools modules are imported" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-Module {
                @(
                    [PSCustomObject]@{
                        Name = "AWS.Tools.S3"
                        Version = "4.1.0.0"
                    }
                )
            } -ParameterFilter { $Name -contains 'AWS.Tools.*' }
            
            # Act & Assert
            { Uninstall-AWSToolsModule -Confirm:$false } |
                Should -Throw -ExpectedMessage "*Cannot uninstall module(s): AWS.Tools.S3 version 4.1.0.0*"
        }
        
        It "Should throw an error when specific AWS.Tools modules are imported and specified by name" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-Module {
                @(
                    [PSCustomObject]@{
                        Name = "AWS.Tools.S3"
                        Version = "4.1.0.0"
                    }
                )
            } -ParameterFilter { $Name -contains 'AWS.Tools.*' }
            
            # Act & Assert
            { Uninstall-AWSToolsModule -Name @('S3', 'EC2') -Confirm:$false } |
                Should -Throw -ExpectedMessage "*Cannot uninstall module(s): AWS.Tools.S3 version 4.1.0.0*"
        }
        
        It "Should throw an error when legacy modules are imported and CleanUpLegacyScope is specified" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-Module {
                @(
                    [PSCustomObject]@{
                        Name = "AWSPowerShell"
                        Version = "4.1.0.0"
                    }
                )
            } -ParameterFilter { $Name -contains 'AWSPowerShell*' }
            
            # Act & Assert
            { Uninstall-AWSToolsModule -CleanUpLegacyScope CurrentUser -Confirm:$false } |
                Should -Throw -ExpectedMessage "*Cannot uninstall module(s): AWSPowerShell version 4.1.0.0*"
        }
        
        It "Should not throw an error when AWS.Tools.Installer is imported" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-Module {
                @(
                    [PSCustomObject]@{
                        Name = "AWS.Tools.Installer"
                        Version = "4.1.0.0"
                    }
                )
            } -ParameterFilter { $Name -contains 'AWS.Tools.*' }
            
            # Act & Assert
            { Uninstall-AWSToolsModule -Confirm:$false } | Should -Not -Throw
        }
        
        It "Should not throw an error when no modules are imported" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-Module { @() }
            
            # Act & Assert
            { Uninstall-AWSToolsModule -Confirm:$false } | Should -Not -Throw
        }
        
        It "Should include guidance on how to resolve the issue in the error message" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-Module {
                @(
                    [PSCustomObject]@{
                        Name = "AWS.Tools.S3"
                        Version = "4.1.0.0"
                    }
                )
            } -ParameterFilter { $Name -contains 'AWS.Tools.*' }
            
            # Act & Assert
            { Uninstall-AWSToolsModule -Confirm:$false } |
                Should -Throw -ExpectedMessage "*Start a new PowerShell session to uninstall*"
        }
        
        It "Should show a warning after ShouldProcess when AWS.Tools modules are imported with -WhatIf" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-Module {
                @(
                    [PSCustomObject]@{
                        Name = "AWS.Tools.S3"
                        Version = "4.1.0.0"
                    }
                )
            } -ParameterFilter { $Name -contains 'AWS.Tools.*' }
            
            Mock -ModuleName AWS.Tools.Installer Write-Warning { }
            
            # Act
            { Uninstall-AWSToolsModule -WhatIf -Confirm:$false } | Should -Not -Throw
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Write-Warning -Times 1 -ParameterFilter {
                $Message -like "*Cannot uninstall module(s): AWS.Tools.S3 version 4.1.0.0*"
            }
        }
        
        It "Should show a warning after ShouldProcess when legacy modules are imported with -WhatIf" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-Module {
                @(
                    [PSCustomObject]@{
                        Name = "AWSPowerShell"
                        Version = "4.1.0.0"
                    }
                )
            } -ParameterFilter { $Name -contains 'AWSPowerShell*' }
            
            Mock -ModuleName AWS.Tools.Installer Write-Warning { }
            
            # Act
            { Uninstall-AWSToolsModule -CleanUpLegacyScope CurrentUser -WhatIf -Confirm:$false } | Should -Not -Throw
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Write-Warning -Times 1 -ParameterFilter {
                $Message -like "*Cannot uninstall module(s): AWSPowerShell version 4.1.0.0*"
            }
        }
        
        It "Should detect imported modules when using ExceptVersion parameter" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-Module {
                @(
                    [PSCustomObject]@{
                        Name = "AWS.Tools.Common"
                        Version = "4.1.0.0"
                    }
                )
            } -ParameterFilter { $Name -contains 'AWS.Tools.*' }
            
            # Act & Assert
            { Uninstall-AWSToolsModule -ExceptVersion "5.0.0" -Confirm:$false } |
                Should -Throw -ExpectedMessage "*Cannot uninstall module(s): AWS.Tools.Common version 4.1.0.0*"
        }
        
        
        It "Should show a warning after ShouldProcess when AWS.Tools modules are imported with -ExceptVersion and -WhatIf" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-Module {
                @(
                    [PSCustomObject]@{
                        Name = "AWS.Tools.Common"
                        Version = "4.1.0.0"
                    }
                )
            } -ParameterFilter { $Name -contains 'AWS.Tools.*' }
            
            Mock -ModuleName AWS.Tools.Installer Write-Warning { }
            
            # Act
            { Uninstall-AWSToolsModule -ExceptVersion "5.0.0" -WhatIf -Confirm:$false } | Should -Not -Throw
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Write-Warning -Times 1 -ParameterFilter {
                $Message -like "*Cannot uninstall module(s): AWS.Tools.Common version 4.1.0.0*"
            }
        }
    }
}
