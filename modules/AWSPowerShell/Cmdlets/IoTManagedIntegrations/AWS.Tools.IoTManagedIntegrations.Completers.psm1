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

# Argument completions for service Managed integrations for AWS IoT Device Management


$IOTMI_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.IoTManagedIntegrations.AuthMaterialType
        "New-IOTMIManagedThing/AuthenticationMaterialType"
        {
            $v = "CUSTOM_PROTOCOL_QR_BAR_CODE","DISCOVERED_DEVICE","WIFI_SETUP_QR_BAR_CODE","ZIGBEE_QR_BAR_CODE","ZWAVE_QR_BAR_CODE"
            break
        }

        # Amazon.IoTManagedIntegrations.AuthType
        {
            ($_ -eq "New-IOTMIConnectorDestination/AuthType") -Or
            ($_ -eq "Update-IOTMIConnectorDestination/AuthType")
        }
        {
            $v = "OAUTH"
            break
        }

        # Amazon.IoTManagedIntegrations.CloudConnectorType
        "Get-IOTMICloudConnectorList/Type"
        {
            $v = "LISTED","UNLISTED"
            break
        }

        # Amazon.IoTManagedIntegrations.ConnectorEventOperation
        "Send-IOTMIConnectorEvent/Operation"
        {
            $v = "DEVICE_COMMAND_REQUEST","DEVICE_COMMAND_RESPONSE","DEVICE_DISCOVERY","DEVICE_EVENT"
            break
        }

        # Amazon.IoTManagedIntegrations.DeliveryDestinationType
        {
            ($_ -eq "New-IOTMIDestination/DeliveryDestinationType") -Or
            ($_ -eq "Update-IOTMIDestination/DeliveryDestinationType")
        }
        {
            $v = "KINESIS"
            break
        }

        # Amazon.IoTManagedIntegrations.DeviceDiscoveryStatus
        "Get-IOTMIDeviceDiscoveryList/StatusFilter"
        {
            $v = "FAILED","RUNNING","SUCCEEDED","TIMED_OUT"
            break
        }

        # Amazon.IoTManagedIntegrations.DiscoveryAuthMaterialType
        "Start-IOTMIDeviceDiscovery/AuthenticationMaterialType"
        {
            $v = "ZWAVE_INSTALL_CODE"
            break
        }

        # Amazon.IoTManagedIntegrations.DiscoveryType
        {
            ($_ -eq "Start-IOTMIDeviceDiscovery/DiscoveryType") -Or
            ($_ -eq "Get-IOTMIDeviceDiscoveryList/TypeFilter")
        }
        {
            $v = "CLOUD","CUSTOM","ZIGBEE","ZWAVE"
            break
        }

        # Amazon.IoTManagedIntegrations.EncryptionType
        "Write-IOTMIDefaultEncryptionConfiguration/EncryptionType"
        {
            $v = "CUSTOMER_KEY_ENCRYPTION","MANAGED_INTEGRATIONS_DEFAULT_ENCRYPTION"
            break
        }

        # Amazon.IoTManagedIntegrations.EndpointType
        "New-IOTMICloudConnector/EndpointType"
        {
            $v = "LAMBDA"
            break
        }

        # Amazon.IoTManagedIntegrations.EventType
        {
            ($_ -eq "Get-IOTMINotificationConfiguration/EventType") -Or
            ($_ -eq "New-IOTMINotificationConfiguration/EventType") -Or
            ($_ -eq "Remove-IOTMINotificationConfiguration/EventType") -Or
            ($_ -eq "Update-IOTMINotificationConfiguration/EventType")
        }
        {
            $v = "ACCOUNT_ASSOCIATION","CONNECTOR_ASSOCIATION","CONNECTOR_ERROR_REPORT","DEVICE_COMMAND","DEVICE_COMMAND_REQUEST","DEVICE_DISCOVERY_STATUS","DEVICE_EVENT","DEVICE_LIFE_CYCLE","DEVICE_OTA","DEVICE_STATE"
            break
        }

        # Amazon.IoTManagedIntegrations.HubNetworkMode
        "Update-IOTMIManagedThing/HubNetworkMode"
        {
            $v = "NETWORK_WIDE_EXCLUSION","STANDARD"
            break
        }

        # Amazon.IoTManagedIntegrations.LogLevel
        {
            ($_ -eq "New-IOTMIEventLogConfiguration/EventLogLevel") -Or
            ($_ -eq "Update-IOTMIEventLogConfiguration/EventLogLevel") -Or
            ($_ -eq "Write-IOTMIRuntimeLogConfiguration/RuntimeLogConfigurations_LogFlushLevel") -Or
            ($_ -eq "Write-IOTMIRuntimeLogConfiguration/RuntimeLogConfigurations_LogLevel")
        }
        {
            $v = "DEBUG","ERROR","INFO","WARN"
            break
        }

        # Amazon.IoTManagedIntegrations.OtaMechanism
        "New-IOTMIOtaTask/OtaMechanism"
        {
            $v = "PUSH"
            break
        }

        # Amazon.IoTManagedIntegrations.OtaProtocol
        "New-IOTMIOtaTask/Protocol"
        {
            $v = "HTTP"
            break
        }

        # Amazon.IoTManagedIntegrations.OtaType
        "New-IOTMIOtaTask/OtaType"
        {
            $v = "CONTINUOUS","ONE_TIME"
            break
        }

        # Amazon.IoTManagedIntegrations.ProvisioningStatus
        "Get-IOTMIManagedThingList/ProvisioningStatusFilter"
        {
            $v = "ACTIVATED","DELETED","DELETE_IN_PROGRESS","DELETION_FAILED","DISCOVERED","ISOLATED","PRE_ASSOCIATED","UNASSOCIATED"
            break
        }

        # Amazon.IoTManagedIntegrations.ProvisioningType
        "New-IOTMIProvisioningProfile/ProvisioningType"
        {
            $v = "FLEET_PROVISIONING","JITR"
            break
        }

        # Amazon.IoTManagedIntegrations.Role
        {
            ($_ -eq "New-IOTMIManagedThing/Role") -Or
            ($_ -eq "Get-IOTMIManagedThingList/RoleFilter")
        }
        {
            $v = "CONTROLLER","DEVICE"
            break
        }

        # Amazon.IoTManagedIntegrations.SchedulingConfigEndBehavior
        "New-IOTMIOtaTask/OtaSchedulingConfig_EndBehavior"
        {
            $v = "CANCEL","FORCE_CANCEL","STOP_ROLLOUT"
            break
        }

        # Amazon.IoTManagedIntegrations.SchemaVersionFormat
        "Get-IOTMISchemaVersion/Format"
        {
            $v = "AWS","CONNECTOR","ZCL"
            break
        }

        # Amazon.IoTManagedIntegrations.SchemaVersionType
        {
            ($_ -eq "Get-IOTMISchemaVersion/Type") -Or
            ($_ -eq "Get-IOTMISchemaVersionList/Type")
        }
        {
            $v = "capability","definition"
            break
        }

        # Amazon.IoTManagedIntegrations.SchemaVersionVisibility
        "Get-IOTMISchemaVersionList/Visibility"
        {
            $v = "PRIVATE","PUBLIC"
            break
        }

        # Amazon.IoTManagedIntegrations.TokenEndpointAuthenticationScheme
        "New-IOTMIConnectorDestination/OAuth_TokenEndpointAuthenticationScheme"
        {
            $v = "HTTP_BASIC","REQUEST_BODY_CREDENTIALS"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$IOTMI_map = @{
    "AuthenticationMaterialType"=@("New-IOTMIManagedThing","Start-IOTMIDeviceDiscovery")
    "AuthType"=@("New-IOTMIConnectorDestination","Update-IOTMIConnectorDestination")
    "DeliveryDestinationType"=@("New-IOTMIDestination","Update-IOTMIDestination")
    "DiscoveryType"=@("Start-IOTMIDeviceDiscovery")
    "EncryptionType"=@("Write-IOTMIDefaultEncryptionConfiguration")
    "EndpointType"=@("New-IOTMICloudConnector")
    "EventLogLevel"=@("New-IOTMIEventLogConfiguration","Update-IOTMIEventLogConfiguration")
    "EventType"=@("Get-IOTMINotificationConfiguration","New-IOTMINotificationConfiguration","Remove-IOTMINotificationConfiguration","Update-IOTMINotificationConfiguration")
    "Format"=@("Get-IOTMISchemaVersion")
    "HubNetworkMode"=@("Update-IOTMIManagedThing")
    "OAuth_TokenEndpointAuthenticationScheme"=@("New-IOTMIConnectorDestination")
    "Operation"=@("Send-IOTMIConnectorEvent")
    "OtaMechanism"=@("New-IOTMIOtaTask")
    "OtaSchedulingConfig_EndBehavior"=@("New-IOTMIOtaTask")
    "OtaType"=@("New-IOTMIOtaTask")
    "Protocol"=@("New-IOTMIOtaTask")
    "ProvisioningStatusFilter"=@("Get-IOTMIManagedThingList")
    "ProvisioningType"=@("New-IOTMIProvisioningProfile")
    "Role"=@("New-IOTMIManagedThing")
    "RoleFilter"=@("Get-IOTMIManagedThingList")
    "RuntimeLogConfigurations_LogFlushLevel"=@("Write-IOTMIRuntimeLogConfiguration")
    "RuntimeLogConfigurations_LogLevel"=@("Write-IOTMIRuntimeLogConfiguration")
    "StatusFilter"=@("Get-IOTMIDeviceDiscoveryList")
    "Type"=@("Get-IOTMICloudConnectorList","Get-IOTMISchemaVersion","Get-IOTMISchemaVersionList")
    "TypeFilter"=@("Get-IOTMIDeviceDiscoveryList")
    "Visibility"=@("Get-IOTMISchemaVersionList")
}

_awsArgumentCompleterRegistration $IOTMI_Completers $IOTMI_map

$IOTMI_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.IOTMI.$($commandName.Replace('-', ''))Cmdlet]"
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

