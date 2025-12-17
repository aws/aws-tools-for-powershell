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
    /// Generates a Message Authentication Code (MAC) cryptogram within Amazon Web Services
    /// Payment Cryptography. 
    /// 
    ///  
    /// <para>
    /// You can use this operation to authenticate card-related data by using known data values
    /// to generate MAC for data validation between the sending and receiving parties. This
    /// operation uses message data, a secret encryption key and MAC algorithm to generate
    /// a unique MAC value for transmission. The receiving party of the MAC must use the same
    /// message data, secret encryption key and MAC algorithm to reproduce another MAC value
    /// for comparision.
    /// </para><para>
    /// You can use this operation to generate a DUPKT, CMAC, HMAC or EMV MAC by setting generation
    /// attributes and algorithm to the associated values. The MAC generation encryption key
    /// must have valid values for <c>KeyUsage</c> such as <c>TR31_M7_HMAC_KEY</c> for HMAC
    /// generation, and the key must have <c>KeyModesOfUse</c> set to <c>Generate</c>.
    /// </para><para>
    /// For information about valid keys for this operation, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/keys-validattributes.html">Understanding
    /// key attributes</a> and <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/crypto-ops-validkeys-ops.html">Key
    /// types for specific data operations</a> in the <i>Amazon Web Services Payment Cryptography
    /// User Guide</i>. 
    /// </para><para><b>Cross-account use</b>: This operation can't be used across different Amazon Web
    /// Services accounts.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>VerifyMac</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "PAYCDMac", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PaymentCryptographyData.Model.GenerateMacResponse")]
    [AWSCmdlet("Calls the Payment Cryptography Data GenerateMac API operation.", Operation = new[] {"GenerateMac"}, SelectReturnType = typeof(Amazon.PaymentCryptographyData.Model.GenerateMacResponse))]
    [AWSCmdletOutput("Amazon.PaymentCryptographyData.Model.GenerateMacResponse",
        "This cmdlet returns an Amazon.PaymentCryptographyData.Model.GenerateMacResponse object containing multiple properties."
    )]
    public partial class NewPAYCDMacCmdlet : AmazonPaymentCryptographyDataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter GenerationAttributes_Algorithm
        /// <summary>
        /// <para>
        /// <para>The encryption algorithm for MAC generation or verification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.MacAlgorithm")]
        public Amazon.PaymentCryptographyData.MacAlgorithm GenerationAttributes_Algorithm { get; set; }
        #endregion
        
        #region Parameter SessionKeyDerivationValue_ApplicationCryptogram
        /// <summary>
        /// <para>
        /// <para>The cryptogram provided by the terminal during transaction processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationAttributes_EmvMac_SessionKeyDerivationValue_ApplicationCryptogram")]
        public System.String SessionKeyDerivationValue_ApplicationCryptogram { get; set; }
        #endregion
        
        #region Parameter SessionKeyDerivationValue_ApplicationTransactionCounter
        /// <summary>
        /// <para>
        /// <para>The transaction counter that is provided by the terminal during transaction processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationAttributes_EmvMac_SessionKeyDerivationValue_ApplicationTransactionCounter")]
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
        [Alias("GenerationAttributes_DukptCmac_DukptDerivationType")]
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
        [Alias("GenerationAttributes_DukptIso9797Algorithm1_DukptDerivationType")]
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
        [Alias("GenerationAttributes_DukptIso9797Algorithm3_DukptDerivationType")]
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
        [Alias("GenerationAttributes_DukptCmac_DukptKeyVariant")]
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
        [Alias("GenerationAttributes_DukptIso9797Algorithm1_DukptKeyVariant")]
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
        [Alias("GenerationAttributes_DukptIso9797Algorithm3_DukptKeyVariant")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.DukptKeyVariant")]
        public Amazon.PaymentCryptographyData.DukptKeyVariant DukptIso9797Algorithm3_DukptKeyVariant { get; set; }
        #endregion
        
        #region Parameter KeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyARN</c> of the MAC generation encryption key.</para>
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
        [Alias("GenerationAttributes_DukptCmac_KeySerialNumber")]
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
        [Alias("GenerationAttributes_DukptIso9797Algorithm1_KeySerialNumber")]
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
        [Alias("GenerationAttributes_DukptIso9797Algorithm3_KeySerialNumber")]
        public System.String DukptIso9797Algorithm3_KeySerialNumber { get; set; }
        #endregion
        
        #region Parameter MacLength
        /// <summary>
        /// <para>
        /// <para>The length of a MAC under generation.</para>
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
        [Alias("GenerationAttributes_EmvMac_MajorKeyDerivationMode")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.MajorKeyDerivationMode")]
        public Amazon.PaymentCryptographyData.MajorKeyDerivationMode EmvMac_MajorKeyDerivationMode { get; set; }
        #endregion
        
        #region Parameter MessageData
        /// <summary>
        /// <para>
        /// <para>The data for which a MAC is under generation. This value must be hexBinary.</para>
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
        [Alias("GenerationAttributes_EmvMac_PanSequenceNumber")]
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
        [Alias("GenerationAttributes_EmvMac_PrimaryAccountNumber")]
        public System.String EmvMac_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter EmvMac_SessionKeyDerivationMode
        /// <summary>
        /// <para>
        /// <para>The method of deriving a session key for EMV MAC generation or verification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GenerationAttributes_EmvMac_SessionKeyDerivationMode")]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.SessionKeyDerivationMode")]
        public Amazon.PaymentCryptographyData.SessionKeyDerivationMode EmvMac_SessionKeyDerivationMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PaymentCryptographyData.Model.GenerateMacResponse).
        /// Specifying the name of a property of type Amazon.PaymentCryptographyData.Model.GenerateMacResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KeyIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PAYCDMac (GenerateMac)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PaymentCryptographyData.Model.GenerateMacResponse, NewPAYCDMacCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.GenerationAttributes_Algorithm = this.GenerationAttributes_Algorithm;
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
            context.KeyIdentifier = this.KeyIdentifier;
            #if MODULAR
            if (this.KeyIdentifier == null && ParameterWasBound(nameof(this.KeyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PaymentCryptographyData.Model.GenerateMacRequest();
            
            
             // populate GenerationAttributes
            var requestGenerationAttributesIsNull = true;
            request.GenerationAttributes = new Amazon.PaymentCryptographyData.Model.MacAttributes();
            Amazon.PaymentCryptographyData.MacAlgorithm requestGenerationAttributes_generationAttributes_Algorithm = null;
            if (cmdletContext.GenerationAttributes_Algorithm != null)
            {
                requestGenerationAttributes_generationAttributes_Algorithm = cmdletContext.GenerationAttributes_Algorithm;
            }
            if (requestGenerationAttributes_generationAttributes_Algorithm != null)
            {
                request.GenerationAttributes.Algorithm = requestGenerationAttributes_generationAttributes_Algorithm;
                requestGenerationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.MacAlgorithmDukpt requestGenerationAttributes_generationAttributes_DukptCmac = null;
            
             // populate DukptCmac
            var requestGenerationAttributes_generationAttributes_DukptCmacIsNull = true;
            requestGenerationAttributes_generationAttributes_DukptCmac = new Amazon.PaymentCryptographyData.Model.MacAlgorithmDukpt();
            Amazon.PaymentCryptographyData.DukptDerivationType requestGenerationAttributes_generationAttributes_DukptCmac_dukptCmac_DukptDerivationType = null;
            if (cmdletContext.DukptCmac_DukptDerivationType != null)
            {
                requestGenerationAttributes_generationAttributes_DukptCmac_dukptCmac_DukptDerivationType = cmdletContext.DukptCmac_DukptDerivationType;
            }
            if (requestGenerationAttributes_generationAttributes_DukptCmac_dukptCmac_DukptDerivationType != null)
            {
                requestGenerationAttributes_generationAttributes_DukptCmac.DukptDerivationType = requestGenerationAttributes_generationAttributes_DukptCmac_dukptCmac_DukptDerivationType;
                requestGenerationAttributes_generationAttributes_DukptCmacIsNull = false;
            }
            Amazon.PaymentCryptographyData.DukptKeyVariant requestGenerationAttributes_generationAttributes_DukptCmac_dukptCmac_DukptKeyVariant = null;
            if (cmdletContext.DukptCmac_DukptKeyVariant != null)
            {
                requestGenerationAttributes_generationAttributes_DukptCmac_dukptCmac_DukptKeyVariant = cmdletContext.DukptCmac_DukptKeyVariant;
            }
            if (requestGenerationAttributes_generationAttributes_DukptCmac_dukptCmac_DukptKeyVariant != null)
            {
                requestGenerationAttributes_generationAttributes_DukptCmac.DukptKeyVariant = requestGenerationAttributes_generationAttributes_DukptCmac_dukptCmac_DukptKeyVariant;
                requestGenerationAttributes_generationAttributes_DukptCmacIsNull = false;
            }
            System.String requestGenerationAttributes_generationAttributes_DukptCmac_dukptCmac_KeySerialNumber = null;
            if (cmdletContext.DukptCmac_KeySerialNumber != null)
            {
                requestGenerationAttributes_generationAttributes_DukptCmac_dukptCmac_KeySerialNumber = cmdletContext.DukptCmac_KeySerialNumber;
            }
            if (requestGenerationAttributes_generationAttributes_DukptCmac_dukptCmac_KeySerialNumber != null)
            {
                requestGenerationAttributes_generationAttributes_DukptCmac.KeySerialNumber = requestGenerationAttributes_generationAttributes_DukptCmac_dukptCmac_KeySerialNumber;
                requestGenerationAttributes_generationAttributes_DukptCmacIsNull = false;
            }
             // determine if requestGenerationAttributes_generationAttributes_DukptCmac should be set to null
            if (requestGenerationAttributes_generationAttributes_DukptCmacIsNull)
            {
                requestGenerationAttributes_generationAttributes_DukptCmac = null;
            }
            if (requestGenerationAttributes_generationAttributes_DukptCmac != null)
            {
                request.GenerationAttributes.DukptCmac = requestGenerationAttributes_generationAttributes_DukptCmac;
                requestGenerationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.MacAlgorithmDukpt requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1 = null;
            
             // populate DukptIso9797Algorithm1
            var requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1IsNull = true;
            requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1 = new Amazon.PaymentCryptographyData.Model.MacAlgorithmDukpt();
            Amazon.PaymentCryptographyData.DukptDerivationType requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_DukptDerivationType = null;
            if (cmdletContext.DukptIso9797Algorithm1_DukptDerivationType != null)
            {
                requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_DukptDerivationType = cmdletContext.DukptIso9797Algorithm1_DukptDerivationType;
            }
            if (requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_DukptDerivationType != null)
            {
                requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1.DukptDerivationType = requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_DukptDerivationType;
                requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1IsNull = false;
            }
            Amazon.PaymentCryptographyData.DukptKeyVariant requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_DukptKeyVariant = null;
            if (cmdletContext.DukptIso9797Algorithm1_DukptKeyVariant != null)
            {
                requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_DukptKeyVariant = cmdletContext.DukptIso9797Algorithm1_DukptKeyVariant;
            }
            if (requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_DukptKeyVariant != null)
            {
                requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1.DukptKeyVariant = requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_DukptKeyVariant;
                requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1IsNull = false;
            }
            System.String requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_KeySerialNumber = null;
            if (cmdletContext.DukptIso9797Algorithm1_KeySerialNumber != null)
            {
                requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_KeySerialNumber = cmdletContext.DukptIso9797Algorithm1_KeySerialNumber;
            }
            if (requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_KeySerialNumber != null)
            {
                requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1.KeySerialNumber = requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1_dukptIso9797Algorithm1_KeySerialNumber;
                requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1IsNull = false;
            }
             // determine if requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1 should be set to null
            if (requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1IsNull)
            {
                requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1 = null;
            }
            if (requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1 != null)
            {
                request.GenerationAttributes.DukptIso9797Algorithm1 = requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm1;
                requestGenerationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.MacAlgorithmDukpt requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3 = null;
            
             // populate DukptIso9797Algorithm3
            var requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3IsNull = true;
            requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3 = new Amazon.PaymentCryptographyData.Model.MacAlgorithmDukpt();
            Amazon.PaymentCryptographyData.DukptDerivationType requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_DukptDerivationType = null;
            if (cmdletContext.DukptIso9797Algorithm3_DukptDerivationType != null)
            {
                requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_DukptDerivationType = cmdletContext.DukptIso9797Algorithm3_DukptDerivationType;
            }
            if (requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_DukptDerivationType != null)
            {
                requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3.DukptDerivationType = requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_DukptDerivationType;
                requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3IsNull = false;
            }
            Amazon.PaymentCryptographyData.DukptKeyVariant requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_DukptKeyVariant = null;
            if (cmdletContext.DukptIso9797Algorithm3_DukptKeyVariant != null)
            {
                requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_DukptKeyVariant = cmdletContext.DukptIso9797Algorithm3_DukptKeyVariant;
            }
            if (requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_DukptKeyVariant != null)
            {
                requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3.DukptKeyVariant = requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_DukptKeyVariant;
                requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3IsNull = false;
            }
            System.String requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_KeySerialNumber = null;
            if (cmdletContext.DukptIso9797Algorithm3_KeySerialNumber != null)
            {
                requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_KeySerialNumber = cmdletContext.DukptIso9797Algorithm3_KeySerialNumber;
            }
            if (requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_KeySerialNumber != null)
            {
                requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3.KeySerialNumber = requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3_dukptIso9797Algorithm3_KeySerialNumber;
                requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3IsNull = false;
            }
             // determine if requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3 should be set to null
            if (requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3IsNull)
            {
                requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3 = null;
            }
            if (requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3 != null)
            {
                request.GenerationAttributes.DukptIso9797Algorithm3 = requestGenerationAttributes_generationAttributes_DukptIso9797Algorithm3;
                requestGenerationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.MacAlgorithmEmv requestGenerationAttributes_generationAttributes_EmvMac = null;
            
             // populate EmvMac
            var requestGenerationAttributes_generationAttributes_EmvMacIsNull = true;
            requestGenerationAttributes_generationAttributes_EmvMac = new Amazon.PaymentCryptographyData.Model.MacAlgorithmEmv();
            Amazon.PaymentCryptographyData.MajorKeyDerivationMode requestGenerationAttributes_generationAttributes_EmvMac_emvMac_MajorKeyDerivationMode = null;
            if (cmdletContext.EmvMac_MajorKeyDerivationMode != null)
            {
                requestGenerationAttributes_generationAttributes_EmvMac_emvMac_MajorKeyDerivationMode = cmdletContext.EmvMac_MajorKeyDerivationMode;
            }
            if (requestGenerationAttributes_generationAttributes_EmvMac_emvMac_MajorKeyDerivationMode != null)
            {
                requestGenerationAttributes_generationAttributes_EmvMac.MajorKeyDerivationMode = requestGenerationAttributes_generationAttributes_EmvMac_emvMac_MajorKeyDerivationMode;
                requestGenerationAttributes_generationAttributes_EmvMacIsNull = false;
            }
            System.String requestGenerationAttributes_generationAttributes_EmvMac_emvMac_PanSequenceNumber = null;
            if (cmdletContext.EmvMac_PanSequenceNumber != null)
            {
                requestGenerationAttributes_generationAttributes_EmvMac_emvMac_PanSequenceNumber = cmdletContext.EmvMac_PanSequenceNumber;
            }
            if (requestGenerationAttributes_generationAttributes_EmvMac_emvMac_PanSequenceNumber != null)
            {
                requestGenerationAttributes_generationAttributes_EmvMac.PanSequenceNumber = requestGenerationAttributes_generationAttributes_EmvMac_emvMac_PanSequenceNumber;
                requestGenerationAttributes_generationAttributes_EmvMacIsNull = false;
            }
            System.String requestGenerationAttributes_generationAttributes_EmvMac_emvMac_PrimaryAccountNumber = null;
            if (cmdletContext.EmvMac_PrimaryAccountNumber != null)
            {
                requestGenerationAttributes_generationAttributes_EmvMac_emvMac_PrimaryAccountNumber = cmdletContext.EmvMac_PrimaryAccountNumber;
            }
            if (requestGenerationAttributes_generationAttributes_EmvMac_emvMac_PrimaryAccountNumber != null)
            {
                requestGenerationAttributes_generationAttributes_EmvMac.PrimaryAccountNumber = requestGenerationAttributes_generationAttributes_EmvMac_emvMac_PrimaryAccountNumber;
                requestGenerationAttributes_generationAttributes_EmvMacIsNull = false;
            }
            Amazon.PaymentCryptographyData.SessionKeyDerivationMode requestGenerationAttributes_generationAttributes_EmvMac_emvMac_SessionKeyDerivationMode = null;
            if (cmdletContext.EmvMac_SessionKeyDerivationMode != null)
            {
                requestGenerationAttributes_generationAttributes_EmvMac_emvMac_SessionKeyDerivationMode = cmdletContext.EmvMac_SessionKeyDerivationMode;
            }
            if (requestGenerationAttributes_generationAttributes_EmvMac_emvMac_SessionKeyDerivationMode != null)
            {
                requestGenerationAttributes_generationAttributes_EmvMac.SessionKeyDerivationMode = requestGenerationAttributes_generationAttributes_EmvMac_emvMac_SessionKeyDerivationMode;
                requestGenerationAttributes_generationAttributes_EmvMacIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.SessionKeyDerivationValue requestGenerationAttributes_generationAttributes_EmvMac_generationAttributes_EmvMac_SessionKeyDerivationValue = null;
            
             // populate SessionKeyDerivationValue
            var requestGenerationAttributes_generationAttributes_EmvMac_generationAttributes_EmvMac_SessionKeyDerivationValueIsNull = true;
            requestGenerationAttributes_generationAttributes_EmvMac_generationAttributes_EmvMac_SessionKeyDerivationValue = new Amazon.PaymentCryptographyData.Model.SessionKeyDerivationValue();
            System.String requestGenerationAttributes_generationAttributes_EmvMac_generationAttributes_EmvMac_SessionKeyDerivationValue_sessionKeyDerivationValue_ApplicationCryptogram = null;
            if (cmdletContext.SessionKeyDerivationValue_ApplicationCryptogram != null)
            {
                requestGenerationAttributes_generationAttributes_EmvMac_generationAttributes_EmvMac_SessionKeyDerivationValue_sessionKeyDerivationValue_ApplicationCryptogram = cmdletContext.SessionKeyDerivationValue_ApplicationCryptogram;
            }
            if (requestGenerationAttributes_generationAttributes_EmvMac_generationAttributes_EmvMac_SessionKeyDerivationValue_sessionKeyDerivationValue_ApplicationCryptogram != null)
            {
                requestGenerationAttributes_generationAttributes_EmvMac_generationAttributes_EmvMac_SessionKeyDerivationValue.ApplicationCryptogram = requestGenerationAttributes_generationAttributes_EmvMac_generationAttributes_EmvMac_SessionKeyDerivationValue_sessionKeyDerivationValue_ApplicationCryptogram;
                requestGenerationAttributes_generationAttributes_EmvMac_generationAttributes_EmvMac_SessionKeyDerivationValueIsNull = false;
            }
            System.String requestGenerationAttributes_generationAttributes_EmvMac_generationAttributes_EmvMac_SessionKeyDerivationValue_sessionKeyDerivationValue_ApplicationTransactionCounter = null;
            if (cmdletContext.SessionKeyDerivationValue_ApplicationTransactionCounter != null)
            {
                requestGenerationAttributes_generationAttributes_EmvMac_generationAttributes_EmvMac_SessionKeyDerivationValue_sessionKeyDerivationValue_ApplicationTransactionCounter = cmdletContext.SessionKeyDerivationValue_ApplicationTransactionCounter;
            }
            if (requestGenerationAttributes_generationAttributes_EmvMac_generationAttributes_EmvMac_SessionKeyDerivationValue_sessionKeyDerivationValue_ApplicationTransactionCounter != null)
            {
                requestGenerationAttributes_generationAttributes_EmvMac_generationAttributes_EmvMac_SessionKeyDerivationValue.ApplicationTransactionCounter = requestGenerationAttributes_generationAttributes_EmvMac_generationAttributes_EmvMac_SessionKeyDerivationValue_sessionKeyDerivationValue_ApplicationTransactionCounter;
                requestGenerationAttributes_generationAttributes_EmvMac_generationAttributes_EmvMac_SessionKeyDerivationValueIsNull = false;
            }
             // determine if requestGenerationAttributes_generationAttributes_EmvMac_generationAttributes_EmvMac_SessionKeyDerivationValue should be set to null
            if (requestGenerationAttributes_generationAttributes_EmvMac_generationAttributes_EmvMac_SessionKeyDerivationValueIsNull)
            {
                requestGenerationAttributes_generationAttributes_EmvMac_generationAttributes_EmvMac_SessionKeyDerivationValue = null;
            }
            if (requestGenerationAttributes_generationAttributes_EmvMac_generationAttributes_EmvMac_SessionKeyDerivationValue != null)
            {
                requestGenerationAttributes_generationAttributes_EmvMac.SessionKeyDerivationValue = requestGenerationAttributes_generationAttributes_EmvMac_generationAttributes_EmvMac_SessionKeyDerivationValue;
                requestGenerationAttributes_generationAttributes_EmvMacIsNull = false;
            }
             // determine if requestGenerationAttributes_generationAttributes_EmvMac should be set to null
            if (requestGenerationAttributes_generationAttributes_EmvMacIsNull)
            {
                requestGenerationAttributes_generationAttributes_EmvMac = null;
            }
            if (requestGenerationAttributes_generationAttributes_EmvMac != null)
            {
                request.GenerationAttributes.EmvMac = requestGenerationAttributes_generationAttributes_EmvMac;
                requestGenerationAttributesIsNull = false;
            }
             // determine if request.GenerationAttributes should be set to null
            if (requestGenerationAttributesIsNull)
            {
                request.GenerationAttributes = null;
            }
            if (cmdletContext.KeyIdentifier != null)
            {
                request.KeyIdentifier = cmdletContext.KeyIdentifier;
            }
            if (cmdletContext.MacLength != null)
            {
                request.MacLength = cmdletContext.MacLength.Value;
            }
            if (cmdletContext.MessageData != null)
            {
                request.MessageData = cmdletContext.MessageData;
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
        
        private Amazon.PaymentCryptographyData.Model.GenerateMacResponse CallAWSServiceOperation(IAmazonPaymentCryptographyData client, Amazon.PaymentCryptographyData.Model.GenerateMacRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Payment Cryptography Data", "GenerateMac");
            try
            {
                return client.GenerateMacAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.PaymentCryptographyData.MacAlgorithm GenerationAttributes_Algorithm { get; set; }
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
            public System.String KeyIdentifier { get; set; }
            public System.Int32? MacLength { get; set; }
            public System.String MessageData { get; set; }
            public System.Func<Amazon.PaymentCryptographyData.Model.GenerateMacResponse, NewPAYCDMacCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
