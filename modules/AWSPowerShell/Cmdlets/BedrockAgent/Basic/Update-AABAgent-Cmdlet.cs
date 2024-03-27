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
    /// Updates the configuration of an agent.
    /// </summary>
    [Cmdlet("Update", "AABAgent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgent.Model.Agent")]
    [AWSCmdlet("Calls the Agents for Amazon Bedrock UpdateAgent API operation.", Operation = new[] {"UpdateAgent"}, SelectReturnType = typeof(Amazon.BedrockAgent.Model.UpdateAgentResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgent.Model.Agent or Amazon.BedrockAgent.Model.UpdateAgentResponse",
        "This cmdlet returns an Amazon.BedrockAgent.Model.Agent object.",
        "The service call response (type Amazon.BedrockAgent.Model.UpdateAgentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAABAgentCmdlet : AmazonBedrockAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AgentId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the agent.</para>
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
        
        #region Parameter AgentName
        /// <summary>
        /// <para>
        /// <para>Specifies a new name for the agent.</para>
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
        public System.String AgentName { get; set; }
        #endregion
        
        #region Parameter AgentResourceRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role with permissions to update the agent. The ARN must begin with
        /// <c>AmazonBedrockExecutionRoleForAgents_</c>.</para>
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
        public System.String AgentResourceRoleArn { get; set; }
        #endregion
        
        #region Parameter CustomerEncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the KMS key with which to encrypt the agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomerEncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Specifies a new description of the agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FoundationModel
        /// <summary>
        /// <para>
        /// <para>Specifies a new foundation model to be used for orchestration by the agent.</para>
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
        /// <para>Specifies new instructions that tell the agent what it should do and how it should
        /// interact with users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Instruction { get; set; }
        #endregion
        
        #region Parameter PromptOverrideConfiguration_OverrideLambda
        /// <summary>
        /// <para>
        /// <para>The ARN of the Lambda function to use when parsing the raw foundation model output
        /// in parts of the agent sequence. If you specify this field, at least one of the <c>promptConfigurations</c>
        /// must contain a <c>parserMode</c> value that is set to <c>OVERRIDDEN</c>.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Agent'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgent.Model.UpdateAgentResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgent.Model.UpdateAgentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Agent";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AgentId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AgentId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AgentId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AgentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AABAgent (UpdateAgent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgent.Model.UpdateAgentResponse, UpdateAABAgentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AgentId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AgentId = this.AgentId;
            #if MODULAR
            if (this.AgentId == null && ParameterWasBound(nameof(this.AgentId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AgentName = this.AgentName;
            #if MODULAR
            if (this.AgentName == null && ParameterWasBound(nameof(this.AgentName)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AgentResourceRoleArn = this.AgentResourceRoleArn;
            #if MODULAR
            if (this.AgentResourceRoleArn == null && ParameterWasBound(nameof(this.AgentResourceRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentResourceRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomerEncryptionKeyArn = this.CustomerEncryptionKeyArn;
            context.Description = this.Description;
            context.FoundationModel = this.FoundationModel;
            #if MODULAR
            if (this.FoundationModel == null && ParameterWasBound(nameof(this.FoundationModel)))
            {
                WriteWarning("You are passing $null as a value for parameter FoundationModel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdleSessionTTLInSecond = this.IdleSessionTTLInSecond;
            context.Instruction = this.Instruction;
            context.PromptOverrideConfiguration_OverrideLambda = this.PromptOverrideConfiguration_OverrideLambda;
            if (this.PromptOverrideConfiguration_PromptConfiguration != null)
            {
                context.PromptOverrideConfiguration_PromptConfiguration = new List<Amazon.BedrockAgent.Model.PromptConfiguration>(this.PromptOverrideConfiguration_PromptConfiguration);
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
            var request = new Amazon.BedrockAgent.Model.UpdateAgentRequest();
            
            if (cmdletContext.AgentId != null)
            {
                request.AgentId = cmdletContext.AgentId;
            }
            if (cmdletContext.AgentName != null)
            {
                request.AgentName = cmdletContext.AgentName;
            }
            if (cmdletContext.AgentResourceRoleArn != null)
            {
                request.AgentResourceRoleArn = cmdletContext.AgentResourceRoleArn;
            }
            if (cmdletContext.CustomerEncryptionKeyArn != null)
            {
                request.CustomerEncryptionKeyArn = cmdletContext.CustomerEncryptionKeyArn;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FoundationModel != null)
            {
                request.FoundationModel = cmdletContext.FoundationModel;
            }
            if (cmdletContext.IdleSessionTTLInSecond != null)
            {
                request.IdleSessionTTLInSeconds = cmdletContext.IdleSessionTTLInSecond.Value;
            }
            if (cmdletContext.Instruction != null)
            {
                request.Instruction = cmdletContext.Instruction;
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
        
        private Amazon.BedrockAgent.Model.UpdateAgentResponse CallAWSServiceOperation(IAmazonBedrockAgent client, Amazon.BedrockAgent.Model.UpdateAgentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Agents for Amazon Bedrock", "UpdateAgent");
            try
            {
                #if DESKTOP
                return client.UpdateAgent(request);
                #elif CORECLR
                return client.UpdateAgentAsync(request).GetAwaiter().GetResult();
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
            public System.String AgentId { get; set; }
            public System.String AgentName { get; set; }
            public System.String AgentResourceRoleArn { get; set; }
            public System.String CustomerEncryptionKeyArn { get; set; }
            public System.String Description { get; set; }
            public System.String FoundationModel { get; set; }
            public System.Int32? IdleSessionTTLInSecond { get; set; }
            public System.String Instruction { get; set; }
            public System.String PromptOverrideConfiguration_OverrideLambda { get; set; }
            public List<Amazon.BedrockAgent.Model.PromptConfiguration> PromptOverrideConfiguration_PromptConfiguration { get; set; }
            public System.Func<Amazon.BedrockAgent.Model.UpdateAgentResponse, UpdateAABAgentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Agent;
        }
        
    }
}
