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

# Argument completions for service AWS Elemental MediaLive


$EML_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.MediaLive.AcceptHeader
        "Get-EMLInputDeviceThumbnail/Accept"
        {
            $v = "image/jpeg"
            break
        }

        # Amazon.MediaLive.CdiInputResolution
        {
            ($_ -eq "New-EMLChannel/CdiInputSpecification_Resolution") -Or
            ($_ -eq "Update-EMLChannel/CdiInputSpecification_Resolution")
        }
        {
            $v = "FHD","HD","SD","UHD"
            break
        }

        # Amazon.MediaLive.ChannelClass
        {
            ($_ -eq "New-EMLChannel/ChannelClass") -Or
            ($_ -eq "Update-EMLChannelClass/ChannelClass")
        }
        {
            $v = "SINGLE_PIPELINE","STANDARD"
            break
        }

        # Amazon.MediaLive.CloudWatchAlarmTemplateComparisonOperator
        {
            ($_ -eq "New-EMLCloudWatchAlarmTemplate/ComparisonOperator") -Or
            ($_ -eq "Update-EMLCloudWatchAlarmTemplate/ComparisonOperator")
        }
        {
            $v = "GreaterThanOrEqualToThreshold","GreaterThanThreshold","LessThanOrEqualToThreshold","LessThanThreshold"
            break
        }

        # Amazon.MediaLive.CloudWatchAlarmTemplateStatistic
        {
            ($_ -eq "New-EMLCloudWatchAlarmTemplate/Statistic") -Or
            ($_ -eq "Update-EMLCloudWatchAlarmTemplate/Statistic")
        }
        {
            $v = "Average","Maximum","Minimum","SampleCount","Sum"
            break
        }

        # Amazon.MediaLive.CloudWatchAlarmTemplateTargetResourceType
        {
            ($_ -eq "New-EMLCloudWatchAlarmTemplate/TargetResourceType") -Or
            ($_ -eq "Update-EMLCloudWatchAlarmTemplate/TargetResourceType")
        }
        {
            $v = "CLOUDFRONT_DISTRIBUTION","MEDIACONNECT_FLOW","MEDIALIVE_CHANNEL","MEDIALIVE_INPUT_DEVICE","MEDIALIVE_MULTIPLEX","MEDIAPACKAGE_CHANNEL","MEDIAPACKAGE_ORIGIN_ENDPOINT","MEDIATAILOR_PLAYBACK_CONFIGURATION","S3_BUCKET"
            break
        }

        # Amazon.MediaLive.CloudWatchAlarmTemplateTreatMissingData
        {
            ($_ -eq "New-EMLCloudWatchAlarmTemplate/TreatMissingData") -Or
            ($_ -eq "Update-EMLCloudWatchAlarmTemplate/TreatMissingData")
        }
        {
            $v = "breaching","ignore","missing","notBreaching"
            break
        }

        # Amazon.MediaLive.ClusterType
        "New-EMLCluster/ClusterType"
        {
            $v = "ON_PREMISES"
            break
        }

        # Amazon.MediaLive.EventBridgeRuleTemplateEventType
        {
            ($_ -eq "New-EMLEventBridgeRuleTemplate/EventType") -Or
            ($_ -eq "Update-EMLEventBridgeRuleTemplate/EventType")
        }
        {
            $v = "MEDIACONNECT_ALERT","MEDIACONNECT_FLOW_STATUS_CHANGE","MEDIACONNECT_OUTPUT_HEALTH","MEDIACONNECT_SOURCE_HEALTH","MEDIALIVE_CHANNEL_ALERT","MEDIALIVE_CHANNEL_INPUT_CHANGE","MEDIALIVE_CHANNEL_STATE_CHANGE","MEDIALIVE_MULTIPLEX_ALERT","MEDIALIVE_MULTIPLEX_STATE_CHANGE","MEDIAPACKAGE_HARVEST_JOB_NOTIFICATION","MEDIAPACKAGE_INPUT_NOTIFICATION","MEDIAPACKAGE_KEY_PROVIDER_NOTIFICATION","SIGNAL_MAP_ACTIVE_ALARM"
            break
        }

        # Amazon.MediaLive.InputCodec
        {
            ($_ -eq "New-EMLChannel/InputSpecification_Codec") -Or
            ($_ -eq "Update-EMLChannel/InputSpecification_Codec")
        }
        {
            $v = "AVC","HEVC","MPEG2"
            break
        }

        # Amazon.MediaLive.InputDeviceCodec
        {
            ($_ -eq "Update-EMLInputDevice/HdDeviceSettings_Codec") -Or
            ($_ -eq "Update-EMLInputDevice/UhdDeviceSettings_Codec")
        }
        {
            $v = "AVC","HEVC"
            break
        }

        # Amazon.MediaLive.InputDeviceConfiguredInput
        {
            ($_ -eq "Update-EMLInputDevice/HdDeviceSettings_ConfiguredInput") -Or
            ($_ -eq "Update-EMLInputDevice/UhdDeviceSettings_ConfiguredInput")
        }
        {
            $v = "AUTO","HDMI","SDI"
            break
        }

        # Amazon.MediaLive.InputMaximumBitrate
        {
            ($_ -eq "New-EMLChannel/InputSpecification_MaximumBitrate") -Or
            ($_ -eq "Update-EMLChannel/InputSpecification_MaximumBitrate")
        }
        {
            $v = "MAX_10_MBPS","MAX_20_MBPS","MAX_50_MBPS"
            break
        }

        # Amazon.MediaLive.InputNetworkLocation
        "New-EMLInput/InputNetworkLocation"
        {
            $v = "AWS","ON_PREMISES"
            break
        }

        # Amazon.MediaLive.InputResolution
        {
            ($_ -eq "New-EMLChannel/InputSpecification_Resolution") -Or
            ($_ -eq "Update-EMLChannel/InputSpecification_Resolution")
        }
        {
            $v = "HD","SD","UHD"
            break
        }

        # Amazon.MediaLive.InputType
        "New-EMLInput/Type"
        {
            $v = "AWS_CDI","INPUT_DEVICE","MEDIACONNECT","MEDIACONNECT_ROUTER","MP4_FILE","MULTICAST","RTMP_PULL","RTMP_PUSH","RTP_PUSH","SDI","SMPTE_2110_RECEIVER_GROUP","SRT_CALLER","TS_FILE","UDP_PUSH","URL_PULL"
            break
        }

        # Amazon.MediaLive.LogLevel
        {
            ($_ -eq "New-EMLChannel/LogLevel") -Or
            ($_ -eq "Update-EMLChannel/LogLevel")
        }
        {
            $v = "DEBUG","DISABLED","ERROR","INFO","WARNING"
            break
        }

        # Amazon.MediaLive.MaintenanceDay
        {
            ($_ -eq "New-EMLChannel/Maintenance_MaintenanceDay") -Or
            ($_ -eq "Update-EMLChannel/Maintenance_MaintenanceDay")
        }
        {
            $v = "FRIDAY","MONDAY","SATURDAY","SUNDAY","THURSDAY","TUESDAY","WEDNESDAY"
            break
        }

        # Amazon.MediaLive.NodeRole
        {
            ($_ -eq "New-EMLNode/Role") -Or
            ($_ -eq "New-EMLNodeRegistrationScript/Role") -Or
            ($_ -eq "Update-EMLNode/Role")
        }
        {
            $v = "ACTIVE","BACKUP"
            break
        }

        # Amazon.MediaLive.PreferredChannelPipeline
        {
            ($_ -eq "New-EMLMultiplexProgram/MultiplexProgramSettings_PreferredChannelPipeline") -Or
            ($_ -eq "Update-EMLMultiplexProgram/MultiplexProgramSettings_PreferredChannelPipeline")
        }
        {
            $v = "CURRENTLY_ACTIVE","PIPELINE_0","PIPELINE_1"
            break
        }

        # Amazon.MediaLive.RebootInputDeviceForce
        "Restart-EMLInputDevice/IgnoreStreaming"
        {
            $v = "NO","YES"
            break
        }

        # Amazon.MediaLive.ReservationAutomaticRenewal
        {
            ($_ -eq "New-EMLOfferingPurchase/RenewalSettings_AutomaticRenewal") -Or
            ($_ -eq "Update-EMLReservation/RenewalSettings_AutomaticRenewal")
        }
        {
            $v = "DISABLED","ENABLED","UNAVAILABLE"
            break
        }

        # Amazon.MediaLive.RouterEncryptionType
        "New-EMLInput/RouterSettings_EncryptionType"
        {
            $v = "AUTOMATIC","SECRETS_MANAGER"
            break
        }

        # Amazon.MediaLive.SdiSourceMode
        {
            ($_ -eq "New-EMLSdiSource/Mode") -Or
            ($_ -eq "Update-EMLSdiSource/Mode")
        }
        {
            $v = "INTERLEAVE","QUADRANT"
            break
        }

        # Amazon.MediaLive.SdiSourceType
        {
            ($_ -eq "New-EMLSdiSource/Type") -Or
            ($_ -eq "Update-EMLSdiSource/Type")
        }
        {
            $v = "QUAD","SINGLE"
            break
        }

        # Amazon.MediaLive.UpdateNodeState
        "Update-EMLNodeState/State"
        {
            $v = "ACTIVE","DRAINING"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EML_map = @{
    "Accept"=@("Get-EMLInputDeviceThumbnail")
    "CdiInputSpecification_Resolution"=@("New-EMLChannel","Update-EMLChannel")
    "ChannelClass"=@("New-EMLChannel","Update-EMLChannelClass")
    "ClusterType"=@("New-EMLCluster")
    "ComparisonOperator"=@("New-EMLCloudWatchAlarmTemplate","Update-EMLCloudWatchAlarmTemplate")
    "EventType"=@("New-EMLEventBridgeRuleTemplate","Update-EMLEventBridgeRuleTemplate")
    "HdDeviceSettings_Codec"=@("Update-EMLInputDevice")
    "HdDeviceSettings_ConfiguredInput"=@("Update-EMLInputDevice")
    "IgnoreStreaming"=@("Restart-EMLInputDevice")
    "InputNetworkLocation"=@("New-EMLInput")
    "InputSpecification_Codec"=@("New-EMLChannel","Update-EMLChannel")
    "InputSpecification_MaximumBitrate"=@("New-EMLChannel","Update-EMLChannel")
    "InputSpecification_Resolution"=@("New-EMLChannel","Update-EMLChannel")
    "LogLevel"=@("New-EMLChannel","Update-EMLChannel")
    "Maintenance_MaintenanceDay"=@("New-EMLChannel","Update-EMLChannel")
    "Mode"=@("New-EMLSdiSource","Update-EMLSdiSource")
    "MultiplexProgramSettings_PreferredChannelPipeline"=@("New-EMLMultiplexProgram","Update-EMLMultiplexProgram")
    "RenewalSettings_AutomaticRenewal"=@("New-EMLOfferingPurchase","Update-EMLReservation")
    "Role"=@("New-EMLNode","New-EMLNodeRegistrationScript","Update-EMLNode")
    "RouterSettings_EncryptionType"=@("New-EMLInput")
    "State"=@("Update-EMLNodeState")
    "Statistic"=@("New-EMLCloudWatchAlarmTemplate","Update-EMLCloudWatchAlarmTemplate")
    "TargetResourceType"=@("New-EMLCloudWatchAlarmTemplate","Update-EMLCloudWatchAlarmTemplate")
    "TreatMissingData"=@("New-EMLCloudWatchAlarmTemplate","Update-EMLCloudWatchAlarmTemplate")
    "Type"=@("New-EMLInput","New-EMLSdiSource","Update-EMLSdiSource")
    "UhdDeviceSettings_Codec"=@("Update-EMLInputDevice")
    "UhdDeviceSettings_ConfiguredInput"=@("Update-EMLInputDevice")
}

_awsArgumentCompleterRegistration $EML_Completers $EML_map

$EML_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.EML.$($commandName.Replace('-', ''))Cmdlet]"
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

