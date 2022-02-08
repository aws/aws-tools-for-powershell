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

# Argument completions for service Amazon Comprehend


$COMP_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Comprehend.DocumentClassifierDataFormat
        "New-COMPDocumentClassifier/InputDataConfig_DataFormat"
        {
            $v = "AUGMENTED_MANIFEST","COMPREHEND_CSV"
            break
        }

        # Amazon.Comprehend.DocumentClassifierMode
        "New-COMPDocumentClassifier/Mode"
        {
            $v = "MULTI_CLASS","MULTI_LABEL"
            break
        }

        # Amazon.Comprehend.EndpointStatus
        "Get-COMPEndpointList/Filter_Status"
        {
            $v = "CREATING","DELETING","FAILED","IN_SERVICE","UPDATING"
            break
        }

        # Amazon.Comprehend.EntityRecognizerDataFormat
        "New-COMPEntityRecognizer/InputDataConfig_DataFormat"
        {
            $v = "AUGMENTED_MANIFEST","COMPREHEND_CSV"
            break
        }

        # Amazon.Comprehend.InputFormat
        "New-COMPEntityRecognizer/InputDataConfig_Documents_InputFormat"
        {
            $v = "ONE_DOC_PER_FILE","ONE_DOC_PER_LINE"
            break
        }

        # Amazon.Comprehend.JobStatus
        {
            ($_ -eq "Get-COMPDocumentClassificationJobList/Filter_JobStatus") -Or
            ($_ -eq "Get-COMPEventsDetectionJobList/Filter_JobStatus")
        }
        {
            $v = "COMPLETED","FAILED","IN_PROGRESS","STOPPED","STOP_REQUESTED","SUBMITTED"
            break
        }

        # Amazon.Comprehend.LanguageCode
        {
            ($_ -eq "Find-COMPEntity/LanguageCode") -Or
            ($_ -eq "Find-COMPEntityBatch/LanguageCode") -Or
            ($_ -eq "Find-COMPKeyPhrase/LanguageCode") -Or
            ($_ -eq "Find-COMPKeyPhrasesBatch/LanguageCode") -Or
            ($_ -eq "Find-COMPPiiEntity/LanguageCode") -Or
            ($_ -eq "Find-COMPPiiEntityType/LanguageCode") -Or
            ($_ -eq "Find-COMPSentiment/LanguageCode") -Or
            ($_ -eq "Find-COMPSentimentBatch/LanguageCode") -Or
            ($_ -eq "New-COMPDocumentClassifier/LanguageCode") -Or
            ($_ -eq "New-COMPEntityRecognizer/LanguageCode") -Or
            ($_ -eq "Start-COMPEntitiesDetectionJob/LanguageCode") -Or
            ($_ -eq "Start-COMPEventsDetectionJob/LanguageCode") -Or
            ($_ -eq "Start-COMPKeyPhrasesDetectionJob/LanguageCode") -Or
            ($_ -eq "Start-COMPPiiEntitiesDetectionJob/LanguageCode") -Or
            ($_ -eq "Start-COMPSentimentDetectionJob/LanguageCode")
        }
        {
            $v = "ar","de","en","es","fr","hi","it","ja","ko","pt","zh","zh-TW"
            break
        }

        # Amazon.Comprehend.ModelStatus
        {
            ($_ -eq "Get-COMPDocumentClassifierList/Filter_Status") -Or
            ($_ -eq "Get-COMPEntityRecognizerList/Filter_Status")
        }
        {
            $v = "DELETING","IN_ERROR","STOPPED","STOP_REQUESTED","SUBMITTED","TRAINED","TRAINING"
            break
        }

        # Amazon.Comprehend.PiiEntitiesDetectionMaskMode
        "Start-COMPPiiEntitiesDetectionJob/RedactionConfig_MaskMode"
        {
            $v = "MASK","REPLACE_WITH_PII_ENTITY_TYPE"
            break
        }

        # Amazon.Comprehend.PiiEntitiesDetectionMode
        "Start-COMPPiiEntitiesDetectionJob/Mode"
        {
            $v = "ONLY_OFFSETS","ONLY_REDACTION"
            break
        }

        # Amazon.Comprehend.SyntaxLanguageCode
        {
            ($_ -eq "Find-COMPSyntax/LanguageCode") -Or
            ($_ -eq "Find-COMPSyntaxBatch/LanguageCode")
        }
        {
            $v = "de","en","es","fr","it","pt"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$COMP_map = @{
    "Filter_JobStatus"=@("Get-COMPDocumentClassificationJobList","Get-COMPEventsDetectionJobList")
    "Filter_Status"=@("Get-COMPDocumentClassifierList","Get-COMPEndpointList","Get-COMPEntityRecognizerList")
    "InputDataConfig_DataFormat"=@("New-COMPDocumentClassifier","New-COMPEntityRecognizer")
    "InputDataConfig_Documents_InputFormat"=@("New-COMPEntityRecognizer")
    "LanguageCode"=@("Find-COMPEntity","Find-COMPEntityBatch","Find-COMPKeyPhrase","Find-COMPKeyPhrasesBatch","Find-COMPPiiEntity","Find-COMPPiiEntityType","Find-COMPSentiment","Find-COMPSentimentBatch","Find-COMPSyntax","Find-COMPSyntaxBatch","New-COMPDocumentClassifier","New-COMPEntityRecognizer","Start-COMPEntitiesDetectionJob","Start-COMPEventsDetectionJob","Start-COMPKeyPhrasesDetectionJob","Start-COMPPiiEntitiesDetectionJob","Start-COMPSentimentDetectionJob")
    "Mode"=@("New-COMPDocumentClassifier","Start-COMPPiiEntitiesDetectionJob")
    "RedactionConfig_MaskMode"=@("Start-COMPPiiEntitiesDetectionJob")
}

_awsArgumentCompleterRegistration $COMP_Completers $COMP_map

$COMP_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.COMP.$($commandName.Replace('-', ''))Cmdlet]"
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

