. (Join-Path (Join-Path (Get-Location) "Include") "TestIncludes.ps1")
. (Join-Path (Join-Path (Get-Location) "Include") "TestHelper.ps1")
. (Join-Path (Join-Path (Get-Location) "Credentials") "CredentialsTestHelper.ps1")
$helper = New-Object CredentialsTestHelper


Describe -Tag "Smoke" "New-AWSCredentials" {

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

    $federatedOptions = $helper.NewOptions()
    $federatedOptions.RoleArn = "role_arn"
    $federatedOptions.EndpointName = "endpoint_name"

    Context "New-AWSCredentials" {

        BeforeEach {
            $helper.ClearAllCreds()
        }

        AfterEach {
            $helper.ClearAllCreds()
        }

        It "should create basic credentials from from command line values" {
            $creds = New-AWSCredentials -AccessKey access_key -SecretKey secret_key

            $creds.GetType().Name | Should Be "BasicAWSCredentials"
            $creds.GetCredentials().AccessKey | Should Be "access_key"
            $creds.GetCredentials().SecretKey | Should Be "secret_key"
        }

        It "should create session credentials from command line values" {
            $creds = New-AWSCredentials -AccessKey access_key -SecretKey secret_key -SessionToken session_token


            $creds.GetType().Name | Should Be "SessionAWSCredentials"
            $creds.GetCredentials().AccessKey | Should Be "access_key"
            $creds.GetCredentials().SecretKey | Should Be "secret_key"
            $creds.GetCredentials().Token | Should Be "session_token"
        }

        It "should create assume role credentials from command line values" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            $creds = New-AWSCredentials -RoleArn role_arn -SourceProfile source_profile

            $creds.GetType().Name | Should Be "AssumeRoleAWSCredentials"
            $creds.SourceCredentials.GetCredentials().AccessKey | Should Be "access_key"
            $creds.SourceCredentials.GetCredentials().SecretKey | Should Be "secret_key"
            $creds.RoleArn | Should Be "role_arn"
        }

        It "should create assume role with mfa credentials from command line values" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            $creds = New-AWSCredentials -RoleArn role_arn -MfaSerial mfa_serial -SourceProfile source_profile

            $creds.GetType().Name | Should Be "AssumeRoleAWSCredentials"
            $creds.SourceCredentials.GetCredentials().AccessKey | Should Be "access_key"
            $creds.SourceCredentials.GetCredentials().SecretKey | Should Be "secret_key"
            $creds.RoleArn | Should Be "role_arn"
            $creds.Options.MfaSerialNumber | Should Be "mfa_serial"
        }

        It "should store assume role with external ID credentials from command line values" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            $creds = New-AWSCredentials -RoleArn role_arn -ExternalId external_id -SourceProfile source_profile

            $creds.GetType().Name | Should Be "AssumeRoleAWSCredentials"
            $creds.SourceCredentials.GetCredentials().AccessKey | Should Be "access_key"
            $creds.SourceCredentials.GetCredentials().SecretKey | Should Be "secret_key"
            $creds.RoleArn | Should Be "role_arn"
            $creds.Options.ExternalId | Should Be "external_id"
        }

        It "should create assume role with MFA and external ID credentials from command line values" {
            Set-AWSCredentials -AccessKey access_key -SecretKey secret_key -StoreAs source_profile

            $creds = New-AWSCredentials -RoleArn role_arn -MfaSerial mfa_serial -ExternalId external_id -SourceProfile source_profile

            $creds.GetType().Name | Should Be "AssumeRoleAWSCredentials"
            $creds.SourceCredentials.GetCredentials().AccessKey | Should Be "access_key"
            $creds.SourceCredentials.GetCredentials().SecretKey | Should Be "secret_key"
            $creds.RoleArn | Should Be "role_arn"
            $creds.Options.ExternalId | Should Be "external_id"
            $creds.Options.MfaSerialNumber | Should Be "mfa_serial"
        }

        <#
        It "should create federated credentials from command line values" {
            $helper.RegisterSamlEndpoint("endpoint_name", "https://some_saml_endpoint.com/", "Kerberos")

            $creds = New-AWSCredentials -EndpointName endpoint_name -RoleArn role_arn

            $creds.GetType().Name | Should Be "FederatedAWSCredentials"
            $creds.SAMLEndpoint.Name | Should Be "endpoint_name"
            $creds.SAMLEndpoint.EndpointUri | Should Be "https://some_saml_endpoint.com/"
            $creds.SAMLEndpoint.AuthenticationType | Should Be "Kerberos"
            $creds.RoleArn | Should Be "role_arn"
        }

        It "should create federated credentials with user identity from command line values" {
            $helper.RegisterSamlEndpoint("endpoint_name", "https://some_saml_endpoint.com/", "Kerberos")

            $creds = New-AWSCredentials -EndpointName endpoint_name -RoleArn role_arn -UserIdentity user_identity

            $creds.GetType().Name | Should Be "FederatedAWSCredentials"
            $creds.SAMLEndpoint.Name | Should Be "endpoint_name"
            $creds.SAMLEndpoint.EndpointUri | Should Be "https://some_saml_endpoint.com/"
            $creds.SAMLEndpoint.AuthenticationType | Should Be "Kerberos"
            $creds.RoleArn | Should Be "role_arn"
            $creds.Options.UserIdentity | Should Be "user_identity"
        }

        It "should create federated credentials with network credentials from command line values" {
            $helper.RegisterSamlEndpoint("endpoint_name", "https://some_saml_endpoint.com/", "Kerberos")

            $creds = New-AWSCredentials -EndpointName endpoint_name -RoleArn role_arn -UserIdentity user_identity  -NetworkCredential $psCreds

            $creds.GetType().Name | Should Be "FederatedAWSCredentials"
            $creds.SAMLEndpoint.Name | Should Be "endpoint_name"
            $creds.SAMLEndpoint.EndpointUri | Should Be "https://some_saml_endpoint.com/"
            $creds.SAMLEndpoint.AuthenticationType | Should Be "Kerberos"
            $creds.RoleArn | Should Be "role_arn"
            $creds.Options.UserIdentity | Should Be "user_identity"
            $creds.Options.CustomCallbackState.CmdletNetworkCredentialParameter | Should Be $psCreds
        }
        #>

        #
        # Test "creating" credentials from the -Credential parameter
        # This isn't a particularly useful mode, but we'll leave it to support backward compatibility
        #

        It "should pass through BasicAWSCredentials from the -Credential parameter" {
            $originalCreds = $helper.GetAWSCredentials($basicOptions, $null)

            $newCreds = New-AWSCredentials -Credential $originalCreds

            $newCreds.GetType().Name | Should Be "BasicAWSCredentials"
            [object]::ReferenceEquals($newCreds, $originalCreds) | Should Be $true

        }

        #
        # Test creating credentials from the -ProfileName parameter
        #

        It "should create BasicAWSCredentials from the .NET credentials file" {
            $helper.RegisterProfile("profile_name", $null, $basicOptions)
            (New-AWSCredentials -ProfileName "profile_name").GetType().Name | Should Be "BasicAWSCredentials"
        }

        It "should create BasicAWSCredentials from the default shared credentials filen" {
            $helper.RegisterProfile("profile_name", $helper.DefaultSharedPath, $basicOptions)
            (New-AWSCredentials -ProfileName "profile_name").GetType().Name | Should Be "BasicAWSCredentials"
        }

        It "should create BasicAWSCredentials from a custom shared credentials file" {
            $helper.RegisterProfile("profile_name", $helper.CustomSharedPath, $basicOptions)
            (New-AWSCredentials -ProfileName "profile_name" -ProfileLocation $helper.CustomSharedPath).GetType().Name | Should Be "BasicAWSCredentials"
        }

        It "should create SessionAWSCredentials from the .NET credentials file" {
            $helper.RegisterProfile("profile_name", $null, $sessionOptions)
            (New-AWSCredentials -ProfileName "profile_name").GetType().Name | Should Be "SessionAWSCredentials"
        }

        It "should create SessionAWSCredentials from the default shared credentials file" {
            $helper.RegisterProfile("profile_name", $helper.DefaultSharedPath, $sessionOptions)
            (New-AWSCredentials -ProfileName "profile_name").GetType().Name | Should Be "SessionAWSCredentials"
        }

        It "should create SessionAWSCredentials from a custom shared credentials file to" {
            $helper.RegisterProfile("profile_name", $helper.CustomSharedPath, $sessionOptions)
            (New-AWSCredentials -ProfileName "profile_name" -ProfileLocation $helper.CustomSharedPath).GetType().Name | Should Be "SessionAWSCredentials"
        }

        It "should create AssumeRoleAWSCredentials from the .NET credentials file" {
            $helper.RegisterProfile("source_profile", $null, $basicOptions)
            $helper.RegisterProfile("profile_name", $null, $assumeRoleOptions)
            (New-AWSCredentials -ProfileName "profile_name").GetType().Name | Should Be "AssumeRoleAWSCredentials"
        }

        It "should create AssumeRoleAWSCredentials from the default shared credentials file" {
            $helper.RegisterProfile("source_profile", $helper.DefaultSharedPath, $basicOptions)
            $helper.RegisterProfile("profile_name", $helper.DefaultSharedPath, $assumeRoleOptions)
            (New-AWSCredentials -ProfileName "profile_name").GetType().Name | Should Be "AssumeRoleAWSCredentials"
        }

        It "should create AssumeRoleAWSCredentials from a custom shared credentials file" {
            $helper.RegisterProfile("source_profile", $helper.CustomSharedPath, $basicOptions)
            $helper.RegisterProfile("profile_name", $helper.CustomSharedPath, $assumeRoleOptions)
            (New-AWSCredentials -ProfileName "profile_name" -ProfileLocation $helper.CustomSharedPath).GetType().Name | Should Be "AssumeRoleAWSCredentials"
        }

        It "should create FederatedAWSCredentials from the .NET credentials file" {
            $helper.RegisterSamlEndpoint("endpoint_name", "https://some_saml_endpoint.com", "Kerberos")
            $helper.RegisterProfile("profile_name", $null, $federatedOptions)
            (New-AWSCredentials -ProfileName "profile_name").GetType().Name | Should Be "FederatedAWSCredentials"
        }

        #
        # make sure postional parameters work
        #

        It "should work with -ProfileName as a positional parameter" {
            $helper.RegisterProfile("profile_name", $null, $basicOptions)
            (New-AWSCredentials profile_name).GetType().Name | Should Be "BasicAWSCredentials"
        }

        It "should work with -ProfileName and -ProfileLocation as positional parameters" {
            $helper.RegisterProfile("profile_name", $helper.CustomSharedPath, $basicOptions)
            (New-AWSCredentials profile_name $helper.CustomSharedPath).GetType().Name | Should Be "BasicAWSCredentials"
        }

        It "should work with -ProfileName, -ProfileLocation, and -Region as positional parameters" {
            $helper.RegisterProfile("profile_name", $helper.CustomSharedPath, $basicOptions)
            (New-AWSCredentials profile_name $helper.CustomSharedPath).GetType().Name | Should Be "BasicAWSCredentials"
        }

        #
        # Spot check to see that the parameter sets are working correctly
        #

        It "should fail if parameter sets are mixed up" {
            $creds = (New-Object Amazon.Runtime.BasicAWSCredentials("access_key", "secret_key"))

            { New-AWSCredentials -AccessKey access_key -SourceProfile source_profile } | Should Throw $parameterSetError
            { New-AWSCredentials -AccessKey access_key -Credential $creds } | Should Throw $parameterSetError
            #{ New-AWSCredentials -AccessKey access_key -UserIdentity user_identity } | Should Throw $parameterSetError
            { New-AWSCredentials -AccessKey access_key -ProfileName profile_name } | Should Throw $parameterSetError

            { New-AWSCredentials -SourceProfile source_profile -Credential $creds } | Should Throw $parameterSetError
            #{ New-AWSCredentials -SourceProfile source_profile -UserIdentity user_identity } | Should Throw $parameterSetError
            { New-AWSCredentials -SourceProfile source_profile -ProfileName profile_name } | Should Throw $parameterSetError

            #{ New-AWSCredentials -Credential $creds -UserIdentity user_identity } | Should Throw $parameterSetError
            { New-AWSCredentials -Credential $creds -ProfileName profile_name } | Should Throw $parameterSetError

            #{ New-AWSCredentials -UserIdentity user_identity -ProfileName profile_name } | Should Throw $parameterSetError
        }#>
    }
}
