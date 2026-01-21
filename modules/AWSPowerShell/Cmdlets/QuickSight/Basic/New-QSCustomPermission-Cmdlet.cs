/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using System.Threading;
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Creates a custom permissions profile.
    /// </summary>
    [Cmdlet("New", "QSCustomPermission", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon QuickSight CreateCustomPermissions API operation.", Operation = new[] {"CreateCustomPermissions"}, SelectReturnType = typeof(Amazon.QuickSight.Model.CreateCustomPermissionsResponse))]
    [AWSCmdletOutput("System.String or Amazon.QuickSight.Model.CreateCustomPermissionsResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.QuickSight.Model.CreateCustomPermissionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewQSCustomPermissionCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Capabilities_Action
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions in external services through Action connectors. Actions
        /// allow users to interact with third-party systems.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_Action { get; set; }
        #endregion
        
        #region Parameter Capabilities_AddOrRunAnomalyDetectionForAnalyses
        /// <summary>
        /// <para>
        /// <para>The ability to add or run anomaly detection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_AddOrRunAnomalyDetectionForAnalyses { get; set; }
        #endregion
        
        #region Parameter Capabilities_AmazonBedrockARSAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Bedrock Agent connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_AmazonBedrockARSAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_AmazonBedrockFSAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Bedrock Runtime connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_AmazonBedrockFSAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_AmazonBedrockKRSAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Bedrock Data Automation Runtime connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_AmazonBedrockKRSAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_AmazonSThreeAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Amazon S3 connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_AmazonSThreeAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_Analysis
        /// <summary>
        /// <para>
        /// <para>The ability to perform analysis-related actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_Analysis { get; set; }
        #endregion
        
        #region Parameter Capabilities_AsanaAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Asana connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_AsanaAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_Automate
        /// <summary>
        /// <para>
        /// <para>The ability to perform automate-related actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_Automate { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that you want to create the custom permissions
        /// profile in.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter Capabilities_BambooHRAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using BambooHR connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_BambooHRAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_BoxAgentAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Box Agent connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_BoxAgentAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CanvaAgentAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Canva Agent connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CanvaAgentAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ChatAgent
        /// <summary>
        /// <para>
        /// <para>The ability to perform chat-related actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ChatAgent { get; set; }
        #endregion
        
        #region Parameter Capabilities_ComprehendAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Comprehend connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ComprehendAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ComprehendMedicalAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Comprehend Medical connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ComprehendMedicalAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ConfluenceAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Atlassian Confluence Cloud connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ConfluenceAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateAmazonBedrockARSAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Bedrock Agent actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateAmazonBedrockARSAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateAmazonBedrockFSAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Bedrock Runtime actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateAmazonBedrockFSAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateAmazonBedrockKRSAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Bedrock Data Automation Runtime actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateAmazonBedrockKRSAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateAmazonSThreeAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Amazon S3 actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateAmazonSThreeAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateAsanaAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Asana actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateAsanaAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateBambooHRAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update BambooHR actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateBambooHRAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateBoxAgentAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Box Agent actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateBoxAgentAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateCanvaAgentAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Canva Agent actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateCanvaAgentAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateComprehendAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Comprehend actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateComprehendAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateComprehendMedicalAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Comprehend Medical actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateComprehendMedicalAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateConfluenceAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Atlassian Confluence Cloud actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateConfluenceAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateDashboardEmailReport
        /// <summary>
        /// <para>
        /// <para>The ability to create and update email reports.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities_CreateAndUpdateDashboardEmailReports")]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateDashboardEmailReport { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateDataset
        /// <summary>
        /// <para>
        /// <para>The ability to create and update datasets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities_CreateAndUpdateDatasets")]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateDataset { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateDataSource
        /// <summary>
        /// <para>
        /// <para>The ability to create and update data sources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities_CreateAndUpdateDataSources")]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateDataSource { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateFactSetAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update FactSet actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateFactSetAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateGenericHTTPAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update REST API connection actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateGenericHTTPAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateGithubAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update GitHub actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateGithubAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateGoogleCalendarAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Google Calendar actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateGoogleCalendarAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateHubspotAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Hubspot actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateHubspotAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateHuggingFaceAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update HuggingFace actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateHuggingFaceAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateIntercomAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Intercom actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateIntercomAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateJiraAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Jira actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateJiraAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateLinearAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Linear actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateLinearAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateMCPAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Model Context Protocol actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateMCPAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateMondayAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Monday actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateMondayAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateMSExchangeAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Microsoft Outlook actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateMSExchangeAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateMSTeamsAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Microsoft Teams actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateMSTeamsAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateNewRelicAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update New Relic actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateNewRelicAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateNotionAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Notion actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateNotionAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateOneDriveAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Microsoft OneDrive actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateOneDriveAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateOpenAPIAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update OpenAPI Specification actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateOpenAPIAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdatePagerDutyAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update PagerDuty Advance actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdatePagerDutyAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateSalesforceAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Salesforce actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateSalesforceAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateSandPGlobalEnergyAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update S&amp;P Global Energy actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateSandPGlobalEnergyAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateSandPGMIAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update S&amp;P Global Market Intelligence actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateSandPGMIAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateSAPBillOfMaterialAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update SAP Bill of Materials actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateSAPBillOfMaterialAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateSAPBusinessPartnerAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update SAP Business Partner actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateSAPBusinessPartnerAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateSAPMaterialStockAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update SAP Material Stock actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateSAPMaterialStockAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateSAPPhysicalInventoryAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update SAP Physical Inventory actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateSAPPhysicalInventoryAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateSAPProductMasterDataAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update SAP Product Master actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateSAPProductMasterDataAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateServiceNowAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update ServiceNow actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateServiceNowAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateSharePointAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Microsoft SharePoint Online actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateSharePointAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateSlackAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Slack actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateSlackAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateSmartsheetAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Smartsheet actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateSmartsheetAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateTextractAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Textract actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateTextractAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateTheme
        /// <summary>
        /// <para>
        /// <para>The ability to export to Create and Update themes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities_CreateAndUpdateThemes")]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateTheme { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateThresholdAlert
        /// <summary>
        /// <para>
        /// <para>The ability to create and update threshold alerts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities_CreateAndUpdateThresholdAlerts")]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateThresholdAlert { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateAndUpdateZendeskAction
        /// <summary>
        /// <para>
        /// <para>The ability to create and update Zendesk actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateZendeskAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateChatAgent
        /// <summary>
        /// <para>
        /// <para>The ability to create chat agents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities_CreateChatAgents")]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateChatAgent { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateSharedFolder
        /// <summary>
        /// <para>
        /// <para>The ability to create shared folders.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities_CreateSharedFolders")]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateSharedFolder { get; set; }
        #endregion
        
        #region Parameter Capabilities_CreateSPICEDataset
        /// <summary>
        /// <para>
        /// <para>The ability to create a SPICE dataset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_CreateSPICEDataset { get; set; }
        #endregion
        
        #region Parameter CustomPermissionsName
        /// <summary>
        /// <para>
        /// <para>The name of the custom permissions profile that you want to create.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String CustomPermissionsName { get; set; }
        #endregion
        
        #region Parameter Capabilities_Dashboard
        /// <summary>
        /// <para>
        /// <para>The ability to perform dashboard-related actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_Dashboard { get; set; }
        #endregion
        
        #region Parameter Capabilities_ExportToCsv
        /// <summary>
        /// <para>
        /// <para>The ability to export to CSV files from the UI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ExportToCsv { get; set; }
        #endregion
        
        #region Parameter Capabilities_ExportToCsvInScheduledReport
        /// <summary>
        /// <para>
        /// <para>The ability to export to CSV files in scheduled email reports.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities_ExportToCsvInScheduledReports")]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ExportToCsvInScheduledReport { get; set; }
        #endregion
        
        #region Parameter Capabilities_ExportToExcel
        /// <summary>
        /// <para>
        /// <para>The ability to export to Excel files from the UI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ExportToExcel { get; set; }
        #endregion
        
        #region Parameter Capabilities_ExportToExcelInScheduledReport
        /// <summary>
        /// <para>
        /// <para>The ability to export to Excel files in scheduled email reports.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities_ExportToExcelInScheduledReports")]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ExportToExcelInScheduledReport { get; set; }
        #endregion
        
        #region Parameter Capabilities_ExportToPdf
        /// <summary>
        /// <para>
        /// <para>The ability to export to PDF files from the UI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ExportToPdf { get; set; }
        #endregion
        
        #region Parameter Capabilities_ExportToPdfInScheduledReport
        /// <summary>
        /// <para>
        /// <para>The ability to export to PDF files in scheduled email reports.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities_ExportToPdfInScheduledReports")]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ExportToPdfInScheduledReport { get; set; }
        #endregion
        
        #region Parameter Capabilities_FactSetAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using FactSet connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_FactSetAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_Flow
        /// <summary>
        /// <para>
        /// <para>The ability to perform flow-related actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_Flow { get; set; }
        #endregion
        
        #region Parameter Capabilities_GenericHTTPAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using REST API connection connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_GenericHTTPAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_GithubAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using GitHub connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_GithubAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_GoogleCalendarAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Google Calendar connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_GoogleCalendarAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_HubspotAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Hubspot connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_HubspotAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_HuggingFaceAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using HuggingFace connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_HuggingFaceAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_IncludeContentInScheduledReportsEmail
        /// <summary>
        /// <para>
        /// <para>The ability to include content in scheduled email reports.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_IncludeContentInScheduledReportsEmail { get; set; }
        #endregion
        
        #region Parameter Capabilities_IntercomAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Intercom connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_IntercomAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_JiraAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Jira connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_JiraAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_KnowledgeBase
        /// <summary>
        /// <para>
        /// <para>The ability to use knowledge bases to specify content from external applications.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_KnowledgeBase { get; set; }
        #endregion
        
        #region Parameter Capabilities_LinearAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Linear connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_LinearAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_MCPAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Model Context Protocol connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_MCPAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_MondayAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Monday connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_MondayAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_MSExchangeAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Microsoft Outlook connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_MSExchangeAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_MSTeamsAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Microsoft Teams connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_MSTeamsAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_NewRelicAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using New Relic connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_NewRelicAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_NotionAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Notion connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_NotionAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_OneDriveAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Microsoft OneDrive connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_OneDriveAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_OpenAPIAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using OpenAPI Specification connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_OpenAPIAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_PagerDutyAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using PagerDuty Advance connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_PagerDutyAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_PerformFlowUiTask
        /// <summary>
        /// <para>
        /// <para>The ability to use UI Agent step to perform tasks on public websites.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_PerformFlowUiTask { get; set; }
        #endregion
        
        #region Parameter Capabilities_PrintReport
        /// <summary>
        /// <para>
        /// <para>The ability to print reports.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities_PrintReports")]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_PrintReport { get; set; }
        #endregion
        
        #region Parameter Capabilities_PublishWithoutApproval
        /// <summary>
        /// <para>
        /// <para>The ability to enable approvals for flow share.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_PublishWithoutApproval { get; set; }
        #endregion
        
        #region Parameter Capabilities_RenameSharedFolder
        /// <summary>
        /// <para>
        /// <para>The ability to rename shared folders.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities_RenameSharedFolders")]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_RenameSharedFolder { get; set; }
        #endregion
        
        #region Parameter Capabilities_Research
        /// <summary>
        /// <para>
        /// <para>The ability to perform research-related actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_Research { get; set; }
        #endregion
        
        #region Parameter Capabilities_SalesforceAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Salesforce connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_SalesforceAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_SandPGlobalEnergyAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using S&amp;P Global Energy connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_SandPGlobalEnergyAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_SandPGMIAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using S&amp;P Global Market Intelligence connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_SandPGMIAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_SAPBillOfMaterialAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using SAP Bill of Materials connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_SAPBillOfMaterialAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_SAPBusinessPartnerAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using SAP Business Partner connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_SAPBusinessPartnerAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_SAPMaterialStockAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using SAP Material Stock connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_SAPMaterialStockAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_SAPPhysicalInventoryAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using SAP Physical Inventory connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_SAPPhysicalInventoryAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_SAPProductMasterDataAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using SAP Product Master connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_SAPProductMasterDataAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_SelfUpgradeUserRole
        /// <summary>
        /// <para>
        /// <para>The ability to enable users to upgrade their user role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_SelfUpgradeUserRole { get; set; }
        #endregion
        
        #region Parameter Capabilities_ServiceNowAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using ServiceNow connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ServiceNowAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareAmazonBedrockARSAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Bedrock Agent actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareAmazonBedrockARSAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareAmazonBedrockFSAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Bedrock Runtime actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareAmazonBedrockFSAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareAmazonBedrockKRSAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Bedrock Data Automation Runtime actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareAmazonBedrockKRSAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareAmazonSThreeAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Amazon S3 actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareAmazonSThreeAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareAnalyses
        /// <summary>
        /// <para>
        /// <para>The ability to share analyses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareAnalyses { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareAsanaAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Asana actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareAsanaAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareBambooHRAction
        /// <summary>
        /// <para>
        /// <para>The ability to share BambooHR actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareBambooHRAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareBoxAgentAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Box Agent actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareBoxAgentAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareCanvaAgentAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Canva Agent actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareCanvaAgentAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareComprehendAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Comprehend actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareComprehendAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareComprehendMedicalAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Comprehend Medical actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareComprehendMedicalAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareConfluenceAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Atlassian Confluence Cloud actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareConfluenceAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareDashboard
        /// <summary>
        /// <para>
        /// <para>The ability to share dashboards.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities_ShareDashboards")]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareDashboard { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareDataset
        /// <summary>
        /// <para>
        /// <para>The ability to share datasets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities_ShareDatasets")]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareDataset { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareDataSource
        /// <summary>
        /// <para>
        /// <para>The ability to share data sources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities_ShareDataSources")]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareDataSource { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareFactSetAction
        /// <summary>
        /// <para>
        /// <para>The ability to share FactSet actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareFactSetAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareGenericHTTPAction
        /// <summary>
        /// <para>
        /// <para>The ability to share REST API connection actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareGenericHTTPAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareGithubAction
        /// <summary>
        /// <para>
        /// <para>The ability to share GitHub actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareGithubAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareGoogleCalendarAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Google Calendar actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareGoogleCalendarAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareHubspotAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Hubspot actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareHubspotAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareHuggingFaceAction
        /// <summary>
        /// <para>
        /// <para>The ability to share HuggingFace actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareHuggingFaceAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareIntercomAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Intercom actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareIntercomAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareJiraAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Jira actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareJiraAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareLinearAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Linear actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareLinearAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareMCPAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Model Context Protocol actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareMCPAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareMondayAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Monday actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareMondayAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareMSExchangeAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Microsoft Outlook actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareMSExchangeAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareMSTeamsAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Microsoft Teams actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareMSTeamsAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareNewRelicAction
        /// <summary>
        /// <para>
        /// <para>The ability to share New Relic actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareNewRelicAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareNotionAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Notion actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareNotionAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareOneDriveAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Microsoft OneDrive actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareOneDriveAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareOpenAPIAction
        /// <summary>
        /// <para>
        /// <para>The ability to share OpenAPI Specification actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareOpenAPIAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_SharePagerDutyAction
        /// <summary>
        /// <para>
        /// <para>The ability to share PagerDuty Advance actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_SharePagerDutyAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_SharePointAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Microsoft SharePoint Online connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_SharePointAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareSalesforceAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Salesforce actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareSalesforceAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareSandPGlobalEnergyAction
        /// <summary>
        /// <para>
        /// <para>The ability to share S&amp;P Global Energy actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareSandPGlobalEnergyAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareSandPGMIAction
        /// <summary>
        /// <para>
        /// <para>The ability to share S&amp;P Global Market Intelligence actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareSandPGMIAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareSAPBillOfMaterialAction
        /// <summary>
        /// <para>
        /// <para>The ability to share SAP Bill of Materials actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareSAPBillOfMaterialAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareSAPBusinessPartnerAction
        /// <summary>
        /// <para>
        /// <para>The ability to share SAP Business Partner actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareSAPBusinessPartnerAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareSAPMaterialStockAction
        /// <summary>
        /// <para>
        /// <para>The ability to share SAP Material Stock actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareSAPMaterialStockAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareSAPPhysicalInventoryAction
        /// <summary>
        /// <para>
        /// <para>The ability to share SAP Physical Inventory actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareSAPPhysicalInventoryAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareSAPProductMasterDataAction
        /// <summary>
        /// <para>
        /// <para>The ability to share SAP Product Master actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareSAPProductMasterDataAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareServiceNowAction
        /// <summary>
        /// <para>
        /// <para>The ability to share ServiceNow actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareServiceNowAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareSharePointAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Microsoft SharePoint Online actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareSharePointAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareSlackAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Slack actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareSlackAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareSmartsheetAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Smartsheet actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareSmartsheetAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareTextractAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Textract actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareTextractAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ShareZendeskAction
        /// <summary>
        /// <para>
        /// <para>The ability to share Zendesk actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ShareZendeskAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_SlackAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Slack connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_SlackAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_SmartsheetAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Smartsheet connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_SmartsheetAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_Space
        /// <summary>
        /// <para>
        /// <para>The ability to perform space-related actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_Space { get; set; }
        #endregion
        
        #region Parameter Capabilities_SubscribeDashboardEmailReport
        /// <summary>
        /// <para>
        /// <para>The ability to subscribe to email reports.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities_SubscribeDashboardEmailReports")]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_SubscribeDashboardEmailReport { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to associate with the custom permissions profile.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.QuickSight.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Capabilities_TextractAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Textract connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_TextractAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseAgentWebSearch
        /// <summary>
        /// <para>
        /// <para>The ability to use internet to enhance results in Chat Agents, Flows, and Quick Research.
        /// Web search queries will be processed securely in an Amazon Web Services region <c>us-east-1</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseAgentWebSearch { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseAmazonBedrockARSAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Bedrock Agent actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseAmazonBedrockARSAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseAmazonBedrockFSAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Bedrock Runtime actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseAmazonBedrockFSAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseAmazonBedrockKRSAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Bedrock Data Automation Runtime actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseAmazonBedrockKRSAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseAmazonSThreeAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Amazon S3 actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseAmazonSThreeAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseAsanaAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Asana actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseAsanaAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseBambooHRAction
        /// <summary>
        /// <para>
        /// <para>The ability to use BambooHR actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseBambooHRAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseBedrockModel
        /// <summary>
        /// <para>
        /// <para>The ability to use Bedrock models for general knowledge step in flows.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities_UseBedrockModels")]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseBedrockModel { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseBoxAgentAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Box Agent actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseBoxAgentAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseCanvaAgentAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Canva Agent actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseCanvaAgentAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseComprehendAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Comprehend actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseComprehendAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseComprehendMedicalAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Comprehend Medical actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseComprehendMedicalAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseConfluenceAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Atlassian Confluence Cloud actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseConfluenceAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseFactSetAction
        /// <summary>
        /// <para>
        /// <para>The ability to use FactSet actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseFactSetAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseGenericHTTPAction
        /// <summary>
        /// <para>
        /// <para>The ability to use REST API connection actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseGenericHTTPAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseGithubAction
        /// <summary>
        /// <para>
        /// <para>The ability to use GitHub actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseGithubAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseGoogleCalendarAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Google Calendar actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseGoogleCalendarAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseHubspotAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Hubspot actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseHubspotAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseHuggingFaceAction
        /// <summary>
        /// <para>
        /// <para>The ability to use HuggingFace actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseHuggingFaceAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseIntercomAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Intercom actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseIntercomAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseJiraAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Jira actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseJiraAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseLinearAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Linear actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseLinearAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseMCPAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Model Context Protocol actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseMCPAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseMondayAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Monday actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseMondayAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseMSExchangeAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Microsoft Outlook actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseMSExchangeAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseMSTeamsAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Microsoft Teams actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseMSTeamsAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseNewRelicAction
        /// <summary>
        /// <para>
        /// <para>The ability to use New Relic actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseNewRelicAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseNotionAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Notion actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseNotionAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseOneDriveAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Microsoft OneDrive actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseOneDriveAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseOpenAPIAction
        /// <summary>
        /// <para>
        /// <para>The ability to use OpenAPI Specification actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseOpenAPIAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UsePagerDutyAction
        /// <summary>
        /// <para>
        /// <para>The ability to use PagerDuty Advance actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UsePagerDutyAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseSalesforceAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Salesforce actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseSalesforceAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseSandPGlobalEnergyAction
        /// <summary>
        /// <para>
        /// <para>The ability to use S&amp;P Global Energy actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseSandPGlobalEnergyAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseSandPGMIAction
        /// <summary>
        /// <para>
        /// <para>The ability to use S&amp;P Global Market Intelligence actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseSandPGMIAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseSAPBillOfMaterialAction
        /// <summary>
        /// <para>
        /// <para>The ability to use SAP Bill of Materials actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseSAPBillOfMaterialAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseSAPBusinessPartnerAction
        /// <summary>
        /// <para>
        /// <para>The ability to use SAP Business Partner actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseSAPBusinessPartnerAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseSAPMaterialStockAction
        /// <summary>
        /// <para>
        /// <para>The ability to use SAP Material Stock actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseSAPMaterialStockAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseSAPPhysicalInventoryAction
        /// <summary>
        /// <para>
        /// <para>The ability to use SAP Physical Inventory actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseSAPPhysicalInventoryAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseSAPProductMasterDataAction
        /// <summary>
        /// <para>
        /// <para>The ability to use SAP Product Master actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseSAPProductMasterDataAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseServiceNowAction
        /// <summary>
        /// <para>
        /// <para>The ability to use ServiceNow actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseServiceNowAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseSharePointAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Microsoft SharePoint Online actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseSharePointAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseSlackAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Slack actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseSlackAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseSmartsheetAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Smartsheet actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseSmartsheetAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseTextractAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Textract actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseTextractAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_UseZendeskAction
        /// <summary>
        /// <para>
        /// <para>The ability to use Zendesk actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_UseZendeskAction { get; set; }
        #endregion
        
        #region Parameter Capabilities_ViewAccountSPICECapacity
        /// <summary>
        /// <para>
        /// <para>The ability to view account SPICE capacity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ViewAccountSPICECapacity { get; set; }
        #endregion
        
        #region Parameter Capabilities_ZendeskAction
        /// <summary>
        /// <para>
        /// <para>The ability to perform actions using Zendesk connectors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.CapabilityState")]
        public Amazon.QuickSight.CapabilityState Capabilities_ZendeskAction { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Arn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.CreateCustomPermissionsResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.CreateCustomPermissionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Arn";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CustomPermissionsName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QSCustomPermission (CreateCustomPermissions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.CreateCustomPermissionsResponse, NewQSCustomPermissionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Capabilities_Action = this.Capabilities_Action;
            context.Capabilities_AddOrRunAnomalyDetectionForAnalyses = this.Capabilities_AddOrRunAnomalyDetectionForAnalyses;
            context.Capabilities_AmazonBedrockARSAction = this.Capabilities_AmazonBedrockARSAction;
            context.Capabilities_AmazonBedrockFSAction = this.Capabilities_AmazonBedrockFSAction;
            context.Capabilities_AmazonBedrockKRSAction = this.Capabilities_AmazonBedrockKRSAction;
            context.Capabilities_AmazonSThreeAction = this.Capabilities_AmazonSThreeAction;
            context.Capabilities_Analysis = this.Capabilities_Analysis;
            context.Capabilities_AsanaAction = this.Capabilities_AsanaAction;
            context.Capabilities_Automate = this.Capabilities_Automate;
            context.Capabilities_BambooHRAction = this.Capabilities_BambooHRAction;
            context.Capabilities_BoxAgentAction = this.Capabilities_BoxAgentAction;
            context.Capabilities_CanvaAgentAction = this.Capabilities_CanvaAgentAction;
            context.Capabilities_ChatAgent = this.Capabilities_ChatAgent;
            context.Capabilities_ComprehendAction = this.Capabilities_ComprehendAction;
            context.Capabilities_ComprehendMedicalAction = this.Capabilities_ComprehendMedicalAction;
            context.Capabilities_ConfluenceAction = this.Capabilities_ConfluenceAction;
            context.Capabilities_CreateAndUpdateAmazonBedrockARSAction = this.Capabilities_CreateAndUpdateAmazonBedrockARSAction;
            context.Capabilities_CreateAndUpdateAmazonBedrockFSAction = this.Capabilities_CreateAndUpdateAmazonBedrockFSAction;
            context.Capabilities_CreateAndUpdateAmazonBedrockKRSAction = this.Capabilities_CreateAndUpdateAmazonBedrockKRSAction;
            context.Capabilities_CreateAndUpdateAmazonSThreeAction = this.Capabilities_CreateAndUpdateAmazonSThreeAction;
            context.Capabilities_CreateAndUpdateAsanaAction = this.Capabilities_CreateAndUpdateAsanaAction;
            context.Capabilities_CreateAndUpdateBambooHRAction = this.Capabilities_CreateAndUpdateBambooHRAction;
            context.Capabilities_CreateAndUpdateBoxAgentAction = this.Capabilities_CreateAndUpdateBoxAgentAction;
            context.Capabilities_CreateAndUpdateCanvaAgentAction = this.Capabilities_CreateAndUpdateCanvaAgentAction;
            context.Capabilities_CreateAndUpdateComprehendAction = this.Capabilities_CreateAndUpdateComprehendAction;
            context.Capabilities_CreateAndUpdateComprehendMedicalAction = this.Capabilities_CreateAndUpdateComprehendMedicalAction;
            context.Capabilities_CreateAndUpdateConfluenceAction = this.Capabilities_CreateAndUpdateConfluenceAction;
            context.Capabilities_CreateAndUpdateDashboardEmailReport = this.Capabilities_CreateAndUpdateDashboardEmailReport;
            context.Capabilities_CreateAndUpdateDataset = this.Capabilities_CreateAndUpdateDataset;
            context.Capabilities_CreateAndUpdateDataSource = this.Capabilities_CreateAndUpdateDataSource;
            context.Capabilities_CreateAndUpdateFactSetAction = this.Capabilities_CreateAndUpdateFactSetAction;
            context.Capabilities_CreateAndUpdateGenericHTTPAction = this.Capabilities_CreateAndUpdateGenericHTTPAction;
            context.Capabilities_CreateAndUpdateGithubAction = this.Capabilities_CreateAndUpdateGithubAction;
            context.Capabilities_CreateAndUpdateGoogleCalendarAction = this.Capabilities_CreateAndUpdateGoogleCalendarAction;
            context.Capabilities_CreateAndUpdateHubspotAction = this.Capabilities_CreateAndUpdateHubspotAction;
            context.Capabilities_CreateAndUpdateHuggingFaceAction = this.Capabilities_CreateAndUpdateHuggingFaceAction;
            context.Capabilities_CreateAndUpdateIntercomAction = this.Capabilities_CreateAndUpdateIntercomAction;
            context.Capabilities_CreateAndUpdateJiraAction = this.Capabilities_CreateAndUpdateJiraAction;
            context.Capabilities_CreateAndUpdateLinearAction = this.Capabilities_CreateAndUpdateLinearAction;
            context.Capabilities_CreateAndUpdateMCPAction = this.Capabilities_CreateAndUpdateMCPAction;
            context.Capabilities_CreateAndUpdateMondayAction = this.Capabilities_CreateAndUpdateMondayAction;
            context.Capabilities_CreateAndUpdateMSExchangeAction = this.Capabilities_CreateAndUpdateMSExchangeAction;
            context.Capabilities_CreateAndUpdateMSTeamsAction = this.Capabilities_CreateAndUpdateMSTeamsAction;
            context.Capabilities_CreateAndUpdateNewRelicAction = this.Capabilities_CreateAndUpdateNewRelicAction;
            context.Capabilities_CreateAndUpdateNotionAction = this.Capabilities_CreateAndUpdateNotionAction;
            context.Capabilities_CreateAndUpdateOneDriveAction = this.Capabilities_CreateAndUpdateOneDriveAction;
            context.Capabilities_CreateAndUpdateOpenAPIAction = this.Capabilities_CreateAndUpdateOpenAPIAction;
            context.Capabilities_CreateAndUpdatePagerDutyAction = this.Capabilities_CreateAndUpdatePagerDutyAction;
            context.Capabilities_CreateAndUpdateSalesforceAction = this.Capabilities_CreateAndUpdateSalesforceAction;
            context.Capabilities_CreateAndUpdateSandPGlobalEnergyAction = this.Capabilities_CreateAndUpdateSandPGlobalEnergyAction;
            context.Capabilities_CreateAndUpdateSandPGMIAction = this.Capabilities_CreateAndUpdateSandPGMIAction;
            context.Capabilities_CreateAndUpdateSAPBillOfMaterialAction = this.Capabilities_CreateAndUpdateSAPBillOfMaterialAction;
            context.Capabilities_CreateAndUpdateSAPBusinessPartnerAction = this.Capabilities_CreateAndUpdateSAPBusinessPartnerAction;
            context.Capabilities_CreateAndUpdateSAPMaterialStockAction = this.Capabilities_CreateAndUpdateSAPMaterialStockAction;
            context.Capabilities_CreateAndUpdateSAPPhysicalInventoryAction = this.Capabilities_CreateAndUpdateSAPPhysicalInventoryAction;
            context.Capabilities_CreateAndUpdateSAPProductMasterDataAction = this.Capabilities_CreateAndUpdateSAPProductMasterDataAction;
            context.Capabilities_CreateAndUpdateServiceNowAction = this.Capabilities_CreateAndUpdateServiceNowAction;
            context.Capabilities_CreateAndUpdateSharePointAction = this.Capabilities_CreateAndUpdateSharePointAction;
            context.Capabilities_CreateAndUpdateSlackAction = this.Capabilities_CreateAndUpdateSlackAction;
            context.Capabilities_CreateAndUpdateSmartsheetAction = this.Capabilities_CreateAndUpdateSmartsheetAction;
            context.Capabilities_CreateAndUpdateTextractAction = this.Capabilities_CreateAndUpdateTextractAction;
            context.Capabilities_CreateAndUpdateTheme = this.Capabilities_CreateAndUpdateTheme;
            context.Capabilities_CreateAndUpdateThresholdAlert = this.Capabilities_CreateAndUpdateThresholdAlert;
            context.Capabilities_CreateAndUpdateZendeskAction = this.Capabilities_CreateAndUpdateZendeskAction;
            context.Capabilities_CreateChatAgent = this.Capabilities_CreateChatAgent;
            context.Capabilities_CreateSharedFolder = this.Capabilities_CreateSharedFolder;
            context.Capabilities_CreateSPICEDataset = this.Capabilities_CreateSPICEDataset;
            context.Capabilities_Dashboard = this.Capabilities_Dashboard;
            context.Capabilities_ExportToCsv = this.Capabilities_ExportToCsv;
            context.Capabilities_ExportToCsvInScheduledReport = this.Capabilities_ExportToCsvInScheduledReport;
            context.Capabilities_ExportToExcel = this.Capabilities_ExportToExcel;
            context.Capabilities_ExportToExcelInScheduledReport = this.Capabilities_ExportToExcelInScheduledReport;
            context.Capabilities_ExportToPdf = this.Capabilities_ExportToPdf;
            context.Capabilities_ExportToPdfInScheduledReport = this.Capabilities_ExportToPdfInScheduledReport;
            context.Capabilities_FactSetAction = this.Capabilities_FactSetAction;
            context.Capabilities_Flow = this.Capabilities_Flow;
            context.Capabilities_GenericHTTPAction = this.Capabilities_GenericHTTPAction;
            context.Capabilities_GithubAction = this.Capabilities_GithubAction;
            context.Capabilities_GoogleCalendarAction = this.Capabilities_GoogleCalendarAction;
            context.Capabilities_HubspotAction = this.Capabilities_HubspotAction;
            context.Capabilities_HuggingFaceAction = this.Capabilities_HuggingFaceAction;
            context.Capabilities_IncludeContentInScheduledReportsEmail = this.Capabilities_IncludeContentInScheduledReportsEmail;
            context.Capabilities_IntercomAction = this.Capabilities_IntercomAction;
            context.Capabilities_JiraAction = this.Capabilities_JiraAction;
            context.Capabilities_KnowledgeBase = this.Capabilities_KnowledgeBase;
            context.Capabilities_LinearAction = this.Capabilities_LinearAction;
            context.Capabilities_MCPAction = this.Capabilities_MCPAction;
            context.Capabilities_MondayAction = this.Capabilities_MondayAction;
            context.Capabilities_MSExchangeAction = this.Capabilities_MSExchangeAction;
            context.Capabilities_MSTeamsAction = this.Capabilities_MSTeamsAction;
            context.Capabilities_NewRelicAction = this.Capabilities_NewRelicAction;
            context.Capabilities_NotionAction = this.Capabilities_NotionAction;
            context.Capabilities_OneDriveAction = this.Capabilities_OneDriveAction;
            context.Capabilities_OpenAPIAction = this.Capabilities_OpenAPIAction;
            context.Capabilities_PagerDutyAction = this.Capabilities_PagerDutyAction;
            context.Capabilities_PerformFlowUiTask = this.Capabilities_PerformFlowUiTask;
            context.Capabilities_PrintReport = this.Capabilities_PrintReport;
            context.Capabilities_PublishWithoutApproval = this.Capabilities_PublishWithoutApproval;
            context.Capabilities_RenameSharedFolder = this.Capabilities_RenameSharedFolder;
            context.Capabilities_Research = this.Capabilities_Research;
            context.Capabilities_SalesforceAction = this.Capabilities_SalesforceAction;
            context.Capabilities_SandPGlobalEnergyAction = this.Capabilities_SandPGlobalEnergyAction;
            context.Capabilities_SandPGMIAction = this.Capabilities_SandPGMIAction;
            context.Capabilities_SAPBillOfMaterialAction = this.Capabilities_SAPBillOfMaterialAction;
            context.Capabilities_SAPBusinessPartnerAction = this.Capabilities_SAPBusinessPartnerAction;
            context.Capabilities_SAPMaterialStockAction = this.Capabilities_SAPMaterialStockAction;
            context.Capabilities_SAPPhysicalInventoryAction = this.Capabilities_SAPPhysicalInventoryAction;
            context.Capabilities_SAPProductMasterDataAction = this.Capabilities_SAPProductMasterDataAction;
            context.Capabilities_SelfUpgradeUserRole = this.Capabilities_SelfUpgradeUserRole;
            context.Capabilities_ServiceNowAction = this.Capabilities_ServiceNowAction;
            context.Capabilities_ShareAmazonBedrockARSAction = this.Capabilities_ShareAmazonBedrockARSAction;
            context.Capabilities_ShareAmazonBedrockFSAction = this.Capabilities_ShareAmazonBedrockFSAction;
            context.Capabilities_ShareAmazonBedrockKRSAction = this.Capabilities_ShareAmazonBedrockKRSAction;
            context.Capabilities_ShareAmazonSThreeAction = this.Capabilities_ShareAmazonSThreeAction;
            context.Capabilities_ShareAnalyses = this.Capabilities_ShareAnalyses;
            context.Capabilities_ShareAsanaAction = this.Capabilities_ShareAsanaAction;
            context.Capabilities_ShareBambooHRAction = this.Capabilities_ShareBambooHRAction;
            context.Capabilities_ShareBoxAgentAction = this.Capabilities_ShareBoxAgentAction;
            context.Capabilities_ShareCanvaAgentAction = this.Capabilities_ShareCanvaAgentAction;
            context.Capabilities_ShareComprehendAction = this.Capabilities_ShareComprehendAction;
            context.Capabilities_ShareComprehendMedicalAction = this.Capabilities_ShareComprehendMedicalAction;
            context.Capabilities_ShareConfluenceAction = this.Capabilities_ShareConfluenceAction;
            context.Capabilities_ShareDashboard = this.Capabilities_ShareDashboard;
            context.Capabilities_ShareDataset = this.Capabilities_ShareDataset;
            context.Capabilities_ShareDataSource = this.Capabilities_ShareDataSource;
            context.Capabilities_ShareFactSetAction = this.Capabilities_ShareFactSetAction;
            context.Capabilities_ShareGenericHTTPAction = this.Capabilities_ShareGenericHTTPAction;
            context.Capabilities_ShareGithubAction = this.Capabilities_ShareGithubAction;
            context.Capabilities_ShareGoogleCalendarAction = this.Capabilities_ShareGoogleCalendarAction;
            context.Capabilities_ShareHubspotAction = this.Capabilities_ShareHubspotAction;
            context.Capabilities_ShareHuggingFaceAction = this.Capabilities_ShareHuggingFaceAction;
            context.Capabilities_ShareIntercomAction = this.Capabilities_ShareIntercomAction;
            context.Capabilities_ShareJiraAction = this.Capabilities_ShareJiraAction;
            context.Capabilities_ShareLinearAction = this.Capabilities_ShareLinearAction;
            context.Capabilities_ShareMCPAction = this.Capabilities_ShareMCPAction;
            context.Capabilities_ShareMondayAction = this.Capabilities_ShareMondayAction;
            context.Capabilities_ShareMSExchangeAction = this.Capabilities_ShareMSExchangeAction;
            context.Capabilities_ShareMSTeamsAction = this.Capabilities_ShareMSTeamsAction;
            context.Capabilities_ShareNewRelicAction = this.Capabilities_ShareNewRelicAction;
            context.Capabilities_ShareNotionAction = this.Capabilities_ShareNotionAction;
            context.Capabilities_ShareOneDriveAction = this.Capabilities_ShareOneDriveAction;
            context.Capabilities_ShareOpenAPIAction = this.Capabilities_ShareOpenAPIAction;
            context.Capabilities_SharePagerDutyAction = this.Capabilities_SharePagerDutyAction;
            context.Capabilities_SharePointAction = this.Capabilities_SharePointAction;
            context.Capabilities_ShareSalesforceAction = this.Capabilities_ShareSalesforceAction;
            context.Capabilities_ShareSandPGlobalEnergyAction = this.Capabilities_ShareSandPGlobalEnergyAction;
            context.Capabilities_ShareSandPGMIAction = this.Capabilities_ShareSandPGMIAction;
            context.Capabilities_ShareSAPBillOfMaterialAction = this.Capabilities_ShareSAPBillOfMaterialAction;
            context.Capabilities_ShareSAPBusinessPartnerAction = this.Capabilities_ShareSAPBusinessPartnerAction;
            context.Capabilities_ShareSAPMaterialStockAction = this.Capabilities_ShareSAPMaterialStockAction;
            context.Capabilities_ShareSAPPhysicalInventoryAction = this.Capabilities_ShareSAPPhysicalInventoryAction;
            context.Capabilities_ShareSAPProductMasterDataAction = this.Capabilities_ShareSAPProductMasterDataAction;
            context.Capabilities_ShareServiceNowAction = this.Capabilities_ShareServiceNowAction;
            context.Capabilities_ShareSharePointAction = this.Capabilities_ShareSharePointAction;
            context.Capabilities_ShareSlackAction = this.Capabilities_ShareSlackAction;
            context.Capabilities_ShareSmartsheetAction = this.Capabilities_ShareSmartsheetAction;
            context.Capabilities_ShareTextractAction = this.Capabilities_ShareTextractAction;
            context.Capabilities_ShareZendeskAction = this.Capabilities_ShareZendeskAction;
            context.Capabilities_SlackAction = this.Capabilities_SlackAction;
            context.Capabilities_SmartsheetAction = this.Capabilities_SmartsheetAction;
            context.Capabilities_Space = this.Capabilities_Space;
            context.Capabilities_SubscribeDashboardEmailReport = this.Capabilities_SubscribeDashboardEmailReport;
            context.Capabilities_TextractAction = this.Capabilities_TextractAction;
            context.Capabilities_UseAgentWebSearch = this.Capabilities_UseAgentWebSearch;
            context.Capabilities_UseAmazonBedrockARSAction = this.Capabilities_UseAmazonBedrockARSAction;
            context.Capabilities_UseAmazonBedrockFSAction = this.Capabilities_UseAmazonBedrockFSAction;
            context.Capabilities_UseAmazonBedrockKRSAction = this.Capabilities_UseAmazonBedrockKRSAction;
            context.Capabilities_UseAmazonSThreeAction = this.Capabilities_UseAmazonSThreeAction;
            context.Capabilities_UseAsanaAction = this.Capabilities_UseAsanaAction;
            context.Capabilities_UseBambooHRAction = this.Capabilities_UseBambooHRAction;
            context.Capabilities_UseBedrockModel = this.Capabilities_UseBedrockModel;
            context.Capabilities_UseBoxAgentAction = this.Capabilities_UseBoxAgentAction;
            context.Capabilities_UseCanvaAgentAction = this.Capabilities_UseCanvaAgentAction;
            context.Capabilities_UseComprehendAction = this.Capabilities_UseComprehendAction;
            context.Capabilities_UseComprehendMedicalAction = this.Capabilities_UseComprehendMedicalAction;
            context.Capabilities_UseConfluenceAction = this.Capabilities_UseConfluenceAction;
            context.Capabilities_UseFactSetAction = this.Capabilities_UseFactSetAction;
            context.Capabilities_UseGenericHTTPAction = this.Capabilities_UseGenericHTTPAction;
            context.Capabilities_UseGithubAction = this.Capabilities_UseGithubAction;
            context.Capabilities_UseGoogleCalendarAction = this.Capabilities_UseGoogleCalendarAction;
            context.Capabilities_UseHubspotAction = this.Capabilities_UseHubspotAction;
            context.Capabilities_UseHuggingFaceAction = this.Capabilities_UseHuggingFaceAction;
            context.Capabilities_UseIntercomAction = this.Capabilities_UseIntercomAction;
            context.Capabilities_UseJiraAction = this.Capabilities_UseJiraAction;
            context.Capabilities_UseLinearAction = this.Capabilities_UseLinearAction;
            context.Capabilities_UseMCPAction = this.Capabilities_UseMCPAction;
            context.Capabilities_UseMondayAction = this.Capabilities_UseMondayAction;
            context.Capabilities_UseMSExchangeAction = this.Capabilities_UseMSExchangeAction;
            context.Capabilities_UseMSTeamsAction = this.Capabilities_UseMSTeamsAction;
            context.Capabilities_UseNewRelicAction = this.Capabilities_UseNewRelicAction;
            context.Capabilities_UseNotionAction = this.Capabilities_UseNotionAction;
            context.Capabilities_UseOneDriveAction = this.Capabilities_UseOneDriveAction;
            context.Capabilities_UseOpenAPIAction = this.Capabilities_UseOpenAPIAction;
            context.Capabilities_UsePagerDutyAction = this.Capabilities_UsePagerDutyAction;
            context.Capabilities_UseSalesforceAction = this.Capabilities_UseSalesforceAction;
            context.Capabilities_UseSandPGlobalEnergyAction = this.Capabilities_UseSandPGlobalEnergyAction;
            context.Capabilities_UseSandPGMIAction = this.Capabilities_UseSandPGMIAction;
            context.Capabilities_UseSAPBillOfMaterialAction = this.Capabilities_UseSAPBillOfMaterialAction;
            context.Capabilities_UseSAPBusinessPartnerAction = this.Capabilities_UseSAPBusinessPartnerAction;
            context.Capabilities_UseSAPMaterialStockAction = this.Capabilities_UseSAPMaterialStockAction;
            context.Capabilities_UseSAPPhysicalInventoryAction = this.Capabilities_UseSAPPhysicalInventoryAction;
            context.Capabilities_UseSAPProductMasterDataAction = this.Capabilities_UseSAPProductMasterDataAction;
            context.Capabilities_UseServiceNowAction = this.Capabilities_UseServiceNowAction;
            context.Capabilities_UseSharePointAction = this.Capabilities_UseSharePointAction;
            context.Capabilities_UseSlackAction = this.Capabilities_UseSlackAction;
            context.Capabilities_UseSmartsheetAction = this.Capabilities_UseSmartsheetAction;
            context.Capabilities_UseTextractAction = this.Capabilities_UseTextractAction;
            context.Capabilities_UseZendeskAction = this.Capabilities_UseZendeskAction;
            context.Capabilities_ViewAccountSPICECapacity = this.Capabilities_ViewAccountSPICECapacity;
            context.Capabilities_ZendeskAction = this.Capabilities_ZendeskAction;
            context.CustomPermissionsName = this.CustomPermissionsName;
            #if MODULAR
            if (this.CustomPermissionsName == null && ParameterWasBound(nameof(this.CustomPermissionsName)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomPermissionsName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.QuickSight.Model.Tag>(this.Tag);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.QuickSight.Model.CreateCustomPermissionsRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            
             // populate Capabilities
            var requestCapabilitiesIsNull = true;
            request.Capabilities = new Amazon.QuickSight.Model.Capabilities();
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_Action = null;
            if (cmdletContext.Capabilities_Action != null)
            {
                requestCapabilities_capabilities_Action = cmdletContext.Capabilities_Action;
            }
            if (requestCapabilities_capabilities_Action != null)
            {
                request.Capabilities.Action = requestCapabilities_capabilities_Action;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_AddOrRunAnomalyDetectionForAnalyses = null;
            if (cmdletContext.Capabilities_AddOrRunAnomalyDetectionForAnalyses != null)
            {
                requestCapabilities_capabilities_AddOrRunAnomalyDetectionForAnalyses = cmdletContext.Capabilities_AddOrRunAnomalyDetectionForAnalyses;
            }
            if (requestCapabilities_capabilities_AddOrRunAnomalyDetectionForAnalyses != null)
            {
                request.Capabilities.AddOrRunAnomalyDetectionForAnalyses = requestCapabilities_capabilities_AddOrRunAnomalyDetectionForAnalyses;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_AmazonBedrockARSAction = null;
            if (cmdletContext.Capabilities_AmazonBedrockARSAction != null)
            {
                requestCapabilities_capabilities_AmazonBedrockARSAction = cmdletContext.Capabilities_AmazonBedrockARSAction;
            }
            if (requestCapabilities_capabilities_AmazonBedrockARSAction != null)
            {
                request.Capabilities.AmazonBedrockARSAction = requestCapabilities_capabilities_AmazonBedrockARSAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_AmazonBedrockFSAction = null;
            if (cmdletContext.Capabilities_AmazonBedrockFSAction != null)
            {
                requestCapabilities_capabilities_AmazonBedrockFSAction = cmdletContext.Capabilities_AmazonBedrockFSAction;
            }
            if (requestCapabilities_capabilities_AmazonBedrockFSAction != null)
            {
                request.Capabilities.AmazonBedrockFSAction = requestCapabilities_capabilities_AmazonBedrockFSAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_AmazonBedrockKRSAction = null;
            if (cmdletContext.Capabilities_AmazonBedrockKRSAction != null)
            {
                requestCapabilities_capabilities_AmazonBedrockKRSAction = cmdletContext.Capabilities_AmazonBedrockKRSAction;
            }
            if (requestCapabilities_capabilities_AmazonBedrockKRSAction != null)
            {
                request.Capabilities.AmazonBedrockKRSAction = requestCapabilities_capabilities_AmazonBedrockKRSAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_AmazonSThreeAction = null;
            if (cmdletContext.Capabilities_AmazonSThreeAction != null)
            {
                requestCapabilities_capabilities_AmazonSThreeAction = cmdletContext.Capabilities_AmazonSThreeAction;
            }
            if (requestCapabilities_capabilities_AmazonSThreeAction != null)
            {
                request.Capabilities.AmazonSThreeAction = requestCapabilities_capabilities_AmazonSThreeAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_Analysis = null;
            if (cmdletContext.Capabilities_Analysis != null)
            {
                requestCapabilities_capabilities_Analysis = cmdletContext.Capabilities_Analysis;
            }
            if (requestCapabilities_capabilities_Analysis != null)
            {
                request.Capabilities.Analysis = requestCapabilities_capabilities_Analysis;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_AsanaAction = null;
            if (cmdletContext.Capabilities_AsanaAction != null)
            {
                requestCapabilities_capabilities_AsanaAction = cmdletContext.Capabilities_AsanaAction;
            }
            if (requestCapabilities_capabilities_AsanaAction != null)
            {
                request.Capabilities.AsanaAction = requestCapabilities_capabilities_AsanaAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_Automate = null;
            if (cmdletContext.Capabilities_Automate != null)
            {
                requestCapabilities_capabilities_Automate = cmdletContext.Capabilities_Automate;
            }
            if (requestCapabilities_capabilities_Automate != null)
            {
                request.Capabilities.Automate = requestCapabilities_capabilities_Automate;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_BambooHRAction = null;
            if (cmdletContext.Capabilities_BambooHRAction != null)
            {
                requestCapabilities_capabilities_BambooHRAction = cmdletContext.Capabilities_BambooHRAction;
            }
            if (requestCapabilities_capabilities_BambooHRAction != null)
            {
                request.Capabilities.BambooHRAction = requestCapabilities_capabilities_BambooHRAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_BoxAgentAction = null;
            if (cmdletContext.Capabilities_BoxAgentAction != null)
            {
                requestCapabilities_capabilities_BoxAgentAction = cmdletContext.Capabilities_BoxAgentAction;
            }
            if (requestCapabilities_capabilities_BoxAgentAction != null)
            {
                request.Capabilities.BoxAgentAction = requestCapabilities_capabilities_BoxAgentAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CanvaAgentAction = null;
            if (cmdletContext.Capabilities_CanvaAgentAction != null)
            {
                requestCapabilities_capabilities_CanvaAgentAction = cmdletContext.Capabilities_CanvaAgentAction;
            }
            if (requestCapabilities_capabilities_CanvaAgentAction != null)
            {
                request.Capabilities.CanvaAgentAction = requestCapabilities_capabilities_CanvaAgentAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ChatAgent = null;
            if (cmdletContext.Capabilities_ChatAgent != null)
            {
                requestCapabilities_capabilities_ChatAgent = cmdletContext.Capabilities_ChatAgent;
            }
            if (requestCapabilities_capabilities_ChatAgent != null)
            {
                request.Capabilities.ChatAgent = requestCapabilities_capabilities_ChatAgent;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ComprehendAction = null;
            if (cmdletContext.Capabilities_ComprehendAction != null)
            {
                requestCapabilities_capabilities_ComprehendAction = cmdletContext.Capabilities_ComprehendAction;
            }
            if (requestCapabilities_capabilities_ComprehendAction != null)
            {
                request.Capabilities.ComprehendAction = requestCapabilities_capabilities_ComprehendAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ComprehendMedicalAction = null;
            if (cmdletContext.Capabilities_ComprehendMedicalAction != null)
            {
                requestCapabilities_capabilities_ComprehendMedicalAction = cmdletContext.Capabilities_ComprehendMedicalAction;
            }
            if (requestCapabilities_capabilities_ComprehendMedicalAction != null)
            {
                request.Capabilities.ComprehendMedicalAction = requestCapabilities_capabilities_ComprehendMedicalAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ConfluenceAction = null;
            if (cmdletContext.Capabilities_ConfluenceAction != null)
            {
                requestCapabilities_capabilities_ConfluenceAction = cmdletContext.Capabilities_ConfluenceAction;
            }
            if (requestCapabilities_capabilities_ConfluenceAction != null)
            {
                request.Capabilities.ConfluenceAction = requestCapabilities_capabilities_ConfluenceAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateAmazonBedrockARSAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateAmazonBedrockARSAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateAmazonBedrockARSAction = cmdletContext.Capabilities_CreateAndUpdateAmazonBedrockARSAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateAmazonBedrockARSAction != null)
            {
                request.Capabilities.CreateAndUpdateAmazonBedrockARSAction = requestCapabilities_capabilities_CreateAndUpdateAmazonBedrockARSAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateAmazonBedrockFSAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateAmazonBedrockFSAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateAmazonBedrockFSAction = cmdletContext.Capabilities_CreateAndUpdateAmazonBedrockFSAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateAmazonBedrockFSAction != null)
            {
                request.Capabilities.CreateAndUpdateAmazonBedrockFSAction = requestCapabilities_capabilities_CreateAndUpdateAmazonBedrockFSAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateAmazonBedrockKRSAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateAmazonBedrockKRSAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateAmazonBedrockKRSAction = cmdletContext.Capabilities_CreateAndUpdateAmazonBedrockKRSAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateAmazonBedrockKRSAction != null)
            {
                request.Capabilities.CreateAndUpdateAmazonBedrockKRSAction = requestCapabilities_capabilities_CreateAndUpdateAmazonBedrockKRSAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateAmazonSThreeAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateAmazonSThreeAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateAmazonSThreeAction = cmdletContext.Capabilities_CreateAndUpdateAmazonSThreeAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateAmazonSThreeAction != null)
            {
                request.Capabilities.CreateAndUpdateAmazonSThreeAction = requestCapabilities_capabilities_CreateAndUpdateAmazonSThreeAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateAsanaAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateAsanaAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateAsanaAction = cmdletContext.Capabilities_CreateAndUpdateAsanaAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateAsanaAction != null)
            {
                request.Capabilities.CreateAndUpdateAsanaAction = requestCapabilities_capabilities_CreateAndUpdateAsanaAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateBambooHRAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateBambooHRAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateBambooHRAction = cmdletContext.Capabilities_CreateAndUpdateBambooHRAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateBambooHRAction != null)
            {
                request.Capabilities.CreateAndUpdateBambooHRAction = requestCapabilities_capabilities_CreateAndUpdateBambooHRAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateBoxAgentAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateBoxAgentAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateBoxAgentAction = cmdletContext.Capabilities_CreateAndUpdateBoxAgentAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateBoxAgentAction != null)
            {
                request.Capabilities.CreateAndUpdateBoxAgentAction = requestCapabilities_capabilities_CreateAndUpdateBoxAgentAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateCanvaAgentAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateCanvaAgentAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateCanvaAgentAction = cmdletContext.Capabilities_CreateAndUpdateCanvaAgentAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateCanvaAgentAction != null)
            {
                request.Capabilities.CreateAndUpdateCanvaAgentAction = requestCapabilities_capabilities_CreateAndUpdateCanvaAgentAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateComprehendAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateComprehendAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateComprehendAction = cmdletContext.Capabilities_CreateAndUpdateComprehendAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateComprehendAction != null)
            {
                request.Capabilities.CreateAndUpdateComprehendAction = requestCapabilities_capabilities_CreateAndUpdateComprehendAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateComprehendMedicalAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateComprehendMedicalAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateComprehendMedicalAction = cmdletContext.Capabilities_CreateAndUpdateComprehendMedicalAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateComprehendMedicalAction != null)
            {
                request.Capabilities.CreateAndUpdateComprehendMedicalAction = requestCapabilities_capabilities_CreateAndUpdateComprehendMedicalAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateConfluenceAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateConfluenceAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateConfluenceAction = cmdletContext.Capabilities_CreateAndUpdateConfluenceAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateConfluenceAction != null)
            {
                request.Capabilities.CreateAndUpdateConfluenceAction = requestCapabilities_capabilities_CreateAndUpdateConfluenceAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateDashboardEmailReport = null;
            if (cmdletContext.Capabilities_CreateAndUpdateDashboardEmailReport != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateDashboardEmailReport = cmdletContext.Capabilities_CreateAndUpdateDashboardEmailReport;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateDashboardEmailReport != null)
            {
                request.Capabilities.CreateAndUpdateDashboardEmailReports = requestCapabilities_capabilities_CreateAndUpdateDashboardEmailReport;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateDataset = null;
            if (cmdletContext.Capabilities_CreateAndUpdateDataset != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateDataset = cmdletContext.Capabilities_CreateAndUpdateDataset;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateDataset != null)
            {
                request.Capabilities.CreateAndUpdateDatasets = requestCapabilities_capabilities_CreateAndUpdateDataset;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateDataSource = null;
            if (cmdletContext.Capabilities_CreateAndUpdateDataSource != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateDataSource = cmdletContext.Capabilities_CreateAndUpdateDataSource;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateDataSource != null)
            {
                request.Capabilities.CreateAndUpdateDataSources = requestCapabilities_capabilities_CreateAndUpdateDataSource;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateFactSetAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateFactSetAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateFactSetAction = cmdletContext.Capabilities_CreateAndUpdateFactSetAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateFactSetAction != null)
            {
                request.Capabilities.CreateAndUpdateFactSetAction = requestCapabilities_capabilities_CreateAndUpdateFactSetAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateGenericHTTPAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateGenericHTTPAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateGenericHTTPAction = cmdletContext.Capabilities_CreateAndUpdateGenericHTTPAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateGenericHTTPAction != null)
            {
                request.Capabilities.CreateAndUpdateGenericHTTPAction = requestCapabilities_capabilities_CreateAndUpdateGenericHTTPAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateGithubAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateGithubAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateGithubAction = cmdletContext.Capabilities_CreateAndUpdateGithubAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateGithubAction != null)
            {
                request.Capabilities.CreateAndUpdateGithubAction = requestCapabilities_capabilities_CreateAndUpdateGithubAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateGoogleCalendarAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateGoogleCalendarAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateGoogleCalendarAction = cmdletContext.Capabilities_CreateAndUpdateGoogleCalendarAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateGoogleCalendarAction != null)
            {
                request.Capabilities.CreateAndUpdateGoogleCalendarAction = requestCapabilities_capabilities_CreateAndUpdateGoogleCalendarAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateHubspotAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateHubspotAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateHubspotAction = cmdletContext.Capabilities_CreateAndUpdateHubspotAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateHubspotAction != null)
            {
                request.Capabilities.CreateAndUpdateHubspotAction = requestCapabilities_capabilities_CreateAndUpdateHubspotAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateHuggingFaceAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateHuggingFaceAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateHuggingFaceAction = cmdletContext.Capabilities_CreateAndUpdateHuggingFaceAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateHuggingFaceAction != null)
            {
                request.Capabilities.CreateAndUpdateHuggingFaceAction = requestCapabilities_capabilities_CreateAndUpdateHuggingFaceAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateIntercomAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateIntercomAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateIntercomAction = cmdletContext.Capabilities_CreateAndUpdateIntercomAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateIntercomAction != null)
            {
                request.Capabilities.CreateAndUpdateIntercomAction = requestCapabilities_capabilities_CreateAndUpdateIntercomAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateJiraAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateJiraAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateJiraAction = cmdletContext.Capabilities_CreateAndUpdateJiraAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateJiraAction != null)
            {
                request.Capabilities.CreateAndUpdateJiraAction = requestCapabilities_capabilities_CreateAndUpdateJiraAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateLinearAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateLinearAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateLinearAction = cmdletContext.Capabilities_CreateAndUpdateLinearAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateLinearAction != null)
            {
                request.Capabilities.CreateAndUpdateLinearAction = requestCapabilities_capabilities_CreateAndUpdateLinearAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateMCPAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateMCPAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateMCPAction = cmdletContext.Capabilities_CreateAndUpdateMCPAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateMCPAction != null)
            {
                request.Capabilities.CreateAndUpdateMCPAction = requestCapabilities_capabilities_CreateAndUpdateMCPAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateMondayAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateMondayAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateMondayAction = cmdletContext.Capabilities_CreateAndUpdateMondayAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateMondayAction != null)
            {
                request.Capabilities.CreateAndUpdateMondayAction = requestCapabilities_capabilities_CreateAndUpdateMondayAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateMSExchangeAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateMSExchangeAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateMSExchangeAction = cmdletContext.Capabilities_CreateAndUpdateMSExchangeAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateMSExchangeAction != null)
            {
                request.Capabilities.CreateAndUpdateMSExchangeAction = requestCapabilities_capabilities_CreateAndUpdateMSExchangeAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateMSTeamsAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateMSTeamsAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateMSTeamsAction = cmdletContext.Capabilities_CreateAndUpdateMSTeamsAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateMSTeamsAction != null)
            {
                request.Capabilities.CreateAndUpdateMSTeamsAction = requestCapabilities_capabilities_CreateAndUpdateMSTeamsAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateNewRelicAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateNewRelicAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateNewRelicAction = cmdletContext.Capabilities_CreateAndUpdateNewRelicAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateNewRelicAction != null)
            {
                request.Capabilities.CreateAndUpdateNewRelicAction = requestCapabilities_capabilities_CreateAndUpdateNewRelicAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateNotionAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateNotionAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateNotionAction = cmdletContext.Capabilities_CreateAndUpdateNotionAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateNotionAction != null)
            {
                request.Capabilities.CreateAndUpdateNotionAction = requestCapabilities_capabilities_CreateAndUpdateNotionAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateOneDriveAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateOneDriveAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateOneDriveAction = cmdletContext.Capabilities_CreateAndUpdateOneDriveAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateOneDriveAction != null)
            {
                request.Capabilities.CreateAndUpdateOneDriveAction = requestCapabilities_capabilities_CreateAndUpdateOneDriveAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateOpenAPIAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateOpenAPIAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateOpenAPIAction = cmdletContext.Capabilities_CreateAndUpdateOpenAPIAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateOpenAPIAction != null)
            {
                request.Capabilities.CreateAndUpdateOpenAPIAction = requestCapabilities_capabilities_CreateAndUpdateOpenAPIAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdatePagerDutyAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdatePagerDutyAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdatePagerDutyAction = cmdletContext.Capabilities_CreateAndUpdatePagerDutyAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdatePagerDutyAction != null)
            {
                request.Capabilities.CreateAndUpdatePagerDutyAction = requestCapabilities_capabilities_CreateAndUpdatePagerDutyAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateSalesforceAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateSalesforceAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateSalesforceAction = cmdletContext.Capabilities_CreateAndUpdateSalesforceAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateSalesforceAction != null)
            {
                request.Capabilities.CreateAndUpdateSalesforceAction = requestCapabilities_capabilities_CreateAndUpdateSalesforceAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateSandPGlobalEnergyAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateSandPGlobalEnergyAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateSandPGlobalEnergyAction = cmdletContext.Capabilities_CreateAndUpdateSandPGlobalEnergyAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateSandPGlobalEnergyAction != null)
            {
                request.Capabilities.CreateAndUpdateSandPGlobalEnergyAction = requestCapabilities_capabilities_CreateAndUpdateSandPGlobalEnergyAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateSandPGMIAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateSandPGMIAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateSandPGMIAction = cmdletContext.Capabilities_CreateAndUpdateSandPGMIAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateSandPGMIAction != null)
            {
                request.Capabilities.CreateAndUpdateSandPGMIAction = requestCapabilities_capabilities_CreateAndUpdateSandPGMIAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateSAPBillOfMaterialAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateSAPBillOfMaterialAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateSAPBillOfMaterialAction = cmdletContext.Capabilities_CreateAndUpdateSAPBillOfMaterialAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateSAPBillOfMaterialAction != null)
            {
                request.Capabilities.CreateAndUpdateSAPBillOfMaterialAction = requestCapabilities_capabilities_CreateAndUpdateSAPBillOfMaterialAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateSAPBusinessPartnerAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateSAPBusinessPartnerAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateSAPBusinessPartnerAction = cmdletContext.Capabilities_CreateAndUpdateSAPBusinessPartnerAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateSAPBusinessPartnerAction != null)
            {
                request.Capabilities.CreateAndUpdateSAPBusinessPartnerAction = requestCapabilities_capabilities_CreateAndUpdateSAPBusinessPartnerAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateSAPMaterialStockAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateSAPMaterialStockAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateSAPMaterialStockAction = cmdletContext.Capabilities_CreateAndUpdateSAPMaterialStockAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateSAPMaterialStockAction != null)
            {
                request.Capabilities.CreateAndUpdateSAPMaterialStockAction = requestCapabilities_capabilities_CreateAndUpdateSAPMaterialStockAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateSAPPhysicalInventoryAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateSAPPhysicalInventoryAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateSAPPhysicalInventoryAction = cmdletContext.Capabilities_CreateAndUpdateSAPPhysicalInventoryAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateSAPPhysicalInventoryAction != null)
            {
                request.Capabilities.CreateAndUpdateSAPPhysicalInventoryAction = requestCapabilities_capabilities_CreateAndUpdateSAPPhysicalInventoryAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateSAPProductMasterDataAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateSAPProductMasterDataAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateSAPProductMasterDataAction = cmdletContext.Capabilities_CreateAndUpdateSAPProductMasterDataAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateSAPProductMasterDataAction != null)
            {
                request.Capabilities.CreateAndUpdateSAPProductMasterDataAction = requestCapabilities_capabilities_CreateAndUpdateSAPProductMasterDataAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateServiceNowAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateServiceNowAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateServiceNowAction = cmdletContext.Capabilities_CreateAndUpdateServiceNowAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateServiceNowAction != null)
            {
                request.Capabilities.CreateAndUpdateServiceNowAction = requestCapabilities_capabilities_CreateAndUpdateServiceNowAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateSharePointAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateSharePointAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateSharePointAction = cmdletContext.Capabilities_CreateAndUpdateSharePointAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateSharePointAction != null)
            {
                request.Capabilities.CreateAndUpdateSharePointAction = requestCapabilities_capabilities_CreateAndUpdateSharePointAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateSlackAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateSlackAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateSlackAction = cmdletContext.Capabilities_CreateAndUpdateSlackAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateSlackAction != null)
            {
                request.Capabilities.CreateAndUpdateSlackAction = requestCapabilities_capabilities_CreateAndUpdateSlackAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateSmartsheetAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateSmartsheetAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateSmartsheetAction = cmdletContext.Capabilities_CreateAndUpdateSmartsheetAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateSmartsheetAction != null)
            {
                request.Capabilities.CreateAndUpdateSmartsheetAction = requestCapabilities_capabilities_CreateAndUpdateSmartsheetAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateTextractAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateTextractAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateTextractAction = cmdletContext.Capabilities_CreateAndUpdateTextractAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateTextractAction != null)
            {
                request.Capabilities.CreateAndUpdateTextractAction = requestCapabilities_capabilities_CreateAndUpdateTextractAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateTheme = null;
            if (cmdletContext.Capabilities_CreateAndUpdateTheme != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateTheme = cmdletContext.Capabilities_CreateAndUpdateTheme;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateTheme != null)
            {
                request.Capabilities.CreateAndUpdateThemes = requestCapabilities_capabilities_CreateAndUpdateTheme;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateThresholdAlert = null;
            if (cmdletContext.Capabilities_CreateAndUpdateThresholdAlert != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateThresholdAlert = cmdletContext.Capabilities_CreateAndUpdateThresholdAlert;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateThresholdAlert != null)
            {
                request.Capabilities.CreateAndUpdateThresholdAlerts = requestCapabilities_capabilities_CreateAndUpdateThresholdAlert;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateAndUpdateZendeskAction = null;
            if (cmdletContext.Capabilities_CreateAndUpdateZendeskAction != null)
            {
                requestCapabilities_capabilities_CreateAndUpdateZendeskAction = cmdletContext.Capabilities_CreateAndUpdateZendeskAction;
            }
            if (requestCapabilities_capabilities_CreateAndUpdateZendeskAction != null)
            {
                request.Capabilities.CreateAndUpdateZendeskAction = requestCapabilities_capabilities_CreateAndUpdateZendeskAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateChatAgent = null;
            if (cmdletContext.Capabilities_CreateChatAgent != null)
            {
                requestCapabilities_capabilities_CreateChatAgent = cmdletContext.Capabilities_CreateChatAgent;
            }
            if (requestCapabilities_capabilities_CreateChatAgent != null)
            {
                request.Capabilities.CreateChatAgents = requestCapabilities_capabilities_CreateChatAgent;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateSharedFolder = null;
            if (cmdletContext.Capabilities_CreateSharedFolder != null)
            {
                requestCapabilities_capabilities_CreateSharedFolder = cmdletContext.Capabilities_CreateSharedFolder;
            }
            if (requestCapabilities_capabilities_CreateSharedFolder != null)
            {
                request.Capabilities.CreateSharedFolders = requestCapabilities_capabilities_CreateSharedFolder;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_CreateSPICEDataset = null;
            if (cmdletContext.Capabilities_CreateSPICEDataset != null)
            {
                requestCapabilities_capabilities_CreateSPICEDataset = cmdletContext.Capabilities_CreateSPICEDataset;
            }
            if (requestCapabilities_capabilities_CreateSPICEDataset != null)
            {
                request.Capabilities.CreateSPICEDataset = requestCapabilities_capabilities_CreateSPICEDataset;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_Dashboard = null;
            if (cmdletContext.Capabilities_Dashboard != null)
            {
                requestCapabilities_capabilities_Dashboard = cmdletContext.Capabilities_Dashboard;
            }
            if (requestCapabilities_capabilities_Dashboard != null)
            {
                request.Capabilities.Dashboard = requestCapabilities_capabilities_Dashboard;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ExportToCsv = null;
            if (cmdletContext.Capabilities_ExportToCsv != null)
            {
                requestCapabilities_capabilities_ExportToCsv = cmdletContext.Capabilities_ExportToCsv;
            }
            if (requestCapabilities_capabilities_ExportToCsv != null)
            {
                request.Capabilities.ExportToCsv = requestCapabilities_capabilities_ExportToCsv;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ExportToCsvInScheduledReport = null;
            if (cmdletContext.Capabilities_ExportToCsvInScheduledReport != null)
            {
                requestCapabilities_capabilities_ExportToCsvInScheduledReport = cmdletContext.Capabilities_ExportToCsvInScheduledReport;
            }
            if (requestCapabilities_capabilities_ExportToCsvInScheduledReport != null)
            {
                request.Capabilities.ExportToCsvInScheduledReports = requestCapabilities_capabilities_ExportToCsvInScheduledReport;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ExportToExcel = null;
            if (cmdletContext.Capabilities_ExportToExcel != null)
            {
                requestCapabilities_capabilities_ExportToExcel = cmdletContext.Capabilities_ExportToExcel;
            }
            if (requestCapabilities_capabilities_ExportToExcel != null)
            {
                request.Capabilities.ExportToExcel = requestCapabilities_capabilities_ExportToExcel;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ExportToExcelInScheduledReport = null;
            if (cmdletContext.Capabilities_ExportToExcelInScheduledReport != null)
            {
                requestCapabilities_capabilities_ExportToExcelInScheduledReport = cmdletContext.Capabilities_ExportToExcelInScheduledReport;
            }
            if (requestCapabilities_capabilities_ExportToExcelInScheduledReport != null)
            {
                request.Capabilities.ExportToExcelInScheduledReports = requestCapabilities_capabilities_ExportToExcelInScheduledReport;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ExportToPdf = null;
            if (cmdletContext.Capabilities_ExportToPdf != null)
            {
                requestCapabilities_capabilities_ExportToPdf = cmdletContext.Capabilities_ExportToPdf;
            }
            if (requestCapabilities_capabilities_ExportToPdf != null)
            {
                request.Capabilities.ExportToPdf = requestCapabilities_capabilities_ExportToPdf;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ExportToPdfInScheduledReport = null;
            if (cmdletContext.Capabilities_ExportToPdfInScheduledReport != null)
            {
                requestCapabilities_capabilities_ExportToPdfInScheduledReport = cmdletContext.Capabilities_ExportToPdfInScheduledReport;
            }
            if (requestCapabilities_capabilities_ExportToPdfInScheduledReport != null)
            {
                request.Capabilities.ExportToPdfInScheduledReports = requestCapabilities_capabilities_ExportToPdfInScheduledReport;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_FactSetAction = null;
            if (cmdletContext.Capabilities_FactSetAction != null)
            {
                requestCapabilities_capabilities_FactSetAction = cmdletContext.Capabilities_FactSetAction;
            }
            if (requestCapabilities_capabilities_FactSetAction != null)
            {
                request.Capabilities.FactSetAction = requestCapabilities_capabilities_FactSetAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_Flow = null;
            if (cmdletContext.Capabilities_Flow != null)
            {
                requestCapabilities_capabilities_Flow = cmdletContext.Capabilities_Flow;
            }
            if (requestCapabilities_capabilities_Flow != null)
            {
                request.Capabilities.Flow = requestCapabilities_capabilities_Flow;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_GenericHTTPAction = null;
            if (cmdletContext.Capabilities_GenericHTTPAction != null)
            {
                requestCapabilities_capabilities_GenericHTTPAction = cmdletContext.Capabilities_GenericHTTPAction;
            }
            if (requestCapabilities_capabilities_GenericHTTPAction != null)
            {
                request.Capabilities.GenericHTTPAction = requestCapabilities_capabilities_GenericHTTPAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_GithubAction = null;
            if (cmdletContext.Capabilities_GithubAction != null)
            {
                requestCapabilities_capabilities_GithubAction = cmdletContext.Capabilities_GithubAction;
            }
            if (requestCapabilities_capabilities_GithubAction != null)
            {
                request.Capabilities.GithubAction = requestCapabilities_capabilities_GithubAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_GoogleCalendarAction = null;
            if (cmdletContext.Capabilities_GoogleCalendarAction != null)
            {
                requestCapabilities_capabilities_GoogleCalendarAction = cmdletContext.Capabilities_GoogleCalendarAction;
            }
            if (requestCapabilities_capabilities_GoogleCalendarAction != null)
            {
                request.Capabilities.GoogleCalendarAction = requestCapabilities_capabilities_GoogleCalendarAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_HubspotAction = null;
            if (cmdletContext.Capabilities_HubspotAction != null)
            {
                requestCapabilities_capabilities_HubspotAction = cmdletContext.Capabilities_HubspotAction;
            }
            if (requestCapabilities_capabilities_HubspotAction != null)
            {
                request.Capabilities.HubspotAction = requestCapabilities_capabilities_HubspotAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_HuggingFaceAction = null;
            if (cmdletContext.Capabilities_HuggingFaceAction != null)
            {
                requestCapabilities_capabilities_HuggingFaceAction = cmdletContext.Capabilities_HuggingFaceAction;
            }
            if (requestCapabilities_capabilities_HuggingFaceAction != null)
            {
                request.Capabilities.HuggingFaceAction = requestCapabilities_capabilities_HuggingFaceAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_IncludeContentInScheduledReportsEmail = null;
            if (cmdletContext.Capabilities_IncludeContentInScheduledReportsEmail != null)
            {
                requestCapabilities_capabilities_IncludeContentInScheduledReportsEmail = cmdletContext.Capabilities_IncludeContentInScheduledReportsEmail;
            }
            if (requestCapabilities_capabilities_IncludeContentInScheduledReportsEmail != null)
            {
                request.Capabilities.IncludeContentInScheduledReportsEmail = requestCapabilities_capabilities_IncludeContentInScheduledReportsEmail;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_IntercomAction = null;
            if (cmdletContext.Capabilities_IntercomAction != null)
            {
                requestCapabilities_capabilities_IntercomAction = cmdletContext.Capabilities_IntercomAction;
            }
            if (requestCapabilities_capabilities_IntercomAction != null)
            {
                request.Capabilities.IntercomAction = requestCapabilities_capabilities_IntercomAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_JiraAction = null;
            if (cmdletContext.Capabilities_JiraAction != null)
            {
                requestCapabilities_capabilities_JiraAction = cmdletContext.Capabilities_JiraAction;
            }
            if (requestCapabilities_capabilities_JiraAction != null)
            {
                request.Capabilities.JiraAction = requestCapabilities_capabilities_JiraAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_KnowledgeBase = null;
            if (cmdletContext.Capabilities_KnowledgeBase != null)
            {
                requestCapabilities_capabilities_KnowledgeBase = cmdletContext.Capabilities_KnowledgeBase;
            }
            if (requestCapabilities_capabilities_KnowledgeBase != null)
            {
                request.Capabilities.KnowledgeBase = requestCapabilities_capabilities_KnowledgeBase;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_LinearAction = null;
            if (cmdletContext.Capabilities_LinearAction != null)
            {
                requestCapabilities_capabilities_LinearAction = cmdletContext.Capabilities_LinearAction;
            }
            if (requestCapabilities_capabilities_LinearAction != null)
            {
                request.Capabilities.LinearAction = requestCapabilities_capabilities_LinearAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_MCPAction = null;
            if (cmdletContext.Capabilities_MCPAction != null)
            {
                requestCapabilities_capabilities_MCPAction = cmdletContext.Capabilities_MCPAction;
            }
            if (requestCapabilities_capabilities_MCPAction != null)
            {
                request.Capabilities.MCPAction = requestCapabilities_capabilities_MCPAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_MondayAction = null;
            if (cmdletContext.Capabilities_MondayAction != null)
            {
                requestCapabilities_capabilities_MondayAction = cmdletContext.Capabilities_MondayAction;
            }
            if (requestCapabilities_capabilities_MondayAction != null)
            {
                request.Capabilities.MondayAction = requestCapabilities_capabilities_MondayAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_MSExchangeAction = null;
            if (cmdletContext.Capabilities_MSExchangeAction != null)
            {
                requestCapabilities_capabilities_MSExchangeAction = cmdletContext.Capabilities_MSExchangeAction;
            }
            if (requestCapabilities_capabilities_MSExchangeAction != null)
            {
                request.Capabilities.MSExchangeAction = requestCapabilities_capabilities_MSExchangeAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_MSTeamsAction = null;
            if (cmdletContext.Capabilities_MSTeamsAction != null)
            {
                requestCapabilities_capabilities_MSTeamsAction = cmdletContext.Capabilities_MSTeamsAction;
            }
            if (requestCapabilities_capabilities_MSTeamsAction != null)
            {
                request.Capabilities.MSTeamsAction = requestCapabilities_capabilities_MSTeamsAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_NewRelicAction = null;
            if (cmdletContext.Capabilities_NewRelicAction != null)
            {
                requestCapabilities_capabilities_NewRelicAction = cmdletContext.Capabilities_NewRelicAction;
            }
            if (requestCapabilities_capabilities_NewRelicAction != null)
            {
                request.Capabilities.NewRelicAction = requestCapabilities_capabilities_NewRelicAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_NotionAction = null;
            if (cmdletContext.Capabilities_NotionAction != null)
            {
                requestCapabilities_capabilities_NotionAction = cmdletContext.Capabilities_NotionAction;
            }
            if (requestCapabilities_capabilities_NotionAction != null)
            {
                request.Capabilities.NotionAction = requestCapabilities_capabilities_NotionAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_OneDriveAction = null;
            if (cmdletContext.Capabilities_OneDriveAction != null)
            {
                requestCapabilities_capabilities_OneDriveAction = cmdletContext.Capabilities_OneDriveAction;
            }
            if (requestCapabilities_capabilities_OneDriveAction != null)
            {
                request.Capabilities.OneDriveAction = requestCapabilities_capabilities_OneDriveAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_OpenAPIAction = null;
            if (cmdletContext.Capabilities_OpenAPIAction != null)
            {
                requestCapabilities_capabilities_OpenAPIAction = cmdletContext.Capabilities_OpenAPIAction;
            }
            if (requestCapabilities_capabilities_OpenAPIAction != null)
            {
                request.Capabilities.OpenAPIAction = requestCapabilities_capabilities_OpenAPIAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_PagerDutyAction = null;
            if (cmdletContext.Capabilities_PagerDutyAction != null)
            {
                requestCapabilities_capabilities_PagerDutyAction = cmdletContext.Capabilities_PagerDutyAction;
            }
            if (requestCapabilities_capabilities_PagerDutyAction != null)
            {
                request.Capabilities.PagerDutyAction = requestCapabilities_capabilities_PagerDutyAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_PerformFlowUiTask = null;
            if (cmdletContext.Capabilities_PerformFlowUiTask != null)
            {
                requestCapabilities_capabilities_PerformFlowUiTask = cmdletContext.Capabilities_PerformFlowUiTask;
            }
            if (requestCapabilities_capabilities_PerformFlowUiTask != null)
            {
                request.Capabilities.PerformFlowUiTask = requestCapabilities_capabilities_PerformFlowUiTask;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_PrintReport = null;
            if (cmdletContext.Capabilities_PrintReport != null)
            {
                requestCapabilities_capabilities_PrintReport = cmdletContext.Capabilities_PrintReport;
            }
            if (requestCapabilities_capabilities_PrintReport != null)
            {
                request.Capabilities.PrintReports = requestCapabilities_capabilities_PrintReport;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_PublishWithoutApproval = null;
            if (cmdletContext.Capabilities_PublishWithoutApproval != null)
            {
                requestCapabilities_capabilities_PublishWithoutApproval = cmdletContext.Capabilities_PublishWithoutApproval;
            }
            if (requestCapabilities_capabilities_PublishWithoutApproval != null)
            {
                request.Capabilities.PublishWithoutApproval = requestCapabilities_capabilities_PublishWithoutApproval;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_RenameSharedFolder = null;
            if (cmdletContext.Capabilities_RenameSharedFolder != null)
            {
                requestCapabilities_capabilities_RenameSharedFolder = cmdletContext.Capabilities_RenameSharedFolder;
            }
            if (requestCapabilities_capabilities_RenameSharedFolder != null)
            {
                request.Capabilities.RenameSharedFolders = requestCapabilities_capabilities_RenameSharedFolder;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_Research = null;
            if (cmdletContext.Capabilities_Research != null)
            {
                requestCapabilities_capabilities_Research = cmdletContext.Capabilities_Research;
            }
            if (requestCapabilities_capabilities_Research != null)
            {
                request.Capabilities.Research = requestCapabilities_capabilities_Research;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_SalesforceAction = null;
            if (cmdletContext.Capabilities_SalesforceAction != null)
            {
                requestCapabilities_capabilities_SalesforceAction = cmdletContext.Capabilities_SalesforceAction;
            }
            if (requestCapabilities_capabilities_SalesforceAction != null)
            {
                request.Capabilities.SalesforceAction = requestCapabilities_capabilities_SalesforceAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_SandPGlobalEnergyAction = null;
            if (cmdletContext.Capabilities_SandPGlobalEnergyAction != null)
            {
                requestCapabilities_capabilities_SandPGlobalEnergyAction = cmdletContext.Capabilities_SandPGlobalEnergyAction;
            }
            if (requestCapabilities_capabilities_SandPGlobalEnergyAction != null)
            {
                request.Capabilities.SandPGlobalEnergyAction = requestCapabilities_capabilities_SandPGlobalEnergyAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_SandPGMIAction = null;
            if (cmdletContext.Capabilities_SandPGMIAction != null)
            {
                requestCapabilities_capabilities_SandPGMIAction = cmdletContext.Capabilities_SandPGMIAction;
            }
            if (requestCapabilities_capabilities_SandPGMIAction != null)
            {
                request.Capabilities.SandPGMIAction = requestCapabilities_capabilities_SandPGMIAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_SAPBillOfMaterialAction = null;
            if (cmdletContext.Capabilities_SAPBillOfMaterialAction != null)
            {
                requestCapabilities_capabilities_SAPBillOfMaterialAction = cmdletContext.Capabilities_SAPBillOfMaterialAction;
            }
            if (requestCapabilities_capabilities_SAPBillOfMaterialAction != null)
            {
                request.Capabilities.SAPBillOfMaterialAction = requestCapabilities_capabilities_SAPBillOfMaterialAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_SAPBusinessPartnerAction = null;
            if (cmdletContext.Capabilities_SAPBusinessPartnerAction != null)
            {
                requestCapabilities_capabilities_SAPBusinessPartnerAction = cmdletContext.Capabilities_SAPBusinessPartnerAction;
            }
            if (requestCapabilities_capabilities_SAPBusinessPartnerAction != null)
            {
                request.Capabilities.SAPBusinessPartnerAction = requestCapabilities_capabilities_SAPBusinessPartnerAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_SAPMaterialStockAction = null;
            if (cmdletContext.Capabilities_SAPMaterialStockAction != null)
            {
                requestCapabilities_capabilities_SAPMaterialStockAction = cmdletContext.Capabilities_SAPMaterialStockAction;
            }
            if (requestCapabilities_capabilities_SAPMaterialStockAction != null)
            {
                request.Capabilities.SAPMaterialStockAction = requestCapabilities_capabilities_SAPMaterialStockAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_SAPPhysicalInventoryAction = null;
            if (cmdletContext.Capabilities_SAPPhysicalInventoryAction != null)
            {
                requestCapabilities_capabilities_SAPPhysicalInventoryAction = cmdletContext.Capabilities_SAPPhysicalInventoryAction;
            }
            if (requestCapabilities_capabilities_SAPPhysicalInventoryAction != null)
            {
                request.Capabilities.SAPPhysicalInventoryAction = requestCapabilities_capabilities_SAPPhysicalInventoryAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_SAPProductMasterDataAction = null;
            if (cmdletContext.Capabilities_SAPProductMasterDataAction != null)
            {
                requestCapabilities_capabilities_SAPProductMasterDataAction = cmdletContext.Capabilities_SAPProductMasterDataAction;
            }
            if (requestCapabilities_capabilities_SAPProductMasterDataAction != null)
            {
                request.Capabilities.SAPProductMasterDataAction = requestCapabilities_capabilities_SAPProductMasterDataAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_SelfUpgradeUserRole = null;
            if (cmdletContext.Capabilities_SelfUpgradeUserRole != null)
            {
                requestCapabilities_capabilities_SelfUpgradeUserRole = cmdletContext.Capabilities_SelfUpgradeUserRole;
            }
            if (requestCapabilities_capabilities_SelfUpgradeUserRole != null)
            {
                request.Capabilities.SelfUpgradeUserRole = requestCapabilities_capabilities_SelfUpgradeUserRole;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ServiceNowAction = null;
            if (cmdletContext.Capabilities_ServiceNowAction != null)
            {
                requestCapabilities_capabilities_ServiceNowAction = cmdletContext.Capabilities_ServiceNowAction;
            }
            if (requestCapabilities_capabilities_ServiceNowAction != null)
            {
                request.Capabilities.ServiceNowAction = requestCapabilities_capabilities_ServiceNowAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareAmazonBedrockARSAction = null;
            if (cmdletContext.Capabilities_ShareAmazonBedrockARSAction != null)
            {
                requestCapabilities_capabilities_ShareAmazonBedrockARSAction = cmdletContext.Capabilities_ShareAmazonBedrockARSAction;
            }
            if (requestCapabilities_capabilities_ShareAmazonBedrockARSAction != null)
            {
                request.Capabilities.ShareAmazonBedrockARSAction = requestCapabilities_capabilities_ShareAmazonBedrockARSAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareAmazonBedrockFSAction = null;
            if (cmdletContext.Capabilities_ShareAmazonBedrockFSAction != null)
            {
                requestCapabilities_capabilities_ShareAmazonBedrockFSAction = cmdletContext.Capabilities_ShareAmazonBedrockFSAction;
            }
            if (requestCapabilities_capabilities_ShareAmazonBedrockFSAction != null)
            {
                request.Capabilities.ShareAmazonBedrockFSAction = requestCapabilities_capabilities_ShareAmazonBedrockFSAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareAmazonBedrockKRSAction = null;
            if (cmdletContext.Capabilities_ShareAmazonBedrockKRSAction != null)
            {
                requestCapabilities_capabilities_ShareAmazonBedrockKRSAction = cmdletContext.Capabilities_ShareAmazonBedrockKRSAction;
            }
            if (requestCapabilities_capabilities_ShareAmazonBedrockKRSAction != null)
            {
                request.Capabilities.ShareAmazonBedrockKRSAction = requestCapabilities_capabilities_ShareAmazonBedrockKRSAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareAmazonSThreeAction = null;
            if (cmdletContext.Capabilities_ShareAmazonSThreeAction != null)
            {
                requestCapabilities_capabilities_ShareAmazonSThreeAction = cmdletContext.Capabilities_ShareAmazonSThreeAction;
            }
            if (requestCapabilities_capabilities_ShareAmazonSThreeAction != null)
            {
                request.Capabilities.ShareAmazonSThreeAction = requestCapabilities_capabilities_ShareAmazonSThreeAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareAnalyses = null;
            if (cmdletContext.Capabilities_ShareAnalyses != null)
            {
                requestCapabilities_capabilities_ShareAnalyses = cmdletContext.Capabilities_ShareAnalyses;
            }
            if (requestCapabilities_capabilities_ShareAnalyses != null)
            {
                request.Capabilities.ShareAnalyses = requestCapabilities_capabilities_ShareAnalyses;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareAsanaAction = null;
            if (cmdletContext.Capabilities_ShareAsanaAction != null)
            {
                requestCapabilities_capabilities_ShareAsanaAction = cmdletContext.Capabilities_ShareAsanaAction;
            }
            if (requestCapabilities_capabilities_ShareAsanaAction != null)
            {
                request.Capabilities.ShareAsanaAction = requestCapabilities_capabilities_ShareAsanaAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareBambooHRAction = null;
            if (cmdletContext.Capabilities_ShareBambooHRAction != null)
            {
                requestCapabilities_capabilities_ShareBambooHRAction = cmdletContext.Capabilities_ShareBambooHRAction;
            }
            if (requestCapabilities_capabilities_ShareBambooHRAction != null)
            {
                request.Capabilities.ShareBambooHRAction = requestCapabilities_capabilities_ShareBambooHRAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareBoxAgentAction = null;
            if (cmdletContext.Capabilities_ShareBoxAgentAction != null)
            {
                requestCapabilities_capabilities_ShareBoxAgentAction = cmdletContext.Capabilities_ShareBoxAgentAction;
            }
            if (requestCapabilities_capabilities_ShareBoxAgentAction != null)
            {
                request.Capabilities.ShareBoxAgentAction = requestCapabilities_capabilities_ShareBoxAgentAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareCanvaAgentAction = null;
            if (cmdletContext.Capabilities_ShareCanvaAgentAction != null)
            {
                requestCapabilities_capabilities_ShareCanvaAgentAction = cmdletContext.Capabilities_ShareCanvaAgentAction;
            }
            if (requestCapabilities_capabilities_ShareCanvaAgentAction != null)
            {
                request.Capabilities.ShareCanvaAgentAction = requestCapabilities_capabilities_ShareCanvaAgentAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareComprehendAction = null;
            if (cmdletContext.Capabilities_ShareComprehendAction != null)
            {
                requestCapabilities_capabilities_ShareComprehendAction = cmdletContext.Capabilities_ShareComprehendAction;
            }
            if (requestCapabilities_capabilities_ShareComprehendAction != null)
            {
                request.Capabilities.ShareComprehendAction = requestCapabilities_capabilities_ShareComprehendAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareComprehendMedicalAction = null;
            if (cmdletContext.Capabilities_ShareComprehendMedicalAction != null)
            {
                requestCapabilities_capabilities_ShareComprehendMedicalAction = cmdletContext.Capabilities_ShareComprehendMedicalAction;
            }
            if (requestCapabilities_capabilities_ShareComprehendMedicalAction != null)
            {
                request.Capabilities.ShareComprehendMedicalAction = requestCapabilities_capabilities_ShareComprehendMedicalAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareConfluenceAction = null;
            if (cmdletContext.Capabilities_ShareConfluenceAction != null)
            {
                requestCapabilities_capabilities_ShareConfluenceAction = cmdletContext.Capabilities_ShareConfluenceAction;
            }
            if (requestCapabilities_capabilities_ShareConfluenceAction != null)
            {
                request.Capabilities.ShareConfluenceAction = requestCapabilities_capabilities_ShareConfluenceAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareDashboard = null;
            if (cmdletContext.Capabilities_ShareDashboard != null)
            {
                requestCapabilities_capabilities_ShareDashboard = cmdletContext.Capabilities_ShareDashboard;
            }
            if (requestCapabilities_capabilities_ShareDashboard != null)
            {
                request.Capabilities.ShareDashboards = requestCapabilities_capabilities_ShareDashboard;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareDataset = null;
            if (cmdletContext.Capabilities_ShareDataset != null)
            {
                requestCapabilities_capabilities_ShareDataset = cmdletContext.Capabilities_ShareDataset;
            }
            if (requestCapabilities_capabilities_ShareDataset != null)
            {
                request.Capabilities.ShareDatasets = requestCapabilities_capabilities_ShareDataset;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareDataSource = null;
            if (cmdletContext.Capabilities_ShareDataSource != null)
            {
                requestCapabilities_capabilities_ShareDataSource = cmdletContext.Capabilities_ShareDataSource;
            }
            if (requestCapabilities_capabilities_ShareDataSource != null)
            {
                request.Capabilities.ShareDataSources = requestCapabilities_capabilities_ShareDataSource;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareFactSetAction = null;
            if (cmdletContext.Capabilities_ShareFactSetAction != null)
            {
                requestCapabilities_capabilities_ShareFactSetAction = cmdletContext.Capabilities_ShareFactSetAction;
            }
            if (requestCapabilities_capabilities_ShareFactSetAction != null)
            {
                request.Capabilities.ShareFactSetAction = requestCapabilities_capabilities_ShareFactSetAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareGenericHTTPAction = null;
            if (cmdletContext.Capabilities_ShareGenericHTTPAction != null)
            {
                requestCapabilities_capabilities_ShareGenericHTTPAction = cmdletContext.Capabilities_ShareGenericHTTPAction;
            }
            if (requestCapabilities_capabilities_ShareGenericHTTPAction != null)
            {
                request.Capabilities.ShareGenericHTTPAction = requestCapabilities_capabilities_ShareGenericHTTPAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareGithubAction = null;
            if (cmdletContext.Capabilities_ShareGithubAction != null)
            {
                requestCapabilities_capabilities_ShareGithubAction = cmdletContext.Capabilities_ShareGithubAction;
            }
            if (requestCapabilities_capabilities_ShareGithubAction != null)
            {
                request.Capabilities.ShareGithubAction = requestCapabilities_capabilities_ShareGithubAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareGoogleCalendarAction = null;
            if (cmdletContext.Capabilities_ShareGoogleCalendarAction != null)
            {
                requestCapabilities_capabilities_ShareGoogleCalendarAction = cmdletContext.Capabilities_ShareGoogleCalendarAction;
            }
            if (requestCapabilities_capabilities_ShareGoogleCalendarAction != null)
            {
                request.Capabilities.ShareGoogleCalendarAction = requestCapabilities_capabilities_ShareGoogleCalendarAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareHubspotAction = null;
            if (cmdletContext.Capabilities_ShareHubspotAction != null)
            {
                requestCapabilities_capabilities_ShareHubspotAction = cmdletContext.Capabilities_ShareHubspotAction;
            }
            if (requestCapabilities_capabilities_ShareHubspotAction != null)
            {
                request.Capabilities.ShareHubspotAction = requestCapabilities_capabilities_ShareHubspotAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareHuggingFaceAction = null;
            if (cmdletContext.Capabilities_ShareHuggingFaceAction != null)
            {
                requestCapabilities_capabilities_ShareHuggingFaceAction = cmdletContext.Capabilities_ShareHuggingFaceAction;
            }
            if (requestCapabilities_capabilities_ShareHuggingFaceAction != null)
            {
                request.Capabilities.ShareHuggingFaceAction = requestCapabilities_capabilities_ShareHuggingFaceAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareIntercomAction = null;
            if (cmdletContext.Capabilities_ShareIntercomAction != null)
            {
                requestCapabilities_capabilities_ShareIntercomAction = cmdletContext.Capabilities_ShareIntercomAction;
            }
            if (requestCapabilities_capabilities_ShareIntercomAction != null)
            {
                request.Capabilities.ShareIntercomAction = requestCapabilities_capabilities_ShareIntercomAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareJiraAction = null;
            if (cmdletContext.Capabilities_ShareJiraAction != null)
            {
                requestCapabilities_capabilities_ShareJiraAction = cmdletContext.Capabilities_ShareJiraAction;
            }
            if (requestCapabilities_capabilities_ShareJiraAction != null)
            {
                request.Capabilities.ShareJiraAction = requestCapabilities_capabilities_ShareJiraAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareLinearAction = null;
            if (cmdletContext.Capabilities_ShareLinearAction != null)
            {
                requestCapabilities_capabilities_ShareLinearAction = cmdletContext.Capabilities_ShareLinearAction;
            }
            if (requestCapabilities_capabilities_ShareLinearAction != null)
            {
                request.Capabilities.ShareLinearAction = requestCapabilities_capabilities_ShareLinearAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareMCPAction = null;
            if (cmdletContext.Capabilities_ShareMCPAction != null)
            {
                requestCapabilities_capabilities_ShareMCPAction = cmdletContext.Capabilities_ShareMCPAction;
            }
            if (requestCapabilities_capabilities_ShareMCPAction != null)
            {
                request.Capabilities.ShareMCPAction = requestCapabilities_capabilities_ShareMCPAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareMondayAction = null;
            if (cmdletContext.Capabilities_ShareMondayAction != null)
            {
                requestCapabilities_capabilities_ShareMondayAction = cmdletContext.Capabilities_ShareMondayAction;
            }
            if (requestCapabilities_capabilities_ShareMondayAction != null)
            {
                request.Capabilities.ShareMondayAction = requestCapabilities_capabilities_ShareMondayAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareMSExchangeAction = null;
            if (cmdletContext.Capabilities_ShareMSExchangeAction != null)
            {
                requestCapabilities_capabilities_ShareMSExchangeAction = cmdletContext.Capabilities_ShareMSExchangeAction;
            }
            if (requestCapabilities_capabilities_ShareMSExchangeAction != null)
            {
                request.Capabilities.ShareMSExchangeAction = requestCapabilities_capabilities_ShareMSExchangeAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareMSTeamsAction = null;
            if (cmdletContext.Capabilities_ShareMSTeamsAction != null)
            {
                requestCapabilities_capabilities_ShareMSTeamsAction = cmdletContext.Capabilities_ShareMSTeamsAction;
            }
            if (requestCapabilities_capabilities_ShareMSTeamsAction != null)
            {
                request.Capabilities.ShareMSTeamsAction = requestCapabilities_capabilities_ShareMSTeamsAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareNewRelicAction = null;
            if (cmdletContext.Capabilities_ShareNewRelicAction != null)
            {
                requestCapabilities_capabilities_ShareNewRelicAction = cmdletContext.Capabilities_ShareNewRelicAction;
            }
            if (requestCapabilities_capabilities_ShareNewRelicAction != null)
            {
                request.Capabilities.ShareNewRelicAction = requestCapabilities_capabilities_ShareNewRelicAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareNotionAction = null;
            if (cmdletContext.Capabilities_ShareNotionAction != null)
            {
                requestCapabilities_capabilities_ShareNotionAction = cmdletContext.Capabilities_ShareNotionAction;
            }
            if (requestCapabilities_capabilities_ShareNotionAction != null)
            {
                request.Capabilities.ShareNotionAction = requestCapabilities_capabilities_ShareNotionAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareOneDriveAction = null;
            if (cmdletContext.Capabilities_ShareOneDriveAction != null)
            {
                requestCapabilities_capabilities_ShareOneDriveAction = cmdletContext.Capabilities_ShareOneDriveAction;
            }
            if (requestCapabilities_capabilities_ShareOneDriveAction != null)
            {
                request.Capabilities.ShareOneDriveAction = requestCapabilities_capabilities_ShareOneDriveAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareOpenAPIAction = null;
            if (cmdletContext.Capabilities_ShareOpenAPIAction != null)
            {
                requestCapabilities_capabilities_ShareOpenAPIAction = cmdletContext.Capabilities_ShareOpenAPIAction;
            }
            if (requestCapabilities_capabilities_ShareOpenAPIAction != null)
            {
                request.Capabilities.ShareOpenAPIAction = requestCapabilities_capabilities_ShareOpenAPIAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_SharePagerDutyAction = null;
            if (cmdletContext.Capabilities_SharePagerDutyAction != null)
            {
                requestCapabilities_capabilities_SharePagerDutyAction = cmdletContext.Capabilities_SharePagerDutyAction;
            }
            if (requestCapabilities_capabilities_SharePagerDutyAction != null)
            {
                request.Capabilities.SharePagerDutyAction = requestCapabilities_capabilities_SharePagerDutyAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_SharePointAction = null;
            if (cmdletContext.Capabilities_SharePointAction != null)
            {
                requestCapabilities_capabilities_SharePointAction = cmdletContext.Capabilities_SharePointAction;
            }
            if (requestCapabilities_capabilities_SharePointAction != null)
            {
                request.Capabilities.SharePointAction = requestCapabilities_capabilities_SharePointAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareSalesforceAction = null;
            if (cmdletContext.Capabilities_ShareSalesforceAction != null)
            {
                requestCapabilities_capabilities_ShareSalesforceAction = cmdletContext.Capabilities_ShareSalesforceAction;
            }
            if (requestCapabilities_capabilities_ShareSalesforceAction != null)
            {
                request.Capabilities.ShareSalesforceAction = requestCapabilities_capabilities_ShareSalesforceAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareSandPGlobalEnergyAction = null;
            if (cmdletContext.Capabilities_ShareSandPGlobalEnergyAction != null)
            {
                requestCapabilities_capabilities_ShareSandPGlobalEnergyAction = cmdletContext.Capabilities_ShareSandPGlobalEnergyAction;
            }
            if (requestCapabilities_capabilities_ShareSandPGlobalEnergyAction != null)
            {
                request.Capabilities.ShareSandPGlobalEnergyAction = requestCapabilities_capabilities_ShareSandPGlobalEnergyAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareSandPGMIAction = null;
            if (cmdletContext.Capabilities_ShareSandPGMIAction != null)
            {
                requestCapabilities_capabilities_ShareSandPGMIAction = cmdletContext.Capabilities_ShareSandPGMIAction;
            }
            if (requestCapabilities_capabilities_ShareSandPGMIAction != null)
            {
                request.Capabilities.ShareSandPGMIAction = requestCapabilities_capabilities_ShareSandPGMIAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareSAPBillOfMaterialAction = null;
            if (cmdletContext.Capabilities_ShareSAPBillOfMaterialAction != null)
            {
                requestCapabilities_capabilities_ShareSAPBillOfMaterialAction = cmdletContext.Capabilities_ShareSAPBillOfMaterialAction;
            }
            if (requestCapabilities_capabilities_ShareSAPBillOfMaterialAction != null)
            {
                request.Capabilities.ShareSAPBillOfMaterialAction = requestCapabilities_capabilities_ShareSAPBillOfMaterialAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareSAPBusinessPartnerAction = null;
            if (cmdletContext.Capabilities_ShareSAPBusinessPartnerAction != null)
            {
                requestCapabilities_capabilities_ShareSAPBusinessPartnerAction = cmdletContext.Capabilities_ShareSAPBusinessPartnerAction;
            }
            if (requestCapabilities_capabilities_ShareSAPBusinessPartnerAction != null)
            {
                request.Capabilities.ShareSAPBusinessPartnerAction = requestCapabilities_capabilities_ShareSAPBusinessPartnerAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareSAPMaterialStockAction = null;
            if (cmdletContext.Capabilities_ShareSAPMaterialStockAction != null)
            {
                requestCapabilities_capabilities_ShareSAPMaterialStockAction = cmdletContext.Capabilities_ShareSAPMaterialStockAction;
            }
            if (requestCapabilities_capabilities_ShareSAPMaterialStockAction != null)
            {
                request.Capabilities.ShareSAPMaterialStockAction = requestCapabilities_capabilities_ShareSAPMaterialStockAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareSAPPhysicalInventoryAction = null;
            if (cmdletContext.Capabilities_ShareSAPPhysicalInventoryAction != null)
            {
                requestCapabilities_capabilities_ShareSAPPhysicalInventoryAction = cmdletContext.Capabilities_ShareSAPPhysicalInventoryAction;
            }
            if (requestCapabilities_capabilities_ShareSAPPhysicalInventoryAction != null)
            {
                request.Capabilities.ShareSAPPhysicalInventoryAction = requestCapabilities_capabilities_ShareSAPPhysicalInventoryAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareSAPProductMasterDataAction = null;
            if (cmdletContext.Capabilities_ShareSAPProductMasterDataAction != null)
            {
                requestCapabilities_capabilities_ShareSAPProductMasterDataAction = cmdletContext.Capabilities_ShareSAPProductMasterDataAction;
            }
            if (requestCapabilities_capabilities_ShareSAPProductMasterDataAction != null)
            {
                request.Capabilities.ShareSAPProductMasterDataAction = requestCapabilities_capabilities_ShareSAPProductMasterDataAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareServiceNowAction = null;
            if (cmdletContext.Capabilities_ShareServiceNowAction != null)
            {
                requestCapabilities_capabilities_ShareServiceNowAction = cmdletContext.Capabilities_ShareServiceNowAction;
            }
            if (requestCapabilities_capabilities_ShareServiceNowAction != null)
            {
                request.Capabilities.ShareServiceNowAction = requestCapabilities_capabilities_ShareServiceNowAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareSharePointAction = null;
            if (cmdletContext.Capabilities_ShareSharePointAction != null)
            {
                requestCapabilities_capabilities_ShareSharePointAction = cmdletContext.Capabilities_ShareSharePointAction;
            }
            if (requestCapabilities_capabilities_ShareSharePointAction != null)
            {
                request.Capabilities.ShareSharePointAction = requestCapabilities_capabilities_ShareSharePointAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareSlackAction = null;
            if (cmdletContext.Capabilities_ShareSlackAction != null)
            {
                requestCapabilities_capabilities_ShareSlackAction = cmdletContext.Capabilities_ShareSlackAction;
            }
            if (requestCapabilities_capabilities_ShareSlackAction != null)
            {
                request.Capabilities.ShareSlackAction = requestCapabilities_capabilities_ShareSlackAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareSmartsheetAction = null;
            if (cmdletContext.Capabilities_ShareSmartsheetAction != null)
            {
                requestCapabilities_capabilities_ShareSmartsheetAction = cmdletContext.Capabilities_ShareSmartsheetAction;
            }
            if (requestCapabilities_capabilities_ShareSmartsheetAction != null)
            {
                request.Capabilities.ShareSmartsheetAction = requestCapabilities_capabilities_ShareSmartsheetAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareTextractAction = null;
            if (cmdletContext.Capabilities_ShareTextractAction != null)
            {
                requestCapabilities_capabilities_ShareTextractAction = cmdletContext.Capabilities_ShareTextractAction;
            }
            if (requestCapabilities_capabilities_ShareTextractAction != null)
            {
                request.Capabilities.ShareTextractAction = requestCapabilities_capabilities_ShareTextractAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ShareZendeskAction = null;
            if (cmdletContext.Capabilities_ShareZendeskAction != null)
            {
                requestCapabilities_capabilities_ShareZendeskAction = cmdletContext.Capabilities_ShareZendeskAction;
            }
            if (requestCapabilities_capabilities_ShareZendeskAction != null)
            {
                request.Capabilities.ShareZendeskAction = requestCapabilities_capabilities_ShareZendeskAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_SlackAction = null;
            if (cmdletContext.Capabilities_SlackAction != null)
            {
                requestCapabilities_capabilities_SlackAction = cmdletContext.Capabilities_SlackAction;
            }
            if (requestCapabilities_capabilities_SlackAction != null)
            {
                request.Capabilities.SlackAction = requestCapabilities_capabilities_SlackAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_SmartsheetAction = null;
            if (cmdletContext.Capabilities_SmartsheetAction != null)
            {
                requestCapabilities_capabilities_SmartsheetAction = cmdletContext.Capabilities_SmartsheetAction;
            }
            if (requestCapabilities_capabilities_SmartsheetAction != null)
            {
                request.Capabilities.SmartsheetAction = requestCapabilities_capabilities_SmartsheetAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_Space = null;
            if (cmdletContext.Capabilities_Space != null)
            {
                requestCapabilities_capabilities_Space = cmdletContext.Capabilities_Space;
            }
            if (requestCapabilities_capabilities_Space != null)
            {
                request.Capabilities.Space = requestCapabilities_capabilities_Space;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_SubscribeDashboardEmailReport = null;
            if (cmdletContext.Capabilities_SubscribeDashboardEmailReport != null)
            {
                requestCapabilities_capabilities_SubscribeDashboardEmailReport = cmdletContext.Capabilities_SubscribeDashboardEmailReport;
            }
            if (requestCapabilities_capabilities_SubscribeDashboardEmailReport != null)
            {
                request.Capabilities.SubscribeDashboardEmailReports = requestCapabilities_capabilities_SubscribeDashboardEmailReport;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_TextractAction = null;
            if (cmdletContext.Capabilities_TextractAction != null)
            {
                requestCapabilities_capabilities_TextractAction = cmdletContext.Capabilities_TextractAction;
            }
            if (requestCapabilities_capabilities_TextractAction != null)
            {
                request.Capabilities.TextractAction = requestCapabilities_capabilities_TextractAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseAgentWebSearch = null;
            if (cmdletContext.Capabilities_UseAgentWebSearch != null)
            {
                requestCapabilities_capabilities_UseAgentWebSearch = cmdletContext.Capabilities_UseAgentWebSearch;
            }
            if (requestCapabilities_capabilities_UseAgentWebSearch != null)
            {
                request.Capabilities.UseAgentWebSearch = requestCapabilities_capabilities_UseAgentWebSearch;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseAmazonBedrockARSAction = null;
            if (cmdletContext.Capabilities_UseAmazonBedrockARSAction != null)
            {
                requestCapabilities_capabilities_UseAmazonBedrockARSAction = cmdletContext.Capabilities_UseAmazonBedrockARSAction;
            }
            if (requestCapabilities_capabilities_UseAmazonBedrockARSAction != null)
            {
                request.Capabilities.UseAmazonBedrockARSAction = requestCapabilities_capabilities_UseAmazonBedrockARSAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseAmazonBedrockFSAction = null;
            if (cmdletContext.Capabilities_UseAmazonBedrockFSAction != null)
            {
                requestCapabilities_capabilities_UseAmazonBedrockFSAction = cmdletContext.Capabilities_UseAmazonBedrockFSAction;
            }
            if (requestCapabilities_capabilities_UseAmazonBedrockFSAction != null)
            {
                request.Capabilities.UseAmazonBedrockFSAction = requestCapabilities_capabilities_UseAmazonBedrockFSAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseAmazonBedrockKRSAction = null;
            if (cmdletContext.Capabilities_UseAmazonBedrockKRSAction != null)
            {
                requestCapabilities_capabilities_UseAmazonBedrockKRSAction = cmdletContext.Capabilities_UseAmazonBedrockKRSAction;
            }
            if (requestCapabilities_capabilities_UseAmazonBedrockKRSAction != null)
            {
                request.Capabilities.UseAmazonBedrockKRSAction = requestCapabilities_capabilities_UseAmazonBedrockKRSAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseAmazonSThreeAction = null;
            if (cmdletContext.Capabilities_UseAmazonSThreeAction != null)
            {
                requestCapabilities_capabilities_UseAmazonSThreeAction = cmdletContext.Capabilities_UseAmazonSThreeAction;
            }
            if (requestCapabilities_capabilities_UseAmazonSThreeAction != null)
            {
                request.Capabilities.UseAmazonSThreeAction = requestCapabilities_capabilities_UseAmazonSThreeAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseAsanaAction = null;
            if (cmdletContext.Capabilities_UseAsanaAction != null)
            {
                requestCapabilities_capabilities_UseAsanaAction = cmdletContext.Capabilities_UseAsanaAction;
            }
            if (requestCapabilities_capabilities_UseAsanaAction != null)
            {
                request.Capabilities.UseAsanaAction = requestCapabilities_capabilities_UseAsanaAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseBambooHRAction = null;
            if (cmdletContext.Capabilities_UseBambooHRAction != null)
            {
                requestCapabilities_capabilities_UseBambooHRAction = cmdletContext.Capabilities_UseBambooHRAction;
            }
            if (requestCapabilities_capabilities_UseBambooHRAction != null)
            {
                request.Capabilities.UseBambooHRAction = requestCapabilities_capabilities_UseBambooHRAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseBedrockModel = null;
            if (cmdletContext.Capabilities_UseBedrockModel != null)
            {
                requestCapabilities_capabilities_UseBedrockModel = cmdletContext.Capabilities_UseBedrockModel;
            }
            if (requestCapabilities_capabilities_UseBedrockModel != null)
            {
                request.Capabilities.UseBedrockModels = requestCapabilities_capabilities_UseBedrockModel;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseBoxAgentAction = null;
            if (cmdletContext.Capabilities_UseBoxAgentAction != null)
            {
                requestCapabilities_capabilities_UseBoxAgentAction = cmdletContext.Capabilities_UseBoxAgentAction;
            }
            if (requestCapabilities_capabilities_UseBoxAgentAction != null)
            {
                request.Capabilities.UseBoxAgentAction = requestCapabilities_capabilities_UseBoxAgentAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseCanvaAgentAction = null;
            if (cmdletContext.Capabilities_UseCanvaAgentAction != null)
            {
                requestCapabilities_capabilities_UseCanvaAgentAction = cmdletContext.Capabilities_UseCanvaAgentAction;
            }
            if (requestCapabilities_capabilities_UseCanvaAgentAction != null)
            {
                request.Capabilities.UseCanvaAgentAction = requestCapabilities_capabilities_UseCanvaAgentAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseComprehendAction = null;
            if (cmdletContext.Capabilities_UseComprehendAction != null)
            {
                requestCapabilities_capabilities_UseComprehendAction = cmdletContext.Capabilities_UseComprehendAction;
            }
            if (requestCapabilities_capabilities_UseComprehendAction != null)
            {
                request.Capabilities.UseComprehendAction = requestCapabilities_capabilities_UseComprehendAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseComprehendMedicalAction = null;
            if (cmdletContext.Capabilities_UseComprehendMedicalAction != null)
            {
                requestCapabilities_capabilities_UseComprehendMedicalAction = cmdletContext.Capabilities_UseComprehendMedicalAction;
            }
            if (requestCapabilities_capabilities_UseComprehendMedicalAction != null)
            {
                request.Capabilities.UseComprehendMedicalAction = requestCapabilities_capabilities_UseComprehendMedicalAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseConfluenceAction = null;
            if (cmdletContext.Capabilities_UseConfluenceAction != null)
            {
                requestCapabilities_capabilities_UseConfluenceAction = cmdletContext.Capabilities_UseConfluenceAction;
            }
            if (requestCapabilities_capabilities_UseConfluenceAction != null)
            {
                request.Capabilities.UseConfluenceAction = requestCapabilities_capabilities_UseConfluenceAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseFactSetAction = null;
            if (cmdletContext.Capabilities_UseFactSetAction != null)
            {
                requestCapabilities_capabilities_UseFactSetAction = cmdletContext.Capabilities_UseFactSetAction;
            }
            if (requestCapabilities_capabilities_UseFactSetAction != null)
            {
                request.Capabilities.UseFactSetAction = requestCapabilities_capabilities_UseFactSetAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseGenericHTTPAction = null;
            if (cmdletContext.Capabilities_UseGenericHTTPAction != null)
            {
                requestCapabilities_capabilities_UseGenericHTTPAction = cmdletContext.Capabilities_UseGenericHTTPAction;
            }
            if (requestCapabilities_capabilities_UseGenericHTTPAction != null)
            {
                request.Capabilities.UseGenericHTTPAction = requestCapabilities_capabilities_UseGenericHTTPAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseGithubAction = null;
            if (cmdletContext.Capabilities_UseGithubAction != null)
            {
                requestCapabilities_capabilities_UseGithubAction = cmdletContext.Capabilities_UseGithubAction;
            }
            if (requestCapabilities_capabilities_UseGithubAction != null)
            {
                request.Capabilities.UseGithubAction = requestCapabilities_capabilities_UseGithubAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseGoogleCalendarAction = null;
            if (cmdletContext.Capabilities_UseGoogleCalendarAction != null)
            {
                requestCapabilities_capabilities_UseGoogleCalendarAction = cmdletContext.Capabilities_UseGoogleCalendarAction;
            }
            if (requestCapabilities_capabilities_UseGoogleCalendarAction != null)
            {
                request.Capabilities.UseGoogleCalendarAction = requestCapabilities_capabilities_UseGoogleCalendarAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseHubspotAction = null;
            if (cmdletContext.Capabilities_UseHubspotAction != null)
            {
                requestCapabilities_capabilities_UseHubspotAction = cmdletContext.Capabilities_UseHubspotAction;
            }
            if (requestCapabilities_capabilities_UseHubspotAction != null)
            {
                request.Capabilities.UseHubspotAction = requestCapabilities_capabilities_UseHubspotAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseHuggingFaceAction = null;
            if (cmdletContext.Capabilities_UseHuggingFaceAction != null)
            {
                requestCapabilities_capabilities_UseHuggingFaceAction = cmdletContext.Capabilities_UseHuggingFaceAction;
            }
            if (requestCapabilities_capabilities_UseHuggingFaceAction != null)
            {
                request.Capabilities.UseHuggingFaceAction = requestCapabilities_capabilities_UseHuggingFaceAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseIntercomAction = null;
            if (cmdletContext.Capabilities_UseIntercomAction != null)
            {
                requestCapabilities_capabilities_UseIntercomAction = cmdletContext.Capabilities_UseIntercomAction;
            }
            if (requestCapabilities_capabilities_UseIntercomAction != null)
            {
                request.Capabilities.UseIntercomAction = requestCapabilities_capabilities_UseIntercomAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseJiraAction = null;
            if (cmdletContext.Capabilities_UseJiraAction != null)
            {
                requestCapabilities_capabilities_UseJiraAction = cmdletContext.Capabilities_UseJiraAction;
            }
            if (requestCapabilities_capabilities_UseJiraAction != null)
            {
                request.Capabilities.UseJiraAction = requestCapabilities_capabilities_UseJiraAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseLinearAction = null;
            if (cmdletContext.Capabilities_UseLinearAction != null)
            {
                requestCapabilities_capabilities_UseLinearAction = cmdletContext.Capabilities_UseLinearAction;
            }
            if (requestCapabilities_capabilities_UseLinearAction != null)
            {
                request.Capabilities.UseLinearAction = requestCapabilities_capabilities_UseLinearAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseMCPAction = null;
            if (cmdletContext.Capabilities_UseMCPAction != null)
            {
                requestCapabilities_capabilities_UseMCPAction = cmdletContext.Capabilities_UseMCPAction;
            }
            if (requestCapabilities_capabilities_UseMCPAction != null)
            {
                request.Capabilities.UseMCPAction = requestCapabilities_capabilities_UseMCPAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseMondayAction = null;
            if (cmdletContext.Capabilities_UseMondayAction != null)
            {
                requestCapabilities_capabilities_UseMondayAction = cmdletContext.Capabilities_UseMondayAction;
            }
            if (requestCapabilities_capabilities_UseMondayAction != null)
            {
                request.Capabilities.UseMondayAction = requestCapabilities_capabilities_UseMondayAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseMSExchangeAction = null;
            if (cmdletContext.Capabilities_UseMSExchangeAction != null)
            {
                requestCapabilities_capabilities_UseMSExchangeAction = cmdletContext.Capabilities_UseMSExchangeAction;
            }
            if (requestCapabilities_capabilities_UseMSExchangeAction != null)
            {
                request.Capabilities.UseMSExchangeAction = requestCapabilities_capabilities_UseMSExchangeAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseMSTeamsAction = null;
            if (cmdletContext.Capabilities_UseMSTeamsAction != null)
            {
                requestCapabilities_capabilities_UseMSTeamsAction = cmdletContext.Capabilities_UseMSTeamsAction;
            }
            if (requestCapabilities_capabilities_UseMSTeamsAction != null)
            {
                request.Capabilities.UseMSTeamsAction = requestCapabilities_capabilities_UseMSTeamsAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseNewRelicAction = null;
            if (cmdletContext.Capabilities_UseNewRelicAction != null)
            {
                requestCapabilities_capabilities_UseNewRelicAction = cmdletContext.Capabilities_UseNewRelicAction;
            }
            if (requestCapabilities_capabilities_UseNewRelicAction != null)
            {
                request.Capabilities.UseNewRelicAction = requestCapabilities_capabilities_UseNewRelicAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseNotionAction = null;
            if (cmdletContext.Capabilities_UseNotionAction != null)
            {
                requestCapabilities_capabilities_UseNotionAction = cmdletContext.Capabilities_UseNotionAction;
            }
            if (requestCapabilities_capabilities_UseNotionAction != null)
            {
                request.Capabilities.UseNotionAction = requestCapabilities_capabilities_UseNotionAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseOneDriveAction = null;
            if (cmdletContext.Capabilities_UseOneDriveAction != null)
            {
                requestCapabilities_capabilities_UseOneDriveAction = cmdletContext.Capabilities_UseOneDriveAction;
            }
            if (requestCapabilities_capabilities_UseOneDriveAction != null)
            {
                request.Capabilities.UseOneDriveAction = requestCapabilities_capabilities_UseOneDriveAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseOpenAPIAction = null;
            if (cmdletContext.Capabilities_UseOpenAPIAction != null)
            {
                requestCapabilities_capabilities_UseOpenAPIAction = cmdletContext.Capabilities_UseOpenAPIAction;
            }
            if (requestCapabilities_capabilities_UseOpenAPIAction != null)
            {
                request.Capabilities.UseOpenAPIAction = requestCapabilities_capabilities_UseOpenAPIAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UsePagerDutyAction = null;
            if (cmdletContext.Capabilities_UsePagerDutyAction != null)
            {
                requestCapabilities_capabilities_UsePagerDutyAction = cmdletContext.Capabilities_UsePagerDutyAction;
            }
            if (requestCapabilities_capabilities_UsePagerDutyAction != null)
            {
                request.Capabilities.UsePagerDutyAction = requestCapabilities_capabilities_UsePagerDutyAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseSalesforceAction = null;
            if (cmdletContext.Capabilities_UseSalesforceAction != null)
            {
                requestCapabilities_capabilities_UseSalesforceAction = cmdletContext.Capabilities_UseSalesforceAction;
            }
            if (requestCapabilities_capabilities_UseSalesforceAction != null)
            {
                request.Capabilities.UseSalesforceAction = requestCapabilities_capabilities_UseSalesforceAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseSandPGlobalEnergyAction = null;
            if (cmdletContext.Capabilities_UseSandPGlobalEnergyAction != null)
            {
                requestCapabilities_capabilities_UseSandPGlobalEnergyAction = cmdletContext.Capabilities_UseSandPGlobalEnergyAction;
            }
            if (requestCapabilities_capabilities_UseSandPGlobalEnergyAction != null)
            {
                request.Capabilities.UseSandPGlobalEnergyAction = requestCapabilities_capabilities_UseSandPGlobalEnergyAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseSandPGMIAction = null;
            if (cmdletContext.Capabilities_UseSandPGMIAction != null)
            {
                requestCapabilities_capabilities_UseSandPGMIAction = cmdletContext.Capabilities_UseSandPGMIAction;
            }
            if (requestCapabilities_capabilities_UseSandPGMIAction != null)
            {
                request.Capabilities.UseSandPGMIAction = requestCapabilities_capabilities_UseSandPGMIAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseSAPBillOfMaterialAction = null;
            if (cmdletContext.Capabilities_UseSAPBillOfMaterialAction != null)
            {
                requestCapabilities_capabilities_UseSAPBillOfMaterialAction = cmdletContext.Capabilities_UseSAPBillOfMaterialAction;
            }
            if (requestCapabilities_capabilities_UseSAPBillOfMaterialAction != null)
            {
                request.Capabilities.UseSAPBillOfMaterialAction = requestCapabilities_capabilities_UseSAPBillOfMaterialAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseSAPBusinessPartnerAction = null;
            if (cmdletContext.Capabilities_UseSAPBusinessPartnerAction != null)
            {
                requestCapabilities_capabilities_UseSAPBusinessPartnerAction = cmdletContext.Capabilities_UseSAPBusinessPartnerAction;
            }
            if (requestCapabilities_capabilities_UseSAPBusinessPartnerAction != null)
            {
                request.Capabilities.UseSAPBusinessPartnerAction = requestCapabilities_capabilities_UseSAPBusinessPartnerAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseSAPMaterialStockAction = null;
            if (cmdletContext.Capabilities_UseSAPMaterialStockAction != null)
            {
                requestCapabilities_capabilities_UseSAPMaterialStockAction = cmdletContext.Capabilities_UseSAPMaterialStockAction;
            }
            if (requestCapabilities_capabilities_UseSAPMaterialStockAction != null)
            {
                request.Capabilities.UseSAPMaterialStockAction = requestCapabilities_capabilities_UseSAPMaterialStockAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseSAPPhysicalInventoryAction = null;
            if (cmdletContext.Capabilities_UseSAPPhysicalInventoryAction != null)
            {
                requestCapabilities_capabilities_UseSAPPhysicalInventoryAction = cmdletContext.Capabilities_UseSAPPhysicalInventoryAction;
            }
            if (requestCapabilities_capabilities_UseSAPPhysicalInventoryAction != null)
            {
                request.Capabilities.UseSAPPhysicalInventoryAction = requestCapabilities_capabilities_UseSAPPhysicalInventoryAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseSAPProductMasterDataAction = null;
            if (cmdletContext.Capabilities_UseSAPProductMasterDataAction != null)
            {
                requestCapabilities_capabilities_UseSAPProductMasterDataAction = cmdletContext.Capabilities_UseSAPProductMasterDataAction;
            }
            if (requestCapabilities_capabilities_UseSAPProductMasterDataAction != null)
            {
                request.Capabilities.UseSAPProductMasterDataAction = requestCapabilities_capabilities_UseSAPProductMasterDataAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseServiceNowAction = null;
            if (cmdletContext.Capabilities_UseServiceNowAction != null)
            {
                requestCapabilities_capabilities_UseServiceNowAction = cmdletContext.Capabilities_UseServiceNowAction;
            }
            if (requestCapabilities_capabilities_UseServiceNowAction != null)
            {
                request.Capabilities.UseServiceNowAction = requestCapabilities_capabilities_UseServiceNowAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseSharePointAction = null;
            if (cmdletContext.Capabilities_UseSharePointAction != null)
            {
                requestCapabilities_capabilities_UseSharePointAction = cmdletContext.Capabilities_UseSharePointAction;
            }
            if (requestCapabilities_capabilities_UseSharePointAction != null)
            {
                request.Capabilities.UseSharePointAction = requestCapabilities_capabilities_UseSharePointAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseSlackAction = null;
            if (cmdletContext.Capabilities_UseSlackAction != null)
            {
                requestCapabilities_capabilities_UseSlackAction = cmdletContext.Capabilities_UseSlackAction;
            }
            if (requestCapabilities_capabilities_UseSlackAction != null)
            {
                request.Capabilities.UseSlackAction = requestCapabilities_capabilities_UseSlackAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseSmartsheetAction = null;
            if (cmdletContext.Capabilities_UseSmartsheetAction != null)
            {
                requestCapabilities_capabilities_UseSmartsheetAction = cmdletContext.Capabilities_UseSmartsheetAction;
            }
            if (requestCapabilities_capabilities_UseSmartsheetAction != null)
            {
                request.Capabilities.UseSmartsheetAction = requestCapabilities_capabilities_UseSmartsheetAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseTextractAction = null;
            if (cmdletContext.Capabilities_UseTextractAction != null)
            {
                requestCapabilities_capabilities_UseTextractAction = cmdletContext.Capabilities_UseTextractAction;
            }
            if (requestCapabilities_capabilities_UseTextractAction != null)
            {
                request.Capabilities.UseTextractAction = requestCapabilities_capabilities_UseTextractAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_UseZendeskAction = null;
            if (cmdletContext.Capabilities_UseZendeskAction != null)
            {
                requestCapabilities_capabilities_UseZendeskAction = cmdletContext.Capabilities_UseZendeskAction;
            }
            if (requestCapabilities_capabilities_UseZendeskAction != null)
            {
                request.Capabilities.UseZendeskAction = requestCapabilities_capabilities_UseZendeskAction;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ViewAccountSPICECapacity = null;
            if (cmdletContext.Capabilities_ViewAccountSPICECapacity != null)
            {
                requestCapabilities_capabilities_ViewAccountSPICECapacity = cmdletContext.Capabilities_ViewAccountSPICECapacity;
            }
            if (requestCapabilities_capabilities_ViewAccountSPICECapacity != null)
            {
                request.Capabilities.ViewAccountSPICECapacity = requestCapabilities_capabilities_ViewAccountSPICECapacity;
                requestCapabilitiesIsNull = false;
            }
            Amazon.QuickSight.CapabilityState requestCapabilities_capabilities_ZendeskAction = null;
            if (cmdletContext.Capabilities_ZendeskAction != null)
            {
                requestCapabilities_capabilities_ZendeskAction = cmdletContext.Capabilities_ZendeskAction;
            }
            if (requestCapabilities_capabilities_ZendeskAction != null)
            {
                request.Capabilities.ZendeskAction = requestCapabilities_capabilities_ZendeskAction;
                requestCapabilitiesIsNull = false;
            }
             // determine if request.Capabilities should be set to null
            if (requestCapabilitiesIsNull)
            {
                request.Capabilities = null;
            }
            if (cmdletContext.CustomPermissionsName != null)
            {
                request.CustomPermissionsName = cmdletContext.CustomPermissionsName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.QuickSight.Model.CreateCustomPermissionsResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.CreateCustomPermissionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "CreateCustomPermissions");
            try
            {
                return client.CreateCustomPermissionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String AwsAccountId { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_Action { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_AddOrRunAnomalyDetectionForAnalyses { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_AmazonBedrockARSAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_AmazonBedrockFSAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_AmazonBedrockKRSAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_AmazonSThreeAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_Analysis { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_AsanaAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_Automate { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_BambooHRAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_BoxAgentAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CanvaAgentAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ChatAgent { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ComprehendAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ComprehendMedicalAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ConfluenceAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateAmazonBedrockARSAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateAmazonBedrockFSAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateAmazonBedrockKRSAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateAmazonSThreeAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateAsanaAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateBambooHRAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateBoxAgentAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateCanvaAgentAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateComprehendAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateComprehendMedicalAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateConfluenceAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateDashboardEmailReport { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateDataset { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateDataSource { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateFactSetAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateGenericHTTPAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateGithubAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateGoogleCalendarAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateHubspotAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateHuggingFaceAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateIntercomAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateJiraAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateLinearAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateMCPAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateMondayAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateMSExchangeAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateMSTeamsAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateNewRelicAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateNotionAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateOneDriveAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateOpenAPIAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdatePagerDutyAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateSalesforceAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateSandPGlobalEnergyAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateSandPGMIAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateSAPBillOfMaterialAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateSAPBusinessPartnerAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateSAPMaterialStockAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateSAPPhysicalInventoryAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateSAPProductMasterDataAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateServiceNowAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateSharePointAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateSlackAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateSmartsheetAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateTextractAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateTheme { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateThresholdAlert { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateZendeskAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateChatAgent { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateSharedFolder { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateSPICEDataset { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_Dashboard { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ExportToCsv { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ExportToCsvInScheduledReport { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ExportToExcel { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ExportToExcelInScheduledReport { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ExportToPdf { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ExportToPdfInScheduledReport { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_FactSetAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_Flow { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_GenericHTTPAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_GithubAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_GoogleCalendarAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_HubspotAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_HuggingFaceAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_IncludeContentInScheduledReportsEmail { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_IntercomAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_JiraAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_KnowledgeBase { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_LinearAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_MCPAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_MondayAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_MSExchangeAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_MSTeamsAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_NewRelicAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_NotionAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_OneDriveAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_OpenAPIAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_PagerDutyAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_PerformFlowUiTask { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_PrintReport { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_PublishWithoutApproval { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_RenameSharedFolder { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_Research { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_SalesforceAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_SandPGlobalEnergyAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_SandPGMIAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_SAPBillOfMaterialAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_SAPBusinessPartnerAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_SAPMaterialStockAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_SAPPhysicalInventoryAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_SAPProductMasterDataAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_SelfUpgradeUserRole { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ServiceNowAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareAmazonBedrockARSAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareAmazonBedrockFSAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareAmazonBedrockKRSAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareAmazonSThreeAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareAnalyses { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareAsanaAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareBambooHRAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareBoxAgentAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareCanvaAgentAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareComprehendAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareComprehendMedicalAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareConfluenceAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareDashboard { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareDataset { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareDataSource { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareFactSetAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareGenericHTTPAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareGithubAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareGoogleCalendarAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareHubspotAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareHuggingFaceAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareIntercomAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareJiraAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareLinearAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareMCPAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareMondayAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareMSExchangeAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareMSTeamsAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareNewRelicAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareNotionAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareOneDriveAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareOpenAPIAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_SharePagerDutyAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_SharePointAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareSalesforceAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareSandPGlobalEnergyAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareSandPGMIAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareSAPBillOfMaterialAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareSAPBusinessPartnerAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareSAPMaterialStockAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareSAPPhysicalInventoryAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareSAPProductMasterDataAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareServiceNowAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareSharePointAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareSlackAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareSmartsheetAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareTextractAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareZendeskAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_SlackAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_SmartsheetAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_Space { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_SubscribeDashboardEmailReport { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_TextractAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseAgentWebSearch { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseAmazonBedrockARSAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseAmazonBedrockFSAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseAmazonBedrockKRSAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseAmazonSThreeAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseAsanaAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseBambooHRAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseBedrockModel { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseBoxAgentAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseCanvaAgentAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseComprehendAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseComprehendMedicalAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseConfluenceAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseFactSetAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseGenericHTTPAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseGithubAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseGoogleCalendarAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseHubspotAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseHuggingFaceAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseIntercomAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseJiraAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseLinearAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseMCPAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseMondayAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseMSExchangeAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseMSTeamsAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseNewRelicAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseNotionAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseOneDriveAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseOpenAPIAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UsePagerDutyAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseSalesforceAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseSandPGlobalEnergyAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseSandPGMIAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseSAPBillOfMaterialAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseSAPBusinessPartnerAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseSAPMaterialStockAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseSAPPhysicalInventoryAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseSAPProductMasterDataAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseServiceNowAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseSharePointAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseSlackAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseSmartsheetAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseTextractAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseZendeskAction { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ViewAccountSPICECapacity { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ZendeskAction { get; set; }
            public System.String CustomPermissionsName { get; set; }
            public List<Amazon.QuickSight.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.QuickSight.Model.CreateCustomPermissionsResponse, NewQSCustomPermissionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Arn;
        }
        
    }
}