$COMP_SelectMap = @{
    "Select"=@("Find-COMPDominantLanguageBatch",
               "Find-COMPEntityBatch",
               "Find-COMPKeyPhrasesBatch",
               "Find-COMPSentimentBatch",
               "Find-COMPSyntaxBatch",
               "Invoke-COMPDocumentClassification",
               "Find-COMPPiiEntityType",
               "New-COMPDocumentClassifier",
               "New-COMPEndpoint",
               "New-COMPEntityRecognizer",
               "Remove-COMPDocumentClassifier",
               "Remove-COMPEndpoint",
               "Remove-COMPEntityRecognizer",
               "Remove-COMPResourcePolicy",
               "Get-COMPDocumentClassificationJob",
               "Get-COMPDocumentClassifier",
               "Get-COMPDominantLanguageDetectionJob",
               "Get-COMPEndpoint",
               "Get-COMPEntitiesDetectionJob",
               "Get-COMPEntityRecognizer",
               "Get-COMPEventsDetectionJob",
               "Get-COMPKeyPhrasesDetectionJob",
               "Get-COMPPiiEntitiesDetectionJob",
               "Get-COMPResourcePolicy",
               "Get-COMPSentimentDetectionJob",
               "Get-COMPTopicsDetectionJob",
               "Find-COMPDominantLanguage",
               "Find-COMPEntity",
               "Find-COMPKeyPhrase",
               "Find-COMPPiiEntity",
               "Find-COMPSentiment",
               "Find-COMPSyntax",
               "Import-COMPModel",
               "Get-COMPDocumentClassificationJobList",
               "Get-COMPDocumentClassifierList",
               "Get-COMPDocumentClassifierSummaryList",
               "Get-COMPDominantLanguageDetectionJobList",
               "Get-COMPEndpointList",
               "Get-COMPEntitiesDetectionJobList",
               "Get-COMPEntityRecognizerList",
               "Get-COMPEntityRecognizerSummaryList",
               "Get-COMPEventsDetectionJobList",
               "Get-COMPKeyPhrasesDetectionJobList",
               "Get-COMPPiiEntitiesDetectionJobList",
               "Get-COMPSentimentDetectionJobList",
               "Get-COMPResourceTag",
               "Get-COMPTopicsDetectionJobList",
               "Write-COMPResourcePolicy",
               "Start-COMPDocumentClassificationJob",
               "Start-COMPDominantLanguageDetectionJob",
               "Start-COMPEntitiesDetectionJob",
               "Start-COMPEventsDetectionJob",
               "Start-COMPKeyPhrasesDetectionJob",
               "Start-COMPPiiEntitiesDetectionJob",
               "Start-COMPSentimentDetectionJob",
               "Start-COMPTopicsDetectionJob",
               "Stop-COMPDominantLanguageDetectionJob",
               "Stop-COMPEntitiesDetectionJob",
               "Stop-COMPEventsDetectionJob",
               "Stop-COMPKeyPhrasesDetectionJob",
               "Stop-COMPPiiEntitiesDetectionJob",
               "Stop-COMPSentimentDetectionJob",
               "Stop-COMPTrainingDocumentClassifier",
               "Stop-COMPTrainingEntityRecognizer",
               "Add-COMPResourceTag",
               "Remove-COMPResourceTag",
               "Update-COMPEndpoint")
}

_awsArgumentCompleterRegistration $COMP_SelectCompleters $COMP_SelectMap

