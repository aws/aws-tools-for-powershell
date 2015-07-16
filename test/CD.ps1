function Test.CD.Applications
{
    $apps = Get-CDApplicationList
    if ($apps)
    {
        Assert $apps.Count -ge 0
        if ($apps.Count -gt 0)
        {
		    Assert $awshistory.LastCommand.EmittedObjectsCount -eq $apps.Count

            if ($apps.Count -eq 1)
            {
                $appName = $apps
            }
            else
            {
                $appName = $apps[0]
            }

            $app = Get-CDApplication -ApplicationName $appName

            Assert $app -IsNotNull
        }
    }
}

function Test.CD.DeploymentConfigs
{
    $configs = Get-CDDeploymentConfigList
    if ($configs)
    {
        Assert $configs.Count -ge 0
        if ($configs.Count -gt 0)
        {
		    Assert $awshistory.LastCommand.EmittedObjectsCount -eq $configs.Count

            if ($configs.Count -eq 1)
            {
                $configName = $configs
            }
            else
            {
                $configName = $configs[0]
            }

            $config = Get-CDDeploymentConfig -DeploymentConfigName $configName
            
            Assert $config -IsNotNull 
        }
    }
}
