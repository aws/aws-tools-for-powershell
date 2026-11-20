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

# Argument completions for service Amazon Textract


$TXT_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Textract.AutoUpdate
        {
            ($_ -eq "New-TXTAdapter/AutoUpdate") -Or
            ($_ -eq "Update-TXTAdapter/AutoUpdate")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.Textract.PIIRedactionMaskMode
        {
            ($_ -eq "New-TXTProject/SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode") -Or
            ($_ -eq "Update-TXTProject/SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode")
        }
        {
            $v = "ENTITY_TYPE","PII"
            break
        }

        # Amazon.Textract.ResourceOwner
        "Get-TXTBlueprintList/ResourceOwner"
        {
            $v = "ACCOUNT","SERVICE"
            break
        }

        # Amazon.Textract.SensitiveDataDetectionMode
        {
            ($_ -eq "New-TXTProject/SensitiveDataConfiguration_DetectionMode") -Or
            ($_ -eq "Update-TXTProject/SensitiveDataConfiguration_DetectionMode")
        }
        {
            $v = "DETECTION","DETECTION_AND_REDACTION","DISABLED"
            break
        }

        # Amazon.Textract.State
        {
            ($_ -eq "New-TXTProject/ExtractionConfiguration_BoundingBox_State") -Or
            ($_ -eq "Update-TXTProject/ExtractionConfiguration_BoundingBox_State") -Or
            ($_ -eq "New-TXTProject/ExtractionConfiguration_OutputFormat_AdditionalFileFormat_State") -Or
            ($_ -eq "Update-TXTProject/ExtractionConfiguration_OutputFormat_AdditionalFileFormat_State") -Or
            ($_ -eq "New-TXTProject/GenerativeConfiguration_FigureCaption_State") -Or
            ($_ -eq "Update-TXTProject/GenerativeConfiguration_FigureCaption_State") -Or
            ($_ -eq "New-TXTProject/GenerativeConfiguration_Summarization_State") -Or
            ($_ -eq "Update-TXTProject/GenerativeConfiguration_Summarization_State") -Or
            ($_ -eq "Start-TXTDocumentInsight/NotificationConfiguration_EventBridgeConfiguration_State") -Or
            ($_ -eq "New-TXTProject/SplitterConfiguration_State") -Or
            ($_ -eq "Update-TXTProject/SplitterConfiguration_State")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$TXT_map = @{
    "AutoUpdate"=@("New-TXTAdapter","Update-TXTAdapter")
    "ExtractionConfiguration_BoundingBox_State"=@("New-TXTProject","Update-TXTProject")
    "ExtractionConfiguration_OutputFormat_AdditionalFileFormat_State"=@("New-TXTProject","Update-TXTProject")
    "GenerativeConfiguration_FigureCaption_State"=@("New-TXTProject","Update-TXTProject")
    "GenerativeConfiguration_Summarization_State"=@("New-TXTProject","Update-TXTProject")
    "NotificationConfiguration_EventBridgeConfiguration_State"=@("Start-TXTDocumentInsight")
    "ResourceOwner"=@("Get-TXTBlueprintList")
    "SensitiveDataConfiguration_DetectionMode"=@("New-TXTProject","Update-TXTProject")
    "SensitiveDataConfiguration_PiiEntitiesConfiguration_RedactionMaskMode"=@("New-TXTProject","Update-TXTProject")
    "SplitterConfiguration_State"=@("New-TXTProject","Update-TXTProject")
}

_awsArgumentCompleterRegistration $TXT_Completers $TXT_map

$TXT_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.TXT.$($commandName.Replace('-', ''))Cmdlet]"
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

$TXT_SelectMap = @{
    "Select"=@("Invoke-TXTDocumentAnalysis",
               "Invoke-TXTExpenseAnalysis",
               "Invoke-TXTAnalyzeID",
               "New-TXTAdapter",
               "New-TXTAdapterVersion",
               "New-TXTBlueprint",
               "New-TXTBlueprintVersion",
               "New-TXTProject",
               "Remove-TXTAdapter",
               "Remove-TXTAdapterVersion",
               "Remove-TXTBlueprint",
               "Remove-TXTProject",
               "Find-TXTDocumentText",
               "Get-TXTAdapter",
               "Get-TXTAdapterVersion",
               "Get-TXTBlueprint",
               "Get-TXTDocumentAnalysis",
               "Get-TXTDocumentInsight",
               "Get-TXTDocumentTextDetection",
               "Get-TXTExpenseAnalysis",
               "Get-TXTLendingAnalysis",
               "Get-TXTLendingAnalysisSummary",
               "Get-TXTProject",
               "Get-TXTAdapterList",
               "Get-TXTAdapterVersionList",
               "Get-TXTBlueprintList",
               "Get-TXTProjectList",
               "Get-TXTResourceTag",
               "Start-TXTDocumentAnalysis",
               "Start-TXTDocumentInsight",
               "Start-TXTDocumentTextDetection",
               "Start-TXTExpenseAnalysis",
               "Start-TXTLendingAnalysis",
               "Add-TXTResourceTag",
               "Remove-TXTResourceTag",
               "Update-TXTAdapter",
               "Update-TXTBlueprint",
               "Update-TXTProject")
}

_awsArgumentCompleterRegistration $TXT_SelectCompleters $TXT_SelectMap

