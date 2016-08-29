Describe -Tag "Smoke" "CodePipeline" {

    BeforeEach {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "List pipelines" {

        It "Can list pipelines" {
            $pipelines = Get-CPPipelineList
            if ($pipelines) {
                $pipelines.Count | Should BeGreaterThan 0
            }
        }
    }

    Context "Read pipeline by name" {

        It "Can read a pipeline" {
            $pipelines = Get-CPPipelineList
            if ($pipelines) {
                $pipeline = Get-CPPipeline -Name $pipelines[0].Name
                $pipeline | Should Not Be $null
                $pipeline.Name | Should Be $pipelines[0].Name
            }
        }
    }

    Context "List action types" {

        It "Can read AWS action owner type" {

            $actionTypes = Get-CPActionType -ActionOwnerFilter AWS
            $actionTypes | Should Not Be $null
            $actionTypes.Count | Should BeGreaterThan 0
        }
    }
}
