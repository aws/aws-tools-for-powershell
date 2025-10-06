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

# Argument completions for service Amazon Bedrock Agent Core Control Plane Fronting Layer


$BACC_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.BedrockAgentCoreControl.AuthorizerType
        {
            ($_ -eq "New-BACCGateway/AuthorizerType") -Or
            ($_ -eq "Update-BACCGateway/AuthorizerType")
        }
        {
            $v = "CUSTOM_JWT"
            break
        }

        # Amazon.BedrockAgentCoreControl.BrowserNetworkMode
        "New-BACCBrowser/NetworkConfiguration_NetworkMode"
        {
            $v = "PUBLIC","VPC"
            break
        }

        # Amazon.BedrockAgentCoreControl.CodeInterpreterNetworkMode
        "New-BACCCodeInterpreter/NetworkConfiguration_NetworkMode"
        {
            $v = "PUBLIC","SANDBOX","VPC"
            break
        }

        # Amazon.BedrockAgentCoreControl.CredentialProviderVendorType
        {
            ($_ -eq "New-BACCOauth2CredentialProvider/CredentialProviderVendor") -Or
            ($_ -eq "Update-BACCOauth2CredentialProvider/CredentialProviderVendor")
        }
        {
            $v = "CustomOauth2","GithubOauth2","GoogleOauth2","MicrosoftOauth2","SalesforceOauth2","SlackOauth2"
            break
        }

        # Amazon.BedrockAgentCoreControl.ExceptionLevel
        {
            ($_ -eq "New-BACCGateway/ExceptionLevel") -Or
            ($_ -eq "Update-BACCGateway/ExceptionLevel")
        }
        {
            $v = "DEBUG"
            break
        }

        # Amazon.BedrockAgentCoreControl.GatewayProtocolType
        {
            ($_ -eq "New-BACCGateway/ProtocolType") -Or
            ($_ -eq "Update-BACCGateway/ProtocolType")
        }
        {
            $v = "MCP"
            break
        }

        # Amazon.BedrockAgentCoreControl.KeyType
        "Set-BACCTokenVaultCMK/KmsConfiguration_KeyType"
        {
            $v = "CustomerManagedKey","ServiceManagedKey"
            break
        }

        # Amazon.BedrockAgentCoreControl.NetworkMode
        {
            ($_ -eq "New-BACCAgentRuntime/NetworkConfiguration_NetworkMode") -Or
            ($_ -eq "Update-BACCAgentRuntime/NetworkConfiguration_NetworkMode")
        }
        {
            $v = "PUBLIC","VPC"
            break
        }

        # Amazon.BedrockAgentCoreControl.ResourceType
        {
            ($_ -eq "Get-BACCBrowserList/Type") -Or
            ($_ -eq "Get-BACCCodeInterpreterList/Type")
        }
        {
            $v = "CUSTOM","SYSTEM"
            break
        }

        # Amazon.BedrockAgentCoreControl.SearchType
        {
            ($_ -eq "New-BACCGateway/Mcp_SearchType") -Or
            ($_ -eq "Update-BACCGateway/Mcp_SearchType")
        }
        {
            $v = "SEMANTIC"
            break
        }

        # Amazon.BedrockAgentCoreControl.ServerProtocol
        {
            ($_ -eq "New-BACCAgentRuntime/ProtocolConfiguration_ServerProtocol") -Or
            ($_ -eq "Update-BACCAgentRuntime/ProtocolConfiguration_ServerProtocol")
        }
        {
            $v = "A2A","HTTP","MCP"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$BACC_map = @{
    "AuthorizerType"=@("New-BACCGateway","Update-BACCGateway")
    "CredentialProviderVendor"=@("New-BACCOauth2CredentialProvider","Update-BACCOauth2CredentialProvider")
    "ExceptionLevel"=@("New-BACCGateway","Update-BACCGateway")
    "KmsConfiguration_KeyType"=@("Set-BACCTokenVaultCMK")
    "Mcp_SearchType"=@("New-BACCGateway","Update-BACCGateway")
    "NetworkConfiguration_NetworkMode"=@("New-BACCAgentRuntime","New-BACCBrowser","New-BACCCodeInterpreter","Update-BACCAgentRuntime")
    "ProtocolConfiguration_ServerProtocol"=@("New-BACCAgentRuntime","Update-BACCAgentRuntime")
    "ProtocolType"=@("New-BACCGateway","Update-BACCGateway")
    "Type"=@("Get-BACCBrowserList","Get-BACCCodeInterpreterList")
}

_awsArgumentCompleterRegistration $BACC_Completers $BACC_map

$BACC_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.BACC.$($commandName.Replace('-', ''))Cmdlet]"
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

$BACC_SelectMap = @{
    "Select"=@("New-BACCAgentRuntime",
               "New-BACCAgentRuntimeEndpoint",
               "New-BACCApiKeyCredentialProvider",
               "New-BACCBrowser",
               "New-BACCCodeInterpreter",
               "New-BACCGateway",
               "New-BACCGatewayTarget",
               "New-BACCMemory",
               "New-BACCOauth2CredentialProvider",
               "New-BACCWorkloadIdentity",
               "Remove-BACCAgentRuntime",
               "Remove-BACCAgentRuntimeEndpoint",
               "Remove-BACCApiKeyCredentialProvider",
               "Remove-BACCBrowser",
               "Remove-BACCCodeInterpreter",
               "Remove-BACCGateway",
               "Remove-BACCGatewayTarget",
               "Remove-BACCMemory",
               "Remove-BACCOauth2CredentialProvider",
               "Remove-BACCWorkloadIdentity",
               "Get-BACCAgentRuntime",
               "Get-BACCAgentRuntimeEndpoint",
               "Get-BACCApiKeyCredentialProvider",
               "Get-BACCBrowser",
               "Get-BACCCodeInterpreter",
               "Get-BACCGateway",
               "Get-BACCGatewayTarget",
               "Get-BACCMemory",
               "Get-BACCOauth2CredentialProvider",
               "Get-BACCTokenVault",
               "Get-BACCWorkloadIdentity",
               "Get-BACCAgentRuntimeEndpointList",
               "Get-BACCAgentRuntimeList",
               "Get-BACCAgentRuntimeVersionList",
               "Get-BACCApiKeyCredentialProviderList",
               "Get-BACCBrowserList",
               "Get-BACCCodeInterpreterList",
               "Get-BACCGatewayList",
               "Get-BACCGatewayTargetList",
               "Get-BACCMemoryList",
               "Get-BACCOauth2CredentialProviderList",
               "Get-BACCResourceTag",
               "Get-BACCWorkloadIdentityList",
               "Set-BACCTokenVaultCMK",
               "Add-BACCResourceTag",
               "Remove-BACCResourceTag",
               "Update-BACCAgentRuntime",
               "Update-BACCAgentRuntimeEndpoint",
               "Update-BACCApiKeyCredentialProvider",
               "Update-BACCGateway",
               "Update-BACCGatewayTarget",
               "Update-BACCMemory",
               "Update-BACCOauth2CredentialProvider",
               "Update-BACCWorkloadIdentity")
}

_awsArgumentCompleterRegistration $BACC_SelectCompleters $BACC_SelectMap

