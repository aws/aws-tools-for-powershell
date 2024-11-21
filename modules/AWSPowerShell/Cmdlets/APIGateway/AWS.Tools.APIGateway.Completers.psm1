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

# Argument completions for service Amazon API Gateway


$AG_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.APIGateway.AccessAssociationSourceType
        "New-AGDomainNameAccessAssociation/AccessAssociationSourceType"
        {
            $v = "VPCE"
            break
        }

        # Amazon.APIGateway.ApiKeysFormat
        "Import-AGApiKey/Format"
        {
            $v = "csv"
            break
        }

        # Amazon.APIGateway.ApiKeySourceType
        "New-AGRestApi/ApiKeySource"
        {
            $v = "AUTHORIZER","HEADER"
            break
        }

        # Amazon.APIGateway.AuthorizerType
        "New-AGAuthorizer/Type"
        {
            $v = "COGNITO_USER_POOLS","REQUEST","TOKEN"
            break
        }

        # Amazon.APIGateway.CacheClusterSize
        {
            ($_ -eq "New-AGDeployment/CacheClusterSize") -Or
            ($_ -eq "New-AGStage/CacheClusterSize")
        }
        {
            $v = "0.5","1.6","118","13.5","237","28.4","58.2","6.1"
            break
        }

        # Amazon.APIGateway.ConnectionType
        "Write-AGIntegration/ConnectionType"
        {
            $v = "INTERNET","VPC_LINK"
            break
        }

        # Amazon.APIGateway.ContentHandlingStrategy
        {
            ($_ -eq "Write-AGIntegration/ContentHandling") -Or
            ($_ -eq "Write-AGIntegrationResponse/ContentHandling")
        }
        {
            $v = "CONVERT_TO_BINARY","CONVERT_TO_TEXT"
            break
        }

        # Amazon.APIGateway.DocumentationPartType
        {
            ($_ -eq "New-AGDocumentationPart/Location_Type") -Or
            ($_ -eq "Get-AGDocumentationPartList/Type")
        }
        {
            $v = "API","AUTHORIZER","METHOD","MODEL","PATH_PARAMETER","QUERY_PARAMETER","REQUEST_BODY","REQUEST_HEADER","RESOURCE","RESPONSE","RESPONSE_BODY","RESPONSE_HEADER"
            break
        }

        # Amazon.APIGateway.GatewayResponseType
        {
            ($_ -eq "Get-AGGatewayResponse/ResponseType") -Or
            ($_ -eq "Remove-AGGatewayResponse/ResponseType") -Or
            ($_ -eq "Update-AGGatewayResponse/ResponseType") -Or
            ($_ -eq "Write-AGGatewayResponse/ResponseType")
        }
        {
            $v = "ACCESS_DENIED","API_CONFIGURATION_ERROR","AUTHORIZER_CONFIGURATION_ERROR","AUTHORIZER_FAILURE","BAD_REQUEST_BODY","BAD_REQUEST_PARAMETERS","DEFAULT_4XX","DEFAULT_5XX","EXPIRED_TOKEN","INTEGRATION_FAILURE","INTEGRATION_TIMEOUT","INVALID_API_KEY","INVALID_SIGNATURE","MISSING_AUTHENTICATION_TOKEN","QUOTA_EXCEEDED","REQUEST_TOO_LARGE","RESOURCE_NOT_FOUND","THROTTLED","UNAUTHORIZED","UNSUPPORTED_MEDIA_TYPE","WAF_FILTERED"
            break
        }

        # Amazon.APIGateway.IntegrationType
        "Write-AGIntegration/Type"
        {
            $v = "AWS","AWS_PROXY","HTTP","HTTP_PROXY","MOCK"
            break
        }

        # Amazon.APIGateway.LocationStatusType
        "Get-AGDocumentationPartList/LocationStatus"
        {
            $v = "DOCUMENTED","UNDOCUMENTED"
            break
        }

        # Amazon.APIGateway.PutMode
        {
            ($_ -eq "Import-AGDocumentationPartList/Mode") -Or
            ($_ -eq "Write-AGRestApi/Mode")
        }
        {
            $v = "merge","overwrite"
            break
        }

        # Amazon.APIGateway.QuotaPeriodType
        "New-AGUsagePlan/Quota_Period"
        {
            $v = "DAY","MONTH","WEEK"
            break
        }

        # Amazon.APIGateway.ResourceOwner
        {
            ($_ -eq "Get-AGDomainNameAccessAssociation/ResourceOwner") -Or
            ($_ -eq "Get-AGDomainNameList/ResourceOwner")
        }
        {
            $v = "OTHER_ACCOUNTS","SELF"
            break
        }

        # Amazon.APIGateway.SecurityPolicy
        "New-AGDomainName/SecurityPolicy"
        {
            $v = "TLS_1_0","TLS_1_2"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$AG_map = @{
    "AccessAssociationSourceType"=@("New-AGDomainNameAccessAssociation")
    "ApiKeySource"=@("New-AGRestApi")
    "CacheClusterSize"=@("New-AGDeployment","New-AGStage")
    "ConnectionType"=@("Write-AGIntegration")
    "ContentHandling"=@("Write-AGIntegration","Write-AGIntegrationResponse")
    "Format"=@("Import-AGApiKey")
    "Location_Type"=@("New-AGDocumentationPart")
    "LocationStatus"=@("Get-AGDocumentationPartList")
    "Mode"=@("Import-AGDocumentationPartList","Write-AGRestApi")
    "Quota_Period"=@("New-AGUsagePlan")
    "ResourceOwner"=@("Get-AGDomainNameAccessAssociation","Get-AGDomainNameList")
    "ResponseType"=@("Get-AGGatewayResponse","Remove-AGGatewayResponse","Update-AGGatewayResponse","Write-AGGatewayResponse")
    "SecurityPolicy"=@("New-AGDomainName")
    "Type"=@("Get-AGDocumentationPartList","New-AGAuthorizer","Write-AGIntegration")
}

_awsArgumentCompleterRegistration $AG_Completers $AG_map

$AG_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.AG.$($commandName.Replace('-', ''))Cmdlet]"
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

