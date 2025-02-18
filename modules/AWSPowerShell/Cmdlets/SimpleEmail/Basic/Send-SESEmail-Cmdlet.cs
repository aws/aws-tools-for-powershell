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
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace Amazon.PowerShell.Cmdlets.SES
{
    /// <summary>
    /// Composes an email message and immediately queues it for sending. To send email using
    /// this operation, your message must meet the following requirements:
    /// 
    ///  <ul><li><para>
    /// The message must be sent from a verified email address or domain. If you attempt to
    /// send email using a non-verified address or domain, the operation results in an "Email
    /// address not verified" error. 
    /// </para></li><li><para>
    /// If your account is still in the Amazon SES sandbox, you may only send to verified
    /// addresses or domains, or to email addresses associated with the Amazon SES Mailbox
    /// Simulator. For more information, see <a href="https://docs.aws.amazon.com/ses/latest/dg/verify-addresses-and-domains.html">Verifying
    /// Email Addresses and Domains</a> in the <i>Amazon SES Developer Guide.</i></para></li><li><para>
    /// The maximum message size is 10 MB.
    /// </para></li><li><para>
    /// The message must include at least one recipient email address. The recipient address
    /// can be a To: address, a CC: address, or a BCC: address. If a recipient email address
    /// is invalid (that is, it is not in the format <i>UserName@[SubDomain.]Domain.TopLevelDomain</i>),
    /// the entire message is rejected, even if the message contains other recipients that
    /// are valid.
    /// </para></li><li><para>
    /// The message may not include more than 50 recipients, across the To:, CC: and BCC:
    /// fields. If you need to send an email message to a larger audience, you can divide
    /// your recipient list into groups of 50 or fewer, and then call the <c>SendEmail</c>
    /// operation several times to send the message to each group.
    /// </para></li></ul><important><para>
    /// For every message that you send, the total number of recipients (including each recipient
    /// in the To:, CC: and BCC: fields) is counted against the maximum number of emails you
    /// can send in a 24-hour period (your <i>sending quota</i>). For more information about
    /// sending quotas in Amazon SES, see <a href="https://docs.aws.amazon.com/ses/latest/dg/manage-sending-quotas.html">Managing
    /// Your Amazon SES Sending Limits</a> in the <i>Amazon SES Developer Guide.</i></para></important>
    /// </summary>
    [Cmdlet("Send", "SESEmail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Email Service (SES) SendEmail API operation.", Operation = new[] {"SendEmail"}, SelectReturnType = typeof(Amazon.SimpleEmail.Model.SendEmailResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleEmail.Model.SendEmailResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SimpleEmail.Model.SendEmailResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SendSESEmailCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Destination_BccAddress
        /// <summary>
        /// <para>
        /// <para>The recipients to place on the BCC: line of the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Destination_BccAddresses")]
        public System.String[] Destination_BccAddress { get; set; }
        #endregion
        
        #region Parameter Destination_CcAddress
        /// <summary>
        /// <para>
        /// <para>The recipients to place on the CC: line of the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Destination_CcAddresses")]
        public System.String[] Destination_CcAddress { get; set; }
        #endregion
        
        #region Parameter Html_Charset
        /// <summary>
        /// <para>
        /// <para>The character set of the content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Message_Body_Html_Charset")]
        public System.String Html_Charset { get; set; }
        #endregion
        
        #region Parameter Text_Charset
        /// <summary>
        /// <para>
        /// <para>The character set of the content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Message_Body_Text_Charset")]
        public System.String Text_Charset { get; set; }
        #endregion
        
        #region Parameter Subject_Charset
        /// <summary>
        /// <para>
        /// <para>The character set of the content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Message_Subject_Charset")]
        public System.String Subject_Charset { get; set; }
        #endregion
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set to use when you send an email using <c>SendEmail</c>.</para>
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Message_Body_Html_Data")]
        public System.String Html_Data { get; set; }
        #endregion
        
        #region Parameter Text_Data
        /// <summary>
        /// <para>
        /// <para>The textual data of the content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Message_Body_Text_Data")]
        public System.String Text_Data { get; set; }
        #endregion
        
        #region Parameter Subject_Data
        /// <summary>
        /// <para>
        /// <para>The textual data of the content.</para>
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
        [Alias("Message_Subject_Data")]
        public System.String Subject_Data { get; set; }
        #endregion
        
        #region Parameter ReplyToAddress
        /// <summary>
        /// <para>
        /// <para>The reply-to email address(es) for the message. If the recipient replies to the message,
        /// each reply-to address receives the reply.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReplyToAddresses")]
        public System.String[] ReplyToAddress { get; set; }
        #endregion
        
        #region Parameter ReturnPath
        /// <summary>
        /// <para>
        /// <para>The email address that bounces and complaints are forwarded to when feedback forwarding
        /// is enabled. If the message cannot be delivered to the recipient, then an error message
        /// is returned from the recipient's ISP; this message is forwarded to the email address
        /// specified by the <c>ReturnPath</c> parameter. The <c>ReturnPath</c> parameter is never
        /// overwritten. This email address must be either individually verified with Amazon SES,
        /// or from a domain that has been verified with Amazon SES. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReturnPath { get; set; }
        #endregion
        
        #region Parameter ReturnPathArn
        /// <summary>
        /// <para>
        /// <para>This parameter is used only for sending authorization. It is the ARN of the identity
        /// that is associated with the sending authorization policy that permits you to use the
        /// email address specified in the <c>ReturnPath</c> parameter.</para><para>For example, if the owner of <c>example.com</c> (which has ARN <c>arn:aws:ses:us-east-1:123456789012:identity/example.com</c>)
        /// attaches a policy to it that authorizes you to use <c>feedback@example.com</c>, then
        /// you would specify the <c>ReturnPathArn</c> to be <c>arn:aws:ses:us-east-1:123456789012:identity/example.com</c>,
        /// and the <c>ReturnPath</c> to be <c>feedback@example.com</c>.</para><para>For more information about sending authorization, see the <a href="https://docs.aws.amazon.com/ses/latest/dg/sending-authorization.html">Amazon
        /// SES Developer Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReturnPathArn { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The email address that is sending the email. This email address must be either individually
        /// verified with Amazon SES, or from a domain that has been verified with Amazon SES.
        /// For information about verifying identities, see the <a href="https://docs.aws.amazon.com/ses/latest/dg/creating-identities.html">Amazon
        /// SES Developer Guide</a>.</para><para>If you are sending on behalf of another user and have been permitted to do so by a
        /// sending authorization policy, then you must also specify the <c>SourceArn</c> parameter.
        /// For more information about sending authorization, see the <a href="https://docs.aws.amazon.com/ses/latest/dg/sending-authorization.html">Amazon
        /// SES Developer Guide</a>.</para><note><para>Amazon SES does not support the SMTPUTF8 extension, as described in <a href="https://tools.ietf.org/html/rfc6531">RFC6531</a>.
        /// For this reason, the email address string must be 7-bit ASCII. If you want to send
        /// to or from email addresses that contain Unicode characters in the domain part of an
        /// address, you must encode the domain using Punycode. Punycode is not permitted in the
        /// local part of the email address (the part before the @ sign) nor in the "friendly
        /// from" name. If you want to use Unicode characters in the "friendly from" name, you
        /// must encode the "friendly from" name using MIME encoded-word syntax, as described
        /// in <a href="https://docs.aws.amazon.com/ses/latest/dg/send-email-raw.html">Sending
        /// raw email using the Amazon SES API</a>. For more information about Punycode, see <a href="http://tools.ietf.org/html/rfc3492">RFC 3492</a>.</para></note>
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
        public System.String Source { get; set; }
        #endregion
        
        #region Parameter SourceArn
        /// <summary>
        /// <para>
        /// <para>This parameter is used only for sending authorization. It is the ARN of the identity
        /// that is associated with the sending authorization policy that permits you to send
        /// for the email address specified in the <c>Source</c> parameter.</para><para>For example, if the owner of <c>example.com</c> (which has ARN <c>arn:aws:ses:us-east-1:123456789012:identity/example.com</c>)
        /// attaches a policy to it that authorizes you to send from <c>user@example.com</c>,
        /// then you would specify the <c>SourceArn</c> to be <c>arn:aws:ses:us-east-1:123456789012:identity/example.com</c>,
        /// and the <c>Source</c> to be <c>user@example.com</c>.</para><para>For more information about sending authorization, see the <a href="https://docs.aws.amazon.com/ses/latest/dg/sending-authorization.html">Amazon
        /// SES Developer Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags, in the form of name/value pairs, to apply to an email that you send
        /// using <c>SendEmail</c>. Tags correspond to characteristics of the email that you define,
        /// so that you can publish email sending events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SimpleEmail.Model.MessageTag[] Tag { get; set; }
        #endregion
        
        #region Parameter Destination_ToAddress
        /// <summary>
        /// <para>
        /// <para>The recipients to place on the To: line of the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("Destination_ToAddresses")]
        public System.String[] Destination_ToAddress { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MessageId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmail.Model.SendEmailResponse).
        /// Specifying the name of a property of type Amazon.SimpleEmail.Model.SendEmailResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Source), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SESEmail (SendEmail)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmail.Model.SendEmailResponse, SendSESEmailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationSetName = this.ConfigurationSetName;
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
            context.Html_Charset = this.Html_Charset;
            context.Html_Data = this.Html_Data;
            context.Text_Charset = this.Text_Charset;
            context.Text_Data = this.Text_Data;
            context.Subject_Charset = this.Subject_Charset;
            context.Subject_Data = this.Subject_Data;
            #if MODULAR
            if (this.Subject_Data == null && ParameterWasBound(nameof(this.Subject_Data)))
            {
                WriteWarning("You are passing $null as a value for parameter Subject_Data which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ReplyToAddress != null)
            {
                context.ReplyToAddress = new List<System.String>(this.ReplyToAddress);
            }
            context.ReturnPath = this.ReturnPath;
            context.ReturnPathArn = this.ReturnPathArn;
            context.Source = this.Source;
            #if MODULAR
            if (this.Source == null && ParameterWasBound(nameof(this.Source)))
            {
                WriteWarning("You are passing $null as a value for parameter Source which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceArn = this.SourceArn;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SimpleEmail.Model.MessageTag>(this.Tag);
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
            var requestDestinationIsNull = true;
            request.Destination = new Amazon.SimpleEmail.Model.Destination();
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
            
             // populate Message
            var requestMessageIsNull = true;
            request.Message = new Amazon.SimpleEmail.Model.Message();
            Amazon.SimpleEmail.Model.Body requestMessage_message_Body = null;
            
             // populate Body
            var requestMessage_message_BodyIsNull = true;
            requestMessage_message_Body = new Amazon.SimpleEmail.Model.Body();
            Amazon.SimpleEmail.Model.Content requestMessage_message_Body_message_Body_Html = null;
            
             // populate Html
            var requestMessage_message_Body_message_Body_HtmlIsNull = true;
            requestMessage_message_Body_message_Body_Html = new Amazon.SimpleEmail.Model.Content();
            System.String requestMessage_message_Body_message_Body_Html_html_Charset = null;
            if (cmdletContext.Html_Charset != null)
            {
                requestMessage_message_Body_message_Body_Html_html_Charset = cmdletContext.Html_Charset;
            }
            if (requestMessage_message_Body_message_Body_Html_html_Charset != null)
            {
                requestMessage_message_Body_message_Body_Html.Charset = requestMessage_message_Body_message_Body_Html_html_Charset;
                requestMessage_message_Body_message_Body_HtmlIsNull = false;
            }
            System.String requestMessage_message_Body_message_Body_Html_html_Data = null;
            if (cmdletContext.Html_Data != null)
            {
                requestMessage_message_Body_message_Body_Html_html_Data = cmdletContext.Html_Data;
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
            var requestMessage_message_Body_message_Body_TextIsNull = true;
            requestMessage_message_Body_message_Body_Text = new Amazon.SimpleEmail.Model.Content();
            System.String requestMessage_message_Body_message_Body_Text_text_Charset = null;
            if (cmdletContext.Text_Charset != null)
            {
                requestMessage_message_Body_message_Body_Text_text_Charset = cmdletContext.Text_Charset;
            }
            if (requestMessage_message_Body_message_Body_Text_text_Charset != null)
            {
                requestMessage_message_Body_message_Body_Text.Charset = requestMessage_message_Body_message_Body_Text_text_Charset;
                requestMessage_message_Body_message_Body_TextIsNull = false;
            }
            System.String requestMessage_message_Body_message_Body_Text_text_Data = null;
            if (cmdletContext.Text_Data != null)
            {
                requestMessage_message_Body_message_Body_Text_text_Data = cmdletContext.Text_Data;
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
            var requestMessage_message_SubjectIsNull = true;
            requestMessage_message_Subject = new Amazon.SimpleEmail.Model.Content();
            System.String requestMessage_message_Subject_subject_Charset = null;
            if (cmdletContext.Subject_Charset != null)
            {
                requestMessage_message_Subject_subject_Charset = cmdletContext.Subject_Charset;
            }
            if (requestMessage_message_Subject_subject_Charset != null)
            {
                requestMessage_message_Subject.Charset = requestMessage_message_Subject_subject_Charset;
                requestMessage_message_SubjectIsNull = false;
            }
            System.String requestMessage_message_Subject_subject_Data = null;
            if (cmdletContext.Subject_Data != null)
            {
                requestMessage_message_Subject_subject_Data = cmdletContext.Subject_Data;
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
            if (cmdletContext.ReplyToAddress != null)
            {
                request.ReplyToAddresses = cmdletContext.ReplyToAddress;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SimpleEmail.Model.SendEmailResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.SendEmailRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service (SES)", "SendEmail");
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
            public List<System.String> Destination_BccAddress { get; set; }
            public List<System.String> Destination_CcAddress { get; set; }
            public List<System.String> Destination_ToAddress { get; set; }
            public System.String Html_Charset { get; set; }
            public System.String Html_Data { get; set; }
            public System.String Text_Charset { get; set; }
            public System.String Text_Data { get; set; }
            public System.String Subject_Charset { get; set; }
            public System.String Subject_Data { get; set; }
            public List<System.String> ReplyToAddress { get; set; }
            public System.String ReturnPath { get; set; }
            public System.String ReturnPathArn { get; set; }
            public System.String Source { get; set; }
            public System.String SourceArn { get; set; }
            public List<Amazon.SimpleEmail.Model.MessageTag> Tag { get; set; }
            public System.Func<Amazon.SimpleEmail.Model.SendEmailResponse, SendSESEmailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageId;
        }
        
    }
}
