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

# Argument completions for service Amazon EventBridge Pipes


$PIPES_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Pipes.AssignPublicIp
        {
            ($_ -eq "New-PIPESPipe/TargetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp") -Or
            ($_ -eq "Update-PIPESPipe/TargetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.Pipes.DynamoDBStreamStartPosition
        "New-PIPESPipe/SourceParameters_DynamoDBStreamParameters_StartingPosition"
        {
            $v = "LATEST","TRIM_HORIZON"
            break
        }

        # Amazon.Pipes.KinesisStreamStartPosition
        "New-PIPESPipe/SourceParameters_KinesisStreamParameters_StartingPosition"
        {
            $v = "AT_TIMESTAMP","LATEST","TRIM_HORIZON"
            break
        }

        # Amazon.Pipes.LaunchType
        {
            ($_ -eq "New-PIPESPipe/TargetParameters_EcsTaskParameters_LaunchType") -Or
            ($_ -eq "Update-PIPESPipe/TargetParameters_EcsTaskParameters_LaunchType")
        }
        {
            $v = "EC2","EXTERNAL","FARGATE"
            break
        }

        # Amazon.Pipes.MSKStartPosition
        "New-PIPESPipe/SourceParameters_ManagedStreamingKafkaParameters_StartingPosition"
        {
            $v = "LATEST","TRIM_HORIZON"
            break
        }

        # Amazon.Pipes.OnPartialBatchItemFailureStreams
        {
            ($_ -eq "New-PIPESPipe/SourceParameters_DynamoDBStreamParameters_OnPartialBatchItemFailure") -Or
            ($_ -eq "Update-PIPESPipe/SourceParameters_DynamoDBStreamParameters_OnPartialBatchItemFailure") -Or
            ($_ -eq "New-PIPESPipe/SourceParameters_KinesisStreamParameters_OnPartialBatchItemFailure") -Or
            ($_ -eq "Update-PIPESPipe/SourceParameters_KinesisStreamParameters_OnPartialBatchItemFailure")
        }
        {
            $v = "AUTOMATIC_BISECT"
            break
        }

        # Amazon.Pipes.PipeState
        "Get-PIPESPipeList/CurrentState"
        {
            $v = "CREATE_FAILED","CREATING","DELETING","RUNNING","STARTING","START_FAILED","STOPPED","STOPPING","STOP_FAILED","UPDATE_FAILED","UPDATING"
            break
        }

        # Amazon.Pipes.PipeTargetInvocationType
        {
            ($_ -eq "New-PIPESPipe/TargetParameters_LambdaFunctionParameters_InvocationType") -Or
            ($_ -eq "Update-PIPESPipe/TargetParameters_LambdaFunctionParameters_InvocationType") -Or
            ($_ -eq "New-PIPESPipe/TargetParameters_StepFunctionStateMachineParameters_InvocationType") -Or
            ($_ -eq "Update-PIPESPipe/TargetParameters_StepFunctionStateMachineParameters_InvocationType")
        }
        {
            $v = "FIRE_AND_FORGET","REQUEST_RESPONSE"
            break
        }

        # Amazon.Pipes.PropagateTags
        {
            ($_ -eq "New-PIPESPipe/TargetParameters_EcsTaskParameters_PropagateTags") -Or
            ($_ -eq "Update-PIPESPipe/TargetParameters_EcsTaskParameters_PropagateTags")
        }
        {
            $v = "TASK_DEFINITION"
            break
        }

        # Amazon.Pipes.RequestedPipeState
        {
            ($_ -eq "Get-PIPESPipeList/DesiredState") -Or
            ($_ -eq "New-PIPESPipe/DesiredState") -Or
            ($_ -eq "Update-PIPESPipe/DesiredState")
        }
        {
            $v = "RUNNING","STOPPED"
            break
        }

        # Amazon.Pipes.SelfManagedKafkaStartPosition
        "New-PIPESPipe/SourceParameters_SelfManagedKafkaParameters_StartingPosition"
        {
            $v = "LATEST","TRIM_HORIZON"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$PIPES_map = @{
    "CurrentState"=@("Get-PIPESPipeList")
    "DesiredState"=@("Get-PIPESPipeList","New-PIPESPipe","Update-PIPESPipe")
    "SourceParameters_DynamoDBStreamParameters_OnPartialBatchItemFailure"=@("New-PIPESPipe","Update-PIPESPipe")
    "SourceParameters_DynamoDBStreamParameters_StartingPosition"=@("New-PIPESPipe")
    "SourceParameters_KinesisStreamParameters_OnPartialBatchItemFailure"=@("New-PIPESPipe","Update-PIPESPipe")
    "SourceParameters_KinesisStreamParameters_StartingPosition"=@("New-PIPESPipe")
    "SourceParameters_ManagedStreamingKafkaParameters_StartingPosition"=@("New-PIPESPipe")
    "SourceParameters_SelfManagedKafkaParameters_StartingPosition"=@("New-PIPESPipe")
    "TargetParameters_EcsTaskParameters_LaunchType"=@("New-PIPESPipe","Update-PIPESPipe")
    "TargetParameters_EcsTaskParameters_NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp"=@("New-PIPESPipe","Update-PIPESPipe")
    "TargetParameters_EcsTaskParameters_PropagateTags"=@("New-PIPESPipe","Update-PIPESPipe")
    "TargetParameters_LambdaFunctionParameters_InvocationType"=@("New-PIPESPipe","Update-PIPESPipe")
    "TargetParameters_StepFunctionStateMachineParameters_InvocationType"=@("New-PIPESPipe","Update-PIPESPipe")
}

_awsArgumentCompleterRegistration $PIPES_Completers $PIPES_map

$PIPES_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.PIPES.$($commandName.Replace('-', ''))Cmdlet]"
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

$PIPES_SelectMap = @{
    "Select"=@("New-PIPESPipe",
               "Remove-PIPESPipe",
               "Get-PIPESPipe",
               "Get-PIPESPipeList",
               "Get-PIPESResourceTag",
               "Start-PIPESPipe",
               "Stop-PIPESPipe",
               "Add-PIPESResourceTag",
               "Remove-PIPESResourceTag",
               "Update-PIPESPipe")
}

_awsArgumentCompleterRegistration $PIPES_SelectCompleters $PIPES_SelectMap

