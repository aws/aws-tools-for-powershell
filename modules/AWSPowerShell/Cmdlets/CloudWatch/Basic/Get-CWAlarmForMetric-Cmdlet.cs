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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// Retrieves the alarms for the specified metric. To filter the results, specify a statistic,
    /// period, or unit.
    /// 
    ///  
    /// <para>
    /// This operation retrieves only standard alarms that are based on the specified metric.
    /// It does not return alarms based on math expressions that use the specified metric,
    /// or composite alarms that use the specified metric.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CWAlarmForMetric")]
    [OutputType("Amazon.CloudWatch.Model.MetricAlarm")]
    [AWSCmdlet("Calls the Amazon CloudWatch DescribeAlarmsForMetric API operation.", Operation = new[] {"DescribeAlarmsForMetric"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.DescribeAlarmsForMetricResponse))]
    [AWSCmdletOutput("Amazon.CloudWatch.Model.MetricAlarm or Amazon.CloudWatch.Model.DescribeAlarmsForMetricResponse",
        "This cmdlet returns a collection of Amazon.CloudWatch.Model.MetricAlarm objects.",
        "The service call response (type Amazon.CloudWatch.Model.DescribeAlarmsForMetricResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWAlarmForMetricCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Dimension
        /// <summary>
        /// <para>
        /// <para>The dimensions associated with the metric. If the metric has any associated dimensions,
        /// you must specify them in order for the call to succeed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Dimensions")]
        public Amazon.CloudWatch.Model.Dimension[] Dimension { get; set; }
        #endregion
        
        #region Parameter ExtendedStatistic
        /// <summary>
        /// <para>
        /// <para>The percentile statistic for the metric. Specify a value between p0.0 and p100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExtendedStatistic { get; set; }
        #endregion
        
        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// <para>The name of the metric.</para>
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
        public System.String MetricName { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the metric.</para>
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
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter Period
        /// <summary>
        /// <para>
        /// <para>The period, in seconds, over which the statistic is applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Period { get; set; }
        #endregion
        
        #region Parameter Statistic
        /// <summary>
        /// <para>
        /// <para>The statistic for the metric, other than percentiles. For percentile statistics, use
        /// <c>ExtendedStatistics</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatch.Statistic")]
        public Amazon.CloudWatch.Statistic Statistic { get; set; }
        #endregion
        
        #region Parameter Unit
        /// <summary>
        /// <para>
        /// <para>The unit for the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatch.StandardUnit")]
        public Amazon.CloudWatch.StandardUnit Unit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MetricAlarms'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.DescribeAlarmsForMetricResponse).
        /// Specifying the name of a property of type Amazon.CloudWatch.Model.DescribeAlarmsForMetricResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MetricAlarms";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MetricName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MetricName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MetricName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.DescribeAlarmsForMetricResponse, GetCWAlarmForMetricCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MetricName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Dimension != null)
            {
                context.Dimension = new List<Amazon.CloudWatch.Model.Dimension>(this.Dimension);
            }
            context.ExtendedStatistic = this.ExtendedStatistic;
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
            context.Statistic = this.Statistic;
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
            var request = new Amazon.CloudWatch.Model.DescribeAlarmsForMetricRequest();
            
            if (cmdletContext.Dimension != null)
            {
                request.Dimensions = cmdletContext.Dimension;
            }
            if (cmdletContext.ExtendedStatistic != null)
            {
                request.ExtendedStatistic = cmdletContext.ExtendedStatistic;
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
            if (cmdletContext.Statistic != null)
            {
                request.Statistic = cmdletContext.Statistic;
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
        
        private Amazon.CloudWatch.Model.DescribeAlarmsForMetricResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.DescribeAlarmsForMetricRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "DescribeAlarmsForMetric");
            try
            {
                #if DESKTOP
                return client.DescribeAlarmsForMetric(request);
                #elif CORECLR
                return client.DescribeAlarmsForMetricAsync(request).GetAwaiter().GetResult();
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
            public System.String ExtendedStatistic { get; set; }
            public System.String MetricName { get; set; }
            public System.String Namespace { get; set; }
            public System.Int32? Period { get; set; }
            public Amazon.CloudWatch.Statistic Statistic { get; set; }
            public Amazon.CloudWatch.StandardUnit Unit { get; set; }
            public System.Func<Amazon.CloudWatch.Model.DescribeAlarmsForMetricResponse, GetCWAlarmForMetricCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MetricAlarms;
        }
        
    }
}
