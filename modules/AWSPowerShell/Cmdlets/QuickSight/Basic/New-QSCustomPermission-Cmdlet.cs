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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

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
        /// <para>The tags to associate with the custom permissions profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.QuickSight.Model.Tag[] Tag { get; set; }
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CustomPermissionsName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CustomPermissionsName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CustomPermissionsName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CustomPermissionsName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QSCustomPermission (CreateCustomPermissions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.CreateCustomPermissionsResponse, NewQSCustomPermissionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CustomPermissionsName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Capabilities_Action = this.Capabilities_Action;
            context.Capabilities_AddOrRunAnomalyDetectionForAnalyses = this.Capabilities_AddOrRunAnomalyDetectionForAnalyses;
            context.Capabilities_Analysis = this.Capabilities_Analysis;
            context.Capabilities_Automate = this.Capabilities_Automate;
            context.Capabilities_ChatAgent = this.Capabilities_ChatAgent;
            context.Capabilities_CreateAndUpdateDashboardEmailReport = this.Capabilities_CreateAndUpdateDashboardEmailReport;
            context.Capabilities_CreateAndUpdateDataset = this.Capabilities_CreateAndUpdateDataset;
            context.Capabilities_CreateAndUpdateDataSource = this.Capabilities_CreateAndUpdateDataSource;
            context.Capabilities_CreateAndUpdateTheme = this.Capabilities_CreateAndUpdateTheme;
            context.Capabilities_CreateAndUpdateThresholdAlert = this.Capabilities_CreateAndUpdateThresholdAlert;
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
            context.Capabilities_Flow = this.Capabilities_Flow;
            context.Capabilities_IncludeContentInScheduledReportsEmail = this.Capabilities_IncludeContentInScheduledReportsEmail;
            context.Capabilities_KnowledgeBase = this.Capabilities_KnowledgeBase;
            context.Capabilities_PerformFlowUiTask = this.Capabilities_PerformFlowUiTask;
            context.Capabilities_PrintReport = this.Capabilities_PrintReport;
            context.Capabilities_PublishWithoutApproval = this.Capabilities_PublishWithoutApproval;
            context.Capabilities_RenameSharedFolder = this.Capabilities_RenameSharedFolder;
            context.Capabilities_Research = this.Capabilities_Research;
            context.Capabilities_SelfUpgradeUserRole = this.Capabilities_SelfUpgradeUserRole;
            context.Capabilities_ShareAnalyses = this.Capabilities_ShareAnalyses;
            context.Capabilities_ShareDashboard = this.Capabilities_ShareDashboard;
            context.Capabilities_ShareDataset = this.Capabilities_ShareDataset;
            context.Capabilities_ShareDataSource = this.Capabilities_ShareDataSource;
            context.Capabilities_Space = this.Capabilities_Space;
            context.Capabilities_SubscribeDashboardEmailReport = this.Capabilities_SubscribeDashboardEmailReport;
            context.Capabilities_UseAgentWebSearch = this.Capabilities_UseAgentWebSearch;
            context.Capabilities_UseBedrockModel = this.Capabilities_UseBedrockModel;
            context.Capabilities_ViewAccountSPICECapacity = this.Capabilities_ViewAccountSPICECapacity;
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
                #if DESKTOP
                return client.CreateCustomPermissions(request);
                #elif CORECLR
                return client.CreateCustomPermissionsAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public Amazon.QuickSight.CapabilityState Capabilities_Analysis { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_Automate { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ChatAgent { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateDashboardEmailReport { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateDataset { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateDataSource { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateTheme { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_CreateAndUpdateThresholdAlert { get; set; }
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
            public Amazon.QuickSight.CapabilityState Capabilities_Flow { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_IncludeContentInScheduledReportsEmail { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_KnowledgeBase { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_PerformFlowUiTask { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_PrintReport { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_PublishWithoutApproval { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_RenameSharedFolder { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_Research { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_SelfUpgradeUserRole { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareAnalyses { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareDashboard { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareDataset { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ShareDataSource { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_Space { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_SubscribeDashboardEmailReport { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseAgentWebSearch { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_UseBedrockModel { get; set; }
            public Amazon.QuickSight.CapabilityState Capabilities_ViewAccountSPICECapacity { get; set; }
            public System.String CustomPermissionsName { get; set; }
            public List<Amazon.QuickSight.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.QuickSight.Model.CreateCustomPermissionsResponse, NewQSCustomPermissionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Arn;
        }
        
    }
}
