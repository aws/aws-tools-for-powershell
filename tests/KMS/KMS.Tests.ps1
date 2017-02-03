. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
$helper = New-Object ServiceTestHelper

Describe -Tag "Smoke" "KMS" {
    BeforeAll {
        $helper.BeforeAll()
    }
    AfterAll {
        $helper.AfterAll()
    }

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
