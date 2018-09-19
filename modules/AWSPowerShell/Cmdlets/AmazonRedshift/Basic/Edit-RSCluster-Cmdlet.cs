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
    /// Modifies the settings for a cluster. For example, you can add another security or
    /// parameter group, update the preferred maintenance window, or change the master user
    /// password. Resetting a cluster password or modifying the security groups associated
    /// with a cluster do not need a reboot. However, modifying a parameter group requires
    /// a reboot for parameters to take effect. For more information about managing clusters,
    /// go to <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/working-with-clusters.html">Amazon
    /// Redshift Clusters</a> in the <i>Amazon Redshift Cluster Management Guide</i>.
    /// 
    ///  
    /// <para>
    /// You can also change node type and the number of nodes to scale up or down the cluster.
    /// When resizing a cluster, you must specify both the number of nodes and the node type
    /// even if one of the parameters does not change.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "RSCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.Cluster")]
    [AWSCmdlet("Calls the Amazon Redshift ModifyCluster API operation.", Operation = new[] {"ModifyCluster"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.Cluster",
        "This cmdlet returns a Cluster object.",
        "The service call response (type Amazon.Redshift.Model.ModifyClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditRSClusterCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter AllowVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>If <code>true</code>, major version upgrades will be applied automatically to the
        /// cluster during the maintenance window. </para><para>Default: <code>false</code></para>
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
        /// manual snapshots when you want with <a>CreateClusterSnapshot</a>. </para><para>If you decrease the automated snapshot retention period from its current value, existing
        /// automated snapshots that fall outside of the new retention period will be immediately
        /// deleted.</para><para>Default: Uses existing setting.</para><para>Constraints: Must be a value from 0 to 35.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 AutomatedSnapshotRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the cluster to be modified.</para><para>Example: <code>examplecluster</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
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
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
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
        /// of the resize request. </para><para>Valid Values: <code> multi-node | single-node </code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClusterType { get; set; }
        #endregion
        
        #region Parameter ClusterVersion
        /// <summary>
        /// <para>
        /// <para>The new version number of the Amazon Redshift engine to upgrade to.</para><para>For major version upgrades, if a non-default cluster parameter group is currently
        /// in use, a new cluster parameter group in the cluster parameter group family for the
        /// new version must be specified. The new cluster parameter group can be the default
        /// for that cluster parameter group family. For more information about parameters and
        /// parameter groups, go to <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/working-with-parameter-groups.html">Amazon
        /// Redshift Parameter Groups</a> in the <i>Amazon Redshift Cluster Management Guide</i>.</para><para>Example: <code>1.0</code></para>
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
        /// go to <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/working-with-clusters.html#cluster-platforms">Supported
        /// Platforms to Launch Your Cluster</a> in the Amazon Redshift Cluster Management Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ElasticIp { get; set; }
        #endregion
        
        #region Parameter Encrypted
        /// <summary>
        /// <para>
        /// <para>Indicates whether the cluster is encrypted. If the cluster is encrypted and you provide
        /// a value for the <code>KmsKeyId</code> parameter, we will encrypt the cluster with
        /// the provided <code>KmsKeyId</code>. If you don't provide a <code>KmsKeyId</code>,
        /// we will encrypt with the default key. In the China region we will use legacy encryption
        /// if you specify that the cluster is encrypted.</para>
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
        /// For more information, see <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/enhanced-vpc-routing.html">Enhanced
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
        /// <para>The name for the maintenance track that you want to assign for the cluster. This name
        /// change is asynchronous. The new track name stays in the <code>PendingModifiedValues</code>
        /// for the cluster until the next maintenance window. When the maintenance track changes,
        /// the cluster is switched to the latest cluster release available for the maintenance
        /// track. At this point, the maintenance track name is applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MaintenanceTrackName { get; set; }
        #endregion
        
        #region Parameter MasterUserPassword
        /// <summary>
        /// <para>
        /// <para>The new password for the cluster master user. This change is asynchronously applied
        /// as soon as possible. Between the time of the request and the completion of the request,
        /// the <code>MasterUserPassword</code> element exists in the <code>PendingModifiedValues</code>
        /// element of the operation response. </para><note><para>Operations never return the password, so this operation provides a way to regain access
        /// to the master user account for a cluster if the password is lost.</para></note><para>Default: Uses existing setting.</para><para>Constraints:</para><ul><li><para>Must be between 8 and 64 characters in length.</para></li><li><para>Must contain at least one uppercase letter.</para></li><li><para>Must contain at least one lowercase letter.</para></li><li><para>Must contain one number.</para></li><li><para>Can be any printable ASCII character (ASCII code 33 to 126) except ' (single quote),
        /// " (double quote), \, /, @, or space.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MasterUserPassword { get; set; }
        #endregion
        
        #region Parameter NewClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The new identifier for the cluster.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 alphanumeric characters or hyphens.</para></li><li><para>Alphabetic characters must be lowercase.</para></li><li><para>First character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li><li><para>Must be unique for all clusters within an AWS account.</para></li></ul><para>Example: <code>examplecluster</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter NodeType
        /// <summary>
        /// <para>
        /// <para>The new node type of the cluster. If you specify a new node type, you must also specify
        /// the number of nodes parameter.</para><para>When you submit your request to resize a cluster, Amazon Redshift sets access permissions
        /// for the cluster to read-only. After Amazon Redshift provisions a new cluster according
        /// to your resize requirements, there will be a temporary outage while the old cluster
        /// is deleted and your connection is switched to the new cluster. When the new connection
        /// is complete, the original access permissions for the cluster are restored. You can
        /// use <a>DescribeResize</a> to track the progress of the resize request. </para><para>Valid Values: <code>ds2.xlarge</code> | <code>ds2.8xlarge</code> | <code>dc1.large</code>
        /// | <code>dc1.8xlarge</code> | <code>dc2.large</code> | <code>dc2.8xlarge</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NodeType { get; set; }
        #endregion
        
        #region Parameter NumberOfNodes
        /// <summary>
        /// <para>
        /// <para>The new number of nodes of the cluster. If you specify a new number of nodes, you
        /// must also specify the node type parameter.</para><para>When you submit your request to resize a cluster, Amazon Redshift sets access permissions
        /// for the cluster to read-only. After Amazon Redshift provisions a new cluster according
        /// to your resize requirements, there will be a temporary outage while the old cluster
        /// is deleted and your connection is switched to the new cluster. When the new connection
        /// is complete, the original access permissions for the cluster are restored. You can
        /// use <a>DescribeResize</a> to track the progress of the resize request. </para><para>Valid Values: Integer greater than <code>0</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 NumberOfNodes { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>The weekly time range (in UTC) during which system maintenance can occur, if necessary.
        /// If system maintenance is necessary during the window, it may result in an outage.</para><para>This maintenance window change is made immediately. If the new maintenance window
        /// indicates the current time, there must be at least 120 minutes between the current
        /// time and end of the window in order to ensure that pending changes are applied.</para><para>Default: Uses existing setting.</para><para>Format: ddd:hh24:mi-ddd:hh24:mi, for example <code>wed:07:30-wed:08:00</code>.</para><para>Valid Days: Mon | Tue | Wed | Thu | Fri | Sat | Sun</para><para>Constraints: Must be at least 30 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>If <code>true</code>, the cluster can be accessed from a public network. Only clusters
        /// in VPCs can be set to be publicly available.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of virtual private cloud (VPC) security groups to be associated with the cluster.
        /// This change is asynchronously applied as soon as possible.</para>
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ClusterIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RSCluster (ModifyCluster)"))
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
            
            if (ParameterWasBound("AllowVersionUpgrade"))
                context.AllowVersionUpgrade = this.AllowVersionUpgrade;
            if (ParameterWasBound("AutomatedSnapshotRetentionPeriod"))
                context.AutomatedSnapshotRetentionPeriod = this.AutomatedSnapshotRetentionPeriod;
            context.ClusterIdentifier = this.ClusterIdentifier;
            context.ClusterParameterGroupName = this.ClusterParameterGroupName;
            if (this.ClusterSecurityGroup != null)
            {
                context.ClusterSecurityGroups = new List<System.String>(this.ClusterSecurityGroup);
            }
            context.ClusterType = this.ClusterType;
            context.ClusterVersion = this.ClusterVersion;
            context.ElasticIp = this.ElasticIp;
            if (ParameterWasBound("Encrypted"))
                context.Encrypted = this.Encrypted;
            if (ParameterWasBound("EnhancedVpcRouting"))
                context.EnhancedVpcRouting = this.EnhancedVpcRouting;
            context.HsmClientCertificateIdentifier = this.HsmClientCertificateIdentifier;
            context.HsmConfigurationIdentifier = this.HsmConfigurationIdentifier;
            context.KmsKeyId = this.KmsKeyId;
            context.MaintenanceTrackName = this.MaintenanceTrackName;
            context.MasterUserPassword = this.MasterUserPassword;
            context.NewClusterIdentifier = this.NewClusterIdentifier;
            context.NodeType = this.NodeType;
            if (ParameterWasBound("NumberOfNodes"))
                context.NumberOfNodes = this.NumberOfNodes;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            if (ParameterWasBound("PubliclyAccessible"))
                context.PubliclyAccessible = this.PubliclyAccessible;
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
            var request = new Amazon.Redshift.Model.ModifyClusterRequest();
            
            if (cmdletContext.AllowVersionUpgrade != null)
            {
                request.AllowVersionUpgrade = cmdletContext.AllowVersionUpgrade.Value;
            }
            if (cmdletContext.AutomatedSnapshotRetentionPeriod != null)
            {
                request.AutomatedSnapshotRetentionPeriod = cmdletContext.AutomatedSnapshotRetentionPeriod.Value;
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
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.MaintenanceTrackName != null)
            {
                request.MaintenanceTrackName = cmdletContext.MaintenanceTrackName;
            }
            if (cmdletContext.MasterUserPassword != null)
            {
                request.MasterUserPassword = cmdletContext.MasterUserPassword;
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
            if (cmdletContext.PreferredMaintenanceWindow != null)
            {
                request.PreferredMaintenanceWindow = cmdletContext.PreferredMaintenanceWindow;
            }
            if (cmdletContext.PubliclyAccessible != null)
            {
                request.PubliclyAccessible = cmdletContext.PubliclyAccessible.Value;
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
        
        private Amazon.Redshift.Model.ModifyClusterResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.ModifyClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "ModifyCluster");
            try
            {
                #if DESKTOP
                return client.ModifyCluster(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ModifyClusterAsync(request);
                return task.Result;
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
            public System.String ClusterIdentifier { get; set; }
            public System.String ClusterParameterGroupName { get; set; }
            public List<System.String> ClusterSecurityGroups { get; set; }
            public System.String ClusterType { get; set; }
            public System.String ClusterVersion { get; set; }
            public System.String ElasticIp { get; set; }
            public System.Boolean? Encrypted { get; set; }
            public System.Boolean? EnhancedVpcRouting { get; set; }
            public System.String HsmClientCertificateIdentifier { get; set; }
            public System.String HsmConfigurationIdentifier { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String MaintenanceTrackName { get; set; }
            public System.String MasterUserPassword { get; set; }
            public System.String NewClusterIdentifier { get; set; }
            public System.String NodeType { get; set; }
            public System.Int32? NumberOfNodes { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public List<System.String> VpcSecurityGroupIds { get; set; }
        }
        
    }
}
