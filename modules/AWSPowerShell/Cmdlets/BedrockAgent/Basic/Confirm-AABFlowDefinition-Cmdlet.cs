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
using Amazon.BedrockAgent;
using Amazon.BedrockAgent.Model;

namespace Amazon.PowerShell.Cmdlets.AAB
{
    /// <summary>
    /// Validates the definition of a flow.
    /// </summary>
    [Cmdlet("Confirm", "AABFlowDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgent.Model.FlowValidation")]
    [AWSCmdlet("Calls the Agents for Amazon Bedrock ValidateFlowDefinition API operation.", Operation = new[] {"ValidateFlowDefinition"}, SelectReturnType = typeof(Amazon.BedrockAgent.Model.ValidateFlowDefinitionResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgent.Model.FlowValidation or Amazon.BedrockAgent.Model.ValidateFlowDefinitionResponse",
        "This cmdlet returns a collection of Amazon.BedrockAgent.Model.FlowValidation objects.",
        "The service call response (type Amazon.BedrockAgent.Model.ValidateFlowDefinitionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ConfirmAABFlowDefinitionCmdlet : AmazonBedrockAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Definition_Connection
        /// <summary>
        /// <para>
        /// <para>An array of connection definitions in the flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_Connections")]
        public Amazon.BedrockAgent.Model.FlowConnection[] Definition_Connection { get; set; }
        #endregion
        
        #region Parameter Definition_Node
        /// <summary>
        /// <para>
        /// <para>An array of node definitions in the flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Definition_Nodes")]
        public Amazon.BedrockAgent.Model.FlowNode[] Definition_Node { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Validations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgent.Model.ValidateFlowDefinitionResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgent.Model.ValidateFlowDefinitionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Validations";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Confirm-AABFlowDefinition (ValidateFlowDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgent.Model.ValidateFlowDefinitionResponse, ConfirmAABFlowDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Definition_Connection != null)
            {
                context.Definition_Connection = new List<Amazon.BedrockAgent.Model.FlowConnection>(this.Definition_Connection);
            }
            if (this.Definition_Node != null)
            {
                context.Definition_Node = new List<Amazon.BedrockAgent.Model.FlowNode>(this.Definition_Node);
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
            var request = new Amazon.BedrockAgent.Model.ValidateFlowDefinitionRequest();
            
            
             // populate Definition
            request.Definition = new Amazon.BedrockAgent.Model.FlowDefinition();
            List<Amazon.BedrockAgent.Model.FlowConnection> requestDefinition_definition_Connection = null;
            if (cmdletContext.Definition_Connection != null)
            {
                requestDefinition_definition_Connection = cmdletContext.Definition_Connection;
            }
            if (requestDefinition_definition_Connection != null)
            {
                request.Definition.Connections = requestDefinition_definition_Connection;
            }
            List<Amazon.BedrockAgent.Model.FlowNode> requestDefinition_definition_Node = null;
            if (cmdletContext.Definition_Node != null)
            {
                requestDefinition_definition_Node = cmdletContext.Definition_Node;
            }
            if (requestDefinition_definition_Node != null)
            {
                request.Definition.Nodes = requestDefinition_definition_Node;
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
        
        private Amazon.BedrockAgent.Model.ValidateFlowDefinitionResponse CallAWSServiceOperation(IAmazonBedrockAgent client, Amazon.BedrockAgent.Model.ValidateFlowDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Agents for Amazon Bedrock", "ValidateFlowDefinition");
            try
            {
                #if DESKTOP
                return client.ValidateFlowDefinition(request);
                #elif CORECLR
                return client.ValidateFlowDefinitionAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.BedrockAgent.Model.FlowConnection> Definition_Connection { get; set; }
            public List<Amazon.BedrockAgent.Model.FlowNode> Definition_Node { get; set; }
            public System.Func<Amazon.BedrockAgent.Model.ValidateFlowDefinitionResponse, ConfirmAABFlowDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Validations;
        }
        
    }
}
