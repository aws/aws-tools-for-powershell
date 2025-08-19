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

# Argument completions for service Amazon Polly


$POL_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Polly.Engine
        {
            ($_ -eq "Get-POLSpeech/Engine") -Or
            ($_ -eq "Get-POLVoice/Engine") -Or
            ($_ -eq "Start-POLSpeechSynthesisTask/Engine")
        }
        {
            $v = "generative","long-form","neural","standard"
            break
        }

        # Amazon.Polly.LanguageCode
        {
            ($_ -eq "Get-POLSpeech/LanguageCode") -Or
            ($_ -eq "Get-POLVoice/LanguageCode") -Or
            ($_ -eq "Start-POLSpeechSynthesisTask/LanguageCode")
        }
        {
            $v = "ar-AE","arb","ca-ES","cmn-CN","cs-CZ","cy-GB","da-DK","de-AT","de-CH","de-DE","en-AU","en-GB","en-GB-WLS","en-IE","en-IN","en-NZ","en-SG","en-US","en-ZA","es-ES","es-MX","es-US","fi-FI","fr-BE","fr-CA","fr-FR","hi-IN","is-IS","it-IT","ja-JP","ko-KR","nb-NO","nl-BE","nl-NL","pl-PL","pt-BR","pt-PT","ro-RO","ru-RU","sv-SE","tr-TR","yue-CN"
            break
        }

        # Amazon.Polly.OutputFormat
        {
            ($_ -eq "Get-POLSpeech/OutputFormat") -Or
            ($_ -eq "Start-POLSpeechSynthesisTask/OutputFormat")
        }
        {
            $v = "json","mp3","ogg_opus","ogg_vorbis","pcm"
            break
        }

        # Amazon.Polly.TaskStatus
        "Get-POLSpeechSynthesisTaskList/Status"
        {
            $v = "completed","failed","inProgress","scheduled"
            break
        }

        # Amazon.Polly.TextType
        {
            ($_ -eq "Get-POLSpeech/TextType") -Or
            ($_ -eq "Start-POLSpeechSynthesisTask/TextType")
        }
        {
            $v = "ssml","text"
            break
        }

        # Amazon.Polly.VoiceId
        {
            ($_ -eq "Get-POLSpeech/VoiceId") -Or
            ($_ -eq "Start-POLSpeechSynthesisTask/VoiceId")
        }
        {
            $v = "Aditi","Adriano","Amy","Andres","Aria","Arlet","Arthur","Astrid","Ayanda","Bianca","Brian","Burcu","Camila","Carla","Carmen","Celine","Chantal","Conchita","Cristiano","Daniel","Danielle","Dora","Elin","Emma","Enrique","Ewa","Filiz","Gabrielle","Geraint","Giorgio","Gregory","Gwyneth","Hala","Hannah","Hans","Hiujin","Ida","Ines","Isabelle","Ivy","Jacek","Jan","Jasmine","Jihye","Jitka","Joanna","Joey","Justin","Kajal","Karl","Kazuha","Kendra","Kevin","Kimberly","Laura","Lea","Liam","Lisa","Liv","Lotte","Lucia","Lupe","Mads","Maja","Marlene","Mathieu","Matthew","Maxim","Mia","Miguel","Mizuki","Naja","Niamh","Nicole","Ola","Olivia","Pedro","Penelope","Raveena","Remi","Ricardo","Ruben","Russell","Ruth","Sabrina","Salli","Seoyeon","Sergio","Sofie","Stephen","Suvi","Takumi","Tatyana","Thiago","Tomoko","Vicki","Vitoria","Zayd","Zeina","Zhiyu"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$POL_map = @{
    "Engine"=@("Get-POLSpeech","Get-POLVoice","Start-POLSpeechSynthesisTask")
    "LanguageCode"=@("Get-POLSpeech","Get-POLVoice","Start-POLSpeechSynthesisTask")
    "OutputFormat"=@("Get-POLSpeech","Start-POLSpeechSynthesisTask")
    "Status"=@("Get-POLSpeechSynthesisTaskList")
    "TextType"=@("Get-POLSpeech","Start-POLSpeechSynthesisTask")
    "VoiceId"=@("Get-POLSpeech","Start-POLSpeechSynthesisTask")
}

_awsArgumentCompleterRegistration $POL_Completers $POL_map

$POL_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.POL.$($commandName.Replace('-', ''))Cmdlet]"
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

$POL_SelectMap = @{
    "Select"=@("Remove-POLLexicon",
               "Get-POLVoice",
               "Get-POLLexicon",
               "Get-POLSpeechSynthesisTask",
               "Get-POLLexiconList",
               "Get-POLSpeechSynthesisTaskList",
               "Write-POLLexicon",
               "Start-POLSpeechSynthesisTask",
               "Get-POLSpeech")
}

_awsArgumentCompleterRegistration $POL_SelectCompleters $POL_SelectMap

