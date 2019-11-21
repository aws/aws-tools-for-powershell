. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Credentials") "CredentialsTestHelper.ps1")
$helper = New-Object CredentialsTestHelper

Describe -Tag "Smoke" "Clear-AWSDefaults" {

    BeforeAll {
        $helper.BeforeAll()
    }

    AfterAll {
        $helper.AfterAll()
    }

    Context "Clear-AWSDefaults" {

        BeforeEach {
            $helper.ClearAllCreds()
            Set-Variable StoredAWSCredentials "storedCredentials"
            Set-Variable StoredAWSRegion "storedRegion"
            $helper.RegisterProfile("default", "access_key", "secret_key", $null)
        }

        AfterEach {
           $helper.ClearAllCreds()
        }

        It "should clear the PS variables and the default profile with no parameters" {
            Clear-AWSDefaults

            (Get-Variable StoredAWSCredentials).Value | Should BeNullOrEmpty
            (Get-Variable StoredAWSRegion).Value | Should BeNullOrEmpty
            $helper.GetCredentialProfile($null, "default") | Should BeNullOrEmpty
        }

        It "should not clear the PS variables if -SkipShell is specified" {
            Clear-AWSDefaults -SkipShell

            (Get-Variable StoredAWSCredentials).Value | Should Be "storedCredentials"
            (Get-Variable StoredAWSRegion).Value | Should Be "storedRegion"
            $helper.GetCredentialProfile($null, "default") | Should BeNullOrEmpty
        }

        It "should not clear the profile store if -SkipProfileStore is specified" {
            Clear-AWSDefaults -SkipProfileStore

            (Get-Variable StoredAWSCredentials).Value | Should BeNullOrEmpty
            (Get-Variable StoredAWSRegion).Value | Should BeNullOrEmpty
            $helper.GetCredentialProfile($null, "default") | Should Not BeNullOrEmpty
        }
    }
}
