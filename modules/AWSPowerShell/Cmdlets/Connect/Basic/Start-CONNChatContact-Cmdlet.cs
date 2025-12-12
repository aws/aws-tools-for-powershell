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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Initiates a flow to start a new chat for the customer. Response of this API provides
    /// a token required to obtain credentials from the <a href="https://docs.aws.amazon.com/connect-participant/latest/APIReference/API_CreateParticipantConnection.html">CreateParticipantConnection</a>
    /// API in the Amazon Connect Participant Service.
    /// 
    ///  
    /// <para>
    /// When a new chat contact is successfully created, clients must subscribe to the participant’s
    /// connection for the created chat within 5 minutes. This is achieved by invoking <a href="https://docs.aws.amazon.com/connect-participant/latest/APIReference/API_CreateParticipantConnection.html">CreateParticipantConnection</a>
    /// with WEBSOCKET and CONNECTION_CREDENTIALS. 
    /// </para><para>
    /// A 429 error occurs in the following situations:
    /// </para><ul><li><para>
    /// API rate limit is exceeded. API TPS throttling returns a <c>TooManyRequests</c> exception.
    /// </para></li><li><para>
    /// The <a href="https://docs.aws.amazon.com/connect/latest/adminguide/amazon-connect-service-limits.html">quota
    /// for concurrent active chats</a> is exceeded. Active chat throttling returns a <c>LimitExceededException</c>.
    /// </para></li></ul><para>
    /// If you use the <c>ChatDurationInMinutes</c> parameter and receive a 400 error, your
    /// account may not support the ability to configure custom chat durations. For more information,
    /// contact Amazon Web Services Support. 
    /// </para><para>
    /// For more information about chat, see the following topics in the <i>Amazon Connect
    /// Administrator Guide</i>: 
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/connect/latest/adminguide/web-and-mobile-chat.html">Concepts:
    /// Web and mobile messaging capabilities in Amazon Connect</a></para></li><li><para><a href="https://docs.aws.amazon.com/connect/latest/adminguide/security-best-practices.html#bp-security-chat">Amazon
    /// Connect Chat security best practices</a></para></li></ul>
    /// </summary>
    [Cmdlet("Start", "CONNChatContact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.StartChatContactResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service StartChatContact API operation.", Operation = new[] {"StartChatContact"}, SelectReturnType = typeof(Amazon.Connect.Model.StartChatContactResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.StartChatContactResponse",
        "This cmdlet returns an Amazon.Connect.Model.StartChatContactResponse object containing multiple properties."
    )]
    public partial class StartCONNChatContactCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>A custom key-value pair using an attribute map. The attributes are standard Amazon
        /// Connect attributes. They can be accessed in flows just like any other contact attributes.
        /// </para><para>There can be up to 32,768 UTF-8 bytes across all key-value pairs per contact. Attribute
        /// keys can include only alphanumeric, dash, and underscore characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter ChatDurationInMinute
        /// <summary>
        /// <para>
        /// <para>The total duration of the newly started chat session. If not specified, the chat session
        /// duration defaults to 25 hour. The minimum configurable time is 60 minutes. The maximum
        /// configurable time is 10,080 minutes (7 days).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChatDurationInMinutes")]
        public System.Int32? ChatDurationInMinute { get; set; }
        #endregion
        
        #region Parameter ContactFlowId
        /// <summary>
        /// <para>
        /// <para>The identifier of the flow for initiating the chat. To see the ContactFlowId in the
        /// Amazon Connect admin website, on the navigation menu go to <b>Routing</b>, <b>Flows</b>.
        /// Choose the flow. On the flow page, under the name of the flow, choose <b>Show additional
        /// flow information</b>. The ContactFlowId is the last part of the ARN, shown here in
        /// bold: </para><para>arn:aws:connect:us-west-2:xxxxxxxxxxxx:instance/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/contact-flow/<b>846ec553-a005-41c0-8341-xxxxxxxxxxxx</b></para>
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
        public System.String ContactFlowId { get; set; }
        #endregion
        
        #region Parameter InitialMessage_Content
        /// <summary>
        /// <para>
        /// <para>The content of the chat message. </para><ul><li><para>For <c>text/plain</c> and <c>text/markdown</c>, the Length Constraints are Minimum
        /// of 1, Maximum of 1024. </para></li><li><para>For <c>application/json</c>, the Length Constraints are Minimum of 1, Maximum of 12000.
        /// </para></li><li><para>For <c>application/vnd.amazonaws.connect.message.interactive.response</c>, the Length
        /// Constraints are Minimum of 1, Maximum of 12288.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InitialMessage_Content { get; set; }
        #endregion
        
        #region Parameter InitialMessage_ContentType
        /// <summary>
        /// <para>
        /// <para>The type of the content. Supported types are <c>text/plain</c>, <c>text/markdown</c>,
        /// <c>application/json</c>, and <c>application/vnd.amazonaws.connect.message.interactive.response</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InitialMessage_ContentType { get; set; }
        #endregion
        
        #region Parameter CustomerId
        /// <summary>
        /// <para>
        /// <para>The customer's identification number. For example, the <c>CustomerId</c> may be a
        /// customer number from your CRM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomerId { get; set; }
        #endregion
        
        #region Parameter DisconnectOnCustomerExit
        /// <summary>
        /// <para>
        /// <para>A list of participant types to automatically disconnect when the end customer ends
        /// the chat session, allowing them to continue through disconnect flows such as surveys
        /// or feedback forms.</para><para>Valid value: <c>AGENT</c>.</para><para>With the <c>DisconnectOnCustomerExit</c> parameter, you can configure automatic agent
        /// disconnection when end customers end the chat, ensuring that disconnect flows are
        /// triggered consistently regardless of which participant disconnects first.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] DisconnectOnCustomerExit { get; set; }
        #endregion
        
        #region Parameter ParticipantDetails_DisplayName
        /// <summary>
        /// <para>
        /// <para>Display name of the participant.</para>
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
        public System.String ParticipantDetails_DisplayName { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter PersistentChat_RehydrationType
        /// <summary>
        /// <para>
        /// <para>The contactId that is used for rehydration depends on the rehydration type. RehydrationType
        /// is required for persistent chat. </para><ul><li><para><c>ENTIRE_PAST_SESSION</c>: Rehydrates a chat from the most recently terminated past
        /// chat contact of the specified past ended chat session. To use this type, provide the
        /// <c>initialContactId</c> of the past ended chat session in the <c>sourceContactId</c>
        /// field. In this type, Amazon Connect determines the most recent chat contact on the
        /// specified chat session that has ended, and uses it to start a persistent chat. </para></li><li><para><c>FROM_SEGMENT</c>: Rehydrates a chat from the past chat contact that is specified
        /// in the <c>sourceContactId</c> field. </para></li></ul><para>The actual contactId used for rehydration is provided in the response of this API.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.RehydrationType")]
        public Amazon.Connect.RehydrationType PersistentChat_RehydrationType { get; set; }
        #endregion
        
        #region Parameter RelatedContactId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for an Amazon Connect contact. This identifier is related to
        /// the chat starting.</para><note><para>You cannot provide data for both RelatedContactId and PersistentChat. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RelatedContactId { get; set; }
        #endregion
        
        #region Parameter ParticipantConfiguration_ResponseMode
        /// <summary>
        /// <para>
        /// <para> The mode in which responses should be sent to the participant. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.ResponseMode")]
        public Amazon.Connect.ResponseMode ParticipantConfiguration_ResponseMode { get; set; }
        #endregion
        
        #region Parameter SegmentAttribute
        /// <summary>
        /// <para>
        /// <para>A set of system defined key-value pairs stored on individual contact segments using
        /// an attribute map. The attributes are standard Amazon Connect attributes. They can
        /// be accessed in flows.</para><para>Attribute keys can include only alphanumeric, -, and _.</para><para>This field can be used to show channel subtype, such as <c>connect:Guide</c>.</para><note><para>The types <c>application/vnd.amazonaws.connect.message.interactive</c> and <c>application/vnd.amazonaws.connect.message.interactive.response</c>
        /// must be present in the SupportedMessagingContentTypes field of this API in order to
        /// set <c>SegmentAttributes</c> as {<c> "connect:Subtype": {"valueString" : "connect:Guide"
        /// }}</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SegmentAttributes")]
        public System.Collections.Hashtable SegmentAttribute { get; set; }
        #endregion
        
        #region Parameter PersistentChat_SourceContactId
        /// <summary>
        /// <para>
        /// <para>The contactId from which a persistent chat session must be started.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PersistentChat_SourceContactId { get; set; }
        #endregion
        
        #region Parameter SupportedMessagingContentType
        /// <summary>
        /// <para>
        /// <para>The supported chat message content types. Supported types are <c>text/plain</c>, <c>text/markdown</c>,
        /// <c>application/json</c>, <c>application/vnd.amazonaws.connect.message.interactive</c>,
        /// and <c>application/vnd.amazonaws.connect.message.interactive.response</c>. </para><para>Content types must always contain <c>text/plain</c>. You can then put any other supported
        /// type in the list. For example, all the following lists are valid because they contain
        /// <c>text/plain</c>: <c>[text/plain, text/markdown, application/json]</c>, <c>[text/markdown,
        /// text/plain]</c>, <c>[text/plain, application/json, application/vnd.amazonaws.connect.message.interactive.response]</c>.
        /// </para><note><para>The type <c>application/vnd.amazonaws.connect.message.interactive</c> is required
        /// to use the <a href="https://docs.aws.amazon.com/connect/latest/adminguide/show-view-block.html">Show
        /// view</a> flow block.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SupportedMessagingContentTypes")]
        public System.String[] SupportedMessagingContentType { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.StartChatContactResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.StartChatContactResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ContactFlowId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ContactFlowId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ContactFlowId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ContactFlowId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CONNChatContact (StartChatContact)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.StartChatContactResponse, StartCONNChatContactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ContactFlowId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Attribute != null)
            {
                context.Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attribute.Add((String)hashKey, (System.String)(this.Attribute[hashKey]));
                }
            }
            context.ChatDurationInMinute = this.ChatDurationInMinute;
            context.ClientToken = this.ClientToken;
            context.ContactFlowId = this.ContactFlowId;
            #if MODULAR
            if (this.ContactFlowId == null && ParameterWasBound(nameof(this.ContactFlowId)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactFlowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomerId = this.CustomerId;
            if (this.DisconnectOnCustomerExit != null)
            {
                context.DisconnectOnCustomerExit = new List<System.String>(this.DisconnectOnCustomerExit);
            }
            context.InitialMessage_Content = this.InitialMessage_Content;
            context.InitialMessage_ContentType = this.InitialMessage_ContentType;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ParticipantConfiguration_ResponseMode = this.ParticipantConfiguration_ResponseMode;
            context.ParticipantDetails_DisplayName = this.ParticipantDetails_DisplayName;
            #if MODULAR
            if (this.ParticipantDetails_DisplayName == null && ParameterWasBound(nameof(this.ParticipantDetails_DisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter ParticipantDetails_DisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PersistentChat_RehydrationType = this.PersistentChat_RehydrationType;
            context.PersistentChat_SourceContactId = this.PersistentChat_SourceContactId;
            context.RelatedContactId = this.RelatedContactId;
            if (this.SegmentAttribute != null)
            {
                context.SegmentAttribute = new Dictionary<System.String, Amazon.Connect.Model.SegmentAttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.SegmentAttribute.Keys)
                {
                    context.SegmentAttribute.Add((String)hashKey, (Amazon.Connect.Model.SegmentAttributeValue)(this.SegmentAttribute[hashKey]));
                }
            }
            if (this.SupportedMessagingContentType != null)
            {
                context.SupportedMessagingContentType = new List<System.String>(this.SupportedMessagingContentType);
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
            var request = new Amazon.Connect.Model.StartChatContactRequest();
            
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
            }
            if (cmdletContext.ChatDurationInMinute != null)
            {
                request.ChatDurationInMinutes = cmdletContext.ChatDurationInMinute.Value;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ContactFlowId != null)
            {
                request.ContactFlowId = cmdletContext.ContactFlowId;
            }
            if (cmdletContext.CustomerId != null)
            {
                request.CustomerId = cmdletContext.CustomerId;
            }
            if (cmdletContext.DisconnectOnCustomerExit != null)
            {
                request.DisconnectOnCustomerExit = cmdletContext.DisconnectOnCustomerExit;
            }
            
             // populate InitialMessage
            var requestInitialMessageIsNull = true;
            request.InitialMessage = new Amazon.Connect.Model.ChatMessage();
            System.String requestInitialMessage_initialMessage_Content = null;
            if (cmdletContext.InitialMessage_Content != null)
            {
                requestInitialMessage_initialMessage_Content = cmdletContext.InitialMessage_Content;
            }
            if (requestInitialMessage_initialMessage_Content != null)
            {
                request.InitialMessage.Content = requestInitialMessage_initialMessage_Content;
                requestInitialMessageIsNull = false;
            }
            System.String requestInitialMessage_initialMessage_ContentType = null;
            if (cmdletContext.InitialMessage_ContentType != null)
            {
                requestInitialMessage_initialMessage_ContentType = cmdletContext.InitialMessage_ContentType;
            }
            if (requestInitialMessage_initialMessage_ContentType != null)
            {
                request.InitialMessage.ContentType = requestInitialMessage_initialMessage_ContentType;
                requestInitialMessageIsNull = false;
            }
             // determine if request.InitialMessage should be set to null
            if (requestInitialMessageIsNull)
            {
                request.InitialMessage = null;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            
             // populate ParticipantConfiguration
            var requestParticipantConfigurationIsNull = true;
            request.ParticipantConfiguration = new Amazon.Connect.Model.ParticipantConfiguration();
            Amazon.Connect.ResponseMode requestParticipantConfiguration_participantConfiguration_ResponseMode = null;
            if (cmdletContext.ParticipantConfiguration_ResponseMode != null)
            {
                requestParticipantConfiguration_participantConfiguration_ResponseMode = cmdletContext.ParticipantConfiguration_ResponseMode;
            }
            if (requestParticipantConfiguration_participantConfiguration_ResponseMode != null)
            {
                request.ParticipantConfiguration.ResponseMode = requestParticipantConfiguration_participantConfiguration_ResponseMode;
                requestParticipantConfigurationIsNull = false;
            }
             // determine if request.ParticipantConfiguration should be set to null
            if (requestParticipantConfigurationIsNull)
            {
                request.ParticipantConfiguration = null;
            }
            
             // populate ParticipantDetails
            var requestParticipantDetailsIsNull = true;
            request.ParticipantDetails = new Amazon.Connect.Model.ParticipantDetails();
            System.String requestParticipantDetails_participantDetails_DisplayName = null;
            if (cmdletContext.ParticipantDetails_DisplayName != null)
            {
                requestParticipantDetails_participantDetails_DisplayName = cmdletContext.ParticipantDetails_DisplayName;
            }
            if (requestParticipantDetails_participantDetails_DisplayName != null)
            {
                request.ParticipantDetails.DisplayName = requestParticipantDetails_participantDetails_DisplayName;
                requestParticipantDetailsIsNull = false;
            }
             // determine if request.ParticipantDetails should be set to null
            if (requestParticipantDetailsIsNull)
            {
                request.ParticipantDetails = null;
            }
            
             // populate PersistentChat
            var requestPersistentChatIsNull = true;
            request.PersistentChat = new Amazon.Connect.Model.PersistentChat();
            Amazon.Connect.RehydrationType requestPersistentChat_persistentChat_RehydrationType = null;
            if (cmdletContext.PersistentChat_RehydrationType != null)
            {
                requestPersistentChat_persistentChat_RehydrationType = cmdletContext.PersistentChat_RehydrationType;
            }
            if (requestPersistentChat_persistentChat_RehydrationType != null)
            {
                request.PersistentChat.RehydrationType = requestPersistentChat_persistentChat_RehydrationType;
                requestPersistentChatIsNull = false;
            }
            System.String requestPersistentChat_persistentChat_SourceContactId = null;
            if (cmdletContext.PersistentChat_SourceContactId != null)
            {
                requestPersistentChat_persistentChat_SourceContactId = cmdletContext.PersistentChat_SourceContactId;
            }
            if (requestPersistentChat_persistentChat_SourceContactId != null)
            {
                request.PersistentChat.SourceContactId = requestPersistentChat_persistentChat_SourceContactId;
                requestPersistentChatIsNull = false;
            }
             // determine if request.PersistentChat should be set to null
            if (requestPersistentChatIsNull)
            {
                request.PersistentChat = null;
            }
            if (cmdletContext.RelatedContactId != null)
            {
                request.RelatedContactId = cmdletContext.RelatedContactId;
            }
            if (cmdletContext.SegmentAttribute != null)
            {
                request.SegmentAttributes = cmdletContext.SegmentAttribute;
            }
            if (cmdletContext.SupportedMessagingContentType != null)
            {
                request.SupportedMessagingContentTypes = cmdletContext.SupportedMessagingContentType;
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
        
        private Amazon.Connect.Model.StartChatContactResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.StartChatContactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "StartChatContact");
            try
            {
                #if DESKTOP
                return client.StartChatContact(request);
                #elif CORECLR
                return client.StartChatContactAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> Attribute { get; set; }
            public System.Int32? ChatDurationInMinute { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ContactFlowId { get; set; }
            public System.String CustomerId { get; set; }
            public List<System.String> DisconnectOnCustomerExit { get; set; }
            public System.String InitialMessage_Content { get; set; }
            public System.String InitialMessage_ContentType { get; set; }
            public System.String InstanceId { get; set; }
            public Amazon.Connect.ResponseMode ParticipantConfiguration_ResponseMode { get; set; }
            public System.String ParticipantDetails_DisplayName { get; set; }
            public Amazon.Connect.RehydrationType PersistentChat_RehydrationType { get; set; }
            public System.String PersistentChat_SourceContactId { get; set; }
            public System.String RelatedContactId { get; set; }
            public Dictionary<System.String, Amazon.Connect.Model.SegmentAttributeValue> SegmentAttribute { get; set; }
            public List<System.String> SupportedMessagingContentType { get; set; }
            public System.Func<Amazon.Connect.Model.StartChatContactResponse, StartCONNChatContactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
