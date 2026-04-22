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
    /// Operation to invoke a Harness.
    /// </summary>
    [Cmdlet("Invoke", "BACHarness", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCore.Model.InvokeHarnessStreamOutput")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer InvokeHarness API operation.", Operation = new[] {"InvokeHarness"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.InvokeHarnessResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.InvokeHarnessStreamOutput or Amazon.BedrockAgentCore.Model.InvokeHarnessResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.Model.InvokeHarnessStreamOutput object.",
        "The service call response (type Amazon.BedrockAgentCore.Model.InvokeHarnessResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeBACHarnessCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActorId
        /// <summary>
        /// <para>
        /// <para>The actor ID for memory operations. Overrides the actor ID configured on the harness.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ActorId { get; set; }
        #endregion
        
        #region Parameter AllowedTool
        /// <summary>
        /// <para>
        /// <para>The tools that the agent is allowed to use for this invocation. If specified, overrides
        /// the harness default.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowedTools")]
        public System.String[] AllowedTool { get; set; }
        #endregion
        
        #region Parameter Model_GeminiModelConfig_ApiKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of your Gemini API key on AgentCore Identity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Model_GeminiModelConfig_ApiKeyArn { get; set; }
        #endregion
        
        #region Parameter Model_OpenAiModelConfig_ApiKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of your OpenAI API key on AgentCore Identity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Model_OpenAiModelConfig_ApiKeyArn { get; set; }
        #endregion
        
        #region Parameter HarnessArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the harness to invoke.</para>
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
        public System.String HarnessArn { get; set; }
        #endregion
        
        #region Parameter MaxIteration
        /// <summary>
        /// <para>
        /// <para>The maximum number of iterations the agent loop can execute. If specified, overrides
        /// the harness default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxIterations")]
        public System.Int32? MaxIteration { get; set; }
        #endregion
        
        #region Parameter MaxToken
        /// <summary>
        /// <para>
        /// <para>The maximum number of tokens the agent can generate per iteration. If specified, overrides
        /// the harness default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxTokens")]
        public System.Int32? MaxToken { get; set; }
        #endregion
        
        #region Parameter Model_BedrockModelConfig_MaxToken
        /// <summary>
        /// <para>
        /// <para>The maximum number of tokens to allow in the generated response per iteration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Model_BedrockModelConfig_MaxTokens")]
        public System.Int32? Model_BedrockModelConfig_MaxToken { get; set; }
        #endregion
        
        #region Parameter Model_GeminiModelConfig_MaxToken
        /// <summary>
        /// <para>
        /// <para>The maximum number of tokens to allow in the generated response per iteration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Model_GeminiModelConfig_MaxTokens")]
        public System.Int32? Model_GeminiModelConfig_MaxToken { get; set; }
        #endregion
        
        #region Parameter Model_OpenAiModelConfig_MaxToken
        /// <summary>
        /// <para>
        /// <para>The maximum number of tokens to allow in the generated response per iteration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Model_OpenAiModelConfig_MaxTokens")]
        public System.Int32? Model_OpenAiModelConfig_MaxToken { get; set; }
        #endregion
        
        #region Parameter Message
        /// <summary>
        /// <para>
        /// <para>The messages to send to the agent.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        public Amazon.BedrockAgentCore.Model.HarnessMessage[] Message { get; set; }
        #endregion
        
        #region Parameter Model_BedrockModelConfig_ModelId
        /// <summary>
        /// <para>
        /// <para>The Bedrock model ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Model_BedrockModelConfig_ModelId { get; set; }
        #endregion
        
        #region Parameter Model_GeminiModelConfig_ModelId
        /// <summary>
        /// <para>
        /// <para>The Gemini model ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Model_GeminiModelConfig_ModelId { get; set; }
        #endregion
        
        #region Parameter Model_OpenAiModelConfig_ModelId
        /// <summary>
        /// <para>
        /// <para>The OpenAI model ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Model_OpenAiModelConfig_ModelId { get; set; }
        #endregion
        
        #region Parameter RuntimeSessionId
        /// <summary>
        /// <para>
        /// <para>The session ID for the invocation. Use the same session ID across requests to continue
        /// a conversation.</para>
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
        public System.String RuntimeSessionId { get; set; }
        #endregion
        
        #region Parameter Skill
        /// <summary>
        /// <para>
        /// <para>The skills available to the agent for this invocation. If specified, overrides the
        /// harness default.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Skills")]
        public Amazon.BedrockAgentCore.Model.HarnessSkill[] Skill { get; set; }
        #endregion
        
        #region Parameter SystemPrompt
        /// <summary>
        /// <para>
        /// <para>The system prompt to use for this invocation. If specified, overrides the harness
        /// default.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.BedrockAgentCore.Model.HarnessSystemContentBlock[] SystemPrompt { get; set; }
        #endregion
        
        #region Parameter Model_BedrockModelConfig_Temperature
        /// <summary>
        /// <para>
        /// <para>The temperature to set when calling the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? Model_BedrockModelConfig_Temperature { get; set; }
        #endregion
        
        #region Parameter Model_GeminiModelConfig_Temperature
        /// <summary>
        /// <para>
        /// <para>The temperature to set when calling the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? Model_GeminiModelConfig_Temperature { get; set; }
        #endregion
        
        #region Parameter Model_OpenAiModelConfig_Temperature
        /// <summary>
        /// <para>
        /// <para>The temperature to set when calling the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? Model_OpenAiModelConfig_Temperature { get; set; }
        #endregion
        
        #region Parameter TimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The maximum duration in seconds for the agent loop execution. If specified, overrides
        /// the harness default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeoutSeconds")]
        public System.Int32? TimeoutSecond { get; set; }
        #endregion
        
        #region Parameter Tool
        /// <summary>
        /// <para>
        /// <para>The tools available to the agent for this invocation. If specified, overrides the
        /// harness default.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tools")]
        public Amazon.BedrockAgentCore.Model.HarnessTool[] Tool { get; set; }
        #endregion
        
        #region Parameter Model_GeminiModelConfig_TopK
        /// <summary>
        /// <para>
        /// <para>The topK set when calling the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Model_GeminiModelConfig_TopK { get; set; }
        #endregion
        
        #region Parameter Model_BedrockModelConfig_TopP
        /// <summary>
        /// <para>
        /// <para>The topP set when calling the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? Model_BedrockModelConfig_TopP { get; set; }
        #endregion
        
        #region Parameter Model_GeminiModelConfig_TopP
        /// <summary>
        /// <para>
        /// <para>The topP set when calling the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? Model_GeminiModelConfig_TopP { get; set; }
        #endregion
        
        #region Parameter Model_OpenAiModelConfig_TopP
        /// <summary>
        /// <para>
        /// <para>The topP set when calling the model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? Model_OpenAiModelConfig_TopP { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Stream'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.InvokeHarnessResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.InvokeHarnessResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Stream";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HarnessArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BACHarness (InvokeHarness)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.InvokeHarnessResponse, InvokeBACHarnessCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActorId = this.ActorId;
            if (this.AllowedTool != null)
            {
                context.AllowedTool = new List<System.String>(this.AllowedTool);
            }
            context.HarnessArn = this.HarnessArn;
            #if MODULAR
            if (this.HarnessArn == null && ParameterWasBound(nameof(this.HarnessArn)))
            {
                WriteWarning("You are passing $null as a value for parameter HarnessArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxIteration = this.MaxIteration;
            context.MaxToken = this.MaxToken;
            if (this.Message != null)
            {
                context.Message = new List<Amazon.BedrockAgentCore.Model.HarnessMessage>(this.Message);
            }
            #if MODULAR
            if (this.Message == null && ParameterWasBound(nameof(this.Message)))
            {
                WriteWarning("You are passing $null as a value for parameter Message which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Model_BedrockModelConfig_MaxToken = this.Model_BedrockModelConfig_MaxToken;
            context.Model_BedrockModelConfig_ModelId = this.Model_BedrockModelConfig_ModelId;
            context.Model_BedrockModelConfig_Temperature = this.Model_BedrockModelConfig_Temperature;
            context.Model_BedrockModelConfig_TopP = this.Model_BedrockModelConfig_TopP;
            context.Model_GeminiModelConfig_ApiKeyArn = this.Model_GeminiModelConfig_ApiKeyArn;
            context.Model_GeminiModelConfig_MaxToken = this.Model_GeminiModelConfig_MaxToken;
            context.Model_GeminiModelConfig_ModelId = this.Model_GeminiModelConfig_ModelId;
            context.Model_GeminiModelConfig_Temperature = this.Model_GeminiModelConfig_Temperature;
            context.Model_GeminiModelConfig_TopK = this.Model_GeminiModelConfig_TopK;
            context.Model_GeminiModelConfig_TopP = this.Model_GeminiModelConfig_TopP;
            context.Model_OpenAiModelConfig_ApiKeyArn = this.Model_OpenAiModelConfig_ApiKeyArn;
            context.Model_OpenAiModelConfig_MaxToken = this.Model_OpenAiModelConfig_MaxToken;
            context.Model_OpenAiModelConfig_ModelId = this.Model_OpenAiModelConfig_ModelId;
            context.Model_OpenAiModelConfig_Temperature = this.Model_OpenAiModelConfig_Temperature;
            context.Model_OpenAiModelConfig_TopP = this.Model_OpenAiModelConfig_TopP;
            context.RuntimeSessionId = this.RuntimeSessionId;
            #if MODULAR
            if (this.RuntimeSessionId == null && ParameterWasBound(nameof(this.RuntimeSessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter RuntimeSessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Skill != null)
            {
                context.Skill = new List<Amazon.BedrockAgentCore.Model.HarnessSkill>(this.Skill);
            }
            if (this.SystemPrompt != null)
            {
                context.SystemPrompt = new List<Amazon.BedrockAgentCore.Model.HarnessSystemContentBlock>(this.SystemPrompt);
            }
            context.TimeoutSecond = this.TimeoutSecond;
            if (this.Tool != null)
            {
                context.Tool = new List<Amazon.BedrockAgentCore.Model.HarnessTool>(this.Tool);
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
            var request = new Amazon.BedrockAgentCore.Model.InvokeHarnessRequest();
            
            if (cmdletContext.ActorId != null)
            {
                request.ActorId = cmdletContext.ActorId;
            }
            if (cmdletContext.AllowedTool != null)
            {
                request.AllowedTools = cmdletContext.AllowedTool;
            }
            if (cmdletContext.HarnessArn != null)
            {
                request.HarnessArn = cmdletContext.HarnessArn;
            }
            if (cmdletContext.MaxIteration != null)
            {
                request.MaxIterations = cmdletContext.MaxIteration.Value;
            }
            if (cmdletContext.MaxToken != null)
            {
                request.MaxTokens = cmdletContext.MaxToken.Value;
            }
            if (cmdletContext.Message != null)
            {
                request.Messages = cmdletContext.Message;
            }
            
             // populate Model
            var requestModelIsNull = true;
            request.Model = new Amazon.BedrockAgentCore.Model.HarnessModelConfiguration();
            Amazon.BedrockAgentCore.Model.HarnessBedrockModelConfig requestModel_model_BedrockModelConfig = null;
            
             // populate BedrockModelConfig
            var requestModel_model_BedrockModelConfigIsNull = true;
            requestModel_model_BedrockModelConfig = new Amazon.BedrockAgentCore.Model.HarnessBedrockModelConfig();
            System.Int32? requestModel_model_BedrockModelConfig_model_BedrockModelConfig_MaxToken = null;
            if (cmdletContext.Model_BedrockModelConfig_MaxToken != null)
            {
                requestModel_model_BedrockModelConfig_model_BedrockModelConfig_MaxToken = cmdletContext.Model_BedrockModelConfig_MaxToken.Value;
            }
            if (requestModel_model_BedrockModelConfig_model_BedrockModelConfig_MaxToken != null)
            {
                requestModel_model_BedrockModelConfig.MaxTokens = requestModel_model_BedrockModelConfig_model_BedrockModelConfig_MaxToken.Value;
                requestModel_model_BedrockModelConfigIsNull = false;
            }
            System.String requestModel_model_BedrockModelConfig_model_BedrockModelConfig_ModelId = null;
            if (cmdletContext.Model_BedrockModelConfig_ModelId != null)
            {
                requestModel_model_BedrockModelConfig_model_BedrockModelConfig_ModelId = cmdletContext.Model_BedrockModelConfig_ModelId;
            }
            if (requestModel_model_BedrockModelConfig_model_BedrockModelConfig_ModelId != null)
            {
                requestModel_model_BedrockModelConfig.ModelId = requestModel_model_BedrockModelConfig_model_BedrockModelConfig_ModelId;
                requestModel_model_BedrockModelConfigIsNull = false;
            }
            System.Single? requestModel_model_BedrockModelConfig_model_BedrockModelConfig_Temperature = null;
            if (cmdletContext.Model_BedrockModelConfig_Temperature != null)
            {
                requestModel_model_BedrockModelConfig_model_BedrockModelConfig_Temperature = cmdletContext.Model_BedrockModelConfig_Temperature.Value;
            }
            if (requestModel_model_BedrockModelConfig_model_BedrockModelConfig_Temperature != null)
            {
                requestModel_model_BedrockModelConfig.Temperature = requestModel_model_BedrockModelConfig_model_BedrockModelConfig_Temperature.Value;
                requestModel_model_BedrockModelConfigIsNull = false;
            }
            System.Single? requestModel_model_BedrockModelConfig_model_BedrockModelConfig_TopP = null;
            if (cmdletContext.Model_BedrockModelConfig_TopP != null)
            {
                requestModel_model_BedrockModelConfig_model_BedrockModelConfig_TopP = cmdletContext.Model_BedrockModelConfig_TopP.Value;
            }
            if (requestModel_model_BedrockModelConfig_model_BedrockModelConfig_TopP != null)
            {
                requestModel_model_BedrockModelConfig.TopP = requestModel_model_BedrockModelConfig_model_BedrockModelConfig_TopP.Value;
                requestModel_model_BedrockModelConfigIsNull = false;
            }
             // determine if requestModel_model_BedrockModelConfig should be set to null
            if (requestModel_model_BedrockModelConfigIsNull)
            {
                requestModel_model_BedrockModelConfig = null;
            }
            if (requestModel_model_BedrockModelConfig != null)
            {
                request.Model.BedrockModelConfig = requestModel_model_BedrockModelConfig;
                requestModelIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.HarnessOpenAiModelConfig requestModel_model_OpenAiModelConfig = null;
            
             // populate OpenAiModelConfig
            var requestModel_model_OpenAiModelConfigIsNull = true;
            requestModel_model_OpenAiModelConfig = new Amazon.BedrockAgentCore.Model.HarnessOpenAiModelConfig();
            System.String requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_ApiKeyArn = null;
            if (cmdletContext.Model_OpenAiModelConfig_ApiKeyArn != null)
            {
                requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_ApiKeyArn = cmdletContext.Model_OpenAiModelConfig_ApiKeyArn;
            }
            if (requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_ApiKeyArn != null)
            {
                requestModel_model_OpenAiModelConfig.ApiKeyArn = requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_ApiKeyArn;
                requestModel_model_OpenAiModelConfigIsNull = false;
            }
            System.Int32? requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_MaxToken = null;
            if (cmdletContext.Model_OpenAiModelConfig_MaxToken != null)
            {
                requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_MaxToken = cmdletContext.Model_OpenAiModelConfig_MaxToken.Value;
            }
            if (requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_MaxToken != null)
            {
                requestModel_model_OpenAiModelConfig.MaxTokens = requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_MaxToken.Value;
                requestModel_model_OpenAiModelConfigIsNull = false;
            }
            System.String requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_ModelId = null;
            if (cmdletContext.Model_OpenAiModelConfig_ModelId != null)
            {
                requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_ModelId = cmdletContext.Model_OpenAiModelConfig_ModelId;
            }
            if (requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_ModelId != null)
            {
                requestModel_model_OpenAiModelConfig.ModelId = requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_ModelId;
                requestModel_model_OpenAiModelConfigIsNull = false;
            }
            System.Single? requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_Temperature = null;
            if (cmdletContext.Model_OpenAiModelConfig_Temperature != null)
            {
                requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_Temperature = cmdletContext.Model_OpenAiModelConfig_Temperature.Value;
            }
            if (requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_Temperature != null)
            {
                requestModel_model_OpenAiModelConfig.Temperature = requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_Temperature.Value;
                requestModel_model_OpenAiModelConfigIsNull = false;
            }
            System.Single? requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_TopP = null;
            if (cmdletContext.Model_OpenAiModelConfig_TopP != null)
            {
                requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_TopP = cmdletContext.Model_OpenAiModelConfig_TopP.Value;
            }
            if (requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_TopP != null)
            {
                requestModel_model_OpenAiModelConfig.TopP = requestModel_model_OpenAiModelConfig_model_OpenAiModelConfig_TopP.Value;
                requestModel_model_OpenAiModelConfigIsNull = false;
            }
             // determine if requestModel_model_OpenAiModelConfig should be set to null
            if (requestModel_model_OpenAiModelConfigIsNull)
            {
                requestModel_model_OpenAiModelConfig = null;
            }
            if (requestModel_model_OpenAiModelConfig != null)
            {
                request.Model.OpenAiModelConfig = requestModel_model_OpenAiModelConfig;
                requestModelIsNull = false;
            }
            Amazon.BedrockAgentCore.Model.HarnessGeminiModelConfig requestModel_model_GeminiModelConfig = null;
            
             // populate GeminiModelConfig
            var requestModel_model_GeminiModelConfigIsNull = true;
            requestModel_model_GeminiModelConfig = new Amazon.BedrockAgentCore.Model.HarnessGeminiModelConfig();
            System.String requestModel_model_GeminiModelConfig_model_GeminiModelConfig_ApiKeyArn = null;
            if (cmdletContext.Model_GeminiModelConfig_ApiKeyArn != null)
            {
                requestModel_model_GeminiModelConfig_model_GeminiModelConfig_ApiKeyArn = cmdletContext.Model_GeminiModelConfig_ApiKeyArn;
            }
            if (requestModel_model_GeminiModelConfig_model_GeminiModelConfig_ApiKeyArn != null)
            {
                requestModel_model_GeminiModelConfig.ApiKeyArn = requestModel_model_GeminiModelConfig_model_GeminiModelConfig_ApiKeyArn;
                requestModel_model_GeminiModelConfigIsNull = false;
            }
            System.Int32? requestModel_model_GeminiModelConfig_model_GeminiModelConfig_MaxToken = null;
            if (cmdletContext.Model_GeminiModelConfig_MaxToken != null)
            {
                requestModel_model_GeminiModelConfig_model_GeminiModelConfig_MaxToken = cmdletContext.Model_GeminiModelConfig_MaxToken.Value;
            }
            if (requestModel_model_GeminiModelConfig_model_GeminiModelConfig_MaxToken != null)
            {
                requestModel_model_GeminiModelConfig.MaxTokens = requestModel_model_GeminiModelConfig_model_GeminiModelConfig_MaxToken.Value;
                requestModel_model_GeminiModelConfigIsNull = false;
            }
            System.String requestModel_model_GeminiModelConfig_model_GeminiModelConfig_ModelId = null;
            if (cmdletContext.Model_GeminiModelConfig_ModelId != null)
            {
                requestModel_model_GeminiModelConfig_model_GeminiModelConfig_ModelId = cmdletContext.Model_GeminiModelConfig_ModelId;
            }
            if (requestModel_model_GeminiModelConfig_model_GeminiModelConfig_ModelId != null)
            {
                requestModel_model_GeminiModelConfig.ModelId = requestModel_model_GeminiModelConfig_model_GeminiModelConfig_ModelId;
                requestModel_model_GeminiModelConfigIsNull = false;
            }
            System.Single? requestModel_model_GeminiModelConfig_model_GeminiModelConfig_Temperature = null;
            if (cmdletContext.Model_GeminiModelConfig_Temperature != null)
            {
                requestModel_model_GeminiModelConfig_model_GeminiModelConfig_Temperature = cmdletContext.Model_GeminiModelConfig_Temperature.Value;
            }
            if (requestModel_model_GeminiModelConfig_model_GeminiModelConfig_Temperature != null)
            {
                requestModel_model_GeminiModelConfig.Temperature = requestModel_model_GeminiModelConfig_model_GeminiModelConfig_Temperature.Value;
                requestModel_model_GeminiModelConfigIsNull = false;
            }
            System.Int32? requestModel_model_GeminiModelConfig_model_GeminiModelConfig_TopK = null;
            if (cmdletContext.Model_GeminiModelConfig_TopK != null)
            {
                requestModel_model_GeminiModelConfig_model_GeminiModelConfig_TopK = cmdletContext.Model_GeminiModelConfig_TopK.Value;
            }
            if (requestModel_model_GeminiModelConfig_model_GeminiModelConfig_TopK != null)
            {
                requestModel_model_GeminiModelConfig.TopK = requestModel_model_GeminiModelConfig_model_GeminiModelConfig_TopK.Value;
                requestModel_model_GeminiModelConfigIsNull = false;
            }
            System.Single? requestModel_model_GeminiModelConfig_model_GeminiModelConfig_TopP = null;
            if (cmdletContext.Model_GeminiModelConfig_TopP != null)
            {
                requestModel_model_GeminiModelConfig_model_GeminiModelConfig_TopP = cmdletContext.Model_GeminiModelConfig_TopP.Value;
            }
            if (requestModel_model_GeminiModelConfig_model_GeminiModelConfig_TopP != null)
            {
                requestModel_model_GeminiModelConfig.TopP = requestModel_model_GeminiModelConfig_model_GeminiModelConfig_TopP.Value;
                requestModel_model_GeminiModelConfigIsNull = false;
            }
             // determine if requestModel_model_GeminiModelConfig should be set to null
            if (requestModel_model_GeminiModelConfigIsNull)
            {
                requestModel_model_GeminiModelConfig = null;
            }
            if (requestModel_model_GeminiModelConfig != null)
            {
                request.Model.GeminiModelConfig = requestModel_model_GeminiModelConfig;
                requestModelIsNull = false;
            }
             // determine if request.Model should be set to null
            if (requestModelIsNull)
            {
                request.Model = null;
            }
            if (cmdletContext.RuntimeSessionId != null)
            {
                request.RuntimeSessionId = cmdletContext.RuntimeSessionId;
            }
            if (cmdletContext.Skill != null)
            {
                request.Skills = cmdletContext.Skill;
            }
            if (cmdletContext.SystemPrompt != null)
            {
                request.SystemPrompt = cmdletContext.SystemPrompt;
            }
            if (cmdletContext.TimeoutSecond != null)
            {
                request.TimeoutSeconds = cmdletContext.TimeoutSecond.Value;
            }
            if (cmdletContext.Tool != null)
            {
                request.Tools = cmdletContext.Tool;
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
        
        private Amazon.BedrockAgentCore.Model.InvokeHarnessResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.InvokeHarnessRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "InvokeHarness");
            try
            {
                return client.InvokeHarnessAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ActorId { get; set; }
            public List<System.String> AllowedTool { get; set; }
            public System.String HarnessArn { get; set; }
            public System.Int32? MaxIteration { get; set; }
            public System.Int32? MaxToken { get; set; }
            public List<Amazon.BedrockAgentCore.Model.HarnessMessage> Message { get; set; }
            public System.Int32? Model_BedrockModelConfig_MaxToken { get; set; }
            public System.String Model_BedrockModelConfig_ModelId { get; set; }
            public System.Single? Model_BedrockModelConfig_Temperature { get; set; }
            public System.Single? Model_BedrockModelConfig_TopP { get; set; }
            public System.String Model_GeminiModelConfig_ApiKeyArn { get; set; }
            public System.Int32? Model_GeminiModelConfig_MaxToken { get; set; }
            public System.String Model_GeminiModelConfig_ModelId { get; set; }
            public System.Single? Model_GeminiModelConfig_Temperature { get; set; }
            public System.Int32? Model_GeminiModelConfig_TopK { get; set; }
            public System.Single? Model_GeminiModelConfig_TopP { get; set; }
            public System.String Model_OpenAiModelConfig_ApiKeyArn { get; set; }
            public System.Int32? Model_OpenAiModelConfig_MaxToken { get; set; }
            public System.String Model_OpenAiModelConfig_ModelId { get; set; }
            public System.Single? Model_OpenAiModelConfig_Temperature { get; set; }
            public System.Single? Model_OpenAiModelConfig_TopP { get; set; }
            public System.String RuntimeSessionId { get; set; }
            public List<Amazon.BedrockAgentCore.Model.HarnessSkill> Skill { get; set; }
            public List<Amazon.BedrockAgentCore.Model.HarnessSystemContentBlock> SystemPrompt { get; set; }
            public System.Int32? TimeoutSecond { get; set; }
            public List<Amazon.BedrockAgentCore.Model.HarnessTool> Tool { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.InvokeHarnessResponse, InvokeBACHarnessCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Stream;
        }
        
    }
}
