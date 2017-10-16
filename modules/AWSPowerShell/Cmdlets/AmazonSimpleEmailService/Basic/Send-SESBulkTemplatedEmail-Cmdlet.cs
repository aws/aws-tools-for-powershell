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
    /// Composes an email message to multiple destinations. The message body is created using
    /// an email template.
    /// 
    ///  
    /// <para>
    /// In order to send email using the <code>SendBulkTemplatedEmail</code> operation, your
    /// call to the API must meet the following requirements:
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
    /// Each <code>Destination</code> parameter must include at least one recipient email
    /// address. The recipient address can be a To: address, a CC: address, or a BCC: address.
    /// If a recipient email address is invalid (that is, it is not in the format <i>UserName@[SubDomain.]Domain.TopLevelDomain</i>),
    /// the entire message will be rejected, even if the message contains other recipients
    /// that are valid.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Send", "SESBulkTemplatedEmail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleEmail.Model.BulkEmailDestinationStatus")]
    [AWSCmdlet("Invokes the SendBulkTemplatedEmail operation against Amazon Simple Email Service.", Operation = new[] {"SendBulkTemplatedEmail"})]
    [AWSCmdletOutput("Amazon.SimpleEmail.Model.BulkEmailDestinationStatus",
        "This cmdlet returns a collection of BulkEmailDestinationStatus objects.",
        "The service call response (type Amazon.SimpleEmail.Model.SendBulkTemplatedEmailResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendSESBulkTemplatedEmailCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set to use when you send an email using <code>SendBulkTemplatedEmail</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationSetName { get; set; }
        #endregion
        
        #region Parameter DefaultTag
        /// <summary>
        /// <para>
        /// <para>A list of tags, in the form of name/value pairs, to apply to an email that you send
        /// to a destination using <code>SendBulkTemplatedEmail</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DefaultTags")]
        public Amazon.SimpleEmail.Model.MessageTag[] DefaultTag { get; set; }
        #endregion
        
        #region Parameter DefaultTemplateData
        /// <summary>
        /// <para>
        /// <para>A list of replacement values to apply to the template when replacement data is not
        /// specified in a Destination object. These values act as a default or fallback option
        /// when no other data is available.</para><para>The template data is a JSON object, typically consisting of key-value pairs in which
        /// the keys correspond to replacement tags in the email template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DefaultTemplateData { get; set; }
        #endregion
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para>One or more <code>Destination</code> objects. All of the recipients in a <code>Destination</code>
        /// will receive the same version of the email. You can specify up to 50 <code>Destination</code>
        /// objects within a <code>Destinations</code> array.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Destinations")]
        public Amazon.SimpleEmail.Model.BulkEmailDestination[] Destination { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SESBulkTemplatedEmail (SendBulkTemplatedEmail)"))
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
            if (this.DefaultTag != null)
            {
                context.DefaultTags = new List<Amazon.SimpleEmail.Model.MessageTag>(this.DefaultTag);
            }
            context.DefaultTemplateData = this.DefaultTemplateData;
            if (this.Destination != null)
            {
                context.Destinations = new List<Amazon.SimpleEmail.Model.BulkEmailDestination>(this.Destination);
            }
            if (this.ReplyToAddress != null)
            {
                context.ReplyToAddresses = new List<System.String>(this.ReplyToAddress);
            }
            context.ReturnPath = this.ReturnPath;
            context.ReturnPathArn = this.ReturnPathArn;
            context.Source = this.Source;
            context.SourceArn = this.SourceArn;
            context.Template = this.Template;
            context.TemplateArn = this.TemplateArn;
            
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
            var request = new Amazon.SimpleEmail.Model.SendBulkTemplatedEmailRequest();
            
            if (cmdletContext.ConfigurationSetName != null)
            {
                request.ConfigurationSetName = cmdletContext.ConfigurationSetName;
            }
            if (cmdletContext.DefaultTags != null)
            {
                request.DefaultTags = cmdletContext.DefaultTags;
            }
            if (cmdletContext.DefaultTemplateData != null)
            {
                request.DefaultTemplateData = cmdletContext.DefaultTemplateData;
            }
            if (cmdletContext.Destinations != null)
            {
                request.Destinations = cmdletContext.Destinations;
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
            if (cmdletContext.Template != null)
            {
                request.Template = cmdletContext.Template;
            }
            if (cmdletContext.TemplateArn != null)
            {
                request.TemplateArn = cmdletContext.TemplateArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Status;
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
        
        private Amazon.SimpleEmail.Model.SendBulkTemplatedEmailResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.SendBulkTemplatedEmailRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service", "SendBulkTemplatedEmail");
            try
            {
                #if DESKTOP
                return client.SendBulkTemplatedEmail(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SendBulkTemplatedEmailAsync(request);
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
            public List<Amazon.SimpleEmail.Model.MessageTag> DefaultTags { get; set; }
            public System.String DefaultTemplateData { get; set; }
            public List<Amazon.SimpleEmail.Model.BulkEmailDestination> Destinations { get; set; }
            public List<System.String> ReplyToAddresses { get; set; }
            public System.String ReturnPath { get; set; }
            public System.String ReturnPathArn { get; set; }
            public System.String Source { get; set; }
            public System.String SourceArn { get; set; }
            public System.String Template { get; set; }
            public System.String TemplateArn { get; set; }
        }
        
    }
}
