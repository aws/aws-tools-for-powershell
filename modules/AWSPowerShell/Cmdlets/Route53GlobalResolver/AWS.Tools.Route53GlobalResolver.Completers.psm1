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

# Argument completions for service Amazon Route 53 Global Resolver


$R53GR_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Route53GlobalResolver.BlockOverrideDnsQueryType
        {
            ($_ -eq "New-R53GRFirewallRule/BlockOverrideDnsType") -Or
            ($_ -eq "Update-R53GRFirewallRule/BlockOverrideDnsType")
        }
        {
            $v = "CNAME"
            break
        }

        # Amazon.Route53GlobalResolver.ConfidenceThreshold
        {
            ($_ -eq "New-R53GRFirewallRule/ConfidenceThreshold") -Or
            ($_ -eq "Update-R53GRFirewallRule/ConfidenceThreshold")
        }
        {
            $v = "HIGH","LOW","MEDIUM"
            break
        }

        # Amazon.Route53GlobalResolver.DnsAdvancedProtection
        {
            ($_ -eq "New-R53GRFirewallRule/DnsAdvancedProtection") -Or
            ($_ -eq "Update-R53GRFirewallRule/DnsAdvancedProtection")
        }
        {
            $v = "DGA","DNS_TUNNELING"
            break
        }

        # Amazon.Route53GlobalResolver.DnsProtocol
        {
            ($_ -eq "New-R53GRAccessSource/Protocol") -Or
            ($_ -eq "Update-R53GRAccessSource/Protocol")
        }
        {
            $v = "DO53","DOH","DOT"
            break
        }

        # Amazon.Route53GlobalResolver.DnsSecValidationType
        {
            ($_ -eq "New-R53GRDNSView/DnssecValidation") -Or
            ($_ -eq "Update-R53GRDNSView/DnssecValidation")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.Route53GlobalResolver.EdnsClientSubnetType
        {
            ($_ -eq "New-R53GRDNSView/EdnsClientSubnet") -Or
            ($_ -eq "Update-R53GRDNSView/EdnsClientSubnet")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.Route53GlobalResolver.FirewallBlockResponse
        {
            ($_ -eq "New-R53GRFirewallRule/BlockResponse") -Or
            ($_ -eq "Update-R53GRFirewallRule/BlockResponse")
        }
        {
            $v = "NODATA","NXDOMAIN","OVERRIDE"
            break
        }

        # Amazon.Route53GlobalResolver.FirewallRuleAction
        {
            ($_ -eq "New-R53GRFirewallRule/Action") -Or
            ($_ -eq "Update-R53GRFirewallRule/Action")
        }
        {
            $v = "ALERT","ALLOW","BLOCK"
            break
        }

        # Amazon.Route53GlobalResolver.FirewallRulesFailOpenType
        {
            ($_ -eq "New-R53GRDNSView/FirewallRulesFailOpen") -Or
            ($_ -eq "Update-R53GRDNSView/FirewallRulesFailOpen")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.Route53GlobalResolver.IpAddressType
        {
            ($_ -eq "New-R53GRAccessSource/IpAddressType") -Or
            ($_ -eq "Update-R53GRAccessSource/IpAddressType")
        }
        {
            $v = "IPV4","IPV6"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$R53GR_map = @{
    "Action"=@("New-R53GRFirewallRule","Update-R53GRFirewallRule")
    "BlockOverrideDnsType"=@("New-R53GRFirewallRule","Update-R53GRFirewallRule")
    "BlockResponse"=@("New-R53GRFirewallRule","Update-R53GRFirewallRule")
    "ConfidenceThreshold"=@("New-R53GRFirewallRule","Update-R53GRFirewallRule")
    "DnsAdvancedProtection"=@("New-R53GRFirewallRule","Update-R53GRFirewallRule")
    "DnssecValidation"=@("New-R53GRDNSView","Update-R53GRDNSView")
    "EdnsClientSubnet"=@("New-R53GRDNSView","Update-R53GRDNSView")
    "FirewallRulesFailOpen"=@("New-R53GRDNSView","Update-R53GRDNSView")
    "IpAddressType"=@("New-R53GRAccessSource","Update-R53GRAccessSource")
    "Protocol"=@("New-R53GRAccessSource","Update-R53GRAccessSource")
}

_awsArgumentCompleterRegistration $R53GR_Completers $R53GR_map

$R53GR_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.R53GR.$($commandName.Replace('-', ''))Cmdlet]"
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

$R53GR_SelectMap = @{
    "Select"=@("New-R53GRHostedZoneAssociation",
               "New-R53GRFirewallRuleBatch",
               "Remove-R53GRFirewallRuleBatch",
               "Update-R53GRFirewallRuleBatch",
               "New-R53GRAccessSource",
               "New-R53GRAccessToken",
               "New-R53GRDNSView",
               "New-R53GRFirewallDomainList",
               "New-R53GRFirewallRule",
               "New-R53GRGlobalResolver",
               "Remove-R53GRAccessSource",
               "Remove-R53GRAccessToken",
               "Remove-R53GRDNSView",
               "Remove-R53GRFirewallDomainList",
               "Remove-R53GRFirewallRule",
               "Remove-R53GRGlobalResolver",
               "Disable-R53GRDNSView",
               "Remove-R53GRHostedZoneAssociation",
               "Enable-R53GRDNSView",
               "Get-R53GRAccessSource",
               "Get-R53GRAccessToken",
               "Get-R53GRDNSView",
               "Get-R53GRFirewallDomainList",
               "Get-R53GRFirewallRule",
               "Get-R53GRGlobalResolver",
               "Get-R53GRHostedZoneAssociation",
               "Get-R53GRManagedFirewallDomainList",
               "Import-R53GRFirewallDomainList",
               "Get-R53GRAccessSourceList",
               "Get-R53GRAccessTokenList",
               "Get-R53GRDNSViewList",
               "Get-R53GRFirewallDomainListList",
               "Get-R53GRFirewallDomain",
               "Get-R53GRFirewallRuleList",
               "Get-R53GRGlobalResolverList",
               "Get-R53GRHostedZoneAssociationList",
               "Get-R53GRManagedFirewallDomainListList",
               "Get-R53GRResourceTagList",
               "Add-R53GRResourceTag",
               "Remove-R53GRResourceTag",
               "Update-R53GRAccessSource",
               "Update-R53GRAccessToken",
               "Update-R53GRDNSView",
               "Edit-R53GRFirewallDomain",
               "Update-R53GRFirewallRule",
               "Update-R53GRGlobalResolver",
               "Update-R53GRHostedZoneAssociation")
}

_awsArgumentCompleterRegistration $R53GR_SelectCompleters $R53GR_SelectMap

