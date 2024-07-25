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

# Argument completions for service Amazon DataZone


$DZ_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.DataZone.AcceptRuleBehavior
        "Approve-DZPrediction/AcceptRule_Rule"
        {
            $v = "ALL","NONE"
            break
        }

        # Amazon.DataZone.AuthType
        {
            ($_ -eq "New-DZDomain/SingleSignOn_Type") -Or
            ($_ -eq "Update-DZDomain/SingleSignOn_Type")
        }
        {
            $v = "DISABLED","IAM_IDC"
            break
        }

        # Amazon.DataZone.ChangeAction
        "New-DZListingChangeSet/Action"
        {
            $v = "PUBLISH","UNPUBLISH"
            break
        }

        # Amazon.DataZone.DataAssetActivityStatus
        "Get-DZDataSourceRunActivityList/Status"
        {
            $v = "FAILED","PUBLISHING_FAILED","SKIPPED_ALREADY_IMPORTED","SKIPPED_ARCHIVED","SKIPPED_NO_ACCESS","SUCCEEDED_CREATED","SUCCEEDED_UPDATED","UNCHANGED"
            break
        }

        # Amazon.DataZone.DataSourceRunStatus
        "Get-DZDataSourceRunList/Status"
        {
            $v = "FAILED","PARTIALLY_SUCCEEDED","REQUESTED","RUNNING","SUCCESS"
            break
        }

        # Amazon.DataZone.DataSourceStatus
        "Get-DZDataSourceList/Status"
        {
            $v = "CREATING","DELETING","FAILED_CREATION","FAILED_DELETION","FAILED_UPDATE","READY","RUNNING","UPDATING"
            break
        }

        # Amazon.DataZone.DomainStatus
        "Get-DZDomainList/Status"
        {
            $v = "AVAILABLE","CREATING","CREATION_FAILED","DELETED","DELETING","DELETION_FAILED"
            break
        }

        # Amazon.DataZone.EdgeDirection
        "Get-DZLineageNodeHistoryList/Direction"
        {
            $v = "DOWNSTREAM","UPSTREAM"
            break
        }

        # Amazon.DataZone.EnableSetting
        {
            ($_ -eq "New-DZDataSource/EnableSetting") -Or
            ($_ -eq "Update-DZDataSource/EnableSetting")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.DataZone.EntityType
        "New-DZListingChangeSet/EntityType"
        {
            $v = "ASSET"
            break
        }

        # Amazon.DataZone.EnvironmentStatus
        "Get-DZEnvironmentList/Status"
        {
            $v = "ACTIVE","CREATE_FAILED","CREATING","DELETED","DELETE_FAILED","DELETING","DISABLED","EXPIRED","INACCESSIBLE","SUSPENDED","UPDATE_FAILED","UPDATING","VALIDATION_FAILED"
            break
        }

        # Amazon.DataZone.FilterStatus
        "Get-DZAssetFilterList/Status"
        {
            $v = "INVALID","VALID"
            break
        }

        # Amazon.DataZone.FormTypeStatus
        "New-DZFormType/Status"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.DataZone.GlossaryStatus
        {
            ($_ -eq "New-DZGlossary/Status") -Or
            ($_ -eq "Update-DZGlossary/Status")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.DataZone.GlossaryTermStatus
        {
            ($_ -eq "New-DZGlossaryTerm/Status") -Or
            ($_ -eq "Update-DZGlossaryTerm/Status")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.DataZone.GroupProfileStatus
        "Update-DZGroupProfile/Status"
        {
            $v = "ASSIGNED","NOT_ASSIGNED"
            break
        }

        # Amazon.DataZone.GroupSearchType
        "Search-DZGroupProfile/GroupType"
        {
            $v = "DATAZONE_SSO_GROUP","SSO_GROUP"
            break
        }

        # Amazon.DataZone.InventorySearchScope
        "Search-DZResource/SearchScope"
        {
            $v = "ASSET","GLOSSARY","GLOSSARY_TERM"
            break
        }

        # Amazon.DataZone.MetadataGenerationRunStatus
        "Get-DZMetadataGenerationRunList/Status"
        {
            $v = "CANCELED","FAILED","IN_PROGRESS","SUBMITTED","SUCCEEDED"
            break
        }

        # Amazon.DataZone.MetadataGenerationRunType
        {
            ($_ -eq "Get-DZMetadataGenerationRunList/Type") -Or
            ($_ -eq "Start-DZMetadataGenerationRun/Type")
        }
        {
            $v = "BUSINESS_DESCRIPTIONS"
            break
        }

        # Amazon.DataZone.MetadataGenerationTargetType
        "Start-DZMetadataGenerationRun/Target_Type"
        {
            $v = "ASSET"
            break
        }

        # Amazon.DataZone.NotificationType
        "Get-DZNotificationList/Type"
        {
            $v = "EVENT","TASK"
            break
        }

        # Amazon.DataZone.RejectRuleBehavior
        "Deny-DZPrediction/RejectRule_Rule"
        {
            $v = "ALL","NONE"
            break
        }

        # Amazon.DataZone.SortFieldProject
        "Get-DZProjectMembershipList/SortBy"
        {
            $v = "NAME"
            break
        }

        # Amazon.DataZone.SortKey
        {
            ($_ -eq "Get-DZSubscriptionGrantList/SortBy") -Or
            ($_ -eq "Get-DZSubscriptionList/SortBy") -Or
            ($_ -eq "Get-DZSubscriptionRequestList/SortBy") -Or
            ($_ -eq "Get-DZSubscriptionTargetList/SortBy")
        }
        {
            $v = "CREATED_AT","UPDATED_AT"
            break
        }

        # Amazon.DataZone.SortOrder
        {
            ($_ -eq "Search-DZListing/Sort_Order") -Or
            ($_ -eq "Search-DZResource/Sort_Order") -Or
            ($_ -eq "Search-DZType/Sort_Order") -Or
            ($_ -eq "Get-DZLineageNodeHistoryList/SortOrder") -Or
            ($_ -eq "Get-DZProjectMembershipList/SortOrder") -Or
            ($_ -eq "Get-DZSubscriptionGrantList/SortOrder") -Or
            ($_ -eq "Get-DZSubscriptionList/SortOrder") -Or
            ($_ -eq "Get-DZSubscriptionRequestList/SortOrder") -Or
            ($_ -eq "Get-DZSubscriptionTargetList/SortOrder")
        }
        {
            $v = "ASCENDING","DESCENDING"
            break
        }

        # Amazon.DataZone.SubscriptionGrantStatus
        "Update-DZSubscriptionGrantStatus/Status"
        {
            $v = "GRANTED","GRANT_FAILED","GRANT_IN_PROGRESS","GRANT_PENDING","REVOKED","REVOKE_FAILED","REVOKE_IN_PROGRESS","REVOKE_PENDING"
            break
        }

        # Amazon.DataZone.SubscriptionRequestStatus
        "Get-DZSubscriptionRequestList/Status"
        {
            $v = "ACCEPTED","PENDING","REJECTED"
            break
        }

        # Amazon.DataZone.SubscriptionStatus
        "Get-DZSubscriptionList/Status"
        {
            $v = "APPROVED","CANCELLED","REVOKED"
            break
        }

        # Amazon.DataZone.TaskStatus
        "Get-DZNotificationList/TaskStatus"
        {
            $v = "ACTIVE","INACTIVE"
            break
        }

        # Amazon.DataZone.TimeSeriesEntityType
        {
            ($_ -eq "Get-DZTimeSeriesDataPoint/EntityType") -Or
            ($_ -eq "Get-DZTimeSeriesDataPointList/EntityType") -Or
            ($_ -eq "New-DZTimeSeriesDataPoint/EntityType") -Or
            ($_ -eq "Remove-DZTimeSeriesDataPoint/EntityType")
        }
        {
            $v = "ASSET","LISTING"
            break
        }

        # Amazon.DataZone.Timezone
        {
            ($_ -eq "New-DZDataSource/Schedule_Timezone") -Or
            ($_ -eq "Update-DZDataSource/Schedule_Timezone")
        }
        {
            $v = "AFRICA_JOHANNESBURG","AMERICA_MONTREAL","AMERICA_SAO_PAULO","ASIA_BAHRAIN","ASIA_BANGKOK","ASIA_CALCUTTA","ASIA_DUBAI","ASIA_HONG_KONG","ASIA_JAKARTA","ASIA_KUALA_LUMPUR","ASIA_SEOUL","ASIA_SHANGHAI","ASIA_SINGAPORE","ASIA_TAIPEI","ASIA_TOKYO","AUSTRALIA_MELBOURNE","AUSTRALIA_SYDNEY","CANADA_CENTRAL","CET","CST6CDT","ETC_GMT","ETC_GMT0","ETC_GMT_ADD_0","ETC_GMT_ADD_1","ETC_GMT_ADD_10","ETC_GMT_ADD_11","ETC_GMT_ADD_12","ETC_GMT_ADD_2","ETC_GMT_ADD_3","ETC_GMT_ADD_4","ETC_GMT_ADD_5","ETC_GMT_ADD_6","ETC_GMT_ADD_7","ETC_GMT_ADD_8","ETC_GMT_ADD_9","ETC_GMT_NEG_0","ETC_GMT_NEG_1","ETC_GMT_NEG_10","ETC_GMT_NEG_11","ETC_GMT_NEG_12","ETC_GMT_NEG_13","ETC_GMT_NEG_14","ETC_GMT_NEG_2","ETC_GMT_NEG_3","ETC_GMT_NEG_4","ETC_GMT_NEG_5","ETC_GMT_NEG_6","ETC_GMT_NEG_7","ETC_GMT_NEG_8","ETC_GMT_NEG_9","EUROPE_DUBLIN","EUROPE_LONDON","EUROPE_PARIS","EUROPE_STOCKHOLM","EUROPE_ZURICH","ISRAEL","MEXICO_GENERAL","MST7MDT","PACIFIC_AUCKLAND","US_CENTRAL","US_EASTERN","US_MOUNTAIN","US_PACIFIC","UTC"
            break
        }

        # Amazon.DataZone.TypesSearchScope
        "Search-DZType/SearchScope"
        {
            $v = "ASSET_TYPE","FORM_TYPE","LINEAGE_NODE_TYPE"
            break
        }

        # Amazon.DataZone.UserAssignment
        {
            ($_ -eq "New-DZDomain/SingleSignOn_UserAssignment") -Or
            ($_ -eq "Update-DZDomain/SingleSignOn_UserAssignment")
        }
        {
            $v = "AUTOMATIC","MANUAL"
            break
        }

        # Amazon.DataZone.UserDesignation
        "New-DZProjectMembership/Designation"
        {
            $v = "PROJECT_CONTRIBUTOR","PROJECT_OWNER"
            break
        }

        # Amazon.DataZone.UserProfileStatus
        "Update-DZUserProfile/Status"
        {
            $v = "ACTIVATED","ASSIGNED","DEACTIVATED","NOT_ASSIGNED"
            break
        }

        # Amazon.DataZone.UserProfileType
        {
            ($_ -eq "Get-DZUserProfile/Type") -Or
            ($_ -eq "Update-DZUserProfile/Type")
        }
        {
            $v = "IAM","SSO"
            break
        }

        # Amazon.DataZone.UserSearchType
        "Search-DZUserProfile/UserType"
        {
            $v = "DATAZONE_IAM_USER","DATAZONE_SSO_USER","DATAZONE_USER","SSO_USER"
            break
        }

        # Amazon.DataZone.UserType
        "New-DZUserProfile/UserType"
        {
            $v = "IAM_ROLE","IAM_USER","SSO_USER"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$DZ_map = @{
    "AcceptRule_Rule"=@("Approve-DZPrediction")
    "Action"=@("New-DZListingChangeSet")
    "Designation"=@("New-DZProjectMembership")
    "Direction"=@("Get-DZLineageNodeHistoryList")
    "EnableSetting"=@("New-DZDataSource","Update-DZDataSource")
    "EntityType"=@("Get-DZTimeSeriesDataPoint","Get-DZTimeSeriesDataPointList","New-DZListingChangeSet","New-DZTimeSeriesDataPoint","Remove-DZTimeSeriesDataPoint")
    "GroupType"=@("Search-DZGroupProfile")
    "RejectRule_Rule"=@("Deny-DZPrediction")
    "Schedule_Timezone"=@("New-DZDataSource","Update-DZDataSource")
    "SearchScope"=@("Search-DZResource","Search-DZType")
    "SingleSignOn_Type"=@("New-DZDomain","Update-DZDomain")
    "SingleSignOn_UserAssignment"=@("New-DZDomain","Update-DZDomain")
    "Sort_Order"=@("Search-DZListing","Search-DZResource","Search-DZType")
    "SortBy"=@("Get-DZProjectMembershipList","Get-DZSubscriptionGrantList","Get-DZSubscriptionList","Get-DZSubscriptionRequestList","Get-DZSubscriptionTargetList")
    "SortOrder"=@("Get-DZLineageNodeHistoryList","Get-DZProjectMembershipList","Get-DZSubscriptionGrantList","Get-DZSubscriptionList","Get-DZSubscriptionRequestList","Get-DZSubscriptionTargetList")
    "Status"=@("Get-DZAssetFilterList","Get-DZDataSourceList","Get-DZDataSourceRunActivityList","Get-DZDataSourceRunList","Get-DZDomainList","Get-DZEnvironmentList","Get-DZMetadataGenerationRunList","Get-DZSubscriptionList","Get-DZSubscriptionRequestList","New-DZFormType","New-DZGlossary","New-DZGlossaryTerm","Update-DZGlossary","Update-DZGlossaryTerm","Update-DZGroupProfile","Update-DZSubscriptionGrantStatus","Update-DZUserProfile")
    "Target_Type"=@("Start-DZMetadataGenerationRun")
    "TaskStatus"=@("Get-DZNotificationList")
    "Type"=@("Get-DZMetadataGenerationRunList","Get-DZNotificationList","Get-DZUserProfile","Start-DZMetadataGenerationRun","Update-DZUserProfile")
    "UserType"=@("New-DZUserProfile","Search-DZUserProfile")
}

_awsArgumentCompleterRegistration $DZ_Completers $DZ_map

$DZ_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.DZ.$($commandName.Replace('-', ''))Cmdlet]"
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

$DZ_SelectMap = @{
    "Select"=@("Approve-DZPrediction",
               "Approve-DZSubscriptionRequest",
               "Set-DZEnvironmentRole",
               "Stop-DZMetadataGenerationRun",
               "Stop-DZSubscription",
               "New-DZAsset",
               "New-DZAssetFilter",
               "New-DZAssetRevision",
               "New-DZAssetType",
               "New-DZDataSource",
               "New-DZDomain",
               "New-DZEnvironment",
               "New-DZEnvironmentAction",
               "New-DZEnvironmentProfile",
               "New-DZFormType",
               "New-DZGlossary",
               "New-DZGlossaryTerm",
               "New-DZGroupProfile",
               "New-DZListingChangeSet",
               "New-DZProject",
               "New-DZProjectMembership",
               "New-DZSubscriptionGrant",
               "New-DZSubscriptionRequest",
               "New-DZSubscriptionTarget",
               "New-DZUserProfile",
               "Remove-DZAsset",
               "Remove-DZAssetFilter",
               "Remove-DZAssetType",
               "Remove-DZDataSource",
               "Remove-DZDomain",
               "Remove-DZEnvironment",
               "Remove-DZEnvironmentAction",
               "Remove-DZEnvironmentBlueprintConfiguration",
               "Remove-DZEnvironmentProfile",
               "Remove-DZFormType",
               "Remove-DZGlossary",
               "Remove-DZGlossaryTerm",
               "Remove-DZListing",
               "Remove-DZProject",
               "Remove-DZProjectMembership",
               "Remove-DZSubscriptionGrant",
               "Remove-DZSubscriptionRequest",
               "Remove-DZSubscriptionTarget",
               "Remove-DZTimeSeriesDataPoint",
               "Reset-DZEnvironmentRole",
               "Get-DZAsset",
               "Get-DZAssetFilter",
               "Get-DZAssetType",
               "Get-DZDataSource",
               "Get-DZDataSourceRun",
               "Get-DZDomain",
               "Get-DZEnvironment",
               "Get-DZEnvironmentAction",
               "Get-DZEnvironmentBlueprint",
               "Get-DZEnvironmentBlueprintConfiguration",
               "Get-DZEnvironmentCredential",
               "Get-DZEnvironmentProfile",
               "Get-DZFormType",
               "Get-DZGlossary",
               "Get-DZGlossaryTerm",
               "Get-DZGroupProfile",
               "Get-DZIamPortalLoginUrl",
               "Get-DZLineageNode",
               "Get-DZListing",
               "Get-DZMetadataGenerationRun",
               "Get-DZProject",
               "Get-DZSubscription",
               "Get-DZSubscriptionGrant",
               "Get-DZSubscriptionRequestDetail",
               "Get-DZSubscriptionTarget",
               "Get-DZTimeSeriesDataPoint",
               "Get-DZUserProfile",
               "Get-DZAssetFilterList",
               "Get-DZAssetRevisionList",
               "Get-DZDataSourceRunActivityList",
               "Get-DZDataSourceRunList",
               "Get-DZDataSourceList",
               "Get-DZDomainList",
               "Get-DZEnvironmentActionList",
               "Get-DZEnvironmentBlueprintConfigurationList",
               "Get-DZEnvironmentBlueprintList",
               "Get-DZEnvironmentProfileList",
               "Get-DZEnvironmentList",
               "Get-DZLineageNodeHistoryList",
               "Get-DZMetadataGenerationRunList",
               "Get-DZNotificationList",
               "Get-DZProjectMembershipList",
               "Get-DZProjectList",
               "Get-DZSubscriptionGrantList",
               "Get-DZSubscriptionRequestList",
               "Get-DZSubscriptionList",
               "Get-DZSubscriptionTargetList",
               "Get-DZResourceTag",
               "Get-DZTimeSeriesDataPointList",
               "Submit-DZLineageEvent",
               "New-DZTimeSeriesDataPoint",
               "Write-DZEnvironmentBlueprintConfiguration",
               "Deny-DZPrediction",
               "Deny-DZSubscriptionRequest",
               "Revoke-DZSubscription",
               "Search-DZResource",
               "Search-DZGroupProfile",
               "Search-DZListing",
               "Search-DZType",
               "Search-DZUserProfile",
               "Start-DZDataSourceRun",
               "Start-DZMetadataGenerationRun",
               "Add-DZResourceTag",
               "Remove-DZResourceTag",
               "Update-DZAssetFilter",
               "Update-DZDataSource",
               "Update-DZDomain",
               "Update-DZEnvironment",
               "Update-DZEnvironmentAction",
               "Update-DZEnvironmentProfile",
               "Update-DZGlossary",
               "Update-DZGlossaryTerm",
               "Update-DZGroupProfile",
               "Update-DZProject",
               "Update-DZSubscriptionGrantStatus",
               "Update-DZSubscriptionRequest",
               "Update-DZSubscriptionTarget",
               "Update-DZUserProfile")
}

_awsArgumentCompleterRegistration $DZ_SelectCompleters $DZ_SelectMap

