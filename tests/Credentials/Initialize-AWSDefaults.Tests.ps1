BeforeAll {
    . (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
    . (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
    . (Join-Path (Join-Path (Get-Location) "Credentials") "CredentialsTestHelper.ps1")
    $helper = New-Object CredentialsTestHelper
    $testRegion = "us-west-1"
    $helper.BeforeAll()

    $parameterSetError = "Parameter set cannot be resolved using the specified named parameters.*"

    $secpasswd = ConvertTo-SecureString "password" -AsPlainText -Force
    $psCreds = New-Object System.Management.Automation.PSCredential ("username", $secpasswd)

    $basicOptions = $helper.NewOptions()
    $basicOptions.AccessKey = "access_key"
    $basicOptions.SecretKey = "secret_key"

    $sessionOptions = $helper.NewOptions()
    $sessionOptions.AccessKey = "access_key"
    $sessionOptions.SecretKey = "secret_key"
    $sessionOptions.Token = "session_token"

    $assumeRoleOptions = $helper.NewOptions()
    $assumeRoleOptions.RoleArn = "role_arn"
    $assumeRoleOptions.SourceProfile = "source_profile"

    $assumeRoleWithMfaOptions = $helper.NewOptions()
    $assumeRoleWithMfaOptions.RoleArn = "role_arn"
    $assumeRoleWithMfaOptions.SourceProfile = "source_profile"
    $assumeRoleWithMfaOptions.MfaSerial = "mfa_serial"

    $assumeRoleWithExternalIdOptions = $helper.NewOptions()
    $assumeRoleWithExternalIdOptions.RoleArn = "role_arn"
    $assumeRoleWithExternalIdOptions.SourceProfile = "source_profile"
    $assumeRoleWithExternalIdOptions.ExternalId = "external_id"

    $assumeRoleWithMfaAndExternalIdOptions = $helper.NewOptions()
    $assumeRoleWithMfaAndExternalIdOptions.RoleArn = "role_arn"
    $assumeRoleWithMfaAndExternalIdOptions.SourceProfile = "source_profile"
    $assumeRoleWithMfaAndExternalIdOptions.ExternalId = "external_id"
    $assumeRoleWithMfaAndExternalIdOptions.MfaSerial = "mfa_serial"

    $federatedOptions = $helper.NewOptions()
    $federatedOptions.RoleArn = "role_arn"
    $federatedOptions.EndpointName = "endpoint_name"

    $federatedWithUserIdentityOptions = $helper.NewOptions()
    $federatedWithUserIdentityOptions.RoleArn = "role_arn"
    $federatedWithUserIdentityOptions.EndpointName = "endpoint_name"
    $federatedWithUserIdentityOptions.UserIdentity = "user_identity"

    function AssertDefaultsEmpty()
    {
        # check stores
        (Test-Path -Path $helper.NetSDKPath)| Should -Be $false
        (Test-Path -Path $helper.DefaultSharedPath)| Should -Be $false
        (Test-Path -Path $helper.CustomSharedPath)| Should -Be $false

        # check PS variables
        Get-AWSCredentials | Should -BeNullOrEmpty
        Get-DefaultAWSRegion | Should -Be $region
    }

    function AssertDefaultsSet($profileLocation, $options, $awsCredentialsTypeName)
    {
        if ($options -eq $null)
        {
            $options = $helper.NewOptions()
        }

        # check one of the credentials files
        $profile = $helper.GetCredentialProfile($profileLocation, "default")
        $profile | Should -Not -BeNullOrEmpty
        $profile.Options | Should -Be $options
        if ($profile.Region -ne $null)
        {
            $profile.Region.SystemName | Should -Be $testRegion
        }

        # check session credentials
        (Get-AWSCredentials).GetType().Name | Should -Be $awsCredentialsTypeName

        (Get-DefaultAWSRegion).Region | Should -Be $testRegion
    }

}

AfterAll {
    $helper.AfterAll()
}


Describe -Tag "Smoke" "Initialize-AWSDefaults" {

    Context "Initialize-AWSDefaults" {

        BeforeEach {
            $helper.ClearAllCreds()
            Clear-Variable "StoredAWSRegion" -Scope Global
            AssertDefaultsEmpty
        }

        AfterEach {
            $helper.ClearAllCreds()
        }
        
        #basic
        It "should store basic credentials from from command line values to the PowerShell session and the .NET credentials file" {
            Initialize-AWSDefaults -AccessKey access_key -SecretKey secret_key -Region $testRegion
            AssertDefaultsSet $null $basicOptions BasicAWSCredentials
        }

        It "should store basic credentials from from command line values to the PowerShell session and the shared credentials file" {
            Initialize-AWSDefaults -AccessKey access_key -SecretKey secret_key -Region $testRegion -ProfileLocation $helper.CustomSharedPath
            AssertDefaultsSet $helper.CustomSharedPath $basicOptions BasicAWSCredentials
        }

        # session
        It "should store basic credentials from from command line values to the PowerShell session and the .NET credentials file" {
            Initialize-AWSDefaults -AccessKey access_key -SecretKey secret_key -SessionToken session_token -Region $testRegion

            AssertDefaultsSet $null $sessionOptions SessionAWSCredentials
        }

        It "should store basic credentials from from command line values to the PowerShell session and the shared credentials file" {
            Initialize-AWSDefaults -AccessKey access_key -SecretKey secret_key -SessionToken session_token -Region $testRegion -ProfileLocation $helper.CustomSharedPath

            AssertDefaultsSet $helper.CustomSharedPath $sessionOptions SessionAWSCredentials
        }


        # assume role
        It "should store assume role credentials from from command line values to the PowerShell session and the .NET credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            Initialize-AWSDefaults -RoleArn role_arn -SourceProfile source_profile -Region $testRegion

            AssertDefaultsSet $null $assumeRoleOptions AssumeRoleAWSCredentials
        }

        It "should store assume role credentials from from command line values to the PowerShell session and the shared credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            Initialize-AWSDefaults -RoleArn role_arn -SourceProfile source_profile -Region $testRegion -ProfileLocation $helper.CustomSharedPath

            AssertDefaultsSet $helper.CustomSharedPath $assumeRoleOptions AssumeRoleAWSCredentials
        }

        # assume role with MFA
        It "should store assume role with mfa credentials from from command line values to the PowerShell session and the .NET credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            Initialize-AWSDefaults -RoleArn role_arn -SourceProfile source_profile -MfaSerial mfa_serial -Region $testRegion

            AssertDefaultsSet $null $assumeRoleWithMfaOptions AssumeRoleAWSCredentials
        }

        It "should store assume role with mfa credentials from from command line values to the PowerShell session and the shared credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            Initialize-AWSDefaults -RoleArn role_arn -SourceProfile source_profile -MfaSerial mfa_serial -Region $testRegion -ProfileLocation $helper.CustomSharedPath

            AssertDefaultsSet $helper.CustomSharedPath $assumeRoleWithMfaOptions AssumeRoleAWSCredentials
        }

        # assume role with ExternalId
        It "should store assume role with external id credentials from from command line values to the PowerShell session and the .NET credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            Initialize-AWSDefaults -RoleArn role_arn -SourceProfile source_profile -ExternalId external_id -Region $testRegion

            AssertDefaultsSet $null $assumeRoleWithExternalIdOptions AssumeRoleAWSCredentials
        }

        It "should store assume role with external id credentials from from command line values to the PowerShell session and the shared credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            Initialize-AWSDefaults -RoleArn role_arn -SourceProfile source_profile  -ExternalId external_id -Region $testRegion -ProfileLocation $helper.CustomSharedPath

            AssertDefaultsSet $helper.CustomSharedPath $assumeRoleWithExternalIdOptions AssumeRoleAWSCredentials
        }
        
        # assume role with MFA and ExternalId
        It "should store assume role with mfa and external id credentials from from command line values to the PowerShell session and the .NET credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            Initialize-AWSDefaults -RoleArn role_arn -SourceProfile source_profile -MfaSerial mfa_serial -ExternalId external_id -Region $testRegion

            AssertDefaultsSet $null $assumeRoleWithMfaAndExternalIdOptions AssumeRoleAWSCredentials
        }

        It "should store assume role with mfa and external id credentials from from command line values to the PowerShell session and the shared credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            Initialize-AWSDefaults -RoleArn role_arn -SourceProfile source_profile -MfaSerial mfa_serial -ExternalId external_id -Region $testRegion -ProfileLocation $helper.CustomSharedPath

            AssertDefaultsSet $helper.CustomSharedPath $assumeRoleWithMfaAndExternalIdOptions AssumeRoleAWSCredentials
        }
        
        <#
        # federated
        It "should store federated credentials from command line values  to the PowerShell session and the .NET credentials file" {
            $helper.RegisterSamlEndpoint("endpoint_name", "https://some_saml_endpoint.com", "Kerberos")
            Initialize-AWSDefaults -RoleArn role_arn -EndpointName endpoint_name -Region $testRegion

            AssertDefaultsSet $null $federatedOptions FederatedAWSCredentials
        }
        
        It "should not store federated credentials from command line values to the PowerShell session and the shared credentials file" {
            $helper.RegisterSamlEndpoint("endpoint_name", "https://some_saml_endpoint.com", "Kerberos")
            { Initialize-AWSDefaults -RoleArn role_arn -EndpointName endpoint_name -UserIdentity user_identity -Region $testRegion -ProfileLocation $helper.CustomSharedPath } | Should -Throw "SharedCredentialsFile does not support the SAMLRoleUserIdentity profile type"
        }
                
        # federated with user identity
        It "should store federated with user identity credentials from command line values to the PowerShell session and the .NET credentials file" {
            $helper.RegisterSamlEndpoint("endpoint_name", "https://some_saml_endpoint.com", "Kerberos")
            Initialize-AWSDefaults -RoleArn role_arn -EndpointName endpoint_name -UserIdentity user_identity -Region $testRegion

            AssertDefaultsSet $null $federatedWithUserIdentityOptions FederatedAWSCredentials
        }

        It "should not store federated with user identity credentials from command line values to the PowerShell session and the shared credentials file" {
            $helper.RegisterSamlEndpoint("endpoint_name", "https://some_saml_endpoint.com", "Kerberos")
            { Initialize-AWSDefaults -RoleArn role_arn -EndpointName endpoint_name -UserIdentity user_identity -Region $testRegion -ProfileLocation $helper.CustomSharedPath } | Should -Throw "SharedCredentialsFile does not support the SAMLRoleUserIdentity profile type"
        }
             
        
        # federated with network credential
        It "should store federated credentials with network credentials from command line values to the PowerShell session and the .NET credentials file" {
            $helper.RegisterSamlEndpoint("endpoint_name", "https://some_saml_endpoint.com", "Kerberos")
            Initialize-AWSDefaults -RoleArn role_arn -EndpointName endpoint_name -NetworkCredential $psCreds -Region $testRegion

            AssertDefaultsSet $null $federatedOptions FederatedAWSCredentials
            (Get-AWSCredentials).Options.CustomCallbackState.CmdletNetworkCredentialParameter | Should -Be $psCreds
        }

        It "should not store federated credentials with network credentials from command line values to the shared credentials file" {
            $helper.RegisterSamlEndpoint("endpoint_name", "https://some_saml_endpoint.com", "Kerberos")
            { Initialize-AWSDefaults -RoleArn role_arn -EndpointName endpoint_name -Region $testRegion -ProfileLocation $helper.CustomSharedPath -NetworkCredential $psCreds } | Should -Throw "SharedCredentialsFile does not support the SAMLRole profile type"
        }
        #>

        #
        # Test setting credentials from the -Credential parameter to the PowerShell session, the .NET credentials file, and the shared credentials file
        #

        # AWSCredentials - Basic
        It "should store BasicAWSCredentials from the -Credential parameter to the PowerShell session and the .NET credentials file" {
            $creds = $helper.GetAWSCredentials($basicOptions, $null)

            Initialize-AWSDefaults -Credential $creds -Region $testRegion

            AssertDefaultsSet $null $basicOptions BasicAWSCredentials
        }
        
        It "should store BasicAWSCredentials from the -Credential parameter to the PowerShell session and the shared credentials file" {
            $creds = $helper.GetAWSCredentials($basicOptions, $null)

            Initialize-AWSDefaults -Credential $creds -Region $testRegion -ProfileLocation $helper.CustomSharedPath

            AssertDefaultsSet $helper.CustomSharedPath $basicOptions BasicAWSCredentials
        }
        
        # AWSCredentials - Session
        It "should store SessionAWSCredentials from the -Credential parameter to the PowerShell session and the .NET credentials file" {
            $creds = $helper.GetAWSCredentials($sessionOptions, $null)

            Initialize-AWSDefaults -Credential $creds -Region $testRegion

            AssertDefaultsSet $null $sessionOptions SessionAWSCredentials
        }

        It "should store SessionAWSCredentials from the -Credential parameter to the PowerShell session and the shared credentials file" {
            $creds = $helper.GetAWSCredentials($sessionOptions, $null)

            Initialize-AWSDefaults -Credential $creds -Region $testRegion -ProfileLocation $helper.CustomSharedPath

            AssertDefaultsSet $helper.CustomSharedPath $sessionOptions SessionAWSCredentials
        }


        # AWSCredentials - AssumeRole
        It "should not store AssumeRoleAWSCredentials from the -Credential parameter to the PowerShell session and the .NET credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile
            $creds = $helper.GetAWSCredentials($assumeRoleOptions, $null)

            { Initialize-AWSDefaults -Credential $creds -Region $testRegion } | Should -Throw "Cannot save credentials of type AssumeRoleAWSCredentials"
        }

        It "should not store AssumeRoleAWSCredentials from the -Credential parameter to the PowerShell session and the shared credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile -ProfileLocation $helper.DefaultSharedPath
            $creds = $helper.GetAWSCredentials($assumeRoleOptions, $helper.DefaultSharedPath)

            { Initialize-AWSDefaults -Credential $creds -Region $testRegion -ProfileLocation $helper.CustomSharedPath } | Should -Throw "Cannot save credentials of type AssumeRoleAWSCredentials"
        }
        
        #
        # Test setting credentials from the -ProfileName parameter to the PowerShell session, the .NET credentials file, and the shared credentials file
        #

        # BasicAWSCredentials
        It "should store BasicAWSCredentials from the .NET credentials file to the PowerShell session and the .NET credentials file" {
            $helper.RegisterProfile("profile_name", $null, $basicOptions)
            Initialize-AWSDefaults -ProfileName "profile_name" -Region $testRegion

            AssertDefaultsSet $null $basicOptions BasicAWSCredentials
        }

        It "should store BasicAWSCredentials from the default shared credentials file to the PowerShell session and the default shared credentials file" {
            $helper.RegisterProfile("profile_name", $helper.DefaultSharedPath, $basicOptions)
            Initialize-AWSDefaults -ProfileName "profile_name" -Region $testRegion

            AssertDefaultsSet $helper.DefaultSharedPath $basicOptions "BasicAWSCredentials"
        }

        It "should store BasicAWSCredentials from a custom shared credentials file to the PowerShell session and a custom shared credentials file" {
            $helper.RegisterProfile("profile_name", $helper.CustomSharedPath, $basicOptions)
            Initialize-AWSDefaults -ProfileName "profile_name" -Region $testRegion -ProfileLocation $helper.CustomSharedPath

            AssertDefaultsSet $helper.CustomSharedPath $basicOptions BasicAWSCredentials
        }
        
        # SessionAWSCredentials
        It "should store SessionAWSCredentials from the .NET credentials file to the PowerShell session and the .NET credentials file" {
            $helper.RegisterProfile("profile_name", $null, $sessionOptions)
            Initialize-AWSDefaults -ProfileName "profile_name" -Region $testRegion

            AssertDefaultsSet $null $sessionOptions SessionAWSCredentials
        }

        It "should store SessionAWSCredentials from the default shared credentials file to the PowerShell session and the default shared credentials file" {
            $helper.RegisterProfile("profile_name", $helper.DefaultSharedPath, $sessionOptions)
            Initialize-AWSDefaults -ProfileName "profile_name" -Region $testRegion

            AssertDefaultsSet $helper.DefaultSharedPath $sessionOptions SessionAWSCredentials
        }

        It "should store SessionAWSCredentials from a custom shared credentials file to the PowerShell session and a custom shared credentials file" {
            $helper.RegisterProfile("profile_name", $helper.CustomSharedPath, $sessionOptions)
            Initialize-AWSDefaults -ProfileName "profile_name" -Region $testRegion -ProfileLocation $helper.CustomSharedPath

            AssertDefaultsSet $helper.CustomSharedPath $sessionOptions SessionAWSCredentials
        }

        
        # AssumeRoleAWSCredentials
        It "should store AssumeRoleAWSCredentials from the .NET credentials file to the PowerShell session and the .NET credentials file" {
            $helper.RegisterProfile("source_profile", $null, $basicOptions)
            $helper.RegisterProfile("profile_name", $null, $assumeRoleOptions)
            Initialize-AWSDefaults -ProfileName "profile_name" -Region $testRegion

            AssertDefaultsSet $null $assumeRoleOptions AssumeRoleAWSCredentials
        }

        It "should store AssumeRoleAWSCredentials from the default shared credentials file to the PowerShell session and the default shared credentials file" {
            $helper.RegisterProfile("source_profile", $helper.DefaultSharedPath, $basicOptions)
            $helper.RegisterProfile("profile_name", $helper.DefaultSharedPath, $assumeRoleOptions)
            Initialize-AWSDefaults -ProfileName "profile_name" -Region $testRegion

            AssertDefaultsSet $helper.DefaultSharedPath $assumeRoleOptions AssumeRoleAWSCredentials
        }

        It "should store AssumeRoleAWSCredentials from a custom shared credentials file to the PowerShell session and a custom shared credentials file" {
            $helper.RegisterProfile("source_profile", $helper.CustomSharedPath, $basicOptions)
            $helper.RegisterProfile("profile_name", $helper.CustomSharedPath, $assumeRoleOptions)
            Initialize-AWSDefaults -ProfileName "profile_name" -Region $testRegion -ProfileLocation $helper.CustomSharedPath

            AssertDefaultsSet $helper.CustomSharedPath $assumeRoleOptions AssumeRoleAWSCredentials
        }
        
        # FederatedAWSCredentials (Federated profiles aren't supported in the shared credentials file)
        It "should store FederatedAWSCredentials from the .NET credentials file to the PowerShell session and the .NET credentials file" {
            $helper.RegisterSamlEndpoint("endpoint_name", "https://some_saml_endpoint.com", "Kerberos")
            $helper.RegisterProfile("profile_name", $null, $federatedOptions)
            Initialize-AWSDefaults -ProfileName "profile_name" -Region $testRegion

            AssertDefaultsSet $null $federatedOptions FederatedAWSCredentials
        }

        # Make sure the region-only version works and doesn't change the default profile
        It "should store a new region without affecting the default profile" {
            $helper.RegisterProfile("default", $basicOptions.AccessKey, $basicOptions.SecretKey, "us-east-1", $null, $null)

            Initialize-AWSDefaults -Region $testRegion

            AssertDefaultsSet $null $basicOptions BasicAWSCredentials
        }
        
        #
        # make sure postional parameters work
        #
        It "should work with -ProfileName as a positional parameter" {
            $helper.RegisterProfile("profile_name", $basicOptions.AccessKey, $basicOptions.SecretKey, $testRegion, $null, $null)
            Initialize-AWSDefaults profile_name -Region $testRegion

            AssertDefaultsSet $null $basicOptions BasicAWSCredentials
        }

        It "should work with -ProfileName and -ProfileLocation as positional parameters" {
            $helper.RegisterProfile("profile_name", $basicOptions.AccessKey, $basicOptions.SecretKey, $testRegion, $helper.CustomSharedPath, $null)

            Initialize-AWSDefaults profile_name $helper.CustomSharedPath -Region $testRegion

            AssertDefaultsSet $helper.CustomSharedPath $basicOptions BasicAWSCredentials
        }

        It "should work with -ProfileName, -ProfileLocation, and -Region as positional parameters" {
            $helper.RegisterProfile("profile_name", $basicOptions.AccessKey, $basicOptions.SecretKey, $null, $helper.CustomSharedPath, $null)

            Initialize-AWSDefaults profile_name $helper.CustomSharedPath $testRegion

            AssertDefaultsSet $helper.CustomSharedPath $basicOptions BasicAWSCredentials
        }

        #
        # Spot check to see that the parameter sets are working correctly
        #
        It "should fail if parameter sets are mixed up" {
            $creds = (New-Object Amazon.Runtime.BasicAWSCredentials("access_key", "secret_key"))

            { Initialize-AWSDefaults -AccessKey access_key -SourceProfile source_profile } | Should -Throw $parameterSetError
            { Initialize-AWSDefaults -AccessKey access_key -Credential $creds } | Should -Throw $parameterSetError
            #{ Initialize-AWSDefaults -AccessKey access_key -UserIdentity user_identity } | Should -Throw $parameterSetError
            { Initialize-AWSDefaults -AccessKey access_key -ProfileName profile_name } | Should -Throw $parameterSetError

            { Initialize-AWSDefaults -SourceProfile source_profile -Credential $creds } | Should -Throw $parameterSetError
            #{ Initialize-AWSDefaults -SourceProfile source_profile -UserIdentity user_identity } | Should -Throw $parameterSetError
            { Initialize-AWSDefaults -SourceProfile source_profile -ProfileName profile_name } | Should -Throw $parameterSetError

            #{ Initialize-AWSDefaults -Credential $creds -UserIdentity user_identity } | Should -Throw $parameterSetError
            { Initialize-AWSDefaults -Credential $creds -ProfileName profile_name } | Should -Throw $parameterSetError

            #{ Initialize-AWSDefaults -UserIdentity user_identity -ProfileName profile_name } | Should -Throw $parameterSetError
        }#>
    }
}
