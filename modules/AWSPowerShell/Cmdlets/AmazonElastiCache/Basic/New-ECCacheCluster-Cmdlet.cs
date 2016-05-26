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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// The <i>CreateCacheCluster</i> action creates a cache cluster. All nodes in the cache
    /// cluster run the same protocol-compliant cache engine software, either Memcached or
    /// Redis.
    /// </summary>
    [Cmdlet("New", "ECCacheCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.CacheCluster")]
    [AWSCmdlet("Invokes the CreateCacheCluster operation against Amazon ElastiCache.", Operation = new[] {"CreateCacheCluster"})]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.CacheCluster",
        "This cmdlet returns a CacheCluster object.",
        "The service call response (type Amazon.ElastiCache.Model.CreateCacheClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewECCacheClusterCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        #region Parameter AutoMinorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>This parameter is currently disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AutoMinorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter AZMode
        /// <summary>
        /// <para>
        /// <para>Specifies whether the nodes in this Memcached node group are created in a single Availability
        /// Zone or created across multiple Availability Zones in the cluster's region.</para><para>This parameter is only supported for Memcached cache clusters.</para><para>If the <code>AZMode</code> and <code>PreferredAvailabilityZones</code> are not specified,
        /// ElastiCache assumes <code>single-az</code> mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ElastiCache.AZMode")]
        public Amazon.ElastiCache.AZMode AZMode { get; set; }
        #endregion
        
        #region Parameter CacheClusterId
        /// <summary>
        /// <para>
        /// <para>The node group identifier. This parameter is stored as a lowercase string.</para><para>Constraints:</para><ul><li>A name must contain from 1 to 20 alphanumeric characters or hyphens.</li><li>The first character must be a letter.</li><li>A name cannot end with a hyphen
        /// or contain two consecutive hyphens.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CacheClusterId { get; set; }
        #endregion
        
        #region Parameter CacheNodeType
        /// <summary>
        /// <para>
        /// <para>The compute and memory capacity of the nodes in the node group.</para><para>Valid node types are as follows:</para><ul><li>General purpose: <ul><li>Current generation: <code>cache.t2.micro</code>,
        /// <code>cache.t2.small</code>, <code>cache.t2.medium</code>, <code>cache.m3.medium</code>,
        /// <code>cache.m3.large</code>, <code>cache.m3.xlarge</code>, <code>cache.m3.2xlarge</code></li><li>Previous generation: <code>cache.t1.micro</code>, <code>cache.m1.small</code>,
        /// <code>cache.m1.medium</code>, <code>cache.m1.large</code>, <code>cache.m1.xlarge</code></li></ul></li><li>Compute optimized: <code>cache.c1.xlarge</code></li><li>Memory optimized
        /// <ul><li>Current generation: <code>cache.r3.large</code>, <code>cache.r3.xlarge</code>,
        /// <code>cache.r3.2xlarge</code>, <code>cache.r3.4xlarge</code>, <code>cache.r3.8xlarge</code></li><li>Previous generation: <code>cache.m2.xlarge</code>, <code>cache.m2.2xlarge</code>,
        /// <code>cache.m2.4xlarge</code></li></ul></li></ul><para><b>Notes:</b></para><ul><li>All t2 instances are created in an Amazon Virtual Private Cloud (VPC).</li><li>Redis backup/restore is not supported for t2 instances.</li><li>Redis Append-only
        /// files (AOF) functionality is not supported for t1 or t2 instances.</li></ul><para>For a complete listing of cache node types and specifications, see <a href="http://aws.amazon.com/elasticache/details">Amazon
        /// ElastiCache Product Features and Details</a> and <a href="http://docs.aws.amazon.com/AmazonElastiCache/latest/UserGuide/CacheParameterGroups.Memcached.html#CacheParameterGroups.Memcached.NodeSpecific">Cache
        /// Node Type-Specific Parameters for Memcached</a> or <a href="http://docs.aws.amazon.com/AmazonElastiCache/latest/UserGuide/CacheParameterGroups.Redis.html#CacheParameterGroups.Redis.NodeSpecific">Cache
        /// Node Type-Specific Parameters for Redis</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CacheNodeType { get; set; }
        #endregion
        
        #region Parameter CacheParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the parameter group to associate with this cache cluster. If this argument
        /// is omitted, the default parameter group for the specified engine is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CacheParameterGroupName { get; set; }
        #endregion
        
        #region Parameter CacheSecurityGroupName
        /// <summary>
        /// <para>
        /// <para>A list of security group names to associate with this cache cluster.</para><para>Use this parameter only when you are creating a cache cluster outside of an Amazon
        /// Virtual Private Cloud (VPC).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheSecurityGroupNames")]
        public System.String[] CacheSecurityGroupName { get; set; }
        #endregion
        
        #region Parameter CacheSubnetGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the subnet group to be used for the cache cluster.</para><para>Use this parameter only when you are creating a cache cluster in an Amazon Virtual
        /// Private Cloud (VPC).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CacheSubnetGroupName { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The name of the cache engine to be used for this cache cluster.</para><para>Valid values for this parameter are:</para><para><code>memcached</code> | <code>redis</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The version number of the cache engine to be used for this cache cluster. To view
        /// the supported cache engine versions, use the <i>DescribeCacheEngineVersions</i> action.</para><para><b>Important:</b> You can upgrade to a newer engine version (see <a href="http://docs.aws.amazon.com/AmazonElastiCache/latest/UserGuide/SelectEngine.html#VersionManagement">Selecting
        /// a Cache Engine and Version</a>), but you cannot downgrade to an earlier engine version.
        /// If you want to use an earlier engine version, you must delete the existing cache cluster
        /// or replication group and create it anew with the earlier engine version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter NotificationTopicArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Simple Notification Service (SNS) topic
        /// to which notifications will be sent.</para><note>The Amazon SNS topic owner must be the same as the cache cluster owner.</note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NotificationTopicArn { get; set; }
        #endregion
        
        #region Parameter NumCacheNode
        /// <summary>
        /// <para>
        /// <para>The initial number of cache nodes that the cache cluster will have.</para><para>For clusters running Redis, this value must be 1. For clusters running Memcached,
        /// this value must be between 1 and 20.</para><para>If you need more than 20 nodes for your Memcached cluster, please fill out the ElastiCache
        /// Limit Increase Request form at <a href="http://aws.amazon.com/contact-us/elasticache-node-limit-request/">http://aws.amazon.com/contact-us/elasticache-node-limit-request/</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NumCacheNodes")]
        public System.Int32 NumCacheNode { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port number on which each of the cache nodes will accept connections.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Port { get; set; }
        #endregion
        
        #region Parameter PreferredAvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The EC2 Availability Zone in which the cache cluster will be created.</para><para>All nodes belonging to this Memcached cache cluster are placed in the preferred Availability
        /// Zone. If you want to create your nodes across multiple Availability Zones, use <code>PreferredAvailabilityZones</code>.</para><para>Default: System chosen Availability Zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreferredAvailabilityZone { get; set; }
        #endregion
        
        #region Parameter PreferredAvailabilityZoneSet
        /// <summary>
        /// <para>
        /// <para>A list of the Availability Zones in which cache nodes will be created. The order of
        /// the zones in the list is not important.</para><para>This option is only supported on Memcached.</para><note><para>If you are creating your cache cluster in an Amazon VPC (recommended) you can only
        /// locate nodes in Availability Zones that are associated with the subnets in the selected
        /// subnet group.</para><para>The number of Availability Zones listed must equal the value of <code>NumCacheNodes</code>.</para></note><para>If you want all the nodes in the same Availability Zone, use <code>PreferredAvailabilityZone</code>
        /// instead, or repeat the Availability Zone multiple times in the list.</para><para>Default: System chosen Availability Zones.</para><para>Example: One Memcached node in each of three different Availability Zones: <code><![CDATA[PreferredAvailabilityZones.member.1=us-west-2a&amp;PreferredAvailabilityZones.member.2=us-west-2b&amp;PreferredAvailabilityZones.member.3=us-west-2c]]></code></para><para>Example: All three Memcached nodes in one Availability Zone: <code><![CDATA[PreferredAvailabilityZones.member.1=us-west-2a&amp;PreferredAvailabilityZones.member.2=us-west-2a&amp;PreferredAvailabilityZones.member.3=us-west-2a]]></code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("PreferredAvailabilityZones")]
        public System.String[] PreferredAvailabilityZoneSet { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>Specifies the weekly time range during which maintenance on the cache cluster is performed.
        /// It is specified as a range in the format ddd:hh24:mi-ddd:hh24:mi (24H Clock UTC).
        /// The minimum maintenance window is a 60 minute period. Valid values for <code>ddd</code>
        /// are:</para><ul><li><code>sun</code></li><li><code>mon</code></li><li><code>tue</code></li><li><code>wed</code></li><li><code>thu</code></li><li><code>fri</code></li><li><code>sat</code></li></ul><para>Example: <code>sun:05:00-sun:09:00</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter ReplicationGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the replication group to which this cache cluster should belong. If this
        /// parameter is specified, the cache cluster will be added to the specified replication
        /// group as a read replica; otherwise, the cache cluster will be a standalone primary
        /// that is not part of any replication group.</para><para>If the specified replication group is Multi-AZ enabled and the availability zone is
        /// not specified, the cache cluster will be created in availability zones that provide
        /// the best spread of read replicas across availability zones.</para><para><b>Note:</b> This parameter is only valid if the <code>Engine</code> parameter is
        /// <code>redis</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReplicationGroupId { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>One or more VPC security groups associated with the cache cluster.</para><para>Use this parameter only when you are creating a cache cluster in an Amazon Virtual
        /// Private Cloud (VPC).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SnapshotArn
        /// <summary>
        /// <para>
        /// <para>A single-element string list containing an Amazon Resource Name (ARN) that uniquely
        /// identifies a Redis RDB snapshot file stored in Amazon S3. The snapshot file will be
        /// used to populate the node group. The Amazon S3 object name in the ARN cannot contain
        /// any commas.</para><para><b>Note:</b> This parameter is only valid if the <code>Engine</code> parameter is
        /// <code>redis</code>.</para><para>Example of an Amazon S3 ARN: <code>arn:aws:s3:::my_bucket/snapshot1.rdb</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SnapshotArns")]
        public System.String[] SnapshotArn { get; set; }
        #endregion
        
        #region Parameter SnapshotName
        /// <summary>
        /// <para>
        /// <para>The name of a snapshot from which to restore data into the new node group. The snapshot
        /// status changes to <code>restoring</code> while the new node group is being created.</para><para><b>Note:</b> This parameter is only valid if the <code>Engine</code> parameter is
        /// <code>redis</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotName { get; set; }
        #endregion
        
        #region Parameter SnapshotRetentionLimit
        /// <summary>
        /// <para>
        /// <para>The number of days for which ElastiCache will retain automatic snapshots before deleting
        /// them. For example, if you set <code>SnapshotRetentionLimit</code> to 5, then a snapshot
        /// that was taken today will be retained for 5 days before being deleted.</para><para><b>Note:</b> This parameter is only valid if the <code>Engine</code> parameter is
        /// <code>redis</code>.</para><para>Default: 0 (i.e., automatic backups are disabled for this cache cluster).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 SnapshotRetentionLimit { get; set; }
        #endregion
        
        #region Parameter SnapshotWindow
        /// <summary>
        /// <para>
        /// <para>The daily time range (in UTC) during which ElastiCache will begin taking a daily snapshot
        /// of your node group.</para><para>Example: <code>05:00-09:00</code></para><para>If you do not specify this parameter, then ElastiCache will automatically choose an
        /// appropriate time range.</para><para><b>Note:</b> This parameter is only valid if the <code>Engine</code> parameter is
        /// <code>redis</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SnapshotWindow { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of cost allocation tags to be added to this resource. A tag is a key-value
        /// pair. A tag key must be accompanied by a tag value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.ElastiCache.Model.Tag[] Tag { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CacheClusterId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ECCacheCluster (CreateCacheCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("AutoMinorVersionUpgrade"))
                context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            context.AZMode = this.AZMode;
            context.CacheClusterId = this.CacheClusterId;
            context.CacheNodeType = this.CacheNodeType;
            context.CacheParameterGroupName = this.CacheParameterGroupName;
            if (this.CacheSecurityGroupName != null)
            {
                context.CacheSecurityGroupNames = new List<System.String>(this.CacheSecurityGroupName);
            }
            context.CacheSubnetGroupName = this.CacheSubnetGroupName;
            context.Engine = this.Engine;
            context.EngineVersion = this.EngineVersion;
            context.NotificationTopicArn = this.NotificationTopicArn;
            if (ParameterWasBound("NumCacheNode"))
                context.NumCacheNodes = this.NumCacheNode;
            if (ParameterWasBound("Port"))
                context.Port = this.Port;
            context.PreferredAvailabilityZone = this.PreferredAvailabilityZone;
            if (this.PreferredAvailabilityZoneSet != null)
            {
                context.PreferredAvailabilityZoneSet = new List<System.String>(this.PreferredAvailabilityZoneSet);
            }
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            context.ReplicationGroupId = this.ReplicationGroupId;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupIds = new List<System.String>(this.SecurityGroupId);
            }
            if (this.SnapshotArn != null)
            {
                context.SnapshotArns = new List<System.String>(this.SnapshotArn);
            }
            context.SnapshotName = this.SnapshotName;
            if (ParameterWasBound("SnapshotRetentionLimit"))
                context.SnapshotRetentionLimit = this.SnapshotRetentionLimit;
            context.SnapshotWindow = this.SnapshotWindow;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.ElastiCache.Model.Tag>(this.Tag);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ElastiCache.Model.CreateCacheClusterRequest();
            
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
            if (cmdletContext.CacheSecurityGroupNames != null)
            {
                request.CacheSecurityGroupNames = cmdletContext.CacheSecurityGroupNames;
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
            if (cmdletContext.NotificationTopicArn != null)
            {
                request.NotificationTopicArn = cmdletContext.NotificationTopicArn;
            }
            if (cmdletContext.NumCacheNodes != null)
            {
                request.NumCacheNodes = cmdletContext.NumCacheNodes.Value;
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
            if (cmdletContext.ReplicationGroupId != null)
            {
                request.ReplicationGroupId = cmdletContext.ReplicationGroupId;
            }
            if (cmdletContext.SecurityGroupIds != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupIds;
            }
            if (cmdletContext.SnapshotArns != null)
            {
                request.SnapshotArns = cmdletContext.SnapshotArns;
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
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.CacheCluster;
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
        
        private static Amazon.ElastiCache.Model.CreateCacheClusterResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.CreateCacheClusterRequest request)
        {
            return client.CreateCacheCluster(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.Boolean? AutoMinorVersionUpgrade { get; set; }
            public Amazon.ElastiCache.AZMode AZMode { get; set; }
            public System.String CacheClusterId { get; set; }
            public System.String CacheNodeType { get; set; }
            public System.String CacheParameterGroupName { get; set; }
            public List<System.String> CacheSecurityGroupNames { get; set; }
            public System.String CacheSubnetGroupName { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String NotificationTopicArn { get; set; }
            public System.Int32? NumCacheNodes { get; set; }
            public System.Int32? Port { get; set; }
            public System.String PreferredAvailabilityZone { get; set; }
            public List<System.String> PreferredAvailabilityZoneSet { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.String ReplicationGroupId { get; set; }
            public List<System.String> SecurityGroupIds { get; set; }
            public List<System.String> SnapshotArns { get; set; }
            public System.String SnapshotName { get; set; }
            public System.Int32? SnapshotRetentionLimit { get; set; }
            public System.String SnapshotWindow { get; set; }
            public List<Amazon.ElastiCache.Model.Tag> Tags { get; set; }
        }
        
    }
}
