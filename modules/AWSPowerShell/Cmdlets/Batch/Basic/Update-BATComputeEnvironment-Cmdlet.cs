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

namespace Amazon.PowerShell.Cmdlets.BAT
{
    /// <summary>
    /// Updates an Batch compute environment.
    /// </summary>
    [Cmdlet("Update", "BATComputeEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Batch.Model.UpdateComputeEnvironmentResponse")]
    [AWSCmdlet("Calls the AWS Batch UpdateComputeEnvironment API operation.", Operation = new[] {"UpdateComputeEnvironment"}, SelectReturnType = typeof(Amazon.Batch.Model.UpdateComputeEnvironmentResponse))]
    [AWSCmdletOutput("Amazon.Batch.Model.UpdateComputeEnvironmentResponse",
        "This cmdlet returns an Amazon.Batch.Model.UpdateComputeEnvironmentResponse object containing multiple properties."
    )]
    public partial class UpdateBATComputeEnvironmentCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ComputeResources_AllocationStrategy
        /// <summary>
        /// <para>
        /// <para>The allocation strategy to use for the compute resource if there's not enough instances
        /// of the best fitting instance type that can be allocated. This might be because of
        /// availability of the instance type in the Region or <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-resource-limits.html">Amazon
        /// EC2 service limits</a>. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/allocation-strategies.html">Allocation
        /// strategies</a> in the <i>Batch User Guide</i>.</para><para>When updating a compute environment, changing the allocation strategy requires an
        /// infrastructure update of the compute environment. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/updating-compute-environments.html">Updating
        /// compute environments</a> in the <i>Batch User Guide</i>. <c>BEST_FIT</c> isn't supported
        /// when updating a compute environment.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note><dl><dt>BEST_FIT_PROGRESSIVE</dt><dd><para>Batch selects additional instance types that are large enough to meet the requirements
        /// of the jobs in the queue. Its preference is for instance types with lower cost vCPUs.
        /// If additional instances of the previously selected instance types aren't available,
        /// Batch selects new instance types.</para></dd><dt>SPOT_CAPACITY_OPTIMIZED</dt><dd><para>Batch selects one or more instance types that are large enough to meet the requirements
        /// of the jobs in the queue. Its preference is for instance types that are less likely
        /// to be interrupted. This allocation strategy is only available for Spot Instance compute
        /// resources.</para></dd><dt>SPOT_PRICE_CAPACITY_OPTIMIZED</dt><dd><para>The price and capacity optimized allocation strategy looks at both price and capacity
        /// to select the Spot Instance pools that are the least likely to be interrupted and
        /// have the lowest possible price. This allocation strategy is only available for Spot
        /// Instance compute resources.</para></dd></dl><para>With <c>BEST_FIT_PROGRESSIVE</c>,<c>SPOT_CAPACITY_OPTIMIZED</c> and <c>SPOT_PRICE_CAPACITY_OPTIMIZED</c>
        /// (recommended) strategies using On-Demand or Spot Instances, and the <c>BEST_FIT</c>
        /// strategy using Spot Instances, Batch might need to exceed <c>maxvCpus</c> to meet
        /// your capacity requirements. In this event, Batch never exceeds <c>maxvCpus</c> by
        /// more than a single instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Batch.CRUpdateAllocationStrategy")]
        public Amazon.Batch.CRUpdateAllocationStrategy ComputeResources_AllocationStrategy { get; set; }
        #endregion
        
        #region Parameter ComputeResources_BidPercentage
        /// <summary>
        /// <para>
        /// <para>The maximum percentage that a Spot Instance price can be when compared with the On-Demand
        /// price for that instance type before instances are launched. For example, if your maximum
        /// percentage is 20%, the Spot price must be less than 20% of the current On-Demand price
        /// for that Amazon EC2 instance. You always pay the lowest (market) price and never more
        /// than your maximum percentage. For most use cases, we recommend leaving this field
        /// empty.</para><para>When updating a compute environment, changing the bid percentage requires an infrastructure
        /// update of the compute environment. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/updating-compute-environments.html">Updating
        /// compute environments</a> in the <i>Batch User Guide</i>.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ComputeResources_BidPercentage { get; set; }
        #endregion
        
