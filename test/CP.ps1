function Test.CP.Pipelines
{
    $pipelines = Get-CPPipelineList -region us-east-1
    if ($pipelines)
    {
        Assert $pipelines.Count -ge 0

        if ($pipelines.Count -gt 0)
        {
		    Assert $awshistory.LastCommand.EmittedObjectsCount -eq $pipelines.Count

            if ($pipelines.Count -eq 1)
            {
                $pipelineName = $pipelines.Name
            }
            else
            {
                $pipelineName = $pipelines[0].Name
            }

            $pipeline = Get-CPPipeline -Name $pipelineName -region us-east-1
            
            Assert $pipeline -IsNotNull 
        }
    }
}

function Test.CP.ListActionTypes
{
    $actionTypes = Get-CPActionType -region us-east-1 -ActionOwnerFilter AWS
    Assert $actionTypes -IsNotNull
    Assert $actionTypes.Count -gt 0
	Assert $awshistory.LastCommand.EmittedObjectsCount -eq $actionTypes.Count
}

