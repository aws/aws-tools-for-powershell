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
using Amazon.BedrockRuntime;
using Amazon.BedrockRuntime.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BDRR
{
    /// <summary>
    /// Sends messages to the specified Amazon Bedrock model. <c>Converse</c> provides a consistent
    /// interface that works with all models that support messages. This allows you to write
    /// code once and use it with different models. If a model has unique inference parameters,
    /// you can also pass those unique parameters to the model.
    /// 
    ///  
    /// <para>
    /// Amazon Bedrock doesn't store any text, images, or documents that you provide as content.
    /// The data is only used to generate the response.
    /// </para><para>
    /// You can submit a prompt by including it in the <c>messages</c> field, specifying the
    /// <c>modelId</c> of a foundation model or inference profile to run inference on it,
    /// and including any other fields that are relevant to your use case.
    /// </para><para>
    /// You can also submit a prompt from Prompt management by specifying the ARN of the prompt
    /// version and including a map of variables to values in the <c>promptVariables</c> field.
    /// You can append more messages to the prompt by using the <c>messages</c> field. If
    /// you use a prompt from Prompt management, you can't include the following fields in
    /// the request: <c>additionalModelRequestFields</c>, <c>inferenceConfig</c>, <c>system</c>,
    /// or <c>toolConfig</c>. Instead, these fields must be defined through Prompt management.
    /// For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/prompt-management-use.html">Use
    /// a prompt from Prompt management</a>.
    /// </para><para>
    /// For information about the Converse API, see <i>Use the Converse API</i> in the <i>Amazon
    /// Bedrock User Guide</i>. To use a guardrail, see <i>Use a guardrail with the Converse
    /// API</i> in the <i>Amazon Bedrock User Guide</i>. To use a tool with a model, see <i>Tool
    /// use (Function calling)</i> in the <i>Amazon Bedrock User Guide</i></para><para>
    /// For example code, see <i>Converse API examples</i> in the <i>Amazon Bedrock User Guide</i>.
    /// 
    /// </para><para>
    /// This operation requires permission for the <c>bedrock:InvokeModel</c> action. 
    /// </para><important><para>
    /// To deny all inference access to resources that you specify in the modelId field, you
    /// need to deny access to the <c>bedrock:InvokeModel</c> and <c>bedrock:InvokeModelWithResponseStream</c>
    /// actions. Doing this also denies access to the resource through the base inference
    /// actions (<a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_runtime_InvokeModel.html">InvokeModel</a>
    /// and <a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_runtime_InvokeModelWithResponseStream.html">InvokeModelWithResponseStream</a>).
    /// For more information see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/security_iam_id-based-policy-examples.html#security_iam_id-based-policy-examples-deny-inference">Deny
    /// access for inference on specific models</a>. 
    /// </para></important><para>
    /// For troubleshooting some of the common errors you might encounter when using the <c>Converse</c>
    /// API, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/troubleshooting-api-error-codes.html">Troubleshooting
    /// Amazon Bedrock API Error Codes</a> in the Amazon Bedrock User Guide
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "BDRRConverse", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockRuntime.Model.ConverseResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Runtime Converse API operation.", Operation = new[] {"Converse"}, SelectReturnType = typeof(Amazon.BedrockRuntime.Model.ConverseResponse))]
    [AWSCmdletOutput("Amazon.BedrockRuntime.Model.ConverseResponse",
        "This cmdlet returns an Amazon.BedrockRuntime.Model.ConverseResponse object containing multiple properties."
    )]
    public partial class InvokeBDRRConverseCmdlet : AmazonBedrockRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AdditionalModelRequestField
        /// <summary>
        /// <para>
        /// <para>Additional inference parameters that the model supports, beyond the base set of inference
        /// parameters that <c>Converse</c> and <c>ConverseStream</c> support in the <c>inferenceConfig</c>
        /// field. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-parameters.html">Model
        /// parameters</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalModelRequestFields")]
        public System.Management.Automation.PSObject AdditionalModelRequestField { get; set; }
        #endregion
        
        #region Parameter AdditionalModelResponseFieldPath
        /// <summary>
        /// <para>
        /// <para>Additional model parameters field paths to return in the response. <c>Converse</c>
        /// and <c>ConverseStream</c> return the requested fields as a JSON Pointer object in
        /// the <c>additionalModelResponseFields</c> field. The following is example JSON for
        /// <c>additionalModelResponseFieldPaths</c>.</para><para><c>[ "/stop_sequence" ]</c></para><para>For information about the JSON Pointer syntax, see the <a href="https://datatracker.ietf.org/doc/html/rfc6901">Internet
        /// Engineering Task Force (IETF)</a> documentation.</para><para><c>Converse</c> and <c>ConverseStream</c> reject an empty JSON Pointer or incorrectly
        /// structured JSON Pointer with a <c>400</c> error code. if the JSON Pointer is valid,
        /// but the requested field is not in the model response, it is ignored by <c>Converse</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalModelResponseFieldPaths")]
        public System.String[] AdditionalModelResponseFieldPath { get; set; }
        #endregion
        
        #region Parameter ToolChoice_Any
        /// <summary>
        /// <para>
        /// <para>The model must request at least one tool (no text is generated).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ToolConfig_ToolChoice_Any")]
        public Amazon.BedrockRuntime.Model.AnyToolChoice ToolChoice_Any { get; set; }
        #endregion
        
        #region Parameter ToolChoice_Auto
        /// <summary>
        /// <para>
        /// <para>(Default). The Model automatically decides if a tool should be called or whether to
        /// generate text instead. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ToolConfig_ToolChoice_Auto")]
        public Amazon.BedrockRuntime.Model.AutoToolChoice ToolChoice_Auto { get; set; }
        #endregion
        
        #region Parameter OutputConfig_TextFormat_Structure_JsonSchema_Description
        /// <summary>
        /// <para>
        /// <para> A description of the JSON schema. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_TextFormat_Structure_JsonSchema_Description { get; set; }
        #endregion
        
        #region Parameter GuardrailConfig_GuardrailIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the guardrail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GuardrailConfig_GuardrailIdentifier { get; set; }
        #endregion
        
        #region Parameter GuardrailConfig_GuardrailVersion
        /// <summary>
        /// <para>
        /// <para>The version of the guardrail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GuardrailConfig_GuardrailVersion { get; set; }
        #endregion
        
        #region Parameter PerformanceConfig_Latency
        /// <summary>
        /// <para>
        /// <para>To use a latency-optimized version of the model, set to <c>optimized</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockRuntime.PerformanceConfigLatency")]
        public Amazon.BedrockRuntime.PerformanceConfigLatency PerformanceConfig_Latency { get; set; }
        #endregion
        
        #region Parameter InferenceConfig_MaxToken
        /// <summary>
        /// <para>
        /// <para>The maximum number of tokens to allow in the generated response. The default value
        /// is the maximum allowed value for the model that you are using. For more information,
        /// see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-parameters.html">Inference
        /// parameters for foundation models</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InferenceConfig_MaxTokens")]
        public System.Int32? InferenceConfig_MaxToken { get; set; }
        #endregion
        
        #region Parameter Message
        /// <summary>
        /// <para>
        /// <para>The messages that you want to send to the model.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Messages")]
        public Amazon.BedrockRuntime.Model.Message[] Message { get; set; }
        #endregion
        
        #region Parameter ModelId
        /// <summary>
        /// <para>
        /// <para>Specifies the model or throughput with which to run inference, or the prompt resource
        /// to use in inference. The value depends on the resource that you use:</para><ul><li><para>If you use a base model, specify the model ID or its ARN. For a list of model IDs
        /// for base models, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-ids.html#model-ids-arns">Amazon
        /// Bedrock base model IDs (on-demand throughput)</a> in the Amazon Bedrock User Guide.</para></li><li><para>If you use an inference profile, specify the inference profile ID or its ARN. For
        /// a list of inference profile IDs, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/cross-region-inference-support.html">Supported
        /// Regions and models for cross-region inference</a> in the Amazon Bedrock User Guide.</para></li><li><para>If you use a provisioned model, specify the ARN of the Provisioned Throughput. For
        /// more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/prov-thru-use.html">Run
        /// inference using a Provisioned Throughput</a> in the Amazon Bedrock User Guide.</para></li><li><para>If you use a custom model, first purchase Provisioned Throughput for it. Then specify
        /// the ARN of the resulting provisioned model. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-customization-use.html">Use
        /// a custom model in Amazon Bedrock</a> in the Amazon Bedrock User Guide.</para></li><li><para>To include a prompt that was defined in <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/prompt-management.html">Prompt
        /// management</a>, specify the ARN of the prompt version to use.</para></li></ul><para>The Converse API doesn't support <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-customization-import-model.html">imported
        /// models</a>.</para>
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
        public System.String ModelId { get; set; }
        #endregion
        
        #region Parameter OutputConfig_TextFormat_Structure_JsonSchema_Name
        /// <summary>
        /// <para>
        /// <para> The name of the JSON schema. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_TextFormat_Structure_JsonSchema_Name { get; set; }
        #endregion
        
        #region Parameter Tool_Name
        /// <summary>
        /// <para>
        /// <para>The name of the tool that the model must request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ToolConfig_ToolChoice_Tool_Name")]
        public System.String Tool_Name { get; set; }
        #endregion
        
        #region Parameter PromptVariable
        /// <summary>
        /// <para>
        /// <para>Contains a map of variables in a prompt from Prompt management to objects containing
        /// the values to fill in for them when running model invocation. This field is ignored
        /// if you don't specify a prompt resource in the <c>modelId</c> field.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PromptVariables")]
        public System.Collections.Hashtable PromptVariable { get; set; }
        #endregion
        
        #region Parameter RequestMetadata
        /// <summary>
        /// <para>
        /// <para>Key-value pairs that you can use to filter invocation logs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable RequestMetadata { get; set; }
        #endregion
        
        #region Parameter OutputConfig_TextFormat_Structure_JsonSchema_Schema
        /// <summary>
        /// <para>
        /// <para> The JSON schema to constrain the model's output. For more information, see <a href="https://json-schema.org/understanding-json-schema/reference">JSON
        /// Schema Reference</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_TextFormat_Structure_JsonSchema_Schema { get; set; }
        #endregion
        
        #region Parameter InferenceConfig_StopSequence
        /// <summary>
        /// <para>
        /// <para>A list of stop sequences. A stop sequence is a sequence of characters that causes
        /// the model to stop generating the response. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InferenceConfig_StopSequences")]
        public System.String[] InferenceConfig_StopSequence { get; set; }
        #endregion
        
        #region Parameter System
        /// <summary>
        /// <para>
        /// <para>A prompt that provides instructions or context to the model about the task it should
        /// perform, or the persona it should adopt during the conversation.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.BedrockRuntime.Model.SystemContentBlock[] System { get; set; }
        #endregion
        
        #region Parameter InferenceConfig_Temperature
        /// <summary>
        /// <para>
        /// <para>The likelihood of the model selecting higher-probability options while generating
        /// a response. A lower value makes the model more likely to choose higher-probability
        /// options, while a higher value makes the model more likely to choose lower-probability
        /// options.</para><para>The default value is the default value for the model that you are using. For more
        /// information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-parameters.html">Inference
        /// parameters for foundation models</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? InferenceConfig_Temperature { get; set; }
        #endregion
        
        #region Parameter ToolConfig_Tool
        /// <summary>
        /// <para>
        /// <para>An array of tools that you want to pass to a model. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ToolConfig_Tools")]
        public Amazon.BedrockRuntime.Model.Tool[] ToolConfig_Tool { get; set; }
        #endregion
        
        #region Parameter InferenceConfig_TopP
        /// <summary>
        /// <para>
        /// <para>The percentage of most-likely candidates that the model considers for the next token.
        /// For example, if you choose a value of 0.8 for <c>topP</c>, the model selects from
        /// the top 80% of the probability distribution of tokens that could be next in the sequence.</para><para>The default value is the default value for the model that you are using. For more
        /// information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-parameters.html">Inference
        /// parameters for foundation models</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? InferenceConfig_TopP { get; set; }
        #endregion
        
        #region Parameter GuardrailConfig_Trace
        /// <summary>
        /// <para>
        /// <para>The trace behavior for the guardrail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockRuntime.GuardrailTrace")]
        public Amazon.BedrockRuntime.GuardrailTrace GuardrailConfig_Trace { get; set; }
        #endregion
        
        #region Parameter OutputConfig_TextFormat_Type
        /// <summary>
        /// <para>
        /// <para> The type of structured output format. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockRuntime.OutputFormatType")]
        public Amazon.BedrockRuntime.OutputFormatType OutputConfig_TextFormat_Type { get; set; }
        #endregion
        
        #region Parameter ServiceTier_Type
        /// <summary>
        /// <para>
        /// <para>Specifies the processing tier type used for serving the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockRuntime.ServiceTierType")]
        public Amazon.BedrockRuntime.ServiceTierType ServiceTier_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockRuntime.Model.ConverseResponse).
        /// Specifying the name of a property of type Amazon.BedrockRuntime.Model.ConverseResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ModelId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BDRRConverse (Converse)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockRuntime.Model.ConverseResponse, InvokeBDRRConverseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AdditionalModelRequestField = this.AdditionalModelRequestField;
            if (this.AdditionalModelResponseFieldPath != null)
            {
                context.AdditionalModelResponseFieldPath = new List<System.String>(this.AdditionalModelResponseFieldPath);
            }
            context.GuardrailConfig_GuardrailIdentifier = this.GuardrailConfig_GuardrailIdentifier;
            context.GuardrailConfig_GuardrailVersion = this.GuardrailConfig_GuardrailVersion;
            context.GuardrailConfig_Trace = this.GuardrailConfig_Trace;
            context.InferenceConfig_MaxToken = this.InferenceConfig_MaxToken;
            if (this.InferenceConfig_StopSequence != null)
            {
                context.InferenceConfig_StopSequence = new List<System.String>(this.InferenceConfig_StopSequence);
            }
            context.InferenceConfig_Temperature = this.InferenceConfig_Temperature;
            context.InferenceConfig_TopP = this.InferenceConfig_TopP;
            if (this.Message != null)
            {
                context.Message = new List<Amazon.BedrockRuntime.Model.Message>(this.Message);
            }
            context.ModelId = this.ModelId;
            #if MODULAR
            if (this.ModelId == null && ParameterWasBound(nameof(this.ModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputConfig_TextFormat_Structure_JsonSchema_Description = this.OutputConfig_TextFormat_Structure_JsonSchema_Description;
            context.OutputConfig_TextFormat_Structure_JsonSchema_Name = this.OutputConfig_TextFormat_Structure_JsonSchema_Name;
            context.OutputConfig_TextFormat_Structure_JsonSchema_Schema = this.OutputConfig_TextFormat_Structure_JsonSchema_Schema;
            context.OutputConfig_TextFormat_Type = this.OutputConfig_TextFormat_Type;
            context.PerformanceConfig_Latency = this.PerformanceConfig_Latency;
            if (this.PromptVariable != null)
            {
                context.PromptVariable = new Dictionary<System.String, Amazon.BedrockRuntime.Model.PromptVariableValues>(StringComparer.Ordinal);
                foreach (var hashKey in this.PromptVariable.Keys)
                {
                    context.PromptVariable.Add((String)hashKey, (Amazon.BedrockRuntime.Model.PromptVariableValues)(this.PromptVariable[hashKey]));
                }
            }
            if (this.RequestMetadata != null)
            {
                context.RequestMetadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RequestMetadata.Keys)
                {
                    context.RequestMetadata.Add((String)hashKey, (System.String)(this.RequestMetadata[hashKey]));
                }
            }
            context.ServiceTier_Type = this.ServiceTier_Type;
            if (this.System != null)
            {
                context.System = new List<Amazon.BedrockRuntime.Model.SystemContentBlock>(this.System);
            }
            context.ToolChoice_Any = this.ToolChoice_Any;
            context.ToolChoice_Auto = this.ToolChoice_Auto;
            context.Tool_Name = this.Tool_Name;
            if (this.ToolConfig_Tool != null)
            {
                context.ToolConfig_Tool = new List<Amazon.BedrockRuntime.Model.Tool>(this.ToolConfig_Tool);
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
            var request = new Amazon.BedrockRuntime.Model.ConverseRequest();
            
            if (cmdletContext.AdditionalModelRequestField != null)
            {
                request.AdditionalModelRequestFields = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.AdditionalModelRequestField);
            }
            if (cmdletContext.AdditionalModelResponseFieldPath != null)
            {
                request.AdditionalModelResponseFieldPaths = cmdletContext.AdditionalModelResponseFieldPath;
            }
            
             // populate GuardrailConfig
            var requestGuardrailConfigIsNull = true;
            request.GuardrailConfig = new Amazon.BedrockRuntime.Model.GuardrailConfiguration();
            System.String requestGuardrailConfig_guardrailConfig_GuardrailIdentifier = null;
            if (cmdletContext.GuardrailConfig_GuardrailIdentifier != null)
            {
                requestGuardrailConfig_guardrailConfig_GuardrailIdentifier = cmdletContext.GuardrailConfig_GuardrailIdentifier;
            }
            if (requestGuardrailConfig_guardrailConfig_GuardrailIdentifier != null)
            {
                request.GuardrailConfig.GuardrailIdentifier = requestGuardrailConfig_guardrailConfig_GuardrailIdentifier;
                requestGuardrailConfigIsNull = false;
            }
            System.String requestGuardrailConfig_guardrailConfig_GuardrailVersion = null;
            if (cmdletContext.GuardrailConfig_GuardrailVersion != null)
            {
                requestGuardrailConfig_guardrailConfig_GuardrailVersion = cmdletContext.GuardrailConfig_GuardrailVersion;
            }
            if (requestGuardrailConfig_guardrailConfig_GuardrailVersion != null)
            {
                request.GuardrailConfig.GuardrailVersion = requestGuardrailConfig_guardrailConfig_GuardrailVersion;
                requestGuardrailConfigIsNull = false;
            }
            Amazon.BedrockRuntime.GuardrailTrace requestGuardrailConfig_guardrailConfig_Trace = null;
            if (cmdletContext.GuardrailConfig_Trace != null)
            {
                requestGuardrailConfig_guardrailConfig_Trace = cmdletContext.GuardrailConfig_Trace;
            }
            if (requestGuardrailConfig_guardrailConfig_Trace != null)
            {
                request.GuardrailConfig.Trace = requestGuardrailConfig_guardrailConfig_Trace;
                requestGuardrailConfigIsNull = false;
            }
             // determine if request.GuardrailConfig should be set to null
            if (requestGuardrailConfigIsNull)
            {
                request.GuardrailConfig = null;
            }
            
             // populate InferenceConfig
            var requestInferenceConfigIsNull = true;
            request.InferenceConfig = new Amazon.BedrockRuntime.Model.InferenceConfiguration();
            System.Int32? requestInferenceConfig_inferenceConfig_MaxToken = null;
            if (cmdletContext.InferenceConfig_MaxToken != null)
            {
                requestInferenceConfig_inferenceConfig_MaxToken = cmdletContext.InferenceConfig_MaxToken.Value;
            }
            if (requestInferenceConfig_inferenceConfig_MaxToken != null)
            {
                request.InferenceConfig.MaxTokens = requestInferenceConfig_inferenceConfig_MaxToken.Value;
                requestInferenceConfigIsNull = false;
            }
            List<System.String> requestInferenceConfig_inferenceConfig_StopSequence = null;
            if (cmdletContext.InferenceConfig_StopSequence != null)
            {
                requestInferenceConfig_inferenceConfig_StopSequence = cmdletContext.InferenceConfig_StopSequence;
            }
            if (requestInferenceConfig_inferenceConfig_StopSequence != null)
            {
                request.InferenceConfig.StopSequences = requestInferenceConfig_inferenceConfig_StopSequence;
                requestInferenceConfigIsNull = false;
            }
            System.Single? requestInferenceConfig_inferenceConfig_Temperature = null;
            if (cmdletContext.InferenceConfig_Temperature != null)
            {
                requestInferenceConfig_inferenceConfig_Temperature = cmdletContext.InferenceConfig_Temperature.Value;
            }
            if (requestInferenceConfig_inferenceConfig_Temperature != null)
            {
                request.InferenceConfig.Temperature = requestInferenceConfig_inferenceConfig_Temperature.Value;
                requestInferenceConfigIsNull = false;
            }
            System.Single? requestInferenceConfig_inferenceConfig_TopP = null;
            if (cmdletContext.InferenceConfig_TopP != null)
            {
                requestInferenceConfig_inferenceConfig_TopP = cmdletContext.InferenceConfig_TopP.Value;
            }
            if (requestInferenceConfig_inferenceConfig_TopP != null)
            {
                request.InferenceConfig.TopP = requestInferenceConfig_inferenceConfig_TopP.Value;
                requestInferenceConfigIsNull = false;
            }
             // determine if request.InferenceConfig should be set to null
            if (requestInferenceConfigIsNull)
            {
                request.InferenceConfig = null;
            }
            if (cmdletContext.Message != null)
            {
                request.Messages = cmdletContext.Message;
            }
            if (cmdletContext.ModelId != null)
            {
                request.ModelId = cmdletContext.ModelId;
            }
            
             // populate OutputConfig
            var requestOutputConfigIsNull = true;
            request.OutputConfig = new Amazon.BedrockRuntime.Model.OutputConfig();
            Amazon.BedrockRuntime.Model.OutputFormat requestOutputConfig_outputConfig_TextFormat = null;
            
             // populate TextFormat
            var requestOutputConfig_outputConfig_TextFormatIsNull = true;
            requestOutputConfig_outputConfig_TextFormat = new Amazon.BedrockRuntime.Model.OutputFormat();
            Amazon.BedrockRuntime.OutputFormatType requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Type = null;
            if (cmdletContext.OutputConfig_TextFormat_Type != null)
            {
                requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Type = cmdletContext.OutputConfig_TextFormat_Type;
            }
            if (requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Type != null)
            {
                requestOutputConfig_outputConfig_TextFormat.Type = requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Type;
                requestOutputConfig_outputConfig_TextFormatIsNull = false;
            }
            Amazon.BedrockRuntime.Model.OutputFormatStructure requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure = null;
            
             // populate Structure
            var requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_StructureIsNull = true;
            requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure = new Amazon.BedrockRuntime.Model.OutputFormatStructure();
            Amazon.BedrockRuntime.Model.JsonSchemaDefinition requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchema = null;
            
             // populate JsonSchema
            var requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchemaIsNull = true;
            requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchema = new Amazon.BedrockRuntime.Model.JsonSchemaDefinition();
            System.String requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchema_outputConfig_TextFormat_Structure_JsonSchema_Description = null;
            if (cmdletContext.OutputConfig_TextFormat_Structure_JsonSchema_Description != null)
            {
                requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchema_outputConfig_TextFormat_Structure_JsonSchema_Description = cmdletContext.OutputConfig_TextFormat_Structure_JsonSchema_Description;
            }
            if (requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchema_outputConfig_TextFormat_Structure_JsonSchema_Description != null)
            {
                requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchema.Description = requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchema_outputConfig_TextFormat_Structure_JsonSchema_Description;
                requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchemaIsNull = false;
            }
            System.String requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchema_outputConfig_TextFormat_Structure_JsonSchema_Name = null;
            if (cmdletContext.OutputConfig_TextFormat_Structure_JsonSchema_Name != null)
            {
                requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchema_outputConfig_TextFormat_Structure_JsonSchema_Name = cmdletContext.OutputConfig_TextFormat_Structure_JsonSchema_Name;
            }
            if (requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchema_outputConfig_TextFormat_Structure_JsonSchema_Name != null)
            {
                requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchema.Name = requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchema_outputConfig_TextFormat_Structure_JsonSchema_Name;
                requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchemaIsNull = false;
            }
            System.String requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchema_outputConfig_TextFormat_Structure_JsonSchema_Schema = null;
            if (cmdletContext.OutputConfig_TextFormat_Structure_JsonSchema_Schema != null)
            {
                requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchema_outputConfig_TextFormat_Structure_JsonSchema_Schema = cmdletContext.OutputConfig_TextFormat_Structure_JsonSchema_Schema;
            }
            if (requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchema_outputConfig_TextFormat_Structure_JsonSchema_Schema != null)
            {
                requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchema.Schema = requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchema_outputConfig_TextFormat_Structure_JsonSchema_Schema;
                requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchemaIsNull = false;
            }
             // determine if requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchema should be set to null
            if (requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchemaIsNull)
            {
                requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchema = null;
            }
            if (requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchema != null)
            {
                requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure.JsonSchema = requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure_outputConfig_TextFormat_Structure_JsonSchema;
                requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_StructureIsNull = false;
            }
             // determine if requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure should be set to null
            if (requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_StructureIsNull)
            {
                requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure = null;
            }
            if (requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure != null)
            {
                requestOutputConfig_outputConfig_TextFormat.Structure = requestOutputConfig_outputConfig_TextFormat_outputConfig_TextFormat_Structure;
                requestOutputConfig_outputConfig_TextFormatIsNull = false;
            }
             // determine if requestOutputConfig_outputConfig_TextFormat should be set to null
            if (requestOutputConfig_outputConfig_TextFormatIsNull)
            {
                requestOutputConfig_outputConfig_TextFormat = null;
            }
            if (requestOutputConfig_outputConfig_TextFormat != null)
            {
                request.OutputConfig.TextFormat = requestOutputConfig_outputConfig_TextFormat;
                requestOutputConfigIsNull = false;
            }
             // determine if request.OutputConfig should be set to null
            if (requestOutputConfigIsNull)
            {
                request.OutputConfig = null;
            }
            
             // populate PerformanceConfig
            var requestPerformanceConfigIsNull = true;
            request.PerformanceConfig = new Amazon.BedrockRuntime.Model.PerformanceConfiguration();
            Amazon.BedrockRuntime.PerformanceConfigLatency requestPerformanceConfig_performanceConfig_Latency = null;
            if (cmdletContext.PerformanceConfig_Latency != null)
            {
                requestPerformanceConfig_performanceConfig_Latency = cmdletContext.PerformanceConfig_Latency;
            }
            if (requestPerformanceConfig_performanceConfig_Latency != null)
            {
                request.PerformanceConfig.Latency = requestPerformanceConfig_performanceConfig_Latency;
                requestPerformanceConfigIsNull = false;
            }
             // determine if request.PerformanceConfig should be set to null
            if (requestPerformanceConfigIsNull)
            {
                request.PerformanceConfig = null;
            }
            if (cmdletContext.PromptVariable != null)
            {
                request.PromptVariables = cmdletContext.PromptVariable;
            }
            if (cmdletContext.RequestMetadata != null)
            {
                request.RequestMetadata = cmdletContext.RequestMetadata;
            }
            
             // populate ServiceTier
            var requestServiceTierIsNull = true;
            request.ServiceTier = new Amazon.BedrockRuntime.Model.ServiceTier();
            Amazon.BedrockRuntime.ServiceTierType requestServiceTier_serviceTier_Type = null;
            if (cmdletContext.ServiceTier_Type != null)
            {
                requestServiceTier_serviceTier_Type = cmdletContext.ServiceTier_Type;
            }
            if (requestServiceTier_serviceTier_Type != null)
            {
                request.ServiceTier.Type = requestServiceTier_serviceTier_Type;
                requestServiceTierIsNull = false;
            }
             // determine if request.ServiceTier should be set to null
            if (requestServiceTierIsNull)
            {
                request.ServiceTier = null;
            }
            if (cmdletContext.System != null)
            {
                request.System = cmdletContext.System;
            }
            
             // populate ToolConfig
            var requestToolConfigIsNull = true;
            request.ToolConfig = new Amazon.BedrockRuntime.Model.ToolConfiguration();
            List<Amazon.BedrockRuntime.Model.Tool> requestToolConfig_toolConfig_Tool = null;
            if (cmdletContext.ToolConfig_Tool != null)
            {
                requestToolConfig_toolConfig_Tool = cmdletContext.ToolConfig_Tool;
            }
            if (requestToolConfig_toolConfig_Tool != null)
            {
                request.ToolConfig.Tools = requestToolConfig_toolConfig_Tool;
                requestToolConfigIsNull = false;
            }
            Amazon.BedrockRuntime.Model.ToolChoice requestToolConfig_toolConfig_ToolChoice = null;
            
             // populate ToolChoice
            var requestToolConfig_toolConfig_ToolChoiceIsNull = true;
            requestToolConfig_toolConfig_ToolChoice = new Amazon.BedrockRuntime.Model.ToolChoice();
            Amazon.BedrockRuntime.Model.AnyToolChoice requestToolConfig_toolConfig_ToolChoice_toolChoice_Any = null;
            if (cmdletContext.ToolChoice_Any != null)
            {
                requestToolConfig_toolConfig_ToolChoice_toolChoice_Any = cmdletContext.ToolChoice_Any;
            }
            if (requestToolConfig_toolConfig_ToolChoice_toolChoice_Any != null)
            {
                requestToolConfig_toolConfig_ToolChoice.Any = requestToolConfig_toolConfig_ToolChoice_toolChoice_Any;
                requestToolConfig_toolConfig_ToolChoiceIsNull = false;
            }
            Amazon.BedrockRuntime.Model.AutoToolChoice requestToolConfig_toolConfig_ToolChoice_toolChoice_Auto = null;
            if (cmdletContext.ToolChoice_Auto != null)
            {
                requestToolConfig_toolConfig_ToolChoice_toolChoice_Auto = cmdletContext.ToolChoice_Auto;
            }
            if (requestToolConfig_toolConfig_ToolChoice_toolChoice_Auto != null)
            {
                requestToolConfig_toolConfig_ToolChoice.Auto = requestToolConfig_toolConfig_ToolChoice_toolChoice_Auto;
                requestToolConfig_toolConfig_ToolChoiceIsNull = false;
            }
            Amazon.BedrockRuntime.Model.SpecificToolChoice requestToolConfig_toolConfig_ToolChoice_toolConfig_ToolChoice_Tool = null;
            
             // populate Tool
            var requestToolConfig_toolConfig_ToolChoice_toolConfig_ToolChoice_ToolIsNull = true;
            requestToolConfig_toolConfig_ToolChoice_toolConfig_ToolChoice_Tool = new Amazon.BedrockRuntime.Model.SpecificToolChoice();
            System.String requestToolConfig_toolConfig_ToolChoice_toolConfig_ToolChoice_Tool_tool_Name = null;
            if (cmdletContext.Tool_Name != null)
            {
                requestToolConfig_toolConfig_ToolChoice_toolConfig_ToolChoice_Tool_tool_Name = cmdletContext.Tool_Name;
            }
            if (requestToolConfig_toolConfig_ToolChoice_toolConfig_ToolChoice_Tool_tool_Name != null)
            {
                requestToolConfig_toolConfig_ToolChoice_toolConfig_ToolChoice_Tool.Name = requestToolConfig_toolConfig_ToolChoice_toolConfig_ToolChoice_Tool_tool_Name;
                requestToolConfig_toolConfig_ToolChoice_toolConfig_ToolChoice_ToolIsNull = false;
            }
             // determine if requestToolConfig_toolConfig_ToolChoice_toolConfig_ToolChoice_Tool should be set to null
            if (requestToolConfig_toolConfig_ToolChoice_toolConfig_ToolChoice_ToolIsNull)
            {
                requestToolConfig_toolConfig_ToolChoice_toolConfig_ToolChoice_Tool = null;
            }
            if (requestToolConfig_toolConfig_ToolChoice_toolConfig_ToolChoice_Tool != null)
            {
                requestToolConfig_toolConfig_ToolChoice.Tool = requestToolConfig_toolConfig_ToolChoice_toolConfig_ToolChoice_Tool;
                requestToolConfig_toolConfig_ToolChoiceIsNull = false;
            }
             // determine if requestToolConfig_toolConfig_ToolChoice should be set to null
            if (requestToolConfig_toolConfig_ToolChoiceIsNull)
            {
                requestToolConfig_toolConfig_ToolChoice = null;
            }
            if (requestToolConfig_toolConfig_ToolChoice != null)
            {
                request.ToolConfig.ToolChoice = requestToolConfig_toolConfig_ToolChoice;
                requestToolConfigIsNull = false;
            }
             // determine if request.ToolConfig should be set to null
            if (requestToolConfigIsNull)
            {
                request.ToolConfig = null;
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
        
        private Amazon.BedrockRuntime.Model.ConverseResponse CallAWSServiceOperation(IAmazonBedrockRuntime client, Amazon.BedrockRuntime.Model.ConverseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Runtime", "Converse");
            try
            {
                return client.ConverseAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Management.Automation.PSObject AdditionalModelRequestField { get; set; }
            public List<System.String> AdditionalModelResponseFieldPath { get; set; }
            public System.String GuardrailConfig_GuardrailIdentifier { get; set; }
            public System.String GuardrailConfig_GuardrailVersion { get; set; }
            public Amazon.BedrockRuntime.GuardrailTrace GuardrailConfig_Trace { get; set; }
            public System.Int32? InferenceConfig_MaxToken { get; set; }
            public List<System.String> InferenceConfig_StopSequence { get; set; }
            public System.Single? InferenceConfig_Temperature { get; set; }
            public System.Single? InferenceConfig_TopP { get; set; }
            public List<Amazon.BedrockRuntime.Model.Message> Message { get; set; }
            public System.String ModelId { get; set; }
            public System.String OutputConfig_TextFormat_Structure_JsonSchema_Description { get; set; }
            public System.String OutputConfig_TextFormat_Structure_JsonSchema_Name { get; set; }
            public System.String OutputConfig_TextFormat_Structure_JsonSchema_Schema { get; set; }
            public Amazon.BedrockRuntime.OutputFormatType OutputConfig_TextFormat_Type { get; set; }
            public Amazon.BedrockRuntime.PerformanceConfigLatency PerformanceConfig_Latency { get; set; }
            public Dictionary<System.String, Amazon.BedrockRuntime.Model.PromptVariableValues> PromptVariable { get; set; }
            public Dictionary<System.String, System.String> RequestMetadata { get; set; }
            public Amazon.BedrockRuntime.ServiceTierType ServiceTier_Type { get; set; }
            public List<Amazon.BedrockRuntime.Model.SystemContentBlock> System { get; set; }
            public Amazon.BedrockRuntime.Model.AnyToolChoice ToolChoice_Any { get; set; }
            public Amazon.BedrockRuntime.Model.AutoToolChoice ToolChoice_Auto { get; set; }
            public System.String Tool_Name { get; set; }
            public List<Amazon.BedrockRuntime.Model.Tool> ToolConfig_Tool { get; set; }
            public System.Func<Amazon.BedrockRuntime.Model.ConverseResponse, InvokeBDRRConverseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
