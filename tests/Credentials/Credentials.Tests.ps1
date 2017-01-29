Describe -Tag "Smoke" "Credentials" {

    BeforeAll {

        # get some credentials to search/replace into the test credentials file

        # build server uses environment variables, dev machines use profiles - try
        # to handle both scenarios
        try
        {
            $profileCreds =  Get-AWSCredentials default
            Write-Output "Setting test credentials from local profile 'default'"

            $testCreds = $profileCreds.GetCredentials()
        }
        catch
        {
            Write-Output "Setting test credentials from environment variables"

            $testCreds = New-Object PSObject
            $testCreds | Add-Member -NotePropertyName AccessKey -NotePropertyValue (Get-Item env:AWS_ACCESS_KEY_ID).Value
            $testCreds | Add-Member -NotePropertyName SecretKey -NotePropertyValue (Get-Item env:AWS_SECRET_ACCESS_KEY).Value
        }

        # make sure we're really using credentials from the shared credentials file
        Set-AWSCredentials -AccessKey "TotallyInvalid" -SecretKey "TotallyInvalid"

        # set HOME so that the SharedCredentialsFile thinks the default location is the Temp directory for this test
        $originalHome = $env:HOME
        $env:HOME = (Join-Path (Get-Location) Temp)

        # set up the directories we need to run with
        $awsDirectory = (Join-Path $env:HOME .aws)
        $defaultCredentialsPath = Join-Path $awsDirectory credentials
        $customCredentialsPath = $defaultCredentialsPath + "X"
        $credsResourcePath = (Join-Path (Join-Path (Get-Location) TestResources) credentials)

        if (-NOT (Test-Path -Path $env:HOME))
        {
           New-Item $env:HOME -Type directory
        }

        if (Test-Path -Path $awsDirectory)
        {
           Remove-Item $awsDirectory -Recurse -Force
        }

        New-Item $awsDirectory -Type directory

        # copy the test credentials file and replace the keys with the valid ones we got earlier
        (Get-Content $credsResourcePath) | Foreach-Object {
            $_ -replace 'ACCESS_KEY_1', $testCreds.AccessKey `
               -replace 'SECRET_KEY_1', $testCreds.SecretKey
        } | Set-Content $defaultCredentialsPath

        # copy the credentials file to credentialsX so we know it's not using the default location
        Copy-item $defaultCredentialsPath $customCredentialsPath
    }

    AfterAll {
        $env:HOME = $originalHome
    }

    Context "Get-S3Bucket" {

        It "fails with invalid credentials from the shared credentials file in the default location" {
             { Get-S3Bucket -ProfileName invalid } | Should Throw "The AWS Access Key Id you provided does not exist in our records."
        }

        It "works with valid credentials from the shared credentials file in the default location" {
             $buckets = Get-S3Bucket -ProfileName valid
             $buckets.BucketName | Should BeGreaterThan 0
        }

        It "fails with invalid credentials from the shared credentials file in a custom location" {
             { Get-S3Bucket -ProfileName invalid  -ProfilesLocation $customCredentialsPath } | Should Throw "The AWS Access Key Id you provided does not exist in our records."
        }

        It "works with valid credentials from the shared credentials file in a custom location" {
             $buckets = Get-S3Bucket -ProfileName valid -ProfilesLocation $customCredentialsPath
             $buckets.BucketName | Should BeGreaterThan 0
        }
    }
}
