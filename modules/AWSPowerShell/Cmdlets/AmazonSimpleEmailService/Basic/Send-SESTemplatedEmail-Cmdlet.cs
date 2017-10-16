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
    /// Composes an email message using an email template and immediately queues it for sending.
    /// 
    ///  
    /// <para>
    /// In order to send email using the <code>SendTemplatedEmail</code> operation, your call
    /// to the API must meet the following requirements:
    /// </para><ul><li><para>
    /// The call must refer to an existing email template. You can create email templates
    /// using the <a>CreateTemplate</a> operation.
    /// </para></li><li><para>
    /// The message must be sent from a verified email address or domain.
    /// </para></li><li><para>
    /// If your account is still in the Amazon SES sandbox, you may only send to verified
    /// addresses or domains, or to email addresses associated with the Amazon SES Mailbox
    /// Simulator. For more information, see <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/verify-addresses-and-domains.html">Verifying
    /// Email Addresses and Domains</a> in the <i>Amazon SES Developer Guide.</i></para></li><li><para>
    /// The total size of the message, including attachments, must be less than 10 MB.
    /// </para></li><li><para>
    /// Calls to the <code>SendTemplatedEmail</code> operation may only include one <code>Destination</code>
    /// parameter. A destination is a set of recipients who will receive the same version
    /// of the email. The <code>Destination</code> parameter can include up to 50 recipients,
    /// across the To:, CC: and BCC: fields.
    /// </para></li><li><para>
    /// The <code>Destination</code> parameter must include at least one recipient email address.
    /// The recipient address can be a To: address, a CC: address, or a BCC: address. If a
    /// recipient email address is invalid (that is, it is not in the format <i>UserName@[SubDomain.]Domain.TopLevelDomain</i>),
    /// the entire message will be rejected, even if the message contains other recipients
    /// that are valid.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Send", "SESTemplatedEmail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the SendTemplatedEmail operation against Amazon Simple Email Service.", Operation = new[] {"SendTemplatedEmail"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.SimpleEmail.Model.SendTemplatedEmailResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendSESTemplatedEmailCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
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
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set to use when you send an email using <code>SendTemplatedEmail</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationSetName { get; set; }
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
        /// <para>The email address that bounces and complaints will be forwarded to when feedback forwarding
        /// is enabled. If the message cannot be delivered to the recipient, then an error message
        /// will be returned from the recipient's ISP; this message will then be forwarded to
        /// the email address specified by the <code>ReturnPath</code> parameter. The <code>ReturnPath</code>
        /// parameter is never overwritten. This email address must be either individually verified
        /// with Amazon SES, or from a domain that has been verified with Amazon SES. </para>
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
        /// SES Developer Guide</a>.</para>
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
        /// For more information, see <a href="https://tools.ietf.org/html/rfc2047">RFC 2047</a>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        /// SES Developer Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags, in the form of name/value pairs, to apply to an email that you send
        /// using <code>SendTemplatedEmail</code>. Tags correspond to characteristics of the email
        /// that you define, so that you can publish email sending events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.SimpleEmail.Model.MessageTag[] Tag { get; set; }
        #endregion
        
        #region Parameter Template
        /// <summary>
        /// <para>
        /// <para>The template to use when sending this email.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Template { get; set; }
        #endregion
        
        #region Parameter TemplateArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the template to use when sending this email.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TemplateArn { get; set; }
        #endregion
        
        #region Parameter TemplateData
        /// <summary>
        /// <para>
        /// <para>A list of replacement values to apply to the template. This parameter is a JSON object,
        /// typically consisting of key-value pairs in which the keys correspond to replacement
        /// tags in the email template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String TemplateData { get; set; }
        #endregion
        
        #region Parameter Destination_ToAddress
        /// <summary>
        /// <para>
        /// <para>The To: field(s) of the message.</para>
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Source", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SESTemplatedEmail (SendTemplatedEmail)"))
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
            context.Template = this.Template;
            context.TemplateArn = this.TemplateArn;
            context.TemplateData = this.TemplateData;
            
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
            var request = new Amazon.SimpleEmail.Model.SendTemplatedEmailRequest();
            
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
            if (cmdletContext.Template != null)
            {
                request.Template = cmdletContext.Template;
            }
            if (cmdletContext.TemplateArn != null)
            {
                request.TemplateArn = cmdletContext.TemplateArn;
            }
            if (cmdletContext.TemplateData != null)
            {
                request.TemplateData = cmdletContext.TemplateData;
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
        
        private Amazon.SimpleEmail.Model.SendTemplatedEmailResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.SendTemplatedEmailRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service", "SendTemplatedEmail");
            try
            {
                #if DESKTOP
                return client.SendTemplatedEmail(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SendTemplatedEmailAsync(request);
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
            public List<System.String> Destination_BccAddresses { get; set; }
            public List<System.String> Destination_CcAddresses { get; set; }
            public List<System.String> Destination_ToAddresses { get; set; }
            public List<System.String> ReplyToAddresses { get; set; }
            public System.String ReturnPath { get; set; }
            public System.String ReturnPathArn { get; set; }
            public System.String Source { get; set; }
            public System.String SourceArn { get; set; }
            public List<Amazon.SimpleEmail.Model.MessageTag> Tags { get; set; }
            public System.String Template { get; set; }
            public System.String TemplateArn { get; set; }
            public System.String TemplateData { get; set; }
        }
        
    }
}
