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

# Argument completions for service AWSDeadlineCloud


$ADC_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Deadline.AutoScalingMode
        {
            ($_ -eq "New-ADCFleet/CustomerManaged_Mode") -Or
            ($_ -eq "Update-ADCFleet/CustomerManaged_Mode")
        }
        {
            $v = "EVENT_BASED_AUTO_SCALING","NO_SCALING"
            break
        }

        # Amazon.Deadline.BudgetStatus
        {
            ($_ -eq "Get-ADCBudgetList/Status") -Or
            ($_ -eq "Update-ADCBudget/Status")
        }
        {
            $v = "ACTIVE","INACTIVE"
            break
        }

        # Amazon.Deadline.CpuArchitectureType
        {
            ($_ -eq "New-ADCFleet/InstanceCapabilities_CpuArchitectureType") -Or
            ($_ -eq "Update-ADCFleet/InstanceCapabilities_CpuArchitectureType") -Or
            ($_ -eq "New-ADCFleet/WorkerCapabilities_CpuArchitectureType") -Or
            ($_ -eq "Update-ADCFleet/WorkerCapabilities_CpuArchitectureType")
        }
        {
            $v = "arm64","x86_64"
            break
        }

        # Amazon.Deadline.CreateJobTargetTaskRunStatus
        "New-ADCJob/TargetTaskRunStatus"
        {
            $v = "READY","SUSPENDED"
            break
        }

        # Amazon.Deadline.CustomerManagedFleetOperatingSystemFamily
        {
            ($_ -eq "New-ADCFleet/WorkerCapabilities_OsFamily") -Or
            ($_ -eq "Update-ADCFleet/WorkerCapabilities_OsFamily")
        }
        {
            $v = "LINUX","MACOS","WINDOWS"
            break
        }

        # Amazon.Deadline.DefaultQueueBudgetAction
        {
            ($_ -eq "New-ADCQueue/DefaultBudgetAction") -Or
            ($_ -eq "Update-ADCQueue/DefaultBudgetAction")
        }
        {
            $v = "NONE","STOP_SCHEDULING_AND_CANCEL_TASKS","STOP_SCHEDULING_AND_COMPLETE_TASKS"
            break
        }

        # Amazon.Deadline.Ec2MarketType
        {
            ($_ -eq "New-ADCFleet/InstanceMarketOptions_Type") -Or
            ($_ -eq "Update-ADCFleet/InstanceMarketOptions_Type")
        }
        {
            $v = "on-demand","spot"
            break
        }

        # Amazon.Deadline.EnvironmentTemplateType
        {
            ($_ -eq "New-ADCQueueEnvironment/TemplateType") -Or
            ($_ -eq "Update-ADCQueueEnvironment/TemplateType")
        }
        {
            $v = "JSON","YAML"
            break
        }

        # Amazon.Deadline.FleetStatus
        "Get-ADCFleetList/Status"
        {
            $v = "ACTIVE","CREATE_FAILED","CREATE_IN_PROGRESS","UPDATE_FAILED","UPDATE_IN_PROGRESS"
            break
        }

        # Amazon.Deadline.JobAttachmentsFileSystem
        "New-ADCJob/Attachments_FileSystem"
        {
            $v = "COPIED","VIRTUAL"
            break
        }

        # Amazon.Deadline.JobTargetTaskRunStatus
        "Update-ADCJob/TargetTaskRunStatus"
        {
            $v = "CANCELED","FAILED","PENDING","READY","SUCCEEDED","SUSPENDED"
            break
        }

        # Amazon.Deadline.JobTemplateType
        "New-ADCJob/TemplateType"
        {
            $v = "JSON","YAML"
            break
        }

        # Amazon.Deadline.LogicalOperator
        {
            ($_ -eq "Search-ADCJob/FilterExpressions_Operator") -Or
            ($_ -eq "Search-ADCStep/FilterExpressions_Operator") -Or
            ($_ -eq "Search-ADCTask/FilterExpressions_Operator") -Or
            ($_ -eq "Search-ADCWorker/FilterExpressions_Operator")
        }
        {
            $v = "AND","OR"
            break
        }

        # Amazon.Deadline.MembershipLevel
        {
            ($_ -eq "Add-ADCMemberToFarm/MembershipLevel") -Or
            ($_ -eq "Add-ADCMemberToFleet/MembershipLevel") -Or
            ($_ -eq "Add-ADCMemberToJob/MembershipLevel") -Or
            ($_ -eq "Add-ADCMemberToQueue/MembershipLevel")
        }
        {
            $v = "CONTRIBUTOR","MANAGER","OWNER","VIEWER"
            break
        }

        # Amazon.Deadline.Period
        "Start-ADCSessionsStatisticsAggregation/Period"
        {
            $v = "DAILY","HOURLY","MONTHLY","WEEKLY"
            break
        }

        # Amazon.Deadline.PrincipalType
        {
            ($_ -eq "Add-ADCMemberToFarm/PrincipalType") -Or
            ($_ -eq "Add-ADCMemberToFleet/PrincipalType") -Or
            ($_ -eq "Add-ADCMemberToJob/PrincipalType") -Or
            ($_ -eq "Add-ADCMemberToQueue/PrincipalType")
        }
        {
            $v = "GROUP","USER"
            break
        }

        # Amazon.Deadline.QueueStatus
        "Get-ADCQueueList/Status"
        {
            $v = "IDLE","SCHEDULING","SCHEDULING_BLOCKED"
            break
        }

        # Amazon.Deadline.RunAs
        {
            ($_ -eq "New-ADCQueue/JobRunAsUser_RunAs") -Or
            ($_ -eq "Update-ADCQueue/JobRunAsUser_RunAs")
        }
        {
            $v = "QUEUE_CONFIGURED_USER","WORKER_AGENT_USER"
            break
        }

        # Amazon.Deadline.ServiceManagedFleetOperatingSystemFamily
        {
            ($_ -eq "New-ADCFleet/InstanceCapabilities_OsFamily") -Or
            ($_ -eq "Update-ADCFleet/InstanceCapabilities_OsFamily")
        }
        {
            $v = "LINUX","WINDOWS"
            break
        }

        # Amazon.Deadline.SessionLifecycleTargetStatus
        "Update-ADCSession/TargetLifecycleStatus"
        {
            $v = "ENDED"
            break
        }

        # Amazon.Deadline.StepTargetTaskRunStatus
        "Update-ADCStep/TargetTaskRunStatus"
        {
            $v = "CANCELED","FAILED","PENDING","READY","SUCCEEDED","SUSPENDED"
            break
        }

        # Amazon.Deadline.StorageProfileOperatingSystemFamily
        {
            ($_ -eq "New-ADCStorageProfile/OsFamily") -Or
            ($_ -eq "Update-ADCStorageProfile/OsFamily")
        }
        {
            $v = "LINUX","MACOS","WINDOWS"
            break
        }

        # Amazon.Deadline.TaskTargetRunStatus
        "Update-ADCTask/TargetRunStatus"
        {
            $v = "CANCELED","FAILED","PENDING","READY","SUCCEEDED","SUSPENDED"
            break
        }

        # Amazon.Deadline.UpdatedWorkerStatus
        "Update-ADCWorker/Status"
        {
            $v = "STARTED","STOPPED","STOPPING"
            break
        }

        # Amazon.Deadline.UpdateJobLifecycleStatus
        "Update-ADCJob/LifecycleStatus"
        {
            $v = "ARCHIVED"
            break
        }

        # Amazon.Deadline.UpdateQueueFleetAssociationStatus
        "Update-ADCQueueFleetAssociation/Status"
        {
            $v = "ACTIVE","STOP_SCHEDULING_AND_CANCEL_TASKS","STOP_SCHEDULING_AND_COMPLETE_TASKS"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$ADC_map = @{
    "Attachments_FileSystem"=@("New-ADCJob")
    "CustomerManaged_Mode"=@("New-ADCFleet","Update-ADCFleet")
    "DefaultBudgetAction"=@("New-ADCQueue","Update-ADCQueue")
    "FilterExpressions_Operator"=@("Search-ADCJob","Search-ADCStep","Search-ADCTask","Search-ADCWorker")
    "InstanceCapabilities_CpuArchitectureType"=@("New-ADCFleet","Update-ADCFleet")
    "InstanceCapabilities_OsFamily"=@("New-ADCFleet","Update-ADCFleet")
    "InstanceMarketOptions_Type"=@("New-ADCFleet","Update-ADCFleet")
    "JobRunAsUser_RunAs"=@("New-ADCQueue","Update-ADCQueue")
    "LifecycleStatus"=@("Update-ADCJob")
    "MembershipLevel"=@("Add-ADCMemberToFarm","Add-ADCMemberToFleet","Add-ADCMemberToJob","Add-ADCMemberToQueue")
    "OsFamily"=@("New-ADCStorageProfile","Update-ADCStorageProfile")
    "Period"=@("Start-ADCSessionsStatisticsAggregation")
    "PrincipalType"=@("Add-ADCMemberToFarm","Add-ADCMemberToFleet","Add-ADCMemberToJob","Add-ADCMemberToQueue")
    "Status"=@("Get-ADCBudgetList","Get-ADCFleetList","Get-ADCQueueList","Update-ADCBudget","Update-ADCQueueFleetAssociation","Update-ADCWorker")
    "TargetLifecycleStatus"=@("Update-ADCSession")
    "TargetRunStatus"=@("Update-ADCTask")
    "TargetTaskRunStatus"=@("New-ADCJob","Update-ADCJob","Update-ADCStep")
    "TemplateType"=@("New-ADCJob","New-ADCQueueEnvironment","Update-ADCQueueEnvironment")
    "WorkerCapabilities_CpuArchitectureType"=@("New-ADCFleet","Update-ADCFleet")
    "WorkerCapabilities_OsFamily"=@("New-ADCFleet","Update-ADCFleet")
}

_awsArgumentCompleterRegistration $ADC_Completers $ADC_map

$ADC_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.ADC.$($commandName.Replace('-', ''))Cmdlet]"
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

