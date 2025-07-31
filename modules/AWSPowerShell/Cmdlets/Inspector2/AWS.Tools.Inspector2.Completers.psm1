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

# Argument completions for service Inspector2


$INS2_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Inspector2.AccountSortBy
        "Get-INS2FindingAggregationList/AccountAggregation_SortBy"
        {
            $v = "ALL","CRITICAL","HIGH"
            break
        }

        # Amazon.Inspector2.AggregationFindingType
        {
            ($_ -eq "Get-INS2FindingAggregationList/AccountAggregation_FindingType") -Or
            ($_ -eq "Get-INS2FindingAggregationList/FindingTypeAggregation_FindingType") -Or
            ($_ -eq "Get-INS2FindingAggregationList/TitleAggregation_FindingType")
        }
        {
            $v = "CODE_VULNERABILITY","NETWORK_REACHABILITY","PACKAGE_VULNERABILITY"
            break
        }

        # Amazon.Inspector2.AggregationResourceType
        {
            ($_ -eq "Get-INS2FindingAggregationList/AccountAggregation_ResourceType") -Or
            ($_ -eq "Get-INS2FindingAggregationList/FindingTypeAggregation_ResourceType") -Or
            ($_ -eq "Get-INS2FindingAggregationList/TitleAggregation_ResourceType")
        }
        {
            $v = "AWS_EC2_INSTANCE","AWS_ECR_CONTAINER_IMAGE","AWS_LAMBDA_FUNCTION","CODE_REPOSITORY"
            break
        }

        # Amazon.Inspector2.AggregationType
        "Get-INS2FindingAggregationList/AggregationType"
        {
            $v = "ACCOUNT","AMI","AWS_EC2_INSTANCE","AWS_ECR_CONTAINER","AWS_LAMBDA_FUNCTION","CODE_REPOSITORY","FINDING_TYPE","IMAGE_LAYER","LAMBDA_LAYER","PACKAGE","REPOSITORY","TITLE"
            break
        }

        # Amazon.Inspector2.AmiSortBy
        "Get-INS2FindingAggregationList/AmiAggregation_SortBy"
        {
            $v = "AFFECTED_INSTANCES","ALL","CRITICAL","HIGH"
            break
        }

        # Amazon.Inspector2.AwsEcrContainerSortBy
        "Get-INS2FindingAggregationList/AwsEcrContainerAggregation_SortBy"
        {
            $v = "ALL","CRITICAL","HIGH"
            break
        }

        # Amazon.Inspector2.CisReportFormat
        "Get-INS2CisScanReport/ReportFormat"
        {
            $v = "CSV","PDF"
            break
        }

        # Amazon.Inspector2.CisScanConfigurationsSortBy
        "Get-INS2CisScanConfigurationList/SortBy"
        {
            $v = "SCAN_CONFIGURATION_ARN","SCAN_NAME"
            break
        }

        # Amazon.Inspector2.CisScanResultDetailsSortBy
        "Get-INS2CisScanResultDetail/SortBy"
        {
            $v = "CHECK_ID","STATUS"
            break
        }

        # Amazon.Inspector2.CisScanResultsAggregatedByChecksSortBy
        "Get-INS2CisScanResultsAggregatedByCheckList/SortBy"
        {
            $v = "CHECK_ID","FAILED_COUNTS","PLATFORM","SECURITY_LEVEL","TITLE"
            break
        }

        # Amazon.Inspector2.CisScanResultsAggregatedByTargetResourceSortBy
        "Get-INS2CisScanResultsAggregatedByTargetResourceList/SortBy"
        {
            $v = "ACCOUNT_ID","FAILED_COUNTS","PLATFORM","RESOURCE_ID","TARGET_STATUS","TARGET_STATUS_REASON"
            break
        }

        # Amazon.Inspector2.CisSecurityLevel
        {
            ($_ -eq "New-INS2CisScanConfiguration/SecurityLevel") -Or
            ($_ -eq "Update-INS2CisScanConfiguration/SecurityLevel")
        }
        {
            $v = "LEVEL_1","LEVEL_2"
            break
        }

        # Amazon.Inspector2.CisSortOrder
        {
            ($_ -eq "Get-INS2CisScanConfigurationList/SortOrder") -Or
            ($_ -eq "Get-INS2CisScanList/SortOrder") -Or
            ($_ -eq "Get-INS2CisScanResultDetail/SortOrder") -Or
            ($_ -eq "Get-INS2CisScanResultsAggregatedByCheckList/SortOrder") -Or
            ($_ -eq "Get-INS2CisScanResultsAggregatedByTargetResourceList/SortOrder")
        }
        {
            $v = "ASC","DESC"
            break
        }

        # Amazon.Inspector2.CodeRepositorySortBy
        "Get-INS2FindingAggregationList/CodeRepositoryAggregation_SortBy"
        {
            $v = "ALL","CRITICAL","HIGH"
            break
        }

        # Amazon.Inspector2.ConfigurationLevel
        "New-INS2CodeSecurityScanConfiguration/Level"
        {
            $v = "ACCOUNT","ORGANIZATION"
            break
        }

        # Amazon.Inspector2.Day
        {
            ($_ -eq "New-INS2CisScanConfiguration/Monthly_Day") -Or
            ($_ -eq "Update-INS2CisScanConfiguration/Monthly_Day")
        }
        {
            $v = "FRI","MON","SAT","SUN","THU","TUE","WED"
            break
        }

        # Amazon.Inspector2.Ec2InstanceSortBy
        "Get-INS2FindingAggregationList/Ec2InstanceAggregation_SortBy"
        {
            $v = "ALL","CRITICAL","HIGH","NETWORK_FINDINGS"
            break
        }

        # Amazon.Inspector2.Ec2ScanMode
        "Update-INS2Configuration/Ec2Configuration_ScanMode"
        {
            $v = "EC2_HYBRID","EC2_SSM_AGENT_BASED"
            break
        }

        # Amazon.Inspector2.EcrPullDateRescanDuration
        "Update-INS2Configuration/EcrConfiguration_PullDateRescanDuration"
        {
            $v = "DAYS_14","DAYS_180","DAYS_30","DAYS_60","DAYS_90"
            break
        }

        # Amazon.Inspector2.EcrPullDateRescanMode
        "Update-INS2Configuration/EcrConfiguration_PullDateRescanMode"
        {
            $v = "LAST_IN_USE_AT","LAST_PULL_DATE"
            break
        }

        # Amazon.Inspector2.EcrRescanDuration
        "Update-INS2Configuration/EcrConfiguration_RescanDuration"
        {
            $v = "DAYS_14","DAYS_180","DAYS_30","DAYS_60","DAYS_90","LIFETIME"
            break
        }

        # Amazon.Inspector2.FilterAction
        {
            ($_ -eq "Get-INS2FilterList/Action") -Or
            ($_ -eq "New-INS2Filter/Action") -Or
            ($_ -eq "Update-INS2Filter/Action")
        }
        {
            $v = "NONE","SUPPRESS"
            break
        }

        # Amazon.Inspector2.FindingTypeSortBy
        "Get-INS2FindingAggregationList/FindingTypeAggregation_SortBy"
        {
            $v = "ALL","CRITICAL","HIGH"
            break
        }

        # Amazon.Inspector2.GroupKey
        "Get-INS2CoverageStatisticList/GroupBy"
        {
            $v = "ACCOUNT_ID","ECR_REPOSITORY_NAME","RESOURCE_TYPE","SCAN_STATUS_CODE","SCAN_STATUS_REASON"
            break
        }

        # Amazon.Inspector2.ImageLayerSortBy
        "Get-INS2FindingAggregationList/ImageLayerAggregation_SortBy"
        {
            $v = "ALL","CRITICAL","HIGH"
            break
        }

        # Amazon.Inspector2.IntegrationType
        "New-INS2CodeSecurityIntegration/Type"
        {
            $v = "GITHUB","GITLAB_SELF_MANAGED"
            break
        }

        # Amazon.Inspector2.LambdaFunctionSortBy
        "Get-INS2FindingAggregationList/LambdaFunctionAggregation_SortBy"
        {
            $v = "ALL","CRITICAL","HIGH"
            break
        }

        # Amazon.Inspector2.LambdaLayerSortBy
        "Get-INS2FindingAggregationList/LambdaLayerAggregation_SortBy"
        {
            $v = "ALL","CRITICAL","HIGH"
            break
        }

        # Amazon.Inspector2.ListCisScansDetailLevel
        "Get-INS2CisScanList/DetailLevel"
        {
            $v = "MEMBER","ORGANIZATION"
            break
        }

        # Amazon.Inspector2.ListCisScansSortBy
        "Get-INS2CisScanList/SortBy"
        {
            $v = "FAILED_CHECKS","SCAN_START_DATE","SCHEDULED_BY","STATUS"
            break
        }

        # Amazon.Inspector2.PackageSortBy
        "Get-INS2FindingAggregationList/PackageAggregation_SortBy"
        {
            $v = "ALL","CRITICAL","HIGH"
            break
        }

        # Amazon.Inspector2.PeriodicScanFrequency
        {
            ($_ -eq "New-INS2CodeSecurityScanConfiguration/PeriodicScanConfiguration_Frequency") -Or
            ($_ -eq "Update-INS2CodeSecurityScanConfiguration/PeriodicScanConfiguration_Frequency")
        }
        {
            $v = "MONTHLY","NEVER","WEEKLY"
            break
        }

        # Amazon.Inspector2.ProjectSelectionScope
        "New-INS2CodeSecurityScanConfiguration/ScopeSettings_ProjectSelectionScope"
        {
            $v = "ALL"
            break
        }

        # Amazon.Inspector2.ReportFormat
        "New-INS2FindingsReport/ReportFormat"
        {
            $v = "CSV","JSON"
            break
        }

        # Amazon.Inspector2.RepositorySortBy
        "Get-INS2FindingAggregationList/RepositoryAggregation_SortBy"
        {
            $v = "AFFECTED_IMAGES","ALL","CRITICAL","HIGH"
            break
        }

        # Amazon.Inspector2.ResourceType
        {
            ($_ -eq "Get-INS2EncryptionKey/ResourceType") -Or
            ($_ -eq "Reset-INS2EncryptionKey/ResourceType") -Or
            ($_ -eq "Update-INS2EncryptionKey/ResourceType")
        }
        {
            $v = "AWS_EC2_INSTANCE","AWS_ECR_CONTAINER_IMAGE","AWS_ECR_REPOSITORY","AWS_LAMBDA_FUNCTION","CODE_REPOSITORY"
            break
        }

        # Amazon.Inspector2.SbomReportFormat
        "New-INS2SbomExport/ReportFormat"
        {
            $v = "CYCLONEDX_1_4","SPDX_2_3"
            break
        }

        # Amazon.Inspector2.ScanType
        {
            ($_ -eq "Get-INS2EncryptionKey/ScanType") -Or
            ($_ -eq "Reset-INS2EncryptionKey/ScanType") -Or
            ($_ -eq "Update-INS2EncryptionKey/ScanType")
        }
        {
            $v = "CODE","NETWORK","PACKAGE"
            break
        }

        # Amazon.Inspector2.Service
        "Get-INS2AccountPermissionList/Service"
        {
            $v = "EC2","ECR","LAMBDA"
            break
        }

        # Amazon.Inspector2.SortField
        "Get-INS2FindingList/SortCriteria_Field"
        {
            $v = "AWS_ACCOUNT_ID","COMPONENT_TYPE","ECR_IMAGE_PUSHED_AT","ECR_IMAGE_REGISTRY","ECR_IMAGE_REPOSITORY_NAME","EPSS_SCORE","FINDING_STATUS","FINDING_TYPE","FIRST_OBSERVED_AT","INSPECTOR_SCORE","LAST_OBSERVED_AT","NETWORK_PROTOCOL","RESOURCE_TYPE","SEVERITY","VENDOR_SEVERITY","VULNERABILITY_ID","VULNERABILITY_SOURCE"
            break
        }

        # Amazon.Inspector2.SortOrder
        {
            ($_ -eq "Get-INS2FindingAggregationList/AccountAggregation_SortOrder") -Or
            ($_ -eq "Get-INS2FindingAggregationList/AmiAggregation_SortOrder") -Or
            ($_ -eq "Get-INS2FindingAggregationList/AwsEcrContainerAggregation_SortOrder") -Or
            ($_ -eq "Get-INS2FindingAggregationList/CodeRepositoryAggregation_SortOrder") -Or
            ($_ -eq "Get-INS2FindingAggregationList/Ec2InstanceAggregation_SortOrder") -Or
            ($_ -eq "Get-INS2FindingAggregationList/FindingTypeAggregation_SortOrder") -Or
            ($_ -eq "Get-INS2FindingAggregationList/ImageLayerAggregation_SortOrder") -Or
            ($_ -eq "Get-INS2FindingAggregationList/LambdaFunctionAggregation_SortOrder") -Or
            ($_ -eq "Get-INS2FindingAggregationList/LambdaLayerAggregation_SortOrder") -Or
            ($_ -eq "Get-INS2FindingAggregationList/PackageAggregation_SortOrder") -Or
            ($_ -eq "Get-INS2FindingAggregationList/RepositoryAggregation_SortOrder") -Or
            ($_ -eq "Get-INS2FindingList/SortCriteria_SortOrder") -Or
            ($_ -eq "Get-INS2FindingAggregationList/TitleAggregation_SortOrder")
        }
        {
            $v = "ASC","DESC"
            break
        }

        # Amazon.Inspector2.StopCisSessionStatus
        "Stop-INS2CisSession/Message_Status"
        {
            $v = "FAILED","INTERRUPTED","SUCCESS","UNSUPPORTED_OS"
            break
        }

        # Amazon.Inspector2.TitleSortBy
        "Get-INS2FindingAggregationList/TitleAggregation_SortBy"
        {
            $v = "ALL","CRITICAL","HIGH"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$INS2_map = @{
    "AccountAggregation_FindingType"=@("Get-INS2FindingAggregationList")
    "AccountAggregation_ResourceType"=@("Get-INS2FindingAggregationList")
    "AccountAggregation_SortBy"=@("Get-INS2FindingAggregationList")
    "AccountAggregation_SortOrder"=@("Get-INS2FindingAggregationList")
    "Action"=@("Get-INS2FilterList","New-INS2Filter","Update-INS2Filter")
    "AggregationType"=@("Get-INS2FindingAggregationList")
    "AmiAggregation_SortBy"=@("Get-INS2FindingAggregationList")
    "AmiAggregation_SortOrder"=@("Get-INS2FindingAggregationList")
    "AwsEcrContainerAggregation_SortBy"=@("Get-INS2FindingAggregationList")
    "AwsEcrContainerAggregation_SortOrder"=@("Get-INS2FindingAggregationList")
    "CodeRepositoryAggregation_SortBy"=@("Get-INS2FindingAggregationList")
    "CodeRepositoryAggregation_SortOrder"=@("Get-INS2FindingAggregationList")
    "DetailLevel"=@("Get-INS2CisScanList")
    "Ec2Configuration_ScanMode"=@("Update-INS2Configuration")
    "Ec2InstanceAggregation_SortBy"=@("Get-INS2FindingAggregationList")
    "Ec2InstanceAggregation_SortOrder"=@("Get-INS2FindingAggregationList")
    "EcrConfiguration_PullDateRescanDuration"=@("Update-INS2Configuration")
    "EcrConfiguration_PullDateRescanMode"=@("Update-INS2Configuration")
    "EcrConfiguration_RescanDuration"=@("Update-INS2Configuration")
    "FindingTypeAggregation_FindingType"=@("Get-INS2FindingAggregationList")
    "FindingTypeAggregation_ResourceType"=@("Get-INS2FindingAggregationList")
    "FindingTypeAggregation_SortBy"=@("Get-INS2FindingAggregationList")
    "FindingTypeAggregation_SortOrder"=@("Get-INS2FindingAggregationList")
    "GroupBy"=@("Get-INS2CoverageStatisticList")
    "ImageLayerAggregation_SortBy"=@("Get-INS2FindingAggregationList")
    "ImageLayerAggregation_SortOrder"=@("Get-INS2FindingAggregationList")
    "LambdaFunctionAggregation_SortBy"=@("Get-INS2FindingAggregationList")
    "LambdaFunctionAggregation_SortOrder"=@("Get-INS2FindingAggregationList")
    "LambdaLayerAggregation_SortBy"=@("Get-INS2FindingAggregationList")
    "LambdaLayerAggregation_SortOrder"=@("Get-INS2FindingAggregationList")
    "Level"=@("New-INS2CodeSecurityScanConfiguration")
    "Message_Status"=@("Stop-INS2CisSession")
    "Monthly_Day"=@("New-INS2CisScanConfiguration","Update-INS2CisScanConfiguration")
    "PackageAggregation_SortBy"=@("Get-INS2FindingAggregationList")
    "PackageAggregation_SortOrder"=@("Get-INS2FindingAggregationList")
    "PeriodicScanConfiguration_Frequency"=@("New-INS2CodeSecurityScanConfiguration","Update-INS2CodeSecurityScanConfiguration")
    "ReportFormat"=@("Get-INS2CisScanReport","New-INS2FindingsReport","New-INS2SbomExport")
    "RepositoryAggregation_SortBy"=@("Get-INS2FindingAggregationList")
    "RepositoryAggregation_SortOrder"=@("Get-INS2FindingAggregationList")
    "ResourceType"=@("Get-INS2EncryptionKey","Reset-INS2EncryptionKey","Update-INS2EncryptionKey")
    "ScanType"=@("Get-INS2EncryptionKey","Reset-INS2EncryptionKey","Update-INS2EncryptionKey")
    "ScopeSettings_ProjectSelectionScope"=@("New-INS2CodeSecurityScanConfiguration")
    "SecurityLevel"=@("New-INS2CisScanConfiguration","Update-INS2CisScanConfiguration")
    "Service"=@("Get-INS2AccountPermissionList")
    "SortBy"=@("Get-INS2CisScanConfigurationList","Get-INS2CisScanList","Get-INS2CisScanResultDetail","Get-INS2CisScanResultsAggregatedByCheckList","Get-INS2CisScanResultsAggregatedByTargetResourceList")
    "SortCriteria_Field"=@("Get-INS2FindingList")
    "SortCriteria_SortOrder"=@("Get-INS2FindingList")
    "SortOrder"=@("Get-INS2CisScanConfigurationList","Get-INS2CisScanList","Get-INS2CisScanResultDetail","Get-INS2CisScanResultsAggregatedByCheckList","Get-INS2CisScanResultsAggregatedByTargetResourceList")
    "TitleAggregation_FindingType"=@("Get-INS2FindingAggregationList")
    "TitleAggregation_ResourceType"=@("Get-INS2FindingAggregationList")
    "TitleAggregation_SortBy"=@("Get-INS2FindingAggregationList")
    "TitleAggregation_SortOrder"=@("Get-INS2FindingAggregationList")
    "Type"=@("New-INS2CodeSecurityIntegration")
}

_awsArgumentCompleterRegistration $INS2_Completers $INS2_map

$INS2_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.INS2.$($commandName.Replace('-', ''))Cmdlet]"
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

