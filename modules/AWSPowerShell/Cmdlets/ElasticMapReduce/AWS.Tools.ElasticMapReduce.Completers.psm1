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

# Argument completions for service Amazon Elastic MapReduce


$EMR_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ElasticMapReduce.AuthMode
        "New-EMRStudio/AuthMode"
        {
            $v = "IAM","SSO"
            break
        }

        # Amazon.ElasticMapReduce.ComputeLimitsUnitType
        {
            ($_ -eq "Start-EMRJobFlow/ComputeLimits_UnitType") -Or
            ($_ -eq "Write-EMRManagedScalingPolicy/ComputeLimits_UnitType")
        }
        {
            $v = "InstanceFleetUnits","Instances","VCPU"
            break
        }

        # Amazon.ElasticMapReduce.ExecutionEngineType
        "Start-EMRNotebookExecution/ExecutionEngine_Type"
        {
            $v = "EMR"
            break
        }

        # Amazon.ElasticMapReduce.IdcUserAssignment
        "New-EMRStudio/IdcUserAssignment"
        {
            $v = "OPTIONAL","REQUIRED"
            break
        }

        # Amazon.ElasticMapReduce.IdentityType
        {
            ($_ -eq "Get-EMRStudioSessionMapping/IdentityType") -Or
            ($_ -eq "Get-EMRStudioSessionMappingList/IdentityType") -Or
            ($_ -eq "New-EMRStudioSessionMapping/IdentityType") -Or
            ($_ -eq "Remove-EMRStudioSessionMapping/IdentityType") -Or
            ($_ -eq "Update-EMRStudioSessionMapping/IdentityType")
        }
        {
            $v = "GROUP","USER"
            break
        }

        # Amazon.ElasticMapReduce.InstanceFleetType
        {
            ($_ -eq "Add-EMRInstanceFleet/InstanceFleet_InstanceFleetType") -Or
            ($_ -eq "Get-EMRInstanceList/InstanceFleetType")
        }
        {
            $v = "CORE","MASTER","TASK"
            break
        }

        # Amazon.ElasticMapReduce.NotebookExecutionStatus
        "Get-EMRNotebookExecutionList/Status"
        {
            $v = "FAILED","FAILING","FINISHED","FINISHING","RUNNING","STARTING","START_PENDING","STOPPED","STOPPING","STOP_PENDING"
            break
        }

        # Amazon.ElasticMapReduce.OnDemandCapacityReservationPreference
        "Add-EMRInstanceFleet/CapacityReservationOptions_CapacityReservationPreference"
        {
            $v = "none","open"
            break
        }

        # Amazon.ElasticMapReduce.OnDemandCapacityReservationUsageStrategy
        "Add-EMRInstanceFleet/CapacityReservationOptions_UsageStrategy"
        {
            $v = "use-capacity-reservations-first"
            break
        }

        # Amazon.ElasticMapReduce.OnDemandProvisioningAllocationStrategy
        "Add-EMRInstanceFleet/OnDemandSpecification_AllocationStrategy"
        {
            $v = "lowest-price","prioritized"
            break
        }

        # Amazon.ElasticMapReduce.OutputNotebookFormat
        "Start-EMRNotebookExecution/OutputNotebookFormat"
        {
            $v = "HTML"
            break
        }

        # Amazon.ElasticMapReduce.RepoUpgradeOnBoot
        "Start-EMRJobFlow/RepoUpgradeOnBoot"
        {
            $v = "NONE","SECURITY"
            break
        }

        # Amazon.ElasticMapReduce.ScaleDownBehavior
        "Start-EMRJobFlow/ScaleDownBehavior"
        {
            $v = "TERMINATE_AT_INSTANCE_HOUR","TERMINATE_AT_TASK_COMPLETION"
            break
        }

        # Amazon.ElasticMapReduce.SpotProvisioningAllocationStrategy
        "Add-EMRInstanceFleet/SpotSpecification_AllocationStrategy"
        {
            $v = "capacity-optimized","capacity-optimized-prioritized","diversified","lowest-price","price-capacity-optimized"
            break
        }

        # Amazon.ElasticMapReduce.SpotProvisioningTimeoutAction
        "Add-EMRInstanceFleet/SpotSpecification_TimeoutAction"
        {
            $v = "SWITCH_TO_ON_DEMAND","TERMINATE_CLUSTER"
            break
        }

        # Amazon.ElasticMapReduce.StepCancellationOption
        "Stop-EMRStep/StepCancellationOption"
        {
            $v = "SEND_INTERRUPT","TERMINATE_PROCESS"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$EMR_map = @{
    "AuthMode"=@("New-EMRStudio")
    "CapacityReservationOptions_CapacityReservationPreference"=@("Add-EMRInstanceFleet")
    "CapacityReservationOptions_UsageStrategy"=@("Add-EMRInstanceFleet")
    "ComputeLimits_UnitType"=@("Start-EMRJobFlow","Write-EMRManagedScalingPolicy")
    "ExecutionEngine_Type"=@("Start-EMRNotebookExecution")
    "IdcUserAssignment"=@("New-EMRStudio")
    "IdentityType"=@("Get-EMRStudioSessionMapping","Get-EMRStudioSessionMappingList","New-EMRStudioSessionMapping","Remove-EMRStudioSessionMapping","Update-EMRStudioSessionMapping")
    "InstanceFleet_InstanceFleetType"=@("Add-EMRInstanceFleet")
    "InstanceFleetType"=@("Get-EMRInstanceList")
    "OnDemandSpecification_AllocationStrategy"=@("Add-EMRInstanceFleet")
    "OutputNotebookFormat"=@("Start-EMRNotebookExecution")
    "RepoUpgradeOnBoot"=@("Start-EMRJobFlow")
    "ScaleDownBehavior"=@("Start-EMRJobFlow")
    "SpotSpecification_AllocationStrategy"=@("Add-EMRInstanceFleet")
    "SpotSpecification_TimeoutAction"=@("Add-EMRInstanceFleet")
    "Status"=@("Get-EMRNotebookExecutionList")
    "StepCancellationOption"=@("Stop-EMRStep")
}

_awsArgumentCompleterRegistration $EMR_Completers $EMR_map

$EMR_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.EMR.$($commandName.Replace('-', ''))Cmdlet]"
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

