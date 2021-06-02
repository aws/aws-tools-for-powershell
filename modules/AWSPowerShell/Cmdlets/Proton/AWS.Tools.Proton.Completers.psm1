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

# Argument completions for service AWS Proton


$PRO_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Proton.DeploymentUpdateType
        {
            ($_ -eq "Update-PROEnvironment/DeploymentType") -Or
            ($_ -eq "Update-PROServiceInstance/DeploymentType") -Or
            ($_ -eq "Update-PROServicePipeline/DeploymentType")
        }
        {
            $v = "CURRENT_VERSION","MAJOR_VERSION","MINOR_VERSION","NONE"
            break
        }

        # Amazon.Proton.EnvironmentAccountConnectionRequesterAccountType
        "Get-PROEnvironmentAccountConnectionList/RequestedBy"
        {
            $v = "ENVIRONMENT_ACCOUNT","MANAGEMENT_ACCOUNT"
            break
        }

        # Amazon.Proton.Provisioning
        {
            ($_ -eq "New-PROServiceTemplate/PipelineProvisioning") -Or
            ($_ -eq "New-PROEnvironmentTemplate/Provisioning")
        }
        {
            $v = "CUSTOMER_MANAGED"
            break
        }

        # Amazon.Proton.TemplateVersionStatus
        {
            ($_ -eq "Update-PROEnvironmentTemplateVersion/Status") -Or
            ($_ -eq "Update-PROServiceTemplateVersion/Status")
        }
        {
            $v = "DRAFT","PUBLISHED","REGISTRATION_FAILED","REGISTRATION_IN_PROGRESS"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$PRO_map = @{
    "DeploymentType"=@("Update-PROEnvironment","Update-PROServiceInstance","Update-PROServicePipeline")
    "PipelineProvisioning"=@("New-PROServiceTemplate")
    "Provisioning"=@("New-PROEnvironmentTemplate")
    "RequestedBy"=@("Get-PROEnvironmentAccountConnectionList")
    "Status"=@("Update-PROEnvironmentTemplateVersion","Update-PROServiceTemplateVersion")
}

_awsArgumentCompleterRegistration $PRO_Completers $PRO_map

$PRO_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.PRO.$($commandName.Replace('-', ''))Cmdlet]"
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

$PRO_SelectMap = @{
    "Select"=@("Approve-PROEnvironmentAccountConnection",
               "Stop-PROEnvironmentDeployment",
               "Stop-PROServiceInstanceDeployment",
               "Stop-PROServicePipelineDeployment",
               "New-PROEnvironment",
               "New-PROEnvironmentAccountConnection",
               "New-PROEnvironmentTemplate",
               "New-PROEnvironmentTemplateVersion",
               "New-PROService",
               "New-PROServiceTemplate",
               "New-PROServiceTemplateVersion",
               "Remove-PROEnvironment",
               "Remove-PROEnvironmentAccountConnection",
               "Remove-PROEnvironmentTemplate",
               "Remove-PROEnvironmentTemplateVersion",
               "Remove-PROService",
               "Remove-PROServiceTemplate",
               "Remove-PROServiceTemplateVersion",
               "Get-PROAccountSetting",
               "Get-PROEnvironment",
               "Get-PROEnvironmentAccountConnection",
               "Get-PROEnvironmentTemplate",
               "Get-PROEnvironmentTemplateVersion",
               "Get-PROService",
               "Get-PROServiceInstance",
               "Get-PROServiceTemplate",
               "Get-PROServiceTemplateVersion",
               "Get-PROEnvironmentAccountConnectionList",
               "Get-PROEnvironmentList",
               "Get-PROEnvironmentTemplateList",
               "Get-PROEnvironmentTemplateVersionList",
               "Get-PROServiceInstanceList",
               "Get-PROServiceList",
               "Get-PROServiceTemplateList",
               "Get-PROServiceTemplateVersionList",
               "Get-PROResourceTag",
               "Deny-PROEnvironmentAccountConnection",
               "Add-PROResourceTag",
               "Remove-PROResourceTag",
               "Update-PROAccountSetting",
               "Update-PROEnvironment",
               "Update-PROEnvironmentAccountConnection",
               "Update-PROEnvironmentTemplate",
               "Update-PROEnvironmentTemplateVersion",
               "Update-PROService",
               "Update-PROServiceInstance",
               "Update-PROServicePipeline",
               "Update-PROServiceTemplate",
               "Update-PROServiceTemplateVersion")
}

_awsArgumentCompleterRegistration $PRO_SelectCompleters $PRO_SelectMap

