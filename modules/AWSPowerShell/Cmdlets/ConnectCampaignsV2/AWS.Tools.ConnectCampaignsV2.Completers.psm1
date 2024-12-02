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

# Argument completions for service AmazonConnectCampaignServiceV2


$CCS2_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ConnectCampaignsV2.CampaignDeletionPolicy
        "Remove-CCS2ConnectInstanceConfig/CampaignDeletionPolicy"
        {
            $v = "DELETE_ALL","RETAIN_ALL"
            break
        }

        # Amazon.ConnectCampaignsV2.ChannelSubtype
        "Remove-CCS2CampaignChannelSubtypeConfig/ChannelSubtype"
        {
            $v = "EMAIL","SMS","TELEPHONY"
            break
        }

        # Amazon.ConnectCampaignsV2.CommunicationLimitsConfigType
        "Remove-CCS2CampaignCommunicationLimit/Config"
        {
            $v = "ALL_CHANNEL_SUBTYPES"
            break
        }

        # Amazon.ConnectCampaignsV2.CommunicationTimeConfigType
        "Remove-CCS2CampaignCommunicationTime/Config"
        {
            $v = "EMAIL","SMS","TELEPHONY"
            break
        }

        # Amazon.ConnectCampaignsV2.EncryptionType
        "Start-CCS2InstanceOnboardingJob/EncryptionConfig_EncryptionType"
        {
            $v = "KMS"
            break
        }

        # Amazon.ConnectCampaignsV2.InstanceIdFilterOperator
        "Get-CCS2CampaignList/InstanceIdFilter_Operator"
        {
            $v = "Eq"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CCS2_map = @{
    "CampaignDeletionPolicy"=@("Remove-CCS2ConnectInstanceConfig")
    "ChannelSubtype"=@("Remove-CCS2CampaignChannelSubtypeConfig")
    "Config"=@("Remove-CCS2CampaignCommunicationLimit","Remove-CCS2CampaignCommunicationTime")
    "EncryptionConfig_EncryptionType"=@("Start-CCS2InstanceOnboardingJob")
    "InstanceIdFilter_Operator"=@("Get-CCS2CampaignList")
}

_awsArgumentCompleterRegistration $CCS2_Completers $CCS2_map

$CCS2_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CCS2.$($commandName.Replace('-', ''))Cmdlet]"
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

$CCS2_SelectMap = @{
    "Select"=@("New-CCS2Campaign",
               "Remove-CCS2Campaign",
               "Remove-CCS2CampaignChannelSubtypeConfig",
               "Remove-CCS2CampaignCommunicationLimit",
               "Remove-CCS2CampaignCommunicationTime",
               "Remove-CCS2ConnectInstanceConfig",
               "Remove-CCS2ConnectInstanceIntegration",
               "Remove-CCS2InstanceOnboardingJob",
               "Get-CCS2Campaign",
               "Get-CCS2CampaignState",
               "Get-CCS2CampaignStateBatch",
               "Get-CCS2ConnectInstanceConfig",
               "Get-CCS2InstanceOnboardingJobStatus",
               "Get-CCS2CampaignList",
               "Get-CCS2ConnectInstanceIntegrationList",
               "Get-CCS2ResourceTag",
               "Suspend-CCS2Campaign",
               "Write-CCS2ConnectInstanceIntegration",
               "Write-CCS2OutboundRequestBatch",
               "Write-CCS2ProfileOutboundRequestBatch",
               "Resume-CCS2Campaign",
               "Start-CCS2Campaign",
               "Start-CCS2InstanceOnboardingJob",
               "Stop-CCS2Campaign",
               "Add-CCS2ResourceTag",
               "Remove-CCS2ResourceTag",
               "Update-CCS2CampaignChannelSubtypeConfig",
               "Update-CCS2CampaignCommunicationLimit",
               "Update-CCS2CampaignCommunicationTime",
               "Update-CCS2CampaignFlowAssociation",
               "Update-CCS2CampaignName",
               "Update-CCS2CampaignSchedule",
               "Update-CCS2CampaignSource")
}

_awsArgumentCompleterRegistration $CCS2_SelectCompleters $CCS2_SelectMap

