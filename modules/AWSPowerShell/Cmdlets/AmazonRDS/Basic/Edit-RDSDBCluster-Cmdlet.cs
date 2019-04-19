/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Modify a setting for an Amazon Aurora DB cluster. You can change one or more database
    /// configuration parameters by specifying these parameters and the new values in the
    /// request. For more information on Amazon Aurora, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/CHAP_AuroraOverview.html">
    /// What Is Amazon Aurora?</a> in the <i>Amazon Aurora User Guide.</i><note><para>
    /// This action only applies to Aurora DB clusters.
    /// </para></note>
    /// </summary>
    [Cmdlet("Edit", "RDSDBCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBCluster")]
    [AWSCmdlet("Calls the Amazon Relational Database Service ModifyDBCluster API operation.", Operation = new[] {"ModifyDBCluster"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBCluster",
        "This cmdlet returns a DBCluster object.",
        "The service call response (type Amazon.RDS.Model.ModifyDBClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditRDSDBClusterCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter ApplyImmediately
        /// <summary>
        /// <para>
        /// <para>A value that specifies whether the modifications in this request and any pending modifications
        /// are asynchronously applied as soon as possible, regardless of the <code>PreferredMaintenanceWindow</code>
        /// setting for the DB cluster. If this parameter is set to <code>false</code>, changes
        /// to the DB cluster are applied during the next maintenance window.</para><para>The <code>ApplyImmediately</code> parameter only affects the <code>EnableIAMDatabaseAuthentication</code>,
        /// <code>MasterUserPassword</code>, and <code>NewDBClusterIdentifier</code> values. If
        /// you set the <code>ApplyImmediately</code> parameter value to false, then changes to
        /// the <code>EnableIAMDatabaseAuthentication</code>, <code>MasterUserPassword</code>,
        /// and <code>NewDBClusterIdentifier</code> values are applied during the next maintenance
        /// window. All other changes are applied immediately, regardless of the value of the
        /// <code>ApplyImmediately</code> parameter.</para><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ApplyImmediately { get; set; }
        #endregion
        
        #region Parameter ScalingConfiguration_AutoPause
        /// <summary>
        /// <para>
        /// <para>A value that specifies whether to allow or disallow automatic pause for an Aurora
        /// DB cluster in <code>serverless</code> DB engine mode. A DB cluster can be paused only
        /// when it's idle (it has no connections).</para><note><para>If a DB cluster is paused for more than seven days, the DB cluster might be backed
        /// up with a snapshot. In this case, the DB cluster is restored when there is a request
        /// to connect to it. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ScalingConfiguration_AutoPause { get; set; }
        #endregion
        
        #region Parameter BacktrackWindow
        /// <summary>
        /// <para>
        /// <para>The target backtrack window, in seconds. To disable backtracking, set this value to
        /// 0.</para><para>Default: 0</para><para>Constraints:</para><ul><li><para>If specified, this value must be set to a number from 0 to 259,200 (72 hours).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 BacktrackWindow { get; set; }
        #endregion
        
        #region Parameter BackupRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days for which automated backups are retained. You must specify a minimum
        /// value of 1.</para><para>Default: 1</para><para>Constraints:</para><ul><li><para>Must be a value from 1 to 35</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 BackupRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter CopyTagsToSnapshot
        /// <summary>
        /// <para>
        /// <para>True to copy all tags from the DB cluster to snapshots of the DB cluster, and otherwise
        /// false. The default is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean CopyTagsToSnapshot { get; set; }
        #endregion
        
        #region Parameter DBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The DB cluster identifier for the cluster being modified. This parameter is not case-sensitive.</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing DBCluster.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DBClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter DBClusterParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the DB cluster parameter group to use for the DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DBClusterParameterGroupName { get; set; }
        #endregion
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para>Indicates if the DB cluster has deletion protection enabled. The database can't be
        /// deleted when this value is set to true. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean DeletionProtection { get; set; }
        #endregion
        
        #region Parameter CloudwatchLogsExportConfiguration_DisableLogType
        /// <summary>
        /// <para>
        /// <para>The list of log types to disable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CloudwatchLogsExportConfiguration_DisableLogTypes")]
        public System.String[] CloudwatchLogsExportConfiguration_DisableLogType { get; set; }
        #endregion
        
        #region Parameter EnableHttpEndpoint
        /// <summary>
        /// <para>
        /// <note><para>HTTP endpoint functionality is in beta for Aurora Serverless and is subject to change.</para></note><para>A value that indicates whether to enable the HTTP endpoint for an Aurora Serverless
        /// DB cluster. By default, the HTTP endpoint is disabled.</para><para>When enabled, the HTTP endpoint provides a connectionless web service API for running
        /// SQL queries on the Aurora Serverless DB cluster. You can also query your database
        /// from inside the RDS console with the query editor.</para><para>For more information about Aurora Serverless, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/aurora-serverless.html">Using
        /// Amazon Aurora Serverless</a> in the <i>Amazon Aurora User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EnableHttpEndpoint { get; set; }
        #endregion
        
        #region Parameter EnableIAMDatabaseAuthentication
        /// <summary>
        /// <para>
        /// <para>True to enable mapping of AWS Identity and Access Management (IAM) accounts to database
        /// accounts, and otherwise false.</para><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EnableIAMDatabaseAuthentication { get; set; }
        #endregion
        
        #region Parameter CloudwatchLogsExportConfiguration_EnableLogType
        /// <summary>
        /// <para>
        /// <para>The list of log types to enable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CloudwatchLogsExportConfiguration_EnableLogTypes")]
        public System.String[] CloudwatchLogsExportConfiguration_EnableLogType { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The version number of the database engine to which you want to upgrade. Changing this
        /// parameter results in an outage. The change is applied during the next maintenance
        /// window unless the ApplyImmediately parameter is set to true.</para><para>For a list of valid engine versions, see <a>CreateDBCluster</a>, or call <a>DescribeDBEngineVersions</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter MasterUserPassword
        /// <summary>
        /// <para>
        /// <para>The new password for the master database user. This password can contain any printable
        /// ASCII character except "/", """, or "@".</para><para>Constraints: Must contain from 8 to 41 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MasterUserPassword { get; set; }
        #endregion
        
        #region Parameter ScalingConfiguration_MaxCapacity
        /// <summary>
        /// <para>
        /// <para>The maximum capacity for an Aurora DB cluster in <code>serverless</code> DB engine
        /// mode.</para><para>Valid capacity values are <code>2</code>, <code>4</code>, <code>8</code>, <code>16</code>,
        /// <code>32</code>, <code>64</code>, <code>128</code>, and <code>256</code>.</para><para>The maximum capacity must be greater than or equal to the minimum capacity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ScalingConfiguration_MaxCapacity { get; set; }
        #endregion
        
        #region Parameter ScalingConfiguration_MinCapacity
        /// <summary>
        /// <para>
        /// <para>The minimum capacity for an Aurora DB cluster in <code>serverless</code> DB engine
        /// mode.</para><para>Valid capacity values are <code>2</code>, <code>4</code>, <code>8</code>, <code>16</code>,
        /// <code>32</code>, <code>64</code>, <code>128</code>, and <code>256</code>.</para><para>The minimum capacity must be less than or equal to the maximum capacity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ScalingConfiguration_MinCapacity { get; set; }
        #endregion
        
        #region Parameter NewDBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The new DB cluster identifier for the DB cluster when renaming a DB cluster. This
        /// value is stored as a lowercase string.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 letters, numbers, or hyphens</para></li><li><para>The first character must be a letter</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens</para></li></ul><para>Example: <code>my-cluster2</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewDBClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter OptionGroupName
        /// <summary>
        /// <para>
        /// <para>A value that indicates that the DB cluster should be associated with the specified
        /// option group. Changing this parameter doesn't result in an outage except in the following
        /// case, and the change is applied during the next maintenance window unless the <code>ApplyImmediately</code>
        /// parameter is set to <code>true</code> for this request. If the parameter change results
        /// in an option group that enables OEM, this change can cause a brief (sub-second) period
        /// during which new connections are rejected but existing connections are not interrupted.
        /// </para><para>Permanent options can't be removed from an option group. The option group can't be
        /// removed from a DB cluster once it is associated with a DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OptionGroupName { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port number on which the DB cluster accepts connections.</para><para>Constraints: Value must be <code>1150-65535</code></para><para>Default: The same port as the original DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Port { get; set; }
        #endregion
        
        #region Parameter PreferredBackupWindow
        /// <summary>
        /// <para>
        /// <para>The daily time range during which automated backups are created if automated backups
        /// are enabled, using the <code>BackupRetentionPeriod</code> parameter. </para><para>The default is a 30-minute window selected at random from an 8-hour block of time
        /// for each AWS Region. To see the time blocks available, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/USER_UpgradeDBInstance.Maintenance.html#AdjustingTheMaintenanceWindow.Aurora">
        /// Adjusting the Preferred DB Cluster Maintenance Window</a> in the <i>Amazon Aurora
        /// User Guide.</i></para><para>Constraints:</para><ul><li><para>Must be in the format <code>hh24:mi-hh24:mi</code>.</para></li><li><para>Must be in Universal Coordinated Time (UTC).</para></li><li><para>Must not conflict with the preferred maintenance window.</para></li><li><para>Must be at least 30 minutes.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreferredBackupWindow { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>The weekly time range during which system maintenance can occur, in Universal Coordinated
        /// Time (UTC).</para><para>Format: <code>ddd:hh24:mi-ddd:hh24:mi</code></para><para>The default is a 30-minute window selected at random from an 8-hour block of time
        /// for each AWS Region, occurring on a random day of the week. To see the time blocks
        /// available, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/USER_UpgradeDBInstance.Maintenance.html#AdjustingTheMaintenanceWindow.Aurora">
        /// Adjusting the Preferred DB Cluster Maintenance Window</a> in the <i>Amazon Aurora
        /// User Guide.</i></para><para>Valid Days: Mon, Tue, Wed, Thu, Fri, Sat, Sun.</para><para>Constraints: Minimum 30-minute window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter ScalingConfiguration_SecondsUntilAutoPause
        /// <summary>
        /// <para>
        /// <para>The time, in seconds, before an Aurora DB cluster in <code>serverless</code> mode
        /// is paused.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ScalingConfiguration_SecondsUntilAutoPause { get; set; }
        #endregion
        
        #region Parameter ScalingConfiguration_TimeoutAction
        /// <summary>
        /// <para>
        /// <para>The action to take when the timeout is reached, either <code>ForceApplyCapacityChange</code>
        /// or <code>RollbackCapacityChange</code>.</para><para><code>ForceApplyCapacityChange</code>, the default, sets the capacity to the specified
        /// value as soon as possible.</para><para><code>RollbackCapacityChange</code> ignores the capacity change if a scaling point
        /// is not found in the timeout period.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/aurora-serverless.how-it-works.html#aurora-serverless.how-it-works.auto-scaling">
        /// Autoscaling for Aurora Serverless</a> in the <i>Amazon Aurora User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ScalingConfiguration_TimeoutAction { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of VPC security groups that the DB cluster will belong to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DBClusterIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSDBCluster (ModifyDBCluster)"))
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
            if (ParameterWasBound("BacktrackWindow"))
                context.BacktrackWindow = this.BacktrackWindow;
            if (ParameterWasBound("BackupRetentionPeriod"))
                context.BackupRetentionPeriod = this.BackupRetentionPeriod;
            if (this.CloudwatchLogsExportConfiguration_DisableLogType != null)
            {
                context.CloudwatchLogsExportConfiguration_DisableLogTypes = new List<System.String>(this.CloudwatchLogsExportConfiguration_DisableLogType);
            }
            if (this.CloudwatchLogsExportConfiguration_EnableLogType != null)
            {
                context.CloudwatchLogsExportConfiguration_EnableLogTypes = new List<System.String>(this.CloudwatchLogsExportConfiguration_EnableLogType);
            }
            if (ParameterWasBound("CopyTagsToSnapshot"))
                context.CopyTagsToSnapshot = this.CopyTagsToSnapshot;
            context.DBClusterIdentifier = this.DBClusterIdentifier;
            context.DBClusterParameterGroupName = this.DBClusterParameterGroupName;
            if (ParameterWasBound("DeletionProtection"))
                context.DeletionProtection = this.DeletionProtection;
            if (ParameterWasBound("EnableHttpEndpoint"))
                context.EnableHttpEndpoint = this.EnableHttpEndpoint;
            if (ParameterWasBound("EnableIAMDatabaseAuthentication"))
                context.EnableIAMDatabaseAuthentication = this.EnableIAMDatabaseAuthentication;
            context.EngineVersion = this.EngineVersion;
            context.MasterUserPassword = this.MasterUserPassword;
            context.NewDBClusterIdentifier = this.NewDBClusterIdentifier;
            context.OptionGroupName = this.OptionGroupName;
            if (ParameterWasBound("Port"))
                context.Port = this.Port;
            context.PreferredBackupWindow = this.PreferredBackupWindow;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            if (ParameterWasBound("ScalingConfiguration_AutoPause"))
                context.ScalingConfiguration_AutoPause = this.ScalingConfiguration_AutoPause;
            if (ParameterWasBound("ScalingConfiguration_MaxCapacity"))
                context.ScalingConfiguration_MaxCapacity = this.ScalingConfiguration_MaxCapacity;
            if (ParameterWasBound("ScalingConfiguration_MinCapacity"))
                context.ScalingConfiguration_MinCapacity = this.ScalingConfiguration_MinCapacity;
            if (ParameterWasBound("ScalingConfiguration_SecondsUntilAutoPause"))
                context.ScalingConfiguration_SecondsUntilAutoPause = this.ScalingConfiguration_SecondsUntilAutoPause;
            context.ScalingConfiguration_TimeoutAction = this.ScalingConfiguration_TimeoutAction;
            if (this.VpcSecurityGroupId != null)
            {
                context.VpcSecurityGroupIds = new List<System.String>(this.VpcSecurityGroupId);
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
            var request = new Amazon.RDS.Model.ModifyDBClusterRequest();
            
            if (cmdletContext.ApplyImmediately != null)
            {
                request.ApplyImmediately = cmdletContext.ApplyImmediately.Value;
            }
            if (cmdletContext.BacktrackWindow != null)
            {
                request.BacktrackWindow = cmdletContext.BacktrackWindow.Value;
            }
            if (cmdletContext.BackupRetentionPeriod != null)
            {
                request.BackupRetentionPeriod = cmdletContext.BackupRetentionPeriod.Value;
            }
            
             // populate CloudwatchLogsExportConfiguration
            bool requestCloudwatchLogsExportConfigurationIsNull = true;
            request.CloudwatchLogsExportConfiguration = new Amazon.RDS.Model.CloudwatchLogsExportConfiguration();
            List<System.String> requestCloudwatchLogsExportConfiguration_cloudwatchLogsExportConfiguration_DisableLogType = null;
            if (cmdletContext.CloudwatchLogsExportConfiguration_DisableLogTypes != null)
            {
                requestCloudwatchLogsExportConfiguration_cloudwatchLogsExportConfiguration_DisableLogType = cmdletContext.CloudwatchLogsExportConfiguration_DisableLogTypes;
            }
            if (requestCloudwatchLogsExportConfiguration_cloudwatchLogsExportConfiguration_DisableLogType != null)
            {
                request.CloudwatchLogsExportConfiguration.DisableLogTypes = requestCloudwatchLogsExportConfiguration_cloudwatchLogsExportConfiguration_DisableLogType;
                requestCloudwatchLogsExportConfigurationIsNull = false;
            }
            List<System.String> requestCloudwatchLogsExportConfiguration_cloudwatchLogsExportConfiguration_EnableLogType = null;
            if (cmdletContext.CloudwatchLogsExportConfiguration_EnableLogTypes != null)
            {
                requestCloudwatchLogsExportConfiguration_cloudwatchLogsExportConfiguration_EnableLogType = cmdletContext.CloudwatchLogsExportConfiguration_EnableLogTypes;
            }
            if (requestCloudwatchLogsExportConfiguration_cloudwatchLogsExportConfiguration_EnableLogType != null)
            {
                request.CloudwatchLogsExportConfiguration.EnableLogTypes = requestCloudwatchLogsExportConfiguration_cloudwatchLogsExportConfiguration_EnableLogType;
                requestCloudwatchLogsExportConfigurationIsNull = false;
            }
             // determine if request.CloudwatchLogsExportConfiguration should be set to null
            if (requestCloudwatchLogsExportConfigurationIsNull)
            {
                request.CloudwatchLogsExportConfiguration = null;
            }
            if (cmdletContext.CopyTagsToSnapshot != null)
            {
                request.CopyTagsToSnapshot = cmdletContext.CopyTagsToSnapshot.Value;
            }
            if (cmdletContext.DBClusterIdentifier != null)
            {
                request.DBClusterIdentifier = cmdletContext.DBClusterIdentifier;
            }
            if (cmdletContext.DBClusterParameterGroupName != null)
            {
                request.DBClusterParameterGroupName = cmdletContext.DBClusterParameterGroupName;
            }
            if (cmdletContext.DeletionProtection != null)
            {
                request.DeletionProtection = cmdletContext.DeletionProtection.Value;
            }
            if (cmdletContext.EnableHttpEndpoint != null)
            {
                request.EnableHttpEndpoint = cmdletContext.EnableHttpEndpoint.Value;
            }
            if (cmdletContext.EnableIAMDatabaseAuthentication != null)
            {
                request.EnableIAMDatabaseAuthentication = cmdletContext.EnableIAMDatabaseAuthentication.Value;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.MasterUserPassword != null)
            {
                request.MasterUserPassword = cmdletContext.MasterUserPassword;
            }
            if (cmdletContext.NewDBClusterIdentifier != null)
            {
                request.NewDBClusterIdentifier = cmdletContext.NewDBClusterIdentifier;
            }
            if (cmdletContext.OptionGroupName != null)
            {
                request.OptionGroupName = cmdletContext.OptionGroupName;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.PreferredBackupWindow != null)
            {
                request.PreferredBackupWindow = cmdletContext.PreferredBackupWindow;
            }
            if (cmdletContext.PreferredMaintenanceWindow != null)
            {
                request.PreferredMaintenanceWindow = cmdletContext.PreferredMaintenanceWindow;
            }
            
             // populate ScalingConfiguration
            bool requestScalingConfigurationIsNull = true;
            request.ScalingConfiguration = new Amazon.RDS.Model.ScalingConfiguration();
            System.Boolean? requestScalingConfiguration_scalingConfiguration_AutoPause = null;
            if (cmdletContext.ScalingConfiguration_AutoPause != null)
            {
                requestScalingConfiguration_scalingConfiguration_AutoPause = cmdletContext.ScalingConfiguration_AutoPause.Value;
            }
            if (requestScalingConfiguration_scalingConfiguration_AutoPause != null)
            {
                request.ScalingConfiguration.AutoPause = requestScalingConfiguration_scalingConfiguration_AutoPause.Value;
                requestScalingConfigurationIsNull = false;
            }
            System.Int32? requestScalingConfiguration_scalingConfiguration_MaxCapacity = null;
            if (cmdletContext.ScalingConfiguration_MaxCapacity != null)
            {
                requestScalingConfiguration_scalingConfiguration_MaxCapacity = cmdletContext.ScalingConfiguration_MaxCapacity.Value;
            }
            if (requestScalingConfiguration_scalingConfiguration_MaxCapacity != null)
            {
                request.ScalingConfiguration.MaxCapacity = requestScalingConfiguration_scalingConfiguration_MaxCapacity.Value;
                requestScalingConfigurationIsNull = false;
            }
            System.Int32? requestScalingConfiguration_scalingConfiguration_MinCapacity = null;
            if (cmdletContext.ScalingConfiguration_MinCapacity != null)
            {
                requestScalingConfiguration_scalingConfiguration_MinCapacity = cmdletContext.ScalingConfiguration_MinCapacity.Value;
            }
            if (requestScalingConfiguration_scalingConfiguration_MinCapacity != null)
            {
                request.ScalingConfiguration.MinCapacity = requestScalingConfiguration_scalingConfiguration_MinCapacity.Value;
                requestScalingConfigurationIsNull = false;
            }
            System.Int32? requestScalingConfiguration_scalingConfiguration_SecondsUntilAutoPause = null;
            if (cmdletContext.ScalingConfiguration_SecondsUntilAutoPause != null)
            {
                requestScalingConfiguration_scalingConfiguration_SecondsUntilAutoPause = cmdletContext.ScalingConfiguration_SecondsUntilAutoPause.Value;
            }
            if (requestScalingConfiguration_scalingConfiguration_SecondsUntilAutoPause != null)
            {
                request.ScalingConfiguration.SecondsUntilAutoPause = requestScalingConfiguration_scalingConfiguration_SecondsUntilAutoPause.Value;
                requestScalingConfigurationIsNull = false;
            }
            System.String requestScalingConfiguration_scalingConfiguration_TimeoutAction = null;
            if (cmdletContext.ScalingConfiguration_TimeoutAction != null)
            {
                requestScalingConfiguration_scalingConfiguration_TimeoutAction = cmdletContext.ScalingConfiguration_TimeoutAction;
            }
            if (requestScalingConfiguration_scalingConfiguration_TimeoutAction != null)
            {
                request.ScalingConfiguration.TimeoutAction = requestScalingConfiguration_scalingConfiguration_TimeoutAction;
                requestScalingConfigurationIsNull = false;
            }
             // determine if request.ScalingConfiguration should be set to null
            if (requestScalingConfigurationIsNull)
            {
                request.ScalingConfiguration = null;
            }
            if (cmdletContext.VpcSecurityGroupIds != null)
            {
                request.VpcSecurityGroupIds = cmdletContext.VpcSecurityGroupIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DBCluster;
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
        
        private Amazon.RDS.Model.ModifyDBClusterResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ModifyDBClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ModifyDBCluster");
            try
            {
                #if DESKTOP
                return client.ModifyDBCluster(request);
                #elif CORECLR
                return client.ModifyDBClusterAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? BacktrackWindow { get; set; }
            public System.Int32? BackupRetentionPeriod { get; set; }
            public List<System.String> CloudwatchLogsExportConfiguration_DisableLogTypes { get; set; }
            public List<System.String> CloudwatchLogsExportConfiguration_EnableLogTypes { get; set; }
            public System.Boolean? CopyTagsToSnapshot { get; set; }
            public System.String DBClusterIdentifier { get; set; }
            public System.String DBClusterParameterGroupName { get; set; }
            public System.Boolean? DeletionProtection { get; set; }
            public System.Boolean? EnableHttpEndpoint { get; set; }
            public System.Boolean? EnableIAMDatabaseAuthentication { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String MasterUserPassword { get; set; }
            public System.String NewDBClusterIdentifier { get; set; }
            public System.String OptionGroupName { get; set; }
            public System.Int32? Port { get; set; }
            public System.String PreferredBackupWindow { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.Boolean? ScalingConfiguration_AutoPause { get; set; }
            public System.Int32? ScalingConfiguration_MaxCapacity { get; set; }
            public System.Int32? ScalingConfiguration_MinCapacity { get; set; }
            public System.Int32? ScalingConfiguration_SecondsUntilAutoPause { get; set; }
            public System.String ScalingConfiguration_TimeoutAction { get; set; }
            public List<System.String> VpcSecurityGroupIds { get; set; }
        }
        
    }
}
