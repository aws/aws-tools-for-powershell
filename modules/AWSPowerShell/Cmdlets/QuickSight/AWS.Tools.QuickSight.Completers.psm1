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

# Argument completions for service Amazon QuickSight


$QS_Completers = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    switch ($("$commandName/$parameterName"))
    {
        # Amazon.QuickSight.ActionConnectorType
        "New-QSActionConnector/Type"
        {
            $v = "AMAZON_BEDROCK_AGENT_RUNTIME","AMAZON_BEDROCK_DATA_AUTOMATION_RUNTIME","AMAZON_BEDROCK_RUNTIME","AMAZON_COMPREHEND","AMAZON_COMPREHEND_MEDICAL","AMAZON_S3","AMAZON_TEXTRACT","ASANA","ATLASSIAN_CONFLUENCE","BAMBOO_HR","GENERIC_HTTP","JIRA_CLOUD","MICROSOFT_ONEDRIVE","MICROSOFT_OUTLOOK","MICROSOFT_SHAREPOINT","MICROSOFT_TEAMS","PAGERDUTY_ADVANCE","SALESFORCE_CRM","SAP_BILLOFMATERIALS","SAP_BUSINESSPARTNER","SAP_MATERIALSTOCK","SAP_PHYSICALINVENTORY","SAP_PRODUCTMASTERDATA","SERVICENOW_NOW_PLATFORM","SLACK","SMARTSHEET","ZENDESK_SUITE"
            break
        }

        # Amazon.QuickSight.AssetBundleExportFormat
        "Start-QSAssetBundleExportJob/ExportFormat"
        {
            $v = "CLOUDFORMATION_JSON","QUICKSIGHT_JSON"
            break
        }

        # Amazon.QuickSight.AssetBundleImportFailureAction
        "Start-QSAssetBundleImportJob/FailureAction"
        {
            $v = "DO_NOTHING","ROLLBACK"
            break
        }

        # Amazon.QuickSight.AssignmentStatus
        {
            ($_ -eq "Get-QSIAMPolicyAssignmentList/AssignmentStatus") -Or
            ($_ -eq "New-QSIAMPolicyAssignment/AssignmentStatus") -Or
            ($_ -eq "Update-QSIAMPolicyAssignment/AssignmentStatus")
        }
        {
            $v = "DISABLED","DRAFT","ENABLED"
            break
        }

        # Amazon.QuickSight.AuthenticationMethodOption
        "New-QSAccountSubscription/AuthenticationMethod"
        {
            $v = "ACTIVE_DIRECTORY","IAM_AND_QUICKSIGHT","IAM_IDENTITY_CENTER","IAM_ONLY"
            break
        }

        # Amazon.QuickSight.AuthenticationType
        {
            ($_ -eq "New-QSDataSource/SnowflakeParameters_AuthenticationType") -Or
            ($_ -eq "Update-QSDataSource/SnowflakeParameters_AuthenticationType") -Or
            ($_ -eq "New-QSDataSource/StarburstParameters_AuthenticationType") -Or
            ($_ -eq "Update-QSDataSource/StarburstParameters_AuthenticationType")
        }
        {
            $v = "PASSWORD","TOKEN","X509"
            break
        }

        # Amazon.QuickSight.AuthorizationCodeGrantCredentialsSource
        {
            ($_ -eq "New-QSActionConnector/AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsSource") -Or
            ($_ -eq "Update-QSActionConnector/AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsSource")
        }
        {
            $v = "PLAIN_CREDENTIALS"
            break
        }

        # Amazon.QuickSight.CapabilityState
        {
            ($_ -eq "New-QSCustomPermission/Capabilities_Action") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_Action") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_AddOrRunAnomalyDetectionForAnalyses") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_AddOrRunAnomalyDetectionForAnalyses") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_AmazonBedrockARSAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_AmazonBedrockARSAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_AmazonBedrockFSAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_AmazonBedrockFSAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_AmazonBedrockKRSAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_AmazonBedrockKRSAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_AmazonSThreeAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_AmazonSThreeAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_Analysis") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_Analysis") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_AsanaAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_AsanaAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_Automate") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_Automate") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_BambooHRAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_BambooHRAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_BoxAgentAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_BoxAgentAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CanvaAgentAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CanvaAgentAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ChatAgent") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ChatAgent") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ComprehendAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ComprehendAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ComprehendMedicalAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ComprehendMedicalAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ConfluenceAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ConfluenceAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateAmazonBedrockARSAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateAmazonBedrockARSAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateAmazonBedrockFSAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateAmazonBedrockFSAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateAmazonBedrockKRSAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateAmazonBedrockKRSAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateAmazonSThreeAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateAmazonSThreeAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateAsanaAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateAsanaAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateBambooHRAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateBambooHRAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateBoxAgentAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateBoxAgentAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateCanvaAgentAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateCanvaAgentAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateComprehendAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateComprehendAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateComprehendMedicalAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateComprehendMedicalAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateConfluenceAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateConfluenceAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateDashboardEmailReport") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateDashboardEmailReport") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateDataset") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateDataset") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateDataSource") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateDataSource") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateFactSetAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateFactSetAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateGenericHTTPAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateGenericHTTPAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateGithubAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateGithubAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateGoogleCalendarAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateGoogleCalendarAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateHubspotAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateHubspotAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateHuggingFaceAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateHuggingFaceAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateIntercomAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateIntercomAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateJiraAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateJiraAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateLinearAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateLinearAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateMCPAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateMCPAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateMondayAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateMondayAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateMSExchangeAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateMSExchangeAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateMSTeamsAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateMSTeamsAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateNewRelicAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateNewRelicAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateNotionAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateNotionAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateOneDriveAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateOneDriveAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateOpenAPIAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateOpenAPIAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdatePagerDutyAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdatePagerDutyAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateSalesforceAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateSalesforceAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateSandPGlobalEnergyAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateSandPGlobalEnergyAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateSandPGMIAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateSandPGMIAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateSAPBillOfMaterialAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateSAPBillOfMaterialAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateSAPBusinessPartnerAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateSAPBusinessPartnerAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateSAPMaterialStockAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateSAPMaterialStockAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateSAPPhysicalInventoryAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateSAPPhysicalInventoryAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateSAPProductMasterDataAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateSAPProductMasterDataAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateServiceNowAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateServiceNowAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateSharePointAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateSharePointAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateSlackAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateSlackAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateSmartsheetAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateSmartsheetAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateTextractAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateTextractAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateTheme") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateTheme") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateThresholdAlert") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateThresholdAlert") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateAndUpdateZendeskAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateAndUpdateZendeskAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateChatAgent") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateChatAgent") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateSharedFolder") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateSharedFolder") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_CreateSPICEDataset") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_CreateSPICEDataset") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_Dashboard") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_Dashboard") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ExportToCsv") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ExportToCsv") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ExportToCsvInScheduledReport") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ExportToCsvInScheduledReport") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ExportToExcel") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ExportToExcel") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ExportToExcelInScheduledReport") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ExportToExcelInScheduledReport") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ExportToPdf") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ExportToPdf") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ExportToPdfInScheduledReport") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ExportToPdfInScheduledReport") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_FactSetAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_FactSetAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_Flow") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_Flow") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_GenericHTTPAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_GenericHTTPAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_GithubAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_GithubAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_GoogleCalendarAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_GoogleCalendarAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_HubspotAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_HubspotAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_HuggingFaceAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_HuggingFaceAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_IncludeContentInScheduledReportsEmail") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_IncludeContentInScheduledReportsEmail") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_IntercomAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_IntercomAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_JiraAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_JiraAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_KnowledgeBase") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_KnowledgeBase") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_LinearAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_LinearAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_MCPAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_MCPAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_MondayAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_MondayAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_MSExchangeAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_MSExchangeAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_MSTeamsAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_MSTeamsAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_NewRelicAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_NewRelicAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_NotionAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_NotionAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_OneDriveAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_OneDriveAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_OpenAPIAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_OpenAPIAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_PagerDutyAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_PagerDutyAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_PerformFlowUiTask") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_PerformFlowUiTask") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_PrintReport") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_PrintReport") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_PublishWithoutApproval") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_PublishWithoutApproval") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_RenameSharedFolder") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_RenameSharedFolder") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_Research") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_Research") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_SalesforceAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_SalesforceAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_SandPGlobalEnergyAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_SandPGlobalEnergyAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_SandPGMIAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_SandPGMIAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_SAPBillOfMaterialAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_SAPBillOfMaterialAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_SAPBusinessPartnerAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_SAPBusinessPartnerAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_SAPMaterialStockAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_SAPMaterialStockAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_SAPPhysicalInventoryAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_SAPPhysicalInventoryAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_SAPProductMasterDataAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_SAPProductMasterDataAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_SelfUpgradeUserRole") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_SelfUpgradeUserRole") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ServiceNowAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ServiceNowAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareAmazonBedrockARSAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareAmazonBedrockARSAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareAmazonBedrockFSAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareAmazonBedrockFSAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareAmazonBedrockKRSAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareAmazonBedrockKRSAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareAmazonSThreeAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareAmazonSThreeAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareAnalyses") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareAnalyses") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareAsanaAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareAsanaAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareBambooHRAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareBambooHRAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareBoxAgentAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareBoxAgentAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareCanvaAgentAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareCanvaAgentAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareComprehendAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareComprehendAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareComprehendMedicalAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareComprehendMedicalAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareConfluenceAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareConfluenceAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareDashboard") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareDashboard") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareDataset") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareDataset") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareDataSource") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareDataSource") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareFactSetAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareFactSetAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareGenericHTTPAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareGenericHTTPAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareGithubAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareGithubAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareGoogleCalendarAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareGoogleCalendarAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareHubspotAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareHubspotAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareHuggingFaceAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareHuggingFaceAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareIntercomAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareIntercomAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareJiraAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareJiraAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareLinearAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareLinearAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareMCPAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareMCPAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareMondayAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareMondayAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareMSExchangeAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareMSExchangeAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareMSTeamsAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareMSTeamsAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareNewRelicAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareNewRelicAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareNotionAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareNotionAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareOneDriveAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareOneDriveAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareOpenAPIAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareOpenAPIAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_SharePagerDutyAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_SharePagerDutyAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_SharePointAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_SharePointAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareSalesforceAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareSalesforceAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareSandPGlobalEnergyAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareSandPGlobalEnergyAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareSandPGMIAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareSandPGMIAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareSAPBillOfMaterialAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareSAPBillOfMaterialAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareSAPBusinessPartnerAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareSAPBusinessPartnerAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareSAPMaterialStockAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareSAPMaterialStockAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareSAPPhysicalInventoryAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareSAPPhysicalInventoryAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareSAPProductMasterDataAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareSAPProductMasterDataAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareServiceNowAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareServiceNowAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareSharePointAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareSharePointAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareSlackAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareSlackAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareSmartsheetAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareSmartsheetAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareTextractAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareTextractAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ShareZendeskAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ShareZendeskAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_SlackAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_SlackAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_SmartsheetAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_SmartsheetAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_Space") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_Space") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_SubscribeDashboardEmailReport") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_SubscribeDashboardEmailReport") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_TextractAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_TextractAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseAgentWebSearch") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseAgentWebSearch") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseAmazonBedrockARSAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseAmazonBedrockARSAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseAmazonBedrockFSAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseAmazonBedrockFSAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseAmazonBedrockKRSAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseAmazonBedrockKRSAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseAmazonSThreeAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseAmazonSThreeAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseAsanaAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseAsanaAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseBambooHRAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseBambooHRAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseBedrockModel") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseBedrockModel") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseBoxAgentAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseBoxAgentAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseCanvaAgentAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseCanvaAgentAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseComprehendAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseComprehendAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseComprehendMedicalAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseComprehendMedicalAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseConfluenceAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseConfluenceAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseFactSetAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseFactSetAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseGenericHTTPAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseGenericHTTPAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseGithubAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseGithubAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseGoogleCalendarAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseGoogleCalendarAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseHubspotAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseHubspotAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseHuggingFaceAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseHuggingFaceAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseIntercomAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseIntercomAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseJiraAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseJiraAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseLinearAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseLinearAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseMCPAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseMCPAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseMondayAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseMondayAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseMSExchangeAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseMSExchangeAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseMSTeamsAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseMSTeamsAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseNewRelicAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseNewRelicAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseNotionAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseNotionAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseOneDriveAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseOneDriveAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseOpenAPIAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseOpenAPIAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UsePagerDutyAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UsePagerDutyAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseSalesforceAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseSalesforceAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseSandPGlobalEnergyAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseSandPGlobalEnergyAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseSandPGMIAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseSandPGMIAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseSAPBillOfMaterialAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseSAPBillOfMaterialAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseSAPBusinessPartnerAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseSAPBusinessPartnerAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseSAPMaterialStockAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseSAPMaterialStockAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseSAPPhysicalInventoryAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseSAPPhysicalInventoryAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseSAPProductMasterDataAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseSAPProductMasterDataAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseServiceNowAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseServiceNowAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseSharePointAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseSharePointAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseSlackAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseSlackAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseSmartsheetAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseSmartsheetAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseTextractAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseTextractAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_UseZendeskAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_UseZendeskAction") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ViewAccountSPICECapacity") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ViewAccountSPICECapacity") -Or
            ($_ -eq "New-QSCustomPermission/Capabilities_ZendeskAction") -Or
            ($_ -eq "Update-QSCustomPermission/Capabilities_ZendeskAction")
        }
        {
            $v = "DENY"
            break
        }

        # Amazon.QuickSight.ClientCredentialsSource
        {
            ($_ -eq "New-QSActionConnector/ClientCredentialsGrantMetadata_ClientCredentialsSource") -Or
            ($_ -eq "Update-QSActionConnector/ClientCredentialsGrantMetadata_ClientCredentialsSource")
        }
        {
            $v = "PLAIN_CREDENTIALS"
            break
        }

        # Amazon.QuickSight.ConnectionAuthType
        {
            ($_ -eq "New-QSActionConnector/AuthenticationConfig_AuthenticationType") -Or
            ($_ -eq "Update-QSActionConnector/AuthenticationConfig_AuthenticationType")
        }
        {
            $v = "API_KEY","BASIC","IAM","NONE","OAUTH2_AUTHORIZATION_CODE","OAUTH2_CLIENT_CREDENTIALS"
            break
        }

        # Amazon.QuickSight.DashboardBehavior
        {
            ($_ -eq "New-QSDashboard/AdHocFilteringOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/AdHocFilteringOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/DataPointDrillUpDownOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/DataPointDrillUpDownOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/DataPointMenuLabelOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/DataPointMenuLabelOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/DataPointTooltipOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/DataPointTooltipOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/DataQAEnabledOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/DataQAEnabledOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/DataStoriesSharingOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/DataStoriesSharingOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/ExecutiveSummaryOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/ExecutiveSummaryOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/ExportHiddenFieldsOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/ExportHiddenFieldsOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/ExportToCSVOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/ExportToCSVOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/ExportWithHiddenFieldsOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/ExportWithHiddenFieldsOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/QuickSuiteActionsOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/QuickSuiteActionsOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/SheetLayoutElementMaximizationOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/SheetLayoutElementMaximizationOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/VisualAxisSortOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/VisualAxisSortOption_AvailabilityStatus") -Or
            ($_ -eq "New-QSDashboard/VisualMenuOption_AvailabilityStatus") -Or
            ($_ -eq "Update-QSDashboard/VisualMenuOption_AvailabilityStatus")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.QuickSight.DashboardsQAStatus
        "Update-QSDashboardsQAConfiguration/DashboardsQAStatus"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.QuickSight.DashboardUIState
        {
            ($_ -eq "New-QSDashboard/SheetControlsOption_VisibilityState") -Or
            ($_ -eq "Update-QSDashboard/SheetControlsOption_VisibilityState")
        }
        {
            $v = "COLLAPSED","EXPANDED"
            break
        }

        # Amazon.QuickSight.DataSetImportMode
        {
            ($_ -eq "New-QSDataSet/ImportMode") -Or
            ($_ -eq "Update-QSDataSet/ImportMode")
        }
        {
            $v = "DIRECT_QUERY","SPICE"
            break
        }

        # Amazon.QuickSight.DataSetUseAs
        "New-QSDataSet/UseAs"
        {
            $v = "RLS_RULES"
            break
        }

        # Amazon.QuickSight.DataSourceType
        "New-QSDataSource/Type"
        {
            $v = "ADOBE_ANALYTICS","AMAZON_ELASTICSEARCH","AMAZON_OPENSEARCH","ATHENA","AURORA","AURORA_POSTGRESQL","AWS_IOT_ANALYTICS","BIGQUERY","CONFLUENCE","DATABRICKS","EXASOL","GITHUB","GOOGLESHEETS","GOOGLE_DRIVE","JIRA","MARIADB","MYSQL","ONE_DRIVE","ORACLE","POSTGRESQL","PRESTO","QBUSINESS","REDSHIFT","S3","S3_KNOWLEDGE_BASE","SALESFORCE","SERVICENOW","SHAREPOINT","SNOWFLAKE","SPARK","SQLSERVER","STARBURST","TERADATA","TIMESTREAM","TRINO","TWITTER","WEB_CRAWLER"
            break
        }

        # Amazon.QuickSight.DayOfTheWeek
        {
            ($_ -eq "New-QSAnalysis/Options_WeekStart") -Or
            ($_ -eq "New-QSDashboard/Options_WeekStart") -Or
            ($_ -eq "New-QSTemplate/Options_WeekStart") -Or
            ($_ -eq "Update-QSAnalysis/Options_WeekStart") -Or
            ($_ -eq "Update-QSDashboard/Options_WeekStart") -Or
            ($_ -eq "Update-QSTemplate/Options_WeekStart")
        }
        {
            $v = "FRIDAY","MONDAY","SATURDAY","SUNDAY","THURSDAY","TUESDAY","WEDNESDAY"
            break
        }

        # Amazon.QuickSight.DayOfWeek
        {
            ($_ -eq "New-QSRefreshSchedule/RefreshOnDay_DayOfWeek") -Or
            ($_ -eq "Update-QSRefreshSchedule/RefreshOnDay_DayOfWeek")
        }
        {
            $v = "FRIDAY","MONDAY","SATURDAY","SUNDAY","THURSDAY","TUESDAY","WEDNESDAY"
            break
        }

        # Amazon.QuickSight.Edition
        "New-QSAccountSubscription/Edition"
        {
            $v = "ENTERPRISE","ENTERPRISE_AND_Q","STANDARD"
            break
        }

        # Amazon.QuickSight.EmbeddingIdentityType
        "Get-QSDashboardEmbedUrl/IdentityType"
        {
            $v = "ANONYMOUS","IAM","QUICKSIGHT"
            break
        }

        # Amazon.QuickSight.FolderType
        "New-QSFolder/FolderType"
        {
            $v = "RESTRICTED","SHARED"
            break
        }

        # Amazon.QuickSight.FontDecoration
        {
            ($_ -eq "New-QSTheme/AxisLabelFontConfiguration_FontDecoration") -Or
            ($_ -eq "Update-QSTheme/AxisLabelFontConfiguration_FontDecoration") -Or
            ($_ -eq "New-QSTheme/AxisTitleFontConfiguration_FontDecoration") -Or
            ($_ -eq "Update-QSTheme/AxisTitleFontConfiguration_FontDecoration") -Or
            ($_ -eq "New-QSTheme/Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontDecoration") -Or
            ($_ -eq "Update-QSTheme/Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontDecoration") -Or
            ($_ -eq "New-QSTheme/Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontDecoration") -Or
            ($_ -eq "Update-QSTheme/Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontDecoration") -Or
            ($_ -eq "New-QSTheme/DataLabelFontConfiguration_FontDecoration") -Or
            ($_ -eq "Update-QSTheme/DataLabelFontConfiguration_FontDecoration") -Or
            ($_ -eq "New-QSTheme/LegendTitleFontConfiguration_FontDecoration") -Or
            ($_ -eq "Update-QSTheme/LegendTitleFontConfiguration_FontDecoration") -Or
            ($_ -eq "New-QSTheme/LegendValueFontConfiguration_FontDecoration") -Or
            ($_ -eq "Update-QSTheme/LegendValueFontConfiguration_FontDecoration")
        }
        {
            $v = "NONE","UNDERLINE"
            break
        }

        # Amazon.QuickSight.FontStyle
        {
            ($_ -eq "New-QSTheme/AxisLabelFontConfiguration_FontStyle") -Or
            ($_ -eq "Update-QSTheme/AxisLabelFontConfiguration_FontStyle") -Or
            ($_ -eq "New-QSTheme/AxisTitleFontConfiguration_FontStyle") -Or
            ($_ -eq "Update-QSTheme/AxisTitleFontConfiguration_FontStyle") -Or
            ($_ -eq "New-QSTheme/Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontStyle") -Or
            ($_ -eq "Update-QSTheme/Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontStyle") -Or
            ($_ -eq "New-QSTheme/Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontStyle") -Or
            ($_ -eq "Update-QSTheme/Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontStyle") -Or
            ($_ -eq "New-QSTheme/DataLabelFontConfiguration_FontStyle") -Or
            ($_ -eq "Update-QSTheme/DataLabelFontConfiguration_FontStyle") -Or
            ($_ -eq "New-QSTheme/LegendTitleFontConfiguration_FontStyle") -Or
            ($_ -eq "Update-QSTheme/LegendTitleFontConfiguration_FontStyle") -Or
            ($_ -eq "New-QSTheme/LegendValueFontConfiguration_FontStyle") -Or
            ($_ -eq "Update-QSTheme/LegendValueFontConfiguration_FontStyle")
        }
        {
            $v = "ITALIC","NORMAL"
            break
        }

        # Amazon.QuickSight.FontWeightName
        {
            ($_ -eq "New-QSTheme/Configuration_Typography_AxisLabelFontConfiguration_FontWeight_Name") -Or
            ($_ -eq "Update-QSTheme/Configuration_Typography_AxisLabelFontConfiguration_FontWeight_Name") -Or
            ($_ -eq "New-QSTheme/Configuration_Typography_AxisTitleFontConfiguration_FontWeight_Name") -Or
            ($_ -eq "Update-QSTheme/Configuration_Typography_AxisTitleFontConfiguration_FontWeight_Name") -Or
            ($_ -eq "New-QSTheme/Configuration_Typography_DataLabelFontConfiguration_FontWeight_Name") -Or
            ($_ -eq "Update-QSTheme/Configuration_Typography_DataLabelFontConfiguration_FontWeight_Name") -Or
            ($_ -eq "New-QSTheme/Configuration_Typography_LegendTitleFontConfiguration_FontWeight_Name") -Or
            ($_ -eq "Update-QSTheme/Configuration_Typography_LegendTitleFontConfiguration_FontWeight_Name") -Or
            ($_ -eq "New-QSTheme/Configuration_Typography_LegendValueFontConfiguration_FontWeight_Name") -Or
            ($_ -eq "Update-QSTheme/Configuration_Typography_LegendValueFontConfiguration_FontWeight_Name") -Or
            ($_ -eq "New-QSTheme/Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight_Name") -Or
            ($_ -eq "Update-QSTheme/Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight_Name") -Or
            ($_ -eq "New-QSTheme/Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight_Name") -Or
            ($_ -eq "Update-QSTheme/Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight_Name")
        }
        {
            $v = "BOLD","NORMAL"
            break
        }

        # Amazon.QuickSight.HorizontalTextAlignment
        {
            ($_ -eq "New-QSTheme/VisualSubtitleFontConfiguration_TextAlignment") -Or
            ($_ -eq "Update-QSTheme/VisualSubtitleFontConfiguration_TextAlignment") -Or
            ($_ -eq "New-QSTheme/VisualTitleFontConfiguration_TextAlignment") -Or
            ($_ -eq "Update-QSTheme/VisualTitleFontConfiguration_TextAlignment")
        }
        {
            $v = "AUTO","CENTER","LEFT","RIGHT"
            break
        }

        # Amazon.QuickSight.IdentityStore
        "New-QSNamespace/IdentityStore"
        {
            $v = "QUICKSIGHT"
            break
        }

        # Amazon.QuickSight.IdentityType
        "Register-QSUser/IdentityType"
        {
            $v = "IAM","IAM_IDENTITY_CENTER","QUICKSIGHT"
            break
        }

        # Amazon.QuickSight.IncludeFolderMembers
        "Start-QSAssetBundleExportJob/IncludeFolderMember"
        {
            $v = "NONE","ONE_LEVEL","RECURSE"
            break
        }

        # Amazon.QuickSight.IncludeGeneratedAnswer
        "Search-QSQAResult/IncludeGeneratedAnswer"
        {
            $v = "EXCLUDE","INCLUDE"
            break
        }

        # Amazon.QuickSight.IncludeQuickSightQIndex
        "Search-QSQAResult/IncludeQuickSightQIndex"
        {
            $v = "EXCLUDE","INCLUDE"
            break
        }

        # Amazon.QuickSight.IngestionType
        {
            ($_ -eq "New-QSIngestion/IngestionType") -Or
            ($_ -eq "New-QSRefreshSchedule/Schedule_RefreshType") -Or
            ($_ -eq "Update-QSRefreshSchedule/Schedule_RefreshType")
        }
        {
            $v = "FULL_REFRESH","INCREMENTAL_REFRESH"
            break
        }

        # Amazon.QuickSight.LookbackWindowSizeUnit
        "Write-QSDataSetRefreshProperty/LookbackWindow_SizeUnit"
        {
            $v = "DAY","HOUR","WEEK"
            break
        }

        # Amazon.QuickSight.MemberType
        {
            ($_ -eq "New-QSFolderMembership/MemberType") -Or
            ($_ -eq "Remove-QSFolderMembership/MemberType")
        }
        {
            $v = "ANALYSIS","DASHBOARD","DATASET","DATASOURCE","TOPIC"
            break
        }

        # Amazon.QuickSight.PaperOrientation
        {
            ($_ -eq "New-QSAnalysis/PaperCanvasSizeOptions_PaperOrientation") -Or
            ($_ -eq "New-QSDashboard/PaperCanvasSizeOptions_PaperOrientation") -Or
            ($_ -eq "New-QSTemplate/PaperCanvasSizeOptions_PaperOrientation") -Or
            ($_ -eq "Update-QSAnalysis/PaperCanvasSizeOptions_PaperOrientation") -Or
            ($_ -eq "Update-QSDashboard/PaperCanvasSizeOptions_PaperOrientation") -Or
            ($_ -eq "Update-QSTemplate/PaperCanvasSizeOptions_PaperOrientation")
        }
        {
            $v = "LANDSCAPE","PORTRAIT"
            break
        }

        # Amazon.QuickSight.PaperSize
        {
            ($_ -eq "New-QSAnalysis/PaperCanvasSizeOptions_PaperSize") -Or
            ($_ -eq "New-QSDashboard/PaperCanvasSizeOptions_PaperSize") -Or
            ($_ -eq "New-QSTemplate/PaperCanvasSizeOptions_PaperSize") -Or
            ($_ -eq "Update-QSAnalysis/PaperCanvasSizeOptions_PaperSize") -Or
            ($_ -eq "Update-QSDashboard/PaperCanvasSizeOptions_PaperSize") -Or
            ($_ -eq "Update-QSTemplate/PaperCanvasSizeOptions_PaperSize")
        }
        {
            $v = "A0","A1","A2","A3","A4","A5","JIS_B4","JIS_B5","US_LEGAL","US_LETTER","US_TABLOID_LEDGER"
            break
        }

        # Amazon.QuickSight.PersonalizationMode
        "Update-QSQPersonalizationConfiguration/PersonalizationMode"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.QuickSight.PurchaseMode
        "Update-QSSPICECapacityConfiguration/PurchaseMode"
        {
            $v = "AUTO_PURCHASE","MANUAL"
            break
        }

        # Amazon.QuickSight.QBusinessInsightsStatus
        {
            ($_ -eq "New-QSAnalysis/Options_QBusinessInsightsStatus") -Or
            ($_ -eq "New-QSDashboard/Options_QBusinessInsightsStatus") -Or
            ($_ -eq "New-QSTemplate/Options_QBusinessInsightsStatus") -Or
            ($_ -eq "Update-QSAnalysis/Options_QBusinessInsightsStatus") -Or
            ($_ -eq "Update-QSDashboard/Options_QBusinessInsightsStatus") -Or
            ($_ -eq "Update-QSTemplate/Options_QBusinessInsightsStatus")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.QuickSight.QSearchStatus
        "Update-QSQuickSightQSearchConfiguration/QSearchStatus"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.QuickSight.QueryExecutionMode
        {
            ($_ -eq "New-QSAnalysis/QueryExecutionOptions_QueryExecutionMode") -Or
            ($_ -eq "New-QSTemplate/QueryExecutionOptions_QueryExecutionMode") -Or
            ($_ -eq "Update-QSAnalysis/QueryExecutionOptions_QueryExecutionMode") -Or
            ($_ -eq "Update-QSTemplate/QueryExecutionOptions_QueryExecutionMode")
        }
        {
            $v = "AUTO","MANUAL"
            break
        }

        # Amazon.QuickSight.RefreshFailureAlertStatus
        "Write-QSDataSetRefreshProperty/EmailAlert_AlertStatus"
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.QuickSight.RefreshInterval
        {
            ($_ -eq "New-QSRefreshSchedule/ScheduleFrequency_Interval") -Or
            ($_ -eq "Update-QSRefreshSchedule/ScheduleFrequency_Interval")
        }
        {
            $v = "DAILY","HOURLY","MINUTE15","MINUTE30","MONTHLY","WEEKLY"
            break
        }

        # Amazon.QuickSight.RelativeFontSize
        {
            ($_ -eq "New-QSTheme/Configuration_Typography_AxisLabelFontConfiguration_FontSize_Relative") -Or
            ($_ -eq "Update-QSTheme/Configuration_Typography_AxisLabelFontConfiguration_FontSize_Relative") -Or
            ($_ -eq "New-QSTheme/Configuration_Typography_AxisTitleFontConfiguration_FontSize_Relative") -Or
            ($_ -eq "Update-QSTheme/Configuration_Typography_AxisTitleFontConfiguration_FontSize_Relative") -Or
            ($_ -eq "New-QSTheme/Configuration_Typography_DataLabelFontConfiguration_FontSize_Relative") -Or
            ($_ -eq "Update-QSTheme/Configuration_Typography_DataLabelFontConfiguration_FontSize_Relative") -Or
            ($_ -eq "New-QSTheme/Configuration_Typography_LegendTitleFontConfiguration_FontSize_Relative") -Or
            ($_ -eq "Update-QSTheme/Configuration_Typography_LegendTitleFontConfiguration_FontSize_Relative") -Or
            ($_ -eq "New-QSTheme/Configuration_Typography_LegendValueFontConfiguration_FontSize_Relative") -Or
            ($_ -eq "Update-QSTheme/Configuration_Typography_LegendValueFontConfiguration_FontSize_Relative") -Or
            ($_ -eq "New-QSTheme/Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Relative") -Or
            ($_ -eq "Update-QSTheme/Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Relative") -Or
            ($_ -eq "New-QSTheme/Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Relative") -Or
            ($_ -eq "Update-QSTheme/Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Relative")
        }
        {
            $v = "EXTRA_LARGE","EXTRA_SMALL","LARGE","MEDIUM","SMALL"
            break
        }

        # Amazon.QuickSight.ResizeOption
        {
            ($_ -eq "New-QSAnalysis/ScreenCanvasSizeOptions_ResizeOption") -Or
            ($_ -eq "New-QSDashboard/ScreenCanvasSizeOptions_ResizeOption") -Or
            ($_ -eq "New-QSTemplate/ScreenCanvasSizeOptions_ResizeOption") -Or
            ($_ -eq "Update-QSAnalysis/ScreenCanvasSizeOptions_ResizeOption") -Or
            ($_ -eq "Update-QSDashboard/ScreenCanvasSizeOptions_ResizeOption") -Or
            ($_ -eq "Update-QSTemplate/ScreenCanvasSizeOptions_ResizeOption")
        }
        {
            $v = "FIXED","RESPONSIVE"
            break
        }

        # Amazon.QuickSight.Role
        {
            ($_ -eq "Get-QSRoleCustomPermission/Role") -Or
            ($_ -eq "Get-QSRoleMembershipList/Role") -Or
            ($_ -eq "New-QSRoleMembership/Role") -Or
            ($_ -eq "Remove-QSRoleCustomPermission/Role") -Or
            ($_ -eq "Remove-QSRoleMembership/Role") -Or
            ($_ -eq "Update-QSRoleCustomPermission/Role")
        }
        {
            $v = "ADMIN","ADMIN_PRO","AUTHOR","AUTHOR_PRO","READER","READER_PRO"
            break
        }

        # Amazon.QuickSight.RowLevelPermissionFormatVersion
        {
            ($_ -eq "New-QSDataSet/RowLevelPermissionDataSet_FormatVersion") -Or
            ($_ -eq "Update-QSDataSet/RowLevelPermissionDataSet_FormatVersion")
        }
        {
            $v = "VERSION_1","VERSION_2"
            break
        }

        # Amazon.QuickSight.RowLevelPermissionPolicy
        {
            ($_ -eq "New-QSDataSet/RowLevelPermissionDataSet_PermissionPolicy") -Or
            ($_ -eq "Update-QSDataSet/RowLevelPermissionDataSet_PermissionPolicy")
        }
        {
            $v = "DENY_ACCESS","GRANT_ACCESS"
            break
        }

        # Amazon.QuickSight.SelfUpgradeAdminAction
        "Update-QSSelfUpgrade/Action"
        {
            $v = "APPROVE","DENY","VERIFY"
            break
        }

        # Amazon.QuickSight.SelfUpgradeStatus
        "Update-QSSelfUpgradeConfiguration/SelfUpgradeStatus"
        {
            $v = "ADMIN_APPROVAL","AUTO_APPROVAL"
            break
        }

        # Amazon.QuickSight.ServiceType
        {
            ($_ -eq "Remove-QSIdentityPropagationConfig/Service") -Or
            ($_ -eq "Update-QSIdentityPropagationConfig/Service")
        }
        {
            $v = "ATHENA","QBUSINESS","REDSHIFT"
            break
        }

        # Amazon.QuickSight.SharingModel
        "New-QSFolder/SharingModel"
        {
            $v = "ACCOUNT","NAMESPACE"
            break
        }

        # Amazon.QuickSight.SheetContentType
        {
            ($_ -eq "New-QSAnalysis/DefaultNewSheetConfiguration_SheetContentType") -Or
            ($_ -eq "New-QSDashboard/DefaultNewSheetConfiguration_SheetContentType") -Or
            ($_ -eq "New-QSTemplate/DefaultNewSheetConfiguration_SheetContentType") -Or
            ($_ -eq "Update-QSAnalysis/DefaultNewSheetConfiguration_SheetContentType") -Or
            ($_ -eq "Update-QSDashboard/DefaultNewSheetConfiguration_SheetContentType") -Or
            ($_ -eq "Update-QSTemplate/DefaultNewSheetConfiguration_SheetContentType")
        }
        {
            $v = "INTERACTIVE","PAGINATED"
            break
        }

        # Amazon.QuickSight.StarburstProductType
        {
            ($_ -eq "New-QSDataSource/StarburstParameters_ProductType") -Or
            ($_ -eq "Update-QSDataSource/StarburstParameters_ProductType")
        }
        {
            $v = "ENTERPRISE","GALAXY"
            break
        }

        # Amazon.QuickSight.Status
        {
            ($_ -eq "New-QSDataSet/RowLevelPermissionDataSet_Status") -Or
            ($_ -eq "Update-QSDataSet/RowLevelPermissionDataSet_Status") -Or
            ($_ -eq "New-QSDataSet/RowLevelPermissionTagConfiguration_Status") -Or
            ($_ -eq "Update-QSDataSet/RowLevelPermissionTagConfiguration_Status")
        }
        {
            $v = "DISABLED","ENABLED"
            break
        }

        # Amazon.QuickSight.TextTransform
        {
            ($_ -eq "New-QSTheme/VisualSubtitleFontConfiguration_TextTransform") -Or
            ($_ -eq "Update-QSTheme/VisualSubtitleFontConfiguration_TextTransform") -Or
            ($_ -eq "New-QSTheme/VisualTitleFontConfiguration_TextTransform") -Or
            ($_ -eq "Update-QSTheme/VisualTitleFontConfiguration_TextTransform")
        }
        {
            $v = "CAPITALIZE"
            break
        }

        # Amazon.QuickSight.ThemeType
        "Get-QSThemeList/Type"
        {
            $v = "ALL","CUSTOM","QUICKSIGHT"
            break
        }

        # Amazon.QuickSight.TopicScheduleType
        {
            ($_ -eq "New-QSTopicRefreshSchedule/RefreshSchedule_TopicScheduleType") -Or
            ($_ -eq "Update-QSTopicRefreshSchedule/RefreshSchedule_TopicScheduleType")
        }
        {
            $v = "DAILY","HOURLY","MONTHLY","WEEKLY"
            break
        }

        # Amazon.QuickSight.TopicUserExperienceVersion
        {
            ($_ -eq "New-QSTopic/Topic_UserExperienceVersion") -Or
            ($_ -eq "Update-QSTopic/Topic_UserExperienceVersion")
        }
        {
            $v = "LEGACY","NEW_READER_EXPERIENCE"
            break
        }

        # Amazon.QuickSight.UserRole
        {
            ($_ -eq "Update-QSUser/Role") -Or
            ($_ -eq "Register-QSUser/UserRole")
        }
        {
            $v = "ADMIN","ADMIN_PRO","AUTHOR","AUTHOR_PRO","READER","READER_PRO","RESTRICTED_AUTHOR","RESTRICTED_READER"
            break
        }

        # Amazon.QuickSight.ValidationStrategyMode
        {
            ($_ -eq "New-QSAnalysis/ValidationStrategy_Mode") -Or
            ($_ -eq "New-QSDashboard/ValidationStrategy_Mode") -Or
            ($_ -eq "New-QSTemplate/ValidationStrategy_Mode") -Or
            ($_ -eq "Update-QSAnalysis/ValidationStrategy_Mode") -Or
            ($_ -eq "Update-QSDashboard/ValidationStrategy_Mode") -Or
            ($_ -eq "Update-QSTemplate/ValidationStrategy_Mode")
        }
        {
            $v = "LENIENT","STRICT"
            break
        }

        # Amazon.QuickSight.VisualHighlightTrigger
        {
            ($_ -eq "New-QSAnalysis/HighlightOperation_Trigger") -Or
            ($_ -eq "New-QSDashboard/HighlightOperation_Trigger") -Or
            ($_ -eq "New-QSTemplate/HighlightOperation_Trigger") -Or
            ($_ -eq "Update-QSAnalysis/HighlightOperation_Trigger") -Or
            ($_ -eq "Update-QSDashboard/HighlightOperation_Trigger") -Or
            ($_ -eq "Update-QSTemplate/HighlightOperation_Trigger")
        }
        {
            $v = "DATA_POINT_CLICK","DATA_POINT_HOVER","NONE"
            break
        }

        # Amazon.QuickSight.WebCrawlerAuthType
        {
            ($_ -eq "New-QSDataSource/WebCrawlerParameters_WebCrawlerAuthType") -Or
            ($_ -eq "Update-QSDataSource/WebCrawlerParameters_WebCrawlerAuthType")
        }
        {
            $v = "BASIC_AUTH","FORM","NO_AUTH","SAML"
            break
        }


    }

    $v |
        Where-Object { $_ -like "$wordToComplete*" } |
        ForEach-Object { New-Object System.Management.Automation.CompletionResult $_, $_, 'ParameterValue', $_ }
}

