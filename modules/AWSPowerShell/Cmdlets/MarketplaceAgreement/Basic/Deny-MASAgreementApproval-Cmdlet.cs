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
    /// to reject an agreement approval that is in <c>PENDING_APPROVAL</c> status, as the
    /// organization administrator approver or on behalf of another approver. Once rejected,
    /// the agreement approval and its agreement request transition to <c>REJECTED</c> status.
    /// You must provide a reason for the rejection.
    /// </summary>
    [Cmdlet("Deny", "MASAgreementApproval", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Marketplace Agreement Service RejectAgreementApproval API operation.", Operation = new[] {"RejectAgreementApproval"}, SelectReturnType = typeof(Amazon.MarketplaceAgreement.Model.RejectAgreementApprovalResponse))]
    [AWSCmdletOutput("None or Amazon.MarketplaceAgreement.Model.RejectAgreementApprovalResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.MarketplaceAgreement.Model.RejectAgreementApprovalResponse) be returned by specifying '-Select *'."
    )]
    public partial class DenyMASAgreementApprovalCmdlet : AmazonMarketplaceAgreementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BuyerAgreementApprovalRejectionInput_AgreementApprovalId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the agreement approval to reject.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BuyerAgreementApprovalRejectionInput_AgreementApprovalId { get; set; }
        #endregion
        
        #region Parameter BuyerAgreementApprovalRejectionInput_ApproverOutcomeIdToOverride
        /// <summary>
        /// <para>
        /// <para>The <c>approverOutcomeId</c> of the approver to decide on behalf of. You must be the
        /// management account or a delegated administrator of your AWS organization to set this
        /// field. Use <c>GetAgreementApproval</c> to retrieve the <c>approverOutcomeId</c> of
        /// each approver.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BuyerAgreementApprovalRejectionInput_ApproverOutcomeIdToOverride { get; set; }
        #endregion
        
        #region Parameter BuyerAgreementApprovalRejectionInput_Note
        /// <summary>
        /// <para>
        /// <para>The reason for the rejection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BuyerAgreementApprovalRejectionInput_Note { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MarketplaceAgreement.Model.RejectAgreementApprovalResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BuyerAgreementApprovalRejectionInput_AgreementApprovalId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Deny-MASAgreementApproval (RejectAgreementApproval)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MarketplaceAgreement.Model.RejectAgreementApprovalResponse, DenyMASAgreementApprovalCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BuyerAgreementApprovalRejectionInput_AgreementApprovalId = this.BuyerAgreementApprovalRejectionInput_AgreementApprovalId;
            context.BuyerAgreementApprovalRejectionInput_ApproverOutcomeIdToOverride = this.BuyerAgreementApprovalRejectionInput_ApproverOutcomeIdToOverride;
            context.BuyerAgreementApprovalRejectionInput_Note = this.BuyerAgreementApprovalRejectionInput_Note;
            
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
            var request = new Amazon.MarketplaceAgreement.Model.RejectAgreementApprovalRequest();
            
            
             // populate BuyerAgreementApprovalRejectionInput
            var requestBuyerAgreementApprovalRejectionInputIsNull = true;
            request.BuyerAgreementApprovalRejectionInput = new Amazon.MarketplaceAgreement.Model.BuyerAgreementApprovalRejectionInput();
            System.String requestBuyerAgreementApprovalRejectionInput_buyerAgreementApprovalRejectionInput_AgreementApprovalId = null;
            if (cmdletContext.BuyerAgreementApprovalRejectionInput_AgreementApprovalId != null)
            {
                requestBuyerAgreementApprovalRejectionInput_buyerAgreementApprovalRejectionInput_AgreementApprovalId = cmdletContext.BuyerAgreementApprovalRejectionInput_AgreementApprovalId;
            }
            if (requestBuyerAgreementApprovalRejectionInput_buyerAgreementApprovalRejectionInput_AgreementApprovalId != null)
            {
                request.BuyerAgreementApprovalRejectionInput.AgreementApprovalId = requestBuyerAgreementApprovalRejectionInput_buyerAgreementApprovalRejectionInput_AgreementApprovalId;
                requestBuyerAgreementApprovalRejectionInputIsNull = false;
            }
            System.String requestBuyerAgreementApprovalRejectionInput_buyerAgreementApprovalRejectionInput_ApproverOutcomeIdToOverride = null;
            if (cmdletContext.BuyerAgreementApprovalRejectionInput_ApproverOutcomeIdToOverride != null)
            {
                requestBuyerAgreementApprovalRejectionInput_buyerAgreementApprovalRejectionInput_ApproverOutcomeIdToOverride = cmdletContext.BuyerAgreementApprovalRejectionInput_ApproverOutcomeIdToOverride;
            }
            if (requestBuyerAgreementApprovalRejectionInput_buyerAgreementApprovalRejectionInput_ApproverOutcomeIdToOverride != null)
            {
                request.BuyerAgreementApprovalRejectionInput.ApproverOutcomeIdToOverride = requestBuyerAgreementApprovalRejectionInput_buyerAgreementApprovalRejectionInput_ApproverOutcomeIdToOverride;
                requestBuyerAgreementApprovalRejectionInputIsNull = false;
            }
            System.String requestBuyerAgreementApprovalRejectionInput_buyerAgreementApprovalRejectionInput_Note = null;
            if (cmdletContext.BuyerAgreementApprovalRejectionInput_Note != null)
            {
                requestBuyerAgreementApprovalRejectionInput_buyerAgreementApprovalRejectionInput_Note = cmdletContext.BuyerAgreementApprovalRejectionInput_Note;
            }
            if (requestBuyerAgreementApprovalRejectionInput_buyerAgreementApprovalRejectionInput_Note != null)
            {
                request.BuyerAgreementApprovalRejectionInput.Note = requestBuyerAgreementApprovalRejectionInput_buyerAgreementApprovalRejectionInput_Note;
                requestBuyerAgreementApprovalRejectionInputIsNull = false;
            }
             // determine if request.BuyerAgreementApprovalRejectionInput should be set to null
            if (requestBuyerAgreementApprovalRejectionInputIsNull)
            {
                request.BuyerAgreementApprovalRejectionInput = null;
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
        
        private Amazon.MarketplaceAgreement.Model.RejectAgreementApprovalResponse CallAWSServiceOperation(IAmazonMarketplaceAgreement client, Amazon.MarketplaceAgreement.Model.RejectAgreementApprovalRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Agreement Service", "RejectAgreementApproval");
            try
            {
                return client.RejectAgreementApprovalAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BuyerAgreementApprovalRejectionInput_AgreementApprovalId { get; set; }
            public System.String BuyerAgreementApprovalRejectionInput_ApproverOutcomeIdToOverride { get; set; }
            public System.String BuyerAgreementApprovalRejectionInput_Note { get; set; }
            public System.Func<Amazon.MarketplaceAgreement.Model.RejectAgreementApprovalResponse, DenyMASAgreementApprovalCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
