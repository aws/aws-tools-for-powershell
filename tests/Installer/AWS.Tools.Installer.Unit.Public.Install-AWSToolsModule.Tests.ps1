BeforeDiscovery {
    . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")
}

BeforeAll {
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
    
    # Mock module-specific functions with -ModuleName
    Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { 
        param($Path, $SkipIfInvalidSignature)
        $modules = @([PSCustomObject]@{ Name = "AWS.Tools.EC2"; Version = [Version]"4.1.850"; ModuleBase = (Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "TestModules/AWS.Tools.EC2/4.1.850") })
        return $modules
    }
    
    Mock -ModuleName AWS.Tools.Installer Get-PSModulePath {
        param($Scope)
        if ($Scope -eq 'AllUsers') {
            return ([System.IO.Path]::Combine($TestDrive, "AllUsers", "Modules"))
        } else {
            return ([System.IO.Path]::Combine($TestDrive, "CurrentUser", "Modules"))
        }
    }
    Mock -ModuleName AWS.Tools.Installer Get-AWSToolsZip { }
    
    # Mock the new Resolve-AWSToolsVersion function
    Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsVersion { 
        param($Version, $Timeout)
        if ($Version -eq "4.*") {
            return [Version]"4.1.754"
        } elseif ($Version -eq "5.*") {
            return [Version]"5.2.100"
        } elseif ($Version -and $Version.Trim() -ne '') {
            return [Version]$Version
        } else {
            return $null
        }
    }

}

