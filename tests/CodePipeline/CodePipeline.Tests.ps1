. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
$helper = New-Object ServiceTestHelper

Describe -Tag "Smoke" "CodePipeline" {
    BeforeAll {
        $helper.BeforeAll()
    }
    AfterAll {
        $helper.AfterAll()
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