$QS_map = @{
    "Action"=@("Update-QSSelfUpgrade")
    "AdHocFilteringOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "AssignmentStatus"=@("Get-QSIAMPolicyAssignmentList","New-QSIAMPolicyAssignment","Update-QSIAMPolicyAssignment")
    "AuthenticationConfig_AuthenticationType"=@("New-QSActionConnector","Update-QSActionConnector")
    "AuthenticationMethod"=@("New-QSAccountSubscription")
    "AuthorizationCodeGrantMetadata_AuthorizationCodeGrantCredentialsSource"=@("New-QSActionConnector","Update-QSActionConnector")
    "AxisLabelFontConfiguration_FontDecoration"=@("New-QSTheme","Update-QSTheme")
    "AxisLabelFontConfiguration_FontStyle"=@("New-QSTheme","Update-QSTheme")
    "AxisTitleFontConfiguration_FontDecoration"=@("New-QSTheme","Update-QSTheme")
    "AxisTitleFontConfiguration_FontStyle"=@("New-QSTheme","Update-QSTheme")
    "Capabilities_Action"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_AddOrRunAnomalyDetectionForAnalyses"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_AmazonBedrockARSAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_AmazonBedrockFSAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_AmazonBedrockKRSAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_AmazonSThreeAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_Analysis"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_AsanaAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_Automate"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_BambooHRAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_BoxAgentAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CanvaAgentAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ChatAgent"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ComprehendAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ComprehendMedicalAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ConfluenceAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateAmazonBedrockARSAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateAmazonBedrockFSAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateAmazonBedrockKRSAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateAmazonSThreeAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateAsanaAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateBambooHRAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateBoxAgentAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateCanvaAgentAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateComprehendAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateComprehendMedicalAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateConfluenceAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateDashboardEmailReport"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateDataset"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateDataSource"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateFactSetAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateGenericHTTPAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateGithubAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateGoogleCalendarAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateHubspotAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateHuggingFaceAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateIntercomAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateJiraAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateLinearAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateMCPAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateMondayAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateMSExchangeAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateMSTeamsAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateNewRelicAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateNotionAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateOneDriveAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateOpenAPIAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdatePagerDutyAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateSalesforceAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateSandPGlobalEnergyAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateSandPGMIAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateSAPBillOfMaterialAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateSAPBusinessPartnerAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateSAPMaterialStockAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateSAPPhysicalInventoryAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateSAPProductMasterDataAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateServiceNowAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateSharePointAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateSlackAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateSmartsheetAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateTextractAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateTheme"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateThresholdAlert"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateAndUpdateZendeskAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateChatAgent"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateSharedFolder"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_CreateSPICEDataset"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_Dashboard"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ExportToCsv"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ExportToCsvInScheduledReport"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ExportToExcel"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ExportToExcelInScheduledReport"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ExportToPdf"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ExportToPdfInScheduledReport"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_FactSetAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_Flow"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_GenericHTTPAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_GithubAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_GoogleCalendarAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_HubspotAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_HuggingFaceAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_IncludeContentInScheduledReportsEmail"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_IntercomAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_JiraAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_KnowledgeBase"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_LinearAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_MCPAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_MondayAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_MSExchangeAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_MSTeamsAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_NewRelicAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_NotionAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_OneDriveAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_OpenAPIAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_PagerDutyAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_PerformFlowUiTask"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_PrintReport"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_PublishWithoutApproval"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_RenameSharedFolder"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_Research"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_SalesforceAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_SandPGlobalEnergyAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_SandPGMIAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_SAPBillOfMaterialAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_SAPBusinessPartnerAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_SAPMaterialStockAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_SAPPhysicalInventoryAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_SAPProductMasterDataAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_SelfUpgradeUserRole"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ServiceNowAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareAmazonBedrockARSAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareAmazonBedrockFSAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareAmazonBedrockKRSAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareAmazonSThreeAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareAnalyses"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareAsanaAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareBambooHRAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareBoxAgentAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareCanvaAgentAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareComprehendAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareComprehendMedicalAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareConfluenceAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareDashboard"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareDataset"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareDataSource"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareFactSetAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareGenericHTTPAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareGithubAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareGoogleCalendarAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareHubspotAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareHuggingFaceAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareIntercomAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareJiraAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareLinearAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareMCPAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareMondayAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareMSExchangeAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareMSTeamsAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareNewRelicAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareNotionAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareOneDriveAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareOpenAPIAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_SharePagerDutyAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_SharePointAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareSalesforceAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareSandPGlobalEnergyAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareSandPGMIAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareSAPBillOfMaterialAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareSAPBusinessPartnerAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareSAPMaterialStockAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareSAPPhysicalInventoryAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareSAPProductMasterDataAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareServiceNowAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareSharePointAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareSlackAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareSmartsheetAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareTextractAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ShareZendeskAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_SlackAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_SmartsheetAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_Space"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_SubscribeDashboardEmailReport"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_TextractAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseAgentWebSearch"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseAmazonBedrockARSAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseAmazonBedrockFSAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseAmazonBedrockKRSAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseAmazonSThreeAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseAsanaAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseBambooHRAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseBedrockModel"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseBoxAgentAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseCanvaAgentAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseComprehendAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseComprehendMedicalAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseConfluenceAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseFactSetAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseGenericHTTPAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseGithubAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseGoogleCalendarAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseHubspotAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseHuggingFaceAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseIntercomAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseJiraAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseLinearAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseMCPAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseMondayAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseMSExchangeAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseMSTeamsAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseNewRelicAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseNotionAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseOneDriveAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseOpenAPIAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UsePagerDutyAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseSalesforceAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseSandPGlobalEnergyAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseSandPGMIAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseSAPBillOfMaterialAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseSAPBusinessPartnerAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseSAPMaterialStockAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseSAPPhysicalInventoryAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseSAPProductMasterDataAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseServiceNowAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseSharePointAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseSlackAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseSmartsheetAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseTextractAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_UseZendeskAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ViewAccountSPICECapacity"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "Capabilities_ZendeskAction"=@("New-QSCustomPermission","Update-QSCustomPermission")
    "ClientCredentialsGrantMetadata_ClientCredentialsSource"=@("New-QSActionConnector","Update-QSActionConnector")
    "Configuration_Typography_AxisLabelFontConfiguration_FontSize_Relative"=@("New-QSTheme","Update-QSTheme")
    "Configuration_Typography_AxisLabelFontConfiguration_FontWeight_Name"=@("New-QSTheme","Update-QSTheme")
    "Configuration_Typography_AxisTitleFontConfiguration_FontSize_Relative"=@("New-QSTheme","Update-QSTheme")
    "Configuration_Typography_AxisTitleFontConfiguration_FontWeight_Name"=@("New-QSTheme","Update-QSTheme")
    "Configuration_Typography_DataLabelFontConfiguration_FontSize_Relative"=@("New-QSTheme","Update-QSTheme")
    "Configuration_Typography_DataLabelFontConfiguration_FontWeight_Name"=@("New-QSTheme","Update-QSTheme")
    "Configuration_Typography_LegendTitleFontConfiguration_FontSize_Relative"=@("New-QSTheme","Update-QSTheme")
    "Configuration_Typography_LegendTitleFontConfiguration_FontWeight_Name"=@("New-QSTheme","Update-QSTheme")
    "Configuration_Typography_LegendValueFontConfiguration_FontSize_Relative"=@("New-QSTheme","Update-QSTheme")
    "Configuration_Typography_LegendValueFontConfiguration_FontWeight_Name"=@("New-QSTheme","Update-QSTheme")
    "Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontDecoration"=@("New-QSTheme","Update-QSTheme")
    "Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontSize_Relative"=@("New-QSTheme","Update-QSTheme")
    "Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontStyle"=@("New-QSTheme","Update-QSTheme")
    "Configuration_Typography_VisualSubtitleFontConfiguration_FontConfiguration_FontWeight_Name"=@("New-QSTheme","Update-QSTheme")
    "Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontDecoration"=@("New-QSTheme","Update-QSTheme")
    "Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontSize_Relative"=@("New-QSTheme","Update-QSTheme")
    "Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontStyle"=@("New-QSTheme","Update-QSTheme")
    "Configuration_Typography_VisualTitleFontConfiguration_FontConfiguration_FontWeight_Name"=@("New-QSTheme","Update-QSTheme")
    "DashboardsQAStatus"=@("Update-QSDashboardsQAConfiguration")
    "DataLabelFontConfiguration_FontDecoration"=@("New-QSTheme","Update-QSTheme")
    "DataLabelFontConfiguration_FontStyle"=@("New-QSTheme","Update-QSTheme")
    "DataPointDrillUpDownOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "DataPointMenuLabelOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "DataPointTooltipOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "DataQAEnabledOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "DataStoriesSharingOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "DefaultNewSheetConfiguration_SheetContentType"=@("New-QSAnalysis","New-QSDashboard","New-QSTemplate","Update-QSAnalysis","Update-QSDashboard","Update-QSTemplate")
    "Edition"=@("New-QSAccountSubscription")
    "EmailAlert_AlertStatus"=@("Write-QSDataSetRefreshProperty")
    "ExecutiveSummaryOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "ExportFormat"=@("Start-QSAssetBundleExportJob")
    "ExportHiddenFieldsOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "ExportToCSVOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "ExportWithHiddenFieldsOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "FailureAction"=@("Start-QSAssetBundleImportJob")
    "FolderType"=@("New-QSFolder")
    "HighlightOperation_Trigger"=@("New-QSAnalysis","New-QSDashboard","New-QSTemplate","Update-QSAnalysis","Update-QSDashboard","Update-QSTemplate")
    "IdentityStore"=@("New-QSNamespace")
    "IdentityType"=@("Get-QSDashboardEmbedUrl","Register-QSUser")
    "ImportMode"=@("New-QSDataSet","Update-QSDataSet")
    "IncludeFolderMember"=@("Start-QSAssetBundleExportJob")
    "IncludeGeneratedAnswer"=@("Search-QSQAResult")
    "IncludeQuickSightQIndex"=@("Search-QSQAResult")
    "IngestionType"=@("New-QSIngestion")
    "LegendTitleFontConfiguration_FontDecoration"=@("New-QSTheme","Update-QSTheme")
    "LegendTitleFontConfiguration_FontStyle"=@("New-QSTheme","Update-QSTheme")
    "LegendValueFontConfiguration_FontDecoration"=@("New-QSTheme","Update-QSTheme")
    "LegendValueFontConfiguration_FontStyle"=@("New-QSTheme","Update-QSTheme")
    "LookbackWindow_SizeUnit"=@("Write-QSDataSetRefreshProperty")
    "MemberType"=@("New-QSFolderMembership","Remove-QSFolderMembership")
    "Options_QBusinessInsightsStatus"=@("New-QSAnalysis","New-QSDashboard","New-QSTemplate","Update-QSAnalysis","Update-QSDashboard","Update-QSTemplate")
    "Options_WeekStart"=@("New-QSAnalysis","New-QSDashboard","New-QSTemplate","Update-QSAnalysis","Update-QSDashboard","Update-QSTemplate")
    "PaperCanvasSizeOptions_PaperOrientation"=@("New-QSAnalysis","New-QSDashboard","New-QSTemplate","Update-QSAnalysis","Update-QSDashboard","Update-QSTemplate")
    "PaperCanvasSizeOptions_PaperSize"=@("New-QSAnalysis","New-QSDashboard","New-QSTemplate","Update-QSAnalysis","Update-QSDashboard","Update-QSTemplate")
    "PersonalizationMode"=@("Update-QSQPersonalizationConfiguration")
    "PurchaseMode"=@("Update-QSSPICECapacityConfiguration")
    "QSearchStatus"=@("Update-QSQuickSightQSearchConfiguration")
    "QueryExecutionOptions_QueryExecutionMode"=@("New-QSAnalysis","New-QSTemplate","Update-QSAnalysis","Update-QSTemplate")
    "QuickSuiteActionsOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "RefreshOnDay_DayOfWeek"=@("New-QSRefreshSchedule","Update-QSRefreshSchedule")
    "RefreshSchedule_TopicScheduleType"=@("New-QSTopicRefreshSchedule","Update-QSTopicRefreshSchedule")
    "Role"=@("Get-QSRoleCustomPermission","Get-QSRoleMembershipList","New-QSRoleMembership","Remove-QSRoleCustomPermission","Remove-QSRoleMembership","Update-QSRoleCustomPermission","Update-QSUser")
    "RowLevelPermissionDataSet_FormatVersion"=@("New-QSDataSet","Update-QSDataSet")
    "RowLevelPermissionDataSet_PermissionPolicy"=@("New-QSDataSet","Update-QSDataSet")
    "RowLevelPermissionDataSet_Status"=@("New-QSDataSet","Update-QSDataSet")
    "RowLevelPermissionTagConfiguration_Status"=@("New-QSDataSet","Update-QSDataSet")
    "Schedule_RefreshType"=@("New-QSRefreshSchedule","Update-QSRefreshSchedule")
    "ScheduleFrequency_Interval"=@("New-QSRefreshSchedule","Update-QSRefreshSchedule")
    "ScreenCanvasSizeOptions_ResizeOption"=@("New-QSAnalysis","New-QSDashboard","New-QSTemplate","Update-QSAnalysis","Update-QSDashboard","Update-QSTemplate")
    "SelfUpgradeStatus"=@("Update-QSSelfUpgradeConfiguration")
    "Service"=@("Remove-QSIdentityPropagationConfig","Update-QSIdentityPropagationConfig")
    "SharingModel"=@("New-QSFolder")
    "SheetControlsOption_VisibilityState"=@("New-QSDashboard","Update-QSDashboard")
    "SheetLayoutElementMaximizationOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "SnowflakeParameters_AuthenticationType"=@("New-QSDataSource","Update-QSDataSource")
    "StarburstParameters_AuthenticationType"=@("New-QSDataSource","Update-QSDataSource")
    "StarburstParameters_ProductType"=@("New-QSDataSource","Update-QSDataSource")
    "Topic_UserExperienceVersion"=@("New-QSTopic","Update-QSTopic")
    "Type"=@("Get-QSThemeList","New-QSActionConnector","New-QSDataSource")
    "UseAs"=@("New-QSDataSet")
    "UserRole"=@("Register-QSUser")
    "ValidationStrategy_Mode"=@("New-QSAnalysis","New-QSDashboard","New-QSTemplate","Update-QSAnalysis","Update-QSDashboard","Update-QSTemplate")
    "VisualAxisSortOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "VisualMenuOption_AvailabilityStatus"=@("New-QSDashboard","Update-QSDashboard")
    "VisualSubtitleFontConfiguration_TextAlignment"=@("New-QSTheme","Update-QSTheme")
    "VisualSubtitleFontConfiguration_TextTransform"=@("New-QSTheme","Update-QSTheme")
    "VisualTitleFontConfiguration_TextAlignment"=@("New-QSTheme","Update-QSTheme")
    "VisualTitleFontConfiguration_TextTransform"=@("New-QSTheme","Update-QSTheme")
    "WebCrawlerParameters_WebCrawlerAuthType"=@("New-QSDataSource","Update-QSDataSource")
}

