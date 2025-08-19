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
using Amazon.PinpointEmail;
using Amazon.PinpointEmail.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PINE
{
    /// <summary>
    /// Sends an email message. You can use the Amazon Pinpoint Email API to send two types
    /// of messages:
    /// 
    ///  <ul><li><para><b>Simple</b> – A standard email message. When you create this type of message, you
    /// specify the sender, the recipient, and the message body, and Amazon Pinpoint assembles
    /// the message for you.
    /// </para></li><li><para><b>Raw</b> – A raw, MIME-formatted email message. When you send this type of email,
    /// you have to specify all of the message headers, as well as the message body. You can
    /// use this message type to send messages that contain attachments. The message that
    /// you specify has to be a valid MIME message.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Send", "PINEEmail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Pinpoint Email SendEmail API operation.", Operation = new[] {"SendEmail"}, SelectReturnType = typeof(Amazon.PinpointEmail.Model.SendEmailResponse))]
    [AWSCmdletOutput("System.String or Amazon.PinpointEmail.Model.SendEmailResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.PinpointEmail.Model.SendEmailResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SendPINEEmailCmdlet : AmazonPinpointEmailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        /// Amazon Pinpoint uses 7-bit ASCII by default. If the text includes characters outside
        /// of the ASCII range, you have to specify a character set. For example, you could specify
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
        /// Amazon Pinpoint uses 7-bit ASCII by default. If the text includes characters outside
        /// of the ASCII range, you have to specify a character set. For example, you could specify
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
        /// Amazon Pinpoint uses 7-bit ASCII by default. If the text includes characters outside
        /// of the ASCII range, you have to specify a character set. For example, you could specify
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
        /// <para>The name of the configuration set that you want to use when sending the email.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ConfigurationSetName { get; set; }
        #endregion
        
        #region Parameter Raw_Data
        /// <summary>
        /// <para>
        /// <para>The raw email message. The message has to meet the following criteria:</para><ul><li><para>The message has to contain a header and a body, separated by one blank line.</para></li><li><para>All of the required header fields must be present in the message.</para></li><li><para>Each part of a multipart MIME message must be formatted properly.</para></li><li><para>Attachments must be in a file format that Amazon Pinpoint supports. </para></li><li><para>The entire message must be Base64 encoded.</para></li><li><para>If any of the MIME parts in your message contain content that is outside of the 7-bit
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
        public Amazon.PinpointEmail.Model.MessageTag[] EmailTag { get; set; }
        #endregion
        
        #region Parameter FeedbackForwardingEmailAddress
        /// <summary>
        /// <para>
        /// <para>The address that Amazon Pinpoint should send bounce and complaint notifications to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FeedbackForwardingEmailAddress { get; set; }
        #endregion
        
        #region Parameter FromEmailAddress
        /// <summary>
        /// <para>
        /// <para>The email address that you want to use as the "From" address for the email. The address
        /// that you specify has to be verified. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FromEmailAddress { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MessageId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointEmail.Model.SendEmailResponse).
        /// Specifying the name of a property of type Amazon.PinpointEmail.Model.SendEmailResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-PINEEmail (SendEmail)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointEmail.Model.SendEmailResponse, SendPINEEmailCmdlet>(Select) ??
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
                context.EmailTag = new List<Amazon.PinpointEmail.Model.MessageTag>(this.EmailTag);
            }
            context.FeedbackForwardingEmailAddress = this.FeedbackForwardingEmailAddress;
            context.FromEmailAddress = this.FromEmailAddress;
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
                var request = new Amazon.PinpointEmail.Model.SendEmailRequest();
                
                if (cmdletContext.ConfigurationSetName != null)
                {
                    request.ConfigurationSetName = cmdletContext.ConfigurationSetName;
                }
                
                 // populate Content
                request.Content = new Amazon.PinpointEmail.Model.EmailContent();
                Amazon.PinpointEmail.Model.RawMessage requestContent_content_Raw = null;
                
                 // populate Raw
                var requestContent_content_RawIsNull = true;
                requestContent_content_Raw = new Amazon.PinpointEmail.Model.RawMessage();
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
                }
                Amazon.PinpointEmail.Model.Message requestContent_content_Simple = null;
                
                 // populate Simple
                var requestContent_content_SimpleIsNull = true;
                requestContent_content_Simple = new Amazon.PinpointEmail.Model.Message();
                Amazon.PinpointEmail.Model.Body requestContent_content_Simple_content_Simple_Body = null;
                
                 // populate Body
                requestContent_content_Simple_content_Simple_Body = new Amazon.PinpointEmail.Model.Body();
                Amazon.PinpointEmail.Model.Content requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html = null;
                
                 // populate Html
                var requestContent_content_Simple_content_Simple_Body_content_Simple_Body_HtmlIsNull = true;
                requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html = new Amazon.PinpointEmail.Model.Content();
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
                }
                Amazon.PinpointEmail.Model.Content requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text = null;
                
                 // populate Text
                var requestContent_content_Simple_content_Simple_Body_content_Simple_Body_TextIsNull = true;
                requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text = new Amazon.PinpointEmail.Model.Content();
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
                }
                if (requestContent_content_Simple_content_Simple_Body != null)
                {
                    requestContent_content_Simple.Body = requestContent_content_Simple_content_Simple_Body;
                    requestContent_content_SimpleIsNull = false;
                }
                Amazon.PinpointEmail.Model.Content requestContent_content_Simple_content_Simple_Subject = null;
                
                 // populate Subject
                var requestContent_content_Simple_content_Simple_SubjectIsNull = true;
                requestContent_content_Simple_content_Simple_Subject = new Amazon.PinpointEmail.Model.Content();
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
                }
                Amazon.PinpointEmail.Model.Template requestContent_content_Template = null;
                
                 // populate Template
                var requestContent_content_TemplateIsNull = true;
                requestContent_content_Template = new Amazon.PinpointEmail.Model.Template();
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
                 // determine if requestContent_content_Template should be set to null
                if (requestContent_content_TemplateIsNull)
                {
                    requestContent_content_Template = null;
                }
                if (requestContent_content_Template != null)
                {
                    request.Content.Template = requestContent_content_Template;
                }
                
                 // populate Destination
                request.Destination = new Amazon.PinpointEmail.Model.Destination();
                List<System.String> requestDestination_destination_BccAddress = null;
                if (cmdletContext.Destination_BccAddress != null)
                {
                    requestDestination_destination_BccAddress = cmdletContext.Destination_BccAddress;
                }
                if (requestDestination_destination_BccAddress != null)
                {
                    request.Destination.BccAddresses = requestDestination_destination_BccAddress;
                }
                List<System.String> requestDestination_destination_CcAddress = null;
                if (cmdletContext.Destination_CcAddress != null)
                {
                    requestDestination_destination_CcAddress = cmdletContext.Destination_CcAddress;
                }
                if (requestDestination_destination_CcAddress != null)
                {
                    request.Destination.CcAddresses = requestDestination_destination_CcAddress;
                }
                List<System.String> requestDestination_destination_ToAddress = null;
                if (cmdletContext.Destination_ToAddress != null)
                {
                    requestDestination_destination_ToAddress = cmdletContext.Destination_ToAddress;
                }
                if (requestDestination_destination_ToAddress != null)
                {
                    request.Destination.ToAddresses = requestDestination_destination_ToAddress;
                }
                if (cmdletContext.EmailTag != null)
                {
                    request.EmailTags = cmdletContext.EmailTag;
                }
                if (cmdletContext.FeedbackForwardingEmailAddress != null)
                {
                    request.FeedbackForwardingEmailAddress = cmdletContext.FeedbackForwardingEmailAddress;
                }
                if (cmdletContext.FromEmailAddress != null)
                {
                    request.FromEmailAddress = cmdletContext.FromEmailAddress;
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
        
        private Amazon.PinpointEmail.Model.SendEmailResponse CallAWSServiceOperation(IAmazonPinpointEmail client, Amazon.PinpointEmail.Model.SendEmailRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint Email", "SendEmail");
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
            public System.String Html_Charset { get; set; }
            public System.String Html_Data { get; set; }
            public System.String Text_Charset { get; set; }
            public System.String Text_Data { get; set; }
            public System.String Subject_Charset { get; set; }
            public System.String Subject_Data { get; set; }
            public System.String Template_TemplateArn { get; set; }
            public System.String Template_TemplateData { get; set; }
            public List<System.String> Destination_BccAddress { get; set; }
            public List<System.String> Destination_CcAddress { get; set; }
            public List<System.String> Destination_ToAddress { get; set; }
            public List<Amazon.PinpointEmail.Model.MessageTag> EmailTag { get; set; }
            public System.String FeedbackForwardingEmailAddress { get; set; }
            public System.String FromEmailAddress { get; set; }
            public List<System.String> ReplyToAddress { get; set; }
            public System.Func<Amazon.PinpointEmail.Model.SendEmailResponse, SendPINEEmailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageId;
        }
        
    }
}
