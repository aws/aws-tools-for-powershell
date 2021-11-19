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

# Argument completions for service AWS IoT


$IOT_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.IoT.AggregationTypeName
        {
            ($_ -eq "New-IOTFleetMetric/AggregationType_Name") -Or
            ($_ -eq "Update-IOTFleetMetric/AggregationType_Name")
        }
        {
            $v = "Cardinality","Percentiles","Statistics"
            break
        }

        # Amazon.IoT.AuditFrequency
        {
            ($_ -eq "New-IOTScheduledAudit/Frequency") -Or
            ($_ -eq "Update-IOTScheduledAudit/Frequency")
        }
        {
            $v = "BIWEEKLY","DAILY","MONTHLY","WEEKLY"
            break
        }

        # Amazon.IoT.AuditMitigationActionsExecutionStatus
        "Get-IOTAuditMitigationActionsExecutionList/ActionStatus"
        {
            $v = "CANCELED","COMPLETED","FAILED","IN_PROGRESS","PENDING","SKIPPED"
            break
        }

        # Amazon.IoT.AuditMitigationActionsTaskStatus
        "Get-IOTAuditMitigationActionsTaskList/TaskStatus"
        {
            $v = "CANCELED","COMPLETED","FAILED","IN_PROGRESS"
            break
        }

        # Amazon.IoT.AuditTaskStatus
        "Get-IOTTaskList/TaskStatus"
        {
            $v = "CANCELED","COMPLETED","FAILED","IN_PROGRESS"
            break
        }

        # Amazon.IoT.AuditTaskType
        "Get-IOTTaskList/TaskType"
        {
            $v = "ON_DEMAND_AUDIT_TASK","SCHEDULED_AUDIT_TASK"
            break
        }

        # Amazon.IoT.AuthorizerStatus
        {
            ($_ -eq "Get-IOTAuthorizerList/Status") -Or
            ($_ -eq "New-IOTAuthorizer/Status") -Or
            ($_ -eq "Update-IOTAuthorizer/Status")
        }
        {
            $v = "ACTIVE","INACTIVE"
            break
        }

        # Amazon.IoT.AutoRegistrationStatus
        "Update-IOTCACertificate/NewAutoRegistrationStatus"
        {
            $v = "DISABLE","ENABLE"
            break
        }

        # Amazon.IoT.BehaviorCriteriaType
        {
            ($_ -eq "Get-IOTActiveViolationList/BehaviorCriteriaType") -Or
            ($_ -eq "Get-IOTViolationEventList/BehaviorCriteriaType")
        }
        {
            $v = "MACHINE_LEARNING","STATIC","STATISTICAL"
            break
        }

        # Amazon.IoT.CACertificateStatus
        "Update-IOTCACertificate/NewStatus"
        {
            $v = "ACTIVE","INACTIVE"
            break
        }

        # Amazon.IoT.CACertificateUpdateAction
        {
            ($_ -eq "New-IOTMitigationAction/ActionParams_UpdateCACertificateParams_Action") -Or
            ($_ -eq "Update-IOTMitigationAction/ActionParams_UpdateCACertificateParams_Action")
        }
        {
            $v = "DEACTIVATE"
            break
        }

        # Amazon.IoT.CannedAccessControlList
        {
            ($_ -eq "New-IOTTopicRule/TopicRulePayload_ErrorAction_S3_CannedAcl") -Or
            ($_ -eq "Set-IOTTopicRule/TopicRulePayload_ErrorAction_S3_CannedAcl")
        }
        {
            $v = "authenticated-read","aws-exec-read","bucket-owner-full-control","bucket-owner-read","log-delivery-write","private","public-read","public-read-write"
            break
        }

        # Amazon.IoT.CertificateStatus
        {
            ($_ -eq "Update-IOTCertificate/NewStatus") -Or
            ($_ -eq "Register-IOTCertificate/Status") -Or
            ($_ -eq "Register-IOTCertificateWithoutCA/Status")
        }
        {
            $v = "ACTIVE","INACTIVE","PENDING_ACTIVATION","PENDING_TRANSFER","REGISTER_INACTIVE","REVOKED"
            break
        }

        # Amazon.IoT.CustomMetricType
        "New-IOTCustomMetric/MetricType"
        {
            $v = "ip-address-list","number","number-list","string-list"
            break
        }

        # Amazon.IoT.DayOfWeek
        {
            ($_ -eq "New-IOTScheduledAudit/DayOfWeek") -Or
            ($_ -eq "Update-IOTScheduledAudit/DayOfWeek")
        }
        {
            $v = "FRI","MON","SAT","SUN","THU","TUE","WED"
            break
        }

        # Amazon.IoT.DeviceCertificateUpdateAction
        {
            ($_ -eq "New-IOTMitigationAction/ActionParams_UpdateDeviceCertificateParams_Action") -Or
            ($_ -eq "Update-IOTMitigationAction/ActionParams_UpdateDeviceCertificateParams_Action")
        }
        {
            $v = "DEACTIVATE"
            break
        }

        # Amazon.IoT.DeviceDefenderIndexingMode
        "Update-IOTIndexingConfiguration/ThingIndexingConfiguration_DeviceDefenderIndexingMode"
        {
            $v = "OFF","VIOLATIONS"
            break
        }

        # Amazon.IoT.DimensionType
        "New-IOTDimension/Type"
        {
            $v = "TOPIC_FILTER"
            break
        }

        # Amazon.IoT.DomainConfigurationStatus
        "Update-IOTDomainConfiguration/DomainConfigurationStatus"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.IoT.DynamoKeyType
        {
            ($_ -eq "New-IOTTopicRule/TopicRulePayload_ErrorAction_DynamoDB_HashKeyType") -Or
            ($_ -eq "Set-IOTTopicRule/TopicRulePayload_ErrorAction_DynamoDB_HashKeyType") -Or
            ($_ -eq "New-IOTTopicRule/TopicRulePayload_ErrorAction_DynamoDB_RangeKeyType") -Or
            ($_ -eq "Set-IOTTopicRule/TopicRulePayload_ErrorAction_DynamoDB_RangeKeyType")
        }
        {
            $v = "NUMBER","STRING"
            break
        }

        # Amazon.IoT.FleetMetricUnit
        {
            ($_ -eq "New-IOTFleetMetric/Unit") -Or
            ($_ -eq "Update-IOTFleetMetric/Unit")
        }
        {
            $v = "Bits","Bits/Second","Bytes","Bytes/Second","Count","Count/Second","Gigabits","Gigabits/Second","Gigabytes","Gigabytes/Second","Kilobits","Kilobits/Second","Kilobytes","Kilobytes/Second","Megabits","Megabits/Second","Megabytes","Megabytes/Second","Microseconds","Milliseconds","None","Percent","Seconds","Terabits","Terabits/Second","Terabytes","Terabytes/Second"
            break
        }

        # Amazon.IoT.JobExecutionStatus
        {
            ($_ -eq "Get-IOTJobExecutionsForJobList/Status") -Or
            ($_ -eq "Get-IOTJobExecutionsForThingList/Status")
        }
        {
            $v = "CANCELED","FAILED","IN_PROGRESS","QUEUED","REJECTED","REMOVED","SUCCEEDED","TIMED_OUT"
            break
        }

        # Amazon.IoT.JobStatus
        "Get-IOTJobList/Status"
        {
            $v = "CANCELED","COMPLETED","DELETION_IN_PROGRESS","IN_PROGRESS"
            break
        }

        # Amazon.IoT.LogLevel
        {
            ($_ -eq "New-IOTMitigationAction/ActionParams_EnableIoTLoggingParams_LogLevel") -Or
            ($_ -eq "Update-IOTMitigationAction/ActionParams_EnableIoTLoggingParams_LogLevel") -Or
            ($_ -eq "Set-IOTV2LoggingOption/DefaultLogLevel") -Or
            ($_ -eq "Set-IOTLoggingOption/LoggingOptionsPayload_LogLevel") -Or
            ($_ -eq "Set-IOTV2LoggingLevel/LogLevel")
        }
        {
            $v = "DEBUG","DISABLED","ERROR","INFO","WARN"
            break
        }

        # Amazon.IoT.LogTargetType
        {
            ($_ -eq "Set-IOTV2LoggingLevel/LogTarget_TargetType") -Or
            ($_ -eq "Get-IOTV2LoggingLevelList/TargetType") -Or
            ($_ -eq "Remove-IOTV2LoggingLevel/TargetType")
        }
        {
            $v = "DEFAULT","THING_GROUP"
            break
        }

        # Amazon.IoT.MessageFormat
        {
            ($_ -eq "New-IOTTopicRule/TopicRulePayload_ErrorAction_Sns_MessageFormat") -Or
            ($_ -eq "Set-IOTTopicRule/TopicRulePayload_ErrorAction_Sns_MessageFormat")
        }
        {
            $v = "JSON","RAW"
            break
        }

        # Amazon.IoT.MitigationActionType
        "Get-IOTMitigationActionList/ActionType"
        {
            $v = "ADD_THINGS_TO_THING_GROUP","ENABLE_IOT_LOGGING","PUBLISH_FINDING_TO_SNS","REPLACE_DEFAULT_POLICY_VERSION","UPDATE_CA_CERTIFICATE","UPDATE_DEVICE_CERTIFICATE"
            break
        }

        # Amazon.IoT.NamedShadowIndexingMode
        "Update-IOTIndexingConfiguration/ThingIndexingConfiguration_NamedShadowIndexingMode"
        {
            $v = "OFF","ON"
            break
        }

        # Amazon.IoT.OTAUpdateStatus
        "Get-IOTOTAUpdateList/OtaUpdateStatus"
        {
            $v = "CREATE_COMPLETE","CREATE_FAILED","CREATE_IN_PROGRESS","CREATE_PENDING"
            break
        }

        # Amazon.IoT.PolicyTemplateName
        {
            ($_ -eq "New-IOTMitigationAction/ActionParams_ReplaceDefaultPolicyVersionParams_TemplateName") -Or
            ($_ -eq "Update-IOTMitigationAction/ActionParams_ReplaceDefaultPolicyVersionParams_TemplateName")
        }
        {
            $v = "BLANK_POLICY"
            break
        }

        # Amazon.IoT.ReportType
        "Get-IOTThingRegistrationTaskReportList/ReportType"
        {
            $v = "ERRORS","RESULTS"
            break
        }

        # Amazon.IoT.ServiceType
        {
            ($_ -eq "Get-IOTDomainConfigurationList/ServiceType") -Or
            ($_ -eq "New-IOTDomainConfiguration/ServiceType")
        }
        {
            $v = "CREDENTIAL_PROVIDER","DATA","JOBS"
            break
        }

        # Amazon.IoT.Status
        "Get-IOTThingRegistrationTaskList/Status"
        {
            $v = "Cancelled","Cancelling","Completed","Failed","InProgress"
            break
        }

        # Amazon.IoT.TargetSelection
        {
            ($_ -eq "Get-IOTJobList/TargetSelection") -Or
            ($_ -eq "New-IOTJob/TargetSelection") -Or
            ($_ -eq "New-IOTOTAUpdate/TargetSelection")
        }
        {
            $v = "CONTINUOUS","SNAPSHOT"
            break
        }

        # Amazon.IoT.ThingConnectivityIndexingMode
        "Update-IOTIndexingConfiguration/ThingIndexingConfiguration_ThingConnectivityIndexingMode"
        {
            $v = "OFF","STATUS"
            break
        }

        # Amazon.IoT.ThingGroupIndexingMode
        "Update-IOTIndexingConfiguration/ThingGroupIndexingConfiguration_ThingGroupIndexingMode"
        {
            $v = "OFF","ON"
            break
        }

        # Amazon.IoT.ThingIndexingMode
        "Update-IOTIndexingConfiguration/ThingIndexingConfiguration_ThingIndexingMode"
        {
            $v = "OFF","REGISTRY","REGISTRY_AND_SHADOW"
            break
        }

        # Amazon.IoT.TopicRuleDestinationStatus
        "Update-IOTTopicRuleDestination/Status"
        {
            $v = "DELETING","DISABLED","ENABLED","ERROR","IN_PROGRESS"
            break
        }

        # Amazon.IoT.VerificationState
        {
            ($_ -eq "Get-IOTActiveViolationList/VerificationState") -Or
            ($_ -eq "Get-IOTViolationEventList/VerificationState") -Or
            ($_ -eq "Write-IOTVerificationStateOnViolation/VerificationState")
        }
        {
            $v = "BENIGN_POSITIVE","FALSE_POSITIVE","TRUE_POSITIVE","UNKNOWN"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$IOT_map = @{
    "ActionParams_EnableIoTLoggingParams_LogLevel"=@("New-IOTMitigationAction","Update-IOTMitigationAction")
    "ActionParams_ReplaceDefaultPolicyVersionParams_TemplateName"=@("New-IOTMitigationAction","Update-IOTMitigationAction")
    "ActionParams_UpdateCACertificateParams_Action"=@("New-IOTMitigationAction","Update-IOTMitigationAction")
    "ActionParams_UpdateDeviceCertificateParams_Action"=@("New-IOTMitigationAction","Update-IOTMitigationAction")
    "ActionStatus"=@("Get-IOTAuditMitigationActionsExecutionList")
    "ActionType"=@("Get-IOTMitigationActionList")
    "AggregationType_Name"=@("New-IOTFleetMetric","Update-IOTFleetMetric")
    "BehaviorCriteriaType"=@("Get-IOTActiveViolationList","Get-IOTViolationEventList")
    "DayOfWeek"=@("New-IOTScheduledAudit","Update-IOTScheduledAudit")
    "DefaultLogLevel"=@("Set-IOTV2LoggingOption")
    "DomainConfigurationStatus"=@("Update-IOTDomainConfiguration")
    "Frequency"=@("New-IOTScheduledAudit","Update-IOTScheduledAudit")
    "LoggingOptionsPayload_LogLevel"=@("Set-IOTLoggingOption")
    "LogLevel"=@("Set-IOTV2LoggingLevel")
    "LogTarget_TargetType"=@("Set-IOTV2LoggingLevel")
    "MetricType"=@("New-IOTCustomMetric")
    "NewAutoRegistrationStatus"=@("Update-IOTCACertificate")
    "NewStatus"=@("Update-IOTCACertificate","Update-IOTCertificate")
    "OtaUpdateStatus"=@("Get-IOTOTAUpdateList")
    "ReportType"=@("Get-IOTThingRegistrationTaskReportList")
    "ServiceType"=@("Get-IOTDomainConfigurationList","New-IOTDomainConfiguration")
    "Status"=@("Get-IOTAuthorizerList","Get-IOTJobExecutionsForJobList","Get-IOTJobExecutionsForThingList","Get-IOTJobList","Get-IOTThingRegistrationTaskList","New-IOTAuthorizer","Register-IOTCertificate","Register-IOTCertificateWithoutCA","Update-IOTAuthorizer","Update-IOTTopicRuleDestination")
    "TargetSelection"=@("Get-IOTJobList","New-IOTJob","New-IOTOTAUpdate")
    "TargetType"=@("Get-IOTV2LoggingLevelList","Remove-IOTV2LoggingLevel")
    "TaskStatus"=@("Get-IOTAuditMitigationActionsTaskList","Get-IOTTaskList")
    "TaskType"=@("Get-IOTTaskList")
    "ThingGroupIndexingConfiguration_ThingGroupIndexingMode"=@("Update-IOTIndexingConfiguration")
    "ThingIndexingConfiguration_DeviceDefenderIndexingMode"=@("Update-IOTIndexingConfiguration")
    "ThingIndexingConfiguration_NamedShadowIndexingMode"=@("Update-IOTIndexingConfiguration")
    "ThingIndexingConfiguration_ThingConnectivityIndexingMode"=@("Update-IOTIndexingConfiguration")
    "ThingIndexingConfiguration_ThingIndexingMode"=@("Update-IOTIndexingConfiguration")
    "TopicRulePayload_ErrorAction_DynamoDB_HashKeyType"=@("New-IOTTopicRule","Set-IOTTopicRule")
    "TopicRulePayload_ErrorAction_DynamoDB_RangeKeyType"=@("New-IOTTopicRule","Set-IOTTopicRule")
    "TopicRulePayload_ErrorAction_S3_CannedAcl"=@("New-IOTTopicRule","Set-IOTTopicRule")
    "TopicRulePayload_ErrorAction_Sns_MessageFormat"=@("New-IOTTopicRule","Set-IOTTopicRule")
    "Type"=@("New-IOTDimension")
    "Unit"=@("New-IOTFleetMetric","Update-IOTFleetMetric")
    "VerificationState"=@("Get-IOTActiveViolationList","Get-IOTViolationEventList","Write-IOTVerificationStateOnViolation")
}

_awsArgumentCompleterRegistration $IOT_Completers $IOT_map

$IOT_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.IOT.$($commandName.Replace('-', ''))Cmdlet]"
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

