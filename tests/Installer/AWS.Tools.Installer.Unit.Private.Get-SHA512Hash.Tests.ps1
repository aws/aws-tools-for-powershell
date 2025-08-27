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
    Describe -Tag "Smoke", "Low", "Medium", "High" "Get-SHA512Hash" {
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
                retry = @{
                    DownloadBaseDelaySeconds = 2.0
                    RetryableExceptions = @{
                        Network = @(
                            "System.Net.WebException"
                            "System.Net.Http.HttpRequestException"
                            "System.TimeoutException"
                        )
                    }
                }
            }
            
            # Mock functions
            Mock Invoke-WithRetry {
                param($ScriptBlock)
                & $ScriptBlock
            }
            
            # Mock temporary file operations
            Mock New-Item { }
            Mock Remove-Item { }
            Mock Test-Path { $true }
            Mock Get-Content { }
        }
        
        Context "Successful hash download and parsing" {
            It "Should download and return a valid SHA512 hash" {
                # Arrange
                $validHash = "a1b2c3d40123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdefabcdef12"
                Mock Get-Content { return $validHash }
                
                Mock Invoke-WebRequestWithStatusHandling {
                    return @{
                        Success = $true
                        StatusCode = 200
                    }
                }
                
                # Act
                $result = Get-SHA512Hash -Url "https://example.com/file.zip.sha512"
                
                # Assert
                $result | Should -Be $validHash
                Should -Invoke Invoke-WebRequestWithStatusHandling -Times 1 -ParameterFilter {
                    $Uri -eq "https://example.com/file.zip.sha512"
                }
            }
            
            It "Should trim whitespace from hash content" {
                # Arrange
                $validHash = "a1b2c3d40123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdefabcdef12"
                Mock Get-Content { return "  $validHash  `r`n" }
                
                Mock Invoke-WebRequestWithStatusHandling {
                    return @{
                        Success = $true
                        StatusCode = 200
                    }
                }
                
                # Act
                $result = Get-SHA512Hash -Url "https://example.com/file.zip.sha512"
                
                # Assert
                $result | Should -Be $validHash
            }
            
            It "Should use the specified timeout value" {
                # Arrange
                $validHash = "a1b2c3d40123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdefabcdef12"
                Mock Get-Content { return $validHash }
                
                Mock Invoke-WebRequestWithStatusHandling {
                    return @{
                        Success = $true
                        StatusCode = 200
                    }
                }
                
                # Act
                Get-SHA512Hash -Url "https://example.com/file.zip.sha512" -TimeoutSec 60
                
                # Assert
                Should -Invoke Invoke-WebRequestWithStatusHandling -Times 1 -ParameterFilter {
                    $TimeoutSec -eq 60
                }
            }
        }
        
        Context "Error handling" {
            It "Should throw when download fails" {
                # Arrange
                Mock Invoke-WebRequestWithStatusHandling {
                    return @{
                        Success = $false
                        StatusCode = 404
                        Error = "Not found"
                    }
                }
                
                Mock Get-HttpStatusErrorMessage { throw "SHA512 hash file not found at URL: https://example.com/file.zip.sha512" }
                
                # Act & Assert
                { Get-SHA512Hash -Url "https://example.com/file.zip.sha512" } | 
                    Should -Throw "SHA512 hash file not found at URL: https://example.com/file.zip.sha512"
            }
            
            It "Should throw when hash format is invalid" {
                # Arrange
                $invalidHash = "not-a-valid-hash"
                Mock Get-Content { return $invalidHash }
                
                Mock Invoke-WebRequestWithStatusHandling {
                    return @{
                        Success = $true
                        StatusCode = 200
                    }
                }
                
                # Act & Assert
                { Get-SHA512Hash -Url "https://example.com/file.zip.sha512" } | 
                    Should -Throw -ExpectedMessage "*Invalid SHA512 hash format*"
            }
            
            It "Should throw when temporary file is not created" {
                # Arrange
                Mock Test-Path { $false }
                
                Mock Invoke-WebRequestWithStatusHandling {
                    return @{
                        Success = $true
                        StatusCode = 200
                    }
                }
                
                # Act & Assert
                { Get-SHA512Hash -Url "https://example.com/file.zip.sha512" } | 
                    Should -Throw -ExpectedMessage "*SHA512 hash file not found at temporary location*"
            }
            
            It "Should clean up temporary file even when an error occurs" {
                # Arrange
                Mock Invoke-WebRequestWithStatusHandling {
                    return @{
                        Success = $false
                        StatusCode = 500
                        Error = "Server error"
                    }
                }
                
                Mock Get-HttpStatusErrorMessage { throw "Server error" }
                
                # Act & Assert
                { Get-SHA512Hash -Url "https://example.com/file.zip.sha512" } | Should -Throw
                Should -Invoke Remove-Item -Times 1
            }
        }
        
        Context "Retry logic" {
            It "Should use the configured retry settings" {
                # Arrange
                $validHash = "a1b2c3d40123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdefabcdef12"
                Mock Get-Content { return $validHash }
                
                Mock Invoke-WebRequestWithStatusHandling {
                    return @{
                        Success = $true
                        StatusCode = 200
                    }
                }
                
                # Act
                Get-SHA512Hash -Url "https://example.com/file.zip.sha512"
                
                # Assert
                Should -Invoke Invoke-WithRetry -Times 1 -ParameterFilter {
                    $MaxRetries -eq 3 -and
                    $BaseDelaySeconds -eq 2.0 -and
                    $OperationName -eq "Download SHA512 hash file"
                }
            }
        }
    }
}
