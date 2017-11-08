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
using Amazon.CertificateManager;
using Amazon.CertificateManager.Model;

namespace Amazon.PowerShell.Cmdlets.ACM
{
    /// <summary>
    /// Resends the email that requests domain ownership validation. The domain owner or an
    /// authorized representative must approve the ACM Certificate before it can be issued.
    /// The certificate can be approved by clicking a link in the mail to navigate to the
    /// Amazon certificate approval website and then clicking <b>I Approve</b>. However, the
    /// validation email can be blocked by spam filters. Therefore, if you do not receive
    /// the original mail, you can request that the mail be resent within 72 hours of requesting
    /// the ACM Certificate. If more than 72 hours have elapsed since your original request
    /// or since your last attempt to resend validation mail, you must request a new certificate.
    /// For more information about setting up your contact email addresses, see <a href="http://docs.aws.amazon.com/acm/latest/userguide/setup-email.html">Configure
    /// Email for your Domain</a>.
    /// </summary>
    [Cmdlet("Send", "ACMValidationEmail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Certificate Manager ResendValidationEmail API operation.", Operation = new[] {"ResendValidationEmail"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the CertificateArn parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.CertificateManager.Model.ResendValidationEmailResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendACMValidationEmailCmdlet : AmazonCertificateManagerClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateArn
        /// <summary>
        /// <para>
        /// <para>String that contains the ARN of the requested certificate. The certificate ARN is
        /// generated and returned by the <a>RequestCertificate</a> action as soon as the request
        /// is made. By default, using this parameter causes email to be sent to all top-level
        /// domains you specified in the certificate request.</para><para>The ARN must be of the form:</para><para><code>arn:aws:acm:us-east-1:123456789012:certificate/12345678-1234-1234-1234-123456789012</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CertificateArn { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The fully qualified domain name (FQDN) of the certificate that needs to be validated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter ValidationDomain
        /// <summary>
        /// <para>
        /// <para>The base validation domain that will act as the suffix of the email addresses that
        /// are used to send the emails. This must be the same as the <code>Domain</code> value
        /// or a superdomain of the <code>Domain</code> value. For example, if you requested a
        /// certificate for <code>site.subdomain.example.com</code> and specify a <b>ValidationDomain</b>
        /// of <code>subdomain.example.com</code>, ACM sends email to the domain registrant, technical
        /// contact, and administrative contact in WHOIS and the following five addresses:</para><ul><li><para>admin@subdomain.example.com</para></li><li><para>administrator@subdomain.example.com</para></li><li><para>hostmaster@subdomain.example.com</para></li><li><para>postmaster@subdomain.example.com</para></li><li><para>webmaster@subdomain.example.com</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ValidationDomain { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the CertificateArn parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CertificateArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-ACMValidationEmail (ResendValidationEmail)"))
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
            
            context.CertificateArn = this.CertificateArn;
            context.Domain = this.Domain;
            context.ValidationDomain = this.ValidationDomain;
            
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
            var request = new Amazon.CertificateManager.Model.ResendValidationEmailRequest();
            
            if (cmdletContext.CertificateArn != null)
            {
                request.CertificateArn = cmdletContext.CertificateArn;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            if (cmdletContext.ValidationDomain != null)
            {
                request.ValidationDomain = cmdletContext.ValidationDomain;
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
                    pipelineOutput = this.CertificateArn;
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
        
        private Amazon.CertificateManager.Model.ResendValidationEmailResponse CallAWSServiceOperation(IAmazonCertificateManager client, Amazon.CertificateManager.Model.ResendValidationEmailRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager", "ResendValidationEmail");
            try
            {
                #if DESKTOP
                return client.ResendValidationEmail(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ResendValidationEmailAsync(request);
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
            public System.String CertificateArn { get; set; }
            public System.String Domain { get; set; }
            public System.String ValidationDomain { get; set; }
        }
        
    }
}
