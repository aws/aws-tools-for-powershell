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

# Argument completions for service Amazon GameLift Service


$GML_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.GameLift.AcceptanceType
        "Confirm-GMLMatch/AcceptanceType"
        {
            $v = "ACCEPT","REJECT"
            break
        }

        # Amazon.GameLift.BackfillMode
        {
            ($_ -eq "New-GMLMatchmakingConfiguration/BackfillMode") -Or
            ($_ -eq "Update-GMLMatchmakingConfiguration/BackfillMode")
        }
        {
            $v = "AUTOMATIC","MANUAL"
            break
        }

        # Amazon.GameLift.BuildStatus
        "Get-GMLBuild/Status"
        {
            $v = "FAILED","INITIALIZED","READY"
            break
        }

        # Amazon.GameLift.CertificateType
        "New-GMLFleet/CertificateConfiguration_CertificateType"
        {
            $v = "DISABLED","GENERATED"
            break
        }

        # Amazon.GameLift.ComparisonOperatorType
        "Write-GMLScalingPolicy/ComparisonOperator"
        {
            $v = "GreaterThanOrEqualToThreshold","GreaterThanThreshold","LessThanOrEqualToThreshold","LessThanThreshold"
            break
        }

        # Amazon.GameLift.EC2InstanceType
        {
            ($_ -eq "Get-GMLEC2InstanceLimit/EC2InstanceType") -Or
            ($_ -eq "New-GMLFleet/EC2InstanceType")
        }
        {
            $v = "c3.2xlarge","c3.4xlarge","c3.8xlarge","c3.large","c3.xlarge","c4.2xlarge","c4.4xlarge","c4.8xlarge","c4.large","c4.xlarge","c5.12xlarge","c5.18xlarge","c5.24xlarge","c5.2xlarge","c5.4xlarge","c5.9xlarge","c5.large","c5.xlarge","m3.2xlarge","m3.large","m3.medium","m3.xlarge","m4.10xlarge","m4.2xlarge","m4.4xlarge","m4.large","m4.xlarge","m5.12xlarge","m5.16xlarge","m5.24xlarge","m5.2xlarge","m5.4xlarge","m5.8xlarge","m5.large","m5.xlarge","r3.2xlarge","r3.4xlarge","r3.8xlarge","r3.large","r3.xlarge","r4.16xlarge","r4.2xlarge","r4.4xlarge","r4.8xlarge","r4.large","r4.xlarge","r5.12xlarge","r5.16xlarge","r5.24xlarge","r5.2xlarge","r5.4xlarge","r5.8xlarge","r5.large","r5.xlarge","t2.large","t2.medium","t2.micro","t2.small"
            break
        }

        # Amazon.GameLift.FleetType
        "New-GMLFleet/FleetType"
        {
            $v = "ON_DEMAND","SPOT"
            break
        }

        # Amazon.GameLift.MetricName
        "Write-GMLScalingPolicy/MetricName"
        {
            $v = "ActivatingGameSessions","ActiveGameSessions","ActiveInstances","AvailableGameSessions","AvailablePlayerSessions","CurrentPlayerSessions","IdleInstances","PercentAvailableGameSessions","PercentIdleInstances","QueueDepth","WaitTime"
            break
        }

        # Amazon.GameLift.OperatingSystem
        "New-GMLBuild/OperatingSystem"
        {
            $v = "AMAZON_LINUX","AMAZON_LINUX_2","WINDOWS_2012"
            break
        }

        # Amazon.GameLift.PlayerSessionCreationPolicy
        "Update-GMLGameSession/PlayerSessionCreationPolicy"
        {
            $v = "ACCEPT_ALL","DENY_ALL"
            break
        }

        # Amazon.GameLift.PolicyType
        "Write-GMLScalingPolicy/PolicyType"
        {
            $v = "RuleBased","TargetBased"
            break
        }

        # Amazon.GameLift.ProtectionPolicy
        {
            ($_ -eq "New-GMLFleet/NewGameSessionProtectionPolicy") -Or
            ($_ -eq "Update-GMLFleetAttribute/NewGameSessionProtectionPolicy") -Or
            ($_ -eq "Update-GMLGameSession/ProtectionPolicy")
        }
        {
            $v = "FullProtection","NoProtection"
            break
        }

        # Amazon.GameLift.RoutingStrategyType
        {
            ($_ -eq "New-GMLAlias/RoutingStrategy_Type") -Or
            ($_ -eq "Update-GMLAlias/RoutingStrategy_Type") -Or
            ($_ -eq "Get-GMLAlias/RoutingStrategyType")
        }
        {
            $v = "SIMPLE","TERMINAL"
            break
        }

        # Amazon.GameLift.ScalingAdjustmentType
        "Write-GMLScalingPolicy/ScalingAdjustmentType"
        {
            $v = "ChangeInCapacity","ExactCapacity","PercentChangeInCapacity"
            break
        }

        # Amazon.GameLift.ScalingStatusType
        "Get-GMLScalingPolicy/StatusFilter"
        {
            $v = "ACTIVE","DELETED","DELETE_REQUESTED","DELETING","ERROR","UPDATE_REQUESTED","UPDATING"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$GML_map = @{
    "AcceptanceType"=@("Confirm-GMLMatch")
    "BackfillMode"=@("New-GMLMatchmakingConfiguration","Update-GMLMatchmakingConfiguration")
    "CertificateConfiguration_CertificateType"=@("New-GMLFleet")
    "ComparisonOperator"=@("Write-GMLScalingPolicy")
    "EC2InstanceType"=@("Get-GMLEC2InstanceLimit","New-GMLFleet")
    "FleetType"=@("New-GMLFleet")
    "MetricName"=@("Write-GMLScalingPolicy")
    "NewGameSessionProtectionPolicy"=@("New-GMLFleet","Update-GMLFleetAttribute")
    "OperatingSystem"=@("New-GMLBuild")
    "PlayerSessionCreationPolicy"=@("Update-GMLGameSession")
    "PolicyType"=@("Write-GMLScalingPolicy")
    "ProtectionPolicy"=@("Update-GMLGameSession")
    "RoutingStrategy_Type"=@("New-GMLAlias","Update-GMLAlias")
    "RoutingStrategyType"=@("Get-GMLAlias")
    "ScalingAdjustmentType"=@("Write-GMLScalingPolicy")
    "Status"=@("Get-GMLBuild")
    "StatusFilter"=@("Get-GMLScalingPolicy")
}

_awsArgumentCompleterRegistration $GML_Completers $GML_map

$GML_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.GML.$($commandName.Replace('-', ''))Cmdlet]"
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

