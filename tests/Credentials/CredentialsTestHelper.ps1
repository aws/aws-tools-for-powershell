class CredentialsTestHelper : TestHelper
{
    [string] $DefaultSharedPath
    [string] $CustomSharedPath
    [string] $NetSDKPath
    

    hidden [string] $AccessKeyEnv
    hidden [string] $SecretKeyEnv
    hidden [string] $TempDir
    hidden [string] $AwsDirectory
    hidden [string] $OriginalSettingsStoreFolder
    hidden [string] $OriginalCredentialsPath

    # Constructor
    CredentialsTestHelper()
    { 
    }

    [Void] BeforeAll()
    {
        ([TestHelper]$this).BeforeAll()
        # save credentials environment variables so we can revert them after the tests
        $this.AccessKeyEnv = $env:AWS_ACCESS_KEY_ID
        $this.SecretKeyEnv = $env:AWS_SECRET_ACCESS_KEY
        
        # set up the directories we need to run with
        $this.TempDir = (Join-Path (Get-Location) Temp)
        $this.AwsDirectory = (Join-Path $this.TempDir .aws)
        $this.DefaultSharedPath = (Join-Path $this.AwsDirectory credentials)
        $this.CustomSharedPath = ($this.DefaultSharedPath + "X")
        $this.NetSDKPath = (Join-Path $this.AwsDirectory RegisteredAccounts.json)

        if (-not (Test-Path -Path $this.TempDir))
        {
           New-Item $this.TempDir -Type directory
        }
        if (-not (Test-Path -Path $this.AwsDirectory))
        {
           New-Item $this.AwsDirectory -Type directory
        }
        
        #mock the sdk credentials folder and the default shared credentials folder to be the Temp\.aws directory
        $this.OriginalSettingsStoreFolder = $this.MockSetingsStoreFolder($this.AwsDirectory);
        $this.OriginalCredentialsPath = $this.MockCredentialsPath($this.DefaultSharedPath);
    }

    [Void] AfterAll()
    {
        if ($this.OriginalSettingsStoreFolder -ne $null) {
            $this.UnMockSettingsStoreFolder($this.OriginalSettingsStoreFolder)
        }

        if ($this.OriginalCredentialsPath -ne $null) {
            $this.UnMockCredentialsPath($this.OriginalCredentialsPath )
        }   
        
        $env:AWS_ACCESS_KEY_ID = $this.AccessKeyEnv
        $env:AWS_SECRET_ACCESS_KEY = $this.SecretKeyEnv 
        
        # this is necessary to remove any plaintext credentials from the build directory
	    if (Test-Path $this.AwsDirectory) { Remove-Item -Recurse -Force -Path $this.AwsDirectory }

        ([TestHelper]$this).AfterAll()
    }
    
    [Void] ClearAllCreds()
    {
        # delete credentials files
        if (Test-Path $this.NetSDKPath) { Remove-Item $this.NetSDKPath }
        if (Test-Path $this.DefaultSharedPath) { Remove-Item $this.DefaultSharedPath }
        if (Test-Path $this.CustomSharedPath) { Remove-Item $this.CustomSharedPath }

        # clear any session credentials
        Clear-AWSCredentials
        
        # clear out credentials environment variables
        $env:AWS_ACCESS_KEY_ID = $null
        $env:AWS_SECRET_ACCESS_KEY = $null
    }

    [string] MockSetingsStoreFolder($newSettingsStoreFolder) {
        $bindingFlags = [Reflection.BindingFlags] "NonPublic,Public,Static"
        $privateField = [Amazon.Runtime.Internal.Settings.PersistenceManager].GetField("SettingsStoreFolder", $bindingFlags);
        $result = $privateField.GetValue($null);
        $privateField.SetValue($null, $newSettingsStoreFolder);
        return $result
    }

    [Void] UnMockSettingsStoreFolder($originalSettingsStoreFolder) {
        $bindingFlags = [Reflection.BindingFlags] "NonPublic,Public,Static"
        $privateField = [Amazon.Runtime.Internal.Settings.PersistenceManager].GetField("SettingsStoreFolder", $bindingFlags);
        $privateField.SetValue($null, $originalSettingsStoreFolder);
    }

    [string] MockCredentialsPath($newCredentialsPath) {
    
        $bindingFlags = [Reflection.BindingFlags] "NonPublic,Public,Static"
        $privateField = [Amazon.Runtime.CredentialManagement.SharedCredentialsFile].GetField("DefaultFilePath", $bindingFlags);
        $result = $privateField.GetValue($null);
        $privateField.SetValue($null, $newCredentialsPath); 
        return $result          
    }

    [Void] UnMockCredentialsPath($originalCredentialsPath) {
        $bindingFlags = [Reflection.BindingFlags] "NonPublic,Public,Static"
        $privateField = [Amazon.Runtime.CredentialManagement.SharedCredentialsFile].GetField("DefaultFilePath", $bindingFlags);
        $privateField.SetValue($null, $originalCredentialsPath);
    }


    [Void] RegisterProfile($profileName, $accessKey, $secretKey, $profilesLocation) {
        [Amazon.Runtime.CredentialManagement.CredentialProfileOptions]$options = (New-Object Amazon.Runtime.CredentialManagement.CredentialProfileOptions)
        $options.AccessKey = $accessKey
        $options.SecretKey = $secretKey
        [Amazon.Runtime.CredentialManagement.CredentialProfile]$credentialProfile = New-Object -TypeName "Amazon.Runtime.CredentialManagement.CredentialProfile" ($profileName, $options)
        if ($profilesLocation -eq $null)
        {
            (New-Object Amazon.Runtime.CredentialManagement.NetSdkCredentialsFile).RegisterProfile($credentialProfile)
        }
        else
        {
            (New-Object Amazon.Runtime.CredentialManagement.SharedCredentialsFile ($profilesLocation)).RegisterProfile($credentialProfile)
        }
    }

    [Void] UnRegisterProfile($profileName, $profilesLocation) {
        if ($profilesLocation -eq $null)
        {
            (New-Object Amazon.Runtime.CredentialManagement.NetSdkCredentialsFile).UnRegisterProfile($profileName)
        }
        else
        {
            (New-Object Amazon.Runtime.CredentialManagement.SharedCredentialsFile ($profilesLocation)).UnRegisterProfile($profileName)
        }
    }
}





