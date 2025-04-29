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
using Amazon.ApplicationAutoScaling;
using Amazon.ApplicationAutoScaling.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AAS
{
    /// <summary>
    /// Creates or updates a scaling policy for an Application Auto Scaling scalable target.
    /// 
    ///  
    /// <para>
    /// Each scalable target is identified by a service namespace, resource ID, and scalable
    /// dimension. A scaling policy applies to the scalable target identified by those three
    /// attributes. You cannot create a scaling policy until you have registered the resource
    /// as a scalable target.
    /// </para><para>
    /// Multiple scaling policies can be in force at the same time for the same scalable target.
    /// You can have one or more target tracking scaling policies, one or more step scaling
    /// policies, or both. However, there is a chance that multiple policies could conflict,
    /// instructing the scalable target to scale out or in at the same time. Application Auto
    /// Scaling gives precedence to the policy that provides the largest capacity for both
    /// scale out and scale in. For example, if one policy increases capacity by 3, another
    /// policy increases capacity by 200 percent, and the current capacity is 10, Application
    /// Auto Scaling uses the policy with the highest calculated capacity (200% of 10 = 20)
    /// and scales out to 30. 
    /// </para><para>
    /// We recommend caution, however, when using target tracking scaling policies with step
    /// scaling policies because conflicts between these policies can cause undesirable behavior.
    /// For example, if the step scaling policy initiates a scale-in activity before the target
    /// tracking policy is ready to scale in, the scale-in activity will not be blocked. After
    /// the scale-in activity completes, the target tracking policy could instruct the scalable
    /// target to scale out again. 
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/autoscaling/application/userguide/application-auto-scaling-target-tracking.html">Target
    /// tracking scaling policies</a>, <a href="https://docs.aws.amazon.com/autoscaling/application/userguide/application-auto-scaling-step-scaling-policies.html">Step
    /// scaling policies</a>, and <a href="https://docs.aws.amazon.com/autoscaling/application/userguide/aas-create-predictive-scaling-policy.html">Predictive
    /// scaling policies</a> in the <i>Application Auto Scaling User Guide</i>.
    /// </para><note><para>
    /// If a scalable target is deregistered, the scalable target is no longer available to
    /// use scaling policies. Any scaling policies that were specified for the scalable target
    /// are deleted.
    /// </para></note>
    /// </summary>
    [Cmdlet("Set", "AASScalingPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApplicationAutoScaling.Model.PutScalingPolicyResponse")]
    [AWSCmdlet("Calls the Application Auto Scaling PutScalingPolicy API operation.", Operation = new[] {"PutScalingPolicy"}, SelectReturnType = typeof(Amazon.ApplicationAutoScaling.Model.PutScalingPolicyResponse), LegacyAlias="Write-AASScalingPolicy")]
    [AWSCmdletOutput("Amazon.ApplicationAutoScaling.Model.PutScalingPolicyResponse",
        "This cmdlet returns an Amazon.ApplicationAutoScaling.Model.PutScalingPolicyResponse object containing multiple properties."
    )]
    public partial class SetAASScalingPolicyCmdlet : AmazonApplicationAutoScalingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter StepScalingPolicyConfiguration_AdjustmentType
        /// <summary>
        /// <para>
        /// <para>Specifies how the <c>ScalingAdjustment</c> value in a <a href="https://docs.aws.amazon.com/autoscaling/application/APIReference/API_StepAdjustment.html">StepAdjustment</a>
        /// is interpreted (for example, an absolute number or a percentage). The valid values
        /// are <c>ChangeInCapacity</c>, <c>ExactCapacity</c>, and <c>PercentChangeInCapacity</c>.
        /// </para><para><c>AdjustmentType</c> is required if you are adding a new step scaling policy configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.AdjustmentType")]
        public Amazon.ApplicationAutoScaling.AdjustmentType StepScalingPolicyConfiguration_AdjustmentType { get; set; }
        #endregion
        
        #region Parameter StepScalingPolicyConfiguration_Cooldown
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, to wait for a previous scaling activity to take effect.
        /// If not specified, the default value is 300. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/application/userguide/step-scaling-policy-overview.html#step-scaling-cooldown">Cooldown
        /// period</a> in the <i>Application Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StepScalingPolicyConfiguration_Cooldown { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_Dimension
        /// <summary>
        /// <para>
        /// <para>The dimensions of the metric. </para><para>Conditional: If you published your metric with dimensions, you must specify the same
        /// dimensions in your scaling policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Dimensions")]
        public Amazon.ApplicationAutoScaling.Model.MetricDimension[] CustomizedMetricSpecification_Dimension { get; set; }
        #endregion
        
        #region Parameter TargetTrackingScalingPolicyConfiguration_DisableScaleIn
        /// <summary>
        /// <para>
        /// <para>Indicates whether scale in by the target tracking scaling policy is disabled. If the
        /// value is <c>true</c>, scale in is disabled and the target tracking scaling policy
        /// won't remove capacity from the scalable target. Otherwise, scale in is enabled and
        /// the target tracking scaling policy can remove capacity from the scalable target. The
        /// default value is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TargetTrackingScalingPolicyConfiguration_DisableScaleIn { get; set; }
        #endregion
        
        #region Parameter PredictiveScalingPolicyConfiguration_MaxCapacityBreachBehavior
        /// <summary>
        /// <para>
        /// <para> Defines the behavior that should be applied if the forecast capacity approaches or
        /// exceeds the maximum capacity. Defaults to <c>HonorMaxCapacity</c> if not specified.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.PredictiveScalingMaxCapacityBreachBehavior")]
        public Amazon.ApplicationAutoScaling.PredictiveScalingMaxCapacityBreachBehavior PredictiveScalingPolicyConfiguration_MaxCapacityBreachBehavior { get; set; }
        #endregion
        
        #region Parameter PredictiveScalingPolicyConfiguration_MaxCapacityBuffer
        /// <summary>
        /// <para>
        /// <para> The size of the capacity buffer to use when the forecast capacity is close to or
        /// exceeds the maximum capacity. The value is specified as a percentage relative to the
        /// forecast capacity. For example, if the buffer is 10, this means a 10 percent buffer,
        /// such that if the forecast capacity is 50, and the maximum capacity is 40, then the
        /// effective maximum capacity is 55. </para><para>Required if the <c>MaxCapacityBreachBehavior</c> property is set to <c>IncreaseMaxCapacity</c>,
        /// and cannot be used otherwise.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PredictiveScalingPolicyConfiguration_MaxCapacityBuffer { get; set; }
        #endregion
        
        #region Parameter StepScalingPolicyConfiguration_MetricAggregationType
        /// <summary>
        /// <para>
        /// <para>The aggregation type for the CloudWatch metrics. Valid values are <c>Minimum</c>,
        /// <c>Maximum</c>, and <c>Average</c>. If the aggregation type is null, the value is
        /// treated as <c>Average</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.MetricAggregationType")]
        public Amazon.ApplicationAutoScaling.MetricAggregationType StepScalingPolicyConfiguration_MetricAggregationType { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_MetricName
        /// <summary>
        /// <para>
        /// <para>The name of the metric. To get the exact metric name, namespace, and dimensions, inspect
        /// the <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_Metric.html">Metric</a>
        /// object that's returned by a call to <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_ListMetrics.html">ListMetrics</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_MetricName")]
        public System.String CustomizedMetricSpecification_MetricName { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_Metric
        /// <summary>
        /// <para>
        /// <para>The metrics to include in the target tracking scaling policy, as a metric data query.
        /// This can include both raw metric and metric math expressions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Metrics")]
        public Amazon.ApplicationAutoScaling.Model.TargetTrackingMetricDataQuery[] CustomizedMetricSpecification_Metric { get; set; }
        #endregion
        
        #region Parameter PredictiveScalingPolicyConfiguration_MetricSpecification
        /// <summary>
        /// <para>
        /// <para> This structure includes the metrics and target utilization to use for predictive
        /// scaling. </para><para>This is an array, but we currently only support a single metric specification. That
        /// is, you can specify a target value and a single metric pair, or a target value and
        /// one scaling metric and one load metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PredictiveScalingPolicyConfiguration_MetricSpecifications")]
        public Amazon.ApplicationAutoScaling.Model.PredictiveScalingMetricSpecification[] PredictiveScalingPolicyConfiguration_MetricSpecification { get; set; }
        #endregion
        
        #region Parameter StepScalingPolicyConfiguration_MinAdjustmentMagnitude
        /// <summary>
        /// <para>
        /// <para>The minimum value to scale by when the adjustment type is <c>PercentChangeInCapacity</c>.
        /// For example, suppose that you create a step scaling policy to scale out an Amazon
        /// ECS service by 25 percent and you specify a <c>MinAdjustmentMagnitude</c> of 2. If
        /// the service has 4 tasks and the scaling policy is performed, 25 percent of 4 is 1.
        /// However, because you specified a <c>MinAdjustmentMagnitude</c> of 2, Application Auto
        /// Scaling scales out the service by 2 tasks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StepScalingPolicyConfiguration_MinAdjustmentMagnitude { get; set; }
        #endregion
        
        #region Parameter PredictiveScalingPolicyConfiguration_Mode
        /// <summary>
        /// <para>
        /// <para> The predictive scaling mode. Defaults to <c>ForecastOnly</c> if not specified. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.PredictiveScalingMode")]
        public Amazon.ApplicationAutoScaling.PredictiveScalingMode PredictiveScalingPolicyConfiguration_Mode { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Namespace")]
        public System.String CustomizedMetricSpecification_Namespace { get; set; }
        #endregion
        
        #region Parameter PolicyName
        /// <summary>
        /// <para>
        /// <para>The name of the scaling policy.</para><para>You cannot change the name of a scaling policy, but you can delete the original scaling
        /// policy and create a new scaling policy with the same settings and a different name.</para>
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
        public System.String PolicyName { get; set; }
        #endregion
        
        #region Parameter PolicyType
        /// <summary>
        /// <para>
        /// <para>The scaling policy type. This parameter is required if you are creating a scaling
        /// policy.</para><para>The following policy types are supported: </para><para><c>TargetTrackingScaling</c>—Not supported for Amazon EMR.</para><para><c>StepScaling</c>—Not supported for DynamoDB, Amazon Comprehend, Lambda, Amazon
        /// Keyspaces, Amazon MSK, Amazon ElastiCache, or Neptune.</para><para><c>PredictiveScaling</c>—Only supported for Amazon ECS.</para><para>For more information, see <a href="https://docs.aws.amazon.com/autoscaling/application/userguide/application-auto-scaling-target-tracking.html">Target
        /// tracking scaling policies</a>, <a href="https://docs.aws.amazon.com/autoscaling/application/userguide/application-auto-scaling-step-scaling-policies.html">Step
        /// scaling policies</a>, and <a href="https://docs.aws.amazon.com/autoscaling/application/userguide/aas-create-predictive-scaling-policy.html">Predictive
        /// scaling policies</a> in the <i>Application Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.PolicyType")]
        public Amazon.ApplicationAutoScaling.PolicyType PolicyType { get; set; }
        #endregion
        
        #region Parameter PredefinedMetricSpecification_PredefinedMetricType
        /// <summary>
        /// <para>
        /// <para>The metric type. The <c>ALBRequestCountPerTarget</c> metric type applies only to Spot
        /// Fleets and ECS services.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_PredefinedMetricType")]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.MetricType")]
        public Amazon.ApplicationAutoScaling.MetricType PredefinedMetricSpecification_PredefinedMetricType { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the resource associated with the scaling policy. This string consists
        /// of the resource type and unique identifier.</para><ul><li><para>ECS service - The resource type is <c>service</c> and the unique identifier is the
        /// cluster name and service name. Example: <c>service/my-cluster/my-service</c>.</para></li><li><para>Spot Fleet - The resource type is <c>spot-fleet-request</c> and the unique identifier
        /// is the Spot Fleet request ID. Example: <c>spot-fleet-request/sfr-73fbd2ce-aa30-494c-8788-1cee4EXAMPLE</c>.</para></li><li><para>EMR cluster - The resource type is <c>instancegroup</c> and the unique identifier
        /// is the cluster ID and instance group ID. Example: <c>instancegroup/j-2EEZNYKUA1NTV/ig-1791Y4E1L8YI0</c>.</para></li><li><para>AppStream 2.0 fleet - The resource type is <c>fleet</c> and the unique identifier
        /// is the fleet name. Example: <c>fleet/sample-fleet</c>.</para></li><li><para>DynamoDB table - The resource type is <c>table</c> and the unique identifier is the
        /// table name. Example: <c>table/my-table</c>.</para></li><li><para>DynamoDB global secondary index - The resource type is <c>index</c> and the unique
        /// identifier is the index name. Example: <c>table/my-table/index/my-table-index</c>.</para></li><li><para>Aurora DB cluster - The resource type is <c>cluster</c> and the unique identifier
        /// is the cluster name. Example: <c>cluster:my-db-cluster</c>.</para></li><li><para>SageMaker endpoint variant - The resource type is <c>variant</c> and the unique identifier
        /// is the resource ID. Example: <c>endpoint/my-end-point/variant/KMeansClustering</c>.</para></li><li><para>Custom resources are not supported with a resource type. This parameter must specify
        /// the <c>OutputValue</c> from the CloudFormation template stack used to access the resources.
        /// The unique identifier is defined by the service provider. More information is available
        /// in our <a href="https://github.com/aws/aws-auto-scaling-custom-resource">GitHub repository</a>.</para></li><li><para>Amazon Comprehend document classification endpoint - The resource type and unique
        /// identifier are specified using the endpoint ARN. Example: <c>arn:aws:comprehend:us-west-2:123456789012:document-classifier-endpoint/EXAMPLE</c>.</para></li><li><para>Amazon Comprehend entity recognizer endpoint - The resource type and unique identifier
        /// are specified using the endpoint ARN. Example: <c>arn:aws:comprehend:us-west-2:123456789012:entity-recognizer-endpoint/EXAMPLE</c>.</para></li><li><para>Lambda provisioned concurrency - The resource type is <c>function</c> and the unique
        /// identifier is the function name with a function version or alias name suffix that
        /// is not <c>$LATEST</c>. Example: <c>function:my-function:prod</c> or <c>function:my-function:1</c>.</para></li><li><para>Amazon Keyspaces table - The resource type is <c>table</c> and the unique identifier
        /// is the table name. Example: <c>keyspace/mykeyspace/table/mytable</c>.</para></li><li><para>Amazon MSK cluster - The resource type and unique identifier are specified using the
        /// cluster ARN. Example: <c>arn:aws:kafka:us-east-1:123456789012:cluster/demo-cluster-1/6357e0b2-0e6a-4b86-a0b4-70df934c2e31-5</c>.</para></li><li><para>Amazon ElastiCache replication group - The resource type is <c>replication-group</c>
        /// and the unique identifier is the replication group name. Example: <c>replication-group/mycluster</c>.</para></li><li><para>Amazon ElastiCache cache cluster - The resource type is <c>cache-cluster</c> and the
        /// unique identifier is the cache cluster name. Example: <c>cache-cluster/mycluster</c>.</para></li><li><para>Neptune cluster - The resource type is <c>cluster</c> and the unique identifier is
        /// the cluster name. Example: <c>cluster:mycluster</c>.</para></li><li><para>SageMaker serverless endpoint - The resource type is <c>variant</c> and the unique
        /// identifier is the resource ID. Example: <c>endpoint/my-end-point/variant/KMeansClustering</c>.</para></li><li><para>SageMaker inference component - The resource type is <c>inference-component</c> and
        /// the unique identifier is the resource ID. Example: <c>inference-component/my-inference-component</c>.</para></li><li><para>Pool of WorkSpaces - The resource type is <c>workspacespool</c> and the unique identifier
        /// is the pool ID. Example: <c>workspacespool/wspool-123456</c>.</para></li></ul>
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
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter PredefinedMetricSpecification_ResourceLabel
        /// <summary>
        /// <para>
        /// <para>Identifies the resource associated with the metric type. You can't specify a resource
        /// label unless the metric type is <c>ALBRequestCountPerTarget</c> and there is a target
        /// group attached to the Spot Fleet or ECS service.</para><para>You create the resource label by appending the final portion of the load balancer
        /// ARN and the final portion of the target group ARN into a single value, separated by
        /// a forward slash (/). The format of the resource label is:</para><para><c>app/my-alb/778d41231b141a0f/targetgroup/my-alb-target-group/943f017f100becff</c>.</para><para>Where:</para><ul><li><para>app/&lt;load-balancer-name&gt;/&lt;load-balancer-id&gt; is the final portion of the
        /// load balancer ARN</para></li><li><para>targetgroup/&lt;target-group-name&gt;/&lt;target-group-id&gt; is the final portion
        /// of the target group ARN.</para></li></ul><para>To find the ARN for an Application Load Balancer, use the <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/APIReference/API_DescribeLoadBalancers.html">DescribeLoadBalancers</a>
        /// API operation. To find the ARN for the target group, use the <a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/APIReference/API_DescribeTargetGroups.html">DescribeTargetGroups</a>
        /// API operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_ResourceLabel")]
        public System.String PredefinedMetricSpecification_ResourceLabel { get; set; }
        #endregion
        
        #region Parameter ScalableDimension
        /// <summary>
        /// <para>
        /// <para>The scalable dimension. This string consists of the service namespace, resource type,
        /// and scaling property.</para><ul><li><para><c>ecs:service:DesiredCount</c> - The task count of an ECS service.</para></li><li><para><c>elasticmapreduce:instancegroup:InstanceCount</c> - The instance count of an EMR
        /// Instance Group.</para></li><li><para><c>ec2:spot-fleet-request:TargetCapacity</c> - The target capacity of a Spot Fleet.</para></li><li><para><c>appstream:fleet:DesiredCapacity</c> - The capacity of an AppStream 2.0 fleet.</para></li><li><para><c>dynamodb:table:ReadCapacityUnits</c> - The provisioned read capacity for a DynamoDB
        /// table.</para></li><li><para><c>dynamodb:table:WriteCapacityUnits</c> - The provisioned write capacity for a DynamoDB
        /// table.</para></li><li><para><c>dynamodb:index:ReadCapacityUnits</c> - The provisioned read capacity for a DynamoDB
        /// global secondary index.</para></li><li><para><c>dynamodb:index:WriteCapacityUnits</c> - The provisioned write capacity for a DynamoDB
        /// global secondary index.</para></li><li><para><c>rds:cluster:ReadReplicaCount</c> - The count of Aurora Replicas in an Aurora DB
        /// cluster. Available for Aurora MySQL-compatible edition and Aurora PostgreSQL-compatible
        /// edition.</para></li><li><para><c>sagemaker:variant:DesiredInstanceCount</c> - The number of EC2 instances for a
        /// SageMaker model endpoint variant.</para></li><li><para><c>custom-resource:ResourceType:Property</c> - The scalable dimension for a custom
        /// resource provided by your own application or service.</para></li><li><para><c>comprehend:document-classifier-endpoint:DesiredInferenceUnits</c> - The number
        /// of inference units for an Amazon Comprehend document classification endpoint.</para></li><li><para><c>comprehend:entity-recognizer-endpoint:DesiredInferenceUnits</c> - The number of
        /// inference units for an Amazon Comprehend entity recognizer endpoint.</para></li><li><para><c>lambda:function:ProvisionedConcurrency</c> - The provisioned concurrency for a
        /// Lambda function.</para></li><li><para><c>cassandra:table:ReadCapacityUnits</c> - The provisioned read capacity for an Amazon
        /// Keyspaces table.</para></li><li><para><c>cassandra:table:WriteCapacityUnits</c> - The provisioned write capacity for an
        /// Amazon Keyspaces table.</para></li><li><para><c>kafka:broker-storage:VolumeSize</c> - The provisioned volume size (in GiB) for
        /// brokers in an Amazon MSK cluster.</para></li><li><para><c>elasticache:cache-cluster:Nodes</c> - The number of nodes for an Amazon ElastiCache
        /// cache cluster.</para></li><li><para><c>elasticache:replication-group:NodeGroups</c> - The number of node groups for an
        /// Amazon ElastiCache replication group.</para></li><li><para><c>elasticache:replication-group:Replicas</c> - The number of replicas per node group
        /// for an Amazon ElastiCache replication group.</para></li><li><para><c>neptune:cluster:ReadReplicaCount</c> - The count of read replicas in an Amazon
        /// Neptune DB cluster.</para></li><li><para><c>sagemaker:variant:DesiredProvisionedConcurrency</c> - The provisioned concurrency
        /// for a SageMaker serverless endpoint.</para></li><li><para><c>sagemaker:inference-component:DesiredCopyCount</c> - The number of copies across
        /// an endpoint for a SageMaker inference component.</para></li><li><para><c>workspaces:workspacespool:DesiredUserSessions</c> - The number of user sessions
        /// for the WorkSpaces in the pool.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.ScalableDimension")]
        public Amazon.ApplicationAutoScaling.ScalableDimension ScalableDimension { get; set; }
        #endregion
        
        #region Parameter TargetTrackingScalingPolicyConfiguration_ScaleInCooldown
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, after a scale-in activity completes before another
        /// scale-in activity can start. For more information and for default values, see <a href="https://docs.aws.amazon.com/autoscaling/application/userguide/target-tracking-scaling-policy-overview.html#target-tracking-cooldown">Define
        /// cooldown periods</a> in the <i>Application Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TargetTrackingScalingPolicyConfiguration_ScaleInCooldown { get; set; }
        #endregion
        
        #region Parameter TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, to wait for a previous scale-out activity to take
        /// effect. For more information and for default values, see <a href="https://docs.aws.amazon.com/autoscaling/application/userguide/target-tracking-scaling-policy-overview.html#target-tracking-cooldown">Define
        /// cooldown periods</a> in the <i>Application Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown { get; set; }
        #endregion
        
        #region Parameter PredictiveScalingPolicyConfiguration_SchedulingBufferTime
        /// <summary>
        /// <para>
        /// <para> The amount of time, in seconds, that the start time can be advanced. </para><para>The value must be less than the forecast interval duration of 3600 seconds (60 minutes).
        /// Defaults to 300 seconds if not specified. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PredictiveScalingPolicyConfiguration_SchedulingBufferTime { get; set; }
        #endregion
        
        #region Parameter ServiceNamespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the Amazon Web Services service that provides the resource. For a
        /// resource provided by your own application or service, use <c>custom-resource</c> instead.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.ServiceNamespace")]
        public Amazon.ApplicationAutoScaling.ServiceNamespace ServiceNamespace { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_Statistic
        /// <summary>
        /// <para>
        /// <para>The statistic of the metric.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Statistic")]
        [AWSConstantClassSource("Amazon.ApplicationAutoScaling.MetricStatistic")]
        public Amazon.ApplicationAutoScaling.MetricStatistic CustomizedMetricSpecification_Statistic { get; set; }
        #endregion
        
        #region Parameter StepScalingPolicyConfiguration_StepAdjustment
        /// <summary>
        /// <para>
        /// <para>A set of adjustments that enable you to scale based on the size of the alarm breach.</para><para>At least one step adjustment is required if you are adding a new step scaling policy
        /// configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StepScalingPolicyConfiguration_StepAdjustments")]
        public Amazon.ApplicationAutoScaling.Model.StepAdjustment[] StepScalingPolicyConfiguration_StepAdjustment { get; set; }
        #endregion
        
        #region Parameter TargetTrackingScalingPolicyConfiguration_TargetValue
        /// <summary>
        /// <para>
        /// <para>The target value for the metric. Although this property accepts numbers of type Double,
        /// it won't accept values that are either too small or too large. Values must be in the
        /// range of -2^360 to 2^360. The value must be a valid number based on the choice of
        /// metric. For example, if the metric is CPU utilization, then the target value is a
        /// percent value that represents how much of the CPU can be used before scaling out.
        /// </para><note><para>If the scaling policy specifies the <c>ALBRequestCountPerTarget</c> predefined metric,
        /// specify the target utilization as the optimal average request count per target during
        /// any one-minute interval.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? TargetTrackingScalingPolicyConfiguration_TargetValue { get; set; }
        #endregion
        
        #region Parameter CustomizedMetricSpecification_Unit
        /// <summary>
        /// <para>
        /// <para>The unit of the metric. For a complete list of the units that CloudWatch supports,
        /// see the <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_MetricDatum.html">MetricDatum</a>
        /// data type in the <i>Amazon CloudWatch API Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_Unit")]
        public System.String CustomizedMetricSpecification_Unit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationAutoScaling.Model.PutScalingPolicyResponse).
        /// Specifying the name of a property of type Amazon.ApplicationAutoScaling.Model.PutScalingPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PolicyName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-AASScalingPolicy (PutScalingPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationAutoScaling.Model.PutScalingPolicyResponse, SetAASScalingPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.PolicyName = this.PolicyName;
            #if MODULAR
            if (this.PolicyName == null && ParameterWasBound(nameof(this.PolicyName)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyType = this.PolicyType;
            context.PredictiveScalingPolicyConfiguration_MaxCapacityBreachBehavior = this.PredictiveScalingPolicyConfiguration_MaxCapacityBreachBehavior;
            context.PredictiveScalingPolicyConfiguration_MaxCapacityBuffer = this.PredictiveScalingPolicyConfiguration_MaxCapacityBuffer;
            if (this.PredictiveScalingPolicyConfiguration_MetricSpecification != null)
            {
                context.PredictiveScalingPolicyConfiguration_MetricSpecification = new List<Amazon.ApplicationAutoScaling.Model.PredictiveScalingMetricSpecification>(this.PredictiveScalingPolicyConfiguration_MetricSpecification);
            }
            context.PredictiveScalingPolicyConfiguration_Mode = this.PredictiveScalingPolicyConfiguration_Mode;
            context.PredictiveScalingPolicyConfiguration_SchedulingBufferTime = this.PredictiveScalingPolicyConfiguration_SchedulingBufferTime;
            context.ResourceId = this.ResourceId;
            #if MODULAR
            if (this.ResourceId == null && ParameterWasBound(nameof(this.ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScalableDimension = this.ScalableDimension;
            #if MODULAR
            if (this.ScalableDimension == null && ParameterWasBound(nameof(this.ScalableDimension)))
            {
                WriteWarning("You are passing $null as a value for parameter ScalableDimension which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceNamespace = this.ServiceNamespace;
            #if MODULAR
            if (this.ServiceNamespace == null && ParameterWasBound(nameof(this.ServiceNamespace)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceNamespace which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StepScalingPolicyConfiguration_AdjustmentType = this.StepScalingPolicyConfiguration_AdjustmentType;
            context.StepScalingPolicyConfiguration_Cooldown = this.StepScalingPolicyConfiguration_Cooldown;
            context.StepScalingPolicyConfiguration_MetricAggregationType = this.StepScalingPolicyConfiguration_MetricAggregationType;
            context.StepScalingPolicyConfiguration_MinAdjustmentMagnitude = this.StepScalingPolicyConfiguration_MinAdjustmentMagnitude;
            if (this.StepScalingPolicyConfiguration_StepAdjustment != null)
            {
                context.StepScalingPolicyConfiguration_StepAdjustment = new List<Amazon.ApplicationAutoScaling.Model.StepAdjustment>(this.StepScalingPolicyConfiguration_StepAdjustment);
            }
            if (this.CustomizedMetricSpecification_Dimension != null)
            {
                context.CustomizedMetricSpecification_Dimension = new List<Amazon.ApplicationAutoScaling.Model.MetricDimension>(this.CustomizedMetricSpecification_Dimension);
            }
            context.CustomizedMetricSpecification_MetricName = this.CustomizedMetricSpecification_MetricName;
            if (this.CustomizedMetricSpecification_Metric != null)
            {
                context.CustomizedMetricSpecification_Metric = new List<Amazon.ApplicationAutoScaling.Model.TargetTrackingMetricDataQuery>(this.CustomizedMetricSpecification_Metric);
            }
            context.CustomizedMetricSpecification_Namespace = this.CustomizedMetricSpecification_Namespace;
            context.CustomizedMetricSpecification_Statistic = this.CustomizedMetricSpecification_Statistic;
            context.CustomizedMetricSpecification_Unit = this.CustomizedMetricSpecification_Unit;
            context.TargetTrackingScalingPolicyConfiguration_DisableScaleIn = this.TargetTrackingScalingPolicyConfiguration_DisableScaleIn;
            context.PredefinedMetricSpecification_PredefinedMetricType = this.PredefinedMetricSpecification_PredefinedMetricType;
            context.PredefinedMetricSpecification_ResourceLabel = this.PredefinedMetricSpecification_ResourceLabel;
            context.TargetTrackingScalingPolicyConfiguration_ScaleInCooldown = this.TargetTrackingScalingPolicyConfiguration_ScaleInCooldown;
            context.TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown = this.TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown;
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
            
             // populate PredictiveScalingPolicyConfiguration
            var requestPredictiveScalingPolicyConfigurationIsNull = true;
            request.PredictiveScalingPolicyConfiguration = new Amazon.ApplicationAutoScaling.Model.PredictiveScalingPolicyConfiguration();
            Amazon.ApplicationAutoScaling.PredictiveScalingMaxCapacityBreachBehavior requestPredictiveScalingPolicyConfiguration_predictiveScalingPolicyConfiguration_MaxCapacityBreachBehavior = null;
            if (cmdletContext.PredictiveScalingPolicyConfiguration_MaxCapacityBreachBehavior != null)
            {
                requestPredictiveScalingPolicyConfiguration_predictiveScalingPolicyConfiguration_MaxCapacityBreachBehavior = cmdletContext.PredictiveScalingPolicyConfiguration_MaxCapacityBreachBehavior;
            }
            if (requestPredictiveScalingPolicyConfiguration_predictiveScalingPolicyConfiguration_MaxCapacityBreachBehavior != null)
            {
                request.PredictiveScalingPolicyConfiguration.MaxCapacityBreachBehavior = requestPredictiveScalingPolicyConfiguration_predictiveScalingPolicyConfiguration_MaxCapacityBreachBehavior;
                requestPredictiveScalingPolicyConfigurationIsNull = false;
            }
            System.Int32? requestPredictiveScalingPolicyConfiguration_predictiveScalingPolicyConfiguration_MaxCapacityBuffer = null;
            if (cmdletContext.PredictiveScalingPolicyConfiguration_MaxCapacityBuffer != null)
            {
                requestPredictiveScalingPolicyConfiguration_predictiveScalingPolicyConfiguration_MaxCapacityBuffer = cmdletContext.PredictiveScalingPolicyConfiguration_MaxCapacityBuffer.Value;
            }
            if (requestPredictiveScalingPolicyConfiguration_predictiveScalingPolicyConfiguration_MaxCapacityBuffer != null)
            {
                request.PredictiveScalingPolicyConfiguration.MaxCapacityBuffer = requestPredictiveScalingPolicyConfiguration_predictiveScalingPolicyConfiguration_MaxCapacityBuffer.Value;
                requestPredictiveScalingPolicyConfigurationIsNull = false;
            }
            List<Amazon.ApplicationAutoScaling.Model.PredictiveScalingMetricSpecification> requestPredictiveScalingPolicyConfiguration_predictiveScalingPolicyConfiguration_MetricSpecification = null;
            if (cmdletContext.PredictiveScalingPolicyConfiguration_MetricSpecification != null)
            {
                requestPredictiveScalingPolicyConfiguration_predictiveScalingPolicyConfiguration_MetricSpecification = cmdletContext.PredictiveScalingPolicyConfiguration_MetricSpecification;
            }
            if (requestPredictiveScalingPolicyConfiguration_predictiveScalingPolicyConfiguration_MetricSpecification != null)
            {
                request.PredictiveScalingPolicyConfiguration.MetricSpecifications = requestPredictiveScalingPolicyConfiguration_predictiveScalingPolicyConfiguration_MetricSpecification;
                requestPredictiveScalingPolicyConfigurationIsNull = false;
            }
            Amazon.ApplicationAutoScaling.PredictiveScalingMode requestPredictiveScalingPolicyConfiguration_predictiveScalingPolicyConfiguration_Mode = null;
            if (cmdletContext.PredictiveScalingPolicyConfiguration_Mode != null)
            {
                requestPredictiveScalingPolicyConfiguration_predictiveScalingPolicyConfiguration_Mode = cmdletContext.PredictiveScalingPolicyConfiguration_Mode;
            }
            if (requestPredictiveScalingPolicyConfiguration_predictiveScalingPolicyConfiguration_Mode != null)
            {
                request.PredictiveScalingPolicyConfiguration.Mode = requestPredictiveScalingPolicyConfiguration_predictiveScalingPolicyConfiguration_Mode;
                requestPredictiveScalingPolicyConfigurationIsNull = false;
            }
            System.Int32? requestPredictiveScalingPolicyConfiguration_predictiveScalingPolicyConfiguration_SchedulingBufferTime = null;
            if (cmdletContext.PredictiveScalingPolicyConfiguration_SchedulingBufferTime != null)
            {
                requestPredictiveScalingPolicyConfiguration_predictiveScalingPolicyConfiguration_SchedulingBufferTime = cmdletContext.PredictiveScalingPolicyConfiguration_SchedulingBufferTime.Value;
            }
            if (requestPredictiveScalingPolicyConfiguration_predictiveScalingPolicyConfiguration_SchedulingBufferTime != null)
            {
                request.PredictiveScalingPolicyConfiguration.SchedulingBufferTime = requestPredictiveScalingPolicyConfiguration_predictiveScalingPolicyConfiguration_SchedulingBufferTime.Value;
                requestPredictiveScalingPolicyConfigurationIsNull = false;
            }
             // determine if request.PredictiveScalingPolicyConfiguration should be set to null
            if (requestPredictiveScalingPolicyConfigurationIsNull)
            {
                request.PredictiveScalingPolicyConfiguration = null;
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
            var requestStepScalingPolicyConfigurationIsNull = true;
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
            if (cmdletContext.StepScalingPolicyConfiguration_StepAdjustment != null)
            {
                requestStepScalingPolicyConfiguration_stepScalingPolicyConfiguration_StepAdjustment = cmdletContext.StepScalingPolicyConfiguration_StepAdjustment;
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
            var requestTargetTrackingScalingPolicyConfigurationIsNull = true;
            request.TargetTrackingScalingPolicyConfiguration = new Amazon.ApplicationAutoScaling.Model.TargetTrackingScalingPolicyConfiguration();
            System.Boolean? requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_DisableScaleIn = null;
            if (cmdletContext.TargetTrackingScalingPolicyConfiguration_DisableScaleIn != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_DisableScaleIn = cmdletContext.TargetTrackingScalingPolicyConfiguration_DisableScaleIn.Value;
            }
            if (requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_DisableScaleIn != null)
            {
                request.TargetTrackingScalingPolicyConfiguration.DisableScaleIn = requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_DisableScaleIn.Value;
                requestTargetTrackingScalingPolicyConfigurationIsNull = false;
            }
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
            var requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecificationIsNull = true;
            requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification = new Amazon.ApplicationAutoScaling.Model.PredefinedMetricSpecification();
            Amazon.ApplicationAutoScaling.MetricType requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_PredefinedMetricType = null;
            if (cmdletContext.PredefinedMetricSpecification_PredefinedMetricType != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_PredefinedMetricType = cmdletContext.PredefinedMetricSpecification_PredefinedMetricType;
            }
            if (requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_PredefinedMetricType != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification.PredefinedMetricType = requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_PredefinedMetricType;
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecificationIsNull = false;
            }
            System.String requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_ResourceLabel = null;
            if (cmdletContext.PredefinedMetricSpecification_ResourceLabel != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_PredefinedMetricSpecification_predefinedMetricSpecification_ResourceLabel = cmdletContext.PredefinedMetricSpecification_ResourceLabel;
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
            var requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecificationIsNull = true;
            requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification = new Amazon.ApplicationAutoScaling.Model.CustomizedMetricSpecification();
            List<Amazon.ApplicationAutoScaling.Model.MetricDimension> requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Dimension = null;
            if (cmdletContext.CustomizedMetricSpecification_Dimension != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Dimension = cmdletContext.CustomizedMetricSpecification_Dimension;
            }
            if (requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Dimension != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification.Dimensions = requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Dimension;
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
            System.String requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_MetricName = null;
            if (cmdletContext.CustomizedMetricSpecification_MetricName != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_MetricName = cmdletContext.CustomizedMetricSpecification_MetricName;
            }
            if (requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_MetricName != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification.MetricName = requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_MetricName;
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
            List<Amazon.ApplicationAutoScaling.Model.TargetTrackingMetricDataQuery> requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Metric = null;
            if (cmdletContext.CustomizedMetricSpecification_Metric != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Metric = cmdletContext.CustomizedMetricSpecification_Metric;
            }
            if (requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Metric != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification.Metrics = requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Metric;
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
            System.String requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Namespace = null;
            if (cmdletContext.CustomizedMetricSpecification_Namespace != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Namespace = cmdletContext.CustomizedMetricSpecification_Namespace;
            }
            if (requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Namespace != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification.Namespace = requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Namespace;
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
            Amazon.ApplicationAutoScaling.MetricStatistic requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Statistic = null;
            if (cmdletContext.CustomizedMetricSpecification_Statistic != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Statistic = cmdletContext.CustomizedMetricSpecification_Statistic;
            }
            if (requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Statistic != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification.Statistic = requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Statistic;
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecificationIsNull = false;
            }
            System.String requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Unit = null;
            if (cmdletContext.CustomizedMetricSpecification_Unit != null)
            {
                requestTargetTrackingScalingPolicyConfiguration_targetTrackingScalingPolicyConfiguration_CustomizedMetricSpecification_customizedMetricSpecification_Unit = cmdletContext.CustomizedMetricSpecification_Unit;
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
        
        private Amazon.ApplicationAutoScaling.Model.PutScalingPolicyResponse CallAWSServiceOperation(IAmazonApplicationAutoScaling client, Amazon.ApplicationAutoScaling.Model.PutScalingPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Auto Scaling", "PutScalingPolicy");
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
            public System.String PolicyName { get; set; }
            public Amazon.ApplicationAutoScaling.PolicyType PolicyType { get; set; }
            public Amazon.ApplicationAutoScaling.PredictiveScalingMaxCapacityBreachBehavior PredictiveScalingPolicyConfiguration_MaxCapacityBreachBehavior { get; set; }
            public System.Int32? PredictiveScalingPolicyConfiguration_MaxCapacityBuffer { get; set; }
            public List<Amazon.ApplicationAutoScaling.Model.PredictiveScalingMetricSpecification> PredictiveScalingPolicyConfiguration_MetricSpecification { get; set; }
            public Amazon.ApplicationAutoScaling.PredictiveScalingMode PredictiveScalingPolicyConfiguration_Mode { get; set; }
            public System.Int32? PredictiveScalingPolicyConfiguration_SchedulingBufferTime { get; set; }
            public System.String ResourceId { get; set; }
            public Amazon.ApplicationAutoScaling.ScalableDimension ScalableDimension { get; set; }
            public Amazon.ApplicationAutoScaling.ServiceNamespace ServiceNamespace { get; set; }
            public Amazon.ApplicationAutoScaling.AdjustmentType StepScalingPolicyConfiguration_AdjustmentType { get; set; }
            public System.Int32? StepScalingPolicyConfiguration_Cooldown { get; set; }
            public Amazon.ApplicationAutoScaling.MetricAggregationType StepScalingPolicyConfiguration_MetricAggregationType { get; set; }
            public System.Int32? StepScalingPolicyConfiguration_MinAdjustmentMagnitude { get; set; }
            public List<Amazon.ApplicationAutoScaling.Model.StepAdjustment> StepScalingPolicyConfiguration_StepAdjustment { get; set; }
            public List<Amazon.ApplicationAutoScaling.Model.MetricDimension> CustomizedMetricSpecification_Dimension { get; set; }
            public System.String CustomizedMetricSpecification_MetricName { get; set; }
            public List<Amazon.ApplicationAutoScaling.Model.TargetTrackingMetricDataQuery> CustomizedMetricSpecification_Metric { get; set; }
            public System.String CustomizedMetricSpecification_Namespace { get; set; }
            public Amazon.ApplicationAutoScaling.MetricStatistic CustomizedMetricSpecification_Statistic { get; set; }
            public System.String CustomizedMetricSpecification_Unit { get; set; }
            public System.Boolean? TargetTrackingScalingPolicyConfiguration_DisableScaleIn { get; set; }
            public Amazon.ApplicationAutoScaling.MetricType PredefinedMetricSpecification_PredefinedMetricType { get; set; }
            public System.String PredefinedMetricSpecification_ResourceLabel { get; set; }
            public System.Int32? TargetTrackingScalingPolicyConfiguration_ScaleInCooldown { get; set; }
            public System.Int32? TargetTrackingScalingPolicyConfiguration_ScaleOutCooldown { get; set; }
            public System.Double? TargetTrackingScalingPolicyConfiguration_TargetValue { get; set; }
            public System.Func<Amazon.ApplicationAutoScaling.Model.PutScalingPolicyResponse, SetAASScalingPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
