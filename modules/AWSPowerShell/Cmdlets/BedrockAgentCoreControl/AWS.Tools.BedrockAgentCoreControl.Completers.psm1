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
        # Amazon.BedrockAgentCoreControl.AgentManagedRuntimeType
        {
            ($_ -eq "New-BACCAgentRuntime/CodeConfiguration_Runtime") -Or
            ($_ -eq "Update-BACCAgentRuntime/CodeConfiguration_Runtime")
        }
        {
            $v = "PYTHON_3_10","PYTHON_3_11","PYTHON_3_12","PYTHON_3_13"
            break
        }

        # Amazon.BedrockAgentCoreControl.AuthorizerType
        {
            ($_ -eq "New-BACCGateway/AuthorizerType") -Or
            ($_ -eq "Update-BACCGateway/AuthorizerType")
        }
        {
            $v = "AWS_IAM","CUSTOM_JWT","NONE"
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
            $v = "AtlassianOauth2","Auth0Oauth2","CognitoOauth2","CustomOauth2","CyberArkOauth2","DropboxOauth2","FacebookOauth2","FusionAuthOauth2","GithubOauth2","GoogleOauth2","HubspotOauth2","LinkedinOauth2","MicrosoftOauth2","NotionOauth2","OktaOauth2","OneLoginOauth2","PingOneOauth2","RedditOauth2","SalesforceOauth2","SlackOauth2","SpotifyOauth2","TwitchOauth2","XOauth2","YandexOauth2","ZoomOauth2"
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

        # Amazon.BedrockAgentCoreControl.KeyType
        "Set-BACCTokenVaultCMK/KmsConfiguration_KeyType"
        {
            $v = "CustomerManagedKey","ServiceManagedKey"
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
            ($_ -eq "New-BACCAgentRuntime/NetworkConfiguration_NetworkMode") -Or
            ($_ -eq "Update-BACCAgentRuntime/NetworkConfiguration_NetworkMode")
        }
        {
            $v = "PUBLIC","VPC"
            break
        }

        # Amazon.BedrockAgentCoreControl.OnlineEvaluationExecutionStatus
        "Update-BACCOnlineEvaluationConfig/ExecutionStatus"
        {
            $v = "DISABLED","ENABLED"
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
    "CodeConfiguration_Runtime"=@("New-BACCAgentRuntime","Update-BACCAgentRuntime")
    "CredentialProviderVendor"=@("New-BACCOauth2CredentialProvider","Update-BACCOauth2CredentialProvider")
    "ExceptionLevel"=@("New-BACCGateway","Update-BACCGateway")
    "ExecutionStatus"=@("Update-BACCOnlineEvaluationConfig")
    "KmsConfiguration_KeyType"=@("Set-BACCTokenVaultCMK")
    "Level"=@("New-BACCEvaluator","Update-BACCEvaluator")
    "Mcp_SearchType"=@("New-BACCGateway","Update-BACCGateway")
    "NetworkConfiguration_NetworkMode"=@("New-BACCAgentRuntime","New-BACCBrowser","New-BACCCodeInterpreter","Update-BACCAgentRuntime")
    "PolicyEngineConfiguration_Mode"=@("New-BACCGateway","Update-BACCGateway")
    "ProtocolConfiguration_ServerProtocol"=@("New-BACCAgentRuntime","Update-BACCAgentRuntime")
    "ProtocolType"=@("New-BACCGateway","Update-BACCGateway")
    "Type"=@("Get-BACCBrowserList","Get-BACCCodeInterpreterList")
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
               "New-BACCEvaluator",
               "New-BACCGateway",
               "New-BACCGatewayTarget",
               "New-BACCMemory",
               "New-BACCOauth2CredentialProvider",
               "New-BACCOnlineEvaluationConfig",
               "New-BACCPolicy",
               "New-BACCPolicyEngine",
               "New-BACCWorkloadIdentity",
               "Remove-BACCAgentRuntime",
               "Remove-BACCAgentRuntimeEndpoint",
               "Remove-BACCApiKeyCredentialProvider",
               "Remove-BACCBrowser",
               "Remove-BACCBrowserProfile",
               "Remove-BACCCodeInterpreter",
               "Remove-BACCEvaluator",
               "Remove-BACCGateway",
               "Remove-BACCGatewayTarget",
               "Remove-BACCMemory",
               "Remove-BACCOauth2CredentialProvider",
               "Remove-BACCOnlineEvaluationConfig",
               "Remove-BACCPolicy",
               "Remove-BACCPolicyEngine",
               "Remove-BACCResourcePolicy",
               "Remove-BACCWorkloadIdentity",
               "Get-BACCAgentRuntime",
               "Get-BACCAgentRuntimeEndpoint",
               "Get-BACCApiKeyCredentialProvider",
               "Get-BACCBrowser",
               "Get-BACCBrowserProfile",
               "Get-BACCCodeInterpreter",
               "Get-BACCEvaluator",
               "Get-BACCGateway",
               "Get-BACCGatewayTarget",
               "Get-BACCMemory",
               "Get-BACCOauth2CredentialProvider",
               "Get-BACCOnlineEvaluationConfig",
               "Get-BACCPolicy",
               "Get-BACCPolicyEngine",
               "Get-BACCPolicyGeneration",
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
               "Get-BACCEvaluatorList",
               "Get-BACCGatewayList",
               "Get-BACCGatewayTargetList",
               "Get-BACCMemoryList",
               "Get-BACCOauth2CredentialProviderList",
               "Get-BACCOnlineEvaluationConfigList",
               "Get-BACCPolicyList",
               "Get-BACCPolicyEngineList",
               "Get-BACCPolicyGenerationAssetList",
               "Get-BACCPolicyGenerationList",
               "Get-BACCResourceTag",
               "Get-BACCWorkloadIdentityList",
               "Write-BACCResourcePolicy",
               "Set-BACCTokenVaultCMK",
               "Start-BACCPolicyGeneration",
               "Sync-BACCGatewayTarget",
               "Add-BACCResourceTag",
               "Remove-BACCResourceTag",
               "Update-BACCAgentRuntime",
               "Update-BACCAgentRuntimeEndpoint",
               "Update-BACCApiKeyCredentialProvider",
               "Update-BACCEvaluator",
               "Update-BACCGateway",
               "Update-BACCGatewayTarget",
               "Update-BACCMemory",
               "Update-BACCOauth2CredentialProvider",
               "Update-BACCOnlineEvaluationConfig",
               "Update-BACCPolicy",
               "Update-BACCPolicyEngine",
               "Update-BACCWorkloadIdentity")
}

_awsArgumentCompleterRegistration $BACC_SelectCompleters $BACC_SelectMap

