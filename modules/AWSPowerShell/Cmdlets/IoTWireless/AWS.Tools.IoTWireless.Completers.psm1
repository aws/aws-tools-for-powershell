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
        # Amazon.IoTWireless.DeviceProfileType
        "Get-IOTWDeviceProfileList/DeviceProfileType"
        {
            $v = "LoRaWAN","Sidewalk"
            break
        }

        # Amazon.IoTWireless.DlClass
        {
            ($_ -eq "New-IOTWMulticastGroup/LoRaWAN_DlClass") -Or
            ($_ -eq "Update-IOTWMulticastGroup/LoRaWAN_DlClass")
        }
        {
            $v = "ClassB","ClassC"
            break
        }

        # Amazon.IoTWireless.DownlinkMode
        "Send-IOTWDataToWirelessDevice/ParticipatingGateways_DownlinkMode"
        {
            $v = "CONCURRENT","SEQUENTIAL","USING_UPLINK_GATEWAY"
            break
        }

        # Amazon.IoTWireless.EventNotificationPartnerType
        {
            ($_ -eq "Get-IOTWResourceEventConfiguration/PartnerType") -Or
            ($_ -eq "Update-IOTWResourceEventConfiguration/PartnerType")
        }
        {
            $v = "Sidewalk"
            break
        }

        # Amazon.IoTWireless.EventNotificationResourceType
        "Get-IOTWEventConfigurationList/ResourceType"
        {
            $v = "SidewalkAccount","WirelessDevice","WirelessGateway"
            break
        }

        # Amazon.IoTWireless.EventNotificationTopicStatus
        {
            ($_ -eq "Update-IOTWResourceEventConfiguration/ConnectionStatus_WirelessGatewayIdEventTopic") -Or
            ($_ -eq "Update-IOTWEventConfigurationByResourceType/DeviceRegistrationState_Sidewalk_WirelessDeviceEventTopic") -Or
            ($_ -eq "Update-IOTWResourceEventConfiguration/DeviceRegistrationState_WirelessDeviceIdEventTopic") -Or
            ($_ -eq "Update-IOTWResourceEventConfiguration/Join_WirelessDeviceIdEventTopic") -Or
            ($_ -eq "Update-IOTWResourceEventConfiguration/LoRaWAN_DevEuiEventTopic") -Or
            ($_ -eq "Update-IOTWResourceEventConfiguration/LoRaWAN_GatewayEuiEventTopic") -Or
            ($_ -eq "Update-IOTWEventConfigurationByResourceType/LoRaWAN_WirelessDeviceEventTopic") -Or
            ($_ -eq "Update-IOTWEventConfigurationByResourceType/LoRaWAN_WirelessGatewayEventTopic") -Or
            ($_ -eq "Update-IOTWResourceEventConfiguration/MessageDeliveryStatus_WirelessDeviceIdEventTopic") -Or
            ($_ -eq "Update-IOTWEventConfigurationByResourceType/Proximity_Sidewalk_WirelessDeviceEventTopic") -Or
            ($_ -eq "Update-IOTWResourceEventConfiguration/Proximity_WirelessDeviceIdEventTopic") -Or
            ($_ -eq "Update-IOTWResourceEventConfiguration/Sidewalk_AmazonIdEventTopic") -Or
            ($_ -eq "Update-IOTWResourceEventConfiguration/Sidewalk_DeviceRegistrationState_AmazonIdEventTopic") -Or
            ($_ -eq "Update-IOTWResourceEventConfiguration/Sidewalk_MessageDeliveryStatus_AmazonIdEventTopic") -Or
            ($_ -eq "Update-IOTWEventConfigurationByResourceType/Sidewalk_WirelessDeviceEventTopic")
        }
        {
            $v = "Disabled","Enabled"
            break
        }

        # Amazon.IoTWireless.ExpressionType
        {
            ($_ -eq "New-IOTWDestination/ExpressionType") -Or
            ($_ -eq "Update-IOTWDestination/ExpressionType")
        }
        {
            $v = "MqttTopic","RuleName"
            break
        }

        # Amazon.IoTWireless.IdentifierType
        {
            ($_ -eq "Get-IOTWResourceEventConfiguration/IdentifierType") -Or
            ($_ -eq "Update-IOTWResourceEventConfiguration/IdentifierType")
        }
        {
            $v = "DevEui","GatewayEui","PartnerAccountId","WirelessDeviceId","WirelessGatewayId"
            break
        }

        # Amazon.IoTWireless.LogLevel
        {
            ($_ -eq "Update-IOTWLogLevelsByResourceType/DefaultLogLevel") -Or
            ($_ -eq "Write-IOTWResourceLogLevel/LogLevel") -Or
            ($_ -eq "New-IOTWNetworkAnalyzerConfiguration/TraceContent_LogLevel") -Or
            ($_ -eq "Update-IOTWNetworkAnalyzerConfiguration/TraceContent_LogLevel")
        }
        {
            $v = "DISABLED","ERROR","INFO"
            break
        }

        # Amazon.IoTWireless.MessageType
        "Send-IOTWDataToWirelessDevice/Sidewalk_MessageType"
        {
            $v = "CUSTOM_COMMAND_ID_GET","CUSTOM_COMMAND_ID_NOTIFY","CUSTOM_COMMAND_ID_RESP","CUSTOM_COMMAND_ID_SET"
            break
        }

        # Amazon.IoTWireless.MulticastFrameInfo
        {
            ($_ -eq "New-IOTWNetworkAnalyzerConfiguration/TraceContent_MulticastFrameInfo") -Or
            ($_ -eq "Update-IOTWNetworkAnalyzerConfiguration/TraceContent_MulticastFrameInfo")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.IoTWireless.OnboardStatus
        "Get-IOTWDevicesForWirelessDeviceImportTaskList/Status"
        {
            $v = "FAILED","INITIALIZED","ONBOARDED","PENDING"
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

        # Amazon.IoTWireless.PositionConfigurationFec
        "Write-IOTWPositionConfiguration/SemtechGnss_Fec"
        {
            $v = "NONE","ROSE"
            break
        }

        # Amazon.IoTWireless.PositionConfigurationStatus
        "Write-IOTWPositionConfiguration/SemtechGnss_Status"
        {
            $v = "Disabled","Enabled"
            break
        }

        # Amazon.IoTWireless.PositioningConfigStatus
        {
            ($_ -eq "New-IOTWWirelessDevice/Positioning") -Or
            ($_ -eq "Update-IOTWWirelessDevice/Positioning")
        }
        {
            $v = "Disabled","Enabled"
            break
        }

        # Amazon.IoTWireless.PositionResourceType
        {
            ($_ -eq "Get-IOTWPosition/ResourceType") -Or
            ($_ -eq "Get-IOTWPositionConfiguration/ResourceType") -Or
            ($_ -eq "Get-IOTWPositionConfigurationList/ResourceType") -Or
            ($_ -eq "Get-IOTWResourcePosition/ResourceType") -Or
            ($_ -eq "Update-IOTWPosition/ResourceType") -Or
            ($_ -eq "Update-IOTWResourcePosition/ResourceType") -Or
            ($_ -eq "Write-IOTWPositionConfiguration/ResourceType")
        }
        {
            $v = "WirelessDevice","WirelessGateway"
            break
        }

        # Amazon.IoTWireless.SummaryMetricConfigurationStatus
        "Update-IOTWMetricConfiguration/SummaryMetric_Status"
        {
            $v = "Disabled","Enabled"
            break
        }

        # Amazon.IoTWireless.SupportedRfRegion
        {
            ($_ -eq "New-IOTWFuotaTask/LoRaWAN_RfRegion") -Or
            ($_ -eq "New-IOTWMulticastGroup/LoRaWAN_RfRegion") -Or
            ($_ -eq "Update-IOTWFuotaTask/LoRaWAN_RfRegion") -Or
            ($_ -eq "Update-IOTWMulticastGroup/LoRaWAN_RfRegion")
        }
        {
            $v = "AS923-1","AS923-2","AS923-3","AS923-4","AU915","CN470","CN779","EU433","EU868","IN865","KR920","RU864","US915"
            break
        }

        # Amazon.IoTWireless.WirelessDeviceFrameInfo
        {
            ($_ -eq "New-IOTWNetworkAnalyzerConfiguration/TraceContent_WirelessDeviceFrameInfo") -Or
            ($_ -eq "Update-IOTWNetworkAnalyzerConfiguration/TraceContent_WirelessDeviceFrameInfo")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.IoTWireless.WirelessDeviceIdType
        "Get-IOTWWirelessDevice/IdentifierType"
        {
            $v = "DevEui","SidewalkManufacturingSn","ThingName","WirelessDeviceId"
            break
        }

        # Amazon.IoTWireless.WirelessDeviceType
        {
            ($_ -eq "New-IOTWWirelessDevice/Type") -Or
            ($_ -eq "Get-IOTWQueuedMessageList/WirelessDeviceType") -Or
            ($_ -eq "Get-IOTWWirelessDeviceList/WirelessDeviceType") -Or
            ($_ -eq "Remove-IOTWQueuedMessage/WirelessDeviceType") -Or
            ($_ -eq "Unregister-IOTWWirelessDevice/WirelessDeviceType")
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
    "ConnectionStatus_WirelessGatewayIdEventTopic"=@("Update-IOTWResourceEventConfiguration")
    "DefaultLogLevel"=@("Update-IOTWLogLevelsByResourceType")
    "DeviceProfileType"=@("Get-IOTWDeviceProfileList")
    "DeviceRegistrationState_Sidewalk_WirelessDeviceEventTopic"=@("Update-IOTWEventConfigurationByResourceType")
    "DeviceRegistrationState_WirelessDeviceIdEventTopic"=@("Update-IOTWResourceEventConfiguration")
    "ExpressionType"=@("New-IOTWDestination","Update-IOTWDestination")
    "IdentifierType"=@("Get-IOTWResourceEventConfiguration","Get-IOTWWirelessDevice","Get-IOTWWirelessGateway","Update-IOTWResourceEventConfiguration")
    "Join_WirelessDeviceIdEventTopic"=@("Update-IOTWResourceEventConfiguration")
    "LogLevel"=@("Write-IOTWResourceLogLevel")
    "LoRaWAN_DevEuiEventTopic"=@("Update-IOTWResourceEventConfiguration")
    "LoRaWAN_DlClass"=@("New-IOTWMulticastGroup","Update-IOTWMulticastGroup")
    "LoRaWAN_GatewayEuiEventTopic"=@("Update-IOTWResourceEventConfiguration")
    "LoRaWAN_RfRegion"=@("New-IOTWFuotaTask","New-IOTWMulticastGroup","Update-IOTWFuotaTask","Update-IOTWMulticastGroup")
    "LoRaWAN_WirelessDeviceEventTopic"=@("Update-IOTWEventConfigurationByResourceType")
    "LoRaWAN_WirelessGatewayEventTopic"=@("Update-IOTWEventConfigurationByResourceType")
    "MessageDeliveryStatus_WirelessDeviceIdEventTopic"=@("Update-IOTWResourceEventConfiguration")
    "ParticipatingGateways_DownlinkMode"=@("Send-IOTWDataToWirelessDevice")
    "PartnerType"=@("Get-IOTWPartnerAccount","Get-IOTWResourceEventConfiguration","Split-IOTWAwsAccountFromPartnerAccount","Update-IOTWPartnerAccount","Update-IOTWResourceEventConfiguration")
    "Positioning"=@("New-IOTWWirelessDevice","Update-IOTWWirelessDevice")
    "Proximity_Sidewalk_WirelessDeviceEventTopic"=@("Update-IOTWEventConfigurationByResourceType")
    "Proximity_WirelessDeviceIdEventTopic"=@("Update-IOTWResourceEventConfiguration")
    "ResourceType"=@("Get-IOTWEventConfigurationList","Get-IOTWPosition","Get-IOTWPositionConfiguration","Get-IOTWPositionConfigurationList","Get-IOTWResourcePosition","Update-IOTWPosition","Update-IOTWResourcePosition","Write-IOTWPositionConfiguration")
    "SemtechGnss_Fec"=@("Write-IOTWPositionConfiguration")
    "SemtechGnss_Status"=@("Write-IOTWPositionConfiguration")
    "ServiceType"=@("Get-IOTWServiceEndpoint")
    "Sidewalk_AmazonIdEventTopic"=@("Update-IOTWResourceEventConfiguration")
    "Sidewalk_DeviceRegistrationState_AmazonIdEventTopic"=@("Update-IOTWResourceEventConfiguration")
    "Sidewalk_MessageDeliveryStatus_AmazonIdEventTopic"=@("Update-IOTWResourceEventConfiguration")
    "Sidewalk_MessageType"=@("Send-IOTWDataToWirelessDevice")
    "Sidewalk_WirelessDeviceEventTopic"=@("Update-IOTWEventConfigurationByResourceType")
    "Status"=@("Get-IOTWDevicesForWirelessDeviceImportTaskList")
    "SummaryMetric_Status"=@("Update-IOTWMetricConfiguration")
    "TaskDefinitionType"=@("Get-IOTWWirelessGatewayTaskDefinitionList")
    "TraceContent_LogLevel"=@("New-IOTWNetworkAnalyzerConfiguration","Update-IOTWNetworkAnalyzerConfiguration")
    "TraceContent_MulticastFrameInfo"=@("New-IOTWNetworkAnalyzerConfiguration","Update-IOTWNetworkAnalyzerConfiguration")
    "TraceContent_WirelessDeviceFrameInfo"=@("New-IOTWNetworkAnalyzerConfiguration","Update-IOTWNetworkAnalyzerConfiguration")
    "Type"=@("New-IOTWWirelessDevice")
    "WirelessDeviceType"=@("Get-IOTWQueuedMessageList","Get-IOTWWirelessDeviceList","Remove-IOTWQueuedMessage","Unregister-IOTWWirelessDevice")
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
               "Join-IOTWMulticastGroupWithFuotaTask",
               "Join-IOTWWirelessDeviceWithFuotaTask",
               "Join-IOTWWirelessDeviceWithMulticastGroup",
               "Join-IOTWWirelessDeviceWithThing",
               "Join-IOTWWirelessGatewayWithCertificate",
               "Join-IOTWWirelessGatewayWithThing",
               "Stop-IOTWMulticastGroupSession",
               "New-IOTWDestination",
               "New-IOTWDeviceProfile",
               "New-IOTWFuotaTask",
               "New-IOTWMulticastGroup",
               "New-IOTWNetworkAnalyzerConfiguration",
               "New-IOTWServiceProfile",
               "New-IOTWWirelessDevice",
               "New-IOTWWirelessGateway",
               "New-IOTWWirelessGatewayTask",
               "New-IOTWWirelessGatewayTaskDefinition",
               "Remove-IOTWDestination",
               "Remove-IOTWDeviceProfile",
               "Remove-IOTWFuotaTask",
               "Remove-IOTWMulticastGroup",
               "Remove-IOTWNetworkAnalyzerConfiguration",
               "Remove-IOTWQueuedMessage",
               "Remove-IOTWServiceProfile",
               "Remove-IOTWWirelessDevice",
               "Remove-IOTWWirelessDeviceImportTask",
               "Remove-IOTWWirelessGateway",
               "Remove-IOTWWirelessGatewayTask",
               "Remove-IOTWWirelessGatewayTaskDefinition",
               "Unregister-IOTWWirelessDevice",
               "Split-IOTWAwsAccountFromPartnerAccount",
               "Split-IOTWMulticastGroupFromFuotaTask",
               "Split-IOTWWirelessDeviceFromFuotaTask",
               "Split-IOTWWirelessDeviceFromMulticastGroup",
               "Split-IOTWWirelessDeviceFromThing",
               "Split-IOTWWirelessGatewayFromCertificate",
               "Split-IOTWWirelessGatewayFromThing",
               "Get-IOTWDestination",
               "Get-IOTWDeviceProfile",
               "Get-IOTWEventConfigurationByResourceType",
               "Get-IOTWFuotaTask",
               "Get-IOTWLogLevelsByResourceType",
               "Get-IOTWMetricConfiguration",
               "Get-IOTWMetric",
               "Get-IOTWMulticastGroup",
               "Get-IOTWMulticastGroupSession",
               "Get-IOTWNetworkAnalyzerConfiguration",
               "Get-IOTWPartnerAccount",
               "Get-IOTWPosition",
               "Get-IOTWPositionConfiguration",
               "Get-IOTWPositionEstimate",
               "Get-IOTWResourceEventConfiguration",
               "Get-IOTWResourceLogLevel",
               "Get-IOTWResourcePosition",
               "Get-IOTWServiceEndpoint",
               "Get-IOTWServiceProfile",
               "Get-IOTWWirelessDevice",
               "Get-IOTWWirelessDeviceImportTask",
               "Get-IOTWWirelessDeviceStatistic",
               "Get-IOTWWirelessGateway",
               "Get-IOTWWirelessGatewayCertificate",
               "Get-IOTWWirelessGatewayFirmwareInformation",
               "Get-IOTWWirelessGatewayStatistic",
               "Get-IOTWWirelessGatewayTask",
               "Get-IOTWWirelessGatewayTaskDefinition",
               "Get-IOTWDestinationList",
               "Get-IOTWDeviceProfileList",
               "Get-IOTWDevicesForWirelessDeviceImportTaskList",
               "Get-IOTWEventConfigurationList",
               "Get-IOTWFuotaTaskList",
               "Get-IOTWMulticastGroupList",
               "Get-IOTWMulticastGroupsByFuotaTaskList",
               "Get-IOTWNetworkAnalyzerConfigurationList",
               "Get-IOTWPartnerAccountList",
               "Get-IOTWPositionConfigurationList",
               "Get-IOTWQueuedMessageList",
               "Get-IOTWServiceProfileList",
               "Get-IOTWResourceTag",
               "Get-IOTWWirelessDeviceImportTaskList",
               "Get-IOTWWirelessDeviceList",
               "Get-IOTWWirelessGatewayList",
               "Get-IOTWWirelessGatewayTaskDefinitionList",
               "Write-IOTWPositionConfiguration",
               "Write-IOTWResourceLogLevel",
               "Reset-IOTWAllResourceLogLevel",
               "Reset-IOTWResourceLogLevel",
               "Send-IOTWDataToMulticastGroup",
               "Send-IOTWDataToWirelessDevice",
               "Start-IOTWBulkAssociateWirelessDeviceWithMulticastGroup",
               "Start-IOTWBulkDisassociateWirelessDeviceFromMulticastGroup",
               "Start-IOTWFuotaTask",
               "Start-IOTWMulticastGroupSession",
               "Start-IOTWSingleWirelessDeviceImportTask",
               "Start-IOTWWirelessDeviceImportTask",
               "Add-IOTWResourceTag",
               "Test-IOTWWirelessDevice",
               "Remove-IOTWResourceTag",
               "Update-IOTWDestination",
               "Update-IOTWEventConfigurationByResourceType",
               "Update-IOTWFuotaTask",
               "Update-IOTWLogLevelsByResourceType",
               "Update-IOTWMetricConfiguration",
               "Update-IOTWMulticastGroup",
               "Update-IOTWNetworkAnalyzerConfiguration",
               "Update-IOTWPartnerAccount",
               "Update-IOTWPosition",
               "Update-IOTWResourceEventConfiguration",
               "Update-IOTWResourcePosition",
               "Update-IOTWWirelessDevice",
               "Update-IOTWWirelessDeviceImportTask",
               "Update-IOTWWirelessGateway")
}

_awsArgumentCompleterRegistration $IOTW_SelectCompleters $IOTW_SelectMap

