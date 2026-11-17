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
using Amazon.MarketplaceAgreement;
using Amazon.MarketplaceAgreement.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MAS
{
    /// <summary>
    /// Allows the management account or a delegated administrator of the buyer's AWS organization
    /// to approve an agreement approval that is in <c>PENDING_APPROVAL</c> status, as the
    /// organization administrator approver or on behalf of another approver. Once every level
    /// is approved, the agreement approval transitions to <c>APPROVED</c> status. You can
    /// optionally provide purchase order references and a note.
    /// </summary>
    [Cmdlet("Approve", "MASAgreementApproval", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Marketplace Agreement Service AcceptAgreementApproval API operation.", Operation = new[] {"AcceptAgreementApproval"}, SelectReturnType = typeof(Amazon.MarketplaceAgreement.Model.AcceptAgreementApprovalResponse))]
    [AWSCmdletOutput("None or Amazon.MarketplaceAgreement.Model.AcceptAgreementApprovalResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.MarketplaceAgreement.Model.AcceptAgreementApprovalResponse) be returned by specifying '-Select *'."
    )]
    public partial class ApproveMASAgreementApprovalCmdlet : AmazonMarketplaceAgreementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BuyerAgreementApprovalApproverInput_AgreementApprovalId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the agreement approval to approve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BuyerAgreementApprovalApproverInput_AgreementApprovalId { get; set; }
        #endregion
        
        #region Parameter BuyerAgreementApprovalApproverInput_ApproverOutcomeIdToOverride
        /// <summary>
        /// <para>
        /// <para>The <c>approverOutcomeId</c> of the approver to decide on behalf of. You must be the
        /// management account or a delegated administrator of your AWS organization to set this
        /// field. Use <c>GetAgreementApproval</c> to retrieve the <c>approverOutcomeId</c> of
        /// each approver.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BuyerAgreementApprovalApproverInput_ApproverOutcomeIdToOverride { get; set; }
        #endregion
        
        #region Parameter BuyerAgreementApprovalApproverInput_Note
        /// <summary>
        /// <para>
        /// <para>An optional note that explains the decision (1-1000 characters).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BuyerAgreementApprovalApproverInput_Note { get; set; }
        #endregion
        
        #region Parameter BuyerAgreementApprovalApproverInput_PurchaseOrder
        /// <summary>
        /// <para>
        /// <para>An optional list of purchase order references to associate with charges on the agreement
        /// request.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BuyerAgreementApprovalApproverInput_PurchaseOrders")]
        public Amazon.MarketplaceAgreement.Model.AgreementApprovalPurchaseOrder[] BuyerAgreementApprovalApproverInput_PurchaseOrder { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MarketplaceAgreement.Model.AcceptAgreementApprovalResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BuyerAgreementApprovalApproverInput_AgreementApprovalId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Approve-MASAgreementApproval (AcceptAgreementApproval)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MarketplaceAgreement.Model.AcceptAgreementApprovalResponse, ApproveMASAgreementApprovalCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BuyerAgreementApprovalApproverInput_AgreementApprovalId = this.BuyerAgreementApprovalApproverInput_AgreementApprovalId;
            context.BuyerAgreementApprovalApproverInput_ApproverOutcomeIdToOverride = this.BuyerAgreementApprovalApproverInput_ApproverOutcomeIdToOverride;
            context.BuyerAgreementApprovalApproverInput_Note = this.BuyerAgreementApprovalApproverInput_Note;
            if (this.BuyerAgreementApprovalApproverInput_PurchaseOrder != null)
            {
                context.BuyerAgreementApprovalApproverInput_PurchaseOrder = new List<Amazon.MarketplaceAgreement.Model.AgreementApprovalPurchaseOrder>(this.BuyerAgreementApprovalApproverInput_PurchaseOrder);
            }
            
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
            var request = new Amazon.MarketplaceAgreement.Model.AcceptAgreementApprovalRequest();
            
            
             // populate BuyerAgreementApprovalApproverInput
            var requestBuyerAgreementApprovalApproverInputIsNull = true;
            request.BuyerAgreementApprovalApproverInput = new Amazon.MarketplaceAgreement.Model.BuyerAgreementApprovalApproverInput();
            System.String requestBuyerAgreementApprovalApproverInput_buyerAgreementApprovalApproverInput_AgreementApprovalId = null;
            if (cmdletContext.BuyerAgreementApprovalApproverInput_AgreementApprovalId != null)
            {
                requestBuyerAgreementApprovalApproverInput_buyerAgreementApprovalApproverInput_AgreementApprovalId = cmdletContext.BuyerAgreementApprovalApproverInput_AgreementApprovalId;
            }
            if (requestBuyerAgreementApprovalApproverInput_buyerAgreementApprovalApproverInput_AgreementApprovalId != null)
            {
                request.BuyerAgreementApprovalApproverInput.AgreementApprovalId = requestBuyerAgreementApprovalApproverInput_buyerAgreementApprovalApproverInput_AgreementApprovalId;
                requestBuyerAgreementApprovalApproverInputIsNull = false;
            }
            System.String requestBuyerAgreementApprovalApproverInput_buyerAgreementApprovalApproverInput_ApproverOutcomeIdToOverride = null;
            if (cmdletContext.BuyerAgreementApprovalApproverInput_ApproverOutcomeIdToOverride != null)
            {
                requestBuyerAgreementApprovalApproverInput_buyerAgreementApprovalApproverInput_ApproverOutcomeIdToOverride = cmdletContext.BuyerAgreementApprovalApproverInput_ApproverOutcomeIdToOverride;
            }
            if (requestBuyerAgreementApprovalApproverInput_buyerAgreementApprovalApproverInput_ApproverOutcomeIdToOverride != null)
            {
                request.BuyerAgreementApprovalApproverInput.ApproverOutcomeIdToOverride = requestBuyerAgreementApprovalApproverInput_buyerAgreementApprovalApproverInput_ApproverOutcomeIdToOverride;
                requestBuyerAgreementApprovalApproverInputIsNull = false;
            }
            System.String requestBuyerAgreementApprovalApproverInput_buyerAgreementApprovalApproverInput_Note = null;
            if (cmdletContext.BuyerAgreementApprovalApproverInput_Note != null)
            {
                requestBuyerAgreementApprovalApproverInput_buyerAgreementApprovalApproverInput_Note = cmdletContext.BuyerAgreementApprovalApproverInput_Note;
            }
            if (requestBuyerAgreementApprovalApproverInput_buyerAgreementApprovalApproverInput_Note != null)
            {
                request.BuyerAgreementApprovalApproverInput.Note = requestBuyerAgreementApprovalApproverInput_buyerAgreementApprovalApproverInput_Note;
                requestBuyerAgreementApprovalApproverInputIsNull = false;
            }
            List<Amazon.MarketplaceAgreement.Model.AgreementApprovalPurchaseOrder> requestBuyerAgreementApprovalApproverInput_buyerAgreementApprovalApproverInput_PurchaseOrder = null;
            if (cmdletContext.BuyerAgreementApprovalApproverInput_PurchaseOrder != null)
            {
                requestBuyerAgreementApprovalApproverInput_buyerAgreementApprovalApproverInput_PurchaseOrder = cmdletContext.BuyerAgreementApprovalApproverInput_PurchaseOrder;
            }
            if (requestBuyerAgreementApprovalApproverInput_buyerAgreementApprovalApproverInput_PurchaseOrder != null)
            {
                request.BuyerAgreementApprovalApproverInput.PurchaseOrders = requestBuyerAgreementApprovalApproverInput_buyerAgreementApprovalApproverInput_PurchaseOrder;
                requestBuyerAgreementApprovalApproverInputIsNull = false;
            }
             // determine if request.BuyerAgreementApprovalApproverInput should be set to null
            if (requestBuyerAgreementApprovalApproverInputIsNull)
            {
                request.BuyerAgreementApprovalApproverInput = null;
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
        
        private Amazon.MarketplaceAgreement.Model.AcceptAgreementApprovalResponse CallAWSServiceOperation(IAmazonMarketplaceAgreement client, Amazon.MarketplaceAgreement.Model.AcceptAgreementApprovalRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Agreement Service", "AcceptAgreementApproval");
            try
            {
                return client.AcceptAgreementApprovalAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BuyerAgreementApprovalApproverInput_AgreementApprovalId { get; set; }
            public System.String BuyerAgreementApprovalApproverInput_ApproverOutcomeIdToOverride { get; set; }
            public System.String BuyerAgreementApprovalApproverInput_Note { get; set; }
            public List<Amazon.MarketplaceAgreement.Model.AgreementApprovalPurchaseOrder> BuyerAgreementApprovalApproverInput_PurchaseOrder { get; set; }
            public System.Func<Amazon.MarketplaceAgreement.Model.AcceptAgreementApprovalResponse, ApproveMASAgreementApprovalCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
