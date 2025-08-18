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
using Amazon.ConnectParticipant;
using Amazon.ConnectParticipant.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONNP
{
    /// <summary>
    /// Creates the participant's connection. 
    /// 
    ///  
    /// <para>
    /// For security recommendations, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/security-best-practices.html#bp-security-chat">Amazon
    /// Connect Chat security best practices</a>. 
    /// </para><para>
    /// For WebRTC security recommendations, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/security-best-practices.html#bp-webrtc-security">Amazon
    /// Connect WebRTC security best practices</a>. 
    /// </para><note><para><c>ParticipantToken</c> is used for invoking this API instead of <c>ConnectionToken</c>.
    /// </para></note><para>
    /// The participant token is valid for the lifetime of the participant – until they are
    /// part of a contact. For WebRTC participants, if they leave or are disconnected for
    /// 60 seconds, a new participant needs to be created using the <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_CreateParticipant.html">CreateParticipant</a>
    /// API. 
    /// </para><para><b>For <c>WEBSOCKET</c> Type</b>: 
    /// </para><para>
    /// The response URL for has a connect expiry timeout of 100s. Clients must manually connect
    /// to the returned websocket URL and subscribe to the desired topic. 
    /// </para><para>
    /// For chat, you need to publish the following on the established websocket connection:
    /// </para><para><c>{"topic":"aws/subscribe","content":{"topics":["aws/chat"]}}</c></para><para>
    /// Upon websocket URL expiry, as specified in the response ConnectionExpiry parameter,
    /// clients need to call this API again to obtain a new websocket URL and perform the
    /// same steps as before.
    /// </para><para>
    /// The expiry time for the connection token is different than the <c>ChatDurationInMinutes</c>.
    /// Expiry time for the connection token is 1 day.
    /// </para><para><b>For <c>WEBRTC_CONNECTION</c> Type</b>: 
    /// </para><para>
    /// The response includes connection data required for the client application to join
    /// the call using the Amazon Chime SDK client libraries. The WebRTCConnection response
    /// contains Meeting and Attendee information needed to establish the media connection.
    /// 
    /// </para><para>
    /// The attendee join token in WebRTCConnection response is valid for the lifetime of
    /// the participant in the call. If a participant leaves or is disconnected for 60 seconds,
    /// their participant credentials will no longer be valid, and a new participant will
    /// need to be created to rejoin the call. 
    /// </para><para><b>Message streaming support</b>: This API can also be used together with the <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_StartContactStreaming.html">StartContactStreaming</a>
    /// API to create a participant connection for chat contacts that are not using a websocket.
    /// For more information about message streaming, <a href="https://docs.aws.amazon.com/connect/latest/adminguide/chat-message-streaming.html">Enable
    /// real-time chat message streaming</a> in the <i>Amazon Connect Administrator Guide</i>.
    /// </para><para><b>Multi-user web, in-app, video calling support</b>: 
    /// </para><para>
    /// For WebRTC calls, this API is used in conjunction with the CreateParticipant API to
    /// enable multi-party calling. The StartWebRTCContact API creates the initial contact
    /// and routes it to an agent, while CreateParticipant adds additional participants to
    /// the ongoing call. For more information about multi-party WebRTC calls, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/enable-multiuser-inapp.html">Enable
    /// multi-user web, in-app, and video calling</a> in the <i>Amazon Connect Administrator
    /// Guide</i>. 
    /// </para><para><b>Feature specifications</b>: For information about feature specifications, such
    /// as the allowed number of open websocket connections per participant or maximum number
    /// of WebRTC participants, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/amazon-connect-service-limits.html#feature-limits">Feature
    /// specifications</a> in the <i>Amazon Connect Administrator Guide</i>. 
    /// </para><note><para>
    /// The Amazon Connect Participant Service APIs do not use <a href="https://docs.aws.amazon.com/general/latest/gr/signature-version-4.html">Signature
    /// Version 4 authentication</a>.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "CONNPParticipantConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConnectParticipant.Model.CreateParticipantConnectionResponse")]
    [AWSCmdlet("Calls the Amazon Connect Participant Service CreateParticipantConnection API operation.", Operation = new[] {"CreateParticipantConnection"}, SelectReturnType = typeof(Amazon.ConnectParticipant.Model.CreateParticipantConnectionResponse))]
    [AWSCmdletOutput("Amazon.ConnectParticipant.Model.CreateParticipantConnectionResponse",
        "This cmdlet returns an Amazon.ConnectParticipant.Model.CreateParticipantConnectionResponse object containing multiple properties."
    )]
    public partial class NewCONNPParticipantConnectionCmdlet : AmazonConnectParticipantClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConnectParticipant
        /// <summary>
        /// <para>
        /// <para>Amazon Connect Participant is used to mark the participant as connected for customer
        /// participant in message streaming, as well as for agent or manager participant in non-streaming
        /// chats.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConnectParticipant { get; set; }
        #endregion
        
        #region Parameter ParticipantToken
        /// <summary>
        /// <para>
        /// <para>This is a header parameter.</para><para>The ParticipantToken as obtained from <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_StartChatContact.html">StartChatContact</a>
        /// API response.</para>
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
        public System.String ParticipantToken { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>Type of connection information required. If you need <c>CONNECTION_CREDENTIALS</c>
        /// along with marking participant as connected, pass <c>CONNECTION_CREDENTIALS</c> in
        /// <c>Type</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectParticipant.Model.CreateParticipantConnectionResponse).
        /// Specifying the name of a property of type Amazon.ConnectParticipant.Model.CreateParticipantConnectionResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CONNPParticipantConnection (CreateParticipantConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectParticipant.Model.CreateParticipantConnectionResponse, NewCONNPParticipantConnectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectParticipant = this.ConnectParticipant;
            context.ParticipantToken = this.ParticipantToken;
            #if MODULAR
            if (this.ParticipantToken == null && ParameterWasBound(nameof(this.ParticipantToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ParticipantToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Type != null)
            {
                context.Type = new List<System.String>(this.Type);
            }
            
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
            var request = new Amazon.ConnectParticipant.Model.CreateParticipantConnectionRequest();
            
            if (cmdletContext.ConnectParticipant != null)
            {
                request.ConnectParticipant = cmdletContext.ConnectParticipant.Value;
            }
            if (cmdletContext.ParticipantToken != null)
            {
                request.ParticipantToken = cmdletContext.ParticipantToken;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.ConnectParticipant.Model.CreateParticipantConnectionResponse CallAWSServiceOperation(IAmazonConnectParticipant client, Amazon.ConnectParticipant.Model.CreateParticipantConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Participant Service", "CreateParticipantConnection");
            try
            {
                return client.CreateParticipantConnectionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? ConnectParticipant { get; set; }
            public System.String ParticipantToken { get; set; }
            public List<System.String> Type { get; set; }
            public System.Func<Amazon.ConnectParticipant.Model.CreateParticipantConnectionResponse, NewCONNPParticipantConnectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
