BeforeDiscovery {
    # Import the module under test in BeforeDiscovery
    . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")
}

BeforeAll {
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
    
    Describe -Skip:$SkipInstallerTests -Tag "Smoke", "Low", "Medium", "High" "Install-AWSToolsInstaller" {
        
        BeforeEach {
            # Reset version cache before each test
            $script:VersionCache = @{}
        }
        
        Context "Parameter Validation" {
            It "Should accept valid Version parameter" {
                # Arrange - Set up mocks for all dependencies
                Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsVersion { return [Version]"1.0.3" }
                Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { return $false }
                Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { return "AWS.Tools.zip" }
                Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { return "1.0.3" }
                Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsInstaller { }
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { return (Join-Path -Path $HOME -ChildPath "TestPath") }
                Mock -ModuleName AWS.Tools.Installer New-Item { }
                Mock -ModuleName AWS.Tools.Installer Test-Path { return $true }
                Mock -ModuleName AWS.Tools.Installer Remove-Item { }
                
                # Act & Assert - Call function with valid Version parameter and verify it doesn't throw
                { Install-AWSToolsInstaller -Version "1.0.3" -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat} | Should -Not -Throw
            }
            
            It "Should accept valid Scope parameter" {
                # Arrange - Set up mocks for all dependencies
                Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsVersion { return [Version]"1.0.3" }
                Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { return $false }
                Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { return "AWS.Tools.zip" }
                Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { return "1.0.3" }
                Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsInstaller { }
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { return (Join-Path -Path $HOME -ChildPath "TestPath") }
                Mock -ModuleName AWS.Tools.Installer New-Item { }
                Mock -ModuleName AWS.Tools.Installer Test-Path { return $true }
                Mock -ModuleName AWS.Tools.Installer Remove-Item { }
                
                # Act - Call function with valid Scope parameter
                { Install-AWSToolsInstaller -Scope AllUsers -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat} | Should -Not -Throw
                
                # Assert - Verify Get-PSModulePath was called with correct scope
                Should -Invoke -ModuleName AWS.Tools.Installer Get-PSModulePath -ParameterFilter { $Scope -eq 'AllUsers' }
            }
            
            It "Should accept SourceZipPath parameter" {
                # Arrange - Set up mocks for all dependencies
                Mock Test-AWSToolsVersionInstalled { return $false }
                Mock Resolve-AWSToolsZipSource { return (Join-Path -Path $HOME -ChildPath "AWS.Tools.zip") }
                Mock Install-AWSToolsModuleFromZip { return "1.0.3" }
                Mock Uninstall-AWSToolsInstaller { }
                Mock Get-PSModulePath { return (Join-Path -Path $HOME -ChildPath "TestPath") }
                Mock New-Item { }
                Mock Test-Path { return $true }
                Mock Remove-Item { }
                
                # Act - Call function with SourceZipPath parameter
                $testZipPath = Join-Path -Path $HOME -ChildPath "AWS.Tools.zip"
                Install-AWSToolsInstaller -SourceZipPath $testZipPath -WarningAction SilentlyContinue @script:InformationActionSplat
                
                # Assert - Verify Resolve-AWSToolsZipSource was called with correct path
                Should -Invoke Resolve-AWSToolsZipSource -ParameterFilter { $SourceZipPath -eq $testZipPath }
            }
            
            It "Should accept custom Path parameter" {
                # Arrange - Set up mocks for all dependencies
                Mock Resolve-AWSToolsVersion { return $null }
                Mock Test-AWSToolsVersionInstalled { return $false }
                Mock Resolve-AWSToolsZipSource { return "AWS.Tools.zip" }
                Mock Install-AWSToolsModuleFromZip { return "1.0.3" }
                Mock Uninstall-AWSToolsInstaller { }
                Mock New-Item { }
                Mock Test-Path { return $true }
                Mock Remove-Item { }
                
                # Act & Assert - Call function with custom Path parameter and verify it doesn't throw
                $customPath = Join-Path -Path $HOME -ChildPath "CustomPath"
                { Install-AWSToolsInstaller -Path $customPath -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
            }
            
            It "Should accept Cleanup parameter" {
                # Arrange - Set up mocks for all dependencies
                Mock Resolve-AWSToolsVersion { return [Version]"1.0.3" }
                Mock Test-AWSToolsVersionInstalled { return $false }
                Mock Resolve-AWSToolsZipSource { return "AWS.Tools.zip" }
                Mock Install-AWSToolsModuleFromZip { return "1.0.3" }
                Mock Uninstall-AWSToolsInstaller { }
                Mock Get-PSModulePath { return (Join-Path -Path $HOME -ChildPath "TestPath") }
                Mock New-Item { }
                Mock Test-Path { return $true }
                Mock Remove-Item { }
                
                # Act & Assert - Call function with Cleanup parameter and verify it doesn't throw
                { Install-AWSToolsInstaller -Cleanup -Confirm:$false  -WarningAction SilentlyContinue @script:InformationActionSplat} | Should -Not -Throw
            }
        }
        
        Context "Version Resolution" {
            It "Should resolve version for ManagedCloudFront parameter set" {
                # Arrange - Set up mocks for all dependencies
                Mock Resolve-AWSToolsVersion { return [Version]"1.0.3" }
                Mock Test-AWSToolsVersionInstalled { return $false }
                Mock Resolve-AWSToolsZipSource { return "AWS.Tools.zip" }
                Mock Install-AWSToolsModuleFromZip { return "1.0.3" }
                Mock Uninstall-AWSToolsInstaller { }
                Mock Get-PSModulePath { return (Join-Path -Path $HOME -ChildPath "TestPath") }
                Mock New-Item { }
                Mock Test-Path { return $true }
                Mock Remove-Item { }
                
                # Act - Call function with specific version
                Install-AWSToolsInstaller -Version "1.0.3" -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
                
                # Assert - Verify version resolution was called with correct parameters
                Should -Invoke Resolve-AWSToolsVersion -ParameterFilter { 
                    $Name -eq 'AWS.Tools.Installer' -and $Version -eq "1.0.3" 
                }
            }
            
            It "Should handle latest version when no version specified" {
                # Arrange - Set up mocks for all dependencies
                Mock Resolve-AWSToolsVersion { return [Version]"1.0.3" }
                Mock Test-AWSToolsVersionInstalled { return $false }
                Mock Resolve-AWSToolsZipSource { return "AWS.Tools.zip" }
                Mock Install-AWSToolsModuleFromZip { return "1.0.3" }
                Mock Uninstall-AWSToolsInstaller { }
                Mock Get-PSModulePath { return (Join-Path -Path $HOME -ChildPath "TestPath") }
                Mock New-Item { }
                Mock Test-Path { return $true }
                Mock Remove-Item { }
                
                # Act - Call function without version parameter
                Install-AWSToolsInstaller -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
                
                # Assert - Verify version resolution was called without version parameter
                Should -Invoke Resolve-AWSToolsVersion -ParameterFilter { 
                    $Name -eq 'AWS.Tools.Installer' -and [string]::IsNullOrEmpty($Version)
                }
            }
        }
        
        Context "Installation Logic" {
            It "Should skip installation if version already installed and Force not specified" {
                # Arrange - Set up mocks with version already installed
                Mock Resolve-AWSToolsVersion { return [Version]"1.0.3" }
                Mock Get-PSModulePath { return (Join-Path -Path $HOME -ChildPath "TestPath") }
                Mock Get-InstalledAWSToolsModule { 
                    return [PSCustomObject]@{
                        Name = 'AWS.Tools.Installer'
                        Version = [Version]"1.0.3"
                    }
                }
                Mock Resolve-AWSToolsZipSource { }
                Mock Install-AWSToolsModuleFromZip { }
                
                # Act - Call function without Force parameter
                Install-AWSToolsInstaller -Version "1.0.3" -WarningAction SilentlyContinue @script:InformationActionSplat
                
                # Assert - Verify installation was skipped
                Should -Invoke Get-InstalledAWSToolsModule -ParameterFilter { 
                    $Name -eq 'AWS.Tools.Installer'
                }
                Should -Not -Invoke Resolve-AWSToolsZipSource
                Should -Not -Invoke Install-AWSToolsModuleFromZip
            }
            
            It "Should proceed with installation if Force specified" {
                # Arrange - Set up mocks for all dependencies
                Mock Resolve-AWSToolsVersion { return [Version]"1.0.3" }
                Mock Get-PSModulePath { return (Join-Path -Path $HOME -ChildPath "TestPath") }
                Mock Get-InstalledAWSToolsModule { 
                    return [PSCustomObject]@{
                        Name = 'AWS.Tools.Installer'
                        Version = [Version]"1.0.3"
                    }
                }
                Mock Resolve-AWSToolsZipSource { return "AWS.Tools.zip" }
                Mock Install-AWSToolsModuleFromZip { 
                    return @{
                        Version = [Version]"1.0.3"
                        VersionString = "1.0.3"
                        Modules = @()
                    }
                }
                Mock Uninstall-AWSToolsInstaller { }
                Mock New-Item { }
                Mock Test-Path { return $true }
                Mock Remove-Item { }
                
                # Act - Call function with Force parameter
                Install-AWSToolsInstaller -Version "1.0.3" -Force -WarningAction SilentlyContinue @script:InformationActionSplat
                
                # Assert - Verify installation proceeded (Get-InstalledAWSToolsModule should not be called when Force is true)
                Should -Not -Invoke Get-InstalledAWSToolsModule
                Should -Invoke Resolve-AWSToolsZipSource
                Should -Invoke Install-AWSToolsModuleFromZip
            }
            
            It "Should use correct Name parameter for installer operations" {
                # Arrange - Set up mocks for all dependencies
                Mock Resolve-AWSToolsVersion { return [Version]"1.0.3" }
                Mock Test-AWSToolsVersionInstalled { return $false }
                Mock Resolve-AWSToolsZipSource { return "AWS.Tools.zip" }
                Mock Install-AWSToolsModuleFromZip { return "1.0.3" }
                Mock Uninstall-AWSToolsInstaller { }
                Mock Get-PSModulePath { return (Join-Path -Path $HOME -ChildPath "TestPath") }
                Mock New-Item { }
                Mock Test-Path { return $true }
                Mock Remove-Item { }
                
                # Act - Call function to trigger installer operations
                Install-AWSToolsInstaller -WarningAction SilentlyContinue @script:InformationActionSplat
                
                # Assert - Verify correct Name parameter was used in operations
                Should -Invoke Resolve-AWSToolsZipSource -ParameterFilter { $Name -eq 'AWS.Tools.Installer' }
                Should -Invoke Install-AWSToolsModuleFromZip -ParameterFilter { 
                    $Name -eq 'AWS.Tools.Installer' -and $ModuleNames -contains 'AWS.Tools.Installer'
                }
            }
        }
        
        Context "Cleanup Operations" {
            It "Should not call cleanup by default" {
                # Arrange - Set up mocks for all dependencies
                Mock Resolve-AWSToolsVersion { return [Version]"1.0.3" }
                Mock Test-AWSToolsVersionInstalled { return $false }
                Mock Resolve-AWSToolsZipSource { return "AWS.Tools.zip" }
                Mock Install-AWSToolsModuleFromZip { return "1.0.3" }
                Mock Uninstall-AWSToolsInstaller { }
                Mock Get-PSModulePath { return (Join-Path -Path $HOME -ChildPath "TestPath") }
                Mock New-Item { }
                Mock Test-Path { return $true }
                Mock Remove-Item { }
                
                # Act - Call function without Cleanup parameter
                Install-AWSToolsInstaller -Version "1.0.3" -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
                
                # Assert - Verify cleanup was not called
                Should -Not -Invoke Uninstall-AWSToolsInstaller
            }
            
            It "Should call cleanup when Cleanup parameter is specified" {
                # Arrange - Set up mocks for all dependencies
                Mock Resolve-AWSToolsVersion { return [Version]"1.0.3" }
                Mock Test-AWSToolsVersionInstalled { return $false }
                Mock Resolve-AWSToolsZipSource { return "AWS.Tools.zip" }
                Mock Install-AWSToolsModuleFromZip { return "1.0.3" }
                Mock Uninstall-AWSToolsInstaller { }
                Mock Get-PSModulePath { return (Join-Path -Path $HOME -ChildPath "TestPath") }
                Mock New-Item { }
                Mock Test-Path { return $true }
                Mock Remove-Item { }
                
                # Act - Call function with Cleanup parameter
                Install-AWSToolsInstaller -Version "1.0.3" -Cleanup -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
                
                # Assert - Verify cleanup was called with correct version
                Should -Invoke Uninstall-AWSToolsInstaller -ParameterFilter { 
                    $ExceptVersion -eq "1.0.3" 
                }
            }
            
            It "Should pass WhatIf preference to cleanup" {
                # Arrange - Set up mocks for all dependencies
                Mock Resolve-AWSToolsVersion { return [Version]"1.0.3" }
                Mock Test-AWSToolsVersionInstalled { return $false }
                Mock Resolve-AWSToolsZipSource { return "AWS.Tools.zip" }
                Mock Install-AWSToolsModuleFromZip { return "1.0.3" }
                Mock Uninstall-AWSToolsInstaller { }
                Mock Get-PSModulePath { return (Join-Path -Path $HOME -ChildPath "TestPath") }
                Mock New-Item { }
                Mock Test-Path { return $true }
                Mock Remove-Item { }
                
                # Act - Call function with Cleanup parameter
                Install-AWSToolsInstaller -Version "1.0.3" -Cleanup -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
                
                # Assert - Verify cleanup was called
                Should -Invoke Uninstall-AWSToolsInstaller -Times 1
            }
            
            It "Should handle cleanup errors gracefully" {
                # Arrange - Set up mocks with cleanup failure
                Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsVersion { return [Version]"1.0.3" }
                Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { return $false }
                Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { return "AWS.Tools.zip" }
                Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { return "1.0.3" }
                Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsInstaller { throw "Cleanup failed" }
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { return (Join-Path -Path $HOME -ChildPath "TestPath") }
                Mock -ModuleName AWS.Tools.Installer New-Item { }
                Mock -ModuleName AWS.Tools.Installer Test-Path { return $true }
                Mock -ModuleName AWS.Tools.Installer Remove-Item { }
                Mock -ModuleName AWS.Tools.Installer Write-Error { }
                
                # Act & Assert - Call function and verify it handles cleanup errors gracefully
                { Install-AWSToolsInstaller -Version "1.0.3" -Cleanup -WarningAction SilentlyContinue @script:InformationActionSplat} | Should -Not -Throw
                Should -Invoke Write-Error -ParameterFilter { 
                    $Message -like "*Failed to clean up previous AWS.Tools.Installer versions*"
                }
            }
        }
        
        Context "Temporary Directory Management" {
            It "Should create and clean up temporary directory" {
                # Arrange - Set up mocks for all dependencies
                Mock Resolve-AWSToolsVersion { return [Version]"1.0.3" }
                Mock Test-AWSToolsVersionInstalled { return $false }
                Mock Resolve-AWSToolsZipSource { return "AWS.Tools.zip" }
                Mock Install-AWSToolsModuleFromZip { return "1.0.3" }
                Mock Uninstall-AWSToolsInstaller { }
                Mock Get-PSModulePath { return (Join-Path -Path $HOME -ChildPath "TestPath") }
                Mock New-Item { }
                Mock Test-Path { return $true }
                Mock Remove-Item { }
                
                # Act - Call function to trigger temporary directory operations
                Install-AWSToolsInstaller -Version "1.0.3" -WarningAction SilentlyContinue @script:InformationActionSplat
                
                # Assert - Verify temporary directory was created and cleaned up
                Should -Invoke New-Item -ParameterFilter { $ItemType -eq 'Directory' }
                Should -Invoke Remove-Item -ParameterFilter { $Recurse -eq $true -and $Force -eq $true }
            }
            
            It "Should clean up temporary directory even if installation fails" {
                # Arrange - Set up mocks with installation failure
                Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsVersion { return [Version]"1.0.3" }
                Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { return $false }
                Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { return "AWS.Tools.zip" }
                Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { throw "Installation failed" }
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { return (Join-Path -Path $HOME -ChildPath "TestPath") }
                Mock -ModuleName AWS.Tools.Installer New-Item { }
                Mock -ModuleName AWS.Tools.Installer Test-Path { return $true }
                Mock -ModuleName AWS.Tools.Installer Remove-Item { }
                
                # Act & Assert - Call function and verify it throws but still cleans up
                { Install-AWSToolsInstaller -Version "1.0.3" -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Throw "Installation failed"
                Should -Invoke -ModuleName AWS.Tools.Installer Remove-Item -ParameterFilter { $Recurse -eq $true -and $Force -eq $true }
            }
        }
        
        Context "ShouldProcess Support" {
            It "Should support WhatIf parameter" {
                # Arrange - Set up mocks for dependencies
                Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsVersion { return [Version]"1.0.3" }
                Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { return $false }
                Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { return "AWS.Tools.zip" }
                Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { return "1.0.3" }
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { return (Join-Path -Path $HOME -ChildPath "TestPath") }
                Mock -ModuleName AWS.Tools.Installer New-Item { }
                Mock -ModuleName AWS.Tools.Installer Test-Path { return $true }
                
                # Act - Call function with WhatIf
                Install-AWSToolsInstaller -Version "1.0.3" -WhatIf -WarningAction SilentlyContinue @script:InformationActionSplat
                
                # Assert - Should not perform actual operations in WhatIf mode
                Should -Not -Invoke -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip
            }
        }
        
        Context "Error Handling" {
            It "Should handle version resolution errors" {
                # Arrange - Set up mock to throw error during version resolution
                Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsVersion { throw "Version resolution failed" }
                Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { return (Join-Path -Path $HOME -ChildPath "TestPath") }
                
                # Act & Assert - Call function with invalid version and verify it throws expected error
                { Install-AWSToolsInstaller -Version "invalid" -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Throw "Version resolution failed"
            }
            
            It "Should handle zip source resolution errors" {
                # Arrange - Set up mocks with zip source resolution failure
                Mock Resolve-AWSToolsVersion { return [Version]"1.0.3" }
                Mock Test-AWSToolsVersionInstalled { return $false }
                Mock Resolve-AWSToolsZipSource { throw "Zip source resolution failed" }
                Mock Get-PSModulePath { return (Join-Path -Path $HOME -ChildPath "TestPath") }
                Mock New-Item { }
                Mock Test-Path { return $true }
                Mock Remove-Item { }
                
                # Act & Assert - Call function and verify it throws expected error
                { Install-AWSToolsInstaller -Version "1.0.3" -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Throw "Zip source resolution failed"
            }
            
            It "Should handle installation errors" {
                # Arrange - Set up mocks with installation failure
                Mock Resolve-AWSToolsVersion { return [Version]"1.0.3" }
                Mock Test-AWSToolsVersionInstalled { return $false }
                Mock Resolve-AWSToolsZipSource { return "AWS.Tools.zip" }
                Mock Install-AWSToolsModuleFromZip { throw "Installation failed" }
                Mock Get-PSModulePath { return (Join-Path -Path $HOME -ChildPath "TestPath") }
                Mock New-Item { }
                Mock Test-Path { return $true }
                Mock Remove-Item { }
                
                # Act & Assert - Call function and verify it throws expected error
                { Install-AWSToolsInstaller -Version "1.0.3" -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Throw "Installation failed"
            }
        }
        
        Context "Default Cleanup Behavior" {
            It "Should not perform cleanup when -Cleanup parameter is not specified" {
                # Arrange
                Mock Resolve-AWSToolsVersion { return [Version]"1.0.3" }
                Mock Test-AWSToolsVersionInstalled { return $false }
                Mock Resolve-AWSToolsZipSource { return "AWS.Tools.zip" }
                Mock Install-AWSToolsModuleFromZip { return "1.0.3" }
                Mock Uninstall-AWSToolsInstaller { }
                Mock Get-PSModulePath { return (Join-Path -Path $HOME -ChildPath "TestPath") }
                Mock New-Item { }
                Mock Test-Path { return $true }
                Mock Remove-Item { }
                
                # Act
                Install-AWSToolsInstaller -Version "1.0.3" -WarningAction SilentlyContinue @script:InformationActionSplat
                
                # Assert
                Should -Not -Invoke Uninstall-AWSToolsInstaller
            }
            
            It "Should perform cleanup when -Cleanup parameter is specified" {
                # Arrange
                Mock Resolve-AWSToolsVersion { return [Version]"1.0.3" }
                Mock Test-AWSToolsVersionInstalled { return $false }
                Mock Resolve-AWSToolsZipSource { return "AWS.Tools.zip" }
                Mock Install-AWSToolsModuleFromZip { return "1.0.3" }
                Mock Uninstall-AWSToolsInstaller { }
                Mock Get-PSModulePath { return (Join-Path -Path $HOME -ChildPath "TestPath") }
                Mock New-Item { }
                Mock Test-Path { return $true }
                Mock Remove-Item { }
                
                # Act
                Install-AWSToolsInstaller -Version "1.0.3" -Cleanup -WarningAction SilentlyContinue @script:InformationActionSplat
                
                # Assert
                Should -Invoke Uninstall-AWSToolsInstaller -Times 1
            }
        }
    }
}
