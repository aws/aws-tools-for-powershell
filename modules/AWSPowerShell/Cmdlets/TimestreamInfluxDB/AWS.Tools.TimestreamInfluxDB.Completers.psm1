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

# Argument completions for service Amazon Timestream InfluxDB


$TIDB_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.TimestreamInfluxDB.ClusterDeploymentType
        "New-TIDBDbCluster/DeploymentType"
        {
            $v = "MULTI_NODE_READ_REPLICAS"
            break
        }

        # Amazon.TimestreamInfluxDB.DataFusionRuntimeType
        {
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Core_DataFusionRuntimeType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Enterprise_DataFusionRuntimeType")
        }
        {
            $v = "multi-thread","multi-thread-alt"
            break
        }

        # Amazon.TimestreamInfluxDB.DbInstanceType
        {
            ($_ -eq "New-TIDBDbCluster/DbInstanceType") -Or
            ($_ -eq "New-TIDBDbInstance/DbInstanceType") -Or
            ($_ -eq "Update-TIDBDbCluster/DbInstanceType") -Or
            ($_ -eq "Update-TIDBDbInstance/DbInstanceType")
        }
        {
            $v = "db.influx.12xlarge","db.influx.16xlarge","db.influx.24xlarge","db.influx.2xlarge","db.influx.4xlarge","db.influx.8xlarge","db.influx.large","db.influx.medium","db.influx.xlarge"
            break
        }

        # Amazon.TimestreamInfluxDB.DbStorageType
        {
            ($_ -eq "New-TIDBDbCluster/DbStorageType") -Or
            ($_ -eq "New-TIDBDbInstance/DbStorageType") -Or
            ($_ -eq "Update-TIDBDbInstance/DbStorageType")
        }
        {
            $v = "InfluxIOIncludedT1","InfluxIOIncludedT2","InfluxIOIncludedT3"
            break
        }

        # Amazon.TimestreamInfluxDB.DeploymentType
        {
            ($_ -eq "New-TIDBDbInstance/DeploymentType") -Or
            ($_ -eq "Update-TIDBDbInstance/DeploymentType")
        }
        {
            $v = "SINGLE_AZ","WITH_MULTIAZ_STANDBY"
            break
        }

        # Amazon.TimestreamInfluxDB.DurationType
        {
            ($_ -eq "New-TIDBDbParameterGroup/CatalogSyncInterval_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/CompactionCheckInterval_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/CompactionCleanupWait_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/CompactionGen2Duration_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/HttpIdleTimeout_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/HttpReadHeaderTimeout_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/HttpReadTimeout_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/HttpWriteTimeout_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Core_DeleteGracePeriod_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Core_DistinctCacheEvictionInterval_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Core_Gen1Duration_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Core_Gen1LookbackDuration_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Core_HardDeleteDefaultDuration_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Core_LastCacheEvictionInterval_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Core_ParquetMemCachePruneInterval_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Core_ParquetMemCacheQueryPathDuration_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Core_PreemptiveCacheAge_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Core_RetentionCheckInterval_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Enterprise_DeleteGracePeriod_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Enterprise_DistinctCacheEvictionInterval_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Enterprise_Gen1Duration_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Enterprise_Gen1LookbackDuration_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Enterprise_HardDeleteDefaultDuration_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Enterprise_LastCacheEvictionInterval_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Enterprise_ParquetMemCachePruneInterval_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Enterprise_PreemptiveCacheAge_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Enterprise_RetentionCheckInterval_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/ReplicationInterval_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/StorageCacheSnapshotWriteColdDuration_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/StorageCompactFullWriteColdDuration_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/StorageRetentionCheckInterval_DurationType") -Or
            ($_ -eq "New-TIDBDbParameterGroup/StorageWalMaxWriteDelay_DurationType")
        }
        {
            $v = "days","hours","milliseconds","minutes","seconds"
            break
        }

        # Amazon.TimestreamInfluxDB.FailoverMode
        {
            ($_ -eq "New-TIDBDbCluster/FailoverMode") -Or
            ($_ -eq "Update-TIDBDbCluster/FailoverMode")
        }
        {
            $v = "AUTOMATIC","NO_FAILOVER"
            break
        }

        # Amazon.TimestreamInfluxDB.LogFormats
        {
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Core_LogFormat") -Or
            ($_ -eq "New-TIDBDbParameterGroup/InfluxDBv3Enterprise_LogFormat")
        }
        {
            $v = "full"
            break
        }

        # Amazon.TimestreamInfluxDB.LogLevel
        "New-TIDBDbParameterGroup/InfluxDBv2_LogLevel"
        {
            $v = "debug","error","info"
            break
        }

        # Amazon.TimestreamInfluxDB.NetworkType
        {
            ($_ -eq "New-TIDBDbCluster/NetworkType") -Or
            ($_ -eq "New-TIDBDbInstance/NetworkType")
        }
        {
            $v = "DUAL","IPV4"
            break
        }

        # Amazon.TimestreamInfluxDB.TracingType
        "New-TIDBDbParameterGroup/InfluxDBv2_TracingType"
        {
            $v = "disabled","jaeger","log"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$TIDB_map = @{
    "CatalogSyncInterval_DurationType"=@("New-TIDBDbParameterGroup")
    "CompactionCheckInterval_DurationType"=@("New-TIDBDbParameterGroup")
    "CompactionCleanupWait_DurationType"=@("New-TIDBDbParameterGroup")
    "CompactionGen2Duration_DurationType"=@("New-TIDBDbParameterGroup")
    "DbInstanceType"=@("New-TIDBDbCluster","New-TIDBDbInstance","Update-TIDBDbCluster","Update-TIDBDbInstance")
    "DbStorageType"=@("New-TIDBDbCluster","New-TIDBDbInstance","Update-TIDBDbInstance")
    "DeploymentType"=@("New-TIDBDbCluster","New-TIDBDbInstance","Update-TIDBDbInstance")
    "FailoverMode"=@("New-TIDBDbCluster","Update-TIDBDbCluster")
    "HttpIdleTimeout_DurationType"=@("New-TIDBDbParameterGroup")
    "HttpReadHeaderTimeout_DurationType"=@("New-TIDBDbParameterGroup")
    "HttpReadTimeout_DurationType"=@("New-TIDBDbParameterGroup")
    "HttpWriteTimeout_DurationType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv2_LogLevel"=@("New-TIDBDbParameterGroup")
    "InfluxDBv2_TracingType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Core_DataFusionRuntimeThreadKeepAlive_DurationType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Core_DataFusionRuntimeType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Core_DeleteGracePeriod_DurationType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Core_DistinctCacheEvictionInterval_DurationType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Core_Gen1Duration_DurationType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Core_Gen1LookbackDuration_DurationType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Core_HardDeleteDefaultDuration_DurationType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Core_LastCacheEvictionInterval_DurationType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Core_LogFormat"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Core_ParquetMemCachePruneInterval_DurationType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Core_ParquetMemCacheQueryPathDuration_DurationType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Core_PreemptiveCacheAge_DurationType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Core_RetentionCheckInterval_DurationType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Enterprise_DataFusionRuntimeThreadKeepAlive_DurationType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Enterprise_DataFusionRuntimeType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Enterprise_DeleteGracePeriod_DurationType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Enterprise_DistinctCacheEvictionInterval_DurationType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Enterprise_Gen1Duration_DurationType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Enterprise_Gen1LookbackDuration_DurationType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Enterprise_HardDeleteDefaultDuration_DurationType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Enterprise_LastCacheEvictionInterval_DurationType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Enterprise_LogFormat"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Enterprise_ParquetMemCachePruneInterval_DurationType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Enterprise_ParquetMemCacheQueryPathDuration_DurationType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Enterprise_PreemptiveCacheAge_DurationType"=@("New-TIDBDbParameterGroup")
    "InfluxDBv3Enterprise_RetentionCheckInterval_DurationType"=@("New-TIDBDbParameterGroup")
    "NetworkType"=@("New-TIDBDbCluster","New-TIDBDbInstance")
    "ReplicationInterval_DurationType"=@("New-TIDBDbParameterGroup")
    "StorageCacheSnapshotWriteColdDuration_DurationType"=@("New-TIDBDbParameterGroup")
    "StorageCompactFullWriteColdDuration_DurationType"=@("New-TIDBDbParameterGroup")
    "StorageRetentionCheckInterval_DurationType"=@("New-TIDBDbParameterGroup")
    "StorageWalMaxWriteDelay_DurationType"=@("New-TIDBDbParameterGroup")
}

_awsArgumentCompleterRegistration $TIDB_Completers $TIDB_map

$TIDB_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.TIDB.$($commandName.Replace('-', ''))Cmdlet]"
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

$TIDB_SelectMap = @{
    "Select"=@("New-TIDBDbCluster",
               "New-TIDBDbInstance",
               "New-TIDBDbParameterGroup",
               "Remove-TIDBDbCluster",
               "Remove-TIDBDbInstance",
               "Get-TIDBDbCluster",
               "Get-TIDBDbInstance",
               "Get-TIDBDbParameterGroup",
               "Get-TIDBDbClusterList",
               "Get-TIDBDbInstanceList",
               "Get-TIDBDbInstancesForClusterList",
               "Get-TIDBDbParameterGroupList",
               "Get-TIDBResourceTag",
               "Add-TIDBResourceTag",
               "Remove-TIDBResourceTag",
               "Update-TIDBDbCluster",
               "Update-TIDBDbInstance")
}

_awsArgumentCompleterRegistration $TIDB_SelectCompleters $TIDB_SelectMap

