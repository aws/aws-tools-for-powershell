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

# Argument completions for service AWS Clean Rooms Service


$CRS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CleanRooms.AdditionalAnalyses
        {
            ($_ -eq "New-CRSConfiguredTableAnalysisRule/Aggregation_AdditionalAnalysis") -Or
            ($_ -eq "Update-CRSConfiguredTableAnalysisRule/Aggregation_AdditionalAnalysis") -Or
            ($_ -eq "New-CRSConfiguredTableAnalysisRule/Custom_AdditionalAnalysis") -Or
            ($_ -eq "Update-CRSConfiguredTableAnalysisRule/Custom_AdditionalAnalysis") -Or
            ($_ -eq "New-CRSConfiguredTableAnalysisRule/List_AdditionalAnalysis") -Or
            ($_ -eq "Update-CRSConfiguredTableAnalysisRule/List_AdditionalAnalysis")
        }
        {
            $v = "ALLOWED","NOT_ALLOWED","REQUIRED"
            break
        }

        # Amazon.CleanRooms.AnalysisFormat
        "New-CRSAnalysisTemplate/Format"
        {
            $v = "PYSPARK_1_0","SQL"
            break
        }

        # Amazon.CleanRooms.AnalysisMethod
        {
            ($_ -eq "New-CRSConfiguredTable/AnalysisMethod") -Or
            ($_ -eq "Update-CRSConfiguredTable/AnalysisMethod")
        }
        {
            $v = "DIRECT_JOB","DIRECT_QUERY","MULTIPLE"
            break
        }

        # Amazon.CleanRooms.AnalysisRuleType
        "Get-CRSSchemaAnalysisRule/Type"
        {
            $v = "AGGREGATION","CUSTOM","ID_MAPPING_TABLE","LIST"
            break
        }

        # Amazon.CleanRooms.AnalyticsEngine
        {
            ($_ -eq "New-CRSCollaboration/AnalyticsEngine") -Or
            ($_ -eq "Update-CRSCollaboration/AnalyticsEngine")
        }
        {
            $v = "CLEAN_ROOMS_SQL","SPARK"
            break
        }

        # Amazon.CleanRooms.ChangeRequestStatus
        "Get-CRSCollaborationChangeRequestList/Status"
        {
            $v = "APPROVED","CANCELLED","COMMITTED","DENIED","PENDING"
            break
        }

        # Amazon.CleanRooms.CollaborationJobLogStatus
        "New-CRSCollaboration/JobLogStatus"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.CleanRooms.CollaborationQueryLogStatus
        "New-CRSCollaboration/QueryLogStatus"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.CleanRooms.ConfiguredTableAnalysisRuleType
        {
            ($_ -eq "Get-CRSConfiguredTableAnalysisRule/AnalysisRuleType") -Or
            ($_ -eq "New-CRSConfiguredTableAnalysisRule/AnalysisRuleType") -Or
            ($_ -eq "Remove-CRSConfiguredTableAnalysisRule/AnalysisRuleType") -Or
            ($_ -eq "Update-CRSConfiguredTableAnalysisRule/AnalysisRuleType")
        }
        {
            $v = "AGGREGATION","CUSTOM","LIST"
            break
        }

        # Amazon.CleanRooms.ConfiguredTableAssociationAnalysisRuleType
        {
            ($_ -eq "Get-CRSConfiguredTableAssociationAnalysisRule/AnalysisRuleType") -Or
            ($_ -eq "New-CRSConfiguredTableAssociationAnalysisRule/AnalysisRuleType") -Or
            ($_ -eq "Remove-CRSConfiguredTableAssociationAnalysisRule/AnalysisRuleType") -Or
            ($_ -eq "Update-CRSConfiguredTableAssociationAnalysisRule/AnalysisRuleType")
        }
        {
            $v = "AGGREGATION","CUSTOM","LIST"
            break
        }

        # Amazon.CleanRooms.ErrorMessageType
        "New-CRSAnalysisTemplate/ErrorMessageConfiguration_Type"
        {
            $v = "DETAILED"
            break
        }

        # Amazon.CleanRooms.FilterableMemberStatus
        "Get-CRSCollaborationList/MemberStatus"
        {
            $v = "ACTIVE","INVITED"
            break
        }

        # Amazon.CleanRooms.JobType
        "Invoke-CRSIdMappingTable/JobType"
        {
            $v = "BATCH","DELETE_ONLY","INCREMENTAL"
            break
        }

        # Amazon.CleanRooms.JoinRequiredOption
        {
            ($_ -eq "New-CRSConfiguredTableAnalysisRule/Aggregation_JoinRequired") -Or
            ($_ -eq "Update-CRSConfiguredTableAnalysisRule/Aggregation_JoinRequired")
        }
        {
            $v = "QUERY_RUNNER"
            break
        }

        # Amazon.CleanRooms.MembershipJobLogStatus
        {
            ($_ -eq "New-CRSMembership/JobLogStatus") -Or
            ($_ -eq "Update-CRSMembership/JobLogStatus")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.CleanRooms.MembershipQueryLogStatus
        {
            ($_ -eq "New-CRSMembership/QueryLogStatus") -Or
            ($_ -eq "Update-CRSMembership/QueryLogStatus")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.CleanRooms.MembershipStatus
        "Get-CRSMembershipList/Status"
        {
            $v = "ACTIVE","COLLABORATION_DELETED","REMOVED"
            break
        }

        # Amazon.CleanRooms.PrivacyBudgetTemplateAutoRefresh
        "New-CRSPrivacyBudgetTemplate/AutoRefresh"
        {
            $v = "CALENDAR_MONTH","NONE"
            break
        }

        # Amazon.CleanRooms.PrivacyBudgetType
        {
            ($_ -eq "Get-CRSCollaborationPrivacyBudgetList/PrivacyBudgetType") -Or
            ($_ -eq "Get-CRSPrivacyBudgetList/PrivacyBudgetType") -Or
            ($_ -eq "New-CRSPrivacyBudgetTemplate/PrivacyBudgetType") -Or
            ($_ -eq "Update-CRSPrivacyBudgetTemplate/PrivacyBudgetType")
        }
        {
            $v = "DIFFERENTIAL_PRIVACY"
            break
        }

        # Amazon.CleanRooms.ProtectedJobStatus
        "Get-CRSProtectedJobList/Status"
        {
            $v = "CANCELLED","CANCELLING","FAILED","STARTED","SUBMITTED","SUCCESS"
            break
        }

        # Amazon.CleanRooms.ProtectedJobType
        "Start-CRSProtectedJob/Type"
        {
            $v = "PYSPARK"
            break
        }

        # Amazon.CleanRooms.ProtectedJobWorkerComputeType
        "Start-CRSProtectedJob/Worker_Type"
        {
            $v = "CR.1X","CR.4X"
            break
        }

        # Amazon.CleanRooms.ProtectedQueryStatus
        "Get-CRSProtectedQueryList/Status"
        {
            $v = "CANCELLED","CANCELLING","FAILED","STARTED","SUBMITTED","SUCCESS","TIMED_OUT"
            break
        }

        # Amazon.CleanRooms.ProtectedQueryType
        "Start-CRSProtectedQuery/Type"
        {
            $v = "SQL"
            break
        }

        # Amazon.CleanRooms.ResultFormat
        {
            ($_ -eq "New-CRSMembership/S3_ResultFormat") -Or
            ($_ -eq "Start-CRSProtectedQuery/S3_ResultFormat") -Or
            ($_ -eq "Update-CRSMembership/S3_ResultFormat")
        }
        {
            $v = "CSV","PARQUET"
            break
        }

        # Amazon.CleanRooms.SchemaType
        "Get-CRSSchemaList/SchemaType"
        {
            $v = "ID_MAPPING_TABLE","TABLE"
            break
        }

        # Amazon.CleanRooms.TargetProtectedJobStatus
        "Update-CRSProtectedJob/TargetStatus"
        {
            $v = "CANCELLED"
            break
        }

        # Amazon.CleanRooms.TargetProtectedQueryStatus
        "Update-CRSProtectedQuery/TargetStatus"
        {
            $v = "CANCELLED"
            break
        }

        # Amazon.CleanRooms.WorkerComputeType
        "Start-CRSProtectedQuery/Worker_Type"
        {
            $v = "CR.1X","CR.4X"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CRS_map = @{
    "Aggregation_AdditionalAnalysis"=@("New-CRSConfiguredTableAnalysisRule","Update-CRSConfiguredTableAnalysisRule")
    "Aggregation_JoinRequired"=@("New-CRSConfiguredTableAnalysisRule","Update-CRSConfiguredTableAnalysisRule")
    "AnalysisMethod"=@("New-CRSConfiguredTable","Update-CRSConfiguredTable")
    "AnalysisRuleType"=@("Get-CRSConfiguredTableAnalysisRule","Get-CRSConfiguredTableAssociationAnalysisRule","New-CRSConfiguredTableAnalysisRule","New-CRSConfiguredTableAssociationAnalysisRule","Remove-CRSConfiguredTableAnalysisRule","Remove-CRSConfiguredTableAssociationAnalysisRule","Update-CRSConfiguredTableAnalysisRule","Update-CRSConfiguredTableAssociationAnalysisRule")
    "AnalyticsEngine"=@("New-CRSCollaboration","Update-CRSCollaboration")
    "AutoRefresh"=@("New-CRSPrivacyBudgetTemplate")
    "Custom_AdditionalAnalysis"=@("New-CRSConfiguredTableAnalysisRule","Update-CRSConfiguredTableAnalysisRule")
    "ErrorMessageConfiguration_Type"=@("New-CRSAnalysisTemplate")
    "Format"=@("New-CRSAnalysisTemplate")
    "JobLogStatus"=@("New-CRSCollaboration","New-CRSMembership","Update-CRSMembership")
    "JobType"=@("Invoke-CRSIdMappingTable")
    "List_AdditionalAnalysis"=@("New-CRSConfiguredTableAnalysisRule","Update-CRSConfiguredTableAnalysisRule")
    "MemberStatus"=@("Get-CRSCollaborationList")
    "PrivacyBudgetType"=@("Get-CRSCollaborationPrivacyBudgetList","Get-CRSPrivacyBudgetList","New-CRSPrivacyBudgetTemplate","Update-CRSPrivacyBudgetTemplate")
    "QueryLogStatus"=@("New-CRSCollaboration","New-CRSMembership","Update-CRSMembership")
    "S3_ResultFormat"=@("New-CRSMembership","Start-CRSProtectedQuery","Update-CRSMembership")
    "SchemaType"=@("Get-CRSSchemaList")
    "Status"=@("Get-CRSCollaborationChangeRequestList","Get-CRSMembershipList","Get-CRSProtectedJobList","Get-CRSProtectedQueryList")
    "TargetStatus"=@("Update-CRSProtectedJob","Update-CRSProtectedQuery")
    "Type"=@("Get-CRSSchemaAnalysisRule","Start-CRSProtectedJob","Start-CRSProtectedQuery")
    "Worker_Type"=@("Start-CRSProtectedJob","Start-CRSProtectedQuery")
}

_awsArgumentCompleterRegistration $CRS_Completers $CRS_map

$CRS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CRS.$($commandName.Replace('-', ''))Cmdlet]"
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

$CRS_SelectMap = @{
    "Select"=@("Get-CRSBatchCollaborationAnalysisTemplate",
               "Get-CRSBatchSchema",
               "Get-CRSBatchGetSchemaAnalysisRule",
               "New-CRSAnalysisTemplate",
               "New-CRSCollaboration",
               "New-CRSCollaborationChangeRequest",
               "New-CRSConfiguredAudienceModelAssociation",
               "New-CRSConfiguredTable",
               "New-CRSConfiguredTableAnalysisRule",
               "New-CRSConfiguredTableAssociation",
               "New-CRSConfiguredTableAssociationAnalysisRule",
               "New-CRSIdMappingTable",
               "New-CRSIdNamespaceAssociation",
               "New-CRSMembership",
               "New-CRSPrivacyBudgetTemplate",
               "Remove-CRSAnalysisTemplate",
               "Remove-CRSCollaboration",
               "Remove-CRSConfiguredAudienceModelAssociation",
               "Remove-CRSConfiguredTable",
               "Remove-CRSConfiguredTableAnalysisRule",
               "Remove-CRSConfiguredTableAssociation",
               "Remove-CRSConfiguredTableAssociationAnalysisRule",
               "Remove-CRSIdMappingTable",
               "Remove-CRSIdNamespaceAssociation",
               "Remove-CRSMember",
               "Remove-CRSMembership",
               "Remove-CRSPrivacyBudgetTemplate",
               "Get-CRSAnalysisTemplate",
               "Get-CRSCollaboration",
               "Get-CRSCollaborationAnalysisTemplate",
               "Get-CRSCollaborationChangeRequest",
               "Get-CRSCollaborationConfiguredAudienceModelAssociation",
               "Get-CRSCollaborationIdNamespaceAssociation",
               "Get-CRSCollaborationPrivacyBudgetTemplate",
               "Get-CRSConfiguredAudienceModelAssociation",
               "Get-CRSConfiguredTable",
               "Get-CRSConfiguredTableAnalysisRule",
               "Get-CRSConfiguredTableAssociation",
               "Get-CRSConfiguredTableAssociationAnalysisRule",
               "Get-CRSIdMappingTable",
               "Get-CRSIdNamespaceAssociation",
               "Get-CRSMembership",
               "Get-CRSPrivacyBudgetTemplate",
               "Get-CRSProtectedJob",
               "Get-CRSProtectedQuery",
               "Get-CRSSchema",
               "Get-CRSSchemaAnalysisRule",
               "Get-CRSAnalysisTemplateList",
               "Get-CRSCollaborationAnalysisTemplateList",
               "Get-CRSCollaborationChangeRequestList",
               "Get-CRSCollaborationConfiguredAudienceModelAssociationList",
               "Get-CRSCollaborationIdNamespaceAssociationList",
               "Get-CRSCollaborationPrivacyBudgetList",
               "Get-CRSCollaborationPrivacyBudgetTemplateList",
               "Get-CRSCollaborationList",
               "Get-CRSConfiguredAudienceModelAssociationList",
               "Get-CRSConfiguredTableAssociationList",
               "Get-CRSConfiguredTableList",
               "Get-CRSIdMappingTableList",
               "Get-CRSIdNamespaceAssociationList",
               "Get-CRSMemberList",
               "Get-CRSMembershipList",
               "Get-CRSPrivacyBudgetList",
               "Get-CRSPrivacyBudgetTemplateList",
               "Get-CRSProtectedJobList",
               "Get-CRSProtectedQueryList",
               "Get-CRSSchemaList",
               "Get-CRSResourceTag",
               "Invoke-CRSIdMappingTable",
               "Test-CRSPrivacyImpact",
               "Start-CRSProtectedJob",
               "Start-CRSProtectedQuery",
               "Add-CRSResourceTag",
               "Remove-CRSResourceTag",
               "Update-CRSAnalysisTemplate",
               "Update-CRSCollaboration",
               "Update-CRSConfiguredAudienceModelAssociation",
               "Update-CRSConfiguredTable",
               "Update-CRSConfiguredTableAnalysisRule",
               "Update-CRSConfiguredTableAssociation",
               "Update-CRSConfiguredTableAssociationAnalysisRule",
               "Update-CRSIdMappingTable",
               "Update-CRSIdNamespaceAssociation",
               "Update-CRSMembership",
               "Update-CRSPrivacyBudgetTemplate",
               "Update-CRSProtectedJob",
               "Update-CRSProtectedQuery")
}

_awsArgumentCompleterRegistration $CRS_SelectCompleters $CRS_SelectMap

