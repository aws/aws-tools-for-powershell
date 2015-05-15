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
    ///  <important> You can only send email from verified email addresses and domains. If
    /// you have not requested production access to Amazon SES, you must also verify every
    /// recipient email address except for the recipients provided by the Amazon SES mailbox
    /// simulator. For more information, go to the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/verify-addresses-and-domains.html">Amazon
    /// SES Developer Guide</a>. </important><para>
    /// The total size of the message cannot exceed 10 MB. This includes any attachments that
    /// are part of the message.
    /// </para><para>
    /// Amazon SES has a limit on the total number of recipients per message: The combined
    /// number of To:, CC: and BCC: email addresses cannot exceed 50. If you need to send
    /// an email message to a larger audience, you can divide your recipient list into groups
    /// of 50 or fewer, and then call Amazon SES repeatedly to send the message to each group.
    /// 
    /// </para><para>
    /// The To:, CC:, and BCC: headers in the raw message can contain a group list. Note that
    /// each recipient in a group list counts towards the 50-recipient limit. 
    /// </para><para>
    /// For every message that you send, the total number of recipients (To:, CC: and BCC:)
    /// is counted against your <i>sending quota</i> - the maximum number of emails you can
    /// send in a 24-hour period. For information about your sending quota, go to the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/manage-sending-limits.html">Amazon
    /// SES Developer Guide</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("Send", "SESRawEmail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the SendRawEmail operation against Amazon Simple Email Service.", Operation = new[] {"SendRawEmail"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type SendRawEmailResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class SendSESRawEmailCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The raw data of the message. The client must ensure that the message format complies
        /// with Internet email standards regarding email header fields, MIME types, MIME encoding,
        /// and base64 encoding (if necessary). </para><para>The To:, CC:, and BCC: headers in the raw message can contain a group list. </para><para>For more information, go to the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/send-email-raw.html">Amazon
        /// SES Developer Guide</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.IO.MemoryStream RawMessage_Data { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of destinations for the message, consisting of To:, CC:, and BCC: addresses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Destinations")]
        public System.String[] Destination { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The identity's email address. If you do not provide a value for this parameter, you
        /// must specify a "From" address in the raw text of the message. (You can also specify
        /// both.)</para><para> By default, the string must be 7-bit ASCII. If the text must contain any other characters,
        /// then you must use MIME encoded-word syntax (RFC 2047) instead of a literal string.
        /// MIME encoded-word syntax uses the following form: <code>=?charset?encoding?encoded-text?=</code>.
        /// For more information, see <a href="http://tools.ietf.org/html/rfc2047">RFC 2047</a>.
        /// </para><note>If you specify the <code>Source</code> parameter and have feedback forwarding
        /// enabled, then bounces and complaints will be sent to this email address. This takes
        /// precedence over any <i>Return-Path</i> header that you might include in the raw text
        /// of the message. </note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String Source { get; set; }
        
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
                context.Destinations = new List<String>(this.Destination);
            }
            context.RawMessage_Data = this.RawMessage_Data;
            context.Source = this.Source;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new SendRawEmailRequest();
            
            if (cmdletContext.Destinations != null)
            {
                request.Destinations = cmdletContext.Destinations;
            }
            
             // populate RawMessage
            bool requestRawMessageIsNull = true;
            request.RawMessage = new RawMessage();
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
            if (cmdletContext.Source != null)
            {
                request.Source = cmdletContext.Source;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.SendRawEmail(request);
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
            public List<String> Destinations { get; set; }
            public System.IO.MemoryStream RawMessage_Data { get; set; }
            public String Source { get; set; }
        }
        
    }
}
