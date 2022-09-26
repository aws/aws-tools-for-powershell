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

# Argument completions for service AWS Cost and Usage Report


$CUR_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CostAndUsageReport.AWSRegion
        {
            ($_ -eq "Edit-CURReportDefinition/ReportDefinition_S3Region") -Or
            ($_ -eq "Write-CURReportDefinition/ReportDefinition_S3Region")
        }
        {
            $v = "af-south-1","ap-east-1","ap-northeast-1","ap-northeast-2","ap-northeast-3","ap-south-1","ap-southeast-1","ap-southeast-2","ap-southeast-3","ca-central-1","cn-north-1","cn-northwest-1","eu-central-1","eu-north-1","eu-south-1","eu-south-2","eu-west-1","eu-west-2","eu-west-3","me-central-1","me-south-1","sa-east-1","us-east-1","us-east-2","us-west-1","us-west-2"
            break
        }

        # Amazon.CostAndUsageReport.CompressionFormat
        {
            ($_ -eq "Edit-CURReportDefinition/ReportDefinition_Compression") -Or
            ($_ -eq "Write-CURReportDefinition/ReportDefinition_Compression")
        }
        {
            $v = "GZIP","Parquet","ZIP"
            break
        }

        # Amazon.CostAndUsageReport.ReportFormat
        {
            ($_ -eq "Edit-CURReportDefinition/ReportDefinition_Format") -Or
            ($_ -eq "Write-CURReportDefinition/ReportDefinition_Format")
        }
        {
            $v = "Parquet","textORcsv"
            break
        }

        # Amazon.CostAndUsageReport.ReportVersioning
        {
            ($_ -eq "Edit-CURReportDefinition/ReportDefinition_ReportVersioning") -Or
            ($_ -eq "Write-CURReportDefinition/ReportDefinition_ReportVersioning")
        }
        {
            $v = "CREATE_NEW_REPORT","OVERWRITE_REPORT"
            break
        }

        # Amazon.CostAndUsageReport.TimeUnit
        {
            ($_ -eq "Edit-CURReportDefinition/ReportDefinition_TimeUnit") -Or
            ($_ -eq "Write-CURReportDefinition/ReportDefinition_TimeUnit")
        }
        {
            $v = "DAILY","HOURLY","MONTHLY"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CUR_map = @{
    "ReportDefinition_Compression"=@("Edit-CURReportDefinition","Write-CURReportDefinition")
    "ReportDefinition_Format"=@("Edit-CURReportDefinition","Write-CURReportDefinition")
    "ReportDefinition_ReportVersioning"=@("Edit-CURReportDefinition","Write-CURReportDefinition")
    "ReportDefinition_S3Region"=@("Edit-CURReportDefinition","Write-CURReportDefinition")
    "ReportDefinition_TimeUnit"=@("Edit-CURReportDefinition","Write-CURReportDefinition")
}

_awsArgumentCompleterRegistration $CUR_Completers $CUR_map

$CUR_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CUR.$($commandName.Replace('-', ''))Cmdlet]"
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

$CUR_SelectMap = @{
    "Select"=@("Remove-CURReportDefinition",
               "Get-CURReportDefinition",
               "Edit-CURReportDefinition",
               "Write-CURReportDefinition")
}

_awsArgumentCompleterRegistration $CUR_SelectCompleters $CUR_SelectMap

