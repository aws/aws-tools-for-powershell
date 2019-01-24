class TestHelper
{
    [string] $AccessKey
    [string] $SecretKey

    TestHelper()
    {
    }

    [Void] BeforeAll()
    {
        Write-Output "Setting test credentials from local profile 'test-runner'"
        $profile = $this.GetDefaultCredentialProfile()
        $this.AccessKey = $profile.Options.AccessKey
        $this.SecretKey = $profile.Options.SecretKey
		
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
         $chain.TryGetProfile("test-runner", [ref] $profile)
         return $profile
     }
}