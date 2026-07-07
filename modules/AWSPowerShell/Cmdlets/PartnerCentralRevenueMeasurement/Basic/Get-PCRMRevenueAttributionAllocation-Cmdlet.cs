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
    /// Retrieves a single allocation by its RevenueAttributionAllocationId. Supports optional
    /// point-in-time version queries.
    /// </summary>
    [Cmdlet("Get", "PCRMRevenueAttributionAllocation")]
    [OutputType("Amazon.PartnerCentralRevenueMeasurement.Model.GetRevenueAttributionAllocationResponse")]
    [AWSCmdlet("Calls the Partner Central Revenue Measurement API GetRevenueAttributionAllocation API operation.", Operation = new[] {"GetRevenueAttributionAllocation"}, SelectReturnType = typeof(Amazon.PartnerCentralRevenueMeasurement.Model.GetRevenueAttributionAllocationResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralRevenueMeasurement.Model.GetRevenueAttributionAllocationResponse",
        "This cmdlet returns an Amazon.PartnerCentralRevenueMeasurement.Model.GetRevenueAttributionAllocationResponse object containing multiple properties."
    )]
    public partial class GetPCRMRevenueAttributionAllocationCmdlet : AmazonPartnerCentralRevenueMeasurementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog that contains the resource.</para>
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
        
        #region Parameter RevenueAttributionAllocationId
        /// <summary>
        /// <para>
        /// <para>The allocation identifier.</para>
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
        public System.String RevenueAttributionAllocationId { get; set; }
        #endregion
        
        #region Parameter RevenueAttributionIdentifier
        /// <summary>
        /// <para>
        /// <para>The revenue attribution identifier.</para>
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
        public System.String RevenueAttributionIdentifier { get; set; }
        #endregion
        
        #region Parameter RevenueAttributionRevision
        /// <summary>
        /// <para>
        /// <para>Point-in-time revision number to query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RevenueAttributionRevision { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralRevenueMeasurement.Model.GetRevenueAttributionAllocationResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralRevenueMeasurement.Model.GetRevenueAttributionAllocationResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralRevenueMeasurement.Model.GetRevenueAttributionAllocationResponse, GetPCRMRevenueAttributionAllocationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RevenueAttributionAllocationId = this.RevenueAttributionAllocationId;
            #if MODULAR
            if (this.RevenueAttributionAllocationId == null && ParameterWasBound(nameof(this.RevenueAttributionAllocationId)))
            {
                WriteWarning("You are passing $null as a value for parameter RevenueAttributionAllocationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RevenueAttributionIdentifier = this.RevenueAttributionIdentifier;
            #if MODULAR
            if (this.RevenueAttributionIdentifier == null && ParameterWasBound(nameof(this.RevenueAttributionIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter RevenueAttributionIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RevenueAttributionRevision = this.RevenueAttributionRevision;
            
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
            var request = new Amazon.PartnerCentralRevenueMeasurement.Model.GetRevenueAttributionAllocationRequest();
            
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.RevenueAttributionAllocationId != null)
            {
                request.RevenueAttributionAllocationId = cmdletContext.RevenueAttributionAllocationId;
            }
            if (cmdletContext.RevenueAttributionIdentifier != null)
            {
                request.RevenueAttributionIdentifier = cmdletContext.RevenueAttributionIdentifier;
            }
            if (cmdletContext.RevenueAttributionRevision != null)
            {
                request.RevenueAttributionRevision = cmdletContext.RevenueAttributionRevision;
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
        
        private Amazon.PartnerCentralRevenueMeasurement.Model.GetRevenueAttributionAllocationResponse CallAWSServiceOperation(IAmazonPartnerCentralRevenueMeasurement client, Amazon.PartnerCentralRevenueMeasurement.Model.GetRevenueAttributionAllocationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Revenue Measurement API", "GetRevenueAttributionAllocation");
            try
            {
                return client.GetRevenueAttributionAllocationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String RevenueAttributionAllocationId { get; set; }
            public System.String RevenueAttributionIdentifier { get; set; }
            public System.String RevenueAttributionRevision { get; set; }
            public System.Func<Amazon.PartnerCentralRevenueMeasurement.Model.GetRevenueAttributionAllocationResponse, GetPCRMRevenueAttributionAllocationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
