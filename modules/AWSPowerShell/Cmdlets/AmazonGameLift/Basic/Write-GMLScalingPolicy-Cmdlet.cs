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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Creates or updates a scaling policy for a fleet. An active scaling policy prompts
    /// Amazon GameLift to track a certain metric for a fleet and automatically change the
    /// fleet's capacity in specific circumstances. Each scaling policy contains one rule
    /// statement. Fleets can have multiple scaling policies in force simultaneously.
    /// 
    ///  
    /// <para>
    /// A scaling policy rule statement has the following structure:
    /// </para><para>
    /// If <code>[MetricName]</code> is <code>[ComparisonOperator]</code><code>[Threshold]</code>
    /// for <code>[EvaluationPeriods]</code> minutes, then <code>[ScalingAdjustmentType]</code>
    /// to/by <code>[ScalingAdjustment]</code>.
    /// </para><para>
    /// For example, this policy: "If the number of idle instances exceeds 20 for more than
    /// 15 minutes, then reduce the fleet capacity by 10 instances" could be implemented as
    /// the following rule statement: 
    /// </para><para>
    /// If [IdleInstances] is [GreaterThanOrEqualToThreshold] [20] for [15] minutes, then
    /// [ChangeInCapacity] by [-10]. 
    /// </para><para>
    /// To create or update a scaling policy, specify a unique combination of name and fleet
    /// ID, and set the rule values. All parameters for this action are required. If successful,
    /// the policy name is returned. Scaling policies cannot be suspended or made inactive.
    /// To stop enforcing a scaling policy, call <a>DeleteScalingPolicy</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "GMLScalingPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the PutScalingPolicy operation against Amazon GameLift Service.", Operation = new[] {"PutScalingPolicy"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.GameLift.Model.PutScalingPolicyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteGMLScalingPolicyCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter ComparisonOperator
        /// <summary>
        /// <para>
        /// <para>Comparison operator to use when measuring the metric against the threshold value.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.GameLift.ComparisonOperatorType")]
        public Amazon.GameLift.ComparisonOperatorType ComparisonOperator { get; set; }
        #endregion
        
        #region Parameter EvaluationPeriod
        /// <summary>
        /// <para>
        /// <para>Length of time (in minutes) the metric must be at or beyond the threshold before a
        /// scaling event is triggered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EvaluationPeriods")]
        public System.Int32 EvaluationPeriod { get; set; }
        #endregion
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>Unique identity for the fleet to scale with this policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String FleetId { get; set; }
        #endregion
        
        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// <para>Name of the Amazon GameLift-defined metric that is used to trigger an adjustment.</para><ul><li><b>ActivatingGameSessions</b> – number of game sessions in the process
        /// of being created (game session status = <code>ACTIVATING</code>).</li><li><b>ActiveGameSessions</b>
        /// – number of game sessions currently running (game session status = <code>ACTIVE</code>).</li><li><b>CurrentPlayerSessions</b> – number of active or reserved player sessions (player
        /// session status = <code>ACTIVE</code> or <code>RESERVED</code>). </li><li><b>AvailablePlayerSessions</b>
        /// – number of player session slots currently available in active game sessions across
        /// the fleet, calculated by subtracting a game session's current player session count
        /// from its maximum player session count. This number includes game sessions that are
        /// not currently accepting players (game session <code>PlayerSessionCreationPolicy</code>
        /// = <code>DENY_ALL</code>).</li><li><b>ActiveInstances</b> – number of instances currently
        /// running a game session.</li><li><b>IdleInstances</b> – number of instances not currently
        /// running a game session.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.GameLift.MetricName")]
        public Amazon.GameLift.MetricName MetricName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Descriptive label associated with a scaling policy. Policy names do not need to be
        /// unique. A fleet can have only one scaling policy with the same name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ScalingAdjustment
        /// <summary>
        /// <para>
        /// <para>Amount of adjustment to make, based on the scaling adjustment type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ScalingAdjustment { get; set; }
        #endregion
        
        #region Parameter ScalingAdjustmentType
        /// <summary>
        /// <para>
        /// <para>Type of adjustment to make to a fleet's instance count (see <a>FleetCapacity</a>):</para><ul><li><b>ChangeInCapacity</b> – add (or subtract) the scaling adjustment value
        /// from the current instance count. Positive values scale up while negative values scale
        /// down.</li><li><b>ExactCapacity</b> – set the instance count to the scaling adjustment
        /// value.</li><li><b>PercentChangeInCapacity</b> – increase or reduce the current instance
        /// count by the scaling adjustment, read as a percentage. Positive values scale up while
        /// negative values scale down; for example, a value of "-10" scales the fleet down by
        /// 10%.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.GameLift.ScalingAdjustmentType")]
        public Amazon.GameLift.ScalingAdjustmentType ScalingAdjustmentType { get; set; }
        #endregion
        
        #region Parameter Threshold
        /// <summary>
        /// <para>
        /// <para>Metric value used to trigger a scaling event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double Threshold { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FleetId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-GMLScalingPolicy (PutScalingPolicy)"))
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
            
            context.ComparisonOperator = this.ComparisonOperator;
            if (ParameterWasBound("EvaluationPeriod"))
                context.EvaluationPeriods = this.EvaluationPeriod;
            context.FleetId = this.FleetId;
            context.MetricName = this.MetricName;
            context.Name = this.Name;
            if (ParameterWasBound("ScalingAdjustment"))
                context.ScalingAdjustment = this.ScalingAdjustment;
            context.ScalingAdjustmentType = this.ScalingAdjustmentType;
            if (ParameterWasBound("Threshold"))
                context.Threshold = this.Threshold;
            
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
            var request = new Amazon.GameLift.Model.PutScalingPolicyRequest();
            
            if (cmdletContext.ComparisonOperator != null)
            {
                request.ComparisonOperator = cmdletContext.ComparisonOperator;
            }
            if (cmdletContext.EvaluationPeriods != null)
            {
                request.EvaluationPeriods = cmdletContext.EvaluationPeriods.Value;
            }
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
            }
            if (cmdletContext.MetricName != null)
            {
                request.MetricName = cmdletContext.MetricName;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ScalingAdjustment != null)
            {
                request.ScalingAdjustment = cmdletContext.ScalingAdjustment.Value;
            }
            if (cmdletContext.ScalingAdjustmentType != null)
            {
                request.ScalingAdjustmentType = cmdletContext.ScalingAdjustmentType;
            }
            if (cmdletContext.Threshold != null)
            {
                request.Threshold = cmdletContext.Threshold.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Name;
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
        
        private static Amazon.GameLift.Model.PutScalingPolicyResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.PutScalingPolicyRequest request)
        {
            #if DESKTOP
            return client.PutScalingPolicy(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.PutScalingPolicyAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public Amazon.GameLift.ComparisonOperatorType ComparisonOperator { get; set; }
            public System.Int32? EvaluationPeriods { get; set; }
            public System.String FleetId { get; set; }
            public Amazon.GameLift.MetricName MetricName { get; set; }
            public System.String Name { get; set; }
            public System.Int32? ScalingAdjustment { get; set; }
            public Amazon.GameLift.ScalingAdjustmentType ScalingAdjustmentType { get; set; }
            public System.Double? Threshold { get; set; }
        }
        
    }
}
