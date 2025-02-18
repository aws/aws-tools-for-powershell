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
using Amazon.Macie2;
using Amazon.Macie2.Model;

namespace Amazon.PowerShell.Cmdlets.MAC2
{
    /// <summary>
    /// Retrieves (queries) quotas and aggregated usage data for one or more accounts.
    /// </summary>
    [Cmdlet("Get", "MAC2UsageStatistic")]
    [OutputType("Amazon.Macie2.Model.UsageRecord")]
    [AWSCmdlet("Calls the Amazon Macie 2 GetUsageStatistics API operation.", Operation = new[] {"GetUsageStatistics"}, SelectReturnType = typeof(Amazon.Macie2.Model.GetUsageStatisticsResponse))]
    [AWSCmdletOutput("Amazon.Macie2.Model.UsageRecord or Amazon.Macie2.Model.GetUsageStatisticsResponse",
        "This cmdlet returns a collection of Amazon.Macie2.Model.UsageRecord objects.",
        "The service call response (type Amazon.Macie2.Model.GetUsageStatisticsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMAC2UsageStatisticCmdlet : AmazonMacie2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FilterBy
        /// <summary>
        /// <para>
        /// <para>An array of objects, one for each condition to use to filter the query results. If
        /// you specify more than one condition, Amazon Macie uses an AND operator to join the
        /// conditions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Macie2.Model.UsageStatisticsFilter[] FilterBy { get; set; }
        #endregion
        
        #region Parameter SortBy_Key
        /// <summary>
        /// <para>
        /// <para>The field to sort the results by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Macie2.UsageStatisticsSortKey")]
        public Amazon.Macie2.UsageStatisticsSortKey SortBy_Key { get; set; }
        #endregion
        
        #region Parameter SortBy_OrderBy
        /// <summary>
        /// <para>
        /// <para>The sort order to apply to the results, based on the value for the field specified
        /// by the key property. Valid values are: ASC, sort the results in ascending order; and,
        /// DESC, sort the results in descending order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Macie2.OrderBy")]
        public Amazon.Macie2.OrderBy SortBy_OrderBy { get; set; }
        #endregion
        
        #region Parameter TimeRange
        /// <summary>
        /// <para>
        /// <para>The inclusive time period to query usage data for. Valid values are: MONTH_TO_DATE,
        /// for the current calendar month to date; and, PAST_30_DAYS, for the preceding 30 days.
        /// If you don't specify a value, Amazon Macie provides usage data for the preceding 30
        /// days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Macie2.TimeRange")]
        public Amazon.Macie2.TimeRange TimeRange { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to include in each page of the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The nextToken string that specifies which page of results to return in a paginated
        /// response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Records'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Macie2.Model.GetUsageStatisticsResponse).
        /// Specifying the name of a property of type Amazon.Macie2.Model.GetUsageStatisticsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Records";
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
                context.Select = CreateSelectDelegate<Amazon.Macie2.Model.GetUsageStatisticsResponse, GetMAC2UsageStatisticCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.FilterBy != null)
            {
                context.FilterBy = new List<Amazon.Macie2.Model.UsageStatisticsFilter>(this.FilterBy);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SortBy_Key = this.SortBy_Key;
            context.SortBy_OrderBy = this.SortBy_OrderBy;
            context.TimeRange = this.TimeRange;
            
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
            var request = new Amazon.Macie2.Model.GetUsageStatisticsRequest();
            
            if (cmdletContext.FilterBy != null)
            {
                request.FilterBy = cmdletContext.FilterBy;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate SortBy
            var requestSortByIsNull = true;
            request.SortBy = new Amazon.Macie2.Model.UsageStatisticsSortBy();
            Amazon.Macie2.UsageStatisticsSortKey requestSortBy_sortBy_Key = null;
            if (cmdletContext.SortBy_Key != null)
            {
                requestSortBy_sortBy_Key = cmdletContext.SortBy_Key;
            }
            if (requestSortBy_sortBy_Key != null)
            {
                request.SortBy.Key = requestSortBy_sortBy_Key;
                requestSortByIsNull = false;
            }
            Amazon.Macie2.OrderBy requestSortBy_sortBy_OrderBy = null;
            if (cmdletContext.SortBy_OrderBy != null)
            {
                requestSortBy_sortBy_OrderBy = cmdletContext.SortBy_OrderBy;
            }
            if (requestSortBy_sortBy_OrderBy != null)
            {
                request.SortBy.OrderBy = requestSortBy_sortBy_OrderBy;
                requestSortByIsNull = false;
            }
             // determine if request.SortBy should be set to null
            if (requestSortByIsNull)
            {
                request.SortBy = null;
            }
            if (cmdletContext.TimeRange != null)
            {
                request.TimeRange = cmdletContext.TimeRange;
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
        
        private Amazon.Macie2.Model.GetUsageStatisticsResponse CallAWSServiceOperation(IAmazonMacie2 client, Amazon.Macie2.Model.GetUsageStatisticsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Macie 2", "GetUsageStatistics");
            try
            {
                return client.GetUsageStatisticsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Macie2.Model.UsageStatisticsFilter> FilterBy { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Macie2.UsageStatisticsSortKey SortBy_Key { get; set; }
            public Amazon.Macie2.OrderBy SortBy_OrderBy { get; set; }
            public Amazon.Macie2.TimeRange TimeRange { get; set; }
            public System.Func<Amazon.Macie2.Model.GetUsageStatisticsResponse, GetMAC2UsageStatisticCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Records;
        }
        
    }
}
