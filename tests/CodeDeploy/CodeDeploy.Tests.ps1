Describe -Tag "Smoke" "CodeDeploy" {

    BeforeAll {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Applications" {

        It "Can list applications" {
            $apps = Get-CDApplicationList
            if ($apps) {
                $apps.Length | Should BeGreaterThan 0
            }
        }

        It "Can read an application" {
            $apps = Get-CDApplicationList
            if ($apps) {
                $app = Get-CDApplication -ApplicationName $apps[0]
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
