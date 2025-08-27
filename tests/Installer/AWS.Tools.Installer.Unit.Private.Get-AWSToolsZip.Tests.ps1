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
    Describe -Tag "Smoke", "Low", "Medium", "High" "Get-AWSToolsZip"  {
        BeforeAll {
            # Mock configuration
            $script:Config = @{
                general = @{
                    CloudFront = @{
                        BaseUrl = "https://sdk-for-net.amazonwebservices.com"
                        Paths = @{
                            AWSTools = "ps"
                            AWSToolsInstaller = "ps/installer"
                        }
                    }
                    Modules = @{
                        "AWS.Tools" = @{
                            CloudFrontUrls = @{
                                ZipDownloadUrlPattern = "{baseUrl}/{path}/v{majorVersion}/latest/AWS.Tools.zip"
                                ZipDownloadUrlVersionPattern = "{baseUrl}/{path}/releases/AWS.Tools.{version}.zip"
                            }
                            ZipFileName = "AWS.Tools.zip"
                            DefaultMajorVersion = "5"
                        }
                        "AWS.Tools.Installer" = @{
                            CloudFrontUrls = @{
                                ZipDownloadUrlPattern = "{baseUrl}/{path}/v{majorVersion}/latest/AWS.Tools.Installer.zip"
                                ZipDownloadUrlVersionPattern = "{baseUrl}/{path}/releases/AWS.Tools.Installer.{version}.zip"
                            }
                            ZipFileName = "AWS.Tools.Installer.zip"
                            DefaultMajorVersion = "1"
                        }
                    }
                }
                network = @{
                    DefaultTimeout = 300
                    SHA512Validation = @{
                        TimeoutSec = 30
                        RetryCount = 3
                        EnableByDefault = $true
                    }
                }
                retry = @{
                    DownloadMaxRetries = 3
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
            
            Mock Invoke-WebRequestWithStatusHandling {
                return @{
                    Success = $true
                    StatusCode = 200
                }
            }
            
            Mock Get-HttpStatusErrorMessage { }
            Mock Test-FileIntegrity { $true }
            Mock Write-Verbose { }
            Mock Write-Debug { }
            Mock Remove-Item { }
            Mock Test-Path { $true } # Add mock for Test-Path to return true
        }
        
        Context "Basic functionality" {
            It "Should download AWS.Tools zip file" {
                # Act
                $tempPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip"
                Get-AWSToolsZip -Path $tempPath
                
                # Assert
                Should -Invoke Invoke-WebRequestWithStatusHandling -Times 1 -ParameterFilter {
                    $Uri -like "*AWS.Tools.zip" -and $OutFile -eq $tempPath
                }
            }
            
            It "Should download AWS.Tools.Installer zip file" {
                # Act
                $tempPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.Installer.zip"
                Get-AWSToolsZip -Name "AWS.Tools.Installer" -Path $tempPath
                
                # Assert
                Should -Invoke Invoke-WebRequestWithStatusHandling -Times 1 -ParameterFilter {
                    $Uri -like "*AWS.Tools.Installer.zip" -and $OutFile -eq $tempPath
                }
            }
            
            It "Should download specific version when specified" {
                # Act
                $tempPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip"
                Get-AWSToolsZip -Name "AWS.Tools" -Version "4.1.754" -Path $tempPath
                
                # Assert
                Should -Invoke Invoke-WebRequestWithStatusHandling -Times 1 -ParameterFilter {
                    $Uri -like "*AWS.Tools.4.1.754.zip"
                }
            }
            
            It "Should use the specified timeout value" {
                # Act
                $tempPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip"
                Get-AWSToolsZip -Path $tempPath -Timeout 600
                
                # Assert
                Should -Invoke Invoke-WebRequestWithStatusHandling -Times 1 -ParameterFilter {
                    $TimeoutSec -eq 600
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
                
                Mock Get-HttpStatusErrorMessage { throw "AWS.Tools.zip file not found at CloudFront URL" }
                
                # Act & Assert
                $tempPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip"
                { Get-AWSToolsZip -Path $tempPath } | 
                    Should -Throw "AWS.Tools.zip file not found at CloudFront URL"
            }
            
            It "Should throw when configuration is missing" {
                # Arrange
                $originalConfig = $script:Config
                $script:Config = @{
                    general = @{
                        CloudFront = @{
                            BaseUrl = "https://sdk-for-net.amazonwebservices.com"
                            Paths = @{
                                AWSTools = "ps"
                            }
                        }
                        Modules = @{
                            # Missing AWS.Tools.Installer configuration
                        }
                    }
                }
                
                # Act & Assert
                $tempPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.Installer.zip"
                { Get-AWSToolsZip -Name "AWS.Tools.Installer" -Path $tempPath } | 
                    Should -Throw "*Configuration not found for module type*"
                
                # Restore original config
                $script:Config = $originalConfig
            }
        }
        
        Context "SHA512 validation" {
            It "Should perform SHA512 validation by default" {
                # Act
                $tempPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip"
                Get-AWSToolsZip -Path $tempPath
                
                # Assert
                Should -Invoke Test-FileIntegrity -Times 1 -ParameterFilter {
                    $FilePath -eq $tempPath
                }
            }
            
            It "Should skip SHA512 validation when SkipIntegrityCheck is specified" {
                # Act
                $tempPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip"
                Get-AWSToolsZip -Path $tempPath -SkipIntegrityCheck
                
                # Assert
                Should -Invoke Test-FileIntegrity -Times 0
            }
            
            It "Should use local hash file when SourceHashPath is provided" {
                # Act
                $tempPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip"
                $hashPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip.sha512"
                Get-AWSToolsZip -Path $tempPath -SourceHashPath $hashPath
                
                # Assert
                Should -Invoke Test-FileIntegrity -Times 1 -ParameterFilter {
                    $FilePath -eq $tempPath -and $SourceHashPath -eq $hashPath
                }
            }
            
            It "Should delete downloaded file when validation fails" {
                # Arrange
                Mock Test-FileIntegrity { throw "SHA512 hash validation failed" }
                
                # Act & Assert
                $tempPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip"
                { Get-AWSToolsZip -Path $tempPath } | Should -Throw "SHA512 hash validation failed"
                Should -Invoke Remove-Item -Times 1 -ParameterFilter {
                    $Path -eq $tempPath
                }
            }
        }
        
        Context "Retry logic" {
            It "Should use the configured retry settings" {
                # Act
                $tempPath = Join-Path -Path $([System.IO.Path]::GetTempPath()) -ChildPath "AWS.Tools.zip"
                Get-AWSToolsZip -Path $tempPath
                
                # Assert
                Should -Invoke Invoke-WithRetry -Times 1 -ParameterFilter {
                    $MaxRetries -eq 3 -and
                    $BaseDelaySeconds -eq 2.0 -and
                    $OperationName -like "Download AWS.Tools.zip"
                }
            }
        }
    }
}
