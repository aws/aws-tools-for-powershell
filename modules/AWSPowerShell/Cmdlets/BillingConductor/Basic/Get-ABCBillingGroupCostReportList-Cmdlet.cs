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
using Amazon.BillingConductor;
using Amazon.BillingConductor.Model;

namespace Amazon.PowerShell.Cmdlets.ABC
{
    /// <summary>
    /// A paginated call to retrieve a summary report of actual Amazon Web Services charges
    /// and the calculated Amazon Web Services charges based on the associated pricing plan
    /// of a billing group.
    /// </summary>
    [Cmdlet("Get", "ABCBillingGroupCostReportList")]
    [OutputType("Amazon.BillingConductor.Model.BillingGroupCostReportElement")]
    [AWSCmdlet("Calls the AWSBillingConductor ListBillingGroupCostReports API operation.", Operation = new[] {"ListBillingGroupCostReports"}, SelectReturnType = typeof(Amazon.BillingConductor.Model.ListBillingGroupCostReportsResponse))]
    [AWSCmdletOutput("Amazon.BillingConductor.Model.BillingGroupCostReportElement or Amazon.BillingConductor.Model.ListBillingGroupCostReportsResponse",
        "This cmdlet returns a collection of Amazon.BillingConductor.Model.BillingGroupCostReportElement objects.",
        "The service call response (type Amazon.BillingConductor.Model.ListBillingGroupCostReportsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetABCBillingGroupCostReportListCmdlet : AmazonBillingConductorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filters_BillingGroupArn
        /// <summary>
        /// <para>
        /// <para>The list of Amazon Resource Names (ARNs) used to filter billing groups to retrieve
        /// reports. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_BillingGroupArns")]
        public System.String[] Filters_BillingGroupArn { get; set; }
        #endregion
        
        #region Parameter BillingPeriod
        /// <summary>
        /// <para>
        /// <para>The preferred billing period for your report. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BillingPeriod { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of reports to retrieve. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token that's used on subsequent calls to get reports. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BillingGroupCostReports'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BillingConductor.Model.ListBillingGroupCostReportsResponse).
        /// Specifying the name of a property of type Amazon.BillingConductor.Model.ListBillingGroupCostReportsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BillingGroupCostReports";
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
                context.Select = CreateSelectDelegate<Amazon.BillingConductor.Model.ListBillingGroupCostReportsResponse, GetABCBillingGroupCostReportListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BillingPeriod = this.BillingPeriod;
            if (this.Filters_BillingGroupArn != null)
            {
                context.Filters_BillingGroupArn = new List<System.String>(this.Filters_BillingGroupArn);
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
            var request = new Amazon.BillingConductor.Model.ListBillingGroupCostReportsRequest();
            
            if (cmdletContext.BillingPeriod != null)
            {
                request.BillingPeriod = cmdletContext.BillingPeriod;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.BillingConductor.Model.ListBillingGroupCostReportsFilter();
            List<System.String> requestFilters_filters_BillingGroupArn = null;
            if (cmdletContext.Filters_BillingGroupArn != null)
            {
                requestFilters_filters_BillingGroupArn = cmdletContext.Filters_BillingGroupArn;
            }
            if (requestFilters_filters_BillingGroupArn != null)
            {
                request.Filters.BillingGroupArns = requestFilters_filters_BillingGroupArn;
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
        
        private Amazon.BillingConductor.Model.ListBillingGroupCostReportsResponse CallAWSServiceOperation(IAmazonBillingConductor client, Amazon.BillingConductor.Model.ListBillingGroupCostReportsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSBillingConductor", "ListBillingGroupCostReports");
            try
            {
                #if DESKTOP
                return client.ListBillingGroupCostReports(request);
                #elif CORECLR
                return client.ListBillingGroupCostReportsAsync(request).GetAwaiter().GetResult();
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
            public System.String BillingPeriod { get; set; }
            public List<System.String> Filters_BillingGroupArn { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.BillingConductor.Model.ListBillingGroupCostReportsResponse, GetABCBillingGroupCostReportListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BillingGroupCostReports;
        }
        
    }
}
