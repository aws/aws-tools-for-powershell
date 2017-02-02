. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestIncludes.ps1")
Describe -Tag "Smoke" "ElasticTranscoder" {
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