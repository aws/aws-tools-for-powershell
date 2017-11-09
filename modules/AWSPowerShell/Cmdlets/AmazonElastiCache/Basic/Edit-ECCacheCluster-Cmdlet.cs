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
    /// Modifies the settings for a cluster. You can use this operation to change one or more
    /// cluster configuration parameters by specifying the parameters and the new values.
    /// </summary>
    [Cmdlet("Edit", "ECCacheCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.CacheCluster")]
    [AWSCmdlet("Calls the Amazon ElastiCache ModifyCacheCluster API operation.", Operation = new[] {"ModifyCacheCluster"})]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.CacheCluster",
        "This cmdlet returns a CacheCluster object.",
        "The service call response (type Amazon.ElastiCache.Model.ModifyCacheClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditECCacheClusterCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        #region Parameter ApplyImmediately
        /// <summary>
        /// <para>
        /// <para>If <code>true</code>, this parameter causes the modifications in this request and
        /// any pending modifications to be applied, asynchronously and as soon as possible, regardless
        /// of the <code>PreferredMaintenanceWindow</code> setting for the cluster.</para><para>If <code>false</code>, changes to the cluster are applied on the next maintenance
        /// reboot, or the next failure reboot, whichever occurs first.</para><important><para>If you perform a <code>ModifyCacheCluster</code> before a pending modification is
        /// applied, the pending modification is replaced by the newer modification.</para></important><para>Valid values: <code>true</code> | <code>false</code></para><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ApplyImmediately { get; set; }
        #endregion
        
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
        /// <para>Specifies whether the new nodes in this Memcached cluster are all created in a single
        /// Availability Zone or created across multiple Availability Zones.</para><para>Valid values: <code>single-az</code> | <code>cross-az</code>.</para><para>This option is only supported for Memcached clusters.</para><note><para>You cannot specify <code>single-az</code> if the Memcached cluster already has cache
        /// nodes in different Availability Zones. If <code>cross-az</code> is specified, existing
        /// Memcached nodes remain in their current Availability Zone.</para><para>Only newly created nodes are located in different Availability Zones. For instructions
        /// on how to move existing Memcached nodes to different Availability Zones, see the <b>Availability
        /// Zone Considerations</b> section of <a href="http://docs.aws.amazon.com/AmazonElastiCache/latest/UserGuide/CacheNode.Memcached.html">Cache
        /// Node Considerations for Memcached</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ElastiCache.AZMode")]
        public Amazon.ElastiCache.AZMode AZMode { get; set; }
        #endregion
        
        #region Parameter CacheClusterId
        /// <summary>
        /// <para>
        /// <para>The cluster identifier. This value is stored as a lowercase string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CacheClusterId { get; set; }
        #endregion
        
        #region Parameter CacheNodeIdsToRemove
        /// <summary>
        /// <para>
        /// <para>A list of cache node IDs to be removed. A node ID is a numeric identifier (0001, 0002,
        /// etc.). This parameter is only valid when <code>NumCacheNodes</code> is less than the
        /// existing number of cache nodes. The number of cache node IDs supplied in this parameter
        /// must match the difference between the existing number of cache nodes in the cluster
        /// or pending cache nodes, whichever is greater, and the value of <code>NumCacheNodes</code>
        /// in the request.</para><para>For example: If you have 3 active cache nodes, 7 pending cache nodes, and the number
        /// of cache nodes in this <code>ModifyCacheCluster</code> call is 5, you must list 2
        /// (7 - 5) cache node IDs to remove.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] CacheNodeIdsToRemove { get; set; }
        #endregion
        
        #region Parameter CacheNodeType
        /// <summary>
        /// <para>
        /// <para>A valid cache node type that you want to scale this cluster up to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CacheNodeType { get; set; }
        #endregion
        
        #region Parameter CacheParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the cache parameter group to apply to this cluster. This change is asynchronously
        /// applied as soon as possible for parameters when the <code>ApplyImmediately</code>
        /// parameter is specified as <code>true</code> for this request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CacheParameterGroupName { get; set; }
        #endregion
        
        #region Parameter CacheSecurityGroupName
        /// <summary>
        /// <para>
        /// <para>A list of cache security group names to authorize on this cluster. This change is
        /// asynchronously applied as soon as possible.</para><para>You can use this parameter only with clusters that are created outside of an Amazon
        /// Virtual Private Cloud (Amazon VPC).</para><para>Constraints: Must contain no more than 255 alphanumeric characters. Must not be "Default".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheSecurityGroupNames")]
        public System.String[] CacheSecurityGroupName { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The upgraded version of the cache engine to be run on the cache nodes.</para><para><b>Important:</b> You can upgrade to a newer engine version (see <a href="http://docs.aws.amazon.com/AmazonElastiCache/latest/UserGuide/SelectEngine.html#VersionManagement">Selecting
        /// a Cache Engine and Version</a>), but you cannot downgrade to an earlier engine version.
        /// If you want to use an earlier engine version, you must delete the existing cluster
        /// and create it anew with the earlier engine version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter NewAvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The list of Availability Zones where the new Memcached cache nodes are created.</para><para>This parameter is only valid when <code>NumCacheNodes</code> in the request is greater
        /// than the sum of the number of active cache nodes and the number of cache nodes pending
        /// creation (which may be zero). The number of Availability Zones supplied in this list
        /// must match the cache nodes being added in this request.</para><para>This option is only supported on Memcached clusters.</para><para>Scenarios:</para><ul><li><para><b>Scenario 1:</b> You have 3 active nodes and wish to add 2 nodes. Specify <code>NumCacheNodes=5</code>
        /// (3 + 2) and optionally specify two Availability Zones for the two new nodes.</para></li><li><para><b>Scenario 2:</b> You have 3 active nodes and 2 nodes pending creation (from the
        /// scenario 1 call) and want to add 1 more node. Specify <code>NumCacheNodes=6</code>
        /// ((3 + 2) + 1) and optionally specify an Availability Zone for the new node.</para></li><li><para><b>Scenario 3:</b> You want to cancel all pending operations. Specify <code>NumCacheNodes=3</code>
        /// to cancel all pending operations.</para></li></ul><para>The Availability Zone placement of nodes pending creation cannot be modified. If you
        /// wish to cancel any nodes pending creation, add 0 nodes by setting <code>NumCacheNodes</code>
        /// to the number of current nodes.</para><para>If <code>cross-az</code> is specified, existing Memcached nodes remain in their current
        /// Availability Zone. Only newly created nodes can be located in different Availability
        /// Zones. For guidance on how to move existing Memcached nodes to different Availability
        /// Zones, see the <b>Availability Zone Considerations</b> section of <a href="http://docs.aws.amazon.com/AmazonElastiCache/latest/UserGuide/CacheNode.Memcached.html">Cache
        /// Node Considerations for Memcached</a>.</para><para><b>Impact of new add/remove requests upon pending requests</b></para><ul><li><para>Scenario-1</para><ul><li><para>Pending Action: Delete</para></li><li><para>New Request: Delete</para></li><li><para>Result: The new delete, pending or immediate, replaces the pending delete.</para></li></ul></li><li><para>Scenario-2</para><ul><li><para>Pending Action: Delete</para></li><li><para>New Request: Create</para></li><li><para>Result: The new create, pending or immediate, replaces the pending delete.</para></li></ul></li><li><para>Scenario-3</para><ul><li><para>Pending Action: Create</para></li><li><para>New Request: Delete</para></li><li><para>Result: The new delete, pending or immediate, replaces the pending create.</para></li></ul></li><li><para>Scenario-4</para><ul><li><para>Pending Action: Create</para></li><li><para>New Request: Create</para></li><li><para>Result: The new create is added to the pending create.</para><important><para><b>Important:</b> If the new create request is <b>Apply Immediately - Yes</b>, all
        /// creates are performed immediately. If the new create request is <b>Apply Immediately
        /// - No</b>, all creates are pending.</para></important></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NewAvailabilityZones")]
        public System.String[] NewAvailabilityZone { get; set; }
        #endregion
        
        #region Parameter NotificationTopicArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon SNS topic to which notifications are
        /// sent.</para><note><para>The Amazon SNS topic owner must be same as the cluster owner.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NotificationTopicArn { get; set; }
        #endregion
        
        #region Parameter NotificationTopicStatus
        /// <summary>
        /// <para>
        /// <para>The status of the Amazon SNS notification topic. Notifications are sent only if the
        /// status is <code>active</code>.</para><para>Valid values: <code>active</code> | <code>inactive</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NotificationTopicStatus { get; set; }
        #endregion
        
        #region Parameter NumCacheNode
        /// <summary>
        /// <para>
        /// <para>The number of cache nodes that the cluster should have. If the value for <code>NumCacheNodes</code>
        /// is greater than the sum of the number of current cache nodes and the number of cache
        /// nodes pending creation (which may be zero), more nodes are added. If the value is
        /// less than the number of existing cache nodes, nodes are removed. If the value is equal
        /// to the number of current cache nodes, any pending add or remove requests are canceled.</para><para>If you are removing cache nodes, you must use the <code>CacheNodeIdsToRemove</code>
        /// parameter to provide the IDs of the specific cache nodes to remove.</para><para>For clusters running Redis, this value must be 1. For clusters running Memcached,
        /// this value must be between 1 and 20.</para><note><para>Adding or removing Memcached cache nodes can be applied immediately or as a pending
        /// operation (see <code>ApplyImmediately</code>).</para><para>A pending operation to modify the number of cache nodes in a cluster during its maintenance
        /// window, whether by adding or removing nodes in accordance with the scale out architecture,
        /// is not queued. The customer's latest request to add or remove nodes to the cluster
        /// overrides any previous pending operations to modify the number of cache nodes in the
        /// cluster. For example, a request to remove 2 nodes would override a previous pending
        /// operation to remove 3 nodes. Similarly, a request to add 2 nodes would override a
        /// previous pending operation to remove 3 nodes and vice versa. As Memcached cache nodes
        /// may now be provisioned in different Availability Zones with flexible cache node placement,
        /// a request to add nodes does not automatically override a previous pending operation
        /// to add nodes. The customer can modify the previous pending operation to add more nodes
        /// or explicitly cancel the pending request and retry the new request. To cancel pending
        /// operations to modify the number of cache nodes in a cluster, use the <code>ModifyCacheCluster</code>
        /// request and set <code>NumCacheNodes</code> equal to the number of cache nodes currently
        /// in the cluster.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("NumCacheNodes")]
        public System.Int32 NumCacheNode { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>Specifies the weekly time range during which maintenance on the cluster is performed.
        /// It is specified as a range in the format ddd:hh24:mi-ddd:hh24:mi (24H Clock UTC).
        /// The minimum maintenance window is a 60 minute period.</para><para>Valid values for <code>ddd</code> are:</para><ul><li><para><code>sun</code></para></li><li><para><code>mon</code></para></li><li><para><code>tue</code></para></li><li><para><code>wed</code></para></li><li><para><code>thu</code></para></li><li><para><code>fri</code></para></li><li><para><code>sat</code></para></li></ul><para>Example: <code>sun:23:00-mon:01:30</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>Specifies the VPC Security Groups associated with the cluster.</para><para>This parameter can be used only with clusters that are created in an Amazon Virtual
        /// Private Cloud (Amazon VPC).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SnapshotRetentionLimit
        /// <summary>
        /// <para>
        /// <para>The number of days for which ElastiCache retains automatic cluster snapshots before
        /// deleting them. For example, if you set <code>SnapshotRetentionLimit</code> to 5, a
        /// snapshot that was taken today is retained for 5 days before being deleted.</para><note><para>If the value of <code>SnapshotRetentionLimit</code> is set to zero (0), backups are
        /// turned off.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 SnapshotRetentionLimit { get; set; }
        #endregion
        
        #region Parameter SnapshotWindow
        /// <summary>
        /// <para>
        /// <para>The daily time range (in UTC) during which ElastiCache begins taking a daily snapshot
        /// of your cluster. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SnapshotWindow { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-ECCacheCluster (ModifyCacheCluster)"))
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
            
            if (ParameterWasBound("ApplyImmediately"))
                context.ApplyImmediately = this.ApplyImmediately;
            if (ParameterWasBound("AutoMinorVersionUpgrade"))
                context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            context.AZMode = this.AZMode;
            context.CacheClusterId = this.CacheClusterId;
            if (this.CacheNodeIdsToRemove != null)
            {
                context.CacheNodeIdsToRemove = new List<System.String>(this.CacheNodeIdsToRemove);
            }
            context.CacheNodeType = this.CacheNodeType;
            context.CacheParameterGroupName = this.CacheParameterGroupName;
            if (this.CacheSecurityGroupName != null)
            {
                context.CacheSecurityGroupNames = new List<System.String>(this.CacheSecurityGroupName);
            }
            context.EngineVersion = this.EngineVersion;
            if (this.NewAvailabilityZone != null)
            {
                context.NewAvailabilityZones = new List<System.String>(this.NewAvailabilityZone);
            }
            context.NotificationTopicArn = this.NotificationTopicArn;
            context.NotificationTopicStatus = this.NotificationTopicStatus;
            if (ParameterWasBound("NumCacheNode"))
                context.NumCacheNodes = this.NumCacheNode;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupIds = new List<System.String>(this.SecurityGroupId);
            }
            if (ParameterWasBound("SnapshotRetentionLimit"))
                context.SnapshotRetentionLimit = this.SnapshotRetentionLimit;
            context.SnapshotWindow = this.SnapshotWindow;
            
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
            var request = new Amazon.ElastiCache.Model.ModifyCacheClusterRequest();
            
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
        
        private Amazon.ElastiCache.Model.ModifyCacheClusterResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.ModifyCacheClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "ModifyCacheCluster");
            try
            {
                #if DESKTOP
                return client.ModifyCacheCluster(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ModifyCacheClusterAsync(request);
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
            public System.Boolean? ApplyImmediately { get; set; }
            public System.Boolean? AutoMinorVersionUpgrade { get; set; }
            public Amazon.ElastiCache.AZMode AZMode { get; set; }
            public System.String CacheClusterId { get; set; }
            public List<System.String> CacheNodeIdsToRemove { get; set; }
            public System.String CacheNodeType { get; set; }
            public System.String CacheParameterGroupName { get; set; }
            public List<System.String> CacheSecurityGroupNames { get; set; }
            public System.String EngineVersion { get; set; }
            public List<System.String> NewAvailabilityZones { get; set; }
            public System.String NotificationTopicArn { get; set; }
            public System.String NotificationTopicStatus { get; set; }
            public System.Int32? NumCacheNodes { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public List<System.String> SecurityGroupIds { get; set; }
            public System.Int32? SnapshotRetentionLimit { get; set; }
            public System.String SnapshotWindow { get; set; }
        }
        
    }
}
