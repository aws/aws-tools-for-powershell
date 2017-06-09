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
    /// Requests an ACM Certificate for use with other AWS services. To request an ACM Certificate,
    /// you must specify the fully qualified domain name (FQDN) for your site. You can also
    /// specify additional FQDNs if users can reach your site by using other names. For each
    /// domain name you specify, email is sent to the domain owner to request approval to
    /// issue the certificate. After receiving approval from the domain owner, the ACM Certificate
    /// is issued. For more information, see the <a href="http://docs.aws.amazon.com/acm/latest/userguide/">AWS
    /// Certificate Manager User Guide</a>.
    /// </summary>
    [Cmdlet("New", "ACMCertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the RequestCertificate operation against AWS Certificate Manager.", Operation = new[] {"RequestCertificate"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CertificateManager.Model.RequestCertificateResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewACMCertificateCmdlet : AmazonCertificateManagerClientCmdlet, IExecutor
    {
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para> Fully qualified domain name (FQDN), such as www.example.com, of the site that you
        /// want to secure with an ACM Certificate. Use an asterisk (*) to create a wildcard certificate
        /// that protects several sites in the same domain. For example, *.example.com protects
        /// www.example.com, site.example.com, and images.example.com. </para><para> The maximum length of a DNS name is 253 octets. The name is made up of multiple labels
        /// separated by periods. No label can be longer than 63 octets. Consider the following
        /// examples: </para><para><code>(63 octets).(63 octets).(63 octets).(61 octets)</code> is legal because the
        /// total length is 253 octets (63+1+63+1+63+1+61) and no label exceeds 63 octets. </para><para><code>(64 octets).(63 octets).(63 octets).(61 octets)</code> is not legal because
        /// the total length exceeds 253 octets (64+1+63+1+63+1+61) and the first label exceeds
        /// 63 octets. </para><para><code>(63 octets).(63 octets).(63 octets).(62 octets)</code> is not legal because
        /// the total length of the DNS name (63+1+63+1+63+1+62) exceeds 253 octets. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter DomainValidationOption
        /// <summary>
        /// <para>
        /// <para>The domain name that you want ACM to use to send you emails to validate your ownership
        /// of the domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DomainValidationOptions")]
        public Amazon.CertificateManager.Model.DomainValidationOption[] DomainValidationOption { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>Customer chosen string that can be used to distinguish between calls to <code>RequestCertificate</code>.
        /// Idempotency tokens time out after one hour. Therefore, if you call <code>RequestCertificate</code>
        /// multiple times with the same idempotency token within one hour, ACM recognizes that
        /// you are requesting only one certificate and will issue only one. If you change the
        /// idempotency token for each call, ACM recognizes that you are requesting multiple certificates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter SubjectAlternativeName
        /// <summary>
        /// <para>
        /// <para>Additional FQDNs to be included in the Subject Alternative Name extension of the ACM
        /// Certificate. For example, add the name www.example.net to a certificate for which
        /// the <code>DomainName</code> field is www.example.com if users can reach your site
        /// by using either name. The maximum number of domain names that you can add to an ACM
        /// Certificate is 100. However, the initial limit is 10 domain names. If you need more
        /// than 10 names, you must request a limit increase. For more information, see <a href="http://docs.aws.amazon.com/acm/latest/userguide/acm-limits.html">Limits</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SubjectAlternativeNames")]
        public System.String[] SubjectAlternativeName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DomainName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ACMCertificate (RequestCertificate)"))
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
            
            context.DomainName = this.DomainName;
            if (this.DomainValidationOption != null)
            {
                context.DomainValidationOptions = new List<Amazon.CertificateManager.Model.DomainValidationOption>(this.DomainValidationOption);
            }
            context.IdempotencyToken = this.IdempotencyToken;
            if (this.SubjectAlternativeName != null)
            {
                context.SubjectAlternativeNames = new List<System.String>(this.SubjectAlternativeName);
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
            var request = new Amazon.CertificateManager.Model.RequestCertificateRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.DomainValidationOptions != null)
            {
                request.DomainValidationOptions = cmdletContext.DomainValidationOptions;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            if (cmdletContext.SubjectAlternativeNames != null)
            {
                request.SubjectAlternativeNames = cmdletContext.SubjectAlternativeNames;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.CertificateArn;
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
        
        private Amazon.CertificateManager.Model.RequestCertificateResponse CallAWSServiceOperation(IAmazonCertificateManager client, Amazon.CertificateManager.Model.RequestCertificateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager", "RequestCertificate");
            #if DESKTOP
            return client.RequestCertificate(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.RequestCertificateAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String DomainName { get; set; }
            public List<Amazon.CertificateManager.Model.DomainValidationOption> DomainValidationOptions { get; set; }
            public System.String IdempotencyToken { get; set; }
            public List<System.String> SubjectAlternativeNames { get; set; }
        }
        
    }
}
