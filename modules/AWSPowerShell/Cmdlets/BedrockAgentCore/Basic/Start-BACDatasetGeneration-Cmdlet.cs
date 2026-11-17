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
    /// Starts a dataset generation, which creates examples for an existing dataset from your
    /// agent's traces. The dataset must be <c>ACTIVE</c>. Each generation produces one scenario
    /// type, set by <c>scenarioType</c>. When the generation finishes, AgentCore adds the
    /// examples to the dataset's draft. Examples that duplicate each other, or that duplicate
    /// examples already in the draft, are left out.
    /// 
    ///  
    /// <para>
    /// A dataset can have only one generation in progress at a time. While it runs, requests
    /// that change the dataset's draft or publish a version are rejected with a <c>ConflictException</c>.
    /// </para><para>
    /// AgentCore reads the traces with your credentials, so you need read access to the trace
    /// log groups, and to the dataset's KMS key if the dataset uses a customer managed key.
    /// The draft can hold at most 1,000 examples, including the examples this generation
    /// can add (<c>maxScenarios</c>).
    /// </para><para>
    /// The operation returns immediately. To track progress, call <c>GetDatasetGeneration</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "BACDatasetGeneration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCore.Model.StartDatasetGenerationResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore StartDatasetGeneration API operation.", Operation = new[] {"StartDatasetGeneration"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.StartDatasetGenerationResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.StartDatasetGenerationResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.Model.StartDatasetGenerationResponse object containing multiple properties."
    )]
    public partial class StartBACDatasetGenerationCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Source_TraceGeneration_Selection_Filters_AttributeFilter
        /// <summary>
        /// <para>
        /// <para>Attribute conditions, up to 5. A session must meet all of them. An attribute on a
        /// span matches when any span in the session meets the condition.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_TraceGeneration_Selection_Filters_AttributeFilters")]
        public Amazon.BedrockAgentCore.Model.GenerationAttributeFilter[] Source_TraceGeneration_Selection_Filters_AttributeFilter { get; set; }
        #endregion
        
        #region Parameter Source_TraceGeneration_SourceConfig_BatchEvaluation_BatchEvaluationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the batch evaluation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_TraceGeneration_SourceConfig_BatchEvaluation_BatchEvaluationArn { get; set; }
        #endregion
        
        #region Parameter Source_TraceGeneration_RedactionConfiguration_CustomDataIdentifier
        /// <summary>
        /// <para>
        /// <para>Custom data identifiers to apply, up to 10. You can use custom identifiers without
        /// any managed identifiers.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_TraceGeneration_RedactionConfiguration_CustomDataIdentifiers")]
        public Amazon.BedrockAgentCore.Model.CustomDataIdentifier[] Source_TraceGeneration_RedactionConfiguration_CustomDataIdentifier { get; set; }
        #endregion
        
        #region Parameter DatasetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the dataset to add the generated examples to. The dataset
        /// must be <c>ACTIVE</c>.</para>
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
        public System.String DatasetId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the dataset generation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Source_TraceGeneration_SourceConfig_CloudWatchLogs_EndTime
        /// <summary>
        /// <para>
        /// <para>The end of the time window to read sessions from. The default is the time the generation
        /// starts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Source_TraceGeneration_SourceConfig_CloudWatchLogs_EndTime { get; set; }
        #endregion
        
        #region Parameter Source_TraceGeneration_SourceConfig_OnlineEvaluation_EndTime
        /// <summary>
        /// <para>
        /// <para>The end of the time window to read sessions from. The default is the time the generation
        /// starts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Source_TraceGeneration_SourceConfig_OnlineEvaluation_EndTime { get; set; }
        #endregion
        
        #region Parameter Source_TraceGeneration_Selection_Filters_EvaluatorFilter
        /// <summary>
        /// <para>
        /// <para>Conditions on evaluation results, up to 10. A session must meet all of them. You can
        /// use these only with an <c>onlineEvaluation</c> or <c>batchEvaluation</c> source. A
        /// <c>cloudWatchLogs</c> source has no evaluation results.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_TraceGeneration_Selection_Filters_EvaluatorFilters")]
        public Amazon.BedrockAgentCore.Model.EvaluatorFilter[] Source_TraceGeneration_Selection_Filters_EvaluatorFilter { get; set; }
        #endregion
        
        #region Parameter Source_TraceGeneration_GroundTruth_Field
        /// <summary>
        /// <para>
        /// <para>The reference fields to copy. Values are copied from the session as observed, not
        /// generated.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_TraceGeneration_GroundTruth_Fields")]
        public System.String[] Source_TraceGeneration_GroundTruth_Field { get; set; }
        #endregion
        
        #region Parameter Source_TraceGeneration_RedactionConfiguration_Identifier
        /// <summary>
        /// <para>
        /// <para>The managed data identifiers to apply. These match the CloudWatch Logs managed data
        /// identifiers.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_TraceGeneration_RedactionConfiguration_Identifiers")]
        public System.String[] Source_TraceGeneration_RedactionConfiguration_Identifier { get; set; }
        #endregion
        
        #region Parameter Source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupNamePrefix
        /// <summary>
        /// <para>
        /// <para>Prefixes of the names of the log groups to read, from 1 to 5. You can't specify this
        /// together with <c>logGroupNames</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupNamePrefixes")]
        public System.String[] Source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupNamePrefix { get; set; }
        #endregion
        
        #region Parameter Source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupName
        /// <summary>
        /// <para>
        /// <para>The names of the log groups to read, from 1 to 5. You can't specify this together
        /// with <c>logGroupNamePrefixes</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupNames")]
        public System.String[] Source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupName { get; set; }
        #endregion
        
        #region Parameter Source_TraceGeneration_Selection_Filters_TurnCount_Max
        /// <summary>
        /// <para>
        /// <para>The maximum number of turns. The default is 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Source_TraceGeneration_Selection_Filters_TurnCount_Max { get; set; }
        #endregion
        
        #region Parameter Source_TraceGeneration_Sampling_MaxScenario
        /// <summary>
        /// <para>
        /// <para>The maximum number of scenarios to generate, from 1 to 1,000. The default is 100.
        /// The generation produces at most one scenario for each selected session. The dataset's
        /// draft examples plus this value can't be more than 1,000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_TraceGeneration_Sampling_MaxScenarios")]
        public System.Int32? Source_TraceGeneration_Sampling_MaxScenario { get; set; }
        #endregion
        
        #region Parameter Source_TraceGeneration_Selection_Filters_TurnCount_Min
        /// <summary>
        /// <para>
        /// <para>The minimum number of turns.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Source_TraceGeneration_Selection_Filters_TurnCount_Min { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the dataset generation. The generation ID starts with this name.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Source_TraceGeneration_SourceConfig_OnlineEvaluation_OnlineEvaluationConfigArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the online evaluation configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_TraceGeneration_SourceConfig_OnlineEvaluation_OnlineEvaluationConfigArn { get; set; }
        #endregion
        
        #region Parameter Source_TraceGeneration_GroundTruth_QualityFilter
        /// <summary>
        /// <para>
        /// <para>Evaluator conditions that a selected session must also meet to have reference fields
        /// copied. If you don't specify these, the generation uses the evaluator filters from
        /// <c>selection</c>. If the selection names sessions and traces by ID, every selected
        /// session gets reference fields. Specify an empty list to give every selected session
        /// reference fields. You can't specify quality filters with a <c>cloudWatchLogs</c> source.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_TraceGeneration_GroundTruth_QualityFilters")]
        public Amazon.BedrockAgentCore.Model.EvaluatorFilter[] Source_TraceGeneration_GroundTruth_QualityFilter { get; set; }
        #endregion
        
        #region Parameter ScenarioType
        /// <summary>
        /// <para>
        /// <para>The type of scenario to generate. If you don't specify a value, the generation produces
        /// <c>DYNAMIC</c> scenarios.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCore.ScenarioType")]
        public Amazon.BedrockAgentCore.ScenarioType ScenarioType { get; set; }
        #endregion
        
        #region Parameter Source_TraceGeneration_SourceConfig_CloudWatchLogs_ServiceName
        /// <summary>
        /// <para>
        /// <para>The service name of the agent, which matches the <c>service.name</c> resource attribute
        /// in its traces. Specify exactly one.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_TraceGeneration_SourceConfig_CloudWatchLogs_ServiceNames")]
        public System.String[] Source_TraceGeneration_SourceConfig_CloudWatchLogs_ServiceName { get; set; }
        #endregion
        
        #region Parameter Source_TraceGeneration_Selection_Identifiers_SessionId
        /// <summary>
        /// <para>
        /// <para>The IDs of the sessions to use, up to 25.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_TraceGeneration_Selection_Identifiers_SessionIds")]
        public System.String[] Source_TraceGeneration_Selection_Identifiers_SessionId { get; set; }
        #endregion
        
        #region Parameter Source_TraceGeneration_SourceConfig_CloudWatchLogs_StartTime
        /// <summary>
        /// <para>
        /// <para>The start of the time window to read sessions from. The default is 7 days before <c>endTime</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Source_TraceGeneration_SourceConfig_CloudWatchLogs_StartTime { get; set; }
        #endregion
        
        #region Parameter Source_TraceGeneration_SourceConfig_OnlineEvaluation_StartTime
        /// <summary>
        /// <para>
        /// <para>The start of the time window to read sessions from. The default is 7 days before <c>endTime</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Source_TraceGeneration_SourceConfig_OnlineEvaluation_StartTime { get; set; }
        #endregion
        
        #region Parameter Source_TraceGeneration_Selection_Identifiers_TraceId
        /// <summary>
        /// <para>
        /// <para>The IDs of the traces to use, up to 25.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_TraceGeneration_Selection_Identifiers_TraceIds")]
        public System.String[] Source_TraceGeneration_Selection_Identifiers_TraceId { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.StartDatasetGenerationResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.StartDatasetGenerationResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.DatasetId),
                nameof(this.Name)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-BACDatasetGeneration (StartDatasetGeneration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.StartDatasetGenerationResponse, StartBACDatasetGenerationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DatasetId = this.DatasetId;
            #if MODULAR
            if (this.DatasetId == null && ParameterWasBound(nameof(this.DatasetId)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScenarioType = this.ScenarioType;
            if (this.Source_TraceGeneration_GroundTruth_Field != null)
            {
                context.Source_TraceGeneration_GroundTruth_Field = new List<System.String>(this.Source_TraceGeneration_GroundTruth_Field);
            }
            if (this.Source_TraceGeneration_GroundTruth_QualityFilter != null)
            {
                context.Source_TraceGeneration_GroundTruth_QualityFilter = new List<Amazon.BedrockAgentCore.Model.EvaluatorFilter>(this.Source_TraceGeneration_GroundTruth_QualityFilter);
            }
            if (this.Source_TraceGeneration_RedactionConfiguration_CustomDataIdentifier != null)
            {
                context.Source_TraceGeneration_RedactionConfiguration_CustomDataIdentifier = new List<Amazon.BedrockAgentCore.Model.CustomDataIdentifier>(this.Source_TraceGeneration_RedactionConfiguration_CustomDataIdentifier);
            }
            if (this.Source_TraceGeneration_RedactionConfiguration_Identifier != null)
            {
                context.Source_TraceGeneration_RedactionConfiguration_Identifier = new List<System.String>(this.Source_TraceGeneration_RedactionConfiguration_Identifier);
            }
            context.Source_TraceGeneration_Sampling_MaxScenario = this.Source_TraceGeneration_Sampling_MaxScenario;
            if (this.Source_TraceGeneration_Selection_Filters_AttributeFilter != null)
            {
                context.Source_TraceGeneration_Selection_Filters_AttributeFilter = new List<Amazon.BedrockAgentCore.Model.GenerationAttributeFilter>(this.Source_TraceGeneration_Selection_Filters_AttributeFilter);
            }
            if (this.Source_TraceGeneration_Selection_Filters_EvaluatorFilter != null)
            {
                context.Source_TraceGeneration_Selection_Filters_EvaluatorFilter = new List<Amazon.BedrockAgentCore.Model.EvaluatorFilter>(this.Source_TraceGeneration_Selection_Filters_EvaluatorFilter);
            }
            context.Source_TraceGeneration_Selection_Filters_TurnCount_Max = this.Source_TraceGeneration_Selection_Filters_TurnCount_Max;
            context.Source_TraceGeneration_Selection_Filters_TurnCount_Min = this.Source_TraceGeneration_Selection_Filters_TurnCount_Min;
            if (this.Source_TraceGeneration_Selection_Identifiers_SessionId != null)
            {
                context.Source_TraceGeneration_Selection_Identifiers_SessionId = new List<System.String>(this.Source_TraceGeneration_Selection_Identifiers_SessionId);
            }
            if (this.Source_TraceGeneration_Selection_Identifiers_TraceId != null)
            {
                context.Source_TraceGeneration_Selection_Identifiers_TraceId = new List<System.String>(this.Source_TraceGeneration_Selection_Identifiers_TraceId);
            }
            context.Source_TraceGeneration_SourceConfig_BatchEvaluation_BatchEvaluationArn = this.Source_TraceGeneration_SourceConfig_BatchEvaluation_BatchEvaluationArn;
            context.Source_TraceGeneration_SourceConfig_CloudWatchLogs_EndTime = this.Source_TraceGeneration_SourceConfig_CloudWatchLogs_EndTime;
            if (this.Source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupNamePrefix != null)
            {
                context.Source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupNamePrefix = new List<System.String>(this.Source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupNamePrefix);
            }
            if (this.Source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupName != null)
            {
                context.Source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupName = new List<System.String>(this.Source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupName);
            }
            if (this.Source_TraceGeneration_SourceConfig_CloudWatchLogs_ServiceName != null)
            {
                context.Source_TraceGeneration_SourceConfig_CloudWatchLogs_ServiceName = new List<System.String>(this.Source_TraceGeneration_SourceConfig_CloudWatchLogs_ServiceName);
            }
            context.Source_TraceGeneration_SourceConfig_CloudWatchLogs_StartTime = this.Source_TraceGeneration_SourceConfig_CloudWatchLogs_StartTime;
            context.Source_TraceGeneration_SourceConfig_OnlineEvaluation_EndTime = this.Source_TraceGeneration_SourceConfig_OnlineEvaluation_EndTime;
            context.Source_TraceGeneration_SourceConfig_OnlineEvaluation_OnlineEvaluationConfigArn = this.Source_TraceGeneration_SourceConfig_OnlineEvaluation_OnlineEvaluationConfigArn;
            context.Source_TraceGeneration_SourceConfig_OnlineEvaluation_StartTime = this.Source_TraceGeneration_SourceConfig_OnlineEvaluation_StartTime;
            
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
            var request = new Amazon.BedrockAgentCore.Model.StartDatasetGenerationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DatasetId != null)
            {
                request.DatasetId = cmdletContext.DatasetId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ScenarioType != null)
            {
                request.ScenarioType = cmdletContext.ScenarioType;
            }
            
             // populate Source
            var requestSourceIsNull = true;
            request.Source = new Amazon.BedrockAgentCore.Model.GenerationSource();
            Amazon.BedrockAgentCore.Model.TraceGenerationSource requestSource_source_TraceGeneration = null;
            
             // populate TraceGeneration
            var requestSource_source_TraceGenerationIsNull = true;
            requestSource_source_TraceGeneration = new Amazon.BedrockAgentCore.Model.TraceGenerationSource();
            Amazon.BedrockAgentCore.Model.GenerationSamplingConfig requestSource_source_TraceGeneration_source_TraceGeneration_Sampling = null;
            
             // populate Sampling
            var requestSource_source_TraceGeneration_source_TraceGeneration_SamplingIsNull = true;
            requestSource_source_TraceGeneration_source_TraceGeneration_Sampling = new Amazon.BedrockAgentCore.Model.GenerationSamplingConfig();
            System.Int32? requestSource_source_TraceGeneration_source_TraceGeneration_Sampling_source_TraceGeneration_Sampling_MaxScenario = null;
            if (cmdletContext.Source_TraceGeneration_Sampling_MaxScenario != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_Sampling_source_TraceGeneration_Sampling_MaxScenario = cmdletContext.Source_TraceGeneration_Sampling_MaxScenario.Value;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_Sampling_source_TraceGeneration_Sampling_MaxScenario != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_Sampling.MaxScenarios = requestSource_source_TraceGeneration_source_TraceGeneration_Sampling_source_TraceGeneration_Sampling_MaxScenario.Value;
                requestSource_source_TraceGeneration_source_TraceGeneration_SamplingIsNull = false;
            }
             // determine if requestSource_source_TraceGeneration_source_TraceGeneration_Sampling should be set to null
            if (requestSource_source_TraceGeneration_source_TraceGeneration_SamplingIsNull)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_Sampling = null;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_Sampling != null)
            {
                requestSource_source_TraceGeneration.Sampling = requestSource_source_TraceGeneration_source_TraceGeneration_Sampling;
                requestSource_source_TraceGenerationIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.GroundTruthConfig requestSource_source_TraceGeneration_source_TraceGeneration_GroundTruth = null;
            
             // populate GroundTruth
            var requestSource_source_TraceGeneration_source_TraceGeneration_GroundTruthIsNull = true;
            requestSource_source_TraceGeneration_source_TraceGeneration_GroundTruth = new Amazon.BedrockAgentCore.Model.GroundTruthConfig();
            List<System.String> requestSource_source_TraceGeneration_source_TraceGeneration_GroundTruth_source_TraceGeneration_GroundTruth_Field = null;
            if (cmdletContext.Source_TraceGeneration_GroundTruth_Field != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_GroundTruth_source_TraceGeneration_GroundTruth_Field = cmdletContext.Source_TraceGeneration_GroundTruth_Field;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_GroundTruth_source_TraceGeneration_GroundTruth_Field != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_GroundTruth.Fields = requestSource_source_TraceGeneration_source_TraceGeneration_GroundTruth_source_TraceGeneration_GroundTruth_Field;
                requestSource_source_TraceGeneration_source_TraceGeneration_GroundTruthIsNull = false;
            }
            List<Amazon.BedrockAgentCore.Model.EvaluatorFilter> requestSource_source_TraceGeneration_source_TraceGeneration_GroundTruth_source_TraceGeneration_GroundTruth_QualityFilter = null;
            if (cmdletContext.Source_TraceGeneration_GroundTruth_QualityFilter != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_GroundTruth_source_TraceGeneration_GroundTruth_QualityFilter = cmdletContext.Source_TraceGeneration_GroundTruth_QualityFilter;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_GroundTruth_source_TraceGeneration_GroundTruth_QualityFilter != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_GroundTruth.QualityFilters = requestSource_source_TraceGeneration_source_TraceGeneration_GroundTruth_source_TraceGeneration_GroundTruth_QualityFilter;
                requestSource_source_TraceGeneration_source_TraceGeneration_GroundTruthIsNull = false;
            }
             // determine if requestSource_source_TraceGeneration_source_TraceGeneration_GroundTruth should be set to null
            if (requestSource_source_TraceGeneration_source_TraceGeneration_GroundTruthIsNull)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_GroundTruth = null;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_GroundTruth != null)
            {
                requestSource_source_TraceGeneration.GroundTruth = requestSource_source_TraceGeneration_source_TraceGeneration_GroundTruth;
                requestSource_source_TraceGenerationIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.RedactionConfiguration requestSource_source_TraceGeneration_source_TraceGeneration_RedactionConfiguration = null;
            
             // populate RedactionConfiguration
            var requestSource_source_TraceGeneration_source_TraceGeneration_RedactionConfigurationIsNull = true;
            requestSource_source_TraceGeneration_source_TraceGeneration_RedactionConfiguration = new Amazon.BedrockAgentCore.Model.RedactionConfiguration();
            List<Amazon.BedrockAgentCore.Model.CustomDataIdentifier> requestSource_source_TraceGeneration_source_TraceGeneration_RedactionConfiguration_source_TraceGeneration_RedactionConfiguration_CustomDataIdentifier = null;
            if (cmdletContext.Source_TraceGeneration_RedactionConfiguration_CustomDataIdentifier != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_RedactionConfiguration_source_TraceGeneration_RedactionConfiguration_CustomDataIdentifier = cmdletContext.Source_TraceGeneration_RedactionConfiguration_CustomDataIdentifier;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_RedactionConfiguration_source_TraceGeneration_RedactionConfiguration_CustomDataIdentifier != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_RedactionConfiguration.CustomDataIdentifiers = requestSource_source_TraceGeneration_source_TraceGeneration_RedactionConfiguration_source_TraceGeneration_RedactionConfiguration_CustomDataIdentifier;
                requestSource_source_TraceGeneration_source_TraceGeneration_RedactionConfigurationIsNull = false;
            }
            List<System.String> requestSource_source_TraceGeneration_source_TraceGeneration_RedactionConfiguration_source_TraceGeneration_RedactionConfiguration_Identifier = null;
            if (cmdletContext.Source_TraceGeneration_RedactionConfiguration_Identifier != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_RedactionConfiguration_source_TraceGeneration_RedactionConfiguration_Identifier = cmdletContext.Source_TraceGeneration_RedactionConfiguration_Identifier;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_RedactionConfiguration_source_TraceGeneration_RedactionConfiguration_Identifier != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_RedactionConfiguration.Identifiers = requestSource_source_TraceGeneration_source_TraceGeneration_RedactionConfiguration_source_TraceGeneration_RedactionConfiguration_Identifier;
                requestSource_source_TraceGeneration_source_TraceGeneration_RedactionConfigurationIsNull = false;
            }
             // determine if requestSource_source_TraceGeneration_source_TraceGeneration_RedactionConfiguration should be set to null
            if (requestSource_source_TraceGeneration_source_TraceGeneration_RedactionConfigurationIsNull)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_RedactionConfiguration = null;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_RedactionConfiguration != null)
            {
                requestSource_source_TraceGeneration.RedactionConfiguration = requestSource_source_TraceGeneration_source_TraceGeneration_RedactionConfiguration;
                requestSource_source_TraceGenerationIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.GenerationSelection requestSource_source_TraceGeneration_source_TraceGeneration_Selection = null;
            
             // populate Selection
            var requestSource_source_TraceGeneration_source_TraceGeneration_SelectionIsNull = true;
            requestSource_source_TraceGeneration_source_TraceGeneration_Selection = new Amazon.BedrockAgentCore.Model.GenerationSelection();
            Amazon.BedrockAgentCore.Model.GenerationIdentifiers requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Identifiers = null;
            
             // populate Identifiers
            var requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_IdentifiersIsNull = true;
            requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Identifiers = new Amazon.BedrockAgentCore.Model.GenerationIdentifiers();
            List<System.String> requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Identifiers_source_TraceGeneration_Selection_Identifiers_SessionId = null;
            if (cmdletContext.Source_TraceGeneration_Selection_Identifiers_SessionId != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Identifiers_source_TraceGeneration_Selection_Identifiers_SessionId = cmdletContext.Source_TraceGeneration_Selection_Identifiers_SessionId;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Identifiers_source_TraceGeneration_Selection_Identifiers_SessionId != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Identifiers.SessionIds = requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Identifiers_source_TraceGeneration_Selection_Identifiers_SessionId;
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_IdentifiersIsNull = false;
            }
            List<System.String> requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Identifiers_source_TraceGeneration_Selection_Identifiers_TraceId = null;
            if (cmdletContext.Source_TraceGeneration_Selection_Identifiers_TraceId != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Identifiers_source_TraceGeneration_Selection_Identifiers_TraceId = cmdletContext.Source_TraceGeneration_Selection_Identifiers_TraceId;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Identifiers_source_TraceGeneration_Selection_Identifiers_TraceId != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Identifiers.TraceIds = requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Identifiers_source_TraceGeneration_Selection_Identifiers_TraceId;
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_IdentifiersIsNull = false;
            }
             // determine if requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Identifiers should be set to null
            if (requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_IdentifiersIsNull)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Identifiers = null;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Identifiers != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection.Identifiers = requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Identifiers;
                requestSource_source_TraceGeneration_source_TraceGeneration_SelectionIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.GenerationFilters requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters = null;
            
             // populate Filters
            var requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_FiltersIsNull = true;
            requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters = new Amazon.BedrockAgentCore.Model.GenerationFilters();
            List<Amazon.BedrockAgentCore.Model.GenerationAttributeFilter> requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_AttributeFilter = null;
            if (cmdletContext.Source_TraceGeneration_Selection_Filters_AttributeFilter != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_AttributeFilter = cmdletContext.Source_TraceGeneration_Selection_Filters_AttributeFilter;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_AttributeFilter != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters.AttributeFilters = requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_AttributeFilter;
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_FiltersIsNull = false;
            }
            List<Amazon.BedrockAgentCore.Model.EvaluatorFilter> requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_EvaluatorFilter = null;
            if (cmdletContext.Source_TraceGeneration_Selection_Filters_EvaluatorFilter != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_EvaluatorFilter = cmdletContext.Source_TraceGeneration_Selection_Filters_EvaluatorFilter;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_EvaluatorFilter != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters.EvaluatorFilters = requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_EvaluatorFilter;
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_FiltersIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.TurnCountRange requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_TurnCount = null;
            
             // populate TurnCount
            var requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_TurnCountIsNull = true;
            requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_TurnCount = new Amazon.BedrockAgentCore.Model.TurnCountRange();
            System.Int32? requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_TurnCount_source_TraceGeneration_Selection_Filters_TurnCount_Max = null;
            if (cmdletContext.Source_TraceGeneration_Selection_Filters_TurnCount_Max != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_TurnCount_source_TraceGeneration_Selection_Filters_TurnCount_Max = cmdletContext.Source_TraceGeneration_Selection_Filters_TurnCount_Max.Value;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_TurnCount_source_TraceGeneration_Selection_Filters_TurnCount_Max != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_TurnCount.Max = requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_TurnCount_source_TraceGeneration_Selection_Filters_TurnCount_Max.Value;
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_TurnCountIsNull = false;
            }
            System.Int32? requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_TurnCount_source_TraceGeneration_Selection_Filters_TurnCount_Min = null;
            if (cmdletContext.Source_TraceGeneration_Selection_Filters_TurnCount_Min != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_TurnCount_source_TraceGeneration_Selection_Filters_TurnCount_Min = cmdletContext.Source_TraceGeneration_Selection_Filters_TurnCount_Min.Value;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_TurnCount_source_TraceGeneration_Selection_Filters_TurnCount_Min != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_TurnCount.Min = requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_TurnCount_source_TraceGeneration_Selection_Filters_TurnCount_Min.Value;
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_TurnCountIsNull = false;
            }
             // determine if requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_TurnCount should be set to null
            if (requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_TurnCountIsNull)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_TurnCount = null;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_TurnCount != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters.TurnCount = requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters_source_TraceGeneration_Selection_Filters_TurnCount;
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_FiltersIsNull = false;
            }
             // determine if requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters should be set to null
            if (requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_FiltersIsNull)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters = null;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection.Filters = requestSource_source_TraceGeneration_source_TraceGeneration_Selection_source_TraceGeneration_Selection_Filters;
                requestSource_source_TraceGeneration_source_TraceGeneration_SelectionIsNull = false;
            }
             // determine if requestSource_source_TraceGeneration_source_TraceGeneration_Selection should be set to null
            if (requestSource_source_TraceGeneration_source_TraceGeneration_SelectionIsNull)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_Selection = null;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_Selection != null)
            {
                requestSource_source_TraceGeneration.Selection = requestSource_source_TraceGeneration_source_TraceGeneration_Selection;
                requestSource_source_TraceGenerationIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.TraceSourceConfig requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig = null;
            
             // populate SourceConfig
            var requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfigIsNull = true;
            requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig = new Amazon.BedrockAgentCore.Model.TraceSourceConfig();
            Amazon.BedrockAgentCore.Model.BatchEvaluationSourceConfig requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_BatchEvaluation = null;
            
             // populate BatchEvaluation
            var requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_BatchEvaluationIsNull = true;
            requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_BatchEvaluation = new Amazon.BedrockAgentCore.Model.BatchEvaluationSourceConfig();
            System.String requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_BatchEvaluation_source_TraceGeneration_SourceConfig_BatchEvaluation_BatchEvaluationArn = null;
            if (cmdletContext.Source_TraceGeneration_SourceConfig_BatchEvaluation_BatchEvaluationArn != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_BatchEvaluation_source_TraceGeneration_SourceConfig_BatchEvaluation_BatchEvaluationArn = cmdletContext.Source_TraceGeneration_SourceConfig_BatchEvaluation_BatchEvaluationArn;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_BatchEvaluation_source_TraceGeneration_SourceConfig_BatchEvaluation_BatchEvaluationArn != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_BatchEvaluation.BatchEvaluationArn = requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_BatchEvaluation_source_TraceGeneration_SourceConfig_BatchEvaluation_BatchEvaluationArn;
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_BatchEvaluationIsNull = false;
            }
             // determine if requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_BatchEvaluation should be set to null
            if (requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_BatchEvaluationIsNull)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_BatchEvaluation = null;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_BatchEvaluation != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig.BatchEvaluation = requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_BatchEvaluation;
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfigIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.OnlineEvaluationSourceConfig requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluation = null;
            
             // populate OnlineEvaluation
            var requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluationIsNull = true;
            requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluation = new Amazon.BedrockAgentCore.Model.OnlineEvaluationSourceConfig();
            System.DateTime? requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluation_source_TraceGeneration_SourceConfig_OnlineEvaluation_EndTime = null;
            if (cmdletContext.Source_TraceGeneration_SourceConfig_OnlineEvaluation_EndTime != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluation_source_TraceGeneration_SourceConfig_OnlineEvaluation_EndTime = cmdletContext.Source_TraceGeneration_SourceConfig_OnlineEvaluation_EndTime.Value;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluation_source_TraceGeneration_SourceConfig_OnlineEvaluation_EndTime != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluation.EndTime = requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluation_source_TraceGeneration_SourceConfig_OnlineEvaluation_EndTime.Value;
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluationIsNull = false;
            }
            System.String requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluation_source_TraceGeneration_SourceConfig_OnlineEvaluation_OnlineEvaluationConfigArn = null;
            if (cmdletContext.Source_TraceGeneration_SourceConfig_OnlineEvaluation_OnlineEvaluationConfigArn != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluation_source_TraceGeneration_SourceConfig_OnlineEvaluation_OnlineEvaluationConfigArn = cmdletContext.Source_TraceGeneration_SourceConfig_OnlineEvaluation_OnlineEvaluationConfigArn;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluation_source_TraceGeneration_SourceConfig_OnlineEvaluation_OnlineEvaluationConfigArn != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluation.OnlineEvaluationConfigArn = requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluation_source_TraceGeneration_SourceConfig_OnlineEvaluation_OnlineEvaluationConfigArn;
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluationIsNull = false;
            }
            System.DateTime? requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluation_source_TraceGeneration_SourceConfig_OnlineEvaluation_StartTime = null;
            if (cmdletContext.Source_TraceGeneration_SourceConfig_OnlineEvaluation_StartTime != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluation_source_TraceGeneration_SourceConfig_OnlineEvaluation_StartTime = cmdletContext.Source_TraceGeneration_SourceConfig_OnlineEvaluation_StartTime.Value;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluation_source_TraceGeneration_SourceConfig_OnlineEvaluation_StartTime != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluation.StartTime = requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluation_source_TraceGeneration_SourceConfig_OnlineEvaluation_StartTime.Value;
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluationIsNull = false;
            }
             // determine if requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluation should be set to null
            if (requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluationIsNull)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluation = null;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluation != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig.OnlineEvaluation = requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_OnlineEvaluation;
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfigIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.CloudWatchLogsSourceConfig requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs = null;
            
             // populate CloudWatchLogs
            var requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogsIsNull = true;
            requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs = new Amazon.BedrockAgentCore.Model.CloudWatchLogsSourceConfig();
            System.DateTime? requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs_source_TraceGeneration_SourceConfig_CloudWatchLogs_EndTime = null;
            if (cmdletContext.Source_TraceGeneration_SourceConfig_CloudWatchLogs_EndTime != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs_source_TraceGeneration_SourceConfig_CloudWatchLogs_EndTime = cmdletContext.Source_TraceGeneration_SourceConfig_CloudWatchLogs_EndTime.Value;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs_source_TraceGeneration_SourceConfig_CloudWatchLogs_EndTime != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs.EndTime = requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs_source_TraceGeneration_SourceConfig_CloudWatchLogs_EndTime.Value;
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogsIsNull = false;
            }
            List<System.String> requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs_source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupNamePrefix = null;
            if (cmdletContext.Source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupNamePrefix != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs_source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupNamePrefix = cmdletContext.Source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupNamePrefix;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs_source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupNamePrefix != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs.LogGroupNamePrefixes = requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs_source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupNamePrefix;
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogsIsNull = false;
            }
            List<System.String> requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs_source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupName = null;
            if (cmdletContext.Source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupName != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs_source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupName = cmdletContext.Source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupName;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs_source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupName != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs.LogGroupNames = requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs_source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupName;
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogsIsNull = false;
            }
            List<System.String> requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs_source_TraceGeneration_SourceConfig_CloudWatchLogs_ServiceName = null;
            if (cmdletContext.Source_TraceGeneration_SourceConfig_CloudWatchLogs_ServiceName != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs_source_TraceGeneration_SourceConfig_CloudWatchLogs_ServiceName = cmdletContext.Source_TraceGeneration_SourceConfig_CloudWatchLogs_ServiceName;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs_source_TraceGeneration_SourceConfig_CloudWatchLogs_ServiceName != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs.ServiceNames = requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs_source_TraceGeneration_SourceConfig_CloudWatchLogs_ServiceName;
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogsIsNull = false;
            }
            System.DateTime? requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs_source_TraceGeneration_SourceConfig_CloudWatchLogs_StartTime = null;
            if (cmdletContext.Source_TraceGeneration_SourceConfig_CloudWatchLogs_StartTime != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs_source_TraceGeneration_SourceConfig_CloudWatchLogs_StartTime = cmdletContext.Source_TraceGeneration_SourceConfig_CloudWatchLogs_StartTime.Value;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs_source_TraceGeneration_SourceConfig_CloudWatchLogs_StartTime != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs.StartTime = requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs_source_TraceGeneration_SourceConfig_CloudWatchLogs_StartTime.Value;
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogsIsNull = false;
            }
             // determine if requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs should be set to null
            if (requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogsIsNull)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs = null;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs != null)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig.CloudWatchLogs = requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig_source_TraceGeneration_SourceConfig_CloudWatchLogs;
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfigIsNull = false;
            }
             // determine if requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig should be set to null
            if (requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfigIsNull)
            {
                requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig = null;
            }
            if (requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig != null)
            {
                requestSource_source_TraceGeneration.SourceConfig = requestSource_source_TraceGeneration_source_TraceGeneration_SourceConfig;
                requestSource_source_TraceGenerationIsNull = false;
            }
             // determine if requestSource_source_TraceGeneration should be set to null
            if (requestSource_source_TraceGenerationIsNull)
            {
                requestSource_source_TraceGeneration = null;
            }
            if (requestSource_source_TraceGeneration != null)
            {
                request.Source.TraceGeneration = requestSource_source_TraceGeneration;
                requestSourceIsNull = false;
            }
             // determine if request.Source should be set to null
            if (requestSourceIsNull)
            {
                request.Source = null;
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
        
        private Amazon.BedrockAgentCore.Model.StartDatasetGenerationResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.StartDatasetGenerationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore", "StartDatasetGeneration");
            try
            {
                return client.StartDatasetGenerationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String DatasetId { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public Amazon.BedrockAgentCore.ScenarioType ScenarioType { get; set; }
            public List<System.String> Source_TraceGeneration_GroundTruth_Field { get; set; }
            public List<Amazon.BedrockAgentCore.Model.EvaluatorFilter> Source_TraceGeneration_GroundTruth_QualityFilter { get; set; }
            public List<Amazon.BedrockAgentCore.Model.CustomDataIdentifier> Source_TraceGeneration_RedactionConfiguration_CustomDataIdentifier { get; set; }
            public List<System.String> Source_TraceGeneration_RedactionConfiguration_Identifier { get; set; }
            public System.Int32? Source_TraceGeneration_Sampling_MaxScenario { get; set; }
            public List<Amazon.BedrockAgentCore.Model.GenerationAttributeFilter> Source_TraceGeneration_Selection_Filters_AttributeFilter { get; set; }
            public List<Amazon.BedrockAgentCore.Model.EvaluatorFilter> Source_TraceGeneration_Selection_Filters_EvaluatorFilter { get; set; }
            public System.Int32? Source_TraceGeneration_Selection_Filters_TurnCount_Max { get; set; }
            public System.Int32? Source_TraceGeneration_Selection_Filters_TurnCount_Min { get; set; }
            public List<System.String> Source_TraceGeneration_Selection_Identifiers_SessionId { get; set; }
            public List<System.String> Source_TraceGeneration_Selection_Identifiers_TraceId { get; set; }
            public System.String Source_TraceGeneration_SourceConfig_BatchEvaluation_BatchEvaluationArn { get; set; }
            public System.DateTime? Source_TraceGeneration_SourceConfig_CloudWatchLogs_EndTime { get; set; }
            public List<System.String> Source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupNamePrefix { get; set; }
            public List<System.String> Source_TraceGeneration_SourceConfig_CloudWatchLogs_LogGroupName { get; set; }
            public List<System.String> Source_TraceGeneration_SourceConfig_CloudWatchLogs_ServiceName { get; set; }
            public System.DateTime? Source_TraceGeneration_SourceConfig_CloudWatchLogs_StartTime { get; set; }
            public System.DateTime? Source_TraceGeneration_SourceConfig_OnlineEvaluation_EndTime { get; set; }
            public System.String Source_TraceGeneration_SourceConfig_OnlineEvaluation_OnlineEvaluationConfigArn { get; set; }
            public System.DateTime? Source_TraceGeneration_SourceConfig_OnlineEvaluation_StartTime { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.StartDatasetGenerationResponse, StartBACDatasetGenerationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
