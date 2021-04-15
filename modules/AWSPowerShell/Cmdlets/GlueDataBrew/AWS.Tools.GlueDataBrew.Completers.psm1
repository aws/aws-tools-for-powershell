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

# Argument completions for service AWS Glue DataBrew


$GDB_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.GlueDataBrew.EncryptionMode
        {
            ($_ -eq "New-GDBProfileJob/EncryptionMode") -Or
            ($_ -eq "New-GDBRecipeJob/EncryptionMode") -Or
            ($_ -eq "Update-GDBProfileJob/EncryptionMode") -Or
            ($_ -eq "Update-GDBRecipeJob/EncryptionMode")
        }
        {
            $v = "SSE-KMS","SSE-S3"
            break
        }

        # Amazon.GlueDataBrew.InputFormat
        {
            ($_ -eq "New-GDBDataset/Format") -Or
            ($_ -eq "Update-GDBDataset/Format")
        }
        {
            $v = "CSV","EXCEL","JSON","PARQUET"
            break
        }

        # Amazon.GlueDataBrew.LogSubscription
        {
            ($_ -eq "New-GDBProfileJob/LogSubscription") -Or
            ($_ -eq "New-GDBRecipeJob/LogSubscription") -Or
            ($_ -eq "Update-GDBProfileJob/LogSubscription") -Or
            ($_ -eq "Update-GDBRecipeJob/LogSubscription")
        }
        {
            $v = "DISABLE","ENABLE"
            break
        }

        # Amazon.GlueDataBrew.Order
        {
            ($_ -eq "New-GDBDataset/PathOptions_FilesLimit_Order") -Or
            ($_ -eq "Update-GDBDataset/PathOptions_FilesLimit_Order")
        }
        {
            $v = "ASCENDING","DESCENDING"
            break
        }

        # Amazon.GlueDataBrew.OrderedBy
        {
            ($_ -eq "New-GDBDataset/PathOptions_FilesLimit_OrderedBy") -Or
            ($_ -eq "Update-GDBDataset/PathOptions_FilesLimit_OrderedBy")
        }
        {
            $v = "LAST_MODIFIED_DATE"
            break
        }

        # Amazon.GlueDataBrew.SampleMode
        {
            ($_ -eq "New-GDBProfileJob/JobSample_Mode") -Or
            ($_ -eq "Update-GDBProfileJob/JobSample_Mode")
        }
        {
            $v = "CUSTOM_ROWS","FULL_DATASET"
            break
        }

        # Amazon.GlueDataBrew.SampleType
        {
            ($_ -eq "New-GDBProject/Sample_Type") -Or
            ($_ -eq "Update-GDBProject/Sample_Type")
        }
        {
            $v = "FIRST_N","LAST_N","RANDOM"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$GDB_map = @{
    "EncryptionMode"=@("New-GDBProfileJob","New-GDBRecipeJob","Update-GDBProfileJob","Update-GDBRecipeJob")
    "Format"=@("New-GDBDataset","Update-GDBDataset")
    "JobSample_Mode"=@("New-GDBProfileJob","Update-GDBProfileJob")
    "LogSubscription"=@("New-GDBProfileJob","New-GDBRecipeJob","Update-GDBProfileJob","Update-GDBRecipeJob")
    "PathOptions_FilesLimit_Order"=@("New-GDBDataset","Update-GDBDataset")
    "PathOptions_FilesLimit_OrderedBy"=@("New-GDBDataset","Update-GDBDataset")
    "Sample_Type"=@("New-GDBProject","Update-GDBProject")
}

_awsArgumentCompleterRegistration $GDB_Completers $GDB_map

$GDB_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.GDB.$($commandName.Replace('-', ''))Cmdlet]"
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

$GDB_SelectMap = @{
    "Select"=@("Remove-GDBRecipeVersionBatch",
               "New-GDBDataset",
               "New-GDBProfileJob",
               "New-GDBProject",
               "New-GDBRecipe",
               "New-GDBRecipeJob",
               "New-GDBSchedule",
               "Remove-GDBDataset",
               "Remove-GDBJob",
               "Remove-GDBProject",
               "Remove-GDBRecipeVersion",
               "Remove-GDBSchedule",
               "Get-GDBDataset",
               "Get-GDBJob",
               "Get-GDBJobRun",
               "Get-GDBProject",
               "Get-GDBRecipe",
               "Get-GDBSchedule",
               "Get-GDBDatasetList",
               "Get-GDBJobRunList",
               "Get-GDBJobList",
               "Get-GDBProjectList",
               "Get-GDBRecipeList",
               "Get-GDBRecipeVersionList",
               "Get-GDBScheduleList",
               "Get-GDBResourceTag",
               "Publish-GDBRecipe",
               "Send-GDBProjectSessionAction",
               "Start-GDBJobRun",
               "Start-GDBProjectSession",
               "Stop-GDBJobRun",
               "Add-GDBResourceTag",
               "Remove-GDBResourceTag",
               "Update-GDBDataset",
               "Update-GDBProfileJob",
               "Update-GDBProject",
               "Update-GDBRecipe",
               "Update-GDBRecipeJob",
               "Update-GDBSchedule")
}

_awsArgumentCompleterRegistration $GDB_SelectCompleters $GDB_SelectMap

