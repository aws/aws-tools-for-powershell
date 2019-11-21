. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
$helper = New-Object ServiceTestHelper

Describe -Tag "Smoke" "DataPipeline" {
    BeforeAll {
        $helper.BeforeAll()
    }
    AfterAll {
        $helper.AfterAll()
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