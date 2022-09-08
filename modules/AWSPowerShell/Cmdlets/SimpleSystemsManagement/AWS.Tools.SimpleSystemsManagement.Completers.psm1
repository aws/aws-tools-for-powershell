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

# Argument completions for service AWS Systems Manager


$SSM_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.SimpleSystemsManagement.AssociationComplianceSeverity
        {
            ($_ -eq "New-SSMAssociation/ComplianceSeverity") -Or
            ($_ -eq "Update-SSMAssociation/ComplianceSeverity")
        }
        {
            $v = "CRITICAL","HIGH","LOW","MEDIUM","UNSPECIFIED"
            break
        }

        # Amazon.SimpleSystemsManagement.AssociationStatusName
        "Update-SSMAssociationStatus/AssociationStatus_Name"
        {
            $v = "Failed","Pending","Success"
            break
        }

        # Amazon.SimpleSystemsManagement.AssociationSyncCompliance
        {
            ($_ -eq "New-SSMAssociation/SyncCompliance") -Or
            ($_ -eq "Update-SSMAssociation/SyncCompliance")
        }
        {
            $v = "AUTO","MANUAL"
            break
        }

        # Amazon.SimpleSystemsManagement.ComplianceUploadType
        "Write-SSMComplianceItem/UploadType"
        {
            $v = "COMPLETE","PARTIAL"
            break
        }

        # Amazon.SimpleSystemsManagement.DocumentFormat
        {
            ($_ -eq "Get-SSMDocument/DocumentFormat") -Or
            ($_ -eq "New-SSMDocument/DocumentFormat") -Or
            ($_ -eq "Update-SSMDocument/DocumentFormat")
        }
        {
            $v = "JSON","TEXT","YAML"
            break
        }

        # Amazon.SimpleSystemsManagement.DocumentHashType
        {
            ($_ -eq "Send-SSMCommand/DocumentHashType") -Or
            ($_ -eq "Register-SSMTaskWithMaintenanceWindow/TaskInvocationParameters_RunCommand_DocumentHashType") -Or
            ($_ -eq "Update-SSMMaintenanceWindowTask/TaskInvocationParameters_RunCommand_DocumentHashType")
        }
        {
            $v = "Sha1","Sha256"
            break
        }

        # Amazon.SimpleSystemsManagement.DocumentMetadataEnum
        "Get-SSMDocumentMetadataHistory/Metadata"
        {
            $v = "DocumentReviews"
            break
        }

        # Amazon.SimpleSystemsManagement.DocumentPermissionType
        {
            ($_ -eq "Edit-SSMDocumentPermission/PermissionType") -Or
            ($_ -eq "Get-SSMDocumentPermission/PermissionType")
        }
        {
            $v = "Share"
            break
        }

        # Amazon.SimpleSystemsManagement.DocumentReviewAction
        "Update-SSMDocumentMetadata/DocumentReviews_Action"
        {
            $v = "Approve","Reject","SendForReview","UpdateReview"
            break
        }

        # Amazon.SimpleSystemsManagement.DocumentType
        "New-SSMDocument/DocumentType"
        {
            $v = "ApplicationConfiguration","ApplicationConfigurationSchema","Automation","Automation.ChangeTemplate","ChangeCalendar","Command","DeploymentStrategy","Package","Policy","ProblemAnalysis","ProblemAnalysisTemplate","Session"
            break
        }

        # Amazon.SimpleSystemsManagement.ExecutionMode
        "Start-SSMAutomationExecution/Mode"
        {
            $v = "Auto","Interactive"
            break
        }

        # Amazon.SimpleSystemsManagement.InventorySchemaDeleteOption
        "Remove-SSMInventory/SchemaDeleteOption"
        {
            $v = "DeleteSchema","DisableSchema"
            break
        }

        # Amazon.SimpleSystemsManagement.MaintenanceWindowResourceType
        {
            ($_ -eq "Get-SSMMaintenanceWindowSchedule/ResourceType") -Or
            ($_ -eq "Get-SSMMaintenanceWindowsForTarget/ResourceType") -Or
            ($_ -eq "Register-SSMTargetWithMaintenanceWindow/ResourceType")
        }
        {
            $v = "INSTANCE","RESOURCE_GROUP"
            break
        }

        # Amazon.SimpleSystemsManagement.MaintenanceWindowTaskCutoffBehavior
        {
            ($_ -eq "Register-SSMTaskWithMaintenanceWindow/CutoffBehavior") -Or
            ($_ -eq "Update-SSMMaintenanceWindowTask/CutoffBehavior")
        }
        {
            $v = "CANCEL_TASK","CONTINUE_TASK"
            break
        }

        # Amazon.SimpleSystemsManagement.MaintenanceWindowTaskType
        "Register-SSMTaskWithMaintenanceWindow/TaskType"
        {
            $v = "AUTOMATION","LAMBDA","RUN_COMMAND","STEP_FUNCTIONS"
            break
        }

        # Amazon.SimpleSystemsManagement.NotificationType
        {
            ($_ -eq "Send-SSMCommand/NotificationConfig_NotificationType") -Or
            ($_ -eq "Register-SSMTaskWithMaintenanceWindow/TaskInvocationParameters_RunCommand_NotificationConfig_NotificationType") -Or
            ($_ -eq "Update-SSMMaintenanceWindowTask/TaskInvocationParameters_RunCommand_NotificationConfig_NotificationType")
        }
        {
            $v = "Command","Invocation"
            break
        }

        # Amazon.SimpleSystemsManagement.OperatingSystem
        {
            ($_ -eq "Get-SSMDeployablePatchSnapshotForInstance/BaselineOverride_OperatingSystem") -Or
            ($_ -eq "Get-SSMDefaultPatchBaseline/OperatingSystem") -Or
            ($_ -eq "Get-SSMPatchBaselineForPatchGroup/OperatingSystem") -Or
            ($_ -eq "Get-SSMPatchProperty/OperatingSystem") -Or
            ($_ -eq "New-SSMPatchBaseline/OperatingSystem")
        }
        {
            $v = "AMAZON_LINUX","AMAZON_LINUX_2","CENTOS","DEBIAN","MACOS","ORACLE_LINUX","RASPBIAN","REDHAT_ENTERPRISE_LINUX","ROCKY_LINUX","SUSE","UBUNTU","WINDOWS"
            break
        }

        # Amazon.SimpleSystemsManagement.OpsItemStatus
        "Update-SSMOpsItem/Status"
        {
            $v = "Approved","Cancelled","Cancelling","ChangeCalendarOverrideApproved","ChangeCalendarOverrideRejected","Closed","CompletedWithFailure","CompletedWithSuccess","Failed","InProgress","Open","Pending","PendingApproval","PendingChangeCalendarOverride","Rejected","Resolved","RunbookInProgress","Scheduled","TimedOut"
            break
        }

        # Amazon.SimpleSystemsManagement.ParameterTier
        "Write-SSMParameter/Tier"
        {
            $v = "Advanced","Intelligent-Tiering","Standard"
            break
        }

        # Amazon.SimpleSystemsManagement.ParameterType
        "Write-SSMParameter/Type"
        {
            $v = "SecureString","String","StringList"
            break
        }

        # Amazon.SimpleSystemsManagement.PatchAction
        {
            ($_ -eq "Get-SSMDeployablePatchSnapshotForInstance/BaselineOverride_RejectedPatchesAction") -Or
            ($_ -eq "New-SSMPatchBaseline/RejectedPatchesAction") -Or
            ($_ -eq "Update-SSMPatchBaseline/RejectedPatchesAction")
        }
        {
            $v = "ALLOW_AS_DEPENDENCY","BLOCK"
            break
        }

        # Amazon.SimpleSystemsManagement.PatchComplianceLevel
        {
            ($_ -eq "New-SSMPatchBaseline/ApprovedPatchesComplianceLevel") -Or
            ($_ -eq "Update-SSMPatchBaseline/ApprovedPatchesComplianceLevel") -Or
            ($_ -eq "Get-SSMDeployablePatchSnapshotForInstance/BaselineOverride_ApprovedPatchesComplianceLevel")
        }
        {
            $v = "CRITICAL","HIGH","INFORMATIONAL","LOW","MEDIUM","UNSPECIFIED"
            break
        }

        # Amazon.SimpleSystemsManagement.PatchProperty
        "Get-SSMPatchProperty/Property"
        {
            $v = "CLASSIFICATION","MSRC_SEVERITY","PRIORITY","PRODUCT","PRODUCT_FAMILY","SEVERITY"
            break
        }

        # Amazon.SimpleSystemsManagement.PatchSet
        "Get-SSMPatchProperty/PatchSet"
        {
            $v = "APPLICATION","OS"
            break
        }

        # Amazon.SimpleSystemsManagement.ResourceDataSyncS3Format
        "New-SSMResourceDataSync/S3Destination_SyncFormat"
        {
            $v = "JsonSerDe"
            break
        }

        # Amazon.SimpleSystemsManagement.ResourceTypeForTagging
        {
            ($_ -eq "Add-SSMResourceTag/ResourceType") -Or
            ($_ -eq "Get-SSMResourceTag/ResourceType") -Or
            ($_ -eq "Remove-SSMResourceTag/ResourceType")
        }
        {
            $v = "Association","Automation","Document","MaintenanceWindow","ManagedInstance","OpsItem","OpsMetadata","Parameter","PatchBaseline"
            break
        }

        # Amazon.SimpleSystemsManagement.SessionState
        "Get-SSMSession/State"
        {
            $v = "Active","History"
            break
        }

        # Amazon.SimpleSystemsManagement.SignalType
        "Send-SSMAutomationSignal/SignalType"
        {
            $v = "Approve","Reject","Resume","StartStep","StopStep"
            break
        }

        # Amazon.SimpleSystemsManagement.StopType
        "Stop-SSMAutomationExecution/Type"
        {
            $v = "Cancel","Complete"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SSM_map = @{
    "ApprovedPatchesComplianceLevel"=@("New-SSMPatchBaseline","Update-SSMPatchBaseline")
    "AssociationStatus_Name"=@("Update-SSMAssociationStatus")
    "BaselineOverride_ApprovedPatchesComplianceLevel"=@("Get-SSMDeployablePatchSnapshotForInstance")
    "BaselineOverride_OperatingSystem"=@("Get-SSMDeployablePatchSnapshotForInstance")
    "BaselineOverride_RejectedPatchesAction"=@("Get-SSMDeployablePatchSnapshotForInstance")
    "ComplianceSeverity"=@("New-SSMAssociation","Update-SSMAssociation")
    "CutoffBehavior"=@("Register-SSMTaskWithMaintenanceWindow","Update-SSMMaintenanceWindowTask")
    "DocumentFormat"=@("Get-SSMDocument","New-SSMDocument","Update-SSMDocument")
    "DocumentHashType"=@("Send-SSMCommand")
    "DocumentReviews_Action"=@("Update-SSMDocumentMetadata")
    "DocumentType"=@("New-SSMDocument")
    "Metadata"=@("Get-SSMDocumentMetadataHistory")
    "Mode"=@("Start-SSMAutomationExecution")
    "NotificationConfig_NotificationType"=@("Send-SSMCommand")
    "OperatingSystem"=@("Get-SSMDefaultPatchBaseline","Get-SSMPatchBaselineForPatchGroup","Get-SSMPatchProperty","New-SSMPatchBaseline")
    "PatchSet"=@("Get-SSMPatchProperty")
    "PermissionType"=@("Edit-SSMDocumentPermission","Get-SSMDocumentPermission")
    "Property"=@("Get-SSMPatchProperty")
    "RejectedPatchesAction"=@("New-SSMPatchBaseline","Update-SSMPatchBaseline")
    "ResourceType"=@("Add-SSMResourceTag","Get-SSMMaintenanceWindowSchedule","Get-SSMMaintenanceWindowsForTarget","Get-SSMResourceTag","Register-SSMTargetWithMaintenanceWindow","Remove-SSMResourceTag")
    "S3Destination_SyncFormat"=@("New-SSMResourceDataSync")
    "SchemaDeleteOption"=@("Remove-SSMInventory")
    "SignalType"=@("Send-SSMAutomationSignal")
    "State"=@("Get-SSMSession")
    "Status"=@("Update-SSMOpsItem")
    "SyncCompliance"=@("New-SSMAssociation","Update-SSMAssociation")
    "TaskInvocationParameters_RunCommand_DocumentHashType"=@("Register-SSMTaskWithMaintenanceWindow","Update-SSMMaintenanceWindowTask")
    "TaskInvocationParameters_RunCommand_NotificationConfig_NotificationType"=@("Register-SSMTaskWithMaintenanceWindow","Update-SSMMaintenanceWindowTask")
    "TaskType"=@("Register-SSMTaskWithMaintenanceWindow")
    "Tier"=@("Write-SSMParameter")
    "Type"=@("Stop-SSMAutomationExecution","Write-SSMParameter")
    "UploadType"=@("Write-SSMComplianceItem")
}

_awsArgumentCompleterRegistration $SSM_Completers $SSM_map

$SSM_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.SSM.$($commandName.Replace('-', ''))Cmdlet]"
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

