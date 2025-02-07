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
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace Amazon.PowerShell.Cmdlets.SES
{
    /// <summary>
    /// Updates an existing custom verification email template.
    /// 
    ///  
    /// <para>
    /// For more information about custom verification email templates, see <a href="https://docs.aws.amazon.com/ses/latest/dg/creating-identities.html#send-email-verify-address-custom">Using
    /// Custom Verification Email Templates</a> in the <i>Amazon SES Developer Guide</i>.
    /// </para><para>
    /// You can execute this operation no more than once per second.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SESCustomVerificationEmailTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Email Service (SES) UpdateCustomVerificationEmailTemplate API operation.", Operation = new[] {"UpdateCustomVerificationEmailTemplate"}, SelectReturnType = typeof(Amazon.SimpleEmail.Model.UpdateCustomVerificationEmailTemplateResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleEmail.Model.UpdateCustomVerificationEmailTemplateResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleEmail.Model.UpdateCustomVerificationEmailTemplateResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSESCustomVerificationEmailTemplateCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FailureRedirectionURL
        /// <summary>
        /// <para>
        /// <para>The URL that the recipient of the verification email is sent to if his or her address
        /// is not successfully verified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FailureRedirectionURL { get; set; }
        #endregion
        
        #region Parameter FromEmailAddress
        /// <summary>
        /// <para>
        /// <para>The email address that the custom verification email is sent from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FromEmailAddress { get; set; }
        #endregion
        
        #region Parameter SuccessRedirectionURL
        /// <summary>
        /// <para>
        /// <para>The URL that the recipient of the verification email is sent to if his or her address
        /// is successfully verified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SuccessRedirectionURL { get; set; }
        #endregion
        
        #region Parameter TemplateContent
        /// <summary>
        /// <para>
        /// <para>The content of the custom verification email. The total size of the email must be
        /// less than 10 MB. The message body may contain HTML, with some limitations. For more
        /// information, see <a href="https://docs.aws.amazon.com/ses/latest/dg/creating-identities.html#send-email-verify-address-custom">Custom
        /// Verification Email Frequently Asked Questions</a> in the <i>Amazon SES Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TemplateContent { get; set; }
        #endregion
        
        #region Parameter TemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the custom verification email template to update.</para>
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
        public System.String TemplateName { get; set; }
        #endregion
        
        #region Parameter TemplateSubject
        /// <summary>
        /// <para>
        /// <para>The subject line of the custom verification email.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateSubject { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmail.Model.UpdateCustomVerificationEmailTemplateResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TemplateName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SESCustomVerificationEmailTemplate (UpdateCustomVerificationEmailTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmail.Model.UpdateCustomVerificationEmailTemplateResponse, UpdateSESCustomVerificationEmailTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FailureRedirectionURL = this.FailureRedirectionURL;
            context.FromEmailAddress = this.FromEmailAddress;
            context.SuccessRedirectionURL = this.SuccessRedirectionURL;
            context.TemplateContent = this.TemplateContent;
            context.TemplateName = this.TemplateName;
            #if MODULAR
            if (this.TemplateName == null && ParameterWasBound(nameof(this.TemplateName)))
            {
                WriteWarning("You are passing $null as a value for parameter TemplateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.SimpleEmail.Model.UpdateCustomVerificationEmailTemplateRequest();
            
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
        
        private Amazon.SimpleEmail.Model.UpdateCustomVerificationEmailTemplateResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.UpdateCustomVerificationEmailTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service (SES)", "UpdateCustomVerificationEmailTemplate");
            try
            {
                #if DESKTOP
                return client.UpdateCustomVerificationEmailTemplate(request);
                #elif CORECLR
                return client.UpdateCustomVerificationEmailTemplateAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.SimpleEmail.Model.UpdateCustomVerificationEmailTemplateResponse, UpdateSESCustomVerificationEmailTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
