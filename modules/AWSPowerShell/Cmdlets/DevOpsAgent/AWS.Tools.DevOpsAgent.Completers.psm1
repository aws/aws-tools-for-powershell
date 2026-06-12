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

# Argument completions for service AWS DevOps Agent Service


$DOPS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.DevOpsAgent.AuthFlow
        {
            ($_ -eq "Disable-DOPSOperatorApp/AuthFlow") -Or
            ($_ -eq "Enable-DOPSOperatorApp/AuthFlow")
        }
        {
            $v = "iam","idc","idp"
            break
        }

        # Amazon.DevOpsAgent.EventChannelType
        "Register-DOPSService/ServiceDetails_EventChannel_Type"
        {
            $v = "webhook"
            break
        }

        # Amazon.DevOpsAgent.GithubRepoOwnerType
        {
            ($_ -eq "Add-DOPSService/Configuration_Github_OwnerType") -Or
            ($_ -eq "Update-DOPSAssociation/Configuration_Github_OwnerType")
        }
        {
            $v = "organization","user"
            break
        }

        # Amazon.DevOpsAgent.GitLabTokenType
        "Register-DOPSService/ServiceDetails_Gitlab_TokenType"
        {
            $v = "group","personal"
            break
        }

        # Amazon.DevOpsAgent.GoalStatus
        "Get-DOPSGoalList/Status"
        {
            $v = "ACTIVE","COMPLETE","PAUSED"
            break
        }

        # Amazon.DevOpsAgent.GoalType
        "Get-DOPSGoalList/GoalType"
        {
            $v = "CUSTOMER_DEFINED","ONCALL_REPORT"
            break
        }

        # Amazon.DevOpsAgent.IpAddressType
        "New-DOPSPrivateConnection/Mode_ServiceManaged_IpAddressType"
        {
            $v = "DUAL_STACK","IPV4","IPV6"
            break
        }

        # Amazon.DevOpsAgent.MonitorAccountType
        {
            ($_ -eq "Add-DOPSService/Configuration_Aws_AccountType") -Or
            ($_ -eq "Update-DOPSAssociation/Configuration_Aws_AccountType")
        }
        {
            $v = "monitor"
            break
        }

        # Amazon.DevOpsAgent.NewRelicRegion
        "Register-DOPSService/ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_Region"
        {
            $v = "EU","US"
            break
        }

        # Amazon.DevOpsAgent.OrderType
        "Get-DOPSJournalRecordList/Order"
        {
            $v = "ASC","DESC"
            break
        }

        # Amazon.DevOpsAgent.PostRegisterServiceSupportedService
        "Register-DOPSService/Service"
        {
            $v = "azureidentity","dynatrace","eventChannel","gitlab","mcpserver","mcpserverdatadog","mcpservergrafana","mcpservernewrelic","mcpserversigv4","mcpserversplunk","pagerduty","servicenow"
            break
        }

        # Amazon.DevOpsAgent.Priority
        "New-DOPSBacklogTask/Priority"
        {
            $v = "CRITICAL","HIGH","LOW","MEDIUM","MINIMAL"
            break
        }

        # Amazon.DevOpsAgent.RecommendationPriority
        "Get-DOPSRecommendationList/Priority"
        {
            $v = "HIGH","LOW","MEDIUM"
            break
        }

        # Amazon.DevOpsAgent.RecommendationStatus
        {
            ($_ -eq "Get-DOPSRecommendationList/Status") -Or
            ($_ -eq "Update-DOPSRecommendation/Status")
        }
        {
            $v = "ACCEPTED","CLOSED","COMPLETED","PROPOSED","REJECTED","UPDATE_IN_PROGRESS"
            break
        }

        # Amazon.DevOpsAgent.ResourceConfigDnsResolution
        "New-DOPSPrivateConnection/Mode_ServiceManaged_DnsResolution"
        {
            $v = "IN_VPC","PUBLIC"
            break
        }

        # Amazon.DevOpsAgent.SchedulerState
        "Update-DOPSGoal/EvaluationSchedule_State"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.DevOpsAgent.Service
        "Get-DOPSServiceList/FilterServiceType"
        {
            $v = "azure","azuredevops","azureidentity","dynatrace","eventChannel","github","gitlab","mcpserver","mcpserverdatadog","mcpservergrafana","mcpservernewrelic","mcpserversigv4","mcpserversplunk","pagerduty","servicenow","slack"
            break
        }

        # Amazon.DevOpsAgent.SourceAccountType
        {
            ($_ -eq "Add-DOPSService/Configuration_SourceAws_AccountType") -Or
            ($_ -eq "Update-DOPSAssociation/Configuration_SourceAws_AccountType")
        }
        {
            $v = "source"
            break
        }

        # Amazon.DevOpsAgent.TaskSortField
        "Get-DOPSBacklogTaskList/SortField"
        {
            $v = "CREATED_AT","PRIORITY"
            break
        }

        # Amazon.DevOpsAgent.TaskSortOrder
        "Get-DOPSBacklogTaskList/Order"
        {
            $v = "ASC","DESC"
            break
        }

        # Amazon.DevOpsAgent.TaskStatus
        "Update-DOPSBacklogTask/TaskStatus"
        {
            $v = "CANCELED","COMPLETED","FAILED","IN_PROGRESS","LINKED","PENDING_CUSTOMER_APPROVAL","PENDING_START","PENDING_TRIAGE","SKIPPED","TIMED_OUT"
            break
        }

        # Amazon.DevOpsAgent.TaskType
        "New-DOPSBacklogTask/TaskType"
        {
            $v = "EVALUATION","INVESTIGATION"
            break
        }

        # Amazon.DevOpsAgent.UserType
        "New-DOPSChat/UserType"
        {
            $v = "IAM","IDC","IDP"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$DOPS_map = @{
    "AuthFlow"=@("Disable-DOPSOperatorApp","Enable-DOPSOperatorApp")
    "Configuration_Aws_AccountType"=@("Add-DOPSService","Update-DOPSAssociation")
    "Configuration_Github_OwnerType"=@("Add-DOPSService","Update-DOPSAssociation")
    "Configuration_SourceAws_AccountType"=@("Add-DOPSService","Update-DOPSAssociation")
    "EvaluationSchedule_State"=@("Update-DOPSGoal")
    "FilterServiceType"=@("Get-DOPSServiceList")
    "GoalType"=@("Get-DOPSGoalList")
    "Mode_ServiceManaged_DnsResolution"=@("New-DOPSPrivateConnection")
    "Mode_ServiceManaged_IpAddressType"=@("New-DOPSPrivateConnection")
    "Order"=@("Get-DOPSBacklogTaskList","Get-DOPSJournalRecordList")
    "Priority"=@("Get-DOPSRecommendationList","New-DOPSBacklogTask")
    "Service"=@("Register-DOPSService")
    "ServiceDetails_EventChannel_Type"=@("Register-DOPSService")
    "ServiceDetails_Gitlab_TokenType"=@("Register-DOPSService")
    "ServiceDetails_Mcpservernewrelic_AuthorizationConfig_ApiKey_Region"=@("Register-DOPSService")
    "SortField"=@("Get-DOPSBacklogTaskList")
    "Status"=@("Get-DOPSGoalList","Get-DOPSRecommendationList","Update-DOPSRecommendation")
    "TaskStatus"=@("Update-DOPSBacklogTask")
    "TaskType"=@("New-DOPSBacklogTask")
    "UserType"=@("New-DOPSChat")
}

_awsArgumentCompleterRegistration $DOPS_Completers $DOPS_map

$DOPS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.DOPS.$($commandName.Replace('-', ''))Cmdlet]"
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

