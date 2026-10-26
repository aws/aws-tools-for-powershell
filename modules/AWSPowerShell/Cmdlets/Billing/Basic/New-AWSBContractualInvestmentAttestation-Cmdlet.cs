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
using Amazon.Billing;
using Amazon.Billing.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AWSB
{
    /// <summary>
    /// Creates an attestation that claims an investment award for a completed milestone or
    /// outcome within a private pricing contract. Supply a <c>clientToken</c> to make the
    /// request idempotent so a safe retry does not create a duplicate attestation. This operation
    /// starts an asynchronous review and returns an <c>attestationId</c> while the attestation
    /// is pending.
    /// </summary>
    [Cmdlet("New", "AWSBContractualInvestmentAttestation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Billing CreateContractualInvestmentAttestation API operation.", Operation = new[] {"CreateContractualInvestmentAttestation"}, SelectReturnType = typeof(Amazon.Billing.Model.CreateContractualInvestmentAttestationResponse))]
    [AWSCmdletOutput("System.String or Amazon.Billing.Model.CreateContractualInvestmentAttestationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Billing.Model.CreateContractualInvestmentAttestationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewAWSBContractualInvestmentAttestationCmdlet : AmazonBillingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AdditionalRecipient
        /// <summary>
        /// <para>
        /// <para>The email addresses to copy as viewers on the executive approval request.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalRecipients")]
        public Amazon.Billing.Model.AdditionalRecipient[] AdditionalRecipient { get; set; }
        #endregion
        
        #region Parameter AttestationDetails_AttestationValue_AttestationQuantity
        /// <summary>
        /// <para>
        /// <para>The value attested as one or more quantities, each with its own unit. The list contains
        /// at most 50 quantities.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AttestationDetails_AttestationValue_AttestationQuantities")]
        public Amazon.Billing.Model.AttestationQuantity[] AttestationDetails_AttestationValue_AttestationQuantity { get; set; }
        #endregion
        
        #region Parameter ContractArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the contract that contains the investment being
        /// attested.</para>
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
        public System.String ContractArn { get; set; }
        #endregion
        
        #region Parameter ContractDocumentId
        /// <summary>
        /// <para>
        /// <para>The contract ID from the contract document, located in the top-right corner of the
        /// private pricing contract pages. This value confirms that you have access to the contract.</para>
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
        public System.String ContractDocumentId { get; set; }
        #endregion
        
        #region Parameter AttestationDetails_AttestationValue_AttestationAmount_CurrencyAmount
        /// <summary>
        /// <para>
        /// <para>The amount as a decimal string (for example, <c>"743.21"</c>). Negative values represent
        /// credits that reduce a bill.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AttestationDetails_AttestationValue_AttestationAmount_CurrencyAmount { get; set; }
        #endregion
        
        #region Parameter AttestationDetails_AttestationValue_AttestationAmount_CurrencyCode
        /// <summary>
        /// <para>
        /// <para>The ISO 4217 currency code for the amount (for example, <c>USD</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AttestationDetails_AttestationValue_AttestationAmount_CurrencyCode { get; set; }
        #endregion
        
        #region Parameter ApproverDetails_Email
        /// <summary>
        /// <para>
        /// <para>The email address of the approver. This value is 3–256 characters and must be a valid
        /// email address.</para>
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
        public System.String ApproverDetails_Email { get; set; }
        #endregion
        
        #region Parameter InvestmentDisbursedAt
        /// <summary>
        /// <para>
        /// <para>The date on which the investment is disbursed to the investment accounts. The disbursement
        /// date is subject to review timelines.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? InvestmentDisbursedAt { get; set; }
        #endregion
        
        #region Parameter AttestationDetails_InvestmentDistribution
        /// <summary>
        /// <para>
        /// <para>The distribution of the resulting investment across the eligible investment accounts
        /// on the contract. If you omit this value, the full investment is allocated to the single
        /// eligible investment account on the contract. This value is required when multiple
        /// investment accounts are eligible. When you provide this value, the sum of all distributions
        /// must equal the resulting monetary investment value (the attested amount, or the value
        /// computed from the attested quantities using the investment multipliers). The list
        /// contains at most 200 distributions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AttestationDetails_InvestmentDistributions")]
        public Amazon.Billing.Model.InvestmentDistribution[] AttestationDetails_InvestmentDistribution { get; set; }
        #endregion
        
        #region Parameter InvestmentId
        /// <summary>
        /// <para>
        /// <para>The identifier of the investment (outcome) being attested.</para>
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
        public System.String InvestmentId { get; set; }
        #endregion
        
        #region Parameter InvestmentSummaryId
        /// <summary>
        /// <para>
        /// <para>The identifier of the investment summary being attested. This is the parent to the
        /// investmentId.</para>
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
        public System.String InvestmentSummaryId { get; set; }
        #endregion
        
        #region Parameter ApproverDetails_Name
        /// <summary>
        /// <para>
        /// <para>The name of the approver as it appears on the contract. This value can be up to 256
        /// characters.</para>
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
        public System.String ApproverDetails_Name { get; set; }
        #endregion
        
        #region Parameter ApproverDetails_Title
        /// <summary>
        /// <para>
        /// <para>The title of the approver, such as <c>Chief Financial Officer</c>. This value can
        /// be up to 256 characters.</para>
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
        public System.String ApproverDetails_Title { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If you retry a request that completed successfully using the same client
        /// token and parameters, the retry completes without performing any further actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AttestationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Billing.Model.CreateContractualInvestmentAttestationResponse).
        /// Specifying the name of a property of type Amazon.Billing.Model.CreateContractualInvestmentAttestationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AttestationId";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AWSBContractualInvestmentAttestation (CreateContractualInvestmentAttestation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Billing.Model.CreateContractualInvestmentAttestationResponse, NewAWSBContractualInvestmentAttestationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AdditionalRecipient != null)
            {
                context.AdditionalRecipient = new List<Amazon.Billing.Model.AdditionalRecipient>(this.AdditionalRecipient);
            }
            context.ApproverDetails_Email = this.ApproverDetails_Email;
            #if MODULAR
            if (this.ApproverDetails_Email == null && ParameterWasBound(nameof(this.ApproverDetails_Email)))
            {
                WriteWarning("You are passing $null as a value for parameter ApproverDetails_Email which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApproverDetails_Name = this.ApproverDetails_Name;
            #if MODULAR
            if (this.ApproverDetails_Name == null && ParameterWasBound(nameof(this.ApproverDetails_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter ApproverDetails_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ApproverDetails_Title = this.ApproverDetails_Title;
            #if MODULAR
            if (this.ApproverDetails_Title == null && ParameterWasBound(nameof(this.ApproverDetails_Title)))
            {
                WriteWarning("You are passing $null as a value for parameter ApproverDetails_Title which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AttestationDetails_AttestationValue_AttestationAmount_CurrencyAmount = this.AttestationDetails_AttestationValue_AttestationAmount_CurrencyAmount;
            context.AttestationDetails_AttestationValue_AttestationAmount_CurrencyCode = this.AttestationDetails_AttestationValue_AttestationAmount_CurrencyCode;
            if (this.AttestationDetails_AttestationValue_AttestationQuantity != null)
            {
                context.AttestationDetails_AttestationValue_AttestationQuantity = new List<Amazon.Billing.Model.AttestationQuantity>(this.AttestationDetails_AttestationValue_AttestationQuantity);
            }
            if (this.AttestationDetails_InvestmentDistribution != null)
            {
                context.AttestationDetails_InvestmentDistribution = new List<Amazon.Billing.Model.InvestmentDistribution>(this.AttestationDetails_InvestmentDistribution);
            }
            context.ClientToken = this.ClientToken;
            context.ContractArn = this.ContractArn;
            #if MODULAR
            if (this.ContractArn == null && ParameterWasBound(nameof(this.ContractArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ContractArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContractDocumentId = this.ContractDocumentId;
            #if MODULAR
            if (this.ContractDocumentId == null && ParameterWasBound(nameof(this.ContractDocumentId)))
            {
                WriteWarning("You are passing $null as a value for parameter ContractDocumentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InvestmentDisbursedAt = this.InvestmentDisbursedAt;
            context.InvestmentId = this.InvestmentId;
            #if MODULAR
            if (this.InvestmentId == null && ParameterWasBound(nameof(this.InvestmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter InvestmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InvestmentSummaryId = this.InvestmentSummaryId;
            #if MODULAR
            if (this.InvestmentSummaryId == null && ParameterWasBound(nameof(this.InvestmentSummaryId)))
            {
                WriteWarning("You are passing $null as a value for parameter InvestmentSummaryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Billing.Model.CreateContractualInvestmentAttestationRequest();
            
            if (cmdletContext.AdditionalRecipient != null)
            {
                request.AdditionalRecipients = cmdletContext.AdditionalRecipient;
            }
            
             // populate ApproverDetails
            var requestApproverDetailsIsNull = true;
            request.ApproverDetails = new Amazon.Billing.Model.ApproverDetails();
            System.String requestApproverDetails_approverDetails_Email = null;
            if (cmdletContext.ApproverDetails_Email != null)
            {
                requestApproverDetails_approverDetails_Email = cmdletContext.ApproverDetails_Email;
            }
            if (requestApproverDetails_approverDetails_Email != null)
            {
                request.ApproverDetails.Email = requestApproverDetails_approverDetails_Email;
                requestApproverDetailsIsNull = false;
            }
            System.String requestApproverDetails_approverDetails_Name = null;
            if (cmdletContext.ApproverDetails_Name != null)
            {
                requestApproverDetails_approverDetails_Name = cmdletContext.ApproverDetails_Name;
            }
            if (requestApproverDetails_approverDetails_Name != null)
            {
                request.ApproverDetails.Name = requestApproverDetails_approverDetails_Name;
                requestApproverDetailsIsNull = false;
            }
            System.String requestApproverDetails_approverDetails_Title = null;
            if (cmdletContext.ApproverDetails_Title != null)
            {
                requestApproverDetails_approverDetails_Title = cmdletContext.ApproverDetails_Title;
            }
            if (requestApproverDetails_approverDetails_Title != null)
            {
                request.ApproverDetails.Title = requestApproverDetails_approverDetails_Title;
                requestApproverDetailsIsNull = false;
            }
             // determine if request.ApproverDetails should be set to null
            if (requestApproverDetailsIsNull)
            {
                request.ApproverDetails = null;
            }
            
             // populate AttestationDetails
            var requestAttestationDetailsIsNull = true;
            request.AttestationDetails = new Amazon.Billing.Model.AttestationDetails();
            List<Amazon.Billing.Model.InvestmentDistribution> requestAttestationDetails_attestationDetails_InvestmentDistribution = null;
            if (cmdletContext.AttestationDetails_InvestmentDistribution != null)
            {
                requestAttestationDetails_attestationDetails_InvestmentDistribution = cmdletContext.AttestationDetails_InvestmentDistribution;
            }
            if (requestAttestationDetails_attestationDetails_InvestmentDistribution != null)
            {
                request.AttestationDetails.InvestmentDistributions = requestAttestationDetails_attestationDetails_InvestmentDistribution;
                requestAttestationDetailsIsNull = false;
            }
            Amazon.Billing.Model.AttestationValue requestAttestationDetails_attestationDetails_AttestationValue = null;
            
             // populate AttestationValue
            var requestAttestationDetails_attestationDetails_AttestationValueIsNull = true;
            requestAttestationDetails_attestationDetails_AttestationValue = new Amazon.Billing.Model.AttestationValue();
            List<Amazon.Billing.Model.AttestationQuantity> requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationQuantity = null;
            if (cmdletContext.AttestationDetails_AttestationValue_AttestationQuantity != null)
            {
                requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationQuantity = cmdletContext.AttestationDetails_AttestationValue_AttestationQuantity;
            }
            if (requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationQuantity != null)
            {
                requestAttestationDetails_attestationDetails_AttestationValue.AttestationQuantities = requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationQuantity;
                requestAttestationDetails_attestationDetails_AttestationValueIsNull = false;
            }
            Amazon.Billing.Model.Amount requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationAmount = null;
            
             // populate AttestationAmount
            var requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationAmountIsNull = true;
            requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationAmount = new Amazon.Billing.Model.Amount();
            System.String requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationAmount_attestationDetails_AttestationValue_AttestationAmount_CurrencyAmount = null;
            if (cmdletContext.AttestationDetails_AttestationValue_AttestationAmount_CurrencyAmount != null)
            {
                requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationAmount_attestationDetails_AttestationValue_AttestationAmount_CurrencyAmount = cmdletContext.AttestationDetails_AttestationValue_AttestationAmount_CurrencyAmount;
            }
            if (requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationAmount_attestationDetails_AttestationValue_AttestationAmount_CurrencyAmount != null)
            {
                requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationAmount.CurrencyAmount = requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationAmount_attestationDetails_AttestationValue_AttestationAmount_CurrencyAmount;
                requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationAmountIsNull = false;
            }
            System.String requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationAmount_attestationDetails_AttestationValue_AttestationAmount_CurrencyCode = null;
            if (cmdletContext.AttestationDetails_AttestationValue_AttestationAmount_CurrencyCode != null)
            {
                requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationAmount_attestationDetails_AttestationValue_AttestationAmount_CurrencyCode = cmdletContext.AttestationDetails_AttestationValue_AttestationAmount_CurrencyCode;
            }
            if (requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationAmount_attestationDetails_AttestationValue_AttestationAmount_CurrencyCode != null)
            {
                requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationAmount.CurrencyCode = requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationAmount_attestationDetails_AttestationValue_AttestationAmount_CurrencyCode;
                requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationAmountIsNull = false;
            }
             // determine if requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationAmount should be set to null
            if (requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationAmountIsNull)
            {
                requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationAmount = null;
            }
            if (requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationAmount != null)
            {
                requestAttestationDetails_attestationDetails_AttestationValue.AttestationAmount = requestAttestationDetails_attestationDetails_AttestationValue_attestationDetails_AttestationValue_AttestationAmount;
                requestAttestationDetails_attestationDetails_AttestationValueIsNull = false;
            }
             // determine if requestAttestationDetails_attestationDetails_AttestationValue should be set to null
            if (requestAttestationDetails_attestationDetails_AttestationValueIsNull)
            {
                requestAttestationDetails_attestationDetails_AttestationValue = null;
            }
            if (requestAttestationDetails_attestationDetails_AttestationValue != null)
            {
                request.AttestationDetails.AttestationValue = requestAttestationDetails_attestationDetails_AttestationValue;
                requestAttestationDetailsIsNull = false;
            }
             // determine if request.AttestationDetails should be set to null
            if (requestAttestationDetailsIsNull)
            {
                request.AttestationDetails = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ContractArn != null)
            {
                request.ContractArn = cmdletContext.ContractArn;
            }
            if (cmdletContext.ContractDocumentId != null)
            {
                request.ContractDocumentId = cmdletContext.ContractDocumentId;
            }
            if (cmdletContext.InvestmentDisbursedAt != null)
            {
                request.InvestmentDisbursedAt = cmdletContext.InvestmentDisbursedAt.Value;
            }
            if (cmdletContext.InvestmentId != null)
            {
                request.InvestmentId = cmdletContext.InvestmentId;
            }
            if (cmdletContext.InvestmentSummaryId != null)
            {
                request.InvestmentSummaryId = cmdletContext.InvestmentSummaryId;
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
        
        private Amazon.Billing.Model.CreateContractualInvestmentAttestationResponse CallAWSServiceOperation(IAmazonBilling client, Amazon.Billing.Model.CreateContractualInvestmentAttestationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Billing", "CreateContractualInvestmentAttestation");
            try
            {
                return client.CreateContractualInvestmentAttestationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Billing.Model.AdditionalRecipient> AdditionalRecipient { get; set; }
            public System.String ApproverDetails_Email { get; set; }
            public System.String ApproverDetails_Name { get; set; }
            public System.String ApproverDetails_Title { get; set; }
            public System.String AttestationDetails_AttestationValue_AttestationAmount_CurrencyAmount { get; set; }
            public System.String AttestationDetails_AttestationValue_AttestationAmount_CurrencyCode { get; set; }
            public List<Amazon.Billing.Model.AttestationQuantity> AttestationDetails_AttestationValue_AttestationQuantity { get; set; }
            public List<Amazon.Billing.Model.InvestmentDistribution> AttestationDetails_InvestmentDistribution { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ContractArn { get; set; }
            public System.String ContractDocumentId { get; set; }
            public System.DateTime? InvestmentDisbursedAt { get; set; }
            public System.String InvestmentId { get; set; }
            public System.String InvestmentSummaryId { get; set; }
            public System.Func<Amazon.Billing.Model.CreateContractualInvestmentAttestationResponse, NewAWSBContractualInvestmentAttestationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AttestationId;
        }
        
    }
}
