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

# Argument completions for service AWS Migration Hub Orchestrator


$MHO_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.MigrationHubOrchestrator.MigrationWorkflowStatusEnum
        "Get-MHOWorkflowList/Status"
        {
            $v = "COMPLETED","CREATING","CREATION_FAILED","DELETED","DELETING","DELETION_FAILED","IN_PROGRESS","NOT_STARTED","PAUSED","PAUSING","PAUSING_FAILED","STARTING","USER_ATTENTION_REQUIRED","WORKFLOW_FAILED"
            break
        }

        # Amazon.MigrationHubOrchestrator.RunEnvironment
        {
            ($_ -eq "New-MHOWorkflowStep/WorkflowStepAutomationConfiguration_RunEnvironment") -Or
            ($_ -eq "Update-MHOWorkflowStep/WorkflowStepAutomationConfiguration_RunEnvironment")
        }
        {
            $v = "AWS","ONPREMISE"
            break
        }

        # Amazon.MigrationHubOrchestrator.StepActionType
        {
            ($_ -eq "New-MHOWorkflowStep/StepActionType") -Or
            ($_ -eq "Update-MHOWorkflowStep/StepActionType")
        }
        {
            $v = "AUTOMATED","MANUAL"
            break
        }

        # Amazon.MigrationHubOrchestrator.StepStatus
        "Update-MHOWorkflowStep/Status"
        {
            $v = "AWAITING_DEPENDENCIES","COMPLETED","FAILED","IN_PROGRESS","PAUSED","READY","SKIPPED","USER_ATTENTION_REQUIRED"
            break
        }

        # Amazon.MigrationHubOrchestrator.TargetType
        {
            ($_ -eq "New-MHOWorkflowStep/WorkflowStepAutomationConfiguration_TargetType") -Or
            ($_ -eq "Update-MHOWorkflowStep/WorkflowStepAutomationConfiguration_TargetType")
        }
        {
            $v = "ALL","NONE","SINGLE"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$MHO_map = @{
    "Status"=@("Get-MHOWorkflowList","Update-MHOWorkflowStep")
    "StepActionType"=@("New-MHOWorkflowStep","Update-MHOWorkflowStep")
    "WorkflowStepAutomationConfiguration_RunEnvironment"=@("New-MHOWorkflowStep","Update-MHOWorkflowStep")
    "WorkflowStepAutomationConfiguration_TargetType"=@("New-MHOWorkflowStep","Update-MHOWorkflowStep")
}

_awsArgumentCompleterRegistration $MHO_Completers $MHO_map

$MHO_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.MHO.$($commandName.Replace('-', ''))Cmdlet]"
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

$MHO_SelectMap = @{
    "Select"=@("New-MHOTemplate",
               "New-MHOWorkflow",
               "New-MHOWorkflowStep",
               "New-MHOWorkflowStepGroup",
               "Remove-MHOTemplate",
               "Remove-MHOWorkflow",
               "Remove-MHOWorkflowStep",
               "Remove-MHOWorkflowStepGroup",
               "Get-MHOTemplate",
               "Get-MHOTemplateStep",
               "Get-MHOTemplateStepGroup",
               "Get-MHOWorkflow",
               "Get-MHOWorkflowStep",
               "Get-MHOWorkflowStepGroup",
               "Get-MHOPluginList",
               "Get-MHOResourceTag",
               "Get-MHOTemplateList",
               "Get-MHOTemplateStepGroupList",
               "Get-MHOTemplateStepList",
               "Get-MHOWorkflowList",
               "Get-MHOWorkflowStepGroupList",
               "Get-MHOWorkflowStepList",
               "Start-MHOWorkflowStep",
               "Start-MHOWorkflow",
               "Stop-MHOWorkflow",
               "Add-MHOResourceTag",
               "Remove-MHOResourceTag",
               "Update-MHOTemplate",
               "Update-MHOWorkflow",
               "Update-MHOWorkflowStep",
               "Update-MHOWorkflowStepGroup")
}

_awsArgumentCompleterRegistration $MHO_SelectCompleters $MHO_SelectMap

