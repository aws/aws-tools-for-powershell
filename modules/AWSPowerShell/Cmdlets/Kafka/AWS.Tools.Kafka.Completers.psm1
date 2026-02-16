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

# Argument completions for service Amazon Managed Streaming for Apache Kafka (MSK)


$MSK_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Kafka.ClientBroker
        {
            ($_ -eq "New-MSKCluster/EncryptionInTransit_ClientBroker") -Or
            ($_ -eq "New-MSKClusterV2/EncryptionInTransit_ClientBroker") -Or
            ($_ -eq "Update-MSKSecurity/EncryptionInTransit_ClientBroker")
        }
        {
            $v = "PLAINTEXT","TLS","TLS_PLAINTEXT"
            break
        }

        # Amazon.Kafka.EnhancedMonitoring
        {
            ($_ -eq "New-MSKCluster/EnhancedMonitoring") -Or
            ($_ -eq "Update-MSKMonitoring/EnhancedMonitoring") -Or
            ($_ -eq "New-MSKClusterV2/Provisioned_EnhancedMonitoring")
        }
        {
            $v = "DEFAULT","PER_BROKER","PER_TOPIC_PER_BROKER","PER_TOPIC_PER_PARTITION"
            break
        }

        # Amazon.Kafka.NetworkType
        "Update-MSKConnectivity/ConnectivityInfo_NetworkType"
        {
            $v = "DUAL","IPV4"
            break
        }

        # Amazon.Kafka.RebalancingStatus
        {
            ($_ -eq "New-MSKCluster/Rebalancing_Status") -Or
            ($_ -eq "New-MSKClusterV2/Rebalancing_Status") -Or
            ($_ -eq "Update-MSKRebalancing/Rebalancing_Status")
        }
        {
            $v = "ACTIVE","PAUSED"
            break
        }

        # Amazon.Kafka.StorageMode
        {
            ($_ -eq "New-MSKClusterV2/Provisioned_StorageMode") -Or
            ($_ -eq "New-MSKCluster/StorageMode") -Or
            ($_ -eq "Update-MSKStorage/StorageMode")
        }
        {
            $v = "LOCAL","TIERED"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$MSK_map = @{
    "ConnectivityInfo_NetworkType"=@("Update-MSKConnectivity")
    "EncryptionInTransit_ClientBroker"=@("New-MSKCluster","New-MSKClusterV2","Update-MSKSecurity")
    "EnhancedMonitoring"=@("New-MSKCluster","Update-MSKMonitoring")
    "Provisioned_EnhancedMonitoring"=@("New-MSKClusterV2")
    "Provisioned_StorageMode"=@("New-MSKClusterV2")
    "Rebalancing_Status"=@("New-MSKCluster","New-MSKClusterV2","Update-MSKRebalancing")
    "StorageMode"=@("New-MSKCluster","Update-MSKStorage")
}

_awsArgumentCompleterRegistration $MSK_Completers $MSK_map

$MSK_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.MSK.$($commandName.Replace('-', ''))Cmdlet]"
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

$MSK_SelectMap = @{
    "Select"=@("Register-MSKAssociateScramSecret",
               "Unregister-MSKDisassociateScramSecret",
               "New-MSKCluster",
               "New-MSKClusterV2",
               "New-MSKConfiguration",
               "New-MSKReplicator",
               "New-MSKTopic",
               "New-MSKVpcConnection",
               "Remove-MSKCluster",
               "Remove-MSKClusterPolicy",
               "Remove-MSKConfiguration",
               "Remove-MSKReplicator",
               "Remove-MSKTopic",
               "Remove-MSKVpcConnection",
               "Get-MSKCluster",
               "Get-MSKClusterOperation",
               "Get-MSKClusterOperationV2",
               "Get-MSKClusterV2",
               "Get-MSKConfiguration",
               "Get-MSKConfigurationRevision",
               "Get-MSKReplicator",
               "Get-MSKTopic",
               "Get-MSKTopicPartition",
               "Get-MSKVpcConnection",
               "Get-MSKBootstrapBroker",
               "Get-MSKClusterPolicy",
               "Get-MSKCompatibleKafkaVersion",
               "Get-MSKClientVpcConnectionList",
               "Get-MSKClusterOperationList",
               "Get-MSKClusterOperationsV2List",
               "Get-MSKClusterList",
               "Get-MSKClustersV2List",
               "Get-MSKConfigurationRevisionList",
               "Get-MSKConfigurationList",
               "Get-MSKKafkaVersionList",
               "Get-MSKNodeList",
               "Get-MSKReplicatorList",
               "Get-MSKScramSecretList",
               "Get-MSKResourceTag",
               "Get-MSKTopicList",
               "Get-MSKVpcConnectionList",
               "Write-MSKClusterPolicy",
               "Restart-MSKBroker",
               "Deny-MSKClientVpcConnection",
               "Add-MSKResourceTag",
               "Remove-MSKResourceTag",
               "Update-MSKBrokerCount",
               "Update-MSKBrokerStorage",
               "Update-MSKBrokerType",
               "Update-MSKClusterConfiguration",
               "Update-MSKClusterKafkaVersion",
               "Update-MSKConfiguration",
               "Update-MSKConnectivity",
               "Update-MSKMonitoring",
               "Update-MSKRebalancing",
               "Update-MSKReplicationInfo",
               "Update-MSKSecurity",
               "Update-MSKStorage",
               "Update-MSKTopic")
}

_awsArgumentCompleterRegistration $MSK_SelectCompleters $MSK_SelectMap

