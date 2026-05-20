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
    /// Generates an Authorization Request Cryptogram (ARQC) for an EMV chip payment card
    /// authorization. For more information, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/data-operations.generateauthrequestcryptogram.html">Generate
    /// auth request cryptogram</a> in the <i>Amazon Web Services Payment Cryptography User
    /// Guide</i>.
    /// 
    ///  
    /// <para>
    /// ARQC generation uses an Issuer Master Key (IMK) for application cryptograms (TR31_E0_EMV_MKEY_APP_CRYPTOGRAMS)
    /// to derive a session key, which is then used to generate the cryptogram from the provided
    /// transaction data (when applicable). To use this operation, you must first create or
    /// import an IMK-AC key by calling <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_CreateKey.html">CreateKey</a>
    /// or <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_ImportKey.html">ImportKey</a>.
    /// The <c>KeyModesOfUse</c> should be set to <c>DeriveKey</c> for the IMK-AC encryption
    /// key.
    /// </para><important><para>
    /// This operation is intended for development and testing scenarios only. It is not recommended
    /// to use this operation as a substitute for card-based cryptogram generation in production
    /// payment flows.
    /// </para></important><para>
    /// For information about valid keys for this operation, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/keys-validattributes.html">Understanding
    /// key attributes</a> and <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/crypto-ops-validkeys-ops.html">Key
    /// types for specific data operations</a> in the <i>Amazon Web Services Payment Cryptography
    /// User Guide</i>. 
    /// </para><para><b>Cross-account use</b>: This operation supports cross-account use when the key
    /// has a resource-based policy that grants access. For more information, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/security_iam_resource-based-policies.html">Resource-based
    /// policies</a>.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>VerifyAuthRequestCryptogram</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "PAYCDAuthRequestCryptogram", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PaymentCryptographyData.Model.GenerateAuthRequestCryptogramResponse")]
    [AWSCmdlet("Calls the Payment Cryptography Data GenerateAuthRequestCryptogram API operation.", Operation = new[] {"GenerateAuthRequestCryptogram"}, SelectReturnType = typeof(Amazon.PaymentCryptographyData.Model.GenerateAuthRequestCryptogramResponse))]
    [AWSCmdletOutput("Amazon.PaymentCryptographyData.Model.GenerateAuthRequestCryptogramResponse",
        "This cmdlet returns an Amazon.PaymentCryptographyData.Model.GenerateAuthRequestCryptogramResponse object containing multiple properties."
    )]
    public partial class NewPAYCDAuthRequestCryptogramCmdlet : AmazonPaymentCryptographyDataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SessionKeyDerivationAttributes_Emv2000_ApplicationTransactionCounter
        /// <summary>
        /// <para>
        /// <para>The transaction counter that is provided by the terminal during transaction processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionKeyDerivationAttributes_Emv2000_ApplicationTransactionCounter { get; set; }
        #endregion
        
        #region Parameter SessionKeyDerivationAttributes_EmvCommon_ApplicationTransactionCounter
        /// <summary>
        /// <para>
        /// <para>The transaction counter that is provided by the terminal during transaction processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionKeyDerivationAttributes_EmvCommon_ApplicationTransactionCounter { get; set; }
        #endregion
        
        #region Parameter SessionKeyDerivationAttributes_Mastercard_ApplicationTransactionCounter
        /// <summary>
        /// <para>
        /// <para>The transaction counter that is provided by the terminal during transaction processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionKeyDerivationAttributes_Mastercard_ApplicationTransactionCounter { get; set; }
        #endregion
        
        #region Parameter KeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyARN</c> of the IMK-AC (TR31_E0_EMV_MKEY_APP_CRYPTOGRAMS) that Amazon Web
        /// Services Payment Cryptography uses to generate the ARQC.</para>
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
        public System.String KeyIdentifier { get; set; }
        #endregion
        
        #region Parameter MajorKeyDerivationMode
        /// <summary>
        /// <para>
        /// <para>The method to use when deriving the major encryption key for ARQC generation within
        /// Amazon Web Services Payment Cryptography.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PaymentCryptographyData.MajorKeyDerivationMode")]
        public Amazon.PaymentCryptographyData.MajorKeyDerivationMode MajorKeyDerivationMode { get; set; }
        #endregion
        
        #region Parameter SessionKeyDerivationAttributes_Amex_PanSequenceNumber
        /// <summary>
        /// <para>
        /// <para>A number that identifies and differentiates payment cards with the same Primary Account
        /// Number (PAN).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionKeyDerivationAttributes_Amex_PanSequenceNumber { get; set; }
        #endregion
        
        #region Parameter SessionKeyDerivationAttributes_Emv2000_PanSequenceNumber
        /// <summary>
        /// <para>
        /// <para>A number that identifies and differentiates payment cards with the same Primary Account
        /// Number (PAN).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionKeyDerivationAttributes_Emv2000_PanSequenceNumber { get; set; }
        #endregion
        
        #region Parameter SessionKeyDerivationAttributes_EmvCommon_PanSequenceNumber
        /// <summary>
        /// <para>
        /// <para>A number that identifies and differentiates payment cards with the same Primary Account
        /// Number (PAN).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionKeyDerivationAttributes_EmvCommon_PanSequenceNumber { get; set; }
        #endregion
        
        #region Parameter SessionKeyDerivationAttributes_Mastercard_PanSequenceNumber
        /// <summary>
        /// <para>
        /// <para>A number that identifies and differentiates payment cards with the same Primary Account
        /// Number (PAN).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionKeyDerivationAttributes_Mastercard_PanSequenceNumber { get; set; }
        #endregion
        
        #region Parameter SessionKeyDerivationAttributes_Visa_PanSequenceNumber
        /// <summary>
        /// <para>
        /// <para>A number that identifies and differentiates payment cards with the same Primary Account
        /// Number (PAN).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionKeyDerivationAttributes_Visa_PanSequenceNumber { get; set; }
        #endregion
        
        #region Parameter SessionKeyDerivationAttributes_Amex_PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN) of the cardholder. A PAN is a unique identifier for
        /// a payment credit or debit card and associates the card to a specific account holder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionKeyDerivationAttributes_Amex_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter SessionKeyDerivationAttributes_Emv2000_PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN) of the cardholder. A PAN is a unique identifier for
        /// a payment credit or debit card and associates the card to a specific account holder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionKeyDerivationAttributes_Emv2000_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter SessionKeyDerivationAttributes_EmvCommon_PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN) of the cardholder. A PAN is a unique identifier for
        /// a payment credit or debit card and associates the card to a specific account holder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionKeyDerivationAttributes_EmvCommon_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter SessionKeyDerivationAttributes_Mastercard_PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN) of the cardholder. A PAN is a unique identifier for
        /// a payment credit or debit card and associates the card to a specific account holder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionKeyDerivationAttributes_Mastercard_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter SessionKeyDerivationAttributes_Visa_PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN) of the cardholder. A PAN is a unique identifier for
        /// a payment credit or debit card and associates the card to a specific account holder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionKeyDerivationAttributes_Visa_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter TransactionData
        /// <summary>
        /// <para>
        /// <para>The transaction data that Amazon Web Services Payment Cryptography uses for ARQC generation.
        /// The same transaction data is used for ARQC verification by the issuer using <a>VerifyAuthRequestCryptogram</a>.</para>
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
        public System.String TransactionData { get; set; }
        #endregion
        
        #region Parameter SessionKeyDerivationAttributes_Mastercard_UnpredictableNumber
        /// <summary>
        /// <para>
        /// <para>A random number generated by the issuer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionKeyDerivationAttributes_Mastercard_UnpredictableNumber { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PaymentCryptographyData.Model.GenerateAuthRequestCryptogramResponse).
        /// Specifying the name of a property of type Amazon.PaymentCryptographyData.Model.GenerateAuthRequestCryptogramResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PAYCDAuthRequestCryptogram (GenerateAuthRequestCryptogram)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PaymentCryptographyData.Model.GenerateAuthRequestCryptogramResponse, NewPAYCDAuthRequestCryptogramCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.KeyIdentifier = this.KeyIdentifier;
            #if MODULAR
            if (this.KeyIdentifier == null && ParameterWasBound(nameof(this.KeyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MajorKeyDerivationMode = this.MajorKeyDerivationMode;
            #if MODULAR
            if (this.MajorKeyDerivationMode == null && ParameterWasBound(nameof(this.MajorKeyDerivationMode)))
            {
                WriteWarning("You are passing $null as a value for parameter MajorKeyDerivationMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SessionKeyDerivationAttributes_Amex_PanSequenceNumber = this.SessionKeyDerivationAttributes_Amex_PanSequenceNumber;
            context.SessionKeyDerivationAttributes_Amex_PrimaryAccountNumber = this.SessionKeyDerivationAttributes_Amex_PrimaryAccountNumber;
            context.SessionKeyDerivationAttributes_Emv2000_ApplicationTransactionCounter = this.SessionKeyDerivationAttributes_Emv2000_ApplicationTransactionCounter;
            context.SessionKeyDerivationAttributes_Emv2000_PanSequenceNumber = this.SessionKeyDerivationAttributes_Emv2000_PanSequenceNumber;
            context.SessionKeyDerivationAttributes_Emv2000_PrimaryAccountNumber = this.SessionKeyDerivationAttributes_Emv2000_PrimaryAccountNumber;
            context.SessionKeyDerivationAttributes_EmvCommon_ApplicationTransactionCounter = this.SessionKeyDerivationAttributes_EmvCommon_ApplicationTransactionCounter;
            context.SessionKeyDerivationAttributes_EmvCommon_PanSequenceNumber = this.SessionKeyDerivationAttributes_EmvCommon_PanSequenceNumber;
            context.SessionKeyDerivationAttributes_EmvCommon_PrimaryAccountNumber = this.SessionKeyDerivationAttributes_EmvCommon_PrimaryAccountNumber;
            context.SessionKeyDerivationAttributes_Mastercard_ApplicationTransactionCounter = this.SessionKeyDerivationAttributes_Mastercard_ApplicationTransactionCounter;
            context.SessionKeyDerivationAttributes_Mastercard_PanSequenceNumber = this.SessionKeyDerivationAttributes_Mastercard_PanSequenceNumber;
            context.SessionKeyDerivationAttributes_Mastercard_PrimaryAccountNumber = this.SessionKeyDerivationAttributes_Mastercard_PrimaryAccountNumber;
            context.SessionKeyDerivationAttributes_Mastercard_UnpredictableNumber = this.SessionKeyDerivationAttributes_Mastercard_UnpredictableNumber;
            context.SessionKeyDerivationAttributes_Visa_PanSequenceNumber = this.SessionKeyDerivationAttributes_Visa_PanSequenceNumber;
            context.SessionKeyDerivationAttributes_Visa_PrimaryAccountNumber = this.SessionKeyDerivationAttributes_Visa_PrimaryAccountNumber;
            context.TransactionData = this.TransactionData;
            #if MODULAR
            if (this.TransactionData == null && ParameterWasBound(nameof(this.TransactionData)))
            {
                WriteWarning("You are passing $null as a value for parameter TransactionData which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PaymentCryptographyData.Model.GenerateAuthRequestCryptogramRequest();
            
            if (cmdletContext.KeyIdentifier != null)
            {
                request.KeyIdentifier = cmdletContext.KeyIdentifier;
            }
            if (cmdletContext.MajorKeyDerivationMode != null)
            {
                request.MajorKeyDerivationMode = cmdletContext.MajorKeyDerivationMode;
            }
            
             // populate SessionKeyDerivationAttributes
            var requestSessionKeyDerivationAttributesIsNull = true;
            request.SessionKeyDerivationAttributes = new Amazon.PaymentCryptographyData.Model.SessionKeyDerivation();
            Amazon.PaymentCryptographyData.Model.SessionKeyAmex requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex = null;
            
             // populate Amex
            var requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_AmexIsNull = true;
            requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex = new Amazon.PaymentCryptographyData.Model.SessionKeyAmex();
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex_sessionKeyDerivationAttributes_Amex_PanSequenceNumber = null;
            if (cmdletContext.SessionKeyDerivationAttributes_Amex_PanSequenceNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex_sessionKeyDerivationAttributes_Amex_PanSequenceNumber = cmdletContext.SessionKeyDerivationAttributes_Amex_PanSequenceNumber;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex_sessionKeyDerivationAttributes_Amex_PanSequenceNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex.PanSequenceNumber = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex_sessionKeyDerivationAttributes_Amex_PanSequenceNumber;
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_AmexIsNull = false;
            }
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex_sessionKeyDerivationAttributes_Amex_PrimaryAccountNumber = null;
            if (cmdletContext.SessionKeyDerivationAttributes_Amex_PrimaryAccountNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex_sessionKeyDerivationAttributes_Amex_PrimaryAccountNumber = cmdletContext.SessionKeyDerivationAttributes_Amex_PrimaryAccountNumber;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex_sessionKeyDerivationAttributes_Amex_PrimaryAccountNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex.PrimaryAccountNumber = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex_sessionKeyDerivationAttributes_Amex_PrimaryAccountNumber;
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_AmexIsNull = false;
            }
             // determine if requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex should be set to null
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_AmexIsNull)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex = null;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex != null)
            {
                request.SessionKeyDerivationAttributes.Amex = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex;
                requestSessionKeyDerivationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.SessionKeyVisa requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa = null;
            
             // populate Visa
            var requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_VisaIsNull = true;
            requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa = new Amazon.PaymentCryptographyData.Model.SessionKeyVisa();
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa_sessionKeyDerivationAttributes_Visa_PanSequenceNumber = null;
            if (cmdletContext.SessionKeyDerivationAttributes_Visa_PanSequenceNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa_sessionKeyDerivationAttributes_Visa_PanSequenceNumber = cmdletContext.SessionKeyDerivationAttributes_Visa_PanSequenceNumber;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa_sessionKeyDerivationAttributes_Visa_PanSequenceNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa.PanSequenceNumber = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa_sessionKeyDerivationAttributes_Visa_PanSequenceNumber;
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_VisaIsNull = false;
            }
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa_sessionKeyDerivationAttributes_Visa_PrimaryAccountNumber = null;
            if (cmdletContext.SessionKeyDerivationAttributes_Visa_PrimaryAccountNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa_sessionKeyDerivationAttributes_Visa_PrimaryAccountNumber = cmdletContext.SessionKeyDerivationAttributes_Visa_PrimaryAccountNumber;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa_sessionKeyDerivationAttributes_Visa_PrimaryAccountNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa.PrimaryAccountNumber = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa_sessionKeyDerivationAttributes_Visa_PrimaryAccountNumber;
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_VisaIsNull = false;
            }
             // determine if requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa should be set to null
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_VisaIsNull)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa = null;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa != null)
            {
                request.SessionKeyDerivationAttributes.Visa = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa;
                requestSessionKeyDerivationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.SessionKeyEmv2000 requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000 = null;
            
             // populate Emv2000
            var requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000IsNull = true;
            requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000 = new Amazon.PaymentCryptographyData.Model.SessionKeyEmv2000();
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_sessionKeyDerivationAttributes_Emv2000_ApplicationTransactionCounter = null;
            if (cmdletContext.SessionKeyDerivationAttributes_Emv2000_ApplicationTransactionCounter != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_sessionKeyDerivationAttributes_Emv2000_ApplicationTransactionCounter = cmdletContext.SessionKeyDerivationAttributes_Emv2000_ApplicationTransactionCounter;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_sessionKeyDerivationAttributes_Emv2000_ApplicationTransactionCounter != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000.ApplicationTransactionCounter = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_sessionKeyDerivationAttributes_Emv2000_ApplicationTransactionCounter;
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000IsNull = false;
            }
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_sessionKeyDerivationAttributes_Emv2000_PanSequenceNumber = null;
            if (cmdletContext.SessionKeyDerivationAttributes_Emv2000_PanSequenceNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_sessionKeyDerivationAttributes_Emv2000_PanSequenceNumber = cmdletContext.SessionKeyDerivationAttributes_Emv2000_PanSequenceNumber;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_sessionKeyDerivationAttributes_Emv2000_PanSequenceNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000.PanSequenceNumber = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_sessionKeyDerivationAttributes_Emv2000_PanSequenceNumber;
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000IsNull = false;
            }
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_sessionKeyDerivationAttributes_Emv2000_PrimaryAccountNumber = null;
            if (cmdletContext.SessionKeyDerivationAttributes_Emv2000_PrimaryAccountNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_sessionKeyDerivationAttributes_Emv2000_PrimaryAccountNumber = cmdletContext.SessionKeyDerivationAttributes_Emv2000_PrimaryAccountNumber;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_sessionKeyDerivationAttributes_Emv2000_PrimaryAccountNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000.PrimaryAccountNumber = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_sessionKeyDerivationAttributes_Emv2000_PrimaryAccountNumber;
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000IsNull = false;
            }
             // determine if requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000 should be set to null
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000IsNull)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000 = null;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000 != null)
            {
                request.SessionKeyDerivationAttributes.Emv2000 = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000;
                requestSessionKeyDerivationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.SessionKeyEmvCommon requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon = null;
            
             // populate EmvCommon
            var requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommonIsNull = true;
            requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon = new Amazon.PaymentCryptographyData.Model.SessionKeyEmvCommon();
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_sessionKeyDerivationAttributes_EmvCommon_ApplicationTransactionCounter = null;
            if (cmdletContext.SessionKeyDerivationAttributes_EmvCommon_ApplicationTransactionCounter != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_sessionKeyDerivationAttributes_EmvCommon_ApplicationTransactionCounter = cmdletContext.SessionKeyDerivationAttributes_EmvCommon_ApplicationTransactionCounter;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_sessionKeyDerivationAttributes_EmvCommon_ApplicationTransactionCounter != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon.ApplicationTransactionCounter = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_sessionKeyDerivationAttributes_EmvCommon_ApplicationTransactionCounter;
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommonIsNull = false;
            }
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_sessionKeyDerivationAttributes_EmvCommon_PanSequenceNumber = null;
            if (cmdletContext.SessionKeyDerivationAttributes_EmvCommon_PanSequenceNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_sessionKeyDerivationAttributes_EmvCommon_PanSequenceNumber = cmdletContext.SessionKeyDerivationAttributes_EmvCommon_PanSequenceNumber;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_sessionKeyDerivationAttributes_EmvCommon_PanSequenceNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon.PanSequenceNumber = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_sessionKeyDerivationAttributes_EmvCommon_PanSequenceNumber;
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommonIsNull = false;
            }
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_sessionKeyDerivationAttributes_EmvCommon_PrimaryAccountNumber = null;
            if (cmdletContext.SessionKeyDerivationAttributes_EmvCommon_PrimaryAccountNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_sessionKeyDerivationAttributes_EmvCommon_PrimaryAccountNumber = cmdletContext.SessionKeyDerivationAttributes_EmvCommon_PrimaryAccountNumber;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_sessionKeyDerivationAttributes_EmvCommon_PrimaryAccountNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon.PrimaryAccountNumber = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_sessionKeyDerivationAttributes_EmvCommon_PrimaryAccountNumber;
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommonIsNull = false;
            }
             // determine if requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon should be set to null
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommonIsNull)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon = null;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon != null)
            {
                request.SessionKeyDerivationAttributes.EmvCommon = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon;
                requestSessionKeyDerivationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.SessionKeyMastercard requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard = null;
            
             // populate Mastercard
            var requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_MastercardIsNull = true;
            requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard = new Amazon.PaymentCryptographyData.Model.SessionKeyMastercard();
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_sessionKeyDerivationAttributes_Mastercard_ApplicationTransactionCounter = null;
            if (cmdletContext.SessionKeyDerivationAttributes_Mastercard_ApplicationTransactionCounter != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_sessionKeyDerivationAttributes_Mastercard_ApplicationTransactionCounter = cmdletContext.SessionKeyDerivationAttributes_Mastercard_ApplicationTransactionCounter;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_sessionKeyDerivationAttributes_Mastercard_ApplicationTransactionCounter != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard.ApplicationTransactionCounter = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_sessionKeyDerivationAttributes_Mastercard_ApplicationTransactionCounter;
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_MastercardIsNull = false;
            }
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_sessionKeyDerivationAttributes_Mastercard_PanSequenceNumber = null;
            if (cmdletContext.SessionKeyDerivationAttributes_Mastercard_PanSequenceNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_sessionKeyDerivationAttributes_Mastercard_PanSequenceNumber = cmdletContext.SessionKeyDerivationAttributes_Mastercard_PanSequenceNumber;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_sessionKeyDerivationAttributes_Mastercard_PanSequenceNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard.PanSequenceNumber = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_sessionKeyDerivationAttributes_Mastercard_PanSequenceNumber;
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_MastercardIsNull = false;
            }
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_sessionKeyDerivationAttributes_Mastercard_PrimaryAccountNumber = null;
            if (cmdletContext.SessionKeyDerivationAttributes_Mastercard_PrimaryAccountNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_sessionKeyDerivationAttributes_Mastercard_PrimaryAccountNumber = cmdletContext.SessionKeyDerivationAttributes_Mastercard_PrimaryAccountNumber;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_sessionKeyDerivationAttributes_Mastercard_PrimaryAccountNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard.PrimaryAccountNumber = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_sessionKeyDerivationAttributes_Mastercard_PrimaryAccountNumber;
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_MastercardIsNull = false;
            }
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_sessionKeyDerivationAttributes_Mastercard_UnpredictableNumber = null;
            if (cmdletContext.SessionKeyDerivationAttributes_Mastercard_UnpredictableNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_sessionKeyDerivationAttributes_Mastercard_UnpredictableNumber = cmdletContext.SessionKeyDerivationAttributes_Mastercard_UnpredictableNumber;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_sessionKeyDerivationAttributes_Mastercard_UnpredictableNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard.UnpredictableNumber = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_sessionKeyDerivationAttributes_Mastercard_UnpredictableNumber;
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_MastercardIsNull = false;
            }
             // determine if requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard should be set to null
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_MastercardIsNull)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard = null;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard != null)
            {
                request.SessionKeyDerivationAttributes.Mastercard = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard;
                requestSessionKeyDerivationAttributesIsNull = false;
            }
             // determine if request.SessionKeyDerivationAttributes should be set to null
            if (requestSessionKeyDerivationAttributesIsNull)
            {
                request.SessionKeyDerivationAttributes = null;
            }
            if (cmdletContext.TransactionData != null)
            {
                request.TransactionData = cmdletContext.TransactionData;
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
        
        private Amazon.PaymentCryptographyData.Model.GenerateAuthRequestCryptogramResponse CallAWSServiceOperation(IAmazonPaymentCryptographyData client, Amazon.PaymentCryptographyData.Model.GenerateAuthRequestCryptogramRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Payment Cryptography Data", "GenerateAuthRequestCryptogram");
            try
            {
                return client.GenerateAuthRequestCryptogramAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.PaymentCryptographyData.MajorKeyDerivationMode MajorKeyDerivationMode { get; set; }
            public System.String SessionKeyDerivationAttributes_Amex_PanSequenceNumber { get; set; }
            public System.String SessionKeyDerivationAttributes_Amex_PrimaryAccountNumber { get; set; }
            public System.String SessionKeyDerivationAttributes_Emv2000_ApplicationTransactionCounter { get; set; }
            public System.String SessionKeyDerivationAttributes_Emv2000_PanSequenceNumber { get; set; }
            public System.String SessionKeyDerivationAttributes_Emv2000_PrimaryAccountNumber { get; set; }
            public System.String SessionKeyDerivationAttributes_EmvCommon_ApplicationTransactionCounter { get; set; }
            public System.String SessionKeyDerivationAttributes_EmvCommon_PanSequenceNumber { get; set; }
            public System.String SessionKeyDerivationAttributes_EmvCommon_PrimaryAccountNumber { get; set; }
            public System.String SessionKeyDerivationAttributes_Mastercard_ApplicationTransactionCounter { get; set; }
            public System.String SessionKeyDerivationAttributes_Mastercard_PanSequenceNumber { get; set; }
            public System.String SessionKeyDerivationAttributes_Mastercard_PrimaryAccountNumber { get; set; }
            public System.String SessionKeyDerivationAttributes_Mastercard_UnpredictableNumber { get; set; }
            public System.String SessionKeyDerivationAttributes_Visa_PanSequenceNumber { get; set; }
            public System.String SessionKeyDerivationAttributes_Visa_PrimaryAccountNumber { get; set; }
            public System.String TransactionData { get; set; }
            public System.Func<Amazon.PaymentCryptographyData.Model.GenerateAuthRequestCryptogramResponse, NewPAYCDAuthRequestCryptogramCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
