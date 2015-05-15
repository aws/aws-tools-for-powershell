
#  New-DCPrivateVirtualInterface
#  New-DCPublicVirtualInterface
#  Remove-DCVirtualInterface

function Test.DC
{
	$connection = Get-DCVirtualGateway
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($connection -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -Gt 0
		if ($awshistory.LastCommand.EmittedObjectsCount -eq 1)
		{	
			Assert $connection.VirtualGatewayId -IsNotNull	
		}
		else
		{
			Assert $connection[0].VirtualGatewayId -IsNotNull	
		}
	}

	$connections = Get-DCConnection
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($connections -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -Gt 0
		if ($awshistory.LastCommand.EmittedObjectsCount -eq 1)
		{
			Assert $connections.ConnectionId -IsNotNull
		}
		else
		{
			Assert $connections[0].ConnectionId -IsNotNull
		}
	}
	
	#$newConnection = New-DCConnection -Bandwith 1Gbps -ConnectionName pstest
	#Assert $newConnection -IsNotNull	
	#Assert $awshistory.LastServiceResponse -IsNotNull

	#$connectionId = $newConnection.ConnectionId

	#sleep -Seconds 5
	
	#$connection = Get-DCConnection -ConnectionId $connectionId
	#Assert $connection -IsNotNull	
	#Assert $awshistory.LastServiceResponse -IsNotNull
	
	#$virtualInterfaces = Get-DCVirtualInterface -ConnectionId $connectionId
	#Assert $awshistory.LastServiceResponse -IsNotNull
	# Assert $virtualInterfaces -IsNull
	#Assert $awshistory.LastCommand.EmittedObjectsCount -Eq 0	

	#$removed = Remove-DCConnection -ConnectionId $connection.ConnectionId -Force
	#Assert $removed -IsNotNull	
	#Assert $awshistory.LastServiceResponse -IsNotNull

	#$connection  = Get-DCConnection -ConnectionId $connectionId
	#if ($connection -ne $null)
	#{
	#	Assert $awshistory.LastServiceResponse -IsNotNull
	#	Assert $connection.ConnectionState -Eq "deleted"
	#}
}