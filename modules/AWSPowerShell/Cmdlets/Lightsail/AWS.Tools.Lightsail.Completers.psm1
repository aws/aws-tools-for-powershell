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

# Argument completions for service Amazon Lightsail


$LS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Lightsail.AddOnType
        {
            ($_ -eq "Enable-LSAddOn/AddOnRequest_AddOnType") -Or
            ($_ -eq "Disable-LSAddOn/AddOnType")
        }
        {
            $v = "AutoSnapshot"
            break
        }

        # Amazon.Lightsail.InstanceAccessProtocol
        "Get-LSInstanceAccessDetail/Protocol"
        {
            $v = "rdp","ssh"
            break
        }

        # Amazon.Lightsail.InstanceMetricName
        "Get-LSInstanceMetricData/MetricName"
        {
            $v = "CPUUtilization","NetworkIn","NetworkOut","StatusCheckFailed","StatusCheckFailed_Instance","StatusCheckFailed_System"
            break
        }

        # Amazon.Lightsail.LoadBalancerAttributeName
        "Update-LSLoadBalancerAttribute/AttributeName"
        {
            $v = "HealthCheckPath","SessionStickinessEnabled","SessionStickiness_LB_CookieDurationSeconds"
            break
        }

        # Amazon.Lightsail.LoadBalancerMetricName
        "Get-LSLoadBalancerMetricData/MetricName"
        {
            $v = "ClientTLSNegotiationErrorCount","HealthyHostCount","HTTPCode_Instance_2XX_Count","HTTPCode_Instance_3XX_Count","HTTPCode_Instance_4XX_Count","HTTPCode_Instance_5XX_Count","HTTPCode_LB_4XX_Count","HTTPCode_LB_5XX_Count","InstanceResponseTime","RejectedConnectionCount","RequestCount","UnhealthyHostCount"
            break
        }

        # Amazon.Lightsail.MetricUnit
        {
            ($_ -eq "Get-LSInstanceMetricData/Unit") -Or
            ($_ -eq "Get-LSLoadBalancerMetricData/Unit") -Or
            ($_ -eq "Get-LSRelationalDatabaseMetricData/Unit")
        }
        {
            $v = "Bits","Bits/Second","Bytes","Bytes/Second","Count","Count/Second","Gigabits","Gigabits/Second","Gigabytes","Gigabytes/Second","Kilobits","Kilobits/Second","Kilobytes","Kilobytes/Second","Megabits","Megabits/Second","Megabytes","Megabytes/Second","Microseconds","Milliseconds","None","Percent","Seconds","Terabits","Terabits/Second","Terabytes","Terabytes/Second"
            break
        }

        # Amazon.Lightsail.NetworkProtocol
        {
            ($_ -eq "Close-LSInstancePublicPort/PortInfo_Protocol") -Or
            ($_ -eq "Open-LSInstancePublicPort/PortInfo_Protocol")
        }
        {
            $v = "all","tcp","udp"
            break
        }

        # Amazon.Lightsail.RegionName
        "Copy-LSSnapshot/SourceRegion"
        {
            $v = "ap-northeast-1","ap-northeast-2","ap-south-1","ap-southeast-1","ap-southeast-2","ca-central-1","eu-central-1","eu-west-1","eu-west-2","eu-west-3","us-east-1","us-east-2","us-west-1","us-west-2"
            break
        }

        # Amazon.Lightsail.RelationalDatabaseMetricName
        "Get-LSRelationalDatabaseMetricData/MetricName"
        {
            $v = "CPUUtilization","DatabaseConnections","DiskQueueDepth","FreeStorageSpace","NetworkReceiveThroughput","NetworkTransmitThroughput"
            break
        }

        # Amazon.Lightsail.RelationalDatabasePasswordVersion
        "Get-LSRelationalDatabaseMasterUserPassword/PasswordVersion"
        {
            $v = "CURRENT","PENDING","PREVIOUS"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$LS_map = @{
    "AddOnRequest_AddOnType"=@("Enable-LSAddOn")
    "AddOnType"=@("Disable-LSAddOn")
    "AttributeName"=@("Update-LSLoadBalancerAttribute")
    "MetricName"=@("Get-LSInstanceMetricData","Get-LSLoadBalancerMetricData","Get-LSRelationalDatabaseMetricData")
    "PasswordVersion"=@("Get-LSRelationalDatabaseMasterUserPassword")
    "PortInfo_Protocol"=@("Close-LSInstancePublicPort","Open-LSInstancePublicPort")
    "Protocol"=@("Get-LSInstanceAccessDetail")
    "SourceRegion"=@("Copy-LSSnapshot")
    "Unit"=@("Get-LSInstanceMetricData","Get-LSLoadBalancerMetricData","Get-LSRelationalDatabaseMetricData")
}

_awsArgumentCompleterRegistration $LS_Completers $LS_map

$LS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.LS.$($commandName.Replace('-', ''))Cmdlet]"
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

