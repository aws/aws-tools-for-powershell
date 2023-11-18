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

# Argument completions for service Amazon Relational Database Service


$RDS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.RDS.ActivityStreamMode
        "Start-RDSActivityStream/Mode"
        {
            $v = "async","sync"
            break
        }

        # Amazon.RDS.AuditPolicyState
        "Edit-RDSActivityStream/AuditPolicyState"
        {
            $v = "locked","unlocked"
            break
        }

        # Amazon.RDS.AutomationMode
        "Edit-RDSDBInstance/AutomationMode"
        {
            $v = "all-paused","full"
            break
        }

        # Amazon.RDS.CustomEngineVersionStatus
        "Edit-RDSCustomDBEngineVersion/Status"
        {
            $v = "available","inactive","inactive-except-restore"
            break
        }

        # Amazon.RDS.DBProxyEndpointTargetRole
        "New-RDSDBProxyEndpoint/TargetRole"
        {
            $v = "READ_ONLY","READ_WRITE"
            break
        }

        # Amazon.RDS.EngineFamily
        "New-RDSDBProxy/EngineFamily"
        {
            $v = "MYSQL","POSTGRESQL","SQLSERVER"
            break
        }

        # Amazon.RDS.ExportSourceType
        "Get-RDSExportTask/SourceType"
        {
            $v = "CLUSTER","SNAPSHOT"
            break
        }

        # Amazon.RDS.ReplicaMode
        {
            ($_ -eq "New-RDSDBCluster/RdsCustomClusterConfiguration_ReplicaMode") -Or
            ($_ -eq "Restore-RDSDBClusterFromSnapshot/RdsCustomClusterConfiguration_ReplicaMode") -Or
            ($_ -eq "Restore-RDSDBClusterToPointInTime/RdsCustomClusterConfiguration_ReplicaMode") -Or
            ($_ -eq "Edit-RDSDBInstance/ReplicaMode") -Or
            ($_ -eq "New-RDSDBInstanceReadReplica/ReplicaMode")
        }
        {
            $v = "mounted","open-read-only"
            break
        }

        # Amazon.RDS.SourceType
        "Get-RDSEvent/SourceType"
        {
            $v = "blue-green-deployment","custom-engine-version","db-cluster","db-cluster-snapshot","db-instance","db-parameter-group","db-proxy","db-security-group","db-snapshot"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$RDS_map = @{
    "AuditPolicyState"=@("Edit-RDSActivityStream")
    "AutomationMode"=@("Edit-RDSDBInstance")
    "EngineFamily"=@("New-RDSDBProxy")
    "Mode"=@("Start-RDSActivityStream")
    "RdsCustomClusterConfiguration_ReplicaMode"=@("New-RDSDBCluster","Restore-RDSDBClusterFromSnapshot","Restore-RDSDBClusterToPointInTime")
    "ReplicaMode"=@("Edit-RDSDBInstance","New-RDSDBInstanceReadReplica")
    "SourceType"=@("Get-RDSEvent","Get-RDSExportTask")
    "Status"=@("Edit-RDSCustomDBEngineVersion")
    "TargetRole"=@("New-RDSDBProxyEndpoint")
}

_awsArgumentCompleterRegistration $RDS_Completers $RDS_map

$RDS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.RDS.$($commandName.Replace('-', ''))Cmdlet]"
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

