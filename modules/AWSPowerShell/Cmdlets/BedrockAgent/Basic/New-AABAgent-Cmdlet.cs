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
using Amazon.BedrockAgent;
using Amazon.BedrockAgent.Model;

namespace Amazon.PowerShell.Cmdlets.AAB
{
    /// <summary>
    /// Creates an agent that orchestrates interactions between foundation models, data sources,
    /// software applications, user conversations, and APIs to carry out tasks to help customers.
    /// 
    ///  <ul><li><para>
    /// Specify the following fields for security purposes.
    /// </para><ul><li><para><c>agentResourceRoleArn</c> – The Amazon Resource Name (ARN) of the role with permissions
    /// to invoke API operations on an agent.
    /// </para></li><li><para>
    /// (Optional) <c>customerEncryptionKeyArn</c> – The Amazon Resource Name (ARN) of a KMS
    /// key to encrypt the creation of the agent.
    /// </para></li><li><para>
    /// (Optional) <c>idleSessionTTLinSeconds</c> – Specify the number of seconds for which
    /// the agent should maintain session information. After this time expires, the subsequent
    /// <c>InvokeAgent</c> request begins a new session.
    /// </para></li></ul></li><li><para>
    /// To enable your agent to retain conversational context across multiple sessions, include
    /// a <c>memoryConfiguration</c> object. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/agents-configure-memory.html">Configure
    /// memory</a>.
    /// </para></li><li><para>
    /// To override the default prompt behavior for agent orchestration and to use advanced
    /// prompts, include a <c>promptOverrideConfiguration</c> object. For more information,
    /// see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/advanced-prompts.html">Advanced
    /// prompts</a>.
    /// </para></li><li><para>
    /// If your agent fails to be created, the response returns a list of <c>failureReasons</c>
    /// alongside a list of <c>recommendedActions</c> for you to troubleshoot.
    /// </para></li><li><para>
    /// The agent instructions will not be honored if your agent has only one knowledge base,
    /// uses default prompts, has no action group, and user input is disabled.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "AABAgent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgent.Model.Agent")]
    [AWSCmdlet("Calls the Agents for Amazon Bedrock CreateAgent API operation.", Operation = new[] {"CreateAgent"}, SelectReturnType = typeof(Amazon.BedrockAgent.Model.CreateAgentResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgent.Model.Agent or Amazon.BedrockAgent.Model.CreateAgentResponse",
        "This cmdlet returns an Amazon.BedrockAgent.Model.Agent object.",
        "The service call response (type Amazon.BedrockAgent.Model.CreateAgentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewAABAgentCmdlet : AmazonBedrockAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AgentName
        /// <summary>
        /// <para>
        /// <para>A name for the agent that you create.</para>
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
        public System.String AgentName { get; set; }
        #endregion
        
        #region Parameter AgentResourceRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role with permissions to invoke API operations
        /// on the agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AgentResourceRoleArn { get; set; }
        #endregion
        
        #region Parameter CustomerEncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key with which to encrypt the agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomerEncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter MemoryConfiguration_EnabledMemoryType
        /// <summary>
        /// <para>
        /// <para>The type of memory that is stored. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MemoryConfiguration_EnabledMemoryTypes")]
        public System.String[] MemoryConfiguration_EnabledMemoryType { get; set; }
        #endregion
        
        #region Parameter FoundationModel
        /// <summary>
        /// <para>
        /// <para>The identifier for the model that you want to be used for orchestration by the agent
        /// you create.</para><para>The <c>modelId</c> to provide depends on the type of model or throughput that you
        /// use:</para><ul><li><para>If you use a base model, specify the model ID or its ARN. For a list of model IDs
        /// for base models, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-ids.html#model-ids-arns">Amazon
        /// Bedrock base model IDs (on-demand throughput)</a> in the Amazon Bedrock User Guide.</para></li><li><para>If you use an inference profile, specify the inference profile ID or its ARN. For
        /// a list of inference profile IDs, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/cross-region-inference-support.html">Supported
        /// Regions and models for cross-region inference</a> in the Amazon Bedrock User Guide.</para></li><li><para>If you use a provisioned model, specify the ARN of the Provisioned Throughput. For
        /// more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/prov-thru-use.html">Run
        /// inference using a Provisioned Throughput</a> in the Amazon Bedrock User Guide.</para></li><li><para>If you use a custom model, first purchase Provisioned Throughput for it. Then specify
        /// the ARN of the resulting provisioned model. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-customization-use.html">Use
        /// a custom model in Amazon Bedrock</a> in the Amazon Bedrock User Guide.</para></li><li><para>If you use an <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/model-customization-import-model.html">imported
        /// model</a>, specify the ARN of the imported model. You can get the model ARN from a
        /// successful call to <a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_CreateModelImportJob.html">CreateModelImportJob</a>
        /// or from the Imported models page in the Amazon Bedrock console.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FoundationModel { get; set; }
        #endregion
        
        #region Parameter GuardrailConfiguration_GuardrailIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the guardrail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GuardrailConfiguration_GuardrailIdentifier { get; set; }
        #endregion
        
        #region Parameter GuardrailConfiguration_GuardrailVersion
        /// <summary>
        /// <para>
        /// <para>The version of the guardrail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GuardrailConfiguration_GuardrailVersion { get; set; }
        #endregion
        
        #region Parameter IdleSessionTTLInSecond
        /// <summary>
        /// <para>
        /// <para>The number of seconds for which Amazon Bedrock keeps information about a user's conversation
        /// with the agent.</para><para>A user interaction remains active for the amount of time specified. If no conversation
        /// occurs during this time, the session expires and Amazon Bedrock deletes any data provided
        /// before the timeout.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdleSessionTTLInSeconds")]
        public System.Int32? IdleSessionTTLInSecond { get; set; }
        #endregion
        
        #region Parameter Instruction
        /// <summary>
        /// <para>
        /// <para>Instructions that tell the agent what it should do and how it should interact with
        /// users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Instruction { get; set; }
        #endregion
        
        #region Parameter Executor_Lambda
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the Lambda function containing the business logic
        /// that is carried out upon invoking the action. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomOrchestration_Executor_Lambda")]
        public System.String Executor_Lambda { get; set; }
        #endregion
        
        #region Parameter OrchestrationType
        /// <summary>
        /// <para>
        /// <para> Specifies the type of orchestration strategy for the agent. This is set to <c>DEFAULT</c>
        /// orchestration type, by default. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgent.OrchestrationType")]
        public Amazon.BedrockAgent.OrchestrationType OrchestrationType { get; set; }
        #endregion
        
        #region Parameter PromptOverrideConfiguration_OverrideLambda
        /// <summary>
        /// <para>
        /// <para>The ARN of the Lambda function to use when parsing the raw foundation model output
        /// in parts of the agent sequence. If you specify this field, at least one of the <c>promptConfigurations</c>
        /// must contain a <c>parserMode</c> value that is set to <c>OVERRIDDEN</c>. For more
        /// information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/lambda-parser.html">Parser
        /// Lambda function in Amazon Bedrock Agents</a>.</para>
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
        /// prompts</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PromptOverrideConfiguration_PromptConfigurations")]
        public Amazon.BedrockAgent.Model.PromptConfiguration[] PromptOverrideConfiguration_PromptConfiguration { get; set; }
        #endregion
        
        #region Parameter MemoryConfiguration_StorageDay
        /// <summary>
        /// <para>
        /// <para>The number of days the agent is configured to retain the conversational context.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MemoryConfiguration_StorageDays")]
        public System.Int32? MemoryConfiguration_StorageDay { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Any tags that you want to attach to the agent.</para>
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
        /// than one time. If this token matches a previous request, Amazon Bedrock ignores the
        /// request, but does not return an error. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Agent'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgent.Model.CreateAgentResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgent.Model.CreateAgentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Agent";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AgentName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AgentName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AgentName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AgentName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AABAgent (CreateAgent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgent.Model.CreateAgentResponse, NewAABAgentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AgentName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AgentName = this.AgentName;
            #if MODULAR
            if (this.AgentName == null && ParameterWasBound(nameof(this.AgentName)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AgentResourceRoleArn = this.AgentResourceRoleArn;
            context.ClientToken = this.ClientToken;
            context.CustomerEncryptionKeyArn = this.CustomerEncryptionKeyArn;
            context.Executor_Lambda = this.Executor_Lambda;
            context.Description = this.Description;
            context.FoundationModel = this.FoundationModel;
            context.GuardrailConfiguration_GuardrailIdentifier = this.GuardrailConfiguration_GuardrailIdentifier;
            context.GuardrailConfiguration_GuardrailVersion = this.GuardrailConfiguration_GuardrailVersion;
            context.IdleSessionTTLInSecond = this.IdleSessionTTLInSecond;
            context.Instruction = this.Instruction;
            if (this.MemoryConfiguration_EnabledMemoryType != null)
            {
                context.MemoryConfiguration_EnabledMemoryType = new List<System.String>(this.MemoryConfiguration_EnabledMemoryType);
            }
            context.MemoryConfiguration_StorageDay = this.MemoryConfiguration_StorageDay;
            context.OrchestrationType = this.OrchestrationType;
            context.PromptOverrideConfiguration_OverrideLambda = this.PromptOverrideConfiguration_OverrideLambda;
            if (this.PromptOverrideConfiguration_PromptConfiguration != null)
            {
                context.PromptOverrideConfiguration_PromptConfiguration = new List<Amazon.BedrockAgent.Model.PromptConfiguration>(this.PromptOverrideConfiguration_PromptConfiguration);
            }
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
            var request = new Amazon.BedrockAgent.Model.CreateAgentRequest();
            
            if (cmdletContext.AgentName != null)
            {
                request.AgentName = cmdletContext.AgentName;
            }
            if (cmdletContext.AgentResourceRoleArn != null)
            {
                request.AgentResourceRoleArn = cmdletContext.AgentResourceRoleArn;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CustomerEncryptionKeyArn != null)
            {
                request.CustomerEncryptionKeyArn = cmdletContext.CustomerEncryptionKeyArn;
            }
            
             // populate CustomOrchestration
            var requestCustomOrchestrationIsNull = true;
            request.CustomOrchestration = new Amazon.BedrockAgent.Model.CustomOrchestration();
            Amazon.BedrockAgent.Model.OrchestrationExecutor requestCustomOrchestration_customOrchestration_Executor = null;
            
             // populate Executor
            var requestCustomOrchestration_customOrchestration_ExecutorIsNull = true;
            requestCustomOrchestration_customOrchestration_Executor = new Amazon.BedrockAgent.Model.OrchestrationExecutor();
            System.String requestCustomOrchestration_customOrchestration_Executor_executor_Lambda = null;
            if (cmdletContext.Executor_Lambda != null)
            {
                requestCustomOrchestration_customOrchestration_Executor_executor_Lambda = cmdletContext.Executor_Lambda;
            }
            if (requestCustomOrchestration_customOrchestration_Executor_executor_Lambda != null)
            {
                requestCustomOrchestration_customOrchestration_Executor.Lambda = requestCustomOrchestration_customOrchestration_Executor_executor_Lambda;
                requestCustomOrchestration_customOrchestration_ExecutorIsNull = false;
            }
             // determine if requestCustomOrchestration_customOrchestration_Executor should be set to null
            if (requestCustomOrchestration_customOrchestration_ExecutorIsNull)
            {
                requestCustomOrchestration_customOrchestration_Executor = null;
            }
            if (requestCustomOrchestration_customOrchestration_Executor != null)
            {
                request.CustomOrchestration.Executor = requestCustomOrchestration_customOrchestration_Executor;
                requestCustomOrchestrationIsNull = false;
            }
             // determine if request.CustomOrchestration should be set to null
            if (requestCustomOrchestrationIsNull)
            {
                request.CustomOrchestration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FoundationModel != null)
            {
                request.FoundationModel = cmdletContext.FoundationModel;
            }
            
             // populate GuardrailConfiguration
            var requestGuardrailConfigurationIsNull = true;
            request.GuardrailConfiguration = new Amazon.BedrockAgent.Model.GuardrailConfiguration();
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
            if (cmdletContext.Instruction != null)
            {
                request.Instruction = cmdletContext.Instruction;
            }
            
             // populate MemoryConfiguration
            var requestMemoryConfigurationIsNull = true;
            request.MemoryConfiguration = new Amazon.BedrockAgent.Model.MemoryConfiguration();
            List<System.String> requestMemoryConfiguration_memoryConfiguration_EnabledMemoryType = null;
            if (cmdletContext.MemoryConfiguration_EnabledMemoryType != null)
            {
                requestMemoryConfiguration_memoryConfiguration_EnabledMemoryType = cmdletContext.MemoryConfiguration_EnabledMemoryType;
            }
            if (requestMemoryConfiguration_memoryConfiguration_EnabledMemoryType != null)
            {
                request.MemoryConfiguration.EnabledMemoryTypes = requestMemoryConfiguration_memoryConfiguration_EnabledMemoryType;
                requestMemoryConfigurationIsNull = false;
            }
            System.Int32? requestMemoryConfiguration_memoryConfiguration_StorageDay = null;
            if (cmdletContext.MemoryConfiguration_StorageDay != null)
            {
                requestMemoryConfiguration_memoryConfiguration_StorageDay = cmdletContext.MemoryConfiguration_StorageDay.Value;
            }
            if (requestMemoryConfiguration_memoryConfiguration_StorageDay != null)
            {
                request.MemoryConfiguration.StorageDays = requestMemoryConfiguration_memoryConfiguration_StorageDay.Value;
                requestMemoryConfigurationIsNull = false;
            }
             // determine if request.MemoryConfiguration should be set to null
            if (requestMemoryConfigurationIsNull)
            {
                request.MemoryConfiguration = null;
            }
            if (cmdletContext.OrchestrationType != null)
            {
                request.OrchestrationType = cmdletContext.OrchestrationType;
            }
            
             // populate PromptOverrideConfiguration
            var requestPromptOverrideConfigurationIsNull = true;
            request.PromptOverrideConfiguration = new Amazon.BedrockAgent.Model.PromptOverrideConfiguration();
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
            List<Amazon.BedrockAgent.Model.PromptConfiguration> requestPromptOverrideConfiguration_promptOverrideConfiguration_PromptConfiguration = null;
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
        
        private Amazon.BedrockAgent.Model.CreateAgentResponse CallAWSServiceOperation(IAmazonBedrockAgent client, Amazon.BedrockAgent.Model.CreateAgentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Agents for Amazon Bedrock", "CreateAgent");
            try
            {
                #if DESKTOP
                return client.CreateAgent(request);
                #elif CORECLR
                return client.CreateAgentAsync(request).GetAwaiter().GetResult();
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
            public System.String AgentName { get; set; }
            public System.String AgentResourceRoleArn { get; set; }
            public System.String ClientToken { get; set; }
            public System.String CustomerEncryptionKeyArn { get; set; }
            public System.String Executor_Lambda { get; set; }
            public System.String Description { get; set; }
            public System.String FoundationModel { get; set; }
            public System.String GuardrailConfiguration_GuardrailIdentifier { get; set; }
            public System.String GuardrailConfiguration_GuardrailVersion { get; set; }
            public System.Int32? IdleSessionTTLInSecond { get; set; }
            public System.String Instruction { get; set; }
            public List<System.String> MemoryConfiguration_EnabledMemoryType { get; set; }
            public System.Int32? MemoryConfiguration_StorageDay { get; set; }
            public Amazon.BedrockAgent.OrchestrationType OrchestrationType { get; set; }
            public System.String PromptOverrideConfiguration_OverrideLambda { get; set; }
            public List<Amazon.BedrockAgent.Model.PromptConfiguration> PromptOverrideConfiguration_PromptConfiguration { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.BedrockAgent.Model.CreateAgentResponse, NewAABAgentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Agent;
        }
        
    }
}
