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
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace Amazon.PowerShell.Cmdlets.SES
{
    /// <summary>
    /// Composes an email message and immediately queues it for sending.
    /// 
    ///  
    /// <para>
    /// This operation is more flexible than the <code>SendEmail</code> API operation. When
    /// you use the <code>SendRawEmail</code> operation, you can specify the headers of the
    /// message as well as its content. This flexibility is useful, for example, when you
    /// want to send a multipart MIME email (such a message that contains both a text and
    /// an HTML version). You can also use this operation to send messages that include attachments.
    /// </para><para>
    /// The <code>SendRawEmail</code> operation has the following requirements:
    /// </para><ul><li><para>
    /// You can only send email from <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/verify-addresses-and-domains.html">verified
    /// email addresses or domains</a>. If you try to send email from an address that isn't
    /// verified, the operation results in an "Email address not verified" error.
    /// </para></li><li><para>
    /// If your account is still in the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/request-production-access.html">Amazon
    /// SES sandbox</a>, you can only send email to other verified addresses in your account,
    /// or to addresses that are associated with the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/mailbox-simulator.html">Amazon
    /// SES mailbox simulator</a>.
    /// </para></li><li><para>
    /// The maximum message size, including attachments, is 10 MB.
    /// </para></li><li><para>
    /// Each message has to include at least one recipient address. A recipient address includes
    /// any address on the To:, CC:, or BCC: lines.
    /// </para></li><li><para>
    /// If you send a single message to more than one recipient address, and one of the recipient
    /// addresses isn't in a valid format (that is, it's not in the format <i>UserName@[SubDomain.]Domain.TopLevelDomain</i>),
    /// Amazon SES rejects the entire message, even if the other addresses are valid.
    /// </para></li><li><para>
    /// Each message can include up to 50 recipient addresses across the To:, CC:, or BCC:
    /// lines. If you need to send a single message to more than 50 recipients, you have to
    /// split the list of recipient addresses into groups of less than 50 recipients, and
    /// send separate messages to each group.
    /// </para></li><li><para>
    /// Amazon SES allows you to specify 8-bit Content-Transfer-Encoding for MIME message
    /// parts. However, if Amazon SES has to modify the contents of your message (for example,
    /// if you use open and click tracking), 8-bit content isn't preserved. For this reason,
    /// we highly recommend that you encode all content that isn't 7-bit ASCII. For more information,
    /// see <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/send-email-raw.html#send-email-mime-encoding">MIME
    /// Encoding</a> in the <i>Amazon SES Developer Guide</i>.
    /// </para></li></ul><para>
    /// Additionally, keep the following considerations in mind when using the <code>SendRawEmail</code>
    /// operation:
    /// </para><ul><li><para>
    /// Although you can customize the message headers when using the <code>SendRawEmail</code>
    /// operation, Amazon SES will automatically apply its own <code>Message-ID</code> and
    /// <code>Date</code> headers; if you passed these headers when creating the message,
    /// they will be overwritten by the values that Amazon SES provides.
    /// </para></li><li><para>
    /// If you are using sending authorization to send on behalf of another user, <code>SendRawEmail</code>
    /// enables you to specify the cross-account identity for the email's Source, From, and
    /// Return-Path parameters in one of two ways: you can pass optional parameters <code>SourceArn</code>,
    /// <code>FromArn</code>, and/or <code>ReturnPathArn</code> to the API, or you can include
    /// the following X-headers in the header of your raw email:
    /// </para><ul><li><para><code>X-SES-SOURCE-ARN</code></para></li><li><para><code>X-SES-FROM-ARN</code></para></li><li><para><code>X-SES-RETURN-PATH-ARN</code></para></li></ul><important><para>
    /// Do not include these X-headers in the DKIM signature; Amazon SES will remove them
    /// before sending the email.
    /// </para></important><para>
    /// For most common sending authorization scenarios, we recommend that you specify the
    /// <code>SourceIdentityArn</code> parameter and not the <code>FromIdentityArn</code>
    /// or <code>ReturnPathIdentityArn</code> parameters. If you only specify the <code>SourceIdentityArn</code>
    /// parameter, Amazon SES will set the From and Return Path addresses to the identity
    /// specified in <code>SourceIdentityArn</code>. For more information about sending authorization,
    /// see the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/sending-authorization.html">Using
    /// Sending Authorization with Amazon SES</a> in the <i>Amazon SES Developer Guide.</i></para></li><li><para>
    /// For every message that you send, the total number of recipients (including each recipient
    /// in the To:, CC: and BCC: fields) is counted against the maximum number of emails you
    /// can send in a 24-hour period (your <i>sending quota</i>). For more information about
    /// sending quotas in Amazon SES, see <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/manage-sending-limits.html">Managing
    /// Your Amazon SES Sending Limits</a> in the <i>Amazon SES Developer Guide.</i></para></li></ul>
    /// </summary>
    [Cmdlet("Send", "SESRawEmail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Email Service SendRawEmail API operation.", Operation = new[] {"SendRawEmail"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.SimpleEmail.Model.SendRawEmailResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendSESRawEmailCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set to use when you send an email using <code>SendRawEmail</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationSetName { get; set; }
        #endregion
        
        #region Parameter RawMessage_Data
        /// <summary>
        /// <para>
        /// <para>The raw data of the message. This data needs to base64-encoded if you are accessing
        /// Amazon SES directly through the HTTPS interface. If you are accessing Amazon SES using
        /// an AWS SDK, the SDK takes care of the base 64-encoding for you. In all cases, the
        /// client must ensure that the message format complies with Internet email standards
        /// regarding email header fields, MIME types, and MIME encoding.</para><para>The To:, CC:, and BCC: headers in the raw message can contain a group list.</para><para>If you are using <code>SendRawEmail</code> with sending authorization, you can include
        /// X-headers in the raw message to specify the "Source," "From," and "Return-Path" addresses.
        /// For more information, see the documentation for <code>SendRawEmail</code>. </para><important><para>Do not include these X-headers in the DKIM signature, because they are removed by
        /// Amazon SES before sending the email.</para></important><para>For more information, go to the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/send-email-raw.html">Amazon
        /// SES Developer Guide</a>.</para>
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
        /// both.)</para><note><para>Amazon SES does not support the SMTPUTF8 extension, as described in<a href="https://tools.ietf.org/html/rfc6531">RFC6531</a>.
        /// For this reason, the <i>local part</i> of a source email address (the part of the
        /// email address that precedes the @ sign) may only contain <a href="https://en.wikipedia.org/wiki/Email_address#Local-part">7-bit
        /// ASCII characters</a>. If the <i>domain part</i> of an address (the part after the
        /// @ sign) contains non-ASCII characters, they must be encoded using Punycode, as described
        /// in <a href="https://tools.ietf.org/html/rfc3492.html">RFC3492</a>. The sender name
        /// (also known as the <i>friendly name</i>) may contain non-ASCII characters. These characters
        /// must be encoded using MIME encoded-word syntax, as described in <a href="https://tools.ietf.org/html/rfc2047">RFC
        /// 2047</a>. MIME encoded-word syntax uses the following form: <code>=?charset?encoding?encoded-text?=</code>.</para></note><para>If you specify the <code>Source</code> parameter and have feedback forwarding enabled,
        /// then bounces and complaints will be sent to this email address. This takes precedence
        /// over any Return-Path header that you might include in the raw text of the message.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags, in the form of name/value pairs, to apply to an email that you send
        /// using <code>SendRawEmail</code>. Tags correspond to characteristics of the email that
        /// you define, so that you can publish email sending events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.SimpleEmail.Model.MessageTag[] Tag { get; set; }
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ConfigurationSetName = this.ConfigurationSetName;
            if (this.Destination != null)
            {
                context.Destinations = new List<System.String>(this.Destination);
            }
            context.FromArn = this.FromArn;
            context.RawMessage_Data = this.RawMessage_Data;
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
            var request = new Amazon.SimpleEmail.Model.SendRawEmailRequest();
            
            if (cmdletContext.ConfigurationSetName != null)
            {
                request.ConfigurationSetName = cmdletContext.ConfigurationSetName;
            }
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
        
        private Amazon.SimpleEmail.Model.SendRawEmailResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.SendRawEmailRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service", "SendRawEmail");
            try
            {
                #if DESKTOP
                return client.SendRawEmail(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SendRawEmailAsync(request);
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
            public List<System.String> Destinations { get; set; }
            public System.String FromArn { get; set; }
            public System.IO.MemoryStream RawMessage_Data { get; set; }
            public System.String ReturnPathArn { get; set; }
            public System.String Source { get; set; }
            public System.String SourceArn { get; set; }
            public List<Amazon.SimpleEmail.Model.MessageTag> Tags { get; set; }
        }
        
    }
}
