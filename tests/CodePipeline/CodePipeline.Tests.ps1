Describe -Tag "Smoke" "CodePipeline" {

    BeforeAll {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "Pipelines" {

        It "Can list pipelines" {
            $pipelines = Get-CPPipelineList
            if ($pipelines) {
                $pipelines.Count | Should BeGreaterThan 0
            }
        }

        It "Can read a pipeline" {
            $pipelines = Get-CPPipelineList
            if ($pipelines) {
                $pipeline = Get-CPPipeline -Name $pipelines[0].Name
                $pipeline | Should Not Be $null
                $pipeline.Name | Should Be $pipelines[0].Name
            }
        }
    }

    Context "Action Types" {

        It "Can read AWS action owner type" {

            $actionTypes = Get-CPActionType -ActionOwnerFilter AWS
            $actionTypes | Should Not Be $null
            $actionTypes.Count | Should BeGreaterThan 0
        }
    }
}
