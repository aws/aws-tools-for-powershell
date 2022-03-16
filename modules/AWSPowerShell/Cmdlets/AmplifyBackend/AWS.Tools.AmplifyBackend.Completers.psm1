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

# Argument completions for service Amplify Backend


$AMPB_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.AmplifyBackend.AuthResources
        {
            ($_ -eq "New-AMPBBackendAuth/ResourceConfig_AuthResources") -Or
            ($_ -eq "Update-AMPBBackendAuth/ResourceConfig_AuthResources")
        }
        {
            $v = "IDENTITY_POOL_AND_USER_POOL","USER_POOL_ONLY"
            break
        }

        # Amazon.AmplifyBackend.DeliveryMethod
        {
            ($_ -eq "New-AMPBBackendAuth/ResourceConfig_UserPoolConfigs_ForgotPassword_DeliveryMethod") -Or
            ($_ -eq "Update-AMPBBackendAuth/ResourceConfig_UserPoolConfigs_ForgotPassword_DeliveryMethod") -Or
            ($_ -eq "New-AMPBBackendAuth/ResourceConfig_UserPoolConfigs_VerificationMessage_DeliveryMethod") -Or
            ($_ -eq "Update-AMPBBackendAuth/ResourceConfig_UserPoolConfigs_VerificationMessage_DeliveryMethod")
        }
        {
            $v = "EMAIL","SMS"
            break
        }

        # Amazon.AmplifyBackend.MFAMode
        {
            ($_ -eq "New-AMPBBackendAuth/ResourceConfig_UserPoolConfigs_Mfa_MFAMode") -Or
            ($_ -eq "Update-AMPBBackendAuth/ResourceConfig_UserPoolConfigs_Mfa_MFAMode")
        }
        {
            $v = "OFF","ON","OPTIONAL"
            break
        }

        # Amazon.AmplifyBackend.Mode
        {
            ($_ -eq "Get-AMPBBackendAPI/ResourceConfig_DefaultAuthType_Mode") -Or
            ($_ -eq "New-AMPBBackendAPI/ResourceConfig_DefaultAuthType_Mode") -Or
            ($_ -eq "Remove-AMPBBackendAPI/ResourceConfig_DefaultAuthType_Mode") -Or
            ($_ -eq "Update-AMPBBackendAPI/ResourceConfig_DefaultAuthType_Mode")
        }
        {
            $v = "AMAZON_COGNITO_USER_POOLS","API_KEY","AWS_IAM","OPENID_CONNECT"
            break
        }

        # Amazon.AmplifyBackend.OAuthGrantType
        {
            ($_ -eq "New-AMPBBackendAuth/ResourceConfig_UserPoolConfigs_OAuth_OAuthGrantType") -Or
            ($_ -eq "Update-AMPBBackendAuth/ResourceConfig_UserPoolConfigs_OAuth_OAuthGrantType")
        }
        {
            $v = "CODE","IMPLICIT"
            break
        }

        # Amazon.AmplifyBackend.ResolutionStrategy
        {
            ($_ -eq "Get-AMPBBackendAPI/ResourceConfig_ConflictResolution_ResolutionStrategy") -Or
            ($_ -eq "New-AMPBBackendAPI/ResourceConfig_ConflictResolution_ResolutionStrategy") -Or
            ($_ -eq "Remove-AMPBBackendAPI/ResourceConfig_ConflictResolution_ResolutionStrategy") -Or
            ($_ -eq "Update-AMPBBackendAPI/ResourceConfig_ConflictResolution_ResolutionStrategy")
        }
        {
            $v = "AUTOMERGE","LAMBDA","NONE","OPTIMISTIC_CONCURRENCY"
            break
        }

        # Amazon.AmplifyBackend.Service
        {
            ($_ -eq "New-AMPBBackendAuth/ResourceConfig_Service") -Or
            ($_ -eq "Update-AMPBBackendAuth/ResourceConfig_Service")
        }
        {
            $v = "COGNITO"
            break
        }

        # Amazon.AmplifyBackend.ServiceName
        {
            ($_ -eq "New-AMPBBackendStorage/ResourceConfig_ServiceName") -Or
            ($_ -eq "Update-AMPBBackendStorage/ResourceConfig_ServiceName") -Or
            ($_ -eq "Import-AMPBBackendStorage/ServiceName") -Or
            ($_ -eq "Remove-AMPBBackendStorage/ServiceName")
        }
        {
            $v = "S3"
            break
        }

        # Amazon.AmplifyBackend.SignInMethod
        "New-AMPBBackendAuth/ResourceConfig_UserPoolConfigs_SignInMethod"
        {
            $v = "EMAIL","EMAIL_AND_PHONE_NUMBER","PHONE_NUMBER","USERNAME"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$AMPB_map = @{
    "ResourceConfig_AuthResources"=@("New-AMPBBackendAuth","Update-AMPBBackendAuth")
    "ResourceConfig_ConflictResolution_ResolutionStrategy"=@("Get-AMPBBackendAPI","New-AMPBBackendAPI","Remove-AMPBBackendAPI","Update-AMPBBackendAPI")
    "ResourceConfig_DefaultAuthType_Mode"=@("Get-AMPBBackendAPI","New-AMPBBackendAPI","Remove-AMPBBackendAPI","Update-AMPBBackendAPI")
    "ResourceConfig_Service"=@("New-AMPBBackendAuth","Update-AMPBBackendAuth")
    "ResourceConfig_ServiceName"=@("New-AMPBBackendStorage","Update-AMPBBackendStorage")
    "ResourceConfig_UserPoolConfigs_ForgotPassword_DeliveryMethod"=@("New-AMPBBackendAuth","Update-AMPBBackendAuth")
    "ResourceConfig_UserPoolConfigs_Mfa_MFAMode"=@("New-AMPBBackendAuth","Update-AMPBBackendAuth")
    "ResourceConfig_UserPoolConfigs_OAuth_OAuthGrantType"=@("New-AMPBBackendAuth","Update-AMPBBackendAuth")
    "ResourceConfig_UserPoolConfigs_SignInMethod"=@("New-AMPBBackendAuth")
    "ResourceConfig_UserPoolConfigs_VerificationMessage_DeliveryMethod"=@("New-AMPBBackendAuth","Update-AMPBBackendAuth")
    "ServiceName"=@("Import-AMPBBackendStorage","Remove-AMPBBackendStorage")
}

_awsArgumentCompleterRegistration $AMPB_Completers $AMPB_map

$AMPB_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.AMPB.$($commandName.Replace('-', ''))Cmdlet]"
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

