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
    /// Creates a cluster. All nodes in the cluster run the same protocol-compliant cache
    /// engine software, either Memcached, Valkey or Redis OSS.
    /// 
    ///  
    /// <para>
    /// This operation is not supported for Valkey or Redis OSS (cluster mode enabled) clusters.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ECCacheCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.CacheCluster")]
    [AWSCmdlet("Calls the Amazon ElastiCache CreateCacheCluster API operation.", Operation = new[] {"CreateCacheCluster"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.CreateCacheClusterResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.CacheCluster or Amazon.ElastiCache.Model.CreateCacheClusterResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.CacheCluster object.",
        "The service call response (type Amazon.ElastiCache.Model.CreateCacheClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewECCacheClusterCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AuthToken
        /// <summary>
        /// <para>
        /// <para><b>Reserved parameter.</b> The password used to access a password protected server.</para><para>Password constraints:</para><ul><li><para>Must be only printable ASCII characters.</para></li><li><para>Must be at least 16 characters and no more than 128 characters in length.</para></li><li><para>The only permitted printable special characters are !, &amp;, #, $, ^, &lt;, &gt;,
        /// and -. Other printable special characters cannot be used in the AUTH token.</para></li></ul><para>For more information, see <a href="http://redis.io/commands/AUTH">AUTH password</a>
        /// at http://redis.io/commands/AUTH.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthToken { get; set; }
        #endregion
        
        #region Parameter AutoMinorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para> If you are running Valkey 7.2 and above or Redis OSS engine version 6.0 and above,
        /// set this parameter to yes to opt-in to the next auto minor version upgrade campaign.
        /// This parameter is disabled for previous versions.  </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoMinorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter AZMode
        /// <summary>
        /// <para>
        /// <para>Specifies whether the nodes in this Memcached cluster are created in a single Availability
        /// Zone or created across multiple Availability Zones in the cluster's region.</para><para>This parameter is only supported for Memcached clusters.</para><para>If the <c>AZMode</c> and <c>PreferredAvailabilityZones</c> are not specified, ElastiCache
        /// assumes <c>single-az</c> mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElastiCache.AZMode")]
        public Amazon.ElastiCache.AZMode AZMode { get; set; }
        #endregion
        
        #region Parameter CacheClusterId
        /// <summary>
        /// <para>
        /// <para>The node group (shard) identifier. This parameter is stored as a lowercase string.</para><para><b>Constraints:</b></para><ul><li><para>A name must contain from 1 to 50 alphanumeric characters or hyphens.</para></li><li><para>The first character must be a letter.</para></li><li><para>A name cannot end with a hyphen or contain two consecutive hyphens.</para></li></ul>
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
        public System.String CacheClusterId { get; set; }
        #endregion
        
        #region Parameter CacheNodeType
        /// <summary>
        /// <para>
        /// <para>The compute and memory capacity of the nodes in the node group (shard).</para><para>The following node types are supported by ElastiCache. Generally speaking, the current
        /// generation types provide more memory and computational power at lower cost when compared
        /// to their equivalent previous generation counterparts.</para><ul><li><para>General purpose:</para><ul><li><para>Current generation: </para><para><b>M7g node types</b>: <c>cache.m7g.large</c>, <c>cache.m7g.xlarge</c>, <c>cache.m7g.2xlarge</c>,
        /// <c>cache.m7g.4xlarge</c>, <c>cache.m7g.8xlarge</c>, <c>cache.m7g.12xlarge</c>, <c>cache.m7g.16xlarge</c></para><note><para>For region availability, see <a href="https://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/CacheNodes.SupportedTypes.html#CacheNodes.SupportedTypesByRegion">Supported
        /// Node Types</a></para></note><para><b>M6g node types</b> (available only for Redis OSS engine version 5.0.6 onward and
        /// for Memcached engine version 1.5.16 onward): <c>cache.m6g.large</c>, <c>cache.m6g.xlarge</c>,
        /// <c>cache.m6g.2xlarge</c>, <c>cache.m6g.4xlarge</c>, <c>cache.m6g.8xlarge</c>, <c>cache.m6g.12xlarge</c>,
        /// <c>cache.m6g.16xlarge</c></para><para><b>M5 node types:</b><c>cache.m5.large</c>, <c>cache.m5.xlarge</c>, <c>cache.m5.2xlarge</c>,
        /// <c>cache.m5.4xlarge</c>, <c>cache.m5.12xlarge</c>, <c>cache.m5.24xlarge</c></para><para><b>M4 node types:</b><c>cache.m4.large</c>, <c>cache.m4.xlarge</c>, <c>cache.m4.2xlarge</c>,
        /// <c>cache.m4.4xlarge</c>, <c>cache.m4.10xlarge</c></para><para><b>T4g node types</b> (available only for Redis OSS engine version 5.0.6 onward and
        /// Memcached engine version 1.5.16 onward): <c>cache.t4g.micro</c>, <c>cache.t4g.small</c>,
        /// <c>cache.t4g.medium</c></para><para><b>T3 node types:</b><c>cache.t3.micro</c>, <c>cache.t3.small</c>, <c>cache.t3.medium</c></para><para><b>T2 node types:</b><c>cache.t2.micro</c>, <c>cache.t2.small</c>, <c>cache.t2.medium</c></para></li><li><para>Previous generation: (not recommended. Existing clusters are still supported but creation
        /// of new clusters is not supported for these types.)</para><para><b>T1 node types:</b><c>cache.t1.micro</c></para><para><b>M1 node types:</b><c>cache.m1.small</c>, <c>cache.m1.medium</c>, <c>cache.m1.large</c>,
        /// <c>cache.m1.xlarge</c></para><para><b>M3 node types:</b><c>cache.m3.medium</c>, <c>cache.m3.large</c>, <c>cache.m3.xlarge</c>,
        /// <c>cache.m3.2xlarge</c></para></li></ul></li><li><para>Compute optimized:</para><ul><li><para>Previous generation: (not recommended. Existing clusters are still supported but creation
        /// of new clusters is not supported for these types.)</para><para><b>C1 node types:</b><c>cache.c1.xlarge</c></para></li></ul></li><li><para>Memory optimized:</para><ul><li><para>Current generation: </para><para><b>R7g node types</b>: <c>cache.r7g.large</c>, <c>cache.r7g.xlarge</c>, <c>cache.r7g.2xlarge</c>,
        /// <c>cache.r7g.4xlarge</c>, <c>cache.r7g.8xlarge</c>, <c>cache.r7g.12xlarge</c>, <c>cache.r7g.16xlarge</c></para><note><para>For region availability, see <a href="https://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/CacheNodes.SupportedTypes.html#CacheNodes.SupportedTypesByRegion">Supported
        /// Node Types</a></para></note><para><b>R6g node types</b> (available only for Redis OSS engine version 5.0.6 onward and
        /// for Memcached engine version 1.5.16 onward): <c>cache.r6g.large</c>, <c>cache.r6g.xlarge</c>,
        /// <c>cache.r6g.2xlarge</c>, <c>cache.r6g.4xlarge</c>, <c>cache.r6g.8xlarge</c>, <c>cache.r6g.12xlarge</c>,
        /// <c>cache.r6g.16xlarge</c></para><para><b>R5 node types:</b><c>cache.r5.large</c>, <c>cache.r5.xlarge</c>, <c>cache.r5.2xlarge</c>,
        /// <c>cache.r5.4xlarge</c>, <c>cache.r5.12xlarge</c>, <c>cache.r5.24xlarge</c></para><para><b>R4 node types:</b><c>cache.r4.large</c>, <c>cache.r4.xlarge</c>, <c>cache.r4.2xlarge</c>,
        /// <c>cache.r4.4xlarge</c>, <c>cache.r4.8xlarge</c>, <c>cache.r4.16xlarge</c></para></li><li><para>Previous generation: (not recommended. Existing clusters are still supported but creation
        /// of new clusters is not supported for these types.)</para><para><b>M2 node types:</b><c>cache.m2.xlarge</c>, <c>cache.m2.2xlarge</c>, <c>cache.m2.4xlarge</c></para><para><b>R3 node types:</b><c>cache.r3.large</c>, <c>cache.r3.xlarge</c>, <c>cache.r3.2xlarge</c>,
        /// <c>cache.r3.4xlarge</c>, <c>cache.r3.8xlarge</c></para></li></ul></li></ul><para><b>Additional node type info</b></para><ul><li><para>All current generation instance types are created in Amazon VPC by default.</para></li><li><para>Valkey or Redis OSS append-only files (AOF) are not supported for T1 or T2 instances.</para></li><li><para>Valkey or Redis OSS Multi-AZ with automatic failover is not supported on T1 instances.</para></li><li><para>The configuration variables <c>appendonly</c> and <c>appendfsync</c> are not supported
        /// on Valkey, or on Redis OSS version 2.8.22 and later.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CacheNodeType { get; set; }
        #endregion
        
        #region Parameter CacheParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the parameter group to associate with this cluster. If this argument is
        /// omitted, the default parameter group for the specified engine is used. You cannot
        /// use any parameter group which has <c>cluster-enabled='yes'</c> when creating a cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CacheParameterGroupName { get; set; }
        #endregion
        
        #region Parameter CacheSecurityGroupName
        /// <summary>
        /// <para>
        /// <para>A list of security group names to associate with this cluster.</para><para>Use this parameter only when you are creating a cluster outside of an Amazon Virtual
        /// Private Cloud (Amazon VPC).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheSecurityGroupNames")]
        public System.String[] CacheSecurityGroupName { get; set; }
        #endregion
        
        #region Parameter CacheSubnetGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the subnet group to be used for the cluster.</para><para>Use this parameter only when you are creating a cluster in an Amazon Virtual Private
        /// Cloud (Amazon VPC).</para><important><para>If you're going to launch your cluster in an Amazon VPC, you need to create a subnet
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
        /// <para>The name of the cache engine to be used for this cluster.</para><para>Valid values for this parameter are: <c>memcached</c> | <c>redis</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The version number of the cache engine to be used for this cluster. To view the supported
        /// cache engine versions, use the DescribeCacheEngineVersions operation.</para><para><b>Important:</b> You can upgrade to a newer engine version (see <a href="https://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/SelectEngine.html#VersionManagement">Selecting
        /// a Cache Engine and Version</a>), but you cannot downgrade to an earlier engine version.
        /// If you want to use an earlier engine version, you must delete the existing cluster
        /// or replication group and create it anew with the earlier engine version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter IpDiscovery
        /// <summary>
        /// <para>
        /// <para>The network type you choose when modifying a cluster, either <c>ipv4</c> | <c>ipv6</c>.
        /// IPv6 is supported for workloads using Valkey 7.2 and above, Redis OSS engine version
        /// 6.2 and above or Memcached engine version 1.6.6 and above on all instances built on
        /// the <a href="http://aws.amazon.com/ec2/nitro/">Nitro system</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElastiCache.IpDiscovery")]
        public Amazon.ElastiCache.IpDiscovery IpDiscovery { get; set; }
        #endregion
        
        #region Parameter LogDeliveryConfiguration
        /// <summary>
        /// <para>
        /// <para>Specifies the destination, format and type of the logs. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogDeliveryConfigurations")]
        public Amazon.ElastiCache.Model.LogDeliveryConfigurationRequest[] LogDeliveryConfiguration { get; set; }
        #endregion
        
        #region Parameter NetworkType
        /// <summary>
        /// <para>
        /// <para>Must be either <c>ipv4</c> | <c>ipv6</c> | <c>dual_stack</c>. IPv6 is supported for
        /// workloads using Valkey 7.2 and above, Redis OSS engine version 6.2 and above or Memcached
        /// engine version 1.6.6 and above on all instances built on the <a href="http://aws.amazon.com/ec2/nitro/">Nitro
        /// system</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElastiCache.NetworkType")]
        public Amazon.ElastiCache.NetworkType NetworkType { get; set; }
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
        
        #region Parameter NumCacheNode
        /// <summary>
        /// <para>
        /// <para>The initial number of cache nodes that the cluster has.</para><para>For clusters running Valkey or Redis OSS, this value must be 1. For clusters running
        /// Memcached, this value must be between 1 and 40.</para><para>If you need more than 40 nodes for your Memcached cluster, please fill out the ElastiCache
        /// Limit Increase Request form at <a href="http://aws.amazon.com/contact-us/elasticache-node-limit-request/">http://aws.amazon.com/contact-us/elasticache-node-limit-request/</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NumCacheNodes")]
        public System.Int32? NumCacheNode { get; set; }
        #endregion
        
        #region Parameter OutpostMode
        /// <summary>
        /// <para>
        /// <para>Specifies whether the nodes in the cluster are created in a single outpost or across
        /// multiple outposts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElastiCache.OutpostMode")]
        public Amazon.ElastiCache.OutpostMode OutpostMode { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port number on which each of the cache nodes accepts connections.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter PreferredAvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The EC2 Availability Zone in which the cluster is created.</para><para>All nodes belonging to this cluster are placed in the preferred Availability Zone.
        /// If you want to create your nodes across multiple Availability Zones, use <c>PreferredAvailabilityZones</c>.</para><para>Default: System chosen Availability Zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredAvailabilityZone { get; set; }
        #endregion
        
        #region Parameter PreferredAvailabilityZoneSet
        /// <summary>
        /// <para>
        /// <para>A list of the Availability Zones in which cache nodes are created. The order of the
        /// zones in the list is not important.</para><para>This option is only supported on Memcached.</para><note><para>If you are creating your cluster in an Amazon VPC (recommended) you can only locate
        /// nodes in Availability Zones that are associated with the subnets in the selected subnet
        /// group.</para><para>The number of Availability Zones listed must equal the value of <c>NumCacheNodes</c>.</para></note><para>If you want all the nodes in the same Availability Zone, use <c>PreferredAvailabilityZone</c>
        /// instead, or repeat the Availability Zone multiple times in the list.</para><para>Default: System chosen Availability Zones.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PreferredAvailabilityZones")]
        public System.String[] PreferredAvailabilityZoneSet { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>Specifies the weekly time range during which maintenance on the cluster is performed.
        /// It is specified as a range in the format ddd:hh24:mi-ddd:hh24:mi (24H Clock UTC).
        /// The minimum maintenance window is a 60 minute period. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter PreferredOutpostArn
        /// <summary>
        /// <para>
        /// <para>The outpost ARN in which the cache cluster is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredOutpostArn { get; set; }
        #endregion
        
        #region Parameter PreferredOutpostArnSet
        /// <summary>
        /// <para>
        /// <para>The outpost ARNs in which the cache cluster is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PreferredOutpostArns")]
        public System.String[] PreferredOutpostArnSet { get; set; }
        #endregion
        
        #region Parameter ReplicationGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the replication group to which this cluster should belong. If this parameter
        /// is specified, the cluster is added to the specified replication group as a read replica;
        /// otherwise, the cluster is a standalone primary that is not part of any replication
        /// group.</para><para>If the specified replication group is Multi-AZ enabled and the Availability Zone is
        /// not specified, the cluster is created in Availability Zones that provide the best
        /// spread of read replicas across Availability Zones.</para><note><para>This parameter is only valid if the <c>Engine</c> parameter is <c>redis</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReplicationGroupId { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>One or more VPC security groups associated with the cluster.</para><para>Use this parameter only when you are creating a cluster in an Amazon Virtual Private
        /// Cloud (Amazon VPC).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SnapshotArn
        /// <summary>
        /// <para>
        /// <para>A single-element string list containing an Amazon Resource Name (ARN) that uniquely
        /// identifies a Valkey or Redis OSS RDB snapshot file stored in Amazon S3. The snapshot
        /// file is used to populate the node group (shard). The Amazon S3 object name in the
        /// ARN cannot contain any commas.</para><note><para>This parameter is only valid if the <c>Engine</c> parameter is <c>redis</c>.</para></note><para>Example of an Amazon S3 ARN: <c>arn:aws:s3:::my_bucket/snapshot1.rdb</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SnapshotArns")]
        public System.String[] SnapshotArn { get; set; }
        #endregion
        
        #region Parameter SnapshotName
        /// <summary>
        /// <para>
        /// <para>The name of a Valkey or Redis OSS snapshot from which to restore data into the new
        /// node group (shard). The snapshot status changes to <c>restoring</c> while the new
        /// node group (shard) is being created.</para><note><para>This parameter is only valid if the <c>Engine</c> parameter is <c>redis</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotName { get; set; }
        #endregion
        
        #region Parameter SnapshotRetentionLimit
        /// <summary>
        /// <para>
        /// <para>The number of days for which ElastiCache retains automatic snapshots before deleting
        /// them. For example, if you set <c>SnapshotRetentionLimit</c> to 5, a snapshot taken
        /// today is retained for 5 days before being deleted.</para><note><para>This parameter is only valid if the <c>Engine</c> parameter is <c>redis</c>.</para></note><para>Default: 0 (i.e., automatic backups are disabled for this cache cluster).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SnapshotRetentionLimit { get; set; }
        #endregion
        
        #region Parameter SnapshotWindow
        /// <summary>
        /// <para>
        /// <para>The daily time range (in UTC) during which ElastiCache begins taking a daily snapshot
        /// of your node group (shard).</para><para>Example: <c>05:00-09:00</c></para><para>If you do not specify this parameter, ElastiCache automatically chooses an appropriate
        /// time range.</para><note><para>This parameter is only valid if the <c>Engine</c> parameter is <c>redis</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotWindow { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to be added to this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ElastiCache.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TransitEncryptionEnabled
        /// <summary>
        /// <para>
        /// <para>A flag that enables in-transit encryption when set to true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TransitEncryptionEnabled { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CacheCluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.CreateCacheClusterResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.CreateCacheClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CacheCluster";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CacheClusterId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ECCacheCluster (CreateCacheCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.CreateCacheClusterResponse, NewECCacheClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AuthToken = this.AuthToken;
            context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            context.AZMode = this.AZMode;
            context.CacheClusterId = this.CacheClusterId;
            #if MODULAR
            if (this.CacheClusterId == null && ParameterWasBound(nameof(this.CacheClusterId)))
            {
                WriteWarning("You are passing $null as a value for parameter CacheClusterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CacheNodeType = this.CacheNodeType;
            context.CacheParameterGroupName = this.CacheParameterGroupName;
            if (this.CacheSecurityGroupName != null)
            {
                context.CacheSecurityGroupName = new List<System.String>(this.CacheSecurityGroupName);
            }
            context.CacheSubnetGroupName = this.CacheSubnetGroupName;
            context.Engine = this.Engine;
            context.EngineVersion = this.EngineVersion;
            context.IpDiscovery = this.IpDiscovery;
            if (this.LogDeliveryConfiguration != null)
            {
                context.LogDeliveryConfiguration = new List<Amazon.ElastiCache.Model.LogDeliveryConfigurationRequest>(this.LogDeliveryConfiguration);
            }
            context.NetworkType = this.NetworkType;
            context.NotificationTopicArn = this.NotificationTopicArn;
            context.NumCacheNode = this.NumCacheNode;
            context.OutpostMode = this.OutpostMode;
            context.Port = this.Port;
            context.PreferredAvailabilityZone = this.PreferredAvailabilityZone;
            if (this.PreferredAvailabilityZoneSet != null)
            {
                context.PreferredAvailabilityZoneSet = new List<System.String>(this.PreferredAvailabilityZoneSet);
            }
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            context.PreferredOutpostArn = this.PreferredOutpostArn;
            if (this.PreferredOutpostArnSet != null)
            {
                context.PreferredOutpostArnSet = new List<System.String>(this.PreferredOutpostArnSet);
            }
            context.ReplicationGroupId = this.ReplicationGroupId;
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
            var request = new Amazon.ElastiCache.Model.CreateCacheClusterRequest();
            
            if (cmdletContext.AuthToken != null)
            {
                request.AuthToken = cmdletContext.AuthToken;
            }
            if (cmdletContext.AutoMinorVersionUpgrade != null)
            {
                request.AutoMinorVersionUpgrade = cmdletContext.AutoMinorVersionUpgrade.Value;
            }
            if (cmdletContext.AZMode != null)
            {
                request.AZMode = cmdletContext.AZMode;
            }
            if (cmdletContext.CacheClusterId != null)
            {
                request.CacheClusterId = cmdletContext.CacheClusterId;
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
            if (cmdletContext.IpDiscovery != null)
            {
                request.IpDiscovery = cmdletContext.IpDiscovery;
            }
            if (cmdletContext.LogDeliveryConfiguration != null)
            {
                request.LogDeliveryConfigurations = cmdletContext.LogDeliveryConfiguration;
            }
            if (cmdletContext.NetworkType != null)
            {
                request.NetworkType = cmdletContext.NetworkType;
            }
            if (cmdletContext.NotificationTopicArn != null)
            {
                request.NotificationTopicArn = cmdletContext.NotificationTopicArn;
            }
            if (cmdletContext.NumCacheNode != null)
            {
                request.NumCacheNodes = cmdletContext.NumCacheNode.Value;
            }
            if (cmdletContext.OutpostMode != null)
            {
                request.OutpostMode = cmdletContext.OutpostMode;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.PreferredAvailabilityZone != null)
            {
                request.PreferredAvailabilityZone = cmdletContext.PreferredAvailabilityZone;
            }
            if (cmdletContext.PreferredAvailabilityZoneSet != null)
            {
                request.PreferredAvailabilityZones = cmdletContext.PreferredAvailabilityZoneSet;
            }
            if (cmdletContext.PreferredMaintenanceWindow != null)
            {
                request.PreferredMaintenanceWindow = cmdletContext.PreferredMaintenanceWindow;
            }
            if (cmdletContext.PreferredOutpostArn != null)
            {
                request.PreferredOutpostArn = cmdletContext.PreferredOutpostArn;
            }
            if (cmdletContext.PreferredOutpostArnSet != null)
            {
                request.PreferredOutpostArns = cmdletContext.PreferredOutpostArnSet;
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
        
        private Amazon.ElastiCache.Model.CreateCacheClusterResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.CreateCacheClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "CreateCacheCluster");
            try
            {
                #if DESKTOP
                return client.CreateCacheCluster(request);
                #elif CORECLR
                return client.CreateCacheClusterAsync(request).GetAwaiter().GetResult();
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
            public System.String AuthToken { get; set; }
            public System.Boolean? AutoMinorVersionUpgrade { get; set; }
            public Amazon.ElastiCache.AZMode AZMode { get; set; }
            public System.String CacheClusterId { get; set; }
            public System.String CacheNodeType { get; set; }
            public System.String CacheParameterGroupName { get; set; }
            public List<System.String> CacheSecurityGroupName { get; set; }
            public System.String CacheSubnetGroupName { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineVersion { get; set; }
            public Amazon.ElastiCache.IpDiscovery IpDiscovery { get; set; }
            public List<Amazon.ElastiCache.Model.LogDeliveryConfigurationRequest> LogDeliveryConfiguration { get; set; }
            public Amazon.ElastiCache.NetworkType NetworkType { get; set; }
            public System.String NotificationTopicArn { get; set; }
            public System.Int32? NumCacheNode { get; set; }
            public Amazon.ElastiCache.OutpostMode OutpostMode { get; set; }
            public System.Int32? Port { get; set; }
            public System.String PreferredAvailabilityZone { get; set; }
            public List<System.String> PreferredAvailabilityZoneSet { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.String PreferredOutpostArn { get; set; }
            public List<System.String> PreferredOutpostArnSet { get; set; }
            public System.String ReplicationGroupId { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public List<System.String> SnapshotArn { get; set; }
            public System.String SnapshotName { get; set; }
            public System.Int32? SnapshotRetentionLimit { get; set; }
            public System.String SnapshotWindow { get; set; }
            public List<Amazon.ElastiCache.Model.Tag> Tag { get; set; }
            public System.Boolean? TransitEncryptionEnabled { get; set; }
            public System.Func<Amazon.ElastiCache.Model.CreateCacheClusterResponse, NewECCacheClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CacheCluster;
        }
        
    }
}
