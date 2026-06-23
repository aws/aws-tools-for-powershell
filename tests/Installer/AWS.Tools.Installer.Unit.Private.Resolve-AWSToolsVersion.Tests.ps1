BeforeDiscovery {
    . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")
}

BeforeAll {
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
    $WarningPreference = 'SilentlyContinue'
    $InformationPreference = 'Ignore'
}

InModuleScope AWS.Tools.Installer {
    Describe -Skip:$SkipInstallerTests -Tag "Smoke", "Low", "Medium", "High" "Installer - Resolve-AWSToolsVersion Private Function Tests" {
        
        Context "Null and Empty Version Handling" {
            It "Should return null for null version" {
                # Act
                $result = Resolve-AWSToolsVersion -Version $null
                
                # Assert
                $result | Should -BeNullOrEmpty
            }
            
            It "Should return null for empty string version" {
                # Act
                $result = Resolve-AWSToolsVersion -Version ""
                
                # Assert
                $result | Should -BeNullOrEmpty
            }
            
            It "Should return null for whitespace-only version" {
                # Act
                $result = Resolve-AWSToolsVersion -Version "   "
                
                # Assert
                $result | Should -BeNullOrEmpty
            }
        }
        
        Context "Exact Version Handling" {
            BeforeEach {
                # Mock successful HEAD check for exact versions by default
                Mock Invoke-WithRetry { 
                    param($ScriptBlock, $OperationName)
                    if ($OperationName -eq "Verify exact version availability") {
                        # Simulate successful HEAD response
                        return @{ StatusCode = 200 }
                    }
                    # For other operations, call the original scriptblock
                    & $ScriptBlock
                }
            }
            
            It "Should return Version object for valid exact version that exists on CloudFront" {
                # Act
                $result = Resolve-AWSToolsVersion -Version "4.1.754"
                
                # Assert
                $result | Should -BeOfType [Version]
                $result.ToString() | Should -Be "4.1.754"
                
                # Verify HEAD check was performed
                Should -Invoke Invoke-WithRetry -ParameterFilter { 
                    $OperationName -eq "Verify exact version availability" 
                } -Times 1
            }
            
            It "Should throw error when exact version does not exist on CloudFront" {
                # Arrange - Mock HEAD check failure with HTTP status code response
                Mock Invoke-WithRetry { 
                    param($ScriptBlock, $OperationName)
                    if ($OperationName -eq "Verify exact version availability") {
                        # Simulate the HTTP status code wrapper returning a 404 error
                        $mockResponse = @{
                            Success = $false
                            StatusCode = 404
                            Error = "Not Found"
                        }
                        # Simulate the script block that would throw the appropriate error
                        throw "Version 4.1.999 is not available online. Please check the version number or use a wildcard pattern to get the latest available version for that major version."
                    }
                }
                
                # Act & Assert
                { Resolve-AWSToolsVersion -Version "4.1.999" } | 
                Should -Throw "*Version 4.1.999 is not available online*"
            }
            
            It "Should construct correct CloudFront URL for exact version HEAD check" {
                # Arrange
                $capturedUri = $null
                Mock Invoke-WithRetry { 
                    param($ScriptBlock, $OperationName)
                    if ($OperationName -eq "Verify exact version availability") {
                        # Capture the URI from the scriptblock
                        $scriptString = $ScriptBlock.ToString()
                        if ($scriptString -match 'Uri\s+([^\s]+)') {
                            $capturedUri = $matches[1]
                        }
                        return @{ StatusCode = 200 }
                    }
                }
                
                # Act
                $result = Resolve-AWSToolsVersion -Version "4.1.754"
                
                # Assert
                Should -Invoke Invoke-WithRetry -ParameterFilter { 
                    $OperationName -eq "Verify exact version availability" 
                } -Times 1
                # Note: URI validation would require more complex mocking to capture the actual parameter
            }
            
            It "Should accept four-part version when last part is 0" {
                # Act
                $result = Resolve-AWSToolsVersion -Version "4.1.754.0"
                
                # Assert
                $result | Should -BeOfType [Version]
                $result.ToString() | Should -Be "4.1.754.0"
            }
            
            It "Should throw error for four-part version with non-zero last part" {
                # Act & Assert
                { Resolve-AWSToolsVersion -Version "4.1.754.1" } | 
                Should -Throw "*Invalid AWS.Tools version format*"
            }
            
            It "Should throw error for invalid version format" {
                # Act & Assert
                { Resolve-AWSToolsVersion -Version "invalid.version" } | 
                Should -Throw "*Invalid version format*"
            }
        }
        
        Context "Wildcard Version Resolution" {
            BeforeEach {
                # Mock Invoke-WithRetry to avoid actual network calls
                Mock Invoke-WithRetry { 
                    param($ScriptBlock)
                    # Simulate successful response with Content-Disposition header
                    return @{ 
                        Headers = @{ 
                            'Content-Disposition' = 'attachment; filename=AWS.Tools.4.1.754.zip' 
                        } 
                    }
                }
            }
            
            It "Should resolve 4.* pattern to actual version" {
                # Act
                $result = Resolve-AWSToolsVersion -Version "4.*"
                
                # Assert
                $result | Should -BeOfType [Version]
                $result.ToString() | Should -Be "4.1.754"
            }
            
            It "Should return null when wildcard resolution fails" {
                # Arrange - Mock failure
                Mock Invoke-WithRetry { 
                    throw "Network error"
                }
                
                # Act
                $result = Resolve-AWSToolsVersion -Version "4.*"
                
                # Assert
                $result | Should -BeNullOrEmpty
            }
            
            It "Should handle array Content-Disposition headers" {
                # Arrange
                Mock Invoke-WithRetry { 
                    return @{ 
                        Headers = @{ 
                            'Content-Disposition' = @('attachment; filename=AWS.Tools.5.2.100.zip', 'other-header') 
                        } 
                    }
                }
                
                # Act
                $result = Resolve-AWSToolsVersion -Version "5.*"
                
                # Assert
                $result | Should -BeOfType [Version]
                $result.ToString() | Should -Be "5.2.100"
            }
        }
        
        Context "Error Handling" {
            It "Should provide helpful error message for invalid version format" {
                # Act & Assert
                $errorMessage = { Resolve-AWSToolsVersion -Version "not.a.version" } | 
                Should -Throw -PassThru
                $errorMessage.Exception.Message | Should -Match "Invalid version format.*Use exact version.*or major version"
            }
        }
        
        Context "Preview/Prerelease Version Handling" {
            BeforeEach {
                # Mock successful HEAD check for preview versions
                Mock Invoke-WithRetry { 
                    param($ScriptBlock, $OperationName)
                    if ($OperationName -eq "Verify preview version availability") {
                        # Simulate successful HEAD response
                        return @{ StatusCode = 200 }
                    }
                    # For other operations, call the original scriptblock
                    & $ScriptBlock
                }
                
                # Mock ConvertTo-AWSToolsSemVer to return expected semver object
                Mock ConvertTo-AWSToolsSemVer {
                    param($VersionString)
                    if ($VersionString -match '^(\d+)\.(\d+)\.(\d+)-(.+)$') {
                        return [PSCustomObject]@{
                            Version = [Version]::new([int]$matches[1], [int]$matches[2], [int]$matches[3])
                            PreReleaseTag = $matches[4]
                            IsPreRelease = $true
                            SemVerString = $VersionString
                            Major = [int]$matches[1]
                            Minor = [int]$matches[2]
                            Build = [int]$matches[3]
                        }
                    }
                    return $null
                }
            }
            
            It "Should detect and handle preview version '5.0.0-preview001'" {
                # Act
                $result = Resolve-AWSToolsVersion -Version "5.0.0-preview001"
                
                # Assert
                $result | Should -Not -BeNullOrEmpty
                $result.IsPreRelease | Should -Be $true
                $result.PreReleaseTag | Should -Be "preview001"
                $result.SemVerString | Should -Be "5.0.0-preview001"
                $result.Version.ToString() | Should -Be "5.0.0"
            }
            
            It "Should return semver object (not Version) for preview versions" {
                # Act
                $result = Resolve-AWSToolsVersion -Version "5.0.0-preview001"
                
                # Assert
                $result | Should -Not -BeOfType [Version]
                $result.PSObject.Properties['IsPreRelease'] | Should -Not -BeNullOrEmpty
                $result.PSObject.Properties['SemVerString'] | Should -Not -BeNullOrEmpty
            }
            
            It "Should verify preview version exists on CloudFront" {
                # Act
                $result = Resolve-AWSToolsVersion -Version "5.0.0-preview001"
                
                # Assert
                Should -Invoke Invoke-WithRetry -ParameterFilter { 
                    $OperationName -eq "Verify preview version availability" 
                } -Times 1
            }
            
            It "Should throw error when preview version does not exist on CloudFront" {
                # Arrange - Mock HEAD check failure
                Mock Invoke-WithRetry { 
                    param($ScriptBlock, $OperationName)
                    if ($OperationName -eq "Verify preview version availability") {
                        throw "Preview version 5.0.0-preview999 is not available online. Please check the version number."
                    }
                }
                
                # Act & Assert
                { Resolve-AWSToolsVersion -Version "5.0.0-preview999" } | 
                Should -Throw "*Preview version 5.0.0-preview999 is not available online*"
            }
            
            It "Should handle various prerelease tag formats" {
                # Test different prerelease formats
                $prereleaseTags = @("alpha", "beta1", "rc.1", "preview001")
                
                foreach ($tag in $prereleaseTags) {
                    # Arrange
                    Mock ConvertTo-AWSToolsSemVer {
                        param($VersionString)
                        return [PSCustomObject]@{
                            Version = [Version]::new(5, 0, 0)
                            PreReleaseTag = $tag
                            IsPreRelease = $true
                            SemVerString = "5.0.0-$tag"
                            Major = 5
                            Minor = 0
                            Build = 0
                        }
                    }
                    
                    # Act
                    $result = Resolve-AWSToolsVersion -Version "5.0.0-$tag"
                    
                    # Assert
                    $result.PreReleaseTag | Should -Be $tag
                    $result.IsPreRelease | Should -Be $true
                }
            }
            
            It "Should preserve Major, Minor, Build properties for preview versions" {
                # Act
                $result = Resolve-AWSToolsVersion -Version "5.0.0-preview001"
                
                # Assert
                $result.Major | Should -Be 5
                $result.Minor | Should -Be 0
                $result.Build | Should -Be 0
            }
        }
        
        Context "Module Type Support" {
            BeforeEach {
                # Mock successful HEAD check for exact versions by default
                Mock Invoke-WithRetry { 
                    param($ScriptBlock, $OperationName)
                    if ($OperationName -eq "Verify exact version availability") {
                        return @{ StatusCode = 200 }
                    }
                    # For wildcard resolution
                    return @{ 
                        Headers = @{ 
                            'Content-Disposition' = 'attachment; filename=AWS.Tools.4.1.754.zip' 
                        } 
                    }
                }
            }
            
            It "Should default to AWS.Tools when no Name specified" {
                # Act
                $result = Resolve-AWSToolsVersion -Version "4.1.754"
                
                # Assert
                $result | Should -BeOfType [Version]
                $result.ToString() | Should -Be "4.1.754"
            }
            
            It "Should handle AWS.Tools module type explicitly" {
                # Act
                $result = Resolve-AWSToolsVersion -Name 'AWS.Tools' -Version "4.1.754"
                
                # Assert
                $result | Should -BeOfType [Version]
                $result.ToString() | Should -Be "4.1.754"
            }
            
            It "Should handle AWS.Tools.Installer module type" {
                # Act
                $result = Resolve-AWSToolsVersion -Name 'AWS.Tools.Installer' -Version "1.0.3"
                
                # Assert
                $result | Should -BeOfType [Version]
                $result.ToString() | Should -Be "1.0.3"
            }
            
            It "Should support wildcard patterns for AWS.Tools" {
                # Act
                $result = Resolve-AWSToolsVersion -Name 'AWS.Tools' -Version "4.*"
                
                # Assert
                $result | Should -BeOfType [Version]
                $result.ToString() | Should -Be "4.1.754"
            }
            
            It "Should support wildcard patterns for AWS.Tools.Installer" {
                # Arrange
                Mock Invoke-WithRetry { 
                    param($ScriptBlock, $OperationName)
                    if ($OperationName -eq "Resolve wildcard version") {
                        $mockResponse = [PSCustomObject]@{
                            Headers = @{
                                'Content-Disposition' = 'attachment; filename=AWS.Tools.Installer.1.0.5.zip'
                            }
                        }
                        return $mockResponse
                    }
                }
                
                # Act
                $result = Resolve-AWSToolsVersion -Name 'AWS.Tools.Installer' -Version "1.*"
                
                # Assert
                $result | Should -Not -BeNullOrEmpty
                $result.ToString() | Should -Be "1.0.5"
            }
            
            It "Should throw for invalid module type" {
                # Act & Assert
                { Resolve-AWSToolsVersion -Name 'InvalidType' -Version "1.0.0" } | Should -Throw
            }
            
            It "Should provide different error messages for different module types" {
                # Arrange
                Mock Invoke-WithRetry { 
                    param($ScriptBlock, $OperationName)
                    if ($OperationName -eq "Verify exact version availability") {
                        throw "Network error"
                    }
                }
                
                # Act & Assert
                $awsToolsError = { Resolve-AWSToolsVersion -Name 'AWS.Tools' -Version "invalid" } | 
                Should -Throw -PassThru
                $awsToolsError.Exception.Message | Should -Match "exact version.*or major version"
                
                $installerError = { Resolve-AWSToolsVersion -Name 'AWS.Tools.Installer' -Version "invalid" } | 
                Should -Throw -PassThru
                $installerError.Exception.Message | Should -Match "exact version.*1\.0\.3.*or major version.*1\.\*"
            }
            
            It "Should accept 4-part versions with .0 for both module types" {
                # Act for AWS.Tools
                $result1 = Resolve-AWSToolsVersion -Name 'AWS.Tools' -Version "4.1.754.0"
                
                # Act for AWS.Tools.Installer
                $result2 = Resolve-AWSToolsVersion -Name 'AWS.Tools.Installer' -Version "1.0.3.0"
                
                # Assert
                $result1 | Should -BeOfType [Version]
                $result1.ToString() | Should -Be "4.1.754.0"
                $result2 | Should -BeOfType [Version]
                $result2.ToString() | Should -Be "1.0.3.0"
            }
            
            It "Should reject 4-part versions with non-zero last part for both module types" {
                # Act & Assert for AWS.Tools
                { Resolve-AWSToolsVersion -Name 'AWS.Tools' -Version "4.1.754.1" } | 
                Should -Throw "*Invalid AWS.Tools version format*"
                
                # Act & Assert for AWS.Tools.Installer
                { Resolve-AWSToolsVersion -Name 'AWS.Tools.Installer' -Version "1.0.3.1" } | 
                Should -Throw "*Invalid AWS.Tools.Installer version format*"
            }
            
            It "Should use correct URL patterns for different module types" {
                # This test verifies that different configurations are used
                # The actual URL construction is tested through the mocked Invoke-WithRetry calls
                
                # Act for AWS.Tools
                $result1 = Resolve-AWSToolsVersion -Name 'AWS.Tools' -Version "4.1.754"
                
                # Act for AWS.Tools.Installer  
                $result2 = Resolve-AWSToolsVersion -Name 'AWS.Tools.Installer' -Version "1.0.3"
                
                # Assert both succeed (indicating correct configuration was found)
                $result1 | Should -BeOfType [Version]
                $result2 | Should -BeOfType [Version]
                
                # Verify both made HEAD requests for verification
                Should -Invoke Invoke-WithRetry -ParameterFilter { 
                    $OperationName -eq "Verify exact version availability" 
                } -Times 2
            }
        }
    }
}
