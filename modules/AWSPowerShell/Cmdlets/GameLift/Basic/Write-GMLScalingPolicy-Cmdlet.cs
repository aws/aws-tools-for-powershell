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
    /// Learn more about how to work with auto-scaling in <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/fleets-autoscaling.html">Set
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
    /// and reference a <c>TargetConfiguration</c> object with your desired buffer value.
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
    /// If <c>[MetricName]</c> is <c>[ComparisonOperator]</c><c>[Threshold]</c> for <c>[EvaluationPeriods]</c>
    /// minutes, then <c>[ScalingAdjustmentType]</c> to/by <c>[ScalingAdjustment]</c>.
    /// </para><para>
    /// To implement the example, the rule statement would look like this:
    /// </para><para>
    /// If <c>[PercentIdleInstances]</c> is <c>[GreaterThanThreshold]</c><c>[20]</c> for
    /// <c>[15]</c> minutes, then <c>[PercentChangeInCapacity]</c> to/by <c>[10]</c>.
    /// </para><para>
    /// To create or update a scaling policy, specify a unique combination of name and fleet
    /// ID, and set the policy type to "RuleBased". Specify the parameter values for a policy
    /// rule statement. On a successful request, the policy name is returned. Scaling policies
    /// are automatically in force as soon as they're successfully created. If the fleet's
    /// auto-scaling actions are temporarily suspended, the new policy will be in force once
    /// the fleet actions are restarted.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "GMLScalingPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon GameLift Service PutScalingPolicy API operation.", Operation = new[] {"PutScalingPolicy"}, SelectReturnType = typeof(Amazon.GameLift.Model.PutScalingPolicyResponse))]
    [AWSCmdletOutput("System.String or Amazon.GameLift.Model.PutScalingPolicyResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GameLift.Model.PutScalingPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteGMLScalingPolicyCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ComparisonOperator
        /// <summary>
        /// <para>
        /// <para>Comparison operator to use when measuring the metric against the threshold value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EvaluationPeriods")]
        public System.Int32? EvaluationPeriod { get; set; }
        #endregion
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the fleet to apply this policy to. You can use either the
        /// fleet ID or ARN value. The fleet cannot be in any of the following statuses: ERROR
        /// or DELETING.</para>
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
        public System.String FleetId { get; set; }
        #endregion
        
        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// <para>Name of the Amazon GameLift-defined metric that is used to trigger a scaling adjustment.
        /// For detailed descriptions of fleet metrics, see <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/monitoring-cloudwatch.html">Monitor
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.GameLift.MetricName")]
        public Amazon.GameLift.MetricName MetricName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A descriptive label that is associated with a fleet's scaling policy. Policy names
        /// do not need to be unique. A fleet can have only one scaling policy with the same name.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PolicyType
        /// <summary>
        /// <para>
        /// <para>The type of scaling policy to create. For a target-based policy, set the parameter
        /// <i>MetricName</i> to 'PercentAvailableGameSessions' and specify a <i>TargetConfiguration</i>.
        /// For a rule-based policy set the following parameters: <i>MetricName</i>, <i>ComparisonOperator</i>,
        /// <i>Threshold</i>, <i>EvaluationPeriods</i>, <i>ScalingAdjustmentType</i>, and <i>ScalingAdjustment</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.PolicyType")]
        public Amazon.GameLift.PolicyType PolicyType { get; set; }
        #endregion
        
        #region Parameter ScalingAdjustment
        /// <summary>
        /// <para>
        /// <para>Amount of adjustment to make, based on the scaling adjustment type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingAdjustment { get; set; }
        #endregion
        
        #region Parameter ScalingAdjustmentType
        /// <summary>
        /// <para>
        /// <para>The type of adjustment to make to a fleet's instance count:</para><ul><li><para><b>ChangeInCapacity</b> -- add (or subtract) the scaling adjustment value from the
        /// current instance count. Positive values scale up while negative values scale down.</para></li><li><para><b>ExactCapacity</b> -- set the instance count to the scaling adjustment value.</para></li><li><para><b>PercentChangeInCapacity</b> -- increase or reduce the current instance count by
        /// the scaling adjustment, read as a percentage. Positive values scale up while negative
        /// values scale down; for example, a value of "-10" scales the fleet down by 10%.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? TargetConfiguration_TargetValue { get; set; }
        #endregion
        
        #region Parameter Threshold
        /// <summary>
        /// <para>
        /// <para>Metric value used to trigger a scaling event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? Threshold { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Name'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.PutScalingPolicyResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.PutScalingPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Name";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FleetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-GMLScalingPolicy (PutScalingPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.PutScalingPolicyResponse, WriteGMLScalingPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ComparisonOperator = this.ComparisonOperator;
            context.EvaluationPeriod = this.EvaluationPeriod;
            context.FleetId = this.FleetId;
            #if MODULAR
            if (this.FleetId == null && ParameterWasBound(nameof(this.FleetId)))
            {
                WriteWarning("You are passing $null as a value for parameter FleetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetricName = this.MetricName;
            #if MODULAR
            if (this.MetricName == null && ParameterWasBound(nameof(this.MetricName)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyType = this.PolicyType;
            context.ScalingAdjustment = this.ScalingAdjustment;
            context.ScalingAdjustmentType = this.ScalingAdjustmentType;
            context.TargetConfiguration_TargetValue = this.TargetConfiguration_TargetValue;
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
            if (cmdletContext.EvaluationPeriod != null)
            {
                request.EvaluationPeriods = cmdletContext.EvaluationPeriod.Value;
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
            var requestTargetConfigurationIsNull = true;
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
        
        private Amazon.GameLift.Model.PutScalingPolicyResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.PutScalingPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "PutScalingPolicy");
            try
            {
                return client.PutScalingPolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? EvaluationPeriod { get; set; }
            public System.String FleetId { get; set; }
            public Amazon.GameLift.MetricName MetricName { get; set; }
            public System.String Name { get; set; }
            public Amazon.GameLift.PolicyType PolicyType { get; set; }
            public System.Int32? ScalingAdjustment { get; set; }
            public Amazon.GameLift.ScalingAdjustmentType ScalingAdjustmentType { get; set; }
            public System.Double? TargetConfiguration_TargetValue { get; set; }
            public System.Double? Threshold { get; set; }
            public System.Func<Amazon.GameLift.Model.PutScalingPolicyResponse, WriteGMLScalingPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Name;
        }
        
    }
}
