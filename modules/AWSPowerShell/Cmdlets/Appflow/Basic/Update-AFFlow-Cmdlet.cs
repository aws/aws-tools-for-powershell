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
using Amazon.Appflow;
using Amazon.Appflow.Model;

namespace Amazon.PowerShell.Cmdlets.AF
{
    /// <summary>
    /// Updates an existing flow.
    /// </summary>
    [Cmdlet("Update", "AFFlow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Appflow.FlowStatus")]
    [AWSCmdlet("Calls the Amazon Appflow UpdateFlow API operation.", Operation = new[] {"UpdateFlow"}, SelectReturnType = typeof(Amazon.Appflow.Model.UpdateFlowResponse))]
    [AWSCmdletOutput("Amazon.Appflow.FlowStatus or Amazon.Appflow.Model.UpdateFlowResponse",
        "This cmdlet returns an Amazon.Appflow.FlowStatus object.",
        "The service call response (type Amazon.Appflow.Model.UpdateFlowResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAFFlowCmdlet : AmazonAppflowClientCmdlet, IExecutor
    {
        
        #region Parameter SourceFlowConfig_ApiVersion
        /// <summary>
        /// <para>
        /// <para>The API version of the connector when it's used as a source in the flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceFlowConfig_ApiVersion { get; set; }
        #endregion
        
        #region Parameter S3_BucketName
        /// <summary>
        /// <para>
        /// <para> The Amazon S3 bucket name where the source files are stored. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_S3_BucketName")]
        public System.String S3_BucketName { get; set; }
        #endregion
        
        #region Parameter S3_BucketPrefix
        /// <summary>
        /// <para>
        /// <para> The object key for the Amazon S3 bucket in which the source files are stored. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_S3_BucketPrefix")]
        public System.String S3_BucketPrefix { get; set; }
        #endregion
        
        #region Parameter SourceFlowConfig_ConnectorProfileName
        /// <summary>
        /// <para>
        /// <para> The name of the connector profile. This name must be unique for each connector profile
        /// in the Amazon Web Services account. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceFlowConfig_ConnectorProfileName { get; set; }
        #endregion
        
        #region Parameter SourceFlowConfig_ConnectorType
        /// <summary>
        /// <para>
        /// <para> The type of connector, such as Salesforce, Amplitude, and so on. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Appflow.ConnectorType")]
        public Amazon.Appflow.ConnectorType SourceFlowConfig_ConnectorType { get; set; }
        #endregion
        
        #region Parameter CustomConnector_CustomProperty
        /// <summary>
        /// <para>
        /// <para>Custom properties that are required to use the custom connector as a source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_CustomConnector_CustomProperties")]
        public System.Collections.Hashtable CustomConnector_CustomProperty { get; set; }
        #endregion
        
        #region Parameter Scheduled_DataPullMode
        /// <summary>
        /// <para>
        /// <para> Specifies whether a scheduled flow has an incremental data transfer or a complete
        /// data transfer for each flow run. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TriggerConfig_TriggerProperties_Scheduled_DataPullMode")]
        [AWSConstantClassSource("Amazon.Appflow.DataPullMode")]
        public Amazon.Appflow.DataPullMode Scheduled_DataPullMode { get; set; }
        #endregion
        
        #region Parameter Salesforce_DataTransferApi
        /// <summary>
        /// <para>
        /// <para>Specifies which Salesforce API is used by Amazon AppFlow when your flow transfers
        /// data from Salesforce.</para><dl><dt>AUTOMATIC</dt><dd><para>The default. Amazon AppFlow selects which API to use based on the number of records
        /// that your flow transfers from Salesforce. If your flow transfers fewer than 1,000,000
        /// records, Amazon AppFlow uses Salesforce REST API. If your flow transfers 1,000,000
        /// records or more, Amazon AppFlow uses Salesforce Bulk API 2.0.</para><para>Each of these Salesforce APIs structures data differently. If Amazon AppFlow selects
        /// the API automatically, be aware that, for recurring flows, the data output might vary
        /// from one flow run to the next. For example, if a flow runs daily, it might use REST
        /// API on one day to transfer 900,000 records, and it might use Bulk API 2.0 on the next
        /// day to transfer 1,100,000 records. For each of these flow runs, the respective Salesforce
        /// API formats the data differently. Some of the differences include how dates are formatted
        /// and null values are represented. Also, Bulk API 2.0 doesn't transfer Salesforce compound
        /// fields.</para><para>By choosing this option, you optimize flow performance for both small and large data
        /// transfers, but the tradeoff is inconsistent formatting in the output.</para></dd><dt>BULKV2</dt><dd><para>Amazon AppFlow uses only Salesforce Bulk API 2.0. This API runs asynchronous data
        /// transfers, and it's optimal for large sets of data. By choosing this option, you ensure
        /// that your flow writes consistent output, but you optimize performance only for large
        /// data transfers.</para><para>Note that Bulk API 2.0 does not transfer Salesforce compound fields.</para></dd><dt>REST_SYNC</dt><dd><para>Amazon AppFlow uses only Salesforce REST API. By choosing this option, you ensure
        /// that your flow writes consistent output, but you decrease performance for large data
        /// transfers that are better suited for Bulk API 2.0. In some cases, if your flow attempts
        /// to transfer a vary large set of data, it might fail with a timed out error.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_Salesforce_DataTransferApi")]
        [AWSConstantClassSource("Amazon.Appflow.SalesforceDataTransferApi")]
        public Amazon.Appflow.SalesforceDataTransferApi Salesforce_DataTransferApi { get; set; }
        #endregion
        
        #region Parameter IncrementalPullConfig_DatetimeTypeFieldName
        /// <summary>
        /// <para>
        /// <para> A field that specifies the date time or timestamp field as the criteria to use when
        /// importing incremental records from the source. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_IncrementalPullConfig_DatetimeTypeFieldName")]
        public System.String IncrementalPullConfig_DatetimeTypeFieldName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> A description of the flow. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DestinationFlowConfigList
        /// <summary>
        /// <para>
        /// <para> The configuration that controls how Amazon AppFlow transfers data to the destination
        /// connector. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.Appflow.Model.DestinationFlowConfig[] DestinationFlowConfigList { get; set; }
        #endregion
        
        #region Parameter Veeva_DocumentType
        /// <summary>
        /// <para>
        /// <para>The document type specified in the Veeva document extract flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_Veeva_DocumentType")]
        public System.String Veeva_DocumentType { get; set; }
        #endregion
        
        #region Parameter Salesforce_EnableDynamicFieldUpdate
        /// <summary>
        /// <para>
        /// <para> The flag that enables dynamic fetching of new (recently added) fields in the Salesforce
        /// objects while running a flow. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_Salesforce_EnableDynamicFieldUpdate")]
        public System.Boolean? Salesforce_EnableDynamicFieldUpdate { get; set; }
        #endregion
        
        #region Parameter CustomConnector_EntityName
        /// <summary>
        /// <para>
        /// <para>The entity specified in the custom connector as a source in the flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_CustomConnector_EntityName")]
        public System.String CustomConnector_EntityName { get; set; }
        #endregion
        
        #region Parameter Scheduled_FirstExecutionFrom
        /// <summary>
        /// <para>
        /// <para> Specifies the date range for the records to import from the connector in the first
        /// flow run. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TriggerConfig_TriggerProperties_Scheduled_FirstExecutionFrom")]
        public System.DateTime? Scheduled_FirstExecutionFrom { get; set; }
        #endregion
        
        #region Parameter Scheduled_FlowErrorDeactivationThreshold
        /// <summary>
        /// <para>
        /// <para>Defines how many times a scheduled flow fails consecutively before Amazon AppFlow
        /// deactivates it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TriggerConfig_TriggerProperties_Scheduled_FlowErrorDeactivationThreshold")]
        public System.Int32? Scheduled_FlowErrorDeactivationThreshold { get; set; }
        #endregion
        
        #region Parameter FlowName
        /// <summary>
        /// <para>
        /// <para> The specified name of the flow. Spaces are not allowed. Use underscores (_) or hyphens
        /// (-) only. </para>
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
        public System.String FlowName { get; set; }
        #endregion
        
        #region Parameter Veeva_IncludeAllVersion
        /// <summary>
        /// <para>
        /// <para>Boolean value to include All Versions of files in Veeva document extract flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_Veeva_IncludeAllVersions")]
        public System.Boolean? Veeva_IncludeAllVersion { get; set; }
        #endregion
        
        #region Parameter Salesforce_IncludeDeletedRecord
        /// <summary>
        /// <para>
        /// <para> Indicates whether Amazon AppFlow includes deleted files in the flow run. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_Salesforce_IncludeDeletedRecords")]
        public System.Boolean? Salesforce_IncludeDeletedRecord { get; set; }
        #endregion
        
        #region Parameter Veeva_IncludeRendition
        /// <summary>
        /// <para>
        /// <para>Boolean value to include file renditions in Veeva document extract flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_Veeva_IncludeRenditions")]
        public System.Boolean? Veeva_IncludeRendition { get; set; }
        #endregion
        
        #region Parameter Veeva_IncludeSourceFile
        /// <summary>
        /// <para>
        /// <para>Boolean value to include source files in Veeva document extract flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_Veeva_IncludeSourceFiles")]
        public System.Boolean? Veeva_IncludeSourceFile { get; set; }
        #endregion
        
        #region Parameter Amplitude_Object
        /// <summary>
        /// <para>
        /// <para> The object specified in the Amplitude flow source. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_Amplitude_Object")]
        public System.String Amplitude_Object { get; set; }
        #endregion
        
        #region Parameter Datadog_Object
        /// <summary>
        /// <para>
        /// <para> The object specified in the Datadog flow source. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_Datadog_Object")]
        public System.String Datadog_Object { get; set; }
        #endregion
        
        #region Parameter Dynatrace_Object
        /// <summary>
        /// <para>
        /// <para> The object specified in the Dynatrace flow source. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_Dynatrace_Object")]
        public System.String Dynatrace_Object { get; set; }
        #endregion
        
        #region Parameter GoogleAnalytics_Object
        /// <summary>
        /// <para>
        /// <para> The object specified in the Google Analytics flow source. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_GoogleAnalytics_Object")]
        public System.String GoogleAnalytics_Object { get; set; }
        #endregion
        
        #region Parameter InforNexus_Object
        /// <summary>
        /// <para>
        /// <para> The object specified in the Infor Nexus flow source. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_InforNexus_Object")]
        public System.String InforNexus_Object { get; set; }
        #endregion
        
        #region Parameter Marketo_Object
        /// <summary>
        /// <para>
        /// <para> The object specified in the Marketo flow source. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_Marketo_Object")]
        public System.String Marketo_Object { get; set; }
        #endregion
        
        #region Parameter Salesforce_Object
        /// <summary>
        /// <para>
        /// <para> The object specified in the Salesforce flow source. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_Salesforce_Object")]
        public System.String Salesforce_Object { get; set; }
        #endregion
        
        #region Parameter ServiceNow_Object
        /// <summary>
        /// <para>
        /// <para> The object specified in the ServiceNow flow source. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_ServiceNow_Object")]
        public System.String ServiceNow_Object { get; set; }
        #endregion
        
        #region Parameter Singular_Object
        /// <summary>
        /// <para>
        /// <para> The object specified in the Singular flow source. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_Singular_Object")]
        public System.String Singular_Object { get; set; }
        #endregion
        
        #region Parameter Slack_Object
        /// <summary>
        /// <para>
        /// <para> The object specified in the Slack flow source. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_Slack_Object")]
        public System.String Slack_Object { get; set; }
        #endregion
        
        #region Parameter Trendmicro_Object
        /// <summary>
        /// <para>
        /// <para> The object specified in the Trend Micro flow source. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_Trendmicro_Object")]
        public System.String Trendmicro_Object { get; set; }
        #endregion
        
        #region Parameter Veeva_Object
        /// <summary>
        /// <para>
        /// <para> The object specified in the Veeva flow source. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_Veeva_Object")]
        public System.String Veeva_Object { get; set; }
        #endregion
        
        #region Parameter Zendesk_Object
        /// <summary>
        /// <para>
        /// <para> The object specified in the Zendesk flow source. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_Zendesk_Object")]
        public System.String Zendesk_Object { get; set; }
        #endregion
        
        #region Parameter SAPOData_ObjectPath
        /// <summary>
        /// <para>
        /// <para> The object path specified in the SAPOData flow source. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_SAPOData_ObjectPath")]
        public System.String SAPOData_ObjectPath { get; set; }
        #endregion
        
        #region Parameter S3InputFormatConfig_S3InputFileType
        /// <summary>
        /// <para>
        /// <para> The file type that Amazon AppFlow gets from your Amazon S3 bucket. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceFlowConfig_SourceConnectorProperties_S3_S3InputFormatConfig_S3InputFileType")]
        [AWSConstantClassSource("Amazon.Appflow.S3InputFileType")]
        public Amazon.Appflow.S3InputFileType S3InputFormatConfig_S3InputFileType { get; set; }
        #endregion
        
        #region Parameter Scheduled_ScheduleEndTime
        /// <summary>
        /// <para>
        /// <para>The time at which the scheduled flow ends. The time is formatted as a timestamp that
        /// follows the ISO 8601 standard, such as <code>2022-04-27T13:00:00-07:00</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TriggerConfig_TriggerProperties_Scheduled_ScheduleEndTime")]
        public System.DateTime? Scheduled_ScheduleEndTime { get; set; }
        #endregion
        
        #region Parameter Scheduled_ScheduleExpression
        /// <summary>
        /// <para>
        /// <para> The scheduling expression that determines the rate at which the schedule will run,
        /// for example <code>rate(5minutes)</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TriggerConfig_TriggerProperties_Scheduled_ScheduleExpression")]
        public System.String Scheduled_ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter Scheduled_ScheduleOffset
        /// <summary>
        /// <para>
        /// <para> Specifies the optional offset that is added to the time interval for a schedule-triggered
        /// flow. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TriggerConfig_TriggerProperties_Scheduled_ScheduleOffset")]
        public System.Int64? Scheduled_ScheduleOffset { get; set; }
        #endregion
        
        #region Parameter Scheduled_ScheduleStartTime
        /// <summary>
        /// <para>
        /// <para>The time at which the scheduled flow starts. The time is formatted as a timestamp
        /// that follows the ISO 8601 standard, such as <code>2022-04-26T13:00:00-07:00</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TriggerConfig_TriggerProperties_Scheduled_ScheduleStartTime")]
        public System.DateTime? Scheduled_ScheduleStartTime { get; set; }
        #endregion
        
        #region Parameter Task
        /// <summary>
        /// <para>
        /// <para> A list of tasks that Amazon AppFlow performs while transferring the data in the flow
        /// run. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Tasks")]
        public Amazon.Appflow.Model.Task[] Task { get; set; }
        #endregion
        
        #region Parameter Scheduled_Timezone
        /// <summary>
        /// <para>
        /// <para>Specifies the time zone used when referring to the dates and times of a scheduled
        /// flow, such as <code>America/New_York</code>. This time zone is only a descriptive
        /// label. It doesn't affect how Amazon AppFlow interprets the timestamps that you specify
        /// to schedule the flow.</para><para>If you want to schedule a flow by using times in a particular time zone, indicate
        /// the time zone as a UTC offset in your timestamps. For example, the UTC offsets for
        /// the <code>America/New_York</code> timezone are <code>-04:00</code> EDT and <code>-05:00
        /// EST</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TriggerConfig_TriggerProperties_Scheduled_Timezone")]
        public System.String Scheduled_Timezone { get; set; }
        #endregion
        
        #region Parameter TriggerConfig_TriggerType
        /// <summary>
        /// <para>
        /// <para> Specifies the type of flow trigger. This can be <code>OnDemand</code>, <code>Scheduled</code>,
        /// or <code>Event</code>. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Appflow.TriggerType")]
        public Amazon.Appflow.TriggerType TriggerConfig_TriggerType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FlowStatus'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Appflow.Model.UpdateFlowResponse).
        /// Specifying the name of a property of type Amazon.Appflow.Model.UpdateFlowResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FlowStatus";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FlowName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FlowName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FlowName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FlowName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AFFlow (UpdateFlow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Appflow.Model.UpdateFlowResponse, UpdateAFFlowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FlowName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            if (this.DestinationFlowConfigList != null)
            {
                context.DestinationFlowConfigList = new List<Amazon.Appflow.Model.DestinationFlowConfig>(this.DestinationFlowConfigList);
            }
            #if MODULAR
            if (this.DestinationFlowConfigList == null && ParameterWasBound(nameof(this.DestinationFlowConfigList)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationFlowConfigList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FlowName = this.FlowName;
            #if MODULAR
            if (this.FlowName == null && ParameterWasBound(nameof(this.FlowName)))
            {
                WriteWarning("You are passing $null as a value for parameter FlowName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceFlowConfig_ApiVersion = this.SourceFlowConfig_ApiVersion;
            context.SourceFlowConfig_ConnectorProfileName = this.SourceFlowConfig_ConnectorProfileName;
            context.SourceFlowConfig_ConnectorType = this.SourceFlowConfig_ConnectorType;
            #if MODULAR
            if (this.SourceFlowConfig_ConnectorType == null && ParameterWasBound(nameof(this.SourceFlowConfig_ConnectorType)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceFlowConfig_ConnectorType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IncrementalPullConfig_DatetimeTypeFieldName = this.IncrementalPullConfig_DatetimeTypeFieldName;
            context.Amplitude_Object = this.Amplitude_Object;
            if (this.CustomConnector_CustomProperty != null)
            {
                context.CustomConnector_CustomProperty = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CustomConnector_CustomProperty.Keys)
                {
                    context.CustomConnector_CustomProperty.Add((String)hashKey, (String)(this.CustomConnector_CustomProperty[hashKey]));
                }
            }
            context.CustomConnector_EntityName = this.CustomConnector_EntityName;
            context.Datadog_Object = this.Datadog_Object;
            context.Dynatrace_Object = this.Dynatrace_Object;
            context.GoogleAnalytics_Object = this.GoogleAnalytics_Object;
            context.InforNexus_Object = this.InforNexus_Object;
            context.Marketo_Object = this.Marketo_Object;
            context.S3_BucketName = this.S3_BucketName;
            context.S3_BucketPrefix = this.S3_BucketPrefix;
            context.S3InputFormatConfig_S3InputFileType = this.S3InputFormatConfig_S3InputFileType;
            context.Salesforce_DataTransferApi = this.Salesforce_DataTransferApi;
            context.Salesforce_EnableDynamicFieldUpdate = this.Salesforce_EnableDynamicFieldUpdate;
            context.Salesforce_IncludeDeletedRecord = this.Salesforce_IncludeDeletedRecord;
            context.Salesforce_Object = this.Salesforce_Object;
            context.SAPOData_ObjectPath = this.SAPOData_ObjectPath;
            context.ServiceNow_Object = this.ServiceNow_Object;
            context.Singular_Object = this.Singular_Object;
            context.Slack_Object = this.Slack_Object;
            context.Trendmicro_Object = this.Trendmicro_Object;
            context.Veeva_DocumentType = this.Veeva_DocumentType;
            context.Veeva_IncludeAllVersion = this.Veeva_IncludeAllVersion;
            context.Veeva_IncludeRendition = this.Veeva_IncludeRendition;
            context.Veeva_IncludeSourceFile = this.Veeva_IncludeSourceFile;
            context.Veeva_Object = this.Veeva_Object;
            context.Zendesk_Object = this.Zendesk_Object;
            if (this.Task != null)
            {
                context.Task = new List<Amazon.Appflow.Model.Task>(this.Task);
            }
            #if MODULAR
            if (this.Task == null && ParameterWasBound(nameof(this.Task)))
            {
                WriteWarning("You are passing $null as a value for parameter Task which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Scheduled_DataPullMode = this.Scheduled_DataPullMode;
            context.Scheduled_FirstExecutionFrom = this.Scheduled_FirstExecutionFrom;
            context.Scheduled_FlowErrorDeactivationThreshold = this.Scheduled_FlowErrorDeactivationThreshold;
            context.Scheduled_ScheduleEndTime = this.Scheduled_ScheduleEndTime;
            context.Scheduled_ScheduleExpression = this.Scheduled_ScheduleExpression;
            context.Scheduled_ScheduleOffset = this.Scheduled_ScheduleOffset;
            context.Scheduled_ScheduleStartTime = this.Scheduled_ScheduleStartTime;
            context.Scheduled_Timezone = this.Scheduled_Timezone;
            context.TriggerConfig_TriggerType = this.TriggerConfig_TriggerType;
            #if MODULAR
            if (this.TriggerConfig_TriggerType == null && ParameterWasBound(nameof(this.TriggerConfig_TriggerType)))
            {
                WriteWarning("You are passing $null as a value for parameter TriggerConfig_TriggerType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Appflow.Model.UpdateFlowRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DestinationFlowConfigList != null)
            {
                request.DestinationFlowConfigList = cmdletContext.DestinationFlowConfigList;
            }
            if (cmdletContext.FlowName != null)
            {
                request.FlowName = cmdletContext.FlowName;
            }
            
             // populate SourceFlowConfig
            var requestSourceFlowConfigIsNull = true;
            request.SourceFlowConfig = new Amazon.Appflow.Model.SourceFlowConfig();
            System.String requestSourceFlowConfig_sourceFlowConfig_ApiVersion = null;
            if (cmdletContext.SourceFlowConfig_ApiVersion != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_ApiVersion = cmdletContext.SourceFlowConfig_ApiVersion;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_ApiVersion != null)
            {
                request.SourceFlowConfig.ApiVersion = requestSourceFlowConfig_sourceFlowConfig_ApiVersion;
                requestSourceFlowConfigIsNull = false;
            }
            System.String requestSourceFlowConfig_sourceFlowConfig_ConnectorProfileName = null;
            if (cmdletContext.SourceFlowConfig_ConnectorProfileName != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_ConnectorProfileName = cmdletContext.SourceFlowConfig_ConnectorProfileName;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_ConnectorProfileName != null)
            {
                request.SourceFlowConfig.ConnectorProfileName = requestSourceFlowConfig_sourceFlowConfig_ConnectorProfileName;
                requestSourceFlowConfigIsNull = false;
            }
            Amazon.Appflow.ConnectorType requestSourceFlowConfig_sourceFlowConfig_ConnectorType = null;
            if (cmdletContext.SourceFlowConfig_ConnectorType != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_ConnectorType = cmdletContext.SourceFlowConfig_ConnectorType;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_ConnectorType != null)
            {
                request.SourceFlowConfig.ConnectorType = requestSourceFlowConfig_sourceFlowConfig_ConnectorType;
                requestSourceFlowConfigIsNull = false;
            }
            Amazon.Appflow.Model.IncrementalPullConfig requestSourceFlowConfig_sourceFlowConfig_IncrementalPullConfig = null;
            
             // populate IncrementalPullConfig
            var requestSourceFlowConfig_sourceFlowConfig_IncrementalPullConfigIsNull = true;
            requestSourceFlowConfig_sourceFlowConfig_IncrementalPullConfig = new Amazon.Appflow.Model.IncrementalPullConfig();
            System.String requestSourceFlowConfig_sourceFlowConfig_IncrementalPullConfig_incrementalPullConfig_DatetimeTypeFieldName = null;
            if (cmdletContext.IncrementalPullConfig_DatetimeTypeFieldName != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_IncrementalPullConfig_incrementalPullConfig_DatetimeTypeFieldName = cmdletContext.IncrementalPullConfig_DatetimeTypeFieldName;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_IncrementalPullConfig_incrementalPullConfig_DatetimeTypeFieldName != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_IncrementalPullConfig.DatetimeTypeFieldName = requestSourceFlowConfig_sourceFlowConfig_IncrementalPullConfig_incrementalPullConfig_DatetimeTypeFieldName;
                requestSourceFlowConfig_sourceFlowConfig_IncrementalPullConfigIsNull = false;
            }
             // determine if requestSourceFlowConfig_sourceFlowConfig_IncrementalPullConfig should be set to null
            if (requestSourceFlowConfig_sourceFlowConfig_IncrementalPullConfigIsNull)
            {
                requestSourceFlowConfig_sourceFlowConfig_IncrementalPullConfig = null;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_IncrementalPullConfig != null)
            {
                request.SourceFlowConfig.IncrementalPullConfig = requestSourceFlowConfig_sourceFlowConfig_IncrementalPullConfig;
                requestSourceFlowConfigIsNull = false;
            }
            Amazon.Appflow.Model.SourceConnectorProperties requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties = null;
            
             // populate SourceConnectorProperties
            var requestSourceFlowConfig_sourceFlowConfig_SourceConnectorPropertiesIsNull = true;
            requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties = new Amazon.Appflow.Model.SourceConnectorProperties();
            Amazon.Appflow.Model.AmplitudeSourceProperties requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Amplitude = null;
            
             // populate Amplitude
            var requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_AmplitudeIsNull = true;
            requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Amplitude = new Amazon.Appflow.Model.AmplitudeSourceProperties();
            System.String requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Amplitude_amplitude_Object = null;
            if (cmdletContext.Amplitude_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Amplitude_amplitude_Object = cmdletContext.Amplitude_Object;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Amplitude_amplitude_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Amplitude.Object = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Amplitude_amplitude_Object;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_AmplitudeIsNull = false;
            }
             // determine if requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Amplitude should be set to null
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_AmplitudeIsNull)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Amplitude = null;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Amplitude != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties.Amplitude = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Amplitude;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
            Amazon.Appflow.Model.DatadogSourceProperties requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Datadog = null;
            
             // populate Datadog
            var requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_DatadogIsNull = true;
            requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Datadog = new Amazon.Appflow.Model.DatadogSourceProperties();
            System.String requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Datadog_datadog_Object = null;
            if (cmdletContext.Datadog_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Datadog_datadog_Object = cmdletContext.Datadog_Object;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Datadog_datadog_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Datadog.Object = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Datadog_datadog_Object;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_DatadogIsNull = false;
            }
             // determine if requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Datadog should be set to null
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_DatadogIsNull)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Datadog = null;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Datadog != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties.Datadog = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Datadog;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
            Amazon.Appflow.Model.DynatraceSourceProperties requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Dynatrace = null;
            
             // populate Dynatrace
            var requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_DynatraceIsNull = true;
            requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Dynatrace = new Amazon.Appflow.Model.DynatraceSourceProperties();
            System.String requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Dynatrace_dynatrace_Object = null;
            if (cmdletContext.Dynatrace_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Dynatrace_dynatrace_Object = cmdletContext.Dynatrace_Object;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Dynatrace_dynatrace_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Dynatrace.Object = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Dynatrace_dynatrace_Object;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_DynatraceIsNull = false;
            }
             // determine if requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Dynatrace should be set to null
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_DynatraceIsNull)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Dynatrace = null;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Dynatrace != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties.Dynatrace = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Dynatrace;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
            Amazon.Appflow.Model.GoogleAnalyticsSourceProperties requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_GoogleAnalytics = null;
            
             // populate GoogleAnalytics
            var requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_GoogleAnalyticsIsNull = true;
            requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_GoogleAnalytics = new Amazon.Appflow.Model.GoogleAnalyticsSourceProperties();
            System.String requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_GoogleAnalytics_googleAnalytics_Object = null;
            if (cmdletContext.GoogleAnalytics_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_GoogleAnalytics_googleAnalytics_Object = cmdletContext.GoogleAnalytics_Object;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_GoogleAnalytics_googleAnalytics_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_GoogleAnalytics.Object = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_GoogleAnalytics_googleAnalytics_Object;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_GoogleAnalyticsIsNull = false;
            }
             // determine if requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_GoogleAnalytics should be set to null
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_GoogleAnalyticsIsNull)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_GoogleAnalytics = null;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_GoogleAnalytics != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties.GoogleAnalytics = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_GoogleAnalytics;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
            Amazon.Appflow.Model.InforNexusSourceProperties requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_InforNexus = null;
            
             // populate InforNexus
            var requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_InforNexusIsNull = true;
            requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_InforNexus = new Amazon.Appflow.Model.InforNexusSourceProperties();
            System.String requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_InforNexus_inforNexus_Object = null;
            if (cmdletContext.InforNexus_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_InforNexus_inforNexus_Object = cmdletContext.InforNexus_Object;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_InforNexus_inforNexus_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_InforNexus.Object = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_InforNexus_inforNexus_Object;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_InforNexusIsNull = false;
            }
             // determine if requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_InforNexus should be set to null
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_InforNexusIsNull)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_InforNexus = null;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_InforNexus != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties.InforNexus = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_InforNexus;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
            Amazon.Appflow.Model.MarketoSourceProperties requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Marketo = null;
            
             // populate Marketo
            var requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_MarketoIsNull = true;
            requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Marketo = new Amazon.Appflow.Model.MarketoSourceProperties();
            System.String requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Marketo_marketo_Object = null;
            if (cmdletContext.Marketo_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Marketo_marketo_Object = cmdletContext.Marketo_Object;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Marketo_marketo_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Marketo.Object = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Marketo_marketo_Object;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_MarketoIsNull = false;
            }
             // determine if requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Marketo should be set to null
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_MarketoIsNull)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Marketo = null;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Marketo != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties.Marketo = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Marketo;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
            Amazon.Appflow.Model.SAPODataSourceProperties requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SAPOData = null;
            
             // populate SAPOData
            var requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SAPODataIsNull = true;
            requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SAPOData = new Amazon.Appflow.Model.SAPODataSourceProperties();
            System.String requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SAPOData_sAPOData_ObjectPath = null;
            if (cmdletContext.SAPOData_ObjectPath != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SAPOData_sAPOData_ObjectPath = cmdletContext.SAPOData_ObjectPath;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SAPOData_sAPOData_ObjectPath != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SAPOData.ObjectPath = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SAPOData_sAPOData_ObjectPath;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SAPODataIsNull = false;
            }
             // determine if requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SAPOData should be set to null
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SAPODataIsNull)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SAPOData = null;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SAPOData != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties.SAPOData = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SAPOData;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
            Amazon.Appflow.Model.ServiceNowSourceProperties requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_ServiceNow = null;
            
             // populate ServiceNow
            var requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_ServiceNowIsNull = true;
            requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_ServiceNow = new Amazon.Appflow.Model.ServiceNowSourceProperties();
            System.String requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_ServiceNow_serviceNow_Object = null;
            if (cmdletContext.ServiceNow_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_ServiceNow_serviceNow_Object = cmdletContext.ServiceNow_Object;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_ServiceNow_serviceNow_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_ServiceNow.Object = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_ServiceNow_serviceNow_Object;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_ServiceNowIsNull = false;
            }
             // determine if requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_ServiceNow should be set to null
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_ServiceNowIsNull)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_ServiceNow = null;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_ServiceNow != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties.ServiceNow = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_ServiceNow;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
            Amazon.Appflow.Model.SingularSourceProperties requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Singular = null;
            
             // populate Singular
            var requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SingularIsNull = true;
            requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Singular = new Amazon.Appflow.Model.SingularSourceProperties();
            System.String requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Singular_singular_Object = null;
            if (cmdletContext.Singular_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Singular_singular_Object = cmdletContext.Singular_Object;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Singular_singular_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Singular.Object = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Singular_singular_Object;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SingularIsNull = false;
            }
             // determine if requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Singular should be set to null
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SingularIsNull)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Singular = null;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Singular != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties.Singular = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Singular;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
            Amazon.Appflow.Model.SlackSourceProperties requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Slack = null;
            
             // populate Slack
            var requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SlackIsNull = true;
            requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Slack = new Amazon.Appflow.Model.SlackSourceProperties();
            System.String requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Slack_slack_Object = null;
            if (cmdletContext.Slack_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Slack_slack_Object = cmdletContext.Slack_Object;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Slack_slack_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Slack.Object = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Slack_slack_Object;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SlackIsNull = false;
            }
             // determine if requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Slack should be set to null
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SlackIsNull)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Slack = null;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Slack != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties.Slack = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Slack;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
            Amazon.Appflow.Model.TrendmicroSourceProperties requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Trendmicro = null;
            
             // populate Trendmicro
            var requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_TrendmicroIsNull = true;
            requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Trendmicro = new Amazon.Appflow.Model.TrendmicroSourceProperties();
            System.String requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Trendmicro_trendmicro_Object = null;
            if (cmdletContext.Trendmicro_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Trendmicro_trendmicro_Object = cmdletContext.Trendmicro_Object;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Trendmicro_trendmicro_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Trendmicro.Object = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Trendmicro_trendmicro_Object;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_TrendmicroIsNull = false;
            }
             // determine if requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Trendmicro should be set to null
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_TrendmicroIsNull)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Trendmicro = null;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Trendmicro != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties.Trendmicro = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Trendmicro;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
            Amazon.Appflow.Model.ZendeskSourceProperties requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Zendesk = null;
            
             // populate Zendesk
            var requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_ZendeskIsNull = true;
            requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Zendesk = new Amazon.Appflow.Model.ZendeskSourceProperties();
            System.String requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Zendesk_zendesk_Object = null;
            if (cmdletContext.Zendesk_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Zendesk_zendesk_Object = cmdletContext.Zendesk_Object;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Zendesk_zendesk_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Zendesk.Object = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Zendesk_zendesk_Object;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_ZendeskIsNull = false;
            }
             // determine if requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Zendesk should be set to null
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_ZendeskIsNull)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Zendesk = null;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Zendesk != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties.Zendesk = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Zendesk;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
            Amazon.Appflow.Model.CustomConnectorSourceProperties requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_CustomConnector = null;
            
