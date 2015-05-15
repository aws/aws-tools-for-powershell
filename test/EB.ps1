Function Test.EB
{
	$applications = Get-EBApplication
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($applications -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -gt 0
	}

	$configsRetrieved = 0
	foreach($app in $applications)
	{
		$versions = Get-EBApplicationVersion -ApplicationName $app.ApplicationName
		Assert $awshistory.LastServiceResponse -IsNotNull
		if ($versions -ne $null)
		{
			Assert $awshistory.LastCommand.EmittedObjectsCount -gt 0
		}

		$environments = Get-EBEnvironment -ApplicationName $app.ApplicationName -IncludeDeleted $false
		Assert $awshistory.LastServiceResponse -IsNotNull
		if ($environments -ne $null)
		{
			Assert $awshistory.LastCommand.EmittedObjectsCount -gt 0
		}
		
		foreach($env in $environments)
		{
			$success = $false
			try
			{
				$settings = Get-EBConfigurationSetting -ApplicationName $app.ApplicationName -EnvironmentName $env.EnvironmentName
				$success = $true
			}
			catch { }

			if ($success)
			{
				$configsRetrieved = $configsRetrieved + 1
				Assert $awshistory.LastServiceResponse -IsNotNull
				if ($settings -ne $null)
				{
					Assert $awshistory.LastCommand.EmittedObjectsCount -gt 0
				}
			}
		}
	}

	$solutionStacks = Get-EBAvailableSolutionStack
	Assert $solutionStacks -IsNotNull
	Assert $awshistory.LastServiceResponse -IsNotNull

	$stacks = $solutionStacks.SolutionStacks
    Assert -Actual $stacks.Count -Gt 0
	$details = $solutionStacks.SolutionStackDetails
    Assert -Actual $details.Count -Gt 0

	foreach($stack in $stacks)
	{
		$configs = Get-EBConfigurationOption -SolutionStackName $stack
		Assert $configs -IsNotNull
		Assert $awshistory.LastServiceResponse -IsNotNull
		Assert $awshistory.LastCommand.EmittedObjectsCount -gt 0
	}

	$dns = Get-EBDNSAvailability -CNAMEPrefix "cname-no-one-would-ever-pick-42"
	Assert $dns -IsNotNull
	Assert $awshistory.LastServiceResponse -IsNotNull
	Assert $dns.Available -Eq $true
}
