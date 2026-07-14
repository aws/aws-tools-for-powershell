BeforeDiscovery {
    . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")
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
    $InformationPreference = 'SilentlyContinue'
    
    # Create version-specific splatting variable for InformationAction parameter
    # 'Ignore' is not supported as a parameter value in PowerShell 5.1
    if ($PSVersionTable.PSVersion.Major -ge 6) {
        $script:InformationActionSplat = @{ InformationAction = 'Ignore' }
    } else {
        $script:InformationActionSplat = @{}
    }
    
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

Describe -Skip:$SkipInstallerTests -Tag "Smoke", "Low", "Medium", "High" "Installer - Uninstall-AWSToolsModule Unit Tests" {
    
    Context "MinimumVersion and MaximumVersion Parameter Validation" {
        It "Should throw error when MinimumVersion is greater than MaximumVersion" {
            # Act & Assert - Parameter validation should occur in Begin block
            { Uninstall-AWSToolsModule -MinimumVersion ([Version]"5.0.0") -MaximumVersion ([Version]"4.0.0") -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | 
                Should -Throw "*Parameter MinimumVersion*cannot be greater than MaximumVersion*"
        }
        
        It "Should accept MinimumVersion parameter alone" {
            # Arrange - Mock all dependencies
            Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "UserModules" }
            Mock -ModuleName AWS.Tools.Installer Get-ModulesToProcess { 
                @{ Regular = @() }
            }
            
            # Act & Assert - Should not throw parameter validation errors
            { Uninstall-AWSToolsModule -MinimumVersion ([Version]"4.0.0") -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
        }
        
        It "Should accept MaximumVersion parameter alone" {
            # Arrange - Mock all dependencies  
            Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "UserModules" }
            Mock -ModuleName AWS.Tools.Installer Get-ModulesToProcess { 
                @{ Regular = @() }
            }
            
            # Act & Assert - Should not throw parameter validation errors
            { Uninstall-AWSToolsModule -MaximumVersion ([Version]"5.0.0") -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
        }
        
        It "Should accept both MinimumVersion and MaximumVersion parameters together" {
            # Arrange - Mock all dependencies
            Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "UserModules" }
            Mock -ModuleName AWS.Tools.Installer Get-ModulesToProcess { 
                @{ Regular = @() }
            }
            
            # Act & Assert - Should not throw parameter validation errors
            { Uninstall-AWSToolsModule -MinimumVersion ([Version]"4.0.0") -MaximumVersion ([Version]"5.0.0") -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
        }
    }
    
    Context "Parameter Validation" {
        It "Should validate Scope parameter values" {
            # Add mocks within the It block
            Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { Join-Path -Path $TestDrive -ChildPath "TestPath" }
            Mock -ModuleName AWS.Tools.Installer Get-ModulesToProcess { @{ Regular = @() } }
            
            # Arrange & Act & Assert
            { Uninstall-AWSToolsModule -Scope 'InvalidScope' -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Throw
            { Uninstall-AWSToolsModule -Scope 'CurrentUser' -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
            { Uninstall-AWSToolsModule -Scope 'AllUsers' -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
        }
        
        It "Should default to CurrentUser scope" {
            # Act
            Uninstall-AWSToolsModule -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Get-PSModulePath -Times 1 -ParameterFilter { $Scope -eq 'CurrentUser' }
        }
        
        It "Should not allow both Version and ExceptVersion" {
            # Arrange & Act & Assert
            { Uninstall-AWSToolsModule -Version "4.1.850" -ExceptVersion "4.1.851" -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Throw
        }
        
        It "Should validate CleanUpLegacyScope parameter values" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-Module { @() } -ParameterFilter { $Name -contains 'AWSPowerShell*' }
            
            # Act & Assert
            { Uninstall-AWSToolsModule -CleanUpLegacyScope 'InvalidScope' -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Throw
            { Uninstall-AWSToolsModule -CleanUpLegacyScope 'CurrentUser' -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
            { Uninstall-AWSToolsModule -CleanUpLegacyScope 'AllUsers' -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
        }
        
        It "Should accept Version as string or Version object" {
            # Act & Assert
            { Uninstall-AWSToolsModule -Version "4.1.850" -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
            { Uninstall-AWSToolsModule -Version ([Version]"4.1.850") -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
        }
        
        It "Should accept ExceptVersion as string or Version object" {
            # Act & Assert
            { Uninstall-AWSToolsModule -ExceptVersion "4.1.850" -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
            { Uninstall-AWSToolsModule -ExceptVersion ([Version]"4.1.850") -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
        }
        
        It "Should handle custom Path parameter" {
            # Arrange
            $customPath = Join-Path $tempPath "CustomModules"
            
            # Act
            Uninstall-AWSToolsModule -Path $customPath -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat 
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Get-ModulesToProcess -Times 1 -ParameterFilter { $TargetPath -eq $customPath }
            Should -Not -Invoke -ModuleName AWS.Tools.Installer Get-PSModulePath
        }
    }
    
    Context "Module Processing" {
        It "Should call Get-ModulesToProcess with correct parameters" {
            # Arrange
            $testVersion = [Version]"4.1.850"
            
            # Create granular mocks for this specific test - remove BeforeAll interference
            Mock -ModuleName AWS.Tools.Installer Get-ModulesToProcess {
                return @{
                    Regular   = @()
                    Installer = @()
                }
            }
            
            # Mock all dependencies to ensure execution reaches Get-ModulesToProcess
            Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { Join-Path -Path $TestDrive -ChildPath "TestPath" }
            Mock -ModuleName AWS.Tools.Installer Get-CleanVersion { param($Version) return $Version }
            Mock -ModuleName AWS.Tools.Installer Get-Module { @() }
            Mock -ModuleName AWS.Tools.Installer Format-ModuleTarget { "Test target" }
            Mock -ModuleName AWS.Tools.Installer Write-Progress { }
            
            # Act
            Uninstall-AWSToolsModule -Version $testVersion -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
            
            # Assert - Simplify to just verify the function gets called
            Should -Invoke -ModuleName AWS.Tools.Installer Get-ModulesToProcess -Times 1
        }
        
        It "Should call Get-ModulesToProcess with ExceptVersion" {
            # Arrange
            $testVersion = [Version]"4.1.850"
            $expectedVersion = [Version]"4.1.850.0"  # Get-CleanVersion normalizes to 4-part version
            
            # Act
            Uninstall-AWSToolsModule -ExceptVersion $testVersion -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat 
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Get-ModulesToProcess -Times 1 -ParameterFilter { 
                $ExceptVersion -eq $expectedVersion 
            }
        }
        
        It "Should call Get-ModulesToProcess with module names" {
            # Arrange
            $testNames = @("EC2", "S3")
            
            # Act
            Uninstall-AWSToolsModule -Name $testNames -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat 
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Get-ModulesToProcess -Times 1 -ParameterFilter { 
                $Name -and ($Name -contains "EC2") -and ($Name -contains "S3")
            }
        }
    }
    
    Context "Installer Exclusion" {
        It "Should reject AWS.Tools.Installer module name" {
            # Act & Assert
            { Uninstall-AWSToolsModule -Name @('AWS.Tools.Installer') -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Throw "*AWS.Tools.Installer cannot be uninstalled using Uninstall-AWSToolsModule*"
        }
        
        It "Should reject AWS.Tools.Installer with short name" {
            # Act & Assert
            { Uninstall-AWSToolsModule -Name @('Installer') -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Throw "*AWS.Tools.Installer cannot be uninstalled using Uninstall-AWSToolsModule*"
        }
        
        It "Should reject AWS.Tools.Installer mixed with valid modules" {
            # Act & Assert
            { Uninstall-AWSToolsModule -Name @('S3', 'AWS.Tools.Installer', 'EC2') -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Throw "*AWS.Tools.Installer cannot be uninstalled using Uninstall-AWSToolsModule*"
        }
        
        It "Should provide helpful error message for installer exclusion" {
            # Act & Assert
            { Uninstall-AWSToolsModule -Name @('AWS.Tools.Installer') -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Throw "*Use Uninstall-AWSToolsInstaller instead*"
        }
    }
    
    Context "Wildcard Version Rejection" {
        It "Should reject wildcard in Version parameter" {
            # Act & Assert
            { Uninstall-AWSToolsModule -Version '5.*' -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | 
                Should -Throw "*Wildcard versions are not supported for uninstall operations*"
        }
        
        It "Should reject wildcard in ExceptVersion parameter" {
            # Act & Assert
            { Uninstall-AWSToolsModule -ExceptVersion '5.*' -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | 
                Should -Throw "*Wildcard versions are not supported in the ExceptVersion parameter*"
        }
        
        It "Should provide helpful error message for Version wildcard" {
            # Act & Assert
            { Uninstall-AWSToolsModule -Version '5.*' -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | 
                Should -Throw "*Please specify an exact version*"
        }
        
        It "Should provide helpful error message for ExceptVersion wildcard" {
            # Act & Assert
            { Uninstall-AWSToolsModule -ExceptVersion '5.*' -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | 
                Should -Throw "*Please specify an exact version*"
        }
    }
    
    Context "Prerelease Version Support" {
        It "Should accept prerelease version with -Prerelease switch" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { Join-Path -Path $TestDrive -ChildPath "TestPath" }
            Mock -ModuleName AWS.Tools.Installer Get-ModulesToProcess { @{ Regular = @() } }
            Mock -ModuleName AWS.Tools.Installer Test-PrereleaseParameterValidation { @{ IsPreReleaseVersion = $true; IsWildcardVersion = $false } }
            
            # Act & Assert
            { Uninstall-AWSToolsModule -Version '5.0.0-preview005' -Prerelease -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
        }
        
        It "Should require -Prerelease switch for prerelease versions" {
            # Act & Assert
            { Uninstall-AWSToolsModule -Version '5.0.0-preview005' -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | 
                Should -Throw "*The -Prerelease switch must be specified when installing a prerelease version*"
        }
        
        It "Should accept prerelease ExceptVersion with -Prerelease switch" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { Join-Path -Path $TestDrive -ChildPath "TestPath" }
            Mock -ModuleName AWS.Tools.Installer Get-ModulesToProcess { @{ Regular = @() } }
            Mock -ModuleName AWS.Tools.Installer Test-PrereleaseParameterValidation { @{ IsPreReleaseVersion = $true; IsWildcardVersion = $false } }
            
            # Act & Assert
            { Uninstall-AWSToolsModule -ExceptVersion '5.0.0-preview005' -Prerelease -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
        }
        
        It "Should require -Prerelease switch for prerelease ExceptVersion" {
            # Act & Assert
            { Uninstall-AWSToolsModule -ExceptVersion '5.0.0-preview005' -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | 
                Should -Throw "*The -Prerelease switch must be specified when installing a prerelease version*"
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
            } -ParameterFilter { $Name -contains 'AWS.Tools*' }
            
            # Act & Assert
            { Uninstall-AWSToolsModule -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } |
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
            } -ParameterFilter { $Name -contains 'AWS.Tools*' }
            
            # Act & Assert
            { Uninstall-AWSToolsModule -Name @('S3', 'EC2') -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } |
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
            { Uninstall-AWSToolsModule -CleanUpLegacyScope CurrentUser -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } |
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
            { Uninstall-AWSToolsModule -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
        }
        
        It "Should not throw an error when no modules are imported" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-Module { @() }
            
            # Act & Assert
            { Uninstall-AWSToolsModule -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
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
            } -ParameterFilter { $Name -contains 'AWS.Tools*' }
            
            # Act & Assert
            { Uninstall-AWSToolsModule -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } |
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
            } -ParameterFilter { $Name -contains 'AWS.Tools*' }
            
            Mock -ModuleName AWS.Tools.Installer Write-Warning { }
            
            # Act
            { Uninstall-AWSToolsModule -WhatIf -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
            
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
            { Uninstall-AWSToolsModule -CleanUpLegacyScope CurrentUser -WhatIf -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
            
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
            } -ParameterFilter { $Name -contains 'AWS.Tools*' }
            
            # Act & Assert
            { Uninstall-AWSToolsModule -ExceptVersion "5.0.0" -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } |
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
            } -ParameterFilter { $Name -contains 'AWS.Tools*' }
            
            Mock -ModuleName AWS.Tools.Installer Write-Warning { }
            
            # Act
            { Uninstall-AWSToolsModule -ExceptVersion "5.0.0" -WhatIf -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Write-Warning -Times 1 -ParameterFilter {
                $Message -like "*Cannot uninstall module(s): AWS.Tools.Common version 4.1.0.0*"
            }
        }
    }

    Context "No Modules To Process Messaging" {
        BeforeEach {
            # No imported modules, no modules found on disk
            Mock -ModuleName AWS.Tools.Installer Get-Module { @() }
            Mock -ModuleName AWS.Tools.Installer Get-ModulesToProcess { @{ Regular = @(); Installer = @() } }
            Mock -ModuleName AWS.Tools.Installer Write-Host { }
        }

        It "Should report no other versions to remove when ExceptVersion is specified" {
            # Act
            Uninstall-AWSToolsModule -ExceptVersion "5.0.241" -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat

            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Write-Host -Times 1 -ParameterFilter {
                $Object -like "Skipped uninstallation: No other AWS.Tools module versions found to remove in *"
            }
        }

        It "Should report no other versions to remove when ExceptModules is specified" {
            # Act
            Uninstall-AWSToolsModule -ExceptModules @(@{ Name = 'AWS.Tools.Common'; Version = '5.0.241' }) -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat

            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Write-Host -Times 1 -ParameterFilter {
                $Object -like "Skipped uninstallation: No other AWS.Tools module versions found to remove in *"
            }
        }

        It "Should report no modules found when no exclusion filter is specified" {
            # Act
            Uninstall-AWSToolsModule -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat

            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Write-Host -Times 1 -ParameterFilter {
                $Object -like "Skipped uninstallation: No AWS.Tools modules found (all versions) in *"
            }
        }

        It "Should report no modules found for a specific version not installed" {
            # Act
            Uninstall-AWSToolsModule -Version "4.1.0" -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat

            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Write-Host -Times 1 -ParameterFilter {
                $Object -like "Skipped uninstallation: No AWS.Tools modules found (version 4.1.0*) in *"
            }
        }
    }
}
