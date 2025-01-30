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
using Amazon.CustomerProfiles;
using Amazon.CustomerProfiles.Model;

namespace Amazon.PowerShell.Cmdlets.CPF
{
    /// <summary>
    /// Creates an integration workflow. An integration workflow is an async process which
    /// ingests historic data and sets up an integration for ongoing updates. The supported
    /// Amazon AppFlow sources are Salesforce, ServiceNow, and Marketo.
    /// </summary>
    [Cmdlet("New", "CPFIntegrationWorkflow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CustomerProfiles.Model.CreateIntegrationWorkflowResponse")]
    [AWSCmdlet("Calls the Amazon Connect Customer Profiles CreateIntegrationWorkflow API operation.", Operation = new[] {"CreateIntegrationWorkflow"}, SelectReturnType = typeof(Amazon.CustomerProfiles.Model.CreateIntegrationWorkflowResponse))]
    [AWSCmdletOutput("Amazon.CustomerProfiles.Model.CreateIntegrationWorkflowResponse",
        "This cmdlet returns an Amazon.CustomerProfiles.Model.CreateIntegrationWorkflowResponse object containing multiple properties."
    )]
    public partial class NewCPFIntegrationWorkflowCmdlet : AmazonCustomerProfilesClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppflowIntegration_Batch
        /// <summary>
        /// <para>
        /// <para>Batches in workflow of type <c>APPFLOW_INTEGRATION</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_Batches")]
        public Amazon.CustomerProfiles.Model.Batch[] AppflowIntegration_Batch { get; set; }
        #endregion
        
        #region Parameter S3_BucketName
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket name where the source files are stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3_BucketName")]
        public System.String S3_BucketName { get; set; }
        #endregion
        
        #region Parameter S3_BucketPrefix
        /// <summary>
        /// <para>
        /// <para>The object key for the Amazon S3 bucket in which the source files are stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3_BucketPrefix")]
        public System.String S3_BucketPrefix { get; set; }
        #endregion
        
        #region Parameter SourceFlowConfig_ConnectorProfileName
        /// <summary>
        /// <para>
        /// <para>The name of the AppFlow connector profile. This name must be unique for each connector
        /// profile in the AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_ConnectorProfileName")]
        public System.String SourceFlowConfig_ConnectorProfileName { get; set; }
        #endregion
        
        #region Parameter SourceFlowConfig_ConnectorType
        /// <summary>
        /// <para>
        /// <para>The type of connector, such as Salesforce, Marketo, and so on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_ConnectorType")]
        [AWSConstantClassSource("Amazon.CustomerProfiles.SourceConnectorType")]
        public Amazon.CustomerProfiles.SourceConnectorType SourceFlowConfig_ConnectorType { get; set; }
        #endregion
        
        #region Parameter Scheduled_DataPullMode
        /// <summary>
        /// <para>
        /// <para>Specifies whether a scheduled flow has an incremental data transfer or a complete
        /// data transfer for each flow run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_DataPullMode")]
        [AWSConstantClassSource("Amazon.CustomerProfiles.DataPullMode")]
        public Amazon.CustomerProfiles.DataPullMode Scheduled_DataPullMode { get; set; }
        #endregion
        
        #region Parameter IncrementalPullConfig_DatetimeTypeFieldName
        /// <summary>
        /// <para>
        /// <para>A field that specifies the date time or timestamp field as the criteria to use when
        /// importing incremental records from the source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_IncrementalPullConfig_DatetimeTypeFieldName")]
        public System.String IncrementalPullConfig_DatetimeTypeFieldName { get; set; }
        #endregion
        