$IOTMI_SelectMap = @{
    "Select"=@("New-IOTMIAccountAssociation",
               "New-IOTMICloudConnector",
               "New-IOTMIConnectorDestination",
               "New-IOTMICredentialLocker",
               "New-IOTMIDestination",
               "New-IOTMIEventLogConfiguration",
               "New-IOTMIManagedThing",
               "New-IOTMINotificationConfiguration",
               "New-IOTMIOtaTask",
               "New-IOTMIOtaTaskConfiguration",
               "New-IOTMIProvisioningProfile",
               "Remove-IOTMIAccountAssociation",
               "Remove-IOTMICloudConnector",
               "Remove-IOTMIConnectorDestination",
               "Remove-IOTMICredentialLocker",
               "Remove-IOTMIDestination",
               "Remove-IOTMIEventLogConfiguration",
               "Remove-IOTMIManagedThing",
               "Remove-IOTMINotificationConfiguration",
               "Remove-IOTMIOtaTask",
               "Remove-IOTMIOtaTaskConfiguration",
               "Remove-IOTMIProvisioningProfile",
               "Unregister-IOTMIAccountAssociation",
               "Get-IOTMIAccountAssociation",
               "Get-IOTMICloudConnector",
               "Get-IOTMIConnectorDestination",
               "Get-IOTMICredentialLocker",
               "Get-IOTMICustomEndpoint",
               "Get-IOTMIDefaultEncryptionConfiguration",
               "Get-IOTMIDestination",
               "Get-IOTMIDeviceDiscovery",
               "Get-IOTMIEventLogConfiguration",
               "Get-IOTMIHubConfiguration",
               "Get-IOTMIManagedThing",
               "Get-IOTMIManagedThingCapability",
               "Get-IOTMIManagedThingCertificate",
               "Get-IOTMIManagedThingConnectivityData",
               "Get-IOTMIManagedThingMetaData",
               "Get-IOTMIManagedThingState",
               "Get-IOTMINotificationConfiguration",
               "Get-IOTMIOtaTask",
               "Get-IOTMIOtaTaskConfiguration",
               "Get-IOTMIProvisioningProfile",
               "Get-IOTMIRuntimeLogConfiguration",
               "Get-IOTMISchemaVersion",
               "Get-IOTMIAccountAssociationList",
               "Get-IOTMICloudConnectorList",
               "Get-IOTMIConnectorDestinationList",
               "Get-IOTMICredentialLockerList",
               "Get-IOTMIDestinationList",
               "Get-IOTMIDeviceDiscoveryList",
               "Get-IOTMIDiscoveredDeviceList",
               "Get-IOTMIEventLogConfigurationList",
               "Get-IOTMIManagedThingAccountAssociationList",
               "Get-IOTMIManagedThingList",
               "Get-IOTMIManagedThingSchemaList",
               "Get-IOTMINotificationConfigurationList",
               "Get-IOTMIOtaTaskConfigurationList",
               "Get-IOTMIOtaTaskExecutionList",
               "Get-IOTMIOtaTaskList",
               "Get-IOTMIProvisioningProfileList",
               "Get-IOTMISchemaVersionList",
               "Get-IOTMIResourceTag",
               "Write-IOTMIDefaultEncryptionConfiguration",
               "Write-IOTMIHubConfiguration",
               "Write-IOTMIRuntimeLogConfiguration",
               "Register-IOTMIAccountAssociation",
               "Register-IOTMICustomEndpoint",
               "Reset-IOTMIRuntimeLogConfiguration",
               "Send-IOTMIConnectorEvent",
               "Send-IOTMIManagedThingCommand",
               "Start-IOTMIAccountAssociationRefresh",
               "Start-IOTMIDeviceDiscovery",
               "Add-IOTMIResourceTag",
               "Remove-IOTMIResourceTag",
               "Update-IOTMIAccountAssociation",
               "Update-IOTMICloudConnector",
               "Update-IOTMIConnectorDestination",
               "Update-IOTMIDestination",
               "Update-IOTMIEventLogConfiguration",
               "Update-IOTMIManagedThing",
               "Update-IOTMINotificationConfiguration",
               "Update-IOTMIOtaTask")
}

_awsArgumentCompleterRegistration $IOTMI_SelectCompleters $IOTMI_SelectMap

