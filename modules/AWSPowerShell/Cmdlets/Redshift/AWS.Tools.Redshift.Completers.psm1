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

# Argument completions for service Amazon Redshift


$RS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Redshift.ActionType
        "Get-RSNodeConfigurationOption/ActionType"
        {
            $v = "recommend-node-config","restore-cluster"
            break
        }

        # Amazon.Redshift.ScheduledActionTypeValues
        "Get-RSScheduledAction/TargetActionType"
        {
            $v = "ResizeCluster"
            break
        }

        # Amazon.Redshift.SourceType
        "Get-RSEvent/SourceType"
        {
            $v = "cluster","cluster-parameter-group","cluster-security-group","cluster-snapshot","scheduled-action"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$RS_map = @{
    "ActionType"=@("Get-RSNodeConfigurationOption")
    "SourceType"=@("Get-RSEvent")
    "TargetActionType"=@("Get-RSScheduledAction")
}

_awsArgumentCompleterRegistration $RS_Completers $RS_map

$RS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.RS.$($commandName.Replace('-', ''))Cmdlet]"
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

$RS_SelectMap = @{
    "Select"=@("Switch-RSReservedNode",
               "Approve-RSClusterSecurityGroupIngress",
               "Approve-RSSnapshotAccess",
               "Remove-RSClusterSnapshotBatch",
               "Edit-RSClusterSnapshotBatch",
               "Stop-RSResize",
               "Copy-RSClusterSnapshot",
               "New-RSCluster",
               "New-RSClusterParameterGroup",
               "New-RSClusterSecurityGroup",
               "New-RSClusterSnapshot",
               "New-RSClusterSubnetGroup",
               "New-RSEventSubscription",
               "New-RSHsmClientCertificate",
               "New-RSHsmConfiguration",
               "New-RSScheduledAction",
               "New-RSSnapshotCopyGrant",
               "New-RSSnapshotSchedule",
               "New-RSResourceTag",
               "Remove-RSCluster",
               "Remove-RSClusterParameterGroup",
               "Remove-RSClusterSecurityGroup",
               "Remove-RSClusterSnapshot",
               "Remove-RSClusterSubnetGroup",
               "Remove-RSEventSubscription",
               "Remove-RSHsmClientCertificate",
               "Remove-RSHsmConfiguration",
               "Remove-RSScheduledAction",
               "Remove-RSSnapshotCopyGrant",
               "Remove-RSSnapshotSchedule",
               "Remove-RSResourceTag",
               "Get-RSAccountAttribute",
               "Get-RSClusterDbRevision",
               "Get-RSClusterParameterGroup",
               "Get-RSClusterParameter",
               "Get-RSCluster",
               "Get-RSClusterSecurityGroup",
               "Get-RSClusterSnapshot",
               "Get-RSClusterSubnetGroup",
               "Get-RSClusterTrack",
               "Get-RSClusterVersion",
               "Get-RSDefaultClusterParameter",
               "Get-RSEventCategory",
               "Get-RSEvent",
               "Get-RSEventSubscription",
               "Get-RSHsmClientCertificate",
               "Get-RSHsmConfiguration",
               "Get-RSLoggingStatus",
               "Get-RSNodeConfigurationOption",
               "Get-RSOrderableClusterOption",
               "Get-RSReservedNodeOffering",
               "Get-RSReservedNode",
               "Get-RSResize",
               "Get-RSScheduledAction",
               "Get-RSSnapshotCopyGrant",
               "Get-RSSnapshotSchedule",
               "Get-RSStorage",
               "Get-RSTableRestoreStatus",
               "Get-RSResourceTag",
               "Disable-RSLogging",
               "Disable-RSSnapshotCopy",
               "Enable-RSLogging",
               "Enable-RSSnapshotCopy",
               "Get-RSClusterCredential",
               "Get-RSReservedNodeExchangeOffering",
               "Edit-RSCluster",
               "Edit-RSClusterDbRevision",
               "Edit-RSClusterIamRole",
               "Edit-RSClusterMaintenance",
               "Edit-RSClusterParameterGroup",
               "Edit-RSClusterSnapshot",
               "Edit-RSClusterSnapshotSchedule",
               "Edit-RSClusterSubnetGroup",
               "Edit-RSEventSubscription",
               "Edit-RSScheduledAction",
               "Edit-RSSnapshotCopyRetentionPeriod",
               "Edit-RSSnapshotSchedule",
               "Request-RSReservedNodeOffering",
               "Restart-RSCluster",
               "Reset-RSClusterParameterGroup",
               "Set-RSClusterSize",
               "Restore-RSFromClusterSnapshot",
               "Restore-RSTableFromClusterSnapshot",
               "Revoke-RSClusterSecurityGroupIngress",
               "Revoke-RSSnapshotAccess",
               "Switch-RSEncryptionKey")
}

_awsArgumentCompleterRegistration $RS_SelectCompleters $RS_SelectMap

