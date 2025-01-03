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
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

namespace Amazon.PowerShell.Cmdlets.SES2
{
    /// <summary>
    /// Composes an email message to multiple destinations.
    /// </summary>
    [Cmdlet("Send", "SES2BulkEmail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleEmailV2.Model.BulkEmailEntryResult")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) SendBulkEmail API operation.", Operation = new[] {"SendBulkEmail"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.SendBulkEmailResponse))]
    [AWSCmdletOutput("Amazon.SimpleEmailV2.Model.BulkEmailEntryResult or Amazon.SimpleEmailV2.Model.SendBulkEmailResponse",
        "This cmdlet returns a collection of Amazon.SimpleEmailV2.Model.BulkEmailEntryResult objects.",
        "The service call response (type Amazon.SimpleEmailV2.Model.SendBulkEmailResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SendSES2BulkEmailCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BulkEmailEntry
        /// <summary>
        /// <para>
        /// <para>The list of bulk email entry objects.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("BulkEmailEntries")]
        public Amazon.SimpleEmailV2.Model.BulkEmailEntry[] BulkEmailEntry { get; set; }
        #endregion
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set to use when sending the email.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationSetName { get; set; }
        #endregion
        
        #region Parameter DefaultEmailTag
        /// <summary>
        /// <para>
        /// <para>A list of tags, in the form of name/value pairs, to apply to an email that you send
        /// using the <c>SendEmail</c> operation. Tags correspond to characteristics of the email
        /// that you define, so that you can publish email sending events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultEmailTags")]
        public Amazon.SimpleEmailV2.Model.MessageTag[] DefaultEmailTag { get; set; }
        #endregion
        
        #region Parameter EndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the multi-region endpoint (global-endpoint).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointId { get; set; }
        #endregion
        
        #region Parameter FeedbackForwardingEmailAddress
        /// <summary>
        /// <para>
        /// <para>The address that you want bounce and complaint notifications to be sent to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FeedbackForwardingEmailAddress { get; set; }
        #endregion
        
        #region Parameter FeedbackForwardingEmailAddressIdentityArn
        /// <summary>
        /// <para>
        /// <para>This parameter is used only for sending authorization. It is the ARN of the identity
        /// that is associated with the sending authorization policy that permits you to use the
        /// email address specified in the <c>FeedbackForwardingEmailAddress</c> parameter.</para><para>For example, if the owner of example.com (which has ARN arn:aws:ses:us-east-1:123456789012:identity/example.com)
        /// attaches a policy to it that authorizes you to use feedback@example.com, then you
        /// would specify the <c>FeedbackForwardingEmailAddressIdentityArn</c> to be arn:aws:ses:us-east-1:123456789012:identity/example.com,
        /// and the <c>FeedbackForwardingEmailAddress</c> to be feedback@example.com.</para><para>For more information about sending authorization, see the <a href="https://docs.aws.amazon.com/ses/latest/DeveloperGuide/sending-authorization.html">Amazon
        /// SES Developer Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FeedbackForwardingEmailAddressIdentityArn { get; set; }
        #endregion
        
        #region Parameter FromEmailAddress
        /// <summary>
        /// <para>
        /// <para>The email address to use as the "From" address for the email. The address that you
        /// specify has to be verified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FromEmailAddress { get; set; }
        #endregion
        
        #region Parameter FromEmailAddressIdentityArn
        /// <summary>
        /// <para>
        /// <para>This parameter is used only for sending authorization. It is the ARN of the identity
        /// that is associated with the sending authorization policy that permits you to use the
        /// email address specified in the <c>FromEmailAddress</c> parameter.</para><para>For example, if the owner of example.com (which has ARN arn:aws:ses:us-east-1:123456789012:identity/example.com)
        /// attaches a policy to it that authorizes you to use sender@example.com, then you would
        /// specify the <c>FromEmailAddressIdentityArn</c> to be arn:aws:ses:us-east-1:123456789012:identity/example.com,
        /// and the <c>FromEmailAddress</c> to be sender@example.com.</para><para>For more information about sending authorization, see the <a href="https://docs.aws.amazon.com/ses/latest/DeveloperGuide/sending-authorization.html">Amazon
        /// SES Developer Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FromEmailAddressIdentityArn { get; set; }
        #endregion
        
        #region Parameter Template_Header
        /// <summary>
        /// <para>
        /// <para>The list of message headers that will be added to the email message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultContent_Template_Headers")]
        public Amazon.SimpleEmailV2.Model.MessageHeader[] Template_Header { get; set; }
        #endregion
        
        #region Parameter TemplateContent_Html
        /// <summary>
        /// <para>
        /// <para>The HTML body of the email.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultContent_Template_TemplateContent_Html")]
        public System.String TemplateContent_Html { get; set; }
        #endregion
        
        #region Parameter ReplyToAddress
        /// <summary>
        /// <para>
        /// <para>The "Reply-to" email addresses for the message. When the recipient replies to the
        /// message, each Reply-to address receives the reply.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReplyToAddresses")]
        public System.String[] ReplyToAddress { get; set; }
        #endregion
        
        #region Parameter TemplateContent_Subject
        /// <summary>
        /// <para>
        /// <para>The subject line of the email.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultContent_Template_TemplateContent_Subject")]
        public System.String TemplateContent_Subject { get; set; }
        #endregion
        
        #region Parameter Template_TemplateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultContent_Template_TemplateArn")]
        public System.String Template_TemplateArn { get; set; }
        #endregion
        
        #region Parameter Template_TemplateData
        /// <summary>
        /// <para>
        /// <para>An object that defines the values to use for message variables in the template. This
        /// object is a set of key-value pairs. Each key defines a message variable in the template.
        /// The corresponding value defines the value to use for that variable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultContent_Template_TemplateData")]
        public System.String Template_TemplateData { get; set; }
        #endregion
        
        #region Parameter Template_TemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the template. You will refer to this name when you send email using the
        /// <c>SendTemplatedEmail</c> or <c>SendBulkTemplatedEmail</c> operations. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultContent_Template_TemplateName")]
        public System.String Template_TemplateName { get; set; }
        #endregion
        
        #region Parameter TemplateContent_Text
        /// <summary>
        /// <para>
        /// <para>The email body that will be visible to recipients whose email clients do not display
        /// HTML.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultContent_Template_TemplateContent_Text")]
        public System.String TemplateContent_Text { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BulkEmailEntryResults'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.SendBulkEmailResponse).
        /// Specifying the name of a property of type Amazon.SimpleEmailV2.Model.SendBulkEmailResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BulkEmailEntryResults";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SES2BulkEmail (SendBulkEmail)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.SendBulkEmailResponse, SendSES2BulkEmailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.BulkEmailEntry != null)
            {
                context.BulkEmailEntry = new List<Amazon.SimpleEmailV2.Model.BulkEmailEntry>(this.BulkEmailEntry);
            }
            #if MODULAR
            if (this.BulkEmailEntry == null && ParameterWasBound(nameof(this.BulkEmailEntry)))
            {
                WriteWarning("You are passing $null as a value for parameter BulkEmailEntry which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConfigurationSetName = this.ConfigurationSetName;
            if (this.Template_Header != null)
            {
                context.Template_Header = new List<Amazon.SimpleEmailV2.Model.MessageHeader>(this.Template_Header);
            }
            context.Template_TemplateArn = this.Template_TemplateArn;
            context.TemplateContent_Html = this.TemplateContent_Html;
            context.TemplateContent_Subject = this.TemplateContent_Subject;
            context.TemplateContent_Text = this.TemplateContent_Text;
            context.Template_TemplateData = this.Template_TemplateData;
            context.Template_TemplateName = this.Template_TemplateName;
            if (this.DefaultEmailTag != null)
            {
                context.DefaultEmailTag = new List<Amazon.SimpleEmailV2.Model.MessageTag>(this.DefaultEmailTag);
            }
            context.EndpointId = this.EndpointId;
            context.FeedbackForwardingEmailAddress = this.FeedbackForwardingEmailAddress;
            context.FeedbackForwardingEmailAddressIdentityArn = this.FeedbackForwardingEmailAddressIdentityArn;
            context.FromEmailAddress = this.FromEmailAddress;
            context.FromEmailAddressIdentityArn = this.FromEmailAddressIdentityArn;
            if (this.ReplyToAddress != null)
            {
                context.ReplyToAddress = new List<System.String>(this.ReplyToAddress);
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
            var request = new Amazon.SimpleEmailV2.Model.SendBulkEmailRequest();
            
            if (cmdletContext.BulkEmailEntry != null)
            {
                request.BulkEmailEntries = cmdletContext.BulkEmailEntry;
            }
            if (cmdletContext.ConfigurationSetName != null)
            {
                request.ConfigurationSetName = cmdletContext.ConfigurationSetName;
            }
            
             // populate DefaultContent
            var requestDefaultContentIsNull = true;
            request.DefaultContent = new Amazon.SimpleEmailV2.Model.BulkEmailContent();
            Amazon.SimpleEmailV2.Model.Template requestDefaultContent_defaultContent_Template = null;
            
             // populate Template
            var requestDefaultContent_defaultContent_TemplateIsNull = true;
            requestDefaultContent_defaultContent_Template = new Amazon.SimpleEmailV2.Model.Template();
            List<Amazon.SimpleEmailV2.Model.MessageHeader> requestDefaultContent_defaultContent_Template_template_Header = null;
            if (cmdletContext.Template_Header != null)
            {
                requestDefaultContent_defaultContent_Template_template_Header = cmdletContext.Template_Header;
            }
            if (requestDefaultContent_defaultContent_Template_template_Header != null)
            {
                requestDefaultContent_defaultContent_Template.Headers = requestDefaultContent_defaultContent_Template_template_Header;
                requestDefaultContent_defaultContent_TemplateIsNull = false;
            }
            System.String requestDefaultContent_defaultContent_Template_template_TemplateArn = null;
            if (cmdletContext.Template_TemplateArn != null)
            {
                requestDefaultContent_defaultContent_Template_template_TemplateArn = cmdletContext.Template_TemplateArn;
            }
            if (requestDefaultContent_defaultContent_Template_template_TemplateArn != null)
            {
                requestDefaultContent_defaultContent_Template.TemplateArn = requestDefaultContent_defaultContent_Template_template_TemplateArn;
                requestDefaultContent_defaultContent_TemplateIsNull = false;
            }
            System.String requestDefaultContent_defaultContent_Template_template_TemplateData = null;
            if (cmdletContext.Template_TemplateData != null)
            {
                requestDefaultContent_defaultContent_Template_template_TemplateData = cmdletContext.Template_TemplateData;
            }
            if (requestDefaultContent_defaultContent_Template_template_TemplateData != null)
            {
                requestDefaultContent_defaultContent_Template.TemplateData = requestDefaultContent_defaultContent_Template_template_TemplateData;
                requestDefaultContent_defaultContent_TemplateIsNull = false;
            }
            System.String requestDefaultContent_defaultContent_Template_template_TemplateName = null;
            if (cmdletContext.Template_TemplateName != null)
            {
                requestDefaultContent_defaultContent_Template_template_TemplateName = cmdletContext.Template_TemplateName;
            }
            if (requestDefaultContent_defaultContent_Template_template_TemplateName != null)
            {
                requestDefaultContent_defaultContent_Template.TemplateName = requestDefaultContent_defaultContent_Template_template_TemplateName;
                requestDefaultContent_defaultContent_TemplateIsNull = false;
            }
            Amazon.SimpleEmailV2.Model.EmailTemplateContent requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContent = null;
            
             // populate TemplateContent
            var requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContentIsNull = true;
            requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContent = new Amazon.SimpleEmailV2.Model.EmailTemplateContent();
            System.String requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContent_templateContent_Html = null;
            if (cmdletContext.TemplateContent_Html != null)
            {
                requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContent_templateContent_Html = cmdletContext.TemplateContent_Html;
            }
            if (requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContent_templateContent_Html != null)
            {
                requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContent.Html = requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContent_templateContent_Html;
                requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContentIsNull = false;
            }
            System.String requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContent_templateContent_Subject = null;
            if (cmdletContext.TemplateContent_Subject != null)
            {
                requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContent_templateContent_Subject = cmdletContext.TemplateContent_Subject;
            }
            if (requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContent_templateContent_Subject != null)
            {
                requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContent.Subject = requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContent_templateContent_Subject;
                requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContentIsNull = false;
            }
            System.String requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContent_templateContent_Text = null;
            if (cmdletContext.TemplateContent_Text != null)
            {
                requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContent_templateContent_Text = cmdletContext.TemplateContent_Text;
            }
            if (requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContent_templateContent_Text != null)
            {
                requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContent.Text = requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContent_templateContent_Text;
                requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContentIsNull = false;
            }
             // determine if requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContent should be set to null
            if (requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContentIsNull)
            {
                requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContent = null;
            }
            if (requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContent != null)
            {
                requestDefaultContent_defaultContent_Template.TemplateContent = requestDefaultContent_defaultContent_Template_defaultContent_Template_TemplateContent;
                requestDefaultContent_defaultContent_TemplateIsNull = false;
            }
             // determine if requestDefaultContent_defaultContent_Template should be set to null
            if (requestDefaultContent_defaultContent_TemplateIsNull)
            {
                requestDefaultContent_defaultContent_Template = null;
            }
            if (requestDefaultContent_defaultContent_Template != null)
            {
                request.DefaultContent.Template = requestDefaultContent_defaultContent_Template;
                requestDefaultContentIsNull = false;
            }
             // determine if request.DefaultContent should be set to null
            if (requestDefaultContentIsNull)
            {
                request.DefaultContent = null;
            }
            if (cmdletContext.DefaultEmailTag != null)
            {
                request.DefaultEmailTags = cmdletContext.DefaultEmailTag;
            }
            if (cmdletContext.EndpointId != null)
            {
                request.EndpointId = cmdletContext.EndpointId;
            }
            if (cmdletContext.FeedbackForwardingEmailAddress != null)
            {
                request.FeedbackForwardingEmailAddress = cmdletContext.FeedbackForwardingEmailAddress;
            }
            if (cmdletContext.FeedbackForwardingEmailAddressIdentityArn != null)
            {
                request.FeedbackForwardingEmailAddressIdentityArn = cmdletContext.FeedbackForwardingEmailAddressIdentityArn;
            }
            if (cmdletContext.FromEmailAddress != null)
            {
                request.FromEmailAddress = cmdletContext.FromEmailAddress;
            }
            if (cmdletContext.FromEmailAddressIdentityArn != null)
            {
                request.FromEmailAddressIdentityArn = cmdletContext.FromEmailAddressIdentityArn;
            }
            if (cmdletContext.ReplyToAddress != null)
            {
                request.ReplyToAddresses = cmdletContext.ReplyToAddress;
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
        
        private Amazon.SimpleEmailV2.Model.SendBulkEmailResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.SendBulkEmailRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "SendBulkEmail");
            try
            {
                #if DESKTOP
                return client.SendBulkEmail(request);
                #elif CORECLR
                return client.SendBulkEmailAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SimpleEmailV2.Model.BulkEmailEntry> BulkEmailEntry { get; set; }
            public System.String ConfigurationSetName { get; set; }
            public List<Amazon.SimpleEmailV2.Model.MessageHeader> Template_Header { get; set; }
            public System.String Template_TemplateArn { get; set; }
            public System.String TemplateContent_Html { get; set; }
            public System.String TemplateContent_Subject { get; set; }
            public System.String TemplateContent_Text { get; set; }
            public System.String Template_TemplateData { get; set; }
            public System.String Template_TemplateName { get; set; }
            public List<Amazon.SimpleEmailV2.Model.MessageTag> DefaultEmailTag { get; set; }
            public System.String EndpointId { get; set; }
            public System.String FeedbackForwardingEmailAddress { get; set; }
            public System.String FeedbackForwardingEmailAddressIdentityArn { get; set; }
            public System.String FromEmailAddress { get; set; }
            public System.String FromEmailAddressIdentityArn { get; set; }
            public List<System.String> ReplyToAddress { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.SendBulkEmailResponse, SendSES2BulkEmailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BulkEmailEntryResults;
        }
        
    }
}
