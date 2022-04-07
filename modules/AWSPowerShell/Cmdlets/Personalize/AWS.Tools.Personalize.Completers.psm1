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

# Argument completions for service AWS Personalize


$PERS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Personalize.Domain
        {
            ($_ -eq "Get-PERSRecipeList/Domain") -Or
            ($_ -eq "New-PERSDatasetGroup/Domain") -Or
            ($_ -eq "New-PERSSchema/Domain")
        }
        {
            $v = "ECOMMERCE","VIDEO_ON_DEMAND"
            break
        }

        # Amazon.Personalize.IngestionMode
        "New-PERSDatasetExportJob/IngestionMode"
        {
            $v = "ALL","BULK","PUT"
            break
        }

        # Amazon.Personalize.ObjectiveSensitivity
        "New-PERSSolution/SolutionConfig_OptimizationObjective_ObjectiveSensitivity"
        {
            $v = "HIGH","LOW","MEDIUM","OFF"
            break
        }

        # Amazon.Personalize.RecipeProvider
        "Get-PERSRecipeList/RecipeProvider"
        {
            $v = "SERVICE"
            break
        }

        # Amazon.Personalize.TrainingMode
        "New-PERSSolutionVersion/TrainingMode"
        {
            $v = "FULL","UPDATE"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$PERS_map = @{
    "Domain"=@("Get-PERSRecipeList","New-PERSDatasetGroup","New-PERSSchema")
    "IngestionMode"=@("New-PERSDatasetExportJob")
    "RecipeProvider"=@("Get-PERSRecipeList")
    "SolutionConfig_OptimizationObjective_ObjectiveSensitivity"=@("New-PERSSolution")
    "TrainingMode"=@("New-PERSSolutionVersion")
}

_awsArgumentCompleterRegistration $PERS_Completers $PERS_map

$PERS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.PERS.$($commandName.Replace('-', ''))Cmdlet]"
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

$PERS_SelectMap = @{
    "Select"=@("New-PERSBatchInferenceJob",
               "New-PERSBatchSegmentJob",
               "New-PERSCampaign",
               "New-PERSDataset",
               "New-PERSDatasetExportJob",
               "New-PERSDatasetGroup",
               "New-PERSDatasetImportJob",
               "New-PERSEventTracker",
               "New-PERSFilter",
               "New-PERSRecommender",
               "New-PERSSchema",
               "New-PERSSolution",
               "New-PERSSolutionVersion",
               "Remove-PERSCampaign",
               "Remove-PERSDataset",
               "Remove-PERSDatasetGroup",
               "Remove-PERSEventTracker",
               "Remove-PERSFilter",
               "Remove-PERSRecommender",
               "Remove-PERSSchema",
               "Remove-PERSSolution",
               "Get-PERSAlgorithm",
               "Get-PERSBatchInferenceJob",
               "Get-PERSBatchSegmentJob",
               "Get-PERSCampaign",
               "Get-PERSDataset",
               "Get-PERSDatasetExportJob",
               "Get-PERSDatasetGroup",
               "Get-PERSDatasetImportJob",
               "Get-PERSEventTracker",
               "Get-PERSFeatureTransformation",
               "Get-PERSFilter",
               "Get-PERSRecipe",
               "Get-PERSRecommender",
               "Get-PERSSchema",
               "Get-PERSSolution",
               "Get-PERSSolutionVersion",
               "Get-PERSSolutionMetric",
               "Get-PERSBatchInferenceJobList",
               "Get-PERSBatchSegmentJobList",
               "Get-PERSCampaignList",
               "Get-PERSDatasetExportJobList",
               "Get-PERSDatasetGroupList",
               "Get-PERSDatasetImportJobList",
               "Get-PERSDatasetList",
               "Get-PERSEventTrackerList",
               "Get-PERSFilterList",
               "Get-PERSRecipeList",
               "Get-PERSRecommenderList",
               "Get-PERSSchemaList",
               "Get-PERSSolutionList",
               "Get-PERSSolutionVersionList",
               "Get-PERSResourceTag",
               "Stop-PERSSolutionVersionCreation",
               "Add-PERSResourceTag",
               "Remove-PERSResourceTag",
               "Update-PERSCampaign",
               "Update-PERSRecommender")
}

_awsArgumentCompleterRegistration $PERS_SelectCompleters $PERS_SelectMap

