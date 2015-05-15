function Test.CF
{
	$maxInvalidations = 0
	$distributions = Get-CFDistributions
	Assert $distributions -IsNotNull
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($distributions -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -gt 0
		Assert $distributions.Quantity -eq $distributions.Items.Count
	}

	foreach($dist in $distributions.Items)
	{
		$distribution = Get-CFDistribution -Id $dist.Id
		Assert $distribution -IsNotNull
		Assert $awshistory.LastServiceResponse -IsNotNull
		
		$invalidations = (Get-CFInvalidations -DistributionId $dist.Id)
		Assert $awshistory.LastServiceResponse -IsNotNull
		if ($invalidations -ne $null)
		{
			Assert $awshistory.LastCommand.EmittedObjectsCount -gt 0
		}

		if ($maxInvalidations -lt $awshistory.LastCommand.EmittedObjectsCount)
		{
			$maxInvalidations =  $awshistory.LastCommand.EmittedObjectsCount
		}
	}
	
	Assert $maxInvalidations -Gt 0
}
