/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// To send email using this operation, your call must meet the following requirements:
    /// </para><ul><li><para>
    /// The call must refer to an existing email template. You can create email templates
    /// using the <a>CreateTemplate</a> operation.
    /// </para></li><li><para>
    /// The message must be sent from a verified email address or domain.
    /// </para></li><li><para>
    /// If your account is still in the Amazon SES sandbox, you may only send to verified
    /// addresses or domains, or to email addresses associated with the Amazon SES Mailbox
    /// Simulator. For more information, see <a href="https://docs.aws.amazon.com/ses/latest/dg/verify-addresses-and-domains.html">Verifying
    /// Email Addresses and Domains</a> in the <i>Amazon SES Developer Guide.</i></para></li><li><para>
    /// The maximum message size is 10 MB.
    /// </para></li><li><para>
    /// Calls to the <c>SendTemplatedEmail</c> operation may only include one <c>Destination</c>
    /// parameter. A destination is a set of recipients that receives the same version of
    /// the email. The <c>Destination</c> parameter can include up to 50 recipients, across
    /// the To:, CC: and BCC: fields.
    /// </para></li><li><para>
    /// The <c>Destination</c> parameter must include at least one recipient email address.
    /// The recipient address can be a To: address, a CC: address, or a BCC: address. If a
    /// recipient email address is invalid (that is, it is not in the format <i>UserName@[SubDomain.]Domain.TopLevelDomain</i>),
    /// the entire message is rejected, even if the message contains other recipients that
    /// are valid.
    /// </para></li></ul><important><para>
    /// If your call to the <c>SendTemplatedEmail</c> operation includes all of the required
    /// parameters, Amazon SES accepts it and returns a Message ID. However, if Amazon SES
    /// can't render the email because the template contains errors, it doesn't send the email.
    /// Additionally, because it already accepted the message, Amazon SES doesn't return a
    /// message stating that it was unable to send the email.
    /// </para><para>
    /// For these reasons, we highly recommend that you set up Amazon SES to send you notifications
    /// when Rendering Failure events occur. For more information, see <a href="https://docs.aws.amazon.com/ses/latest/dg/send-personalized-email-api.html">Sending
    /// Personalized Email Using the Amazon SES API</a> in the <i>Amazon Simple Email Service
    /// Developer Guide</i>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Send", "SESTemplatedEmail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Email Service (SES) SendTemplatedEmail API operation.", Operation = new[] {"SendTemplatedEmail"}, SelectReturnType = typeof(Amazon.SimpleEmail.Model.SendTemplatedEmailResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleEmail.Model.SendTemplatedEmailResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SimpleEmail.Model.SendTemplatedEmailResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendSESTemplatedEmailCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set to use when you send an email using <c>SendTemplatedEmail</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationSetName { get; set; }
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
        /// for this reason, The email address string must be 7-bit ASCII. If you want to send
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
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
        /// using <c>SendTemplatedEmail</c>. Tags correspond to characteristics of the email that
        /// you define, so that you can publish email sending events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SimpleEmail.Model.MessageTag[] Tag { get; set; }
        #endregion
        
        #region Parameter Template
        /// <summary>
        /// <para>
        /// <para>The template to use when sending this email.</para>
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
        public System.String Template { get; set; }
        #endregion
        
        #region Parameter TemplateArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the template to use when sending this email.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String TemplateData { get; set; }
        #endregion
        
        #region Parameter Destination_ToAddress
        /// <summary>
        /// <para>
        /// <para>The recipients to place on the To: line of the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Destination_ToAddresses")]
        public System.String[] Destination_ToAddress { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MessageId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmail.Model.SendTemplatedEmailResponse).
        /// Specifying the name of a property of type Amazon.SimpleEmail.Model.SendTemplatedEmailResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Source), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SESTemplatedEmail (SendTemplatedEmail)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmail.Model.SendTemplatedEmailResponse, SendSESTemplatedEmailCmdlet>(Select) ??
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
            context.Template = this.Template;
            #if MODULAR
            if (this.Template == null && ParameterWasBound(nameof(this.Template)))
            {
                WriteWarning("You are passing $null as a value for parameter Template which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TemplateArn = this.TemplateArn;
            context.TemplateData = this.TemplateData;
            #if MODULAR
            if (this.TemplateData == null && ParameterWasBound(nameof(this.TemplateData)))
            {
                WriteWarning("You are passing $null as a value for parameter TemplateData which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
        
        private Amazon.SimpleEmail.Model.SendTemplatedEmailResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.SendTemplatedEmailRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service (SES)", "SendTemplatedEmail");
            try
            {
                #if DESKTOP
                return client.SendTemplatedEmail(request);
                #elif CORECLR
                return client.SendTemplatedEmailAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Destination_BccAddress { get; set; }
            public List<System.String> Destination_CcAddress { get; set; }
            public List<System.String> Destination_ToAddress { get; set; }
            public List<System.String> ReplyToAddress { get; set; }
            public System.String ReturnPath { get; set; }
            public System.String ReturnPathArn { get; set; }
            public System.String Source { get; set; }
            public System.String SourceArn { get; set; }
            public List<Amazon.SimpleEmail.Model.MessageTag> Tag { get; set; }
            public System.String Template { get; set; }
            public System.String TemplateArn { get; set; }
            public System.String TemplateData { get; set; }
            public System.Func<Amazon.SimpleEmail.Model.SendTemplatedEmailResponse, SendSESTemplatedEmailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageId;
        }
        
    }
}
