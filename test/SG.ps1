function Test.StorageGateway
{
	$gateways = Get-SGGateway
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($gateways -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -gt 0
	}
}
