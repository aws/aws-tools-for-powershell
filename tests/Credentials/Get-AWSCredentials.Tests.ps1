. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Credentials") "CredentialsTestHelper.ps1")
$helper = New-Object CredentialsTestHelper
        
Describe -Tag "Smoke" "Credentials" {

    BeforeAll {
        $helper.BeforeAll()
    }

    AfterAll {
        $helper.AfterAll()
    }

    Context "Get-AWSCredentials" {

        BeforeEach { 
            $helper.ClearAllCreds()
        }

        AfterEach {
            $helper.ClearAllCreds()
        }       
        
        It "should return null with no arguments" {
            (Get-AWSCredentials) | Should BeNullOrEmpty
        }

        It "should return session credentials if there are any" {
            Set-AWSCredentials -AccessKey accessSession -SecretKey secretSession   

            $creds = Get-AWSCredentials

            $creds.GetCredentials().AccessKey | Should Be accessSession
            $creds.GetCredentials().SecretKey | Should Be secretSession
        }

        It "should prefer the .net credentials file over the shared credentials file" {
            $helper.RegisterProfile("preference", "accessShared", "secretShared", $helper.DefaultSharedPath)
            $helper.RegisterProfile("preference", "accessNet", "secretNet", $null)

            $creds = (Get-AWSCredentials preference)

            $creds.GetCredentials().AccessKey | Should Be "accessNet"
            $creds.GetCredentials().SecretKey | Should Be "secretNet"
        }

        It "should go to the shared file if .net credentials doesn't have the profile" {  
            $helper.RegisterProfile("preference", "accessShared", "secretShared", $helper.DefaultSharedPath)
            
            $creds = (Get-AWSCredentials preference)

            $creds.GetCredentials().AccessKey | Should Be "accessShared"
            $creds.GetCredentials().SecretKey | Should Be "secretShared"
        }
        
        It "should go to the custom shared file if -ProfilesLocation is specified" {
            $helper.RegisterProfile("preference", "accessCustom", "secretCustom", $helper.CustomSharedPath)
            $helper.RegisterProfile("preference", "accessShared", "secretShared", $helper.DefaultSharedPath)
            $helper.RegisterProfile("preference", "accessNet", "secretNet", $null)

            $creds = (Get-AWSCredentials preference -ProfilesLocation $helper.CustomSharedPath)

            $creds.GetCredentials().AccessKey | Should Be "accessCustom"
            $creds.GetCredentials().SecretKey | Should Be "secretCustom"
        }

    }
}