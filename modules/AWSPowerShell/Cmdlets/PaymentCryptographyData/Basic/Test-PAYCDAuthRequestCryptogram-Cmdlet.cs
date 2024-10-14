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
    /// Verifies Authorization Request Cryptogram (ARQC) for a EMV chip payment card authorization.
    /// For more information, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/data-operations.verifyauthrequestcryptogram.html">Verify
    /// auth request cryptogram</a> in the <i>Amazon Web Services Payment Cryptography User
    /// Guide</i>.
    /// 
    ///  
    /// <para>
    /// ARQC generation is done outside of Amazon Web Services Payment Cryptography and is
    /// typically generated on a point of sale terminal for an EMV chip card to obtain payment
    /// authorization during transaction time. For ARQC verification, you must first import
    /// the ARQC generated outside of Amazon Web Services Payment Cryptography by calling
    /// <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_ImportKey.html">ImportKey</a>.
    /// This operation uses the imported ARQC and an major encryption key (DUKPT) created
    /// by calling <a href="https://docs.aws.amazon.com/payment-cryptography/latest/APIReference/API_CreateKey.html">CreateKey</a>
    /// to either provide a boolean ARQC verification result or provide an APRC (Authorization
    /// Response Cryptogram) response using Method 1 or Method 2. The <c>ARPC_METHOD_1</c>
    /// uses <c>AuthResponseCode</c> to generate ARPC and <c>ARPC_METHOD_2</c> uses <c>CardStatusUpdate</c>
    /// to generate ARPC. 
    /// </para><para>
    /// For information about valid keys for this operation, see <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/keys-validattributes.html">Understanding
    /// key attributes</a> and <a href="https://docs.aws.amazon.com/payment-cryptography/latest/userguide/crypto-ops-validkeys-ops.html">Key
    /// types for specific data operations</a> in the <i>Amazon Web Services Payment Cryptography
    /// User Guide</i>.
    /// </para><para><b>Cross-account use</b>: This operation can't be used across different Amazon Web
    /// Services accounts.
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>VerifyCardValidationData</a></para></li><li><para><a>VerifyPinData</a></para></li></ul>
    /// </summary>
    [Cmdlet("Test", "PAYCDAuthRequestCryptogram")]
    [OutputType("Amazon.PaymentCryptographyData.Model.VerifyAuthRequestCryptogramResponse")]
    [AWSCmdlet("Calls the Payment Cryptography Data VerifyAuthRequestCryptogram API operation.", Operation = new[] {"VerifyAuthRequestCryptogram"}, SelectReturnType = typeof(Amazon.PaymentCryptographyData.Model.VerifyAuthRequestCryptogramResponse))]
    [AWSCmdletOutput("Amazon.PaymentCryptographyData.Model.VerifyAuthRequestCryptogramResponse",
        "This cmdlet returns an Amazon.PaymentCryptographyData.Model.VerifyAuthRequestCryptogramResponse object containing multiple properties."
    )]
    public partial class TestPAYCDAuthRequestCryptogramCmdlet : AmazonPaymentCryptographyDataClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Emv2000_ApplicationTransactionCounter
        /// <summary>
        /// <para>
        /// <para>The transaction counter that is provided by the terminal during transaction processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionKeyDerivationAttributes_Emv2000_ApplicationTransactionCounter")]
        public System.String Emv2000_ApplicationTransactionCounter { get; set; }
        #endregion
        
        #region Parameter EmvCommon_ApplicationTransactionCounter
        /// <summary>
        /// <para>
        /// <para>The transaction counter that is provided by the terminal during transaction processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionKeyDerivationAttributes_EmvCommon_ApplicationTransactionCounter")]
        public System.String EmvCommon_ApplicationTransactionCounter { get; set; }
        #endregion
        
        #region Parameter Mastercard_ApplicationTransactionCounter
        /// <summary>
        /// <para>
        /// <para>The transaction counter that is provided by the terminal during transaction processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionKeyDerivationAttributes_Mastercard_ApplicationTransactionCounter")]
        public System.String Mastercard_ApplicationTransactionCounter { get; set; }
        #endregion
        
        #region Parameter AuthRequestCryptogram
        /// <summary>
        /// <para>
        /// <para>The auth request cryptogram imported into Amazon Web Services Payment Cryptography
        /// for ARQC verification using a major encryption key and transaction data.</para>
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
        public System.String AuthRequestCryptogram { get; set; }
        #endregion
        
        #region Parameter ArpcMethod1_AuthResponseCode
        /// <summary>
        /// <para>
        /// <para>The auth code used to calculate APRC after ARQC verification is successful. This is
        /// the same auth code used for ARQC generation outside of Amazon Web Services Payment
        /// Cryptography.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthResponseAttributes_ArpcMethod1_AuthResponseCode")]
        public System.String ArpcMethod1_AuthResponseCode { get; set; }
        #endregion
        
        #region Parameter ArpcMethod2_CardStatusUpdate
        /// <summary>
        /// <para>
        /// <para>The data indicating whether the issuer approves or declines an online transaction
        /// using an EMV chip card.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthResponseAttributes_ArpcMethod2_CardStatusUpdate")]
        public System.String ArpcMethod2_CardStatusUpdate { get; set; }
        #endregion
        
        #region Parameter KeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The <c>keyARN</c> of the major encryption key that Amazon Web Services Payment Cryptography
        /// uses for ARQC verification.</para>
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
        
        #region Parameter MajorKeyDerivationMode
        /// <summary>
        /// <para>
        /// <para>The method to use when deriving the major encryption key for ARQC verification within
        /// Amazon Web Services Payment Cryptography. The same key derivation mode was used for
        /// ARQC generation outside of Amazon Web Services Payment Cryptography.</para>
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
        
        #region Parameter Amex_PanSequenceNumber
        /// <summary>
        /// <para>
        /// <para>A number that identifies and differentiates payment cards with the same Primary Account
        /// Number (PAN).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionKeyDerivationAttributes_Amex_PanSequenceNumber")]
        public System.String Amex_PanSequenceNumber { get; set; }
        #endregion
        
        #region Parameter Emv2000_PanSequenceNumber
        /// <summary>
        /// <para>
        /// <para>A number that identifies and differentiates payment cards with the same Primary Account
        /// Number (PAN).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionKeyDerivationAttributes_Emv2000_PanSequenceNumber")]
        public System.String Emv2000_PanSequenceNumber { get; set; }
        #endregion
        
        #region Parameter EmvCommon_PanSequenceNumber
        /// <summary>
        /// <para>
        /// <para>A number that identifies and differentiates payment cards with the same Primary Account
        /// Number (PAN).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionKeyDerivationAttributes_EmvCommon_PanSequenceNumber")]
        public System.String EmvCommon_PanSequenceNumber { get; set; }
        #endregion
        
        #region Parameter Mastercard_PanSequenceNumber
        /// <summary>
        /// <para>
        /// <para>A number that identifies and differentiates payment cards with the same Primary Account
        /// Number (PAN).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionKeyDerivationAttributes_Mastercard_PanSequenceNumber")]
        public System.String Mastercard_PanSequenceNumber { get; set; }
        #endregion
        
        #region Parameter Visa_PanSequenceNumber
        /// <summary>
        /// <para>
        /// <para>A number that identifies and differentiates payment cards with the same Primary Account
        /// Number (PAN).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionKeyDerivationAttributes_Visa_PanSequenceNumber")]
        public System.String Visa_PanSequenceNumber { get; set; }
        #endregion
        
        #region Parameter Amex_PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN) of the cardholder. A PAN is a unique identifier for
        /// a payment credit or debit card and associates the card to a specific account holder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionKeyDerivationAttributes_Amex_PrimaryAccountNumber")]
        public System.String Amex_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter Emv2000_PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN) of the cardholder. A PAN is a unique identifier for
        /// a payment credit or debit card and associates the card to a specific account holder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionKeyDerivationAttributes_Emv2000_PrimaryAccountNumber")]
        public System.String Emv2000_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter EmvCommon_PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN) of the cardholder. A PAN is a unique identifier for
        /// a payment credit or debit card and associates the card to a specific account holder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionKeyDerivationAttributes_EmvCommon_PrimaryAccountNumber")]
        public System.String EmvCommon_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter Mastercard_PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN) of the cardholder. A PAN is a unique identifier for
        /// a payment credit or debit card and associates the card to a specific account holder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionKeyDerivationAttributes_Mastercard_PrimaryAccountNumber")]
        public System.String Mastercard_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter Visa_PrimaryAccountNumber
        /// <summary>
        /// <para>
        /// <para>The Primary Account Number (PAN) of the cardholder. A PAN is a unique identifier for
        /// a payment credit or debit card and associates the card to a specific account holder.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionKeyDerivationAttributes_Visa_PrimaryAccountNumber")]
        public System.String Visa_PrimaryAccountNumber { get; set; }
        #endregion
        
        #region Parameter ArpcMethod2_ProprietaryAuthenticationData
        /// <summary>
        /// <para>
        /// <para>The proprietary authentication data used by issuer for communication during online
        /// transaction using an EMV chip card.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AuthResponseAttributes_ArpcMethod2_ProprietaryAuthenticationData")]
        public System.String ArpcMethod2_ProprietaryAuthenticationData { get; set; }
        #endregion
        
        #region Parameter TransactionData
        /// <summary>
        /// <para>
        /// <para>The transaction data that Amazon Web Services Payment Cryptography uses for ARQC verification.
        /// The same transaction is used for ARQC generation outside of Amazon Web Services Payment
        /// Cryptography.</para>
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
        
        #region Parameter Mastercard_UnpredictableNumber
        /// <summary>
        /// <para>
        /// <para>A random number generated by the issuer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionKeyDerivationAttributes_Mastercard_UnpredictableNumber")]
        public System.String Mastercard_UnpredictableNumber { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PaymentCryptographyData.Model.VerifyAuthRequestCryptogramResponse).
        /// Specifying the name of a property of type Amazon.PaymentCryptographyData.Model.VerifyAuthRequestCryptogramResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PaymentCryptographyData.Model.VerifyAuthRequestCryptogramResponse, TestPAYCDAuthRequestCryptogramCmdlet>(Select) ??
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
            context.AuthRequestCryptogram = this.AuthRequestCryptogram;
            #if MODULAR
            if (this.AuthRequestCryptogram == null && ParameterWasBound(nameof(this.AuthRequestCryptogram)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthRequestCryptogram which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ArpcMethod1_AuthResponseCode = this.ArpcMethod1_AuthResponseCode;
            context.ArpcMethod2_CardStatusUpdate = this.ArpcMethod2_CardStatusUpdate;
            context.ArpcMethod2_ProprietaryAuthenticationData = this.ArpcMethod2_ProprietaryAuthenticationData;
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
            context.Amex_PanSequenceNumber = this.Amex_PanSequenceNumber;
            context.Amex_PrimaryAccountNumber = this.Amex_PrimaryAccountNumber;
            context.Emv2000_ApplicationTransactionCounter = this.Emv2000_ApplicationTransactionCounter;
            context.Emv2000_PanSequenceNumber = this.Emv2000_PanSequenceNumber;
            context.Emv2000_PrimaryAccountNumber = this.Emv2000_PrimaryAccountNumber;
            context.EmvCommon_ApplicationTransactionCounter = this.EmvCommon_ApplicationTransactionCounter;
            context.EmvCommon_PanSequenceNumber = this.EmvCommon_PanSequenceNumber;
            context.EmvCommon_PrimaryAccountNumber = this.EmvCommon_PrimaryAccountNumber;
            context.Mastercard_ApplicationTransactionCounter = this.Mastercard_ApplicationTransactionCounter;
            context.Mastercard_PanSequenceNumber = this.Mastercard_PanSequenceNumber;
            context.Mastercard_PrimaryAccountNumber = this.Mastercard_PrimaryAccountNumber;
            context.Mastercard_UnpredictableNumber = this.Mastercard_UnpredictableNumber;
            context.Visa_PanSequenceNumber = this.Visa_PanSequenceNumber;
            context.Visa_PrimaryAccountNumber = this.Visa_PrimaryAccountNumber;
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
            var request = new Amazon.PaymentCryptographyData.Model.VerifyAuthRequestCryptogramRequest();
            
            if (cmdletContext.AuthRequestCryptogram != null)
            {
                request.AuthRequestCryptogram = cmdletContext.AuthRequestCryptogram;
            }
            
             // populate AuthResponseAttributes
            var requestAuthResponseAttributesIsNull = true;
            request.AuthResponseAttributes = new Amazon.PaymentCryptographyData.Model.CryptogramAuthResponse();
            Amazon.PaymentCryptographyData.Model.CryptogramVerificationArpcMethod1 requestAuthResponseAttributes_authResponseAttributes_ArpcMethod1 = null;
            
             // populate ArpcMethod1
            var requestAuthResponseAttributes_authResponseAttributes_ArpcMethod1IsNull = true;
            requestAuthResponseAttributes_authResponseAttributes_ArpcMethod1 = new Amazon.PaymentCryptographyData.Model.CryptogramVerificationArpcMethod1();
            System.String requestAuthResponseAttributes_authResponseAttributes_ArpcMethod1_arpcMethod1_AuthResponseCode = null;
            if (cmdletContext.ArpcMethod1_AuthResponseCode != null)
            {
                requestAuthResponseAttributes_authResponseAttributes_ArpcMethod1_arpcMethod1_AuthResponseCode = cmdletContext.ArpcMethod1_AuthResponseCode;
            }
            if (requestAuthResponseAttributes_authResponseAttributes_ArpcMethod1_arpcMethod1_AuthResponseCode != null)
            {
                requestAuthResponseAttributes_authResponseAttributes_ArpcMethod1.AuthResponseCode = requestAuthResponseAttributes_authResponseAttributes_ArpcMethod1_arpcMethod1_AuthResponseCode;
                requestAuthResponseAttributes_authResponseAttributes_ArpcMethod1IsNull = false;
            }
             // determine if requestAuthResponseAttributes_authResponseAttributes_ArpcMethod1 should be set to null
            if (requestAuthResponseAttributes_authResponseAttributes_ArpcMethod1IsNull)
            {
                requestAuthResponseAttributes_authResponseAttributes_ArpcMethod1 = null;
            }
            if (requestAuthResponseAttributes_authResponseAttributes_ArpcMethod1 != null)
            {
                request.AuthResponseAttributes.ArpcMethod1 = requestAuthResponseAttributes_authResponseAttributes_ArpcMethod1;
                requestAuthResponseAttributesIsNull = false;
            }
            Amazon.PaymentCryptographyData.Model.CryptogramVerificationArpcMethod2 requestAuthResponseAttributes_authResponseAttributes_ArpcMethod2 = null;
            
             // populate ArpcMethod2
            var requestAuthResponseAttributes_authResponseAttributes_ArpcMethod2IsNull = true;
            requestAuthResponseAttributes_authResponseAttributes_ArpcMethod2 = new Amazon.PaymentCryptographyData.Model.CryptogramVerificationArpcMethod2();
            System.String requestAuthResponseAttributes_authResponseAttributes_ArpcMethod2_arpcMethod2_CardStatusUpdate = null;
            if (cmdletContext.ArpcMethod2_CardStatusUpdate != null)
            {
                requestAuthResponseAttributes_authResponseAttributes_ArpcMethod2_arpcMethod2_CardStatusUpdate = cmdletContext.ArpcMethod2_CardStatusUpdate;
            }
            if (requestAuthResponseAttributes_authResponseAttributes_ArpcMethod2_arpcMethod2_CardStatusUpdate != null)
            {
                requestAuthResponseAttributes_authResponseAttributes_ArpcMethod2.CardStatusUpdate = requestAuthResponseAttributes_authResponseAttributes_ArpcMethod2_arpcMethod2_CardStatusUpdate;
                requestAuthResponseAttributes_authResponseAttributes_ArpcMethod2IsNull = false;
            }
            System.String requestAuthResponseAttributes_authResponseAttributes_ArpcMethod2_arpcMethod2_ProprietaryAuthenticationData = null;
            if (cmdletContext.ArpcMethod2_ProprietaryAuthenticationData != null)
            {
                requestAuthResponseAttributes_authResponseAttributes_ArpcMethod2_arpcMethod2_ProprietaryAuthenticationData = cmdletContext.ArpcMethod2_ProprietaryAuthenticationData;
            }
            if (requestAuthResponseAttributes_authResponseAttributes_ArpcMethod2_arpcMethod2_ProprietaryAuthenticationData != null)
            {
                requestAuthResponseAttributes_authResponseAttributes_ArpcMethod2.ProprietaryAuthenticationData = requestAuthResponseAttributes_authResponseAttributes_ArpcMethod2_arpcMethod2_ProprietaryAuthenticationData;
                requestAuthResponseAttributes_authResponseAttributes_ArpcMethod2IsNull = false;
            }
             // determine if requestAuthResponseAttributes_authResponseAttributes_ArpcMethod2 should be set to null
            if (requestAuthResponseAttributes_authResponseAttributes_ArpcMethod2IsNull)
            {
                requestAuthResponseAttributes_authResponseAttributes_ArpcMethod2 = null;
            }
            if (requestAuthResponseAttributes_authResponseAttributes_ArpcMethod2 != null)
            {
                request.AuthResponseAttributes.ArpcMethod2 = requestAuthResponseAttributes_authResponseAttributes_ArpcMethod2;
                requestAuthResponseAttributesIsNull = false;
            }
             // determine if request.AuthResponseAttributes should be set to null
            if (requestAuthResponseAttributesIsNull)
            {
                request.AuthResponseAttributes = null;
            }
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
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex_amex_PanSequenceNumber = null;
            if (cmdletContext.Amex_PanSequenceNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex_amex_PanSequenceNumber = cmdletContext.Amex_PanSequenceNumber;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex_amex_PanSequenceNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex.PanSequenceNumber = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex_amex_PanSequenceNumber;
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_AmexIsNull = false;
            }
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex_amex_PrimaryAccountNumber = null;
            if (cmdletContext.Amex_PrimaryAccountNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex_amex_PrimaryAccountNumber = cmdletContext.Amex_PrimaryAccountNumber;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex_amex_PrimaryAccountNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex.PrimaryAccountNumber = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Amex_amex_PrimaryAccountNumber;
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
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa_visa_PanSequenceNumber = null;
            if (cmdletContext.Visa_PanSequenceNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa_visa_PanSequenceNumber = cmdletContext.Visa_PanSequenceNumber;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa_visa_PanSequenceNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa.PanSequenceNumber = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa_visa_PanSequenceNumber;
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_VisaIsNull = false;
            }
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa_visa_PrimaryAccountNumber = null;
            if (cmdletContext.Visa_PrimaryAccountNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa_visa_PrimaryAccountNumber = cmdletContext.Visa_PrimaryAccountNumber;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa_visa_PrimaryAccountNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa.PrimaryAccountNumber = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Visa_visa_PrimaryAccountNumber;
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
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_emv2000_ApplicationTransactionCounter = null;
            if (cmdletContext.Emv2000_ApplicationTransactionCounter != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_emv2000_ApplicationTransactionCounter = cmdletContext.Emv2000_ApplicationTransactionCounter;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_emv2000_ApplicationTransactionCounter != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000.ApplicationTransactionCounter = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_emv2000_ApplicationTransactionCounter;
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000IsNull = false;
            }
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_emv2000_PanSequenceNumber = null;
            if (cmdletContext.Emv2000_PanSequenceNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_emv2000_PanSequenceNumber = cmdletContext.Emv2000_PanSequenceNumber;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_emv2000_PanSequenceNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000.PanSequenceNumber = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_emv2000_PanSequenceNumber;
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000IsNull = false;
            }
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_emv2000_PrimaryAccountNumber = null;
            if (cmdletContext.Emv2000_PrimaryAccountNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_emv2000_PrimaryAccountNumber = cmdletContext.Emv2000_PrimaryAccountNumber;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_emv2000_PrimaryAccountNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000.PrimaryAccountNumber = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Emv2000_emv2000_PrimaryAccountNumber;
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
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_emvCommon_ApplicationTransactionCounter = null;
            if (cmdletContext.EmvCommon_ApplicationTransactionCounter != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_emvCommon_ApplicationTransactionCounter = cmdletContext.EmvCommon_ApplicationTransactionCounter;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_emvCommon_ApplicationTransactionCounter != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon.ApplicationTransactionCounter = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_emvCommon_ApplicationTransactionCounter;
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommonIsNull = false;
            }
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_emvCommon_PanSequenceNumber = null;
            if (cmdletContext.EmvCommon_PanSequenceNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_emvCommon_PanSequenceNumber = cmdletContext.EmvCommon_PanSequenceNumber;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_emvCommon_PanSequenceNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon.PanSequenceNumber = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_emvCommon_PanSequenceNumber;
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommonIsNull = false;
            }
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_emvCommon_PrimaryAccountNumber = null;
            if (cmdletContext.EmvCommon_PrimaryAccountNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_emvCommon_PrimaryAccountNumber = cmdletContext.EmvCommon_PrimaryAccountNumber;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_emvCommon_PrimaryAccountNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon.PrimaryAccountNumber = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_EmvCommon_emvCommon_PrimaryAccountNumber;
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
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_mastercard_ApplicationTransactionCounter = null;
            if (cmdletContext.Mastercard_ApplicationTransactionCounter != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_mastercard_ApplicationTransactionCounter = cmdletContext.Mastercard_ApplicationTransactionCounter;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_mastercard_ApplicationTransactionCounter != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard.ApplicationTransactionCounter = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_mastercard_ApplicationTransactionCounter;
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_MastercardIsNull = false;
            }
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_mastercard_PanSequenceNumber = null;
            if (cmdletContext.Mastercard_PanSequenceNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_mastercard_PanSequenceNumber = cmdletContext.Mastercard_PanSequenceNumber;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_mastercard_PanSequenceNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard.PanSequenceNumber = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_mastercard_PanSequenceNumber;
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_MastercardIsNull = false;
            }
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_mastercard_PrimaryAccountNumber = null;
            if (cmdletContext.Mastercard_PrimaryAccountNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_mastercard_PrimaryAccountNumber = cmdletContext.Mastercard_PrimaryAccountNumber;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_mastercard_PrimaryAccountNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard.PrimaryAccountNumber = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_mastercard_PrimaryAccountNumber;
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_MastercardIsNull = false;
            }
            System.String requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_mastercard_UnpredictableNumber = null;
            if (cmdletContext.Mastercard_UnpredictableNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_mastercard_UnpredictableNumber = cmdletContext.Mastercard_UnpredictableNumber;
            }
            if (requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_mastercard_UnpredictableNumber != null)
            {
                requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard.UnpredictableNumber = requestSessionKeyDerivationAttributes_sessionKeyDerivationAttributes_Mastercard_mastercard_UnpredictableNumber;
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
        
        private Amazon.PaymentCryptographyData.Model.VerifyAuthRequestCryptogramResponse CallAWSServiceOperation(IAmazonPaymentCryptographyData client, Amazon.PaymentCryptographyData.Model.VerifyAuthRequestCryptogramRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Payment Cryptography Data", "VerifyAuthRequestCryptogram");
            try
            {
                #if DESKTOP
                return client.VerifyAuthRequestCryptogram(request);
                #elif CORECLR
                return client.VerifyAuthRequestCryptogramAsync(request).GetAwaiter().GetResult();
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
            public System.String AuthRequestCryptogram { get; set; }
            public System.String ArpcMethod1_AuthResponseCode { get; set; }
            public System.String ArpcMethod2_CardStatusUpdate { get; set; }
            public System.String ArpcMethod2_ProprietaryAuthenticationData { get; set; }
            public System.String KeyIdentifier { get; set; }
            public Amazon.PaymentCryptographyData.MajorKeyDerivationMode MajorKeyDerivationMode { get; set; }
            public System.String Amex_PanSequenceNumber { get; set; }
            public System.String Amex_PrimaryAccountNumber { get; set; }
            public System.String Emv2000_ApplicationTransactionCounter { get; set; }
            public System.String Emv2000_PanSequenceNumber { get; set; }
            public System.String Emv2000_PrimaryAccountNumber { get; set; }
            public System.String EmvCommon_ApplicationTransactionCounter { get; set; }
            public System.String EmvCommon_PanSequenceNumber { get; set; }
            public System.String EmvCommon_PrimaryAccountNumber { get; set; }
            public System.String Mastercard_ApplicationTransactionCounter { get; set; }
            public System.String Mastercard_PanSequenceNumber { get; set; }
            public System.String Mastercard_PrimaryAccountNumber { get; set; }
            public System.String Mastercard_UnpredictableNumber { get; set; }
            public System.String Visa_PanSequenceNumber { get; set; }
            public System.String Visa_PrimaryAccountNumber { get; set; }
            public System.String TransactionData { get; set; }
            public System.Func<Amazon.PaymentCryptographyData.Model.VerifyAuthRequestCryptogramResponse, TestPAYCDAuthRequestCryptogramCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
