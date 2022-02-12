BeforeAll {
    . (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
    . (Join-Path (Join-Path (Get-Location) "Credentials") "CredentialsTestHelper.ps1")
    $helper = New-Object CredentialsTestHelper
    $helper.BeforeAll()
}

AfterAll {
    $helper.AfterAll()
}

Describe -Tag "Smoke" "Clear-AWSCredentials" {


    Context "Clear-AWSCredentials" {

        BeforeEach {
            $helper.ClearAllCreds()
        }

        AfterEach {
           $helper.ClearAllCreds()
        }

        It "should clear the StoredAWSCredentials variable with no parameters" {
            Set-Variable StoredAWSCredentials "hello"
            (Get-Variable StoredAWSCredentials).Value | Should -Be "hello"

            Clear-AWSCredentials

            (Get-Variable StoredAWSCredentials).Value | Should -BeNullOrEmpty
        }
    }
}
