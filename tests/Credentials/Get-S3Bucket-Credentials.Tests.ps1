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

    Context "Get-S3Bucket" {
        BeforeEach {
           $helper.ClearAllCreds()
        }

        AfterEach {
           $helper.ClearAllCreds()
        }

        It "should fail with no credentials set" {
            # unfortunately, this takes 15 seconds...
            { Get-S3Bucket } | Should Throw "No credentials specified or obtained from persisted/shell defaults."
        }

        It "should work with environment variables set" {
            $env:AWS_ACCESS_KEY_ID = $helper.accessKey
            $env:AWS_SECRET_ACCESS_KEY = $helper.secretKey
            
            $buckets = Get-S3Bucket
            $buckets.BucketName | Should BeGreaterThan 0
        }      
        
        It "should work with a default profile in the .net credentials file" {
            $helper.RegisterProfile("default", $helper.AccessKey, $helper.SecretKey, $null)
            
            $buckets = Get-S3Bucket
            $buckets.BucketName | Should BeGreaterThan 0
        }
        
        It "should work with a default profile in the shared credentials file" {
            $helper.RegisterProfile("default", $helper.AccessKey, $helper.SecretKey, $helper.DefaultSharedPath)
            
            $buckets = Get-S3Bucket
            $buckets.BucketName | Should BeGreaterThan 0
        }

        It "should fail with invalid credentials from the shared credentials file in the default location" {
            $helper.RegisterProfile("invalid", "invalidAccessKey", "invalidSecretKey", $helper.DefaultSharedPath)

            { Get-S3Bucket -ProfileName invalid } | Should Throw "The AWS Access Key Id you provided does not exist in our records."
        }

        It "should work with valid credentials from the shared credentials file in the default location" {
            $helper.RegisterProfile("valid", $helper.AccessKey, $helper.SecretKey, $helper.DefaultSharedPath)
            
            $buckets = Get-S3Bucket -ProfileName valid
            $buckets.BucketName | Should BeGreaterThan 0
        }

        It "should fail with invalid credentials from the shared credentials file in a custom location" {
            $helper.RegisterProfile("invalid", "invalidAccessKey", "invalidSecretKey", $helper.CustomSharedPath)

            { Get-S3Bucket -ProfileName invalid -ProfilesLocation $helper.CustomSharedPath } | Should Throw "The AWS Access Key Id you provided does not exist in our records."
        }

        It "should work with valid credentials from the shared credentials file in a custom location" {
            $helper.RegisterProfile("valid", $helper.AccessKey, $helper.SecretKey, $helper.CustomSharedPath)
            
            $buckets = Get-S3Bucket -ProfileName valid -ProfilesLocation $helper.CustomSharedPath
            $buckets.BucketName | Should BeGreaterThan 0
        }

        It "should work with basic credentials on the command line" {
            $buckets = Get-S3Bucket -AccessKey $helper.AccessKey -SecretKey $helper.SecretKey
            $buckets.BucketName | Should BeGreaterThan 0
        }

        It "should accept session credentials on the command line" {
            { Get-S3Bucket -AccessKey $helper.AccessKey -SecretKey $helper.SecretKey -SessionToken invalid_token } | Should Throw "The provided token is malformed or otherwise invalid."
        }
    }
}