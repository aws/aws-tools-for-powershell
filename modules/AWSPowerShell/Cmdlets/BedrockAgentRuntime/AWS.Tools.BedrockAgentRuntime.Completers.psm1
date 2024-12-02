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

# Argument completions for service Amazon Bedrock Agent Runtime


$BAR_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.BedrockAgentRuntime.MemoryType
        "Get-BARAgentMemory/MemoryType"
        {
            $v = "SESSION_SUMMARY"
            break
        }

        # Amazon.BedrockAgentRuntime.QueryTransformationType
        {
            ($_ -eq "Invoke-BARRetrieveAndGenerate/QueryTransformationConfiguration_Type") -Or
            ($_ -eq "Invoke-BARRetrieveAndGenerateStream/QueryTransformationConfiguration_Type")
        }
        {
            $v = "QUERY_DECOMPOSITION"
            break
        }

        # Amazon.BedrockAgentRuntime.RerankingConfigurationType
        "Invoke-BARRerank/RerankingConfiguration_Type"
        {
            $v = "BEDROCK_RERANKING_MODEL"
            break
        }

        # Amazon.BedrockAgentRuntime.RerankingMetadataSelectionMode
        {
            ($_ -eq "Invoke-BARRetrieve/MetadataConfiguration_SelectionMode") -Or
            ($_ -eq "Invoke-BARRetrieveAndGenerate/MetadataConfiguration_SelectionMode") -Or
            ($_ -eq "Invoke-BARRetrieveAndGenerateStream/MetadataConfiguration_SelectionMode")
        }
        {
            $v = "ALL","SELECTIVE"
            break
        }

        # Amazon.BedrockAgentRuntime.RetrieveAndGenerateType
        {
            ($_ -eq "Invoke-BARRetrieveAndGenerate/RetrieveAndGenerateConfiguration_Type") -Or
            ($_ -eq "Invoke-BARRetrieveAndGenerateStream/RetrieveAndGenerateConfiguration_Type")
        }
        {
            $v = "EXTERNAL_SOURCES","KNOWLEDGE_BASE"
            break
        }

        # Amazon.BedrockAgentRuntime.SearchType
        {
            ($_ -eq "Invoke-BARRetrieve/VectorSearchConfiguration_OverrideSearchType") -Or
            ($_ -eq "Invoke-BARRetrieveAndGenerate/VectorSearchConfiguration_OverrideSearchType") -Or
            ($_ -eq "Invoke-BARRetrieveAndGenerateStream/VectorSearchConfiguration_OverrideSearchType")
        }
        {
            $v = "HYBRID","SEMANTIC"
            break
        }

        # Amazon.BedrockAgentRuntime.VectorSearchRerankingConfigurationType
        {
            ($_ -eq "Invoke-BARRetrieve/RerankingConfiguration_Type") -Or
            ($_ -eq "Invoke-BARRetrieveAndGenerate/RerankingConfiguration_Type") -Or
            ($_ -eq "Invoke-BARRetrieveAndGenerateStream/RerankingConfiguration_Type")
        }
        {
            $v = "BEDROCK_RERANKING_MODEL"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$BAR_map = @{
    "MemoryType"=@("Get-BARAgentMemory")
    "MetadataConfiguration_SelectionMode"=@("Invoke-BARRetrieve","Invoke-BARRetrieveAndGenerate","Invoke-BARRetrieveAndGenerateStream")
    "QueryTransformationConfiguration_Type"=@("Invoke-BARRetrieveAndGenerate","Invoke-BARRetrieveAndGenerateStream")
    "RerankingConfiguration_Type"=@("Invoke-BARRerank","Invoke-BARRetrieve","Invoke-BARRetrieveAndGenerate","Invoke-BARRetrieveAndGenerateStream")
    "RetrieveAndGenerateConfiguration_Type"=@("Invoke-BARRetrieveAndGenerate","Invoke-BARRetrieveAndGenerateStream")
    "VectorSearchConfiguration_OverrideSearchType"=@("Invoke-BARRetrieve","Invoke-BARRetrieveAndGenerate","Invoke-BARRetrieveAndGenerateStream")
}

_awsArgumentCompleterRegistration $BAR_Completers $BAR_map

$BAR_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.BAR.$($commandName.Replace('-', ''))Cmdlet]"
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

$BAR_SelectMap = @{
    "Select"=@("Remove-BARAgentMemory",
               "Get-BARAgentMemory",
               "Invoke-BARAgent",
               "Invoke-BARFlow",
               "Invoke-BARInlineAgent",
               "Get-BAROptimizePrompt",
               "Invoke-BARRerank",
               "Invoke-BARRetrieve",
               "Invoke-BARRetrieveAndGenerate",
               "Invoke-BARRetrieveAndGenerateStream")
}

_awsArgumentCompleterRegistration $BAR_SelectCompleters $BAR_SelectMap

