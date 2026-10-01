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

# Argument completions for service AWS End User Messaging


$EUM_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.EndUserMessaging.CodeType
        {
            ($_ -eq "New-EUMNotifyCodeConfiguration/CodeConfigurationParameters_CodeType") -Or
            ($_ -eq "Update-EUMNotifyCodeConfiguration/CodeConfigurationParameters_CodeType") -Or
            ($_ -eq "Send-EUMNotifyCodeVerification/OverrideCodeConfigurationParameters_CodeType")
        }
        {
            $v = "ALPHA","ALPHANUMERIC","NUMERIC"
            break
        }

        # Amazon.EndUserMessaging.JobStatus
        "Get-EUMJobList/Status"
        {
            $v = "FAILED","PROCESSING","SUCCESS"
            break
        }

        # Amazon.EndUserMessaging.NotifyChannel
        "Send-EUMNotifyCodeVerification/Channel"
        {
            $v = "TEXT","VOICE","WHATSAPP"
            break
        }

        # Amazon.EndUserMessaging.OnAttributeConflict
        {
            ($_ -eq "Update-EUMBrandProfileFromRegistration/OnAttributeConflict") -Or
            ($_ -eq "Update-EUMRegistrationsFromBrandProfile/OnAttributeConflict")
        }
        {
            $v = "PRESERVE","REPLACE"
            break
        }

        # Amazon.EndUserMessaging.VoiceMessageBodyTextType
        {
            ($_ -eq "New-EUMNotifyCodeConfiguration/ChannelParameters_Voice_VoiceMessageBodyTextType") -Or
            ($_ -eq "Update-EUMNotifyCodeConfiguration/ChannelParameters_Voice_VoiceMessageBodyTextType") -Or
            ($_ -eq "Send-EUMNotifyCodeVerification/OverrideChannelParameters_Voice_VoiceMessageBodyTextType")
        }
        {
            $v = "SSML","TEXT"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EUM_map = @{
    "Channel"=@("Send-EUMNotifyCodeVerification")
    "ChannelParameters_Voice_VoiceMessageBodyTextType"=@("New-EUMNotifyCodeConfiguration","Update-EUMNotifyCodeConfiguration")
    "CodeConfigurationParameters_CodeType"=@("New-EUMNotifyCodeConfiguration","Update-EUMNotifyCodeConfiguration")
    "OnAttributeConflict"=@("Update-EUMBrandProfileFromRegistration","Update-EUMRegistrationsFromBrandProfile")
    "OverrideChannelParameters_Voice_VoiceMessageBodyTextType"=@("Send-EUMNotifyCodeVerification")
    "OverrideCodeConfigurationParameters_CodeType"=@("Send-EUMNotifyCodeVerification")
    "Status"=@("Get-EUMJobList")
}

_awsArgumentCompleterRegistration $EUM_Completers $EUM_map

$EUM_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.EUM.$($commandName.Replace('-', ''))Cmdlet]"
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

$EUM_SelectMap = @{
    "Select"=@("New-EUMBrandProfile",
               "New-EUMBrandProfileAttribute",
               "New-EUMBrandProfileFromRegistration",
               "New-EUMNotifyCodeConfiguration",
               "New-EUMRegistrationsFromBrandProfile",
               "Remove-EUMBrandProfile",
               "Remove-EUMBrandProfileAttribute",
               "Remove-EUMNotifyCodeConfiguration",
               "Get-EUMBrandProfile",
               "Get-EUMBrandProfileAttribute",
               "Get-EUMJob",
               "Get-EUMNotifyCodeConfiguration",
               "Get-EUMBrandProfileAttributeList",
               "Get-EUMBrandProfileList",
               "Get-EUMJobList",
               "Get-EUMNotifyCodeConfigurationList",
               "Get-EUMRegistrationsFromBrandProfileList",
               "Get-EUMResourceTag",
               "Send-EUMNotifyCodeVerification",
               "Add-EUMResourceTag",
               "Remove-EUMResourceTag",
               "Update-EUMBrandProfile",
               "Update-EUMBrandProfileAttribute",
               "Update-EUMBrandProfileFromRegistration",
               "Update-EUMNotifyCodeConfiguration",
               "Update-EUMRegistrationsFromBrandProfile",
               "Confirm-EUMNotifyCodeVerification")
}

_awsArgumentCompleterRegistration $EUM_SelectCompleters $EUM_SelectMap

