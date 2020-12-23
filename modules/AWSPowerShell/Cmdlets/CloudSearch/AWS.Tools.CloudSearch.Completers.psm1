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

# Argument completions for service Amazon CloudSearch


$CS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CloudSearch.AlgorithmicStemming
        "Set-CSAnalysisScheme/AnalysisScheme_AnalysisOptions_AlgorithmicStemming"
        {
            $v = "full","light","minimal","none"
            break
        }

        # Amazon.CloudSearch.AnalysisSchemeLanguage
        "Set-CSAnalysisScheme/AnalysisScheme_AnalysisSchemeLanguage"
        {
            $v = "ar","bg","ca","cs","da","de","el","en","es","eu","fa","fi","fr","ga","gl","he","hi","hu","hy","id","it","ja","ko","lv","mul","nl","no","pt","ro","ru","sv","th","tr","zh-Hans","zh-Hant"
            break
        }

        # Amazon.CloudSearch.IndexFieldType
        "Set-CSIndexField/IndexField_IndexFieldType"
        {
            $v = "date","date-array","double","double-array","int","int-array","latlon","literal","literal-array","text","text-array"
            break
        }

        # Amazon.CloudSearch.PartitionInstanceType
        "Update-CSScalingParameter/ScalingParameters_DesiredInstanceType"
        {
            $v = "search.2xlarge","search.large","search.m1.large","search.m1.small","search.m2.2xlarge","search.m2.xlarge","search.m3.2xlarge","search.m3.large","search.m3.medium","search.m3.xlarge","search.medium","search.small","search.xlarge"
            break
        }

        # Amazon.CloudSearch.SuggesterFuzzyMatching
        "Set-CSSuggester/Suggester_DocumentSuggesterOptions_FuzzyMatching"
        {
            $v = "high","low","none"
            break
        }

        # Amazon.CloudSearch.TLSSecurityPolicy
        "Update-CSDomainEndpointOption/DomainEndpointOptions_TLSSecurityPolicy"
        {
            $v = "Policy-Min-TLS-1-0-2019-07","Policy-Min-TLS-1-2-2019-07"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CS_map = @{
    "AnalysisScheme_AnalysisOptions_AlgorithmicStemming"=@("Set-CSAnalysisScheme")
    "AnalysisScheme_AnalysisSchemeLanguage"=@("Set-CSAnalysisScheme")
    "DomainEndpointOptions_TLSSecurityPolicy"=@("Update-CSDomainEndpointOption")
    "IndexField_IndexFieldType"=@("Set-CSIndexField")
    "ScalingParameters_DesiredInstanceType"=@("Update-CSScalingParameter")
    "Suggester_DocumentSuggesterOptions_FuzzyMatching"=@("Set-CSSuggester")
}

_awsArgumentCompleterRegistration $CS_Completers $CS_map

$CS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CS.$($commandName.Replace('-', ''))Cmdlet]"
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

$CS_SelectMap = @{
    "Select"=@("Start-CSSuggestersBuild",
               "New-CSDomain",
               "Set-CSAnalysisScheme",
               "Set-CSExpression",
               "Set-CSIndexField",
               "Set-CSSuggester",
               "Remove-CSAnalysisScheme",
               "Remove-CSDomain",
               "Remove-CSExpression",
               "Remove-CSIndexField",
               "Remove-CSSuggester",
               "Get-CSAnalysisScheme",
               "Get-CSAvailabilityOption",
               "Get-CSDomainEndpointOption",
               "Get-CSDomain",
               "Get-CSExpression",
               "Get-CSIndexField",
               "Get-CSScalingParameter",
               "Get-CSServiceAccessPolicy",
               "Get-CSSuggester",
               "Start-CSIndex",
               "Get-CSDomainNameList",
               "Update-CSAvailabilityOption",
               "Update-CSDomainEndpointOption",
               "Update-CSScalingParameter",
               "Update-CSServiceAccessPolicy")
}

_awsArgumentCompleterRegistration $CS_SelectCompleters $CS_SelectMap

