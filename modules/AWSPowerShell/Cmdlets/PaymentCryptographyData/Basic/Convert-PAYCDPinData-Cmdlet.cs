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
    /// Translates encrypted PIN block from and to ISO 9564 formats 0,1,3,4. For more information,
    /// see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/translate-pin-data.html">Translate
    /// PIN data</a> in the <i>Amazon Web Services Payment Cryptography User Guide</i>.
    /// 
    ///  
    /// <para>
    /// PIN block translation involves changing the encrytion of PIN block from one encryption
    /// key to another encryption key and changing PIN block format from one to another without
    /// PIN block data leaving Amazon Web Services Payment Cryptography. The encryption key
    /// transformation can be from PEK (Pin Encryption Key) to BDK (Base Derivation Key) for
    /// DUKPT or from BDK for DUKPT to PEK. Amazon Web Services Payment Cryptography supports
    /// <c>TDES</c> and <c>AES</c> key derivation type for DUKPT translations. 
    /// </para><para>
    /// The allowed combinations of PIN block format translations are guided by PCI. It is
    /// important to note that not all encrypted PIN block formats (example, format 1) require
    /// PAN (Primary Account Number) as input. And as such, PIN block format that requires
    /// PAN (example, formats 0,3,4) cannot be translated to a format (format 1) that does
    /// not require a PAN for generation. 
    /// </para><para>
    /// For information about valid keys for this operation, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/keys-validattributes.html">Understanding
    /// key attributes</a> and <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/crypto-ops-validkeys-ops.html">Key
    /// types for specific data operations</a> in the <i>Amazon Web Services Payment Cryptography
    /// User Guide</i>.
    /// </para><note><para>
    /// Amazon Web Services Payment Cryptography currently supports ISO PIN block 4 translation
    /// for PIN block built using legacy PAN length. That is, PAN is the right most 12 digits
    /// excluding the check digits.
    /// </para></note><para><b>Cross-account use</b>: This operation can't be used across different Amazon Web
    /// Services accounts.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>GeneratePinData</a></para></li><li><para><a>VerifyPinData</a></para></li></ul>
    /// </summary>
    [Cmdlet("Convert", "PAYCDPinData", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PaymentCryptographyData.Model.TranslatePinDataResponse")]
    [AWSCmdlet("Calls the Payment Cryptography Data TranslatePinData API operation.", Operation = new[] {"TranslatePinData"}, SelectReturnType = typeof(Amazon.PaymentCryptographyData.Model.TranslatePinDataResponse))]
    [AWSCmdletOutput("Amazon.PaymentCryptographyData.Model.TranslatePinDataResponse",
        "This cmdlet returns an Amazon.PaymentCryptographyData.Model.TranslatePinDataResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ConvertPAYCDPinDataCmdlet : AmazonPaymentCryptographyDataClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IncomingDukptAttributes_DukptKeyDerivationType
        /// <summary>
        /// <para>
        /// <para>The key type derived using DUKPT from a Base Derivation Key (BDK) and Key Serial Number
        /// (KSN). This must be less than or equal to the strength of the BDK. For example, you
        /// can't use <c>AES_128</c> as a derivation type for a BDK of <c>AES_128</c> or <c>TDES_2KEY</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.DukptDerivationType")]
        public Amazon.PaymentCryptographyData.DukptDerivationType IncomingDukptAttributes_DukptKeyDerivationType { get; set; }
        #endregion
        
        #region Parameter OutgoingDukptAttributes_DukptKeyDerivationType
        /// <summary>
        /// <para>
        /// <para>The key type derived using DUKPT from a Base Derivation Key (BDK) and Key Serial Number
        /// (KSN). This must be less than or equal to the strength of the BDK. For example, you
        /// can't use <c>AES_128</c> as a derivation type for a BDK of <c>AES_128</c> or <c>TDES_2KEY</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.DukptDerivationType")]
        public Amazon.PaymentCryptographyData.DukptDerivationType OutgoingDukptAttributes_DukptKeyDerivationType { get; set; }
        #endregion
        
        #region Parameter IncomingDukptAttributes_DukptKeyVariant
        /// <summary>
        /// <para>
        /// <para>The type of use of DUKPT, which can be for incoming data decryption, outgoing data
        /// encryption, or both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.DukptKeyVariant")]
        public Amazon.PaymentCryptographyData.DukptKeyVariant IncomingDukptAttributes_DukptKeyVariant { get; set; }
        #endregion
        
        #region Parameter OutgoingDukptAttributes_DukptKeyVariant
        /// <summary>
        /// <para>
        /// <para>The type of use of DUKPT, which can be for incoming data decryption, outgoing data
        /// encryption, or both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.DukptKeyVariant")]
        public Amazon.PaymentCryptographyData.DukptKeyVariant OutgoingDukptAttributes_DukptKeyVariant { get; set; }
        #endregion
        
        #region Parameter EncryptedPinBlock
        /// <summary>
        /// <para>
        /// <para>The encrypted PIN block data that Amazon Web Services Payment Cryptography translates.</para>
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
        
        #region Parameter IncomingKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyARN</c> of the encryption key under which incoming PIN block data is encrypted.
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
        public System.String IncomingKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter IncomingTranslationAttributes_IsoFormat1
        /// <summary>
        /// <para>
        /// <para>Parameters that are required for ISO9564 PIN format 1 tranlation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.PaymentCryptographyData.Model.TranslationPinDataIsoFormat1 IncomingTranslationAttributes_IsoFormat1 { get; set; }
        #endregion
        
        #region Parameter OutgoingTranslationAttributes_IsoFormat1
        /// <summary>
        /// <para>
        /// <para>Parameters that are required for ISO9564 PIN format 1 tranlation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.PaymentCryptographyData.Model.TranslationPinDataIsoFormat1 OutgoingTranslationAttributes_IsoFormat1 { get; set; }
        #endregion
        
        #region Parameter IncomingDukptAttributes_KeySerialNumber
        /// <summary>
        /// <para>
        /// <para>The unique identifier known as Key Serial Number (KSN) that comes from an encrypting
        /// device using DUKPT encryption method. The KSN is derived from the encrypting device
        /// unique identifier and an internal transaction counter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IncomingDukptAttributes_KeySerialNumber { get; set; }
        #endregion
        
        #region Parameter OutgoingDukptAttributes_KeySerialNumber
        /// <summary>
        /// <para>
        /// <para>The unique identifier known as Key Serial Number (KSN) that comes from an encrypting
        /// device using DUKPT encryption method. The KSN is derived from the encrypting device
        /// unique identifier and an internal transaction counter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutgoingDukptAttributes_KeySerialNumber { get; set; }
        #endregion
        
        #region Parameter OutgoingKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyARN</c> of the encryption key for encrypting outgoing PIN block data. This
        /// key type can be PEK or BDK.</para>
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
        public System.String OutgoingKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter IncomingTranslationAttributes_IsoFormat0_PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN) of the cardholder. A PAN is a unique identifier for
        /// a payment credit or debit card and associates the card to a specific account holder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IncomingTranslationAttributes_IsoFormat0_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter IncomingTranslationAttributes_IsoFormat3_PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN) of the cardholder. A PAN is a unique identifier for
        /// a payment credit or debit card and associates the card to a specific account holder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IncomingTranslationAttributes_IsoFormat3_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter IncomingTranslationAttributes_IsoFormat4_PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN) of the cardholder. A PAN is a unique identifier for
        /// a payment credit or debit card and associates the card to a specific account holder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IncomingTranslationAttributes_IsoFormat4_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter OutgoingTranslationAttributes_IsoFormat0_PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN) of the cardholder. A PAN is a unique identifier for
        /// a payment credit or debit card and associates the card to a specific account holder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutgoingTranslationAttributes_IsoFormat0_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter OutgoingTranslationAttributes_IsoFormat3_PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN) of the cardholder. A PAN is a unique identifier for
        /// a payment credit or debit card and associates the card to a specific account holder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutgoingTranslationAttributes_IsoFormat3_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter OutgoingTranslationAttributes_IsoFormat4_PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN) of the cardholder. A PAN is a unique identifier for
        /// a payment credit or debit card and associates the card to a specific account holder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutgoingTranslationAttributes_IsoFormat4_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PaymentCryptographyData.Model.TranslatePinDataResponse).
        /// Specifying the name of a property of type Amazon.PaymentCryptographyData.Model.TranslatePinDataResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Convert-PAYCDPinData (TranslatePinData)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PaymentCryptographyData.Model.TranslatePinDataResponse, ConvertPAYCDPinDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EncryptedPinBlock = this.EncryptedPinBlock;
            #if MODULAR
            if (this.EncryptedPinBlock == null && ParameterWasBound(nameof(this.EncryptedPinBlock)))
            {
                WriteWarning("You are passing $null as a value for parameter EncryptedPinBlock which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IncomingDukptAttributes_DukptKeyDerivationType = this.IncomingDukptAttributes_DukptKeyDerivationType;
            context.IncomingDukptAttributes_DukptKeyVariant = this.IncomingDukptAttributes_DukptKeyVariant;
            context.IncomingDukptAttributes_KeySerialNumber = this.IncomingDukptAttributes_KeySerialNumber;
            context.IncomingKeyIdentifier = this.IncomingKeyIdentifier;
            #if MODULAR
            if (this.IncomingKeyIdentifier == null && ParameterWasBound(nameof(this.IncomingKeyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter IncomingKeyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IncomingTranslationAttributes_IsoFormat0_PrimaryAccountNumber = this.IncomingTranslationAttributes_IsoFormat0_PrimaryAccountNumber;
            context.IncomingTranslationAttributes_IsoFormat1 = this.IncomingTranslationAttributes_IsoFormat1;
            context.IncomingTranslationAttributes_IsoFormat3_PrimaryAccountNumber = this.IncomingTranslationAttributes_IsoFormat3_PrimaryAccountNumber;
            context.IncomingTranslationAttributes_IsoFormat4_PrimaryAccountNumber = this.IncomingTranslationAttributes_IsoFormat4_PrimaryAccountNumber;
            context.OutgoingDukptAttributes_DukptKeyDerivationType = this.OutgoingDukptAttributes_DukptKeyDerivationType;
            context.OutgoingDukptAttributes_DukptKeyVariant = this.OutgoingDukptAttributes_DukptKeyVariant;
            context.OutgoingDukptAttributes_KeySerialNumber = this.OutgoingDukptAttributes_KeySerialNumber;
            context.OutgoingKeyIdentifier = this.OutgoingKeyIdentifier;
            #if MODULAR
            if (this.OutgoingKeyIdentifier == null && ParameterWasBound(nameof(this.OutgoingKeyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter OutgoingKeyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutgoingTranslationAttributes_IsoFormat0_PrimaryAccountNumber = this.OutgoingTranslationAttributes_IsoFormat0_PrimaryAccountNumber;
            context.OutgoingTranslationAttributes_IsoFormat1 = this.OutgoingTranslationAttributes_IsoFormat1;
            context.OutgoingTranslationAttributes_IsoFormat3_PrimaryAccountNumber = this.OutgoingTranslationAttributes_IsoFormat3_PrimaryAccountNumber;
            context.OutgoingTranslationAttributes_IsoFormat4_PrimaryAccountNumber = this.OutgoingTranslationAttributes_IsoFormat4_PrimaryAccountNumber;
            
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
            var request = new Amazon.PaymentCryptographyData.Model.TranslatePinDataRequest();
            
            if (cmdletContext.EncryptedPinBlock != null)
            {
                request.EncryptedPinBlock = cmdletContext.EncryptedPinBlock;
            }
            
             // populate IncomingDukptAttributes
            var requestIncomingDukptAttributesIsNull = true;
            request.IncomingDukptAttributes = new Amazon.PaymentCryptographyData.Model.DukptDerivationAttributes();
            Amazon.PaymentCryptographyData.DukptDerivationType requestIncomingDukptAttributes_incomingDukptAttributes_DukptKeyDerivationType = null;
            if (cmdletContext.IncomingDukptAttributes_DukptKeyDerivationType != null)
            {
                requestIncomingDukptAttributes_incomingDukptAttributes_DukptKeyDerivationType = cmdletContext.IncomingDukptAttributes_DukptKeyDerivationType;
            }
            if (requestIncomingDukptAttributes_incomingDukptAttributes_DukptKeyDerivationType != null)
            {
                request.IncomingDukptAttributes.DukptKeyDerivationType = requestIncomingDukptAttributes_incomingDukptAttributes_DukptKeyDerivationType;
                requestIncomingDukptAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.DukptKeyVariant requestIncomingDukptAttributes_incomingDukptAttributes_DukptKeyVariant = null;
            if (cmdletContext.IncomingDukptAttributes_DukptKeyVariant != null)
            {
                requestIncomingDukptAttributes_incomingDukptAttributes_DukptKeyVariant = cmdletContext.IncomingDukptAttributes_DukptKeyVariant;
            }
            if (requestIncomingDukptAttributes_incomingDukptAttributes_DukptKeyVariant != null)
            {
                request.IncomingDukptAttributes.DukptKeyVariant = requestIncomingDukptAttributes_incomingDukptAttributes_DukptKeyVariant;
                requestIncomingDukptAttributesIsNull = false;
            }
            System.String requestIncomingDukptAttributes_incomingDukptAttributes_KeySerialNumber = null;
            if (cmdletContext.IncomingDukptAttributes_KeySerialNumber != null)
            {
                requestIncomingDukptAttributes_incomingDukptAttributes_KeySerialNumber = cmdletContext.IncomingDukptAttributes_KeySerialNumber;
            }
            if (requestIncomingDukptAttributes_incomingDukptAttributes_KeySerialNumber != null)
            {
                request.IncomingDukptAttributes.KeySerialNumber = requestIncomingDukptAttributes_incomingDukptAttributes_KeySerialNumber;
                requestIncomingDukptAttributesIsNull = false;
            }
             // determine if request.IncomingDukptAttributes should be set to null
            if (requestIncomingDukptAttributesIsNull)
            {
                request.IncomingDukptAttributes = null;
            }
            if (cmdletContext.IncomingKeyIdentifier != null)
            {
                request.IncomingKeyIdentifier = cmdletContext.IncomingKeyIdentifier;
            }
            
             // populate IncomingTranslationAttributes
            var requestIncomingTranslationAttributesIsNull = true;
            request.IncomingTranslationAttributes = new Amazon.PaymentCryptographyData.Model.TranslationIsoFormats();
            Amazon.PaymentCryptographyData.Model.TranslationPinDataIsoFormat1 requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat1 = null;
            if (cmdletContext.IncomingTranslationAttributes_IsoFormat1 != null)
            {
                requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat1 = cmdletContext.IncomingTranslationAttributes_IsoFormat1;
            }
            if (requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat1 != null)
            {
                request.IncomingTranslationAttributes.IsoFormat1 = requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat1;
                requestIncomingTranslationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.TranslationPinDataIsoFormat034 requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat0 = null;
            
             // populate IsoFormat0
            var requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat0IsNull = true;
            requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat0 = new Amazon.PaymentCryptographyData.Model.TranslationPinDataIsoFormat034();
            System.String requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat0_incomingTranslationAttributes_IsoFormat0_PrimaryAccountNumber = null;
            if (cmdletContext.IncomingTranslationAttributes_IsoFormat0_PrimaryAccountNumber != null)
            {
                requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat0_incomingTranslationAttributes_IsoFormat0_PrimaryAccountNumber = cmdletContext.IncomingTranslationAttributes_IsoFormat0_PrimaryAccountNumber;
            }
            if (requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat0_incomingTranslationAttributes_IsoFormat0_PrimaryAccountNumber != null)
            {
                requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat0.PrimaryAccountNumber = requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat0_incomingTranslationAttributes_IsoFormat0_PrimaryAccountNumber;
                requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat0IsNull = false;
            }
             // determine if requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat0 should be set to null
            if (requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat0IsNull)
            {
                requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat0 = null;
            }
            if (requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat0 != null)
            {
                request.IncomingTranslationAttributes.IsoFormat0 = requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat0;
                requestIncomingTranslationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.TranslationPinDataIsoFormat034 requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat3 = null;
            
             // populate IsoFormat3
            var requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat3IsNull = true;
            requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat3 = new Amazon.PaymentCryptographyData.Model.TranslationPinDataIsoFormat034();
            System.String requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat3_incomingTranslationAttributes_IsoFormat3_PrimaryAccountNumber = null;
            if (cmdletContext.IncomingTranslationAttributes_IsoFormat3_PrimaryAccountNumber != null)
            {
                requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat3_incomingTranslationAttributes_IsoFormat3_PrimaryAccountNumber = cmdletContext.IncomingTranslationAttributes_IsoFormat3_PrimaryAccountNumber;
            }
            if (requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat3_incomingTranslationAttributes_IsoFormat3_PrimaryAccountNumber != null)
            {
                requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat3.PrimaryAccountNumber = requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat3_incomingTranslationAttributes_IsoFormat3_PrimaryAccountNumber;
                requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat3IsNull = false;
            }
             // determine if requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat3 should be set to null
            if (requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat3IsNull)
            {
                requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat3 = null;
            }
            if (requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat3 != null)
            {
                request.IncomingTranslationAttributes.IsoFormat3 = requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat3;
                requestIncomingTranslationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.TranslationPinDataIsoFormat034 requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat4 = null;
            
             // populate IsoFormat4
            var requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat4IsNull = true;
            requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat4 = new Amazon.PaymentCryptographyData.Model.TranslationPinDataIsoFormat034();
            System.String requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat4_incomingTranslationAttributes_IsoFormat4_PrimaryAccountNumber = null;
            if (cmdletContext.IncomingTranslationAttributes_IsoFormat4_PrimaryAccountNumber != null)
            {
                requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat4_incomingTranslationAttributes_IsoFormat4_PrimaryAccountNumber = cmdletContext.IncomingTranslationAttributes_IsoFormat4_PrimaryAccountNumber;
            }
            if (requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat4_incomingTranslationAttributes_IsoFormat4_PrimaryAccountNumber != null)
            {
                requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat4.PrimaryAccountNumber = requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat4_incomingTranslationAttributes_IsoFormat4_PrimaryAccountNumber;
                requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat4IsNull = false;
            }
             // determine if requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat4 should be set to null
            if (requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat4IsNull)
            {
                requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat4 = null;
            }
            if (requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat4 != null)
            {
                request.IncomingTranslationAttributes.IsoFormat4 = requestIncomingTranslationAttributes_incomingTranslationAttributes_IsoFormat4;
                requestIncomingTranslationAttributesIsNull = false;
            }
             // determine if request.IncomingTranslationAttributes should be set to null
            if (requestIncomingTranslationAttributesIsNull)
            {
                request.IncomingTranslationAttributes = null;
            }
            
             // populate OutgoingDukptAttributes
            var requestOutgoingDukptAttributesIsNull = true;
            request.OutgoingDukptAttributes = new Amazon.PaymentCryptographyData.Model.DukptDerivationAttributes();
            Amazon.PaymentCryptographyData.DukptDerivationType requestOutgoingDukptAttributes_outgoingDukptAttributes_DukptKeyDerivationType = null;
            if (cmdletContext.OutgoingDukptAttributes_DukptKeyDerivationType != null)
            {
                requestOutgoingDukptAttributes_outgoingDukptAttributes_DukptKeyDerivationType = cmdletContext.OutgoingDukptAttributes_DukptKeyDerivationType;
            }
            if (requestOutgoingDukptAttributes_outgoingDukptAttributes_DukptKeyDerivationType != null)
            {
                request.OutgoingDukptAttributes.DukptKeyDerivationType = requestOutgoingDukptAttributes_outgoingDukptAttributes_DukptKeyDerivationType;
                requestOutgoingDukptAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.DukptKeyVariant requestOutgoingDukptAttributes_outgoingDukptAttributes_DukptKeyVariant = null;
            if (cmdletContext.OutgoingDukptAttributes_DukptKeyVariant != null)
            {
                requestOutgoingDukptAttributes_outgoingDukptAttributes_DukptKeyVariant = cmdletContext.OutgoingDukptAttributes_DukptKeyVariant;
            }
            if (requestOutgoingDukptAttributes_outgoingDukptAttributes_DukptKeyVariant != null)
            {
                request.OutgoingDukptAttributes.DukptKeyVariant = requestOutgoingDukptAttributes_outgoingDukptAttributes_DukptKeyVariant;
                requestOutgoingDukptAttributesIsNull = false;
            }
            System.String requestOutgoingDukptAttributes_outgoingDukptAttributes_KeySerialNumber = null;
            if (cmdletContext.OutgoingDukptAttributes_KeySerialNumber != null)
            {
                requestOutgoingDukptAttributes_outgoingDukptAttributes_KeySerialNumber = cmdletContext.OutgoingDukptAttributes_KeySerialNumber;
            }
            if (requestOutgoingDukptAttributes_outgoingDukptAttributes_KeySerialNumber != null)
            {
                request.OutgoingDukptAttributes.KeySerialNumber = requestOutgoingDukptAttributes_outgoingDukptAttributes_KeySerialNumber;
                requestOutgoingDukptAttributesIsNull = false;
            }
             // determine if request.OutgoingDukptAttributes should be set to null
            if (requestOutgoingDukptAttributesIsNull)
            {
                request.OutgoingDukptAttributes = null;
            }
            if (cmdletContext.OutgoingKeyIdentifier != null)
            {
                request.OutgoingKeyIdentifier = cmdletContext.OutgoingKeyIdentifier;
            }
            
             // populate OutgoingTranslationAttributes
            var requestOutgoingTranslationAttributesIsNull = true;
            request.OutgoingTranslationAttributes = new Amazon.PaymentCryptographyData.Model.TranslationIsoFormats();
            Amazon.PaymentCryptographyData.Model.TranslationPinDataIsoFormat1 requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat1 = null;
            if (cmdletContext.OutgoingTranslationAttributes_IsoFormat1 != null)
            {
                requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat1 = cmdletContext.OutgoingTranslationAttributes_IsoFormat1;
            }
            if (requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat1 != null)
            {
                request.OutgoingTranslationAttributes.IsoFormat1 = requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat1;
                requestOutgoingTranslationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.TranslationPinDataIsoFormat034 requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat0 = null;
            
             // populate IsoFormat0
            var requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat0IsNull = true;
            requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat0 = new Amazon.PaymentCryptographyData.Model.TranslationPinDataIsoFormat034();
            System.String requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat0_outgoingTranslationAttributes_IsoFormat0_PrimaryAccountNumber = null;
            if (cmdletContext.OutgoingTranslationAttributes_IsoFormat0_PrimaryAccountNumber != null)
            {
                requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat0_outgoingTranslationAttributes_IsoFormat0_PrimaryAccountNumber = cmdletContext.OutgoingTranslationAttributes_IsoFormat0_PrimaryAccountNumber;
            }
            if (requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat0_outgoingTranslationAttributes_IsoFormat0_PrimaryAccountNumber != null)
            {
                requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat0.PrimaryAccountNumber = requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat0_outgoingTranslationAttributes_IsoFormat0_PrimaryAccountNumber;
                requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat0IsNull = false;
            }
             // determine if requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat0 should be set to null
            if (requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat0IsNull)
            {
                requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat0 = null;
            }
            if (requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat0 != null)
            {
                request.OutgoingTranslationAttributes.IsoFormat0 = requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat0;
                requestOutgoingTranslationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.TranslationPinDataIsoFormat034 requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat3 = null;
            
             // populate IsoFormat3
            var requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat3IsNull = true;
            requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat3 = new Amazon.PaymentCryptographyData.Model.TranslationPinDataIsoFormat034();
            System.String requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat3_outgoingTranslationAttributes_IsoFormat3_PrimaryAccountNumber = null;
            if (cmdletContext.OutgoingTranslationAttributes_IsoFormat3_PrimaryAccountNumber != null)
            {
                requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat3_outgoingTranslationAttributes_IsoFormat3_PrimaryAccountNumber = cmdletContext.OutgoingTranslationAttributes_IsoFormat3_PrimaryAccountNumber;
            }
            if (requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat3_outgoingTranslationAttributes_IsoFormat3_PrimaryAccountNumber != null)
            {
                requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat3.PrimaryAccountNumber = requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat3_outgoingTranslationAttributes_IsoFormat3_PrimaryAccountNumber;
                requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat3IsNull = false;
            }
             // determine if requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat3 should be set to null
            if (requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat3IsNull)
            {
                requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat3 = null;
            }
            if (requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat3 != null)
            {
                request.OutgoingTranslationAttributes.IsoFormat3 = requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat3;
                requestOutgoingTranslationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.TranslationPinDataIsoFormat034 requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat4 = null;
            
             // populate IsoFormat4
            var requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat4IsNull = true;
            requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat4 = new Amazon.PaymentCryptographyData.Model.TranslationPinDataIsoFormat034();
            System.String requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat4_outgoingTranslationAttributes_IsoFormat4_PrimaryAccountNumber = null;
            if (cmdletContext.OutgoingTranslationAttributes_IsoFormat4_PrimaryAccountNumber != null)
            {
                requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat4_outgoingTranslationAttributes_IsoFormat4_PrimaryAccountNumber = cmdletContext.OutgoingTranslationAttributes_IsoFormat4_PrimaryAccountNumber;
            }
            if (requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat4_outgoingTranslationAttributes_IsoFormat4_PrimaryAccountNumber != null)
            {
                requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat4.PrimaryAccountNumber = requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat4_outgoingTranslationAttributes_IsoFormat4_PrimaryAccountNumber;
                requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat4IsNull = false;
            }
             // determine if requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat4 should be set to null
            if (requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat4IsNull)
            {
                requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat4 = null;
            }
            if (requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat4 != null)
            {
                request.OutgoingTranslationAttributes.IsoFormat4 = requestOutgoingTranslationAttributes_outgoingTranslationAttributes_IsoFormat4;
                requestOutgoingTranslationAttributesIsNull = false;
            }
             // determine if request.OutgoingTranslationAttributes should be set to null
            if (requestOutgoingTranslationAttributesIsNull)
            {
                request.OutgoingTranslationAttributes = null;
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
        
        private Amazon.PaymentCryptographyData.Model.TranslatePinDataResponse CallAWSServiceOperation(IAmazonPaymentCryptographyData client, Amazon.PaymentCryptographyData.Model.TranslatePinDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Payment Cryptography Data", "TranslatePinData");
            try
            {
                #if DESKTOP
                return client.TranslatePinData(request);
                #elif CORECLR
                return client.TranslatePinDataAsync(request).GetAwaiter().GetResult();
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
            public System.String EncryptedPinBlock { get; set; }
            public Amazon.PaymentCryptographyData.DukptDerivationType IncomingDukptAttributes_DukptKeyDerivationType { get; set; }
            public Amazon.PaymentCryptographyData.DukptKeyVariant IncomingDukptAttributes_DukptKeyVariant { get; set; }
            public System.String IncomingDukptAttributes_KeySerialNumber { get; set; }
            public System.String IncomingKeyIdentifier { get; set; }
            public System.String IncomingTranslationAttributes_IsoFormat0_PrimaryAccountNumber { get; set; }
            public Amazon.PaymentCryptographyData.Model.TranslationPinDataIsoFormat1 IncomingTranslationAttributes_IsoFormat1 { get; set; }
            public System.String IncomingTranslationAttributes_IsoFormat3_PrimaryAccountNumber { get; set; }
            public System.String IncomingTranslationAttributes_IsoFormat4_PrimaryAccountNumber { get; set; }
            public Amazon.PaymentCryptographyData.DukptDerivationType OutgoingDukptAttributes_DukptKeyDerivationType { get; set; }
            public Amazon.PaymentCryptographyData.DukptKeyVariant OutgoingDukptAttributes_DukptKeyVariant { get; set; }
            public System.String OutgoingDukptAttributes_KeySerialNumber { get; set; }
            public System.String OutgoingKeyIdentifier { get; set; }
            public System.String OutgoingTranslationAttributes_IsoFormat0_PrimaryAccountNumber { get; set; }
            public Amazon.PaymentCryptographyData.Model.TranslationPinDataIsoFormat1 OutgoingTranslationAttributes_IsoFormat1 { get; set; }
            public System.String OutgoingTranslationAttributes_IsoFormat3_PrimaryAccountNumber { get; set; }
            public System.String OutgoingTranslationAttributes_IsoFormat4_PrimaryAccountNumber { get; set; }
            public System.Func<Amazon.PaymentCryptographyData.Model.TranslatePinDataResponse, ConvertPAYCDPinDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
