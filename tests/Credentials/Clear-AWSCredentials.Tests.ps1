. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Credentials") "CredentialsTestHelper.ps1")
$helper = New-Object CredentialsTestHelper

Describe -Tag "Smoke" "Clear-AWSCredentials" {

    BeforeAll {
        $helper.BeforeAll()
    }

    AfterAll {
        $helper.AfterAll()
    }

    Context "Clear-AWSCredentials" {

        BeforeEach {
            $helper.ClearAllCreds()
        }

        AfterEach {
           $helper.ClearAllCreds()
        }

        It "should clear the StoredAWSCredentials variable with no parameters" {
            Set-Variable StoredAWSCredentials "hello"
            (Get-Variable StoredAWSCredentials).Value | Should Be "hello"

            Clear-AWSCredentials

            (Get-Variable StoredAWSCredentials).Value | Should BeNullOrEmpty
        }
    }
}