        #region Parameter FlowDefinition_Description
        /// <summary>
        /// <para>
        /// <para>A description of the flow you want to create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_FlowDefinition_Description")]
        public System.String FlowDefinition_Description { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The unique name of the domain.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter Salesforce_EnableDynamicFieldUpdate
        /// <summary>
        /// <para>
        /// <para>The flag that enables dynamic fetching of new (recently added) fields in the Salesforce
        /// objects while running a flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_EnableDynamicFieldUpdate")]
        public System.Boolean? Salesforce_EnableDynamicFieldUpdate { get; set; }
        #endregion
        
        #region Parameter Scheduled_FirstExecutionFrom
        /// <summary>
        /// <para>
        /// <para>Specifies the date range for the records to import from the connector in the first
        /// flow run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_FirstExecutionFrom")]
        public System.DateTime? Scheduled_FirstExecutionFrom { get; set; }
        #endregion
        
        #region Parameter FlowDefinition_FlowName
        /// <summary>
        /// <para>
        /// <para>The specified name of the flow. Use underscores (_) or hyphens (-) only. Spaces are
        /// not allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_FlowDefinition_FlowName")]
        public System.String FlowDefinition_FlowName { get; set; }
        #endregion
        
        #region Parameter Salesforce_IncludeDeletedRecord
        /// <summary>
        /// <para>
        /// <para>Indicates whether Amazon AppFlow includes deleted files in the flow run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_IncludeDeletedRecords")]
        public System.Boolean? Salesforce_IncludeDeletedRecord { get; set; }
        #endregion
        
        #region Parameter FlowDefinition_KmsArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name of the AWS Key Management Service (KMS) key you provide for
        /// encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_FlowDefinition_KmsArn")]
        public System.String FlowDefinition_KmsArn { get; set; }
        #endregion
        
        #region Parameter Marketo_Object
        /// <summary>
        /// <para>
        /// <para>The object specified in the Marketo flow source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo_Object")]
        public System.String Marketo_Object { get; set; }
        #endregion
        
        #region Parameter Salesforce_Object
        /// <summary>
        /// <para>
        /// <para>The object specified in the Salesforce flow source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_Object")]
        public System.String Salesforce_Object { get; set; }
        #endregion
        
        #region Parameter ServiceNow_Object
        /// <summary>
        /// <para>
        /// <para>The object specified in the ServiceNow flow source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow_Object")]
        public System.String ServiceNow_Object { get; set; }
        #endregion
        
        #region Parameter Zendesk_Object
        /// <summary>
        /// <para>
        /// <para>The object specified in the Zendesk flow source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk_Object")]
        public System.String Zendesk_Object { get; set; }
        #endregion
        
        #region Parameter ObjectTypeName
        /// <summary>
        /// <para>
        /// <para>The name of the profile object type.</para>
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
        public System.String ObjectTypeName { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role. Customer Profiles assumes this role
        /// to create resources on your behalf as part of workflow execution.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Scheduled_ScheduleEndTime
        /// <summary>
        /// <para>
        /// <para>Specifies the scheduled end time for a scheduled-trigger flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_ScheduleEndTime")]
        public System.DateTime? Scheduled_ScheduleEndTime { get; set; }
        #endregion
        
        #region Parameter Scheduled_ScheduleExpression
        /// <summary>
        /// <para>
        /// <para>The scheduling expression that determines the rate at which the schedule will run,
        /// for example rate (5 minutes).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_ScheduleExpression")]
        public System.String Scheduled_ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter Scheduled_ScheduleOffset
        /// <summary>
        /// <para>
        /// <para>Specifies the optional offset that is added to the time interval for a schedule-triggered
        /// flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_ScheduleOffset")]
        public System.Int64? Scheduled_ScheduleOffset { get; set; }
        #endregion
        
        #region Parameter Scheduled_ScheduleStartTime
        /// <summary>
        /// <para>
        /// <para>Specifies the scheduled start time for a scheduled-trigger flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_ScheduleStartTime")]
        public System.DateTime? Scheduled_ScheduleStartTime { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter FlowDefinition_Task
        /// <summary>
        /// <para>
        /// <para>A list of tasks that Customer Profiles performs while transferring the data in the
        /// flow run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_FlowDefinition_Tasks")]
        public Amazon.CustomerProfiles.Model.Task[] FlowDefinition_Task { get; set; }
        #endregion
        
        #region Parameter Scheduled_Timezone
        /// <summary>
        /// <para>
        /// <para>Specifies the time zone used when referring to the date and time of a scheduled-triggered
        /// flow, such as America/New_York.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_Timezone")]
        public System.String Scheduled_Timezone { get; set; }
        #endregion
        
        #region Parameter TriggerConfig_TriggerType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of flow trigger. It can be OnDemand, Scheduled, or Event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IntegrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerType")]
        [AWSConstantClassSource("Amazon.CustomerProfiles.TriggerType")]
        public Amazon.CustomerProfiles.TriggerType TriggerConfig_TriggerType { get; set; }
        #endregion
        
        #region Parameter WorkflowType
        /// <summary>
        /// <para>
        /// <para>The type of workflow. The only supported value is APPFLOW_INTEGRATION.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CustomerProfiles.WorkflowType")]
        public Amazon.CustomerProfiles.WorkflowType WorkflowType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CustomerProfiles.Model.CreateIntegrationWorkflowResponse).
        /// Specifying the name of a property of type Amazon.CustomerProfiles.Model.CreateIntegrationWorkflowResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CPFIntegrationWorkflow (CreateIntegrationWorkflow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CustomerProfiles.Model.CreateIntegrationWorkflowResponse, NewCPFIntegrationWorkflowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AppflowIntegration_Batch != null)
            {
                context.AppflowIntegration_Batch = new List<Amazon.CustomerProfiles.Model.Batch>(this.AppflowIntegration_Batch);
            }
            context.FlowDefinition_Description = this.FlowDefinition_Description;
            context.FlowDefinition_FlowName = this.FlowDefinition_FlowName;
            context.FlowDefinition_KmsArn = this.FlowDefinition_KmsArn;
            context.SourceFlowConfig_ConnectorProfileName = this.SourceFlowConfig_ConnectorProfileName;
            context.SourceFlowConfig_ConnectorType = this.SourceFlowConfig_ConnectorType;
            context.IncrementalPullConfig_DatetimeTypeFieldName = this.IncrementalPullConfig_DatetimeTypeFieldName;
            context.Marketo_Object = this.Marketo_Object;
            context.S3_BucketName = this.S3_BucketName;
            context.S3_BucketPrefix = this.S3_BucketPrefix;
            context.Salesforce_EnableDynamicFieldUpdate = this.Salesforce_EnableDynamicFieldUpdate;
            context.Salesforce_IncludeDeletedRecord = this.Salesforce_IncludeDeletedRecord;
            context.Salesforce_Object = this.Salesforce_Object;
            context.ServiceNow_Object = this.ServiceNow_Object;
            context.Zendesk_Object = this.Zendesk_Object;
            if (this.FlowDefinition_Task != null)
            {
                context.FlowDefinition_Task = new List<Amazon.CustomerProfiles.Model.Task>(this.FlowDefinition_Task);
            }
            context.Scheduled_DataPullMode = this.Scheduled_DataPullMode;
            context.Scheduled_FirstExecutionFrom = this.Scheduled_FirstExecutionFrom;
            context.Scheduled_ScheduleEndTime = this.Scheduled_ScheduleEndTime;
            context.Scheduled_ScheduleExpression = this.Scheduled_ScheduleExpression;
            context.Scheduled_ScheduleOffset = this.Scheduled_ScheduleOffset;
            context.Scheduled_ScheduleStartTime = this.Scheduled_ScheduleStartTime;
            context.Scheduled_Timezone = this.Scheduled_Timezone;
            context.TriggerConfig_TriggerType = this.TriggerConfig_TriggerType;
            context.ObjectTypeName = this.ObjectTypeName;
            #if MODULAR
            if (this.ObjectTypeName == null && ParameterWasBound(nameof(this.ObjectTypeName)))
            {
                WriteWarning("You are passing $null as a value for parameter ObjectTypeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.WorkflowType = this.WorkflowType;
            #if MODULAR
            if (this.WorkflowType == null && ParameterWasBound(nameof(this.WorkflowType)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.CustomerProfiles.Model.CreateIntegrationWorkflowRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
             // populate IntegrationConfig
            var requestIntegrationConfigIsNull = true;
            request.IntegrationConfig = new Amazon.CustomerProfiles.Model.IntegrationConfig();
            Amazon.CustomerProfiles.Model.AppflowIntegration requestIntegrationConfig_integrationConfig_AppflowIntegration = null;
            
             // populate AppflowIntegration
            var requestIntegrationConfig_integrationConfig_AppflowIntegrationIsNull = true;
            requestIntegrationConfig_integrationConfig_AppflowIntegration = new Amazon.CustomerProfiles.Model.AppflowIntegration();
            List<Amazon.CustomerProfiles.Model.Batch> requestIntegrationConfig_integrationConfig_AppflowIntegration_appflowIntegration_Batch = null;
            if (cmdletContext.AppflowIntegration_Batch != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_appflowIntegration_Batch = cmdletContext.AppflowIntegration_Batch;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_appflowIntegration_Batch != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration.Batches = requestIntegrationConfig_integrationConfig_AppflowIntegration_appflowIntegration_Batch;
                requestIntegrationConfig_integrationConfig_AppflowIntegrationIsNull = false;
            }
            Amazon.CustomerProfiles.Model.FlowDefinition requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition = null;
            
             // populate FlowDefinition
            var requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinitionIsNull = true;
            requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition = new Amazon.CustomerProfiles.Model.FlowDefinition();
            System.String requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_flowDefinition_Description = null;
            if (cmdletContext.FlowDefinition_Description != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_flowDefinition_Description = cmdletContext.FlowDefinition_Description;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_flowDefinition_Description != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition.Description = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_flowDefinition_Description;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinitionIsNull = false;
            }
            System.String requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_flowDefinition_FlowName = null;
            if (cmdletContext.FlowDefinition_FlowName != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_flowDefinition_FlowName = cmdletContext.FlowDefinition_FlowName;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_flowDefinition_FlowName != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition.FlowName = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_flowDefinition_FlowName;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinitionIsNull = false;
            }
            System.String requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_flowDefinition_KmsArn = null;
            if (cmdletContext.FlowDefinition_KmsArn != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_flowDefinition_KmsArn = cmdletContext.FlowDefinition_KmsArn;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_flowDefinition_KmsArn != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition.KmsArn = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_flowDefinition_KmsArn;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinitionIsNull = false;
            }
            List<Amazon.CustomerProfiles.Model.Task> requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_flowDefinition_Task = null;
            if (cmdletContext.FlowDefinition_Task != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_flowDefinition_Task = cmdletContext.FlowDefinition_Task;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_flowDefinition_Task != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition.Tasks = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_flowDefinition_Task;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinitionIsNull = false;
            }
            Amazon.CustomerProfiles.Model.TriggerConfig requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig = null;
            
             // populate TriggerConfig
            var requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfigIsNull = true;
            requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig = new Amazon.CustomerProfiles.Model.TriggerConfig();
            Amazon.CustomerProfiles.TriggerType requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_triggerConfig_TriggerType = null;
            if (cmdletContext.TriggerConfig_TriggerType != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_triggerConfig_TriggerType = cmdletContext.TriggerConfig_TriggerType;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_triggerConfig_TriggerType != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig.TriggerType = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_triggerConfig_TriggerType;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfigIsNull = false;
            }
            Amazon.CustomerProfiles.Model.TriggerProperties requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties = null;
            
             // populate TriggerProperties
            var requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerPropertiesIsNull = true;
            requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties = new Amazon.CustomerProfiles.Model.TriggerProperties();
            Amazon.CustomerProfiles.Model.ScheduledTriggerProperties requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled = null;
            
             // populate Scheduled
            var requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_ScheduledIsNull = true;
            requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled = new Amazon.CustomerProfiles.Model.ScheduledTriggerProperties();
            Amazon.CustomerProfiles.DataPullMode requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_DataPullMode = null;
            if (cmdletContext.Scheduled_DataPullMode != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_DataPullMode = cmdletContext.Scheduled_DataPullMode;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_DataPullMode != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled.DataPullMode = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_DataPullMode;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_ScheduledIsNull = false;
            }
            System.DateTime? requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_FirstExecutionFrom = null;
            if (cmdletContext.Scheduled_FirstExecutionFrom != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_FirstExecutionFrom = cmdletContext.Scheduled_FirstExecutionFrom.Value;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_FirstExecutionFrom != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled.FirstExecutionFrom = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_FirstExecutionFrom.Value;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_ScheduledIsNull = false;
            }
            System.DateTime? requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleEndTime = null;
            if (cmdletContext.Scheduled_ScheduleEndTime != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleEndTime = cmdletContext.Scheduled_ScheduleEndTime.Value;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleEndTime != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled.ScheduleEndTime = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleEndTime.Value;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_ScheduledIsNull = false;
            }
            System.String requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleExpression = null;
            if (cmdletContext.Scheduled_ScheduleExpression != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleExpression = cmdletContext.Scheduled_ScheduleExpression;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleExpression != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled.ScheduleExpression = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleExpression;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_ScheduledIsNull = false;
            }
            System.Int64? requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleOffset = null;
            if (cmdletContext.Scheduled_ScheduleOffset != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleOffset = cmdletContext.Scheduled_ScheduleOffset.Value;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleOffset != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled.ScheduleOffset = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleOffset.Value;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_ScheduledIsNull = false;
            }
            System.DateTime? requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleStartTime = null;
            if (cmdletContext.Scheduled_ScheduleStartTime != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleStartTime = cmdletContext.Scheduled_ScheduleStartTime.Value;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleStartTime != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled.ScheduleStartTime = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleStartTime.Value;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_ScheduledIsNull = false;
            }
            System.String requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_Timezone = null;
            if (cmdletContext.Scheduled_Timezone != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_Timezone = cmdletContext.Scheduled_Timezone;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_Timezone != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled.Timezone = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_Timezone;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_ScheduledIsNull = false;
            }
             // determine if requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled should be set to null
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_ScheduledIsNull)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled = null;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties.Scheduled = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties_Scheduled;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerPropertiesIsNull = false;
            }
             // determine if requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties should be set to null
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerPropertiesIsNull)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties = null;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig.TriggerProperties = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig_TriggerProperties;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfigIsNull = false;
            }
             // determine if requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig should be set to null
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfigIsNull)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig = null;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition.TriggerConfig = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_TriggerConfig;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinitionIsNull = false;
            }
            Amazon.CustomerProfiles.Model.SourceFlowConfig requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig = null;
            
