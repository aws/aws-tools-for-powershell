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

# Argument completions for service AWS Step Functions


$SFN_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.StepFunctions.EncryptionType
        {
            ($_ -eq "New-SFNActivity/EncryptionConfiguration_Type") -Or
            ($_ -eq "New-SFNStateMachine/EncryptionConfiguration_Type") -Or
            ($_ -eq "Update-SFNStateMachine/EncryptionConfiguration_Type")
        }
        {
            $v = "AWS_OWNED_KEY","CUSTOMER_MANAGED_KMS_KEY"
            break
        }

        # Amazon.StepFunctions.ExecutionRedriveFilter
        "Get-SFNExecutionList/RedriveFilter"
        {
            $v = "NOT_REDRIVEN","REDRIVEN"
            break
        }

        # Amazon.StepFunctions.ExecutionStatus
        "Get-SFNExecutionList/StatusFilter"
        {
            $v = "ABORTED","FAILED","PENDING_REDRIVE","RUNNING","SUCCEEDED","TIMED_OUT"
            break
        }

        # Amazon.StepFunctions.IncludedData
        {
            ($_ -eq "Get-SFNExecution/IncludedData") -Or
            ($_ -eq "Get-SFNStateMachine/IncludedData") -Or
            ($_ -eq "Get-SFNStateMachineForExecution/IncludedData") -Or
            ($_ -eq "Start-SFNSyncExecution/IncludedData")
        }
        {
            $v = "ALL_DATA","METADATA_ONLY"
            break
        }

        # Amazon.StepFunctions.InspectionLevel
        "Test-SFNState/InspectionLevel"
        {
            $v = "DEBUG","INFO","TRACE"
            break
        }

        # Amazon.StepFunctions.LogLevel
        {
            ($_ -eq "New-SFNStateMachine/LoggingConfiguration_Level") -Or
            ($_ -eq "Update-SFNStateMachine/LoggingConfiguration_Level")
        }
        {
            $v = "ALL","ERROR","FATAL","OFF"
            break
        }

        # Amazon.StepFunctions.StateMachineType
        {
            ($_ -eq "New-SFNStateMachine/Type") -Or
            ($_ -eq "Test-SFNStateMachineDefinitionValidation/Type")
        }
        {
            $v = "EXPRESS","STANDARD"
            break
        }

        # Amazon.StepFunctions.ValidateStateMachineDefinitionSeverity
        "Test-SFNStateMachineDefinitionValidation/Severity"
        {
            $v = "ERROR","WARNING"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$SFN_map = @{
    "EncryptionConfiguration_Type"=@("New-SFNActivity","New-SFNStateMachine","Update-SFNStateMachine")
    "IncludedData"=@("Get-SFNExecution","Get-SFNStateMachine","Get-SFNStateMachineForExecution","Start-SFNSyncExecution")
    "InspectionLevel"=@("Test-SFNState")
    "LoggingConfiguration_Level"=@("New-SFNStateMachine","Update-SFNStateMachine")
    "RedriveFilter"=@("Get-SFNExecutionList")
    "Severity"=@("Test-SFNStateMachineDefinitionValidation")
    "StatusFilter"=@("Get-SFNExecutionList")
    "Type"=@("New-SFNStateMachine","Test-SFNStateMachineDefinitionValidation")
}

_awsArgumentCompleterRegistration $SFN_Completers $SFN_map

$SFN_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.SFN.$($commandName.Replace('-', ''))Cmdlet]"
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

$SFN_SelectMap = @{
    "Select"=@("New-SFNActivity",
               "New-SFNStateMachine",
               "New-SFNStateMachineAlias",
               "Remove-SFNActivity",
               "Remove-SFNStateMachine",
               "Remove-SFNStateMachineAlias",
               "Remove-SFNStateMachineVersion",
               "Get-SFNActivity",
               "Get-SFNExecution",
               "Get-SFNMapRun",
               "Get-SFNStateMachine",
               "Get-SFNStateMachineAlias",
               "Get-SFNStateMachineForExecution",
               "Get-SFNActivityTask",
               "Get-SFNExecutionHistory",
               "Get-SFNActivityList",
               "Get-SFNExecutionList",
               "Get-SFNMapRunList",
               "Get-SFNStateMachineAliasList",
               "Get-SFNStateMachineList",
               "Get-SFNStateMachineVersionList",
               "Get-SFNResourceTag",
               "Publish-SFNStateMachineVersion",
               "Restart-SFNExecution",
               "Send-SFNTaskFailure",
               "Send-SFNTaskHeartbeat",
               "Send-SFNTaskSuccess",
               "Start-SFNExecution",
               "Start-SFNSyncExecution",
               "Stop-SFNExecution",
               "Add-SFNResourceTag",
               "Test-SFNState",
               "Remove-SFNResourceTag",
               "Update-SFNMapRun",
               "Update-SFNStateMachine",
               "Update-SFNStateMachineAlias",
               "Test-SFNStateMachineDefinitionValidation")
}

_awsArgumentCompleterRegistration $SFN_SelectCompleters $SFN_SelectMap

