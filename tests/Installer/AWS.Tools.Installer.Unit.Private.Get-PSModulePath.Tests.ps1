BeforeDiscovery {
    Import-Module (Join-Path $PSScriptRoot "../../modules/Installer/AWS.Tools.Installer.psd1") -Force
}

BeforeAll {
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
}

InModuleScope AWS.Tools.Installer {
    Describe -Tag "Smoke", "Low", "Medium", "High" "Installer - Get-PSModulePath Unit Tests" {
    
        Context "Windows Platform" {
        
            It "Should return AllUsers path on Windows with PowerShell Core" {
                # Arrange
                $programFiles = [System.Environment]::GetFolderPath([System.Environment+SpecialFolder]::ProgramFiles)
                $expectedPath = '{0}\PowerShell\Modules' -f $programFiles
                
                # Act
                $result = Get-PSModulePath -Scope 'AllUsers' -OperatingSystem 'Win32NT' -IfCoreCLR $true -ErrorAction SilentlyContinue
                
                # Assert
                $result | Should -Be $expectedPath
            }
            
            It "Should return AllUsers path on Windows with Windows PowerShell" {
                # Arrange
                $programFiles = [System.Environment]::GetFolderPath([System.Environment+SpecialFolder]::ProgramFiles)
                $expectedPath = '{0}\WindowsPowerShell\Modules' -f $programFiles
                
                # Act
                $result = Get-PSModulePath -Scope 'AllUsers' -OperatingSystem 'Win32NT' -IfCoreCLR $false -ErrorAction SilentlyContinue
                
                # Assert
                $result | Should -Be $expectedPath
            }
            
            It "Should return CurrentUser path on Windows with PowerShell Core" {
                # Arrange
                $testHomePath = Join-Path -Path $HOME -ChildPath "Documents"
                $expectedPath = '{0}\PowerShell\Modules' -f $testHomePath
                
                # Act
                $result = Get-PSModulePath -Scope 'CurrentUser' -OperatingSystem 'Win32NT' -IfCoreCLR $true -HomePath $testHomePath -ErrorAction 'SilentlyContinue'
                
                # Assert
                $result | Should -Be $expectedPath
            }
            
            It "Should return CurrentUser path on Windows with Windows PowerShell" {
                # Arrange
                $testHomePath = Join-Path -Path $HOME -ChildPath "Documents"
                $expectedPath = '{0}\WindowsPowerShell\Modules' -f $testHomePath
                
                # Act
                $result = Get-PSModulePath -Scope 'CurrentUser' -OperatingSystem 'Win32NT' -IfCoreCLR $false -HomePath $testHomePath -ErrorAction 'SilentlyContinue'
                
                # Assert
                $result | Should -Be $expectedPath
            }
        }
        
        Context "Non-Windows Platforms (Linux, macOS, Unix)" {
        
            It "Should return AllUsers path on Unix systems" {
                # Act
                $result = Get-PSModulePath -Scope 'AllUsers' -OperatingSystem 'Unix' -IfCoreCLR $true -PSModulePath '/usr/local/share/powershell/Modules'
                
                # Assert
                $result | Should -Be '/usr/local/share/powershell/Modules'
            }
            
            It "Should return CurrentUser path on Unix systems" {
                # Arrange
                $testHomePath = "/home/testuser"
                
                # Act
                $result = Get-PSModulePath -Scope 'CurrentUser' -OperatingSystem 'Unix' -IfCoreCLR $true -HomePath $testHomePath -PSModulePath '/home/testuser/.local/share/powershell/Modules'
                
                # Assert
                $result | Should -Be '/home/testuser/.local/share/powershell/Modules'
            }
            
            It "Should handle macOS the same as other Unix systems" {
                # Arrange
                $testHomePath = "/Users/testuser"
                
                # Act
                $result = Get-PSModulePath -Scope 'CurrentUser' -OperatingSystem 'MacOSX' -IfCoreCLR $true -HomePath $testHomePath -PSModulePath '/Users/testuser/.local/share/powershell/Modules'
                
                # Assert
                $result | Should -Be '/Users/testuser/.local/share/powershell/Modules'
            }
            
            It "Should return Lambda path when IfLambda is true" {
                # Act
                $result = Get-PSModulePath -Scope 'CurrentUser' -OperatingSystem 'Unix' -IfCoreCLR $true -IfLambda $true -PSModulePath '/tmp/powershell/modules'
                
                # Assert
                $result | Should -Be '/tmp/powershell/modules'
            }
        }
        
        Context "Cross-Platform Compatibility" {
        
            It "Should handle different operating systems without throwing" {
                # Act & Assert - Test that function accepts various OS parameters without error
                { Get-PSModulePath -Scope 'CurrentUser' -OperatingSystem 'Unix' -IfCoreCLR $true -HomePath '/home/testuser' -PSModulePath '/usr/local/share/powershell/Modules' -ErrorAction SilentlyContinue } | Should -Not -Throw
                { Get-PSModulePath -Scope 'AllUsers' -OperatingSystem 'Unix' -IfCoreCLR $true -PSModulePath '/usr/local/share/powershell/Modules' } | Should -Not -Throw
                { Get-PSModulePath -Scope 'CurrentUser' -OperatingSystem 'MacOSX' -IfCoreCLR $true -HomePath '/Users/testuser' -PSModulePath '/Users/testuser/.local/share/powershell/Modules' -ErrorAction SilentlyContinue } | Should -Not -Throw
            }
            
            It "Should return correct paths for different platforms without throwing exceptions" {
                # Act & Assert - Windows should return Windows-style path
                $windowsResult = Get-PSModulePath -Scope 'CurrentUser' -OperatingSystem 'Win32NT' -IfCoreCLR $true -HomePath 'C:\Users\TestUser\Documents' -PSModulePath 'C:\Path1;C:\Path2' -ErrorAction SilentlyContinue
                $windowsResult | Should -Be 'C:\Users\TestUser\Documents\PowerShell\Modules'
                
                # Act & Assert - Unix should return Unix-style path
                $unixResult = Get-PSModulePath -Scope 'CurrentUser' -OperatingSystem 'Unix' -IfCoreCLR $true -HomePath '/home/testuser' -PSModulePath '/path1:/path2' -ErrorAction SilentlyContinue
                $unixResult | Should -Be '/home/testuser/.local/share/powershell/Modules'
                
                # Assert - Functions should not throw exceptions
                { Get-PSModulePath -Scope 'CurrentUser' -OperatingSystem 'Win32NT' -IfCoreCLR $true -PSModulePath 'C:\Path1;C:\Path2' -ErrorAction SilentlyContinue } | Should -Not -Throw
                { Get-PSModulePath -Scope 'CurrentUser' -OperatingSystem 'Unix' -IfCoreCLR $true -PSModulePath '/path1:/path2' -ErrorAction SilentlyContinue } | Should -Not -Throw
            }
        }
    }
}
