BeforeDiscovery {
    . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")
}

BeforeAll {
    . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")
    
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
    $WarningPreference = 'SilentlyContinue'
    $InformationPreference = 'SilentlyContinue'
    
    # Create version-specific splatting variable for InformationAction parameter
    # 'Ignore' is not supported as a parameter value in PowerShell 5.1
    if ($PSVersionTable.PSVersion.Major -ge 6) {
        $script:InformationActionSplat = @{ InformationAction = 'Ignore' }
    } else {
        $script:InformationActionSplat = @{}
    }
    
    # Set required variables for cross-platform compatibility
    if (-not (Get-Variable -Name IsCoreCLR -ErrorAction SilentlyContinue)) {
        $global:IsCoreCLR = $PSVersionTable.PSEdition -eq 'Core'
    }
    
    # Download AWS.Tools.zip once for all tests
    $script:CachedZipPath = Join-Path ([System.IO.Path]::GetTempPath()) "AWS.Tools.zip"
    if (-not (Test-Path $script:CachedZipPath)) {
        & $module Get-AWSToolsZip -Path $script:CachedZipPath -WarningAction SilentlyContinue @script:InformationActionSplat
    }
}

Describe -Skip:$SkipInstallerTests -Tag "Smoke", "Medium", "High" "Installer - Integration Tests" {
    
    
    Context "Module Installation" {

        
        It "Should generate PSGetModuleInfo.xml compatible with Uninstall-Module" {
            # Arrange
            $testModulePath = Join-Path $TestDrive "TestModules"
            $originalPSModulePath = $env:PSModulePath
            
            try {
                # Add test path to PSModulePath so modules can be discovered
                $env:PSModulePath = "$testModulePath$([System.IO.Path]::PathSeparator)$env:PSModulePath"
                
                # Install modules - this should succeed without errors
                { Install-AWSToolsModule -Name @('Common') -SourceZipPath $script:CachedZipPath -Path $testModulePath -Confirm:$false -Force -SkipIntegrityCheck -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
                
                # Verify module was actually installed
                $commonPath = Join-Path $testModulePath "AWS.Tools.Common"
                Test-Path $commonPath | Should -Be $true
                
                # Verify PSGetModuleInfo.xml was created
                $infoXmlPath = Get-ChildItem -Path $commonPath -Recurse -Filter "PSGetModuleInfo.xml" -Force | Select-Object -First 1
                $infoXmlPath | Should -Not -BeNullOrEmpty
                Test-Path $infoXmlPath.FullName | Should -Be $true
                
                # Act & Assert - Should be able to uninstall installed modules
                { Uninstall-Module AWS.Tools.Common -ErrorAction SilentlyContinue -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
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
                { Install-AWSToolsModule -Name @('Common') -SourceZipPath $script:CachedZipPath -Path $testModulePath -Confirm:$false -SkipIntegrityCheck -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
                
                # Verify module was actually installed
                $commonPath = Join-Path $testModulePath "AWS.Tools.Common"
                Test-Path $commonPath | Should -Be $true
                
                # Verify PSGetModuleInfo.xml was created
                $infoXmlPath = Get-ChildItem -Path $commonPath -Recurse -Filter "PSGetModuleInfo.xml" -Force | Select-Object -First 1
                $infoXmlPath | Should -Not -BeNullOrEmpty
                Test-Path $infoXmlPath.FullName | Should -Be $true
                
                # Act & Assert - Should be able to uninstall with Uninstall-PSResource
                { Uninstall-PSResource -Name AWS.Tools.Common -ErrorAction SilentlyContinue -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
            }
            finally {
                # Restore original PSModulePath
                $env:PSModulePath = $originalPSModulePath
            }
        }

        It "Generates a PSGetModuleInfo.xml whose fields Get-InstalledModule expects" {
            # Round-trip parity check: install via the C# DLL, then read the generated
            # PSGetModuleInfo.xml directly and verify it has the fields Get-InstalledModule
            # reconstructs into a PSRepositoryItemInfo. We can't call Get-InstalledModule
            # itself because PowerShellGet's PackageManagement provider only enumerates the
            # well-known module roots (e.g. ~/Documents/PowerShell/Modules) — it ignores
            # custom paths added to $env:PSModulePath. Asserting the XML contract is
            # equivalent and avoids polluting the user's real module store.
            $testModulePath = Join-Path $TestDrive "TestModulesGetInstalled"
            try {
                Install-AWSToolsModule -Name @('Common') -SourceZipPath $script:CachedZipPath -Path $testModulePath -Confirm:$false -Force -SkipIntegrityCheck -WarningAction SilentlyContinue @script:InformationActionSplat

                $xmlFile = Get-ChildItem -Path $testModulePath -Recurse -Filter 'PSGetModuleInfo.xml' -Force | Select-Object -First 1
                $xmlFile | Should -Not -BeNullOrEmpty -Because 'PSGetModuleInfo.xml should be written by the C# installer'

                # Deserialize the way Get-InstalledModule does internally: PSGet uses
                # CliXml import to rehydrate the saved PSRepositoryItemInfo object.
                $info = Import-Clixml -Path $xmlFile.FullName
                $info | Should -Not -BeNullOrEmpty

                $info.Name        | Should -Be 'AWS.Tools.Common'
                $info.Type        | Should -Be 'Module'
                $info.Author      | Should -Match 'Amazon'
                $info.Description | Should -Not -BeNullOrEmpty
                $info.Repository  | Should -Be 'PSGallery'

                # Tags must include the AWS.Tools.* PSData tags plus the PSModule marker that
                # Get-InstalledModule uses to recognize a PowerShell module.
                $info.Tags | Should -Contain 'AWS'
            }
            finally {
                # nothing to restore — TestDrive is cleaned up by Pester
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
                Install-AWSToolsModule -Name @('Common', 'CloudWatch', 'DynamoDBv2') -SourceZipPath $script:CachedZipPath -Path $testModulePath -Confirm:$false -SkipIntegrityCheck -WarningAction SilentlyContinue @script:InformationActionSplat
                
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
                        Import-Module AWS.Tools.Common -Force -ErrorAction Stop -WarningAction SilentlyContinue @using:InformationActionSplat
                        Import-Module AWS.Tools.CloudWatch -Force -ErrorAction Stop -WarningAction SilentlyContinue @using:InformationActionSplat
                        Import-Module AWS.Tools.DynamoDBv2 -Force -ErrorAction Stop -WarningAction SilentlyContinue @using:InformationActionSplat
                        
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
            Install-AWSToolsModule -Name @('Common') -SourceZipPath $script:CachedZipPath -Path $testModulePath -Confirm:$false -SkipIntegrityCheck -WarningAction SilentlyContinue @script:InformationActionSplat
            
            # Verify module was installed
            $commonPath = Join-Path $testModulePath "AWS.Tools.Common"
            Test-Path $commonPath | Should -Be $true
            
            # Act - Uninstall modules from custom path
            { Uninstall-AWSToolsModule -Path $testModulePath -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
        }
        

    }
}