$ADC_SelectMap = @{
    "Select"=@("Add-ADCMemberToFarm",
               "Add-ADCMemberToFleet",
               "Add-ADCMemberToJob",
               "Add-ADCMemberToQueue",
               "Get-ADCFleetRoleForRead",
               "Get-ADCFleetRoleForWorker",
               "Get-ADCQueueRoleForRead",
               "Get-ADCQueueRoleForUser",
               "Get-ADCQueueRoleForWorker",
               "Get-ADCBatchJobEntity",
               "Copy-ADCJobTemplate",
               "New-ADCBudget",
               "New-ADCFarm",
               "New-ADCFleet",
               "New-ADCJob",
               "New-ADCLicenseEndpoint",
               "New-ADCMonitor",
               "New-ADCQueue",
               "New-ADCQueueEnvironment",
               "New-ADCQueueFleetAssociation",
               "New-ADCStorageProfile",
               "New-ADCWorker",
               "Remove-ADCBudget",
               "Remove-ADCFarm",
               "Remove-ADCFleet",
               "Remove-ADCLicenseEndpoint",
               "Remove-ADCMeteredProduct",
               "Remove-ADCMonitor",
               "Remove-ADCQueue",
               "Remove-ADCQueueEnvironment",
               "Remove-ADCQueueFleetAssociation",
               "Remove-ADCStorageProfile",
               "Remove-ADCWorker",
               "Remove-ADCMemberFromFarm",
               "Remove-ADCMemberFromFleet",
               "Remove-ADCMemberFromJob",
               "Remove-ADCMemberFromQueue",
               "Get-ADCBudget",
               "Get-ADCFarm",
               "Get-ADCFleet",
               "Get-ADCJob",
               "Get-ADCLicenseEndpoint",
               "Get-ADCMonitor",
               "Get-ADCQueue",
               "Get-ADCQueueEnvironment",
               "Get-ADCQueueFleetAssociation",
               "Get-ADCSession",
               "Get-ADCSessionAction",
               "Get-ADCSessionsStatisticsAggregation",
               "Get-ADCStep",
               "Get-ADCStorageProfile",
               "Get-ADCStorageProfileForQueue",
               "Get-ADCTask",
               "Get-ADCWorker",
               "Get-ADCAvailableMeteredProductList",
               "Get-ADCBudgetList",
               "Get-ADCFarmMemberList",
               "Get-ADCFarmList",
               "Get-ADCFleetMemberList",
               "Get-ADCFleetList",
               "Get-ADCJobMemberList",
               "Get-ADCJobList",
               "Get-ADCLicenseEndpointList",
               "Get-ADCMeteredProductList",
               "Get-ADCMonitorList",
               "Get-ADCQueueEnvironmentList",
               "Get-ADCQueueFleetAssociationList",
               "Get-ADCQueueMemberList",
               "Get-ADCQueueList",
               "Get-ADCSessionActionList",
               "Get-ADCSessionList",
               "Get-ADCSessionsForWorkerList",
               "Get-ADCStepConsumerList",
               "Get-ADCStepDependencyList",
               "Get-ADCStepList",
               "Get-ADCStorageProfileList",
               "Get-ADCStorageProfilesForQueueList",
               "Get-ADCResourceTag",
               "Get-ADCTaskList",
               "Get-ADCWorkerList",
               "Write-ADCMeteredProduct",
               "Search-ADCJob",
               "Search-ADCStep",
               "Search-ADCTask",
               "Search-ADCWorker",
               "Start-ADCSessionsStatisticsAggregation",
               "Add-ADCResourceTag",
               "Remove-ADCResourceTag",
               "Update-ADCBudget",
               "Update-ADCFarm",
               "Update-ADCFleet",
               "Update-ADCJob",
               "Update-ADCMonitor",
               "Update-ADCQueue",
               "Update-ADCQueueEnvironment",
               "Update-ADCQueueFleetAssociation",
               "Update-ADCSession",
               "Update-ADCStep",
               "Update-ADCStorageProfile",
               "Update-ADCTask",
               "Update-ADCWorker",
               "Update-ADCWorkerSchedule")
}

_awsArgumentCompleterRegistration $ADC_SelectCompleters $ADC_SelectMap

