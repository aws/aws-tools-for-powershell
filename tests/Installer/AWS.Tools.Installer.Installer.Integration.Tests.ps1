BeforeDiscovery {
    . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")
}

BeforeAll {
    . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")
    
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
    $WarningPreference = 'SilentlyContinue'
    $InformationPreference = 'Ignore'

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
    
    # Download AWS.Tools.Installer.zip once for all tests
    # TODO: Update to no longer target 1.* after AWS.Tools.Installer 2.0.0 reaches GA
    # Currently downloading latest available version (which will be 1.x until 2.0.0 is published)
    $script:CachedZipPath = [System.IO.Path]::Combine([System.IO.Path]::GetTempPath(), "AWS.Tools.Installer.zip")
    if (-not (Test-Path $script:CachedZipPath)) {
        try {
            Write-Verbose "Downloading latest AWS.Tools.Installer.zip to: $script:CachedZipPath"
            & $module Get-AWSToolsZip -Version 1.0.3 -Name 'AWS.Tools.Installer' -Path $script:CachedZipPath -WarningAction SilentlyContinue @script:InformationActionSplat
            
            # Verify the file was actually created
            if (-not (Test-Path $script:CachedZipPath)) {
                throw "AWS.Tools.Installer.zip download completed but file not found at expected location: $script:CachedZipPath"
            }
            
            # Verify the file is not empty
            $fileInfo = Get-Item $script:CachedZipPath
            if ($fileInfo.Length -eq 0) {
                throw "AWS.Tools.Installer.zip download completed but file is empty: $script:CachedZipPath"
            }
            
            Write-Verbose "Successfully downloaded AWS.Tools.Installer.zip ($($fileInfo.Length) bytes)"
        }
        catch {
            Write-Error "Failed to download AWS.Tools.Installer.zip for integration tests: $($_.Exception.Message)"
            Write-Error "Stack trace: $($_.Exception.StackTrace)"
            throw
        }
    }
    else {
        Write-Verbose "Using existing cached AWS.Tools.Installer.zip: $script:CachedZipPath"
    }
    
    # Capture current system state of AWS.Tools.Installer installations before running tests
    Write-Verbose "Capturing current AWS.Tools module state..."
    $script:OriginalModules = Get-Module AWS.Tools.Installer -ListAvailable | ForEach-Object {
        @{
            Name       = $_.Name
            Version    = $_.Version
            ModuleBase = $_.ModuleBase
            Scope      = if ($_.ModuleBase -like "*$env:USERPROFILE*") { "CurrentUser" } else { "AllUsers" }
        }
    }
        
    Write-Verbose "Original modules found: $($script:OriginalModules.Count)"
    $script:OriginalModules | ForEach-Object { 
        Write-Verbose "  - $($_.Name) $($_.Version) [$($_.Scope)]"
    }
}

