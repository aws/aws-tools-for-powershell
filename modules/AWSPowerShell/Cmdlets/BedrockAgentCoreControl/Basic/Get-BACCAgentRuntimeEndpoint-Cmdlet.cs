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
using Amazon.BedrockAgentCoreControl;
using Amazon.BedrockAgentCoreControl.Model;

namespace Amazon.PowerShell.Cmdlets.BACC
{
    /// <summary>
    /// Gets information about an Amazon Secure AgentEndpoint.
    /// </summary>
    [Cmdlet("Get", "BACCAgentRuntimeEndpoint")]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.GetAgentRuntimeEndpointResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer GetAgentRuntimeEndpoint API operation.", Operation = new[] {"GetAgentRuntimeEndpoint"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.GetAgentRuntimeEndpointResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.GetAgentRuntimeEndpointResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.GetAgentRuntimeEndpointResponse object containing multiple properties."
    )]
    public partial class GetBACCAgentRuntimeEndpointCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AgentRuntimeId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the AgentCore Runtime associated with the endpoint.</para>
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
        /// <para>The name of the AgentCore Runtime endpoint to retrieve.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.GetAgentRuntimeEndpointResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.GetAgentRuntimeEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.GetAgentRuntimeEndpointResponse, GetBACCAgentRuntimeEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentRuntimeId = this.AgentRuntimeId;
            #if MODULAR
            if (this.AgentRuntimeId == null && ParameterWasBound(nameof(this.AgentRuntimeId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentRuntimeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.BedrockAgentCoreControl.Model.GetAgentRuntimeEndpointRequest();
            
            if (cmdletContext.AgentRuntimeId != null)
            {
                request.AgentRuntimeId = cmdletContext.AgentRuntimeId;
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
        
        private Amazon.BedrockAgentCoreControl.Model.GetAgentRuntimeEndpointResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.GetAgentRuntimeEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "GetAgentRuntimeEndpoint");
            try
            {
                #if DESKTOP
                return client.GetAgentRuntimeEndpoint(request);
                #elif CORECLR
                return client.GetAgentRuntimeEndpointAsync(request).GetAwaiter().GetResult();
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
            public System.String AgentRuntimeId { get; set; }
            public System.String EndpointName { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.GetAgentRuntimeEndpointResponse, GetBACCAgentRuntimeEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
