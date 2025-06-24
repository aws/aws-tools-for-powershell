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

# Argument completions for service AWS Batch


$BAT_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Batch.AssignPublicIp
        "Register-BATJobDefinition/NetworkConfiguration_AssignPublicIp"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.Batch.CEState
        {
            ($_ -eq "New-BATComputeEnvironment/State") -Or
            ($_ -eq "Update-BATComputeEnvironment/State")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.Batch.CEType
        "New-BATComputeEnvironment/Type"
        {
            $v = "MANAGED","UNMANAGED"
            break
        }

        # Amazon.Batch.CRAllocationStrategy
        "New-BATComputeEnvironment/ComputeResources_AllocationStrategy"
        {
            $v = "BEST_FIT","BEST_FIT_PROGRESSIVE","SPOT_CAPACITY_OPTIMIZED","SPOT_PRICE_CAPACITY_OPTIMIZED"
            break
        }

        # Amazon.Batch.CRType
        {
            ($_ -eq "New-BATComputeEnvironment/ComputeResources_Type") -Or
            ($_ -eq "Update-BATComputeEnvironment/ComputeResources_Type")
        }
        {
            $v = "EC2","FARGATE","FARGATE_SPOT","SPOT"
            break
        }

        # Amazon.Batch.CRUpdateAllocationStrategy
        "Update-BATComputeEnvironment/ComputeResources_AllocationStrategy"
        {
            $v = "BEST_FIT_PROGRESSIVE","SPOT_CAPACITY_OPTIMIZED","SPOT_PRICE_CAPACITY_OPTIMIZED"
            break
        }

        # Amazon.Batch.JobDefinitionType
        "Register-BATJobDefinition/Type"
        {
            $v = "container","multinode"
            break
        }

        # Amazon.Batch.JobStatus
        "Get-BATJobList/JobStatus"
        {
            $v = "FAILED","PENDING","RUNNABLE","RUNNING","STARTING","SUBMITTED","SUCCEEDED"
            break
        }

        # Amazon.Batch.JQState
        {
            ($_ -eq "New-BATJobQueue/State") -Or
            ($_ -eq "Update-BATJobQueue/State")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.Batch.LogDriver
        "Register-BATJobDefinition/LogConfiguration_LogDriver"
        {
            $v = "awsfirelens","awslogs","fluentd","gelf","journald","json-file","splunk","syslog"
            break
        }

        # Amazon.Batch.UserdataType
        {
            ($_ -eq "New-BATComputeEnvironment/LaunchTemplate_UserdataType") -Or
            ($_ -eq "Update-BATComputeEnvironment/LaunchTemplate_UserdataType")
        }
        {
            $v = "EKS_BOOTSTRAP_SH","EKS_NODEADM"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$BAT_map = @{
    "ComputeResources_AllocationStrategy"=@("New-BATComputeEnvironment","Update-BATComputeEnvironment")
    "ComputeResources_Type"=@("New-BATComputeEnvironment","Update-BATComputeEnvironment")
    "JobStatus"=@("Get-BATJobList")
    "LaunchTemplate_UserdataType"=@("New-BATComputeEnvironment","Update-BATComputeEnvironment")
    "LogConfiguration_LogDriver"=@("Register-BATJobDefinition")
    "NetworkConfiguration_AssignPublicIp"=@("Register-BATJobDefinition")
    "State"=@("New-BATComputeEnvironment","New-BATJobQueue","Update-BATComputeEnvironment","Update-BATJobQueue")
    "Type"=@("New-BATComputeEnvironment","Register-BATJobDefinition")
}

_awsArgumentCompleterRegistration $BAT_Completers $BAT_map

$BAT_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.BAT.$($commandName.Replace('-', ''))Cmdlet]"
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

$BAT_SelectMap = @{
    "Select"=@("Stop-BATJob",
               "New-BATComputeEnvironment",
               "New-BATConsumableResource",
               "New-BATJobQueue",
               "New-BATSchedulingPolicy",
               "Remove-BATComputeEnvironment",
               "Remove-BATConsumableResource",
               "Remove-BATJobQueue",
               "Remove-BATSchedulingPolicy",
               "Unregister-BATJobDefinition",
               "Get-BATComputeEnvironment",
               "Get-BATConsumableResource",
               "Get-BATJobDefinition",
               "Get-BATJobQueue",
               "Get-BATJobDetail",
               "Get-BATSchedulingPolicy",
               "Get-BATJobQueueSnapshot",
               "Get-BATConsumableResourceList",
               "Get-BATJobList",
               "Get-BATJobsByConsumableResourceList",
               "Get-BATSchedulingPolicyList",
               "Get-BATResourceTag",
               "Register-BATJobDefinition",
               "Submit-BATJob",
               "Add-BATResourceTag",
               "Remove-BATJob",
               "Remove-BATResourceTag",
               "Update-BATComputeEnvironment",
               "Update-BATConsumableResource",
               "Update-BATJobQueue",
               "Update-BATSchedulingPolicy")
}

_awsArgumentCompleterRegistration $BAT_SelectCompleters $BAT_SelectMap

