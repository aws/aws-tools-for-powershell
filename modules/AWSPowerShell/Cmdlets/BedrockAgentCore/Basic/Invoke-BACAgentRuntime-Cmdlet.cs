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
using Amazon.BedrockAgentCore;
using Amazon.BedrockAgentCore.Model;

namespace Amazon.PowerShell.Cmdlets.BAC
{
    /// <summary>
    /// Sends a request to an agent or tool hosted in an Amazon Bedrock AgentCore Runtime
    /// and receives responses in real-time. 
    /// 
    ///  
    /// <para>
    /// To invoke an agent you must specify the AgentCore Runtime ARN and provide a payload
    /// containing your request. You can optionally specify a qualifier to target a specific
    /// version or endpoint of the agent.
    /// </para><para>
    /// This operation supports streaming responses, allowing you to receive partial responses
    /// as they become available. We recommend using pagination to ensure that the operation
    /// returns quickly and successfully when processing large responses.
    /// </para><para>
    /// For example code, see <a href="https://docs.aws.amazon.com/bedrock-agentcore/latest/devguide/runtime-invoke-agent.html">Invoke
    /// an AgentCore Runtime agent</a>. 
    /// </para><para>
    /// If you're integrating your agent with OAuth, you can't use the Amazon Web Services
    /// SDK to call <c>InvokeAgentRuntime</c>. Instead, make a HTTPS request to <c>InvokeAgentRuntime</c>.
    /// For an example, see <a href="https://docs.aws.amazon.com/bedrock-agentcore/latest/devguide/runtime-oauth.html">Authenticate
    /// and authorize with Inbound Auth and Outbound Auth</a>.
    /// </para><para>
    /// To use this operation, you must have the <c>bedrock-agentcore:InvokeAgentRuntime</c>
    /// permission. If you are making a call to <c>InvokeAgentRuntime</c> on behalf of a user
    /// ID with the <c>X-Amzn-Bedrock-AgentCore-Runtime-User-Id</c> header, You require permissions
    /// to both actions (<c>bedrock-agentcore:InvokeAgentRuntime</c> and <c>bedrock-agentcore:InvokeAgentRuntimeForUser</c>).
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "BACAgentRuntime", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCore.Model.InvokeAgentRuntimeResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer InvokeAgentRuntime API operation.", Operation = new[] {"InvokeAgentRuntime"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.InvokeAgentRuntimeResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.InvokeAgentRuntimeResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.Model.InvokeAgentRuntimeResponse object containing multiple properties."
    )]
    public partial class InvokeBACAgentRuntimeCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Accept
        /// <summary>
        /// <para>
        /// <para>The desired MIME type for the response from the agent runtime. This tells the agent
        /// runtime what format to use for the response data. Common values include application/json
        /// for JSON data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Accept { get; set; }
        #endregion
        
        #region Parameter AgentRuntimeArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Resource Name (ARN) of the agent runtime to invoke. The ARN
        /// uniquely identifies the agent runtime resource in Amazon Bedrock.</para>
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
        
        #region Parameter ContentType
        /// <summary>
        /// <para>
        /// <para>The MIME type of the input data in the payload. This tells the agent runtime how to
        /// interpret the payload data. Common values include application/json for JSON data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentType { get; set; }
        #endregion
        
        #region Parameter McpProtocolVersion
        /// <summary>
        /// <para>
        /// <para>The version of the MCP protocol being used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String McpProtocolVersion { get; set; }
        #endregion
        
        #region Parameter McpSessionId
        /// <summary>
        /// <para>
        /// <para>The identifier of the MCP session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String McpSessionId { get; set; }
        #endregion
        
        #region Parameter Payload
        /// <summary>
        /// <para>
        /// <para>The input data to send to the agent runtime. The format of this data depends on the
        /// specific agent configuration and must match the specified content type. For most agents,
        /// this is a JSON object containing the user's request.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Payload { get; set; }
        #endregion
        
        #region Parameter Qualifier
        /// <summary>
        /// <para>
        /// <para>The qualifier to use for the agent runtime. This can be a version number or an endpoint
        /// name that points to a specific version. If not specified, Amazon Bedrock uses the
        /// default version of the agent runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Qualifier { get; set; }
        #endregion
        
        #region Parameter RuntimeSessionId
        /// <summary>
        /// <para>
        /// <para>The identifier of the runtime session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RuntimeSessionId { get; set; }
        #endregion
        
        #region Parameter RuntimeUserId
        /// <summary>
        /// <para>
        /// <para>The identifier of the runtime user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RuntimeUserId { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.InvokeAgentRuntimeResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.InvokeAgentRuntimeResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AgentRuntimeArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-BACAgentRuntime (InvokeAgentRuntime)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.InvokeAgentRuntimeResponse, InvokeBACAgentRuntimeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Accept = this.Accept;
            context.AgentRuntimeArn = this.AgentRuntimeArn;
            #if MODULAR
            if (this.AgentRuntimeArn == null && ParameterWasBound(nameof(this.AgentRuntimeArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentRuntimeArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Baggage = this.Baggage;
            context.ContentType = this.ContentType;
            context.McpProtocolVersion = this.McpProtocolVersion;
            context.McpSessionId = this.McpSessionId;
            context.Payload = this.Payload;
            #if MODULAR
            if (this.Payload == null && ParameterWasBound(nameof(this.Payload)))
            {
                WriteWarning("You are passing $null as a value for parameter Payload which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Qualifier = this.Qualifier;
            context.RuntimeSessionId = this.RuntimeSessionId;
            context.RuntimeUserId = this.RuntimeUserId;
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
            System.IO.MemoryStream _PayloadStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.BedrockAgentCore.Model.InvokeAgentRuntimeRequest();
                
                if (cmdletContext.Accept != null)
                {
                    request.Accept = cmdletContext.Accept;
                }
                if (cmdletContext.AgentRuntimeArn != null)
                {
                    request.AgentRuntimeArn = cmdletContext.AgentRuntimeArn;
                }
                if (cmdletContext.Baggage != null)
                {
                    request.Baggage = cmdletContext.Baggage;
                }
                if (cmdletContext.ContentType != null)
                {
                    request.ContentType = cmdletContext.ContentType;
                }
                if (cmdletContext.McpProtocolVersion != null)
                {
                    request.McpProtocolVersion = cmdletContext.McpProtocolVersion;
                }
                if (cmdletContext.McpSessionId != null)
                {
                    request.McpSessionId = cmdletContext.McpSessionId;
                }
                if (cmdletContext.Payload != null)
                {
                    _PayloadStream = new System.IO.MemoryStream(cmdletContext.Payload);
                    request.Payload = _PayloadStream;
                }
                if (cmdletContext.Qualifier != null)
                {
                    request.Qualifier = cmdletContext.Qualifier;
                }
                if (cmdletContext.RuntimeSessionId != null)
                {
                    request.RuntimeSessionId = cmdletContext.RuntimeSessionId;
                }
                if (cmdletContext.RuntimeUserId != null)
                {
                    request.RuntimeUserId = cmdletContext.RuntimeUserId;
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
            finally
            {
                if( _PayloadStream != null)
                {
                    _PayloadStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.BedrockAgentCore.Model.InvokeAgentRuntimeResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.InvokeAgentRuntimeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "InvokeAgentRuntime");
            try
            {
                #if DESKTOP
                return client.InvokeAgentRuntime(request);
                #elif CORECLR
                return client.InvokeAgentRuntimeAsync(request).GetAwaiter().GetResult();
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
            public System.String Accept { get; set; }
            public System.String AgentRuntimeArn { get; set; }
            public System.String Baggage { get; set; }
            public System.String ContentType { get; set; }
            public System.String McpProtocolVersion { get; set; }
            public System.String McpSessionId { get; set; }
            public byte[] Payload { get; set; }
            public System.String Qualifier { get; set; }
            public System.String RuntimeSessionId { get; set; }
            public System.String RuntimeUserId { get; set; }
            public System.String TraceId { get; set; }
            public System.String TraceParent { get; set; }
            public System.String TraceState { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.InvokeAgentRuntimeResponse, InvokeBACAgentRuntimeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
