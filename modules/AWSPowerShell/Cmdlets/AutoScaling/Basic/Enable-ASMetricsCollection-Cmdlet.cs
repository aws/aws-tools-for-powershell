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
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AS
{
    /// <summary>
    /// Enables group metrics collection for the specified Auto Scaling group.
    /// 
    ///  
    /// <para>
    /// You can use these metrics to track changes in an Auto Scaling group and to set alarms
    /// on threshold values. You can view group metrics using the Amazon EC2 Auto Scaling
    /// console or the CloudWatch console. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-cloudwatch-monitoring.html">Monitor
    /// CloudWatch metrics for your Auto Scaling groups and instances</a> in the <i>Amazon
    /// EC2 Auto Scaling User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Enable", "ASMetricsCollection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Auto Scaling EnableMetricsCollection API operation.", Operation = new[] {"EnableMetricsCollection"}, SelectReturnType = typeof(Amazon.AutoScaling.Model.EnableMetricsCollectionResponse))]
    [AWSCmdletOutput("None or Amazon.AutoScaling.Model.EnableMetricsCollectionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.AutoScaling.Model.EnableMetricsCollectionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EnableASMetricsCollectionCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AutoScalingGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the Auto Scaling group.</para>
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
        public System.String AutoScalingGroupName { get; set; }
        #endregion
        
        #region Parameter Granularity
        /// <summary>
        /// <para>
        /// <para>The frequency at which Amazon EC2 Auto Scaling sends aggregated data to CloudWatch.
        /// The only valid value is <c>1Minute</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Granularity { get; set; }
        #endregion
        
        #region Parameter Metric
        /// <summary>
        /// <para>
        /// <para>Identifies the metrics to enable.</para><para>You can specify one or more of the following metrics:</para><ul><li><para><c>GroupMinSize</c></para></li><li><para><c>GroupMaxSize</c></para></li><li><para><c>GroupDesiredCapacity</c></para></li><li><para><c>GroupInServiceInstances</c></para></li><li><para><c>GroupPendingInstances</c></para></li><li><para><c>GroupStandbyInstances</c></para></li><li><para><c>GroupTerminatingInstances</c></para></li><li><para><c>GroupTotalInstances</c></para></li><li><para><c>GroupInServiceCapacity</c></para></li><li><para><c>GroupPendingCapacity</c></para></li><li><para><c>GroupStandbyCapacity</c></para></li><li><para><c>GroupTerminatingCapacity</c></para></li><li><para><c>GroupTotalCapacity</c></para></li><li><para><c>WarmPoolDesiredCapacity</c></para></li><li><para><c>WarmPoolWarmedCapacity</c></para></li><li><para><c>WarmPoolPendingCapacity</c></para></li><li><para><c>WarmPoolTerminatingCapacity</c></para></li><li><para><c>WarmPoolTotalCapacity</c></para></li><li><para><c>GroupAndWarmPoolDesiredCapacity</c></para></li><li><para><c>GroupAndWarmPoolTotalCapacity</c></para></li></ul><para>If you specify <c>Granularity</c> and don't specify any metrics, all metrics are enabled.</para><para>For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/ec2-auto-scaling-metrics.html">Amazon
        /// CloudWatch metrics for Amazon EC2 Auto Scaling</a> in the <i>Amazon EC2 Auto Scaling
        /// User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("Metrics")]
        public System.String[] Metric { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AutoScaling.Model.EnableMetricsCollectionResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AutoScalingGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-ASMetricsCollection (EnableMetricsCollection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AutoScaling.Model.EnableMetricsCollectionResponse, EnableASMetricsCollectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            #if MODULAR
            if (this.AutoScalingGroupName == null && ParameterWasBound(nameof(this.AutoScalingGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoScalingGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Granularity = this.Granularity;
            #if MODULAR
            if (this.Granularity == null && ParameterWasBound(nameof(this.Granularity)))
            {
                WriteWarning("You are passing $null as a value for parameter Granularity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Metric != null)
            {
                context.Metric = new List<System.String>(this.Metric);
            }
            
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
            var request = new Amazon.AutoScaling.Model.EnableMetricsCollectionRequest();
            
            if (cmdletContext.AutoScalingGroupName != null)
            {
                request.AutoScalingGroupName = cmdletContext.AutoScalingGroupName;
            }
            if (cmdletContext.Granularity != null)
            {
                request.Granularity = cmdletContext.Granularity;
            }
            if (cmdletContext.Metric != null)
            {
                request.Metrics = cmdletContext.Metric;
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
        
        private Amazon.AutoScaling.Model.EnableMetricsCollectionResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.EnableMetricsCollectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Auto Scaling", "EnableMetricsCollection");
            try
            {
                #if DESKTOP
                return client.EnableMetricsCollection(request);
                #elif CORECLR
                return client.EnableMetricsCollectionAsync(request).GetAwaiter().GetResult();
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
            public System.String AutoScalingGroupName { get; set; }
            public System.String Granularity { get; set; }
            public List<System.String> Metric { get; set; }
            public System.Func<Amazon.AutoScaling.Model.EnableMetricsCollectionResponse, EnableASMetricsCollectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
