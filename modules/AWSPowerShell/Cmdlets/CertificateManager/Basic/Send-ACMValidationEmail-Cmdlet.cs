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
using Amazon.CertificateManager;
using Amazon.CertificateManager.Model;

namespace Amazon.PowerShell.Cmdlets.ACM
{
    /// <summary>
    /// Resends the email that requests domain ownership validation. The domain owner or an
    /// authorized representative must approve the ACM certificate before it can be issued.
    /// The certificate can be approved by clicking a link in the mail to navigate to the
    /// Amazon certificate approval website and then clicking <b>I Approve</b>. However, the
    /// validation email can be blocked by spam filters. Therefore, if you do not receive
    /// the original mail, you can request that the mail be resent within 72 hours of requesting
    /// the ACM certificate. If more than 72 hours have elapsed since your original request
    /// or since your last attempt to resend validation mail, you must request a new certificate.
    /// For more information about setting up your contact email addresses, see <a href="https://docs.aws.amazon.com/acm/latest/userguide/setup-email.html">Configure
    /// Email for your Domain</a>.
    /// </summary>
    [Cmdlet("Send", "ACMValidationEmail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Certificate Manager ResendValidationEmail API operation.", Operation = new[] {"ResendValidationEmail"}, SelectReturnType = typeof(Amazon.CertificateManager.Model.ResendValidationEmailResponse))]
    [AWSCmdletOutput("None or Amazon.CertificateManager.Model.ResendValidationEmailResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CertificateManager.Model.ResendValidationEmailResponse) be returned by specifying '-Select *'."
    )]
    public partial class SendACMValidationEmailCmdlet : AmazonCertificateManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CertificateArn
        /// <summary>
        /// <para>
        /// <para>String that contains the ARN of the requested certificate. The certificate ARN is
        /// generated and returned by the <a>RequestCertificate</a> action as soon as the request
        /// is made. By default, using this parameter causes email to be sent to all top-level
        /// domains you specified in the certificate request. The ARN must be of the form: </para><para><c>arn:aws:acm:us-east-1:123456789012:certificate/12345678-1234-1234-1234-123456789012</c></para>
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
        public System.String CertificateArn { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The fully qualified domain name (FQDN) of the certificate that needs to be validated.</para>
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
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter ValidationDomain
        /// <summary>
        /// <para>
        /// <para>The base validation domain that will act as the suffix of the email addresses that
        /// are used to send the emails. This must be the same as the <c>Domain</c> value or a
        /// superdomain of the <c>Domain</c> value. For example, if you requested a certificate
        /// for <c>site.subdomain.example.com</c> and specify a <b>ValidationDomain</b> of <c>subdomain.example.com</c>,
        /// ACM sends email to the domain registrant, technical contact, and administrative contact
        /// in WHOIS and the following five addresses:</para><ul><li><para>admin@subdomain.example.com</para></li><li><para>administrator@subdomain.example.com</para></li><li><para>hostmaster@subdomain.example.com</para></li><li><para>postmaster@subdomain.example.com</para></li><li><para>webmaster@subdomain.example.com</para></li></ul>
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
        public System.String ValidationDomain { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CertificateManager.Model.ResendValidationEmailResponse).
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CertificateArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-ACMValidationEmail (ResendValidationEmail)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CertificateManager.Model.ResendValidationEmailResponse, SendACMValidationEmailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CertificateArn = this.CertificateArn;
            #if MODULAR
            if (this.CertificateArn == null && ParameterWasBound(nameof(this.CertificateArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Domain = this.Domain;
            #if MODULAR
            if (this.Domain == null && ParameterWasBound(nameof(this.Domain)))
            {
                WriteWarning("You are passing $null as a value for parameter Domain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ValidationDomain = this.ValidationDomain;
            #if MODULAR
            if (this.ValidationDomain == null && ParameterWasBound(nameof(this.ValidationDomain)))
            {
                WriteWarning("You are passing $null as a value for parameter ValidationDomain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
        
        private Amazon.CertificateManager.Model.ResendValidationEmailResponse CallAWSServiceOperation(IAmazonCertificateManager client, Amazon.CertificateManager.Model.ResendValidationEmailRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager", "ResendValidationEmail");
            try
            {
                return client.ResendValidationEmailAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.CertificateManager.Model.ResendValidationEmailResponse, SendACMValidationEmailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
