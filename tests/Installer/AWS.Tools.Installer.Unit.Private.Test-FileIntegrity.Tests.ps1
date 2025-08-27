BeforeDiscovery {
    # Import the module under test in BeforeDiscovery
    Import-Module (Join-Path $PSScriptRoot "../../modules/Installer/AWS.Tools.Installer.psd1") -Force
}

BeforeAll {
    # Use preference variables instead of mocking Write commands
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
}

InModuleScope AWS.Tools.Installer {
    Describe -Tag "Smoke", "Low", "Medium", "High" "Test-FileIntegrity" {
        BeforeAll {
            # Mock configuration
            $script:Config = @{
                network = @{
                    SHA512Validation = @{
                        TimeoutSec = 30
                        RetryCount = 3
                        EnableByDefault = $true
                    }
                }
            }
            
            # Define a valid hash for testing
            $validHash = "a1b2c3d40123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdefabcdef12"
            
            # Mock functions
            Mock Get-SHA512Hash { return $validHash }
            Mock Get-FileHash { 
                return [PSCustomObject]@{
                    Algorithm = "SHA512"
                    Hash = $validHash
                }
            }
            
            # Mock file operations
            Mock Test-Path { $true }
            Mock Get-Content { return $validHash }
        }
        
        Context "Successful validation" {
            It "Should return true when hash validation succeeds with remote hash" {
                # Act
                $tempPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "file.zip"
                $result = Test-FileIntegrity -FilePath $tempPath -BaseUrl "https://example.com/file.zip"
                
                # Assert
                $result | Should -Be $true
                Should -Invoke Get-SHA512Hash -Times 1 -ParameterFilter {
                    $Url -eq "https://example.com/file.zip.sha512"
                }
                Should -Invoke Get-FileHash -Times 1 -ParameterFilter {
                    $Path -eq $tempPath -and $Algorithm -eq "SHA512"
                }
            }
            
            It "Should return true when hash validation succeeds with local hash file" {
                # Act
                $tempPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "file.zip"
                $hashPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "file.zip.sha512"
                $result = Test-FileIntegrity -FilePath $tempPath -SourceHashPath $hashPath
                
                # Assert
                $result | Should -Be $true
                Should -Invoke Get-SHA512Hash -Times 0
                Should -Invoke Get-Content -Times 1 -ParameterFilter {
                    $Path -eq $hashPath
                }
                Should -Invoke Get-FileHash -Times 1 -ParameterFilter {
                    $Path -eq $tempPath -and $Algorithm -eq "SHA512"
                }
            }
            
            It "Should use the specified timeout value" {
                # Act
                $tempPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "file.zip"
                Test-FileIntegrity -FilePath $tempPath -BaseUrl "https://example.com/file.zip" -TimeoutSec 60
                
                # Assert
                Should -Invoke Get-SHA512Hash -Times 1 -ParameterFilter {
                    $TimeoutSec -eq 60
                }
            }
            
            It "Should handle case-insensitive hash comparison" {
                # Arrange
                $upperCaseHash = $validHash.ToUpper()
                Mock Get-FileHash { 
                    return [PSCustomObject]@{
                        Algorithm = "SHA512"
                        Hash = $upperCaseHash
                    }
                }
                
                # Act
                $tempPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "file.zip"
                $result = Test-FileIntegrity -FilePath $tempPath -BaseUrl "https://example.com/file.zip"
                
                # Assert
                $result | Should -Be $true
            }
        }
        
        Context "Error handling" {
            It "Should throw when file does not exist" {
                # Arrange
                Mock Test-Path { $false }
                
                # Act & Assert
                $nonExistentPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "nonexistent.zip"
                { Test-FileIntegrity -FilePath $nonExistentPath -BaseUrl "https://example.com/file.zip" } | 
                    Should -Throw -ExpectedMessage "*File not found for integrity validation*"
            }
            
            It "Should throw when neither BaseUrl nor SourceHashPath is provided" {
                # Act & Assert
                $tempPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "file.zip"
                { Test-FileIntegrity -FilePath $tempPath } | 
                    Should -Throw -ExpectedMessage "*Either BaseUrl or SourceHashPath must be provided*"
            }
            
            It "Should throw when local hash file does not exist" {
                # Arrange
                Mock Test-Path { 
                    param($Path)
                    $tempPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "file.zip"
                    return $Path -eq $tempPath
                }
                
                # Act & Assert
                $tempPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "file.zip"
                $nonExistentHashPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "nonexistent.sha512"
                { Test-FileIntegrity -FilePath $tempPath -SourceHashPath $nonExistentHashPath } | 
                    Should -Throw -ExpectedMessage "*SHA512 hash file not found at specified path*"
            }
            
            It "Should throw when local hash file has invalid format" {
                # Arrange
                $invalidHash = "not-a-valid-hash"
                Mock Get-Content { return $invalidHash }
                
                # Act & Assert
                $tempPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "file.zip"
                $hashPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "file.zip.sha512"
                { Test-FileIntegrity -FilePath $tempPath -SourceHashPath $hashPath } | 
                    Should -Throw -ExpectedMessage "*Invalid SHA512 hash format*"
            }
            
            It "Should throw when Get-FileHash fails" {
                # Arrange
                Mock Get-FileHash { throw "Access denied" }
                
                # Act & Assert
                $tempPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "file.zip"
                { Test-FileIntegrity -FilePath $tempPath -BaseUrl "https://example.com/file.zip" } | 
                    Should -Throw -ExpectedMessage "*Failed to calculate SHA512 hash*"
            }
            
            It "Should throw when Get-SHA512Hash fails" {
                # Arrange
                Mock Get-SHA512Hash { throw "Download failed" }
                
                # Act & Assert
                $tempPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "file.zip"
                { Test-FileIntegrity -FilePath $tempPath -BaseUrl "https://example.com/file.zip" } | 
                    Should -Throw -ExpectedMessage "*Failed to download SHA512 hash*"
            }
            
            It "Should throw when hash validation fails" {
                # Arrange
                $differentHash = "b2c3d4e40123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdefabcdef12"
                Mock Get-FileHash { 
                    return [PSCustomObject]@{
                        Algorithm = "SHA512"
                        Hash = $differentHash
                    }
                }
                
                # Act & Assert
                $tempPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "file.zip"
                { Test-FileIntegrity -FilePath $tempPath -BaseUrl "https://example.com/file.zip" } | 
                    Should -Throw -ExpectedMessage "*SHA512 hash validation failed*"
            }
        }
        
        Context "Parameter validation" {
            It "Should prioritize SourceHashPath over BaseUrl when both are provided" {
                # Act
                $tempPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "file.zip"
                $hashPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "file.zip.sha512"
                Test-FileIntegrity -FilePath $tempPath -BaseUrl "https://example.com/file.zip" -SourceHashPath $hashPath
                
                # Assert
                Should -Invoke Get-Content -Times 1 -ParameterFilter {
                    $Path -eq $hashPath
                }
                Should -Invoke Get-SHA512Hash -Times 0
            }
        }
    }
}
