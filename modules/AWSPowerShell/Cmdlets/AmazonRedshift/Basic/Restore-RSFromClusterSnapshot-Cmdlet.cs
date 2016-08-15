/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    ///  If you restore a cluster into a VPC, you must provide a cluster subnet group where
    /// you want the cluster restored. 
    /// </para><para>
    ///  For more information about working with snapshots, go to <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/working-with-snapshots.html">Amazon
    /// Redshift Snapshots</a> in the <i>Amazon Redshift Cluster Management Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("Restore", "RSFromClusterSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.Cluster")]
    [AWSCmdlet("Invokes the RestoreFromClusterSnapshot operation against Amazon Redshift.", Operation = new[] {"RestoreFromClusterSnapshot"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.Cluster",
        "This cmdlet returns a Cluster object.",
        "The service call response (type Amazon.Redshift.Model.RestoreFromClusterSnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RestoreRSFromClusterSnapshotCmdlet : AmazonRedshiftClientCmdlet, IExecutor
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
        /// window to the Amazon Redshift engine that is running on the cluster. </para><para>Default: <code>true</code></para>
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
        /// manual snapshots when you want with <a>CreateClusterSnapshot</a>. </para><para> Default: The value selected for the cluster from which the snapshot was taken. </para><para>Constraints: Must be a value from 0 to 35.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 AutomatedSnapshotRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para> The Amazon EC2 Availability Zone in which to restore the cluster. </para><para>Default: A random, system-chosen Availability Zone.</para><para>Example: <code>us-east-1a</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para> The identifier of the cluster that will be created from restoring the snapshot. </para><para><para>Constraints:</para><ul><li>Must contain from 1 to 63 alphanumeric characters or hyphens.</li><li>Alphabetic
        /// characters must be lowercase.</li><li>First character must be a letter.</li><li>Cannot
        /// end with a hyphen or contain two consecutive hyphens.</li><li>Must be unique for
        /// all clusters within an AWS account.</li></ul></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter ClusterParameterGroupName
        /// <summary>
        /// <para>
        /// <para> The name of the parameter group to be associated with this cluster. </para><para>Default: The default Amazon Redshift cluster parameter group. For information about
        /// the default parameter group, go to <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/working-with-parameter-groups.html">Working
        /// with Amazon Redshift Parameter Groups</a>.</para><para> Constraints: </para><ul><li>Must be 1 to 255 alphanumeric characters or hyphens.</li><li>First character
        /// must be a letter.</li><li>Cannot end with a hyphen or contain two consecutive hyphens.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClusterParameterGroupName { get; set; }
        #endregion
        
        #region Parameter ClusterSecurityGroup
        /// <summary>
        /// <para>
        /// <para> A list of security groups to be associated with this cluster. </para><para> Default: The default cluster security group for Amazon Redshift. </para><para>Cluster security groups only apply to clusters outside of VPCs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ClusterSecurityGroups")]
        public System.String[] ClusterSecurityGroup { get; set; }
        #endregion
        
        #region Parameter ClusterSubnetGroupName
        /// <summary>
        /// <para>
        /// <para> The name of the subnet group where you want to cluster restored. </para><para> A snapshot of cluster in VPC can be restored only in VPC. Therefore, you must provide
        /// subnet group name where you want the cluster restored. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClusterSubnetGroupName { get; set; }
        #endregion
        
        #region Parameter ElasticIp
        /// <summary>
        /// <para>
        /// <para>The elastic IP (EIP) address for the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ElasticIp { get; set; }
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
        /// Name (ARN) format. You can supply up to 10 IAM roles in a single request.</para><para>A cluster can have up to 10 IAM roles associated at any time. </para>
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
        /// use to encrypt data in the cluster that you restore from a shared snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter NodeType
        /// <summary>
        /// <para>
        /// <para> The node type that the restored cluster will be provisioned with.</para><para> Default: The node type of the cluster from which the snapshot was taken. You can
        /// modify this if you are using any DS node type. In that case, you can choose to restore
        /// into another DS node type of the same size. For example, you can restore ds1.8xlarge
        /// into ds2.8xlarge, or ds2.xlarge into ds1.xlarge. If you have a DC instance type, you
        /// must restore into that same instance type and size. In other words, you can only restore
        /// a dc1.large instance type into another dc1.large instance type. For more information
        /// about node types, see <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/working-with-clusters.html#rs-about-clusters-and-nodes">
        /// About Clusters and Nodes</a> in the <i>Amazon Redshift Cluster Management Guide</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NodeType { get; set; }
        #endregion
        
        #region Parameter OwnerAccount
        /// <summary>
        /// <para>
        /// <para> The AWS customer account used to create or copy the snapshot. Required if you are
        /// restoring a snapshot you do not own, optional if you own the snapshot. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OwnerAccount { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para> The port number on which the cluster accepts connections. </para><para>Default: The same port as the original cluster.</para><para>Constraints: Must be between <code>1115</code> and <code>65535</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Port { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para> The weekly time range (in UTC) during which automated cluster maintenance can occur.
        /// </para><para> Format: <code>ddd:hh24:mi-ddd:hh24:mi</code></para><para> Default: The value selected for the cluster from which the snapshot was taken. For
        /// more information about the time blocks for each region, see <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/working-with-clusters.html#rs-maintenance-windows">Maintenance
        /// Windows</a> in Amazon Redshift Cluster Management Guide. </para><para>Valid Days: Mon | Tue | Wed | Thu | Fri | Sat | Sun</para><para>Constraints: Minimum 30-minute window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para> If <code>true</code>, the cluster can be accessed from a public network. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter SnapshotClusterIdentifier
        /// <summary>
        /// <para>
        /// <para> The name of the cluster the source snapshot was created from. This parameter is required
        /// if your IAM user has a policy containing a snapshot resource element that specifies
        /// anything other than * for the cluster name. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SnapshotClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter SnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para> The name of the snapshot from which to create the new cluster. This parameter isn't
        /// case sensitive. </para><para>Example: <code>my-snapshot-id</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para> A list of Virtual Private Cloud (VPC) security groups to be associated with the cluster.
        /// </para><para> Default: The default VPC security group is associated with the cluster. </para><para> VPC security groups only apply to clusters in VPCs. </para>
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SnapshotIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-RSFromClusterSnapshot (RestoreFromClusterSnapshot)"))
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
            context.ElasticIp = this.ElasticIp;
            context.HsmClientCertificateIdentifier = this.HsmClientCertificateIdentifier;
            context.HsmConfigurationIdentifier = this.HsmConfigurationIdentifier;
            if (this.IamRole != null)
            {
                context.IamRoles = new List<System.String>(this.IamRole);
            }
            context.KmsKeyId = this.KmsKeyId;
            context.NodeType = this.NodeType;
            context.OwnerAccount = this.OwnerAccount;
            if (ParameterWasBound("Port"))
                context.Port = this.Port;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            if (ParameterWasBound("PubliclyAccessible"))
                context.PubliclyAccessible = this.PubliclyAccessible;
            context.SnapshotClusterIdentifier = this.SnapshotClusterIdentifier;
            context.SnapshotIdentifier = this.SnapshotIdentifier;
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
            var request = new Amazon.Redshift.Model.RestoreFromClusterSnapshotRequest();
            
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
            if (cmdletContext.ElasticIp != null)
            {
                request.ElasticIp = cmdletContext.ElasticIp;
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
            if (cmdletContext.NodeType != null)
            {
                request.NodeType = cmdletContext.NodeType;
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
            if (cmdletContext.SnapshotClusterIdentifier != null)
            {
                request.SnapshotClusterIdentifier = cmdletContext.SnapshotClusterIdentifier;
            }
            if (cmdletContext.SnapshotIdentifier != null)
            {
                request.SnapshotIdentifier = cmdletContext.SnapshotIdentifier;
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
        
        private static Amazon.Redshift.Model.RestoreFromClusterSnapshotResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.RestoreFromClusterSnapshotRequest request)
        {
            #if DESKTOP
            return client.RestoreFromClusterSnapshot(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.RestoreFromClusterSnapshotAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AdditionalInfo { get; set; }
            public System.Boolean? AllowVersionUpgrade { get; set; }
            public System.Int32? AutomatedSnapshotRetentionPeriod { get; set; }
            public System.String AvailabilityZone { get; set; }
            public System.String ClusterIdentifier { get; set; }
            public System.String ClusterParameterGroupName { get; set; }
            public List<System.String> ClusterSecurityGroups { get; set; }
            public System.String ClusterSubnetGroupName { get; set; }
            public System.String ElasticIp { get; set; }
            public System.String HsmClientCertificateIdentifier { get; set; }
            public System.String HsmConfigurationIdentifier { get; set; }
            public List<System.String> IamRoles { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String NodeType { get; set; }
            public System.String OwnerAccount { get; set; }
            public System.Int32? Port { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public System.String SnapshotClusterIdentifier { get; set; }
            public System.String SnapshotIdentifier { get; set; }
            public List<System.String> VpcSecurityGroupIds { get; set; }
        }
        
    }
}
