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
            $v = "recommend-node-config","resize-cluster","restore-cluster"
            break
        }

        # Amazon.Redshift.AquaConfigurationStatus
        {
            ($_ -eq "Edit-RSAquaConfiguration/AquaConfigurationStatus") -Or
            ($_ -eq "New-RSCluster/AquaConfigurationStatus") -Or
            ($_ -eq "Restore-RSFromClusterSnapshot/AquaConfigurationStatus")
        }
        {
            $v = "auto","disabled","enabled"
            break
        }

        # Amazon.Redshift.DataShareStatusForConsumer
        "Get-RSDataSharesForConsumer/Status"
        {
            $v = "ACTIVE","AVAILABLE"
            break
        }

        # Amazon.Redshift.DataShareStatusForProducer
        "Get-RSDataSharesForProducer/Status"
        {
            $v = "ACTIVE","AUTHORIZED","DEAUTHORIZED","PENDING_AUTHORIZATION","REJECTED"
            break
        }

        # Amazon.Redshift.LogDestinationType
        "Enable-RSLogging/LogDestinationType"
        {
            $v = "cloudwatch","s3"
            break
        }

        # Amazon.Redshift.PartnerIntegrationStatus
        "Update-RSPartnerStatus/Status"
        {
            $v = "Active","ConnectionFailure","Inactive","RuntimeFailure"
            break
        }

        # Amazon.Redshift.ReservedNodeExchangeActionType
        "Get-RSReservedNodeExchangeConfigurationOption/ActionType"
        {
            $v = "resize-cluster","restore-cluster"
            break
        }

        # Amazon.Redshift.ScheduledActionTypeValues
        "Get-RSScheduledAction/TargetActionType"
        {
            $v = "PauseCluster","ResizeCluster","ResumeCluster"
            break
        }

        # Amazon.Redshift.SourceType
        "Get-RSEvent/SourceType"
        {
            $v = "cluster","cluster-parameter-group","cluster-security-group","cluster-snapshot","scheduled-action"
            break
        }

        # Amazon.Redshift.UsageLimitBreachAction
        {
            ($_ -eq "Edit-RSUsageLimit/BreachAction") -Or
            ($_ -eq "New-RSUsageLimit/BreachAction")
        }
        {
            $v = "disable","emit-metric","log"
            break
        }

        # Amazon.Redshift.UsageLimitFeatureType
        {
            ($_ -eq "Get-RSUsageLimit/FeatureType") -Or
            ($_ -eq "New-RSUsageLimit/FeatureType")
        }
        {
            $v = "concurrency-scaling","cross-region-datasharing","spectrum"
            break
        }

        # Amazon.Redshift.UsageLimitLimitType
        "New-RSUsageLimit/LimitType"
        {
            $v = "data-scanned","time"
            break
        }

        # Amazon.Redshift.UsageLimitPeriod
        "New-RSUsageLimit/Period"
        {
            $v = "daily","monthly","weekly"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$RS_map = @{
    "ActionType"=@("Get-RSNodeConfigurationOption","Get-RSReservedNodeExchangeConfigurationOption")
    "AquaConfigurationStatus"=@("Edit-RSAquaConfiguration","New-RSCluster","Restore-RSFromClusterSnapshot")
    "BreachAction"=@("Edit-RSUsageLimit","New-RSUsageLimit")
    "FeatureType"=@("Get-RSUsageLimit","New-RSUsageLimit")
    "LimitType"=@("New-RSUsageLimit")
    "LogDestinationType"=@("Enable-RSLogging")
    "Period"=@("New-RSUsageLimit")
    "SourceType"=@("Get-RSEvent")
    "Status"=@("Get-RSDataSharesForConsumer","Get-RSDataSharesForProducer","Update-RSPartnerStatus")
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
               "Add-RSPartner",
               "Add-RSDataShareConsumer",
               "Approve-RSClusterSecurityGroupIngress",
               "Approve-RSDataShare",
               "Approve-RSEndpointAccess",
               "Approve-RSSnapshotAccess",
               "Remove-RSClusterSnapshotBatch",
               "Edit-RSClusterSnapshotBatch",
               "Stop-RSResize",
               "Copy-RSClusterSnapshot",
               "New-RSAuthenticationProfile",
               "New-RSCluster",
               "New-RSClusterParameterGroup",
               "New-RSClusterSecurityGroup",
               "New-RSClusterSnapshot",
               "New-RSClusterSubnetGroup",
               "New-RSCustomDomainAssociation",
               "New-RSEndpointAccess",
               "New-RSEventSubscription",
               "New-RSHsmClientCertificate",
               "New-RSHsmConfiguration",
               "New-RSIntegration",
               "New-RSRedshiftIdcApplication",
               "New-RSScheduledAction",
               "New-RSSnapshotCopyGrant",
               "New-RSSnapshotSchedule",
               "New-RSResourceTag",
               "New-RSUsageLimit",
               "Revoke-RSDataShare",
               "Remove-RSAuthenticationProfile",
               "Remove-RSCluster",
               "Remove-RSClusterParameterGroup",
               "Remove-RSClusterSecurityGroup",
               "Remove-RSClusterSnapshot",
               "Remove-RSClusterSubnetGroup",
               "Remove-RSCustomDomainAssociation",
               "Remove-RSEndpointAccess",
               "Remove-RSEventSubscription",
               "Remove-RSHsmClientCertificate",
               "Remove-RSHsmConfiguration",
               "Remove-RSIntegration",
               "Remove-RSPartner",
               "Remove-RSRedshiftIdcApplication",
               "Remove-RSResourcePolicy",
               "Remove-RSScheduledAction",
               "Remove-RSSnapshotCopyGrant",
               "Remove-RSSnapshotSchedule",
               "Remove-RSResourceTag",
               "Remove-RSUsageLimit",
               "Unregister-RSNamespace",
               "Get-RSAccountAttribute",
               "Get-RSAuthenticationProfile",
               "Get-RSClusterDbRevision",
               "Get-RSClusterParameterGroup",
               "Get-RSClusterParameter",
               "Get-RSCluster",
               "Get-RSClusterSecurityGroup",
               "Get-RSClusterSnapshot",
               "Get-RSClusterSubnetGroup",
               "Get-RSClusterTrack",
               "Get-RSClusterVersion",
               "Get-RSCustomDomainAssociation",
               "Get-RSDataShare",
               "Get-RSDataSharesForConsumer",
               "Get-RSDataSharesForProducer",
               "Get-RSDefaultClusterParameter",
               "Get-RSEndpointAccess",
               "Get-RSEndpointAuthorization",
               "Get-RSEventCategory",
               "Get-RSEvent",
               "Get-RSEventSubscription",
               "Get-RSHsmClientCertificate",
               "Get-RSHsmConfiguration",
               "Get-RSInboundIntegration",
               "Get-RSIntegration",
               "Get-RSLoggingStatus",
               "Get-RSNodeConfigurationOption",
               "Get-RSOrderableClusterOption",
               "Get-RSPartner",
               "Get-RSRedshiftIdcApplication",
               "Get-RSReservedNodeExchangeStatus",
               "Get-RSReservedNodeOffering",
               "Get-RSReservedNode",
               "Get-RSResize",
               "Get-RSScheduledAction",
               "Get-RSSnapshotCopyGrant",
               "Get-RSSnapshotSchedule",
               "Get-RSStorage",
               "Get-RSTableRestoreStatus",
               "Get-RSResourceTag",
               "Get-RSUsageLimit",
               "Disable-RSLogging",
               "Disable-RSSnapshotCopy",
               "Remove-RSDataShareConsumer",
               "Enable-RSLogging",
               "Enable-RSSnapshotCopy",
               "Start-RSFailoverPrimaryCompute",
               "Get-RSClusterCredential",
               "Get-RSClusterCredentialsWithIAM",
               "Get-RSReservedNodeExchangeConfigurationOption",
               "Get-RSReservedNodeExchangeOffering",
               "Get-RSResourcePolicy",
               "Get-RSRecommendationList",
               "Edit-RSAquaConfiguration",
               "Edit-RSAuthenticationProfile",
               "Edit-RSCluster",
               "Edit-RSClusterDbRevision",
               "Edit-RSClusterIamRole",
               "Edit-RSClusterMaintenance",
               "Edit-RSClusterParameterGroup",
               "Edit-RSClusterSnapshot",
               "Edit-RSClusterSnapshotSchedule",
               "Edit-RSClusterSubnetGroup",
               "Edit-RSCustomDomainAssociation",
               "Edit-RSEndpointAccess",
               "Edit-RSEventSubscription",
               "Edit-RSIntegration",
               "Edit-RSRedshiftIdcApplication",
               "Edit-RSScheduledAction",
               "Edit-RSSnapshotCopyRetentionPeriod",
               "Edit-RSSnapshotSchedule",
               "Edit-RSUsageLimit",
               "Stop-RSCluster",
               "Request-RSReservedNodeOffering",
               "Write-RSResourcePolicy",
               "Restart-RSCluster",
               "Register-RSNamespace",
               "Deny-RSDataShare",
               "Reset-RSClusterParameterGroup",
               "Set-RSClusterSize",
               "Restore-RSFromClusterSnapshot",
               "Restore-RSTableFromClusterSnapshot",
               "Start-RSCluster",
               "Revoke-RSClusterSecurityGroupIngress",
               "Revoke-RSEndpointAccess",
               "Revoke-RSSnapshotAccess",
               "Switch-RSEncryptionKey",
               "Update-RSPartnerStatus")
}

_awsArgumentCompleterRegistration $RS_SelectCompleters $RS_SelectMap

