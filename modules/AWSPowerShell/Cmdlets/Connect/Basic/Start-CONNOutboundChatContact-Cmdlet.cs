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
    /// Initiates a new outbound SMS contact to a customer. Response of this API provides
    /// the <c>ContactId</c> of the outbound SMS contact created.
    /// 
    ///  
    /// <para><b>SourceEndpoint</b> only supports Endpoints with <c>CONNECT_PHONENUMBER_ARN</c>
    /// as Type and <b>DestinationEndpoint</b> only supports Endpoints with <c>TELEPHONE_NUMBER</c>
    /// as Type. <b>ContactFlowId</b> initiates the flow to manage the new SMS contact created.
    /// </para><para>
    /// This API can be used to initiate outbound SMS contacts for an agent, or it can also
    /// deflect an ongoing contact to an outbound SMS contact by using the <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_StartOutboundChatContact.html">StartOutboundChatContact</a>
    /// Flow Action.
    /// </para><para>
    /// For more information about using SMS in Amazon Connect, see the following topics in
    /// the <i>Amazon Connect Administrator Guide</i>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/connect/latest/adminguide/setup-sms-messaging.html">Set
    /// up SMS messaging</a></para></li><li><para><a href="https://docs.aws.amazon.com/connect/latest/adminguide/sms-number.html">Request
    /// an SMS-enabled phone number through AWS End User Messaging SMS</a></para></li></ul>
    /// </summary>
    [Cmdlet("Start", "CONNOutboundChatContact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Connect Service StartOutboundChatContact API operation.", Operation = new[] {"StartOutboundChatContact"}, SelectReturnType = typeof(Amazon.Connect.Model.StartOutboundChatContactResponse))]
    [AWSCmdletOutput("System.String or Amazon.Connect.Model.StartOutboundChatContactResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Connect.Model.StartOutboundChatContactResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartCONNOutboundChatContactCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DestinationEndpoint_Address
        /// <summary>
        /// <para>
        /// <para>Address of the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationEndpoint_Address { get; set; }
        #endregion
        
        #region Parameter SourceEndpoint_Address
        /// <summary>
        /// <para>
        /// <para>Address of the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceEndpoint_Address { get; set; }
        #endregion
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>A custom key-value pair using an attribute map. The attributes are standard Amazon
        /// Connect attributes, and can be accessed in flows just like any other contact attributes.</para>
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
        /// <para>The identifier of the flow for the call. To see the ContactFlowId in the Amazon Connect
        /// console user interface, on the navigation menu go to <b>Routing, Contact Flows</b>.
        /// Choose the flow. On the flow page, under the name of the flow, choose <b>Show additional
        /// flow information</b>. The ContactFlowId is the last part of the ARN, shown here in
        /// bold:</para><ul><li><para>arn:aws:connect:us-west-2:xxxxxxxxxxxx:instance/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/contact-flow/<b>123ec456-a007-89c0-1234-xxxxxxxxxxxx</b></para></li></ul>
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
        public System.String ContactFlowId { get; set; }
        #endregion
        
        #region Parameter InitialSystemMessage_Content
        /// <summary>
        /// <para>
        /// <para>The content of the chat message. </para><ul><li><para>For <c>text/plain</c> and <c>text/markdown</c>, the Length Constraints are Minimum
        /// of 1, Maximum of 1024. </para></li><li><para>For <c>application/json</c>, the Length Constraints are Minimum of 1, Maximum of 12000.
        /// </para></li><li><para>For <c>application/vnd.amazonaws.connect.message.interactive.response</c>, the Length
        /// Constraints are Minimum of 1, Maximum of 12288.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InitialSystemMessage_Content { get; set; }
        #endregion
        
        #region Parameter InitialSystemMessage_ContentType
        /// <summary>
        /// <para>
        /// <para>The type of the content. Supported types are <c>text/plain</c>, <c>text/markdown</c>,
        /// <c>application/json</c>, and <c>application/vnd.amazonaws.connect.message.interactive.response</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InitialSystemMessage_ContentType { get; set; }
        #endregion
        
        #region Parameter TemplateAttributes_CustomAttribute
        /// <summary>
        /// <para>
        /// <para>An object that specifies the custom attributes values to use for variables in the
        /// message template. This object contains different categories of key-value pairs. Each
        /// key defines a variable or placeholder in the message template. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InitialTemplatedSystemMessage_TemplateAttributes_CustomAttributes")]
        public System.Collections.Hashtable TemplateAttributes_CustomAttribute { get; set; }
        #endregion
        
        #region Parameter TemplateAttributes_CustomerProfileAttribute
        /// <summary>
        /// <para>
        /// <para>An object that specifies the customer profile attributes values to use for variables
        /// in the message template. This object contains different categories of key-value pairs.
        /// Each key defines a variable or placeholder in the message template. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InitialTemplatedSystemMessage_TemplateAttributes_CustomerProfileAttributes")]
        public System.String TemplateAttributes_CustomerProfileAttribute { get; set; }
        #endregion
        
        #region Parameter ParticipantDetails_DisplayName
        /// <summary>
        /// <para>
        /// <para>Display name of the participant.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParticipantDetails_DisplayName { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can find the instance ID in the
        /// Amazon Resource Name (ARN) of the instance.</para>
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
        
        #region Parameter InitialTemplatedSystemMessage_KnowledgeBaseId
        /// <summary>
        /// <para>
        /// <para>The identifier of the knowledge base. Can be either the ID or the ARN. URLs cannot
        /// contain the ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InitialTemplatedSystemMessage_KnowledgeBaseId { get; set; }
        #endregion
        
        #region Parameter InitialTemplatedSystemMessage_MessageTemplateId
        /// <summary>
        /// <para>
        /// <para>The identifier of the message template Id.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InitialTemplatedSystemMessage_MessageTemplateId { get; set; }
        #endregion
        
        #region Parameter RelatedContactId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for an Amazon Connect contact. This identifier is related to
        /// the contact starting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RelatedContactId { get; set; }
        #endregion
        
        #region Parameter SegmentAttribute
        /// <summary>
        /// <para>
        /// <para>A set of system defined key-value pairs stored on individual contact segments using
        /// an attribute map. The attributes are standard Amazon Connect attributes. They can
        /// be accessed in flows.</para><ul><li><para>Attribute keys can include only alphanumeric, <c>-</c>, and <c>_</c>.</para></li><li><para>This field can be used to show channel subtype, such as <c>connect:Guide</c> and <c>connect:SMS</c>.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SegmentAttributes")]
        public System.Collections.Hashtable SegmentAttribute { get; set; }
        #endregion
        
        #region Parameter SupportedMessagingContentType
        /// <summary>
        /// <para>
        /// <para>The supported chat message content types. Supported types are:</para><ul><li><para><c>text/plain</c></para></li><li><para><c>text/markdown</c></para></li><li><para><c>application/json, application/vnd.amazonaws.connect.message.interactive</c></para></li><li><para><c>application/vnd.amazonaws.connect.message.interactive.response</c></para></li></ul><para>Content types must always contain <c>text/plain</c>. You can then put any other supported
        /// type in the list. For example, all the following lists are valid because they contain
        /// <c>text/plain</c>:</para><ul><li><para><c>[text/plain, text/markdown, application/json]</c></para></li><li><para><c>[text/markdown, text/plain]</c></para></li><li><para><c>[text/plain, application/json, application/vnd.amazonaws.connect.message.interactive.response]</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SupportedMessagingContentTypes")]
        public System.String[] SupportedMessagingContentType { get; set; }
        #endregion
        
        #region Parameter DestinationEndpoint_Type
        /// <summary>
        /// <para>
        /// <para>Type of the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.EndpointType")]
        public Amazon.Connect.EndpointType DestinationEndpoint_Type { get; set; }
        #endregion
        
        #region Parameter SourceEndpoint_Type
        /// <summary>
        /// <para>
        /// <para>Type of the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.EndpointType")]
        public Amazon.Connect.EndpointType SourceEndpoint_Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the AWS SDK populates this field. For more information
        /// about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>. The token is valid for 7 days after creation.
        /// If a contact is already started, the contact ID is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContactId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.StartOutboundChatContactResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.StartOutboundChatContactResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContactId";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CONNOutboundChatContact (StartOutboundChatContact)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.StartOutboundChatContactResponse, StartCONNOutboundChatContactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.DestinationEndpoint_Address = this.DestinationEndpoint_Address;
            context.DestinationEndpoint_Type = this.DestinationEndpoint_Type;
            context.InitialSystemMessage_Content = this.InitialSystemMessage_Content;
            context.InitialSystemMessage_ContentType = this.InitialSystemMessage_ContentType;
            context.InitialTemplatedSystemMessage_KnowledgeBaseId = this.InitialTemplatedSystemMessage_KnowledgeBaseId;
            context.InitialTemplatedSystemMessage_MessageTemplateId = this.InitialTemplatedSystemMessage_MessageTemplateId;
            if (this.TemplateAttributes_CustomAttribute != null)
            {
                context.TemplateAttributes_CustomAttribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.TemplateAttributes_CustomAttribute.Keys)
                {
                    context.TemplateAttributes_CustomAttribute.Add((String)hashKey, (System.String)(this.TemplateAttributes_CustomAttribute[hashKey]));
                }
            }
            context.TemplateAttributes_CustomerProfileAttribute = this.TemplateAttributes_CustomerProfileAttribute;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ParticipantDetails_DisplayName = this.ParticipantDetails_DisplayName;
            context.RelatedContactId = this.RelatedContactId;
            if (this.SegmentAttribute != null)
            {
                context.SegmentAttribute = new Dictionary<System.String, Amazon.Connect.Model.SegmentAttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.SegmentAttribute.Keys)
                {
                    context.SegmentAttribute.Add((String)hashKey, (Amazon.Connect.Model.SegmentAttributeValue)(this.SegmentAttribute[hashKey]));
                }
            }
            #if MODULAR
            if (this.SegmentAttribute == null && ParameterWasBound(nameof(this.SegmentAttribute)))
            {
                WriteWarning("You are passing $null as a value for parameter SegmentAttribute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceEndpoint_Address = this.SourceEndpoint_Address;
            context.SourceEndpoint_Type = this.SourceEndpoint_Type;
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
            var request = new Amazon.Connect.Model.StartOutboundChatContactRequest();
            
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
            
             // populate DestinationEndpoint
            var requestDestinationEndpointIsNull = true;
            request.DestinationEndpoint = new Amazon.Connect.Model.Endpoint();
            System.String requestDestinationEndpoint_destinationEndpoint_Address = null;
            if (cmdletContext.DestinationEndpoint_Address != null)
            {
                requestDestinationEndpoint_destinationEndpoint_Address = cmdletContext.DestinationEndpoint_Address;
            }
            if (requestDestinationEndpoint_destinationEndpoint_Address != null)
            {
                request.DestinationEndpoint.Address = requestDestinationEndpoint_destinationEndpoint_Address;
                requestDestinationEndpointIsNull = false;
            }
            Amazon.Connect.EndpointType requestDestinationEndpoint_destinationEndpoint_Type = null;
            if (cmdletContext.DestinationEndpoint_Type != null)
            {
                requestDestinationEndpoint_destinationEndpoint_Type = cmdletContext.DestinationEndpoint_Type;
            }
            if (requestDestinationEndpoint_destinationEndpoint_Type != null)
            {
                request.DestinationEndpoint.Type = requestDestinationEndpoint_destinationEndpoint_Type;
                requestDestinationEndpointIsNull = false;
            }
             // determine if request.DestinationEndpoint should be set to null
            if (requestDestinationEndpointIsNull)
            {
                request.DestinationEndpoint = null;
            }
            
             // populate InitialSystemMessage
            var requestInitialSystemMessageIsNull = true;
            request.InitialSystemMessage = new Amazon.Connect.Model.ChatMessage();
            System.String requestInitialSystemMessage_initialSystemMessage_Content = null;
            if (cmdletContext.InitialSystemMessage_Content != null)
            {
                requestInitialSystemMessage_initialSystemMessage_Content = cmdletContext.InitialSystemMessage_Content;
            }
            if (requestInitialSystemMessage_initialSystemMessage_Content != null)
            {
                request.InitialSystemMessage.Content = requestInitialSystemMessage_initialSystemMessage_Content;
                requestInitialSystemMessageIsNull = false;
            }
            System.String requestInitialSystemMessage_initialSystemMessage_ContentType = null;
            if (cmdletContext.InitialSystemMessage_ContentType != null)
            {
                requestInitialSystemMessage_initialSystemMessage_ContentType = cmdletContext.InitialSystemMessage_ContentType;
            }
            if (requestInitialSystemMessage_initialSystemMessage_ContentType != null)
            {
                request.InitialSystemMessage.ContentType = requestInitialSystemMessage_initialSystemMessage_ContentType;
                requestInitialSystemMessageIsNull = false;
            }
             // determine if request.InitialSystemMessage should be set to null
            if (requestInitialSystemMessageIsNull)
            {
                request.InitialSystemMessage = null;
            }
            
             // populate InitialTemplatedSystemMessage
            var requestInitialTemplatedSystemMessageIsNull = true;
            request.InitialTemplatedSystemMessage = new Amazon.Connect.Model.TemplatedMessageConfig();
            System.String requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_KnowledgeBaseId = null;
            if (cmdletContext.InitialTemplatedSystemMessage_KnowledgeBaseId != null)
            {
                requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_KnowledgeBaseId = cmdletContext.InitialTemplatedSystemMessage_KnowledgeBaseId;
            }
            if (requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_KnowledgeBaseId != null)
            {
                request.InitialTemplatedSystemMessage.KnowledgeBaseId = requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_KnowledgeBaseId;
                requestInitialTemplatedSystemMessageIsNull = false;
            }
            System.String requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_MessageTemplateId = null;
            if (cmdletContext.InitialTemplatedSystemMessage_MessageTemplateId != null)
            {
                requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_MessageTemplateId = cmdletContext.InitialTemplatedSystemMessage_MessageTemplateId;
            }
            if (requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_MessageTemplateId != null)
            {
                request.InitialTemplatedSystemMessage.MessageTemplateId = requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_MessageTemplateId;
                requestInitialTemplatedSystemMessageIsNull = false;
            }
            Amazon.Connect.Model.TemplateAttributes requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_TemplateAttributes = null;
            
             // populate TemplateAttributes
            var requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_TemplateAttributesIsNull = true;
            requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_TemplateAttributes = new Amazon.Connect.Model.TemplateAttributes();
            Dictionary<System.String, System.String> requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_TemplateAttributes_templateAttributes_CustomAttribute = null;
            if (cmdletContext.TemplateAttributes_CustomAttribute != null)
            {
                requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_TemplateAttributes_templateAttributes_CustomAttribute = cmdletContext.TemplateAttributes_CustomAttribute;
            }
            if (requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_TemplateAttributes_templateAttributes_CustomAttribute != null)
            {
                requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_TemplateAttributes.CustomAttributes = requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_TemplateAttributes_templateAttributes_CustomAttribute;
                requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_TemplateAttributesIsNull = false;
            }
            System.String requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_TemplateAttributes_templateAttributes_CustomerProfileAttribute = null;
            if (cmdletContext.TemplateAttributes_CustomerProfileAttribute != null)
            {
                requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_TemplateAttributes_templateAttributes_CustomerProfileAttribute = cmdletContext.TemplateAttributes_CustomerProfileAttribute;
            }
            if (requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_TemplateAttributes_templateAttributes_CustomerProfileAttribute != null)
            {
                requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_TemplateAttributes.CustomerProfileAttributes = requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_TemplateAttributes_templateAttributes_CustomerProfileAttribute;
                requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_TemplateAttributesIsNull = false;
            }
             // determine if requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_TemplateAttributes should be set to null
            if (requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_TemplateAttributesIsNull)
            {
                requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_TemplateAttributes = null;
            }
            if (requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_TemplateAttributes != null)
            {
                request.InitialTemplatedSystemMessage.TemplateAttributes = requestInitialTemplatedSystemMessage_initialTemplatedSystemMessage_TemplateAttributes;
                requestInitialTemplatedSystemMessageIsNull = false;
            }
             // determine if request.InitialTemplatedSystemMessage should be set to null
            if (requestInitialTemplatedSystemMessageIsNull)
            {
                request.InitialTemplatedSystemMessage = null;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
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
            if (cmdletContext.RelatedContactId != null)
            {
                request.RelatedContactId = cmdletContext.RelatedContactId;
            }
            if (cmdletContext.SegmentAttribute != null)
            {
                request.SegmentAttributes = cmdletContext.SegmentAttribute;
            }
            
             // populate SourceEndpoint
            var requestSourceEndpointIsNull = true;
            request.SourceEndpoint = new Amazon.Connect.Model.Endpoint();
            System.String requestSourceEndpoint_sourceEndpoint_Address = null;
            if (cmdletContext.SourceEndpoint_Address != null)
            {
                requestSourceEndpoint_sourceEndpoint_Address = cmdletContext.SourceEndpoint_Address;
            }
            if (requestSourceEndpoint_sourceEndpoint_Address != null)
            {
                request.SourceEndpoint.Address = requestSourceEndpoint_sourceEndpoint_Address;
                requestSourceEndpointIsNull = false;
            }
            Amazon.Connect.EndpointType requestSourceEndpoint_sourceEndpoint_Type = null;
            if (cmdletContext.SourceEndpoint_Type != null)
            {
                requestSourceEndpoint_sourceEndpoint_Type = cmdletContext.SourceEndpoint_Type;
            }
            if (requestSourceEndpoint_sourceEndpoint_Type != null)
            {
                request.SourceEndpoint.Type = requestSourceEndpoint_sourceEndpoint_Type;
                requestSourceEndpointIsNull = false;
            }
             // determine if request.SourceEndpoint should be set to null
            if (requestSourceEndpointIsNull)
            {
                request.SourceEndpoint = null;
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
        
        private Amazon.Connect.Model.StartOutboundChatContactResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.StartOutboundChatContactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "StartOutboundChatContact");
            try
            {
                #if DESKTOP
                return client.StartOutboundChatContact(request);
                #elif CORECLR
                return client.StartOutboundChatContactAsync(request).GetAwaiter().GetResult();
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
            public System.String DestinationEndpoint_Address { get; set; }
            public Amazon.Connect.EndpointType DestinationEndpoint_Type { get; set; }
            public System.String InitialSystemMessage_Content { get; set; }
            public System.String InitialSystemMessage_ContentType { get; set; }
            public System.String InitialTemplatedSystemMessage_KnowledgeBaseId { get; set; }
            public System.String InitialTemplatedSystemMessage_MessageTemplateId { get; set; }
            public Dictionary<System.String, System.String> TemplateAttributes_CustomAttribute { get; set; }
            public System.String TemplateAttributes_CustomerProfileAttribute { get; set; }
            public System.String InstanceId { get; set; }
            public System.String ParticipantDetails_DisplayName { get; set; }
            public System.String RelatedContactId { get; set; }
            public Dictionary<System.String, Amazon.Connect.Model.SegmentAttributeValue> SegmentAttribute { get; set; }
            public System.String SourceEndpoint_Address { get; set; }
            public Amazon.Connect.EndpointType SourceEndpoint_Type { get; set; }
            public List<System.String> SupportedMessagingContentType { get; set; }
            public System.Func<Amazon.Connect.Model.StartOutboundChatContactResponse, StartCONNOutboundChatContactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContactId;
        }
        
    }
}
