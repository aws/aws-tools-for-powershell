function Test.EC
{
	$clusters = Get-ECCacheCluster
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($clusters -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -Gt 0
	}

	$groups = Get-ECCacheParameterGroup
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($groups -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -Gt 0
	}

	foreach ($group in $groups)
	{
		$groupName = $group.CacheParameterGroupName
		Assert $groupName -IsNotNull
		$groupFamily = $group.CacheParameterGroupFamily
		Assert $groupFamily -IsNotNull
		
		$parameters = Get-ECCacheParameter -CacheParameterGroupName $groupName
		Assert $parameters -IsNotNull
		Assert $awshistory.LastServiceResponse -IsNotNull
		Assert $parameters.Parameters -IsNotNull
		Assert $parameters.CacheNodeTypeSpecificParameters -IsNotNull

		$defaults = Get-ECEngineDefaultParameter -CacheParameterGroupFamily $groupFamily
		Assert $defaults -IsNotNull
		Assert $awshistory.LastServiceResponse -IsNotNull
		Assert $defaults.CacheParameterGroupFamily -IsNotNull
		Assert $defaults.Parameters -IsNotNull
		Assert $defaults.CacheNodeTypeSpecificParameters -IsNotNull
	}
}