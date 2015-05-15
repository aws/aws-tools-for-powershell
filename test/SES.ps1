function Test.SES
{
	$stats = Get-SESSendStatistics
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($stats -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -Gt 0
	}
	
	$quota = Get-SESSendQuota
	Assert $quota -IsNotNull
	Assert $awshistory.LastServiceResponse -IsNotNull
	
	$identities = Get-SESIdentity
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($identities -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -Gt 0
	}
}
