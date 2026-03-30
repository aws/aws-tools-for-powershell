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
using Amazon.BedrockAgentCore;
using Amazon.BedrockAgentCore.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAC
{
    /// <summary>
    /// Executes a command in a runtime session container and streams the output back to the
    /// caller. This operation allows you to run shell commands within the agent runtime environment
    /// and receive real-time streaming responses including standard output and standard error.
    /// 
    ///  
    /// <para>
    /// To invoke a command, you must specify the agent runtime ARN and a runtime session
    /// ID. The command execution supports streaming responses, allowing you to receive output
    /// as it becomes available through <c>contentStart</c>, <c>contentDelta</c>, and <c>contentStop</c>
    /// events.
    /// </para><para>
    /// To use this operation, you must have the <c>bedrock-agentcore:InvokeAgentRuntimeCommand</c>
    /// permission.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "BACAgentRuntimeCommand", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCore.Model.InvokeAgentRuntimeCommandResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer InvokeAgentRuntimeCommand API operation.", Operation = new[] {"InvokeAgentRuntimeCommand"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.InvokeAgentRuntimeCommandResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.InvokeAgentRuntimeCommandResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.Model.InvokeAgentRuntimeCommandResponse object containing multiple properties."
    )]
    public partial class InvokeBACAgentRuntimeCommandCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Accept
        /// <summary>
        /// <para>
        /// <para>The desired MIME type for the response from the agent runtime command. This tells
        /// the agent runtime what format to use for the response data. Common values include
        /// application/json for JSON data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Accept { get; set; }
        #endregion
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Web Services account for the agent runtime resource.
        /// This parameter is required when you specify an agent ID instead of the full ARN for
        /// <c>agentRuntimeArn</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter AgentRuntimeArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the agent runtime on which to execute the command.
        /// This identifies the specific agent runtime environment where the command will run.</para>
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
        public System.String AgentRuntimeArn { get; set; }
        #endregion
        
        #region Parameter Baggage
        /// <summary>
        /// <para>
        /// <para>Additional context information for distributed tracing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Baggage { get; set; }
        #endregion
        
        #region Parameter Body_Command
        /// <summary>
        /// <para>
        /// <para>The shell command to execute on the agent runtime. This command is executed in the
        /// runtime environment and its output is streamed back to the caller.</para>
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
        public System.String Body_Command { get; set; }
        #endregion
        
        #region Parameter ContentType
        /// <summary>
        /// <para>
        /// <para>The MIME type of the input data in the request payload. This tells the agent runtime
        /// how to interpret the payload data. Common values include application/json for JSON
        /// data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentType { get; set; }
        #endregion
        
        #region Parameter Qualifier
        /// <summary>
        /// <para>
        /// <para>The qualifier to use for the agent runtime. This is an endpoint name that points to
        /// a specific version. If not specified, Amazon Bedrock AgentCore uses the default endpoint
        /// of the agent runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Qualifier { get; set; }
        #endregion
        
        #region Parameter RuntimeSessionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the runtime session in which to execute the command. This
        /// session ID is used to maintain state and context across multiple command invocations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RuntimeSessionId { get; set; }
        #endregion
        
        #region Parameter Body_Timeout
        /// <summary>
        /// <para>
        /// <para>The maximum duration in seconds to wait for the command to complete. If the command
        /// execution exceeds this timeout, it will be terminated. Default is 300 seconds. Minimum
        /// is 1 second. Maximum is 3600 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Body_Timeout { get; set; }
        #endregion
        
        #region Parameter TraceId
        /// <summary>
        /// <para>
        /// <para>The trace identifier for request tracking.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TraceId { get; set; }
        #endregion
        
        #region Parameter TraceParent
        /// <summary>
        /// <para>
        /// <para>The parent trace information for distributed tracing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TraceParent { get; set; }
        #endregion
        
        #region Parameter TraceState
        /// <summary>
        /// <para>
        /// <para>The trace state information for distributed tracing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TraceState { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.InvokeAgentRuntimeCommandResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.InvokeAgentRuntimeCommandResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AgentRuntimeArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BACAgentRuntimeCommand (InvokeAgentRuntimeCommand)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.InvokeAgentRuntimeCommandResponse, InvokeBACAgentRuntimeCommandCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Accept = this.Accept;
            context.AccountId = this.AccountId;
            context.AgentRuntimeArn = this.AgentRuntimeArn;
            #if MODULAR
            if (this.AgentRuntimeArn == null && ParameterWasBound(nameof(this.AgentRuntimeArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentRuntimeArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Baggage = this.Baggage;
            context.Body_Command = this.Body_Command;
            #if MODULAR
            if (this.Body_Command == null && ParameterWasBound(nameof(this.Body_Command)))
            {
                WriteWarning("You are passing $null as a value for parameter Body_Command which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Body_Timeout = this.Body_Timeout;
            context.ContentType = this.ContentType;
            context.Qualifier = this.Qualifier;
            context.RuntimeSessionId = this.RuntimeSessionId;
            context.TraceId = this.TraceId;
            context.TraceParent = this.TraceParent;
            context.TraceState = this.TraceState;
            
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
            var request = new Amazon.BedrockAgentCore.Model.InvokeAgentRuntimeCommandRequest();
            
            if (cmdletContext.Accept != null)
            {
                request.Accept = cmdletContext.Accept;
            }
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.AgentRuntimeArn != null)
            {
                request.AgentRuntimeArn = cmdletContext.AgentRuntimeArn;
            }
            if (cmdletContext.Baggage != null)
            {
                request.Baggage = cmdletContext.Baggage;
            }
            
             // populate Body
            var requestBodyIsNull = true;
            request.Body = new Amazon.BedrockAgentCore.Model.InvokeAgentRuntimeCommandRequestBody();
            System.String requestBody_body_Command = null;
            if (cmdletContext.Body_Command != null)
            {
                requestBody_body_Command = cmdletContext.Body_Command;
            }
            if (requestBody_body_Command != null)
            {
                request.Body.Command = requestBody_body_Command;
                requestBodyIsNull = false;
            }
            System.Int32? requestBody_body_Timeout = null;
            if (cmdletContext.Body_Timeout != null)
            {
                requestBody_body_Timeout = cmdletContext.Body_Timeout.Value;
            }
            if (requestBody_body_Timeout != null)
            {
                request.Body.Timeout = requestBody_body_Timeout.Value;
                requestBodyIsNull = false;
            }
             // determine if request.Body should be set to null
            if (requestBodyIsNull)
            {
                request.Body = null;
            }
            if (cmdletContext.ContentType != null)
            {
                request.ContentType = cmdletContext.ContentType;
            }
            if (cmdletContext.Qualifier != null)
            {
                request.Qualifier = cmdletContext.Qualifier;
            }
            if (cmdletContext.RuntimeSessionId != null)
            {
                request.RuntimeSessionId = cmdletContext.RuntimeSessionId;
            }
            if (cmdletContext.TraceId != null)
            {
                request.TraceId = cmdletContext.TraceId;
            }
            if (cmdletContext.TraceParent != null)
            {
                request.TraceParent = cmdletContext.TraceParent;
            }
            if (cmdletContext.TraceState != null)
            {
                request.TraceState = cmdletContext.TraceState;
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
        
        private Amazon.BedrockAgentCore.Model.InvokeAgentRuntimeCommandResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.InvokeAgentRuntimeCommandRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "InvokeAgentRuntimeCommand");
            try
            {
                return client.InvokeAgentRuntimeCommandAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Accept { get; set; }
            public System.String AccountId { get; set; }
            public System.String AgentRuntimeArn { get; set; }
            public System.String Baggage { get; set; }
            public System.String Body_Command { get; set; }
            public System.Int32? Body_Timeout { get; set; }
            public System.String ContentType { get; set; }
            public System.String Qualifier { get; set; }
            public System.String RuntimeSessionId { get; set; }
            public System.String TraceId { get; set; }
            public System.String TraceParent { get; set; }
            public System.String TraceState { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.InvokeAgentRuntimeCommandResponse, InvokeBACAgentRuntimeCommandCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
