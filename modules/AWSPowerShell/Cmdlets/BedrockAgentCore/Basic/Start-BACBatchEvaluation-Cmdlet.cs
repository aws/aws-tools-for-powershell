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
using Amazon.BedrockAgentCore;
using Amazon.BedrockAgentCore.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAC
{
    /// <summary>
    /// Starts a batch evaluation job that evaluates agent performance across multiple sessions.
    /// Batch evaluations pull agent traces from CloudWatch Logs or an existing online evaluation
    /// configuration and run specified evaluators and insights against them.
    /// </summary>
    [Cmdlet("Start", "BACBatchEvaluation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCore.Model.StartBatchEvaluationResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer StartBatchEvaluation API operation.", Operation = new[] {"StartBatchEvaluation"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.StartBatchEvaluationResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.StartBatchEvaluationResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.Model.StartBatchEvaluationResponse object containing multiple properties."
    )]
    public partial class StartBACBatchEvaluationCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BatchEvaluationName
        /// <summary>
        /// <para>
        /// <para>The name of the batch evaluation. Must be unique within your account.</para>
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
        public System.String BatchEvaluationName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the batch evaluation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_EndTime
        /// <summary>
        /// <para>
        /// <para>The end time of the time range. Only sessions with activity before this timestamp
        /// are included.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? DataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_EndTime { get; set; }
        #endregion
        
        #region Parameter DataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_EndTime
        /// <summary>
        /// <para>
        /// <para>The end time of the time range. Only sessions with activity before this timestamp
        /// are included.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? DataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_EndTime { get; set; }
        #endregion
        
        #region Parameter Evaluator
        /// <summary>
        /// <para>
        /// <para>The list of evaluators to apply during the batch evaluation. Can include both built-in
        /// evaluators and custom evaluators. Maximum of 10 evaluators.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Evaluators")]
        public Amazon.BedrockAgentCore.Model.Evaluator[] Evaluator { get; set; }
        #endregion
        
        #region Parameter Insight
        /// <summary>
        /// <para>
        /// <para>The list of insight analyses to run against sessions during the batch evaluation.
        /// Maximum of 10 insights.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Insights")]
        public Amazon.BedrockAgentCore.Model.Insight[] Insight { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the KMS key used to encrypt evaluation data. If provided, customer data
        /// is encrypted at rest with the specified key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter DataSourceConfig_CloudWatchLogs_LogGroupName
        /// <summary>
        /// <para>
        /// <para>The list of CloudWatch log group names to read agent traces from. Maximum of 5 log
        /// groups.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfig_CloudWatchLogs_LogGroupNames")]
        public System.String[] DataSourceConfig_CloudWatchLogs_LogGroupName { get; set; }
        #endregion
        
        #region Parameter DataSourceConfig_OnlineEvaluationConfigSource_OnlineEvaluationConfigArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the online evaluation configuration to use as the
        /// session source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSourceConfig_OnlineEvaluationConfigSource_OnlineEvaluationConfigArn { get; set; }
        #endregion
        
        #region Parameter DataSourceConfig_CloudWatchLogs_ServiceName
        /// <summary>
        /// <para>
        /// <para>The list of agent service names to filter traces within the specified log groups.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfig_CloudWatchLogs_ServiceNames")]
        public System.String[] DataSourceConfig_CloudWatchLogs_ServiceName { get; set; }
        #endregion
        
        #region Parameter DataSourceConfig_CloudWatchLogs_FilterConfig_SessionId
        /// <summary>
        /// <para>
        /// <para>A list of specific session IDs to evaluate. If specified, only these sessions are
        /// included in the evaluation.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfig_CloudWatchLogs_FilterConfig_SessionIds")]
        public System.String[] DataSourceConfig_CloudWatchLogs_FilterConfig_SessionId { get; set; }
        #endregion
        
        #region Parameter EvaluationMetadata_SessionMetadata
        /// <summary>
        /// <para>
        /// <para>A list of session metadata entries containing ground truth data and test scenario
        /// identifiers for specific sessions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.BedrockAgentCore.Model.SessionMetadataShape[] EvaluationMetadata_SessionMetadata { get; set; }
        #endregion
        
        #region Parameter DataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_StartTime
        /// <summary>
        /// <para>
        /// <para>The start time of the time range. Only sessions with activity at or after this timestamp
        /// are included.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? DataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_StartTime { get; set; }
        #endregion
        
        #region Parameter DataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_StartTime
        /// <summary>
        /// <para>
        /// <para>The start time of the time range. Only sessions with activity at or after this timestamp
        /// are included.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? DataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_StartTime { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of tag keys and values to associate with the batch evaluation.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the API request completes no more
        /// than one time. If this token matches a previous request, the service ignores the request,
        /// but does not return an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.StartBatchEvaluationResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.StartBatchEvaluationResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BatchEvaluationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-BACBatchEvaluation (StartBatchEvaluation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.StartBatchEvaluationResponse, StartBACBatchEvaluationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BatchEvaluationName = this.BatchEvaluationName;
            #if MODULAR
            if (this.BatchEvaluationName == null && ParameterWasBound(nameof(this.BatchEvaluationName)))
            {
                WriteWarning("You are passing $null as a value for parameter BatchEvaluationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            if (this.DataSourceConfig_CloudWatchLogs_FilterConfig_SessionId != null)
            {
                context.DataSourceConfig_CloudWatchLogs_FilterConfig_SessionId = new List<System.String>(this.DataSourceConfig_CloudWatchLogs_FilterConfig_SessionId);
            }
            context.DataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_EndTime = this.DataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_EndTime;
            context.DataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_StartTime = this.DataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_StartTime;
            if (this.DataSourceConfig_CloudWatchLogs_LogGroupName != null)
            {
                context.DataSourceConfig_CloudWatchLogs_LogGroupName = new List<System.String>(this.DataSourceConfig_CloudWatchLogs_LogGroupName);
            }
            if (this.DataSourceConfig_CloudWatchLogs_ServiceName != null)
            {
                context.DataSourceConfig_CloudWatchLogs_ServiceName = new List<System.String>(this.DataSourceConfig_CloudWatchLogs_ServiceName);
            }
            context.DataSourceConfig_OnlineEvaluationConfigSource_OnlineEvaluationConfigArn = this.DataSourceConfig_OnlineEvaluationConfigSource_OnlineEvaluationConfigArn;
            context.DataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_EndTime = this.DataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_EndTime;
            context.DataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_StartTime = this.DataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_StartTime;
            context.Description = this.Description;
            if (this.EvaluationMetadata_SessionMetadata != null)
            {
                context.EvaluationMetadata_SessionMetadata = new List<Amazon.BedrockAgentCore.Model.SessionMetadataShape>(this.EvaluationMetadata_SessionMetadata);
            }
            if (this.Evaluator != null)
            {
                context.Evaluator = new List<Amazon.BedrockAgentCore.Model.Evaluator>(this.Evaluator);
            }
            if (this.Insight != null)
            {
                context.Insight = new List<Amazon.BedrockAgentCore.Model.Insight>(this.Insight);
            }
            context.KmsKeyArn = this.KmsKeyArn;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.BedrockAgentCore.Model.StartBatchEvaluationRequest();
            
            if (cmdletContext.BatchEvaluationName != null)
            {
                request.BatchEvaluationName = cmdletContext.BatchEvaluationName;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate DataSourceConfig
            var requestDataSourceConfigIsNull = true;
            request.DataSourceConfig = new Amazon.BedrockAgentCore.Model.DataSourceConfig();
            Amazon.BedrockAgentCore.Model.OnlineEvaluationConfigSource requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource = null;
            
             // populate OnlineEvaluationConfigSource
            var requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSourceIsNull = true;
            requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource = new Amazon.BedrockAgentCore.Model.OnlineEvaluationConfigSource();
            System.String requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_OnlineEvaluationConfigArn = null;
            if (cmdletContext.DataSourceConfig_OnlineEvaluationConfigSource_OnlineEvaluationConfigArn != null)
            {
                requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_OnlineEvaluationConfigArn = cmdletContext.DataSourceConfig_OnlineEvaluationConfigSource_OnlineEvaluationConfigArn;
            }
            if (requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_OnlineEvaluationConfigArn != null)
            {
                requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource.OnlineEvaluationConfigArn = requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_OnlineEvaluationConfigArn;
                requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSourceIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.SessionFilterConfig requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig = null;
            
             // populate SessionFilterConfig
            var requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfigIsNull = true;
            requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig = new Amazon.BedrockAgentCore.Model.SessionFilterConfig();
            System.DateTime? requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_EndTime = null;
            if (cmdletContext.DataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_EndTime != null)
            {
                requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_EndTime = cmdletContext.DataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_EndTime.Value;
            }
            if (requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_EndTime != null)
            {
                requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig.EndTime = requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_EndTime.Value;
                requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfigIsNull = false;
            }
            System.DateTime? requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_StartTime = null;
            if (cmdletContext.DataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_StartTime != null)
            {
                requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_StartTime = cmdletContext.DataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_StartTime.Value;
            }
            if (requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_StartTime != null)
            {
                requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig.StartTime = requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_StartTime.Value;
                requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfigIsNull = false;
            }
             // determine if requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig should be set to null
            if (requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfigIsNull)
            {
                requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig = null;
            }
            if (requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig != null)
            {
                requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource.SessionFilterConfig = requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource_dataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig;
                requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSourceIsNull = false;
            }
             // determine if requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource should be set to null
            if (requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSourceIsNull)
            {
                requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource = null;
            }
            if (requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource != null)
            {
                request.DataSourceConfig.OnlineEvaluationConfigSource = requestDataSourceConfig_dataSourceConfig_OnlineEvaluationConfigSource;
                requestDataSourceConfigIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.CloudWatchLogsSource requestDataSourceConfig_dataSourceConfig_CloudWatchLogs = null;
            
             // populate CloudWatchLogs
            var requestDataSourceConfig_dataSourceConfig_CloudWatchLogsIsNull = true;
            requestDataSourceConfig_dataSourceConfig_CloudWatchLogs = new Amazon.BedrockAgentCore.Model.CloudWatchLogsSource();
            List<System.String> requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_LogGroupName = null;
            if (cmdletContext.DataSourceConfig_CloudWatchLogs_LogGroupName != null)
            {
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_LogGroupName = cmdletContext.DataSourceConfig_CloudWatchLogs_LogGroupName;
            }
            if (requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_LogGroupName != null)
            {
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs.LogGroupNames = requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_LogGroupName;
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogsIsNull = false;
            }
            List<System.String> requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_ServiceName = null;
            if (cmdletContext.DataSourceConfig_CloudWatchLogs_ServiceName != null)
            {
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_ServiceName = cmdletContext.DataSourceConfig_CloudWatchLogs_ServiceName;
            }
            if (requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_ServiceName != null)
            {
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs.ServiceNames = requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_ServiceName;
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogsIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.CloudWatchFilterConfig requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig = null;
            
             // populate FilterConfig
            var requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfigIsNull = true;
            requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig = new Amazon.BedrockAgentCore.Model.CloudWatchFilterConfig();
            List<System.String> requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_SessionId = null;
            if (cmdletContext.DataSourceConfig_CloudWatchLogs_FilterConfig_SessionId != null)
            {
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_SessionId = cmdletContext.DataSourceConfig_CloudWatchLogs_FilterConfig_SessionId;
            }
            if (requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_SessionId != null)
            {
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig.SessionIds = requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_SessionId;
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfigIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.SessionFilterConfig requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange = null;
            
             // populate TimeRange
            var requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRangeIsNull = true;
            requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange = new Amazon.BedrockAgentCore.Model.SessionFilterConfig();
            System.DateTime? requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_EndTime = null;
            if (cmdletContext.DataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_EndTime != null)
            {
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_EndTime = cmdletContext.DataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_EndTime.Value;
            }
            if (requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_EndTime != null)
            {
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange.EndTime = requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_EndTime.Value;
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRangeIsNull = false;
            }
            System.DateTime? requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_StartTime = null;
            if (cmdletContext.DataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_StartTime != null)
            {
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_StartTime = cmdletContext.DataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_StartTime.Value;
            }
            if (requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_StartTime != null)
            {
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange.StartTime = requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_StartTime.Value;
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRangeIsNull = false;
            }
             // determine if requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange should be set to null
            if (requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRangeIsNull)
            {
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange = null;
            }
            if (requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange != null)
            {
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig.TimeRange = requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig_dataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange;
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfigIsNull = false;
            }
             // determine if requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig should be set to null
            if (requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfigIsNull)
            {
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig = null;
            }
            if (requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig != null)
            {
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs.FilterConfig = requestDataSourceConfig_dataSourceConfig_CloudWatchLogs_dataSourceConfig_CloudWatchLogs_FilterConfig;
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogsIsNull = false;
            }
             // determine if requestDataSourceConfig_dataSourceConfig_CloudWatchLogs should be set to null
            if (requestDataSourceConfig_dataSourceConfig_CloudWatchLogsIsNull)
            {
                requestDataSourceConfig_dataSourceConfig_CloudWatchLogs = null;
            }
            if (requestDataSourceConfig_dataSourceConfig_CloudWatchLogs != null)
            {
                request.DataSourceConfig.CloudWatchLogs = requestDataSourceConfig_dataSourceConfig_CloudWatchLogs;
                requestDataSourceConfigIsNull = false;
            }
             // determine if request.DataSourceConfig should be set to null
            if (requestDataSourceConfigIsNull)
            {
                request.DataSourceConfig = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate EvaluationMetadata
            var requestEvaluationMetadataIsNull = true;
            request.EvaluationMetadata = new Amazon.BedrockAgentCore.Model.EvaluationMetadata();
            List<Amazon.BedrockAgentCore.Model.SessionMetadataShape> requestEvaluationMetadata_evaluationMetadata_SessionMetadata = null;
            if (cmdletContext.EvaluationMetadata_SessionMetadata != null)
            {
                requestEvaluationMetadata_evaluationMetadata_SessionMetadata = cmdletContext.EvaluationMetadata_SessionMetadata;
            }
            if (requestEvaluationMetadata_evaluationMetadata_SessionMetadata != null)
            {
                request.EvaluationMetadata.SessionMetadata = requestEvaluationMetadata_evaluationMetadata_SessionMetadata;
                requestEvaluationMetadataIsNull = false;
            }
             // determine if request.EvaluationMetadata should be set to null
            if (requestEvaluationMetadataIsNull)
            {
                request.EvaluationMetadata = null;
            }
            if (cmdletContext.Evaluator != null)
            {
                request.Evaluators = cmdletContext.Evaluator;
            }
            if (cmdletContext.Insight != null)
            {
                request.Insights = cmdletContext.Insight;
            }
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
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
        
        private Amazon.BedrockAgentCore.Model.StartBatchEvaluationResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.StartBatchEvaluationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "StartBatchEvaluation");
            try
            {
                return client.StartBatchEvaluationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BatchEvaluationName { get; set; }
            public System.String ClientToken { get; set; }
            public List<System.String> DataSourceConfig_CloudWatchLogs_FilterConfig_SessionId { get; set; }
            public System.DateTime? DataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_EndTime { get; set; }
            public System.DateTime? DataSourceConfig_CloudWatchLogs_FilterConfig_TimeRange_StartTime { get; set; }
            public List<System.String> DataSourceConfig_CloudWatchLogs_LogGroupName { get; set; }
            public List<System.String> DataSourceConfig_CloudWatchLogs_ServiceName { get; set; }
            public System.String DataSourceConfig_OnlineEvaluationConfigSource_OnlineEvaluationConfigArn { get; set; }
            public System.DateTime? DataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_EndTime { get; set; }
            public System.DateTime? DataSourceConfig_OnlineEvaluationConfigSource_SessionFilterConfig_StartTime { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.BedrockAgentCore.Model.SessionMetadataShape> EvaluationMetadata_SessionMetadata { get; set; }
            public List<Amazon.BedrockAgentCore.Model.Evaluator> Evaluator { get; set; }
            public List<Amazon.BedrockAgentCore.Model.Insight> Insight { get; set; }
            public System.String KmsKeyArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.StartBatchEvaluationResponse, StartBACBatchEvaluationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