$RDS_SelectMap = @{
    "Select"=@("Add-RDSRoleToDBCluster",
               "Add-RDSRoleToDBInstance",
               "Add-RDSSourceIdentifierToSubscription",
               "Add-RDSTagsToResource",
               "Submit-RDSPendingMaintenanceAction",
               "Enable-RDSDBSecurityGroupIngress",
               "Reset-RDSDBCluster",
               "Stop-RDSExportTask",
               "Copy-RDSDBClusterParameterGroup",
               "Copy-RDSDBClusterSnapshot",
               "Copy-RDSDBParameterGroup",
               "Copy-RDSDBSnapshot",
               "Copy-RDSOptionGroup",
               "New-RDSBlueGreenDeployment",
               "New-RDSCustomDBEngineVersion",
               "New-RDSDBCluster",
               "New-RDSDBClusterEndpoint",
               "New-RDSDBClusterParameterGroup",
               "New-RDSDBClusterSnapshot",
               "New-RDSDBInstance",
               "New-RDSDBInstanceReadReplica",
               "New-RDSDBParameterGroup",
               "New-RDSDBProxy",
               "New-RDSDBProxyEndpoint",
               "New-RDSDBSecurityGroup",
               "New-RDSDBSnapshot",
               "New-RDSDBSubnetGroup",
               "New-RDSEventSubscription",
               "New-RDSGlobalCluster",
               "New-RDSIntegration",
               "New-RDSOptionGroup",
               "New-RDSTenantDatabase",
               "Remove-RDSBlueGreenDeployment",
               "Remove-RDSCustomDBEngineVersion",
               "Remove-RDSDBCluster",
               "Remove-RDSDBClusterAutomatedBackup",
               "Remove-RDSDBClusterEndpoint",
               "Remove-RDSDBClusterParameterGroup",
               "Remove-RDSDBClusterSnapshot",
               "Remove-RDSDBInstance",
               "Remove-RDSDBInstanceAutomatedBackup",
               "Remove-RDSDBParameterGroup",
               "Remove-RDSDBProxy",
               "Remove-RDSDBProxyEndpoint",
               "Remove-RDSDBSecurityGroup",
               "Remove-RDSDBSnapshot",
               "Remove-RDSDBSubnetGroup",
               "Remove-RDSEventSubscription",
               "Remove-RDSGlobalCluster",
               "Remove-RDSIntegration",
               "Remove-RDSOptionGroup",
               "Remove-RDSTenantDatabase",
               "Unregister-RDSDBProxyTarget",
               "Get-RDSAccountAttribute",
               "Get-RDSBlueGreenDeployment",
               "Get-RDSCertificate",
               "Get-RDSDBClusterAutomatedBackup",
               "Get-RDSDBClusterBacktrackList",
               "Get-RDSDBClusterEndpoint",
               "Get-RDSDBClusterParameterGroup",
               "Get-RDSDBClusterParameter",
               "Get-RDSDBCluster",
               "Get-RDSDBClusterSnapshotAttribute",
               "Get-RDSDBClusterSnapshot",
               "Get-RDSDBEngineVersion",
               "Get-RDSDBInstanceAutomatedBackup",
               "Get-RDSDBInstance",
               "Get-RDSDBLogFile",
               "Get-RDSDBParameterGroup",
               "Get-RDSDBParameter",
               "Get-RDSDBProxy",
               "Get-RDSDBProxyEndpoint",
               "Get-RDSDBProxyTargetGroup",
               "Get-RDSDBProxyTarget",
               "Get-RDSDBSecurityGroup",
               "Get-RDSDBSnapshotAttribute",
               "Get-RDSDBSnapshot",
               "Get-RDSDBSnapshotTenantDatabasis",
               "Get-RDSDBSubnetGroup",
               "Get-RDSEngineDefaultClusterParameter",
               "Get-RDSEngineDefaultParameter",
               "Get-RDSEventCategory",
               "Get-RDSEvent",
               "Get-RDSEventSubscription",
               "Get-RDSExportTask",
               "Get-RDSGlobalCluster",
               "Get-RDSIntegration",
               "Get-RDSOptionGroupOption",
               "Get-RDSOptionGroup",
               "Get-RDSOrderableDBInstanceOption",
               "Get-RDSPendingMaintenanceAction",
               "Get-RDSReservedDBInstance",
               "Get-RDSReservedDBInstancesOfferingList",
               "Get-RDSSourceRegion",
               "Get-RDSTenantDatabasis",
               "Get-RDSValidDBInstanceModification",
               "Get-RDSDBLogFilePortion",
               "Start-RDSDBClusterFailover",
               "Start-RDSFailoverGlobalCluster",
               "Get-RDSTagForResource",
               "Edit-RDSActivityStream",
               "Edit-RDSCertificate",
               "Edit-RDSCurrentDBClusterCapacity",
               "Edit-RDSCustomDBEngineVersion",
               "Edit-RDSDBCluster",
               "Edit-RDSDBClusterEndpoint",
               "Edit-RDSDBClusterParameterGroup",
               "Edit-RDSDBClusterSnapshotAttribute",
               "Edit-RDSDBInstance",
               "Edit-RDSDBParameterGroup",
               "Edit-RDSDBProxy",
               "Edit-RDSDBProxyEndpoint",
               "Edit-RDSDBProxyTargetGroup",
               "Edit-RDSDBSnapshot",
               "Edit-RDSDBSnapshotAttribute",
               "Edit-RDSDBSubnetGroup",
               "Edit-RDSEventSubscription",
               "Edit-RDSGlobalCluster",
               "Edit-RDSOptionGroup",
               "Edit-RDSTenantDatabase",
               "Convert-RDSReadReplicaToStandalone",
               "Convert-RDSReadReplicaDBCluster",
               "New-RDSReservedDBInstancesOfferingPurchase",
               "Restart-RDSDBCluster",
               "Restart-RDSDBInstance",
               "Register-RDSDBProxyTarget",
               "Remove-RDSFromGlobalCluster",
               "Remove-RDSRoleFromDBCluster",
               "Remove-RDSRoleFromDBInstance",
               "Remove-RDSSourceIdentifierFromSubscription",
               "Remove-RDSTagFromResource",
               "Reset-RDSDBClusterParameterGroup",
               "Reset-RDSDBParameterGroup",
               "Restore-RDSDBClusterFromS3",
               "Restore-RDSDBClusterFromSnapshot",
               "Restore-RDSDBClusterToPointInTime",
               "Restore-RDSDBInstanceFromDBSnapshot",
               "Restore-RDSDBInstanceFromS3",
               "Restore-RDSDBInstanceToPointInTime",
               "Revoke-RDSDBSecurityGroupIngress",
               "Start-RDSActivityStream",
               "Start-RDSDBCluster",
               "Start-RDSDBInstance",
               "Start-RDSDBInstanceAutomatedBackupsReplication",
               "Start-RDSExportTask",
               "Stop-RDSActivityStream",
               "Stop-RDSDBCluster",
               "Stop-RDSDBInstance",
               "Stop-RDSDBInstanceAutomatedBackupsReplication",
               "Switch-RDSBlueGreenDeployment",
               "Request-RDSSwitchoverGlobalCluster",
               "Convert-RDSReadReplicaToNewPrimary")
}

_awsArgumentCompleterRegistration $RDS_SelectCompleters $RDS_SelectMap

