# Auto-generated argument completers for parameters of SDK ConstantClass-derived type used in cmdlets.
# Do not modify this file; it may be overwritten during version upgrades.

$psMajorVersion = $PSVersionTable.PSVersion.Major
if ($psMajorVersion -eq 2) 
{ 
	Write-Verbose "Dynamic argument completion not supported in PowerShell version 2; skipping load."
	return 
}

# PowerShell's native Register-ArgumentCompleter cmdlet is available on v5.0 or higher. For lower
# version, we can use the version in the TabExpansion++ module if installed.
$registrationCmdletAvailable = ($psMajorVersion -ge 5) -Or !((Get-Command Register-ArgumentCompleter -ea Ignore) -eq $null)

# internal function to perform the registration using either cmdlet or manipulation
# of the options table
function _awsArgumentCompleterRegistration()
{
    param
    (
        [scriptblock]$scriptBlock,
        [hashtable]$param2CmdletsMap
    )

    if ($registrationCmdletAvailable)
    {
        foreach ($paramName in $param2CmdletsMap.Keys)
        {
             $args = @{
                "ScriptBlock" = $scriptBlock
                "Parameter" = $paramName
            }

            $cmdletNames = $param2CmdletsMap[$paramName]
            if ($cmdletNames -And $cmdletNames.Length -gt 0)
            {
                $args["Command"] = $cmdletNames
            }

            Register-ArgumentCompleter @args
        }
    }
    else
    {
        if (-not $global:options) { $global:options = @{ CustomArgumentCompleters = @{ }; NativeArgumentCompleters = @{ } } }

        foreach ($paramName in $param2CmdletsMap.Keys)
        {
            $cmdletNames = $param2CmdletsMap[$paramName]

            if ($cmdletNames -And $cmdletNames.Length -gt 0)
            {
                foreach ($cn in $cmdletNames)
                {
                    $fqn =  [string]::Concat($cn, ":", $paramName)
                    $global:options['CustomArgumentCompleters'][$fqn] = $scriptBlock
                }
            }
            else
            {
                $global:options['CustomArgumentCompleters'][$paramName] = $scriptBlock
            }
        }

        $function:tabexpansion2 = $function:tabexpansion2 -replace 'End\r\n{', 'End { if ($null -ne $options) { $options += $global:options} else {$options = $global:options}'
    }
}

# To allow for same-name parameters of different ConstantClass-derived types 
# each completer function checks on command name concatenated with parameter name.
# Additionally, the standard code pattern for completers is to pipe through 
# sort-object after filtering against $wordToComplete but we omit this as our members 
# are already sorted.

# Argument completions for service Amazon Cognito Identity Provider


