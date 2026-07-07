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
using Amazon.PartnerCentralRevenueMeasurement;
using Amazon.PartnerCentralRevenueMeasurement.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PCRM
{
    /// <summary>
    /// Updates an existing marketplace revenue share allocation. Supports modifying effective
    /// dates, revenue share percentage, and status with time-based mutability rules.
    /// </summary>
    [Cmdlet("Update", "PCRMMarketplaceRevenueShareAllocation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PartnerCentralRevenueMeasurement.Model.UpdateMarketplaceRevenueShareAllocationResponse")]
    [AWSCmdlet("Calls the Partner Central Revenue Measurement API UpdateMarketplaceRevenueShareAllocation API operation.", Operation = new[] {"UpdateMarketplaceRevenueShareAllocation"}, SelectReturnType = typeof(Amazon.PartnerCentralRevenueMeasurement.Model.UpdateMarketplaceRevenueShareAllocationResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralRevenueMeasurement.Model.UpdateMarketplaceRevenueShareAllocationResponse",
        "This cmdlet returns an Amazon.PartnerCentralRevenueMeasurement.Model.UpdateMarketplaceRevenueShareAllocationResponse object containing multiple properties."
    )]
    public partial class UpdatePCRMMarketplaceRevenueShareAllocationCmdlet : AmazonPartnerCentralRevenueMeasurementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog containing the allocation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PartnerCentralRevenueMeasurement.CatalogName")]
        public Amazon.PartnerCentralRevenueMeasurement.CatalogName Catalog { get; set; }
        #endregion
        
        #region Parameter EffectiveFrom
        /// <summary>
        /// <para>
        /// <para>The new effective start date. Must be the first day of a month. Only modifiable on
        /// future-dated allocations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EffectiveFrom { get; set; }
        #endregion
        
        #region Parameter EffectiveUntil
        /// <summary>
        /// <para>
        /// <para>The new effective end date. Must be the last day of a month and on or after today.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EffectiveUntil { get; set; }
        #endregion
        
        #region Parameter MarketplaceRevenueShareAllocationId
        /// <summary>
        /// <para>
        /// <para>The identifier of the allocation to update.</para>
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
        public System.String MarketplaceRevenueShareAllocationId { get; set; }
        #endregion
        
        #region Parameter MarketplaceRevenueShareRevision
        /// <summary>
        /// <para>
        /// <para>The current revision of the parent share. Must match for optimistic concurrency control.</para>
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
        public System.String MarketplaceRevenueShareRevision { get; set; }
        #endregion
        
        #region Parameter ProductId
        /// <summary>
        /// <para>
        /// <para>The AWS Marketplace product identifier for the parent revenue share.</para>
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
        public System.String ProductId { get; set; }
        #endregion
        
        #region Parameter RevenueSharePercent
        /// <summary>
        /// <para>
        /// <para>The new revenue share percentage. Only modifiable on future-dated allocations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RevenueSharePercent { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The new status. Set to INACTIVE for soft-delete. Only modifiable on future-dated allocations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.PartnerCentralRevenueMeasurement.AllocationStatus")]
        public Amazon.PartnerCentralRevenueMeasurement.AllocationStatus Status { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique token to ensure idempotency of the update request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralRevenueMeasurement.Model.UpdateMarketplaceRevenueShareAllocationResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralRevenueMeasurement.Model.UpdateMarketplaceRevenueShareAllocationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MarketplaceRevenueShareAllocationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PCRMMarketplaceRevenueShareAllocation (UpdateMarketplaceRevenueShareAllocation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralRevenueMeasurement.Model.UpdateMarketplaceRevenueShareAllocationResponse, UpdatePCRMMarketplaceRevenueShareAllocationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.EffectiveFrom = this.EffectiveFrom;
            context.EffectiveUntil = this.EffectiveUntil;
            context.MarketplaceRevenueShareAllocationId = this.MarketplaceRevenueShareAllocationId;
            #if MODULAR
            if (this.MarketplaceRevenueShareAllocationId == null && ParameterWasBound(nameof(this.MarketplaceRevenueShareAllocationId)))
            {
                WriteWarning("You are passing $null as a value for parameter MarketplaceRevenueShareAllocationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MarketplaceRevenueShareRevision = this.MarketplaceRevenueShareRevision;
            #if MODULAR
            if (this.MarketplaceRevenueShareRevision == null && ParameterWasBound(nameof(this.MarketplaceRevenueShareRevision)))
            {
                WriteWarning("You are passing $null as a value for parameter MarketplaceRevenueShareRevision which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProductId = this.ProductId;
            #if MODULAR
            if (this.ProductId == null && ParameterWasBound(nameof(this.ProductId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProductId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RevenueSharePercent = this.RevenueSharePercent;
            context.Status = this.Status;
            
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
            var request = new Amazon.PartnerCentralRevenueMeasurement.Model.UpdateMarketplaceRevenueShareAllocationRequest();
            
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EffectiveFrom != null)
            {
                request.EffectiveFrom = cmdletContext.EffectiveFrom;
            }
            if (cmdletContext.EffectiveUntil != null)
            {
                request.EffectiveUntil = cmdletContext.EffectiveUntil;
            }
            if (cmdletContext.MarketplaceRevenueShareAllocationId != null)
            {
                request.MarketplaceRevenueShareAllocationId = cmdletContext.MarketplaceRevenueShareAllocationId;
            }
            if (cmdletContext.MarketplaceRevenueShareRevision != null)
            {
                request.MarketplaceRevenueShareRevision = cmdletContext.MarketplaceRevenueShareRevision;
            }
            if (cmdletContext.ProductId != null)
            {
                request.ProductId = cmdletContext.ProductId;
            }
            if (cmdletContext.RevenueSharePercent != null)
            {
                request.RevenueSharePercent = cmdletContext.RevenueSharePercent;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.PartnerCentralRevenueMeasurement.Model.UpdateMarketplaceRevenueShareAllocationResponse CallAWSServiceOperation(IAmazonPartnerCentralRevenueMeasurement client, Amazon.PartnerCentralRevenueMeasurement.Model.UpdateMarketplaceRevenueShareAllocationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Revenue Measurement API", "UpdateMarketplaceRevenueShareAllocation");
            try
            {
                return client.UpdateMarketplaceRevenueShareAllocationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.PartnerCentralRevenueMeasurement.CatalogName Catalog { get; set; }
            public System.String ClientToken { get; set; }
            public System.String EffectiveFrom { get; set; }
            public System.String EffectiveUntil { get; set; }
            public System.String MarketplaceRevenueShareAllocationId { get; set; }
            public System.String MarketplaceRevenueShareRevision { get; set; }
            public System.String ProductId { get; set; }
            public System.String RevenueSharePercent { get; set; }
            public Amazon.PartnerCentralRevenueMeasurement.AllocationStatus Status { get; set; }
            public System.Func<Amazon.PartnerCentralRevenueMeasurement.Model.UpdateMarketplaceRevenueShareAllocationResponse, UpdatePCRMMarketplaceRevenueShareAllocationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
