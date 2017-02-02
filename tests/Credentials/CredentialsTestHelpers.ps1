function MockSetingsStoreFolder($newSettingsStoreFolder) {
    
    $bindingFlags = [Reflection.BindingFlags] "NonPublic,Public,Static"
    $privateField = [Amazon.Runtime.Internal.Settings.PersistenceManager].GetField("SettingsStoreFolder", $bindingFlags);
    $originalSettingsStoreFolder = $privateField.GetValue($null);
    $privateField.SetValue($null, $newSettingsStoreFolder);
    return $originalSettingsStoreFolder
           
}

function UnMockSettingsStoreFolder($originalSettingsStoreFolder) {
    $bindingFlags = [Reflection.BindingFlags] "NonPublic,Public,Static"
    $privateField = [Amazon.Runtime.Internal.Settings.PersistenceManager].GetField("SettingsStoreFolder", $bindingFlags);
    $privateField.SetValue($null, $originalSettingsStoreFolder);
}

function MockCredentialsPath($newCredentialsPath) {
    
    $bindingFlags = [Reflection.BindingFlags] "NonPublic,Public,Static"
    $privateField = [Amazon.Runtime.CredentialManagement.SharedCredentialsFile].GetField("DefaultFilePath", $bindingFlags);
    $originalCredentialsPath = $privateField.GetValue($null);
    $privateField.SetValue($null, $newCredentialsPath);
    return $originalCredentialsPath
           
}

function UnMockCredentialsPath($originalCredentialsPath) {
    $bindingFlags = [Reflection.BindingFlags] "NonPublic,Public,Static"
    $privateField = [Amazon.Runtime.CredentialManagement.SharedCredentialsFile].GetField("DefaultFilePath", $bindingFlags);
    $privateField.SetValue($null, $originalCredentialsPath);
}

function RegisterProfile($profileName, $accessKey, $secretKey, $profilesLocation) {
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

function UnRegisterProfile($profileName, $profilesLocation) {
    if ($profilesLocation -eq $null)
    {
        (New-Object Amazon.Runtime.CredentialManagement.NetSdkCredentialsFile).UnRegisterProfile($profileName)
    }
    else
    {
        (New-Object Amazon.Runtime.CredentialManagement.SharedCredentialsFile ($profilesLocation)).UnRegisterProfile($profileName)
    }
}
