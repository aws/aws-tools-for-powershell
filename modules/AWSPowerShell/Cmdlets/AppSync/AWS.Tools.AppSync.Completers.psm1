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
            $v = "R4_2XLARGE","R4_4XLARGE","R4_8XLARGE","R4_LARGE","R4_XLARGE","T2_MEDIUM","T2_SMALL"
            break
        }

        # Amazon.AppSync.ApiCachingBehavior
        {
            ($_ -eq "New-ASYNApiCache/ApiCachingBehavior") -Or
            ($_ -eq "Update-ASYNApiCache/ApiCachingBehavior")
        }
        {
            $v = "FULL_REQUEST_CACHING","PER_RESOLVER_CACHING"
            break
        }

        # Amazon.AppSync.AuthenticationType
        {
            ($_ -eq "New-ASYNGraphqlApi/AuthenticationType") -Or
            ($_ -eq "Update-ASYNGraphqlApi/AuthenticationType")
        }
        {
            $v = "AMAZON_COGNITO_USER_POOLS","API_KEY","AWS_IAM","OPENID_CONNECT"
            break
        }

        # Amazon.AppSync.ConflictDetectionType
        {
            ($_ -eq "New-ASYNResolver/SyncConfig_ConflictDetection") -Or
            ($_ -eq "Update-ASYNResolver/SyncConfig_ConflictDetection")
        }
        {
            $v = "NONE","VERSION"
            break
        }

        # Amazon.AppSync.ConflictHandlerType
        {
            ($_ -eq "New-ASYNResolver/SyncConfig_ConflictHandler") -Or
            ($_ -eq "Update-ASYNResolver/SyncConfig_ConflictHandler")
        }
        {
            $v = "AUTOMERGE","LAMBDA","NONE","OPTIMISTIC_CONCURRENCY"
            break
        }

        # Amazon.AppSync.DataSourceType
        {
            ($_ -eq "New-ASYNDataSource/Type") -Or
            ($_ -eq "Update-ASYNDataSource/Type")
        }
        {
            $v = "AMAZON_DYNAMODB","AMAZON_ELASTICSEARCH","AWS_LAMBDA","HTTP","NONE","RELATIONAL_DATABASE"
            break
        }

        # Amazon.AppSync.FieldLogLevel
        {
            ($_ -eq "New-ASYNGraphqlApi/LogConfig_FieldLogLevel") -Or
            ($_ -eq "Update-ASYNGraphqlApi/LogConfig_FieldLogLevel")
        }
        {
            $v = "ALL","ERROR","NONE"
            break
        }

        # Amazon.AppSync.OutputType
        "Get-ASYNIntrospectionSchema/Format"
        {
            $v = "JSON","SDL"
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

        # Amazon.AppSync.TypeDefinitionFormat
        {
            ($_ -eq "Get-ASYNType/Format") -Or
            ($_ -eq "Get-ASYNTypeList/Format") -Or
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
    "AuthenticationType"=@("New-ASYNGraphqlApi","Update-ASYNGraphqlApi")
    "Format"=@("Get-ASYNIntrospectionSchema","Get-ASYNType","Get-ASYNTypeList","New-ASYNType","Update-ASYNType")
    "Kind"=@("New-ASYNResolver","Update-ASYNResolver")
    "LogConfig_FieldLogLevel"=@("New-ASYNGraphqlApi","Update-ASYNGraphqlApi")
    "RelationalDatabaseConfig_RelationalDatabaseSourceType"=@("New-ASYNDataSource","Update-ASYNDataSource")
    "SyncConfig_ConflictDetection"=@("New-ASYNResolver","Update-ASYNResolver")
    "SyncConfig_ConflictHandler"=@("New-ASYNResolver","Update-ASYNResolver")
    "Type"=@("New-ASYNApiCache","New-ASYNDataSource","Update-ASYNApiCache","Update-ASYNDataSource")
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
    "Select"=@("New-ASYNApiCache",
               "New-ASYNApiKey",
               "New-ASYNDataSource",
               "New-ASYNFunction",
               "New-ASYNGraphqlApi",
               "New-ASYNResolver",
               "New-ASYNType",
               "Remove-ASYNApiCache",
               "Remove-ASYNApiKey",
               "Remove-ASYNDataSource",
               "Remove-ASYNFunction",
               "Remove-ASYNGraphqlApi",
               "Remove-ASYNResolver",
               "Remove-ASYNType",
               "Clear-ASYNApiCache",
               "Get-ASYNApiCache",
               "Get-ASYNDataSource",
               "Get-ASYNFunction",
               "Get-ASYNGraphqlApi",
               "Get-ASYNIntrospectionSchema",
               "Get-ASYNResolver",
               "Get-ASYNSchemaCreationStatus",
               "Get-ASYNType",
               "Get-ASYNApiKeyList",
               "Get-ASYNDataSourceList",
               "Get-ASYNFunctionList",
               "Get-ASYNGraphqlApiList",
               "Get-ASYNResolverList",
               "Get-ASYNResolverListByFunction",
               "Get-ASYNResourceTag",
               "Get-ASYNTypeList",
               "Start-ASYNSchemaCreation",
               "Add-ASYNResourceTag",
               "Remove-ASYNResourceTag",
               "Update-ASYNApiCache",
               "Update-ASYNApiKey",
               "Update-ASYNDataSource",
               "Update-ASYNFunction",
               "Update-ASYNGraphqlApi",
               "Update-ASYNResolver",
               "Update-ASYNType")
}

_awsArgumentCompleterRegistration $ASYN_SelectCompleters $ASYN_SelectMap

