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

# Argument completions for service Amazon ElastiCache


$EC_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ElastiCache.AuthTokenUpdateStrategyType
        {
            ($_ -eq "Edit-ECCacheCluster/AuthTokenUpdateStrategy") -Or
            ($_ -eq "Edit-ECReplicationGroup/AuthTokenUpdateStrategy")
        }
        {
            $v = "DELETE","ROTATE","SET"
            break
        }

        # Amazon.ElastiCache.AZMode
        {
            ($_ -eq "Edit-ECCacheCluster/AZMode") -Or
            ($_ -eq "New-ECCacheCluster/AZMode")
        }
        {
            $v = "cross-az","single-az"
            break
        }

        # Amazon.ElastiCache.ClusterMode
        {
            ($_ -eq "Edit-ECReplicationGroup/ClusterMode") -Or
            ($_ -eq "New-ECReplicationGroup/ClusterMode")
        }
        {
            $v = "compatible","disabled","enabled"
            break
        }

        # Amazon.ElastiCache.DataStorageUnit
        {
            ($_ -eq "Edit-ECServerlessCache/CacheUsageLimits_DataStorage_Unit") -Or
            ($_ -eq "New-ECServerlessCache/CacheUsageLimits_DataStorage_Unit")
        }
        {
            $v = "GB"
            break
        }

        # Amazon.ElastiCache.InputAuthenticationType
        {
            ($_ -eq "Edit-ECUser/AuthenticationMode_Type") -Or
            ($_ -eq "New-ECUser/AuthenticationMode_Type")
        }
        {
            $v = "iam","no-password-required","password"
            break
        }

        # Amazon.ElastiCache.IpDiscovery
        {
            ($_ -eq "Edit-ECCacheCluster/IpDiscovery") -Or
            ($_ -eq "Edit-ECReplicationGroup/IpDiscovery") -Or
            ($_ -eq "New-ECCacheCluster/IpDiscovery") -Or
            ($_ -eq "New-ECReplicationGroup/IpDiscovery")
        }
        {
            $v = "ipv4","ipv6"
            break
        }

        # Amazon.ElastiCache.NetworkType
        {
            ($_ -eq "New-ECCacheCluster/NetworkType") -Or
            ($_ -eq "New-ECReplicationGroup/NetworkType")
        }
        {
            $v = "dual_stack","ipv4","ipv6"
            break
        }

        # Amazon.ElastiCache.OutpostMode
        "New-ECCacheCluster/OutpostMode"
        {
            $v = "cross-outpost","single-outpost"
            break
        }

        # Amazon.ElastiCache.SourceType
        "Get-ECEvent/SourceType"
        {
            $v = "cache-cluster","cache-parameter-group","cache-security-group","cache-subnet-group","replication-group","serverless-cache","serverless-cache-snapshot","user","user-group"
            break
        }

        # Amazon.ElastiCache.TransitEncryptionMode
        {
            ($_ -eq "Edit-ECReplicationGroup/TransitEncryptionMode") -Or
            ($_ -eq "New-ECReplicationGroup/TransitEncryptionMode")
        }
        {
            $v = "preferred","required"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EC_map = @{
    "AuthenticationMode_Type"=@("Edit-ECUser","New-ECUser")
    "AuthTokenUpdateStrategy"=@("Edit-ECCacheCluster","Edit-ECReplicationGroup")
    "AZMode"=@("Edit-ECCacheCluster","New-ECCacheCluster")
    "CacheUsageLimits_DataStorage_Unit"=@("Edit-ECServerlessCache","New-ECServerlessCache")
    "ClusterMode"=@("Edit-ECReplicationGroup","New-ECReplicationGroup")
    "IpDiscovery"=@("Edit-ECCacheCluster","Edit-ECReplicationGroup","New-ECCacheCluster","New-ECReplicationGroup")
    "NetworkType"=@("New-ECCacheCluster","New-ECReplicationGroup")
    "OutpostMode"=@("New-ECCacheCluster")
    "SourceType"=@("Get-ECEvent")
    "TransitEncryptionMode"=@("Edit-ECReplicationGroup","New-ECReplicationGroup")
}

_awsArgumentCompleterRegistration $EC_Completers $EC_map

$EC_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.EC.$($commandName.Replace('-', ''))Cmdlet]"
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

