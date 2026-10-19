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
    /// Gets a retrieval instruction. Also used to poll the terminal reporting of an asynchronous
    /// create or update.
    /// </summary>
    [Cmdlet("Get", "AABRetrievalInstruction")]
    [OutputType("Amazon.BedrockAgent.Model.GetRetrievalInstructionResponse")]
    [AWSCmdlet("Calls the Agents for Amazon Bedrock GetRetrievalInstruction API operation.", Operation = new[] {"GetRetrievalInstruction"}, SelectReturnType = typeof(Amazon.BedrockAgent.Model.GetRetrievalInstructionResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgent.Model.GetRetrievalInstructionResponse",
        "This cmdlet returns an Amazon.BedrockAgent.Model.GetRetrievalInstructionResponse object containing multiple properties."
    )]
    public partial class GetAABRetrievalInstructionCmdlet : AmazonBedrockAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RetrievalInstructionId
        /// <summary>
        /// <para>
        /// <para>The identifier of the retrieval instruction to get.</para>
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
        public System.String RetrievalInstructionId { get; set; }
        #endregion
        
        #region Parameter RetrievalInstructionVersion
        /// <summary>
        /// <para>
        /// <para>The version to return: a version number, or DRAFT for the retrieval instruction's
        /// current reviewed content. When omitted, DRAFT is used. This default is permanent:
        /// omitting retrievalInstructionVersion will never resolve to a numbered version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RetrievalInstructionVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgent.Model.GetRetrievalInstructionResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgent.Model.GetRetrievalInstructionResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.BedrockAgent.Model.GetRetrievalInstructionResponse, GetAABRetrievalInstructionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RetrievalInstructionId = this.RetrievalInstructionId;
            #if MODULAR
            if (this.RetrievalInstructionId == null && ParameterWasBound(nameof(this.RetrievalInstructionId)))
            {
                WriteWarning("You are passing $null as a value for parameter RetrievalInstructionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RetrievalInstructionVersion = this.RetrievalInstructionVersion;
            
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
            var request = new Amazon.BedrockAgent.Model.GetRetrievalInstructionRequest();
            
            if (cmdletContext.RetrievalInstructionId != null)
            {
                request.RetrievalInstructionId = cmdletContext.RetrievalInstructionId;
            }
            if (cmdletContext.RetrievalInstructionVersion != null)
            {
                request.RetrievalInstructionVersion = cmdletContext.RetrievalInstructionVersion;
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
        
        private Amazon.BedrockAgent.Model.GetRetrievalInstructionResponse CallAWSServiceOperation(IAmazonBedrockAgent client, Amazon.BedrockAgent.Model.GetRetrievalInstructionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Agents for Amazon Bedrock", "GetRetrievalInstruction");
            try
            {
                return client.GetRetrievalInstructionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String RetrievalInstructionId { get; set; }
            public System.String RetrievalInstructionVersion { get; set; }
            public System.Func<Amazon.BedrockAgent.Model.GetRetrievalInstructionResponse, GetAABRetrievalInstructionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