        #region Parameter ComputeEnvironment
        /// <summary>
        /// <para>
        /// <para>The name or full Amazon Resource Name (ARN) of the compute environment to update.</para>
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
        public System.String ComputeEnvironment { get; set; }
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
        /// specify it.</para></note><note><para>Batch doesn't support changing the desired number of vCPUs of an existing compute
        /// environment. Don't specify this parameter for compute environments using Amazon EKS
        /// clusters.</para></note><note><para>When you update the <c>desiredvCpus</c> setting, the value must be between the <c>minvCpus</c>
        /// and <c>maxvCpus</c> values. </para><para>Additionally, the updated <c>desiredvCpus</c> value must be greater than or equal
        /// to the current <c>desiredvCpus</c> value. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/troubleshooting.html#error-desired-vcpus-update">Troubleshooting
        /// Batch</a> in the <i>Batch User Guide</i>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_DesiredvCpus")]
        public System.Int32? ComputeResources_DesiredvCpu { get; set; }
        #endregion
        
        #region Parameter ComputeResources_Ec2Configuration
        /// <summary>
        /// <para>
        /// <para>Provides information used to select Amazon Machine Images (AMIs) for Amazon EC2 instances
        /// in the compute environment. If <c>Ec2Configuration</c> isn't specified, the default
        /// is <c>ECS_AL2</c>.</para><para>When updating a compute environment, changing this setting requires an infrastructure
        /// update of the compute environment. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/updating-compute-environments.html">Updating
        /// compute environments</a> in the <i>Batch User Guide</i>. To remove the Amazon EC2
        /// configuration and any custom AMI ID specified in <c>imageIdOverride</c>, set this
        /// value to an empty string.</para><para>One or two values can be provided.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Batch.Model.Ec2Configuration[] ComputeResources_Ec2Configuration { get; set; }
        #endregion
        
        #region Parameter ComputeResources_Ec2KeyPair
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 key pair that's used for instances launched in the compute environment.
        /// You can use this key pair to log in to your instances with SSH. To remove the Amazon
        /// EC2 key pair, set this value to an empty string.</para><para>When updating a compute environment, changing the Amazon EC2 key pair requires an
        /// infrastructure update of the compute environment. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/updating-compute-environments.html">Updating
        /// compute environments</a> in the <i>Batch User Guide</i>.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeResources_Ec2KeyPair { get; set; }
        #endregion
        
        #region Parameter ComputeResources_ImageId
        /// <summary>
        /// <para>
        /// <para>The Amazon Machine Image (AMI) ID used for instances launched in the compute environment.
        /// This parameter is overridden by the <c>imageIdOverride</c> member of the <c>Ec2Configuration</c>
        /// structure. To remove the custom AMI ID and use the default AMI ID, set this value
        /// to an empty string.</para><para>When updating a compute environment, changing the AMI ID requires an infrastructure
        /// update of the compute environment. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/updating-compute-environments.html">Updating
        /// compute environments</a> in the <i>Batch User Guide</i>.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note><note><para>The AMI that you choose for a compute environment must match the architecture of the
        /// instance types that you intend to use for that compute environment. For example, if
        /// your compute environment uses A1 instance types, the compute resource AMI that you
        /// choose must support ARM instances. Amazon ECS vends both x86 and ARM versions of the
        /// Amazon ECS-optimized Amazon Linux 2 AMI. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs-optimized_AMI.html#ecs-optimized-ami-linux-variants.html">Amazon
        /// ECS-optimized Amazon Linux 2 AMI</a> in the <i>Amazon Elastic Container Service Developer
        /// Guide</i>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeResources_ImageId { get; set; }
        #endregion
        
