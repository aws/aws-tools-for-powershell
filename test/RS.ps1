function Test.RS
{
	$options = Get-RSOrderableClusterOptions
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($options -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -gt 0
	}
}