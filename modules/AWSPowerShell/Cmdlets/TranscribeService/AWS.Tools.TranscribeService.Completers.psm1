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

# Argument completions for service Amazon Transcribe Service


$TRS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.TranscribeService.BaseModelName
        "New-TRSLanguageModel/BaseModelName"
        {
            $v = "NarrowBand","WideBand"
            break
        }

        # Amazon.TranscribeService.CallAnalyticsJobStatus
        "Get-TRSCallAnalyticsJobList/Status"
        {
            $v = "COMPLETED","FAILED","IN_PROGRESS","QUEUED"
            break
        }

        # Amazon.TranscribeService.CLMLanguageCode
        "New-TRSLanguageModel/LanguageCode"
        {
            $v = "de-DE","en-AU","en-GB","en-US","es-US","hi-IN","ja-JP"
            break
        }

        # Amazon.TranscribeService.InputType
        {
            ($_ -eq "New-TRSCallAnalyticsCategory/InputType") -Or
            ($_ -eq "Update-TRSCallAnalyticsCategory/InputType")
        }
        {
            $v = "POST_CALL","REAL_TIME"
            break
        }

        # Amazon.TranscribeService.LanguageCode
        {
            ($_ -eq "New-TRSMedicalVocabulary/LanguageCode") -Or
            ($_ -eq "New-TRSVocabulary/LanguageCode") -Or
            ($_ -eq "New-TRSVocabularyFilter/LanguageCode") -Or
            ($_ -eq "Start-TRSMedicalTranscriptionJob/LanguageCode") -Or
            ($_ -eq "Start-TRSTranscriptionJob/LanguageCode") -Or
            ($_ -eq "Update-TRSMedicalVocabulary/LanguageCode") -Or
            ($_ -eq "Update-TRSVocabulary/LanguageCode")
        }
        {
            $v = "af-ZA","ar-AE","ar-SA","da-DK","de-CH","de-DE","en-AB","en-AU","en-GB","en-IE","en-IN","en-NZ","en-US","en-WL","en-ZA","es-ES","es-US","fa-IR","fr-CA","fr-FR","he-IL","hi-IN","id-ID","it-IT","ja-JP","ko-KR","ms-MY","nl-NL","pt-BR","pt-PT","ru-RU","sv-SE","ta-IN","te-IN","th-TH","tr-TR","vi-VN","zh-CN","zh-TW"
            break
        }

        # Amazon.TranscribeService.MediaFormat
        {
            ($_ -eq "Start-TRSMedicalTranscriptionJob/MediaFormat") -Or
            ($_ -eq "Start-TRSTranscriptionJob/MediaFormat")
        }
        {
            $v = "amr","flac","mp3","mp4","ogg","wav","webm"
            break
        }

        # Amazon.TranscribeService.MedicalContentIdentificationType
        "Start-TRSMedicalTranscriptionJob/ContentIdentificationType"
        {
            $v = "PHI"
            break
        }

        # Amazon.TranscribeService.ModelStatus
        "Get-TRSLanguageModelList/StatusEquals"
        {
            $v = "COMPLETED","FAILED","IN_PROGRESS"
            break
        }

        # Amazon.TranscribeService.RedactionOutput
        {
            ($_ -eq "Start-TRSTranscriptionJob/ContentRedaction_RedactionOutput") -Or
            ($_ -eq "Start-TRSCallAnalyticsJob/Settings_ContentRedaction_RedactionOutput")
        }
        {
            $v = "redacted","redacted_and_unredacted"
            break
        }

        # Amazon.TranscribeService.RedactionType
        {
            ($_ -eq "Start-TRSTranscriptionJob/ContentRedaction_RedactionType") -Or
            ($_ -eq "Start-TRSCallAnalyticsJob/Settings_ContentRedaction_RedactionType")
        }
        {
            $v = "PII"
            break
        }

        # Amazon.TranscribeService.Specialty
        "Start-TRSMedicalTranscriptionJob/Specialty"
        {
            $v = "PRIMARYCARE"
            break
        }

        # Amazon.TranscribeService.TranscriptionJobStatus
        {
            ($_ -eq "Get-TRSMedicalTranscriptionJobList/Status") -Or
            ($_ -eq "Get-TRSTranscriptionJobList/Status")
        }
        {
            $v = "COMPLETED","FAILED","IN_PROGRESS","QUEUED"
            break
        }

        # Amazon.TranscribeService.Type
        "Start-TRSMedicalTranscriptionJob/Type"
        {
            $v = "CONVERSATION","DICTATION"
            break
        }

        # Amazon.TranscribeService.VocabularyFilterMethod
        {
            ($_ -eq "Start-TRSCallAnalyticsJob/Settings_VocabularyFilterMethod") -Or
            ($_ -eq "Start-TRSTranscriptionJob/Settings_VocabularyFilterMethod")
        }
        {
            $v = "mask","remove","tag"
            break
        }

        # Amazon.TranscribeService.VocabularyState
        {
            ($_ -eq "Get-TRSMedicalVocabularyList/StateEquals") -Or
            ($_ -eq "Get-TRSVocabularyList/StateEquals")
        }
        {
            $v = "FAILED","PENDING","READY"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$TRS_map = @{
    "BaseModelName"=@("New-TRSLanguageModel")
    "ContentIdentificationType"=@("Start-TRSMedicalTranscriptionJob")
    "ContentRedaction_RedactionOutput"=@("Start-TRSTranscriptionJob")
    "ContentRedaction_RedactionType"=@("Start-TRSTranscriptionJob")
    "InputType"=@("New-TRSCallAnalyticsCategory","Update-TRSCallAnalyticsCategory")
    "LanguageCode"=@("New-TRSLanguageModel","New-TRSMedicalVocabulary","New-TRSVocabulary","New-TRSVocabularyFilter","Start-TRSMedicalTranscriptionJob","Start-TRSTranscriptionJob","Update-TRSMedicalVocabulary","Update-TRSVocabulary")
    "MediaFormat"=@("Start-TRSMedicalTranscriptionJob","Start-TRSTranscriptionJob")
    "Settings_ContentRedaction_RedactionOutput"=@("Start-TRSCallAnalyticsJob")
    "Settings_ContentRedaction_RedactionType"=@("Start-TRSCallAnalyticsJob")
    "Settings_VocabularyFilterMethod"=@("Start-TRSCallAnalyticsJob","Start-TRSTranscriptionJob")
    "Specialty"=@("Start-TRSMedicalTranscriptionJob")
    "StateEquals"=@("Get-TRSMedicalVocabularyList","Get-TRSVocabularyList")
    "Status"=@("Get-TRSCallAnalyticsJobList","Get-TRSMedicalTranscriptionJobList","Get-TRSTranscriptionJobList")
    "StatusEquals"=@("Get-TRSLanguageModelList")
    "Type"=@("Start-TRSMedicalTranscriptionJob")
}

_awsArgumentCompleterRegistration $TRS_Completers $TRS_map

$TRS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.TRS.$($commandName.Replace('-', ''))Cmdlet]"
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

