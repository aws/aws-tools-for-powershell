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
using Amazon.ApplicationAutoScaling;
using Amazon.ApplicationAutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AAS
{
    /// <summary>
    /// Registers or updates a scalable target, which is the resource that you want to scale.
    /// 
    ///  
    /// <para>
    /// Scalable targets are uniquely identified by the combination of resource ID, scalable
    /// dimension, and namespace, which represents some capacity dimension of the underlying
    /// service.
    /// </para><para>
    /// When you register a new scalable target, you must specify values for the minimum and
    /// maximum capacity. If the specified resource is not active in the target service, this
    /// operation does not change the resource's current capacity. Otherwise, it changes the
    /// resource's current capacity to a value that is inside of this range.
    /// </para><para>
    /// If you add a scaling policy, current capacity is adjustable within the specified range
    /// when scaling starts. Application Auto Scaling scaling policies will not scale capacity
    /// to values that are outside of the minimum and maximum range.
    /// </para><para>
    /// After you register a scalable target, you do not need to register it again to use
    /// other Application Auto Scaling operations. To see which resources have been registered,
    /// use <a href="https://docs.aws.amazon.com/autoscaling/application/APIReference/API_DescribeScalableTargets.html">DescribeScalableTargets</a>.
    /// You can also view the scaling policies for a service namespace by using <a href="https://docs.aws.amazon.com/autoscaling/application/APIReference/API_DescribeScalableTargets.html">DescribeScalableTargets</a>.
    /// If you no longer need a scalable target, you can deregister it by using <a href="https://docs.aws.amazon.com/autoscaling/application/APIReference/API_DeregisterScalableTarget.html">DeregisterScalableTarget</a>.
    /// </para><para>
    /// To update a scalable target, specify the parameters that you want to change. Include
    /// the parameters that identify the scalable target: resource ID, scalable dimension,
    /// and namespace. Any parameters that you don't specify are not changed by this update
    /// request. 
    /// </para><note><para>
    /// If you call the <c>RegisterScalableTarget</c> API operation to create a scalable target,
    /// there might be a brief delay until the operation achieves <a href="https://en.wikipedia.org/wiki/Eventual_consistency">eventual
    /// consistency</a>. You might become aware of this brief delay if you get unexpected
    /// errors when performing sequential operations. The typical strategy is to retry the
    /// request, and some Amazon Web Services SDKs include automatic backoff and retry logic.
    /// </para><para>
    /// If you call the <c>RegisterScalableTarget</c> API operation to update an existing
    /// scalable target, Application Auto Scaling retrieves the current capacity of the resource.
    /// If it's below the minimum capacity or above the maximum capacity, Application Auto
    /// Scaling adjusts the capacity of the scalable target to place it within these bounds,
    /// even if you don't include the <c>MinCapacity</c> or <c>MaxCapacity</c> request parameters.
    /// </para></note>
    /// </summary>
    [Cmdlet("Add", "AASScalableTarget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Application Auto Scaling RegisterScalableTarget API operation.", Operation = new[] {"RegisterScalableTarget"}, SelectReturnType = typeof(Amazon.ApplicationAutoScaling.Model.RegisterScalableTargetResponse))]
    [AWSCmdletOutput("System.String or Amazon.ApplicationAutoScaling.Model.RegisterScalableTargetResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ApplicationAutoScaling.Model.RegisterScalableTargetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddAASScalableTargetCmdlet : AmazonApplicationAutoScalingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SuspendedState_DynamicScalingInSuspended
        /// <summary>
        /// <para>
        /// <para>Whether scale in by a target tracking scaling policy or a step scaling policy is suspended.
        /// Set the value to <c>true</c> if you don't want Application Auto Scaling to remove
        /// capacity when a scaling policy is triggered. The default is <c>false</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SuspendedState_DynamicScalingInSuspended { get; set; }
        #endregion
        
        #region Parameter SuspendedState_DynamicScalingOutSuspended
        /// <summary>
        /// <para>
        /// <para>Whether scale out by a target tracking scaling policy or a step scaling policy is
        /// suspended. Set the value to <c>true</c> if you don't want Application Auto Scaling
        /// to add capacity when a scaling policy is triggered. The default is <c>false</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SuspendedState_DynamicScalingOutSuspended { get; set; }
        #endregion
        
        #region Parameter MaxCapacity
        /// <summary>
        /// <para>
        /// <para>The maximum value that you plan to scale out to. When a scaling policy is in effect,
        /// Application Auto Scaling can scale out (expand) as needed to the maximum capacity
        /// limit in response to changing demand. This property is required when registering a
        /// new scalable target.</para><para>Although you can specify a large maximum capacity, note that service quotas might
        /// impose lower limits. Each service has its own default quotas for the maximum capacity
        /// of the resource. If you want to specify a higher limit, you can request an increase.
        /// For more information, consult the documentation for that service. For information
        /// about the default quotas for each service, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-service-information.html">Service
        /// endpoints and quotas</a> in the <i>Amazon Web Services General Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxCapacity { get; set; }
        #endregion
        
        #region Parameter MinCapacity
        /// <summary>
        /// <para>
        /// <para>The minimum value that you plan to scale in to. When a scaling policy is in effect,
        /// Application Auto Scaling can scale in (contract) as needed to the minimum capacity
        /// limit in response to changing demand. This property is required when registering a
        /// new scalable target.</para><para>For the following resources, the minimum value allowed is 0.</para><ul><li><para>AppStream 2.0 fleets</para></li><li><para> Aurora DB clusters</para></li><li><para>ECS services</para></li><li><para>EMR clusters</para></li><li><para>Lambda provisioned concurrency</para></li><li><para>SageMaker endpoint variants</para></li><li><para>SageMaker Serverless endpoint provisioned concurrency</para></li><li><para>Spot Fleets</para></li><li><para>custom resources</para></li></ul><para>It's strongly recommended that you specify a value greater than 0. A value greater
        /// than 0 means that data points are continuously reported to CloudWatch that scaling
        /// policies can use to scale on a metric like average CPU utilization.</para><para>For all other resources, the minimum allowed value depends on the type of resource
        /// that you are using. If you provide a value that is lower than what a resource can
        /// accept, an error occurs. In which case, the error message will provide the minimum
        /// value that the resource can accept.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinCapacity { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the resource that is associated with the scalable target. This string
        /// consists of the resource type and unique identifier.</para><ul><li><para>ECS service - The resource type is <c>service</c> and the unique identifier is the
        /// cluster name and service name. Example: <c>service/default/sample-webapp</c>.</para></li><li><para>Spot Fleet - The resource type is <c>spot-fleet-request</c> and the unique identifier
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
        /// and the unique identifier is the replication group name. Example: <c>replication-group/mycluster</c>.</para></li><li><para>Neptune cluster - The resource type is <c>cluster</c> and the unique identifier is
        /// the cluster name. Example: <c>cluster:mycluster</c>.</para></li><li><para>SageMaker Serverless endpoint - The resource type is <c>variant</c> and the unique
        /// identifier is the resource ID. Example: <c>endpoint/my-end-point/variant/KMeansClustering</c>.</para></li><li><para>SageMaker inference component - The resource type is <c>inference-component</c> and
        /// the unique identifier is the resource ID. Example: <c>inference-component/my-inference-component</c>.</para></li></ul>
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
        
        #region Parameter RoleARN
        /// <summary>
        /// <para>
        /// <para>This parameter is required for services that do not support service-linked roles (such
        /// as Amazon EMR), and it must specify the ARN of an IAM role that allows Application
        /// Auto Scaling to modify the scalable target on your behalf. </para><para>If the service supports service-linked roles, Application Auto Scaling uses a service-linked
        /// role, which it creates if it does not yet exist. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/application/userguide/security_iam_service-with-iam.html#security_iam_service-with-iam-roles">Application
        /// Auto Scaling IAM roles</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleARN { get; set; }
        #endregion
        
        #region Parameter ScalableDimension
        /// <summary>
        /// <para>
        /// <para>The scalable dimension associated with the scalable target. This string consists of
        /// the service namespace, resource type, and scaling property.</para><ul><li><para><c>ecs:service:DesiredCount</c> - The desired task count of an ECS service.</para></li><li><para><c>elasticmapreduce:instancegroup:InstanceCount</c> - The instance count of an EMR
        /// Instance Group.</para></li><li><para><c>ec2:spot-fleet-request:TargetCapacity</c> - The target capacity of a Spot Fleet.</para></li><li><para><c>appstream:fleet:DesiredCapacity</c> - The desired capacity of an AppStream 2.0
        /// fleet.</para></li><li><para><c>dynamodb:table:ReadCapacityUnits</c> - The provisioned read capacity for a DynamoDB
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
        /// brokers in an Amazon MSK cluster.</para></li><li><para><c>elasticache:replication-group:NodeGroups</c> - The number of node groups for an
        /// Amazon ElastiCache replication group.</para></li><li><para><c>elasticache:replication-group:Replicas</c> - The number of replicas per node group
        /// for an Amazon ElastiCache replication group.</para></li><li><para><c>neptune:cluster:ReadReplicaCount</c> - The count of read replicas in an Amazon
        /// Neptune DB cluster.</para></li><li><para><c>sagemaker:variant:DesiredProvisionedConcurrency</c> - The provisioned concurrency
        /// for a SageMaker Serverless endpoint.</para></li><li><para><c>sagemaker:inference-component:DesiredCopyCount</c> - The number of copies across
        /// an endpoint for a SageMaker inference component.</para></li></ul>
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
        
        #region Parameter SuspendedState_ScheduledScalingSuspended
        /// <summary>
        /// <para>
        /// <para>Whether scheduled scaling is suspended. Set the value to <c>true</c> if you don't
        /// want Application Auto Scaling to add or remove capacity by initiating scheduled actions.
        /// The default is <c>false</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SuspendedState_ScheduledScalingSuspended { get; set; }
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Assigns one or more tags to the scalable target. Use this parameter to tag the scalable
        /// target when it is created. To tag an existing scalable target, use the <a>TagResource</a>
        /// operation.</para><para>Each tag consists of a tag key and a tag value. Both the tag key and the tag value
        /// are required. You cannot have more than one tag on a scalable target with the same
        /// tag key.</para><para>Use tags to control access to a scalable target. For more information, see <a href="https://docs.aws.amazon.com/autoscaling/application/userguide/resource-tagging-support.html">Tagging
        /// support for Application Auto Scaling</a> in the <i>Application Auto Scaling User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ScalableTargetARN'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationAutoScaling.Model.RegisterScalableTargetResponse).
        /// Specifying the name of a property of type Amazon.ApplicationAutoScaling.Model.RegisterScalableTargetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ScalableTargetARN";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServiceNamespace parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServiceNamespace' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServiceNamespace' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-AASScalableTarget (RegisterScalableTarget)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationAutoScaling.Model.RegisterScalableTargetResponse, AddAASScalableTargetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServiceNamespace;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxCapacity = this.MaxCapacity;
            context.MinCapacity = this.MinCapacity;
            context.ResourceId = this.ResourceId;
            #if MODULAR
            if (this.ResourceId == null && ParameterWasBound(nameof(this.ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleARN = this.RoleARN;
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
            context.SuspendedState_DynamicScalingInSuspended = this.SuspendedState_DynamicScalingInSuspended;
            context.SuspendedState_DynamicScalingOutSuspended = this.SuspendedState_DynamicScalingOutSuspended;
            context.SuspendedState_ScheduledScalingSuspended = this.SuspendedState_ScheduledScalingSuspended;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.ApplicationAutoScaling.Model.RegisterScalableTargetRequest();
            
            if (cmdletContext.MaxCapacity != null)
            {
                request.MaxCapacity = cmdletContext.MaxCapacity.Value;
            }
            if (cmdletContext.MinCapacity != null)
            {
                request.MinCapacity = cmdletContext.MinCapacity.Value;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.RoleARN != null)
            {
                request.RoleARN = cmdletContext.RoleARN;
            }
            if (cmdletContext.ScalableDimension != null)
            {
                request.ScalableDimension = cmdletContext.ScalableDimension;
            }
            if (cmdletContext.ServiceNamespace != null)
            {
                request.ServiceNamespace = cmdletContext.ServiceNamespace;
            }
            
             // populate SuspendedState
            var requestSuspendedStateIsNull = true;
            request.SuspendedState = new Amazon.ApplicationAutoScaling.Model.SuspendedState();
            System.Boolean? requestSuspendedState_suspendedState_DynamicScalingInSuspended = null;
            if (cmdletContext.SuspendedState_DynamicScalingInSuspended != null)
            {
                requestSuspendedState_suspendedState_DynamicScalingInSuspended = cmdletContext.SuspendedState_DynamicScalingInSuspended.Value;
            }
            if (requestSuspendedState_suspendedState_DynamicScalingInSuspended != null)
            {
                request.SuspendedState.DynamicScalingInSuspended = requestSuspendedState_suspendedState_DynamicScalingInSuspended.Value;
                requestSuspendedStateIsNull = false;
            }
            System.Boolean? requestSuspendedState_suspendedState_DynamicScalingOutSuspended = null;
            if (cmdletContext.SuspendedState_DynamicScalingOutSuspended != null)
            {
                requestSuspendedState_suspendedState_DynamicScalingOutSuspended = cmdletContext.SuspendedState_DynamicScalingOutSuspended.Value;
            }
            if (requestSuspendedState_suspendedState_DynamicScalingOutSuspended != null)
            {
                request.SuspendedState.DynamicScalingOutSuspended = requestSuspendedState_suspendedState_DynamicScalingOutSuspended.Value;
                requestSuspendedStateIsNull = false;
            }
            System.Boolean? requestSuspendedState_suspendedState_ScheduledScalingSuspended = null;
            if (cmdletContext.SuspendedState_ScheduledScalingSuspended != null)
            {
                requestSuspendedState_suspendedState_ScheduledScalingSuspended = cmdletContext.SuspendedState_ScheduledScalingSuspended.Value;
            }
            if (requestSuspendedState_suspendedState_ScheduledScalingSuspended != null)
            {
                request.SuspendedState.ScheduledScalingSuspended = requestSuspendedState_suspendedState_ScheduledScalingSuspended.Value;
                requestSuspendedStateIsNull = false;
            }
             // determine if request.SuspendedState should be set to null
            if (requestSuspendedStateIsNull)
            {
                request.SuspendedState = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.ApplicationAutoScaling.Model.RegisterScalableTargetResponse CallAWSServiceOperation(IAmazonApplicationAutoScaling client, Amazon.ApplicationAutoScaling.Model.RegisterScalableTargetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Auto Scaling", "RegisterScalableTarget");
            try
            {
                #if DESKTOP
                return client.RegisterScalableTarget(request);
                #elif CORECLR
                return client.RegisterScalableTargetAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxCapacity { get; set; }
            public System.Int32? MinCapacity { get; set; }
            public System.String ResourceId { get; set; }
            public System.String RoleARN { get; set; }
            public Amazon.ApplicationAutoScaling.ScalableDimension ScalableDimension { get; set; }
            public Amazon.ApplicationAutoScaling.ServiceNamespace ServiceNamespace { get; set; }
            public System.Boolean? SuspendedState_DynamicScalingInSuspended { get; set; }
            public System.Boolean? SuspendedState_DynamicScalingOutSuspended { get; set; }
            public System.Boolean? SuspendedState_ScheduledScalingSuspended { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.ApplicationAutoScaling.Model.RegisterScalableTargetResponse, AddAASScalableTargetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ScalableTargetARN;
        }
        
    }
}
