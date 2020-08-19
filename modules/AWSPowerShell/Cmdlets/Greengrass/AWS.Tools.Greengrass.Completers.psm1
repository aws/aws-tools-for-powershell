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

# Argument completions for service AWS Greengrass


$GG_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Greengrass.DeploymentType
        "New-GGDeployment/DeploymentType"
        {
            $v = "ForceResetDeployment","NewDeployment","Redeployment","ResetDeployment"
            break
        }

        # Amazon.Greengrass.FunctionIsolationMode
        {
            ($_ -eq "New-GGFunctionDefinitionVersion/DefaultConfig_Execution_IsolationMode") -Or
            ($_ -eq "New-GGFunctionDefinition/InitialVersion_DefaultConfig_Execution_IsolationMode")
        }
        {
            $v = "GreengrassContainer","NoContainer"
            break
        }

        # Amazon.Greengrass.SoftwareToUpdate
        "New-GGSoftwareUpdateJob/SoftwareToUpdate"
        {
            $v = "core","ota_agent"
            break
        }

        # Amazon.Greengrass.Telemetry
        "Update-GGThingRuntimeConfiguration/TelemetryConfiguration_Telemetry"
        {
            $v = "Off","On"
            break
        }

        # Amazon.Greengrass.UpdateAgentLogLevel
        "New-GGSoftwareUpdateJob/UpdateAgentLogLevel"
        {
            $v = "DEBUG","ERROR","FATAL","INFO","NONE","TRACE","VERBOSE","WARN"
            break
        }

        # Amazon.Greengrass.UpdateTargetsArchitecture
        "New-GGSoftwareUpdateJob/UpdateTargetsArchitecture"
        {
            $v = "aarch64","armv6l","armv7l","x86_64"
            break
        }

        # Amazon.Greengrass.UpdateTargetsOperatingSystem
        "New-GGSoftwareUpdateJob/UpdateTargetsOperatingSystem"
        {
            $v = "amazon_linux","openwrt","raspbian","ubuntu"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$GG_map = @{
    "DefaultConfig_Execution_IsolationMode"=@("New-GGFunctionDefinitionVersion")
    "DeploymentType"=@("New-GGDeployment")
    "InitialVersion_DefaultConfig_Execution_IsolationMode"=@("New-GGFunctionDefinition")
    "SoftwareToUpdate"=@("New-GGSoftwareUpdateJob")
    "TelemetryConfiguration_Telemetry"=@("Update-GGThingRuntimeConfiguration")
    "UpdateAgentLogLevel"=@("New-GGSoftwareUpdateJob")
    "UpdateTargetsArchitecture"=@("New-GGSoftwareUpdateJob")
    "UpdateTargetsOperatingSystem"=@("New-GGSoftwareUpdateJob")
}

_awsArgumentCompleterRegistration $GG_Completers $GG_map

$GG_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.GG.$($commandName.Replace('-', ''))Cmdlet]"
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

$GG_SelectMap = @{
    "Select"=@("Add-GGRoleToGroup",
               "Add-GGServiceRoleToAccount",
               "New-GGConnectorDefinition",
               "New-GGConnectorDefinitionVersion",
               "New-GGCoreDefinition",
               "New-GGCoreDefinitionVersion",
               "New-GGDeployment",
               "New-GGDeviceDefinition",
               "New-GGDeviceDefinitionVersion",
               "New-GGFunctionDefinition",
               "New-GGFunctionDefinitionVersion",
               "New-GGGroup",
               "New-GGGroupCertificateAuthority",
               "New-GGGroupVersion",
               "New-GGLoggerDefinition",
               "New-GGLoggerDefinitionVersion",
               "New-GGResourceDefinition",
               "New-GGResourceDefinitionVersion",
               "New-GGSoftwareUpdateJob",
               "New-GGSubscriptionDefinition",
               "New-GGSubscriptionDefinitionVersion",
               "Remove-GGConnectorDefinition",
               "Remove-GGCoreDefinition",
               "Remove-GGDeviceDefinition",
               "Remove-GGFunctionDefinition",
               "Remove-GGGroup",
               "Remove-GGLoggerDefinition",
               "Remove-GGResourceDefinition",
               "Remove-GGSubscriptionDefinition",
               "Remove-GGRoleFromGroup",
               "Remove-GGServiceRoleFromAccount",
               "Get-GGAssociatedRole",
               "Get-GGBulkDeploymentStatus",
               "Get-GGConnectivityInfo",
               "Get-GGConnectorDefinition",
               "Get-GGConnectorDefinitionVersion",
               "Get-GGCoreDefinition",
               "Get-GGCoreDefinitionVersion",
               "Get-GGDeploymentStatus",
               "Get-GGDeviceDefinition",
               "Get-GGDeviceDefinitionVersion",
               "Get-GGFunctionDefinition",
               "Get-GGFunctionDefinitionVersion",
               "Get-GGGroup",
               "Get-GGGroupCertificateAuthority",
               "Get-GGGroupCertificateConfiguration",
               "Get-GGGroupVersion",
               "Get-GGLoggerDefinition",
               "Get-GGLoggerDefinitionVersion",
               "Get-GGResourceDefinition",
               "Get-GGResourceDefinitionVersion",
               "Get-GGServiceRoleForAccount",
               "Get-GGSubscriptionDefinition",
               "Get-GGSubscriptionDefinitionVersion",
               "Get-GGThingRuntimeConfiguration",
               "Get-GGBulkDeploymentDetailedReportList",
               "Get-GGBulkDeploymentList",
               "Get-GGConnectorDefinitionList",
               "Get-GGConnectorDefinitionVersionList",
               "Get-GGCoreDefinitionList",
               "Get-GGCoreDefinitionVersionList",
               "Get-GGDeploymentList",
               "Get-GGDeviceDefinitionList",
               "Get-GGDeviceDefinitionVersionList",
               "Get-GGFunctionDefinitionList",
               "Get-GGFunctionDefinitionVersionList",
               "Get-GGGroupCertificateAuthorityList",
               "Get-GGGroupList",
               "Get-GGGroupVersionList",
               "Get-GGLoggerDefinitionList",
               "Get-GGLoggerDefinitionVersionList",
               "Get-GGResourceDefinitionList",
               "Get-GGResourceDefinitionVersionList",
               "Get-GGSubscriptionDefinitionList",
               "Get-GGSubscriptionDefinitionVersionList",
               "Get-GGResourceTag",
               "Reset-GGDeployment",
               "Start-GGBulkDeployment",
               "Stop-GGBulkDeployment",
               "Add-GGResourceTag",
               "Remove-GGResourceTag",
               "Update-GGConnectivityInfo",
               "Update-GGConnectorDefinition",
               "Update-GGCoreDefinition",
               "Update-GGDeviceDefinition",
               "Update-GGFunctionDefinition",
               "Update-GGGroup",
               "Update-GGGroupCertificateConfiguration",
               "Update-GGLoggerDefinition",
               "Update-GGResourceDefinition",
               "Update-GGSubscriptionDefinition",
               "Update-GGThingRuntimeConfiguration")
}

_awsArgumentCompleterRegistration $GG_SelectCompleters $GG_SelectMap

