function Init.EMR
{
	$random = New-Object System.Random
	$context.JFName = "ps-test-jf-" + $random.Next()
}
function Test.EMR
{
	$jobFlows = Get-EMRJobFlow
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($jobFlows -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -Gt 0
	}
	$jobCount = $awshistory.LastCommand.EmittedObjectsCount

	$jfId = Start-EMRJobFlow `
		-Name "Hive Interactive" `
		-LogUri "s3://log-bucket" `
		-Instances_MasterInstanceType "m1.small" `
		-Instances_SlaveInstanceType "m1.small" `
		-Instances_InstanceCount 5 `
		-Instances_Ec2KeyName "pavel2" `
		-Instances_KeepJobFlowAliveWhenNoSteps $true `
		-Instances_HadoopVersion "0.20" 
	Assert $jfId -IsNotNull
	Assert $awshistory.LastServiceResponse -IsNotNull

	$jobFlows = Get-EMRJobFlow
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($jobFlows -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -Gt 0
	}
	$newJobCount = $awshistory.LastCommand.EmittedObjectsCount
	Assert $newJobCount -Eq ($jobCount + 1)

	Stop-EMRJobFlow -JobFlowIds $jfId
}