BeforeAll {
    # Import the module under test
    $module = Import-Module (Join-Path -Path $PSScriptRoot -ChildPath ".." | Join-Path -ChildPath ".." | Join-Path -ChildPath "modules" | Join-Path -ChildPath "Installer" | Join-Path -ChildPath "AWS.Tools.Installer.psd1") -Force -PassThru
    
    $VerbosePreference = 'SilentlyContinue'
    $ProgressPreference = 'SilentlyContinue'
    $WarningPreference = 'SilentlyContinue'
    $InformationPreference = 'Ignore'

    # Set required variables for cross-platform compatibility
    if (-not (Get-Variable -Name IsCoreCLR -ErrorAction SilentlyContinue)) {
        $global:IsCoreCLR = $PSVersionTable.PSEdition -eq 'Core'
    }
    
    # Download AWS.Tools.zip once for all tests
    $script:CachedZipPath = Join-Path ([System.IO.Path]::GetTempPath()) "AWS.Tools.zip"
    if (-not (Test-Path $script:CachedZipPath)) {
        try {
            Write-Verbose "Downloading AWS.Tools.zip to: $script:CachedZipPath"
            & $module Get-AWSToolsZip -Path $script:CachedZipPath
            
            # Verify the file was actually created
            if (-not (Test-Path $script:CachedZipPath)) {
                throw "AWS.Tools.zip download completed but file not found at expected location: $script:CachedZipPath"
            }
            
            # Verify the file is not empty
            $fileInfo = Get-Item $script:CachedZipPath
            if ($fileInfo.Length -eq 0) {
                throw "AWS.Tools.zip download completed but file is empty: $script:CachedZipPath"
            }
            
            Write-Verbose "Successfully downloaded AWS.Tools.zip ($($fileInfo.Length) bytes)"
        }
        catch {
            Write-Error "Failed to download AWS.Tools.zip for integration tests: $($_.Exception.Message)"
            Write-Error "Stack trace: $($_.Exception.StackTrace)"
            throw
        }
    }
    else {
        Write-Verbose "Using existing cached AWS.Tools.zip: $script:CachedZipPath"
    }
    
    # Capture current system state before running tests
    Write-Verbose "Capturing current AWS.Tools module state..."
    $script:OriginalModules = Get-Module AWS.Tools.* -ListAvailable | ForEach-Object {
        @{
            Name       = $_.Name
            Version    = $_.Version
            ModuleBase = $_.ModuleBase
            Scope      = if ($_.ModuleBase -like "*$env:USERPROFILE*") { "CurrentUser" } else { "AllUsers" }
        }
    }
    
    # Also capture legacy modules state
    $script:OriginalLegacyModules = @()
    $legacyModules = Get-Module AWSPowerShell, AWSPowerShell.NetCore -ListAvailable -ErrorAction SilentlyContinue
    foreach ($legacyModule in $legacyModules) {
        $script:OriginalLegacyModules += @{
            Name       = $legacyModule.Name
            Version    = $legacyModule.Version
            ModuleBase = $legacyModule.ModuleBase
            Scope      = if ($legacyModule.ModuleBase -like "*$env:USERPROFILE*") { "CurrentUser" } else { "AllUsers" }
        }
    }
    
    Write-Verbose "Original modules found: $($script:OriginalModules.Count)"
    $script:OriginalModules | ForEach-Object { 
        Write-Verbose "  - $($_.Name) $($_.Version) [$($_.Scope)]"
    }
    
    Write-Verbose "Original legacy modules found: $($script:OriginalLegacyModules.Count)"
    $script:OriginalLegacyModules | ForEach-Object { 
        Write-Verbose "  - $($_.Name) $($_.Version) [$($_.Scope)]"
    }
}

