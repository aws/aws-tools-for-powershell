BeforeAll {
    # Import the module under test
    $module = Import-Module (Join-Path -Path $PSScriptRoot -ChildPath ".." | Join-Path -ChildPath ".." | Join-Path -ChildPath "modules" | Join-Path -ChildPath "Installer" | Join-Path -ChildPath "AWS.Tools.Installer.psd1") -Force -PassThru
    
    # Set required variables for cross-platform compatibility
    if (-not (Get-Variable -Name IsCoreCLR -ErrorAction SilentlyContinue)) {
        $global:IsCoreCLR = $PSVersionTable.PSEdition -eq 'Core'
    }
    
    # Download AWS.Tools.zip once for all tests
    $script:CachedZipPath = Join-Path ([System.IO.Path]::GetTempPath()) "AWS.Tools.zip"
    if (-not (Test-Path $script:CachedZipPath)) {
        & $module Get-AWSToolsZip -Path $script:CachedZipPath
    }

    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
    $WarningPreference = 'SilentlyContinue'
    $InformationPreference = 'Ignore'
}

Describe -Tag "Smoke", "Medium", "High" "Installer - Integration Tests" {
    
    
    Context "Module Installation" {

        
        It "Should generate PSGetModuleInfo.xml compatible with Uninstall-Module" {
            # Arrange
            $testModulePath = Join-Path $TestDrive "TestModules"
            $originalPSModulePath = $env:PSModulePath
            
            try {
                # Add test path to PSModulePath so modules can be discovered
                $env:PSModulePath = "$testModulePath$([System.IO.Path]::PathSeparator)$env:PSModulePath"
                
                # Install modules - this should succeed without errors
                { Install-AWSToolsModule -Name @('Common') -SourceZipPath $script:CachedZipPath -Path $testModulePath -Confirm:$false -Force } | Should -Not -Throw
                
                # Verify module was actually installed
                $commonPath = Join-Path $testModulePath "AWS.Tools.Common"
                Test-Path $commonPath | Should -Be $true
                
                # Verify PSGetModuleInfo.xml was created
                $infoXmlPath = Get-ChildItem -Path $commonPath -Recurse -Filter "PSGetModuleInfo.xml" -Force | Select-Object -First 1
                $infoXmlPath | Should -Not -BeNullOrEmpty
                Test-Path $infoXmlPath.FullName | Should -Be $true
                
                # Act & Assert - Should be able to uninstall installed modules
                { Uninstall-Module AWS.Tools.Common -ErrorAction SilentlyContinue -Confirm:$false } | Should -Not -Throw
            }
            finally {
                # Restore original PSModulePath
                $env:PSModulePath = $originalPSModulePath
            }
        }
        
        It "Should generate PSGetModuleInfo.xml compatible with Uninstall-PSResource" {
            
            # Arrange
            $testModulePath = Join-Path $TestDrive "TestModules"
            $originalPSModulePath = $env:PSModulePath
            
            try {
                # Add test path to PSModulePath so modules can be discovered
                $env:PSModulePath = "$testModulePath$([System.IO.Path]::PathSeparator)$env:PSModulePath"
                
                # Install modules - this should succeed without errors
                { Install-AWSToolsModule -Name @('Common') -SourceZipPath $script:CachedZipPath -Path $testModulePath -Confirm:$false } | Should -Not -Throw
                
                # Verify module was actually installed
                $commonPath = Join-Path $testModulePath "AWS.Tools.Common"
                Test-Path $commonPath | Should -Be $true
                
                # Verify PSGetModuleInfo.xml was created
                $infoXmlPath = Get-ChildItem -Path $commonPath -Recurse -Filter "PSGetModuleInfo.xml" -Force | Select-Object -First 1
                $infoXmlPath | Should -Not -BeNullOrEmpty
                Test-Path $infoXmlPath.FullName | Should -Be $true
                
                # Act & Assert - Should be able to uninstall with Uninstall-PSResource
                { Uninstall-PSResource -Name AWS.Tools.Common -ErrorAction SilentlyContinue } | Should -Not -Throw
            }
            finally {
                # Restore original PSModulePath
                $env:PSModulePath = $originalPSModulePath
            }
        }
        
        
        It "Should detect installed version in custom path" {
            # Arrange
            $testModulePath = Join-Path $TestDrive "TestModules"
            $originalPSModulePath = $env:PSModulePath
            
            try {
                # Add test path to PSModulePath so modules can be imported
                $env:PSModulePath = "$testModulePath$([System.IO.Path]::PathSeparator)$env:PSModulePath"
                
                # Install modules first
                Install-AWSToolsModule -Name @('Common', 'CloudWatch', 'DynamoDBv2') -SourceZipPath $script:CachedZipPath -Path $testModulePath -Confirm:$false
                
                # Verify modules were installed
                $commonPath = Join-Path $testModulePath "AWS.Tools.Common"
                $cloudWatchPath = Join-Path $testModulePath "AWS.Tools.CloudWatch"
                $dynamoDBPath = Join-Path $testModulePath "AWS.Tools.DynamoDBv2"
                
                Test-Path $commonPath | Should -Be $true
                Test-Path $cloudWatchPath | Should -Be $true
                Test-Path $dynamoDBPath | Should -Be $true
                
                # Verify modules can be imported successfully using jobs to avoid DLL locking
                $importJob = Start-Job -ScriptBlock {
                    param($ModulePath)
                    
                    # Set PSModulePath in the job context
                    $env:PSModulePath = "$ModulePath$([System.IO.Path]::PathSeparator)$env:PSModulePath"
                    
                    try {
                        # Import modules
                        Import-Module AWS.Tools.Common -Force -ErrorAction Stop
                        Import-Module AWS.Tools.CloudWatch -Force -ErrorAction Stop  
                        Import-Module AWS.Tools.DynamoDBv2 -Force -ErrorAction Stop
                        
                        # Verify modules are loaded
                        $commonModule = Get-Module AWS.Tools.Common
                        $cloudWatchModule = Get-Module AWS.Tools.CloudWatch
                        $dynamoDBModule = Get-Module AWS.Tools.DynamoDBv2
                        
                        # Verify key cmdlets are available
                        $commonCmdlets = Get-Command -Module AWS.Tools.Common -Name "Get-AWSCredential" -ErrorAction SilentlyContinue
                        $cloudWatchCmdlets = Get-Command -Module AWS.Tools.CloudWatch -Name "Get-CWMetric*" -ErrorAction SilentlyContinue
                        $dynamoDBCmdlets = Get-Command -Module AWS.Tools.DynamoDBv2 -Name "Get-DDBTable*" -ErrorAction SilentlyContinue
                        
                        return @{
                            Success = $true
                            CommonModule = ($commonModule -ne $null)
                            CloudWatchModule = ($cloudWatchModule -ne $null)
                            DynamoDBModule = ($dynamoDBModule -ne $null)
                            CommonCmdlets = ($commonCmdlets.Count -gt 0)
                            CloudWatchCmdlets = ($cloudWatchCmdlets.Count -gt 0)
                            DynamoDBCmdlets = ($dynamoDBCmdlets.Count -gt 0)
                        }
                    }
                    catch {
                        return @{
                            Success = $false
                            Error = $_.Exception.Message
                        }
                    }
                } -ArgumentList $testModulePath
                
                $importResult = $importJob | Wait-Job | Receive-Job
                $importJob | Remove-Job
                
                # Verify import results
                $importResult.Success | Should -Be $true
                $importResult.CommonModule | Should -Be $true
                $importResult.CloudWatchModule | Should -Be $true
                $importResult.DynamoDBModule | Should -Be $true
                $importResult.CommonCmdlets | Should -Be $true
                $importResult.CloudWatchCmdlets | Should -Be $true
                $importResult.DynamoDBCmdlets | Should -Be $true
            }
            finally {
                # Restore original PSModulePath
                $env:PSModulePath = $originalPSModulePath
                
                # Remove imported modules to clean up
                Remove-Module AWS.Tools.Common -Force -ErrorAction SilentlyContinue
                Remove-Module AWS.Tools.CloudWatch -Force -ErrorAction SilentlyContinue
                Remove-Module AWS.Tools.DynamoDBv2 -Force -ErrorAction SilentlyContinue
            }
        }
        
        It "Should uninstall modules from custom path" {
            # Arrange
            $testModulePath = Join-Path $TestDrive "TestModules"
            
            # Install modules first
            Install-AWSToolsModule -Name @('Common') -SourceZipPath $script:CachedZipPath -Path $testModulePath -Confirm:$false
            
            # Verify module was installed
            $commonPath = Join-Path $testModulePath "AWS.Tools.Common"
            Test-Path $commonPath | Should -Be $true
            
            # Act - Uninstall modules from custom path
            { Uninstall-AWSToolsModule -Path $testModulePath -Confirm:$false } | Should -Not -Throw
        }
        

    }
}
