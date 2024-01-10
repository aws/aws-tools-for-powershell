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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Modifies the settings for a cluster.
    /// 
    ///  
    /// <para>
    /// You can also change node type and the number of nodes to scale up or down the cluster.
    /// When resizing a cluster, you must specify both the number of nodes and the node type
    /// even if one of the parameters does not change.
    /// </para><para>
    /// You can add another security or parameter group, or change the admin user password.
    /// Resetting a cluster password or modifying the security groups associated with a cluster
    /// do not need a reboot. However, modifying a parameter group requires a reboot for parameters
    /// to take effect. For more information about managing clusters, go to <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/working-with-clusters.html">Amazon
    /// Redshift Clusters</a> in the <i>Amazon Redshift Cluster Management Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "RSCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.Cluster")]
    [AWSCmdlet("Calls the Amazon Redshift ModifyCluster API operation.", Operation = new[] {"ModifyCluster"}, SelectReturnType = typeof(Amazon.Redshift.Model.ModifyClusterResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.Cluster or Amazon.Redshift.Model.ModifyClusterResponse",
        "This cmdlet returns an Amazon.Redshift.Model.Cluster object.",
        "The service call response (type Amazon.Redshift.Model.ModifyClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditRSClusterCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllowVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>If <c>true</c>, major version upgrades will be applied automatically to the cluster
        /// during the maintenance window. </para><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter AutomatedSnapshotRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days that automated snapshots are retained. If the value is 0, automated
        /// snapshots are disabled. Even if automated snapshots are disabled, you can still create
        /// manual snapshots when you want with <a>CreateClusterSnapshot</a>. </para><para>If you decrease the automated snapshot retention period from its current value, existing
        /// automated snapshots that fall outside of the new retention period will be immediately
        /// deleted.</para><para>You can't disable automated snapshots for RA3 node types. Set the automated retention
        /// period from 1-35 days.</para><para>Default: Uses existing setting.</para><para>Constraints: Must be a value from 0 to 35.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AutomatedSnapshotRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The option to initiate relocation for an Amazon Redshift cluster to the target Availability
        /// Zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter AvailabilityZoneRelocation
        /// <summary>
        /// <para>
        /// <para>The option to enable relocation for an Amazon Redshift cluster between Availability
        /// Zones after the cluster modification is complete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AvailabilityZoneRelocation { get; set; }
        #endregion
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the cluster to be modified.</para><para>Example: <c>examplecluster</c></para>
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
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter ClusterParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the cluster parameter group to apply to this cluster. This change is applied
        /// only after the cluster is rebooted. To reboot a cluster use <a>RebootCluster</a>.
        /// </para><para>Default: Uses existing setting.</para><para>Constraints: The cluster parameter group must be in the same parameter group family
        /// that matches the cluster version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClusterParameterGroupName { get; set; }
        #endregion
        
        #region Parameter ClusterSecurityGroup
        /// <summary>
        /// <para>
        /// <para>A list of cluster security groups to be authorized on this cluster. This change is
        /// asynchronously applied as soon as possible.</para><para>Security groups currently associated with the cluster, and not in the list of groups
        /// to apply, will be revoked from the cluster.</para><para>Constraints:</para><ul><li><para>Must be 1 to 255 alphanumeric characters or hyphens</para></li><li><para>First character must be a letter</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ClusterSecurityGroups")]
        public System.String[] ClusterSecurityGroup { get; set; }
        #endregion
        
        #region Parameter ClusterType
        /// <summary>
        /// <para>
        /// <para>The new cluster type.</para><para>When you submit your cluster resize request, your existing cluster goes into a read-only
        /// mode. After Amazon Redshift provisions a new cluster based on your resize requirements,
        /// there will be outage for a period while the old cluster is deleted and your connection
        /// is switched to the new cluster. You can use <a>DescribeResize</a> to track the progress
        /// of the resize request. </para><para>Valid Values: <c> multi-node | single-node </c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClusterType { get; set; }
        #endregion
        
        #region Parameter ClusterVersion
        /// <summary>
        /// <para>
        /// <para>The new version number of the Amazon Redshift engine to upgrade to.</para><para>For major version upgrades, if a non-default cluster parameter group is currently
        /// in use, a new cluster parameter group in the cluster parameter group family for the
        /// new version must be specified. The new cluster parameter group can be the default
        /// for that cluster parameter group family. For more information about parameters and
        /// parameter groups, go to <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/working-with-parameter-groups.html">Amazon
        /// Redshift Parameter Groups</a> in the <i>Amazon Redshift Cluster Management Guide</i>.</para><para>Example: <c>1.0</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClusterVersion { get; set; }
        #endregion
        
        #region Parameter ElasticIp
        /// <summary>
        /// <para>
        /// <para>The Elastic IP (EIP) address for the cluster.</para><para>Constraints: The cluster must be provisioned in EC2-VPC and publicly-accessible through
        /// an Internet gateway. For more information about provisioning clusters in EC2-VPC,
        /// go to <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/working-with-clusters.html#cluster-platforms">Supported
        /// Platforms to Launch Your Cluster</a> in the Amazon Redshift Cluster Management Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ElasticIp { get; set; }
        #endregion
        
        #region Parameter Encrypted
        /// <summary>
        /// <para>
        /// <para>Indicates whether the cluster is encrypted. If the value is encrypted (true) and you
        /// provide a value for the <c>KmsKeyId</c> parameter, we encrypt the cluster with the
        /// provided <c>KmsKeyId</c>. If you don't provide a <c>KmsKeyId</c>, we encrypt with
        /// the default key. </para><para>If the value is not encrypted (false), then the cluster is decrypted. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Encrypted { get; set; }
        #endregion
        
        #region Parameter EnhancedVpcRouting
        /// <summary>
        /// <para>
        /// <para>An option that specifies whether to create the cluster with enhanced VPC routing enabled.
        /// To create a cluster that uses enhanced VPC routing, the cluster must be in a VPC.
        /// For more information, see <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/enhanced-vpc-routing.html">Enhanced
        /// VPC Routing</a> in the Amazon Redshift Cluster Management Guide.</para><para>If this option is <c>true</c>, enhanced VPC routing is enabled. </para><para>Default: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnhancedVpcRouting { get; set; }
        #endregion
        
        #region Parameter HsmClientCertificateIdentifier
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the HSM client certificate the Amazon Redshift cluster uses
        /// to retrieve the data encryption keys stored in an HSM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HsmClientCertificateIdentifier { get; set; }
        #endregion
        
        #region Parameter HsmConfigurationIdentifier
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the HSM configuration that contains the information the Amazon
        /// Redshift cluster can use to retrieve and store keys in an HSM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HsmConfigurationIdentifier { get; set; }
        #endregion
        
        #region Parameter IpAddressType
        /// <summary>
        /// <para>
        /// <para>The IP address types that the cluster supports. Possible values are <c>ipv4</c> and
        /// <c>dualstack</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IpAddressType { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Key Management Service (KMS) key ID of the encryption key that you want to use
        /// to encrypt data in the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter MaintenanceTrackName
        /// <summary>
        /// <para>
        /// <para>The name for the maintenance track that you want to assign for the cluster. This name
        /// change is asynchronous. The new track name stays in the <c>PendingModifiedValues</c>
        /// for the cluster until the next maintenance window. When the maintenance track changes,
        /// the cluster is switched to the latest cluster release available for the maintenance
        /// track. At this point, the maintenance track name is applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaintenanceTrackName { get; set; }
        #endregion
        
        #region Parameter ManageMasterPassword
        /// <summary>
        /// <para>
        /// <para>If <c>true</c>, Amazon Redshift uses Secrets Manager to manage this cluster's admin
        /// credentials. You can't use <c>MasterUserPassword</c> if <c>ManageMasterPassword</c>
        /// is true. If <c>ManageMasterPassword</c> is false or not set, Amazon Redshift uses
        /// <c>MasterUserPassword</c> for the admin user account's password. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ManageMasterPassword { get; set; }
        #endregion
        
        #region Parameter ManualSnapshotRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The default for number of days that a newly created manual snapshot is retained. If
        /// the value is -1, the manual snapshot is retained indefinitely. This value doesn't
        /// retroactively change the retention periods of existing manual snapshots.</para><para>The value must be either -1 or an integer between 1 and 3,653.</para><para>The default value is -1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ManualSnapshotRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter MasterPasswordSecretKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The ID of the Key Management Service (KMS) key used to encrypt and store the cluster's
        /// admin credentials secret. You can only use this parameter if <c>ManageMasterPassword</c>
        /// is true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MasterPasswordSecretKmsKeyId { get; set; }
        #endregion
        
        #region Parameter MasterUserPassword
        /// <summary>
        /// <para>
        /// <para>The new password for the cluster admin user. This change is asynchronously applied
        /// as soon as possible. Between the time of the request and the completion of the request,
        /// the <c>MasterUserPassword</c> element exists in the <c>PendingModifiedValues</c> element
        /// of the operation response. </para><para>You can't use <c>MasterUserPassword</c> if <c>ManageMasterPassword</c> is <c>true</c>.</para><note><para>Operations never return the password, so this operation provides a way to regain access
        /// to the admin user account for a cluster if the password is lost.</para></note><para>Default: Uses existing setting.</para><para>Constraints:</para><ul><li><para>Must be between 8 and 64 characters in length.</para></li><li><para>Must contain at least one uppercase letter.</para></li><li><para>Must contain at least one lowercase letter.</para></li><li><para>Must contain one number.</para></li><li><para>Can be any printable ASCII character (ASCII code 33-126) except <c>'</c> (single quote),
        /// <c>"</c> (double quote), <c>\</c>, <c>/</c>, or <c>@</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MasterUserPassword { get; set; }
        #endregion
        
        #region Parameter MultiAZ
        /// <summary>
        /// <para>
        /// <para>If true and the cluster is currently only deployed in a single Availability Zone,
        /// the cluster will be modified to be deployed in two Availability Zones.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MultiAZ { get; set; }
        #endregion
        
        #region Parameter NewClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The new identifier for the cluster.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 alphanumeric characters or hyphens.</para></li><li><para>Alphabetic characters must be lowercase.</para></li><li><para>First character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li><li><para>Must be unique for all clusters within an Amazon Web Services account.</para></li></ul><para>Example: <c>examplecluster</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter NodeType
        /// <summary>
        /// <para>
        /// <para>The new node type of the cluster. If you specify a new node type, you must also specify
        /// the number of nodes parameter.</para><para> For more information about resizing clusters, go to <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/rs-resize-tutorial.html">Resizing
        /// Clusters in Amazon Redshift</a> in the <i>Amazon Redshift Cluster Management Guide</i>.</para><para>Valid Values: <c>ds2.xlarge</c> | <c>ds2.8xlarge</c> | <c>dc1.large</c> | <c>dc1.8xlarge</c>
        /// | <c>dc2.large</c> | <c>dc2.8xlarge</c> | <c>ra3.xlplus</c> | <c>ra3.4xlarge</c> |
        /// <c>ra3.16xlarge</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NodeType { get; set; }
        #endregion
        
        #region Parameter NumberOfNodes
        /// <summary>
        /// <para>
        /// <para>The new number of nodes of the cluster. If you specify a new number of nodes, you
        /// must also specify the node type parameter.</para><para> For more information about resizing clusters, go to <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/rs-resize-tutorial.html">Resizing
        /// Clusters in Amazon Redshift</a> in the <i>Amazon Redshift Cluster Management Guide</i>.</para><para>Valid Values: Integer greater than <c>0</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NumberOfNodes { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The option to change the port of an Amazon Redshift cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>The weekly time range (in UTC) during which system maintenance can occur, if necessary.
        /// If system maintenance is necessary during the window, it may result in an outage.</para><para>This maintenance window change is made immediately. If the new maintenance window
        /// indicates the current time, there must be at least 120 minutes between the current
        /// time and end of the window in order to ensure that pending changes are applied.</para><para>Default: Uses existing setting.</para><para>Format: ddd:hh24:mi-ddd:hh24:mi, for example <c>wed:07:30-wed:08:00</c>.</para><para>Valid Days: Mon | Tue | Wed | Thu | Fri | Sat | Sun</para><para>Constraints: Must be at least 30 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>If <c>true</c>, the cluster can be accessed from a public network. Only clusters in
        /// VPCs can be set to be publicly available.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of virtual private cloud (VPC) security groups to be associated with the cluster.
        /// This change is asynchronously applied as soon as possible.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Cluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.ModifyClusterResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.ModifyClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Cluster";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RSCluster (ModifyCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.ModifyClusterResponse, EditRSClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AllowVersionUpgrade = this.AllowVersionUpgrade;
            context.AutomatedSnapshotRetentionPeriod = this.AutomatedSnapshotRetentionPeriod;
            context.AvailabilityZone = this.AvailabilityZone;
            context.AvailabilityZoneRelocation = this.AvailabilityZoneRelocation;
            context.ClusterIdentifier = this.ClusterIdentifier;
            #if MODULAR
            if (this.ClusterIdentifier == null && ParameterWasBound(nameof(this.ClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClusterParameterGroupName = this.ClusterParameterGroupName;
            if (this.ClusterSecurityGroup != null)
            {
                context.ClusterSecurityGroup = new List<System.String>(this.ClusterSecurityGroup);
            }
            context.ClusterType = this.ClusterType;
            context.ClusterVersion = this.ClusterVersion;
            context.ElasticIp = this.ElasticIp;
            context.Encrypted = this.Encrypted;
            context.EnhancedVpcRouting = this.EnhancedVpcRouting;
            context.HsmClientCertificateIdentifier = this.HsmClientCertificateIdentifier;
            context.HsmConfigurationIdentifier = this.HsmConfigurationIdentifier;
            context.IpAddressType = this.IpAddressType;
            context.KmsKeyId = this.KmsKeyId;
            context.MaintenanceTrackName = this.MaintenanceTrackName;
            context.ManageMasterPassword = this.ManageMasterPassword;
            context.ManualSnapshotRetentionPeriod = this.ManualSnapshotRetentionPeriod;
            context.MasterPasswordSecretKmsKeyId = this.MasterPasswordSecretKmsKeyId;
            context.MasterUserPassword = this.MasterUserPassword;
            context.MultiAZ = this.MultiAZ;
            context.NewClusterIdentifier = this.NewClusterIdentifier;
            context.NodeType = this.NodeType;
            context.NumberOfNodes = this.NumberOfNodes;
            context.Port = this.Port;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            context.PubliclyAccessible = this.PubliclyAccessible;
            if (this.VpcSecurityGroupId != null)
            {
                context.VpcSecurityGroupId = new List<System.String>(this.VpcSecurityGroupId);
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
            var request = new Amazon.Redshift.Model.ModifyClusterRequest();
            
            if (cmdletContext.AllowVersionUpgrade != null)
            {
                request.AllowVersionUpgrade = cmdletContext.AllowVersionUpgrade.Value;
            }
            if (cmdletContext.AutomatedSnapshotRetentionPeriod != null)
            {
                request.AutomatedSnapshotRetentionPeriod = cmdletContext.AutomatedSnapshotRetentionPeriod.Value;
            }
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.AvailabilityZoneRelocation != null)
            {
                request.AvailabilityZoneRelocation = cmdletContext.AvailabilityZoneRelocation.Value;
            }
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.ClusterParameterGroupName != null)
            {
                request.ClusterParameterGroupName = cmdletContext.ClusterParameterGroupName;
            }
            if (cmdletContext.ClusterSecurityGroup != null)
            {
                request.ClusterSecurityGroups = cmdletContext.ClusterSecurityGroup;
            }
            if (cmdletContext.ClusterType != null)
            {
                request.ClusterType = cmdletContext.ClusterType;
            }
            if (cmdletContext.ClusterVersion != null)
            {
                request.ClusterVersion = cmdletContext.ClusterVersion;
            }
            if (cmdletContext.ElasticIp != null)
            {
                request.ElasticIp = cmdletContext.ElasticIp;
            }
            if (cmdletContext.Encrypted != null)
            {
                request.Encrypted = cmdletContext.Encrypted.Value;
            }
            if (cmdletContext.EnhancedVpcRouting != null)
            {
                request.EnhancedVpcRouting = cmdletContext.EnhancedVpcRouting.Value;
            }
            if (cmdletContext.HsmClientCertificateIdentifier != null)
            {
                request.HsmClientCertificateIdentifier = cmdletContext.HsmClientCertificateIdentifier;
            }
            if (cmdletContext.HsmConfigurationIdentifier != null)
            {
                request.HsmConfigurationIdentifier = cmdletContext.HsmConfigurationIdentifier;
            }
            if (cmdletContext.IpAddressType != null)
            {
                request.IpAddressType = cmdletContext.IpAddressType;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.MaintenanceTrackName != null)
            {
                request.MaintenanceTrackName = cmdletContext.MaintenanceTrackName;
            }
            if (cmdletContext.ManageMasterPassword != null)
            {
                request.ManageMasterPassword = cmdletContext.ManageMasterPassword.Value;
            }
            if (cmdletContext.ManualSnapshotRetentionPeriod != null)
            {
                request.ManualSnapshotRetentionPeriod = cmdletContext.ManualSnapshotRetentionPeriod.Value;
            }
            if (cmdletContext.MasterPasswordSecretKmsKeyId != null)
            {
                request.MasterPasswordSecretKmsKeyId = cmdletContext.MasterPasswordSecretKmsKeyId;
            }
            if (cmdletContext.MasterUserPassword != null)
            {
                request.MasterUserPassword = cmdletContext.MasterUserPassword;
            }
            if (cmdletContext.MultiAZ != null)
            {
                request.MultiAZ = cmdletContext.MultiAZ.Value;
            }
            if (cmdletContext.NewClusterIdentifier != null)
            {
                request.NewClusterIdentifier = cmdletContext.NewClusterIdentifier;
            }
            if (cmdletContext.NodeType != null)
            {
                request.NodeType = cmdletContext.NodeType;
            }
            if (cmdletContext.NumberOfNodes != null)
            {
                request.NumberOfNodes = cmdletContext.NumberOfNodes.Value;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.PreferredMaintenanceWindow != null)
            {
                request.PreferredMaintenanceWindow = cmdletContext.PreferredMaintenanceWindow;
            }
            if (cmdletContext.PubliclyAccessible != null)
            {
                request.PubliclyAccessible = cmdletContext.PubliclyAccessible.Value;
            }
            if (cmdletContext.VpcSecurityGroupId != null)
            {
                request.VpcSecurityGroupIds = cmdletContext.VpcSecurityGroupId;
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
        
        private Amazon.Redshift.Model.ModifyClusterResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.ModifyClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "ModifyCluster");
            try
            {
                #if DESKTOP
                return client.ModifyCluster(request);
                #elif CORECLR
                return client.ModifyClusterAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AllowVersionUpgrade { get; set; }
            public System.Int32? AutomatedSnapshotRetentionPeriod { get; set; }
            public System.String AvailabilityZone { get; set; }
            public System.Boolean? AvailabilityZoneRelocation { get; set; }
            public System.String ClusterIdentifier { get; set; }
            public System.String ClusterParameterGroupName { get; set; }
            public List<System.String> ClusterSecurityGroup { get; set; }
            public System.String ClusterType { get; set; }
            public System.String ClusterVersion { get; set; }
            public System.String ElasticIp { get; set; }
            public System.Boolean? Encrypted { get; set; }
            public System.Boolean? EnhancedVpcRouting { get; set; }
            public System.String HsmClientCertificateIdentifier { get; set; }
            public System.String HsmConfigurationIdentifier { get; set; }
            public System.String IpAddressType { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String MaintenanceTrackName { get; set; }
            public System.Boolean? ManageMasterPassword { get; set; }
            public System.Int32? ManualSnapshotRetentionPeriod { get; set; }
            public System.String MasterPasswordSecretKmsKeyId { get; set; }
            public System.String MasterUserPassword { get; set; }
            public System.Boolean? MultiAZ { get; set; }
            public System.String NewClusterIdentifier { get; set; }
            public System.String NodeType { get; set; }
            public System.Int32? NumberOfNodes { get; set; }
            public System.Int32? Port { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public List<System.String> VpcSecurityGroupId { get; set; }
            public System.Func<Amazon.Redshift.Model.ModifyClusterResponse, EditRSClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Cluster;
        }
        
    }
}
