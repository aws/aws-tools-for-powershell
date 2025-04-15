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

# Argument completions for service Amazon QuickSight


$QS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.QuickSight.AssetBundleExportFormat
        "Start-QSAssetBundleExportJob/ExportFormat"
        {
            $v = "CLOUDFORMATION_JSON","QUICKSIGHT_JSON"
            break
        }

        # Amazon.QuickSight.AssetBundleImportFailureAction
        "Start-QSAssetBundleImportJob/FailureAction"
        {
            $v = "DO_NOTHING","ROLLBACK"
            break
        }

        # Amazon.QuickSight.AssignmentStatus
        {
            ($_ -eq "Get-QSIAMPolicyAssignmentList/AssignmentStatus") -Or
            ($_ -eq "New-QSIAMPolicyAssignment/AssignmentStatus") -Or
            ($_ -eq "Update-QSIAMPolicyAssignment/AssignmentStatus")
        }
        {
            $v = "DISABLED","DRAFT","ENABLED"
            break
        }

        # Amazon.QuickSight.AuthenticationMethodOption
        "New-QSAccountSubscription/AuthenticationMethod"
        {
            $v = "ACTIVE_DIRECTORY","IAM_AND_QUICKSIGHT","IAM_IDENTITY_CENTER","IAM_ONLY"
            break
        }

        # Amazon.QuickSight.AuthenticationType
        {
            ($_ -eq "New-QSDataSource/SnowflakeParameters_AuthenticationType") -Or
            ($_ -eq "Update-QSDataSource/SnowflakeParameters_AuthenticationType") -Or
            ($_ -eq "New-QSDataSource/StarburstParameters_AuthenticationType") -Or
            ($_ -eq "Update-QSDataSource/StarburstParameters_AuthenticationType")
        }
        {
            $v = "PASSWORD","TOKEN","X509"
            break
        }

        # Amazon.QuickSight.CapabilityState
        {
            ($_ -eq "New-QSCustomPermission/Capabilities_AddOrRunAnomalyDetectionForAnalyses") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_AddOrRunAnomalyDetectionForAnalyses") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateDashboardEmailReport") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateDashboardEmailReport") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateDataset") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateDataset") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateDataSource") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateDataSource") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateTheme") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateTheme") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateThresholdAlert") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateThresholdAlert") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateSharedFolder") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateSharedFolder") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateSPICEDataset") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateSPICEDataset") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ExportToCsv") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ExportToCsv") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ExportToExcel") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ExportToExcel") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_RenameSharedFolder") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_RenameSharedFolder") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareAnalyses") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareAnalyses") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareDashboard") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareDashboard") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareDataset") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareDataset") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareDataSource") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareDataSource") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_SubscribeDashboardEmailReport") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_SubscribeDashboardEmailReport") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ViewAccountSPICECapacity") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ViewAccountSPICECapacity")
        }
        {
            $v = "DENY"
            break
        }

        # Amazon.QuickSight.DashboardBehavior
        {
            ($_ -eq "New-QSDashboard/AdHocFilteringOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/AdHocFilteringOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/DataPointDrillUpDownOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/DataPointDrillUpDownOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/DataPointMenuLabelOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/DataPointMenuLabelOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/DataPointTooltipOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/DataPointTooltipOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/DataQAEnabledOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/DataQAEnabledOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/ExportHiddenFieldsOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/ExportHiddenFieldsOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/ExportToCSVOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/ExportToCSVOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/ExportWithHiddenFieldsOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/ExportWithHiddenFieldsOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/SheetLayoutElementMaximizationOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/SheetLayoutElementMaximizationOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/VisualAxisSortOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/VisualAxisSortOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/VisualMenuOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/VisualMenuOption_AvailabilityStatus")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.QuickSight.DashboardsQAStatus
        "Update-QSDashboardsQAConfiguration/DashboardsQAStatus"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.QuickSight.DashboardUIState
        {
            ($_ -eq "New-QSDashboard/SheetControlsOption_VisibilityState") -Or
            ($_ -eq "Update-QSDashboard/SheetControlsOption_VisibilityState")
        }
        {
            $v = "COLLAPSED","EXPANDED"
            break
        }

        # Amazon.QuickSight.DataSetImportMode
        {
            ($_ -eq "New-QSDataSet/ImportMode") -Or
            ($_ -eq "Update-QSDataSet/ImportMode")
        }
        {
            $v = "DIRECT_QUERY","SPICE"
            break
        }

        # Amazon.QuickSight.DataSetUseAs
        "New-QSDataSet/UseAs"
        {
            $v = "RLS_RULES"
            break
        }

        # Amazon.QuickSight.DataSourceType
        "New-QSDataSource/Type"
        {
            $v = "ADOBE_ANALYTICS","AMAZON_ELASTICSEARCH","AMAZON_OPENSEARCH","ATHENA","AURORA","AURORA_POSTGRESQL","AWS_IOT_ANALYTICS","BIGQUERY","DATABRICKS","EXASOL","GITHUB","JIRA","MARIADB","MYSQL","ORACLE","POSTGRESQL","PRESTO","REDSHIFT","S3","SALESFORCE","SERVICENOW","SNOWFLAKE","SPARK","SQLSERVER","STARBURST","TERADATA","TIMESTREAM","TRINO","TWITTER"
            break
        }

        # Amazon.QuickSight.DayOfTheWeek
        {
            ($_ -eq "New-QSAnalysis/Options_WeekStart") -Or
            ($_ -eq "New-QSDashboard/Options_WeekStart") -Or
            ($_ -eq "New-QSTemplate/Options_WeekStart") -Or
            ($_ -eq "Update-QSAnalysis/Options_WeekStart") -Or
            ($_ -eq "Update-QSDashboard/Options_WeekStart") -Or
            ($_ -eq "Update-QSTemplate/Options_WeekStart")
        }
        {
            $v = "FRIDAY","MONDAY","SATURDAY","SUNDAY","THURSDAY","TUESDAY","WEDNESDAY"
            break
        }

        # Amazon.QuickSight.DayOfWeek
        {
            ($_ -eq "New-QSRefreshSchedule/RefreshOnDay_DayOfWeek") -Or
            ($_ -eq "Update-QSRefreshSchedule/RefreshOnDay_DayOfWeek")
        }
        {
            $v = "FRIDAY","MONDAY","SATURDAY","SUNDAY","THURSDAY","TUESDAY","WEDNESDAY"
            break
        }

        # Amazon.QuickSight.Edition
        "New-QSAccountSubscription/Edition"
        {
            $v = "ENTERPRISE","ENTERPRISE_AND_Q","STANDARD"
            break
        }

        # Amazon.QuickSight.EmbeddingIdentityType
        "Get-QSDashboardEmbedUrl/IdentityType"
        {
            $v = "ANONYMOUS","IAM","QUICKSIGHT"
            break
        }

        # Amazon.QuickSight.FolderType
        "New-QSFolder/FolderType"
        {
            $v = "RESTRICTED","SHARED"
            break
        }

        # Amazon.QuickSight.IdentityStore
        "New-QSNamespace/IdentityStore"
        {
            $v = "QUICKSIGHT"
            break
        }

        # Amazon.QuickSight.IdentityType
        "Register-QSUser/IdentityType"
        {
            $v = "IAM","IAM_IDENTITY_CENTER","QUICKSIGHT"
            break
        }

        # Amazon.QuickSight.IncludeFolderMembers
        "Start-QSAssetBundleExportJob/IncludeFolderMember"
        {
            $v = "NONE","ONE_LEVEL","RECURSE"
            break
        }

        # Amazon.QuickSight.IncludeGeneratedAnswer
        "Search-QSQAResult/IncludeGeneratedAnswer"
        {
            $v = "EXCLUDE","INCLUDE"
            break
        }

        # Amazon.QuickSight.IncludeQuickSightQIndex
        "Search-QSQAResult/IncludeQuickSightQIndex"
        {
            $v = "EXCLUDE","INCLUDE"
            break
        }

        # Amazon.QuickSight.IngestionType
        {
            ($_ -eq "New-QSIngestion/IngestionType") -Or
            ($_ -eq "New-QSRefreshSchedule/Schedule_RefreshType") -Or
            ($_ -eq "Update-QSRefreshSchedule/Schedule_RefreshType")
        }
        {
            $v = "FULL_REFRESH","INCREMENTAL_REFRESH"
            break
        }

        # Amazon.QuickSight.LookbackWindowSizeUnit
        "Write-QSDataSetRefreshProperty/LookbackWindow_SizeUnit"
        {
            $v = "DAY","HOUR","WEEK"
            break
        }

        # Amazon.QuickSight.MemberType
        {
            ($_ -eq "New-QSFolderMembership/MemberType") -Or
            ($_ -eq "Remove-QSFolderMembership/MemberType")
        }
        {
            $v = "ANALYSIS","DASHBOARD","DATASET","DATASOURCE","TOPIC"
            break
        }

        # Amazon.QuickSight.PaperOrientation
        {
            ($_ -eq "New-QSAnalysis/PaperCanvasSizeOptions_PaperOrientation") -Or
            ($_ -eq "New-QSDashboard/PaperCanvasSizeOptions_PaperOrientation") -Or
            ($_ -eq "New-QSTemplate/PaperCanvasSizeOptions_PaperOrientation") -Or
            ($_ -eq "Update-QSAnalysis/PaperCanvasSizeOptions_PaperOrientation") -Or
            ($_ -eq "Update-QSDashboard/PaperCanvasSizeOptions_PaperOrientation") -Or
            ($_ -eq "Update-QSTemplate/PaperCanvasSizeOptions_PaperOrientation")
        }
        {
            $v = "LANDSCAPE","PORTRAIT"
            break
        }

        # Amazon.QuickSight.PaperSize
        {
            ($_ -eq "New-QSAnalysis/PaperCanvasSizeOptions_PaperSize") -Or
            ($_ -eq "New-QSDashboard/PaperCanvasSizeOptions_PaperSize") -Or
            ($_ -eq "New-QSTemplate/PaperCanvasSizeOptions_PaperSize") -Or
            ($_ -eq "Update-QSAnalysis/PaperCanvasSizeOptions_PaperSize") -Or
            ($_ -eq "Update-QSDashboard/PaperCanvasSizeOptions_PaperSize") -Or
            ($_ -eq "Update-QSTemplate/PaperCanvasSizeOptions_PaperSize")
        }
        {
            $v = "A0","A1","A2","A3","A4","A5","JIS_B4","JIS_B5","US_LEGAL","US_LETTER","US_TABLOID_LEDGER"
            break
        }

        # Amazon.QuickSight.PersonalizationMode
        "Update-QSQPersonalizationConfiguration/PersonalizationMode"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.QuickSight.PurchaseMode
        "Update-QSSPICECapacityConfiguration/PurchaseMode"
        {
            $v = "AUTO_PURCHASE","MANUAL"
            break
        }

        # Amazon.QuickSight.QBusinessInsightsStatus
        {
            ($_ -eq "New-QSAnalysis/Options_QBusinessInsightsStatus") -Or
            ($_ -eq "New-QSDashboard/Options_QBusinessInsightsStatus") -Or
            ($_ -eq "New-QSTemplate/Options_QBusinessInsightsStatus") -Or
            ($_ -eq "Update-QSAnalysis/Options_QBusinessInsightsStatus") -Or
            ($_ -eq "Update-QSDashboard/Options_QBusinessInsightsStatus") -Or
            ($_ -eq "Update-QSTemplate/Options_QBusinessInsightsStatus")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.QuickSight.QSearchStatus
        "Update-QSQuickSightQSearchConfiguration/QSearchStatus"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.QuickSight.QueryExecutionMode
        {
            ($_ -eq "New-QSAnalysis/QueryExecutionOptions_QueryExecutionMode") -Or
            ($_ -eq "New-QSTemplate/QueryExecutionOptions_QueryExecutionMode") -Or
            ($_ -eq "Update-QSAnalysis/QueryExecutionOptions_QueryExecutionMode") -Or
            ($_ -eq "Update-QSTemplate/QueryExecutionOptions_QueryExecutionMode")
        }
        {
            $v = "AUTO","MANUAL"
            break
        }

        # Amazon.QuickSight.RefreshFailureAlertStatus
        "Write-QSDataSetRefreshProperty/EmailAlert_AlertStatus"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.QuickSight.RefreshInterval
        {
            ($_ -eq "New-QSRefreshSchedule/ScheduleFrequency_Interval") -Or
            ($_ -eq "Update-QSRefreshSchedule/ScheduleFrequency_Interval")
        }
        {
            $v = "DAILY","HOURLY","MINUTE15","MINUTE30","MONTHLY","WEEKLY"
            break
        }

        # Amazon.QuickSight.ResizeOption
        {
            ($_ -eq "New-QSAnalysis/ScreenCanvasSizeOptions_ResizeOption") -Or
            ($_ -eq "New-QSDashboard/ScreenCanvasSizeOptions_ResizeOption") -Or
            ($_ -eq "New-QSTemplate/ScreenCanvasSizeOptions_ResizeOption") -Or
            ($_ -eq "Update-QSAnalysis/ScreenCanvasSizeOptions_ResizeOption") -Or
            ($_ -eq "Update-QSDashboard/ScreenCanvasSizeOptions_ResizeOption") -Or
            ($_ -eq "Update-QSTemplate/ScreenCanvasSizeOptions_ResizeOption")
        }
        {
            $v = "FIXED","RESPONSIVE"
            break
        }

        # Amazon.QuickSight.Role
        {
            ($_ -eq "Get-QSRoleCustomPermission/Role") -Or
            ($_ -eq "Get-QSRoleMembershipList/Role") -Or
            ($_ -eq "New-QSRoleMembership/Role") -Or
            ($_ -eq "Remove-QSRoleCustomPermission/Role") -Or
            ($_ -eq "Remove-QSRoleMembership/Role") -Or
            ($_ -eq "Update-QSRoleCustomPermission/Role")
        }
        {
            $v = "ADMIN","ADMIN_PRO","AUTHOR","AUTHOR_PRO","READER","READER_PRO"
            break
        }

        # Amazon.QuickSight.RowLevelPermissionFormatVersion
        {
            ($_ -eq "New-QSDataSet/RowLevelPermissionDataSet_FormatVersion") -Or
            ($_ -eq "Update-QSDataSet/RowLevelPermissionDataSet_FormatVersion")
        }
        {
            $v = "VERSION_1","VERSION_2"
            break
        }

        # Amazon.QuickSight.RowLevelPermissionPolicy
        {
            ($_ -eq "New-QSDataSet/RowLevelPermissionDataSet_PermissionPolicy") -Or
            ($_ -eq "Update-QSDataSet/RowLevelPermissionDataSet_PermissionPolicy")
        }
        {
            $v = "DENY_ACCESS","GRANT_ACCESS"
            break
        }

        # Amazon.QuickSight.ServiceType
        {
            ($_ -eq "Remove-QSIdentityPropagationConfig/Service") -Or
            ($_ -eq "Update-QSIdentityPropagationConfig/Service")
        }
        {
            $v = "QBUSINESS","REDSHIFT"
            break
        }

        # Amazon.QuickSight.SharingModel
        "New-QSFolder/SharingModel"
        {
            $v = "ACCOUNT","NAMESPACE"
            break
        }

        # Amazon.QuickSight.SheetContentType
        {
            ($_ -eq "New-QSAnalysis/DefaultNewSheetConfiguration_SheetContentType") -Or
            ($_ -eq "New-QSDashboard/DefaultNewSheetConfiguration_SheetContentType") -Or
            ($_ -eq "New-QSTemplate/DefaultNewSheetConfiguration_SheetContentType") -Or
            ($_ -eq "Update-QSAnalysis/DefaultNewSheetConfiguration_SheetContentType") -Or
            ($_ -eq "Update-QSDashboard/DefaultNewSheetConfiguration_SheetContentType") -Or
            ($_ -eq "Update-QSTemplate/DefaultNewSheetConfiguration_SheetContentType")
        }
        {
            $v = "INTERACTIVE","PAGINATED"
            break
        }

        # Amazon.QuickSight.StarburstProductType
        {
            ($_ -eq "New-QSDataSource/StarburstParameters_ProductType") -Or
            ($_ -eq "Update-QSDataSource/StarburstParameters_ProductType")
        }
        {
            $v = "ENTERPRISE","GALAXY"
            break
        }

        # Amazon.QuickSight.Status
        {
            ($_ -eq "New-QSDataSet/RowLevelPermissionDataSet_Status") -Or
            ($_ -eq "Update-QSDataSet/RowLevelPermissionDataSet_Status") -Or
            ($_ -eq "New-QSDataSet/RowLevelPermissionTagConfiguration_Status") -Or
            ($_ -eq "Update-QSDataSet/RowLevelPermissionTagConfiguration_Status")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.QuickSight.ThemeType
        "Get-QSThemeList/Type"
        {
            $v = "ALL","CUSTOM","QUICKSIGHT"
            break
        }

        # Amazon.QuickSight.TopicScheduleType
        {
            ($_ -eq "New-QSTopicRefreshSchedule/RefreshSchedule_TopicScheduleType") -Or
            ($_ -eq "Update-QSTopicRefreshSchedule/RefreshSchedule_TopicScheduleType")
        }
        {
            $v = "DAILY","HOURLY","MONTHLY","WEEKLY"
            break
        }

        # Amazon.QuickSight.TopicUserExperienceVersion
        {
            ($_ -eq "New-QSTopic/Topic_UserExperienceVersion") -Or
            ($_ -eq "Update-QSTopic/Topic_UserExperienceVersion")
        }
        {
            $v = "LEGACY","NEW_READER_EXPERIENCE"
            break
        }

        # Amazon.QuickSight.UserRole
        {
            ($_ -eq "Update-QSUser/Role") -Or
            ($_ -eq "Register-QSUser/UserRole")
        }
        {
            $v = "ADMIN","ADMIN_PRO","AUTHOR","AUTHOR_PRO","READER","READER_PRO","RESTRICTED_AUTHOR","RESTRICTED_READER"
            break
        }

        # Amazon.QuickSight.ValidationStrategyMode
        {
            ($_ -eq "New-QSAnalysis/ValidationStrategy_Mode") -Or
            ($_ -eq "New-QSDashboard/ValidationStrategy_Mode") -Or
            ($_ -eq "New-QSTemplate/ValidationStrategy_Mode") -Or
            ($_ -eq "Update-QSAnalysis/ValidationStrategy_Mode") -Or
            ($_ -eq "Update-QSDashboard/ValidationStrategy_Mode") -Or
            ($_ -eq "Update-QSTemplate/ValidationStrategy_Mode")
        }
        {
            $v = "LENIENT","STRICT"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$QS_map = @{
    "AdHocFilteringOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "AssignmentStatus"=@("Get-QSIAMPolicyAssignmentList","New-QSIAMPolicyAssignment","Update-QSIAMPolicyAssignment")
    "AuthenticationMethod"=@("New-QSAccountSubscription")
    "Capabilities_AddOrRunAnomalyDetectionForAnalyses"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateDashboardEmailReport"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateDataset"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateDataSource"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateTheme"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateThresholdAlert"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateSharedFolder"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateSPICEDataset"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ExportToCsv"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ExportToExcel"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_RenameSharedFolder"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareAnalyses"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareDashboard"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareDataset"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareDataSource"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_SubscribeDashboardEmailReport"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ViewAccountSPICECapacity"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "DashboardsQAStatus"=@("Update-QSDashboardsQAConfiguration")
    "DataPointDrillUpDownOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "DataPointMenuLabelOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "DataPointTooltipOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "DataQAEnabledOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "DefaultNewSheetConfiguration_SheetContentType"=@("New-QSAnalysis","New-QSDashboard","New-QSTemplate","Update-QSAnalysis","Update-QSDashboard","Update-QSTemplate")
    "Edition"=@("New-QSAccountSubscription")
    "EmailAlert_AlertStatus"=@("Write-QSDataSetRefreshProperty")
    "ExportFormat"=@("Start-QSAssetBundleExportJob")
    "ExportHiddenFieldsOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "ExportToCSVOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "ExportWithHiddenFieldsOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "FailureAction"=@("Start-QSAssetBundleImportJob")
    "FolderType"=@("New-QSFolder")
    "IdentityStore"=@("New-QSNamespace")
    "IdentityType"=@("Get-QSDashboardEmbedUrl","Register-QSUser")
    "ImportMode"=@("New-QSDataSet","Update-QSDataSet")
    "IncludeFolderMember"=@("Start-QSAssetBundleExportJob")
    "IncludeGeneratedAnswer"=@("Search-QSQAResult")
    "IncludeQuickSightQIndex"=@("Search-QSQAResult")
    "IngestionType"=@("New-QSIngestion")
    "LookbackWindow_SizeUnit"=@("Write-QSDataSetRefreshProperty")
    "MemberType"=@("New-QSFolderMembership","Remove-QSFolderMembership")
    "Options_QBusinessInsightsStatus"=@("New-QSAnalysis","New-QSDashboard","New-QSTemplate","Update-QSAnalysis","Update-QSDashboard","Update-QSTemplate")
    "Options_WeekStart"=@("New-QSAnalysis","New-QSDashboard","New-QSTemplate","Update-QSAnalysis","Update-QSDashboard","Update-QSTemplate")
    "PaperCanvasSizeOptions_PaperOrientation"=@("New-QSAnalysis","New-QSDashboard","New-QSTemplate","Update-QSAnalysis","Update-QSDashboard","Update-QSTemplate")
    "PaperCanvasSizeOptions_PaperSize"=@("New-QSAnalysis","New-QSDashboard","New-QSTemplate","Update-QSAnalysis","Update-QSDashboard","Update-QSTemplate")
    "PersonalizationMode"=@("Update-QSQPersonalizationConfiguration")
    "PurchaseMode"=@("Update-QSSPICECapacityConfiguration")
    "QSearchStatus"=@("Update-QSQuickSightQSearchConfiguration")
    "QueryExecutionOptions_QueryExecutionMode"=@("New-QSAnalysis","New-QSTemplate","Update-QSAnalysis","Update-QSTemplate")
    "RefreshOnDay_DayOfWeek"=@("New-QSRefreshSchedule","Update-QSRefreshSchedule")
    "RefreshSchedule_TopicScheduleType"=@("New-QSTopicRefreshSchedule","Update-QSTopicRefreshSchedule")
    "Role"=@("Get-QSRoleCustomPermission","Get-QSRoleMembershipList","New-QSRoleMembership","Remove-QSRoleCustomPermission","Remove-QSRoleMembership","Update-QSRoleCustomPermission","Update-QSUser")
    "RowLevelPermissionDataSet_FormatVersion"=@("New-QSDataSet","Update-QSDataSet")
    "RowLevelPermissionDataSet_PermissionPolicy"=@("New-QSDataSet","Update-QSDataSet")
    "RowLevelPermissionDataSet_Status"=@("New-QSDataSet","Update-QSDataSet")
    "RowLevelPermissionTagConfiguration_Status"=@("New-QSDataSet","Update-QSDataSet")
    "Schedule_RefreshType"=@("New-QSRefreshSchedule","Update-QSRefreshSchedule")
    "ScheduleFrequency_Interval"=@("New-QSRefreshSchedule","Update-QSRefreshSchedule")
    "ScreenCanvasSizeOptions_ResizeOption"=@("New-QSAnalysis","New-QSDashboard","New-QSTemplate","Update-QSAnalysis","Update-QSDashboard","Update-QSTemplate")
    "Service"=@("Remove-QSIdentityPropagationConfig","Update-QSIdentityPropagationConfig")
    "SharingModel"=@("New-QSFolder")
    "SheetControlsOption_VisibilityState"=@("New-QSDashboard","Update-QSDashboard")
    "SheetLayoutElementMaximizationOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "SnowflakeParameters_AuthenticationType"=@("New-QSDataSource","Update-QSDataSource")
    "StarburstParameters_AuthenticationType"=@("New-QSDataSource","Update-QSDataSource")
    "StarburstParameters_ProductType"=@("New-QSDataSource","Update-QSDataSource")
    "Topic_UserExperienceVersion"=@("New-QSTopic","Update-QSTopic")
    "Type"=@("Get-QSThemeList","New-QSDataSource")
    "UseAs"=@("New-QSDataSet")
    "UserRole"=@("Register-QSUser")
    "ValidationStrategy_Mode"=@("New-QSAnalysis","New-QSDashboard","New-QSTemplate","Update-QSAnalysis","Update-QSDashboard","Update-QSTemplate")
    "VisualAxisSortOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "VisualMenuOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
}

_awsArgumentCompleterRegistration $QS_Completers $QS_map

$QS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.QS.$($commandName.Replace('-', ''))Cmdlet]"
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

$QS_SelectMap = @{
    "Select"=@("Set-QSBatchCreateTopicReviewedAnswer",
               "Set-QSBatchDeleteTopicReviewedAnswer",
               "Stop-QSIngestion",
               "New-QSAccountCustomization",
               "New-QSAccountSubscription",
               "New-QSAnalysis",
               "New-QSBrand",
               "New-QSCustomPermission",
               "New-QSDashboard",
               "New-QSDataSet",
               "New-QSDataSource",
               "New-QSFolder",
               "New-QSFolderMembership",
               "New-QSGroup",
               "New-QSGroupMembership",
               "New-QSIAMPolicyAssignment",
               "New-QSIngestion",
               "New-QSNamespace",
               "New-QSRefreshSchedule",
               "New-QSRoleMembership",
               "New-QSTemplate",
               "New-QSTemplateAlias",
               "New-QSTheme",
               "New-QSThemeAlias",
               "New-QSTopic",
               "New-QSTopicRefreshSchedule",
               "New-QSVPCConnection",
               "Remove-QSAccountCustomization",
               "Remove-QSAccountSubscription",
               "Remove-QSAnalysis",
               "Remove-QSBrand",
               "Remove-QSBrandAssignment",
               "Remove-QSCustomPermission",
               "Remove-QSDashboard",
               "Remove-QSDataSet",
               "Remove-QSDataSetRefreshProperty",
               "Remove-QSDataSource",
               "Remove-QSDefaultQBusinessApplication",
               "Remove-QSFolder",
               "Remove-QSFolderMembership",
               "Remove-QSGroup",
               "Remove-QSGroupMembership",
               "Remove-QSIAMPolicyAssignment",
               "Remove-QSIdentityPropagationConfig",
               "Remove-QSNamespace",
               "Remove-QSRefreshSchedule",
               "Remove-QSRoleCustomPermission",
               "Remove-QSRoleMembership",
               "Remove-QSTemplate",
               "Remove-QSTemplateAlias",
               "Remove-QSTheme",
               "Remove-QSThemeAlias",
               "Remove-QSTopic",
               "Remove-QSTopicRefreshSchedule",
               "Remove-QSUser",
               "Remove-QSUserByPrincipalId",
               "Remove-QSUserCustomPermission",
               "Remove-QSVPCConnection",
               "Get-QSAccountCustomization",
               "Get-QSAccountSetting",
               "Get-QSAccountSubscription",
               "Get-QSAnalysis",
               "Get-QSAnalysisDefinition",
               "Get-QSAnalysisPermission",
               "Get-QSAssetBundleExportJob",
               "Get-QSAssetBundleImportJob",
               "Get-QSBrand",
               "Get-QSBrandAssignment",
               "Get-QSBrandPublishedVersion",
               "Get-QSCustomPermission",
               "Get-QSDashboard",
               "Get-QSDashboardDefinition",
               "Get-QSDashboardPermission",
               "Get-QSDashboardSnapshotJob",
               "Get-QSDashboardSnapshotJobResult",
               "Get-QSDashboardsQAConfiguration",
               "Get-QSDataSet",
               "Get-QSDataSetPermission",
               "Get-QSDataSetRefreshProperty",
               "Get-QSDataSource",
               "Get-QSDataSourcePermission",
               "Get-QSDefaultQBusinessApplication",
               "Get-QSFolder",
               "Get-QSFolderPermission",
               "Get-QSFolderResolvedPermission",
               "Get-QSGroup",
               "Get-QSGroupMembership",
               "Get-QSIAMPolicyAssignment",
               "Get-QSIngestion",
               "Get-QSIpRestriction",
               "Get-QSKeyRegistration",
               "Get-QSNamespace",
               "Get-QSQPersonalizationConfiguration",
               "Get-QSQuickSightQSearchConfiguration",
               "Get-QSRefreshSchedule",
               "Get-QSRoleCustomPermission",
               "Get-QSTemplate",
               "Get-QSTemplateAlias",
               "Get-QSTemplateDefinition",
               "Get-QSTemplatePermission",
               "Get-QSTheme",
               "Get-QSThemeAlias",
               "Get-QSThemePermission",
               "Get-QSTopic",
               "Get-QSTopicPermission",
               "Get-QSTopicRefresh",
               "Get-QSTopicRefreshSchedule",
               "Get-QSUser",
               "Get-QSVPCConnection",
               "New-QSEmbedUrlForAnonymousUser",
               "New-QSEmbedUrlForRegisteredUser",
               "Initialize-QSEmbedUrlForRegisteredUserWithIdentity",
               "Get-QSDashboardEmbedUrl",
               "Get-QSSessionEmbedUrl",
               "Get-QSAnalysisList",
               "Get-QSAssetBundleExportJobList",
               "Get-QSAssetBundleImportJobList",
               "Get-QSBrandList",
               "Get-QSCustomPermissionList",
               "Get-QSDashboardList",
               "Get-QSDashboardVersionList",
               "Get-QSDataSetList",
               "Get-QSDataSourceList",
               "Get-QSFolderMemberList",
               "Get-QSFolderList",
               "Get-QSFoldersForResourceList",
               "Get-QSGroupMembershipList",
               "Get-QSGroupList",
               "Get-QSIAMPolicyAssignmentList",
               "Get-QSIAMPolicyAssignmentsForUserList",
               "Get-QSIdentityPropagationConfigList",
               "Get-QSIngestionList",
               "Get-QSNamespaceList",
               "Get-QSRefreshScheduleList",
               "Get-QSRoleMembershipList",
               "Get-QSResourceTag",
               "Get-QSTemplateAliasList",
               "Get-QSTemplateList",
               "Get-QSTemplateVersionList",
               "Get-QSThemeAliasList",
               "Get-QSThemeList",
               "Get-QSThemeVersionList",
               "Get-QSTopicRefreshScheduleList",
               "Get-QSTopicReviewedAnswerList",
               "Get-QSTopicList",
               "Get-QSUserGroupList",
               "Get-QSUserList",
               "Get-QSVPCConnectionList",
               "Search-QSQAResult",
               "Write-QSDataSetRefreshProperty",
               "Register-QSUser",
               "Restore-QSAnalysis",
               "Search-QSAnalysis",
               "Search-QSDashboard",
               "Search-QSDataSet",
               "Search-QSDataSource",
               "Search-QSFolder",
               "Find-QSGroup",
               "Search-QSTopic",
               "Start-QSAssetBundleExportJob",
               "Start-QSAssetBundleImportJob",
               "Start-QSDashboardSnapshotJob",
               "Start-QSDashboardSnapshotJobSchedule",
               "Add-QSResourceTag",
               "Remove-QSResourceTag",
               "Update-QSAccountCustomization",
               "Update-QSAccountSetting",
               "Update-QSAnalysis",
               "Update-QSAnalysisPermission",
               "Update-QSApplicationWithTokenExchangeGrant",
               "Update-QSBrand",
               "Update-QSBrandAssignment",
               "Update-QSBrandPublishedVersion",
               "Update-QSCustomPermission",
               "Update-QSDashboard",
               "Update-QSDashboardLink",
               "Update-QSDashboardPermission",
               "Update-QSDashboardPublishedVersion",
               "Update-QSDashboardsQAConfiguration",
               "Update-QSDataSet",
               "Update-QSDataSetPermission",
               "Update-QSDataSource",
               "Update-QSDataSourcePermission",
               "Update-QSDefaultQBusinessApplication",
               "Update-QSFolder",
               "Update-QSFolderPermission",
               "Update-QSGroup",
               "Update-QSIAMPolicyAssignment",
               "Update-QSIdentityPropagationConfig",
               "Update-QSIpRestriction",
               "Update-QSKeyRegistration",
               "Update-QSPublicSharingSetting",
               "Update-QSQPersonalizationConfiguration",
               "Update-QSQuickSightQSearchConfiguration",
               "Update-QSRefreshSchedule",
               "Update-QSRoleCustomPermission",
               "Update-QSSPICECapacityConfiguration",
               "Update-QSTemplate",
               "Update-QSTemplateAlias",
               "Update-QSTemplatePermission",
               "Update-QSTheme",
               "Update-QSThemeAlias",
               "Update-QSThemePermission",
               "Update-QSTopic",
               "Update-QSTopicPermission",
               "Update-QSTopicRefreshSchedule",
               "Update-QSUser",
               "Update-QSUserCustomPermission",
               "Update-QSVPCConnection")
}

_awsArgumentCompleterRegistration $QS_SelectCompleters $QS_SelectMap

