Describe -Tag "Smoke" "AutoScaling" {

    BeforeEach {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Create-Fetch-Delete" {

        $launchConfig = $null
        $launchConfigName = "PShellLaunchConfigTest" + (Get-Date).Ticks

        It "creates a launch configuration" {
            $launchConfigParams = @{
                "ImageId"=(Get-EC2ImageByName WINDOWS_2012R2_BASE).ImageId
                "InstanceType"="t1.micro"
                "LaunchConfigurationName"=$launchConfigName
            }

            { New-ASLaunchConfiguration @launchConfigParams } | Should Not Throw
        }

        It "can get the launch configuration" {
            $launchConfig = Get-ASLaunchConfiguration -LaunchConfigurationName $launchConfigName
            $launchConfig | Should Not BeNullOrEmpty
        }

        It "can delete the launch configuration" {
            Remove-ASLaunchConfiguration -LaunchConfigurationName $launchConfigName -Force
            $launchConfig = Get-ASLaunchConfiguration -LaunchConfigurationName $launchConfigName -ErrorAction SilentlyContinue
            $launchConfig | Should BeNullOrEmpty
        }
    }
}