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

# Argument completions for service Agent Registry Control


$AGRC_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.AgentRegistryControl.AgentSkillsRepositoryProvider
        {
            ($_ -eq "New-AGRCRegistryRecord/Descriptors_AgentSkillsDefinition_AdditionalData_RepositoryProvider") -Or
            ($_ -eq "Update-AGRCRegistryRecord/Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_RepositoryProvider_OptionalValue")
        }
        {
            $v = "GITHUB"
            break
        }

        # Amazon.AgentRegistryControl.AssociationApprovalStatus
        "Update-AGRCPublisherAssociationApprovalStatus/ApprovalStatus"
        {
            $v = "APPROVED","REJECTED"
            break
        }

        # Amazon.AgentRegistryControl.AutoDetectionScope
        {
            ($_ -eq "Update-AGRCRegistry/AutoDetectionConfiguration_OptionalValue_Scope") -Or
            ($_ -eq "New-AGRCRegistry/AutoDetectionConfiguration_Scope")
        }
        {
            $v = "ORGANIZATION"
            break
        }

        # Amazon.AgentRegistryControl.BotCategory
        {
            ($_ -eq "Update-AGRCRegistryRecord/Descriptors_OptionalValue_SignatureAgentCard_OptionalValue_AdditionalData_OptionalValue_Category_OptionalValue") -Or
            ($_ -eq "New-AGRCRegistryRecord/Descriptors_SignatureAgentCard_AdditionalData_Category")
        }
        {
            $v = "advertising","ai_assistant","ai_content_optimization","ai_search","ai_training","archiver","content_fetcher","email_client","http_library","link_checker","miscellaneous","monitoring","page_preview","scraping_framework","search_engine","security","seo","social_media"
            break
        }

        # Amazon.AgentRegistryControl.EndpointIpAddressType
        {
            ($_ -eq "New-AGRCRegistry/DiscoveryConfiguration_AuthorizerConfiguration_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType") -Or
            ($_ -eq "Update-AGRCRegistry/DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType")
        }
        {
            $v = "IPV4","IPV6"
            break
        }

        # Amazon.AgentRegistryControl.RecordType
        {
            ($_ -eq "New-AGRCRegistryRecord/RecordType") -Or
            ($_ -eq "Update-AGRCRegistryRecord/RecordType")
        }
        {
            $v = "AGENT","CUSTOM","GATEWAY","MCP","SKILL","WEB_BOT"
            break
        }

        # Amazon.AgentRegistryControl.RegistryAuthorizerType
        "New-AGRCRegistry/DiscoveryConfiguration_AuthorizerType"
        {
            $v = "AWS_IAM","CUSTOM_JWT"
            break
        }

        # Amazon.AgentRegistryControl.RegistryRecordStatus
        "Update-AGRCRegistryRecordStatus/Status"
        {
            $v = "APPROVED","CREATE_FAILED","CREATE_PENDING_AUTH","CREATING","DEPRECATED","DRAFT","PENDING_APPROVAL","REJECTED","UPDATE_FAILED","UPDATE_PENDING_AUTH","UPDATING"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$AGRC_map = @{
    "ApprovalStatus"=@("Update-AGRCPublisherAssociationApprovalStatus")
    "AutoDetectionConfiguration_OptionalValue_Scope"=@("Update-AGRCRegistry")
    "AutoDetectionConfiguration_Scope"=@("New-AGRCRegistry")
    "Descriptors_AgentSkillsDefinition_AdditionalData_RepositoryProvider"=@("New-AGRCRegistryRecord")
    "Descriptors_OptionalValue_AgentSkillsDefinition_OptionalValue_AdditionalData_OptionalValue_RepositoryProvider_OptionalValue"=@("Update-AGRCRegistryRecord")
    "Descriptors_OptionalValue_SignatureAgentCard_OptionalValue_AdditionalData_OptionalValue_Category_OptionalValue"=@("Update-AGRCRegistryRecord")
    "Descriptors_SignatureAgentCard_AdditionalData_Category"=@("New-AGRCRegistryRecord")
    "DiscoveryConfiguration_AuthorizerConfiguration_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType"=@("New-AGRCRegistry")
    "DiscoveryConfiguration_AuthorizerConfiguration_OptionalValue_CustomJWTAuthorizer_PrivateEndpoint_ManagedVpcResource_EndpointIpAddressType"=@("Update-AGRCRegistry")
    "DiscoveryConfiguration_AuthorizerType"=@("New-AGRCRegistry")
    "RecordType"=@("New-AGRCRegistryRecord","Update-AGRCRegistryRecord")
    "Status"=@("Update-AGRCRegistryRecordStatus")
}

_awsArgumentCompleterRegistration $AGRC_Completers $AGRC_map

$AGRC_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.AGRC.$($commandName.Replace('-', ''))Cmdlet]"
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

$AGRC_SelectMap = @{
    "Select"=@("Add-AGRCPublisher",
               "New-AGRCPublisher",
               "New-AGRCRegistry",
               "New-AGRCRegistryRecord",
               "Remove-AGRCPublisher",
               "Remove-AGRCRegistry",
               "Remove-AGRCRegistryRecord",
               "Unregister-AGRCPublisher",
               "Get-AGRCPublisher",
               "Get-AGRCRegistry",
               "Get-AGRCRegistryRecord",
               "Get-AGRCPublisherAssociationList",
               "Get-AGRCPublisherList",
               "Get-AGRCRegistryList",
               "Get-AGRCRegistryRecordList",
               "Get-AGRCResourceTag",
               "Submit-AGRCRegistryRecordForApproval",
               "Add-AGRCResourceTag",
               "Remove-AGRCResourceTag",
               "Update-AGRCPublisherAssociationApprovalStatus",
               "Update-AGRCRegistry",
               "Update-AGRCRegistryRecord",
               "Update-AGRCRegistryRecordStatus",
               "Test-AGRCPublisher")
}

_awsArgumentCompleterRegistration $AGRC_SelectCompleters $AGRC_SelectMap