$TRS_SelectMap = @{
    "Select"=@("New-TRSCallAnalyticsCategory",
               "New-TRSLanguageModel",
               "New-TRSMedicalVocabulary",
               "New-TRSVocabulary",
               "New-TRSVocabularyFilter",
               "Remove-TRSCallAnalyticsCategory",
               "Remove-TRSCallAnalyticsJob",
               "Remove-TRSLanguageModel",
               "Remove-TRSMedicalTranscriptionJob",
               "Remove-TRSMedicalVocabulary",
               "Remove-TRSTranscriptionJob",
               "Remove-TRSVocabulary",
               "Remove-TRSVocabularyFilter",
               "Get-TRSLanguageModel",
               "Get-TRSCallAnalyticsCategory",
               "Get-TRSCallAnalyticsJob",
               "Get-TRSMedicalTranscriptionJob",
               "Get-TRSMedicalVocabulary",
               "Get-TRSTranscriptionJob",
               "Get-TRSVocabulary",
               "Get-TRSVocabularyFilter",
               "Get-TRSCallAnalyticsCategoryList",
               "Get-TRSCallAnalyticsJobList",
               "Get-TRSLanguageModelList",
               "Get-TRSMedicalTranscriptionJobList",
               "Get-TRSMedicalVocabularyList",
               "Get-TRSResourceTag",
               "Get-TRSTranscriptionJobList",
               "Get-TRSVocabularyList",
               "Get-TRSVocabularyFilterList",
               "Start-TRSCallAnalyticsJob",
               "Start-TRSMedicalTranscriptionJob",
               "Start-TRSTranscriptionJob",
               "Add-TRSResourceTag",
               "Remove-TRSResourceTag",
               "Update-TRSCallAnalyticsCategory",
               "Update-TRSMedicalVocabulary",
               "Update-TRSVocabulary",
               "Update-TRSVocabularyFilter")
}

_awsArgumentCompleterRegistration $TRS_SelectCompleters $TRS_SelectMap

