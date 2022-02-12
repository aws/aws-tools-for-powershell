BeforeAll {
    . (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
    $helper = New-Object ServiceTestHelper
    $script:launchConfigName = "PShellLaunchConfigTest" + (Get-Date).Ticks

    $helper.BeforeAll()
}

AfterAll {
    $helper.AfterAll()
}

Describe -Tag "Smoke" "AutoScaling" {

    Context "Launch Configurations" {
        It "Can create a launch configuration" {
            $launchConfigParams = @{
                "ImageId"=(Get-EC2ImageByName WINDOWS_2012R2_BASE).ImageId
                "InstanceType"="t1.micro"
                "LaunchConfigurationName"=$script:launchConfigName
            }

            { New-ASLaunchConfiguration @launchConfigParams } | Should -Not -Throw
        }

        It "Can get the launch configuration" {
            $launchConfig = Get-ASLaunchConfiguration -LaunchConfigurationName $script:launchConfigName
            $launchConfig | Should -Not -BeNullOrEmpty
        }

        It "Can delete the launch configuration" {
            Remove-ASLaunchConfiguration -LaunchConfigurationName $script:launchConfigName -Force
            $launchConfig = Get-ASLaunchConfiguration -LaunchConfigurationName $script:launchConfigName -ErrorAction SilentlyContinue
            $launchConfig | Should -BeNullOrEmpty
        }
    }
}