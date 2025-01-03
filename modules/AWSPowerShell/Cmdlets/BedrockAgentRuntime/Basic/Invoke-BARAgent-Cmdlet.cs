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
using Amazon.BedrockAgentRuntime;
using Amazon.BedrockAgentRuntime.Model;

namespace Amazon.PowerShell.Cmdlets.BAR
{
    /// <summary>
    /// <note><para>
    /// The CLI doesn't support streaming operations in Amazon Bedrock, including <c>InvokeAgent</c>.
    /// </para></note><para>
    /// Sends a prompt for the agent to process and respond to. Note the following fields
    /// for the request:
    /// </para><ul><li><para>
    /// To continue the same conversation with an agent, use the same <c>sessionId</c> value
    /// in the request.
    /// </para></li><li><para>
    /// To activate trace enablement, turn <c>enableTrace</c> to <c>true</c>. Trace enablement
    /// helps you follow the agent's reasoning process that led it to the information it processed,
    /// the actions it took, and the final result it yielded. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/agents-test.html#trace-events">Trace
    /// enablement</a>.
    /// </para></li><li><para>
    /// To stream agent responses, make sure that only orchestration prompt is enabled. Agent
    /// streaming is not supported for the following steps: 
    /// </para><ul><li><para><c>Pre-processing</c></para></li><li><para><c>Post-processing</c></para></li><li><para>
    /// Agent with 1 Knowledge base and <c>User Input</c> not enabled
    /// </para></li></ul></li><li><para>
    /// End a conversation by setting <c>endSession</c> to <c>true</c>.
    /// </para></li><li><para>
    /// In the <c>sessionState</c> object, you can include attributes for the session or prompt
    /// or, if you configured an action group to return control, results from invocation of
    /// the action group.
    /// </para></li></ul><para>
    /// The response is returned in the <c>bytes</c> field of the <c>chunk</c> object.
    /// </para><ul><li><para>
    /// The <c>attribution</c> object contains citations for parts of the response.
    /// </para></li><li><para>
    /// If you set <c>enableTrace</c> to <c>true</c> in the request, you can trace the agent's
    /// steps and reasoning process that led it to the response.
    /// </para></li><li><para>
    /// If the action predicted was configured to return control, the response returns parameters
    /// for the action, elicited from the user, in the <c>returnControl</c> field.
    /// </para></li><li><para>
    /// Errors are also surfaced in the response.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Invoke", "BARAgent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentRuntime.Model.InvokeAgentResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Runtime InvokeAgent API operation.", Operation = new[] {"InvokeAgent"}, SelectReturnType = typeof(Amazon.BedrockAgentRuntime.Model.InvokeAgentResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentRuntime.Model.InvokeAgentResponse",
        "This cmdlet returns an Amazon.BedrockAgentRuntime.Model.InvokeAgentResponse object containing multiple properties."
    )]
    public partial class InvokeBARAgentCmdlet : AmazonBedrockAgentRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AgentAliasId
        /// <summary>
        /// <para>
        /// <para>The alias of the agent to use.</para>
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
        public System.String AgentAliasId { get; set; }
        #endregion
        
        #region Parameter AgentId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the agent to use.</para>
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
        public System.String AgentId { get; set; }
        #endregion
        
        #region Parameter StreamingConfigurations_ApplyGuardrailInterval
        /// <summary>
        /// <para>
        /// <para> The guardrail interval to apply as response is generated. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StreamingConfigurations_ApplyGuardrailInterval { get; set; }
        #endregion
        
        #region Parameter EnableTrace
        /// <summary>
        /// <para>
        /// <para>Specifies whether to turn on the trace or not to track the agent's reasoning process.
        /// For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/agents-test.html#trace-events">Trace
        /// enablement</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableTrace { get; set; }
        #endregion
        
        #region Parameter EndSession
        /// <summary>
        /// <para>
        /// <para>Specifies whether to end the session with the agent or not.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EndSession { get; set; }
        #endregion
        
        #region Parameter SessionState_File
        /// <summary>
        /// <para>
        /// <para>Contains information about the files used by code interpreter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionState_Files")]
        public Amazon.BedrockAgentRuntime.Model.InputFile[] SessionState_File { get; set; }
        #endregion
        
        #region Parameter InputText
        /// <summary>
        /// <para>
        /// <para>The prompt text to send the agent.</para><note><para>If you include <c>returnControlInvocationResults</c> in the <c>sessionState</c> field,
        /// the <c>inputText</c> field will be ignored.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputText { get; set; }
        #endregion
        
        #region Parameter SessionState_InvocationId
        /// <summary>
        /// <para>
        /// <para>The identifier of the invocation of an action. This value must match the <c>invocationId</c>
        /// returned in the <c>InvokeAgent</c> response for the action whose results are provided
        /// in the <c>returnControlInvocationResults</c> field. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/agents-returncontrol.html">Return
        /// control to the agent developer</a> and <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/agents-session-state.html">Control
        /// session context</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionState_InvocationId { get; set; }
        #endregion
        
        #region Parameter SessionState_KnowledgeBaseConfiguration
        /// <summary>
        /// <para>
        /// <para>An array of configurations, each of which applies to a knowledge base attached to
        /// the agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionState_KnowledgeBaseConfigurations")]
        public Amazon.BedrockAgentRuntime.Model.KnowledgeBaseConfiguration[] SessionState_KnowledgeBaseConfiguration { get; set; }
        #endregion
        
        #region Parameter PerformanceConfig_Latency
        /// <summary>
        /// <para>
        /// <para>To use a latency-optimized version of the model, set to <c>optimized</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BedrockModelConfigurations_PerformanceConfig_Latency")]
        [AWSConstantClassSource("Amazon.BedrockAgentRuntime.PerformanceConfigLatency")]
        public Amazon.BedrockAgentRuntime.PerformanceConfigLatency PerformanceConfig_Latency { get; set; }
        #endregion
        
        #region Parameter MemoryId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the agent memory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MemoryId { get; set; }
        #endregion
        
        #region Parameter ConversationHistory_Message
        /// <summary>
        /// <para>
        /// <para>The conversation's messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionState_ConversationHistory_Messages")]
        public Amazon.BedrockAgentRuntime.Model.Message[] ConversationHistory_Message { get; set; }
        #endregion
        
        #region Parameter SessionState_PromptSessionAttribute
        /// <summary>
        /// <para>
        /// <para>Contains attributes that persist across a prompt and the values of those attributes.
        /// These attributes replace the $prompt_session_attributes$ placeholder variable in the
        /// orchestration prompt template. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/prompt-placeholders.html">Prompt
        /// template placeholder variables</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionState_PromptSessionAttributes")]
        public System.Collections.Hashtable SessionState_PromptSessionAttribute { get; set; }
        #endregion
        
        #region Parameter SessionState_ReturnControlInvocationResult
        /// <summary>
        /// <para>
        /// <para>Contains information about the results from the action group invocation. For more
        /// information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/agents-returncontrol.html">Return
        /// control to the agent developer</a> and <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/agents-session-state.html">Control
        /// session context</a>.</para><note><para>If you include this field, the <c>inputText</c> field will be ignored.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionState_ReturnControlInvocationResults")]
        public Amazon.BedrockAgentRuntime.Model.InvocationResultMember[] SessionState_ReturnControlInvocationResult { get; set; }
        #endregion
        
        #region Parameter SessionState_SessionAttribute
        /// <summary>
        /// <para>
        /// <para>Contains attributes that persist across a session and the values of those attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionState_SessionAttributes")]
        public System.Collections.Hashtable SessionState_SessionAttribute { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the session. Use the same value across requests to continue
        /// the same conversation.</para>
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
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter SourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the resource making the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceArn { get; set; }
        #endregion
        
        #region Parameter StreamingConfigurations_StreamFinalResponse
        /// <summary>
        /// <para>
        /// <para> Specifies whether to enable streaming for the final response. This is set to <c>false</c>
        /// by default. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? StreamingConfigurations_StreamFinalResponse { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentRuntime.Model.InvokeAgentResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentRuntime.Model.InvokeAgentResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AgentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BARAgent (InvokeAgent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentRuntime.Model.InvokeAgentResponse, InvokeBARAgentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentAliasId = this.AgentAliasId;
            #if MODULAR
            if (this.AgentAliasId == null && ParameterWasBound(nameof(this.AgentAliasId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentAliasId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AgentId = this.AgentId;
            #if MODULAR
            if (this.AgentId == null && ParameterWasBound(nameof(this.AgentId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PerformanceConfig_Latency = this.PerformanceConfig_Latency;
            context.EnableTrace = this.EnableTrace;
            context.EndSession = this.EndSession;
            context.InputText = this.InputText;
            context.MemoryId = this.MemoryId;
            context.SessionId = this.SessionId;
            #if MODULAR
            if (this.SessionId == null && ParameterWasBound(nameof(this.SessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ConversationHistory_Message != null)
            {
                context.ConversationHistory_Message = new List<Amazon.BedrockAgentRuntime.Model.Message>(this.ConversationHistory_Message);
            }
            if (this.SessionState_File != null)
            {
                context.SessionState_File = new List<Amazon.BedrockAgentRuntime.Model.InputFile>(this.SessionState_File);
            }
            context.SessionState_InvocationId = this.SessionState_InvocationId;
            if (this.SessionState_KnowledgeBaseConfiguration != null)
            {
                context.SessionState_KnowledgeBaseConfiguration = new List<Amazon.BedrockAgentRuntime.Model.KnowledgeBaseConfiguration>(this.SessionState_KnowledgeBaseConfiguration);
            }
            if (this.SessionState_PromptSessionAttribute != null)
            {
                context.SessionState_PromptSessionAttribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SessionState_PromptSessionAttribute.Keys)
                {
                    context.SessionState_PromptSessionAttribute.Add((String)hashKey, (System.String)(this.SessionState_PromptSessionAttribute[hashKey]));
                }
            }
            if (this.SessionState_ReturnControlInvocationResult != null)
            {
                context.SessionState_ReturnControlInvocationResult = new List<Amazon.BedrockAgentRuntime.Model.InvocationResultMember>(this.SessionState_ReturnControlInvocationResult);
            }
            if (this.SessionState_SessionAttribute != null)
            {
                context.SessionState_SessionAttribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SessionState_SessionAttribute.Keys)
                {
                    context.SessionState_SessionAttribute.Add((String)hashKey, (System.String)(this.SessionState_SessionAttribute[hashKey]));
                }
            }
            context.SourceArn = this.SourceArn;
            context.StreamingConfigurations_ApplyGuardrailInterval = this.StreamingConfigurations_ApplyGuardrailInterval;
            context.StreamingConfigurations_StreamFinalResponse = this.StreamingConfigurations_StreamFinalResponse;
            
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
            var request = new Amazon.BedrockAgentRuntime.Model.InvokeAgentRequest();
            
            if (cmdletContext.AgentAliasId != null)
            {
                request.AgentAliasId = cmdletContext.AgentAliasId;
            }
            if (cmdletContext.AgentId != null)
            {
                request.AgentId = cmdletContext.AgentId;
            }
            
             // populate BedrockModelConfigurations
            var requestBedrockModelConfigurationsIsNull = true;
            request.BedrockModelConfigurations = new Amazon.BedrockAgentRuntime.Model.BedrockModelConfigurations();
            Amazon.BedrockAgentRuntime.Model.PerformanceConfiguration requestBedrockModelConfigurations_bedrockModelConfigurations_PerformanceConfig = null;
            
             // populate PerformanceConfig
            var requestBedrockModelConfigurations_bedrockModelConfigurations_PerformanceConfigIsNull = true;
            requestBedrockModelConfigurations_bedrockModelConfigurations_PerformanceConfig = new Amazon.BedrockAgentRuntime.Model.PerformanceConfiguration();
            Amazon.BedrockAgentRuntime.PerformanceConfigLatency requestBedrockModelConfigurations_bedrockModelConfigurations_PerformanceConfig_performanceConfig_Latency = null;
            if (cmdletContext.PerformanceConfig_Latency != null)
            {
                requestBedrockModelConfigurations_bedrockModelConfigurations_PerformanceConfig_performanceConfig_Latency = cmdletContext.PerformanceConfig_Latency;
            }
            if (requestBedrockModelConfigurations_bedrockModelConfigurations_PerformanceConfig_performanceConfig_Latency != null)
            {
                requestBedrockModelConfigurations_bedrockModelConfigurations_PerformanceConfig.Latency = requestBedrockModelConfigurations_bedrockModelConfigurations_PerformanceConfig_performanceConfig_Latency;
                requestBedrockModelConfigurations_bedrockModelConfigurations_PerformanceConfigIsNull = false;
            }
             // determine if requestBedrockModelConfigurations_bedrockModelConfigurations_PerformanceConfig should be set to null
            if (requestBedrockModelConfigurations_bedrockModelConfigurations_PerformanceConfigIsNull)
            {
                requestBedrockModelConfigurations_bedrockModelConfigurations_PerformanceConfig = null;
            }
            if (requestBedrockModelConfigurations_bedrockModelConfigurations_PerformanceConfig != null)
            {
                request.BedrockModelConfigurations.PerformanceConfig = requestBedrockModelConfigurations_bedrockModelConfigurations_PerformanceConfig;
                requestBedrockModelConfigurationsIsNull = false;
            }
             // determine if request.BedrockModelConfigurations should be set to null
            if (requestBedrockModelConfigurationsIsNull)
            {
                request.BedrockModelConfigurations = null;
            }
            if (cmdletContext.EnableTrace != null)
            {
                request.EnableTrace = cmdletContext.EnableTrace.Value;
            }
            if (cmdletContext.EndSession != null)
            {
                request.EndSession = cmdletContext.EndSession.Value;
            }
            if (cmdletContext.InputText != null)
            {
                request.InputText = cmdletContext.InputText;
            }
            if (cmdletContext.MemoryId != null)
            {
                request.MemoryId = cmdletContext.MemoryId;
            }
            if (cmdletContext.SessionId != null)
            {
                request.SessionId = cmdletContext.SessionId;
            }
            
             // populate SessionState
            var requestSessionStateIsNull = true;
            request.SessionState = new Amazon.BedrockAgentRuntime.Model.SessionState();
            List<Amazon.BedrockAgentRuntime.Model.InputFile> requestSessionState_sessionState_File = null;
            if (cmdletContext.SessionState_File != null)
            {
                requestSessionState_sessionState_File = cmdletContext.SessionState_File;
            }
            if (requestSessionState_sessionState_File != null)
            {
                request.SessionState.Files = requestSessionState_sessionState_File;
                requestSessionStateIsNull = false;
            }
            System.String requestSessionState_sessionState_InvocationId = null;
            if (cmdletContext.SessionState_InvocationId != null)
            {
                requestSessionState_sessionState_InvocationId = cmdletContext.SessionState_InvocationId;
            }
            if (requestSessionState_sessionState_InvocationId != null)
            {
                request.SessionState.InvocationId = requestSessionState_sessionState_InvocationId;
                requestSessionStateIsNull = false;
            }
            List<Amazon.BedrockAgentRuntime.Model.KnowledgeBaseConfiguration> requestSessionState_sessionState_KnowledgeBaseConfiguration = null;
            if (cmdletContext.SessionState_KnowledgeBaseConfiguration != null)
            {
                requestSessionState_sessionState_KnowledgeBaseConfiguration = cmdletContext.SessionState_KnowledgeBaseConfiguration;
            }
            if (requestSessionState_sessionState_KnowledgeBaseConfiguration != null)
            {
                request.SessionState.KnowledgeBaseConfigurations = requestSessionState_sessionState_KnowledgeBaseConfiguration;
                requestSessionStateIsNull = false;
            }
            Dictionary<System.String, System.String> requestSessionState_sessionState_PromptSessionAttribute = null;
            if (cmdletContext.SessionState_PromptSessionAttribute != null)
            {
                requestSessionState_sessionState_PromptSessionAttribute = cmdletContext.SessionState_PromptSessionAttribute;
            }
            if (requestSessionState_sessionState_PromptSessionAttribute != null)
            {
                request.SessionState.PromptSessionAttributes = requestSessionState_sessionState_PromptSessionAttribute;
                requestSessionStateIsNull = false;
            }
            List<Amazon.BedrockAgentRuntime.Model.InvocationResultMember> requestSessionState_sessionState_ReturnControlInvocationResult = null;
            if (cmdletContext.SessionState_ReturnControlInvocationResult != null)
            {
                requestSessionState_sessionState_ReturnControlInvocationResult = cmdletContext.SessionState_ReturnControlInvocationResult;
            }
            if (requestSessionState_sessionState_ReturnControlInvocationResult != null)
            {
                request.SessionState.ReturnControlInvocationResults = requestSessionState_sessionState_ReturnControlInvocationResult;
                requestSessionStateIsNull = false;
            }
            Dictionary<System.String, System.String> requestSessionState_sessionState_SessionAttribute = null;
            if (cmdletContext.SessionState_SessionAttribute != null)
            {
                requestSessionState_sessionState_SessionAttribute = cmdletContext.SessionState_SessionAttribute;
            }
            if (requestSessionState_sessionState_SessionAttribute != null)
            {
                request.SessionState.SessionAttributes = requestSessionState_sessionState_SessionAttribute;
                requestSessionStateIsNull = false;
            }
            Amazon.BedrockAgentRuntime.Model.ConversationHistory requestSessionState_sessionState_ConversationHistory = null;
            
             // populate ConversationHistory
            var requestSessionState_sessionState_ConversationHistoryIsNull = true;
            requestSessionState_sessionState_ConversationHistory = new Amazon.BedrockAgentRuntime.Model.ConversationHistory();
            List<Amazon.BedrockAgentRuntime.Model.Message> requestSessionState_sessionState_ConversationHistory_conversationHistory_Message = null;
            if (cmdletContext.ConversationHistory_Message != null)
            {
                requestSessionState_sessionState_ConversationHistory_conversationHistory_Message = cmdletContext.ConversationHistory_Message;
            }
            if (requestSessionState_sessionState_ConversationHistory_conversationHistory_Message != null)
            {
                requestSessionState_sessionState_ConversationHistory.Messages = requestSessionState_sessionState_ConversationHistory_conversationHistory_Message;
                requestSessionState_sessionState_ConversationHistoryIsNull = false;
            }
             // determine if requestSessionState_sessionState_ConversationHistory should be set to null
            if (requestSessionState_sessionState_ConversationHistoryIsNull)
            {
                requestSessionState_sessionState_ConversationHistory = null;
            }
            if (requestSessionState_sessionState_ConversationHistory != null)
            {
                request.SessionState.ConversationHistory = requestSessionState_sessionState_ConversationHistory;
                requestSessionStateIsNull = false;
            }
             // determine if request.SessionState should be set to null
            if (requestSessionStateIsNull)
            {
                request.SessionState = null;
            }
            if (cmdletContext.SourceArn != null)
            {
                request.SourceArn = cmdletContext.SourceArn;
            }
            
             // populate StreamingConfigurations
            var requestStreamingConfigurationsIsNull = true;
            request.StreamingConfigurations = new Amazon.BedrockAgentRuntime.Model.StreamingConfigurations();
            System.Int32? requestStreamingConfigurations_streamingConfigurations_ApplyGuardrailInterval = null;
            if (cmdletContext.StreamingConfigurations_ApplyGuardrailInterval != null)
            {
                requestStreamingConfigurations_streamingConfigurations_ApplyGuardrailInterval = cmdletContext.StreamingConfigurations_ApplyGuardrailInterval.Value;
            }
            if (requestStreamingConfigurations_streamingConfigurations_ApplyGuardrailInterval != null)
            {
                request.StreamingConfigurations.ApplyGuardrailInterval = requestStreamingConfigurations_streamingConfigurations_ApplyGuardrailInterval.Value;
                requestStreamingConfigurationsIsNull = false;
            }
            System.Boolean? requestStreamingConfigurations_streamingConfigurations_StreamFinalResponse = null;
            if (cmdletContext.StreamingConfigurations_StreamFinalResponse != null)
            {
                requestStreamingConfigurations_streamingConfigurations_StreamFinalResponse = cmdletContext.StreamingConfigurations_StreamFinalResponse.Value;
            }
            if (requestStreamingConfigurations_streamingConfigurations_StreamFinalResponse != null)
            {
                request.StreamingConfigurations.StreamFinalResponse = requestStreamingConfigurations_streamingConfigurations_StreamFinalResponse.Value;
                requestStreamingConfigurationsIsNull = false;
            }
             // determine if request.StreamingConfigurations should be set to null
            if (requestStreamingConfigurationsIsNull)
            {
                request.StreamingConfigurations = null;
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
        
        private Amazon.BedrockAgentRuntime.Model.InvokeAgentResponse CallAWSServiceOperation(IAmazonBedrockAgentRuntime client, Amazon.BedrockAgentRuntime.Model.InvokeAgentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Runtime", "InvokeAgent");
            try
            {
                #if DESKTOP
                return client.InvokeAgent(request);
                #elif CORECLR
                return client.InvokeAgentAsync(request).GetAwaiter().GetResult();
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
            public System.String AgentAliasId { get; set; }
            public System.String AgentId { get; set; }
            public Amazon.BedrockAgentRuntime.PerformanceConfigLatency PerformanceConfig_Latency { get; set; }
            public System.Boolean? EnableTrace { get; set; }
            public System.Boolean? EndSession { get; set; }
            public System.String InputText { get; set; }
            public System.String MemoryId { get; set; }
            public System.String SessionId { get; set; }
            public List<Amazon.BedrockAgentRuntime.Model.Message> ConversationHistory_Message { get; set; }
            public List<Amazon.BedrockAgentRuntime.Model.InputFile> SessionState_File { get; set; }
            public System.String SessionState_InvocationId { get; set; }
            public List<Amazon.BedrockAgentRuntime.Model.KnowledgeBaseConfiguration> SessionState_KnowledgeBaseConfiguration { get; set; }
            public Dictionary<System.String, System.String> SessionState_PromptSessionAttribute { get; set; }
            public List<Amazon.BedrockAgentRuntime.Model.InvocationResultMember> SessionState_ReturnControlInvocationResult { get; set; }
            public Dictionary<System.String, System.String> SessionState_SessionAttribute { get; set; }
            public System.String SourceArn { get; set; }
            public System.Int32? StreamingConfigurations_ApplyGuardrailInterval { get; set; }
            public System.Boolean? StreamingConfigurations_StreamFinalResponse { get; set; }
            public System.Func<Amazon.BedrockAgentRuntime.Model.InvokeAgentResponse, InvokeBARAgentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
