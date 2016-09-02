Describe -Tag "Smoke" "KMS" {

    BeforeEach {
        Set-AWSCredentials default
        Set-DefaultAWSRegion us-east-1
    }

    Context "List and read keys" {

        It "Can list and read keys" {
            $keys = Get-KMSKeys
            if ($keys) {
                $keys.Count | Should BeGreaterThan 0

                $key = Get-KMSKey -KeyId $keys[0].KeyId
                $key | Should Not Be $null
                $key.Arn | Should Be $keys[0].KeyArn
            }
        }
    }
}
