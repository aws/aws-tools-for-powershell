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
using Amazon.ApplicationAutoScaling;
using Amazon.ApplicationAutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AAS
{
    /// <summary>
    /// Creates or updates a policy for an Application Auto Scaling scalable target.
    /// 
    ///  
    /// <para>
    /// Each scalable target is identified by a service namespace, resource ID, and scalable
    /// dimension. A scaling policy applies to the scalable target identified by those three
    /// attributes. You cannot create a scaling policy without first registering a scalable
    /// target using <a>RegisterScalableTarget</a>.
    /// </para><para>
    /// To update a policy, specify its policy name and the parameters that you want to change.
    /// Any parameters that you don't specify are not changed by this update request.
    /// </para><para>
    /// You can view the scaling policies for a service namespace using <a>DescribeScalingPolicies</a>.
    /// If you are no longer using a scaling policy, you can delete it using <a>DeleteScalingPolicy</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "AASScalingPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApplicationAutoScaling.Model.PutScalingPolicyResponse")]
    [AWSCmdlet("Invokes the PutScalingPolicy operation against Application Auto Scaling.", Operation = new[] {"PutScalingPolicy"})]
    [AWSCmdletOutput("Amazon.ApplicationAutoScaling.Model.PutScalingPolicyResponse",
        "This cmdlet returns a Amazon.ApplicationAutoScaling.Model.PutScalingPolicyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteAASScalingPolicyCmdlet : AmazonApplicationAutoScalingClientCmdlet, IExecutor
    {
        
        #region Parameter StepScalingPolicyConfiguration_AdjustmentType
        /// <summary>
        /// <para>
        /// <para>The adjustment type, which specifies how the <code>ScalingAdjustment</code> parameter
        /// in a <a>StepAdjustment</a> is interpreted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.AdjustmentType")]
        public Amazon.ApplicationAutoScaling.AdjustmentType StepScalingPolicyConfiguration_AdjustmentType { get; set; }
        #endregion
        
        #region Parameter StepScalingPolicyConfiguration_Cooldown
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, after a scaling activity completes where previous
        /// trigger-related scaling activities can influence future scaling events.</para><para>For scale out policies, while the cooldown period is in effect, the capacity that
        /// has been added by the previous scale out event that initiated the cooldown is calculated
        /// as part of the desired capacity for the next scale out. The intention is to continuously
        /// (but not excessively) scale out. For example, an alarm triggers a step scaling policy
        /// to scale out an Amazon ECS service by 2 tasks, the scaling activity completes successfully,
        /// and a cooldown period of 5 minutes starts. During the Cooldown period, if the alarm
        /// triggers the same policy again but at a more aggressive step adjustment to scale out
        /// the service by 3 tasks, the 2 tasks that were added in the previous scale out event
        /// are considered part of that capacity and only 1 additional task is added to the desired
        /// count.</para><para>For scale in policies, the cooldown period is used to block subsequent scale in requests
        /// until it has expired. The intention is to scale in conservatively to protect your
        /// application's availability. However, if another alarm triggers a scale out policy
        /// during the cooldown period after a scale-in, Application Auto Scaling scales out your
        /// scalable target immediately.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 StepScalingPolicyConfiguration_Cooldown { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_Dimension
        /// <summary>
        /// <para>
        /// <para>The dimensions of the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Dimensions")]
        public Amazon.ApplicationAutoScaling.Model.MetricDimension[] CustomizedMetricSpecification_Dimension { get; set; }
        #endregion
        
        #region Parameter StepScalingPolicyConfiguration_MetricAggregationType
        /// <summary>
        /// <para>
        /// <para>The aggregation type for the CloudWatch metrics. Valid values are <code>Minimum</code>,
        /// <code>Maximum</code>, and <code>Average</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.MetricAggregationType")]
        public Amazon.ApplicationAutoScaling.MetricAggregationType StepScalingPolicyConfiguration_MetricAggregationType { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_MetricName
        /// <summary>
        /// <para>
        /// <para>The name of the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_MetricName")]
        public System.String CustomizedMetricSpecification_MetricName { get; set; }
        #endregion
        
        #region Parameter StepScalingPolicyConfiguration_MinAdjustmentMagnitude
        /// <summary>
        /// <para>
        /// <para>The minimum number to adjust your scalable dimension as a result of a scaling activity.
        /// If the adjustment type is <code>PercentChangeInCapacity</code>, the scaling policy
        /// changes the scalable dimension of the scalable target by this amount.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 StepScalingPolicyConfiguration_MinAdjustmentMagnitude { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Namespace")]
        public System.String CustomizedMetricSpecification_Namespace { get; set; }
        #endregion
        
        #region Parameter PolicyName
        /// <summary>
        /// <para>
        /// <para>The name of the scaling policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PolicyName { get; set; }
        #endregion
        
        #region Parameter PolicyType
        /// <summary>
        /// <para>
        /// <para>The policy type. If you are creating a new policy, this parameter is required. If
        /// you are updating a policy, this parameter is not required.</para><para>For DynamoDB, only <code>TargetTrackingScaling</code> is supported. For any other
        /// service, only <code>StepScaling</code> is supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.PolicyType")]
        public Amazon.ApplicationAutoScaling.PolicyType PolicyType { get; set; }
        #endregion
        
        #region Parameter PredefinedMetricSpecification_PredefinedMetricType
        /// <summary>
        /// <para>
        /// <para>The metric type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TargetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_PredefinedMetricType")]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.MetricType")]
        public Amazon.ApplicationAutoScaling.MetricType PredefinedMetricSpecification_PredefinedMetricType { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the resource associated with the scaling policy. This string consists
        /// of the resource type and unique identifier.</para><ul><li><para>ECS service - The resource type is <code>service</code> and the unique identifier
        /// is the cluster name and service name. Example: <code>service/default/sample-webapp</code>.</para></li><li><para>Spot fleet request - The resource type is <code>spot-fleet-request</code> and the
        /// unique identifier is the Spot fleet request ID. Example: <code>spot-fleet-request/sfr-73fbd2ce-aa30-494c-8788-1cee4EXAMPLE</code>.</para></li><li><para>EMR cluster - The resource type is <code>instancegroup</code> and the unique identifier
        /// is the cluster ID and instance group ID. Example: <code>instancegroup/j-2EEZNYKUA1NTV/ig-1791Y4E1L8YI0</code>.</para></li><li><para>AppStream 2.0 fleet - The resource type is <code>fleet</code> and the unique identifier
        /// is the fleet name. Example: <code>fleet/sample-fleet</code>.</para></li><li><para>DynamoDB table - The resource type is <code>table</code> and the unique identifier
        /// is the resource ID. Example: <code>table/my-table</code>.</para></li><li><para>DynamoDB global secondary index - The resource type is <code>index</code> and the
        /// unique identifier is the resource ID. Example: <code>table/my-table/index/my-table-index</code>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter PredefinedMetricSpecification_ResourceLabel
        /// <summary>
        /// <para>
        /// <para>Reserved for future use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TargetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_ResourceLabel")]
        public System.String PredefinedMetricSpecification_ResourceLabel { get; set; }
        #endregion
        
        #region Parameter ScalableDimension
        /// <summary>
        /// <para>
        /// <para>The scalable dimension. This string consists of the service namespace, resource type,
        /// and scaling property.</para><ul><li><para><code>ecs:service:DesiredCount</code> - The desired task count of an ECS service.</para></li><li><para><code>ec2:spot-fleet-request:TargetCapacity</code> - The target capacity of a Spot
        /// fleet request.</para></li><li><para><code>elasticmapreduce:instancegroup:InstanceCount</code> - The instance count of
        /// an EMR Instance Group.</para></li><li><para><code>appstream:fleet:DesiredCapacity</code> - The desired capacity of an AppStream
        /// 2.0 fleet.</para></li><li><para><code>dynamodb:table:ReadCapacityUnits</code> - The provisioned read capacity for
        /// a DynamoDB table.</para></li><li><para><code>dynamodb:table:WriteCapacityUnits</code> - The provisioned write capacity for
        /// a DynamoDB table.</para></li><li><para><code>dynamodb:index:ReadCapacityUnits</code> - The provisioned read capacity for
        /// a DynamoDB global secondary index.</para></li><li><para><code>dynamodb:index:WriteCapacityUnits</code> - The provisioned write capacity for
        /// a DynamoDB global secondary index.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.ScalableDimension")]
        public Amazon.ApplicationAutoScaling.ScalableDimension ScalableDimension { get; set; }
        #endregion
        
        #region Parameter TargetTrackingScalingPolicyConfiguration_ScaleInCooldown
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, after a scale in activity completes before another
        /// scale in activity can start.</para><para>The cooldown period is used to block subsequent scale in requests until it has expired.
        /// The intention is to scale in conservatively to protect your application's availability.
        /// However, if another alarm triggers a scale out policy during the cooldown period after
        /// a scale-in, Application Auto Scaling scales out your scalable target immediately.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 TargetTrackingScalingPolicyConfiguration_ScaleInCooldown { get; set; }
        #endregion
        
        #region Parameter TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, after a scale out activity completes before another
        /// scale out activity can start.</para><para>While the cooldown period is in effect, the capacity that has been added by the previous
        /// scale out event that initiated the cooldown is calculated as part of the desired capacity
        /// for the next scale out. The intention is to continuously (but not excessively) scale
        /// out.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown { get; set; }
        #endregion
        
        #region Parameter ServiceNamespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the AWS service. For more information, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#genref-aws-service-namespaces">AWS
        /// Service Namespaces</a> in the <i>Amazon Web Services General Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.ServiceNamespace")]
        public Amazon.ApplicationAutoScaling.ServiceNamespace ServiceNamespace { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_Statistic
        /// <summary>
        /// <para>
        /// <para>The statistic of the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Statistic")]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.MetricStatistic")]
        public Amazon.ApplicationAutoScaling.MetricStatistic CustomizedMetricSpecification_Statistic { get; set; }
        #endregion
        
        #region Parameter StepScalingPolicyConfiguration_StepAdjustment
        /// <summary>
        /// <para>
        /// <para>A set of adjustments that enable you to scale based on the size of the alarm breach.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StepScalingPolicyConfiguration_StepAdjustments")]
        public Amazon.ApplicationAutoScaling.Model.StepAdjustment[] StepScalingPolicyConfiguration_StepAdjustment { get; set; }
        #endregion
        
        #region Parameter TargetTrackingScalingPolicyConfiguration_TargetValue
        /// <summary>
        /// <para>
        /// <para>The target value for the metric. The range is 8.515920e-109 to 1.174271e+108 (Base
        /// 10) or 2e-360 to 2e360 (Base 2).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double TargetTrackingScalingPolicyConfiguration_TargetValue { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_Unit
        /// <summary>
        /// <para>
        /// <para>The unit of the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Unit")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("PolicyName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-AASScalingPolicy (PutScalingPolicy)"))
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
            
            context.PolicyName = this.PolicyName;
            context.PolicyType = this.PolicyType;
            context.ResourceId = this.ResourceId;
            context.ScalableDimension = this.ScalableDimension;
            context.ServiceNamespace = this.ServiceNamespace;
            context.StepScalingPolicyConfiguration_AdjustmentType = this.StepScalingPolicyConfiguration_AdjustmentType;
            if (ParameterWasBound("StepScalingPolicyConfiguration_Cooldown"))
                context.StepScalingPolicyConfiguration_Cooldown = this.StepScalingPolicyConfiguration_Cooldown;
            context.StepScalingPolicyConfiguration_MetricAggregationType = this.StepScalingPolicyConfiguration_MetricAggregationType;
            if (ParameterWasBound("StepScalingPolicyConfiguration_MinAdjustmentMagnitude"))
                context.StepScalingPolicyConfiguration_MinAdjustmentMagnitude = this.StepScalingPolicyConfiguration_MinAdjustmentMagnitude;
            if (this.StepScalingPolicyConfiguration_StepAdjustment != null)
            {
                context.StepScalingPolicyConfiguration_StepAdjustments = new List<Amazon.ApplicationAutoScaling.Model.StepAdjustment>(this.StepScalingPolicyConfiguration_StepAdjustment);
            }
            if (this.CustomizedMetricSpecification_Dimension != null)
            {
                context.TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Dimensions = new List<Amazon.ApplicationAutoScaling.Model.MetricDimension>(this.CustomizedMetricSpecification_Dimension);
            }
            context.TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_MetricName = this.CustomizedMetricSpecification_MetricName;
            context.TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Namespace = this.CustomizedMetricSpecification_Namespace;
            context.TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Statistic = this.CustomizedMetricSpecification_Statistic;
            context.TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Unit = this.CustomizedMetricSpecification_Unit;
            context.TargetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_PredefinedMetricType = this.PredefinedMetricSpecification_PredefinedMetricType;
            context.TargetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_ResourceLabel = this.PredefinedMetricSpecification_ResourceLabel;
            if (ParameterWasBound("TargetTrackingScalingPolicyConfiguration_ScaleInCooldown"))
                context.TargetTrackingScalingPolicyConfiguration_ScaleInCooldown = this.TargetTrackingScalingPolicyConfiguration_ScaleInCooldown;
            if (ParameterWasBound("TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown"))
                context.TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown = this.TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown;
            if (ParameterWasBound("TargetTrackingScalingPolicyConfiguration_TargetValue"))
                context.TargetTrackingScalingPolicyConfiguration_TargetValue = this.TargetTrackingScalingPolicyConfiguration_TargetValue;
            
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
            var request = new Amazon.ApplicationAutoScaling.Model.PutScalingPolicyRequest();
            
            if (cmdletContext.PolicyName != null)
            {
                request.PolicyName = cmdletContext.PolicyName;
            }
            if (cmdletContext.PolicyType != null)
            {
                request.PolicyType = cmdletContext.PolicyType;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.ScalableDimension != null)
            {
                request.ScalableDimension = cmdletContext.ScalableDimension;
            }
            if (cmdletContext.ServiceNamespace != null)
            {
                request.ServiceNamespace = cmdletContext.ServiceNamespace;
            }
            
             // populate StepScalingPolicyConfiguration
            bool requestStepScalingPolicyConfigurationIsNull = true;
            request.StepScalingPolicyConfiguration = new Amazon.ApplicationAutoScaling.Model.StepScalingPolicyConfiguration();
            Amazon.ApplicationAutoScaling.AdjustmentType requestStepScalingPolicyConfiguration_stepScalingPolicyConfiguration_AdjustmentType = null;
            if (cmdletContext.StepScalingPolicyConfiguration_AdjustmentType != null)
            {
                requestStepScalingPolicyConfiguration_stepScalingPolicyConfiguration_AdjustmentType = cmdletContext.StepScalingPolicyConfiguration_AdjustmentType;
            }
            if (requestStepScalingPolicyConfiguration_stepScalingPolicyConfiguration_AdjustmentType != null)
            {
                request.StepScalingPolicyConfiguration.AdjustmentType = requestStepScalingPolicyConfiguration_stepScalingPolicyConfiguration_AdjustmentType;
                requestStepScalingPolicyConfigurationIsNull = false;
            }
            System.Int32? requestStepScalingPolicyConfiguration_stepScalingPolicyConfiguration_Cooldown = null;
            if (cmdletContext.StepScalingPolicyConfiguration_Cooldown != null)
            {
                requestStepScalingPolicyConfiguration_stepScalingPolicyConfiguration_Cooldown = cmdletContext.StepScalingPolicyConfiguration_Cooldown.Value;
            }
            if (requestStepScalingPolicyConfiguration_stepScalingPolicyConfiguration_Cooldown != null)
            {
                request.StepScalingPolicyConfiguration.Cooldown = requestStepScalingPolicyConfiguration_stepScalingPolicyConfiguration_Cooldown.Value;
                requestStepScalingPolicyConfigurationIsNull = false;
            }
            Amazon.ApplicationAutoScaling.MetricAggregationType requestStepScalingPolicyConfiguration_stepScalingPolicyConfiguration_MetricAggregationType = null;
            if (cmdletContext.StepScalingPolicyConfiguration_MetricAggregationType != null)
            {
                requestStepScalingPolicyConfiguration_stepScalingPolicyConfiguration_MetricAggregationType = cmdletContext.StepScalingPolicyConfiguration_MetricAggregationType;
            }
            if (requestStepScalingPolicyConfiguration_stepScalingPolicyConfiguration_MetricAggregationType != null)
            {
                request.StepScalingPolicyConfiguration.MetricAggregationType = requestStepScalingPolicyConfiguration_stepScalingPolicyConfiguration_MetricAggregationType;
                requestStepScalingPolicyConfigurationIsNull = false;
            }
            System.Int32? requestStepScalingPolicyConfiguration_stepScalingPolicyConfiguration_MinAdjustmentMagnitude = null;
            if (cmdletContext.StepScalingPolicyConfiguration_MinAdjustmentMagnitude != null)
            {
                requestStepScalingPolicyConfiguration_stepScalingPolicyConfiguration_MinAdjustmentMagnitude = cmdletContext.StepScalingPolicyConfiguration_MinAdjustmentMagnitude.Value;
            }
            if (requestStepScalingPolicyConfiguration_stepScalingPolicyConfiguration_MinAdjustmentMagnitude != null)
            {
                request.StepScalingPolicyConfiguration.MinAdjustmentMagnitude = requestStepScalingPolicyConfiguration_stepScalingPolicyConfiguration_MinAdjustmentMagnitude.Value;
                requestStepScalingPolicyConfigurationIsNull = false;
            }
            List<Amazon.ApplicationAutoScaling.Model.StepAdjustment> requestStepScalingPolicyConfiguration_stepScalingPolicyConfiguration_StepAdjustment = null;
            if (cmdletContext.StepScalingPolicyConfiguration_StepAdjustments != null)
            {
                requestStepScalingPolicyConfiguration_stepScalingPolicyConfiguration_StepAdjustment = cmdletContext.StepScalingPolicyConfiguration_StepAdjustments;
            }
            if (requestStepScalingPolicyConfiguration_stepScalingPolicyConfiguration_StepAdjustment != null)
            {
                request.StepScalingPolicyConfiguration.StepAdjustments = requestStepScalingPolicyConfiguration_stepScalingPolicyConfiguration_StepAdjustment;
                requestStepScalingPolicyConfigurationIsNull = false;
            }
             // determine if request.StepScalingPolicyConfiguration should be set to null
            if (requestStepScalingPolicyConfigurationIsNull)
            {
                request.StepScalingPolicyConfiguration = null;
            }
            
             // populate TargetTrackingScalingPolicyConfiguration
            bool requestTargetTrackingScalingPolicyConfigurationIsNull = true;
            request.TargetTrackingScalingPolicyConfiguration = new Amazon.ApplicationAutoScaling.Model.TargetTrackingScalingPolicyConfiguration();
            System.Int32? requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_ScaleInCooldown = null;
            if (cmdletContext.TargetTrackingScalingPolicyConfiguration_ScaleInCooldown != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_ScaleInCooldown = cmdletContext.TargetTrackingScalingPolicyConfiguration_ScaleInCooldown.Value;
            }
            if (requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_ScaleInCooldown != null)
            {
                request.TargetTrackingScalingPolicyConfiguration.ScaleInCooldown = requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_ScaleInCooldown.Value;
                requestTargetTrackingScalingPolicyConfigurationIsNull = false;
            }
            System.Int32? requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_ScaleOutCooldown = null;
            if (cmdletContext.TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_ScaleOutCooldown = cmdletContext.TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown.Value;
            }
            if (requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_ScaleOutCooldown != null)
            {
                request.TargetTrackingScalingPolicyConfiguration.ScaleOutCooldown = requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_ScaleOutCooldown.Value;
                requestTargetTrackingScalingPolicyConfigurationIsNull = false;
            }
            System.Double? requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_TargetValue = null;
            if (cmdletContext.TargetTrackingScalingPolicyConfiguration_TargetValue != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_TargetValue = cmdletContext.TargetTrackingScalingPolicyConfiguration_TargetValue.Value;
            }
            if (requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_TargetValue != null)
            {
                request.TargetTrackingScalingPolicyConfiguration.TargetValue = requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_TargetValue.Value;
                requestTargetTrackingScalingPolicyConfigurationIsNull = false;
            }
            Amazon.ApplicationAutoScaling.Model.PredefinedMetricSpecification requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification = null;
            
             // populate PredefinedMetricSpecification
            bool requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecificationIsNull = true;
            requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification = new Amazon.ApplicationAutoScaling.Model.PredefinedMetricSpecification();
            Amazon.ApplicationAutoScaling.MetricType requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_PredefinedMetricType = null;
            if (cmdletContext.TargetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_PredefinedMetricType != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_PredefinedMetricType = cmdletContext.TargetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_PredefinedMetricType;
            }
            if (requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_PredefinedMetricType != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification.PredefinedMetricType = requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_PredefinedMetricType;
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecificationIsNull = false;
            }
            System.String requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_ResourceLabel = null;
            if (cmdletContext.TargetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_ResourceLabel != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_ResourceLabel = cmdletContext.TargetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_ResourceLabel;
            }
            if (requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_ResourceLabel != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification.ResourceLabel = requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_ResourceLabel;
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecificationIsNull = false;
            }
             // determine if requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification should be set to null
            if (requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecificationIsNull)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification = null;
            }
            if (requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification != null)
            {
                request.TargetTrackingScalingPolicyConfiguration.PredefinedMetricSpecification = requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification;
                requestTargetTrackingScalingPolicyConfigurationIsNull = false;
            }
            Amazon.ApplicationAutoScaling.Model.CustomizedMetricSpecification requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification = null;
            
             // populate CustomizedMetricSpecification
            bool requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecificationIsNull = true;
            requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification = new Amazon.ApplicationAutoScaling.Model.CustomizedMetricSpecification();
            List<Amazon.ApplicationAutoScaling.Model.MetricDimension> requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Dimension = null;
            if (cmdletContext.TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Dimensions != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Dimension = cmdletContext.TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Dimensions;
            }
            if (requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Dimension != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification.Dimensions = requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Dimension;
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
            System.String requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_MetricName = null;
            if (cmdletContext.TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_MetricName != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_MetricName = cmdletContext.TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_MetricName;
            }
            if (requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_MetricName != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification.MetricName = requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_MetricName;
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
            System.String requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Namespace = null;
            if (cmdletContext.TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Namespace != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Namespace = cmdletContext.TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Namespace;
            }
            if (requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Namespace != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification.Namespace = requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Namespace;
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
            Amazon.ApplicationAutoScaling.MetricStatistic requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Statistic = null;
            if (cmdletContext.TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Statistic != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Statistic = cmdletContext.TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Statistic;
            }
            if (requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Statistic != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification.Statistic = requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Statistic;
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
            System.String requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Unit = null;
            if (cmdletContext.TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Unit != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Unit = cmdletContext.TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Unit;
            }
            if (requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Unit != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification.Unit = requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Unit;
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
             // determine if requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification should be set to null
            if (requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecificationIsNull)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification = null;
            }
            if (requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification != null)
            {
                request.TargetTrackingScalingPolicyConfiguration.CustomizedMetricSpecification = requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification;
                requestTargetTrackingScalingPolicyConfigurationIsNull = false;
            }
             // determine if request.TargetTrackingScalingPolicyConfiguration should be set to null
            if (requestTargetTrackingScalingPolicyConfigurationIsNull)
            {
                request.TargetTrackingScalingPolicyConfiguration = null;
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
        
        private Amazon.ApplicationAutoScaling.Model.PutScalingPolicyResponse CallAWSServiceOperation(IAmazonApplicationAutoScaling client, Amazon.ApplicationAutoScaling.Model.PutScalingPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Auto Scaling", "PutScalingPolicy");
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
            public System.String PolicyName { get; set; }
            public Amazon.ApplicationAutoScaling.PolicyType PolicyType { get; set; }
            public System.String ResourceId { get; set; }
            public Amazon.ApplicationAutoScaling.ScalableDimension ScalableDimension { get; set; }
            public Amazon.ApplicationAutoScaling.ServiceNamespace ServiceNamespace { get; set; }
            public Amazon.ApplicationAutoScaling.AdjustmentType StepScalingPolicyConfiguration_AdjustmentType { get; set; }
            public System.Int32? StepScalingPolicyConfiguration_Cooldown { get; set; }
            public Amazon.ApplicationAutoScaling.MetricAggregationType StepScalingPolicyConfiguration_MetricAggregationType { get; set; }
            public System.Int32? StepScalingPolicyConfiguration_MinAdjustmentMagnitude { get; set; }
            public List<Amazon.ApplicationAutoScaling.Model.StepAdjustment> StepScalingPolicyConfiguration_StepAdjustments { get; set; }
            public List<Amazon.ApplicationAutoScaling.Model.MetricDimension> TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Dimensions { get; set; }
            public System.String TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_MetricName { get; set; }
            public System.String TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Namespace { get; set; }
            public Amazon.ApplicationAutoScaling.MetricStatistic TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Statistic { get; set; }
            public System.String TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Unit { get; set; }
            public Amazon.ApplicationAutoScaling.MetricType TargetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_PredefinedMetricType { get; set; }
            public System.String TargetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_ResourceLabel { get; set; }
            public System.Int32? TargetTrackingScalingPolicyConfiguration_ScaleInCooldown { get; set; }
            public System.Int32? TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown { get; set; }
            public System.Double? TargetTrackingScalingPolicyConfiguration_TargetValue { get; set; }
        }
        
    }
}
