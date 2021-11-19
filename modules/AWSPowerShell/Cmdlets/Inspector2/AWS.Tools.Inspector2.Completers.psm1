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
        "Get-INS2FindingAggregationList/AggregationRequest_AccountAggregation_SortBy"
        {
            $v = "ALL","CRITICAL","HIGH"
            break
        }

        # Amazon.Inspector2.AggregationFindingType
        {
            ($_ -eq "Get-INS2FindingAggregationList/AggregationRequest_AccountAggregation_FindingType") -Or
            ($_ -eq "Get-INS2FindingAggregationList/AggregationRequest_FindingTypeAggregation_FindingType")
        }
        {
            $v = "NETWORK_REACHABILITY","PACKAGE_VULNERABILITY"
            break
        }

        # Amazon.Inspector2.AggregationResourceType
        {
            ($_ -eq "Get-INS2FindingAggregationList/AggregationRequest_AccountAggregation_ResourceType") -Or
            ($_ -eq "Get-INS2FindingAggregationList/AggregationRequest_FindingTypeAggregation_ResourceType") -Or
            ($_ -eq "Get-INS2FindingAggregationList/AggregationRequest_TitleAggregation_ResourceType")
        }
        {
            $v = "AWS_EC2_INSTANCE","AWS_ECR_CONTAINER_IMAGE"
            break
        }

        # Amazon.Inspector2.AggregationType
        "Get-INS2FindingAggregationList/AggregationType"
        {
            $v = "ACCOUNT","AMI","AWS_EC2_INSTANCE","AWS_ECR_CONTAINER","FINDING_TYPE","IMAGE_LAYER","PACKAGE","REPOSITORY","TITLE"
            break
        }

        # Amazon.Inspector2.AmiSortBy
        "Get-INS2FindingAggregationList/AggregationRequest_AmiAggregation_SortBy"
        {
            $v = "AFFECTED_INSTANCES","ALL","CRITICAL","HIGH"
            break
        }

        # Amazon.Inspector2.AwsEcrContainerSortBy
        "Get-INS2FindingAggregationList/AggregationRequest_AwsEcrContainerAggregation_SortBy"
        {
            $v = "ALL","CRITICAL","HIGH"
            break
        }

        # Amazon.Inspector2.Ec2InstanceSortBy
        "Get-INS2FindingAggregationList/AggregationRequest_Ec2InstanceAggregation_SortBy"
        {
            $v = "ALL","CRITICAL","HIGH","NETWORK_FINDINGS"
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
        "Get-INS2FindingAggregationList/AggregationRequest_FindingTypeAggregation_SortBy"
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
        "Get-INS2FindingAggregationList/AggregationRequest_ImageLayerAggregation_SortBy"
        {
            $v = "ALL","CRITICAL","HIGH"
            break
        }

        # Amazon.Inspector2.PackageSortBy
        "Get-INS2FindingAggregationList/AggregationRequest_PackageAggregation_SortBy"
        {
            $v = "ALL","CRITICAL","HIGH"
            break
        }

        # Amazon.Inspector2.ReportFormat
        "New-INS2FindingsReport/ReportFormat"
        {
            $v = "CSV","JSON"
            break
        }

        # Amazon.Inspector2.RepositorySortBy
        "Get-INS2FindingAggregationList/AggregationRequest_RepositoryAggregation_SortBy"
        {
            $v = "AFFECTED_IMAGES","ALL","CRITICAL","HIGH"
            break
        }

        # Amazon.Inspector2.Service
        "Get-INS2AccountPermissionList/Service"
        {
            $v = "EC2","ECR"
            break
        }

        # Amazon.Inspector2.SortField
        "Get-INS2FindingList/SortCriteria_Field"
        {
            $v = "AWS_ACCOUNT_ID","COMPONENT_TYPE","ECR_IMAGE_PUSHED_AT","ECR_IMAGE_REGISTRY","ECR_IMAGE_REPOSITORY_NAME","FINDING_STATUS","FINDING_TYPE","FIRST_OBSERVED_AT","INSPECTOR_SCORE","LAST_OBSERVED_AT","NETWORK_PROTOCOL","RESOURCE_TYPE","SEVERITY","VENDOR_SEVERITY","VULNERABILITY_ID","VULNERABILITY_SOURCE"
            break
        }

        # Amazon.Inspector2.SortOrder
        {
            ($_ -eq "Get-INS2FindingAggregationList/AggregationRequest_AccountAggregation_SortOrder") -Or
            ($_ -eq "Get-INS2FindingAggregationList/AggregationRequest_AmiAggregation_SortOrder") -Or
            ($_ -eq "Get-INS2FindingAggregationList/AggregationRequest_AwsEcrContainerAggregation_SortOrder") -Or
            ($_ -eq "Get-INS2FindingAggregationList/AggregationRequest_Ec2InstanceAggregation_SortOrder") -Or
            ($_ -eq "Get-INS2FindingAggregationList/AggregationRequest_FindingTypeAggregation_SortOrder") -Or
            ($_ -eq "Get-INS2FindingAggregationList/AggregationRequest_ImageLayerAggregation_SortOrder") -Or
            ($_ -eq "Get-INS2FindingAggregationList/AggregationRequest_PackageAggregation_SortOrder") -Or
            ($_ -eq "Get-INS2FindingAggregationList/AggregationRequest_RepositoryAggregation_SortOrder") -Or
            ($_ -eq "Get-INS2FindingAggregationList/AggregationRequest_TitleAggregation_SortOrder") -Or
            ($_ -eq "Get-INS2FindingList/SortCriteria_SortOrder")
        }
        {
            $v = "ASC","DESC"
            break
        }

        # Amazon.Inspector2.TitleSortBy
        "Get-INS2FindingAggregationList/AggregationRequest_TitleAggregation_SortBy"
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
    "Action"=@("Get-INS2FilterList","New-INS2Filter","Update-INS2Filter")
    "AggregationRequest_AccountAggregation_FindingType"=@("Get-INS2FindingAggregationList")
    "AggregationRequest_AccountAggregation_ResourceType"=@("Get-INS2FindingAggregationList")
    "AggregationRequest_AccountAggregation_SortBy"=@("Get-INS2FindingAggregationList")
    "AggregationRequest_AccountAggregation_SortOrder"=@("Get-INS2FindingAggregationList")
    "AggregationRequest_AmiAggregation_SortBy"=@("Get-INS2FindingAggregationList")
    "AggregationRequest_AmiAggregation_SortOrder"=@("Get-INS2FindingAggregationList")
    "AggregationRequest_AwsEcrContainerAggregation_SortBy"=@("Get-INS2FindingAggregationList")
    "AggregationRequest_AwsEcrContainerAggregation_SortOrder"=@("Get-INS2FindingAggregationList")
    "AggregationRequest_Ec2InstanceAggregation_SortBy"=@("Get-INS2FindingAggregationList")
    "AggregationRequest_Ec2InstanceAggregation_SortOrder"=@("Get-INS2FindingAggregationList")
    "AggregationRequest_FindingTypeAggregation_FindingType"=@("Get-INS2FindingAggregationList")
    "AggregationRequest_FindingTypeAggregation_ResourceType"=@("Get-INS2FindingAggregationList")
    "AggregationRequest_FindingTypeAggregation_SortBy"=@("Get-INS2FindingAggregationList")
    "AggregationRequest_FindingTypeAggregation_SortOrder"=@("Get-INS2FindingAggregationList")
    "AggregationRequest_ImageLayerAggregation_SortBy"=@("Get-INS2FindingAggregationList")
    "AggregationRequest_ImageLayerAggregation_SortOrder"=@("Get-INS2FindingAggregationList")
    "AggregationRequest_PackageAggregation_SortBy"=@("Get-INS2FindingAggregationList")
    "AggregationRequest_PackageAggregation_SortOrder"=@("Get-INS2FindingAggregationList")
    "AggregationRequest_RepositoryAggregation_SortBy"=@("Get-INS2FindingAggregationList")
    "AggregationRequest_RepositoryAggregation_SortOrder"=@("Get-INS2FindingAggregationList")
    "AggregationRequest_TitleAggregation_ResourceType"=@("Get-INS2FindingAggregationList")
    "AggregationRequest_TitleAggregation_SortBy"=@("Get-INS2FindingAggregationList")
    "AggregationRequest_TitleAggregation_SortOrder"=@("Get-INS2FindingAggregationList")
    "AggregationType"=@("Get-INS2FindingAggregationList")
    "GroupBy"=@("Get-INS2CoverageStatisticList")
    "ReportFormat"=@("New-INS2FindingsReport")
    "Service"=@("Get-INS2AccountPermissionList")
    "SortCriteria_Field"=@("Get-INS2FindingList")
    "SortCriteria_SortOrder"=@("Get-INS2FindingList")
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
               "Get-INS2GetAccountStatus",
               "Get-INS2GetFreeTrialInfo",
               "Stop-INS2FindingsReport",
               "New-INS2Filter",
               "New-INS2FindingsReport",
               "Remove-INS2Filter",
               "Get-INS2OrganizationConfiguration",
               "Stop-INS2Service",
               "Disable-INS2DelegatedAdminAccount",
               "Unregister-INS2Member",
               "Stop-INS2Inspector",
               "Enable-INS2DelegatedAdminAccount",
               "Get-INS2DelegatedAdminAccount",
               "Get-INS2FindingsReportStatus",
               "Get-INS2Member",
               "Get-INS2AccountPermissionList",
               "Get-INS2CoverageList",
               "Get-INS2CoverageStatisticList",
               "Get-INS2DelegatedAdminAccountList",
               "Get-INS2FilterList",
               "Get-INS2FindingAggregationList",
               "Get-INS2FindingList",
               "Get-INS2MemberList",
               "Get-INS2ResourceTag",
               "Get-INS2UsageTotalList",
               "Add-INS2ResourceTag",
               "Remove-INS2ResourceTag",
               "Update-INS2Filter",
               "Update-INS2OrganizationConfiguration")
}

_awsArgumentCompleterRegistration $INS2_SelectCompleters $INS2_SelectMap

