Describe -Tag "Smoke" "AutoScaling" {

    BeforeEach {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Create-Fetch-Delete" {

        $script:launchConfigName = "PShellLaunchConfigTest" + (Get-Date).Ticks

        It "creates a launch configuration" {
            $launchConfigParams = @{
                "ImageId"=(Get-EC2ImageByName WINDOWS_2012R2_BASE).ImageId
                "InstanceType"="t1.micro"
                "LaunchConfigurationName"=$script:launchConfigName
            }

            { New-ASLaunchConfiguration @launchConfigParams } | Should Not Throw
        }

        It "can get the launch configuration" {
            $launchConfig = Get-ASLaunchConfiguration -LaunchConfigurationName $script:launchConfigName
            $launchConfig | Should Not BeNullOrEmpty
        }

        It "can delete the launch configuration" {
            Remove-ASLaunchConfiguration -LaunchConfigurationName $script:launchConfigName -Force
            $launchConfig = Get-ASLaunchConfiguration -LaunchConfigurationName $script:launchConfigName -ErrorAction SilentlyContinue
            $launchConfig | Should BeNullOrEmpty
        }
    }
}