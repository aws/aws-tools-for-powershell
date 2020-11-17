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

# Argument completions for service Amazon Route 53 Resolver


$R53R_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.Route53Resolver.ResolverEndpointDirection
        "New-R53RResolverEndpoint/Direction"
        {
            $v = "INBOUND","OUTBOUND"
            break
        }

        # Amazon.Route53Resolver.RuleTypeOption
        "New-R53RResolverRule/RuleType"
        {
            $v = "FORWARD","RECURSIVE","SYSTEM"
            break
        }

        # Amazon.Route53Resolver.SortOrder
        {
            ($_ -eq "Get-R53RResolverQueryLogConfigAssociationList/SortOrder") -Or
            ($_ -eq "Get-R53RResolverQueryLogConfigList/SortOrder")
        }
        {
            $v = "ASCENDING","DESCENDING"
            break
        }

        # Amazon.Route53Resolver.Validation
        "Update-R53RResolverDnssecConfig/Validation"
        {
            $v = "DISABLE","ENABLE"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$R53R_map = @{
    "Direction"=@("New-R53RResolverEndpoint")
    "RuleType"=@("New-R53RResolverRule")
    "SortOrder"=@("Get-R53RResolverQueryLogConfigAssociationList","Get-R53RResolverQueryLogConfigList")
    "Validation"=@("Update-R53RResolverDnssecConfig")
}

_awsArgumentCompleterRegistration $R53R_Completers $R53R_map

$R53R_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.R53R.$($commandName.Replace('-', ''))Cmdlet]"
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

$R53R_SelectMap = @{
    "Select"=@("Add-R53RResolverEndpointIpAddressAssociation",
               "Add-R53RResolverQueryLogConfigAssociation",
               "Add-R53RResolverRuleAssociation",
               "New-R53RResolverEndpoint",
               "New-R53RResolverQueryLogConfig",
               "New-R53RResolverRule",
               "Remove-R53RResolverEndpoint",
               "Remove-R53RResolverQueryLogConfig",
               "Remove-R53RResolverRule",
               "Remove-R53RResolverEndpointIpAddressAssociation",
               "Remove-R53RResolverQueryLogConfigAssociation",
               "Remove-R53RResolverRuleAssociation",
               "Get-R53RResolverDnssecConfig",
               "Get-R53RResolverEndpoint",
               "Get-R53RResolverQueryLogConfig",
               "Get-R53RResolverQueryLogConfigAssociation",
               "Get-R53RResolverQueryLogConfigPolicy",
               "Get-R53RResolverRule",
               "Get-R53RResolverRuleAssociation",
               "Get-R53RResolverRulePolicy",
               "Get-R53RResolverDnssecConfigList",
               "Get-R53RResolverEndpointIpAddressList",
               "Get-R53RResolverEndpointList",
               "Get-R53RResolverQueryLogConfigAssociationList",
               "Get-R53RResolverQueryLogConfigList",
               "Get-R53RResolverRuleAssociationList",
               "Get-R53RResolverRuleList",
               "Get-R53RResourceTagList",
               "Write-R53RResolverQueryLogConfigPolicy",
               "Set-R53RResolverRulePolicy",
               "Add-R53RResourceTag",
               "Remove-R53RResourceTag",
               "Update-R53RResolverDnssecConfig",
               "Update-R53RResolverEndpoint",
               "Update-R53RResolverRule")
}

_awsArgumentCompleterRegistration $R53R_SelectCompleters $R53R_SelectMap