        #region Parameter ComputeResources_InstanceRole
        /// <summary>
        /// <para>
        /// <para>The Amazon ECS instance profile applied to Amazon EC2 instances in a compute environment.
        /// Required for Amazon EC2 instances. You can specify the short name or full Amazon Resource
        /// Name (ARN) of an instance profile. For example, <c><i>ecsInstanceRole</i></c> or
        /// <c>arn:aws:iam::<i>&lt;aws_account_id&gt;</i>:instance-profile/<i>ecsInstanceRole</i></c>. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/instance_IAM_role.html">Amazon
        /// ECS instance role</a> in the <i>Batch User Guide</i>.</para><para>When updating a compute environment, changing this setting requires an infrastructure
        /// update of the compute environment. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/updating-compute-environments.html">Updating
        /// compute environments</a> in the <i>Batch User Guide</i>.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note>
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
        /// you can specify specific sizes within a family (such as <c>c5.8xlarge</c>). You can
        /// also choose <c>optimal</c> to select instance types (from the C4, M4, and R4 instance
        /// families) that match the demand of your job queues.</para><para>When updating a compute environment, changing this setting requires an infrastructure
        /// update of the compute environment. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/updating-compute-environments.html">Updating
        /// compute environments</a> in the <i>Batch User Guide</i>.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note><note><para>When you create a compute environment, the instance types that you select for the
        /// compute environment must share the same architecture. For example, you can't mix x86
        /// and ARM instances in the same compute environment.</para></note><note><para>Currently, <c>optimal</c> uses instance types from the C4, M4, and R4 instance families.
        /// In Regions that don't have instance types from those instance families, instance types
        /// from the C5, M5, and R5 instance families are used.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_InstanceTypes")]
        public System.String[] ComputeResources_InstanceType { get; set; }
        #endregion
        
        #region Parameter UpdatePolicy_JobExecutionTimeoutMinute
        /// <summary>
        /// <para>
        /// <para>Specifies the job timeout (in minutes) when the compute environment infrastructure
        /// is updated. The default value is 30.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UpdatePolicy_JobExecutionTimeoutMinutes")]
        public System.Int64? UpdatePolicy_JobExecutionTimeoutMinute { get; set; }
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
        /// <para>The maximum number of Amazon EC2 vCPUs that an environment can reach.</para><note><para>With <c>BEST_FIT_PROGRESSIVE</c>,<c>SPOT_CAPACITY_OPTIMIZED</c> and <c>SPOT_PRICE_CAPACITY_OPTIMIZED</c>
        /// (recommended) strategies using On-Demand or Spot Instances, and the <c>BEST_FIT</c>
        /// strategy using Spot Instances, Batch might need to exceed <c>maxvCpus</c> to meet
        /// your capacity requirements. In this event, Batch never exceeds <c>maxvCpus</c> by
        /// more than a single instance.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_MaxvCpus")]
        public System.Int32? ComputeResources_MaxvCpu { get; set; }
        #endregion
        
