function Test.CP.Pipelines
{
    $pipelines = Get-CPPipelineList
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

            $pipeline = Get-CPPipeline -Name $pipelineName
            
            Assert $pipeline -IsNotNull 
        }
    }
}

function Test.CP.ListActionTypes
{
    $actionTypes = Get-CPActionType -ActionOwnerFilter AWS
    Assert $actionTypes -IsNotNull
    Assert $actionTypes.Count -gt 0
	Assert $awshistory.LastCommand.EmittedObjectsCount -eq $actionTypes.Count
}

