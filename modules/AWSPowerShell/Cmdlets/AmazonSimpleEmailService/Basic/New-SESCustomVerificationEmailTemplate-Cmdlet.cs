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
    /// Creates a new custom verification email template.
    /// 
    ///  
    /// <para>
    /// For more information about custom verification email templates, see <a href="https://docs.aws.amazon.com/ses/latest/DeveloperGuide/custom-verification-emails.html">Using
    /// Custom Verification Email Templates</a> in the <i>Amazon SES Developer Guide</i>.
    /// </para><para>
    /// You can execute this operation no more than once per second.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SESCustomVerificationEmailTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Simple Email Service CreateCustomVerificationEmailTemplate API operation.", Operation = new[] {"CreateCustomVerificationEmailTemplate"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the TemplateContent parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.SimpleEmail.Model.CreateCustomVerificationEmailTemplateResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSESCustomVerificationEmailTemplateCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        #region Parameter FailureRedirectionURL
        /// <summary>
        /// <para>
        /// <para>The URL that the recipient of the verification email is sent to if his or her address
        /// is not successfully verified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FailureRedirectionURL { get; set; }
        #endregion
        
        #region Parameter FromEmailAddress
        /// <summary>
        /// <para>
        /// <para>The email address that the custom verification email is sent from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FromEmailAddress { get; set; }
        #endregion
        
        #region Parameter SuccessRedirectionURL
        /// <summary>
        /// <para>
        /// <para>The URL that the recipient of the verification email is sent to if his or her address
        /// is successfully verified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SuccessRedirectionURL { get; set; }
        #endregion
        
        #region Parameter TemplateContent
        /// <summary>
        /// <para>
        /// <para>The content of the custom verification email. The total size of the email must be
        /// less than 10 MB. The message body may contain HTML, with some limitations. For more
        /// information, see <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/custom-verification-emails.html#custom-verification-emails-faq">Custom
        /// Verification Email Frequently Asked Questions</a> in the <i>Amazon SES Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String TemplateContent { get; set; }
        #endregion
        
        #region Parameter TemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the custom verification email template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TemplateName { get; set; }
        #endregion
        
        #region Parameter TemplateSubject
        /// <summary>
        /// <para>
        /// <para>The subject line of the custom verification email.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TemplateSubject { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the TemplateContent parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TemplateName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SESCustomVerificationEmailTemplate (CreateCustomVerificationEmailTemplate)"))
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
            
            context.FailureRedirectionURL = this.FailureRedirectionURL;
            context.FromEmailAddress = this.FromEmailAddress;
            context.SuccessRedirectionURL = this.SuccessRedirectionURL;
            context.TemplateContent = this.TemplateContent;
            context.TemplateName = this.TemplateName;
            context.TemplateSubject = this.TemplateSubject;
            
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
            var request = new Amazon.SimpleEmail.Model.CreateCustomVerificationEmailTemplateRequest();
            
            if (cmdletContext.FailureRedirectionURL != null)
            {
                request.FailureRedirectionURL = cmdletContext.FailureRedirectionURL;
            }
            if (cmdletContext.FromEmailAddress != null)
            {
                request.FromEmailAddress = cmdletContext.FromEmailAddress;
            }
            if (cmdletContext.SuccessRedirectionURL != null)
            {
                request.SuccessRedirectionURL = cmdletContext.SuccessRedirectionURL;
            }
            if (cmdletContext.TemplateContent != null)
            {
                request.TemplateContent = cmdletContext.TemplateContent;
            }
            if (cmdletContext.TemplateName != null)
            {
                request.TemplateName = cmdletContext.TemplateName;
            }
            if (cmdletContext.TemplateSubject != null)
            {
                request.TemplateSubject = cmdletContext.TemplateSubject;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.TemplateContent;
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
        
        private Amazon.SimpleEmail.Model.CreateCustomVerificationEmailTemplateResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.CreateCustomVerificationEmailTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service", "CreateCustomVerificationEmailTemplate");
            try
            {
                #if DESKTOP
                return client.CreateCustomVerificationEmailTemplate(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateCustomVerificationEmailTemplateAsync(request);
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
            public System.String FailureRedirectionURL { get; set; }
            public System.String FromEmailAddress { get; set; }
            public System.String SuccessRedirectionURL { get; set; }
            public System.String TemplateContent { get; set; }
            public System.String TemplateName { get; set; }
            public System.String TemplateSubject { get; set; }
        }
        
    }
}
