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


Describe -Tag "Smoke" "Remove-AWSCredentialProfile" {

    Context "Remove-AWSCredentialProfile" {

        BeforeEach {
            $helper.ClearAllCreds()
        }

        AfterEach {
           $helper.ClearAllCreds()
        }

        It "should delete from the right location depending on the -ProfileLocation parameter" {

            $helper.RegisterProfile("clearme", "accessShared", "secretShared", $helper.DefaultSharedPath)
            $helper.RegisterProfile("clearme", "accessCustom", "secretCustom", $helper.CustomSharedPath)
            $helper.RegisterProfile("clearme", "accessNet", "secretNet", $null)

            (Get-Content $helper.NetSDKPath | Out-String).Trim() | Should -Not -BeNullOrEmpty
            (Get-Content $helper.DefaultSharedPath | Out-String).Trim() | Should -Not -BeNullOrEmpty
            (Get-Content $helper.CustomSharedPath | Out-String).Trim() | Should -Not -BeNullOrEmpty

            Remove-AWSCredentialProfile -ProfileName clearme -ProfileLocation $helper.CustomSharedpath -Force

            (Get-Content $helper.NetSDKPath | Out-String).Trim() | Should -Not -BeNullOrEmpty
            (Get-Content $helper.DefaultSharedPath | Out-String).Trim() | Should -Not -BeNullOrEmpty
            (Get-Content $helper.CustomSharedPath | Out-String).Trim() | Should -BeNullOrEmpty

            Remove-AWSCredentialProfile -ProfileName clearme -Force

            (Test-Path -Path $helper.NetSDKPath)| Should -Be $false
            (Get-Content $helper.DefaultSharedPath | Out-String).Trim() | Should -Not -BeNullOrEmpty
            (Get-Content $helper.CustomSharedPath | Out-String).Trim() | Should -BeNullOrEmpty

            Remove-AWSCredentialProfile -ProfileName clearme -Force

            (Test-Path -Path $helper.NetSDKPath)| Should -Be $false
            (Get-Content $helper.DefaultSharedPath | Out-String).Trim() | Should -BeNullOrEmpty
            (Get-Content $helper.CustomSharedPath | Out-String).Trim() | Should -BeNullOrEmpty
        }

        It "should throw if the profile doesn't exist" {
            { Remove-AWSCredentialProfile -ProfileName doesnotexist } | Should -Throw "*does not exist*"
        }

    }
}
