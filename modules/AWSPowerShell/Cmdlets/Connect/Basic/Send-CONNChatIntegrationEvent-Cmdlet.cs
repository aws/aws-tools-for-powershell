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
using Amazon.Connect;
using Amazon.Connect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Processes chat integration events from Amazon Web Services or external integrations
    /// to Amazon Connect. A chat integration event includes:
    /// 
    ///  <ul><li><para>
    /// SourceId, DestinationId, and Subtype: a set of identifiers, uniquely representing
    /// a chat
    /// </para></li><li><para>
    ///  ChatEvent: details of the chat action to perform such as sending a message, event,
    /// or disconnecting from a chat
    /// </para></li></ul><para>
    /// When a chat integration event is sent with chat identifiers that do not map to an
    /// active chat contact, a new chat contact is also created before handling chat action.
    /// 
    /// </para><para>
    /// Access to this API is currently restricted to Amazon Web Services End User Messaging
    /// for supporting SMS integration. 
    /// </para>
    /// </summary>
    [Cmdlet("Send", "CONNChatIntegrationEvent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.SendChatIntegrationEventResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service SendChatIntegrationEvent API operation.", Operation = new[] {"SendChatIntegrationEvent"}, SelectReturnType = typeof(Amazon.Connect.Model.SendChatIntegrationEventResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.SendChatIntegrationEventResponse",
        "This cmdlet returns an Amazon.Connect.Model.SendChatIntegrationEventResponse object containing multiple properties."
    )]
    public partial class SendCONNChatIntegrationEventCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter NewSessionDetails_Attribute
        /// <summary>
        /// <para>
        /// <para> A custom key-value pair using an attribute map. The attributes are standard Amazon
        /// Connect attributes. They can be accessed in flows just like any other contact attributes.
        /// </para><para> There can be up to 32,768 UTF-8 bytes across all key-value pairs per contact. Attribute
        /// keys can include only alphanumeric, dash, and underscore characters. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewSessionDetails_Attributes")]
        public System.Collections.Hashtable NewSessionDetails_Attribute { get; set; }
        #endregion
        
        #region Parameter Event_Content
        /// <summary>
        /// <para>
        /// <para>Content of the message or event. This is required when <c>Type</c> is <c>MESSAGE</c>
        /// and for certain <c>ContentTypes</c> when <c>Type</c> is <c>EVENT</c>.</para><ul><li><para>For allowed message content, see the <c>Content</c> parameter in the <a href="https://docs.aws.amazon.com/connect-participant/latest/APIReference/API_SendMessage.html">SendMessage</a>
        /// topic in the <i>Amazon Connect Participant Service API Reference</i>.</para></li><li><para>For allowed event content, see the <c>Content</c> parameter in the <a href="https://docs.aws.amazon.com/connect-participant/latest/APIReference/API_SendEvent.html">SendEvent</a>
        /// topic in the <i>Amazon Connect Participant Service API Reference</i>. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Event_Content { get; set; }
        #endregion
        
        #region Parameter Event_ContentType
        /// <summary>
        /// <para>
        /// <para>Type of content. This is required when <c>Type</c> is <c>MESSAGE</c> or <c>EVENT</c>.
        /// </para><ul><li><para>For allowed message content types, see the <c>ContentType</c> parameter in the <a href="https://docs.aws.amazon.com/connect-participant/latest/APIReference/API_SendMessage.html">SendMessage</a>
        /// topic in the <i>Amazon Connect Participant Service API Reference</i>.</para></li><li><para>For allowed event content types, see the <c>ContentType</c> parameter in the <a href="https://docs.aws.amazon.com/connect-participant/latest/APIReference/API_SendEvent.html">SendEvent</a>
        /// topic in the <i>Amazon Connect Participant Service API Reference</i>. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Event_ContentType { get; set; }
        #endregion
        
        #region Parameter DestinationId
        /// <summary>
        /// <para>
        /// <para>Chat system identifier, used in part to uniquely identify chat. This is associated
        /// with the Amazon Connect instance and flow to be used to start chats. For Server Migration
        /// Service, this is the phone number destination of inbound Server Migration Service
        /// messages represented by an Amazon Web Services End User Messaging phone number ARN.</para>
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
        public System.String DestinationId { get; set; }
        #endregion
        
        #region Parameter ParticipantDetails_DisplayName
        /// <summary>
        /// <para>
        /// <para>Display name of the participant.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewSessionDetails_ParticipantDetails_DisplayName")]
        public System.String ParticipantDetails_DisplayName { get; set; }
        #endregion
        
        #region Parameter SourceId
        /// <summary>
        /// <para>
        /// <para>External identifier of chat customer participant, used in part to uniquely identify
        /// a chat. For SMS, this is the E164 phone number of the chat customer participant.</para>
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
        public System.String SourceId { get; set; }
        #endregion
        
        #region Parameter StreamingConfiguration_StreamingEndpointArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the standard Amazon SNS topic. The Amazon Resource
        /// Name (ARN) of the streaming endpoint that is used to publish real-time message streaming
        /// for chat conversations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewSessionDetails_StreamingConfiguration_StreamingEndpointArn")]
        public System.String StreamingConfiguration_StreamingEndpointArn { get; set; }
        #endregion
        
        #region Parameter Subtype
        /// <summary>
        /// <para>
        /// <para>Classification of a channel. This is used in part to uniquely identify chat. </para><para>Valid value: <c>["connect:sms", connect:"WhatsApp"]</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Subtype { get; set; }
        #endregion
        
        #region Parameter NewSessionDetails_SupportedMessagingContentType
        /// <summary>
        /// <para>
        /// <para> The supported chat message content types. Supported types are <c>text/plain</c>,
        /// <c>text/markdown</c>, <c>application/json</c>, <c>application/vnd.amazonaws.connect.message.interactive</c>,
        /// and <c>application/vnd.amazonaws.connect.message.interactive.response</c>. </para><para>Content types must always contain <c> text/plain</c>. You can then put any other supported
        /// type in the list. For example, all the following lists are valid because they contain
        /// <c>text/plain</c>: <c>[text/plain, text/markdown, application/json]</c>, <c> [text/markdown,
        /// text/plain]</c>, <c>[text/plain, application/json, application/vnd.amazonaws.connect.message.interactive.response]</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewSessionDetails_SupportedMessagingContentTypes")]
        public System.String[] NewSessionDetails_SupportedMessagingContentType { get; set; }
        #endregion
        
        #region Parameter Event_Type
        /// <summary>
        /// <para>
        /// <para>Type of chat integration event. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.ChatEventType")]
        public Amazon.Connect.ChatEventType Event_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.SendChatIntegrationEventResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.SendChatIntegrationEventResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-CONNChatIntegrationEvent (SendChatIntegrationEvent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.SendChatIntegrationEventResponse, SendCONNChatIntegrationEventCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DestinationId = this.DestinationId;
            #if MODULAR
            if (this.DestinationId == null && ParameterWasBound(nameof(this.DestinationId)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Event_Content = this.Event_Content;
            context.Event_ContentType = this.Event_ContentType;
            context.Event_Type = this.Event_Type;
            #if MODULAR
            if (this.Event_Type == null && ParameterWasBound(nameof(this.Event_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Event_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.NewSessionDetails_Attribute != null)
            {
                context.NewSessionDetails_Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.NewSessionDetails_Attribute.Keys)
                {
                    context.NewSessionDetails_Attribute.Add((String)hashKey, (System.String)(this.NewSessionDetails_Attribute[hashKey]));
                }
            }
            context.ParticipantDetails_DisplayName = this.ParticipantDetails_DisplayName;
            context.StreamingConfiguration_StreamingEndpointArn = this.StreamingConfiguration_StreamingEndpointArn;
            if (this.NewSessionDetails_SupportedMessagingContentType != null)
            {
                context.NewSessionDetails_SupportedMessagingContentType = new List<System.String>(this.NewSessionDetails_SupportedMessagingContentType);
            }
            context.SourceId = this.SourceId;
            #if MODULAR
            if (this.SourceId == null && ParameterWasBound(nameof(this.SourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Subtype = this.Subtype;
            
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
            var request = new Amazon.Connect.Model.SendChatIntegrationEventRequest();
            
            if (cmdletContext.DestinationId != null)
            {
                request.DestinationId = cmdletContext.DestinationId;
            }
            
             // populate Event
            var requestEventIsNull = true;
            request.Event = new Amazon.Connect.Model.ChatEvent();
            System.String requestEvent_event_Content = null;
            if (cmdletContext.Event_Content != null)
            {
                requestEvent_event_Content = cmdletContext.Event_Content;
            }
            if (requestEvent_event_Content != null)
            {
                request.Event.Content = requestEvent_event_Content;
                requestEventIsNull = false;
            }
            System.String requestEvent_event_ContentType = null;
            if (cmdletContext.Event_ContentType != null)
            {
                requestEvent_event_ContentType = cmdletContext.Event_ContentType;
            }
            if (requestEvent_event_ContentType != null)
            {
                request.Event.ContentType = requestEvent_event_ContentType;
                requestEventIsNull = false;
            }
            Amazon.Connect.ChatEventType requestEvent_event_Type = null;
            if (cmdletContext.Event_Type != null)
            {
                requestEvent_event_Type = cmdletContext.Event_Type;
            }
            if (requestEvent_event_Type != null)
            {
                request.Event.Type = requestEvent_event_Type;
                requestEventIsNull = false;
            }
             // determine if request.Event should be set to null
            if (requestEventIsNull)
            {
                request.Event = null;
            }
            
             // populate NewSessionDetails
            var requestNewSessionDetailsIsNull = true;
            request.NewSessionDetails = new Amazon.Connect.Model.NewSessionDetails();
            Dictionary<System.String, System.String> requestNewSessionDetails_newSessionDetails_Attribute = null;
            if (cmdletContext.NewSessionDetails_Attribute != null)
            {
                requestNewSessionDetails_newSessionDetails_Attribute = cmdletContext.NewSessionDetails_Attribute;
            }
            if (requestNewSessionDetails_newSessionDetails_Attribute != null)
            {
                request.NewSessionDetails.Attributes = requestNewSessionDetails_newSessionDetails_Attribute;
                requestNewSessionDetailsIsNull = false;
            }
            List<System.String> requestNewSessionDetails_newSessionDetails_SupportedMessagingContentType = null;
            if (cmdletContext.NewSessionDetails_SupportedMessagingContentType != null)
            {
                requestNewSessionDetails_newSessionDetails_SupportedMessagingContentType = cmdletContext.NewSessionDetails_SupportedMessagingContentType;
            }
            if (requestNewSessionDetails_newSessionDetails_SupportedMessagingContentType != null)
            {
                request.NewSessionDetails.SupportedMessagingContentTypes = requestNewSessionDetails_newSessionDetails_SupportedMessagingContentType;
                requestNewSessionDetailsIsNull = false;
            }
            Amazon.Connect.Model.ParticipantDetails requestNewSessionDetails_newSessionDetails_ParticipantDetails = null;
            
             // populate ParticipantDetails
            var requestNewSessionDetails_newSessionDetails_ParticipantDetailsIsNull = true;
            requestNewSessionDetails_newSessionDetails_ParticipantDetails = new Amazon.Connect.Model.ParticipantDetails();
            System.String requestNewSessionDetails_newSessionDetails_ParticipantDetails_participantDetails_DisplayName = null;
            if (cmdletContext.ParticipantDetails_DisplayName != null)
            {
                requestNewSessionDetails_newSessionDetails_ParticipantDetails_participantDetails_DisplayName = cmdletContext.ParticipantDetails_DisplayName;
            }
            if (requestNewSessionDetails_newSessionDetails_ParticipantDetails_participantDetails_DisplayName != null)
            {
                requestNewSessionDetails_newSessionDetails_ParticipantDetails.DisplayName = requestNewSessionDetails_newSessionDetails_ParticipantDetails_participantDetails_DisplayName;
                requestNewSessionDetails_newSessionDetails_ParticipantDetailsIsNull = false;
            }
             // determine if requestNewSessionDetails_newSessionDetails_ParticipantDetails should be set to null
            if (requestNewSessionDetails_newSessionDetails_ParticipantDetailsIsNull)
            {
                requestNewSessionDetails_newSessionDetails_ParticipantDetails = null;
            }
            if (requestNewSessionDetails_newSessionDetails_ParticipantDetails != null)
            {
                request.NewSessionDetails.ParticipantDetails = requestNewSessionDetails_newSessionDetails_ParticipantDetails;
                requestNewSessionDetailsIsNull = false;
            }
            Amazon.Connect.Model.ChatStreamingConfiguration requestNewSessionDetails_newSessionDetails_StreamingConfiguration = null;
            
             // populate StreamingConfiguration
            var requestNewSessionDetails_newSessionDetails_StreamingConfigurationIsNull = true;
            requestNewSessionDetails_newSessionDetails_StreamingConfiguration = new Amazon.Connect.Model.ChatStreamingConfiguration();
            System.String requestNewSessionDetails_newSessionDetails_StreamingConfiguration_streamingConfiguration_StreamingEndpointArn = null;
            if (cmdletContext.StreamingConfiguration_StreamingEndpointArn != null)
            {
                requestNewSessionDetails_newSessionDetails_StreamingConfiguration_streamingConfiguration_StreamingEndpointArn = cmdletContext.StreamingConfiguration_StreamingEndpointArn;
            }
            if (requestNewSessionDetails_newSessionDetails_StreamingConfiguration_streamingConfiguration_StreamingEndpointArn != null)
            {
                requestNewSessionDetails_newSessionDetails_StreamingConfiguration.StreamingEndpointArn = requestNewSessionDetails_newSessionDetails_StreamingConfiguration_streamingConfiguration_StreamingEndpointArn;
                requestNewSessionDetails_newSessionDetails_StreamingConfigurationIsNull = false;
            }
             // determine if requestNewSessionDetails_newSessionDetails_StreamingConfiguration should be set to null
            if (requestNewSessionDetails_newSessionDetails_StreamingConfigurationIsNull)
            {
                requestNewSessionDetails_newSessionDetails_StreamingConfiguration = null;
            }
            if (requestNewSessionDetails_newSessionDetails_StreamingConfiguration != null)
            {
                request.NewSessionDetails.StreamingConfiguration = requestNewSessionDetails_newSessionDetails_StreamingConfiguration;
                requestNewSessionDetailsIsNull = false;
            }
             // determine if request.NewSessionDetails should be set to null
            if (requestNewSessionDetailsIsNull)
            {
                request.NewSessionDetails = null;
            }
            if (cmdletContext.SourceId != null)
            {
                request.SourceId = cmdletContext.SourceId;
            }
            if (cmdletContext.Subtype != null)
            {
                request.Subtype = cmdletContext.Subtype;
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
        
        private Amazon.Connect.Model.SendChatIntegrationEventResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.SendChatIntegrationEventRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "SendChatIntegrationEvent");
            try
            {
                return client.SendChatIntegrationEventAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DestinationId { get; set; }
            public System.String Event_Content { get; set; }
            public System.String Event_ContentType { get; set; }
            public Amazon.Connect.ChatEventType Event_Type { get; set; }
            public Dictionary<System.String, System.String> NewSessionDetails_Attribute { get; set; }
            public System.String ParticipantDetails_DisplayName { get; set; }
            public System.String StreamingConfiguration_StreamingEndpointArn { get; set; }
            public List<System.String> NewSessionDetails_SupportedMessagingContentType { get; set; }
            public System.String SourceId { get; set; }
            public System.String Subtype { get; set; }
            public System.Func<Amazon.Connect.Model.SendChatIntegrationEventResponse, SendCONNChatIntegrationEventCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
