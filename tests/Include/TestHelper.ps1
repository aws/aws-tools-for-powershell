class TestHelper
{
    [string] $AccessKey
    [string] $SecretKey
    [string] $Region

    TestHelper()
    {
    }

    [Void] BeforeAll()
    {
        try
        {
            #try to handle as dev machine
            Write-Output "Setting test credentials from local profile 'default'"
            $profile = $this.GetDefaultCredentialProfile()
            $this.AccessKey = $profile.Options.AccessKey
            $this.SecretKey = $profile.Options.SecretKey
            $this.Region = $profile.Region.SystemName
        }
        catch
        {
            #try to handle as build machine
            Write-Output "Setting test credentials from environment variables"
            $this.AccessKey = (Get-Item env:AWS_ACCESS_KEY_ID).Value
            $this.SecretKey =  (Get-Item env:AWS_SECRET_ACCESS_KEY).Value
            $this.Region =  (Get-Item env:AWS_REGION).Value
        }

        # similar to the Set-DefaultAWSRegion cmdlet, except this sets the region globally
        Set-Variable "StoredAWSRegion" -Value "us-east-1" -Scope Global
    }

    [Void] AfterAll()
    {
        # similar to the Set-DefaultAWSRegion cmdlet, except this sets the region globally
        Set-Variable "StoredAWSRegion" -Value "us-east-1" -Scope Global
    }

    [Void] LaunchDebugger()
    {
        [System.Diagnostics.Debugger]::Launch()
    }

    [Amazon.Runtime.CredentialManagement.CredentialProfile] GetDefaultCredentialProfile()
    {
        $chain = (New-Object Amazon.Runtime.CredentialManagement.CredentialProfileStoreChain)

        [Amazon.Runtime.CredentialManagement.CredentialProfile] $profile = $null

        $chain.TryGetProfile("default", [ref] $profile)

        return $profile
    }
}


