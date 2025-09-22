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
using Amazon.EKS;
using Amazon.EKS.Model;

namespace Amazon.PowerShell.Cmdlets.EKS
{
    /// <summary>
    /// Creates a managed node group for an Amazon EKS cluster.
    /// 
    ///  
    /// <para>
    /// You can only create a node group for your cluster that is equal to the current Kubernetes
    /// version for the cluster. All node groups are created with the latest AMI release version
    /// for the respective minor Kubernetes version of the cluster, unless you deploy a custom
    /// AMI using a launch template.
    /// </para><para>
    /// For later updates, you will only be able to update a node group using a launch template
    /// only if it was originally deployed with a launch template. Additionally, the launch
    /// template ID or name must match what was used when the node group was created. You
    /// can update the launch template version with necessary changes. For more information
    /// about using launch templates, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/launch-templates.html">Customizing
    /// managed nodes with launch templates</a>.
    /// </para><para>
    /// An Amazon EKS managed node group is an Amazon EC2 Auto Scaling group and associated
    /// Amazon EC2 instances that are managed by Amazon Web Services for an Amazon EKS cluster.
    /// For more information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/managed-node-groups.html">Managed
    /// node groups</a> in the <i>Amazon EKS User Guide</i>.
    /// </para><note><para>
    /// Windows AMI types are only supported for commercial Amazon Web Services Regions that
    /// support Windows on Amazon EKS.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "EKSNodegroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EKS.Model.Nodegroup")]
    [AWSCmdlet("Calls the Amazon Elastic Container Service for Kubernetes CreateNodegroup API operation.", Operation = new[] {"CreateNodegroup"}, SelectReturnType = typeof(Amazon.EKS.Model.CreateNodegroupResponse))]
    [AWSCmdletOutput("Amazon.EKS.Model.Nodegroup or Amazon.EKS.Model.CreateNodegroupResponse",
        "This cmdlet returns an Amazon.EKS.Model.Nodegroup object.",
        "The service call response (type Amazon.EKS.Model.CreateNodegroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEKSNodegroupCmdlet : AmazonEKSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AmiType
        /// <summary>
        /// <para>
        /// <para>The AMI type for your node group. If you specify <c>launchTemplate</c>, and your launch
        /// template uses a custom AMI, then don't specify <c>amiType</c>, or the node group deployment
        /// will fail. If your launch template uses a Windows custom AMI, then add <c>eks:kube-proxy-windows</c>
        /// to your Windows nodes <c>rolearn</c> in the <c>aws-auth</c><c>ConfigMap</c>. For
        /// more information about using launch templates with Amazon EKS, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/launch-templates.html">Customizing
        /// managed nodes with launch templates</a> in the <i>Amazon EKS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EKS.AMITypes")]
        public Amazon.EKS.AMITypes AmiType { get; set; }
        #endregion
        
        #region Parameter CapacityType
        /// <summary>
        /// <para>
        /// <para>The capacity type for your node group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EKS.CapacityTypes")]
        public Amazon.EKS.CapacityTypes CapacityType { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The name of your cluster.</para>
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
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter ScalingConfig_DesiredSize
        /// <summary>
        /// <para>
        /// <para>The current number of nodes that the managed node group should maintain.</para><important><para>If you use the Kubernetes <a href="https://github.com/kubernetes/autoscaler#kubernetes-autoscaler">Cluster
        /// Autoscaler</a>, you shouldn't change the <c>desiredSize</c> value directly, as this
        /// can cause the Cluster Autoscaler to suddenly scale up or scale down.</para></important><para>Whenever this parameter changes, the number of worker nodes in the node group is updated
        /// to the specified size. If this parameter is given a value that is smaller than the
        /// current number of running worker nodes, the necessary number of worker nodes are terminated
        /// to match the given value. When using CloudFormation, no action occurs if you remove
        /// this parameter from your CFN template.</para><para>This parameter can be different from <c>minSize</c> in some cases, such as when starting
        /// with extra hosts for testing. This parameter can also be different when you want to
        /// start with an estimated number of needed hosts, but let the Cluster Autoscaler reduce
        /// the number if there are too many. When the Cluster Autoscaler is used, the <c>desiredSize</c>
        /// parameter is altered by the Cluster Autoscaler (but can be out-of-date for short periods
        /// of time). the Cluster Autoscaler doesn't scale a managed node group lower than <c>minSize</c>
        /// or higher than <c>maxSize</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingConfig_DesiredSize { get; set; }
        #endregion
        
        #region Parameter DiskSize
        /// <summary>
        /// <para>
        /// <para>The root device disk size (in GiB) for your node group instances. The default disk
        /// size is 20 GiB for Linux and Bottlerocket. The default disk size is 50 GiB for Windows.
        /// If you specify <c>launchTemplate</c>, then don't specify <c>diskSize</c>, or the node
        /// group deployment will fail. For more information about using launch templates with
        /// Amazon EKS, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/launch-templates.html">Customizing
        /// managed nodes with launch templates</a> in the <i>Amazon EKS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DiskSize { get; set; }
        #endregion
        
        #region Parameter RemoteAccess_Ec2SshKey
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 SSH key name that provides access for SSH communication with the nodes
        /// in the managed node group. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-key-pairs.html">Amazon
        /// EC2 key pairs and Linux instances</a> in the <i>Amazon Elastic Compute Cloud User
        /// Guide for Linux Instances</i>. For Windows, an Amazon EC2 SSH key is used to obtain
        /// the RDP password. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/WindowsGuide/ec2-key-pairs.html">Amazon
        /// EC2 key pairs and Windows instances</a> in the <i>Amazon Elastic Compute Cloud User
        /// Guide for Windows Instances</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RemoteAccess_Ec2SshKey { get; set; }
        #endregion
        
        #region Parameter NodeRepairConfig_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable node auto repair for the node group. Node auto repair
        /// is disabled by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NodeRepairConfig_Enabled { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_Id
        /// <summary>
        /// <para>
        /// <para>The ID of the launch template.</para><para>You must specify either the launch template ID or the launch template name in the
        /// request, but not both. After node group creation, you cannot use a different ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchTemplate_Id { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>Specify the instance types for a node group. If you specify a GPU instance type, make
        /// sure to also specify an applicable GPU AMI type with the <c>amiType</c> parameter.
        /// If you specify <c>launchTemplate</c>, then you can specify zero or one instance type
        /// in your launch template <i>or</i> you can specify 0-20 instance types for <c>instanceTypes</c>.
        /// If however, you specify an instance type in your launch template <i>and</i> specify
        /// any <c>instanceTypes</c>, the node group deployment will fail. If you don't specify
        /// an instance type in a launch template or for <c>instanceTypes</c>, then <c>t3.medium</c>
        /// is used, by default. If you specify <c>Spot</c> for <c>capacityType</c>, then we recommend
        /// specifying multiple values for <c>instanceTypes</c>. For more information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/managed-node-groups.html#managed-node-group-capacity-types">Managed
        /// node group capacity types</a> and <a href="https://docs.aws.amazon.com/eks/latest/userguide/launch-templates.html">Customizing
        /// managed nodes with launch templates</a> in the <i>Amazon EKS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceTypes")]
        public System.String[] InstanceType { get; set; }
        #endregion
        
        #region Parameter Label
        /// <summary>
        /// <para>
        /// <para>The Kubernetes <c>labels</c> to apply to the nodes in the node group when they are
        /// created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Labels")]
        public System.Collections.Hashtable Label { get; set; }
        #endregion
        
        #region Parameter NodeRepairConfig_MaxParallelNodesRepairedCount
        /// <summary>
        /// <para>
        /// <para>Specify the maximum number of nodes that can be repaired concurrently or in parallel,
        /// expressed as a count of unhealthy nodes. This gives you finer-grained control over
        /// the pace of node replacements. When using this, you cannot also set <c>maxParallelNodesRepairedPercentage</c>
        /// at the same time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NodeRepairConfig_MaxParallelNodesRepairedCount { get; set; }
        #endregion
        
        #region Parameter NodeRepairConfig_MaxParallelNodesRepairedPercentage
        /// <summary>
        /// <para>
        /// <para>Specify the maximum number of nodes that can be repaired concurrently or in parallel,
        /// expressed as a percentage of unhealthy nodes. This gives you finer-grained control
        /// over the pace of node replacements. When using this, you cannot also set <c>maxParallelNodesRepairedCount</c>
        /// at the same time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NodeRepairConfig_MaxParallelNodesRepairedPercentage { get; set; }
        #endregion
        
        #region Parameter ScalingConfig_MaxSize
        /// <summary>
        /// <para>
        /// <para>The maximum number of nodes that the managed node group can scale out to. For information
        /// about the maximum number that you can specify, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/service-quotas.html">Amazon
        /// EKS service quotas</a> in the <i>Amazon EKS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingConfig_MaxSize { get; set; }
        #endregion
        
        #region Parameter UpdateConfig_MaxUnavailable
        /// <summary>
        /// <para>
        /// <para>The maximum number of nodes unavailable at once during a version update. Nodes are
        /// updated in parallel. This value or <c>maxUnavailablePercentage</c> is required to
        /// have a value.The maximum number is 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? UpdateConfig_MaxUnavailable { get; set; }
        #endregion
        
        #region Parameter UpdateConfig_MaxUnavailablePercentage
        /// <summary>
        /// <para>
        /// <para>The maximum percentage of nodes unavailable during a version update. This percentage
        /// of nodes are updated in parallel, up to 100 nodes at once. This value or <c>maxUnavailable</c>
        /// is required to have a value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? UpdateConfig_MaxUnavailablePercentage { get; set; }
        #endregion
        
        #region Parameter NodeRepairConfig_MaxUnhealthyNodeThresholdCount
        /// <summary>
        /// <para>
        /// <para>Specify a count threshold of unhealthy nodes, above which node auto repair actions
        /// will stop. When using this, you cannot also set <c>maxUnhealthyNodeThresholdPercentage</c>
        /// at the same time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NodeRepairConfig_MaxUnhealthyNodeThresholdCount { get; set; }
        #endregion
        
        #region Parameter NodeRepairConfig_MaxUnhealthyNodeThresholdPercentage
        /// <summary>
        /// <para>
        /// <para>Specify a percentage threshold of unhealthy nodes, above which node auto repair actions
        /// will stop. When using this, you cannot also set <c>maxUnhealthyNodeThresholdCount</c>
        /// at the same time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NodeRepairConfig_MaxUnhealthyNodeThresholdPercentage { get; set; }
        #endregion
        
        #region Parameter ScalingConfig_MinSize
        /// <summary>
        /// <para>
        /// <para>The minimum number of nodes that the managed node group can scale in to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingConfig_MinSize { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_Name
        /// <summary>
        /// <para>
        /// <para>The name of the launch template.</para><para>You must specify either the launch template name or the launch template ID in the
        /// request, but not both. After node group creation, you cannot use a different name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchTemplate_Name { get; set; }
        #endregion
        
        #region Parameter NodegroupName
        /// <summary>
        /// <para>
        /// <para>The unique name to give your node group.</para>
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
        public System.String NodegroupName { get; set; }
        #endregion
        
        #region Parameter NodeRepairConfig_NodeRepairConfigOverride
        /// <summary>
        /// <para>
        /// <para>Specify granular overrides for specific repair actions. These overrides control the
        /// repair action and the repair delay time before a node is considered eligible for repair.
        /// If you use this, you must specify all the values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NodeRepairConfig_NodeRepairConfigOverrides")]
        public Amazon.EKS.Model.NodeRepairConfigOverrides[] NodeRepairConfig_NodeRepairConfigOverride { get; set; }
        #endregion
        
        #region Parameter NodeRole
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role to associate with your node group.
        /// The Amazon EKS worker node <c>kubelet</c> daemon makes calls to Amazon Web Services
        /// APIs on your behalf. Nodes receive permissions for these API calls through an IAM
        /// instance profile and associated policies. Before you can launch nodes and register
        /// them into a cluster, you must create an IAM role for those nodes to use when they
        /// are launched. For more information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/create-node-role.html">Amazon
        /// EKS node IAM role</a> in the <i><i>Amazon EKS User Guide</i></i>. If you specify
        /// <c>launchTemplate</c>, then don't specify <c><a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_IamInstanceProfile.html">IamInstanceProfile</a></c> in your launch template, or the node group deployment will fail. For more information
        /// about using launch templates with Amazon EKS, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/launch-templates.html">Customizing
        /// managed nodes with launch templates</a> in the <i>Amazon EKS User Guide</i>.</para>
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
        public System.String NodeRole { get; set; }
        #endregion
        
        #region Parameter ReleaseVersion
        /// <summary>
        /// <para>
        /// <para>The AMI version of the Amazon EKS optimized AMI to use with your node group. By default,
        /// the latest available AMI version for the node group's current Kubernetes version is
        /// used. For information about Linux versions, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/eks-linux-ami-versions.html">Amazon
        /// EKS optimized Amazon Linux AMI versions</a> in the <i>Amazon EKS User Guide</i>. Amazon
        /// EKS managed node groups support the November 2022 and later releases of the Windows
        /// AMIs. For information about Windows versions, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/eks-ami-versions-windows.html">Amazon
        /// EKS optimized Windows AMI versions</a> in the <i>Amazon EKS User Guide</i>.</para><para>If you specify <c>launchTemplate</c>, and your launch template uses a custom AMI,
        /// then don't specify <c>releaseVersion</c>, or the node group deployment will fail.
        /// For more information about using launch templates with Amazon EKS, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/launch-templates.html">Customizing
        /// managed nodes with launch templates</a> in the <i>Amazon EKS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReleaseVersion { get; set; }
        #endregion
        
        #region Parameter RemoteAccess_SourceSecurityGroup
        /// <summary>
        /// <para>
        /// <para>The security group IDs that are allowed SSH access (port 22) to the nodes. For Windows,
        /// the port is 3389. If you specify an Amazon EC2 SSH key but don't specify a source
        /// security group when you create a managed node group, then the port on the nodes is
        /// opened to the internet (<c>0.0.0.0/0</c>). For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_SecurityGroups.html">Security
        /// Groups for Your VPC</a> in the <i>Amazon Virtual Private Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoteAccess_SourceSecurityGroups")]
        public System.String[] RemoteAccess_SourceSecurityGroup { get; set; }
        #endregion
        
        #region Parameter Subnet
        /// <summary>
        /// <para>
        /// <para>The subnets to use for the Auto Scaling group that is created for your node group.
        /// If you specify <c>launchTemplate</c>, then don't specify <c><a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateNetworkInterface.html">SubnetId</a></c> in your launch template, or the node group deployment will fail. For more information
        /// about using launch templates with Amazon EKS, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/launch-templates.html">Customizing
        /// managed nodes with launch templates</a> in the <i>Amazon EKS User Guide</i>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Subnets")]
        public System.String[] Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata that assists with categorization and organization. Each tag consists of a
        /// key and an optional value. You define both. Tags don't propagate to any other cluster
        /// or Amazon Web Services resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Taint
        /// <summary>
        /// <para>
        /// <para>The Kubernetes taints to be applied to the nodes in the node group. For more information,
        /// see <a href="https://docs.aws.amazon.com/eks/latest/userguide/node-taints-managed-node-groups.html">Node
        /// taints on managed node groups</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Taints")]
        public Amazon.EKS.Model.Taint[] Taint { get; set; }
        #endregion
        
        #region Parameter UpdateConfig_UpdateStrategy
        /// <summary>
        /// <para>
        /// <para>The configuration for the behavior to follow during a node group version update of
        /// this managed node group. You choose between two possible strategies for replacing
        /// nodes during an <a href="https://docs.aws.amazon.com/eks/latest/APIReference/API_UpdateNodegroupVersion.html"><c>UpdateNodegroupVersion</c></a> action.</para><para>An Amazon EKS managed node group updates by replacing nodes with new nodes of newer
        /// AMI versions in parallel. The <i>update strategy</i> changes the managed node update
        /// behavior of the managed node group for each quantity. The <i>default</i> strategy
        /// has guardrails to protect you from misconfiguration and launches the new instances
        /// first, before terminating the old instances. The <i>minimal</i> strategy removes the
        /// guardrails and terminates the old instances before launching the new instances. This
        /// minimal strategy is useful in scenarios where you are constrained to resources or
        /// costs (for example, with hardware accelerators such as GPUs).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EKS.NodegroupUpdateStrategies")]
        public Amazon.EKS.NodegroupUpdateStrategies UpdateConfig_UpdateStrategy { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_Version
        /// <summary>
        /// <para>
        /// <para>The version number of the launch template to use. If no version is specified, then
        /// the template's default version is used. You can use a different version for node group
        /// updates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchTemplate_Version { get; set; }
        #endregion
        
        #region Parameter Version
        /// <summary>
        /// <para>
        /// <para>The Kubernetes version to use for your managed nodes. By default, the Kubernetes version
        /// of the cluster is used, and this is the only accepted specified value. If you specify
        /// <c>launchTemplate</c>, and your launch template uses a custom AMI, then don't specify
        /// <c>version</c>, or the node group deployment will fail. For more information about
        /// using launch templates with Amazon EKS, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/launch-templates.html">Customizing
        /// managed nodes with launch templates</a> in the <i>Amazon EKS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Nodegroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EKS.Model.CreateNodegroupResponse).
        /// Specifying the name of a property of type Amazon.EKS.Model.CreateNodegroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Nodegroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NodegroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NodegroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NodegroupName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NodegroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EKSNodegroup (CreateNodegroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EKS.Model.CreateNodegroupResponse, NewEKSNodegroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NodegroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AmiType = this.AmiType;
            context.CapacityType = this.CapacityType;
            context.ClientRequestToken = this.ClientRequestToken;
            context.ClusterName = this.ClusterName;
            #if MODULAR
            if (this.ClusterName == null && ParameterWasBound(nameof(this.ClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DiskSize = this.DiskSize;
            if (this.InstanceType != null)
            {
                context.InstanceType = new List<System.String>(this.InstanceType);
            }
            if (this.Label != null)
            {
                context.Label = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Label.Keys)
                {
                    context.Label.Add((String)hashKey, (System.String)(this.Label[hashKey]));
                }
            }
            context.LaunchTemplate_Id = this.LaunchTemplate_Id;
            context.LaunchTemplate_Name = this.LaunchTemplate_Name;
            context.LaunchTemplate_Version = this.LaunchTemplate_Version;
            context.NodegroupName = this.NodegroupName;
            #if MODULAR
            if (this.NodegroupName == null && ParameterWasBound(nameof(this.NodegroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter NodegroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NodeRepairConfig_Enabled = this.NodeRepairConfig_Enabled;
            context.NodeRepairConfig_MaxParallelNodesRepairedCount = this.NodeRepairConfig_MaxParallelNodesRepairedCount;
            context.NodeRepairConfig_MaxParallelNodesRepairedPercentage = this.NodeRepairConfig_MaxParallelNodesRepairedPercentage;
            context.NodeRepairConfig_MaxUnhealthyNodeThresholdCount = this.NodeRepairConfig_MaxUnhealthyNodeThresholdCount;
            context.NodeRepairConfig_MaxUnhealthyNodeThresholdPercentage = this.NodeRepairConfig_MaxUnhealthyNodeThresholdPercentage;
            if (this.NodeRepairConfig_NodeRepairConfigOverride != null)
            {
                context.NodeRepairConfig_NodeRepairConfigOverride = new List<Amazon.EKS.Model.NodeRepairConfigOverrides>(this.NodeRepairConfig_NodeRepairConfigOverride);
            }
            context.NodeRole = this.NodeRole;
            #if MODULAR
            if (this.NodeRole == null && ParameterWasBound(nameof(this.NodeRole)))
            {
                WriteWarning("You are passing $null as a value for parameter NodeRole which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReleaseVersion = this.ReleaseVersion;
            context.RemoteAccess_Ec2SshKey = this.RemoteAccess_Ec2SshKey;
            if (this.RemoteAccess_SourceSecurityGroup != null)
            {
                context.RemoteAccess_SourceSecurityGroup = new List<System.String>(this.RemoteAccess_SourceSecurityGroup);
            }
            context.ScalingConfig_DesiredSize = this.ScalingConfig_DesiredSize;
            context.ScalingConfig_MaxSize = this.ScalingConfig_MaxSize;
            context.ScalingConfig_MinSize = this.ScalingConfig_MinSize;
            if (this.Subnet != null)
            {
                context.Subnet = new List<System.String>(this.Subnet);
            }
            #if MODULAR
            if (this.Subnet == null && ParameterWasBound(nameof(this.Subnet)))
            {
                WriteWarning("You are passing $null as a value for parameter Subnet which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            if (this.Taint != null)
            {
                context.Taint = new List<Amazon.EKS.Model.Taint>(this.Taint);
            }
            context.UpdateConfig_MaxUnavailable = this.UpdateConfig_MaxUnavailable;
            context.UpdateConfig_MaxUnavailablePercentage = this.UpdateConfig_MaxUnavailablePercentage;
            context.UpdateConfig_UpdateStrategy = this.UpdateConfig_UpdateStrategy;
            context.Version = this.Version;
            
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
            var request = new Amazon.EKS.Model.CreateNodegroupRequest();
            
            if (cmdletContext.AmiType != null)
            {
                request.AmiType = cmdletContext.AmiType;
            }
            if (cmdletContext.CapacityType != null)
            {
                request.CapacityType = cmdletContext.CapacityType;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            if (cmdletContext.DiskSize != null)
            {
                request.DiskSize = cmdletContext.DiskSize.Value;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceTypes = cmdletContext.InstanceType;
            }
            if (cmdletContext.Label != null)
            {
                request.Labels = cmdletContext.Label;
            }
            
             // populate LaunchTemplate
            var requestLaunchTemplateIsNull = true;
            request.LaunchTemplate = new Amazon.EKS.Model.LaunchTemplateSpecification();
            System.String requestLaunchTemplate_launchTemplate_Id = null;
            if (cmdletContext.LaunchTemplate_Id != null)
            {
                requestLaunchTemplate_launchTemplate_Id = cmdletContext.LaunchTemplate_Id;
            }
            if (requestLaunchTemplate_launchTemplate_Id != null)
            {
                request.LaunchTemplate.Id = requestLaunchTemplate_launchTemplate_Id;
                requestLaunchTemplateIsNull = false;
            }
            System.String requestLaunchTemplate_launchTemplate_Name = null;
            if (cmdletContext.LaunchTemplate_Name != null)
            {
                requestLaunchTemplate_launchTemplate_Name = cmdletContext.LaunchTemplate_Name;
            }
            if (requestLaunchTemplate_launchTemplate_Name != null)
            {
                request.LaunchTemplate.Name = requestLaunchTemplate_launchTemplate_Name;
                requestLaunchTemplateIsNull = false;
            }
            System.String requestLaunchTemplate_launchTemplate_Version = null;
            if (cmdletContext.LaunchTemplate_Version != null)
            {
                requestLaunchTemplate_launchTemplate_Version = cmdletContext.LaunchTemplate_Version;
            }
            if (requestLaunchTemplate_launchTemplate_Version != null)
            {
                request.LaunchTemplate.Version = requestLaunchTemplate_launchTemplate_Version;
                requestLaunchTemplateIsNull = false;
            }
             // determine if request.LaunchTemplate should be set to null
            if (requestLaunchTemplateIsNull)
            {
                request.LaunchTemplate = null;
            }
            if (cmdletContext.NodegroupName != null)
            {
                request.NodegroupName = cmdletContext.NodegroupName;
            }
            
             // populate NodeRepairConfig
            var requestNodeRepairConfigIsNull = true;
            request.NodeRepairConfig = new Amazon.EKS.Model.NodeRepairConfig();
            System.Boolean? requestNodeRepairConfig_nodeRepairConfig_Enabled = null;
            if (cmdletContext.NodeRepairConfig_Enabled != null)
            {
                requestNodeRepairConfig_nodeRepairConfig_Enabled = cmdletContext.NodeRepairConfig_Enabled.Value;
            }
            if (requestNodeRepairConfig_nodeRepairConfig_Enabled != null)
            {
                request.NodeRepairConfig.Enabled = requestNodeRepairConfig_nodeRepairConfig_Enabled.Value;
                requestNodeRepairConfigIsNull = false;
            }
            System.Int32? requestNodeRepairConfig_nodeRepairConfig_MaxParallelNodesRepairedCount = null;
            if (cmdletContext.NodeRepairConfig_MaxParallelNodesRepairedCount != null)
            {
                requestNodeRepairConfig_nodeRepairConfig_MaxParallelNodesRepairedCount = cmdletContext.NodeRepairConfig_MaxParallelNodesRepairedCount.Value;
            }
            if (requestNodeRepairConfig_nodeRepairConfig_MaxParallelNodesRepairedCount != null)
            {
                request.NodeRepairConfig.MaxParallelNodesRepairedCount = requestNodeRepairConfig_nodeRepairConfig_MaxParallelNodesRepairedCount.Value;
                requestNodeRepairConfigIsNull = false;
            }
            System.Int32? requestNodeRepairConfig_nodeRepairConfig_MaxParallelNodesRepairedPercentage = null;
            if (cmdletContext.NodeRepairConfig_MaxParallelNodesRepairedPercentage != null)
            {
                requestNodeRepairConfig_nodeRepairConfig_MaxParallelNodesRepairedPercentage = cmdletContext.NodeRepairConfig_MaxParallelNodesRepairedPercentage.Value;
            }
            if (requestNodeRepairConfig_nodeRepairConfig_MaxParallelNodesRepairedPercentage != null)
            {
                request.NodeRepairConfig.MaxParallelNodesRepairedPercentage = requestNodeRepairConfig_nodeRepairConfig_MaxParallelNodesRepairedPercentage.Value;
                requestNodeRepairConfigIsNull = false;
            }
            System.Int32? requestNodeRepairConfig_nodeRepairConfig_MaxUnhealthyNodeThresholdCount = null;
            if (cmdletContext.NodeRepairConfig_MaxUnhealthyNodeThresholdCount != null)
            {
                requestNodeRepairConfig_nodeRepairConfig_MaxUnhealthyNodeThresholdCount = cmdletContext.NodeRepairConfig_MaxUnhealthyNodeThresholdCount.Value;
            }
            if (requestNodeRepairConfig_nodeRepairConfig_MaxUnhealthyNodeThresholdCount != null)
            {
                request.NodeRepairConfig.MaxUnhealthyNodeThresholdCount = requestNodeRepairConfig_nodeRepairConfig_MaxUnhealthyNodeThresholdCount.Value;
                requestNodeRepairConfigIsNull = false;
            }
            System.Int32? requestNodeRepairConfig_nodeRepairConfig_MaxUnhealthyNodeThresholdPercentage = null;
            if (cmdletContext.NodeRepairConfig_MaxUnhealthyNodeThresholdPercentage != null)
            {
                requestNodeRepairConfig_nodeRepairConfig_MaxUnhealthyNodeThresholdPercentage = cmdletContext.NodeRepairConfig_MaxUnhealthyNodeThresholdPercentage.Value;
            }
            if (requestNodeRepairConfig_nodeRepairConfig_MaxUnhealthyNodeThresholdPercentage != null)
            {
                request.NodeRepairConfig.MaxUnhealthyNodeThresholdPercentage = requestNodeRepairConfig_nodeRepairConfig_MaxUnhealthyNodeThresholdPercentage.Value;
                requestNodeRepairConfigIsNull = false;
            }
            List<Amazon.EKS.Model.NodeRepairConfigOverrides> requestNodeRepairConfig_nodeRepairConfig_NodeRepairConfigOverride = null;
            if (cmdletContext.NodeRepairConfig_NodeRepairConfigOverride != null)
            {
                requestNodeRepairConfig_nodeRepairConfig_NodeRepairConfigOverride = cmdletContext.NodeRepairConfig_NodeRepairConfigOverride;
            }
            if (requestNodeRepairConfig_nodeRepairConfig_NodeRepairConfigOverride != null)
            {
                request.NodeRepairConfig.NodeRepairConfigOverrides = requestNodeRepairConfig_nodeRepairConfig_NodeRepairConfigOverride;
                requestNodeRepairConfigIsNull = false;
            }
             // determine if request.NodeRepairConfig should be set to null
            if (requestNodeRepairConfigIsNull)
            {
                request.NodeRepairConfig = null;
            }
            if (cmdletContext.NodeRole != null)
            {
                request.NodeRole = cmdletContext.NodeRole;
            }
            if (cmdletContext.ReleaseVersion != null)
            {
                request.ReleaseVersion = cmdletContext.ReleaseVersion;
            }
            
             // populate RemoteAccess
            var requestRemoteAccessIsNull = true;
            request.RemoteAccess = new Amazon.EKS.Model.RemoteAccessConfig();
            System.String requestRemoteAccess_remoteAccess_Ec2SshKey = null;
            if (cmdletContext.RemoteAccess_Ec2SshKey != null)
            {
                requestRemoteAccess_remoteAccess_Ec2SshKey = cmdletContext.RemoteAccess_Ec2SshKey;
            }
            if (requestRemoteAccess_remoteAccess_Ec2SshKey != null)
            {
                request.RemoteAccess.Ec2SshKey = requestRemoteAccess_remoteAccess_Ec2SshKey;
                requestRemoteAccessIsNull = false;
            }
            List<System.String> requestRemoteAccess_remoteAccess_SourceSecurityGroup = null;
            if (cmdletContext.RemoteAccess_SourceSecurityGroup != null)
            {
                requestRemoteAccess_remoteAccess_SourceSecurityGroup = cmdletContext.RemoteAccess_SourceSecurityGroup;
            }
            if (requestRemoteAccess_remoteAccess_SourceSecurityGroup != null)
            {
                request.RemoteAccess.SourceSecurityGroups = requestRemoteAccess_remoteAccess_SourceSecurityGroup;
                requestRemoteAccessIsNull = false;
            }
             // determine if request.RemoteAccess should be set to null
            if (requestRemoteAccessIsNull)
            {
                request.RemoteAccess = null;
            }
            
             // populate ScalingConfig
            var requestScalingConfigIsNull = true;
            request.ScalingConfig = new Amazon.EKS.Model.NodegroupScalingConfig();
            System.Int32? requestScalingConfig_scalingConfig_DesiredSize = null;
            if (cmdletContext.ScalingConfig_DesiredSize != null)
            {
                requestScalingConfig_scalingConfig_DesiredSize = cmdletContext.ScalingConfig_DesiredSize.Value;
            }
            if (requestScalingConfig_scalingConfig_DesiredSize != null)
            {
                request.ScalingConfig.DesiredSize = requestScalingConfig_scalingConfig_DesiredSize.Value;
                requestScalingConfigIsNull = false;
            }
            System.Int32? requestScalingConfig_scalingConfig_MaxSize = null;
            if (cmdletContext.ScalingConfig_MaxSize != null)
            {
                requestScalingConfig_scalingConfig_MaxSize = cmdletContext.ScalingConfig_MaxSize.Value;
            }
            if (requestScalingConfig_scalingConfig_MaxSize != null)
            {
                request.ScalingConfig.MaxSize = requestScalingConfig_scalingConfig_MaxSize.Value;
                requestScalingConfigIsNull = false;
            }
            System.Int32? requestScalingConfig_scalingConfig_MinSize = null;
            if (cmdletContext.ScalingConfig_MinSize != null)
            {
                requestScalingConfig_scalingConfig_MinSize = cmdletContext.ScalingConfig_MinSize.Value;
            }
            if (requestScalingConfig_scalingConfig_MinSize != null)
            {
                request.ScalingConfig.MinSize = requestScalingConfig_scalingConfig_MinSize.Value;
                requestScalingConfigIsNull = false;
            }
             // determine if request.ScalingConfig should be set to null
            if (requestScalingConfigIsNull)
            {
                request.ScalingConfig = null;
            }
            if (cmdletContext.Subnet != null)
            {
                request.Subnets = cmdletContext.Subnet;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Taint != null)
            {
                request.Taints = cmdletContext.Taint;
            }
            
             // populate UpdateConfig
            var requestUpdateConfigIsNull = true;
            request.UpdateConfig = new Amazon.EKS.Model.NodegroupUpdateConfig();
            System.Int32? requestUpdateConfig_updateConfig_MaxUnavailable = null;
            if (cmdletContext.UpdateConfig_MaxUnavailable != null)
            {
                requestUpdateConfig_updateConfig_MaxUnavailable = cmdletContext.UpdateConfig_MaxUnavailable.Value;
            }
            if (requestUpdateConfig_updateConfig_MaxUnavailable != null)
            {
                request.UpdateConfig.MaxUnavailable = requestUpdateConfig_updateConfig_MaxUnavailable.Value;
                requestUpdateConfigIsNull = false;
            }
            System.Int32? requestUpdateConfig_updateConfig_MaxUnavailablePercentage = null;
            if (cmdletContext.UpdateConfig_MaxUnavailablePercentage != null)
            {
                requestUpdateConfig_updateConfig_MaxUnavailablePercentage = cmdletContext.UpdateConfig_MaxUnavailablePercentage.Value;
            }
            if (requestUpdateConfig_updateConfig_MaxUnavailablePercentage != null)
            {
                request.UpdateConfig.MaxUnavailablePercentage = requestUpdateConfig_updateConfig_MaxUnavailablePercentage.Value;
                requestUpdateConfigIsNull = false;
            }
            Amazon.EKS.NodegroupUpdateStrategies requestUpdateConfig_updateConfig_UpdateStrategy = null;
            if (cmdletContext.UpdateConfig_UpdateStrategy != null)
            {
                requestUpdateConfig_updateConfig_UpdateStrategy = cmdletContext.UpdateConfig_UpdateStrategy;
            }
            if (requestUpdateConfig_updateConfig_UpdateStrategy != null)
            {
                request.UpdateConfig.UpdateStrategy = requestUpdateConfig_updateConfig_UpdateStrategy;
                requestUpdateConfigIsNull = false;
            }
             // determine if request.UpdateConfig should be set to null
            if (requestUpdateConfigIsNull)
            {
                request.UpdateConfig = null;
            }
            if (cmdletContext.Version != null)
            {
                request.Version = cmdletContext.Version;
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
        
        private Amazon.EKS.Model.CreateNodegroupResponse CallAWSServiceOperation(IAmazonEKS client, Amazon.EKS.Model.CreateNodegroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Service for Kubernetes", "CreateNodegroup");
            try
            {
                #if DESKTOP
                return client.CreateNodegroup(request);
                #elif CORECLR
                return client.CreateNodegroupAsync(request).GetAwaiter().GetResult();
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
            public Amazon.EKS.AMITypes AmiType { get; set; }
            public Amazon.EKS.CapacityTypes CapacityType { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String ClusterName { get; set; }
            public System.Int32? DiskSize { get; set; }
            public List<System.String> InstanceType { get; set; }
            public Dictionary<System.String, System.String> Label { get; set; }
            public System.String LaunchTemplate_Id { get; set; }
            public System.String LaunchTemplate_Name { get; set; }
            public System.String LaunchTemplate_Version { get; set; }
            public System.String NodegroupName { get; set; }
            public System.Boolean? NodeRepairConfig_Enabled { get; set; }
            public System.Int32? NodeRepairConfig_MaxParallelNodesRepairedCount { get; set; }
            public System.Int32? NodeRepairConfig_MaxParallelNodesRepairedPercentage { get; set; }
            public System.Int32? NodeRepairConfig_MaxUnhealthyNodeThresholdCount { get; set; }
            public System.Int32? NodeRepairConfig_MaxUnhealthyNodeThresholdPercentage { get; set; }
            public List<Amazon.EKS.Model.NodeRepairConfigOverrides> NodeRepairConfig_NodeRepairConfigOverride { get; set; }
            public System.String NodeRole { get; set; }
            public System.String ReleaseVersion { get; set; }
            public System.String RemoteAccess_Ec2SshKey { get; set; }
            public List<System.String> RemoteAccess_SourceSecurityGroup { get; set; }
            public System.Int32? ScalingConfig_DesiredSize { get; set; }
            public System.Int32? ScalingConfig_MaxSize { get; set; }
            public System.Int32? ScalingConfig_MinSize { get; set; }
            public List<System.String> Subnet { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<Amazon.EKS.Model.Taint> Taint { get; set; }
            public System.Int32? UpdateConfig_MaxUnavailable { get; set; }
            public System.Int32? UpdateConfig_MaxUnavailablePercentage { get; set; }
            public Amazon.EKS.NodegroupUpdateStrategies UpdateConfig_UpdateStrategy { get; set; }
            public System.String Version { get; set; }
            public System.Func<Amazon.EKS.Model.CreateNodegroupResponse, NewEKSNodegroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Nodegroup;
        }
        
    }
}