$EMR_SelectMap = @{
    "Select"=@("Add-EMRInstanceFleet",
               "Add-EMRInstanceGroup",
               "Add-EMRJobFlowStep",
               "Add-EMRResourceTag",
               "Stop-EMRStep",
               "New-EMRSecurityConfiguration",
               "New-EMRStudio",
               "New-EMRStudioSessionMapping",
               "Remove-EMRSecurityConfiguration",
               "Remove-EMRStudio",
               "Remove-EMRStudioSessionMapping",
               "Get-EMRCluster",
               "Get-EMRJobFlow",
               "Get-EMRNotebookExecution",
               "Get-EMRReleaseLabel",
               "Get-EMRSecurityConfiguration",
               "Get-EMRStep",
               "Get-EMRStudio",
               "Get-EMRAutoTerminationPolicy",
               "Get-EMRBlockPublicAccessConfiguration",
               "Get-EMRClusterSessionCredential",
               "Get-EMRManagedScalingPolicy",
               "Get-EMRStudioSessionMapping",
               "Get-EMRBootstrapActionList",
               "Get-EMRClusterList",
               "Get-EMRInstanceFleetList",
               "Get-EMRInstanceGroupList",
               "Get-EMRInstanceList",
               "Get-EMRNotebookExecutionList",
               "Find-EMRReleaseLabel",
               "Get-EMRSecurityConfigurationList",
               "Get-EMRStepList",
               "Get-EMRStudioList",
               "Get-EMRStudioSessionMappingList",
               "Get-EMRSupportedInstanceType",
               "Edit-EMRCluster",
               "Edit-EMRInstanceFleet",
               "Edit-EMRInstanceGroup",
               "Write-EMRAutoScalingPolicy",
               "Write-EMRAutoTerminationPolicy",
               "Write-EMRBlockPublicAccessConfiguration",
               "Write-EMRManagedScalingPolicy",
               "Remove-EMRAutoScalingPolicy",
               "Remove-EMRAutoTerminationPolicy",
               "Remove-EMRManagedScalingPolicy",
               "Remove-EMRResourceTag",
               "Start-EMRJobFlow",
               "Set-EMRKeepJobFlowAliveWhenNoStep",
               "Set-EMRTerminationProtection",
               "Set-EMRUnhealthyNodeReplacement",
               "Set-EMRVisibleToAllUser",
               "Start-EMRNotebookExecution",
               "Stop-EMRNotebookExecution",
               "Stop-EMRJobFlow",
               "Update-EMRStudio",
               "Update-EMRStudioSessionMapping")
}

_awsArgumentCompleterRegistration $EMR_SelectCompleters $EMR_SelectMap

