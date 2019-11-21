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

# Argument completions for service AWS App Mesh


$AMSH_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.AppMesh.DurationUnit
        {
            ($_ -eq "New-AMSHRoute/Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Unit") -Or
            ($_ -eq "Update-AMSHRoute/Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Unit") -Or
            ($_ -eq "New-AMSHRoute/Spec_Http2Route_RetryPolicy_PerRetryTimeout_Unit") -Or
            ($_ -eq "Update-AMSHRoute/Spec_Http2Route_RetryPolicy_PerRetryTimeout_Unit") -Or
            ($_ -eq "New-AMSHRoute/Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Unit") -Or
            ($_ -eq "Update-AMSHRoute/Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Unit")
        }
        {
            $v = "ms","s"
            break
        }

        # Amazon.AppMesh.EgressFilterType
        {
            ($_ -eq "New-AMSHMesh/Spec_EgressFilter_Type") -Or
            ($_ -eq "Update-AMSHMesh/Spec_EgressFilter_Type")
        }
        {
            $v = "ALLOW_ALL","DROP_ALL"
            break
        }

        # Amazon.AppMesh.HttpMethod
        {
            ($_ -eq "New-AMSHRoute/Spec_Http2Route_Match_Method") -Or
            ($_ -eq "Update-AMSHRoute/Spec_Http2Route_Match_Method") -Or
            ($_ -eq "New-AMSHRoute/Spec_HttpRoute_Match_Method") -Or
            ($_ -eq "Update-AMSHRoute/Spec_HttpRoute_Match_Method")
        }
        {
            $v = "CONNECT","DELETE","GET","HEAD","OPTIONS","PATCH","POST","PUT","TRACE"
            break
        }

        # Amazon.AppMesh.HttpScheme
        {
            ($_ -eq "New-AMSHRoute/Spec_Http2Route_Match_Scheme") -Or
            ($_ -eq "Update-AMSHRoute/Spec_Http2Route_Match_Scheme") -Or
            ($_ -eq "New-AMSHRoute/Spec_HttpRoute_Match_Scheme") -Or
            ($_ -eq "Update-AMSHRoute/Spec_HttpRoute_Match_Scheme")
        }
        {
            $v = "http","https"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$AMSH_map = @{
    "Spec_EgressFilter_Type"=@("New-AMSHMesh","Update-AMSHMesh")
    "Spec_GrpcRoute_RetryPolicy_PerRetryTimeout_Unit"=@("New-AMSHRoute","Update-AMSHRoute")
    "Spec_Http2Route_Match_Method"=@("New-AMSHRoute","Update-AMSHRoute")
    "Spec_Http2Route_Match_Scheme"=@("New-AMSHRoute","Update-AMSHRoute")
    "Spec_Http2Route_RetryPolicy_PerRetryTimeout_Unit"=@("New-AMSHRoute","Update-AMSHRoute")
    "Spec_HttpRoute_Match_Method"=@("New-AMSHRoute","Update-AMSHRoute")
    "Spec_HttpRoute_Match_Scheme"=@("New-AMSHRoute","Update-AMSHRoute")
    "Spec_HttpRoute_RetryPolicy_PerRetryTimeout_Unit"=@("New-AMSHRoute","Update-AMSHRoute")
}

_awsArgumentCompleterRegistration $AMSH_Completers $AMSH_map

$AMSH_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.AMSH.$($commandName.Replace('-', ''))Cmdlet]"
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

$AMSH_SelectMap = @{
    "Select"=@("New-AMSHMesh",
               "New-AMSHRoute",
               "New-AMSHVirtualNode",
               "New-AMSHVirtualRouter",
               "New-AMSHVirtualService",
               "Remove-AMSHMesh",
               "Remove-AMSHRoute",
               "Remove-AMSHVirtualNode",
               "Remove-AMSHVirtualRouter",
               "Remove-AMSHVirtualService",
               "Get-AMSHMesh",
               "Get-AMSHRoute",
               "Get-AMSHVirtualNode",
               "Get-AMSHVirtualRouter",
               "Get-AMSHVirtualService",
               "Get-AMSHMeshList",
               "Get-AMSHRouteList",
               "Get-AMSHResourceTag",
               "Get-AMSHVirtualNodeList",
               "Get-AMSHVirtualRouterList",
               "Get-AMSHVirtualServiceList",
               "Add-AMSHResourceTag",
               "Remove-AMSHResourceTag",
               "Update-AMSHMesh",
               "Update-AMSHRoute",
               "Update-AMSHVirtualNode",
               "Update-AMSHVirtualRouter",
               "Update-AMSHVirtualService")
}

_awsArgumentCompleterRegistration $AMSH_SelectCompleters $AMSH_SelectMap

