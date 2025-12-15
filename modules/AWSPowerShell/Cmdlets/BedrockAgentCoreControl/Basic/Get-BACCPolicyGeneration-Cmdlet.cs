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
    /// Retrieves information about a policy generation request within the AgentCore Policy
    /// system. Policy generation converts natural language descriptions into Cedar policy
    /// statements using AI-powered translation, enabling non-technical users to create policies.
    /// </summary>
    [Cmdlet("Get", "BACCPolicyGeneration")]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.GetPolicyGenerationResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer GetPolicyGeneration API operation.", Operation = new[] {"GetPolicyGeneration"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.GetPolicyGenerationResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.GetPolicyGenerationResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.GetPolicyGenerationResponse object containing multiple properties."
    )]
    public partial class GetBACCPolicyGenerationCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PolicyEngineId
        /// <summary>
        /// <para>
        /// <para>The identifier of the policy engine associated with the policy generation request.
        /// This provides the context for the generation operation and schema validation.</para>
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
        public System.String PolicyEngineId { get; set; }
        #endregion
        
        #region Parameter PolicyGenerationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the policy generation request to be retrieved. This must
        /// be a valid generation ID from a previous <a href="https://docs.aws.amazon.com/bedrock-agentcore-control/latest/APIReference/API_StartPolicyGeneration.html">StartPolicyGeneration</a>
        /// call.</para>
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
        public System.String PolicyGenerationId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.GetPolicyGenerationResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.GetPolicyGenerationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.GetPolicyGenerationResponse, GetBACCPolicyGenerationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.PolicyEngineId = this.PolicyEngineId;
            #if MODULAR
            if (this.PolicyEngineId == null && ParameterWasBound(nameof(this.PolicyEngineId)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyEngineId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyGenerationId = this.PolicyGenerationId;
            #if MODULAR
            if (this.PolicyGenerationId == null && ParameterWasBound(nameof(this.PolicyGenerationId)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyGenerationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgentCoreControl.Model.GetPolicyGenerationRequest();
            
            if (cmdletContext.PolicyEngineId != null)
            {
                request.PolicyEngineId = cmdletContext.PolicyEngineId;
            }
            if (cmdletContext.PolicyGenerationId != null)
            {
                request.PolicyGenerationId = cmdletContext.PolicyGenerationId;
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
        
        private Amazon.BedrockAgentCoreControl.Model.GetPolicyGenerationResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.GetPolicyGenerationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "GetPolicyGeneration");
            try
            {
                return client.GetPolicyGenerationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String PolicyEngineId { get; set; }
            public System.String PolicyGenerationId { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.GetPolicyGenerationResponse, GetBACCPolicyGenerationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
