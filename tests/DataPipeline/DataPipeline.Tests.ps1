Describe -Tag "Smoke" "DataPipeline" {

    BeforeAll {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Pipelines" {

        It "Can list pipelines and read descriptions" {
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