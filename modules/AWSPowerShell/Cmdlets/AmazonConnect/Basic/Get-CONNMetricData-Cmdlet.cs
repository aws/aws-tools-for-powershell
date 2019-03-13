/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// The <code>GetMetricData</code> operation retrieves historical metrics data from your
    /// Amazon Connect instance.
    /// 
    ///  
    /// <para>
    /// If you are using an IAM account, it must have permission to the <code>connect:GetMetricData</code>
    /// action.
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "CONNMetricData")]
    [OutputType("Amazon.Connect.Model.HistoricalMetricResult")]
    [AWSCmdlet("Calls the Amazon Connect Service GetMetricData API operation.", Operation = new[] {"GetMetricData"})]
    [AWSCmdletOutput("Amazon.Connect.Model.HistoricalMetricResult",
        "This cmdlet returns a collection of HistoricalMetricResult objects.",
        "The service call response (type Amazon.Connect.Model.GetMetricDataResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetCONNMetricDataCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        #region Parameter Filters_Channel
        /// <summary>
        /// <para>
        /// <para>The Channel to use as a filter for the metrics returned. Only VOICE is supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filters_Channels")]
        public System.String[] Filters_Channel { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The timestamp, in UNIX Epoch time format, at which to end the reporting interval for
        /// the retrieval of historical metrics data. The time must be specified using an interval
        /// of 5 minutes, such as 11:00, 11:05, 11:10, and must be later than the <code>StartTime</code>
        /// timestamp.</para><para>The time range between <code>StartTime</code> and <code>EndTime</code> must be less
        /// than 24 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime EndTime { get; set; }
        #endregion
        
        #region Parameter Grouping
        /// <summary>
        /// <para>
        /// <para>The grouping applied to the metrics returned. For example, when results are grouped
        /// by queueId, the metrics returned are grouped by queue. The values returned apply to
        /// the metrics for each queue rather than aggregated for all queues.</para><para>The current version supports grouping by Queue</para><para>If no <code>Grouping</code> is included in the request, a summary of <code>HistoricalMetrics</code>
        /// for all queues is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Groupings")]
        public System.String[] Grouping { get; set; }
        #endregion
        
        #region Parameter HistoricalMetric
        /// <summary>
        /// <para>
        /// <para>A list of <code>HistoricalMetric</code> objects that contain the metrics to retrieve
        /// with the request.</para><para>A <code>HistoricalMetric</code> object contains: <code>HistoricalMetricName</code>,
        /// <code>Statistic</code>, <code>Threshold</code>, and <code>Unit</code>.</para><para>You must list each metric to retrieve data for in the request. For each historical
        /// metric you include in the request, you must include a <code>Unit</code> and a <code>Statistic</code>.
        /// </para><para>The following historical metrics are available:</para><dl><dt>CONTACTS_QUEUED</dt><dd><para>Unit: COUNT</para><para>Statistic: SUM</para></dd><dt>CONTACTS_HANDLED</dt><dd><para>Unit: COUNT</para><para>Statistics: SUM</para></dd><dt>CONTACTS_ABANDONED</dt><dd><para>Unit: COUNT</para><para>Statistics: SUM</para></dd><dt>CONTACTS_CONSULTED</dt><dd><para>Unit: COUNT</para><para>Statistics: SUM</para></dd><dt>CONTACTS_AGENT_HUNG_UP_FIRST</dt><dd><para>Unit: COUNT</para><para>Statistics: SUM</para></dd><dt>CONTACTS_HANDLED_INCOMING</dt><dd><para>Unit: COUNT</para><para>Statistics: SUM</para></dd><dt>CONTACTS_HANDLED_OUTBOUND</dt><dd><para>Unit: COUNT</para><para>Statistics: SUM</para></dd><dt>CONTACTS_HOLD_ABANDONS</dt><dd><para>Unit: COUNT</para><para>Statistics: SUM</para></dd><dt>CONTACTS_TRANSFERRED_IN</dt><dd><para>Unit: COUNT</para><para>Statistics: SUM</para></dd><dt>CONTACTS_TRANSFERRED_OUT</dt><dd><para>Unit: COUNT</para><para>Statistics: SUM</para></dd><dt>CONTACTS_TRANSFERRED_IN_FROM_QUEUE</dt><dd><para>Unit: COUNT</para><para>Statistics: SUM</para></dd><dt>CONTACTS_TRANSFERRED_OUT_FROM_QUEUE</dt><dd><para>Unit: COUNT</para><para>Statistics: SUM</para></dd><dt>CALLBACK_CONTACTS_HANDLED</dt><dd><para>Unit: COUNT</para><para>Statistics: SUM</para></dd><dt>CALLBACK_CONTACTS_HANDLED</dt><dd><para>Unit: COUNT</para><para>Statistics: SUM</para></dd><dt>API_CONTACTS_HANDLED</dt><dd><para>Unit: COUNT</para><para>Statistics: SUM</para></dd><dt>CONTACTS_MISSED</dt><dd><para>Unit: COUNT</para><para>Statistics: SUM</para></dd><dt>OCCUPANCY</dt><dd><para>Unit: PERCENT</para><para>Statistics: AVG</para></dd><dt>HANDLE_TIME</dt><dd><para>Unit: SECONDS</para><para>Statistics: AVG</para></dd><dt>AFTER_CONTACT_WORK_TIME</dt><dd><para>Unit: SECONDS</para><para>Statistics: AVG</para></dd><dt>QUEUED_TIME</dt><dd><para>Unit: SECONDS</para><para>Statistics: MAX</para></dd><dt>ABANDON_TIME</dt><dd><para>Unit: COUNT</para><para>Statistics: SUM</para></dd><dt>QUEUE_ANSWER_TIME</dt><dd><para>Unit: SECONDS</para><para>Statistics: AVG</para></dd><dt>HOLD_TIME</dt><dd><para>Unit: SECONDS</para><para>Statistics: AVG</para></dd><dt>INTERACTION_TIME</dt><dd><para>Unit: SECONDS</para><para>Statistics: AVG</para></dd><dt>INTERACTION_AND_HOLD_TIME</dt><dd><para>Unit: SECONDS</para><para>Statistics: AVG</para></dd><dt>SERVICE_LEVEL</dt><dd><para>Unit: PERCENT</para><para>Statistics: AVG</para><para>Threshold: Only "Less than" comparisons are supported, with the following service
        /// level thresholds: 15, 20, 25, 30, 45, 60, 90, 120, 180, 240, 300, 600</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HistoricalMetrics")]
        public Amazon.Connect.Model.HistoricalMetric[] HistoricalMetric { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier for your Amazon Connect instance. To find the ID of your instance,
        /// open the AWS console and select Amazon Connect. Select the alias of the instance in
        /// the Instance alias column. The instance ID is displayed in the Overview section of
        /// your instance settings. For example, the instance ID is the set of characters at the
        /// end of the instance ARN, after instance/, such as 10a4c4eb-f57e-4d4c-b602-bf39176ced07.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Filters_Queue
        /// <summary>
        /// <para>
        /// <para>A list of up to 100 queue IDs or queue ARNs to use to filter the metrics retrieved.
        /// You can include both IDs and ARNs in a request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filters_Queues")]
        public System.String[] Filters_Queue { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The timestamp, in UNIX Epoch time format, at which to start the reporting interval
        /// for the retrieval of historical metrics data. The time must be specified using a multiple
        /// of 5 minutes, such as 10:05, 10:10, 10:15.</para><para><code>StartTime</code> cannot be earlier than 24 hours before the time of the request.
        /// Historical metrics are available in Amazon Connect only for 24 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime StartTime { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Indicates the maximum number of results to return per page in the response, between
        /// 1-100.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results. Use the value returned in the previous response
        /// in the next request to retrieve the next set of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, assign $null, for the first call, and the value of $AWSHistory.LastServiceResponse.NextToken, for subsequent calls, to this parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("EndTime"))
                context.EndTime = this.EndTime;
            if (this.Filters_Channel != null)
            {
                context.Filters_Channels = new List<System.String>(this.Filters_Channel);
            }
            if (this.Filters_Queue != null)
            {
                context.Filters_Queues = new List<System.String>(this.Filters_Queue);
            }
            if (this.Grouping != null)
            {
                context.Groupings = new List<System.String>(this.Grouping);
            }
            if (this.HistoricalMetric != null)
            {
                context.HistoricalMetrics = new List<Amazon.Connect.Model.HistoricalMetric>(this.HistoricalMetric);
            }
            context.InstanceId = this.InstanceId;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            if (ParameterWasBound("StartTime"))
                context.StartTime = this.StartTime;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.Connect.Model.GetMetricDataRequest();
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            
             // populate Filters
            bool requestFiltersIsNull = true;
            request.Filters = new Amazon.Connect.Model.Filters();
            List<System.String> requestFilters_filters_Channel = null;
            if (cmdletContext.Filters_Channels != null)
            {
                requestFilters_filters_Channel = cmdletContext.Filters_Channels;
            }
            if (requestFilters_filters_Channel != null)
            {
                request.Filters.Channels = requestFilters_filters_Channel;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_Queue = null;
            if (cmdletContext.Filters_Queues != null)
            {
                requestFilters_filters_Queue = cmdletContext.Filters_Queues;
            }
            if (requestFilters_filters_Queue != null)
            {
                request.Filters.Queues = requestFilters_filters_Queue;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.Groupings != null)
            {
                request.Groupings = cmdletContext.Groupings;
            }
            if (cmdletContext.HistoricalMetrics != null)
            {
                request.HistoricalMetrics = cmdletContext.HistoricalMetrics;
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
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            int? _pageSize = 1000;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxResults))
            {
                // The service has a maximum page size of 1000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 1000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResults;
            }
            bool _userControllingPaging = ParameterWasBound("NextToken") || ParameterWasBound("MaxResult");
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    if (AutoIterationHelpers.HasValue(_pageSize))
                    {
                        int correctPageSize;
                        if (AutoIterationHelpers.IsSet(request.MaxResults))
                        {
                            correctPageSize = AutoIterationHelpers.Min(_pageSize.Value, request.MaxResults);
                        }
                        else
                        {
                            correctPageSize = _pageSize.Value;
                        }
                        request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = CallAWSServiceOperation(client, request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.MetricResults;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.MetricResults.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                        
                        _retrievedSoFar += _receivedThisCall;
                        if (AutoIterationHelpers.HasValue(_emitLimit) && (_retrievedSoFar == 0 || _retrievedSoFar >= _emitLimit.Value))
                        {
                            _continueIteration = false;
                        }
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                    // The service has a maximum page size of 1000 and the user has set a retrieval limit.
                    // Deduce what's left to fetch and if less than one page update _emitLimit to fetch just
                    // what's left to match the user's request.
                    
                    var _remainingItems = _emitLimit - _retrievedSoFar;
                    if (_remainingItems < _pageSize)
                    {
                        _emitLimit = _remainingItems;
                    }
                } while (_continueIteration && AutoIterationHelpers.HasValue(_nextMarker));
                
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
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
            public List<System.String> Filters_Channels { get; set; }
            public List<System.String> Filters_Queues { get; set; }
            public List<System.String> Groupings { get; set; }
            public List<Amazon.Connect.Model.HistoricalMetric> HistoricalMetrics { get; set; }
            public System.String InstanceId { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public System.DateTime? StartTime { get; set; }
        }
        
    }
}
