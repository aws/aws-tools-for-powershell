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
using Amazon.Redshift;
using Amazon.Redshift.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Creates a new cluster from a snapshot. By default, Amazon Redshift creates the resulting
    /// cluster with the same configuration as the original cluster from which the snapshot
    /// was created, except that the new cluster is created with the default cluster security
    /// and parameter groups. After Amazon Redshift creates the cluster, you can use the <a>ModifyCluster</a>
    /// API to associate a different security group and different parameter group with the
    /// restored cluster. If you are using a DS node type, you can also choose to change to
    /// another DS node type of the same size during restore.
    /// 
    ///  
    /// <para>
    /// If you restore a cluster into a VPC, you must provide a cluster subnet group where
    /// you want the cluster restored.
    /// </para><para>
    /// VPC Block Public Access (BPA) enables you to block resources in VPCs and subnets that
    /// you own in a Region from reaching or being reached from the internet through internet
    /// gateways and egress-only internet gateways. If a subnet group for a provisioned cluster
    /// is in an account with VPC BPA turned on, the following capabilities are blocked:
    /// </para><ul><li><para>
    /// Creating a public cluster
    /// </para></li><li><para>
    /// Restoring a public cluster
    /// </para></li><li><para>
    /// Modifying a private cluster to be public
    /// </para></li><li><para>
    /// Adding a subnet with VPC BPA turned on to the subnet group when there's at least one
    /// public cluster within the group
    /// </para></li></ul><para>
    /// For more information about VPC BPA, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/security-vpc-bpa.html">Block
    /// public access to VPCs and subnets</a> in the <i>Amazon VPC User Guide</i>.
    /// </para><para>
    ///  For more information about working with snapshots, go to <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/working-with-snapshots.html">Amazon
    /// Redshift Snapshots</a> in the <i>Amazon Redshift Cluster Management Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Restore", "RSFromClusterSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.Cluster")]
    [AWSCmdlet("Calls the Amazon Redshift RestoreFromClusterSnapshot API operation.", Operation = new[] {"RestoreFromClusterSnapshot"}, SelectReturnType = typeof(Amazon.Redshift.Model.RestoreFromClusterSnapshotResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.Cluster or Amazon.Redshift.Model.RestoreFromClusterSnapshotResponse",
        "This cmdlet returns an Amazon.Redshift.Model.Cluster object.",
        "The service call response (type Amazon.Redshift.Model.RestoreFromClusterSnapshotResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RestoreRSFromClusterSnapshotCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AdditionalInfo
        /// <summary>
        /// <para>
        /// <para>Reserved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalInfo { get; set; }
        #endregion
        
        #region Parameter AllowVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>If <c>true</c>, major version upgrades can be applied during the maintenance window
        /// to the Amazon Redshift engine that is running on the cluster. </para><para>Default: <c>true</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter AquaConfigurationStatus
        /// <summary>
        /// <para>
        /// <para>This parameter is retired. It does not set the AQUA configuration status. Amazon Redshift
        /// automatically determines whether to use AQUA (Advanced Query Accelerator).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Redshift.AquaConfigurationStatus")]
        public Amazon.Redshift.AquaConfigurationStatus AquaConfigurationStatus { get; set; }
        #endregion
        
        #region Parameter AutomatedSnapshotRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days that automated snapshots are retained. If the value is 0, automated
        /// snapshots are disabled. Even if automated snapshots are disabled, you can still create
        /// manual snapshots when you want with <a>CreateClusterSnapshot</a>. </para><para>You can't disable automated snapshots for RA3 node types. Set the automated retention
        /// period from 1-35 days.</para><para>Default: The value selected for the cluster from which the snapshot was taken.</para><para>Constraints: Must be a value from 0 to 35.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AutomatedSnapshotRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 Availability Zone in which to restore the cluster.</para><para>Default: A random, system-chosen Availability Zone.</para><para>Example: <c>us-east-2a</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter AvailabilityZoneRelocation
        /// <summary>
        /// <para>
        /// <para>The option to enable relocation for an Amazon Redshift cluster between Availability
        /// Zones after the cluster is restored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AvailabilityZoneRelocation { get; set; }
        #endregion
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the cluster that will be created from restoring the snapshot.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 alphanumeric characters or hyphens.</para></li><li><para>Alphabetic characters must be lowercase.</para></li><li><para>First character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li><li><para>Must be unique for all clusters within an Amazon Web Services account.</para></li></ul>
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
        /// <para>The name of the parameter group to be associated with this cluster.</para><para>Default: The default Amazon Redshift cluster parameter group. For information about
        /// the default parameter group, go to <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/working-with-parameter-groups.html">Working
        /// with Amazon Redshift Parameter Groups</a>.</para><para>Constraints:</para><ul><li><para>Must be 1 to 255 alphanumeric characters or hyphens.</para></li><li><para>First character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClusterParameterGroupName { get; set; }
        #endregion
        
        #region Parameter ClusterSecurityGroup
        /// <summary>
        /// <para>
        /// <para>A list of security groups to be associated with this cluster.</para><para>Default: The default cluster security group for Amazon Redshift.</para><para>Cluster security groups only apply to clusters outside of VPCs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ClusterSecurityGroups")]
        public System.String[] ClusterSecurityGroup { get; set; }
        #endregion
        
        #region Parameter ClusterSubnetGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the subnet group where you want to cluster restored.</para><para>A snapshot of cluster in VPC can be restored only in VPC. Therefore, you must provide
        /// subnet group name where you want the cluster restored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClusterSubnetGroupName { get; set; }
        #endregion
        
        #region Parameter DefaultIamRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the IAM role that was set as default for the cluster
        /// when the cluster was last modified while it was restored from a snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultIamRoleArn { get; set; }
        #endregion
        
        #region Parameter ElasticIp
        /// <summary>
        /// <para>
        /// <para>The Elastic IP (EIP) address for the cluster. Don't specify the Elastic IP address
        /// for a publicly accessible cluster with availability zone relocation turned on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ElasticIp { get; set; }
        #endregion
        
        #region Parameter Encrypted
        /// <summary>
        /// <para>
        /// <para>Enables support for restoring an unencrypted snapshot to a cluster encrypted with
        /// Key Management Service (KMS) and a customer managed key.</para>
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
        
        #region Parameter IamRole
        /// <summary>
        /// <para>
        /// <para>A list of Identity and Access Management (IAM) roles that can be used by the cluster
        /// to access other Amazon Web Services services. You must supply the IAM roles in their
        /// Amazon Resource Name (ARN) format. </para><para>The maximum number of IAM roles that you can associate is subject to a quota. For
        /// more information, go to <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/amazon-redshift-limits.html">Quotas
        /// and limits</a> in the <i>Amazon Redshift Cluster Management Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IamRoles")]
        public System.String[] IamRole { get; set; }
        #endregion
        
        #region Parameter IpAddressType
        /// <summary>
        /// <para>
        /// <para>The IP address type for the cluster. Possible values are <c>ipv4</c> and <c>dualstack</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IpAddressType { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Key Management Service (KMS) key ID of the encryption key that encrypts data in
        /// the cluster restored from a shared snapshot. You can also provide the key ID when
        /// you restore from an unencrypted snapshot to an encrypted cluster in the same account.
        /// Additionally, you can specify a new KMS key ID when you restore from an encrypted
        /// snapshot in the same account in order to change it. In that case, the restored cluster
        /// is encrypted with the new KMS key ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter MaintenanceTrackName
        /// <summary>
        /// <para>
        /// <para>The name of the maintenance track for the restored cluster. When you take a snapshot,
        /// the snapshot inherits the <c>MaintenanceTrack</c> value from the cluster. The snapshot
        /// might be on a different track than the cluster that was the source for the snapshot.
        /// For example, suppose that you take a snapshot of a cluster that is on the current
        /// track and then change the cluster to be on the trailing track. In this case, the snapshot
        /// and the source cluster are on different tracks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaintenanceTrackName { get; set; }
        #endregion
        
        #region Parameter ManageMasterPassword
        /// <summary>
        /// <para>
        /// <para>If <c>true</c>, Amazon Redshift uses Secrets Manager to manage the restored cluster's
        /// admin credentials. If <c>ManageMasterPassword</c> is false or not set, Amazon Redshift
        /// uses the admin credentials the cluster had at the time the snapshot was taken.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ManageMasterPassword { get; set; }
        #endregion
        
        #region Parameter ManualSnapshotRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The default number of days to retain a manual snapshot. If the value is -1, the snapshot
        /// is retained indefinitely. This setting doesn't change the retention period of existing
        /// snapshots.</para><para>The value must be either -1 or an integer between 1 and 3,653.</para>
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
        
        #region Parameter MultiAZ
        /// <summary>
        /// <para>
        /// <para>If true, the snapshot will be restored to a cluster deployed in two Availability Zones.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MultiAZ { get; set; }
        #endregion
        
        #region Parameter NodeType
        /// <summary>
        /// <para>
        /// <para>The node type that the restored cluster will be provisioned with.</para><para>If you have a DC instance type, you must restore into that same instance type and
        /// size. In other words, you can only restore a dc2.large node type into another dc2
        /// type. For more information about node types, see <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/working-with-clusters.html#rs-about-clusters-and-nodes">
        /// About Clusters and Nodes</a> in the <i>Amazon Redshift Cluster Management Guide</i>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NodeType { get; set; }
        #endregion
        
        #region Parameter NumberOfNode
        /// <summary>
        /// <para>
        /// <para>The number of nodes specified when provisioning the restored cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NumberOfNodes")]
        public System.Int32? NumberOfNode { get; set; }
        #endregion
        
        #region Parameter OwnerAccount
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account used to create or copy the snapshot. Required if you
        /// are restoring a snapshot you do not own, optional if you own the snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OwnerAccount { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port number on which the cluster accepts connections.</para><para>Default: The same port as the original cluster.</para><para>Valid values: For clusters with DC2 nodes, must be within the range <c>1150</c>-<c>65535</c>.
        /// For clusters with ra3 nodes, must be within the ranges <c>5431</c>-<c>5455</c> or
        /// <c>8191</c>-<c>8215</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>The weekly time range (in UTC) during which automated cluster maintenance can occur.</para><para> Format: <c>ddd:hh24:mi-ddd:hh24:mi</c></para><para> Default: The value selected for the cluster from which the snapshot was taken. For
        /// more information about the time blocks for each region, see <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/working-with-clusters.html#rs-maintenance-windows">Maintenance
        /// Windows</a> in Amazon Redshift Cluster Management Guide. </para><para>Valid Days: Mon | Tue | Wed | Thu | Fri | Sat | Sun</para><para>Constraints: Minimum 30-minute window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>If <c>true</c>, the cluster can be accessed from a public network. </para><para>Default: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter ReservedNodeId
        /// <summary>
        /// <para>
        /// <para>The identifier of the target reserved node offering.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReservedNodeId { get; set; }
        #endregion
        
        #region Parameter SnapshotArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the snapshot associated with the message to restore
        /// from a cluster. You must specify this parameter or <c>snapshotIdentifier</c>, but
        /// not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotArn { get; set; }
        #endregion
        
        #region Parameter SnapshotClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The name of the cluster the source snapshot was created from. This parameter is required
        /// if your IAM user has a policy containing a snapshot resource element that specifies
        /// anything other than * for the cluster name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter SnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The name of the snapshot from which to create the new cluster. This parameter isn't
        /// case sensitive. You must specify this parameter or <c>snapshotArn</c>, but not both.</para><para>Example: <c>my-snapshot-id</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter SnapshotScheduleIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the snapshot schedule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotScheduleIdentifier { get; set; }
        #endregion
        
        #region Parameter TargetReservedNodeOfferingId
        /// <summary>
        /// <para>
        /// <para>The identifier of the target reserved node offering.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetReservedNodeOfferingId { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of Virtual Private Cloud (VPC) security groups to be associated with the cluster.</para><para>Default: The default VPC security group is associated with the cluster.</para><para>VPC security groups only apply to clusters in VPCs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Cluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.RestoreFromClusterSnapshotResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.RestoreFromClusterSnapshotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Cluster";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SnapshotIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-RSFromClusterSnapshot (RestoreFromClusterSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.RestoreFromClusterSnapshotResponse, RestoreRSFromClusterSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AdditionalInfo = this.AdditionalInfo;
            context.AllowVersionUpgrade = this.AllowVersionUpgrade;
            context.AquaConfigurationStatus = this.AquaConfigurationStatus;
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
            context.ClusterSubnetGroupName = this.ClusterSubnetGroupName;
            context.DefaultIamRoleArn = this.DefaultIamRoleArn;
            context.ElasticIp = this.ElasticIp;
            context.Encrypted = this.Encrypted;
            context.EnhancedVpcRouting = this.EnhancedVpcRouting;
            context.HsmClientCertificateIdentifier = this.HsmClientCertificateIdentifier;
            context.HsmConfigurationIdentifier = this.HsmConfigurationIdentifier;
            if (this.IamRole != null)
            {
                context.IamRole = new List<System.String>(this.IamRole);
            }
            context.IpAddressType = this.IpAddressType;
            context.KmsKeyId = this.KmsKeyId;
            context.MaintenanceTrackName = this.MaintenanceTrackName;
            context.ManageMasterPassword = this.ManageMasterPassword;
            context.ManualSnapshotRetentionPeriod = this.ManualSnapshotRetentionPeriod;
            context.MasterPasswordSecretKmsKeyId = this.MasterPasswordSecretKmsKeyId;
            context.MultiAZ = this.MultiAZ;
            context.NodeType = this.NodeType;
            context.NumberOfNode = this.NumberOfNode;
            context.OwnerAccount = this.OwnerAccount;
            context.Port = this.Port;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            context.PubliclyAccessible = this.PubliclyAccessible;
            context.ReservedNodeId = this.ReservedNodeId;
            context.SnapshotArn = this.SnapshotArn;
            context.SnapshotClusterIdentifier = this.SnapshotClusterIdentifier;
            context.SnapshotIdentifier = this.SnapshotIdentifier;
            context.SnapshotScheduleIdentifier = this.SnapshotScheduleIdentifier;
            context.TargetReservedNodeOfferingId = this.TargetReservedNodeOfferingId;
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
            var request = new Amazon.Redshift.Model.RestoreFromClusterSnapshotRequest();
            
            if (cmdletContext.AdditionalInfo != null)
            {
                request.AdditionalInfo = cmdletContext.AdditionalInfo;
            }
            if (cmdletContext.AllowVersionUpgrade != null)
            {
                request.AllowVersionUpgrade = cmdletContext.AllowVersionUpgrade.Value;
            }
            if (cmdletContext.AquaConfigurationStatus != null)
            {
                request.AquaConfigurationStatus = cmdletContext.AquaConfigurationStatus;
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
            if (cmdletContext.ClusterSubnetGroupName != null)
            {
                request.ClusterSubnetGroupName = cmdletContext.ClusterSubnetGroupName;
            }
            if (cmdletContext.DefaultIamRoleArn != null)
            {
                request.DefaultIamRoleArn = cmdletContext.DefaultIamRoleArn;
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
            if (cmdletContext.IamRole != null)
            {
                request.IamRoles = cmdletContext.IamRole;
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
            if (cmdletContext.MultiAZ != null)
            {
                request.MultiAZ = cmdletContext.MultiAZ.Value;
            }
            if (cmdletContext.NodeType != null)
            {
                request.NodeType = cmdletContext.NodeType;
            }
            if (cmdletContext.NumberOfNode != null)
            {
                request.NumberOfNodes = cmdletContext.NumberOfNode.Value;
            }
            if (cmdletContext.OwnerAccount != null)
            {
                request.OwnerAccount = cmdletContext.OwnerAccount;
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
            if (cmdletContext.ReservedNodeId != null)
            {
                request.ReservedNodeId = cmdletContext.ReservedNodeId;
            }
            if (cmdletContext.SnapshotArn != null)
            {
                request.SnapshotArn = cmdletContext.SnapshotArn;
            }
            if (cmdletContext.SnapshotClusterIdentifier != null)
            {
                request.SnapshotClusterIdentifier = cmdletContext.SnapshotClusterIdentifier;
            }
            if (cmdletContext.SnapshotIdentifier != null)
            {
                request.SnapshotIdentifier = cmdletContext.SnapshotIdentifier;
            }
            if (cmdletContext.SnapshotScheduleIdentifier != null)
            {
                request.SnapshotScheduleIdentifier = cmdletContext.SnapshotScheduleIdentifier;
            }
            if (cmdletContext.TargetReservedNodeOfferingId != null)
            {
                request.TargetReservedNodeOfferingId = cmdletContext.TargetReservedNodeOfferingId;
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
        
        private Amazon.Redshift.Model.RestoreFromClusterSnapshotResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.RestoreFromClusterSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "RestoreFromClusterSnapshot");
            try
            {
                return client.RestoreFromClusterSnapshotAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AdditionalInfo { get; set; }
            public System.Boolean? AllowVersionUpgrade { get; set; }
            public Amazon.Redshift.AquaConfigurationStatus AquaConfigurationStatus { get; set; }
            public System.Int32? AutomatedSnapshotRetentionPeriod { get; set; }
            public System.String AvailabilityZone { get; set; }
            public System.Boolean? AvailabilityZoneRelocation { get; set; }
            public System.String ClusterIdentifier { get; set; }
            public System.String ClusterParameterGroupName { get; set; }
            public List<System.String> ClusterSecurityGroup { get; set; }
            public System.String ClusterSubnetGroupName { get; set; }
            public System.String DefaultIamRoleArn { get; set; }
            public System.String ElasticIp { get; set; }
            public System.Boolean? Encrypted { get; set; }
            public System.Boolean? EnhancedVpcRouting { get; set; }
            public System.String HsmClientCertificateIdentifier { get; set; }
            public System.String HsmConfigurationIdentifier { get; set; }
            public List<System.String> IamRole { get; set; }
            public System.String IpAddressType { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String MaintenanceTrackName { get; set; }
            public System.Boolean? ManageMasterPassword { get; set; }
            public System.Int32? ManualSnapshotRetentionPeriod { get; set; }
            public System.String MasterPasswordSecretKmsKeyId { get; set; }
            public System.Boolean? MultiAZ { get; set; }
            public System.String NodeType { get; set; }
            public System.Int32? NumberOfNode { get; set; }
            public System.String OwnerAccount { get; set; }
            public System.Int32? Port { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public System.String ReservedNodeId { get; set; }
            public System.String SnapshotArn { get; set; }
            public System.String SnapshotClusterIdentifier { get; set; }
            public System.String SnapshotIdentifier { get; set; }
            public System.String SnapshotScheduleIdentifier { get; set; }
            public System.String TargetReservedNodeOfferingId { get; set; }
            public List<System.String> VpcSecurityGroupId { get; set; }
            public System.Func<Amazon.Redshift.Model.RestoreFromClusterSnapshotResponse, RestoreRSFromClusterSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Cluster;
        }
        
    }
}
