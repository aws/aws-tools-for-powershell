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

Describe -Tag "Smoke" "ElasticTranscoder" {

    Context "Pipelines" {

        It "Can list and read pipelines" {
            $pipelines = Get-ETSPipeline
            if ($pipelines) {
                $pipelines.Count | Should -BeGreaterThan 0

                $pipeline = Read-ETSPipeline -Id $pipelines[0].Id

                $pipeline | Should -Not -Be $null
                $pipeline.Arn | Should -Be $pipelines[0].Arn
            }
        }
    }
}