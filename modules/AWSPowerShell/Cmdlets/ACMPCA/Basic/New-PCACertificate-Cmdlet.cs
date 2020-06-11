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
using Amazon.ACMPCA;
using Amazon.ACMPCA.Model;

namespace Amazon.PowerShell.Cmdlets.PCA
{
    /// <summary>
    /// Uses your private certificate authority (CA), or one that has been shared with you,
    /// to issue a client certificate. This action returns the Amazon Resource Name (ARN)
    /// of the certificate. You can retrieve the certificate by calling the <a href="https://docs.aws.amazon.com/acm-pca/latest/APIReference/API_GetCertificate.html">GetCertificate</a>
    /// action and specifying the ARN. 
    /// 
    ///  <note><para>
    /// You cannot use the ACM <b>ListCertificateAuthorities</b> action to retrieve the ARNs
    /// of the certificates that you issue by using ACM Private CA.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "PCACertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Certificate Manager Private Certificate Authority IssueCertificate API operation.", Operation = new[] {"IssueCertificate"}, SelectReturnType = typeof(Amazon.ACMPCA.Model.IssueCertificateResponse))]
    [AWSCmdletOutput("System.String or Amazon.ACMPCA.Model.IssueCertificateResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ACMPCA.Model.IssueCertificateResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPCACertificateCmdlet : AmazonACMPCAClientCmdlet, IExecutor
    {
        
        #region Parameter CertificateAuthorityArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that was returned when you called <a href="https://docs.aws.amazon.com/acm-pca/latest/APIReference/API_CreateCertificateAuthority.html">CreateCertificateAuthority</a>.
        /// This must be of the form:</para><para><code>arn:aws:acm-pca:<i>region</i>:<i>account</i>:certificate-authority/<i>12345678-1234-1234-1234-123456789012</i></code></para>
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
        public System.String CertificateAuthorityArn { get; set; }
        #endregion
        
        #region Parameter Csr
        /// <summary>
        /// <para>
        /// <para>The certificate signing request (CSR) for the certificate you want to issue. You can
        /// use the following OpenSSL command to create the CSR and a 2048 bit RSA private key.
        /// </para><para><code>openssl req -new -newkey rsa:2048 -days 365 -keyout private/test_cert_priv_key.pem
        /// -out csr/test_cert_.csr</code></para><para>If you have a configuration file, you can use the following OpenSSL command. The <code>usr_cert</code>
        /// block in the configuration file contains your X509 version 3 extensions. </para><para><code>openssl req -new -config openssl_rsa.cnf -extensions usr_cert -newkey rsa:2048
        /// -days -365 -keyout private/test_cert_priv_key.pem -out csr/test_cert_.csr</code></para><para>Note: A CSR must provide either a <i>subject name</i> or a <i>subject alternative
        /// name</i> or the request will be rejected. </para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Csr { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>Custom string that can be used to distinguish between calls to the <b>IssueCertificate</b>
        /// action. Idempotency tokens time out after one hour. Therefore, if you call <b>IssueCertificate</b>
        /// multiple times with the same idempotency token within 5 minutes, ACM Private CA recognizes
        /// that you are requesting only one certificate and will issue only one. If you change
        /// the idempotency token for each call, PCA recognizes that you are requesting multiple
        /// certificates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter SigningAlgorithm
        /// <summary>
        /// <para>
        /// <para>The name of the algorithm that will be used to sign the certificate to be issued.
        /// </para><para>This parameter should not be confused with the <code>SigningAlgorithm</code> parameter
        /// used to sign a CSR.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ACMPCA.SigningAlgorithm")]
        public Amazon.ACMPCA.SigningAlgorithm SigningAlgorithm { get; set; }
        #endregion
        
        #region Parameter TemplateArn
        /// <summary>
        /// <para>
        /// <para>Specifies a custom configuration template to use when issuing a certificate. If this
        /// parameter is not provided, ACM Private CA defaults to the <code>EndEntityCertificate/V1</code>
        /// template. For CA certificates, you should choose the shortest path length that meets
        /// your needs. The path length is indicated by the PathLen<i>N</i> portion of the ARN,
        /// where <i>N</i> is the <a href="https://docs.aws.amazon.com/acm-pca/latest/userguide/PcaTerms.html#terms-cadepth">CA
        /// depth</a>.</para><para>Note: The CA depth configured on a subordinate CA certificate must not exceed the
        /// limit set by its parents in the CA hierarchy.</para><para>The following service-owned <code>TemplateArn</code> values are supported by ACM Private
        /// CA: </para><ul><li><para>arn:aws:acm-pca:::template/CodeSigningCertificate/V1</para></li><li><para>arn:aws:acm-pca:::template/CodeSigningCertificate_CSRPassthrough/V1</para></li><li><para>arn:aws:acm-pca:::template/EndEntityCertificate/V1</para></li><li><para>arn:aws:acm-pca:::template/EndEntityCertificate_CSRPassthrough/V1</para></li><li><para>arn:aws:acm-pca:::template/EndEntityClientAuthCertificate/V1</para></li><li><para>arn:aws:acm-pca:::template/EndEntityClientAuthCertificate_CSRPassthrough/V1</para></li><li><para>arn:aws:acm-pca:::template/EndEntityServerAuthCertificate/V1</para></li><li><para>arn:aws:acm-pca:::template/EndEntityServerAuthCertificate_CSRPassthrough/V1</para></li><li><para>arn:aws:acm-pca:::template/OCSPSigningCertificate/V1</para></li><li><para>arn:aws:acm-pca:::template/OCSPSigningCertificate_CSRPassthrough/V1</para></li><li><para>arn:aws:acm-pca:::template/RootCACertificate/V1</para></li><li><para>arn:aws:acm-pca:::template/SubordinateCACertificate_PathLen0/V1</para></li><li><para>arn:aws:acm-pca:::template/SubordinateCACertificate_PathLen1/V1</para></li><li><para>arn:aws:acm-pca:::template/SubordinateCACertificate_PathLen2/V1</para></li><li><para>arn:aws:acm-pca:::template/SubordinateCACertificate_PathLen3/V1</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/acm-pca/latest/userguide/UsingTemplates.html">Using
        /// Templates</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateArn { get; set; }
        #endregion
        
        #region Parameter Validity
        /// <summary>
        /// <para>
        /// <para>Information describing the validity period of the certificate.</para><para>When issuing a certificate, ACM Private CA sets the "Not Before" date in the validity
        /// field to date and time minus 60 minutes. This is intended to compensate for time inconsistencies
        /// across systems of 60 minutes or less. </para><para>The validity period configured on a certificate must not exceed the limit set by its
        /// parents in the CA hierarchy.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.ACMPCA.Model.Validity Validity { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CertificateArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ACMPCA.Model.IssueCertificateResponse).
        /// Specifying the name of a property of type Amazon.ACMPCA.Model.IssueCertificateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CertificateArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CertificateAuthorityArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CertificateAuthorityArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CertificateAuthorityArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CertificateAuthorityArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PCACertificate (IssueCertificate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ACMPCA.Model.IssueCertificateResponse, NewPCACertificateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CertificateAuthorityArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CertificateAuthorityArn = this.CertificateAuthorityArn;
            #if MODULAR
            if (this.CertificateAuthorityArn == null && ParameterWasBound(nameof(this.CertificateAuthorityArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateAuthorityArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Csr = this.Csr;
            #if MODULAR
            if (this.Csr == null && ParameterWasBound(nameof(this.Csr)))
            {
                WriteWarning("You are passing $null as a value for parameter Csr which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdempotencyToken = this.IdempotencyToken;
            context.SigningAlgorithm = this.SigningAlgorithm;
            #if MODULAR
            if (this.SigningAlgorithm == null && ParameterWasBound(nameof(this.SigningAlgorithm)))
            {
                WriteWarning("You are passing $null as a value for parameter SigningAlgorithm which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TemplateArn = this.TemplateArn;
            context.Validity = this.Validity;
            #if MODULAR
            if (this.Validity == null && ParameterWasBound(nameof(this.Validity)))
            {
                WriteWarning("You are passing $null as a value for parameter Validity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.MemoryStream _CsrStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.ACMPCA.Model.IssueCertificateRequest();
                
                if (cmdletContext.CertificateAuthorityArn != null)
                {
                    request.CertificateAuthorityArn = cmdletContext.CertificateAuthorityArn;
                }
                if (cmdletContext.Csr != null)
                {
                    _CsrStream = new System.IO.MemoryStream(cmdletContext.Csr);
                    request.Csr = _CsrStream;
                }
                if (cmdletContext.IdempotencyToken != null)
                {
                    request.IdempotencyToken = cmdletContext.IdempotencyToken;
                }
                if (cmdletContext.SigningAlgorithm != null)
                {
                    request.SigningAlgorithm = cmdletContext.SigningAlgorithm;
                }
                if (cmdletContext.TemplateArn != null)
                {
                    request.TemplateArn = cmdletContext.TemplateArn;
                }
                if (cmdletContext.Validity != null)
                {
                    request.Validity = cmdletContext.Validity;
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
            finally
            {
                if( _CsrStream != null)
                {
                    _CsrStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ACMPCA.Model.IssueCertificateResponse CallAWSServiceOperation(IAmazonACMPCA client, Amazon.ACMPCA.Model.IssueCertificateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager Private Certificate Authority", "IssueCertificate");
            try
            {
                #if DESKTOP
                return client.IssueCertificate(request);
                #elif CORECLR
                return client.IssueCertificateAsync(request).GetAwaiter().GetResult();
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
            public byte[] Csr { get; set; }
            public System.String IdempotencyToken { get; set; }
            public Amazon.ACMPCA.SigningAlgorithm SigningAlgorithm { get; set; }
            public System.String TemplateArn { get; set; }
            public Amazon.ACMPCA.Model.Validity Validity { get; set; }
            public System.Func<Amazon.ACMPCA.Model.IssueCertificateResponse, NewPCACertificateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CertificateArn;
        }
        
    }
}
