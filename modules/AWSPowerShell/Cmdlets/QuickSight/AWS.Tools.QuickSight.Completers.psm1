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

        # Amazon.QuickSight.DashboardBehavior
        {
            ($_ -eq "New-QSDashboard/DashboardPublishOptions_AdHocFilteringOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/DashboardPublishOptions_AdHocFilteringOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/DashboardPublishOptions_ExportToCSVOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/DashboardPublishOptions_ExportToCSVOption_AvailabilityStatus")
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
            $v = "ADOBE_ANALYTICS","AMAZON_ELASTICSEARCH","AMAZON_OPENSEARCH","ATHENA","AURORA","AURORA_POSTGRESQL","AWS_IOT_ANALYTICS","EXASOL","GITHUB","JIRA","MARIADB","MYSQL","ORACLE","POSTGRESQL","PRESTO","REDSHIFT","S3","SALESFORCE","SERVICENOW","SNOWFLAKE","SPARK","SQLSERVER","TERADATA","TIMESTREAM","TWITTER"
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
            $v = "SHARED"
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
            $v = "IAM","QUICKSIGHT"
            break
        }

        # Amazon.QuickSight.IngestionType
        "New-QSIngestion/IngestionType"
        {
            $v = "FULL_REFRESH","INCREMENTAL_REFRESH"
            break
        }

        # Amazon.QuickSight.MemberType
        {
            ($_ -eq "New-QSFolderMembership/MemberType") -Or
            ($_ -eq "Remove-QSFolderMembership/MemberType")
        }
        {
            $v = "ANALYSIS","DASHBOARD","DATASET"
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

        # Amazon.QuickSight.UserRole
        {
            ($_ -eq "Update-QSUser/Role") -Or
            ($_ -eq "Register-QSUser/UserRole")
        }
        {
            $v = "ADMIN","AUTHOR","READER","RESTRICTED_AUTHOR","RESTRICTED_READER"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$QS_map = @{
    "AssignmentStatus"=@("Get-QSIAMPolicyAssignmentList","New-QSIAMPolicyAssignment","Update-QSIAMPolicyAssignment")
    "DashboardPublishOptions_AdHocFilteringOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "DashboardPublishOptions_ExportToCSVOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "DashboardPublishOptions_SheetControlsOption_VisibilityState"=@("New-QSDashboard","Update-QSDashboard")
    "FolderType"=@("New-QSFolder")
    "IdentityStore"=@("New-QSNamespace")
    "IdentityType"=@("Get-QSDashboardEmbedUrl","Register-QSUser")
    "ImportMode"=@("New-QSDataSet","Update-QSDataSet")
    "IngestionType"=@("New-QSIngestion")
    "MemberType"=@("New-QSFolderMembership","Remove-QSFolderMembership")
    "Role"=@("Update-QSUser")
    "RowLevelPermissionDataSet_FormatVersion"=@("New-QSDataSet","Update-QSDataSet")
    "RowLevelPermissionDataSet_PermissionPolicy"=@("New-QSDataSet","Update-QSDataSet")
    "RowLevelPermissionDataSet_Status"=@("New-QSDataSet","Update-QSDataSet")
    "RowLevelPermissionTagConfiguration_Status"=@("New-QSDataSet","Update-QSDataSet")
    "Type"=@("Get-QSThemeList","New-QSDataSource")
    "UserRole"=@("Register-QSUser")
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
               "New-QSTemplate",
               "New-QSTemplateAlias",
               "New-QSTheme",
               "New-QSThemeAlias",
               "Remove-QSAccountCustomization",
               "Remove-QSAnalysis",
               "Remove-QSDashboard",
               "Remove-QSDataSet",
               "Remove-QSDataSource",
               "Remove-QSFolder",
               "Remove-QSFolderMembership",
               "Remove-QSGroup",
               "Remove-QSGroupMembership",
               "Remove-QSIAMPolicyAssignment",
               "Remove-QSNamespace",
               "Remove-QSTemplate",
               "Remove-QSTemplateAlias",
               "Remove-QSTheme",
               "Remove-QSThemeAlias",
               "Remove-QSUser",
               "Remove-QSUserByPrincipalId",
               "Get-QSAccountCustomization",
               "Get-QSAccountSetting",
               "Get-QSAnalysis",
               "Get-QSAnalysisPermission",
               "Get-QSDashboard",
               "Get-QSDashboardPermission",
               "Get-QSDataSet",
               "Get-QSDataSetPermission",
               "Get-QSDataSource",
               "Get-QSDataSourcePermission",
               "Get-QSFolder",
               "Get-QSFolderPermission",
               "Get-QSFolderResolvedPermission",
               "Get-QSGroup",
               "Get-QSIAMPolicyAssignment",
               "Get-QSIngestion",
               "Get-QSIpRestriction",
               "Get-QSNamespace",
               "Get-QSTemplate",
               "Get-QSTemplateAlias",
               "Get-QSTemplatePermission",
               "Get-QSTheme",
               "Get-QSThemeAlias",
               "Get-QSThemePermission",
               "Get-QSUser",
               "New-QSEmbedUrlForAnonymousUser",
               "New-QSEmbedUrlForRegisteredUser",
               "Get-QSDashboardEmbedUrl",
               "Get-QSSessionEmbedUrl",
               "Get-QSAnalysisList",
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
               "Get-QSResourceTag",
               "Get-QSTemplateAliasList",
               "Get-QSTemplateList",
               "Get-QSTemplateVersionList",
               "Get-QSThemeAliasList",
               "Get-QSThemeList",
               "Get-QSThemeVersionList",
               "Get-QSUserGroupList",
               "Get-QSUserList",
               "Register-QSUser",
               "Restore-QSAnalysis",
               "Search-QSAnalysis",
               "Search-QSDashboard",
               "Search-QSFolder",
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
               "Update-QSTemplate",
               "Update-QSTemplateAlias",
               "Update-QSTemplatePermission",
               "Update-QSTheme",
               "Update-QSThemeAlias",
               "Update-QSThemePermission",
               "Update-QSUser")
}

_awsArgumentCompleterRegistration $QS_SelectCompleters $QS_SelectMap

