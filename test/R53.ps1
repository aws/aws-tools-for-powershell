function Test.R53
{
	$zones = Get-R53HostedZones
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($zones -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -Gt 0
	}
	
	foreach($z in $zones)
	{
		$zone = Get-R53HostedZone -Id $z.Id
		Assert $zone -IsNotNull
		Assert $awshistory.LastServiceResponse -IsNotNull
		Assert $zone.HostedZone -IsNotNull
		Assert $zone.DelegationSet -IsNotNull
	}
}