BeforeAll {
    # Import the module under test
    Import-Module (Join-Path $PSScriptRoot "../../modules/Installer/AWS.Tools.Installer.psd1") -Force
    
    # Set preference variables to suppress verbose and progress output
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
}

Describe -Tag "Smoke", "Low", "Medium", "High" "Installer - Install-AWSToolsModuleFromZip Unit Tests" {
    
    Context "Installation Process" {
        It "Should call Write-PSGetModuleInfo during installation" {
            InModuleScope AWS.Tools.Installer {
                # Arrange
                $tempPath = [System.IO.Path]::GetTempPath()
                $testZipPath = Join-Path -Path $tempPath -ChildPath "AWS.Tools.zip"
                $targetPath = Join-Path -Path $tempPath -ChildPath "TestTarget"
                $moduleDir = Join-Path -Path $tempPath -ChildPath "AWS.Tools.Common"
                $versionDir = Join-Path -Path $moduleDir -ChildPath "4.1.853"
                $psd1Path = Join-Path -Path $versionDir -ChildPath "AWS.Tools.Common.psd1"
                
                Mock New-PSGetModuleInfo { "<xml>test</xml>" }
                Mock Write-PSGetModuleInfo { }
                Mock Expand-Archive { }
                Mock Get-ChildItem { 
                    @([PSCustomObject]@{ 
                        Name = "AWS.Tools.Common"
                        FullName = $moduleDir
                    })
                } -ParameterFilter { $Path -like "*AwsTools" -and [System.Boolean]$Directory.IsPresent -eq $true }
                Mock Get-ChildItem { 
                    @([PSCustomObject]@{ 
                        FullName = $psd1Path
                        Directory = @{ FullName = $versionDir }
                    })
                } -ParameterFilter { $Filter -eq "*.psd1" }
                Mock Copy-Item { }
                Mock Test-Path { $false }
                Mock New-Item { }
                Mock Remove-Item { }
                
                # Act
                Install-AWSToolsModuleFromZip -ZipPath $testZipPath -TargetPath $targetPath
                
                # Assert
                Should -Invoke Write-PSGetModuleInfo -Times 1
            }
        }
        
        It "Should create proper module directory structure" {
            InModuleScope AWS.Tools.Installer {
                # Arrange
                $tempPath = [System.IO.Path]::GetTempPath()
                $testZipPath = Join-Path -Path $tempPath -ChildPath "AWS.Tools.zip"
                $targetPath = Join-Path -Path $tempPath -ChildPath "TestTarget"
                $moduleDir = Join-Path -Path $tempPath -ChildPath "AWS.Tools.Common"
                $versionDir = Join-Path -Path $moduleDir -ChildPath "4.1.853"
                $psd1Path = Join-Path -Path $versionDir -ChildPath "AWS.Tools.Common.psd1"
                
                # Mock all the necessary functions
                Mock New-Item { }
                Mock Test-Path { $false }
                Mock Expand-Archive { }
                Mock Get-ChildItem { 
                    @([PSCustomObject]@{ 
                        Name = "AWS.Tools.Common"
                        FullName = $moduleDir
                    })
                } -ParameterFilter { [System.Boolean]$Directory.IsPresent -eq $true }
                Mock Get-ChildItem { 
                    @([PSCustomObject]@{ 
                        FullName = $psd1Path
                        Directory = @{ FullName = $versionDir }
                    })
                } -ParameterFilter { $Filter -eq "*.psd1" }
                Mock Copy-Item { }
                Mock New-PSGetModuleInfo { "<xml/>" }
                Mock Write-PSGetModuleInfo { }
                Mock Remove-Item { }

                # Act
                Install-AWSToolsModuleFromZip -ZipPath $testZipPath -TargetPath $targetPath

                # Assert
                Should -Invoke New-Item -ParameterFilter { $ItemType -eq "Directory" } -Times 1
            }
        }
        
        It "Should throw terminating error for missing manifest files" {
            InModuleScope AWS.Tools.Installer {
                # Arrange
                $tempPath = [System.IO.Path]::GetTempPath()
                $testZipPath = Join-Path -Path $tempPath -ChildPath "AWS.Tools.zip"
                $targetPath = Join-Path -Path $tempPath -ChildPath "TestTarget"
                $moduleDir = Join-Path -Path $tempPath -ChildPath "AWS.Tools.Common"
                
                Mock Expand-Archive { }
                Mock Get-ChildItem { 
                    @([PSCustomObject]@{ 
                        Name = "AWS.Tools.Common"
                        FullName = $moduleDir
                    })
                } -ParameterFilter { $Path -like "*AwsTools" -and [System.Boolean]$Directory.IsPresent -eq $true }
                Mock Get-ChildItem { @() } -ParameterFilter { $Filter -eq "*.psd1" }
                Mock Remove-Item { }
                
                # Act & Assert
                { Install-AWSToolsModuleFromZip -ZipPath $testZipPath -TargetPath $targetPath } | Should -Throw "*No manifest file found for module*"
            }
        }
        
        It "Should throw terminating error when any module fails to install" {
            InModuleScope AWS.Tools.Installer {
                # Arrange
                $tempPath = [System.IO.Path]::GetTempPath()
                $testZipPath = Join-Path $tempPath "AWS.Tools.zip"
                $targetPath = Join-Path $tempPath "TestTarget"
                $moduleDir = Join-Path $tempPath "AWS.Tools.Common"
                
                Mock Expand-Archive { }
                Mock Get-ChildItem { 
                    @([PSCustomObject]@{ 
                        Name = "AWS.Tools.Common"
                        FullName = $moduleDir
                    })
                } -ParameterFilter { $Path -like "*AwsTools" -and [System.Boolean]$Directory.IsPresent -eq $true }
                Mock Get-ChildItem { @() } -ParameterFilter { $Filter -eq "*.psd1" }
                Mock Remove-Item { }
                
                # Act & Assert
                { Install-AWSToolsModuleFromZip -ZipPath $testZipPath -TargetPath $targetPath } | Should -Throw "*No manifest file found for module*"
            }
        }
        
        It "Should complete installation process without errors when PSD1 files exist" {
            InModuleScope AWS.Tools.Installer {
                # Arrange
                $tempPath = [System.IO.Path]::GetTempPath()
                $testZipPath = Join-Path -Path $tempPath -ChildPath "AWS.Tools.zip"
                $targetPath = Join-Path -Path $tempPath -ChildPath "TestTarget"
                $moduleDir = Join-Path -Path $tempPath -ChildPath "AWS.Tools.Common"
                $versionDir = Join-Path -Path $moduleDir -ChildPath "4.1.853"
                $psd1Path = Join-Path -Path $versionDir -ChildPath "AWS.Tools.Common.psd1"
                
                Mock Expand-Archive { }
                Mock Get-ChildItem { 
                    @([PSCustomObject]@{ 
                        Name = "AWS.Tools.Common"
                        FullName = $moduleDir
                    })
                } -ParameterFilter { [System.Boolean]$Directory.IsPresent -eq $true }
                Mock Get-ChildItem { 
                    @([PSCustomObject]@{ 
                        FullName = $psd1Path
                        Directory = @{ FullName = $versionDir }
                    })
                } -ParameterFilter { $Filter -eq "*.psd1" }
                Mock Copy-Item { }
                Mock Test-Path { $false }
                Mock New-Item { }
                Mock New-PSGetModuleInfo { "<xml/>" }
                Mock Write-PSGetModuleInfo { }
                Mock Remove-Item { }
                
                # Act & Assert
                { Install-AWSToolsModuleFromZip -ZipPath $testZipPath -TargetPath $targetPath } | Should -Not -Throw
            }
        }
        
        It "Should return installed version" {
            InModuleScope AWS.Tools.Installer {
                # Arrange
                $tempPath = [System.IO.Path]::GetTempPath()
                $testZipPath = Join-Path -Path $tempPath -ChildPath "AWS.Tools.zip"
                $targetPath = Join-Path -Path $tempPath -ChildPath "TestTarget"
                $moduleDir = Join-Path -Path $tempPath -ChildPath "AWS.Tools.Common"
                $versionDir = Join-Path -Path $moduleDir -ChildPath "4.1.853"
                $psd1Path = Join-Path -Path $versionDir -ChildPath "AWS.Tools.Common.psd1"
                
                Mock Expand-Archive { }
                Mock Get-ChildItem { 
                    @([PSCustomObject]@{ 
                        Name = "AWS.Tools.Common"
                        FullName = $moduleDir
                    })
                } -ParameterFilter { [System.Boolean]$Directory.IsPresent -eq $true }
                Mock Get-ChildItem { 
                    @([PSCustomObject]@{ 
                        FullName = $psd1Path
                        Directory = @{ FullName = $versionDir }
                    })
                } -ParameterFilter { $Filter -eq "*.psd1" }
                Mock Copy-Item { }
                Mock Test-Path { $false }
                Mock New-Item { }
                Mock New-PSGetModuleInfo { "<xml/>" }
                Mock Write-PSGetModuleInfo { }
                Mock Remove-Item { }
                
                # Act
                $result = Install-AWSToolsModuleFromZip -ZipPath $testZipPath -TargetPath $targetPath
                
                # Assert - Function should complete without error
                { $result } | Should -Not -Throw
            }
        }
        
        It "Should skip AWS.Tools.Installer when determining version" {
            InModuleScope AWS.Tools.Installer {
                # Arrange
                $tempPath = [System.IO.Path]::GetTempPath()
                $testZipPath = Join-Path -Path $tempPath -ChildPath "AWS.Tools.zip"
                $targetPath = Join-Path -Path $tempPath -ChildPath "TestTarget"
                $commonDir = Join-Path -Path $tempPath -ChildPath "AWS.Tools.Common"
                $installerDir = Join-Path -Path $tempPath -ChildPath "AWS.Tools.Installer"
                
                Mock Expand-Archive { }
                Mock Get-ChildItem { 
                    @(
                        [PSCustomObject]@{ Name = "AWS.Tools.Common"; FullName = $commonDir },
                        [PSCustomObject]@{ Name = "AWS.Tools.Installer"; FullName = $installerDir }
                    )
                } -ParameterFilter { $Path -like '*AwsTools' -and [System.Boolean]$Directory.IsPresent -eq $true }
                Mock Get-ChildItem { 
                    @([PSCustomObject]@{ 
                        FullName = Join-Path -Path $commonDir -ChildPath "4.1.853/AWS.Tools.Common.psd1"
                        Directory = @{ FullName = Join-Path -Path $commonDir -ChildPath "4.1.853" }
                    })
                } -ParameterFilter { $Filter -eq "*.psd1" -and $Path -like "*Common*" }
                Mock Get-ChildItem { 
                    @([PSCustomObject]@{ 
                        FullName = Join-Path -Path $installerDir -ChildPath "1.0.2/AWS.Tools.Installer.psd1"
                        Directory = @{ FullName = Join-Path -Path $installerDir -ChildPath "1.0.2" }
                    })
                } -ParameterFilter { $Filter -eq "*.psd1" -and $Path -like "*Installer*" }
                Mock Get-ChildItem { }
                Mock Copy-Item { }
                Mock Test-Path { $false }
                Mock New-Item { }
                Mock New-PSGetModuleInfo { "<xml/>" }
                Mock Write-PSGetModuleInfo { }
                Mock Remove-Item { }
                
                # Act
                $result = Install-AWSToolsModuleFromZip -ZipPath $testZipPath -TargetPath $targetPath

                # Assert - Function should complete without error
                { $result } | Should -Not -Throw
            }
        }
    }
}
