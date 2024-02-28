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

        # Amazon.MediaConnect.DesiredState
        "Update-EMCNBridgeState/DesiredState"
        {
            $v = "ACTIVE","DELETED","STANDBY"
            break
        }

        # Amazon.MediaConnect.EntitlementStatus
        "Update-EMCNFlowEntitlement/EntitlementStatus"
        {
            $v = "DISABLED","ENABLED"
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

        # Amazon.MediaConnect.MaintenanceDay
        {
            ($_ -eq "New-EMCNFlow/Maintenance_MaintenanceDay") -Or
            ($_ -eq "Update-EMCNFlow/Maintenance_MaintenanceDay")
        }
        {
            $v = "Friday","Monday","Saturday","Sunday","Thursday","Tuesday","Wednesday"
            break
        }

        # Amazon.MediaConnect.MediaStreamType
        "Update-EMCNFlowMediaStream/MediaStreamType"
        {
            $v = "ancillary-data","audio","video"
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
            $v = "cdi","fujitsu-qos","rist","rtp","rtp-fec","srt-caller","srt-listener","st2110-jpegxs","udp","zixi-pull","zixi-push"
            break
        }

        # Amazon.MediaConnect.Range
        "Update-EMCNFlowMediaStream/Fmtp_Range"
        {
            $v = "FULL","FULLPROTECT","NARROW"
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


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EMCN_map = @{
    "BridgePlacement"=@("Update-EMCNGatewayInstance")
    "DesiredState"=@("Update-EMCNBridgeState")
    "EntitlementStatus"=@("Update-EMCNFlowEntitlement")
    "Fmtp_Colorimetry"=@("Update-EMCNFlowMediaStream")
    "Fmtp_Range"=@("Update-EMCNFlowMediaStream")
    "Fmtp_ScanMode"=@("Update-EMCNFlowMediaStream")
    "Fmtp_Tc"=@("Update-EMCNFlowMediaStream")
    "Maintenance_MaintenanceDay"=@("New-EMCNFlow","Update-EMCNFlow")
    "MediaStreamType"=@("Update-EMCNFlowMediaStream")
    "NetworkOutput_Protocol"=@("Update-EMCNBridgeOutput")
    "NetworkSource_Protocol"=@("Update-EMCNBridgeSource")
    "Protocol"=@("Update-EMCNFlowOutput","Update-EMCNFlowSource")
    "SourceFailoverConfig_FailoverMode"=@("New-EMCNBridge","New-EMCNFlow","Update-EMCNBridge","Update-EMCNFlow")
    "SourceFailoverConfig_State"=@("New-EMCNBridge","New-EMCNFlow","Update-EMCNBridge","Update-EMCNFlow")
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
               "New-EMCNBridge",
               "New-EMCNFlow",
               "New-EMCNGateway",
               "Remove-EMCNBridge",
               "Remove-EMCNFlow",
               "Remove-EMCNGateway",
               "Remove-EMCNGatewayInstance",
               "Get-EMCNBridge",
               "Get-EMCNFlow",
               "Get-EMCNFlowSourceMetadata",
               "Get-EMCNGateway",
               "Get-EMCNGatewayInstance",
               "Get-EMCNOffering",
               "Get-EMCNReservation",
               "Grant-EMCNFlowEntitlement",
               "Get-EMCNBridgeList",
               "Get-EMCNEntitlementList",
               "Get-EMCNFlowList",
               "Get-EMCNGatewayInstanceList",
               "Get-EMCNGatewayList",
               "Get-EMCNOfferingList",
               "Get-EMCNReservationList",
               "Get-EMCNResourceTag",
               "New-EMCNOffering",
               "Remove-EMCNBridgeOutput",
               "Remove-EMCNBridgeSource",
               "Remove-EMCNFlowMediaStream",
               "Remove-EMCNFlowOutput",
               "Remove-EMCNFlowSource",
               "Remove-EMCNFlowVpcInterface",
               "Revoke-EMCNFlowEntitlement",
               "Start-EMCNFlow",
               "Stop-EMCNFlow",
               "Add-EMCNResourceTag",
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
               "Update-EMCNGatewayInstance")
}

_awsArgumentCompleterRegistration $EMCN_SelectCompleters $EMCN_SelectMap

