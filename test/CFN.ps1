function Test.CFN
{
	$stacks = Get-CFNStack
	if ($stacks)
	{
		Assert $stacks -IsNotNull
		Assert $awshistory.LastServiceResponse -IsNotNull
		if ($stacks -ne $null)
		{
			Assert $awshistory.LastCommand.EmittedObjectsCount -gt 0
		}
	}
	
	#$stackSummaries = Get-CFNStackSummary
	#Assert $stackSummaries -IsNotNull
	#Assert $awshistory.LastServiceResponse -IsNotNull
	#if ($stackSummaries -ne $null)
	#{
	#	Assert $awshistory.LastCommand.EmittedObjectsCount -gt 0
	#}
}
