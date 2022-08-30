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

# Argument completions for service AWS GreengrassV2


$GGV2_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.GreengrassV2.ComponentVisibilityScope
        "Get-GGV2ComponentList/Scope"
        {
            $v = "PRIVATE","PUBLIC"
            break
        }

        # Amazon.GreengrassV2.CoreDeviceStatus
        "Get-GGV2CoreDeviceList/Status"
        {
            $v = "HEALTHY","UNHEALTHY"
            break
        }

        # Amazon.GreengrassV2.DeploymentComponentUpdatePolicyAction
        "New-GGV2Deployment/DeploymentPolicies_ComponentUpdatePolicy_Action"
        {
            $v = "NOTIFY_COMPONENTS","SKIP_NOTIFY_COMPONENTS"
            break
        }

        # Amazon.GreengrassV2.DeploymentFailureHandlingPolicy
        "New-GGV2Deployment/DeploymentPolicies_FailureHandlingPolicy"
        {
            $v = "DO_NOTHING","ROLLBACK"
            break
        }

        # Amazon.GreengrassV2.DeploymentHistoryFilter
        "Get-GGV2DeploymentList/HistoryFilter"
        {
            $v = "ALL","LATEST_ONLY"
            break
        }

        # Amazon.GreengrassV2.InstalledComponentTopologyFilter
        "Get-GGV2InstalledComponentList/TopologyFilter"
        {
            $v = "ALL","ROOT"
            break
        }

        # Amazon.GreengrassV2.LambdaInputPayloadEncodingType
        "New-GGV2ComponentVersion/LambdaFunction_ComponentLambdaParameters_InputPayloadEncodingType"
        {
            $v = "binary","json"
            break
        }

        # Amazon.GreengrassV2.LambdaIsolationMode
        "New-GGV2ComponentVersion/LambdaFunction_ComponentLambdaParameters_LinuxProcessParams_IsolationMode"
        {
            $v = "GreengrassContainer","NoContainer"
            break
        }

        # Amazon.GreengrassV2.RecipeOutputFormat
        "Get-GGV2Component/RecipeOutputFormat"
        {
            $v = "JSON","YAML"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$GGV2_map = @{
    "DeploymentPolicies_ComponentUpdatePolicy_Action"=@("New-GGV2Deployment")
    "DeploymentPolicies_FailureHandlingPolicy"=@("New-GGV2Deployment")
    "HistoryFilter"=@("Get-GGV2DeploymentList")
    "LambdaFunction_ComponentLambdaParameters_InputPayloadEncodingType"=@("New-GGV2ComponentVersion")
    "LambdaFunction_ComponentLambdaParameters_LinuxProcessParams_IsolationMode"=@("New-GGV2ComponentVersion")
    "RecipeOutputFormat"=@("Get-GGV2Component")
    "Scope"=@("Get-GGV2ComponentList")
    "Status"=@("Get-GGV2CoreDeviceList")
    "TopologyFilter"=@("Get-GGV2InstalledComponentList")
}

_awsArgumentCompleterRegistration $GGV2_Completers $GGV2_map

$GGV2_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.GGV2.$($commandName.Replace('-', ''))Cmdlet]"
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

$GGV2_SelectMap = @{
    "Select"=@("Add-GGV2ServiceRoleToAccount",
               "Add-GGV2BatchClientDeviceWithCoreDevice",
               "Remove-GGV2BatchClientDeviceFromCoreDevice",
               "Stop-GGV2Deployment",
               "New-GGV2ComponentVersion",
               "New-GGV2Deployment",
               "Remove-GGV2Component",
               "Remove-GGV2CoreDevice",
               "Remove-GGV2Deployment",
               "Get-GGV2ComponentMetadata",
               "Remove-GGV2ServiceRoleFromAccount",
               "Get-GGV2Component",
               "Get-GGV2ComponentVersionArtifact",
               "Get-GGV2ConnectivityInfo",
               "Get-GGV2CoreDevice",
               "Get-GGV2Deployment",
               "Get-GGV2ServiceRoleForAccount",
               "Get-GGV2ClientDevicesAssociatedWithCoreDeviceList",
               "Get-GGV2ComponentList",
               "Get-GGV2ComponentVersionList",
               "Get-GGV2CoreDeviceList",
               "Get-GGV2DeploymentList",
               "Get-GGV2EffectiveDeploymentList",
               "Get-GGV2InstalledComponentList",
               "Get-GGV2ResourceTag",
               "Resolve-GGV2ComponentCandidate",
               "Add-GGV2ResourceTag",
               "Remove-GGV2ResourceTag",
               "Update-GGV2ConnectivityInfo")
}

_awsArgumentCompleterRegistration $GGV2_SelectCompleters $GGV2_SelectMap

