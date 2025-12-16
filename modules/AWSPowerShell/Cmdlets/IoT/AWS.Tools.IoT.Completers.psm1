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

        # Amazon.IoT.ApplicationProtocol
        {
            ($_ -eq "New-IOTDomainConfiguration/ApplicationProtocol") -Or
            ($_ -eq "Update-IOTDomainConfiguration/ApplicationProtocol")
        }
        {
            $v = "DEFAULT","HTTPS","MQTT_WSS","SECURE_MQTT"
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

        # Amazon.IoT.AuthenticationType
        {
            ($_ -eq "New-IOTDomainConfiguration/AuthenticationType") -Or
            ($_ -eq "Update-IOTDomainConfiguration/AuthenticationType")
        }
        {
            $v = "AWS_SIGV4","AWS_X509","CUSTOM_AUTH","CUSTOM_AUTH_X509","DEFAULT"
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
            ($_ -eq "New-IOTMitigationAction/UpdateCACertificateParams_Action") -Or
            ($_ -eq "Update-IOTMitigationAction/UpdateCACertificateParams_Action")
        }
        {
            $v = "DEACTIVATE"
            break
        }

        # Amazon.IoT.CannedAccessControlList
        {
            ($_ -eq "New-IOTTopicRule/S3_CannedAcl") -Or
            ($_ -eq "Set-IOTTopicRule/S3_CannedAcl")
        }
        {
            $v = "authenticated-read","aws-exec-read","bucket-owner-full-control","bucket-owner-read","log-delivery-write","private","public-read","public-read-write"
            break
        }

        # Amazon.IoT.CertificateMode
        "Register-IOTCACertificate/CertificateMode"
        {
            $v = "DEFAULT","SNI_ONLY"
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

        # Amazon.IoT.CommandExecutionStatus
        "Get-IOTCommandExecutionList/Status"
        {
            $v = "CREATED","FAILED","IN_PROGRESS","REJECTED","SUCCEEDED","TIMED_OUT"
            break
        }

        # Amazon.IoT.CommandNamespace
        {
            ($_ -eq "Get-IOTCommandExecutionList/Namespace") -Or
            ($_ -eq "Get-IOTCommandList/Namespace") -Or
            ($_ -eq "New-IOTCommand/Namespace")
        }
        {
            $v = "AWS-IoT","AWS-IoT-FleetWise"
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
            ($_ -eq "New-IOTMitigationAction/UpdateDeviceCertificateParams_Action") -Or
            ($_ -eq "Update-IOTMitigationAction/UpdateDeviceCertificateParams_Action")
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

        # Amazon.IoT.DimensionValueOperator
        "Get-IOTMetricValueList/DimensionValueOperator"
        {
            $v = "IN","NOT_IN"
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
            ($_ -eq "New-IOTTopicRule/DynamoDB_HashKeyType") -Or
            ($_ -eq "Set-IOTTopicRule/DynamoDB_HashKeyType") -Or
            ($_ -eq "New-IOTTopicRule/DynamoDB_RangeKeyType") -Or
            ($_ -eq "Set-IOTTopicRule/DynamoDB_RangeKeyType")
        }
        {
            $v = "NUMBER","STRING"
            break
        }

        # Amazon.IoT.EncryptionType
        "Update-IOTEncryptionConfiguration/EncryptionType"
        {
            $v = "AWS_OWNED_KMS_KEY","CUSTOMER_MANAGED_KMS_KEY"
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

        # Amazon.IoT.JobEndBehavior
        "New-IOTJob/SchedulingConfig_EndBehavior"
        {
            $v = "CANCEL","FORCE_CANCEL","STOP_ROLLOUT"
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
            $v = "CANCELED","COMPLETED","DELETION_IN_PROGRESS","IN_PROGRESS","SCHEDULED"
            break
        }

        # Amazon.IoT.LogLevel
        {
            ($_ -eq "Set-IOTV2LoggingOption/DefaultLogLevel") -Or
            ($_ -eq "New-IOTMitigationAction/EnableIoTLoggingParams_LogLevel") -Or
            ($_ -eq "Update-IOTMitigationAction/EnableIoTLoggingParams_LogLevel") -Or
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
            $v = "CLIENT_ID","DEFAULT","PRINCIPAL_ID","SOURCE_IP","THING_GROUP"
            break
        }

        # Amazon.IoT.MessageFormat
        {
            ($_ -eq "New-IOTTopicRule/Sns_MessageFormat") -Or
            ($_ -eq "Set-IOTTopicRule/Sns_MessageFormat")
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
            $v = "CREATE_COMPLETE","CREATE_FAILED","CREATE_IN_PROGRESS","CREATE_PENDING","DELETE_FAILED","DELETE_IN_PROGRESS"
            break
        }

        # Amazon.IoT.OutputFormat
        "New-IOTCommand/Preprocessor_AwsJsonSubstitution_OutputFormat"
        {
            $v = "CBOR","JSON"
            break
        }

        # Amazon.IoT.PackageVersionAction
        "Update-IOTPackageVersion/Action"
        {
            $v = "DEPRECATE","PUBLISH"
            break
        }

        # Amazon.IoT.PackageVersionStatus
        "Get-IOTPackageVersionList/Status"
        {
            $v = "DEPRECATED","DRAFT","PUBLISHED"
            break
        }

        # Amazon.IoT.PolicyTemplateName
        {
            ($_ -eq "New-IOTMitigationAction/ReplaceDefaultPolicyVersionParams_TemplateName") -Or
            ($_ -eq "Update-IOTMitigationAction/ReplaceDefaultPolicyVersionParams_TemplateName")
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

        # Amazon.IoT.SbomValidationResult
        "Get-IOTSbomValidationResultList/ValidationResult"
        {
            $v = "FAILED","SUCCEEDED"
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

        # Amazon.IoT.SortOrder
        {
            ($_ -eq "Get-IOTCommandExecutionList/SortOrder") -Or
            ($_ -eq "Get-IOTCommandList/SortOrder")
        }
        {
            $v = "ASCENDING","DESCENDING"
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

        # Amazon.IoT.TemplateType
        "New-IOTProvisioningTemplate/Type"
        {
            $v = "FLEET_PROVISIONING","JITP"
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

        # Amazon.IoT.ThingPrincipalType
        {
            ($_ -eq "Add-IOTThingPrincipal/ThingPrincipalType") -Or
            ($_ -eq "Get-IOTPrincipalThingsV2List/ThingPrincipalType") -Or
            ($_ -eq "Get-IOTThingPrincipalsV2List/ThingPrincipalType")
        }
        {
            $v = "EXCLUSIVE_THING","NON_EXCLUSIVE_THING"
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
    "Action"=@("Update-IOTPackageVersion")
    "ActionStatus"=@("Get-IOTAuditMitigationActionsExecutionList")
    "ActionType"=@("Get-IOTMitigationActionList")
    "AggregationType_Name"=@("New-IOTFleetMetric","Update-IOTFleetMetric")
    "ApplicationProtocol"=@("New-IOTDomainConfiguration","Update-IOTDomainConfiguration")
    "AuthenticationType"=@("New-IOTDomainConfiguration","Update-IOTDomainConfiguration")
    "BehaviorCriteriaType"=@("Get-IOTActiveViolationList","Get-IOTViolationEventList")
    "CertificateMode"=@("Register-IOTCACertificate")
    "DayOfWeek"=@("New-IOTScheduledAudit","Update-IOTScheduledAudit")
    "DefaultLogLevel"=@("Set-IOTV2LoggingOption")
    "DimensionValueOperator"=@("Get-IOTMetricValueList")
    "DomainConfigurationStatus"=@("Update-IOTDomainConfiguration")
    "DynamoDB_HashKeyType"=@("New-IOTTopicRule","Set-IOTTopicRule")
    "DynamoDB_RangeKeyType"=@("New-IOTTopicRule","Set-IOTTopicRule")
    "EnableIoTLoggingParams_LogLevel"=@("New-IOTMitigationAction","Update-IOTMitigationAction")
    "EncryptionType"=@("Update-IOTEncryptionConfiguration")
    "Frequency"=@("New-IOTScheduledAudit","Update-IOTScheduledAudit")
    "LoggingOptionsPayload_LogLevel"=@("Set-IOTLoggingOption")
    "LogLevel"=@("Set-IOTV2LoggingLevel")
    "LogTarget_TargetType"=@("Set-IOTV2LoggingLevel")
    "MetricType"=@("New-IOTCustomMetric")
    "Namespace"=@("Get-IOTCommandExecutionList","Get-IOTCommandList","New-IOTCommand")
    "NewAutoRegistrationStatus"=@("Update-IOTCACertificate")
    "NewStatus"=@("Update-IOTCACertificate","Update-IOTCertificate")
    "OtaUpdateStatus"=@("Get-IOTOTAUpdateList")
    "Preprocessor_AwsJsonSubstitution_OutputFormat"=@("New-IOTCommand")
    "ReplaceDefaultPolicyVersionParams_TemplateName"=@("New-IOTMitigationAction","Update-IOTMitigationAction")
    "ReportType"=@("Get-IOTThingRegistrationTaskReportList")
    "S3_CannedAcl"=@("New-IOTTopicRule","Set-IOTTopicRule")
    "SchedulingConfig_EndBehavior"=@("New-IOTJob")
    "ServiceType"=@("Get-IOTDomainConfigurationList","New-IOTDomainConfiguration")
    "Sns_MessageFormat"=@("New-IOTTopicRule","Set-IOTTopicRule")
    "SortOrder"=@("Get-IOTCommandExecutionList","Get-IOTCommandList")
    "Status"=@("Get-IOTAuthorizerList","Get-IOTCommandExecutionList","Get-IOTJobExecutionsForJobList","Get-IOTJobExecutionsForThingList","Get-IOTJobList","Get-IOTPackageVersionList","Get-IOTThingRegistrationTaskList","New-IOTAuthorizer","Register-IOTCertificate","Register-IOTCertificateWithoutCA","Update-IOTAuthorizer","Update-IOTTopicRuleDestination")
    "TargetSelection"=@("Get-IOTJobList","New-IOTJob","New-IOTOTAUpdate")
    "TargetType"=@("Get-IOTV2LoggingLevelList","Remove-IOTV2LoggingLevel")
    "TaskStatus"=@("Get-IOTAuditMitigationActionsTaskList","Get-IOTTaskList")
    "TaskType"=@("Get-IOTTaskList")
    "ThingGroupIndexingConfiguration_ThingGroupIndexingMode"=@("Update-IOTIndexingConfiguration")
    "ThingIndexingConfiguration_DeviceDefenderIndexingMode"=@("Update-IOTIndexingConfiguration")
    "ThingIndexingConfiguration_NamedShadowIndexingMode"=@("Update-IOTIndexingConfiguration")
    "ThingIndexingConfiguration_ThingConnectivityIndexingMode"=@("Update-IOTIndexingConfiguration")
    "ThingIndexingConfiguration_ThingIndexingMode"=@("Update-IOTIndexingConfiguration")
    "ThingPrincipalType"=@("Add-IOTThingPrincipal","Get-IOTPrincipalThingsV2List","Get-IOTThingPrincipalsV2List")
    "Type"=@("New-IOTDimension","New-IOTProvisioningTemplate")
    "Unit"=@("New-IOTFleetMetric","Update-IOTFleetMetric")
    "UpdateCACertificateParams_Action"=@("New-IOTMitigationAction","Update-IOTMitigationAction")
    "UpdateDeviceCertificateParams_Action"=@("New-IOTMitigationAction","Update-IOTMitigationAction")
    "ValidationResult"=@("Get-IOTSbomValidationResultList")
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
               "Add-IOTSbomWithPackageVersion",
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
               "New-IOTCertificateProvider",
               "New-IOTCommand",
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
               "New-IOTPackage",
               "New-IOTPackageVersion",
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
               "Remove-IOTCertificateProvider",
               "Remove-IOTCommand",
               "Remove-IOTCommandExecution",
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
               "Remove-IOTPackage",
               "Remove-IOTPackageVersion",
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
               "Get-IOTCertificateProvider",
               "Get-IOTCustomMetric",
               "Get-IOTDefaultAuthorizer",
               "Get-IOTDetectMitigationActionsTask",
               "Get-IOTDimension",
               "Get-IOTDomainConfiguration",
               "Get-IOTEncryptionConfiguration",
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
               "Remove-IOTSbomFromPackageVersion",
               "Enable-IOTTopicRule",
               "Get-IOTBehaviorModelTrainingSummary",
               "Get-IOTBucketsAggregation",
               "Get-IOTCardinality",
               "Get-IOTCommand",
               "Get-IOTCommandExecution",
               "Get-IOTEffectivePolicy",
               "Get-IOTIndexingConfiguration",
               "Get-IOTJobDocument",
               "Get-IOTLoggingOption",
               "Get-IOTOTAUpdate",
               "Get-IOTPackage",
               "Get-IOTPackageConfiguration",
               "Get-IOTPackageVersion",
               "Get-IOTPercentile",
               "Get-IOTPolicy",
               "Get-IOTPolicyVersion",
               "Get-IOTRegistrationCode",
               "Get-IOTStatistic",
               "Get-IOTThingConnectivityData",
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
               "Get-IOTCertificateProviderList",
               "Get-IOTCertificateList",
               "Get-IOTCertificateListByCA",
               "Get-IOTCommandExecutionList",
               "Get-IOTCommandList",
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
               "Get-IOTMetricValueList",
               "Get-IOTMitigationActionList",
               "Get-IOTOTAUpdateList",
               "Get-IOTOutgoingCertificate",
               "Get-IOTPackageList",
               "Get-IOTPackageVersionList",
               "Get-IOTPolicyList",
               "Get-IOTPolicyPrincipalList",
               "Get-IOTPolicyVersionList",
               "Get-IOTPrincipalPolicyList",
               "Get-IOTPrincipalThingList",
               "Get-IOTPrincipalThingsV2List",
               "Get-IOTProvisioningTemplateList",
               "Get-IOTProvisioningTemplateVersionList",
               "Get-IOTRelatedResourcesForAuditFindingList",
               "Get-IOTRoleAliasList",
               "Get-IOTSbomValidationResultList",
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
               "Get-IOTThingPrincipalsV2List",
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
               "Update-IOTCertificateProvider",
               "Update-IOTCommand",
               "Update-IOTCustomMetric",
               "Update-IOTDimension",
               "Update-IOTDomainConfiguration",
               "Update-IOTDynamicThingGroup",
               "Update-IOTEncryptionConfiguration",
               "Update-IOTEventConfiguration",
               "Update-IOTFleetMetric",
               "Update-IOTIndexingConfiguration",
               "Update-IOTJob",
               "Update-IOTMitigationAction",
               "Update-IOTPackage",
               "Update-IOTPackageConfiguration",
               "Update-IOTPackageVersion",
               "Update-IOTProvisioningTemplate",
               "Update-IOTRoleAlias",
               "Update-IOTScheduledAudit",
               "Update-IOTSecurityProfile",
               "Update-IOTStream",
               "Update-IOTThing",
               "Update-IOTThingGroup",
               "Update-IOTThingGroupsForThing",
               "Update-IOTThingType",
               "Update-IOTTopicRuleDestination",
               "Test-IOTValidSecurityProfileBehavior")
}

_awsArgumentCompleterRegistration $IOT_SelectCompleters $IOT_SelectMap

