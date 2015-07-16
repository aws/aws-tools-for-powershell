
function Test.DP.ListPipelines
{
    $pipelines = Get-DPPipeline
    if ($pipelines)
    {
        Assert $pipelines.Count -ge 0
        if ($pipelines.Count -gt 0)
        {
		    Assert $awshistory.LastCommand.EmittedObjectsCount -eq $pipelines.Count
        }
    }
}

# test currently disabled due to eventual consistency issues
$disabled = @"
function Test.DP
{
	$count = 0
	
	$pipelines = Get-DPPipeline
	Assert $awshistory.LastServiceResponse -IsNotNull
	if ($pipelines -ne $null)
	{
		$count = $awshistory.LastCommand.EmittedObjectsCount
	}

	$name = "pstest-pipeline"
	$id = "pspipeline-" + [System.DateTime]::Now.ToFileTime()
	$description = "PowerShell Test pipeline"

	$newpipeline = New-DPPipeline -Name $name -UniqueId $id -Description $description
	Assert $newpipeline -IsNotNull	
	Assert $awshistory.LastServiceResponse -IsNotNull

	$pipeline = Get-DPPipelineDescription -PipelineIds $newpipeline
	Assert $pipeline -IsNotNull	
	Assert $awshistory.LastServiceResponse -IsNotNull
	Assert $pipeline.Name -Eq $name
	Assert $pipeline.Description -Eq $description

	$def = Get-DPPipelineDefinition -PipelineId $newpipeline
	# Assert $def -eq $null
	Assert $awshistory.LastCommand.EmittedObjectsCount -Eq 0
	Assert $awshistory.LastServiceResponse -IsNotNull
	
	$obj = new-object Amazon.DataPipeline.Model.PipelineObject
	$obj.Id = "Default"
	$obj.Name = "Default"
	$field = new-object Amazon.DataPipeline.Model.Field
	$field.Key = "workerGroup"
	$field.StringValue = "MyworkerGroup"
	$obj.Fields.Add($field)
	
	$test = Test-DPPipelineDefinition -PipelineId $newpipeline -PipelineObjects $obj
	Assert $test -IsNotNull	
	Assert $awshistory.LastServiceResponse -IsNotNull
	Assert $test.Errored -Eq $false

	$write = Write-DPPipelineDefinition -PipelineId $newpipeline -PipelineObjects $obj
	Assert $write -IsNotNull	
	Assert $awshistory.LastServiceResponse -IsNotNull
	Assert $write.Errored -Eq $false

	$def = Get-DPPipelineDefinition -PipelineId $newpipeline
	Assert $def -IsNotNull	
	Assert $awshistory.LastServiceResponse -IsNotNull
	
	$enable = Enable-DPPipeline -PipelineId $newpipeline
	#Assert $enable -IsNull
	#Assert $awshistory.LastServiceResponse -IsNotNull
	
	Sleep -Seconds 5
	
	$objects = Get-DPObject -PipelineId $newpipeline -ObjectIds "Default"
	Assert $objects -IsNotNull	
	Assert $awshistory.LastServiceResponse -IsNotNull
	Assert $awshistory.LastCommand.EmittedObjectsCount -Eq 1
	
	$objects = Find-DPObject -PipelineId $newpipeline -Sphere COMPONENT
	Assert $objects -IsNotNull	
	Assert $awshistory.LastServiceResponse -IsNotNull
	Assert $awshistory.LastCommand.EmittedObjectsCount -Eq 1

	$pipelines = Get-DPPipeline
	$newcount = $awshistory.LastCommand.EmittedObjectsCount
	Assert $newcount -Eq ($count + 1)

	$remove = Remove-DPPipeline -PipelineId $newpipeline -Force
	# Assert $remove -IsNotNull	
	Assert $awshistory.LastCommand.EmittedObjectsCount -Eq 0
	Assert $awshistory.LastServiceResponse -IsNotNull
}
"@
