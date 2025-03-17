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
using Amazon.BedrockAgentRuntime;
using Amazon.BedrockAgentRuntime.Model;

namespace Amazon.PowerShell.Cmdlets.BAR
{
    /// <summary>
    /// Add an invocation step to an invocation in a session. An invocation step stores fine-grained
    /// state checkpoints, including text and images, for each interaction. For more information
    /// about sessions, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/sessions.html">Store
    /// and retrieve conversation history and context with Amazon Bedrock sessions</a>.
    /// 
    ///  
    /// <para>
    /// Related APIs:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_agent-runtime_GetInvocationStep.html">GetInvocationStep</a></para></li><li><para><a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_agent-runtime_ListInvocationSteps.html">ListInvocationSteps</a></para></li><li><para><a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_agent-runtime_ListInvocations.html">ListInvocations</a></para></li><li><para><a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_agent-runtime_ListInvocations.html">ListSessions</a></para></li></ul>
    /// </summary>
    [Cmdlet("Write", "BARInvocationStep", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Runtime PutInvocationStep API operation.", Operation = new[] {"PutInvocationStep"}, SelectReturnType = typeof(Amazon.BedrockAgentRuntime.Model.PutInvocationStepResponse))]
    [AWSCmdletOutput("System.String or Amazon.BedrockAgentRuntime.Model.PutInvocationStepResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.BedrockAgentRuntime.Model.PutInvocationStepResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteBARInvocationStepCmdlet : AmazonBedrockAgentRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Payload_ContentBlock
        /// <summary>
        /// <para>
        /// <para>The content for the invocation step.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Payload_ContentBlocks")]
        public Amazon.BedrockAgentRuntime.Model.BedrockSessionContentBlock[] Payload_ContentBlock { get; set; }
        #endregion
        
        #region Parameter InvocationIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier (in UUID format) of the invocation to add the invocation step
        /// to.</para>
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
        public System.String InvocationIdentifier { get; set; }
        #endregion
        
        #region Parameter InvocationStepId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the invocation step in UUID format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InvocationStepId { get; set; }
        #endregion
        
        #region Parameter InvocationStepTime
        /// <summary>
        /// <para>
        /// <para>The timestamp for when the invocation step occurred.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? InvocationStepTime { get; set; }
        #endregion
        
        #region Parameter SessionIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the session to add the invocation step to. You can specify
        /// either the session's <c>sessionId</c> or its Amazon Resource Name (ARN).</para>
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
        public System.String SessionIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InvocationStepId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentRuntime.Model.PutInvocationStepResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentRuntime.Model.PutInvocationStepResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InvocationStepId";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SessionIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-BARInvocationStep (PutInvocationStep)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentRuntime.Model.PutInvocationStepResponse, WriteBARInvocationStepCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InvocationIdentifier = this.InvocationIdentifier;
            #if MODULAR
            if (this.InvocationIdentifier == null && ParameterWasBound(nameof(this.InvocationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter InvocationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InvocationStepId = this.InvocationStepId;
            context.InvocationStepTime = this.InvocationStepTime;
            #if MODULAR
            if (this.InvocationStepTime == null && ParameterWasBound(nameof(this.InvocationStepTime)))
            {
                WriteWarning("You are passing $null as a value for parameter InvocationStepTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Payload_ContentBlock != null)
            {
                context.Payload_ContentBlock = new List<Amazon.BedrockAgentRuntime.Model.BedrockSessionContentBlock>(this.Payload_ContentBlock);
            }
            context.SessionIdentifier = this.SessionIdentifier;
            #if MODULAR
            if (this.SessionIdentifier == null && ParameterWasBound(nameof(this.SessionIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockAgentRuntime.Model.PutInvocationStepRequest();
            
            if (cmdletContext.InvocationIdentifier != null)
            {
                request.InvocationIdentifier = cmdletContext.InvocationIdentifier;
            }
            if (cmdletContext.InvocationStepId != null)
            {
                request.InvocationStepId = cmdletContext.InvocationStepId;
            }
            if (cmdletContext.InvocationStepTime != null)
            {
                request.InvocationStepTime = cmdletContext.InvocationStepTime.Value;
            }
            
             // populate Payload
            var requestPayloadIsNull = true;
            request.Payload = new Amazon.BedrockAgentRuntime.Model.InvocationStepPayload();
            List<Amazon.BedrockAgentRuntime.Model.BedrockSessionContentBlock> requestPayload_payload_ContentBlock = null;
            if (cmdletContext.Payload_ContentBlock != null)
            {
                requestPayload_payload_ContentBlock = cmdletContext.Payload_ContentBlock;
            }
            if (requestPayload_payload_ContentBlock != null)
            {
                request.Payload.ContentBlocks = requestPayload_payload_ContentBlock;
                requestPayloadIsNull = false;
            }
             // determine if request.Payload should be set to null
            if (requestPayloadIsNull)
            {
                request.Payload = null;
            }
            if (cmdletContext.SessionIdentifier != null)
            {
                request.SessionIdentifier = cmdletContext.SessionIdentifier;
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
        
        private Amazon.BedrockAgentRuntime.Model.PutInvocationStepResponse CallAWSServiceOperation(IAmazonBedrockAgentRuntime client, Amazon.BedrockAgentRuntime.Model.PutInvocationStepRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Runtime", "PutInvocationStep");
            try
            {
                return client.PutInvocationStepAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String InvocationIdentifier { get; set; }
            public System.String InvocationStepId { get; set; }
            public System.DateTime? InvocationStepTime { get; set; }
            public List<Amazon.BedrockAgentRuntime.Model.BedrockSessionContentBlock> Payload_ContentBlock { get; set; }
            public System.String SessionIdentifier { get; set; }
            public System.Func<Amazon.BedrockAgentRuntime.Model.PutInvocationStepResponse, WriteBARInvocationStepCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InvocationStepId;
        }
        
    }
}