AfterAll {
    # Restore original system state after all tests complete
    Write-Verbose "Restoring original AWS.Tools module state..."
    
    # Remove any AWS.Tools.Installer modules that weren't there originally
    $currentModules = Get-Module AWS.Tools.Installer -ListAvailable
    foreach ($currentModule in $currentModules) {
        $wasOriginal = $script:OriginalModules | Where-Object { 
            $_.Name -eq $currentModule.Name -and 
            $_.Version -eq $currentModule.Version -and
            $_.ModuleBase -eq $currentModule.ModuleBase 
        }
        
        if (-not $wasOriginal) {
            Write-Verbose "  Removing extra module: $($currentModule.Name) $($currentModule.Version)"
            try {
                $moduleName = $currentModule.Name.Replace('AWS.Tools.', '')
                Uninstall-AWSToolsModule -Name @($moduleName) -Confirm:$false -ErrorAction SilentlyContinue -WarningAction SilentlyContinue @script:InformationActionSplat
            }
            catch {
                Write-Warning "Failed to remove $($currentModule.Name): $($_.Exception.Message)"
            }
        }
    }
    
    # Reinstall any original installer modules that are now missing
    $currentModulesAfterCleanup = Get-Module AWS.Tools.Installer -ListAvailable
    $missingModules = @()
    
    foreach ($originalModule in $script:OriginalModules) {
        $stillExists = $currentModulesAfterCleanup | Where-Object { 
            $_.Name -eq $originalModule.Name -and 
            $_.Version -eq $originalModule.Version -and
            $_.ModuleBase -eq $originalModule.ModuleBase 
        }
        
        if (-not $stillExists) {
            $missingModules += $originalModule
        }
    }
    
    if ($missingModules.Count -gt 0) {
        # Group missing modules by version and scope for efficient restoration
        $restorationGroups = $missingModules | Group-Object { "$($_.Version)|$($_.Scope)" }
        
        foreach ($group in $restorationGroups) {
            $versionAndScope = $group.Name.Split('|')
            $version = $versionAndScope[0]
            $scope = $versionAndScope[1]
            $moduleNames = $group.Group | ForEach-Object { $_.Name.Replace('AWS.Tools.', '') }
            
            Write-Verbose "  Restoring missing modules (v$version, $scope scope): $($moduleNames -join ', ')"
            try {
                Install-AWSToolsModule -Name $moduleNames -Version $version -Scope $scope -Confirm:$false -ErrorAction SilentlyContinue -WarningAction SilentlyContinue @script:InformationActionSplat
            }
            catch {
                Write-Warning "Failed to restore modules $($moduleNames -join ', '): $($_.Exception.Message)"
            }
        }
    }
    
    Write-Verbose "System state restoration completed"
    
    # Clean up cached zip file
    if (Test-Path $script:CachedZipPath) {
        Remove-Item $script:CachedZipPath -Force -ErrorAction SilentlyContinue
    }
}

