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
        # Amazon.TranscribeService.LanguageCode
        {
            ($_ -eq "New-TRSVocabulary/LanguageCode") -Or
            ($_ -eq "New-TRSVocabularyFilter/LanguageCode") -Or
            ($_ -eq "Start-TRSTranscriptionJob/LanguageCode") -Or
            ($_ -eq "Update-TRSVocabulary/LanguageCode")
        }
        {
            $v = "ar-AE","ar-SA","de-CH","de-DE","en-AB","en-AU","en-GB","en-IE","en-IN","en-US","en-WL","es-ES","es-US","fa-IR","fr-CA","fr-FR","he-IL","hi-IN","id-ID","it-IT","ja-JP","ko-KR","ms-MY","nl-NL","pt-BR","pt-PT","ru-RU","ta-IN","te-IN","tr-TR","zh-CN"
            break
        }

        # Amazon.TranscribeService.MediaFormat
        "Start-TRSTranscriptionJob/MediaFormat"
        {
            $v = "flac","mp3","mp4","wav"
            break
        }

        # Amazon.TranscribeService.TranscriptionJobStatus
        "Get-TRSTranscriptionJobList/Status"
        {
            $v = "COMPLETED","FAILED","IN_PROGRESS","QUEUED"
            break
        }

        # Amazon.TranscribeService.VocabularyFilterMethod
        "Start-TRSTranscriptionJob/Settings_VocabularyFilterMethod"
        {
            $v = "mask","remove"
            break
        }

        # Amazon.TranscribeService.VocabularyState
        "Get-TRSVocabularyList/StateEquals"
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
    "LanguageCode"=@("New-TRSVocabulary","New-TRSVocabularyFilter","Start-TRSTranscriptionJob","Update-TRSVocabulary")
    "MediaFormat"=@("Start-TRSTranscriptionJob")
    "Settings_VocabularyFilterMethod"=@("Start-TRSTranscriptionJob")
    "StateEquals"=@("Get-TRSVocabularyList")
    "Status"=@("Get-TRSTranscriptionJobList")
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
    "Select"=@("New-TRSVocabulary",
               "New-TRSVocabularyFilter",
               "Remove-TRSTranscriptionJob",
               "Remove-TRSVocabulary",
               "Remove-TRSVocabularyFilter",
               "Get-TRSTranscriptionJob",
               "Get-TRSVocabulary",
               "Get-TRSVocabularyFilter",
               "Get-TRSTranscriptionJobList",
               "Get-TRSVocabularyList",
               "Get-TRSVocabularyFilterList",
               "Start-TRSTranscriptionJob",
               "Update-TRSVocabulary",
               "Update-TRSVocabularyFilter")
}

_awsArgumentCompleterRegistration $TRS_SelectCompleters $TRS_SelectMap