$EC_SelectMap = @{
    "Select"=@("Add-ECTag",
               "Approve-ECCacheSecurityGroupIngress",
               "Start-ECUpdateActionBatch",
               "Stop-ECUpdateActionBatch",
               "Complete-ECMigration",
               "Copy-ECServerlessCacheSnapshot",
               "Copy-ECSnapshot",
               "New-ECCacheCluster",
               "New-ECCacheParameterGroup",
               "New-ECCacheSecurityGroup",
               "New-ECCacheSubnetGroup",
               "New-ECGlobalReplicationGroup",
               "New-ECReplicationGroup",
               "New-ECServerlessCache",
               "New-ECServerlessCacheSnapshot",
               "New-ECSnapshot",
               "New-ECUser",
               "New-ECUserGroup",
               "Request-ECNodeGroupDecreaseInGlobalReplicationGroup",
               "Request-ECReplicaCountDecrease",
               "Remove-ECCacheCluster",
               "Remove-ECCacheParameterGroup",
               "Remove-ECCacheSecurityGroup",
               "Remove-ECCacheSubnetGroup",
               "Remove-ECGlobalReplicationGroup",
               "Remove-ECReplicationGroup",
               "Remove-ECServerlessCache",
               "Remove-ECServerlessCacheSnapshot",
               "Remove-ECSnapshot",
               "Remove-ECUser",
               "Remove-ECUserGroup",
               "Get-ECCacheCluster",
               "Get-ECCacheEngineVersion",
               "Get-ECCacheParameterGroup",
               "Get-ECCacheParameter",
               "Get-ECCacheSecurityGroup",
               "Get-ECCacheSubnetGroup",
               "Get-ECEngineDefaultParameter",
               "Get-ECEvent",
               "Get-ECGlobalReplicationGroup",
               "Get-ECReplicationGroup",
               "Get-ECReservedCacheNode",
               "Get-ECReservedCacheNodesOffering",
               "Get-ECServerlessCache",
               "Get-ECServerlessCacheSnapshot",
               "Get-ECServiceUpdate",
               "Get-ECSnapshot",
               "Get-ECUpdateAction",
               "Get-ECUserGroup",
               "Get-ECUser",
               "Remove-ECReplicationGroupFromGlobalReplicationGroup",
               "Export-ECServerlessCacheSnapshot",
               "Request-ECGlobalReplicationGroupFailover",
               "Request-ECNodeGroupIncreaseInGlobalReplicationGroup",
               "Request-ECReplicaCountIncrease",
               "Get-ECAllowedNodeTypeModification",
               "Get-ECTag",
               "Edit-ECCacheCluster",
               "Edit-ECCacheParameterGroup",
               "Edit-ECCacheSubnetGroup",
               "Edit-ECGlobalReplicationGroup",
               "Edit-ECReplicationGroup",
               "Edit-ECReplicationGroupShardConfiguration",
               "Edit-ECServerlessCache",
               "Edit-ECUser",
               "Edit-ECUserGroup",
               "Request-ECReservedCacheNodesOffering",
               "Request-ECSlotRebalanceInGlobalReplicationGroup",
               "Restart-ECCacheCluster",
               "Remove-ECTag",
               "Reset-ECCacheParameterGroup",
               "Revoke-ECCacheSecurityGroupIngress",
               "Start-ECMigration",
               "Test-ECFailover",
               "Test-ECMigration")
}

_awsArgumentCompleterRegistration $EC_SelectCompleters $EC_SelectMap

