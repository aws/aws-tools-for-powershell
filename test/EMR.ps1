function Init.EMR
{
	$random = New-Object System.Random
	$context.JFName = "ps-test-jf-" + $random.Next()
}
function Test.EMR
{
	$clusters = Get-EMRClusters
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($clusters -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -Gt 0
	}
	$clusterCount = $awshistory.LastCommand.EmittedObjectsCount

    # currently errors claiming 'InstanceProfile' is required.
    # service api doc mentions JobFlowRole but not that it is required,
    # as the service will use a default 'EMR_EC2_DefaultRole' but
    # it must be created.
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

	$clusters = Get-EMRClusters
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($clusters -ne $null)
	{
		Assert $awshistory.LastCommand.EmittedObjectsCount -Gt 0
	}
	$newClusterCount = $awshistory.LastCommand.EmittedObjectsCount
    # should have at least one new cluster
	Assert $newClusterCount -Gt $clusterCount

	Stop-EMRJobFlow -JobFlowIds $jfId
}