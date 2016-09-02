Describe -Tag "Smoke" "MachineLearning" {

    BeforeEach {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "List and read models" {

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
