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
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AS
{
    /// <summary>
    /// Creates or updates a policy for an Auto Scaling group. To update an existing policy,
    /// use the existing policy name and set the parameters you want to change. Any existing
    /// parameter not changed in an update to an existing policy is not changed in this update
    /// request.
    /// 
    ///  
    /// <para>
    /// If you exceed your maximum limit of step adjustments, which by default is 20 per region,
    /// the call fails. For information about updating this limit, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws_service_limits.html">AWS
    /// Service Limits</a> in the <i>Amazon Web Services General Reference</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "ASScalingPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the PutScalingPolicy operation against Auto Scaling.", Operation = new[] {"PutScalingPolicy"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.AutoScaling.Model.PutScalingPolicyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteASScalingPolicyCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        #region Parameter AdjustmentType
        /// <summary>
        /// <para>
        /// <para>The adjustment type. Valid values are <code>ChangeInCapacity</code>, <code>ExactCapacity</code>,
        /// and <code>PercentChangeInCapacity</code>.</para><para>For more information, see <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/as-scale-based-on-demand.html">Dynamic
        /// Scaling</a> in the <i>Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AdjustmentType { get; set; }
        #endregion
        
        #region Parameter AutoScalingGroupName
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AutoScalingGroupName { get; set; }
        #endregion
        
        #region Parameter Cooldown
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, after a scaling activity completes and before the
        /// next scaling activity can start. If this parameter is not specified, the default cooldown
        /// period for the group applies.</para><para>This parameter is not supported unless the policy type is <code>SimpleScaling</code>.</para><para>For more information, see <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/Cooldown.html">Auto
        /// Scaling Cooldowns</a> in the <i>Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Cooldown { get; set; }
        #endregion
        
        #region Parameter EstimatedInstanceWarmup
        /// <summary>
        /// <para>
        /// <para>The estimated time, in seconds, until a newly launched instance can contribute to
        /// the CloudWatch metrics. The default is to use the value specified for the default
        /// cooldown period for the group.</para><para>This parameter is not supported if the policy type is <code>SimpleScaling</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 EstimatedInstanceWarmup { get; set; }
        #endregion
        
        #region Parameter MetricAggregationType
        /// <summary>
        /// <para>
        /// <para>The aggregation type for the CloudWatch metrics. Valid values are <code>Minimum</code>,
        /// <code>Maximum</code>, and <code>Average</code>. If the aggregation type is null, the
        /// value is treated as <code>Average</code>.</para><para>This parameter is not supported if the policy type is <code>SimpleScaling</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MetricAggregationType { get; set; }
        #endregion
        
        #region Parameter MinAdjustmentMagnitude
        /// <summary>
        /// <para>
        /// <para>The minimum number of instances to scale. If the value of <code>AdjustmentType</code>
        /// is <code>PercentChangeInCapacity</code>, the scaling policy changes the <code>DesiredCapacity</code>
        /// of the Auto Scaling group by at least this many instances. Otherwise, the error is
        /// <code>ValidationError</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 MinAdjustmentMagnitude { get; set; }
        #endregion
        
        #region Parameter MinAdjustmentStep
        /// <summary>
        /// <para>
        /// <para>Available for backward compatibility. Use <code>MinAdjustmentMagnitude</code> instead.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 MinAdjustmentStep { get; set; }
        #endregion
        
        #region Parameter PolicyName
        /// <summary>
        /// <para>
        /// <para>The name of the policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String PolicyName { get; set; }
        #endregion
        
        #region Parameter PolicyType
        /// <summary>
        /// <para>
        /// <para>The policy type. Valid values are <code>SimpleScaling</code> and <code>StepScaling</code>.
        /// If the policy type is null, the value is treated as <code>SimpleScaling</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PolicyType { get; set; }
        #endregion
        
        #region Parameter ScalingAdjustment
        /// <summary>
        /// <para>
        /// <para>The amount by which to scale, based on the specified adjustment type. A positive value
        /// adds to the current capacity while a negative number removes from the current capacity.</para><para>This parameter is required if the policy type is <code>SimpleScaling</code> and not
        /// supported otherwise.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ScalingAdjustment { get; set; }
        #endregion
        
        #region Parameter StepAdjustment
        /// <summary>
        /// <para>
        /// <para>A set of adjustments that enable you to scale based on the size of the alarm breach.</para><para>This parameter is required if the policy type is <code>StepScaling</code> and not
        /// supported otherwise.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StepAdjustments")]
        public Amazon.AutoScaling.Model.StepAdjustment[] StepAdjustment { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("AutoScalingGroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ASScalingPolicy (PutScalingPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AdjustmentType = this.AdjustmentType;
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            if (ParameterWasBound("Cooldown"))
                context.Cooldown = this.Cooldown;
            if (ParameterWasBound("EstimatedInstanceWarmup"))
                context.EstimatedInstanceWarmup = this.EstimatedInstanceWarmup;
            context.MetricAggregationType = this.MetricAggregationType;
            if (ParameterWasBound("MinAdjustmentMagnitude"))
                context.MinAdjustmentMagnitude = this.MinAdjustmentMagnitude;
            if (ParameterWasBound("MinAdjustmentStep"))
                context.MinAdjustmentStep = this.MinAdjustmentStep;
            context.PolicyName = this.PolicyName;
            context.PolicyType = this.PolicyType;
            if (ParameterWasBound("ScalingAdjustment"))
                context.ScalingAdjustment = this.ScalingAdjustment;
            if (this.StepAdjustment != null)
            {
                context.StepAdjustments = new List<Amazon.AutoScaling.Model.StepAdjustment>(this.StepAdjustment);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.AutoScaling.Model.PutScalingPolicyRequest();
            
            if (cmdletContext.AdjustmentType != null)
            {
                request.AdjustmentType = cmdletContext.AdjustmentType;
            }
            if (cmdletContext.AutoScalingGroupName != null)
            {
                request.AutoScalingGroupName = cmdletContext.AutoScalingGroupName;
            }
            if (cmdletContext.Cooldown != null)
            {
                request.Cooldown = cmdletContext.Cooldown.Value;
            }
            if (cmdletContext.EstimatedInstanceWarmup != null)
            {
                request.EstimatedInstanceWarmup = cmdletContext.EstimatedInstanceWarmup.Value;
            }
            if (cmdletContext.MetricAggregationType != null)
            {
                request.MetricAggregationType = cmdletContext.MetricAggregationType;
            }
            if (cmdletContext.MinAdjustmentMagnitude != null)
            {
                request.MinAdjustmentMagnitude = cmdletContext.MinAdjustmentMagnitude.Value;
            }
            if (cmdletContext.MinAdjustmentStep != null)
            {
                request.MinAdjustmentStep = cmdletContext.MinAdjustmentStep.Value;
            }
            if (cmdletContext.PolicyName != null)
            {
                request.PolicyName = cmdletContext.PolicyName;
            }
            if (cmdletContext.PolicyType != null)
            {
                request.PolicyType = cmdletContext.PolicyType;
            }
            if (cmdletContext.ScalingAdjustment != null)
            {
                request.ScalingAdjustment = cmdletContext.ScalingAdjustment.Value;
            }
            if (cmdletContext.StepAdjustments != null)
            {
                request.StepAdjustments = cmdletContext.StepAdjustments;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.PolicyARN;
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
        
        private static Amazon.AutoScaling.Model.PutScalingPolicyResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.PutScalingPolicyRequest request)
        {
            return client.PutScalingPolicy(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AdjustmentType { get; set; }
            public System.String AutoScalingGroupName { get; set; }
            public System.Int32? Cooldown { get; set; }
            public System.Int32? EstimatedInstanceWarmup { get; set; }
            public System.String MetricAggregationType { get; set; }
            public System.Int32? MinAdjustmentMagnitude { get; set; }
            public System.Int32? MinAdjustmentStep { get; set; }
            public System.String PolicyName { get; set; }
            public System.String PolicyType { get; set; }
            public System.Int32? ScalingAdjustment { get; set; }
            public List<Amazon.AutoScaling.Model.StepAdjustment> StepAdjustments { get; set; }
        }
        
    }
}
