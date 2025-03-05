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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Returns the data points for the specified Amazon Lightsail instance metric, given
    /// an instance name.
    /// 
    ///  
    /// <para>
    /// Metrics report the utilization of your resources, and the error counts generated by
    /// them. Monitor and collect metric data regularly to maintain the reliability, availability,
    /// and performance of your resources.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "LSInstanceMetricData")]
    [OutputType("Amazon.Lightsail.Model.GetInstanceMetricDataResponse")]
    [AWSCmdlet("Calls the Amazon Lightsail GetInstanceMetricData API operation.", Operation = new[] {"GetInstanceMetricData"}, SelectReturnType = typeof(Amazon.Lightsail.Model.GetInstanceMetricDataResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.GetInstanceMetricDataResponse",
        "This cmdlet returns an Amazon.Lightsail.Model.GetInstanceMetricDataResponse object containing multiple properties."
    )]
    public partial class GetLSInstanceMetricDataCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The end time of the time period.</para>
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
        
        #region Parameter InstanceName
        /// <summary>
        /// <para>
        /// <para>The name of the instance for which you want to get metrics data.</para>
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
        public System.String InstanceName { get; set; }
        #endregion
        
        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// <para>The metric for which you want to return information.</para><para>Valid instance metric names are listed below, along with the most useful <c>statistics</c>
        /// to include in your request, and the published <c>unit</c> value.</para><ul><li><para><b><c>BurstCapacityPercentage</c></b> - The percentage of CPU performance available
        /// for your instance to burst above its baseline. Your instance continuously accrues
        /// and consumes burst capacity. Burst capacity stops accruing when your instance's <c>BurstCapacityPercentage</c>
        /// reaches 100%. For more information, see <a href="https://docs.aws.amazon.com/lightsail/latest/userguide/amazon-lightsail-viewing-instance-burst-capacity">Viewing
        /// instance burst capacity in Amazon Lightsail</a>.</para><para><c>Statistics</c>: The most useful statistics are <c>Maximum</c> and <c>Average</c>.</para><para><c>Unit</c>: The published unit is <c>Percent</c>.</para></li><li><para><b><c>BurstCapacityTime</c></b> - The available amount of time for your instance
        /// to burst at 100% CPU utilization. Your instance continuously accrues and consumes
        /// burst capacity. Burst capacity time stops accruing when your instance's <c>BurstCapacityPercentage</c>
        /// metric reaches 100%.</para><para>Burst capacity time is consumed at the full rate only when your instance operates
        /// at 100% CPU utilization. For example, if your instance operates at 50% CPU utilization
        /// in the burstable zone for a 5-minute period, then it consumes CPU burst capacity minutes
        /// at a 50% rate in that period. Your instance consumed 2 minutes and 30 seconds of CPU
        /// burst capacity minutes in the 5-minute period. For more information, see <a href="https://docs.aws.amazon.com/lightsail/latest/userguide/amazon-lightsail-viewing-instance-burst-capacity">Viewing
        /// instance burst capacity in Amazon Lightsail</a>.</para><para><c>Statistics</c>: The most useful statistics are <c>Maximum</c> and <c>Average</c>.</para><para><c>Unit</c>: The published unit is <c>Seconds</c>.</para></li><li><para><b><c>CPUUtilization</c></b> - The percentage of allocated compute units that are
        /// currently in use on the instance. This metric identifies the processing power to run
        /// the applications on the instance. Tools in your operating system can show a lower
        /// percentage than Lightsail when the instance is not allocated a full processor core.</para><para><c>Statistics</c>: The most useful statistics are <c>Maximum</c> and <c>Average</c>.</para><para><c>Unit</c>: The published unit is <c>Percent</c>.</para></li><li><para><b><c>NetworkIn</c></b> - The number of bytes received on all network interfaces
        /// by the instance. This metric identifies the volume of incoming network traffic to
        /// the instance. The number reported is the number of bytes received during the period.
        /// Because this metric is reported in 5-minute intervals, divide the reported number
        /// by 300 to find Bytes/second.</para><para><c>Statistics</c>: The most useful statistic is <c>Sum</c>.</para><para><c>Unit</c>: The published unit is <c>Bytes</c>.</para></li><li><para><b><c>NetworkOut</c></b> - The number of bytes sent out on all network interfaces
        /// by the instance. This metric identifies the volume of outgoing network traffic from
        /// the instance. The number reported is the number of bytes sent during the period. Because
        /// this metric is reported in 5-minute intervals, divide the reported number by 300 to
        /// find Bytes/second.</para><para><c>Statistics</c>: The most useful statistic is <c>Sum</c>.</para><para><c>Unit</c>: The published unit is <c>Bytes</c>.</para></li><li><para><b><c>StatusCheckFailed</c></b> - Reports whether the instance passed or failed
        /// both the instance status check and the system status check. This metric can be either
        /// 0 (passed) or 1 (failed). This metric data is available in 1-minute (60 seconds) granularity.</para><para><c>Statistics</c>: The most useful statistic is <c>Sum</c>.</para><para><c>Unit</c>: The published unit is <c>Count</c>.</para></li><li><para><b><c>StatusCheckFailed_Instance</c></b> - Reports whether the instance passed
        /// or failed the instance status check. This metric can be either 0 (passed) or 1 (failed).
        /// This metric data is available in 1-minute (60 seconds) granularity.</para><para><c>Statistics</c>: The most useful statistic is <c>Sum</c>.</para><para><c>Unit</c>: The published unit is <c>Count</c>.</para></li><li><para><b><c>StatusCheckFailed_System</c></b> - Reports whether the instance passed or
        /// failed the system status check. This metric can be either 0 (passed) or 1 (failed).
        /// This metric data is available in 1-minute (60 seconds) granularity.</para><para><c>Statistics</c>: The most useful statistic is <c>Sum</c>.</para><para><c>Unit</c>: The published unit is <c>Count</c>.</para></li><li><para><b><c>MetadataNoToken</c></b> - Reports the number of times that the instance metadata
        /// service was successfully accessed without a token. This metric determines if there
        /// are any processes accessing instance metadata by using Instance Metadata Service Version
        /// 1, which doesn't use a token. If all requests use token-backed sessions, such as Instance
        /// Metadata Service Version 2, then the value is 0.</para><para><c>Statistics</c>: The most useful statistic is <c>Sum</c>.</para><para><c>Unit</c>: The published unit is <c>Count</c>.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Lightsail.InstanceMetricName")]
        public Amazon.Lightsail.InstanceMetricName MetricName { get; set; }
        #endregion
        
        #region Parameter Period
        /// <summary>
        /// <para>
        /// <para>The granularity, in seconds, of the returned data points.</para><para>The <c>StatusCheckFailed</c>, <c>StatusCheckFailed_Instance</c>, and <c>StatusCheckFailed_System</c>
        /// instance metric data is available in 1-minute (60 seconds) granularity. All other
        /// instance metric data is available in 5-minute (300 seconds) granularity.</para>
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
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The start time of the time period.</para>
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
        
        #region Parameter Statistic
        /// <summary>
        /// <para>
        /// <para>The statistic for the metric.</para><para>The following statistics are available:</para><ul><li><para><c>Minimum</c> - The lowest value observed during the specified period. Use this
        /// value to determine low volumes of activity for your application.</para></li><li><para><c>Maximum</c> - The highest value observed during the specified period. Use this
        /// value to determine high volumes of activity for your application.</para></li><li><para><c>Sum</c> - All values submitted for the matching metric added together. You can
        /// use this statistic to determine the total volume of a metric.</para></li><li><para><c>Average</c> - The value of Sum / SampleCount during the specified period. By comparing
        /// this statistic with the Minimum and Maximum values, you can determine the full scope
        /// of a metric and how close the average use is to the Minimum and Maximum values. This
        /// comparison helps you to know when to increase or decrease your resources.</para></li><li><para><c>SampleCount</c> - The count, or number, of data points used for the statistical
        /// calculation.</para></li></ul>
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
        [Alias("Statistics")]
        public System.String[] Statistic { get; set; }
        #endregion
        
        #region Parameter Unit
        /// <summary>
        /// <para>
        /// <para>The unit for the metric data request. Valid units depend on the metric data being
        /// requested. For the valid units to specify with each available metric, see the <c>metricName</c>
        /// parameter.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Lightsail.MetricUnit")]
        public Amazon.Lightsail.MetricUnit Unit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.GetInstanceMetricDataResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.GetInstanceMetricDataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.GetInstanceMetricDataResponse, GetLSInstanceMetricDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndTime = this.EndTime;
            #if MODULAR
            if (this.EndTime == null && ParameterWasBound(nameof(this.EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceName = this.InstanceName;
            #if MODULAR
            if (this.InstanceName == null && ParameterWasBound(nameof(this.InstanceName)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetricName = this.MetricName;
            #if MODULAR
            if (this.MetricName == null && ParameterWasBound(nameof(this.MetricName)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Period = this.Period;
            #if MODULAR
            if (this.Period == null && ParameterWasBound(nameof(this.Period)))
            {
                WriteWarning("You are passing $null as a value for parameter Period which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartTime = this.StartTime;
            #if MODULAR
            if (this.StartTime == null && ParameterWasBound(nameof(this.StartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter StartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Statistic != null)
            {
                context.Statistic = new List<System.String>(this.Statistic);
            }
            #if MODULAR
            if (this.Statistic == null && ParameterWasBound(nameof(this.Statistic)))
            {
                WriteWarning("You are passing $null as a value for parameter Statistic which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Unit = this.Unit;
            #if MODULAR
            if (this.Unit == null && ParameterWasBound(nameof(this.Unit)))
            {
                WriteWarning("You are passing $null as a value for parameter Unit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Lightsail.Model.GetInstanceMetricDataRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.InstanceName != null)
            {
                request.InstanceName = cmdletContext.InstanceName;
            }
            if (cmdletContext.MetricName != null)
            {
                request.MetricName = cmdletContext.MetricName;
            }
            if (cmdletContext.Period != null)
            {
                request.Period = cmdletContext.Period.Value;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.Statistic != null)
            {
                request.Statistics = cmdletContext.Statistic;
            }
            if (cmdletContext.Unit != null)
            {
                request.Unit = cmdletContext.Unit;
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
        
        private Amazon.Lightsail.Model.GetInstanceMetricDataResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.GetInstanceMetricDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "GetInstanceMetricData");
            try
            {
                return client.GetInstanceMetricDataAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String InstanceName { get; set; }
            public Amazon.Lightsail.InstanceMetricName MetricName { get; set; }
            public System.Int32? Period { get; set; }
            public System.DateTime? StartTime { get; set; }
            public List<System.String> Statistic { get; set; }
            public Amazon.Lightsail.MetricUnit Unit { get; set; }
            public System.Func<Amazon.Lightsail.Model.GetInstanceMetricDataResponse, GetLSInstanceMetricDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