$SSM_SelectMap = @{
    "Select"=@("Add-SSMResourceTag",
               "Register-SSMOpsItemRelatedItem",
               "Stop-SSMCommand",
               "Stop-SSMMaintenanceWindowExecution",
               "New-SSMActivation",
               "New-SSMAssociation",
               "New-SSMAssociationFromBatch",
               "New-SSMDocument",
               "New-SSMMaintenanceWindow",
               "New-SSMOpsItem",
               "New-SSMOpsMetadata",
               "New-SSMPatchBaseline",
               "New-SSMResourceDataSync",
               "Remove-SSMActivation",
               "Remove-SSMAssociation",
               "Remove-SSMDocument",
               "Remove-SSMInventory",
               "Remove-SSMMaintenanceWindow",
               "Remove-SSMOpsMetadata",
               "Remove-SSMParameter",
               "Remove-SSMParameterCollection",
               "Remove-SSMPatchBaseline",
               "Remove-SSMResourceDataSync",
               "Unregister-SSMManagedInstance",
               "Unregister-SSMPatchBaselineForPatchGroup",
               "Unregister-SSMTargetFromMaintenanceWindow",
               "Unregister-SSMTaskFromMaintenanceWindow",
               "Get-SSMActivation",
               "Get-SSMAssociation",
               "Get-SSMAssociationExecution",
               "Get-SSMAssociationExecutionTarget",
               "Get-SSMAutomationExecutionList",
               "Get-SSMAutomationStepExecution",
               "Get-SSMAvailablePatch",
               "Get-SSMDocumentDescription",
               "Get-SSMDocumentPermission",
               "Get-SSMEffectiveInstanceAssociationList",
               "Get-SSMEffectivePatchesForPatchBaseline",
               "Get-SSMInstanceAssociationsStatus",
               "Get-SSMInstanceInformation",
               "Get-SSMInstancePatch",
               "Get-SSMInstancePatchState",
               "Get-SSMInstancePatchStatesForPatchGroup",
               "Get-SSMInventoryDeletionList",
               "Get-SSMMaintenanceWindowExecutionList",
               "Get-SSMMaintenanceWindowExecutionTaskInvocationList",
               "Get-SSMMaintenanceWindowExecutionTaskList",
               "Get-SSMMaintenanceWindowList",
               "Get-SSMMaintenanceWindowSchedule",
               "Get-SSMMaintenanceWindowsForTarget",
               "Get-SSMMaintenanceWindowTarget",
               "Get-SSMMaintenanceWindowTaskList",
               "Get-SSMOpsItemSummary",
               "Get-SSMParameterList",
               "Get-SSMPatchBaseline",
               "Get-SSMPatchGroup",
               "Get-SSMPatchGroupState",
               "Get-SSMPatchProperty",
               "Get-SSMSession",
               "Unregister-SSMOpsItemRelatedItem",
               "Get-SSMAutomationExecution",
               "Get-SSMCalendarState",
               "Get-SSMCommandInvocationDetail",
               "Get-SSMConnectionStatus",
               "Get-SSMDefaultPatchBaseline",
               "Get-SSMDeployablePatchSnapshotForInstance",
               "Get-SSMDocument",
               "Get-SSMInventory",
               "Get-SSMInventorySchema",
               "Get-SSMMaintenanceWindow",
               "Get-SSMMaintenanceWindowExecution",
               "Get-SSMMaintenanceWindowExecutionTask",
               "Get-SSMMaintenanceWindowExecutionTaskInvocation",
               "Get-SSMMaintenanceWindowTask",
               "Get-SSMOpsItem",
               "Get-SSMOpsMetadata",
               "Get-SSMOpsSummary",
               "Get-SSMParameter",
               "Get-SSMParameterHistory",
               "Get-SSMParameterValue",
               "Get-SSMParametersByPath",
               "Get-SSMPatchBaselineDetail",
               "Get-SSMPatchBaselineForPatchGroup",
               "Get-SSMServiceSetting",
               "Set-SSMParameterVersionLabel",
               "Get-SSMAssociationList",
               "Get-SSMAssociationVersionList",
               "Get-SSMCommandInvocation",
               "Get-SSMCommand",
               "Get-SSMComplianceItemList",
               "Get-SSMComplianceSummaryList",
               "Get-SSMDocumentMetadataHistory",
               "Get-SSMDocumentList",
               "Get-SSMDocumentVersionList",
               "Get-SSMInventoryEntryList",
               "Get-SSMOpsItemEvent",
               "Get-SSMOpsItemRelatedItem",
               "Get-SSMOpsMetadataList",
               "Get-SSMResourceComplianceSummaryList",
               "Get-SSMResourceDataSync",
               "Get-SSMResourceTag",
               "Edit-SSMDocumentPermission",
               "Write-SSMComplianceItem",
               "Write-SSMInventory",
               "Write-SSMParameter",
               "Register-SSMDefaultPatchBaseline",
               "Register-SSMPatchBaselineForPatchGroup",
               "Register-SSMTargetWithMaintenanceWindow",
               "Register-SSMTaskWithMaintenanceWindow",
               "Remove-SSMResourceTag",
               "Reset-SSMServiceSetting",
               "Resume-SSMSession",
               "Send-SSMAutomationSignal",
               "Send-SSMCommand",
               "Start-SSMAssociationsOnce",
               "Start-SSMAutomationExecution",
               "Start-SSMChangeRequestExecution",
               "Start-SSMSession",
               "Stop-SSMAutomationExecution",
               "Stop-SSMSession",
               "Reset-SSMParameterVersionLabel",
               "Update-SSMAssociation",
               "Update-SSMAssociationStatus",
               "Update-SSMDocument",
               "Update-SSMDocumentDefaultVersion",
               "Update-SSMDocumentMetadata",
               "Update-SSMMaintenanceWindow",
               "Update-SSMMaintenanceWindowTarget",
               "Update-SSMMaintenanceWindowTask",
               "Update-SSMManagedInstanceRole",
               "Update-SSMOpsItem",
               "Update-SSMOpsMetadata",
               "Update-SSMPatchBaseline",
               "Update-SSMResourceDataSync",
               "Update-SSMServiceSetting",
               "Get-SSMLatestEC2Image")
}

_awsArgumentCompleterRegistration $SSM_SelectCompleters $SSM_SelectMap