        #region Parameter ComputeResources_MinvCpu
        /// <summary>
        /// <para>
        /// <para>The minimum number of vCPUs that an environment should maintain (even if the compute
        /// environment is <c>DISABLED</c>).</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_MinvCpus")]
        public System.Int32? ComputeResources_MinvCpu { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_Override
        /// <summary>
        /// <para>
        /// <para>A launch template to use in place of the default launch template. You must specify
        /// either the launch template ID or launch template name in the request, but not both.</para><para>You can specify up to ten (10) launch template overrides that are associated to unique
        /// instance types or families for each compute environment.</para><note><para>To unset all override templates for a compute environment, you can pass an empty array
        /// to the <a href="https://docs.aws.amazon.com/batch/latest/APIReference/API_UpdateComputeEnvironment.html">UpdateComputeEnvironment.overrides</a>
        /// parameter, or not include the <c>overrides</c> parameter when submitting the <c>UpdateComputeEnvironment</c>
        /// API operation.</para></note>
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
        /// groups</a> in the <i>Amazon EC2 User Guide for Linux Instances</i>.</para><para>When updating a compute environment, changing the placement group requires an infrastructure
        /// update of the compute environment. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/updating-compute-environments.html">Updating
        /// compute environments</a> in the <i>Batch User Guide</i>.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeResources_PlacementGroup { get; set; }
        #endregion
        
        #region Parameter ComputeResources_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 security groups that are associated with instances launched in the
        /// compute environment. This parameter is required for Fargate compute resources, where
        /// it can contain up to 5 security groups. For Fargate compute resources, providing an
        /// empty list is handled as if this parameter wasn't specified and no change is made.
        /// For Amazon EC2 compute resources, providing an empty list removes the security groups
        /// from the compute resource.</para><para>When updating a compute environment, changing the Amazon EC2 security groups requires
        /// an infrastructure update of the compute environment. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/updating-compute-environments.html">Updating
        /// compute environments</a> in the <i>Batch User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_SecurityGroupIds")]
        public System.String[] ComputeResources_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter ServiceRole
        /// <summary>
        /// <para>
        /// <para>The full Amazon Resource Name (ARN) of the IAM role that allows Batch to make calls
        /// to other Amazon Web Services services on your behalf. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/service_IAM_role.html">Batch
        /// service IAM role</a> in the <i>Batch User Guide</i>.</para><important><para>If the compute environment has a service-linked role, it can't be changed to use a
        /// regular IAM role. Likewise, if the compute environment has a regular IAM role, it
        /// can't be changed to use a service-linked role. To update the parameters for the compute
        /// environment that require an infrastructure update to change, the <b>AWSServiceRoleForBatch</b>
        /// service-linked role must be used. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/updating-compute-environments.html">Updating
        /// compute environments</a> in the <i>Batch User Guide</i>.</para></important><para>If your specified role has a path other than <c>/</c>, then you must either specify
        /// the full role ARN (recommended) or prefix the role name with the path.</para><note><para>Depending on how you created your Batch service role, its ARN might contain the <c>service-role</c>
        /// path prefix. When you only specify the name of the service role, Batch assumes that
        /// your ARN doesn't use the <c>service-role</c> path prefix. Because of this, we recommend
        /// that you specify the full ARN of your service role when you create compute environments.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceRole { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The state of the compute environment. Compute environments in the <c>ENABLED</c> state
        /// can accept jobs from a queue and scale in or out automatically based on the workload
        /// demand of its associated queues.</para><para>If the state is <c>ENABLED</c>, then the Batch scheduler can attempt to place jobs
        /// from an associated job queue on the compute resources within the environment. If the
        /// compute environment is managed, then it can scale its instances out or in automatically,
        /// based on the job queue demand.</para><para>If the state is <c>DISABLED</c>, then the Batch scheduler doesn't attempt to place
        /// jobs within the environment. Jobs in a <c>STARTING</c> or <c>RUNNING</c> state continue
        /// to progress normally. Managed compute environments in the <c>DISABLED</c> state don't
        /// scale out. </para><note><para>Compute environments in a <c>DISABLED</c> state may continue to incur billing charges.
        /// To prevent additional charges, turn off and then delete the compute environment. For
        /// more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/compute_environment_parameters.html#compute_environment_state">State</a>
        /// in the <i>Batch User Guide</i>.</para></note><para>When an instance is idle, the instance scales down to the <c>minvCpus</c> value. However,
        /// the instance size doesn't change. For example, consider a <c>c5.8xlarge</c> instance
        /// with a <c>minvCpus</c> value of <c>4</c> and a <c>desiredvCpus</c> value of <c>36</c>.
        /// This instance doesn't scale down to a <c>c5.large</c> instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Batch.CEState")]
        public Amazon.Batch.CEState State { get; set; }
        #endregion
        
        #region Parameter ComputeResources_Subnet
        /// <summary>
        /// <para>
        /// <para>The VPC subnets where the compute resources are launched. Fargate compute resources
        /// can contain up to 16 subnets. For Fargate compute resources, providing an empty list
        /// will be handled as if this parameter wasn't specified and no change is made. For Amazon
        /// EC2 compute resources, providing an empty list removes the VPC subnets from the compute
        /// resource. For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_Subnets.html">VPCs
        /// and subnets</a> in the <i>Amazon VPC User Guide</i>.</para><para>When updating a compute environment, changing the VPC subnets requires an infrastructure
        /// update of the compute environment. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/updating-compute-environments.html">Updating
        /// compute environments</a> in the <i>Batch User Guide</i>.</para><note><para>Batch on Amazon EC2 and Batch on Amazon EKS support Local Zones. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/using-regions-availability-zones.html#concepts-local-zones">
        /// Local Zones</a> in the <i>Amazon EC2 User Guide for Linux Instances</i>, <a href="https://docs.aws.amazon.com/eks/latest/userguide/local-zones.html">Amazon
        /// EKS and Amazon Web Services Local Zones</a> in the <i>Amazon EKS User Guide</i> and
        /// <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/cluster-regions-zones.html#clusters-local-zones">
        /// Amazon ECS clusters in Local Zones, Wavelength Zones, and Amazon Web Services Outposts</a>
        /// in the <i>Amazon ECS Developer Guide</i>.</para><para>Batch on Fargate doesn't currently support Local Zones.</para></note>
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
        /// where <c>String1</c> is the tag key and <c>String2</c> is the tag value-for example,
        /// <c>{ "Name": "Batch Instance - C4OnDemand" }</c>. This is helpful for recognizing
        /// your Batch instances in the Amazon EC2 console. These tags aren't seen when using
        /// the Batch <c>ListTagsForResource</c> API operation.</para><para>When updating a compute environment, changing this setting requires an infrastructure
        /// update of the compute environment. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/updating-compute-environments.html">Updating
        /// compute environments</a> in the <i>Batch User Guide</i>.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_Tags")]
        public System.Collections.Hashtable ComputeResources_Tag { get; set; }
        #endregion
        
        #region Parameter UpdatePolicy_TerminateJobsOnUpdate
        /// <summary>
        /// <para>
        /// <para>Specifies whether jobs are automatically terminated when the computer environment
        /// infrastructure is updated. The default value is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UpdatePolicy_TerminateJobsOnUpdate { get; set; }
        #endregion
        
        #region Parameter ComputeResources_Type
        /// <summary>
        /// <para>
        /// <para>The type of compute environment: <c>EC2</c>, <c>SPOT</c>, <c>FARGATE</c>, or <c>FARGATE_SPOT</c>.
        /// For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/compute_environments.html">Compute
        /// environments</a> in the <i>Batch User Guide</i>.</para><para> If you choose <c>SPOT</c>, you must also specify an Amazon EC2 Spot Fleet role with
        /// the <c>spotIamFleetRole</c> parameter. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/spot_fleet_IAM_role.html">Amazon
        /// EC2 spot fleet role</a> in the <i>Batch User Guide</i>.</para><para>When updating a compute environment, changing the type of a compute environment requires
        /// an infrastructure update of the compute environment. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/updating-compute-environments.html">Updating
        /// compute environments</a> in the <i>Batch User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Batch.CRType")]
        public Amazon.Batch.CRType ComputeResources_Type { get; set; }
        #endregion
        
        #region Parameter UnmanagedvCpu
        /// <summary>
        /// <para>
        /// <para>The maximum number of vCPUs expected to be used for an unmanaged compute environment.
        /// Don't specify this parameter for a managed compute environment. This parameter is
        /// only used for fair share scheduling to reserve vCPU capacity for new share identifiers.
        /// If this parameter isn't provided for a fair share job queue, no vCPU capacity is reserved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UnmanagedvCpus")]
        public System.Int32? UnmanagedvCpu { get; set; }
        #endregion
        
        #region Parameter ComputeResources_UpdateToLatestImageVersion
        /// <summary>
        /// <para>
        /// <para>Specifies whether the AMI ID is updated to the latest one that's supported by Batch
        /// when the compute environment has an infrastructure update. The default value is <c>false</c>.</para><note><para>An AMI ID can either be specified in the <c>imageId</c> or <c>imageIdOverride</c>
        /// parameters or be determined by the launch template that's specified in the <c>launchTemplate</c>
        /// parameter. If an AMI ID is specified any of these ways, this parameter is ignored.
        /// For more information about to update AMI IDs during an infrastructure update, see
        /// <a href="https://docs.aws.amazon.com/batch/latest/userguide/updating-compute-environments.html#updating-compute-environments-ami">Updating
        /// the AMI ID</a> in the <i>Batch User Guide</i>.</para></note><para>When updating a compute environment, changing this setting requires an infrastructure
        /// update of the compute environment. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/updating-compute-environments.html">Updating
        /// compute environments</a> in the <i>Batch User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ComputeResources_UpdateToLatestImageVersion { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Batch.Model.UpdateComputeEnvironmentResponse).
        /// Specifying the name of a property of type Amazon.Batch.Model.UpdateComputeEnvironmentResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ComputeEnvironment), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BATComputeEnvironment (UpdateComputeEnvironment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Batch.Model.UpdateComputeEnvironmentResponse, UpdateBATComputeEnvironmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ComputeEnvironment = this.ComputeEnvironment;
            #if MODULAR
            if (this.ComputeEnvironment == null && ParameterWasBound(nameof(this.ComputeEnvironment)))
            {
                WriteWarning("You are passing $null as a value for parameter ComputeEnvironment which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ComputeResources_AllocationStrategy = this.ComputeResources_AllocationStrategy;
            context.ComputeResources_BidPercentage = this.ComputeResources_BidPercentage;
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
            context.LaunchTemplate_Version = this.LaunchTemplate_Version;
            context.ComputeResources_MaxvCpu = this.ComputeResources_MaxvCpu;
            context.ComputeResources_MinvCpu = this.ComputeResources_MinvCpu;
            context.ComputeResources_PlacementGroup = this.ComputeResources_PlacementGroup;
            if (this.ComputeResources_SecurityGroupId != null)
            {
                context.ComputeResources_SecurityGroupId = new List<System.String>(this.ComputeResources_SecurityGroupId);
            }
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
            context.ComputeResources_UpdateToLatestImageVersion = this.ComputeResources_UpdateToLatestImageVersion;
            context.Context = this.Context;
            context.ServiceRole = this.ServiceRole;
            context.State = this.State;
            context.UnmanagedvCpu = this.UnmanagedvCpu;
            context.UpdatePolicy_JobExecutionTimeoutMinute = this.UpdatePolicy_JobExecutionTimeoutMinute;
            context.UpdatePolicy_TerminateJobsOnUpdate = this.UpdatePolicy_TerminateJobsOnUpdate;
            
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
            var request = new Amazon.Batch.Model.UpdateComputeEnvironmentRequest();
            
            if (cmdletContext.ComputeEnvironment != null)
            {
                request.ComputeEnvironment = cmdletContext.ComputeEnvironment;
            }
            
             // populate ComputeResources
            var requestComputeResourcesIsNull = true;
            request.ComputeResources = new Amazon.Batch.Model.ComputeResourceUpdate();
            Amazon.Batch.CRUpdateAllocationStrategy requestComputeResources_computeResources_AllocationStrategy = null;
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
            System.Boolean? requestComputeResources_computeResources_UpdateToLatestImageVersion = null;
            if (cmdletContext.ComputeResources_UpdateToLatestImageVersion != null)
            {
                requestComputeResources_computeResources_UpdateToLatestImageVersion = cmdletContext.ComputeResources_UpdateToLatestImageVersion.Value;
            }
            if (requestComputeResources_computeResources_UpdateToLatestImageVersion != null)
            {
                request.ComputeResources.UpdateToLatestImageVersion = requestComputeResources_computeResources_UpdateToLatestImageVersion.Value;
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
            if (cmdletContext.ServiceRole != null)
            {
                request.ServiceRole = cmdletContext.ServiceRole;
            }
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
            }
            if (cmdletContext.UnmanagedvCpu != null)
            {
                request.UnmanagedvCpus = cmdletContext.UnmanagedvCpu.Value;
            }
            
             // populate UpdatePolicy
            var requestUpdatePolicyIsNull = true;
            request.UpdatePolicy = new Amazon.Batch.Model.UpdatePolicy();
            System.Int64? requestUpdatePolicy_updatePolicy_JobExecutionTimeoutMinute = null;
            if (cmdletContext.UpdatePolicy_JobExecutionTimeoutMinute != null)
            {
                requestUpdatePolicy_updatePolicy_JobExecutionTimeoutMinute = cmdletContext.UpdatePolicy_JobExecutionTimeoutMinute.Value;
            }
            if (requestUpdatePolicy_updatePolicy_JobExecutionTimeoutMinute != null)
            {
                request.UpdatePolicy.JobExecutionTimeoutMinutes = requestUpdatePolicy_updatePolicy_JobExecutionTimeoutMinute.Value;
                requestUpdatePolicyIsNull = false;
            }
            System.Boolean? requestUpdatePolicy_updatePolicy_TerminateJobsOnUpdate = null;
            if (cmdletContext.UpdatePolicy_TerminateJobsOnUpdate != null)
            {
                requestUpdatePolicy_updatePolicy_TerminateJobsOnUpdate = cmdletContext.UpdatePolicy_TerminateJobsOnUpdate.Value;
            }
            if (requestUpdatePolicy_updatePolicy_TerminateJobsOnUpdate != null)
            {
                request.UpdatePolicy.TerminateJobsOnUpdate = requestUpdatePolicy_updatePolicy_TerminateJobsOnUpdate.Value;
                requestUpdatePolicyIsNull = false;
            }
             // determine if request.UpdatePolicy should be set to null
            if (requestUpdatePolicyIsNull)
            {
                request.UpdatePolicy = null;
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
        
        private Amazon.Batch.Model.UpdateComputeEnvironmentResponse CallAWSServiceOperation(IAmazonBatch client, Amazon.Batch.Model.UpdateComputeEnvironmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Batch", "UpdateComputeEnvironment");
            try
            {
                return client.UpdateComputeEnvironmentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ComputeEnvironment { get; set; }
            public Amazon.Batch.CRUpdateAllocationStrategy ComputeResources_AllocationStrategy { get; set; }
            public System.Int32? ComputeResources_BidPercentage { get; set; }
            public System.Int32? ComputeResources_DesiredvCpu { get; set; }
            public List<Amazon.Batch.Model.Ec2Configuration> ComputeResources_Ec2Configuration { get; set; }
            public System.String ComputeResources_Ec2KeyPair { get; set; }
            public System.String ComputeResources_ImageId { get; set; }
            public System.String ComputeResources_InstanceRole { get; set; }
            public List<System.String> ComputeResources_InstanceType { get; set; }
            public System.String LaunchTemplate_LaunchTemplateId { get; set; }
            public System.String LaunchTemplate_LaunchTemplateName { get; set; }
            public List<Amazon.Batch.Model.LaunchTemplateSpecificationOverride> LaunchTemplate_Override { get; set; }
            public System.String LaunchTemplate_Version { get; set; }
            public System.Int32? ComputeResources_MaxvCpu { get; set; }
            public System.Int32? ComputeResources_MinvCpu { get; set; }
            public System.String ComputeResources_PlacementGroup { get; set; }
            public List<System.String> ComputeResources_SecurityGroupId { get; set; }
            public List<System.String> ComputeResources_Subnet { get; set; }
            public Dictionary<System.String, System.String> ComputeResources_Tag { get; set; }
            public Amazon.Batch.CRType ComputeResources_Type { get; set; }
            public System.Boolean? ComputeResources_UpdateToLatestImageVersion { get; set; }
            public System.String Context { get; set; }
            public System.String ServiceRole { get; set; }
            public Amazon.Batch.CEState State { get; set; }
            public System.Int32? UnmanagedvCpu { get; set; }
            public System.Int64? UpdatePolicy_JobExecutionTimeoutMinute { get; set; }
            public System.Boolean? UpdatePolicy_TerminateJobsOnUpdate { get; set; }
            public System.Func<Amazon.Batch.Model.UpdateComputeEnvironmentResponse, UpdateBATComputeEnvironmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
