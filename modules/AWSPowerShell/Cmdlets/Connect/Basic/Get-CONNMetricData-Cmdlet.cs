/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Gets historical metric data from the specified Amazon Connect instance.
    /// 
    ///  
    /// <para>
    /// For a description of each historical metric, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/historical-metrics-definitions.html">Historical
    /// Metrics Definitions</a> in the <i>Amazon Connect Administrator Guide</i>.
    /// </para><note><para>
    /// We recommend using the <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_GetMetricDataV2.html">GetMetricDataV2</a>
    /// API. It provides more flexibility, features, and the ability to query longer time
    /// ranges than <code>GetMetricData</code>. Use it to retrieve historical agent and contact
    /// metrics for the last 3 months, at varying intervals. You can also use it to build
    /// custom dashboards to measure historical queue and agent performance. For example,
    /// you can track the number of incoming contacts for the last 7 days, with data split
    /// by day, to see how contact volume changed per day of the week.
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CONNMetricData")]
    [OutputType("Amazon.Connect.Model.HistoricalMetricResult")]
    [AWSCmdlet("Calls the Amazon Connect Service GetMetricData API operation.", Operation = new[] {"GetMetricData"}, SelectReturnType = typeof(Amazon.Connect.Model.GetMetricDataResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.HistoricalMetricResult or Amazon.Connect.Model.GetMetricDataResponse",
        "This cmdlet returns a collection of Amazon.Connect.Model.HistoricalMetricResult objects.",
        "The service call response (type Amazon.Connect.Model.GetMetricDataResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCONNMetricDataCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filters_Channel
        /// <summary>
        /// <para>
        /// <para>The channel to use to filter the metrics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Channels")]
        public System.String[] Filters_Channel { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The timestamp, in UNIX Epoch time format, at which to end the reporting interval for
        /// the retrieval of historical metrics data. The time must be specified using an interval
        /// of 5 minutes, such as 11:00, 11:05, 11:10, and must be later than the start time timestamp.</para><para>The time range between the start and end time must be less than 24 hours.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter Grouping
        /// <summary>
        /// <para>
        /// <para>The grouping applied to the metrics returned. For example, when results are grouped
        /// by queue, the metrics returned are grouped by queue. The values returned apply to
        /// the metrics for each queue rather than aggregated for all queues.</para><para>If no grouping is specified, a summary of metrics for all queues is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Groupings")]
        public System.String[] Grouping { get; set; }
        #endregion
        
        #region Parameter HistoricalMetric
        /// <summary>
        /// <para>
        /// <para>The metrics to retrieve. Specify the name, unit, and statistic for each metric. The
        /// following historical metrics are available. For a description of each metric, see
        /// <a href="https://docs.aws.amazon.com/connect/latest/adminguide/historical-metrics-definitions.html">Historical
        /// Metrics Definitions</a> in the <i>Amazon Connect Administrator Guide</i>.</para><note><para>This API does not support a contacts incoming metric (there's no CONTACTS_INCOMING
        /// metric missing from the documented list). </para></note><dl><dt>ABANDON_TIME</dt><dd><para>Unit: SECONDS</para><para>Statistic: AVG</para></dd><dt>AFTER_CONTACT_WORK_TIME</dt><dd><para>Unit: SECONDS</para><para>Statistic: AVG</para></dd><dt>API_CONTACTS_HANDLED</dt><dd><para>Unit: COUNT</para><para>Statistic: SUM</para></dd><dt>CALLBACK_CONTACTS_HANDLED</dt><dd><para>Unit: COUNT</para><para>Statistic: SUM</para></dd><dt>CONTACTS_ABANDONED</dt><dd><para>Unit: COUNT</para><para>Statistic: SUM</para></dd><dt>CONTACTS_AGENT_HUNG_UP_FIRST</dt><dd><para>Unit: COUNT</para><para>Statistic: SUM</para></dd><dt>CONTACTS_CONSULTED</dt><dd><para>Unit: COUNT</para><para>Statistic: SUM</para></dd><dt>CONTACTS_HANDLED</dt><dd><para>Unit: COUNT</para><para>Statistic: SUM</para></dd><dt>CONTACTS_HANDLED_INCOMING</dt><dd><para>Unit: COUNT</para><para>Statistic: SUM</para></dd><dt>CONTACTS_HANDLED_OUTBOUND</dt><dd><para>Unit: COUNT</para><para>Statistic: SUM</para></dd><dt>CONTACTS_HOLD_ABANDONS</dt><dd><para>Unit: COUNT</para><para>Statistic: SUM</para></dd><dt>CONTACTS_MISSED</dt><dd><para>Unit: COUNT</para><para>Statistic: SUM</para></dd><dt>CONTACTS_QUEUED</dt><dd><para>Unit: COUNT</para><para>Statistic: SUM</para></dd><dt>CONTACTS_TRANSFERRED_IN</dt><dd><para>Unit: COUNT</para><para>Statistic: SUM</para></dd><dt>CONTACTS_TRANSFERRED_IN_FROM_QUEUE</dt><dd><para>Unit: COUNT</para><para>Statistic: SUM</para></dd><dt>CONTACTS_TRANSFERRED_OUT</dt><dd><para>Unit: COUNT</para><para>Statistic: SUM</para></dd><dt>CONTACTS_TRANSFERRED_OUT_FROM_QUEUE</dt><dd><para>Unit: COUNT</para><para>Statistic: SUM</para></dd><dt>HANDLE_TIME</dt><dd><para>Unit: SECONDS</para><para>Statistic: AVG</para></dd><dt>HOLD_TIME</dt><dd><para>Unit: SECONDS</para><para>Statistic: AVG</para></dd><dt>INTERACTION_AND_HOLD_TIME</dt><dd><para>Unit: SECONDS</para><para>Statistic: AVG</para></dd><dt>INTERACTION_TIME</dt><dd><para>Unit: SECONDS</para><para>Statistic: AVG</para></dd><dt>OCCUPANCY</dt><dd><para>Unit: PERCENT</para><para>Statistic: AVG</para></dd><dt>QUEUE_ANSWER_TIME</dt><dd><para>Unit: SECONDS</para><para>Statistic: AVG</para></dd><dt>QUEUED_TIME</dt><dd><para>Unit: SECONDS</para><para>Statistic: MAX</para></dd><dt>SERVICE_LEVEL</dt><dd><para>You can include up to 20 SERVICE_LEVEL metrics in a request.</para><para>Unit: PERCENT</para><para>Statistic: AVG</para><para>Threshold: For <code>ThresholdValue</code>, enter any whole number from 1 to 604800
        /// (inclusive), in seconds. For <code>Comparison</code>, you must enter <code>LT</code>
        /// (for "Less than"). </para></dd></dl>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("HistoricalMetrics")]
        public Amazon.Connect.Model.HistoricalMetric[] HistoricalMetric { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Filters_Queue
        /// <summary>
        /// <para>
        /// <para>The queues to use to filter the metrics. You should specify at least one queue, and
        /// can specify up to 100 queues per request. The <code>GetCurrentMetricsData</code> API
        /// in particular requires a queue when you include a <code>Filter</code> in your request.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Queues")]
        public System.String[] Filters_Queue { get; set; }
        #endregion
        
        #region Parameter Filters_RoutingProfile
        /// <summary>
        /// <para>
        /// <para>A list of up to 100 routing profile IDs or ARNs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_RoutingProfiles")]
        public System.String[] Filters_RoutingProfile { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The timestamp, in UNIX Epoch time format, at which to start the reporting interval
        /// for the retrieval of historical metrics data. The time must be specified using a multiple
        /// of 5 minutes, such as 10:05, 10:10, 10:15.</para><para>The start time cannot be earlier than 24 hours before the time of the request. Historical
        /// metrics are available only for 24 hours.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return per page.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>100</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results. Use the value returned in the previous response
        /// in the next request to retrieve the next set of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MetricResults'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.GetMetricDataResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.GetMetricDataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MetricResults";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.GetMetricDataResponse, GetCONNMetricDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EndTime = this.EndTime;
            #if MODULAR
            if (this.EndTime == null && ParameterWasBound(nameof(this.EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Filters_Channel != null)
            {
                context.Filters_Channel = new List<System.String>(this.Filters_Channel);
            }
            if (this.Filters_Queue != null)
            {
                context.Filters_Queue = new List<System.String>(this.Filters_Queue);
            }
            if (this.Filters_RoutingProfile != null)
            {
                context.Filters_RoutingProfile = new List<System.String>(this.Filters_RoutingProfile);
            }
            if (this.Grouping != null)
            {
                context.Grouping = new List<System.String>(this.Grouping);
            }
            if (this.HistoricalMetric != null)
            {
                context.HistoricalMetric = new List<Amazon.Connect.Model.HistoricalMetric>(this.HistoricalMetric);
            }
            #if MODULAR
            if (this.HistoricalMetric == null && ParameterWasBound(nameof(this.HistoricalMetric)))
            {
                WriteWarning("You are passing $null as a value for parameter HistoricalMetric which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            #if MODULAR
            if (!ParameterWasBound(nameof(this.MaxResult)))
            {
                WriteVerbose("MaxResult parameter unset, using default value of '100'");
                context.MaxResult = 100;
            }
            #endif
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
            context.StartTime = this.StartTime;
            #if MODULAR
            if (this.StartTime == null && ParameterWasBound(nameof(this.StartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter StartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.Connect.Model.GetMetricDataRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.Connect.Model.Filters();
            List<System.String> requestFilters_filters_Channel = null;
            if (cmdletContext.Filters_Channel != null)
            {
                requestFilters_filters_Channel = cmdletContext.Filters_Channel;
            }
            if (requestFilters_filters_Channel != null)
            {
                request.Filters.Channels = requestFilters_filters_Channel;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_Queue = null;
            if (cmdletContext.Filters_Queue != null)
            {
                requestFilters_filters_Queue = cmdletContext.Filters_Queue;
            }
            if (requestFilters_filters_Queue != null)
            {
                request.Filters.Queues = requestFilters_filters_Queue;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_RoutingProfile = null;
            if (cmdletContext.Filters_RoutingProfile != null)
            {
                requestFilters_filters_RoutingProfile = cmdletContext.Filters_RoutingProfile;
            }
            if (requestFilters_filters_RoutingProfile != null)
            {
                request.Filters.RoutingProfiles = requestFilters_filters_RoutingProfile;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.Grouping != null)
            {
                request.Groupings = cmdletContext.Grouping;
            }
            if (cmdletContext.HistoricalMetric != null)
            {
                request.HistoricalMetrics = cmdletContext.HistoricalMetric;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
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
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            
            // create request and set iteration invariants
            var request = new Amazon.Connect.Model.GetMetricDataRequest();
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.Connect.Model.Filters();
            List<System.String> requestFilters_filters_Channel = null;
            if (cmdletContext.Filters_Channel != null)
            {
                requestFilters_filters_Channel = cmdletContext.Filters_Channel;
            }
            if (requestFilters_filters_Channel != null)
            {
                request.Filters.Channels = requestFilters_filters_Channel;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_Queue = null;
            if (cmdletContext.Filters_Queue != null)
            {
                requestFilters_filters_Queue = cmdletContext.Filters_Queue;
            }
            if (requestFilters_filters_Queue != null)
            {
                request.Filters.Queues = requestFilters_filters_Queue;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_RoutingProfile = null;
            if (cmdletContext.Filters_RoutingProfile != null)
            {
                requestFilters_filters_RoutingProfile = cmdletContext.Filters_RoutingProfile;
            }
            if (requestFilters_filters_RoutingProfile != null)
            {
                request.Filters.RoutingProfiles = requestFilters_filters_RoutingProfile;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.Grouping != null)
            {
                request.Groupings = cmdletContext.Grouping;
            }
            if (cmdletContext.HistoricalMetric != null)
            {
                request.HistoricalMetrics = cmdletContext.HistoricalMetric;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult.HasValue)
            {
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(100, _emitLimit.Value);
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                else if (!ParameterWasBound(nameof(this.MaxResult)))
                {
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(100);
                }
                
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
                    int _receivedThisCall = response.MetricResults.Count;
                    
                    _nextToken = response.NextToken;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Connect.Model.GetMetricDataResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.GetMetricDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "GetMetricData");
            try
            {
                #if DESKTOP
                return client.GetMetricData(request);
                #elif CORECLR
                return client.GetMetricDataAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? EndTime { get; set; }
            public List<System.String> Filters_Channel { get; set; }
            public List<System.String> Filters_Queue { get; set; }
            public List<System.String> Filters_RoutingProfile { get; set; }
            public List<System.String> Grouping { get; set; }
            public List<Amazon.Connect.Model.HistoricalMetric> HistoricalMetric { get; set; }
            public System.String InstanceId { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.Connect.Model.GetMetricDataResponse, GetCONNMetricDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MetricResults;
        }
        
    }
}
