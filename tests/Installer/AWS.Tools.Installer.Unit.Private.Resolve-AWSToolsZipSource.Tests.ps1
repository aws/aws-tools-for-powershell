BeforeDiscovery {
    # Import the module under test in BeforeDiscovery
    Import-Module (Join-Path $PSScriptRoot "../../modules/Installer/AWS.Tools.Installer.psd1") -Force
}

BeforeAll {
    # Use preference variables instead of mocking Write commands
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
}

# Single InModuleScope wrapping ALL tests (OUTSIDE BeforeAll)
InModuleScope AWS.Tools.Installer {
    Describe -Tag "Smoke", "Low", "Medium", "High" "Resolve-AWSToolsZipSource" {
        
        BeforeEach {
            # Reset any module state before each test
            $script:VersionCache = @{}
        }
        
        Context "Local Source File Validation" {
            It "Should return local path when SourceZipPath exists" {
                # Arrange
                $testZipPath = Join-Path $TestDrive "AWS.Tools.zip"
                Mock Test-Path { $true }
                
                # Act
                $result = Resolve-AWSToolsZipSource -SourceZipPath $testZipPath -TempDir $TestDrive
                
                # Assert
                $result | Should -Be $testZipPath
                Should -Invoke Test-Path -ParameterFilter { $Path -eq $testZipPath } -Times 1
            }
            
            It "Should throw when SourceZipPath does not exist" {
                # Arrange
                $missingZipPath = Join-Path $TestDrive "missing.zip"
                Mock Test-Path { $false }
                
                # Act & Assert
                { Resolve-AWSToolsZipSource -SourceZipPath $missingZipPath -TempDir $TestDrive } | 
                    Should -Throw "*does not exist*"
            }
            
            It "Should validate absolute path for SourceZipPath" {
                # Arrange
                $relativePath = "relative.zip"
                
                # Act & Assert
                { Resolve-AWSToolsZipSource -SourceZipPath $relativePath -TempDir $TestDrive } | 
                    Should -Throw "*must be an absolute path*"
            }
            
            It "Should validate zip file extension" {
                # Arrange
                $testPath = Join-Path $TestDrive "test.txt"
                Mock Test-Path { $true }
                
                # Act & Assert
                { Resolve-AWSToolsZipSource -SourceZipPath $testPath -TempDir $TestDrive } | 
                    Should -Throw "*must be a .zip file*"
            }
        }
        
        Context "CloudFront Download" {
            It "Should download when no SourceZipPath specified" {
                # Arrange
                Mock Get-AWSToolsZip { 
                    # Create the expected file
                    $outFile = Join-Path $TestDrive "AWS.Tools.zip"
                    New-Item -Path $outFile -ItemType File -Force | Out-Null
                }
                
                # Act
                $result = Resolve-AWSToolsZipSource -TempDir $TestDrive
                
                # Assert
                Should -Invoke Get-AWSToolsZip -Times 1
                $result | Should -Be (Join-Path $TestDrive "AWS.Tools.zip")
            }
            
            It "Should pass SkipIntegrityCheck parameter to Get-AWSToolsZip" {
                # Arrange
                Mock Get-AWSToolsZip { 
                    # Create the expected file
                    $outFile = Join-Path $TestDrive "AWS.Tools.zip"
                    New-Item -Path $outFile -ItemType File -Force | Out-Null
                }
                
                # Act
                Resolve-AWSToolsZipSource -TempDir $TestDrive -SkipIntegrityCheck
                
                # Assert
                Should -Invoke Get-AWSToolsZip -ParameterFilter { $SkipIntegrityCheck -eq $true } -Times 1
            }
            
            It "Should pass SourceHashPath parameter to Get-AWSToolsZip" {
                # Arrange
                Mock Get-AWSToolsZip { 
                    # Create the expected file
                    $outFile = Join-Path $TestDrive "AWS.Tools.zip"
                    New-Item -Path $outFile -ItemType File -Force | Out-Null
                }
                $hashPath = Join-Path $TestDrive "AWS.Tools.zip.sha512"
                
                # Act
                Resolve-AWSToolsZipSource -TempDir $TestDrive -SourceHashPath $hashPath
                
                # Assert
                Should -Invoke Get-AWSToolsZip -ParameterFilter { $SourceHashPath -eq $hashPath } -Times 1
            }
            
            It "Should pass version to Get-AWSToolsZip" {
                # Arrange
                $version = [Version]"4.1.853"
                Mock Get-AWSToolsZip { 
                    # Create the expected file
                    $outFile = Join-Path $TestDrive "AWS.Tools.zip"
                    New-Item -Path $outFile -ItemType File -Force | Out-Null
                }
                
                # Act
                Resolve-AWSToolsZipSource -Version $version -TempDir $TestDrive
                
                # Assert
                Should -Invoke Get-AWSToolsZip -ParameterFilter { $Version -eq $version } -Times 1
            }
            
            It "Should pass timeout to Get-AWSToolsZip" {
                # Arrange
                Mock Get-AWSToolsZip { 
                    # Create the expected file
                    $outFile = Join-Path $TestDrive "AWS.Tools.zip"
                    New-Item -Path $outFile -ItemType File -Force | Out-Null
                }
                
                # Act
                Resolve-AWSToolsZipSource -TempDir $TestDrive -Timeout 600
                
                # Assert
                Should -Invoke Get-AWSToolsZip -ParameterFilter { $Timeout -eq 600 } -Times 1
            }
        }
        
        Context "Module Type Support" {
            It "Should default to AWS.Tools when no Name specified" {
                # Arrange
                Mock Get-AWSToolsZip { 
                    # Create the expected file
                    $outFile = Join-Path $TestDrive "AWS.Tools.zip"
                    New-Item -Path $outFile -ItemType File -Force | Out-Null
                }
                
                # Act
                $result = Resolve-AWSToolsZipSource -TempDir $TestDrive
                
                # Assert
                Should -Invoke Get-AWSToolsZip -ParameterFilter { $Name -eq 'AWS.Tools' } -Times 1
                $result | Should -Be (Join-Path $TestDrive "AWS.Tools.zip")
            }
            
            It "Should handle AWS.Tools module type" {
                # Arrange
                Mock Get-AWSToolsZip { 
                    # Create the expected file
                    $outFile = Join-Path $TestDrive "AWS.Tools.zip"
                    New-Item -Path $outFile -ItemType File -Force | Out-Null
                }
                
                # Act
                $result = Resolve-AWSToolsZipSource -Name 'AWS.Tools' -TempDir $TestDrive
                
                # Assert
                Should -Invoke Get-AWSToolsZip -ParameterFilter { $Name -eq 'AWS.Tools' } -Times 1
                $result | Should -Be (Join-Path $TestDrive "AWS.Tools.zip")
            }
            
            It "Should handle AWS.Tools.Installer module type" {
                # Arrange
                Mock Get-AWSToolsZip { 
                    # Create the expected file
                    $outFile = Join-Path $TestDrive "AWS.Tools.Installer.zip"
                    New-Item -Path $outFile -ItemType File -Force | Out-Null
                }
                
                # Act
                $result = Resolve-AWSToolsZipSource -Name 'AWS.Tools.Installer' -TempDir $TestDrive
                
                # Assert
                Should -Invoke Get-AWSToolsZip -ParameterFilter { $Name -eq 'AWS.Tools.Installer' } -Times 1
                $result | Should -Be (Join-Path $TestDrive "AWS.Tools.Installer.zip")
            }
            
            It "Should pass Name parameter to Get-AWSToolsZip" {
                # Arrange
                Mock Get-AWSToolsZip { }
                
                # Act
                Resolve-AWSToolsZipSource -Name 'AWS.Tools.Installer' -TempDir $TestDrive
                
                # Assert
                Should -Invoke Get-AWSToolsZip -ParameterFilter { $Name -eq 'AWS.Tools.Installer' } -Times 1
            }
            
            It "Should throw for invalid module type" {
                # Arrange
                # No mocks needed for validation test
                
                # Act & Assert
                { Resolve-AWSToolsZipSource -Name 'InvalidType' -TempDir $TestDrive } | 
                    Should -Throw
            }
        }
        
        Context "File Name Validation" {
            It "Should validate zip file name for AWS.Tools" {
                # Arrange
                $testZipPath = Join-Path $TestDrive "WrongName.zip"
                Mock Test-Path { $true }
                Mock Write-Warning { }
                
                # Act
                $result = Resolve-AWSToolsZipSource -Name 'AWS.Tools' -SourceZipPath $testZipPath -TempDir $TestDrive
                
                # Assert
                Should -Invoke Write-Warning -ParameterFilter { 
                    $Message -like "*WrongName.zip*does not match expected*AWS.Tools.zip*" 
                } -Times 1
                $result | Should -Be $testZipPath
            }
            
            It "Should validate zip file name for AWS.Tools.Installer" {
                # Arrange
                $testZipPath = Join-Path $TestDrive "WrongName.zip"
                Mock Test-Path { $true }
                Mock Write-Warning { }
                
                # Act
                $result = Resolve-AWSToolsZipSource -Name 'AWS.Tools.Installer' -SourceZipPath $testZipPath -TempDir $TestDrive
                
                # Assert
                Should -Invoke Write-Warning -ParameterFilter { 
                    $Message -like "*WrongName.zip*does not match expected*AWS.Tools.Installer.zip*" 
                } -Times 1
                $result | Should -Be $testZipPath
            }
            
            It "Should not warn when zip file name matches expected name for AWS.Tools" {
                # Arrange
                $testZipPath = Join-Path $TestDrive "AWS.Tools.zip"
                Mock Test-Path { $true }
                Mock Write-Warning { }
                
                # Act
                $result = Resolve-AWSToolsZipSource -Name 'AWS.Tools' -SourceZipPath $testZipPath -TempDir $TestDrive
                
                # Assert
                Should -Not -Invoke Write-Warning
                $result | Should -Be $testZipPath
            }
            
            It "Should not warn when zip file name matches expected name for AWS.Tools.Installer" {
                # Arrange
                $testZipPath = Join-Path $TestDrive "AWS.Tools.Installer.zip"
                Mock Test-Path { $true }
                Mock Write-Warning { }
                
                # Act
                $result = Resolve-AWSToolsZipSource -Name 'AWS.Tools.Installer' -SourceZipPath $testZipPath -TempDir $TestDrive
                
                # Assert
                Should -Not -Invoke Write-Warning
                $result | Should -Be $testZipPath
            }
        }
        
        Context "Error Handling" {
            It "Should handle Get-AWSToolsZip errors gracefully" {
                # Arrange
                Mock Get-AWSToolsZip { throw "Network error" }
                
                # Act & Assert
                { Resolve-AWSToolsZipSource -TempDir $TestDrive } | 
                    Should -Throw "Network error"
            }
            
            It "Should handle invalid TempDir parameter" {
                # Arrange
                $invalidTempDir = ""
                
                # Act & Assert
                { Resolve-AWSToolsZipSource -TempDir $invalidTempDir } | 
                    Should -Throw
            }
        }
        
        Context "Cross-Platform Compatibility" {
            It "Should work with Unix-style paths" {
                # Arrange
                $unixStylePath = "/tmp/AWS.Tools.zip"
                Mock Test-Path { $true }
                # No need to mock [System.IO.Path]::IsPathRooted anymore
                # Our implementation now handles Unix paths directly
                
                # Act
                $result = Resolve-AWSToolsZipSource -SourceZipPath $unixStylePath -TempDir $TestDrive
                
                # Assert
                $result | Should -Be $unixStylePath
            }
            
            It "Should handle different path separators correctly" {
                # Arrange
                Mock Get-AWSToolsZip { 
                    # Create the expected file
                    $normalizedTempDir = $tempDirWithSeparator.TrimEnd([System.IO.Path]::DirectorySeparatorChar, [System.IO.Path]::AltDirectorySeparatorChar)
                    $outFile = Join-Path $normalizedTempDir "AWS.Tools.zip"
                    New-Item -Path $outFile -ItemType File -Force | Out-Null
                }
                $tempDirWithSeparator = $TestDrive + [System.IO.Path]::DirectorySeparatorChar
                
                # Act
                $result = Resolve-AWSToolsZipSource -TempDir $tempDirWithSeparator
                
                # Assert
                # The result should be the normalized path
                $normalizedTempDir = $tempDirWithSeparator.TrimEnd([System.IO.Path]::DirectorySeparatorChar, [System.IO.Path]::AltDirectorySeparatorChar)
                $result | Should -Be (Join-Path $normalizedTempDir "AWS.Tools.zip")
            }
        }
    }
}
