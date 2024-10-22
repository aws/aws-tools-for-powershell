/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Adds an integration between the service and a third-party service, which includes
    /// Amazon AppFlow and Amazon Connect.
    /// 
    ///  
    /// <para>
    /// An integration can belong to only one domain.
    /// </para><para>
    /// To add or remove tags on an existing Integration, see <a href="https://docs.aws.amazon.com/customerprofiles/latest/APIReference/API_TagResource.html">
    /// TagResource </a>/<a href="https://docs.aws.amazon.com/customerprofiles/latest/APIReference/API_UntagResource.html">
    /// UntagResource</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CPFIntegration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CustomerProfiles.Model.PutIntegrationResponse")]
    [AWSCmdlet("Calls the Amazon Connect Customer Profiles PutIntegration API operation.", Operation = new[] {"PutIntegration"}, SelectReturnType = typeof(Amazon.CustomerProfiles.Model.PutIntegrationResponse))]
    [AWSCmdletOutput("Amazon.CustomerProfiles.Model.PutIntegrationResponse",
        "This cmdlet returns an Amazon.CustomerProfiles.Model.PutIntegrationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCPFIntegrationCmdlet : AmazonCustomerProfilesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3_BucketName
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket name where the source files are stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3_BucketName")]
        public System.String S3_BucketName { get; set; }
        #endregion
        
        #region Parameter S3_BucketPrefix
        /// <summary>
        /// <para>
        /// <para>The object key for the Amazon S3 bucket in which the source files are stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FlowDefinition_SourceFlowConfig_SourceConnectorProperties_S3_BucketPrefix")]
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
        [Alias("FlowDefinition_SourceFlowConfig_ConnectorProfileName")]
        public System.String SourceFlowConfig_ConnectorProfileName { get; set; }
        #endregion
        
        #region Parameter SourceFlowConfig_ConnectorType
        /// <summary>
        /// <para>
        /// <para>The type of connector, such as Salesforce, Marketo, and so on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FlowDefinition_SourceFlowConfig_ConnectorType")]
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
        [Alias("FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_DataPullMode")]
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
        [Alias("FlowDefinition_SourceFlowConfig_IncrementalPullConfig_DatetimeTypeFieldName")]
        public System.String IncrementalPullConfig_DatetimeTypeFieldName { get; set; }
        #endregion
        
        #region Parameter FlowDefinition_Description
        /// <summary>
        /// <para>
        /// <para>A description of the flow you want to create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [Alias("FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_EnableDynamicFieldUpdate")]
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
        [Alias("FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_FirstExecutionFrom")]
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
        public System.String FlowDefinition_FlowName { get; set; }
        #endregion
        
        #region Parameter Salesforce_IncludeDeletedRecord
        /// <summary>
        /// <para>
        /// <para>Indicates whether Amazon AppFlow includes deleted files in the flow run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_IncludeDeletedRecords")]
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
        public System.String FlowDefinition_KmsArn { get; set; }
        #endregion
        
        #region Parameter Marketo_Object
        /// <summary>
        /// <para>
        /// <para>The object specified in the Marketo flow source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo_Object")]
        public System.String Marketo_Object { get; set; }
        #endregion
        
        #region Parameter Salesforce_Object
        /// <summary>
        /// <para>
        /// <para>The object specified in the Salesforce flow source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_Object")]
        public System.String Salesforce_Object { get; set; }
        #endregion
        
        #region Parameter ServiceNow_Object
        /// <summary>
        /// <para>
        /// <para>The object specified in the ServiceNow flow source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FlowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow_Object")]
        public System.String ServiceNow_Object { get; set; }
        #endregion
        
        #region Parameter Zendesk_Object
        /// <summary>
        /// <para>
        /// <para>The object specified in the Zendesk flow source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FlowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk_Object")]
        public System.String Zendesk_Object { get; set; }
        #endregion
        
        #region Parameter ObjectTypeName
        /// <summary>
        /// <para>
        /// <para>The name of the profile object type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ObjectTypeName { get; set; }
        #endregion
        
        #region Parameter ObjectTypeNames
        /// <summary>
        /// <para>
        /// <para>A map in which each key is an event type from an external application such as Segment
        /// or Shopify, and each value is an <c>ObjectTypeName</c> (template) used to ingest the
        /// event. It supports the following event types: <c>SegmentIdentify</c>, <c>ShopifyCreateCustomers</c>,
        /// <c>ShopifyUpdateCustomers</c>, <c>ShopifyCreateDraftOrders</c>, <c>ShopifyUpdateDraftOrders</c>,
        /// <c>ShopifyCreateOrders</c>, and <c>ShopifyUpdatedOrders</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ObjectTypeNames { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role. The Integration uses this role to
        /// make Customer Profiles requests on your behalf.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Scheduled_ScheduleEndTime
        /// <summary>
        /// <para>
        /// <para>Specifies the scheduled end time for a scheduled-trigger flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_ScheduleEndTime")]
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
        [Alias("FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_ScheduleExpression")]
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
        [Alias("FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_ScheduleOffset")]
        public System.Int64? Scheduled_ScheduleOffset { get; set; }
        #endregion
        
        #region Parameter Scheduled_ScheduleStartTime
        /// <summary>
        /// <para>
        /// <para>Specifies the scheduled start time for a scheduled-trigger flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_ScheduleStartTime")]
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
        [Alias("FlowDefinition_Tasks")]
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
        [Alias("FlowDefinition_TriggerConfig_TriggerProperties_Scheduled_Timezone")]
        public System.String Scheduled_Timezone { get; set; }
        #endregion
        
        #region Parameter TriggerConfig_TriggerType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of flow trigger. It can be OnDemand, Scheduled, or Event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FlowDefinition_TriggerConfig_TriggerType")]
        [AWSConstantClassSource("Amazon.CustomerProfiles.TriggerType")]
        public Amazon.CustomerProfiles.TriggerType TriggerConfig_TriggerType { get; set; }
        #endregion
        
        #region Parameter Uri
        /// <summary>
        /// <para>
        /// <para>The URI of the S3 bucket or any other type of data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Uri { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CustomerProfiles.Model.PutIntegrationResponse).
        /// Specifying the name of a property of type Amazon.CustomerProfiles.Model.PutIntegrationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Uri), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CPFIntegration (PutIntegration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CustomerProfiles.Model.PutIntegrationResponse, WriteCPFIntegrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            if (this.ObjectTypeNames != null)
            {
                context.ObjectTypeNames = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ObjectTypeNames.Keys)
                {
                    context.ObjectTypeNames.Add((String)hashKey, (System.String)(this.ObjectTypeNames[hashKey]));
                }
            }
            context.RoleArn = this.RoleArn;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Uri = this.Uri;
            
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
            var request = new Amazon.CustomerProfiles.Model.PutIntegrationRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
             // populate FlowDefinition
            var requestFlowDefinitionIsNull = true;
            request.FlowDefinition = new Amazon.CustomerProfiles.Model.FlowDefinition();
            System.String requestFlowDefinition_flowDefinition_Description = null;
            if (cmdletContext.FlowDefinition_Description != null)
            {
                requestFlowDefinition_flowDefinition_Description = cmdletContext.FlowDefinition_Description;
            }
            if (requestFlowDefinition_flowDefinition_Description != null)
            {
                request.FlowDefinition.Description = requestFlowDefinition_flowDefinition_Description;
                requestFlowDefinitionIsNull = false;
            }
            System.String requestFlowDefinition_flowDefinition_FlowName = null;
            if (cmdletContext.FlowDefinition_FlowName != null)
            {
                requestFlowDefinition_flowDefinition_FlowName = cmdletContext.FlowDefinition_FlowName;
            }
            if (requestFlowDefinition_flowDefinition_FlowName != null)
            {
                request.FlowDefinition.FlowName = requestFlowDefinition_flowDefinition_FlowName;
                requestFlowDefinitionIsNull = false;
            }
            System.String requestFlowDefinition_flowDefinition_KmsArn = null;
            if (cmdletContext.FlowDefinition_KmsArn != null)
            {
                requestFlowDefinition_flowDefinition_KmsArn = cmdletContext.FlowDefinition_KmsArn;
            }
            if (requestFlowDefinition_flowDefinition_KmsArn != null)
            {
                request.FlowDefinition.KmsArn = requestFlowDefinition_flowDefinition_KmsArn;
                requestFlowDefinitionIsNull = false;
            }
            List<Amazon.CustomerProfiles.Model.Task> requestFlowDefinition_flowDefinition_Task = null;
            if (cmdletContext.FlowDefinition_Task != null)
            {
                requestFlowDefinition_flowDefinition_Task = cmdletContext.FlowDefinition_Task;
            }
            if (requestFlowDefinition_flowDefinition_Task != null)
            {
                request.FlowDefinition.Tasks = requestFlowDefinition_flowDefinition_Task;
                requestFlowDefinitionIsNull = false;
            }
            Amazon.CustomerProfiles.Model.TriggerConfig requestFlowDefinition_flowDefinition_TriggerConfig = null;
            
             // populate TriggerConfig
            var requestFlowDefinition_flowDefinition_TriggerConfigIsNull = true;
            requestFlowDefinition_flowDefinition_TriggerConfig = new Amazon.CustomerProfiles.Model.TriggerConfig();
            Amazon.CustomerProfiles.TriggerType requestFlowDefinition_flowDefinition_TriggerConfig_triggerConfig_TriggerType = null;
            if (cmdletContext.TriggerConfig_TriggerType != null)
            {
                requestFlowDefinition_flowDefinition_TriggerConfig_triggerConfig_TriggerType = cmdletContext.TriggerConfig_TriggerType;
            }
            if (requestFlowDefinition_flowDefinition_TriggerConfig_triggerConfig_TriggerType != null)
            {
                requestFlowDefinition_flowDefinition_TriggerConfig.TriggerType = requestFlowDefinition_flowDefinition_TriggerConfig_triggerConfig_TriggerType;
                requestFlowDefinition_flowDefinition_TriggerConfigIsNull = false;
            }
            Amazon.CustomerProfiles.Model.TriggerProperties requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties = null;
            
             // populate TriggerProperties
            var requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerPropertiesIsNull = true;
            requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties = new Amazon.CustomerProfiles.Model.TriggerProperties();
            Amazon.CustomerProfiles.Model.ScheduledTriggerProperties requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled = null;
            
             // populate Scheduled
            var requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_ScheduledIsNull = true;
            requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled = new Amazon.CustomerProfiles.Model.ScheduledTriggerProperties();
            Amazon.CustomerProfiles.DataPullMode requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_DataPullMode = null;
            if (cmdletContext.Scheduled_DataPullMode != null)
            {
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_DataPullMode = cmdletContext.Scheduled_DataPullMode;
            }
            if (requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_DataPullMode != null)
            {
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled.DataPullMode = requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_DataPullMode;
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_ScheduledIsNull = false;
            }
            System.DateTime? requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_FirstExecutionFrom = null;
            if (cmdletContext.Scheduled_FirstExecutionFrom != null)
            {
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_FirstExecutionFrom = cmdletContext.Scheduled_FirstExecutionFrom.Value;
            }
            if (requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_FirstExecutionFrom != null)
            {
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled.FirstExecutionFrom = requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_FirstExecutionFrom.Value;
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_ScheduledIsNull = false;
            }
            System.DateTime? requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleEndTime = null;
            if (cmdletContext.Scheduled_ScheduleEndTime != null)
            {
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleEndTime = cmdletContext.Scheduled_ScheduleEndTime.Value;
            }
            if (requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleEndTime != null)
            {
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled.ScheduleEndTime = requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleEndTime.Value;
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_ScheduledIsNull = false;
            }
            System.String requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleExpression = null;
            if (cmdletContext.Scheduled_ScheduleExpression != null)
            {
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleExpression = cmdletContext.Scheduled_ScheduleExpression;
            }
            if (requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleExpression != null)
            {
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled.ScheduleExpression = requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleExpression;
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_ScheduledIsNull = false;
            }
            System.Int64? requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleOffset = null;
            if (cmdletContext.Scheduled_ScheduleOffset != null)
            {
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleOffset = cmdletContext.Scheduled_ScheduleOffset.Value;
            }
            if (requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleOffset != null)
            {
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled.ScheduleOffset = requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleOffset.Value;
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_ScheduledIsNull = false;
            }
            System.DateTime? requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleStartTime = null;
            if (cmdletContext.Scheduled_ScheduleStartTime != null)
            {
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleStartTime = cmdletContext.Scheduled_ScheduleStartTime.Value;
            }
            if (requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleStartTime != null)
            {
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled.ScheduleStartTime = requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleStartTime.Value;
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_ScheduledIsNull = false;
            }
            System.String requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_Timezone = null;
            if (cmdletContext.Scheduled_Timezone != null)
            {
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_Timezone = cmdletContext.Scheduled_Timezone;
            }
            if (requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_Timezone != null)
            {
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled.Timezone = requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled_scheduled_Timezone;
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_ScheduledIsNull = false;
            }
             // determine if requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled should be set to null
            if (requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_ScheduledIsNull)
            {
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled = null;
            }
            if (requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled != null)
            {
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties.Scheduled = requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties_flowDefinition_TriggerConfig_TriggerProperties_Scheduled;
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerPropertiesIsNull = false;
            }
             // determine if requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties should be set to null
            if (requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerPropertiesIsNull)
            {
                requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties = null;
            }
            if (requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties != null)
            {
                requestFlowDefinition_flowDefinition_TriggerConfig.TriggerProperties = requestFlowDefinition_flowDefinition_TriggerConfig_flowDefinition_TriggerConfig_TriggerProperties;
                requestFlowDefinition_flowDefinition_TriggerConfigIsNull = false;
            }
             // determine if requestFlowDefinition_flowDefinition_TriggerConfig should be set to null
            if (requestFlowDefinition_flowDefinition_TriggerConfigIsNull)
            {
                requestFlowDefinition_flowDefinition_TriggerConfig = null;
            }
            if (requestFlowDefinition_flowDefinition_TriggerConfig != null)
            {
                request.FlowDefinition.TriggerConfig = requestFlowDefinition_flowDefinition_TriggerConfig;
                requestFlowDefinitionIsNull = false;
            }
            Amazon.CustomerProfiles.Model.SourceFlowConfig requestFlowDefinition_flowDefinition_SourceFlowConfig = null;
            
             // populate SourceFlowConfig
            var requestFlowDefinition_flowDefinition_SourceFlowConfigIsNull = true;
            requestFlowDefinition_flowDefinition_SourceFlowConfig = new Amazon.CustomerProfiles.Model.SourceFlowConfig();
            System.String requestFlowDefinition_flowDefinition_SourceFlowConfig_sourceFlowConfig_ConnectorProfileName = null;
            if (cmdletContext.SourceFlowConfig_ConnectorProfileName != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_sourceFlowConfig_ConnectorProfileName = cmdletContext.SourceFlowConfig_ConnectorProfileName;
            }
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_sourceFlowConfig_ConnectorProfileName != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig.ConnectorProfileName = requestFlowDefinition_flowDefinition_SourceFlowConfig_sourceFlowConfig_ConnectorProfileName;
                requestFlowDefinition_flowDefinition_SourceFlowConfigIsNull = false;
            }
            Amazon.CustomerProfiles.SourceConnectorType requestFlowDefinition_flowDefinition_SourceFlowConfig_sourceFlowConfig_ConnectorType = null;
            if (cmdletContext.SourceFlowConfig_ConnectorType != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_sourceFlowConfig_ConnectorType = cmdletContext.SourceFlowConfig_ConnectorType;
            }
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_sourceFlowConfig_ConnectorType != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig.ConnectorType = requestFlowDefinition_flowDefinition_SourceFlowConfig_sourceFlowConfig_ConnectorType;
                requestFlowDefinition_flowDefinition_SourceFlowConfigIsNull = false;
            }
            Amazon.CustomerProfiles.Model.IncrementalPullConfig requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_IncrementalPullConfig = null;
            
             // populate IncrementalPullConfig
            var requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_IncrementalPullConfigIsNull = true;
            requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_IncrementalPullConfig = new Amazon.CustomerProfiles.Model.IncrementalPullConfig();
            System.String requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_IncrementalPullConfig_incrementalPullConfig_DatetimeTypeFieldName = null;
            if (cmdletContext.IncrementalPullConfig_DatetimeTypeFieldName != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_IncrementalPullConfig_incrementalPullConfig_DatetimeTypeFieldName = cmdletContext.IncrementalPullConfig_DatetimeTypeFieldName;
            }
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_IncrementalPullConfig_incrementalPullConfig_DatetimeTypeFieldName != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_IncrementalPullConfig.DatetimeTypeFieldName = requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_IncrementalPullConfig_incrementalPullConfig_DatetimeTypeFieldName;
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_IncrementalPullConfigIsNull = false;
            }
             // determine if requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_IncrementalPullConfig should be set to null
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_IncrementalPullConfigIsNull)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_IncrementalPullConfig = null;
            }
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_IncrementalPullConfig != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig.IncrementalPullConfig = requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_IncrementalPullConfig;
                requestFlowDefinition_flowDefinition_SourceFlowConfigIsNull = false;
            }
            Amazon.CustomerProfiles.Model.SourceConnectorProperties requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties = null;
            
             // populate SourceConnectorProperties
            var requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorPropertiesIsNull = true;
            requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties = new Amazon.CustomerProfiles.Model.SourceConnectorProperties();
            Amazon.CustomerProfiles.Model.MarketoSourceProperties requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo = null;
            
             // populate Marketo
            var requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_MarketoIsNull = true;
            requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo = new Amazon.CustomerProfiles.Model.MarketoSourceProperties();
            System.String requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo_marketo_Object = null;
            if (cmdletContext.Marketo_Object != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo_marketo_Object = cmdletContext.Marketo_Object;
            }
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo_marketo_Object != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo.Object = requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo_marketo_Object;
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_MarketoIsNull = false;
            }
             // determine if requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo should be set to null
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_MarketoIsNull)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo = null;
            }
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties.Marketo = requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Marketo;
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
            Amazon.CustomerProfiles.Model.ServiceNowSourceProperties requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow = null;
            
             // populate ServiceNow
            var requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNowIsNull = true;
            requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow = new Amazon.CustomerProfiles.Model.ServiceNowSourceProperties();
            System.String requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow_serviceNow_Object = null;
            if (cmdletContext.ServiceNow_Object != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow_serviceNow_Object = cmdletContext.ServiceNow_Object;
            }
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow_serviceNow_Object != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow.Object = requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow_serviceNow_Object;
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNowIsNull = false;
            }
             // determine if requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow should be set to null
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNowIsNull)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow = null;
            }
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties.ServiceNow = requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_ServiceNow;
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
            Amazon.CustomerProfiles.Model.ZendeskSourceProperties requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk = null;
            
             // populate Zendesk
            var requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_ZendeskIsNull = true;
            requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk = new Amazon.CustomerProfiles.Model.ZendeskSourceProperties();
            System.String requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk_zendesk_Object = null;
            if (cmdletContext.Zendesk_Object != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk_zendesk_Object = cmdletContext.Zendesk_Object;
            }
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk_zendesk_Object != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk.Object = requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk_zendesk_Object;
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_ZendeskIsNull = false;
            }
             // determine if requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk should be set to null
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_ZendeskIsNull)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk = null;
            }
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties.Zendesk = requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Zendesk;
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
            Amazon.CustomerProfiles.Model.S3SourceProperties requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_S3 = null;
            
             // populate S3
            var requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_S3IsNull = true;
            requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_S3 = new Amazon.CustomerProfiles.Model.S3SourceProperties();
            System.String requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_S3_s3_BucketName = null;
            if (cmdletContext.S3_BucketName != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_S3_s3_BucketName = cmdletContext.S3_BucketName;
            }
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_S3_s3_BucketName != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_S3.BucketName = requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_S3_s3_BucketName;
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_S3IsNull = false;
            }
            System.String requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_S3_s3_BucketPrefix = null;
            if (cmdletContext.S3_BucketPrefix != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_S3_s3_BucketPrefix = cmdletContext.S3_BucketPrefix;
            }
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_S3_s3_BucketPrefix != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_S3.BucketPrefix = requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_S3_s3_BucketPrefix;
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_S3IsNull = false;
            }
             // determine if requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_S3 should be set to null
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_S3IsNull)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_S3 = null;
            }
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_S3 != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties.S3 = requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_S3;
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
            Amazon.CustomerProfiles.Model.SalesforceSourceProperties requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce = null;
            
             // populate Salesforce
            var requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_SalesforceIsNull = true;
            requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce = new Amazon.CustomerProfiles.Model.SalesforceSourceProperties();
            System.Boolean? requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_EnableDynamicFieldUpdate = null;
            if (cmdletContext.Salesforce_EnableDynamicFieldUpdate != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_EnableDynamicFieldUpdate = cmdletContext.Salesforce_EnableDynamicFieldUpdate.Value;
            }
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_EnableDynamicFieldUpdate != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce.EnableDynamicFieldUpdate = requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_EnableDynamicFieldUpdate.Value;
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_SalesforceIsNull = false;
            }
            System.Boolean? requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_IncludeDeletedRecord = null;
            if (cmdletContext.Salesforce_IncludeDeletedRecord != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_IncludeDeletedRecord = cmdletContext.Salesforce_IncludeDeletedRecord.Value;
            }
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_IncludeDeletedRecord != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce.IncludeDeletedRecords = requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_IncludeDeletedRecord.Value;
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_SalesforceIsNull = false;
            }
            System.String requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_Object = null;
            if (cmdletContext.Salesforce_Object != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_Object = cmdletContext.Salesforce_Object;
            }
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_Object != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce.Object = requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_Object;
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_SalesforceIsNull = false;
            }
             // determine if requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce should be set to null
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_SalesforceIsNull)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce = null;
            }
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties.Salesforce = requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties_flowDefinition_SourceFlowConfig_SourceConnectorProperties_Salesforce;
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
             // determine if requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties should be set to null
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorPropertiesIsNull)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties = null;
            }
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties != null)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig.SourceConnectorProperties = requestFlowDefinition_flowDefinition_SourceFlowConfig_flowDefinition_SourceFlowConfig_SourceConnectorProperties;
                requestFlowDefinition_flowDefinition_SourceFlowConfigIsNull = false;
            }
             // determine if requestFlowDefinition_flowDefinition_SourceFlowConfig should be set to null
            if (requestFlowDefinition_flowDefinition_SourceFlowConfigIsNull)
            {
                requestFlowDefinition_flowDefinition_SourceFlowConfig = null;
            }
            if (requestFlowDefinition_flowDefinition_SourceFlowConfig != null)
            {
                request.FlowDefinition.SourceFlowConfig = requestFlowDefinition_flowDefinition_SourceFlowConfig;
                requestFlowDefinitionIsNull = false;
            }
             // determine if request.FlowDefinition should be set to null
            if (requestFlowDefinitionIsNull)
            {
                request.FlowDefinition = null;
            }
            if (cmdletContext.ObjectTypeName != null)
            {
                request.ObjectTypeName = cmdletContext.ObjectTypeName;
            }
            if (cmdletContext.ObjectTypeNames != null)
            {
                request.ObjectTypeNames = cmdletContext.ObjectTypeNames;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Uri != null)
            {
                request.Uri = cmdletContext.Uri;
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
        
        private Amazon.CustomerProfiles.Model.PutIntegrationResponse CallAWSServiceOperation(IAmazonCustomerProfiles client, Amazon.CustomerProfiles.Model.PutIntegrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Customer Profiles", "PutIntegration");
            try
            {
                #if DESKTOP
                return client.PutIntegration(request);
                #elif CORECLR
                return client.PutIntegrationAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> ObjectTypeNames { get; set; }
            public System.String RoleArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String Uri { get; set; }
            public System.Func<Amazon.CustomerProfiles.Model.PutIntegrationResponse, WriteCPFIntegrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
