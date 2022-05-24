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

# Argument completions for service AWS Network Manager


$NMGR_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.NetworkManager.AttachmentState
        "Get-NMGRAttachmentList/State"
        {
            $v = "AVAILABLE","CREATING","DELETING","FAILED","PENDING_ATTACHMENT_ACCEPTANCE","PENDING_NETWORK_UPDATE","PENDING_TAG_ACCEPTANCE","REJECTED","UPDATING"
            break
        }

        # Amazon.NetworkManager.AttachmentType
        "Get-NMGRAttachmentList/AttachmentType"
        {
            $v = "CONNECT","SITE_TO_SITE_VPN","VPC"
            break
        }

        # Amazon.NetworkManager.CoreNetworkPolicyAlias
        "Get-NMGRCoreNetworkPolicy/Alias"
        {
            $v = "LATEST","LIVE"
            break
        }

        # Amazon.NetworkManager.TunnelProtocol
        "New-NMGRConnectAttachment/Options_Protocol"
        {
            $v = "GRE"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$NMGR_map = @{
    "Alias"=@("Get-NMGRCoreNetworkPolicy")
    "AttachmentType"=@("Get-NMGRAttachmentList")
    "Options_Protocol"=@("New-NMGRConnectAttachment")
    "State"=@("Get-NMGRAttachmentList")
}

_awsArgumentCompleterRegistration $NMGR_Completers $NMGR_map

$NMGR_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.NMGR.$($commandName.Replace('-', ''))Cmdlet]"
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

$NMGR_SelectMap = @{
    "Select"=@("Confirm-NMGRAttachment",
               "Add-NMGRConnectPeerAssociation",
               "Register-NMGRCustomerGateway",
               "Register-NMGRLink",
               "Register-NMGRTransitGatewayConnectPeer",
               "New-NMGRConnectAttachment",
               "New-NMGRConnection",
               "New-NMGRConnectPeer",
               "New-NMGRCoreNetwork",
               "New-NMGRDevice",
               "New-NMGRGlobalNetwork",
               "New-NMGRLink",
               "New-NMGRSite",
               "New-NMGRSiteToSiteVpnAttachment",
               "New-NMGRVpcAttachment",
               "Remove-NMGRAttachment",
               "Remove-NMGRConnection",
               "Remove-NMGRConnectPeer",
               "Remove-NMGRCoreNetwork",
               "Remove-NMGRCoreNetworkPolicyVersion",
               "Remove-NMGRDevice",
               "Remove-NMGRGlobalNetwork",
               "Remove-NMGRLink",
               "Remove-NMGRResourcePolicy",
               "Remove-NMGRSite",
               "Unregister-NMGRTransitGateway",
               "Get-NMGRGlobalNetwork",
               "Remove-NMGRConnectPeerAssociation",
               "Unregister-NMGRCustomerGateway",
               "Unregister-NMGRLink",
               "Unregister-NMGRTransitGatewayConnectPeer",
               "Enable-NMGRCoreNetworkChangeSet",
               "Get-NMGRConnectAttachment",
               "Get-NMGRConnection",
               "Get-NMGRConnectPeer",
               "Get-NMGRConnectPeerAssociation",
               "Get-NMGRCoreNetwork",
               "Get-NMGRCoreNetworkChangeSet",
               "Get-NMGRCoreNetworkPolicy",
               "Get-NMGRCustomerGatewayAssociation",
               "Get-NMGRDevice",
               "Get-NMGRLinkAssociation",
               "Get-NMGRLink",
               "Get-NMGRNetworkResourceCount",
               "Get-NMGRNetworkResourceRelationship",
               "Get-NMGRNetworkResource",
               "Get-NMGRNetworkRoute",
               "Get-NMGRNetworkTelemetry",
               "Get-NMGRResourcePolicy",
               "Get-NMGRRouteAnalysis",
               "Get-NMGRSite",
               "Get-NMGRSiteToSiteVpnAttachment",
               "Get-NMGRTransitGatewayConnectPeerAssociation",
               "Get-NMGRTransitGatewayRegistration",
               "Get-NMGRVpcAttachment",
               "Get-NMGRAttachmentList",
               "Get-NMGRConnectPeerList",
               "Get-NMGRCoreNetworkPolicyVersionList",
               "Get-NMGRCoreNetworkList",
               "Get-NMGROrganizationServiceAccessStatusList",
               "Get-NMGRResourceTag",
               "Write-NMGRCoreNetworkPolicy",
               "Write-NMGRResourcePolicy",
               "Register-NMGRTransitGateway",
               "Deny-NMGRAttachment",
               "Restore-NMGRCoreNetworkPolicyVersion",
               "Start-NMGROrganizationServiceAccessUpdate",
               "Start-NMGRRouteAnalysis",
               "Add-NMGRResourceTag",
               "Remove-NMGRResourceTag",
               "Update-NMGRConnection",
               "Update-NMGRCoreNetwork",
               "Update-NMGRDevice",
               "Update-NMGRGlobalNetwork",
               "Update-NMGRLink",
               "Update-NMGRNetworkResourceMetadata",
               "Update-NMGRSite",
               "Update-NMGRVpcAttachment")
}

_awsArgumentCompleterRegistration $NMGR_SelectCompleters $NMGR_SelectMap

