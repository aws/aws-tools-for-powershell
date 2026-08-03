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
    Describe -Skip:$SkipInstallerTests -Tag "Smoke", "Low", "Medium", "High" "Installer - ConvertTo-AWSToolsSemVer Private Function Tests" {
        
        Context "Standard Version Parsing" {
            It "Should parse standard 3-part version '5.0.0'" {
                # Act
                $result = ConvertTo-AWSToolsSemVer -VersionString "5.0.0"
                
                # Assert
                $result | Should -Not -BeNullOrEmpty
                $result.Version | Should -BeOfType [Version]
                $result.Version.ToString() | Should -Be "5.0.0"
                $result.Major | Should -Be 5
                $result.Minor | Should -Be 0
                $result.Build | Should -Be 0
                $result.PreReleaseTag | Should -BeNullOrEmpty
                $result.IsPreRelease | Should -Be $false
                $result.SemVerString | Should -Be "5.0.0"
            }
            
            It "Should parse standard version '4.1.754'" {
                # Act
                $result = ConvertTo-AWSToolsSemVer -VersionString "4.1.754"
                
                # Assert
                $result | Should -Not -BeNullOrEmpty
                $result.Version.ToString() | Should -Be "4.1.754"
                $result.Major | Should -Be 4
                $result.Minor | Should -Be 1
                $result.Build | Should -Be 754
                $result.IsPreRelease | Should -Be $false
            }
            
            It "Should handle version with leading/trailing whitespace" {
                # Act
                $result = ConvertTo-AWSToolsSemVer -VersionString "  5.0.0  "
                
                # Assert
                $result | Should -Not -BeNullOrEmpty
                $result.Version.ToString() | Should -Be "5.0.0"
                $result.SemVerString | Should -Be "5.0.0"
            }
        }
        
        Context "Preview/Prerelease Version Parsing" {
            It "Should parse preview version '5.0.0-preview001'" {
                # Act
                $result = ConvertTo-AWSToolsSemVer -VersionString "5.0.0-preview001"
                
                # Assert
                $result | Should -Not -BeNullOrEmpty
                $result.Version | Should -BeOfType [Version]
                $result.Version.ToString() | Should -Be "5.0.0"
                $result.Major | Should -Be 5
                $result.Minor | Should -Be 0
                $result.Build | Should -Be 0
                $result.PreReleaseTag | Should -Be "preview001"
                $result.IsPreRelease | Should -Be $true
                $result.SemVerString | Should -Be "5.0.0-preview001"
            }
            
            It "Should parse preview version '5.0.0-alpha'" {
                # Act
                $result = ConvertTo-AWSToolsSemVer -VersionString "5.0.0-alpha"
                
                # Assert
                $result | Should -Not -BeNullOrEmpty
                $result.PreReleaseTag | Should -Be "alpha"
                $result.IsPreRelease | Should -Be $true
            }
            
            It "Should parse preview version '5.0.0-beta1'" {
                # Act
                $result = ConvertTo-AWSToolsSemVer -VersionString "5.0.0-beta1"
                
                # Assert
                $result | Should -Not -BeNullOrEmpty
                $result.PreReleaseTag | Should -Be "beta1"
                $result.IsPreRelease | Should -Be $true
            }
            
            It "Should parse preview version '5.0.0-rc.1'" {
                # Act
                $result = ConvertTo-AWSToolsSemVer -VersionString "5.0.0-rc.1"
                
                # Assert
                $result | Should -Not -BeNullOrEmpty
                $result.PreReleaseTag | Should -Be "rc.1"
                $result.IsPreRelease | Should -Be $true
            }
            
            It "Should parse preview version with multiple dots '5.0.0-alpha.beta.1'" {
                # Act
                $result = ConvertTo-AWSToolsSemVer -VersionString "5.0.0-alpha.beta.1"
                
                # Assert
                $result | Should -Not -BeNullOrEmpty
                $result.PreReleaseTag | Should -Be "alpha.beta.1"
                $result.IsPreRelease | Should -Be $true
            }
            
            It "Should preserve full semver string for URL construction" {
                # Act
                $result = ConvertTo-AWSToolsSemVer -VersionString "5.0.0-preview001"
                
                # Assert
                $result.SemVerString | Should -Be "5.0.0-preview001"
            }
        }
        
        Context "Null and Empty Input Handling" {
            It "Should return null for null input" {
                # Act
                $result = ConvertTo-AWSToolsSemVer -VersionString $null
                
                # Assert
                $result | Should -BeNullOrEmpty
            }
            
            It "Should return null for empty string" {
                # Act
                $result = ConvertTo-AWSToolsSemVer -VersionString ""
                
                # Assert
                $result | Should -BeNullOrEmpty
            }
            
            It "Should return null for whitespace-only string" {
                # Act
                $result = ConvertTo-AWSToolsSemVer -VersionString "   "
                
                # Assert
                $result | Should -BeNullOrEmpty
            }
        }
        
        Context "Invalid Version Format Handling" {
            It "Should throw for 2-part version '5.0'" {
                # Act & Assert
                { ConvertTo-AWSToolsSemVer -VersionString "5.0" } | 
                Should -Throw "*Invalid version format*"
            }
            
            It "Should throw for 4-part version '5.0.0.0'" {
                # Act & Assert
                { ConvertTo-AWSToolsSemVer -VersionString "5.0.0.0" } | 
                Should -Throw "*Invalid version format*"
            }
            
            It "Should throw for non-numeric version 'invalid'" {
                # Act & Assert
                { ConvertTo-AWSToolsSemVer -VersionString "invalid" } | 
                Should -Throw "*Invalid version format*"
            }
            
            It "Should throw for version with invalid characters '5.0.0-preview@1'" {
                # Act & Assert
                { ConvertTo-AWSToolsSemVer -VersionString "5.0.0-preview@1" } | 
                Should -Throw "*Invalid version format*"
            }
            
            It "Should throw for version with empty prerelease tag '5.0.0-'" {
                # Act & Assert
                { ConvertTo-AWSToolsSemVer -VersionString "5.0.0-" } | 
                Should -Throw "*Invalid version format*"
            }
        }
        
        Context "Pipeline Input" {
            It "Should accept pipeline input" {
                # Act
                $result = "5.0.0-preview001" | ConvertTo-AWSToolsSemVer
                
                # Assert
                $result | Should -Not -BeNullOrEmpty
                $result.IsPreRelease | Should -Be $true
            }
            
            It "Should process multiple pipeline inputs" {
                # Act
                $results = @("5.0.0", "5.0.0-preview001") | ConvertTo-AWSToolsSemVer
                
                # Assert
                $results | Should -HaveCount 2
                $results[0].IsPreRelease | Should -Be $false
                $results[1].IsPreRelease | Should -Be $true
            }
        }
        
        Context "Edge Cases" {
            It "Should handle version with large numbers '999.999.999'" {
                # Act
                $result = ConvertTo-AWSToolsSemVer -VersionString "999.999.999"
                
                # Assert
                $result | Should -Not -BeNullOrEmpty
                $result.Major | Should -Be 999
                $result.Minor | Should -Be 999
                $result.Build | Should -Be 999
            }
            
            It "Should handle version '0.0.0'" {
                # Act
                $result = ConvertTo-AWSToolsSemVer -VersionString "0.0.0"
                
                # Assert
                $result | Should -Not -BeNullOrEmpty
                $result.Major | Should -Be 0
                $result.Minor | Should -Be 0
                $result.Build | Should -Be 0
            }
            
            It "Should handle preview version with numeric-only tag '5.0.0-123'" {
                # Act
                $result = ConvertTo-AWSToolsSemVer -VersionString "5.0.0-123"
                
                # Assert
                $result | Should -Not -BeNullOrEmpty
                $result.PreReleaseTag | Should -Be "123"
                $result.IsPreRelease | Should -Be $true
            }
        }
        
        Context "Version String Length Validation" {
            It "Should accept version string at exactly 64 characters" {
                # Arrange - Create a 64-character version string
                # Format: 5.0.0-<52 character prerelease tag> = 64 chars total
                $prereleaseTag = "a" * 52  # 52 characters
                $versionString = "5.0.0-$prereleaseTag"  # 5 + 1 + 52 = 64 characters
                
                # Act
                $result = ConvertTo-AWSToolsSemVer -VersionString $versionString
                
                # Assert
                $result | Should -Not -BeNullOrEmpty
                $result.Version.ToString() | Should -Be "5.0.0"
                $result.PreReleaseTag | Should -Be $prereleaseTag
                $result.IsPreRelease | Should -Be $true
            }
            
            It "Should throw for version string exceeding 64 characters" {
                # Arrange - Create a 65-character version string
                # Format: 5.0.0-<59 character prerelease tag> = 65 chars total
                $prereleaseTag = "a" * 59  # 59 characters
                $versionString = "5.0.0-$prereleaseTag"  # 6 + 59 = 65 characters
                
                # Act & Assert
                { ConvertTo-AWSToolsSemVer -VersionString $versionString } | 
                Should -Throw "*exceeds maximum length of 64 characters*"
            }
            
            It "Should throw for very long version string" {
                # Arrange - Create a 200-character version string
                $prereleaseTag = "a" * 194  # 194 characters
                $versionString = "5.0.0-$prereleaseTag"  # 6 + 194 = 200 characters
                
                # Act & Assert
                { ConvertTo-AWSToolsSemVer -VersionString $versionString } | 
                Should -Throw "*exceeds maximum length of 64 characters*"
            }
        }
    }
}