AfterAll {
    # Restore original system state after all tests complete
    Write-Verbose "Restoring original AWS.Tools module state..."
    
    # Remove any AWS.Tools modules that weren't there originally
    $currentModules = Get-Module AWS.Tools.* -ListAvailable
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
                Uninstall-AWSToolsModule -Name @($moduleName) -Confirm:$false -ErrorAction SilentlyContinue
            }
            catch {
                Write-Warning "Failed to remove $($currentModule.Name): $($_.Exception.Message)"
            }
        }
    }
    
    # Reinstall any original modules that are now missing
    $currentModulesAfterCleanup = Get-Module AWS.Tools.* -ListAvailable
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
                Install-AWSToolsModule -Name $moduleNames -Version $version -Scope $scope -Confirm:$false -ErrorAction SilentlyContinue
            }
            catch {
                Write-Warning "Failed to restore modules $($moduleNames -join ', '): $($_.Exception.Message)"
            }
        }
    }
    
    # Restore legacy modules state
    Write-Verbose "Restoring original legacy module state..."
    
    # Remove any legacy modules that weren't there originally
    $currentLegacyModules = Get-Module AWSPowerShell, AWSPowerShell.NetCore -ListAvailable -ErrorAction SilentlyContinue
    foreach ($currentLegacyModule in $currentLegacyModules) {
        $wasOriginal = $script:OriginalLegacyModules | Where-Object { 
            $_.Name -eq $currentLegacyModule.Name -and 
            $_.Version -eq $currentLegacyModule.Version -and
            $_.ModuleBase -eq $currentLegacyModule.ModuleBase 
        }
        
        if (-not $wasOriginal) {
            Write-Verbose "  Removing extra legacy module: $($currentLegacyModule.Name) $($currentLegacyModule.Version)"
            try {
                Uninstall-Module -Name $currentLegacyModule.Name -Force -Confirm:$false -ErrorAction SilentlyContinue
            }
            catch {
                Write-Warning "Failed to remove $($currentLegacyModule.Name): $($_.Exception.Message)"
            }
        }
    }
    
    # Reinstall any original legacy modules that are now missing
    $currentLegacyModulesAfterCleanup = Get-Module AWSPowerShell, AWSPowerShell.NetCore -ListAvailable -ErrorAction SilentlyContinue
    $missingLegacyModules = @()
    
    foreach ($originalLegacyModule in $script:OriginalLegacyModules) {
        $stillExists = $currentLegacyModulesAfterCleanup | Where-Object { 
            $_.Name -eq $originalLegacyModule.Name -and 
            $_.Version -eq $originalLegacyModule.Version -and
            $_.ModuleBase -eq $originalLegacyModule.ModuleBase 
        }
        
        if (-not $stillExists) {
            $missingLegacyModules += $originalLegacyModule
        }
    }
    
    if ($missingLegacyModules.Count -gt 0) {
        foreach ($missingLegacyModule in $missingLegacyModules) {
            Write-Verbose "  Restoring missing legacy module: $($missingLegacyModule.Name) v$($missingLegacyModule.Version)"
            try {
                $installParams = @{
                    Name            = $missingLegacyModule.Name
                    RequiredVersion = $missingLegacyModule.Version
                    Scope           = $missingLegacyModule.Scope
                    Force           = $true
                    Confirm         = $false
                    ErrorAction     = 'SilentlyContinue'
                }
                Install-Module @installParams
            }
            catch {
                Write-Warning "Failed to restore legacy module $($missingLegacyModule.Name): $($_.Exception.Message)"
            }
        }
    }
    
    Write-Verbose "System state restoration completed"
    
    # Clean up cached zip file
    if (Test-Path $script:CachedZipPath) {
        Remove-Item $script:CachedZipPath -Force -ErrorAction SilentlyContinue
    }
}

