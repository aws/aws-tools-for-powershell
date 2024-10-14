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
    /// Modifies the settings for a cluster. You can use this operation to change one or more
    /// cluster configuration parameters by specifying the parameters and the new values.
    /// </summary>
    [Cmdlet("Edit", "ECCacheCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.CacheCluster")]
    [AWSCmdlet("Calls the Amazon ElastiCache ModifyCacheCluster API operation.", Operation = new[] {"ModifyCacheCluster"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.ModifyCacheClusterResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.CacheCluster or Amazon.ElastiCache.Model.ModifyCacheClusterResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.CacheCluster object.",
        "The service call response (type Amazon.ElastiCache.Model.ModifyCacheClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditECCacheClusterCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplyImmediately
        /// <summary>
        /// <para>
        /// <para>If <c>true</c>, this parameter causes the modifications in this request and any pending
        /// modifications to be applied, asynchronously and as soon as possible, regardless of
        /// the <c>PreferredMaintenanceWindow</c> setting for the cluster.</para><para>If <c>false</c>, changes to the cluster are applied on the next maintenance reboot,
        /// or the next failure reboot, whichever occurs first.</para><important><para>If you perform a <c>ModifyCacheCluster</c> before a pending modification is applied,
        /// the pending modification is replaced by the newer modification.</para></important><para>Valid values: <c>true</c> | <c>false</c></para><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ApplyImmediately { get; set; }
        #endregion
        
        #region Parameter AuthToken
        /// <summary>
        /// <para>
        /// <para>Reserved parameter. The password used to access a password protected server. This
        /// parameter must be specified with the <c>auth-token-update</c> parameter. Password
        /// constraints:</para><ul><li><para>Must be only printable ASCII characters</para></li><li><para>Must be at least 16 characters and no more than 128 characters in length</para></li><li><para>Cannot contain any of the following characters: '/', '"', or '@', '%'</para></li></ul><para> For more information, see AUTH password at <a href="http://redis.io/commands/AUTH">AUTH</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthToken { get; set; }
        #endregion
        
        #region Parameter AuthTokenUpdateStrategy
        /// <summary>
        /// <para>
        /// <para>Specifies the strategy to use to update the AUTH token. This parameter must be specified
        /// with the <c>auth-token</c> parameter. Possible values:</para><ul><li><para>ROTATE - default, if no update strategy is provided</para></li><li><para>SET - allowed only after ROTATE</para></li><li><para>DELETE - allowed only when transitioning to RBAC</para></li></ul><para> For more information, see <a href="http://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/auth.html">Authenticating
        /// Users with AUTH</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElastiCache.AuthTokenUpdateStrategyType")]
        public Amazon.ElastiCache.AuthTokenUpdateStrategyType AuthTokenUpdateStrategy { get; set; }
        #endregion
        
        #region Parameter AutoMinorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para> If you are running Valkey 7.2 or Redis OSS engine version 6.0 or later, set this
        /// parameter to yes to opt-in to the next auto minor version upgrade campaign. This parameter
        /// is disabled for previous versions.  </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoMinorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter AZMode
        /// <summary>
        /// <para>
        /// <para>Specifies whether the new nodes in this Memcached cluster are all created in a single
        /// Availability Zone or created across multiple Availability Zones.</para><para>Valid values: <c>single-az</c> | <c>cross-az</c>.</para><para>This option is only supported for Memcached clusters.</para><note><para>You cannot specify <c>single-az</c> if the Memcached cluster already has cache nodes
        /// in different Availability Zones. If <c>cross-az</c> is specified, existing Memcached
        /// nodes remain in their current Availability Zone.</para><para>Only newly created nodes are located in different Availability Zones. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElastiCache.AZMode")]
        public Amazon.ElastiCache.AZMode AZMode { get; set; }
        #endregion
        
        #region Parameter CacheClusterId
        /// <summary>
        /// <para>
        /// <para>The cluster identifier. This value is stored as a lowercase string.</para>
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
        
        #region Parameter CacheNodeIdsToRemove
        /// <summary>
        /// <para>
        /// <para>A list of cache node IDs to be removed. A node ID is a numeric identifier (0001, 0002,
        /// etc.). This parameter is only valid when <c>NumCacheNodes</c> is less than the existing
        /// number of cache nodes. The number of cache node IDs supplied in this parameter must
        /// match the difference between the existing number of cache nodes in the cluster or
        /// pending cache nodes, whichever is greater, and the value of <c>NumCacheNodes</c> in
        /// the request.</para><para>For example: If you have 3 active cache nodes, 7 pending cache nodes, and the number
        /// of cache nodes in this <c>ModifyCacheCluster</c> call is 5, you must list 2 (7 - 5)
        /// cache node IDs to remove.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] CacheNodeIdsToRemove { get; set; }
        #endregion
        
        #region Parameter CacheNodeType
        /// <summary>
        /// <para>
        /// <para>A valid cache node type that you want to scale this cluster up to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CacheNodeType { get; set; }
        #endregion
        
        #region Parameter CacheParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the cache parameter group to apply to this cluster. This change is asynchronously
        /// applied as soon as possible for parameters when the <c>ApplyImmediately</c> parameter
        /// is specified as <c>true</c> for this request.</para>
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
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>Modifies the engine listed in a cluster message. The options are redis, memcached
        /// or valkey.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The upgraded version of the cache engine to be run on the cache nodes.</para><para><b>Important:</b> You can upgrade to a newer engine version (see <a href="https://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/SelectEngine.html#VersionManagement">Selecting
        /// a Cache Engine and Version</a>), but you cannot downgrade to an earlier engine version.
        /// If you want to use an earlier engine version, you must delete the existing cluster
        /// and create it anew with the earlier engine version. </para>
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
        /// <para>Specifies the destination, format and type of the logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogDeliveryConfigurations")]
        public Amazon.ElastiCache.Model.LogDeliveryConfigurationRequest[] LogDeliveryConfiguration { get; set; }
        #endregion
        
        #region Parameter NewAvailabilityZone
        /// <summary>
        /// <para>
        /// <note><para>This option is only supported on Memcached clusters.</para></note><para>The list of Availability Zones where the new Memcached cache nodes are created.</para><para>This parameter is only valid when <c>NumCacheNodes</c> in the request is greater than
        /// the sum of the number of active cache nodes and the number of cache nodes pending
        /// creation (which may be zero). The number of Availability Zones supplied in this list
        /// must match the cache nodes being added in this request.</para><para>Scenarios:</para><ul><li><para><b>Scenario 1:</b> You have 3 active nodes and wish to add 2 nodes. Specify <c>NumCacheNodes=5</c>
        /// (3 + 2) and optionally specify two Availability Zones for the two new nodes.</para></li><li><para><b>Scenario 2:</b> You have 3 active nodes and 2 nodes pending creation (from the
        /// scenario 1 call) and want to add 1 more node. Specify <c>NumCacheNodes=6</c> ((3 +
        /// 2) + 1) and optionally specify an Availability Zone for the new node.</para></li><li><para><b>Scenario 3:</b> You want to cancel all pending operations. Specify <c>NumCacheNodes=3</c>
        /// to cancel all pending operations.</para></li></ul><para>The Availability Zone placement of nodes pending creation cannot be modified. If you
        /// wish to cancel any nodes pending creation, add 0 nodes by setting <c>NumCacheNodes</c>
        /// to the number of current nodes.</para><para>If <c>cross-az</c> is specified, existing Memcached nodes remain in their current
        /// Availability Zone. Only newly created nodes can be located in different Availability
        /// Zones. For guidance on how to move existing Memcached nodes to different Availability
        /// Zones, see the <b>Availability Zone Considerations</b> section of <a href="https://docs.aws.amazon.com/AmazonElastiCache/latest/mem-ug/CacheNodes.SupportedTypes.html">Cache
        /// Node Considerations for Memcached</a>.</para><para><b>Impact of new add/remove requests upon pending requests</b></para><ul><li><para>Scenario-1</para><ul><li><para>Pending Action: Delete</para></li><li><para>New Request: Delete</para></li><li><para>Result: The new delete, pending or immediate, replaces the pending delete.</para></li></ul></li><li><para>Scenario-2</para><ul><li><para>Pending Action: Delete</para></li><li><para>New Request: Create</para></li><li><para>Result: The new create, pending or immediate, replaces the pending delete.</para></li></ul></li><li><para>Scenario-3</para><ul><li><para>Pending Action: Create</para></li><li><para>New Request: Delete</para></li><li><para>Result: The new delete, pending or immediate, replaces the pending create.</para></li></ul></li><li><para>Scenario-4</para><ul><li><para>Pending Action: Create</para></li><li><para>New Request: Create</para></li><li><para>Result: The new create is added to the pending create.</para><important><para><b>Important:</b> If the new create request is <b>Apply Immediately - Yes</b>, all
        /// creates are performed immediately. If the new create request is <b>Apply Immediately
        /// - No</b>, all creates are pending.</para></important></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationTopicArn { get; set; }
        #endregion
        
        #region Parameter NotificationTopicStatus
        /// <summary>
        /// <para>
        /// <para>The status of the Amazon SNS notification topic. Notifications are sent only if the
        /// status is <c>active</c>.</para><para>Valid values: <c>active</c> | <c>inactive</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationTopicStatus { get; set; }
        #endregion
        
        #region Parameter NumCacheNode
        /// <summary>
        /// <para>
        /// <para>The number of cache nodes that the cluster should have. If the value for <c>NumCacheNodes</c>
        /// is greater than the sum of the number of current cache nodes and the number of cache
        /// nodes pending creation (which may be zero), more nodes are added. If the value is
        /// less than the number of existing cache nodes, nodes are removed. If the value is equal
        /// to the number of current cache nodes, any pending add or remove requests are canceled.</para><para>If you are removing cache nodes, you must use the <c>CacheNodeIdsToRemove</c> parameter
        /// to provide the IDs of the specific cache nodes to remove.</para><para>For clusters running Valkey or Redis OSS, this value must be 1. For clusters running
        /// Memcached, this value must be between 1 and 40.</para><note><para>Adding or removing Memcached cache nodes can be applied immediately or as a pending
        /// operation (see <c>ApplyImmediately</c>).</para><para>A pending operation to modify the number of cache nodes in a cluster during its maintenance
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
        /// operations to modify the number of cache nodes in a cluster, use the <c>ModifyCacheCluster</c>
        /// request and set <c>NumCacheNodes</c> equal to the number of cache nodes currently
        /// in the cluster.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("NumCacheNodes")]
        public System.Int32? NumCacheNode { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>Specifies the weekly time range during which maintenance on the cluster is performed.
        /// It is specified as a range in the format ddd:hh24:mi-ddd:hh24:mi (24H Clock UTC).
        /// The minimum maintenance window is a 60 minute period.</para><para>Valid values for <c>ddd</c> are:</para><ul><li><para><c>sun</c></para></li><li><para><c>mon</c></para></li><li><para><c>tue</c></para></li><li><para><c>wed</c></para></li><li><para><c>thu</c></para></li><li><para><c>fri</c></para></li><li><para><c>sat</c></para></li></ul><para>Example: <c>sun:23:00-mon:01:30</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>Specifies the VPC Security Groups associated with the cluster.</para><para>This parameter can be used only with clusters that are created in an Amazon Virtual
        /// Private Cloud (Amazon VPC).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SnapshotRetentionLimit
        /// <summary>
        /// <para>
        /// <para>The number of days for which ElastiCache retains automatic cluster snapshots before
        /// deleting them. For example, if you set <c>SnapshotRetentionLimit</c> to 5, a snapshot
        /// that was taken today is retained for 5 days before being deleted.</para><note><para>If the value of <c>SnapshotRetentionLimit</c> is set to zero (0), backups are turned
        /// off.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SnapshotRetentionLimit { get; set; }
        #endregion
        
        #region Parameter SnapshotWindow
        /// <summary>
        /// <para>
        /// <para>The daily time range (in UTC) during which ElastiCache begins taking a daily snapshot
        /// of your cluster. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotWindow { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CacheCluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.ModifyCacheClusterResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.ModifyCacheClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CacheCluster";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CacheClusterId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CacheClusterId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CacheClusterId' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CacheClusterId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-ECCacheCluster (ModifyCacheCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.ModifyCacheClusterResponse, EditECCacheClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CacheClusterId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplyImmediately = this.ApplyImmediately;
            context.AuthToken = this.AuthToken;
            context.AuthTokenUpdateStrategy = this.AuthTokenUpdateStrategy;
            context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            context.AZMode = this.AZMode;
            context.CacheClusterId = this.CacheClusterId;
            #if MODULAR
            if (this.CacheClusterId == null && ParameterWasBound(nameof(this.CacheClusterId)))
            {
                WriteWarning("You are passing $null as a value for parameter CacheClusterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CacheNodeIdsToRemove != null)
            {
                context.CacheNodeIdsToRemove = new List<System.String>(this.CacheNodeIdsToRemove);
            }
            context.CacheNodeType = this.CacheNodeType;
            context.CacheParameterGroupName = this.CacheParameterGroupName;
            if (this.CacheSecurityGroupName != null)
            {
                context.CacheSecurityGroupName = new List<System.String>(this.CacheSecurityGroupName);
            }
            context.Engine = this.Engine;
            context.EngineVersion = this.EngineVersion;
            context.IpDiscovery = this.IpDiscovery;
            if (this.LogDeliveryConfiguration != null)
            {
                context.LogDeliveryConfiguration = new List<Amazon.ElastiCache.Model.LogDeliveryConfigurationRequest>(this.LogDeliveryConfiguration);
            }
            if (this.NewAvailabilityZone != null)
            {
                context.NewAvailabilityZone = new List<System.String>(this.NewAvailabilityZone);
            }
            context.NotificationTopicArn = this.NotificationTopicArn;
            context.NotificationTopicStatus = this.NotificationTopicStatus;
            context.NumCacheNode = this.NumCacheNode;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupId = new List<System.String>(this.SecurityGroupId);
            }
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
            if (cmdletContext.AuthToken != null)
            {
                request.AuthToken = cmdletContext.AuthToken;
            }
            if (cmdletContext.AuthTokenUpdateStrategy != null)
            {
                request.AuthTokenUpdateStrategy = cmdletContext.AuthTokenUpdateStrategy;
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
            if (cmdletContext.CacheSecurityGroupName != null)
            {
                request.CacheSecurityGroupNames = cmdletContext.CacheSecurityGroupName;
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
            if (cmdletContext.NewAvailabilityZone != null)
            {
                request.NewAvailabilityZones = cmdletContext.NewAvailabilityZone;
            }
            if (cmdletContext.NotificationTopicArn != null)
            {
                request.NotificationTopicArn = cmdletContext.NotificationTopicArn;
            }
            if (cmdletContext.NotificationTopicStatus != null)
            {
                request.NotificationTopicStatus = cmdletContext.NotificationTopicStatus;
            }
            if (cmdletContext.NumCacheNode != null)
            {
                request.NumCacheNodes = cmdletContext.NumCacheNode.Value;
            }
            if (cmdletContext.PreferredMaintenanceWindow != null)
            {
                request.PreferredMaintenanceWindow = cmdletContext.PreferredMaintenanceWindow;
            }
            if (cmdletContext.SecurityGroupId != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupId;
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
        
        private Amazon.ElastiCache.Model.ModifyCacheClusterResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.ModifyCacheClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "ModifyCacheCluster");
            try
            {
                #if DESKTOP
                return client.ModifyCacheCluster(request);
                #elif CORECLR
                return client.ModifyCacheClusterAsync(request).GetAwaiter().GetResult();
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
            public System.String AuthToken { get; set; }
            public Amazon.ElastiCache.AuthTokenUpdateStrategyType AuthTokenUpdateStrategy { get; set; }
            public System.Boolean? AutoMinorVersionUpgrade { get; set; }
            public Amazon.ElastiCache.AZMode AZMode { get; set; }
            public System.String CacheClusterId { get; set; }
            public List<System.String> CacheNodeIdsToRemove { get; set; }
            public System.String CacheNodeType { get; set; }
            public System.String CacheParameterGroupName { get; set; }
            public List<System.String> CacheSecurityGroupName { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineVersion { get; set; }
            public Amazon.ElastiCache.IpDiscovery IpDiscovery { get; set; }
            public List<Amazon.ElastiCache.Model.LogDeliveryConfigurationRequest> LogDeliveryConfiguration { get; set; }
            public List<System.String> NewAvailabilityZone { get; set; }
            public System.String NotificationTopicArn { get; set; }
            public System.String NotificationTopicStatus { get; set; }
            public System.Int32? NumCacheNode { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public System.Int32? SnapshotRetentionLimit { get; set; }
            public System.String SnapshotWindow { get; set; }
            public System.Func<Amazon.ElastiCache.Model.ModifyCacheClusterResponse, EditECCacheClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CacheCluster;
        }
        
    }
}
