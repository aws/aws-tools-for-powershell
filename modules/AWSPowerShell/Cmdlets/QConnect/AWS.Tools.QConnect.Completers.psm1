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

# Argument completions for service Amazon Q Connect


$QC_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.QConnect.AssistantType
        "New-QCAssistant/Type"
        {
            $v = "AGENT"
            break
        }

        # Amazon.QConnect.AssociationType
        "New-QCAssistantAssociation/AssociationType"
        {
            $v = "KNOWLEDGE_BASE"
            break
        }

        # Amazon.QConnect.ExternalSource
        "Start-QCImportJob/ExternalSourceConfiguration_Source"
        {
            $v = "AMAZON_CONNECT"
            break
        }

        # Amazon.QConnect.ImportJobType
        "Start-QCImportJob/ImportJobType"
        {
            $v = "QUICK_RESPONSES"
            break
        }

        # Amazon.QConnect.KnowledgeBaseType
        "New-QCKnowledgeBase/KnowledgeBaseType"
        {
            $v = "CUSTOM","EXTERNAL","QUICK_RESPONSES"
            break
        }

        # Amazon.QConnect.Order
        "Search-QCQuickResponse/OrderOnField_Order"
        {
            $v = "ASC","DESC"
            break
        }

        # Amazon.QConnect.Relevance
        "Write-QCFeedback/GenerativeContentFeedbackData_Relevance"
        {
            $v = "HELPFUL","NOT_HELPFUL"
            break
        }

        # Amazon.QConnect.TargetType
        "Write-QCFeedback/TargetType"
        {
            $v = "RECOMMENDATION","RESULT"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$QC_map = @{
    "AssociationType"=@("New-QCAssistantAssociation")
    "ExternalSourceConfiguration_Source"=@("Start-QCImportJob")
    "GenerativeContentFeedbackData_Relevance"=@("Write-QCFeedback")
    "ImportJobType"=@("Start-QCImportJob")
    "KnowledgeBaseType"=@("New-QCKnowledgeBase")
    "OrderOnField_Order"=@("Search-QCQuickResponse")
    "TargetType"=@("Write-QCFeedback")
    "Type"=@("New-QCAssistant")
}

_awsArgumentCompleterRegistration $QC_Completers $QC_map

$QC_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.QC.$($commandName.Replace('-', ''))Cmdlet]"
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

$QC_SelectMap = @{
    "Select"=@("New-QCAssistant",
               "New-QCAssistantAssociation",
               "New-QCContent",
               "New-QCKnowledgeBase",
               "New-QCQuickResponse",
               "New-QCSession",
               "Remove-QCAssistant",
               "Remove-QCAssistantAssociation",
               "Remove-QCContent",
               "Remove-QCImportJob",
               "Remove-QCKnowledgeBase",
               "Remove-QCQuickResponse",
               "Get-QCAssistant",
               "Get-QCAssistantAssociation",
               "Get-QCContent",
               "Get-QCContentSummary",
               "Get-QCImportJob",
               "Get-QCKnowledgeBase",
               "Get-QCQuickResponse",
               "Get-QCRecommendation",
               "Get-QCSession",
               "Get-QCAssistantAssociationList",
               "Get-QCAssistantList",
               "Get-QCContentList",
               "Get-QCImportJobList",
               "Get-QCKnowledgeBasisList",
               "Get-QCQuickResponseList",
               "Get-QCResourceTag",
               "Remove-QCRecommendationsReceived",
               "Write-QCFeedback",
               "Search-QCAssistant",
               "Remove-QCKnowledgeBaseTemplateUri",
               "Search-QCContent",
               "Search-QCQuickResponse",
               "Search-QCSession",
               "Start-QCContentUpload",
               "Start-QCImportJob",
               "Add-QCResourceTag",
               "Remove-QCResourceTag",
               "Update-QCContent",
               "Update-QCKnowledgeBaseTemplateUri",
               "Update-QCQuickResponse")
}

_awsArgumentCompleterRegistration $QC_SelectCompleters $QC_SelectMap

