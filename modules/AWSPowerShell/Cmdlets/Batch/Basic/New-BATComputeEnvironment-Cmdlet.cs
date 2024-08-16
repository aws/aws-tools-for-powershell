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
using Amazon.Batch;
using Amazon.Batch.Model;

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
    /// </para><note><para>
    /// Multi-node parallel jobs aren't supported on Spot Instances.
    /// </para></note><para>
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
    /// To create a compute environment that uses EKS resources, the caller must have permissions
    /// to call <c>eks:DescribeCluster</c>.
    /// </para></note><note><para>
    /// Batch doesn't automatically upgrade the AMIs in a compute environment after it's created.
    /// For example, it also doesn't update the AMIs in your compute environment when a newer
    /// version of the Amazon ECS optimized AMI is available. You're responsible for the management
    /// of the guest operating system. This includes any updates and security patches. You're
    /// also responsible for any additional application software or utilities that you install
    /// on the compute resources. There are two ways to use a new AMI for your Batch jobs.
    /// The original method is to complete these steps:
    /// </para><ol><li><para>
    /// Create a new compute environment with the new AMI.
    /// </para></li><li><para>
    /// Add the compute environment to an existing job queue.
    /// </para></li><li><para>
    /// Remove the earlier compute environment from your job queue.
    /// </para></li><li><para>
    /// Delete the earlier compute environment.
    /// </para></li></ol><para>
    /// In April 2022, Batch added enhanced support for updating compute environments. For
    /// more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/updating-compute-environments.html">Updating
    /// compute environments</a>. To use the enhanced updating of compute environments to
    /// update AMIs, follow these rules:
    /// </para><ul><li><para>
    /// Either don't set the service role (<c>serviceRole</c>) parameter or set it to the
    /// <b>AWSBatchServiceRole</b> service-linked role.
    /// </para></li><li><para>
    /// Set the allocation strategy (<c>allocationStrategy</c>) parameter to <c>BEST_FIT_PROGRESSIVE</c>,
    /// <c>SPOT_CAPACITY_OPTIMIZED</c>, or <c>SPOT_PRICE_CAPACITY_OPTIMIZED</c>.
    /// </para></li><li><para>
    /// Set the update to latest image version (<c>updateToLatestImageVersion</c>) parameter
    /// to <c>true</c>. The <c>updateToLatestImageVersion</c> parameter is used when you update
    /// a compute environment. This parameter is ignored when you create a compute environment.
    /// </para></li><li><para>
    /// Don't specify an AMI ID in <c>imageId</c>, <c>imageIdOverride</c> (in <a href="https://docs.aws.amazon.com/batch/latest/APIReference/API_Ec2Configuration.html"><c>ec2Configuration</c></a>), or in the launch template (<c>launchTemplate</c>).
    /// In that case, Batch selects the latest Amazon ECS optimized AMI that's supported by
    /// Batch at the time the infrastructure update is initiated. Alternatively, you can specify
    /// the AMI ID in the <c>imageId</c> or <c>imageIdOverride</c> parameters, or the launch
    /// template identified by the <c>LaunchTemplate</c> properties. Changing any of these
    /// properties starts an infrastructure update. If the AMI ID is specified in the launch
    /// template, it can't be replaced by specifying an AMI ID in either the <c>imageId</c>
    /// or <c>imageIdOverride</c> parameters. It can only be replaced by specifying a different
    /// launch template, or if the launch template version is set to <c>$Default</c> or <c>$Latest</c>,
    /// by setting either a new default version for the launch template (if <c>$Default</c>)
    /// or by adding a new version to the launch template (if <c>$Latest</c>).
    /// </para></li></ul><para>
    /// If these rules are followed, any update that starts an infrastructure update causes
    /// the AMI ID to be re-selected. If the <c>version</c> setting in the launch template
    /// (<c>launchTemplate</c>) is set to <c>$Latest</c> or <c>$Default</c>, the latest or
    /// default version of the launch template is evaluated up at the time of the infrastructure
    /// update, even if the <c>launchTemplate</c> wasn't updated.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "BATComputeEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Batch.Model.CreateComputeEnvironmentResponse")]
    [AWSCmdlet("Calls the AWS Batch CreateComputeEnvironment API operation.", Operation = new[] {"CreateComputeEnvironment"}, SelectReturnType = typeof(Amazon.Batch.Model.CreateComputeEnvironmentResponse))]
    [AWSCmdletOutput("Amazon.Batch.Model.CreateComputeEnvironmentResponse",
        "This cmdlet returns an Amazon.Batch.Model.CreateComputeEnvironmentResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewBATComputeEnvironmentCmdlet : AmazonBatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ComputeResources_AllocationStrategy
        /// <summary>
        /// <para>
        /// <para>The allocation strategy to use for the compute resource if not enough instances of
        /// the best fitting instance type can be allocated. This might be because of availability
        /// of the instance type in the Region or <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-resource-limits.html">Amazon
        /// EC2 service limits</a>. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/allocation-strategies.html">Allocation
        /// strategies</a> in the <i>Batch User Guide</i>.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note><dl><dt>BEST_FIT (default)</dt><dd><para>Batch selects an instance type that best fits the needs of the jobs with a preference
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
        [AWSConstantClassSource("Amazon.Batch.CRAllocationStrategy")]
        public Amazon.Batch.CRAllocationStrategy ComputeResources_AllocationStrategy { get; set; }
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
        /// the default is <c>ECS_AL2</c>.</para><para>One or two values can be provided.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
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
        
        #region Parameter ComputeResources_InstanceRole
        /// <summary>
        /// <para>
        /// <para>The Amazon ECS instance profile applied to Amazon EC2 instances in a compute environment.
        /// This parameter is required for Amazon EC2 instances types. You can specify the short
        /// name or full Amazon Resource Name (ARN) of an instance profile. For example, <c><i>ecsInstanceRole</i></c> or <c>arn:aws:iam::<i>&lt;aws_account_id&gt;</i>:instance-profile/<i>ecsInstanceRole</i></c>. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/instance_IAM_role.html">Amazon
        /// ECS instance role</a> in the <i>Batch User Guide</i>.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
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
        /// families) that match the demand of your job queues.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
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
        /// <para>The maximum number of vCPUs that a compute environment can support.</para><note><para>With <c>BEST_FIT_PROGRESSIVE</c>,<c>SPOT_CAPACITY_OPTIMIZED</c> and <c>SPOT_PRICE_CAPACITY_OPTIMIZED</c>
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
        /// <para>The minimum number of vCPUs that a compute environment should maintain (even if the
        /// compute environment is <c>DISABLED</c>).</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeResources_MinvCpus")]
        public System.Int32? ComputeResources_MinvCpu { get; set; }
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
        
        #region Parameter ComputeResources_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 security groups that are associated with instances launched in the
        /// compute environment. One or more security groups must be specified, either in <c>securityGroupIds</c>
        /// or using a launch template referenced in <c>launchTemplate</c>. This parameter is
        /// required for jobs that are running on Fargate resources and must contain at least
        /// one security group. Fargate doesn't support launch templates. If security groups are
        /// specified using both <c>securityGroupIds</c> and <c>launchTemplate</c>, the values
        /// in <c>securityGroupIds</c> are used.</para>
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
        /// service IAM role</a> in the <i>Batch User Guide</i>.</para><important><para>If your account already created the Batch service-linked role, that role is used by
        /// default for your compute environment unless you specify a different role here. If
        /// the Batch service-linked role doesn't exist in your account, and no role is specified
        /// here, the service attempts to create the Batch service-linked role in your account.</para></important><para>If your specified role has a path other than <c>/</c>, then you must specify either
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
        /// <para>The state of the compute environment. If the state is <c>ENABLED</c>, then the compute
        /// environment accepts jobs from a queue and can scale out automatically based on queues.</para><para>If the state is <c>ENABLED</c>, then the Batch scheduler can attempt to place jobs
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
        /// <para>The VPC subnets where the compute resources are launched. These subnets must be within
        /// the same VPC. Fargate compute resources can contain up to 16 subnets. For more information,
        /// see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_Subnets.html">VPCs
        /// and subnets</a> in the <i>Amazon VPC User Guide</i>.</para><note><para>Batch on Amazon EC2 and Batch on Amazon EKS support Local Zones. For more information,
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
        /// your Batch instances in the Amazon EC2 console. Updating these tags requires an infrastructure
        /// update to the compute environment. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/updating-compute-environments.html">Updating
        /// compute environments</a> in the <i>Batch User Guide</i>. These tags aren't seen when
        /// using the Batch <c>ListTagsForResource</c> API operation.</para><note><para>This parameter isn't applicable to jobs that are running on Fargate resources. Don't
        /// specify it.</para></note>
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
        /// API operations. These tags don't propagate to the underlying compute resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ComputeResources_Type
        /// <summary>
        /// <para>
        /// <para>The type of compute environment: <c>EC2</c>, <c>SPOT</c>, <c>FARGATE</c>, or <c>FARGATE_SPOT</c>.
        /// For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/compute_environments.html">Compute
        /// environments</a> in the <i>Batch User Guide</i>.</para><para> If you choose <c>SPOT</c>, you must also specify an Amazon EC2 Spot Fleet role with
        /// the <c>spotIamFleetRole</c> parameter. For more information, see <a href="https://docs.aws.amazon.com/batch/latest/userguide/spot_fleet_IAM_role.html">Amazon
        /// EC2 spot fleet role</a> in the <i>Batch User Guide</i>.</para>
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
        /// only used for fair share scheduling to reserve vCPU capacity for new share identifiers.
        /// If this parameter isn't provided for a fair share job queue, no vCPU capacity is reserved.</para><note><para>This parameter is only supported when the <c>type</c> parameter is set to <c>UNMANAGED</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UnmanagedvCpus")]
        public System.Int32? UnmanagedvCpu { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_Version
        /// <summary>
        /// <para>
        /// <para>The version number of the launch template, <c>$Latest</c>, or <c>$Default</c>.</para><para>If the value is <c>$Latest</c>, the latest version of the launch template is used.
        /// If the value is <c>$Default</c>, the default version of the launch template is used.</para><important><para>If the AMI ID that's used in a compute environment is from the launch template, the
        /// AMI isn't changed when the compute environment is updated. It's only changed if the
        /// <c>updateToLatestImageVersion</c> parameter for the compute environment is set to
        /// <c>true</c>. During an infrastructure update, if either <c>$Latest</c> or <c>$Default</c>
        /// is specified, Batch re-evaluates the launch template version, and it might use a different
        /// version of the launch template. This is the case even if the launch template isn't
        /// specified in the update. When updating a compute environment, changing the launch
        /// template requires an infrastructure update of the compute environment. For more information,
        /// see <a href="https://docs.aws.amazon.com/batch/latest/userguide/updating-compute-environments.html">Updating
        /// compute environments</a> in the <i>Batch User Guide</i>.</para></important><para>Default: <c>$Default</c>.</para>
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
        /// Amazon ECS-optimized Amazon Linux 2 AMI. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs-optimized_AMI.html#ecs-optimized-ami-linux-variants.html">Amazon
        /// ECS-optimized Amazon Linux 2 AMI</a> in the <i>Amazon Elastic Container Service Developer
        /// Guide</i>.</para></note>
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
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
            context.ComputeResources_DesiredvCpu = this.ComputeResources_DesiredvCpu;
            if (this.ComputeResources_Ec2Configuration != null)
            {
                context.ComputeResources_Ec2Configuration = new List<Amazon.Batch.Model.Ec2Configuration>(this.ComputeResources_Ec2Configuration);
            }
            context.ComputeResources_Ec2KeyPair = this.ComputeResources_Ec2KeyPair;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ComputeResources_ImageId = this.ComputeResources_ImageId;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ComputeResources_InstanceRole = this.ComputeResources_InstanceRole;
            if (this.ComputeResources_InstanceType != null)
            {
                context.ComputeResources_InstanceType = new List<System.String>(this.ComputeResources_InstanceType);
            }
            context.LaunchTemplate_LaunchTemplateId = this.LaunchTemplate_LaunchTemplateId;
            context.LaunchTemplate_LaunchTemplateName = this.LaunchTemplate_LaunchTemplateName;
            context.LaunchTemplate_Version = this.LaunchTemplate_Version;
            context.ComputeResources_MaxvCpu = this.ComputeResources_MaxvCpu;
            context.ComputeResources_MinvCpu = this.ComputeResources_MinvCpu;
            context.ComputeResources_PlacementGroup = this.ComputeResources_PlacementGroup;
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
                #if DESKTOP
                return client.CreateComputeEnvironment(request);
                #elif CORECLR
                return client.CreateComputeEnvironmentAsync(request).GetAwaiter().GetResult();
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
            public System.String ComputeEnvironmentName { get; set; }
            public Amazon.Batch.CRAllocationStrategy ComputeResources_AllocationStrategy { get; set; }
            public System.Int32? ComputeResources_BidPercentage { get; set; }
            public System.Int32? ComputeResources_DesiredvCpu { get; set; }
            public List<Amazon.Batch.Model.Ec2Configuration> ComputeResources_Ec2Configuration { get; set; }
            public System.String ComputeResources_Ec2KeyPair { get; set; }
            [System.ObsoleteAttribute]
            public System.String ComputeResources_ImageId { get; set; }
            public System.String ComputeResources_InstanceRole { get; set; }
            public List<System.String> ComputeResources_InstanceType { get; set; }
            public System.String LaunchTemplate_LaunchTemplateId { get; set; }
            public System.String LaunchTemplate_LaunchTemplateName { get; set; }
            public System.String LaunchTemplate_Version { get; set; }
            public System.Int32? ComputeResources_MaxvCpu { get; set; }
            public System.Int32? ComputeResources_MinvCpu { get; set; }
            public System.String ComputeResources_PlacementGroup { get; set; }
            public List<System.String> ComputeResources_SecurityGroupId { get; set; }
            public System.String ComputeResources_SpotIamFleetRole { get; set; }
            public List<System.String> ComputeResources_Subnet { get; set; }
            public Dictionary<System.String, System.String> ComputeResources_Tag { get; set; }
            public Amazon.Batch.CRType ComputeResources_Type { get; set; }
            public System.String Context { get; set; }
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
