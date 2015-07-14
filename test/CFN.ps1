function Test.CFN.DescribeStacks
{
	$stacks = Get-CFNStack
    # empty collection is returned if no stacks available. The 'if' followed
    # by Assert not null looks odd, but the test runner requires it otherwise
    # "cannot bind to parameter Actual" messages result
    if ($stacks)
    {
	    Assert $stacks -IsNotNull
	    Assert $awshistory.LastServiceResponse -IsNotNull
    
	    if ($stacks.Count -gt 0)
	    {
		    Assert $awshistory.LastCommand.EmittedObjectsCount -eq $stacks.Count
	    }
    }
}

function Test.CFN.ListStacks
{    	
    $deletedStacks = Get-CFNStackSummary -StackStatusFilter DELETE_COMPLETE
    if ($deletedStacks)
    {
	    Assert $deletedStacks -IsNotNull
	    Assert $awshistory.LastServiceResponse -IsNotNull

	    if ($deletedStacks.Count -gt 0)
	    {
		    Assert $awshistory.LastCommand.EmittedObjectsCount -eq $deletedStacks.Count
	    }
    }
}
