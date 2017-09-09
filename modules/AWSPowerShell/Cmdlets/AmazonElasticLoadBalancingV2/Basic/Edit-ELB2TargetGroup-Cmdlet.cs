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
using Amazon.ElasticLoadBalancingV2;
using Amazon.ElasticLoadBalancingV2.Model;

namespace Amazon.PowerShell.Cmdlets.ELB2
{
    /// <summary>
    /// Modifies the health checks used when evaluating the health state of the targets in
    /// the specified target group.
    /// 
    ///  
    /// <para>
    /// To monitor the health of the targets, use <a>DescribeTargetHealth</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "ELB2TargetGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticLoadBalancingV2.Model.TargetGroup")]
    [AWSCmdlet("Invokes the ModifyTargetGroup operation against Elastic Load Balancing V2.", Operation = new[] {"ModifyTargetGroup"})]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancingV2.Model.TargetGroup",
        "This cmdlet returns a collection of TargetGroup objects.",
        "The service call response (type Amazon.ElasticLoadBalancingV2.Model.ModifyTargetGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditELB2TargetGroupCmdlet : AmazonElasticLoadBalancingV2ClientCmdlet, IExecutor
    {
        
        #region Parameter HealthCheckIntervalSecond
        /// <summary>
        /// <para>
        /// <para>The approximate amount of time, in seconds, between health checks of an individual
        /// target. For Application Load Balancers, the range is 5 to 300 seconds. For Network
        /// Load Balancers, the supported values are 10 or 30 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HealthCheckIntervalSeconds")]
        public System.Int32 HealthCheckIntervalSecond { get; set; }
        #endregion
        
        #region Parameter HealthCheckPath
        /// <summary>
        /// <para>
        /// <para>[HTTP/HTTPS health checks] The ping path that is the destination for the health check
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HealthCheckPath { get; set; }
        #endregion
        
        #region Parameter HealthCheckPort
        /// <summary>
        /// <para>
        /// <para>The port the load balancer uses when performing health checks on targets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HealthCheckPort { get; set; }
        #endregion
        
        #region Parameter HealthCheckProtocol
        /// <summary>
        /// <para>
        /// <para>The protocol the load balancer uses when performing health checks on targets. The
        /// TCP protocol is supported only if the protocol of the target group is TCP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ElasticLoadBalancingV2.ProtocolEnum")]
        public Amazon.ElasticLoadBalancingV2.ProtocolEnum HealthCheckProtocol { get; set; }
        #endregion
        
        #region Parameter HealthCheckTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>[HTTP/HTTPS health checks] The amount of time, in seconds, during which no response
        /// means a failed health check.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("HealthCheckTimeoutSeconds")]
        public System.Int32 HealthCheckTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter HealthyThresholdCount
        /// <summary>
        /// <para>
        /// <para>The number of consecutive health checks successes required before considering an unhealthy
        /// target healthy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 HealthyThresholdCount { get; set; }
        #endregion
        
        #region Parameter Matcher_HttpCode
        /// <summary>
        /// <para>
        /// <para>The HTTP codes.</para><para>For Application Load Balancers, you can specify values between 200 and 499, and the
        /// default value is 200. You can specify multiple values (for example, "200,202") or
        /// a range of values (for example, "200-299").</para><para>For Network Load Balancers, this is 200 to 399.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Matcher_HttpCode { get; set; }
        #endregion
        
        #region Parameter TargetGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the target group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TargetGroupArn { get; set; }
        #endregion
        
        #region Parameter UnhealthyThresholdCount
        /// <summary>
        /// <para>
        /// <para>The number of consecutive health check failures required before considering the target
        /// unhealthy. For Network Load Balancers, this value must be the same as the healthy
        /// threshold count.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 UnhealthyThresholdCount { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TargetGroupArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-ELB2TargetGroup (ModifyTargetGroup)"))
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
            
            if (ParameterWasBound("HealthCheckIntervalSecond"))
                context.HealthCheckIntervalSeconds = this.HealthCheckIntervalSecond;
            context.HealthCheckPath = this.HealthCheckPath;
            context.HealthCheckPort = this.HealthCheckPort;
            context.HealthCheckProtocol = this.HealthCheckProtocol;
            if (ParameterWasBound("HealthCheckTimeoutSecond"))
                context.HealthCheckTimeoutSeconds = this.HealthCheckTimeoutSecond;
            if (ParameterWasBound("HealthyThresholdCount"))
                context.HealthyThresholdCount = this.HealthyThresholdCount;
            context.Matcher_HttpCode = this.Matcher_HttpCode;
            context.TargetGroupArn = this.TargetGroupArn;
            if (ParameterWasBound("UnhealthyThresholdCount"))
                context.UnhealthyThresholdCount = this.UnhealthyThresholdCount;
            
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
            var request = new Amazon.ElasticLoadBalancingV2.Model.ModifyTargetGroupRequest();
            
            if (cmdletContext.HealthCheckIntervalSeconds != null)
            {
                request.HealthCheckIntervalSeconds = cmdletContext.HealthCheckIntervalSeconds.Value;
            }
            if (cmdletContext.HealthCheckPath != null)
            {
                request.HealthCheckPath = cmdletContext.HealthCheckPath;
            }
            if (cmdletContext.HealthCheckPort != null)
            {
                request.HealthCheckPort = cmdletContext.HealthCheckPort;
            }
            if (cmdletContext.HealthCheckProtocol != null)
            {
                request.HealthCheckProtocol = cmdletContext.HealthCheckProtocol;
            }
            if (cmdletContext.HealthCheckTimeoutSeconds != null)
            {
                request.HealthCheckTimeoutSeconds = cmdletContext.HealthCheckTimeoutSeconds.Value;
            }
            if (cmdletContext.HealthyThresholdCount != null)
            {
                request.HealthyThresholdCount = cmdletContext.HealthyThresholdCount.Value;
            }
            
             // populate Matcher
            bool requestMatcherIsNull = true;
            request.Matcher = new Amazon.ElasticLoadBalancingV2.Model.Matcher();
            System.String requestMatcher_matcher_HttpCode = null;
            if (cmdletContext.Matcher_HttpCode != null)
            {
                requestMatcher_matcher_HttpCode = cmdletContext.Matcher_HttpCode;
            }
            if (requestMatcher_matcher_HttpCode != null)
            {
                request.Matcher.HttpCode = requestMatcher_matcher_HttpCode;
                requestMatcherIsNull = false;
            }
             // determine if request.Matcher should be set to null
            if (requestMatcherIsNull)
            {
                request.Matcher = null;
            }
            if (cmdletContext.TargetGroupArn != null)
            {
                request.TargetGroupArn = cmdletContext.TargetGroupArn;
            }
            if (cmdletContext.UnhealthyThresholdCount != null)
            {
                request.UnhealthyThresholdCount = cmdletContext.UnhealthyThresholdCount.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.TargetGroups;
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
        
        private Amazon.ElasticLoadBalancingV2.Model.ModifyTargetGroupResponse CallAWSServiceOperation(IAmazonElasticLoadBalancingV2 client, Amazon.ElasticLoadBalancingV2.Model.ModifyTargetGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing V2", "ModifyTargetGroup");
            try
            {
                #if DESKTOP
                return client.ModifyTargetGroup(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ModifyTargetGroupAsync(request);
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
            public System.Int32? HealthCheckIntervalSeconds { get; set; }
            public System.String HealthCheckPath { get; set; }
            public System.String HealthCheckPort { get; set; }
            public Amazon.ElasticLoadBalancingV2.ProtocolEnum HealthCheckProtocol { get; set; }
            public System.Int32? HealthCheckTimeoutSeconds { get; set; }
            public System.Int32? HealthyThresholdCount { get; set; }
            public System.String Matcher_HttpCode { get; set; }
            public System.String TargetGroupArn { get; set; }
            public System.Int32? UnhealthyThresholdCount { get; set; }
        }
        
    }
}
