function Test.ETS
{
    $pipelines = Get-ETSPipeline
    if ($pipelines)
    {
        Assert $pipelines.Count -ge 0
        if ($pipelines.Count -gt 0)
        {
            Assert $pipelines.Count -eq $awshistory.LastCommand.EmittedObjectsCount

            if ($pipelines.Count -eq 1)
            {
                $pipelineData = Read-ETSPipeline -Id $pipelines.Id
            }
            else
            {
                $pipelineData = Read-ETSPipeline -Id $pipelines[0].Id
            }

            Assert $pipelineData -IsNotNull
        }
    }
}
