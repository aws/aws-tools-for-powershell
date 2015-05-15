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
    ///  The maximum number of data points returned from a single <code>GetMetricStatistics</code>
    /// request is 1,440, wereas the maximum number of data points that can be queried is
    /// 50,850. If you make a request that generates more than 1,440 data points, Amazon CloudWatch
    /// returns an error. In such a case, you can alter the request by narrowing the specified
    /// time range or increasing the specified period. Alternatively, you can make multiple
    /// requests across adjacent time ranges. 
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
    /// </para><ul><li>Statistics for up to 400 instances for a span of one hour</li><li>Statistics
    /// for up to 35 instances over a span of 24 hours</li><li>Statistics for up to 2 instances
    /// over a span of 2 weeks</li></ul><para>
    ///  For information about the namespace, metric names, and dimensions that other Amazon
    /// Web Services products use to send metrics to Cloudwatch, go to <a href="http://docs.aws.amazon.com/AmazonCloudWatch/latest/DeveloperGuide/CW_Support_For_AWS.html">Amazon
    /// CloudWatch Metrics, Namespaces, and Dimensions Reference</a> in the <i>Amazon CloudWatch
    /// Developer Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CWMetricStatistics")]
    [OutputType("Amazon.CloudWatch.Model.GetMetricStatisticsResult")]
    [AWSCmdlet("Invokes the GetMetricStatistics operation against Amazon CloudWatch.", Operation = new[] {"GetMetricStatistics"})]
    [AWSCmdletOutput("Amazon.CloudWatch.Model.GetMetricStatisticsResult",
        "This cmdlet returns a GetMetricStatisticsResult object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetCWMetricStatisticsCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> A list of dimensions describing qualities of the metric. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("Dimensions")]
        public Amazon.CloudWatch.Model.Dimension[] Dimension { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The time stamp to use for determining the last datapoint to return. The value specified
        /// is exclusive; results will include datapoints up to the time stamp specified. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public DateTime EndTime { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The name of the metric, with or without spaces. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public String MetricName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The namespace of the metric, with or without spaces. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String Namespace { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The granularity, in seconds, of the returned datapoints. <code>Period</code> must
        /// be at least 60 seconds and must be a multiple of 60. The default value is 60. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 Period { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The time stamp to use for determining the first datapoint to return. The value specified
        /// is inclusive; results include datapoints with the time stamp specified. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public DateTime StartTime { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The metric statistics to return. For information about specific statistics returned
        /// by GetMetricStatistics, go to <a href="http://docs.aws.amazon.com/AmazonCloudWatch/latest/DeveloperGuide/index.html?CHAP_TerminologyandKeyConcepts.html#Statistic">Statistics</a>
        /// in the <i>Amazon CloudWatch Developer Guide</i>. </para><para> Valid Values: <code>Average | Sum | SampleCount | Maximum | Minimum</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Statistics")]
        public System.String[] Statistic { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The unit for the metric. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public StandardUnit Unit { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.Dimension != null)
            {
                context.Dimensions = new List<Dimension>(this.Dimension);
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
                context.Statistics = new List<String>(this.Statistic);
            }
            context.Unit = this.Unit;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new GetMetricStatisticsRequest();
            
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
                var response = client.GetMetricStatistics(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<Dimension> Dimensions { get; set; }
            public DateTime? EndTime { get; set; }
            public String MetricName { get; set; }
            public String Namespace { get; set; }
            public Int32? Period { get; set; }
            public DateTime? StartTime { get; set; }
            public List<String> Statistics { get; set; }
            public StandardUnit Unit { get; set; }
        }
        
    }
}
