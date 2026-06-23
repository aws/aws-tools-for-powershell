BeforeDiscovery {
    # Import the module under test in BeforeDiscovery
    . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")
}

BeforeAll {
    . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")

    # Use preference variables instead of mocking Write commands
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
    $WarningPreference = 'SilentlyContinue'
    $InformationPreference = 'SilentlyContinue'
}

# Single InModuleScope wrapping ALL tests (OUTSIDE BeforeAll)
InModuleScope AWS.Tools.Installer {
    # Create version-specific splatting variable for InformationAction parameter
    # 'Ignore' is not supported as a parameter value in PowerShell 5.1
    # This must be inside InModuleScope for PowerShell 5.1 compatibility
    if ($PSVersionTable.PSVersion.Major -ge 6) {
        $script:InformationActionSplat = @{ InformationAction = 'Ignore' }
    } else {
        $script:InformationActionSplat = @{}
    }
    
    Describe -Skip:$SkipInstallerTests -Tag "Smoke", "Low", "Medium", "High" "Uninstall-AWSToolsInstaller" {
        
        Context "Parameter Validation" {
            It "Should accept valid Version parameter" {
                # Arrange - Set up mocks for dependencies
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { return (Join-Path -Path $TestDrive -ChildPath "TestPath") }
                Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { return @() }
                Mock -ModuleName AWS.Tools.Installer Get-CleanVersion { param($Version) return $Version }
                
                # Act & Assert - Call function with valid Version parameter and verify it doesn't throw
                { Uninstall-AWSToolsInstaller -Version "1.0.3" -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
            }
            
            It "Should accept valid ExceptVersion parameter" {
                # Arrange - Set up mocks for dependencies
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { return (Join-Path -Path $TestDrive -ChildPath "TestPath") }
                Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { return @() }
                Mock -ModuleName AWS.Tools.Installer Get-CleanVersion { param($Version) return $Version }
                
                # Act & Assert - Call function with valid ExceptVersion parameter and verify it doesn't throw
                { Uninstall-AWSToolsInstaller -ExceptVersion "1.0.3" -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
            }
            
            It "Should accept valid Scope parameter" {
                # Arrange - Set up mocks for dependencies
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { return (Join-Path -Path $TestDrive -ChildPath "TestPath") }
                Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { return @() }
                Mock -ModuleName AWS.Tools.Installer Get-CleanVersion { param($Version) return $Version }
                
                # Act - Call function with valid Scope parameter
                { Uninstall-AWSToolsInstaller -Scope AllUsers -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
                
                # Assert - Verify Get-PSModulePath was called with correct scope
                Should -Invoke -ModuleName AWS.Tools.Installer Get-PSModulePath -ParameterFilter { $Scope -eq 'AllUsers' }
            }
            
            It "Should accept custom Path parameter" {
                # Arrange - Set up mock for module discovery
                Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { return @() }
                Mock -ModuleName AWS.Tools.Installer Get-CleanVersion { param($Version) return $Version }
                
                # Act & Assert - Call function with custom Path parameter and verify it doesn't throw
                { Uninstall-AWSToolsInstaller -Path (Join-Path -Path $TestDrive -ChildPath "CustomPath") -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
            }
        }
        
        Context "Module Discovery" {
            It "Should use scope-based path when no custom path specified" {
                # Arrange - Set up mocks for path and module discovery
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { return (Join-Path -Path $TestDrive -ChildPath "TestPath") }
                Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { return @() }
                Mock -ModuleName AWS.Tools.Installer Get-CleanVersion { param($Version) return $Version }
                
                # Act - Call function with scope parameter
                Uninstall-AWSToolsInstaller -Scope CurrentUser -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
                
                # Assert - Verify correct path resolution and module discovery
                Should -Invoke -ModuleName AWS.Tools.Installer Get-PSModulePath -ParameterFilter { $Scope -eq 'CurrentUser' }
                Should -Invoke -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule -ParameterFilter { $Path -eq (Join-Path -Path $TestDrive -ChildPath "TestPath") }
            }
            
            It "Should use custom path when specified" {
                # Arrange - Set up mock for module discovery
                Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { return @() }
                Mock -ModuleName AWS.Tools.Installer Get-CleanVersion { param($Version) return $Version }
                
                # Act - Call function with custom path
                Uninstall-AWSToolsInstaller -Path (Join-Path -Path $TestDrive -ChildPath "CustomPath") -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat 
                
                # Assert - Verify custom path was used for module discovery
                Should -Invoke -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule -ParameterFilter { $Path -eq (Join-Path -Path $TestDrive -ChildPath "CustomPath") }
            }
            
            It "Should filter modules to only AWS.Tools.Installer" {
                # For this test, we'll verify that the function correctly filters modules by name
                # We'll use a different approach since we can't easily create PSModuleInfo objects
                
                # First, let's create a mock for Get-InstalledAWSToolsModule that returns an empty array
                # This will make the function skip the Format-ModuleTarget call
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { return (Join-Path -Path $TestDrive -ChildPath "TestPath") }
                Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { return @() }
                Mock -ModuleName AWS.Tools.Installer Get-CleanVersion { param($Version) return $Version }
                
                # Act - Call function with Confirm:$false
                Uninstall-AWSToolsInstaller -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
                
                # Assert - Verify Get-InstalledAWSToolsModule was called with the correct Name parameter
                Should -Invoke -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule -ParameterFilter { 
                    $Name -eq 'AWS.Tools.Installer'
                }
                
                # This test passes if Get-InstalledAWSToolsModule was called with the correct Name parameter
                # which verifies that the function is filtering modules to only AWS.Tools.Installer
            }
        }
        
        # Note: Using New-MockModule from tests/Include/InstallerTestIncludes.ps1
        
        Context "Version Filtering" {
            BeforeEach {
                $script:mockInstallerModules = @(
                    (New-MockModule -Name "AWS.Tools.Installer" -Version ([Version]"1.0.1") -ModuleBase ([System.IO.Path]::Combine($TestDrive, "TestPath", "AWS.Tools.Installer\1.0.1")))
                    (New-MockModule -Name "AWS.Tools.Installer" -Version ([Version]"1.0.2") -ModuleBase ([System.IO.Path]::Combine($TestDrive, "TestPath", "AWS.Tools.Installer\1.0.2")))
                    (New-MockModule -Name "AWS.Tools.Installer" -Version ([Version]"1.0.3") -ModuleBase ([System.IO.Path]::Combine($TestDrive, "TestPath", "AWS.Tools.Installer\1.0.3")))
                )
            }
            
            It "Should filter by specific version when Version parameter specified" {
                # Arrange - Set up mocks for version filtering
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { return (Join-Path -Path $TestDrive -ChildPath "TestPath") }
                Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { return @() }
                Mock -ModuleName AWS.Tools.Installer Get-CleanVersion { param($Version) return $Version }
                
                # Act - Call function with specific version parameter
                Uninstall-AWSToolsInstaller -Version "1.0.2" -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat 
                
                # Assert - Verify Get-InstalledAWSToolsModule was called with the correct parameters
                Should -Invoke -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule -ParameterFilter { 
                    $Path -eq (Join-Path -Path $TestDrive -ChildPath "TestPath") -and
                    $Name -eq 'AWS.Tools.Installer'
                }
                
                # Verify Get-CleanVersion was called with the correct version
                Should -Invoke -ModuleName AWS.Tools.Installer Get-CleanVersion -ParameterFilter { 
                    $Version -eq "1.0.2"
                }
            }
            
            It "Should filter by except version when ExceptVersion parameter specified" {
                # Arrange - Set up mocks for except version filtering
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { return (Join-Path -Path $TestDrive -ChildPath "TestPath") }
                Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { return @() }
                Mock -ModuleName AWS.Tools.Installer Get-CleanVersion { param($Version) return $Version }
                
                # Act - Call function with ExceptVersion parameter
                Uninstall-AWSToolsInstaller -ExceptVersion "1.0.2" -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat 
                
                # Assert - Verify Get-InstalledAWSToolsModule was called with the correct parameters
                Should -Invoke -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule -ParameterFilter { 
                    $Path -eq (Join-Path -Path $TestDrive -ChildPath "TestPath") -and
                    $Name -eq 'AWS.Tools.Installer'
                }
                
                # Verify Get-CleanVersion was called with the correct version
                Should -Invoke -ModuleName AWS.Tools.Installer Get-CleanVersion -ParameterFilter { 
                    $Version -eq "1.0.2"
                }
            }
            
            It "Should process all versions when no version filter specified" {
                # Arrange - Set up mocks for processing all versions
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { return (Join-Path -Path $TestDrive -ChildPath "TestPath") }
                Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { return @() }
                Mock -ModuleName AWS.Tools.Installer Get-CleanVersion { param($Version) return $Version }
                
                # Act - Call function without version filter
                Uninstall-AWSToolsInstaller -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat 
                
                # Assert - Verify Get-InstalledAWSToolsModule was called with the correct parameters
                Should -Invoke -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule -ParameterFilter { 
                    $Path -eq (Join-Path -Path $TestDrive -ChildPath "TestPath") -and
                    $Name -eq 'AWS.Tools.Installer'
                }
                
                # Verify Get-CleanVersion was not called with any version parameter
                # This is because when no version filter is specified, Get-CleanVersion is only called in Begin block with $null
                Should -Not -Invoke -ModuleName AWS.Tools.Installer Get-CleanVersion -ParameterFilter { 
                    $Version -ne $null
                }
            }
        }
        
        Context "Module Removal" {
            It "Should call Remove-ModuleItem with correct parameters" {

                # Arrange - Set up mock module and dependencies
                $mockModule = New-MockModule -Name "AWS.Tools.Installer" -Version ([Version]"1.0.3") -ModuleBase ([System.IO.Path]::Combine($TestDrive, "TestPath", "AWS.Tools.Installer\1.0.3"))
                
                # Mock the functions with -ModuleName parameter
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { return (Join-Path -Path $TestDrive -ChildPath "TestPath") }
                Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { return @($mockModule) }
                Mock -ModuleName AWS.Tools.Installer Format-ModuleTarget { return "AWS.Tools.Installer version 1.0.3" }
                
                # Mock Remove-ModuleItem
                Mock -ModuleName AWS.Tools.Installer Remove-ModuleItem {
                    param($Module, $Reason)
                    return @{ SuccessCount = 1; FailureCount = 0; FailedModules = @() }
                }
                
                # Act - Call function to trigger module removal
                Uninstall-AWSToolsInstaller -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
                
                # Assert - Verify Remove-ModuleItem was called
                Should -Invoke -ModuleName AWS.Tools.Installer Remove-ModuleItem -Times 1
            }
            
            It "Should handle successful removal" {
                # Arrange - Set up mock module and successful removal scenario
                $mockModule = New-MockModule -Name "AWS.Tools.Installer" -Version ([Version]"1.0.3") -ModuleBase ([System.IO.Path]::Combine($TestDrive, "TestPath", "AWS.Tools.Installer\1.0.3"))
                
                # Mock the functions with -ModuleName parameter
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { return (Join-Path -Path $TestDrive -ChildPath "TestPath") }
                Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { return @($mockModule) }
                Mock -ModuleName AWS.Tools.Installer Format-ModuleTarget { return "test target" }
                
                # Mock Remove-ModuleItem

                Mock -ModuleName AWS.Tools.Installer Remove-ModuleItem {
                    param($Module, $Reason)
                    return @{ SuccessCount = 1; FailureCount = 0; FailedModules = @() }
                }
                
                # Act & Assert - Call function and verify it doesn't throw
                { Uninstall-AWSToolsInstaller -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
                
                # Verify Remove-ModuleItem was called
                Should -Invoke -ModuleName AWS.Tools.Installer Remove-ModuleItem -Times 1
            }
            
            It "Should handle partial failures with warnings" {
                # Arrange - Set up mock modules and partial failure scenario
                $mockModules = @(
                    (New-MockModule -Name "AWS.Tools.Installer" -Version ([Version]"1.0.2") -ModuleBase ([System.IO.Path]::Combine($TestDrive, "TestPath", "AWS.Tools.Installer\1.0.2")))
                    (New-MockModule -Name "AWS.Tools.Installer" -Version ([Version]"1.0.3") -ModuleBase ([System.IO.Path]::Combine($TestDrive, "TestPath", "AWS.Tools.Installer\1.0.3")))
                )
                
                # Mock the functions with -ModuleName parameter
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { return (Join-Path -Path $TestDrive -ChildPath "TestPath") }
                Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { return $mockModules }
                Mock -ModuleName AWS.Tools.Installer Format-ModuleTarget { return "test target" }
                
                # Mock Remove-ModuleItem to simulate partial failures
                $removeResults = @(
                    @{ SuccessCount = 0; FailureCount = 1; FailedModules = @("AWS.Tools.Installer 1.0.2"); RemovedModules = @() },
                    @{ SuccessCount = 1; FailureCount = 0; FailedModules = @(); RemovedModules = @("AWS.Tools.Installer 1.0.3") }
                )
                $removeIndex = 0
                Mock -ModuleName AWS.Tools.Installer Remove-ModuleItem {
                    param($Module, $Reason)
                    $result = $removeResults[$removeIndex]
                    $removeIndex++
                    return $result
                }
                
                # Create a variable to capture the warning message
                $script:warningMessage = $null
                Mock -ModuleName AWS.Tools.Installer Write-Warning { 
                    param($Message) 
                    $script:warningMessage = $Message
                }
                
                # Act - Call function to trigger partial failure handling
                Uninstall-AWSToolsInstaller -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat 
                
                # Assert - Verify warning was written for failed modules
                $script:warningMessage | Should -Match "Failed to remove.*AWS.Tools.Installer"
            }
        }
        
        Context "No Modules Found" {
            It "Should handle case when no installer modules found" {
                # Arrange - Set up mocks with no modules found
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { return (Join-Path -Path $TestDrive -ChildPath "TestPath") }
                Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { return @() }
                Mock -ModuleName AWS.Tools.Installer Get-CleanVersion { param($Version) return $Version }
                Mock -ModuleName AWS.Tools.Installer Format-ModuleTarget { }
                
                # Act & Assert - Call function and verify it handles empty result gracefully
                { Uninstall-AWSToolsInstaller -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
                
                # Verify Format-ModuleTarget was not called since there are no modules
                Should -Not -Invoke -ModuleName AWS.Tools.Installer Format-ModuleTarget
            }
            
            It "Should handle case when no modules match version filter" {
                # Arrange - Set up mock modules that don't match the version filter
                $mockModules = @(
                    [PSCustomObject]@{
                        Name = "AWS.Tools.Installer"
                        Version = [Version]"1.0.1"
                        ModuleBase = ([System.IO.Path]::Combine($TestDrive, "TestPath", "AWS.Tools.Installer\1.0.1"))
                    },
                    [PSCustomObject]@{
                        Name = "AWS.Tools.Installer"
                        Version = [Version]"1.0.2"
                        ModuleBase = ([System.IO.Path]::Combine($TestDrive, "TestPath", "AWS.Tools.Installer\1.0.2"))
                    }
                )
                
                # Mock Get-InstalledAWSToolsModule to return our mock modules
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { return (Join-Path -Path $TestDrive -ChildPath "TestPath") }
                Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { return $mockModules }
                Mock -ModuleName AWS.Tools.Installer Get-CleanVersion { param($Version) return $Version }
                
                # Mock Format-ModuleTarget to avoid the type conversion issue
                Mock -ModuleName AWS.Tools.Installer Format-ModuleTarget { return "test target" }
                
                # Act & Assert - Call function with non-matching version and verify it doesn't throw
                { Uninstall-AWSToolsInstaller -Version "1.0.3" -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
            }
        }
        
        Context "ShouldProcess Support" {
            It "Should support WhatIf parameter" {
                # Arrange - Set up mock module for WhatIf testing
                $mockModule = New-MockModule -Name "AWS.Tools.Installer" -Version ([Version]"1.0.3") -ModuleBase ([System.IO.Path]::Combine($TestDrive, "TestPath", "AWS.Tools.Installer\1.0.3"))
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { return (Join-Path -Path $TestDrive -ChildPath "TestPath") }
                Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { return @($mockModule) }
                Mock -ModuleName AWS.Tools.Installer Format-ModuleTarget { return "test target" }

                Mock -ModuleName AWS.Tools.Installer Write-Host { }
                
                # Act & Assert - Call function with WhatIf and verify it doesn't throw
                { Uninstall-AWSToolsInstaller -WhatIf -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
                
                # Should display WhatIf message
                Should -Invoke -ModuleName AWS.Tools.Installer Write-Host -ParameterFilter {
                    $Object -like "What if: Would remove*"
                }
            }
        }
        
        Context "Wildcard Version Rejection" {
            It "Should reject wildcard in Version parameter" {
                # Act & Assert
                { Uninstall-AWSToolsInstaller -Version '2.*' -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | 
                    Should -Throw "*Wildcard versions are not supported for uninstall operations*"
            }
            
            It "Should reject wildcard in ExceptVersion parameter" {
                # Act & Assert
                { Uninstall-AWSToolsInstaller -ExceptVersion '2.*' -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | 
                    Should -Throw "*Wildcard versions are not supported in the ExceptVersion parameter*"
            }
            
            It "Should provide helpful error message for Version wildcard" {
                # Act & Assert
                { Uninstall-AWSToolsInstaller -Version '2.*' -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | 
                    Should -Throw "*Please specify an exact version*"
            }
            
            It "Should provide helpful error message for ExceptVersion wildcard" {
                # Act & Assert
                { Uninstall-AWSToolsInstaller -ExceptVersion '2.*' -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | 
                    Should -Throw "*Please specify an exact version*"
            }
        }
        
        Context "Prerelease Version Support" {
            It "Should accept prerelease version with -Prerelease switch" {
                # Arrange
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { Join-Path -Path $TestDrive -ChildPath "TestPath" }
                Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { @() }
                Mock -ModuleName AWS.Tools.Installer Test-PrereleaseParameterValidation { @{ IsPreReleaseVersion = $true; IsWildcardVersion = $false } }
                
                # Act & Assert
                { Uninstall-AWSToolsInstaller -Version '2.0.0-preview001' -Prerelease -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
            }
            
            It "Should require -Prerelease switch for prerelease versions" {
                # Act & Assert
                { Uninstall-AWSToolsInstaller -Version '2.0.0-preview001' -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | 
                    Should -Throw "*The -Prerelease switch must be specified when installing a prerelease version*"
            }
            
            It "Should accept prerelease ExceptVersion with -Prerelease switch" {
                # Arrange
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { Join-Path -Path $TestDrive -ChildPath "TestPath" }
                Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { @() }
                Mock -ModuleName AWS.Tools.Installer Test-PrereleaseParameterValidation { @{ IsPreReleaseVersion = $true; IsWildcardVersion = $false } }
                
                # Act & Assert
                { Uninstall-AWSToolsInstaller -ExceptVersion '2.0.0-preview001' -Prerelease -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
            }
            
            It "Should require -Prerelease switch for prerelease ExceptVersion" {
                # Act & Assert
                { Uninstall-AWSToolsInstaller -ExceptVersion '2.0.0-preview001' -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | 
                    Should -Throw "*The -Prerelease switch must be specified when installing a prerelease version*"
            }
        }
        
        Context "Error Handling" {
            It "Should handle Get-InstalledAWSToolsModule errors" {
                # Arrange - Set up mock to throw error during module discovery
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { return (Join-Path -Path $TestDrive -ChildPath "TestPath") }
                Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { throw "Module discovery failed" }
                
                # Act & Assert - Call function and verify it throws expected error
                { Uninstall-AWSToolsInstaller -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Throw "Module discovery failed"
            }
            
            It "Should handle Remove-ModuleItem errors" {
                # Arrange - Set up mock module and Remove-ModuleItem to throw error
                $mockModule = New-MockModule -Name "AWS.Tools.Installer" -Version ([Version]"1.0.3") -ModuleBase ([System.IO.Path]::Combine($TestDrive, "TestPath", "AWS.Tools.Installer\1.0.3"))
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { return (Join-Path -Path $TestDrive -ChildPath "TestPath") }
                Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { return @($mockModule) }
                Mock -ModuleName AWS.Tools.Installer Format-ModuleTarget { return "test target" }
                Mock -ModuleName AWS.Tools.Installer Remove-ModuleItem { throw "Removal failed" }
                
                # Act & Assert - Call function and verify it throws expected error
                { Uninstall-AWSToolsInstaller -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Throw "Removal failed"
            }
        }
        
        Context "Path Filtering" {
            It "Should filter modules by target path" {
                # Arrange - Set up mock modules from different paths
                $mockModules = @(
                    (New-MockModule -Name "AWS.Tools.Installer" -Version ([Version]"1.0.3") -ModuleBase ([System.IO.Path]::Combine($TestDrive, "TestPath", "AWS.Tools.Installer\1.0.3")))
                    (New-MockModule -Name "AWS.Tools.Installer" -Version ([Version]"1.0.3") -ModuleBase ([System.IO.Path]::Combine($TestDrive, "OtherPath", "AWS.Tools.Installer\1.0.3")))
                )
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { return (Join-Path -Path $TestDrive -ChildPath "TestPath") }
                Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { return $mockModules }
                Mock -ModuleName AWS.Tools.Installer Format-ModuleTarget { return "test target" }
                
                # Track which modules are passed to Remove-ModuleItem
                $processedModules = @()
                Mock -ModuleName AWS.Tools.Installer Remove-ModuleItem {
                    param($Module, $Reason)
                    $script:processedModules += $Module
                    return @{ SuccessCount = 1; FailureCount = 0; FailedModules = @() }
                }
                
                # Act - Call function to trigger path filtering
                $script:processedModules = @()
                Uninstall-AWSToolsInstaller -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat 
                
                # Assert - Verify only modules from the target path were processed
                $script:processedModules.Count | Should -Be 1
                $script:processedModules[0].ModuleBase | Should -BeLike "*TestPath*"
                $script:processedModules[0].ModuleBase | Should -Not -BeLike "*OtherPath*"
            }
        }
    }
}
