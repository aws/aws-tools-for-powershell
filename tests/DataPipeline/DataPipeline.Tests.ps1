BeforeAll {
    . (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
    $helper = New-Object ServiceTestHelper
    $helper.BeforeAll()
}

AfterAll {
    $helper.AfterAll()
}

Describe -Tag "Smoke" "DataPipeline" {

    Context "Pipelines" {

        It "Can list pipelines and read descriptions" {
            $pipelines = Get-DPPipeline
            if ($pipelines) {
                $pipelines.Count | Should -BeGreaterThan 0

                $pipeline = Get-DPPipelineDescription -PipelineId $pipelines[0].Id
                $pipeline | Should -Not -Be $null

                $pipeline.Name | Should -Be $pipelines[0].Name
            }

        }
    }
}