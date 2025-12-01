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
using Amazon.Connect;
using Amazon.Connect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Gets metric data from the specified Amazon Connect instance. 
    /// 
    ///  
    /// <para><c>GetMetricDataV2</c> offers more features than <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_GetMetricData.html">GetMetricData</a>,
    /// the previous version of this API. It has new metrics, offers filtering at a metric
    /// level, and offers the ability to filter and group data by channels, queues, routing
    /// profiles, agents, and agent hierarchy levels. It can retrieve historical data for
    /// the last 3 months, at varying intervals. It does not support agent queues.
    /// </para><para>
    /// For a description of the historical metrics that are supported by <c>GetMetricDataV2</c>
    /// and <c>GetMetricData</c>, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html">Metrics
    /// definitions</a> in the <i>Amazon Connect Administrator Guide</i>.
    /// </para><note><para>
    /// When you make a successful API request, you can expect the following metric values
    /// in the response:
    /// </para><ol><li><para><b>Metric value is null</b>: The calculation cannot be performed due to divide by
    /// zero or insufficient data
    /// </para></li><li><para><b>Metric value is a number (including 0) of defined type</b>: The number provided
    /// is the calculation result
    /// </para></li><li><para><b>MetricResult list is empty</b>: The request cannot find any data in the system
    /// </para></li></ol><para>
    /// The following guidelines can help you work with the API:
    /// </para><ul><li><para>
    /// Each dimension in the metric response must contain a value
    /// </para></li><li><para>
    /// Each item in MetricResult must include all requested metrics
    /// </para></li><li><para>
    /// If the response is slow due to large result sets, try these approaches:
    /// </para><ul><li><para>
    /// Narrow the time range of your request
    /// </para></li><li><para>
    /// Add filters to reduce the amount of data returned
    /// </para></li></ul></li></ul></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CONNMetricDataV2")]
    [OutputType("Amazon.Connect.Model.MetricResultV2")]
    [AWSCmdlet("Calls the Amazon Connect Service GetMetricDataV2 API operation.", Operation = new[] {"GetMetricDataV2"}, SelectReturnType = typeof(Amazon.Connect.Model.GetMetricDataV2Response))]
    [AWSCmdletOutput("Amazon.Connect.Model.MetricResultV2 or Amazon.Connect.Model.GetMetricDataV2Response",
        "This cmdlet returns a collection of Amazon.Connect.Model.MetricResultV2 objects.",
        "The service call response (type Amazon.Connect.Model.GetMetricDataV2Response) can be returned by specifying '-Select *'."
    )]
    public partial class GetCONNMetricDataV2Cmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The timestamp, in UNIX Epoch time format, at which to end the reporting interval for
        /// the retrieval of historical metrics data. The time must be later than the start time
        /// timestamp. It cannot be later than the current timestamp.</para>
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
        /// <para>The filters to apply to returned metrics. You can filter on the following resources:</para><ul><li><para>Agents</para></li><li><para>Campaigns</para></li><li><para>Channels</para></li><li><para>Feature</para></li><li><para>Queues</para></li><li><para>Routing profiles</para></li><li><para>Routing step expression</para></li><li><para>User hierarchy groups</para></li></ul><para>At least one filter must be passed from queues, routing profiles, agents, or user
        /// hierarchy groups.</para><para>For metrics for outbound campaigns analytics, you can also use campaigns to satisfy
        /// at least one filter requirement.</para><para>To filter by phone number, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/create-historical-metrics-report.html">Create
        /// a historical metrics report</a> in the <i>Amazon Connect Administrator Guide</i>.</para><para>Note the following limits:</para><ul><li><para><b>Filter keys</b>: A maximum of 5 filter keys are supported in a single request.
        /// Valid filter keys: <c>AGENT</c> | <c>AGENT_HIERARCHY_LEVEL_FIVE</c> | <c>AGENT_HIERARCHY_LEVEL_FOUR</c>
        /// | <c>AGENT_ HIERARCHY_LEVEL_ONE</c> | <c>AGENT_HIERARCHY_LEVEL_THREE</c> | <c>AGENT_HIERARCHY_LEVEL_TWO</c>
        /// | <c> ANSWERING_MACHINE_DETECTION_STATUS</c> | <c>BOT_ALIAS</c> | <c>BOT_ID</c> |
        /// <c>BOT_INTENT_NAME</c> | <c>BOT_LOCALE</c> | <c>BOT_VERSION</c> | <c>CAMPAIGN</c>
        /// | <c>CAMPAIGN_DELIVERY_EVENT_TYPE</c> | <c> CAMPAIGN_EXCLUDED_EVENT_TYPE</c> | <c>CASE_STATUS</c>
        /// | <c>CASE_TEMPLATE_ARN</c> | <c>CHANNEL</c> | <c> contact/segmentAttributes/connect:Subtype</c>
        /// | <c>contact/segmentAttributes/connect:ValidationTestType</c> | <c> DISCONNECT_REASON</c>
        /// | <c>EVALUATION_FORM</c> | <c>EVALUATION_QUESTION</c> | <c>EVALUATION_SECTION</c>
        /// | <c>EVALUATION_SOURCE</c> | <c>EVALUATOR_ID</c> | <c>FEATURE</c> | <c>FLOW_ACTION_ID</c>
        /// | <c>FLOW_TYPE</c> | <c>FLOWS_MODULE_RESOURCE_ID</c> | <c>FLOWS_NEXT_RESOURCE_ID</c>
        /// | <c>FLOWS_NEXT_RESOURCE_QUEUE_ID</c> | <c>FLOWS_OUTCOME_TYPE</c> | <c>FLOWS_RESOURCE_ID</c>
        /// | <c>FORM_VERSION</c> | <c>INITIATING_FLOW</c> | <c>INITIATION_METHOD</c> | <c>INVOKING_RESOURCE_PUBLISHED_TIMESTAMP</c>
        /// | <c>INVOKING_RESOURCE_TYPE</c> | <c>PARENT_FLOWS_RESOURCE_ID</c> | <c>Q_CONNECT_ENABLED</c>
        /// | <c>QUEUE</c> | <c>RESOURCE_PUBLISHED_ TIMESTAMP</c> | <c>ROUTING_PROFILE</c> | <c>ROUTING_STEP_EXPRESSION</c>
        /// | <c>TEST_CASE</c> | <c>TEST_ CASE_EXECUTION_FAILURE_REASON</c> | <c>TEST_CASE_EXECUTION_RESULT</c>
        /// | <c>TEST_CASE_EXECUTION_STATE</c></para></li><li><para><b>Filter values</b>: A maximum of 100 filter values are supported in a single request.
        /// VOICE, CHAT, and TASK are valid <c>filterValue</c> for the CHANNEL filter key. They
        /// do not count towards limitation of 100 filter values. For example, a GetMetricDataV2
        /// request can filter by 50 queues, 35 agents, and 15 routing profiles for a total of
        /// 100 filter values, along with 3 channel filters. </para><para><c>contact_lens_conversational_analytics</c> is a valid filterValue for the <c>FEATURE</c>
        /// filter key. It is available only to contacts analyzed by Contact Lens conversational
        /// analytics.</para><para><c>connect:Chat</c>, <c>connect:SMS</c>, <c>connect:Telephony</c>, and <c>connect:WebRTC</c>
        /// are valid <c>filterValue</c> examples (not exhaustive) for the <c>contact/segmentAttributes/connect:Subtype
        /// filter</c> key.</para><para><c>ROUTING_STEP_EXPRESSION</c> is a valid filter key with a filter value up to 3000
        /// length. This filter is case and order sensitive. JSON string fields must be sorted
        /// in ascending order and JSON array order should be kept as is.</para><para><c>Q_CONNECT_ENABLED</c>. TRUE and FALSE are the only valid filterValues for the
        /// <c>Q_CONNECT_ENABLED</c> filter key. </para><ul><li><para>TRUE includes all contacts that had Connect AI Agents enabled as part of the flow.</para></li><li><para>FALSE includes all contacts that did not have Connect AI Agents enabled as part of
        /// the flow</para></li><li><para>EXPERIENCE_VALIDATION and FLOW_VALIDATION are the only valid filterValues for the
        /// contact/segmentAttributes/connect:ValidationTestType filter key</para></li></ul><para>This filter is available only for contact record-driven metrics. </para><para><a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_connect-outbound-campaigns_Campaign.html">Campaign</a>
        /// ARNs are valid <c>filterValues</c> for the <c>CAMPAIGN</c> filter key.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// apply to the metrics for each queue. They are not aggregated for all queues.</para><para>If no grouping is specified, a summary of all metrics is returned.</para><para>Valid grouping keys: <c>AGENT</c> | <c>AGENT_HIERARCHY_LEVEL_ONE</c> | <c>AGENT_HIERARCHY_LEVEL_TWO</c>
        /// | <c>AGENT_HIERARCHY_LEVEL_THREE</c> | <c>AGENT_HIERARCHY_LEVEL_FOUR</c> | <c>AGENT_HIERARCHY_LEVEL_FIVE</c>
        /// | <c>ANSWERING_MACHINE_DETECTION_STATUS</c> | <c>BOT_ID</c> | <c>BOT_ALIAS</c> | <c>BOT_VERSION</c>
        /// | <c>BOT_LOCALE</c> | <c>BOT_INTENT_NAME</c> | <c>CAMPAIGN</c> | <c>CAMPAIGN_DELIVERY_EVENT_TYPE</c>
        /// | <c>CAMPAIGN_EXCLUDED_EVENT_TYPE</c> | <c>CAMPAIGN_EXECUTION_TIMESTAMP</c> | <c>CASE_TEMPLATE_ARN</c>
        /// | <c>CASE_STATUS</c> | <c>CHANNEL</c> | <c>contact/segmentAttributes/connect:Subtype</c>
        /// | <c>DISCONNECT_REASON</c> | <c>EVALUATION_FORM</c> | <c>EVALUATION_SECTION</c> |
        /// <c>EVALUATION_QUESTION</c> | <c>EVALUATION_SOURCE</c> | <c>EVALUATOR_ID</c> | <c>FLOWS_RESOURCE_ID</c>
        /// | <c>FLOWS_MODULE_RESOURCE_ID</c> | <c>FLOW_ACTION_ID</c> | <c>FLOW_TYPE</c> | <c>FLOWS_OUTCOME_TYPE</c>
        /// | <c>FORM_VERSION</c> | <c>INITIATION_METHOD</c> | <c>INVOKING_RESOURCE_PUBLISHED_TIMESTAMP</c>
        /// | <c>INVOKING_RESOURCE_TYPE</c> | <c>PARENT_FLOWS_RESOURCE_ID</c> | <c>Q_CONNECT_ENABLED</c>
        /// | <c>QUEUE</c> | <c>RESOURCE_PUBLISHED_TIMESTAMP</c> | <c>ROUTING_PROFILE</c> | <c>ROUTING_STEP_EXPRESSION</c>
        /// | <c>TEST_CASE</c> | <c>TEST_CASE_EXECUTION_FAILURE_REASON</c> | <c>TEST_CASE_INVOCATION_METHOD</c></para><para>API, SCHEDULE, and EVENT are the only valid filterValues for TEST_CASE_INVOCATION_METHOD.</para><para>OBSERVE_EVENT, SEND_INSTRUCTION, ASSERT_DATA, and OVERRIDE_SYSTEM_BEHAVIOR are the
        /// only valid filterValues for TEST_CASE_EXECUTION_FAILURE_REASON</para><para>Type: Array of strings</para><para>Array Members: Maximum number of 4 items</para><para>Required: No</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Groupings")]
        public System.String[] Grouping { get; set; }
        #endregion
        
        #region Parameter Interval_IntervalPeriod
        /// <summary>
        /// <para>
        /// <para><c>IntervalPeriod</c>: An aggregated grouping applied to request metrics. Valid <c>IntervalPeriod</c>
        /// values are: <c>FIFTEEN_MIN</c> | <c>THIRTY_MIN</c> | <c>HOUR</c> | <c>DAY</c> | <c>WEEK</c>
        /// | <c>TOTAL</c>. </para><para>For example, if <c>IntervalPeriod</c> is selected <c>THIRTY_MIN</c>, <c>StartTime</c>
        /// and <c>EndTime</c> differs by 1 day, then Amazon Connect returns 48 results in the
        /// response. Each result is aggregated by the THIRTY_MIN period. By default Amazon Connect
        /// aggregates results based on the <c>TOTAL</c> interval period. </para><para>The following list describes restrictions on <c>StartTime</c> and <c>EndTime</c> based
        /// on what <c>IntervalPeriod</c> is requested. </para><ul><li><para><c>FIFTEEN_MIN</c>: The difference between <c>StartTime</c> and <c>EndTime</c> must
        /// be less than 3 days.</para></li><li><para><c>THIRTY_MIN</c>: The difference between <c>StartTime</c> and <c>EndTime</c> must
        /// be less than 3 days.</para></li><li><para><c>HOUR</c>: The difference between <c>StartTime</c> and <c>EndTime</c> must be less
        /// than 3 days.</para></li><li><para><c>DAY</c>: The difference between <c>StartTime</c> and <c>EndTime</c> must be less
        /// than 35 days.</para></li><li><para><c>WEEK</c>: The difference between <c>StartTime</c> and <c>EndTime</c> must be less
        /// than 35 days.</para></li><li><para><c>TOTAL</c>: The difference between <c>StartTime</c> and <c>EndTime</c> must be
        /// less than 35 days.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.IntervalPeriod")]
        public Amazon.Connect.IntervalPeriod Interval_IntervalPeriod { get; set; }
        #endregion
        
        #region Parameter Metric
        /// <summary>
        /// <para>
        /// <para>The metrics to retrieve. Specify the name or metricId, groupings, and filters for
        /// each metric. The following historical metrics are available. For a description of
        /// each metric, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html">Metrics
        /// definition</a> in the <i>Amazon Connect Administrator Guide</i>.</para><note><para>MetricId should be used to reference custom metrics or out of the box metrics as Arn.
        /// If using MetricId, the limit is 20 MetricId per request.</para></note><dl><dt>ABANDONMENT_RATE</dt><dd><para>Unit: Percent</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// Feature, contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#abandonment-rate">Abandonment
        /// rate</a></para></dd><dt>AGENT_ADHERENT_TIME</dt><dd><para>This metric is available only in Amazon Web Services Regions where <a href="https://docs.aws.amazon.com/connect/latest/adminguide/regions.html#optimization_region">Forecasting,
        /// capacity planning, and scheduling</a> is available.</para><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy
        /// </para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#adherent-time">Adherent
        /// time</a></para></dd><dt>AGENT_ANSWER_RATE</dt><dd><para>Unit: Percent</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#agent-answer-rate">Agent
        /// answer rate</a></para></dd><dt>AGENT_NON_ADHERENT_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#non-adherent-time">Non-adherent
        /// time</a></para></dd><dt>AGENT_NON_RESPONSE</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy
        /// </para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#agent-non-response">Agent
        /// non-response</a></para></dd><dt>AGENT_NON_RESPONSE_WITHOUT_CUSTOMER_ABANDONS</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para><para>Data for this metric is available starting from October 1, 2023 0:00:00 GMT.</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#agent-non-response-without-customer-abandons">Agent
        /// non-response without customer abandons</a></para></dd><dt>AGENT_OCCUPANCY</dt><dd><para>Unit: Percentage</para><para>Valid groupings and filters: Routing Profile, Agent, Agent Hierarchy </para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#occupancy">Occupancy</a></para></dd><dt>AGENT_SCHEDULE_ADHERENCE</dt><dd><para>This metric is available only in Amazon Web Services Regions where <a href="https://docs.aws.amazon.com/connect/latest/adminguide/regions.html#optimization_region">Forecasting,
        /// capacity planning, and scheduling</a> is available.</para><para>Unit: Percent</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#adherence">Adherence</a></para></dd><dt>AGENT_SCHEDULED_TIME</dt><dd><para>This metric is available only in Amazon Web Services Regions where <a href="https://docs.aws.amazon.com/connect/latest/adminguide/regions.html#optimization_region">Forecasting,
        /// capacity planning, and scheduling</a> is available.</para><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#scheduled-time">Scheduled
        /// time</a></para></dd><dt>AVG_ABANDON_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// Feature, contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>Valid metric filter key: <c>INITIATION_METHOD</c></para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-queue-abandon-time">Average
        /// queue abandon time</a></para></dd><dt>AVG_ACTIVE_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-active-time">Average
        /// active time</a></para></dd><dt>AVG_AFTER_CONTACT_WORK_TIME</dt><dd><para>Unit: Seconds</para><para>Valid metric filter key: <c>INITIATION_METHOD</c></para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// Feature, contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#after-contact-work-time">Average
        /// after contact work time</a></para><note><para>Feature is a valid filter but not a valid grouping.</para></note></dd><dt>AVG_AGENT_CONCURRENCY</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-agent-concurrency">Average
        /// agent concurrency</a></para></dd><dt>AVG_AGENT_CONNECTING_TIME</dt><dd><para>Unit: Seconds</para><para>Valid metric filter key: <c>INITIATION_METHOD</c>. For now, this metric only supports
        /// the following as <c>INITIATION_METHOD</c>: <c>INBOUND</c> | <c>OUTBOUND</c> | <c>CALLBACK</c>
        /// | <c>API</c></para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-agent-api-connecting-time">Average
        /// agent API connecting time</a></para><note><para>The <c>Negate</c> key in metric-level filters is not applicable for this metric.</para></note></dd><dt>AVG_AGENT_PAUSE_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-agent-pause-time">Average
        /// agent pause time</a></para></dd><dt>AVG_BOT_CONVERSATION_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Channel, contact/segmentAttributes/connect:Subtype, Bot
        /// ID, Bot alias, Bot version, Bot locale, Flows resource ID, Flows module resource ID,
        /// Flow type, Flow action ID, Invoking resource published timestamp, Initiation method,
        /// Invoking resource type, Parent flows resource ID</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/bot-metrics.html#average-bot-conversation-time">Average
        /// bot conversation time</a></para></dd><dt>AVG_BOT_CONVERSATION_TURNS</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Channel, contact/segmentAttributes/connect:Subtype, Bot
        /// ID, Bot alias, Bot version, Bot locale, Flows resource ID, Flows module resource ID,
        /// Flow type, Flow action ID, Invoking resource published timestamp, Initiation method,
        /// Invoking resource type, Parent flows resource ID</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/bot-metrics.html#average-bot-conversation-turns">Average
        /// bot conversation turns</a></para></dd><dt>AVG_CASE_RELATED_CONTACTS</dt><dd><para>Unit: Count</para><para>Required filter key: CASE_TEMPLATE_ARN</para><para>Valid groupings and filters: CASE_TEMPLATE_ARN, CASE_STATUS</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-contacts-per-case">Average
        /// contacts per case</a></para></dd><dt>AVG_CASE_RESOLUTION_TIME</dt><dd><para>Unit: Seconds</para><para>Required filter key: CASE_TEMPLATE_ARN</para><para>Valid groupings and filters: CASE_TEMPLATE_ARN, CASE_STATUS</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-case-resolution-time">Average
        /// case resolution time</a></para></dd><dt>AVG_CONTACT_DURATION</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// Feature, contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-contact-duration">Average
        /// contact duration</a></para><note><para>Feature is a valid filter but not a valid grouping.</para></note></dd><dt>AVG_CONTACT_FIRST_RESPONSE_TIME_AGENT</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Agent, Agent Hierarchy, Channel, contact/segmentAttributes/connect:Subtype,
        /// Disconnect Reason, Feature, RoutingStepExpression, Initiation method, Routing Profile,
        /// Queue, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#agent-average-contact-first-response-wait-time">Agent
        /// average contact first response wait time</a></para></dd><dt>AVG_CONVERSATION_CLOSE_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Agent, Agent Hierarchy, Channel, contact/segmentAttributes/connect:Subtype,
        /// Disconnect Reason, Feature, RoutingStepExpression, Initiation method, Routing Profile,
        /// Queue, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-conversation-close-time">Average
        /// conversation close time</a></para></dd><dt>AVG_CONVERSATION_DURATION</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// Feature, contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-conversation-duration">Average
        /// conversation duration</a></para></dd><dt>AVG_DIALS_PER_MINUTE</dt><dd><para>This metric is available only for outbound campaigns that use the agent assisted voice
        /// and automated voice delivery modes.</para><para>Unit: Count</para><para>Valid groupings and filters: Agent, Campaign, Queue, Routing Profile</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-dials-per-minute">Average
        /// dials per minute</a></para></dd><dt>AVG_EVALUATION_SCORE</dt><dd><para>Unit: Percent</para><para>Valid groupings and filters: Agent, Agent Hierarchy, Channel, Evaluation Form ID,
        /// Evaluation Section ID, Evaluation Question ID, Evaluation Source, Form Version, Queue,
        /// Routing Profile</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-evaluation-score">Average
        /// evaluation score</a></para></dd><dt>AVG_FIRST_RESPONSE_TIME_AGENT</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Agent, Agent Hierarchy, Channel, contact/segmentAttributes/connect:Subtype,
        /// Disconnect Reason, Feature, RoutingStepExpression, Initiation method, Routing Profile,
        /// Queue, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-agent-first-response-time">Average
        /// agent first response time</a></para></dd><dt>AVG_FLOW_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Channel, contact/segmentAttributes/connect:Subtype, Flow
        /// type, Flows module resource ID, Flows next resource ID, Flows next resource queue
        /// ID, Flows outcome type, Flows resource ID, Initiation method, Resource published timestamp</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-flow-time">Average
        /// flow time</a></para></dd><dt>AVG_GREETING_TIME_AGENT</dt><dd><para>This metric is available only for contacts analyzed by Contact Lens conversational
        /// analytics.</para><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-agent-greeting-time">Average
        /// agent greeting time</a></para></dd><dt>AVG_HANDLE_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// Feature, contact/segmentAttributes/connect:Subtype, RoutingStepExpression</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-handle-time">Average
        /// handle time</a></para><note><para>Feature is a valid filter but not a valid grouping.</para></note></dd><dt>ACTIVE_AI_AGENTS</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: AI Agent, AI Agent Name, AI Agent Type, AI Use Case,
        /// Channel, Queue, Routing Profile</para><para>UI name: Active AI Agents</para></dd><dt>AI_HANDOFF_RATE</dt><dd><para>Unit: Percent</para><para>Valid groupings and filters: AI Use Case, Channel, Queue, Routing Profile</para><para>UI name: Handoff Rate</para></dd><dt>AI_HANDOFFS</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: AI Use Case, Channel, Queue, Routing Profile</para><para>UI name: AI Handoff Count</para></dd><dt>AI_AGENT_INVOCATION_SUCCESS</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: AI Agent, AI Agent Name, AI Agent Name Version, AI Agent
        /// Type, AI Use Case, Channel, Queue, Routing Profile</para><para>UI name: AI Agent Invocation Success Count</para><note><para>AI Agent Name Version is not a valid filter but a valid grouping.</para></note></dd><dt>AI_AGENT_INVOCATION_SUCCESS_RATE</dt><dd><para>Unit: Percent</para><para>Valid groupings and filters: AI Agent, AI Agent Name, AI Agent Name Version, AI Agent
        /// Type, AI Use Case, Channel, Queue, Routing Profile</para><para>UI name: AI Agent Invocation Success Rate</para><note><para>AI Agent Name Version is not a valid filter but a valid grouping.</para></note></dd><dt>AI_AGENT_INVOCATIONS</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: AI Agent, AI Agent Name, AI Agent Type, AI Agent Name
        /// Version, AI Use Case, Channel, Queue, Routing Profile</para><para>UI name: AI Agent Invocation Count</para><note><para>AI Agent Name Version is not a valid filter but a valid grouping.</para></note></dd><dt>AI_RESPONSE_COMPLETION_RATE</dt><dd><para>Unit: Percent</para><para>Valid groupings and filters: AI Use Case, Channel, Queue, Routing Profile</para><para>UI name: AI Response Completion Rate</para></dd><dt>AI_INVOLVED_CONTACTS</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: AI Use Case, Channel, Queue, Routing Profile</para><para>UI name: AI Contacts</para></dd><dt>AI_PROMPT_INVOCATION_SUCCESS</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: AI Agent, AI Agent Name, AI Agent Name Version, AI Agent
        /// Type, AI Prompt, AI Prompt ID, AI Prompt Name, AI Prompt Type, AI Use Case, Channel,
        /// Queue, Routing Profile</para><para>UI name: AI Prompt Invocation Success Count</para><note><para>AI Agent Name Version is not a valid filter but a valid grouping.</para></note></dd><dt>AI_PROMPT_INVOCATION_SUCCESS_RATE</dt><dd><para>Unit: Percent</para><para>Valid groupings and filters: AI Agent, AI Agent Name, AI Agent Name Version, AI Agent
        /// Type, AI Prompt, AI Prompt ID, AI Prompt Name, AI Prompt Type, AI Use Case, Channel,
        /// Queue, Routing Profile</para><para>UI name: AI Prompt Invocation Success Rate</para><note><para>AI Agent Name Version is not a valid filter but a valid grouping.</para></note></dd><dt>AI_TOOL_INVOCATIONS</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: AI Agent, AI Agent Name, AI Agent Name Version, AI Agent
        /// Type, AI Tool ID, AI Tool Name, AI Tool Type, AI Use Case, Channel, Queue, Routing
        /// Profile</para><para>UI name: AI Tool Invocation Count</para><note><para>AI Agent Name Version is not a valid filter but a valid grouping.</para></note></dd><dt>AVG_AI_AGENT_CONVERSATION_TURNS</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: AI Agent, AI Agent Name, AI Agent Name Version, AI Agent
        /// Type, AI Use Case, Channel, Queue, Routing Profile </para><para>UI name: Average AI Agent Conversation Turns</para><note><para>AI Agent Name Version is not a valid filter but a valid grouping.</para></note></dd><dt>AVG_AI_CONVERSATION_TURNS</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: AI Use Case, Channel, Queue, Routing Profile</para><para>UI name: AI Conversation Turns</para></dd><dt>AVG_AI_PROMPT_INVOCATION_LATENCY</dt><dd><para>Unit: Milliseconds</para><para>Valid groupings and filters: AI Agent, AI Agent Name, AI Agent Name Version, AI Agent
        /// Type, AI Prompt, AI Prompt ID, AI Prompt Name, AI Prompt Type, AI Use Case, Channel,
        /// Queue, Routing Profile</para><para>UI name: Average AI Prompt Invocation Latency</para><note><para>AI Agent Name Version is not a valid filter but a valid grouping.</para></note></dd><dt>AVG_AI_TOOL_INVOCATION_LATENCY</dt><dd><para>Unit: Milliseconds</para><para>Valid groupings and filters: AI Agent, AI Agent Name, AI Agent Name Version, AI Agent
        /// Type, AI Tool ID, AI Tool Name, AI Tool Type, AI Use Case, Channel, Queue, Routing
        /// Profile</para><para>UI name: Average AI Tool Invocation Latency</para><note><para>AI Agent Name Version is not a valid filter but a valid grouping.</para></note></dd><dt>KNOWLEDGE_CONTENT_REFERENCES</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: AI Agent, AI Agent Name, AI Agent Type, AI Use Case,
        /// Channel, Knowledge Base Name, Queue, Routing Profile</para><para>UI name: KnowledgeBase Reference Count</para></dd><dt>PROACTIVE_INTENT_ENGAGEMENT_RATE</dt><dd><para>Unit: Percent</para><para>Valid groupings and filters: AI Use Case, Channel, Queue, Routing Profile</para><para>UI name: Proactive Intent Engagement Rate</para></dd><dt>PROACTIVE_INTENT_RESPONSE_RATE</dt><dd><para>Unit: Percent</para><para>Valid groupings and filters: AI Use Case, Channel, Queue, Routing Profile </para><para>UI name: Proactive Intent Response Rate</para></dd><dt>PROACTIVE_INTENTS_ANSWERED</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: AI Use Case, Channel, Queue, Routing Profile</para><para>UI name: Proactive Intents Answered</para></dd><dt>PROACTIVE_INTENTS_DETECTED</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: AI Use Case, Channel, Queue, Routing Profile</para><para>UI name: Proactive Intents Detected</para></dd><dt></dt><dd><para>Unit: </para><para>Valid groupings and filters: </para><para>UI name: </para></dd><dt></dt><dd><para>Unit: </para><para>Valid groupings and filters: </para><para>UI name: </para></dd><dt>PROACTIVE_INTENTS_ENGAGED</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: AI Use Case, Channel, Queue, Routing Profile</para><para>UI name: UI name:</para></dd><dt>AVG_HOLD_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// Feature, contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-customer-hold-time">Average
        /// customer hold time</a></para><note><para>Feature is a valid filter but not a valid grouping.</para></note></dd><dt>AVG_HOLD_TIME_ALL_CONTACTS</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-customer-hold-time-all-contacts">Average
        /// customer hold time all contacts</a></para></dd><dt>AVG_HOLDS</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// Feature, contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-holds">Average
        /// holds</a></para><note><para>Feature is a valid filter but not a valid grouping.</para></note></dd><dt>AVG_INTERACTION_AND_HOLD_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-agent-interaction-and-customer-hold-time">Average
        /// agent interaction and customer hold time</a></para></dd><dt>AVG_INTERACTION_TIME</dt><dd><para>Unit: Seconds</para><para>Valid metric filter key: <c>INITIATION_METHOD</c></para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Feature, contact/segmentAttributes/connect:Subtype,
        /// Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-agent-interaction-time">Average
        /// agent interaction time</a></para><note><para>Feature is a valid filter but not a valid grouping.</para></note></dd><dt>AVG_INTERRUPTIONS_AGENT</dt><dd><para>This metric is available only for contacts analyzed by Contact Lens conversational
        /// analytics.</para><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-agent-interruptions">Average
        /// agent interruptions</a></para></dd><dt>AVG_INTERRUPTION_TIME_AGENT</dt><dd><para>This metric is available only for contacts analyzed by Contact Lens conversational
        /// analytics.</para><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-agent-interruption-time">Average
        /// agent interruption time</a></para></dd><dt>AVG_MESSAGE_LENGTH_AGENT</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Agent, Agent Hierarchy, Channel, contact/segmentAttributes/connect:Subtype,
        /// Disconnect Reason, Feature, RoutingStepExpression, Initiation method, Routing Profile,
        /// Queue, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-agent-message-length">Average
        /// agent message length</a></para></dd><dt>AVG_MESSAGE_LENGTH_CUSTOMER</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Agent, Agent Hierarchy, Channel, contact/segmentAttributes/connect:Subtype,
        /// Disconnect Reason, Feature, RoutingStepExpression, Initiation method, Routing Profile,
        /// Queue, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-customer-message-length">Average
        /// customer message length</a></para></dd><dt>AVG_MESSAGES</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Agent, Agent Hierarchy, Channel, contact/segmentAttributes/connect:Subtype,
        /// Disconnect Reason, Feature, RoutingStepExpression, Initiation method, Routing Profile,
        /// Queue, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-messages">Average
        /// messages</a></para></dd><dt>AVG_MESSAGES_AGENT</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Agent, Agent Hierarchy, Channel, contact/segmentAttributes/connect:Subtype,
        /// Disconnect Reason, Feature, RoutingStepExpression, Initiation method, Routing Profile,
        /// Queue, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-agent-messages">Average
        /// agent messages</a></para></dd><dt>AVG_MESSAGES_BOT</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Agent, Agent Hierarchy, Channel, contact/segmentAttributes/connect:Subtype,
        /// Disconnect Reason, Feature, RoutingStepExpression, Initiation method, Routing Profile,
        /// Queue, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-bot-messages">Average
        /// bot messages</a></para></dd><dt>AVG_MESSAGES_CUSTOMER</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Agent, Agent Hierarchy, Channel, contact/segmentAttributes/connect:Subtype,
        /// Disconnect Reason, Feature, RoutingStepExpression, Initiation method, Routing Profile,
        /// Queue, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-customer-messages">Average
        /// customer messages</a></para></dd><dt>AVG_NON_TALK_TIME</dt><dd><para>This metric is available only for contacts analyzed by Contact Lens conversational
        /// analytics.</para><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-non-talk-time">Average
        /// non-talk time</a></para></dd><dt>AVG_QUEUE_ANSWER_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Feature, contact/segmentAttributes/connect:Subtype,
        /// Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-queue-answer-time">Average
        /// queue answer time</a></para><para>Valid metric level filters: <c>INITIATION_METHOD</c>, <c>FEATURE</c>, <c>DISCONNECT_REASON</c></para><note><para>Feature is a valid filter but not a valid grouping.</para></note></dd><dt>AVG_QUEUE_ANSWER_TIME_CUSTOMER_FIRST_CALLBACK</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Feature, contact/segmentAttributes/connect:Subtype,
        /// Q in Connect, Agent Hierarchy</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-queue-answer-time-customer-first-callback">Avg.
        /// queue answer time - customer first callback</a></para></dd><dt>AVG_RESPONSE_TIME_AGENT</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Agent, Agent Hierarchy, Channel, contact/segmentAttributes/connect:Subtype,
        /// Disconnect Reason, Feature, RoutingStepExpression, Initiation method, Routing Profile,
        /// Queue, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-response-time-agent">Average
        /// agent response time</a></para></dd><dt>AVG_RESPONSE_TIME_CUSTOMER</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Agent, Agent Hierarchy, Channel, contact/segmentAttributes/connect:Subtype,
        /// Disconnect Reason, Feature, RoutingStepExpression, Initiation method, Routing Profile,
        /// Queue, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-customer-time-agent">Average
        /// customer response time</a></para></dd><dt>AVG_RESOLUTION_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, contact/segmentAttributes/connect:Subtype,
        /// Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-resolution-time">Average
        /// resolution time</a></para></dd><dt>AVG_TALK_TIME</dt><dd><para>This metric is available only for contacts analyzed by Contact Lens conversational
        /// analytics.</para><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-talk-time">Average
        /// talk time</a></para></dd><dt>AVG_TALK_TIME_AGENT</dt><dd><para>This metric is available only for contacts analyzed by Contact Lens conversational
        /// analytics.</para><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-agent-talk-time">Average
        /// agent talk time</a></para></dd><dt>AVG_TALK_TIME_CUSTOMER</dt><dd><para>This metric is available only for contacts analyzed by Contact Lens conversational
        /// analytics.</para><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-customer-talk-time">Average
        /// customer talk time</a></para></dd><dt>AVG_WAIT_TIME_AFTER_CUSTOMER_CONNECTION</dt><dd><para>This metric is available only for outbound campaigns that use the agent assisted voice
        /// and automated voice delivery modes.</para><para>Unit: Seconds</para><para>Valid groupings and filters: Campaign</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-wait-time-after-customer-connection">Average
        /// wait time after customer connection</a></para></dd><dt>AVG_WAIT_TIME_AFTER_CUSTOMER_FIRST_CALLBACK_CONNECTION</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Feature, contact/segmentAttributes/connect:Subtype,
        /// Q in Connect, Agent Hierarchy</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-wait-time-after-customer-connection-customer-first-callback">Avg.
        /// wait time after customer connection - customer first callback</a></para></dd><dt>AVG_WEIGHTED_EVALUATION_SCORE</dt><dd><para>Unit: Percent</para><para>Valid groupings and filters: Agent, Agent Hierarchy, Channel, Evaluation Form Id,
        /// Evaluation Section ID, Evaluation Question ID, Evaluation Source, Form Version, Queue,
        /// Routing Profile</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#average-weighted-evaluation-score">Average
        /// weighted evaluation score</a></para></dd><dt>BOT_CONVERSATIONS_COMPLETED</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Channel, contact/segmentAttributes/connect:Subtype, Bot
        /// ID, Bot alias, Bot version, Bot locale, Flows resource ID, Flows module resource ID,
        /// Flow type, Flow action ID, Invoking resource published timestamp, Initiation method,
        /// Invoking resource type, Parent flows resource ID</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/bot-metrics.html#bot-conversations-completed">Bot
        /// conversations completed</a></para></dd><dt>BOT_INTENTS_COMPLETED</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Channel, contact/segmentAttributes/connect:Subtype, Bot
        /// ID, Bot alias, Bot version, Bot locale, Bot intent name, Flows resource ID, Flows
        /// module resource ID, Flow type, Flow action ID, Invoking resource published timestamp,
        /// Initiation method, Invoking resource type, Parent flows resource ID</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/bot-metrics.html#bot-intents-completed">Bot
        /// intents completed</a></para></dd><dt>CAMPAIGN_CONTACTS_ABANDONED_AFTER_X</dt><dd><para>This metric is available only for outbound campaigns using the agent assisted voice
        /// and automated voice delivery modes.</para><para>Unit: Count</para><para>Valid groupings and filters: Agent, Campaign</para><para>Threshold: For <c>ThresholdValue</c>, enter any whole number from 1 to 604800 (inclusive),
        /// in seconds. For <c>Comparison</c>, you must enter <c>GT</c> (for <i>Greater than</i>).</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#campaign-contacts-abandoned-after-x">Campaign
        /// contacts abandoned after X</a></para></dd><dt>CAMPAIGN_CONTACTS_ABANDONED_AFTER_X_RATE</dt><dd><para>This metric is available only for outbound campaigns using the agent assisted voice
        /// and automated voice delivery modes.</para><para>Unit: Percent</para><para>Valid groupings and filters: Agent, Campaign</para><para>Threshold: For <c>ThresholdValue</c>, enter any whole number from 1 to 604800 (inclusive),
        /// in seconds. For <c>Comparison</c>, you must enter <c>GT</c> (for <i>Greater than</i>).</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#campaign-contacts-abandoned-after-x-rate">Campaign
        /// contacts abandoned after X rate</a></para></dd><dt>CAMPAIGN_INTERACTIONS</dt><dd><para>This metric is available only for outbound campaigns using the email delivery mode.
        /// </para><para>Unit: Count</para><para>Valid metric filter key: CAMPAIGN_INTERACTION_EVENT_TYPE</para><para>Valid groupings and filters: Campaign</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#campaign-interactions">Campaign
        /// interactions</a></para></dd><dt>CAMPAIGN_PROGRESS_RATE</dt><dd><para>This metric is only available for outbound campaigns initiated using a customer segment.
        /// It is not available for event triggered campaigns.</para><para>Unit: Percent</para><para>Valid groupings and filters: Campaign, Campaign Execution Timestamp</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#campaign-progress-rate">Campaign
        /// progress rate</a></para></dd><dt>CAMPAIGN_SEND_ATTEMPTS</dt><dd><para>This metric is available only for outbound campaigns.</para><para>Unit: Count</para><para>Valid groupings and filters: Campaign, Channel, contact/segmentAttributes/connect:Subtype
        /// </para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#campaign-send-attempts">Campaign
        /// send attempts</a></para></dd><dt>CAMPAIGN_SEND_EXCLUSIONS</dt><dd><para>This metric is available only for outbound campaigns.</para><para>Valid metric filter key: CAMPAIGN_EXCLUDED_EVENT_TYPE</para><para>Unit: Count</para><para>Valid groupings and filters: Campaign, Campaign Excluded Event Type, Campaign Execution
        /// Timestamp</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#campaign-send-exclusions">Campaign
        /// send exclusions</a></para></dd><dt>CASES_CREATED</dt><dd><para>Unit: Count</para><para>Required filter key: CASE_TEMPLATE_ARN</para><para>Valid groupings and filters: CASE_TEMPLATE_ARN, CASE_STATUS</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#cases-created">Cases
        /// created</a></para></dd><dt>CONTACTS_CREATED</dt><dd><para>Unit: Count</para><para>Valid metric filter key: <c>INITIATION_METHOD</c></para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Feature, contact/segmentAttributes/connect:Subtype,
        /// Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#contacts-created">Contacts
        /// created</a></para><note><para>Feature is a valid filter but not a valid grouping.</para></note></dd><dt>CONTACTS_HANDLED</dt><dd><para>Unit: Count</para><para>Valid metric filter key: <c>INITIATION_METHOD</c>, <c>DISCONNECT_REASON</c></para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// Feature, contact/segmentAttributes/connect:Subtype, RoutingStepExpression, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#contacts-handled">Contacts
        /// handled</a></para><note><para>Feature is a valid filter but not a valid grouping.</para></note></dd><dt>CONTACTS_HANDLED_BY_CONNECTED_TO_AGENT</dt><dd><para>Unit: Count</para><para>Valid metric filter key: <c>INITIATION_METHOD</c></para><para>Valid groupings and filters: Queue, Channel, Agent, Agent Hierarchy, contact/segmentAttributes/connect:Subtype,
        /// Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#contacts-handled-by-connected-to-agent-timestamp">Contacts
        /// handled (connected to agent timestamp)</a></para></dd><dt>CONTACTS_HOLD_ABANDONS</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#contacts-hold-disconnect">Contacts
        /// hold disconnect</a></para></dd><dt>CONTACTS_ON_HOLD_AGENT_DISCONNECT</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#contacts-hold-agent-disconnect">Contacts
        /// hold agent disconnect</a></para></dd><dt>CONTACTS_ON_HOLD_CUSTOMER_DISCONNECT</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#contacts-hold-customer-disconnect">Contacts
        /// hold customer disconnect</a></para></dd><dt>CONTACTS_PUT_ON_HOLD</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#contacts-put-on-hold">Contacts
        /// put on hold</a></para></dd><dt>CONTACTS_TRANSFERRED_OUT_EXTERNAL</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#contacts-transferred-out-external">Contacts
        /// transferred out external</a></para></dd><dt>CONTACTS_TRANSFERRED_OUT_INTERNAL</dt><dd><para>Unit: Percent</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#contacts-transferred-out-internal">Contacts
        /// transferred out internal</a></para></dd><dt>CONTACTS_QUEUED</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#contacts-queued">Contacts
        /// queued</a></para></dd><dt>CONTACTS_QUEUED_BY_ENQUEUE</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Agent, Agent Hierarchy, contact/segmentAttributes/connect:Subtype</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#contacts-queued-by-enqueue">Contacts
        /// queued (enqueue timestamp)</a></para></dd><dt>CONTACTS_REMOVED_FROM_QUEUE_IN_X</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Q in Connect</para><para>Threshold: For <c>ThresholdValue</c>, enter any whole number from 1 to 604800 (inclusive),
        /// in seconds. For <c>Comparison</c>, you can use <c>LT</c> (for "Less than") or <c>LTE</c>
        /// (for "Less than equal").</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#contacts-removed-from-queue">Contacts
        /// removed from queue in X seconds</a></para></dd><dt>CONTACTS_RESOLVED_IN_X</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, contact/segmentAttributes/connect:Subtype,
        /// Q in Connect</para><para>Threshold: For <c>ThresholdValue</c>, enter any whole number from 1 to 604800 (inclusive),
        /// in seconds. For <c>Comparison</c>, you can use <c>LT</c> (for "Less than") or <c>LTE</c>
        /// (for "Less than equal").</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#contacts-resolved">Contacts
        /// resolved in X</a></para></dd><dt>CONTACTS_TRANSFERRED_OUT</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// Feature, contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#contacts-transferred-out">Contacts
        /// transferred out</a></para><note><para>Feature is a valid filter but not a valid grouping.</para></note></dd><dt>CONTACTS_TRANSFERRED_OUT_BY_AGENT</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#contacts-transferred-out-by-agent">Contacts
        /// transferred out by agent</a></para></dd><dt>CONTACTS_TRANSFERRED_OUT_FROM_QUEUE</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#contacts-transferred-out-queue">Contacts
        /// transferred out queue</a></para></dd><dt>CURRENT_CASES</dt><dd><para>Unit: Count</para><para>Required filter key: CASE_TEMPLATE_ARN</para><para>Valid groupings and filters: CASE_TEMPLATE_ARN, CASE_STATUS</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#current-cases">Current
        /// cases</a></para></dd><dt>CONVERSATIONS_ABANDONED</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Agent, Agent Hierarchy, Channel, contact/segmentAttributes/connect:Subtype,
        /// Disconnect Reason, Feature, RoutingStepExpression, Initiation method, Routing Profile,
        /// Queue, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#conversations-abandoned">Conversations
        /// abandoned</a></para></dd><dt>DELIVERY_ATTEMPTS</dt><dd><para>This metric is available only for outbound campaigns.</para><para>Unit: Count</para><para>Valid metric filter key: <c>ANSWERING_MACHINE_DETECTION_STATUS</c>, <c>CAMPAIGN_DELIVERY_EVENT_TYPE</c>,
        /// <c>DISCONNECT_REASON</c></para><para>Valid groupings and filters: Agent, Answering Machine Detection Status, Campaign,
        /// Campaign Delivery EventType, Channel, contact/segmentAttributes/connect:Subtype, Disconnect
        /// Reason, Queue, Routing Profile</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#delivery-attempts">Delivery
        /// attempts</a></para><note><para>Campaign Delivery EventType filter and grouping are only available for SMS and Email
        /// campaign delivery modes. Agent, Queue, Routing Profile, Answering Machine Detection
        /// Status and Disconnect Reason are only available for agent assisted voice and automated
        /// voice delivery modes. </para></note></dd><dt>DELIVERY_ATTEMPT_DISPOSITION_RATE</dt><dd><para>This metric is available only for outbound campaigns. Dispositions for the agent assisted
        /// voice and automated voice delivery modes are only available with answering machine
        /// detection enabled.</para><para>Unit: Percent</para><para>Valid metric filter key: <c>ANSWERING_MACHINE_DETECTION_STATUS</c>, <c>CAMPAIGN_DELIVERY_EVENT_TYPE</c>,
        /// <c>DISCONNECT_REASON</c></para><para>Valid groupings and filters: Agent, Answering Machine Detection Status, Campaign,
        /// Channel, contact/segmentAttributes/connect:Subtype, Disconnect Reason, Queue, Routing
        /// Profile</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#delivery-attempt-disposition-rate">Delivery
        /// attempt disposition rate</a></para><note><para>Campaign Delivery Event Type filter and grouping are only available for SMS and Email
        /// campaign delivery modes. Agent, Queue, Routing Profile, Answering Machine Detection
        /// Status and Disconnect Reason are only available for agent assisted voice and automated
        /// voice delivery modes. </para></note></dd><dt>EVALUATIONS_PERFORMED</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Agent, Agent Hierarchy, Channel, Evaluation Form ID,
        /// Evaluation Source, Form Version, Queue, Routing Profile</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#evaluations-performed">Evaluations
        /// performed</a></para></dd><dt>FLOWS_OUTCOME</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Channel, contact/segmentAttributes/connect:Subtype, Flow
        /// type, Flows module resource ID, Flows next resource ID, Flows next resource queue
        /// ID, Flows outcome type, Flows resource ID, Initiation method, Resource published timestamp</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#flows-outcome">Flows
        /// outcome</a></para></dd><dt>FLOWS_STARTED</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Channel, contact/segmentAttributes/connect:Subtype, Flow
        /// type, Flows module resource ID, Flows resource ID, Initiation method, Resource published
        /// timestamp</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#flows-started">Flows
        /// started</a></para></dd><dt>HUMAN_ANSWERED_CALLS</dt><dd><para>This metric is available only for outbound campaigns. Dispositions for the agent assisted
        /// voice and automated voice delivery modes are only available with answering machine
        /// detection enabled. </para><para>Unit: Count</para><para>Valid groupings and filters: Agent, Campaign</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#human-answered">Human
        /// answered</a></para></dd><dt>MAX_FLOW_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Channel, contact/segmentAttributes/connect:Subtype, Flow
        /// type, Flows module resource ID, Flows next resource ID, Flows next resource queue
        /// ID, Flows outcome type, Flows resource ID, Initiation method, Resource published timestamp</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#maximum-flow-time">Maximum
        /// flow time</a></para></dd><dt>MAX_QUEUED_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#maximum-queued-time">Maximum
        /// queued time</a></para></dd><dt>MIN_FLOW_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Channel, contact/segmentAttributes/connect:Subtype, Flow
        /// type, Flows module resource ID, Flows next resource ID, Flows next resource queue
        /// ID, Flows outcome type, Flows resource ID, Initiation method, Resource published timestamp</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#minimum-flow-time">Minimum
        /// flow time</a></para></dd><dt>PERCENT_AUTOMATIC_FAILS</dt><dd><para>Unit: Percent</para><para>Valid groupings and filters: Agent, Agent Hierarchy, Channel, Evaluation Form ID,
        /// Evaluation Source, Form Version, Queue, Routing Profile</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#automatic-fails-percent">Automatic
        /// fails percent</a></para></dd><dt>PERCENT_BOT_CONVERSATIONS_OUTCOME</dt><dd><para>Unit: Percent</para><para>Valid groupings and filters: Channel, contact/segmentAttributes/connect:Subtype, Bot
        /// ID, Bot alias, Bot version, Bot locale, Flows resource ID, Flows module resource ID,
        /// Flow type, Flow action ID, Invoking resource published timestamp, Initiation method,
        /// Invoking resource type, Parent flows resource ID</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/bot-metrics.html#percent-bot-conversations-outcome">Percent
        /// bot conversations outcome</a></para></dd><dt>PERCENT_BOT_INTENTS_OUTCOME</dt><dd><para>Unit: Percent</para><para>Valid groupings and filters: Channel, contact/segmentAttributes/connect:Subtype, Bot
        /// ID, Bot alias, Bot version, Bot locale, Bot intent name, Flows resource ID, Flows
        /// module resource ID, Flow type, Flow action ID, Invoking resource published timestamp,
        /// Initiation method, Invoking resource type, Parent flows resource ID</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/bot-metrics.html#percent-bot-intents-outcome">Percent
        /// bot intents outcome</a></para></dd><dt>PERCENT_CASES_FIRST_CONTACT_RESOLVED</dt><dd><para>Unit: Percent</para><para>Required filter key: CASE_TEMPLATE_ARN</para><para>Valid groupings and filters: CASE_TEMPLATE_ARN, CASE_STATUS</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#cases-resolved-on-first-contact">Cases
        /// resolved on first contact</a></para></dd><dt>PERCENT_CONTACTS_STEP_EXPIRED</dt><dd><para>Unit: Percent</para><para>Valid groupings and filters: Queue, RoutingStepExpression</para><para>UI name: This metric is available in Real-time Metrics UI but not on the Historical
        /// Metrics UI.</para></dd><dt>PERCENT_CONTACTS_STEP_JOINED</dt><dd><para>Unit: Percent</para><para>Valid groupings and filters: Queue, RoutingStepExpression</para><para>UI name: This metric is available in Real-time Metrics UI but not on the Historical
        /// Metrics UI.</para></dd><dt>PERCENT_FLOWS_OUTCOME</dt><dd><para>Unit: Percent</para><para>Valid metric filter key: <c>FLOWS_OUTCOME_TYPE</c></para><para>Valid groupings and filters: Channel, contact/segmentAttributes/connect:Subtype, Flow
        /// type, Flows module resource ID, Flows next resource ID, Flows next resource queue
        /// ID, Flows outcome type, Flows resource ID, Initiation method, Resource published timestamp</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#flows-outcome-percentage">Flows
        /// outcome percentage</a>.</para><note><para>The <c>FLOWS_OUTCOME_TYPE</c> is not a valid grouping.</para></note></dd><dt>PERCENT_NON_TALK_TIME</dt><dd><para>This metric is available only for contacts analyzed by Contact Lens conversational
        /// analytics.</para><para>Unit: Percentage</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#non-talk-time-percent">Non-talk
        /// time percent</a></para></dd><dt>PERCENT_TALK_TIME</dt><dd><para>This metric is available only for contacts analyzed by Contact Lens conversational
        /// analytics.</para><para>Unit: Percentage</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#talk-time-percent">Talk
        /// time percent</a></para></dd><dt>PERCENT_TALK_TIME_AGENT</dt><dd><para>This metric is available only for contacts analyzed by Contact Lens conversational
        /// analytics.</para><para>Unit: Percentage</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#agent-talk-time-percent">Agent
        /// talk time percent</a></para></dd><dt>PERCENT_TALK_TIME_CUSTOMER</dt><dd><para>This metric is available only for contacts analyzed by Contact Lens conversational
        /// analytics.</para><para>Unit: Percentage</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#customer-talk-time-percent">Customer
        /// talk time percent</a></para></dd><dt>RECIPIENTS_ATTEMPTED</dt><dd><para>This metric is only available for outbound campaigns initiated using a customer segment.
        /// It is not available for event triggered campaigns.</para><para>Unit: Count</para><para>Valid groupings and filters: Campaign, Campaign Execution Timestamp</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#recipients-attempted">Recipients
        /// attempted</a></para></dd><dt>RECIPIENTS_INTERACTED</dt><dd><para>This metric is only available for outbound campaigns initiated using a customer segment.
        /// It is not available for event triggered campaigns.</para><para>Valid metric filter key: CAMPAIGN_INTERACTION_EVENT_TYPE</para><para>Unit: Count</para><para>Valid groupings and filters: Campaign, Channel, contact/segmentAttributes/connect:Subtype,
        /// Campaign Execution Timestamp</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#recipients-interacted">Recipients
        /// interacted</a></para></dd><dt>RECIPIENTS_TARGETED</dt><dd><para>This metric is only available for outbound campaigns initiated using a customer segment.
        /// It is not available for event triggered campaigns.</para><para>Unit: Count</para><para>Valid groupings and filters: Campaign, Campaign Execution Timestamp</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#recipients-targeted">Recipients
        /// targeted</a></para></dd><dt>REOPENED_CASE_ACTIONS</dt><dd><para>Unit: Count</para><para>Required filter key: CASE_TEMPLATE_ARN</para><para>Valid groupings and filters: CASE_TEMPLATE_ARN, CASE_STATUS</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#cases-reopened">Cases
        /// reopened</a></para></dd><dt>RESOLVED_CASE_ACTIONS</dt><dd><para>Unit: Count</para><para>Required filter key: CASE_TEMPLATE_ARN</para><para>Valid groupings and filters: CASE_TEMPLATE_ARN, CASE_STATUS</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#cases-resolved">Cases
        /// resolved</a></para></dd><dt>SERVICE_LEVEL</dt><dd><para>You can include up to 20 SERVICE_LEVEL metrics in a request.</para><para>Unit: Percent</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Q in Connect</para><para>Threshold: For <c>ThresholdValue</c>, enter any whole number from 1 to 604800 (inclusive),
        /// in seconds. For <c>Comparison</c>, you can use <c>LT</c> (for "Less than") or <c>LTE</c>
        /// (for "Less than equal").</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#service-level">Service
        /// level X</a></para></dd><dt>STEP_CONTACTS_QUEUED</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, RoutingStepExpression</para><para>UI name: This metric is available in Real-time Metrics UI but not on the Historical
        /// Metrics UI.</para></dd><dt>SUM_AFTER_CONTACT_WORK_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#after-contact-work-time">After
        /// contact work time</a></para></dd><dt>SUM_CONNECTING_TIME_AGENT</dt><dd><para>Unit: Seconds</para><para>Valid metric filter key: <c>INITIATION_METHOD</c>. This metric only supports the following
        /// filter keys as <c>INITIATION_METHOD</c>: <c>INBOUND</c> | <c>OUTBOUND</c> | <c>CALLBACK</c>
        /// | <c>API</c> | <c>CALLBACK_CUSTOMER_FIRST_DIALED</c></para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#agent-api-connecting-time">Agent
        /// API connecting time</a></para><note><para>The <c>Negate</c> key in metric-level filters is not applicable for this metric.</para></note></dd><dt>CONTACTS_ABANDONED</dt><dd><para>Unit: Count</para><para>Metric filter: </para><ul><li><para>Valid values: <c>API</c>| <c>INCOMING</c> | <c>OUTBOUND</c> | <c>TRANSFER</c> | <c>CALLBACK</c>
        /// | <c>QUEUE_TRANSFER</c>| <c>Disconnect</c> | <c>CALLBACK_CUSTOMER_FIRST_DIALED</c></para></li></ul><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// contact/segmentAttributes/connect:Subtype, RoutingStepExpression, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#contacts-abandoned">Contact
        /// abandoned</a></para></dd><dt>SUM_CONTACTS_ABANDONED_IN_X</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, contact/segmentAttributes/connect:Subtype,
        /// Q in Connect</para><para>Threshold: For <c>ThresholdValue</c>, enter any whole number from 1 to 604800 (inclusive),
        /// in seconds. For <c>Comparison</c>, you can use <c>LT</c> (for "Less than") or <c>LTE</c>
        /// (for "Less than equal").</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#contacts-abandoned-in-x-seconds">Contacts
        /// abandoned in X seconds</a></para></dd><dt>SUM_CONTACTS_ANSWERED_IN_X</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, contact/segmentAttributes/connect:Subtype,
        /// Q in Connect</para><para>Threshold: For <c>ThresholdValue</c>, enter any whole number from 1 to 604800 (inclusive),
        /// in seconds. For <c>Comparison</c>, you can use <c>LT</c> (for "Less than") or <c>LTE</c>
        /// (for "Less than equal").</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#contacts-answered-in-x-seconds">Contacts
        /// answered in X seconds</a></para></dd><dt>SUM_CONTACT_FLOW_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#contact-flow-time">Contact
        /// flow time</a></para></dd><dt>SUM_CONTACT_TIME_AGENT</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Routing Profile, Agent, Agent Hierarchy</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#agent-on-contact-time">Agent
        /// on contact time</a></para></dd><dt>SUM_CONTACTS_DISCONNECTED </dt><dd><para>Valid metric filter key: <c>DISCONNECT_REASON</c></para><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// contact/segmentAttributes/connect:Subtype, Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#contact-disconnected">Contact
        /// disconnected</a></para></dd><dt>SUM_ERROR_STATUS_TIME_AGENT</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Routing Profile, Agent, Agent Hierarchy</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#error-status-time">Error
        /// status time</a></para></dd><dt>SUM_HANDLE_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#contact-handle-time">Contact
        /// handle time</a></para></dd><dt>SUM_HOLD_TIME</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#customer-hold-time">Customer
        /// hold time</a></para></dd><dt>SUM_IDLE_TIME_AGENT</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Routing Profile, Agent, Agent Hierarchy</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#agent-idle-time">Agent
        /// idle time</a></para></dd><dt>SUM_INTERACTION_AND_HOLD_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy,
        /// Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#agent-interaction-and-hold-time">Agent
        /// interaction and hold time</a></para></dd><dt>SUM_INTERACTION_TIME</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, Agent, Agent Hierarchy</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#agent-interaction-time">Agent
        /// interaction time</a></para></dd><dt>SUM_NON_PRODUCTIVE_TIME_AGENT</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Routing Profile, Agent, Agent Hierarchy</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#agent-non-productive-time">Agent
        /// non-productive time</a></para></dd><dt>SUM_ONLINE_TIME_AGENT</dt><dd><para>Unit: Seconds</para><para>Valid groupings and filters: Routing Profile, Agent, Agent Hierarchy</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#online-time">Online
        /// time</a></para></dd><dt>SUM_RETRY_CALLBACK_ATTEMPTS</dt><dd><para>Unit: Count</para><para>Valid groupings and filters: Queue, Channel, Routing Profile, contact/segmentAttributes/connect:Subtype,
        /// Q in Connect</para><para>UI name: <a href="https://docs.aws.amazon.com/connect/latest/adminguide/metrics-definitions.html#callback-attempts">Callback
        /// attempts</a></para></dd></dl><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// <para>The Amazon Resource Name (ARN) of the resource. This includes the <c>instanceId</c>
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
        /// timestamp. The start and end time depends on the <c>IntervalPeriod</c> selected. By
        /// default the time range between start and end time is 35 days. Historical metrics are
        /// available for 3 months.</para>
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
        
        #region Parameter Interval_TimeZone
        /// <summary>
        /// <para>
        /// <para>The timezone applied to requested metrics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Interval_TimeZone { get; set; }
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
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
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
            context.Interval_IntervalPeriod = this.Interval_IntervalPeriod;
            context.Interval_TimeZone = this.Interval_TimeZone;
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
            
             // populate Interval
            var requestIntervalIsNull = true;
            request.Interval = new Amazon.Connect.Model.IntervalDetails();
            Amazon.Connect.IntervalPeriod requestInterval_interval_IntervalPeriod = null;
            if (cmdletContext.Interval_IntervalPeriod != null)
            {
                requestInterval_interval_IntervalPeriod = cmdletContext.Interval_IntervalPeriod;
            }
            if (requestInterval_interval_IntervalPeriod != null)
            {
                request.Interval.IntervalPeriod = requestInterval_interval_IntervalPeriod;
                requestIntervalIsNull = false;
            }
            System.String requestInterval_interval_TimeZone = null;
            if (cmdletContext.Interval_TimeZone != null)
            {
                requestInterval_interval_TimeZone = cmdletContext.Interval_TimeZone;
            }
            if (requestInterval_interval_TimeZone != null)
            {
                request.Interval.TimeZone = requestInterval_interval_TimeZone;
                requestIntervalIsNull = false;
            }
             // determine if request.Interval should be set to null
            if (requestIntervalIsNull)
            {
                request.Interval = null;
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
                return client.GetMetricDataV2Async(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Connect.IntervalPeriod Interval_IntervalPeriod { get; set; }
            public System.String Interval_TimeZone { get; set; }
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
