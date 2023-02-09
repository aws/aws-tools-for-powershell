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

# Argument completions for service AWS Migration Hub Refactor Spaces


$MHRS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.MigrationHubRefactorSpaces.ApiGatewayEndpointType
        "New-MHRSApplication/ApiGatewayProxy_EndpointType"
        {
            $v = "PRIVATE","REGIONAL"
            break
        }

        # Amazon.MigrationHubRefactorSpaces.NetworkFabricType
        "New-MHRSEnvironment/NetworkFabricType"
        {
            $v = "NONE","TRANSIT_GATEWAY"
            break
        }

        # Amazon.MigrationHubRefactorSpaces.ProxyType
        "New-MHRSApplication/ProxyType"
        {
            $v = "API_GATEWAY"
            break
        }

        # Amazon.MigrationHubRefactorSpaces.RouteActivationState
        {
            ($_ -eq "Update-MHRSRoute/ActivationState") -Or
            ($_ -eq "New-MHRSRoute/DefaultRoute_ActivationState") -Or
            ($_ -eq "New-MHRSRoute/UriPathRoute_ActivationState")
        }
        {
            $v = "ACTIVE","INACTIVE"
            break
        }

        # Amazon.MigrationHubRefactorSpaces.RouteType
        "New-MHRSRoute/RouteType"
        {
            $v = "DEFAULT","URI_PATH"
            break
        }

        # Amazon.MigrationHubRefactorSpaces.ServiceEndpointType
        "New-MHRSService/EndpointType"
        {
            $v = "LAMBDA","URL"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$MHRS_map = @{
    "ActivationState"=@("Update-MHRSRoute")
    "ApiGatewayProxy_EndpointType"=@("New-MHRSApplication")
    "DefaultRoute_ActivationState"=@("New-MHRSRoute")
    "EndpointType"=@("New-MHRSService")
    "NetworkFabricType"=@("New-MHRSEnvironment")
    "ProxyType"=@("New-MHRSApplication")
    "RouteType"=@("New-MHRSRoute")
    "UriPathRoute_ActivationState"=@("New-MHRSRoute")
}

_awsArgumentCompleterRegistration $MHRS_Completers $MHRS_map

$MHRS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.MHRS.$($commandName.Replace('-', ''))Cmdlet]"
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

$MHRS_SelectMap = @{
    "Select"=@("New-MHRSApplication",
               "New-MHRSEnvironment",
               "New-MHRSRoute",
               "New-MHRSService",
               "Remove-MHRSApplication",
               "Remove-MHRSEnvironment",
               "Remove-MHRSResourcePolicy",
               "Remove-MHRSRoute",
               "Remove-MHRSService",
               "Get-MHRSApplication",
               "Get-MHRSEnvironment",
               "Get-MHRSResourcePolicy",
               "Get-MHRSRoute",
               "Get-MHRSService",
               "Get-MHRSApplicationList",
               "Get-MHRSEnvironmentList",
               "Get-MHRSEnvironmentVpcList",
               "Get-MHRSRouteList",
               "Get-MHRSServiceList",
               "Get-MHRSResourceTag",
               "Write-MHRSResourcePolicy",
               "Add-MHRSResourceTag",
               "Remove-MHRSResourceTag",
               "Update-MHRSRoute")
}

_awsArgumentCompleterRegistration $MHRS_SelectCompleters $MHRS_SelectMap

