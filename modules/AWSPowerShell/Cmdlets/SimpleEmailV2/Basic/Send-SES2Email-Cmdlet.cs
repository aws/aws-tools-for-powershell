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
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SES2
{
    /// <summary>
    /// Sends an email message. You can use the Amazon SES API v2 to send the following types
    /// of messages:
    /// 
    ///  <ul><li><para><b>Simple</b> – A standard email message. When you create this type of message, you
    /// specify the sender, the recipient, and the message body, and Amazon SES assembles
    /// the message for you.
    /// </para></li><li><para><b>Raw</b> – A raw, MIME-formatted email message. When you send this type of email,
    /// you have to specify all of the message headers, as well as the message body. You can
    /// use this message type to send messages that contain attachments. The message that
    /// you specify has to be a valid MIME message.
    /// </para></li><li><para><b>Templated</b> – A message that contains personalization tags. When you send this
    /// type of email, Amazon SES API v2 automatically replaces the tags with values that
    /// you specify.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Send", "SES2Email", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) SendEmail API operation.", Operation = new[] {"SendEmail"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.SendEmailResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleEmailV2.Model.SendEmailResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SimpleEmailV2.Model.SendEmailResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SendSES2EmailCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Simple_Attachment
        /// <summary>
        /// <para>
        /// <para> The List of attachments to include in your email. All recipients will receive the
        /// same attachments.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Simple_Attachments")]
        public Amazon.SimpleEmailV2.Model.Attachment[] Simple_Attachment { get; set; }
        #endregion
        
        #region Parameter Template_Attachment
        /// <summary>
        /// <para>
        /// <para> The List of attachments to include in your email. All recipients will receive the
        /// same attachments.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Template_Attachments")]
        public Amazon.SimpleEmailV2.Model.Attachment[] Template_Attachment { get; set; }
        #endregion
        
        #region Parameter Destination_BccAddress
        /// <summary>
        /// <para>
        /// <para>An array that contains the email addresses of the "BCC" (blind carbon copy) recipients
        /// for the email.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Destination_BccAddresses")]
        public System.String[] Destination_BccAddress { get; set; }
        #endregion
        
        #region Parameter Destination_CcAddress
        /// <summary>
        /// <para>
        /// <para>An array that contains the email addresses of the "CC" (carbon copy) recipients for
        /// the email.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Destination_CcAddresses")]
        public System.String[] Destination_CcAddress { get; set; }
        #endregion
        
        #region Parameter Html_Charset
        /// <summary>
        /// <para>
        /// <para>The character set for the content. Because of the constraints of the SMTP protocol,
        /// Amazon SES uses 7-bit ASCII by default. If the text includes characters outside of
        /// the ASCII range, you have to specify a character set. For example, you could specify
        /// <c>UTF-8</c>, <c>ISO-8859-1</c>, or <c>Shift_JIS</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Simple_Body_Html_Charset")]
        public System.String Html_Charset { get; set; }
        #endregion
        
        #region Parameter Text_Charset
        /// <summary>
        /// <para>
        /// <para>The character set for the content. Because of the constraints of the SMTP protocol,
        /// Amazon SES uses 7-bit ASCII by default. If the text includes characters outside of
        /// the ASCII range, you have to specify a character set. For example, you could specify
        /// <c>UTF-8</c>, <c>ISO-8859-1</c>, or <c>Shift_JIS</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Simple_Body_Text_Charset")]
        public System.String Text_Charset { get; set; }
        #endregion
        
        #region Parameter Subject_Charset
        /// <summary>
        /// <para>
        /// <para>The character set for the content. Because of the constraints of the SMTP protocol,
        /// Amazon SES uses 7-bit ASCII by default. If the text includes characters outside of
        /// the ASCII range, you have to specify a character set. For example, you could specify
        /// <c>UTF-8</c>, <c>ISO-8859-1</c>, or <c>Shift_JIS</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Simple_Subject_Charset")]
        public System.String Subject_Charset { get; set; }
        #endregion
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set to use when sending the email.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationSetName { get; set; }
        #endregion
        
        #region Parameter ListManagementOptions_ContactListName
        /// <summary>
        /// <para>
        /// <para>The name of the contact list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ListManagementOptions_ContactListName { get; set; }
        #endregion
        
        #region Parameter Raw_Data
        /// <summary>
        /// <para>
        /// <para>The raw email message. The message has to meet the following criteria:</para><ul><li><para>The message has to contain a header and a body, separated by one blank line.</para></li><li><para>All of the required header fields must be present in the message.</para></li><li><para>Each part of a multipart MIME message must be formatted properly.</para></li><li><para>Attachments must be in a file format that the Amazon SES supports.</para></li><li><para>The raw data of the message needs to base64-encoded if you are accessing Amazon SES
        /// directly through the HTTPS interface. If you are accessing Amazon SES using an Amazon
        /// Web Services SDK, the SDK takes care of the base 64-encoding for you.</para></li><li><para>If any of the MIME parts in your message contain content that is outside of the 7-bit
        /// ASCII character range, you should encode that content to ensure that recipients' email
        /// clients render the message properly.</para></li><li><para>The length of any single line of text in the message can't exceed 1,000 characters.
        /// This restriction is defined in <a href="https://tools.ietf.org/html/rfc5321">RFC 5321</a>.</para></li></ul>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Raw_Data")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Raw_Data { get; set; }
        #endregion
        
        #region Parameter Html_Data
        /// <summary>
        /// <para>
        /// <para>The content of the message itself.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Simple_Body_Html_Data")]
        public System.String Html_Data { get; set; }
        #endregion
        
        #region Parameter Text_Data
        /// <summary>
        /// <para>
        /// <para>The content of the message itself.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Simple_Body_Text_Data")]
        public System.String Text_Data { get; set; }
        #endregion
        
        #region Parameter Subject_Data
        /// <summary>
        /// <para>
        /// <para>The content of the message itself.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Simple_Subject_Data")]
        public System.String Subject_Data { get; set; }
        #endregion
        
        #region Parameter EmailTag
        /// <summary>
        /// <para>
        /// <para>A list of tags, in the form of name/value pairs, to apply to an email that you send
        /// using the <c>SendEmail</c> operation. Tags correspond to characteristics of the email
        /// that you define, so that you can publish email sending events. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EmailTags")]
        public Amazon.SimpleEmailV2.Model.MessageTag[] EmailTag { get; set; }
        #endregion
        
        #region Parameter EndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the multi-region endpoint (global-endpoint).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointId { get; set; }
        #endregion
        
        #region Parameter FeedbackForwardingEmailAddress
        /// <summary>
        /// <para>
        /// <para>The address that you want bounce and complaint notifications to be sent to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FeedbackForwardingEmailAddress { get; set; }
        #endregion
        
        #region Parameter FeedbackForwardingEmailAddressIdentityArn
        /// <summary>
        /// <para>
        /// <para>This parameter is used only for sending authorization. It is the ARN of the identity
        /// that is associated with the sending authorization policy that permits you to use the
        /// email address specified in the <c>FeedbackForwardingEmailAddress</c> parameter.</para><para>For example, if the owner of example.com (which has ARN arn:aws:ses:us-east-1:123456789012:identity/example.com)
        /// attaches a policy to it that authorizes you to use feedback@example.com, then you
        /// would specify the <c>FeedbackForwardingEmailAddressIdentityArn</c> to be arn:aws:ses:us-east-1:123456789012:identity/example.com,
        /// and the <c>FeedbackForwardingEmailAddress</c> to be feedback@example.com.</para><para>For more information about sending authorization, see the <a href="https://docs.aws.amazon.com/ses/latest/DeveloperGuide/sending-authorization.html">Amazon
        /// SES Developer Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FeedbackForwardingEmailAddressIdentityArn { get; set; }
        #endregion
        
        #region Parameter FromEmailAddress
        /// <summary>
        /// <para>
        /// <para>The email address to use as the "From" address for the email. The address that you
        /// specify has to be verified. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FromEmailAddress { get; set; }
        #endregion
        
        #region Parameter FromEmailAddressIdentityArn
        /// <summary>
        /// <para>
        /// <para>This parameter is used only for sending authorization. It is the ARN of the identity
        /// that is associated with the sending authorization policy that permits you to use the
        /// email address specified in the <c>FromEmailAddress</c> parameter.</para><para>For example, if the owner of example.com (which has ARN arn:aws:ses:us-east-1:123456789012:identity/example.com)
        /// attaches a policy to it that authorizes you to use sender@example.com, then you would
        /// specify the <c>FromEmailAddressIdentityArn</c> to be arn:aws:ses:us-east-1:123456789012:identity/example.com,
        /// and the <c>FromEmailAddress</c> to be sender@example.com.</para><para>For more information about sending authorization, see the <a href="https://docs.aws.amazon.com/ses/latest/DeveloperGuide/sending-authorization.html">Amazon
        /// SES Developer Guide</a>.</para><para>For Raw emails, the <c>FromEmailAddressIdentityArn</c> value overrides the X-SES-SOURCE-ARN
        /// and X-SES-FROM-ARN headers specified in raw email message content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FromEmailAddressIdentityArn { get; set; }
        #endregion
        
        #region Parameter Simple_Header
        /// <summary>
        /// <para>
        /// <para>The list of message headers that will be added to the email message.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Simple_Headers")]
        public Amazon.SimpleEmailV2.Model.MessageHeader[] Simple_Header { get; set; }
        #endregion
        
        #region Parameter Template_Header
        /// <summary>
        /// <para>
        /// <para>The list of message headers that will be added to the email message.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Template_Headers")]
        public Amazon.SimpleEmailV2.Model.MessageHeader[] Template_Header { get; set; }
        #endregion
        
        #region Parameter TemplateContent_Html
        /// <summary>
        /// <para>
        /// <para>The HTML body of the email.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Template_TemplateContent_Html")]
        public System.String TemplateContent_Html { get; set; }
        #endregion
        
        #region Parameter ReplyToAddress
        /// <summary>
        /// <para>
        /// <para>The "Reply-to" email addresses for the message. When the recipient replies to the
        /// message, each Reply-to address receives the reply.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReplyToAddresses")]
        public System.String[] ReplyToAddress { get; set; }
        #endregion
        
        #region Parameter TemplateContent_Subject
        /// <summary>
        /// <para>
        /// <para>The subject line of the email.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Template_TemplateContent_Subject")]
        public System.String TemplateContent_Subject { get; set; }
        #endregion
        
        #region Parameter Template_TemplateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Template_TemplateArn")]
        public System.String Template_TemplateArn { get; set; }
        #endregion
        
        #region Parameter Template_TemplateData
        /// <summary>
        /// <para>
        /// <para>An object that defines the values to use for message variables in the template. This
        /// object is a set of key-value pairs. Each key defines a message variable in the template.
        /// The corresponding value defines the value to use for that variable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Template_TemplateData")]
        public System.String Template_TemplateData { get; set; }
        #endregion
        
        #region Parameter Template_TemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the template. You will refer to this name when you send email using the
        /// <c>SendEmail</c> or <c>SendBulkEmail</c> operations. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Template_TemplateName")]
        public System.String Template_TemplateName { get; set; }
        #endregion
        
        #region Parameter TenantName
        /// <summary>
        /// <para>
        /// <para>The name of the tenant through which this email will be sent.</para><note><para>The email sending operation will only succeed if all referenced resources (identities,
        /// configuration sets, and templates) are associated with this tenant. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TenantName { get; set; }
        #endregion
        
        #region Parameter TemplateContent_Text
        /// <summary>
        /// <para>
        /// <para>The email body that will be visible to recipients whose email clients do not display
        /// HTML.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Template_TemplateContent_Text")]
        public System.String TemplateContent_Text { get; set; }
        #endregion
        
        #region Parameter Destination_ToAddress
        /// <summary>
        /// <para>
        /// <para>An array that contains the email addresses of the "To" recipients for the email.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Destination_ToAddresses")]
        public System.String[] Destination_ToAddress { get; set; }
        #endregion
        
        #region Parameter ListManagementOptions_TopicName
        /// <summary>
        /// <para>
        /// <para>The name of the topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ListManagementOptions_TopicName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MessageId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.SendEmailResponse).
        /// Specifying the name of a property of type Amazon.SimpleEmailV2.Model.SendEmailResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MessageId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigurationSetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SES2Email (SendEmail)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.SendEmailResponse, SendSES2EmailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationSetName = this.ConfigurationSetName;
            context.Raw_Data = this.Raw_Data;
            if (this.Simple_Attachment != null)
            {
                context.Simple_Attachment = new List<Amazon.SimpleEmailV2.Model.Attachment>(this.Simple_Attachment);
            }
            context.Html_Charset = this.Html_Charset;
            context.Html_Data = this.Html_Data;
            context.Text_Charset = this.Text_Charset;
            context.Text_Data = this.Text_Data;
            if (this.Simple_Header != null)
            {
                context.Simple_Header = new List<Amazon.SimpleEmailV2.Model.MessageHeader>(this.Simple_Header);
            }
            context.Subject_Charset = this.Subject_Charset;
            context.Subject_Data = this.Subject_Data;
            if (this.Template_Attachment != null)
            {
                context.Template_Attachment = new List<Amazon.SimpleEmailV2.Model.Attachment>(this.Template_Attachment);
            }
            if (this.Template_Header != null)
            {
                context.Template_Header = new List<Amazon.SimpleEmailV2.Model.MessageHeader>(this.Template_Header);
            }
            context.Template_TemplateArn = this.Template_TemplateArn;
            context.TemplateContent_Html = this.TemplateContent_Html;
            context.TemplateContent_Subject = this.TemplateContent_Subject;
            context.TemplateContent_Text = this.TemplateContent_Text;
            context.Template_TemplateData = this.Template_TemplateData;
            context.Template_TemplateName = this.Template_TemplateName;
            if (this.Destination_BccAddress != null)
            {
                context.Destination_BccAddress = new List<System.String>(this.Destination_BccAddress);
            }
            if (this.Destination_CcAddress != null)
            {
                context.Destination_CcAddress = new List<System.String>(this.Destination_CcAddress);
            }
            if (this.Destination_ToAddress != null)
            {
                context.Destination_ToAddress = new List<System.String>(this.Destination_ToAddress);
            }
            if (this.EmailTag != null)
            {
                context.EmailTag = new List<Amazon.SimpleEmailV2.Model.MessageTag>(this.EmailTag);
            }
            context.EndpointId = this.EndpointId;
            context.FeedbackForwardingEmailAddress = this.FeedbackForwardingEmailAddress;
            context.FeedbackForwardingEmailAddressIdentityArn = this.FeedbackForwardingEmailAddressIdentityArn;
            context.FromEmailAddress = this.FromEmailAddress;
            context.FromEmailAddressIdentityArn = this.FromEmailAddressIdentityArn;
            context.ListManagementOptions_ContactListName = this.ListManagementOptions_ContactListName;
            context.ListManagementOptions_TopicName = this.ListManagementOptions_TopicName;
            if (this.ReplyToAddress != null)
            {
                context.ReplyToAddress = new List<System.String>(this.ReplyToAddress);
            }
            context.TenantName = this.TenantName;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _Raw_DataStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.SimpleEmailV2.Model.SendEmailRequest();
                
                if (cmdletContext.ConfigurationSetName != null)
                {
                    request.ConfigurationSetName = cmdletContext.ConfigurationSetName;
                }
                
                 // populate Content
                var requestContentIsNull = true;
                request.Content = new Amazon.SimpleEmailV2.Model.EmailContent();
                Amazon.SimpleEmailV2.Model.RawMessage requestContent_content_Raw = null;
                
                 // populate Raw
                var requestContent_content_RawIsNull = true;
                requestContent_content_Raw = new Amazon.SimpleEmailV2.Model.RawMessage();
                System.IO.MemoryStream requestContent_content_Raw_raw_Data = null;
                if (cmdletContext.Raw_Data != null)
                {
                    _Raw_DataStream = new System.IO.MemoryStream(cmdletContext.Raw_Data);
                    requestContent_content_Raw_raw_Data = _Raw_DataStream;
                }
                if (requestContent_content_Raw_raw_Data != null)
                {
                    requestContent_content_Raw.Data = requestContent_content_Raw_raw_Data;
                    requestContent_content_RawIsNull = false;
                }
                 // determine if requestContent_content_Raw should be set to null
                if (requestContent_content_RawIsNull)
                {
                    requestContent_content_Raw = null;
                }
                if (requestContent_content_Raw != null)
                {
                    request.Content.Raw = requestContent_content_Raw;
                    requestContentIsNull = false;
                }
                Amazon.SimpleEmailV2.Model.Message requestContent_content_Simple = null;
                
                 // populate Simple
                var requestContent_content_SimpleIsNull = true;
                requestContent_content_Simple = new Amazon.SimpleEmailV2.Model.Message();
                List<Amazon.SimpleEmailV2.Model.Attachment> requestContent_content_Simple_simple_Attachment = null;
                if (cmdletContext.Simple_Attachment != null)
                {
                    requestContent_content_Simple_simple_Attachment = cmdletContext.Simple_Attachment;
                }
                if (requestContent_content_Simple_simple_Attachment != null)
                {
                    requestContent_content_Simple.Attachments = requestContent_content_Simple_simple_Attachment;
                    requestContent_content_SimpleIsNull = false;
                }
                List<Amazon.SimpleEmailV2.Model.MessageHeader> requestContent_content_Simple_simple_Header = null;
                if (cmdletContext.Simple_Header != null)
                {
                    requestContent_content_Simple_simple_Header = cmdletContext.Simple_Header;
                }
                if (requestContent_content_Simple_simple_Header != null)
                {
                    requestContent_content_Simple.Headers = requestContent_content_Simple_simple_Header;
                    requestContent_content_SimpleIsNull = false;
                }
                Amazon.SimpleEmailV2.Model.Body requestContent_content_Simple_content_Simple_Body = null;
                
                 // populate Body
                var requestContent_content_Simple_content_Simple_BodyIsNull = true;
                requestContent_content_Simple_content_Simple_Body = new Amazon.SimpleEmailV2.Model.Body();
                Amazon.SimpleEmailV2.Model.Content requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html = null;
                
                 // populate Html
                var requestContent_content_Simple_content_Simple_Body_content_Simple_Body_HtmlIsNull = true;
                requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html = new Amazon.SimpleEmailV2.Model.Content();
                System.String requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Charset = null;
                if (cmdletContext.Html_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Charset = cmdletContext.Html_Charset;
                }
                if (requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html.Charset = requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Charset;
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_HtmlIsNull = false;
                }
                System.String requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Data = null;
                if (cmdletContext.Html_Data != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Data = cmdletContext.Html_Data;
                }
                if (requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Data != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html.Data = requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Data;
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_HtmlIsNull = false;
                }
                 // determine if requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html should be set to null
                if (requestContent_content_Simple_content_Simple_Body_content_Simple_Body_HtmlIsNull)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html = null;
                }
                if (requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html != null)
                {
                    requestContent_content_Simple_content_Simple_Body.Html = requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html;
                    requestContent_content_Simple_content_Simple_BodyIsNull = false;
                }
                Amazon.SimpleEmailV2.Model.Content requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text = null;
                
                 // populate Text
                var requestContent_content_Simple_content_Simple_Body_content_Simple_Body_TextIsNull = true;
                requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text = new Amazon.SimpleEmailV2.Model.Content();
                System.String requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Charset = null;
                if (cmdletContext.Text_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Charset = cmdletContext.Text_Charset;
                }
                if (requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text.Charset = requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Charset;
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_TextIsNull = false;
                }
                System.String requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Data = null;
                if (cmdletContext.Text_Data != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Data = cmdletContext.Text_Data;
                }
                if (requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Data != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text.Data = requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Data;
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_TextIsNull = false;
                }
                 // determine if requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text should be set to null
                if (requestContent_content_Simple_content_Simple_Body_content_Simple_Body_TextIsNull)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text = null;
                }
                if (requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text != null)
                {
                    requestContent_content_Simple_content_Simple_Body.Text = requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text;
                    requestContent_content_Simple_content_Simple_BodyIsNull = false;
                }
                 // determine if requestContent_content_Simple_content_Simple_Body should be set to null
                if (requestContent_content_Simple_content_Simple_BodyIsNull)
                {
                    requestContent_content_Simple_content_Simple_Body = null;
                }
                if (requestContent_content_Simple_content_Simple_Body != null)
                {
                    requestContent_content_Simple.Body = requestContent_content_Simple_content_Simple_Body;
                    requestContent_content_SimpleIsNull = false;
                }
                Amazon.SimpleEmailV2.Model.Content requestContent_content_Simple_content_Simple_Subject = null;
                
                 // populate Subject
                var requestContent_content_Simple_content_Simple_SubjectIsNull = true;
                requestContent_content_Simple_content_Simple_Subject = new Amazon.SimpleEmailV2.Model.Content();
                System.String requestContent_content_Simple_content_Simple_Subject_subject_Charset = null;
                if (cmdletContext.Subject_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Subject_subject_Charset = cmdletContext.Subject_Charset;
                }
                if (requestContent_content_Simple_content_Simple_Subject_subject_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Subject.Charset = requestContent_content_Simple_content_Simple_Subject_subject_Charset;
                    requestContent_content_Simple_content_Simple_SubjectIsNull = false;
                }
                System.String requestContent_content_Simple_content_Simple_Subject_subject_Data = null;
                if (cmdletContext.Subject_Data != null)
                {
                    requestContent_content_Simple_content_Simple_Subject_subject_Data = cmdletContext.Subject_Data;
                }
                if (requestContent_content_Simple_content_Simple_Subject_subject_Data != null)
                {
                    requestContent_content_Simple_content_Simple_Subject.Data = requestContent_content_Simple_content_Simple_Subject_subject_Data;
                    requestContent_content_Simple_content_Simple_SubjectIsNull = false;
                }
                 // determine if requestContent_content_Simple_content_Simple_Subject should be set to null
                if (requestContent_content_Simple_content_Simple_SubjectIsNull)
                {
                    requestContent_content_Simple_content_Simple_Subject = null;
                }
                if (requestContent_content_Simple_content_Simple_Subject != null)
                {
                    requestContent_content_Simple.Subject = requestContent_content_Simple_content_Simple_Subject;
                    requestContent_content_SimpleIsNull = false;
                }
                 // determine if requestContent_content_Simple should be set to null
                if (requestContent_content_SimpleIsNull)
                {
                    requestContent_content_Simple = null;
                }
                if (requestContent_content_Simple != null)
                {
                    request.Content.Simple = requestContent_content_Simple;
                    requestContentIsNull = false;
                }
                Amazon.SimpleEmailV2.Model.Template requestContent_content_Template = null;
                
                 // populate Template
                var requestContent_content_TemplateIsNull = true;
                requestContent_content_Template = new Amazon.SimpleEmailV2.Model.Template();
                List<Amazon.SimpleEmailV2.Model.Attachment> requestContent_content_Template_template_Attachment = null;
                if (cmdletContext.Template_Attachment != null)
                {
                    requestContent_content_Template_template_Attachment = cmdletContext.Template_Attachment;
                }
                if (requestContent_content_Template_template_Attachment != null)
                {
                    requestContent_content_Template.Attachments = requestContent_content_Template_template_Attachment;
                    requestContent_content_TemplateIsNull = false;
                }
                List<Amazon.SimpleEmailV2.Model.MessageHeader> requestContent_content_Template_template_Header = null;
                if (cmdletContext.Template_Header != null)
                {
                    requestContent_content_Template_template_Header = cmdletContext.Template_Header;
                }
                if (requestContent_content_Template_template_Header != null)
                {
                    requestContent_content_Template.Headers = requestContent_content_Template_template_Header;
                    requestContent_content_TemplateIsNull = false;
                }
                System.String requestContent_content_Template_template_TemplateArn = null;
                if (cmdletContext.Template_TemplateArn != null)
                {
                    requestContent_content_Template_template_TemplateArn = cmdletContext.Template_TemplateArn;
                }
                if (requestContent_content_Template_template_TemplateArn != null)
                {
                    requestContent_content_Template.TemplateArn = requestContent_content_Template_template_TemplateArn;
                    requestContent_content_TemplateIsNull = false;
                }
                System.String requestContent_content_Template_template_TemplateData = null;
                if (cmdletContext.Template_TemplateData != null)
                {
                    requestContent_content_Template_template_TemplateData = cmdletContext.Template_TemplateData;
                }
                if (requestContent_content_Template_template_TemplateData != null)
                {
                    requestContent_content_Template.TemplateData = requestContent_content_Template_template_TemplateData;
                    requestContent_content_TemplateIsNull = false;
                }
                System.String requestContent_content_Template_template_TemplateName = null;
                if (cmdletContext.Template_TemplateName != null)
                {
                    requestContent_content_Template_template_TemplateName = cmdletContext.Template_TemplateName;
                }
                if (requestContent_content_Template_template_TemplateName != null)
                {
                    requestContent_content_Template.TemplateName = requestContent_content_Template_template_TemplateName;
                    requestContent_content_TemplateIsNull = false;
                }
                Amazon.SimpleEmailV2.Model.EmailTemplateContent requestContent_content_Template_content_Template_TemplateContent = null;
                
                 // populate TemplateContent
                var requestContent_content_Template_content_Template_TemplateContentIsNull = true;
                requestContent_content_Template_content_Template_TemplateContent = new Amazon.SimpleEmailV2.Model.EmailTemplateContent();
                System.String requestContent_content_Template_content_Template_TemplateContent_templateContent_Html = null;
                if (cmdletContext.TemplateContent_Html != null)
                {
                    requestContent_content_Template_content_Template_TemplateContent_templateContent_Html = cmdletContext.TemplateContent_Html;
                }
                if (requestContent_content_Template_content_Template_TemplateContent_templateContent_Html != null)
                {
                    requestContent_content_Template_content_Template_TemplateContent.Html = requestContent_content_Template_content_Template_TemplateContent_templateContent_Html;
                    requestContent_content_Template_content_Template_TemplateContentIsNull = false;
                }
                System.String requestContent_content_Template_content_Template_TemplateContent_templateContent_Subject = null;
                if (cmdletContext.TemplateContent_Subject != null)
                {
                    requestContent_content_Template_content_Template_TemplateContent_templateContent_Subject = cmdletContext.TemplateContent_Subject;
                }
                if (requestContent_content_Template_content_Template_TemplateContent_templateContent_Subject != null)
                {
                    requestContent_content_Template_content_Template_TemplateContent.Subject = requestContent_content_Template_content_Template_TemplateContent_templateContent_Subject;
                    requestContent_content_Template_content_Template_TemplateContentIsNull = false;
                }
                System.String requestContent_content_Template_content_Template_TemplateContent_templateContent_Text = null;
                if (cmdletContext.TemplateContent_Text != null)
                {
                    requestContent_content_Template_content_Template_TemplateContent_templateContent_Text = cmdletContext.TemplateContent_Text;
                }
                if (requestContent_content_Template_content_Template_TemplateContent_templateContent_Text != null)
                {
                    requestContent_content_Template_content_Template_TemplateContent.Text = requestContent_content_Template_content_Template_TemplateContent_templateContent_Text;
                    requestContent_content_Template_content_Template_TemplateContentIsNull = false;
                }
                 // determine if requestContent_content_Template_content_Template_TemplateContent should be set to null
                if (requestContent_content_Template_content_Template_TemplateContentIsNull)
                {
                    requestContent_content_Template_content_Template_TemplateContent = null;
                }
                if (requestContent_content_Template_content_Template_TemplateContent != null)
                {
                    requestContent_content_Template.TemplateContent = requestContent_content_Template_content_Template_TemplateContent;
                    requestContent_content_TemplateIsNull = false;
                }
                 // determine if requestContent_content_Template should be set to null
                if (requestContent_content_TemplateIsNull)
                {
                    requestContent_content_Template = null;
                }
                if (requestContent_content_Template != null)
                {
                    request.Content.Template = requestContent_content_Template;
                    requestContentIsNull = false;
                }
                 // determine if request.Content should be set to null
                if (requestContentIsNull)
                {
                    request.Content = null;
                }
                
                 // populate Destination
                var requestDestinationIsNull = true;
                request.Destination = new Amazon.SimpleEmailV2.Model.Destination();
                List<System.String> requestDestination_destination_BccAddress = null;
                if (cmdletContext.Destination_BccAddress != null)
                {
                    requestDestination_destination_BccAddress = cmdletContext.Destination_BccAddress;
                }
                if (requestDestination_destination_BccAddress != null)
                {
                    request.Destination.BccAddresses = requestDestination_destination_BccAddress;
                    requestDestinationIsNull = false;
                }
                List<System.String> requestDestination_destination_CcAddress = null;
                if (cmdletContext.Destination_CcAddress != null)
                {
                    requestDestination_destination_CcAddress = cmdletContext.Destination_CcAddress;
                }
                if (requestDestination_destination_CcAddress != null)
                {
                    request.Destination.CcAddresses = requestDestination_destination_CcAddress;
                    requestDestinationIsNull = false;
                }
                List<System.String> requestDestination_destination_ToAddress = null;
                if (cmdletContext.Destination_ToAddress != null)
                {
                    requestDestination_destination_ToAddress = cmdletContext.Destination_ToAddress;
                }
                if (requestDestination_destination_ToAddress != null)
                {
                    request.Destination.ToAddresses = requestDestination_destination_ToAddress;
                    requestDestinationIsNull = false;
                }
                 // determine if request.Destination should be set to null
                if (requestDestinationIsNull)
                {
                    request.Destination = null;
                }
                if (cmdletContext.EmailTag != null)
                {
                    request.EmailTags = cmdletContext.EmailTag;
                }
                if (cmdletContext.EndpointId != null)
                {
                    request.EndpointId = cmdletContext.EndpointId;
                }
                if (cmdletContext.FeedbackForwardingEmailAddress != null)
                {
                    request.FeedbackForwardingEmailAddress = cmdletContext.FeedbackForwardingEmailAddress;
                }
                if (cmdletContext.FeedbackForwardingEmailAddressIdentityArn != null)
                {
                    request.FeedbackForwardingEmailAddressIdentityArn = cmdletContext.FeedbackForwardingEmailAddressIdentityArn;
                }
                if (cmdletContext.FromEmailAddress != null)
                {
                    request.FromEmailAddress = cmdletContext.FromEmailAddress;
                }
                if (cmdletContext.FromEmailAddressIdentityArn != null)
                {
                    request.FromEmailAddressIdentityArn = cmdletContext.FromEmailAddressIdentityArn;
                }
                
                 // populate ListManagementOptions
                var requestListManagementOptionsIsNull = true;
                request.ListManagementOptions = new Amazon.SimpleEmailV2.Model.ListManagementOptions();
                System.String requestListManagementOptions_listManagementOptions_ContactListName = null;
                if (cmdletContext.ListManagementOptions_ContactListName != null)
                {
                    requestListManagementOptions_listManagementOptions_ContactListName = cmdletContext.ListManagementOptions_ContactListName;
                }
                if (requestListManagementOptions_listManagementOptions_ContactListName != null)
                {
                    request.ListManagementOptions.ContactListName = requestListManagementOptions_listManagementOptions_ContactListName;
                    requestListManagementOptionsIsNull = false;
                }
                System.String requestListManagementOptions_listManagementOptions_TopicName = null;
                if (cmdletContext.ListManagementOptions_TopicName != null)
                {
                    requestListManagementOptions_listManagementOptions_TopicName = cmdletContext.ListManagementOptions_TopicName;
                }
                if (requestListManagementOptions_listManagementOptions_TopicName != null)
                {
                    request.ListManagementOptions.TopicName = requestListManagementOptions_listManagementOptions_TopicName;
                    requestListManagementOptionsIsNull = false;
                }
                 // determine if request.ListManagementOptions should be set to null
                if (requestListManagementOptionsIsNull)
                {
                    request.ListManagementOptions = null;
                }
                if (cmdletContext.ReplyToAddress != null)
                {
                    request.ReplyToAddresses = cmdletContext.ReplyToAddress;
                }
                if (cmdletContext.TenantName != null)
                {
                    request.TenantName = cmdletContext.TenantName;
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
                if( _Raw_DataStream != null)
                {
                    _Raw_DataStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SimpleEmailV2.Model.SendEmailResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.SendEmailRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "SendEmail");
            try
            {
                return client.SendEmailAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConfigurationSetName { get; set; }
            public byte[] Raw_Data { get; set; }
            public List<Amazon.SimpleEmailV2.Model.Attachment> Simple_Attachment { get; set; }
            public System.String Html_Charset { get; set; }
            public System.String Html_Data { get; set; }
            public System.String Text_Charset { get; set; }
            public System.String Text_Data { get; set; }
            public List<Amazon.SimpleEmailV2.Model.MessageHeader> Simple_Header { get; set; }
            public System.String Subject_Charset { get; set; }
            public System.String Subject_Data { get; set; }
            public List<Amazon.SimpleEmailV2.Model.Attachment> Template_Attachment { get; set; }
            public List<Amazon.SimpleEmailV2.Model.MessageHeader> Template_Header { get; set; }
            public System.String Template_TemplateArn { get; set; }
            public System.String TemplateContent_Html { get; set; }
            public System.String TemplateContent_Subject { get; set; }
            public System.String TemplateContent_Text { get; set; }
            public System.String Template_TemplateData { get; set; }
            public System.String Template_TemplateName { get; set; }
            public List<System.String> Destination_BccAddress { get; set; }
            public List<System.String> Destination_CcAddress { get; set; }
            public List<System.String> Destination_ToAddress { get; set; }
            public List<Amazon.SimpleEmailV2.Model.MessageTag> EmailTag { get; set; }
            public System.String EndpointId { get; set; }
            public System.String FeedbackForwardingEmailAddress { get; set; }
            public System.String FeedbackForwardingEmailAddressIdentityArn { get; set; }
            public System.String FromEmailAddress { get; set; }
            public System.String FromEmailAddressIdentityArn { get; set; }
            public System.String ListManagementOptions_ContactListName { get; set; }
            public System.String ListManagementOptions_TopicName { get; set; }
            public List<System.String> ReplyToAddress { get; set; }
            public System.String TenantName { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.SendEmailResponse, SendSES2EmailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageId;
        }
        
    }
}
