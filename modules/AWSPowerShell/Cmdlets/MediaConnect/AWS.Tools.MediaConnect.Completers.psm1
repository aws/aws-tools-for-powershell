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

# Argument completions for service AWS Elemental MediaConnect


$EMCN_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.MediaConnect.BridgePlacement
        "Update-EMCNGatewayInstance/BridgePlacement"
        {
            $v = "AVAILABLE","LOCKED"
            break
        }

        # Amazon.MediaConnect.Colorimetry
        "Update-EMCNFlowMediaStream/Fmtp_Colorimetry"
        {
            $v = "BT2020","BT2100","BT601","BT709","ST2065-1","ST2065-3","XYZ"
            break
        }

        # Amazon.MediaConnect.ContentQualityAnalysisState
        {
            ($_ -eq "New-EMCNFlow/SourceMonitoringConfig_ContentQualityAnalysisState") -Or
            ($_ -eq "Update-EMCNFlow/SourceMonitoringConfig_ContentQualityAnalysisState")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.MediaConnect.Day
        {
            ($_ -eq "New-EMCNRouterInput/PreferredDayTime_Day") -Or
            ($_ -eq "New-EMCNRouterOutput/PreferredDayTime_Day") -Or
            ($_ -eq "Update-EMCNRouterInput/PreferredDayTime_Day") -Or
            ($_ -eq "Update-EMCNRouterOutput/PreferredDayTime_Day")
        }
        {
            $v = "FRIDAY","MONDAY","SATURDAY","SUNDAY","THURSDAY","TUESDAY","WEDNESDAY"
            break
        }

        # Amazon.MediaConnect.DesiredState
        "Update-EMCNBridgeState/DesiredState"
        {
            $v = "ACTIVE","DELETED","STANDBY"
            break
        }

        # Amazon.MediaConnect.EncodingProfile
        {
            ($_ -eq "New-EMCNFlow/EncodingConfig_EncodingProfile") -Or
            ($_ -eq "Update-EMCNFlow/EncodingConfig_EncodingProfile")
        }
        {
            $v = "CONTRIBUTION_H264_DEFAULT","DISTRIBUTION_H264_DEFAULT"
            break
        }

        # Amazon.MediaConnect.EntitlementStatus
        "Update-EMCNFlowEntitlement/EntitlementStatus"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.MediaConnect.FailoverInputSourcePriorityMode
        {
            ($_ -eq "New-EMCNRouterInput/Failover_SourcePriorityMode") -Or
            ($_ -eq "Update-EMCNRouterInput/Failover_SourcePriorityMode")
        }
        {
            $v = "NO_PRIORITY","PRIMARY_SECONDARY"
            break
        }

        # Amazon.MediaConnect.FailoverMode
        {
            ($_ -eq "New-EMCNBridge/SourceFailoverConfig_FailoverMode") -Or
            ($_ -eq "New-EMCNFlow/SourceFailoverConfig_FailoverMode") -Or
            ($_ -eq "Update-EMCNBridge/SourceFailoverConfig_FailoverMode") -Or
            ($_ -eq "Update-EMCNFlow/SourceFailoverConfig_FailoverMode")
        }
        {
            $v = "FAILOVER","MERGE"
            break
        }

        # Amazon.MediaConnect.FlowSize
        {
            ($_ -eq "New-EMCNFlow/FlowSize") -Or
            ($_ -eq "Update-EMCNFlow/FlowSize")
        }
        {
            $v = "LARGE","LARGE_4X","MEDIUM"
            break
        }

        # Amazon.MediaConnect.FlowTransitEncryptionKeyType
        {
            ($_ -eq "New-EMCNRouterOutput/MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyType") -Or
            ($_ -eq "Update-EMCNRouterOutput/MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyType") -Or
            ($_ -eq "Update-EMCNFlowSource/RouterIntegrationTransitDecryption_EncryptionKeyType") -Or
            ($_ -eq "Update-EMCNFlowOutput/RouterIntegrationTransitEncryption_EncryptionKeyType") -Or
            ($_ -eq "New-EMCNRouterInput/SourceTransitDecryption_EncryptionKeyType") -Or
            ($_ -eq "Update-EMCNRouterInput/SourceTransitDecryption_EncryptionKeyType")
        }
        {
            $v = "AUTOMATIC","SECRETS_MANAGER"
            break
        }

        # Amazon.MediaConnect.ForwardErrorCorrectionState
        {
            ($_ -eq "New-EMCNRouterInput/Rtp_ForwardErrorCorrection") -Or
            ($_ -eq "New-EMCNRouterOutput/Rtp_ForwardErrorCorrection") -Or
            ($_ -eq "Update-EMCNRouterInput/Rtp_ForwardErrorCorrection") -Or
            ($_ -eq "Update-EMCNRouterOutput/Rtp_ForwardErrorCorrection")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.MediaConnect.MaintenanceDay
        {
            ($_ -eq "New-EMCNFlow/Maintenance_MaintenanceDay") -Or
            ($_ -eq "Update-EMCNFlow/Maintenance_MaintenanceDay")
        }
        {
            $v = "Friday","Monday","Saturday","Sunday","Thursday","Tuesday","Wednesday"
            break
        }

        # Amazon.MediaConnect.MediaLiveInputPipelineId
        {
            ($_ -eq "New-EMCNRouterOutput/MediaLiveInput_MediaLivePipelineId") -Or
            ($_ -eq "Update-EMCNRouterOutput/MediaLiveInput_MediaLivePipelineId")
        }
        {
            $v = "PIPELINE_0","PIPELINE_1"
            break
        }

        # Amazon.MediaConnect.MediaLiveTransitEncryptionKeyType
        {
            ($_ -eq "New-EMCNRouterOutput/MediaLiveInput_DestinationTransitEncryption_EncryptionKeyType") -Or
            ($_ -eq "Update-EMCNRouterOutput/MediaLiveInput_DestinationTransitEncryption_EncryptionKeyType")
        }
        {
            $v = "AUTOMATIC","SECRETS_MANAGER"
            break
        }

        # Amazon.MediaConnect.MediaStreamType
        "Update-EMCNFlowMediaStream/MediaStreamType"
        {
            $v = "ancillary-data","audio","video"
            break
        }

        # Amazon.MediaConnect.NdiState
        {
            ($_ -eq "New-EMCNFlow/NdiConfig_NdiState") -Or
            ($_ -eq "Update-EMCNFlow/NdiConfig_NdiState")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.MediaConnect.OutputStatus
        "Update-EMCNFlowOutput/OutputStatus"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.MediaConnect.Protocol
        {
            ($_ -eq "Update-EMCNBridgeOutput/NetworkOutput_Protocol") -Or
            ($_ -eq "Update-EMCNBridgeSource/NetworkSource_Protocol") -Or
            ($_ -eq "Update-EMCNFlowOutput/Protocol") -Or
            ($_ -eq "Update-EMCNFlowSource/Protocol")
        }
        {
            $v = "cdi","fujitsu-qos","ndi-speed-hq","rist","rtp","rtp-fec","srt-caller","srt-listener","st2110-jpegxs","udp","zixi-pull","zixi-push"
            break
        }

        # Amazon.MediaConnect.Range
        "Update-EMCNFlowMediaStream/Fmtp_Range"
        {
            $v = "FULL","FULLPROTECT","NARROW"
            break
        }

        # Amazon.MediaConnect.RouterInputProtocol
        {
            ($_ -eq "New-EMCNRouterInput/Standard_Protocol") -Or
            ($_ -eq "Update-EMCNRouterInput/Standard_Protocol")
        }
        {
            $v = "RIST","RTP","SRT_CALLER","SRT_LISTENER"
            break
        }

        # Amazon.MediaConnect.RouterInputTier
        {
            ($_ -eq "New-EMCNRouterInput/Tier") -Or
            ($_ -eq "Update-EMCNRouterInput/Tier")
        }
        {
            $v = "INPUT_100","INPUT_20","INPUT_50"
            break
        }

        # Amazon.MediaConnect.RouterInputTransitEncryptionKeyType
        {
            ($_ -eq "New-EMCNRouterInput/TransitEncryption_EncryptionKeyType") -Or
            ($_ -eq "Update-EMCNRouterInput/TransitEncryption_EncryptionKeyType")
        }
        {
            $v = "AUTOMATIC","SECRETS_MANAGER"
            break
        }

        # Amazon.MediaConnect.RouterOutputProtocol
        {
            ($_ -eq "New-EMCNRouterOutput/Standard_Protocol") -Or
            ($_ -eq "Update-EMCNRouterOutput/Standard_Protocol")
        }
        {
            $v = "RIST","RTP","SRT_CALLER","SRT_LISTENER"
            break
        }

        # Amazon.MediaConnect.RouterOutputTier
        {
            ($_ -eq "New-EMCNRouterOutput/Tier") -Or
            ($_ -eq "Update-EMCNRouterOutput/Tier")
        }
        {
            $v = "OUTPUT_100","OUTPUT_20","OUTPUT_50"
            break
        }

        # Amazon.MediaConnect.RoutingScope
        {
            ($_ -eq "New-EMCNRouterInput/RoutingScope") -Or
            ($_ -eq "New-EMCNRouterOutput/RoutingScope") -Or
            ($_ -eq "Update-EMCNRouterInput/RoutingScope") -Or
            ($_ -eq "Update-EMCNRouterOutput/RoutingScope")
        }
        {
            $v = "GLOBAL","REGIONAL"
            break
        }

        # Amazon.MediaConnect.ScanMode
        "Update-EMCNFlowMediaStream/Fmtp_ScanMode"
        {
            $v = "interlace","progressive","progressive-segmented-frame"
            break
        }

        # Amazon.MediaConnect.State
        {
            ($_ -eq "Update-EMCNFlowOutput/RouterIntegrationState") -Or
            ($_ -eq "Update-EMCNFlowSource/RouterIntegrationState") -Or
            ($_ -eq "New-EMCNBridge/SourceFailoverConfig_State") -Or
            ($_ -eq "New-EMCNFlow/SourceFailoverConfig_State") -Or
            ($_ -eq "Update-EMCNBridge/SourceFailoverConfig_State") -Or
            ($_ -eq "Update-EMCNFlow/SourceFailoverConfig_State")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.MediaConnect.Tcs
        "Update-EMCNFlowMediaStream/Fmtp_Tc"
        {
            $v = "BT2100LINHLG","BT2100LINPQ","DENSITY","HLG","LINEAR","PQ","SDR","ST2065-1","ST428-1"
            break
        }

        # Amazon.MediaConnect.ThumbnailState
        {
            ($_ -eq "New-EMCNFlow/SourceMonitoringConfig_ThumbnailState") -Or
            ($_ -eq "Update-EMCNFlow/SourceMonitoringConfig_ThumbnailState")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EMCN_map = @{
    "BridgePlacement"=@("Update-EMCNGatewayInstance")
    "DesiredState"=@("Update-EMCNBridgeState")
    "EncodingConfig_EncodingProfile"=@("New-EMCNFlow","Update-EMCNFlow")
    "EntitlementStatus"=@("Update-EMCNFlowEntitlement")
    "Failover_SourcePriorityMode"=@("New-EMCNRouterInput","Update-EMCNRouterInput")
    "FlowSize"=@("New-EMCNFlow","Update-EMCNFlow")
    "Fmtp_Colorimetry"=@("Update-EMCNFlowMediaStream")
    "Fmtp_Range"=@("Update-EMCNFlowMediaStream")
    "Fmtp_ScanMode"=@("Update-EMCNFlowMediaStream")
    "Fmtp_Tc"=@("Update-EMCNFlowMediaStream")
    "Maintenance_MaintenanceDay"=@("New-EMCNFlow","Update-EMCNFlow")
    "MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyType"=@("New-EMCNRouterOutput","Update-EMCNRouterOutput")
    "MediaLiveInput_DestinationTransitEncryption_EncryptionKeyType"=@("New-EMCNRouterOutput","Update-EMCNRouterOutput")
    "MediaLiveInput_MediaLivePipelineId"=@("New-EMCNRouterOutput","Update-EMCNRouterOutput")
    "MediaStreamType"=@("Update-EMCNFlowMediaStream")
    "NdiConfig_NdiState"=@("New-EMCNFlow","Update-EMCNFlow")
    "NetworkOutput_Protocol"=@("Update-EMCNBridgeOutput")
    "NetworkSource_Protocol"=@("Update-EMCNBridgeSource")
    "OutputStatus"=@("Update-EMCNFlowOutput")
    "PreferredDayTime_Day"=@("New-EMCNRouterInput","New-EMCNRouterOutput","Update-EMCNRouterInput","Update-EMCNRouterOutput")
    "Protocol"=@("Update-EMCNFlowOutput","Update-EMCNFlowSource")
    "RouterIntegrationState"=@("Update-EMCNFlowOutput","Update-EMCNFlowSource")
    "RouterIntegrationTransitDecryption_EncryptionKeyType"=@("Update-EMCNFlowSource")
    "RouterIntegrationTransitEncryption_EncryptionKeyType"=@("Update-EMCNFlowOutput")
    "RoutingScope"=@("New-EMCNRouterInput","New-EMCNRouterOutput","Update-EMCNRouterInput","Update-EMCNRouterOutput")
    "Rtp_ForwardErrorCorrection"=@("New-EMCNRouterInput","New-EMCNRouterOutput","Update-EMCNRouterInput","Update-EMCNRouterOutput")
    "SourceFailoverConfig_FailoverMode"=@("New-EMCNBridge","New-EMCNFlow","Update-EMCNBridge","Update-EMCNFlow")
    "SourceFailoverConfig_State"=@("New-EMCNBridge","New-EMCNFlow","Update-EMCNBridge","Update-EMCNFlow")
    "SourceMonitoringConfig_ContentQualityAnalysisState"=@("New-EMCNFlow","Update-EMCNFlow")
    "SourceMonitoringConfig_ThumbnailState"=@("New-EMCNFlow","Update-EMCNFlow")
    "SourceTransitDecryption_EncryptionKeyType"=@("New-EMCNRouterInput","Update-EMCNRouterInput")
    "Standard_Protocol"=@("New-EMCNRouterInput","New-EMCNRouterOutput","Update-EMCNRouterInput","Update-EMCNRouterOutput")
    "Tier"=@("New-EMCNRouterInput","New-EMCNRouterOutput","Update-EMCNRouterInput","Update-EMCNRouterOutput")
    "TransitEncryption_EncryptionKeyType"=@("New-EMCNRouterInput","Update-EMCNRouterInput")
}

_awsArgumentCompleterRegistration $EMCN_Completers $EMCN_map

$EMCN_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.EMCN.$($commandName.Replace('-', ''))Cmdlet]"
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

$EMCN_SelectMap = @{
    "Select"=@("Add-EMCNBridgeOutput",
               "Add-EMCNBridgeSource",
               "Add-EMCNFlowMediaStream",
               "Add-EMCNFlowOutput",
               "Add-EMCNFlowSource",
               "Add-EMCNFlowVpcInterface",
               "Get-EMCNBatchRouterInput",
               "Get-EMCNBatchRouterNetworkInterface",
               "Get-EMCNBatchRouterOutput",
               "New-EMCNBridge",
               "New-EMCNFlow",
               "New-EMCNGateway",
               "New-EMCNRouterInput",
               "New-EMCNRouterNetworkInterface",
               "New-EMCNRouterOutput",
               "Remove-EMCNBridge",
               "Remove-EMCNFlow",
               "Remove-EMCNGateway",
               "Remove-EMCNRouterInput",
               "Remove-EMCNRouterNetworkInterface",
               "Remove-EMCNRouterOutput",
               "Remove-EMCNGatewayInstance",
               "Get-EMCNBridge",
               "Get-EMCNFlow",
               "Get-EMCNFlowSourceMetadata",
               "Get-EMCNFlowSourceThumbnail",
               "Get-EMCNGateway",
               "Get-EMCNGatewayInstance",
               "Get-EMCNOffering",
               "Get-EMCNReservation",
               "Get-EMCNRouterInput",
               "Get-EMCNRouterInputSourceMetadata",
               "Get-EMCNRouterInputThumbnail",
               "Get-EMCNRouterNetworkInterface",
               "Get-EMCNRouterOutput",
               "Grant-EMCNFlowEntitlement",
               "Get-EMCNBridgeList",
               "Get-EMCNEntitlementList",
               "Get-EMCNFlowList",
               "Get-EMCNGatewayInstanceList",
               "Get-EMCNGatewayList",
               "Get-EMCNOfferingList",
               "Get-EMCNReservationList",
               "Get-EMCNRouterInputList",
               "Get-EMCNRouterNetworkInterfaceList",
               "Get-EMCNRouterOutputList",
               "Get-EMCNTagsForGlobalResourceList",
               "Get-EMCNResourceTag",
               "New-EMCNOffering",
               "Remove-EMCNBridgeOutput",
               "Remove-EMCNBridgeSource",
               "Remove-EMCNFlowMediaStream",
               "Remove-EMCNFlowOutput",
               "Remove-EMCNFlowSource",
               "Remove-EMCNFlowVpcInterface",
               "Restart-EMCNRouterInput",
               "Restart-EMCNRouterOutput",
               "Revoke-EMCNFlowEntitlement",
               "Start-EMCNFlow",
               "Start-EMCNRouterInput",
               "Start-EMCNRouterOutput",
               "Stop-EMCNFlow",
               "Stop-EMCNRouterInput",
               "Stop-EMCNRouterOutput",
               "Add-EMCNTagGlobalResource",
               "Add-EMCNResourceTag",
               "Set-EMCNRouterInput",
               "Remove-EMCNTagGlobalResource",
               "Remove-EMCNResourceTag",
               "Update-EMCNBridge",
               "Update-EMCNBridgeOutput",
               "Update-EMCNBridgeSource",
               "Update-EMCNBridgeState",
               "Update-EMCNFlow",
               "Update-EMCNFlowEntitlement",
               "Update-EMCNFlowMediaStream",
               "Update-EMCNFlowOutput",
               "Update-EMCNFlowSource",
               "Update-EMCNGatewayInstance",
               "Update-EMCNRouterInput",
               "Update-EMCNRouterNetworkInterface",
               "Update-EMCNRouterOutput")
}

_awsArgumentCompleterRegistration $EMCN_SelectCompleters $EMCN_SelectMap