$AMPB_SelectMap = @{
    "Select"=@("Copy-AMPBBackend",
               "New-AMPBBackend",
               "New-AMPBBackendAPI",
               "New-AMPBBackendAuth",
               "New-AMPBBackendConfig",
               "New-AMPBBackendStorage",
               "New-AMPBToken",
               "Remove-AMPBBackend",
               "Remove-AMPBBackendAPI",
               "Remove-AMPBBackendAuth",
               "Remove-AMPBBackendStorage",
               "Remove-AMPBToken",
               "New-AMPBBackendAPIModel",
               "Get-AMPBBackend",
               "Get-AMPBBackendAPI",
               "Get-AMPBBackendAPIModel",
               "Get-AMPBBackendAuth",
               "Get-AMPBBackendJob",
               "Get-AMPBBackendStorage",
               "Get-AMPBToken",
               "Import-AMPBBackendAuth",
               "Import-AMPBBackendStorage",
               "Get-AMPBBackendJobList",
               "Get-AMPBS3BucketList",
               "Remove-AMPBAllBackend",
               "Remove-AMPBBackendConfig",
               "Update-AMPBBackendAPI",
               "Update-AMPBBackendAuth",
               "Update-AMPBBackendConfig",
               "Update-AMPBBackendJob",
               "Update-AMPBBackendStorage")
}

_awsArgumentCompleterRegistration $AMPB_SelectCompleters $AMPB_SelectMap