Describe -Skip:$SkipInstallerTests -Tag "Smoke", "Low", "Medium", "High" "Installer - Install-AWSToolsModule Unit Tests" {
    
    Context "Parameter Set Validation" {
        It "Should prevent using Version and SourceZipPath parameters together" {
            # This should throw a parameter set validation error
            $testZipPath = Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip"
            { Install-AWSToolsModule -Version "4.1.0" -SourceZipPath $testZipPath -WarningAction SilentlyContinue @script:InformationActionSplat } | 
                Should -Throw -ExpectedMessage "*Parameter set cannot be resolved*"
        }

        It "Should allow Version parameter alone (ManagedCloudFront parameter set)" {
            # Add comprehensive mocking within the It block
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { @{ Version = "4.1.853"; Modules = @() } }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }

            # This should not throw a parameter set error (though it may fail for other reasons)
            { Install-AWSToolsModule -Version "4.1.853" -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw -Because "Version parameter should be valid in ManagedCloudFront parameter set"
        }

        It "Should allow SourceZipPath parameter alone (SourceZipPath parameter set)" {
            # Add comprehensive mocking within the It block
            $testZipPath = Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip"
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { $testZipPath }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { @{ Version = "4.1.853"; Modules = @() } }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }

            # This should not throw a parameter set error (though it may fail for other reasons like file not found)
            { Install-AWSToolsModule -SourceZipPath $testZipPath -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw -Because "SourceZipPath parameter should be valid in SourceZipPath parameter set"
        }
    }
    
    Context "Parameter Validation" {
        It "Should accept valid module names with AWS.Tools prefix" {
            # Arrange
            $validNames = @('AWS.Tools.EC2', 'AWS.Tools.S3')
            Mock -ModuleName AWS.Tools.Installer Get-ChildItem { 
                @(
                    [PSCustomObject]@{ Name = "AWS.Tools.EC2"; FullName = (Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "Test/AWS.Tools.EC2") },
                    [PSCustomObject]@{ Name = "AWS.Tools.S3"; FullName = (Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "Test/AWS.Tools.S3") }
                )
            } -ParameterFilter { $Directory }
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { 
                @{
                    Version = "4.1.853"
                    Modules = @(
                        @{ Name = "AWS.Tools.EC2"; Version = "4.1.853" }
                        @{ Name = "AWS.Tools.S3"; Version = "4.1.853" }
                    )
                }
            }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act & Assert
            { Install-AWSToolsModule -Name $validNames -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat} | Should -Not -Throw
        }
        
        It "Should automatically include AWS.Tools.Common when specific modules are requested" {
            # Arrange
            $validNames = @('AWS.Tools.EC2', 'AWS.Tools.S3')
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsModuleNames { 
                @('AWS.Tools.Common', 'AWS.Tools.EC2', 'AWS.Tools.S3')
            } -ParameterFilter { $Name -contains 'AWS.Tools.EC2' -and $Name -contains 'AWS.Tools.S3' }
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { @{ Version = "4.1.853"; Modules = @() } }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act
            Install-AWSToolsModule -Name $validNames -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Resolve-AWSToolsModuleNames -Times 1
            Should -Invoke -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip -ParameterFilter { 
                $ModuleNames -contains 'AWS.Tools.Common' -and 
                $ModuleNames -contains 'AWS.Tools.EC2' -and 
                $ModuleNames -contains 'AWS.Tools.S3'
            } -Times 1
        }
        
        It "Should accept valid module names without AWS.Tools prefix" {
            # Arrange
            $validNames = @('EC2', 'S3')
            Mock -ModuleName AWS.Tools.Installer Get-ChildItem { 
                @(
                    [PSCustomObject]@{ Name = "AWS.Tools.EC2"; FullName = (Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "Test/AWS.Tools.EC2") },
                    [PSCustomObject]@{ Name = "AWS.Tools.S3"; FullName = (Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "Test/AWS.Tools.S3") }
                )
            } -ParameterFilter { $Directory }
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { @{ Version = "4.1.853"; Modules = @() } }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act & Assert
            { Install-AWSToolsModule -Name $validNames  -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat} | Should -Not -Throw
        }
        
        It "Should throw error for invalid module names" {
            # Arrange
            $invalidNames = @('InvalidModule')
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsModuleNames { throw "None of the specified modules were found in the zip file: InvalidModule" }
            
            # Act & Assert
            { Install-AWSToolsModule -Name $invalidNames  -Confirm:$false} | Should -Throw "*None of the specified modules were found*"
        }
        
        It "Should validate Scope parameter values" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { @{ Version = "4.1.853"; Modules = @() } }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act & Assert
            { Install-AWSToolsModule -Scope 'InvalidScope' -Confirm:$false } | Should -Throw
            { Install-AWSToolsModule -Scope 'CurrentUser' -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
            { Install-AWSToolsModule -Scope 'AllUsers' -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
        }
        
        It "Should validate Install-AWSToolsModule parameter combinations" {
            # Act & Assert - These should not throw parameter validation errors
            { Get-Command Install-AWSToolsModule -ParameterName Scope -Confirm:$false } | Should -Not -Throw
            { Get-Command Install-AWSToolsModule -ParameterName Cleanup -Confirm:$false } | Should -Not -Throw
        }
        
        It "Should validate Uninstall-AWSToolsModule scope parameters" {
            # Act & Assert - These should not throw parameter validation errors
            { Get-Command Uninstall-AWSToolsModule -ParameterName Scope -Confirm:$false } | Should -Not -Throw
        }
        
        It "Should validate Uninstall-AWSToolsModule version parameters" {
            # Act & Assert - These should not throw parameter validation errors
            { Get-Command Uninstall-AWSToolsModule -ParameterName Version -Confirm:$false } | Should -Not -Throw
            { Get-Command Uninstall-AWSToolsModule -ParameterName ExceptVersion -Confirm:$false } | Should -Not -Throw
        }
    }
    
    Context "URL Construction" {
        It "Should call Resolve-AWSToolsZipSource for latest version" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { @{ Version = "4.1.853"; Modules = @() } }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act
            Install-AWSToolsModule -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource -Times 1
        }
        
        It "Should call Resolve-AWSToolsZipSource with specific version" {
            # Arrange
            $version = [Version]"4.1.853.0"
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { @{ Version = "4.1.853"; Modules = @() } }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act
            Install-AWSToolsModule -Version $version  -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource -Times 1 -ParameterFilter { $Version -eq $version }
        }
    }
    
    Context "Module Extraction Method" {
        # Mock the Install-AWSToolsModuleFromZip function to capture how it's called
        BeforeEach {
            # Create a mock implementation of Install-AWSToolsModuleFromZip that records how it was called
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip {
                param($Name, $ZipPath, $ModuleNames, $TargetPath)
                
                # Return structured format to simulate successful installation
                return @{
                    Version = "4.1.853"
                    Modules = @()
                }
            }
        }
        
        It "Should pass specific modules to Install-AWSToolsModuleFromZip when Name parameter is used" {
            # Arrange
            $validNames = @('AWS.Tools.EC2', 'AWS.Tools.S3')
            $resolvedNames = @('AWS.Tools.Common', 'AWS.Tools.EC2', 'AWS.Tools.S3')
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsModuleNames { 
                return $resolvedNames
            } -ParameterFilter { $Name -contains 'AWS.Tools.EC2' -and $Name -contains 'AWS.Tools.S3' }
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act
            Install-AWSToolsModule -Name $validNames -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip -ParameterFilter {
                $ModuleNames -contains 'AWS.Tools.Common' -and 
                $ModuleNames -contains 'AWS.Tools.EC2' -and 
                $ModuleNames -contains 'AWS.Tools.S3'
            } -Times 1
        }
        
        It "Should not pass specific modules to Install-AWSToolsModuleFromZip when Name parameter is not used" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act
            Install-AWSToolsModule -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip -ParameterFilter {
                $null -eq $ModuleNames -or $ModuleNames.Count -eq 0
            } -Times 1
        }
    }
    
    Context "Local Source File" {
        It "Should use local zip file when SourceZipPath is provided" {
            # Arrange
            $testZipPath = Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "TestZip.zip"
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { $testZipPath }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { @{ Version = "4.1.853"; Modules = @() } }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act
            Install-AWSToolsModule -SourceZipPath $testZipPath  -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource -ParameterFilter { $SourceZipPath -eq $testZipPath } -Times 1
            Should -Invoke -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip -Times 1
        }
        
        It "Should throw error when local zip file does not exist" {
            # Arrange
            $nonExistentPath = Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "NonExistent.zip"
            Mock -ModuleName AWS.Tools.Installer Test-Path { $false } -ParameterFilter { $Path -eq $nonExistentPath }
            Mock -ModuleName AWS.Tools.Installer Expand-Archive { throw "Cannot find path '$nonExistentPath'" }
            
            # Act & Assert
            { Install-AWSToolsModule -SourceZipPath $nonExistentPath  -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat} | Should -Throw
        }
        
        It "Should skip installation if version already exists without Force" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsVersion { return [Version]"5.0.154" }
            Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { 
                return [PSCustomObject]@{
                    Name = 'AWS.Tools.Common'
                    Version = [Version]"5.0.154"
                }
            }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { }
            
            # Act
            Install-AWSToolsModule -Version "5.0.154" -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule -ParameterFilter {
                $Name -eq 'AWS.Tools'
            }
            Should -Not -Invoke -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip
        }
        
        It "Should install if version already exists with Force" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { @{ Version = "4.1.853"; Modules = @() } }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act
            Install-AWSToolsModule -Force -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip -Times 1
        }
        
        It "Should test Path parameter functionality" {
            # Arrange
            $customPath = Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "CustomPath"
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsVersion { return [Version]"4.1.853" }
            Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { return $null }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { @{ Version = "4.1.853"; Modules = @() } }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act
            Install-AWSToolsModule -Path $customPath -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule -ParameterFilter { $Path -eq $customPath }
        }
        
        It "Should support WhatIf without executing" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act
            Install-AWSToolsModule -WhatIf -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
            
            # Assert
            Should -Not -Invoke -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip
            Should -Not -Invoke -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule
        }
        
        It "Should handle empty version parameter without error" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { @{ Version = "5.1.0"; Modules = @() } }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act & Assert - Should not throw version conversion error
            { Install-AWSToolsModule -Version "" -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
        }
        
        It "Should pass custom timeout to download functions" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsVersion { return [Version]"4.1.853" }
            Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { return $null }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { @{ Version = "4.1.853"; Modules = @() } }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act
            Install-AWSToolsModule -Timeout 600 -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource -ParameterFilter { $Timeout -eq 600 } -Times 1
        }
        
        It "Should resolve wildcard versions to actual versions" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsVersion { [Version]"4.1.754" } -ParameterFilter { $Version -eq "4.*" }
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { @{ Version = "4.1.754"; Modules = @() } }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act
            Install-AWSToolsModule -Version "4.*" -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Resolve-AWSToolsVersion -ParameterFilter { $Version -eq "4.*" } -Times 1
        }
    }
    
    Context "Error Handling" {
        It "Should treat installation errors as terminating" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { throw "Network error during download" }
            
            # Act & Assert - Installation error should terminate
            { Install-AWSToolsModule -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Throw "*Network error during download*"
        }
        
        It "Should treat cleanup errors as non-terminating errors" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { 
                @{ 
                    Version = "4.1.853"
                    Modules = @(
                        @{ Name = "AWS.Tools.Common"; Version = "4.1.853" }
                    )
                }
            }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { throw "Access denied during cleanup" }
            Mock -ModuleName AWS.Tools.Installer Write-Error { }
            
            # Act & Assert - Cleanup error should not terminate, but should write error
            { Install-AWSToolsModule -Cleanup -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
            Should -Invoke -ModuleName AWS.Tools.Installer Write-Error -ParameterFilter { 
                $Message -like "*Failed to clean up previous AWS Tools versions*" 
            } -Times 1
        }
        
        It "Should treat legacy cleanup errors as non-terminating errors" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { @{ Version = "4.1.853"; Modules = @() } }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { 
                # Always throw to simulate legacy cleanup failure
                throw "Access denied during legacy cleanup"
            }
            Mock -ModuleName AWS.Tools.Installer Write-Error { }
            
            # Act & Assert - Legacy cleanup error should not terminate, but should write error
            { Install-AWSToolsModule -CleanUpLegacyModuleScope CurrentUser -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
            Should -Invoke -ModuleName AWS.Tools.Installer Write-Error -ParameterFilter { 
                $Message -like "*Failed to clean up legacy AWSPowerShell modules*" 
            } -Times 1
        }
        
        It "Should continue installation even when cleanup fails" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { 
                @{ 
                    Version = "4.1.853"
                    Modules = @(
                        @{ Name = "AWS.Tools.Common"; Version = "4.1.853" }
                    )
                }
            }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { throw "Cleanup failed" }
            Mock -ModuleName AWS.Tools.Installer Write-Error { }
            
            # Act
            Install-AWSToolsModule -Cleanup -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
            
            # Assert - Installation should complete successfully despite cleanup failure
            Should -Invoke -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip -Times 1
            Should -Invoke -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule -Times 1
            Should -Invoke -ModuleName AWS.Tools.Installer Write-Error -Times 1
        }
        
        It "Should handle installation errors from Install-AWSToolsModuleFromZip as terminating" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { throw "Failed to extract modules" }
            
            # Act & Assert - Installation error should terminate
            { Install-AWSToolsModule -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Throw "*Failed to extract modules*"
        }
    }
    
    Context "Installer Exclusion" {
        It "Should reject AWS.Tools.Installer module name" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsModuleNames { throw "AWS.Tools.Installer cannot be installed using Install-AWSToolsModule. Use Install-AWSToolsInstaller instead." }
            
            # Act & Assert
            { Install-AWSToolsModule -Name @('AWS.Tools.Installer') -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Throw "*AWS.Tools.Installer cannot be installed using Install-AWSToolsModule*"
        }
        
        It "Should reject AWS.Tools.Installer with short name" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsModuleNames { throw "AWS.Tools.Installer cannot be installed using Install-AWSToolsModule. Use Install-AWSToolsInstaller instead." }
            
            # Act & Assert
            { Install-AWSToolsModule -Name @('Installer') -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Throw "*AWS.Tools.Installer cannot be installed using Install-AWSToolsModule*"
        }
        
        It "Should reject AWS.Tools.Installer mixed with valid modules" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsModuleNames { throw "AWS.Tools.Installer cannot be installed using Install-AWSToolsModule. Use Install-AWSToolsInstaller instead." }
            
            # Act & Assert
            { Install-AWSToolsModule -Name @('S3', 'AWS.Tools.Installer', 'EC2') -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Throw "*AWS.Tools.Installer cannot be installed using Install-AWSToolsModule*"
        }
        
        It "Should provide helpful error message for installer exclusion" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsModuleNames { throw "AWS.Tools.Installer cannot be installed using Install-AWSToolsModule. Use Install-AWSToolsInstaller instead." }
            
            # Act & Assert
            { Install-AWSToolsModule -Name @('AWS.Tools.Installer') -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Throw "*Use Install-AWSToolsInstaller instead*"
        }
    }
    
    Context "Default Cleanup Behavior" {
        It "Should not perform cleanup when -Cleanup parameter is not specified" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { @{ Version = "4.1.853"; Modules = @() } }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act
            Install-AWSToolsModule -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
            
            # Assert
            Should -Not -Invoke -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule
        }
        
        It "Should perform cleanup when -Cleanup parameter is specified" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { 
                @{ 
                    Version = "4.1.853"
                    Modules = @(
                        @{ Name = "AWS.Tools.Common"; Version = "4.1.853" }
                    )
                }
            }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act
            Install-AWSToolsModule -Cleanup -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule -Times 1
        }
        
        It "Should not accept -SkipCleanup parameter" {
            # Act & Assert
            { Install-AWSToolsModule -SkipCleanup -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat} | Should -Throw
        }
    }
    
    Context "Prerelease and Legacy Parameter Set Mutual Exclusivity" {
        It "Should prevent using Prerelease with MinimumVersion" {
            # Act & Assert - Parameter set validation should prevent this combination
            { Install-AWSToolsModule -Version "5.0.0-preview001" -Prerelease -MinimumVersion ([Version]"5.0.0") -Confirm:$false } | 
                Should -Throw -ExpectedMessage "*Parameter set cannot be resolved*"
        }
        
        It "Should prevent using Prerelease with MaximumVersion" {
            # Act & Assert - Parameter set validation should prevent this combination
            { Install-AWSToolsModule -Version "5.0.0-preview001" -Prerelease -MaximumVersion ([Version]"5.1.0") -Confirm:$false } | 
                Should -Throw -ExpectedMessage "*Parameter set cannot be resolved*"
        }
        
        It "Should prevent using Prerelease with both MinimumVersion and MaximumVersion" {
            # Act & Assert - Parameter set validation should prevent this combination
            { Install-AWSToolsModule -Version "5.0.0-preview001" -Prerelease -MinimumVersion ([Version]"5.0.0") -MaximumVersion ([Version]"5.1.0") -Confirm:$false } | 
                Should -Throw -ExpectedMessage "*Parameter set cannot be resolved*"
        }
        
        It "Should allow Prerelease with Version alone (ManagedCloudFront parameter set)" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsVersion { 
                return [PSCustomObject]@{ 
                    Major = 5
                    Minor = 0
                    Build = 0
                    SemVerString = "5.0.0-preview001"
                }
            }
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { @{ Version = "5.0.0-preview001"; Modules = @() } }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act & Assert - Should not throw parameter set errors
            { Install-AWSToolsModule -Version "5.0.0-preview001" -Prerelease -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | 
                Should -Not -Throw
        }
        
        It "Should allow MinimumVersion and MaximumVersion together without Prerelease (Legacy parameter set)" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsVersion { return [Version]"5.0.100" }
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { @{ Version = "5.0.100"; Modules = @() } }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act & Assert - Should not throw parameter set errors
            { Install-AWSToolsModule -MinimumVersion ([Version]"5.0.0") -MaximumVersion ([Version]"5.1.0") -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | 
                Should -Not -Throw
        }
    }
    
    Context "Wildcard Version Regression Tests" {
        It "Should not throw [Version] conversion error when using wildcard version 5.*" {
            # Arrange - Mock network operations but allow cleanup section to execute
            Mock -ModuleName AWS.Tools.Installer Invoke-WebRequestWithStatusHandling { 
                return [PSCustomObject]@{
                    Success = $true
                    StatusCode = 200
                    RawResponse = [PSCustomObject]@{
                        Headers = @{
                            'Content-Disposition' = "attachment; filename=AWS.Tools.5.0.148.zip"
                        }
                    }
                }
            }
            Mock -ModuleName AWS.Tools.Installer Invoke-WithRetry { 
                param($ScriptBlock)
                & $ScriptBlock
            }
            Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { @() }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { 
                @{ 
                    Version = "5.0.148"
                    Modules = @(
                        @{ Name = "AWS.Tools.Common"; Version = "5.0.148" }
                    )
                }
            }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act & Assert - Should NOT throw "Cannot convert value "5.*" to type "System.Version""
            { Install-AWSToolsModule -Version "5.*" -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | 
                Should -Not -Throw -Because "Wildcard version strings should not trigger [Version] conversion errors"
        }
        
        It "Should not throw [Version] conversion error when using wildcard version 4.*" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Invoke-WebRequestWithStatusHandling { 
                return [PSCustomObject]@{
                    Success = $true
                    StatusCode = 200
                    RawResponse = [PSCustomObject]@{
                        Headers = @{
                            'Content-Disposition' = "attachment; filename=AWS.Tools.4.1.754.zip"
                        }
                    }
                }
            }
            Mock -ModuleName AWS.Tools.Installer Invoke-WithRetry { 
                param($ScriptBlock)
                & $ScriptBlock
            }
            Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { @() }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { 
                @{ 
                    Version = "4.1.754"
                    Modules = @(
                        @{ Name = "AWS.Tools.Common"; Version = "4.1.754" }
                    )
                }
            }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act & Assert
            { Install-AWSToolsModule -Version "4.*" -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | 
                Should -Not -Throw -Because "Wildcard version strings should not trigger [Version] conversion errors"
        }
        
        It "Should not throw [Version] conversion error when using wildcard with -Cleanup" {
            # Arrange - This specifically tests the cleanup section where the bug occurs
            Mock -ModuleName AWS.Tools.Installer Invoke-WebRequestWithStatusHandling { 
                return [PSCustomObject]@{
                    Success = $true
                    StatusCode = 200
                    RawResponse = [PSCustomObject]@{
                        Headers = @{
                            'Content-Disposition' = "attachment; filename=AWS.Tools.5.0.148.zip"
                        }
                    }
                }
            }
            Mock -ModuleName AWS.Tools.Installer Invoke-WithRetry { 
                param($ScriptBlock)
                & $ScriptBlock
            }
            Mock -ModuleName AWS.Tools.Installer Get-InstalledAWSToolsModule { @() }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { 
                @{ 
                    Version = "5.0.148"
                    Modules = @(
                        @{ Name = "AWS.Tools.Common"; Version = "5.0.148" }
                    )
                }
            }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act & Assert - The -Cleanup parameter exercises the cleanup section where $Version.PSObject.Properties is accessed
            { Install-AWSToolsModule -Version "5.*" -Cleanup -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | 
                Should -Not -Throw -Because "Wildcard versions with -Cleanup should not cause [Version] conversion errors in cleanup section"
        }
    }
    
    Context "MinimumVersion and MaximumVersion Parameter Validation" {
        It "Should allow Version and MinimumVersion to be used together when Version >= MinimumVersion" {
            # Arrange - Mock all dependencies
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsVersion { return [Version]"4.1.0" }
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { @{ Version = "4.1.0"; Modules = @() } }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act & Assert - Should not throw parameter validation errors (1.0.3 compatible)
            { Install-AWSToolsModule -Version "4.1.0" -MinimumVersion ([Version]"4.0.0") -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | 
                Should -Not -Throw
        }
        
        It "Should allow Version and MaximumVersion to be used together when Version <= MaximumVersion" {
            # Arrange - Mock all dependencies
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsVersion { return [Version]"4.1.0" }
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { @{ Version = "4.1.0"; Modules = @() } }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act & Assert - Should not throw parameter validation errors (1.0.3 compatible)
            { Install-AWSToolsModule -Version "4.1.0" -MaximumVersion ([Version]"5.0.0") -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | 
                Should -Not -Throw
        }
        
        It "Should throw error when Version is less than MinimumVersion" {
            # Act & Assert - Parameter validation should occur in Begin block
            { Install-AWSToolsModule -Version "4.0.0" -MinimumVersion ([Version]"4.1.0") -Confirm:$false  -WarningAction SilentlyContinue @script:InformationActionSplat} | 
                Should -Throw "*Parameter MinimumVersion*cannot be greater than Version*"
        }
        
        It "Should throw error when Version is greater than MaximumVersion" {
            # Act & Assert - Parameter validation should occur in Begin block
            { Install-AWSToolsModule -Version "5.0.0" -MaximumVersion ([Version]"4.1.0") -Confirm:$false  -WarningAction SilentlyContinue @script:InformationActionSplat} | 
                Should -Throw "*Parameter MaximumVersion*cannot be less than Version*"
        }
        
        It "Should throw error when MinimumVersion is greater than MaximumVersion" {
            # Act & Assert - Parameter validation should occur in Begin block
            { Install-AWSToolsModule -MinimumVersion ([Version]"5.0.0") -MaximumVersion ([Version]"4.0.0") -Confirm:$false  -WarningAction SilentlyContinue @script:InformationActionSplat} | 
                Should -Throw "*Parameter MinimumVersion*cannot be greater than MaximumVersion*"
        }
        
        It "Should accept MinimumVersion parameter alone" {
            # Arrange - Mock all dependencies
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsVersion { return [Version]"4.1.853" }
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { @{ Version = "4.1.853"; Modules = @() } }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act & Assert - Should not throw parameter validation errors
            { Install-AWSToolsModule -MinimumVersion ([Version]"4.0.0") -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
        }
        
        It "Should accept MaximumVersion parameter alone" {
            # Arrange - Mock all dependencies  
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsVersion { return [Version]"4.1.853" }
            Mock -ModuleName AWS.Tools.Installer Test-AWSToolsVersionInstalled { $false }
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsZipSource { "AWS.Tools.zip" }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModuleFromZip { @{ Version = "4.1.853"; Modules = @() } }
            Mock -ModuleName AWS.Tools.Installer Uninstall-AWSToolsModule { }
            
            # Act & Assert - Should not throw parameter validation errors
            { Install-AWSToolsModule -MaximumVersion ([Version]"5.0.0") -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
        }
    }
}