$AG_SelectMap = @{
    "Select"=@("New-AGApiKey",
               "New-AGAuthorizer",
               "New-AGBasePathMapping",
               "New-AGDeployment",
               "New-AGDocumentationPart",
               "New-AGDocumentationVersion",
               "New-AGDomainName",
               "New-AGDomainNameAccessAssociation",
               "New-AGModel",
               "New-AGRequestValidator",
               "New-AGResource",
               "New-AGRestApi",
               "New-AGStage",
               "New-AGUsagePlan",
               "New-AGUsagePlanKey",
               "New-AGVpcLink",
               "Remove-AGApiKey",
               "Remove-AGAuthorizer",
               "Remove-AGBasePathMapping",
               "Remove-AGClientCertificate",
               "Remove-AGDeployment",
               "Remove-AGDocumentationPart",
               "Remove-AGDocumentationVersion",
               "Remove-AGDomainName",
               "Remove-AGDomainNameAccessAssociation",
               "Remove-AGGatewayResponse",
               "Remove-AGIntegration",
               "Remove-AGIntegrationResponse",
               "Remove-AGMethod",
               "Remove-AGMethodResponse",
               "Remove-AGModel",
               "Remove-AGRequestValidator",
               "Remove-AGResource",
               "Remove-AGRestApi",
               "Remove-AGStage",
               "Remove-AGUsagePlan",
               "Remove-AGUsagePlanKey",
               "Remove-AGVpcLink",
               "Clear-AGStageAuthorizersCache",
               "Clear-AGStageCache",
               "New-AGClientCertificate",
               "Get-AGAccount",
               "Get-AGApiKey",
               "Get-AGApiKeyList",
               "Get-AGAuthorizer",
               "Get-AGAuthorizerList",
               "Get-AGBasePathMapping",
               "Get-AGBasePathMappingList",
               "Get-AGClientCertificate",
               "Get-AGClientCertificateList",
               "Get-AGDeployment",
               "Get-AGDeploymentList",
               "Get-AGDocumentationPart",
               "Get-AGDocumentationPartList",
               "Get-AGDocumentationVersion",
               "Get-AGDocumentationVersionList",
               "Get-AGDomainName",
               "Get-AGDomainNameAccessAssociation",
               "Get-AGDomainNameList",
               "Get-AGExport",
               "Get-AGGatewayResponse",
               "Get-AGGatewayResponseList",
               "Get-AGIntegration",
               "Get-AGIntegrationResponse",
               "Get-AGMethod",
               "Get-AGMethodResponse",
               "Get-AGModel",
               "Get-AGModelList",
               "Get-AGModelTemplate",
               "Get-AGRequestValidator",
               "Get-AGValidatorList",
               "Get-AGResource",
               "Get-AGResourceList",
               "Get-AGRestApi",
               "Get-AGRestApiList",
               "Get-AGSdk",
               "Get-AGSdkType",
               "Get-AGSdkTypeList",
               "Get-AGStage",
               "Get-AGStageList",
               "Get-AGResourceTag",
               "Get-AGUsage",
               "Get-AGUsagePlan",
               "Get-AGUsagePlanKey",
               "Get-AGUsagePlanKeyList",
               "Get-AGUsagePlanList",
               "Get-AGVpcLink",
               "Get-AGVpcLinkList",
               "Import-AGApiKey",
               "Import-AGDocumentationPartList",
               "Import-AGRestApi",
               "Write-AGGatewayResponse",
               "Write-AGIntegration",
               "Write-AGIntegrationResponse",
               "Write-AGMethod",
               "Write-AGMethodResponse",
               "Write-AGRestApi",
               "Disable-AGDomainNameAccessAssociation",
               "Add-AGResourceTag",
               "Test-AGInvokeAuthorizer",
               "Test-AGInvokeMethod",
               "Remove-AGResourceTag",
               "Update-AGAccount",
               "Update-AGApiKey",
               "Update-AGAuthorizer",
               "Update-AGBasePathMapping",
               "Update-AGClientCertificate",
               "Update-AGDeployment",
               "Update-AGDocumentationPart",
               "Update-AGDocumentationVersion",
               "Update-AGDomainName",
               "Update-AGGatewayResponse",
               "Update-AGIntegration",
               "Update-AGIntegrationResponse",
               "Update-AGMethod",
               "Update-AGMethodResponse",
               "Update-AGModel",
               "Update-AGRequestValidator",
               "Update-AGResource",
               "Update-AGRestApi",
               "Update-AGStage",
               "Update-AGUsage",
               "Update-AGUsagePlan",
               "Update-AGVpcLink")
}

_awsArgumentCompleterRegistration $AG_SelectCompleters $AG_SelectMap