$LS_SelectMap = @{
    "Select"=@("New-LSStaticIp",
               "Add-LSDisk",
               "Add-LSInstancesToLoadBalancer",
               "Add-LSLoadBalancerTlsCertificate",
               "Mount-LSStaticIp",
               "Close-LSInstancePublicPort",
               "Copy-LSSnapshot",
               "New-LSCloudFormationStack",
               "New-LSDisk",
               "New-LSDiskFromSnapshot",
               "New-LSDiskSnapshot",
               "New-LSDomain",
               "New-LSDomainEntry",
               "New-LSInstance",
               "New-LSInstancesFromSnapshot",
               "New-LSInstanceSnapshot",
               "New-LSKeyPair",
               "New-LSLoadBalancer",
               "New-LSLoadBalancerTlsCertificate",
               "New-LSRelationalDatabase",
               "New-LSRelationalDatabaseFromSnapshot",
               "New-LSRelationalDatabaseSnapshot",
               "Remove-LSAutoSnapshot",
               "Remove-LSDisk",
               "Remove-LSDiskSnapshot",
               "Remove-LSDomain",
               "Remove-LSDomainEntry",
               "Remove-LSInstance",
               "Remove-LSInstanceSnapshot",
               "Remove-LSKeyPair",
               "Remove-LSKnownHostKey",
               "Remove-LSLoadBalancer",
               "Remove-LSLoadBalancerTlsCertificate",
               "Remove-LSRelationalDatabase",
               "Remove-LSRelationalDatabaseSnapshot",
               "Dismount-LSDisk",
               "Dismount-LSInstancesFromLoadBalancer",
               "Dismount-LSStaticIp",
               "Disable-LSAddOn",
               "Read-LSDefaultKeyPair",
               "Enable-LSAddOn",
               "Export-LSSnapshot",
               "Get-LSActiveNameList",
               "Get-LSAutoSnapshot",
               "Get-LSBlueprintList",
               "Get-LSBundleList",
               "Get-LSCloudFormationStackRecord",
               "Get-LSDisk",
               "Get-LSDiskList",
               "Get-LSDiskSnapshot",
               "Get-LSDiskSnapshotList",
               "Get-LSDomain",
               "Get-LSDomainList",
               "Get-LSExportSnapshotRecord",
               "Get-LSInstance",
               "Get-LSInstanceAccessDetail",
               "Get-LSInstanceMetricData",
               "Get-LSInstancePortStateList",
               "Get-LSInstanceList",
               "Get-LSInstanceSnapshot",
               "Get-LSInstanceSnapshotList",
               "Get-LSInstanceState",
               "Get-LSKeyPairInfo",
               "Get-LSKeypairList",
               "Get-LSLoadBalancer",
               "Get-LSLoadBalancerMetricData",
               "Get-LSLoadBalancerList",
               "Get-LSLoadBalancerTlsCertificate",
               "Get-LSOperation",
               "Get-LSOperationList",
               "Get-LSOperationListForResource",
               "Get-LSRegionList",
               "Get-LSRelationalDatabase",
               "Get-LSRelationalDatabaseBlueprint",
               "Get-LSRelationalDatabaseBundle",
               "Get-LSRelationalDatabaseEvent",
               "Get-LSRelationalDatabaseLogEvent",
               "Get-LSRelationalDatabaseLogStream",
               "Get-LSRelationalDatabaseMasterUserPassword",
               "Get-LSRelationalDatabaseMetricData",
               "Get-LSRelationalDatabaseParameter",
               "Get-LSRelationalDatabaseList",
               "Get-LSRelationalDatabaseSnapshot",
               "Get-LSRelationalDatabaseSnapshotList",
               "Get-LSStaticIp",
               "Get-LSStaticIpList",
               "Import-LSKeyPair",
               "Test-LSVpcPeered",
               "Open-LSInstancePublicPort",
               "Add-LSPeerVpc",
               "Set-LSInstancePublicPort",
               "Restart-LSInstance",
               "Restart-LSRelationalDatabase",
               "Remove-LSStaticIp",
               "Start-LSInstance",
               "Start-LSRelationalDatabase",
               "Stop-LSInstance",
               "Stop-LSRelationalDatabase",
               "Add-LSResourceTag",
               "Remove-LSPeerVpc",
               "Remove-LSResourceTag",
               "Update-LSDomainEntry",
               "Update-LSLoadBalancerAttribute",
               "Update-LSRelationalDatabase",
               "Update-LSRelationalDatabaseParameter")
}

_awsArgumentCompleterRegistration $LS_SelectCompleters $LS_SelectMap

