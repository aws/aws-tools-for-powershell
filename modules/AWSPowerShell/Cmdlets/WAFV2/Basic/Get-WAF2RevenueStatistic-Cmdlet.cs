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
using Amazon.WAFV2;
using Amazon.WAFV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WAF2
{
    /// <summary>
    /// Retrieves ranked monetization statistics. Use the <c>StatisticType</c> parameter to
    /// specify the ranking: <c>TOP_SOURCES_BY_REVENUE</c> for top sources by revenue, or
    /// <c>TOP_PATHS_BY_REVENUE</c> for top content paths by revenue. This operation is only
    /// available for <c>CLOUDFRONT</c> scope. The maximum supported time window is 90 days.
    /// When no <c>CurrencyMode</c> filter is provided, results default to <c>REAL</c>. To
    /// retrieve test data, include a <c>CurrencyMode</c> filter with the value <c>TEST</c>.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "WAF2RevenueStatistic")]
    [OutputType("Amazon.WAFV2.Model.GetRevenueStatisticsResponse")]
    [AWSCmdlet("Calls the AWS WAF V2 GetRevenueStatistics API operation.", Operation = new[] {"GetRevenueStatistics"}, SelectReturnType = typeof(Amazon.WAFV2.Model.GetRevenueStatisticsResponse))]
    [AWSCmdletOutput("Amazon.WAFV2.Model.GetRevenueStatisticsResponse",
        "This cmdlet returns an Amazon.WAFV2.Model.GetRevenueStatisticsResponse object containing multiple properties."
    )]
    public partial class GetWAF2RevenueStatisticCmdlet : AmazonWAFV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Currency
        /// <summary>
        /// <para>
        /// <para>The currency for the revenue amounts in the response.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WAFV2.Currency")]
        public Amazon.WAFV2.Currency Currency { get; set; }
        #endregion
        
        #region Parameter TimeWindow_EndTime
        /// <summary>
        /// <para>
        /// <para>The end of the time range from which you want <c>GetSampledRequests</c> to return
        /// a sample of the requests that your Amazon Web Services resource received. You must
        /// specify the times in Coordinated Universal Time (UTC) format. UTC format includes
        /// the special designator, <c>Z</c>. For example, <c>"2016-09-27T14:50Z"</c>. You can
        /// specify any time range in the previous three hours.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? TimeWindow_EndTime { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>Optional filters to narrow the results.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.WAFV2.Model.MonetizationFilter[] Filter { get; set; }
        #endregion
        
        #region Parameter GroupBy
        /// <summary>
        /// <para>
        /// <para>The dimension to group results by: <c>NAME</c>, <c>CATEGORY</c>, <c>INTENT</c>, <c>ORGANIZATION</c>,
        /// or <c>WEBACL</c>. Required when <c>StatisticType</c> is <c>TOP_SOURCES_BY_REVENUE</c>.
        /// Not required for <c>TOP_PATHS_BY_REVENUE</c>, where results are grouped by content
        /// path. If <c>StatisticType</c> is <c>TOP_SOURCES_BY_REVENUE</c> and <c>GroupBy</c>
        /// is omitted, the request is rejected with a <c>WAFInvalidParameterException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WAFV2.GroupByType")]
        public Amazon.WAFV2.GroupByType GroupBy { get; set; }
        #endregion
        
        #region Parameter Scope
        /// <summary>
        /// <para>
        /// <para>Specifies whether this is for a Amazon CloudFront distribution (<c>CLOUDFRONT</c>)
        /// or for a regional application (<c>REGIONAL</c>).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WAFV2.Scope")]
        public Amazon.WAFV2.Scope Scope { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The field to sort results by: <c>REVENUE</c>, <c>PERCENTAGE</c>, or <c>NAME</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WAFV2.RankingSortBy")]
        public Amazon.WAFV2.RankingSortBy SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>The sort order: <c>ASC</c> for ascending or <c>DESC</c> for descending.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WAFV2.SortOrder")]
        public Amazon.WAFV2.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter TimeWindow_StartTime
        /// <summary>
        /// <para>
        /// <para>The beginning of the time range from which you want <c>GetSampledRequests</c> to return
        /// a sample of the requests that your Amazon Web Services resource received. You must
        /// specify the times in Coordinated Universal Time (UTC) format. UTC format includes
        /// the special designator, <c>Z</c>. For example, <c>"2016-09-27T14:50Z"</c>. You can
        /// specify any time range in the previous three hours.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? TimeWindow_StartTime { get; set; }
        #endregion
        
        #region Parameter StatisticType
        /// <summary>
        /// <para>
        /// <para><c>TOP_SOURCES_BY_REVENUE</c> ranks revenue from AI bot traffic, grouped by the dimension
        /// you specify in the <c>GroupBy</c> parameter (<c>NAME</c>, <c>CATEGORY</c>, <c>INTENT</c>,
        /// <c>ORGANIZATION</c>, or <c>WEBACL</c>); <c>GroupBy</c> is required for this statistic
        /// type. <c>TOP_PATHS_BY_REVENUE</c> ranks revenue by path.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WAFV2.RankingStatisticType")]
        public Amazon.WAFV2.RankingStatisticType StatisticType { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter NextMarker
        /// <summary>
        /// <para>
        /// <para>When you get a paginated response, this marker indicates that additional results are
        /// available. Use it in a subsequent request to retrieve the next page of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextMarker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextMarker' to null for the first call then set the 'NextMarker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String NextMarker { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFV2.Model.GetRevenueStatisticsResponse).
        /// Specifying the name of a property of type Amazon.WAFV2.Model.GetRevenueStatisticsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextMarker
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.WAFV2.Model.GetRevenueStatisticsResponse, GetWAF2RevenueStatisticCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Currency = this.Currency;
            #if MODULAR
            if (this.Currency == null && ParameterWasBound(nameof(this.Currency)))
            {
                WriteWarning("You are passing $null as a value for parameter Currency which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.WAFV2.Model.MonetizationFilter>(this.Filter);
            }
            context.GroupBy = this.GroupBy;
            context.Limit = this.Limit;
            context.NextMarker = this.NextMarker;
            context.Scope = this.Scope;
            #if MODULAR
            if (this.Scope == null && ParameterWasBound(nameof(this.Scope)))
            {
                WriteWarning("You are passing $null as a value for parameter Scope which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            context.StatisticType = this.StatisticType;
            #if MODULAR
            if (this.StatisticType == null && ParameterWasBound(nameof(this.StatisticType)))
            {
                WriteWarning("You are passing $null as a value for parameter StatisticType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimeWindow_EndTime = this.TimeWindow_EndTime;
            #if MODULAR
            if (this.TimeWindow_EndTime == null && ParameterWasBound(nameof(this.TimeWindow_EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter TimeWindow_EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimeWindow_StartTime = this.TimeWindow_StartTime;
            #if MODULAR
            if (this.TimeWindow_StartTime == null && ParameterWasBound(nameof(this.TimeWindow_StartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter TimeWindow_StartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.WAFV2.Model.GetRevenueStatisticsRequest();
            
            if (cmdletContext.Currency != null)
            {
                request.Currency = cmdletContext.Currency;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.GroupBy != null)
            {
                request.GroupBy = cmdletContext.GroupBy;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.Scope != null)
            {
                request.Scope = cmdletContext.Scope;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            if (cmdletContext.StatisticType != null)
            {
                request.StatisticType = cmdletContext.StatisticType;
            }
            
             // populate TimeWindow
            var requestTimeWindowIsNull = true;
            request.TimeWindow = new Amazon.WAFV2.Model.TimeWindow();
            System.DateTime? requestTimeWindow_timeWindow_EndTime = null;
            if (cmdletContext.TimeWindow_EndTime != null)
            {
                requestTimeWindow_timeWindow_EndTime = cmdletContext.TimeWindow_EndTime.Value;
            }
            if (requestTimeWindow_timeWindow_EndTime != null)
            {
                request.TimeWindow.EndTime = requestTimeWindow_timeWindow_EndTime.Value;
                requestTimeWindowIsNull = false;
            }
            System.DateTime? requestTimeWindow_timeWindow_StartTime = null;
            if (cmdletContext.TimeWindow_StartTime != null)
            {
                requestTimeWindow_timeWindow_StartTime = cmdletContext.TimeWindow_StartTime.Value;
            }
            if (requestTimeWindow_timeWindow_StartTime != null)
            {
                request.TimeWindow.StartTime = requestTimeWindow_timeWindow_StartTime.Value;
                requestTimeWindowIsNull = false;
            }
             // determine if request.TimeWindow should be set to null
            if (requestTimeWindowIsNull)
            {
                request.TimeWindow = null;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextMarker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextMarker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextMarker = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextMarker;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.WAFV2.Model.GetRevenueStatisticsResponse CallAWSServiceOperation(IAmazonWAFV2 client, Amazon.WAFV2.Model.GetRevenueStatisticsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAF V2", "GetRevenueStatistics");
            try
            {
                return client.GetRevenueStatisticsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.WAFV2.Currency Currency { get; set; }
            public List<Amazon.WAFV2.Model.MonetizationFilter> Filter { get; set; }
            public Amazon.WAFV2.GroupByType GroupBy { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String NextMarker { get; set; }
            public Amazon.WAFV2.Scope Scope { get; set; }
            public Amazon.WAFV2.RankingSortBy SortBy { get; set; }
            public Amazon.WAFV2.SortOrder SortOrder { get; set; }
            public Amazon.WAFV2.RankingStatisticType StatisticType { get; set; }
            public System.DateTime? TimeWindow_EndTime { get; set; }
            public System.DateTime? TimeWindow_StartTime { get; set; }
            public System.Func<Amazon.WAFV2.Model.GetRevenueStatisticsResponse, GetWAF2RevenueStatisticCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
