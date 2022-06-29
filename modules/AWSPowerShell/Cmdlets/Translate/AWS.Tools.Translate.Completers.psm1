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

# Argument completions for service Amazon Translate


$TRN_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Translate.Directionality
        "Import-TRNTerminology/TerminologyData_Directionality"
        {
            $v = "MULTI","UNI"
            break
        }

        # Amazon.Translate.DisplayLanguageCode
        "Get-TRNLanguageList/DisplayLanguageCode"
        {
            $v = "de","en","es","fr","it","ja","ko","pt","zh","zh-TW"
            break
        }

        # Amazon.Translate.EncryptionKeyType
        {
            ($_ -eq "Import-TRNTerminology/EncryptionKey_Type") -Or
            ($_ -eq "New-TRNParallelData/EncryptionKey_Type") -Or
            ($_ -eq "Start-TRNTextTranslationJob/OutputDataConfig_EncryptionKey_Type")
        }
        {
            $v = "KMS"
            break
        }

        # Amazon.Translate.Formality
        {
            ($_ -eq "ConvertTo-TRNTargetLanguage/Settings_Formality") -Or
            ($_ -eq "Start-TRNTextTranslationJob/Settings_Formality")
        }
        {
            $v = "FORMAL","INFORMAL"
            break
        }

        # Amazon.Translate.JobStatus
        "Get-TRNTextTranslationJobList/Filter_JobStatus"
        {
            $v = "COMPLETED","COMPLETED_WITH_ERROR","FAILED","IN_PROGRESS","STOPPED","STOP_REQUESTED","SUBMITTED"
            break
        }

        # Amazon.Translate.MergeStrategy
        "Import-TRNTerminology/MergeStrategy"
        {
            $v = "OVERWRITE"
            break
        }

        # Amazon.Translate.ParallelDataFormat
        {
            ($_ -eq "New-TRNParallelData/ParallelDataConfig_Format") -Or
            ($_ -eq "Update-TRNParallelData/ParallelDataConfig_Format")
        }
        {
            $v = "CSV","TMX","TSV"
            break
        }

        # Amazon.Translate.Profanity
        {
            ($_ -eq "ConvertTo-TRNTargetLanguage/Settings_Profanity") -Or
            ($_ -eq "Start-TRNTextTranslationJob/Settings_Profanity")
        }
        {
            $v = "MASK"
            break
        }

        # Amazon.Translate.TerminologyDataFormat
        {
            ($_ -eq "Import-TRNTerminology/TerminologyData_Format") -Or
            ($_ -eq "Get-TRNTerminology/TerminologyDataFormat")
        }
        {
            $v = "CSV","TMX","TSV"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$TRN_map = @{
    "DisplayLanguageCode"=@("Get-TRNLanguageList")
    "EncryptionKey_Type"=@("Import-TRNTerminology","New-TRNParallelData")
    "Filter_JobStatus"=@("Get-TRNTextTranslationJobList")
    "MergeStrategy"=@("Import-TRNTerminology")
    "OutputDataConfig_EncryptionKey_Type"=@("Start-TRNTextTranslationJob")
    "ParallelDataConfig_Format"=@("New-TRNParallelData","Update-TRNParallelData")
    "Settings_Formality"=@("ConvertTo-TRNTargetLanguage","Start-TRNTextTranslationJob")
    "Settings_Profanity"=@("ConvertTo-TRNTargetLanguage","Start-TRNTextTranslationJob")
    "TerminologyData_Directionality"=@("Import-TRNTerminology")
    "TerminologyData_Format"=@("Import-TRNTerminology")
    "TerminologyDataFormat"=@("Get-TRNTerminology")
}

_awsArgumentCompleterRegistration $TRN_Completers $TRN_map

$TRN_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.TRN.$($commandName.Replace('-', ''))Cmdlet]"
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

$TRN_SelectMap = @{
    "Select"=@("New-TRNParallelData",
               "Remove-TRNParallelData",
               "Remove-TRNTerminology",
               "Get-TRNTextTranslationJob",
               "Get-TRNParallelData",
               "Get-TRNTerminology",
               "Import-TRNTerminology",
               "Get-TRNLanguageList",
               "Get-TRNParallelDataList",
               "Get-TRNTerminologyList",
               "Get-TRNTextTranslationJobList",
               "Start-TRNTextTranslationJob",
               "Stop-TRNTextTranslationJob",
               "ConvertTo-TRNTargetLanguage",
               "Update-TRNParallelData")
}

_awsArgumentCompleterRegistration $TRN_SelectCompleters $TRN_SelectMap

