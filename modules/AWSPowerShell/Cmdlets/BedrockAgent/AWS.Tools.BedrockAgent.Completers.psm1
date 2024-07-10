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

# Argument completions for service Agents for Amazon Bedrock


$AAB_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.BedrockAgent.ActionGroupSignature
        {
            ($_ -eq "New-AABAgentActionGroup/ParentActionGroupSignature") -Or
            ($_ -eq "Update-AABAgentActionGroup/ParentActionGroupSignature")
        }
        {
            $v = "AMAZON.CodeInterpreter","AMAZON.UserInput"
            break
        }

        # Amazon.BedrockAgent.ActionGroupState
        {
            ($_ -eq "New-AABAgentActionGroup/ActionGroupState") -Or
            ($_ -eq "Update-AABAgentActionGroup/ActionGroupState")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.BedrockAgent.ChunkingStrategy
        {
            ($_ -eq "New-AABDataSource/ChunkingConfiguration_ChunkingStrategy") -Or
            ($_ -eq "Update-AABDataSource/ChunkingConfiguration_ChunkingStrategy")
        }
        {
            $v = "FIXED_SIZE","HIERARCHICAL","NONE","SEMANTIC"
            break
        }

        # Amazon.BedrockAgent.ConfluenceAuthType
        {
            ($_ -eq "New-AABDataSource/DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_AuthType") -Or
            ($_ -eq "Update-AABDataSource/DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_AuthType")
        }
        {
            $v = "BASIC","OAUTH2_CLIENT_CREDENTIALS"
            break
        }

        # Amazon.BedrockAgent.ConfluenceHostType
        {
            ($_ -eq "New-AABDataSource/DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostType") -Or
            ($_ -eq "Update-AABDataSource/DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostType")
        }
        {
            $v = "SAAS"
            break
        }

        # Amazon.BedrockAgent.CrawlFilterConfigurationType
        {
            ($_ -eq "New-AABDataSource/DataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_Type") -Or
            ($_ -eq "Update-AABDataSource/DataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_Type") -Or
            ($_ -eq "New-AABDataSource/DataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_Type") -Or
            ($_ -eq "Update-AABDataSource/DataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_Type") -Or
            ($_ -eq "New-AABDataSource/DataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_Type") -Or
            ($_ -eq "Update-AABDataSource/DataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_Type")
        }
        {
            $v = "PATTERN"
            break
        }

        # Amazon.BedrockAgent.CustomControlMethod
        {
            ($_ -eq "New-AABAgentActionGroup/ActionGroupExecutor_CustomControl") -Or
            ($_ -eq "Update-AABAgentActionGroup/ActionGroupExecutor_CustomControl")
        }
        {
            $v = "RETURN_CONTROL"
            break
        }

        # Amazon.BedrockAgent.DataDeletionPolicy
        {
            ($_ -eq "New-AABDataSource/DataDeletionPolicy") -Or
            ($_ -eq "Update-AABDataSource/DataDeletionPolicy")
        }
        {
            $v = "DELETE","RETAIN"
            break
        }

        # Amazon.BedrockAgent.DataSourceType
        {
            ($_ -eq "New-AABDataSource/DataSourceConfiguration_Type") -Or
            ($_ -eq "Update-AABDataSource/DataSourceConfiguration_Type")
        }
        {
            $v = "CONFLUENCE","S3","SALESFORCE","SHAREPOINT","WEB"
            break
        }

        # Amazon.BedrockAgent.IngestionJobSortByAttribute
        "Get-AABIngestionJobList/SortBy_Attribute"
        {
            $v = "STARTED_AT","STATUS"
            break
        }

        # Amazon.BedrockAgent.KnowledgeBaseState
        {
            ($_ -eq "Register-AABAgentKnowledgeBase/KnowledgeBaseState") -Or
            ($_ -eq "Update-AABAgentKnowledgeBase/KnowledgeBaseState")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.BedrockAgent.KnowledgeBaseStorageType
        {
            ($_ -eq "New-AABKnowledgeBase/StorageConfiguration_Type") -Or
            ($_ -eq "Update-AABKnowledgeBase/StorageConfiguration_Type")
        }
        {
            $v = "MONGO_DB_ATLAS","OPENSEARCH_SERVERLESS","PINECONE","RDS","REDIS_ENTERPRISE_CLOUD"
            break
        }

        # Amazon.BedrockAgent.KnowledgeBaseType
        {
            ($_ -eq "New-AABKnowledgeBase/KnowledgeBaseConfiguration_Type") -Or
            ($_ -eq "Update-AABKnowledgeBase/KnowledgeBaseConfiguration_Type")
        }
        {
            $v = "VECTOR"
            break
        }

        # Amazon.BedrockAgent.ParsingStrategy
        {
            ($_ -eq "New-AABDataSource/ParsingConfiguration_ParsingStrategy") -Or
            ($_ -eq "Update-AABDataSource/ParsingConfiguration_ParsingStrategy")
        }
        {
            $v = "BEDROCK_FOUNDATION_MODEL"
            break
        }

        # Amazon.BedrockAgent.SalesforceAuthType
        {
            ($_ -eq "New-AABDataSource/DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_AuthType") -Or
            ($_ -eq "Update-AABDataSource/DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_AuthType")
        }
        {
            $v = "OAUTH2_CLIENT_CREDENTIALS"
            break
        }

        # Amazon.BedrockAgent.SharePointAuthType
        {
            ($_ -eq "New-AABDataSource/DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_AuthType") -Or
            ($_ -eq "Update-AABDataSource/DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_AuthType")
        }
        {
            $v = "OAUTH2_CLIENT_CREDENTIALS"
            break
        }

        # Amazon.BedrockAgent.SharePointHostType
        {
            ($_ -eq "New-AABDataSource/DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_HostType") -Or
            ($_ -eq "Update-AABDataSource/DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_HostType")
        }
        {
            $v = "ONLINE"
            break
        }

        # Amazon.BedrockAgent.SortOrder
        "Get-AABIngestionJobList/SortBy_Order"
        {
            $v = "ASCENDING","DESCENDING"
            break
        }

        # Amazon.BedrockAgent.WebScopeType
        {
            ($_ -eq "New-AABDataSource/CrawlerConfiguration_Scope") -Or
            ($_ -eq "Update-AABDataSource/CrawlerConfiguration_Scope")
        }
        {
            $v = "HOST_ONLY","SUBDOMAINS"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$AAB_map = @{
    "ActionGroupExecutor_CustomControl"=@("New-AABAgentActionGroup","Update-AABAgentActionGroup")
    "ActionGroupState"=@("New-AABAgentActionGroup","Update-AABAgentActionGroup")
    "ChunkingConfiguration_ChunkingStrategy"=@("New-AABDataSource","Update-AABDataSource")
    "CrawlerConfiguration_Scope"=@("New-AABDataSource","Update-AABDataSource")
    "DataDeletionPolicy"=@("New-AABDataSource","Update-AABDataSource")
    "DataSourceConfiguration_ConfluenceConfiguration_CrawlerConfiguration_FilterConfiguration_Type"=@("New-AABDataSource","Update-AABDataSource")
    "DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_AuthType"=@("New-AABDataSource","Update-AABDataSource")
    "DataSourceConfiguration_ConfluenceConfiguration_SourceConfiguration_HostType"=@("New-AABDataSource","Update-AABDataSource")
    "DataSourceConfiguration_SalesforceConfiguration_CrawlerConfiguration_FilterConfiguration_Type"=@("New-AABDataSource","Update-AABDataSource")
    "DataSourceConfiguration_SalesforceConfiguration_SourceConfiguration_AuthType"=@("New-AABDataSource","Update-AABDataSource")
    "DataSourceConfiguration_SharePointConfiguration_CrawlerConfiguration_FilterConfiguration_Type"=@("New-AABDataSource","Update-AABDataSource")
    "DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_AuthType"=@("New-AABDataSource","Update-AABDataSource")
    "DataSourceConfiguration_SharePointConfiguration_SourceConfiguration_HostType"=@("New-AABDataSource","Update-AABDataSource")
    "DataSourceConfiguration_Type"=@("New-AABDataSource","Update-AABDataSource")
    "KnowledgeBaseConfiguration_Type"=@("New-AABKnowledgeBase","Update-AABKnowledgeBase")
    "KnowledgeBaseState"=@("Register-AABAgentKnowledgeBase","Update-AABAgentKnowledgeBase")
    "ParentActionGroupSignature"=@("New-AABAgentActionGroup","Update-AABAgentActionGroup")
    "ParsingConfiguration_ParsingStrategy"=@("New-AABDataSource","Update-AABDataSource")
    "SortBy_Attribute"=@("Get-AABIngestionJobList")
    "SortBy_Order"=@("Get-AABIngestionJobList")
    "StorageConfiguration_Type"=@("New-AABKnowledgeBase","Update-AABKnowledgeBase")
}

_awsArgumentCompleterRegistration $AAB_Completers $AAB_map

$AAB_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.AAB.$($commandName.Replace('-', ''))Cmdlet]"
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

$AAB_SelectMap = @{
    "Select"=@("Register-AABAgentKnowledgeBase",
               "New-AABAgent",
               "New-AABAgentActionGroup",
               "New-AABAgentAlias",
               "New-AABDataSource",
               "New-AABFlow",
               "New-AABFlowAlias",
               "New-AABFlowVersion",
               "New-AABKnowledgeBase",
               "New-AABPrompt",
               "New-AABPromptVersion",
               "Remove-AABAgent",
               "Remove-AABAgentActionGroup",
               "Remove-AABAgentAlias",
               "Remove-AABAgentVersion",
               "Remove-AABDataSource",
               "Remove-AABFlow",
               "Remove-AABFlowAlias",
               "Remove-AABFlowVersion",
               "Remove-AABKnowledgeBase",
               "Remove-AABPrompt",
               "Unregister-AABAgentKnowledgeBase",
               "Get-AABAgent",
               "Get-AABAgentActionGroup",
               "Get-AABAgentAlias",
               "Get-AABAgentKnowledgeBase",
               "Get-AABAgentVersion",
               "Get-AABDataSource",
               "Get-AABFlow",
               "Get-AABFlowAlias",
               "Get-AABFlowVersion",
               "Get-AABIngestionJob",
               "Get-AABKnowledgeBase",
               "Get-AABPrompt",
               "Get-AABAgentActionGroupList",
               "Get-AABAgentAliasList",
               "Get-AABAgentKnowledgeBasisList",
               "Get-AABAgentList",
               "Get-AABAgentVersionList",
               "Get-AABDataSourceList",
               "Get-AABFlowAliasList",
               "Get-AABFlowList",
               "Get-AABFlowVersionList",
               "Get-AABIngestionJobList",
               "Get-AABKnowledgeBasisList",
               "Get-AABPromptList",
               "Get-AABResourceTag",
               "Initialize-AABAgent",
               "Initialize-AABFlow",
               "Start-AABIngestionJob",
               "Add-AABResourceTag",
               "Remove-AABResourceTag",
               "Update-AABAgent",
               "Update-AABAgentActionGroup",
               "Update-AABAgentAlias",
               "Update-AABAgentKnowledgeBase",
               "Update-AABDataSource",
               "Update-AABFlow",
               "Update-AABFlowAlias",
               "Update-AABKnowledgeBase",
               "Update-AABPrompt")
}

_awsArgumentCompleterRegistration $AAB_SelectCompleters $AAB_SelectMap

