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
    /// Publishes metric data points to Amazon CloudWatch. CloudWatch associates the data
    /// points with the specified metric. If the specified metric does not exist, CloudWatch
    /// creates the metric. When CloudWatch creates a metric, it can take up to fifteen minutes
    /// for the metric to appear in calls to <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_ListMetrics.html">ListMetrics</a>.
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
    /// Each <code>PutMetricData</code> request is limited to 1 MB in size for HTTP POST requests.
    /// You can send a payload compressed by gzip. Each request is also limited to no more
    /// than 1000 different metrics.
    /// </para><para>
    /// Although the <code>Value</code> parameter accepts numbers of type <code>Double</code>,
    /// CloudWatch rejects values that are either too small or too large. Values must be in
    /// the range of -2^360 to 2^360. In addition, special values (for example, NaN, +Infinity,
    /// -Infinity) are not supported.
    /// </para><para>
    /// You can use up to 30 dimensions per metric to further clarify what data the metric
    /// collects. Each dimension consists of a Name and Value pair. For more information about
    /// specifying dimensions, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/publishingMetrics.html">Publishing
    /// Metrics</a> in the <i>Amazon CloudWatch User Guide</i>.
    /// </para><para>
    /// You specify the time stamp to be associated with each data point. You can specify
    /// time stamps that are as much as two weeks before the current date, and as much as
    /// 2 hours after the current day and time.
    /// </para><para>
    /// Data points with time stamps from 24 hours ago or longer can take at least 48 hours
    /// to become available for <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_GetMetricData.html">GetMetricData</a>
    /// or <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_GetMetricStatistics.html">GetMetricStatistics</a>
    /// from the time they are submitted. Data points with time stamps between 3 and 24 hours
    /// ago can take as much as 2 hours to become available for for <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_GetMetricData.html">GetMetricData</a>
    /// or <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_GetMetricStatistics.html">GetMetricStatistics</a>.
    /// </para><para>
    /// CloudWatch needs raw data points to calculate percentile statistics. If you publish
    /// data using a statistic set instead, you can only retrieve percentile statistics for
    /// this data if one of the following conditions is true:
    /// </para><ul><li><para>
    /// The <code>SampleCount</code> value of the statistic set is 1 and <code>Min</code>,
    /// <code>Max</code>, and <code>Sum</code> are all equal.
    /// </para></li><li><para>
    /// The <code>Min</code> and <code>Max</code> are equal, and <code>Sum</code> is equal
    /// to <code>Min</code> multiplied by <code>SampleCount</code>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Write", "CWMetricData", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon CloudWatch PutMetricData API operation.", Operation = new[] {"PutMetricData"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.PutMetricDataResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatch.Model.PutMetricDataResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatch.Model.PutMetricDataResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCWMetricDataCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        #region Parameter MetricData
        /// <summary>
        /// <para>
        /// <para>The data for the metric. The array can include no more than 1000 metrics per call.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.CloudWatch.Model.MetricDatum[] MetricData { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace for the metric data. You can use ASCII characters for the namespace,
        /// except for control characters which are not supported.</para><para>To avoid conflicts with Amazon Web Services service namespaces, you should not specify
        /// a namespace that begins with <code>AWS/</code></para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.PutMetricDataResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Namespace), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWMetricData (PutMetricData)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.PutMetricDataResponse, WriteCWMetricDataCmdlet>(Select) ??
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
            if (this.MetricData != null)
            {
                context.MetricData = new List<Amazon.CloudWatch.Model.MetricDatum>(this.MetricData);
            }
            #if MODULAR
            if (this.MetricData == null && ParameterWasBound(nameof(this.MetricData)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricData which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Namespace = this.Namespace;
            #if MODULAR
            if (this.Namespace == null && ParameterWasBound(nameof(this.Namespace)))
            {
                WriteWarning("You are passing $null as a value for parameter Namespace which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
        
        private Amazon.CloudWatch.Model.PutMetricDataResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.PutMetricDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "PutMetricData");
            try
            {
                #if DESKTOP
                return client.PutMetricData(request);
                #elif CORECLR
                return client.PutMetricDataAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.CloudWatch.Model.PutMetricDataResponse, WriteCWMetricDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