_awsArgumentCompleterRegistration $QS_Completers $QS_map

$QS_SelectCompleters = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameter)

    $cmdletType = Invoke-Expression "[Amazon.PowerShell.Cmdlets.QS.$($commandName.Replace('-', ''))Cmdlet]"
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

$QS_SelectMap = @{
    "Select"=@("Set-QSBatchCreateTopicReviewedAnswer",
               "Set-QSBatchDeleteTopicReviewedAnswer",
               "Stop-QSIngestion",
               "New-QSAccountCustomization",
               "New-QSAccountSubscription",
               "New-QSActionConnector",
               "New-QSAnalysis",
               "New-QSBrand",
               "New-QSCustomPermission",
               "New-QSDashboard",
               "New-QSDataSet",
               "New-QSDataSource",
               "New-QSFolder",
               "New-QSFolderMembership",
               "New-QSGroup",
               "New-QSGroupMembership",
               "New-QSIAMPolicyAssignment",
               "New-QSIngestion",
               "New-QSNamespace",
               "New-QSRefreshSchedule",
               "New-QSRoleMembership",
               "New-QSTemplate",
               "New-QSTemplateAlias",
               "New-QSTheme",
               "New-QSThemeAlias",
               "New-QSTopic",
               "New-QSTopicRefreshSchedule",
               "New-QSVPCConnection",
               "Remove-QSAccountCustomization",
               "Remove-QSAccountCustomPermission",
               "Remove-QSAccountSubscription",
               "Remove-QSActionConnector",
               "Remove-QSAnalysis",
               "Remove-QSBrand",
               "Remove-QSBrandAssignment",
               "Remove-QSCustomPermission",
               "Remove-QSDashboard",
               "Remove-QSDataSet",
               "Remove-QSDataSetRefreshProperty",
               "Remove-QSDataSource",
               "Remove-QSDefaultQBusinessApplication",
               "Remove-QSFolder",
               "Remove-QSFolderMembership",
               "Remove-QSGroup",
               "Remove-QSGroupMembership",
               "Remove-QSIAMPolicyAssignment",
               "Remove-QSIdentityPropagationConfig",
               "Remove-QSNamespace",
               "Remove-QSRefreshSchedule",
               "Remove-QSRoleCustomPermission",
               "Remove-QSRoleMembership",
               "Remove-QSTemplate",
               "Remove-QSTemplateAlias",
               "Remove-QSTheme",
               "Remove-QSThemeAlias",
               "Remove-QSTopic",
               "Remove-QSTopicRefreshSchedule",
               "Remove-QSUser",
               "Remove-QSUserByPrincipalId",
               "Remove-QSUserCustomPermission",
               "Remove-QSVPCConnection",
               "Get-QSAccountCustomization",
               "Get-QSAccountCustomPermission",
               "Get-QSAccountSetting",
               "Get-QSAccountSubscription",
               "Get-QSActionConnector",
               "Get-QSActionConnectorPermission",
               "Get-QSAnalysis",
               "Get-QSAnalysisDefinition",
               "Get-QSAnalysisPermission",
               "Get-QSAssetBundleExportJob",
               "Get-QSAssetBundleImportJob",
               "Get-QSBrand",
               "Get-QSBrandAssignment",
               "Get-QSBrandPublishedVersion",
               "Get-QSCustomPermission",
               "Get-QSDashboard",
               "Get-QSDashboardDefinition",
               "Get-QSDashboardPermission",
               "Get-QSDashboardSnapshotJob",
               "Get-QSDashboardSnapshotJobResult",
               "Get-QSDashboardsQAConfiguration",
               "Get-QSDataSet",
               "Get-QSDataSetPermission",
               "Get-QSDataSetRefreshProperty",
               "Get-QSDataSource",
               "Get-QSDataSourcePermission",
               "Get-QSDefaultQBusinessApplication",
               "Get-QSFolder",
               "Get-QSFolderPermission",
               "Get-QSFolderResolvedPermission",
               "Get-QSGroup",
               "Get-QSGroupMembership",
               "Get-QSIAMPolicyAssignment",
               "Get-QSIngestion",
               "Get-QSIpRestriction",
               "Get-QSKeyRegistration",
               "Get-QSNamespace",
               "Get-QSQPersonalizationConfiguration",
               "Get-QSQuickSightQSearchConfiguration",
               "Get-QSRefreshSchedule",
               "Get-QSRoleCustomPermission",
               "Get-QSSelfUpgradeConfigurationDetail",
               "Get-QSTemplate",
               "Get-QSTemplateAlias",
               "Get-QSTemplateDefinition",
               "Get-QSTemplatePermission",
               "Get-QSTheme",
               "Get-QSThemeAlias",
               "Get-QSThemePermission",
               "Get-QSTopic",
               "Get-QSTopicPermission",
               "Get-QSTopicRefresh",
               "Get-QSTopicRefreshSchedule",
               "Get-QSUser",
               "Get-QSVPCConnection",
               "New-QSEmbedUrlForAnonymousUser",
               "New-QSEmbedUrlForRegisteredUser",
               "Initialize-QSEmbedUrlForRegisteredUserWithIdentity",
               "Get-QSDashboardEmbedUrl",
               "Get-QSFlowMetadata",
               "Get-QSFlowPermission",
               "Get-QSIdentityContext",
               "Get-QSSessionEmbedUrl",
               "Get-QSActionConnectorList",
               "Get-QSAnalysisList",
               "Get-QSAssetBundleExportJobList",
               "Get-QSAssetBundleImportJobList",
               "Get-QSBrandList",
               "Get-QSCustomPermissionList",
               "Get-QSDashboardList",
               "Get-QSDashboardVersionList",
               "Get-QSDataSetList",
               "Get-QSDataSourceList",
               "Get-QSFlowList",
               "Get-QSFolderMemberList",
               "Get-QSFolderList",
               "Get-QSFoldersForResourceList",
               "Get-QSGroupMembershipList",
               "Get-QSGroupList",
               "Get-QSIAMPolicyAssignmentList",
               "Get-QSIAMPolicyAssignmentsForUserList",
               "Get-QSIdentityPropagationConfigList",
               "Get-QSIngestionList",
               "Get-QSNamespaceList",
               "Get-QSRefreshScheduleList",
               "Get-QSRoleMembershipList",
               "Get-QSSelfUpgradeList",
               "Get-QSResourceTag",
               "Get-QSTemplateAliasList",
               "Get-QSTemplateList",
               "Get-QSTemplateVersionList",
               "Get-QSThemeAliasList",
               "Get-QSThemeList",
               "Get-QSThemeVersionList",
               "Get-QSTopicRefreshScheduleList",
               "Get-QSTopicReviewedAnswerList",
               "Get-QSTopicList",
               "Get-QSUserGroupList",
               "Get-QSUserList",
               "Get-QSVPCConnectionList",
               "Search-QSQAResult",
               "Write-QSDataSetRefreshProperty",
               "Register-QSUser",
               "Restore-QSAnalysis",
               "Search-QSActionConnector",
               "Search-QSAnalysis",
               "Search-QSDashboard",
               "Search-QSDataSet",
               "Search-QSDataSource",
               "Search-QSFlow",
               "Search-QSFolder",
               "Find-QSGroup",
               "Search-QSTopic",
               "Start-QSAssetBundleExportJob",
               "Start-QSAssetBundleImportJob",
               "Start-QSDashboardSnapshotJob",
               "Start-QSDashboardSnapshotJobSchedule",
               "Add-QSResourceTag",
               "Remove-QSResourceTag",
               "Update-QSAccountCustomization",
               "Update-QSAccountCustomPermission",
               "Update-QSAccountSetting",
               "Update-QSActionConnector",
               "Update-QSActionConnectorPermission",
               "Update-QSAnalysis",
               "Update-QSAnalysisPermission",
               "Update-QSApplicationWithTokenExchangeGrant",
               "Update-QSBrand",
               "Update-QSBrandAssignment",
               "Update-QSBrandPublishedVersion",
               "Update-QSCustomPermission",
               "Update-QSDashboard",
               "Update-QSDashboardLink",
               "Update-QSDashboardPermission",
               "Update-QSDashboardPublishedVersion",
               "Update-QSDashboardsQAConfiguration",
               "Update-QSDataSet",
               "Update-QSDataSetPermission",
               "Update-QSDataSource",
               "Update-QSDataSourcePermission",
               "Update-QSDefaultQBusinessApplication",
               "Update-QSFlowPermission",
               "Update-QSFolder",
               "Update-QSFolderPermission",
               "Update-QSGroup",
               "Update-QSIAMPolicyAssignment",
               "Update-QSIdentityPropagationConfig",
               "Update-QSIpRestriction",
               "Update-QSKeyRegistration",
               "Update-QSPublicSharingSetting",
               "Update-QSQPersonalizationConfiguration",
               "Update-QSQuickSightQSearchConfiguration",
               "Update-QSRefreshSchedule",
               "Update-QSRoleCustomPermission",
               "Update-QSSelfUpgrade",
               "Update-QSSelfUpgradeConfiguration",
               "Update-QSSPICECapacityConfiguration",
               "Update-QSTemplate",
               "Update-QSTemplateAlias",
               "Update-QSTemplatePermission",
               "Update-QSTheme",
               "Update-QSThemeAlias",
               "Update-QSThemePermission",
               "Update-QSTopic",
               "Update-QSTopicPermission",
               "Update-QSTopicRefreshSchedule",
               "Update-QSUser",
               "Update-QSUserCustomPermission",
               "Update-QSVPCConnection")
}

_awsArgumentCompleterRegistration $QS_SelectCompleters $QS_SelectMap

