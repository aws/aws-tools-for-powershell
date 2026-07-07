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
    /// Retrieves the details of a specific marketplace revenue share allocation.
    /// </summary>
    [Cmdlet("Get", "PCRMMarketplaceRevenueShareAllocation")]
    [OutputType("Amazon.PartnerCentralRevenueMeasurement.Model.GetMarketplaceRevenueShareAllocationResponse")]
    [AWSCmdlet("Calls the Partner Central Revenue Measurement API GetMarketplaceRevenueShareAllocation API operation.", Operation = new[] {"GetMarketplaceRevenueShareAllocation"}, SelectReturnType = typeof(Amazon.PartnerCentralRevenueMeasurement.Model.GetMarketplaceRevenueShareAllocationResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralRevenueMeasurement.Model.GetMarketplaceRevenueShareAllocationResponse",
        "This cmdlet returns an Amazon.PartnerCentralRevenueMeasurement.Model.GetMarketplaceRevenueShareAllocationResponse object containing multiple properties."
    )]
    public partial class GetPCRMMarketplaceRevenueShareAllocationCmdlet : AmazonPartnerCentralRevenueMeasurementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog that the allocation belongs to.</para>
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
        
        #region Parameter MarketplaceRevenueShareAllocationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the allocation to retrieve.</para>
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
        /// <para>The revision of the parent marketplace revenue share at which to retrieve the allocation.
        /// Omit to return the latest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MarketplaceRevenueShareRevision { get; set; }
        #endregion
        
        #region Parameter ProductId
        /// <summary>
        /// <para>
        /// <para>The AWS Marketplace product identifier of the parent revenue share.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralRevenueMeasurement.Model.GetMarketplaceRevenueShareAllocationResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralRevenueMeasurement.Model.GetMarketplaceRevenueShareAllocationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralRevenueMeasurement.Model.GetMarketplaceRevenueShareAllocationResponse, GetPCRMMarketplaceRevenueShareAllocationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MarketplaceRevenueShareAllocationId = this.MarketplaceRevenueShareAllocationId;
            #if MODULAR
            if (this.MarketplaceRevenueShareAllocationId == null && ParameterWasBound(nameof(this.MarketplaceRevenueShareAllocationId)))
            {
                WriteWarning("You are passing $null as a value for parameter MarketplaceRevenueShareAllocationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MarketplaceRevenueShareRevision = this.MarketplaceRevenueShareRevision;
            context.ProductId = this.ProductId;
            #if MODULAR
            if (this.ProductId == null && ParameterWasBound(nameof(this.ProductId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProductId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PartnerCentralRevenueMeasurement.Model.GetMarketplaceRevenueShareAllocationRequest();
            
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
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
        
        private Amazon.PartnerCentralRevenueMeasurement.Model.GetMarketplaceRevenueShareAllocationResponse CallAWSServiceOperation(IAmazonPartnerCentralRevenueMeasurement client, Amazon.PartnerCentralRevenueMeasurement.Model.GetMarketplaceRevenueShareAllocationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Revenue Measurement API", "GetMarketplaceRevenueShareAllocation");
            try
            {
                return client.GetMarketplaceRevenueShareAllocationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String MarketplaceRevenueShareAllocationId { get; set; }
            public System.String MarketplaceRevenueShareRevision { get; set; }
            public System.String ProductId { get; set; }
            public System.Func<Amazon.PartnerCentralRevenueMeasurement.Model.GetMarketplaceRevenueShareAllocationResponse, GetPCRMMarketplaceRevenueShareAllocationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
