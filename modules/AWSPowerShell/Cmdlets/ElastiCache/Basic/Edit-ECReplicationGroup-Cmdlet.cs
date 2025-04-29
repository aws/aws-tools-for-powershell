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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// Modifies the settings for a replication group. This is limited to Valkey and Redis
    /// OSS 7 and above.
    /// 
    ///  <ul><li><para><a href="https://docs.aws.amazon.com/AmazonElastiCache/latest/dg/scaling-redis-cluster-mode-enabled.html">Scaling
    /// for Valkey or Redis OSS (cluster mode enabled)</a> in the ElastiCache User Guide
    /// </para></li><li><para><a href="https://docs.aws.amazon.com/AmazonElastiCache/latest/APIReference/API_ModifyReplicationGroupShardConfiguration.html">ModifyReplicationGroupShardConfiguration</a>
    /// in the ElastiCache API Reference
    /// </para></li></ul><note><para>
    /// This operation is valid for Valkey or Redis OSS only.
    /// </para></note>
    /// </summary>
    [Cmdlet("Edit", "ECReplicationGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.ReplicationGroup")]
    [AWSCmdlet("Calls the Amazon ElastiCache ModifyReplicationGroup API operation.", Operation = new[] {"ModifyReplicationGroup"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.ModifyReplicationGroupResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ReplicationGroup or Amazon.ElastiCache.Model.ModifyReplicationGroupResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.ReplicationGroup object.",
        "The service call response (type Amazon.ElastiCache.Model.ModifyReplicationGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditECReplicationGroupCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplyImmediately
        /// <summary>
        /// <para>
        /// <para>If <c>true</c>, this parameter causes the modifications in this request and any pending
        /// modifications to be applied, asynchronously and as soon as possible, regardless of
        /// the <c>PreferredMaintenanceWindow</c> setting for the replication group.</para><para>If <c>false</c>, changes to the nodes in the replication group are applied on the
        /// next maintenance reboot, or the next failure reboot, whichever occurs first.</para><para>Valid values: <c>true</c> | <c>false</c></para><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ApplyImmediately { get; set; }
        #endregion
        
        #region Parameter AuthToken
        /// <summary>
        /// <para>
        /// <para>Reserved parameter. The password used to access a password protected server. This
        /// parameter must be specified with the <c>auth-token-update-strategy </c> parameter.
        /// Password constraints:</para><ul><li><para>Must be only printable ASCII characters</para></li><li><para>Must be at least 16 characters and no more than 128 characters in length</para></li><li><para>Cannot contain any of the following characters: '/', '"', or '@', '%'</para></li></ul><para> For more information, see AUTH password at <a href="http://redis.io/commands/AUTH">AUTH</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthToken { get; set; }
        #endregion
        
        #region Parameter AuthTokenUpdateStrategy
        /// <summary>
        /// <para>
        /// <para>Specifies the strategy to use to update the AUTH token. This parameter must be specified
        /// with the <c>auth-token</c> parameter. Possible values:</para><ul><li><para>ROTATE - default, if no update strategy is provided</para></li><li><para>SET - allowed only after ROTATE</para></li><li><para>DELETE - allowed only when transitioning to RBAC</para></li></ul><para> For more information, see <a href="http://docs.aws.amazon.com/AmazonElastiCache/latest/dg/auth.html">Authenticating
        /// Users with AUTH</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElastiCache.AuthTokenUpdateStrategyType")]
        public Amazon.ElastiCache.AuthTokenUpdateStrategyType AuthTokenUpdateStrategy { get; set; }
        #endregion
        
        #region Parameter AutomaticFailoverEnabled
        /// <summary>
        /// <para>
        /// <para>Determines whether a read replica is automatically promoted to read/write primary
        /// if the existing primary encounters a failure.</para><para>Valid values: <c>true</c> | <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutomaticFailoverEnabled { get; set; }
        #endregion
        
        #region Parameter AutoMinorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para> If you are running Valkey or Redis OSS engine version 6.0 or later, set this parameter
        /// to yes if you want to opt-in to the next auto minor version upgrade campaign. This
        /// parameter is disabled for previous versions.  </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoMinorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter CacheNodeType
        /// <summary>
        /// <para>
        /// <para>A valid cache node type that you want to scale this replication group to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CacheNodeType { get; set; }
        #endregion
        
        #region Parameter CacheParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the cache parameter group to apply to all of the clusters in this replication
        /// group. This change is asynchronously applied as soon as possible for parameters when
        /// the <c>ApplyImmediately</c> parameter is specified as <c>true</c> for this request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CacheParameterGroupName { get; set; }
        #endregion
        
        #region Parameter CacheSecurityGroupName
        /// <summary>
        /// <para>
        /// <para>A list of cache security group names to authorize for the clusters in this replication
        /// group. This change is asynchronously applied as soon as possible.</para><para>This parameter can be used only with replication group containing clusters running
        /// outside of an Amazon Virtual Private Cloud (Amazon VPC).</para><para>Constraints: Must contain no more than 255 alphanumeric characters. Must not be <c>Default</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheSecurityGroupNames")]
        public System.String[] CacheSecurityGroupName { get; set; }
        #endregion
        
        #region Parameter ClusterMode
        /// <summary>
        /// <para>
        /// <para>Enabled or Disabled. To modify cluster mode from Disabled to Enabled, you must first
        /// set the cluster mode to Compatible. Compatible mode allows your Valkey or Redis OSS
        /// clients to connect using both cluster mode enabled and cluster mode disabled. After
        /// you migrate all Valkey or Redis OSS clients to use cluster mode enabled, you can then
        /// complete cluster mode configuration and set the cluster mode to Enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElastiCache.ClusterMode")]
        public Amazon.ElastiCache.ClusterMode ClusterMode { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>Modifies the engine listed in a replication group message. The options are redis,
        /// memcached or valkey.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The upgraded version of the cache engine to be run on the clusters in the replication
        /// group.</para><para><b>Important:</b> You can upgrade to a newer engine version (see <a href="https://docs.aws.amazon.com/AmazonElastiCache/latest/dg/SelectEngine.html#VersionManagement">Selecting
        /// a Cache Engine and Version</a>), but you cannot downgrade to an earlier engine version.
        /// If you want to use an earlier engine version, you must delete the existing replication
        /// group and create it anew with the earlier engine version. </para>
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
        /// 6.2 to 7.1 and Memcached engine version 1.6.6 and above on all instances built on
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
        
        #region Parameter MultiAZEnabled
        /// <summary>
        /// <para>
        /// <para>A flag to indicate MultiAZ is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MultiAZEnabled { get; set; }
        #endregion
        
        #region Parameter NotificationTopicArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon SNS topic to which notifications are
        /// sent.</para><note><para>The Amazon SNS topic owner must be same as the replication group owner. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationTopicArn { get; set; }
        #endregion
        
        #region Parameter NotificationTopicStatus
        /// <summary>
        /// <para>
        /// <para>The status of the Amazon SNS notification topic for the replication group. Notifications
        /// are sent only if the status is <c>active</c>.</para><para>Valid values: <c>active</c> | <c>inactive</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationTopicStatus { get; set; }
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
        
        #region Parameter PrimaryClusterId
        /// <summary>
        /// <para>
        /// <para>For replication groups with a single primary, if this parameter is specified, ElastiCache
        /// promotes the specified cluster in the specified replication group to the primary role.
        /// The nodes of all other clusters in the replication group are read replicas.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrimaryClusterId { get; set; }
        #endregion
        
        #region Parameter RemoveUserGroup
        /// <summary>
        /// <para>
        /// <para>Removes the user group associated with this replication group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveUserGroups")]
        public System.Boolean? RemoveUserGroup { get; set; }
        #endregion
        
        #region Parameter ReplicationGroupDescription
        /// <summary>
        /// <para>
        /// <para>A description for the replication group. Maximum length is 255 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReplicationGroupDescription { get; set; }
        #endregion
        
        #region Parameter ReplicationGroupId
        /// <summary>
        /// <para>
        /// <para>The identifier of the replication group to modify.</para>
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
        public System.String ReplicationGroupId { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>Specifies the VPC Security Groups associated with the clusters in the replication
        /// group.</para><para>This parameter can be used only with replication group containing clusters running
        /// in an Amazon Virtual Private Cloud (Amazon VPC).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SnapshotRetentionLimit
        /// <summary>
        /// <para>
        /// <para>The number of days for which ElastiCache retains automatic node group (shard) snapshots
        /// before deleting them. For example, if you set <c>SnapshotRetentionLimit</c> to 5,
        /// a snapshot that was taken today is retained for 5 days before being deleted.</para><para><b>Important</b> If the value of SnapshotRetentionLimit is set to zero (0), backups
        /// are turned off.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SnapshotRetentionLimit { get; set; }
        #endregion
        
        #region Parameter SnapshottingClusterId
        /// <summary>
        /// <para>
        /// <para>The cluster ID that is used as the daily snapshot source for the replication group.
        /// This parameter cannot be set for Valkey or Redis OSS (cluster mode enabled) replication
        /// groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshottingClusterId { get; set; }
        #endregion
        
        #region Parameter SnapshotWindow
        /// <summary>
        /// <para>
        /// <para>The daily time range (in UTC) during which ElastiCache begins taking a daily snapshot
        /// of the node group (shard) specified by <c>SnapshottingClusterId</c>.</para><para>Example: <c>05:00-09:00</c></para><para>If you do not specify this parameter, ElastiCache automatically chooses an appropriate
        /// time range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotWindow { get; set; }
        #endregion
        
        #region Parameter TransitEncryptionEnabled
        /// <summary>
        /// <para>
        /// <para>A flag that enables in-transit encryption when set to true. If you are enabling in-transit
        /// encryption for an existing cluster, you must also set <c>TransitEncryptionMode</c>
        /// to <c>preferred</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TransitEncryptionEnabled { get; set; }
        #endregion
        
        #region Parameter TransitEncryptionMode
        /// <summary>
        /// <para>
        /// <para>A setting that allows you to migrate your clients to use in-transit encryption, with
        /// no downtime.</para><para>You must set <c>TransitEncryptionEnabled</c> to <c>true</c>, for your existing cluster,
        /// and set <c>TransitEncryptionMode</c> to <c>preferred</c> in the same request to allow
        /// both encrypted and unencrypted connections at the same time. Once you migrate all
        /// your Valkey or Redis OSS clients to use encrypted connections you can set the value
        /// to <c>required</c> to allow encrypted connections only.</para><para>Setting <c>TransitEncryptionMode</c> to <c>required</c> is a two-step process that
        /// requires you to first set the <c>TransitEncryptionMode</c> to <c>preferred</c>, after
        /// that you can set <c>TransitEncryptionMode</c> to <c>required</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElastiCache.TransitEncryptionMode")]
        public Amazon.ElastiCache.TransitEncryptionMode TransitEncryptionMode { get; set; }
        #endregion
        
        #region Parameter UserGroupIdsToAdd
        /// <summary>
        /// <para>
        /// <para>The ID of the user group you are associating with the replication group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] UserGroupIdsToAdd { get; set; }
        #endregion
        
        #region Parameter UserGroupIdsToRemove
        /// <summary>
        /// <para>
        /// <para>The ID of the user group to disassociate from the replication group, meaning the users
        /// in the group no longer can access the replication group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] UserGroupIdsToRemove { get; set; }
        #endregion
        
        #region Parameter NodeGroupId
        /// <summary>
        /// <para>
        /// <para>Deprecated. This parameter is not used.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This field is deprecated and is no longer used.")]
        public System.String NodeGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReplicationGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.ModifyReplicationGroupResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.ModifyReplicationGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReplicationGroup";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReplicationGroupId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-ECReplicationGroup (ModifyReplicationGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.ModifyReplicationGroupResponse, EditECReplicationGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplyImmediately = this.ApplyImmediately;
            context.AuthToken = this.AuthToken;
            context.AuthTokenUpdateStrategy = this.AuthTokenUpdateStrategy;
            context.AutomaticFailoverEnabled = this.AutomaticFailoverEnabled;
            context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            context.CacheNodeType = this.CacheNodeType;
            context.CacheParameterGroupName = this.CacheParameterGroupName;
            if (this.CacheSecurityGroupName != null)
            {
                context.CacheSecurityGroupName = new List<System.String>(this.CacheSecurityGroupName);
            }
            context.ClusterMode = this.ClusterMode;
            context.Engine = this.Engine;
            context.EngineVersion = this.EngineVersion;
            context.IpDiscovery = this.IpDiscovery;
            if (this.LogDeliveryConfiguration != null)
            {
                context.LogDeliveryConfiguration = new List<Amazon.ElastiCache.Model.LogDeliveryConfigurationRequest>(this.LogDeliveryConfiguration);
            }
            context.MultiAZEnabled = this.MultiAZEnabled;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.NodeGroupId = this.NodeGroupId;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.NotificationTopicArn = this.NotificationTopicArn;
            context.NotificationTopicStatus = this.NotificationTopicStatus;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            context.PrimaryClusterId = this.PrimaryClusterId;
            context.RemoveUserGroup = this.RemoveUserGroup;
            context.ReplicationGroupDescription = this.ReplicationGroupDescription;
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
            context.SnapshotRetentionLimit = this.SnapshotRetentionLimit;
            context.SnapshottingClusterId = this.SnapshottingClusterId;
            context.SnapshotWindow = this.SnapshotWindow;
            context.TransitEncryptionEnabled = this.TransitEncryptionEnabled;
            context.TransitEncryptionMode = this.TransitEncryptionMode;
            if (this.UserGroupIdsToAdd != null)
            {
                context.UserGroupIdsToAdd = new List<System.String>(this.UserGroupIdsToAdd);
            }
            if (this.UserGroupIdsToRemove != null)
            {
                context.UserGroupIdsToRemove = new List<System.String>(this.UserGroupIdsToRemove);
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
            var request = new Amazon.ElastiCache.Model.ModifyReplicationGroupRequest();
            
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
            if (cmdletContext.ClusterMode != null)
            {
                request.ClusterMode = cmdletContext.ClusterMode;
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
            if (cmdletContext.MultiAZEnabled != null)
            {
                request.MultiAZEnabled = cmdletContext.MultiAZEnabled.Value;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.NodeGroupId != null)
            {
                request.NodeGroupId = cmdletContext.NodeGroupId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.NotificationTopicArn != null)
            {
                request.NotificationTopicArn = cmdletContext.NotificationTopicArn;
            }
            if (cmdletContext.NotificationTopicStatus != null)
            {
                request.NotificationTopicStatus = cmdletContext.NotificationTopicStatus;
            }
            if (cmdletContext.PreferredMaintenanceWindow != null)
            {
                request.PreferredMaintenanceWindow = cmdletContext.PreferredMaintenanceWindow;
            }
            if (cmdletContext.PrimaryClusterId != null)
            {
                request.PrimaryClusterId = cmdletContext.PrimaryClusterId;
            }
            if (cmdletContext.RemoveUserGroup != null)
            {
                request.RemoveUserGroups = cmdletContext.RemoveUserGroup.Value;
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
            if (cmdletContext.SnapshotRetentionLimit != null)
            {
                request.SnapshotRetentionLimit = cmdletContext.SnapshotRetentionLimit.Value;
            }
            if (cmdletContext.SnapshottingClusterId != null)
            {
                request.SnapshottingClusterId = cmdletContext.SnapshottingClusterId;
            }
            if (cmdletContext.SnapshotWindow != null)
            {
                request.SnapshotWindow = cmdletContext.SnapshotWindow;
            }
            if (cmdletContext.TransitEncryptionEnabled != null)
            {
                request.TransitEncryptionEnabled = cmdletContext.TransitEncryptionEnabled.Value;
            }
            if (cmdletContext.TransitEncryptionMode != null)
            {
                request.TransitEncryptionMode = cmdletContext.TransitEncryptionMode;
            }
            if (cmdletContext.UserGroupIdsToAdd != null)
            {
                request.UserGroupIdsToAdd = cmdletContext.UserGroupIdsToAdd;
            }
            if (cmdletContext.UserGroupIdsToRemove != null)
            {
                request.UserGroupIdsToRemove = cmdletContext.UserGroupIdsToRemove;
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
        
        private Amazon.ElastiCache.Model.ModifyReplicationGroupResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.ModifyReplicationGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "ModifyReplicationGroup");
            try
            {
                return client.ModifyReplicationGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AutomaticFailoverEnabled { get; set; }
            public System.Boolean? AutoMinorVersionUpgrade { get; set; }
            public System.String CacheNodeType { get; set; }
            public System.String CacheParameterGroupName { get; set; }
            public List<System.String> CacheSecurityGroupName { get; set; }
            public Amazon.ElastiCache.ClusterMode ClusterMode { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineVersion { get; set; }
            public Amazon.ElastiCache.IpDiscovery IpDiscovery { get; set; }
            public List<Amazon.ElastiCache.Model.LogDeliveryConfigurationRequest> LogDeliveryConfiguration { get; set; }
            public System.Boolean? MultiAZEnabled { get; set; }
            [System.ObsoleteAttribute]
            public System.String NodeGroupId { get; set; }
            public System.String NotificationTopicArn { get; set; }
            public System.String NotificationTopicStatus { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.String PrimaryClusterId { get; set; }
            public System.Boolean? RemoveUserGroup { get; set; }
            public System.String ReplicationGroupDescription { get; set; }
            public System.String ReplicationGroupId { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public System.Int32? SnapshotRetentionLimit { get; set; }
            public System.String SnapshottingClusterId { get; set; }
            public System.String SnapshotWindow { get; set; }
            public System.Boolean? TransitEncryptionEnabled { get; set; }
            public Amazon.ElastiCache.TransitEncryptionMode TransitEncryptionMode { get; set; }
            public List<System.String> UserGroupIdsToAdd { get; set; }
            public List<System.String> UserGroupIdsToRemove { get; set; }
            public System.Func<Amazon.ElastiCache.Model.ModifyReplicationGroupResponse, EditECReplicationGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReplicationGroup;
        }
        
    }
}
