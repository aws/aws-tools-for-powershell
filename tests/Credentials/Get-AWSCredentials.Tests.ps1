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

Describe -Tag "Smoke" "Get-AWSCredentials" {


    Context "Get-AWSCredentials" {

        BeforeEach {
            $helper.ClearAllCreds()
        }

        AfterEach {
            $helper.ClearAllCreds()
        }

        It "should return null with no arguments" {
            (Get-AWSCredentials) | Should -BeNullOrEmpty
        }

        It "should work with no .aws directory" {
            Remove-Item -Recurse -Force $helper.AwsDirectory

            $awsCreds = (Get-AWSCredentials default)

            New-Item -ItemType Directory $helper.AwsDirectory
        }

        It "should get credentials using -ProfileName positional parameter" {
            $helper.RegisterProfile("profile", "access", "secret", $null);
            
            $creds = Get-AWSCredentials profile
            
            $creds | Should -Not -BeNullOrEmpty
            $creds.GetType().Name | Should -Be BasicAWSCredentials
        }

        It "should be able to return AssumeRoleCredentials" {

            # register a source profile
            $helper.RegisterProfile("default", "access", "secret", $null);
            $store = (New-Object Amazon.Runtime.CredentialManagement.NetSdkCredentialsFile)
            [Amazon.Runtime.CredentialManagement.CredentialProfile] $profile = $null

            # create assume role credentials that point to the source profile
            $options = $helper.NewOptions()
            $options.RoleArn = "roleArn"
            $options.SourceProfile = "default"
            $awsCredentials = $helper.GetAWSCredentials($options, $null)

            # create the AWSPSCredentials and put it in the session
            $awsPSCredentials = $helper.GetAWSPSCredentials($awsCredentials, "awspscreds", "Profile")
            Set-Variable "StoredAWSCredentials" $awsPSCredentials

            # get the AWSPSCredentials using the cmdlet
            $creds = Get-AWSCredentials

            $creds | Should -Not -BeNullOrEmpty
            $creds.GetType().Name | Should -Be "AssumeRoleAWSCredentials"
            { $creds.GetCredentials() } | Should -Throw "*Error calling AssumeRole for role roleArn*"
        }

        It "should return session credentials if there are any" {
            $awsCredentials = New-Object Amazon.Runtime.BasicAWSCredentials("accessSession","secretSession")
            Set-Variable "StoredAWSCredentials" $helper.GetAWSPSCredentials($awsCredentials, "awspscreds", "Profile")

            $creds = Get-AWSCredentials

            $creds.GetCredentials().AccessKey | Should -Be accessSession
            $creds.GetCredentials().SecretKey | Should -Be secretSession
        }

        It "should prefer the .net credentials file over the shared credentials file" {
            $helper.RegisterProfile("preference", "accessShared", "secretShared", $helper.DefaultSharedPath)
            $helper.RegisterProfile("preference", "accessNet", "secretNet", $null)

            $creds = (Get-AWSCredentials preference)

            $creds.GetCredentials().AccessKey | Should -Be "accessNet"
            $creds.GetCredentials().SecretKey | Should -Be "secretNet"
        }

        It "should go to the shared file if .net credentials doesn't have the profile" {
            $helper.RegisterProfile("preference", "accessShared", "secretShared", $helper.DefaultSharedPath)

            $creds = (Get-AWSCredentials preference)

            $creds.GetCredentials().AccessKey | Should -Be "accessShared"
            $creds.GetCredentials().SecretKey | Should -Be "secretShared"
        }

        It "should go to the custom shared file if -ProfilesLocation is specified" {
            $helper.RegisterProfile("preference", "accessCustom", "secretCustom", $helper.CustomSharedPath)
            $helper.RegisterProfile("preference", "accessShared", "secretShared", $helper.DefaultSharedPath)
            $helper.RegisterProfile("preference", "accessNet", "secretNet", $null)

            $creds = (Get-AWSCredentials preference -ProfilesLocation $helper.CustomSharedPath)

            $creds.GetCredentials().AccessKey | Should -Be "accessCustom"
            $creds.GetCredentials().SecretKey | Should -Be "secretCustom"
        }

        It "should list profiles from the correct places if -ListProfileDetail or -ListProfile is specified" {
            $helper.RegisterProfile("net", "accessNet", "secretNet", $null)
            $helper.RegisterProfile("default", "accessShared", "secretShared", $helper.DefaultSharedPath)
            $helper.RegisterProfile("custom", "accessCustom", "secretCustom", $helper.CustomSharedPath)

            # test getting details from .NET credentials file
            $profileInfo = (Get-AWSCredentials -ListProfileDetail)

            $profileInfo[0].ProfileName | Should -Be "net"
            $profileInfo[0].StoreTypeName | Should -Be "NetSDKCredentialsFile"
            $profileInfo[0].ProfileLocation | Should -BeNullOrEmpty

            $profileInfo[1].ProfileName | Should -Be "default"
            $profileInfo[1].StoreTypeName | Should -Be "SharedCredentialsFile"
            $profileInfo[1].ProfileLocation | Should -Be $helper.DefaultSharedPath

            $profileInfo.Count | Should -Be 2

            # test getting names from .NET credentials file using -ListProfile Alias
            $profileInfo = (Get-AWSCredentials -ListProfile)
            $profileInfo[0].ProfileName | Should -Be "net"
            $profileInfo[1].ProfileName | Should -Be "default"
            $profileInfo.Count | Should -Be 2

            # test getting details from custom shared credentials file
            $profileInfo = (Get-AWSCredentials -ListProfileDetail -ProfileLocation $helper.CustomSharedPath)

            $profileInfo[0].ProfileName | Should -Be "custom"
            $profileInfo[0].StoreTypeName | Should -Be "SharedCredentialsFile"
            $profileInfo[0].ProfileLocation | Should -Be $helper.CustomSharedPath

            $profileInfo.Count | Should -Be 1
            
            # test getting names from default shared credentials file using -ListProfile Alias
            $profileInfo = (Get-AWSCredentials -ListProfile -ProfileLocation $helper.CustomSharedPath)
            $profileInfo[0].ProfileName | Should -Be "custom"
            $profileInfo[0].StoreTypeName | Should -Be "SharedCredentialsFile"
            $profileInfo[0].ProfileLocation | Should -Be $helper.CustomSharedPath

            # test getting details from default shared credentials file
            $profileInfo = (Get-AWSCredentials -ListProfileDetail -ProfileLocation $helper.DefaultSharedPath)

            $profileInfo[0].ProfileName | Should -Be "default"
            $profileInfo[0].StoreTypeName | Should -Be "SharedCredentialsFile"
            $profileInfo[0].ProfileLocation | Should -Be $helper.DefaultSharedPath

            $profileInfo.Count | Should -Be 1
            
            # test getting names from default shared credentials file using -ListProfile Alias
            $profileInfo = (Get-AWSCredentials -ListProfile -ProfileLocation $helper.DefaultSharedPath)
            $profileInfo[0].ProfileName | Should -Be "default"
            $profileInfo[0].StoreTypeName | Should -Be "SharedCredentialsFile"
            $profileInfo[0].ProfileLocation | Should -Be $helper.DefaultSharedPath

            $profileInfo.Count | Should -Be 1
        }
    }
}