$GML_SelectMap = @{
    "Select"=@("Confirm-GMLMatch",
               "New-GMLAlias",
               "New-GMLBuild",
               "New-GMLFleet",
               "New-GMLGameSession",
               "New-GMLGameSessionQueue",
               "New-GMLMatchmakingConfiguration",
               "New-GMLMatchmakingRuleSet",
               "New-GMLPlayerSession",
               "New-GMLScript",
               "New-GMLVpcPeeringAuthorization",
               "New-GMLVpcPeeringConnection",
               "Remove-GMLAlias",
               "Remove-GMLBuild",
               "Remove-GMLFleet",
               "Remove-GMLGameSessionQueue",
               "Remove-GMLMatchmakingConfiguration",
               "Remove-GMLMatchmakingRuleSet",
               "Remove-GMLScalingPolicy",
               "Remove-GMLScript",
               "Remove-GMLVpcPeeringAuthorization",
               "Remove-GMLVpcPeeringConnection",
               "Get-GMLAliasDetail",
               "Get-GMLBuildDetail",
               "Get-GMLEC2InstanceLimit",
               "Get-GMLFleetAttribute",
               "Get-GMLFleetCapacity",
               "Get-GMLFleetEvent",
               "Get-GMLFleetPortSetting",
               "Get-GMLFleetUtilization",
               "Get-GMLGameSessionDetail",
               "Get-GMLGameSessionPlacement",
               "Get-GMLGameSessionQueue",
               "Get-GMLGameSession",
               "Get-GMLInstance",
               "Get-GMLMatchmaking",
               "Get-GMLMatchmakingConfiguration",
               "Get-GMLMatchmakingRuleSet",
               "Get-GMLPlayerSession",
               "Get-GMLRuntimeConfiguration",
               "Get-GMLScalingPolicy",
               "Get-GMLScript",
               "Get-GMLVpcPeeringAuthorization",
               "Get-GMLVpcPeeringConnection",
               "Get-GMLGameSessionLogUrl",
               "Get-GMLInstanceAccess",
               "Get-GMLAlias",
               "Get-GMLBuild",
               "Get-GMLFleet",
               "Get-GMLScriptList",
               "Get-GMLResourceTag",
               "Write-GMLScalingPolicy",
               "Request-GMLUploadCredential",
               "Resolve-GMLAlias",
               "Find-GMLGameSession",
               "Start-GMLFleetAction",
               "Start-GMLGameSessionPlacement",
               "Start-GMLMatchBackfill",
               "Start-GMLMatchmaking",
               "Stop-GMLFleetAction",
               "Stop-GMLGameSessionPlacement",
               "Stop-GMLMatchmaking",
               "Add-GMLResourceTag",
               "Remove-GMLResourceTag",
               "Update-GMLAlias",
               "Update-GMLBuild",
               "Update-GMLFleetAttribute",
               "Update-GMLFleetCapacity",
               "Update-GMLFleetPortSetting",
               "Update-GMLGameSession",
               "Update-GMLGameSessionQueue",
               "Update-GMLMatchmakingConfiguration",
               "Update-GMLRuntimeConfiguration",
               "Update-GMLScript",
               "Test-GMLMatchmakingRuleSetValidity")
}

_awsArgumentCompleterRegistration $GML_SelectCompleters $GML_SelectMap

