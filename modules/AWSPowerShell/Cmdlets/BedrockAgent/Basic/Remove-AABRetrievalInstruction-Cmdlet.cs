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
    /// Deletes a retrieval instruction or a single version of it. Omit retrievalInstructionVersion
    /// to delete the retrieval instruction itself; the service rejects that request with
    /// ConflictException while the retrieval instruction has versions or while lastTransitionStatus
    /// is CREATING or UPDATING. Specify retrievalInstructionVersion to delete only that version;
    /// the retrieval instruction and its other versions are unaffected.
    /// </summary>
    [Cmdlet("Remove", "AABRetrievalInstruction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.BedrockAgent.Model.DeleteRetrievalInstructionResponse")]
    [AWSCmdlet("Calls the Agents for Amazon Bedrock DeleteRetrievalInstruction API operation.", Operation = new[] {"DeleteRetrievalInstruction"}, SelectReturnType = typeof(Amazon.BedrockAgent.Model.DeleteRetrievalInstructionResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgent.Model.DeleteRetrievalInstructionResponse",
        "This cmdlet returns an Amazon.BedrockAgent.Model.DeleteRetrievalInstructionResponse object containing multiple properties."
    )]
    public partial class RemoveAABRetrievalInstructionCmdlet : AmazonBedrockAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RetrievalInstructionId
        /// <summary>
        /// <para>
        /// <para>The identifier of the retrieval instruction to delete.</para>
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
        /// <para>The version to delete. Omit this field to delete the retrieval instruction itself,
        /// which you can do only when it has no versions; while any version exists the service
        /// rejects the request with ConflictException. You cannot delete DRAFT on its own; deleting
        /// the retrieval instruction removes it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RetrievalInstructionVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgent.Model.DeleteRetrievalInstructionResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgent.Model.DeleteRetrievalInstructionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RetrievalInstructionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-AABRetrievalInstruction (DeleteRetrievalInstruction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgent.Model.DeleteRetrievalInstructionResponse, RemoveAABRetrievalInstructionCmdlet>(Select) ??
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
            var request = new Amazon.BedrockAgent.Model.DeleteRetrievalInstructionRequest();
            
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
        
        private Amazon.BedrockAgent.Model.DeleteRetrievalInstructionResponse CallAWSServiceOperation(IAmazonBedrockAgent client, Amazon.BedrockAgent.Model.DeleteRetrievalInstructionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Agents for Amazon Bedrock", "DeleteRetrievalInstruction");
            try
            {
                return client.DeleteRetrievalInstructionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.BedrockAgent.Model.DeleteRetrievalInstructionResponse, RemoveAABRetrievalInstructionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
