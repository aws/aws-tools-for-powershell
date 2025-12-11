#Comment
BeforeAll {
    . (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
    $helper = New-Object ServiceTestHelper
    $helper.BeforeAll()
}

AfterAll {
    $helper.AfterAll()
}

Describe -Tag "Smoke" "CodeDeploy" {

    Context "Applications" {

        It "Can list applications" {
            $apps = Get-CDApplicationList
            if ($apps) {
                $apps.Length | Should -BeGreaterThan 0
            }
        }

        It "Can read an application" {
            $appName = Get-CDApplicationList | Select -First 1
            if ($appName) {
                $app = Get-CDApplication -ApplicationName $appName
                $app | Should -Not -Be $null
            }
        }

    }

    Context "Deployment Configurations" {

        It "Can list configurations" {
            $configs = Get-CDDeploymentConfigList
            if ($configs) {
                $configs.Length | Should -BeGreaterThan 0
            }
        }

        It "Can read a configuration" {
            $configName = Get-CDDeploymentConfigList | Select -First 1
            if ($configName) {
                $config = Get-CDDeploymentConfig -DeploymentConfigName $configName
                $config | Should -Not -Be $null
            }
        }

    }
}
