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
    /// </summary>
    [Cmdlet("Write", "ASScalingPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the PutScalingPolicy operation against Auto Scaling.", Operation = new[] {"PutScalingPolicy"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type PutScalingPolicyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteASScalingPolicyCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The adjustment type. Valid values are <code>ChangeInCapacity</code>, <code>ExactCapacity</code>,
        /// and <code>PercentChangeInCapacity</code>.</para><para>For more information, see <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/as-scale-based-on-demand.html">Dynamic
        /// Scaling</a> in the <i>Auto Scaling Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String AdjustmentType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String AutoScalingGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, after a scaling activity completes and before the
        /// next scaling activity can start.</para><para>For more information, see <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/Cooldown.html">Understanding
        /// Auto Scaling Cooldowns</a> in the <i>Auto Scaling Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 Cooldown { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Used with <code>AdjustmentType</code> with the value <code>PercentChangeInCapacity</code>,
        /// the scaling policy changes the <code>DesiredCapacity</code> of the Auto Scaling group
        /// by at least the number of instances specified in the value. </para><para>You will get a <code>ValidationError</code> if you use <code>MinAdjustmentStep</code>
        /// on a policy with an <code>AdjustmentType</code> other than <code>PercentChangeInCapacity</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 MinAdjustmentStep { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public String PolicyName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The number of instances by which to scale. <code>AdjustmentType</code> determines
        /// the interpretation of this number (for example, as an absolute number or as a percentage
        /// of the existing Auto Scaling group size). A positive increment adds to the current
        /// capacity and a negative value removes from the current capacity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 ScalingAdjustment { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
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
            if (ParameterWasBound("MinAdjustmentStep"))
                context.MinAdjustmentStep = this.MinAdjustmentStep;
            context.PolicyName = this.PolicyName;
            if (ParameterWasBound("ScalingAdjustment"))
                context.ScalingAdjustment = this.ScalingAdjustment;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new PutScalingPolicyRequest();
            
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
            if (cmdletContext.MinAdjustmentStep != null)
            {
                request.MinAdjustmentStep = cmdletContext.MinAdjustmentStep.Value;
            }
            if (cmdletContext.PolicyName != null)
            {
                request.PolicyName = cmdletContext.PolicyName;
            }
            if (cmdletContext.ScalingAdjustment != null)
            {
                request.ScalingAdjustment = cmdletContext.ScalingAdjustment.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.PutScalingPolicy(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String AdjustmentType { get; set; }
            public String AutoScalingGroupName { get; set; }
            public Int32? Cooldown { get; set; }
            public Int32? MinAdjustmentStep { get; set; }
            public String PolicyName { get; set; }
            public Int32? ScalingAdjustment { get; set; }
        }
        
    }
}
