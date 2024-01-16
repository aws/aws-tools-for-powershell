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
    /// Exports a key from Amazon Web Services Payment Cryptography.
    /// 
    ///  
    /// <para>
    /// Amazon Web Services Payment Cryptography simplifies key exchange by replacing the
    /// existing paper-based approach with a modern electronic approach. With <c>ExportKey</c>
    /// you can export symmetric keys using either symmetric and asymmetric key exchange mechanisms.
    /// Using this operation, you can share your Amazon Web Services Payment Cryptography
    /// generated keys with other service partners to perform cryptographic operations outside
    /// of Amazon Web Services Payment Cryptography 
    /// </para><para>
    /// For symmetric key exchange, Amazon Web Services Payment Cryptography uses the ANSI
    /// X9 TR-31 norm in accordance with PCI PIN guidelines. And for asymmetric key exchange,
    /// Amazon Web Services Payment Cryptography supports ANSI X9 TR-34 norm and RSA wrap
    /// and unwrap key exchange mechanism. Asymmetric key exchange methods are typically used
    /// to establish bi-directional trust between the two parties exhanging keys and are used
    /// for initial key exchange such as Key Encryption Key (KEK). After which you can export
    /// working keys using symmetric method to perform various cryptographic operations within
    /// Amazon Web Services Payment Cryptography.
    /// </para><para>
    /// The TR-34 norm is intended for exchanging 3DES keys only and keys are imported in
    /// a WrappedKeyBlock format. Key attributes (such as KeyUsage, KeyAlgorithm, KeyModesOfUse,
    /// Exportability) are contained within the key block. With RSA wrap and unwrap, you can
    /// exchange both 3DES and AES-128 keys. The keys are imported in a WrappedKeyCryptogram
    /// format and you will need to specify the key attributes during import. 
    /// </para><para>
    /// You can also use <c>ExportKey</c> functionality to generate and export an IPEK (Initial
    /// Pin Encryption Key) from Amazon Web Services Payment Cryptography using either TR-31
    /// or TR-34 export key exchange. IPEK is generated from BDK (Base Derivation Key) and
    /// <c>ExportDukptInitialKey</c> attribute KSN (<c>KeySerialNumber</c>). The generated
    /// IPEK does not persist within Amazon Web Services Payment Cryptography and has to be
    /// re-generated each time during export.
    /// </para><para><b>To export initial keys (KEK) or IPEK using TR-34</b></para><para>
    /// Using this operation, you can export initial key using TR-34 asymmetric key exchange.
    /// You can only export KEK generated within Amazon Web Services Payment Cryptography.
    /// In TR-34 terminology, the sending party of the key is called Key Distribution Host
    /// (KDH) and the receiving party of the key is called Key Receiving Device (KRD). During
    /// key export process, KDH is Amazon Web Services Payment Cryptography which initiates
    /// key export and KRD is the user receiving the key.
    /// </para><para>
    /// To initiate TR-34 key export, the KRD must obtain an export token by calling <a>GetParametersForExport</a>.
    /// This operation also generates a key pair for the purpose of key export, signs the
    /// key and returns back the signing public key certificate (also known as KDH signing
    /// certificate) and root certificate chain. The KDH uses the private key to sign the
    /// the export payload and the signing public key certificate is provided to KRD to verify
    /// the signature. The KRD can import the root certificate into its Hardware Security
    /// Module (HSM), as required. The export token and the associated KDH signing certificate
    /// expires after 7 days. 
    /// </para><para>
    /// Next the KRD generates a key pair for the the purpose of encrypting the KDH key and
    /// provides the public key cerificate (also known as KRD wrapping certificate) back to
    /// KDH. The KRD will also import the root cerificate chain into Amazon Web Services Payment
    /// Cryptography by calling <a>ImportKey</a> for <c>RootCertificatePublicKey</c>. The
    /// KDH, Amazon Web Services Payment Cryptography, will use the KRD wrapping cerificate
    /// to encrypt (wrap) the key under export and signs it with signing private key to generate
    /// a TR-34 WrappedKeyBlock. For more information on TR-34 key export, see section <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/keys-export.html">Exporting
    /// symmetric keys</a> in the <i>Amazon Web Services Payment Cryptography User Guide</i>.
    /// 
    /// </para><para>
    /// Set the following parameters:
    /// </para><ul><li><para><c>ExportAttributes</c>: Specify export attributes in case of IPEK export. This parameter
    /// is optional for KEK export.
    /// </para></li><li><para><c>ExportKeyIdentifier</c>: The <c>KeyARN</c> of the KEK or BDK (in case of IPEK)
    /// under export.
    /// </para></li><li><para><c>KeyMaterial</c>: Use <c>Tr34KeyBlock</c> parameters.
    /// </para></li><li><para><c>CertificateAuthorityPublicKeyIdentifier</c>: The <c>KeyARN</c> of the certificate
    /// chain that signed the KRD wrapping key certificate.
    /// </para></li><li><para><c>ExportToken</c>: Obtained from KDH by calling <a>GetParametersForImport</a>.
    /// </para></li><li><para><c>WrappingKeyCertificate</c>: The public key certificate in PEM format (base64 encoded)
    /// of the KRD wrapping key Amazon Web Services Payment Cryptography uses for encryption
    /// of the TR-34 export payload. This certificate must be signed by the root certificate
    /// (CertificateAuthorityPublicKeyIdentifier) imported into Amazon Web Services Payment
    /// Cryptography.
    /// </para></li></ul><para>
    /// When this operation is successful, Amazon Web Services Payment Cryptography returns
    /// the KEK or IPEK as a TR-34 WrappedKeyBlock. 
    /// </para><para><b>To export initial keys (KEK) or IPEK using RSA Wrap and Unwrap</b></para><para>
    /// Using this operation, you can export initial key using asymmetric RSA wrap and unwrap
    /// key exchange method. To initiate export, generate an asymmetric key pair on the receiving
    /// HSM and obtain the public key certificate in PEM format (base64 encoded) for the purpose
    /// of wrapping and the root certifiate chain. Import the root certificate into Amazon
    /// Web Services Payment Cryptography by calling <a>ImportKey</a> for <c>RootCertificatePublicKey</c>.
    /// </para><para>
    /// Next call <c>ExportKey</c> and set the following parameters:
    /// </para><ul><li><para><c>CertificateAuthorityPublicKeyIdentifier</c>: The <c>KeyARN</c> of the certificate
    /// chain that signed wrapping key certificate.
    /// </para></li><li><para><c>KeyMaterial</c>: Set to <c>KeyCryptogram</c>.
    /// </para></li><li><para><c>WrappingKeyCertificate</c>: The public key certificate in PEM format (base64 encoded)
    /// obtained by the receiving HSM and signed by the root certificate (CertificateAuthorityPublicKeyIdentifier)
    /// imported into Amazon Web Services Payment Cryptography. The receiving HSM uses its
    /// private key component to unwrap the WrappedKeyCryptogram.
    /// </para></li></ul><para>
    /// When this operation is successful, Amazon Web Services Payment Cryptography returns
    /// the WrappedKeyCryptogram. 
    /// </para><para><b>To export working keys or IPEK using TR-31</b></para><para>
    /// Using this operation, you can export working keys or IPEK using TR-31 symmetric key
    /// exchange. In TR-31, you must use an initial key such as KEK to encrypt or wrap the
    /// key under export. To establish a KEK, you can use <a>CreateKey</a> or <a>ImportKey</a>.
    /// 
    /// </para><para>
    /// Set the following parameters:
    /// </para><ul><li><para><c>ExportAttributes</c>: Specify export attributes in case of IPEK export. This parameter
    /// is optional for KEK export.
    /// </para></li><li><para><c>ExportKeyIdentifier</c>: The <c>KeyARN</c> of the KEK or BDK (in case of IPEK)
    /// under export.
    /// </para></li><li><para><c>KeyMaterial</c>: Use <c>Tr31KeyBlock</c> parameters.
    /// </para></li></ul><para>
    /// When this operation is successful, Amazon Web Services Payment Cryptography returns
    /// the working key or IPEK as a TR-31 WrappedKeyBlock.
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
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter KeyCryptogram_CertificateAuthorityPublicKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>KeyARN</c> of the certificate chain that signs the wrapping key certificate
        /// during RSA wrap and unwrap key export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_KeyCryptogram_CertificateAuthorityPublicKeyIdentifier")]
        public System.String KeyCryptogram_CertificateAuthorityPublicKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter Tr34KeyBlock_CertificateAuthorityPublicKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>KeyARN</c> of the certificate chain that signs the wrapping key certificate
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
        /// <para>The <c>KeyARN</c> of the key under export from Amazon Web Services Payment Cryptography.</para>
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
        
        #region Parameter ExportAttributes_KeyCheckValueAlgorithm
        /// <summary>
        /// <para>
        /// <para>The algorithm that Amazon Web Services Payment Cryptography uses to calculate the
        /// key check value (KCV). It is used to validate the key integrity. Specify KCV for IPEK
        /// export only.</para><para>For TDES keys, the KCV is computed by encrypting 8 bytes, each with value of zero,
        /// with the key to be checked and retaining the 3 highest order bytes of the encrypted
        /// result. For AES keys, the KCV is computed using a CMAC algorithm where the input data
        /// is 16 bytes of zero and retaining the 3 highest order bytes of the encrypted result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PaymentCryptography.KeyCheckValueAlgorithm")]
        public Amazon.PaymentCryptography.KeyCheckValueAlgorithm ExportAttributes_KeyCheckValueAlgorithm { get; set; }
        #endregion
        
        #region Parameter ExportDukptInitialKey_KeySerialNumber
        /// <summary>
        /// <para>
        /// <para>The KSN for IPEK generation using DUKPT. </para><para>KSN must be padded before sending to Amazon Web Services Payment Cryptography. KSN
        /// hex length should be 20 for a TDES_2KEY key or 24 for an AES key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExportAttributes_ExportDukptInitialKey_KeySerialNumber")]
        public System.String ExportDukptInitialKey_KeySerialNumber { get; set; }
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
        
        #region Parameter KeyCryptogram_WrappingKeyCertificate
        /// <summary>
        /// <para>
        /// <para>The wrapping key certificate in PEM format (base64 encoded). Amazon Web Services Payment
        /// Cryptography uses this certificate to wrap the key under export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_KeyCryptogram_WrappingKeyCertificate")]
        public System.String KeyCryptogram_WrappingKeyCertificate { get; set; }
        #endregion
        
        #region Parameter Tr34KeyBlock_WrappingKeyCertificate
        /// <summary>
        /// <para>
        /// <para>The <c>KeyARN</c> of the wrapping key certificate. Amazon Web Services Payment Cryptography
        /// uses this certificate to wrap the key under export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr34KeyBlock_WrappingKeyCertificate")]
        public System.String Tr34KeyBlock_WrappingKeyCertificate { get; set; }
        #endregion
        
        #region Parameter Tr31KeyBlock_WrappingKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>KeyARN</c> of the the wrapping key. This key encrypts or wraps the key under
        /// export for TR-31 key block generation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_Tr31KeyBlock_WrappingKeyIdentifier")]
        public System.String Tr31KeyBlock_WrappingKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter KeyCryptogram_WrappingSpec
        /// <summary>
        /// <para>
        /// <para>The wrapping spec for the key under export.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KeyMaterial_KeyCryptogram_WrappingSpec")]
        [AWSConstantClassSource("Amazon.PaymentCryptography.WrappingKeySpec")]
        public Amazon.PaymentCryptography.WrappingKeySpec KeyCryptogram_WrappingSpec { get; set; }
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
            context.ExportDukptInitialKey_KeySerialNumber = this.ExportDukptInitialKey_KeySerialNumber;
            context.ExportAttributes_KeyCheckValueAlgorithm = this.ExportAttributes_KeyCheckValueAlgorithm;
            context.ExportKeyIdentifier = this.ExportKeyIdentifier;
            #if MODULAR
            if (this.ExportKeyIdentifier == null && ParameterWasBound(nameof(this.ExportKeyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ExportKeyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KeyCryptogram_CertificateAuthorityPublicKeyIdentifier = this.KeyCryptogram_CertificateAuthorityPublicKeyIdentifier;
            context.KeyCryptogram_WrappingKeyCertificate = this.KeyCryptogram_WrappingKeyCertificate;
            context.KeyCryptogram_WrappingSpec = this.KeyCryptogram_WrappingSpec;
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
            
            
             // populate ExportAttributes
            var requestExportAttributesIsNull = true;
            request.ExportAttributes = new Amazon.PaymentCryptography.Model.ExportAttributes();
            Amazon.PaymentCryptography.KeyCheckValueAlgorithm requestExportAttributes_exportAttributes_KeyCheckValueAlgorithm = null;
            if (cmdletContext.ExportAttributes_KeyCheckValueAlgorithm != null)
            {
                requestExportAttributes_exportAttributes_KeyCheckValueAlgorithm = cmdletContext.ExportAttributes_KeyCheckValueAlgorithm;
            }
            if (requestExportAttributes_exportAttributes_KeyCheckValueAlgorithm != null)
            {
                request.ExportAttributes.KeyCheckValueAlgorithm = requestExportAttributes_exportAttributes_KeyCheckValueAlgorithm;
                requestExportAttributesIsNull = false;
            }
            Amazon.PaymentCryptography.Model.ExportDukptInitialKey requestExportAttributes_exportAttributes_ExportDukptInitialKey = null;
            
             // populate ExportDukptInitialKey
            var requestExportAttributes_exportAttributes_ExportDukptInitialKeyIsNull = true;
            requestExportAttributes_exportAttributes_ExportDukptInitialKey = new Amazon.PaymentCryptography.Model.ExportDukptInitialKey();
            System.String requestExportAttributes_exportAttributes_ExportDukptInitialKey_exportDukptInitialKey_KeySerialNumber = null;
            if (cmdletContext.ExportDukptInitialKey_KeySerialNumber != null)
            {
                requestExportAttributes_exportAttributes_ExportDukptInitialKey_exportDukptInitialKey_KeySerialNumber = cmdletContext.ExportDukptInitialKey_KeySerialNumber;
            }
            if (requestExportAttributes_exportAttributes_ExportDukptInitialKey_exportDukptInitialKey_KeySerialNumber != null)
            {
                requestExportAttributes_exportAttributes_ExportDukptInitialKey.KeySerialNumber = requestExportAttributes_exportAttributes_ExportDukptInitialKey_exportDukptInitialKey_KeySerialNumber;
                requestExportAttributes_exportAttributes_ExportDukptInitialKeyIsNull = false;
            }
             // determine if requestExportAttributes_exportAttributes_ExportDukptInitialKey should be set to null
            if (requestExportAttributes_exportAttributes_ExportDukptInitialKeyIsNull)
            {
                requestExportAttributes_exportAttributes_ExportDukptInitialKey = null;
            }
            if (requestExportAttributes_exportAttributes_ExportDukptInitialKey != null)
            {
                request.ExportAttributes.ExportDukptInitialKey = requestExportAttributes_exportAttributes_ExportDukptInitialKey;
                requestExportAttributesIsNull = false;
            }
             // determine if request.ExportAttributes should be set to null
            if (requestExportAttributesIsNull)
            {
                request.ExportAttributes = null;
            }
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
            Amazon.PaymentCryptography.Model.ExportKeyCryptogram requestKeyMaterial_keyMaterial_KeyCryptogram = null;
            
             // populate KeyCryptogram
            var requestKeyMaterial_keyMaterial_KeyCryptogramIsNull = true;
            requestKeyMaterial_keyMaterial_KeyCryptogram = new Amazon.PaymentCryptography.Model.ExportKeyCryptogram();
            System.String requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_CertificateAuthorityPublicKeyIdentifier = null;
            if (cmdletContext.KeyCryptogram_CertificateAuthorityPublicKeyIdentifier != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_CertificateAuthorityPublicKeyIdentifier = cmdletContext.KeyCryptogram_CertificateAuthorityPublicKeyIdentifier;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_CertificateAuthorityPublicKeyIdentifier != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram.CertificateAuthorityPublicKeyIdentifier = requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_CertificateAuthorityPublicKeyIdentifier;
                requestKeyMaterial_keyMaterial_KeyCryptogramIsNull = false;
            }
            System.String requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_WrappingKeyCertificate = null;
            if (cmdletContext.KeyCryptogram_WrappingKeyCertificate != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_WrappingKeyCertificate = cmdletContext.KeyCryptogram_WrappingKeyCertificate;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_WrappingKeyCertificate != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram.WrappingKeyCertificate = requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_WrappingKeyCertificate;
                requestKeyMaterial_keyMaterial_KeyCryptogramIsNull = false;
            }
            Amazon.PaymentCryptography.WrappingKeySpec requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_WrappingSpec = null;
            if (cmdletContext.KeyCryptogram_WrappingSpec != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_WrappingSpec = cmdletContext.KeyCryptogram_WrappingSpec;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_WrappingSpec != null)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram.WrappingSpec = requestKeyMaterial_keyMaterial_KeyCryptogram_keyCryptogram_WrappingSpec;
                requestKeyMaterial_keyMaterial_KeyCryptogramIsNull = false;
            }
             // determine if requestKeyMaterial_keyMaterial_KeyCryptogram should be set to null
            if (requestKeyMaterial_keyMaterial_KeyCryptogramIsNull)
            {
                requestKeyMaterial_keyMaterial_KeyCryptogram = null;
            }
            if (requestKeyMaterial_keyMaterial_KeyCryptogram != null)
            {
                request.KeyMaterial.KeyCryptogram = requestKeyMaterial_keyMaterial_KeyCryptogram;
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
            public System.String ExportDukptInitialKey_KeySerialNumber { get; set; }
            public Amazon.PaymentCryptography.KeyCheckValueAlgorithm ExportAttributes_KeyCheckValueAlgorithm { get; set; }
            public System.String ExportKeyIdentifier { get; set; }
            public System.String KeyCryptogram_CertificateAuthorityPublicKeyIdentifier { get; set; }
            public System.String KeyCryptogram_WrappingKeyCertificate { get; set; }
            public Amazon.PaymentCryptography.WrappingKeySpec KeyCryptogram_WrappingSpec { get; set; }
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
