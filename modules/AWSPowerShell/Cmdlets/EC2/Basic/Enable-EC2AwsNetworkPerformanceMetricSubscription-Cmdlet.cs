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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Enables Infrastructure Performance subscriptions.
    /// </summary>
    [Cmdlet("Enable", "EC2AwsNetworkPerformanceMetricSubscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) EnableAwsNetworkPerformanceMetricSubscription API operation.", Operation = new[] {"EnableAwsNetworkPerformanceMetricSubscription"}, SelectReturnType = typeof(Amazon.EC2.Model.EnableAwsNetworkPerformanceMetricSubscriptionResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.EC2.Model.EnableAwsNetworkPerformanceMetricSubscriptionResponse",
        "This cmdlet returns a System.Boolean object.",
        "The service call response (type Amazon.EC2.Model.EnableAwsNetworkPerformanceMetricSubscriptionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EnableEC2AwsNetworkPerformanceMetricSubscriptionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para>The target Region (like <c>us-east-2</c>) or Availability Zone ID (like <c>use2-az2</c>)
        /// that the metric subscription is enabled for. If you use Availability Zone IDs, the
        /// Source and Destination Availability Zones must be in the same Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Destination { get; set; }
        #endregion
        
        #region Parameter Metric
        /// <summary>
        /// <para>
        /// <para>The metric used for the enabled subscription.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.MetricType")]
        public Amazon.EC2.MetricType Metric { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The source Region (like <c>us-east-1</c>) or Availability Zone ID (like <c>use1-az1</c>)
        /// that the metric subscription is enabled for. If you use Availability Zone IDs, the
        /// Source and Destination Availability Zones must be in the same Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source { get; set; }
        #endregion
        
        #region Parameter Statistic
        /// <summary>
        /// <para>
        /// <para>The statistic used for the enabled subscription.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.StatisticType")]
        public Amazon.EC2.StatisticType Statistic { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Output'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.EnableAwsNetworkPerformanceMetricSubscriptionResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.EnableAwsNetworkPerformanceMetricSubscriptionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Output";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Enable-EC2AwsNetworkPerformanceMetricSubscription (EnableAwsNetworkPerformanceMetricSubscription)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.EnableAwsNetworkPerformanceMetricSubscriptionResponse, EnableEC2AwsNetworkPerformanceMetricSubscriptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Destination = this.Destination;
            context.Metric = this.Metric;
            context.Source = this.Source;
            context.Statistic = this.Statistic;
            
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
            var request = new Amazon.EC2.Model.EnableAwsNetworkPerformanceMetricSubscriptionRequest();
            
            if (cmdletContext.Destination != null)
            {
                request.Destination = cmdletContext.Destination;
            }
            if (cmdletContext.Metric != null)
            {
                request.Metric = cmdletContext.Metric;
            }
            if (cmdletContext.Source != null)
            {
                request.Source = cmdletContext.Source;
            }
            if (cmdletContext.Statistic != null)
            {
                request.Statistic = cmdletContext.Statistic;
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
        
        private Amazon.EC2.Model.EnableAwsNetworkPerformanceMetricSubscriptionResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.EnableAwsNetworkPerformanceMetricSubscriptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "EnableAwsNetworkPerformanceMetricSubscription");
            try
            {
                #if DESKTOP
                return client.EnableAwsNetworkPerformanceMetricSubscription(request);
                #elif CORECLR
                return client.EnableAwsNetworkPerformanceMetricSubscriptionAsync(request).GetAwaiter().GetResult();
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
            public System.String Destination { get; set; }
            public Amazon.EC2.MetricType Metric { get; set; }
            public System.String Source { get; set; }
            public Amazon.EC2.StatisticType Statistic { get; set; }
            public System.Func<Amazon.EC2.Model.EnableAwsNetworkPerformanceMetricSubscriptionResponse, EnableEC2AwsNetworkPerformanceMetricSubscriptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Output;
        }
        
    }
}
