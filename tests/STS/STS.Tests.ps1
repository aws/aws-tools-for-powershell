. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "ServiceTestHelper.ps1")
$helper = New-Object ServiceTestHelper

Describe -Tag "Smoke" "STS" {
    BeforeAll {
        $helper.BeforeAll()
    }
    AfterAll {
        $helper.AfterAll()
    }

    Context "Temporary Credentials" {
        It "Can get temporary credentials" {
            # Get-STSSecurityToken can't be used here because it requires permanent credentials
            if ($helper.Token -ne $null) {
                return
            }

            $creds = Get-STSSessionToken
            $creds | Should Not Be $null
            $creds.AccessKeyId | Should Not BeNullOrEmpty
            $creds.SecretAccessKey | Should Not BeNullOrEmpty
            $creds.SessionToken | Should Not BeNullOrEmpty
        }
    }
}