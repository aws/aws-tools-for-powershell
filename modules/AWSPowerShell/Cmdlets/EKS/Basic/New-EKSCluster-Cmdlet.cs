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
    /// Creates an Amazon EKS control plane.
    /// 
    ///  
    /// <para>
    /// The Amazon EKS control plane consists of control plane instances that run the Kubernetes
    /// software, such as <c>etcd</c> and the API server. The control plane runs in an account
    /// managed by Amazon Web Services, and the Kubernetes API is exposed by the Amazon EKS
    /// API server endpoint. Each Amazon EKS cluster control plane is single tenant and unique.
    /// It runs on its own set of Amazon EC2 instances.
    /// </para><para>
    /// The cluster control plane is provisioned across multiple Availability Zones and fronted
    /// by an Elastic Load Balancing Network Load Balancer. Amazon EKS also provisions elastic
    /// network interfaces in your VPC subnets to provide connectivity from the control plane
    /// instances to the nodes (for example, to support <c>kubectl exec</c>, <c>logs</c>,
    /// and <c>proxy</c> data flows).
    /// </para><para>
    /// Amazon EKS nodes run in your Amazon Web Services account and connect to your cluster's
    /// control plane over the Kubernetes API server endpoint and a certificate file that
    /// is created for your cluster.
    /// </para><para>
    /// You can use the <c>endpointPublicAccess</c> and <c>endpointPrivateAccess</c> parameters
    /// to enable or disable public and private access to your cluster's Kubernetes API server
    /// endpoint. By default, public access is enabled, and private access is disabled. For
    /// more information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/cluster-endpoint.html">Amazon
    /// EKS Cluster Endpoint Access Control</a> in the <i><i>Amazon EKS User Guide</i></i>.
    /// 
    /// </para><para>
    /// You can use the <c>logging</c> parameter to enable or disable exporting the Kubernetes
    /// control plane logs for your cluster to CloudWatch Logs. By default, cluster control
    /// plane logs aren't exported to CloudWatch Logs. For more information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/control-plane-logs.html">Amazon
    /// EKS Cluster Control Plane Logs</a> in the <i><i>Amazon EKS User Guide</i></i>.
    /// </para><note><para>
    /// CloudWatch Logs ingestion, archive storage, and data scanning rates apply to exported
    /// control plane logs. For more information, see <a href="http://aws.amazon.com/cloudwatch/pricing/">CloudWatch
    /// Pricing</a>.
    /// </para></note><para>
    /// In most cases, it takes several minutes to create a cluster. After you create an Amazon
    /// EKS cluster, you must configure your Kubernetes tooling to communicate with the API
    /// server and launch nodes into your cluster. For more information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/cluster-auth.html">Allowing
    /// users to access your cluster</a> and <a href="https://docs.aws.amazon.com/eks/latest/userguide/launch-workers.html">Launching
    /// Amazon EKS nodes</a> in the <i>Amazon EKS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EKSCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EKS.Model.Cluster")]
    [AWSCmdlet("Calls the Amazon Elastic Container Service for Kubernetes CreateCluster API operation.", Operation = new[] {"CreateCluster"}, SelectReturnType = typeof(Amazon.EKS.Model.CreateClusterResponse))]
    [AWSCmdletOutput("Amazon.EKS.Model.Cluster or Amazon.EKS.Model.CreateClusterResponse",
        "This cmdlet returns an Amazon.EKS.Model.Cluster object.",
        "The service call response (type Amazon.EKS.Model.CreateClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEKSClusterCmdlet : AmazonEKSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessConfig_AuthenticationMode
        /// <summary>
        /// <para>
        /// <para>The desired authentication mode for the cluster. If you create a cluster by using
        /// the EKS API, Amazon Web Services SDKs, or CloudFormation, the default is <c>CONFIG_MAP</c>.
        /// If you create the cluster by using the Amazon Web Services Management Console, the
        /// default value is <c>API_AND_CONFIG_MAP</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EKS.AuthenticationMode")]
        public Amazon.EKS.AuthenticationMode AccessConfig_AuthenticationMode { get; set; }
        #endregion
        
        #region Parameter AccessConfig_BootstrapClusterCreatorAdminPermission
        /// <summary>
        /// <para>
        /// <para>Specifies whether or not the cluster creator IAM principal was set as a cluster admin
        /// access entry during cluster creation time. The default value is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccessConfig_BootstrapClusterCreatorAdminPermissions")]
        public System.Boolean? AccessConfig_BootstrapClusterCreatorAdminPermission { get; set; }
        #endregion
        
        #region Parameter BootstrapSelfManagedAddon
        /// <summary>
        /// <para>
        /// <para>If you set this value to <c>False</c> when creating a cluster, the default networking
        /// add-ons will not be installed.</para><para>The default networking addons include vpc-cni, coredns, and kube-proxy.</para><para>Use this option when you plan to install third-party alternative add-ons or self-manage
        /// the default networking add-ons.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BootstrapSelfManagedAddons")]
        public System.Boolean? BootstrapSelfManagedAddon { get; set; }
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
        
        #region Parameter Logging_ClusterLogging
        /// <summary>
        /// <para>
        /// <para>The cluster control plane logging configuration for your cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.EKS.Model.LogSetup[] Logging_ClusterLogging { get; set; }
        #endregion
        
        #region Parameter OutpostConfig_ControlPlaneInstanceType
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 instance type that you want to use for your local Amazon EKS cluster
        /// on Outposts. Choose an instance type based on the number of nodes that your cluster
        /// will have. For more information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/eks-outposts-capacity-considerations.html">Capacity
        /// considerations</a> in the <i>Amazon EKS User Guide</i>.</para><para>The instance type that you specify is used for all Kubernetes control plane instances.
        /// The instance type can't be changed after cluster creation. The control plane is not
        /// automatically scaled by Amazon EKS.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutpostConfig_ControlPlaneInstanceType { get; set; }
        #endregion
        
        #region Parameter EncryptionConfig
        /// <summary>
        /// <para>
        /// <para>The encryption configuration for the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.EKS.Model.EncryptionConfig[] EncryptionConfig { get; set; }
        #endregion
        
        #region Parameter ControlPlanePlacement_GroupName
        /// <summary>
        /// <para>
        /// <para>The name of the placement group for the Kubernetes control plane instances. This setting
        /// can't be changed after cluster creation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutpostConfig_ControlPlanePlacement_GroupName")]
        public System.String ControlPlanePlacement_GroupName { get; set; }
        #endregion
        
        #region Parameter KubernetesNetworkConfig_IpFamily
        /// <summary>
        /// <para>
        /// <para>Specify which IP family is used to assign Kubernetes pod and service IP addresses.
        /// If you don't specify a value, <c>ipv4</c> is used by default. You can only specify
        /// an IP family when you create a cluster and can't change this value once the cluster
        /// is created. If you specify <c>ipv6</c>, the VPC and subnets that you specify for cluster
        /// creation must have both <c>IPv4</c> and <c>IPv6</c> CIDR blocks assigned to them.
        /// You can't specify <c>ipv6</c> for clusters in China Regions.</para><para>You can only specify <c>ipv6</c> for <c>1.21</c> and later clusters that use version
        /// <c>1.10.1</c> or later of the Amazon VPC CNI add-on. If you specify <c>ipv6</c>, then
        /// ensure that your VPC meets the requirements listed in the considerations listed in
        /// <a href="https://docs.aws.amazon.com/eks/latest/userguide/cni-ipv6.html">Assigning
        /// IPv6 addresses to pods and services</a> in the Amazon EKS User Guide. Kubernetes assigns
        /// services <c>IPv6</c> addresses from the unique local address range <c>(fc00::/7)</c>.
        /// You can't specify a custom <c>IPv6</c> CIDR block. Pod addresses are assigned from
        /// the subnet's <c>IPv6</c> CIDR.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EKS.IpFamily")]
        public Amazon.EKS.IpFamily KubernetesNetworkConfig_IpFamily { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The unique name to give to your cluster.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter OutpostConfig_OutpostArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Outpost that you want to use for your local Amazon EKS cluster on Outposts.
        /// Only a single Outpost ARN is supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutpostConfig_OutpostArns")]
        public System.String[] OutpostConfig_OutpostArn { get; set; }
        #endregion
        
        #region Parameter ResourcesVpcConfig
        /// <summary>
        /// <para>
        /// <para>The VPC configuration that's used by the cluster control plane. Amazon EKS VPC resources
        /// have specific requirements to work properly with Kubernetes. For more information,
        /// see <a href="https://docs.aws.amazon.com/eks/latest/userguide/network_reqs.html">Cluster
        /// VPC Considerations</a> and <a href="https://docs.aws.amazon.com/eks/latest/userguide/sec-group-reqs.html">Cluster
        /// Security Group Considerations</a> in the <i>Amazon EKS User Guide</i>. You must specify
        /// at least two subnets. You can specify up to five security groups. However, we recommend
        /// that you use a dedicated security group for your cluster control plane.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.EKS.Model.VpcConfigRequest ResourcesVpcConfig { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that provides permissions for the Kubernetes
        /// control plane to make calls to Amazon Web Services API operations on your behalf.
        /// For more information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/service_IAM_role.html">Amazon
        /// EKS Service IAM Role</a> in the <i><i>Amazon EKS User Guide</i></i>.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter KubernetesNetworkConfig_ServiceIpv4Cidr
        /// <summary>
        /// <para>
        /// <para>Don't specify a value if you select <c>ipv6</c> for <b>ipFamily</b>. The CIDR block
        /// to assign Kubernetes service IP addresses from. If you don't specify a block, Kubernetes
        /// assigns addresses from either the <c>10.100.0.0/16</c> or <c>172.20.0.0/16</c> CIDR
        /// blocks. We recommend that you specify a block that does not overlap with resources
        /// in other networks that are peered or connected to your VPC. The block must meet the
        /// following requirements:</para><ul><li><para>Within one of the following private IP address blocks: <c>10.0.0.0/8</c>, <c>172.16.0.0/12</c>,
        /// or <c>192.168.0.0/16</c>.</para></li><li><para>Doesn't overlap with any CIDR block assigned to the VPC that you selected for VPC.</para></li><li><para>Between <c>/24</c> and <c>/12</c>.</para></li></ul><important><para>You can only specify a custom CIDR block when you create a cluster. You can't change
        /// this value after the cluster is created.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KubernetesNetworkConfig_ServiceIpv4Cidr { get; set; }
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
        
        #region Parameter Version
        /// <summary>
        /// <para>
        /// <para>The desired Kubernetes version for your cluster. If you don't specify a value here,
        /// the default version available in Amazon EKS is used.</para><note><para>The default version might not be the latest version available.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Cluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EKS.Model.CreateClusterResponse).
        /// Specifying the name of a property of type Amazon.EKS.Model.CreateClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Cluster";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EKSCluster (CreateCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EKS.Model.CreateClusterResponse, NewEKSClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccessConfig_AuthenticationMode = this.AccessConfig_AuthenticationMode;
            context.AccessConfig_BootstrapClusterCreatorAdminPermission = this.AccessConfig_BootstrapClusterCreatorAdminPermission;
            context.BootstrapSelfManagedAddon = this.BootstrapSelfManagedAddon;
            context.ClientRequestToken = this.ClientRequestToken;
            if (this.EncryptionConfig != null)
            {
                context.EncryptionConfig = new List<Amazon.EKS.Model.EncryptionConfig>(this.EncryptionConfig);
            }
            context.KubernetesNetworkConfig_IpFamily = this.KubernetesNetworkConfig_IpFamily;
            context.KubernetesNetworkConfig_ServiceIpv4Cidr = this.KubernetesNetworkConfig_ServiceIpv4Cidr;
            if (this.Logging_ClusterLogging != null)
            {
                context.Logging_ClusterLogging = new List<Amazon.EKS.Model.LogSetup>(this.Logging_ClusterLogging);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutpostConfig_ControlPlaneInstanceType = this.OutpostConfig_ControlPlaneInstanceType;
            context.ControlPlanePlacement_GroupName = this.ControlPlanePlacement_GroupName;
            if (this.OutpostConfig_OutpostArn != null)
            {
                context.OutpostConfig_OutpostArn = new List<System.String>(this.OutpostConfig_OutpostArn);
            }
            context.ResourcesVpcConfig = this.ResourcesVpcConfig;
            #if MODULAR
            if (this.ResourcesVpcConfig == null && ParameterWasBound(nameof(this.ResourcesVpcConfig)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourcesVpcConfig which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EKS.Model.CreateClusterRequest();
            
            
             // populate AccessConfig
            var requestAccessConfigIsNull = true;
            request.AccessConfig = new Amazon.EKS.Model.CreateAccessConfigRequest();
            Amazon.EKS.AuthenticationMode requestAccessConfig_accessConfig_AuthenticationMode = null;
            if (cmdletContext.AccessConfig_AuthenticationMode != null)
            {
                requestAccessConfig_accessConfig_AuthenticationMode = cmdletContext.AccessConfig_AuthenticationMode;
            }
            if (requestAccessConfig_accessConfig_AuthenticationMode != null)
            {
                request.AccessConfig.AuthenticationMode = requestAccessConfig_accessConfig_AuthenticationMode;
                requestAccessConfigIsNull = false;
            }
            System.Boolean? requestAccessConfig_accessConfig_BootstrapClusterCreatorAdminPermission = null;
            if (cmdletContext.AccessConfig_BootstrapClusterCreatorAdminPermission != null)
            {
                requestAccessConfig_accessConfig_BootstrapClusterCreatorAdminPermission = cmdletContext.AccessConfig_BootstrapClusterCreatorAdminPermission.Value;
            }
            if (requestAccessConfig_accessConfig_BootstrapClusterCreatorAdminPermission != null)
            {
                request.AccessConfig.BootstrapClusterCreatorAdminPermissions = requestAccessConfig_accessConfig_BootstrapClusterCreatorAdminPermission.Value;
                requestAccessConfigIsNull = false;
            }
             // determine if request.AccessConfig should be set to null
            if (requestAccessConfigIsNull)
            {
                request.AccessConfig = null;
            }
            if (cmdletContext.BootstrapSelfManagedAddon != null)
            {
                request.BootstrapSelfManagedAddons = cmdletContext.BootstrapSelfManagedAddon.Value;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.EncryptionConfig != null)
            {
                request.EncryptionConfig = cmdletContext.EncryptionConfig;
            }
            
             // populate KubernetesNetworkConfig
            var requestKubernetesNetworkConfigIsNull = true;
            request.KubernetesNetworkConfig = new Amazon.EKS.Model.KubernetesNetworkConfigRequest();
            Amazon.EKS.IpFamily requestKubernetesNetworkConfig_kubernetesNetworkConfig_IpFamily = null;
            if (cmdletContext.KubernetesNetworkConfig_IpFamily != null)
            {
                requestKubernetesNetworkConfig_kubernetesNetworkConfig_IpFamily = cmdletContext.KubernetesNetworkConfig_IpFamily;
            }
            if (requestKubernetesNetworkConfig_kubernetesNetworkConfig_IpFamily != null)
            {
                request.KubernetesNetworkConfig.IpFamily = requestKubernetesNetworkConfig_kubernetesNetworkConfig_IpFamily;
                requestKubernetesNetworkConfigIsNull = false;
            }
            System.String requestKubernetesNetworkConfig_kubernetesNetworkConfig_ServiceIpv4Cidr = null;
            if (cmdletContext.KubernetesNetworkConfig_ServiceIpv4Cidr != null)
            {
                requestKubernetesNetworkConfig_kubernetesNetworkConfig_ServiceIpv4Cidr = cmdletContext.KubernetesNetworkConfig_ServiceIpv4Cidr;
            }
            if (requestKubernetesNetworkConfig_kubernetesNetworkConfig_ServiceIpv4Cidr != null)
            {
                request.KubernetesNetworkConfig.ServiceIpv4Cidr = requestKubernetesNetworkConfig_kubernetesNetworkConfig_ServiceIpv4Cidr;
                requestKubernetesNetworkConfigIsNull = false;
            }
             // determine if request.KubernetesNetworkConfig should be set to null
            if (requestKubernetesNetworkConfigIsNull)
            {
                request.KubernetesNetworkConfig = null;
            }
            
             // populate Logging
            var requestLoggingIsNull = true;
            request.Logging = new Amazon.EKS.Model.Logging();
            List<Amazon.EKS.Model.LogSetup> requestLogging_logging_ClusterLogging = null;
            if (cmdletContext.Logging_ClusterLogging != null)
            {
                requestLogging_logging_ClusterLogging = cmdletContext.Logging_ClusterLogging;
            }
            if (requestLogging_logging_ClusterLogging != null)
            {
                request.Logging.ClusterLogging = requestLogging_logging_ClusterLogging;
                requestLoggingIsNull = false;
            }
             // determine if request.Logging should be set to null
            if (requestLoggingIsNull)
            {
                request.Logging = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OutpostConfig
            var requestOutpostConfigIsNull = true;
            request.OutpostConfig = new Amazon.EKS.Model.OutpostConfigRequest();
            System.String requestOutpostConfig_outpostConfig_ControlPlaneInstanceType = null;
            if (cmdletContext.OutpostConfig_ControlPlaneInstanceType != null)
            {
                requestOutpostConfig_outpostConfig_ControlPlaneInstanceType = cmdletContext.OutpostConfig_ControlPlaneInstanceType;
            }
            if (requestOutpostConfig_outpostConfig_ControlPlaneInstanceType != null)
            {
                request.OutpostConfig.ControlPlaneInstanceType = requestOutpostConfig_outpostConfig_ControlPlaneInstanceType;
                requestOutpostConfigIsNull = false;
            }
            List<System.String> requestOutpostConfig_outpostConfig_OutpostArn = null;
            if (cmdletContext.OutpostConfig_OutpostArn != null)
            {
                requestOutpostConfig_outpostConfig_OutpostArn = cmdletContext.OutpostConfig_OutpostArn;
            }
            if (requestOutpostConfig_outpostConfig_OutpostArn != null)
            {
                request.OutpostConfig.OutpostArns = requestOutpostConfig_outpostConfig_OutpostArn;
                requestOutpostConfigIsNull = false;
            }
            Amazon.EKS.Model.ControlPlanePlacementRequest requestOutpostConfig_outpostConfig_ControlPlanePlacement = null;
            
             // populate ControlPlanePlacement
            var requestOutpostConfig_outpostConfig_ControlPlanePlacementIsNull = true;
            requestOutpostConfig_outpostConfig_ControlPlanePlacement = new Amazon.EKS.Model.ControlPlanePlacementRequest();
            System.String requestOutpostConfig_outpostConfig_ControlPlanePlacement_controlPlanePlacement_GroupName = null;
            if (cmdletContext.ControlPlanePlacement_GroupName != null)
            {
                requestOutpostConfig_outpostConfig_ControlPlanePlacement_controlPlanePlacement_GroupName = cmdletContext.ControlPlanePlacement_GroupName;
            }
            if (requestOutpostConfig_outpostConfig_ControlPlanePlacement_controlPlanePlacement_GroupName != null)
            {
                requestOutpostConfig_outpostConfig_ControlPlanePlacement.GroupName = requestOutpostConfig_outpostConfig_ControlPlanePlacement_controlPlanePlacement_GroupName;
                requestOutpostConfig_outpostConfig_ControlPlanePlacementIsNull = false;
            }
             // determine if requestOutpostConfig_outpostConfig_ControlPlanePlacement should be set to null
            if (requestOutpostConfig_outpostConfig_ControlPlanePlacementIsNull)
            {
                requestOutpostConfig_outpostConfig_ControlPlanePlacement = null;
            }
            if (requestOutpostConfig_outpostConfig_ControlPlanePlacement != null)
            {
                request.OutpostConfig.ControlPlanePlacement = requestOutpostConfig_outpostConfig_ControlPlanePlacement;
                requestOutpostConfigIsNull = false;
            }
             // determine if request.OutpostConfig should be set to null
            if (requestOutpostConfigIsNull)
            {
                request.OutpostConfig = null;
            }
            if (cmdletContext.ResourcesVpcConfig != null)
            {
                request.ResourcesVpcConfig = cmdletContext.ResourcesVpcConfig;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.EKS.Model.CreateClusterResponse CallAWSServiceOperation(IAmazonEKS client, Amazon.EKS.Model.CreateClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Service for Kubernetes", "CreateCluster");
            try
            {
                #if DESKTOP
                return client.CreateCluster(request);
                #elif CORECLR
                return client.CreateClusterAsync(request).GetAwaiter().GetResult();
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
            public Amazon.EKS.AuthenticationMode AccessConfig_AuthenticationMode { get; set; }
            public System.Boolean? AccessConfig_BootstrapClusterCreatorAdminPermission { get; set; }
            public System.Boolean? BootstrapSelfManagedAddon { get; set; }
            public System.String ClientRequestToken { get; set; }
            public List<Amazon.EKS.Model.EncryptionConfig> EncryptionConfig { get; set; }
            public Amazon.EKS.IpFamily KubernetesNetworkConfig_IpFamily { get; set; }
            public System.String KubernetesNetworkConfig_ServiceIpv4Cidr { get; set; }
            public List<Amazon.EKS.Model.LogSetup> Logging_ClusterLogging { get; set; }
            public System.String Name { get; set; }
            public System.String OutpostConfig_ControlPlaneInstanceType { get; set; }
            public System.String ControlPlanePlacement_GroupName { get; set; }
            public List<System.String> OutpostConfig_OutpostArn { get; set; }
            public Amazon.EKS.Model.VpcConfigRequest ResourcesVpcConfig { get; set; }
            public System.String RoleArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String Version { get; set; }
            public System.Func<Amazon.EKS.Model.CreateClusterResponse, NewEKSClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Cluster;
        }
        
    }
}
