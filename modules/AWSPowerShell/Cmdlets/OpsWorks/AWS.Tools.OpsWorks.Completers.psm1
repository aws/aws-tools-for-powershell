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

# Argument completions for service AWS OpsWorks


$OPS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.OpsWorks.AppType
        {
            ($_ -eq "New-OPSApp/Type") -Or
            ($_ -eq "Update-OPSApp/Type")
        }
        {
            $v = "aws-flow-ruby","java","nodejs","other","php","rails","static"
            break
        }

        # Amazon.OpsWorks.Architecture
        {
            ($_ -eq "New-OPSInstance/Architecture") -Or
            ($_ -eq "Update-OPSInstance/Architecture")
        }
        {
            $v = "i386","x86_64"
            break
        }

        # Amazon.OpsWorks.AutoScalingType
        {
            ($_ -eq "New-OPSInstance/AutoScalingType") -Or
            ($_ -eq "Update-OPSInstance/AutoScalingType")
        }
        {
            $v = "load","timer"
            break
        }

        # Amazon.OpsWorks.DeploymentCommandName
        "New-OPSDeployment/Command_Name"
        {
            $v = "configure","deploy","execute_recipes","install_dependencies","restart","rollback","setup","start","stop","undeploy","update_custom_cookbooks","update_dependencies"
            break
        }

        # Amazon.OpsWorks.LayerType
        "New-OPSLayer/Type"
        {
            $v = "aws-flow-ruby","custom","db-master","ecs-cluster","java-app","lb","memcached","monitoring-master","nodejs-app","php-app","rails-app","web"
            break
        }

        # Amazon.OpsWorks.RootDeviceType
        {
            ($_ -eq "Copy-OPSStack/DefaultRootDeviceType") -Or
            ($_ -eq "New-OPSStack/DefaultRootDeviceType") -Or
            ($_ -eq "Update-OPSStack/DefaultRootDeviceType") -Or
            ($_ -eq "New-OPSInstance/RootDeviceType")
        }
        {
            $v = "ebs","instance-store"
            break
        }

        # Amazon.OpsWorks.SourceType
        {
            ($_ -eq "New-OPSApp/AppSource_Type") -Or
            ($_ -eq "Update-OPSApp/AppSource_Type") -Or
            ($_ -eq "Copy-OPSStack/CustomCookbooksSource_Type") -Or
            ($_ -eq "New-OPSStack/CustomCookbooksSource_Type") -Or
            ($_ -eq "Update-OPSStack/CustomCookbooksSource_Type")
        }
        {
            $v = "archive","git","s3","svn"
            break
        }

        # Amazon.OpsWorks.VirtualizationType
        "New-OPSInstance/VirtualizationType"
        {
            $v = "hvm","paravirtual"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$OPS_map = @{
    "AppSource_Type"=@("New-OPSApp","Update-OPSApp")
    "Architecture"=@("New-OPSInstance","Update-OPSInstance")
    "AutoScalingType"=@("New-OPSInstance","Update-OPSInstance")
    "Command_Name"=@("New-OPSDeployment")
    "CustomCookbooksSource_Type"=@("Copy-OPSStack","New-OPSStack","Update-OPSStack")
    "DefaultRootDeviceType"=@("Copy-OPSStack","New-OPSStack","Update-OPSStack")
    "RootDeviceType"=@("New-OPSInstance")
    "Type"=@("New-OPSApp","New-OPSLayer","Update-OPSApp")
    "VirtualizationType"=@("New-OPSInstance")
}

_awsArgumentCompleterRegistration $OPS_Completers $OPS_map

$OPS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.OPS.$($commandName.Replace('-', ''))Cmdlet]"
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

$OPS_SelectMap = @{
    "Select"=@("Register-OPSInstanceAssignment",
               "Add-OPSVolume",
               "Add-OPSElasticIp",
               "Add-OPSElasticLoadBalancer",
               "Copy-OPSStack",
               "New-OPSApp",
               "New-OPSDeployment",
               "New-OPSInstance",
               "New-OPSLayer",
               "New-OPSStack",
               "New-OPSUserProfile",
               "Remove-OPSApp",
               "Remove-OPSInstance",
               "Remove-OPSLayer",
               "Remove-OPSStack",
               "Remove-OPSUserProfile",
               "Unregister-OPSEcsCluster",
               "Unregister-OPSElasticIp",
               "Unregister-OPSInstance",
               "Unregister-OPSRdsDbInstance",
               "Unregister-OPSVolume",
               "Get-OPSAgentVersion",
               "Get-OPSApp",
               "Get-OPSCommand",
               "Get-OPSDeployment",
               "Get-OPSEcsCluster",
               "Get-OPSElasticIp",
               "Get-OPSElasticLoadBalancer",
               "Get-OPSInstance",
               "Get-OPSLayer",
               "Get-OPSLoadBasedAutoScaling",
               "Get-OPSMyUserProfile",
               "Get-OPSOperatingSystem",
               "Get-OPSPermission",
               "Get-OPSRaidArray",
               "Get-OPSRdsDbInstance",
               "Get-OPSServiceError",
               "Get-OPSStackProvisioningParameter",
               "Get-OPSStack",
               "Get-OPSStackSummary",
               "Get-OPSTimeBasedAutoScaling",
               "Get-OPSUserProfile",
               "Get-OPSVolume",
               "Dismount-OPSElasticLoadBalancer",
               "Remove-OPSElasticIp",
               "Get-OPSHostnameSuggestion",
               "Grant-OPSAccess",
               "Get-OPSResourceTag",
               "Restart-OPSInstance",
               "Register-OPSEcsCluster",
               "Register-OPSElasticIp",
               "Register-OPSInstance",
               "Register-OPSRdsDbInstance",
               "Register-OPSVolume",
               "Set-OPSLoadBasedAutoScaling",
               "Set-OPSPermission",
               "Set-OPSTimeBasedAutoScaling",
               "Start-OPSInstance",
               "Start-OPSStack",
               "Stop-OPSInstance",
               "Stop-OPSStack",
               "Add-OPSResourceTag",
               "Unregister-OPSInstanceAssignment",
               "Remove-OPSVolume",
               "Remove-OPSResourceTag",
               "Update-OPSApp",
               "Update-OPSElasticIp",
               "Update-OPSInstance",
               "Update-OPSLayer",
               "Update-OPSMyUserProfile",
               "Update-OPSRdsDbInstance",
               "Update-OPSStack",
               "Update-OPSUserProfile",
               "Update-OPSVolume")
}

_awsArgumentCompleterRegistration $OPS_SelectCompleters $OPS_SelectMap

