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

# Argument completions for service AWS Auto Scaling


$AS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.AutoScaling.CapacityDistributionStrategy
        {
            ($_ -eq "New-ASAutoScalingGroup/AvailabilityZoneDistribution_CapacityDistributionStrategy") -Or
            ($_ -eq "Update-ASAutoScalingGroup/AvailabilityZoneDistribution_CapacityDistributionStrategy")
        }
        {
            $v = "balanced-best-effort","balanced-only"
            break
        }

        # Amazon.AutoScaling.InstanceMetadataEndpointState
        "New-ASLaunchConfiguration/MetadataOptions_HttpEndpoint"
        {
            $v = "disabled","enabled"
            break
        }

        # Amazon.AutoScaling.InstanceMetadataHttpTokensState
        "New-ASLaunchConfiguration/MetadataOptions_HttpToken"
        {
            $v = "optional","required"
            break
        }

        # Amazon.AutoScaling.MetricStatistic
        "Write-ASScalingPolicy/CustomizedMetricSpecification_Statistic"
        {
            $v = "Average","Maximum","Minimum","SampleCount","Sum"
            break
        }

        # Amazon.AutoScaling.MetricType
        "Write-ASScalingPolicy/PredefinedMetricSpecification_PredefinedMetricType"
        {
            $v = "ALBRequestCountPerTarget","ASGAverageCPUUtilization","ASGAverageNetworkIn","ASGAverageNetworkOut"
            break
        }

        # Amazon.AutoScaling.PredictiveScalingMaxCapacityBreachBehavior
        "Write-ASScalingPolicy/PredictiveScalingConfiguration_MaxCapacityBreachBehavior"
        {
            $v = "HonorMaxCapacity","IncreaseMaxCapacity"
            break
        }

        # Amazon.AutoScaling.PredictiveScalingMode
        "Write-ASScalingPolicy/PredictiveScalingConfiguration_Mode"
        {
            $v = "ForecastAndScale","ForecastOnly"
            break
        }

        # Amazon.AutoScaling.RefreshStrategy
        "Start-ASInstanceRefresh/Strategy"
        {
            $v = "Rolling"
            break
        }

        # Amazon.AutoScaling.ScaleInProtectedInstances
        "Start-ASInstanceRefresh/Preferences_ScaleInProtectedInstance"
        {
            $v = "Ignore","Refresh","Wait"
            break
        }

        # Amazon.AutoScaling.StandbyInstances
        "Start-ASInstanceRefresh/Preferences_StandbyInstance"
        {
            $v = "Ignore","Terminate","Wait"
            break
        }

        # Amazon.AutoScaling.WarmPoolState
        "Write-ASWarmPool/PoolState"
        {
            $v = "Hibernated","Running","Stopped"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$AS_map = @{
    "AvailabilityZoneDistribution_CapacityDistributionStrategy"=@("New-ASAutoScalingGroup","Update-ASAutoScalingGroup")
    "CustomizedMetricSpecification_Statistic"=@("Write-ASScalingPolicy")
    "MetadataOptions_HttpEndpoint"=@("New-ASLaunchConfiguration")
    "MetadataOptions_HttpToken"=@("New-ASLaunchConfiguration")
    "PoolState"=@("Write-ASWarmPool")
    "PredefinedMetricSpecification_PredefinedMetricType"=@("Write-ASScalingPolicy")
    "PredictiveScalingConfiguration_MaxCapacityBreachBehavior"=@("Write-ASScalingPolicy")
    "PredictiveScalingConfiguration_Mode"=@("Write-ASScalingPolicy")
    "Preferences_ScaleInProtectedInstance"=@("Start-ASInstanceRefresh")
    "Preferences_StandbyInstance"=@("Start-ASInstanceRefresh")
    "Strategy"=@("Start-ASInstanceRefresh")
}

_awsArgumentCompleterRegistration $AS_Completers $AS_map

$AS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.AS.$($commandName.Replace('-', ''))Cmdlet]"
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

$AS_SelectMap = @{
    "Select"=@("Mount-ASInstance",
               "Add-ASLoadBalancer",
               "Add-ASLoadBalancerTargetGroup",
               "Add-ASTrafficSource",
               "Remove-ASScheduledActionBatch",
               "Set-ASScheduledUpdateGroupActionBatch",
               "Stop-ASInstanceRefresh",
               "Complete-ASLifecycleAction",
               "New-ASAutoScalingGroup",
               "New-ASLaunchConfiguration",
               "Set-ASTag",
               "Remove-ASAutoScalingGroup",
               "Remove-ASLaunchConfiguration",
               "Remove-ASLifecycleHook",
               "Remove-ASNotificationConfiguration",
               "Remove-ASPolicy",
               "Remove-ASScheduledAction",
               "Remove-ASTag",
               "Remove-ASWarmPool",
               "Get-ASAccountLimit",
               "Get-ASAdjustmentType",
               "Get-ASAutoScalingGroup",
               "Get-ASAutoScalingInstance",
               "Get-ASAutoScalingNotificationType",
               "Get-ASInstanceRefresh",
               "Get-ASLaunchConfiguration",
               "Get-ASLifecycleHook",
               "Get-ASLifecycleHookType",
               "Get-ASLoadBalancer",
               "Get-ASLoadBalancerTargetGroup",
               "Get-ASMetricCollectionType",
               "Get-ASNotificationConfiguration",
               "Get-ASPolicy",
               "Get-ASScalingActivity",
               "Get-ASScalingProcessType",
               "Get-ASScheduledAction",
               "Get-ASTag",
               "Get-ASTerminationPolicyType",
               "Get-ASTrafficSource",
               "Get-ASWarmPool",
               "Dismount-ASInstance",
               "Dismount-ASLoadBalancer",
               "Dismount-ASLoadBalancerTargetGroup",
               "Dismount-ASTrafficSource",
               "Disable-ASMetricsCollection",
               "Enable-ASMetricsCollection",
               "Enter-ASStandby",
               "Start-ASPolicy",
               "Exit-ASStandby",
               "Get-ASPredictiveScalingForecast",
               "Write-ASLifecycleHook",
               "Write-ASNotificationConfiguration",
               "Write-ASScalingPolicy",
               "Write-ASScheduledUpdateGroupAction",
               "Write-ASWarmPool",
               "Write-ASLifecycleActionHeartbeat",
               "Resume-ASProcess",
               "Undo-ASInstanceRefresh",
               "Set-ASDesiredCapacity",
               "Set-ASInstanceHealth",
               "Set-ASInstanceProtection",
               "Start-ASInstanceRefresh",
               "Suspend-ASProcess",
               "Stop-ASInstanceInAutoScalingGroup",
               "Update-ASAutoScalingGroup")
}

_awsArgumentCompleterRegistration $AS_SelectCompleters $AS_SelectMap