$INS2_SelectMap = @{
    "Select"=@("Register-INS2Member",
               "Register-INS2CodeSecurityScanConfigurationBatch",
               "Unregister-INS2CodeSecurityScanConfigurationBatch",
               "Get-INS2GetAccountStatus",
               "Get-INS2BatchGetCodeSnippet",
               "Get-INS2GetFindingDetail",
               "Get-INS2GetFreeTrialInfo",
               "Get-INS2BatchMemberEc2DeepInspectionStatus",
               "Update-INS2BatchMemberEc2DeepInspectionStatus",
               "Stop-INS2FindingsReport",
               "Stop-INS2SbomExport",
               "New-INS2CisScanConfiguration",
               "New-INS2CodeSecurityIntegration",
               "New-INS2CodeSecurityScanConfiguration",
               "New-INS2Filter",
               "New-INS2FindingsReport",
               "New-INS2SbomExport",
               "Remove-INS2CisScanConfiguration",
               "Remove-INS2CodeSecurityIntegration",
               "Remove-INS2CodeSecurityScanConfiguration",
               "Remove-INS2Filter",
               "Get-INS2OrganizationConfiguration",
               "Stop-INS2Service",
               "Disable-INS2DelegatedAdminAccount",
               "Unregister-INS2Member",
               "Stop-INS2Inspector",
               "Enable-INS2DelegatedAdminAccount",
               "Get-INS2CisScanReport",
               "Get-INS2CisScanResultDetail",
               "Get-INS2ClustersForImage",
               "Get-INS2CodeSecurityIntegration",
               "Get-INS2CodeSecurityScan",
               "Get-INS2CodeSecurityScanConfiguration",
               "Get-INS2Configuration",
               "Get-INS2DelegatedAdminAccount",
               "Get-INS2Ec2DeepInspectionConfiguration",
               "Get-INS2EncryptionKey",
               "Get-INS2FindingsReportStatus",
               "Get-INS2Member",
               "Get-INS2SbomExport",
               "Get-INS2AccountPermissionList",
               "Get-INS2CisScanConfigurationList",
               "Get-INS2CisScanResultsAggregatedByCheckList",
               "Get-INS2CisScanResultsAggregatedByTargetResourceList",
               "Get-INS2CisScanList",
               "Get-INS2CodeSecurityIntegrationList",
               "Get-INS2CodeSecurityScanConfigurationAssociationList",
               "Get-INS2CodeSecurityScanConfigurationList",
               "Get-INS2CoverageList",
               "Get-INS2CoverageStatisticList",
               "Get-INS2DelegatedAdminAccountList",
               "Get-INS2FilterList",
               "Get-INS2FindingAggregationList",
               "Get-INS2FindingList",
               "Get-INS2MemberList",
               "Get-INS2ResourceTag",
               "Get-INS2UsageTotalList",
               "Reset-INS2EncryptionKey",
               "Search-INS2Vulnerability",
               "Send-INS2CisSessionHealth",
               "Send-INS2CisSessionTelemetry",
               "Start-INS2CisSession",
               "Start-INS2CodeSecurityScan",
               "Stop-INS2CisSession",
               "Add-INS2ResourceTag",
               "Remove-INS2ResourceTag",
               "Update-INS2CisScanConfiguration",
               "Update-INS2CodeSecurityIntegration",
               "Update-INS2CodeSecurityScanConfiguration",
               "Update-INS2Configuration",
               "Update-INS2Ec2DeepInspectionConfiguration",
               "Update-INS2EncryptionKey",
               "Update-INS2Filter",
               "Update-INS2OrganizationConfiguration",
               "Update-INS2OrgEc2DeepInspectionConfiguration")
}

_awsArgumentCompleterRegistration $INS2_SelectCompleters $INS2_SelectMap

