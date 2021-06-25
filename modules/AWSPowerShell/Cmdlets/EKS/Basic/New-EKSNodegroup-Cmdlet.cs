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
using Amazon.EKS;
using Amazon.EKS.Model;

namespace Amazon.PowerShell.Cmdlets.EKS
{
    /// <summary>
    /// Creates a managed node group for an Amazon EKS cluster. You can only create a node
    /// group for your cluster that is equal to the current Kubernetes version for the cluster.
    /// All node groups are created with the latest AMI release version for the respective
    /// minor Kubernetes version of the cluster, unless you deploy a custom AMI using a launch
    /// template. For more information about using launch templates, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/launch-templates.html">Launch
    /// template support</a>.
    /// 
    ///  
    /// <para>
    /// An Amazon EKS managed node group is an Amazon EC2 Auto Scaling group and associated
    /// Amazon EC2 instances that are managed by Amazon Web Services for an Amazon EKS cluster.
    /// Each node group uses a version of the Amazon EKS optimized Amazon Linux 2 AMI. For
    /// more information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/managed-node-groups.html">Managed
    /// Node Groups</a> in the <i>Amazon EKS User Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "EKSNodegroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EKS.Model.Nodegroup")]
    [AWSCmdlet("Calls the Amazon Elastic Container Service for Kubernetes CreateNodegroup API operation.", Operation = new[] {"CreateNodegroup"}, SelectReturnType = typeof(Amazon.EKS.Model.CreateNodegroupResponse))]
    [AWSCmdletOutput("Amazon.EKS.Model.Nodegroup or Amazon.EKS.Model.CreateNodegroupResponse",
        "This cmdlet returns an Amazon.EKS.Model.Nodegroup object.",
        "The service call response (type Amazon.EKS.Model.CreateNodegroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEKSNodegroupCmdlet : AmazonEKSClientCmdlet, IExecutor
    {
        
        #region Parameter AmiType
        /// <summary>
        /// <para>
        /// <para>The AMI type for your node group. GPU instance types should use the <code>AL2_x86_64_GPU</code>
        /// AMI type. Non-GPU instances should use the <code>AL2_x86_64</code> AMI type. Arm instances
        /// should use the <code>AL2_ARM_64</code> AMI type. All types use the Amazon EKS optimized
        /// Amazon Linux 2 AMI. If you specify <code>launchTemplate</code>, and your launch template
        /// uses a custom AMI, then don't specify <code>amiType</code>, or the node group deployment
        /// will fail. For more information about using launch templates with Amazon EKS, see
        /// <a href="https://docs.aws.amazon.com/eks/latest/userguide/launch-templates.html">Launch
        /// template support</a> in the Amazon EKS User Guide.</para>
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
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The name of the cluster to create the node group in.</para>
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
        /// <para>The current number of nodes that the managed node group should maintain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingConfig_DesiredSize { get; set; }
        #endregion
        
        #region Parameter DiskSize
        /// <summary>
        /// <para>
        /// <para>The root device disk size (in GiB) for your node group instances. The default disk
        /// size is 20 GiB. If you specify <code>launchTemplate</code>, then don't specify <code>diskSize</code>,
        /// or the node group deployment will fail. For more information about using launch templates
        /// with Amazon EKS, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/launch-templates.html">Launch
        /// template support</a> in the Amazon EKS User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DiskSize { get; set; }
        #endregion
        
        #region Parameter RemoteAccess_Ec2SshKey
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 SSH key that provides access for SSH communication with the nodes in
        /// the managed node group. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-key-pairs.html">Amazon
        /// EC2 key pairs and Linux instances</a> in the <i>Amazon Elastic Compute Cloud User
        /// Guide for Linux Instances</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RemoteAccess_Ec2SshKey { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_Id
        /// <summary>
        /// <para>
        /// <para>The ID of the launch template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LaunchTemplate_Id { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>Specify the instance types for a node group. If you specify a GPU instance type, be
        /// sure to specify <code>AL2_x86_64_GPU</code> with the <code>amiType</code> parameter.
        /// If you specify <code>launchTemplate</code>, then you can specify zero or one instance
        /// type in your launch template <i>or</i> you can specify 0-20 instance types for <code>instanceTypes</code>.
        /// If however, you specify an instance type in your launch template <i>and</i> specify
        /// any <code>instanceTypes</code>, the node group deployment will fail. If you don't
        /// specify an instance type in a launch template or for <code>instanceTypes</code>, then
        /// <code>t3.medium</code> is used, by default. If you specify <code>Spot</code> for <code>capacityType</code>,
        /// then we recommend specifying multiple values for <code>instanceTypes</code>. For more
        /// information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/managed-node-groups.html#managed-node-group-capacity-types">Managed
        /// node group capacity types</a> and <a href="https://docs.aws.amazon.com/eks/latest/userguide/launch-templates.html">Launch
        /// template support</a> in the <i>Amazon EKS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceTypes")]
        public System.String[] InstanceType { get; set; }
        #endregion
        
        #region Parameter Label
        /// <summary>
        /// <para>
        /// <para>The Kubernetes labels to be applied to the nodes in the node group when they are created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Labels")]
        public System.Collections.Hashtable Label { get; set; }
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
        /// <para>The maximum number of nodes unavailable at once during a version update. Nodes will
        /// be updated in parallel. This value or <code>maxUnavailablePercentage</code> is required
        /// to have a value.The maximum number is 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? UpdateConfig_MaxUnavailable { get; set; }
        #endregion
        
        #region Parameter UpdateConfig_MaxUnavailablePercentage
        /// <summary>
        /// <para>
        /// <para>The maximum percentage of nodes unavailable during a version update. This percentage
        /// of nodes will be updated in parallel, up to 100 nodes at once. This value or <code>maxUnavailable</code>
        /// is required to have a value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? UpdateConfig_MaxUnavailablePercentage { get; set; }
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
        /// <para>The name of the launch template.</para>
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
        
        #region Parameter NodeRole
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role to associate with your node group.
        /// The Amazon EKS worker node <code>kubelet</code> daemon makes calls to Amazon Web Services
        /// APIs on your behalf. Nodes receive permissions for these API calls through an IAM
        /// instance profile and associated policies. Before you can launch nodes and register
        /// them into a cluster, you must create an IAM role for those nodes to use when they
        /// are launched. For more information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/worker_node_IAM_role.html">Amazon
        /// EKS node IAM role</a> in the <i><i>Amazon EKS User Guide</i></i>. If you specify
        /// <code>launchTemplate</code>, then don't specify <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_IamInstanceProfile.html"><code>IamInstanceProfile</code></a> in your launch template, or the node group deployment
        /// will fail. For more information about using launch templates with Amazon EKS, see
        /// <a href="https://docs.aws.amazon.com/eks/latest/userguide/launch-templates.html">Launch
        /// template support</a> in the Amazon EKS User Guide.</para>
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
        /// used. For more information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/eks-linux-ami-versions.html">Amazon
        /// EKS optimized Amazon Linux 2 AMI versions</a> in the <i>Amazon EKS User Guide</i>.
        /// If you specify <code>launchTemplate</code>, and your launch template uses a custom
        /// AMI, then don't specify <code>releaseVersion</code>, or the node group deployment
        /// will fail. For more information about using launch templates with Amazon EKS, see
        /// <a href="https://docs.aws.amazon.com/eks/latest/userguide/launch-templates.html">Launch
        /// template support</a> in the Amazon EKS User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReleaseVersion { get; set; }
        #endregion
        
        #region Parameter RemoteAccess_SourceSecurityGroup
        /// <summary>
        /// <para>
        /// <para>The security groups that are allowed SSH access (port 22) to the nodes. If you specify
        /// an Amazon EC2 SSH key but do not specify a source security group when you create a
        /// managed node group, then port 22 on the nodes is opened to the internet (0.0.0.0/0).
        /// For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/VPC_SecurityGroups.html">Security
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
        /// If you specify <code>launchTemplate</code>, then don't specify <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateNetworkInterface.html"><code>SubnetId</code></a> in your launch template, or the node group deployment will
        /// fail. For more information about using launch templates with Amazon EKS, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/launch-templates.html">Launch
        /// template support</a> in the Amazon EKS User Guide.</para>
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
        /// <para>The metadata to apply to the node group to assist with categorization and organization.
        /// Each tag consists of a key and an optional value, both of which you define. Node group
        /// tags do not propagate to any other resources associated with the node group, such
        /// as the Amazon EC2 instances or subnets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Taint
        /// <summary>
        /// <para>
        /// <para>The Kubernetes taints to be applied to the nodes in the node group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Taints")]
        public Amazon.EKS.Model.Taint[] Taint { get; set; }
        #endregion
        
        #region Parameter LaunchTemplate_Version
        /// <summary>
        /// <para>
        /// <para>The version of the launch template to use. If no version is specified, then the template's
        /// default version is used.</para>
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
        /// <code>launchTemplate</code>, and your launch template uses a custom AMI, then don't
        /// specify <code>version</code>, or the node group deployment will fail. For more information
        /// about using launch templates with Amazon EKS, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/launch-templates.html">Launch
        /// template support</a> in the Amazon EKS User Guide.</para>
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
                    context.Label.Add((String)hashKey, (String)(this.Label[hashKey]));
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
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            if (this.Taint != null)
            {
                context.Taint = new List<Amazon.EKS.Model.Taint>(this.Taint);
            }
            context.UpdateConfig_MaxUnavailable = this.UpdateConfig_MaxUnavailable;
            context.UpdateConfig_MaxUnavailablePercentage = this.UpdateConfig_MaxUnavailablePercentage;
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
            public System.String Version { get; set; }
            public System.Func<Amazon.EKS.Model.CreateNodegroupResponse, NewEKSNodegroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Nodegroup;
        }
        
    }
}
