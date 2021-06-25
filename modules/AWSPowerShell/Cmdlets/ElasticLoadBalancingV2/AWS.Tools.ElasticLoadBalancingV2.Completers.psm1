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

# Argument completions for service Elastic Load Balancing V2


$ELB2_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ElasticLoadBalancingV2.IpAddressType
        {
            ($_ -eq "New-ELB2LoadBalancer/IpAddressType") -Or
            ($_ -eq "Set-ELB2IpAddressType/IpAddressType") -Or
            ($_ -eq "Set-ELB2Subnet/IpAddressType")
        }
        {
            $v = "dualstack","ipv4"
            break
        }

        # Amazon.ElasticLoadBalancingV2.LoadBalancerSchemeEnum
        "New-ELB2LoadBalancer/Scheme"
        {
            $v = "internal","internet-facing"
            break
        }

        # Amazon.ElasticLoadBalancingV2.LoadBalancerTypeEnum
        "New-ELB2LoadBalancer/Type"
        {
            $v = "application","gateway","network"
            break
        }

        # Amazon.ElasticLoadBalancingV2.ProtocolEnum
        {
            ($_ -eq "Edit-ELB2TargetGroup/HealthCheckProtocol") -Or
            ($_ -eq "New-ELB2TargetGroup/HealthCheckProtocol") -Or
            ($_ -eq "Edit-ELB2Listener/Protocol") -Or
            ($_ -eq "New-ELB2Listener/Protocol") -Or
            ($_ -eq "New-ELB2TargetGroup/Protocol")
        }
        {
            $v = "GENEVE","HTTP","HTTPS","TCP","TCP_UDP","TLS","UDP"
            break
        }

        # Amazon.ElasticLoadBalancingV2.TargetTypeEnum
        "New-ELB2TargetGroup/TargetType"
        {
            $v = "alb","instance","ip","lambda"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$ELB2_map = @{
    "HealthCheckProtocol"=@("Edit-ELB2TargetGroup","New-ELB2TargetGroup")
    "IpAddressType"=@("New-ELB2LoadBalancer","Set-ELB2IpAddressType","Set-ELB2Subnet")
    "Protocol"=@("Edit-ELB2Listener","New-ELB2Listener","New-ELB2TargetGroup")
    "Scheme"=@("New-ELB2LoadBalancer")
    "TargetType"=@("New-ELB2TargetGroup")
    "Type"=@("New-ELB2LoadBalancer")
}

_awsArgumentCompleterRegistration $ELB2_Completers $ELB2_map

$ELB2_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.ELB2.$($commandName.Replace('-', ''))Cmdlet]"
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

$ELB2_SelectMap = @{
    "Select"=@("Add-ELB2ListenerCertificate",
               "Add-ELB2Tag",
               "New-ELB2Listener",
               "New-ELB2LoadBalancer",
               "New-ELB2Rule",
               "New-ELB2TargetGroup",
               "Remove-ELB2Listener",
               "Remove-ELB2LoadBalancer",
               "Remove-ELB2Rule",
               "Remove-ELB2TargetGroup",
               "Unregister-ELB2Target",
               "Get-ELB2AccountLimit",
               "Get-ELB2ListenerCertificate",
               "Get-ELB2Listener",
               "Get-ELB2LoadBalancerAttribute",
               "Get-ELB2LoadBalancer",
               "Get-ELB2Rule",
               "Get-ELB2SSLPolicy",
               "Get-ELB2Tag",
               "Get-ELB2TargetGroupAttribute",
               "Get-ELB2TargetGroup",
               "Get-ELB2TargetHealth",
               "Edit-ELB2Listener",
               "Edit-ELB2LoadBalancerAttribute",
               "Edit-ELB2Rule",
               "Edit-ELB2TargetGroup",
               "Edit-ELB2TargetGroupAttribute",
               "Register-ELB2Target",
               "Remove-ELB2ListenerCertificate",
               "Remove-ELB2Tag",
               "Set-ELB2IpAddressType",
               "Set-ELB2RulePriority",
               "Set-ELB2SecurityGroup",
               "Set-ELB2Subnet")
}

_awsArgumentCompleterRegistration $ELB2_SelectCompleters $ELB2_SelectMap