             // populate SourceFlowConfig
            var requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfigIsNull = true;
            requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig = new Amazon.CustomerProfiles.Model.SourceFlowConfig();
            System.String requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_sourceFlowConfig_ConnectorProfileName = null;
            if (cmdletContext.SourceFlowConfig_ConnectorProfileName != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_sourceFlowConfig_ConnectorProfileName = cmdletContext.SourceFlowConfig_ConnectorProfileName;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_sourceFlowConfig_ConnectorProfileName != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig.ConnectorProfileName = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_sourceFlowConfig_ConnectorProfileName;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfigIsNull = false;
            }
            Amazon.CustomerProfiles.SourceConnectorType requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_sourceFlowConfig_ConnectorType = null;
            if (cmdletContext.SourceFlowConfig_ConnectorType != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_sourceFlowConfig_ConnectorType = cmdletContext.SourceFlowConfig_ConnectorType;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_sourceFlowConfig_ConnectorType != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig.ConnectorType = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_sourceFlowConfig_ConnectorType;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfigIsNull = false;
            }
            Amazon.CustomerProfiles.Model.IncrementalPullConfig requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_IncrementalPullConfig = null;
            
             // populate IncrementalPullConfig
            var requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_IncrementalPullConfigIsNull = true;
            requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_IncrementalPullConfig = new Amazon.CustomerProfiles.Model.IncrementalPullConfig();
            System.String requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_IncrementalPullConfig_incrementalPullConfig_DatetimeTypeFieldName = null;
            if (cmdletContext.IncrementalPullConfig_DatetimeTypeFieldName != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_IncrementalPullConfig_incrementalPullConfig_DatetimeTypeFieldName = cmdletContext.IncrementalPullConfig_DatetimeTypeFieldName;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_IncrementalPullConfig_incrementalPullConfig_DatetimeTypeFieldName != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_IncrementalPullConfig.DatetimeTypeFieldName = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_IncrementalPullConfig_incrementalPullConfig_DatetimeTypeFieldName;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_IncrementalPullConfigIsNull = false;
            }
             // determine if requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_IncrementalPullConfig should be set to null
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_IncrementalPullConfigIsNull)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_IncrementalPullConfig = null;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_IncrementalPullConfig != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig.IncrementalPullConfig = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_IncrementalPullConfig;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfigIsNull = false;
            }
            Amazon.CustomerProfiles.Model.SourceConnectorProperties requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties = null;
            
             // populate SourceConnectorProperties
            var requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorPropertiesIsNull = true;
            requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties = new Amazon.CustomerProfiles.Model.SourceConnectorProperties();
            Amazon.CustomerProfiles.Model.MarketoSourceProperties requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo = null;
            
             // populate Marketo
            var requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_MarketoIsNull = true;
            requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo = new Amazon.CustomerProfiles.Model.MarketoSourceProperties();
            System.String requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo_marketo_Object = null;
            if (cmdletContext.Marketo_Object != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo_marketo_Object = cmdletContext.Marketo_Object;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo_marketo_Object != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo.Object = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo_marketo_Object;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_MarketoIsNull = false;
            }
             // determine if requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo should be set to null
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_MarketoIsNull)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo = null;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties.Marketo = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
            Amazon.CustomerProfiles.Model.ServiceNowSourceProperties requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow = null;
            
             // populate ServiceNow
            var requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNowIsNull = true;
            requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow = new Amazon.CustomerProfiles.Model.ServiceNowSourceProperties();
            System.String requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow_serviceNow_Object = null;
            if (cmdletContext.ServiceNow_Object != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow_serviceNow_Object = cmdletContext.ServiceNow_Object;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow_serviceNow_Object != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow.Object = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow_serviceNow_Object;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNowIsNull = false;
            }
             // determine if requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow should be set to null
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNowIsNull)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow = null;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties.ServiceNow = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
            Amazon.CustomerProfiles.Model.ZendeskSourceProperties requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk = null;
            
             // populate Zendesk
            var requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_ZendeskIsNull = true;
            requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk = new Amazon.CustomerProfiles.Model.ZendeskSourceProperties();
            System.String requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk_zendesk_Object = null;
            if (cmdletContext.Zendesk_Object != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk_zendesk_Object = cmdletContext.Zendesk_Object;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk_zendesk_Object != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk.Object = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk_zendesk_Object;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_ZendeskIsNull = false;
            }
             // determine if requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk should be set to null
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_ZendeskIsNull)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk = null;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties.Zendesk = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
            Amazon.CustomerProfiles.Model.S3SourceProperties requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3 = null;
            
             // populate S3
            var requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3IsNull = true;
            requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3 = new Amazon.CustomerProfiles.Model.S3SourceProperties();
            System.String requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3_s3_BucketName = null;
            if (cmdletContext.S3_BucketName != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3_s3_BucketName = cmdletContext.S3_BucketName;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3_s3_BucketName != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3.BucketName = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3_s3_BucketName;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3IsNull = false;
            }
            System.String requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3_s3_BucketPrefix = null;
            if (cmdletContext.S3_BucketPrefix != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3_s3_BucketPrefix = cmdletContext.S3_BucketPrefix;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3_s3_BucketPrefix != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3.BucketPrefix = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3_s3_BucketPrefix;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3IsNull = false;
            }
             // determine if requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3 should be set to null
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3IsNull)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3 = null;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3 != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties.S3 = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
            Amazon.CustomerProfiles.Model.SalesforceSourceProperties requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce = null;
            
             // populate Salesforce
            var requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_SalesforceIsNull = true;
            requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce = new Amazon.CustomerProfiles.Model.SalesforceSourceProperties();
            System.Boolean? requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_EnableDynamicFieldUpdate = null;
            if (cmdletContext.Salesforce_EnableDynamicFieldUpdate != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_EnableDynamicFieldUpdate = cmdletContext.Salesforce_EnableDynamicFieldUpdate.Value;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_EnableDynamicFieldUpdate != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce.EnableDynamicFieldUpdate = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_EnableDynamicFieldUpdate.Value;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_SalesforceIsNull = false;
            }
            System.Boolean? requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_IncludeDeletedRecord = null;
            if (cmdletContext.Salesforce_IncludeDeletedRecord != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_IncludeDeletedRecord = cmdletContext.Salesforce_IncludeDeletedRecord.Value;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_IncludeDeletedRecord != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce.IncludeDeletedRecords = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_IncludeDeletedRecord.Value;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_SalesforceIsNull = false;
            }
            System.String requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_Object = null;
            if (cmdletContext.Salesforce_Object != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_Object = cmdletContext.Salesforce_Object;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_Object != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce.Object = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_Object;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_SalesforceIsNull = false;
            }
             // determine if requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce should be set to null
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_SalesforceIsNull)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce = null;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties.Salesforce = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
             // determine if requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties should be set to null
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorPropertiesIsNull)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties = null;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig.SourceConnectorProperties = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig_SourceConnectorProperties;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfigIsNull = false;
            }
             // determine if requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig should be set to null
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfigIsNull)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig = null;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition.SourceFlowConfig = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition_integrationConfig_AppflowIntegration_FlowDefinition_SourceFlowConfig;
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinitionIsNull = false;
            }
             // determine if requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition should be set to null
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinitionIsNull)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition = null;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition != null)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration.FlowDefinition = requestIntegrationConfig_integrationConfig_AppflowIntegration_integrationConfig_AppflowIntegration_FlowDefinition;
                requestIntegrationConfig_integrationConfig_AppflowIntegrationIsNull = false;
            }
             // determine if requestIntegrationConfig_integrationConfig_AppflowIntegration should be set to null
            if (requestIntegrationConfig_integrationConfig_AppflowIntegrationIsNull)
            {
                requestIntegrationConfig_integrationConfig_AppflowIntegration = null;
            }
            if (requestIntegrationConfig_integrationConfig_AppflowIntegration != null)
            {
                request.IntegrationConfig.AppflowIntegration = requestIntegrationConfig_integrationConfig_AppflowIntegration;
                requestIntegrationConfigIsNull = false;
            }
             // determine if request.IntegrationConfig should be set to null
            if (requestIntegrationConfigIsNull)
            {
                request.IntegrationConfig = null;
            }
            if (cmdletContext.ObjectTypeName != null)
            {
                request.ObjectTypeName = cmdletContext.ObjectTypeName;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.WorkflowType != null)
            {
                request.WorkflowType = cmdletContext.WorkflowType;
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
        
        private Amazon.CustomerProfiles.Model.CreateIntegrationWorkflowResponse CallAWSServiceOperation(IAmazonCustomerProfiles client, Amazon.CustomerProfiles.Model.CreateIntegrationWorkflowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Customer Profiles", "CreateIntegrationWorkflow");
            try
            {
                #if DESKTOP
                return client.CreateIntegrationWorkflow(request);
                #elif CORECLR
                return client.CreateIntegrationWorkflowAsync(request).GetAwaiter().GetResult();
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
            public System.String DomainName { get; set; }
            public List<Amazon.CustomerProfiles.Model.Batch> AppflowIntegration_Batch { get; set; }
            public System.String FlowDefinition_Description { get; set; }
            public System.String FlowDefinition_FlowName { get; set; }
            public System.String FlowDefinition_KmsArn { get; set; }
            public System.String SourceFlowConfig_ConnectorProfileName { get; set; }
            public Amazon.CustomerProfiles.SourceConnectorType SourceFlowConfig_ConnectorType { get; set; }
            public System.String IncrementalPullConfig_DatetimeTypeFieldName { get; set; }
            public System.String Marketo_Object { get; set; }
            public System.String S3_BucketName { get; set; }
            public System.String S3_BucketPrefix { get; set; }
            public System.Boolean? Salesforce_EnableDynamicFieldUpdate { get; set; }
            public System.Boolean? Salesforce_IncludeDeletedRecord { get; set; }
            public System.String Salesforce_Object { get; set; }
            public System.String ServiceNow_Object { get; set; }
            public System.String Zendesk_Object { get; set; }
            public List<Amazon.CustomerProfiles.Model.Task> FlowDefinition_Task { get; set; }
            public Amazon.CustomerProfiles.DataPullMode Scheduled_DataPullMode { get; set; }
            public System.DateTime? Scheduled_FirstExecutionFrom { get; set; }
            public System.DateTime? Scheduled_ScheduleEndTime { get; set; }
            public System.String Scheduled_ScheduleExpression { get; set; }
            public System.Int64? Scheduled_ScheduleOffset { get; set; }
            public System.DateTime? Scheduled_ScheduleStartTime { get; set; }
            public System.String Scheduled_Timezone { get; set; }
            public Amazon.CustomerProfiles.TriggerType TriggerConfig_TriggerType { get; set; }
            public System.String ObjectTypeName { get; set; }
            public System.String RoleArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.CustomerProfiles.WorkflowType WorkflowType { get; set; }
            public System.Func<Amazon.CustomerProfiles.Model.CreateIntegrationWorkflowResponse, NewCPFIntegrationWorkflowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
