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

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Creates an inbound email contact and initiates a flow to start the email contact for
    /// the customer. Response of this API provides the ContactId of the email contact created.
    /// </summary>
    [Cmdlet("Start", "CONNEmailContact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Connect Service StartEmailContact API operation.", Operation = new[] {"StartEmailContact"}, SelectReturnType = typeof(Amazon.Connect.Model.StartEmailContactResponse))]
    [AWSCmdletOutput("System.String or Amazon.Connect.Model.StartEmailContactResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Connect.Model.StartEmailContactResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartCONNEmailContactCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Attachment
        /// <summary>
        /// <para>
        /// <para>List of S3 presigned URLs of email attachments and their file name. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attachments")]
        public Amazon.Connect.Model.EmailAttachment[] Attachment { get; set; }
        #endregion
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>A custom key-value pair using an attribute map. The attributes are standard Amazon
        /// Connect attributes, and can be accessed in flows just like any other contact attributes.</para><para>There can be up to 32,768 UTF-8 bytes across all key-value pairs per contact. Attribute
        /// keys can include only alphanumeric, dash, and underscore characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter RawMessage_Body
        /// <summary>
        /// <para>
        /// <para>The email message body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EmailMessage_RawMessage_Body")]
        public System.String RawMessage_Body { get; set; }
        #endregion
        
        #region Parameter AdditionalRecipients_CcAddress
        /// <summary>
        /// <para>
        /// <para>The additional recipients information present in cc list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalRecipients_CcAddresses")]
        public Amazon.Connect.Model.EmailAddressInfo[] AdditionalRecipients_CcAddress { get; set; }
        #endregion
        
        #region Parameter ContactFlowId
        /// <summary>
        /// <para>
        /// <para>The identifier of the flow for initiating the emails. To see the ContactFlowId in
        /// the Amazon Connect admin website, on the navigation menu go to <b>Routing</b>, <b>Flows</b>.
        /// Choose the flow. On the flow page, under the name of the flow, choose <b>Show additional
        /// flow information</b>. The ContactFlowId is the last part of the ARN, shown here in
        /// bold: </para><para>arn:aws:connect:us-west-2:xxxxxxxxxxxx:instance/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/contact-flow/<b>846ec553-a005-41c0-8341-xxxxxxxxxxxx</b></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContactFlowId { get; set; }
        #endregion
        
        #region Parameter RawMessage_ContentType
        /// <summary>
        /// <para>
        /// <para>Type of content, that is, <c>text/plain</c> or <c>text/html</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EmailMessage_RawMessage_ContentType")]
        public System.String RawMessage_ContentType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the email contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DestinationEmailAddress
        /// <summary>
        /// <para>
        /// <para>The email address associated with the instance.</para>
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
        public System.String DestinationEmailAddress { get; set; }
        #endregion
        
        #region Parameter FromEmailAddress_DisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of email address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FromEmailAddress_DisplayName { get; set; }
        #endregion
        
        #region Parameter FromEmailAddress_EmailAddress
        /// <summary>
        /// <para>
        /// <para>The email address with the instance, in [^\s@]+@[^\s@]+\.[^\s@]+ format.</para>
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
        public System.String FromEmailAddress_EmailAddress { get; set; }
        #endregion
        
        #region Parameter RawMessage_Header
        /// <summary>
        /// <para>
        /// <para>Headers present in inbound email.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EmailMessage_RawMessage_Headers")]
        public System.Collections.Hashtable RawMessage_Header { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter EmailMessage_MessageSourceType
        /// <summary>
        /// <para>
        /// <para>The message source type, that is, <c>RAW</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.InboundMessageSourceType")]
        public Amazon.Connect.InboundMessageSourceType EmailMessage_MessageSourceType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of a email that is shown to an agent in the Contact Control Panel (CCP).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Reference
        /// <summary>
        /// <para>
        /// <para>A formatted URL that is shown to an agent in the Contact Control Panel (CCP). Emails
        /// can have the following reference types at the time of creation: <c>URL</c> | <c>NUMBER</c>
        /// | <c>STRING</c> | <c>DATE</c>. <c>EMAIL</c> | <c>EMAIL_MESSAGE</c> |<c>ATTACHMENT</c>
        /// are not a supported reference type during email creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("References")]
        public System.Collections.Hashtable Reference { get; set; }
        #endregion
        
        #region Parameter RelatedContactId
        /// <summary>
        /// <para>
        /// <para>The contactId that is related to this contact. Linking emails together by using <c>RelatedContactID</c>
        /// copies over contact attributes from the related email contact to the new email contact.
        /// All updates to user-defined attributes in the new email contact are limited to the
        /// individual contact ID. There are no limits to the number of contacts that can be linked
        /// by using <c>RelatedContactId</c>. </para>
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
        /// be accessed in flows.</para><para>Attribute keys can include only alphanumeric, -, and _.</para><para>This field can be used to show channel subtype, such as <c>connect:Guide</c>.</para><note><para>To set contact expiry, a <c>ValueMap</c> must be specified containing the integer
        /// number of minutes the contact will be active for before expiring, with <c>SegmentAttributes</c>
        /// like { <c> "connect:ContactExpiry": {"ValueMap" : { "ExpiryDuration": { "ValueInteger":135}}}}</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SegmentAttributes")]
        public System.Collections.Hashtable SegmentAttribute { get; set; }
        #endregion
        
        #region Parameter RawMessage_Subject
        /// <summary>
        /// <para>
        /// <para>The email subject.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EmailMessage_RawMessage_Subject")]
        public System.String RawMessage_Subject { get; set; }
        #endregion
        
        #region Parameter AdditionalRecipients_ToAddress
        /// <summary>
        /// <para>
        /// <para>The additional recipients information present in to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalRecipients_ToAddresses")]
        public Amazon.Connect.Model.EmailAddressInfo[] AdditionalRecipients_ToAddress { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContactId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.StartEmailContactResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.StartEmailContactResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CONNEmailContact (StartEmailContact)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.StartEmailContactResponse, StartCONNEmailContactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AdditionalRecipients_CcAddress != null)
            {
                context.AdditionalRecipients_CcAddress = new List<Amazon.Connect.Model.EmailAddressInfo>(this.AdditionalRecipients_CcAddress);
            }
            if (this.AdditionalRecipients_ToAddress != null)
            {
                context.AdditionalRecipients_ToAddress = new List<Amazon.Connect.Model.EmailAddressInfo>(this.AdditionalRecipients_ToAddress);
            }
            if (this.Attachment != null)
            {
                context.Attachment = new List<Amazon.Connect.Model.EmailAttachment>(this.Attachment);
            }
            if (this.Attribute != null)
            {
                context.Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attribute.Add((String)hashKey, (System.String)(this.Attribute[hashKey]));
                }
            }
            context.ClientToken = this.ClientToken;
            context.ContactFlowId = this.ContactFlowId;
            context.Description = this.Description;
            context.DestinationEmailAddress = this.DestinationEmailAddress;
            #if MODULAR
            if (this.DestinationEmailAddress == null && ParameterWasBound(nameof(this.DestinationEmailAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationEmailAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EmailMessage_MessageSourceType = this.EmailMessage_MessageSourceType;
            #if MODULAR
            if (this.EmailMessage_MessageSourceType == null && ParameterWasBound(nameof(this.EmailMessage_MessageSourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter EmailMessage_MessageSourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RawMessage_Body = this.RawMessage_Body;
            context.RawMessage_ContentType = this.RawMessage_ContentType;
            if (this.RawMessage_Header != null)
            {
                context.RawMessage_Header = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RawMessage_Header.Keys)
                {
                    context.RawMessage_Header.Add((String)hashKey, (System.String)(this.RawMessage_Header[hashKey]));
                }
            }
            context.RawMessage_Subject = this.RawMessage_Subject;
            context.FromEmailAddress_DisplayName = this.FromEmailAddress_DisplayName;
            context.FromEmailAddress_EmailAddress = this.FromEmailAddress_EmailAddress;
            #if MODULAR
            if (this.FromEmailAddress_EmailAddress == null && ParameterWasBound(nameof(this.FromEmailAddress_EmailAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter FromEmailAddress_EmailAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            if (this.Reference != null)
            {
                context.Reference = new Dictionary<System.String, Amazon.Connect.Model.Reference>(StringComparer.Ordinal);
                foreach (var hashKey in this.Reference.Keys)
                {
                    context.Reference.Add((String)hashKey, (Amazon.Connect.Model.Reference)(this.Reference[hashKey]));
                }
            }
            context.RelatedContactId = this.RelatedContactId;
            if (this.SegmentAttribute != null)
            {
                context.SegmentAttribute = new Dictionary<System.String, Amazon.Connect.Model.SegmentAttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.SegmentAttribute.Keys)
                {
                    context.SegmentAttribute.Add((String)hashKey, (Amazon.Connect.Model.SegmentAttributeValue)(this.SegmentAttribute[hashKey]));
                }
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
            var request = new Amazon.Connect.Model.StartEmailContactRequest();
            
            
             // populate AdditionalRecipients
            var requestAdditionalRecipientsIsNull = true;
            request.AdditionalRecipients = new Amazon.Connect.Model.InboundAdditionalRecipients();
            List<Amazon.Connect.Model.EmailAddressInfo> requestAdditionalRecipients_additionalRecipients_CcAddress = null;
            if (cmdletContext.AdditionalRecipients_CcAddress != null)
            {
                requestAdditionalRecipients_additionalRecipients_CcAddress = cmdletContext.AdditionalRecipients_CcAddress;
            }
            if (requestAdditionalRecipients_additionalRecipients_CcAddress != null)
            {
                request.AdditionalRecipients.CcAddresses = requestAdditionalRecipients_additionalRecipients_CcAddress;
                requestAdditionalRecipientsIsNull = false;
            }
            List<Amazon.Connect.Model.EmailAddressInfo> requestAdditionalRecipients_additionalRecipients_ToAddress = null;
            if (cmdletContext.AdditionalRecipients_ToAddress != null)
            {
                requestAdditionalRecipients_additionalRecipients_ToAddress = cmdletContext.AdditionalRecipients_ToAddress;
            }
            if (requestAdditionalRecipients_additionalRecipients_ToAddress != null)
            {
                request.AdditionalRecipients.ToAddresses = requestAdditionalRecipients_additionalRecipients_ToAddress;
                requestAdditionalRecipientsIsNull = false;
            }
             // determine if request.AdditionalRecipients should be set to null
            if (requestAdditionalRecipientsIsNull)
            {
                request.AdditionalRecipients = null;
            }
            if (cmdletContext.Attachment != null)
            {
                request.Attachments = cmdletContext.Attachment;
            }
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ContactFlowId != null)
            {
                request.ContactFlowId = cmdletContext.ContactFlowId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DestinationEmailAddress != null)
            {
                request.DestinationEmailAddress = cmdletContext.DestinationEmailAddress;
            }
            
             // populate EmailMessage
            var requestEmailMessageIsNull = true;
            request.EmailMessage = new Amazon.Connect.Model.InboundEmailContent();
            Amazon.Connect.InboundMessageSourceType requestEmailMessage_emailMessage_MessageSourceType = null;
            if (cmdletContext.EmailMessage_MessageSourceType != null)
            {
                requestEmailMessage_emailMessage_MessageSourceType = cmdletContext.EmailMessage_MessageSourceType;
            }
            if (requestEmailMessage_emailMessage_MessageSourceType != null)
            {
                request.EmailMessage.MessageSourceType = requestEmailMessage_emailMessage_MessageSourceType;
                requestEmailMessageIsNull = false;
            }
            Amazon.Connect.Model.InboundRawMessage requestEmailMessage_emailMessage_RawMessage = null;
            
             // populate RawMessage
            var requestEmailMessage_emailMessage_RawMessageIsNull = true;
            requestEmailMessage_emailMessage_RawMessage = new Amazon.Connect.Model.InboundRawMessage();
            System.String requestEmailMessage_emailMessage_RawMessage_rawMessage_Body = null;
            if (cmdletContext.RawMessage_Body != null)
            {
                requestEmailMessage_emailMessage_RawMessage_rawMessage_Body = cmdletContext.RawMessage_Body;
            }
            if (requestEmailMessage_emailMessage_RawMessage_rawMessage_Body != null)
            {
                requestEmailMessage_emailMessage_RawMessage.Body = requestEmailMessage_emailMessage_RawMessage_rawMessage_Body;
                requestEmailMessage_emailMessage_RawMessageIsNull = false;
            }
            System.String requestEmailMessage_emailMessage_RawMessage_rawMessage_ContentType = null;
            if (cmdletContext.RawMessage_ContentType != null)
            {
                requestEmailMessage_emailMessage_RawMessage_rawMessage_ContentType = cmdletContext.RawMessage_ContentType;
            }
            if (requestEmailMessage_emailMessage_RawMessage_rawMessage_ContentType != null)
            {
                requestEmailMessage_emailMessage_RawMessage.ContentType = requestEmailMessage_emailMessage_RawMessage_rawMessage_ContentType;
                requestEmailMessage_emailMessage_RawMessageIsNull = false;
            }
            Dictionary<System.String, System.String> requestEmailMessage_emailMessage_RawMessage_rawMessage_Header = null;
            if (cmdletContext.RawMessage_Header != null)
            {
                requestEmailMessage_emailMessage_RawMessage_rawMessage_Header = cmdletContext.RawMessage_Header;
            }
            if (requestEmailMessage_emailMessage_RawMessage_rawMessage_Header != null)
            {
                requestEmailMessage_emailMessage_RawMessage.Headers = requestEmailMessage_emailMessage_RawMessage_rawMessage_Header;
                requestEmailMessage_emailMessage_RawMessageIsNull = false;
            }
            System.String requestEmailMessage_emailMessage_RawMessage_rawMessage_Subject = null;
            if (cmdletContext.RawMessage_Subject != null)
            {
                requestEmailMessage_emailMessage_RawMessage_rawMessage_Subject = cmdletContext.RawMessage_Subject;
            }
            if (requestEmailMessage_emailMessage_RawMessage_rawMessage_Subject != null)
            {
                requestEmailMessage_emailMessage_RawMessage.Subject = requestEmailMessage_emailMessage_RawMessage_rawMessage_Subject;
                requestEmailMessage_emailMessage_RawMessageIsNull = false;
            }
             // determine if requestEmailMessage_emailMessage_RawMessage should be set to null
            if (requestEmailMessage_emailMessage_RawMessageIsNull)
            {
                requestEmailMessage_emailMessage_RawMessage = null;
            }
            if (requestEmailMessage_emailMessage_RawMessage != null)
            {
                request.EmailMessage.RawMessage = requestEmailMessage_emailMessage_RawMessage;
                requestEmailMessageIsNull = false;
            }
             // determine if request.EmailMessage should be set to null
            if (requestEmailMessageIsNull)
            {
                request.EmailMessage = null;
            }
            
             // populate FromEmailAddress
            var requestFromEmailAddressIsNull = true;
            request.FromEmailAddress = new Amazon.Connect.Model.EmailAddressInfo();
            System.String requestFromEmailAddress_fromEmailAddress_DisplayName = null;
            if (cmdletContext.FromEmailAddress_DisplayName != null)
            {
                requestFromEmailAddress_fromEmailAddress_DisplayName = cmdletContext.FromEmailAddress_DisplayName;
            }
            if (requestFromEmailAddress_fromEmailAddress_DisplayName != null)
            {
                request.FromEmailAddress.DisplayName = requestFromEmailAddress_fromEmailAddress_DisplayName;
                requestFromEmailAddressIsNull = false;
            }
            System.String requestFromEmailAddress_fromEmailAddress_EmailAddress = null;
            if (cmdletContext.FromEmailAddress_EmailAddress != null)
            {
                requestFromEmailAddress_fromEmailAddress_EmailAddress = cmdletContext.FromEmailAddress_EmailAddress;
            }
            if (requestFromEmailAddress_fromEmailAddress_EmailAddress != null)
            {
                request.FromEmailAddress.EmailAddress = requestFromEmailAddress_fromEmailAddress_EmailAddress;
                requestFromEmailAddressIsNull = false;
            }
             // determine if request.FromEmailAddress should be set to null
            if (requestFromEmailAddressIsNull)
            {
                request.FromEmailAddress = null;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Reference != null)
            {
                request.References = cmdletContext.Reference;
            }
            if (cmdletContext.RelatedContactId != null)
            {
                request.RelatedContactId = cmdletContext.RelatedContactId;
            }
            if (cmdletContext.SegmentAttribute != null)
            {
                request.SegmentAttributes = cmdletContext.SegmentAttribute;
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
        
        private Amazon.Connect.Model.StartEmailContactResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.StartEmailContactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "StartEmailContact");
            try
            {
                return client.StartEmailContactAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Connect.Model.EmailAddressInfo> AdditionalRecipients_CcAddress { get; set; }
            public List<Amazon.Connect.Model.EmailAddressInfo> AdditionalRecipients_ToAddress { get; set; }
            public List<Amazon.Connect.Model.EmailAttachment> Attachment { get; set; }
            public Dictionary<System.String, System.String> Attribute { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ContactFlowId { get; set; }
            public System.String Description { get; set; }
            public System.String DestinationEmailAddress { get; set; }
            public Amazon.Connect.InboundMessageSourceType EmailMessage_MessageSourceType { get; set; }
            public System.String RawMessage_Body { get; set; }
            public System.String RawMessage_ContentType { get; set; }
            public Dictionary<System.String, System.String> RawMessage_Header { get; set; }
            public System.String RawMessage_Subject { get; set; }
            public System.String FromEmailAddress_DisplayName { get; set; }
            public System.String FromEmailAddress_EmailAddress { get; set; }
            public System.String InstanceId { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, Amazon.Connect.Model.Reference> Reference { get; set; }
            public System.String RelatedContactId { get; set; }
            public Dictionary<System.String, Amazon.Connect.Model.SegmentAttributeValue> SegmentAttribute { get; set; }
            public System.Func<Amazon.Connect.Model.StartEmailContactResponse, StartCONNEmailContactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContactId;
        }
        
    }
}
