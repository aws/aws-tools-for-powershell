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
    /// Creates a new marketplace revenue share allocation for the specified product.
    /// </summary>
    [Cmdlet("New", "PCRMMarketplaceRevenueShareAllocation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PartnerCentralRevenueMeasurement.Model.CreateMarketplaceRevenueShareAllocationResponse")]
    [AWSCmdlet("Calls the Partner Central Revenue Measurement API CreateMarketplaceRevenueShareAllocation API operation.", Operation = new[] {"CreateMarketplaceRevenueShareAllocation"}, SelectReturnType = typeof(Amazon.PartnerCentralRevenueMeasurement.Model.CreateMarketplaceRevenueShareAllocationResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralRevenueMeasurement.Model.CreateMarketplaceRevenueShareAllocationResponse",
        "This cmdlet returns an Amazon.PartnerCentralRevenueMeasurement.Model.CreateMarketplaceRevenueShareAllocationResponse object containing multiple properties."
    )]
    public partial class NewPCRMMarketplaceRevenueShareAllocationCmdlet : AmazonPartnerCentralRevenueMeasurementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog in which to create the allocation.</para>
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
        /// <para>The effective start date for the allocation. Must be the first day of a month.</para>
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
        public System.String EffectiveFrom { get; set; }
        #endregion
        
        #region Parameter EffectiveUntil
        /// <summary>
        /// <para>
        /// <para>The effective end date for the allocation. Must be the last day of a month (YYYY-MM-DD).
        /// Omit for open-ended allocations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EffectiveUntil { get; set; }
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
        /// <para>The revenue share percentage for this allocation.</para>
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
        public System.String RevenueSharePercent { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique token to ensure idempotency of the create request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralRevenueMeasurement.Model.CreateMarketplaceRevenueShareAllocationResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralRevenueMeasurement.Model.CreateMarketplaceRevenueShareAllocationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProductId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PCRMMarketplaceRevenueShareAllocation (CreateMarketplaceRevenueShareAllocation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralRevenueMeasurement.Model.CreateMarketplaceRevenueShareAllocationResponse, NewPCRMMarketplaceRevenueShareAllocationCmdlet>(Select) ??
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
            #if MODULAR
            if (this.EffectiveFrom == null && ParameterWasBound(nameof(this.EffectiveFrom)))
            {
                WriteWarning("You are passing $null as a value for parameter EffectiveFrom which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EffectiveUntil = this.EffectiveUntil;
            context.ProductId = this.ProductId;
            #if MODULAR
            if (this.ProductId == null && ParameterWasBound(nameof(this.ProductId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProductId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RevenueSharePercent = this.RevenueSharePercent;
            #if MODULAR
            if (this.RevenueSharePercent == null && ParameterWasBound(nameof(this.RevenueSharePercent)))
            {
                WriteWarning("You are passing $null as a value for parameter RevenueSharePercent which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PartnerCentralRevenueMeasurement.Model.CreateMarketplaceRevenueShareAllocationRequest();
            
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
            if (cmdletContext.ProductId != null)
            {
                request.ProductId = cmdletContext.ProductId;
            }
            if (cmdletContext.RevenueSharePercent != null)
            {
                request.RevenueSharePercent = cmdletContext.RevenueSharePercent;
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
        
        private Amazon.PartnerCentralRevenueMeasurement.Model.CreateMarketplaceRevenueShareAllocationResponse CallAWSServiceOperation(IAmazonPartnerCentralRevenueMeasurement client, Amazon.PartnerCentralRevenueMeasurement.Model.CreateMarketplaceRevenueShareAllocationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Revenue Measurement API", "CreateMarketplaceRevenueShareAllocation");
            try
            {
                return client.CreateMarketplaceRevenueShareAllocationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ProductId { get; set; }
            public System.String RevenueSharePercent { get; set; }
            public System.Func<Amazon.PartnerCentralRevenueMeasurement.Model.CreateMarketplaceRevenueShareAllocationResponse, NewPCRMMarketplaceRevenueShareAllocationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
