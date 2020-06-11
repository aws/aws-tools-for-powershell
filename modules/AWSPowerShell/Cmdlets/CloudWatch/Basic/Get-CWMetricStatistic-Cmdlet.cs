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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// Gets statistics for the specified metric.
    /// 
    ///  
    /// <para>
    /// The maximum number of data points returned from a single call is 1,440. If you request
    /// more than 1,440 data points, CloudWatch returns an error. To reduce the number of
    /// data points, you can narrow the specified time range and make multiple requests across
    /// adjacent time ranges, or you can increase the specified period. Data points are not
    /// returned in chronological order.
    /// </para><para>
    /// CloudWatch aggregates data points based on the length of the period that you specify.
    /// For example, if you request statistics with a one-hour period, CloudWatch aggregates
    /// all data points with time stamps that fall within each one-hour period. Therefore,
    /// the number of values aggregated by CloudWatch is larger than the number of data points
    /// returned.
    /// </para><para>
    /// CloudWatch needs raw data points to calculate percentile statistics. If you publish
    /// data using a statistic set instead, you can only retrieve percentile statistics for
    /// this data if one of the following conditions is true:
    /// </para><ul><li><para>
    /// The SampleCount value of the statistic set is 1.
    /// </para></li><li><para>
    /// The Min and the Max values of the statistic set are equal.
    /// </para></li></ul><para>
    /// Percentile statistics are not available for metrics when any of the metric values
    /// are negative numbers.
    /// </para><para>
    /// Amazon CloudWatch retains metric data as follows:
    /// </para><ul><li><para>
    /// Data points with a period of less than 60 seconds are available for 3 hours. These
    /// data points are high-resolution metrics and are available only for custom metrics
    /// that have been defined with a <code>StorageResolution</code> of 1.
    /// </para></li><li><para>
    /// Data points with a period of 60 seconds (1-minute) are available for 15 days.
    /// </para></li><li><para>
    /// Data points with a period of 300 seconds (5-minute) are available for 63 days.
    /// </para></li><li><para>
    /// Data points with a period of 3600 seconds (1 hour) are available for 455 days (15
    /// months).
    /// </para></li></ul><para>
    /// Data points that are initially published with a shorter period are aggregated together
    /// for long-term storage. For example, if you collect data using a period of 1 minute,
    /// the data remains available for 15 days with 1-minute resolution. After 15 days, this
    /// data is still available, but is aggregated and retrievable only with a resolution
    /// of 5 minutes. After 63 days, the data is further aggregated and is available with
    /// a resolution of 1 hour.
    /// </para><para>
    /// CloudWatch started retaining 5-minute and 1-hour metric data as of July 9, 2016.
    /// </para><para>
    /// For information about metrics and dimensions supported by AWS services, see the <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CW_Support_For_AWS.html">Amazon
    /// CloudWatch Metrics and Dimensions Reference</a> in the <i>Amazon CloudWatch User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CWMetricStatistic")]
    [OutputType("Amazon.CloudWatch.Model.GetMetricStatisticsResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch GetMetricStatistics API operation.", Operation = new[] {"GetMetricStatistics"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.GetMetricStatisticsResponse), LegacyAlias="Get-CWMetricStatistics")]
    [AWSCmdletOutput("Amazon.CloudWatch.Model.GetMetricStatisticsResponse",
        "This cmdlet returns an Amazon.CloudWatch.Model.GetMetricStatisticsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCWMetricStatisticCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        #region Parameter Dimension
        /// <summary>
        /// <para>
        /// <para>The dimensions. If the metric contains multiple dimensions, you must include a value
        /// for each dimension. CloudWatch treats each unique combination of dimensions as a separate
        /// metric. If a specific combination of dimensions was not published, you can't retrieve
        /// statistics for it. You must specify the same dimensions that were used when the metrics
        /// were created. For an example, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/cloudwatch_concepts.html#dimension-combinations">Dimension
        /// Combinations</a> in the <i>Amazon CloudWatch User Guide</i>. For more information
        /// about specifying dimensions, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/publishingMetrics.html">Publishing
        /// Metrics</a> in the <i>Amazon CloudWatch User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [Alias("Dimensions")]
        public Amazon.CloudWatch.Model.Dimension[] Dimension { get; set; }
        #endregion
        
        #region Parameter UtcEndTime
        /// <summary>
        /// <para>
        /// <para>The time stamp that determines the last data point to return.</para><para>The value specified is exclusive; results include data points up to the specified
        /// time stamp. In a raw HTTP query, the time stamp must be in ISO 8601 UTC format (for
        /// example, 2016-10-10T23:00:00Z).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? UtcEndTime { get; set; }
        #endregion
        
        #region Parameter ExtendedStatistic
        /// <summary>
        /// <para>
        /// <para>The percentile statistics. Specify values between p0.0 and p100. When calling <code>GetMetricStatistics</code>,
        /// you must specify either <code>Statistics</code> or <code>ExtendedStatistics</code>,
        /// but not both. Percentile statistics are not available for metrics when any of the
        /// metric values are negative numbers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExtendedStatistics")]
        public System.String[] ExtendedStatistic { get; set; }
        #endregion
        
        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// <para>The name of the metric, with or without spaces.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String MetricName { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the metric, with or without spaces.</para>
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
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter Period
        /// <summary>
        /// <para>
        /// <para>The granularity, in seconds, of the returned data points. For metrics with regular
        /// resolution, a period can be as short as one minute (60 seconds) and must be a multiple
        /// of 60. For high-resolution metrics that are collected at intervals of less than one
        /// minute, the period can be 1, 5, 10, 30, 60, or any multiple of 60. High-resolution
        /// metrics are those metrics stored by a <code>PutMetricData</code> call that includes
        /// a <code>StorageResolution</code> of 1 second.</para><para>If the <code>StartTime</code> parameter specifies a time stamp that is greater than
        /// 3 hours ago, you must specify the period as follows or no data points in that time
        /// range is returned:</para><ul><li><para>Start time between 3 hours and 15 days ago - Use a multiple of 60 seconds (1 minute).</para></li><li><para>Start time between 15 and 63 days ago - Use a multiple of 300 seconds (5 minutes).</para></li><li><para>Start time greater than 63 days ago - Use a multiple of 3600 seconds (1 hour).</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Period { get; set; }
        #endregion
        
        #region Parameter UtcStartTime
        /// <summary>
        /// <para>
        /// <para>The time stamp that determines the first data point to return. Start times are evaluated
        /// relative to the time that CloudWatch receives the request.</para><para>The value specified is inclusive; results include data points with the specified time
        /// stamp. In a raw HTTP query, the time stamp must be in ISO 8601 UTC format (for example,
        /// 2016-10-03T23:00:00Z).</para><para>CloudWatch rounds the specified time stamp as follows:</para><ul><li><para>Start time less than 15 days ago - Round down to the nearest whole minute. For example,
        /// 12:32:34 is rounded down to 12:32:00.</para></li><li><para>Start time between 15 and 63 days ago - Round down to the nearest 5-minute clock interval.
        /// For example, 12:32:34 is rounded down to 12:30:00.</para></li><li><para>Start time greater than 63 days ago - Round down to the nearest 1-hour clock interval.
        /// For example, 12:32:34 is rounded down to 12:00:00.</para></li></ul><para>If you set <code>Period</code> to 5, 10, or 30, the start time of your request is
        /// rounded down to the nearest time that corresponds to even 5-, 10-, or 30-second divisions
        /// of a minute. For example, if you make a query at (HH:mm:ss) 01:05:23 for the previous
        /// 10-second period, the start time of your request is rounded down and you receive data
        /// from 01:05:10 to 01:05:20. If you make a query at 15:07:17 for the previous 5 minutes
        /// of data, using a period of 5 seconds, you receive data timestamped between 15:02:15
        /// and 15:07:15. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? UtcStartTime { get; set; }
        #endregion
        
        #region Parameter Statistic
        /// <summary>
        /// <para>
        /// <para>The metric statistics, other than percentile. For percentile statistics, use <code>ExtendedStatistics</code>.
        /// When calling <code>GetMetricStatistics</code>, you must specify either <code>Statistics</code>
        /// or <code>ExtendedStatistics</code>, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Statistics")]
        public System.String[] Statistic { get; set; }
        #endregion
        
        #region Parameter Unit
        /// <summary>
        /// <para>
        /// <para>The unit for a given metric. If you omit <code>Unit</code>, all data that was collected
        /// with any unit is returned, along with the corresponding units that were specified
        /// when the data was reported to CloudWatch. If you specify a unit, the operation returns
        /// only data that was collected with that unit specified. If you specify a unit that
        /// does not match the data collected, the results of the operation are null. CloudWatch
        /// does not perform unit conversions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatch.StandardUnit")]
        public Amazon.CloudWatch.StandardUnit Unit { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use EndTimeUtc instead. Setting either EndTime or EndTimeUtc
        /// results in both EndTime and EndTimeUtc being assigned, the latest assignment to either
        /// one of the two property is reflected in the value of both. EndTime is provided for
        /// backwards compatibility only and assigning a non-Utc DateTime to it results in the
        /// wrong timestamp being passed to the service.</para><para>The time stamp that determines the last data point to return.</para><para>The value specified is exclusive; results include data points up to the specified
        /// time stamp. In a raw HTTP query, the time stamp must be in ISO 8601 UTC format (for
        /// example, 2016-10-10T23:00:00Z).</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed to the service, use UtcEndTime instead.")]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use StartTimeUtc instead. Setting either StartTime or
        /// StartTimeUtc results in both StartTime and StartTimeUtc being assigned, the latest
        /// assignment to either one of the two property is reflected in the value of both. StartTime
        /// is provided for backwards compatibility only and assigning a non-Utc DateTime to it
        /// results in the wrong timestamp being passed to the service.</para><para>The time stamp that determines the first data point to return. Start times are evaluated
        /// relative to the time that CloudWatch receives the request.</para><para>The value specified is inclusive; results include data points with the specified time
        /// stamp. In a raw HTTP query, the time stamp must be in ISO 8601 UTC format (for example,
        /// 2016-10-03T23:00:00Z).</para><para>CloudWatch rounds the specified time stamp as follows:</para><ul><li><para>Start time less than 15 days ago - Round down to the nearest whole minute. For example,
        /// 12:32:34 is rounded down to 12:32:00.</para></li><li><para>Start time between 15 and 63 days ago - Round down to the nearest 5-minute clock interval.
        /// For example, 12:32:34 is rounded down to 12:30:00.</para></li><li><para>Start time greater than 63 days ago - Round down to the nearest 1-hour clock interval.
        /// For example, 12:32:34 is rounded down to 12:00:00.</para></li></ul><para>If you set <code>Period</code> to 5, 10, or 30, the start time of your request is
        /// rounded down to the nearest time that corresponds to even 5-, 10-, or 30-second divisions
        /// of a minute. For example, if you make a query at (HH:mm:ss) 01:05:23 for the previous
        /// 10-second period, the start time of your request is rounded down and you receive data
        /// from 01:05:10 to 01:05:20. If you make a query at 15:07:17 for the previous 5 minutes
        /// of data, using a period of 5 seconds, you receive data timestamped between 15:02:15
        /// and 15:07:15. </para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed to the service, use UtcStartTime instead.")]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.GetMetricStatisticsResponse).
        /// Specifying the name of a property of type Amazon.CloudWatch.Model.GetMetricStatisticsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Namespace parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Namespace' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Namespace' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.GetMetricStatisticsResponse, GetCWMetricStatisticCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Namespace;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Dimension != null)
            {
                context.Dimension = new List<Amazon.CloudWatch.Model.Dimension>(this.Dimension);
            }
            context.UtcEndTime = this.UtcEndTime;
            #if MODULAR
            if (this.UtcEndTime == null && ParameterWasBound(nameof(this.UtcEndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter UtcEndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ExtendedStatistic != null)
            {
                context.ExtendedStatistic = new List<System.String>(this.ExtendedStatistic);
            }
            context.MetricName = this.MetricName;
            #if MODULAR
            if (this.MetricName == null && ParameterWasBound(nameof(this.MetricName)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Namespace = this.Namespace;
            #if MODULAR
            if (this.Namespace == null && ParameterWasBound(nameof(this.Namespace)))
            {
                WriteWarning("You are passing $null as a value for parameter Namespace which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Period = this.Period;
            #if MODULAR
            if (this.Period == null && ParameterWasBound(nameof(this.Period)))
            {
                WriteWarning("You are passing $null as a value for parameter Period which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UtcStartTime = this.UtcStartTime;
            #if MODULAR
            if (this.UtcStartTime == null && ParameterWasBound(nameof(this.UtcStartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter UtcStartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Statistic != null)
            {
                context.Statistic = new List<System.String>(this.Statistic);
            }
            context.Unit = this.Unit;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EndTime = this.EndTime;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.StartTime = this.StartTime;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
            var request = new Amazon.CloudWatch.Model.GetMetricStatisticsRequest();
            
            if (cmdletContext.Dimension != null)
            {
                request.Dimensions = cmdletContext.Dimension;
            }
            if (cmdletContext.UtcEndTime != null)
            {
                request.EndTimeUtc = cmdletContext.UtcEndTime.Value;
            }
            if (cmdletContext.ExtendedStatistic != null)
            {
                request.ExtendedStatistics = cmdletContext.ExtendedStatistic;
            }
            if (cmdletContext.MetricName != null)
            {
                request.MetricName = cmdletContext.MetricName;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            if (cmdletContext.Period != null)
            {
                request.Period = cmdletContext.Period.Value;
            }
            if (cmdletContext.UtcStartTime != null)
            {
                request.StartTimeUtc = cmdletContext.UtcStartTime.Value;
            }
            if (cmdletContext.Statistic != null)
            {
                request.Statistics = cmdletContext.Statistic;
            }
            if (cmdletContext.Unit != null)
            {
                request.Unit = cmdletContext.Unit;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.EndTime != null)
            {
                if (cmdletContext.UtcEndTime != null)
                {
                    throw new System.ArgumentException("Parameters EndTime and UtcEndTime are mutually exclusive.", nameof(this.EndTime));
                }
                request.EndTime = cmdletContext.EndTime.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.StartTime != null)
            {
                if (cmdletContext.UtcStartTime != null)
                {
                    throw new System.ArgumentException("Parameters StartTime and UtcStartTime are mutually exclusive.", nameof(this.StartTime));
                }
                request.StartTime = cmdletContext.StartTime.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
        
        private Amazon.CloudWatch.Model.GetMetricStatisticsResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.GetMetricStatisticsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "GetMetricStatistics");
            try
            {
                #if DESKTOP
                return client.GetMetricStatistics(request);
                #elif CORECLR
                return client.GetMetricStatisticsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.CloudWatch.Model.Dimension> Dimension { get; set; }
            public System.DateTime? UtcEndTime { get; set; }
            public List<System.String> ExtendedStatistic { get; set; }
            public System.String MetricName { get; set; }
            public System.String Namespace { get; set; }
            public System.Int32? Period { get; set; }
            public System.DateTime? UtcStartTime { get; set; }
            public List<System.String> Statistic { get; set; }
            public Amazon.CloudWatch.StandardUnit Unit { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? EndTime { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.CloudWatch.Model.GetMetricStatisticsResponse, GetCWMetricStatisticCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