$DOPS_SelectMap = @{
    "Select"=@("Add-DOPSService",
               "New-DOPSAgentSpace",
               "New-DOPSAsset",
               "New-DOPSAssetFile",
               "New-DOPSBacklogTask",
               "New-DOPSChat",
               "New-DOPSPrivateConnection",
               "New-DOPSTrigger",
               "Remove-DOPSAgentSpace",
               "Remove-DOPSAsset",
               "Remove-DOPSAssetFile",
               "Remove-DOPSPrivateConnection",
               "Remove-DOPSTrigger",
               "Unregister-DOPSService",
               "Get-DOPSPrivateConnectionDetail",
               "Disable-DOPSOperatorApp",
               "Remove-DOPSService",
               "Enable-DOPSOperatorApp",
               "Get-DOPSAccountUsage",
               "Get-DOPSAgentSpace",
               "Get-DOPSAsset",
               "Get-DOPSAssetContent",
               "Get-DOPSAssetFile",
               "Get-DOPSAssociation",
               "Get-DOPSBacklogTask",
               "Get-DOPSOperatorApp",
               "Get-DOPSRecommendation",
               "Get-DOPSService",
               "Get-DOPSTrigger",
               "Get-DOPSAgentSpaceList",
               "Get-DOPSAssetFileList",
               "Get-DOPSAssetList",
               "Get-DOPSAssetTypeList",
               "Get-DOPSAssetVersionList",
               "Get-DOPSAssociationList",
               "Get-DOPSBacklogTaskList",
               "Get-DOPSChatList",
               "Get-DOPSExecutionList",
               "Get-DOPSGoalList",
               "Get-DOPSJournalRecordList",
               "Get-DOPSPendingMessageList",
               "Get-DOPSPrivateConnectionList",
               "Get-DOPSRecommendationList",
               "Get-DOPSServiceList",
               "Get-DOPSResourceTag",
               "Get-DOPSTriggerList",
               "Get-DOPSWebhookList",
               "Register-DOPSService",
               "Send-DOPSMessage",
               "Add-DOPSResourceTag",
               "Remove-DOPSResourceTag",
               "Update-DOPSAgentSpace",
               "Update-DOPSAsset",
               "Update-DOPSAssetFile",
               "Update-DOPSAssociation",
               "Update-DOPSBacklogTask",
               "Update-DOPSGoal",
               "Update-DOPSOperatorAppIdpConfig",
               "Update-DOPSPrivateConnectionCertificate",
               "Update-DOPSRecommendation",
               "Update-DOPSTrigger",
               "Test-DOPSAwsAssociation")
}

_awsArgumentCompleterRegistration $DOPS_SelectCompleters $DOPS_SelectMap

