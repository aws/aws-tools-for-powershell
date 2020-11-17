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

# Argument completions for service AWS IoT Wireless


$IOTW_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.IoTWireless.ExpressionType
        {
            ($_ -eq "New-IOTWDestination/ExpressionType") -Or
            ($_ -eq "Update-IOTWDestination/ExpressionType")
        }
        {
            $v = "RuleName"
            break
        }

        # Amazon.IoTWireless.PartnerType
        {
            ($_ -eq "Get-IOTWPartnerAccount/PartnerType") -Or
            ($_ -eq "Split-IOTWAwsAccountFromPartnerAccount/PartnerType") -Or
            ($_ -eq "Update-IOTWPartnerAccount/PartnerType")
        }
        {
            $v = "Sidewalk"
            break
        }

        # Amazon.IoTWireless.WirelessDeviceIdType
        "Get-IOTWWirelessDevice/IdentifierType"
        {
            $v = "DevEui","ThingName","WirelessDeviceId"
            break
        }

        # Amazon.IoTWireless.WirelessDeviceType
        {
            ($_ -eq "New-IOTWWirelessDevice/Type") -Or
            ($_ -eq "Get-IOTWWirelessDeviceList/WirelessDeviceType")
        }
        {
            $v = "LoRaWAN","Sidewalk"
            break
        }

        # Amazon.IoTWireless.WirelessGatewayIdType
        "Get-IOTWWirelessGateway/IdentifierType"
        {
            $v = "GatewayEui","ThingName","WirelessGatewayId"
            break
        }

        # Amazon.IoTWireless.WirelessGatewayServiceType
        "Get-IOTWServiceEndpoint/ServiceType"
        {
            $v = "CUPS","LNS"
            break
        }

        # Amazon.IoTWireless.WirelessGatewayTaskDefinitionType
        "Get-IOTWWirelessGatewayTaskDefinitionList/TaskDefinitionType"
        {
            $v = "UPDATE"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$IOTW_map = @{
    "ExpressionType"=@("New-IOTWDestination","Update-IOTWDestination")
    "IdentifierType"=@("Get-IOTWWirelessDevice","Get-IOTWWirelessGateway")
    "PartnerType"=@("Get-IOTWPartnerAccount","Split-IOTWAwsAccountFromPartnerAccount","Update-IOTWPartnerAccount")
    "ServiceType"=@("Get-IOTWServiceEndpoint")
    "TaskDefinitionType"=@("Get-IOTWWirelessGatewayTaskDefinitionList")
    "Type"=@("New-IOTWWirelessDevice")
    "WirelessDeviceType"=@("Get-IOTWWirelessDeviceList")
}

_awsArgumentCompleterRegistration $IOTW_Completers $IOTW_map

$IOTW_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.IOTW.$($commandName.Replace('-', ''))Cmdlet]"
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

$IOTW_SelectMap = @{
    "Select"=@("Join-IOTWAwsAccountWithPartnerAccount",
               "Join-IOTWWirelessDeviceWithThing",
               "Join-IOTWWirelessGatewayWithCertificate",
               "Join-IOTWWirelessGatewayWithThing",
               "New-IOTWDestination",
               "New-IOTWDeviceProfile",
               "New-IOTWServiceProfile",
               "New-IOTWWirelessDevice",
               "New-IOTWWirelessGateway",
               "New-IOTWWirelessGatewayTask",
               "New-IOTWWirelessGatewayTaskDefinition",
               "Remove-IOTWDestination",
               "Remove-IOTWDeviceProfile",
               "Remove-IOTWServiceProfile",
               "Remove-IOTWWirelessDevice",
               "Remove-IOTWWirelessGateway",
               "Remove-IOTWWirelessGatewayTask",
               "Remove-IOTWWirelessGatewayTaskDefinition",
               "Split-IOTWAwsAccountFromPartnerAccount",
               "Split-IOTWWirelessDeviceFromThing",
               "Split-IOTWWirelessGatewayFromCertificate",
               "Split-IOTWWirelessGatewayFromThing",
               "Get-IOTWDestination",
               "Get-IOTWDeviceProfile",
               "Get-IOTWPartnerAccount",
               "Get-IOTWServiceEndpoint",
               "Get-IOTWServiceProfile",
               "Get-IOTWWirelessDevice",
               "Get-IOTWWirelessDeviceStatistic",
               "Get-IOTWWirelessGateway",
               "Get-IOTWWirelessGatewayCertificate",
               "Get-IOTWWirelessGatewayFirmwareInformation",
               "Get-IOTWWirelessGatewayStatistic",
               "Get-IOTWWirelessGatewayTask",
               "Get-IOTWWirelessGatewayTaskDefinition",
               "Get-IOTWDestinationList",
               "Get-IOTWDeviceProfileList",
               "Get-IOTWPartnerAccountList",
               "Get-IOTWServiceProfileList",
               "Get-IOTWResourceTag",
               "Get-IOTWWirelessDeviceList",
               "Get-IOTWWirelessGatewayList",
               "Get-IOTWWirelessGatewayTaskDefinitionList",
               "Send-IOTWDataToWirelessDevice",
               "Add-IOTWResourceTag",
               "Test-IOTWWirelessDevice",
               "Remove-IOTWResourceTag",
               "Update-IOTWDestination",
               "Update-IOTWPartnerAccount",
               "Update-IOTWWirelessDevice",
               "Update-IOTWWirelessGateway")
}

_awsArgumentCompleterRegistration $IOTW_SelectCompleters $IOTW_SelectMap

