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
using Amazon.BedrockAgentRuntime;
using Amazon.BedrockAgentRuntime.Model;

namespace Amazon.PowerShell.Cmdlets.BAR
{
    /// <summary>
    /// Retrieves the details of a specific invocation step within an invocation in a session.
    /// For more information about sessions, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/sessions.html">Store
    /// and retrieve conversation history and context with Amazon Bedrock sessions</a>.
    /// </summary>
    [Cmdlet("Get", "BARInvocationStep")]
    [OutputType("Amazon.BedrockAgentRuntime.Model.InvocationStep")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Runtime GetInvocationStep API operation.", Operation = new[] {"GetInvocationStep"}, SelectReturnType = typeof(Amazon.BedrockAgentRuntime.Model.GetInvocationStepResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentRuntime.Model.InvocationStep or Amazon.BedrockAgentRuntime.Model.GetInvocationStepResponse",
        "This cmdlet returns an Amazon.BedrockAgentRuntime.Model.InvocationStep object.",
        "The service call response (type Amazon.BedrockAgentRuntime.Model.GetInvocationStepResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBARInvocationStepCmdlet : AmazonBedrockAgentRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InvocationIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the invocation in UUID format.</para>
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
        /// <para>The unique identifier (in UUID format) for the specific invocation step to retrieve.</para>
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
        public System.String InvocationStepId { get; set; }
        #endregion
        
        #region Parameter SessionIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the invocation step's associated session. You can specify
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InvocationStep'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentRuntime.Model.GetInvocationStepResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentRuntime.Model.GetInvocationStepResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InvocationStep";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SessionIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SessionIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SessionIdentifier' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentRuntime.Model.GetInvocationStepResponse, GetBARInvocationStepCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SessionIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InvocationIdentifier = this.InvocationIdentifier;
            #if MODULAR
            if (this.InvocationIdentifier == null && ParameterWasBound(nameof(this.InvocationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter InvocationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InvocationStepId = this.InvocationStepId;
            #if MODULAR
            if (this.InvocationStepId == null && ParameterWasBound(nameof(this.InvocationStepId)))
            {
                WriteWarning("You are passing $null as a value for parameter InvocationStepId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.BedrockAgentRuntime.Model.GetInvocationStepRequest();
            
            if (cmdletContext.InvocationIdentifier != null)
            {
                request.InvocationIdentifier = cmdletContext.InvocationIdentifier;
            }
            if (cmdletContext.InvocationStepId != null)
            {
                request.InvocationStepId = cmdletContext.InvocationStepId;
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
        
        private Amazon.BedrockAgentRuntime.Model.GetInvocationStepResponse CallAWSServiceOperation(IAmazonBedrockAgentRuntime client, Amazon.BedrockAgentRuntime.Model.GetInvocationStepRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Runtime", "GetInvocationStep");
            try
            {
                #if DESKTOP
                return client.GetInvocationStep(request);
                #elif CORECLR
                return client.GetInvocationStepAsync(request).GetAwaiter().GetResult();
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
            public System.String InvocationIdentifier { get; set; }
            public System.String InvocationStepId { get; set; }
            public System.String SessionIdentifier { get; set; }
            public System.Func<Amazon.BedrockAgentRuntime.Model.GetInvocationStepResponse, GetBARInvocationStepCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InvocationStep;
        }
        
    }
}
