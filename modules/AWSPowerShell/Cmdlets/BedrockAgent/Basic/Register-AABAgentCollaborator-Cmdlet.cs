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
using Amazon.BedrockAgent;
using Amazon.BedrockAgent.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AAB
{
    /// <summary>
    /// Makes an agent a collaborator for another agent.
    /// </summary>
    [Cmdlet("Register", "AABAgentCollaborator", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgent.Model.AgentCollaborator")]
    [AWSCmdlet("Calls the Agents for Amazon Bedrock AssociateAgentCollaborator API operation.", Operation = new[] {"AssociateAgentCollaborator"}, SelectReturnType = typeof(Amazon.BedrockAgent.Model.AssociateAgentCollaboratorResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgent.Model.AgentCollaborator or Amazon.BedrockAgent.Model.AssociateAgentCollaboratorResponse",
        "This cmdlet returns an Amazon.BedrockAgent.Model.AgentCollaborator object.",
        "The service call response (type Amazon.BedrockAgent.Model.AssociateAgentCollaboratorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RegisterAABAgentCollaboratorCmdlet : AmazonBedrockAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgentId
        /// <summary>
        /// <para>
        /// <para>The agent's ID.</para>
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
        
        #region Parameter AgentVersion
        /// <summary>
        /// <para>
        /// <para>An agent version.</para>
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
        public System.String AgentVersion { get; set; }
        #endregion
        
        #region Parameter AgentDescriptor_AliasArn
        /// <summary>
        /// <para>
        /// <para>The agent's alias ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AgentDescriptor_AliasArn { get; set; }
        #endregion
        
        #region Parameter CollaborationInstruction
        /// <summary>
        /// <para>
        /// <para>Instruction for the collaborator.</para>
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
        public System.String CollaborationInstruction { get; set; }
        #endregion
        
        #region Parameter CollaboratorName
        /// <summary>
        /// <para>
        /// <para>A name for the collaborator.</para>
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
        public System.String CollaboratorName { get; set; }
        #endregion
        
        #region Parameter RelayConversationHistory
        /// <summary>
        /// <para>
        /// <para>A relay conversation history for the collaborator.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgent.RelayConversationHistory")]
        public Amazon.BedrockAgent.RelayConversationHistory RelayConversationHistory { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A client token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AgentCollaborator'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgent.Model.AssociateAgentCollaboratorResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgent.Model.AssociateAgentCollaboratorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AgentCollaborator";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AgentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-AABAgentCollaborator (AssociateAgentCollaborator)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgent.Model.AssociateAgentCollaboratorResponse, RegisterAABAgentCollaboratorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentDescriptor_AliasArn = this.AgentDescriptor_AliasArn;
            context.AgentId = this.AgentId;
            #if MODULAR
            if (this.AgentId == null && ParameterWasBound(nameof(this.AgentId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AgentVersion = this.AgentVersion;
            #if MODULAR
            if (this.AgentVersion == null && ParameterWasBound(nameof(this.AgentVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.CollaborationInstruction = this.CollaborationInstruction;
            #if MODULAR
            if (this.CollaborationInstruction == null && ParameterWasBound(nameof(this.CollaborationInstruction)))
            {
                WriteWarning("You are passing $null as a value for parameter CollaborationInstruction which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CollaboratorName = this.CollaboratorName;
            #if MODULAR
            if (this.CollaboratorName == null && ParameterWasBound(nameof(this.CollaboratorName)))
            {
                WriteWarning("You are passing $null as a value for parameter CollaboratorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RelayConversationHistory = this.RelayConversationHistory;
            
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
            var request = new Amazon.BedrockAgent.Model.AssociateAgentCollaboratorRequest();
            
            
             // populate AgentDescriptor
            var requestAgentDescriptorIsNull = true;
            request.AgentDescriptor = new Amazon.BedrockAgent.Model.AgentDescriptor();
            System.String requestAgentDescriptor_agentDescriptor_AliasArn = null;
            if (cmdletContext.AgentDescriptor_AliasArn != null)
            {
                requestAgentDescriptor_agentDescriptor_AliasArn = cmdletContext.AgentDescriptor_AliasArn;
            }
            if (requestAgentDescriptor_agentDescriptor_AliasArn != null)
            {
                request.AgentDescriptor.AliasArn = requestAgentDescriptor_agentDescriptor_AliasArn;
                requestAgentDescriptorIsNull = false;
            }
             // determine if request.AgentDescriptor should be set to null
            if (requestAgentDescriptorIsNull)
            {
                request.AgentDescriptor = null;
            }
            if (cmdletContext.AgentId != null)
            {
                request.AgentId = cmdletContext.AgentId;
            }
            if (cmdletContext.AgentVersion != null)
            {
                request.AgentVersion = cmdletContext.AgentVersion;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CollaborationInstruction != null)
            {
                request.CollaborationInstruction = cmdletContext.CollaborationInstruction;
            }
            if (cmdletContext.CollaboratorName != null)
            {
                request.CollaboratorName = cmdletContext.CollaboratorName;
            }
            if (cmdletContext.RelayConversationHistory != null)
            {
                request.RelayConversationHistory = cmdletContext.RelayConversationHistory;
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
        
        private Amazon.BedrockAgent.Model.AssociateAgentCollaboratorResponse CallAWSServiceOperation(IAmazonBedrockAgent client, Amazon.BedrockAgent.Model.AssociateAgentCollaboratorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Agents for Amazon Bedrock", "AssociateAgentCollaborator");
            try
            {
                return client.AssociateAgentCollaboratorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AgentDescriptor_AliasArn { get; set; }
            public System.String AgentId { get; set; }
            public System.String AgentVersion { get; set; }
            public System.String ClientToken { get; set; }
            public System.String CollaborationInstruction { get; set; }
            public System.String CollaboratorName { get; set; }
            public Amazon.BedrockAgent.RelayConversationHistory RelayConversationHistory { get; set; }
            public System.Func<Amazon.BedrockAgent.Model.AssociateAgentCollaboratorResponse, RegisterAABAgentCollaboratorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AgentCollaborator;
        }
        
    }
}
