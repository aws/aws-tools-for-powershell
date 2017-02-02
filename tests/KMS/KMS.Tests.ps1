. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestIncludes.ps1")
Describe -Tag "Smoke" "KMS" {
    Context "Keys" {

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
