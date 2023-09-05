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

# Argument completions for service VPC Lattice


$VPCL_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.VPCLattice.AuthType
        {
            ($_ -eq "New-VPCLService/AuthType") -Or
            ($_ -eq "New-VPCLServiceNetwork/AuthType") -Or
            ($_ -eq "Update-VPCLService/AuthType") -Or
            ($_ -eq "Update-VPCLServiceNetwork/AuthType")
        }
        {
            $v = "AWS_IAM","NONE"
            break
        }

        # Amazon.VPCLattice.HealthCheckProtocolVersion
        {
            ($_ -eq "New-VPCLTargetGroup/Config_HealthCheck_ProtocolVersion") -Or
            ($_ -eq "Update-VPCLTargetGroup/HealthCheck_ProtocolVersion")
        }
        {
            $v = "HTTP1","HTTP2"
            break
        }

        # Amazon.VPCLattice.IpAddressType
        "New-VPCLTargetGroup/Config_IpAddressType"
        {
            $v = "IPV4","IPV6"
            break
        }

        # Amazon.VPCLattice.LambdaEventStructureVersion
        "New-VPCLTargetGroup/Config_LambdaEventStructureVersion"
        {
            $v = "V1","V2"
            break
        }

        # Amazon.VPCLattice.ListenerProtocol
        "New-VPCLListener/Protocol"
        {
            $v = "HTTP","HTTPS"
            break
        }

        # Amazon.VPCLattice.TargetGroupProtocol
        {
            ($_ -eq "New-VPCLTargetGroup/Config_HealthCheck_Protocol") -Or
            ($_ -eq "New-VPCLTargetGroup/Config_Protocol") -Or
            ($_ -eq "Update-VPCLTargetGroup/HealthCheck_Protocol")
        }
        {
            $v = "HTTP","HTTPS"
            break
        }

        # Amazon.VPCLattice.TargetGroupProtocolVersion
        "New-VPCLTargetGroup/Config_ProtocolVersion"
        {
            $v = "GRPC","HTTP1","HTTP2"
            break
        }

        # Amazon.VPCLattice.TargetGroupType
        {
            ($_ -eq "Get-VPCLTargetGroupList/TargetGroupType") -Or
            ($_ -eq "New-VPCLTargetGroup/Type")
        }
        {
            $v = "ALB","INSTANCE","IP","LAMBDA"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$VPCL_map = @{
    "AuthType"=@("New-VPCLService","New-VPCLServiceNetwork","Update-VPCLService","Update-VPCLServiceNetwork")
    "Config_HealthCheck_Protocol"=@("New-VPCLTargetGroup")
    "Config_HealthCheck_ProtocolVersion"=@("New-VPCLTargetGroup")
    "Config_IpAddressType"=@("New-VPCLTargetGroup")
    "Config_LambdaEventStructureVersion"=@("New-VPCLTargetGroup")
    "Config_Protocol"=@("New-VPCLTargetGroup")
    "Config_ProtocolVersion"=@("New-VPCLTargetGroup")
    "HealthCheck_Protocol"=@("Update-VPCLTargetGroup")
    "HealthCheck_ProtocolVersion"=@("Update-VPCLTargetGroup")
    "Protocol"=@("New-VPCLListener")
    "TargetGroupType"=@("Get-VPCLTargetGroupList")
    "Type"=@("New-VPCLTargetGroup")
}

_awsArgumentCompleterRegistration $VPCL_Completers $VPCL_map

$VPCL_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.VPCL.$($commandName.Replace('-', ''))Cmdlet]"
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

$VPCL_SelectMap = @{
    "Select"=@("Update-VPCLRuleList",
               "New-VPCLAccessLogSubscription",
               "New-VPCLListener",
               "New-VPCLRule",
               "New-VPCLService",
               "New-VPCLServiceNetwork",
               "New-VPCLServiceNetworkServiceAssociation",
               "New-VPCLServiceNetworkVpcAssociation",
               "New-VPCLTargetGroup",
               "Remove-VPCLAccessLogSubscription",
               "Remove-VPCLAuthPolicy",
               "Remove-VPCLListener",
               "Remove-VPCLResourcePolicy",
               "Remove-VPCLRule",
               "Remove-VPCLService",
               "Remove-VPCLServiceNetwork",
               "Remove-VPCLServiceNetworkServiceAssociation",
               "Remove-VPCLServiceNetworkVpcAssociation",
               "Remove-VPCLTargetGroup",
               "Unregister-VPCLTarget",
               "Get-VPCLAccessLogSubscription",
               "Get-VPCLAuthPolicy",
               "Get-VPCLListener",
               "Get-VPCLResourcePolicy",
               "Get-VPCLRule",
               "Get-VPCLService",
               "Get-VPCLServiceNetwork",
               "Get-VPCLServiceNetworkServiceAssociation",
               "Get-VPCLServiceNetworkVpcAssociation",
               "Get-VPCLTargetGroup",
               "Get-VPCLAccessLogSubscriptionList",
               "Get-VPCLListenerList",
               "Get-VPCLRuleList",
               "Get-VPCLServiceNetworkList",
               "Get-VPCLServiceNetworkServiceAssociationList",
               "Get-VPCLServiceNetworkVpcAssociationList",
               "Get-VPCLServiceList",
               "Get-VPCLResourceTag",
               "Get-VPCLTargetGroupList",
               "Get-VPCLTargetList",
               "Write-VPCLAuthPolicy",
               "Write-VPCLResourcePolicy",
               "Register-VPCLTarget",
               "Add-VPCLResourceTag",
               "Remove-VPCLResourceTag",
               "Update-VPCLAccessLogSubscription",
               "Update-VPCLListener",
               "Update-VPCLRule",
               "Update-VPCLService",
               "Update-VPCLServiceNetwork",
               "Update-VPCLServiceNetworkVpcAssociation",
               "Update-VPCLTargetGroup")
}

_awsArgumentCompleterRegistration $VPCL_SelectCompleters $VPCL_SelectMap

