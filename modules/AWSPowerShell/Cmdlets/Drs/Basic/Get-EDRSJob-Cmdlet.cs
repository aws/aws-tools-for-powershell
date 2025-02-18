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
using Amazon.Drs;
using Amazon.Drs.Model;

namespace Amazon.PowerShell.Cmdlets.EDRS
{
    /// <summary>
    /// Returns a list of Jobs. Use the JobsID and fromDate and toDate filters to limit which
    /// jobs are returned. The response is sorted by creationDataTime - latest date first.
    /// Jobs are created by the StartRecovery, TerminateRecoveryInstances and StartFailbackLaunch
    /// APIs. Jobs are also created by DiagnosticLaunch and TerminateDiagnosticInstances,
    /// which are APIs available only to *Support* and only used in response to relevant support
    /// tickets.
    /// </summary>
    [Cmdlet("Get", "EDRSJob")]
    [OutputType("Amazon.Drs.Model.Job")]
    [AWSCmdlet("Calls the Elastic Disaster Recovery Service DescribeJobs API operation.", Operation = new[] {"DescribeJobs"}, SelectReturnType = typeof(Amazon.Drs.Model.DescribeJobsResponse))]
    [AWSCmdletOutput("Amazon.Drs.Model.Job or Amazon.Drs.Model.DescribeJobsResponse",
        "This cmdlet returns a collection of Amazon.Drs.Model.Job objects.",
        "The service call response (type Amazon.Drs.Model.DescribeJobsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEDRSJobCmdlet : AmazonDrsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filters_FromDate
        /// <summary>
        /// <para>
        /// <para>The start date in a date range query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_FromDate { get; set; }
        #endregion
        
        #region Parameter Filters_JobIDs
        /// <summary>
        /// <para>
        /// <para>An array of Job IDs that should be returned. An empty array means all jobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String[] Filters_JobIDs { get; set; }
        #endregion
        
        #region Parameter Filters_ToDate
        /// <summary>
        /// <para>
        /// <para>The end date in a date range query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_ToDate { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of Jobs to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token of the next Job to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Drs.Model.DescribeJobsResponse).
        /// Specifying the name of a property of type Amazon.Drs.Model.DescribeJobsResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.Drs.Model.DescribeJobsResponse, GetEDRSJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filters_FromDate = this.Filters_FromDate;
            if (this.Filters_JobIDs != null)
            {
                context.Filters_JobIDs = new List<System.String>(this.Filters_JobIDs);
            }
            context.Filters_ToDate = this.Filters_ToDate;
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
            var request = new Amazon.Drs.Model.DescribeJobsRequest();
            
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.Drs.Model.DescribeJobsRequestFilters();
            System.String requestFilters_filters_FromDate = null;
            if (cmdletContext.Filters_FromDate != null)
            {
                requestFilters_filters_FromDate = cmdletContext.Filters_FromDate;
            }
            if (requestFilters_filters_FromDate != null)
            {
                request.Filters.FromDate = requestFilters_filters_FromDate;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_JobIDs = null;
            if (cmdletContext.Filters_JobIDs != null)
            {
                requestFilters_filters_JobIDs = cmdletContext.Filters_JobIDs;
            }
            if (requestFilters_filters_JobIDs != null)
            {
                request.Filters.JobIDs = requestFilters_filters_JobIDs;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_ToDate = null;
            if (cmdletContext.Filters_ToDate != null)
            {
                requestFilters_filters_ToDate = cmdletContext.Filters_ToDate;
            }
            if (requestFilters_filters_ToDate != null)
            {
                request.Filters.ToDate = requestFilters_filters_ToDate;
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
        
        private Amazon.Drs.Model.DescribeJobsResponse CallAWSServiceOperation(IAmazonDrs client, Amazon.Drs.Model.DescribeJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Disaster Recovery Service", "DescribeJobs");
            try
            {
                return client.DescribeJobsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Filters_FromDate { get; set; }
            public List<System.String> Filters_JobIDs { get; set; }
            public System.String Filters_ToDate { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Drs.Model.DescribeJobsResponse, GetEDRSJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
