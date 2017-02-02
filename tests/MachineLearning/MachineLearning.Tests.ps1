. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestIncludes.ps1")
Describe -Tag "Smoke" "MachineLearning" {
    Context "Models" {

        It "Can list and read models" {
            $models = Get-MLModels
            if ($models) {
                $models.Count | Should BeGreaterThan 0

                $model = Get-MLModel -MLModelId $models[0].MLModelId

                $model | Should Not Be $null
                $model.MLModelId | Should Be $models[0].MLModelId
            }
        }
    }
}
