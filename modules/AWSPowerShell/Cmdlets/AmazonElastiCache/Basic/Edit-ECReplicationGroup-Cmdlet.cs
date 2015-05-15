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
    /// The <i>ModifyReplicationGroup</i> action modifies the settings for a replication group.
    /// </summary>
    [Cmdlet("Edit", "ECReplicationGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.ReplicationGroup")]
    [AWSCmdlet("Invokes the ModifyReplicationGroup operation against Amazon ElastiCache.", Operation = new[] {"ModifyReplicationGroup"})]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ReplicationGroup",
        "This cmdlet returns a ReplicationGroup object.",
        "The service call response (type ModifyReplicationGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class EditECReplicationGroupCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>If <code>true</code>, this parameter causes the modifications in this request and
        /// any pending modifications to be applied, asynchronously and as soon as possible, regardless
        /// of the <i>PreferredMaintenanceWindow</i> setting for the replication group.</para><para>If <code>false</code>, then changes to the nodes in the replication group are applied
        /// on the next maintenance reboot, or the next failure reboot, whichever occurs first.</para><para>Valid values: <code>true</code> | <code>false</code></para><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean ApplyImmediately { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Whether a read replica will be automatically promoted to read/write primary if the
        /// existing primary encounters a failure.</para><para>Valid values: <code>true</code> | <code>false</code></para><note><para>ElastiCache Multi-AZ replication groups are not supported on:</para><ul><li>Redis versions earlier than 2.8.6.</li><li>T1 and T2 cache node types.</li></ul></note>
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
        /// <para>The name of the cache parameter group to apply to all of the clusters in this replication
        /// group. This change is asynchronously applied as soon as possible for parameters when
        /// the <i>ApplyImmediately</i> parameter is specified as <i>true</i> for this request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String CacheParameterGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of cache security group names to authorize for the clusters in this replication
        /// group. This change is asynchronously applied as soon as possible.</para><para>This parameter can be used only with replication group containing cache clusters running
        /// outside of an Amazon Virtual Private Cloud (VPC).</para><para>Constraints: Must contain no more than 255 alphanumeric characters. Must not be "Default".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheSecurityGroupNames")]
        public System.String[] CacheSecurityGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The upgraded version of the cache engine to be run on the cache clusters in the replication
        /// group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String EngineVersion { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon SNS topic to which notifications will
        /// be sent.</para><note>The Amazon SNS topic owner must be same as the replication group owner. </note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NotificationTopicArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The status of the Amazon SNS notification topic for the replication group. Notifications
        /// are sent only if the status is <i>active</i>.</para><para>Valid values: <code>active</code> | <code>inactive</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NotificationTopicStatus { get; set; }
        
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
        /// <para>If this parameter is specified, ElastiCache will promote each of the cache clusters
        /// in the specified replication group to the primary role. The nodes of all other cache
        /// clusters in the replication group will be read replicas.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String PrimaryClusterId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A description for the replication group. Maximum length is 255 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String ReplicationGroupDescription { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The identifier of the replication group to modify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String ReplicationGroupId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specifies the VPC Security Groups associated with the cache clusters in the replication
        /// group.</para><para>This parameter can be used only with replication group containing cache clusters running
        /// in an Amazon Virtual Private Cloud (VPC).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The number of days for which ElastiCache will retain automatic node group snapshots
        /// before deleting them. For example, if you set <i>SnapshotRetentionLimit</i> to 5,
        /// then a snapshot that was taken today will be retained for 5 days before being deleted.</para><para><b>Important</b>If the value of SnapshotRetentionLimit is set to zero (0), backups
        /// are turned off.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 SnapshotRetentionLimit { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The cache cluster ID that will be used as the daily snapshot source for the replication
        /// group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String SnapshottingClusterId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The daily time range (in UTC) during which ElastiCache will begin taking a daily snapshot
        /// of the node group specified by <i>SnapshottingClusterId</i>.</para><para>Example: <code>05:00-09:00</code></para><para>If you do not specify this parameter, then ElastiCache will automatically choose an
        /// appropriate time range.</para>
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ReplicationGroupId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-ECReplicationGroup (ModifyReplicationGroup)"))
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
            if (ParameterWasBound("AutomaticFailoverEnabled"))
                context.AutomaticFailoverEnabled = this.AutomaticFailoverEnabled;
            if (ParameterWasBound("AutoMinorVersionUpgrade"))
                context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            context.CacheParameterGroupName = this.CacheParameterGroupName;
            if (this.CacheSecurityGroupName != null)
            {
                context.CacheSecurityGroupNames = new List<String>(this.CacheSecurityGroupName);
            }
            context.EngineVersion = this.EngineVersion;
            context.NotificationTopicArn = this.NotificationTopicArn;
            context.NotificationTopicStatus = this.NotificationTopicStatus;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            context.PrimaryClusterId = this.PrimaryClusterId;
            context.ReplicationGroupDescription = this.ReplicationGroupDescription;
            context.ReplicationGroupId = this.ReplicationGroupId;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupIds = new List<String>(this.SecurityGroupId);
            }
            if (ParameterWasBound("SnapshotRetentionLimit"))
                context.SnapshotRetentionLimit = this.SnapshotRetentionLimit;
            context.SnapshottingClusterId = this.SnapshottingClusterId;
            context.SnapshotWindow = this.SnapshotWindow;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new ModifyReplicationGroupRequest();
            
            if (cmdletContext.ApplyImmediately != null)
            {
                request.ApplyImmediately = cmdletContext.ApplyImmediately.Value;
            }
            if (cmdletContext.AutomaticFailoverEnabled != null)
            {
                request.AutomaticFailoverEnabled = cmdletContext.AutomaticFailoverEnabled.Value;
            }
            if (cmdletContext.AutoMinorVersionUpgrade != null)
            {
                request.AutoMinorVersionUpgrade = cmdletContext.AutoMinorVersionUpgrade.Value;
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ModifyReplicationGroup(request);
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
            public Boolean? ApplyImmediately { get; set; }
            public Boolean? AutomaticFailoverEnabled { get; set; }
            public Boolean? AutoMinorVersionUpgrade { get; set; }
            public String CacheParameterGroupName { get; set; }
            public List<String> CacheSecurityGroupNames { get; set; }
            public String EngineVersion { get; set; }
            public String NotificationTopicArn { get; set; }
            public String NotificationTopicStatus { get; set; }
            public String PreferredMaintenanceWindow { get; set; }
            public String PrimaryClusterId { get; set; }
            public String ReplicationGroupDescription { get; set; }
            public String ReplicationGroupId { get; set; }
            public List<String> SecurityGroupIds { get; set; }
            public Int32? SnapshotRetentionLimit { get; set; }
            public String SnapshottingClusterId { get; set; }
            public String SnapshotWindow { get; set; }
        }
        
    }
}
