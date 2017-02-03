. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
$helper = New-Object ServiceTestHelper

Describe -Tag "Smoke" "MachineLearning" {
    BeforeAll {
        $helper.BeforeAll()
    }
    AfterAll {
        $helper.AfterAll()
    }

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
