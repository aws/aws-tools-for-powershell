# Import the module
Import-Module ./modules/Installer/AWS.Tools.Installer.psd1 -Force

# Test AWS.Tools.Installer version 1.0.3
Write-Host "Testing AWS.Tools.Installer version 1.0.3..." -ForegroundColor Yellow
try {
    # Call Test-ParameterValidation directly to test version validation
    & (Get-Module AWS.Tools.Installer) {
        Test-ParameterValidation -Version ([Version]"1.0.3") -ModuleName 'AWS.Tools.Installer'
        Write-Host "Version 1.0.3 is valid for AWS.Tools.Installer" -ForegroundColor Green
    }
} catch {
    Write-Host "Error: $($_.Exception.Message)" -ForegroundColor Red
}

# Test AWS.Tools.Installer version 1.0.2 (should fail)
Write-Host "`nTesting AWS.Tools.Installer version 1.0.2..." -ForegroundColor Yellow
try {
    # Call Test-ParameterValidation directly to test version validation
    & (Get-Module AWS.Tools.Installer) {
        Test-ParameterValidation -Version ([Version]"1.0.2") -ModuleName 'AWS.Tools.Installer'
        Write-Host "Version 1.0.2 is valid for AWS.Tools.Installer" -ForegroundColor Green
    }
} catch {
    Write-Host "Error: $($_.Exception.Message)" -ForegroundColor Red
}

# Test AWS.Tools version 4.0.0
Write-Host "`nTesting AWS.Tools version 4.0.0..." -ForegroundColor Yellow
try {
    # Call Test-ParameterValidation directly to test version validation
    & (Get-Module AWS.Tools.Installer) {
        Test-ParameterValidation -Version ([Version]"4.0.0") -ModuleName 'AWS.Tools'
        Write-Host "Version 4.0.0 is valid for AWS.Tools" -ForegroundColor Green
    }
} catch {
    Write-Host "Error: $($_.Exception.Message)" -ForegroundColor Red
}

# Test AWS.Tools version 3.0.0 (should fail)
Write-Host "`nTesting AWS.Tools version 3.0.0..." -ForegroundColor Yellow
try {
    # Call Test-ParameterValidation directly to test version validation
    & (Get-Module AWS.Tools.Installer) {
        Test-ParameterValidation -Version ([Version]"3.0.0") -ModuleName 'AWS.Tools'
        Write-Host "Version 3.0.0 is valid for AWS.Tools" -ForegroundColor Green
    }
} catch {
    Write-Host "Error: $($_.Exception.Message)" -ForegroundColor Red
}
