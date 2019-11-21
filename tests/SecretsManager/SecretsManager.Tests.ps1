. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
$helper = New-Object ServiceTestHelper

Describe -Tag "Smoke" "SecretsManager" {
    BeforeAll {
        $helper.BeforeAll()
    }
    AfterAll {
        $helper.AfterAll()
    }

    Context "SecretsManager" {
    
        It "Can list secrets" {
            $secrets = Get-SECSecretList
            if ($secrets) {
                $secrets.Count | Should BeGreaterThan 0
            }
        }

        It "Can get a random secret password" {
            $randomPassword = Get-SECRandomPassword
            if ($randomPassword) {
                $randomPassword.Length | Should BeGreaterThan 0
            }
        }
    }
}
