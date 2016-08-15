/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    ///  The maximum number of data points that can be queried is 50,850, whereas the maximum
    /// number of data points returned from a single <code>GetMetricStatistics</code> request
    /// is 1,440. If you make a request that generates more than 1,440 data points, Amazon
    /// CloudWatch returns an error. In such a case, you can alter the request by narrowing
    /// the specified time range or increasing the specified period. A period can be as short
    /// as one minute (60 seconds) or as long as one day (86,400 seconds). Alternatively,
    /// you can make multiple requests across adjacent time ranges. <code>GetMetricStatistics</code>
    /// does not return the data in chronological order. 
    /// </para><para>
    ///  Amazon CloudWatch aggregates data points based on the length of the <code>period</code>
    /// that you specify. For example, if you request statistics with a one-minute granularity,
    /// Amazon CloudWatch aggregates data points with time stamps that fall within the same
    /// one-minute period. In such a case, the data points queried can greatly outnumber the
    /// data points returned. 
    /// </para><para>
    ///  The following examples show various statistics allowed by the data point query maximum
    /// of 50,850 when you call <code>GetMetricStatistics</code> on Amazon EC2 instances with
    /// detailed (one-minute) monitoring enabled: 
    /// </para><ul><li><para>
    /// Statistics for up to 400 instances for a span of one hour
    /// </para></li><li><para>
    /// Statistics for up to 35 instances over a span of 24 hours
    /// </para></li><li><para>
    /// Statistics for up to 2 instances over a span of 2 weeks
    /// </para></li></ul><para>
    ///  For information about the namespace, metric names, and dimensions that other Amazon
    /// Web Services products use to send metrics to CloudWatch, go to <a href="http://docs.aws.amazon.com/AmazonCloudWatch/latest/DeveloperGuide/CW_Support_For_AWS.html">Amazon
    /// CloudWatch Metrics, Namespaces, and Dimensions Reference</a> in the <i>Amazon CloudWatch
    /// Developer Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CWMetricStatistics")]
    [OutputType("Amazon.CloudWatch.Model.GetMetricStatisticsResponse")]
    [AWSCmdlet("Invokes the GetMetricStatistics operation against Amazon CloudWatch.", Operation = new[] {"GetMetricStatistics"})]
    [AWSCmdletOutput("Amazon.CloudWatch.Model.GetMetricStatisticsResponse",
        "This cmdlet returns a Amazon.CloudWatch.Model.GetMetricStatisticsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCWMetricStatisticsCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        #region Parameter Dimension
        /// <summary>
        /// <para>
        /// <para>A list of dimensions describing qualities of the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("Dimensions")]
        public Amazon.CloudWatch.Model.Dimension[] Dimension { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The time stamp to use for determining the last datapoint to return. The value specified
        /// is exclusive; results will include datapoints up to the time stamp specified. The
        /// time stamp must be in ISO 8601 UTC format (e.g., 2014-09-03T23:00:00Z).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime EndTime { get; set; }
        #endregion
        
        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// <para>The name of the metric, with or without spaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String MetricName { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the metric, with or without spaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter Period
        /// <summary>
        /// <para>
        /// <para> The granularity, in seconds, of the returned datapoints. A <code>Period</code> can
        /// be as short as one minute (60 seconds) or as long as one day (86,400 seconds), and
        /// must be a multiple of 60. The default value is 60. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Period { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The time stamp to use for determining the first datapoint to return. The value specified
        /// is inclusive; results include datapoints with the time stamp specified. The time stamp
        /// must be in ISO 8601 UTC format (e.g., 2014-09-03T23:00:00Z).</para><note><para>The specified start time is rounded down to the nearest value. Datapoints are returned
        /// for start times up to two weeks in the past. Specified start times that are more than
        /// two weeks in the past will not return datapoints for metrics that are older than two
        /// weeks.</para><para>Data that is timestamped 24 hours or more in the past may take in excess of 48 hours
        /// to become available from submission time using <code>GetMetricStatistics</code>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime StartTime { get; set; }
        #endregion
        
        #region Parameter Statistic
        /// <summary>
        /// <para>
        /// <para> The metric statistics to return. For information about specific statistics returned
        /// by GetMetricStatistics, see <a href="http://docs.aws.amazon.com/AmazonCloudWatch/latest/DeveloperGuide/cloudwatch_concepts.html#Statistic">Statistics</a>
        /// in the <i>Amazon CloudWatch Developer Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Statistics")]
        public System.String[] Statistic { get; set; }
        #endregion
        
        #region Parameter Unit
        /// <summary>
        /// <para>
        /// <para>The specific unit for a given metric. Metrics may be reported in multiple units. Not
        /// supplying a unit results in all units being returned. If the metric only ever reports
        /// one unit, specifying a unit will have no effect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CloudWatch.StandardUnit")]
        public Amazon.CloudWatch.StandardUnit Unit { get; set; }
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
            
            if (this.Dimension != null)
            {
                context.Dimensions = new List<Amazon.CloudWatch.Model.Dimension>(this.Dimension);
            }
            if (ParameterWasBound("EndTime"))
                context.EndTime = this.EndTime;
            context.MetricName = this.MetricName;
            context.Namespace = this.Namespace;
            if (ParameterWasBound("Period"))
                context.Period = this.Period;
            if (ParameterWasBound("StartTime"))
                context.StartTime = this.StartTime;
            if (this.Statistic != null)
            {
                context.Statistics = new List<System.String>(this.Statistic);
            }
            context.Unit = this.Unit;
            
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
            
            if (cmdletContext.Dimensions != null)
            {
                request.Dimensions = cmdletContext.Dimensions;
            }
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
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
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.Statistics != null)
            {
                request.Statistics = cmdletContext.Statistics;
            }
            if (cmdletContext.Unit != null)
            {
                request.Unit = cmdletContext.Unit;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private static Amazon.CloudWatch.Model.GetMetricStatisticsResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.GetMetricStatisticsRequest request)
        {
            #if DESKTOP
            return client.GetMetricStatistics(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.GetMetricStatisticsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<Amazon.CloudWatch.Model.Dimension> Dimensions { get; set; }
            public System.DateTime? EndTime { get; set; }
            public System.String MetricName { get; set; }
            public System.String Namespace { get; set; }
            public System.Int32? Period { get; set; }
            public System.DateTime? StartTime { get; set; }
            public List<System.String> Statistics { get; set; }
            public Amazon.CloudWatch.StandardUnit Unit { get; set; }
        }
        
    }
}
