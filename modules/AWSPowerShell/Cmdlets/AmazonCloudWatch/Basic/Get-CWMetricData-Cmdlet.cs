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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// You can use the <code>GetMetricData</code> API to retrieve as many as 100 different
    /// metrics in a single request, with a total of as many as 100,800 datapoints. You can
    /// also optionally perform math expressions on the values of the returned statistics,
    /// to create new time series that represent new insights into your data. For example,
    /// using Lambda metrics, you could divide the Errors metric by the Invocations metric
    /// to get an error rate time series. For more information about metric math expressions,
    /// see <a href="http://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/using-metric-math.html#metric-math-syntax">Metric
    /// Math Syntax and Functions</a> in the <i>Amazon CloudWatch User Guide</i>.
    /// 
    ///  
    /// <para>
    /// Calls to the <code>GetMetricData</code> API have a different pricing structure than
    /// calls to <code>GetMetricStatistics</code>. For more information about pricing, see
    /// <a href="https://aws.amazon.com/cloudwatch/pricing/">Amazon CloudWatch Pricing</a>.
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
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CWMetricData")]
    [OutputType("Amazon.CloudWatch.Model.MetricDataResult")]
    [AWSCmdlet("Calls the Amazon CloudWatch GetMetricData API operation.", Operation = new[] {"GetMetricData"})]
    [AWSCmdletOutput("Amazon.CloudWatch.Model.MetricDataResult",
        "This cmdlet returns a collection of MetricDataResult objects.",
        "The service call response (type Amazon.CloudWatch.Model.GetMetricDataResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetCWMetricDataCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use EndTimeUtc instead. Setting either EndTime or EndTimeUtc
        /// results in both EndTime and EndTimeUtc being assigned, the latest assignment to either
        /// one of the two property is reflected in the value of both. EndTime is provided for
        /// backwards compatibility only and assigning a non-Utc DateTime to it results in the
        /// wrong timestamp being passed to the service.</para><para>The time stamp indicating the latest data to be returned.</para><para>For better performance, specify <code>StartTime</code> and <code>EndTime</code> values
        /// that align with the value of the metric's <code>Period</code> and sync up with the
        /// beginning and end of an hour. For example, if the <code>Period</code> of a metric
        /// is 5 minutes, specifying 12:05 or 12:30 as <code>EndTime</code> can get a faster response
        /// from CloudWatch then setting 12:07 or 12:29 as the <code>EndTime</code>.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed t" +
            "o the service, use UtcEndTime instead.")]
        public System.DateTime EndTime { get; set; }
        #endregion
        
        #region Parameter UtcEndTime
        /// <summary>
        /// <para>
        /// <para>The time stamp indicating the latest data to be returned.</para><para>For better performance, specify <code>StartTime</code> and <code>EndTime</code> values
        /// that align with the value of the metric's <code>Period</code> and sync up with the
        /// beginning and end of an hour. For example, if the <code>Period</code> of a metric
        /// is 5 minutes, specifying 12:05 or 12:30 as <code>EndTime</code> can get a faster response
        /// from CloudWatch then setting 12:07 or 12:29 as the <code>EndTime</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime UtcEndTime { get; set; }
        #endregion
        
        #region Parameter MaxDatapoint
        /// <summary>
        /// <para>
        /// <para>The maximum number of data points the request should return before paginating. If
        /// you omit this, the default of 100,800 is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxDatapoints")]
        public System.Int32 MaxDatapoint { get; set; }
        #endregion
        
        #region Parameter MetricDataQuery
        /// <summary>
        /// <para>
        /// <para>The metric queries to be returned. A single <code>GetMetricData</code> call can include
        /// as many as 100 <code>MetricDataQuery</code> structures. Each of these structures can
        /// specify either a metric to retrieve, or a math expression to perform on retrieved
        /// data. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MetricDataQueries")]
        public Amazon.CloudWatch.Model.MetricDataQuery[] MetricDataQuery { get; set; }
        #endregion
        
        #region Parameter ScanBy
        /// <summary>
        /// <para>
        /// <para>The order in which data points should be returned. <code>TimestampDescending</code>
        /// returns the newest data first and paginates when the <code>MaxDatapoints</code> limit
        /// is reached. <code>TimestampAscending</code> returns the oldest data first and paginates
        /// when the <code>MaxDatapoints</code> limit is reached.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CloudWatch.ScanBy")]
        public Amazon.CloudWatch.ScanBy ScanBy { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use StartTimeUtc instead. Setting either StartTime or
        /// StartTimeUtc results in both StartTime and StartTimeUtc being assigned, the latest
        /// assignment to either one of the two property is reflected in the value of both. StartTime
        /// is provided for backwards compatibility only and assigning a non-Utc DateTime to it
        /// results in the wrong timestamp being passed to the service.</para><para>The time stamp indicating the earliest data to be returned.</para><para>For better performance, specify <code>StartTime</code> and <code>EndTime</code> values
        /// that align with the value of the metric's <code>Period</code> and sync up with the
        /// beginning and end of an hour. For example, if the <code>Period</code> of a metric
        /// is 5 minutes, specifying 12:05 or 12:30 as <code>StartTime</code> can get a faster
        /// response from CloudWatch then setting 12:07 or 12:29 as the <code>StartTime</code>.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed t" +
            "o the service, use UtcStartTime instead.")]
        public System.DateTime StartTime { get; set; }
        #endregion
        
        #region Parameter UtcStartTime
        /// <summary>
        /// <para>
        /// <para>The time stamp indicating the earliest data to be returned.</para><para>For better performance, specify <code>StartTime</code> and <code>EndTime</code> values
        /// that align with the value of the metric's <code>Period</code> and sync up with the
        /// beginning and end of an hour. For example, if the <code>Period</code> of a metric
        /// is 5 minutes, specifying 12:05 or 12:30 as <code>StartTime</code> can get a faster
        /// response from CloudWatch then setting 12:07 or 12:29 as the <code>StartTime</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime UtcStartTime { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Include this value, if it was returned by the previous call, to get the next set of
        /// data points.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
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
            
            if (ParameterWasBound("UtcEndTime"))
                context.UtcEndTime = this.UtcEndTime;
            if (ParameterWasBound("MaxDatapoint"))
                context.MaxDatapoints = this.MaxDatapoint;
            if (this.MetricDataQuery != null)
            {
                context.MetricDataQueries = new List<Amazon.CloudWatch.Model.MetricDataQuery>(this.MetricDataQuery);
            }
            context.NextToken = this.NextToken;
            context.ScanBy = this.ScanBy;
            if (ParameterWasBound("UtcStartTime"))
                context.UtcStartTime = this.UtcStartTime;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound("EndTime"))
                context.EndTime = this.EndTime;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound("StartTime"))
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
            var request = new Amazon.CloudWatch.Model.GetMetricDataRequest();
            
            if (cmdletContext.UtcEndTime != null)
            {
                request.EndTimeUtc = cmdletContext.UtcEndTime.Value;
            }
            if (cmdletContext.MaxDatapoints != null)
            {
                request.MaxDatapoints = cmdletContext.MaxDatapoints.Value;
            }
            if (cmdletContext.MetricDataQueries != null)
            {
                request.MetricDataQueries = cmdletContext.MetricDataQueries;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ScanBy != null)
            {
                request.ScanBy = cmdletContext.ScanBy;
            }
            if (cmdletContext.UtcStartTime != null)
            {
                request.StartTimeUtc = cmdletContext.UtcStartTime.Value;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.EndTime != null)
            {
                if (cmdletContext.UtcEndTime != null)
                {
                    throw new ArgumentException("Parameters EndTime and UtcEndTime are mutually exclusive.");
                }
                request.EndTime = cmdletContext.EndTime.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.StartTime != null)
            {
                if (cmdletContext.UtcStartTime != null)
                {
                    throw new ArgumentException("Parameters StartTime and UtcStartTime are mutually exclusive.");
                }
                request.StartTime = cmdletContext.StartTime.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.MetricDataResults;
                notes = new Dictionary<string, object>();
                notes["NextToken"] = response.NextToken;
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
        
        private Amazon.CloudWatch.Model.GetMetricDataResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.GetMetricDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "GetMetricData");
            try
            {
                #if DESKTOP
                return client.GetMetricData(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetMetricDataAsync(request);
                return task.Result;
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
            public System.DateTime? UtcEndTime { get; set; }
            public System.Int32? MaxDatapoints { get; set; }
            public List<Amazon.CloudWatch.Model.MetricDataQuery> MetricDataQueries { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.CloudWatch.ScanBy ScanBy { get; set; }
            public System.DateTime? UtcStartTime { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? EndTime { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? StartTime { get; set; }
        }
        
    }
}