$EML_SelectMap = @{
    "Select"=@("Receive-EMLInputDeviceTransfer",
               "Remove-EMLResourceBatch",
               "Start-EMLResourceBatch",
               "Stop-EMLResourceBatch",
               "Update-EMLScheduleBatch",
               "Stop-EMLInputDeviceTransfer",
               "Request-EMLDevice",
               "New-EMLChannel",
               "New-EMLChannelPlacementGroup",
               "New-EMLCloudWatchAlarmTemplate",
               "New-EMLCloudWatchAlarmTemplateGroup",
               "New-EMLCluster",
               "New-EMLEventBridgeRuleTemplate",
               "New-EMLEventBridgeRuleTemplateGroup",
               "New-EMLInput",
               "New-EMLInputSecurityGroup",
               "New-EMLMultiplex",
               "New-EMLMultiplexProgram",
               "New-EMLNetwork",
               "New-EMLNode",
               "New-EMLNodeRegistrationScript",
               "New-EMLPartnerInput",
               "New-EMLSdiSource",
               "New-EMLSignalMap",
               "Add-EMLResourceTag",
               "Remove-EMLChannel",
               "Remove-EMLChannelPlacementGroup",
               "Remove-EMLCloudWatchAlarmTemplate",
               "Remove-EMLCloudWatchAlarmTemplateGroup",
               "Remove-EMLCluster",
               "Remove-EMLEventBridgeRuleTemplate",
               "Remove-EMLEventBridgeRuleTemplateGroup",
               "Remove-EMLInput",
               "Remove-EMLInputSecurityGroup",
               "Remove-EMLMultiplex",
               "Remove-EMLMultiplexProgram",
               "Remove-EMLNetwork",
               "Remove-EMLNode",
               "Remove-EMLReservation",
               "Remove-EMLSchedule",
               "Remove-EMLSdiSource",
               "Remove-EMLSignalMap",
               "Remove-EMLResourceTag",
               "Get-EMLAccountConfiguration",
               "Get-EMLChannel",
               "Get-EMLChannelPlacementGroup",
               "Get-EMLCluster",
               "Get-EMLInput",
               "Get-EMLInputDevice",
               "Get-EMLInputDeviceThumbnail",
               "Get-EMLInputSecurityGroup",
               "Get-EMLMultiplex",
               "Get-EMLMultiplexProgram",
               "Get-EMLNetwork",
               "Get-EMLNode",
               "Get-EMLOffering",
               "Get-EMLReservation",
               "Get-EMLSchedule",
               "Get-EMLSdiSource",
               "Get-EMLThumbnail",
               "Get-EMLCloudWatchAlarmTemplate",
               "Get-EMLCloudWatchAlarmTemplateGroup",
               "Get-EMLEventBridgeRuleTemplate",
               "Get-EMLEventBridgeRuleTemplateGroup",
               "Get-EMLSignalMap",
               "Get-EMLAlertList",
               "Get-EMLChannelPlacementGroupList",
               "Get-EMLChannelList",
               "Get-EMLCloudWatchAlarmTemplateGroupList",
               "Get-EMLCloudWatchAlarmTemplateList",
               "Get-EMLClusterAlertList",
               "Get-EMLClusterList",
               "Get-EMLEventBridgeRuleTemplateGroupList",
               "Get-EMLEventBridgeRuleTemplateList",
               "Get-EMLInputDeviceList",
               "Get-EMLInputDeviceTransferList",
               "Get-EMLInputList",
               "Get-EMLInputSecurityGroupList",
               "Get-EMLMultiplexAlertList",
               "Get-EMLMultiplexList",
               "Get-EMLMultiplexProgramList",
               "Get-EMLNetworkList",
               "Get-EMLNodeList",
               "Get-EMLOfferingList",
               "Get-EMLReservationList",
               "Get-EMLSdiSourceList",
               "Get-EMLSignalMapList",
               "Get-EMLResourceTag",
               "Get-EMLVersionList",
               "New-EMLOfferingPurchase",
               "Restart-EMLInputDevice",
               "Deny-EMLInputDeviceTransfer",
               "Restart-EMLChannelPipeline",
               "Start-EMLChannel",
               "Start-EMLDeleteMonitorDeployment",
               "Start-EMLInputDevice",
               "Start-EMLInputDeviceMaintenanceWindow",
               "Start-EMLMonitorDeployment",
               "Start-EMLMultiplex",
               "Start-EMLUpdateSignalMap",
               "Stop-EMLChannel",
               "Stop-EMLInputDevice",
               "Stop-EMLMultiplex",
               "Move-EMLInputDevice",
               "Update-EMLAccountConfiguration",
               "Update-EMLChannel",
               "Update-EMLChannelClass",
               "Update-EMLChannelPlacementGroup",
               "Update-EMLCloudWatchAlarmTemplate",
               "Update-EMLCloudWatchAlarmTemplateGroup",
               "Update-EMLCluster",
               "Update-EMLEventBridgeRuleTemplate",
               "Update-EMLEventBridgeRuleTemplateGroup",
               "Update-EMLInput",
               "Update-EMLInputDevice",
               "Update-EMLInputSecurityGroup",
               "Update-EMLMultiplex",
               "Update-EMLMultiplexProgram",
               "Update-EMLNetwork",
               "Update-EMLNode",
               "Update-EMLNodeState",
               "Update-EMLReservation",
               "Update-EMLSdiSource")
}

_awsArgumentCompleterRegistration $EML_SelectCompleters $EML_SelectMap

