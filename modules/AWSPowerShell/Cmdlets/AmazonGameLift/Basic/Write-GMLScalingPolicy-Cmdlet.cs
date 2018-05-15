/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates or updates a scaling policy for a fleet. Scaling policies are used to automatically
    /// scale a fleet's hosting capacity to meet player demand. An active scaling policy instructs
    /// Amazon GameLift to track a fleet metric and automatically change the fleet's capacity
    /// when a certain threshold is reached. There are two types of scaling policies: target-based
    /// and rule-based. Use a target-based policy to quickly and efficiently manage fleet
    /// scaling; this option is the most commonly used. Use rule-based policies when you need
    /// to exert fine-grained control over auto-scaling. 
    /// 
    ///  
    /// <para>
    /// Fleets can have multiple scaling policies of each type in force at the same time;
    /// you can have one target-based policy, one or multiple rule-based scaling policies,
    /// or both. We recommend caution, however, because multiple auto-scaling policies can
    /// have unintended consequences.
    /// </para><para>
    /// You can temporarily suspend all scaling policies for a fleet by calling <a>StopFleetActions</a>
    /// with the fleet action AUTO_SCALING. To resume scaling policies, call <a>StartFleetActions</a>
    /// with the same fleet action. To stop just one scaling policy--or to permanently remove
    /// it, you must delete the policy with <a>DeleteScalingPolicy</a>.
    /// </para><para>
    /// Learn more about how to work with auto-scaling in <a href="http://docs.aws.amazon.com/gamelift/latest/developerguide/fleets-autoscaling.html">Set
    /// Up Fleet Automatic Scaling</a>.
    /// </para><para><b>Target-based policy</b></para><para>
    /// A target-based policy tracks a single metric: PercentAvailableGameSessions. This metric
    /// tells us how much of a fleet's hosting capacity is ready to host game sessions but
    /// is not currently in use. This is the fleet's buffer; it measures the additional player
    /// demand that the fleet could handle at current capacity. With a target-based policy,
    /// you set your ideal buffer size and leave it to Amazon GameLift to take whatever action
    /// is needed to maintain that target. 
    /// </para><para>
    /// For example, you might choose to maintain a 10% buffer for a fleet that has the capacity
    /// to host 100 simultaneous game sessions. This policy tells Amazon GameLift to take
    /// action whenever the fleet's available capacity falls below or rises above 10 game
    /// sessions. Amazon GameLift will start new instances or stop unused instances in order
    /// to return to the 10% buffer. 
    /// </para><para>
    /// To create or update a target-based policy, specify a fleet ID and name, and set the
    /// policy type to "TargetBased". Specify the metric to track (PercentAvailableGameSessions)
    /// and reference a <a>TargetConfiguration</a> object with your desired buffer value.
    /// Exclude all other parameters. On a successful request, the policy name is returned.
    /// The scaling policy is automatically in force as soon as it's successfully created.
    /// If the fleet's auto-scaling actions are temporarily suspended, the new policy will
    /// be in force once the fleet actions are restarted.
    /// </para><para><b>Rule-based policy</b></para><para>
    /// A rule-based policy tracks specified fleet metric, sets a threshold value, and specifies
    /// the type of action to initiate when triggered. With a rule-based policy, you can select
    /// from several available fleet metrics. Each policy specifies whether to scale up or
    /// scale down (and by how much), so you need one policy for each type of action. 
    /// </para><para>
    /// For example, a policy may make the following statement: "If the percentage of idle
    /// instances is greater than 20% for more than 15 minutes, then reduce the fleet capacity
    /// by 10%."
    /// </para><para>
    /// A policy's rule statement has the following structure:
    /// </para><para>
    /// If <code>[MetricName]</code> is <code>[ComparisonOperator]</code><code>[Threshold]</code>
    /// for <code>[EvaluationPeriods]</code> minutes, then <code>[ScalingAdjustmentType]</code>
    /// to/by <code>[ScalingAdjustment]</code>.
    /// </para><para>
    /// To implement the example, the rule statement would look like this:
    /// </para><para>
    /// If <code>[PercentIdleInstances]</code> is <code>[GreaterThanThreshold]</code><code>[20]</code>
    /// for <code>[15]</code> minutes, then <code>[PercentChangeInCapacity]</code> to/by <code>[10]</code>.
    /// </para><para>
    /// To create or update a scaling policy, specify a unique combination of name and fleet
    /// ID, and set the policy type to "RuleBased". Specify the parameter values for a policy
    /// rule statement. On a successful request, the policy name is returned. Scaling policies
    /// are automatically in force as soon as they're successfully created. If the fleet's
    /// auto-scaling actions are temporarily suspended, the new policy will be in force once
    /// the fleet actions are restarted.
    /// </para><para>
    /// Operations related to fleet capacity scaling include:
    /// </para><ul><li><para><a>DescribeFleetCapacity</a></para></li><li><para><a>UpdateFleetCapacity</a></para></li><li><para><a>DescribeEC2InstanceLimits</a></para></li><li><para>
    /// Manage scaling policies:
    /// </para><ul><li><para><a>PutScalingPolicy</a> (auto-scaling)
    /// </para></li><li><para><a>DescribeScalingPolicies</a> (auto-scaling)
    /// </para></li><li><para><a>DeleteScalingPolicy</a> (auto-scaling)
    /// </para></li></ul></li><li><para>
    /// Manage fleet actions:
    /// </para><ul><li><para><a>StartFleetActions</a></para></li><li><para><a>StopFleetActions</a></para></li></ul></li></ul>
    /// </summary>
    [Cmdlet("Write", "GMLScalingPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon GameLift Service PutScalingPolicy API operation.", Operation = new[] {"PutScalingPolicy"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.GameLift.Model.PutScalingPolicyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteGMLScalingPolicyCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter ComparisonOperator
        /// <summary>
        /// <para>
        /// <para>Comparison operator to use when measuring the metric against the threshold value.</para>
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
        /// <para>Unique identifier for a fleet to apply this policy to. The fleet cannot be in any
        /// of the following statuses: ERROR or DELETING.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String FleetId { get; set; }
        #endregion
        
        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// <para>Name of the Amazon GameLift-defined metric that is used to trigger a scaling adjustment.
        /// For detailed descriptions of fleet metrics, see <a href="http://docs.aws.amazon.com/gamelift/latest/developerguide/monitoring-cloudwatch.html">Monitor
        /// Amazon GameLift with Amazon CloudWatch</a>. </para><ul><li><para><b>ActivatingGameSessions</b> -- Game sessions in the process of being created.</para></li><li><para><b>ActiveGameSessions</b> -- Game sessions that are currently running.</para></li><li><para><b>ActiveInstances</b> -- Fleet instances that are currently running at least one
        /// game session.</para></li><li><para><b>AvailableGameSessions</b> -- Additional game sessions that fleet could host simultaneously,
        /// given current capacity.</para></li><li><para><b>AvailablePlayerSessions</b> -- Empty player slots in currently active game sessions.
        /// This includes game sessions that are not currently accepting players. Reserved player
        /// slots are not included.</para></li><li><para><b>CurrentPlayerSessions</b> -- Player slots in active game sessions that are being
        /// used by a player or are reserved for a player. </para></li><li><para><b>IdleInstances</b> -- Active instances that are currently hosting zero game sessions.
        /// </para></li><li><para><b>PercentAvailableGameSessions</b> -- Unused percentage of the total number of game
        /// sessions that a fleet could host simultaneously, given current capacity. Use this
        /// metric for a target-based scaling policy.</para></li><li><para><b>PercentIdleInstances</b> -- Percentage of the total number of active instances
        /// that are hosting zero game sessions.</para></li><li><para><b>QueueDepth</b> -- Pending game session placement requests, in any queue, where
        /// the current fleet is the top-priority destination.</para></li><li><para><b>WaitTime</b> -- Current wait time for pending game session placement requests,
        /// in any queue, where the current fleet is the top-priority destination. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.GameLift.MetricName")]
        public Amazon.GameLift.MetricName MetricName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Descriptive label that is associated with a scaling policy. Policy names do not need
        /// to be unique. A fleet can have only one scaling policy with the same name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PolicyType
        /// <summary>
        /// <para>
        /// <para>Type of scaling policy to create. For a target-based policy, set the parameter <i>MetricName</i>
        /// to 'PercentAvailableGameSessions' and specify a <i>TargetConfiguration</i>. For a
        /// rule-based policy set the following parameters: <i>MetricName</i>, <i>ComparisonOperator</i>,
        /// <i>Threshold</i>, <i>EvaluationPeriods</i>, <i>ScalingAdjustmentType</i>, and <i>ScalingAdjustment</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.GameLift.PolicyType")]
        public Amazon.GameLift.PolicyType PolicyType { get; set; }
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
        /// <para>Type of adjustment to make to a fleet's instance count (see <a>FleetCapacity</a>):</para><ul><li><para><b>ChangeInCapacity</b> -- add (or subtract) the scaling adjustment value from the
        /// current instance count. Positive values scale up while negative values scale down.</para></li><li><para><b>ExactCapacity</b> -- set the instance count to the scaling adjustment value.</para></li><li><para><b>PercentChangeInCapacity</b> -- increase or reduce the current instance count by
        /// the scaling adjustment, read as a percentage. Positive values scale up while negative
        /// values scale down; for example, a value of "-10" scales the fleet down by 10%.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.GameLift.ScalingAdjustmentType")]
        public Amazon.GameLift.ScalingAdjustmentType ScalingAdjustmentType { get; set; }
        #endregion
        
        #region Parameter TargetConfiguration_TargetValue
        /// <summary>
        /// <para>
        /// <para>Desired value to use with a target-based scaling policy. The value must be relevant
        /// for whatever metric the scaling policy is using. For example, in a policy using the
        /// metric PercentAvailableGameSessions, the target value should be the preferred size
        /// of the fleet's buffer (the percent of capacity that should be idle and ready for new
        /// game sessions).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double TargetConfiguration_TargetValue { get; set; }
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
            context.PolicyType = this.PolicyType;
            if (ParameterWasBound("ScalingAdjustment"))
                context.ScalingAdjustment = this.ScalingAdjustment;
            context.ScalingAdjustmentType = this.ScalingAdjustmentType;
            if (ParameterWasBound("TargetConfiguration_TargetValue"))
                context.TargetConfiguration_TargetValue = this.TargetConfiguration_TargetValue;
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
            if (cmdletContext.PolicyType != null)
            {
                request.PolicyType = cmdletContext.PolicyType;
            }
            if (cmdletContext.ScalingAdjustment != null)
            {
                request.ScalingAdjustment = cmdletContext.ScalingAdjustment.Value;
            }
            if (cmdletContext.ScalingAdjustmentType != null)
            {
                request.ScalingAdjustmentType = cmdletContext.ScalingAdjustmentType;
            }
            
             // populate TargetConfiguration
            bool requestTargetConfigurationIsNull = true;
            request.TargetConfiguration = new Amazon.GameLift.Model.TargetConfiguration();
            System.Double? requestTargetConfiguration_targetConfiguration_TargetValue = null;
            if (cmdletContext.TargetConfiguration_TargetValue != null)
            {
                requestTargetConfiguration_targetConfiguration_TargetValue = cmdletContext.TargetConfiguration_TargetValue.Value;
            }
            if (requestTargetConfiguration_targetConfiguration_TargetValue != null)
            {
                request.TargetConfiguration.TargetValue = requestTargetConfiguration_targetConfiguration_TargetValue.Value;
                requestTargetConfigurationIsNull = false;
            }
             // determine if request.TargetConfiguration should be set to null
            if (requestTargetConfigurationIsNull)
            {
                request.TargetConfiguration = null;
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
        
        private Amazon.GameLift.Model.PutScalingPolicyResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.PutScalingPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "PutScalingPolicy");
            try
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
            public Amazon.GameLift.ComparisonOperatorType ComparisonOperator { get; set; }
            public System.Int32? EvaluationPeriods { get; set; }
            public System.String FleetId { get; set; }
            public Amazon.GameLift.MetricName MetricName { get; set; }
            public System.String Name { get; set; }
            public Amazon.GameLift.PolicyType PolicyType { get; set; }
            public System.Int32? ScalingAdjustment { get; set; }
            public Amazon.GameLift.ScalingAdjustmentType ScalingAdjustmentType { get; set; }
            public System.Double? TargetConfiguration_TargetValue { get; set; }
            public System.Double? Threshold { get; set; }
        }
        
    }
}
