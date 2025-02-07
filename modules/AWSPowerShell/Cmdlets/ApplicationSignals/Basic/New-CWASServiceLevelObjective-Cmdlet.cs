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
using Amazon.ApplicationSignals;
using Amazon.ApplicationSignals.Model;

namespace Amazon.PowerShell.Cmdlets.CWAS
{
    /// <summary>
    /// Creates a service level objective (SLO), which can help you ensure that your critical
    /// business operations are meeting customer expectations. Use SLOs to set and track specific
    /// target levels for the reliability and availability of your applications and services.
    /// SLOs use service level indicators (SLIs) to calculate whether the application is performing
    /// at the level that you want.
    /// 
    ///  
    /// <para>
    /// Create an SLO to set a target for a service or operation’s availability or latency.
    /// CloudWatch measures this target frequently you can find whether it has been breached.
    /// 
    /// </para><para>
    /// The target performance quality that is defined for an SLO is the <i>attainment goal</i>.
    /// </para><para>
    /// You can set SLO targets for your applications that are discovered by Application Signals,
    /// using critical metrics such as latency and availability. You can also set SLOs against
    /// any CloudWatch metric or math expression that produces a time series.
    /// </para><para>
    /// When you create an SLO, you specify whether it is a <i>period-based SLO</i> or a <i>request-based
    /// SLO</i>. Each type of SLO has a different way of evaluating your application's performance
    /// against its attainment goal.
    /// </para><ul><li><para>
    /// A <i>period-based SLO</i> uses defined <i>periods</i> of time within a specified total
    /// time interval. For each period of time, Application Signals determines whether the
    /// application met its goal. The attainment rate is calculated as the <c>number of good
    /// periods/number of total periods</c>.
    /// </para><para>
    /// For example, for a period-based SLO, meeting an attainment goal of 99.9% means that
    /// within your interval, your application must meet its performance goal during at least
    /// 99.9% of the time periods.
    /// </para></li><li><para>
    /// A <i>request-based SLO</i> doesn't use pre-defined periods of time. Instead, the SLO
    /// measures <c>number of good requests/number of total requests</c> during the interval.
    /// At any time, you can find the ratio of good requests to total requests for the interval
    /// up to the time stamp that you specify, and measure that ratio against the goal set
    /// in your SLO.
    /// </para></li></ul><para>
    /// After you have created an SLO, you can retrieve error budget reports for it. An <i>error
    /// budget</i> is the amount of time or amount of requests that your application can be
    /// non-compliant with the SLO's goal, and still have your application meet the goal.
    /// </para><ul><li><para>
    /// For a period-based SLO, the error budget starts at a number defined by the highest
    /// number of periods that can fail to meet the threshold, while still meeting the overall
    /// goal. The <i>remaining error budget</i> decreases with every failed period that is
    /// recorded. The error budget within one interval can never increase.
    /// </para><para>
    /// For example, an SLO with a threshold that 99.95% of requests must be completed under
    /// 2000ms every month translates to an error budget of 21.9 minutes of downtime per month.
    /// </para></li><li><para>
    /// For a request-based SLO, the remaining error budget is dynamic and can increase or
    /// decrease, depending on the ratio of good requests to total requests.
    /// </para></li></ul><para>
    /// For more information about SLOs, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch-ServiceLevelObjectives.html">
    /// Service level objectives (SLOs)</a>. 
    /// </para><para>
    /// When you perform a <c>CreateServiceLevelObjective</c> operation, Application Signals
    /// creates the <i>AWSServiceRoleForCloudWatchApplicationSignals</i> service-linked role,
    /// if it doesn't already exist in your account. This service- linked role has the following
    /// permissions:
    /// </para><ul><li><para><c>xray:GetServiceGraph</c></para></li><li><para><c>logs:StartQuery</c></para></li><li><para><c>logs:GetQueryResults</c></para></li><li><para><c>cloudwatch:GetMetricData</c></para></li><li><para><c>cloudwatch:ListMetrics</c></para></li><li><para><c>tag:GetResources</c></para></li><li><para><c>autoscaling:DescribeAutoScalingGroups</c></para></li></ul>
    /// </summary>
    [Cmdlet("New", "CWASServiceLevelObjective", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApplicationSignals.Model.ServiceLevelObjective")]
    [AWSCmdlet("Calls the Amazon CloudWatch Application Signals CreateServiceLevelObjective API operation.", Operation = new[] {"CreateServiceLevelObjective"}, SelectReturnType = typeof(Amazon.ApplicationSignals.Model.CreateServiceLevelObjectiveResponse))]
    [AWSCmdletOutput("Amazon.ApplicationSignals.Model.ServiceLevelObjective or Amazon.ApplicationSignals.Model.CreateServiceLevelObjectiveResponse",
        "This cmdlet returns an Amazon.ApplicationSignals.Model.ServiceLevelObjective object.",
        "The service call response (type Amazon.ApplicationSignals.Model.CreateServiceLevelObjectiveResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCWASServiceLevelObjectiveCmdlet : AmazonApplicationSignalsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Goal_AttainmentGoal
        /// <summary>
        /// <para>
        /// <para>The threshold that determines if the goal is being met.</para><para>If this is a period-based SLO, the attainment goal is the percentage of good periods
        /// that meet the threshold requirements to the total periods within the interval. For
        /// example, an attainment goal of 99.9% means that within your interval, you are targeting
        /// 99.9% of the periods to be in healthy state.</para><para>If this is a request-based SLO, the attainment goal is the percentage of requests
        /// that must be successful to meet the attainment goal.</para><para>If you omit this parameter, 99 is used to represent 99% as the attainment goal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? Goal_AttainmentGoal { get; set; }
        #endregion
        
        #region Parameter MonitoredRequestCountMetric_BadCountMetric
        /// <summary>
        /// <para>
        /// <para>If you want to count "bad requests" to determine the percentage of successful requests
        /// for this request-based SLO, specify the metric to use as "bad requests" in this structure.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestBasedSliConfig_RequestBasedSliMetricConfig_MonitoredRequestCountMetric_BadCountMetric")]
        public Amazon.ApplicationSignals.Model.MetricDataQuery[] MonitoredRequestCountMetric_BadCountMetric { get; set; }
        #endregion
        
        #region Parameter BurnRateConfiguration
        /// <summary>
        /// <para>
        /// <para>Use this array to create <i>burn rates</i> for this SLO. Each burn rate is a metric
        /// that indicates how fast the service is consuming the error budget, relative to the
        /// attainment goal of the SLO.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BurnRateConfigurations")]
        public Amazon.ApplicationSignals.Model.BurnRateConfiguration[] BurnRateConfiguration { get; set; }
        #endregion
        
        #region Parameter RequestBasedSliConfig_ComparisonOperator
        /// <summary>
        /// <para>
        /// <para>The arithmetic operation to use when comparing the specified metric to the threshold.
        /// This parameter is required if this SLO is tracking the <c>Latency</c> metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApplicationSignals.ServiceLevelIndicatorComparisonOperator")]
        public Amazon.ApplicationSignals.ServiceLevelIndicatorComparisonOperator RequestBasedSliConfig_ComparisonOperator { get; set; }
        #endregion
        
        #region Parameter SliConfig_ComparisonOperator
        /// <summary>
        /// <para>
        /// <para>The arithmetic operation to use when comparing the specified metric to the threshold.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApplicationSignals.ServiceLevelIndicatorComparisonOperator")]
        public Amazon.ApplicationSignals.ServiceLevelIndicatorComparisonOperator SliConfig_ComparisonOperator { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description for this SLO.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter CalendarInterval_Duration
        /// <summary>
        /// <para>
        /// <para>Specifies the duration of each calendar interval. For example, if <c>Duration</c>
        /// is <c>1</c> and <c>DurationUnit</c> is <c>MONTH</c>, each interval is one month, aligned
        /// with the calendar.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Goal_Interval_CalendarInterval_Duration")]
        public System.Int32? CalendarInterval_Duration { get; set; }
        #endregion
        
        #region Parameter RollingInterval_Duration
        /// <summary>
        /// <para>
        /// <para>Specifies the duration of each rolling interval. For example, if <c>Duration</c> is
        /// <c>7</c> and <c>DurationUnit</c> is <c>DAY</c>, each rolling interval is seven days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Goal_Interval_RollingInterval_Duration")]
        public System.Int32? RollingInterval_Duration { get; set; }
        #endregion
        
        #region Parameter CalendarInterval_DurationUnit
        /// <summary>
        /// <para>
        /// <para>Specifies the calendar interval unit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Goal_Interval_CalendarInterval_DurationUnit")]
        [AWSConstantClassSource("Amazon.ApplicationSignals.DurationUnit")]
        public Amazon.ApplicationSignals.DurationUnit CalendarInterval_DurationUnit { get; set; }
        #endregion
        
        #region Parameter RollingInterval_DurationUnit
        /// <summary>
        /// <para>
        /// <para>Specifies the rolling interval unit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Goal_Interval_RollingInterval_DurationUnit")]
        [AWSConstantClassSource("Amazon.ApplicationSignals.DurationUnit")]
        public Amazon.ApplicationSignals.DurationUnit RollingInterval_DurationUnit { get; set; }
        #endregion
        
        #region Parameter MonitoredRequestCountMetric_GoodCountMetric
        /// <summary>
        /// <para>
        /// <para>If you want to count "good requests" to determine the percentage of successful requests
        /// for this request-based SLO, specify the metric to use as "good requests" in this structure.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestBasedSliConfig_RequestBasedSliMetricConfig_MonitoredRequestCountMetric_GoodCountMetric")]
        public Amazon.ApplicationSignals.Model.MetricDataQuery[] MonitoredRequestCountMetric_GoodCountMetric { get; set; }
        #endregion
        
        #region Parameter RequestBasedSliMetricConfig_KeyAttribute
        /// <summary>
        /// <para>
        /// <para>If this SLO is related to a metric collected by Application Signals, you must use
        /// this field to specify which service the SLO metric is related to. To do so, you must
        /// specify at least the <c>Type</c>, <c>Name</c>, and <c>Environment</c> attributes.</para><para>This is a string-to-string map. It can include the following fields.</para><ul><li><para><c>Type</c> designates the type of object this is.</para></li><li><para><c>ResourceType</c> specifies the type of the resource. This field is used only when
        /// the value of the <c>Type</c> field is <c>Resource</c> or <c>AWS::Resource</c>.</para></li><li><para><c>Name</c> specifies the name of the object. This is used only if the value of the
        /// <c>Type</c> field is <c>Service</c>, <c>RemoteService</c>, or <c>AWS::Service</c>.</para></li><li><para><c>Identifier</c> identifies the resource objects of this resource. This is used
        /// only if the value of the <c>Type</c> field is <c>Resource</c> or <c>AWS::Resource</c>.</para></li><li><para><c>Environment</c> specifies the location where this object is hosted, or what it
        /// belongs to.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestBasedSliConfig_RequestBasedSliMetricConfig_KeyAttributes")]
        public System.Collections.Hashtable RequestBasedSliMetricConfig_KeyAttribute { get; set; }
        #endregion
        
        #region Parameter SliMetricConfig_KeyAttribute
        /// <summary>
        /// <para>
        /// <para>If this SLO is related to a metric collected by Application Signals, you must use
        /// this field to specify which service the SLO metric is related to. To do so, you must
        /// specify at least the <c>Type</c>, <c>Name</c>, and <c>Environment</c> attributes.</para><para>This is a string-to-string map. It can include the following fields.</para><ul><li><para><c>Type</c> designates the type of object this is.</para></li><li><para><c>ResourceType</c> specifies the type of the resource. This field is used only when
        /// the value of the <c>Type</c> field is <c>Resource</c> or <c>AWS::Resource</c>.</para></li><li><para><c>Name</c> specifies the name of the object. This is used only if the value of the
        /// <c>Type</c> field is <c>Service</c>, <c>RemoteService</c>, or <c>AWS::Service</c>.</para></li><li><para><c>Identifier</c> identifies the resource objects of this resource. This is used
        /// only if the value of the <c>Type</c> field is <c>Resource</c> or <c>AWS::Resource</c>.</para></li><li><para><c>Environment</c> specifies the location where this object is hosted, or what it
        /// belongs to.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SliConfig_SliMetricConfig_KeyAttributes")]
        public System.Collections.Hashtable SliMetricConfig_KeyAttribute { get; set; }
        #endregion
        
        #region Parameter SliMetricConfig_MetricDataQuery
        /// <summary>
        /// <para>
        /// <para>If this SLO monitors a CloudWatch metric or the result of a CloudWatch metric math
        /// expression, use this structure to specify that metric or expression. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SliConfig_SliMetricConfig_MetricDataQueries")]
        public Amazon.ApplicationSignals.Model.MetricDataQuery[] SliMetricConfig_MetricDataQuery { get; set; }
        #endregion
        
        #region Parameter RequestBasedSliConfig_MetricThreshold
        /// <summary>
        /// <para>
        /// <para>The value that the SLI metric is compared to. This parameter is required if this SLO
        /// is tracking the <c>Latency</c> metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? RequestBasedSliConfig_MetricThreshold { get; set; }
        #endregion
        
        #region Parameter SliConfig_MetricThreshold
        /// <summary>
        /// <para>
        /// <para>This parameter is used only when a request-based SLO tracks the <c>Latency</c> metric.
        /// Specify the threshold value that the observed <c>Latency</c> metric values are to
        /// be compared to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? SliConfig_MetricThreshold { get; set; }
        #endregion
        
        #region Parameter RequestBasedSliMetricConfig_MetricType
        /// <summary>
        /// <para>
        /// <para>If the SLO is to monitor either the <c>LATENCY</c> or <c>AVAILABILITY</c> metric that
        /// Application Signals collects, use this field to specify which of those metrics is
        /// used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestBasedSliConfig_RequestBasedSliMetricConfig_MetricType")]
        [AWSConstantClassSource("Amazon.ApplicationSignals.ServiceLevelIndicatorMetricType")]
        public Amazon.ApplicationSignals.ServiceLevelIndicatorMetricType RequestBasedSliMetricConfig_MetricType { get; set; }
        #endregion
        
        #region Parameter SliMetricConfig_MetricType
        /// <summary>
        /// <para>
        /// <para>If the SLO is to monitor either the <c>LATENCY</c> or <c>AVAILABILITY</c> metric that
        /// Application Signals collects, use this field to specify which of those metrics is
        /// used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SliConfig_SliMetricConfig_MetricType")]
        [AWSConstantClassSource("Amazon.ApplicationSignals.ServiceLevelIndicatorMetricType")]
        public Amazon.ApplicationSignals.ServiceLevelIndicatorMetricType SliMetricConfig_MetricType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for this SLO.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RequestBasedSliMetricConfig_OperationName
        /// <summary>
        /// <para>
        /// <para>If the SLO is to monitor a specific operation of the service, use this field to specify
        /// the name of that operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestBasedSliConfig_RequestBasedSliMetricConfig_OperationName")]
        public System.String RequestBasedSliMetricConfig_OperationName { get; set; }
        #endregion
        
        #region Parameter SliMetricConfig_OperationName
        /// <summary>
        /// <para>
        /// <para>If the SLO is to monitor a specific operation of the service, use this field to specify
        /// the name of that operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SliConfig_SliMetricConfig_OperationName")]
        public System.String SliMetricConfig_OperationName { get; set; }
        #endregion
        
        #region Parameter SliMetricConfig_PeriodSecond
        /// <summary>
        /// <para>
        /// <para>The number of seconds to use as the period for SLO evaluation. Your application's
        /// performance is compared to the SLI during each period. For each period, the application
        /// is determined to have either achieved or not achieved the necessary performance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SliConfig_SliMetricConfig_PeriodSeconds")]
        public System.Int32? SliMetricConfig_PeriodSecond { get; set; }
        #endregion
        
        #region Parameter CalendarInterval_StartTime
        /// <summary>
        /// <para>
        /// <para>The date and time when you want the first interval to start. Be sure to choose a time
        /// that configures the intervals the way that you want. For example, if you want weekly
        /// intervals starting on Mondays at 6 a.m., be sure to specify a start time that is a
        /// Monday at 6 a.m.</para><para>When used in a raw HTTP Query API, it is formatted as be epoch time in seconds. For
        /// example: <c>1698778057</c></para><para>As soon as one calendar interval ends, another automatically begins.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Goal_Interval_CalendarInterval_StartTime")]
        public System.DateTime? CalendarInterval_StartTime { get; set; }
        #endregion
        
        #region Parameter SliMetricConfig_Statistic
        /// <summary>
        /// <para>
        /// <para>The statistic to use for comparison to the threshold. It can be any CloudWatch statistic
        /// or extended statistic. For more information about statistics, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/Statistics-definitions.html">CloudWatch
        /// statistics definitions</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SliConfig_SliMetricConfig_Statistic")]
        public System.String SliMetricConfig_Statistic { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs to associate with the SLO. You can associate as many as
        /// 50 tags with an SLO. To be able to associate tags with the SLO when you create the
        /// SLO, you must have the <c>cloudwatch:TagResource</c> permission.</para><para>Tags can help you organize and categorize your resources. You can also use them to
        /// scope user permissions by granting a user permission to access or change only resources
        /// with certain tag values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ApplicationSignals.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter RequestBasedSliMetricConfig_TotalRequestCountMetric
        /// <summary>
        /// <para>
        /// <para>Use this structure to define the metric that you want to use as the "total requests"
        /// number for a request-based SLO. This result will be divided by the "good request"
        /// or "bad request" value defined in <c>MonitoredRequestCountMetric</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestBasedSliConfig_RequestBasedSliMetricConfig_TotalRequestCountMetric")]
        public Amazon.ApplicationSignals.Model.MetricDataQuery[] RequestBasedSliMetricConfig_TotalRequestCountMetric { get; set; }
        #endregion
        
        #region Parameter Goal_WarningThreshold
        /// <summary>
        /// <para>
        /// <para>The percentage of remaining budget over total budget that you want to get warnings
        /// for. If you omit this parameter, the default of 50.0 is used. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? Goal_WarningThreshold { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Slo'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationSignals.Model.CreateServiceLevelObjectiveResponse).
        /// Specifying the name of a property of type Amazon.ApplicationSignals.Model.CreateServiceLevelObjectiveResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Slo";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWASServiceLevelObjective (CreateServiceLevelObjective)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationSignals.Model.CreateServiceLevelObjectiveResponse, NewCWASServiceLevelObjectiveCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.BurnRateConfiguration != null)
            {
                context.BurnRateConfiguration = new List<Amazon.ApplicationSignals.Model.BurnRateConfiguration>(this.BurnRateConfiguration);
            }
            context.Description = this.Description;
            context.Goal_AttainmentGoal = this.Goal_AttainmentGoal;
            context.CalendarInterval_Duration = this.CalendarInterval_Duration;
            context.CalendarInterval_DurationUnit = this.CalendarInterval_DurationUnit;
            context.CalendarInterval_StartTime = this.CalendarInterval_StartTime;
            context.RollingInterval_Duration = this.RollingInterval_Duration;
            context.RollingInterval_DurationUnit = this.RollingInterval_DurationUnit;
            context.Goal_WarningThreshold = this.Goal_WarningThreshold;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RequestBasedSliConfig_ComparisonOperator = this.RequestBasedSliConfig_ComparisonOperator;
            context.RequestBasedSliConfig_MetricThreshold = this.RequestBasedSliConfig_MetricThreshold;
            if (this.RequestBasedSliMetricConfig_KeyAttribute != null)
            {
                context.RequestBasedSliMetricConfig_KeyAttribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RequestBasedSliMetricConfig_KeyAttribute.Keys)
                {
                    context.RequestBasedSliMetricConfig_KeyAttribute.Add((String)hashKey, (System.String)(this.RequestBasedSliMetricConfig_KeyAttribute[hashKey]));
                }
            }
            context.RequestBasedSliMetricConfig_MetricType = this.RequestBasedSliMetricConfig_MetricType;
            if (this.MonitoredRequestCountMetric_BadCountMetric != null)
            {
                context.MonitoredRequestCountMetric_BadCountMetric = new List<Amazon.ApplicationSignals.Model.MetricDataQuery>(this.MonitoredRequestCountMetric_BadCountMetric);
            }
            if (this.MonitoredRequestCountMetric_GoodCountMetric != null)
            {
                context.MonitoredRequestCountMetric_GoodCountMetric = new List<Amazon.ApplicationSignals.Model.MetricDataQuery>(this.MonitoredRequestCountMetric_GoodCountMetric);
            }
            context.RequestBasedSliMetricConfig_OperationName = this.RequestBasedSliMetricConfig_OperationName;
            if (this.RequestBasedSliMetricConfig_TotalRequestCountMetric != null)
            {
                context.RequestBasedSliMetricConfig_TotalRequestCountMetric = new List<Amazon.ApplicationSignals.Model.MetricDataQuery>(this.RequestBasedSliMetricConfig_TotalRequestCountMetric);
            }
            context.SliConfig_ComparisonOperator = this.SliConfig_ComparisonOperator;
            context.SliConfig_MetricThreshold = this.SliConfig_MetricThreshold;
            if (this.SliMetricConfig_KeyAttribute != null)
            {
                context.SliMetricConfig_KeyAttribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SliMetricConfig_KeyAttribute.Keys)
                {
                    context.SliMetricConfig_KeyAttribute.Add((String)hashKey, (System.String)(this.SliMetricConfig_KeyAttribute[hashKey]));
                }
            }
            if (this.SliMetricConfig_MetricDataQuery != null)
            {
                context.SliMetricConfig_MetricDataQuery = new List<Amazon.ApplicationSignals.Model.MetricDataQuery>(this.SliMetricConfig_MetricDataQuery);
            }
            context.SliMetricConfig_MetricType = this.SliMetricConfig_MetricType;
            context.SliMetricConfig_OperationName = this.SliMetricConfig_OperationName;
            context.SliMetricConfig_PeriodSecond = this.SliMetricConfig_PeriodSecond;
            context.SliMetricConfig_Statistic = this.SliMetricConfig_Statistic;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ApplicationSignals.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.ApplicationSignals.Model.CreateServiceLevelObjectiveRequest();
            
            if (cmdletContext.BurnRateConfiguration != null)
            {
                request.BurnRateConfigurations = cmdletContext.BurnRateConfiguration;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate Goal
            var requestGoalIsNull = true;
            request.Goal = new Amazon.ApplicationSignals.Model.Goal();
            System.Double? requestGoal_goal_AttainmentGoal = null;
            if (cmdletContext.Goal_AttainmentGoal != null)
            {
                requestGoal_goal_AttainmentGoal = cmdletContext.Goal_AttainmentGoal.Value;
            }
            if (requestGoal_goal_AttainmentGoal != null)
            {
                request.Goal.AttainmentGoal = requestGoal_goal_AttainmentGoal.Value;
                requestGoalIsNull = false;
            }
            System.Double? requestGoal_goal_WarningThreshold = null;
            if (cmdletContext.Goal_WarningThreshold != null)
            {
                requestGoal_goal_WarningThreshold = cmdletContext.Goal_WarningThreshold.Value;
            }
            if (requestGoal_goal_WarningThreshold != null)
            {
                request.Goal.WarningThreshold = requestGoal_goal_WarningThreshold.Value;
                requestGoalIsNull = false;
            }
            Amazon.ApplicationSignals.Model.Interval requestGoal_goal_Interval = null;
            
             // populate Interval
            var requestGoal_goal_IntervalIsNull = true;
            requestGoal_goal_Interval = new Amazon.ApplicationSignals.Model.Interval();
            Amazon.ApplicationSignals.Model.RollingInterval requestGoal_goal_Interval_goal_Interval_RollingInterval = null;
            
             // populate RollingInterval
            var requestGoal_goal_Interval_goal_Interval_RollingIntervalIsNull = true;
            requestGoal_goal_Interval_goal_Interval_RollingInterval = new Amazon.ApplicationSignals.Model.RollingInterval();
            System.Int32? requestGoal_goal_Interval_goal_Interval_RollingInterval_rollingInterval_Duration = null;
            if (cmdletContext.RollingInterval_Duration != null)
            {
                requestGoal_goal_Interval_goal_Interval_RollingInterval_rollingInterval_Duration = cmdletContext.RollingInterval_Duration.Value;
            }
            if (requestGoal_goal_Interval_goal_Interval_RollingInterval_rollingInterval_Duration != null)
            {
                requestGoal_goal_Interval_goal_Interval_RollingInterval.Duration = requestGoal_goal_Interval_goal_Interval_RollingInterval_rollingInterval_Duration.Value;
                requestGoal_goal_Interval_goal_Interval_RollingIntervalIsNull = false;
            }
            Amazon.ApplicationSignals.DurationUnit requestGoal_goal_Interval_goal_Interval_RollingInterval_rollingInterval_DurationUnit = null;
            if (cmdletContext.RollingInterval_DurationUnit != null)
            {
                requestGoal_goal_Interval_goal_Interval_RollingInterval_rollingInterval_DurationUnit = cmdletContext.RollingInterval_DurationUnit;
            }
            if (requestGoal_goal_Interval_goal_Interval_RollingInterval_rollingInterval_DurationUnit != null)
            {
                requestGoal_goal_Interval_goal_Interval_RollingInterval.DurationUnit = requestGoal_goal_Interval_goal_Interval_RollingInterval_rollingInterval_DurationUnit;
                requestGoal_goal_Interval_goal_Interval_RollingIntervalIsNull = false;
            }
             // determine if requestGoal_goal_Interval_goal_Interval_RollingInterval should be set to null
            if (requestGoal_goal_Interval_goal_Interval_RollingIntervalIsNull)
            {
                requestGoal_goal_Interval_goal_Interval_RollingInterval = null;
            }
            if (requestGoal_goal_Interval_goal_Interval_RollingInterval != null)
            {
                requestGoal_goal_Interval.RollingInterval = requestGoal_goal_Interval_goal_Interval_RollingInterval;
                requestGoal_goal_IntervalIsNull = false;
            }
            Amazon.ApplicationSignals.Model.CalendarInterval requestGoal_goal_Interval_goal_Interval_CalendarInterval = null;
            
             // populate CalendarInterval
            var requestGoal_goal_Interval_goal_Interval_CalendarIntervalIsNull = true;
            requestGoal_goal_Interval_goal_Interval_CalendarInterval = new Amazon.ApplicationSignals.Model.CalendarInterval();
            System.Int32? requestGoal_goal_Interval_goal_Interval_CalendarInterval_calendarInterval_Duration = null;
            if (cmdletContext.CalendarInterval_Duration != null)
            {
                requestGoal_goal_Interval_goal_Interval_CalendarInterval_calendarInterval_Duration = cmdletContext.CalendarInterval_Duration.Value;
            }
            if (requestGoal_goal_Interval_goal_Interval_CalendarInterval_calendarInterval_Duration != null)
            {
                requestGoal_goal_Interval_goal_Interval_CalendarInterval.Duration = requestGoal_goal_Interval_goal_Interval_CalendarInterval_calendarInterval_Duration.Value;
                requestGoal_goal_Interval_goal_Interval_CalendarIntervalIsNull = false;
            }
            Amazon.ApplicationSignals.DurationUnit requestGoal_goal_Interval_goal_Interval_CalendarInterval_calendarInterval_DurationUnit = null;
            if (cmdletContext.CalendarInterval_DurationUnit != null)
            {
                requestGoal_goal_Interval_goal_Interval_CalendarInterval_calendarInterval_DurationUnit = cmdletContext.CalendarInterval_DurationUnit;
            }
            if (requestGoal_goal_Interval_goal_Interval_CalendarInterval_calendarInterval_DurationUnit != null)
            {
                requestGoal_goal_Interval_goal_Interval_CalendarInterval.DurationUnit = requestGoal_goal_Interval_goal_Interval_CalendarInterval_calendarInterval_DurationUnit;
                requestGoal_goal_Interval_goal_Interval_CalendarIntervalIsNull = false;
            }
            System.DateTime? requestGoal_goal_Interval_goal_Interval_CalendarInterval_calendarInterval_StartTime = null;
            if (cmdletContext.CalendarInterval_StartTime != null)
            {
                requestGoal_goal_Interval_goal_Interval_CalendarInterval_calendarInterval_StartTime = cmdletContext.CalendarInterval_StartTime.Value;
            }
            if (requestGoal_goal_Interval_goal_Interval_CalendarInterval_calendarInterval_StartTime != null)
            {
                requestGoal_goal_Interval_goal_Interval_CalendarInterval.StartTime = requestGoal_goal_Interval_goal_Interval_CalendarInterval_calendarInterval_StartTime.Value;
                requestGoal_goal_Interval_goal_Interval_CalendarIntervalIsNull = false;
            }
             // determine if requestGoal_goal_Interval_goal_Interval_CalendarInterval should be set to null
            if (requestGoal_goal_Interval_goal_Interval_CalendarIntervalIsNull)
            {
                requestGoal_goal_Interval_goal_Interval_CalendarInterval = null;
            }
            if (requestGoal_goal_Interval_goal_Interval_CalendarInterval != null)
            {
                requestGoal_goal_Interval.CalendarInterval = requestGoal_goal_Interval_goal_Interval_CalendarInterval;
                requestGoal_goal_IntervalIsNull = false;
            }
             // determine if requestGoal_goal_Interval should be set to null
            if (requestGoal_goal_IntervalIsNull)
            {
                requestGoal_goal_Interval = null;
            }
            if (requestGoal_goal_Interval != null)
            {
                request.Goal.Interval = requestGoal_goal_Interval;
                requestGoalIsNull = false;
            }
             // determine if request.Goal should be set to null
            if (requestGoalIsNull)
            {
                request.Goal = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate RequestBasedSliConfig
            var requestRequestBasedSliConfigIsNull = true;
            request.RequestBasedSliConfig = new Amazon.ApplicationSignals.Model.RequestBasedServiceLevelIndicatorConfig();
            Amazon.ApplicationSignals.ServiceLevelIndicatorComparisonOperator requestRequestBasedSliConfig_requestBasedSliConfig_ComparisonOperator = null;
            if (cmdletContext.RequestBasedSliConfig_ComparisonOperator != null)
            {
                requestRequestBasedSliConfig_requestBasedSliConfig_ComparisonOperator = cmdletContext.RequestBasedSliConfig_ComparisonOperator;
            }
            if (requestRequestBasedSliConfig_requestBasedSliConfig_ComparisonOperator != null)
            {
                request.RequestBasedSliConfig.ComparisonOperator = requestRequestBasedSliConfig_requestBasedSliConfig_ComparisonOperator;
                requestRequestBasedSliConfigIsNull = false;
            }
            System.Double? requestRequestBasedSliConfig_requestBasedSliConfig_MetricThreshold = null;
            if (cmdletContext.RequestBasedSliConfig_MetricThreshold != null)
            {
                requestRequestBasedSliConfig_requestBasedSliConfig_MetricThreshold = cmdletContext.RequestBasedSliConfig_MetricThreshold.Value;
            }
            if (requestRequestBasedSliConfig_requestBasedSliConfig_MetricThreshold != null)
            {
                request.RequestBasedSliConfig.MetricThreshold = requestRequestBasedSliConfig_requestBasedSliConfig_MetricThreshold.Value;
                requestRequestBasedSliConfigIsNull = false;
            }
            Amazon.ApplicationSignals.Model.RequestBasedServiceLevelIndicatorMetricConfig requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig = null;
            
             // populate RequestBasedSliMetricConfig
            var requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfigIsNull = true;
            requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig = new Amazon.ApplicationSignals.Model.RequestBasedServiceLevelIndicatorMetricConfig();
            Dictionary<System.String, System.String> requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliMetricConfig_KeyAttribute = null;
            if (cmdletContext.RequestBasedSliMetricConfig_KeyAttribute != null)
            {
                requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliMetricConfig_KeyAttribute = cmdletContext.RequestBasedSliMetricConfig_KeyAttribute;
            }
            if (requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliMetricConfig_KeyAttribute != null)
            {
                requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig.KeyAttributes = requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliMetricConfig_KeyAttribute;
                requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfigIsNull = false;
            }
            Amazon.ApplicationSignals.ServiceLevelIndicatorMetricType requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliMetricConfig_MetricType = null;
            if (cmdletContext.RequestBasedSliMetricConfig_MetricType != null)
            {
                requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliMetricConfig_MetricType = cmdletContext.RequestBasedSliMetricConfig_MetricType;
            }
            if (requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliMetricConfig_MetricType != null)
            {
                requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig.MetricType = requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliMetricConfig_MetricType;
                requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfigIsNull = false;
            }
            System.String requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliMetricConfig_OperationName = null;
            if (cmdletContext.RequestBasedSliMetricConfig_OperationName != null)
            {
                requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliMetricConfig_OperationName = cmdletContext.RequestBasedSliMetricConfig_OperationName;
            }
            if (requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliMetricConfig_OperationName != null)
            {
                requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig.OperationName = requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliMetricConfig_OperationName;
                requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfigIsNull = false;
            }
            List<Amazon.ApplicationSignals.Model.MetricDataQuery> requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliMetricConfig_TotalRequestCountMetric = null;
            if (cmdletContext.RequestBasedSliMetricConfig_TotalRequestCountMetric != null)
            {
                requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliMetricConfig_TotalRequestCountMetric = cmdletContext.RequestBasedSliMetricConfig_TotalRequestCountMetric;
            }
            if (requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliMetricConfig_TotalRequestCountMetric != null)
            {
                requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig.TotalRequestCountMetric = requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliMetricConfig_TotalRequestCountMetric;
                requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfigIsNull = false;
            }
            Amazon.ApplicationSignals.Model.MonitoredRequestCountMetricDataQueries requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_MonitoredRequestCountMetric = null;
            
             // populate MonitoredRequestCountMetric
            var requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_MonitoredRequestCountMetricIsNull = true;
            requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_MonitoredRequestCountMetric = new Amazon.ApplicationSignals.Model.MonitoredRequestCountMetricDataQueries();
            List<Amazon.ApplicationSignals.Model.MetricDataQuery> requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_MonitoredRequestCountMetric_monitoredRequestCountMetric_BadCountMetric = null;
            if (cmdletContext.MonitoredRequestCountMetric_BadCountMetric != null)
            {
                requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_MonitoredRequestCountMetric_monitoredRequestCountMetric_BadCountMetric = cmdletContext.MonitoredRequestCountMetric_BadCountMetric;
            }
            if (requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_MonitoredRequestCountMetric_monitoredRequestCountMetric_BadCountMetric != null)
            {
                requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_MonitoredRequestCountMetric.BadCountMetric = requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_MonitoredRequestCountMetric_monitoredRequestCountMetric_BadCountMetric;
                requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_MonitoredRequestCountMetricIsNull = false;
            }
            List<Amazon.ApplicationSignals.Model.MetricDataQuery> requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_MonitoredRequestCountMetric_monitoredRequestCountMetric_GoodCountMetric = null;
            if (cmdletContext.MonitoredRequestCountMetric_GoodCountMetric != null)
            {
                requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_MonitoredRequestCountMetric_monitoredRequestCountMetric_GoodCountMetric = cmdletContext.MonitoredRequestCountMetric_GoodCountMetric;
            }
            if (requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_MonitoredRequestCountMetric_monitoredRequestCountMetric_GoodCountMetric != null)
            {
                requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_MonitoredRequestCountMetric.GoodCountMetric = requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_MonitoredRequestCountMetric_monitoredRequestCountMetric_GoodCountMetric;
                requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_MonitoredRequestCountMetricIsNull = false;
            }
             // determine if requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_MonitoredRequestCountMetric should be set to null
            if (requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_MonitoredRequestCountMetricIsNull)
            {
                requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_MonitoredRequestCountMetric = null;
            }
            if (requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_MonitoredRequestCountMetric != null)
            {
                requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig.MonitoredRequestCountMetric = requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_requestBasedSliConfig_RequestBasedSliMetricConfig_MonitoredRequestCountMetric;
                requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfigIsNull = false;
            }
             // determine if requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig should be set to null
            if (requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfigIsNull)
            {
                requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig = null;
            }
            if (requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig != null)
            {
                request.RequestBasedSliConfig.RequestBasedSliMetricConfig = requestRequestBasedSliConfig_requestBasedSliConfig_RequestBasedSliMetricConfig;
                requestRequestBasedSliConfigIsNull = false;
            }
             // determine if request.RequestBasedSliConfig should be set to null
            if (requestRequestBasedSliConfigIsNull)
            {
                request.RequestBasedSliConfig = null;
            }
            
             // populate SliConfig
            var requestSliConfigIsNull = true;
            request.SliConfig = new Amazon.ApplicationSignals.Model.ServiceLevelIndicatorConfig();
            Amazon.ApplicationSignals.ServiceLevelIndicatorComparisonOperator requestSliConfig_sliConfig_ComparisonOperator = null;
            if (cmdletContext.SliConfig_ComparisonOperator != null)
            {
                requestSliConfig_sliConfig_ComparisonOperator = cmdletContext.SliConfig_ComparisonOperator;
            }
            if (requestSliConfig_sliConfig_ComparisonOperator != null)
            {
                request.SliConfig.ComparisonOperator = requestSliConfig_sliConfig_ComparisonOperator;
                requestSliConfigIsNull = false;
            }
            System.Double? requestSliConfig_sliConfig_MetricThreshold = null;
            if (cmdletContext.SliConfig_MetricThreshold != null)
            {
                requestSliConfig_sliConfig_MetricThreshold = cmdletContext.SliConfig_MetricThreshold.Value;
            }
            if (requestSliConfig_sliConfig_MetricThreshold != null)
            {
                request.SliConfig.MetricThreshold = requestSliConfig_sliConfig_MetricThreshold.Value;
                requestSliConfigIsNull = false;
            }
            Amazon.ApplicationSignals.Model.ServiceLevelIndicatorMetricConfig requestSliConfig_sliConfig_SliMetricConfig = null;
            
             // populate SliMetricConfig
            var requestSliConfig_sliConfig_SliMetricConfigIsNull = true;
            requestSliConfig_sliConfig_SliMetricConfig = new Amazon.ApplicationSignals.Model.ServiceLevelIndicatorMetricConfig();
            Dictionary<System.String, System.String> requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_KeyAttribute = null;
            if (cmdletContext.SliMetricConfig_KeyAttribute != null)
            {
                requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_KeyAttribute = cmdletContext.SliMetricConfig_KeyAttribute;
            }
            if (requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_KeyAttribute != null)
            {
                requestSliConfig_sliConfig_SliMetricConfig.KeyAttributes = requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_KeyAttribute;
                requestSliConfig_sliConfig_SliMetricConfigIsNull = false;
            }
            List<Amazon.ApplicationSignals.Model.MetricDataQuery> requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_MetricDataQuery = null;
            if (cmdletContext.SliMetricConfig_MetricDataQuery != null)
            {
                requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_MetricDataQuery = cmdletContext.SliMetricConfig_MetricDataQuery;
            }
            if (requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_MetricDataQuery != null)
            {
                requestSliConfig_sliConfig_SliMetricConfig.MetricDataQueries = requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_MetricDataQuery;
                requestSliConfig_sliConfig_SliMetricConfigIsNull = false;
            }
            Amazon.ApplicationSignals.ServiceLevelIndicatorMetricType requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_MetricType = null;
            if (cmdletContext.SliMetricConfig_MetricType != null)
            {
                requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_MetricType = cmdletContext.SliMetricConfig_MetricType;
            }
            if (requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_MetricType != null)
            {
                requestSliConfig_sliConfig_SliMetricConfig.MetricType = requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_MetricType;
                requestSliConfig_sliConfig_SliMetricConfigIsNull = false;
            }
            System.String requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_OperationName = null;
            if (cmdletContext.SliMetricConfig_OperationName != null)
            {
                requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_OperationName = cmdletContext.SliMetricConfig_OperationName;
            }
            if (requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_OperationName != null)
            {
                requestSliConfig_sliConfig_SliMetricConfig.OperationName = requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_OperationName;
                requestSliConfig_sliConfig_SliMetricConfigIsNull = false;
            }
            System.Int32? requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_PeriodSecond = null;
            if (cmdletContext.SliMetricConfig_PeriodSecond != null)
            {
                requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_PeriodSecond = cmdletContext.SliMetricConfig_PeriodSecond.Value;
            }
            if (requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_PeriodSecond != null)
            {
                requestSliConfig_sliConfig_SliMetricConfig.PeriodSeconds = requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_PeriodSecond.Value;
                requestSliConfig_sliConfig_SliMetricConfigIsNull = false;
            }
            System.String requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_Statistic = null;
            if (cmdletContext.SliMetricConfig_Statistic != null)
            {
                requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_Statistic = cmdletContext.SliMetricConfig_Statistic;
            }
            if (requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_Statistic != null)
            {
                requestSliConfig_sliConfig_SliMetricConfig.Statistic = requestSliConfig_sliConfig_SliMetricConfig_sliMetricConfig_Statistic;
                requestSliConfig_sliConfig_SliMetricConfigIsNull = false;
            }
             // determine if requestSliConfig_sliConfig_SliMetricConfig should be set to null
            if (requestSliConfig_sliConfig_SliMetricConfigIsNull)
            {
                requestSliConfig_sliConfig_SliMetricConfig = null;
            }
            if (requestSliConfig_sliConfig_SliMetricConfig != null)
            {
                request.SliConfig.SliMetricConfig = requestSliConfig_sliConfig_SliMetricConfig;
                requestSliConfigIsNull = false;
            }
             // determine if request.SliConfig should be set to null
            if (requestSliConfigIsNull)
            {
                request.SliConfig = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.ApplicationSignals.Model.CreateServiceLevelObjectiveResponse CallAWSServiceOperation(IAmazonApplicationSignals client, Amazon.ApplicationSignals.Model.CreateServiceLevelObjectiveRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Application Signals", "CreateServiceLevelObjective");
            try
            {
                #if DESKTOP
                return client.CreateServiceLevelObjective(request);
                #elif CORECLR
                return client.CreateServiceLevelObjectiveAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ApplicationSignals.Model.BurnRateConfiguration> BurnRateConfiguration { get; set; }
            public System.String Description { get; set; }
            public System.Double? Goal_AttainmentGoal { get; set; }
            public System.Int32? CalendarInterval_Duration { get; set; }
            public Amazon.ApplicationSignals.DurationUnit CalendarInterval_DurationUnit { get; set; }
            public System.DateTime? CalendarInterval_StartTime { get; set; }
            public System.Int32? RollingInterval_Duration { get; set; }
            public Amazon.ApplicationSignals.DurationUnit RollingInterval_DurationUnit { get; set; }
            public System.Double? Goal_WarningThreshold { get; set; }
            public System.String Name { get; set; }
            public Amazon.ApplicationSignals.ServiceLevelIndicatorComparisonOperator RequestBasedSliConfig_ComparisonOperator { get; set; }
            public System.Double? RequestBasedSliConfig_MetricThreshold { get; set; }
            public Dictionary<System.String, System.String> RequestBasedSliMetricConfig_KeyAttribute { get; set; }
            public Amazon.ApplicationSignals.ServiceLevelIndicatorMetricType RequestBasedSliMetricConfig_MetricType { get; set; }
            public List<Amazon.ApplicationSignals.Model.MetricDataQuery> MonitoredRequestCountMetric_BadCountMetric { get; set; }
            public List<Amazon.ApplicationSignals.Model.MetricDataQuery> MonitoredRequestCountMetric_GoodCountMetric { get; set; }
            public System.String RequestBasedSliMetricConfig_OperationName { get; set; }
            public List<Amazon.ApplicationSignals.Model.MetricDataQuery> RequestBasedSliMetricConfig_TotalRequestCountMetric { get; set; }
            public Amazon.ApplicationSignals.ServiceLevelIndicatorComparisonOperator SliConfig_ComparisonOperator { get; set; }
            public System.Double? SliConfig_MetricThreshold { get; set; }
            public Dictionary<System.String, System.String> SliMetricConfig_KeyAttribute { get; set; }
            public List<Amazon.ApplicationSignals.Model.MetricDataQuery> SliMetricConfig_MetricDataQuery { get; set; }
            public Amazon.ApplicationSignals.ServiceLevelIndicatorMetricType SliMetricConfig_MetricType { get; set; }
            public System.String SliMetricConfig_OperationName { get; set; }
            public System.Int32? SliMetricConfig_PeriodSecond { get; set; }
            public System.String SliMetricConfig_Statistic { get; set; }
            public List<Amazon.ApplicationSignals.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ApplicationSignals.Model.CreateServiceLevelObjectiveResponse, NewCWASServiceLevelObjectiveCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Slo;
        }
        
    }
}
