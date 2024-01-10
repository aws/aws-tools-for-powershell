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
    /// Encrypts plaintext data to ciphertext using symmetric, asymmetric, or DUKPT data encryption
    /// key. For more information, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/encrypt-data.html">Encrypt
    /// data</a> in the <i>Amazon Web Services Payment Cryptography User Guide</i>.
    /// 
    ///  
    /// <para>
    /// You can generate an encryption key within Amazon Web Services Payment Cryptography
    /// by calling <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_CreateKey.html">CreateKey</a>.
    /// You can import your own encryption key by calling <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_ImportKey.html">ImportKey</a>.
    /// For this operation, the key must have <c>KeyModesOfUse</c> set to <c>Encrypt</c>.
    /// In asymmetric encryption, plaintext is encrypted using public component. You can import
    /// the public component of an asymmetric key pair created outside Amazon Web Services
    /// Payment Cryptography by calling <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_ImportKey.html">ImportKey</a>).
    /// 
    /// </para><para>
    /// for symmetric and DUKPT encryption, Amazon Web Services Payment Cryptography supports
    /// <c>TDES</c> and <c>AES</c> algorithms. For asymmetric encryption, Amazon Web Services
    /// Payment Cryptography supports <c>RSA</c>. To encrypt using DUKPT, you must already
    /// have a DUKPT key in your account with <c>KeyModesOfUse</c> set to <c>DeriveKey</c>,
    /// or you can generate a new DUKPT key by calling <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_CreateKey.html">CreateKey</a>.
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
        "This cmdlet returns an Amazon.PaymentCryptographyData.Model.EncryptDataResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ProtectPAYCDDataCmdlet : AmazonPaymentCryptographyDataClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        /// <para>An input to cryptographic primitive used to provide the intial state. Typically the
        /// <c>InitializationVector</c> must have a random or psuedo-random value, but sometimes
        /// it only needs to be unpredictable or unique. If you don't provide a value, Amazon
        /// Web Services Payment Cryptography generates a random value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionAttributes_Dukpt_InitializationVector")]
        public System.String Dukpt_InitializationVector { get; set; }
        #endregion
        
        #region Parameter Symmetric_InitializationVector
        /// <summary>
        /// <para>
        /// <para>An input to cryptographic primitive used to provide the intial state. The <c>InitializationVector</c>
        /// is typically required have a random or psuedo-random value, but sometimes it only
        /// needs to be unpredictable or unique. If a value is not provided, Amazon Web Services
        /// Payment Cryptography generates a random value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionAttributes_Symmetric_InitializationVector")]
        public System.String Symmetric_InitializationVector { get; set; }
        #endregion
        
        #region Parameter KeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyARN</c> of the encryption key that Amazon Web Services Payment Cryptography
        /// uses for plaintext encryption.</para>
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
        
        #region Parameter Dukpt_Mode
        /// <summary>
        /// <para>
        /// <para>The block cipher mode of operation. Block ciphers are designed to encrypt a block
        /// of data of fixed size, for example, 128 bits. The size of the input block is usually
        /// same as the size of the encrypted output block, while the key length can be different.
        /// A mode of operation describes how to repeatedly apply a cipher's single-block operation
        /// to securely transform amounts of data larger than a block.</para><para>The default is CBC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionAttributes_Dukpt_Mode")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.DukptEncryptionMode")]
        public Amazon.PaymentCryptographyData.DukptEncryptionMode Dukpt_Mode { get; set; }
        #endregion
        
        #region Parameter Symmetric_Mode
        /// <summary>
        /// <para>
        /// <para>The block cipher mode of operation. Block ciphers are designed to encrypt a block
        /// of data of fixed size (for example, 128 bits). The size of the input block is usually
        /// same as the size of the encrypted output block, while the key length can be different.
        /// A mode of operation describes how to repeatedly apply a cipher's single-block operation
        /// to securely transform amounts of data larger than a block.</para>
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
        
        #region Parameter PlainText
        /// <summary>
        /// <para>
        /// <para>The plaintext to be encrypted.</para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the KeyIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^KeyIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^KeyIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KeyIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Protect-PAYCDData (EncryptData)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PaymentCryptographyData.Model.EncryptDataResponse, ProtectPAYCDDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.KeyIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Asymmetric_PaddingType = this.Asymmetric_PaddingType;
            context.Dukpt_DukptKeyDerivationType = this.Dukpt_DukptKeyDerivationType;
            context.Dukpt_DukptKeyVariant = this.Dukpt_DukptKeyVariant;
            context.Dukpt_InitializationVector = this.Dukpt_InitializationVector;
            context.Dukpt_KeySerialNumber = this.Dukpt_KeySerialNumber;
            context.Dukpt_Mode = this.Dukpt_Mode;
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
            public System.String Symmetric_InitializationVector { get; set; }
            public Amazon.PaymentCryptographyData.EncryptionMode Symmetric_Mode { get; set; }
            public Amazon.PaymentCryptographyData.PaddingType Symmetric_PaddingType { get; set; }
            public System.String KeyIdentifier { get; set; }
            public System.String PlainText { get; set; }
            public System.Func<Amazon.PaymentCryptographyData.Model.EncryptDataResponse, ProtectPAYCDDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
