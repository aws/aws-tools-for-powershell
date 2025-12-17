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
using Amazon.PaymentCryptographyData;
using Amazon.PaymentCryptographyData.Model;

namespace Amazon.PowerShell.Cmdlets.PAYCD
{
    /// <summary>
    /// Translates an cryptographic key between different wrapping keys without importing
    /// the key into Amazon Web Services Payment Cryptography.
    /// 
    ///  
    /// <para>
    /// This operation can be used when key material is frequently rotated, such as during
    /// every card transaction, and there is a need to avoid importing short-lived keys into
    /// Amazon Web Services Payment Cryptography. It translates short-lived transaction keys
    /// such as <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/terminology.html#terms.pek">PEK</a>
    /// generated for each transaction and wrapped with an <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/terminology.html#terms.ecdh">ECDH</a>
    /// derived wrapping key to another <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/terminology.html#terms.kek">KEK</a>
    /// wrapping key. 
    /// </para><para>
    /// Before using this operation, you must first request the public key certificate of
    /// the ECC key pair generated within Amazon Web Services Payment Cryptography to establish
    /// an ECDH key agreement. In <c>TranslateKeyData</c>, the service uses its own ECC key
    /// pair, public certificate of receiving ECC key pair, and the key derivation parameters
    /// to generate a derived key. The service uses this derived key to unwrap the incoming
    /// transaction key received as a TR31WrappedKeyBlock and re-wrap using a user provided
    /// KEK to generate an outgoing Tr31WrappedKeyBlock.
    /// </para><para>
    /// For information about valid keys for this operation, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/keys-validattributes.html">Understanding
    /// key attributes</a> and <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/crypto-ops-validkeys-ops.html">Key
    /// types for specific data operations</a> in the <i>Amazon Web Services Payment Cryptography
    /// User Guide</i>. 
    /// </para><para><b>Cross-account use</b>: This operation can't be used across different Amazon Web
    /// Services accounts.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_CreateKey.html">CreateKey</a></para></li><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_GetPublicKeyCertificate.html">GetPublicCertificate</a></para></li><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_ImportKey.html">ImportKey</a></para></li></ul>
    /// </summary>
    [Cmdlet("Convert", "PAYCDKeyMaterial", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PaymentCryptographyData.Model.WrappedWorkingKey")]
    [AWSCmdlet("Calls the Payment Cryptography Data TranslateKeyMaterial API operation.", Operation = new[] {"TranslateKeyMaterial"}, SelectReturnType = typeof(Amazon.PaymentCryptographyData.Model.TranslateKeyMaterialResponse))]
    [AWSCmdletOutput("Amazon.PaymentCryptographyData.Model.WrappedWorkingKey or Amazon.PaymentCryptographyData.Model.TranslateKeyMaterialResponse",
        "This cmdlet returns an Amazon.PaymentCryptographyData.Model.WrappedWorkingKey object.",
        "The service call response (type Amazon.PaymentCryptographyData.Model.TranslateKeyMaterialResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ConvertPAYCDKeyMaterialCmdlet : AmazonPaymentCryptographyDataClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DiffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyArn</c> of the certificate that signed the client's <c>PublicKeyCertificate</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncomingKeyMaterial_DiffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier")]
        public System.String DiffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm
        /// <summary>
        /// <para>
        /// <para>The key algorithm of the derived ECDH key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncomingKeyMaterial_DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.SymmetricKeyAlgorithm")]
        public Amazon.PaymentCryptographyData.SymmetricKeyAlgorithm DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm { get; set; }
        #endregion
        
        #region Parameter KeyCheckValueAlgorithm
        /// <summary>
        /// <para>
        /// <para>The key check value (KCV) algorithm used for calculating the KCV of the derived key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.KeyCheckValueAlgorithm")]
        public Amazon.PaymentCryptographyData.KeyCheckValueAlgorithm KeyCheckValueAlgorithm { get; set; }
        #endregion
        
        #region Parameter DiffieHellmanTr31KeyBlock_KeyDerivationFunction
        /// <summary>
        /// <para>
        /// <para>The key derivation function to use for deriving a key using ECDH.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncomingKeyMaterial_DiffieHellmanTr31KeyBlock_KeyDerivationFunction")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.KeyDerivationFunction")]
        public Amazon.PaymentCryptographyData.KeyDerivationFunction DiffieHellmanTr31KeyBlock_KeyDerivationFunction { get; set; }
        #endregion
        
        #region Parameter DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm
        /// <summary>
        /// <para>
        /// <para>The hash type to use for deriving a key using ECDH.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncomingKeyMaterial_DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.KeyDerivationHashAlgorithm")]
        public Amazon.PaymentCryptographyData.KeyDerivationHashAlgorithm DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm { get; set; }
        #endregion
        
        #region Parameter DiffieHellmanTr31KeyBlock_PrivateKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyARN</c> of the asymmetric ECC key pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncomingKeyMaterial_DiffieHellmanTr31KeyBlock_PrivateKeyIdentifier")]
        public System.String DiffieHellmanTr31KeyBlock_PrivateKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter DiffieHellmanTr31KeyBlock_PublicKeyCertificate
        /// <summary>
        /// <para>
        /// <para>The client's public key certificate in PEM format (base64 encoded) to use for ECDH
        /// key derivation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncomingKeyMaterial_DiffieHellmanTr31KeyBlock_PublicKeyCertificate")]
        public System.String DiffieHellmanTr31KeyBlock_PublicKeyCertificate { get; set; }
        #endregion
        
        #region Parameter DerivationData_SharedInformation
        /// <summary>
        /// <para>
        /// <para>A string containing information that binds the ECDH derived key to the two parties
        /// involved or to the context of the key.</para><para>It may include details like identities of the two parties deriving the key, context
        /// of the operation, session IDs, and optionally a nonce. It must not contain zero bytes.
        /// It is not recommended to reuse shared information for multiple ECDH key derivations,
        /// as it could result in derived key material being the same across different derivations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncomingKeyMaterial_DiffieHellmanTr31KeyBlock_DerivationData_SharedInformation")]
        public System.String DerivationData_SharedInformation { get; set; }
        #endregion
        
        #region Parameter DiffieHellmanTr31KeyBlock_WrappedKeyBlock
        /// <summary>
        /// <para>
        /// <para>The WrappedKeyBlock containing the transaction key wrapped using an ECDH dervied key.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncomingKeyMaterial_DiffieHellmanTr31KeyBlock_WrappedKeyBlock")]
        public System.String DiffieHellmanTr31KeyBlock_WrappedKeyBlock { get; set; }
        #endregion
        
        #region Parameter Tr31KeyBlock_WrappingKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyARN</c> of the KEK used to wrap the transaction key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutgoingKeyMaterial_Tr31KeyBlock_WrappingKeyIdentifier")]
        public System.String Tr31KeyBlock_WrappingKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'WrappedKey'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PaymentCryptographyData.Model.TranslateKeyMaterialResponse).
        /// Specifying the name of a property of type Amazon.PaymentCryptographyData.Model.TranslateKeyMaterialResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "WrappedKey";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the KeyCheckValueAlgorithm parameter.
        /// The -PassThru parameter is deprecated, use -Select '^KeyCheckValueAlgorithm' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^KeyCheckValueAlgorithm' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KeyCheckValueAlgorithm), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Convert-PAYCDKeyMaterial (TranslateKeyMaterial)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PaymentCryptographyData.Model.TranslateKeyMaterialResponse, ConvertPAYCDKeyMaterialCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.KeyCheckValueAlgorithm;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DiffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier = this.DiffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier;
            context.DerivationData_SharedInformation = this.DerivationData_SharedInformation;
            context.DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm = this.DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm;
            context.DiffieHellmanTr31KeyBlock_KeyDerivationFunction = this.DiffieHellmanTr31KeyBlock_KeyDerivationFunction;
            context.DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm = this.DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm;
            context.DiffieHellmanTr31KeyBlock_PrivateKeyIdentifier = this.DiffieHellmanTr31KeyBlock_PrivateKeyIdentifier;
            context.DiffieHellmanTr31KeyBlock_PublicKeyCertificate = this.DiffieHellmanTr31KeyBlock_PublicKeyCertificate;
            context.DiffieHellmanTr31KeyBlock_WrappedKeyBlock = this.DiffieHellmanTr31KeyBlock_WrappedKeyBlock;
            context.KeyCheckValueAlgorithm = this.KeyCheckValueAlgorithm;
            context.Tr31KeyBlock_WrappingKeyIdentifier = this.Tr31KeyBlock_WrappingKeyIdentifier;
            
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
            var request = new Amazon.PaymentCryptographyData.Model.TranslateKeyMaterialRequest();
            
            
             // populate IncomingKeyMaterial
            var requestIncomingKeyMaterialIsNull = true;
            request.IncomingKeyMaterial = new Amazon.PaymentCryptographyData.Model.IncomingKeyMaterial();
            Amazon.PaymentCryptographyData.Model.IncomingDiffieHellmanTr31KeyBlock requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock = null;
            
             // populate DiffieHellmanTr31KeyBlock
            var requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlockIsNull = true;
            requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock = new Amazon.PaymentCryptographyData.Model.IncomingDiffieHellmanTr31KeyBlock();
            System.String requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier = null;
            if (cmdletContext.DiffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier != null)
            {
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier = cmdletContext.DiffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier;
            }
            if (requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier != null)
            {
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock.CertificateAuthorityPublicKeyIdentifier = requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier;
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlockIsNull = false;
            }
            Amazon.PaymentCryptographyData.SymmetricKeyAlgorithm requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_DeriveKeyAlgorithm = null;
            if (cmdletContext.DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm != null)
            {
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_DeriveKeyAlgorithm = cmdletContext.DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm;
            }
            if (requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_DeriveKeyAlgorithm != null)
            {
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock.DeriveKeyAlgorithm = requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_DeriveKeyAlgorithm;
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlockIsNull = false;
            }
            Amazon.PaymentCryptographyData.KeyDerivationFunction requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_KeyDerivationFunction = null;
            if (cmdletContext.DiffieHellmanTr31KeyBlock_KeyDerivationFunction != null)
            {
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_KeyDerivationFunction = cmdletContext.DiffieHellmanTr31KeyBlock_KeyDerivationFunction;
            }
            if (requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_KeyDerivationFunction != null)
            {
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock.KeyDerivationFunction = requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_KeyDerivationFunction;
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlockIsNull = false;
            }
            Amazon.PaymentCryptographyData.KeyDerivationHashAlgorithm requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm = null;
            if (cmdletContext.DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm != null)
            {
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm = cmdletContext.DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm;
            }
            if (requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm != null)
            {
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock.KeyDerivationHashAlgorithm = requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm;
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlockIsNull = false;
            }
            System.String requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_PrivateKeyIdentifier = null;
            if (cmdletContext.DiffieHellmanTr31KeyBlock_PrivateKeyIdentifier != null)
            {
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_PrivateKeyIdentifier = cmdletContext.DiffieHellmanTr31KeyBlock_PrivateKeyIdentifier;
            }
            if (requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_PrivateKeyIdentifier != null)
            {
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock.PrivateKeyIdentifier = requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_PrivateKeyIdentifier;
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlockIsNull = false;
            }
            System.String requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_PublicKeyCertificate = null;
            if (cmdletContext.DiffieHellmanTr31KeyBlock_PublicKeyCertificate != null)
            {
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_PublicKeyCertificate = cmdletContext.DiffieHellmanTr31KeyBlock_PublicKeyCertificate;
            }
            if (requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_PublicKeyCertificate != null)
            {
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock.PublicKeyCertificate = requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_PublicKeyCertificate;
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlockIsNull = false;
            }
            System.String requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_WrappedKeyBlock = null;
            if (cmdletContext.DiffieHellmanTr31KeyBlock_WrappedKeyBlock != null)
            {
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_WrappedKeyBlock = cmdletContext.DiffieHellmanTr31KeyBlock_WrappedKeyBlock;
            }
            if (requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_WrappedKeyBlock != null)
            {
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock.WrappedKeyBlock = requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_diffieHellmanTr31KeyBlock_WrappedKeyBlock;
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlockIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.DiffieHellmanDerivationData requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_DerivationData = null;
            
             // populate DerivationData
            var requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_DerivationDataIsNull = true;
            requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_DerivationData = new Amazon.PaymentCryptographyData.Model.DiffieHellmanDerivationData();
            System.String requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_DerivationData_derivationData_SharedInformation = null;
            if (cmdletContext.DerivationData_SharedInformation != null)
            {
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_DerivationData_derivationData_SharedInformation = cmdletContext.DerivationData_SharedInformation;
            }
            if (requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_DerivationData_derivationData_SharedInformation != null)
            {
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_DerivationData.SharedInformation = requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_DerivationData_derivationData_SharedInformation;
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_DerivationDataIsNull = false;
            }
             // determine if requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_DerivationData should be set to null
            if (requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_DerivationDataIsNull)
            {
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_DerivationData = null;
            }
            if (requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_DerivationData != null)
            {
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock.DerivationData = requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_incomingKeyMaterial_DiffieHellmanTr31KeyBlock_DerivationData;
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlockIsNull = false;
            }
             // determine if requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock should be set to null
            if (requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlockIsNull)
            {
                requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock = null;
            }
            if (requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock != null)
            {
                request.IncomingKeyMaterial.DiffieHellmanTr31KeyBlock = requestIncomingKeyMaterial_incomingKeyMaterial_DiffieHellmanTr31KeyBlock;
                requestIncomingKeyMaterialIsNull = false;
            }
             // determine if request.IncomingKeyMaterial should be set to null
            if (requestIncomingKeyMaterialIsNull)
            {
                request.IncomingKeyMaterial = null;
            }
            if (cmdletContext.KeyCheckValueAlgorithm != null)
            {
                request.KeyCheckValueAlgorithm = cmdletContext.KeyCheckValueAlgorithm;
            }
            
             // populate OutgoingKeyMaterial
            var requestOutgoingKeyMaterialIsNull = true;
            request.OutgoingKeyMaterial = new Amazon.PaymentCryptographyData.Model.OutgoingKeyMaterial();
            Amazon.PaymentCryptographyData.Model.OutgoingTr31KeyBlock requestOutgoingKeyMaterial_outgoingKeyMaterial_Tr31KeyBlock = null;
            
             // populate Tr31KeyBlock
            var requestOutgoingKeyMaterial_outgoingKeyMaterial_Tr31KeyBlockIsNull = true;
            requestOutgoingKeyMaterial_outgoingKeyMaterial_Tr31KeyBlock = new Amazon.PaymentCryptographyData.Model.OutgoingTr31KeyBlock();
            System.String requestOutgoingKeyMaterial_outgoingKeyMaterial_Tr31KeyBlock_tr31KeyBlock_WrappingKeyIdentifier = null;
            if (cmdletContext.Tr31KeyBlock_WrappingKeyIdentifier != null)
            {
                requestOutgoingKeyMaterial_outgoingKeyMaterial_Tr31KeyBlock_tr31KeyBlock_WrappingKeyIdentifier = cmdletContext.Tr31KeyBlock_WrappingKeyIdentifier;
            }
            if (requestOutgoingKeyMaterial_outgoingKeyMaterial_Tr31KeyBlock_tr31KeyBlock_WrappingKeyIdentifier != null)
            {
                requestOutgoingKeyMaterial_outgoingKeyMaterial_Tr31KeyBlock.WrappingKeyIdentifier = requestOutgoingKeyMaterial_outgoingKeyMaterial_Tr31KeyBlock_tr31KeyBlock_WrappingKeyIdentifier;
                requestOutgoingKeyMaterial_outgoingKeyMaterial_Tr31KeyBlockIsNull = false;
            }
             // determine if requestOutgoingKeyMaterial_outgoingKeyMaterial_Tr31KeyBlock should be set to null
            if (requestOutgoingKeyMaterial_outgoingKeyMaterial_Tr31KeyBlockIsNull)
            {
                requestOutgoingKeyMaterial_outgoingKeyMaterial_Tr31KeyBlock = null;
            }
            if (requestOutgoingKeyMaterial_outgoingKeyMaterial_Tr31KeyBlock != null)
            {
                request.OutgoingKeyMaterial.Tr31KeyBlock = requestOutgoingKeyMaterial_outgoingKeyMaterial_Tr31KeyBlock;
                requestOutgoingKeyMaterialIsNull = false;
            }
             // determine if request.OutgoingKeyMaterial should be set to null
            if (requestOutgoingKeyMaterialIsNull)
            {
                request.OutgoingKeyMaterial = null;
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
        
        private Amazon.PaymentCryptographyData.Model.TranslateKeyMaterialResponse CallAWSServiceOperation(IAmazonPaymentCryptographyData client, Amazon.PaymentCryptographyData.Model.TranslateKeyMaterialRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Payment Cryptography Data", "TranslateKeyMaterial");
            try
            {
                #if DESKTOP
                return client.TranslateKeyMaterial(request);
                #elif CORECLR
                return client.TranslateKeyMaterialAsync(request).GetAwaiter().GetResult();
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
            public System.String DiffieHellmanTr31KeyBlock_CertificateAuthorityPublicKeyIdentifier { get; set; }
            public System.String DerivationData_SharedInformation { get; set; }
            public Amazon.PaymentCryptographyData.SymmetricKeyAlgorithm DiffieHellmanTr31KeyBlock_DeriveKeyAlgorithm { get; set; }
            public Amazon.PaymentCryptographyData.KeyDerivationFunction DiffieHellmanTr31KeyBlock_KeyDerivationFunction { get; set; }
            public Amazon.PaymentCryptographyData.KeyDerivationHashAlgorithm DiffieHellmanTr31KeyBlock_KeyDerivationHashAlgorithm { get; set; }
            public System.String DiffieHellmanTr31KeyBlock_PrivateKeyIdentifier { get; set; }
            public System.String DiffieHellmanTr31KeyBlock_PublicKeyCertificate { get; set; }
            public System.String DiffieHellmanTr31KeyBlock_WrappedKeyBlock { get; set; }
            public Amazon.PaymentCryptographyData.KeyCheckValueAlgorithm KeyCheckValueAlgorithm { get; set; }
            public System.String Tr31KeyBlock_WrappingKeyIdentifier { get; set; }
            public System.Func<Amazon.PaymentCryptographyData.Model.TranslateKeyMaterialResponse, ConvertPAYCDKeyMaterialCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.WrappedKey;
        }
        
    }
}
