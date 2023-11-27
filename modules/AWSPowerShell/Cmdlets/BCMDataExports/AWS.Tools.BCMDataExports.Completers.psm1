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

# Argument completions for service AWSBillingAndCostManagementDataExports


$BCMDE_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.BCMDataExports.CompressionOption
        {
            ($_ -eq "New-BCMDEExport/Export_DestinationConfigurations_S3Destination_S3OutputConfigurations_Compression") -Or
            ($_ -eq "Update-BCMDEExport/Export_DestinationConfigurations_S3Destination_S3OutputConfigurations_Compression")
        }
        {
            $v = "GZIP","PARQUET"
            break
        }

        # Amazon.BCMDataExports.FormatOption
        {
            ($_ -eq "New-BCMDEExport/Export_DestinationConfigurations_S3Destination_S3OutputConfigurations_Format") -Or
            ($_ -eq "Update-BCMDEExport/Export_DestinationConfigurations_S3Destination_S3OutputConfigurations_Format")
        }
        {
            $v = "PARQUET","TEXT_OR_CSV"
            break
        }

        # Amazon.BCMDataExports.FrequencyOption
        {
            ($_ -eq "New-BCMDEExport/Export_RefreshCadence_Frequency") -Or
            ($_ -eq "Update-BCMDEExport/Export_RefreshCadence_Frequency")
        }
        {
            $v = "SYNCHRONOUS"
            break
        }

        # Amazon.BCMDataExports.OverwriteOption
        {
            ($_ -eq "New-BCMDEExport/Export_DestinationConfigurations_S3Destination_S3OutputConfigurations_Overwrite") -Or
            ($_ -eq "Update-BCMDEExport/Export_DestinationConfigurations_S3Destination_S3OutputConfigurations_Overwrite")
        }
        {
            $v = "CREATE_NEW_REPORT","OVERWRITE_REPORT"
            break
        }

        # Amazon.BCMDataExports.S3OutputType
        {
            ($_ -eq "New-BCMDEExport/Export_DestinationConfigurations_S3Destination_S3OutputConfigurations_OutputType") -Or
            ($_ -eq "Update-BCMDEExport/Export_DestinationConfigurations_S3Destination_S3OutputConfigurations_OutputType")
        }
        {
            $v = "CUSTOM"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$BCMDE_map = @{
    "Export_DestinationConfigurations_S3Destination_S3OutputConfigurations_Compression"=@("New-BCMDEExport","Update-BCMDEExport")
    "Export_DestinationConfigurations_S3Destination_S3OutputConfigurations_Format"=@("New-BCMDEExport","Update-BCMDEExport")
    "Export_DestinationConfigurations_S3Destination_S3OutputConfigurations_OutputType"=@("New-BCMDEExport","Update-BCMDEExport")
    "Export_DestinationConfigurations_S3Destination_S3OutputConfigurations_Overwrite"=@("New-BCMDEExport","Update-BCMDEExport")
    "Export_RefreshCadence_Frequency"=@("New-BCMDEExport","Update-BCMDEExport")
}

_awsArgumentCompleterRegistration $BCMDE_Completers $BCMDE_map

$BCMDE_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.BCMDE.$($commandName.Replace('-', ''))Cmdlet]"
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

$BCMDE_SelectMap = @{
    "Select"=@("New-BCMDEExport",
               "Remove-BCMDEExport",
               "Get-BCMDEExecution",
               "Get-BCMDEExport",
               "Get-BCMDETable",
               "Get-BCMDEExecutionList",
               "Get-BCMDEExportList",
               "Get-BCMDETableList",
               "Get-BCMDEResourceTag",
               "Add-BCMDEResourceTag",
               "Remove-BCMDEResourceTag",
               "Update-BCMDEExport")
}

_awsArgumentCompleterRegistration $BCMDE_SelectCompleters $BCMDE_SelectMap

