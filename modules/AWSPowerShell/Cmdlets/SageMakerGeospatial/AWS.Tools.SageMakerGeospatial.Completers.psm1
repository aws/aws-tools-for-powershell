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

# Argument completions for service SageMaker Geospatial


$SMGS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.SageMakerGeospatial.AlgorithmNameCloudRemoval
        "Start-SMGSEarthObservationJob/CloudRemovalConfig_AlgorithmName"
        {
            $v = "INTERPOLATION"
            break
        }

        # Amazon.SageMakerGeospatial.AlgorithmNameGeoMosaic
        "Start-SMGSEarthObservationJob/GeoMosaicConfig_AlgorithmName"
        {
            $v = "AVERAGE","BILINEAR","CUBIC","CUBICSPLINE","LANCZOS","MAX","MED","MIN","MODE","NEAR","Q1","Q3","RMS","SUM"
            break
        }

        # Amazon.SageMakerGeospatial.AlgorithmNameResampling
        "Start-SMGSEarthObservationJob/ResamplingConfig_AlgorithmName"
        {
            $v = "AVERAGE","BILINEAR","CUBIC","CUBICSPLINE","LANCZOS","MAX","MED","MIN","MODE","NEAR","Q1","Q3","RMS","SUM"
            break
        }

        # Amazon.SageMakerGeospatial.EarthObservationJobStatus
        "Get-SMGSEarthObservationJobList/StatusEqual"
        {
            $v = "COMPLETED","DELETED","DELETING","FAILED","INITIALIZING","IN_PROGRESS","STOPPED","STOPPING"
            break
        }

        # Amazon.SageMakerGeospatial.GroupBy
        "Start-SMGSEarthObservationJob/TemporalStatisticsConfig_GroupBy"
        {
            $v = "ALL","YEARLY"
            break
        }

        # Amazon.SageMakerGeospatial.LogicalOperator
        {
            ($_ -eq "Search-SMGSRasterDataCollection/PropertyFilters_LogicalOperator") -Or
            ($_ -eq "Start-SMGSEarthObservationJob/PropertyFilters_LogicalOperator")
        }
        {
            $v = "AND"
            break
        }

        # Amazon.SageMakerGeospatial.OutputType
        "Get-SMGSTile/OutputDataType"
        {
            $v = "FLOAT32","FLOAT64","INT16","INT32","UINT16"
            break
        }

        # Amazon.SageMakerGeospatial.PredefinedResolution
        "Start-SMGSEarthObservationJob/OutputResolution_Predefined"
        {
            $v = "AVERAGE","HIGHEST","LOWEST"
            break
        }

        # Amazon.SageMakerGeospatial.SortOrder
        {
            ($_ -eq "Get-SMGSEarthObservationJobList/SortOrder") -Or
            ($_ -eq "Get-SMGSVectorEnrichmentJobList/SortOrder")
        }
        {
            $v = "ASCENDING","DESCENDING"
            break
        }

        # Amazon.SageMakerGeospatial.TargetOptions
        "Get-SMGSTile/Target"
        {
            $v = "INPUT","OUTPUT"
            break
        }

        # Amazon.SageMakerGeospatial.Unit
        {
            ($_ -eq "Start-SMGSEarthObservationJob/JobConfig_ResamplingConfig_OutputResolution_UserDefined_Unit") -Or
            ($_ -eq "Start-SMGSEarthObservationJob/JobConfig_StackConfig_OutputResolution_UserDefined_Unit")
        }
        {
            $v = "METERS"
            break
        }

        # Amazon.SageMakerGeospatial.VectorEnrichmentJobDocumentType
        "Start-SMGSVectorEnrichmentJob/InputConfig_DocumentType"
        {
            $v = "CSV"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SMGS_map = @{
    "CloudRemovalConfig_AlgorithmName"=@("Start-SMGSEarthObservationJob")
    "GeoMosaicConfig_AlgorithmName"=@("Start-SMGSEarthObservationJob")
    "InputConfig_DocumentType"=@("Start-SMGSVectorEnrichmentJob")
    "JobConfig_ResamplingConfig_OutputResolution_UserDefined_Unit"=@("Start-SMGSEarthObservationJob")
    "JobConfig_StackConfig_OutputResolution_UserDefined_Unit"=@("Start-SMGSEarthObservationJob")
    "OutputDataType"=@("Get-SMGSTile")
    "OutputResolution_Predefined"=@("Start-SMGSEarthObservationJob")
    "PropertyFilters_LogicalOperator"=@("Search-SMGSRasterDataCollection","Start-SMGSEarthObservationJob")
    "ResamplingConfig_AlgorithmName"=@("Start-SMGSEarthObservationJob")
    "SortOrder"=@("Get-SMGSEarthObservationJobList","Get-SMGSVectorEnrichmentJobList")
    "StatusEqual"=@("Get-SMGSEarthObservationJobList")
    "Target"=@("Get-SMGSTile")
    "TemporalStatisticsConfig_GroupBy"=@("Start-SMGSEarthObservationJob")
}

_awsArgumentCompleterRegistration $SMGS_Completers $SMGS_map

$SMGS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.SMGS.$($commandName.Replace('-', ''))Cmdlet]"
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

$SMGS_SelectMap = @{
    "Select"=@("Remove-SMGSEarthObservationJob",
               "Remove-SMGSVectorEnrichmentJob",
               "Export-SMGSEarthObservationJob",
               "Export-SMGSVectorEnrichmentJob",
               "Get-SMGSEarthObservationJob",
               "Get-SMGSRasterDataCollection",
               "Get-SMGSTile",
               "Get-SMGSVectorEnrichmentJob",
               "Get-SMGSEarthObservationJobList",
               "Get-SMGSRasterDataCollectionList",
               "Get-SMGSResourceTag",
               "Get-SMGSVectorEnrichmentJobList",
               "Search-SMGSRasterDataCollection",
               "Start-SMGSEarthObservationJob",
               "Start-SMGSVectorEnrichmentJob",
               "Stop-SMGSEarthObservationJob",
               "Stop-SMGSVectorEnrichmentJob",
               "Add-SMGSResourceTag",
               "Remove-SMGSResourceTag")
}

_awsArgumentCompleterRegistration $SMGS_SelectCompleters $SMGS_SelectMap

