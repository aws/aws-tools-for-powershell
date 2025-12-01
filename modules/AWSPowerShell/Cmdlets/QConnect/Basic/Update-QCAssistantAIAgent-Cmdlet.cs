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
using Amazon.QConnect;
using Amazon.QConnect.Model;

namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// Updates the AI Agent that is set for use by default on an Amazon Q in Connect Assistant.
    /// </summary>
    [Cmdlet("Update", "QCAssistantAIAgent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.AssistantData")]
    [AWSCmdlet("Calls the Amazon Q Connect UpdateAssistantAIAgent API operation.", Operation = new[] {"UpdateAssistantAIAgent"}, SelectReturnType = typeof(Amazon.QConnect.Model.UpdateAssistantAIAgentResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.AssistantData or Amazon.QConnect.Model.UpdateAssistantAIAgentResponse",
        "This cmdlet returns an Amazon.QConnect.Model.AssistantData object.",
        "The service call response (type Amazon.QConnect.Model.UpdateAssistantAIAgentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateQCAssistantAIAgentCmdlet : AmazonQConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Configuration_AiAgentId
        /// <summary>
        /// <para>
        /// <para>The ID of the AI Agent to be configured.</para>
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
        public System.String Configuration_AiAgentId { get; set; }
        #endregion
        
        #region Parameter AiAgentType
        /// <summary>
        /// <para>
        /// <para>The type of the AI Agent being updated for use by default on the Amazon Q in Connect
        /// Assistant.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QConnect.AIAgentType")]
        public Amazon.QConnect.AIAgentType AiAgentType { get; set; }
        #endregion
        
        #region Parameter AssistantId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Q in Connect assistant. Can be either the ID or the ARN.
        /// URLs cannot contain the ARN.</para>
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
        public System.String AssistantId { get; set; }
        #endregion
        
        #region Parameter OrchestratorConfigurationList
        /// <summary>
        /// <para>
        /// <para>The updated list of orchestrator configurations for the assistant AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QConnect.Model.OrchestratorConfigurationEntry[] OrchestratorConfigurationList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Assistant'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.UpdateAssistantAIAgentResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.UpdateAssistantAIAgentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Assistant";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AssistantId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AssistantId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AssistantId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssistantId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QCAssistantAIAgent (UpdateAssistantAIAgent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.UpdateAssistantAIAgentResponse, UpdateQCAssistantAIAgentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AssistantId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AiAgentType = this.AiAgentType;
            #if MODULAR
            if (this.AiAgentType == null && ParameterWasBound(nameof(this.AiAgentType)))
            {
                WriteWarning("You are passing $null as a value for parameter AiAgentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AssistantId = this.AssistantId;
            #if MODULAR
            if (this.AssistantId == null && ParameterWasBound(nameof(this.AssistantId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssistantId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Configuration_AiAgentId = this.Configuration_AiAgentId;
            #if MODULAR
            if (this.Configuration_AiAgentId == null && ParameterWasBound(nameof(this.Configuration_AiAgentId)))
            {
                WriteWarning("You are passing $null as a value for parameter Configuration_AiAgentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.OrchestratorConfigurationList != null)
            {
                context.OrchestratorConfigurationList = new List<Amazon.QConnect.Model.OrchestratorConfigurationEntry>(this.OrchestratorConfigurationList);
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
            var request = new Amazon.QConnect.Model.UpdateAssistantAIAgentRequest();
            
            if (cmdletContext.AiAgentType != null)
            {
                request.AiAgentType = cmdletContext.AiAgentType;
            }
            if (cmdletContext.AssistantId != null)
            {
                request.AssistantId = cmdletContext.AssistantId;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.QConnect.Model.AIAgentConfigurationData();
            System.String requestConfiguration_configuration_AiAgentId = null;
            if (cmdletContext.Configuration_AiAgentId != null)
            {
                requestConfiguration_configuration_AiAgentId = cmdletContext.Configuration_AiAgentId;
            }
            if (requestConfiguration_configuration_AiAgentId != null)
            {
                request.Configuration.AiAgentId = requestConfiguration_configuration_AiAgentId;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.OrchestratorConfigurationList != null)
            {
                request.OrchestratorConfigurationList = cmdletContext.OrchestratorConfigurationList;
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
        
        private Amazon.QConnect.Model.UpdateAssistantAIAgentResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.UpdateAssistantAIAgentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "UpdateAssistantAIAgent");
            try
            {
                #if DESKTOP
                return client.UpdateAssistantAIAgent(request);
                #elif CORECLR
                return client.UpdateAssistantAIAgentAsync(request).GetAwaiter().GetResult();
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
            public Amazon.QConnect.AIAgentType AiAgentType { get; set; }
            public System.String AssistantId { get; set; }
            public System.String Configuration_AiAgentId { get; set; }
            public List<Amazon.QConnect.Model.OrchestratorConfigurationEntry> OrchestratorConfigurationList { get; set; }
            public System.Func<Amazon.QConnect.Model.UpdateAssistantAIAgentResponse, UpdateQCAssistantAIAgentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Assistant;
        }
        
    }
}
