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
    /// The <i>CreateReplicationGroup</i> action creates a replication group. A replication
    /// group is a collection of cache clusters, where one of the cache clusters is a read/write
    /// primary and the others are read-only replicas. Writes to the primary are automatically
    /// propagated to the replicas.
    /// 
    ///  
    /// <para>
    /// When you create a replication group, you must specify an existing cache cluster that
    /// is in the primary role. When the replication group has been successfully created,
    /// you can add one or more read replica replicas to it, up to a total of five read replicas.
    /// </para><para><b>Note:</b> This action is valid only for Redis.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ECReplicationGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.ReplicationGroup")]
    [AWSCmdlet("Invokes the CreateReplicationGroup operation against Amazon ElastiCache.", Operation = new[] {"CreateReplicationGroup"})]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ReplicationGroup",
        "This cmdlet returns a ReplicationGroup object.",
        "The service call response (type CreateReplicationGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewECReplicationGroupCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Specifies whether a read-only replica will be automatically promoted to read/write
        /// primary if the existing primary fails.</para><para>If <code>true</code>, Multi-AZ is enabled for this replication group. If <code>false</code>,
        /// Multi-AZ is disabled for this replication group.</para><para>Default: false</para><note><para>ElastiCache Multi-AZ replication groups is not supported on:</para><ul><li>Redis versions earlier than 2.8.6.</li><li>T1 and T2 cache node types.</li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean AutomaticFailoverEnabled { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>This parameter is currently disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean AutoMinorVersionUpgrade { get; set; }
        
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
        public String CacheNodeType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the parameter group to associate with this replication group. If this
        /// argument is omitted, the default cache parameter group for the specified engine is
        /// used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String CacheParameterGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of cache security group names to associate with this replication group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheSecurityGroupNames")]
        public System.String[] CacheSecurityGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the cache subnet group to be used for the replication group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String CacheSubnetGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the cache engine to be used for the cache clusters in this replication
        /// group.</para><para>Default: redis</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String Engine { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The version number of the cache engine to be used for the cache clusters in this replication
        /// group. To view the supported cache engine versions, use the <i>DescribeCacheEngineVersions</i>
        /// action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String EngineVersion { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Simple Notification Service (SNS) topic
        /// to which notifications will be sent.</para><note>The Amazon SNS topic owner must be the same as the cache cluster owner.</note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NotificationTopicArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The number of cache clusters this replication group will initially have.</para><para>If <i>Multi-AZ</i> is <code>enabled</code>, the value of this parameter must be at
        /// least 2.</para><para>The maximum permitted value for <i>NumCacheClusters</i> is 6 (primary plus 5 replicas).
        /// If you need to exceed this limit, please fill out the ElastiCache Limit Increase Request
        /// form at <a href="http://aws.amazon.com/contact-us/elasticache-node-limit-request">http://aws.amazon.com/contact-us/elasticache-node-limit-request</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NumCacheClusters")]
        public Int32 NumCacheCluster { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The port number on which each member of the replication group will accept connections.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 Port { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of EC2 availability zones in which the replication group's cache clusters will
        /// be created. The order of the availability zones in the list is not important.</para><note>If you are creating your replication group in an Amazon VPC (recommended),
        /// you can only locate cache clusters in availability zones associated with the subnets
        /// in the selected subnet group. 
        /// <para>The number of availability zones listed must equal the value of <i>NumCacheClusters</i>.</para></note><para>Default: system chosen availability zones.</para><para>Example: One Redis cache cluster in each of three availability zones. PreferredAvailabilityZones.member.1=us-west-2a
        /// PreferredAvailabilityZones.member.2=us-west-2c PreferredAvailabilityZones.member.3=us-west-2c</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] PreferredCacheClusterAZs { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specifies the weekly time range during which maintenance on the cache cluster is performed.
        /// It is specified as a range in the format ddd:hh24:mi-ddd:hh24:mi (24H Clock UTC).
        /// The minimum maintenance window is a 60 minute period. Valid values for <code>ddd</code>
        /// are:</para><ul><li><code>sun</code></li><li><code>mon</code></li><li><code>tue</code></li><li><code>wed</code></li><li><code>thu</code></li><li><code>fri</code></li><li><code>sat</code></li></ul><para>Example: <code>sun:05:00-sun:09:00</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String PreferredMaintenanceWindow { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The identifier of the cache cluster that will serve as the primary for this replication
        /// group. This cache cluster must already exist and have a status of <i>available</i>.</para><para>This parameter is not required if <i>NumCacheClusters</i> is specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String PrimaryClusterId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A user-created description for the replication group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String ReplicationGroupDescription { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The replication group identifier. This parameter is stored as a lowercase string.</para><para>Constraints:</para><ul><li>A name must contain from 1 to 20 alphanumeric characters or hyphens.</li><li>The first character must be a letter.</li><li>A name cannot end with a hyphen
        /// or contain two consecutive hyphens.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String ReplicationGroupId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>One or more Amazon VPC security groups associated with this replication group.</para><para>Use this parameter only when you are creating a replication group in an Amazon Virtual
        /// Private Cloud (VPC).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        
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
        
        /// <summary>
        /// <para>
        /// <para>The name of a snapshot from which to restore data into the new node group. The snapshot
        /// status changes to <code>restoring</code> while the new node group is being created.</para><para><b>Note:</b> This parameter is only valid if the <code>Engine</code> parameter is
        /// <code>redis</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String SnapshotName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The number of days for which ElastiCache will retain automatic snapshots before deleting
        /// them. For example, if you set <code>SnapshotRetentionLimit</code> to 5, then a snapshot
        /// that was taken today will be retained for 5 days before being deleted.</para><para><b>Note:</b> This parameter is only valid if the <code>Engine</code> parameter is
        /// <code>redis</code>.</para><para>Default: 0 (i.e., automatic backups are disabled for this cache cluster).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 SnapshotRetentionLimit { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The daily time range (in UTC) during which ElastiCache will begin taking a daily snapshot
        /// of your node group.</para><para>Example: <code>05:00-09:00</code></para><para>If you do not specify this parameter, then ElastiCache will automatically choose an
        /// appropriate time range.</para><para><b>Note:</b> This parameter is only valid if the <code>Engine</code> parameter is
        /// <code>redis</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String SnapshotWindow { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of cost allocation tags to be added to this resource. A tag is a key-value
        /// pair. A tag key must be accompanied by a tag value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.ElastiCache.Model.Tag[] Tag { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("PrimaryClusterId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ECReplicationGroup (CreateReplicationGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("AutomaticFailoverEnabled"))
                context.AutomaticFailoverEnabled = this.AutomaticFailoverEnabled;
            if (ParameterWasBound("AutoMinorVersionUpgrade"))
                context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            context.CacheNodeType = this.CacheNodeType;
            context.CacheParameterGroupName = this.CacheParameterGroupName;
            if (this.CacheSecurityGroupName != null)
            {
                context.CacheSecurityGroupNames = new List<String>(this.CacheSecurityGroupName);
            }
            context.CacheSubnetGroupName = this.CacheSubnetGroupName;
            context.Engine = this.Engine;
            context.EngineVersion = this.EngineVersion;
            context.NotificationTopicArn = this.NotificationTopicArn;
            if (ParameterWasBound("NumCacheCluster"))
                context.NumCacheClusters = this.NumCacheCluster;
            if (ParameterWasBound("Port"))
                context.Port = this.Port;
            if (this.PreferredCacheClusterAZs != null)
            {
                context.PreferredCacheClusterAZs = new List<String>(this.PreferredCacheClusterAZs);
            }
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            context.PrimaryClusterId = this.PrimaryClusterId;
            context.ReplicationGroupDescription = this.ReplicationGroupDescription;
            context.ReplicationGroupId = this.ReplicationGroupId;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupIds = new List<String>(this.SecurityGroupId);
            }
            if (this.SnapshotArn != null)
            {
                context.SnapshotArns = new List<String>(this.SnapshotArn);
            }
            context.SnapshotName = this.SnapshotName;
            if (ParameterWasBound("SnapshotRetentionLimit"))
                context.SnapshotRetentionLimit = this.SnapshotRetentionLimit;
            context.SnapshotWindow = this.SnapshotWindow;
            if (this.Tag != null)
            {
                context.Tags = new List<Tag>(this.Tag);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateReplicationGroupRequest();
            
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
            if (cmdletContext.NumCacheClusters != null)
            {
                request.NumCacheClusters = cmdletContext.NumCacheClusters.Value;
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
            if (cmdletContext.ReplicationGroupDescription != null)
            {
                request.ReplicationGroupDescription = cmdletContext.ReplicationGroupDescription;
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
                var response = client.CreateReplicationGroup(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ReplicationGroup;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public Boolean? AutomaticFailoverEnabled { get; set; }
            public Boolean? AutoMinorVersionUpgrade { get; set; }
            public String CacheNodeType { get; set; }
            public String CacheParameterGroupName { get; set; }
            public List<String> CacheSecurityGroupNames { get; set; }
            public String CacheSubnetGroupName { get; set; }
            public String Engine { get; set; }
            public String EngineVersion { get; set; }
            public String NotificationTopicArn { get; set; }
            public Int32? NumCacheClusters { get; set; }
            public Int32? Port { get; set; }
            public List<String> PreferredCacheClusterAZs { get; set; }
            public String PreferredMaintenanceWindow { get; set; }
            public String PrimaryClusterId { get; set; }
            public String ReplicationGroupDescription { get; set; }
            public String ReplicationGroupId { get; set; }
            public List<String> SecurityGroupIds { get; set; }
            public List<String> SnapshotArns { get; set; }
            public String SnapshotName { get; set; }
            public Int32? SnapshotRetentionLimit { get; set; }
            public String SnapshotWindow { get; set; }
            public List<Tag> Tags { get; set; }
        }
        
    }
}
