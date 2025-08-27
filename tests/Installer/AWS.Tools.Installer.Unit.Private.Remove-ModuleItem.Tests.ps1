BeforeDiscovery {
    Import-Module (Join-Path $PSScriptRoot "../../modules/Installer/AWS.Tools.Installer.psd1") -Force
}

BeforeAll {
    # Set preference variables to suppress verbose, progress, and warning output
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
    $WarningPreference = 'SilentlyContinue'
}


InModuleScope AWS.Tools.Installer {
    Describe -Tag "Smoke", "Low", "Medium", "High" "Installer - Remove-ModuleItem Unit Tests" {
        BeforeAll {
            # Create cross-platform paths
            $tempPath = [System.IO.Path]::GetTempPath()
            $userModulePath = Join-Path $tempPath "UserModules"
            
            # Mock Remove-Item to simulate successful removal
            Mock Remove-Item { }
            Mock Test-Path { return $false } -ParameterFilter { $Path -like "*AWS.Tools*" }
            
            # Mock functions
            Mock Invoke-WithRetry {
                param($ScriptBlock)
                & $ScriptBlock
            }
            
            # Mock Remove-Item to simulate successful removal
            Mock Remove-Item { }
            Mock Test-Path { return $false } -ParameterFilter { $Path -like "*AWS.Tools*" }
        }
        
        Context "Parameter Validation" {
            It "Should accept a single module object" {
                # Arrange
                $mockModule = New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                    Name       = "AWS.Tools.EC2"
                    Version    = [Version]"4.1.850"
                    ModuleBase = Join-Path $tempPath "TestModules/AWS.Tools.EC2/4.1.850"
                }
                
                # Act & Assert
                { Remove-ModuleItem -Module $mockModule } | Should -Not -Throw
            }
            
            It "Should accept multiple module objects" {
                # Arrange
                $mockModules = @(
                    (New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                        Name       = "AWS.Tools.EC2"
                        Version    = [Version]"4.1.850"
                        ModuleBase = Join-Path $tempPath "TestModules/AWS.Tools.EC2/4.1.850"
                    }),
                    (New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                        Name       = "AWS.Tools.S3"
                        Version    = [Version]"4.1.850"
                        ModuleBase = Join-Path $tempPath "TestModules/AWS.Tools.S3/4.1.850"
                    })
                )
                
                # Act
                $result = Remove-ModuleItem -Module $mockModules
                
                # Assert
                $result.SuccessCount | Should -Be 2
                $result.RemovedModules.Count | Should -Be 2
            }
            
            It "Should accept module objects via pipeline" {
                # Arrange
                $mockModules = @(
                    (New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                        Name       = "AWS.Tools.EC2"
                        Version    = [Version]"4.1.850"
                        ModuleBase = Join-Path $tempPath "TestModules/AWS.Tools.EC2/4.1.850"
                    }),
                    (New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                        Name       = "AWS.Tools.S3"
                        Version    = [Version]"4.1.850"
                        ModuleBase = Join-Path $tempPath "TestModules/AWS.Tools.S3/4.1.850"
                    })
                )
                
                # Act
                $result = $mockModules | Remove-ModuleItem
                
                # Assert
                $result.SuccessCount | Should -Be 2
                $result.RemovedModules.Count | Should -Be 2
            }
            
            It "Should accept custom Reason parameter" {
                # Arrange
                $mockModule = New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                    Name       = "AWS.Tools.EC2"
                    Version    = [Version]"4.1.850"
                    ModuleBase = Join-Path $tempPath "TestModules/AWS.Tools.EC2/4.1.850"
                }
                $customReason = "Custom removal reason"
                
                # Act
                Remove-ModuleItem -Module $mockModule -Reason $customReason
                
                # Assert
                Should -Invoke Remove-Item -Times 1
            }
        }
        
        Context "Module Removal Functionality" {
            It "Should call Remove-Item with correct parameters" {
                # Arrange
                $mockModule = New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                    Name       = "AWS.Tools.EC2"
                    Version    = [Version]"4.1.850"
                    ModuleBase = Join-Path $tempPath "TestModules/AWS.Tools.EC2/4.1.850"
                }
                
                # Act
                Remove-ModuleItem -Module $mockModule
                
                # Assert
                Should -Invoke Remove-Item -Times 1 -ParameterFilter { 
                    $Path -eq $mockModule.ModuleBase -and 
                    $Recurse -eq $true -and 
                    $Force -eq $true 
                }
            }
            
            It "Should handle successful removal" {
                # Arrange
                $mockModule = New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                    Name       = "AWS.Tools.EC2"
                    Version    = [Version]"4.1.850"
                    ModuleBase = Join-Path $tempPath "TestModules/AWS.Tools.EC2/4.1.850"
                }
                Mock Test-Path { return $false } -ParameterFilter { $Path -eq $mockModule.ModuleBase }
                
                # Act
                $result = Remove-ModuleItem -Module $mockModule
                
                # Assert
                $result.SuccessCount | Should -Be 1
                $result.FailureCount | Should -Be 0
                $result.RemovedModules | Should -Contain "AWS.Tools.EC2 (4.1.850)"
                $result.FailedModules | Should -BeNullOrEmpty
            }
            
            It "Should handle failed removal" {
                # Arrange
                $mockModule = New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                    Name       = "AWS.Tools.EC2"
                    Version    = [Version]"4.1.850"
                    ModuleBase = Join-Path $tempPath "TestModules/AWS.Tools.EC2/4.1.850"
                }
                Mock Test-Path { return $true } -ParameterFilter { $Path -eq $mockModule.ModuleBase }
                
                # Act
                $result = Remove-ModuleItem -Module $mockModule -ErrorAction SilentlyContinue
                
                # Assert
                $result.SuccessCount | Should -Be 0
                $result.FailureCount | Should -Be 1
                $result.RemovedModules | Should -BeNullOrEmpty
                $result.FailedModules | Should -Contain "AWS.Tools.EC2 (4.1.850)"
            }
        
            Context "ShouldProcess Support" {
                It "Should respect WhatIf parameter" {
                    # Arrange
                    $mockModule = New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                        Name       = "AWS.Tools.EC2"
                        Version    = [Version]"4.1.850"
                        ModuleBase = Join-Path $tempPath "TestModules/AWS.Tools.EC2/4.1.850"
                    }
                
                    # Act
                    Remove-ModuleItem -Module $mockModule -WhatIf
                
                    # Assert
                    Should -Not -Invoke Remove-Item
                }

                It "Should handle ShouldProcess confirmation" {
                    # Arrange
                    $mockModule = New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                        Name       = "AWS.Tools.EC2"
                        Version    = [Version]"4.1.850"
                        ModuleBase = Join-Path $tempPath "TestModules/AWS.Tools.EC2/4.1.850"
                    }
                      
                    # Act with -WhatIf to test ShouldProcess
                    Remove-ModuleItem -Module $mockModule -WhatIf
                
                    # Assert
                    Should -Not -Invoke Remove-Item

                }
            }
        
            Context "Parent Directory Cleanup" {
                It "Should remove empty parent directory after removing version directory" {
                    # Arrange
                    $mockModule = New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                        Name       = "AWS.Tools.EC2"
                        Version    = [Version]"4.1.850"
                        ModuleBase = Join-Path $tempPath "TestModules/AWS.Tools.EC2/4.1.850"
                    }
                
                    # Clear any existing mocks
                    Mock Test-Path { } -ParameterFilter { $true } -ModuleName AWS.Tools.Installer
                
                    # First, mock Test-Path for the module directory to return false (successful removal)
                    Mock Test-Path { return $false } -ParameterFilter { $Path -eq $mockModule.ModuleBase }
                
                    # Then, mock Test-Path for the parent directory to return true (exists) initially
                    # and false (successfully removed) after removal
                    Mock Test-Path { return $true } -ParameterFilter { $Path -eq (Join-Path $tempPath "TestModules/AWS.Tools.EC2") }
                
                    # Mock Get-ChildItem to return empty results (empty directory)
                    Mock Get-ChildItem { return $null } -ParameterFilter { $Path -eq (Join-Path $tempPath "TestModules/AWS.Tools.EC2") }
                
                    # Mock Remove-Item to track calls
                    Mock Remove-Item { } -ParameterFilter { $true } -Verifiable

                    # Act
                    $result = Remove-ModuleItem -Module $mockModule -WarningAction 'SilentlyContinue'
                
                    # Assert
                    # Should be called twice: once for version directory, once for parent directory
                    Should -Invoke Remove-Item -Times 2
                    Should -Invoke Remove-Item -ParameterFilter { 
                        $Path -eq $mockModule.ModuleBase 
                    } -Times 1
                    Should -Invoke Remove-Item -ParameterFilter { 
                        $Path -eq (Join-Path $tempPath "TestModules/AWS.Tools.EC2") 
                    } -Times 1
                
                    $result.SuccessCount | Should -Be 1
                    $result.FailureCount | Should -Be 0
                }
            
                It "Should not remove non-empty parent directory" {
                    # Arrange
                    $mockModule = New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                        Name       = "AWS.Tools.EC2"
                        Version    = [Version]"4.1.850"
                        ModuleBase = Join-Path $tempPath "TestModules/AWS.Tools.EC2/4.1.850"
                    }
                
                    # Mock Test-Path to indicate parent directory exists
                    Mock Test-Path { return $true } -ParameterFilter { $Path -eq (Join-Path $tempPath "TestModules/AWS.Tools.EC2") }
                
                    # Mock Get-ChildItem to return non-empty results (directory has content)
                    Mock Get-ChildItem { 
                        return @(
                            [PSCustomObject]@{ Name = "4.1.851"; FullName = Join-Path $tempPath "TestModules/AWS.Tools.EC2/4.1.851" }
                        )
                    } -ParameterFilter { $Path -eq (Join-Path $tempPath "TestModules/AWS.Tools.EC2") }
                
                    # Mock Remove-Item and Test-Path for version directory
                    Mock Remove-Item { }
                    Mock Test-Path { return $false } -ParameterFilter { $Path -eq $mockModule.ModuleBase }
                
                    # Act
                    $result = Remove-ModuleItem -Module $mockModule
                
                    # Assert
                    # Should be called only once for the version directory, not for parent
                    Should -Invoke Remove-Item -Times 1
                    Should -Invoke Remove-Item -ParameterFilter { 
                        $Path -eq $mockModule.ModuleBase 
                    } -Times 1
                    Should -Not -Invoke Remove-Item -ParameterFilter { 
                        $Path -eq (Join-Path $tempPath "TestModules/AWS.Tools.EC2") 
                    }
                
                    $result.SuccessCount | Should -Be 1
                    $result.FailureCount | Should -Be 0
                }
            
                It "Should respect WhatIf parameter for parent directory removal" {
                    # Arrange
                    $mockModule = New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                        Name       = "AWS.Tools.EC2"
                        Version    = [Version]"4.1.850"
                        ModuleBase = Join-Path $tempPath "TestModules/AWS.Tools.EC2/4.1.850"
                    }
                
                    # Mock Test-Path to indicate parent directory exists
                    Mock Test-Path { return $true } -ParameterFilter { $Path -eq (Join-Path $tempPath "TestModules/AWS.Tools.EC2") }
                
                    # Mock Get-ChildItem to return empty results (empty directory)
                    Mock Get-ChildItem { return $null } -ParameterFilter { $Path -eq (Join-Path $tempPath "TestModules/AWS.Tools.EC2") }
                
                    # Act
                    Remove-ModuleItem -Module $mockModule -WhatIf
                
                    # Assert
                    Should -Not -Invoke Remove-Item
                }
            
                It "Should handle errors during parent directory cleanup" {
                    # Arrange
                    $mockModule = New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                        Name       = "AWS.Tools.EC2"
                        Version    = [Version]"4.1.850"
                        ModuleBase = Join-Path $tempPath "TestModules/AWS.Tools.EC2/4.1.850"
                    }
                
                    # Mock Test-Path to indicate parent directory exists
                    Mock Test-Path { return $true } -ParameterFilter { $Path -eq (Join-Path $tempPath "TestModules/AWS.Tools.EC2") }
                
                    # Mock Get-ChildItem to throw an exception
                    Mock Get-ChildItem { throw "Access denied" } -ParameterFilter { $Path -eq (Join-Path $tempPath "TestModules/AWS.Tools.EC2") }
                
                    # Mock Write-Warning to capture warnings
                    Mock Write-Warning { }
                
                    # Mock Remove-Item and Test-Path for version directory
                    Mock Remove-Item { }
                    Mock Test-Path { return $false } -ParameterFilter { $Path -eq $mockModule.ModuleBase }
                
                    # Act
                    $result = Remove-ModuleItem -Module $mockModule
                
                    # Assert
                    # Should still succeed for the module removal
                    $result.SuccessCount | Should -Be 1
                    $result.FailureCount | Should -Be 0
                
                    # Should have logged a warning
                    Should -Invoke Write-Warning -Times 1
                }
            }
        
            Context "Retry Behavior" {
            It "Should use Invoke-WithRetry for module removal" {
                # Arrange
                $mockModule = New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                    Name       = "AWS.Tools.EC2"
                    Version    = [Version]"4.1.850"
                    ModuleBase = Join-Path $tempPath "TestModules/AWS.Tools.EC2/4.1.850"
                }
                
                # Act
                Remove-ModuleItem -Module $mockModule
                
                # Assert
                Should -Invoke Invoke-WithRetry -Times 1
            }
            
            It "Should use Invoke-WithRetry for parent directory removal" {
                # Arrange
                $mockModule = New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                    Name       = "AWS.Tools.EC2"
                    Version    = [Version]"4.1.850"
                    ModuleBase = Join-Path $tempPath "TestModules/AWS.Tools.EC2/4.1.850"
                }
                
                # Mock Test-Path to indicate parent directory exists
                Mock Test-Path { return $true } -ParameterFilter { $Path -eq (Join-Path $tempPath "TestModules/AWS.Tools.EC2") }
                
                # Mock Get-ChildItem to return empty results (empty directory)
                Mock Get-ChildItem { return $null } -ParameterFilter { $Path -eq (Join-Path $tempPath "TestModules/AWS.Tools.EC2") }
                
                # Act
                Remove-ModuleItem -Module $mockModule
                
                # Assert
                # Should invoke Invoke-WithRetry twice - once for module directory and once for parent directory
                Should -Invoke Invoke-WithRetry -Times 2
                
                # Should invoke Invoke-WithRetry for parent directory with correct operation name
                Should -Invoke Invoke-WithRetry -ParameterFilter { 
                    $OperationName -eq "Remove parent module directory" 
                } -Times 1
            }
            
            It "Should handle transient failures during module removal" {
                # Arrange
                $mockModule = New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                    Name       = "AWS.Tools.EC2"
                    Version    = [Version]"4.1.850"
                    ModuleBase = Join-Path $tempPath "TestModules/AWS.Tools.EC2/4.1.850"
                }
                
                # Mock Test-Path to simulate successful removal
                Mock Test-Path { return $false } -ParameterFilter { $Path -eq $mockModule.ModuleBase }
                
                # No need to mock Invoke-WithRetry again, we're using the mock from BeforeAll
                
                # Act
                $result = Remove-ModuleItem -Module $mockModule
                
                # Assert
                # Should invoke Invoke-WithRetry only once for the module directory removal
                Should -Invoke Invoke-WithRetry -Times 1
                $result.SuccessCount | Should -Be 1
                $result.FailureCount | Should -Be 0
            }
        }
        
        Context "Error Handling" {
                It "Should handle exceptions during module processing" {
                    # Arrange
                    $mockModule = New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                        Name       = "AWS.Tools.EC2"
                        Version    = [Version]"4.1.850"
                        ModuleBase = Join-Path $tempPath "TestModules/AWS.Tools.EC2/4.1.850"
                    }
                
                    # Mock Remove-Item to throw an exception
                    Mock Remove-Item { throw "Access denied" }
                
                    # Act
                    $result = Remove-ModuleItem -Module $mockModule -ErrorAction SilentlyContinue
                
                    # Assert
                    $result.SuccessCount | Should -Be 0
                    $result.FailureCount | Should -Be 1
                    $result.FailedModules | Should -Contain "AWS.Tools.EC2 (4.1.850)"
                }
            
                It "Should handle exceptions with specific error types" {
                    # Arrange
                    $mockModule = New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                        Name       = "AWS.Tools.EC2"
                        Version    = [Version]"4.1.850"
                        ModuleBase = Join-Path $tempPath "TestModules/AWS.Tools.EC2/4.1.850"
                    }
                
                    # Mock Remove-Item to throw specific exceptions
                    Mock Remove-Item { throw [System.UnauthorizedAccessException]::new("Access denied") }
                
                    # Act
                    $result = Remove-ModuleItem -Module $mockModule -ErrorAction SilentlyContinue
                
                    # Assert
                    $result.SuccessCount | Should -Be 0
                    $result.FailureCount | Should -Be 1
                    $result.FailedModules | Should -Contain "AWS.Tools.EC2 (4.1.850)"
                }
            
                It "Should handle invalid module objects" {
                    # Arrange
                    $invalidModule = New-MockObject -Type System.Management.Automation.PSModuleInfo -Properties @{
                        Name       = $null
                        Version    = $null
                        ModuleBase = $null
                    }
                
                    # Act
                    $result = Remove-ModuleItem -Module $invalidModule -ErrorAction SilentlyContinue
                
                    # Assert
                    $result.SuccessCount | Should -Be 0
                    $result.FailureCount | Should -Be 1
                    $result.FailedModules | Should -HaveCount 1
                }
            }
        }
    }
}
