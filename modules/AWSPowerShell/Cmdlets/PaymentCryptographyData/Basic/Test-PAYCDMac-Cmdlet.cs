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
    /// Verifies a Message Authentication Code (MAC). 
    /// 
    ///  
    /// <para>
    /// You can use this operation to verify MAC for message data authentication such as .
    /// In this operation, you must use the same message data, secret encryption key and MAC
    /// algorithm that was used to generate MAC. You can use this operation to verify a DUPKT,
    /// CMAC, HMAC or EMV MAC by setting generation attributes and algorithm to the associated
    /// values. 
    /// </para><para>
    /// For information about valid keys for this operation, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/keys-validattributes.html">Understanding
    /// key attributes</a> and <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/crypto-ops-validkeys-ops.html">Key
    /// types for specific data operations</a> in the <i>Amazon Web Services Payment Cryptography
    /// User Guide</i>. 
    /// </para><para><b>Cross-account use</b>: This operation can't be used across different Amazon Web
    /// Services accounts.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>GenerateMac</a></para></li></ul>
    /// </summary>
    [Cmdlet("Test", "PAYCDMac")]
    [OutputType("Amazon.PaymentCryptographyData.Model.VerifyMacResponse")]
    [AWSCmdlet("Calls the Payment Cryptography Data VerifyMac API operation.", Operation = new[] {"VerifyMac"}, SelectReturnType = typeof(Amazon.PaymentCryptographyData.Model.VerifyMacResponse))]
    [AWSCmdletOutput("Amazon.PaymentCryptographyData.Model.VerifyMacResponse",
        "This cmdlet returns an Amazon.PaymentCryptographyData.Model.VerifyMacResponse object containing multiple properties."
    )]
    public partial class TestPAYCDMacCmdlet : AmazonPaymentCryptographyDataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter VerificationAttributes_Algorithm
        /// <summary>
        /// <para>
        /// <para>The encryption algorithm for MAC generation or verification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.MacAlgorithm")]
        public Amazon.PaymentCryptographyData.MacAlgorithm VerificationAttributes_Algorithm { get; set; }
        #endregion
        
        #region Parameter SessionKeyDerivationValue_ApplicationCryptogram
        /// <summary>
        /// <para>
        /// <para>The cryptogram provided by the terminal during transaction processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_EmvMac_SessionKeyDerivationValue_ApplicationCryptogram")]
        public System.String SessionKeyDerivationValue_ApplicationCryptogram { get; set; }
        #endregion
        
        #region Parameter SessionKeyDerivationValue_ApplicationTransactionCounter
        /// <summary>
        /// <para>
        /// <para>The transaction counter that is provided by the terminal during transaction processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_EmvMac_SessionKeyDerivationValue_ApplicationTransactionCounter")]
        public System.String SessionKeyDerivationValue_ApplicationTransactionCounter { get; set; }
        #endregion
        
        #region Parameter DukptCmac_DukptDerivationType
        /// <summary>
        /// <para>
        /// <para>The key type derived using DUKPT from a Base Derivation Key (BDK) and Key Serial Number
        /// (KSN). This must be less than or equal to the strength of the BDK. For example, you
        /// can't use <c>AES_128</c> as a derivation type for a BDK of <c>AES_128</c> or <c>TDES_2KEY</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_DukptCmac_DukptDerivationType")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.DukptDerivationType")]
        public Amazon.PaymentCryptographyData.DukptDerivationType DukptCmac_DukptDerivationType { get; set; }
        #endregion
        
        #region Parameter DukptIso9797Algorithm1_DukptDerivationType
        /// <summary>
        /// <para>
        /// <para>The key type derived using DUKPT from a Base Derivation Key (BDK) and Key Serial Number
        /// (KSN). This must be less than or equal to the strength of the BDK. For example, you
        /// can't use <c>AES_128</c> as a derivation type for a BDK of <c>AES_128</c> or <c>TDES_2KEY</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_DukptIso9797Algorithm1_DukptDerivationType")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.DukptDerivationType")]
        public Amazon.PaymentCryptographyData.DukptDerivationType DukptIso9797Algorithm1_DukptDerivationType { get; set; }
        #endregion
        
        #region Parameter DukptIso9797Algorithm3_DukptDerivationType
        /// <summary>
        /// <para>
        /// <para>The key type derived using DUKPT from a Base Derivation Key (BDK) and Key Serial Number
        /// (KSN). This must be less than or equal to the strength of the BDK. For example, you
        /// can't use <c>AES_128</c> as a derivation type for a BDK of <c>AES_128</c> or <c>TDES_2KEY</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_DukptIso9797Algorithm3_DukptDerivationType")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.DukptDerivationType")]
        public Amazon.PaymentCryptographyData.DukptDerivationType DukptIso9797Algorithm3_DukptDerivationType { get; set; }
        #endregion
        
        #region Parameter DukptCmac_DukptKeyVariant
        /// <summary>
        /// <para>
        /// <para>The type of use of DUKPT, which can be MAC generation, MAC verification, or both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_DukptCmac_DukptKeyVariant")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.DukptKeyVariant")]
        public Amazon.PaymentCryptographyData.DukptKeyVariant DukptCmac_DukptKeyVariant { get; set; }
        #endregion
        
        #region Parameter DukptIso9797Algorithm1_DukptKeyVariant
        /// <summary>
        /// <para>
        /// <para>The type of use of DUKPT, which can be MAC generation, MAC verification, or both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_DukptIso9797Algorithm1_DukptKeyVariant")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.DukptKeyVariant")]
        public Amazon.PaymentCryptographyData.DukptKeyVariant DukptIso9797Algorithm1_DukptKeyVariant { get; set; }
        #endregion
        
        #region Parameter DukptIso9797Algorithm3_DukptKeyVariant
        /// <summary>
        /// <para>
        /// <para>The type of use of DUKPT, which can be MAC generation, MAC verification, or both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_DukptIso9797Algorithm3_DukptKeyVariant")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.DukptKeyVariant")]
        public Amazon.PaymentCryptographyData.DukptKeyVariant DukptIso9797Algorithm3_DukptKeyVariant { get; set; }
        #endregion
        
        #region Parameter KeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyARN</c> of the encryption key that Amazon Web Services Payment Cryptography
        /// uses to verify MAC data.</para>
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
        
        #region Parameter DukptCmac_KeySerialNumber
        /// <summary>
        /// <para>
        /// <para>The unique identifier known as Key Serial Number (KSN) that comes from an encrypting
        /// device using DUKPT encryption method. The KSN is derived from the encrypting device
        /// unique identifier and an internal transaction counter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_DukptCmac_KeySerialNumber")]
        public System.String DukptCmac_KeySerialNumber { get; set; }
        #endregion
        
        #region Parameter DukptIso9797Algorithm1_KeySerialNumber
        /// <summary>
        /// <para>
        /// <para>The unique identifier known as Key Serial Number (KSN) that comes from an encrypting
        /// device using DUKPT encryption method. The KSN is derived from the encrypting device
        /// unique identifier and an internal transaction counter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_DukptIso9797Algorithm1_KeySerialNumber")]
        public System.String DukptIso9797Algorithm1_KeySerialNumber { get; set; }
        #endregion
        
        #region Parameter DukptIso9797Algorithm3_KeySerialNumber
        /// <summary>
        /// <para>
        /// <para>The unique identifier known as Key Serial Number (KSN) that comes from an encrypting
        /// device using DUKPT encryption method. The KSN is derived from the encrypting device
        /// unique identifier and an internal transaction counter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_DukptIso9797Algorithm3_KeySerialNumber")]
        public System.String DukptIso9797Algorithm3_KeySerialNumber { get; set; }
        #endregion
        
        #region Parameter Mac
        /// <summary>
        /// <para>
        /// <para>The MAC being verified.</para>
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
        public System.String Mac { get; set; }
        #endregion
        
        #region Parameter MacLength
        /// <summary>
        /// <para>
        /// <para>The length of the MAC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MacLength { get; set; }
        #endregion
        
        #region Parameter EmvMac_MajorKeyDerivationMode
        /// <summary>
        /// <para>
        /// <para>The method to use when deriving the master key for EMV MAC generation or verification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_EmvMac_MajorKeyDerivationMode")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.MajorKeyDerivationMode")]
        public Amazon.PaymentCryptographyData.MajorKeyDerivationMode EmvMac_MajorKeyDerivationMode { get; set; }
        #endregion
        
        #region Parameter MessageData
        /// <summary>
        /// <para>
        /// <para>The data on for which MAC is under verification. This value must be hexBinary.</para>
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
        
        #region Parameter EmvMac_PanSequenceNumber
        /// <summary>
        /// <para>
        /// <para>A number that identifies and differentiates payment cards with the same Primary Account
        /// Number (PAN).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_EmvMac_PanSequenceNumber")]
        public System.String EmvMac_PanSequenceNumber { get; set; }
        #endregion
        
        #region Parameter EmvMac_PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN), a unique identifier for a payment credit or debit
        /// card and associates the card to a specific account holder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_EmvMac_PrimaryAccountNumber")]
        public System.String EmvMac_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter EmvMac_SessionKeyDerivationMode
        /// <summary>
        /// <para>
        /// <para>The method of deriving a session key for EMV MAC generation or verification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_EmvMac_SessionKeyDerivationMode")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.SessionKeyDerivationMode")]
        public Amazon.PaymentCryptographyData.SessionKeyDerivationMode EmvMac_SessionKeyDerivationMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PaymentCryptographyData.Model.VerifyMacResponse).
        /// Specifying the name of a property of type Amazon.PaymentCryptographyData.Model.VerifyMacResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.PaymentCryptographyData.Model.VerifyMacResponse, TestPAYCDMacCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.KeyIdentifier = this.KeyIdentifier;
            #if MODULAR
            if (this.KeyIdentifier == null && ParameterWasBound(nameof(this.KeyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Mac = this.Mac;
            #if MODULAR
            if (this.Mac == null && ParameterWasBound(nameof(this.Mac)))
            {
                WriteWarning("You are passing $null as a value for parameter Mac which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MacLength = this.MacLength;
            context.MessageData = this.MessageData;
            #if MODULAR
            if (this.MessageData == null && ParameterWasBound(nameof(this.MessageData)))
            {
                WriteWarning("You are passing $null as a value for parameter MessageData which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VerificationAttributes_Algorithm = this.VerificationAttributes_Algorithm;
            context.DukptCmac_DukptDerivationType = this.DukptCmac_DukptDerivationType;
            context.DukptCmac_DukptKeyVariant = this.DukptCmac_DukptKeyVariant;
            context.DukptCmac_KeySerialNumber = this.DukptCmac_KeySerialNumber;
            context.DukptIso9797Algorithm1_DukptDerivationType = this.DukptIso9797Algorithm1_DukptDerivationType;
            context.DukptIso9797Algorithm1_DukptKeyVariant = this.DukptIso9797Algorithm1_DukptKeyVariant;
            context.DukptIso9797Algorithm1_KeySerialNumber = this.DukptIso9797Algorithm1_KeySerialNumber;
            context.DukptIso9797Algorithm3_DukptDerivationType = this.DukptIso9797Algorithm3_DukptDerivationType;
            context.DukptIso9797Algorithm3_DukptKeyVariant = this.DukptIso9797Algorithm3_DukptKeyVariant;
            context.DukptIso9797Algorithm3_KeySerialNumber = this.DukptIso9797Algorithm3_KeySerialNumber;
            context.EmvMac_MajorKeyDerivationMode = this.EmvMac_MajorKeyDerivationMode;
            context.EmvMac_PanSequenceNumber = this.EmvMac_PanSequenceNumber;
            context.EmvMac_PrimaryAccountNumber = this.EmvMac_PrimaryAccountNumber;
            context.EmvMac_SessionKeyDerivationMode = this.EmvMac_SessionKeyDerivationMode;
            context.SessionKeyDerivationValue_ApplicationCryptogram = this.SessionKeyDerivationValue_ApplicationCryptogram;
            context.SessionKeyDerivationValue_ApplicationTransactionCounter = this.SessionKeyDerivationValue_ApplicationTransactionCounter;
            
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
            var request = new Amazon.PaymentCryptographyData.Model.VerifyMacRequest();
            
            if (cmdletContext.KeyIdentifier != null)
            {
                request.KeyIdentifier = cmdletContext.KeyIdentifier;
            }
            if (cmdletContext.Mac != null)
            {
                request.Mac = cmdletContext.Mac;
            }
            if (cmdletContext.MacLength != null)
            {
                request.MacLength = cmdletContext.MacLength.Value;
            }
            if (cmdletContext.MessageData != null)
            {
                request.MessageData = cmdletContext.MessageData;
            }
            
             // populate VerificationAttributes
            var requestVerificationAttributesIsNull = true;
            request.VerificationAttributes = new Amazon.PaymentCryptographyData.Model.MacAttributes();
            Amazon.PaymentCryptographyData.MacAlgorithm requestVerificationAttributes_verificationAttributes_Algorithm = null;
            if (cmdletContext.VerificationAttributes_Algorithm != null)
            {
                requestVerificationAttributes_verificationAttributes_Algorithm = cmdletContext.VerificationAttributes_Algorithm;
            }
            if (requestVerificationAttributes_verificationAttributes_Algorithm != null)
            {
                request.VerificationAttributes.Algorithm = requestVerificationAttributes_verificationAttributes_Algorithm;
                requestVerificationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.MacAlgorithmDukpt requestVerificationAttributes_verificationAttributes_DukptCmac = null;
            
             // populate DukptCmac
            var requestVerificationAttributes_verificationAttributes_DukptCmacIsNull = true;
            requestVerificationAttributes_verificationAttributes_DukptCmac = new Amazon.PaymentCryptographyData.Model.MacAlgorithmDukpt();
            Amazon.PaymentCryptographyData.DukptDerivationType requestVerificationAttributes_verificationAttributes_DukptCmac_dukptCmac_DukptDerivationType = null;
            if (cmdletContext.DukptCmac_DukptDerivationType != null)
            {
                requestVerificationAttributes_verificationAttributes_DukptCmac_dukptCmac_DukptDerivationType = cmdletContext.DukptCmac_DukptDerivationType;
            }
            if (requestVerificationAttributes_verificationAttributes_DukptCmac_dukptCmac_DukptDerivationType != null)
            {
                requestVerificationAttributes_verificationAttributes_DukptCmac.DukptDerivationType = requestVerificationAttributes_verificationAttributes_DukptCmac_dukptCmac_DukptDerivationType;
                requestVerificationAttributes_verificationAttributes_DukptCmacIsNull = false;
            }
            Amazon.PaymentCryptographyData.DukptKeyVariant requestVerificationAttributes_verificationAttributes_DukptCmac_dukptCmac_DukptKeyVariant = null;
            if (cmdletContext.DukptCmac_DukptKeyVariant != null)
            {
                requestVerificationAttributes_verificationAttributes_DukptCmac_dukptCmac_DukptKeyVariant = cmdletContext.DukptCmac_DukptKeyVariant;
            }
            if (requestVerificationAttributes_verificationAttributes_DukptCmac_dukptCmac_DukptKeyVariant != null)
            {
                requestVerificationAttributes_verificationAttributes_DukptCmac.DukptKeyVariant = requestVerificationAttributes_verificationAttributes_DukptCmac_dukptCmac_DukptKeyVariant;
                requestVerificationAttributes_verificationAttributes_DukptCmacIsNull = false;
            }
            System.String requestVerificationAttributes_verificationAttributes_DukptCmac_dukptCmac_KeySerialNumber = null;
            if (cmdletContext.DukptCmac_KeySerialNumber != null)
            {
                requestVerificationAttributes_verificationAttributes_DukptCmac_dukptCmac_KeySerialNumber = cmdletContext.DukptCmac_KeySerialNumber;
            }
            if (requestVerificationAttributes_verificationAttributes_DukptCmac_dukptCmac_KeySerialNumber != null)
            {
                requestVerificationAttributes_verificationAttributes_DukptCmac.KeySerialNumber = requestVerificationAttributes_verificationAttributes_DukptCmac_dukptCmac_KeySerialNumber;
                requestVerificationAttributes_verificationAttributes_DukptCmacIsNull = false;
            }
             // determine if requestVerificationAttributes_verificationAttributes_DukptCmac should be set to null
            if (requestVerificationAttributes_verificationAttributes_DukptCmacIsNull)
            {
                requestVerificationAttributes_verificationAttributes_DukptCmac = null;
            }
            if (requestVerificationAttributes_verificationAttributes_DukptCmac != null)
            {
                request.VerificationAttributes.DukptCmac = requestVerificationAttributes_verificationAttributes_DukptCmac;
                requestVerificationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.MacAlgorithmDukpt requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1 = null;
            
             // populate DukptIso9797Algorithm1
            var requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1IsNull = true;
            requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1 = new Amazon.PaymentCryptographyData.Model.MacAlgorithmDukpt();
            Amazon.PaymentCryptographyData.DukptDerivationType requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_DukptDerivationType = null;
            if (cmdletContext.DukptIso9797Algorithm1_DukptDerivationType != null)
            {
                requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_DukptDerivationType = cmdletContext.DukptIso9797Algorithm1_DukptDerivationType;
            }
            if (requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_DukptDerivationType != null)
            {
                requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1.DukptDerivationType = requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_DukptDerivationType;
                requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1IsNull = false;
            }
            Amazon.PaymentCryptographyData.DukptKeyVariant requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_DukptKeyVariant = null;
            if (cmdletContext.DukptIso9797Algorithm1_DukptKeyVariant != null)
            {
                requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_DukptKeyVariant = cmdletContext.DukptIso9797Algorithm1_DukptKeyVariant;
            }
            if (requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_DukptKeyVariant != null)
            {
                requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1.DukptKeyVariant = requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_DukptKeyVariant;
                requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1IsNull = false;
            }
            System.String requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_KeySerialNumber = null;
            if (cmdletContext.DukptIso9797Algorithm1_KeySerialNumber != null)
            {
                requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_KeySerialNumber = cmdletContext.DukptIso9797Algorithm1_KeySerialNumber;
            }
            if (requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_KeySerialNumber != null)
            {
                requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1.KeySerialNumber = requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_KeySerialNumber;
                requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1IsNull = false;
            }
             // determine if requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1 should be set to null
            if (requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1IsNull)
            {
                requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1 = null;
            }
            if (requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1 != null)
            {
                request.VerificationAttributes.DukptIso9797Algorithm1 = requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm1;
                requestVerificationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.MacAlgorithmDukpt requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3 = null;
            
             // populate DukptIso9797Algorithm3
            var requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3IsNull = true;
            requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3 = new Amazon.PaymentCryptographyData.Model.MacAlgorithmDukpt();
            Amazon.PaymentCryptographyData.DukptDerivationType requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_DukptDerivationType = null;
            if (cmdletContext.DukptIso9797Algorithm3_DukptDerivationType != null)
            {
                requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_DukptDerivationType = cmdletContext.DukptIso9797Algorithm3_DukptDerivationType;
            }
            if (requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_DukptDerivationType != null)
            {
                requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3.DukptDerivationType = requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_DukptDerivationType;
                requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3IsNull = false;
            }
            Amazon.PaymentCryptographyData.DukptKeyVariant requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_DukptKeyVariant = null;
            if (cmdletContext.DukptIso9797Algorithm3_DukptKeyVariant != null)
            {
                requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_DukptKeyVariant = cmdletContext.DukptIso9797Algorithm3_DukptKeyVariant;
            }
            if (requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_DukptKeyVariant != null)
            {
                requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3.DukptKeyVariant = requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_DukptKeyVariant;
                requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3IsNull = false;
            }
            System.String requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_KeySerialNumber = null;
            if (cmdletContext.DukptIso9797Algorithm3_KeySerialNumber != null)
            {
                requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_KeySerialNumber = cmdletContext.DukptIso9797Algorithm3_KeySerialNumber;
            }
            if (requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_KeySerialNumber != null)
            {
                requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3.KeySerialNumber = requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_KeySerialNumber;
                requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3IsNull = false;
            }
             // determine if requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3 should be set to null
            if (requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3IsNull)
            {
                requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3 = null;
            }
            if (requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3 != null)
            {
                request.VerificationAttributes.DukptIso9797Algorithm3 = requestVerificationAttributes_verificationAttributes_DukptIso9797Algorithm3;
                requestVerificationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.MacAlgorithmEmv requestVerificationAttributes_verificationAttributes_EmvMac = null;
            
             // populate EmvMac
            var requestVerificationAttributes_verificationAttributes_EmvMacIsNull = true;
            requestVerificationAttributes_verificationAttributes_EmvMac = new Amazon.PaymentCryptographyData.Model.MacAlgorithmEmv();
            Amazon.PaymentCryptographyData.MajorKeyDerivationMode requestVerificationAttributes_verificationAttributes_EmvMac_emvMac_MajorKeyDerivationMode = null;
            if (cmdletContext.EmvMac_MajorKeyDerivationMode != null)
            {
                requestVerificationAttributes_verificationAttributes_EmvMac_emvMac_MajorKeyDerivationMode = cmdletContext.EmvMac_MajorKeyDerivationMode;
            }
            if (requestVerificationAttributes_verificationAttributes_EmvMac_emvMac_MajorKeyDerivationMode != null)
            {
                requestVerificationAttributes_verificationAttributes_EmvMac.MajorKeyDerivationMode = requestVerificationAttributes_verificationAttributes_EmvMac_emvMac_MajorKeyDerivationMode;
                requestVerificationAttributes_verificationAttributes_EmvMacIsNull = false;
            }
            System.String requestVerificationAttributes_verificationAttributes_EmvMac_emvMac_PanSequenceNumber = null;
            if (cmdletContext.EmvMac_PanSequenceNumber != null)
            {
                requestVerificationAttributes_verificationAttributes_EmvMac_emvMac_PanSequenceNumber = cmdletContext.EmvMac_PanSequenceNumber;
            }
            if (requestVerificationAttributes_verificationAttributes_EmvMac_emvMac_PanSequenceNumber != null)
            {
                requestVerificationAttributes_verificationAttributes_EmvMac.PanSequenceNumber = requestVerificationAttributes_verificationAttributes_EmvMac_emvMac_PanSequenceNumber;
                requestVerificationAttributes_verificationAttributes_EmvMacIsNull = false;
            }
            System.String requestVerificationAttributes_verificationAttributes_EmvMac_emvMac_PrimaryAccountNumber = null;
            if (cmdletContext.EmvMac_PrimaryAccountNumber != null)
            {
                requestVerificationAttributes_verificationAttributes_EmvMac_emvMac_PrimaryAccountNumber = cmdletContext.EmvMac_PrimaryAccountNumber;
            }
            if (requestVerificationAttributes_verificationAttributes_EmvMac_emvMac_PrimaryAccountNumber != null)
            {
                requestVerificationAttributes_verificationAttributes_EmvMac.PrimaryAccountNumber = requestVerificationAttributes_verificationAttributes_EmvMac_emvMac_PrimaryAccountNumber;
                requestVerificationAttributes_verificationAttributes_EmvMacIsNull = false;
            }
            Amazon.PaymentCryptographyData.SessionKeyDerivationMode requestVerificationAttributes_verificationAttributes_EmvMac_emvMac_SessionKeyDerivationMode = null;
            if (cmdletContext.EmvMac_SessionKeyDerivationMode != null)
            {
                requestVerificationAttributes_verificationAttributes_EmvMac_emvMac_SessionKeyDerivationMode = cmdletContext.EmvMac_SessionKeyDerivationMode;
            }
            if (requestVerificationAttributes_verificationAttributes_EmvMac_emvMac_SessionKeyDerivationMode != null)
            {
                requestVerificationAttributes_verificationAttributes_EmvMac.SessionKeyDerivationMode = requestVerificationAttributes_verificationAttributes_EmvMac_emvMac_SessionKeyDerivationMode;
                requestVerificationAttributes_verificationAttributes_EmvMacIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.SessionKeyDerivationValue requestVerificationAttributes_verificationAttributes_EmvMac_verificationAttributes_EmvMac_SessionKeyDerivationValue = null;
            
             // populate SessionKeyDerivationValue
            var requestVerificationAttributes_verificationAttributes_EmvMac_verificationAttributes_EmvMac_SessionKeyDerivationValueIsNull = true;
            requestVerificationAttributes_verificationAttributes_EmvMac_verificationAttributes_EmvMac_SessionKeyDerivationValue = new Amazon.PaymentCryptographyData.Model.SessionKeyDerivationValue();
            System.String requestVerificationAttributes_verificationAttributes_EmvMac_verificationAttributes_EmvMac_SessionKeyDerivationValue_sessionKeyDerivationValue_ApplicationCryptogram = null;
            if (cmdletContext.SessionKeyDerivationValue_ApplicationCryptogram != null)
            {
                requestVerificationAttributes_verificationAttributes_EmvMac_verificationAttributes_EmvMac_SessionKeyDerivationValue_sessionKeyDerivationValue_ApplicationCryptogram = cmdletContext.SessionKeyDerivationValue_ApplicationCryptogram;
            }
            if (requestVerificationAttributes_verificationAttributes_EmvMac_verificationAttributes_EmvMac_SessionKeyDerivationValue_sessionKeyDerivationValue_ApplicationCryptogram != null)
            {
                requestVerificationAttributes_verificationAttributes_EmvMac_verificationAttributes_EmvMac_SessionKeyDerivationValue.ApplicationCryptogram = requestVerificationAttributes_verificationAttributes_EmvMac_verificationAttributes_EmvMac_SessionKeyDerivationValue_sessionKeyDerivationValue_ApplicationCryptogram;
                requestVerificationAttributes_verificationAttributes_EmvMac_verificationAttributes_EmvMac_SessionKeyDerivationValueIsNull = false;
            }
            System.String requestVerificationAttributes_verificationAttributes_EmvMac_verificationAttributes_EmvMac_SessionKeyDerivationValue_sessionKeyDerivationValue_ApplicationTransactionCounter = null;
            if (cmdletContext.SessionKeyDerivationValue_ApplicationTransactionCounter != null)
            {
                requestVerificationAttributes_verificationAttributes_EmvMac_verificationAttributes_EmvMac_SessionKeyDerivationValue_sessionKeyDerivationValue_ApplicationTransactionCounter = cmdletContext.SessionKeyDerivationValue_ApplicationTransactionCounter;
            }
            if (requestVerificationAttributes_verificationAttributes_EmvMac_verificationAttributes_EmvMac_SessionKeyDerivationValue_sessionKeyDerivationValue_ApplicationTransactionCounter != null)
            {
                requestVerificationAttributes_verificationAttributes_EmvMac_verificationAttributes_EmvMac_SessionKeyDerivationValue.ApplicationTransactionCounter = requestVerificationAttributes_verificationAttributes_EmvMac_verificationAttributes_EmvMac_SessionKeyDerivationValue_sessionKeyDerivationValue_ApplicationTransactionCounter;
                requestVerificationAttributes_verificationAttributes_EmvMac_verificationAttributes_EmvMac_SessionKeyDerivationValueIsNull = false;
            }
             // determine if requestVerificationAttributes_verificationAttributes_EmvMac_verificationAttributes_EmvMac_SessionKeyDerivationValue should be set to null
            if (requestVerificationAttributes_verificationAttributes_EmvMac_verificationAttributes_EmvMac_SessionKeyDerivationValueIsNull)
            {
                requestVerificationAttributes_verificationAttributes_EmvMac_verificationAttributes_EmvMac_SessionKeyDerivationValue = null;
            }
            if (requestVerificationAttributes_verificationAttributes_EmvMac_verificationAttributes_EmvMac_SessionKeyDerivationValue != null)
            {
                requestVerificationAttributes_verificationAttributes_EmvMac.SessionKeyDerivationValue = requestVerificationAttributes_verificationAttributes_EmvMac_verificationAttributes_EmvMac_SessionKeyDerivationValue;
                requestVerificationAttributes_verificationAttributes_EmvMacIsNull = false;
            }
             // determine if requestVerificationAttributes_verificationAttributes_EmvMac should be set to null
            if (requestVerificationAttributes_verificationAttributes_EmvMacIsNull)
            {
                requestVerificationAttributes_verificationAttributes_EmvMac = null;
            }
            if (requestVerificationAttributes_verificationAttributes_EmvMac != null)
            {
                request.VerificationAttributes.EmvMac = requestVerificationAttributes_verificationAttributes_EmvMac;
                requestVerificationAttributesIsNull = false;
            }
             // determine if request.VerificationAttributes should be set to null
            if (requestVerificationAttributesIsNull)
            {
                request.VerificationAttributes = null;
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
        
        private Amazon.PaymentCryptographyData.Model.VerifyMacResponse CallAWSServiceOperation(IAmazonPaymentCryptographyData client, Amazon.PaymentCryptographyData.Model.VerifyMacRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Payment Cryptography Data", "VerifyMac");
            try
            {
                return client.VerifyMacAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String KeyIdentifier { get; set; }
            public System.String Mac { get; set; }
            public System.Int32? MacLength { get; set; }
            public System.String MessageData { get; set; }
            public Amazon.PaymentCryptographyData.MacAlgorithm VerificationAttributes_Algorithm { get; set; }
            public Amazon.PaymentCryptographyData.DukptDerivationType DukptCmac_DukptDerivationType { get; set; }
            public Amazon.PaymentCryptographyData.DukptKeyVariant DukptCmac_DukptKeyVariant { get; set; }
            public System.String DukptCmac_KeySerialNumber { get; set; }
            public Amazon.PaymentCryptographyData.DukptDerivationType DukptIso9797Algorithm1_DukptDerivationType { get; set; }
            public Amazon.PaymentCryptographyData.DukptKeyVariant DukptIso9797Algorithm1_DukptKeyVariant { get; set; }
            public System.String DukptIso9797Algorithm1_KeySerialNumber { get; set; }
            public Amazon.PaymentCryptographyData.DukptDerivationType DukptIso9797Algorithm3_DukptDerivationType { get; set; }
            public Amazon.PaymentCryptographyData.DukptKeyVariant DukptIso9797Algorithm3_DukptKeyVariant { get; set; }
            public System.String DukptIso9797Algorithm3_KeySerialNumber { get; set; }
            public Amazon.PaymentCryptographyData.MajorKeyDerivationMode EmvMac_MajorKeyDerivationMode { get; set; }
            public System.String EmvMac_PanSequenceNumber { get; set; }
            public System.String EmvMac_PrimaryAccountNumber { get; set; }
            public Amazon.PaymentCryptographyData.SessionKeyDerivationMode EmvMac_SessionKeyDerivationMode { get; set; }
            public System.String SessionKeyDerivationValue_ApplicationCryptogram { get; set; }
            public System.String SessionKeyDerivationValue_ApplicationTransactionCounter { get; set; }
            public System.Func<Amazon.PaymentCryptographyData.Model.VerifyMacResponse, TestPAYCDMacCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
