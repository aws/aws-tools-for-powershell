Describe -Tag "Smoke" "ElasticBeanstalk" {

    BeforeAll {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Applications and Environments" {

        It "Can list and read applications and environments" {

            $apps = Get-EBApplication
            if ($apps) {
                $apps.Count | Should BeGreaterThan 0

                foreach ($app in $apps) {
                    $versions = Get-EBApplicationVersion -ApplicationName $app.ApplicationName
                    if ($versions) {
                        $versions.Count | Should BeGreaterThan 0
                    }

            		$environments = Get-EBEnvironment -ApplicationName $app.ApplicationName -IncludeDeleted $false
                    if ($environments) {
                        $environments.Count | Should BeGreaterThan 0
                        foreach ($env in $environments) {
        				    $settings = Get-EBConfigurationSetting -ApplicationName $app.ApplicationName -EnvironmentName $env.EnvironmentName
                            $settings | Should Not Be $null
                        }
                    }
                }
            }
        }
    }

    Context "Solution Stacks" {

        It "Can list solution stacks" {

            $stacks = Get-EBAvailableSolutionStack
            if ($stacks) {
                $stacks.SolutionStacks | Should Not Be $null
                $stacks.SolutionStacks.Count | Should BeGreaterThan 0

                $stacks.SolutionStackDetails | Should Not Be $null
                $stacks.SolutionStackDetails.Count | Should BeGreaterThan 0

                $configs = Get-EBConfigurationOption -SolutionStackName $stacks.SolutionStacks[0]
                $configs | Should Not Be $null
                $configs.Count | Should BeGreaterThan 0
            }
        }
    }

    Context "DNS Availability" {

        It "Can check for dns availability" {
        	$dns = Get-EBDNSAvailability -CNAMEPrefix "cname-no-one-would-ever-pick-42"
            $dns | Should Not Be $null
            $dns.Available | Should Be $true
        }
    }
}
