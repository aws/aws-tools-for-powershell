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
using Amazon.BCMPricingCalculator;
using Amazon.BCMPricingCalculator.Model;

namespace Amazon.PowerShell.Cmdlets.BCMPC
{
    /// <summary>
    /// Lists all workload estimates for the account.
    /// </summary>
    [Cmdlet("Get", "BCMPCWorkloadEstimateList")]
    [OutputType("Amazon.BCMPricingCalculator.Model.WorkloadEstimateSummary")]
    [AWSCmdlet("Calls the AWS Pricing Calculator ListWorkloadEstimates API operation.", Operation = new[] {"ListWorkloadEstimates"}, SelectReturnType = typeof(Amazon.BCMPricingCalculator.Model.ListWorkloadEstimatesResponse))]
    [AWSCmdletOutput("Amazon.BCMPricingCalculator.Model.WorkloadEstimateSummary or Amazon.BCMPricingCalculator.Model.ListWorkloadEstimatesResponse",
        "This cmdlet returns a collection of Amazon.BCMPricingCalculator.Model.WorkloadEstimateSummary objects.",
        "The service call response (type Amazon.BCMPricingCalculator.Model.ListWorkloadEstimatesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBCMPCWorkloadEstimateListCmdlet : AmazonBCMPricingCalculatorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CreatedAtFilter_AfterTimestamp
        /// <summary>
        /// <para>
        /// <para> Include results after this timestamp. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreatedAtFilter_AfterTimestamp { get; set; }
        #endregion
        
        #region Parameter ExpiresAtFilter_AfterTimestamp
        /// <summary>
        /// <para>
        /// <para> Include results after this timestamp. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ExpiresAtFilter_AfterTimestamp { get; set; }
        #endregion
        
        #region Parameter CreatedAtFilter_BeforeTimestamp
        /// <summary>
        /// <para>
        /// <para> Include results before this timestamp. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreatedAtFilter_BeforeTimestamp { get; set; }
        #endregion
        
        #region Parameter ExpiresAtFilter_BeforeTimestamp
        /// <summary>
        /// <para>
        /// <para> Include results before this timestamp. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ExpiresAtFilter_BeforeTimestamp { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para> Filters to apply to the list of workload estimates. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.BCMPricingCalculator.Model.ListWorkloadEstimatesFilter[] Filter { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BCMPricingCalculator.Model.ListWorkloadEstimatesResponse).
        /// Specifying the name of a property of type Amazon.BCMPricingCalculator.Model.ListWorkloadEstimatesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BCMPricingCalculator.Model.ListWorkloadEstimatesResponse, GetBCMPCWorkloadEstimateListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CreatedAtFilter_AfterTimestamp = this.CreatedAtFilter_AfterTimestamp;
            context.CreatedAtFilter_BeforeTimestamp = this.CreatedAtFilter_BeforeTimestamp;
            context.ExpiresAtFilter_AfterTimestamp = this.ExpiresAtFilter_AfterTimestamp;
            context.ExpiresAtFilter_BeforeTimestamp = this.ExpiresAtFilter_BeforeTimestamp;
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.BCMPricingCalculator.Model.ListWorkloadEstimatesFilter>(this.Filter);
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
            var request = new Amazon.BCMPricingCalculator.Model.ListWorkloadEstimatesRequest();
            
            
             // populate CreatedAtFilter
            var requestCreatedAtFilterIsNull = true;
            request.CreatedAtFilter = new Amazon.BCMPricingCalculator.Model.FilterTimestamp();
            System.DateTime? requestCreatedAtFilter_createdAtFilter_AfterTimestamp = null;
            if (cmdletContext.CreatedAtFilter_AfterTimestamp != null)
            {
                requestCreatedAtFilter_createdAtFilter_AfterTimestamp = cmdletContext.CreatedAtFilter_AfterTimestamp.Value;
            }
            if (requestCreatedAtFilter_createdAtFilter_AfterTimestamp != null)
            {
                request.CreatedAtFilter.AfterTimestamp = requestCreatedAtFilter_createdAtFilter_AfterTimestamp.Value;
                requestCreatedAtFilterIsNull = false;
            }
            System.DateTime? requestCreatedAtFilter_createdAtFilter_BeforeTimestamp = null;
            if (cmdletContext.CreatedAtFilter_BeforeTimestamp != null)
            {
                requestCreatedAtFilter_createdAtFilter_BeforeTimestamp = cmdletContext.CreatedAtFilter_BeforeTimestamp.Value;
            }
            if (requestCreatedAtFilter_createdAtFilter_BeforeTimestamp != null)
            {
                request.CreatedAtFilter.BeforeTimestamp = requestCreatedAtFilter_createdAtFilter_BeforeTimestamp.Value;
                requestCreatedAtFilterIsNull = false;
            }
             // determine if request.CreatedAtFilter should be set to null
            if (requestCreatedAtFilterIsNull)
            {
                request.CreatedAtFilter = null;
            }
            
             // populate ExpiresAtFilter
            var requestExpiresAtFilterIsNull = true;
            request.ExpiresAtFilter = new Amazon.BCMPricingCalculator.Model.FilterTimestamp();
            System.DateTime? requestExpiresAtFilter_expiresAtFilter_AfterTimestamp = null;
            if (cmdletContext.ExpiresAtFilter_AfterTimestamp != null)
            {
                requestExpiresAtFilter_expiresAtFilter_AfterTimestamp = cmdletContext.ExpiresAtFilter_AfterTimestamp.Value;
            }
            if (requestExpiresAtFilter_expiresAtFilter_AfterTimestamp != null)
            {
                request.ExpiresAtFilter.AfterTimestamp = requestExpiresAtFilter_expiresAtFilter_AfterTimestamp.Value;
                requestExpiresAtFilterIsNull = false;
            }
            System.DateTime? requestExpiresAtFilter_expiresAtFilter_BeforeTimestamp = null;
            if (cmdletContext.ExpiresAtFilter_BeforeTimestamp != null)
            {
                requestExpiresAtFilter_expiresAtFilter_BeforeTimestamp = cmdletContext.ExpiresAtFilter_BeforeTimestamp.Value;
            }
            if (requestExpiresAtFilter_expiresAtFilter_BeforeTimestamp != null)
            {
                request.ExpiresAtFilter.BeforeTimestamp = requestExpiresAtFilter_expiresAtFilter_BeforeTimestamp.Value;
                requestExpiresAtFilterIsNull = false;
            }
             // determine if request.ExpiresAtFilter should be set to null
            if (requestExpiresAtFilterIsNull)
            {
                request.ExpiresAtFilter = null;
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
        
        private Amazon.BCMPricingCalculator.Model.ListWorkloadEstimatesResponse CallAWSServiceOperation(IAmazonBCMPricingCalculator client, Amazon.BCMPricingCalculator.Model.ListWorkloadEstimatesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Pricing Calculator", "ListWorkloadEstimates");
            try
            {
                #if DESKTOP
                return client.ListWorkloadEstimates(request);
                #elif CORECLR
                return client.ListWorkloadEstimatesAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public System.DateTime? CreatedAtFilter_AfterTimestamp { get; set; }
            public System.DateTime? CreatedAtFilter_BeforeTimestamp { get; set; }
            public System.DateTime? ExpiresAtFilter_AfterTimestamp { get; set; }
            public System.DateTime? ExpiresAtFilter_BeforeTimestamp { get; set; }
            public List<Amazon.BCMPricingCalculator.Model.ListWorkloadEstimatesFilter> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.BCMPricingCalculator.Model.ListWorkloadEstimatesResponse, GetBCMPCWorkloadEstimateListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
