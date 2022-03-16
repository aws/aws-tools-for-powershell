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
    /// Imports a signed private CA certificate into Amazon Web Services Private CA. This
    /// action is used when you are using a chain of trust whose root is located outside Amazon
    /// Web Services Private CA. Before you can call this action, the following preparations
    /// must in place:
    /// 
    ///  <ol><li><para>
    /// In Amazon Web Services Private CA, call the <a href="https://docs.aws.amazon.com/acm-pca/latest/APIReference/API_CreateCertificateAuthority.html">CreateCertificateAuthority</a>
    /// action to create the private CA that you plan to back with the imported certificate.
    /// </para></li><li><para>
    /// Call the <a href="https://docs.aws.amazon.com/acm-pca/latest/APIReference/API_GetCertificateAuthorityCsr.html">GetCertificateAuthorityCsr</a>
    /// action to generate a certificate signing request (CSR).
    /// </para></li><li><para>
    /// Sign the CSR using a root or intermediate CA hosted by either an on-premises PKI hierarchy
    /// or by a commercial CA.
    /// </para></li><li><para>
    /// Create a certificate chain and copy the signed certificate and the certificate chain
    /// to your working directory.
    /// </para></li></ol><para>
    /// Amazon Web Services Private CA supports three scenarios for installing a CA certificate:
    /// </para><ul><li><para>
    /// Installing a certificate for a root CA hosted by Amazon Web Services Private CA.
    /// </para></li><li><para>
    /// Installing a subordinate CA certificate whose parent authority is hosted by Amazon
    /// Web Services Private CA.
    /// </para></li><li><para>
    /// Installing a subordinate CA certificate whose parent authority is externally hosted.
    /// </para></li></ul><para>
    /// The following additional requirements apply when you import a CA certificate.
    /// </para><ul><li><para>
    /// Only a self-signed certificate can be imported as a root CA.
    /// </para></li><li><para>
    /// A self-signed certificate cannot be imported as a subordinate CA.
    /// </para></li><li><para>
    /// Your certificate chain must not include the private CA certificate that you are importing.
    /// </para></li><li><para>
    /// Your root CA must be the last certificate in your chain. The subordinate certificate,
    /// if any, that your root CA signed must be next to last. The subordinate certificate
    /// signed by the preceding subordinate CA must come next, and so on until your chain
    /// is built. 
    /// </para></li><li><para>
    /// The chain must be PEM-encoded.
    /// </para></li><li><para>
    /// The maximum allowed size of a certificate is 32 KB.
    /// </para></li><li><para>
    /// The maximum allowed size of a certificate chain is 2 MB.
    /// </para></li></ul><para><i>Enforcement of Critical Constraints</i></para><para>
    /// Amazon Web Services Private CA allows the following extensions to be marked critical
    /// in the imported CA certificate or chain.
    /// </para><ul><li><para>
    /// Basic constraints (<i>must</i> be marked critical)
    /// </para></li><li><para>
    /// Subject alternative names
    /// </para></li><li><para>
    /// Key usage
    /// </para></li><li><para>
    /// Extended key usage
    /// </para></li><li><para>
    /// Authority key identifier
    /// </para></li><li><para>
    /// Subject key identifier
    /// </para></li><li><para>
    /// Issuer alternative name
    /// </para></li><li><para>
    /// Subject directory attributes
    /// </para></li><li><para>
    /// Subject information access
    /// </para></li><li><para>
    /// Certificate policies
    /// </para></li><li><para>
    /// Policy mappings
    /// </para></li><li><para>
    /// Inhibit anyPolicy
    /// </para></li></ul><para>
    /// Amazon Web Services Private CA rejects the following extensions when they are marked
    /// critical in an imported CA certificate or chain.
    /// </para><ul><li><para>
    /// Name constraints
    /// </para></li><li><para>
    /// Policy constraints
    /// </para></li><li><para>
    /// CRL distribution points
    /// </para></li><li><para>
    /// Authority information access
    /// </para></li><li><para>
    /// Freshest CRL
    /// </para></li><li><para>
    /// Any other extension
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Import", "PCACertificateAuthorityCertificate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Certificate Manager Private Certificate Authority ImportCertificateAuthorityCertificate API operation.", Operation = new[] {"ImportCertificateAuthorityCertificate"}, SelectReturnType = typeof(Amazon.ACMPCA.Model.ImportCertificateAuthorityCertificateResponse))]
    [AWSCmdletOutput("None or Amazon.ACMPCA.Model.ImportCertificateAuthorityCertificateResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ACMPCA.Model.ImportCertificateAuthorityCertificateResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ImportPCACertificateAuthorityCertificateCmdlet : AmazonACMPCAClientCmdlet, IExecutor
    {
        
        #region Parameter Certificate
        /// <summary>
        /// <para>
        /// <para>The PEM-encoded certificate for a private CA. This may be a self-signed certificate
        /// in the case of a root CA, or it may be signed by another CA that you control.</para>
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
        public byte[] Certificate { get; set; }
        #endregion
        
        #region Parameter CertificateAuthorityArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that was returned when you called <a href="https://docs.aws.amazon.com/acm-pca/latest/APIReference/API_CreateCertificateAuthority.html">CreateCertificateAuthority</a>.
        /// This must be of the form: </para><para><code>arn:aws:acm-pca:<i>region</i>:<i>account</i>:certificate-authority/<i>12345678-1234-1234-1234-123456789012</i></code></para>
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
        
        #region Parameter CertificateChain
        /// <summary>
        /// <para>
        /// <para>A PEM-encoded file that contains all of your certificates, other than the certificate
        /// you're importing, chaining up to your root CA. Your Amazon Web Services Private CA-hosted
        /// or on-premises root certificate is the last in the chain, and each certificate in
        /// the chain signs the one preceding. </para><para>This parameter must be supplied when you import a subordinate CA. When you import
        /// a root CA, there is no chain.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] CertificateChain { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ACMPCA.Model.ImportCertificateAuthorityCertificateResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-PCACertificateAuthorityCertificate (ImportCertificateAuthorityCertificate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ACMPCA.Model.ImportCertificateAuthorityCertificateResponse, ImportPCACertificateAuthorityCertificateCmdlet>(Select) ??
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
            context.Certificate = this.Certificate;
            #if MODULAR
            if (this.Certificate == null && ParameterWasBound(nameof(this.Certificate)))
            {
                WriteWarning("You are passing $null as a value for parameter Certificate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CertificateAuthorityArn = this.CertificateAuthorityArn;
            #if MODULAR
            if (this.CertificateAuthorityArn == null && ParameterWasBound(nameof(this.CertificateAuthorityArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateAuthorityArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CertificateChain = this.CertificateChain;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _CertificateStream = null;
            System.IO.MemoryStream _CertificateChainStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.ACMPCA.Model.ImportCertificateAuthorityCertificateRequest();
                
                if (cmdletContext.Certificate != null)
                {
                    _CertificateStream = new System.IO.MemoryStream(cmdletContext.Certificate);
                    request.Certificate = _CertificateStream;
                }
                if (cmdletContext.CertificateAuthorityArn != null)
                {
                    request.CertificateAuthorityArn = cmdletContext.CertificateAuthorityArn;
                }
                if (cmdletContext.CertificateChain != null)
                {
                    _CertificateChainStream = new System.IO.MemoryStream(cmdletContext.CertificateChain);
                    request.CertificateChain = _CertificateChainStream;
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
                if( _CertificateStream != null)
                {
                    _CertificateStream.Dispose();
                }
                if( _CertificateChainStream != null)
                {
                    _CertificateChainStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ACMPCA.Model.ImportCertificateAuthorityCertificateResponse CallAWSServiceOperation(IAmazonACMPCA client, Amazon.ACMPCA.Model.ImportCertificateAuthorityCertificateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Certificate Manager Private Certificate Authority", "ImportCertificateAuthorityCertificate");
            try
            {
                #if DESKTOP
                return client.ImportCertificateAuthorityCertificate(request);
                #elif CORECLR
                return client.ImportCertificateAuthorityCertificateAsync(request).GetAwaiter().GetResult();
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
            public byte[] Certificate { get; set; }
            public System.String CertificateAuthorityArn { get; set; }
            public byte[] CertificateChain { get; set; }
            public System.Func<Amazon.ACMPCA.Model.ImportCertificateAuthorityCertificateResponse, ImportPCACertificateAuthorityCertificateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
