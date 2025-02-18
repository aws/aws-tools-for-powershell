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
using Amazon.BCMPricingCalculator;
using Amazon.BCMPricingCalculator.Model;

namespace Amazon.PowerShell.Cmdlets.BCMPC
{
    /// <summary>
    /// Lists the line items associated with a bill estimate.
    /// </summary>
    [Cmdlet("Get", "BCMPCBillEstimateLineItemList")]
    [OutputType("Amazon.BCMPricingCalculator.Model.BillEstimateLineItemSummary")]
    [AWSCmdlet("Calls the AWS Pricing Calculator ListBillEstimateLineItems API operation.", Operation = new[] {"ListBillEstimateLineItems"}, SelectReturnType = typeof(Amazon.BCMPricingCalculator.Model.ListBillEstimateLineItemsResponse))]
    [AWSCmdletOutput("Amazon.BCMPricingCalculator.Model.BillEstimateLineItemSummary or Amazon.BCMPricingCalculator.Model.ListBillEstimateLineItemsResponse",
        "This cmdlet returns a collection of Amazon.BCMPricingCalculator.Model.BillEstimateLineItemSummary objects.",
        "The service call response (type Amazon.BCMPricingCalculator.Model.ListBillEstimateLineItemsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBCMPCBillEstimateLineItemListCmdlet : AmazonBCMPricingCalculatorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BillEstimateId
        /// <summary>
        /// <para>
        /// <para> The unique identifier of the bill estimate to list line items for. </para>
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
        public System.String BillEstimateId { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para> Filters to apply to the list of line items. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.BCMPricingCalculator.Model.ListBillEstimateLineItemsFilter[] Filter { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The maximum number of results to return per page. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para> A token to retrieve the next page of results. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BCMPricingCalculator.Model.ListBillEstimateLineItemsResponse).
        /// Specifying the name of a property of type Amazon.BCMPricingCalculator.Model.ListBillEstimateLineItemsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BCMPricingCalculator.Model.ListBillEstimateLineItemsResponse, GetBCMPCBillEstimateLineItemListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BillEstimateId = this.BillEstimateId;
            #if MODULAR
            if (this.BillEstimateId == null && ParameterWasBound(nameof(this.BillEstimateId)))
            {
                WriteWarning("You are passing $null as a value for parameter BillEstimateId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.BCMPricingCalculator.Model.ListBillEstimateLineItemsFilter>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.BCMPricingCalculator.Model.ListBillEstimateLineItemsRequest();
            
            if (cmdletContext.BillEstimateId != null)
            {
                request.BillEstimateId = cmdletContext.BillEstimateId;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.BCMPricingCalculator.Model.ListBillEstimateLineItemsResponse CallAWSServiceOperation(IAmazonBCMPricingCalculator client, Amazon.BCMPricingCalculator.Model.ListBillEstimateLineItemsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Pricing Calculator", "ListBillEstimateLineItems");
            try
            {
                return client.ListBillEstimateLineItemsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BillEstimateId { get; set; }
            public List<Amazon.BCMPricingCalculator.Model.ListBillEstimateLineItemsFilter> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.BCMPricingCalculator.Model.ListBillEstimateLineItemsResponse, GetBCMPCBillEstimateLineItemListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
