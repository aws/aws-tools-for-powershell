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
    ///  <important> You can only send email from verified email addresses and domains. If
    /// you have not requested production access to Amazon SES, you must also verify every
    /// recipient email address except for the recipients provided by the Amazon SES mailbox
    /// simulator. For more information, go to the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/verify-addresses-and-domains.html">Amazon
    /// SES Developer Guide</a>. </important><para>
    /// The total size of the message cannot exceed 10 MB.
    /// </para><para>
    /// Amazon SES has a limit on the total number of recipients per message: The combined
    /// number of To:, CC: and BCC: email addresses cannot exceed 50. If you need to send
    /// an email message to a larger audience, you can divide your recipient list into groups
    /// of 50 or fewer, and then call Amazon SES repeatedly to send the message to each group.
    /// 
    /// </para><para>
    /// For every message that you send, the total number of recipients (To:, CC: and BCC:)
    /// is counted against your <i>sending quota</i> - the maximum number of emails you can
    /// send in a 24-hour period. For information about your sending quota, go to the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/manage-sending-limits.html">Amazon
    /// SES Developer Guide</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("Send", "SESEmail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the SendEmail operation against Amazon Simple Email Service.", Operation = new[] {"SendEmail"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type SendEmailResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class SendSESEmailCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The BCC: field(s) of the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Destination_BccAddresses")]
        public System.String[] Destination_BccAddress { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The CC: field(s) of the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Destination_CcAddresses")]
        public System.String[] Destination_CcAddress { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The character set of the content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Message_Body_Html_Charset")]
        public String Html_Charset { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The character set of the content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Message_Body_Text_Charset")]
        public String Text_Charset { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The character set of the content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Message_Subject_Charset")]
        public String Subject_Charset { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The textual data of the content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Message_Body_Html_Data")]
        public String Html_Data { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The textual data of the content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Message_Body_Text_Data")]
        public String Text_Data { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The textual data of the content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Message_Subject_Data")]
        public String Subject_Data { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The reply-to email address(es) for the message. If the recipient replies to the message,
        /// each reply-to address will receive the reply. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ReplyToAddresses")]
        public System.String[] ReplyToAddress { get; set; }
        
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
        public String ReturnPath { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The identity's email address.</para><para> By default, the string must be 7-bit ASCII. If the text must contain any other characters,
        /// then you must use MIME encoded-word syntax (RFC 2047) instead of a literal string.
        /// MIME encoded-word syntax uses the following form: <code>=?charset?encoding?encoded-text?=</code>.
        /// For more information, see <a href="http://tools.ietf.org/html/rfc2047">RFC 2047</a>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String Source { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The To: field(s) of the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Destination_ToAddresses")]
        public System.String[] Destination_ToAddress { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
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
            
            if (this.Destination_BccAddress != null)
            {
                context.Destination_BccAddresses = new List<String>(this.Destination_BccAddress);
            }
            if (this.Destination_CcAddress != null)
            {
                context.Destination_CcAddresses = new List<String>(this.Destination_CcAddress);
            }
            if (this.Destination_ToAddress != null)
            {
                context.Destination_ToAddresses = new List<String>(this.Destination_ToAddress);
            }
            context.Message_Body_Html_Charset = this.Html_Charset;
            context.Message_Body_Html_Data = this.Html_Data;
            context.Message_Body_Text_Charset = this.Text_Charset;
            context.Message_Body_Text_Data = this.Text_Data;
            context.Message_Subject_Charset = this.Subject_Charset;
            context.Message_Subject_Data = this.Subject_Data;
            if (this.ReplyToAddress != null)
            {
                context.ReplyToAddresses = new List<String>(this.ReplyToAddress);
            }
            context.ReturnPath = this.ReturnPath;
            context.Source = this.Source;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new SendEmailRequest();
            
            
             // populate Destination
            bool requestDestinationIsNull = true;
            request.Destination = new Destination();
            List<String> requestDestination_destination_BccAddress = null;
            if (cmdletContext.Destination_BccAddresses != null)
            {
                requestDestination_destination_BccAddress = cmdletContext.Destination_BccAddresses;
            }
            if (requestDestination_destination_BccAddress != null)
            {
                request.Destination.BccAddresses = requestDestination_destination_BccAddress;
                requestDestinationIsNull = false;
            }
            List<String> requestDestination_destination_CcAddress = null;
            if (cmdletContext.Destination_CcAddresses != null)
            {
                requestDestination_destination_CcAddress = cmdletContext.Destination_CcAddresses;
            }
            if (requestDestination_destination_CcAddress != null)
            {
                request.Destination.CcAddresses = requestDestination_destination_CcAddress;
                requestDestinationIsNull = false;
            }
            List<String> requestDestination_destination_ToAddress = null;
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
            request.Message = new Message();
            Body requestMessage_message_Body = null;
            
             // populate Body
            bool requestMessage_message_BodyIsNull = true;
            requestMessage_message_Body = new Body();
            Content requestMessage_message_Body_message_Body_Html = null;
            
             // populate Html
            bool requestMessage_message_Body_message_Body_HtmlIsNull = true;
            requestMessage_message_Body_message_Body_Html = new Content();
            String requestMessage_message_Body_message_Body_Html_html_Charset = null;
            if (cmdletContext.Message_Body_Html_Charset != null)
            {
                requestMessage_message_Body_message_Body_Html_html_Charset = cmdletContext.Message_Body_Html_Charset;
            }
            if (requestMessage_message_Body_message_Body_Html_html_Charset != null)
            {
                requestMessage_message_Body_message_Body_Html.Charset = requestMessage_message_Body_message_Body_Html_html_Charset;
                requestMessage_message_Body_message_Body_HtmlIsNull = false;
            }
            String requestMessage_message_Body_message_Body_Html_html_Data = null;
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
            Content requestMessage_message_Body_message_Body_Text = null;
            
             // populate Text
            bool requestMessage_message_Body_message_Body_TextIsNull = true;
            requestMessage_message_Body_message_Body_Text = new Content();
            String requestMessage_message_Body_message_Body_Text_text_Charset = null;
            if (cmdletContext.Message_Body_Text_Charset != null)
            {
                requestMessage_message_Body_message_Body_Text_text_Charset = cmdletContext.Message_Body_Text_Charset;
            }
            if (requestMessage_message_Body_message_Body_Text_text_Charset != null)
            {
                requestMessage_message_Body_message_Body_Text.Charset = requestMessage_message_Body_message_Body_Text_text_Charset;
                requestMessage_message_Body_message_Body_TextIsNull = false;
            }
            String requestMessage_message_Body_message_Body_Text_text_Data = null;
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
            Content requestMessage_message_Subject = null;
            
             // populate Subject
            bool requestMessage_message_SubjectIsNull = true;
            requestMessage_message_Subject = new Content();
            String requestMessage_message_Subject_subject_Charset = null;
            if (cmdletContext.Message_Subject_Charset != null)
            {
                requestMessage_message_Subject_subject_Charset = cmdletContext.Message_Subject_Charset;
            }
            if (requestMessage_message_Subject_subject_Charset != null)
            {
                requestMessage_message_Subject.Charset = requestMessage_message_Subject_subject_Charset;
                requestMessage_message_SubjectIsNull = false;
            }
            String requestMessage_message_Subject_subject_Data = null;
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
            if (cmdletContext.Source != null)
            {
                request.Source = cmdletContext.Source;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.SendEmail(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<String> Destination_BccAddresses { get; set; }
            public List<String> Destination_CcAddresses { get; set; }
            public List<String> Destination_ToAddresses { get; set; }
            public String Message_Body_Html_Charset { get; set; }
            public String Message_Body_Html_Data { get; set; }
            public String Message_Body_Text_Charset { get; set; }
            public String Message_Body_Text_Data { get; set; }
            public String Message_Subject_Charset { get; set; }
            public String Message_Subject_Data { get; set; }
            public List<String> ReplyToAddresses { get; set; }
            public String ReturnPath { get; set; }
            public String Source { get; set; }
        }
        
    }
}
