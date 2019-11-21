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

# Argument completions for service AWS CodeDeploy


$CD_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.CodeDeploy.ApplicationRevisionSortBy
        "Get-CDApplicationRevisionList/SortBy"
        {
            $v = "firstUsedTime","lastUsedTime","registerTime"
            break
        }

        # Amazon.CodeDeploy.BundleType
        {
            ($_ -eq "Get-CDApplicationRevision/Revision_S3Location_BundleType") -Or
            ($_ -eq "New-CDDeployment/Revision_S3Location_BundleType") -Or
            ($_ -eq "Register-CDApplicationRevision/Revision_S3Location_BundleType")
        }
        {
            $v = "JSON","tar","tgz","YAML","zip"
            break
        }

        # Amazon.CodeDeploy.ComputePlatform
        {
            ($_ -eq "New-CDApplication/ComputePlatform") -Or
            ($_ -eq "New-CDDeploymentConfig/ComputePlatform")
        }
        {
            $v = "ECS","Lambda","Server"
            break
        }

        # Amazon.CodeDeploy.DeploymentOption
        {
            ($_ -eq "New-CDDeploymentGroup/DeploymentStyle_DeploymentOption") -Or
            ($_ -eq "Update-CDDeploymentGroup/DeploymentStyle_DeploymentOption")
        }
        {
            $v = "WITHOUT_TRAFFIC_CONTROL","WITH_TRAFFIC_CONTROL"
            break
        }

        # Amazon.CodeDeploy.DeploymentReadyAction
        {
            ($_ -eq "New-CDDeploymentGroup/BlueGreenDeploymentConfiguration_DeploymentReadyOption_ActionOnTimeout") -Or
            ($_ -eq "Update-CDDeploymentGroup/BlueGreenDeploymentConfiguration_DeploymentReadyOption_ActionOnTimeout")
        }
        {
            $v = "CONTINUE_DEPLOYMENT","STOP_DEPLOYMENT"
            break
        }

        # Amazon.CodeDeploy.DeploymentType
        {
            ($_ -eq "New-CDDeploymentGroup/DeploymentStyle_DeploymentType") -Or
            ($_ -eq "Update-CDDeploymentGroup/DeploymentStyle_DeploymentType")
        }
        {
            $v = "BLUE_GREEN","IN_PLACE"
            break
        }

        # Amazon.CodeDeploy.DeploymentWaitType
        "Resume-CDDeployment/DeploymentWaitType"
        {
            $v = "READY_WAIT","TERMINATION_WAIT"
            break
        }

        # Amazon.CodeDeploy.FileExistsBehavior
        "New-CDDeployment/FileExistsBehavior"
        {
            $v = "DISALLOW","OVERWRITE","RETAIN"
            break
        }

        # Amazon.CodeDeploy.GreenFleetProvisioningAction
        {
            ($_ -eq "New-CDDeploymentGroup/BlueGreenDeploymentConfiguration_GreenFleetProvisioningOption_Action") -Or
            ($_ -eq "Update-CDDeploymentGroup/BlueGreenDeploymentConfiguration_GreenFleetProvisioningOption_Action")
        }
        {
            $v = "COPY_AUTO_SCALING_GROUP","DISCOVER_EXISTING"
            break
        }

        # Amazon.CodeDeploy.InstanceAction
        {
            ($_ -eq "New-CDDeploymentGroup/BlueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_Action") -Or
            ($_ -eq "Update-CDDeploymentGroup/BlueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_Action")
        }
        {
            $v = "KEEP_ALIVE","TERMINATE"
            break
        }

        # Amazon.CodeDeploy.LifecycleEventStatus
        "Write-CDLifecycleEventHookExecutionStatus/Status"
        {
            $v = "Failed","InProgress","Pending","Skipped","Succeeded","Unknown"
            break
        }

        # Amazon.CodeDeploy.ListStateFilterAction
        "Get-CDApplicationRevisionList/Deployed"
        {
            $v = "exclude","ignore","include"
            break
        }

        # Amazon.CodeDeploy.MinimumHealthyHostsType
        "New-CDDeploymentConfig/MinimumHealthyHosts_Type"
        {
            $v = "FLEET_PERCENT","HOST_COUNT"
            break
        }

        # Amazon.CodeDeploy.RegistrationStatus
        "Get-CDOnPremiseInstanceList/RegistrationStatus"
        {
            $v = "Deregistered","Registered"
            break
        }

        # Amazon.CodeDeploy.RevisionLocationType
        {
            ($_ -eq "Get-CDApplicationRevision/Revision_RevisionType") -Or
            ($_ -eq "New-CDDeployment/Revision_RevisionType") -Or
            ($_ -eq "Register-CDApplicationRevision/Revision_RevisionType")
        }
        {
            $v = "AppSpecContent","GitHub","S3","String"
            break
        }

        # Amazon.CodeDeploy.SortOrder
        "Get-CDApplicationRevisionList/SortOrder"
        {
            $v = "ascending","descending"
            break
        }

        # Amazon.CodeDeploy.TrafficRoutingType
        "New-CDDeploymentConfig/TrafficRoutingConfig_Type"
        {
            $v = "AllAtOnce","TimeBasedCanary","TimeBasedLinear"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$CD_map = @{
    "BlueGreenDeploymentConfiguration_DeploymentReadyOption_ActionOnTimeout"=@("New-CDDeploymentGroup","Update-CDDeploymentGroup")
    "BlueGreenDeploymentConfiguration_GreenFleetProvisioningOption_Action"=@("New-CDDeploymentGroup","Update-CDDeploymentGroup")
    "BlueGreenDeploymentConfiguration_TerminateBlueInstancesOnDeploymentSuccess_Action"=@("New-CDDeploymentGroup","Update-CDDeploymentGroup")
    "ComputePlatform"=@("New-CDApplication","New-CDDeploymentConfig")
    "Deployed"=@("Get-CDApplicationRevisionList")
    "DeploymentStyle_DeploymentOption"=@("New-CDDeploymentGroup","Update-CDDeploymentGroup")
    "DeploymentStyle_DeploymentType"=@("New-CDDeploymentGroup","Update-CDDeploymentGroup")
    "DeploymentWaitType"=@("Resume-CDDeployment")
    "FileExistsBehavior"=@("New-CDDeployment")
    "MinimumHealthyHosts_Type"=@("New-CDDeploymentConfig")
    "RegistrationStatus"=@("Get-CDOnPremiseInstanceList")
    "Revision_RevisionType"=@("Get-CDApplicationRevision","New-CDDeployment","Register-CDApplicationRevision")
    "Revision_S3Location_BundleType"=@("Get-CDApplicationRevision","New-CDDeployment","Register-CDApplicationRevision")
    "SortBy"=@("Get-CDApplicationRevisionList")
    "SortOrder"=@("Get-CDApplicationRevisionList")
    "Status"=@("Write-CDLifecycleEventHookExecutionStatus")
    "TrafficRoutingConfig_Type"=@("New-CDDeploymentConfig")
}

_awsArgumentCompleterRegistration $CD_Completers $CD_map

$CD_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.CD.$($commandName.Replace('-', ''))Cmdlet]"
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

