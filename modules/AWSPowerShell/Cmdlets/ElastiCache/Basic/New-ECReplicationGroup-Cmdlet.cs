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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// Creates a Redis (cluster mode disabled) or a Redis (cluster mode enabled) replication
    /// group.
    /// 
    ///  
    /// <para>
    /// A Redis (cluster mode disabled) replication group is a collection of clusters, where
    /// one of the clusters is a read/write primary and the others are read-only replicas.
    /// Writes to the primary are asynchronously propagated to the replicas.
    /// </para><para>
    /// A Redis (cluster mode enabled) replication group is a collection of 1 to 90 node groups
    /// (shards). Each node group (shard) has one read/write primary node and up to 5 read-only
    /// replica nodes. Writes to the primary are asynchronously propagated to the replicas.
    /// Redis (cluster mode enabled) replication groups partition the data across node groups
    /// (shards).
    /// </para><para>
    /// When a Redis (cluster mode disabled) replication group has been successfully created,
    /// you can add one or more read replicas to it, up to a total of 5 read replicas. You
    /// cannot alter a Redis (cluster mode enabled) replication group after it has been created.
    /// However, if you need to increase or decrease the number of node groups (console: shards),
    /// you can avail yourself of ElastiCache for Redis' enhanced backup and restore. For
    /// more information, see <a href="https://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/backups-restoring.html">Restoring
    /// From a Backup with Cluster Resizing</a> in the <i>ElastiCache User Guide</i>.
    /// </para><note><para>
    /// This operation is valid for Redis only.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "ECReplicationGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.ReplicationGroup")]
    [AWSCmdlet("Calls the Amazon ElastiCache CreateReplicationGroup API operation.", Operation = new[] {"CreateReplicationGroup"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.CreateReplicationGroupResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ReplicationGroup or Amazon.ElastiCache.Model.CreateReplicationGroupResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.ReplicationGroup object.",
        "The service call response (type Amazon.ElastiCache.Model.CreateReplicationGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewECReplicationGroupCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        #region Parameter AtRestEncryptionEnabled
        /// <summary>
        /// <para>
        /// <para>A flag that enables encryption at rest when set to <code>true</code>.</para><para>You cannot modify the value of <code>AtRestEncryptionEnabled</code> after the replication
        /// group is created. To enable encryption at rest on a replication group you must set
        /// <code>AtRestEncryptionEnabled</code> to <code>true</code> when you create the replication
        /// group. </para><para><b>Required:</b> Only available when creating a replication group in an Amazon VPC
        /// using redis version <code>3.2.6</code>, <code>4.x</code> or later.</para><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AtRestEncryptionEnabled { get; set; }
        #endregion
        
        #region Parameter AuthToken
        /// <summary>
        /// <para>
        /// <para><b>Reserved parameter.</b> The password used to access a password protected server.</para><para><code>AuthToken</code> can be specified only on replication groups where <code>TransitEncryptionEnabled</code>
        /// is <code>true</code>.</para><important><para>For HIPAA compliance, you must specify <code>TransitEncryptionEnabled</code> as <code>true</code>,
        /// an <code>AuthToken</code>, and a <code>CacheSubnetGroup</code>.</para></important><para>Password constraints:</para><ul><li><para>Must be only printable ASCII characters.</para></li><li><para>Must be at least 16 characters and no more than 128 characters in length.</para></li><li><para>The only permitted printable special characters are !, &amp;, #, $, ^, &lt;, &gt;,
        /// and -. Other printable special characters cannot be used in the AUTH token.</para></li></ul><para>For more information, see <a href="http://redis.io/commands/AUTH">AUTH password</a>
        /// at http://redis.io/commands/AUTH.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthToken { get; set; }
        #endregion
        
        #region Parameter AutomaticFailoverEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether a read-only replica is automatically promoted to read/write primary
        /// if the existing primary fails.</para><para>If <code>true</code>, Multi-AZ is enabled for this replication group. If <code>false</code>,
        /// Multi-AZ is disabled for this replication group.</para><para><code>AutomaticFailoverEnabled</code> must be enabled for Redis (cluster mode enabled)
        /// replication groups.</para><para>Default: false</para><para>Amazon ElastiCache for Redis does not support Multi-AZ with automatic failover on:</para><ul><li><para>Redis versions earlier than 2.8.6.</para></li><li><para>Redis (cluster mode disabled): T1 node types.</para></li><li><para>Redis (cluster mode enabled): T1 node types.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutomaticFailoverEnabled { get; set; }
        #endregion
        
        #region Parameter AutoMinorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>This parameter is currently disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoMinorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter CacheNodeType
        /// <summary>
        /// <para>
        /// <para>The compute and memory capacity of the nodes in the node group (shard).</para><para>The following node types are supported by ElastiCache. Generally speaking, the current
        /// generation types provide more memory and computational power at lower cost when compared
        /// to their equivalent previous generation counterparts.</para><ul><li><para>General purpose:</para><ul><li><para>Current generation: </para><para><b>M5 node types:</b><code>cache.m5.large</code>, <code>cache.m5.xlarge</code>,
        /// <code>cache.m5.2xlarge</code>, <code>cache.m5.4xlarge</code>, <code>cache.m5.12xlarge</code>,
        /// <code>cache.m5.24xlarge</code></para><para><b>M4 node types:</b><code>cache.m4.large</code>, <code>cache.m4.xlarge</code>,
        /// <code>cache.m4.2xlarge</code>, <code>cache.m4.4xlarge</code>, <code>cache.m4.10xlarge</code></para><para><b>T2 node types:</b><code>cache.t2.micro</code>, <code>cache.t2.small</code>, <code>cache.t2.medium</code></para></li><li><para>Previous generation: (not recommended)</para><para><b>T1 node types:</b><code>cache.t1.micro</code></para><para><b>M1 node types:</b><code>cache.m1.small</code>, <code>cache.m1.medium</code>,
        /// <code>cache.m1.large</code>, <code>cache.m1.xlarge</code></para><para><b>M3 node types:</b><code>cache.m3.medium</code>, <code>cache.m3.large</code>,
        /// <code>cache.m3.xlarge</code>, <code>cache.m3.2xlarge</code></para></li></ul></li><li><para>Compute optimized:</para><ul><li><para>Previous generation: (not recommended)</para><para><b>C1 node types:</b><code>cache.c1.xlarge</code></para></li></ul></li><li><para>Memory optimized:</para><ul><li><para>Current generation: </para><para><b>R5 node types:</b><code>cache.r5.large</code>, <code>cache.r5.xlarge</code>,
        /// <code>cache.r5.2xlarge</code>, <code>cache.r5.4xlarge</code>, <code>cache.r5.12xlarge</code>,
        /// <code>cache.r5.24xlarge</code></para><para><b>R4 node types:</b><code>cache.r4.large</code>, <code>cache.r4.xlarge</code>,
        /// <code>cache.r4.2xlarge</code>, <code>cache.r4.4xlarge</code>, <code>cache.r4.8xlarge</code>,
        /// <code>cache.r4.16xlarge</code></para></li><li><para>Previous generation: (not recommended)</para><para><b>M2 node types:</b><code>cache.m2.xlarge</code>, <code>cache.m2.2xlarge</code>,
        /// <code>cache.m2.4xlarge</code></para><para><b>R3 node types:</b><code>cache.r3.large</code>, <code>cache.r3.xlarge</code>,
        /// <code>cache.r3.2xlarge</code>, <code>cache.r3.4xlarge</code>, <code>cache.r3.8xlarge</code></para></li></ul></li></ul><para><b>Additional node type info</b></para><ul><li><para>All current generation instance types are created in Amazon VPC by default.</para></li><li><para>Redis append-only files (AOF) are not supported for T1 or T2 instances.</para></li><li><para>Redis Multi-AZ with automatic failover is not supported on T1 instances.</para></li><li><para>Redis configuration variables <code>appendonly</code> and <code>appendfsync</code>
        /// are not supported on Redis version 2.8.22 and later.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CacheNodeType { get; set; }
        #endregion
        
        #region Parameter CacheParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the parameter group to associate with this replication group. If this
        /// argument is omitted, the default cache parameter group for the specified engine is
        /// used.</para><note><para>If you are restoring to an engine version that is different than the original, you
        /// must specify the default version of that version. For example, <code>CacheParameterGroupName=default.redis4.0</code>.</para></note><para>If you are running Redis version 3.2.4 or later, only one node group (shard), and
        /// want to use a default parameter group, we recommend that you specify the parameter
        /// group by name. </para><ul><li><para>To create a Redis (cluster mode disabled) replication group, use <code>CacheParameterGroupName=default.redis3.2</code>.</para></li><li><para>To create a Redis (cluster mode enabled) replication group, use <code>CacheParameterGroupName=default.redis3.2.cluster.on</code>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CacheParameterGroupName { get; set; }
        #endregion
        
        #region Parameter CacheSecurityGroupName
        /// <summary>
        /// <para>
        /// <para>A list of cache security group names to associate with this replication group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheSecurityGroupNames")]
        public System.String[] CacheSecurityGroupName { get; set; }
        #endregion
        
        #region Parameter CacheSubnetGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the cache subnet group to be used for the replication group.</para><important><para>If you're going to launch your cluster in an Amazon VPC, you need to create a subnet
        /// group before you start creating a cluster. For more information, see <a href="https://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/SubnetGroups.html">Subnets
        /// and Subnet Groups</a>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CacheSubnetGroupName { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The name of the cache engine to be used for the clusters in this replication group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The version number of the cache engine to be used for the clusters in this replication
        /// group. To view the supported cache engine versions, use the <code>DescribeCacheEngineVersions</code>
        /// operation.</para><para><b>Important:</b> You can upgrade to a newer engine version (see <a href="https://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/SelectEngine.html#VersionManagement">Selecting
        /// a Cache Engine and Version</a>) in the <i>ElastiCache User Guide</i>, but you cannot
        /// downgrade to an earlier engine version. If you want to use an earlier engine version,
        /// you must delete the existing cluster or replication group and create it anew with
        /// the earlier engine version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The ID of the KMS key used to encrypt the disk on the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter NodeGroupConfiguration
        /// <summary>
        /// <para>
        /// <para>A list of node group (shard) configuration options. Each node group (shard) configuration
        /// has the following members: <code>PrimaryAvailabilityZone</code>, <code>ReplicaAvailabilityZones</code>,
        /// <code>ReplicaCount</code>, and <code>Slots</code>.</para><para>If you're creating a Redis (cluster mode disabled) or a Redis (cluster mode enabled)
        /// replication group, you can use this parameter to individually configure each node
        /// group (shard), or you can omit this parameter. However, when seeding a Redis (cluster
        /// mode enabled) cluster from a S3 rdb file, you must configure each node group (shard)
        /// using this parameter because you must specify the slots for each node group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ElastiCache.Model.NodeGroupConfiguration[] NodeGroupConfiguration { get; set; }
        #endregion
        
        #region Parameter NotificationTopicArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Simple Notification Service (SNS) topic
        /// to which notifications are sent.</para><note><para>The Amazon SNS topic owner must be the same as the cluster owner.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationTopicArn { get; set; }
        #endregion
        
        #region Parameter NumCacheCluster
        /// <summary>
        /// <para>
        /// <para>The number of clusters this replication group initially has.</para><para>This parameter is not used if there is more than one node group (shard). You should
        /// use <code>ReplicasPerNodeGroup</code> instead.</para><para>If <code>AutomaticFailoverEnabled</code> is <code>true</code>, the value of this parameter
        /// must be at least 2. If <code>AutomaticFailoverEnabled</code> is <code>false</code>
        /// you can omit this parameter (it will default to 1), or you can explicitly set it to
        /// a value between 2 and 6.</para><para>The maximum permitted value for <code>NumCacheClusters</code> is 6 (1 primary plus
        /// 5 replicas).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NumCacheClusters")]
        public System.Int32? NumCacheCluster { get; set; }
        #endregion
        
        #region Parameter NumNodeGroup
        /// <summary>
        /// <para>
        /// <para>An optional parameter that specifies the number of node groups (shards) for this Redis
        /// (cluster mode enabled) replication group. For Redis (cluster mode disabled) either
        /// omit this parameter or set it to 1.</para><para>Default: 1</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NumNodeGroups")]
        public System.Int32? NumNodeGroup { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port number on which each member of the replication group accepts connections.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter PreferredCacheClusterAZs
        /// <summary>
        /// <para>
        /// <para>A list of EC2 Availability Zones in which the replication group's clusters are created.
        /// The order of the Availability Zones in the list is the order in which clusters are
        /// allocated. The primary cluster is created in the first AZ in the list.</para><para>This parameter is not used if there is more than one node group (shard). You should
        /// use <code>NodeGroupConfiguration</code> instead.</para><note><para>If you are creating your replication group in an Amazon VPC (recommended), you can
        /// only locate clusters in Availability Zones associated with the subnets in the selected
        /// subnet group.</para><para>The number of Availability Zones listed must equal the value of <code>NumCacheClusters</code>.</para></note><para>Default: system chosen Availability Zones.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] PreferredCacheClusterAZs { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>Specifies the weekly time range during which maintenance on the cluster is performed.
        /// It is specified as a range in the format ddd:hh24:mi-ddd:hh24:mi (24H Clock UTC).
        /// The minimum maintenance window is a 60 minute period. Valid values for <code>ddd</code>
        /// are:</para><para>Specifies the weekly time range during which maintenance on the cluster is performed.
        /// It is specified as a range in the format ddd:hh24:mi-ddd:hh24:mi (24H Clock UTC).
        /// The minimum maintenance window is a 60 minute period.</para><para>Valid values for <code>ddd</code> are:</para><ul><li><para><code>sun</code></para></li><li><para><code>mon</code></para></li><li><para><code>tue</code></para></li><li><para><code>wed</code></para></li><li><para><code>thu</code></para></li><li><para><code>fri</code></para></li><li><para><code>sat</code></para></li></ul><para>Example: <code>sun:23:00-mon:01:30</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter PrimaryClusterId
        /// <summary>
        /// <para>
        /// <para>The identifier of the cluster that serves as the primary for this replication group.
        /// This cluster must already exist and have a status of <code>available</code>.</para><para>This parameter is not required if <code>NumCacheClusters</code>, <code>NumNodeGroups</code>,
        /// or <code>ReplicasPerNodeGroup</code> is specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String PrimaryClusterId { get; set; }
        #endregion
        
        #region Parameter ReplicasPerNodeGroup
        /// <summary>
        /// <para>
        /// <para>An optional parameter that specifies the number of replica nodes in each node group
        /// (shard). Valid values are 0 to 5.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ReplicasPerNodeGroup { get; set; }
        #endregion
        
        #region Parameter ReplicationGroupDescription
        /// <summary>
        /// <para>
        /// <para>A user-created description for the replication group.</para>
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
        public System.String ReplicationGroupDescription { get; set; }
        #endregion
        
        #region Parameter ReplicationGroupId
        /// <summary>
        /// <para>
        /// <para>The replication group identifier. This parameter is stored as a lowercase string.</para><para>Constraints:</para><ul><li><para>A name must contain from 1 to 40 alphanumeric characters or hyphens.</para></li><li><para>The first character must be a letter.</para></li><li><para>A name cannot end with a hyphen or contain two consecutive hyphens.</para></li></ul>
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
        public System.String ReplicationGroupId { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>One or more Amazon VPC security groups associated with this replication group.</para><para>Use this parameter only when you are creating a replication group in an Amazon Virtual
        /// Private Cloud (Amazon VPC).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SnapshotArn
        /// <summary>
        /// <para>
        /// <para>A list of Amazon Resource Names (ARN) that uniquely identify the Redis RDB snapshot
        /// files stored in Amazon S3. The snapshot files are used to populate the new replication
        /// group. The Amazon S3 object name in the ARN cannot contain any commas. The new replication
        /// group will have the number of node groups (console: shards) specified by the parameter
        /// <i>NumNodeGroups</i> or the number of node groups configured by <i>NodeGroupConfiguration</i>
        /// regardless of the number of ARNs specified here.</para><para>Example of an Amazon S3 ARN: <code>arn:aws:s3:::my_bucket/snapshot1.rdb</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SnapshotArns")]
        public System.String[] SnapshotArn { get; set; }
        #endregion
        
        #region Parameter SnapshotName
        /// <summary>
        /// <para>
        /// <para>The name of a snapshot from which to restore data into the new replication group.
        /// The snapshot status changes to <code>restoring</code> while the new replication group
        /// is being created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotName { get; set; }
        #endregion
        
        #region Parameter SnapshotRetentionLimit
        /// <summary>
        /// <para>
        /// <para>The number of days for which ElastiCache retains automatic snapshots before deleting
        /// them. For example, if you set <code>SnapshotRetentionLimit</code> to 5, a snapshot
        /// that was taken today is retained for 5 days before being deleted.</para><para>Default: 0 (i.e., automatic backups are disabled for this cluster).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SnapshotRetentionLimit { get; set; }
        #endregion
        
        #region Parameter SnapshotWindow
        /// <summary>
        /// <para>
        /// <para>The daily time range (in UTC) during which ElastiCache begins taking a daily snapshot
        /// of your node group (shard).</para><para>Example: <code>05:00-09:00</code></para><para>If you do not specify this parameter, ElastiCache automatically chooses an appropriate
        /// time range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotWindow { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of cost allocation tags to be added to this resource. Tags are comma-separated
        /// key,value pairs (e.g. Key=<code>myKey</code>, Value=<code>myKeyValue</code>. You can
        /// include multiple tags as shown following: Key=<code>myKey</code>, Value=<code>myKeyValue</code>
        /// Key=<code>mySecondKey</code>, Value=<code>mySecondKeyValue</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ElastiCache.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TransitEncryptionEnabled
        /// <summary>
        /// <para>
        /// <para>A flag that enables in-transit encryption when set to <code>true</code>.</para><para>You cannot modify the value of <code>TransitEncryptionEnabled</code> after the cluster
        /// is created. To enable in-transit encryption on a cluster you must set <code>TransitEncryptionEnabled</code>
        /// to <code>true</code> when you create a cluster.</para><para>This parameter is valid only if the <code>Engine</code> parameter is <code>redis</code>,
        /// the <code>EngineVersion</code> parameter is <code>3.2.6</code>, <code>4.x</code> or
        /// later, and the cluster is being created in an Amazon VPC.</para><para>If you enable in-transit encryption, you must also specify a value for <code>CacheSubnetGroup</code>.</para><para><b>Required:</b> Only available when creating a replication group in an Amazon VPC
        /// using redis version <code>3.2.6</code>, <code>4.x</code> or later.</para><para>Default: <code>false</code></para><important><para>For HIPAA compliance, you must specify <code>TransitEncryptionEnabled</code> as <code>true</code>,
        /// an <code>AuthToken</code>, and a <code>CacheSubnetGroup</code>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TransitEncryptionEnabled { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReplicationGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.CreateReplicationGroupResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.CreateReplicationGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReplicationGroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PrimaryClusterId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PrimaryClusterId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PrimaryClusterId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PrimaryClusterId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ECReplicationGroup (CreateReplicationGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.CreateReplicationGroupResponse, NewECReplicationGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PrimaryClusterId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AtRestEncryptionEnabled = this.AtRestEncryptionEnabled;
            context.AuthToken = this.AuthToken;
            context.AutomaticFailoverEnabled = this.AutomaticFailoverEnabled;
            context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            context.CacheNodeType = this.CacheNodeType;
            context.CacheParameterGroupName = this.CacheParameterGroupName;
            if (this.CacheSecurityGroupName != null)
            {
                context.CacheSecurityGroupName = new List<System.String>(this.CacheSecurityGroupName);
            }
            context.CacheSubnetGroupName = this.CacheSubnetGroupName;
            context.Engine = this.Engine;
            context.EngineVersion = this.EngineVersion;
            context.KmsKeyId = this.KmsKeyId;
            if (this.NodeGroupConfiguration != null)
            {
                context.NodeGroupConfiguration = new List<Amazon.ElastiCache.Model.NodeGroupConfiguration>(this.NodeGroupConfiguration);
            }
            context.NotificationTopicArn = this.NotificationTopicArn;
            context.NumCacheCluster = this.NumCacheCluster;
            context.NumNodeGroup = this.NumNodeGroup;
            context.Port = this.Port;
            if (this.PreferredCacheClusterAZs != null)
            {
                context.PreferredCacheClusterAZs = new List<System.String>(this.PreferredCacheClusterAZs);
            }
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            context.PrimaryClusterId = this.PrimaryClusterId;
            context.ReplicasPerNodeGroup = this.ReplicasPerNodeGroup;
            context.ReplicationGroupDescription = this.ReplicationGroupDescription;
            #if MODULAR
            if (this.ReplicationGroupDescription == null && ParameterWasBound(nameof(this.ReplicationGroupDescription)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationGroupDescription which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReplicationGroupId = this.ReplicationGroupId;
            #if MODULAR
            if (this.ReplicationGroupId == null && ParameterWasBound(nameof(this.ReplicationGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ElastiCache.Model.Tag>(this.Tag);
            }
            context.TransitEncryptionEnabled = this.TransitEncryptionEnabled;
            
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
            var request = new Amazon.ElastiCache.Model.CreateReplicationGroupRequest();
            
            if (cmdletContext.AtRestEncryptionEnabled != null)
            {
                request.AtRestEncryptionEnabled = cmdletContext.AtRestEncryptionEnabled.Value;
            }
            if (cmdletContext.AuthToken != null)
            {
                request.AuthToken = cmdletContext.AuthToken;
            }
            if (cmdletContext.AutomaticFailoverEnabled != null)
            {
                request.AutomaticFailoverEnabled = cmdletContext.AutomaticFailoverEnabled.Value;
            }
            if (cmdletContext.AutoMinorVersionUpgrade != null)
            {
                request.AutoMinorVersionUpgrade = cmdletContext.AutoMinorVersionUpgrade.Value;
            }
            if (cmdletContext.CacheNodeType != null)
            {
                request.CacheNodeType = cmdletContext.CacheNodeType;
            }
            if (cmdletContext.CacheParameterGroupName != null)
            {
                request.CacheParameterGroupName = cmdletContext.CacheParameterGroupName;
            }
            if (cmdletContext.CacheSecurityGroupName != null)
            {
                request.CacheSecurityGroupNames = cmdletContext.CacheSecurityGroupName;
            }
            if (cmdletContext.CacheSubnetGroupName != null)
            {
                request.CacheSubnetGroupName = cmdletContext.CacheSubnetGroupName;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.NodeGroupConfiguration != null)
            {
                request.NodeGroupConfiguration = cmdletContext.NodeGroupConfiguration;
            }
            if (cmdletContext.NotificationTopicArn != null)
            {
                request.NotificationTopicArn = cmdletContext.NotificationTopicArn;
            }
            if (cmdletContext.NumCacheCluster != null)
            {
                request.NumCacheClusters = cmdletContext.NumCacheCluster.Value;
            }
            if (cmdletContext.NumNodeGroup != null)
            {
                request.NumNodeGroups = cmdletContext.NumNodeGroup.Value;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.PreferredCacheClusterAZs != null)
            {
                request.PreferredCacheClusterAZs = cmdletContext.PreferredCacheClusterAZs;
            }
            if (cmdletContext.PreferredMaintenanceWindow != null)
            {
                request.PreferredMaintenanceWindow = cmdletContext.PreferredMaintenanceWindow;
            }
            if (cmdletContext.PrimaryClusterId != null)
            {
                request.PrimaryClusterId = cmdletContext.PrimaryClusterId;
            }
            if (cmdletContext.ReplicasPerNodeGroup != null)
            {
                request.ReplicasPerNodeGroup = cmdletContext.ReplicasPerNodeGroup.Value;
            }
            if (cmdletContext.ReplicationGroupDescription != null)
            {
                request.ReplicationGroupDescription = cmdletContext.ReplicationGroupDescription;
            }
            if (cmdletContext.ReplicationGroupId != null)
            {
                request.ReplicationGroupId = cmdletContext.ReplicationGroupId;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TransitEncryptionEnabled != null)
            {
                request.TransitEncryptionEnabled = cmdletContext.TransitEncryptionEnabled.Value;
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
        
        private Amazon.ElastiCache.Model.CreateReplicationGroupResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.CreateReplicationGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "CreateReplicationGroup");
            try
            {
                #if DESKTOP
                return client.CreateReplicationGroup(request);
                #elif CORECLR
                return client.CreateReplicationGroupAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AtRestEncryptionEnabled { get; set; }
            public System.String AuthToken { get; set; }
            public System.Boolean? AutomaticFailoverEnabled { get; set; }
            public System.Boolean? AutoMinorVersionUpgrade { get; set; }
            public System.String CacheNodeType { get; set; }
            public System.String CacheParameterGroupName { get; set; }
            public List<System.String> CacheSecurityGroupName { get; set; }
            public System.String CacheSubnetGroupName { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String KmsKeyId { get; set; }
            public List<Amazon.ElastiCache.Model.NodeGroupConfiguration> NodeGroupConfiguration { get; set; }
            public System.String NotificationTopicArn { get; set; }
            public System.Int32? NumCacheCluster { get; set; }
            public System.Int32? NumNodeGroup { get; set; }
            public System.Int32? Port { get; set; }
            public List<System.String> PreferredCacheClusterAZs { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.String PrimaryClusterId { get; set; }
            public System.Int32? ReplicasPerNodeGroup { get; set; }
            public System.String ReplicationGroupDescription { get; set; }
            public System.String ReplicationGroupId { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public List<System.String> SnapshotArn { get; set; }
            public System.String SnapshotName { get; set; }
            public System.Int32? SnapshotRetentionLimit { get; set; }
            public System.String SnapshotWindow { get; set; }
            public List<Amazon.ElastiCache.Model.Tag> Tag { get; set; }
            public System.Boolean? TransitEncryptionEnabled { get; set; }
            public System.Func<Amazon.ElastiCache.Model.CreateReplicationGroupResponse, NewECReplicationGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReplicationGroup;
        }
        
    }
}
