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
    /// The <i>ModifyCacheCluster</i> action modifies the settings for a cache cluster. You
    /// can use this action to change one or more cluster configuration parameters by specifying
    /// the parameters and the new values.
    /// </summary>
    [Cmdlet("Edit", "ECCacheCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.CacheCluster")]
    [AWSCmdlet("Invokes the ModifyCacheCluster operation against Amazon ElastiCache.", Operation = new[] {"ModifyCacheCluster"})]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.CacheCluster",
        "This cmdlet returns a CacheCluster object.",
        "The service call response (type ModifyCacheClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class EditECCacheClusterCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>If <code>true</code>, this parameter causes the modifications in this request and
        /// any pending modifications to be applied, asynchronously and as soon as possible, regardless
        /// of the <i>PreferredMaintenanceWindow</i> setting for the cache cluster.</para><para>If <code>false</code>, then changes to the cache cluster are applied on the next maintenance
        /// reboot, or the next failure reboot, whichever occurs first.</para><important>If you perform a <code>ModifyCacheCluster</code> before a pending modification
        /// is applied, the pending modification is replaced by the newer modification.</important><para>Valid values: <code>true</code> | <code>false</code></para><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean ApplyImmediately { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>This parameter is currently disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean AutoMinorVersionUpgrade { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specifies whether the new nodes in this Memcached cache cluster are all created in
        /// a single Availability Zone or created across multiple Availability Zones.</para><para>Valid values: <code>single-az</code> | <code>cross-az</code>.</para><para>This option is only supported for Memcached cache clusters.</para><note><para>You cannot specify <code>single-az</code> if the Memcached cache cluster already has
        /// cache nodes in different Availability Zones. If <code>cross-az</code> is specified,
        /// existing Memcached nodes remain in their current Availability Zone.</para><para>Only newly created nodes will be located in different Availability Zones. For instructions
        /// on how to move existing Memcached nodes to different Availability Zones, see the <b>Availability
        /// Zone Considerations</b> section of <a href="http://docs.aws.amazon.com/AmazonElastiCache/latest/UserGuide/CacheNode.Memcached.html">Cache
        /// Node Considerations for Memcached</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public AZMode AZMode { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The cache cluster identifier. This value is stored as a lowercase string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String CacheClusterId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of cache node IDs to be removed. A node ID is a numeric identifier (0001, 0002,
        /// etc.). This parameter is only valid when <i>NumCacheNodes</i> is less than the existing
        /// number of cache nodes. The number of cache node IDs supplied in this parameter must
        /// match the difference between the existing number of cache nodes in the cluster or
        /// pending cache nodes, whichever is greater, and the value of <i>NumCacheNodes</i> in
        /// the request.</para><para>For example: If you have 3 active cache nodes, 7 pending cache nodes, and the number
        /// of cache nodes in this <code>ModifyCacheCluser</code> call is 5, you must list 2 (7
        /// - 5) cache node IDs to remove.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] CacheNodeIdsToRemove { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the cache parameter group to apply to this cache cluster. This change
        /// is asynchronously applied as soon as possible for parameters when the <i>ApplyImmediately</i>
        /// parameter is specified as <i>true</i> for this request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String CacheParameterGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of cache security group names to authorize on this cache cluster. This change
        /// is asynchronously applied as soon as possible.</para><para>This parameter can be used only with clusters that are created outside of an Amazon
        /// Virtual Private Cloud (VPC).</para><para>Constraints: Must contain no more than 255 alphanumeric characters. Must not be "Default".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheSecurityGroupNames")]
        public System.String[] CacheSecurityGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The upgraded version of the cache engine to be run on the cache nodes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String EngineVersion { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The list of Availability Zones where the new Memcached cache nodes will be created.</para><para>This parameter is only valid when <i>NumCacheNodes</i> in the request is greater than
        /// the sum of the number of active cache nodes and the number of cache nodes pending
        /// creation (which may be zero). The number of Availability Zones supplied in this list
        /// must match the cache nodes being added in this request.</para><para>This option is only supported on Memcached clusters.</para><para>Scenarios: <ul><li><b>Scenario 1:</b> You have 3 active nodes and wish to add 2
        /// nodes. Specify <code>NumCacheNodes=5</code> (3 + 2) and optionally specify two Availability
        /// Zones for the two new nodes.</li><li><b>Scenario 2:</b> You have 3 active nodes
        /// and 2 nodes pending creation (from the scenario 1 call) and want to add 1 more node.
        /// Specify <code>NumCacheNodes=6</code> ((3 + 2) + 1)</li> and optionally specify an
        /// Availability Zone for the new node. <li><b>Scenario 3:</b> You want to cancel all
        /// pending actions. Specify <code>NumCacheNodes=3</code> to cancel all pending actions.</li></ul></para><para>The Availability Zone placement of nodes pending creation cannot be modified. If you
        /// wish to cancel any nodes pending creation, add 0 nodes by setting <code>NumCacheNodes</code>
        /// to the number of current nodes.</para><para>If <code>cross-az</code> is specified, existing Memcached nodes remain in their current
        /// Availability Zone. Only newly created nodes can be located in different Availability
        /// Zones. For guidance on how to move existing Memcached nodes to different Availability
        /// Zones, see the <b>Availability Zone Considerations</b> section of <a href="http://docs.aws.amazon.com/AmazonElastiCache/latest/UserGuide/CacheNode.Memcached.html">Cache
        /// Node Considerations for Memcached</a>.</para><para><b>Impact of new add/remove requests upon pending requests</b></para><table><tr><th>Scenarios</th><th>Pending action</th><th>New Request</th><th>Results</th></tr><tr><td>Scenario-1</td><td>Delete</td><td>Delete</td><td>The new delete,
        /// pending or immediate, replaces the pending delete.</td></tr><tr><td>Scenario-2</td><td>Delete</td><td>Create</td><td>The new create, pending or immediate, replaces
        /// the pending delete.</td></tr><tr><td>Scenario-3</td><td>Create</td><td>Delete</td><td>The new delete, pending or immediate, replaces the pending create.</td></tr><tr><td>Scenario-4</td><td>Create</td><td>Create</td><td>The new create is added
        /// to the pending create.<br /><b>Important:</b><br />If the new create request is <b>Apply
        /// Immediately - Yes</b>, all creates are performed immediately. If the new create request
        /// is <b>Apply Immediately - No</b>, all creates are pending.</td></tr></table><para>Example: <code>NewAvailabilityZones.member.1=us-west-2a&amp;NewAvailabilityZones.member.2=us-west-2b&amp;NewAvailabilityZones.member.3=us-west-2c</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NewAvailabilityZones")]
        public System.String[] NewAvailabilityZone { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon SNS topic to which notifications will
        /// be sent.</para><note>The Amazon SNS topic owner must be same as the cache cluster owner. </note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NotificationTopicArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The status of the Amazon SNS notification topic. Notifications are sent only if the
        /// status is <i>active</i>.</para><para>Valid values: <code>active</code> | <code>inactive</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NotificationTopicStatus { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The number of cache nodes that the cache cluster should have. If the value for <code>NumCacheNodes</code>
        /// is greater than the sum of the number of current cache nodes and the number of cache
        /// nodes pending creation (which may be zero), then more nodes will be added. If the
        /// value is less than the number of existing cache nodes, then nodes will be removed.
        /// If the value is equal to the number of current cache nodes, then any pending add or
        /// remove requests are canceled.</para><para>If you are removing cache nodes, you must use the <code>CacheNodeIdsToRemove</code>
        /// parameter to provide the IDs of the specific cache nodes to remove.</para><para>For clusters running Redis, this value must be 1. For clusters running Memcached,
        /// this value must be between 1 and 20.</para><para><b>Note:</b>Adding or removing Memcached cache nodes can be applied immediately or
        /// as a pending action. See <code>ApplyImmediately</code>. A pending action to modify
        /// the number of cache nodes in a cluster during its maintenance window, whether by adding
        /// or removing nodes in accordance with the scale out architecture, is not queued. The
        /// customer's latest request to add or remove nodes to the cluster overrides any previous
        /// pending actions to modify the number of cache nodes in the cluster. For example, a
        /// request to remove 2 nodes would override a previous pending action to remove 3 nodes.
        /// Similarly, a request to add 2 nodes would override a previous pending action to remove
        /// 3 nodes and vice versa. As Memcached cache nodes may now be provisioned in different
        /// Availability Zones with flexible cache node placement, a request to add nodes does
        /// not automatically override a previous pending action to add nodes. The customer can
        /// modify the previous pending action to add more nodes or explicitly cancel the pending
        /// request and retry the new request. To cancel pending actions to modify the number
        /// of cache nodes in a cluster, use the <code>ModifyCacheCluster</code> request and set
        /// <i>NumCacheNodes</i> equal to the number of cache nodes currently in the cache cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("NumCacheNodes")]
        public Int32 NumCacheNode { get; set; }
        
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
        /// <para>Specifies the VPC Security Groups associated with the cache cluster.</para><para>This parameter can be used only with clusters that are created in an Amazon Virtual
        /// Private Cloud (VPC).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The number of days for which ElastiCache will retain automatic cache cluster snapshots
        /// before deleting them. For example, if you set <i>SnapshotRetentionLimit</i> to 5,
        /// then a snapshot that was taken today will be retained for 5 days before being deleted.</para><para><b>Important</b>If the value of SnapshotRetentionLimit is set to zero (0), backups
        /// are turned off.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 SnapshotRetentionLimit { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The daily time range (in UTC) during which ElastiCache will begin taking a daily snapshot
        /// of your cache cluster. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String SnapshotWindow { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CacheClusterId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-ECCacheCluster (ModifyCacheCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("ApplyImmediately"))
                context.ApplyImmediately = this.ApplyImmediately;
            if (ParameterWasBound("AutoMinorVersionUpgrade"))
                context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            context.AZMode = this.AZMode;
            context.CacheClusterId = this.CacheClusterId;
            if (this.CacheNodeIdsToRemove != null)
            {
                context.CacheNodeIdsToRemove = new List<String>(this.CacheNodeIdsToRemove);
            }
            context.CacheParameterGroupName = this.CacheParameterGroupName;
            if (this.CacheSecurityGroupName != null)
            {
                context.CacheSecurityGroupNames = new List<String>(this.CacheSecurityGroupName);
            }
            context.EngineVersion = this.EngineVersion;
            if (this.NewAvailabilityZone != null)
            {
                context.NewAvailabilityZones = new List<String>(this.NewAvailabilityZone);
            }
            context.NotificationTopicArn = this.NotificationTopicArn;
            context.NotificationTopicStatus = this.NotificationTopicStatus;
            if (ParameterWasBound("NumCacheNode"))
                context.NumCacheNodes = this.NumCacheNode;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupIds = new List<String>(this.SecurityGroupId);
            }
            if (ParameterWasBound("SnapshotRetentionLimit"))
                context.SnapshotRetentionLimit = this.SnapshotRetentionLimit;
            context.SnapshotWindow = this.SnapshotWindow;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new ModifyCacheClusterRequest();
            
            if (cmdletContext.ApplyImmediately != null)
            {
                request.ApplyImmediately = cmdletContext.ApplyImmediately.Value;
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
            if (cmdletContext.CacheNodeIdsToRemove != null)
            {
                request.CacheNodeIdsToRemove = cmdletContext.CacheNodeIdsToRemove;
            }
            if (cmdletContext.CacheParameterGroupName != null)
            {
                request.CacheParameterGroupName = cmdletContext.CacheParameterGroupName;
            }
            if (cmdletContext.CacheSecurityGroupNames != null)
            {
                request.CacheSecurityGroupNames = cmdletContext.CacheSecurityGroupNames;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.NewAvailabilityZones != null)
            {
                request.NewAvailabilityZones = cmdletContext.NewAvailabilityZones;
            }
            if (cmdletContext.NotificationTopicArn != null)
            {
                request.NotificationTopicArn = cmdletContext.NotificationTopicArn;
            }
            if (cmdletContext.NotificationTopicStatus != null)
            {
                request.NotificationTopicStatus = cmdletContext.NotificationTopicStatus;
            }
            if (cmdletContext.NumCacheNodes != null)
            {
                request.NumCacheNodes = cmdletContext.NumCacheNodes.Value;
            }
            if (cmdletContext.PreferredMaintenanceWindow != null)
            {
                request.PreferredMaintenanceWindow = cmdletContext.PreferredMaintenanceWindow;
            }
            if (cmdletContext.SecurityGroupIds != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupIds;
            }
            if (cmdletContext.SnapshotRetentionLimit != null)
            {
                request.SnapshotRetentionLimit = cmdletContext.SnapshotRetentionLimit.Value;
            }
            if (cmdletContext.SnapshotWindow != null)
            {
                request.SnapshotWindow = cmdletContext.SnapshotWindow;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ModifyCacheCluster(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public Boolean? ApplyImmediately { get; set; }
            public Boolean? AutoMinorVersionUpgrade { get; set; }
            public AZMode AZMode { get; set; }
            public String CacheClusterId { get; set; }
            public List<String> CacheNodeIdsToRemove { get; set; }
            public String CacheParameterGroupName { get; set; }
            public List<String> CacheSecurityGroupNames { get; set; }
            public String EngineVersion { get; set; }
            public List<String> NewAvailabilityZones { get; set; }
            public String NotificationTopicArn { get; set; }
            public String NotificationTopicStatus { get; set; }
            public Int32? NumCacheNodes { get; set; }
            public String PreferredMaintenanceWindow { get; set; }
            public List<String> SecurityGroupIds { get; set; }
            public Int32? SnapshotRetentionLimit { get; set; }
            public String SnapshotWindow { get; set; }
        }
        
    }
}
