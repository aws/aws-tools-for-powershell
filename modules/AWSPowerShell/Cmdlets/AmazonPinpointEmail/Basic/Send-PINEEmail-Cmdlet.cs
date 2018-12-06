/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.PinpointEmail;
using Amazon.PinpointEmail.Model;

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
    [AWSCmdlet("Calls the Amazon Pinpoint Email SendEmail API operation.", Operation = new[] {"SendEmail"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.PinpointEmail.Model.SendEmailResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendPINEEmailCmdlet : AmazonPinpointEmailClientCmdlet, IExecutor
    {
        
        #region Parameter Destination_BccAddress
        /// <summary>
        /// <para>
        /// <para>An array that contains the email addresses of the "BCC" (blind carbon copy) recipients
        /// for the email.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        [Alias("Destination_CcAddresses")]
        public System.String[] Destination_CcAddress { get; set; }
        #endregion
        
        #region Parameter Html_Charset
        /// <summary>
        /// <para>
        /// <para>The character set for the content. Because of the constraints of the SMTP protocol,
        /// Amazon Pinpoint uses 7-bit ASCII by default. If the text includes characters outside
        /// of the ASCII range, you have to specify a character set. For example, you could specify
        /// <code>UTF-8</code>, <code>ISO-8859-1</code>, or <code>Shift_JIS</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Content_Simple_Body_Html_Charset")]
        public System.String Html_Charset { get; set; }
        #endregion
        
        #region Parameter Text_Charset
        /// <summary>
        /// <para>
        /// <para>The character set for the content. Because of the constraints of the SMTP protocol,
        /// Amazon Pinpoint uses 7-bit ASCII by default. If the text includes characters outside
        /// of the ASCII range, you have to specify a character set. For example, you could specify
        /// <code>UTF-8</code>, <code>ISO-8859-1</code>, or <code>Shift_JIS</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Content_Simple_Body_Text_Charset")]
        public System.String Text_Charset { get; set; }
        #endregion
        
        #region Parameter Subject_Charset
        /// <summary>
        /// <para>
        /// <para>The character set for the content. Because of the constraints of the SMTP protocol,
        /// Amazon Pinpoint uses 7-bit ASCII by default. If the text includes characters outside
        /// of the ASCII range, you have to specify a character set. For example, you could specify
        /// <code>UTF-8</code>, <code>ISO-8859-1</code>, or <code>Shift_JIS</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Content_Simple_Subject_Charset")]
        public System.String Subject_Charset { get; set; }
        #endregion
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set that you want to use when sending the email.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Content_Raw_Data")]
        public byte[] Raw_Data { get; set; }
        #endregion
        
        #region Parameter Html_Data
        /// <summary>
        /// <para>
        /// <para>The content of the message itself.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Content_Simple_Body_Html_Data")]
        public System.String Html_Data { get; set; }
        #endregion
        
        #region Parameter Text_Data
        /// <summary>
        /// <para>
        /// <para>The content of the message itself.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Content_Simple_Body_Text_Data")]
        public System.String Text_Data { get; set; }
        #endregion
        
        #region Parameter Subject_Data
        /// <summary>
        /// <para>
        /// <para>The content of the message itself.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        [Alias("EmailTags")]
        public Amazon.PinpointEmail.Model.MessageTag[] EmailTag { get; set; }
        #endregion
        
        #region Parameter FeedbackForwardingEmailAddress
        /// <summary>
        /// <para>
        /// <para>The address that Amazon Pinpoint should send bounce and complaint notifications to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FeedbackForwardingEmailAddress { get; set; }
        #endregion
        
        #region Parameter FromEmailAddress
        /// <summary>
        /// <para>
        /// <para>The email address that you want to use as the "From" address for the email. The address
        /// that you specify has to be verified. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FromEmailAddress { get; set; }
        #endregion
        
        #region Parameter ReplyToAddress
        /// <summary>
        /// <para>
        /// <para>The "Reply-to" email addresses for the message. When the recipient replies to the
        /// message, each Reply-to address receives the reply.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ReplyToAddresses")]
        public System.String[] ReplyToAddress { get; set; }
        #endregion
        
        #region Parameter Destination_ToAddress
        /// <summary>
        /// <para>
        /// <para>An array that contains the email addresses of the "To" recipients for the email.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Destination_ToAddresses")]
        public System.String[] Destination_ToAddress { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ConfigurationSetName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-PINEEmail (SendEmail)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ConfigurationSetName = this.ConfigurationSetName;
            context.Content_Raw_Data = this.Raw_Data;
            context.Content_Simple_Body_Html_Charset = this.Html_Charset;
            context.Content_Simple_Body_Html_Data = this.Html_Data;
            context.Content_Simple_Body_Text_Charset = this.Text_Charset;
            context.Content_Simple_Body_Text_Data = this.Text_Data;
            context.Content_Simple_Subject_Charset = this.Subject_Charset;
            context.Content_Simple_Subject_Data = this.Subject_Data;
            if (this.Destination_BccAddress != null)
            {
                context.Destination_BccAddresses = new List<System.String>(this.Destination_BccAddress);
            }
            if (this.Destination_CcAddress != null)
            {
                context.Destination_CcAddresses = new List<System.String>(this.Destination_CcAddress);
            }
            if (this.Destination_ToAddress != null)
            {
                context.Destination_ToAddresses = new List<System.String>(this.Destination_ToAddress);
            }
            if (this.EmailTag != null)
            {
                context.EmailTags = new List<Amazon.PinpointEmail.Model.MessageTag>(this.EmailTag);
            }
            context.FeedbackForwardingEmailAddress = this.FeedbackForwardingEmailAddress;
            context.FromEmailAddress = this.FromEmailAddress;
            if (this.ReplyToAddress != null)
            {
                context.ReplyToAddresses = new List<System.String>(this.ReplyToAddress);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _Content_Raw_DataStream = null;
            
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
                bool requestContentIsNull = true;
                request.Content = new Amazon.PinpointEmail.Model.EmailContent();
                Amazon.PinpointEmail.Model.RawMessage requestContent_content_Raw = null;
                
                 // populate Raw
                bool requestContent_content_RawIsNull = true;
                requestContent_content_Raw = new Amazon.PinpointEmail.Model.RawMessage();
                System.IO.MemoryStream requestContent_content_Raw_raw_Data = null;
                if (cmdletContext.Content_Raw_Data != null)
                {
                    _Content_Raw_DataStream = new System.IO.MemoryStream(cmdletContext.Content_Raw_Data);
                    requestContent_content_Raw_raw_Data = _Content_Raw_DataStream;
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
                Amazon.PinpointEmail.Model.Message requestContent_content_Simple = null;
                
                 // populate Simple
                bool requestContent_content_SimpleIsNull = true;
                requestContent_content_Simple = new Amazon.PinpointEmail.Model.Message();
                Amazon.PinpointEmail.Model.Body requestContent_content_Simple_content_Simple_Body = null;
                
                 // populate Body
                bool requestContent_content_Simple_content_Simple_BodyIsNull = true;
                requestContent_content_Simple_content_Simple_Body = new Amazon.PinpointEmail.Model.Body();
                Amazon.PinpointEmail.Model.Content requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html = null;
                
                 // populate Html
                bool requestContent_content_Simple_content_Simple_Body_content_Simple_Body_HtmlIsNull = true;
                requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html = new Amazon.PinpointEmail.Model.Content();
                System.String requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Charset = null;
                if (cmdletContext.Content_Simple_Body_Html_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Charset = cmdletContext.Content_Simple_Body_Html_Charset;
                }
                if (requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html.Charset = requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Charset;
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_HtmlIsNull = false;
                }
                System.String requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Data = null;
                if (cmdletContext.Content_Simple_Body_Html_Data != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Html_html_Data = cmdletContext.Content_Simple_Body_Html_Data;
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
                Amazon.PinpointEmail.Model.Content requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text = null;
                
                 // populate Text
                bool requestContent_content_Simple_content_Simple_Body_content_Simple_Body_TextIsNull = true;
                requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text = new Amazon.PinpointEmail.Model.Content();
                System.String requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Charset = null;
                if (cmdletContext.Content_Simple_Body_Text_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Charset = cmdletContext.Content_Simple_Body_Text_Charset;
                }
                if (requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text.Charset = requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Charset;
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_TextIsNull = false;
                }
                System.String requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Data = null;
                if (cmdletContext.Content_Simple_Body_Text_Data != null)
                {
                    requestContent_content_Simple_content_Simple_Body_content_Simple_Body_Text_text_Data = cmdletContext.Content_Simple_Body_Text_Data;
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
                Amazon.PinpointEmail.Model.Content requestContent_content_Simple_content_Simple_Subject = null;
                
                 // populate Subject
                bool requestContent_content_Simple_content_Simple_SubjectIsNull = true;
                requestContent_content_Simple_content_Simple_Subject = new Amazon.PinpointEmail.Model.Content();
                System.String requestContent_content_Simple_content_Simple_Subject_subject_Charset = null;
                if (cmdletContext.Content_Simple_Subject_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Subject_subject_Charset = cmdletContext.Content_Simple_Subject_Charset;
                }
                if (requestContent_content_Simple_content_Simple_Subject_subject_Charset != null)
                {
                    requestContent_content_Simple_content_Simple_Subject.Charset = requestContent_content_Simple_content_Simple_Subject_subject_Charset;
                    requestContent_content_Simple_content_Simple_SubjectIsNull = false;
                }
                System.String requestContent_content_Simple_content_Simple_Subject_subject_Data = null;
                if (cmdletContext.Content_Simple_Subject_Data != null)
                {
                    requestContent_content_Simple_content_Simple_Subject_subject_Data = cmdletContext.Content_Simple_Subject_Data;
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
                 // determine if request.Content should be set to null
                if (requestContentIsNull)
                {
                    request.Content = null;
                }
                
                 // populate Destination
                bool requestDestinationIsNull = true;
                request.Destination = new Amazon.PinpointEmail.Model.Destination();
                List<System.String> requestDestination_destination_BccAddress = null;
                if (cmdletContext.Destination_BccAddresses != null)
                {
                    requestDestination_destination_BccAddress = cmdletContext.Destination_BccAddresses;
                }
                if (requestDestination_destination_BccAddress != null)
                {
                    request.Destination.BccAddresses = requestDestination_destination_BccAddress;
                    requestDestinationIsNull = false;
                }
                List<System.String> requestDestination_destination_CcAddress = null;
                if (cmdletContext.Destination_CcAddresses != null)
                {
                    requestDestination_destination_CcAddress = cmdletContext.Destination_CcAddresses;
                }
                if (requestDestination_destination_CcAddress != null)
                {
                    request.Destination.CcAddresses = requestDestination_destination_CcAddress;
                    requestDestinationIsNull = false;
                }
                List<System.String> requestDestination_destination_ToAddress = null;
                if (cmdletContext.Destination_ToAddresses != null)
                {
                    requestDestination_destination_ToAddress = cmdletContext.Destination_ToAddresses;
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
                if (cmdletContext.EmailTags != null)
                {
                    request.EmailTags = cmdletContext.EmailTags;
                }
                if (cmdletContext.FeedbackForwardingEmailAddress != null)
                {
                    request.FeedbackForwardingEmailAddress = cmdletContext.FeedbackForwardingEmailAddress;
                }
                if (cmdletContext.FromEmailAddress != null)
                {
                    request.FromEmailAddress = cmdletContext.FromEmailAddress;
                }
                if (cmdletContext.ReplyToAddresses != null)
                {
                    request.ReplyToAddresses = cmdletContext.ReplyToAddresses;
                }
                
                CmdletOutput output;
                
                // issue call
                var client = Client ?? CreateClient(context.Credentials, context.Region);
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    Dictionary<string, object> notes = null;
                    object pipelineOutput = response.MessageId;
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response,
                        Notes = notes
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
                if( _Content_Raw_DataStream != null)
                {
                    _Content_Raw_DataStream.Dispose();
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
                #if DESKTOP
                return client.SendEmail(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SendEmailAsync(request);
                return task.Result;
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
            public byte[] Content_Raw_Data { get; set; }
            public System.String Content_Simple_Body_Html_Charset { get; set; }
            public System.String Content_Simple_Body_Html_Data { get; set; }
            public System.String Content_Simple_Body_Text_Charset { get; set; }
            public System.String Content_Simple_Body_Text_Data { get; set; }
            public System.String Content_Simple_Subject_Charset { get; set; }
            public System.String Content_Simple_Subject_Data { get; set; }
            public List<System.String> Destination_BccAddresses { get; set; }
            public List<System.String> Destination_CcAddresses { get; set; }
            public List<System.String> Destination_ToAddresses { get; set; }
            public List<Amazon.PinpointEmail.Model.MessageTag> EmailTags { get; set; }
            public System.String FeedbackForwardingEmailAddress { get; set; }
            public System.String FromEmailAddress { get; set; }
            public List<System.String> ReplyToAddresses { get; set; }
        }
        
    }
}
