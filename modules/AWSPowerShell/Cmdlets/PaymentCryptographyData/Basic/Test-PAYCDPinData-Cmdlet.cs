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
using Amazon.PaymentCryptographyData;
using Amazon.PaymentCryptographyData.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PAYCD
{
    /// <summary>
    /// Verifies pin-related data such as PIN and PIN Offset using algorithms including VISA
    /// PVV and IBM3624. For more information, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/verify-pin-data.html">Verify
    /// PIN data</a> in the <i>Amazon Web Services Payment Cryptography User Guide</i>.
    /// 
    ///  
    /// <para>
    /// This operation verifies PIN data for user payment card. A card holder PIN data is
    /// never transmitted in clear to or from Amazon Web Services Payment Cryptography. This
    /// operation uses PIN Verification Key (PVK) for PIN or PIN Offset generation and then
    /// encrypts it using PIN Encryption Key (PEK) to create an <c>EncryptedPinBlock</c> for
    /// transmission from Amazon Web Services Payment Cryptography. 
    /// </para><para>
    /// For information about valid keys for this operation, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/keys-validattributes.html">Understanding
    /// key attributes</a> and <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/crypto-ops-validkeys-ops.html">Key
    /// types for specific data operations</a> in the <i>Amazon Web Services Payment Cryptography
    /// User Guide</i>. 
    /// </para><para><b>Cross-account use</b>: This operation can't be used across different Amazon Web
    /// Services accounts.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>GeneratePinData</a></para></li><li><para><a>TranslatePinData</a></para></li></ul>
    /// </summary>
    [Cmdlet("Test", "PAYCDPinData")]
    [OutputType("Amazon.PaymentCryptographyData.Model.VerifyPinDataResponse")]
    [AWSCmdlet("Calls the Payment Cryptography Data VerifyPinData API operation.", Operation = new[] {"VerifyPinData"}, SelectReturnType = typeof(Amazon.PaymentCryptographyData.Model.VerifyPinDataResponse))]
    [AWSCmdletOutput("Amazon.PaymentCryptographyData.Model.VerifyPinDataResponse",
        "This cmdlet returns an Amazon.PaymentCryptographyData.Model.VerifyPinDataResponse object containing multiple properties."
    )]
    public partial class TestPAYCDPinDataCmdlet : AmazonPaymentCryptographyDataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyArn</c> of the certificate that signed the client's <c>PublicKeyCertificate</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier")]
        public System.String DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter Ibm3624Pin_DecimalizationTable
        /// <summary>
        /// <para>
        /// <para>The decimalization table to use for IBM 3624 PIN algorithm. The table is used to convert
        /// the algorithm intermediate result from hexadecimal characters to decimal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_Ibm3624Pin_DecimalizationTable")]
        public System.String Ibm3624Pin_DecimalizationTable { get; set; }
        #endregion
        
        #region Parameter DukptAttributes_DukptDerivationType
        /// <summary>
        /// <para>
        /// <para>The key type derived using DUKPT from a Base Derivation Key (BDK) and Key Serial Number
        /// (KSN). This must be less than or equal to the strength of the BDK. For example, you
        /// can't use <c>AES_128</c> as a derivation type for a BDK of <c>AES_128</c> or <c>TDES_2KEY</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.DukptDerivationType")]
        public Amazon.PaymentCryptographyData.DukptDerivationType DukptAttributes_DukptDerivationType { get; set; }
        #endregion
        
        #region Parameter EncryptedPinBlock
        /// <summary>
        /// <para>
        /// <para>The encrypted PIN block data that Amazon Web Services Payment Cryptography verifies.</para>
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
        public System.String EncryptedPinBlock { get; set; }
        #endregion
        
        #region Parameter EncryptionKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyARN</c> of the encryption key under which the PIN block data is encrypted.
        /// This key type can be PEK or BDK.</para>
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
        public System.String EncryptionKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter DiffieHellmanSymmetricKey_KeyAlgorithm
        /// <summary>
        /// <para>
        /// <para>The key algorithm of the derived ECDH key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_KeyAlgorithm")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.SymmetricKeyAlgorithm")]
        public Amazon.PaymentCryptographyData.SymmetricKeyAlgorithm DiffieHellmanSymmetricKey_KeyAlgorithm { get; set; }
        #endregion
        
        #region Parameter EncryptionWrappedKey_KeyCheckValueAlgorithm
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
        public Amazon.PaymentCryptographyData.KeyCheckValueAlgorithm EncryptionWrappedKey_KeyCheckValueAlgorithm { get; set; }
        #endregion
        
        #region Parameter DiffieHellmanSymmetricKey_KeyDerivationFunction
        /// <summary>
        /// <para>
        /// <para>The key derivation function to use for deriving a key using ECDH.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_KeyDerivationFunction")]
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
        [Alias("EncryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_KeyDerivationHashAlgorithm")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.KeyDerivationHashAlgorithm")]
        public Amazon.PaymentCryptographyData.KeyDerivationHashAlgorithm DiffieHellmanSymmetricKey_KeyDerivationHashAlgorithm { get; set; }
        #endregion
        
        #region Parameter DukptAttributes_KeySerialNumber
        /// <summary>
        /// <para>
        /// <para>The unique identifier known as Key Serial Number (KSN) that comes from an encrypting
        /// device using DUKPT encryption method. The KSN is derived from the encrypting device
        /// unique identifier and an internal transaction counter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DukptAttributes_KeySerialNumber { get; set; }
        #endregion
        
        #region Parameter PinBlockFormat
        /// <summary>
        /// <para>
        /// <para>The PIN encoding format for pin data generation as specified in ISO 9564. Amazon Web
        /// Services Payment Cryptography supports <c>ISO_Format_0</c> and <c>ISO_Format_3</c>.</para><para>The <c>ISO_Format_0</c> PIN block format is equivalent to the ANSI X9.8, VISA-1, and
        /// ECI-1 PIN block formats. It is similar to a VISA-4 PIN block format. It supports a
        /// PIN from 4 to 12 digits in length.</para><para>The <c>ISO_Format_3</c> PIN block format is the same as <c>ISO_Format_0</c> except
        /// that the fill digits are random values from 10 to 15.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.PinBlockFormatForPinData")]
        public Amazon.PaymentCryptographyData.PinBlockFormatForPinData PinBlockFormat { get; set; }
        #endregion
        
        #region Parameter PinDataLength
        /// <summary>
        /// <para>
        /// <para>The length of PIN being verified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PinDataLength { get; set; }
        #endregion
        
        #region Parameter Ibm3624Pin_PinOffset
        /// <summary>
        /// <para>
        /// <para>The PIN offset value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_Ibm3624Pin_PinOffset")]
        public System.String Ibm3624Pin_PinOffset { get; set; }
        #endregion
        
        #region Parameter Ibm3624Pin_PinValidationData
        /// <summary>
        /// <para>
        /// <para>The unique data for cardholder identification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_Ibm3624Pin_PinValidationData")]
        public System.String Ibm3624Pin_PinValidationData { get; set; }
        #endregion
        
        #region Parameter Ibm3624Pin_PinValidationDataPadCharacter
        /// <summary>
        /// <para>
        /// <para>The padding character for validation data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_Ibm3624Pin_PinValidationDataPadCharacter")]
        public System.String Ibm3624Pin_PinValidationDataPadCharacter { get; set; }
        #endregion
        
        #region Parameter VisaPin_PinVerificationKeyIndex
        /// <summary>
        /// <para>
        /// <para>The value for PIN verification index. It is used in the Visa PIN algorithm to calculate
        /// the PVV (PIN Verification Value).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_VisaPin_PinVerificationKeyIndex")]
        public System.Int32? VisaPin_PinVerificationKeyIndex { get; set; }
        #endregion
        
        #region Parameter PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN), a unique identifier for a payment credit or debit
        /// card that associates the card with a specific account holder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter DiffieHellmanSymmetricKey_PublicKeyCertificate
        /// <summary>
        /// <para>
        /// <para>The client's public key certificate in PEM format (base64 encoded) to use for ECDH
        /// key derivation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_PublicKeyCertificate")]
        public System.String DiffieHellmanSymmetricKey_PublicKeyCertificate { get; set; }
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
        [Alias("EncryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_SharedInformation")]
        public System.String DiffieHellmanSymmetricKey_SharedInformation { get; set; }
        #endregion
        
        #region Parameter WrappedKeyMaterial_Tr31KeyBlock
        /// <summary>
        /// <para>
        /// <para>The TR-31 wrapped key block.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionWrappedKey_WrappedKeyMaterial_Tr31KeyBlock")]
        public System.String WrappedKeyMaterial_Tr31KeyBlock { get; set; }
        #endregion
        
        #region Parameter VerificationKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyARN</c> of the PIN verification key.</para>
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
        public System.String VerificationKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter VisaPin_VerificationValue
        /// <summary>
        /// <para>
        /// <para>Parameters that are required to generate or verify Visa PVV (PIN Verification Value).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_VisaPin_VerificationValue")]
        public System.String VisaPin_VerificationValue { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PaymentCryptographyData.Model.VerifyPinDataResponse).
        /// Specifying the name of a property of type Amazon.PaymentCryptographyData.Model.VerifyPinDataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PaymentCryptographyData.Model.VerifyPinDataResponse, TestPAYCDPinDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DukptAttributes_DukptDerivationType = this.DukptAttributes_DukptDerivationType;
            context.DukptAttributes_KeySerialNumber = this.DukptAttributes_KeySerialNumber;
            context.EncryptedPinBlock = this.EncryptedPinBlock;
            #if MODULAR
            if (this.EncryptedPinBlock == null && ParameterWasBound(nameof(this.EncryptedPinBlock)))
            {
                WriteWarning("You are passing $null as a value for parameter EncryptedPinBlock which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EncryptionKeyIdentifier = this.EncryptionKeyIdentifier;
            #if MODULAR
            if (this.EncryptionKeyIdentifier == null && ParameterWasBound(nameof(this.EncryptionKeyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter EncryptionKeyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EncryptionWrappedKey_KeyCheckValueAlgorithm = this.EncryptionWrappedKey_KeyCheckValueAlgorithm;
            context.DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier = this.DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier;
            context.DiffieHellmanSymmetricKey_KeyAlgorithm = this.DiffieHellmanSymmetricKey_KeyAlgorithm;
            context.DiffieHellmanSymmetricKey_KeyDerivationFunction = this.DiffieHellmanSymmetricKey_KeyDerivationFunction;
            context.DiffieHellmanSymmetricKey_KeyDerivationHashAlgorithm = this.DiffieHellmanSymmetricKey_KeyDerivationHashAlgorithm;
            context.DiffieHellmanSymmetricKey_PublicKeyCertificate = this.DiffieHellmanSymmetricKey_PublicKeyCertificate;
            context.DiffieHellmanSymmetricKey_SharedInformation = this.DiffieHellmanSymmetricKey_SharedInformation;
            context.WrappedKeyMaterial_Tr31KeyBlock = this.WrappedKeyMaterial_Tr31KeyBlock;
            context.PinBlockFormat = this.PinBlockFormat;
            #if MODULAR
            if (this.PinBlockFormat == null && ParameterWasBound(nameof(this.PinBlockFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter PinBlockFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PinDataLength = this.PinDataLength;
            context.PrimaryAccountNumber = this.PrimaryAccountNumber;
            context.Ibm3624Pin_DecimalizationTable = this.Ibm3624Pin_DecimalizationTable;
            context.Ibm3624Pin_PinOffset = this.Ibm3624Pin_PinOffset;
            context.Ibm3624Pin_PinValidationData = this.Ibm3624Pin_PinValidationData;
            context.Ibm3624Pin_PinValidationDataPadCharacter = this.Ibm3624Pin_PinValidationDataPadCharacter;
            context.VisaPin_PinVerificationKeyIndex = this.VisaPin_PinVerificationKeyIndex;
            context.VisaPin_VerificationValue = this.VisaPin_VerificationValue;
            context.VerificationKeyIdentifier = this.VerificationKeyIdentifier;
            #if MODULAR
            if (this.VerificationKeyIdentifier == null && ParameterWasBound(nameof(this.VerificationKeyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter VerificationKeyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PaymentCryptographyData.Model.VerifyPinDataRequest();
            
            
             // populate DukptAttributes
            var requestDukptAttributesIsNull = true;
            request.DukptAttributes = new Amazon.PaymentCryptographyData.Model.DukptAttributes();
            Amazon.PaymentCryptographyData.DukptDerivationType requestDukptAttributes_dukptAttributes_DukptDerivationType = null;
            if (cmdletContext.DukptAttributes_DukptDerivationType != null)
            {
                requestDukptAttributes_dukptAttributes_DukptDerivationType = cmdletContext.DukptAttributes_DukptDerivationType;
            }
            if (requestDukptAttributes_dukptAttributes_DukptDerivationType != null)
            {
                request.DukptAttributes.DukptDerivationType = requestDukptAttributes_dukptAttributes_DukptDerivationType;
                requestDukptAttributesIsNull = false;
            }
            System.String requestDukptAttributes_dukptAttributes_KeySerialNumber = null;
            if (cmdletContext.DukptAttributes_KeySerialNumber != null)
            {
                requestDukptAttributes_dukptAttributes_KeySerialNumber = cmdletContext.DukptAttributes_KeySerialNumber;
            }
            if (requestDukptAttributes_dukptAttributes_KeySerialNumber != null)
            {
                request.DukptAttributes.KeySerialNumber = requestDukptAttributes_dukptAttributes_KeySerialNumber;
                requestDukptAttributesIsNull = false;
            }
             // determine if request.DukptAttributes should be set to null
            if (requestDukptAttributesIsNull)
            {
                request.DukptAttributes = null;
            }
            if (cmdletContext.EncryptedPinBlock != null)
            {
                request.EncryptedPinBlock = cmdletContext.EncryptedPinBlock;
            }
            if (cmdletContext.EncryptionKeyIdentifier != null)
            {
                request.EncryptionKeyIdentifier = cmdletContext.EncryptionKeyIdentifier;
            }
            
             // populate EncryptionWrappedKey
            var requestEncryptionWrappedKeyIsNull = true;
            request.EncryptionWrappedKey = new Amazon.PaymentCryptographyData.Model.WrappedKey();
            Amazon.PaymentCryptographyData.KeyCheckValueAlgorithm requestEncryptionWrappedKey_encryptionWrappedKey_KeyCheckValueAlgorithm = null;
            if (cmdletContext.EncryptionWrappedKey_KeyCheckValueAlgorithm != null)
            {
                requestEncryptionWrappedKey_encryptionWrappedKey_KeyCheckValueAlgorithm = cmdletContext.EncryptionWrappedKey_KeyCheckValueAlgorithm;
            }
            if (requestEncryptionWrappedKey_encryptionWrappedKey_KeyCheckValueAlgorithm != null)
            {
                request.EncryptionWrappedKey.KeyCheckValueAlgorithm = requestEncryptionWrappedKey_encryptionWrappedKey_KeyCheckValueAlgorithm;
                requestEncryptionWrappedKeyIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.WrappedKeyMaterial requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial = null;
            
             // populate WrappedKeyMaterial
            var requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterialIsNull = true;
            requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial = new Amazon.PaymentCryptographyData.Model.WrappedKeyMaterial();
            System.String requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_wrappedKeyMaterial_Tr31KeyBlock = null;
            if (cmdletContext.WrappedKeyMaterial_Tr31KeyBlock != null)
            {
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_wrappedKeyMaterial_Tr31KeyBlock = cmdletContext.WrappedKeyMaterial_Tr31KeyBlock;
            }
            if (requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_wrappedKeyMaterial_Tr31KeyBlock != null)
            {
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial.Tr31KeyBlock = requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_wrappedKeyMaterial_Tr31KeyBlock;
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterialIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.EcdhDerivationAttributes requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey = null;
            
             // populate DiffieHellmanSymmetricKey
            var requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKeyIsNull = true;
            requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey = new Amazon.PaymentCryptographyData.Model.EcdhDerivationAttributes();
            System.String requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier = null;
            if (cmdletContext.DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier != null)
            {
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier = cmdletContext.DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier;
            }
            if (requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier != null)
            {
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey.CertificateAuthorityPublicKeyIdentifier = requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier;
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKeyIsNull = false;
            }
            Amazon.PaymentCryptographyData.SymmetricKeyAlgorithm requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyAlgorithm = null;
            if (cmdletContext.DiffieHellmanSymmetricKey_KeyAlgorithm != null)
            {
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyAlgorithm = cmdletContext.DiffieHellmanSymmetricKey_KeyAlgorithm;
            }
            if (requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyAlgorithm != null)
            {
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey.KeyAlgorithm = requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyAlgorithm;
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKeyIsNull = false;
            }
            Amazon.PaymentCryptographyData.KeyDerivationFunction requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyDerivationFunction = null;
            if (cmdletContext.DiffieHellmanSymmetricKey_KeyDerivationFunction != null)
            {
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyDerivationFunction = cmdletContext.DiffieHellmanSymmetricKey_KeyDerivationFunction;
            }
            if (requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyDerivationFunction != null)
            {
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey.KeyDerivationFunction = requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyDerivationFunction;
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKeyIsNull = false;
            }
            Amazon.PaymentCryptographyData.KeyDerivationHashAlgorithm requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyDerivationHashAlgorithm = null;
            if (cmdletContext.DiffieHellmanSymmetricKey_KeyDerivationHashAlgorithm != null)
            {
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyDerivationHashAlgorithm = cmdletContext.DiffieHellmanSymmetricKey_KeyDerivationHashAlgorithm;
            }
            if (requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyDerivationHashAlgorithm != null)
            {
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey.KeyDerivationHashAlgorithm = requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_KeyDerivationHashAlgorithm;
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKeyIsNull = false;
            }
            System.String requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_PublicKeyCertificate = null;
            if (cmdletContext.DiffieHellmanSymmetricKey_PublicKeyCertificate != null)
            {
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_PublicKeyCertificate = cmdletContext.DiffieHellmanSymmetricKey_PublicKeyCertificate;
            }
            if (requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_PublicKeyCertificate != null)
            {
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey.PublicKeyCertificate = requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_PublicKeyCertificate;
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKeyIsNull = false;
            }
            System.String requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_SharedInformation = null;
            if (cmdletContext.DiffieHellmanSymmetricKey_SharedInformation != null)
            {
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_SharedInformation = cmdletContext.DiffieHellmanSymmetricKey_SharedInformation;
            }
            if (requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_SharedInformation != null)
            {
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey.SharedInformation = requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey_diffieHellmanSymmetricKey_SharedInformation;
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKeyIsNull = false;
            }
             // determine if requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey should be set to null
            if (requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKeyIsNull)
            {
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey = null;
            }
            if (requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey != null)
            {
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial.DiffieHellmanSymmetricKey = requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial_encryptionWrappedKey_WrappedKeyMaterial_DiffieHellmanSymmetricKey;
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterialIsNull = false;
            }
             // determine if requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial should be set to null
            if (requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterialIsNull)
            {
                requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial = null;
            }
            if (requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial != null)
            {
                request.EncryptionWrappedKey.WrappedKeyMaterial = requestEncryptionWrappedKey_encryptionWrappedKey_WrappedKeyMaterial;
                requestEncryptionWrappedKeyIsNull = false;
            }
             // determine if request.EncryptionWrappedKey should be set to null
            if (requestEncryptionWrappedKeyIsNull)
            {
                request.EncryptionWrappedKey = null;
            }
            if (cmdletContext.PinBlockFormat != null)
            {
                request.PinBlockFormat = cmdletContext.PinBlockFormat;
            }
            if (cmdletContext.PinDataLength != null)
            {
                request.PinDataLength = cmdletContext.PinDataLength.Value;
            }
            if (cmdletContext.PrimaryAccountNumber != null)
            {
                request.PrimaryAccountNumber = cmdletContext.PrimaryAccountNumber;
            }
            
             // populate VerificationAttributes
            var requestVerificationAttributesIsNull = true;
            request.VerificationAttributes = new Amazon.PaymentCryptographyData.Model.PinVerificationAttributes();
            Amazon.PaymentCryptographyData.Model.VisaPinVerification requestVerificationAttributes_verificationAttributes_VisaPin = null;
            
             // populate VisaPin
            var requestVerificationAttributes_verificationAttributes_VisaPinIsNull = true;
            requestVerificationAttributes_verificationAttributes_VisaPin = new Amazon.PaymentCryptographyData.Model.VisaPinVerification();
            System.Int32? requestVerificationAttributes_verificationAttributes_VisaPin_visaPin_PinVerificationKeyIndex = null;
            if (cmdletContext.VisaPin_PinVerificationKeyIndex != null)
            {
                requestVerificationAttributes_verificationAttributes_VisaPin_visaPin_PinVerificationKeyIndex = cmdletContext.VisaPin_PinVerificationKeyIndex.Value;
            }
            if (requestVerificationAttributes_verificationAttributes_VisaPin_visaPin_PinVerificationKeyIndex != null)
            {
                requestVerificationAttributes_verificationAttributes_VisaPin.PinVerificationKeyIndex = requestVerificationAttributes_verificationAttributes_VisaPin_visaPin_PinVerificationKeyIndex.Value;
                requestVerificationAttributes_verificationAttributes_VisaPinIsNull = false;
            }
            System.String requestVerificationAttributes_verificationAttributes_VisaPin_visaPin_VerificationValue = null;
            if (cmdletContext.VisaPin_VerificationValue != null)
            {
                requestVerificationAttributes_verificationAttributes_VisaPin_visaPin_VerificationValue = cmdletContext.VisaPin_VerificationValue;
            }
            if (requestVerificationAttributes_verificationAttributes_VisaPin_visaPin_VerificationValue != null)
            {
                requestVerificationAttributes_verificationAttributes_VisaPin.VerificationValue = requestVerificationAttributes_verificationAttributes_VisaPin_visaPin_VerificationValue;
                requestVerificationAttributes_verificationAttributes_VisaPinIsNull = false;
            }
             // determine if requestVerificationAttributes_verificationAttributes_VisaPin should be set to null
            if (requestVerificationAttributes_verificationAttributes_VisaPinIsNull)
            {
                requestVerificationAttributes_verificationAttributes_VisaPin = null;
            }
            if (requestVerificationAttributes_verificationAttributes_VisaPin != null)
            {
                request.VerificationAttributes.VisaPin = requestVerificationAttributes_verificationAttributes_VisaPin;
                requestVerificationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.Ibm3624PinVerification requestVerificationAttributes_verificationAttributes_Ibm3624Pin = null;
            
             // populate Ibm3624Pin
            var requestVerificationAttributes_verificationAttributes_Ibm3624PinIsNull = true;
            requestVerificationAttributes_verificationAttributes_Ibm3624Pin = new Amazon.PaymentCryptographyData.Model.Ibm3624PinVerification();
            System.String requestVerificationAttributes_verificationAttributes_Ibm3624Pin_ibm3624Pin_DecimalizationTable = null;
            if (cmdletContext.Ibm3624Pin_DecimalizationTable != null)
            {
                requestVerificationAttributes_verificationAttributes_Ibm3624Pin_ibm3624Pin_DecimalizationTable = cmdletContext.Ibm3624Pin_DecimalizationTable;
            }
            if (requestVerificationAttributes_verificationAttributes_Ibm3624Pin_ibm3624Pin_DecimalizationTable != null)
            {
                requestVerificationAttributes_verificationAttributes_Ibm3624Pin.DecimalizationTable = requestVerificationAttributes_verificationAttributes_Ibm3624Pin_ibm3624Pin_DecimalizationTable;
                requestVerificationAttributes_verificationAttributes_Ibm3624PinIsNull = false;
            }
            System.String requestVerificationAttributes_verificationAttributes_Ibm3624Pin_ibm3624Pin_PinOffset = null;
            if (cmdletContext.Ibm3624Pin_PinOffset != null)
            {
                requestVerificationAttributes_verificationAttributes_Ibm3624Pin_ibm3624Pin_PinOffset = cmdletContext.Ibm3624Pin_PinOffset;
            }
            if (requestVerificationAttributes_verificationAttributes_Ibm3624Pin_ibm3624Pin_PinOffset != null)
            {
                requestVerificationAttributes_verificationAttributes_Ibm3624Pin.PinOffset = requestVerificationAttributes_verificationAttributes_Ibm3624Pin_ibm3624Pin_PinOffset;
                requestVerificationAttributes_verificationAttributes_Ibm3624PinIsNull = false;
            }
            System.String requestVerificationAttributes_verificationAttributes_Ibm3624Pin_ibm3624Pin_PinValidationData = null;
            if (cmdletContext.Ibm3624Pin_PinValidationData != null)
            {
                requestVerificationAttributes_verificationAttributes_Ibm3624Pin_ibm3624Pin_PinValidationData = cmdletContext.Ibm3624Pin_PinValidationData;
            }
            if (requestVerificationAttributes_verificationAttributes_Ibm3624Pin_ibm3624Pin_PinValidationData != null)
            {
                requestVerificationAttributes_verificationAttributes_Ibm3624Pin.PinValidationData = requestVerificationAttributes_verificationAttributes_Ibm3624Pin_ibm3624Pin_PinValidationData;
                requestVerificationAttributes_verificationAttributes_Ibm3624PinIsNull = false;
            }
            System.String requestVerificationAttributes_verificationAttributes_Ibm3624Pin_ibm3624Pin_PinValidationDataPadCharacter = null;
            if (cmdletContext.Ibm3624Pin_PinValidationDataPadCharacter != null)
            {
                requestVerificationAttributes_verificationAttributes_Ibm3624Pin_ibm3624Pin_PinValidationDataPadCharacter = cmdletContext.Ibm3624Pin_PinValidationDataPadCharacter;
            }
            if (requestVerificationAttributes_verificationAttributes_Ibm3624Pin_ibm3624Pin_PinValidationDataPadCharacter != null)
            {
                requestVerificationAttributes_verificationAttributes_Ibm3624Pin.PinValidationDataPadCharacter = requestVerificationAttributes_verificationAttributes_Ibm3624Pin_ibm3624Pin_PinValidationDataPadCharacter;
                requestVerificationAttributes_verificationAttributes_Ibm3624PinIsNull = false;
            }
             // determine if requestVerificationAttributes_verificationAttributes_Ibm3624Pin should be set to null
            if (requestVerificationAttributes_verificationAttributes_Ibm3624PinIsNull)
            {
                requestVerificationAttributes_verificationAttributes_Ibm3624Pin = null;
            }
            if (requestVerificationAttributes_verificationAttributes_Ibm3624Pin != null)
            {
                request.VerificationAttributes.Ibm3624Pin = requestVerificationAttributes_verificationAttributes_Ibm3624Pin;
                requestVerificationAttributesIsNull = false;
            }
             // determine if request.VerificationAttributes should be set to null
            if (requestVerificationAttributesIsNull)
            {
                request.VerificationAttributes = null;
            }
            if (cmdletContext.VerificationKeyIdentifier != null)
            {
                request.VerificationKeyIdentifier = cmdletContext.VerificationKeyIdentifier;
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
        
        private Amazon.PaymentCryptographyData.Model.VerifyPinDataResponse CallAWSServiceOperation(IAmazonPaymentCryptographyData client, Amazon.PaymentCryptographyData.Model.VerifyPinDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Payment Cryptography Data", "VerifyPinData");
            try
            {
                return client.VerifyPinDataAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.PaymentCryptographyData.DukptDerivationType DukptAttributes_DukptDerivationType { get; set; }
            public System.String DukptAttributes_KeySerialNumber { get; set; }
            public System.String EncryptedPinBlock { get; set; }
            public System.String EncryptionKeyIdentifier { get; set; }
            public Amazon.PaymentCryptographyData.KeyCheckValueAlgorithm EncryptionWrappedKey_KeyCheckValueAlgorithm { get; set; }
            public System.String DiffieHellmanSymmetricKey_CertificateAuthorityPublicKeyIdentifier { get; set; }
            public Amazon.PaymentCryptographyData.SymmetricKeyAlgorithm DiffieHellmanSymmetricKey_KeyAlgorithm { get; set; }
            public Amazon.PaymentCryptographyData.KeyDerivationFunction DiffieHellmanSymmetricKey_KeyDerivationFunction { get; set; }
            public Amazon.PaymentCryptographyData.KeyDerivationHashAlgorithm DiffieHellmanSymmetricKey_KeyDerivationHashAlgorithm { get; set; }
            public System.String DiffieHellmanSymmetricKey_PublicKeyCertificate { get; set; }
            public System.String DiffieHellmanSymmetricKey_SharedInformation { get; set; }
            public System.String WrappedKeyMaterial_Tr31KeyBlock { get; set; }
            public Amazon.PaymentCryptographyData.PinBlockFormatForPinData PinBlockFormat { get; set; }
            public System.Int32? PinDataLength { get; set; }
            public System.String PrimaryAccountNumber { get; set; }
            public System.String Ibm3624Pin_DecimalizationTable { get; set; }
            public System.String Ibm3624Pin_PinOffset { get; set; }
            public System.String Ibm3624Pin_PinValidationData { get; set; }
            public System.String Ibm3624Pin_PinValidationDataPadCharacter { get; set; }
            public System.Int32? VisaPin_PinVerificationKeyIndex { get; set; }
            public System.String VisaPin_VerificationValue { get; set; }
            public System.String VerificationKeyIdentifier { get; set; }
            public System.Func<Amazon.PaymentCryptographyData.Model.VerifyPinDataResponse, TestPAYCDPinDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
