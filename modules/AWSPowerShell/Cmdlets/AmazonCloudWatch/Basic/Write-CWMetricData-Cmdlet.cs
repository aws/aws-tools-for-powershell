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
    /// Publishes metric data to Amazon CloudWatch. CloudWatch associates the data with the
    /// specified metric. If the specified metric does not exist, CloudWatch creates the metric.
    /// When CloudWatch creates a metric, it can take up to fifteen minutes for the metric
    /// to appear in calls to <a>ListMetrics</a>.
    /// 
    ///  
    /// <para>
    /// You can publish either individual data points in the <code>Value</code> field, or
    /// arrays of values and the number of times each value occurred during the period by
    /// using the <code>Values</code> and <code>Counts</code> fields in the <code>MetricDatum</code>
    /// structure. Using the <code>Values</code> and <code>Counts</code> method enables you
    /// to publish up to 150 values per metric with one <code>PutMetricData</code> request,
    /// and supports retrieving percentile statistics on this data.
    /// </para><para>
    /// Each <code>PutMetricData</code> request is limited to 40 KB in size for HTTP POST
    /// requests. You can send a payload compressed by gzip. Each request is also limited
    /// to no more than 20 different metrics.
    /// </para><para>
    /// Although the <code>Value</code> parameter accepts numbers of type <code>Double</code>,
    /// CloudWatch rejects values that are either too small or too large. Values must be in
    /// the range of 8.515920e-109 to 1.174271e+108 (Base 10) or 2e-360 to 2e360 (Base 2).
    /// In addition, special values (for example, NaN, +Infinity, -Infinity) are not supported.
    /// </para><para>
    /// You can use up to 10 dimensions per metric to further clarify what data the metric
    /// collects. For more information about specifying dimensions, see <a href="http://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/publishingMetrics.html">Publishing
    /// Metrics</a> in the <i>Amazon CloudWatch User Guide</i>.
    /// </para><para>
    /// Data points with time stamps from 24 hours ago or longer can take at least 48 hours
    /// to become available for <a>GetMetricData</a> or <a>GetMetricStatistics</a> from the
    /// time they are submitted.
    /// </para><para>
    /// CloudWatch needs raw data points to calculate percentile statistics. These raw data
    /// points could be published individually or as part of <code>Values</code> and <code>Counts</code>
    /// arrays. If you publish data using statistic sets in the <code>StatisticValues</code>
    /// field instead, you can only retrieve percentile statistics for this data if one of
    /// the following conditions is true:
    /// </para><ul><li><para>
    /// The <code>SampleCount</code> value of the statistic set is 1 and <code>Min</code>,
    /// <code>Max</code>, and <code>Sum</code> are all equal.
    /// </para></li><li><para>
    /// The <code>Min</code> and <code>Max</code> are equal, and <code>Sum</code> is equal
    /// to <code>Min</code> multiplied by <code>SampleCount</code>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Write", "CWMetricData", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon CloudWatch PutMetricData API operation.", Operation = new[] {"PutMetricData"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the Namespace parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.CloudWatch.Model.PutMetricDataResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCWMetricDataCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        #region Parameter MetricData
        /// <summary>
        /// <para>
        /// <para>The data for the metric. The array can include no more than 20 metrics per call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public Amazon.CloudWatch.Model.MetricDatum[] MetricData { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace for the metric data.</para><para>You cannot specify a namespace that begins with "AWS/". Namespaces that begin with
        /// "AWS/" are reserved for use by Amazon Web Services products.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the Namespace parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Namespace", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWMetricData (PutMetricData)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.MetricData != null)
            {
                context.MetricData = new List<Amazon.CloudWatch.Model.MetricDatum>(this.MetricData);
            }
            context.Namespace = this.Namespace;
            
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
            var request = new Amazon.CloudWatch.Model.PutMetricDataRequest();
            
            if (cmdletContext.MetricData != null)
            {
                request.MetricData = cmdletContext.MetricData;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.Namespace;
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
        
        private Amazon.CloudWatch.Model.PutMetricDataResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.PutMetricDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "PutMetricData");
            try
            {
                #if DESKTOP
                return client.PutMetricData(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutMetricDataAsync(request);
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
            public List<Amazon.CloudWatch.Model.MetricDatum> MetricData { get; set; }
            public System.String Namespace { get; set; }
        }
        
    }
}
