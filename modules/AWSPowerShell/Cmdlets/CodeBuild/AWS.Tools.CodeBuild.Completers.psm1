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

        # Amazon.CodeBuild.CacheType
        {
            ($_ -eq "New-CBProject/Cache_Type") -Or
            ($_ -eq "Update-CBProject/Cache_Type") -Or
            ($_ -eq "Start-CBBuild/CacheOverride_Type")
        }
        {
            $v = "LOCAL","NO_CACHE","S3"
            break
        }

        # Amazon.CodeBuild.ComputeType
        {
            ($_ -eq "Start-CBBuild/ComputeTypeOverride") -Or
            ($_ -eq "New-CBProject/Environment_ComputeType") -Or
            ($_ -eq "Update-CBProject/Environment_ComputeType")
        }
        {
            $v = "BUILD_GENERAL1_2XLARGE","BUILD_GENERAL1_LARGE","BUILD_GENERAL1_MEDIUM","BUILD_GENERAL1_SMALL"
            break
        }

        # Amazon.CodeBuild.CredentialProviderType
        {
            ($_ -eq "New-CBProject/Environment_RegistryCredential_CredentialProvider") -Or
            ($_ -eq "Update-CBProject/Environment_RegistryCredential_CredentialProvider") -Or
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
            ($_ -eq "Start-CBBuild/EnvironmentTypeOverride")
        }
        {
            $v = "ARM_CONTAINER","LINUX_CONTAINER","LINUX_GPU_CONTAINER","WINDOWS_CONTAINER"
            break
        }

        # Amazon.CodeBuild.ImagePullCredentialsType
        {
            ($_ -eq "New-CBProject/Environment_ImagePullCredentialsType") -Or
            ($_ -eq "Update-CBProject/Environment_ImagePullCredentialsType") -Or
            ($_ -eq "Start-CBBuild/ImagePullCredentialsTypeOverride")
        }
        {
            $v = "CODEBUILD","SERVICE_ROLE"
            break
        }

        # Amazon.CodeBuild.LogsConfigStatusType
        {
            ($_ -eq "New-CBProject/LogsConfig_CloudWatchLogs_Status") -Or
            ($_ -eq "Update-CBProject/LogsConfig_CloudWatchLogs_Status") -Or
            ($_ -eq "New-CBProject/LogsConfig_S3Logs_Status") -Or
            ($_ -eq "Update-CBProject/LogsConfig_S3Logs_Status") -Or
            ($_ -eq "Start-CBBuild/LogsConfigOverride_CloudWatchLogs_Status") -Or
            ($_ -eq "Start-CBBuild/LogsConfigOverride_S3Logs_Status")
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

        # Amazon.CodeBuild.ReportPackagingType
        {
            ($_ -eq "New-CBReportGroup/ExportConfig_S3Destination_Packaging") -Or
            ($_ -eq "Update-CBReportGroup/ExportConfig_S3Destination_Packaging")
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
            $v = "TEST"
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
            ($_ -eq "Get-CBBuildIdList/SortOrder") -Or
            ($_ -eq "Get-CBBuildIdListForProject/SortOrder") -Or
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
            ($_ -eq "New-CBProject/Source_Auth_Type") -Or
            ($_ -eq "Update-CBProject/Source_Auth_Type") -Or
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
            ($_ -eq "Start-CBBuild/SourceTypeOverride")
        }
        {
            $v = "BITBUCKET","CODECOMMIT","CODEPIPELINE","GITHUB","GITHUB_ENTERPRISE","NO_SOURCE","S3"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CB_map = @{
    "Artifacts_NamespaceType"=@("New-CBProject","Update-CBProject")
    "Artifacts_Packaging"=@("New-CBProject","Update-CBProject")
    "Artifacts_Type"=@("New-CBProject","Update-CBProject")
    "ArtifactsOverride_NamespaceType"=@("Start-CBBuild")
    "ArtifactsOverride_Packaging"=@("Start-CBBuild")
    "ArtifactsOverride_Type"=@("Start-CBBuild")
    "AuthType"=@("Import-CBSourceCredential")
    "Cache_Type"=@("New-CBProject","Update-CBProject")
    "CacheOverride_Type"=@("Start-CBBuild")
    "ComputeTypeOverride"=@("Start-CBBuild")
    "Environment_ComputeType"=@("New-CBProject","Update-CBProject")
    "Environment_ImagePullCredentialsType"=@("New-CBProject","Update-CBProject")
    "Environment_RegistryCredential_CredentialProvider"=@("New-CBProject","Update-CBProject")
    "Environment_Type"=@("New-CBProject","Update-CBProject")
    "EnvironmentTypeOverride"=@("Start-CBBuild")
    "ExportConfig_ExportConfigType"=@("New-CBReportGroup","Update-CBReportGroup")
    "ExportConfig_S3Destination_Packaging"=@("New-CBReportGroup","Update-CBReportGroup")
    "Filter_Status"=@("Get-CBReportList","Get-CBReportsForReportGroupList")
    "ImagePullCredentialsTypeOverride"=@("Start-CBBuild")
    "LogsConfig_CloudWatchLogs_Status"=@("New-CBProject","Update-CBProject")
    "LogsConfig_S3Logs_Status"=@("New-CBProject","Update-CBProject")
    "LogsConfigOverride_CloudWatchLogs_Status"=@("Start-CBBuild")
    "LogsConfigOverride_S3Logs_Status"=@("Start-CBBuild")
    "RegistryCredentialOverride_CredentialProvider"=@("Start-CBBuild")
    "ServerType"=@("Import-CBSourceCredential")
    "SortBy"=@("Get-CBProjectList","Get-CBReportGroupList","Get-CBSharedProjectList","Get-CBSharedReportGroupList")
    "SortOrder"=@("Get-CBBuildIdList","Get-CBBuildIdListForProject","Get-CBProjectList","Get-CBReportGroupList","Get-CBReportList","Get-CBReportsForReportGroupList","Get-CBSharedProjectList","Get-CBSharedReportGroupList")
    "Source_Auth_Type"=@("New-CBProject","Update-CBProject")
    "Source_Type"=@("New-CBProject","Update-CBProject")
    "SourceAuthOverride_Type"=@("Start-CBBuild")
    "SourceTypeOverride"=@("Start-CBBuild")
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
               "Get-CBBuildBatch",
               "Get-CBProjectBatch",
               "Get-CBReportGroupBatch",
               "Get-CBReportBatch",
               "New-CBProject",
               "New-CBReportGroup",
               "New-CBWebhook",
               "Remove-CBProject",
               "Remove-CBReport",
               "Remove-CBReportGroup",
               "Remove-CBResourcePolicy",
               "Remove-CBSourceCredential",
               "Remove-CBWebhook",
               "Get-CBTestCase",
               "Get-CBResourcePolicy",
               "Import-CBSourceCredential",
               "Reset-CBProjectCache",
               "Get-CBBuildIdList",
               "Get-CBBuildIdListForProject",
               "Get-CBCuratedEnvironmentImageList",
               "Get-CBProjectList",
               "Get-CBReportGroupList",
               "Get-CBReportList",
               "Get-CBReportsForReportGroupList",
               "Get-CBSharedProjectList",
               "Get-CBSharedReportGroupList",
               "Get-CBSourceCredentialList",
               "Write-CBResourcePolicy",
               "Start-CBBuild",
               "Stop-CBBuild",
               "Update-CBProject",
               "Update-CBReportGroup",
               "Update-CBWebhook")
}

_awsArgumentCompleterRegistration $CB_SelectCompleters $CB_SelectMap

