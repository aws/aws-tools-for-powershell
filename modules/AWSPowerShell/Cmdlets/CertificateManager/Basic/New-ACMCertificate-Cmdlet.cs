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
using Amazon.CertificateManager;
using Amazon.CertificateManager.Model;

namespace Amazon.PowerShell.Cmdlets.ACM
{
    /// <summary>
    /// Requests an ACM certificate for use with other Amazon Web Services services. To request
    /// an ACM certificate, you must specify a fully qualified domain name (FQDN) in the <code>DomainName</code>
    /// parameter. You can also specify additional FQDNs in the <code>SubjectAlternativeNames</code>
    /// parameter. 
    /// 
    ///  
    /// <para>
    /// If you are requesting a private certificate, domain validation is not required. If
    /// you are requesting a public certificate, each domain name that you specify must be
    /// validated to verify that you own or control the domain. You can use <a href="https://docs.aws.amazon.com/acm/latest/userguide/gs-acm-validate-dns.html">DNS
    /// validation</a> or <a href="https://docs.aws.amazon.com/acm/latest/userguide/gs-acm-validate-email.html">email
    /// validation</a>. We recommend that you use DNS validation. ACM issues public certificates
    /// after receiving approval from the domain owner. 
    /// </para><note><para>
    /// ACM behavior differs from the <a href="https://datatracker.ietf.org/doc/html/rfc6125#appendix-B.2">RFC
    /// 6125</a> specification of the certificate validation process. ACM first checks for
    /// a Subject Alternative Name, and, if it finds one, ignores the common name (CN).
    /// </para></note><para>
    /// After successful completion of the <code>RequestCertificate</code> action, there is
    /// a delay of several seconds before you can retrieve information about the new certificate.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ACMCertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Certificate Manager RequestCertificate API operation.", Operation = new[] {"RequestCertificate"}, SelectReturnType = typeof(Amazon.CertificateManager.Model.RequestCertificateResponse))]
    [AWSCmdletOutput("System.String or Amazon.CertificateManager.Model.RequestCertificateResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CertificateManager.Model.RequestCertificateResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewACMCertificateCmdlet : AmazonCertificateManagerClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateAuthorityArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the private certificate authority (CA) that will
        /// be used to issue the certificate. If you do not provide an ARN and you are trying
        /// to request a private certificate, ACM will attempt to issue a public certificate.
        /// For more information about private CAs, see the <a href="https://docs.aws.amazon.com/acm-pca/latest/userguide/PcaWelcome.html">Certificate
        /// Manager Private Certificate Authority</a> user guide. The ARN must have the following
        /// form: </para><para><code>arn:aws:acm-pca:region:account:certificate-authority/12345678-1234-1234-1234-123456789012</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CertificateAuthorityArn { get; set; }
        #endregion
        
        #region Parameter Options_CertificateTransparencyLoggingPreference
        /// <summary>
        /// <para>
        /// <para>You can opt out of certificate transparency logging by specifying the <code>DISABLED</code>
        /// option. Opt in by specifying <code>ENABLED</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CertificateManager.CertificateTransparencyLoggingPreference")]
        public Amazon.CertificateManager.CertificateTransparencyLoggingPreference Options_CertificateTransparencyLoggingPreference { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>Fully qualified domain name (FQDN), such as www.example.com, that you want to secure
        /// with an ACM certificate. Use an asterisk (*) to create a wildcard certificate that
        /// protects several sites in the same domain. For example, *.example.com protects www.example.com,
        /// site.example.com, and images.example.com. </para><para>In compliance with <a href="https://datatracker.ietf.org/doc/html/rfc5280">RFC 5280</a>,
        /// the length of the domain name (technically, the Common Name) that you provide cannot
        /// exceed 64 octets (characters), including periods. To add a longer domain name, specify
        /// it in the Subject Alternative Name field, which supports names up to 253 octets in
        /// length. </para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter DomainValidationOption
        /// <summary>
        /// <para>
        /// <para>The domain name that you want ACM to use to send you emails so that you can validate
        /// domain ownership.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter SubjectAlternativeName
        /// <summary>
        /// <para>
        /// <para>Additional FQDNs to be included in the Subject Alternative Name extension of the ACM
        /// certificate. For example, add the name www.example.net to a certificate for which
        /// the <code>DomainName</code> field is www.example.com if users can reach your site
        /// by using either name. The maximum number of domain names that you can add to an ACM
        /// certificate is 100. However, the initial quota is 10 domain names. If you need more
        /// than 10 names, you must request a quota increase. For more information, see <a href="https://docs.aws.amazon.com/acm/latest/userguide/acm-limits.html">Quotas</a>.</para><para> The maximum length of a SAN DNS name is 253 octets. The name is made up of multiple
        /// labels separated by periods. No label can be longer than 63 octets. Consider the following
        /// examples: </para><ul><li><para><code>(63 octets).(63 octets).(63 octets).(61 octets)</code> is legal because the
        /// total length is 253 octets (63+1+63+1+63+1+61) and no label exceeds 63 octets.</para></li><li><para><code>(64 octets).(63 octets).(63 octets).(61 octets)</code> is not legal because
        /// the total length exceeds 253 octets (64+1+63+1+63+1+61) and the first label exceeds
        /// 63 octets.</para></li><li><para><code>(63 octets).(63 octets).(63 octets).(62 octets)</code> is not legal because
        /// the total length of the DNS name (63+1+63+1+63+1+62) exceeds 253 octets.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubjectAlternativeNames")]
        public System.String[] SubjectAlternativeName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>One or more resource tags to associate with the certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CertificateManager.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ValidationMethod
        /// <summary>
        /// <para>
        /// <para>The method you want to use if you are requesting a public certificate to validate
        /// that you own or control domain. You can <a href="https://docs.aws.amazon.com/acm/latest/userguide/gs-acm-validate-dns.html">validate
        /// with DNS</a> or <a href="https://docs.aws.amazon.com/acm/latest/userguide/gs-acm-validate-email.html">validate
        /// with email</a>. We recommend that you use DNS validation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CertificateManager.ValidationMethod")]
        public Amazon.CertificateManager.ValidationMethod ValidationMethod { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CertificateArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CertificateManager.Model.RequestCertificateResponse).
        /// Specifying the name of a property of type Amazon.CertificateManager.Model.RequestCertificateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CertificateArn";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ACMCertificate (RequestCertificate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CertificateManager.Model.RequestCertificateResponse, NewACMCertificateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CertificateAuthorityArn = this.CertificateAuthorityArn;
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DomainValidationOption != null)
            {
                context.DomainValidationOption = new List<Amazon.CertificateManager.Model.DomainValidationOption>(this.DomainValidationOption);
            }
            context.IdempotencyToken = this.IdempotencyToken;
            context.Options_CertificateTransparencyLoggingPreference = this.Options_CertificateTransparencyLoggingPreference;
            if (this.SubjectAlternativeName != null)
            {
                context.SubjectAlternativeName = new List<System.String>(this.SubjectAlternativeName);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.CertificateManager.Model.Tag>(this.Tag);
            }
            context.ValidationMethod = this.ValidationMethod;
            
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
            
            if (cmdletContext.CertificateAuthorityArn != null)
            {
                request.CertificateAuthorityArn = cmdletContext.CertificateAuthorityArn;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.DomainValidationOption != null)
            {
                request.DomainValidationOptions = cmdletContext.DomainValidationOption;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            
             // populate Options
            var requestOptionsIsNull = true;
            request.Options = new Amazon.CertificateManager.Model.CertificateOptions();
            Amazon.CertificateManager.CertificateTransparencyLoggingPreference requestOptions_options_CertificateTransparencyLoggingPreference = null;
            if (cmdletContext.Options_CertificateTransparencyLoggingPreference != null)
            {
                requestOptions_options_CertificateTransparencyLoggingPreference = cmdletContext.Options_CertificateTransparencyLoggingPreference;
            }
            if (requestOptions_options_CertificateTransparencyLoggingPreference != null)
            {
                request.Options.CertificateTransparencyLoggingPreference = requestOptions_options_CertificateTransparencyLoggingPreference;
                requestOptionsIsNull = false;
            }
             // determine if request.Options should be set to null
            if (requestOptionsIsNull)
            {
                request.Options = null;
            }
            if (cmdletContext.SubjectAlternativeName != null)
            {
                request.SubjectAlternativeNames = cmdletContext.SubjectAlternativeName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.ValidationMethod != null)
            {
                request.ValidationMethod = cmdletContext.ValidationMethod;
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
        
        private Amazon.CertificateManager.Model.RequestCertificateResponse CallAWSServiceOperation(IAmazonCertificateManager client, Amazon.CertificateManager.Model.RequestCertificateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager", "RequestCertificate");
            try
            {
                #if DESKTOP
                return client.RequestCertificate(request);
                #elif CORECLR
                return client.RequestCertificateAsync(request).GetAwaiter().GetResult();
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
            public System.String CertificateAuthorityArn { get; set; }
            public System.String DomainName { get; set; }
            public List<Amazon.CertificateManager.Model.DomainValidationOption> DomainValidationOption { get; set; }
            public System.String IdempotencyToken { get; set; }
            public Amazon.CertificateManager.CertificateTransparencyLoggingPreference Options_CertificateTransparencyLoggingPreference { get; set; }
            public List<System.String> SubjectAlternativeName { get; set; }
            public List<Amazon.CertificateManager.Model.Tag> Tag { get; set; }
            public Amazon.CertificateManager.ValidationMethod ValidationMethod { get; set; }
            public System.Func<Amazon.CertificateManager.Model.RequestCertificateResponse, NewACMCertificateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CertificateArn;
        }
        
    }
}
