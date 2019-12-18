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

# Argument completions for service Amazon EC2 Container Service


$ECS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ECS.AssignPublicIp
        {
            ($_ -eq "New-ECSService/NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp") -Or
            ($_ -eq "New-ECSTask/NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp") -Or
            ($_ -eq "New-ECSTaskSet/NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp") -Or
            ($_ -eq "Start-ECSTask/NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp") -Or
            ($_ -eq "Update-ECSService/NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.ECS.ContainerInstanceStatus
        {
            ($_ -eq "Get-ECSContainerInstanceList/Status") -Or
            ($_ -eq "Update-ECSContainerInstancesState/Status")
        }
        {
            $v = "ACTIVE","DEREGISTERING","DRAINING","REGISTERING","REGISTRATION_FAILED"
            break
        }

        # Amazon.ECS.DeploymentControllerType
        "New-ECSService/DeploymentController_Type"
        {
            $v = "CODE_DEPLOY","ECS","EXTERNAL"
            break
        }

        # Amazon.ECS.DesiredStatus
        "Get-ECSTaskList/DesiredStatus"
        {
            $v = "PENDING","RUNNING","STOPPED"
            break
        }

        # Amazon.ECS.IpcMode
        "Register-ECSTaskDefinition/IpcMode"
        {
            $v = "host","none","task"
            break
        }

        # Amazon.ECS.LaunchType
        {
            ($_ -eq "Get-ECSClusterService/LaunchType") -Or
            ($_ -eq "Get-ECSTaskList/LaunchType") -Or
            ($_ -eq "New-ECSService/LaunchType") -Or
            ($_ -eq "New-ECSTask/LaunchType") -Or
            ($_ -eq "New-ECSTaskSet/LaunchType")
        }
        {
            $v = "EC2","FARGATE"
            break
        }

        # Amazon.ECS.ManagedScalingStatus
        "New-ECSCapacityProvider/AutoScalingGroupProvider_ManagedScaling_Status"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.ECS.ManagedTerminationProtection
        "New-ECSCapacityProvider/AutoScalingGroupProvider_ManagedTerminationProtection"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.ECS.NetworkMode
        "Register-ECSTaskDefinition/NetworkMode"
        {
            $v = "awsvpc","bridge","host","none"
            break
        }

        # Amazon.ECS.PidMode
        "Register-ECSTaskDefinition/PidMode"
        {
            $v = "host","task"
            break
        }

        # Amazon.ECS.PropagateTags
        {
            ($_ -eq "New-ECSService/PropagateTags") -Or
            ($_ -eq "New-ECSTask/PropagateTags") -Or
            ($_ -eq "Start-ECSTask/PropagateTags")
        }
        {
            $v = "SERVICE","TASK_DEFINITION"
            break
        }

        # Amazon.ECS.ProxyConfigurationType
        "Register-ECSTaskDefinition/ProxyConfiguration_Type"
        {
            $v = "APPMESH"
            break
        }

        # Amazon.ECS.ScaleUnit
        {
            ($_ -eq "New-ECSTaskSet/Scale_Unit") -Or
            ($_ -eq "Update-ECSTaskSet/Scale_Unit")
        }
        {
            $v = "PERCENT"
            break
        }

        # Amazon.ECS.SchedulingStrategy
        {
            ($_ -eq "Get-ECSClusterService/SchedulingStrategy") -Or
            ($_ -eq "New-ECSService/SchedulingStrategy")
        }
        {
            $v = "DAEMON","REPLICA"
            break
        }

        # Amazon.ECS.SettingName
        {
            ($_ -eq "Get-ECSAccountSetting/Name") -Or
            ($_ -eq "Remove-ECSAccountSetting/Name") -Or
            ($_ -eq "Write-ECSAccountSetting/Name") -Or
            ($_ -eq "Write-ECSAccountSettingDefault/Name")
        }
        {
            $v = "awsvpcTrunking","containerInsights","containerInstanceLongArnFormat","serviceLongArnFormat","taskLongArnFormat"
            break
        }

        # Amazon.ECS.SortOrder
        "Get-ECSTaskDefinitionList/Sort"
        {
            $v = "ASC","DESC"
            break
        }

        # Amazon.ECS.TargetType
        "Get-ECSAttributeList/TargetType"
        {
            $v = "container-instance"
            break
        }

        # Amazon.ECS.TaskDefinitionFamilyStatus
        "Get-ECSTaskDefinitionFamilyList/Status"
        {
            $v = "ACTIVE","ALL","INACTIVE"
            break
        }

        # Amazon.ECS.TaskDefinitionStatus
        "Get-ECSTaskDefinitionList/Status"
        {
            $v = "ACTIVE","INACTIVE"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$ECS_map = @{
    "AutoScalingGroupProvider_ManagedScaling_Status"=@("New-ECSCapacityProvider")
    "AutoScalingGroupProvider_ManagedTerminationProtection"=@("New-ECSCapacityProvider")
    "DeploymentController_Type"=@("New-ECSService")
    "DesiredStatus"=@("Get-ECSTaskList")
    "IpcMode"=@("Register-ECSTaskDefinition")
    "LaunchType"=@("Get-ECSClusterService","Get-ECSTaskList","New-ECSService","New-ECSTask","New-ECSTaskSet")
    "Name"=@("Get-ECSAccountSetting","Remove-ECSAccountSetting","Write-ECSAccountSetting","Write-ECSAccountSettingDefault")
    "NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp"=@("New-ECSService","New-ECSTask","New-ECSTaskSet","Start-ECSTask","Update-ECSService")
    "NetworkMode"=@("Register-ECSTaskDefinition")
    "PidMode"=@("Register-ECSTaskDefinition")
    "PropagateTags"=@("New-ECSService","New-ECSTask","Start-ECSTask")
    "ProxyConfiguration_Type"=@("Register-ECSTaskDefinition")
    "Scale_Unit"=@("New-ECSTaskSet","Update-ECSTaskSet")
    "SchedulingStrategy"=@("Get-ECSClusterService","New-ECSService")
    "Sort"=@("Get-ECSTaskDefinitionList")
    "Status"=@("Get-ECSContainerInstanceList","Get-ECSTaskDefinitionFamilyList","Get-ECSTaskDefinitionList","Update-ECSContainerInstancesState")
    "TargetType"=@("Get-ECSAttributeList")
}

_awsArgumentCompleterRegistration $ECS_Completers $ECS_map

$ECS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.ECS.$($commandName.Replace('-', ''))Cmdlet]"
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

$ECS_SelectMap = @{
    "Select"=@("New-ECSCapacityProvider",
               "New-ECSCluster",
               "New-ECSService",
               "New-ECSTaskSet",
               "Remove-ECSAccountSetting",
               "Remove-ECSAttribute",
               "Remove-ECSCluster",
               "Remove-ECSService",
               "Remove-ECSTaskSet",
               "Unregister-ECSContainerInstance",
               "Unregister-ECSTaskDefinition",
               "Get-ECSCapacityProvider",
               "Get-ECSClusterDetail",
               "Get-ECSContainerInstanceDetail",
               "Get-ECSService",
               "Get-ECSTaskDefinitionDetail",
               "Get-ECSTaskDetail",
               "Get-ECSTaskSet",
               "Get-ECSAccountSetting",
               "Get-ECSAttributeList",
               "Get-ECSClusterList",
               "Get-ECSContainerInstanceList",
               "Get-ECSClusterService",
               "Get-ECSTagsForResource",
               "Get-ECSTaskDefinitionFamilyList",
               "Get-ECSTaskDefinitionList",
               "Get-ECSTaskList",
               "Write-ECSAccountSetting",
               "Write-ECSAccountSettingDefault",
               "Write-ECSAttribute",
               "Write-ECSClusterCapacityProvider",
               "Register-ECSTaskDefinition",
               "New-ECSTask",
               "Start-ECSTask",
               "Stop-ECSTask",
               "Submit-ECSAttachmentStateChange",
               "Add-ECSResourceTag",
               "Remove-ECSResourceTag",
               "Update-ECSClusterSetting",
               "Update-ECSContainerAgent",
               "Update-ECSContainerInstancesState",
               "Update-ECSService",
               "Update-ECSServicePrimaryTaskSet",
               "Update-ECSTaskSet")
}

_awsArgumentCompleterRegistration $ECS_SelectCompleters $ECS_SelectMap

