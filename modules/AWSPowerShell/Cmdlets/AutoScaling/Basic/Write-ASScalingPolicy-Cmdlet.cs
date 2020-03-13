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
    /// Creates or updates a scaling policy for an Auto Scaling group.
    /// 
    ///  
    /// <para>
    /// For more information about using scaling policies to scale your Auto Scaling group,
    /// see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/as-scaling-target-tracking.html">Target
    /// Tracking Scaling Policies</a> and <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/as-scaling-simple-step.html">Step
    /// and Simple Scaling Policies</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "ASScalingPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AutoScaling.Model.PutScalingPolicyResponse")]
    [AWSCmdlet("Calls the AWS Auto Scaling PutScalingPolicy API operation.", Operation = new[] {"PutScalingPolicy"}, SelectReturnType = typeof(Amazon.AutoScaling.Model.PutScalingPolicyResponse))]
    [AWSCmdletOutput("Amazon.AutoScaling.Model.PutScalingPolicyResponse",
        "This cmdlet returns an Amazon.AutoScaling.Model.PutScalingPolicyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteASScalingPolicyCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        #region Parameter AdjustmentType
        /// <summary>
        /// <para>
        /// <para>Specifies whether the <code>ScalingAdjustment</code> parameter is an absolute number
        /// or a percentage of the current capacity. The valid values are <code>ChangeInCapacity</code>,
        /// <code>ExactCapacity</code>, and <code>PercentChangeInCapacity</code>.</para><para>Valid only if the policy type is <code>StepScaling</code> or <code>SimpleScaling</code>.
        /// For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/as-scaling-simple-step.html#as-scaling-adjustment">Scaling
        /// Adjustment Types</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdjustmentType { get; set; }
        #endregion
        
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
        
        #region Parameter Cooldown
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, after a scaling activity completes before any further
        /// dynamic scaling activities can start. If this parameter is not specified, the default
        /// cooldown period for the group applies.</para><para>Valid only if the policy type is <code>SimpleScaling</code>. For more information,
        /// see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/Cooldown.html">Scaling
        /// Cooldowns</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Cooldown { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_Dimension
        /// <summary>
        /// <para>
        /// <para>The dimensions of the metric.</para><para>Conditional: If you published your metric with dimensions, you must specify the same
        /// dimensions in your scaling policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingConfiguration_CustomizedMetricSpecification_Dimensions")]
        public Amazon.AutoScaling.Model.MetricDimension[] CustomizedMetricSpecification_Dimension { get; set; }
        #endregion
        
        #region Parameter TargetTrackingConfiguration_DisableScaleIn
        /// <summary>
        /// <para>
        /// <para>Indicates whether scaling in by the target tracking scaling policy is disabled. If
        /// scaling in is disabled, the target tracking scaling policy doesn't remove instances
        /// from the Auto Scaling group. Otherwise, the target tracking scaling policy can remove
        /// instances from the Auto Scaling group. The default is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TargetTrackingConfiguration_DisableScaleIn { get; set; }
        #endregion
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether the scaling policy is enabled or disabled. The default is enabled.
        /// For more information, see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/as-enable-disable-scaling-policy.html">Disabling
        /// a Scaling Policy for an Auto Scaling Group</a> in the <i>Amazon EC2 Auto Scaling User
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter EstimatedInstanceWarmup
        /// <summary>
        /// <para>
        /// <para>The estimated time, in seconds, until a newly launched instance can contribute to
        /// the CloudWatch metrics. The default is to use the value specified for the default
        /// cooldown period for the group.</para><para>Valid only if the policy type is <code>StepScaling</code> or <code>TargetTrackingScaling</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EstimatedInstanceWarmup { get; set; }
        #endregion
        
        #region Parameter MetricAggregationType
        /// <summary>
        /// <para>
        /// <para>The aggregation type for the CloudWatch metrics. The valid values are <code>Minimum</code>,
        /// <code>Maximum</code>, and <code>Average</code>. If the aggregation type is null, the
        /// value is treated as <code>Average</code>.</para><para>Valid only if the policy type is <code>StepScaling</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetricAggregationType { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_MetricName
        /// <summary>
        /// <para>
        /// <para>The name of the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingConfiguration_CustomizedMetricSpecification_MetricName")]
        public System.String CustomizedMetricSpecification_MetricName { get; set; }
        #endregion
        
        #region Parameter MinAdjustmentMagnitude
        /// <summary>
        /// <para>
        /// <para>The minimum value to scale by when scaling by percentages. For example, suppose that
        /// you create a step scaling policy to scale out an Auto Scaling group by 25 percent
        /// and you specify a <code>MinAdjustmentMagnitude</code> of 2. If the group has 4 instances
        /// and the scaling policy is performed, 25 percent of 4 is 1. However, because you specified
        /// a <code>MinAdjustmentMagnitude</code> of 2, Amazon EC2 Auto Scaling scales out the
        /// group by 2 instances. </para><para>Valid only if the policy type is <code>StepScaling</code> or <code>SimpleScaling</code>
        /// and the adjustment type is <code>PercentChangeInCapacity</code>. For more information,
        /// see <a href="https://docs.aws.amazon.com/autoscaling/ec2/userguide/as-scaling-simple-step.html#as-scaling-adjustment">Scaling
        /// Adjustment Types</a> in the <i>Amazon EC2 Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinAdjustmentMagnitude { get; set; }
        #endregion
        
        #region Parameter MinAdjustmentStep
        /// <summary>
        /// <para>
        /// <para>Available for backward compatibility. Use <code>MinAdjustmentMagnitude</code> instead.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinAdjustmentStep { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingConfiguration_CustomizedMetricSpecification_Namespace")]
        public System.String CustomizedMetricSpecification_Namespace { get; set; }
        #endregion
        
        #region Parameter PolicyName
        /// <summary>
        /// <para>
        /// <para>The name of the policy.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PolicyType { get; set; }
        #endregion
        
        #region Parameter PredefinedMetricSpecification_PredefinedMetricType
        /// <summary>
        /// <para>
        /// <para>The metric type. The following predefined metrics are available:</para><ul><li><para><code>ASGAverageCPUUtilization</code> - Average CPU utilization of the Auto Scaling
        /// group.</para></li><li><para><code>ASGAverageNetworkIn</code> - Average number of bytes received on all network
        /// interfaces by the Auto Scaling group.</para></li><li><para><code>ASGAverageNetworkOut</code> - Average number of bytes sent out on all network
        /// interfaces by the Auto Scaling group.</para></li><li><para><code>ALBRequestCountPerTarget</code> - Number of requests completed per target in
        /// an Application Load Balancer target group.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingConfiguration_PredefinedMetricSpecification_PredefinedMetricType")]
        [AWSConstantClassSource("Amazon.AutoScaling.MetricType")]
        public Amazon.AutoScaling.MetricType PredefinedMetricSpecification_PredefinedMetricType { get; set; }
        #endregion
        
        #region Parameter PredefinedMetricSpecification_ResourceLabel
        /// <summary>
        /// <para>
        /// <para>Identifies the resource associated with the metric type. You can't specify a resource
        /// label unless the metric type is <code>ALBRequestCountPerTarget</code> and there is
        /// a target group attached to the Auto Scaling group.</para><para>The format is <code>app/<i>load-balancer-name</i>/<i>load-balancer-id</i>/targetgroup/<i>target-group-name</i>/<i>target-group-id</i></code>, where </para><ul><li><para><code>app/<i>load-balancer-name</i>/<i>load-balancer-id</i></code> is the final
        /// portion of the load balancer ARN, and</para></li><li><para><code>targetgroup/<i>target-group-name</i>/<i>target-group-id</i></code> is the
        /// final portion of the target group ARN.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingConfiguration_PredefinedMetricSpecification_ResourceLabel")]
        public System.String PredefinedMetricSpecification_ResourceLabel { get; set; }
        #endregion
        
        #region Parameter ScalingAdjustment
        /// <summary>
        /// <para>
        /// <para>The amount by which a simple scaling policy scales the Auto Scaling group in response
        /// to an alarm breach. The adjustment is based on the value that you specified in the
        /// <code>AdjustmentType</code> parameter (either an absolute number or a percentage).
        /// A positive value adds to the current capacity and a negative value subtracts from
        /// the current capacity. For exact capacity, you must specify a positive value.</para><para>Conditional: If you specify <code>SimpleScaling</code> for the policy type, you must
        /// specify this parameter. (Not used with any other policy type.) </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingAdjustment { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_Statistic
        /// <summary>
        /// <para>
        /// <para>The statistic of the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingConfiguration_CustomizedMetricSpecification_Statistic")]
        [AWSConstantClassSource("Amazon.AutoScaling.MetricStatistic")]
        public Amazon.AutoScaling.MetricStatistic CustomizedMetricSpecification_Statistic { get; set; }
        #endregion
        
        #region Parameter StepAdjustment
        /// <summary>
        /// <para>
        /// <para>A set of adjustments that enable you to scale based on the size of the alarm breach.</para><para>Conditional: If you specify <code>StepScaling</code> for the policy type, you must
        /// specify this parameter. (Not used with any other policy type.) </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StepAdjustments")]
        public Amazon.AutoScaling.Model.StepAdjustment[] StepAdjustment { get; set; }
        #endregion
        
        #region Parameter TargetTrackingConfiguration_TargetValue
        /// <summary>
        /// <para>
        /// <para>The target value for the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? TargetTrackingConfiguration_TargetValue { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_Unit
        /// <summary>
        /// <para>
        /// <para>The unit of the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingConfiguration_CustomizedMetricSpecification_Unit")]
        public System.String CustomizedMetricSpecification_Unit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AutoScaling.Model.PutScalingPolicyResponse).
        /// Specifying the name of a property of type Amazon.AutoScaling.Model.PutScalingPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AutoScalingGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AutoScalingGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AutoScalingGroupName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AutoScalingGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ASScalingPolicy (PutScalingPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AutoScaling.Model.PutScalingPolicyResponse, WriteASScalingPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AutoScalingGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AdjustmentType = this.AdjustmentType;
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            #if MODULAR
            if (this.AutoScalingGroupName == null && ParameterWasBound(nameof(this.AutoScalingGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoScalingGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Cooldown = this.Cooldown;
            context.Enabled = this.Enabled;
            context.EstimatedInstanceWarmup = this.EstimatedInstanceWarmup;
            context.MetricAggregationType = this.MetricAggregationType;
            context.MinAdjustmentMagnitude = this.MinAdjustmentMagnitude;
            context.MinAdjustmentStep = this.MinAdjustmentStep;
            context.PolicyName = this.PolicyName;
            #if MODULAR
            if (this.PolicyName == null && ParameterWasBound(nameof(this.PolicyName)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyType = this.PolicyType;
            context.ScalingAdjustment = this.ScalingAdjustment;
            if (this.StepAdjustment != null)
            {
                context.StepAdjustment = new List<Amazon.AutoScaling.Model.StepAdjustment>(this.StepAdjustment);
            }
            if (this.CustomizedMetricSpecification_Dimension != null)
            {
                context.CustomizedMetricSpecification_Dimension = new List<Amazon.AutoScaling.Model.MetricDimension>(this.CustomizedMetricSpecification_Dimension);
            }
            context.CustomizedMetricSpecification_MetricName = this.CustomizedMetricSpecification_MetricName;
            context.CustomizedMetricSpecification_Namespace = this.CustomizedMetricSpecification_Namespace;
            context.CustomizedMetricSpecification_Statistic = this.CustomizedMetricSpecification_Statistic;
            context.CustomizedMetricSpecification_Unit = this.CustomizedMetricSpecification_Unit;
            context.TargetTrackingConfiguration_DisableScaleIn = this.TargetTrackingConfiguration_DisableScaleIn;
            context.PredefinedMetricSpecification_PredefinedMetricType = this.PredefinedMetricSpecification_PredefinedMetricType;
            context.PredefinedMetricSpecification_ResourceLabel = this.PredefinedMetricSpecification_ResourceLabel;
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
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
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
            if (cmdletContext.StepAdjustment != null)
            {
                request.StepAdjustments = cmdletContext.StepAdjustment;
            }
            
             // populate TargetTrackingConfiguration
            var requestTargetTrackingConfigurationIsNull = true;
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
            var requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecificationIsNull = true;
            requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification = new Amazon.AutoScaling.Model.PredefinedMetricSpecification();
            Amazon.AutoScaling.MetricType requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_PredefinedMetricType = null;
            if (cmdletContext.PredefinedMetricSpecification_PredefinedMetricType != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_PredefinedMetricType = cmdletContext.PredefinedMetricSpecification_PredefinedMetricType;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_PredefinedMetricType != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification.PredefinedMetricType = requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_PredefinedMetricType;
                requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecificationIsNull = false;
            }
            System.String requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_ResourceLabel = null;
            if (cmdletContext.PredefinedMetricSpecification_ResourceLabel != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_ResourceLabel = cmdletContext.PredefinedMetricSpecification_ResourceLabel;
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
            var requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecificationIsNull = true;
            requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification = new Amazon.AutoScaling.Model.CustomizedMetricSpecification();
            List<Amazon.AutoScaling.Model.MetricDimension> requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Dimension = null;
            if (cmdletContext.CustomizedMetricSpecification_Dimension != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Dimension = cmdletContext.CustomizedMetricSpecification_Dimension;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Dimension != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification.Dimensions = requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Dimension;
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
            System.String requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_MetricName = null;
            if (cmdletContext.CustomizedMetricSpecification_MetricName != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_MetricName = cmdletContext.CustomizedMetricSpecification_MetricName;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_MetricName != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification.MetricName = requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_MetricName;
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
            System.String requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Namespace = null;
            if (cmdletContext.CustomizedMetricSpecification_Namespace != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Namespace = cmdletContext.CustomizedMetricSpecification_Namespace;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Namespace != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification.Namespace = requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Namespace;
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
            Amazon.AutoScaling.MetricStatistic requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Statistic = null;
            if (cmdletContext.CustomizedMetricSpecification_Statistic != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Statistic = cmdletContext.CustomizedMetricSpecification_Statistic;
            }
            if (requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Statistic != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification.Statistic = requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Statistic;
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
            System.String requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Unit = null;
            if (cmdletContext.CustomizedMetricSpecification_Unit != null)
            {
                requestTargetTrackingConfiguration_targetTrackingConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Unit = cmdletContext.CustomizedMetricSpecification_Unit;
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
        
        private Amazon.AutoScaling.Model.PutScalingPolicyResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.PutScalingPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Auto Scaling", "PutScalingPolicy");
            try
            {
                #if DESKTOP
                return client.PutScalingPolicy(request);
                #elif CORECLR
                return client.PutScalingPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Enabled { get; set; }
            public System.Int32? EstimatedInstanceWarmup { get; set; }
            public System.String MetricAggregationType { get; set; }
            public System.Int32? MinAdjustmentMagnitude { get; set; }
            public System.Int32? MinAdjustmentStep { get; set; }
            public System.String PolicyName { get; set; }
            public System.String PolicyType { get; set; }
            public System.Int32? ScalingAdjustment { get; set; }
            public List<Amazon.AutoScaling.Model.StepAdjustment> StepAdjustment { get; set; }
            public List<Amazon.AutoScaling.Model.MetricDimension> CustomizedMetricSpecification_Dimension { get; set; }
            public System.String CustomizedMetricSpecification_MetricName { get; set; }
            public System.String CustomizedMetricSpecification_Namespace { get; set; }
            public Amazon.AutoScaling.MetricStatistic CustomizedMetricSpecification_Statistic { get; set; }
            public System.String CustomizedMetricSpecification_Unit { get; set; }
            public System.Boolean? TargetTrackingConfiguration_DisableScaleIn { get; set; }
            public Amazon.AutoScaling.MetricType PredefinedMetricSpecification_PredefinedMetricType { get; set; }
            public System.String PredefinedMetricSpecification_ResourceLabel { get; set; }
            public System.Double? TargetTrackingConfiguration_TargetValue { get; set; }
            public System.Func<Amazon.AutoScaling.Model.PutScalingPolicyResponse, WriteASScalingPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
