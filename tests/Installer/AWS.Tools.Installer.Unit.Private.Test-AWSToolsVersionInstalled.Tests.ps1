BeforeDiscovery {
    Import-Module (Join-Path $PSScriptRoot "../../modules/Installer/AWS.Tools.Installer.psd1") -Force
}

BeforeAll {
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
}

Describe -Tag "Smoke", "Low", "Medium", "High" "Installer - Test-AWSToolsVersionInstalled Unit Tests" {
    
    Context "Version Checking" {
        It "Should return false when Force is specified" {
            InModuleScope AWS.Tools.Installer {
                # Arrange
                Mock Invoke-WebRequest { }
                Mock Get-AWSToolsModule { }
                
                # Act
                $testPath = Join-Path ([System.IO.Path]::GetTempPath()) "Test"
                $result = Test-AWSToolsVersionInstalled -TargetPath $testPath -Force
                
                # Assert
                $result | Should -Be $false
            }
        }
        
        It "Should check version via web request" {
            InModuleScope AWS.Tools.Installer {
                # Arrange
                $testPath = Join-Path ([System.IO.Path]::GetTempPath()) "Test"
                $script:VersionCache = @{}  # Clear cache
                
                # Mock the HTTP status code wrapper instead of Invoke-WebRequest directly
                Mock Invoke-WebRequestWithStatusHandling { 
                    return @{
                        Success = $true
                        StatusCode = 200
                        RawResponse = @{ Headers = @{ 'Content-Disposition' = 'attachment; filename=AWS.Tools.4.1.853.zip' } }
                    }
                } -ParameterFilter { $Uri -like "*v4/latest*" -or $Uri -like "*v5/latest*" }
                
                # Mock Invoke-WithRetry to return the successful response
                Mock Invoke-WithRetry { 
                    param($ScriptBlock)
                    return & $ScriptBlock
                }
                
                Mock Get-AWSToolsModule { @([PSCustomObject]@{ Name = "AWS.Tools.Common"; Version = [Version]"4.1.853" }) }
                
                # Act
                $result = Test-AWSToolsVersionInstalled -TargetPath $testPath
                
                # Assert
                Should -Invoke Invoke-WithRetry -Times 1
                Should -Invoke Get-AWSToolsModule -Times 1
            }
        }
        
        It "Should handle network errors gracefully" {
            InModuleScope AWS.Tools.Installer {
                # Arrange
                $testPath = Join-Path ([System.IO.Path]::GetTempPath()) "Test"
                $script:VersionCache = @{}  # Clear cache
                Mock Invoke-WebRequest { throw "Network timeout" }
                
                # Act
                $result = Test-AWSToolsVersionInstalled -TargetPath $testPath -WarningAction 'SilentlyContinue'
                
                # Assert
                $result | Should -Be $false
            }
        }
        
        It "Should validate absolute path" {
            InModuleScope AWS.Tools.Installer {
                # Act & Assert
                { Test-AWSToolsVersionInstalled -TargetPath "relative\path" } | Should -Throw "*must be an absolute path*"
            }
        }
        
        It "Should validate minimum version" {
            InModuleScope AWS.Tools.Installer {
                # Arrange
                $testPath = Join-Path ([System.IO.Path]::GetTempPath()) "Test"
                
                # Act & Assert
                { Test-AWSToolsVersionInstalled -TargetPath $testPath -Version ([Version]"3.0.0") } | Should -Throw "*must be 4.0.0 or higher*"
            }
        }
        
        It "Should use cached version on subsequent calls" {
            InModuleScope AWS.Tools.Installer {
                # Arrange
                $testPath = Join-Path ([System.IO.Path]::GetTempPath()) "Test"
                $script:VersionCache = @{ "AWS.Tools-latest" = "4.1.853" }
                Mock Get-AWSToolsModule { @([PSCustomObject]@{ Name = "AWS.Tools.Common"; Version = [Version]"4.1.853" }) }
                
                # Act
                $result = Test-AWSToolsVersionInstalled -TargetPath $testPath
                
                # Assert - Should use cached version and return true
                $result | Should -Be $true
            }
        }
        
        It "Should return true when versions match" {
            InModuleScope AWS.Tools.Installer {
                # Arrange
                $testPath = Join-Path ([System.IO.Path]::GetTempPath()) "Test"
                Mock Invoke-WithRetry { 
                    @{ Headers = @{ 'Content-Disposition' = 'attachment; filename=AWS.Tools.4.1.853.zip' } } 
                }
                Mock Get-AWSToolsModule { @([PSCustomObject]@{ Name = "AWS.Tools.Common"; Version = [Version]"4.1.853" }) }
                
                # Act
                $result = Test-AWSToolsVersionInstalled -TargetPath $testPath
                
                # Assert
                $result | Should -Be $true
            }
        }
        
        It "Should return false when versions don't match" {
            InModuleScope AWS.Tools.Installer {
                # Arrange
                $testPath = Join-Path ([System.IO.Path]::GetTempPath()) "Test"
                $script:VersionCache = @{}  # Clear cache
                Mock Invoke-WebRequest { @{ Headers = @{ 'Content-Disposition' = 'attachment; filename=AWS.Tools.4.1.854.zip' } } }
                Mock Get-AWSToolsModule { @([PSCustomObject]@{ Name = "AWS.Tools.Common"; Version = [Version]"4.1.853" }) }
                
                # Act
                $result = Test-AWSToolsVersionInstalled -TargetPath $testPath
                
                # Assert
                $result | Should -Be $false
            }
        }
    }
}