$CD_SelectMap = @{
    "Select"=@("Add-CDOnPremiseInstanceTag",
               "Get-CDApplicationRevisionBatch",
               "Get-CDApplicationBatch",
               "Get-CDDeploymentGroupBatch",
               "Get-CDDeploymentInstanceBatch",
               "Get-CDDeploymentBatch",
               "Get-CDDeploymentTargetBatch",
               "Get-CDOnPremiseInstanceBatch",
               "Resume-CDDeployment",
               "New-CDApplication",
               "New-CDDeployment",
               "New-CDDeploymentConfig",
               "New-CDDeploymentGroup",
               "Remove-CDApplication",
               "Remove-CDDeploymentConfig",
               "Remove-CDDeploymentGroup",
               "Remove-CDGitHubAccountToken",
               "Unregister-CDOnPremiseInstance",
               "Get-CDApplication",
               "Get-CDApplicationRevision",
               "Get-CDDeployment",
               "Get-CDDeploymentConfig",
               "Get-CDDeploymentGroup",
               "Get-CDDeploymentInstance",
               "Get-CDDeploymentTarget",
               "Get-CDOnPremiseInstance",
               "Get-CDApplicationRevisionList",
               "Get-CDApplicationList",
               "Get-CDDeploymentConfigList",
               "Get-CDDeploymentGroupList",
               "Get-CDDeploymentInstanceList",
               "Get-CDDeploymentList",
               "Get-CDDeploymentTargetList",
               "Get-CDGitHubAccountTokenNameList",
               "Get-CDOnPremiseInstanceList",
               "Get-CDResourceTag",
               "Write-CDLifecycleEventHookExecutionStatus",
               "Register-CDApplicationRevision",
               "Register-CDOnPremiseInstance",
               "Remove-CDOnPremiseInstanceTag",
               "Skip-CDWaitTimeForInstanceTermination",
               "Stop-CDDeployment",
               "Add-CDResourceTag",
               "Remove-CDResourceTag",
               "Update-CDApplication",
               "Update-CDDeploymentGroup")
}

_awsArgumentCompleterRegistration $CD_SelectCompleters $CD_SelectMap

