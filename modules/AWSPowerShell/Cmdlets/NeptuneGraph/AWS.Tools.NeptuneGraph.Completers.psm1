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

# Argument completions for service Amazon Neptune Graph


$NEPTG_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.NeptuneGraph.BlankNodeHandling
        {
            ($_ -eq "New-NEPTGGraphUsingImportTask/BlankNodeHandling") -Or
            ($_ -eq "Start-NEPTGImportTask/BlankNodeHandling")
        }
        {
            $v = "convertToIri"
            break
        }

        # Amazon.NeptuneGraph.ExplainMode
        "Invoke-NEPTGQuery/ExplainMode"
        {
            $v = "DETAILS","STATIC"
            break
        }

        # Amazon.NeptuneGraph.ExportFormat
        "Start-NEPTGExportTask/Format"
        {
            $v = "CSV","PARQUET"
            break
        }

        # Amazon.NeptuneGraph.Format
        {
            ($_ -eq "New-NEPTGGraphUsingImportTask/Format") -Or
            ($_ -eq "Start-NEPTGImportTask/Format")
        }
        {
            $v = "CSV","NTRIPLES","OPEN_CYPHER","PARQUET"
            break
        }

        # Amazon.NeptuneGraph.GraphSummaryMode
        "Get-NEPTGGraphSummary/Mode"
        {
            $v = "BASIC","DETAILED"
            break
        }

        # Amazon.NeptuneGraph.ParquetType
        {
            ($_ -eq "New-NEPTGGraphUsingImportTask/ParquetType") -Or
            ($_ -eq "Start-NEPTGExportTask/ParquetType") -Or
            ($_ -eq "Start-NEPTGImportTask/ParquetType")
        }
        {
            $v = "COLUMNAR"
            break
        }

        # Amazon.NeptuneGraph.PlanCacheType
        "Invoke-NEPTGQuery/PlanCache"
        {
            $v = "AUTO","DISABLED","ENABLED"
            break
        }

        # Amazon.NeptuneGraph.QueryLanguage
        "Invoke-NEPTGQuery/Language"
        {
            $v = "OPEN_CYPHER"
            break
        }

        # Amazon.NeptuneGraph.QueryStateInput
        "Get-NEPTGQueryList/State"
        {
            $v = "ALL","CANCELLING","RUNNING","WAITING"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$NEPTG_map = @{
    "BlankNodeHandling"=@("New-NEPTGGraphUsingImportTask","Start-NEPTGImportTask")
    "ExplainMode"=@("Invoke-NEPTGQuery")
    "Format"=@("New-NEPTGGraphUsingImportTask","Start-NEPTGExportTask","Start-NEPTGImportTask")
    "Language"=@("Invoke-NEPTGQuery")
    "Mode"=@("Get-NEPTGGraphSummary")
    "ParquetType"=@("New-NEPTGGraphUsingImportTask","Start-NEPTGExportTask","Start-NEPTGImportTask")
    "PlanCache"=@("Invoke-NEPTGQuery")
    "State"=@("Get-NEPTGQueryList")
}

_awsArgumentCompleterRegistration $NEPTG_Completers $NEPTG_map

$NEPTG_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.NEPTG.$($commandName.Replace('-', ''))Cmdlet]"
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

$NEPTG_SelectMap = @{
    "Select"=@("Stop-NEPTGExportTask",
               "Stop-NEPTGImportTask",
               "Stop-NEPTGQuery",
               "New-NEPTGGraph",
               "New-NEPTGGraphSnapshot",
               "New-NEPTGGraphUsingImportTask",
               "New-NEPTGPrivateGraphEndpoint",
               "Remove-NEPTGGraph",
               "Remove-NEPTGGraphSnapshot",
               "Remove-NEPTGPrivateGraphEndpoint",
               "Invoke-NEPTGQuery",
               "Get-NEPTGExportTask",
               "Get-NEPTGGraph",
               "Get-NEPTGGraphSnapshot",
               "Get-NEPTGGraphSummary",
               "Get-NEPTGImportTask",
               "Get-NEPTGPrivateGraphEndpoint",
               "Get-NEPTGQuery",
               "Get-NEPTGExportTaskList",
               "Get-NEPTGGraphList",
               "Get-NEPTGGraphSnapshotList",
               "Get-NEPTGImportTaskList",
               "Get-NEPTGPrivateGraphEndpointList",
               "Get-NEPTGQueryList",
               "Get-NEPTGResourceTag",
               "Reset-NEPTGGraph",
               "Restore-NEPTGGraphFromSnapshot",
               "Start-NEPTGExportTask",
               "Start-NEPTGGraph",
               "Start-NEPTGImportTask",
               "Stop-NEPTGGraph",
               "Add-NEPTGResourceTag",
               "Remove-NEPTGResourceTag",
               "Update-NEPTGGraph")
}

_awsArgumentCompleterRegistration $NEPTG_SelectCompleters $NEPTG_SelectMap

