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
        # Amazon.BedrockAgentCoreControl.ActorTokenContentType
        {
            ($_ -eq "New-BACCOauth2CredentialProvider/Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenContent") -Or
            ($_ -eq "Update-BACCOauth2CredentialProvider/Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenContent")
        }
        {
            $v = "AWS_IAM_ID_TOKEN_JWT","M2M","NONE"
            break
        }

        # Amazon.BedrockAgentCoreControl.AgentManagedRuntimeType
        {
            ($_ -eq "New-BACCAgentRuntime/CodeConfiguration_Runtime") -Or
            ($_ -eq "Update-BACCAgentRuntime/CodeConfiguration_Runtime")
        }
        {
            $v = "NODE_22","PYTHON_3_10","PYTHON_3_11","PYTHON_3_12","PYTHON_3_13","PYTHON_3_14"
            break
        }

        # Amazon.BedrockAgentCoreControl.AuthorizerType
        {
            ($_ -eq "New-BACCGateway/AuthorizerType") -Or
            ($_ -eq "Update-BACCGateway/AuthorizerType")
        }
        {
            $v = "AUTHENTICATE_ONLY","AWS_IAM","CUSTOM_JWT","NONE"
            break
        }

        # Amazon.BedrockAgentCoreControl.BrowserNetworkMode
        "New-BACCBrowser/NetworkConfiguration_NetworkMode"
        {
            $v = "PUBLIC","VPC"
            break
        }

        # Amazon.BedrockAgentCoreControl.ClientAuthenticationMethodType
        {
            ($_ -eq "New-BACCOauth2CredentialProvider/Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientAuthenticationMethod") -Or
            ($_ -eq "Update-BACCOauth2CredentialProvider/Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientAuthenticationMethod")
        }
        {
            $v = "AWS_IAM_ID_TOKEN_JWT","CLIENT_SECRET_BASIC","CLIENT_SECRET_POST"
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
            $v = "AtlassianOauth2","Auth0Oauth2","CognitoOauth2","CustomOauth2","CyberArkOauth2","DropboxOauth2","FacebookOauth2","FusionAuthOauth2","GithubOauth2","GoogleOauth2","HubspotOauth2","LinkedinOauth2","MicrosoftOauth2","NotionOauth2","OktaOauth2","OneLoginOauth2","PingOneOauth2","RedditOauth2","SalesforceOauth2","SlackOauth2","SpotifyOauth2","TwitchOauth2","XOauth2","YandexOauth2","ZoomOauth2"
            break
        }

        # Amazon.BedrockAgentCoreControl.DescriptorType
        {
            ($_ -eq "Get-BACCRegistryRecordList/DescriptorType") -Or
            ($_ -eq "New-BACCRegistryRecord/DescriptorType") -Or
            ($_ -eq "Update-BACCRegistryRecord/DescriptorType")
        }
        {
            $v = "A2A","AGENT_SKILLS","CUSTOM","MCP"
            break
        }

        # Amazon.BedrockAgentCoreControl.EndpointIpAddressType
        {
            ($_ -eq "New-BACCAgentRuntime/AuthorizerConfiguration_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType") -Or
            ($_ -eq "New-BACCGateway/AuthorizerConfiguration_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType") -Or
            ($_ -eq "New-BACCHarness/AuthorizerConfiguration_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType") -Or
            ($_ -eq "New-BACCPaymentManager/AuthorizerConfiguration_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType") -Or
            ($_ -eq "New-BACCRegistry/AuthorizerConfiguration_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType") -Or
            ($_ -eq "Update-BACCAgentRuntime/AuthorizerConfiguration_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType") -Or
            ($_ -eq "Update-BACCGateway/AuthorizerConfiguration_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType") -Or
            ($_ -eq "Update-BACCPaymentManager/AuthorizerConfiguration_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType") -Or
            ($_ -eq "Update-BACCHarness/AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType") -Or
            ($_ -eq "Update-BACCRegistry/AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType") -Or
            ($_ -eq "New-BACCOauth2CredentialProvider/Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType") -Or
            ($_ -eq "Update-BACCOauth2CredentialProvider/Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType") -Or
            ($_ -eq "New-BACCGatewayTarget/PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType") -Or
            ($_ -eq "Update-BACCGatewayTarget/PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType")
        }
        {
            $v = "IPV4","IPV6"
            break
        }

        # Amazon.BedrockAgentCoreControl.EvaluatorLevel
        {
            ($_ -eq "New-BACCEvaluator/Level") -Or
            ($_ -eq "Update-BACCEvaluator/Level")
        }
        {
            $v = "SESSION","TOOL_CALL","TRACE"
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

        # Amazon.BedrockAgentCoreControl.GatewayPolicyEngineMode
        {
            ($_ -eq "New-BACCGateway/PolicyEngineConfiguration_Mode") -Or
            ($_ -eq "Update-BACCGateway/PolicyEngineConfiguration_Mode")
        }
        {
            $v = "ENFORCE","LOG_ONLY"
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

        # Amazon.BedrockAgentCoreControl.HarnessTruncationStrategy
        {
            ($_ -eq "New-BACCHarness/Truncation_Strategy") -Or
            ($_ -eq "Update-BACCHarness/Truncation_Strategy")
        }
        {
            $v = "none","sliding_window","summarization"
            break
        }

        # Amazon.BedrockAgentCoreControl.IncludedData
        "Get-BACCEvaluator/IncludedData"
        {
            $v = "ALL_DATA","METADATA_ONLY"
            break
        }

        # Amazon.BedrockAgentCoreControl.KeyType
        "Set-BACCTokenVaultCMK/KmsConfiguration_KeyType"
        {
            $v = "CustomerManagedKey","ServiceManagedKey"
            break
        }

        # Amazon.BedrockAgentCoreControl.ListingMode
        {
            ($_ -eq "New-BACCGatewayTarget/TargetConfiguration_Mcp_McpServer_ListingMode") -Or
            ($_ -eq "Update-BACCGatewayTarget/TargetConfiguration_Mcp_McpServer_ListingMode")
        }
        {
            $v = "DEFAULT","DYNAMIC"
            break
        }

        # Amazon.BedrockAgentCoreControl.MemoryView
        "Get-BACCMemory/View"
        {
            $v = "full","without_decryption"
            break
        }

        # Amazon.BedrockAgentCoreControl.NetworkMode
        {
            ($_ -eq "New-BACCHarness/Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkMode") -Or
            ($_ -eq "Update-BACCHarness/Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkMode") -Or
            ($_ -eq "New-BACCAgentRuntime/NetworkConfiguration_NetworkMode") -Or
            ($_ -eq "Update-BACCAgentRuntime/NetworkConfiguration_NetworkMode")
        }
        {
            $v = "PUBLIC","VPC"
            break
        }

        # Amazon.BedrockAgentCoreControl.OnBehalfOfTokenExchangeGrantTypeType
        {
            ($_ -eq "New-BACCOauth2CredentialProvider/Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_GrantType") -Or
            ($_ -eq "Update-BACCOauth2CredentialProvider/Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_GrantType")
        }
        {
            $v = "JWT_AUTHORIZATION_GRANT","TOKEN_EXCHANGE"
            break
        }

        # Amazon.BedrockAgentCoreControl.OnlineEvaluationExecutionStatus
        "Update-BACCOnlineEvaluationConfig/ExecutionStatus"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.BedrockAgentCoreControl.PaymentConnectorType
        {
            ($_ -eq "New-BACCPaymentConnector/Type") -Or
            ($_ -eq "Update-BACCPaymentConnector/Type")
        }
        {
            $v = "CoinbaseCDP","StripePrivy"
            break
        }

        # Amazon.BedrockAgentCoreControl.PaymentCredentialProviderVendorType
        {
            ($_ -eq "New-BACCPaymentCredentialProvider/CredentialProviderVendor") -Or
            ($_ -eq "Update-BACCPaymentCredentialProvider/CredentialProviderVendor")
        }
        {
            $v = "CoinbaseCDP","StripePrivy"
            break
        }

        # Amazon.BedrockAgentCoreControl.PaymentsAuthorizerType
        {
            ($_ -eq "New-BACCPaymentManager/AuthorizerType") -Or
            ($_ -eq "Update-BACCPaymentManager/AuthorizerType")
        }
        {
            $v = "AWS_IAM","CUSTOM_JWT"
            break
        }

        # Amazon.BedrockAgentCoreControl.PolicyValidationMode
        {
            ($_ -eq "New-BACCPolicy/ValidationMode") -Or
            ($_ -eq "Update-BACCPolicy/ValidationMode")
        }
        {
            $v = "FAIL_ON_ANY_FINDINGS","IGNORE_ALL_FINDINGS"
            break
        }

        # Amazon.BedrockAgentCoreControl.RegistryAuthorizerType
        "New-BACCRegistry/AuthorizerType"
        {
            $v = "AWS_IAM","CUSTOM_JWT"
            break
        }

        # Amazon.BedrockAgentCoreControl.RegistryRecordStatus
        {
            ($_ -eq "Get-BACCRegistryRecordList/Status") -Or
            ($_ -eq "Update-BACCRegistryRecordStatus/Status")
        }
        {
            $v = "APPROVED","CREATE_FAILED","CREATING","DEPRECATED","DRAFT","PENDING_APPROVAL","REJECTED","UPDATE_FAILED","UPDATING"
            break
        }

        # Amazon.BedrockAgentCoreControl.RegistryStatus
        "Get-BACCRegistryList/Status"
        {
            $v = "CREATE_FAILED","CREATING","DELETE_FAILED","DELETING","READY","UPDATE_FAILED","UPDATING"
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
            $v = "A2A","AGUI","HTTP","MCP"
            break
        }

        # Amazon.BedrockAgentCoreControl.SynchronizationType
        {
            ($_ -eq "New-BACCRegistryRecord/SynchronizationType") -Or
            ($_ -eq "Update-BACCRegistryRecord/SynchronizationType_OptionalValue")
        }
        {
            $v = "URL"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$BACC_map = @{
    "AuthorizerConfiguration_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType"=@("New-BACCAgentRuntime","New-BACCGateway","New-BACCHarness","New-BACCPaymentManager","New-BACCRegistry","Update-BACCAgentRuntime","Update-BACCGateway","Update-BACCPaymentManager")
    "AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType"=@("Update-BACCHarness","Update-BACCRegistry")
    "AuthorizerType"=@("New-BACCGateway","New-BACCPaymentManager","New-BACCRegistry","Update-BACCGateway","Update-BACCPaymentManager")
    "CodeConfiguration_Runtime"=@("New-BACCAgentRuntime","Update-BACCAgentRuntime")
    "CredentialProviderVendor"=@("New-BACCOauth2CredentialProvider","New-BACCPaymentCredentialProvider","Update-BACCOauth2CredentialProvider","Update-BACCPaymentCredentialProvider")
    "DescriptorType"=@("Get-BACCRegistryRecordList","New-BACCRegistryRecord","Update-BACCRegistryRecord")
    "Environment_AgentCoreRuntimeEnvironment_NetworkConfiguration_NetworkMode"=@("New-BACCHarness","Update-BACCHarness")
    "ExceptionLevel"=@("New-BACCGateway","Update-BACCGateway")
    "ExecutionStatus"=@("Update-BACCOnlineEvaluationConfig")
    "IncludedData"=@("Get-BACCEvaluator")
    "KmsConfiguration_KeyType"=@("Set-BACCTokenVaultCMK")
    "Level"=@("New-BACCEvaluator","Update-BACCEvaluator")
    "Mcp_SearchType"=@("New-BACCGateway","Update-BACCGateway")
    "NetworkConfiguration_NetworkMode"=@("New-BACCAgentRuntime","New-BACCBrowser","New-BACCCodeInterpreter","Update-BACCAgentRuntime")
    "Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_ClientAuthenticationMethod"=@("New-BACCOauth2CredentialProvider","Update-BACCOauth2CredentialProvider")
    "Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_GrantType"=@("New-BACCOauth2CredentialProvider","Update-BACCOauth2CredentialProvider")
    "Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_OnBehalfOfTokenExchangeConfig_TokenExchangeGrantTypeConfig_ActorTokenContent"=@("New-BACCOauth2CredentialProvider","Update-BACCOauth2CredentialProvider")
    "Oauth2ProviderConfigInput_CustomOauth2ProviderConfig_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType"=@("New-BACCOauth2CredentialProvider","Update-BACCOauth2CredentialProvider")
    "PolicyEngineConfiguration_Mode"=@("New-BACCGateway","Update-BACCGateway")
    "PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType"=@("New-BACCGatewayTarget","Update-BACCGatewayTarget")
    "ProtocolConfiguration_ServerProtocol"=@("New-BACCAgentRuntime","Update-BACCAgentRuntime")
    "ProtocolType"=@("New-BACCGateway","Update-BACCGateway")
    "Status"=@("Get-BACCRegistryList","Get-BACCRegistryRecordList","Update-BACCRegistryRecordStatus")
    "SynchronizationType"=@("New-BACCRegistryRecord")
    "SynchronizationType_OptionalValue"=@("Update-BACCRegistryRecord")
    "TargetConfiguration_Mcp_McpServer_ListingMode"=@("New-BACCGatewayTarget","Update-BACCGatewayTarget")
    "Truncation_Strategy"=@("New-BACCHarness","Update-BACCHarness")
    "Type"=@("Get-BACCBrowserList","Get-BACCCodeInterpreterList","New-BACCPaymentConnector","Update-BACCPaymentConnector")
    "ValidationMode"=@("New-BACCPolicy","Update-BACCPolicy")
    "View"=@("Get-BACCMemory")
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
               "New-BACCBrowserProfile",
               "New-BACCCodeInterpreter",
               "New-BACCConfigurationBundle",
               "New-BACCEvaluator",
               "New-BACCGateway",
               "New-BACCGatewayRule",
               "New-BACCGatewayTarget",
               "New-BACCHarness",
               "New-BACCMemory",
               "New-BACCOauth2CredentialProvider",
               "New-BACCOnlineEvaluationConfig",
               "New-BACCPaymentConnector",
               "New-BACCPaymentCredentialProvider",
               "New-BACCPaymentManager",
               "New-BACCPolicy",
               "New-BACCPolicyEngine",
               "New-BACCRegistry",
               "New-BACCRegistryRecord",
               "New-BACCWorkloadIdentity",
               "Remove-BACCAgentRuntime",
               "Remove-BACCAgentRuntimeEndpoint",
               "Remove-BACCApiKeyCredentialProvider",
               "Remove-BACCBrowser",
               "Remove-BACCBrowserProfile",
               "Remove-BACCCodeInterpreter",
               "Remove-BACCConfigurationBundle",
               "Remove-BACCEvaluator",
               "Remove-BACCGateway",
               "Remove-BACCGatewayRule",
               "Remove-BACCGatewayTarget",
               "Remove-BACCHarness",
               "Remove-BACCMemory",
               "Remove-BACCOauth2CredentialProvider",
               "Remove-BACCOnlineEvaluationConfig",
               "Remove-BACCPaymentConnector",
               "Remove-BACCPaymentCredentialProvider",
               "Remove-BACCPaymentManager",
               "Remove-BACCPolicy",
               "Remove-BACCPolicyEngine",
               "Remove-BACCRegistry",
               "Remove-BACCRegistryRecord",
               "Remove-BACCResourcePolicy",
               "Remove-BACCWorkloadIdentity",
               "Get-BACCAgentRuntime",
               "Get-BACCAgentRuntimeEndpoint",
               "Get-BACCApiKeyCredentialProvider",
               "Get-BACCBrowser",
               "Get-BACCBrowserProfile",
               "Get-BACCCodeInterpreter",
               "Get-BACCConfigurationBundle",
               "Get-BACCConfigurationBundleVersion",
               "Get-BACCEvaluator",
               "Get-BACCGateway",
               "Get-BACCGatewayRule",
               "Get-BACCGatewayTarget",
               "Get-BACCHarness",
               "Get-BACCMemory",
               "Get-BACCOauth2CredentialProvider",
               "Get-BACCOnlineEvaluationConfig",
               "Get-BACCPaymentConnector",
               "Get-BACCPaymentCredentialProvider",
               "Get-BACCPaymentManager",
               "Get-BACCPolicy",
               "Get-BACCPolicyEngine",
               "Get-BACCPolicyGeneration",
               "Get-BACCRegistry",
               "Get-BACCRegistryRecord",
               "Get-BACCResourcePolicy",
               "Get-BACCTokenVault",
               "Get-BACCWorkloadIdentity",
               "Get-BACCAgentRuntimeEndpointList",
               "Get-BACCAgentRuntimeList",
               "Get-BACCAgentRuntimeVersionList",
               "Get-BACCApiKeyCredentialProviderList",
               "Get-BACCBrowserProfileList",
               "Get-BACCBrowserList",
               "Get-BACCCodeInterpreterList",
               "Get-BACCConfigurationBundleList",
               "Get-BACCConfigurationBundleVersionList",
               "Get-BACCEvaluatorList",
               "Get-BACCGatewayRuleList",
               "Get-BACCGatewayList",
               "Get-BACCGatewayTargetList",
               "Get-BACCHarnessList",
               "Get-BACCMemoryList",
               "Get-BACCOauth2CredentialProviderList",
               "Get-BACCOnlineEvaluationConfigList",
               "Get-BACCPaymentConnectorList",
               "Get-BACCPaymentCredentialProviderList",
               "Get-BACCPaymentManagerList",
               "Get-BACCPolicyList",
               "Get-BACCPolicyEngineList",
               "Get-BACCPolicyGenerationAssetList",
               "Get-BACCPolicyGenerationList",
               "Get-BACCRegistryList",
               "Get-BACCRegistryRecordList",
               "Get-BACCResourceTag",
               "Get-BACCWorkloadIdentityList",
               "Write-BACCResourcePolicy",
               "Set-BACCTokenVaultCMK",
               "Start-BACCPolicyGeneration",
               "Submit-BACCRegistryRecordForApproval",
               "Sync-BACCGatewayTarget",
               "Add-BACCResourceTag",
               "Remove-BACCResourceTag",
               "Update-BACCAgentRuntime",
               "Update-BACCAgentRuntimeEndpoint",
               "Update-BACCApiKeyCredentialProvider",
               "Update-BACCConfigurationBundle",
               "Update-BACCEvaluator",
               "Update-BACCGateway",
               "Update-BACCGatewayRule",
               "Update-BACCGatewayTarget",
               "Update-BACCHarness",
               "Update-BACCMemory",
               "Update-BACCOauth2CredentialProvider",
               "Update-BACCOnlineEvaluationConfig",
               "Update-BACCPaymentConnector",
               "Update-BACCPaymentCredentialProvider",
               "Update-BACCPaymentManager",
               "Update-BACCPolicy",
               "Update-BACCPolicyEngine",
               "Update-BACCRegistry",
               "Update-BACCRegistryRecord",
               "Update-BACCRegistryRecordStatus",
               "Update-BACCWorkloadIdentity")
}

_awsArgumentCompleterRegistration $BACC_SelectCompleters $BACC_SelectMap