Describe -Tag "Smoke", "High" "Installer - Extra Integration Tests" {
    
    Context "Default PSModulePath Behavior" {
        
        It "Should install and uninstall modules using default PSModulePath" {
            # Act: Install test modules without -Path parameter (uses default PSModulePath)
            Install-AWSToolsModule -Name @('Common', 'CloudWatch') -SourceZipPath $script:CachedZipPath -Scope CurrentUser -Confirm:$false -Force
            
            # Assert: Verify modules installed to default location
            $installedCommon = Get-Module AWS.Tools.Common -ListAvailable | Select-Object -First 1
            $installedCloudWatch = Get-Module AWS.Tools.CloudWatch -ListAvailable | Select-Object -First 1
            
            $installedCommon | Should -Not -BeNullOrEmpty
            $installedCloudWatch | Should -Not -BeNullOrEmpty
            
            Write-Verbose "Installed modules successfully"
            Write-Verbose "  - AWS.Tools.Common: $($installedCommon.ModuleBase)"
            Write-Verbose "  - AWS.Tools.CloudWatch: $($installedCloudWatch.ModuleBase)"
            
            # Act: Uninstall test modules without -Path parameter
            Uninstall-AWSToolsModule -Confirm:$false
            
            # Assert: Verify modules were removed
            $removedCommon = Get-Module AWS.Tools.Common -ListAvailable | Where-Object { $_.ModuleBase -eq $installedCommon.ModuleBase }
            $removedCloudWatch = Get-Module AWS.Tools.CloudWatch -ListAvailable | Where-Object { $_.ModuleBase -eq $installedCloudWatch.ModuleBase }
            
            $removedCommon | Should -BeNullOrEmpty
            $removedCloudWatch | Should -BeNullOrEmpty
            
            Write-Verbose "Uninstalled modules successfully"
        }
        
        It "Should automatically include AWS.Tools.Common when specific modules are requested" {
            # Act: Install only CloudWatch module (Common should be automatically included)
            Install-AWSToolsModule -Name @('CloudWatch') -SourceZipPath $script:CachedZipPath -Scope CurrentUser -Confirm:$false -Force
            
            # Assert: Verify both modules were installed
            $installedCommon = Get-Module AWS.Tools.Common -ListAvailable | Select-Object -First 1
            $installedCloudWatch = Get-Module AWS.Tools.CloudWatch -ListAvailable | Select-Object -First 1
            
            $installedCommon | Should -Not -BeNullOrEmpty
            $installedCloudWatch | Should -Not -BeNullOrEmpty
            
            Write-Verbose "Verified AWS.Tools.Common was automatically installed"
            Write-Verbose "  - AWS.Tools.Common: $($installedCommon.ModuleBase)"
            Write-Verbose "  - AWS.Tools.CloudWatch: $($installedCloudWatch.ModuleBase)"
            
            # Cleanup
            Uninstall-AWSToolsModule -Confirm:$false
            
            # Verify cleanup
            $removedCommon = Get-Module AWS.Tools.Common -ListAvailable | Where-Object { $_.ModuleBase -eq $installedCommon.ModuleBase }
            $removedCloudWatch = Get-Module AWS.Tools.CloudWatch -ListAvailable | Where-Object { $_.ModuleBase -eq $installedCloudWatch.ModuleBase }
            
            $removedCommon | Should -BeNullOrEmpty
            $removedCloudWatch | Should -BeNullOrEmpty
        }
    }
    
    Context "Legacy Module Cleanup" {
        
        It "Should remove legacy AWSPowerShell modules when using CleanUpLegacyModuleScope CurrentUser" {
            # Check if any AWSPowerShell* modules are currently imported in the session
            $importedLegacyModules = Get-Module -Name 'AWSPowerShell*'
            $importedCount = $importedLegacyModules | Measure-Object | Select-Object -ExpandProperty Count
            
            if ($importedCount -gt 0) {
                Set-ItResult -Skipped -Because "AWSPowerShell modules are currently imported and cannot be uninstalled"
                return
            }
            
            # Arrange: Install legacy modules for testing
            Write-Verbose "Installing legacy AWSPowerShell modules for testing..."
            
            # Install AWSPowerShell (Windows PowerShell version)
            try {
                Install-Module -Name AWSPowerShell -Scope CurrentUser -Force -Confirm:$false -ErrorAction Stop
                Write-Verbose "  - Installed AWSPowerShell"
            }
            catch {
                Write-Warning "Failed to install AWSPowerShell: $($_.Exception.Message)"
                # Skip test if we can't install the prerequisite
                Set-ItResult -Skipped -Because "Could not install AWSPowerShell module for testing"
                return
            }
            
            # Install AWSPowerShell.NetCore (PowerShell Core version) if running on PowerShell Core
            $netCoreInstalled = $false
            if ($PSVersionTable.PSEdition -eq 'Core') {
                try {
                    Install-Module -Name AWSPowerShell.NetCore -Scope CurrentUser -Force -Confirm:$false -ErrorAction Stop
                    Write-Verbose "  - Installed AWSPowerShell.NetCore"
                    $netCoreInstalled = $true
                }
                catch {
                    Write-Warning "Failed to install AWSPowerShell.NetCore: $($_.Exception.Message)"
                }
            }
            
            # Verify legacy modules are installed
            $legacyAWS = Get-Module AWSPowerShell -ListAvailable | Where-Object { $_.ModuleBase -like "*$env:USERPROFILE*" }
            $legacyNetCore = if ($netCoreInstalled) { 
                Get-Module AWSPowerShell.NetCore -ListAvailable | Where-Object { $_.ModuleBase -like "*$env:USERPROFILE*" }
            }
            else { $null }
            
            $legacyAWS | Should -Not -BeNullOrEmpty
            Write-Verbose "  - Verified AWSPowerShell is installed: $($legacyAWS.ModuleBase)"
            
            if ($netCoreInstalled) {
                $legacyNetCore | Should -Not -BeNullOrEmpty
                Write-Verbose "  - Verified AWSPowerShell.NetCore is installed: $($legacyNetCore.ModuleBase)"
            }
            
            # Act: Install AWS.Tools with legacy cleanup enabled
            Write-Verbose "Installing AWS.Tools with legacy cleanup..."
            # Add -Cleanup parameter to ensure module installation works with the new behavior
            Install-AWSToolsModule -Name @('Common') -SourceZipPath $script:CachedZipPath -Scope CurrentUser -CleanUpLegacyModuleScope CurrentUser -Cleanup -Confirm:$false -Force
            
            # Assert: Verify legacy modules were removed
            Write-Verbose "Verifying legacy modules were removed..."
            
            $remainingLegacyAWS = Get-Module AWSPowerShell -ListAvailable | Where-Object { $_.ModuleBase -like "*$env:USERPROFILE*" }
            $remainingLegacyNetCore = Get-Module AWSPowerShell.NetCore -ListAvailable | Where-Object { $_.ModuleBase -like "*$env:USERPROFILE*" }
            
            $remainingLegacyAWS | Should -BeNullOrEmpty
            Write-Verbose "  - Verified AWSPowerShell was removed from CurrentUser scope"
            
            if ($netCoreInstalled) {
                $remainingLegacyNetCore | Should -BeNullOrEmpty
                Write-Verbose "  - Verified AWSPowerShell.NetCore was removed from CurrentUser scope"
            }
            
            # Verify AWS.Tools.Common was installed
            $installedCommon = Get-Module AWS.Tools.Common -ListAvailable | Where-Object { $_.ModuleBase -like "*$env:USERPROFILE*" }
            $installedCommon | Should -Not -BeNullOrEmpty
            Write-Verbose "  - Verified AWS.Tools.Common was installed: $($installedCommon.ModuleBase)"
            
            # Cleanup: Remove AWS.Tools.Common for next test
            Uninstall-AWSToolsModule -Confirm:$false -ErrorAction SilentlyContinue
        }
    }
}
