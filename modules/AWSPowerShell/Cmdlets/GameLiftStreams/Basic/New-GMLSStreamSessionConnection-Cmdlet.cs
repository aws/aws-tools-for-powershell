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
using Amazon.GameLiftStreams;
using Amazon.GameLiftStreams.Model;

namespace Amazon.PowerShell.Cmdlets.GMLS
{
    /// <summary>
    /// Enables clients to reconnect to a stream session while preserving all session state
    /// and data in the disconnected session. This reconnection process can be initiated when
    /// a stream session is in either <c>PENDING_CLIENT_RECONNECTION</c> or <c>ACTIVE</c>
    /// status. The process works as follows: 
    /// 
    ///  <ol><li><para>
    /// Initial disconnect:
    /// </para><ul><li><para>
    /// When a client disconnects or loses connection, the stream session transitions from
    /// <c>CONNECTED</c> to <c>PENDING_CLIENT_RECONNECTION</c></para></li></ul></li><li><para>
    /// Reconnection time window:
    /// </para><ul><li><para>
    /// Clients have <c>ConnectionTimeoutSeconds</c> (defined in <a href="https://docs.aws.amazon.com/gameliftstreams/latest/apireference/API_StartStreamSession.html">StartStreamSession</a>)
    /// to reconnect before session termination
    /// </para></li><li><para>
    /// Your backend server must call <b>CreateStreamSessionConnection</b> to initiate reconnection
    /// </para></li><li><para>
    /// Session transitions to <c>RECONNECTING</c> status
    /// </para></li></ul></li><li><para>
    /// Reconnection completion:
    /// </para><ul><li><para>
    /// On successful <b>CreateStreamSessionConnection</b>, session status changes to <c>ACTIVE</c></para></li><li><para>
    /// Provide the new connection information to the requesting client
    /// </para></li><li><para>
    /// Client must establish connection within <c>ConnectionTimeoutSeconds</c></para></li><li><para>
    /// Session terminates automatically if client fails to connect in time
    /// </para></li></ul></li></ol><para>
    /// For more information about the stream session lifecycle, see <a href="https://docs.aws.amazon.com/gameliftstreams/latest/developerguide/stream-sessions.html">Stream
    /// sessions</a> in the <i>Amazon GameLift Streams Developer Guide</i>.
    /// </para><para>
    /// To begin re-connecting to an existing stream session, specify the stream group ID
    /// and stream session ID that you want to reconnect to, and the signal request to use
    /// with the stream.
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
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para><a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference-arns.html">Amazon
        /// Resource Name (ARN)</a> or ID that uniquely identifies the stream group resource.
        /// Example ARN: <c>arn:aws:gameliftstreams:us-west-2:111122223333:streamgroup/sg-1AB2C3De4</c>.
        /// Example ID: <c>sg-1AB2C3De4</c>. </para><para> The stream group that you want to run this stream session with. The stream group
        /// must be in <c>ACTIVE</c> status. </para>
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
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
                #if DESKTOP
                return client.CreateStreamSessionConnection(request);
                #elif CORECLR
                return client.CreateStreamSessionConnectionAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Identifier { get; set; }
            public System.String SignalRequest { get; set; }
            public System.String StreamSessionIdentifier { get; set; }
            public System.Func<Amazon.GameLiftStreams.Model.CreateStreamSessionConnectionResponse, NewGMLSStreamSessionConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
