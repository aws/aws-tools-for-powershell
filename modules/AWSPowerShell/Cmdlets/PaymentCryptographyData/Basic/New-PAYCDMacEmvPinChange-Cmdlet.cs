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
    /// Generates an issuer script mac for EMV payment cards that use offline PINs as the
    /// cardholder verification method (CVM).
    /// 
    ///  
    /// <para>
    /// This operation generates an authenticated issuer script response by appending the
    /// incoming message data (APDU command) with the target encrypted PIN block in ISO2 format.
    /// The command structure and method to send the issuer script update to the card is not
    /// defined by this operation and is typically determined by the applicable payment card
    /// scheme.
    /// </para><para>
    /// The primary inputs to this operation include the incoming new encrypted pinblock,
    /// PIN encryption key (PEK), issuer master key (IMK), primary account number (PAN), and
    /// the payment card derivation method.
    /// </para><para>
    /// The operation uses two issuer master keys - secure messaging for confidentiality (IMK-SMC)
    /// and secure messaging for integrity (IMK-SMI). The SMC key is used to internally derive
    /// a key to secure the pin, while SMI key is used to internally derive a key to authenticate
    /// the script reponse as per the <a href="https://www.emvco.com/specifications/">EMV
    /// 4.4 - Book 2 - Security and Key Management</a> specification. 
    /// </para><para>
    /// This operation supports Amex, EMV2000, EMVCommon, Mastercard and Visa derivation methods,
    /// each requiring specific input parameters. Users must follow the specific derivation
    /// method and input parameters defined by the respective payment card scheme.
    /// </para><note><para>
    /// Use <a>GenerateMac</a> operation when sending a script update to an EMV card that
    /// does not involve PIN change. When assigning IAM permissions, it is important to understand
    /// that <a>EncryptData</a> using EMV keys and <a>GenerateMac</a> perform similar functions
    /// to this command.
    /// </para></note><para><b>Cross-account use</b>: This operation can't be used across different Amazon Web
    /// Services accounts.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>EncryptData</a></para></li><li><para><a>GenerateMac</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "PAYCDMacEmvPinChange", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PaymentCryptographyData.Model.GenerateMacEmvPinChangeResponse")]
    [AWSCmdlet("Calls the Payment Cryptography Data GenerateMacEmvPinChange API operation.", Operation = new[] {"GenerateMacEmvPinChange"}, SelectReturnType = typeof(Amazon.PaymentCryptographyData.Model.GenerateMacEmvPinChangeResponse))]
    [AWSCmdletOutput("Amazon.PaymentCryptographyData.Model.GenerateMacEmvPinChangeResponse",
        "This cmdlet returns an Amazon.PaymentCryptographyData.Model.GenerateMacEmvPinChangeResponse object containing multiple properties."
    )]
    public partial class NewPAYCDMacEmvPinChangeCmdlet : AmazonPaymentCryptographyDataClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EmvCommon_ApplicationCryptogram
        /// <summary>
        /// <para>
        /// <para>The application cryptogram for the current transaction that is provided by the terminal
        /// during transaction processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_EmvCommon_ApplicationCryptogram")]
        public System.String EmvCommon_ApplicationCryptogram { get; set; }
        #endregion
        
        #region Parameter Mastercard_ApplicationCryptogram
        /// <summary>
        /// <para>
        /// <para>The application cryptogram for the current transaction that is provided by the terminal
        /// during transaction processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_Mastercard_ApplicationCryptogram")]
        public System.String Mastercard_ApplicationCryptogram { get; set; }
        #endregion
        
        #region Parameter Amex_ApplicationTransactionCounter
        /// <summary>
        /// <para>
        /// <para>The transaction counter of the current transaction that is provided by the terminal
        /// during transaction processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_Amex_ApplicationTransactionCounter")]
        public System.String Amex_ApplicationTransactionCounter { get; set; }
        #endregion
        
        #region Parameter Emv2000_ApplicationTransactionCounter
        /// <summary>
        /// <para>
        /// <para>The transaction counter of the current transaction that is provided by the terminal
        /// during transaction processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_Emv2000_ApplicationTransactionCounter")]
        public System.String Emv2000_ApplicationTransactionCounter { get; set; }
        #endregion
        
        #region Parameter Visa_ApplicationTransactionCounter
        /// <summary>
        /// <para>
        /// <para>The transaction counter of the current transaction that is provided by the terminal
        /// during transaction processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_Visa_ApplicationTransactionCounter")]
        public System.String Visa_ApplicationTransactionCounter { get; set; }
        #endregion
        
        #region Parameter Amex_AuthorizationRequestKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyArn</c> of the issuer master key for cryptogram (IMK-AC) for the payment
        /// card.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_Amex_AuthorizationRequestKeyIdentifier")]
        public System.String Amex_AuthorizationRequestKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter Visa_AuthorizationRequestKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyArn</c> of the issuer master key for cryptogram (IMK-AC) for the payment
        /// card.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_Visa_AuthorizationRequestKeyIdentifier")]
        public System.String Visa_AuthorizationRequestKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter DerivationMethodAttributes_Amex_CurrentPinAttributes_CurrentEncryptedPinBlock
        /// <summary>
        /// <para>
        /// <para>The encrypted pinblock of the current pin stored on the chip card.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DerivationMethodAttributes_Amex_CurrentPinAttributes_CurrentEncryptedPinBlock { get; set; }
        #endregion
        
        #region Parameter DerivationMethodAttributes_Visa_CurrentPinAttributes_CurrentEncryptedPinBlock
        /// <summary>
        /// <para>
        /// <para>The encrypted pinblock of the current pin stored on the chip card.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DerivationMethodAttributes_Visa_CurrentPinAttributes_CurrentEncryptedPinBlock { get; set; }
        #endregion
        
        #region Parameter DerivationMethodAttributes_Amex_CurrentPinAttributes_CurrentPinPekIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyArn</c> of the current PIN PEK.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DerivationMethodAttributes_Amex_CurrentPinAttributes_CurrentPinPekIdentifier { get; set; }
        #endregion
        
        #region Parameter DerivationMethodAttributes_Visa_CurrentPinAttributes_CurrentPinPekIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyArn</c> of the current PIN PEK.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DerivationMethodAttributes_Visa_CurrentPinAttributes_CurrentPinPekIdentifier { get; set; }
        #endregion
        
        #region Parameter Amex_MajorKeyDerivationMode
        /// <summary>
        /// <para>
        /// <para>The method to use when deriving the master key for a payment card using Amex derivation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_Amex_MajorKeyDerivationMode")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.MajorKeyDerivationMode")]
        public Amazon.PaymentCryptographyData.MajorKeyDerivationMode Amex_MajorKeyDerivationMode { get; set; }
        #endregion
        
        #region Parameter Emv2000_MajorKeyDerivationMode
        /// <summary>
        /// <para>
        /// <para>The method to use when deriving the master key for the payment card.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_Emv2000_MajorKeyDerivationMode")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.MajorKeyDerivationMode")]
        public Amazon.PaymentCryptographyData.MajorKeyDerivationMode Emv2000_MajorKeyDerivationMode { get; set; }
        #endregion
        
        #region Parameter EmvCommon_MajorKeyDerivationMode
        /// <summary>
        /// <para>
        /// <para>The method to use when deriving the master key for the payment card.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_EmvCommon_MajorKeyDerivationMode")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.MajorKeyDerivationMode")]
        public Amazon.PaymentCryptographyData.MajorKeyDerivationMode EmvCommon_MajorKeyDerivationMode { get; set; }
        #endregion
        
        #region Parameter Mastercard_MajorKeyDerivationMode
        /// <summary>
        /// <para>
        /// <para>The method to use when deriving the master key for the payment card.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_Mastercard_MajorKeyDerivationMode")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.MajorKeyDerivationMode")]
        public Amazon.PaymentCryptographyData.MajorKeyDerivationMode Mastercard_MajorKeyDerivationMode { get; set; }
        #endregion
        
        #region Parameter Visa_MajorKeyDerivationMode
        /// <summary>
        /// <para>
        /// <para>The method to use when deriving the master key for the payment card.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_Visa_MajorKeyDerivationMode")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.MajorKeyDerivationMode")]
        public Amazon.PaymentCryptographyData.MajorKeyDerivationMode Visa_MajorKeyDerivationMode { get; set; }
        #endregion
        
        #region Parameter MessageData
        /// <summary>
        /// <para>
        /// <para>The message data is the APDU command from the card reader or terminal. The target
        /// encrypted PIN block, after translation to ISO2 format, is appended to this message
        /// data to generate an issuer script response.</para>
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
        public System.String MessageData { get; set; }
        #endregion
        
        #region Parameter EmvCommon_Mode
        /// <summary>
        /// <para>
        /// <para>The block cipher method to use for encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_EmvCommon_Mode")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.EmvEncryptionMode")]
        public Amazon.PaymentCryptographyData.EmvEncryptionMode EmvCommon_Mode { get; set; }
        #endregion
        
        #region Parameter NewEncryptedPinBlock
        /// <summary>
        /// <para>
        /// <para>The incoming new encrypted PIN block data for offline pin change on an EMV card.</para>
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
        public System.String NewEncryptedPinBlock { get; set; }
        #endregion
        
        #region Parameter NewPinPekIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyARN</c> of the PEK protecting the incoming new encrypted PIN block.</para>
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
        public System.String NewPinPekIdentifier { get; set; }
        #endregion
        
        #region Parameter Amex_PanSequenceNumber
        /// <summary>
        /// <para>
        /// <para>A number that identifies and differentiates payment cards with the same Primary Account
        /// Number (PAN). Typically 00 is used, if no value is provided by the terminal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_Amex_PanSequenceNumber")]
        public System.String Amex_PanSequenceNumber { get; set; }
        #endregion
        
        #region Parameter Emv2000_PanSequenceNumber
        /// <summary>
        /// <para>
        /// <para>A number that identifies and differentiates payment cards with the same Primary Account
        /// Number (PAN). Typically 00 is used, if no value is provided by the terminal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_Emv2000_PanSequenceNumber")]
        public System.String Emv2000_PanSequenceNumber { get; set; }
        #endregion
        
        #region Parameter EmvCommon_PanSequenceNumber
        /// <summary>
        /// <para>
        /// <para>A number that identifies and differentiates payment cards with the same Primary Account
        /// Number (PAN). Typically 00 is used, if no value is provided by the terminal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_EmvCommon_PanSequenceNumber")]
        public System.String EmvCommon_PanSequenceNumber { get; set; }
        #endregion
        
        #region Parameter Mastercard_PanSequenceNumber
        /// <summary>
        /// <para>
        /// <para>A number that identifies and differentiates payment cards with the same Primary Account
        /// Number (PAN). Typically 00 is used, if no value is provided by the terminal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_Mastercard_PanSequenceNumber")]
        public System.String Mastercard_PanSequenceNumber { get; set; }
        #endregion
        
        #region Parameter Visa_PanSequenceNumber
        /// <summary>
        /// <para>
        /// <para>A number that identifies and differentiates payment cards with the same Primary Account
        /// Number (PAN). Typically 00 is used, if no value is provided by the terminal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_Visa_PanSequenceNumber")]
        public System.String Visa_PanSequenceNumber { get; set; }
        #endregion
        
        #region Parameter PinBlockFormat
        /// <summary>
        /// <para>
        /// <para>The PIN encoding format of the incoming new encrypted PIN block as specified in ISO
        /// 9564.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.PinBlockFormatForEmvPinChange")]
        public Amazon.PaymentCryptographyData.PinBlockFormatForEmvPinChange PinBlockFormat { get; set; }
        #endregion
        
        #region Parameter EmvCommon_PinBlockLengthPosition
        /// <summary>
        /// <para>
        /// <para>Specifies if PIN block length should be added to front of the pin block. </para><para>If value is set to <c>FRONT_OF_PIN_BLOCK</c>, then PIN block padding type should be
        /// <c>ISO_IEC_7816_4</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_EmvCommon_PinBlockLengthPosition")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.PinBlockLengthPosition")]
        public Amazon.PaymentCryptographyData.PinBlockLengthPosition EmvCommon_PinBlockLengthPosition { get; set; }
        #endregion
        
        #region Parameter EmvCommon_PinBlockPaddingType
        /// <summary>
        /// <para>
        /// <para>The padding to be added to the PIN block prior to encryption.</para><para>Padding type should be <c>ISO_IEC_7816_4</c>, if <c>PinBlockLengthPosition</c> is
        /// set to <c>FRONT_OF_PIN_BLOCK</c>. No padding is required, if <c>PinBlockLengthPosition</c>
        /// is set to <c>NONE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_EmvCommon_PinBlockPaddingType")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.PinBlockPaddingType")]
        public Amazon.PaymentCryptographyData.PinBlockPaddingType EmvCommon_PinBlockPaddingType { get; set; }
        #endregion
        
        #region Parameter Amex_PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN) of the cardholder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_Amex_PrimaryAccountNumber")]
        public System.String Amex_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter Emv2000_PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN) of the cardholder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_Emv2000_PrimaryAccountNumber")]
        public System.String Emv2000_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter EmvCommon_PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN) of the cardholder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_EmvCommon_PrimaryAccountNumber")]
        public System.String EmvCommon_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter Mastercard_PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN) of the cardholder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_Mastercard_PrimaryAccountNumber")]
        public System.String Mastercard_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter Visa_PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN) of the cardholder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DerivationMethodAttributes_Visa_PrimaryAccountNumber")]
        public System.String Visa_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter SecureMessagingConfidentialityKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyARN</c> of the issuer master key (IMK-SMC) used to protect the PIN block
        /// data in the issuer script response.</para>
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
        public System.String SecureMessagingConfidentialityKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter SecureMessagingIntegrityKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyARN</c> of the issuer master key (IMK-SMI) used to authenticate the issuer
        /// script response.</para>
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
        public System.String SecureMessagingIntegrityKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PaymentCryptographyData.Model.GenerateMacEmvPinChangeResponse).
        /// Specifying the name of a property of type Amazon.PaymentCryptographyData.Model.GenerateMacEmvPinChangeResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PAYCDMacEmvPinChange (GenerateMacEmvPinChange)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PaymentCryptographyData.Model.GenerateMacEmvPinChangeResponse, NewPAYCDMacEmvPinChangeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Amex_ApplicationTransactionCounter = this.Amex_ApplicationTransactionCounter;
            context.Amex_AuthorizationRequestKeyIdentifier = this.Amex_AuthorizationRequestKeyIdentifier;
            context.DerivationMethodAttributes_Amex_CurrentPinAttributes_CurrentEncryptedPinBlock = this.DerivationMethodAttributes_Amex_CurrentPinAttributes_CurrentEncryptedPinBlock;
            context.DerivationMethodAttributes_Amex_CurrentPinAttributes_CurrentPinPekIdentifier = this.DerivationMethodAttributes_Amex_CurrentPinAttributes_CurrentPinPekIdentifier;
            context.Amex_MajorKeyDerivationMode = this.Amex_MajorKeyDerivationMode;
            context.Amex_PanSequenceNumber = this.Amex_PanSequenceNumber;
            context.Amex_PrimaryAccountNumber = this.Amex_PrimaryAccountNumber;
            context.Emv2000_ApplicationTransactionCounter = this.Emv2000_ApplicationTransactionCounter;
            context.Emv2000_MajorKeyDerivationMode = this.Emv2000_MajorKeyDerivationMode;
            context.Emv2000_PanSequenceNumber = this.Emv2000_PanSequenceNumber;
            context.Emv2000_PrimaryAccountNumber = this.Emv2000_PrimaryAccountNumber;
            context.EmvCommon_ApplicationCryptogram = this.EmvCommon_ApplicationCryptogram;
            context.EmvCommon_MajorKeyDerivationMode = this.EmvCommon_MajorKeyDerivationMode;
            context.EmvCommon_Mode = this.EmvCommon_Mode;
            context.EmvCommon_PanSequenceNumber = this.EmvCommon_PanSequenceNumber;
            context.EmvCommon_PinBlockLengthPosition = this.EmvCommon_PinBlockLengthPosition;
            context.EmvCommon_PinBlockPaddingType = this.EmvCommon_PinBlockPaddingType;
            context.EmvCommon_PrimaryAccountNumber = this.EmvCommon_PrimaryAccountNumber;
            context.Mastercard_ApplicationCryptogram = this.Mastercard_ApplicationCryptogram;
            context.Mastercard_MajorKeyDerivationMode = this.Mastercard_MajorKeyDerivationMode;
            context.Mastercard_PanSequenceNumber = this.Mastercard_PanSequenceNumber;
            context.Mastercard_PrimaryAccountNumber = this.Mastercard_PrimaryAccountNumber;
            context.Visa_ApplicationTransactionCounter = this.Visa_ApplicationTransactionCounter;
            context.Visa_AuthorizationRequestKeyIdentifier = this.Visa_AuthorizationRequestKeyIdentifier;
            context.DerivationMethodAttributes_Visa_CurrentPinAttributes_CurrentEncryptedPinBlock = this.DerivationMethodAttributes_Visa_CurrentPinAttributes_CurrentEncryptedPinBlock;
            context.DerivationMethodAttributes_Visa_CurrentPinAttributes_CurrentPinPekIdentifier = this.DerivationMethodAttributes_Visa_CurrentPinAttributes_CurrentPinPekIdentifier;
            context.Visa_MajorKeyDerivationMode = this.Visa_MajorKeyDerivationMode;
            context.Visa_PanSequenceNumber = this.Visa_PanSequenceNumber;
            context.Visa_PrimaryAccountNumber = this.Visa_PrimaryAccountNumber;
            context.MessageData = this.MessageData;
            #if MODULAR
            if (this.MessageData == null && ParameterWasBound(nameof(this.MessageData)))
            {
                WriteWarning("You are passing $null as a value for parameter MessageData which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NewEncryptedPinBlock = this.NewEncryptedPinBlock;
            #if MODULAR
            if (this.NewEncryptedPinBlock == null && ParameterWasBound(nameof(this.NewEncryptedPinBlock)))
            {
                WriteWarning("You are passing $null as a value for parameter NewEncryptedPinBlock which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NewPinPekIdentifier = this.NewPinPekIdentifier;
            #if MODULAR
            if (this.NewPinPekIdentifier == null && ParameterWasBound(nameof(this.NewPinPekIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter NewPinPekIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PinBlockFormat = this.PinBlockFormat;
            #if MODULAR
            if (this.PinBlockFormat == null && ParameterWasBound(nameof(this.PinBlockFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter PinBlockFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SecureMessagingConfidentialityKeyIdentifier = this.SecureMessagingConfidentialityKeyIdentifier;
            #if MODULAR
            if (this.SecureMessagingConfidentialityKeyIdentifier == null && ParameterWasBound(nameof(this.SecureMessagingConfidentialityKeyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter SecureMessagingConfidentialityKeyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SecureMessagingIntegrityKeyIdentifier = this.SecureMessagingIntegrityKeyIdentifier;
            #if MODULAR
            if (this.SecureMessagingIntegrityKeyIdentifier == null && ParameterWasBound(nameof(this.SecureMessagingIntegrityKeyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter SecureMessagingIntegrityKeyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PaymentCryptographyData.Model.GenerateMacEmvPinChangeRequest();
            
            
             // populate DerivationMethodAttributes
            var requestDerivationMethodAttributesIsNull = true;
            request.DerivationMethodAttributes = new Amazon.PaymentCryptographyData.Model.DerivationMethodAttributes();
            Amazon.PaymentCryptographyData.Model.Emv2000Attributes requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000 = null;
            
             // populate Emv2000
            var requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000IsNull = true;
            requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000 = new Amazon.PaymentCryptographyData.Model.Emv2000Attributes();
            System.String requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000_emv2000_ApplicationTransactionCounter = null;
            if (cmdletContext.Emv2000_ApplicationTransactionCounter != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000_emv2000_ApplicationTransactionCounter = cmdletContext.Emv2000_ApplicationTransactionCounter;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000_emv2000_ApplicationTransactionCounter != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000.ApplicationTransactionCounter = requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000_emv2000_ApplicationTransactionCounter;
                requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000IsNull = false;
            }
            Amazon.PaymentCryptographyData.MajorKeyDerivationMode requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000_emv2000_MajorKeyDerivationMode = null;
            if (cmdletContext.Emv2000_MajorKeyDerivationMode != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000_emv2000_MajorKeyDerivationMode = cmdletContext.Emv2000_MajorKeyDerivationMode;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000_emv2000_MajorKeyDerivationMode != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000.MajorKeyDerivationMode = requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000_emv2000_MajorKeyDerivationMode;
                requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000IsNull = false;
            }
            System.String requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000_emv2000_PanSequenceNumber = null;
            if (cmdletContext.Emv2000_PanSequenceNumber != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000_emv2000_PanSequenceNumber = cmdletContext.Emv2000_PanSequenceNumber;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000_emv2000_PanSequenceNumber != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000.PanSequenceNumber = requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000_emv2000_PanSequenceNumber;
                requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000IsNull = false;
            }
            System.String requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000_emv2000_PrimaryAccountNumber = null;
            if (cmdletContext.Emv2000_PrimaryAccountNumber != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000_emv2000_PrimaryAccountNumber = cmdletContext.Emv2000_PrimaryAccountNumber;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000_emv2000_PrimaryAccountNumber != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000.PrimaryAccountNumber = requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000_emv2000_PrimaryAccountNumber;
                requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000IsNull = false;
            }
             // determine if requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000 should be set to null
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000IsNull)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000 = null;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000 != null)
            {
                request.DerivationMethodAttributes.Emv2000 = requestDerivationMethodAttributes_derivationMethodAttributes_Emv2000;
                requestDerivationMethodAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.MasterCardAttributes requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard = null;
            
             // populate Mastercard
            var requestDerivationMethodAttributes_derivationMethodAttributes_MastercardIsNull = true;
            requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard = new Amazon.PaymentCryptographyData.Model.MasterCardAttributes();
            System.String requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard_mastercard_ApplicationCryptogram = null;
            if (cmdletContext.Mastercard_ApplicationCryptogram != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard_mastercard_ApplicationCryptogram = cmdletContext.Mastercard_ApplicationCryptogram;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard_mastercard_ApplicationCryptogram != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard.ApplicationCryptogram = requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard_mastercard_ApplicationCryptogram;
                requestDerivationMethodAttributes_derivationMethodAttributes_MastercardIsNull = false;
            }
            Amazon.PaymentCryptographyData.MajorKeyDerivationMode requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard_mastercard_MajorKeyDerivationMode = null;
            if (cmdletContext.Mastercard_MajorKeyDerivationMode != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard_mastercard_MajorKeyDerivationMode = cmdletContext.Mastercard_MajorKeyDerivationMode;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard_mastercard_MajorKeyDerivationMode != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard.MajorKeyDerivationMode = requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard_mastercard_MajorKeyDerivationMode;
                requestDerivationMethodAttributes_derivationMethodAttributes_MastercardIsNull = false;
            }
            System.String requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard_mastercard_PanSequenceNumber = null;
            if (cmdletContext.Mastercard_PanSequenceNumber != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard_mastercard_PanSequenceNumber = cmdletContext.Mastercard_PanSequenceNumber;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard_mastercard_PanSequenceNumber != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard.PanSequenceNumber = requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard_mastercard_PanSequenceNumber;
                requestDerivationMethodAttributes_derivationMethodAttributes_MastercardIsNull = false;
            }
            System.String requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard_mastercard_PrimaryAccountNumber = null;
            if (cmdletContext.Mastercard_PrimaryAccountNumber != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard_mastercard_PrimaryAccountNumber = cmdletContext.Mastercard_PrimaryAccountNumber;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard_mastercard_PrimaryAccountNumber != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard.PrimaryAccountNumber = requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard_mastercard_PrimaryAccountNumber;
                requestDerivationMethodAttributes_derivationMethodAttributes_MastercardIsNull = false;
            }
             // determine if requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard should be set to null
            if (requestDerivationMethodAttributes_derivationMethodAttributes_MastercardIsNull)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard = null;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard != null)
            {
                request.DerivationMethodAttributes.Mastercard = requestDerivationMethodAttributes_derivationMethodAttributes_Mastercard;
                requestDerivationMethodAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.AmexAttributes requestDerivationMethodAttributes_derivationMethodAttributes_Amex = null;
            
             // populate Amex
            var requestDerivationMethodAttributes_derivationMethodAttributes_AmexIsNull = true;
            requestDerivationMethodAttributes_derivationMethodAttributes_Amex = new Amazon.PaymentCryptographyData.Model.AmexAttributes();
            System.String requestDerivationMethodAttributes_derivationMethodAttributes_Amex_amex_ApplicationTransactionCounter = null;
            if (cmdletContext.Amex_ApplicationTransactionCounter != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Amex_amex_ApplicationTransactionCounter = cmdletContext.Amex_ApplicationTransactionCounter;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Amex_amex_ApplicationTransactionCounter != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Amex.ApplicationTransactionCounter = requestDerivationMethodAttributes_derivationMethodAttributes_Amex_amex_ApplicationTransactionCounter;
                requestDerivationMethodAttributes_derivationMethodAttributes_AmexIsNull = false;
            }
            System.String requestDerivationMethodAttributes_derivationMethodAttributes_Amex_amex_AuthorizationRequestKeyIdentifier = null;
            if (cmdletContext.Amex_AuthorizationRequestKeyIdentifier != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Amex_amex_AuthorizationRequestKeyIdentifier = cmdletContext.Amex_AuthorizationRequestKeyIdentifier;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Amex_amex_AuthorizationRequestKeyIdentifier != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Amex.AuthorizationRequestKeyIdentifier = requestDerivationMethodAttributes_derivationMethodAttributes_Amex_amex_AuthorizationRequestKeyIdentifier;
                requestDerivationMethodAttributes_derivationMethodAttributes_AmexIsNull = false;
            }
            Amazon.PaymentCryptographyData.MajorKeyDerivationMode requestDerivationMethodAttributes_derivationMethodAttributes_Amex_amex_MajorKeyDerivationMode = null;
            if (cmdletContext.Amex_MajorKeyDerivationMode != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Amex_amex_MajorKeyDerivationMode = cmdletContext.Amex_MajorKeyDerivationMode;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Amex_amex_MajorKeyDerivationMode != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Amex.MajorKeyDerivationMode = requestDerivationMethodAttributes_derivationMethodAttributes_Amex_amex_MajorKeyDerivationMode;
                requestDerivationMethodAttributes_derivationMethodAttributes_AmexIsNull = false;
            }
            System.String requestDerivationMethodAttributes_derivationMethodAttributes_Amex_amex_PanSequenceNumber = null;
            if (cmdletContext.Amex_PanSequenceNumber != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Amex_amex_PanSequenceNumber = cmdletContext.Amex_PanSequenceNumber;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Amex_amex_PanSequenceNumber != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Amex.PanSequenceNumber = requestDerivationMethodAttributes_derivationMethodAttributes_Amex_amex_PanSequenceNumber;
                requestDerivationMethodAttributes_derivationMethodAttributes_AmexIsNull = false;
            }
            System.String requestDerivationMethodAttributes_derivationMethodAttributes_Amex_amex_PrimaryAccountNumber = null;
            if (cmdletContext.Amex_PrimaryAccountNumber != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Amex_amex_PrimaryAccountNumber = cmdletContext.Amex_PrimaryAccountNumber;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Amex_amex_PrimaryAccountNumber != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Amex.PrimaryAccountNumber = requestDerivationMethodAttributes_derivationMethodAttributes_Amex_amex_PrimaryAccountNumber;
                requestDerivationMethodAttributes_derivationMethodAttributes_AmexIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.CurrentPinAttributes requestDerivationMethodAttributes_derivationMethodAttributes_Amex_derivationMethodAttributes_Amex_CurrentPinAttributes = null;
            
             // populate CurrentPinAttributes
            var requestDerivationMethodAttributes_derivationMethodAttributes_Amex_derivationMethodAttributes_Amex_CurrentPinAttributesIsNull = true;
            requestDerivationMethodAttributes_derivationMethodAttributes_Amex_derivationMethodAttributes_Amex_CurrentPinAttributes = new Amazon.PaymentCryptographyData.Model.CurrentPinAttributes();
            System.String requestDerivationMethodAttributes_derivationMethodAttributes_Amex_derivationMethodAttributes_Amex_CurrentPinAttributes_derivationMethodAttributes_Amex_CurrentPinAttributes_CurrentEncryptedPinBlock = null;
            if (cmdletContext.DerivationMethodAttributes_Amex_CurrentPinAttributes_CurrentEncryptedPinBlock != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Amex_derivationMethodAttributes_Amex_CurrentPinAttributes_derivationMethodAttributes_Amex_CurrentPinAttributes_CurrentEncryptedPinBlock = cmdletContext.DerivationMethodAttributes_Amex_CurrentPinAttributes_CurrentEncryptedPinBlock;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Amex_derivationMethodAttributes_Amex_CurrentPinAttributes_derivationMethodAttributes_Amex_CurrentPinAttributes_CurrentEncryptedPinBlock != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Amex_derivationMethodAttributes_Amex_CurrentPinAttributes.CurrentEncryptedPinBlock = requestDerivationMethodAttributes_derivationMethodAttributes_Amex_derivationMethodAttributes_Amex_CurrentPinAttributes_derivationMethodAttributes_Amex_CurrentPinAttributes_CurrentEncryptedPinBlock;
                requestDerivationMethodAttributes_derivationMethodAttributes_Amex_derivationMethodAttributes_Amex_CurrentPinAttributesIsNull = false;
            }
            System.String requestDerivationMethodAttributes_derivationMethodAttributes_Amex_derivationMethodAttributes_Amex_CurrentPinAttributes_derivationMethodAttributes_Amex_CurrentPinAttributes_CurrentPinPekIdentifier = null;
            if (cmdletContext.DerivationMethodAttributes_Amex_CurrentPinAttributes_CurrentPinPekIdentifier != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Amex_derivationMethodAttributes_Amex_CurrentPinAttributes_derivationMethodAttributes_Amex_CurrentPinAttributes_CurrentPinPekIdentifier = cmdletContext.DerivationMethodAttributes_Amex_CurrentPinAttributes_CurrentPinPekIdentifier;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Amex_derivationMethodAttributes_Amex_CurrentPinAttributes_derivationMethodAttributes_Amex_CurrentPinAttributes_CurrentPinPekIdentifier != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Amex_derivationMethodAttributes_Amex_CurrentPinAttributes.CurrentPinPekIdentifier = requestDerivationMethodAttributes_derivationMethodAttributes_Amex_derivationMethodAttributes_Amex_CurrentPinAttributes_derivationMethodAttributes_Amex_CurrentPinAttributes_CurrentPinPekIdentifier;
                requestDerivationMethodAttributes_derivationMethodAttributes_Amex_derivationMethodAttributes_Amex_CurrentPinAttributesIsNull = false;
            }
             // determine if requestDerivationMethodAttributes_derivationMethodAttributes_Amex_derivationMethodAttributes_Amex_CurrentPinAttributes should be set to null
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Amex_derivationMethodAttributes_Amex_CurrentPinAttributesIsNull)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Amex_derivationMethodAttributes_Amex_CurrentPinAttributes = null;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Amex_derivationMethodAttributes_Amex_CurrentPinAttributes != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Amex.CurrentPinAttributes = requestDerivationMethodAttributes_derivationMethodAttributes_Amex_derivationMethodAttributes_Amex_CurrentPinAttributes;
                requestDerivationMethodAttributes_derivationMethodAttributes_AmexIsNull = false;
            }
             // determine if requestDerivationMethodAttributes_derivationMethodAttributes_Amex should be set to null
            if (requestDerivationMethodAttributes_derivationMethodAttributes_AmexIsNull)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Amex = null;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Amex != null)
            {
                request.DerivationMethodAttributes.Amex = requestDerivationMethodAttributes_derivationMethodAttributes_Amex;
                requestDerivationMethodAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.VisaAttributes requestDerivationMethodAttributes_derivationMethodAttributes_Visa = null;
            
             // populate Visa
            var requestDerivationMethodAttributes_derivationMethodAttributes_VisaIsNull = true;
            requestDerivationMethodAttributes_derivationMethodAttributes_Visa = new Amazon.PaymentCryptographyData.Model.VisaAttributes();
            System.String requestDerivationMethodAttributes_derivationMethodAttributes_Visa_visa_ApplicationTransactionCounter = null;
            if (cmdletContext.Visa_ApplicationTransactionCounter != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Visa_visa_ApplicationTransactionCounter = cmdletContext.Visa_ApplicationTransactionCounter;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Visa_visa_ApplicationTransactionCounter != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Visa.ApplicationTransactionCounter = requestDerivationMethodAttributes_derivationMethodAttributes_Visa_visa_ApplicationTransactionCounter;
                requestDerivationMethodAttributes_derivationMethodAttributes_VisaIsNull = false;
            }
            System.String requestDerivationMethodAttributes_derivationMethodAttributes_Visa_visa_AuthorizationRequestKeyIdentifier = null;
            if (cmdletContext.Visa_AuthorizationRequestKeyIdentifier != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Visa_visa_AuthorizationRequestKeyIdentifier = cmdletContext.Visa_AuthorizationRequestKeyIdentifier;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Visa_visa_AuthorizationRequestKeyIdentifier != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Visa.AuthorizationRequestKeyIdentifier = requestDerivationMethodAttributes_derivationMethodAttributes_Visa_visa_AuthorizationRequestKeyIdentifier;
                requestDerivationMethodAttributes_derivationMethodAttributes_VisaIsNull = false;
            }
            Amazon.PaymentCryptographyData.MajorKeyDerivationMode requestDerivationMethodAttributes_derivationMethodAttributes_Visa_visa_MajorKeyDerivationMode = null;
            if (cmdletContext.Visa_MajorKeyDerivationMode != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Visa_visa_MajorKeyDerivationMode = cmdletContext.Visa_MajorKeyDerivationMode;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Visa_visa_MajorKeyDerivationMode != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Visa.MajorKeyDerivationMode = requestDerivationMethodAttributes_derivationMethodAttributes_Visa_visa_MajorKeyDerivationMode;
                requestDerivationMethodAttributes_derivationMethodAttributes_VisaIsNull = false;
            }
            System.String requestDerivationMethodAttributes_derivationMethodAttributes_Visa_visa_PanSequenceNumber = null;
            if (cmdletContext.Visa_PanSequenceNumber != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Visa_visa_PanSequenceNumber = cmdletContext.Visa_PanSequenceNumber;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Visa_visa_PanSequenceNumber != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Visa.PanSequenceNumber = requestDerivationMethodAttributes_derivationMethodAttributes_Visa_visa_PanSequenceNumber;
                requestDerivationMethodAttributes_derivationMethodAttributes_VisaIsNull = false;
            }
            System.String requestDerivationMethodAttributes_derivationMethodAttributes_Visa_visa_PrimaryAccountNumber = null;
            if (cmdletContext.Visa_PrimaryAccountNumber != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Visa_visa_PrimaryAccountNumber = cmdletContext.Visa_PrimaryAccountNumber;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Visa_visa_PrimaryAccountNumber != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Visa.PrimaryAccountNumber = requestDerivationMethodAttributes_derivationMethodAttributes_Visa_visa_PrimaryAccountNumber;
                requestDerivationMethodAttributes_derivationMethodAttributes_VisaIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.CurrentPinAttributes requestDerivationMethodAttributes_derivationMethodAttributes_Visa_derivationMethodAttributes_Visa_CurrentPinAttributes = null;
            
             // populate CurrentPinAttributes
            var requestDerivationMethodAttributes_derivationMethodAttributes_Visa_derivationMethodAttributes_Visa_CurrentPinAttributesIsNull = true;
            requestDerivationMethodAttributes_derivationMethodAttributes_Visa_derivationMethodAttributes_Visa_CurrentPinAttributes = new Amazon.PaymentCryptographyData.Model.CurrentPinAttributes();
            System.String requestDerivationMethodAttributes_derivationMethodAttributes_Visa_derivationMethodAttributes_Visa_CurrentPinAttributes_derivationMethodAttributes_Visa_CurrentPinAttributes_CurrentEncryptedPinBlock = null;
            if (cmdletContext.DerivationMethodAttributes_Visa_CurrentPinAttributes_CurrentEncryptedPinBlock != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Visa_derivationMethodAttributes_Visa_CurrentPinAttributes_derivationMethodAttributes_Visa_CurrentPinAttributes_CurrentEncryptedPinBlock = cmdletContext.DerivationMethodAttributes_Visa_CurrentPinAttributes_CurrentEncryptedPinBlock;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Visa_derivationMethodAttributes_Visa_CurrentPinAttributes_derivationMethodAttributes_Visa_CurrentPinAttributes_CurrentEncryptedPinBlock != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Visa_derivationMethodAttributes_Visa_CurrentPinAttributes.CurrentEncryptedPinBlock = requestDerivationMethodAttributes_derivationMethodAttributes_Visa_derivationMethodAttributes_Visa_CurrentPinAttributes_derivationMethodAttributes_Visa_CurrentPinAttributes_CurrentEncryptedPinBlock;
                requestDerivationMethodAttributes_derivationMethodAttributes_Visa_derivationMethodAttributes_Visa_CurrentPinAttributesIsNull = false;
            }
            System.String requestDerivationMethodAttributes_derivationMethodAttributes_Visa_derivationMethodAttributes_Visa_CurrentPinAttributes_derivationMethodAttributes_Visa_CurrentPinAttributes_CurrentPinPekIdentifier = null;
            if (cmdletContext.DerivationMethodAttributes_Visa_CurrentPinAttributes_CurrentPinPekIdentifier != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Visa_derivationMethodAttributes_Visa_CurrentPinAttributes_derivationMethodAttributes_Visa_CurrentPinAttributes_CurrentPinPekIdentifier = cmdletContext.DerivationMethodAttributes_Visa_CurrentPinAttributes_CurrentPinPekIdentifier;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Visa_derivationMethodAttributes_Visa_CurrentPinAttributes_derivationMethodAttributes_Visa_CurrentPinAttributes_CurrentPinPekIdentifier != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Visa_derivationMethodAttributes_Visa_CurrentPinAttributes.CurrentPinPekIdentifier = requestDerivationMethodAttributes_derivationMethodAttributes_Visa_derivationMethodAttributes_Visa_CurrentPinAttributes_derivationMethodAttributes_Visa_CurrentPinAttributes_CurrentPinPekIdentifier;
                requestDerivationMethodAttributes_derivationMethodAttributes_Visa_derivationMethodAttributes_Visa_CurrentPinAttributesIsNull = false;
            }
             // determine if requestDerivationMethodAttributes_derivationMethodAttributes_Visa_derivationMethodAttributes_Visa_CurrentPinAttributes should be set to null
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Visa_derivationMethodAttributes_Visa_CurrentPinAttributesIsNull)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Visa_derivationMethodAttributes_Visa_CurrentPinAttributes = null;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Visa_derivationMethodAttributes_Visa_CurrentPinAttributes != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Visa.CurrentPinAttributes = requestDerivationMethodAttributes_derivationMethodAttributes_Visa_derivationMethodAttributes_Visa_CurrentPinAttributes;
                requestDerivationMethodAttributes_derivationMethodAttributes_VisaIsNull = false;
            }
             // determine if requestDerivationMethodAttributes_derivationMethodAttributes_Visa should be set to null
            if (requestDerivationMethodAttributes_derivationMethodAttributes_VisaIsNull)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_Visa = null;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_Visa != null)
            {
                request.DerivationMethodAttributes.Visa = requestDerivationMethodAttributes_derivationMethodAttributes_Visa;
                requestDerivationMethodAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.EmvCommonAttributes requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon = null;
            
             // populate EmvCommon
            var requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommonIsNull = true;
            requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon = new Amazon.PaymentCryptographyData.Model.EmvCommonAttributes();
            System.String requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_ApplicationCryptogram = null;
            if (cmdletContext.EmvCommon_ApplicationCryptogram != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_ApplicationCryptogram = cmdletContext.EmvCommon_ApplicationCryptogram;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_ApplicationCryptogram != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon.ApplicationCryptogram = requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_ApplicationCryptogram;
                requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommonIsNull = false;
            }
            Amazon.PaymentCryptographyData.MajorKeyDerivationMode requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_MajorKeyDerivationMode = null;
            if (cmdletContext.EmvCommon_MajorKeyDerivationMode != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_MajorKeyDerivationMode = cmdletContext.EmvCommon_MajorKeyDerivationMode;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_MajorKeyDerivationMode != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon.MajorKeyDerivationMode = requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_MajorKeyDerivationMode;
                requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommonIsNull = false;
            }
            Amazon.PaymentCryptographyData.EmvEncryptionMode requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_Mode = null;
            if (cmdletContext.EmvCommon_Mode != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_Mode = cmdletContext.EmvCommon_Mode;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_Mode != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon.Mode = requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_Mode;
                requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommonIsNull = false;
            }
            System.String requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_PanSequenceNumber = null;
            if (cmdletContext.EmvCommon_PanSequenceNumber != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_PanSequenceNumber = cmdletContext.EmvCommon_PanSequenceNumber;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_PanSequenceNumber != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon.PanSequenceNumber = requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_PanSequenceNumber;
                requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommonIsNull = false;
            }
            Amazon.PaymentCryptographyData.PinBlockLengthPosition requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_PinBlockLengthPosition = null;
            if (cmdletContext.EmvCommon_PinBlockLengthPosition != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_PinBlockLengthPosition = cmdletContext.EmvCommon_PinBlockLengthPosition;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_PinBlockLengthPosition != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon.PinBlockLengthPosition = requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_PinBlockLengthPosition;
                requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommonIsNull = false;
            }
            Amazon.PaymentCryptographyData.PinBlockPaddingType requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_PinBlockPaddingType = null;
            if (cmdletContext.EmvCommon_PinBlockPaddingType != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_PinBlockPaddingType = cmdletContext.EmvCommon_PinBlockPaddingType;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_PinBlockPaddingType != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon.PinBlockPaddingType = requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_PinBlockPaddingType;
                requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommonIsNull = false;
            }
            System.String requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_PrimaryAccountNumber = null;
            if (cmdletContext.EmvCommon_PrimaryAccountNumber != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_PrimaryAccountNumber = cmdletContext.EmvCommon_PrimaryAccountNumber;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_PrimaryAccountNumber != null)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon.PrimaryAccountNumber = requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon_emvCommon_PrimaryAccountNumber;
                requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommonIsNull = false;
            }
             // determine if requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon should be set to null
            if (requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommonIsNull)
            {
                requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon = null;
            }
            if (requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon != null)
            {
                request.DerivationMethodAttributes.EmvCommon = requestDerivationMethodAttributes_derivationMethodAttributes_EmvCommon;
                requestDerivationMethodAttributesIsNull = false;
            }
             // determine if request.DerivationMethodAttributes should be set to null
            if (requestDerivationMethodAttributesIsNull)
            {
                request.DerivationMethodAttributes = null;
            }
            if (cmdletContext.MessageData != null)
            {
                request.MessageData = cmdletContext.MessageData;
            }
            if (cmdletContext.NewEncryptedPinBlock != null)
            {
                request.NewEncryptedPinBlock = cmdletContext.NewEncryptedPinBlock;
            }
            if (cmdletContext.NewPinPekIdentifier != null)
            {
                request.NewPinPekIdentifier = cmdletContext.NewPinPekIdentifier;
            }
            if (cmdletContext.PinBlockFormat != null)
            {
                request.PinBlockFormat = cmdletContext.PinBlockFormat;
            }
            if (cmdletContext.SecureMessagingConfidentialityKeyIdentifier != null)
            {
                request.SecureMessagingConfidentialityKeyIdentifier = cmdletContext.SecureMessagingConfidentialityKeyIdentifier;
            }
            if (cmdletContext.SecureMessagingIntegrityKeyIdentifier != null)
            {
                request.SecureMessagingIntegrityKeyIdentifier = cmdletContext.SecureMessagingIntegrityKeyIdentifier;
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
        
        private Amazon.PaymentCryptographyData.Model.GenerateMacEmvPinChangeResponse CallAWSServiceOperation(IAmazonPaymentCryptographyData client, Amazon.PaymentCryptographyData.Model.GenerateMacEmvPinChangeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Payment Cryptography Data", "GenerateMacEmvPinChange");
            try
            {
                #if DESKTOP
                return client.GenerateMacEmvPinChange(request);
                #elif CORECLR
                return client.GenerateMacEmvPinChangeAsync(request).GetAwaiter().GetResult();
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
            public System.String Amex_ApplicationTransactionCounter { get; set; }
            public System.String Amex_AuthorizationRequestKeyIdentifier { get; set; }
            public System.String DerivationMethodAttributes_Amex_CurrentPinAttributes_CurrentEncryptedPinBlock { get; set; }
            public System.String DerivationMethodAttributes_Amex_CurrentPinAttributes_CurrentPinPekIdentifier { get; set; }
            public Amazon.PaymentCryptographyData.MajorKeyDerivationMode Amex_MajorKeyDerivationMode { get; set; }
            public System.String Amex_PanSequenceNumber { get; set; }
            public System.String Amex_PrimaryAccountNumber { get; set; }
            public System.String Emv2000_ApplicationTransactionCounter { get; set; }
            public Amazon.PaymentCryptographyData.MajorKeyDerivationMode Emv2000_MajorKeyDerivationMode { get; set; }
            public System.String Emv2000_PanSequenceNumber { get; set; }
            public System.String Emv2000_PrimaryAccountNumber { get; set; }
            public System.String EmvCommon_ApplicationCryptogram { get; set; }
            public Amazon.PaymentCryptographyData.MajorKeyDerivationMode EmvCommon_MajorKeyDerivationMode { get; set; }
            public Amazon.PaymentCryptographyData.EmvEncryptionMode EmvCommon_Mode { get; set; }
            public System.String EmvCommon_PanSequenceNumber { get; set; }
            public Amazon.PaymentCryptographyData.PinBlockLengthPosition EmvCommon_PinBlockLengthPosition { get; set; }
            public Amazon.PaymentCryptographyData.PinBlockPaddingType EmvCommon_PinBlockPaddingType { get; set; }
            public System.String EmvCommon_PrimaryAccountNumber { get; set; }
            public System.String Mastercard_ApplicationCryptogram { get; set; }
            public Amazon.PaymentCryptographyData.MajorKeyDerivationMode Mastercard_MajorKeyDerivationMode { get; set; }
            public System.String Mastercard_PanSequenceNumber { get; set; }
            public System.String Mastercard_PrimaryAccountNumber { get; set; }
            public System.String Visa_ApplicationTransactionCounter { get; set; }
            public System.String Visa_AuthorizationRequestKeyIdentifier { get; set; }
            public System.String DerivationMethodAttributes_Visa_CurrentPinAttributes_CurrentEncryptedPinBlock { get; set; }
            public System.String DerivationMethodAttributes_Visa_CurrentPinAttributes_CurrentPinPekIdentifier { get; set; }
            public Amazon.PaymentCryptographyData.MajorKeyDerivationMode Visa_MajorKeyDerivationMode { get; set; }
            public System.String Visa_PanSequenceNumber { get; set; }
            public System.String Visa_PrimaryAccountNumber { get; set; }
            public System.String MessageData { get; set; }
            public System.String NewEncryptedPinBlock { get; set; }
            public System.String NewPinPekIdentifier { get; set; }
            public Amazon.PaymentCryptographyData.PinBlockFormatForEmvPinChange PinBlockFormat { get; set; }
            public System.String SecureMessagingConfidentialityKeyIdentifier { get; set; }
            public System.String SecureMessagingIntegrityKeyIdentifier { get; set; }
            public System.Func<Amazon.PaymentCryptographyData.Model.GenerateMacEmvPinChangeResponse, NewPAYCDMacEmvPinChangeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
