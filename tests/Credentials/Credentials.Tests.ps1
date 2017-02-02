. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
Describe -Tag "Smoke" "Credentials" {

    function ClearAllCreds {
        # delete credentials files
        if (Test-Path $netSDKCredentialsPath) { Remove-Item $netSDKCredentialsPath }
        if (Test-Path $defaultCredentialsPath) { Remove-Item $defaultCredentialsPath }
        if (Test-Path $customCredentialsPath) { Remove-Item $customCredentialsPath }

        # clear any session credentials
        Clear-AWSCredentials
        
        # clear out credentials environment variables
        $env:AWS_ACCESS_KEY_ID = $null
        $env:AWS_SECRET_ACCESS_KEY = $null
    }
    
    BeforeAll {
        . (Join-Path (Join-Path (Get-Location) Credentials) "CredentialsTestHelpers.ps1")

        # save credentials environment variables so we can revert them after the tests
        $accessKeyEnv = $env:AWS_ACCESS_KEY_ID
        $secretKeyEnv = $env:AWS_SECRET_ACCESS_KEY
        
        # set up the directories we need to run with
        $tempDir = (Join-Path (Get-Location) Temp)
        $awsDirectory = (Join-Path $tempDir .aws)
        $defaultCredentialsPath = (Join-Path $awsDirectory credentials)
        $customCredentialsPath = ($defaultCredentialsPath + "X")
        $credsResourcePath = (Join-Path (Join-Path (Get-Location) TestResources) credentials)
        $netSDKCredentialsPath = (Join-Path $awsDirectory RegisteredAccounts.json)

        if (-not (Test-Path -Path $tempDir))
        {
           New-Item $tempDir -Type directory
        }
        if (-not (Test-Path -Path $awsDirectory))
        {
           New-Item $awsDirectory -Type directory
        }
        
        #mock the sdk credentials folder and the default shared credentials folder to be the Temp\.aws directory
        $originalSettingsStoreFolder = MockSetingsStoreFolder($awsDirectory);
        $originalCredentialsPath = MockCredentialsPath($defaultCredentialsPath);
    }

    AfterAll {
	
        # this is necessary to remove any plaintext credentials from the build directory
	    if (Test-Path $awsDirectory) { Remove-Item -Recurse -Force -Path $awsDirectory }
        
        Set-AWSCredentials -AccessKey $testCreds.AccessKey -SecretKey $testCreds.SecretKey

        if ($originalSettingsStoreFolder -ne $null) {
            UnMockSettingsStoreFolder $originalSettingsStoreFolder 
        }

        if ($originalCredentialsPath -ne $null) {
            UnMockCredentialsPath $originalCredentialsPath 
        }   
        
        $env:AWS_ACCESS_KEY_ID = $accessKeyEnv
        $env:AWS_SECRET_ACCESS_KEY = $secretKeyEnv 
    }

    Context "Get-S3Bucket" {
    
        BeforeEach {
            ClearAllCreds
        }

        AfterEach {
            ClearAllCreds
        }

        It "should fail with no credentials set" {
            # unfortunately, this takes 15 seconds...
            { Get-S3Bucket } | Should Throw "No credentials specified or obtained from persisted/shell defaults."
        }

        It "should work with environment variables set" {
            $env:AWS_ACCESS_KEY_ID = $testCreds.AccessKey
            $env:AWS_SECRET_ACCESS_KEY = $testCreds.SecretKey
            
            $buckets = Get-S3Bucket
            $buckets.BucketName | Should BeGreaterThan 0
        }      
        
        It "should work with a default profile in the .net credentials file" {
            RegisterProfile default $testCreds.AccessKey $testCreds.SecretKey $null
            
            $buckets = Get-S3Bucket
            $buckets.BucketName | Should BeGreaterThan 0
        }
        
        It "should work with a default profile in the shared credentials file" {
            RegisterProfile default $testCreds.AccessKey $testCreds.SecretKey $defaultCredentialsPath
            
            $buckets = Get-S3Bucket
            $buckets.BucketName | Should BeGreaterThan 0
        }

        It "should fail with invalid credentials from the shared credentials file in the default location" {
            RegisterProfile invalid invalidAccessKey invalidSecretKey $defaultCredentialsPath

            { Get-S3Bucket -ProfileName invalid } | Should Throw "The AWS Access Key Id you provided does not exist in our records."
        }

        It "should work with valid credentials from the shared credentials file in the default location" {
            RegisterProfile valid $testCreds.AccessKey $testCreds.SecretKey $defaultCredentialsPath
            
            $buckets = Get-S3Bucket -ProfileName valid
            $buckets.BucketName | Should BeGreaterThan 0
        }

        It "should fail with invalid credentials from the shared credentials file in a custom location" {
            RegisterProfile invalid invalidAccessKey invalidSecretKey $customCredentialsPath

            { Get-S3Bucket -ProfileName invalid -ProfilesLocation $customCredentialsPath } | Should Throw "The AWS Access Key Id you provided does not exist in our records."
        }

        It "should work with valid credentials from the shared credentials file in a custom location" {
            RegisterProfile valid $testCreds.AccessKey $testCreds.SecretKey $customCredentialsPath
            
            $buckets = Get-S3Bucket -ProfileName valid -ProfilesLocation $customCredentialsPath
            $buckets.BucketName | Should BeGreaterThan 0
        }
    }

    Context "Get-AWSCredentials" {

        BeforeEach {
            ClearAllCreds 
            Clear-AWSCredentials
        }

        AfterEach {
           ClearAllCreds
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
            RegisterProfile preference accessShared secretShared $defaultCredentialsPath
            RegisterProfile preference accessNet secretNet $null

            $creds = (Get-AWSCredentials preference)

            $creds.GetCredentials().AccessKey | Should Be "accessNet"
            $creds.GetCredentials().SecretKey | Should Be "secretNet"
        }

        It "should go to the shared file if .net credentials doesn't have the profile" {  
            RegisterProfile preference accessShared secretShared $defaultCredentialsPath
            
            $creds = (Get-AWSCredentials preference)

            $creds.GetCredentials().AccessKey | Should Be "accessShared"
            $creds.GetCredentials().SecretKey | Should Be "secretShared"
        }
        
        It "should go to the custom shared file if -ProfilesLocation is specified" {
            RegisterProfile preference accessCustom secretCustom $customCredentialsPath
            RegisterProfile preference accessShared secretShared $defaultCredentialsPath
            RegisterProfile preference accessNet secretNet $null

            $creds = (Get-AWSCredentials preference -ProfilesLocation $customCredentialsPath)

            $creds.GetCredentials().AccessKey | Should Be "accessCustom"
            $creds.GetCredentials().SecretKey | Should Be "secretCustom"
        }
    }
}
    
