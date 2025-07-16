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
using Amazon.BedrockAgentCoreControl;
using Amazon.BedrockAgentCoreControl.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BACC
{
    /// <summary>
    /// Deletes an Amazon Secure AgentEndpoint.
    /// </summary>
    [Cmdlet("Remove", "BACCAgentRuntimeEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.BedrockAgentCoreControl.AgentEndpointStatus")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer DeleteAgentRuntimeEndpoint API operation.", Operation = new[] {"DeleteAgentRuntimeEndpoint"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.DeleteAgentRuntimeEndpointResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.AgentEndpointStatus or Amazon.BedrockAgentCoreControl.Model.DeleteAgentRuntimeEndpointResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.AgentEndpointStatus object.",
        "The service call response (type Amazon.BedrockAgentCoreControl.Model.DeleteAgentRuntimeEndpointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveBACCAgentRuntimeEndpointCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgentRuntimeId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the agent runtime associated with the endpoint.</para>
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
        public System.String AgentRuntimeId { get; set; }
        #endregion
        
        #region Parameter EndpointName
        /// <summary>
        /// <para>
        /// <para>The name of the agent runtime endpoint to delete.</para>
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
        public System.String EndpointName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Status'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.DeleteAgentRuntimeEndpointResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.DeleteAgentRuntimeEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Status";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EndpointName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-BACCAgentRuntimeEndpoint (DeleteAgentRuntimeEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.DeleteAgentRuntimeEndpointResponse, RemoveBACCAgentRuntimeEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentRuntimeId = this.AgentRuntimeId;
            #if MODULAR
            if (this.AgentRuntimeId == null && ParameterWasBound(nameof(this.AgentRuntimeId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentRuntimeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.EndpointName = this.EndpointName;
            #if MODULAR
            if (this.EndpointName == null && ParameterWasBound(nameof(this.EndpointName)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgentCoreControl.Model.DeleteAgentRuntimeEndpointRequest();
            
            if (cmdletContext.AgentRuntimeId != null)
            {
                request.AgentRuntimeId = cmdletContext.AgentRuntimeId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EndpointName != null)
            {
                request.EndpointName = cmdletContext.EndpointName;
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
        
        private Amazon.BedrockAgentCoreControl.Model.DeleteAgentRuntimeEndpointResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.DeleteAgentRuntimeEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "DeleteAgentRuntimeEndpoint");
            try
            {
                return client.DeleteAgentRuntimeEndpointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AgentRuntimeId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String EndpointName { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.DeleteAgentRuntimeEndpointResponse, RemoveBACCAgentRuntimeEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Status;
        }
        
    }
}
