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
using Amazon.Batch;
using Amazon.Batch.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAT
{
    /// <summary>
    /// Creates an Batch compute environment. You can create <c>MANAGED</c> or <c>UNMANAGED</c>
    /// compute environments. <c>MANAGED</c> compute environments can use Amazon EC2 or Fargate
    /// resources. <c>UNMANAGED</c> compute environments can only use EC2 resources.
    /// 
    ///  
    /// <para>
    /// In a managed compute environment, Batch manages the capacity and instance types of
    /// the compute resources within the environment. This is based on the compute resource
    /// specification that you define or the <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-launch-templates.html">launch
    /// template</a> that you specify when you create the compute environment. Either, you
    /// can choose to use EC2 On-Demand Instances and EC2 Spot Instances. Or, you can use
    /// Fargate and Fargate Spot capacity in your managed compute environment. You can optionally
    /// set a maximum price so that Spot Instances only launch when the Spot Instance price
    /// is less than a specified percentage of the On-Demand price.
    /// </para><para>
    /// In an unmanaged compute environment, you can manage your own EC2 compute resources
    /// and have flexibility with how you configure your compute resources. For example, you
    /// can use custom AMIs. However, you must verify that each of your AMIs meet the Amazon
    /// ECS container instance AMI specification. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/container_instance_AMIs.html">container
    /// instance AMIs</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.
    /// After you created your unmanaged compute environment, you can use the <a>DescribeComputeEnvironments</a>
    /// operation to find the Amazon ECS cluster that's associated with it. Then, launch your
    /// container instances into that Amazon ECS cluster. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/launch_container_instance.html">Launching
    /// an Amazon ECS container instance</a> in the <i>Amazon Elastic Container Service Developer
    /// Guide</i>.
    /// </para><note><para>
    /// Batch doesn't automatically upgrade the AMIs in a compute environment after it's created.
    /// For more information on how to update a compute environment's AMI, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/updating-compute-environments.html">Updating
    /// compute environments</a> in the <i>Batch User Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "BATComputeEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Batch.Model.CreateComputeEnvironmentResponse")]
    [AWSCmdlet("Calls the AWS Batch CreateComputeEnvironment API operation.", Operation = new[] {"CreateComputeEnvironment"}, SelectReturnType = typeof(Amazon.Batch.Model.CreateComputeEnvironmentResponse))]
    [AWSCmdletOutput("Amazon.Batch.Model.CreateComputeEnvironmentResponse",
        "This cmdlet returns an Amazon.Batch.Model.CreateComputeEnvironmentResponse object containing multiple properties."
    )]
    public partial class NewBATComputeEnvironmentCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ComputeResources_AllocationStrategy
        /// <summary>
        /// <para>
        /// <para>The allocation strategy to use for the compute resource if not enough instances of
        /// the best fitting instance type can be allocated. This might be because of availability
        /// of the instance type in the Region or <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-resource-limits.html">Amazon
        /// EC2 service limits</a>. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/allocation-strategies.html">Allocation
        /// strategies</a> in the <i>Batch User Guide</i>.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note><note><para>This parameter is required for Amazon EKS compute environments. For Amazon ECS compute
        /// environments, if this parameter isn't specified, the <c>BEST_FIT</c> allocation strategy
        /// is used by default.</para></note><dl><dt>BEST_FIT (default)</dt><dd><para>Batch selects an instance type that best fits the needs of the jobs with a preference
        /// for the lowest-cost instance type. If additional instances of the selected instance
        /// type aren't available, Batch waits for the additional instances to be available. If
        /// there aren't enough instances available or the user is reaching <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-resource-limits.html">Amazon
        /// EC2 service limits</a>, additional jobs aren't run until the currently running jobs
        /// are completed. This allocation strategy keeps costs lower but can limit scaling. If
        /// you're using Spot Fleets with <c>BEST_FIT</c>, the Spot Fleet IAM Role must be specified.
        /// Compute resources that use a <c>BEST_FIT</c> allocation strategy don't support infrastructure
        /// updates and can't update some parameters. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/updating-compute-environments.html">Updating
        /// compute environments</a> in the <i>Batch User Guide</i>.</para></dd><dt>BEST_FIT_PROGRESSIVE</dt><dd><para>Batch selects additional instance types that are large enough to meet the requirements
        /// of the jobs in the queue. Its preference is for instance types with lower cost vCPUs.
        /// If additional instances of the previously selected instance types aren't available,
        /// Batch selects new instance types.</para></dd><dt>BEST_FIT_PROGRESSIVE_ORDERED</dt><dd><important><para>This is an advanced allocation strategy only for customers who want to control which
        /// instance types are preferred during scaling.</para><para>Placing large instance types at the top of the list may result in <b>over-provisioning</b>
        /// for small jobs. Placing small instance types at the top may cause the compute environment
        /// to reach Amazon EC2 instance count limits before reaching <c>maxvCpus</c>.</para></important><para>Batch selects instance types in the order they appear in the <c>instanceTypes</c>
        /// list. When an instance family is specified, sizes within that family are expanded
        /// using <c>BEST_FIT_PROGRESSIVE</c> logic—preferring sizes that best fit the jobs, with
        /// larger sizes as fallback. Instance types that cannot meet the resource requirements
        /// of the jobs are skipped. This strategy is only available for On-Demand Instance (<c>EC2</c>)
        /// compute resources.</para><para>If an instance family and an explicit instance type from that family both appear in
        /// <c>instanceTypes</c>, the explicit type takes its listed position and is excluded
        /// from the family expansion. For example, in <c>["m7a.4xlarge", "m7a", "m6a"]</c>, <c>m7a.4xlarge</c>
        /// is always placed first and is excluded from the <c>m7a</c> family expansion.</para></dd><dt>SPOT_CAPACITY_OPTIMIZED</dt><dd><para>Batch selects one or more instance types that are large enough to meet the requirements
        /// of the jobs in the queue. Its preference is for instance types that are less likely
        /// to be interrupted. This allocation strategy is only available for Spot Instance compute
        /// resources.</para></dd><dt>SPOT_PRICE_CAPACITY_OPTIMIZED</dt><dd><para>The price and capacity optimized allocation strategy looks at both price and capacity
        /// to select the Spot Instance pools that are the least likely to be interrupted and
        /// have the lowest possible price. This allocation strategy is only available for Spot
        /// Instance compute resources.</para></dd><dt>SPOT_CAPACITY_OPTIMIZED_PRIORITIZED</dt><dd><important><para>This is an advanced allocation strategy for customers who want to influence instance
        /// type selection during scaling. This strategy optimizes for <b>capacity first</b>,
        /// and honors instance type priorities on a best-effort basis (priorities are honored
        /// when they do not significantly reduce available Spot capacity).</para><para>Placing large instance types at the top of the list may result in <b>over-provisioning</b>
        /// for small jobs. Placing small instance types at the top may cause the compute environment
        /// to reach Amazon EC2 instance count limits before reaching <c>maxvCpus</c>.</para></important><para>Batch selects instance types in the order they appear in the <c>instanceTypes</c>
        /// list, but <b>optimizes for capacity first</b>. The customer-defined priority is honored
        /// on a best-effort basis. When Spot Instance capacity pools are similarly available,
        /// priority order is respected. When capacity is constrained, Batch selects from the
        /// most available pools regardless of priority to minimize the likelihood of Spot Instance
        /// interruptions. This strategy is only available for Spot Instance compute resources.</para></dd></dl><para>With any allocation strategy except <c>BEST_FIT</c> using On-Demand (<c>EC2</c>) compute
        /// resources, Batch might need to exceed <c>maxvCpus</c> to meet your capacity requirements.
        /// In this event, Batch never exceeds <c>maxvCpus</c> by more than a single instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Batch.CRAllocationStrategy")]
        public Amazon.Batch.CRAllocationStrategy ComputeResources_AllocationStrategy { get; set; }
        #endregion
        
        #region Parameter ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AllowedInstanceType
        /// <summary>
        /// <para>
        /// <para>A list of specific instance types or instance families that Amazon ECS can launch
        /// (for example, <c>m5.large</c> or <c>g5</c>). When specified, only these instance types
        /// are used.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AllowedInstanceTypes")]
        public System.String[] ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AllowedInstanceType { get; set; }
        #endregion
        
        #region Parameter ComputeResources_BidPercentage
        /// <summary>
        /// <para>
        /// <para>The maximum percentage that a Spot Instance price can be when compared with the On-Demand
        /// price for that instance type before instances are launched. For example, if your maximum
        /// percentage is 20%, then the Spot price must be less than 20% of the current On-Demand
        /// price for that Amazon EC2 instance. You always pay the lowest (market) price and never
        /// more than your maximum percentage. If you leave this field empty, the default value
        /// is 100% of the On-Demand price. For most use cases, we recommend leaving this field
        /// empty.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ComputeResources_BidPercentage { get; set; }
        #endregion
        
        #region Parameter ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityOptionType
        /// <summary>
        /// <para>
        /// <para>The capacity pricing model for the managed instances. Valid values:</para><ul><li><para><c>ON_DEMAND</c> (default) — On-Demand pricing.</para></li><li><para><c>SPOT</c> — Spot Instances, which can provide significant cost savings for fault-tolerant
        /// workloads.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityOptionType { get; set; }
        #endregion
        
        #region Parameter ComputeResources_CapacityTag
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the Amazon ECS capacity provider and Amazon EC2 instances launched
        /// by the compute environment. These tags are separate from the compute environment resource
        /// tags (the top-level <c>tags</c> parameter). Use <c>capacityTags</c> for cost allocation
        /// and organization of the underlying infrastructure resources.</para><para>This parameter is only valid for <c>ECS_MANAGED_INSTANCES</c> compute environments.
        /// You must have the <c>batch:SetCapacityTags</c> permission on the compute environment
        /// resource to use this parameter.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_CapacityTags")]
        public System.Collections.Hashtable ComputeResources_CapacityTag { get; set; }
        #endregion
        
        #region Parameter ComputeEnvironmentName
        /// <summary>
        /// <para>
        /// <para>The name for your compute environment. It can be up to 128 characters long. It can
        /// contain uppercase and lowercase letters, numbers, hyphens (-), and underscores (_).</para>
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
        public System.String ComputeEnvironmentName { get; set; }
        #endregion
        
        #region Parameter EcsSettings_ContainerInsight
        /// <summary>
        /// <para>
        /// <para>Specifies the CloudWatch Container Insights mode for the compute environment. Valid
        /// values are:</para><dl><dt>ENABLED</dt><dd><para>Turns on standard Container Insights, which collects CPU, memory, disk, and network
        /// utilization metrics for the compute environment.</para></dd><dt>ENHANCED</dt><dd><para>Turns on enhanced Container Insights, which collects the standard metrics along with
        /// additional per-task observability metrics.</para></dd><dt>DISABLED</dt><dd><para>Turns off Container Insights for the compute environment.</para></dd></dl><para>If you don't specify a value, the default is <c>DISABLED</c>. For more information,
        /// see <a href="https://docs.aws.amazon.com/batch/latest/userguide/cloudwatch-container-insights.html">Container
        /// Insights</a> in the <i>Batch User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EcsSettings_ContainerInsights")]
        [AWSConstantClassSource("Amazon.Batch.ContainerInsights")]
        public Amazon.Batch.ContainerInsights EcsSettings_ContainerInsight { get; set; }
        #endregion
        
        #region Parameter Context
        /// <summary>
        /// <para>
        /// <para>Reserved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Context { get; set; }
        #endregion
        
        #region Parameter ComputeResources_DesiredvCpu
        /// <summary>
        /// <para>
        /// <para>The desired number of vCPUS in the compute environment. Batch modifies this value
        /// between the minimum and maximum values based on job queue demand.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_DesiredvCpus")]
        public System.Int32? ComputeResources_DesiredvCpu { get; set; }
        #endregion
        
        #region Parameter ComputeResources_Ec2Configuration
        /// <summary>
        /// <para>
        /// <para>Provides information that's used to select Amazon Machine Images (AMIs) for Amazon
        /// EC2 instances in the compute environment. If <c>Ec2Configuration</c> isn't specified,
        /// the default is <c>ECS_AL2023</c> for EC2 (ECS) compute environments and <c>EKS_AL2023</c>
        /// for EKS compute environments.</para><para>One or two values can be provided.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Batch.Model.Ec2Configuration[] ComputeResources_Ec2Configuration { get; set; }
        #endregion
        
        #region Parameter ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_Ec2InstanceProfileArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon EC2 instance profile for the managed
        /// instances. The instance profile must use the <c>AmazonECSInstanceRolePolicyForManagedInstances</c>
        /// managed policy with a trust policy for <c>ec2.amazonaws.com</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_Ec2InstanceProfileArn { get; set; }
        #endregion
        
        #region Parameter ComputeResources_Ec2KeyPair
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 key pair that's used for instances launched in the compute environment.
        /// You can use this key pair to log in to your instances with SSH.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeResources_Ec2KeyPair { get; set; }
        #endregion
        
        #region Parameter EksConfiguration_EksClusterArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon EKS cluster. An example is <c>arn:<i>aws</i>:eks:<i>us-east-1</i>:<i>123456789012</i>:cluster/<i>ClusterForBatch</i></c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EksConfiguration_EksClusterArn { get; set; }
        #endregion
        
        #region Parameter ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_FipsEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether FIPS 140-2 validated cryptographic modules are enabled on the managed
        /// instances. Not available in all Regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_FipsEnabled { get; set; }
        #endregion
        
        #region Parameter ComputeResources_ManagedInstancesProvider_InfrastructureRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that Amazon ECS assumes to manage Amazon
        /// EC2 instances on your behalf. This role must have a trust policy for <c>ecs.amazonaws.com</c>.
        /// You must have the <c>iam:PassRole</c> permission for this role with the condition
        /// <c>iam:PassedToService: ecs.amazonaws.com</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeResources_ManagedInstancesProvider_InfrastructureRoleArn { get; set; }
        #endregion
        
        #region Parameter ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceMetadataTagsPropagation
        /// <summary>
        /// <para>
        /// <para>Specifies whether instance tags are accessible from the instance metadata service
        /// (IMDS). If not specified, instance tags are not accessible from IMDS.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceMetadataTagsPropagation { get; set; }
        #endregion
        
        #region Parameter ComputeResources_InstanceRole
        /// <summary>
        /// <para>
        /// Amazon.Batch.Model.ComputeResource.InstanceRole
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeResources_InstanceRole { get; set; }
        #endregion
        
        #region Parameter ComputeResources_InstanceType
        /// <summary>
        /// <para>
        /// <para>The instances types that can be launched. You can specify instance families to launch
        /// any instance type within those families (for example, <c>c5</c> or <c>p3</c>), or
        /// you can specify specific sizes within a family (such as <c>c5.8xlarge</c>).</para><para>Batch can select the instance type for you if you choose one of the following:</para><ul><li><para><c>default_x86_64</c> to choose x86 based instance types (from the <c>m6i</c>, <c>c6i</c>,
        /// <c>r6i</c>, and <c>c7i</c> instance families) that matches the resource demands of
        /// the job queue.</para></li><li><para><c>default_arm64</c> to choose ARM based instance types (from the <c>m6g</c>, <c>c6g</c>,
        /// <c>r6g</c>, and <c>c7g</c> instance families) that matches the resource demands of
        /// the job queue.</para></li><li><para><c>optimal</c> Semantically equivalent to <c>default_x86_64</c>, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/optimal-default-instance-troubleshooting.html">Optimal
        /// instance type configuration to receive automatic instance family updates</a> for details.</para></li></ul><note><para>Instance family availability varies by Amazon Web Services Region. For example, some
        /// Amazon Web Services Regions may not have any fourth generation instance families but
        /// have fifth and sixth generation instance families.</para><para>When using <c>default_x86_64</c> or <c>default_arm64</c> instance bundles, Batch selects
        /// instance families based on a balance of cost-effectiveness and performance. While
        /// newer generation instances often provide better price-performance, Batch may choose
        /// an earlier generation instance family if it provides the optimal combination of availability,
        /// cost, and performance for your workload. For example, in an Amazon Web Services Region
        /// where both c6i and c7i instances are available, Batch might select c6i instances if
        /// they offer better cost-effectiveness for your specific job requirements. For more
        /// information on Batch instance types and Amazon Web Services Region availability, see
        /// <a href="https://docs.aws.amazon.com/batch/latest/userguide/instance-type-compute-table.html">Instance
        /// type compute table</a> in the <i>Batch User Guide</i>.</para><para>Batch periodically updates your instances in default bundles to newer, more cost-effective
        /// options. Updates happen automatically without requiring any action from you. Your
        /// workloads continue running during updates with no interruption </para></note><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note><note><para>When you create a compute environment, the instance types that you select for the
        /// compute environment must share the same architecture. For example, you can't mix x86
        /// and ARM instances in the same compute environment.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_InstanceTypes")]
        public System.String[] ComputeResources_InstanceType { get; set; }
        #endregion
        
        #region Parameter EksConfiguration_KubernetesNamespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the Amazon EKS cluster. Batch manages pods in this namespace. The
        /// value can't left empty or null. It must be fewer than 64 characters long, can't be
        /// set to <c>default</c>, can't start with "<c>kube-</c>," and must match this regular
        /// expression: <c>^[a-z0-9]([-a-z0-9]*[a-z0-9])?$</c>. For more information, see <a href="https://kubernetes.io/docs/concepts/overview/working-with-objects/namespaces/">Namespaces</a>
        /// in the Kubernetes documentation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EksConfiguration_KubernetesNamespace { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_LaunchTemplateId
        /// <summary>
        /// <para>
        /// <para>The ID of the launch template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_LaunchTemplate_LaunchTemplateId")]
        public System.String LaunchTemplate_LaunchTemplateId { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_LaunchTemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the launch template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_LaunchTemplate_LaunchTemplateName")]
        public System.String LaunchTemplate_LaunchTemplateName { get; set; }
        #endregion
        
        #region Parameter ComputeResources_MaxvCpu
        /// <summary>
        /// <para>
        /// <para>The maximum number of vCPUs that a compute environment can support.</para><note><para>With any allocation strategy except <c>BEST_FIT</c> using On-Demand (<c>EC2</c>) compute
        /// resources, Batch might need to exceed <c>maxvCpus</c> to meet your capacity requirements.
        /// In this event, Batch never exceeds <c>maxvCpus</c> by more than a single instance.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_MaxvCpus")]
        public System.Int32? ComputeResources_MaxvCpu { get; set; }
        #endregion
        
        #region Parameter ComputeResources_ScalingPolicy_MinScaleDownDelayMinute
        /// <summary>
        /// <para>
        /// <para>The minimum time (in minutes) that Batch keeps instances running in the compute environment
        /// after their jobs complete. For each instance, the delay period begins when the last
        /// job finishes. If no new jobs are placed on the instance during this delay, Batch terminates
        /// the instance once the delay expires.</para><para>Valid Range: Minimum value of 20. Maximum value of 10080. Use 0 to unset and disable
        /// the scale down delay.</para><note><para>Idle instances retained during the scale-down delay period are billable at standard
        /// EC2 pricing.</para></note><note><para>The scale down delay does not apply to:</para><ul><li><para>Instances being replaced during infrastructure updates</para></li><li><para>Newly launched instances that have not yet run any jobs</para></li><li><para>Spot instances reclaimed due to interruption</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_ScalingPolicy_MinScaleDownDelayMinutes")]
        public System.Int32? ComputeResources_ScalingPolicy_MinScaleDownDelayMinute { get; set; }
        #endregion
        
        #region Parameter ComputeResources_MinvCpu
        /// <summary>
        /// <para>
        /// <para>The minimum number of vCPUs that a compute environment should maintain (even if the
        /// compute environment is <c>DISABLED</c>).</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_MinvCpus")]
        public System.Int32? ComputeResources_MinvCpu { get; set; }
        #endregion
        
        #region Parameter ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_Monitoring
        /// <summary>
        /// <para>
        /// <para>The level of CloudWatch monitoring for the managed instances. Valid values are <c>BASIC</c>
        /// and <c>DETAILED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_Monitoring { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_Override
        /// <summary>
        /// <para>
        /// <para>A launch template to use in place of the default launch template. You must specify
        /// either the launch template ID or launch template name in the request, but not both.</para><para>You can specify up to ten (10) launch template overrides that are associated to unique
        /// instance types or families for each compute environment.</para><note><para>To unset all override templates for a compute environment, you can pass an empty array
        /// to the <a href="https://docs.aws.amazon.com/batch/latest/APIReference/API_UpdateComputeEnvironment.html">UpdateComputeEnvironment.overrides</a>
        /// parameter, or not include the <c>overrides</c> parameter when submitting the <c>UpdateComputeEnvironment</c>
        /// API operation.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_LaunchTemplate_Overrides")]
        public Amazon.Batch.Model.LaunchTemplateSpecificationOverride[] LaunchTemplate_Override { get; set; }
        #endregion
        
        #region Parameter ComputeResources_PlacementGroup
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 placement group to associate with your compute resources. If you intend
        /// to submit multi-node parallel jobs to your compute environment, you should consider
        /// creating a cluster placement group and associate it with your compute resources. This
        /// keeps your multi-node parallel job on a logical grouping of instances within a single
        /// Availability Zone with high network flow potential. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/placement-groups.html">Placement
        /// groups</a> in the <i>Amazon EC2 User Guide for Linux Instances</i>.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeResources_PlacementGroup { get; set; }
        #endregion
        
        #region Parameter ComputeResources_ManagedInstancesProvider_PropagateTag
        /// <summary>
        /// <para>
        /// <para>Specifies whether tags on the capacity provider are propagated to the Amazon EC2 instances
        /// it launches. Valid values:</para><ul><li><para><c>CAPACITY_PROVIDER</c> — Propagates tags to instances.</para></li><li><para><c>NONE</c> (default) — Does not propagate tags to instances.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_ManagedInstancesProvider_PropagateTags")]
        public System.String ComputeResources_ManagedInstancesProvider_PropagateTag { get; set; }
        #endregion
        
        #region Parameter ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the capacity reservation group to target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationGroupArn { get; set; }
        #endregion
        
        #region Parameter ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationPreference
        /// <summary>
        /// <para>
        /// <para>The capacity reservation preference. Valid values:</para><ul><li><para><c>RESERVATIONS_ONLY</c> — Use only capacity reservations.</para></li><li><para><c>RESERVATIONS_FIRST</c> — Prefer capacity reservations but fall back to On-Demand
        /// if unavailable.</para></li><li><para><c>RESERVATIONS_EXCLUDED</c> — Do not use capacity reservations.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationPreference { get; set; }
        #endregion
        
        #region Parameter ComputeResources_ManagedInstancesProvider_InfrastructureOptimization_ScaleInAfter
        /// <summary>
        /// <para>
        /// <para>The number of seconds an instance can remain idle before it is terminated. Valid values
        /// are <c>-1</c> or <c>0</c> to <c>3600</c>. Use <c>-1</c> as a special value to disable
        /// scale-in (instances are never terminated for being idle). If not specified, a default
        /// value applies.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ComputeResources_ManagedInstancesProvider_InfrastructureOptimization_ScaleInAfter { get; set; }
        #endregion
        
        #region Parameter ComputeResources_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 security groups that are associated with instances launched in the
        /// compute environment. One or more security groups must be specified, either in <c>securityGroupIds</c>
        /// or using a launch template referenced in <c>launchTemplate</c>. This parameter is
        /// required for jobs that are running on Fargate resources and must contain at least
        /// one security group. Fargate doesn't support launch templates. If security groups are
        /// specified using both <c>securityGroupIds</c> and <c>launchTemplate</c>, the values
        /// in <c>securityGroupIds</c> are used.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_SecurityGroupIds")]
        public System.String[] ComputeResources_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>The VPC security groups to associate with the managed instances.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_SecurityGroups")]
        public System.String[] ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter ServiceRole
        /// <summary>
        /// <para>
        /// <para>The full Amazon Resource Name (ARN) of the IAM role that allows Batch to make calls
        /// to other Amazon Web Services services on your behalf. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/service_IAM_role.html">Batch
        /// service IAM role</a> in the <i>Batch User Guide</i>.</para><important><para>If your account already created the Batch service-linked role, that role is used by
        /// default for your compute environment unless you specify a different role here. If
        /// the Batch service-linked role doesn't exist in your account, and no role is specified
        /// here, the service attempts to create the Batch service-linked role in your account.</para><para>This automatic service-linked role creation only applies to <c>MANAGED</c> compute
        /// environments. For <c>UNMANAGED</c> compute environments, you must explicitly specify
        /// a <c>serviceRole</c>.</para></important><para>If your specified role has a path other than <c>/</c>, then you must specify either
        /// the full role ARN (recommended) or prefix the role name with the path. For example,
        /// if a role with the name <c>bar</c> has a path of <c>/foo/</c>, specify <c>/foo/bar</c>
        /// as the role name. For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_identifiers.html#identifiers-friendly-names">Friendly
        /// names and paths</a> in the <i>IAM User Guide</i>.</para><note><para>Depending on how you created your Batch service role, its ARN might contain the <c>service-role</c>
        /// path prefix. When you only specify the name of the service role, Batch assumes that
        /// your ARN doesn't use the <c>service-role</c> path prefix. Because of this, we recommend
        /// that you specify the full ARN of your service role when you create compute environments.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceRole { get; set; }
        #endregion
        
        #region Parameter ComputeResources_SpotIamFleetRole
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon EC2 Spot Fleet IAM role applied to a
        /// <c>SPOT</c> compute environment. This role is required if the allocation strategy
        /// set to <c>BEST_FIT</c> or if the allocation strategy isn't specified. For more information,
        /// see <a href="https://docs.aws.amazon.com/batch/latest/userguide/spot_fleet_IAM_role.html">Amazon
        /// EC2 spot fleet role</a> in the <i>Batch User Guide</i>.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note><important><para>To tag your Spot Instances on creation, the Spot Fleet IAM role specified here must
        /// use the newer <b>AmazonEC2SpotFleetTaggingRole</b> managed policy. The previously
        /// recommended <b>AmazonEC2SpotFleetRole</b> managed policy doesn't have the required
        /// permissions to tag Spot Instances. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/troubleshooting.html#spot-instance-no-tag">Spot
        /// instances not tagged on creation</a> in the <i>Batch User Guide</i>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeResources_SpotIamFleetRole { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The state of the compute environment. A compute environment must be created in the
        /// <c>ENABLED</c> state.</para><para>If the state is <c>ENABLED</c>, then the compute environment accepts jobs from a queue
        /// and can scale out automatically based on queues.</para><para>If the state is <c>ENABLED</c>, then the Batch scheduler can attempt to place jobs
        /// from an associated job queue on the compute resources within the environment. If the
        /// compute environment is managed, then it can scale its instances out or in automatically,
        /// based on the job queue demand.</para><para>If the state is <c>DISABLED</c>, then the Batch scheduler doesn't attempt to place
        /// jobs within the environment. Jobs in a <c>STARTING</c> or <c>RUNNING</c> state continue
        /// to progress normally. Managed compute environments in the <c>DISABLED</c> state don't
        /// scale out. </para><note><para>Compute environments in a <c>DISABLED</c> state may continue to incur billing charges,
        /// for example, if they have running instances due to jobs that are still executing or
        /// a non-zero <c>minvCpus</c> setting. To prevent additional charges, disable and delete
        /// the compute environment.</para></note><para>When an instance is idle, the instance scales down to the <c>minvCpus</c> value. However,
        /// the instance size doesn't change. For example, consider a <c>c5.8xlarge</c> instance
        /// with a <c>minvCpus</c> value of <c>4</c> and a <c>desiredvCpus</c> value of <c>36</c>.
        /// This instance doesn't scale down to a <c>c5.large</c> instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Batch.CEState")]
        public Amazon.Batch.CEState State { get; set; }
        #endregion
        
        #region Parameter ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration_StorageSizeGiB
        /// <summary>
        /// <para>
        /// <para>The size of the root EBS volume in GiB for the managed instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration_StorageSizeGiB { get; set; }
        #endregion
        
        #region Parameter ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_Subnet
        /// <summary>
        /// <para>
        /// <para>The VPC subnets where managed instances are launched. If your subnets don't provide
        /// public IP addresses, they must have a NAT gateway for outbound internet access.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_Subnets")]
        public System.String[] ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_Subnet { get; set; }
        #endregion
        
        #region Parameter ComputeResources_Subnet
        /// <summary>
        /// <para>
        /// <para>The VPC subnets where the compute resources are launched. These subnets must be within
        /// the same VPC. Fargate compute resources can contain up to 16 subnets. For more information,
        /// see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_Subnets.html">VPCs
        /// and subnets</a> in the <i>Amazon VPC User Guide</i>. This parameter is required for
        /// compute environments using <c>EC2</c>, <c>SPOT</c>, <c>FARGATE</c>, or <c>FARGATE_SPOT</c>
        /// compute resources.</para><note><para>Batch on Amazon EC2 and Batch on Amazon EKS support Local Zones. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/using-regions-availability-zones.html#concepts-local-zones">
        /// Local Zones</a> in the <i>Amazon EC2 User Guide for Linux Instances</i>, <a href="https://docs.aws.amazon.com/eks/latest/userguide/local-zones.html">Amazon
        /// EKS and Amazon Web Services Local Zones</a> in the <i>Amazon EKS User Guide</i> and
        /// <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/cluster-regions-zones.html#clusters-local-zones">
        /// Amazon ECS clusters in Local Zones, Wavelength Zones, and Amazon Web Services Outposts</a>
        /// in the <i>Amazon ECS Developer Guide</i>.</para><para>Batch on Fargate doesn't currently support Local Zones.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_Subnets")]
        public System.String[] ComputeResources_Subnet { get; set; }
        #endregion
        
        #region Parameter ComputeResources_Tag
        /// <summary>
        /// <para>
        /// <para>Key-value pair tags to be applied to Amazon EC2 resources that are launched in the
        /// compute environment. For Batch, these take the form of <c>"String1": "String2"</c>,
        /// where <c>String1</c> is the tag key and <c>String2</c> is the tag value (for example,
        /// <c>{ "Name": "Batch Instance - C4OnDemand" }</c>). This is helpful for recognizing
        /// your Batch instances in the Amazon EC2 console. Updating these tags requires an infrastructure
        /// update to the compute environment. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/updating-compute-environments.html">Updating
        /// compute environments</a> in the <i>Batch User Guide</i>. These tags aren't seen when
        /// using the Batch <c>ListTagsForResource</c> API operation.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_Tags")]
        public System.Collections.Hashtable ComputeResources_Tag { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags that you apply to the compute environment to help you categorize and organize
        /// your resources. Each tag consists of a key and an optional value. For more information,
        /// see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services Resources</a> in <i>Amazon Web Services General Reference</i>.</para><para>These tags can be updated or removed using the <a href="https://docs.aws.amazon.com/batch/latest/APIReference/API_TagResource.html">TagResource</a>
        /// and <a href="https://docs.aws.amazon.com/batch/latest/APIReference/API_UntagResource.html">UntagResource</a>
        /// API operations. These tags don't propagate to the underlying compute resources.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ComputeResources_Type
        /// <summary>
        /// <para>
        /// <para>The type of compute environment: <c>EC2</c>, <c>SPOT</c>, <c>FARGATE</c>, <c>FARGATE_SPOT</c>,
        /// or <c>ECS_MANAGED_INSTANCES</c>. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/compute_environments.html">Compute
        /// environments</a> in the <i>Batch User Guide</i>.</para><para> If you choose <c>SPOT</c>, you must also specify an Amazon EC2 Spot Fleet role with
        /// the <c>spotIamFleetRole</c> parameter. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/spot_fleet_IAM_role.html">Amazon
        /// EC2 spot fleet role</a> in the <i>Batch User Guide</i>.</para><para>If you choose <c>ECS_MANAGED_INSTANCES</c>, you must also specify a <c>managedInstancesProvider</c>
        /// configuration. To use Spot capacity, set <c>capacityOptionType</c> to <c>SPOT</c>
        /// in the <c>managedInstancesProvider.instanceLaunchTemplate</c> configuration. For more
        /// information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/ecs_managed_instances.html">Amazon
        /// ECS Managed Instances compute environments</a> in the <i>Batch User Guide</i>.</para><note><para>Multi-node parallel jobs aren't supported on Spot Instances or Amazon ECS Managed
        /// Instances.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Batch.CRType")]
        public Amazon.Batch.CRType ComputeResources_Type { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of the compute environment: <c>MANAGED</c> or <c>UNMANAGED</c>. For more
        /// information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/compute_environments.html">Compute
        /// Environments</a> in the <i>Batch User Guide</i>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Batch.CEType")]
        public Amazon.Batch.CEType Type { get; set; }
        #endregion
        
        #region Parameter UnmanagedvCpu
        /// <summary>
        /// <para>
        /// <para>The maximum number of vCPUs for an unmanaged compute environment. This parameter is
        /// only used for fair-share scheduling to reserve vCPU capacity for new share identifiers.
        /// If this parameter isn't provided for a fair-share job queue, no vCPU capacity is reserved.</para><note><para>This parameter is only supported when the <c>type</c> parameter is set to <c>UNMANAGED</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UnmanagedvCpus")]
        public System.Int32? UnmanagedvCpu { get; set; }
        #endregion
        
        #region Parameter ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration_UseLocalStorage
        /// <summary>
        /// <para>
        /// <para>Specifies whether instance store volumes (local NVMe SSDs) are available to containers.
        /// When enabled, containers can use the instance store for high-performance temporary
        /// storage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration_UseLocalStorage { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_UserdataType
        /// <summary>
        /// <para>
        /// <para>The EKS node initialization process to use. You only need to specify this value if
        /// you are using a custom AMI. The default value is <c>EKS_BOOTSTRAP_SH</c>. If <i>imageType</i>
        /// is a custom AMI based on EKS_AL2023 or EKS_AL2023_NVIDIA then you must choose <c>EKS_NODEADM</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_LaunchTemplate_UserdataType")]
        [AWSConstantClassSource("Amazon.Batch.UserdataType")]
        public Amazon.Batch.UserdataType LaunchTemplate_UserdataType { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_Version
        /// <summary>
        /// <para>
        /// <para>The version number of the launch template, <c>$Default</c>, or <c>$Latest</c>.</para><para>If the value is <c>$Default</c>, the default version of the launch template is used.
        /// If the value is <c>$Latest</c>, the latest version of the launch template is used.
        /// </para><important><para>If the AMI ID that's used in a compute environment is from the launch template, the
        /// AMI isn't changed when the compute environment is updated. It's only changed if the
        /// <c>updateToLatestImageVersion</c> parameter for the compute environment is set to
        /// <c>true</c>. During an infrastructure update, if either <c>$Default</c> or <c>$Latest</c>
        /// is specified, Batch re-evaluates the launch template version, and it might use a different
        /// version of the launch template. This is the case even if the launch template isn't
        /// specified in the update. When updating a compute environment, changing the launch
        /// template requires an infrastructure update of the compute environment. For more information,
        /// see <a href="https://docs.aws.amazon.com/batch/latest/userguide/updating-compute-environments.html">Updating
        /// compute environments</a> in the <i>Batch User Guide</i>.</para></important><para>Default: <c>$Default</c></para><para>Latest: <c>$Latest</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_LaunchTemplate_Version")]
        public System.String LaunchTemplate_Version { get; set; }
        #endregion
        
        #region Parameter ComputeResources_ImageId
        /// <summary>
        /// <para>
        /// <para>The Amazon Machine Image (AMI) ID used for instances launched in the compute environment.
        /// This parameter is overridden by the <c>imageIdOverride</c> member of the <c>Ec2Configuration</c>
        /// structure.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note><note><para>The AMI that you choose for a compute environment must match the architecture of the
        /// instance types that you intend to use for that compute environment. For example, if
        /// your compute environment uses A1 instance types, the compute resource AMI that you
        /// choose must support ARM instances. Amazon ECS vends both x86 and ARM versions of the
        /// Amazon ECS-optimized Amazon Linux 2023 AMI. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs-optimized_AMI.html#ecs-optimized-ami-linux-variants.html">Amazon
        /// ECS-optimized Amazon Linux 2023 AMI</a> in the <i>Amazon Elastic Container Service
        /// Developer Guide</i>.</para></note>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This field is deprecated, use ec2Configuration[].imageIdOverride instead.")]
        public System.String ComputeResources_ImageId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Batch.Model.CreateComputeEnvironmentResponse).
        /// Specifying the name of a property of type Amazon.Batch.Model.CreateComputeEnvironmentResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ComputeEnvironmentName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BATComputeEnvironment (CreateComputeEnvironment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Batch.Model.CreateComputeEnvironmentResponse, NewBATComputeEnvironmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ComputeEnvironmentName = this.ComputeEnvironmentName;
            #if MODULAR
            if (this.ComputeEnvironmentName == null && ParameterWasBound(nameof(this.ComputeEnvironmentName)))
            {
                WriteWarning("You are passing $null as a value for parameter ComputeEnvironmentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ComputeResources_AllocationStrategy = this.ComputeResources_AllocationStrategy;
            context.ComputeResources_BidPercentage = this.ComputeResources_BidPercentage;
            if (this.ComputeResources_CapacityTag != null)
            {
                context.ComputeResources_CapacityTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ComputeResources_CapacityTag.Keys)
                {
                    context.ComputeResources_CapacityTag.Add((String)hashKey, (System.String)(this.ComputeResources_CapacityTag[hashKey]));
                }
            }
            context.ComputeResources_DesiredvCpu = this.ComputeResources_DesiredvCpu;
            if (this.ComputeResources_Ec2Configuration != null)
            {
                context.ComputeResources_Ec2Configuration = new List<Amazon.Batch.Model.Ec2Configuration>(this.ComputeResources_Ec2Configuration);
            }
            context.ComputeResources_Ec2KeyPair = this.ComputeResources_Ec2KeyPair;
            context.ComputeResources_ImageId = this.ComputeResources_ImageId;
            context.ComputeResources_InstanceRole = this.ComputeResources_InstanceRole;
            if (this.ComputeResources_InstanceType != null)
            {
                context.ComputeResources_InstanceType = new List<System.String>(this.ComputeResources_InstanceType);
            }
            context.LaunchTemplate_LaunchTemplateId = this.LaunchTemplate_LaunchTemplateId;
            context.LaunchTemplate_LaunchTemplateName = this.LaunchTemplate_LaunchTemplateName;
            if (this.LaunchTemplate_Override != null)
            {
                context.LaunchTemplate_Override = new List<Amazon.Batch.Model.LaunchTemplateSpecificationOverride>(this.LaunchTemplate_Override);
            }
            context.LaunchTemplate_UserdataType = this.LaunchTemplate_UserdataType;
            context.LaunchTemplate_Version = this.LaunchTemplate_Version;
            context.ComputeResources_ManagedInstancesProvider_InfrastructureOptimization_ScaleInAfter = this.ComputeResources_ManagedInstancesProvider_InfrastructureOptimization_ScaleInAfter;
            context.ComputeResources_ManagedInstancesProvider_InfrastructureRoleArn = this.ComputeResources_ManagedInstancesProvider_InfrastructureRoleArn;
            context.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityOptionType = this.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityOptionType;
            context.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationGroupArn = this.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationGroupArn;
            context.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationPreference = this.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationPreference;
            context.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_Ec2InstanceProfileArn = this.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_Ec2InstanceProfileArn;
            context.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_FipsEnabled = this.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_FipsEnabled;
            context.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceMetadataTagsPropagation = this.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceMetadataTagsPropagation;
            if (this.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AllowedInstanceType != null)
            {
                context.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AllowedInstanceType = new List<System.String>(this.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AllowedInstanceType);
            }
            context.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration_UseLocalStorage = this.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration_UseLocalStorage;
            context.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_Monitoring = this.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_Monitoring;
            if (this.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_SecurityGroup != null)
            {
                context.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_SecurityGroup = new List<System.String>(this.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_SecurityGroup);
            }
            if (this.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_Subnet != null)
            {
                context.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_Subnet = new List<System.String>(this.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_Subnet);
            }
            context.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration_StorageSizeGiB = this.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration_StorageSizeGiB;
            context.ComputeResources_ManagedInstancesProvider_PropagateTag = this.ComputeResources_ManagedInstancesProvider_PropagateTag;
            context.ComputeResources_MaxvCpu = this.ComputeResources_MaxvCpu;
            context.ComputeResources_MinvCpu = this.ComputeResources_MinvCpu;
            context.ComputeResources_PlacementGroup = this.ComputeResources_PlacementGroup;
            context.ComputeResources_ScalingPolicy_MinScaleDownDelayMinute = this.ComputeResources_ScalingPolicy_MinScaleDownDelayMinute;
            if (this.ComputeResources_SecurityGroupId != null)
            {
                context.ComputeResources_SecurityGroupId = new List<System.String>(this.ComputeResources_SecurityGroupId);
            }
            context.ComputeResources_SpotIamFleetRole = this.ComputeResources_SpotIamFleetRole;
            if (this.ComputeResources_Subnet != null)
            {
                context.ComputeResources_Subnet = new List<System.String>(this.ComputeResources_Subnet);
            }
            if (this.ComputeResources_Tag != null)
            {
                context.ComputeResources_Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ComputeResources_Tag.Keys)
                {
                    context.ComputeResources_Tag.Add((String)hashKey, (System.String)(this.ComputeResources_Tag[hashKey]));
                }
            }
            context.ComputeResources_Type = this.ComputeResources_Type;
            context.Context = this.Context;
            context.EcsSettings_ContainerInsight = this.EcsSettings_ContainerInsight;
            context.EksConfiguration_EksClusterArn = this.EksConfiguration_EksClusterArn;
            context.EksConfiguration_KubernetesNamespace = this.EksConfiguration_KubernetesNamespace;
            context.ServiceRole = this.ServiceRole;
            context.State = this.State;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UnmanagedvCpu = this.UnmanagedvCpu;
            
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
            var request = new Amazon.Batch.Model.CreateComputeEnvironmentRequest();
            
            if (cmdletContext.ComputeEnvironmentName != null)
            {
                request.ComputeEnvironmentName = cmdletContext.ComputeEnvironmentName;
            }
            
             // populate ComputeResources
            var requestComputeResourcesIsNull = true;
            request.ComputeResources = new Amazon.Batch.Model.ComputeResource();
            Amazon.Batch.CRAllocationStrategy requestComputeResources_computeResources_AllocationStrategy = null;
            if (cmdletContext.ComputeResources_AllocationStrategy != null)
            {
                requestComputeResources_computeResources_AllocationStrategy = cmdletContext.ComputeResources_AllocationStrategy;
            }
            if (requestComputeResources_computeResources_AllocationStrategy != null)
            {
                request.ComputeResources.AllocationStrategy = requestComputeResources_computeResources_AllocationStrategy;
                requestComputeResourcesIsNull = false;
            }
            System.Int32? requestComputeResources_computeResources_BidPercentage = null;
            if (cmdletContext.ComputeResources_BidPercentage != null)
            {
                requestComputeResources_computeResources_BidPercentage = cmdletContext.ComputeResources_BidPercentage.Value;
            }
            if (requestComputeResources_computeResources_BidPercentage != null)
            {
                request.ComputeResources.BidPercentage = requestComputeResources_computeResources_BidPercentage.Value;
                requestComputeResourcesIsNull = false;
            }
            Dictionary<System.String, System.String> requestComputeResources_computeResources_CapacityTag = null;
            if (cmdletContext.ComputeResources_CapacityTag != null)
            {
                requestComputeResources_computeResources_CapacityTag = cmdletContext.ComputeResources_CapacityTag;
            }
            if (requestComputeResources_computeResources_CapacityTag != null)
            {
                request.ComputeResources.CapacityTags = requestComputeResources_computeResources_CapacityTag;
                requestComputeResourcesIsNull = false;
            }
            System.Int32? requestComputeResources_computeResources_DesiredvCpu = null;
            if (cmdletContext.ComputeResources_DesiredvCpu != null)
            {
                requestComputeResources_computeResources_DesiredvCpu = cmdletContext.ComputeResources_DesiredvCpu.Value;
            }
            if (requestComputeResources_computeResources_DesiredvCpu != null)
            {
                request.ComputeResources.DesiredvCpus = requestComputeResources_computeResources_DesiredvCpu.Value;
                requestComputeResourcesIsNull = false;
            }
            List<Amazon.Batch.Model.Ec2Configuration> requestComputeResources_computeResources_Ec2Configuration = null;
            if (cmdletContext.ComputeResources_Ec2Configuration != null)
            {
                requestComputeResources_computeResources_Ec2Configuration = cmdletContext.ComputeResources_Ec2Configuration;
            }
            if (requestComputeResources_computeResources_Ec2Configuration != null)
            {
                request.ComputeResources.Ec2Configuration = requestComputeResources_computeResources_Ec2Configuration;
                requestComputeResourcesIsNull = false;
            }
            System.String requestComputeResources_computeResources_Ec2KeyPair = null;
            if (cmdletContext.ComputeResources_Ec2KeyPair != null)
            {
                requestComputeResources_computeResources_Ec2KeyPair = cmdletContext.ComputeResources_Ec2KeyPair;
            }
            if (requestComputeResources_computeResources_Ec2KeyPair != null)
            {
                request.ComputeResources.Ec2KeyPair = requestComputeResources_computeResources_Ec2KeyPair;
                requestComputeResourcesIsNull = false;
            }
            System.String requestComputeResources_computeResources_ImageId = null;
            if (cmdletContext.ComputeResources_ImageId != null)
            {
                requestComputeResources_computeResources_ImageId = cmdletContext.ComputeResources_ImageId;
            }
            if (requestComputeResources_computeResources_ImageId != null)
            {
                request.ComputeResources.ImageId = requestComputeResources_computeResources_ImageId;
                requestComputeResourcesIsNull = false;
            }
            System.String requestComputeResources_computeResources_InstanceRole = null;
            if (cmdletContext.ComputeResources_InstanceRole != null)
            {
                requestComputeResources_computeResources_InstanceRole = cmdletContext.ComputeResources_InstanceRole;
            }
            if (requestComputeResources_computeResources_InstanceRole != null)
            {
                request.ComputeResources.InstanceRole = requestComputeResources_computeResources_InstanceRole;
                requestComputeResourcesIsNull = false;
            }
            List<System.String> requestComputeResources_computeResources_InstanceType = null;
            if (cmdletContext.ComputeResources_InstanceType != null)
            {
                requestComputeResources_computeResources_InstanceType = cmdletContext.ComputeResources_InstanceType;
            }
            if (requestComputeResources_computeResources_InstanceType != null)
            {
                request.ComputeResources.InstanceTypes = requestComputeResources_computeResources_InstanceType;
                requestComputeResourcesIsNull = false;
            }
            System.Int32? requestComputeResources_computeResources_MaxvCpu = null;
            if (cmdletContext.ComputeResources_MaxvCpu != null)
            {
                requestComputeResources_computeResources_MaxvCpu = cmdletContext.ComputeResources_MaxvCpu.Value;
            }
            if (requestComputeResources_computeResources_MaxvCpu != null)
            {
                request.ComputeResources.MaxvCpus = requestComputeResources_computeResources_MaxvCpu.Value;
                requestComputeResourcesIsNull = false;
            }
            System.Int32? requestComputeResources_computeResources_MinvCpu = null;
            if (cmdletContext.ComputeResources_MinvCpu != null)
            {
                requestComputeResources_computeResources_MinvCpu = cmdletContext.ComputeResources_MinvCpu.Value;
            }
            if (requestComputeResources_computeResources_MinvCpu != null)
            {
                request.ComputeResources.MinvCpus = requestComputeResources_computeResources_MinvCpu.Value;
                requestComputeResourcesIsNull = false;
            }
            System.String requestComputeResources_computeResources_PlacementGroup = null;
            if (cmdletContext.ComputeResources_PlacementGroup != null)
            {
                requestComputeResources_computeResources_PlacementGroup = cmdletContext.ComputeResources_PlacementGroup;
            }
            if (requestComputeResources_computeResources_PlacementGroup != null)
            {
                request.ComputeResources.PlacementGroup = requestComputeResources_computeResources_PlacementGroup;
                requestComputeResourcesIsNull = false;
            }
            List<System.String> requestComputeResources_computeResources_SecurityGroupId = null;
            if (cmdletContext.ComputeResources_SecurityGroupId != null)
            {
                requestComputeResources_computeResources_SecurityGroupId = cmdletContext.ComputeResources_SecurityGroupId;
            }
            if (requestComputeResources_computeResources_SecurityGroupId != null)
            {
                request.ComputeResources.SecurityGroupIds = requestComputeResources_computeResources_SecurityGroupId;
                requestComputeResourcesIsNull = false;
            }
            System.String requestComputeResources_computeResources_SpotIamFleetRole = null;
            if (cmdletContext.ComputeResources_SpotIamFleetRole != null)
            {
                requestComputeResources_computeResources_SpotIamFleetRole = cmdletContext.ComputeResources_SpotIamFleetRole;
            }
            if (requestComputeResources_computeResources_SpotIamFleetRole != null)
            {
                request.ComputeResources.SpotIamFleetRole = requestComputeResources_computeResources_SpotIamFleetRole;
                requestComputeResourcesIsNull = false;
            }
            List<System.String> requestComputeResources_computeResources_Subnet = null;
            if (cmdletContext.ComputeResources_Subnet != null)
            {
                requestComputeResources_computeResources_Subnet = cmdletContext.ComputeResources_Subnet;
            }
            if (requestComputeResources_computeResources_Subnet != null)
            {
                request.ComputeResources.Subnets = requestComputeResources_computeResources_Subnet;
                requestComputeResourcesIsNull = false;
            }
            Dictionary<System.String, System.String> requestComputeResources_computeResources_Tag = null;
            if (cmdletContext.ComputeResources_Tag != null)
            {
                requestComputeResources_computeResources_Tag = cmdletContext.ComputeResources_Tag;
            }
            if (requestComputeResources_computeResources_Tag != null)
            {
                request.ComputeResources.Tags = requestComputeResources_computeResources_Tag;
                requestComputeResourcesIsNull = false;
            }
            Amazon.Batch.CRType requestComputeResources_computeResources_Type = null;
            if (cmdletContext.ComputeResources_Type != null)
            {
                requestComputeResources_computeResources_Type = cmdletContext.ComputeResources_Type;
            }
            if (requestComputeResources_computeResources_Type != null)
            {
                request.ComputeResources.Type = requestComputeResources_computeResources_Type;
                requestComputeResourcesIsNull = false;
            }
            Amazon.Batch.Model.ComputeScalingPolicy requestComputeResources_computeResources_ScalingPolicy = null;
            
             // populate ScalingPolicy
            var requestComputeResources_computeResources_ScalingPolicyIsNull = true;
            requestComputeResources_computeResources_ScalingPolicy = new Amazon.Batch.Model.ComputeScalingPolicy();
            System.Int32? requestComputeResources_computeResources_ScalingPolicy_computeResources_ScalingPolicy_MinScaleDownDelayMinute = null;
            if (cmdletContext.ComputeResources_ScalingPolicy_MinScaleDownDelayMinute != null)
            {
                requestComputeResources_computeResources_ScalingPolicy_computeResources_ScalingPolicy_MinScaleDownDelayMinute = cmdletContext.ComputeResources_ScalingPolicy_MinScaleDownDelayMinute.Value;
            }
            if (requestComputeResources_computeResources_ScalingPolicy_computeResources_ScalingPolicy_MinScaleDownDelayMinute != null)
            {
                requestComputeResources_computeResources_ScalingPolicy.MinScaleDownDelayMinutes = requestComputeResources_computeResources_ScalingPolicy_computeResources_ScalingPolicy_MinScaleDownDelayMinute.Value;
                requestComputeResources_computeResources_ScalingPolicyIsNull = false;
            }
             // determine if requestComputeResources_computeResources_ScalingPolicy should be set to null
            if (requestComputeResources_computeResources_ScalingPolicyIsNull)
            {
                requestComputeResources_computeResources_ScalingPolicy = null;
            }
            if (requestComputeResources_computeResources_ScalingPolicy != null)
            {
                request.ComputeResources.ScalingPolicy = requestComputeResources_computeResources_ScalingPolicy;
                requestComputeResourcesIsNull = false;
            }
            Amazon.Batch.Model.ManagedInstancesProvider requestComputeResources_computeResources_ManagedInstancesProvider = null;
            
             // populate ManagedInstancesProvider
            var requestComputeResources_computeResources_ManagedInstancesProviderIsNull = true;
            requestComputeResources_computeResources_ManagedInstancesProvider = new Amazon.Batch.Model.ManagedInstancesProvider();
            System.String requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InfrastructureRoleArn = null;
            if (cmdletContext.ComputeResources_ManagedInstancesProvider_InfrastructureRoleArn != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InfrastructureRoleArn = cmdletContext.ComputeResources_ManagedInstancesProvider_InfrastructureRoleArn;
            }
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InfrastructureRoleArn != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider.InfrastructureRoleArn = requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InfrastructureRoleArn;
                requestComputeResources_computeResources_ManagedInstancesProviderIsNull = false;
            }
            System.String requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_PropagateTag = null;
            if (cmdletContext.ComputeResources_ManagedInstancesProvider_PropagateTag != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_PropagateTag = cmdletContext.ComputeResources_ManagedInstancesProvider_PropagateTag;
            }
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_PropagateTag != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider.PropagateTags = requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_PropagateTag;
                requestComputeResources_computeResources_ManagedInstancesProviderIsNull = false;
            }
            Amazon.Batch.Model.InfrastructureOptimization requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InfrastructureOptimization = null;
            
             // populate InfrastructureOptimization
            var requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InfrastructureOptimizationIsNull = true;
            requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InfrastructureOptimization = new Amazon.Batch.Model.InfrastructureOptimization();
            System.Int32? requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InfrastructureOptimization_computeResources_ManagedInstancesProvider_InfrastructureOptimization_ScaleInAfter = null;
            if (cmdletContext.ComputeResources_ManagedInstancesProvider_InfrastructureOptimization_ScaleInAfter != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InfrastructureOptimization_computeResources_ManagedInstancesProvider_InfrastructureOptimization_ScaleInAfter = cmdletContext.ComputeResources_ManagedInstancesProvider_InfrastructureOptimization_ScaleInAfter.Value;
            }
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InfrastructureOptimization_computeResources_ManagedInstancesProvider_InfrastructureOptimization_ScaleInAfter != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InfrastructureOptimization.ScaleInAfter = requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InfrastructureOptimization_computeResources_ManagedInstancesProvider_InfrastructureOptimization_ScaleInAfter.Value;
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InfrastructureOptimizationIsNull = false;
            }
             // determine if requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InfrastructureOptimization should be set to null
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InfrastructureOptimizationIsNull)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InfrastructureOptimization = null;
            }
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InfrastructureOptimization != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider.InfrastructureOptimization = requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InfrastructureOptimization;
                requestComputeResources_computeResources_ManagedInstancesProviderIsNull = false;
            }
            Amazon.Batch.Model.InstanceLaunchTemplate requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate = null;
            
             // populate InstanceLaunchTemplate
            var requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplateIsNull = true;
            requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate = new Amazon.Batch.Model.InstanceLaunchTemplate();
            System.String requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityOptionType = null;
            if (cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityOptionType != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityOptionType = cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityOptionType;
            }
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityOptionType != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate.CapacityOptionType = requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityOptionType;
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplateIsNull = false;
            }
            System.String requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_Ec2InstanceProfileArn = null;
            if (cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_Ec2InstanceProfileArn != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_Ec2InstanceProfileArn = cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_Ec2InstanceProfileArn;
            }
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_Ec2InstanceProfileArn != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate.Ec2InstanceProfileArn = requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_Ec2InstanceProfileArn;
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplateIsNull = false;
            }
            System.Boolean? requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_FipsEnabled = null;
            if (cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_FipsEnabled != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_FipsEnabled = cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_FipsEnabled.Value;
            }
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_FipsEnabled != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate.FipsEnabled = requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_FipsEnabled.Value;
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplateIsNull = false;
            }
            System.Boolean? requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceMetadataTagsPropagation = null;
            if (cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceMetadataTagsPropagation != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceMetadataTagsPropagation = cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceMetadataTagsPropagation.Value;
            }
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceMetadataTagsPropagation != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate.InstanceMetadataTagsPropagation = requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceMetadataTagsPropagation.Value;
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplateIsNull = false;
            }
            System.String requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_Monitoring = null;
            if (cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_Monitoring != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_Monitoring = cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_Monitoring;
            }
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_Monitoring != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate.Monitoring = requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_Monitoring;
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplateIsNull = false;
            }
            Amazon.Batch.Model.InstanceRequirementsRequest requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements = null;
            
             // populate InstanceRequirements
            var requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = true;
            requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements = new Amazon.Batch.Model.InstanceRequirementsRequest();
            List<System.String> requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AllowedInstanceType = null;
            if (cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AllowedInstanceType != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AllowedInstanceType = cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AllowedInstanceType;
            }
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AllowedInstanceType != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements.AllowedInstanceTypes = requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AllowedInstanceType;
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull = false;
            }
             // determine if requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements should be set to null
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirementsIsNull)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements = null;
            }
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate.InstanceRequirements = requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements;
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplateIsNull = false;
            }
            Amazon.Batch.Model.ManagedInstancesLocalStorageConfiguration requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration = null;
            
             // populate LocalStorageConfiguration
            var requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfigurationIsNull = true;
            requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration = new Amazon.Batch.Model.ManagedInstancesLocalStorageConfiguration();
            System.Boolean? requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration_UseLocalStorage = null;
            if (cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration_UseLocalStorage != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration_UseLocalStorage = cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration_UseLocalStorage.Value;
            }
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration_UseLocalStorage != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration.UseLocalStorage = requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration_UseLocalStorage.Value;
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfigurationIsNull = false;
            }
             // determine if requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration should be set to null
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfigurationIsNull)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration = null;
            }
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate.LocalStorageConfiguration = requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration;
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplateIsNull = false;
            }
            Amazon.Batch.Model.ManagedInstancesStorageConfiguration requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration = null;
            
             // populate StorageConfiguration
            var requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfigurationIsNull = true;
            requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration = new Amazon.Batch.Model.ManagedInstancesStorageConfiguration();
            System.Int32? requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration_StorageSizeGiB = null;
            if (cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration_StorageSizeGiB != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration_StorageSizeGiB = cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration_StorageSizeGiB.Value;
            }
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration_StorageSizeGiB != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration.StorageSizeGiB = requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration_StorageSizeGiB.Value;
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfigurationIsNull = false;
            }
             // determine if requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration should be set to null
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfigurationIsNull)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration = null;
            }
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate.StorageConfiguration = requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration;
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplateIsNull = false;
            }
            Amazon.Batch.Model.CapacityReservationRequest requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations = null;
            
             // populate CapacityReservations
            var requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservationsIsNull = true;
            requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations = new Amazon.Batch.Model.CapacityReservationRequest();
            System.String requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationGroupArn = null;
            if (cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationGroupArn != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationGroupArn = cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationGroupArn;
            }
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationGroupArn != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations.ReservationGroupArn = requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationGroupArn;
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservationsIsNull = false;
            }
            System.String requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationPreference = null;
            if (cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationPreference != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationPreference = cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationPreference;
            }
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationPreference != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations.ReservationPreference = requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationPreference;
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservationsIsNull = false;
            }
             // determine if requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations should be set to null
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservationsIsNull)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations = null;
            }
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate.CapacityReservations = requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations;
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplateIsNull = false;
            }
            Amazon.Batch.Model.ManagedInstancesNetworkConfiguration requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration = null;
            
             // populate NetworkConfiguration
            var requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfigurationIsNull = true;
            requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration = new Amazon.Batch.Model.ManagedInstancesNetworkConfiguration();
            List<System.String> requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_SecurityGroup = null;
            if (cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_SecurityGroup != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_SecurityGroup = cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_SecurityGroup;
            }
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_SecurityGroup != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration.SecurityGroups = requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_SecurityGroup;
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfigurationIsNull = false;
            }
            List<System.String> requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_Subnet = null;
            if (cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_Subnet != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_Subnet = cmdletContext.ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_Subnet;
            }
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_Subnet != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration.Subnets = requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_Subnet;
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfigurationIsNull = false;
            }
             // determine if requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration should be set to null
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfigurationIsNull)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration = null;
            }
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate.NetworkConfiguration = requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration;
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplateIsNull = false;
            }
             // determine if requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate should be set to null
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplateIsNull)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate = null;
            }
            if (requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate != null)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider.InstanceLaunchTemplate = requestComputeResources_computeResources_ManagedInstancesProvider_computeResources_ManagedInstancesProvider_InstanceLaunchTemplate;
                requestComputeResources_computeResources_ManagedInstancesProviderIsNull = false;
            }
             // determine if requestComputeResources_computeResources_ManagedInstancesProvider should be set to null
            if (requestComputeResources_computeResources_ManagedInstancesProviderIsNull)
            {
                requestComputeResources_computeResources_ManagedInstancesProvider = null;
            }
            if (requestComputeResources_computeResources_ManagedInstancesProvider != null)
            {
                request.ComputeResources.ManagedInstancesProvider = requestComputeResources_computeResources_ManagedInstancesProvider;
                requestComputeResourcesIsNull = false;
            }
            Amazon.Batch.Model.LaunchTemplateSpecification requestComputeResources_computeResources_LaunchTemplate = null;
            
             // populate LaunchTemplate
            var requestComputeResources_computeResources_LaunchTemplateIsNull = true;
            requestComputeResources_computeResources_LaunchTemplate = new Amazon.Batch.Model.LaunchTemplateSpecification();
            System.String requestComputeResources_computeResources_LaunchTemplate_launchTemplate_LaunchTemplateId = null;
            if (cmdletContext.LaunchTemplate_LaunchTemplateId != null)
            {
                requestComputeResources_computeResources_LaunchTemplate_launchTemplate_LaunchTemplateId = cmdletContext.LaunchTemplate_LaunchTemplateId;
            }
            if (requestComputeResources_computeResources_LaunchTemplate_launchTemplate_LaunchTemplateId != null)
            {
                requestComputeResources_computeResources_LaunchTemplate.LaunchTemplateId = requestComputeResources_computeResources_LaunchTemplate_launchTemplate_LaunchTemplateId;
                requestComputeResources_computeResources_LaunchTemplateIsNull = false;
            }
            System.String requestComputeResources_computeResources_LaunchTemplate_launchTemplate_LaunchTemplateName = null;
            if (cmdletContext.LaunchTemplate_LaunchTemplateName != null)
            {
                requestComputeResources_computeResources_LaunchTemplate_launchTemplate_LaunchTemplateName = cmdletContext.LaunchTemplate_LaunchTemplateName;
            }
            if (requestComputeResources_computeResources_LaunchTemplate_launchTemplate_LaunchTemplateName != null)
            {
                requestComputeResources_computeResources_LaunchTemplate.LaunchTemplateName = requestComputeResources_computeResources_LaunchTemplate_launchTemplate_LaunchTemplateName;
                requestComputeResources_computeResources_LaunchTemplateIsNull = false;
            }
            List<Amazon.Batch.Model.LaunchTemplateSpecificationOverride> requestComputeResources_computeResources_LaunchTemplate_launchTemplate_Override = null;
            if (cmdletContext.LaunchTemplate_Override != null)
            {
                requestComputeResources_computeResources_LaunchTemplate_launchTemplate_Override = cmdletContext.LaunchTemplate_Override;
            }
            if (requestComputeResources_computeResources_LaunchTemplate_launchTemplate_Override != null)
            {
                requestComputeResources_computeResources_LaunchTemplate.Overrides = requestComputeResources_computeResources_LaunchTemplate_launchTemplate_Override;
                requestComputeResources_computeResources_LaunchTemplateIsNull = false;
            }
            Amazon.Batch.UserdataType requestComputeResources_computeResources_LaunchTemplate_launchTemplate_UserdataType = null;
            if (cmdletContext.LaunchTemplate_UserdataType != null)
            {
                requestComputeResources_computeResources_LaunchTemplate_launchTemplate_UserdataType = cmdletContext.LaunchTemplate_UserdataType;
            }
            if (requestComputeResources_computeResources_LaunchTemplate_launchTemplate_UserdataType != null)
            {
                requestComputeResources_computeResources_LaunchTemplate.UserdataType = requestComputeResources_computeResources_LaunchTemplate_launchTemplate_UserdataType;
                requestComputeResources_computeResources_LaunchTemplateIsNull = false;
            }
            System.String requestComputeResources_computeResources_LaunchTemplate_launchTemplate_Version = null;
            if (cmdletContext.LaunchTemplate_Version != null)
            {
                requestComputeResources_computeResources_LaunchTemplate_launchTemplate_Version = cmdletContext.LaunchTemplate_Version;
            }
            if (requestComputeResources_computeResources_LaunchTemplate_launchTemplate_Version != null)
            {
                requestComputeResources_computeResources_LaunchTemplate.Version = requestComputeResources_computeResources_LaunchTemplate_launchTemplate_Version;
                requestComputeResources_computeResources_LaunchTemplateIsNull = false;
            }
             // determine if requestComputeResources_computeResources_LaunchTemplate should be set to null
            if (requestComputeResources_computeResources_LaunchTemplateIsNull)
            {
                requestComputeResources_computeResources_LaunchTemplate = null;
            }
            if (requestComputeResources_computeResources_LaunchTemplate != null)
            {
                request.ComputeResources.LaunchTemplate = requestComputeResources_computeResources_LaunchTemplate;
                requestComputeResourcesIsNull = false;
            }
             // determine if request.ComputeResources should be set to null
            if (requestComputeResourcesIsNull)
            {
                request.ComputeResources = null;
            }
            if (cmdletContext.Context != null)
            {
                request.Context = cmdletContext.Context;
            }
            
             // populate EcsSettings
            var requestEcsSettingsIsNull = true;
            request.EcsSettings = new Amazon.Batch.Model.EcsSettings();
            Amazon.Batch.ContainerInsights requestEcsSettings_ecsSettings_ContainerInsight = null;
            if (cmdletContext.EcsSettings_ContainerInsight != null)
            {
                requestEcsSettings_ecsSettings_ContainerInsight = cmdletContext.EcsSettings_ContainerInsight;
            }
            if (requestEcsSettings_ecsSettings_ContainerInsight != null)
            {
                request.EcsSettings.ContainerInsights = requestEcsSettings_ecsSettings_ContainerInsight;
                requestEcsSettingsIsNull = false;
            }
             // determine if request.EcsSettings should be set to null
            if (requestEcsSettingsIsNull)
            {
                request.EcsSettings = null;
            }
            
             // populate EksConfiguration
            var requestEksConfigurationIsNull = true;
            request.EksConfiguration = new Amazon.Batch.Model.EksConfiguration();
            System.String requestEksConfiguration_eksConfiguration_EksClusterArn = null;
            if (cmdletContext.EksConfiguration_EksClusterArn != null)
            {
                requestEksConfiguration_eksConfiguration_EksClusterArn = cmdletContext.EksConfiguration_EksClusterArn;
            }
            if (requestEksConfiguration_eksConfiguration_EksClusterArn != null)
            {
                request.EksConfiguration.EksClusterArn = requestEksConfiguration_eksConfiguration_EksClusterArn;
                requestEksConfigurationIsNull = false;
            }
            System.String requestEksConfiguration_eksConfiguration_KubernetesNamespace = null;
            if (cmdletContext.EksConfiguration_KubernetesNamespace != null)
            {
                requestEksConfiguration_eksConfiguration_KubernetesNamespace = cmdletContext.EksConfiguration_KubernetesNamespace;
            }
            if (requestEksConfiguration_eksConfiguration_KubernetesNamespace != null)
            {
                request.EksConfiguration.KubernetesNamespace = requestEksConfiguration_eksConfiguration_KubernetesNamespace;
                requestEksConfigurationIsNull = false;
            }
             // determine if request.EksConfiguration should be set to null
            if (requestEksConfigurationIsNull)
            {
                request.EksConfiguration = null;
            }
            if (cmdletContext.ServiceRole != null)
            {
                request.ServiceRole = cmdletContext.ServiceRole;
            }
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            if (cmdletContext.UnmanagedvCpu != null)
            {
                request.UnmanagedvCpus = cmdletContext.UnmanagedvCpu.Value;
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
        
        private Amazon.Batch.Model.CreateComputeEnvironmentResponse CallAWSServiceOperation(IAmazonBatch client, Amazon.Batch.Model.CreateComputeEnvironmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Batch", "CreateComputeEnvironment");
            try
            {
                return client.CreateComputeEnvironmentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ComputeEnvironmentName { get; set; }
            public Amazon.Batch.CRAllocationStrategy ComputeResources_AllocationStrategy { get; set; }
            public System.Int32? ComputeResources_BidPercentage { get; set; }
            public Dictionary<System.String, System.String> ComputeResources_CapacityTag { get; set; }
            public System.Int32? ComputeResources_DesiredvCpu { get; set; }
            public List<Amazon.Batch.Model.Ec2Configuration> ComputeResources_Ec2Configuration { get; set; }
            public System.String ComputeResources_Ec2KeyPair { get; set; }
            [System.ObsoleteAttribute]
            public System.String ComputeResources_ImageId { get; set; }
            public System.String ComputeResources_InstanceRole { get; set; }
            public List<System.String> ComputeResources_InstanceType { get; set; }
            public System.String LaunchTemplate_LaunchTemplateId { get; set; }
            public System.String LaunchTemplate_LaunchTemplateName { get; set; }
            public List<Amazon.Batch.Model.LaunchTemplateSpecificationOverride> LaunchTemplate_Override { get; set; }
            public Amazon.Batch.UserdataType LaunchTemplate_UserdataType { get; set; }
            public System.String LaunchTemplate_Version { get; set; }
            public System.Int32? ComputeResources_ManagedInstancesProvider_InfrastructureOptimization_ScaleInAfter { get; set; }
            public System.String ComputeResources_ManagedInstancesProvider_InfrastructureRoleArn { get; set; }
            public System.String ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityOptionType { get; set; }
            public System.String ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationGroupArn { get; set; }
            public System.String ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_CapacityReservations_ReservationPreference { get; set; }
            public System.String ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_Ec2InstanceProfileArn { get; set; }
            public System.Boolean? ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_FipsEnabled { get; set; }
            public System.Boolean? ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceMetadataTagsPropagation { get; set; }
            public List<System.String> ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_InstanceRequirements_AllowedInstanceType { get; set; }
            public System.Boolean? ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_LocalStorageConfiguration_UseLocalStorage { get; set; }
            public System.String ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_Monitoring { get; set; }
            public List<System.String> ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_SecurityGroup { get; set; }
            public List<System.String> ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_NetworkConfiguration_Subnet { get; set; }
            public System.Int32? ComputeResources_ManagedInstancesProvider_InstanceLaunchTemplate_StorageConfiguration_StorageSizeGiB { get; set; }
            public System.String ComputeResources_ManagedInstancesProvider_PropagateTag { get; set; }
            public System.Int32? ComputeResources_MaxvCpu { get; set; }
            public System.Int32? ComputeResources_MinvCpu { get; set; }
            public System.String ComputeResources_PlacementGroup { get; set; }
            public System.Int32? ComputeResources_ScalingPolicy_MinScaleDownDelayMinute { get; set; }
            public List<System.String> ComputeResources_SecurityGroupId { get; set; }
            public System.String ComputeResources_SpotIamFleetRole { get; set; }
            public List<System.String> ComputeResources_Subnet { get; set; }
            public Dictionary<System.String, System.String> ComputeResources_Tag { get; set; }
            public Amazon.Batch.CRType ComputeResources_Type { get; set; }
            public System.String Context { get; set; }
            public Amazon.Batch.ContainerInsights EcsSettings_ContainerInsight { get; set; }
            public System.String EksConfiguration_EksClusterArn { get; set; }
            public System.String EksConfiguration_KubernetesNamespace { get; set; }
            public System.String ServiceRole { get; set; }
            public Amazon.Batch.CEState State { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.Batch.CEType Type { get; set; }
            public System.Int32? UnmanagedvCpu { get; set; }
            public System.Func<Amazon.Batch.Model.CreateComputeEnvironmentResponse, NewBATComputeEnvironmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
