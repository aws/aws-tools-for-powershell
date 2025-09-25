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
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

namespace Amazon.PowerShell.Cmdlets.SES2
{
    /// <summary>
    /// Updates an email template. Email templates enable you to send personalized email to
    /// one or more destinations in a single API operation. For more information, see the
    /// <a href="https://docs.aws.amazon.com/ses/latest/DeveloperGuide/send-personalized-email-api.html">Amazon
    /// SES Developer Guide</a>.
    /// 
    ///  
    /// <para>
    /// You can execute this operation no more than once per second.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SES2EmailTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) UpdateEmailTemplate API operation.", Operation = new[] {"UpdateEmailTemplate"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.UpdateEmailTemplateResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleEmailV2.Model.UpdateEmailTemplateResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleEmailV2.Model.UpdateEmailTemplateResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSES2EmailTemplateCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TemplateContent_Html
        /// <summary>
        /// <para>
        /// <para>The HTML body of the email.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateContent_Html { get; set; }
        #endregion
        
        #region Parameter TemplateContent_Subject
        /// <summary>
        /// <para>
        /// <para>The subject line of the email.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateContent_Subject { get; set; }
        #endregion
        
        #region Parameter TemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the template.</para>
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
        
        #region Parameter TemplateContent_Text
        /// <summary>
        /// <para>
        /// <para>The email body that will be visible to recipients whose email clients do not display
        /// HTML.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateContent_Text { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.UpdateEmailTemplateResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SES2EmailTemplate (UpdateEmailTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.UpdateEmailTemplateResponse, UpdateSES2EmailTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TemplateContent_Html = this.TemplateContent_Html;
            context.TemplateContent_Subject = this.TemplateContent_Subject;
            context.TemplateContent_Text = this.TemplateContent_Text;
            context.TemplateName = this.TemplateName;
            #if MODULAR
            if (this.TemplateName == null && ParameterWasBound(nameof(this.TemplateName)))
            {
                WriteWarning("You are passing $null as a value for parameter TemplateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleEmailV2.Model.UpdateEmailTemplateRequest();
            
            
             // populate TemplateContent
            var requestTemplateContentIsNull = true;
            request.TemplateContent = new Amazon.SimpleEmailV2.Model.EmailTemplateContent();
            System.String requestTemplateContent_templateContent_Html = null;
            if (cmdletContext.TemplateContent_Html != null)
            {
                requestTemplateContent_templateContent_Html = cmdletContext.TemplateContent_Html;
            }
            if (requestTemplateContent_templateContent_Html != null)
            {
                request.TemplateContent.Html = requestTemplateContent_templateContent_Html;
                requestTemplateContentIsNull = false;
            }
            System.String requestTemplateContent_templateContent_Subject = null;
            if (cmdletContext.TemplateContent_Subject != null)
            {
                requestTemplateContent_templateContent_Subject = cmdletContext.TemplateContent_Subject;
            }
            if (requestTemplateContent_templateContent_Subject != null)
            {
                request.TemplateContent.Subject = requestTemplateContent_templateContent_Subject;
                requestTemplateContentIsNull = false;
            }
            System.String requestTemplateContent_templateContent_Text = null;
            if (cmdletContext.TemplateContent_Text != null)
            {
                requestTemplateContent_templateContent_Text = cmdletContext.TemplateContent_Text;
            }
            if (requestTemplateContent_templateContent_Text != null)
            {
                request.TemplateContent.Text = requestTemplateContent_templateContent_Text;
                requestTemplateContentIsNull = false;
            }
             // determine if request.TemplateContent should be set to null
            if (requestTemplateContentIsNull)
            {
                request.TemplateContent = null;
            }
            if (cmdletContext.TemplateName != null)
            {
                request.TemplateName = cmdletContext.TemplateName;
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
        
        private Amazon.SimpleEmailV2.Model.UpdateEmailTemplateResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.UpdateEmailTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "UpdateEmailTemplate");
            try
            {
                #if DESKTOP
                return client.UpdateEmailTemplate(request);
                #elif CORECLR
                return client.UpdateEmailTemplateAsync(request).GetAwaiter().GetResult();
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
            public System.String TemplateContent_Html { get; set; }
            public System.String TemplateContent_Subject { get; set; }
            public System.String TemplateContent_Text { get; set; }
            public System.String TemplateName { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.UpdateEmailTemplateResponse, UpdateSES2EmailTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
