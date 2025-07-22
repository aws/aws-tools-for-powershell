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

# Argument completions for service Amazon NeptuneData


$NEPT_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Neptunedata.Action
        "Invoke-NEPTFastReset/Action"
        {
            $v = "initiateDatabaseReset","performDatabaseReset"
            break
        }

        # Amazon.Neptunedata.Encoding
        {
            ($_ -eq "Get-NEPTPropertygraphStream/Encoding") -Or
            ($_ -eq "Get-NEPTSparqlStream/Encoding")
        }
        {
            $v = "gzip"
            break
        }

        # Amazon.Neptunedata.Format
        "Start-NEPTLoaderJob/Format"
        {
            $v = "csv","nquads","ntriples","opencypher","rdfxml","turtle"
            break
        }

        # Amazon.Neptunedata.GraphSummaryType
        {
            ($_ -eq "Get-NEPTPropertygraphSummary/Mode") -Or
            ($_ -eq "Get-NEPTRDFGraphSummary/Mode")
        }
        {
            $v = "basic","detailed"
            break
        }

        # Amazon.Neptunedata.IteratorType
        {
            ($_ -eq "Get-NEPTPropertygraphStream/IteratorType") -Or
            ($_ -eq "Get-NEPTSparqlStream/IteratorType")
        }
        {
            $v = "AFTER_SEQUENCE_NUMBER","AT_SEQUENCE_NUMBER","LATEST","TRIM_HORIZON"
            break
        }

        # Amazon.Neptunedata.Mode
        "Start-NEPTLoaderJob/Mode"
        {
            $v = "AUTO","NEW","RESUME"
            break
        }

        # Amazon.Neptunedata.OpenCypherExplainMode
        "Invoke-NEPTOpenCypherExplainQuery/ExplainMode"
        {
            $v = "details","dynamic","static"
            break
        }

        # Amazon.Neptunedata.Parallelism
        "Start-NEPTLoaderJob/Parallelism"
        {
            $v = "HIGH","LOW","MEDIUM","OVERSUBSCRIBE"
            break
        }

        # Amazon.Neptunedata.S3BucketRegion
        "Start-NEPTLoaderJob/S3BucketRegion"
        {
            $v = "af-south-1","ap-east-1","ap-east-2","ap-northeast-1","ap-northeast-2","ap-northeast-3","ap-south-1","ap-south-2","ap-southeast-1","ap-southeast-2","ap-southeast-3","ap-southeast-4","ap-southeast-5","ap-southeast-7","ca-central-1","ca-west-1","cn-north-1","cn-northwest-1","eu-central-1","eu-central-2","eu-north-1","eu-south-2","eu-west-1","eu-west-2","eu-west-3","il-central-1","me-central-1","me-south-1","mx-central-1","sa-east-1","us-east-1","us-east-2","us-gov-east-1","us-gov-west-1","us-west-1","us-west-2"
            break
        }

        # Amazon.Neptunedata.StatisticsAutoGenerationMode
        {
            ($_ -eq "Update-NEPTPropertygraphStatistic/Mode") -Or
            ($_ -eq "Update-NEPTSparqlStatistic/Mode")
        }
        {
            $v = "disableAutoCompute","enableAutoCompute","refresh"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$NEPT_map = @{
    "Action"=@("Invoke-NEPTFastReset")
    "Encoding"=@("Get-NEPTPropertygraphStream","Get-NEPTSparqlStream")
    "ExplainMode"=@("Invoke-NEPTOpenCypherExplainQuery")
    "Format"=@("Start-NEPTLoaderJob")
    "IteratorType"=@("Get-NEPTPropertygraphStream","Get-NEPTSparqlStream")
    "Mode"=@("Get-NEPTPropertygraphSummary","Get-NEPTRDFGraphSummary","Start-NEPTLoaderJob","Update-NEPTPropertygraphStatistic","Update-NEPTSparqlStatistic")
    "Parallelism"=@("Start-NEPTLoaderJob")
    "S3BucketRegion"=@("Start-NEPTLoaderJob")
}

_awsArgumentCompleterRegistration $NEPT_Completers $NEPT_map

$NEPT_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.NEPT.$($commandName.Replace('-', ''))Cmdlet]"
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

$NEPT_SelectMap = @{
    "Select"=@("Stop-NEPTGremlinQuery",
               "Stop-NEPTLoaderJob",
               "Stop-NEPTMLDataProcessingJob",
               "Stop-NEPTMLModelTrainingJob",
               "Stop-NEPTMLModelTransformJob",
               "Stop-NEPTOpenCypherQuery",
               "New-NEPTMLEndpoint",
               "Remove-NEPTMLEndpoint",
               "Remove-NEPTPropertygraphStatistic",
               "Remove-NEPTSparqlStatistic",
               "Invoke-NEPTFastReset",
               "Invoke-NEPTGremlinExplainQuery",
               "Invoke-NEPTGremlinProfileQuery",
               "Invoke-NEPTGremlinQuery",
               "Invoke-NEPTOpenCypherExplainQuery",
               "Invoke-NEPTOpenCypherQuery",
               "Get-NEPTEngineStatus",
               "Get-NEPTGremlinQueryStatus",
               "Get-NEPTLoaderJobStatus",
               "Get-NEPTMLDataProcessingJob",
               "Get-NEPTMLEndpoint",
               "Get-NEPTMLModelTrainingJob",
               "Get-NEPTMLModelTransformJob",
               "Get-NEPTOpenCypherQueryStatus",
               "Get-NEPTPropertygraphStatistic",
               "Get-NEPTPropertygraphStream",
               "Get-NEPTPropertygraphSummary",
               "Get-NEPTRDFGraphSummary",
               "Get-NEPTSparqlStatistic",
               "Get-NEPTSparqlStream",
               "Get-NEPTGremlinQueryList",
               "Get-NEPTLoaderJobList",
               "Get-NEPTMLDataProcessingJobList",
               "Get-NEPTMLEndpointList",
               "Get-NEPTMLModelTrainingJobList",
               "Get-NEPTMLModelTransformJobList",
               "Get-NEPTOpenCypherQueryList",
               "Update-NEPTPropertygraphStatistic",
               "Update-NEPTSparqlStatistic",
               "Start-NEPTLoaderJob",
               "Start-NEPTMLDataProcessingJob",
               "Start-NEPTMLModelTrainingJob",
               "Start-NEPTMLModelTransformJob")
}

_awsArgumentCompleterRegistration $NEPT_SelectCompleters $NEPT_SelectMap

