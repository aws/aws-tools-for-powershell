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

        # Amazon.QuickSight.DashboardBehavior
        {
            ($_ -eq "New-QSDashboard/DashboardPublishOptions_AdHocFilteringOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/DashboardPublishOptions_AdHocFilteringOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/DashboardPublishOptions_DataPointDrillUpDownOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/DashboardPublishOptions_DataPointDrillUpDownOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/DashboardPublishOptions_DataPointMenuLabelOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/DashboardPublishOptions_DataPointMenuLabelOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/DashboardPublishOptions_DataPointTooltipOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/DashboardPublishOptions_DataPointTooltipOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/DashboardPublishOptions_ExportToCSVOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/DashboardPublishOptions_ExportToCSVOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/DashboardPublishOptions_ExportWithHiddenFieldsOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/DashboardPublishOptions_ExportWithHiddenFieldsOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/DashboardPublishOptions_SheetLayoutElementMaximizationOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/DashboardPublishOptions_SheetLayoutElementMaximizationOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/DashboardPublishOptions_VisualAxisSortOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/DashboardPublishOptions_VisualAxisSortOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/DashboardPublishOptions_VisualMenuOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/DashboardPublishOptions_VisualMenuOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/DashboardPublishOptions_VisualPublishOptions_ExportHiddenFieldsOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/DashboardPublishOptions_VisualPublishOptions_ExportHiddenFieldsOption_AvailabilityStatus")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.QuickSight.DashboardUIState
        {
            ($_ -eq "New-QSDashboard/DashboardPublishOptions_SheetControlsOption_VisibilityState") -Or
            ($_ -eq "Update-QSDashboard/DashboardPublishOptions_SheetControlsOption_VisibilityState")
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

        # Amazon.QuickSight.DataSourceType
        "New-QSDataSource/Type"
        {
            $v = "ADOBE_ANALYTICS","AMAZON_ELASTICSEARCH","AMAZON_OPENSEARCH","ATHENA","AURORA","AURORA_POSTGRESQL","AWS_IOT_ANALYTICS","BIGQUERY","DATABRICKS","EXASOL","GITHUB","JIRA","MARIADB","MYSQL","ORACLE","POSTGRESQL","PRESTO","REDSHIFT","S3","SALESFORCE","SERVICENOW","SNOWFLAKE","SPARK","SQLSERVER","STARBURST","TERADATA","TIMESTREAM","TRINO","TWITTER"
            break
        }

        # Amazon.QuickSight.DayOfTheWeek
        {
            ($_ -eq "New-QSAnalysis/Definition_Options_WeekStart") -Or
            ($_ -eq "New-QSDashboard/Definition_Options_WeekStart") -Or
            ($_ -eq "New-QSTemplate/Definition_Options_WeekStart") -Or
            ($_ -eq "Update-QSAnalysis/Definition_Options_WeekStart") -Or
            ($_ -eq "Update-QSDashboard/Definition_Options_WeekStart") -Or
            ($_ -eq "Update-QSTemplate/Definition_Options_WeekStart")
        }
        {
            $v = "FRIDAY","MONDAY","SATURDAY","SUNDAY","THURSDAY","TUESDAY","WEDNESDAY"
            break
        }

        # Amazon.QuickSight.DayOfWeek
        {
            ($_ -eq "New-QSRefreshSchedule/Schedule_ScheduleFrequency_RefreshOnDay_DayOfWeek") -Or
            ($_ -eq "Update-QSRefreshSchedule/Schedule_ScheduleFrequency_RefreshOnDay_DayOfWeek")
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
        "Write-QSDataSetRefreshProperty/DataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow_SizeUnit"
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
            ($_ -eq "New-QSAnalysis/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperOrientation") -Or
            ($_ -eq "New-QSDashboard/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperOrientation") -Or
            ($_ -eq "New-QSTemplate/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperOrientation") -Or
            ($_ -eq "Update-QSAnalysis/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperOrientation") -Or
            ($_ -eq "Update-QSDashboard/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperOrientation") -Or
            ($_ -eq "Update-QSTemplate/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperOrientation")
        }
        {
            $v = "LANDSCAPE","PORTRAIT"
            break
        }

        # Amazon.QuickSight.PaperSize
        {
            ($_ -eq "New-QSAnalysis/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperSize") -Or
            ($_ -eq "New-QSDashboard/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperSize") -Or
            ($_ -eq "New-QSTemplate/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperSize") -Or
            ($_ -eq "Update-QSAnalysis/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperSize") -Or
            ($_ -eq "Update-QSDashboard/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperSize") -Or
            ($_ -eq "Update-QSTemplate/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperSize")
        }
        {
            $v = "A0","A1","A2","A3","A4","A5","JIS_B4","JIS_B5","US_LEGAL","US_LETTER","US_TABLOID_LEDGER"
            break
        }

        # Amazon.QuickSight.RefreshInterval
        {
            ($_ -eq "New-QSRefreshSchedule/Schedule_ScheduleFrequency_Interval") -Or
            ($_ -eq "Update-QSRefreshSchedule/Schedule_ScheduleFrequency_Interval")
        }
        {
            $v = "DAILY","HOURLY","MINUTE15","MINUTE30","MONTHLY","WEEKLY"
            break
        }

        # Amazon.QuickSight.ResizeOption
        {
            ($_ -eq "New-QSAnalysis/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_ResizeOption") -Or
            ($_ -eq "New-QSDashboard/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_ResizeOption") -Or
            ($_ -eq "New-QSTemplate/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_ResizeOption") -Or
            ($_ -eq "Update-QSAnalysis/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_ResizeOption") -Or
            ($_ -eq "Update-QSDashboard/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_ResizeOption") -Or
            ($_ -eq "Update-QSTemplate/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_ResizeOption")
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
            $v = "ADMIN","AUTHOR","READER"
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

        # Amazon.QuickSight.SharingModel
        "New-QSFolder/SharingModel"
        {
            $v = "ACCOUNT","NAMESPACE"
            break
        }

        # Amazon.QuickSight.SheetContentType
        {
            ($_ -eq "New-QSAnalysis/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_SheetContentType") -Or
            ($_ -eq "New-QSDashboard/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_SheetContentType") -Or
            ($_ -eq "New-QSTemplate/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_SheetContentType") -Or
            ($_ -eq "Update-QSAnalysis/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_SheetContentType") -Or
            ($_ -eq "Update-QSDashboard/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_SheetContentType") -Or
            ($_ -eq "Update-QSTemplate/Definition_AnalysisDefaults_DefaultNewSheetConfiguration_SheetContentType")
        }
        {
            $v = "INTERACTIVE","PAGINATED"
            break
        }

        # Amazon.QuickSight.StarburstProductType
        {
            ($_ -eq "New-QSDataSource/DataSourceParameters_StarburstParameters_ProductType") -Or
            ($_ -eq "Update-QSDataSource/DataSourceParameters_StarburstParameters_ProductType")
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

        # Amazon.QuickSight.UserRole
        {
            ($_ -eq "Update-QSUser/Role") -Or
            ($_ -eq "Register-QSUser/UserRole")
        }
        {
            $v = "ADMIN","AUTHOR","READER","RESTRICTED_AUTHOR","RESTRICTED_READER"
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
    "AssignmentStatus"=@("Get-QSIAMPolicyAssignmentList","New-QSIAMPolicyAssignment","Update-QSIAMPolicyAssignment")
    "AuthenticationMethod"=@("New-QSAccountSubscription")
    "DashboardPublishOptions_AdHocFilteringOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "DashboardPublishOptions_DataPointDrillUpDownOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "DashboardPublishOptions_DataPointMenuLabelOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "DashboardPublishOptions_DataPointTooltipOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "DashboardPublishOptions_ExportToCSVOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "DashboardPublishOptions_ExportWithHiddenFieldsOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "DashboardPublishOptions_SheetControlsOption_VisibilityState"=@("New-QSDashboard","Update-QSDashboard")
    "DashboardPublishOptions_SheetLayoutElementMaximizationOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "DashboardPublishOptions_VisualAxisSortOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "DashboardPublishOptions_VisualMenuOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "DashboardPublishOptions_VisualPublishOptions_ExportHiddenFieldsOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "DataSetRefreshProperties_RefreshConfiguration_IncrementalRefresh_LookbackWindow_SizeUnit"=@("Write-QSDataSetRefreshProperty")
    "DataSourceParameters_StarburstParameters_ProductType"=@("New-QSDataSource","Update-QSDataSource")
    "Definition_AnalysisDefaults_DefaultNewSheetConfiguration_InteractiveLayoutConfiguration_Grid_CanvasSizeOptions_ScreenCanvasSizeOptions_ResizeOption"=@("New-QSAnalysis","New-QSDashboard","New-QSTemplate","Update-QSAnalysis","Update-QSDashboard","Update-QSTemplate")
    "Definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperOrientation"=@("New-QSAnalysis","New-QSDashboard","New-QSTemplate","Update-QSAnalysis","Update-QSDashboard","Update-QSTemplate")
    "Definition_AnalysisDefaults_DefaultNewSheetConfiguration_PaginatedLayoutConfiguration_SectionBased_CanvasSizeOptions_PaperCanvasSizeOptions_PaperSize"=@("New-QSAnalysis","New-QSDashboard","New-QSTemplate","Update-QSAnalysis","Update-QSDashboard","Update-QSTemplate")
    "Definition_AnalysisDefaults_DefaultNewSheetConfiguration_SheetContentType"=@("New-QSAnalysis","New-QSDashboard","New-QSTemplate","Update-QSAnalysis","Update-QSDashboard","Update-QSTemplate")
    "Definition_Options_WeekStart"=@("New-QSAnalysis","New-QSDashboard","New-QSTemplate","Update-QSAnalysis","Update-QSDashboard","Update-QSTemplate")
    "Edition"=@("New-QSAccountSubscription")
    "ExportFormat"=@("Start-QSAssetBundleExportJob")
    "FailureAction"=@("Start-QSAssetBundleImportJob")
    "FolderType"=@("New-QSFolder")
    "IdentityStore"=@("New-QSNamespace")
    "IdentityType"=@("Get-QSDashboardEmbedUrl","Register-QSUser")
    "ImportMode"=@("New-QSDataSet","Update-QSDataSet")
    "IngestionType"=@("New-QSIngestion")
    "MemberType"=@("New-QSFolderMembership","Remove-QSFolderMembership")
    "RefreshSchedule_TopicScheduleType"=@("New-QSTopicRefreshSchedule","Update-QSTopicRefreshSchedule")
    "Role"=@("Get-QSRoleCustomPermission","Get-QSRoleMembershipList","New-QSRoleMembership","Remove-QSRoleCustomPermission","Remove-QSRoleMembership","Update-QSRoleCustomPermission","Update-QSUser")
    "RowLevelPermissionDataSet_FormatVersion"=@("New-QSDataSet","Update-QSDataSet")
    "RowLevelPermissionDataSet_PermissionPolicy"=@("New-QSDataSet","Update-QSDataSet")
    "RowLevelPermissionDataSet_Status"=@("New-QSDataSet","Update-QSDataSet")
    "RowLevelPermissionTagConfiguration_Status"=@("New-QSDataSet","Update-QSDataSet")
    "Schedule_RefreshType"=@("New-QSRefreshSchedule","Update-QSRefreshSchedule")
    "Schedule_ScheduleFrequency_Interval"=@("New-QSRefreshSchedule","Update-QSRefreshSchedule")
    "Schedule_ScheduleFrequency_RefreshOnDay_DayOfWeek"=@("New-QSRefreshSchedule","Update-QSRefreshSchedule")
    "SharingModel"=@("New-QSFolder")
    "Type"=@("Get-QSThemeList","New-QSDataSource")
    "UserRole"=@("Register-QSUser")
    "ValidationStrategy_Mode"=@("New-QSAnalysis","New-QSDashboard","New-QSTemplate","Update-QSAnalysis","Update-QSDashboard","Update-QSTemplate")
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
    "Select"=@("Stop-QSIngestion",
               "New-QSAccountCustomization",
               "New-QSAccountSubscription",
               "New-QSAnalysis",
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
               "Remove-QSDashboard",
               "Remove-QSDataSet",
               "Remove-QSDataSetRefreshProperty",
               "Remove-QSDataSource",
               "Remove-QSFolder",
               "Remove-QSFolderMembership",
               "Remove-QSGroup",
               "Remove-QSGroupMembership",
               "Remove-QSIAMPolicyAssignment",
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
               "Remove-QSVPCConnection",
               "Get-QSAccountCustomization",
               "Get-QSAccountSetting",
               "Get-QSAccountSubscription",
               "Get-QSAnalysis",
               "Get-QSAnalysisDefinition",
               "Get-QSAnalysisPermission",
               "Get-QSAssetBundleExportJob",
               "Get-QSAssetBundleImportJob",
               "Get-QSDashboard",
               "Get-QSDashboardDefinition",
               "Get-QSDashboardPermission",
               "Get-QSDashboardSnapshotJob",
               "Get-QSDashboardSnapshotJobResult",
               "Get-QSDataSet",
               "Get-QSDataSetPermission",
               "Get-QSDataSetRefreshProperty",
               "Get-QSDataSource",
               "Get-QSDataSourcePermission",
               "Get-QSFolder",
               "Get-QSFolderPermission",
               "Get-QSFolderResolvedPermission",
               "Get-QSGroup",
               "Get-QSGroupMembership",
               "Get-QSIAMPolicyAssignment",
               "Get-QSIngestion",
               "Get-QSIpRestriction",
               "Get-QSNamespace",
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
               "Get-QSDashboardEmbedUrl",
               "Get-QSSessionEmbedUrl",
               "Get-QSAnalysisList",
               "Get-QSAssetBundleExportJobList",
               "Get-QSAssetBundleImportJobList",
               "Get-QSDashboardList",
               "Get-QSDashboardVersionList",
               "Get-QSDataSetList",
               "Get-QSDataSourceList",
               "Get-QSFolderMemberList",
               "Get-QSFolderList",
               "Get-QSGroupMembershipList",
               "Get-QSGroupList",
               "Get-QSIAMPolicyAssignmentList",
               "Get-QSIAMPolicyAssignmentsForUserList",
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
               "Get-QSTopicList",
               "Get-QSUserGroupList",
               "Get-QSUserList",
               "Get-QSVPCConnectionList",
               "Write-QSDataSetRefreshProperty",
               "Register-QSUser",
               "Restore-QSAnalysis",
               "Search-QSAnalysis",
               "Search-QSDashboard",
               "Search-QSDataSet",
               "Search-QSDataSource",
               "Search-QSFolder",
               "Find-QSGroup",
               "Start-QSAssetBundleExportJob",
               "Start-QSAssetBundleImportJob",
               "Start-QSDashboardSnapshotJob",
               "Add-QSResourceTag",
               "Remove-QSResourceTag",
               "Update-QSAccountCustomization",
               "Update-QSAccountSetting",
               "Update-QSAnalysis",
               "Update-QSAnalysisPermission",
               "Update-QSDashboard",
               "Update-QSDashboardPermission",
               "Update-QSDashboardPublishedVersion",
               "Update-QSDataSet",
               "Update-QSDataSetPermission",
               "Update-QSDataSource",
               "Update-QSDataSourcePermission",
               "Update-QSFolder",
               "Update-QSFolderPermission",
               "Update-QSGroup",
               "Update-QSIAMPolicyAssignment",
               "Update-QSIpRestriction",
               "Update-QSPublicSharingSetting",
               "Update-QSRefreshSchedule",
               "Update-QSRoleCustomPermission",
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
               "Update-QSVPCConnection")
}

_awsArgumentCompleterRegistration $QS_SelectCompleters $QS_SelectMap

