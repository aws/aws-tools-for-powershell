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
    /// Gets metric data from the specified Amazon Connect instance. 
    /// 
    ///  
    /// <para><code>GetMetricDataV2</code> offers more features than <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_GetMetricData.html">GetMetricData</a>,
    /// the previous version of this API. It has new metrics, offers filtering at a metric
    /// level, and offers the ability to filter and group data by channels, queues, routing
    /// profiles, agents, and agent hierarchy levels. It can retrieve historical data for
    /// the last 14 days, in 24-hour intervals.
    /// </para><para>
    /// For a description of the historical metrics that are supported by <code>GetMetricDataV2</code>
    /// and <code>GetMetricData</code>, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/historical-metrics-definitions.html">Historical
    /// metrics definitions</a> in the <i>Amazon Connect Administrator's Guide</i>. 
    /// </para><para>
    /// This API is not available in the Amazon Web Services GovCloud (US) Regions.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CONNMetricDataV2")]
    [OutputType("Amazon.Connect.Model.MetricResultV2")]
    [AWSCmdlet("Calls the Amazon Connect Service GetMetricDataV2 API operation.", Operation = new[] {"GetMetricDataV2"}, SelectReturnType = typeof(Amazon.Connect.Model.GetMetricDataV2Response))]
    [AWSCmdletOutput("Amazon.Connect.Model.MetricResultV2 or Amazon.Connect.Model.GetMetricDataV2Response",
        "This cmdlet returns a collection of Amazon.Connect.Model.MetricResultV2 objects.",
        "The service call response (type Amazon.Connect.Model.GetMetricDataV2Response) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCONNMetricDataV2Cmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The timestamp, in UNIX Epoch time format, at which to end the reporting interval for
        /// the retrieval of historical metrics data. The time must be later than the start time
        /// timestamp.</para><para>The time range between the start and end time must be less than 24 hours.</para>
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
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters to apply to returned metrics. You can filter on the following resources:</para><ul><li><para>Queues</para></li><li><para>Routing profiles</para></li><li><para>Agents</para></li><li><para>Channels</para></li><li><para>User hierarchy groups</para></li></ul><para>At least one filter must be passed from queues, routing profiles, agents, or user
        /// hierarchy groups.</para><para>To filter by phone number, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/create-historical-metrics-report.html">Create
        /// a historical metrics report</a> in the <i>Amazon Connect Administrator's Guide</i>.</para><para>Note the following limits:</para><ul><li><para><b>Filter keys</b>: A maximum of 5 filter keys are supported in a single request.
        /// Valid filter keys: <code>QUEUE</code> | <code>ROUTING_PROFILE</code> | <code>AGENT</code>
        /// | <code>CHANNEL</code> | <code>AGENT_HIERARCHY_LEVEL_ONE</code> | <code>AGENT_HIERARCHY_LEVEL_TWO</code>
        /// | <code>AGENT_HIERARCHY_LEVEL_THREE</code> | <code>AGENT_HIERARCHY_LEVEL_FOUR</code>
        /// | <code>AGENT_HIERARCHY_LEVEL_FIVE</code></para></li><li><para><b>Filter values</b>: A maximum of 100 filter values are supported in a single request.
        /// For example, a <code>GetMetricDataV2</code> request can filter by 50 queues, 35 agents,
        /// and 15 routing profiles for a total of 100 filter values. <code>VOICE</code>, <code>CHAT</code>,
        /// and <code>TASK</code> are valid <code>filterValue</code> for the <code>CHANNEL</code>
        /// filter key.</para></li></ul>
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
        [Alias("Filters")]
        public Amazon.Connect.Model.FilterV2[] Filter { get; set; }
        #endregion
        
        #region Parameter Grouping
        /// <summary>
        /// <para>
        /// <para>The grouping applied to the metrics that are returned. For example, when results are
        /// grouped by queue, the metrics returned are grouped by queue. The values that are returned
        /// apply to the metrics for each queue. They are not aggregated for all queues.</para><para>If no grouping is specified, a summary of all metrics is returned.</para><para>Valid grouping keys: <code>QUEUE</code> | <code>ROUTING_PROFILE</code> | <code>AGENT</code>
        /// | <code>CHANNEL</code> | <code>AGENT_HIERARCHY_LEVEL_ONE</code> | <code>AGENT_HIERARCHY_LEVEL_TWO</code>
        /// | <code>AGENT_HIERARCHY_LEVEL_THREE</code> | <code>AGENT_HIERARCHY_LEVEL_FOUR</code>
        /// | <code>AGENT_HIERARCHY_LEVEL_FIVE</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Groupings")]
        public System.String[] Grouping { get; set; }
        #endregion
        
        #region Parameter Metric
        /// <summary>
        /// <para>
        /// <para>The metrics to retrieve. Specify the name, groupings, and filters for each metric.
        /// The following historical metrics are available. For a description of each metric,
        /// see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/historical-metrics-definitions.html">Historical
        /// metrics definitions</a> in the <i>Amazon Connect Administrator's Guide</i>.</para><dl><dt>AGENT_ADHERENT_TIME</dt><dd><para>This metric is available only in Amazon Web Services Regions where <a href="https://docs.aws.amazon.com/connect/latest/adminguide/regions.html#optimization_region">Forecasting,
        /// capacity planning, and scheduling</a> is available.</para><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy
        /// </para></dd><dt>AGENT_NON_RESPONSE</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy
        /// </para></dd><dt>AGENT_OCCUPANCY</dt><dd><para>Unit: Percentage</para><para>Valid groupings and filters: Routing Profile, Agent, Agent Hierarchy </para></dd><dt>AGENT_SCHEDULE_ADHERENCE</dt><dd><para>This metric is available only in Amazon Web Services Regions where <a href="https://docs.aws.amazon.com/connect/latest/adminguide/regions.html#optimization_region">Forecasting,
        /// capacity planning, and scheduling</a> is available.</para><para>Unit: Percent</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para></dd><dt>AGENT_SCHEDULED_TIME</dt><dd><para>This metric is available only in Amazon Web Services Regions where <a href="https://docs.aws.amazon.com/connect/latest/adminguide/regions.html#optimization_region">Forecasting,
        /// capacity planning, and scheduling</a> is available.</para><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para></dd><dt>AVG_ABANDON_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para></dd><dt>AVG_AFTER_CONTACT_WORK_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para></dd><dt>AVG_AGENT_CONNECTING_TIME</dt><dd><para>Unit: Seconds</para><para>Valid metric filter key: <code>INITIATION_METHOD</code>. For now, this metric only
        /// supports the following as <code>INITIATION_METHOD</code>: <code>INBOUND</code> | <code>OUTBOUND</code>
        /// | <code>CALLBACK</code> | <code>API</code></para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para></dd><dt>AVG_HANDLE_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para></dd><dt>AVG_HOLD_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para></dd><dt>AVG_INTERACTION_AND_HOLD_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para></dd><dt>AVG_INTERACTION_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile</para></dd><dt>AVG_QUEUE_ANSWER_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile</para></dd><dt>CONTACTS_ABANDONED</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para></dd><dt>CONTACTS_CREATED</dt><dd><para>Unit: Count</para><para>Valid metric filter key: <code>INITIATION_METHOD</code></para><para>Valid groupings and filters: Queue, Channel, Routing Profile</para></dd><dt>CONTACTS_HANDLED</dt><dd><para>Unit: Count</para><para>Valid metric filter key: <code>INITIATION_METHOD</code>, <code>DISCONNECT_REASON</code></para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para></dd><dt>CONTACTS_HOLD_ABANDONS</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para></dd><dt>CONTACTS_QUEUED</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para></dd><dt>CONTACTS_TRANSFERRED_OUT</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para></dd><dt>CONTACTS_TRANSFERRED_OUT_BY_AGENT</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para></dd><dt>CONTACTS_TRANSFERRED_OUT_FROM_QUEUE</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para></dd><dt>MAX_QUEUED_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para></dd><dt>SERVICE_LEVEL</dt><dd><para>You can include up to 20 SERVICE_LEVEL metrics in a request.</para><para>Unit: Percent</para><para>Valid groupings and filters: Queue, Channel, Routing Profile</para><para>Threshold: For <code>ThresholdValue</code>, enter any whole number from 1 to 604800
        /// (inclusive), in seconds. For <code>Comparison</code>, you must enter <code>LT</code>
        /// (for "Less than"). </para></dd><dt>SUM_CONTACTS_ANSWERED_IN_X</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile</para></dd><dt>SUM_CONTACTS_ABANDONED_IN_X</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile</para></dd><dt>SUM_CONTACTS_DISCONNECTED </dt><dd><para>Valid metric filter key: <code>DISCONNECT_REASON</code></para><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile</para></dd><dt>SUM_RETRY_CALLBACK_ATTEMPTS</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile</para></dd></dl>
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
        [Alias("Metrics")]
        public Amazon.Connect.Model.MetricV2[] Metric { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the resource. This includes the <code>instanceId</code>
        /// an Amazon Connect instance.</para>
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
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The timestamp, in UNIX Epoch time format, at which to start the reporting interval
        /// for the retrieval of historical metrics data. The time must be before the end time
        /// timestamp. The time range between the start and end time must be less than 24 hours.
        /// The start time cannot be earlier than 14 days before the time of the request. Historical
        /// metrics are available for 14 days.</para>
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
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.GetMetricDataV2Response).
        /// Specifying the name of a property of type Amazon.Connect.Model.GetMetricDataV2Response will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MetricResults";
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
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.GetMetricDataV2Response, GetCONNMetricDataV2Cmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndTime = this.EndTime;
            #if MODULAR
            if (this.EndTime == null && ParameterWasBound(nameof(this.EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.Connect.Model.FilterV2>(this.Filter);
            }
            #if MODULAR
            if (this.Filter == null && ParameterWasBound(nameof(this.Filter)))
            {
                WriteWarning("You are passing $null as a value for parameter Filter which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Grouping != null)
            {
                context.Grouping = new List<System.String>(this.Grouping);
            }
            context.MaxResult = this.MaxResult;
            if (this.Metric != null)
            {
                context.Metric = new List<Amazon.Connect.Model.MetricV2>(this.Metric);
            }
            #if MODULAR
            if (this.Metric == null && ParameterWasBound(nameof(this.Metric)))
            {
                WriteWarning("You are passing $null as a value for parameter Metric which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Connect.Model.GetMetricDataV2Request();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.Grouping != null)
            {
                request.Groupings = cmdletContext.Grouping;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Metric != null)
            {
                request.Metrics = cmdletContext.Metric;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Connect.Model.GetMetricDataV2Response CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.GetMetricDataV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "GetMetricDataV2");
            try
            {
                #if DESKTOP
                return client.GetMetricDataV2(request);
                #elif CORECLR
                return client.GetMetricDataV2Async(request).GetAwaiter().GetResult();
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
            public List<Amazon.Connect.Model.FilterV2> Filter { get; set; }
            public List<System.String> Grouping { get; set; }
            public System.Int32? MaxResult { get; set; }
            public List<Amazon.Connect.Model.MetricV2> Metric { get; set; }
            public System.String NextToken { get; set; }
            public System.String ResourceArn { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.Connect.Model.GetMetricDataV2Response, GetCONNMetricDataV2Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MetricResults;
        }
        
    }
}
