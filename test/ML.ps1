function Test.ML.DescribeLMModels
{
    $models = Get-MLModels
    if ($models)
    {
        Assert $models.Count -ge 0
        Assert $models.Count -eq $awshistory.LastCommand.EmittedObjectsCount

        if ($models.Count -gt 0)
        {
            if ($models.Count -eq 1)
            {
                $model = Get-MLModel -MLModelId $models.MLModelId
            }
            else
            {
                $model = Get-MLModel -MLModelId $models[0].MLModelId
            }

            Assert $model -IsNotNull
        }
    }
}
