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
using Amazon.MemoryDB;
using Amazon.MemoryDB.Model;

namespace Amazon.PowerShell.Cmdlets.MDB
{
    /// <summary>
    /// Creates a cluster. All nodes in the cluster run the same protocol-compliant engine
    /// software.
    /// </summary>
    [Cmdlet("New", "MDBCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MemoryDB.Model.Cluster")]
    [AWSCmdlet("Calls the Amazon MemoryDB CreateCluster API operation.", Operation = new[] {"CreateCluster"}, SelectReturnType = typeof(Amazon.MemoryDB.Model.CreateClusterResponse))]
    [AWSCmdletOutput("Amazon.MemoryDB.Model.Cluster or Amazon.MemoryDB.Model.CreateClusterResponse",
        "This cmdlet returns an Amazon.MemoryDB.Model.Cluster object.",
        "The service call response (type Amazon.MemoryDB.Model.CreateClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewMDBClusterCmdlet : AmazonMemoryDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ACLName
        /// <summary>
        /// <para>
        /// <para>The name of the Access Control List to associate with the cluster.</para>
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
        public System.String ACLName { get; set; }
        #endregion
        
        #region Parameter AutoMinorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>When set to true, the cluster will automatically receive minor engine version upgrades
        /// after launch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoMinorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The name of the cluster. This value must be unique as it also serves as the cluster
        /// identifier.</para>
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
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter DataTiering
        /// <summary>
        /// <para>
        /// <para>Enables data tiering. Data tiering is only supported for clusters using the r6gd node
        /// type. This parameter must be set when using r6gd nodes. For more information, see
        /// <a href="https://docs.aws.amazon.com/memorydb/latest/devguide/data-tiering.html">Data
        /// tiering</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DataTiering { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description of the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The name of the engine to be used for the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The version number of the Redis OSS engine to be used for the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter IpDiscovery
        /// <summary>
        /// <para>
        /// <para>The mechanism for discovering IP addresses for the cluster discovery protocol. Valid
        /// values are 'ipv4' or 'ipv6'. When set to 'ipv4', cluster discovery functions such
        /// as cluster slots, cluster shards, and cluster nodes return IPv4 addresses for cluster
        /// nodes. When set to 'ipv6', the cluster discovery functions return IPv6 addresses for
        /// cluster nodes. The value must be compatible with the NetworkType parameter. If not
        /// specified, the default is 'ipv4'.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MemoryDB.IpDiscovery")]
        public Amazon.MemoryDB.IpDiscovery IpDiscovery { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The ID of the KMS key used to encrypt the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>Specifies the weekly time range during which maintenance on the cluster is performed.
        /// It is specified as a range in the format ddd:hh24:mi-ddd:hh24:mi (24H Clock UTC).
        /// The minimum maintenance window is a 60 minute period.</para><para>Valid values for <c>ddd</c> are:</para><ul><li><para><c>sun</c></para></li><li><para><c>mon</c></para></li><li><para><c>tue</c></para></li><li><para><c>wed</c></para></li><li><para><c>thu</c></para></li><li><para><c>fri</c></para></li><li><para><c>sat</c></para></li></ul><para>Example: <c>sun:23:00-mon:01:30</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter MultiRegionClusterName
        /// <summary>
        /// <para>
        /// <para>The name of the multi-Region cluster to be created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MultiRegionClusterName { get; set; }
        #endregion
        
        #region Parameter NetworkType
        /// <summary>
        /// <para>
        /// <para>Specifies the IP address type for the cluster. Valid values are 'ipv4', 'ipv6', or
        /// 'dual_stack'. When set to 'ipv4', the cluster will only be accessible via IPv4 addresses.
        /// When set to 'ipv6', the cluster will only be accessible via IPv6 addresses. When set
        /// to 'dual_stack', the cluster will be accessible via both IPv4 and IPv6 addresses.
        /// If not specified, the default is 'ipv4'.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MemoryDB.NetworkType")]
        public Amazon.MemoryDB.NetworkType NetworkType { get; set; }
        #endregion
        
        #region Parameter NodeType
        /// <summary>
        /// <para>
        /// <para>The compute and memory capacity of the nodes in the cluster.</para>
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
        public System.String NodeType { get; set; }
        #endregion
        
        #region Parameter NumReplicasPerShard
        /// <summary>
        /// <para>
        /// <para>The number of replicas to apply to each shard. The default value is 1. The maximum
        /// is 5. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NumReplicasPerShard { get; set; }
        #endregion
        
        #region Parameter NumShard
        /// <summary>
        /// <para>
        /// <para>The number of shards the cluster will contain. The default value is 1. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NumShards")]
        public System.Int32? NumShard { get; set; }
        #endregion
        
        #region Parameter ParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the parameter group associated with the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParameterGroupName { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port number on which each of the nodes accepts connections.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of security group names to associate with this cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SnapshotArn
        /// <summary>
        /// <para>
        /// <para>A list of Amazon Resource Names (ARN) that uniquely identify the RDB snapshot files
        /// stored in Amazon S3. The snapshot files are used to populate the new cluster. The
        /// Amazon S3 object name in the ARN cannot contain any commas.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SnapshotArns")]
        public System.String[] SnapshotArn { get; set; }
        #endregion
        
        #region Parameter SnapshotName
        /// <summary>
        /// <para>
        /// <para>The name of a snapshot from which to restore data into the new cluster. The snapshot
        /// status changes to restoring while the new cluster is being created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotName { get; set; }
        #endregion
        
        #region Parameter SnapshotRetentionLimit
        /// <summary>
        /// <para>
        /// <para>The number of days for which MemoryDB retains automatic snapshots before deleting
        /// them. For example, if you set SnapshotRetentionLimit to 5, a snapshot that was taken
        /// today is retained for 5 days before being deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SnapshotRetentionLimit { get; set; }
        #endregion
        
        #region Parameter SnapshotWindow
        /// <summary>
        /// <para>
        /// <para>The daily time range (in UTC) during which MemoryDB begins taking a daily snapshot
        /// of your shard.</para><para> Example: 05:00-09:00</para><para> If you do not specify this parameter, MemoryDB automatically chooses an appropriate
        /// time range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotWindow { get; set; }
        #endregion
        
        #region Parameter SnsTopicArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Simple Notification Service (SNS) topic
        /// to which notifications are sent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnsTopicArn { get; set; }
        #endregion
        
        #region Parameter SubnetGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the subnet group to be used for the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubnetGroupName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to be added to this resource. Tags are comma-separated key,value pairs
        /// (e.g. Key=myKey, Value=myKeyValue. You can include multiple tags as shown following:
        /// Key=myKey, Value=myKeyValue Key=mySecondKey, Value=mySecondKeyValue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.MemoryDB.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TLSEnabled
        /// <summary>
        /// <para>
        /// <para>A flag to enable in-transit encryption on the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TLSEnabled { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Cluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MemoryDB.Model.CreateClusterResponse).
        /// Specifying the name of a property of type Amazon.MemoryDB.Model.CreateClusterResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MDBCluster (CreateCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MemoryDB.Model.CreateClusterResponse, NewMDBClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ACLName = this.ACLName;
            #if MODULAR
            if (this.ACLName == null && ParameterWasBound(nameof(this.ACLName)))
            {
                WriteWarning("You are passing $null as a value for parameter ACLName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            context.ClusterName = this.ClusterName;
            #if MODULAR
            if (this.ClusterName == null && ParameterWasBound(nameof(this.ClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataTiering = this.DataTiering;
            context.Description = this.Description;
            context.Engine = this.Engine;
            context.EngineVersion = this.EngineVersion;
            context.IpDiscovery = this.IpDiscovery;
            context.KmsKeyId = this.KmsKeyId;
            context.MaintenanceWindow = this.MaintenanceWindow;
            context.MultiRegionClusterName = this.MultiRegionClusterName;
            context.NetworkType = this.NetworkType;
            context.NodeType = this.NodeType;
            #if MODULAR
            if (this.NodeType == null && ParameterWasBound(nameof(this.NodeType)))
            {
                WriteWarning("You are passing $null as a value for parameter NodeType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NumReplicasPerShard = this.NumReplicasPerShard;
            context.NumShard = this.NumShard;
            context.ParameterGroupName = this.ParameterGroupName;
            context.Port = this.Port;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupId = new List<System.String>(this.SecurityGroupId);
            }
            if (this.SnapshotArn != null)
            {
                context.SnapshotArn = new List<System.String>(this.SnapshotArn);
            }
            context.SnapshotName = this.SnapshotName;
            context.SnapshotRetentionLimit = this.SnapshotRetentionLimit;
            context.SnapshotWindow = this.SnapshotWindow;
            context.SnsTopicArn = this.SnsTopicArn;
            context.SubnetGroupName = this.SubnetGroupName;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.MemoryDB.Model.Tag>(this.Tag);
            }
            context.TLSEnabled = this.TLSEnabled;
            
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
            var request = new Amazon.MemoryDB.Model.CreateClusterRequest();
            
            if (cmdletContext.ACLName != null)
            {
                request.ACLName = cmdletContext.ACLName;
            }
            if (cmdletContext.AutoMinorVersionUpgrade != null)
            {
                request.AutoMinorVersionUpgrade = cmdletContext.AutoMinorVersionUpgrade.Value;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            if (cmdletContext.DataTiering != null)
            {
                request.DataTiering = cmdletContext.DataTiering.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.IpDiscovery != null)
            {
                request.IpDiscovery = cmdletContext.IpDiscovery;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.MaintenanceWindow != null)
            {
                request.MaintenanceWindow = cmdletContext.MaintenanceWindow;
            }
            if (cmdletContext.MultiRegionClusterName != null)
            {
                request.MultiRegionClusterName = cmdletContext.MultiRegionClusterName;
            }
            if (cmdletContext.NetworkType != null)
            {
                request.NetworkType = cmdletContext.NetworkType;
            }
            if (cmdletContext.NodeType != null)
            {
                request.NodeType = cmdletContext.NodeType;
            }
            if (cmdletContext.NumReplicasPerShard != null)
            {
                request.NumReplicasPerShard = cmdletContext.NumReplicasPerShard.Value;
            }
            if (cmdletContext.NumShard != null)
            {
                request.NumShards = cmdletContext.NumShard.Value;
            }
            if (cmdletContext.ParameterGroupName != null)
            {
                request.ParameterGroupName = cmdletContext.ParameterGroupName;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.SecurityGroupId != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupId;
            }
            if (cmdletContext.SnapshotArn != null)
            {
                request.SnapshotArns = cmdletContext.SnapshotArn;
            }
            if (cmdletContext.SnapshotName != null)
            {
                request.SnapshotName = cmdletContext.SnapshotName;
            }
            if (cmdletContext.SnapshotRetentionLimit != null)
            {
                request.SnapshotRetentionLimit = cmdletContext.SnapshotRetentionLimit.Value;
            }
            if (cmdletContext.SnapshotWindow != null)
            {
                request.SnapshotWindow = cmdletContext.SnapshotWindow;
            }
            if (cmdletContext.SnsTopicArn != null)
            {
                request.SnsTopicArn = cmdletContext.SnsTopicArn;
            }
            if (cmdletContext.SubnetGroupName != null)
            {
                request.SubnetGroupName = cmdletContext.SubnetGroupName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TLSEnabled != null)
            {
                request.TLSEnabled = cmdletContext.TLSEnabled.Value;
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
        
        private Amazon.MemoryDB.Model.CreateClusterResponse CallAWSServiceOperation(IAmazonMemoryDB client, Amazon.MemoryDB.Model.CreateClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MemoryDB", "CreateCluster");
            try
            {
                return client.CreateClusterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ACLName { get; set; }
            public System.Boolean? AutoMinorVersionUpgrade { get; set; }
            public System.String ClusterName { get; set; }
            public System.Boolean? DataTiering { get; set; }
            public System.String Description { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineVersion { get; set; }
            public Amazon.MemoryDB.IpDiscovery IpDiscovery { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String MaintenanceWindow { get; set; }
            public System.String MultiRegionClusterName { get; set; }
            public Amazon.MemoryDB.NetworkType NetworkType { get; set; }
            public System.String NodeType { get; set; }
            public System.Int32? NumReplicasPerShard { get; set; }
            public System.Int32? NumShard { get; set; }
            public System.String ParameterGroupName { get; set; }
            public System.Int32? Port { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public List<System.String> SnapshotArn { get; set; }
            public System.String SnapshotName { get; set; }
            public System.Int32? SnapshotRetentionLimit { get; set; }
            public System.String SnapshotWindow { get; set; }
            public System.String SnsTopicArn { get; set; }
            public System.String SubnetGroupName { get; set; }
            public List<Amazon.MemoryDB.Model.Tag> Tag { get; set; }
            public System.Boolean? TLSEnabled { get; set; }
            public System.Func<Amazon.MemoryDB.Model.CreateClusterResponse, NewMDBClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Cluster;
        }
        
    }
}
