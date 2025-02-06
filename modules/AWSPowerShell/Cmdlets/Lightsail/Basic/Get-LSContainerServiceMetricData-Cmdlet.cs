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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Returns the data points of a specific metric of your Amazon Lightsail container service.
    /// 
    ///  
    /// <para>
    /// Metrics report the utilization of your resources. Monitor and collect metric data
    /// regularly to maintain the reliability, availability, and performance of your resources.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "LSContainerServiceMetricData")]
    [OutputType("Amazon.Lightsail.Model.GetContainerServiceMetricDataResponse")]
    [AWSCmdlet("Calls the Amazon Lightsail GetContainerServiceMetricData API operation.", Operation = new[] {"GetContainerServiceMetricData"}, SelectReturnType = typeof(Amazon.Lightsail.Model.GetContainerServiceMetricDataResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.GetContainerServiceMetricDataResponse",
        "This cmdlet returns an Amazon.Lightsail.Model.GetContainerServiceMetricDataResponse object containing multiple properties."
    )]
    public partial class GetLSContainerServiceMetricDataCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// <para>The metric for which you want to return information.</para><para>Valid container service metric names are listed below, along with the most useful
        /// statistics to include in your request, and the published unit value.</para><ul><li><para><c>CPUUtilization</c> - The average percentage of compute units that are currently
        /// in use across all nodes of the container service. This metric identifies the processing
        /// power required to run containers on each node of the container service.</para><para>Statistics: The most useful statistics are <c>Maximum</c> and <c>Average</c>.</para><para>Unit: The published unit is <c>Percent</c>.</para></li><li><para><c>MemoryUtilization</c> - The average percentage of available memory that is currently
        /// in use across all nodes of the container service. This metric identifies the memory
        /// required to run containers on each node of the container service.</para><para>Statistics: The most useful statistics are <c>Maximum</c> and <c>Average</c>.</para><para>Unit: The published unit is <c>Percent</c>.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Lightsail.ContainerServiceMetricName")]
        public Amazon.Lightsail.ContainerServiceMetricName MetricName { get; set; }
        #endregion
        
        #region Parameter Period
        /// <summary>
        /// <para>
        /// <para>The granularity, in seconds, of the returned data points.</para><para>All container service metric data is available in 5-minute (300 seconds) granularity.</para>
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
        
        #region Parameter ServiceName
        /// <summary>
        /// <para>
        /// <para>The name of the container service for which to get metric data.</para>
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
        public System.String ServiceName { get; set; }
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
        /// use this statistic to determine the total volume of a metric.</para></li><li><para><c>Average</c> - The value of <c>Sum</c> / <c>SampleCount</c> during the specified
        /// period. By comparing this statistic with the <c>Minimum</c> and <c>Maximum</c> values,
        /// you can determine the full scope of a metric and how close the average use is to the
        /// <c>Minimum</c> and <c>Maximum</c> values. This comparison helps you to know when to
        /// increase or decrease your resources.</para></li><li><para><c>SampleCount</c> - The count, or number, of data points used for the statistical
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.GetContainerServiceMetricDataResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.GetContainerServiceMetricDataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.GetContainerServiceMetricDataResponse, GetLSContainerServiceMetricDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndTime = this.EndTime;
            #if MODULAR
            if (this.EndTime == null && ParameterWasBound(nameof(this.EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            context.ServiceName = this.ServiceName;
            #if MODULAR
            if (this.ServiceName == null && ParameterWasBound(nameof(this.ServiceName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Lightsail.Model.GetContainerServiceMetricDataRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.MetricName != null)
            {
                request.MetricName = cmdletContext.MetricName;
            }
            if (cmdletContext.Period != null)
            {
                request.Period = cmdletContext.Period.Value;
            }
            if (cmdletContext.ServiceName != null)
            {
                request.ServiceName = cmdletContext.ServiceName;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.Statistic != null)
            {
                request.Statistics = cmdletContext.Statistic;
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
        
        private Amazon.Lightsail.Model.GetContainerServiceMetricDataResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.GetContainerServiceMetricDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "GetContainerServiceMetricData");
            try
            {
                #if DESKTOP
                return client.GetContainerServiceMetricData(request);
                #elif CORECLR
                return client.GetContainerServiceMetricDataAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Lightsail.ContainerServiceMetricName MetricName { get; set; }
            public System.Int32? Period { get; set; }
            public System.String ServiceName { get; set; }
            public System.DateTime? StartTime { get; set; }
            public List<System.String> Statistic { get; set; }
            public System.Func<Amazon.Lightsail.Model.GetContainerServiceMetricDataResponse, GetLSContainerServiceMetricDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
