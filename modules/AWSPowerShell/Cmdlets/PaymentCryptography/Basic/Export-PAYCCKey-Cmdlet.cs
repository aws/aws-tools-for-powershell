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
using Amazon.PaymentCryptography;
using Amazon.PaymentCryptography.Model;

namespace Amazon.PowerShell.Cmdlets.PAYCC
{
    /// <summary>
    /// Exports a key from Amazon Web Services Payment Cryptography using either ANSI X9 TR-34
    /// or TR-31 key export standard.
    /// 
    ///  
    /// <para>
    /// Amazon Web Services Payment Cryptography simplifies main or root key exchange process
    /// by eliminating the need of a paper-based key exchange process. It takes a modern and
    /// secure approach based of the ANSI X9 TR-34 key exchange standard.
    /// </para><para>
    /// You can use <code>ExportKey</code> to export main or root keys such as KEK (Key Encryption
    /// Key), using asymmetric key exchange technique following ANSI X9 TR-34 standard. The
    /// ANSI X9 TR-34 standard uses asymmetric keys to establishes bi-directional trust between
    /// the two parties exchanging keys. After which you can export working keys using the
    /// ANSI X9 TR-31 symmetric key exchange standard as mandated by PCI PIN. Using this operation,
    /// you can share your Amazon Web Services Payment Cryptography generated keys with other
    /// service partners to perform cryptographic operations outside of Amazon Web Services
    /// Payment Cryptography 
    /// </para><para><b>TR-34 key export</b></para><para>
    /// Amazon Web Services Payment Cryptography uses TR-34 asymmetric key exchange standard
    /// to export main keys such as KEK. In TR-34 terminology, the sending party of the key
    /// is called Key Distribution Host (KDH) and the receiving party of the key is called
    /// Key Receiving Host (KRH). In key export process, KDH is Amazon Web Services Payment
    /// Cryptography which initiates key export. KRH is the user receiving the key. Before
    /// you initiate TR-34 key export, you must obtain an export token by calling <a>GetParametersForExport</a>.
    /// This operation also returns the signing key certificate that KDH uses to sign the
    /// wrapped key to generate a TR-34 wrapped key block. The export token expires after
    /// 7 days.
    /// </para><para>
    /// Set the following parameters:
    /// </para><dl><dt>CertificateAuthorityPublicKeyIdentifier</dt><dd><para>
    /// The <code>KeyARN</code> of the certificate chain that will sign the wrapping key certificate.
    /// This must exist within Amazon Web Services Payment Cryptography before you initiate
    /// TR-34 key export. If it does not exist, you can import it by calling <a>ImportKey</a>
    /// for <code>RootCertificatePublicKey</code>.
    /// </para></dd><dt>ExportToken</dt><dd><para>
    /// Obtained from KDH by calling <a>GetParametersForExport</a>.
    /// </para></dd><dt>WrappingKeyCertificate</dt><dd><para>
    /// Amazon Web Services Payment Cryptography uses this to wrap the key under export.
    /// </para></dd></dl><para>
    /// When this operation is successful, Amazon Web Services Payment Cryptography returns
    /// the TR-34 wrapped key block. 
    /// </para><para><b>TR-31 key export</b></para><para>
    /// Amazon Web Services Payment Cryptography uses TR-31 symmetric key exchange standard
    /// to export working keys. In TR-31, you must use a main key such as KEK to encrypt or
    /// wrap the key under export. To establish a KEK, you can use <a>CreateKey</a> or <a>ImportKey</a>.
    /// When this operation is successful, Amazon Web Services Payment Cryptography returns
    /// a TR-31 wrapped key block. 
    /// </para><para><b>Cross-account use:</b> This operation can't be used across different Amazon Web
    /// Services accounts.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>GetParametersForExport</a></para></li><li><para><a>ImportKey</a></para></li></ul>
    /// </summary>
    [Cmdlet("Export", "PAYCCKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PaymentCryptography.Model.WrappedKey")]
    [AWSCmdlet("Calls the Payment Cryptography Control Plane ExportKey API operation.", Operation = new[] {"ExportKey"}, SelectReturnType = typeof(Amazon.PaymentCryptography.Model.ExportKeyResponse))]
    [AWSCmdletOutput("Amazon.PaymentCryptography.Model.WrappedKey or Amazon.PaymentCryptography.Model.ExportKeyResponse",
        "This cmdlet returns an Amazon.PaymentCryptography.Model.WrappedKey object.",
        "The service call response (type Amazon.PaymentCryptography.Model.ExportKeyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ExportPAYCCKeyCmdlet : AmazonPaymentCryptographyClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        #region Parameter Tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <code>KeyARN</code> of the certificate chain that signs the wrapping key certificate
        /// during TR-34 key export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier")]
        public System.String Tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter ExportKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <code>KeyARN</code> of the key under export from Amazon Web Services Payment Cryptography.</para>
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
        public System.String ExportKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter Tr34KeyBlock_ExportToken
        /// <summary>
        /// <para>
        /// <para>The export token to initiate key export from Amazon Web Services Payment Cryptography.
        /// It also contains the signing key certificate that will sign the wrapped key during
        /// TR-34 key block generation. Call <a>GetParametersForExport</a> to receive an export
        /// token. It expires after 7 days. You can use the same export token to export multiple
        /// keys from the same service account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr34KeyBlock_ExportToken")]
        public System.String Tr34KeyBlock_ExportToken { get; set; }
        #endregion
        
        #region Parameter Tr34KeyBlock_KeyBlockFormat
        /// <summary>
        /// <para>
        /// <para>The format of key block that Amazon Web Services Payment Cryptography will use during
        /// key export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr34KeyBlock_KeyBlockFormat")]
        [AWSConstantClassSource("Amazon.PaymentCryptography.Tr34KeyBlockFormat")]
        public Amazon.PaymentCryptography.Tr34KeyBlockFormat Tr34KeyBlock_KeyBlockFormat { get; set; }
        #endregion
        
        #region Parameter Tr34KeyBlock_RandomNonce
        /// <summary>
        /// <para>
        /// <para>A random number value that is unique to the TR-34 key block generated using 2 pass.
        /// The operation will fail, if a random nonce value is not provided for a TR-34 key block
        /// generated using 2 pass.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr34KeyBlock_RandomNonce")]
        public System.String Tr34KeyBlock_RandomNonce { get; set; }
        #endregion
        
        #region Parameter Tr34KeyBlock_WrappingKeyCertificate
        /// <summary>
        /// <para>
        /// <para>The <code>KeyARN</code> of the wrapping key certificate. Amazon Web Services Payment
        /// Cryptography uses this certificate to wrap the key under export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr34KeyBlock_WrappingKeyCertificate")]
        public System.String Tr34KeyBlock_WrappingKeyCertificate { get; set; }
        #endregion
        
        #region Parameter Tr31KeyBlock_WrappingKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <code>KeyARN</code> of the the wrapping key. This key encrypts or wraps the key
        /// under export for TR-31 key block generation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr31KeyBlock_WrappingKeyIdentifier")]
        public System.String Tr31KeyBlock_WrappingKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'WrappedKey'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PaymentCryptography.Model.ExportKeyResponse).
        /// Specifying the name of a property of type Amazon.PaymentCryptography.Model.ExportKeyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "WrappedKey";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ExportKeyIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ExportKeyIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ExportKeyIdentifier' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExportKeyIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Export-PAYCCKey (ExportKey)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PaymentCryptography.Model.ExportKeyResponse, ExportPAYCCKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ExportKeyIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ExportKeyIdentifier = this.ExportKeyIdentifier;
            #if MODULAR
            if (this.ExportKeyIdentifier == null && ParameterWasBound(nameof(this.ExportKeyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ExportKeyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Tr31KeyBlock_WrappingKeyIdentifier = this.Tr31KeyBlock_WrappingKeyIdentifier;
            context.Tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier = this.Tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier;
            context.Tr34KeyBlock_ExportToken = this.Tr34KeyBlock_ExportToken;
            context.Tr34KeyBlock_KeyBlockFormat = this.Tr34KeyBlock_KeyBlockFormat;
            context.Tr34KeyBlock_RandomNonce = this.Tr34KeyBlock_RandomNonce;
            context.Tr34KeyBlock_WrappingKeyCertificate = this.Tr34KeyBlock_WrappingKeyCertificate;
            
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
            var request = new Amazon.PaymentCryptography.Model.ExportKeyRequest();
            
            if (cmdletContext.ExportKeyIdentifier != null)
            {
                request.ExportKeyIdentifier = cmdletContext.ExportKeyIdentifier;
            }
            
             // populate KeyMaterial
            var requestKeyMaterialIsNull = true;
            request.KeyMaterial = new Amazon.PaymentCryptography.Model.ExportKeyMaterial();
            Amazon.PaymentCryptography.Model.ExportTr31KeyBlock requestKeyMaterial_keyMaterial_Tr31KeyBlock = null;
            
             // populate Tr31KeyBlock
            var requestKeyMaterial_keyMaterial_Tr31KeyBlockIsNull = true;
            requestKeyMaterial_keyMaterial_Tr31KeyBlock = new Amazon.PaymentCryptography.Model.ExportTr31KeyBlock();
            System.String requestKeyMaterial_keyMaterial_Tr31KeyBlock_tr31KeyBlock_WrappingKeyIdentifier = null;
            if (cmdletContext.Tr31KeyBlock_WrappingKeyIdentifier != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock_tr31KeyBlock_WrappingKeyIdentifier = cmdletContext.Tr31KeyBlock_WrappingKeyIdentifier;
            }
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlock_tr31KeyBlock_WrappingKeyIdentifier != null)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock.WrappingKeyIdentifier = requestKeyMaterial_keyMaterial_Tr31KeyBlock_tr31KeyBlock_WrappingKeyIdentifier;
                requestKeyMaterial_keyMaterial_Tr31KeyBlockIsNull = false;
            }
             // determine if requestKeyMaterial_keyMaterial_Tr31KeyBlock should be set to null
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlockIsNull)
            {
                requestKeyMaterial_keyMaterial_Tr31KeyBlock = null;
            }
            if (requestKeyMaterial_keyMaterial_Tr31KeyBlock != null)
            {
                request.KeyMaterial.Tr31KeyBlock = requestKeyMaterial_keyMaterial_Tr31KeyBlock;
                requestKeyMaterialIsNull = false;
            }
            Amazon.PaymentCryptography.Model.ExportTr34KeyBlock requestKeyMaterial_keyMaterial_Tr34KeyBlock = null;
            
             // populate Tr34KeyBlock
            var requestKeyMaterial_keyMaterial_Tr34KeyBlockIsNull = true;
            requestKeyMaterial_keyMaterial_Tr34KeyBlock = new Amazon.PaymentCryptography.Model.ExportTr34KeyBlock();
            System.String requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier = null;
            if (cmdletContext.Tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier = cmdletContext.Tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock.CertificateAuthorityPublicKeyIdentifier = requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier;
                requestKeyMaterial_keyMaterial_Tr34KeyBlockIsNull = false;
            }
            System.String requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_ExportToken = null;
            if (cmdletContext.Tr34KeyBlock_ExportToken != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_ExportToken = cmdletContext.Tr34KeyBlock_ExportToken;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_ExportToken != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock.ExportToken = requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_ExportToken;
                requestKeyMaterial_keyMaterial_Tr34KeyBlockIsNull = false;
            }
            Amazon.PaymentCryptography.Tr34KeyBlockFormat requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_KeyBlockFormat = null;
            if (cmdletContext.Tr34KeyBlock_KeyBlockFormat != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_KeyBlockFormat = cmdletContext.Tr34KeyBlock_KeyBlockFormat;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_KeyBlockFormat != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock.KeyBlockFormat = requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_KeyBlockFormat;
                requestKeyMaterial_keyMaterial_Tr34KeyBlockIsNull = false;
            }
            System.String requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_RandomNonce = null;
            if (cmdletContext.Tr34KeyBlock_RandomNonce != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_RandomNonce = cmdletContext.Tr34KeyBlock_RandomNonce;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_RandomNonce != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock.RandomNonce = requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_RandomNonce;
                requestKeyMaterial_keyMaterial_Tr34KeyBlockIsNull = false;
            }
            System.String requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_WrappingKeyCertificate = null;
            if (cmdletContext.Tr34KeyBlock_WrappingKeyCertificate != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_WrappingKeyCertificate = cmdletContext.Tr34KeyBlock_WrappingKeyCertificate;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_WrappingKeyCertificate != null)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock.WrappingKeyCertificate = requestKeyMaterial_keyMaterial_Tr34KeyBlock_tr34KeyBlock_WrappingKeyCertificate;
                requestKeyMaterial_keyMaterial_Tr34KeyBlockIsNull = false;
            }
             // determine if requestKeyMaterial_keyMaterial_Tr34KeyBlock should be set to null
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlockIsNull)
            {
                requestKeyMaterial_keyMaterial_Tr34KeyBlock = null;
            }
            if (requestKeyMaterial_keyMaterial_Tr34KeyBlock != null)
            {
                request.KeyMaterial.Tr34KeyBlock = requestKeyMaterial_keyMaterial_Tr34KeyBlock;
                requestKeyMaterialIsNull = false;
            }
             // determine if request.KeyMaterial should be set to null
            if (requestKeyMaterialIsNull)
            {
                request.KeyMaterial = null;
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
        
        private Amazon.PaymentCryptography.Model.ExportKeyResponse CallAWSServiceOperation(IAmazonPaymentCryptography client, Amazon.PaymentCryptography.Model.ExportKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Payment Cryptography Control Plane", "ExportKey");
            try
            {
                #if DESKTOP
                return client.ExportKey(request);
                #elif CORECLR
                return client.ExportKeyAsync(request).GetAwaiter().GetResult();
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
            public System.String ExportKeyIdentifier { get; set; }
            public System.String Tr31KeyBlock_WrappingKeyIdentifier { get; set; }
            public System.String Tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier { get; set; }
            public System.String Tr34KeyBlock_ExportToken { get; set; }
            public Amazon.PaymentCryptography.Tr34KeyBlockFormat Tr34KeyBlock_KeyBlockFormat { get; set; }
            public System.String Tr34KeyBlock_RandomNonce { get; set; }
            public System.String Tr34KeyBlock_WrappingKeyCertificate { get; set; }
            public System.Func<Amazon.PaymentCryptography.Model.ExportKeyResponse, ExportPAYCCKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.WrappedKey;
        }
        
    }
}
