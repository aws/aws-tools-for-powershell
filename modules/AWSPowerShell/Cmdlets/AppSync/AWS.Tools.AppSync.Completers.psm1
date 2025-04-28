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

# Argument completions for service AWS AppSync


$ASYN_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.AppSync.ApiCacheType
        {
            ($_ -eq "New-ASYNApiCache/Type") -Or
            ($_ -eq "Update-ASYNApiCache/Type")
        }
        {
            $v = "LARGE","LARGE_12X","LARGE_2X","LARGE_4X","LARGE_8X","MEDIUM","R4_2XLARGE","R4_4XLARGE","R4_8XLARGE","R4_LARGE","R4_XLARGE","SMALL","T2_MEDIUM","T2_SMALL","XLARGE"
            break
        }

        # Amazon.AppSync.ApiCachingBehavior
        {
            ($_ -eq "New-ASYNApiCache/ApiCachingBehavior") -Or
            ($_ -eq "Update-ASYNApiCache/ApiCachingBehavior")
        }
        {
            $v = "FULL_REQUEST_CACHING","OPERATION_LEVEL_CACHING","PER_RESOLVER_CACHING"
            break
        }

        # Amazon.AppSync.AuthenticationType
        {
            ($_ -eq "New-ASYNGraphqlApi/AuthenticationType") -Or
            ($_ -eq "Update-ASYNGraphqlApi/AuthenticationType")
        }
        {
            $v = "AMAZON_COGNITO_USER_POOLS","API_KEY","AWS_IAM","AWS_LAMBDA","OPENID_CONNECT"
            break
        }

        # Amazon.AppSync.CacheHealthMetricsConfig
        {
            ($_ -eq "New-ASYNApiCache/HealthMetricsConfig") -Or
            ($_ -eq "Update-ASYNApiCache/HealthMetricsConfig")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.AppSync.ConflictDetectionType
        {
            ($_ -eq "New-ASYNFunction/SyncConfig_ConflictDetection") -Or
            ($_ -eq "New-ASYNResolver/SyncConfig_ConflictDetection") -Or
            ($_ -eq "Update-ASYNFunction/SyncConfig_ConflictDetection") -Or
            ($_ -eq "Update-ASYNResolver/SyncConfig_ConflictDetection")
        }
        {
            $v = "NONE","VERSION"
            break
        }

        # Amazon.AppSync.ConflictHandlerType
        {
            ($_ -eq "New-ASYNFunction/SyncConfig_ConflictHandler") -Or
            ($_ -eq "New-ASYNResolver/SyncConfig_ConflictHandler") -Or
            ($_ -eq "Update-ASYNFunction/SyncConfig_ConflictHandler") -Or
            ($_ -eq "Update-ASYNResolver/SyncConfig_ConflictHandler")
        }
        {
            $v = "AUTOMERGE","LAMBDA","NONE","OPTIMISTIC_CONCURRENCY"
            break
        }

        # Amazon.AppSync.DataSourceLevelMetricsBehavior
        {
            ($_ -eq "New-ASYNGraphqlApi/EnhancedMetricsConfig_DataSourceLevelMetricsBehavior") -Or
            ($_ -eq "Update-ASYNGraphqlApi/EnhancedMetricsConfig_DataSourceLevelMetricsBehavior")
        }
        {
            $v = "FULL_REQUEST_DATA_SOURCE_METRICS","PER_DATA_SOURCE_METRICS"
            break
        }

        # Amazon.AppSync.DataSourceLevelMetricsConfig
        {
            ($_ -eq "New-ASYNDataSource/MetricsConfig") -Or
            ($_ -eq "Update-ASYNDataSource/MetricsConfig")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.AppSync.DataSourceType
        {
            ($_ -eq "New-ASYNDataSource/Type") -Or
            ($_ -eq "Update-ASYNDataSource/Type")
        }
        {
            $v = "AMAZON_BEDROCK_RUNTIME","AMAZON_DYNAMODB","AMAZON_ELASTICSEARCH","AMAZON_EVENTBRIDGE","AMAZON_OPENSEARCH_SERVICE","AWS_LAMBDA","HTTP","NONE","RELATIONAL_DATABASE"
            break
        }

        # Amazon.AppSync.EventLogLevel
        {
            ($_ -eq "New-ASYNApi/LogConfig_LogLevel") -Or
            ($_ -eq "Update-ASYNApi/LogConfig_LogLevel")
        }
        {
            $v = "ALL","DEBUG","ERROR","INFO","NONE"
            break
        }

        # Amazon.AppSync.FieldLogLevel
        {
            ($_ -eq "New-ASYNGraphqlApi/LogConfig_FieldLogLevel") -Or
            ($_ -eq "Update-ASYNGraphqlApi/LogConfig_FieldLogLevel")
        }
        {
            $v = "ALL","DEBUG","ERROR","INFO","NONE"
            break
        }

        # Amazon.AppSync.GraphQLApiIntrospectionConfig
        {
            ($_ -eq "New-ASYNGraphqlApi/IntrospectionConfig") -Or
            ($_ -eq "Update-ASYNGraphqlApi/IntrospectionConfig")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.AppSync.GraphQLApiType
        {
            ($_ -eq "Get-ASYNGraphqlApiList/ApiType") -Or
            ($_ -eq "New-ASYNGraphqlApi/ApiType")
        }
        {
            $v = "GRAPHQL","MERGED"
            break
        }

        # Amazon.AppSync.GraphQLApiVisibility
        "New-ASYNGraphqlApi/Visibility"
        {
            $v = "GLOBAL","PRIVATE"
            break
        }

        # Amazon.AppSync.HandlerBehavior
        {
            ($_ -eq "New-ASYNChannelNamespace/OnPublish_Behavior") -Or
            ($_ -eq "Update-ASYNChannelNamespace/OnPublish_Behavior") -Or
            ($_ -eq "New-ASYNChannelNamespace/OnSubscribe_Behavior") -Or
            ($_ -eq "Update-ASYNChannelNamespace/OnSubscribe_Behavior")
        }
        {
            $v = "CODE","DIRECT"
            break
        }

        # Amazon.AppSync.InvokeType
        {
            ($_ -eq "New-ASYNChannelNamespace/OnPublish_LambdaConfig_InvokeType") -Or
            ($_ -eq "Update-ASYNChannelNamespace/OnPublish_LambdaConfig_InvokeType") -Or
            ($_ -eq "New-ASYNChannelNamespace/OnSubscribe_LambdaConfig_InvokeType") -Or
            ($_ -eq "Update-ASYNChannelNamespace/OnSubscribe_LambdaConfig_InvokeType")
        }
        {
            $v = "EVENT","REQUEST_RESPONSE"
            break
        }

        # Amazon.AppSync.MergeType
        {
            ($_ -eq "Start-ASYNMergedGraphqlApi/SourceApiAssociationConfig_MergeType") -Or
            ($_ -eq "Start-ASYNSourceGraphqlApi/SourceApiAssociationConfig_MergeType") -Or
            ($_ -eq "Update-ASYNSourceApiAssociation/SourceApiAssociationConfig_MergeType")
        }
        {
            $v = "AUTO_MERGE","MANUAL_MERGE"
            break
        }

        # Amazon.AppSync.OperationLevelMetricsConfig
        {
            ($_ -eq "New-ASYNGraphqlApi/EnhancedMetricsConfig_OperationLevelMetricsConfig") -Or
            ($_ -eq "Update-ASYNGraphqlApi/EnhancedMetricsConfig_OperationLevelMetricsConfig")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.AppSync.OutputType
        "Get-ASYNIntrospectionSchema/Format"
        {
            $v = "JSON","SDL"
            break
        }

        # Amazon.AppSync.Ownership
        "Get-ASYNGraphqlApiList/Owner"
        {
            $v = "CURRENT_ACCOUNT","OTHER_ACCOUNTS"
            break
        }

        # Amazon.AppSync.RelationalDatabaseSourceType
        {
            ($_ -eq "New-ASYNDataSource/RelationalDatabaseConfig_RelationalDatabaseSourceType") -Or
            ($_ -eq "Update-ASYNDataSource/RelationalDatabaseConfig_RelationalDatabaseSourceType")
        }
        {
            $v = "RDS_HTTP_ENDPOINT"
            break
        }

        # Amazon.AppSync.ResolverKind
        {
            ($_ -eq "New-ASYNResolver/Kind") -Or
            ($_ -eq "Update-ASYNResolver/Kind")
        }
        {
            $v = "PIPELINE","UNIT"
            break
        }

        # Amazon.AppSync.ResolverLevelMetricsBehavior
        {
            ($_ -eq "New-ASYNGraphqlApi/EnhancedMetricsConfig_ResolverLevelMetricsBehavior") -Or
            ($_ -eq "Update-ASYNGraphqlApi/EnhancedMetricsConfig_ResolverLevelMetricsBehavior")
        }
        {
            $v = "FULL_REQUEST_RESOLVER_METRICS","PER_RESOLVER_METRICS"
            break
        }

        # Amazon.AppSync.ResolverLevelMetricsConfig
        {
            ($_ -eq "New-ASYNResolver/MetricsConfig") -Or
            ($_ -eq "Update-ASYNResolver/MetricsConfig")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.AppSync.RuntimeName
        {
            ($_ -eq "New-ASYNFunction/Runtime_Name") -Or
            ($_ -eq "New-ASYNResolver/Runtime_Name") -Or
            ($_ -eq "Test-ASYNCode/Runtime_Name") -Or
            ($_ -eq "Update-ASYNFunction/Runtime_Name") -Or
            ($_ -eq "Update-ASYNResolver/Runtime_Name")
        }
        {
            $v = "APPSYNC_JS"
            break
        }

        # Amazon.AppSync.TypeDefinitionFormat
        {
            ($_ -eq "Get-ASYNType/Format") -Or
            ($_ -eq "Get-ASYNTypeList/Format") -Or
            ($_ -eq "Get-ASYNTypesByAssociationList/Format") -Or
            ($_ -eq "New-ASYNType/Format") -Or
            ($_ -eq "Update-ASYNType/Format")
        }
        {
            $v = "JSON","SDL"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$ASYN_map = @{
    "ApiCachingBehavior"=@("New-ASYNApiCache","Update-ASYNApiCache")
    "ApiType"=@("Get-ASYNGraphqlApiList","New-ASYNGraphqlApi")
    "AuthenticationType"=@("New-ASYNGraphqlApi","Update-ASYNGraphqlApi")
    "EnhancedMetricsConfig_DataSourceLevelMetricsBehavior"=@("New-ASYNGraphqlApi","Update-ASYNGraphqlApi")
    "EnhancedMetricsConfig_OperationLevelMetricsConfig"=@("New-ASYNGraphqlApi","Update-ASYNGraphqlApi")
    "EnhancedMetricsConfig_ResolverLevelMetricsBehavior"=@("New-ASYNGraphqlApi","Update-ASYNGraphqlApi")
    "Format"=@("Get-ASYNIntrospectionSchema","Get-ASYNType","Get-ASYNTypeList","Get-ASYNTypesByAssociationList","New-ASYNType","Update-ASYNType")
    "HealthMetricsConfig"=@("New-ASYNApiCache","Update-ASYNApiCache")
    "IntrospectionConfig"=@("New-ASYNGraphqlApi","Update-ASYNGraphqlApi")
    "Kind"=@("New-ASYNResolver","Update-ASYNResolver")
    "LogConfig_FieldLogLevel"=@("New-ASYNGraphqlApi","Update-ASYNGraphqlApi")
    "LogConfig_LogLevel"=@("New-ASYNApi","Update-ASYNApi")
    "MetricsConfig"=@("New-ASYNDataSource","New-ASYNResolver","Update-ASYNDataSource","Update-ASYNResolver")
    "OnPublish_Behavior"=@("New-ASYNChannelNamespace","Update-ASYNChannelNamespace")
    "OnPublish_LambdaConfig_InvokeType"=@("New-ASYNChannelNamespace","Update-ASYNChannelNamespace")
    "OnSubscribe_Behavior"=@("New-ASYNChannelNamespace","Update-ASYNChannelNamespace")
    "OnSubscribe_LambdaConfig_InvokeType"=@("New-ASYNChannelNamespace","Update-ASYNChannelNamespace")
    "Owner"=@("Get-ASYNGraphqlApiList")
    "RelationalDatabaseConfig_RelationalDatabaseSourceType"=@("New-ASYNDataSource","Update-ASYNDataSource")
    "Runtime_Name"=@("New-ASYNFunction","New-ASYNResolver","Test-ASYNCode","Update-ASYNFunction","Update-ASYNResolver")
    "SourceApiAssociationConfig_MergeType"=@("Start-ASYNMergedGraphqlApi","Start-ASYNSourceGraphqlApi","Update-ASYNSourceApiAssociation")
    "SyncConfig_ConflictDetection"=@("New-ASYNFunction","New-ASYNResolver","Update-ASYNFunction","Update-ASYNResolver")
    "SyncConfig_ConflictHandler"=@("New-ASYNFunction","New-ASYNResolver","Update-ASYNFunction","Update-ASYNResolver")
    "Type"=@("New-ASYNApiCache","New-ASYNDataSource","Update-ASYNApiCache","Update-ASYNDataSource")
    "Visibility"=@("New-ASYNGraphqlApi")
}

_awsArgumentCompleterRegistration $ASYN_Completers $ASYN_map

$ASYN_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.ASYN.$($commandName.Replace('-', ''))Cmdlet]"
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

$ASYN_SelectMap = @{
    "Select"=@("Start-ASYNApiAssociation",
               "Start-ASYNMergedGraphqlApi",
               "Start-ASYNSourceGraphqlApi",
               "New-ASYNApi",
               "New-ASYNApiCache",
               "New-ASYNApiKey",
               "New-ASYNChannelNamespace",
               "New-ASYNDataSource",
               "New-ASYNDomainName",
               "New-ASYNFunction",
               "New-ASYNGraphqlApi",
               "New-ASYNResolver",
               "New-ASYNType",
               "Remove-ASYNApi",
               "Remove-ASYNApiCache",
               "Remove-ASYNApiKey",
               "Remove-ASYNChannelNamespace",
               "Remove-ASYNDataSource",
               "Remove-ASYNDomainName",
               "Remove-ASYNFunction",
               "Remove-ASYNGraphqlApi",
               "Remove-ASYNResolver",
               "Remove-ASYNType",
               "Stop-ASYNApiAssociation",
               "Stop-ASYNMergedGraphqlApi",
               "Stop-ASYNSourceGraphqlApi",
               "Test-ASYNCode",
               "Test-ASYNMappingTemplate",
               "Clear-ASYNApiCache",
               "Get-ASYNApi",
               "Get-ASYNApiAssociation",
               "Get-ASYNApiCache",
               "Get-ASYNChannelNamespace",
               "Get-ASYNDataSource",
               "Get-ASYNDataSourceIntrospection",
               "Get-ASYNDomainName",
               "Get-ASYNFunction",
               "Get-ASYNGraphqlApi",
               "Get-ASYNGraphqlApiEnvironmentVariable",
               "Get-ASYNIntrospectionSchema",
               "Get-ASYNResolver",
               "Get-ASYNSchemaCreationStatus",
               "Get-ASYNSourceApiAssociation",
               "Get-ASYNType",
               "Get-ASYNApiKeyList",
               "Get-ASYNApiList",
               "Get-ASYNChannelNamespaceList",
               "Get-ASYNDataSourceList",
               "Get-ASYNDomainNameList",
               "Get-ASYNFunctionList",
               "Get-ASYNGraphqlApiList",
               "Get-ASYNResolverList",
               "Get-ASYNResolverListByFunction",
               "Get-ASYNSourceApiAssociationList",
               "Get-ASYNResourceTag",
               "Get-ASYNTypeList",
               "Get-ASYNTypesByAssociationList",
               "Write-ASYNGraphqlApiEnvironmentVariable",
               "Start-ASYNDataSourceIntrospection",
               "Start-ASYNSchemaCreation",
               "Start-ASYNSchemaMerge",
               "Add-ASYNResourceTag",
               "Remove-ASYNResourceTag",
               "Update-ASYNApi",
               "Update-ASYNApiCache",
               "Update-ASYNApiKey",
               "Update-ASYNChannelNamespace",
               "Update-ASYNDataSource",
               "Update-ASYNDomainName",
               "Update-ASYNFunction",
               "Update-ASYNGraphqlApi",
               "Update-ASYNResolver",
               "Update-ASYNSourceApiAssociation",
               "Update-ASYNType")
}

_awsArgumentCompleterRegistration $ASYN_SelectCompleters $ASYN_SelectMap

