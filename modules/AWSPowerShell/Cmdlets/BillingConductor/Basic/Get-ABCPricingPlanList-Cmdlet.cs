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
using Amazon.BillingConductor;
using Amazon.BillingConductor.Model;

namespace Amazon.PowerShell.Cmdlets.ABC
{
    /// <summary>
    /// A paginated call to get pricing plans for the given billing period. If you don't provide
    /// a billing period, the current billing period is used.
    /// </summary>
    [Cmdlet("Get", "ABCPricingPlanList")]
    [OutputType("Amazon.BillingConductor.Model.ListPricingPlansResponse")]
    [AWSCmdlet("Calls the AWSBillingConductor ListPricingPlans API operation.", Operation = new[] {"ListPricingPlans"}, SelectReturnType = typeof(Amazon.BillingConductor.Model.ListPricingPlansResponse))]
    [AWSCmdletOutput("Amazon.BillingConductor.Model.ListPricingPlansResponse",
        "This cmdlet returns an Amazon.BillingConductor.Model.ListPricingPlansResponse object containing multiple properties."
    )]
    public partial class GetABCPricingPlanListCmdlet : AmazonBillingConductorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filters_Arn
        /// <summary>
        /// <para>
        /// <para>A list of pricing plan Amazon Resource Names (ARNs) to retrieve information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Arns")]
        public System.String[] Filters_Arn { get; set; }
        #endregion
        
        #region Parameter BillingPeriod
        /// <summary>
        /// <para>
        /// <para>The preferred billing period to get pricing plan. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BillingPeriod { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of pricing plans to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token that's used on subsequent call to get pricing plans. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BillingConductor.Model.ListPricingPlansResponse).
        /// Specifying the name of a property of type Amazon.BillingConductor.Model.ListPricingPlansResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BillingConductor.Model.ListPricingPlansResponse, GetABCPricingPlanListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BillingPeriod = this.BillingPeriod;
            if (this.Filters_Arn != null)
            {
                context.Filters_Arn = new List<System.String>(this.Filters_Arn);
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
            var request = new Amazon.BillingConductor.Model.ListPricingPlansRequest();
            
            if (cmdletContext.BillingPeriod != null)
            {
                request.BillingPeriod = cmdletContext.BillingPeriod;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.BillingConductor.Model.ListPricingPlansFilter();
            List<System.String> requestFilters_filters_Arn = null;
            if (cmdletContext.Filters_Arn != null)
            {
                requestFilters_filters_Arn = cmdletContext.Filters_Arn;
            }
            if (requestFilters_filters_Arn != null)
            {
                request.Filters.Arns = requestFilters_filters_Arn;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
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
        
        private Amazon.BillingConductor.Model.ListPricingPlansResponse CallAWSServiceOperation(IAmazonBillingConductor client, Amazon.BillingConductor.Model.ListPricingPlansRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSBillingConductor", "ListPricingPlans");
            try
            {
                return client.ListPricingPlansAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BillingPeriod { get; set; }
            public List<System.String> Filters_Arn { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.BillingConductor.Model.ListPricingPlansResponse, GetABCPricingPlanListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
