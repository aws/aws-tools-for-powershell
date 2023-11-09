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
        # Amazon.Comprehend.DatasetDataFormat
        "New-COMPDataset/InputDataConfig_DataFormat"
        {
            $v = "AUGMENTED_MANIFEST","COMPREHEND_CSV"
            break
        }

        # Amazon.Comprehend.DatasetStatus
        "Get-COMPDatasetList/Filter_Status"
        {
            $v = "COMPLETED","CREATING","FAILED"
            break
        }

        # Amazon.Comprehend.DatasetType
        {
            ($_ -eq "New-COMPDataset/DatasetType") -Or
            ($_ -eq "Get-COMPDatasetList/Filter_DatasetType")
        }
        {
            $v = "TEST","TRAIN"
            break
        }

        # Amazon.Comprehend.DocumentClassifierDataFormat
        "New-COMPDocumentClassifier/InputDataConfig_DataFormat"
        {
            $v = "AUGMENTED_MANIFEST","COMPREHEND_CSV"
            break
        }

        # Amazon.Comprehend.DocumentClassifierDocumentTypeFormat
        "New-COMPDocumentClassifier/InputDataConfig_DocumentType"
        {
            $v = "PLAIN_TEXT_DOCUMENT","SEMI_STRUCTURED_DOCUMENT"
            break
        }

        # Amazon.Comprehend.DocumentClassifierMode
        {
            ($_ -eq "New-COMPDocumentClassifier/Mode") -Or
            ($_ -eq "New-COMPFlywheel/TaskConfig_DocumentClassificationConfig_Mode")
        }
        {
            $v = "MULTI_CLASS","MULTI_LABEL"
            break
        }

        # Amazon.Comprehend.DocumentReadAction
        {
            ($_ -eq "Find-COMPEntity/DocumentReaderConfig_DocumentReadAction") -Or
            ($_ -eq "Invoke-COMPDocumentClassification/DocumentReaderConfig_DocumentReadAction") -Or
            ($_ -eq "New-COMPDocumentClassifier/InputDataConfig_DocumentReaderConfig_DocumentReadAction")
        }
        {
            $v = "TEXTRACT_ANALYZE_DOCUMENT","TEXTRACT_DETECT_DOCUMENT_TEXT"
            break
        }

        # Amazon.Comprehend.DocumentReadMode
        {
            ($_ -eq "Find-COMPEntity/DocumentReaderConfig_DocumentReadMode") -Or
            ($_ -eq "Invoke-COMPDocumentClassification/DocumentReaderConfig_DocumentReadMode") -Or
            ($_ -eq "New-COMPDocumentClassifier/InputDataConfig_DocumentReaderConfig_DocumentReadMode")
        }
        {
            $v = "FORCE_DOCUMENT_READ_ACTION","SERVICE_DEFAULT"
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

        # Amazon.Comprehend.FlywheelStatus
        "Get-COMPFlywheelList/Filter_Status"
        {
            $v = "ACTIVE","CREATING","DELETING","FAILED","UPDATING"
            break
        }

        # Amazon.Comprehend.InputFormat
        {
            ($_ -eq "New-COMPEntityRecognizer/InputDataConfig_Documents_InputFormat") -Or
            ($_ -eq "New-COMPDataset/InputDataConfig_EntityRecognizerInputDataConfig_Documents_InputFormat")
        }
        {
            $v = "ONE_DOC_PER_FILE","ONE_DOC_PER_LINE"
            break
        }

        # Amazon.Comprehend.JobStatus
        {
            ($_ -eq "Get-COMPDocumentClassificationJobList/Filter_JobStatus") -Or
            ($_ -eq "Get-COMPEventsDetectionJobList/Filter_JobStatus") -Or
            ($_ -eq "Get-COMPTargetedSentimentDetectionJobList/Filter_JobStatus")
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
            ($_ -eq "Find-COMPTargetedSentiment/LanguageCode") -Or
            ($_ -eq "Find-COMPTargetedSentimentBatch/LanguageCode") -Or
            ($_ -eq "Find-COMPToxicContent/LanguageCode") -Or
            ($_ -eq "New-COMPDocumentClassifier/LanguageCode") -Or
            ($_ -eq "New-COMPEntityRecognizer/LanguageCode") -Or
            ($_ -eq "Start-COMPEntitiesDetectionJob/LanguageCode") -Or
            ($_ -eq "Start-COMPEventsDetectionJob/LanguageCode") -Or
            ($_ -eq "Start-COMPKeyPhrasesDetectionJob/LanguageCode") -Or
            ($_ -eq "Start-COMPPiiEntitiesDetectionJob/LanguageCode") -Or
            ($_ -eq "Start-COMPSentimentDetectionJob/LanguageCode") -Or
            ($_ -eq "Start-COMPTargetedSentimentDetectionJob/LanguageCode") -Or
            ($_ -eq "New-COMPFlywheel/TaskConfig_LanguageCode")
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
            $v = "DELETING","IN_ERROR","STOPPED","STOP_REQUESTED","SUBMITTED","TRAINED","TRAINED_WITH_WARNING","TRAINING"
            break
        }

        # Amazon.Comprehend.ModelType
        "New-COMPFlywheel/ModelType"
        {
            $v = "DOCUMENT_CLASSIFIER","ENTITY_RECOGNIZER"
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
    "DatasetType"=@("New-COMPDataset")
    "DocumentReaderConfig_DocumentReadAction"=@("Find-COMPEntity","Invoke-COMPDocumentClassification")
    "DocumentReaderConfig_DocumentReadMode"=@("Find-COMPEntity","Invoke-COMPDocumentClassification")
    "Filter_DatasetType"=@("Get-COMPDatasetList")
    "Filter_JobStatus"=@("Get-COMPDocumentClassificationJobList","Get-COMPEventsDetectionJobList","Get-COMPTargetedSentimentDetectionJobList")
    "Filter_Status"=@("Get-COMPDatasetList","Get-COMPDocumentClassifierList","Get-COMPEndpointList","Get-COMPEntityRecognizerList","Get-COMPFlywheelList")
    "InputDataConfig_DataFormat"=@("New-COMPDataset","New-COMPDocumentClassifier","New-COMPEntityRecognizer")
    "InputDataConfig_DocumentReaderConfig_DocumentReadAction"=@("New-COMPDocumentClassifier")
    "InputDataConfig_DocumentReaderConfig_DocumentReadMode"=@("New-COMPDocumentClassifier")
    "InputDataConfig_Documents_InputFormat"=@("New-COMPEntityRecognizer")
    "InputDataConfig_DocumentType"=@("New-COMPDocumentClassifier")
    "InputDataConfig_EntityRecognizerInputDataConfig_Documents_InputFormat"=@("New-COMPDataset")
    "LanguageCode"=@("Find-COMPEntity","Find-COMPEntityBatch","Find-COMPKeyPhrase","Find-COMPKeyPhrasesBatch","Find-COMPPiiEntity","Find-COMPPiiEntityType","Find-COMPSentiment","Find-COMPSentimentBatch","Find-COMPSyntax","Find-COMPSyntaxBatch","Find-COMPTargetedSentiment","Find-COMPTargetedSentimentBatch","Find-COMPToxicContent","New-COMPDocumentClassifier","New-COMPEntityRecognizer","Start-COMPEntitiesDetectionJob","Start-COMPEventsDetectionJob","Start-COMPKeyPhrasesDetectionJob","Start-COMPPiiEntitiesDetectionJob","Start-COMPSentimentDetectionJob","Start-COMPTargetedSentimentDetectionJob")
    "Mode"=@("New-COMPDocumentClassifier","Start-COMPPiiEntitiesDetectionJob")
    "ModelType"=@("New-COMPFlywheel")
    "RedactionConfig_MaskMode"=@("Start-COMPPiiEntitiesDetectionJob")
    "TaskConfig_DocumentClassificationConfig_Mode"=@("New-COMPFlywheel")
    "TaskConfig_LanguageCode"=@("New-COMPFlywheel")
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
               "Find-COMPTargetedSentimentBatch",
               "Invoke-COMPDocumentClassification",
               "Find-COMPPiiEntityType",
               "New-COMPDataset",
               "New-COMPDocumentClassifier",
               "New-COMPEndpoint",
               "New-COMPEntityRecognizer",
               "New-COMPFlywheel",
               "Remove-COMPDocumentClassifier",
               "Remove-COMPEndpoint",
               "Remove-COMPEntityRecognizer",
               "Remove-COMPFlywheel",
               "Remove-COMPResourcePolicy",
               "Get-COMPDataset",
               "Get-COMPDocumentClassificationJob",
               "Get-COMPDocumentClassifier",
               "Get-COMPDominantLanguageDetectionJob",
               "Get-COMPEndpoint",
               "Get-COMPEntitiesDetectionJob",
               "Get-COMPEntityRecognizer",
               "Get-COMPEventsDetectionJob",
               "Get-COMPFlywheel",
               "Get-COMPFlywheelIteration",
               "Get-COMPKeyPhrasesDetectionJob",
               "Get-COMPPiiEntitiesDetectionJob",
               "Get-COMPResourcePolicy",
               "Get-COMPSentimentDetectionJob",
               "Get-COMPTargetedSentimentDetectionJob",
               "Get-COMPTopicsDetectionJob",
               "Find-COMPDominantLanguage",
               "Find-COMPEntity",
               "Find-COMPKeyPhrase",
               "Find-COMPPiiEntity",
               "Find-COMPSentiment",
               "Find-COMPSyntax",
               "Find-COMPTargetedSentiment",
               "Find-COMPToxicContent",
               "Import-COMPModel",
               "Get-COMPDatasetList",
               "Get-COMPDocumentClassificationJobList",
               "Get-COMPDocumentClassifierList",
               "Get-COMPDocumentClassifierSummaryList",
               "Get-COMPDominantLanguageDetectionJobList",
               "Get-COMPEndpointList",
               "Get-COMPEntitiesDetectionJobList",
               "Get-COMPEntityRecognizerList",
               "Get-COMPEntityRecognizerSummaryList",
               "Get-COMPEventsDetectionJobList",
               "Get-COMPFlywheelIterationHistoryList",
               "Get-COMPFlywheelList",
               "Get-COMPKeyPhrasesDetectionJobList",
               "Get-COMPPiiEntitiesDetectionJobList",
               "Get-COMPSentimentDetectionJobList",
               "Get-COMPResourceTag",
               "Get-COMPTargetedSentimentDetectionJobList",
               "Get-COMPTopicsDetectionJobList",
               "Write-COMPResourcePolicy",
               "Start-COMPDocumentClassificationJob",
               "Start-COMPDominantLanguageDetectionJob",
               "Start-COMPEntitiesDetectionJob",
               "Start-COMPEventsDetectionJob",
               "Start-COMPFlywheelIteration",
               "Start-COMPKeyPhrasesDetectionJob",
               "Start-COMPPiiEntitiesDetectionJob",
               "Start-COMPSentimentDetectionJob",
               "Start-COMPTargetedSentimentDetectionJob",
               "Start-COMPTopicsDetectionJob",
               "Stop-COMPDominantLanguageDetectionJob",
               "Stop-COMPEntitiesDetectionJob",
               "Stop-COMPEventsDetectionJob",
               "Stop-COMPKeyPhrasesDetectionJob",
               "Stop-COMPPiiEntitiesDetectionJob",
               "Stop-COMPSentimentDetectionJob",
               "Stop-COMPTargetedSentimentDetectionJob",
               "Stop-COMPTrainingDocumentClassifier",
               "Stop-COMPTrainingEntityRecognizer",
               "Add-COMPResourceTag",
               "Remove-COMPResourceTag",
               "Update-COMPEndpoint",
               "Update-COMPFlywheel")
}

_awsArgumentCompleterRegistration $COMP_SelectCompleters $COMP_SelectMap

