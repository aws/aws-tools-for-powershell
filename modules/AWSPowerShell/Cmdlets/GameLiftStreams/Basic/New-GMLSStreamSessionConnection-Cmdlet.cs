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
using Amazon.GameLiftStreams;
using Amazon.GameLiftStreams.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GMLS
{
    /// <summary>
    /// Allows clients to reconnect to a recently disconnected stream session without losing
    /// any data from the last session.
    /// 
    ///  
    /// <para>
    /// A client can reconnect to a stream session that's in <c>PENDING_CLIENT_RECONNECTION</c>
    /// or <c>ACTIVE</c> status. In the stream session life cycle, when the client disconnects
    /// from the stream session, the stream session transitions from <c>CONNECTED</c> to <c>PENDING_CLIENT_RECONNECTION</c>
    /// status. When a client requests to reconnect by calling <c>CreateStreamSessionConnection</c>,
    /// the stream session transitions to <c>RECONNECTING</c> status. When the reconnection
    /// is successful, the stream session transitions to <c>ACTIVE</c> status. After a stream
    /// session is disconnected for longer than <c>ConnectionTimeoutSeconds</c>, the stream
    /// session transitions to the <c>TERMINATED</c> status.
    /// </para><para>
    /// To connect to an existing stream session, specify the stream group ID and stream session
    /// ID that you want to reconnect to, as well as the signal request settings to use with
    /// the stream.
    /// </para><para><c>ConnectionTimeoutSeconds</c> defines the amount of time after the stream session
    /// disconnects that a reconnection is allowed. If a client is disconnected from the stream
    /// for longer than <c>ConnectionTimeoutSeconds</c>, the stream session ends.
    /// </para>
    /// </summary>
    [Cmdlet("New", "GMLSStreamSessionConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLiftStreams.Model.CreateStreamSessionConnectionResponse")]
    [AWSCmdlet("Calls the Amazon GameLiftStreams CreateStreamSessionConnection API operation.", Operation = new[] {"CreateStreamSessionConnection"}, SelectReturnType = typeof(Amazon.GameLiftStreams.Model.CreateStreamSessionConnectionResponse))]
    [AWSCmdletOutput("Amazon.GameLiftStreams.Model.CreateStreamSessionConnectionResponse",
        "This cmdlet returns an Amazon.GameLiftStreams.Model.CreateStreamSessionConnectionResponse object containing multiple properties."
    )]
    public partial class NewGMLSStreamSessionConnectionCmdlet : AmazonGameLiftStreamsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para><a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference-arns.html">Amazon
        /// Resource Name (ARN)</a> or ID that uniquely identifies the stream group resource.
        /// Example ARN: <c>arn:aws:gameliftstreams:us-west-2:111122223333:streamgroup/sg-1AB2C3De4</c>.
        /// Example ID: <c>sg-1AB2C3De4</c>. </para><para> The stream group that you want to run this stream session with. The stream group
        /// must be in <c>ACTIVE</c> status and have idle stream capacity. </para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter SignalRequest
        /// <summary>
        /// <para>
        /// <para>A WebRTC ICE offer string to use when initializing a WebRTC connection. The offer
        /// is a very long JSON string. Provide the string as a text value in quotes. The offer
        /// must be newly generated, not the same offer provided to <c>StartStreamSession</c>.
        /// </para>
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
        public System.String SignalRequest { get; set; }
        #endregion
        
        #region Parameter StreamSessionIdentifier
        /// <summary>
        /// <para>
        /// <para><a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference-arns.html">Amazon
        /// Resource Name (ARN)</a> or ID that uniquely identifies the stream session resource.
        /// Example ARN: <c>arn:aws:gameliftstreams:us-west-2:111122223333:streamsession/sg-1AB2C3De4/ABC123def4567</c>.
        /// Example ID: <c>ABC123def4567</c>. </para><para> The stream session must be in <c>PENDING_CLIENT_RECONNECTION</c> or <c>ACTIVE</c>
        /// status. </para>
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
        public System.String StreamSessionIdentifier { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> A unique identifier that represents a client request. The request is idempotent,
        /// which ensures that an API request completes only once. When users send a request,
        /// Amazon GameLift Streams automatically populates this field. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLiftStreams.Model.CreateStreamSessionConnectionResponse).
        /// Specifying the name of a property of type Amazon.GameLiftStreams.Model.CreateStreamSessionConnectionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLSStreamSessionConnection (CreateStreamSessionConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLiftStreams.Model.CreateStreamSessionConnectionResponse, NewGMLSStreamSessionConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SignalRequest = this.SignalRequest;
            #if MODULAR
            if (this.SignalRequest == null && ParameterWasBound(nameof(this.SignalRequest)))
            {
                WriteWarning("You are passing $null as a value for parameter SignalRequest which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamSessionIdentifier = this.StreamSessionIdentifier;
            #if MODULAR
            if (this.StreamSessionIdentifier == null && ParameterWasBound(nameof(this.StreamSessionIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamSessionIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GameLiftStreams.Model.CreateStreamSessionConnectionRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.SignalRequest != null)
            {
                request.SignalRequest = cmdletContext.SignalRequest;
            }
            if (cmdletContext.StreamSessionIdentifier != null)
            {
                request.StreamSessionIdentifier = cmdletContext.StreamSessionIdentifier;
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
        
        private Amazon.GameLiftStreams.Model.CreateStreamSessionConnectionResponse CallAWSServiceOperation(IAmazonGameLiftStreams client, Amazon.GameLiftStreams.Model.CreateStreamSessionConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLiftStreams", "CreateStreamSessionConnection");
            try
            {
                return client.CreateStreamSessionConnectionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Identifier { get; set; }
            public System.String SignalRequest { get; set; }
            public System.String StreamSessionIdentifier { get; set; }
            public System.Func<Amazon.GameLiftStreams.Model.CreateStreamSessionConnectionResponse, NewGMLSStreamSessionConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
