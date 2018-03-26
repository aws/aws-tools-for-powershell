. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
$helper = New-Object ServiceTestHelper

Describe -Tag "Smoke" "CodeDeploy" {
    BeforeAll {
        $helper.BeforeAll()
    }
    AfterAll {
        $helper.AfterAll()
    }

    Context "Applications" {

        It "Can list applications" {
            $apps = Get-CDApplicationList
            if ($apps) {
                $apps.Length | Should BeGreaterThan 0
            }
        }

        It "Can read an application" {
            $appname = Get-CDApplicationList | Select -First 1
            if ($appName) {
                $app = Get-CDApplication -ApplicationName $appName
                $app | Should Not Be $null
            }
        }

    }

    Context "Deployment Configurations" {

        It "Can list configurations" {
            $configs = Get-CDDeploymentConfigList
            if ($configs) {
                $configs.Length | Should BeGreaterThan 0
            }
        }

        It "Can read a configuration" {
            $configs = Get-CDDeploymentConfigList
            if ($configs) {
                $config = Get-CDDeploymentConfig -DeploymentConfigName $configs[0]
                $config | Should Not Be $null
            }
        }

    }
}
