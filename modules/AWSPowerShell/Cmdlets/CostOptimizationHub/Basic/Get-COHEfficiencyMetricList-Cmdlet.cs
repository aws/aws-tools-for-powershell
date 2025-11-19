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
using Amazon.CostOptimizationHub;
using Amazon.CostOptimizationHub.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.COH
{
    /// <summary>
    /// Returns cost efficiency metrics aggregated over time and optionally grouped by a specified
    /// dimension. The metrics provide insights into your cost optimization progress by tracking
    /// estimated savings, spending, and measures how effectively you're optimizing your Cloud
    /// resources.
    /// 
    ///  
    /// <para>
    /// The operation supports both daily and monthly time granularities and allows grouping
    /// results by account ID, Amazon Web Services Region. Results are returned as time-series
    /// data, enabling you to analyze trends in your cost optimization performance over the
    /// specified time period.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "COHEfficiencyMetricList")]
    [OutputType("Amazon.CostOptimizationHub.Model.EfficiencyMetricsByGroup")]
    [AWSCmdlet("Calls the Cost Optimization Hub ListEfficiencyMetrics API operation.", Operation = new[] {"ListEfficiencyMetrics"}, SelectReturnType = typeof(Amazon.CostOptimizationHub.Model.ListEfficiencyMetricsResponse))]
    [AWSCmdletOutput("Amazon.CostOptimizationHub.Model.EfficiencyMetricsByGroup or Amazon.CostOptimizationHub.Model.ListEfficiencyMetricsResponse",
        "This cmdlet returns a collection of Amazon.CostOptimizationHub.Model.EfficiencyMetricsByGroup objects.",
        "The service call response (type Amazon.CostOptimizationHub.Model.ListEfficiencyMetricsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCOHEfficiencyMetricListCmdlet : AmazonCostOptimizationHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter OrderBy_Dimension
        /// <summary>
        /// <para>
        /// <para>Sorts by dimension values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrderBy_Dimension { get; set; }
        #endregion
        
        #region Parameter TimePeriod_End
        /// <summary>
        /// <para>
        /// <para>The end of the time period (exclusive). Specify the date in ISO 8601 format, such
        /// as 2024-12-31.</para>
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
        public System.String TimePeriod_End { get; set; }
        #endregion
        
        #region Parameter Granularity
        /// <summary>
        /// <para>
        /// <para>The time granularity for the cost efficiency metrics. Specify <c>Daily</c> for metrics
        /// aggregated by day, or <c>Monthly</c> for metrics aggregated by month.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CostOptimizationHub.GranularityType")]
        public Amazon.CostOptimizationHub.GranularityType Granularity { get; set; }
        #endregion
        
        #region Parameter GroupBy
        /// <summary>
        /// <para>
        /// <para>The dimension by which to group the cost efficiency metrics. Valid values include
        /// account ID, Amazon Web Services Region. When no grouping is specified, metrics are
        /// aggregated across all resources in the specified time period.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GroupBy { get; set; }
        #endregion
        
        #region Parameter OrderBy_Order
        /// <summary>
        /// <para>
        /// <para>The order that's used to sort the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostOptimizationHub.Order")]
        public Amazon.CostOptimizationHub.Order OrderBy_Order { get; set; }
        #endregion
        
        #region Parameter TimePeriod_Start
        /// <summary>
        /// <para>
        /// <para>The beginning of the time period (inclusive). Specify the date in ISO 8601 format,
        /// such as 2024-01-01.</para>
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
        public System.String TimePeriod_Start { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of groups to return in the response. Valid values range from 0
        /// to 1000. Use in conjunction with <c>nextToken</c> to paginate through results when
        /// the total number of groups exceeds this limit.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to retrieve the next page of results. This value is returned in the response
        /// when the number of groups exceeds the specified <c>maxResults</c> value.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EfficiencyMetricsByGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostOptimizationHub.Model.ListEfficiencyMetricsResponse).
        /// Specifying the name of a property of type Amazon.CostOptimizationHub.Model.ListEfficiencyMetricsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EfficiencyMetricsByGroup";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
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
                context.Select = CreateSelectDelegate<Amazon.CostOptimizationHub.Model.ListEfficiencyMetricsResponse, GetCOHEfficiencyMetricListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Granularity = this.Granularity;
            #if MODULAR
            if (this.Granularity == null && ParameterWasBound(nameof(this.Granularity)))
            {
                WriteWarning("You are passing $null as a value for parameter Granularity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GroupBy = this.GroupBy;
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.OrderBy_Dimension = this.OrderBy_Dimension;
            context.OrderBy_Order = this.OrderBy_Order;
            context.TimePeriod_End = this.TimePeriod_End;
            #if MODULAR
            if (this.TimePeriod_End == null && ParameterWasBound(nameof(this.TimePeriod_End)))
            {
                WriteWarning("You are passing $null as a value for parameter TimePeriod_End which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimePeriod_Start = this.TimePeriod_Start;
            #if MODULAR
            if (this.TimePeriod_Start == null && ParameterWasBound(nameof(this.TimePeriod_Start)))
            {
                WriteWarning("You are passing $null as a value for parameter TimePeriod_Start which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CostOptimizationHub.Model.ListEfficiencyMetricsRequest();
            
            if (cmdletContext.Granularity != null)
            {
                request.Granularity = cmdletContext.Granularity;
            }
            if (cmdletContext.GroupBy != null)
            {
                request.GroupBy = cmdletContext.GroupBy;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            
             // populate OrderBy
            var requestOrderByIsNull = true;
            request.OrderBy = new Amazon.CostOptimizationHub.Model.OrderBy();
            System.String requestOrderBy_orderBy_Dimension = null;
            if (cmdletContext.OrderBy_Dimension != null)
            {
                requestOrderBy_orderBy_Dimension = cmdletContext.OrderBy_Dimension;
            }
            if (requestOrderBy_orderBy_Dimension != null)
            {
                request.OrderBy.Dimension = requestOrderBy_orderBy_Dimension;
                requestOrderByIsNull = false;
            }
            Amazon.CostOptimizationHub.Order requestOrderBy_orderBy_Order = null;
            if (cmdletContext.OrderBy_Order != null)
            {
                requestOrderBy_orderBy_Order = cmdletContext.OrderBy_Order;
            }
            if (requestOrderBy_orderBy_Order != null)
            {
                request.OrderBy.Order = requestOrderBy_orderBy_Order;
                requestOrderByIsNull = false;
            }
             // determine if request.OrderBy should be set to null
            if (requestOrderByIsNull)
            {
                request.OrderBy = null;
            }
            
             // populate TimePeriod
            var requestTimePeriodIsNull = true;
            request.TimePeriod = new Amazon.CostOptimizationHub.Model.TimePeriod();
            System.String requestTimePeriod_timePeriod_End = null;
            if (cmdletContext.TimePeriod_End != null)
            {
                requestTimePeriod_timePeriod_End = cmdletContext.TimePeriod_End;
            }
            if (requestTimePeriod_timePeriod_End != null)
            {
                request.TimePeriod.End = requestTimePeriod_timePeriod_End;
                requestTimePeriodIsNull = false;
            }
            System.String requestTimePeriod_timePeriod_Start = null;
            if (cmdletContext.TimePeriod_Start != null)
            {
                requestTimePeriod_timePeriod_Start = cmdletContext.TimePeriod_Start;
            }
            if (requestTimePeriod_timePeriod_Start != null)
            {
                request.TimePeriod.Start = requestTimePeriod_timePeriod_Start;
                requestTimePeriodIsNull = false;
            }
             // determine if request.TimePeriod should be set to null
            if (requestTimePeriodIsNull)
            {
                request.TimePeriod = null;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
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
                    
                    _nextToken = response.NextToken;
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
        
        private Amazon.CostOptimizationHub.Model.ListEfficiencyMetricsResponse CallAWSServiceOperation(IAmazonCostOptimizationHub client, Amazon.CostOptimizationHub.Model.ListEfficiencyMetricsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Cost Optimization Hub", "ListEfficiencyMetrics");
            try
            {
                return client.ListEfficiencyMetricsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.CostOptimizationHub.GranularityType Granularity { get; set; }
            public System.String GroupBy { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String OrderBy_Dimension { get; set; }
            public Amazon.CostOptimizationHub.Order OrderBy_Order { get; set; }
            public System.String TimePeriod_End { get; set; }
            public System.String TimePeriod_Start { get; set; }
            public System.Func<Amazon.CostOptimizationHub.Model.ListEfficiencyMetricsResponse, GetCOHEfficiencyMetricListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EfficiencyMetricsByGroup;
        }
        
    }
}
