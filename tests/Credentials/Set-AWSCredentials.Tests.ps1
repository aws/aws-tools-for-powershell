. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Credentials") "CredentialsTestHelper.ps1")
$helper = New-Object CredentialsTestHelper

function AssertCredentialsEmpty()
{
    # check stores
    (Test-Path -Path $helper.NetSDKPath)| Should Be $false
    (Test-Path -Path $helper.DefaultSharedPath)| Should Be $false
    (Test-Path -Path $helper.CustomSharedPath)| Should Be $false

    # check PS variable
    $StoredAWSCredentials | Should BeNullOrEmpty
}

function AssertCredentialsSet($profileLocation, $storeAs, $options, $awsCredentialsTypeName)
{
    if ($storeAs -eq $null)
    {
        # check session credentials
        (Get-AWSCredentials).GetType().Name | Should Be $awsCredentialsTypeName
    }
    else
    {
        # check one of the credentials files
        $profile = $helper.GetCredentialProfile($profileLocation, $storeAs)
        $profile.Options | Should Be $options
    }
}

Describe -Tag "Smoke" "Set-AWSCredentials" {

    BeforeAll {
        $helper.BeforeAll()
    }

    AfterAll {
        $helper.AfterAll()
    }

    $parameterSetError = "Parameter set cannot be resolved using the specified named parameters."

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

    Context "Set-AWSCredentials" {

        BeforeEach {
            $helper.ClearAllCreds()
            AssertCredentialsEmpty
        }

        AfterEach {
            $helper.ClearAllCreds()
        }

        #
        # Test setting credentials from individual values to the PowerShell session, the .NET credentials file, and the shared credentials file
        #

        # basic
        It "should store basic credentials from from command line values to the PowerShell session" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key

            AssertCredentialsSet $null $null $basicOptions "BasicAWSCredentials"
        }

        It "should store basic credentials from from command line values to the .NET credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs some_profile

            AssertCredentialsSet $null "some_profile" $basicOptions $null
        }

        It "should store basic credentials from from command line values to the shared credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs some_profile -ProfileLocation $helper.CustomSharedPath

            AssertCredentialsSet $helper.CustomSharedPath "some_profile" $basicOptions $null
        }

        # session
        It "should store session credentials from command line values to the PowerShell session" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -SessionToken session_token

            AssertCredentialsSet $null $null $sessionOptions "SessionAWSCredentials"
        }

        It "should store session credentials from command line values to the .NET credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -SessionToken session_token -StoreAs some_profile

            AssertCredentialsSet $null "some_profile" $sessionOptions $null
        }

        It "should store session credentials from command line values to the shared credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -SessionToken session_token -StoreAs some_profile -ProfileLocation $helper.CustomSharedPath

            AssertCredentialsSet $helper.CustomSharedPath "some_profile" $sessionOptions $null
        }

        # assume role
        It "should store assume role credentials from command line values to the PowerShell session" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            Set-AWSCredentials -RoleArn role_arn -SourceProfile source_profile

            AssertCredentialsSet $null $null $assumeRoleOptions "AssumeRoleAWSCredentials"
        }

        It "should store assume role credentials from command line values to the .NET credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            Set-AWSCredentials -RoleArn role_arn -SourceProfile source_profile -StoreAs some_profile

            AssertCredentialsSet $null "some_profile" $assumeRoleOptions $null
        }

        It "should store assume role credentials from command line values to the shared credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            Set-AWSCredentials -RoleArn role_arn -SourceProfile source_profile -StoreAs some_profile -ProfileLocation $helper.CustomSharedPath

            AssertCredentialsSet $helper.CustomSharedPath "some_profile" $assumeRoleOptions $null
        }

        # assume role with MFA
        It "should store assume role with mfa credentials from command line values to the PowerShell session" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            Set-AWSCredentials -RoleArn role_arn -SourceProfile source_profile -MfaSerial mfa_serial

            AssertCredentialsSet $null $null $assumeRoleWithMfaOptions "AssumeRoleAWSCredentials"
        }

        It "should store assume role with mfa credentials from command line values to the .NET credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            Set-AWSCredentials -RoleArn role_arn -SourceProfile source_profile -MfaSerial mfa_serial -StoreAs some_profile

            AssertCredentialsSet $null "some_profile" $assumeRoleWithMfaOptions $null
        }

        It "should store assume role with mfa credentials from command line values to the shared credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            Set-AWSCredentials -RoleArn role_arn -SourceProfile source_profile -MfaSerial mfa_serial -StoreAs some_profile -ProfileLocation $helper.CustomSharedPath

            AssertCredentialsSet $helper.CustomSharedPath "some_profile" $assumeRoleWithMfaOptions $null
        }

        # assume role with ExternalId
        It "should store assume role with external ID credentials from command line values to the PowerShell session" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            Set-AWSCredentials -RoleArn role_arn -SourceProfile source_profile -ExternalId external_id

            AssertCredentialsSet $null $null $assumeRoleWithExternalIdOptions "AssumeRoleAWSCredentials"
        }

        It "should store assume role with external ID credentials from command line values to the .NET credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            Set-AWSCredentials -RoleArn role_arn -SourceProfile source_profile -ExternalId external_id -StoreAs some_profile

            AssertCredentialsSet $null "some_profile" $assumeRoleWithExternalIdOptions $null
        }

        It "should store assume role with external ID credentials from command line values to the shared credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            Set-AWSCredentials -RoleArn role_arn -SourceProfile source_profile -ExternalId external_id -StoreAs some_profile -ProfileLocation $helper.CustomSharedPath

            AssertCredentialsSet $helper.CustomSharedPath "some_profile" $assumeRoleWithExternalIdOptions $null
        }

        # assume role with MFA and ExternalId
        It "should store assume role with MFA and external ID credentials from command line values to the PowerShell session" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            Set-AWSCredentials -RoleArn role_arn -SourceProfile source_profile -MfaSerial mfa_serial -ExternalId external_id

            AssertCredentialsSet $null $null $assumeRoleWithMfaAndExternalIdOptions "AssumeRoleAWSCredentials"
        }

        It "should store assume role with MFA and external ID credentials from command line values to the .NET credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            Set-AWSCredentials -RoleArn role_arn -SourceProfile source_profile -MfaSerial mfa_serial -ExternalId external_id -StoreAs some_profile

            AssertCredentialsSet $null "some_profile" $assumeRoleWithMfaAndExternalIdOptions $null
        }

        It "should store assume role with MFA and external ID credentials from command line values to the shared credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            Set-AWSCredentials -RoleArn role_arn -SourceProfile source_profile -MfaSerial mfa_serial -ExternalId external_id -StoreAs some_profile -ProfileLocation $helper.CustomSharedPath

            AssertCredentialsSet $helper.CustomSharedPath "some_profile" $assumeRoleWithMfaAndExternalIdOptions $null
        }

        # federated
        It "should store federated credentials from command line values to the PowerShell session" {
            $helper.RegisterSamlEndpoint("endpoint_name", "https://some_saml_endpoint.com", "Kerberos")
            Set-AWSCredentials -RoleArn role_arn -EndpointName endpoint_name

            AssertCredentialsSet $null $null $federatedOptions "FederatedAWSCredentials"
        }

        It "should store federated credentials from command line values to the .NET credentials file" {
            $helper.RegisterSamlEndpoint("endpoint_name", "https://some_saml_endpoint.com", "Kerberos")
            Set-AWSCredentials -RoleArn role_arn -EndpointName endpoint_name -StoreAs some_profile

            AssertCredentialsSet $null "some_profile" $federatedOptions $null
        }

        It "should store federated credentials from command line values to the shared credentials file" {
            $helper.RegisterSamlEndpoint("endpoint_name", "https://some_saml_endpoint.com", "Kerberos")
            { Set-AWSCredentials -RoleArn role_arn -EndpointName endpoint_name -StoreAs some_profile -ProfileLocation $helper.CustomSharedPath } | Should Throw "SharedCredentialsFile does not support the SAMLRole profile type"
        }

        # federated with user identity
        It "should store federated credentials from command line values to the PowerShell session" {
            $helper.RegisterSamlEndpoint("endpoint_name", "https://some_saml_endpoint.com", "Kerberos")
            Set-AWSCredentials -RoleArn role_arn -EndpointName endpoint_name -UserIdentity user_identity

            AssertCredentialsSet $null $null $federatedWithUserIdentityOptions "FederatedAWSCredentials"
        }

        It "should store federated credentials from command line values to the .NET credentials file" {
            $helper.RegisterSamlEndpoint("endpoint_name", "https://some_saml_endpoint.com", "Kerberos")
            Set-AWSCredentials -RoleArn role_arn -EndpointName endpoint_name -UserIdentity user_identity -StoreAs some_profile

            AssertCredentialsSet $null "some_profile" $federatedWithUserIdentityOptions $null
        }

        It "should store federated credentials from command line values to the shared credentials file" {
            $helper.RegisterSamlEndpoint("endpoint_name", "https://some_saml_endpoint.com", "Kerberos")
            { Set-AWSCredentials -RoleArn role_arn -EndpointName endpoint_name -UserIdentity user_identity -StoreAs some_profile -ProfileLocation $helper.CustomSharedPath } | Should Throw "SharedCredentialsFile does not support the SAMLRoleUserIdentity profile type"
        }

        # federated with network credential
        It "should store federated credentials with network credentials from command line values to the PowerShell session" {
            $helper.RegisterSamlEndpoint("endpoint_name", "https://some_saml_endpoint.com", "Kerberos")
            Set-AWSCredentials -RoleArn role_arn -EndpointName endpoint_name -NetworkCredential $psCreds

            AssertCredentialsSet $null $null $federatedOptions "FederatedAWSCredentials"
            (Get-AWSCredentials).Options.CustomCallbackState.CmdletNetworkCredentialParameter | Should Be $psCreds
        }

        It "should store federated credentials with network credentials from command line values to the .NET credentials file" {
            $helper.RegisterSamlEndpoint("endpoint_name", "https://some_saml_endpoint.com", "Kerberos")
            Set-AWSCredentials -RoleArn role_arn -EndpointName endpoint_name -StoreAs some_profile -NetworkCredential $psCreds

            AssertCredentialsSet $null "some_profile" $federatedOptions $null
            # the -NetworkCredential parameter is not used when -StoreAs is specified
            (Get-AWSCredentials) | Should Be $null
       }

        It "should store federated credentials with network credentials from command line values to the shared credentials file" {
            $helper.RegisterSamlEndpoint("endpoint_name", "https://some_saml_endpoint.com", "Kerberos")
            { Set-AWSCredentials -RoleArn role_arn -EndpointName endpoint_name -StoreAs some_profile -ProfileLocation $helper.CustomSharedPath -NetworkCredential $psCreds } | Should Throw "SharedCredentialsFile does not support the SAMLRole profile type"
        }

        #
        # Test setting credentials from the -Credential parameter to the PowerShell session, the .NET credentials file, and the shared credentials file
        #

        # AWSCredentials - Basic
        It "should store BasicAWSCredentials from the -Credential parameter to the PowerShell session" {
            $creds = $helper.GetAWSCredentials($basicOptions, $null)

            Set-AWSCredentials -Credential $creds

            AssertCredentialsSet $null $null $basicOptions "BasicAWSCredentials"
        }

        It "should store BasicAWSCredentials from the -Credential parameter to the .NET credentials file" {
            $creds = $helper.GetAWSCredentials($basicOptions, $null)

            Set-AWSCredentials -Credential $creds -StoreAs some_profile

            AssertCredentialsSet $null some_profile $basicOptions $null
        }

        It "should store BasicAWSCredentials from the -Credential parameter to the shared credentials file" {
            $creds = $helper.GetAWSCredentials($basicOptions, $null)

            Set-AWSCredentials -Credential $creds -StoreAs some_profile -ProfileLocation $helper.CustomSharedPath

            AssertCredentialsSet $helper.CustomSharedPath some_profile $basicOptions $null
        }

        # AWSCredentials - Basic
        It "should store SessionAWSCredentials from the -Credential parameter to the PowerShell session" {
            $creds = $helper.GetAWSCredentials($sessionOptions, $null)

            Set-AWSCredentials -Credential $creds

            AssertCredentialsSet $null $null $sessionOptions "SessionAWSCredentials"
        }

        It "should store SessionAWSCredentials from the -Credential parameter to the .NET credentials file" {
            $creds = $helper.GetAWSCredentials($sessionOptions, $null)

            Set-AWSCredentials -Credential $creds -StoreAs some_profile

            AssertCredentialsSet $null some_profile $sessionOptions $null
        }

        It "should store SessionAWSCredentials from the -Credential parameter to the shared credentials file" {
            $creds = $helper.GetAWSCredentials($sessionOptions, $null)

            Set-AWSCredentials -Credential $creds -StoreAs some_profile -ProfileLocation $helper.CustomSharedPath

            AssertCredentialsSet $helper.CustomSharedPath some_profile $sessionOptions $null
        }

        # AWSCredentials - AssumeRole
        It "should store AssumeRoleAWSCredentials from the -Credential parameter to the PowerShell session" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile
            $creds = $helper.GetAWSCredentials($assumeRoleOptions, $null)

            Set-AWSCredentials -Credential $creds

            AssertCredentialsSet $null $null $assumeRoleOptions "AssumeRoleAWSCredentials"
        }

        It "should not store AssumeRoleAWSCredentials from the -Credential parameter to the .NET credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile -ProfileLocation $helper.DefaultSharedPath
            $creds = $helper.GetAWSCredentials($assumeRoleOptions, $helper.DefaultSharedPath)

            { Set-AWSCredentials -Credential $creds -StoreAs some_profile } | Should Throw "Cannot save credentials of type AssumeRoleAWSCredentials"
        }

        It "should not store AssumeRoleAWSCredentials from the -Credential parameter to the shared credentials file" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile -ProfileLocation $helper.CustomSharedPath
            $creds = $helper.GetAWSCredentials($assumeRoleOptions, $helper.CustomSharedPath)

            { Set-AWSCredentials -Credential $creds -StoreAs some_profile -ProfileLocation $helper.CustomSharedPath } | Should Throw "Cannot save credentials of type AssumeRoleAWSCredentials"
        }

        #
        # Test setting credentials from the -ProfileName parameter to the PowerShell session, the .NET credentials file, and the shared credentials file
        #

        # BasicAWSCredentials
        It "should store BasicAWSCredentials from the .NET credentials file to the PowerShell session" {
            $helper.RegisterProfile("profile_name", $null, $basicOptions)
            Set-AWSCredentials -ProfileName "profile_name"

            AssertCredentialsSet $null $null $basicOptions "BasicAWSCredentials"
        }

        It "should store BasicAWSCredentials from the default shared credentials file to the PowerShell session" {
            $helper.RegisterProfile("profile_name", $helper.DefaultSharedPath, $basicOptions)
            Set-AWSCredentials -ProfileName "profile_name"

            AssertCredentialsSet $null $null $basicOptions "BasicAWSCredentials"
        }

        It "should store BasicAWSCredentials from a custom shared credentials file to the PowerShell session" {
            $helper.RegisterProfile("profile_name", $helper.CustomSharedPath, $basicOptions)
            Set-AWSCredentials -ProfileName "profile_name" -ProfileLocation $helper.CustomSharedPath

            AssertCredentialsSet $null $null $basicOptions "BasicAWSCredentials"
        }

        It "should store BasicAWSCredentials from the .NET credentials file to the .NET credentials file" {
            $helper.RegisterProfile("profile_name", $null, $basicOptions)
            Set-AWSCredentials -ProfileName "profile_name" -StoreAs "copied_profile"

            AssertCredentialsSet $null "copied_profile" $basicOptions $null
        }

        It "should store BasicAWSCredentials from the shared credentials file to the shared credentials file" {
            $helper.RegisterProfile("profile_name", $helper.CustomSharedPath, $basicOptions)
            Set-AWSCredentials -ProfileName "profile_name" -StoreAs "copied_profile" -ProfileLocation $helper.CustomSharedPath

            AssertCredentialsSet $helper.CustomSharedPath "copied_profile" $basicOptions $null
        }

        # SessionAWSCredentials
        It "should store SessionAWSCredentials from the .NET credentials file to the PowerShell session" {
            $helper.RegisterProfile("profile_name", $null, $sessionOptions)
            Set-AWSCredentials -ProfileName "profile_name"

            AssertCredentialsSet $null $null $sessionOptions "SessionAWSCredentials"
        }

        It "should store SessionAWSCredentials from the default shared credentials file to the PowerShell session" {
            $helper.RegisterProfile("profile_name", $helper.DefaultSharedPath, $sessionOptions)
            Set-AWSCredentials -ProfileName "profile_name"

            AssertCredentialsSet $null $null $sessionOptions "SessionAWSCredentials"
        }

        It "should store SessionAWSCredentials from a custom shared credentials file to the PowerShell session" {
            $helper.RegisterProfile("profile_name", $helper.CustomSharedPath, $sessionOptions)
            Set-AWSCredentials -ProfileName "profile_name" -ProfileLocation $helper.CustomSharedPath

            AssertCredentialsSet $null $null $sessionOptions "SessionAWSCredentials"
        }

        It "should store SessionAWSCredentials from the .NET credentials file to the .NET credentials file" {
            $helper.RegisterProfile("profile_name", $null, $sessionOptions)
            Set-AWSCredentials -ProfileName "profile_name" -StoreAs "copied_profile"

            AssertCredentialsSet $null "copied_profile" $sessionOptions $null
        }

        It "should store SessionAWSCredentials from the shared credentials file to the shared credentials file" {
            $helper.RegisterProfile("profile_name", $helper.CustomSharedPath, $sessionOptions)
            Set-AWSCredentials -ProfileName "profile_name" -StoreAs "copied_profile" -ProfileLocation $helper.CustomSharedPath

            AssertCredentialsSet $helper.CustomSharedPath "copied_profile" $sessionOptions $null
        }

        # AssumeRoleAWSCredentials
        It "should store AssumeRoleAWSCredentials from the .NET credentials file to the PowerShell session" {
            $helper.RegisterProfile("source_profile", $null, $basicOptions)
            $helper.RegisterProfile("profile_name", $null, $assumeRoleOptions)
            Set-AWSCredentials -ProfileName "profile_name"

            AssertCredentialsSet $null $null $assumeRoleOptions "AssumeRoleAWSCredentials"
        }

        It "should store AssumeRoleAWSCredentials from the default shared credentials file to the PowerShell session" {
            $helper.RegisterProfile("source_profile", $helper.DefaultSharedPath, $basicOptions)
            $helper.RegisterProfile("profile_name", $helper.DefaultSharedPath, $assumeRoleOptions)
            Set-AWSCredentials -ProfileName "profile_name"

            AssertCredentialsSet $null $null $assumeRoleOptions "AssumeRoleAWSCredentials"
        }

        It "should store AssumeRoleAWSCredentials from a custom shared credentials file to the PowerShell session" {
            $helper.RegisterProfile("source_profile", $helper.CustomSharedPath, $basicOptions)
            $helper.RegisterProfile("profile_name", $helper.CustomSharedPath, $assumeRoleOptions)
            Set-AWSCredentials -ProfileName "profile_name" -ProfileLocation $helper.CustomSharedPath

            AssertCredentialsSet $null $null $assumeRoleOptions "AssumeRoleAWSCredentials"
        }

        It "should store AssumeRoleAWSCredentials from the .NET credentials file to the .NET credentials file" {
            $helper.RegisterProfile("source_profile", $null, $basicOptions)
            $helper.RegisterProfile("profile_name", $null, $assumeRoleOptions)
            Set-AWSCredentials -ProfileName "profile_name" -StoreAs "copied_profile"

            AssertCredentialsSet $null "copied_profile" $assumeRoleOptions $null
        }

        It "should store AssumeRoleAWSCredentials from the shared credentials file to the shared credentials file" {
            $helper.RegisterProfile("source_profile", $helper.CustomSharedPath, $basicOptions)
            $helper.RegisterProfile("profile_name", $helper.CustomSharedPath, $assumeRoleOptions)
            Set-AWSCredentials -ProfileName "profile_name" -StoreAs "copied_profile" -ProfileLocation $helper.CustomSharedPath

            AssertCredentialsSet $helper.CustomSharedPath "copied_profile" $assumeRoleOptions $null
        }

        # FederatedAWSCredentials (Federated profiles aren't supported in the shared credentials file)
        It "should store FederatedAWSCredentials from the .NET credentials file to the PowerShell session" {
            $helper.RegisterSamlEndpoint("endpoint_name", "https://some_saml_endpoint.com", "Kerberos")
            $helper.RegisterProfile("profile_name", $null, $federatedOptions)
            Set-AWSCredentials -ProfileName "profile_name"

            AssertCredentialsSet $null $null $federatedOptions "FederatedAWSCredentials"
        }

        It "should store FederatedAWSCredentials from the .NET credentials file to the .NET credentials file" {
            $helper.RegisterSamlEndpoint("endpoint_name", "https://some_saml_endpoint.com", "Kerberos")
            $helper.RegisterProfile("profile_name", $null, $federatedOptions)
            Set-AWSCredentials -ProfileName "profile_name" -StoreAs "copied_profile"

            AssertCredentialsSet $null "copied_profile" $federatedOptions "FederatedAWSCredentials"
        }

        #
        # Spot check to see that the parameter sets are working correctly
        #
        It "should fail if parameter sets are mixed up" {
            $creds = (New-Object Amazon.Runtime.BasicAWSCredentials("access_key", "secret_key"))

            { Set-AWSCredentials -AccessKey access_key -SourceProfile source_profile } | Should Throw $parameterSetError
            { Set-AWSCredentials -AccessKey access_key -Credential $creds } | Should Throw $parameterSetError
            { Set-AWSCredentials -AccessKey access_key -UserIdentity user_identity } | Should Throw $parameterSetError
            { Set-AWSCredentials -AccessKey access_key -ProfileName profile_name } | Should Throw $parameterSetError

            { Set-AWSCredentials -SourceProfile source_profile -Credential $creds } | Should Throw $parameterSetError
            { Set-AWSCredentials -SourceProfile source_profile -UserIdentity user_identity } | Should Throw $parameterSetError
            { Set-AWSCredentials -SourceProfile source_profile -ProfileName profile_name } | Should Throw $parameterSetError

            { Set-AWSCredentials -Credential $creds -UserIdentity user_identity } | Should Throw $parameterSetError
            { Set-AWSCredentials -Credential $creds -ProfileName profile_name } | Should Throw $parameterSetError

            { Set-AWSCredentials -UserIdentity user_identity -ProfileName profile_name } | Should Throw $parameterSetError
        }
    }
}
