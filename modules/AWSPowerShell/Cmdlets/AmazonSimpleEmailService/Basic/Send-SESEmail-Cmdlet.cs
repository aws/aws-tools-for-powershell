/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace Amazon.PowerShell.Cmdlets.SES
{
    /// <summary>
    /// Composes an email message based on input data, and then immediately queues the message
    /// for sending.
    /// 
    ///  
    /// <para>
    /// There are several important points to know about <code>SendEmail</code>:
    /// </para><ul><li><para>
    /// You can only send email from verified email addresses and domains; otherwise, you
    /// will get an "Email address not verified" error. If your account is still in the Amazon
    /// SES sandbox, you must also verify every recipient email address except for the recipients
    /// provided by the Amazon SES mailbox simulator. For more information, go to the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/verify-addresses-and-domains.html">Amazon
    /// SES Developer Guide</a>.
    /// </para></li><li><para>
    /// The total size of the message cannot exceed 10 MB. This includes any attachments that
    /// are part of the message.
    /// </para></li><li><para>
    /// Amazon SES has a limit on the total number of recipients per message. The combined
    /// number of To:, CC: and BCC: email addresses cannot exceed 50. If you need to send
    /// an email message to a larger audience, you can divide your recipient list into groups
    /// of 50 or fewer, and then call Amazon SES repeatedly to send the message to each group.
    /// </para></li><li><para>
    /// For every message that you send, the total number of recipients (To:, CC: and BCC:)
    /// is counted against your sending quota - the maximum number of emails you can send
    /// in a 24-hour period. For information about your sending quota, go to the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/manage-sending-limits.html">Amazon
    /// SES Developer Guide</a>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Send", "SESEmail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the SendEmail operation against Amazon Simple Email Service.", Operation = new[] {"SendEmail"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.SimpleEmail.Model.SendEmailResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendSESEmailCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Destination_BccAddress
        /// <summary>
        /// <para>
        /// <para>The BCC: field(s) of the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Destination_BccAddresses")]
        public System.String[] Destination_BccAddress { get; set; }
        #endregion
        
        #region Parameter Destination_CcAddress
        /// <summary>
        /// <para>
        /// <para>The CC: field(s) of the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Destination_CcAddresses")]
        public System.String[] Destination_CcAddress { get; set; }
        #endregion
        
        #region Parameter Html_Charset
        /// <summary>
        /// <para>
        /// <para>The character set of the content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Message_Body_Html_Charset")]
        public System.String Html_Charset { get; set; }
        #endregion
        
        #region Parameter Text_Charset
        /// <summary>
        /// <para>
        /// <para>The character set of the content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Message_Body_Text_Charset")]
        public System.String Text_Charset { get; set; }
        #endregion
        
        #region Parameter Subject_Charset
        /// <summary>
        /// <para>
        /// <para>The character set of the content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Message_Subject_Charset")]
        public System.String Subject_Charset { get; set; }
        #endregion
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set to use when you send an email using <code>SendEmail</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationSetName { get; set; }
        #endregion
        
        #region Parameter Html_Data
        /// <summary>
        /// <para>
        /// <para>The textual data of the content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Message_Body_Html_Data")]
        public System.String Html_Data { get; set; }
        #endregion
        
        #region Parameter Text_Data
        /// <summary>
        /// <para>
        /// <para>The textual data of the content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Message_Body_Text_Data")]
        public System.String Text_Data { get; set; }
        #endregion
        
        #region Parameter Subject_Data
        /// <summary>
        /// <para>
        /// <para>The textual data of the content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Message_Subject_Data")]
        public System.String Subject_Data { get; set; }
        #endregion
        
        #region Parameter ReplyToAddress
        /// <summary>
        /// <para>
        /// <para>The reply-to email address(es) for the message. If the recipient replies to the message,
        /// each reply-to address will receive the reply.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ReplyToAddresses")]
        public System.String[] ReplyToAddress { get; set; }
        #endregion
        
        #region Parameter ReturnPath
        /// <summary>
        /// <para>
        /// <para>The email address to which bounces and complaints are to be forwarded when feedback
        /// forwarding is enabled. If the message cannot be delivered to the recipient, then an
        /// error message will be returned from the recipient's ISP; this message will then be
        /// forwarded to the email address specified by the <code>ReturnPath</code> parameter.
        /// The <code>ReturnPath</code> parameter is never overwritten. This email address must
        /// be either individually verified with Amazon SES, or from a domain that has been verified
        /// with Amazon SES. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ReturnPath { get; set; }
        #endregion
        
        #region Parameter ReturnPathArn
        /// <summary>
        /// <para>
        /// <para>This parameter is used only for sending authorization. It is the ARN of the identity
        /// that is associated with the sending authorization policy that permits you to use the
        /// email address specified in the <code>ReturnPath</code> parameter.</para><para>For example, if the owner of <code>example.com</code> (which has ARN <code>arn:aws:ses:us-east-1:123456789012:identity/example.com</code>)
        /// attaches a policy to it that authorizes you to use <code>feedback@example.com</code>,
        /// then you would specify the <code>ReturnPathArn</code> to be <code>arn:aws:ses:us-east-1:123456789012:identity/example.com</code>,
        /// and the <code>ReturnPath</code> to be <code>feedback@example.com</code>.</para><para>For more information about sending authorization, see the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/sending-authorization.html">Amazon
        /// SES Developer Guide</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ReturnPathArn { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The email address that is sending the email. This email address must be either individually
        /// verified with Amazon SES, or from a domain that has been verified with Amazon SES.
        /// For information about verifying identities, see the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/verify-addresses-and-domains.html">Amazon
        /// SES Developer Guide</a>.</para><para>If you are sending on behalf of another user and have been permitted to do so by a
        /// sending authorization policy, then you must also specify the <code>SourceArn</code>
        /// parameter. For more information about sending authorization, see the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/sending-authorization.html">Amazon
        /// SES Developer Guide</a>.</para><para> In all cases, the email address must be 7-bit ASCII. If the text must contain any
        /// other characters, then you must use MIME encoded-word syntax (RFC 2047) instead of
        /// a literal string. MIME encoded-word syntax uses the following form: <code>=?charset?encoding?encoded-text?=</code>.
        /// For more information, see <a href="http://tools.ietf.org/html/rfc2047">RFC 2047</a>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Source { get; set; }
        #endregion
        
        #region Parameter SourceArn
        /// <summary>
        /// <para>
        /// <para>This parameter is used only for sending authorization. It is the ARN of the identity
        /// that is associated with the sending authorization policy that permits you to send
        /// for the email address specified in the <code>Source</code> parameter.</para><para>For example, if the owner of <code>example.com</code> (which has ARN <code>arn:aws:ses:us-east-1:123456789012:identity/example.com</code>)
        /// attaches a policy to it that authorizes you to send from <code>user@example.com</code>,
        /// then you would specify the <code>SourceArn</code> to be <code>arn:aws:ses:us-east-1:123456789012:identity/example.com</code>,
        /// and the <code>Source</code> to be <code>user@example.com</code>.</para><para>For more information about sending authorization, see the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/sending-authorization.html">Amazon
        /// SES Developer Guide</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags, in the form of name/value pairs, to apply to an email that you send
        /// using <code>SendEmail</code>. Tags correspond to characteristics of the email that
        /// you define, so that you can publish email sending events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.SimpleEmail.Model.MessageTag[] Tag { get; set; }
        #endregion
        
        #region Parameter Destination_ToAddress
        /// <summary>
        /// <para>
        /// <para>The To: field(s) of the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Source", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SESEmail (SendEmail)"))
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
            context.Message_Body_Html_Charset = this.Html_Charset;
            context.Message_Body_Html_Data = this.Html_Data;
            context.Message_Body_Text_Charset = this.Text_Charset;
            context.Message_Body_Text_Data = this.Text_Data;
            context.Message_Subject_Charset = this.Subject_Charset;
            context.Message_Subject_Data = this.Subject_Data;
            if (this.ReplyToAddress != null)
            {
                context.ReplyToAddresses = new List<System.String>(this.ReplyToAddress);
            }
            context.ReturnPath = this.ReturnPath;
            context.ReturnPathArn = this.ReturnPathArn;
            context.Source = this.Source;
            context.SourceArn = this.SourceArn;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.SimpleEmail.Model.MessageTag>(this.Tag);
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
            var request = new Amazon.SimpleEmail.Model.SendEmailRequest();
            
            if (cmdletContext.ConfigurationSetName != null)
            {
                request.ConfigurationSetName = cmdletContext.ConfigurationSetName;
            }
            
             // populate Destination
            bool requestDestinationIsNull = true;
            request.Destination = new Amazon.SimpleEmail.Model.Destination();
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
            
             // populate Message
            bool requestMessageIsNull = true;
            request.Message = new Amazon.SimpleEmail.Model.Message();
            Amazon.SimpleEmail.Model.Body requestMessage_message_Body = null;
            
             // populate Body
            bool requestMessage_message_BodyIsNull = true;
            requestMessage_message_Body = new Amazon.SimpleEmail.Model.Body();
            Amazon.SimpleEmail.Model.Content requestMessage_message_Body_message_Body_Html = null;
            
             // populate Html
            bool requestMessage_message_Body_message_Body_HtmlIsNull = true;
            requestMessage_message_Body_message_Body_Html = new Amazon.SimpleEmail.Model.Content();
            System.String requestMessage_message_Body_message_Body_Html_html_Charset = null;
            if (cmdletContext.Message_Body_Html_Charset != null)
            {
                requestMessage_message_Body_message_Body_Html_html_Charset = cmdletContext.Message_Body_Html_Charset;
            }
            if (requestMessage_message_Body_message_Body_Html_html_Charset != null)
            {
                requestMessage_message_Body_message_Body_Html.Charset = requestMessage_message_Body_message_Body_Html_html_Charset;
                requestMessage_message_Body_message_Body_HtmlIsNull = false;
            }
            System.String requestMessage_message_Body_message_Body_Html_html_Data = null;
            if (cmdletContext.Message_Body_Html_Data != null)
            {
                requestMessage_message_Body_message_Body_Html_html_Data = cmdletContext.Message_Body_Html_Data;
            }
            if (requestMessage_message_Body_message_Body_Html_html_Data != null)
            {
                requestMessage_message_Body_message_Body_Html.Data = requestMessage_message_Body_message_Body_Html_html_Data;
                requestMessage_message_Body_message_Body_HtmlIsNull = false;
            }
             // determine if requestMessage_message_Body_message_Body_Html should be set to null
            if (requestMessage_message_Body_message_Body_HtmlIsNull)
            {
                requestMessage_message_Body_message_Body_Html = null;
            }
            if (requestMessage_message_Body_message_Body_Html != null)
            {
                requestMessage_message_Body.Html = requestMessage_message_Body_message_Body_Html;
                requestMessage_message_BodyIsNull = false;
            }
            Amazon.SimpleEmail.Model.Content requestMessage_message_Body_message_Body_Text = null;
            
             // populate Text
            bool requestMessage_message_Body_message_Body_TextIsNull = true;
            requestMessage_message_Body_message_Body_Text = new Amazon.SimpleEmail.Model.Content();
            System.String requestMessage_message_Body_message_Body_Text_text_Charset = null;
            if (cmdletContext.Message_Body_Text_Charset != null)
            {
                requestMessage_message_Body_message_Body_Text_text_Charset = cmdletContext.Message_Body_Text_Charset;
            }
            if (requestMessage_message_Body_message_Body_Text_text_Charset != null)
            {
                requestMessage_message_Body_message_Body_Text.Charset = requestMessage_message_Body_message_Body_Text_text_Charset;
                requestMessage_message_Body_message_Body_TextIsNull = false;
            }
            System.String requestMessage_message_Body_message_Body_Text_text_Data = null;
            if (cmdletContext.Message_Body_Text_Data != null)
            {
                requestMessage_message_Body_message_Body_Text_text_Data = cmdletContext.Message_Body_Text_Data;
            }
            if (requestMessage_message_Body_message_Body_Text_text_Data != null)
            {
                requestMessage_message_Body_message_Body_Text.Data = requestMessage_message_Body_message_Body_Text_text_Data;
                requestMessage_message_Body_message_Body_TextIsNull = false;
            }
             // determine if requestMessage_message_Body_message_Body_Text should be set to null
            if (requestMessage_message_Body_message_Body_TextIsNull)
            {
                requestMessage_message_Body_message_Body_Text = null;
            }
            if (requestMessage_message_Body_message_Body_Text != null)
            {
                requestMessage_message_Body.Text = requestMessage_message_Body_message_Body_Text;
                requestMessage_message_BodyIsNull = false;
            }
             // determine if requestMessage_message_Body should be set to null
            if (requestMessage_message_BodyIsNull)
            {
                requestMessage_message_Body = null;
            }
            if (requestMessage_message_Body != null)
            {
                request.Message.Body = requestMessage_message_Body;
                requestMessageIsNull = false;
            }
            Amazon.SimpleEmail.Model.Content requestMessage_message_Subject = null;
            
             // populate Subject
            bool requestMessage_message_SubjectIsNull = true;
            requestMessage_message_Subject = new Amazon.SimpleEmail.Model.Content();
            System.String requestMessage_message_Subject_subject_Charset = null;
            if (cmdletContext.Message_Subject_Charset != null)
            {
                requestMessage_message_Subject_subject_Charset = cmdletContext.Message_Subject_Charset;
            }
            if (requestMessage_message_Subject_subject_Charset != null)
            {
                requestMessage_message_Subject.Charset = requestMessage_message_Subject_subject_Charset;
                requestMessage_message_SubjectIsNull = false;
            }
            System.String requestMessage_message_Subject_subject_Data = null;
            if (cmdletContext.Message_Subject_Data != null)
            {
                requestMessage_message_Subject_subject_Data = cmdletContext.Message_Subject_Data;
            }
            if (requestMessage_message_Subject_subject_Data != null)
            {
                requestMessage_message_Subject.Data = requestMessage_message_Subject_subject_Data;
                requestMessage_message_SubjectIsNull = false;
            }
             // determine if requestMessage_message_Subject should be set to null
            if (requestMessage_message_SubjectIsNull)
            {
                requestMessage_message_Subject = null;
            }
            if (requestMessage_message_Subject != null)
            {
                request.Message.Subject = requestMessage_message_Subject;
                requestMessageIsNull = false;
            }
             // determine if request.Message should be set to null
            if (requestMessageIsNull)
            {
                request.Message = null;
            }
            if (cmdletContext.ReplyToAddresses != null)
            {
                request.ReplyToAddresses = cmdletContext.ReplyToAddresses;
            }
            if (cmdletContext.ReturnPath != null)
            {
                request.ReturnPath = cmdletContext.ReturnPath;
            }
            if (cmdletContext.ReturnPathArn != null)
            {
                request.ReturnPathArn = cmdletContext.ReturnPathArn;
            }
            if (cmdletContext.Source != null)
            {
                request.Source = cmdletContext.Source;
            }
            if (cmdletContext.SourceArn != null)
            {
                request.SourceArn = cmdletContext.SourceArn;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SimpleEmail.Model.SendEmailResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.SendEmailRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service", "SendEmail");
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
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ConfigurationSetName { get; set; }
            public List<System.String> Destination_BccAddresses { get; set; }
            public List<System.String> Destination_CcAddresses { get; set; }
            public List<System.String> Destination_ToAddresses { get; set; }
            public System.String Message_Body_Html_Charset { get; set; }
            public System.String Message_Body_Html_Data { get; set; }
            public System.String Message_Body_Text_Charset { get; set; }
            public System.String Message_Body_Text_Data { get; set; }
            public System.String Message_Subject_Charset { get; set; }
            public System.String Message_Subject_Data { get; set; }
            public List<System.String> ReplyToAddresses { get; set; }
            public System.String ReturnPath { get; set; }
            public System.String ReturnPathArn { get; set; }
            public System.String Source { get; set; }
            public System.String SourceArn { get; set; }
            public List<Amazon.SimpleEmail.Model.MessageTag> Tags { get; set; }
        }
        
    }
}
