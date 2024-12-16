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
using Amazon.PaymentCryptographyData;
using Amazon.PaymentCryptographyData.Model;

namespace Amazon.PowerShell.Cmdlets.PAYCD
{
    /// <summary>
    /// Encrypts plaintext data to ciphertext using a symmetric (TDES, AES), asymmetric (RSA),
    /// or derived (DUKPT or EMV) encryption key scheme. For more information, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/encrypt-data.html">Encrypt
    /// data</a> in the <i>Amazon Web Services Payment Cryptography User Guide</i>.
    /// 
    ///  
    /// <para>
    /// You can generate an encryption key within Amazon Web Services Payment Cryptography
    /// by calling <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_CreateKey.html">CreateKey</a>.
    /// You can import your own encryption key by calling <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_ImportKey.html">ImportKey</a>.
    /// </para><para>
    /// For this operation, the key must have <c>KeyModesOfUse</c> set to <c>Encrypt</c>.
    /// In asymmetric encryption, plaintext is encrypted using public component. You can import
    /// the public component of an asymmetric key pair created outside Amazon Web Services
    /// Payment Cryptography by calling <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_ImportKey.html">ImportKey</a>.
    /// 
    /// </para><para>
    /// This operation also supports dynamic keys, allowing you to pass a dynamic encryption
    /// key as a TR-31 WrappedKeyBlock. This can be used when key material is frequently rotated,
    /// such as during every card transaction, and there is need to avoid importing short-lived
    /// keys into Amazon Web Services Payment Cryptography. To encrypt using dynamic keys,
    /// the <c>keyARN</c> is the Key Encryption Key (KEK) of the TR-31 wrapped encryption
    /// key material. The incoming wrapped key shall have a key purpose of D0 with a mode
    /// of use of B or D. For more information, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/use-cases-acquirers-dynamickeys.html">Using
    /// Dynamic Keys</a> in the <i>Amazon Web Services Payment Cryptography User Guide</i>.
    /// </para><para>
    /// For symmetric and DUKPT encryption, Amazon Web Services Payment Cryptography supports
    /// <c>TDES</c> and <c>AES</c> algorithms. For EMV encryption, Amazon Web Services Payment
    /// Cryptography supports <c>TDES</c> algorithms.For asymmetric encryption, Amazon Web
    /// Services Payment Cryptography supports <c>RSA</c>. 
    /// </para><para>
    /// When you use TDES or TDES DUKPT, the plaintext data length must be a multiple of 8
    /// bytes. For AES or AES DUKPT, the plaintext data length must be a multiple of 16 bytes.
    /// For RSA, it sould be equal to the key size unless padding is enabled.
    /// </para><para>
    /// To encrypt using DUKPT, you must already have a BDK (Base Derivation Key) key in your
    /// account with <c>KeyModesOfUse</c> set to <c>DeriveKey</c>, or you can generate a new
    /// DUKPT key by calling <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_CreateKey.html">CreateKey</a>.
    /// To encrypt using EMV, you must already have an IMK (Issuer Master Key) key in your
    /// account with <c>KeyModesOfUse</c> set to <c>DeriveKey</c>.
    /// </para><para>
    /// For information about valid keys for this operation, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/keys-validattributes.html">Understanding
    /// key attributes</a> and <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/crypto-ops-validkeys-ops.html">Key
    /// types for specific data operations</a> in the <i>Amazon Web Services Payment Cryptography
    /// User Guide</i>.
    /// </para><para><b>Cross-account use</b>: This operation can't be used across different Amazon Web
    /// Services accounts.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>DecryptData</a></para></li><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_GetPublicKeyCertificate.html">GetPublicCertificate</a></para></li><li><para><a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_ImportKey.html">ImportKey</a></para></li><li><para><a>ReEncryptData</a></para></li></ul>
    /// </summary>
    [Cmdlet("Protect", "PAYCDData", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PaymentCryptographyData.Model.EncryptDataResponse")]
    [AWSCmdlet("Calls the Payment Cryptography Data EncryptData API operation.", Operation = new[] {"EncryptData"}, SelectReturnType = typeof(Amazon.PaymentCryptographyData.Model.EncryptDataResponse))]
    [AWSCmdletOutput("Amazon.PaymentCryptographyData.Model.EncryptDataResponse",
        "This cmdlet returns an Amazon.PaymentCryptographyData.Model.EncryptDataResponse object containing multiple properties."
    )]
    public partial class ProtectPAYCDDataCmdlet : AmazonPaymentCryptographyDataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyArn</c> of the certificate that signed the client's <c>PublicKeyCertificate</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier")]
        public System.String DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter Dukpt_DukptKeyDerivationType
        /// <summary>
        /// <para>
        /// <para>The key type encrypted using DUKPT from a Base Derivation Key (BDK) and Key Serial
        /// Number (KSN). This must be less than or equal to the strength of the BDK. For example,
        /// you can't use <c>AES_128</c> as a derivation type for a BDK of <c>AES_128</c> or <c>TDES_2KEY</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionAttributes_Dukpt_DukptKeyDerivationType")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.DukptDerivationType")]
        public Amazon.PaymentCryptographyData.DukptDerivationType Dukpt_DukptKeyDerivationType { get; set; }
        #endregion
        
        #region Parameter Dukpt_DukptKeyVariant
        /// <summary>
        /// <para>
        /// <para>The type of use of DUKPT, which can be incoming data decryption, outgoing data encryption,
        /// or both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionAttributes_Dukpt_DukptKeyVariant")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.DukptKeyVariant")]
        public Amazon.PaymentCryptographyData.DukptKeyVariant Dukpt_DukptKeyVariant { get; set; }
        #endregion
        
        #region Parameter Dukpt_InitializationVector
        /// <summary>
        /// <para>
        /// <para>An input used to provide the intial state. If no value is provided, Amazon Web Services
        /// Payment Cryptography defaults it to zero.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionAttributes_Dukpt_InitializationVector")]
        public System.String Dukpt_InitializationVector { get; set; }
        #endregion
        
        #region Parameter Emv_InitializationVector
        /// <summary>
        /// <para>
        /// <para>An input used to provide the intial state. If no value is provided, Amazon Web Services
        /// Payment Cryptography defaults it to zero.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionAttributes_Emv_InitializationVector")]
        public System.String Emv_InitializationVector { get; set; }
        #endregion
        
        #region Parameter Symmetric_InitializationVector
        /// <summary>
        /// <para>
        /// <para>An input used to provide the intial state. If no value is provided, Amazon Web Services
        /// Payment Cryptography defaults it to zero.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionAttributes_Symmetric_InitializationVector")]
        public System.String Symmetric_InitializationVector { get; set; }
        #endregion
        
        #region Parameter DiffieHellmanSymmetricKey_KeyAlgorithm
        /// <summary>
        /// <para>
        /// <para>The key algorithm of the derived ECDH key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_KeyAlgorithm")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.SymmetricKeyAlgorithm")]
        public Amazon.PaymentCryptographyData.SymmetricKeyAlgorithm DiffieHellmanSymmetricKey_KeyAlgorithm { get; set; }
        #endregion
        
        #region Parameter WrappedKey_KeyCheckValueAlgorithm
        /// <summary>
        /// <para>
        /// <para>The algorithm that Amazon Web Services Payment Cryptography uses to calculate the
        /// key check value (KCV). It is used to validate the key integrity.</para><para>For TDES keys, the KCV is computed by encrypting 8 bytes, each with value of zero,
        /// with the key to be checked and retaining the 3 highest order bytes of the encrypted
        /// result. For AES keys, the KCV is computed using a CMAC algorithm where the input data
        /// is 16 bytes of zero and retaining the 3 highest order bytes of the encrypted result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.KeyCheckValueAlgorithm")]
        public Amazon.PaymentCryptographyData.KeyCheckValueAlgorithm WrappedKey_KeyCheckValueAlgorithm { get; set; }
        #endregion
        
        #region Parameter DiffieHellmanSymmetricKey_KeyDerivationFunction
        /// <summary>
        /// <para>
        /// <para>The key derivation function to use for deriving a key using ECDH.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_KeyDerivationFunction")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.KeyDerivationFunction")]
        public Amazon.PaymentCryptographyData.KeyDerivationFunction DiffieHellmanSymmetricKey_KeyDerivationFunction { get; set; }
        #endregion
        
        #region Parameter DiffieHellmanSymmetricKey_KeyDerivationHashAlgorithm
        /// <summary>
        /// <para>
        /// <para>The hash type to use for deriving a key using ECDH.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_KeyDerivationHashAlgorithm")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.KeyDerivationHashAlgorithm")]
        public Amazon.PaymentCryptographyData.KeyDerivationHashAlgorithm DiffieHellmanSymmetricKey_KeyDerivationHashAlgorithm { get; set; }
        #endregion
        
        #region Parameter KeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyARN</c> of the encryption key that Amazon Web Services Payment Cryptography
        /// uses for plaintext encryption.</para><para>When a WrappedKeyBlock is provided, this value will be the identifier to the key wrapping
        /// key. Otherwise, it is the key identifier used to perform the operation.</para>
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
        public System.String KeyIdentifier { get; set; }
        #endregion
        
        #region Parameter Dukpt_KeySerialNumber
        /// <summary>
        /// <para>
        /// <para>The unique identifier known as Key Serial Number (KSN) that comes from an encrypting
        /// device using DUKPT encryption method. The KSN is derived from the encrypting device
        /// unique identifier and an internal transaction counter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionAttributes_Dukpt_KeySerialNumber")]
        public System.String Dukpt_KeySerialNumber { get; set; }
        #endregion
        
        #region Parameter Emv_MajorKeyDerivationMode
        /// <summary>
        /// <para>
        /// <para>The EMV derivation mode to use for ICC master key derivation as per EMV version 4.3
        /// book 2.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionAttributes_Emv_MajorKeyDerivationMode")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.EmvMajorKeyDerivationMode")]
        public Amazon.PaymentCryptographyData.EmvMajorKeyDerivationMode Emv_MajorKeyDerivationMode { get; set; }
        #endregion
        
        #region Parameter Dukpt_Mode
        /// <summary>
        /// <para>
        /// <para>The block cipher method to use for encryption.</para><para>The default is CBC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionAttributes_Dukpt_Mode")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.DukptEncryptionMode")]
        public Amazon.PaymentCryptographyData.DukptEncryptionMode Dukpt_Mode { get; set; }
        #endregion
        
        #region Parameter Emv_Mode
        /// <summary>
        /// <para>
        /// <para>The block cipher method to use for encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionAttributes_Emv_Mode")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.EmvEncryptionMode")]
        public Amazon.PaymentCryptographyData.EmvEncryptionMode Emv_Mode { get; set; }
        #endregion
        
        #region Parameter Symmetric_Mode
        /// <summary>
        /// <para>
        /// <para>The block cipher method to use for encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionAttributes_Symmetric_Mode")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.EncryptionMode")]
        public Amazon.PaymentCryptographyData.EncryptionMode Symmetric_Mode { get; set; }
        #endregion
        
        #region Parameter Asymmetric_PaddingType
        /// <summary>
        /// <para>
        /// <para>The padding to be included with the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionAttributes_Asymmetric_PaddingType")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.PaddingType")]
        public Amazon.PaymentCryptographyData.PaddingType Asymmetric_PaddingType { get; set; }
        #endregion
        
        #region Parameter Symmetric_PaddingType
        /// <summary>
        /// <para>
        /// <para>The padding to be included with the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionAttributes_Symmetric_PaddingType")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.PaddingType")]
        public Amazon.PaymentCryptographyData.PaddingType Symmetric_PaddingType { get; set; }
        #endregion
        
        #region Parameter Emv_PanSequenceNumber
        /// <summary>
        /// <para>
        /// <para>A number that identifies and differentiates payment cards with the same Primary Account
        /// Number (PAN). Typically 00 is used, if no value is provided by the terminal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionAttributes_Emv_PanSequenceNumber")]
        public System.String Emv_PanSequenceNumber { get; set; }
        #endregion
        
        #region Parameter PlainText
        /// <summary>
        /// <para>
        /// <para>The plaintext to be encrypted.</para><note><para>For encryption using asymmetric keys, plaintext data length is constrained by encryption
        /// key strength that you define in <c>KeyAlgorithm</c> and padding type that you define
        /// in <c>AsymmetricEncryptionAttributes</c>. For more information, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/encrypt-data.html">Encrypt
        /// data</a> in the <i>Amazon Web Services Payment Cryptography User Guide</i>.</para></note>
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
        public System.String PlainText { get; set; }
        #endregion
        
        #region Parameter Emv_PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN), a unique identifier for a payment credit or debit
        /// card and associates the card to a specific account holder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionAttributes_Emv_PrimaryAccountNumber")]
        public System.String Emv_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter DiffieHellmanSymmetricKey_PublicKeyCertificate
        /// <summary>
        /// <para>
        /// <para>The client's public key certificate in PEM format (base64 encoded) to use for ECDH
        /// key derivation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_PublicKeyCertificate")]
        public System.String DiffieHellmanSymmetricKey_PublicKeyCertificate { get; set; }
        #endregion
        
        #region Parameter Emv_SessionDerivationData
        /// <summary>
        /// <para>
        /// <para>The derivation value used to derive the ICC session key. It is typically the application
        /// transaction counter value padded with zeros or previous ARQC value padded with zeros
        /// as per EMV version 4.3 book 2.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionAttributes_Emv_SessionDerivationData")]
        public System.String Emv_SessionDerivationData { get; set; }
        #endregion
        
        #region Parameter DiffieHellmanSymmetricKey_SharedInformation
        /// <summary>
        /// <para>
        /// <para>A byte string containing information that binds the ECDH derived key to the two parties
        /// involved or to the context of the key.</para><para>It may include details like identities of the two parties deriving the key, context
        /// of the operation, session IDs, and optionally a nonce. It must not contain zero bytes,
        /// and re-using shared information for multiple ECDH key derivations is not recommended.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_SharedInformation")]
        public System.String DiffieHellmanSymmetricKey_SharedInformation { get; set; }
        #endregion
        
        #region Parameter WrappedKeyMaterial_Tr31KeyBlock
        /// <summary>
        /// <para>
        /// <para>The TR-31 wrapped key block.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WrappedKey_WrappedKeyMaterial_Tr31KeyBlock")]
        public System.String WrappedKeyMaterial_Tr31KeyBlock { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PaymentCryptographyData.Model.EncryptDataResponse).
        /// Specifying the name of a property of type Amazon.PaymentCryptographyData.Model.EncryptDataResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KeyIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Protect-PAYCDData (EncryptData)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PaymentCryptographyData.Model.EncryptDataResponse, ProtectPAYCDDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Asymmetric_PaddingType = this.Asymmetric_PaddingType;
            context.Dukpt_DukptKeyDerivationType = this.Dukpt_DukptKeyDerivationType;
            context.Dukpt_DukptKeyVariant = this.Dukpt_DukptKeyVariant;
            context.Dukpt_InitializationVector = this.Dukpt_InitializationVector;
            context.Dukpt_KeySerialNumber = this.Dukpt_KeySerialNumber;
            context.Dukpt_Mode = this.Dukpt_Mode;
            context.Emv_InitializationVector = this.Emv_InitializationVector;
            context.Emv_MajorKeyDerivationMode = this.Emv_MajorKeyDerivationMode;
            context.Emv_Mode = this.Emv_Mode;
            context.Emv_PanSequenceNumber = this.Emv_PanSequenceNumber;
            context.Emv_PrimaryAccountNumber = this.Emv_PrimaryAccountNumber;
            context.Emv_SessionDerivationData = this.Emv_SessionDerivationData;
            context.Symmetric_InitializationVector = this.Symmetric_InitializationVector;
            context.Symmetric_Mode = this.Symmetric_Mode;
            context.Symmetric_PaddingType = this.Symmetric_PaddingType;
            context.KeyIdentifier = this.KeyIdentifier;
            #if MODULAR
            if (this.KeyIdentifier == null && ParameterWasBound(nameof(this.KeyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PlainText = this.PlainText;
            #if MODULAR
            if (this.PlainText == null && ParameterWasBound(nameof(this.PlainText)))
            {
                WriteWarning("You are passing $null as a value for parameter PlainText which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WrappedKey_KeyCheckValueAlgorithm = this.WrappedKey_KeyCheckValueAlgorithm;
            context.DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier = this.DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier;
            context.DiffieHellmanSymmetricKey_KeyAlgorithm = this.DiffieHellmanSymmetricKey_KeyAlgorithm;
            context.DiffieHellmanSymmetricKey_KeyDerivationFunction = this.DiffieHellmanSymmetricKey_KeyDerivationFunction;
            context.DiffieHellmanSymmetricKey_KeyDerivationHashAlgorithm = this.DiffieHellmanSymmetricKey_KeyDerivationHashAlgorithm;
            context.DiffieHellmanSymmetricKey_PublicKeyCertificate = this.DiffieHellmanSymmetricKey_PublicKeyCertificate;
            context.DiffieHellmanSymmetricKey_SharedInformation = this.DiffieHellmanSymmetricKey_SharedInformation;
            context.WrappedKeyMaterial_Tr31KeyBlock = this.WrappedKeyMaterial_Tr31KeyBlock;
            
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
            var request = new Amazon.PaymentCryptographyData.Model.EncryptDataRequest();
            
            
             // populate EncryptionAttributes
            var requestEncryptionAttributesIsNull = true;
            request.EncryptionAttributes = new Amazon.PaymentCryptographyData.Model.EncryptionDecryptionAttributes();
            Amazon.PaymentCryptographyData.Model.AsymmetricEncryptionAttributes requestEncryptionAttributes_encryptionAttributes_Asymmetric = null;
            
             // populate Asymmetric
            var requestEncryptionAttributes_encryptionAttributes_AsymmetricIsNull = true;
            requestEncryptionAttributes_encryptionAttributes_Asymmetric = new Amazon.PaymentCryptographyData.Model.AsymmetricEncryptionAttributes();
            Amazon.PaymentCryptographyData.PaddingType requestEncryptionAttributes_encryptionAttributes_Asymmetric_asymmetric_PaddingType = null;
            if (cmdletContext.Asymmetric_PaddingType != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Asymmetric_asymmetric_PaddingType = cmdletContext.Asymmetric_PaddingType;
            }
            if (requestEncryptionAttributes_encryptionAttributes_Asymmetric_asymmetric_PaddingType != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Asymmetric.PaddingType = requestEncryptionAttributes_encryptionAttributes_Asymmetric_asymmetric_PaddingType;
                requestEncryptionAttributes_encryptionAttributes_AsymmetricIsNull = false;
            }
             // determine if requestEncryptionAttributes_encryptionAttributes_Asymmetric should be set to null
            if (requestEncryptionAttributes_encryptionAttributes_AsymmetricIsNull)
            {
                requestEncryptionAttributes_encryptionAttributes_Asymmetric = null;
            }
            if (requestEncryptionAttributes_encryptionAttributes_Asymmetric != null)
            {
                request.EncryptionAttributes.Asymmetric = requestEncryptionAttributes_encryptionAttributes_Asymmetric;
                requestEncryptionAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.SymmetricEncryptionAttributes requestEncryptionAttributes_encryptionAttributes_Symmetric = null;
            
             // populate Symmetric
            var requestEncryptionAttributes_encryptionAttributes_SymmetricIsNull = true;
            requestEncryptionAttributes_encryptionAttributes_Symmetric = new Amazon.PaymentCryptographyData.Model.SymmetricEncryptionAttributes();
            System.String requestEncryptionAttributes_encryptionAttributes_Symmetric_symmetric_InitializationVector = null;
            if (cmdletContext.Symmetric_InitializationVector != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Symmetric_symmetric_InitializationVector = cmdletContext.Symmetric_InitializationVector;
            }
            if (requestEncryptionAttributes_encryptionAttributes_Symmetric_symmetric_InitializationVector != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Symmetric.InitializationVector = requestEncryptionAttributes_encryptionAttributes_Symmetric_symmetric_InitializationVector;
                requestEncryptionAttributes_encryptionAttributes_SymmetricIsNull = false;
            }
            Amazon.PaymentCryptographyData.EncryptionMode requestEncryptionAttributes_encryptionAttributes_Symmetric_symmetric_Mode = null;
            if (cmdletContext.Symmetric_Mode != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Symmetric_symmetric_Mode = cmdletContext.Symmetric_Mode;
            }
            if (requestEncryptionAttributes_encryptionAttributes_Symmetric_symmetric_Mode != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Symmetric.Mode = requestEncryptionAttributes_encryptionAttributes_Symmetric_symmetric_Mode;
                requestEncryptionAttributes_encryptionAttributes_SymmetricIsNull = false;
            }
            Amazon.PaymentCryptographyData.PaddingType requestEncryptionAttributes_encryptionAttributes_Symmetric_symmetric_PaddingType = null;
            if (cmdletContext.Symmetric_PaddingType != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Symmetric_symmetric_PaddingType = cmdletContext.Symmetric_PaddingType;
            }
            if (requestEncryptionAttributes_encryptionAttributes_Symmetric_symmetric_PaddingType != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Symmetric.PaddingType = requestEncryptionAttributes_encryptionAttributes_Symmetric_symmetric_PaddingType;
                requestEncryptionAttributes_encryptionAttributes_SymmetricIsNull = false;
            }
             // determine if requestEncryptionAttributes_encryptionAttributes_Symmetric should be set to null
            if (requestEncryptionAttributes_encryptionAttributes_SymmetricIsNull)
            {
                requestEncryptionAttributes_encryptionAttributes_Symmetric = null;
            }
            if (requestEncryptionAttributes_encryptionAttributes_Symmetric != null)
            {
                request.EncryptionAttributes.Symmetric = requestEncryptionAttributes_encryptionAttributes_Symmetric;
                requestEncryptionAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.DukptEncryptionAttributes requestEncryptionAttributes_encryptionAttributes_Dukpt = null;
            
             // populate Dukpt
            var requestEncryptionAttributes_encryptionAttributes_DukptIsNull = true;
            requestEncryptionAttributes_encryptionAttributes_Dukpt = new Amazon.PaymentCryptographyData.Model.DukptEncryptionAttributes();
            Amazon.PaymentCryptographyData.DukptDerivationType requestEncryptionAttributes_encryptionAttributes_Dukpt_dukpt_DukptKeyDerivationType = null;
            if (cmdletContext.Dukpt_DukptKeyDerivationType != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Dukpt_dukpt_DukptKeyDerivationType = cmdletContext.Dukpt_DukptKeyDerivationType;
            }
            if (requestEncryptionAttributes_encryptionAttributes_Dukpt_dukpt_DukptKeyDerivationType != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Dukpt.DukptKeyDerivationType = requestEncryptionAttributes_encryptionAttributes_Dukpt_dukpt_DukptKeyDerivationType;
                requestEncryptionAttributes_encryptionAttributes_DukptIsNull = false;
            }
            Amazon.PaymentCryptographyData.DukptKeyVariant requestEncryptionAttributes_encryptionAttributes_Dukpt_dukpt_DukptKeyVariant = null;
            if (cmdletContext.Dukpt_DukptKeyVariant != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Dukpt_dukpt_DukptKeyVariant = cmdletContext.Dukpt_DukptKeyVariant;
            }
            if (requestEncryptionAttributes_encryptionAttributes_Dukpt_dukpt_DukptKeyVariant != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Dukpt.DukptKeyVariant = requestEncryptionAttributes_encryptionAttributes_Dukpt_dukpt_DukptKeyVariant;
                requestEncryptionAttributes_encryptionAttributes_DukptIsNull = false;
            }
            System.String requestEncryptionAttributes_encryptionAttributes_Dukpt_dukpt_InitializationVector = null;
            if (cmdletContext.Dukpt_InitializationVector != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Dukpt_dukpt_InitializationVector = cmdletContext.Dukpt_InitializationVector;
            }
            if (requestEncryptionAttributes_encryptionAttributes_Dukpt_dukpt_InitializationVector != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Dukpt.InitializationVector = requestEncryptionAttributes_encryptionAttributes_Dukpt_dukpt_InitializationVector;
                requestEncryptionAttributes_encryptionAttributes_DukptIsNull = false;
            }
            System.String requestEncryptionAttributes_encryptionAttributes_Dukpt_dukpt_KeySerialNumber = null;
            if (cmdletContext.Dukpt_KeySerialNumber != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Dukpt_dukpt_KeySerialNumber = cmdletContext.Dukpt_KeySerialNumber;
            }
            if (requestEncryptionAttributes_encryptionAttributes_Dukpt_dukpt_KeySerialNumber != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Dukpt.KeySerialNumber = requestEncryptionAttributes_encryptionAttributes_Dukpt_dukpt_KeySerialNumber;
                requestEncryptionAttributes_encryptionAttributes_DukptIsNull = false;
            }
            Amazon.PaymentCryptographyData.DukptEncryptionMode requestEncryptionAttributes_encryptionAttributes_Dukpt_dukpt_Mode = null;
            if (cmdletContext.Dukpt_Mode != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Dukpt_dukpt_Mode = cmdletContext.Dukpt_Mode;
            }
            if (requestEncryptionAttributes_encryptionAttributes_Dukpt_dukpt_Mode != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Dukpt.Mode = requestEncryptionAttributes_encryptionAttributes_Dukpt_dukpt_Mode;
                requestEncryptionAttributes_encryptionAttributes_DukptIsNull = false;
            }
             // determine if requestEncryptionAttributes_encryptionAttributes_Dukpt should be set to null
            if (requestEncryptionAttributes_encryptionAttributes_DukptIsNull)
            {
                requestEncryptionAttributes_encryptionAttributes_Dukpt = null;
            }
            if (requestEncryptionAttributes_encryptionAttributes_Dukpt != null)
            {
                request.EncryptionAttributes.Dukpt = requestEncryptionAttributes_encryptionAttributes_Dukpt;
                requestEncryptionAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.EmvEncryptionAttributes requestEncryptionAttributes_encryptionAttributes_Emv = null;
            
             // populate Emv
            var requestEncryptionAttributes_encryptionAttributes_EmvIsNull = true;
            requestEncryptionAttributes_encryptionAttributes_Emv = new Amazon.PaymentCryptographyData.Model.EmvEncryptionAttributes();
            System.String requestEncryptionAttributes_encryptionAttributes_Emv_emv_InitializationVector = null;
            if (cmdletContext.Emv_InitializationVector != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Emv_emv_InitializationVector = cmdletContext.Emv_InitializationVector;
            }
            if (requestEncryptionAttributes_encryptionAttributes_Emv_emv_InitializationVector != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Emv.InitializationVector = requestEncryptionAttributes_encryptionAttributes_Emv_emv_InitializationVector;
                requestEncryptionAttributes_encryptionAttributes_EmvIsNull = false;
            }
            Amazon.PaymentCryptographyData.EmvMajorKeyDerivationMode requestEncryptionAttributes_encryptionAttributes_Emv_emv_MajorKeyDerivationMode = null;
            if (cmdletContext.Emv_MajorKeyDerivationMode != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Emv_emv_MajorKeyDerivationMode = cmdletContext.Emv_MajorKeyDerivationMode;
            }
            if (requestEncryptionAttributes_encryptionAttributes_Emv_emv_MajorKeyDerivationMode != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Emv.MajorKeyDerivationMode = requestEncryptionAttributes_encryptionAttributes_Emv_emv_MajorKeyDerivationMode;
                requestEncryptionAttributes_encryptionAttributes_EmvIsNull = false;
            }
            Amazon.PaymentCryptographyData.EmvEncryptionMode requestEncryptionAttributes_encryptionAttributes_Emv_emv_Mode = null;
            if (cmdletContext.Emv_Mode != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Emv_emv_Mode = cmdletContext.Emv_Mode;
            }
            if (requestEncryptionAttributes_encryptionAttributes_Emv_emv_Mode != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Emv.Mode = requestEncryptionAttributes_encryptionAttributes_Emv_emv_Mode;
                requestEncryptionAttributes_encryptionAttributes_EmvIsNull = false;
            }
            System.String requestEncryptionAttributes_encryptionAttributes_Emv_emv_PanSequenceNumber = null;
            if (cmdletContext.Emv_PanSequenceNumber != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Emv_emv_PanSequenceNumber = cmdletContext.Emv_PanSequenceNumber;
            }
            if (requestEncryptionAttributes_encryptionAttributes_Emv_emv_PanSequenceNumber != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Emv.PanSequenceNumber = requestEncryptionAttributes_encryptionAttributes_Emv_emv_PanSequenceNumber;
                requestEncryptionAttributes_encryptionAttributes_EmvIsNull = false;
            }
            System.String requestEncryptionAttributes_encryptionAttributes_Emv_emv_PrimaryAccountNumber = null;
            if (cmdletContext.Emv_PrimaryAccountNumber != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Emv_emv_PrimaryAccountNumber = cmdletContext.Emv_PrimaryAccountNumber;
            }
            if (requestEncryptionAttributes_encryptionAttributes_Emv_emv_PrimaryAccountNumber != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Emv.PrimaryAccountNumber = requestEncryptionAttributes_encryptionAttributes_Emv_emv_PrimaryAccountNumber;
                requestEncryptionAttributes_encryptionAttributes_EmvIsNull = false;
            }
            System.String requestEncryptionAttributes_encryptionAttributes_Emv_emv_SessionDerivationData = null;
            if (cmdletContext.Emv_SessionDerivationData != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Emv_emv_SessionDerivationData = cmdletContext.Emv_SessionDerivationData;
            }
            if (requestEncryptionAttributes_encryptionAttributes_Emv_emv_SessionDerivationData != null)
            {
                requestEncryptionAttributes_encryptionAttributes_Emv.SessionDerivationData = requestEncryptionAttributes_encryptionAttributes_Emv_emv_SessionDerivationData;
                requestEncryptionAttributes_encryptionAttributes_EmvIsNull = false;
            }
             // determine if requestEncryptionAttributes_encryptionAttributes_Emv should be set to null
            if (requestEncryptionAttributes_encryptionAttributes_EmvIsNull)
            {
                requestEncryptionAttributes_encryptionAttributes_Emv = null;
            }
            if (requestEncryptionAttributes_encryptionAttributes_Emv != null)
            {
                request.EncryptionAttributes.Emv = requestEncryptionAttributes_encryptionAttributes_Emv;
                requestEncryptionAttributesIsNull = false;
            }
             // determine if request.EncryptionAttributes should be set to null
            if (requestEncryptionAttributesIsNull)
            {
                request.EncryptionAttributes = null;
            }
            if (cmdletContext.KeyIdentifier != null)
            {
                request.KeyIdentifier = cmdletContext.KeyIdentifier;
            }
            if (cmdletContext.PlainText != null)
            {
                request.PlainText = cmdletContext.PlainText;
            }
            
             // populate WrappedKey
            var requestWrappedKeyIsNull = true;
            request.WrappedKey = new Amazon.PaymentCryptographyData.Model.WrappedKey();
            Amazon.PaymentCryptographyData.KeyCheckValueAlgorithm requestWrappedKey_wrappedKey_KeyCheckValueAlgorithm = null;
            if (cmdletContext.WrappedKey_KeyCheckValueAlgorithm != null)
            {
                requestWrappedKey_wrappedKey_KeyCheckValueAlgorithm = cmdletContext.WrappedKey_KeyCheckValueAlgorithm;
            }
            if (requestWrappedKey_wrappedKey_KeyCheckValueAlgorithm != null)
            {
                request.WrappedKey.KeyCheckValueAlgorithm = requestWrappedKey_wrappedKey_KeyCheckValueAlgorithm;
                requestWrappedKeyIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.WrappedKeyMaterial requestWrappedKey_wrappedKey_WrappedKeyMaterial = null;
            
             // populate WrappedKeyMaterial
            var requestWrappedKey_wrappedKey_WrappedKeyMaterialIsNull = true;
            requestWrappedKey_wrappedKey_WrappedKeyMaterial = new Amazon.PaymentCryptographyData.Model.WrappedKeyMaterial();
            System.String requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKeyMaterial_Tr31KeyBlock = null;
            if (cmdletContext.WrappedKeyMaterial_Tr31KeyBlock != null)
            {
                requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKeyMaterial_Tr31KeyBlock = cmdletContext.WrappedKeyMaterial_Tr31KeyBlock;
            }
            if (requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKeyMaterial_Tr31KeyBlock != null)
            {
                requestWrappedKey_wrappedKey_WrappedKeyMaterial.Tr31KeyBlock = requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKeyMaterial_Tr31KeyBlock;
                requestWrappedKey_wrappedKey_WrappedKeyMaterialIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.EcdhDerivationAttributes requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey = null;
            
             // populate DiffieHellmanSymmetricKey
            var requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKeyIsNull = true;
            requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey = new Amazon.PaymentCryptographyData.Model.EcdhDerivationAttributes();
            System.String requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier = null;
            if (cmdletContext.DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier != null)
            {
                requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier = cmdletContext.DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier;
            }
            if (requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier != null)
            {
                requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey.CertificateAuthorityPublicKeyIdentifier = requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier;
                requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKeyIsNull = false;
            }
            Amazon.PaymentCryptographyData.SymmetricKeyAlgorithm requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyAlgorithm = null;
            if (cmdletContext.DiffieHellmanSymmetricKey_KeyAlgorithm != null)
            {
                requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyAlgorithm = cmdletContext.DiffieHellmanSymmetricKey_KeyAlgorithm;
            }
            if (requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyAlgorithm != null)
            {
                requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey.KeyAlgorithm = requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyAlgorithm;
                requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKeyIsNull = false;
            }
            Amazon.PaymentCryptographyData.KeyDerivationFunction requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyDerivationFunction = null;
            if (cmdletContext.DiffieHellmanSymmetricKey_KeyDerivationFunction != null)
            {
                requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyDerivationFunction = cmdletContext.DiffieHellmanSymmetricKey_KeyDerivationFunction;
            }
            if (requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyDerivationFunction != null)
            {
                requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey.KeyDerivationFunction = requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyDerivationFunction;
                requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKeyIsNull = false;
            }
            Amazon.PaymentCryptographyData.KeyDerivationHashAlgorithm requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyDerivationHashAlgorithm = null;
            if (cmdletContext.DiffieHellmanSymmetricKey_KeyDerivationHashAlgorithm != null)
            {
                requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyDerivationHashAlgorithm = cmdletContext.DiffieHellmanSymmetricKey_KeyDerivationHashAlgorithm;
            }
            if (requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyDerivationHashAlgorithm != null)
            {
                requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey.KeyDerivationHashAlgorithm = requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyDerivationHashAlgorithm;
                requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKeyIsNull = false;
            }
            System.String requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_PublicKeyCertificate = null;
            if (cmdletContext.DiffieHellmanSymmetricKey_PublicKeyCertificate != null)
            {
                requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_PublicKeyCertificate = cmdletContext.DiffieHellmanSymmetricKey_PublicKeyCertificate;
            }
            if (requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_PublicKeyCertificate != null)
            {
                requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey.PublicKeyCertificate = requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_PublicKeyCertificate;
                requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKeyIsNull = false;
            }
            System.String requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_SharedInformation = null;
            if (cmdletContext.DiffieHellmanSymmetricKey_SharedInformation != null)
            {
                requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_SharedInformation = cmdletContext.DiffieHellmanSymmetricKey_SharedInformation;
            }
            if (requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_SharedInformation != null)
            {
                requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey.SharedInformation = requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_SharedInformation;
                requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKeyIsNull = false;
            }
             // determine if requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey should be set to null
            if (requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKeyIsNull)
            {
                requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey = null;
            }
            if (requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey != null)
            {
                requestWrappedKey_wrappedKey_WrappedKeyMaterial.DiffieHellmanSymmetricKey = requestWrappedKey_wrappedKey_WrappedKeyMaterial_wrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey;
                requestWrappedKey_wrappedKey_WrappedKeyMaterialIsNull = false;
            }
             // determine if requestWrappedKey_wrappedKey_WrappedKeyMaterial should be set to null
            if (requestWrappedKey_wrappedKey_WrappedKeyMaterialIsNull)
            {
                requestWrappedKey_wrappedKey_WrappedKeyMaterial = null;
            }
            if (requestWrappedKey_wrappedKey_WrappedKeyMaterial != null)
            {
                request.WrappedKey.WrappedKeyMaterial = requestWrappedKey_wrappedKey_WrappedKeyMaterial;
                requestWrappedKeyIsNull = false;
            }
             // determine if request.WrappedKey should be set to null
            if (requestWrappedKeyIsNull)
            {
                request.WrappedKey = null;
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
        
        private Amazon.PaymentCryptographyData.Model.EncryptDataResponse CallAWSServiceOperation(IAmazonPaymentCryptographyData client, Amazon.PaymentCryptographyData.Model.EncryptDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Payment Cryptography Data", "EncryptData");
            try
            {
                #if DESKTOP
                return client.EncryptData(request);
                #elif CORECLR
                return client.EncryptDataAsync(request).GetAwaiter().GetResult();
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
            public Amazon.PaymentCryptographyData.PaddingType Asymmetric_PaddingType { get; set; }
            public Amazon.PaymentCryptographyData.DukptDerivationType Dukpt_DukptKeyDerivationType { get; set; }
            public Amazon.PaymentCryptographyData.DukptKeyVariant Dukpt_DukptKeyVariant { get; set; }
            public System.String Dukpt_InitializationVector { get; set; }
            public System.String Dukpt_KeySerialNumber { get; set; }
            public Amazon.PaymentCryptographyData.DukptEncryptionMode Dukpt_Mode { get; set; }
            public System.String Emv_InitializationVector { get; set; }
            public Amazon.PaymentCryptographyData.EmvMajorKeyDerivationMode Emv_MajorKeyDerivationMode { get; set; }
            public Amazon.PaymentCryptographyData.EmvEncryptionMode Emv_Mode { get; set; }
            public System.String Emv_PanSequenceNumber { get; set; }
            public System.String Emv_PrimaryAccountNumber { get; set; }
            public System.String Emv_SessionDerivationData { get; set; }
            public System.String Symmetric_InitializationVector { get; set; }
            public Amazon.PaymentCryptographyData.EncryptionMode Symmetric_Mode { get; set; }
            public Amazon.PaymentCryptographyData.PaddingType Symmetric_PaddingType { get; set; }
            public System.String KeyIdentifier { get; set; }
            public System.String PlainText { get; set; }
            public Amazon.PaymentCryptographyData.KeyCheckValueAlgorithm WrappedKey_KeyCheckValueAlgorithm { get; set; }
            public System.String DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier { get; set; }
            public Amazon.PaymentCryptographyData.SymmetricKeyAlgorithm DiffieHellmanSymmetricKey_KeyAlgorithm { get; set; }
            public Amazon.PaymentCryptographyData.KeyDerivationFunction DiffieHellmanSymmetricKey_KeyDerivationFunction { get; set; }
            public Amazon.PaymentCryptographyData.KeyDerivationHashAlgorithm DiffieHellmanSymmetricKey_KeyDerivationHashAlgorithm { get; set; }
            public System.String DiffieHellmanSymmetricKey_PublicKeyCertificate { get; set; }
            public System.String DiffieHellmanSymmetricKey_SharedInformation { get; set; }
            public System.String WrappedKeyMaterial_Tr31KeyBlock { get; set; }
            public System.Func<Amazon.PaymentCryptographyData.Model.EncryptDataResponse, ProtectPAYCDDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
