/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

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
        "The service call response (type Amazon.SimpleEmailV2.Model.SendEmailResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendSES2EmailCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        #region Parameter Destination_BccAddress
        /// <summary>
        /// <para>
        /// <para>An array that contains the email addresses of the "BCC" (blind carbon copy) recipients
        /// for the email.</para>
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
        /// the email.</para>
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
        /// <code>UTF-8</code>, <code>ISO-8859-1</code>, or <code>Shift_JIS</code>.</para>
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
        /// <code>UTF-8</code>, <code>ISO-8859-1</code>, or <code>Shift_JIS</code>.</para>
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
        /// <code>UTF-8</code>, <code>ISO-8859-1</code>, or <code>Shift_JIS</code>.</para>
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
        /// <para>The raw email message. The message has to meet the following criteria:</para><ul><li><para>The message has to contain a header and a body, separated by one blank line.</para></li><li><para>All of the required header fields must be present in the message.</para></li><li><para>Each part of a multipart MIME message must be formatted properly.</para></li><li><para>Attachments must be in a file format that the Amazon SES supports.</para></li><li><para>The entire message must be Base64 encoded.</para></li><li><para>If any of the MIME parts in your message contain content that is outside of the 7-bit
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
        /// using the <code>SendEmail</code> operation. Tags correspond to characteristics of
        /// the email that you define, so that you can publish email sending events. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EmailTags")]
        public Amazon.SimpleEmailV2.Model.MessageTag[] EmailTag { get; set; }
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
        /// email address specified in the <code>FeedbackForwardingEmailAddress</code> parameter.</para><para>For example, if the owner of example.com (which has ARN arn:aws:ses:us-east-1:123456789012:identity/example.com)
        /// attaches a policy to it that authorizes you to use feedback@example.com, then you
        /// would specify the <code>FeedbackForwardingEmailAddressIdentityArn</code> to be arn:aws:ses:us-east-1:123456789012:identity/example.com,
        /// and the <code>FeedbackForwardingEmailAddress</code> to be feedback@example.com.</para><para>For more information about sending authorization, see the <a href="https://docs.aws.amazon.com/ses/latest/DeveloperGuide/sending-authorization.html">Amazon
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
        /// email address specified in the <code>FromEmailAddress</code> parameter.</para><para>For example, if the owner of example.com (which has ARN arn:aws:ses:us-east-1:123456789012:identity/example.com)
        /// attaches a policy to it that authorizes you to use sender@example.com, then you would
        /// specify the <code>FromEmailAddressIdentityArn</code> to be arn:aws:ses:us-east-1:123456789012:identity/example.com,
        /// and the <code>FromEmailAddress</code> to be sender@example.com.</para><para>For more information about sending authorization, see the <a href="https://docs.aws.amazon.com/ses/latest/DeveloperGuide/sending-authorization.html">Amazon
        /// SES Developer Guide</a>.</para><para>For Raw emails, the <code>FromEmailAddressIdentityArn</code> value overrides the X-SES-SOURCE-ARN
        /// and X-SES-FROM-ARN headers specified in raw email message content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FromEmailAddressIdentityArn { get; set; }
        #endregion
        
        #region Parameter ReplyToAddress
        /// <summary>
        /// <para>
        /// <para>The "Reply-to" email addresses for the message. When the recipient replies to the
        /// message, each Reply-to address receives the reply.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReplyToAddresses")]
        public System.String[] ReplyToAddress { get; set; }
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
        /// <code>SendTemplatedEmail</code> or <code>SendBulkTemplatedEmail</code> operations.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Content_Template_TemplateName")]
        public System.String Template_TemplateName { get; set; }
        #endregion
        
        #region Parameter Destination_ToAddress
        /// <summary>
        /// <para>
        /// <para>An array that contains the email addresses of the "To" recipients for the email.</para>
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
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
            context.Html_Charset = this.Html_Charset;
            context.Html_Data = this.Html_Data;
            context.Text_Charset = this.Text_Charset;
            context.Text_Data = this.Text_Data;
            context.Subject_Charset = this.Subject_Charset;
            context.Subject_Data = this.Subject_Data;
            context.Template_TemplateArn = this.Template_TemplateArn;
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
                #if DESKTOP
                return client.SendEmail(request);
                #elif CORECLR
                return client.SendEmailAsync(request).GetAwaiter().GetResult();
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
            public System.String ConfigurationSetName { get; set; }
            public byte[] Raw_Data { get; set; }
            public System.String Html_Charset { get; set; }
            public System.String Html_Data { get; set; }
            public System.String Text_Charset { get; set; }
            public System.String Text_Data { get; set; }
            public System.String Subject_Charset { get; set; }
            public System.String Subject_Data { get; set; }
            public System.String Template_TemplateArn { get; set; }
            public System.String Template_TemplateData { get; set; }
            public System.String Template_TemplateName { get; set; }
            public List<System.String> Destination_BccAddress { get; set; }
            public List<System.String> Destination_CcAddress { get; set; }
            public List<System.String> Destination_ToAddress { get; set; }
            public List<Amazon.SimpleEmailV2.Model.MessageTag> EmailTag { get; set; }
            public System.String FeedbackForwardingEmailAddress { get; set; }
            public System.String FeedbackForwardingEmailAddressIdentityArn { get; set; }
            public System.String FromEmailAddress { get; set; }
            public System.String FromEmailAddressIdentityArn { get; set; }
            public System.String ListManagementOptions_ContactListName { get; set; }
            public System.String ListManagementOptions_TopicName { get; set; }
            public List<System.String> ReplyToAddress { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.SendEmailResponse, SendSES2EmailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageId;
        }
        
    }
}
