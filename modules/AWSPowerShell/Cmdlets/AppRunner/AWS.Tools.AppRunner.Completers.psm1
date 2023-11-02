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

# Argument completions for service AWS App Runner


$AAR_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.AppRunner.ConfigurationSource
        {
            ($_ -eq "New-AARService/SourceConfiguration_CodeRepository_CodeConfiguration_ConfigurationSource") -Or
            ($_ -eq "Update-AARService/SourceConfiguration_CodeRepository_CodeConfiguration_ConfigurationSource")
        }
        {
            $v = "API","REPOSITORY"
            break
        }

        # Amazon.AppRunner.EgressType
        {
            ($_ -eq "New-AARService/NetworkConfiguration_EgressConfiguration_EgressType") -Or
            ($_ -eq "Update-AARService/NetworkConfiguration_EgressConfiguration_EgressType")
        }
        {
            $v = "DEFAULT","VPC"
            break
        }

        # Amazon.AppRunner.HealthCheckProtocol
        {
            ($_ -eq "New-AARService/HealthCheckConfiguration_Protocol") -Or
            ($_ -eq "Update-AARService/HealthCheckConfiguration_Protocol")
        }
        {
            $v = "HTTP","TCP"
            break
        }

        # Amazon.AppRunner.ImageRepositoryType
        {
            ($_ -eq "New-AARService/SourceConfiguration_ImageRepository_ImageRepositoryType") -Or
            ($_ -eq "Update-AARService/SourceConfiguration_ImageRepository_ImageRepositoryType")
        }
        {
            $v = "ECR","ECR_PUBLIC"
            break
        }

        # Amazon.AppRunner.IpAddressType
        {
            ($_ -eq "New-AARService/NetworkConfiguration_IpAddressType") -Or
            ($_ -eq "Update-AARService/NetworkConfiguration_IpAddressType")
        }
        {
            $v = "DUAL_STACK","IPV4"
            break
        }

        # Amazon.AppRunner.ProviderType
        "New-AARConnection/ProviderType"
        {
            $v = "BITBUCKET","GITHUB"
            break
        }

        # Amazon.AppRunner.Runtime
        {
            ($_ -eq "New-AARService/SourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_Runtime") -Or
            ($_ -eq "Update-AARService/SourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_Runtime")
        }
        {
            $v = "CORRETTO_11","CORRETTO_8","DOTNET_6","GO_1","NODEJS_12","NODEJS_14","NODEJS_16","PHP_81","PYTHON_3","RUBY_31"
            break
        }

        # Amazon.AppRunner.SourceCodeVersionType
        {
            ($_ -eq "New-AARService/SourceConfiguration_CodeRepository_SourceCodeVersion_Type") -Or
            ($_ -eq "Update-AARService/SourceConfiguration_CodeRepository_SourceCodeVersion_Type")
        }
        {
            $v = "BRANCH"
            break
        }

        # Amazon.AppRunner.TracingVendor
        "New-AARObservabilityConfiguration/TraceConfiguration_Vendor"
        {
            $v = "AWSXRAY"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$AAR_map = @{
    "HealthCheckConfiguration_Protocol"=@("New-AARService","Update-AARService")
    "NetworkConfiguration_EgressConfiguration_EgressType"=@("New-AARService","Update-AARService")
    "NetworkConfiguration_IpAddressType"=@("New-AARService","Update-AARService")
    "ProviderType"=@("New-AARConnection")
    "SourceConfiguration_CodeRepository_CodeConfiguration_CodeConfigurationValues_Runtime"=@("New-AARService","Update-AARService")
    "SourceConfiguration_CodeRepository_CodeConfiguration_ConfigurationSource"=@("New-AARService","Update-AARService")
    "SourceConfiguration_CodeRepository_SourceCodeVersion_Type"=@("New-AARService","Update-AARService")
    "SourceConfiguration_ImageRepository_ImageRepositoryType"=@("New-AARService","Update-AARService")
    "TraceConfiguration_Vendor"=@("New-AARObservabilityConfiguration")
}

_awsArgumentCompleterRegistration $AAR_Completers $AAR_map

$AAR_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.AAR.$($commandName.Replace('-', ''))Cmdlet]"
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

$AAR_SelectMap = @{
    "Select"=@("Add-AARCustomDomain",
               "New-AARAutoScalingConfiguration",
               "New-AARConnection",
               "New-AARObservabilityConfiguration",
               "New-AARService",
               "New-AARVpcConnector",
               "New-AARVpcIngressConnection",
               "Remove-AARAutoScalingConfiguration",
               "Remove-AARConnection",
               "Remove-AARObservabilityConfiguration",
               "Remove-AARService",
               "Remove-AARVpcConnector",
               "Remove-AARVpcIngressConnection",
               "Get-AARAutoScalingConfiguration",
               "Get-AARCustomDomain",
               "Get-AARObservabilityConfiguration",
               "Get-AARService",
               "Get-AARVpcConnector",
               "Get-AARVpcIngressConnection",
               "Remove-AARCustomDomain",
               "Get-AARAutoScalingConfigurationList",
               "Get-AARConnectionList",
               "Get-AARObservabilityConfigurationList",
               "Get-AAROperationList",
               "Get-AARServiceList",
               "Get-AARServicesForAutoScalingConfigurationList",
               "Get-AARResourceTag",
               "Get-AARVpcConnectorList",
               "Get-AARVpcIngressConnectionList",
               "Suspend-AARService",
               "Resume-AARService",
               "Start-AARDeployment",
               "Add-AARResourceTag",
               "Remove-AARResourceTag",
               "Update-AARDefaultAutoScalingConfiguration",
               "Update-AARService",
               "Update-AARVpcIngressConnection")
}

_awsArgumentCompleterRegistration $AAR_SelectCompleters $AAR_SelectMap

