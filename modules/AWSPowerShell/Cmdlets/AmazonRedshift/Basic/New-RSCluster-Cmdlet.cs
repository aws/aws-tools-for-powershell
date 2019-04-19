/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates a new cluster.
    /// 
    ///  
    /// <para>
    /// To create a cluster in Virtual Private Cloud (VPC), you must provide a cluster subnet
    /// group name. The cluster subnet group identifies the subnets of your VPC that Amazon
    /// Redshift uses when creating the cluster. For more information about managing clusters,
    /// go to <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/working-with-clusters.html">Amazon
    /// Redshift Clusters</a> in the <i>Amazon Redshift Cluster Management Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "RSCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.Cluster")]
    [AWSCmdlet("Calls the Amazon Redshift CreateCluster API operation.", Operation = new[] {"CreateCluster"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.Cluster",
        "This cmdlet returns a Cluster object.",
        "The service call response (type Amazon.Redshift.Model.CreateClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewRSClusterCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter AdditionalInfo
        /// <summary>
        /// <para>
        /// <para>Reserved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AdditionalInfo { get; set; }
        #endregion
        
        #region Parameter AllowVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>If <code>true</code>, major version upgrades can be applied during the maintenance
        /// window to the Amazon Redshift engine that is running on the cluster.</para><para>When a new major version of the Amazon Redshift engine is released, you can request
        /// that the service automatically apply upgrades during the maintenance window to the
        /// Amazon Redshift engine that is running on your cluster.</para><para>Default: <code>true</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AllowVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter AutomatedSnapshotRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days that automated snapshots are retained. If the value is 0, automated
        /// snapshots are disabled. Even if automated snapshots are disabled, you can still create
        /// manual snapshots when you want with <a>CreateClusterSnapshot</a>. </para><para>Default: <code>1</code></para><para>Constraints: Must be a value from 0 to 35.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 AutomatedSnapshotRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The EC2 Availability Zone (AZ) in which you want Amazon Redshift to provision the
        /// cluster. For example, if you have several EC2 instances running in a specific Availability
        /// Zone, then you might want the cluster to be provisioned in the same zone in order
        /// to decrease network latency.</para><para>Default: A random, system-chosen Availability Zone in the region that is specified
        /// by the endpoint.</para><para>Example: <code>us-east-1d</code></para><para>Constraint: The specified Availability Zone must be in the same region as the current
        /// endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the cluster. You use this identifier to refer to the cluster
        /// for any subsequent cluster operations such as deleting or modifying. The identifier
        /// also appears in the Amazon Redshift console.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 alphanumeric characters or hyphens.</para></li><li><para>Alphabetic characters must be lowercase.</para></li><li><para>First character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li><li><para>Must be unique for all clusters within an AWS account.</para></li></ul><para>Example: <code>myexamplecluster</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter ClusterParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the parameter group to be associated with this cluster.</para><para>Default: The default Amazon Redshift cluster parameter group. For information about
        /// the default parameter group, go to <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/working-with-parameter-groups.html">Working
        /// with Amazon Redshift Parameter Groups</a></para><para>Constraints:</para><ul><li><para>Must be 1 to 255 alphanumeric characters or hyphens.</para></li><li><para>First character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClusterParameterGroupName { get; set; }
        #endregion
        
        #region Parameter ClusterSecurityGroup
        /// <summary>
        /// <para>
        /// <para>A list of security groups to be associated with this cluster.</para><para>Default: The default cluster security group for Amazon Redshift.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ClusterSecurityGroups")]
        public System.String[] ClusterSecurityGroup { get; set; }
        #endregion
        
        #region Parameter ClusterSubnetGroupName
        /// <summary>
        /// <para>
        /// <para>The name of a cluster subnet group to be associated with this cluster.</para><para>If this parameter is not provided the resulting cluster will be deployed outside virtual
        /// private cloud (VPC).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClusterSubnetGroupName { get; set; }
        #endregion
        
        #region Parameter ClusterType
        /// <summary>
        /// <para>
        /// <para>The type of the cluster. When cluster type is specified as</para><ul><li><para><code>single-node</code>, the <b>NumberOfNodes</b> parameter is not required.</para></li><li><para><code>multi-node</code>, the <b>NumberOfNodes</b> parameter is required.</para></li></ul><para>Valid Values: <code>multi-node</code> | <code>single-node</code></para><para>Default: <code>multi-node</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String ClusterType { get; set; }
        #endregion
        
        #region Parameter ClusterVersion
        /// <summary>
        /// <para>
        /// <para>The version of the Amazon Redshift engine software that you want to deploy on the
        /// cluster.</para><para>The version selected runs on all the nodes in the cluster.</para><para>Constraints: Only version 1.0 is currently available.</para><para>Example: <code>1.0</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClusterVersion { get; set; }
        #endregion
        
        #region Parameter DBName
        /// <summary>
        /// <para>
        /// <para>The name of the first database to be created when the cluster is created.</para><para>To create additional databases after the cluster is created, connect to the cluster
        /// with a SQL client and use SQL commands to create a database. For more information,
        /// go to <a href="https://docs.aws.amazon.com/redshift/latest/dg/t_creating_database.html">Create
        /// a Database</a> in the Amazon Redshift Database Developer Guide. </para><para>Default: <code>dev</code></para><para>Constraints:</para><ul><li><para>Must contain 1 to 64 alphanumeric characters.</para></li><li><para>Must contain only lowercase letters.</para></li><li><para>Cannot be a word that is reserved by the service. A list of reserved words can be
        /// found in <a href="https://docs.aws.amazon.com/redshift/latest/dg/r_pg_keywords.html">Reserved
        /// Words</a> in the Amazon Redshift Database Developer Guide. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DBName { get; set; }
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
        [System.Management.Automation.Parameter]
        public System.String ElasticIp { get; set; }
        #endregion
        
        #region Parameter Encrypted
        /// <summary>
        /// <para>
        /// <para>If <code>true</code>, the data in the cluster is encrypted at rest. </para><para>Default: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Encrypted { get; set; }
        #endregion
        
        #region Parameter EnhancedVpcRouting
        /// <summary>
        /// <para>
        /// <para>An option that specifies whether to create the cluster with enhanced VPC routing enabled.
        /// To create a cluster that uses enhanced VPC routing, the cluster must be in a VPC.
        /// For more information, see <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/enhanced-vpc-routing.html">Enhanced
        /// VPC Routing</a> in the Amazon Redshift Cluster Management Guide.</para><para>If this option is <code>true</code>, enhanced VPC routing is enabled. </para><para>Default: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EnhancedVpcRouting { get; set; }
        #endregion
        
        #region Parameter HsmClientCertificateIdentifier
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the HSM client certificate the Amazon Redshift cluster uses
        /// to retrieve the data encryption keys stored in an HSM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        /// <para>A list of AWS Identity and Access Management (IAM) roles that can be used by the cluster
        /// to access other AWS services. You must supply the IAM roles in their Amazon Resource
        /// Name (ARN) format. You can supply up to 10 IAM roles in a single request.</para><para>A cluster can have up to 10 IAM roles associated with it at any time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IamRoles")]
        public System.String[] IamRole { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The AWS Key Management Service (KMS) key ID of the encryption key that you want to
        /// use to encrypt data in the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter MaintenanceTrackName
        /// <summary>
        /// <para>
        /// <para>An optional parameter for the name of the maintenance track for the cluster. If you
        /// don't provide a maintenance track name, the cluster is assigned to the <code>current</code>
        /// track.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MaintenanceTrackName { get; set; }
        #endregion
        
        #region Parameter ManualSnapshotRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The default number of days to retain a manual snapshot. If the value is -1, the snapshot
        /// is retained indefinitely. This setting doesn't change the retention period of existing
        /// snapshots.</para><para>The value must be either -1 or an integer between 1 and 3,653.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ManualSnapshotRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter MasterUsername
        /// <summary>
        /// <para>
        /// <para>The user name associated with the master user account for the cluster that is being
        /// created.</para><para>Constraints:</para><ul><li><para>Must be 1 - 128 alphanumeric characters. The user name can't be <code>PUBLIC</code>.</para></li><li><para>First character must be a letter.</para></li><li><para>Cannot be a reserved word. A list of reserved words can be found in <a href="https://docs.aws.amazon.com/redshift/latest/dg/r_pg_keywords.html">Reserved
        /// Words</a> in the Amazon Redshift Database Developer Guide. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MasterUsername { get; set; }
        #endregion
        
        #region Parameter MasterUserPassword
        /// <summary>
        /// <para>
        /// <para>The password associated with the master user account for the cluster that is being
        /// created.</para><para>Constraints:</para><ul><li><para>Must be between 8 and 64 characters in length.</para></li><li><para>Must contain at least one uppercase letter.</para></li><li><para>Must contain at least one lowercase letter.</para></li><li><para>Must contain one number.</para></li><li><para>Can be any printable ASCII character (ASCII code 33 to 126) except ' (single quote),
        /// " (double quote), \, /, @, or space.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MasterUserPassword { get; set; }
        #endregion
        
        #region Parameter NodeType
        /// <summary>
        /// <para>
        /// <para>The node type to be provisioned for the cluster. For information about node types,
        /// go to <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/working-with-clusters.html#how-many-nodes">
        /// Working with Clusters</a> in the <i>Amazon Redshift Cluster Management Guide</i>.
        /// </para><para>Valid Values: <code>ds2.xlarge</code> | <code>ds2.8xlarge</code> | <code>ds2.xlarge</code>
        /// | <code>ds2.8xlarge</code> | <code>dc1.large</code> | <code>dc1.8xlarge</code> | <code>dc2.large</code>
        /// | <code>dc2.8xlarge</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.String NodeType { get; set; }
        #endregion
        
        #region Parameter NumberOfNodes
        /// <summary>
        /// <para>
        /// <para>The number of compute nodes in the cluster. This parameter is required when the <b>ClusterType</b>
        /// parameter is specified as <code>multi-node</code>. </para><para>For information about determining how many nodes you need, go to <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/working-with-clusters.html#how-many-nodes">
        /// Working with Clusters</a> in the <i>Amazon Redshift Cluster Management Guide</i>.
        /// </para><para>If you don't specify this parameter, you get a single-node cluster. When requesting
        /// a multi-node cluster, you must specify the number of nodes that you want in the cluster.</para><para>Default: <code>1</code></para><para>Constraints: Value must be at least 1 and no more than 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 NumberOfNodes { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port number on which the cluster accepts incoming connections.</para><para>The cluster is accessible only via the JDBC and ODBC connection strings. Part of the
        /// connection string requires the port on which the cluster will listen for incoming
        /// connections.</para><para>Default: <code>5439</code></para><para>Valid Values: <code>1150-65535</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Port { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>The weekly time range (in UTC) during which automated cluster maintenance can occur.</para><para> Format: <code>ddd:hh24:mi-ddd:hh24:mi</code></para><para> Default: A 30-minute window selected at random from an 8-hour block of time per region,
        /// occurring on a random day of the week. For more information about the time blocks
        /// for each region, see <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/working-with-clusters.html#rs-maintenance-windows">Maintenance
        /// Windows</a> in Amazon Redshift Cluster Management Guide.</para><para>Valid Days: Mon | Tue | Wed | Thu | Fri | Sat | Sun</para><para>Constraints: Minimum 30-minute window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>If <code>true</code>, the cluster can be accessed from a public network. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter SnapshotScheduleIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the snapshot schedule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SnapshotScheduleIdentifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tag instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.Redshift.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of Virtual Private Cloud (VPC) security groups to be associated with the cluster.</para><para>Default: The default VPC security group is associated with the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DBName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RSCluster (CreateCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AdditionalInfo = this.AdditionalInfo;
            if (ParameterWasBound("AllowVersionUpgrade"))
                context.AllowVersionUpgrade = this.AllowVersionUpgrade;
            if (ParameterWasBound("AutomatedSnapshotRetentionPeriod"))
                context.AutomatedSnapshotRetentionPeriod = this.AutomatedSnapshotRetentionPeriod;
            context.AvailabilityZone = this.AvailabilityZone;
            context.ClusterIdentifier = this.ClusterIdentifier;
            context.ClusterParameterGroupName = this.ClusterParameterGroupName;
            if (this.ClusterSecurityGroup != null)
            {
                context.ClusterSecurityGroups = new List<System.String>(this.ClusterSecurityGroup);
            }
            context.ClusterSubnetGroupName = this.ClusterSubnetGroupName;
            context.ClusterType = this.ClusterType;
            context.ClusterVersion = this.ClusterVersion;
            context.DBName = this.DBName;
            context.ElasticIp = this.ElasticIp;
            if (ParameterWasBound("Encrypted"))
                context.Encrypted = this.Encrypted;
            if (ParameterWasBound("EnhancedVpcRouting"))
                context.EnhancedVpcRouting = this.EnhancedVpcRouting;
            context.HsmClientCertificateIdentifier = this.HsmClientCertificateIdentifier;
            context.HsmConfigurationIdentifier = this.HsmConfigurationIdentifier;
            if (this.IamRole != null)
            {
                context.IamRoles = new List<System.String>(this.IamRole);
            }
            context.KmsKeyId = this.KmsKeyId;
            context.MaintenanceTrackName = this.MaintenanceTrackName;
            if (ParameterWasBound("ManualSnapshotRetentionPeriod"))
                context.ManualSnapshotRetentionPeriod = this.ManualSnapshotRetentionPeriod;
            context.MasterUsername = this.MasterUsername;
            context.MasterUserPassword = this.MasterUserPassword;
            context.NodeType = this.NodeType;
            if (ParameterWasBound("NumberOfNodes"))
                context.NumberOfNodes = this.NumberOfNodes;
            if (ParameterWasBound("Port"))
                context.Port = this.Port;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            if (ParameterWasBound("PubliclyAccessible"))
                context.PubliclyAccessible = this.PubliclyAccessible;
            context.SnapshotScheduleIdentifier = this.SnapshotScheduleIdentifier;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.Redshift.Model.Tag>(this.Tag);
            }
            if (this.VpcSecurityGroupId != null)
            {
                context.VpcSecurityGroupIds = new List<System.String>(this.VpcSecurityGroupId);
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
            var request = new Amazon.Redshift.Model.CreateClusterRequest();
            
            if (cmdletContext.AdditionalInfo != null)
            {
                request.AdditionalInfo = cmdletContext.AdditionalInfo;
            }
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
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.ClusterParameterGroupName != null)
            {
                request.ClusterParameterGroupName = cmdletContext.ClusterParameterGroupName;
            }
            if (cmdletContext.ClusterSecurityGroups != null)
            {
                request.ClusterSecurityGroups = cmdletContext.ClusterSecurityGroups;
            }
            if (cmdletContext.ClusterSubnetGroupName != null)
            {
                request.ClusterSubnetGroupName = cmdletContext.ClusterSubnetGroupName;
            }
            if (cmdletContext.ClusterType != null)
            {
                request.ClusterType = cmdletContext.ClusterType;
            }
            if (cmdletContext.ClusterVersion != null)
            {
                request.ClusterVersion = cmdletContext.ClusterVersion;
            }
            if (cmdletContext.DBName != null)
            {
                request.DBName = cmdletContext.DBName;
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
            if (cmdletContext.IamRoles != null)
            {
                request.IamRoles = cmdletContext.IamRoles;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.MaintenanceTrackName != null)
            {
                request.MaintenanceTrackName = cmdletContext.MaintenanceTrackName;
            }
            if (cmdletContext.ManualSnapshotRetentionPeriod != null)
            {
                request.ManualSnapshotRetentionPeriod = cmdletContext.ManualSnapshotRetentionPeriod.Value;
            }
            if (cmdletContext.MasterUsername != null)
            {
                request.MasterUsername = cmdletContext.MasterUsername;
            }
            if (cmdletContext.MasterUserPassword != null)
            {
                request.MasterUserPassword = cmdletContext.MasterUserPassword;
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
            if (cmdletContext.SnapshotScheduleIdentifier != null)
            {
                request.SnapshotScheduleIdentifier = cmdletContext.SnapshotScheduleIdentifier;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.VpcSecurityGroupIds != null)
            {
                request.VpcSecurityGroupIds = cmdletContext.VpcSecurityGroupIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Cluster;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.Redshift.Model.CreateClusterResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.CreateClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "CreateCluster");
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
            public System.String AdditionalInfo { get; set; }
            public System.Boolean? AllowVersionUpgrade { get; set; }
            public System.Int32? AutomatedSnapshotRetentionPeriod { get; set; }
            public System.String AvailabilityZone { get; set; }
            public System.String ClusterIdentifier { get; set; }
            public System.String ClusterParameterGroupName { get; set; }
            public List<System.String> ClusterSecurityGroups { get; set; }
            public System.String ClusterSubnetGroupName { get; set; }
            public System.String ClusterType { get; set; }
            public System.String ClusterVersion { get; set; }
            public System.String DBName { get; set; }
            public System.String ElasticIp { get; set; }
            public System.Boolean? Encrypted { get; set; }
            public System.Boolean? EnhancedVpcRouting { get; set; }
            public System.String HsmClientCertificateIdentifier { get; set; }
            public System.String HsmConfigurationIdentifier { get; set; }
            public List<System.String> IamRoles { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String MaintenanceTrackName { get; set; }
            public System.Int32? ManualSnapshotRetentionPeriod { get; set; }
            public System.String MasterUsername { get; set; }
            public System.String MasterUserPassword { get; set; }
            public System.String NodeType { get; set; }
            public System.Int32? NumberOfNodes { get; set; }
            public System.Int32? Port { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public System.String SnapshotScheduleIdentifier { get; set; }
            public List<Amazon.Redshift.Model.Tag> Tags { get; set; }
            public List<System.String> VpcSecurityGroupIds { get; set; }
        }
        
    }
}
