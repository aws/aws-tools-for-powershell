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
    /// Sends an email message, with header and content specified by the client. The <code>SendRawEmail</code>
    /// action is useful for sending multipart MIME emails. The raw text of the message must
    /// comply with Internet email standards; otherwise, the message cannot be sent. 
    /// 
    ///  
    /// <para>
    /// There are several important points to know about <code>SendRawEmail</code>:
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
    /// The To:, CC:, and BCC: headers in the raw message can contain a group list. Note that
    /// each recipient in a group list counts towards the 50-recipient limit.
    /// </para></li><li><para>
    /// For every message that you send, the total number of recipients (To:, CC: and BCC:)
    /// is counted against your sending quota - the maximum number of emails you can send
    /// in a 24-hour period. For information about your sending quota, go to the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/manage-sending-limits.html">Amazon
    /// SES Developer Guide</a>.
    /// </para></li><li><para>
    /// If you are using sending authorization to send on behalf of another user, <code>SendRawEmail</code>
    /// enables you to specify the cross-account identity for the email's "Source," "From,"
    /// and "Return-Path" parameters in one of two ways: you can pass optional parameters
    /// <code>SourceArn</code>, <code>FromArn</code>, and/or <code>ReturnPathArn</code> to
    /// the API, or you can include the following X-headers in the header of your raw email:
    /// </para><ul><li><para><code>X-SES-SOURCE-ARN</code></para></li><li><para><code>X-SES-FROM-ARN</code></para></li><li><para><code>X-SES-RETURN-PATH-ARN</code></para></li></ul><important><para>
    /// Do not include these X-headers in the DKIM signature, because they are removed by
    /// Amazon SES before sending the email.
    /// </para></important><para>
    /// For the most common sending authorization use case, we recommend that you specify
    /// the <code>SourceIdentityArn</code> and do not specify either the <code>FromIdentityArn</code>
    /// or <code>ReturnPathIdentityArn</code>. (The same note applies to the corresponding
    /// X-headers.) If you only specify the <code>SourceIdentityArn</code>, Amazon SES will
    /// simply set the "From" address and the "Return Path" address to the identity specified
    /// in <code>SourceIdentityArn</code>. For more information about sending authorization,
    /// see the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/sending-authorization.html">Amazon
    /// SES Developer Guide</a>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Send", "SESRawEmail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the SendRawEmail operation against Amazon Simple Email Service.", Operation = new[] {"SendRawEmail"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.SimpleEmail.Model.SendRawEmailResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class SendSESRawEmailCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        #region Parameter RawMessage_Data
        /// <summary>
        /// <para>
        /// <para>The raw data of the message. The client must ensure that the message format complies
        /// with Internet email standards regarding email header fields, MIME types, MIME encoding,
        /// and base64 encoding (if necessary).</para><para>The To:, CC:, and BCC: headers in the raw message can contain a group list.</para><para>If you are using <code>SendRawEmail</code> with sending authorization, you can include
        /// X-headers in the raw message to specify the "Source," "From," and "Return-Path" addresses.
        /// For more information, see the documentation for <code>SendRawEmail</code>. </para><important><para>Do not include these X-headers in the DKIM signature, because they are removed by
        /// Amazon SES before sending the email.</para></important><para>For more information, go to the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/send-email-raw.html">Amazon
        /// SES Developer Guide</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.IO.MemoryStream RawMessage_Data { get; set; }
        #endregion
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para>A list of destinations for the message, consisting of To:, CC:, and BCC: addresses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Destinations")]
        public System.String[] Destination { get; set; }
        #endregion
        
        #region Parameter FromArn
        /// <summary>
        /// <para>
        /// <para>This parameter is used only for sending authorization. It is the ARN of the identity
        /// that is associated with the sending authorization policy that permits you to specify
        /// a particular "From" address in the header of the raw email.</para><para>Instead of using this parameter, you can use the X-header <code>X-SES-FROM-ARN</code>
        /// in the raw message of the email. If you use both the <code>FromArn</code> parameter
        /// and the corresponding X-header, Amazon SES uses the value of the <code>FromArn</code>
        /// parameter.</para><note><para>For information about when to use this parameter, see the description of <code>SendRawEmail</code>
        /// in this guide, or see the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/sending-authorization-delegate-sender-tasks-email.html">Amazon
        /// SES Developer Guide</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FromArn { get; set; }
        #endregion
        
        #region Parameter ReturnPathArn
        /// <summary>
        /// <para>
        /// <para>This parameter is used only for sending authorization. It is the ARN of the identity
        /// that is associated with the sending authorization policy that permits you to use the
        /// email address specified in the <code>ReturnPath</code> parameter.</para><para>For example, if the owner of <code>example.com</code> (which has ARN <code>arn:aws:ses:us-east-1:123456789012:identity/example.com</code>)
        /// attaches a policy to it that authorizes you to use <code>feedback@example.com</code>,
        /// then you would specify the <code>ReturnPathArn</code> to be <code>arn:aws:ses:us-east-1:123456789012:identity/example.com</code>,
        /// and the <code>ReturnPath</code> to be <code>feedback@example.com</code>.</para><para>Instead of using this parameter, you can use the X-header <code>X-SES-RETURN-PATH-ARN</code>
        /// in the raw message of the email. If you use both the <code>ReturnPathArn</code> parameter
        /// and the corresponding X-header, Amazon SES uses the value of the <code>ReturnPathArn</code>
        /// parameter.</para><note><para>For information about when to use this parameter, see the description of <code>SendRawEmail</code>
        /// in this guide, or see the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/sending-authorization-delegate-sender-tasks-email.html">Amazon
        /// SES Developer Guide</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ReturnPathArn { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The identity's email address. If you do not provide a value for this parameter, you
        /// must specify a "From" address in the raw text of the message. (You can also specify
        /// both.)</para><para> By default, the string must be 7-bit ASCII. If the text must contain any other characters,
        /// then you must use MIME encoded-word syntax (RFC 2047) instead of a literal string.
        /// MIME encoded-word syntax uses the following form: <code>=?charset?encoding?encoded-text?=</code>.
        /// For more information, see <a href="http://tools.ietf.org/html/rfc2047">RFC 2047</a>.
        /// </para><note><para>If you specify the <code>Source</code> parameter and have feedback forwarding enabled,
        /// then bounces and complaints will be sent to this email address. This takes precedence
        /// over any <i>Return-Path</i> header that you might include in the raw text of the message.</para></note>
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
        /// and the <code>Source</code> to be <code>user@example.com</code>.</para><para>Instead of using this parameter, you can use the X-header <code>X-SES-SOURCE-ARN</code>
        /// in the raw message of the email. If you use both the <code>SourceArn</code> parameter
        /// and the corresponding X-header, Amazon SES uses the value of the <code>SourceArn</code>
        /// parameter.</para><note><para>For information about when to use this parameter, see the description of <code>SendRawEmail</code>
        /// in this guide, or see the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/sending-authorization-delegate-sender-tasks-email.html">Amazon
        /// SES Developer Guide</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceArn { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SESRawEmail (SendRawEmail)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.Destination != null)
            {
                context.Destinations = new List<System.String>(this.Destination);
            }
            context.FromArn = this.FromArn;
            context.RawMessage_Data = this.RawMessage_Data;
            context.ReturnPathArn = this.ReturnPathArn;
            context.Source = this.Source;
            context.SourceArn = this.SourceArn;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.SimpleEmail.Model.SendRawEmailRequest();
            
            if (cmdletContext.Destinations != null)
            {
                request.Destinations = cmdletContext.Destinations;
            }
            if (cmdletContext.FromArn != null)
            {
                request.FromArn = cmdletContext.FromArn;
            }
            
             // populate RawMessage
            bool requestRawMessageIsNull = true;
            request.RawMessage = new Amazon.SimpleEmail.Model.RawMessage();
            System.IO.MemoryStream requestRawMessage_rawMessage_Data = null;
            if (cmdletContext.RawMessage_Data != null)
            {
                requestRawMessage_rawMessage_Data = cmdletContext.RawMessage_Data;
            }
            if (requestRawMessage_rawMessage_Data != null)
            {
                request.RawMessage.Data = requestRawMessage_rawMessage_Data;
                requestRawMessageIsNull = false;
            }
             // determine if request.RawMessage should be set to null
            if (requestRawMessageIsNull)
            {
                request.RawMessage = null;
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
        
        private static Amazon.SimpleEmail.Model.SendRawEmailResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.SendRawEmailRequest request)
        {
            return client.SendRawEmail(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> Destinations { get; set; }
            public System.String FromArn { get; set; }
            public System.IO.MemoryStream RawMessage_Data { get; set; }
            public System.String ReturnPathArn { get; set; }
            public System.String Source { get; set; }
            public System.String SourceArn { get; set; }
        }
        
    }
}
