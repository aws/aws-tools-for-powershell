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
    /// Verifies card-related validation data using algorithms such as Card Verification Values
    /// (CVV/CVV2), Dynamic Card Verification Values (dCVV/dCVV2) and Card Security Codes
    /// (CSC). For more information, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/verify-card-data.html">Verify
    /// card data</a> in the <i>Amazon Web Services Payment Cryptography User Guide</i>.
    /// 
    ///  
    /// <para>
    /// This operation validates the CVV or CSC codes that is printed on a payment credit
    /// or debit card during card payment transaction. The input values are typically provided
    /// as part of an inbound transaction to an issuer or supporting platform partner. Amazon
    /// Web Services Payment Cryptography uses CVV or CSC, PAN (Primary Account Number) and
    /// expiration date of the card to check its validity during transaction processing. In
    /// this operation, the CVK (Card Verification Key) encryption key for use with card data
    /// verification is same as the one in used for <a>GenerateCardValidationData</a>. 
    /// </para><para>
    /// For information about valid keys for this operation, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/keys-validattributes.html">Understanding
    /// key attributes</a> and <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/crypto-ops-validkeys-ops.html">Key
    /// types for specific data operations</a> in the <i>Amazon Web Services Payment Cryptography
    /// User Guide</i>. 
    /// </para><para><b>Cross-account use</b>: This operation can't be used across different Amazon Web
    /// Services accounts.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>GenerateCardValidationData</a></para></li><li><para><a>VerifyAuthRequestCryptogram</a></para></li><li><para><a>VerifyPinData</a></para></li></ul>
    /// </summary>
    [Cmdlet("Test", "PAYCDCardValidationData")]
    [OutputType("Amazon.PaymentCryptographyData.Model.VerifyCardValidationDataResponse")]
    [AWSCmdlet("Calls the Payment Cryptography Data VerifyCardValidationData API operation.", Operation = new[] {"VerifyCardValidationData"}, SelectReturnType = typeof(Amazon.PaymentCryptographyData.Model.VerifyCardValidationDataResponse))]
    [AWSCmdletOutput("Amazon.PaymentCryptographyData.Model.VerifyCardValidationDataResponse",
        "This cmdlet returns an Amazon.PaymentCryptographyData.Model.VerifyCardValidationDataResponse object containing multiple properties."
    )]
    public partial class TestPAYCDCardValidationDataCmdlet : AmazonPaymentCryptographyDataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CardHolderVerificationValue_ApplicationTransactionCounter
        /// <summary>
        /// <para>
        /// <para>The transaction counter value that comes from a point of sale terminal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_CardHolderVerificationValue_ApplicationTransactionCounter")]
        public System.String CardHolderVerificationValue_ApplicationTransactionCounter { get; set; }
        #endregion
        
        #region Parameter DiscoverDynamicCardVerificationCode_ApplicationTransactionCounter
        /// <summary>
        /// <para>
        /// <para>The transaction counter value that comes from the terminal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_DiscoverDynamicCardVerificationCode_ApplicationTransactionCounter")]
        public System.String DiscoverDynamicCardVerificationCode_ApplicationTransactionCounter { get; set; }
        #endregion
        
        #region Parameter DynamicCardVerificationCode_ApplicationTransactionCounter
        /// <summary>
        /// <para>
        /// <para>The transaction counter value that comes from the terminal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_DynamicCardVerificationCode_ApplicationTransactionCounter")]
        public System.String DynamicCardVerificationCode_ApplicationTransactionCounter { get; set; }
        #endregion
        
        #region Parameter DynamicCardVerificationValue_ApplicationTransactionCounter
        /// <summary>
        /// <para>
        /// <para>The transaction counter value that comes from the terminal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_DynamicCardVerificationValue_ApplicationTransactionCounter")]
        public System.String DynamicCardVerificationValue_ApplicationTransactionCounter { get; set; }
        #endregion
        
        #region Parameter AmexCardSecurityCodeVersion1_CardExpiryDate
        /// <summary>
        /// <para>
        /// <para>The expiry date of a payment card.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_AmexCardSecurityCodeVersion1_CardExpiryDate")]
        public System.String AmexCardSecurityCodeVersion1_CardExpiryDate { get; set; }
        #endregion
        
        #region Parameter AmexCardSecurityCodeVersion2_CardExpiryDate
        /// <summary>
        /// <para>
        /// <para>The expiry date of a payment card.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_AmexCardSecurityCodeVersion2_CardExpiryDate")]
        public System.String AmexCardSecurityCodeVersion2_CardExpiryDate { get; set; }
        #endregion
        
        #region Parameter CardVerificationValue1_CardExpiryDate
        /// <summary>
        /// <para>
        /// <para>The expiry date of a payment card.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_CardVerificationValue1_CardExpiryDate")]
        public System.String CardVerificationValue1_CardExpiryDate { get; set; }
        #endregion
        
        #region Parameter CardVerificationValue2_CardExpiryDate
        /// <summary>
        /// <para>
        /// <para>The expiry date of a payment card.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_CardVerificationValue2_CardExpiryDate")]
        public System.String CardVerificationValue2_CardExpiryDate { get; set; }
        #endregion
        
        #region Parameter DiscoverDynamicCardVerificationCode_CardExpiryDate
        /// <summary>
        /// <para>
        /// <para>The expiry date of a payment card.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_DiscoverDynamicCardVerificationCode_CardExpiryDate")]
        public System.String DiscoverDynamicCardVerificationCode_CardExpiryDate { get; set; }
        #endregion
        
        #region Parameter DynamicCardVerificationValue_CardExpiryDate
        /// <summary>
        /// <para>
        /// <para>The expiry date of a payment card.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_DynamicCardVerificationValue_CardExpiryDate")]
        public System.String DynamicCardVerificationValue_CardExpiryDate { get; set; }
        #endregion
        
        #region Parameter KeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyARN</c> of the CVK encryption key that Amazon Web Services Payment Cryptography
        /// uses to verify card data.</para>
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
        
        #region Parameter CardHolderVerificationValue_PanSequenceNumber
        /// <summary>
        /// <para>
        /// <para>A number that identifies and differentiates payment cards with the same Primary Account
        /// Number (PAN).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_CardHolderVerificationValue_PanSequenceNumber")]
        public System.String CardHolderVerificationValue_PanSequenceNumber { get; set; }
        #endregion
        
        #region Parameter DynamicCardVerificationCode_PanSequenceNumber
        /// <summary>
        /// <para>
        /// <para>A number that identifies and differentiates payment cards with the same Primary Account
        /// Number (PAN).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_DynamicCardVerificationCode_PanSequenceNumber")]
        public System.String DynamicCardVerificationCode_PanSequenceNumber { get; set; }
        #endregion
        
        #region Parameter DynamicCardVerificationValue_PanSequenceNumber
        /// <summary>
        /// <para>
        /// <para>A number that identifies and differentiates payment cards with the same Primary Account
        /// Number (PAN).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_DynamicCardVerificationValue_PanSequenceNumber")]
        public System.String DynamicCardVerificationValue_PanSequenceNumber { get; set; }
        #endregion
        
        #region Parameter PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN), a unique identifier for a payment credit or debit
        /// card that associates the card with a specific account holder.</para>
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
        public System.String PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter AmexCardSecurityCodeVersion2_ServiceCode
        /// <summary>
        /// <para>
        /// <para>The service code of the AMEX payment card. This is different from the Card Security
        /// Code (CSC).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_AmexCardSecurityCodeVersion2_ServiceCode")]
        public System.String AmexCardSecurityCodeVersion2_ServiceCode { get; set; }
        #endregion
        
        #region Parameter CardVerificationValue1_ServiceCode
        /// <summary>
        /// <para>
        /// <para>The service code of the payment card. This is different from Card Security Code (CSC).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_CardVerificationValue1_ServiceCode")]
        public System.String CardVerificationValue1_ServiceCode { get; set; }
        #endregion
        
        #region Parameter DynamicCardVerificationValue_ServiceCode
        /// <summary>
        /// <para>
        /// <para>The service code of the payment card. This is different from Card Security Code (CSC).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_DynamicCardVerificationValue_ServiceCode")]
        public System.String DynamicCardVerificationValue_ServiceCode { get; set; }
        #endregion
        
        #region Parameter DynamicCardVerificationCode_TrackData
        /// <summary>
        /// <para>
        /// <para>The data on the two tracks of magnetic cards used for financial transactions. This
        /// includes the cardholder name, PAN, expiration date, bank ID (BIN) and several other
        /// numbers the issuing bank uses to validate the data received.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_DynamicCardVerificationCode_TrackData")]
        public System.String DynamicCardVerificationCode_TrackData { get; set; }
        #endregion
        
        #region Parameter CardHolderVerificationValue_UnpredictableNumber
        /// <summary>
        /// <para>
        /// <para>A random number generated by the issuer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_CardHolderVerificationValue_UnpredictableNumber")]
        public System.String CardHolderVerificationValue_UnpredictableNumber { get; set; }
        #endregion
        
        #region Parameter DiscoverDynamicCardVerificationCode_UnpredictableNumber
        /// <summary>
        /// <para>
        /// <para>A random number that is generated by the issuer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_DiscoverDynamicCardVerificationCode_UnpredictableNumber")]
        public System.String DiscoverDynamicCardVerificationCode_UnpredictableNumber { get; set; }
        #endregion
        
        #region Parameter DynamicCardVerificationCode_UnpredictableNumber
        /// <summary>
        /// <para>
        /// <para>A random number generated by the issuer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationAttributes_DynamicCardVerificationCode_UnpredictableNumber")]
        public System.String DynamicCardVerificationCode_UnpredictableNumber { get; set; }
        #endregion
        
        #region Parameter ValidationData
        /// <summary>
        /// <para>
        /// <para>The CVV or CSC value for use for card data verification within Amazon Web Services
        /// Payment Cryptography.</para>
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
        public System.String ValidationData { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PaymentCryptographyData.Model.VerifyCardValidationDataResponse).
        /// Specifying the name of a property of type Amazon.PaymentCryptographyData.Model.VerifyCardValidationDataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PaymentCryptographyData.Model.VerifyCardValidationDataResponse, TestPAYCDCardValidationDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.KeyIdentifier = this.KeyIdentifier;
            #if MODULAR
            if (this.KeyIdentifier == null && ParameterWasBound(nameof(this.KeyIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrimaryAccountNumber = this.PrimaryAccountNumber;
            #if MODULAR
            if (this.PrimaryAccountNumber == null && ParameterWasBound(nameof(this.PrimaryAccountNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter PrimaryAccountNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ValidationData = this.ValidationData;
            #if MODULAR
            if (this.ValidationData == null && ParameterWasBound(nameof(this.ValidationData)))
            {
                WriteWarning("You are passing $null as a value for parameter ValidationData which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AmexCardSecurityCodeVersion1_CardExpiryDate = this.AmexCardSecurityCodeVersion1_CardExpiryDate;
            context.AmexCardSecurityCodeVersion2_CardExpiryDate = this.AmexCardSecurityCodeVersion2_CardExpiryDate;
            context.AmexCardSecurityCodeVersion2_ServiceCode = this.AmexCardSecurityCodeVersion2_ServiceCode;
            context.CardHolderVerificationValue_ApplicationTransactionCounter = this.CardHolderVerificationValue_ApplicationTransactionCounter;
            context.CardHolderVerificationValue_PanSequenceNumber = this.CardHolderVerificationValue_PanSequenceNumber;
            context.CardHolderVerificationValue_UnpredictableNumber = this.CardHolderVerificationValue_UnpredictableNumber;
            context.CardVerificationValue1_CardExpiryDate = this.CardVerificationValue1_CardExpiryDate;
            context.CardVerificationValue1_ServiceCode = this.CardVerificationValue1_ServiceCode;
            context.CardVerificationValue2_CardExpiryDate = this.CardVerificationValue2_CardExpiryDate;
            context.DiscoverDynamicCardVerificationCode_ApplicationTransactionCounter = this.DiscoverDynamicCardVerificationCode_ApplicationTransactionCounter;
            context.DiscoverDynamicCardVerificationCode_CardExpiryDate = this.DiscoverDynamicCardVerificationCode_CardExpiryDate;
            context.DiscoverDynamicCardVerificationCode_UnpredictableNumber = this.DiscoverDynamicCardVerificationCode_UnpredictableNumber;
            context.DynamicCardVerificationCode_ApplicationTransactionCounter = this.DynamicCardVerificationCode_ApplicationTransactionCounter;
            context.DynamicCardVerificationCode_PanSequenceNumber = this.DynamicCardVerificationCode_PanSequenceNumber;
            context.DynamicCardVerificationCode_TrackData = this.DynamicCardVerificationCode_TrackData;
            context.DynamicCardVerificationCode_UnpredictableNumber = this.DynamicCardVerificationCode_UnpredictableNumber;
            context.DynamicCardVerificationValue_ApplicationTransactionCounter = this.DynamicCardVerificationValue_ApplicationTransactionCounter;
            context.DynamicCardVerificationValue_CardExpiryDate = this.DynamicCardVerificationValue_CardExpiryDate;
            context.DynamicCardVerificationValue_PanSequenceNumber = this.DynamicCardVerificationValue_PanSequenceNumber;
            context.DynamicCardVerificationValue_ServiceCode = this.DynamicCardVerificationValue_ServiceCode;
            
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
            var request = new Amazon.PaymentCryptographyData.Model.VerifyCardValidationDataRequest();
            
            if (cmdletContext.KeyIdentifier != null)
            {
                request.KeyIdentifier = cmdletContext.KeyIdentifier;
            }
            if (cmdletContext.PrimaryAccountNumber != null)
            {
                request.PrimaryAccountNumber = cmdletContext.PrimaryAccountNumber;
            }
            if (cmdletContext.ValidationData != null)
            {
                request.ValidationData = cmdletContext.ValidationData;
            }
            
             // populate VerificationAttributes
            var requestVerificationAttributesIsNull = true;
            request.VerificationAttributes = new Amazon.PaymentCryptographyData.Model.CardVerificationAttributes();
            Amazon.PaymentCryptographyData.Model.AmexCardSecurityCodeVersion1 requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion1 = null;
            
             // populate AmexCardSecurityCodeVersion1
            var requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion1IsNull = true;
            requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion1 = new Amazon.PaymentCryptographyData.Model.AmexCardSecurityCodeVersion1();
            System.String requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion1_amexCardSecurityCodeVersion1_CardExpiryDate = null;
            if (cmdletContext.AmexCardSecurityCodeVersion1_CardExpiryDate != null)
            {
                requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion1_amexCardSecurityCodeVersion1_CardExpiryDate = cmdletContext.AmexCardSecurityCodeVersion1_CardExpiryDate;
            }
            if (requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion1_amexCardSecurityCodeVersion1_CardExpiryDate != null)
            {
                requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion1.CardExpiryDate = requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion1_amexCardSecurityCodeVersion1_CardExpiryDate;
                requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion1IsNull = false;
            }
             // determine if requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion1 should be set to null
            if (requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion1IsNull)
            {
                requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion1 = null;
            }
            if (requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion1 != null)
            {
                request.VerificationAttributes.AmexCardSecurityCodeVersion1 = requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion1;
                requestVerificationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.CardVerificationValue2 requestVerificationAttributes_verificationAttributes_CardVerificationValue2 = null;
            
             // populate CardVerificationValue2
            var requestVerificationAttributes_verificationAttributes_CardVerificationValue2IsNull = true;
            requestVerificationAttributes_verificationAttributes_CardVerificationValue2 = new Amazon.PaymentCryptographyData.Model.CardVerificationValue2();
            System.String requestVerificationAttributes_verificationAttributes_CardVerificationValue2_cardVerificationValue2_CardExpiryDate = null;
            if (cmdletContext.CardVerificationValue2_CardExpiryDate != null)
            {
                requestVerificationAttributes_verificationAttributes_CardVerificationValue2_cardVerificationValue2_CardExpiryDate = cmdletContext.CardVerificationValue2_CardExpiryDate;
            }
            if (requestVerificationAttributes_verificationAttributes_CardVerificationValue2_cardVerificationValue2_CardExpiryDate != null)
            {
                requestVerificationAttributes_verificationAttributes_CardVerificationValue2.CardExpiryDate = requestVerificationAttributes_verificationAttributes_CardVerificationValue2_cardVerificationValue2_CardExpiryDate;
                requestVerificationAttributes_verificationAttributes_CardVerificationValue2IsNull = false;
            }
             // determine if requestVerificationAttributes_verificationAttributes_CardVerificationValue2 should be set to null
            if (requestVerificationAttributes_verificationAttributes_CardVerificationValue2IsNull)
            {
                requestVerificationAttributes_verificationAttributes_CardVerificationValue2 = null;
            }
            if (requestVerificationAttributes_verificationAttributes_CardVerificationValue2 != null)
            {
                request.VerificationAttributes.CardVerificationValue2 = requestVerificationAttributes_verificationAttributes_CardVerificationValue2;
                requestVerificationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.AmexCardSecurityCodeVersion2 requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion2 = null;
            
             // populate AmexCardSecurityCodeVersion2
            var requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion2IsNull = true;
            requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion2 = new Amazon.PaymentCryptographyData.Model.AmexCardSecurityCodeVersion2();
            System.String requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion2_amexCardSecurityCodeVersion2_CardExpiryDate = null;
            if (cmdletContext.AmexCardSecurityCodeVersion2_CardExpiryDate != null)
            {
                requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion2_amexCardSecurityCodeVersion2_CardExpiryDate = cmdletContext.AmexCardSecurityCodeVersion2_CardExpiryDate;
            }
            if (requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion2_amexCardSecurityCodeVersion2_CardExpiryDate != null)
            {
                requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion2.CardExpiryDate = requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion2_amexCardSecurityCodeVersion2_CardExpiryDate;
                requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion2IsNull = false;
            }
            System.String requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion2_amexCardSecurityCodeVersion2_ServiceCode = null;
            if (cmdletContext.AmexCardSecurityCodeVersion2_ServiceCode != null)
            {
                requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion2_amexCardSecurityCodeVersion2_ServiceCode = cmdletContext.AmexCardSecurityCodeVersion2_ServiceCode;
            }
            if (requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion2_amexCardSecurityCodeVersion2_ServiceCode != null)
            {
                requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion2.ServiceCode = requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion2_amexCardSecurityCodeVersion2_ServiceCode;
                requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion2IsNull = false;
            }
             // determine if requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion2 should be set to null
            if (requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion2IsNull)
            {
                requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion2 = null;
            }
            if (requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion2 != null)
            {
                request.VerificationAttributes.AmexCardSecurityCodeVersion2 = requestVerificationAttributes_verificationAttributes_AmexCardSecurityCodeVersion2;
                requestVerificationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.CardVerificationValue1 requestVerificationAttributes_verificationAttributes_CardVerificationValue1 = null;
            
             // populate CardVerificationValue1
            var requestVerificationAttributes_verificationAttributes_CardVerificationValue1IsNull = true;
            requestVerificationAttributes_verificationAttributes_CardVerificationValue1 = new Amazon.PaymentCryptographyData.Model.CardVerificationValue1();
            System.String requestVerificationAttributes_verificationAttributes_CardVerificationValue1_cardVerificationValue1_CardExpiryDate = null;
            if (cmdletContext.CardVerificationValue1_CardExpiryDate != null)
            {
                requestVerificationAttributes_verificationAttributes_CardVerificationValue1_cardVerificationValue1_CardExpiryDate = cmdletContext.CardVerificationValue1_CardExpiryDate;
            }
            if (requestVerificationAttributes_verificationAttributes_CardVerificationValue1_cardVerificationValue1_CardExpiryDate != null)
            {
                requestVerificationAttributes_verificationAttributes_CardVerificationValue1.CardExpiryDate = requestVerificationAttributes_verificationAttributes_CardVerificationValue1_cardVerificationValue1_CardExpiryDate;
                requestVerificationAttributes_verificationAttributes_CardVerificationValue1IsNull = false;
            }
            System.String requestVerificationAttributes_verificationAttributes_CardVerificationValue1_cardVerificationValue1_ServiceCode = null;
            if (cmdletContext.CardVerificationValue1_ServiceCode != null)
            {
                requestVerificationAttributes_verificationAttributes_CardVerificationValue1_cardVerificationValue1_ServiceCode = cmdletContext.CardVerificationValue1_ServiceCode;
            }
            if (requestVerificationAttributes_verificationAttributes_CardVerificationValue1_cardVerificationValue1_ServiceCode != null)
            {
                requestVerificationAttributes_verificationAttributes_CardVerificationValue1.ServiceCode = requestVerificationAttributes_verificationAttributes_CardVerificationValue1_cardVerificationValue1_ServiceCode;
                requestVerificationAttributes_verificationAttributes_CardVerificationValue1IsNull = false;
            }
             // determine if requestVerificationAttributes_verificationAttributes_CardVerificationValue1 should be set to null
            if (requestVerificationAttributes_verificationAttributes_CardVerificationValue1IsNull)
            {
                requestVerificationAttributes_verificationAttributes_CardVerificationValue1 = null;
            }
            if (requestVerificationAttributes_verificationAttributes_CardVerificationValue1 != null)
            {
                request.VerificationAttributes.CardVerificationValue1 = requestVerificationAttributes_verificationAttributes_CardVerificationValue1;
                requestVerificationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.CardHolderVerificationValue requestVerificationAttributes_verificationAttributes_CardHolderVerificationValue = null;
            
             // populate CardHolderVerificationValue
            var requestVerificationAttributes_verificationAttributes_CardHolderVerificationValueIsNull = true;
            requestVerificationAttributes_verificationAttributes_CardHolderVerificationValue = new Amazon.PaymentCryptographyData.Model.CardHolderVerificationValue();
            System.String requestVerificationAttributes_verificationAttributes_CardHolderVerificationValue_cardHolderVerificationValue_ApplicationTransactionCounter = null;
            if (cmdletContext.CardHolderVerificationValue_ApplicationTransactionCounter != null)
            {
                requestVerificationAttributes_verificationAttributes_CardHolderVerificationValue_cardHolderVerificationValue_ApplicationTransactionCounter = cmdletContext.CardHolderVerificationValue_ApplicationTransactionCounter;
            }
            if (requestVerificationAttributes_verificationAttributes_CardHolderVerificationValue_cardHolderVerificationValue_ApplicationTransactionCounter != null)
            {
                requestVerificationAttributes_verificationAttributes_CardHolderVerificationValue.ApplicationTransactionCounter = requestVerificationAttributes_verificationAttributes_CardHolderVerificationValue_cardHolderVerificationValue_ApplicationTransactionCounter;
                requestVerificationAttributes_verificationAttributes_CardHolderVerificationValueIsNull = false;
            }
            System.String requestVerificationAttributes_verificationAttributes_CardHolderVerificationValue_cardHolderVerificationValue_PanSequenceNumber = null;
            if (cmdletContext.CardHolderVerificationValue_PanSequenceNumber != null)
            {
                requestVerificationAttributes_verificationAttributes_CardHolderVerificationValue_cardHolderVerificationValue_PanSequenceNumber = cmdletContext.CardHolderVerificationValue_PanSequenceNumber;
            }
            if (requestVerificationAttributes_verificationAttributes_CardHolderVerificationValue_cardHolderVerificationValue_PanSequenceNumber != null)
            {
                requestVerificationAttributes_verificationAttributes_CardHolderVerificationValue.PanSequenceNumber = requestVerificationAttributes_verificationAttributes_CardHolderVerificationValue_cardHolderVerificationValue_PanSequenceNumber;
                requestVerificationAttributes_verificationAttributes_CardHolderVerificationValueIsNull = false;
            }
            System.String requestVerificationAttributes_verificationAttributes_CardHolderVerificationValue_cardHolderVerificationValue_UnpredictableNumber = null;
            if (cmdletContext.CardHolderVerificationValue_UnpredictableNumber != null)
            {
                requestVerificationAttributes_verificationAttributes_CardHolderVerificationValue_cardHolderVerificationValue_UnpredictableNumber = cmdletContext.CardHolderVerificationValue_UnpredictableNumber;
            }
            if (requestVerificationAttributes_verificationAttributes_CardHolderVerificationValue_cardHolderVerificationValue_UnpredictableNumber != null)
            {
                requestVerificationAttributes_verificationAttributes_CardHolderVerificationValue.UnpredictableNumber = requestVerificationAttributes_verificationAttributes_CardHolderVerificationValue_cardHolderVerificationValue_UnpredictableNumber;
                requestVerificationAttributes_verificationAttributes_CardHolderVerificationValueIsNull = false;
            }
             // determine if requestVerificationAttributes_verificationAttributes_CardHolderVerificationValue should be set to null
            if (requestVerificationAttributes_verificationAttributes_CardHolderVerificationValueIsNull)
            {
                requestVerificationAttributes_verificationAttributes_CardHolderVerificationValue = null;
            }
            if (requestVerificationAttributes_verificationAttributes_CardHolderVerificationValue != null)
            {
                request.VerificationAttributes.CardHolderVerificationValue = requestVerificationAttributes_verificationAttributes_CardHolderVerificationValue;
                requestVerificationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.DiscoverDynamicCardVerificationCode requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCode = null;
            
             // populate DiscoverDynamicCardVerificationCode
            var requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCodeIsNull = true;
            requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCode = new Amazon.PaymentCryptographyData.Model.DiscoverDynamicCardVerificationCode();
            System.String requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCode_discoverDynamicCardVerificationCode_ApplicationTransactionCounter = null;
            if (cmdletContext.DiscoverDynamicCardVerificationCode_ApplicationTransactionCounter != null)
            {
                requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCode_discoverDynamicCardVerificationCode_ApplicationTransactionCounter = cmdletContext.DiscoverDynamicCardVerificationCode_ApplicationTransactionCounter;
            }
            if (requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCode_discoverDynamicCardVerificationCode_ApplicationTransactionCounter != null)
            {
                requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCode.ApplicationTransactionCounter = requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCode_discoverDynamicCardVerificationCode_ApplicationTransactionCounter;
                requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCodeIsNull = false;
            }
            System.String requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCode_discoverDynamicCardVerificationCode_CardExpiryDate = null;
            if (cmdletContext.DiscoverDynamicCardVerificationCode_CardExpiryDate != null)
            {
                requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCode_discoverDynamicCardVerificationCode_CardExpiryDate = cmdletContext.DiscoverDynamicCardVerificationCode_CardExpiryDate;
            }
            if (requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCode_discoverDynamicCardVerificationCode_CardExpiryDate != null)
            {
                requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCode.CardExpiryDate = requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCode_discoverDynamicCardVerificationCode_CardExpiryDate;
                requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCodeIsNull = false;
            }
            System.String requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCode_discoverDynamicCardVerificationCode_UnpredictableNumber = null;
            if (cmdletContext.DiscoverDynamicCardVerificationCode_UnpredictableNumber != null)
            {
                requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCode_discoverDynamicCardVerificationCode_UnpredictableNumber = cmdletContext.DiscoverDynamicCardVerificationCode_UnpredictableNumber;
            }
            if (requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCode_discoverDynamicCardVerificationCode_UnpredictableNumber != null)
            {
                requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCode.UnpredictableNumber = requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCode_discoverDynamicCardVerificationCode_UnpredictableNumber;
                requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCodeIsNull = false;
            }
             // determine if requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCode should be set to null
            if (requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCodeIsNull)
            {
                requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCode = null;
            }
            if (requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCode != null)
            {
                request.VerificationAttributes.DiscoverDynamicCardVerificationCode = requestVerificationAttributes_verificationAttributes_DiscoverDynamicCardVerificationCode;
                requestVerificationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.DynamicCardVerificationCode requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode = null;
            
             // populate DynamicCardVerificationCode
            var requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCodeIsNull = true;
            requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode = new Amazon.PaymentCryptographyData.Model.DynamicCardVerificationCode();
            System.String requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode_dynamicCardVerificationCode_ApplicationTransactionCounter = null;
            if (cmdletContext.DynamicCardVerificationCode_ApplicationTransactionCounter != null)
            {
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode_dynamicCardVerificationCode_ApplicationTransactionCounter = cmdletContext.DynamicCardVerificationCode_ApplicationTransactionCounter;
            }
            if (requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode_dynamicCardVerificationCode_ApplicationTransactionCounter != null)
            {
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode.ApplicationTransactionCounter = requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode_dynamicCardVerificationCode_ApplicationTransactionCounter;
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCodeIsNull = false;
            }
            System.String requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode_dynamicCardVerificationCode_PanSequenceNumber = null;
            if (cmdletContext.DynamicCardVerificationCode_PanSequenceNumber != null)
            {
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode_dynamicCardVerificationCode_PanSequenceNumber = cmdletContext.DynamicCardVerificationCode_PanSequenceNumber;
            }
            if (requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode_dynamicCardVerificationCode_PanSequenceNumber != null)
            {
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode.PanSequenceNumber = requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode_dynamicCardVerificationCode_PanSequenceNumber;
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCodeIsNull = false;
            }
            System.String requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode_dynamicCardVerificationCode_TrackData = null;
            if (cmdletContext.DynamicCardVerificationCode_TrackData != null)
            {
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode_dynamicCardVerificationCode_TrackData = cmdletContext.DynamicCardVerificationCode_TrackData;
            }
            if (requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode_dynamicCardVerificationCode_TrackData != null)
            {
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode.TrackData = requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode_dynamicCardVerificationCode_TrackData;
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCodeIsNull = false;
            }
            System.String requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode_dynamicCardVerificationCode_UnpredictableNumber = null;
            if (cmdletContext.DynamicCardVerificationCode_UnpredictableNumber != null)
            {
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode_dynamicCardVerificationCode_UnpredictableNumber = cmdletContext.DynamicCardVerificationCode_UnpredictableNumber;
            }
            if (requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode_dynamicCardVerificationCode_UnpredictableNumber != null)
            {
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode.UnpredictableNumber = requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode_dynamicCardVerificationCode_UnpredictableNumber;
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCodeIsNull = false;
            }
             // determine if requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode should be set to null
            if (requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCodeIsNull)
            {
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode = null;
            }
            if (requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode != null)
            {
                request.VerificationAttributes.DynamicCardVerificationCode = requestVerificationAttributes_verificationAttributes_DynamicCardVerificationCode;
                requestVerificationAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.DynamicCardVerificationValue requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue = null;
            
             // populate DynamicCardVerificationValue
            var requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValueIsNull = true;
            requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue = new Amazon.PaymentCryptographyData.Model.DynamicCardVerificationValue();
            System.String requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue_dynamicCardVerificationValue_ApplicationTransactionCounter = null;
            if (cmdletContext.DynamicCardVerificationValue_ApplicationTransactionCounter != null)
            {
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue_dynamicCardVerificationValue_ApplicationTransactionCounter = cmdletContext.DynamicCardVerificationValue_ApplicationTransactionCounter;
            }
            if (requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue_dynamicCardVerificationValue_ApplicationTransactionCounter != null)
            {
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue.ApplicationTransactionCounter = requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue_dynamicCardVerificationValue_ApplicationTransactionCounter;
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValueIsNull = false;
            }
            System.String requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue_dynamicCardVerificationValue_CardExpiryDate = null;
            if (cmdletContext.DynamicCardVerificationValue_CardExpiryDate != null)
            {
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue_dynamicCardVerificationValue_CardExpiryDate = cmdletContext.DynamicCardVerificationValue_CardExpiryDate;
            }
            if (requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue_dynamicCardVerificationValue_CardExpiryDate != null)
            {
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue.CardExpiryDate = requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue_dynamicCardVerificationValue_CardExpiryDate;
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValueIsNull = false;
            }
            System.String requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue_dynamicCardVerificationValue_PanSequenceNumber = null;
            if (cmdletContext.DynamicCardVerificationValue_PanSequenceNumber != null)
            {
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue_dynamicCardVerificationValue_PanSequenceNumber = cmdletContext.DynamicCardVerificationValue_PanSequenceNumber;
            }
            if (requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue_dynamicCardVerificationValue_PanSequenceNumber != null)
            {
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue.PanSequenceNumber = requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue_dynamicCardVerificationValue_PanSequenceNumber;
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValueIsNull = false;
            }
            System.String requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue_dynamicCardVerificationValue_ServiceCode = null;
            if (cmdletContext.DynamicCardVerificationValue_ServiceCode != null)
            {
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue_dynamicCardVerificationValue_ServiceCode = cmdletContext.DynamicCardVerificationValue_ServiceCode;
            }
            if (requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue_dynamicCardVerificationValue_ServiceCode != null)
            {
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue.ServiceCode = requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue_dynamicCardVerificationValue_ServiceCode;
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValueIsNull = false;
            }
             // determine if requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue should be set to null
            if (requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValueIsNull)
            {
                requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue = null;
            }
            if (requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue != null)
            {
                request.VerificationAttributes.DynamicCardVerificationValue = requestVerificationAttributes_verificationAttributes_DynamicCardVerificationValue;
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
        
        private Amazon.PaymentCryptographyData.Model.VerifyCardValidationDataResponse CallAWSServiceOperation(IAmazonPaymentCryptographyData client, Amazon.PaymentCryptographyData.Model.VerifyCardValidationDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Payment Cryptography Data", "VerifyCardValidationData");
            try
            {
                #if DESKTOP
                return client.VerifyCardValidationData(request);
                #elif CORECLR
                return client.VerifyCardValidationDataAsync(request).GetAwaiter().GetResult();
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
            public System.String KeyIdentifier { get; set; }
            public System.String PrimaryAccountNumber { get; set; }
            public System.String ValidationData { get; set; }
            public System.String AmexCardSecurityCodeVersion1_CardExpiryDate { get; set; }
            public System.String AmexCardSecurityCodeVersion2_CardExpiryDate { get; set; }
            public System.String AmexCardSecurityCodeVersion2_ServiceCode { get; set; }
            public System.String CardHolderVerificationValue_ApplicationTransactionCounter { get; set; }
            public System.String CardHolderVerificationValue_PanSequenceNumber { get; set; }
            public System.String CardHolderVerificationValue_UnpredictableNumber { get; set; }
            public System.String CardVerificationValue1_CardExpiryDate { get; set; }
            public System.String CardVerificationValue1_ServiceCode { get; set; }
            public System.String CardVerificationValue2_CardExpiryDate { get; set; }
            public System.String DiscoverDynamicCardVerificationCode_ApplicationTransactionCounter { get; set; }
            public System.String DiscoverDynamicCardVerificationCode_CardExpiryDate { get; set; }
            public System.String DiscoverDynamicCardVerificationCode_UnpredictableNumber { get; set; }
            public System.String DynamicCardVerificationCode_ApplicationTransactionCounter { get; set; }
            public System.String DynamicCardVerificationCode_PanSequenceNumber { get; set; }
            public System.String DynamicCardVerificationCode_TrackData { get; set; }
            public System.String DynamicCardVerificationCode_UnpredictableNumber { get; set; }
            public System.String DynamicCardVerificationValue_ApplicationTransactionCounter { get; set; }
            public System.String DynamicCardVerificationValue_CardExpiryDate { get; set; }
            public System.String DynamicCardVerificationValue_PanSequenceNumber { get; set; }
            public System.String DynamicCardVerificationValue_ServiceCode { get; set; }
            public System.Func<Amazon.PaymentCryptographyData.Model.VerifyCardValidationDataResponse, TestPAYCDCardValidationDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
