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

# Argument completions for service Amazon API Gateway V2


$AG2_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.ApiGatewayV2.AuthorizationType
        {
            ($_ -eq "New-AG2Route/AuthorizationType") -Or
            ($_ -eq "Update-AG2Route/AuthorizationType")
        }
        {
            $v = "AWS_IAM","CUSTOM","JWT","NONE"
            break
        }

        # Amazon.ApiGatewayV2.AuthorizerType
        {
            ($_ -eq "New-AG2Authorizer/AuthorizerType") -Or
            ($_ -eq "Update-AG2Authorizer/AuthorizerType")
        }
        {
            $v = "JWT","REQUEST"
            break
        }

        # Amazon.ApiGatewayV2.ConnectionType
        {
            ($_ -eq "New-AG2Integration/ConnectionType") -Or
            ($_ -eq "Update-AG2Integration/ConnectionType")
        }
        {
            $v = "INTERNET","VPC_LINK"
            break
        }

        # Amazon.ApiGatewayV2.ContentHandlingStrategy
        {
            ($_ -eq "New-AG2Integration/ContentHandlingStrategy") -Or
            ($_ -eq "New-AG2IntegrationResponse/ContentHandlingStrategy") -Or
            ($_ -eq "Update-AG2Integration/ContentHandlingStrategy") -Or
            ($_ -eq "Update-AG2IntegrationResponse/ContentHandlingStrategy")
        }
        {
            $v = "CONVERT_TO_BINARY","CONVERT_TO_TEXT"
            break
        }

        # Amazon.ApiGatewayV2.IntegrationType
        {
            ($_ -eq "New-AG2Integration/IntegrationType") -Or
            ($_ -eq "Update-AG2Integration/IntegrationType")
        }
        {
            $v = "AWS","AWS_PROXY","HTTP","HTTP_PROXY","MOCK"
            break
        }

        # Amazon.ApiGatewayV2.IpAddressType
        {
            ($_ -eq "New-AG2Api/IpAddressType") -Or
            ($_ -eq "Update-AG2Api/IpAddressType")
        }
        {
            $v = "dualstack","ipv4"
            break
        }

        # Amazon.ApiGatewayV2.LoggingLevel
        {
            ($_ -eq "New-AG2Stage/DefaultRouteSettings_LoggingLevel") -Or
            ($_ -eq "Update-AG2Stage/DefaultRouteSettings_LoggingLevel")
        }
        {
            $v = "ERROR","INFO","OFF"
            break
        }

        # Amazon.ApiGatewayV2.PassthroughBehavior
        {
            ($_ -eq "New-AG2Integration/PassthroughBehavior") -Or
            ($_ -eq "Update-AG2Integration/PassthroughBehavior")
        }
        {
            $v = "NEVER","WHEN_NO_MATCH","WHEN_NO_TEMPLATES"
            break
        }

        # Amazon.ApiGatewayV2.ProtocolType
        "New-AG2Api/ProtocolType"
        {
            $v = "HTTP","WEBSOCKET"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$AG2_map = @{
    "AuthorizationType"=@("New-AG2Route","Update-AG2Route")
    "AuthorizerType"=@("New-AG2Authorizer","Update-AG2Authorizer")
    "ConnectionType"=@("New-AG2Integration","Update-AG2Integration")
    "ContentHandlingStrategy"=@("New-AG2Integration","New-AG2IntegrationResponse","Update-AG2Integration","Update-AG2IntegrationResponse")
    "DefaultRouteSettings_LoggingLevel"=@("New-AG2Stage","Update-AG2Stage")
    "IntegrationType"=@("New-AG2Integration","Update-AG2Integration")
    "IpAddressType"=@("New-AG2Api","Update-AG2Api")
    "PassthroughBehavior"=@("New-AG2Integration","Update-AG2Integration")
    "ProtocolType"=@("New-AG2Api")
}

_awsArgumentCompleterRegistration $AG2_Completers $AG2_map

$AG2_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.AG2.$($commandName.Replace('-', ''))Cmdlet]"
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

$AG2_SelectMap = @{
    "Select"=@("New-AG2Api",
               "New-AG2ApiMapping",
               "New-AG2Authorizer",
               "New-AG2Deployment",
               "New-AG2DomainName",
               "New-AG2Integration",
               "New-AG2IntegrationResponse",
               "New-AG2Model",
               "New-AG2Route",
               "New-AG2RouteResponse",
               "New-AG2Stage",
               "New-AG2VpcLink",
               "Remove-AG2AccessLogSetting",
               "Remove-AG2Api",
               "Remove-AG2ApiMapping",
               "Remove-AG2Authorizer",
               "Remove-AG2CorsConfiguration",
               "Remove-AG2Deployment",
               "Remove-AG2DomainName",
               "Remove-AG2Integration",
               "Remove-AG2IntegrationResponse",
               "Remove-AG2Model",
               "Remove-AG2Route",
               "Remove-AG2RouteRequestParameter",
               "Remove-AG2RouteResponse",
               "Remove-AG2RouteSetting",
               "Remove-AG2Stage",
               "Remove-AG2VpcLink",
               "Export-AG2Api",
               "Get-AG2Api",
               "Get-AG2ApiMapping",
               "Get-AG2ApiMappingList",
               "Get-AG2ApiList",
               "Get-AG2Authorizer",
               "Get-AG2AuthorizerList",
               "Get-AG2Deployment",
               "Get-AG2DeploymentList",
               "Get-AG2DomainName",
               "Get-AG2DomainNameList",
               "Get-AG2Integration",
               "Get-AG2IntegrationResponse",
               "Get-AG2IntegrationResponseList",
               "Get-AG2IntegrationList",
               "Get-AG2Model",
               "Get-AG2ModelList",
               "Get-AG2ModelTemplate",
               "Get-AG2Route",
               "Get-AG2RouteResponse",
               "Get-AG2RouteResponseList",
               "Get-AG2RouteList",
               "Get-AG2Stage",
               "Get-AG2StageList",
               "Get-AG2Tag",
               "Get-AG2VpcLink",
               "Get-AG2VpcLinkList",
               "Import-AG2Api",
               "Update-AG2ApiImport",
               "Reset-AG2AuthorizersCache",
               "Add-AG2ResourceTag",
               "Remove-AG2ResourceTag",
               "Update-AG2Api",
               "Update-AG2ApiMapping",
               "Update-AG2Authorizer",
               "Update-AG2Deployment",
               "Update-AG2DomainName",
               "Update-AG2Integration",
               "Update-AG2IntegrationResponse",
               "Update-AG2Model",
               "Update-AG2Route",
               "Update-AG2RouteResponse",
               "Update-AG2Stage",
               "Update-AG2VpcLink")
}

_awsArgumentCompleterRegistration $AG2_SelectCompleters $AG2_SelectMap

