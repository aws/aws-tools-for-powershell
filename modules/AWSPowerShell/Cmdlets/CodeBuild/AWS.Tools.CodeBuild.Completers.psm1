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

# Argument completions for service AWS CodeBuild


$CB_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CodeBuild.ArtifactNamespace
        {
            ($_ -eq "New-CBProject/Artifacts_NamespaceType") -Or
            ($_ -eq "Update-CBProject/Artifacts_NamespaceType") -Or
            ($_ -eq "Start-CBBatch/ArtifactsOverride_NamespaceType") -Or
            ($_ -eq "Start-CBBuild/ArtifactsOverride_NamespaceType")
        }
        {
            $v = "BUILD_ID","NONE"
            break
        }

        # Amazon.CodeBuild.ArtifactPackaging
        {
            ($_ -eq "New-CBProject/Artifacts_Packaging") -Or
            ($_ -eq "Update-CBProject/Artifacts_Packaging") -Or
            ($_ -eq "Start-CBBatch/ArtifactsOverride_Packaging") -Or
            ($_ -eq "Start-CBBuild/ArtifactsOverride_Packaging")
        }
        {
            $v = "NONE","ZIP"
            break
        }

        # Amazon.CodeBuild.ArtifactsType
        {
            ($_ -eq "New-CBProject/Artifacts_Type") -Or
            ($_ -eq "Update-CBProject/Artifacts_Type") -Or
            ($_ -eq "Start-CBBatch/ArtifactsOverride_Type") -Or
            ($_ -eq "Start-CBBuild/ArtifactsOverride_Type")
        }
        {
            $v = "CODEPIPELINE","NO_ARTIFACTS","S3"
            break
        }

        # Amazon.CodeBuild.AuthType
        "Import-CBSourceCredential/AuthType"
        {
            $v = "BASIC_AUTH","OAUTH","PERSONAL_ACCESS_TOKEN"
            break
        }

        # Amazon.CodeBuild.BatchReportModeType
        {
            ($_ -eq "New-CBProject/BuildBatchConfig_BatchReportMode") -Or
            ($_ -eq "Update-CBProject/BuildBatchConfig_BatchReportMode") -Or
            ($_ -eq "Start-CBBatch/BuildBatchConfigOverride_BatchReportMode")
        }
        {
            $v = "REPORT_AGGREGATED_BATCH","REPORT_INDIVIDUAL_BUILDS"
            break
        }

        # Amazon.CodeBuild.BucketOwnerAccess
        {
            ($_ -eq "New-CBProject/Artifacts_BucketOwnerAccess") -Or
            ($_ -eq "Update-CBProject/Artifacts_BucketOwnerAccess") -Or
            ($_ -eq "Start-CBBatch/ArtifactsOverride_BucketOwnerAccess") -Or
            ($_ -eq "Start-CBBuild/ArtifactsOverride_BucketOwnerAccess") -Or
            ($_ -eq "New-CBProject/S3Logs_BucketOwnerAccess") -Or
            ($_ -eq "Start-CBBatch/S3Logs_BucketOwnerAccess") -Or
            ($_ -eq "Start-CBBuild/S3Logs_BucketOwnerAccess") -Or
            ($_ -eq "Update-CBProject/S3Logs_BucketOwnerAccess")
        }
        {
            $v = "FULL","NONE","READ_ONLY"
            break
        }

        # Amazon.CodeBuild.CacheType
        {
            ($_ -eq "New-CBProject/Cache_Type") -Or
            ($_ -eq "Update-CBProject/Cache_Type") -Or
            ($_ -eq "Start-CBBatch/CacheOverride_Type") -Or
            ($_ -eq "Start-CBBuild/CacheOverride_Type")
        }
        {
            $v = "LOCAL","NO_CACHE","S3"
            break
        }

        # Amazon.CodeBuild.ComputeType
        {
            ($_ -eq "New-CBFleet/ComputeType") -Or
            ($_ -eq "Update-CBFleet/ComputeType") -Or
            ($_ -eq "Start-CBBatch/ComputeTypeOverride") -Or
            ($_ -eq "Start-CBBuild/ComputeTypeOverride") -Or
            ($_ -eq "New-CBProject/Environment_ComputeType") -Or
            ($_ -eq "Update-CBProject/Environment_ComputeType")
        }
        {
            $v = "BUILD_GENERAL1_2XLARGE","BUILD_GENERAL1_LARGE","BUILD_GENERAL1_MEDIUM","BUILD_GENERAL1_SMALL","BUILD_GENERAL1_XLARGE","BUILD_LAMBDA_10GB","BUILD_LAMBDA_1GB","BUILD_LAMBDA_2GB","BUILD_LAMBDA_4GB","BUILD_LAMBDA_8GB"
            break
        }

        # Amazon.CodeBuild.CredentialProviderType
        {
            ($_ -eq "New-CBProject/RegistryCredential_CredentialProvider") -Or
            ($_ -eq "Update-CBProject/RegistryCredential_CredentialProvider") -Or
            ($_ -eq "Start-CBBatch/RegistryCredentialOverride_CredentialProvider") -Or
            ($_ -eq "Start-CBBuild/RegistryCredentialOverride_CredentialProvider")
        }
        {
            $v = "SECRETS_MANAGER"
            break
        }

        # Amazon.CodeBuild.EnvironmentType
        {
            ($_ -eq "New-CBProject/Environment_Type") -Or
            ($_ -eq "Update-CBProject/Environment_Type") -Or
            ($_ -eq "New-CBFleet/EnvironmentType") -Or
            ($_ -eq "Update-CBFleet/EnvironmentType") -Or
            ($_ -eq "Start-CBBatch/EnvironmentTypeOverride") -Or
            ($_ -eq "Start-CBBuild/EnvironmentTypeOverride")
        }
        {
            $v = "ARM_CONTAINER","ARM_LAMBDA_CONTAINER","LINUX_CONTAINER","LINUX_GPU_CONTAINER","LINUX_LAMBDA_CONTAINER","WINDOWS_CONTAINER","WINDOWS_SERVER_2019_CONTAINER"
            break
        }

        # Amazon.CodeBuild.FleetScalingType
        {
            ($_ -eq "New-CBFleet/ScalingConfiguration_ScalingType") -Or
            ($_ -eq "Update-CBFleet/ScalingConfiguration_ScalingType")
        }
        {
            $v = "TARGET_TRACKING_SCALING"
            break
        }

        # Amazon.CodeBuild.FleetSortByType
        "Get-CBFleetList/SortBy"
        {
            $v = "CREATED_TIME","LAST_MODIFIED_TIME","NAME"
            break
        }

        # Amazon.CodeBuild.ImagePullCredentialsType
        {
            ($_ -eq "New-CBProject/Environment_ImagePullCredentialsType") -Or
            ($_ -eq "Update-CBProject/Environment_ImagePullCredentialsType") -Or
            ($_ -eq "Start-CBBatch/ImagePullCredentialsTypeOverride") -Or
            ($_ -eq "Start-CBBuild/ImagePullCredentialsTypeOverride")
        }
        {
            $v = "CODEBUILD","SERVICE_ROLE"
            break
        }

        # Amazon.CodeBuild.LogsConfigStatusType
        {
            ($_ -eq "New-CBProject/CloudWatchLogs_Status") -Or
            ($_ -eq "Start-CBBatch/CloudWatchLogs_Status") -Or
            ($_ -eq "Start-CBBuild/CloudWatchLogs_Status") -Or
            ($_ -eq "Update-CBProject/CloudWatchLogs_Status") -Or
            ($_ -eq "New-CBProject/S3Logs_Status") -Or
            ($_ -eq "Start-CBBatch/S3Logs_Status") -Or
            ($_ -eq "Start-CBBuild/S3Logs_Status") -Or
            ($_ -eq "Update-CBProject/S3Logs_Status")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.CodeBuild.ProjectSortByType
        "Get-CBProjectList/SortBy"
        {
            $v = "CREATED_TIME","LAST_MODIFIED_TIME","NAME"
            break
        }

        # Amazon.CodeBuild.ProjectVisibilityType
        "Update-CBProjectVisibility/ProjectVisibility"
        {
            $v = "PRIVATE","PUBLIC_READ"
            break
        }

        # Amazon.CodeBuild.ReportCodeCoverageSortByType
        "Get-CBCodeCoverage/SortBy"
        {
            $v = "FILE_PATH","LINE_COVERAGE_PERCENTAGE"
            break
        }

        # Amazon.CodeBuild.ReportExportConfigType
        {
            ($_ -eq "New-CBReportGroup/ExportConfig_ExportConfigType") -Or
            ($_ -eq "Update-CBReportGroup/ExportConfig_ExportConfigType")
        }
        {
            $v = "NO_EXPORT","S3"
            break
        }

        # Amazon.CodeBuild.ReportGroupSortByType
        "Get-CBReportGroupList/SortBy"
        {
            $v = "CREATED_TIME","LAST_MODIFIED_TIME","NAME"
            break
        }

        # Amazon.CodeBuild.ReportGroupTrendFieldType
        "Get-CBReportGroupTrend/TrendField"
        {
            $v = "BRANCHES_COVERED","BRANCHES_MISSED","BRANCH_COVERAGE","DURATION","LINES_COVERED","LINES_MISSED","LINE_COVERAGE","PASS_RATE","TOTAL"
            break
        }

        # Amazon.CodeBuild.ReportPackagingType
        {
            ($_ -eq "New-CBReportGroup/S3Destination_Packaging") -Or
            ($_ -eq "Update-CBReportGroup/S3Destination_Packaging")
        }
        {
            $v = "NONE","ZIP"
            break
        }

        # Amazon.CodeBuild.ReportStatusType
        {
            ($_ -eq "Get-CBReportList/Filter_Status") -Or
            ($_ -eq "Get-CBReportsForReportGroupList/Filter_Status")
        }
        {
            $v = "DELETING","FAILED","GENERATING","INCOMPLETE","SUCCEEDED"
            break
        }

        # Amazon.CodeBuild.ReportType
        "New-CBReportGroup/Type"
        {
            $v = "CODE_COVERAGE","TEST"
            break
        }

        # Amazon.CodeBuild.RetryBuildBatchType
        "Redo-CBBatch/RetryType"
        {
            $v = "RETRY_ALL_BUILDS","RETRY_FAILED_BUILDS"
            break
        }

        # Amazon.CodeBuild.ServerType
        "Import-CBSourceCredential/ServerType"
        {
            $v = "BITBUCKET","GITHUB","GITHUB_ENTERPRISE"
            break
        }

        # Amazon.CodeBuild.SharedResourceSortByType
        {
            ($_ -eq "Get-CBSharedProjectList/SortBy") -Or
            ($_ -eq "Get-CBSharedReportGroupList/SortBy")
        }
        {
            $v = "ARN","MODIFIED_TIME"
            break
        }

        # Amazon.CodeBuild.SortOrderType
        {
            ($_ -eq "Get-CBBatchIdList/SortOrder") -Or
            ($_ -eq "Get-CBBatchIdListForProject/SortOrder") -Or
            ($_ -eq "Get-CBBuildIdList/SortOrder") -Or
            ($_ -eq "Get-CBBuildIdListForProject/SortOrder") -Or
            ($_ -eq "Get-CBCodeCoverage/SortOrder") -Or
            ($_ -eq "Get-CBFleetList/SortOrder") -Or
            ($_ -eq "Get-CBProjectList/SortOrder") -Or
            ($_ -eq "Get-CBReportGroupList/SortOrder") -Or
            ($_ -eq "Get-CBReportList/SortOrder") -Or
            ($_ -eq "Get-CBReportsForReportGroupList/SortOrder") -Or
            ($_ -eq "Get-CBSharedProjectList/SortOrder") -Or
            ($_ -eq "Get-CBSharedReportGroupList/SortOrder")
        }
        {
            $v = "ASCENDING","DESCENDING"
            break
        }

        # Amazon.CodeBuild.SourceAuthType
        {
            ($_ -eq "New-CBProject/Auth_Type") -Or
            ($_ -eq "Update-CBProject/Auth_Type") -Or
            ($_ -eq "Start-CBBatch/SourceAuthOverride_Type") -Or
            ($_ -eq "Start-CBBuild/SourceAuthOverride_Type")
        }
        {
            $v = "OAUTH"
            break
        }

        # Amazon.CodeBuild.SourceType
        {
            ($_ -eq "New-CBProject/Source_Type") -Or
            ($_ -eq "Update-CBProject/Source_Type") -Or
            ($_ -eq "Start-CBBatch/SourceTypeOverride") -Or
            ($_ -eq "Start-CBBuild/SourceTypeOverride")
        }
        {
            $v = "BITBUCKET","CODECOMMIT","CODEPIPELINE","GITHUB","GITHUB_ENTERPRISE","NO_SOURCE","S3"
            break
        }

        # Amazon.CodeBuild.StatusType
        {
            ($_ -eq "Get-CBBatchIdList/Filter_Status") -Or
            ($_ -eq "Get-CBBatchIdListForProject/Filter_Status")
        }
        {
            $v = "FAILED","FAULT","IN_PROGRESS","STOPPED","SUCCEEDED","TIMED_OUT"
            break
        }

        # Amazon.CodeBuild.WebhookBuildType
        {
            ($_ -eq "New-CBWebhook/BuildType") -Or
            ($_ -eq "Update-CBWebhook/BuildType")
        }
        {
            $v = "BUILD","BUILD_BATCH"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CB_map = @{
    "Artifacts_BucketOwnerAccess"=@("New-CBProject","Update-CBProject")
    "Artifacts_NamespaceType"=@("New-CBProject","Update-CBProject")
    "Artifacts_Packaging"=@("New-CBProject","Update-CBProject")
    "Artifacts_Type"=@("New-CBProject","Update-CBProject")
    "ArtifactsOverride_BucketOwnerAccess"=@("Start-CBBatch","Start-CBBuild")
    "ArtifactsOverride_NamespaceType"=@("Start-CBBatch","Start-CBBuild")
    "ArtifactsOverride_Packaging"=@("Start-CBBatch","Start-CBBuild")
    "ArtifactsOverride_Type"=@("Start-CBBatch","Start-CBBuild")
    "Auth_Type"=@("New-CBProject","Update-CBProject")
    "AuthType"=@("Import-CBSourceCredential")
    "BuildBatchConfig_BatchReportMode"=@("New-CBProject","Update-CBProject")
    "BuildBatchConfigOverride_BatchReportMode"=@("Start-CBBatch")
    "BuildType"=@("New-CBWebhook","Update-CBWebhook")
    "Cache_Type"=@("New-CBProject","Update-CBProject")
    "CacheOverride_Type"=@("Start-CBBatch","Start-CBBuild")
    "CloudWatchLogs_Status"=@("New-CBProject","Start-CBBatch","Start-CBBuild","Update-CBProject")
    "ComputeType"=@("New-CBFleet","Update-CBFleet")
    "ComputeTypeOverride"=@("Start-CBBatch","Start-CBBuild")
    "Environment_ComputeType"=@("New-CBProject","Update-CBProject")
    "Environment_ImagePullCredentialsType"=@("New-CBProject","Update-CBProject")
    "Environment_Type"=@("New-CBProject","Update-CBProject")
    "EnvironmentType"=@("New-CBFleet","Update-CBFleet")
    "EnvironmentTypeOverride"=@("Start-CBBatch","Start-CBBuild")
    "ExportConfig_ExportConfigType"=@("New-CBReportGroup","Update-CBReportGroup")
    "Filter_Status"=@("Get-CBBatchIdList","Get-CBBatchIdListForProject","Get-CBReportList","Get-CBReportsForReportGroupList")
    "ImagePullCredentialsTypeOverride"=@("Start-CBBatch","Start-CBBuild")
    "ProjectVisibility"=@("Update-CBProjectVisibility")
    "RegistryCredential_CredentialProvider"=@("New-CBProject","Update-CBProject")
    "RegistryCredentialOverride_CredentialProvider"=@("Start-CBBatch","Start-CBBuild")
    "RetryType"=@("Redo-CBBatch")
    "S3Destination_Packaging"=@("New-CBReportGroup","Update-CBReportGroup")
    "S3Logs_BucketOwnerAccess"=@("New-CBProject","Start-CBBatch","Start-CBBuild","Update-CBProject")
    "S3Logs_Status"=@("New-CBProject","Start-CBBatch","Start-CBBuild","Update-CBProject")
    "ScalingConfiguration_ScalingType"=@("New-CBFleet","Update-CBFleet")
    "ServerType"=@("Import-CBSourceCredential")
    "SortBy"=@("Get-CBCodeCoverage","Get-CBFleetList","Get-CBProjectList","Get-CBReportGroupList","Get-CBSharedProjectList","Get-CBSharedReportGroupList")
    "SortOrder"=@("Get-CBBatchIdList","Get-CBBatchIdListForProject","Get-CBBuildIdList","Get-CBBuildIdListForProject","Get-CBCodeCoverage","Get-CBFleetList","Get-CBProjectList","Get-CBReportGroupList","Get-CBReportList","Get-CBReportsForReportGroupList","Get-CBSharedProjectList","Get-CBSharedReportGroupList")
    "Source_Type"=@("New-CBProject","Update-CBProject")
    "SourceAuthOverride_Type"=@("Start-CBBatch","Start-CBBuild")
    "SourceTypeOverride"=@("Start-CBBatch","Start-CBBuild")
    "TrendField"=@("Get-CBReportGroupTrend")
    "Type"=@("New-CBReportGroup")
}

_awsArgumentCompleterRegistration $CB_Completers $CB_map

$CB_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CB.$($commandName.Replace('-', ''))Cmdlet]"
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

$CB_SelectMap = @{
    "Select"=@("Remove-CBBuildBatch",
               "Get-CBBatch",
               "Get-CBBuildBatch",
               "Get-CBCBFleetBatch",
               "Get-CBProjectBatch",
               "Get-CBReportGroupBatch",
               "Get-CBReportBatch",
               "New-CBFleet",
               "New-CBProject",
               "New-CBReportGroup",
               "New-CBWebhook",
               "Remove-CBBatch",
               "Remove-CBFleet",
               "Remove-CBProject",
               "Remove-CBReport",
               "Remove-CBReportGroup",
               "Remove-CBResourcePolicy",
               "Remove-CBSourceCredential",
               "Remove-CBWebhook",
               "Get-CBCodeCoverage",
               "Get-CBTestCase",
               "Get-CBReportGroupTrend",
               "Get-CBResourcePolicy",
               "Import-CBSourceCredential",
               "Reset-CBProjectCache",
               "Get-CBBatchIdList",
               "Get-CBBatchIdListForProject",
               "Get-CBBuildIdList",
               "Get-CBBuildIdListForProject",
               "Get-CBCuratedEnvironmentImageList",
               "Get-CBFleetList",
               "Get-CBProjectList",
               "Get-CBReportGroupList",
               "Get-CBReportList",
               "Get-CBReportsForReportGroupList",
               "Get-CBSharedProjectList",
               "Get-CBSharedReportGroupList",
               "Get-CBSourceCredentialList",
               "Write-CBResourcePolicy",
               "Redo-CBBuild",
               "Redo-CBBatch",
               "Start-CBBuild",
               "Start-CBBatch",
               "Stop-CBBuild",
               "Stop-CBBatch",
               "Update-CBFleet",
               "Update-CBProject",
               "Update-CBProjectVisibility",
               "Update-CBReportGroup",
               "Update-CBWebhook")
}

_awsArgumentCompleterRegistration $CB_SelectCompleters $CB_SelectMap

