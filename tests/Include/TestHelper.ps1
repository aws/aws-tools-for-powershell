class TestHelper
{
    [string] $AccessKey
    [string] $SecretKey

    TestHelper()
    {     
    }

    [Void] BeforeAll()
    {
        # get some good credentials from somewhere, in order to run the tests
        try
        {
            #try to handle as dev machine
            $profileCreds =  Get-AWSCredentials default
            Write-Output "Setting test credentials from local profile 'default'"
            $testCreds = $profileCreds.GetCredentials()
            $this.AccessKey = $testCreds.AccessKey
            $this.SecretKey = $testCreds.SecretKey
        }
        catch
        {
            #try to handle as build machine
            Write-Output "Setting test credentials from environment variables"
            $this.AccessKey = (Get-Item env:AWS_ACCESS_KEY_ID).Value
            $this.SecretKey =  (Get-Item env:AWS_SECRET_ACCESS_KEY).Value
        }

        Set-DefaultAWSRegion -Region us-east-1
    }

    [Void] AfterAll()
    {
    }
}


