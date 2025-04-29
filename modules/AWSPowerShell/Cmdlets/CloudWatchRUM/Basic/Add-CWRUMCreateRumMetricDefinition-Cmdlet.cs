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
using Amazon.CloudWatchRUM;
using Amazon.CloudWatchRUM.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWRUM
{
    /// <summary>
    /// Specifies the extended metrics and custom metrics that you want a CloudWatch RUM app
    /// monitor to send to a destination. Valid destinations include CloudWatch and Evidently.
    /// 
    ///  
    /// <para>
    /// By default, RUM app monitors send some metrics to CloudWatch. These default metrics
    /// are listed in <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch-RUM-metrics.html">CloudWatch
    /// metrics that you can collect with CloudWatch RUM</a>.
    /// </para><para>
    /// In addition to these default metrics, you can choose to send extended metrics, custom
    /// metrics, or both.
    /// </para><ul><li><para>
    /// Extended metrics let you send metrics with additional dimensions that aren't included
    /// in the default metrics. You can also send extended metrics to both Evidently and CloudWatch.
    /// The valid dimension names for the additional dimensions for extended metrics are <c>BrowserName</c>,
    /// <c>CountryCode</c>, <c>DeviceType</c>, <c>FileType</c>, <c>OSName</c>, and <c>PageId</c>.
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch-RUM-vended-metrics.html">
    /// Extended metrics that you can send to CloudWatch and CloudWatch Evidently</a>.
    /// </para></li><li><para>
    /// Custom metrics are metrics that you define. You can send custom metrics to CloudWatch.
    /// CloudWatch Evidently, or both. With custom metrics, you can use any metric name and
    /// namespace. To derive the metrics, you can use any custom events, built-in events,
    /// custom attributes, or default attributes. 
    /// </para><para>
    /// You can't send custom metrics to the <c>AWS/RUM</c> namespace. You must send custom
    /// metrics to a custom namespace that you define. The namespace that you use can't start
    /// with <c>AWS/</c>. CloudWatch RUM prepends <c>RUM/CustomMetrics/</c> to the custom
    /// namespace that you define, so the final namespace for your metrics in CloudWatch is
    /// <c>RUM/CustomMetrics/<i>your-custom-namespace</i></c>.
    /// </para></li></ul><para>
    /// The maximum number of metric definitions that you can specify in one <c>BatchCreateRumMetricDefinitions</c>
    /// operation is 200.
    /// </para><para>
    /// The maximum number of metric definitions that one destination can contain is 2000.
    /// </para><para>
    /// Extended metrics sent to CloudWatch and RUM custom metrics are charged as CloudWatch
    /// custom metrics. Each combination of additional dimension name and dimension value
    /// counts as a custom metric. For more information, see <a href="https://aws.amazon.com/cloudwatch/pricing/">Amazon
    /// CloudWatch Pricing</a>.
    /// </para><para>
    /// You must have already created a destination for the metrics before you send them.
    /// For more information, see <a href="https://docs.aws.amazon.com/cloudwatchrum/latest/APIReference/API_PutRumMetricsDestination.html">PutRumMetricsDestination</a>.
    /// </para><para>
    /// If some metric definitions specified in a <c>BatchCreateRumMetricDefinitions</c> operations
    /// are not valid, those metric definitions fail and return errors, but all valid metric
    /// definitions in the same operation still succeed.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "CWRUMCreateRumMetricDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchRUM.Model.BatchCreateRumMetricDefinitionsResponse")]
    [AWSCmdlet("Calls the CloudWatch RUM BatchCreateRumMetricDefinitions API operation.", Operation = new[] {"BatchCreateRumMetricDefinitions"}, SelectReturnType = typeof(Amazon.CloudWatchRUM.Model.BatchCreateRumMetricDefinitionsResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchRUM.Model.BatchCreateRumMetricDefinitionsResponse",
        "This cmdlet returns an Amazon.CloudWatchRUM.Model.BatchCreateRumMetricDefinitionsResponse object containing multiple properties."
    )]
    public partial class AddCWRUMCreateRumMetricDefinitionCmdlet : AmazonCloudWatchRUMClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AppMonitorName
        /// <summary>
        /// <para>
        /// <para>The name of the CloudWatch RUM app monitor that is to send the metrics.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AppMonitorName { get; set; }
        #endregion
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para>The destination to send the metrics to. Valid values are <c>CloudWatch</c> and <c>Evidently</c>.
        /// If you specify <c>Evidently</c>, you must also specify the Amazon Resource Name (ARN)
        /// of the CloudWatchEvidently experiment that will receive the metrics and an IAM role
        /// that has permission to write to the experiment.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudWatchRUM.MetricDestination")]
        public Amazon.CloudWatchRUM.MetricDestination Destination { get; set; }
        #endregion
        
        #region Parameter DestinationArn
        /// <summary>
        /// <para>
        /// <para>This parameter is required if <c>Destination</c> is <c>Evidently</c>. If <c>Destination</c>
        /// is <c>CloudWatch</c>, do not use this parameter.</para><para>This parameter specifies the ARN of the Evidently experiment that is to receive the
        /// metrics. You must have already defined this experiment as a valid destination. For
        /// more information, see <a href="https://docs.aws.amazon.com/cloudwatchrum/latest/APIReference/API_PutRumMetricsDestination.html">PutRumMetricsDestination</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationArn { get; set; }
        #endregion
        
        #region Parameter MetricDefinition
        /// <summary>
        /// <para>
        /// <para>An array of structures which define the metrics that you want to send.</para>
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
        [Alias("MetricDefinitions")]
        public Amazon.CloudWatchRUM.Model.MetricDefinitionRequest[] MetricDefinition { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchRUM.Model.BatchCreateRumMetricDefinitionsResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchRUM.Model.BatchCreateRumMetricDefinitionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppMonitorName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-CWRUMCreateRumMetricDefinition (BatchCreateRumMetricDefinitions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchRUM.Model.BatchCreateRumMetricDefinitionsResponse, AddCWRUMCreateRumMetricDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppMonitorName = this.AppMonitorName;
            #if MODULAR
            if (this.AppMonitorName == null && ParameterWasBound(nameof(this.AppMonitorName)))
            {
                WriteWarning("You are passing $null as a value for parameter AppMonitorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Destination = this.Destination;
            #if MODULAR
            if (this.Destination == null && ParameterWasBound(nameof(this.Destination)))
            {
                WriteWarning("You are passing $null as a value for parameter Destination which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DestinationArn = this.DestinationArn;
            if (this.MetricDefinition != null)
            {
                context.MetricDefinition = new List<Amazon.CloudWatchRUM.Model.MetricDefinitionRequest>(this.MetricDefinition);
            }
            #if MODULAR
            if (this.MetricDefinition == null && ParameterWasBound(nameof(this.MetricDefinition)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricDefinition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchRUM.Model.BatchCreateRumMetricDefinitionsRequest();
            
            if (cmdletContext.AppMonitorName != null)
            {
                request.AppMonitorName = cmdletContext.AppMonitorName;
            }
            if (cmdletContext.Destination != null)
            {
                request.Destination = cmdletContext.Destination;
            }
            if (cmdletContext.DestinationArn != null)
            {
                request.DestinationArn = cmdletContext.DestinationArn;
            }
            if (cmdletContext.MetricDefinition != null)
            {
                request.MetricDefinitions = cmdletContext.MetricDefinition;
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
        
        private Amazon.CloudWatchRUM.Model.BatchCreateRumMetricDefinitionsResponse CallAWSServiceOperation(IAmazonCloudWatchRUM client, Amazon.CloudWatchRUM.Model.BatchCreateRumMetricDefinitionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch RUM", "BatchCreateRumMetricDefinitions");
            try
            {
                return client.BatchCreateRumMetricDefinitionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AppMonitorName { get; set; }
            public Amazon.CloudWatchRUM.MetricDestination Destination { get; set; }
            public System.String DestinationArn { get; set; }
            public List<Amazon.CloudWatchRUM.Model.MetricDefinitionRequest> MetricDefinition { get; set; }
            public System.Func<Amazon.CloudWatchRUM.Model.BatchCreateRumMetricDefinitionsResponse, AddCWRUMCreateRumMetricDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
