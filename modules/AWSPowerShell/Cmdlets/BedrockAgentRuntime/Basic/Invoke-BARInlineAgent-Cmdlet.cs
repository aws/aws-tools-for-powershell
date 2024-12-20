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
    /// Invokes an inline Amazon Bedrock agent using the configurations you provide with
    /// the request. 
    /// 
    ///  <ul><li><para>
    /// Specify the following fields for security purposes.
    /// </para><ul><li><para>
    /// (Optional) <c>customerEncryptionKeyArn</c> – The Amazon Resource Name (ARN) of a KMS
    /// key to encrypt the creation of the agent.
    /// </para></li><li><para>
    /// (Optional) <c>idleSessionTTLinSeconds</c> – Specify the number of seconds for which
    /// the agent should maintain session information. After this time expires, the subsequent
    /// <c>InvokeInlineAgent</c> request begins a new session.
    /// </para></li></ul></li><li><para>
    /// To override the default prompt behavior for agent orchestration and to use advanced
    /// prompts, include a <c>promptOverrideConfiguration</c> object. For more information,
    /// see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/advanced-prompts.html">Advanced
    /// prompts</a>.
    /// </para></li><li><para>
    /// The agent instructions will not be honored if your agent has only one knowledge base,
    /// uses default prompts, has no action group, and user input is disabled.
    /// </para></li></ul><note><para>
    /// The CLI doesn't support streaming operations in Amazon Bedrock, including <c>InvokeInlineAgent</c>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Invoke", "BARInlineAgent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentRuntime.Model.InvokeInlineAgentResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Runtime InvokeInlineAgent API operation.", Operation = new[] {"InvokeInlineAgent"}, SelectReturnType = typeof(Amazon.BedrockAgentRuntime.Model.InvokeInlineAgentResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentRuntime.Model.InvokeInlineAgentResponse",
        "This cmdlet returns an Amazon.BedrockAgentRuntime.Model.InvokeInlineAgentResponse object containing multiple properties."
    )]
    public partial class InvokeBARInlineAgentCmdlet : AmazonBedrockAgentRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ActionGroup
        /// <summary>
        /// <para>
        /// <para> A list of action groups with each action group defining the action the inline agent
        /// needs to carry out. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActionGroups")]
        public Amazon.BedrockAgentRuntime.Model.AgentActionGroup[] ActionGroup { get; set; }
        #endregion
        
        #region Parameter CustomerEncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the Amazon Web Services KMS key to use to encrypt
        /// your inline agent. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomerEncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter EnableTrace
        /// <summary>
        /// <para>
        /// Amazon.BedrockAgentRuntime.Model.InvokeInlineAgentRequest.EnableTrace
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableTrace { get; set; }
        #endregion
        
        #region Parameter EndSession
        /// <summary>
        /// <para>
        /// <para> Specifies whether to end the session with the inline agent or not. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EndSession { get; set; }
        #endregion
        
        #region Parameter InlineSessionState_File
        /// <summary>
        /// <para>
        /// <para> Contains information about the files used by code interpreter. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InlineSessionState_Files")]
        public Amazon.BedrockAgentRuntime.Model.InputFile[] InlineSessionState_File { get; set; }
        #endregion
        
        #region Parameter FoundationModel
        /// <summary>
        /// <para>
        /// <para> The <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-ids.html#model-ids-arns">model
        /// identifier (ID)</a> of the model to use for orchestration by the inline agent. For
        /// example, <c>meta.llama3-1-70b-instruct-v1:0</c>. </para>
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
        public System.String FoundationModel { get; set; }
        #endregion
        
        #region Parameter GuardrailConfiguration_GuardrailIdentifier
        /// <summary>
        /// <para>
        /// <para> The unique identifier for the guardrail. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GuardrailConfiguration_GuardrailIdentifier { get; set; }
        #endregion
        
        #region Parameter GuardrailConfiguration_GuardrailVersion
        /// <summary>
        /// <para>
        /// <para> The version of the guardrail. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GuardrailConfiguration_GuardrailVersion { get; set; }
        #endregion
        
        #region Parameter IdleSessionTTLInSecond
        /// <summary>
        /// <para>
        /// <para> The number of seconds for which the inline agent should maintain session information.
        /// After this time expires, the subsequent <c>InvokeInlineAgent</c> request begins a
        /// new session. </para><para>A user interaction remains active for the amount of time specified. If no conversation
        /// occurs during this time, the session expires and the data provided before the timeout
        /// is deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdleSessionTTLInSeconds")]
        public System.Int32? IdleSessionTTLInSecond { get; set; }
        #endregion
        
        #region Parameter InputText
        /// <summary>
        /// <para>
        /// <para> The prompt text to send to the agent. </para><note><para>If you include <c>returnControlInvocationResults</c> in the <c>sessionState</c> field,
        /// the <c>inputText</c> field will be ignored.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputText { get; set; }
        #endregion
        
        #region Parameter Instruction
        /// <summary>
        /// <para>
        /// <para> The instructions that tell the inline agent what it should do and how it should interact
        /// with users. </para>
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
        public System.String Instruction { get; set; }
        #endregion
        
        #region Parameter InlineSessionState_InvocationId
        /// <summary>
        /// <para>
        /// <para> The identifier of the invocation of an action. This value must match the <c>invocationId</c>
        /// returned in the <c>InvokeInlineAgent</c> response for the action whose results are
        /// provided in the <c>returnControlInvocationResults</c> field. For more information,
        /// see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/agents-returncontrol.html">Return
        /// control to the agent developer</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InlineSessionState_InvocationId { get; set; }
        #endregion
        
        #region Parameter KnowledgeBases
        /// <summary>
        /// <para>
        /// <para> Contains information of the knowledge bases to associate with. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.BedrockAgentRuntime.Model.KnowledgeBase[] KnowledgeBases { get; set; }
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
        
        #region Parameter PromptOverrideConfiguration_OverrideLambda
        /// <summary>
        /// <para>
        /// <para>The ARN of the Lambda function to use when parsing the raw foundation model output
        /// in parts of the agent sequence. If you specify this field, at least one of the <c>promptConfigurations</c>
        /// must contain a <c>parserMode</c> value that is set to <c>OVERRIDDEN</c>. For more
        /// information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/lambda-parser.html">Parser
        /// Lambda function in Amazon Bedrock Agents</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PromptOverrideConfiguration_OverrideLambda { get; set; }
        #endregion
        
        #region Parameter PromptOverrideConfiguration_PromptConfiguration
        /// <summary>
        /// <para>
        /// <para>Contains configurations to override a prompt template in one part of an agent sequence.
        /// For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/advanced-prompts.html">Advanced
        /// prompts</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PromptOverrideConfiguration_PromptConfigurations")]
        public Amazon.BedrockAgentRuntime.Model.PromptConfiguration[] PromptOverrideConfiguration_PromptConfiguration { get; set; }
        #endregion
        
        #region Parameter InlineSessionState_PromptSessionAttribute
        /// <summary>
        /// <para>
        /// <para> Contains attributes that persist across a session and the values of those attributes.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InlineSessionState_PromptSessionAttributes")]
        public System.Collections.Hashtable InlineSessionState_PromptSessionAttribute { get; set; }
        #endregion
        
        #region Parameter InlineSessionState_ReturnControlInvocationResult
        /// <summary>
        /// <para>
        /// <para> Contains information about the results from the action group invocation. For more
        /// information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/agents-returncontrol.html">Return
        /// control to the agent developer</a>. </para><note><para>If you include this field in the <c>sessionState</c> field, the <c>inputText</c> field
        /// will be ignored.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InlineSessionState_ReturnControlInvocationResults")]
        public Amazon.BedrockAgentRuntime.Model.InvocationResultMember[] InlineSessionState_ReturnControlInvocationResult { get; set; }
        #endregion
        
        #region Parameter InlineSessionState_SessionAttribute
        /// <summary>
        /// <para>
        /// <para> Contains attributes that persist across a session and the values of those attributes.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InlineSessionState_SessionAttributes")]
        public System.Collections.Hashtable InlineSessionState_SessionAttribute { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para> The unique identifier of the session. Use the same value across requests to continue
        /// the same conversation. </para>
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
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentRuntime.Model.InvokeInlineAgentResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentRuntime.Model.InvokeInlineAgentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SessionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SessionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SessionId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SessionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BARInlineAgent (InvokeInlineAgent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentRuntime.Model.InvokeInlineAgentResponse, InvokeBARInlineAgentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SessionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ActionGroup != null)
            {
                context.ActionGroup = new List<Amazon.BedrockAgentRuntime.Model.AgentActionGroup>(this.ActionGroup);
            }
            context.PerformanceConfig_Latency = this.PerformanceConfig_Latency;
            context.CustomerEncryptionKeyArn = this.CustomerEncryptionKeyArn;
            context.EnableTrace = this.EnableTrace;
            context.EndSession = this.EndSession;
            context.FoundationModel = this.FoundationModel;
            #if MODULAR
            if (this.FoundationModel == null && ParameterWasBound(nameof(this.FoundationModel)))
            {
                WriteWarning("You are passing $null as a value for parameter FoundationModel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GuardrailConfiguration_GuardrailIdentifier = this.GuardrailConfiguration_GuardrailIdentifier;
            context.GuardrailConfiguration_GuardrailVersion = this.GuardrailConfiguration_GuardrailVersion;
            context.IdleSessionTTLInSecond = this.IdleSessionTTLInSecond;
            if (this.InlineSessionState_File != null)
            {
                context.InlineSessionState_File = new List<Amazon.BedrockAgentRuntime.Model.InputFile>(this.InlineSessionState_File);
            }
            context.InlineSessionState_InvocationId = this.InlineSessionState_InvocationId;
            if (this.InlineSessionState_PromptSessionAttribute != null)
            {
                context.InlineSessionState_PromptSessionAttribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.InlineSessionState_PromptSessionAttribute.Keys)
                {
                    context.InlineSessionState_PromptSessionAttribute.Add((String)hashKey, (System.String)(this.InlineSessionState_PromptSessionAttribute[hashKey]));
                }
            }
            if (this.InlineSessionState_ReturnControlInvocationResult != null)
            {
                context.InlineSessionState_ReturnControlInvocationResult = new List<Amazon.BedrockAgentRuntime.Model.InvocationResultMember>(this.InlineSessionState_ReturnControlInvocationResult);
            }
            if (this.InlineSessionState_SessionAttribute != null)
            {
                context.InlineSessionState_SessionAttribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.InlineSessionState_SessionAttribute.Keys)
                {
                    context.InlineSessionState_SessionAttribute.Add((String)hashKey, (System.String)(this.InlineSessionState_SessionAttribute[hashKey]));
                }
            }
            context.InputText = this.InputText;
            context.Instruction = this.Instruction;
            #if MODULAR
            if (this.Instruction == null && ParameterWasBound(nameof(this.Instruction)))
            {
                WriteWarning("You are passing $null as a value for parameter Instruction which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.KnowledgeBases != null)
            {
                context.KnowledgeBases = new List<Amazon.BedrockAgentRuntime.Model.KnowledgeBase>(this.KnowledgeBases);
            }
            context.PromptOverrideConfiguration_OverrideLambda = this.PromptOverrideConfiguration_OverrideLambda;
            if (this.PromptOverrideConfiguration_PromptConfiguration != null)
            {
                context.PromptOverrideConfiguration_PromptConfiguration = new List<Amazon.BedrockAgentRuntime.Model.PromptConfiguration>(this.PromptOverrideConfiguration_PromptConfiguration);
            }
            context.SessionId = this.SessionId;
            #if MODULAR
            if (this.SessionId == null && ParameterWasBound(nameof(this.SessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgentRuntime.Model.InvokeInlineAgentRequest();
            
            if (cmdletContext.ActionGroup != null)
            {
                request.ActionGroups = cmdletContext.ActionGroup;
            }
            
             // populate BedrockModelConfigurations
            var requestBedrockModelConfigurationsIsNull = true;
            request.BedrockModelConfigurations = new Amazon.BedrockAgentRuntime.Model.InlineBedrockModelConfigurations();
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
            if (cmdletContext.CustomerEncryptionKeyArn != null)
            {
                request.CustomerEncryptionKeyArn = cmdletContext.CustomerEncryptionKeyArn;
            }
            if (cmdletContext.EnableTrace != null)
            {
                request.EnableTrace = cmdletContext.EnableTrace.Value;
            }
            if (cmdletContext.EndSession != null)
            {
                request.EndSession = cmdletContext.EndSession.Value;
            }
            if (cmdletContext.FoundationModel != null)
            {
                request.FoundationModel = cmdletContext.FoundationModel;
            }
            
             // populate GuardrailConfiguration
            var requestGuardrailConfigurationIsNull = true;
            request.GuardrailConfiguration = new Amazon.BedrockAgentRuntime.Model.GuardrailConfigurationWithArn();
            System.String requestGuardrailConfiguration_guardrailConfiguration_GuardrailIdentifier = null;
            if (cmdletContext.GuardrailConfiguration_GuardrailIdentifier != null)
            {
                requestGuardrailConfiguration_guardrailConfiguration_GuardrailIdentifier = cmdletContext.GuardrailConfiguration_GuardrailIdentifier;
            }
            if (requestGuardrailConfiguration_guardrailConfiguration_GuardrailIdentifier != null)
            {
                request.GuardrailConfiguration.GuardrailIdentifier = requestGuardrailConfiguration_guardrailConfiguration_GuardrailIdentifier;
                requestGuardrailConfigurationIsNull = false;
            }
            System.String requestGuardrailConfiguration_guardrailConfiguration_GuardrailVersion = null;
            if (cmdletContext.GuardrailConfiguration_GuardrailVersion != null)
            {
                requestGuardrailConfiguration_guardrailConfiguration_GuardrailVersion = cmdletContext.GuardrailConfiguration_GuardrailVersion;
            }
            if (requestGuardrailConfiguration_guardrailConfiguration_GuardrailVersion != null)
            {
                request.GuardrailConfiguration.GuardrailVersion = requestGuardrailConfiguration_guardrailConfiguration_GuardrailVersion;
                requestGuardrailConfigurationIsNull = false;
            }
             // determine if request.GuardrailConfiguration should be set to null
            if (requestGuardrailConfigurationIsNull)
            {
                request.GuardrailConfiguration = null;
            }
            if (cmdletContext.IdleSessionTTLInSecond != null)
            {
                request.IdleSessionTTLInSeconds = cmdletContext.IdleSessionTTLInSecond.Value;
            }
            
             // populate InlineSessionState
            var requestInlineSessionStateIsNull = true;
            request.InlineSessionState = new Amazon.BedrockAgentRuntime.Model.InlineSessionState();
            List<Amazon.BedrockAgentRuntime.Model.InputFile> requestInlineSessionState_inlineSessionState_File = null;
            if (cmdletContext.InlineSessionState_File != null)
            {
                requestInlineSessionState_inlineSessionState_File = cmdletContext.InlineSessionState_File;
            }
            if (requestInlineSessionState_inlineSessionState_File != null)
            {
                request.InlineSessionState.Files = requestInlineSessionState_inlineSessionState_File;
                requestInlineSessionStateIsNull = false;
            }
            System.String requestInlineSessionState_inlineSessionState_InvocationId = null;
            if (cmdletContext.InlineSessionState_InvocationId != null)
            {
                requestInlineSessionState_inlineSessionState_InvocationId = cmdletContext.InlineSessionState_InvocationId;
            }
            if (requestInlineSessionState_inlineSessionState_InvocationId != null)
            {
                request.InlineSessionState.InvocationId = requestInlineSessionState_inlineSessionState_InvocationId;
                requestInlineSessionStateIsNull = false;
            }
            Dictionary<System.String, System.String> requestInlineSessionState_inlineSessionState_PromptSessionAttribute = null;
            if (cmdletContext.InlineSessionState_PromptSessionAttribute != null)
            {
                requestInlineSessionState_inlineSessionState_PromptSessionAttribute = cmdletContext.InlineSessionState_PromptSessionAttribute;
            }
            if (requestInlineSessionState_inlineSessionState_PromptSessionAttribute != null)
            {
                request.InlineSessionState.PromptSessionAttributes = requestInlineSessionState_inlineSessionState_PromptSessionAttribute;
                requestInlineSessionStateIsNull = false;
            }
            List<Amazon.BedrockAgentRuntime.Model.InvocationResultMember> requestInlineSessionState_inlineSessionState_ReturnControlInvocationResult = null;
            if (cmdletContext.InlineSessionState_ReturnControlInvocationResult != null)
            {
                requestInlineSessionState_inlineSessionState_ReturnControlInvocationResult = cmdletContext.InlineSessionState_ReturnControlInvocationResult;
            }
            if (requestInlineSessionState_inlineSessionState_ReturnControlInvocationResult != null)
            {
                request.InlineSessionState.ReturnControlInvocationResults = requestInlineSessionState_inlineSessionState_ReturnControlInvocationResult;
                requestInlineSessionStateIsNull = false;
            }
            Dictionary<System.String, System.String> requestInlineSessionState_inlineSessionState_SessionAttribute = null;
            if (cmdletContext.InlineSessionState_SessionAttribute != null)
            {
                requestInlineSessionState_inlineSessionState_SessionAttribute = cmdletContext.InlineSessionState_SessionAttribute;
            }
            if (requestInlineSessionState_inlineSessionState_SessionAttribute != null)
            {
                request.InlineSessionState.SessionAttributes = requestInlineSessionState_inlineSessionState_SessionAttribute;
                requestInlineSessionStateIsNull = false;
            }
             // determine if request.InlineSessionState should be set to null
            if (requestInlineSessionStateIsNull)
            {
                request.InlineSessionState = null;
            }
            if (cmdletContext.InputText != null)
            {
                request.InputText = cmdletContext.InputText;
            }
            if (cmdletContext.Instruction != null)
            {
                request.Instruction = cmdletContext.Instruction;
            }
            if (cmdletContext.KnowledgeBases != null)
            {
                request.KnowledgeBases = cmdletContext.KnowledgeBases;
            }
            
             // populate PromptOverrideConfiguration
            var requestPromptOverrideConfigurationIsNull = true;
            request.PromptOverrideConfiguration = new Amazon.BedrockAgentRuntime.Model.PromptOverrideConfiguration();
            System.String requestPromptOverrideConfiguration_promptOverrideConfiguration_OverrideLambda = null;
            if (cmdletContext.PromptOverrideConfiguration_OverrideLambda != null)
            {
                requestPromptOverrideConfiguration_promptOverrideConfiguration_OverrideLambda = cmdletContext.PromptOverrideConfiguration_OverrideLambda;
            }
            if (requestPromptOverrideConfiguration_promptOverrideConfiguration_OverrideLambda != null)
            {
                request.PromptOverrideConfiguration.OverrideLambda = requestPromptOverrideConfiguration_promptOverrideConfiguration_OverrideLambda;
                requestPromptOverrideConfigurationIsNull = false;
            }
            List<Amazon.BedrockAgentRuntime.Model.PromptConfiguration> requestPromptOverrideConfiguration_promptOverrideConfiguration_PromptConfiguration = null;
            if (cmdletContext.PromptOverrideConfiguration_PromptConfiguration != null)
            {
                requestPromptOverrideConfiguration_promptOverrideConfiguration_PromptConfiguration = cmdletContext.PromptOverrideConfiguration_PromptConfiguration;
            }
            if (requestPromptOverrideConfiguration_promptOverrideConfiguration_PromptConfiguration != null)
            {
                request.PromptOverrideConfiguration.PromptConfigurations = requestPromptOverrideConfiguration_promptOverrideConfiguration_PromptConfiguration;
                requestPromptOverrideConfigurationIsNull = false;
            }
             // determine if request.PromptOverrideConfiguration should be set to null
            if (requestPromptOverrideConfigurationIsNull)
            {
                request.PromptOverrideConfiguration = null;
            }
            if (cmdletContext.SessionId != null)
            {
                request.SessionId = cmdletContext.SessionId;
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
        
        private Amazon.BedrockAgentRuntime.Model.InvokeInlineAgentResponse CallAWSServiceOperation(IAmazonBedrockAgentRuntime client, Amazon.BedrockAgentRuntime.Model.InvokeInlineAgentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Runtime", "InvokeInlineAgent");
            try
            {
                #if DESKTOP
                return client.InvokeInlineAgent(request);
                #elif CORECLR
                return client.InvokeInlineAgentAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.BedrockAgentRuntime.Model.AgentActionGroup> ActionGroup { get; set; }
            public Amazon.BedrockAgentRuntime.PerformanceConfigLatency PerformanceConfig_Latency { get; set; }
            public System.String CustomerEncryptionKeyArn { get; set; }
            public System.Boolean? EnableTrace { get; set; }
            public System.Boolean? EndSession { get; set; }
            public System.String FoundationModel { get; set; }
            public System.String GuardrailConfiguration_GuardrailIdentifier { get; set; }
            public System.String GuardrailConfiguration_GuardrailVersion { get; set; }
            public System.Int32? IdleSessionTTLInSecond { get; set; }
            public List<Amazon.BedrockAgentRuntime.Model.InputFile> InlineSessionState_File { get; set; }
            public System.String InlineSessionState_InvocationId { get; set; }
            public Dictionary<System.String, System.String> InlineSessionState_PromptSessionAttribute { get; set; }
            public List<Amazon.BedrockAgentRuntime.Model.InvocationResultMember> InlineSessionState_ReturnControlInvocationResult { get; set; }
            public Dictionary<System.String, System.String> InlineSessionState_SessionAttribute { get; set; }
            public System.String InputText { get; set; }
            public System.String Instruction { get; set; }
            public List<Amazon.BedrockAgentRuntime.Model.KnowledgeBase> KnowledgeBases { get; set; }
            public System.String PromptOverrideConfiguration_OverrideLambda { get; set; }
            public List<Amazon.BedrockAgentRuntime.Model.PromptConfiguration> PromptOverrideConfiguration_PromptConfiguration { get; set; }
            public System.String SessionId { get; set; }
            public System.Func<Amazon.BedrockAgentRuntime.Model.InvokeInlineAgentResponse, InvokeBARInlineAgentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
