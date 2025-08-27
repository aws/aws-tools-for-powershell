BeforeDiscovery {
    Import-Module (Join-Path -Path $PSScriptRoot -ChildPath "../../modules/Installer/AWS.Tools.Installer.psd1") -Force
}

BeforeAll {
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
    $WarningPreference = 'SilentlyContinue'
    $InformationPreference = 'Ignore'
    
    # Mock module-specific functions with -ModuleName
    Mock -ModuleName AWS.Tools.Installer Get-AWSToolsModule { 
        param($Path, $SkipIfInvalidSignature)
        $modules = @(
            [PSCustomObject]@{ Name = "AWS.Tools.EC2"; Version = [Version]"4.1.850"; ModuleBase = (Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "TestModules/AWS.Tools.EC2/4.1.850") },
            [PSCustomObject]@{ Name = "AWS.Tools.S3"; Version = [Version]"4.1.850"; ModuleBase = (Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "TestModules/AWS.Tools.S3/4.1.850") }
        )
        return $modules
    }
    
    # Mock Install-AWSToolsModule function
    Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModule { }
    
    # Mock Get-PSModulePath function
    Mock -ModuleName AWS.Tools.Installer Get-PSModulePath { 
        param($Scope)
        if ($Scope -eq 'AllUsers') {
            return ([System.IO.Path]::Combine($TestDrive, "AllUsers", "Modules"))
        } else {
            return ([System.IO.Path]::Combine($TestDrive, "CurrentUser", "Modules"))
        }
    }
    
    # Mock the Resolve-AWSToolsVersion function
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

Describe -Tag "Smoke", "Low", "Medium", "High" "Installer - Update-AWSToolsModule Unit Tests" {
    
    Context "Parameter Set Validation" {
        It "Should prevent using Version and SourceZipPath parameters together" {
            # This should throw a parameter set validation error
            $testZipPath = Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip"
            { Update-AWSToolsModule -Version "4.1.0" -SourceZipPath $testZipPath -WhatIf } | 
                Should -Throw -ExpectedMessage "*Parameter set cannot be resolved*"
        }

        It "Should allow Version parameter alone (ManagedCloudFront parameter set)" {
            # Mock the version resolution to avoid network calls
            Mock -ModuleName AWS.Tools.Installer Resolve-AWSToolsVersion { return [Version]"4.1.853" }
            
            # This should not throw a parameter set error (though it may fail for other reasons)
            { Update-AWSToolsModule -Version "4.1.853" -WhatIf } | Should -Not -Throw -Because "Version parameter should be valid in ManagedCloudFront parameter set"
        }

        It "Should allow SourceZipPath parameter alone (SourceZipPath parameter set)" {
            # This should not throw a parameter set error (though it may fail for other reasons like file not found)
            $testZipPath = Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip"
            { Update-AWSToolsModule -SourceZipPath $testZipPath -WhatIf } | Should -Not -Throw -Because "SourceZipPath parameter should be valid in SourceZipPath parameter set"
        }
    }
    
    Context "Parameter Validation" {
        It "Should validate Scope parameter values" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModule { }
            
            # Act & Assert
            { Update-AWSToolsModule -Scope 'InvalidScope' -Confirm:$false } | Should -Throw
            { Update-AWSToolsModule -Scope 'CurrentUser' -Confirm:$false } | Should -Not -Throw
            { Update-AWSToolsModule -Scope 'AllUsers' -Confirm:$false } | Should -Not -Throw
        }
        
        It "Should validate Update-AWSToolsModule parameter combinations" {
            # Act & Assert - These should not throw parameter validation errors
            { Get-Command Update-AWSToolsModule -ParameterName Scope -Confirm:$false } | Should -Not -Throw
            { Get-Command Update-AWSToolsModule -ParameterName Cleanup -Confirm:$false } | Should -Not -Throw
        }
    }
    
    Context "Module Discovery" {
        It "Should get installed AWS.Tools modules" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-AWSToolsModule { 
                @(
                    [PSCustomObject]@{ Name = "AWS.Tools.EC2"; Version = [Version]"4.1.850"; ModuleBase = (Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "TestModules/AWS.Tools.EC2/4.1.850") },
                    [PSCustomObject]@{ Name = "AWS.Tools.S3"; Version = [Version]"4.1.850"; ModuleBase = (Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "TestModules/AWS.Tools.S3/4.1.850") }
                )
            }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModule { }
            
            # Act
            Update-AWSToolsModule -Confirm:$false
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Get-AWSToolsModule -Times 1
        }
        
        It "Should handle no installed modules gracefully" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-AWSToolsModule { $null }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModule { }
            Mock -ModuleName AWS.Tools.Installer Write-Host { }
            
            # Act
            Update-AWSToolsModule -Confirm:$false
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Get-AWSToolsModule -Times 1
            Should -Invoke -ModuleName AWS.Tools.Installer Write-Host -ParameterFilter { 
                $Object -like "*No AWS.Tools modules found to update*" 
            } -Times 1
            Should -Not -Invoke -ModuleName AWS.Tools.Installer Install-AWSToolsModule
        }
        
        It "Should get unique module names without regard for version" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-AWSToolsModule { 
                @(
                    [PSCustomObject]@{ Name = "AWS.Tools.EC2"; Version = [Version]"4.1.850"; ModuleBase = (Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "TestModules/AWS.Tools.EC2/4.1.850") },
                    [PSCustomObject]@{ Name = "AWS.Tools.EC2"; Version = [Version]"4.1.800"; ModuleBase = (Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "TestModules/AWS.Tools.EC2/4.1.800") },
                    [PSCustomObject]@{ Name = "AWS.Tools.S3"; Version = [Version]"4.1.850"; ModuleBase = (Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "TestModules/AWS.Tools.S3/4.1.850") }
                )
            }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModule { }
            Mock -ModuleName AWS.Tools.Installer Write-Host { }
            
            # Act
            Update-AWSToolsModule -Confirm:$false
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Install-AWSToolsModule -ParameterFilter { 
                $Name.Count -eq 2 -and 
                $Name -contains "AWS.Tools.EC2" -and 
                $Name -contains "AWS.Tools.S3"
            } -Times 1
            Should -Invoke -ModuleName AWS.Tools.Installer Write-Host -ParameterFilter { 
                $Object -like "Updating 2 installed AWS.Tools modules*" 
            } -Times 1
        }
    }
    
    Context "Parameter Forwarding" {
        It "Should forward Version parameter to Install-AWSToolsModule" {
            # Arrange
            $version = "4.1.853"
            Mock -ModuleName AWS.Tools.Installer Get-AWSToolsModule { 
                @(
                    [PSCustomObject]@{ Name = "AWS.Tools.EC2"; Version = [Version]"4.1.850"; ModuleBase = (Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "TestModules/AWS.Tools.EC2/4.1.850") }
                )
            }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModule { }
            
            # Act
            Update-AWSToolsModule -Version $version -Confirm:$false
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Install-AWSToolsModule -ParameterFilter { 
                $Version -eq $version
            } -Times 1
        }
        
        It "Should forward Cleanup parameter to Install-AWSToolsModule" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-AWSToolsModule { 
                @(
                    [PSCustomObject]@{ Name = "AWS.Tools.EC2"; Version = [Version]"4.1.850"; ModuleBase = (Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "TestModules/AWS.Tools.EC2/4.1.850") }
                )
            }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModule { }
            
            # Act
            Update-AWSToolsModule -Cleanup -Confirm:$false
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Install-AWSToolsModule -ParameterFilter { 
                $Cleanup -eq $true
            } -Times 1
        }
        
        It "Should forward CleanUpLegacyModuleScope parameter to Install-AWSToolsModule" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-AWSToolsModule { 
                @(
                    [PSCustomObject]@{ Name = "AWS.Tools.EC2"; Version = [Version]"4.1.850"; ModuleBase = (Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "TestModules/AWS.Tools.EC2/4.1.850") }
                )
            }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModule { }
            
            # Act
            Update-AWSToolsModule -CleanUpLegacyModuleScope CurrentUser -Confirm:$false
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Install-AWSToolsModule -ParameterFilter { 
                $CleanUpLegacyModuleScope -eq "CurrentUser"
            } -Times 1
        }
        
        It "Should forward Scope parameter to Install-AWSToolsModule" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-AWSToolsModule { 
                @(
                    [PSCustomObject]@{ Name = "AWS.Tools.EC2"; Version = [Version]"4.1.850"; ModuleBase = (Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "TestModules/AWS.Tools.EC2/4.1.850") }
                )
            }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModule { }
            
            # Act
            Update-AWSToolsModule -Scope AllUsers -Confirm:$false
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Install-AWSToolsModule -ParameterFilter { 
                $Scope -eq "AllUsers"
            } -Times 1
        }
        
        It "Should forward Path parameter to Install-AWSToolsModule" {
            # Arrange
            $customPath = Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "CustomPath"
            Mock -ModuleName AWS.Tools.Installer Get-AWSToolsModule { 
                @(
                    [PSCustomObject]@{ Name = "AWS.Tools.EC2"; Version = [Version]"4.1.850"; ModuleBase = (Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "TestModules/AWS.Tools.EC2/4.1.850") }
                )
            }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModule { }
            
            # Act
            Update-AWSToolsModule -Path $customPath -Confirm:$false
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Get-AWSToolsModule -ParameterFilter { 
                $Path -eq $customPath
            } -Times 1
            Should -Invoke -ModuleName AWS.Tools.Installer Install-AWSToolsModule -ParameterFilter { 
                $Path -eq $customPath
            } -Times 1
        }
        
        It "Should forward Force parameter to Install-AWSToolsModule" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-AWSToolsModule { 
                @(
                    [PSCustomObject]@{ Name = "AWS.Tools.EC2"; Version = [Version]"4.1.850"; ModuleBase = (Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "TestModules/AWS.Tools.EC2/4.1.850") }
                )
            }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModule { }
            
            # Act
            Update-AWSToolsModule -Force -Confirm:$false
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Install-AWSToolsModule -ParameterFilter { 
                $Force -eq $true
            } -Times 1
        }
        
        It "Should forward Timeout parameter to Install-AWSToolsModule" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-AWSToolsModule { 
                @(
                    [PSCustomObject]@{ Name = "AWS.Tools.EC2"; Version = [Version]"4.1.850"; ModuleBase = (Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "TestModules/AWS.Tools.EC2/4.1.850") }
                )
            }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModule { }
            
            # Act
            Update-AWSToolsModule -Timeout 600 -Confirm:$false
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Install-AWSToolsModule -ParameterFilter { 
                $Timeout -eq 600
            } -Times 1
        }
        
        It "Should forward SourceZipPath parameter to Install-AWSToolsModule" {
            # Arrange
            $testZipPath = Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip"
            Mock -ModuleName AWS.Tools.Installer Get-AWSToolsModule { 
                @(
                    [PSCustomObject]@{ Name = "AWS.Tools.EC2"; Version = [Version]"4.1.850"; ModuleBase = (Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "TestModules/AWS.Tools.EC2/4.1.850") }
                )
            }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModule { }
            
            # Act
            Update-AWSToolsModule -SourceZipPath $testZipPath -Confirm:$false
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Install-AWSToolsModule -ParameterFilter { 
                $SourceZipPath -eq $testZipPath
            } -Times 1
        }
        
        It "Should forward SourceHashPath parameter to Install-AWSToolsModule" {
            # Arrange
            $testZipPath = Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip"
            $testHashPath = Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip.sha512"
            Mock -ModuleName AWS.Tools.Installer Get-AWSToolsModule { 
                @(
                    [PSCustomObject]@{ Name = "AWS.Tools.EC2"; Version = [Version]"4.1.850"; ModuleBase = (Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "TestModules/AWS.Tools.EC2/4.1.850") }
                )
            }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModule { }
            
            # Act
            Update-AWSToolsModule -SourceZipPath $testZipPath -SourceHashPath $testHashPath -Confirm:$false
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Install-AWSToolsModule -ParameterFilter { 
                $SourceZipPath -eq $testZipPath -and $SourceHashPath -eq $testHashPath
            } -Times 1
        }
        
        It "Should forward SkipIntegrityCheck parameter to Install-AWSToolsModule" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-AWSToolsModule { 
                @(
                    [PSCustomObject]@{ Name = "AWS.Tools.EC2"; Version = [Version]"4.1.850"; ModuleBase = (Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "TestModules/AWS.Tools.EC2/4.1.850") }
                )
            }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModule { }
            
            # Act
            Update-AWSToolsModule -SkipIntegrityCheck -Confirm:$false
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Install-AWSToolsModule -ParameterFilter { 
                $SkipIntegrityCheck -eq $true
            } -Times 1
        }
    }
    
    Context "Error Handling" {
        It "Should treat errors as terminating" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-AWSToolsModule { throw "Error getting modules" }
            
            # Act & Assert
            { Update-AWSToolsModule -Confirm:$false } | Should -Throw "*Error getting modules*"
        }
    }
    
    Context "ShouldProcess Support" {
        It "Should support WhatIf without executing actual changes" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-AWSToolsModule { 
                @(
                    [PSCustomObject]@{ Name = "AWS.Tools.EC2"; Version = [Version]"4.1.850"; ModuleBase = (Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "TestModules/AWS.Tools.EC2/4.1.850") }
                )
            }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModule { }
            Mock -ModuleName AWS.Tools.Installer Write-Host { }
            
            # Act
            Update-AWSToolsModule -WhatIf -Confirm:$false
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Get-AWSToolsModule -Times 1
            Should -Invoke -ModuleName AWS.Tools.Installer Write-Host -ParameterFilter { 
                $Object -like "*What if: Would update*" 
            } -Times 1
            Should -Invoke -ModuleName AWS.Tools.Installer Install-AWSToolsModule -ParameterFilter {
                $WhatIf -eq $true
            } -Times 1
        }
        
        It "Should pass WhatIf to Install-AWSToolsModule" {
            # Arrange
            Mock -ModuleName AWS.Tools.Installer Get-AWSToolsModule { 
                @(
                    [PSCustomObject]@{ Name = "AWS.Tools.EC2"; Version = [Version]"4.1.850"; ModuleBase = (Join-Path -Path ([System.IO.Path]::GetTempPath()) -ChildPath "TestModules/AWS.Tools.EC2/4.1.850") }
                )
            }
            Mock -ModuleName AWS.Tools.Installer Install-AWSToolsModule { }
            
            # Act
            Update-AWSToolsModule -WhatIf
            
            # Assert
            Should -Invoke -ModuleName AWS.Tools.Installer Install-AWSToolsModule -ParameterFilter { 
                $WhatIf -eq $true
            } -Times 1  # Should be called with WhatIf
        }
    }
}
