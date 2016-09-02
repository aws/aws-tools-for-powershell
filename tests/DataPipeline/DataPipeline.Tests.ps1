Describe -Tag "Smoke" "DataPipeline" {

    BeforeEach {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "List" {

        It "Can list pipelines" {
            $pipelines = Get-DPPipeline
            if ($pipelines) {
                $pipelines.Count | Should BeGreaterThan 0

                $pipeline = Get-DPPipelineDescription -PipelineId $pipelines[0].Id
                $pipeline | Should Not Be $null

                $pipeline.Name | Should be $pipelines[0].Name
            }

        }
    }
}