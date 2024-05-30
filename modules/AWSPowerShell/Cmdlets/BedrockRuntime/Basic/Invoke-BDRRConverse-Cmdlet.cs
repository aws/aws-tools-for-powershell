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
using Amazon.BedrockRuntime;
using Amazon.BedrockRuntime.Model;

namespace Amazon.PowerShell.Cmdlets.BDRR
{
    /// <summary>
    /// Sends messages to the specified Amazon Bedrock model. <c>Converse</c> provides a consistent
    /// interface that works with all models that support messages. This allows you to write
    /// code once and use it with different models. Should a model have unique inference parameters,
    /// you can also pass those unique parameters to the model. For more information, see
    /// <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/api-methods-run.html">Run
    /// inference</a> in the Bedrock User Guide.
    /// 
    ///  
    /// <para>
    /// This operation requires permission for the <c>bedrock:InvokeModel</c> action. 
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "BDRRConverse", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockRuntime.Model.ConverseResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Runtime Converse API operation.", Operation = new[] {"Converse"}, SelectReturnType = typeof(Amazon.BedrockRuntime.Model.ConverseResponse))]
    [AWSCmdletOutput("Amazon.BedrockRuntime.Model.ConverseResponse",
        "This cmdlet returns an Amazon.BedrockRuntime.Model.ConverseResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeBDRRConverseCmdlet : AmazonBedrockRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AdditionalModelRequestField
        /// <summary>
        /// <para>
        /// <para>Additional inference parameters that the model supports, beyond the base set of inference
        /// parameters that <c>Converse</c> supports in the <c>inferenceConfig</c> field. For
        /// more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-parameters.html">Model
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
        /// returns the requested fields as a JSON Pointer object in the <c>additionalModelResultFields</c>
        /// field. The following is example JSON for <c>additionalModelResponseFieldPaths</c>.</para><para><c>[ "/stop_sequence" ]</c></para><para>For information about the JSON Pointer syntax, see the <a href="https://datatracker.ietf.org/doc/html/rfc6901">Internet
        /// Engineering Task Force (IETF)</a> documentation.</para><para><c>Converse</c> rejects an empty JSON Pointer or incorrectly structured JSON Pointer
        /// with a <c>400</c> error code. if the JSON Pointer is valid, but the requested field
        /// is not in the model response, it is ignored by <c>Converse</c>.</para>
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
        /// <para>The Model automatically decides if a tool should be called or to whether to generate
        /// text instead.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ToolConfig_ToolChoice_Auto")]
        public Amazon.BedrockRuntime.Model.AutoToolChoice ToolChoice_Auto { get; set; }
        #endregion
        
        #region Parameter InferenceConfig_MaxToken
        /// <summary>
        /// <para>
        /// <para>The maximum number of tokens to allow in the generated response. The default value
        /// is the maximum allowed value for the model that you are using. For more information,
        /// see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-parameters.html">Inference
        /// parameters for foundatio{ "messages": [ { "role": "user", "content": [ { "text": "what's
        /// the weather in Queens, NY and Austin, TX?" } ] }, { "role": "assistant", "content":
        /// [ { "toolUse": { "toolUseId": "1", "name": "get_weather", "input": { "city": "Queens",
        /// "state": "NY" } } }, { "toolUse": { "toolUseId": "2", "name": "get_weather", "input":
        /// { "city": "Austin", "state": "TX" } } } ] }, { "role": "user", "content": [ { "toolResult":
        /// { "toolUseId": "2", "content": [ { "json": { "weather": "40" } } ] } }, { "text":
        /// "..." }, { "toolResult": { "toolUseId": "1", "content": [ { "text": "result text"
        /// } ] } } ] } ], "toolConfig": { "tools": [ { "name": "get_weather", "description":
        /// "Get weather", "inputSchema": { "type": "object", "properties": { "city": { "type":
        /// "string", "description": "City of location" }, "state": { "type": "string", "description":
        /// "State of location" } }, "required": ["city", "state"] } } ] } } n models</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InferenceConfig_MaxTokens")]
        public System.Int32? InferenceConfig_MaxToken { get; set; }
        #endregion
        
        #region Parameter Message
        /// <summary>
        /// <para>
        /// <para>The messages that you want to send to the model.</para>
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
        [Alias("Messages")]
        public Amazon.BedrockRuntime.Model.Message[] Message { get; set; }
        #endregion
        
        #region Parameter ModelId
        /// <summary>
        /// <para>
        /// <para>The identifier for the model that you want to call.</para><para>The <c>modelId</c> to provide depends on the type of model that you use:</para><ul><li><para>If you use a base model, specify the model ID or its ARN. For a list of model IDs
        /// for base models, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-ids.html#model-ids-arns">Amazon
        /// Bedrock base model IDs (on-demand throughput)</a> in the Amazon Bedrock User Guide.</para></li><li><para>If you use a provisioned model, specify the ARN of the Provisioned Throughput. For
        /// more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/prov-thru-use.html">Run
        /// inference using a Provisioned Throughput</a> in the Amazon Bedrock User Guide.</para></li><li><para>If you use a custom model, first purchase Provisioned Throughput for it. Then specify
        /// the ARN of the resulting provisioned model. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-customization-use.html">Use
        /// a custom model in Amazon Bedrock</a> in the Amazon Bedrock User Guide.</para></li></ul>
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
        
        #region Parameter InferenceConfig_StopSequence
        /// <summary>
        /// <para>
        /// <para>A list of stop sequences. A stop sequence is a sequence of characters that causes
        /// the model to stop generating the response. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InferenceConfig_StopSequences")]
        public System.String[] InferenceConfig_StopSequence { get; set; }
        #endregion
        
        #region Parameter System
        /// <summary>
        /// <para>
        /// <para>A system prompt to pass to the model.</para>
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
        /// <para>An array of tools that you want to pass to a model.</para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ModelId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ModelId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ModelId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ModelId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BDRRConverse (Converse)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockRuntime.Model.ConverseResponse, InvokeBDRRConverseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ModelId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AdditionalModelRequestField = this.AdditionalModelRequestField;
            if (this.AdditionalModelResponseFieldPath != null)
            {
                context.AdditionalModelResponseFieldPath = new List<System.String>(this.AdditionalModelResponseFieldPath);
            }
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
            #if MODULAR
            if (this.Message == null && ParameterWasBound(nameof(this.Message)))
            {
                WriteWarning("You are passing $null as a value for parameter Message which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelId = this.ModelId;
            #if MODULAR
            if (this.ModelId == null && ParameterWasBound(nameof(this.ModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
                #if DESKTOP
                return client.Converse(request);
                #elif CORECLR
                return client.ConverseAsync(request).GetAwaiter().GetResult();
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
            public System.Management.Automation.PSObject AdditionalModelRequestField { get; set; }
            public List<System.String> AdditionalModelResponseFieldPath { get; set; }
            public System.Int32? InferenceConfig_MaxToken { get; set; }
            public List<System.String> InferenceConfig_StopSequence { get; set; }
            public System.Single? InferenceConfig_Temperature { get; set; }
            public System.Single? InferenceConfig_TopP { get; set; }
            public List<Amazon.BedrockRuntime.Model.Message> Message { get; set; }
            public System.String ModelId { get; set; }
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
