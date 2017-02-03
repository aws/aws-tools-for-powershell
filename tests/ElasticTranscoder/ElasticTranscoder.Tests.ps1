. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
$helper = New-Object ServiceTestHelper

Describe -Tag "Smoke" "ElasticTranscoder" {
    BeforeAll {
        $helper.BeforeAll()
    }
    AfterAll {
        $helper.AfterAll()
    }

    Context "Pipelines" {

        It "Can list and read pipelines" {
            $pipelines = Get-ETSPipeline
            if ($pipelines) {
                $pipelines.Count | Should BeGreaterThan 0

                $pipeline = Read-ETSPipeline -Id $pipelines[0].Id

                $pipeline | Should Not Be $null
                $pipeline.Arn | Should Be $pipelines[0].Arn
            }
        }
    }
}