function Init.ELB
{
	$random = New-Object System.Random
	$context.LBName = "ps-test-lb-" + $random.Next()
}
function Test.ELB
{
	$elb = Get-ELBLoadBalancer
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($elb -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -Gt 0
	}
	$elbCount = $awshistory.LastCommand.EmittedObjectsCount

	$lbName = $context.LBName
	$listener = New-Object Amazon.ElasticLoadBalancing.Model.Listener
	$listener.Protocol = "http"
	$listener.InstancePort = 80
	$listener.LoadBalancerPort = 80
	New-ELBLoadBalancer -LoadBalancerName $lbName -Listeners $listener -AvailabilityZones "us-east-1b"
	
	$lbs = Get-ELBLoadBalancer
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($lbs -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -Eq ($elbCount + 1)
	}

	Remove-ELBLoadBalancer -LoadBalancerName $lbName -Force
	$lbs = Get-ELBLoadBalancer
	$newElbCount = $awshistory.LastCommand.EmittedObjectsCount
	Assert $elbCount -Eq $newElbCount
}