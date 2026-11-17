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
    /// Allows buyers (acceptors) to start the approvals that their organization requires
    /// for an agreement request. You start one agreement approval for each approval plan
    /// that you specify. Use <c>GetAgreementRequestApprovalPlans</c> to retrieve the approval
    /// plans of the agreement request. Once the agreement approvals start, the agreement
    /// request transitions to <c>PENDING_APPROVAL</c> status.
    /// </summary>
    [Cmdlet("Start", "MASAgreementApproval", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MarketplaceAgreement.Model.AgreementApprovalSummary")]
    [AWSCmdlet("Calls the AWS Marketplace Agreement Service StartAgreementApprovals API operation.", Operation = new[] {"StartAgreementApprovals"}, SelectReturnType = typeof(Amazon.MarketplaceAgreement.Model.StartAgreementApprovalsResponse))]
    [AWSCmdletOutput("Amazon.MarketplaceAgreement.Model.AgreementApprovalSummary or Amazon.MarketplaceAgreement.Model.StartAgreementApprovalsResponse",
        "This cmdlet returns a collection of Amazon.MarketplaceAgreement.Model.AgreementApprovalSummary objects.",
        "The service call response (type Amazon.MarketplaceAgreement.Model.StartAgreementApprovalsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartMASAgreementApprovalCmdlet : AmazonMarketplaceAgreementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgreementRequestId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the agreement request to start approvals for.</para>
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
        public System.String AgreementRequestId { get; set; }
        #endregion
        
        #region Parameter PlanInput
        /// <summary>
        /// <para>
        /// <para>The approval plans to start agreement approvals for.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("PlanInputs")]
        public Amazon.MarketplaceAgreement.Model.AgreementApprovalPlanInput[] PlanInput { get; set; }
        #endregion
        
        #region Parameter PurchaseOrder
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
        [Alias("PurchaseOrders")]
        public Amazon.MarketplaceAgreement.Model.AgreementApprovalPurchaseOrder[] PurchaseOrder { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApprovalSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MarketplaceAgreement.Model.StartAgreementApprovalsResponse).
        /// Specifying the name of a property of type Amazon.MarketplaceAgreement.Model.StartAgreementApprovalsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApprovalSummaries";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AgreementRequestId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-MASAgreementApproval (StartAgreementApprovals)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MarketplaceAgreement.Model.StartAgreementApprovalsResponse, StartMASAgreementApprovalCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgreementRequestId = this.AgreementRequestId;
            #if MODULAR
            if (this.AgreementRequestId == null && ParameterWasBound(nameof(this.AgreementRequestId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgreementRequestId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PlanInput != null)
            {
                context.PlanInput = new List<Amazon.MarketplaceAgreement.Model.AgreementApprovalPlanInput>(this.PlanInput);
            }
            #if MODULAR
            if (this.PlanInput == null && ParameterWasBound(nameof(this.PlanInput)))
            {
                WriteWarning("You are passing $null as a value for parameter PlanInput which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PurchaseOrder != null)
            {
                context.PurchaseOrder = new List<Amazon.MarketplaceAgreement.Model.AgreementApprovalPurchaseOrder>(this.PurchaseOrder);
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
            var request = new Amazon.MarketplaceAgreement.Model.StartAgreementApprovalsRequest();
            
            if (cmdletContext.AgreementRequestId != null)
            {
                request.AgreementRequestId = cmdletContext.AgreementRequestId;
            }
            if (cmdletContext.PlanInput != null)
            {
                request.PlanInputs = cmdletContext.PlanInput;
            }
            if (cmdletContext.PurchaseOrder != null)
            {
                request.PurchaseOrders = cmdletContext.PurchaseOrder;
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
        
        private Amazon.MarketplaceAgreement.Model.StartAgreementApprovalsResponse CallAWSServiceOperation(IAmazonMarketplaceAgreement client, Amazon.MarketplaceAgreement.Model.StartAgreementApprovalsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Agreement Service", "StartAgreementApprovals");
            try
            {
                return client.StartAgreementApprovalsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AgreementRequestId { get; set; }
            public List<Amazon.MarketplaceAgreement.Model.AgreementApprovalPlanInput> PlanInput { get; set; }
            public List<Amazon.MarketplaceAgreement.Model.AgreementApprovalPurchaseOrder> PurchaseOrder { get; set; }
            public System.Func<Amazon.MarketplaceAgreement.Model.StartAgreementApprovalsResponse, StartMASAgreementApprovalCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApprovalSummaries;
        }
        
    }
}
