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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SES
{
    /// <summary>
    /// Composes an email message and immediately queues it for sending.
    /// 
    ///  
    /// <para>
    /// This operation is more flexible than the <c>SendEmail</c> operation. When you use
    /// the <c>SendRawEmail</c> operation, you can specify the headers of the message as well
    /// as its content. This flexibility is useful, for example, when you need to send a multipart
    /// MIME email (such a message that contains both a text and an HTML version). You can
    /// also use this operation to send messages that include attachments.
    /// </para><para>
    /// The <c>SendRawEmail</c> operation has the following requirements:
    /// </para><ul><li><para>
    /// You can only send email from <a href="https://docs.aws.amazon.com/ses/latest/dg/verify-addresses-and-domains.html">verified
    /// email addresses or domains</a>. If you try to send email from an address that isn't
    /// verified, the operation results in an "Email address not verified" error.
    /// </para></li><li><para>
    /// If your account is still in the <a href="https://docs.aws.amazon.com/ses/latest/dg/request-production-access.html">Amazon
    /// SES sandbox</a>, you can only send email to other verified addresses in your account,
    /// or to addresses that are associated with the <a href="https://docs.aws.amazon.com/ses/latest/dg/send-an-email-from-console.html">Amazon
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
    /// see <a href="https://docs.aws.amazon.com/ses/latest/dg/send-email-raw.html#send-email-mime-encoding">MIME
    /// Encoding</a> in the <i>Amazon SES Developer Guide</i>.
    /// </para></li></ul><para>
    /// Additionally, keep the following considerations in mind when using the <c>SendRawEmail</c>
    /// operation:
    /// </para><ul><li><para>
    /// Although you can customize the message headers when using the <c>SendRawEmail</c>
    /// operation, Amazon SES automatically applies its own <c>Message-ID</c> and <c>Date</c>
    /// headers; if you passed these headers when creating the message, they are overwritten
    /// by the values that Amazon SES provides.
    /// </para></li><li><para>
    /// If you are using sending authorization to send on behalf of another user, <c>SendRawEmail</c>
    /// enables you to specify the cross-account identity for the email's Source, From, and
    /// Return-Path parameters in one of two ways: you can pass optional parameters <c>SourceArn</c>,
    /// <c>FromArn</c>, and/or <c>ReturnPathArn</c>, or you can include the following X-headers
    /// in the header of your raw email:
    /// </para><ul><li><para><c>X-SES-SOURCE-ARN</c></para></li><li><para><c>X-SES-FROM-ARN</c></para></li><li><para><c>X-SES-RETURN-PATH-ARN</c></para></li></ul><important><para>
    /// Don't include these X-headers in the DKIM signature. Amazon SES removes these before
    /// it sends the email.
    /// </para></important><para>
    /// If you only specify the <c>SourceIdentityArn</c> parameter, Amazon SES sets the From
    /// and Return-Path addresses to the same identity that you specified.
    /// </para><para>
    /// For more information about sending authorization, see the <a href="https://docs.aws.amazon.com/ses/latest/dg/sending-authorization.html">Using
    /// Sending Authorization with Amazon SES</a> in the <i>Amazon SES Developer Guide.</i></para></li><li><para>
    /// For every message that you send, the total number of recipients (including each recipient
    /// in the To:, CC: and BCC: fields) is counted against the maximum number of emails you
    /// can send in a 24-hour period (your <i>sending quota</i>). For more information about
    /// sending quotas in Amazon SES, see <a href="https://docs.aws.amazon.com/ses/latest/dg/manage-sending-quotas.html">Managing
    /// Your Amazon SES Sending Limits</a> in the <i>Amazon SES Developer Guide.</i></para></li></ul>
    /// </summary>
    [Cmdlet("Send", "SESRawEmail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Email Service (SES) SendRawEmail API operation.", Operation = new[] {"SendRawEmail"}, SelectReturnType = typeof(Amazon.SimpleEmail.Model.SendRawEmailResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleEmail.Model.SendRawEmailResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SimpleEmail.Model.SendRawEmailResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SendSESRawEmailCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set to use when you send an email using <c>SendRawEmail</c>.</para>
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
        /// an Amazon Web Services SDK, the SDK takes care of the base 64-encoding for you. In
        /// all cases, the client must ensure that the message format complies with Internet email
        /// standards regarding email header fields, MIME types, and MIME encoding.</para><para>The To:, CC:, and BCC: headers in the raw message can contain a group list.</para><para>If you are using <c>SendRawEmail</c> with sending authorization, you can include X-headers
        /// in the raw message to specify the "Source," "From," and "Return-Path" addresses. For
        /// more information, see the documentation for <c>SendRawEmail</c>. </para><important><para>Do not include these X-headers in the DKIM signature, because they are removed by
        /// Amazon SES before sending the email.</para></important><para>For more information, go to the <a href="https://docs.aws.amazon.com/ses/latest/dg/send-email-raw.html">Amazon
        /// SES Developer Guide</a>.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] RawMessage_Data { get; set; }
        #endregion
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para>A list of destinations for the message, consisting of To:, CC:, and BCC: addresses.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("Destinations")]
        public System.String[] Destination { get; set; }
        #endregion
        
        #region Parameter FromArn
        /// <summary>
        /// <para>
        /// <para>This parameter is used only for sending authorization. It is the ARN of the identity
        /// that is associated with the sending authorization policy that permits you to specify
        /// a particular "From" address in the header of the raw email.</para><para>Instead of using this parameter, you can use the X-header <c>X-SES-FROM-ARN</c> in
        /// the raw message of the email. If you use both the <c>FromArn</c> parameter and the
        /// corresponding X-header, Amazon SES uses the value of the <c>FromArn</c> parameter.</para><note><para>For information about when to use this parameter, see the description of <c>SendRawEmail</c>
        /// in this guide, or see the <a href="https://docs.aws.amazon.com/ses/latest/dg/sending-authorization-delegate-sender-tasks-email.html">Amazon
        /// SES Developer Guide</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FromArn { get; set; }
        #endregion
        
        #region Parameter ReturnPathArn
        /// <summary>
        /// <para>
        /// <para>This parameter is used only for sending authorization. It is the ARN of the identity
        /// that is associated with the sending authorization policy that permits you to use the
        /// email address specified in the <c>ReturnPath</c> parameter.</para><para>For example, if the owner of <c>example.com</c> (which has ARN <c>arn:aws:ses:us-east-1:123456789012:identity/example.com</c>)
        /// attaches a policy to it that authorizes you to use <c>feedback@example.com</c>, then
        /// you would specify the <c>ReturnPathArn</c> to be <c>arn:aws:ses:us-east-1:123456789012:identity/example.com</c>,
        /// and the <c>ReturnPath</c> to be <c>feedback@example.com</c>.</para><para>Instead of using this parameter, you can use the X-header <c>X-SES-RETURN-PATH-ARN</c>
        /// in the raw message of the email. If you use both the <c>ReturnPathArn</c> parameter
        /// and the corresponding X-header, Amazon SES uses the value of the <c>ReturnPathArn</c>
        /// parameter.</para><note><para>For information about when to use this parameter, see the description of <c>SendRawEmail</c>
        /// in this guide, or see the <a href="https://docs.aws.amazon.com/ses/latest/dg/sending-authorization-delegate-sender-tasks-email.html">Amazon
        /// SES Developer Guide</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReturnPathArn { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The identity's email address. If you do not provide a value for this parameter, you
        /// must specify a "From" address in the raw text of the message. (You can also specify
        /// both.)</para><note><para>Amazon SES does not support the SMTPUTF8 extension, as described in<a href="https://tools.ietf.org/html/rfc6531">RFC6531</a>.
        /// For this reason, the email address string must be 7-bit ASCII. If you want to send
        /// to or from email addresses that contain Unicode characters in the domain part of an
        /// address, you must encode the domain using Punycode. Punycode is not permitted in the
        /// local part of the email address (the part before the @ sign) nor in the "friendly
        /// from" name. If you want to use Unicode characters in the "friendly from" name, you
        /// must encode the "friendly from" name using MIME encoded-word syntax, as described
        /// in <a href="https://docs.aws.amazon.com/ses/latest/dg/send-email-raw.html">Sending
        /// raw email using the Amazon SES API</a>. For more information about Punycode, see <a href="http://tools.ietf.org/html/rfc3492">RFC 3492</a>.</para></note><para>If you specify the <c>Source</c> parameter and have feedback forwarding enabled, then
        /// bounces and complaints are sent to this email address. This takes precedence over
        /// any Return-Path header that you might include in the raw text of the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
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
        /// and the <c>Source</c> to be <c>user@example.com</c>.</para><para>Instead of using this parameter, you can use the X-header <c>X-SES-SOURCE-ARN</c>
        /// in the raw message of the email. If you use both the <c>SourceArn</c> parameter and
        /// the corresponding X-header, Amazon SES uses the value of the <c>SourceArn</c> parameter.</para><note><para>For information about when to use this parameter, see the description of <c>SendRawEmail</c>
        /// in this guide, or see the <a href="https://docs.aws.amazon.com/ses/latest/dg/sending-authorization-delegate-sender-tasks-email.html">Amazon
        /// SES Developer Guide</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags, in the form of name/value pairs, to apply to an email that you send
        /// using <c>SendRawEmail</c>. Tags correspond to characteristics of the email that you
        /// define, so that you can publish email sending events.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SimpleEmail.Model.MessageTag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MessageId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmail.Model.SendRawEmailResponse).
        /// Specifying the name of a property of type Amazon.SimpleEmail.Model.SendRawEmailResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Source), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SESRawEmail (SendRawEmail)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmail.Model.SendRawEmailResponse, SendSESRawEmailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationSetName = this.ConfigurationSetName;
            if (this.Destination != null)
            {
                context.Destination = new List<System.String>(this.Destination);
            }
            context.FromArn = this.FromArn;
            context.RawMessage_Data = this.RawMessage_Data;
            #if MODULAR
            if (this.RawMessage_Data == null && ParameterWasBound(nameof(this.RawMessage_Data)))
            {
                WriteWarning("You are passing $null as a value for parameter RawMessage_Data which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReturnPathArn = this.ReturnPathArn;
            context.Source = this.Source;
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
            System.IO.MemoryStream _RawMessage_DataStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.SimpleEmail.Model.SendRawEmailRequest();
                
                if (cmdletContext.ConfigurationSetName != null)
                {
                    request.ConfigurationSetName = cmdletContext.ConfigurationSetName;
                }
                if (cmdletContext.Destination != null)
                {
                    request.Destinations = cmdletContext.Destination;
                }
                if (cmdletContext.FromArn != null)
                {
                    request.FromArn = cmdletContext.FromArn;
                }
                
                 // populate RawMessage
                var requestRawMessageIsNull = true;
                request.RawMessage = new Amazon.SimpleEmail.Model.RawMessage();
                System.IO.MemoryStream requestRawMessage_rawMessage_Data = null;
                if (cmdletContext.RawMessage_Data != null)
                {
                    _RawMessage_DataStream = new System.IO.MemoryStream(cmdletContext.RawMessage_Data);
                    requestRawMessage_rawMessage_Data = _RawMessage_DataStream;
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
            finally
            {
                if( _RawMessage_DataStream != null)
                {
                    _RawMessage_DataStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SimpleEmail.Model.SendRawEmailResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.SendRawEmailRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service (SES)", "SendRawEmail");
            try
            {
                return client.SendRawEmailAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Destination { get; set; }
            public System.String FromArn { get; set; }
            public byte[] RawMessage_Data { get; set; }
            public System.String ReturnPathArn { get; set; }
            public System.String Source { get; set; }
            public System.String SourceArn { get; set; }
            public List<Amazon.SimpleEmail.Model.MessageTag> Tag { get; set; }
            public System.Func<Amazon.SimpleEmail.Model.SendRawEmailResponse, SendSESRawEmailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageId;
        }
        
    }
}