             // populate CustomConnector
            var requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_CustomConnectorIsNull = true;
            requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_CustomConnector = new Amazon.Appflow.Model.CustomConnectorSourceProperties();
            Dictionary<System.String, System.String> requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_CustomConnector_customConnector_CustomProperty = null;
            if (cmdletContext.CustomConnector_CustomProperty != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_CustomConnector_customConnector_CustomProperty = cmdletContext.CustomConnector_CustomProperty;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_CustomConnector_customConnector_CustomProperty != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_CustomConnector.CustomProperties = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_CustomConnector_customConnector_CustomProperty;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_CustomConnectorIsNull = false;
            }
            System.String requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_CustomConnector_customConnector_EntityName = null;
            if (cmdletContext.CustomConnector_EntityName != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_CustomConnector_customConnector_EntityName = cmdletContext.CustomConnector_EntityName;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_CustomConnector_customConnector_EntityName != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_CustomConnector.EntityName = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_CustomConnector_customConnector_EntityName;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_CustomConnectorIsNull = false;
            }
             // determine if requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_CustomConnector should be set to null
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_CustomConnectorIsNull)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_CustomConnector = null;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_CustomConnector != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties.CustomConnector = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_CustomConnector;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
            Amazon.Appflow.Model.S3SourceProperties requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3 = null;
            
             // populate S3
            var requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3IsNull = true;
            requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3 = new Amazon.Appflow.Model.S3SourceProperties();
            System.String requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3_s3_BucketName = null;
            if (cmdletContext.S3_BucketName != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3_s3_BucketName = cmdletContext.S3_BucketName;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3_s3_BucketName != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3.BucketName = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3_s3_BucketName;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3IsNull = false;
            }
            System.String requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3_s3_BucketPrefix = null;
            if (cmdletContext.S3_BucketPrefix != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3_s3_BucketPrefix = cmdletContext.S3_BucketPrefix;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3_s3_BucketPrefix != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3.BucketPrefix = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3_s3_BucketPrefix;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3IsNull = false;
            }
            Amazon.Appflow.Model.S3InputFormatConfig requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3_sourceFlowConfig_SourceConnectorProperties_S3_S3InputFormatConfig = null;
            
             // populate S3InputFormatConfig
            var requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3_sourceFlowConfig_SourceConnectorProperties_S3_S3InputFormatConfigIsNull = true;
            requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3_sourceFlowConfig_SourceConnectorProperties_S3_S3InputFormatConfig = new Amazon.Appflow.Model.S3InputFormatConfig();
            Amazon.Appflow.S3InputFileType requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3_sourceFlowConfig_SourceConnectorProperties_S3_S3InputFormatConfig_s3InputFormatConfig_S3InputFileType = null;
            if (cmdletContext.S3InputFormatConfig_S3InputFileType != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3_sourceFlowConfig_SourceConnectorProperties_S3_S3InputFormatConfig_s3InputFormatConfig_S3InputFileType = cmdletContext.S3InputFormatConfig_S3InputFileType;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3_sourceFlowConfig_SourceConnectorProperties_S3_S3InputFormatConfig_s3InputFormatConfig_S3InputFileType != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3_sourceFlowConfig_SourceConnectorProperties_S3_S3InputFormatConfig.S3InputFileType = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3_sourceFlowConfig_SourceConnectorProperties_S3_S3InputFormatConfig_s3InputFormatConfig_S3InputFileType;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3_sourceFlowConfig_SourceConnectorProperties_S3_S3InputFormatConfigIsNull = false;
            }
             // determine if requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3_sourceFlowConfig_SourceConnectorProperties_S3_S3InputFormatConfig should be set to null
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3_sourceFlowConfig_SourceConnectorProperties_S3_S3InputFormatConfigIsNull)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3_sourceFlowConfig_SourceConnectorProperties_S3_S3InputFormatConfig = null;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3_sourceFlowConfig_SourceConnectorProperties_S3_S3InputFormatConfig != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3.S3InputFormatConfig = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3_sourceFlowConfig_SourceConnectorProperties_S3_S3InputFormatConfig;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3IsNull = false;
            }
             // determine if requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3 should be set to null
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3IsNull)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3 = null;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3 != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties.S3 = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_S3;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
            Amazon.Appflow.Model.SalesforceSourceProperties requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce = null;
            
             // populate Salesforce
            var requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SalesforceIsNull = true;
            requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce = new Amazon.Appflow.Model.SalesforceSourceProperties();
            Amazon.Appflow.SalesforceDataTransferApi requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_DataTransferApi = null;
            if (cmdletContext.Salesforce_DataTransferApi != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_DataTransferApi = cmdletContext.Salesforce_DataTransferApi;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_DataTransferApi != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce.DataTransferApi = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_DataTransferApi;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SalesforceIsNull = false;
            }
            System.Boolean? requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_EnableDynamicFieldUpdate = null;
            if (cmdletContext.Salesforce_EnableDynamicFieldUpdate != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_EnableDynamicFieldUpdate = cmdletContext.Salesforce_EnableDynamicFieldUpdate.Value;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_EnableDynamicFieldUpdate != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce.EnableDynamicFieldUpdate = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_EnableDynamicFieldUpdate.Value;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SalesforceIsNull = false;
            }
            System.Boolean? requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_IncludeDeletedRecord = null;
            if (cmdletContext.Salesforce_IncludeDeletedRecord != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_IncludeDeletedRecord = cmdletContext.Salesforce_IncludeDeletedRecord.Value;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_IncludeDeletedRecord != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce.IncludeDeletedRecords = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_IncludeDeletedRecord.Value;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SalesforceIsNull = false;
            }
            System.String requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_Object = null;
            if (cmdletContext.Salesforce_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_Object = cmdletContext.Salesforce_Object;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce.Object = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce_salesforce_Object;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SalesforceIsNull = false;
            }
             // determine if requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce should be set to null
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_SalesforceIsNull)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce = null;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties.Salesforce = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Salesforce;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
            Amazon.Appflow.Model.VeevaSourceProperties requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva = null;
            
             // populate Veeva
            var requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_VeevaIsNull = true;
            requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva = new Amazon.Appflow.Model.VeevaSourceProperties();
            System.String requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva_veeva_DocumentType = null;
            if (cmdletContext.Veeva_DocumentType != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva_veeva_DocumentType = cmdletContext.Veeva_DocumentType;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva_veeva_DocumentType != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva.DocumentType = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva_veeva_DocumentType;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_VeevaIsNull = false;
            }
            System.Boolean? requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva_veeva_IncludeAllVersion = null;
            if (cmdletContext.Veeva_IncludeAllVersion != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva_veeva_IncludeAllVersion = cmdletContext.Veeva_IncludeAllVersion.Value;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva_veeva_IncludeAllVersion != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva.IncludeAllVersions = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva_veeva_IncludeAllVersion.Value;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_VeevaIsNull = false;
            }
            System.Boolean? requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva_veeva_IncludeRendition = null;
            if (cmdletContext.Veeva_IncludeRendition != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva_veeva_IncludeRendition = cmdletContext.Veeva_IncludeRendition.Value;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva_veeva_IncludeRendition != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva.IncludeRenditions = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva_veeva_IncludeRendition.Value;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_VeevaIsNull = false;
            }
            System.Boolean? requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva_veeva_IncludeSourceFile = null;
            if (cmdletContext.Veeva_IncludeSourceFile != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva_veeva_IncludeSourceFile = cmdletContext.Veeva_IncludeSourceFile.Value;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva_veeva_IncludeSourceFile != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva.IncludeSourceFiles = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva_veeva_IncludeSourceFile.Value;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_VeevaIsNull = false;
            }
            System.String requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva_veeva_Object = null;
            if (cmdletContext.Veeva_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva_veeva_Object = cmdletContext.Veeva_Object;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva_veeva_Object != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva.Object = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva_veeva_Object;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_VeevaIsNull = false;
            }
             // determine if requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva should be set to null
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_VeevaIsNull)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva = null;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva != null)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties.Veeva = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties_sourceFlowConfig_SourceConnectorProperties_Veeva;
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorPropertiesIsNull = false;
            }
             // determine if requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties should be set to null
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorPropertiesIsNull)
            {
                requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties = null;
            }
            if (requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties != null)
            {
                request.SourceFlowConfig.SourceConnectorProperties = requestSourceFlowConfig_sourceFlowConfig_SourceConnectorProperties;
                requestSourceFlowConfigIsNull = false;
            }
             // determine if request.SourceFlowConfig should be set to null
            if (requestSourceFlowConfigIsNull)
            {
                request.SourceFlowConfig = null;
            }
            if (cmdletContext.Task != null)
            {
                request.Tasks = cmdletContext.Task;
            }
            
             // populate TriggerConfig
            var requestTriggerConfigIsNull = true;
            request.TriggerConfig = new Amazon.Appflow.Model.TriggerConfig();
            Amazon.Appflow.TriggerType requestTriggerConfig_triggerConfig_TriggerType = null;
            if (cmdletContext.TriggerConfig_TriggerType != null)
            {
                requestTriggerConfig_triggerConfig_TriggerType = cmdletContext.TriggerConfig_TriggerType;
            }
            if (requestTriggerConfig_triggerConfig_TriggerType != null)
            {
                request.TriggerConfig.TriggerType = requestTriggerConfig_triggerConfig_TriggerType;
                requestTriggerConfigIsNull = false;
            }
            Amazon.Appflow.Model.TriggerProperties requestTriggerConfig_triggerConfig_TriggerProperties = null;
            
             // populate TriggerProperties
            var requestTriggerConfig_triggerConfig_TriggerPropertiesIsNull = true;
            requestTriggerConfig_triggerConfig_TriggerProperties = new Amazon.Appflow.Model.TriggerProperties();
            Amazon.Appflow.Model.ScheduledTriggerProperties requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled = null;
            
             // populate Scheduled
            var requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_ScheduledIsNull = true;
            requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled = new Amazon.Appflow.Model.ScheduledTriggerProperties();
            Amazon.Appflow.DataPullMode requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_DataPullMode = null;
            if (cmdletContext.Scheduled_DataPullMode != null)
            {
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_DataPullMode = cmdletContext.Scheduled_DataPullMode;
            }
            if (requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_DataPullMode != null)
            {
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled.DataPullMode = requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_DataPullMode;
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_ScheduledIsNull = false;
            }
            System.DateTime? requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_FirstExecutionFrom = null;
            if (cmdletContext.Scheduled_FirstExecutionFrom != null)
            {
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_FirstExecutionFrom = cmdletContext.Scheduled_FirstExecutionFrom.Value;
            }
            if (requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_FirstExecutionFrom != null)
            {
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled.FirstExecutionFrom = requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_FirstExecutionFrom.Value;
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_ScheduledIsNull = false;
            }
            System.Int32? requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_FlowErrorDeactivationThreshold = null;
            if (cmdletContext.Scheduled_FlowErrorDeactivationThreshold != null)
            {
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_FlowErrorDeactivationThreshold = cmdletContext.Scheduled_FlowErrorDeactivationThreshold.Value;
            }
            if (requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_FlowErrorDeactivationThreshold != null)
            {
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled.FlowErrorDeactivationThreshold = requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_FlowErrorDeactivationThreshold.Value;
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_ScheduledIsNull = false;
            }
            System.DateTime? requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleEndTime = null;
            if (cmdletContext.Scheduled_ScheduleEndTime != null)
            {
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleEndTime = cmdletContext.Scheduled_ScheduleEndTime.Value;
            }
            if (requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleEndTime != null)
            {
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled.ScheduleEndTime = requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleEndTime.Value;
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_ScheduledIsNull = false;
            }
            System.String requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleExpression = null;
            if (cmdletContext.Scheduled_ScheduleExpression != null)
            {
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleExpression = cmdletContext.Scheduled_ScheduleExpression;
            }
            if (requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleExpression != null)
            {
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled.ScheduleExpression = requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleExpression;
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_ScheduledIsNull = false;
            }
            System.Int64? requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleOffset = null;
            if (cmdletContext.Scheduled_ScheduleOffset != null)
            {
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleOffset = cmdletContext.Scheduled_ScheduleOffset.Value;
            }
            if (requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleOffset != null)
            {
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled.ScheduleOffset = requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleOffset.Value;
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_ScheduledIsNull = false;
            }
            System.DateTime? requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleStartTime = null;
            if (cmdletContext.Scheduled_ScheduleStartTime != null)
            {
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleStartTime = cmdletContext.Scheduled_ScheduleStartTime.Value;
            }
            if (requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleStartTime != null)
            {
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled.ScheduleStartTime = requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_ScheduleStartTime.Value;
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_ScheduledIsNull = false;
            }
            System.String requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_Timezone = null;
            if (cmdletContext.Scheduled_Timezone != null)
            {
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_Timezone = cmdletContext.Scheduled_Timezone;
            }
            if (requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_Timezone != null)
            {
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled.Timezone = requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled_scheduled_Timezone;
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_ScheduledIsNull = false;
            }
             // determine if requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled should be set to null
            if (requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_ScheduledIsNull)
            {
                requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled = null;
            }
            if (requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled != null)
            {
                requestTriggerConfig_triggerConfig_TriggerProperties.Scheduled = requestTriggerConfig_triggerConfig_TriggerProperties_triggerConfig_TriggerProperties_Scheduled;
                requestTriggerConfig_triggerConfig_TriggerPropertiesIsNull = false;
            }
             // determine if requestTriggerConfig_triggerConfig_TriggerProperties should be set to null
            if (requestTriggerConfig_triggerConfig_TriggerPropertiesIsNull)
            {
                requestTriggerConfig_triggerConfig_TriggerProperties = null;
            }
            if (requestTriggerConfig_triggerConfig_TriggerProperties != null)
            {
                request.TriggerConfig.TriggerProperties = requestTriggerConfig_triggerConfig_TriggerProperties;
                requestTriggerConfigIsNull = false;
            }
             // determine if request.TriggerConfig should be set to null
            if (requestTriggerConfigIsNull)
            {
                request.TriggerConfig = null;
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
        
        private Amazon.Appflow.Model.UpdateFlowResponse CallAWSServiceOperation(IAmazonAppflow client, Amazon.Appflow.Model.UpdateFlowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Appflow", "UpdateFlow");
            try
            {
                #if DESKTOP
                return client.UpdateFlow(request);
                #elif CORECLR
                return client.UpdateFlowAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public List<Amazon.Appflow.Model.DestinationFlowConfig> DestinationFlowConfigList { get; set; }
            public System.String FlowName { get; set; }
            public System.String SourceFlowConfig_ApiVersion { get; set; }
            public System.String SourceFlowConfig_ConnectorProfileName { get; set; }
            public Amazon.Appflow.ConnectorType SourceFlowConfig_ConnectorType { get; set; }
            public System.String IncrementalPullConfig_DatetimeTypeFieldName { get; set; }
            public System.String Amplitude_Object { get; set; }
            public Dictionary<System.String, System.String> CustomConnector_CustomProperty { get; set; }
            public System.String CustomConnector_EntityName { get; set; }
            public System.String Datadog_Object { get; set; }
            public System.String Dynatrace_Object { get; set; }
            public System.String GoogleAnalytics_Object { get; set; }
            public System.String InforNexus_Object { get; set; }
            public System.String Marketo_Object { get; set; }
            public System.String S3_BucketName { get; set; }
            public System.String S3_BucketPrefix { get; set; }
            public Amazon.Appflow.S3InputFileType S3InputFormatConfig_S3InputFileType { get; set; }
            public Amazon.Appflow.SalesforceDataTransferApi Salesforce_DataTransferApi { get; set; }
            public System.Boolean? Salesforce_EnableDynamicFieldUpdate { get; set; }
            public System.Boolean? Salesforce_IncludeDeletedRecord { get; set; }
            public System.String Salesforce_Object { get; set; }
            public System.String SAPOData_ObjectPath { get; set; }
            public System.String ServiceNow_Object { get; set; }
            public System.String Singular_Object { get; set; }
            public System.String Slack_Object { get; set; }
            public System.String Trendmicro_Object { get; set; }
            public System.String Veeva_DocumentType { get; set; }
            public System.Boolean? Veeva_IncludeAllVersion { get; set; }
            public System.Boolean? Veeva_IncludeRendition { get; set; }
            public System.Boolean? Veeva_IncludeSourceFile { get; set; }
            public System.String Veeva_Object { get; set; }
            public System.String Zendesk_Object { get; set; }
            public List<Amazon.Appflow.Model.Task> Task { get; set; }
            public Amazon.Appflow.DataPullMode Scheduled_DataPullMode { get; set; }
            public System.DateTime? Scheduled_FirstExecutionFrom { get; set; }
            public System.Int32? Scheduled_FlowErrorDeactivationThreshold { get; set; }
            public System.DateTime? Scheduled_ScheduleEndTime { get; set; }
            public System.String Scheduled_ScheduleExpression { get; set; }
            public System.Int64? Scheduled_ScheduleOffset { get; set; }
            public System.DateTime? Scheduled_ScheduleStartTime { get; set; }
            public System.String Scheduled_Timezone { get; set; }
            public Amazon.Appflow.TriggerType TriggerConfig_TriggerType { get; set; }
            public System.Func<Amazon.Appflow.Model.UpdateFlowResponse, UpdateAFFlowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FlowStatus;
        }
        
    }
}
