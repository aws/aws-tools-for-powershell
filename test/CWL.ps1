function Test.CWL.DescribeLogGroups
{
    $logGroups = Get-CWLLogGroups
    if ($logGroups)
    {
        Assert $logGroups.Count -ge 0
	    Assert $awshistory.LastServiceResponse -IsNotNull

        if ($logGroups.Count -gt 0)
        {
		    Assert $awshistory.LastCommand.EmittedObjectsCount -eq $logGroups.Count
        }
    }
}