$IOT_SelectMap = @{
    "Select"=@("Confirm-IOTCertificateTransfer",
               "Add-IOTThingToBillingGroup",
               "Add-IOTThingToThingGroup",
               "Add-IOTTargetsWithJob",
               "Add-IOTPolicy",
               "Add-IOTPrincipalPolicy",
               "Mount-IOTSecurityProfile",
               "Add-IOTThingPrincipal",
               "Stop-IOTAuditMitigationActionsTask",
               "Stop-IOTAuditTask",
               "Stop-IOTCertificateTransfer",
               "Stop-IOTDetectMitigationActionsTask",
               "Stop-IOTJob",
               "Stop-IOTJobExecution",
               "Clear-IOTDefaultAuthorizer",
               "Confirm-IOTTopicRuleDestination",
               "New-IOTAuditSuppression",
               "New-IOTAuthorizer",
               "New-IOTBillingGroup",
               "New-IOTCertificateFromCsr",
               "New-IOTCustomMetric",
               "New-IOTDimension",
               "New-IOTDomainConfiguration",
               "New-IOTDynamicThingGroup",
               "New-IOTFleetMetric",
               "New-IOTJob",
               "New-IOTJobTemplate",
               "New-IOTKeysAndCertificate",
               "New-IOTMitigationAction",
               "New-IOTOTAUpdate",
               "New-IOTPolicy",
               "New-IOTPolicyVersion",
               "New-IOTProvisioningClaim",
               "New-IOTProvisioningTemplate",
               "New-IOTProvisioningTemplateVersion",
               "New-IOTRoleAlias",
               "New-IOTScheduledAudit",
               "New-IOTSecurityProfile",
               "New-IOTStream",
               "New-IOTThing",
               "New-IOTThingGroup",
               "New-IOTThingType",
               "New-IOTTopicRule",
               "New-IOTTopicRuleDestination",
               "Remove-IOTAccountAuditConfiguration",
               "Remove-IOTAuditSuppression",
               "Remove-IOTAuthorizer",
               "Remove-IOTBillingGroup",
               "Remove-IOTCACertificate",
               "Remove-IOTCertificate",
               "Remove-IOTCustomMetric",
               "Remove-IOTDimension",
               "Remove-IOTDomainConfiguration",
               "Remove-IOTDynamicThingGroup",
               "Remove-IOTFleetMetric",
               "Remove-IOTJob",
               "Remove-IOTJobExecution",
               "Remove-IOTJobTemplate",
               "Remove-IOTMitigationAction",
               "Remove-IOTOTAUpdate",
               "Remove-IOTPolicy",
               "Remove-IOTPolicyVersion",
               "Remove-IOTProvisioningTemplate",
               "Remove-IOTProvisioningTemplateVersion",
               "Remove-IOTRegistrationCode",
               "Remove-IOTRoleAlias",
               "Remove-IOTScheduledAudit",
               "Remove-IOTSecurityProfile",
               "Remove-IOTStream",
               "Remove-IOTThing",
               "Remove-IOTThingGroup",
               "Remove-IOTThingType",
               "Remove-IOTTopicRule",
               "Remove-IOTTopicRuleDestination",
               "Remove-IOTV2LoggingLevel",
               "Set-IOTThingTypeDeprecation",
               "Get-IOTAccountAuditConfiguration",
               "Get-IOTAuditFinding",
               "Get-IOTAuditMitigationActionsTask",
               "Get-IOTAuditSuppression",
               "Get-IOTAuditTask",
               "Get-IOTAuthorizer",
               "Get-IOTBillingGroup",
               "Get-IOTCACertificate",
               "Get-IOTCertificate",
               "Get-IOTCustomMetric",
               "Get-IOTDefaultAuthorizer",
               "Get-IOTDetectMitigationActionsTask",
               "Get-IOTDimension",
               "Get-IOTDomainConfiguration",
               "Get-IOTEndpoint",
               "Get-IOTEventConfiguration",
               "Get-IOTFleetMetric",
               "Get-IOTIndex",
               "Get-IOTJob",
               "Get-IOTJobExecution",
               "Get-IOTJobTemplate",
               "Get-IOTManagedJobTemplate",
               "Get-IOTMitigationAction",
               "Get-IOTProvisioningTemplate",
               "Get-IOTProvisioningTemplateVersion",
               "Get-IOTRoleAlias",
               "Get-IOTScheduledAudit",
               "Get-IOTSecurityProfile",
               "Get-IOTStream",
               "Get-IOTThing",
               "Get-IOTThingGroup",
               "Get-IOTThingRegistrationTask",
               "Get-IOTThingType",
               "Dismount-IOTPolicy",
               "Remove-IOTPrincipalPolicy",
               "Dismount-IOTSecurityProfile",
               "Remove-IOTThingPrincipal",
               "Disable-IOTTopicRule",
               "Enable-IOTTopicRule",
               "Get-IOTBehaviorModelTrainingSummary",
               "Get-IOTBucketsAggregation",
               "Get-IOTCardinality",
               "Get-IOTEffectivePolicy",
               "Get-IOTIndexingConfiguration",
               "Get-IOTJobDocument",
               "Get-IOTLoggingOption",
               "Get-IOTOTAUpdate",
               "Get-IOTPercentile",
               "Get-IOTPolicy",
               "Get-IOTPolicyVersion",
               "Get-IOTRegistrationCode",
               "Get-IOTStatistic",
               "Get-IOTTopicRule",
               "Get-IOTTopicRuleDestination",
               "Get-IOTV2LoggingOption",
               "Get-IOTActiveViolationList",
               "Get-IOTAttachedPolicyList",
               "Get-IOTAuditFindingList",
               "Get-IOTAuditMitigationActionsExecutionList",
               "Get-IOTAuditMitigationActionsTaskList",
               "Get-IOTAuditSuppressionList",
               "Get-IOTTaskList",
               "Get-IOTAuthorizerList",
               "Get-IOTBillingGroupList",
               "Get-IOTCACertificateList",
               "Get-IOTCertificateList",
               "Get-IOTCertificateListByCA",
               "Get-IOTCustomMetricList",
               "Get-IOTDetectMitigationActionsExecutionList",
               "Get-IOTDetectMitigationActionsTaskList",
               "Get-IOTDimensionList",
               "Get-IOTDomainConfigurationList",
               "Get-IOTFleetMetricList",
               "Get-IOTIndexList",
               "Get-IOTJobExecutionsForJobList",
               "Get-IOTJobExecutionsForThingList",
               "Get-IOTJobList",
               "Get-IOTJobTemplateList",
               "Get-IOTManagedJobTemplateList",
               "Get-IOTMitigationActionList",
               "Get-IOTOTAUpdateList",
               "Get-IOTOutgoingCertificate",
               "Get-IOTPolicyList",
               "Get-IOTPolicyPrincipalList",
               "Get-IOTPolicyVersionList",
               "Get-IOTPrincipalPolicyList",
               "Get-IOTPrincipalThingList",
               "Get-IOTProvisioningTemplateList",
               "Get-IOTProvisioningTemplateVersionList",
               "Get-IOTRoleAliasList",
               "Get-IOTScheduledAuditList",
               "Get-IOTSecurityProfileList",
               "Get-IOTSecurityProfilesForTargetList",
               "Get-IOTStreamList",
               "Get-IOTTagListForResource",
               "Get-IOTTargetsForPolicyList",
               "Get-IOTTargetsForSecurityProfileList",
               "Get-IOTThingGroupList",
               "Get-IOTThingGroupsForThingList",
               "Get-IOTThingPrincipalList",
               "Get-IOTThingRegistrationTaskReportList",
               "Get-IOTThingRegistrationTaskList",
               "Get-IOTThingList",
               "Get-IOTThingsInBillingGroupList",
               "Get-IOTThingsInThingGroupList",
               "Get-IOTThingTypeList",
               "Get-IOTTopicRuleDestinationList",
               "Get-IOTTopicRuleList",
               "Get-IOTV2LoggingLevelList",
               "Get-IOTViolationEventList",
               "Write-IOTVerificationStateOnViolation",
               "Register-IOTCACertificate",
               "Register-IOTCertificate",
               "Register-IOTCertificateWithoutCA",
               "Register-IOTThing",
               "Deny-IOTCertificateTransfer",
               "Remove-IOTThingFromBillingGroup",
               "Remove-IOTThingFromThingGroup",
               "Set-IOTTopicRule",
               "Search-IOTIndex",
               "Set-IOTDefaultAuthorizer",
               "Set-IOTDefaultPolicyVersion",
               "Set-IOTLoggingOption",
               "Set-IOTV2LoggingLevel",
               "Set-IOTV2LoggingOption",
               "Start-IOTAuditMitigationActionsTask",
               "Start-IOTDetectMitigationActionsTask",
               "Start-IOTOnDemandAuditTask",
               "Start-IOTThingRegistrationTask",
               "Stop-IOTThingRegistrationTask",
               "Add-IOTResourceTag",
               "Test-IOTAuthorization",
               "Test-IOTInvokeAuthorizer",
               "Request-IOTCertificateTransfer",
               "Remove-IOTResourceTag",
               "Update-IOTAccountAuditConfiguration",
               "Update-IOTAuditSuppression",
               "Update-IOTAuthorizer",
               "Update-IOTBillingGroup",
               "Update-IOTCACertificate",
               "Update-IOTCertificate",
               "Update-IOTCustomMetric",
               "Update-IOTDimension",
               "Update-IOTDomainConfiguration",
               "Update-IOTDynamicThingGroup",
               "Update-IOTEventConfiguration",
               "Update-IOTFleetMetric",
               "Update-IOTIndexingConfiguration",
               "Update-IOTJob",
               "Update-IOTMitigationAction",
               "Update-IOTProvisioningTemplate",
               "Update-IOTRoleAlias",
               "Update-IOTScheduledAudit",
               "Update-IOTSecurityProfile",
               "Update-IOTStream",
               "Update-IOTThing",
               "Update-IOTThingGroup",
               "Update-IOTThingGroupsForThing",
               "Update-IOTTopicRuleDestination",
               "Test-IOTValidSecurityProfileBehavior")
}

_awsArgumentCompleterRegistration $IOT_SelectCompleters $IOT_SelectMap