$CGIP_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType
        {
            ($_ -eq "Set-CGIPRiskConfiguration/HighAction_EventAction") -Or
            ($_ -eq "Set-CGIPRiskConfiguration/LowAction_EventAction") -Or
            ($_ -eq "Set-CGIPRiskConfiguration/MediumAction_EventAction")
        }
        {
            $v = "BLOCK","MFA_IF_CONFIGURED","MFA_REQUIRED","NO_ACTION"
            break
        }

        # Amazon.CognitoIdentityProvider.AdvancedSecurityEnabledModeType
        {
            ($_ -eq "New-CGIPUserPool/AdvancedSecurityAdditionalFlows_CustomAuthMode") -Or
            ($_ -eq "Update-CGIPUserPool/AdvancedSecurityAdditionalFlows_CustomAuthMode")
        }
        {
            $v = "AUDIT","ENFORCED"
            break
        }

        # Amazon.CognitoIdentityProvider.AdvancedSecurityModeType
        {
            ($_ -eq "New-CGIPUserPool/UserPoolAddOns_AdvancedSecurityMode") -Or
            ($_ -eq "Update-CGIPUserPool/UserPoolAddOns_AdvancedSecurityMode")
        }
        {
            $v = "AUDIT","ENFORCED","OFF"
            break
        }

        # Amazon.CognitoIdentityProvider.AuthFlowType
        {
            ($_ -eq "Start-CGIPAuth/AuthFlow") -Or
            ($_ -eq "Start-CGIPAuthAdmin/AuthFlow")
        }
        {
            $v = "ADMIN_NO_SRP_AUTH","ADMIN_USER_PASSWORD_AUTH","CUSTOM_AUTH","REFRESH_TOKEN","REFRESH_TOKEN_AUTH","USER_AUTH","USER_PASSWORD_AUTH","USER_SRP_AUTH"
            break
        }

        # Amazon.CognitoIdentityProvider.ChallengeNameType
        {
            ($_ -eq "Send-CGIPAuthChallengeResponse/ChallengeName") -Or
            ($_ -eq "Send-CGIPAuthChallengeResponseAdmin/ChallengeName")
        }
        {
            $v = "ADMIN_NO_SRP_AUTH","CUSTOM_CHALLENGE","DEVICE_PASSWORD_VERIFIER","DEVICE_SRP_AUTH","EMAIL_OTP","MFA_SETUP","NEW_PASSWORD_REQUIRED","PASSWORD","PASSWORD_SRP","PASSWORD_VERIFIER","SELECT_CHALLENGE","SELECT_MFA_TYPE","SMS_MFA","SMS_OTP","SOFTWARE_TOKEN_MFA","WEB_AUTHN"
            break
        }

        # Amazon.CognitoIdentityProvider.CompromisedCredentialsEventActionType
        "Set-CGIPRiskConfiguration/Actions_EventAction"
        {
            $v = "BLOCK","NO_ACTION"
            break
        }

        # Amazon.CognitoIdentityProvider.CustomEmailSenderLambdaVersionType
        {
            ($_ -eq "New-CGIPUserPool/CustomEmailSender_LambdaVersion") -Or
            ($_ -eq "Update-CGIPUserPool/CustomEmailSender_LambdaVersion")
        }
        {
            $v = "V1_0"
            break
        }

        # Amazon.CognitoIdentityProvider.CustomSMSSenderLambdaVersionType
        {
            ($_ -eq "New-CGIPUserPool/CustomSMSSender_LambdaVersion") -Or
            ($_ -eq "Update-CGIPUserPool/CustomSMSSender_LambdaVersion")
        }
        {
            $v = "V1_0"
            break
        }

        # Amazon.CognitoIdentityProvider.DefaultEmailOptionType
        {
            ($_ -eq "New-CGIPUserPool/VerificationMessageTemplate_DefaultEmailOption") -Or
            ($_ -eq "Update-CGIPUserPool/VerificationMessageTemplate_DefaultEmailOption")
        }
        {
            $v = "CONFIRM_WITH_CODE","CONFIRM_WITH_LINK"
            break
        }

        # Amazon.CognitoIdentityProvider.DeletionProtectionType
        {
            ($_ -eq "New-CGIPUserPool/DeletionProtection") -Or
            ($_ -eq "Update-CGIPUserPool/DeletionProtection")
        }
        {
            $v = "ACTIVE","INACTIVE"
            break
        }

        # Amazon.CognitoIdentityProvider.DeviceRememberedStatusType
        {
            ($_ -eq "Edit-CGIPDeviceStatus/DeviceRememberedStatus") -Or
            ($_ -eq "Edit-CGIPDeviceStatusAdmin/DeviceRememberedStatus")
        }
        {
            $v = "not_remembered","remembered"
            break
        }

        # Amazon.CognitoIdentityProvider.EmailSendingAccountType
        {
            ($_ -eq "New-CGIPUserPool/EmailConfiguration_EmailSendingAccount") -Or
            ($_ -eq "Update-CGIPUserPool/EmailConfiguration_EmailSendingAccount")
        }
        {
            $v = "COGNITO_DEFAULT","DEVELOPER"
            break
        }

        # Amazon.CognitoIdentityProvider.FeedbackValueType
        {
            ($_ -eq "Update-CGIPAuthEventFeedback/FeedbackValue") -Or
            ($_ -eq "Update-CGIPAuthEventFeedbackAdmin/FeedbackValue")
        }
        {
            $v = "Invalid","Valid"
            break
        }

        # Amazon.CognitoIdentityProvider.IdentityProviderTypeType
        "New-CGIPIdentityProvider/ProviderType"
        {
            $v = "Facebook","Google","LoginWithAmazon","OIDC","SAML","SignInWithApple"
            break
        }

        # Amazon.CognitoIdentityProvider.MessageActionType
        "New-CGIPUserAdmin/MessageAction"
        {
            $v = "RESEND","SUPPRESS"
            break
        }

        # Amazon.CognitoIdentityProvider.PreTokenGenerationLambdaVersionType
        {
            ($_ -eq "New-CGIPUserPool/PreTokenGenerationConfig_LambdaVersion") -Or
            ($_ -eq "Update-CGIPUserPool/PreTokenGenerationConfig_LambdaVersion")
        }
        {
            $v = "V1_0","V2_0"
            break
        }

        # Amazon.CognitoIdentityProvider.PreventUserExistenceErrorTypes
        {
            ($_ -eq "New-CGIPUserPoolClient/PreventUserExistenceError") -Or
            ($_ -eq "Update-CGIPUserPoolClient/PreventUserExistenceError")
        }
        {
            $v = "ENABLED","LEGACY"
            break
        }

        # Amazon.CognitoIdentityProvider.TimeUnitsType
        {
            ($_ -eq "New-CGIPUserPoolClient/TokenValidityUnits_AccessToken") -Or
            ($_ -eq "Update-CGIPUserPoolClient/TokenValidityUnits_AccessToken") -Or
            ($_ -eq "New-CGIPUserPoolClient/TokenValidityUnits_IdToken") -Or
            ($_ -eq "Update-CGIPUserPoolClient/TokenValidityUnits_IdToken") -Or
            ($_ -eq "New-CGIPUserPoolClient/TokenValidityUnits_RefreshToken") -Or
            ($_ -eq "Update-CGIPUserPoolClient/TokenValidityUnits_RefreshToken")
        }
        {
            $v = "days","hours","minutes","seconds"
            break
        }

        # Amazon.CognitoIdentityProvider.UserPoolMfaType
        {
            ($_ -eq "New-CGIPUserPool/MfaConfiguration") -Or
            ($_ -eq "Set-CGIPUserPoolMfaConfig/MfaConfiguration") -Or
            ($_ -eq "Update-CGIPUserPool/MfaConfiguration")
        }
        {
            $v = "OFF","ON","OPTIONAL"
            break
        }

        # Amazon.CognitoIdentityProvider.UserPoolTierType
        {
            ($_ -eq "New-CGIPUserPool/UserPoolTier") -Or
            ($_ -eq "Update-CGIPUserPool/UserPoolTier")
        }
        {
            $v = "ESSENTIALS","LITE","PLUS"
            break
        }

        # Amazon.CognitoIdentityProvider.UserVerificationType
        "Set-CGIPUserPoolMfaConfig/WebAuthnConfiguration_UserVerification"
        {
            $v = "preferred","required"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CGIP_map = @{
    "Actions_EventAction"=@("Set-CGIPRiskConfiguration")
    "AdvancedSecurityAdditionalFlows_CustomAuthMode"=@("New-CGIPUserPool","Update-CGIPUserPool")
    "AuthFlow"=@("Start-CGIPAuth","Start-CGIPAuthAdmin")
    "ChallengeName"=@("Send-CGIPAuthChallengeResponse","Send-CGIPAuthChallengeResponseAdmin")
    "CustomEmailSender_LambdaVersion"=@("New-CGIPUserPool","Update-CGIPUserPool")
    "CustomSMSSender_LambdaVersion"=@("New-CGIPUserPool","Update-CGIPUserPool")
    "DeletionProtection"=@("New-CGIPUserPool","Update-CGIPUserPool")
    "DeviceRememberedStatus"=@("Edit-CGIPDeviceStatus","Edit-CGIPDeviceStatusAdmin")
    "EmailConfiguration_EmailSendingAccount"=@("New-CGIPUserPool","Update-CGIPUserPool")
    "FeedbackValue"=@("Update-CGIPAuthEventFeedback","Update-CGIPAuthEventFeedbackAdmin")
    "HighAction_EventAction"=@("Set-CGIPRiskConfiguration")
    "LowAction_EventAction"=@("Set-CGIPRiskConfiguration")
    "MediumAction_EventAction"=@("Set-CGIPRiskConfiguration")
    "MessageAction"=@("New-CGIPUserAdmin")
    "MfaConfiguration"=@("New-CGIPUserPool","Set-CGIPUserPoolMfaConfig","Update-CGIPUserPool")
    "PreTokenGenerationConfig_LambdaVersion"=@("New-CGIPUserPool","Update-CGIPUserPool")
    "PreventUserExistenceError"=@("New-CGIPUserPoolClient","Update-CGIPUserPoolClient")
    "ProviderType"=@("New-CGIPIdentityProvider")
    "TokenValidityUnits_AccessToken"=@("New-CGIPUserPoolClient","Update-CGIPUserPoolClient")
    "TokenValidityUnits_IdToken"=@("New-CGIPUserPoolClient","Update-CGIPUserPoolClient")
    "TokenValidityUnits_RefreshToken"=@("New-CGIPUserPoolClient","Update-CGIPUserPoolClient")
    "UserPoolAddOns_AdvancedSecurityMode"=@("New-CGIPUserPool","Update-CGIPUserPool")
    "UserPoolTier"=@("New-CGIPUserPool","Update-CGIPUserPool")
    "VerificationMessageTemplate_DefaultEmailOption"=@("New-CGIPUserPool","Update-CGIPUserPool")
    "WebAuthnConfiguration_UserVerification"=@("Set-CGIPUserPoolMfaConfig")
}

_awsArgumentCompleterRegistration $CGIP_Completers $CGIP_map

$CGIP_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CGIP.$($commandName.Replace('-', ''))Cmdlet]"
    if (-not $cmdletType) {
        return
    }
    $awsCmdletAttribute = $cmdletType.GetCustomAttributes([Amazon.PowerShell.Common.AWSCmdletAttribute], $false)
    if (-not $awsCmdletAttribute) {
        return
    }
    $type = $awsCmdletAttribute.SelectReturnType
    if (-not $type) {
        return
    }

    $splitSelect = $wordToComplete -Split '\.'
    $splitSelect | Select-Object -First ($splitSelect.Length - 1) | ForEach-Object {
        $propertyName = $_
        $properties = $type.GetProperties(('Instance', 'Public', 'DeclaredOnly')) | Where-Object { $_.Name -ieq $propertyName }
        if ($properties.Length -ne 1) {
            break
        }
        $type = $properties.PropertyType
        $prefix += "$($properties.Name)."

        $asEnumerableType = $type.GetInterface('System.Collections.Generic.IEnumerable`1')
        if ($asEnumerableType -and $type -ne [System.String]) {
            $type =  $asEnumerableType.GetGenericArguments()[0]
        }
    }

    $v = @( '*' )
    $properties = $type.GetProperties(('Instance', 'Public', 'DeclaredOnly')).Name | Sort-Object
    if ($properties) {
        $v += ($properties | ForEach-Object { $prefix + $_ })
    }
    $parameters = $cmdletType.GetProperties(('Instance', 'Public')) | Where-Object { $_.GetCustomAttributes([System.Management.Automation.ParameterAttribute], $true) } | Select-Object -ExpandProperty Name | Sort-Object
    if ($parameters) {
        $v += ($parameters | ForEach-Object { "^$_" })
    }

    $v |
        Where-Object { $_ -match "^$([System.Text.RegularExpressions.Regex]::Escape($wordToComplete)).*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CGIP_SelectMap = @{
    "Select"=@("Add-CGIPCustomAttribute",
               "Add-CGIPUserToGroupAdmin",
               "Confirm-CGIPUserRegistrationAdmin",
               "New-CGIPUserAdmin",
               "Remove-CGIPUserAdmin",
               "Remove-CGIPUserAttributeAdmin",
               "Disable-CGIPProviderForUserAdmin",
               "Disable-CGIPUserAdmin",
               "Enable-CGIPUserAdmin",
               "Stop-CGIPDeviceTrackingAdmin",
               "Get-CGIPDeviceAdmin",
               "Get-CGIPUserAdmin",
               "Start-CGIPAuthAdmin",
               "Connect-CGIPProviderForUserAdmin",
               "Get-CGIPDeviceListAdmin",
               "Get-CGIPGroupsForUserAdmin",
               "Get-CGIPUserAuthEventListAdmin",
               "Remove-CGIPUserFromGroupAdmin",
               "Reset-CGIPUserPasswordAdmin",
               "Send-CGIPAuthChallengeResponseAdmin",
               "Set-CGIPUserMFAPreferenceAdmin",
               "Set-CGIPUserPasswordAdmin",
               "Set-CGIPUserSettingAdmin",
               "Update-CGIPAuthEventFeedbackAdmin",
               "Edit-CGIPDeviceStatusAdmin",
               "Update-CGIPUserAttributeAdmin",
               "Disconnect-CGIPUserGlobalAdmin",
               "Add-CGIPSoftwareToken",
               "Update-CGIPPassword",
               "Complete-CGIPWebAuthnRegistration",
               "Approve-CGIPDevice",
               "Confirm-CGIPForgotPassword",
               "Confirm-CGIPUserRegistration",
               "New-CGIPGroup",
               "New-CGIPIdentityProvider",
               "New-CGIPManagedLoginBranding",
               "New-CGIPResourceServer",
               "New-CGIPUserImportJob",
               "New-CGIPUserPool",
               "New-CGIPUserPoolClient",
               "New-CGIPUserPoolDomain",
               "Remove-CGIPGroup",
               "Remove-CGIPIdentityProvider",
               "Remove-CGIPManagedLoginBranding",
               "Remove-CGIPResourceServer",
               "Remove-CGIPUser",
               "Remove-CGIPUserAttribute",
               "Remove-CGIPUserPool",
               "Remove-CGIPUserPoolClient",
               "Remove-CGIPUserPoolDomain",
               "Remove-CGIPWebAuthnCredential",
               "Get-CGIPIdentityProvider",
               "Get-CGIPManagedLoginBranding",
               "Get-CGIPManagedLoginBrandingByClient",
               "Get-CGIPResourceServer",
               "Get-CGIPRiskConfiguration",
               "Get-CGIPUserImportJob",
               "Get-CGIPUserPool",
               "Get-CGIPUserPoolClient",
               "Get-CGIPUserPoolDomain",
               "Stop-CGIPDeviceTracking",
               "Reset-CGIPForgottenPassword",
               "Get-CGIPCSVHeader",
               "Get-CGIPDevice",
               "Get-CGIPGroup",
               "Get-CGIPIdentityProviderByIdentifier",
               "Get-CGIPLogDeliveryConfiguration",
               "Get-CGIPSigningCertificate",
               "Get-CGIPUICustomization",
               "Get-CGIPUser",
               "Get-CGIPUserAttributeVerificationCode",
               "Get-CGIPUserAuthFactor",
               "Get-CGIPUserPoolMfaConfig",
               "Disconnect-CGIPDeviceGlobal",
               "Start-CGIPAuth",
               "Get-CGIPDeviceList",
               "Get-CGIPGroupList",
               "Get-CGIPIdentityProviderList",
               "Get-CGIPResourceServerList",
               "Get-CGIPResourceTag",
               "Get-CGIPUserImportJobList",
               "Get-CGIPUserPoolClientList",
               "Get-CGIPUserPoolList",
               "Get-CGIPUserList",
               "Get-CGIPUsersInGroup",
               "Get-CGIPWebAuthnCredentialList",
               "Send-CGIPConfirmationCode",
               "Send-CGIPAuthChallengeResponse",
               "Revoke-CGIPToken",
               "Set-CGIPLogDeliveryConfiguration",
               "Set-CGIPRiskConfiguration",
               "Set-CGIPUICustomization",
               "Set-CGIPUserMFAPreference",
               "Set-CGIPUserPoolMfaConfig",
               "Set-CGIPUserSetting",
               "Register-CGIPUserInPool",
               "Start-CGIPUserImportJob",
               "Start-CGIPWebAuthnRegistration",
               "Stop-CGIPUserImportJob",
               "Add-CGIPResourceTag",
               "Remove-CGIPResourceTag",
               "Update-CGIPAuthEventFeedback",
               "Edit-CGIPDeviceStatus",
               "Update-CGIPGroup",
               "Update-CGIPIdentityProvider",
               "Update-CGIPManagedLoginBranding",
               "Update-CGIPResourceServer",
               "Update-CGIPUserAttribute",
               "Update-CGIPUserPool",
               "Update-CGIPUserPoolClient",
               "Update-CGIPUserPoolDomain",
               "Test-CGIPSoftwareToken",
               "Test-CGIPUserAttribute")
}

_awsArgumentCompleterRegistration $CGIP_SelectCompleters $CGIP_SelectMap

