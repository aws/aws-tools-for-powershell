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

# Argument completions for service Lambda Web


$LWEB_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.LambdaWeb.ApplicationLogLevel
        {
            ($_ -eq "New-LWEBWebFunction/RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel") -Or
            ($_ -eq "New-LWEBWebFunctionRevision/ServiceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel")
        }
        {
            $v = "DEBUG","ERROR","FATAL","INFO","TRACE","WARN"
            break
        }

        # Amazon.LambdaWeb.AuthType
        {
            ($_ -eq "New-LWEBWebFunctionEndpoint/AuthType") -Or
            ($_ -eq "Update-LWEBWebFunctionEndpoint/AuthType") -Or
            ($_ -eq "New-LWEBWebFunction/EndpointConfig_AuthType")
        }
        {
            $v = "ApplicationManaged","IamAuth"
            break
        }

        # Amazon.LambdaWeb.AutoDeploymentMode
        {
            ($_ -eq "New-LWEBWebFunctionEndpoint/AutoDeploymentMode") -Or
            ($_ -eq "Update-LWEBWebFunctionEndpoint/AutoDeploymentMode") -Or
            ($_ -eq "New-LWEBWebFunction/EndpointConfig_AutoDeploymentMode")
        }
        {
            $v = "Disabled","LatestRevision"
            break
        }

        # Amazon.LambdaWeb.EndpointType
        {
            ($_ -eq "New-LWEBWebFunction/EndpointConfig_EndpointType") -Or
            ($_ -eq "New-LWEBWebFunctionEndpoint/EndpointType")
        }
        {
            $v = "HomeRegion","MultiRegion","PerRegion"
            break
        }

        # Amazon.LambdaWeb.SystemLogLevel
        {
            ($_ -eq "New-LWEBWebFunction/RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel") -Or
            ($_ -eq "New-LWEBWebFunctionRevision/ServiceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel")
        }
        {
            $v = "DEBUG","INFO","WARN"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$LWEB_map = @{
    "AuthType"=@("New-LWEBWebFunctionEndpoint","Update-LWEBWebFunctionEndpoint")
    "AutoDeploymentMode"=@("New-LWEBWebFunctionEndpoint","Update-LWEBWebFunctionEndpoint")
    "EndpointConfig_AuthType"=@("New-LWEBWebFunction")
    "EndpointConfig_AutoDeploymentMode"=@("New-LWEBWebFunction")
    "EndpointConfig_EndpointType"=@("New-LWEBWebFunction")
    "EndpointType"=@("New-LWEBWebFunctionEndpoint")
    "RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel"=@("New-LWEBWebFunction")
    "RevisionConfig_ServiceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel"=@("New-LWEBWebFunction")
    "ServiceConfig_TelemetryConfig_LoggingConfig_ApplicationLogLevel"=@("New-LWEBWebFunctionRevision")
    "ServiceConfig_TelemetryConfig_LoggingConfig_SystemLogLevel"=@("New-LWEBWebFunctionRevision")
}

_awsArgumentCompleterRegistration $LWEB_Completers $LWEB_map

$LWEB_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.LWEB.$($commandName.Replace('-', ''))Cmdlet]"
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

$LWEB_SelectMap = @{
    "Select"=@("New-LWEBWebFunction",
               "New-LWEBWebFunctionEndpoint",
               "New-LWEBWebFunctionRevision",
               "Remove-LWEBResourcePolicy",
               "Remove-LWEBWebFunction",
               "Remove-LWEBWebFunctionEndpoint",
               "Remove-LWEBWebFunctionRevision",
               "Get-LWEBResourcePolicy",
               "Get-LWEBWebAccountSetting",
               "Get-LWEBWebFunction",
               "Get-LWEBWebFunctionEndpoint",
               "Get-LWEBWebFunctionRevision",
               "Get-LWEBTag",
               "Get-LWEBWebFunctionEndpointList",
               "Get-LWEBWebFunctionRevisionList",
               "Get-LWEBWebFunctionList",
               "Write-LWEBResourcePolicy",
               "Add-LWEBResourceTag",
               "Remove-LWEBResourceTag",
               "Update-LWEBWebFunctionEndpoint")
}

_awsArgumentCompleterRegistration $LWEB_SelectCompleters $LWEB_SelectMap