InModuleScope AWS.Tools.Installer {
    # Create version-specific splatting variable for InformationAction parameter
    # 'Ignore' is not supported as a parameter value in PowerShell 5.1
    # This must be inside InModuleScope for PowerShell 5.1 compatibility
    if ($PSVersionTable.PSVersion.Major -ge 6) {
        $script:InformationActionSplat = @{ InformationAction = 'Ignore' }
    } else {
        $script:InformationActionSplat = @{}
    }
    
    # TODO: Update to target version 2.* after AWS.Tools.Installer 2.0.0 reaches GA and is published to CloudFront.
    # Currently targeting 1.* to provide integration test coverage while 2.0.0 is in development.
    Describe -Skip:$SkipInstallerTests -Tag "Smoke", "Medium", "High" "Installer-Installer - Integration Tests" {
        Context "Installer Module Management" {
            
            It "Should install AWS.Tools.Installer from CloudFront" {
                # Arrange
                $testModulePath = [System.IO.Path]::Combine($TestDrive, "TestInstallerModules")
                
                try {
                    # Act - Install installer module to custom path (targeting version 1.*)
                    { Install-AWSToolsInstaller -Version '1.*' -Path $testModulePath -Confirm:$false -Force -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
                    
                    # Assert - Verify installer module was installed
                    $installerPath = [System.IO.Path]::Combine($testModulePath, "AWS.Tools.Installer")
                    Test-Path $installerPath | Should -Be $true
                    
                    # Verify PSGetModuleInfo.xml was created
                    $infoXmlPath = Get-ChildItem -Path $installerPath -Recurse -Filter "PSGetModuleInfo.xml" -Force | Select-Object -First 1
                    $infoXmlPath | Should -Not -BeNullOrEmpty
                    Test-Path $infoXmlPath.FullName | Should -Be $true
                    
                    # Verify module can be imported
                    $installerModule = Get-ChildItem -Path $installerPath -Recurse -Filter "AWS.Tools.Installer.psd1" | Select-Object -First 1
                    { Import-Module $installerModule.FullName -Force -ErrorAction Stop -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
                }
                finally {
                    # Clean up
                    if (Test-Path $testModulePath) {
                        Remove-Item -Path $testModulePath -Recurse -Force -ErrorAction SilentlyContinue
                    }
                    Remove-Module AWS.Tools.Installer -Force -ErrorAction SilentlyContinue
                }
            }
            
            It "Should install AWS.Tools.Installer from local zip file" {
                # Arrange
                $testModulePath = [System.IO.Path]::Combine($TestDrive, "TestInstallerModulesLocal")
                
                # Create a mock AWS.Tools.Installer.zip for testing
                $tempZipPath = [System.IO.Path]::Combine($TestDrive, "AWS.Tools.Installer.zip")
                $tempExtractPath = [System.IO.Path]::Combine($TestDrive, "TempExtract")
                
                try {
                    # Create mock installer module structure
                    $mockInstallerPath = [System.IO.Path]::Combine($tempExtractPath, "AWS.Tools.Installer", "1.0.0")
                    New-Item -ItemType Directory -Path $mockInstallerPath -Force | Out-Null
                    
                    # Create minimal manifest file
                    $manifestContent = @"
@{
    ModuleVersion = '1.0.0'
    GUID = '450031c1-9177-4fc1-9518-93166b1a926b'
    Author = 'Amazon.com, Inc'
    CompanyName = 'Amazon.com, Inc'
    Description = 'Test AWS.Tools.Installer'
    PowerShellVersion = '5.1'
    FunctionsToExport = @()
}
"@
                    $manifestPath = [System.IO.Path]::Combine($mockInstallerPath, "AWS.Tools.Installer.psd1")
                    Set-Content -Path $manifestPath -Value $manifestContent
                    
                    # Create zip file
                    Compress-Archive -Path "$tempExtractPath\*" -DestinationPath $tempZipPath -Force -WarningAction SilentlyContinue @script:InformationActionSplat
                    
                    # Act - Install from local zip
                    { Install-AWSToolsInstaller -SourceZipPath $tempZipPath -Path $testModulePath -Confirm:$false -Force -SkipIntegrityCheck -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
                    
                    # Assert - Verify installer module was installed
                    $installerPath = [System.IO.Path]::Combine($testModulePath, "AWS.Tools.Installer")
                    Test-Path $installerPath | Should -Be $true
                }
                finally {
                    # Clean up
                    if (Test-Path $testModulePath) {
                        Remove-Item -Path $testModulePath -Recurse -Force -ErrorAction SilentlyContinue
                    }
                    if (Test-Path $tempZipPath) {
                        Remove-Item -Path $tempZipPath -Force -ErrorAction SilentlyContinue
                    }
                    if (Test-Path $tempExtractPath) {
                        Remove-Item -Path $tempExtractPath -Recurse -Force -ErrorAction SilentlyContinue
                    }
                }
            }
            
            It "Should uninstall AWS.Tools.Installer module" {
                # Arrange
                $testModulePath = [System.IO.Path]::Combine($TestDrive, "TestInstallerUninstall")
                
                try {
                    # Install installer module first (targeting version 1.*)
                    Install-AWSToolsInstaller -Version '1.*' -Path $testModulePath -Confirm:$false -Force -WarningAction SilentlyContinue @script:InformationActionSplat
                    
                    # Verify it was installed
                    $installerPath = [System.IO.Path]::Combine($testModulePath, "AWS.Tools.Installer")
                    Test-Path $installerPath | Should -Be $true
                    
                    # Act - Uninstall installer module
                    { Uninstall-AWSToolsInstaller -Path $testModulePath -Confirm:$false -WarningAction SilentlyContinue @script:InformationActionSplat } | Should -Not -Throw
                    
                    # Assert - Verify installer module was removed
                    Test-Path $installerPath | Should -Be $false
                }
                finally {
                    # Clean up
                    if (Test-Path $testModulePath) {
                        Remove-Item -Path $testModulePath -Recurse -Force -ErrorAction SilentlyContinue
                    }
                }
            }
        }
    }
}
