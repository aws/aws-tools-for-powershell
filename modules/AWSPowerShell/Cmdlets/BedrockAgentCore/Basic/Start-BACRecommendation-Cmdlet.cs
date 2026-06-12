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
    /// Starts a recommendation job that analyzes agent traces and generates optimization
    /// suggestions for system prompts or tool descriptions to improve agent performance.
    /// </summary>
    [Cmdlet("Start", "BACRecommendation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCore.Model.StartRecommendationResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer StartRecommendation API operation.", Operation = new[] {"StartRecommendation"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.StartRecommendationResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.StartRecommendationResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.Model.StartRecommendationResponse object containing multiple properties."
    )]
    public partial class StartBACRecommendationCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluation_BatchEvaluationArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the completed batch evaluation to use as the trace source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluation_BatchEvaluationArn { get; set; }
        #endregion
        
        #region Parameter RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluation_BatchEvaluationArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the completed batch evaluation to use as the trace source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluation_BatchEvaluationArn { get; set; }
        #endregion
        
        #region Parameter RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_BundleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the configuration bundle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_BundleArn { get; set; }
        #endregion
        
        #region Parameter RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_BundleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the configuration bundle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_BundleArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the recommendation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_EndTime
        /// <summary>
        /// <para>
        /// <para>The end time of the time range to read traces from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_EndTime { get; set; }
        #endregion
        
        #region Parameter RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_EndTime
        /// <summary>
        /// <para>
        /// <para>The end time of the time range to read traces from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_EndTime { get; set; }
        #endregion
        
        #region Parameter RecommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig_Evaluator
        /// <summary>
        /// <para>
        /// <para>The list of evaluators to use for assessing recommendation quality.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig_Evaluators")]
        public Amazon.BedrockAgentCore.Model.RecommendationEvaluatorReference[] RecommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig_Evaluator { get; set; }
        #endregion
        
        #region Parameter RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter
        /// <summary>
        /// <para>
        /// <para>The list of filters to apply when reading agent traces.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filters")]
        public Amazon.BedrockAgentCore.Model.CloudWatchLogsFilter[] RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter { get; set; }
        #endregion
        
        #region Parameter RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter
        /// <summary>
        /// <para>
        /// <para>The list of filters to apply when reading agent traces.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filters")]
        public Amazon.BedrockAgentCore.Model.CloudWatchLogsFilter[] RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the KMS key used to encrypt recommendation data. If provided, customer
        /// data is encrypted at rest with the specified key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn
        /// <summary>
        /// <para>
        /// <para>The list of CloudWatch log group ARNs to read agent traces from.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArns")]
        public System.String[] RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn { get; set; }
        #endregion
        
        #region Parameter RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn
        /// <summary>
        /// <para>
        /// <para>The list of CloudWatch log group ARNs to read agent traces from.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArns")]
        public System.String[] RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the recommendation. Must be unique within your account.</para>
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
        
        #region Parameter RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName
        /// <summary>
        /// <para>
        /// <para>The list of service names to filter traces within the specified log groups.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceNames")]
        public System.String[] RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName { get; set; }
        #endregion
        
        #region Parameter RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName
        /// <summary>
        /// <para>
        /// <para>The list of service names to filter traces within the specified log groups.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceNames")]
        public System.String[] RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName { get; set; }
        #endregion
        
        #region Parameter RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_SessionSpan
        /// <summary>
        /// <para>
        /// <para>Agent traces provided as inline session spans in OpenTelemetry format.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_SessionSpans")]
        public Amazon.Runtime.Documents.Document[] RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_SessionSpan { get; set; }
        #endregion
        
        #region Parameter RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_SessionSpan
        /// <summary>
        /// <para>
        /// <para>Agent traces provided as inline session spans in OpenTelemetry format.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_SessionSpans")]
        public Amazon.Runtime.Documents.Document[] RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_SessionSpan { get; set; }
        #endregion
        
        #region Parameter RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_StartTime
        /// <summary>
        /// <para>
        /// <para>The start time of the time range to read traces from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_StartTime { get; set; }
        #endregion
        
        #region Parameter RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_StartTime
        /// <summary>
        /// <para>
        /// <para>The start time of the time range to read traces from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_StartTime { get; set; }
        #endregion
        
        #region Parameter RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_SystemPromptJsonPath
        /// <summary>
        /// <para>
        /// <para>The JSON path within the configuration bundle that contains the system prompt.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_SystemPromptJsonPath { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of tag keys and values to associate with the recommendation.</para><para />
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
        
        #region Parameter RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_Text
        /// <summary>
        /// <para>
        /// <para>The system prompt text provided inline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_Text { get; set; }
        #endregion
        
        #region Parameter RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_Tool
        /// <summary>
        /// <para>
        /// <para>The list of tool entries mapping tool names to their JSON paths within the bundle.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_Tools")]
        public Amazon.BedrockAgentCore.Model.ConfigurationBundleToolEntry[] RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_Tool { get; set; }
        #endregion
        
        #region Parameter RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText_Tool
        /// <summary>
        /// <para>
        /// <para>The list of tool descriptions to optimize.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText_Tools")]
        public Amazon.BedrockAgentCore.Model.ToolDescriptionInput[] RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText_Tool { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of recommendation to generate. Valid values are <c>SYSTEM_PROMPT_RECOMMENDATION</c>
        /// for system prompt optimization or <c>TOOL_DESCRIPTION_RECOMMENDATION</c> for tool
        /// description optimization.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockAgentCore.RecommendationType")]
        public Amazon.BedrockAgentCore.RecommendationType Type { get; set; }
        #endregion
        
        #region Parameter RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_VersionId
        /// <summary>
        /// <para>
        /// <para>The version identifier of the configuration bundle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_VersionId { get; set; }
        #endregion
        
        #region Parameter RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_VersionId
        /// <summary>
        /// <para>
        /// <para>The version identifier of the configuration bundle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_VersionId { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.StartRecommendationResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.StartRecommendationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-BACRecommendation (StartRecommendation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.StartRecommendationResponse, StartBACRecommendationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.KmsKeyArn = this.KmsKeyArn;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluation_BatchEvaluationArn = this.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluation_BatchEvaluationArn;
            context.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_EndTime = this.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_EndTime;
            if (this.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn != null)
            {
                context.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn = new List<System.String>(this.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn);
            }
            if (this.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter != null)
            {
                context.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter = new List<Amazon.BedrockAgentCore.Model.CloudWatchLogsFilter>(this.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter);
            }
            if (this.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName != null)
            {
                context.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName = new List<System.String>(this.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName);
            }
            context.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_StartTime = this.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_StartTime;
            if (this.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_SessionSpan != null)
            {
                context.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_SessionSpan = new List<Amazon.Runtime.Documents.Document>(this.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_SessionSpan);
            }
            if (this.RecommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig_Evaluator != null)
            {
                context.RecommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig_Evaluator = new List<Amazon.BedrockAgentCore.Model.RecommendationEvaluatorReference>(this.RecommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig_Evaluator);
            }
            context.RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_BundleArn = this.RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_BundleArn;
            context.RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_SystemPromptJsonPath = this.RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_SystemPromptJsonPath;
            context.RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_VersionId = this.RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_VersionId;
            context.RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_Text = this.RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_Text;
            context.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluation_BatchEvaluationArn = this.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluation_BatchEvaluationArn;
            context.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_EndTime = this.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_EndTime;
            if (this.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn != null)
            {
                context.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn = new List<System.String>(this.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn);
            }
            if (this.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter != null)
            {
                context.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter = new List<Amazon.BedrockAgentCore.Model.CloudWatchLogsFilter>(this.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter);
            }
            if (this.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName != null)
            {
                context.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName = new List<System.String>(this.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName);
            }
            context.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_StartTime = this.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_StartTime;
            if (this.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_SessionSpan != null)
            {
                context.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_SessionSpan = new List<Amazon.Runtime.Documents.Document>(this.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_SessionSpan);
            }
            context.RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_BundleArn = this.RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_BundleArn;
            if (this.RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_Tool != null)
            {
                context.RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_Tool = new List<Amazon.BedrockAgentCore.Model.ConfigurationBundleToolEntry>(this.RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_Tool);
            }
            context.RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_VersionId = this.RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_VersionId;
            if (this.RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText_Tool != null)
            {
                context.RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText_Tool = new List<Amazon.BedrockAgentCore.Model.ToolDescriptionInput>(this.RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText_Tool);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgentCore.Model.StartRecommendationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate RecommendationConfig
            var requestRecommendationConfigIsNull = true;
            request.RecommendationConfig = new Amazon.BedrockAgentCore.Model.RecommendationConfig();
            Amazon.BedrockAgentCore.Model.ToolDescriptionRecommendationConfig requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig = null;
            
             // populate ToolDescriptionRecommendationConfig
            var requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfigIsNull = true;
            requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig = new Amazon.BedrockAgentCore.Model.ToolDescriptionRecommendationConfig();
            Amazon.BedrockAgentCore.Model.ToolDescriptionSource requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription = null;
            
             // populate ToolDescription
            var requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescriptionIsNull = true;
            requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription = new Amazon.BedrockAgentCore.Model.ToolDescriptionSource();
            Amazon.BedrockAgentCore.Model.ToolDescriptionTextInput requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText = null;
            
             // populate ToolDescriptionText
            var requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionTextIsNull = true;
            requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText = new Amazon.BedrockAgentCore.Model.ToolDescriptionTextInput();
            List<Amazon.BedrockAgentCore.Model.ToolDescriptionInput> requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText_Tool = null;
            if (cmdletContext.RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText_Tool != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText_Tool = cmdletContext.RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText_Tool;
            }
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText_Tool != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText.Tools = requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText_Tool;
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionTextIsNull = false;
            }
             // determine if requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText should be set to null
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionTextIsNull)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText = null;
            }
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription.ToolDescriptionText = requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText;
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescriptionIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.ToolDescriptionConfigurationBundle requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle = null;
            
             // populate ConfigurationBundle
            var requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundleIsNull = true;
            requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle = new Amazon.BedrockAgentCore.Model.ToolDescriptionConfigurationBundle();
            System.String requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_BundleArn = null;
            if (cmdletContext.RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_BundleArn != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_BundleArn = cmdletContext.RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_BundleArn;
            }
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_BundleArn != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle.BundleArn = requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_BundleArn;
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundleIsNull = false;
            }
            List<Amazon.BedrockAgentCore.Model.ConfigurationBundleToolEntry> requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_Tool = null;
            if (cmdletContext.RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_Tool != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_Tool = cmdletContext.RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_Tool;
            }
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_Tool != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle.Tools = requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_Tool;
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundleIsNull = false;
            }
            System.String requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_VersionId = null;
            if (cmdletContext.RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_VersionId != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_VersionId = cmdletContext.RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_VersionId;
            }
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_VersionId != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle.VersionId = requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_VersionId;
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundleIsNull = false;
            }
             // determine if requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle should be set to null
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundleIsNull)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle = null;
            }
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription.ConfigurationBundle = requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle;
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescriptionIsNull = false;
            }
             // determine if requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription should be set to null
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescriptionIsNull)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription = null;
            }
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig.ToolDescription = requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription;
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfigIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.AgentTracesConfig requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces = null;
            
             // populate AgentTraces
            var requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTracesIsNull = true;
            requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces = new Amazon.BedrockAgentCore.Model.AgentTracesConfig();
            List<Amazon.Runtime.Documents.Document> requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_SessionSpan = null;
            if (cmdletContext.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_SessionSpan != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_SessionSpan = cmdletContext.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_SessionSpan;
            }
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_SessionSpan != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces.SessionSpans = requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_SessionSpan;
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTracesIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.BatchEvaluationTraceConfig requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluation = null;
            
             // populate BatchEvaluation
            var requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluationIsNull = true;
            requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluation = new Amazon.BedrockAgentCore.Model.BatchEvaluationTraceConfig();
            System.String requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluation_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluation_BatchEvaluationArn = null;
            if (cmdletContext.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluation_BatchEvaluationArn != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluation_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluation_BatchEvaluationArn = cmdletContext.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluation_BatchEvaluationArn;
            }
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluation_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluation_BatchEvaluationArn != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluation.BatchEvaluationArn = requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluation_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluation_BatchEvaluationArn;
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluationIsNull = false;
            }
             // determine if requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluation should be set to null
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluationIsNull)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluation = null;
            }
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluation != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces.BatchEvaluation = requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluation;
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTracesIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.CloudWatchLogsTraceConfig requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs = null;
            
             // populate CloudwatchLogs
            var requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogsIsNull = true;
            requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs = new Amazon.BedrockAgentCore.Model.CloudWatchLogsTraceConfig();
            System.DateTime? requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_EndTime = null;
            if (cmdletContext.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_EndTime != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_EndTime = cmdletContext.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_EndTime.Value;
            }
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_EndTime != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs.EndTime = requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_EndTime.Value;
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogsIsNull = false;
            }
            List<System.String> requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn = null;
            if (cmdletContext.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn = cmdletContext.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn;
            }
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs.LogGroupArns = requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn;
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogsIsNull = false;
            }
            List<System.String> requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName = null;
            if (cmdletContext.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName = cmdletContext.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName;
            }
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs.ServiceNames = requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName;
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogsIsNull = false;
            }
            System.DateTime? requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_StartTime = null;
            if (cmdletContext.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_StartTime != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_StartTime = cmdletContext.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_StartTime.Value;
            }
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_StartTime != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs.StartTime = requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_StartTime.Value;
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogsIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.CloudWatchLogsRule requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule = null;
            
             // populate Rule
            var requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_RuleIsNull = true;
            requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule = new Amazon.BedrockAgentCore.Model.CloudWatchLogsRule();
            List<Amazon.BedrockAgentCore.Model.CloudWatchLogsFilter> requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter = null;
            if (cmdletContext.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter = cmdletContext.RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter;
            }
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule.Filters = requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter;
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_RuleIsNull = false;
            }
             // determine if requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule should be set to null
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_RuleIsNull)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule = null;
            }
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs.Rule = requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule;
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogsIsNull = false;
            }
             // determine if requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs should be set to null
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogsIsNull)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs = null;
            }
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces.CloudwatchLogs = requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs;
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTracesIsNull = false;
            }
             // determine if requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces should be set to null
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTracesIsNull)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces = null;
            }
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces != null)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig.AgentTraces = requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces;
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfigIsNull = false;
            }
             // determine if requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig should be set to null
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfigIsNull)
            {
                requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig = null;
            }
            if (requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig != null)
            {
                request.RecommendationConfig.ToolDescriptionRecommendationConfig = requestRecommendationConfig_recommendationConfig_ToolDescriptionRecommendationConfig;
                requestRecommendationConfigIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.SystemPromptRecommendationConfig requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig = null;
            
             // populate SystemPromptRecommendationConfig
            var requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfigIsNull = true;
            requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig = new Amazon.BedrockAgentCore.Model.SystemPromptRecommendationConfig();
            Amazon.BedrockAgentCore.Model.RecommendationEvaluationConfig requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig = null;
            
             // populate EvaluationConfig
            var requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_EvaluationConfigIsNull = true;
            requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig = new Amazon.BedrockAgentCore.Model.RecommendationEvaluationConfig();
            List<Amazon.BedrockAgentCore.Model.RecommendationEvaluatorReference> requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig_recommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig_Evaluator = null;
            if (cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig_Evaluator != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig_recommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig_Evaluator = cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig_Evaluator;
            }
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig_recommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig_Evaluator != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig.Evaluators = requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig_recommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig_Evaluator;
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_EvaluationConfigIsNull = false;
            }
             // determine if requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig should be set to null
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_EvaluationConfigIsNull)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig = null;
            }
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig.EvaluationConfig = requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig;
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfigIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.SystemPromptConfig requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt = null;
            
             // populate SystemPrompt
            var requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPromptIsNull = true;
            requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt = new Amazon.BedrockAgentCore.Model.SystemPromptConfig();
            System.String requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_Text = null;
            if (cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_Text != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_Text = cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_Text;
            }
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_Text != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt.Text = requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_Text;
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPromptIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.SystemPromptConfigurationBundle requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle = null;
            
             // populate ConfigurationBundle
            var requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundleIsNull = true;
            requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle = new Amazon.BedrockAgentCore.Model.SystemPromptConfigurationBundle();
            System.String requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_BundleArn = null;
            if (cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_BundleArn != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_BundleArn = cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_BundleArn;
            }
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_BundleArn != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle.BundleArn = requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_BundleArn;
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundleIsNull = false;
            }
            System.String requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_SystemPromptJsonPath = null;
            if (cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_SystemPromptJsonPath != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_SystemPromptJsonPath = cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_SystemPromptJsonPath;
            }
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_SystemPromptJsonPath != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle.SystemPromptJsonPath = requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_SystemPromptJsonPath;
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundleIsNull = false;
            }
            System.String requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_VersionId = null;
            if (cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_VersionId != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_VersionId = cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_VersionId;
            }
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_VersionId != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle.VersionId = requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_VersionId;
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundleIsNull = false;
            }
             // determine if requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle should be set to null
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundleIsNull)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle = null;
            }
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt.ConfigurationBundle = requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle;
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPromptIsNull = false;
            }
             // determine if requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt should be set to null
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPromptIsNull)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt = null;
            }
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig.SystemPrompt = requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_SystemPrompt;
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfigIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.AgentTracesConfig requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces = null;
            
             // populate AgentTraces
            var requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTracesIsNull = true;
            requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces = new Amazon.BedrockAgentCore.Model.AgentTracesConfig();
            List<Amazon.Runtime.Documents.Document> requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_SessionSpan = null;
            if (cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_SessionSpan != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_SessionSpan = cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_SessionSpan;
            }
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_SessionSpan != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces.SessionSpans = requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_SessionSpan;
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTracesIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.BatchEvaluationTraceConfig requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluation = null;
            
             // populate BatchEvaluation
            var requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluationIsNull = true;
            requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluation = new Amazon.BedrockAgentCore.Model.BatchEvaluationTraceConfig();
            System.String requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluation_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluation_BatchEvaluationArn = null;
            if (cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluation_BatchEvaluationArn != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluation_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluation_BatchEvaluationArn = cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluation_BatchEvaluationArn;
            }
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluation_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluation_BatchEvaluationArn != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluation.BatchEvaluationArn = requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluation_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluation_BatchEvaluationArn;
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluationIsNull = false;
            }
             // determine if requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluation should be set to null
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluationIsNull)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluation = null;
            }
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluation != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces.BatchEvaluation = requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluation;
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTracesIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.CloudWatchLogsTraceConfig requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs = null;
            
             // populate CloudwatchLogs
            var requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogsIsNull = true;
            requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs = new Amazon.BedrockAgentCore.Model.CloudWatchLogsTraceConfig();
            System.DateTime? requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_EndTime = null;
            if (cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_EndTime != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_EndTime = cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_EndTime.Value;
            }
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_EndTime != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs.EndTime = requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_EndTime.Value;
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogsIsNull = false;
            }
            List<System.String> requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn = null;
            if (cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn = cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn;
            }
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs.LogGroupArns = requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn;
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogsIsNull = false;
            }
            List<System.String> requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName = null;
            if (cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName = cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName;
            }
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs.ServiceNames = requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName;
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogsIsNull = false;
            }
            System.DateTime? requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_StartTime = null;
            if (cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_StartTime != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_StartTime = cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_StartTime.Value;
            }
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_StartTime != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs.StartTime = requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_StartTime.Value;
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogsIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.CloudWatchLogsRule requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule = null;
            
             // populate Rule
            var requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_RuleIsNull = true;
            requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule = new Amazon.BedrockAgentCore.Model.CloudWatchLogsRule();
            List<Amazon.BedrockAgentCore.Model.CloudWatchLogsFilter> requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter = null;
            if (cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter = cmdletContext.RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter;
            }
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule.Filters = requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter;
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_RuleIsNull = false;
            }
             // determine if requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule should be set to null
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_RuleIsNull)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule = null;
            }
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs.Rule = requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule;
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogsIsNull = false;
            }
             // determine if requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs should be set to null
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogsIsNull)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs = null;
            }
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces.CloudwatchLogs = requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs;
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTracesIsNull = false;
            }
             // determine if requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces should be set to null
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTracesIsNull)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces = null;
            }
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces != null)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig.AgentTraces = requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig_AgentTraces;
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfigIsNull = false;
            }
             // determine if requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig should be set to null
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfigIsNull)
            {
                requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig = null;
            }
            if (requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig != null)
            {
                request.RecommendationConfig.SystemPromptRecommendationConfig = requestRecommendationConfig_recommendationConfig_SystemPromptRecommendationConfig;
                requestRecommendationConfigIsNull = false;
            }
             // determine if request.RecommendationConfig should be set to null
            if (requestRecommendationConfigIsNull)
            {
                request.RecommendationConfig = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.BedrockAgentCore.Model.StartRecommendationResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.StartRecommendationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "StartRecommendation");
            try
            {
                return client.StartRecommendationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String KmsKeyArn { get; set; }
            public System.String Name { get; set; }
            public System.String RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_BatchEvaluation_BatchEvaluationArn { get; set; }
            public System.DateTime? RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_EndTime { get; set; }
            public List<System.String> RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn { get; set; }
            public List<Amazon.BedrockAgentCore.Model.CloudWatchLogsFilter> RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter { get; set; }
            public List<System.String> RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName { get; set; }
            public System.DateTime? RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_CloudwatchLogs_StartTime { get; set; }
            public List<Amazon.Runtime.Documents.Document> RecommendationConfig_SystemPromptRecommendationConfig_AgentTraces_SessionSpan { get; set; }
            public List<Amazon.BedrockAgentCore.Model.RecommendationEvaluatorReference> RecommendationConfig_SystemPromptRecommendationConfig_EvaluationConfig_Evaluator { get; set; }
            public System.String RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_BundleArn { get; set; }
            public System.String RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_SystemPromptJsonPath { get; set; }
            public System.String RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_ConfigurationBundle_VersionId { get; set; }
            public System.String RecommendationConfig_SystemPromptRecommendationConfig_SystemPrompt_Text { get; set; }
            public System.String RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_BatchEvaluation_BatchEvaluationArn { get; set; }
            public System.DateTime? RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_EndTime { get; set; }
            public List<System.String> RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_LogGroupArn { get; set; }
            public List<Amazon.BedrockAgentCore.Model.CloudWatchLogsFilter> RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_Rule_Filter { get; set; }
            public List<System.String> RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_ServiceName { get; set; }
            public System.DateTime? RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_CloudwatchLogs_StartTime { get; set; }
            public List<Amazon.Runtime.Documents.Document> RecommendationConfig_ToolDescriptionRecommendationConfig_AgentTraces_SessionSpan { get; set; }
            public System.String RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_BundleArn { get; set; }
            public List<Amazon.BedrockAgentCore.Model.ConfigurationBundleToolEntry> RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_Tool { get; set; }
            public System.String RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ConfigurationBundle_VersionId { get; set; }
            public List<Amazon.BedrockAgentCore.Model.ToolDescriptionInput> RecommendationConfig_ToolDescriptionRecommendationConfig_ToolDescription_ToolDescriptionText_Tool { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.BedrockAgentCore.RecommendationType Type { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.StartRecommendationResponse, StartBACRecommendationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
