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

# Argument completions for service AWS CodePipeline


$CP_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CodePipeline.ActionCategory
        {
            ($_ -eq "Update-CPActionType/ActionType_Id_Category") -Or
            ($_ -eq "Get-CPActionableJobList/ActionTypeId_Category") -Or
            ($_ -eq "Get-CPActionableThirdPartyJobList/ActionTypeId_Category") -Or
            ($_ -eq "Get-CPActionTypeDeclaration/Category") -Or
            ($_ -eq "New-CPCustomActionType/Category") -Or
            ($_ -eq "Remove-CPCustomActionType/Category")
        }
        {
            $v = "Approval","Build","Deploy","Invoke","Source","Test"
            break
        }

        # Amazon.CodePipeline.ActionOwner
        {
            ($_ -eq "Get-CPActionType/ActionOwnerFilter") -Or
            ($_ -eq "Get-CPActionableJobList/ActionTypeId_Owner") -Or
            ($_ -eq "Get-CPActionableThirdPartyJobList/ActionTypeId_Owner")
        }
        {
            $v = "AWS","Custom","ThirdParty"
            break
        }

        # Amazon.CodePipeline.ApprovalStatus
        "Write-CPApprovalResult/Result_Status"
        {
            $v = "Approved","Rejected"
            break
        }

        # Amazon.CodePipeline.ExecutorType
        "Update-CPActionType/ActionType_Executor_Type"
        {
            $v = "JobWorker","Lambda"
            break
        }

        # Amazon.CodePipeline.FailureType
        {
            ($_ -eq "Write-CPJobFailureResult/FailureDetails_Type") -Or
            ($_ -eq "Write-CPThirdPartyJobFailureResult/FailureDetails_Type")
        }
        {
            $v = "ConfigurationError","JobFailed","PermissionError","RevisionOutOfSync","RevisionUnavailable","SystemUnavailable"
            break
        }

        # Amazon.CodePipeline.StageRetryMode
        "Redo-CPStageExecution/RetryMode"
        {
            $v = "ALL_ACTIONS","FAILED_ACTIONS"
            break
        }

        # Amazon.CodePipeline.StageTransitionType
        {
            ($_ -eq "Disable-CPStageTransition/TransitionType") -Or
            ($_ -eq "Enable-CPStageTransition/TransitionType")
        }
        {
            $v = "Inbound","Outbound"
            break
        }

        # Amazon.CodePipeline.StartTimeRange
        "Get-CPActionExecutionList/Filter_LatestInPipelineExecution_StartTimeRange"
        {
            $v = "All","Latest"
            break
        }

        # Amazon.CodePipeline.WebhookAuthenticationType
        "Write-CPWebhook/Webhook_Authentication"
        {
            $v = "GITHUB_HMAC","IP","UNAUTHENTICATED"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CP_map = @{
    "ActionOwnerFilter"=@("Get-CPActionType")
    "ActionType_Executor_Type"=@("Update-CPActionType")
    "ActionType_Id_Category"=@("Update-CPActionType")
    "ActionTypeId_Category"=@("Get-CPActionableJobList","Get-CPActionableThirdPartyJobList")
    "ActionTypeId_Owner"=@("Get-CPActionableJobList","Get-CPActionableThirdPartyJobList")
    "Category"=@("Get-CPActionTypeDeclaration","New-CPCustomActionType","Remove-CPCustomActionType")
    "FailureDetails_Type"=@("Write-CPJobFailureResult","Write-CPThirdPartyJobFailureResult")
    "Filter_LatestInPipelineExecution_StartTimeRange"=@("Get-CPActionExecutionList")
    "Result_Status"=@("Write-CPApprovalResult")
    "RetryMode"=@("Redo-CPStageExecution")
    "TransitionType"=@("Disable-CPStageTransition","Enable-CPStageTransition")
    "Webhook_Authentication"=@("Write-CPWebhook")
}

_awsArgumentCompleterRegistration $CP_Completers $CP_map

$CP_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CP.$($commandName.Replace('-', ''))Cmdlet]"
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

$CP_SelectMap = @{
    "Select"=@("Confirm-CPJob",
               "Confirm-CPThirdPartyJob",
               "New-CPCustomActionType",
               "New-CPPipeline",
               "Remove-CPCustomActionType",
               "Remove-CPPipeline",
               "Remove-CPWebhook",
               "Unregister-CPWebhookWithThirdParty",
               "Disable-CPStageTransition",
               "Enable-CPStageTransition",
               "Get-CPActionTypeDeclaration",
               "Get-CPJobDetail",
               "Get-CPPipeline",
               "Get-CPPipelineExecution",
               "Get-CPPipelineState",
               "Get-CPThirdPartyJobDetail",
               "Get-CPActionExecutionList",
               "Get-CPActionType",
               "Get-CPPipelineExecutionSummary",
               "Get-CPPipelineList",
               "Get-CPResourceTag",
               "Get-CPWebhookList",
               "Get-CPActionableJobList",
               "Get-CPActionableThirdPartyJobList",
               "Write-CPActionRevision",
               "Write-CPApprovalResult",
               "Write-CPJobFailureResult",
               "Write-CPJobSuccessResult",
               "Write-CPThirdPartyJobFailureResult",
               "Write-CPThirdPartyJobSuccessResult",
               "Write-CPWebhook",
               "Register-CPWebhookWithThirdParty",
               "Redo-CPStageExecution",
               "Start-CPPipelineExecution",
               "Stop-CPPipelineExecution",
               "Add-CPResourceTag",
               "Remove-CPResourceTag",
               "Update-CPActionType",
               "Update-CPPipeline")
}

_awsArgumentCompleterRegistration $CP_SelectCompleters $CP_SelectMap

