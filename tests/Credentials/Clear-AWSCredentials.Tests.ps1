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

        It "should delete from the right location depending on the -ProfileLocation parameter" {

            $helper.RegisterProfile("clearme", "accessShared", "secretShared", $helper.DefaultSharedPath)
            $helper.RegisterProfile("clearme", "accessCustom", "secretCustom", $helper.CustomSharedPath)
            $helper.RegisterProfile("clearme", "accessNet", "secretNet", $null)

            (Get-Content $helper.NetSDKPath | Out-String).Trim() | Should Not BeNullOrEmpty
            (Get-Content $helper.DefaultSharedPath | Out-String).Trim() | Should Not BeNullOrEmpty
            (Get-Content $helper.CustomSharedPath | Out-String).Trim() | Should Not BeNullOrEmpty

            Clear-AWSCredentials -ProfileName clearme -ProfileLocation $helper.CustomSharedpath

            (Get-Content $helper.NetSDKPath | Out-String).Trim() | Should Not BeNullOrEmpty
            (Get-Content $helper.DefaultSharedPath | Out-String).Trim() | Should Not BeNullOrEmpty
            (Get-Content $helper.CustomSharedPath | Out-String).Trim() | Should BeNullOrEmpty

            Clear-AWSCredentials -ProfileName clearme

            (Test-Path -Path $helper.NetSDKPath)| Should Be $false
            (Get-Content $helper.DefaultSharedPath | Out-String).Trim() | Should Not BeNullOrEmpty
            (Get-Content $helper.CustomSharedPath | Out-String).Trim() | Should BeNullOrEmpty

            Clear-AWSCredentials -ProfileName clearme

            (Test-Path -Path $helper.NetSDKPath)| Should Be $false
            (Get-Content $helper.DefaultSharedPath | Out-String).Trim() | Should BeNullOrEmpty
            (Get-Content $helper.CustomSharedPath | Out-String).Trim() | Should BeNullOrEmpty

        }
    }
}
