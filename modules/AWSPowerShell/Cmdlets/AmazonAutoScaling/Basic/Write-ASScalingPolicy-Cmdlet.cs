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
    [OutputType("Amazon.AutoScaling.Model.PutScalingPolicyResponse")]
    [AWSCmdlet("Calls the Auto Scaling PutScalingPolicy API operation.", Operation = new[] {"PutScalingPolicy"})]
    [AWSCmdletOutput("Amazon.AutoScaling.Model.PutScalingPolicyResponse",
        "This cmdlet returns a Amazon.AutoScaling.Model.PutScalingPolicyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteASScalingPolicyCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        #region Parameter AdjustmentType
        /// <summary>
        /// <para>
        /// <para>The adjustment type. The valid values are <code>ChangeInCapacity</code>, <code>ExactCapacity</code>,
        /// and <code>PercentChangeInCapacity</code>.</para><para>This parameter is supported if the policy type is <code>SimpleScaling</code> or <code>StepScaling</code>.</para><para>For more information, see <a href="http://docs.aws.amazon.com/autoscaling/ec2/userguide/as-scale-based-on-demand.html">Dynamic
        /// Scaling</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AdjustmentType { get; set; }
        #endregion
        
        #region Parameter AutoScalingGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the Auto Scaling group.</para>
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
        /// period for the group applies.</para><para>This parameter is supported if the policy type is <code>SimpleScaling</code>.</para><para>For more information, see <a href="http://docs.aws.amazon.com/autoscaling/ec2/userguide/Cooldown.html">Scaling
        /// Cooldowns</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Cooldown { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_Dimension
        /// <summary>
        /// <para>
        /// <para>The dimensions of the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TargetTrackingConfiguration_CustomizedMetricSpecification_Dimensions")]
        public Amazon.AutoScaling.Model.MetricDimension[] CustomizedMetricSpecification_Dimension { get; set; }
        #endregion
        
        #region Parameter TargetTrackingConfiguration_DisableScaleIn
        /// <summary>
        /// <para>
        /// <para>Indicates whether scale in by the target tracking policy is disabled. If scale in
        /// is disabled, the target tracking policy won't remove instances from the Auto Scaling
        /// group. Otherwise, the target tracking policy can remove instances from the Auto Scaling
        /// group. The default is disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean TargetTrackingConfiguration_DisableScaleIn { get; set; }
        #endregion
        
        #region Parameter EstimatedInstanceWarmup
        /// <summary>
        /// <para>
        /// <para>The estimated time, in seconds, until a newly launched instance can contribute to
        /// the CloudWatch metrics. The default is to use the value specified for the default
        /// cooldown period for the group.</para><para>This parameter is supported if the policy type is <code>StepScaling</code> or <code>TargetTrackingScaling</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 EstimatedInstanceWarmup { get; set; }
        #endregion
        
        #region Parameter MetricAggregationType
        /// <summary>
        /// <para>
        /// <para>The aggregation type for the CloudWatch metrics. The valid values are <code>Minimum</code>,
        /// <code>Maximum</code>, and <code>Average</code>. If the aggregation type is null, the
        /// value is treated as <code>Average</code>.</para><para>This parameter is supported if the policy type is <code>StepScaling</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MetricAggregationType { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_MetricName
        /// <summary>
        /// <para>
        /// <para>The name of the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TargetTrackingConfiguration_CustomizedMetricSpecification_MetricName")]
        public System.String CustomizedMetricSpecification_MetricName { get; set; }
        #endregion
        
        #region Parameter MinAdjustmentMagnitude
        /// <summary>
        /// <para>
        /// <para>The minimum number of instances to scale. If the value of <code>AdjustmentType</code>
        /// is <code>PercentChangeInCapacity</code>, the scaling policy changes the <code>DesiredCapacity</code>
        /// of the Auto Scaling group by at least this many instances. Otherwise, the error is
        /// <code>ValidationError</code>.</para><para>This parameter is supported if the policy type is <code>SimpleScaling</code> or <code>StepScaling</code>.</para>
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
        
        #region Parameter CustomizedMetricSpecification_Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TargetTrackingConfiguration_CustomizedMetricSpecification_Namespace")]
        public System.String CustomizedMetricSpecification_Namespace { get; set; }
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
        /// <para>The policy type. The valid values are <code>SimpleScaling</code>, <code>StepScaling</code>,
        /// and <code>TargetTrackingScaling</code>. If the policy type is null, the value is treated
        /// as <code>SimpleScaling</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PolicyType { get; set; }
        #endregion
        
        #region Parameter PredefinedMetricSpecification_PredefinedMetricType
        /// <summary>
        /// <para>
        /// <para>The metric type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TargetTrackingConfiguration_PredefinedMetricSpecification_PredefinedMetricType")]
        [AWSConstantClassSource("Amazon.AutoScaling.MetricType")]
        public Amazon.AutoScaling.MetricType PredefinedMetricSpecification_PredefinedMetricType { get; set; }
        #endregion
        
        #region Parameter PredefinedMetricSpecification_ResourceLabel
        /// <summary>
        /// <para>
        /// <para>Identifies the resource associated with the metric type. The following predefined
        /// metrics are available:</para><ul><li><para><code>ASGAverageCPUUtilization</code> - average CPU utilization of the Auto Scaling
        /// group</para></li><li><para><code>ASGAverageNetworkIn</code> - average number of bytes received on all network
        /// interfaces by the Auto Scaling group</para></li><li><para><code>ASGAverageNetworkOut</code> - average number of bytes sent out on all network
        /// interfaces by the Auto Scaling group</para></li><li><para><code>ALBRequestCountPerTarget</code> - number of requests completed per target in
        /// an Application Load Balancer target group</para></li></ul><para>For predefined metric types <code>ASGAverageCPUUtilization</code>, <code>ASGAverageNetworkIn</code>,
        /// and <code>ASGAverageNetworkOut</code>, the parameter must not be specified as the
        /// resource associated with the metric type is the Auto Scaling group. For predefined
        /// metric type <code>ALBRequestCountPerTarget</code>, the parameter must be specified
        /// in the format: <code>app/<i>load-balancer-name</i>/<i>load-balancer-id</i>/targetgroup/<i>target-group-name</i>/<i>target-group-id</i></code>, where <code>app/<i>load-balancer-name</i>/<i>load-balancer-id</i></code>
        /// is the final portion of the load balancer ARN, and <code>targetgroup/<i>target-group-name</i>/<i>target-group-id</i></code> is the final portion of the target group ARN. The target group must be attached
        /// to the Auto Scaling group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TargetTrackingConfiguration_PredefinedMetricSpecification_ResourceLabel")]
        public System.String PredefinedMetricSpecification_ResourceLabel { get; set; }
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
        
        #region Parameter CustomizedMetricSpecification_Statistic
        /// <summary>
        /// <para>
        /// <para>The statistic of the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TargetTrackingConfiguration_CustomizedMetricSpecification_Statistic")]
        [AWSConstantClassSource("Amazon.AutoScaling.MetricStatistic")]
        public Amazon.AutoScaling.MetricStatistic CustomizedMetricSpecification_Statistic { get; set; }
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
        
        #region Parameter TargetTrackingConfiguration_TargetValue
        /// <summary>
        /// <para>
        /// <para>The target value for the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double TargetTrackingConfiguration_TargetValue { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_Unit
        /// <summary>
        /// <para>
        /// <para>The unit of the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TargetTrackingConfiguration_CustomizedMetricSpecification_Unit")]
        public System.String CustomizedMetricSpecification_Unit { get; set; }
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
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
            if (this.CustomizedMetricSpecification_Dimension != null)
            {
                context.TargetTrackingConfiguration_CustomizedMetricSpecification_Dimensions = new List<Amazon.AutoScaling.Model.MetricDimension>(this.CustomizedMetricSpecification_Dimension);
            }
            context.TargetTrackingConfiguration_CustomizedMetricSpecification_MetricName = this.CustomizedMetricSpecification_MetricName;
            context.TargetTrackingConfiguration_CustomizedMetricSpecification_Namespace = this.CustomizedMetricSpecification_Namespace;
            context.TargetTrackingConfiguration_CustomizedMetricSpecification_Statistic = this.CustomizedMetricSpecification_Statistic;
            context.TargetTrackingConfiguration_CustomizedMetricSpecification_Unit = this.CustomizedMetricSpecification_Unit;
            if (ParameterWasBound("TargetTrackingConfiguration_DisableScaleIn"))
                context.TargetTrackingConfiguration_DisableScaleIn = this.TargetTrackingConfiguration_DisableScaleIn;
            context.TargetTrackingConfiguration_PredefinedMetricSpecification_PredefinedMetricType = this.PredefinedMetricSpecification_PredefinedMetricType;
            context.TargetTrackingConfiguration_PredefinedMetricSpecification_ResourceLabel = this.PredefinedMetricSpecification_ResourceLabel;
            if (ParameterWasBound("TargetTrackingConfiguration_TargetValue"))
                context.TargetTrackingConfiguration_TargetValue = this.TargetTrackingConfiguration_TargetValue;
            
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
            
             // populate TargetTrackingConfiguration
            bool requestTargetTrackingConfigurationIsNull = true;
            request.TargetTrackingConfiguration = new Amazon.AutoScaling.Model.TargetTrackingConfiguration();
            System.Boolean? requestTargetTrackingConfiguration_targetTrackingConfiguration_DisableScaleIn = null;
            if (cmdletContext.TargetTrackingConfiguration_DisableScaleIn != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_DisableScaleIn = cmdletContext.TargetTrackingConfiguration_DisableScaleIn.Value;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_DisableScaleIn != null)
            {
                request.TargetTrackingConfiguration.DisableScaleIn = requestTargetTrackingConfiguration_targetTrackingConfiguration_DisableScaleIn.Value;
                requestTargetTrackingConfigurationIsNull = false;
            }
            System.Double? requestTargetTrackingConfiguration_targetTrackingConfiguration_TargetValue = null;
            if (cmdletContext.TargetTrackingConfiguration_TargetValue != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_TargetValue = cmdletContext.TargetTrackingConfiguration_TargetValue.Value;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_TargetValue != null)
            {
                request.TargetTrackingConfiguration.TargetValue = requestTargetTrackingConfiguration_targetTrackingConfiguration_TargetValue.Value;
                requestTargetTrackingConfigurationIsNull = false;
            }
            Amazon.AutoScaling.Model.PredefinedMetricSpecification requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification = null;
            
             // populate PredefinedMetricSpecification
            bool requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecificationIsNull = true;
            requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification = new Amazon.AutoScaling.Model.PredefinedMetricSpecification();
            Amazon.AutoScaling.MetricType requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_PredefinedMetricType = null;
            if (cmdletContext.TargetTrackingConfiguration_PredefinedMetricSpecification_PredefinedMetricType != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_PredefinedMetricType = cmdletContext.TargetTrackingConfiguration_PredefinedMetricSpecification_PredefinedMetricType;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_PredefinedMetricType != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification.PredefinedMetricType = requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_PredefinedMetricType;
                requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecificationIsNull = false;
            }
            System.String requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_ResourceLabel = null;
            if (cmdletContext.TargetTrackingConfiguration_PredefinedMetricSpecification_ResourceLabel != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_ResourceLabel = cmdletContext.TargetTrackingConfiguration_PredefinedMetricSpecification_ResourceLabel;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_ResourceLabel != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification.ResourceLabel = requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_ResourceLabel;
                requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecificationIsNull = false;
            }
             // determine if requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification should be set to null
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecificationIsNull)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification = null;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification != null)
            {
                request.TargetTrackingConfiguration.PredefinedMetricSpecification = requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification;
                requestTargetTrackingConfigurationIsNull = false;
            }
            Amazon.AutoScaling.Model.CustomizedMetricSpecification requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification = null;
            
             // populate CustomizedMetricSpecification
            bool requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecificationIsNull = true;
            requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification = new Amazon.AutoScaling.Model.CustomizedMetricSpecification();
            List<Amazon.AutoScaling.Model.MetricDimension> requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Dimension = null;
            if (cmdletContext.TargetTrackingConfiguration_CustomizedMetricSpecification_Dimensions != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Dimension = cmdletContext.TargetTrackingConfiguration_CustomizedMetricSpecification_Dimensions;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Dimension != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification.Dimensions = requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Dimension;
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
            System.String requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_MetricName = null;
            if (cmdletContext.TargetTrackingConfiguration_CustomizedMetricSpecification_MetricName != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_MetricName = cmdletContext.TargetTrackingConfiguration_CustomizedMetricSpecification_MetricName;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_MetricName != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification.MetricName = requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_MetricName;
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
            System.String requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Namespace = null;
            if (cmdletContext.TargetTrackingConfiguration_CustomizedMetricSpecification_Namespace != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Namespace = cmdletContext.TargetTrackingConfiguration_CustomizedMetricSpecification_Namespace;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Namespace != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification.Namespace = requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Namespace;
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
            Amazon.AutoScaling.MetricStatistic requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Statistic = null;
            if (cmdletContext.TargetTrackingConfiguration_CustomizedMetricSpecification_Statistic != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Statistic = cmdletContext.TargetTrackingConfiguration_CustomizedMetricSpecification_Statistic;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Statistic != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification.Statistic = requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Statistic;
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
            System.String requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Unit = null;
            if (cmdletContext.TargetTrackingConfiguration_CustomizedMetricSpecification_Unit != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Unit = cmdletContext.TargetTrackingConfiguration_CustomizedMetricSpecification_Unit;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Unit != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification.Unit = requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Unit;
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
             // determine if requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification should be set to null
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecificationIsNull)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification = null;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification != null)
            {
                request.TargetTrackingConfiguration.CustomizedMetricSpecification = requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification;
                requestTargetTrackingConfigurationIsNull = false;
            }
             // determine if request.TargetTrackingConfiguration should be set to null
            if (requestTargetTrackingConfigurationIsNull)
            {
                request.TargetTrackingConfiguration = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.AutoScaling.Model.PutScalingPolicyResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.PutScalingPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Auto Scaling", "PutScalingPolicy");
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
            public List<Amazon.AutoScaling.Model.MetricDimension> TargetTrackingConfiguration_CustomizedMetricSpecification_Dimensions { get; set; }
            public System.String TargetTrackingConfiguration_CustomizedMetricSpecification_MetricName { get; set; }
            public System.String TargetTrackingConfiguration_CustomizedMetricSpecification_Namespace { get; set; }
            public Amazon.AutoScaling.MetricStatistic TargetTrackingConfiguration_CustomizedMetricSpecification_Statistic { get; set; }
            public System.String TargetTrackingConfiguration_CustomizedMetricSpecification_Unit { get; set; }
            public System.Boolean? TargetTrackingConfiguration_DisableScaleIn { get; set; }
            public Amazon.AutoScaling.MetricType TargetTrackingConfiguration_PredefinedMetricSpecification_PredefinedMetricType { get; set; }
            public System.String TargetTrackingConfiguration_PredefinedMetricSpecification_ResourceLabel { get; set; }
            public System.Double? TargetTrackingConfiguration_TargetValue { get; set; }
        }
        
    }
}
