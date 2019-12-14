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

# Argument completions for service Amazon Fraud Detector


$FD_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.FraudDetector.DataSource
        "New-FDVariable/DataSource"
        {
            $v = "EVENT","EXTERNAL_MODEL_SCORE","MODEL_SCORE"
            break
        }

        # Amazon.FraudDetector.DataType
        "New-FDVariable/DataType"
        {
            $v = "BOOLEAN","FLOAT","INTEGER","STRING"
            break
        }

        # Amazon.FraudDetector.DetectorVersionStatus
        "Update-FDDetectorVersionStatus/Status"
        {
            $v = "ACTIVE","DRAFT","INACTIVE"
            break
        }

        # Amazon.FraudDetector.Language
        {
            ($_ -eq "New-FDRule/Language") -Or
            ($_ -eq "Update-FDRuleVersion/Language")
        }
        {
            $v = "DETECTORPL"
            break
        }

        # Amazon.FraudDetector.ModelEndpointStatus
        "Write-FDExternalModel/ModelEndpointStatus"
        {
            $v = "ASSOCIATED","DISSOCIATED"
            break
        }

        # Amazon.FraudDetector.ModelInputDataFormat
        "Write-FDExternalModel/InputConfiguration_Format"
        {
            $v = "APPLICATION_JSON","TEXT_CSV"
            break
        }

        # Amazon.FraudDetector.ModelOutputDataFormat
        "Write-FDExternalModel/OutputConfiguration_Format"
        {
            $v = "APPLICATION_JSONLINES","TEXT_CSV"
            break
        }

        # Amazon.FraudDetector.ModelSource
        "Write-FDExternalModel/ModelSource"
        {
            $v = "SAGEMAKER"
            break
        }

        # Amazon.FraudDetector.ModelTypeEnum
        {
            ($_ -eq "Get-FDModel/ModelType") -Or
            ($_ -eq "Get-FDModelVersion/ModelType") -Or
            ($_ -eq "Get-FDModelVersionList/ModelType") -Or
            ($_ -eq "New-FDModelVersion/ModelType") -Or
            ($_ -eq "Update-FDModelVersion/ModelType") -Or
            ($_ -eq "Write-FDModel/ModelType")
        }
        {
            $v = "ONLINE_FRAUD_INSIGHTS"
            break
        }

        # Amazon.FraudDetector.ModelVersionStatus
        "Update-FDModelVersion/Status"
        {
            $v = "ACTIVATE_IN_PROGRESS","ACTIVATE_REQUESTED","ACTIVE","ERROR","INACTIVATE_IN_PROGRESS","INACTIVE","TRAINING_COMPLETE","TRAINING_IN_PROGRESS"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$FD_map = @{
    "DataSource"=@("New-FDVariable")
    "DataType"=@("New-FDVariable")
    "InputConfiguration_Format"=@("Write-FDExternalModel")
    "Language"=@("New-FDRule","Update-FDRuleVersion")
    "ModelEndpointStatus"=@("Write-FDExternalModel")
    "ModelSource"=@("Write-FDExternalModel")
    "ModelType"=@("Get-FDModel","Get-FDModelVersion","Get-FDModelVersionList","New-FDModelVersion","Update-FDModelVersion","Write-FDModel")
    "OutputConfiguration_Format"=@("Write-FDExternalModel")
    "Status"=@("Update-FDDetectorVersionStatus","Update-FDModelVersion")
}

_awsArgumentCompleterRegistration $FD_Completers $FD_map

$FD_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.FD.$($commandName.Replace('-', ''))Cmdlet]"
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

$FD_SelectMap = @{
    "Select"=@("New-FDVariableBatch",
               "Get-FDVariableBatch",
               "New-FDDetectorVersion",
               "New-FDModelVersion",
               "New-FDRule",
               "New-FDVariable",
               "Remove-FDDetectorVersion",
               "Remove-FDEvent",
               "Get-FDDetectorVersionList",
               "Get-FDModelVersionList",
               "Get-FDDetector",
               "Get-FDDetectorVersion",
               "Get-FDExternalModel",
               "Get-FDModel",
               "Get-FDModelVersion",
               "Get-FDOutcome",
               "Get-FDPrediction",
               "Get-FDRule",
               "Get-FDVariable",
               "Write-FDDetector",
               "Write-FDExternalModel",
               "Write-FDModel",
               "Write-FDOutcome",
               "Update-FDDetectorVersion",
               "Update-FDDetectorVersionMetadata",
               "Update-FDDetectorVersionStatus",
               "Update-FDModelVersion",
               "Update-FDRuleMetadata",
               "Update-FDRuleVersion",
               "Update-FDVariable")
}

_awsArgumentCompleterRegistration $FD_SelectCompleters $FD_SelectMap

