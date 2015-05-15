#
# Basic test we can call CloudWatch using auto-iteration
#
function Test.CW
{
	$met = Get-CWMetrics
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($met -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -gt 0
	}
	#Assert $awshistory.LastServiceResponse.NextToken -eq $null
	
	
	$alarms = Get-CWAlarm
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($alarms -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -gt 0
	}
}

#
# Test group that manual iteration works
#
function Init.CW.Iteration()
{
    $context.AllAlarms = Get-CWAlarm
}
function Test.CW.Iteration([switch] $Category_Smoke)
{
    [int]$numPerPage = $context.AllAlarms.Count / 4
	$numPerPage = [System.Math]::Min($numPerPage, 100)

    # test using service api names for tokenization
    $manualIter1 = Get-CWAlarm -MaxRecords $numPerPage
    while ($awshistory.LastServiceResponse.NextToken -ne $null)
    {
        $manualIter1 += Get-CWAlarm -MaxRecords $numPerPage -NextToken $awshistory.LastServiceResponse.NextToken
    }
    
	Assert $manualIter1.Count -eq $context.AllAlarms.Count

    # test using tokenization aliases
    $manualIter2 = Get-CWAlarm -MaxItems $numPerPage
    while ($awshistory.LastServiceResponse.NextToken -ne $null)
    {
        $manualIter2 += Get-CWAlarm -MaxItems $numPerPage -NextToken $awshistory.LastServiceResponse.NextToken
    }
    
	Assert $manualIter1.Count -eq $context.AllAlarms.Count
}

