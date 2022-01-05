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

# Argument completions for service Amazon Lookout for Metrics


$LOM_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.LookoutMetrics.CSVFileCompression
        {
            ($_ -eq "New-LOMMetricSet/MetricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_FileCompression") -Or
            ($_ -eq "Update-LOMMetricSet/MetricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_FileCompression") -Or
            ($_ -eq "Get-LOMSampleData/S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_FileCompression")
        }
        {
            $v = "GZIP","NONE"
            break
        }

        # Amazon.LookoutMetrics.Frequency
        {
            ($_ -eq "New-LOMAnomalyDetector/AnomalyDetectorConfig_AnomalyDetectorFrequency") -Or
            ($_ -eq "Update-LOMAnomalyDetector/AnomalyDetectorConfig_AnomalyDetectorFrequency") -Or
            ($_ -eq "New-LOMMetricSet/MetricSetFrequency") -Or
            ($_ -eq "Update-LOMMetricSet/MetricSetFrequency")
        }
        {
            $v = "P1D","PT10M","PT1H","PT5M"
            break
        }

        # Amazon.LookoutMetrics.JsonFileCompression
        {
            ($_ -eq "New-LOMMetricSet/MetricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_FileCompression") -Or
            ($_ -eq "Update-LOMMetricSet/MetricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_FileCompression") -Or
            ($_ -eq "Get-LOMSampleData/S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_FileCompression")
        }
        {
            $v = "GZIP","NONE"
            break
        }

        # Amazon.LookoutMetrics.RelationshipType
        "Get-LOMAnomalyGroupRelatedMetricList/RelationshipTypeFilter"
        {
            $v = "CAUSE_OF_INPUT_ANOMALY_GROUP","EFFECT_OF_INPUT_ANOMALY_GROUP"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$LOM_map = @{
    "AnomalyDetectorConfig_AnomalyDetectorFrequency"=@("New-LOMAnomalyDetector","Update-LOMAnomalyDetector")
    "MetricSetFrequency"=@("New-LOMMetricSet","Update-LOMMetricSet")
    "MetricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_FileCompression"=@("New-LOMMetricSet","Update-LOMMetricSet")
    "MetricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_FileCompression"=@("New-LOMMetricSet","Update-LOMMetricSet")
    "RelationshipTypeFilter"=@("Get-LOMAnomalyGroupRelatedMetricList")
    "S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_FileCompression"=@("Get-LOMSampleData")
    "S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_FileCompression"=@("Get-LOMSampleData")
}

_awsArgumentCompleterRegistration $LOM_Completers $LOM_map

$LOM_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.LOM.$($commandName.Replace('-', ''))Cmdlet]"
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

$LOM_SelectMap = @{
    "Select"=@("Enable-LOMAnomalyDetector",
               "Enable-LOMBackTestAnomalyDetector",
               "New-LOMAlert",
               "New-LOMAnomalyDetector",
               "New-LOMMetricSet",
               "Disable-LOMAnomalyDetector",
               "Remove-LOMAlert",
               "Remove-LOMAnomalyDetector",
               "Get-LOMAlert",
               "Get-LOMAnomalyDetectionExecution",
               "Get-LOMAnomalyDetector",
               "Get-LOMMetricSet",
               "Get-LOMAnomalyGroup",
               "Get-LOMFeedback",
               "Get-LOMSampleData",
               "Get-LOMAlertList",
               "Get-LOMAnomalyDetectorList",
               "Get-LOMAnomalyGroupRelatedMetricList",
               "Get-LOMAnomalyGroupSummaryList",
               "Get-LOMAnomalyGroupTimeSeriesList",
               "Get-LOMMetricSetList",
               "Get-LOMResourceTag",
               "Write-LOMFeedback",
               "Add-LOMResourceTag",
               "Remove-LOMResourceTag",
               "Update-LOMAnomalyDetector",
               "Update-LOMMetricSet")
}

_awsArgumentCompleterRegistration $LOM_SelectCompleters $LOM_SelectMap

