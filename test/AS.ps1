function Test.AS.LaunchConfiguration
{
    $launchConfig = $null
    $launchConfigName = "PShellLaunchConfigTest" + (Get-Date).Ticks

    try
    {
        $launchConfigParams = @{
            "ImageId"=(Get-EC2ImageByName WINDOWS_2012R2_BASE).ImageId
            "InstanceType"="t1.micro"
            "LaunchConfigurationName"=$launchConfigName
        } 

        New-ASLaunchConfiguration @launchConfigParams   

        $launchConfig = Get-ASLaunchConfiguration -LaunchConfigurationName $launchConfigName
        Assert $launchConfig -IsNotNull
    }
    finally
    {
        if ($launchConfig -ne $null)
        {
            Remove-ASLaunchConfiguration -LaunchConfigurationName $launchConfigName -Force
        }
    }

}
