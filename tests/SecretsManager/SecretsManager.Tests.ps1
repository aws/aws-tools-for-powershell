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

Describe -Tag "Smoke" "SecretsManager" {

    Context "SecretsManager" {
    
        It "Can list secrets" {
            $secrets = Get-SECSecretList
            if ($secrets) {
                $secrets.Count | Should -BeGreaterThan 0
            }
        }

        It "Can get a random secret password" {
            $randomPassword = Get-SECRandomPassword
            if ($randomPassword) {
                $randomPassword.Length | Should -BeGreaterThan 0
            }
        }
    }
}
