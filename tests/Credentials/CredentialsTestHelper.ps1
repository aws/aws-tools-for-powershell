class CredentialsTestHelper : TestHelper
{
    [string] $DefaultSharedPath
    [string] $CustomSharedPath
    [string] $NetSDKPath
    [string] $AwsDirectory


    hidden [string] $AccessKeyEnv
    hidden [string] $SecretKeyEnv
    hidden [string] $RegionEnv
    hidden [string] $TempDir
    hidden [string] $OriginalSettingsStoreFolder
    hidden [string] $OriginalCredentialsPath
    hidden [string] $OriginalInstanceMetadataServer

    hidden [string] $FakeMetadataIp = "127.0.0.1"
    hidden [string] $RealMetadataIp = "169.254.169.254"

    CredentialsTestHelper()
    {
    }

    [Void] BeforeAll()
    {
        ([TestHelper]$this).BeforeAll()

        # save credentials environment variables so we can revert them after the tests
        $this.AccessKeyEnv = $env:AWS_ACCESS_KEY_ID
        $this.SecretKeyEnv = $env:AWS_SECRET_ACCESS_KEY
        $this.RegionEnv = $env:AWS_REGION

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

        #mock the instance metadata server url to cause a fast-fail when no credentials or region are available
        $this.MockInstanceMetadataServer()
    }

    [Void] AfterAll()
    {
        if ($this.OriginalSettingsStoreFolder -ne $null)
        {
            $this.UnMockSettingsStoreFolder($this.OriginalSettingsStoreFolder)
        }

        if ($this.OriginalCredentialsPath -ne $null)
        {
            $this.UnMockCredentialsPath($this.OriginalCredentialsPath )
        }

        $env:AWS_ACCESS_KEY_ID = $this.AccessKeyEnv
        $env:AWS_SECRET_ACCESS_KEY = $this.SecretKeyEnv
        $env:AWS_REGION = $this.RegionEnv

        # this is necessary to remove any plaintext credentials from the build directory
	    if (Test-Path $this.AwsDirectory) { Remove-Item -Recurse -Force -Path $this.AwsDirectory }

        #unmock the instance profile server
        $this.UnMockInstanceMetadataServer()

        # call base implementation
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
        $env:AWS_REGION = $null
    }

    [Void] MockInstanceMetadataServer()
    {
        $this.MockMetadataField([Amazon.Util.EC2InstanceMetadata], "EC2_METADATA_SVC", $null)
        $this.MockMetadataField([Amazon.Util.EC2InstanceMetadata], "EC2_METADATA_ROOT", $null)
        $this.MockMetadataField([Amazon.Util.EC2InstanceMetadata], "EC2_USERDATA_ROOT", $null)
        $this.MockMetadataField([Amazon.Util.EC2InstanceMetadata], "EC2_DYNAMICDATA_ROOT", $null)
        $this.MockMetadataField([Amazon.Runtime.InstanceProfileAWSCredentials], "Server", [Reflection.BindingFlags] "Static,NonPublic")
    }

    [Void] UnMockInstanceMetadataServer()
    {
        $this.UnMockMetadataField([Amazon.Util.EC2InstanceMetadata], "EC2_METADATA_SVC", $null)
        $this.UnMockMetadataField([Amazon.Util.EC2InstanceMetadata], "EC2_METADATA_ROOT", $null)
        $this.UnMockMetadataField([Amazon.Util.EC2InstanceMetadata], "EC2_USERDATA_ROOT", $null)
        $this.UnMockMetadataField([Amazon.Util.EC2InstanceMetadata], "EC2_DYNAMICDATA_ROOT", $null)
        $this.UnMockMetadataField([Amazon.Runtime.InstanceProfileAWSCredentials], "Server", [Reflection.BindingFlags] "Static,NonPublic")
    }

    [void] MockMetadataField($type, $fieldName, $bindingFlags)
    {
        $this.ReplaceInStringField($type, $fieldName, $bindingFlags, $this.RealMetadataIp, $this.FakeMetadataIp)
    }

    [void] UnMockMetadataField($type, $fieldName, $bindingFlags)
    {
        $this.ReplaceInStringField($type, $fieldName, $bindingFlags, $this.FakeMetadataIp, $this.RealMetadataIp)
    }

    [void] ReplaceInStringField($type, $fieldName, $bindingFlags, $old, $new)
    {
        if ($bindingFlags -eq $null)
        {
            $field = $type.GetField($fieldName)
        }
        else
        {
            $field = $type.GetField($fieldName, $bindingFlags)
        }

        $value = $field.GetValue($null)
        $value = $value.Replace($old, $new)
        $field.SetValue($null, $value);
    }

    [string] MockSetingsStoreFolder($newSettingsStoreFolder)
    {
        $bindingFlags = [Reflection.BindingFlags] "NonPublic,Public,Static"
        $privateField = [Amazon.Runtime.Internal.Settings.PersistenceManager].GetField("SettingsStoreFolder", $bindingFlags);
        $result = $privateField.GetValue($null);
        $privateField.SetValue($null, $newSettingsStoreFolder);
        return $result
    }

    [Void] UnMockSettingsStoreFolder($originalSettingsStoreFolder)
    {
        $bindingFlags = [Reflection.BindingFlags] "NonPublic,Public,Static"
        $privateField = [Amazon.Runtime.Internal.Settings.PersistenceManager].GetField("SettingsStoreFolder", $bindingFlags);
        $privateField.SetValue($null, $originalSettingsStoreFolder);
    }

    [string] MockCredentialsPath($newCredentialsPath)
    {

        $bindingFlags = [Reflection.BindingFlags] "NonPublic,Public,Static"
        $privateField = [Amazon.Runtime.CredentialManagement.SharedCredentialsFile].GetField("DefaultFilePath", $bindingFlags);
        $result = $privateField.GetValue($null);
        $privateField.SetValue($null, $newCredentialsPath);
        return $result
    }

    [Void] UnMockCredentialsPath($originalCredentialsPath)
    {
        $bindingFlags = [Reflection.BindingFlags] "NonPublic,Public,Static"
        $privateField = [Amazon.Runtime.CredentialManagement.SharedCredentialsFile].GetField("DefaultFilePath", $bindingFlags);
        $privateField.SetValue($null, $originalCredentialsPath);
    }


    [Void] RegisterProfile($profileName, $profilesLocation, $options)
    {
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

    [Void] RegisterProfile($profileName, $accessKey, $secretKey, $profilesLocation)
    {
        $this.RegisterProfile($profileName, $accessKey, $secretKey, $null, $profilesLocation)
    }

    [Void] RegisterProfile($profileName, $accessKey, $secretKey, $region, $profilesLocation)
    {
        [Amazon.Runtime.CredentialManagement.CredentialProfileOptions]$options = (New-Object Amazon.Runtime.CredentialManagement.CredentialProfileOptions)
        $options.AccessKey = $accessKey
        $options.SecretKey = $secretKey
        [Amazon.Runtime.CredentialManagement.CredentialProfile]$credentialProfile = New-Object -TypeName "Amazon.Runtime.CredentialManagement.CredentialProfile" ($profileName, $options)

        if ($region -ne $null)
        {
            $credentialProfile.Region = [Amazon.RegionEndpoint]::GetBySystemName($region)
        }

        if ($profilesLocation -eq $null)
        {
            (New-Object Amazon.Runtime.CredentialManagement.NetSdkCredentialsFile).RegisterProfile($credentialProfile)
        }
        else
        {
            (New-Object Amazon.Runtime.CredentialManagement.SharedCredentialsFile ($profilesLocation)).RegisterProfile($credentialProfile)
        }
    }

    [Amazon.Runtime.CredentialManagement.ICredentialProfileStore] GetProfileStore($profilesLocation)
    {
        if ($profilesLocation -eq $null)
        {
            return (New-Object Amazon.Runtime.CredentialManagement.NetSdkCredentialsFile)
        }
        else
        {
            return (New-Object Amazon.Runtime.CredentialManagement.SharedCredentialsFile ($profilesLocation))
        }
    }

    [Void] UnRegisterProfile($profileName, $profilesLocation)
    {
        if ($profilesLocation -eq $null)
        {
            (New-Object Amazon.Runtime.CredentialManagement.NetSdkCredentialsFile).UnRegisterProfile($profileName)
        }
        else
        {
            (New-Object Amazon.Runtime.CredentialManagement.SharedCredentialsFile ($profilesLocation)).UnRegisterProfile($profileName)
        }
    }

    [Amazon.Runtime.CredentialManagement.CredentialProfileOptions] NewOptions()
    {
        return (New-Object Amazon.Runtime.CredentialManagement.CredentialProfileOptions)
    }

    [Amazon.Runtime.CredentialManagement.CredentialProfile] GetCredentialProfile($profileLocation, $profileName)
    {
        if ($profileLocation -eq $null)
        {
            $store = (New-Object Amazon.Runtime.CredentialManagement.NetSdkCredentialsFile)
        }
        else
        {
            $store = (New-Object Amazon.Runtime.CredentialManagement.SharedCredentialsFile ($profileLocation))
        }

        [Amazon.Runtime.CredentialManagement.CredentialProfile] $profile = $null

        $store.TryGetProfile($profileName, [ref] $profile)

        return $profile
    }

    [Amazon.Runtime.AWSCredentials] GetAWSCredentials([Amazon.Runtime.CredentialManagement.CredentialProfileOptions] $options, $profilesLocation)
    {
        if ($profilesLocation -eq $null)
        {
            $store = (New-Object Amazon.Runtime.CredentialManagement.NetSdkCredentialsFile)
        }
        else
        {
            $store = (New-Object Amazon.Runtime.CredentialManagement.SharedCredentialsFile ($profilesLocation))
        }

        return [Amazon.Runtime.CredentialManagement.AWSCredentialsFactory]::GetAWSCredentials($options, $store)
    }

    [Amazon.PowerShell.Common.AWSPSCredentials] GetAWSPSCredentials([Amazon.Runtime.AWSCredentials] $credentials, [string] $name, [string] $source)
    {
        [System.Type[]] $types = @([Amazon.Runtime.AWSCredentials], [string], [Amazon.PowerShell.Common.CredentialsSource])
        $constructor = [Amazon.PowerShell.Common.AWSPSCredentials].GetConstructor([Reflection.BindingFlags] "NonPublic,Instance", $null, $types, $null)
        return $constructor.Invoke(@($credentials, $name, [Amazon.PowerShell.Common.CredentialsSource] $source))
    }

    [Void] RegisterSAMLEndpoint($name, $endpointUri, $authenticationType)
    {
        $endpoint = New-Object Amazon.Runtime.CredentialManagement.SAMLEndpoint($name, $endpointUri, $authenticationType)
        (New-Object Amazon.Runtime.CredentialManagement.SAMLEndpointManager).RegisterEndpoint($endpoint)
    }
}
