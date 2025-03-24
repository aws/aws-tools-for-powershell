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

Describe -Tag "Smoke" "Get-S3Bucket-Credentials" {

    Context "Get-S3Bucket" {
        BeforeEach {
           $helper.ClearAllCreds()
        }

        AfterEach {
           $helper.ClearAllCreds()
        }

        It "should work with environment variables set" {
            $env:AWS_ACCESS_KEY_ID = $helper.AccessKey
            $env:AWS_SECRET_ACCESS_KEY = $helper.SecretKey
            $env:AWS_SESSION_TOKEN = $helper.Token
            $env:AWS_REGION = $helper.Region

            $buckets = Get-S3Bucket
            $buckets.BucketName | Should -BeGreaterThan 0
        }

        It "should work with a default profile in the .net credentials file" {
            $helper.RegisterProfile("default", $helper.AccessKey, $helper.SecretKey, $null, $helper.Token)

            $buckets = Get-S3Bucket
            $buckets.BucketName | Should -BeGreaterThan 0
        }

        It "should work with a default profile in the shared credentials file" {
            $helper.RegisterProfile("default", $helper.AccessKey, $helper.SecretKey, $helper.DefaultSharedPath,  $helper.Token)

            $buckets = Get-S3Bucket
            $buckets.BucketName | Should -BeGreaterThan 0
        }

        It "should fail with invalid credentials from the shared credentials file in the default location" {
            $helper.RegisterProfile("invalid", "invalidAccessKey", "invalidSecretKey", $helper.DefaultSharedPath)

            { Get-S3Bucket -ProfileName invalid } | Should -Throw "The AWS Access Key Id you provided does not exist in our records."
        }

        It "should work with valid credentials from the shared credentials file in the default location" {
            $helper.RegisterProfile("valid", $helper.AccessKey, $helper.SecretKey, $helper.DefaultSharedPath, $helper.Token)

            $buckets = Get-S3Bucket -ProfileName valid
            $buckets.BucketName | Should -BeGreaterThan 0
        }

        It "should fail with invalid credentials from the shared credentials file in a custom location" {
            $helper.RegisterProfile("invalid", "invalidAccessKey", "invalidSecretKey", $helper.CustomSharedPath)

            { Get-S3Bucket -ProfileName invalid -ProfilesLocation $helper.CustomSharedPath } | Should -Throw "The AWS Access Key Id you provided does not exist in our records."
        }

        It "should work with valid credentials from the shared credentials file in a custom location" {
            $helper.RegisterProfile("valid", $helper.AccessKey, $helper.SecretKey, $helper.CustomSharedPath, $helper.Token)

            $buckets = Get-S3Bucket -ProfileName valid -ProfilesLocation $helper.CustomSharedPath
            $buckets.BucketName | Should -BeGreaterThan 0
        }

        It "should work with basic credentials on the command line" {
            $buckets = Get-S3Bucket -AccessKey $helper.AccessKey -SecretKey $helper.SecretKey -SessionToken $helper.Token
            $buckets.BucketName | Should -BeGreaterThan 0
        }

        It "should accept session credentials on the command line" {
            { Get-S3Bucket -AccessKey $helper.AccessKey -SecretKey $helper.SecretKey -SessionToken invalid_token } | Should -Throw "The provided token is malformed or otherwise invalid."
        }
    }

    Context "Credential Resolution Order" {

        BeforeEach {
            $helper.ClearAllCreds()
        }
        AfterEach {
            $helper.ClearAllCreds()
        }

        # Setting ENVACCESSKEY and AWSACCESSKEY to to verify that the flow correctly identifies and utilizes the intended credentials. 
        # If the credentials are not properly picked up, these dummy values are expected to throw an error, which confirms the flow's behavior.
        # Link to user guide for the correct credentials resolution order - https://docs.aws.amazon.com/powershell/latest/userguide/creds-assign.html
        It "should follow correct credential resolution order when multiple sources are present" {
            # 1. Create profiles in shared and net sdk credentials file
            $helper.RegisterProfile("default", $helper.AccessKey, $helper.SecretKey, $null, $helper.Token)
            $helper.RegisterProfile("default", $helper.AccessKey, $helper.SecretKey, $helper.DefaultSharedPath, $helper.Token)
            $helper.RegisterProfile("AWS PS Default", $helper.AccessKey, $helper.SecretKey, $null, $helper.Token)
            
            # 2. Environment variables
            $env:AWS_ACCESS_KEY_ID = $helper.AccessKey
            $env:AWS_SECRET_ACCESS_KEY = $helper.SecretKey
            $env:AWS_SESSION_TOKEN = $helper.Token
            
            # 4. Set-AWSCredential
            Set-AWSCredential -AccessKey $helper.AccessKey -SecretKey $helper.SecretKey -SessionToken $helper.Token -StoreAs "test-profile-creds"
            Set-AWSCredential -ProfileName "test-profile-creds"
            
            # 5. Command-line parameters (should take precedence) and verify that these took precedence
            $buckets = Get-S3Bucket -AccessKey $helper.AccessKey -SecretKey $helper.SecretKey -SessionToken $helper.Token        
            $buckets.BucketName | Should -BeGreaterThan 0
            (Get-AWSCredential).GetCredentials().AccessKey | Should -Be $helper.AccessKey
            
            # Remove command-line parameters and verify Set-AWSCredential takes precedence
            $buckets = Get-S3Bucket
            $buckets.BucketName | Should -BeGreaterThan 0
            (Get-AWSCredential).GetCredentials().AccessKey | Should -Be $helper.AccessKey

            # Clear Set-AWSCredential
            Clear-AWSCredential
            
            # Verify environment variables take precedence after Clear-AWSCredential
            $buckets = Get-S3Bucket
            $buckets.BucketName | Should -BeGreaterThan 0
            $env:AWS_ACCESS_KEY_ID | Should -Be $helper.AccessKey
            
            # Clear environment variables and verify shared credentials file is used
            Remove-Item Env:\AWS_ACCESS_KEY_ID
            Remove-Item Env:\AWS_SECRET_ACCESS_KEY
            Remove-Item Env:\AWS_SESSION_TOKEN
            
            #Verify that the default profile from Net SDK file credentials is being used 
            $buckets = Get-S3Bucket
            $buckets.BucketName | Should -BeGreaterThan 0
            Remove-AWSCredentialProfile -ProfileName 'default' -Force -ProfileLocation $null

            # Verify that the default profile the shared credentials file is being used
            $buckets = Get-S3Bucket
            $buckets.BucketName | Should -BeGreaterThan 0
            $env:AWS_ACCESS_KEY_ID | Should -BeNull
            $sharedCreds = Get-AWSCredential -ProfileName 'default'
            $sharedCreds.GetCredentials().AccessKey | Should -Be $helper.AccessKey
            Remove-AWSCredentialProfile -ProfileName 'default' -Force -ProfileLocation $helper.DefaultSharedPath

            #Verify that the AWS PS default profile from Net SDK credentials file is being used
            $buckets = Get-S3Bucket
            $buckets.BucketName | Should -BeGreaterThan 0
            $sdkCreds = Get-AWSCredential -ProfileName "AWS PS default"
            $sdkCreds.GetCredentials().AccessKey | Should -Be $helper.AccessKey
        }
        
        It "should prioritize Set-AWSCredential over environment variables" {
            $env:AWS_ACCESS_KEY_ID = "ENVACCESKEY"
            $env:AWS_SECRET_ACCESS_KEY = "ENVSECRETKEY"

            Set-AWSCredential -AccessKey $helper.AccessKey -SecretKey $helper.SecretKey -SessionToken $helper.Token -StoreAs "test-profile-creds"
            Set-AWSCredential -ProfileName "test-profile-creds"

            $buckets = Get-S3Bucket
            $buckets.BucketName | Should -BeGreaterThan 0
            (Get-AWSCredential).GetCredentials().AccessKey | Should -Be $helper.AccessKey
        }

        It "should prioritize and throw exception as Set-AWSCredential would have wrong credentials" {
            $env:AWS_ACCESS_KEY_ID = $helper.AccessKey
            $env:AWS_SECRET_ACCESS_KEY = $helper.SecretKey

            Set-AWSCredential -AccessKey "AWSACCESSKEY" -SecretKey "AWSSECRETKEY" -SessionToken "AWSSESSIONTOKEN" -StoreAs "test-profile-creds"
            Set-AWSCredential -ProfileName "test-profile-creds"
            
            { Get-S3Bucket } | Should -Throw
            (Get-AWSCredential).GetCredentials().AccessKey | Should -Be "AWSACCESSKEY"
        }

        It "should priotitize Credential parameter over environment variables and profile credentials" {
            $env:AWS_ACCESS_KEY_ID = "ENVACCESKEY"
            $env:AWS_SECRET_ACCESS_KEY = "ENVSECRETKEY"

            Set-AWSCredential -AccessKey "AWSACCESSKEY" -SecretKey "AWSSECRETKEY" -SessionToken $helper.Token -StoreAs "test-profile-creds"
            Set-AWSCredential -ProfileName "test-profile-creds"
            $creds = New-AWSCredential -AccessKey $helper.AccessKey -SecretKey $helper.SecretKey -SessionToken $helper.Token
    
            $buckets = Get-S3Bucket -Credential $creds
            $buckets.BucketName | Should -BeGreaterThan 0
            (Get-AWSCredential).GetCredentials().AccessKey | Should -Be "AWSACCESSKEY"
        }

        It "should prioritize and throw exception as the Credentials parameter has wrong credentials" {
            $env:AWS_ACCESS_KEY_ID = "ENVACCESKEY"
            $env:AWS_SECRET_ACCESS_KEY = "ENVSECRETKEY"

            Set-AWSCredential -AccessKey $helper.AccessKey -SecretKey $helper.SecretKey -SessionToken $helper.Token -StoreAs "test-profile-creds"
            Set-AWSCredential -ProfileName "test-profile-creds"
            $creds = New-AWSCredential -AccessKey "AWSACCESSKEY" -SecretKey "AWSSECRETKEY" -SessionToken "AWSSESSIONTOKEN"

            { Get-S3Bucket -Credential $creds } | Should -Throw
            (Get-AWSCredential).GetCredentials().AccessKey | Should -Be $helper.AccessKey
        }

        It "should use specified profile when -ProfileName is provided" {
            Set-AWSCredential -AccessKey $helper.AccessKey -SecretKey $helper.SecretKey -SessionToken $helper.Token -StoreAs "test-profile-creds"
            Set-AWSCredential -ProfileName "test-profile-creds"
            
            $buckets = Get-S3Bucket -ProfileName "test-profile-creds"
            $buckets.BucketName | Should -BeGreaterThan 0
            (Get-AWSCredential -ProfileName "test-profile-creds").GetCredentials().AccessKey | Should -Be $helper.AccessKey
        }

        It "should prioritize and throw exception as -AccessKey and -SecretKey parameters have wrong credentials" {
            $env:AWS_ACCESS_KEY_ID = $helper.AccessKey
            $env:AWS_SECRET_ACCESS_KEY = $helper.SecretKey

            Set-AWSCredential -AccessKey $helper.AccessKey -SecretKey $helper.SecretKey -SessionToken $helper.Token -StoreAs "test-profile-creds"
            Set-AWSCredential -ProfileName "test-profile-creds"

            { Get-S3Bucket -AccessKey "AWSACCESSKEY" -SecretKey "AWSSECRETKEY" -SessionToken "AWSSESSIONTOKEN"} | Should -Throw
            (Get-AWSCredential).GetCredentials().AccessKey | Should -Be $helper.AccessKey
        }

        It "should use profile specified in AWS_PROFILE environment variable" {
            Set-AWSCredential -AccessKey $helper.AccessKey -SecretKey $helper.SecretKey -SessionToken $helper.Token -StoreAs "test-profile-creds"
            $env:AWS_PROFILE = "test-profile-creds"

            $buckets = Get-S3Bucket
            $buckets.BucketName | Should -BeGreaterThan 0
        }
    }
}
