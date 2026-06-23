BeforeDiscovery {
    . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")
    $deploymentRoot = Join-Path $PSScriptRoot "../../Deployment/AWS.Tools"
    $script:CommonDeployed = Test-Path (Join-Path $deploymentRoot "AWS.Tools.Common/AWS.Tools.Common.psd1")
    if (-not $script:CommonDeployed -and -not $global:SkipInstallerTests) {
        Write-Host "[InstalledModulesAgainstDeployment] Skipping: AWS.Tools.Common not deployed (only AWS.Tools.Installer is staged)" -ForegroundColor Yellow
    }
}

BeforeAll {
    . (Join-Path $PSScriptRoot "../Include/InstallerTestIncludes.ps1")
    $deploymentRoot = (Resolve-Path (Join-Path $PSScriptRoot "../../Deployment/AWS.Tools")).Path
    $commonPsd1 = Join-Path $deploymentRoot 'AWS.Tools.Common/AWS.Tools.Common.psd1'
}

Describe -Skip:($global:SkipInstallerTests -or -not $script:CommonDeployed) "InstalledModules.Get matches Import-PowerShellDataFile" {
    It "reads the same ModuleVersion and Prerelease as Import-PowerShellDataFile for AWS.Tools.Common" {
        $manifestData = Import-PowerShellDataFile -Path $commonPsd1
        $expectedVersion = $manifestData.ModuleVersion
        $expectedPrerelease = if ($manifestData.PrivateData.PSData.ContainsKey('Prerelease')) {
            $manifestData.PrivateData.PSData.Prerelease
        } else { '' }

        $info = [Amazon.PowerShell.Installer.InstalledModules]::Get($deploymentRoot, 'AWS.Tools.Common') |
                Where-Object Path -EQ $commonPsd1 | Select-Object -First 1
        $info | Should -Not -BeNullOrEmpty

        $info.Version | Should -Be $expectedVersion

        $actualPrerelease = if ($info.FullVersionString -match '-') {
            $info.FullVersionString.Substring($info.FullVersionString.IndexOf('-') + 1)
        } else { '' }
        $actualPrerelease | Should -Be $expectedPrerelease
    }
}
