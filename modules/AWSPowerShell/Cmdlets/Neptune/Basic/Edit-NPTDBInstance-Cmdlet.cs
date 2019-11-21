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
using Amazon.Neptune;
using Amazon.Neptune.Model;

namespace Amazon.PowerShell.Cmdlets.NPT
{
    /// <summary>
    /// Modifies settings for a DB instance. You can change one or more database configuration
    /// parameters by specifying these parameters and the new values in the request. To learn
    /// what modifications you can make to your DB instance, call <a>DescribeValidDBInstanceModifications</a>
    /// before you call <a>ModifyDBInstance</a>.
    /// </summary>
    [Cmdlet("Edit", "NPTDBInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Neptune.Model.DBInstance")]
    [AWSCmdlet("Calls the Amazon Neptune ModifyDBInstance API operation.", Operation = new[] {"ModifyDBInstance"}, SelectReturnType = typeof(Amazon.Neptune.Model.ModifyDBInstanceResponse))]
    [AWSCmdletOutput("Amazon.Neptune.Model.DBInstance or Amazon.Neptune.Model.ModifyDBInstanceResponse",
        "This cmdlet returns an Amazon.Neptune.Model.DBInstance object.",
        "The service call response (type Amazon.Neptune.Model.ModifyDBInstanceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditNPTDBInstanceCmdlet : AmazonNeptuneClientCmdlet, IExecutor
    {
        
        #region Parameter AllocatedStorage
        /// <summary>
        /// <para>
        /// <para>The new amount of storage (in gibibytes) to allocate for the DB instance.</para><para>Not applicable. Storage is managed by the DB Cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AllocatedStorage { get; set; }
        #endregion
        
        #region Parameter AllowMajorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>Indicates that major version upgrades are allowed. Changing this parameter doesn't
        /// result in an outage and the change is asynchronously applied as soon as possible.</para><para>Constraints: This parameter must be set to true when specifying a value for the EngineVersion
        /// parameter that is a different major version than the DB instance's current version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowMajorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter ApplyImmediately
        /// <summary>
        /// <para>
        /// <para>Specifies whether the modifications in this request and any pending modifications
        /// are asynchronously applied as soon as possible, regardless of the <code>PreferredMaintenanceWindow</code>
        /// setting for the DB instance.</para><para> If this parameter is set to <code>false</code>, changes to the DB instance are applied
        /// during the next maintenance window. Some parameter changes can cause an outage and
        /// are applied on the next call to <a>RebootDBInstance</a>, or the next failure reboot.</para><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ApplyImmediately { get; set; }
        #endregion
        
        #region Parameter AutoMinorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para> Indicates that minor version upgrades are applied automatically to the DB instance
        /// during the maintenance window. Changing this parameter doesn't result in an outage
        /// except in the following case and the change is asynchronously applied as soon as possible.
        /// An outage will result if this parameter is set to <code>true</code> during the maintenance
        /// window, and a newer minor version is available, and Neptune has enabled auto patching
        /// for that engine version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoMinorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter BackupRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>Not applicable. The retention period for automated backups is managed by the DB cluster.
        /// For more information, see <a>ModifyDBCluster</a>.</para><para>Default: Uses existing setting</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BackupRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter CACertificateIdentifier
        /// <summary>
        /// <para>
        /// <para>Indicates the certificate that needs to be associated with the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CACertificateIdentifier { get; set; }
        #endregion
        
        #region Parameter CopyTagsToSnapshot
        /// <summary>
        /// <para>
        /// <para>True to copy all tags from the DB instance to snapshots of the DB instance, and otherwise
        /// false. The default is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CopyTagsToSnapshot { get; set; }
        #endregion
        
        #region Parameter DBInstanceClass
        /// <summary>
        /// <para>
        /// <para>The new compute and memory capacity of the DB instance, for example, <code>db.m4.large</code>.
        /// Not all DB instance classes are available in all AWS Regions.</para><para>If you modify the DB instance class, an outage occurs during the change. The change
        /// is applied during the next maintenance window, unless <code>ApplyImmediately</code>
        /// is specified as <code>true</code> for this request.</para><para>Default: Uses existing setting</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBInstanceClass { get; set; }
        #endregion
        
        #region Parameter DBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The DB instance identifier. This value is stored as a lowercase string.</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing DBInstance.</para></li></ul>
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
        public System.String DBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter DBParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the DB parameter group to apply to the DB instance. Changing this setting
        /// doesn't result in an outage. The parameter group name itself is changed immediately,
        /// but the actual parameter changes are not applied until you reboot the instance without
        /// failover. The db instance will NOT be rebooted automatically and the parameter changes
        /// will NOT be applied during the next maintenance window.</para><para>Default: Uses existing setting</para><para>Constraints: The DB parameter group must be in the same DB parameter group family
        /// as this DB instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBParameterGroupName { get; set; }
        #endregion
        
        #region Parameter DBPortNumber
        /// <summary>
        /// <para>
        /// <para>The port number on which the database accepts connections.</para><para>The value of the <code>DBPortNumber</code> parameter must not match any of the port
        /// values specified for options in the option group for the DB instance.</para><para>Your database will restart when you change the <code>DBPortNumber</code> value regardless
        /// of the value of the <code>ApplyImmediately</code> parameter.</para><para> Default: <code>8182</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DBPortNumber { get; set; }
        #endregion
        
        #region Parameter DBSecurityGroup
        /// <summary>
        /// <para>
        /// <para>A list of DB security groups to authorize on this DB instance. Changing this setting
        /// doesn't result in an outage and the change is asynchronously applied as soon as possible.</para><para>Constraints:</para><ul><li><para>If supplied, must match existing DBSecurityGroups.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DBSecurityGroups")]
        public System.String[] DBSecurityGroup { get; set; }
        #endregion
        
        #region Parameter DBSubnetGroupName
        /// <summary>
        /// <para>
        /// <para>The new DB subnet group for the DB instance. You can use this parameter to move your
        /// DB instance to a different VPC.</para><para>Changing the subnet group causes an outage during the change. The change is applied
        /// during the next maintenance window, unless you specify <code>true</code> for the <code>ApplyImmediately</code>
        /// parameter.</para><para>Constraints: If supplied, must match the name of an existing DBSubnetGroup.</para><para>Example: <code>mySubnetGroup</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBSubnetGroupName { get; set; }
        #endregion
        
        #region Parameter CloudwatchLogsExportConfiguration_DisableLogType
        /// <summary>
        /// <para>
        /// <para>The list of log types to disable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CloudwatchLogsExportConfiguration_DisableLogTypes")]
        public System.String[] CloudwatchLogsExportConfiguration_DisableLogType { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>Not supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter DomainIAMRoleName
        /// <summary>
        /// <para>
        /// <para>Not supported</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainIAMRoleName { get; set; }
        #endregion
        
        #region Parameter EnableIAMDatabaseAuthentication
        /// <summary>
        /// <para>
        /// <para>True to enable mapping of AWS Identity and Access Management (IAM) accounts to database
        /// accounts, and otherwise false.</para><para>You can enable IAM database authentication for the following database engines</para><para>Not applicable. Mapping AWS IAM accounts to database accounts is managed by the DB
        /// cluster. For more information, see <a>ModifyDBCluster</a>.</para><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableIAMDatabaseAuthentication { get; set; }
        #endregion
        
        #region Parameter CloudwatchLogsExportConfiguration_EnableLogType
        /// <summary>
        /// <para>
        /// <para>The list of log types to enable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CloudwatchLogsExportConfiguration_EnableLogTypes")]
        public System.String[] CloudwatchLogsExportConfiguration_EnableLogType { get; set; }
        #endregion
        
        #region Parameter EnablePerformanceInsight
        /// <summary>
        /// <para>
        /// <para>Not supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnablePerformanceInsights")]
        public System.Boolean? EnablePerformanceInsight { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para> The version number of the database engine to upgrade to. Changing this parameter
        /// results in an outage and the change is applied during the next maintenance window
        /// unless the <code>ApplyImmediately</code> parameter is set to <code>true</code> for
        /// this request.</para><para>For major version upgrades, if a nondefault DB parameter group is currently in use,
        /// a new DB parameter group in the DB parameter group family for the new engine version
        /// must be specified. The new DB parameter group can be the default for that DB parameter
        /// group family.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter Iops
        /// <summary>
        /// <para>
        /// <para>The new Provisioned IOPS (I/O operations per second) value for the instance.</para><para>Changing this setting doesn't result in an outage and the change is applied during
        /// the next maintenance window unless the <code>ApplyImmediately</code> parameter is
        /// set to <code>true</code> for this request.</para><para>Default: Uses existing setting</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Iops { get; set; }
        #endregion
        
        #region Parameter LicenseModel
        /// <summary>
        /// <para>
        /// <para>Not supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LicenseModel { get; set; }
        #endregion
        
        #region Parameter MasterUserPassword
        /// <summary>
        /// <para>
        /// <para>Not applicable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MasterUserPassword { get; set; }
        #endregion
        
        #region Parameter MonitoringInterval
        /// <summary>
        /// <para>
        /// <para>The interval, in seconds, between points when Enhanced Monitoring metrics are collected
        /// for the DB instance. To disable collecting Enhanced Monitoring metrics, specify 0.
        /// The default is 0.</para><para>If <code>MonitoringRoleArn</code> is specified, then you must also set <code>MonitoringInterval</code>
        /// to a value other than 0.</para><para>Valid Values: <code>0, 1, 5, 10, 15, 30, 60</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MonitoringInterval { get; set; }
        #endregion
        
        #region Parameter MonitoringRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN for the IAM role that permits Neptune to send enhanced monitoring metrics
        /// to Amazon CloudWatch Logs. For example, <code>arn:aws:iam:123456789012:role/emaccess</code>.</para><para>If <code>MonitoringInterval</code> is set to a value other than 0, then you must supply
        /// a <code>MonitoringRoleArn</code> value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MonitoringRoleArn { get; set; }
        #endregion
        
        #region Parameter MultiAZ
        /// <summary>
        /// <para>
        /// <para>Specifies if the DB instance is a Multi-AZ deployment. Changing this parameter doesn't
        /// result in an outage and the change is applied during the next maintenance window unless
        /// the <code>ApplyImmediately</code> parameter is set to <code>true</code> for this request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MultiAZ { get; set; }
        #endregion
        
        #region Parameter NewDBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para> The new DB instance identifier for the DB instance when renaming a DB instance. When
        /// you change the DB instance identifier, an instance reboot will occur immediately if
        /// you set <code>Apply Immediately</code> to true, or will occur during the next maintenance
        /// window if <code>Apply Immediately</code> to false. This value is stored as a lowercase
        /// string.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 letters, numbers, or hyphens.</para></li><li><para>The first character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li></ul><para>Example: <code>mydbinstance</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewDBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter OptionGroupName
        /// <summary>
        /// <para>
        /// <para> Indicates that the DB instance should be associated with the specified option group.
        /// Changing this parameter doesn't result in an outage except in the following case and
        /// the change is applied during the next maintenance window unless the <code>ApplyImmediately</code>
        /// parameter is set to <code>true</code> for this request. If the parameter change results
        /// in an option group that enables OEM, this change can cause a brief (sub-second) period
        /// during which new connections are rejected but existing connections are not interrupted.</para><para>Permanent options, such as the TDE option for Oracle Advanced Security TDE, can't
        /// be removed from an option group, and that option group can't be removed from a DB
        /// instance once it is associated with a DB instance</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OptionGroupName { get; set; }
        #endregion
        
        #region Parameter PerformanceInsightsKMSKeyId
        /// <summary>
        /// <para>
        /// <para>Not supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PerformanceInsightsKMSKeyId { get; set; }
        #endregion
        
        #region Parameter PreferredBackupWindow
        /// <summary>
        /// <para>
        /// <para> The daily time range during which automated backups are created if automated backups
        /// are enabled.</para><para>Not applicable. The daily time range for creating automated backups is managed by
        /// the DB cluster. For more information, see <a>ModifyDBCluster</a>.</para><para>Constraints:</para><ul><li><para>Must be in the format hh24:mi-hh24:mi</para></li><li><para>Must be in Universal Time Coordinated (UTC)</para></li><li><para>Must not conflict with the preferred maintenance window</para></li><li><para>Must be at least 30 minutes</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredBackupWindow { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>The weekly time range (in UTC) during which system maintenance can occur, which might
        /// result in an outage. Changing this parameter doesn't result in an outage, except in
        /// the following situation, and the change is asynchronously applied as soon as possible.
        /// If there are pending actions that cause a reboot, and the maintenance window is changed
        /// to include the current time, then changing this parameter will cause a reboot of the
        /// DB instance. If moving this window to the current time, there must be at least 30
        /// minutes between the current time and end of the window to ensure pending changes are
        /// applied.</para><para>Default: Uses existing setting</para><para>Format: ddd:hh24:mi-ddd:hh24:mi</para><para>Valid Days: Mon | Tue | Wed | Thu | Fri | Sat | Sun</para><para>Constraints: Must be at least 30 minutes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter PromotionTier
        /// <summary>
        /// <para>
        /// <para>A value that specifies the order in which a Read Replica is promoted to the primary
        /// instance after a failure of the existing primary instance.</para><para>Default: 1</para><para>Valid Values: 0 - 15</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PromotionTier { get; set; }
        #endregion
        
        #region Parameter StorageType
        /// <summary>
        /// <para>
        /// <para>Not supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageType { get; set; }
        #endregion
        
        #region Parameter TdeCredentialArn
        /// <summary>
        /// <para>
        /// <para>The ARN from the key store with which to associate the instance for TDE encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TdeCredentialArn { get; set; }
        #endregion
        
        #region Parameter TdeCredentialPassword
        /// <summary>
        /// <para>
        /// <para>The password for the given ARN from the key store in order to access the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TdeCredentialPassword { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of EC2 VPC security groups to authorize on this DB instance. This change is
        /// asynchronously applied as soon as possible.</para><para>Not applicable. The associated list of EC2 VPC security groups is managed by the DB
        /// cluster. For more information, see <a>ModifyDBCluster</a>.</para><para>Constraints:</para><ul><li><para>If supplied, must match existing VpcSecurityGroupIds.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>This flag should no longer be used.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is not supported")]
        public System.Boolean? PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBInstance'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Neptune.Model.ModifyDBInstanceResponse).
        /// Specifying the name of a property of type Amazon.Neptune.Model.ModifyDBInstanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBInstance";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DBInstanceIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DBInstanceIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DBInstanceIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBInstanceIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-NPTDBInstance (ModifyDBInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Neptune.Model.ModifyDBInstanceResponse, EditNPTDBInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DBInstanceIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AllocatedStorage = this.AllocatedStorage;
            context.AllowMajorVersionUpgrade = this.AllowMajorVersionUpgrade;
            context.ApplyImmediately = this.ApplyImmediately;
            context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            context.BackupRetentionPeriod = this.BackupRetentionPeriod;
            context.CACertificateIdentifier = this.CACertificateIdentifier;
            if (this.CloudwatchLogsExportConfiguration_DisableLogType != null)
            {
                context.CloudwatchLogsExportConfiguration_DisableLogType = new List<System.String>(this.CloudwatchLogsExportConfiguration_DisableLogType);
            }
            if (this.CloudwatchLogsExportConfiguration_EnableLogType != null)
            {
                context.CloudwatchLogsExportConfiguration_EnableLogType = new List<System.String>(this.CloudwatchLogsExportConfiguration_EnableLogType);
            }
            context.CopyTagsToSnapshot = this.CopyTagsToSnapshot;
            context.DBInstanceClass = this.DBInstanceClass;
            context.DBInstanceIdentifier = this.DBInstanceIdentifier;
            #if MODULAR
            if (this.DBInstanceIdentifier == null && ParameterWasBound(nameof(this.DBInstanceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBInstanceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DBParameterGroupName = this.DBParameterGroupName;
            context.DBPortNumber = this.DBPortNumber;
            if (this.DBSecurityGroup != null)
            {
                context.DBSecurityGroup = new List<System.String>(this.DBSecurityGroup);
            }
            context.DBSubnetGroupName = this.DBSubnetGroupName;
            context.Domain = this.Domain;
            context.DomainIAMRoleName = this.DomainIAMRoleName;
            context.EnableIAMDatabaseAuthentication = this.EnableIAMDatabaseAuthentication;
            context.EnablePerformanceInsight = this.EnablePerformanceInsight;
            context.EngineVersion = this.EngineVersion;
            context.Iops = this.Iops;
            context.LicenseModel = this.LicenseModel;
            context.MasterUserPassword = this.MasterUserPassword;
            context.MonitoringInterval = this.MonitoringInterval;
            context.MonitoringRoleArn = this.MonitoringRoleArn;
            context.MultiAZ = this.MultiAZ;
            context.NewDBInstanceIdentifier = this.NewDBInstanceIdentifier;
            context.OptionGroupName = this.OptionGroupName;
            context.PerformanceInsightsKMSKeyId = this.PerformanceInsightsKMSKeyId;
            context.PreferredBackupWindow = this.PreferredBackupWindow;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            context.PromotionTier = this.PromotionTier;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PubliclyAccessible = this.PubliclyAccessible;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.StorageType = this.StorageType;
            context.TdeCredentialArn = this.TdeCredentialArn;
            context.TdeCredentialPassword = this.TdeCredentialPassword;
            if (this.VpcSecurityGroupId != null)
            {
                context.VpcSecurityGroupId = new List<System.String>(this.VpcSecurityGroupId);
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
            var request = new Amazon.Neptune.Model.ModifyDBInstanceRequest();
            
            if (cmdletContext.AllocatedStorage != null)
            {
                request.AllocatedStorage = cmdletContext.AllocatedStorage.Value;
            }
            if (cmdletContext.AllowMajorVersionUpgrade != null)
            {
                request.AllowMajorVersionUpgrade = cmdletContext.AllowMajorVersionUpgrade.Value;
            }
            if (cmdletContext.ApplyImmediately != null)
            {
                request.ApplyImmediately = cmdletContext.ApplyImmediately.Value;
            }
            if (cmdletContext.AutoMinorVersionUpgrade != null)
            {
                request.AutoMinorVersionUpgrade = cmdletContext.AutoMinorVersionUpgrade.Value;
            }
            if (cmdletContext.BackupRetentionPeriod != null)
            {
                request.BackupRetentionPeriod = cmdletContext.BackupRetentionPeriod.Value;
            }
            if (cmdletContext.CACertificateIdentifier != null)
            {
                request.CACertificateIdentifier = cmdletContext.CACertificateIdentifier;
            }
            
             // populate CloudwatchLogsExportConfiguration
            var requestCloudwatchLogsExportConfigurationIsNull = true;
            request.CloudwatchLogsExportConfiguration = new Amazon.Neptune.Model.CloudwatchLogsExportConfiguration();
            List<System.String> requestCloudwatchLogsExportConfiguration_cloudwatchLogsExportConfiguration_DisableLogType = null;
            if (cmdletContext.CloudwatchLogsExportConfiguration_DisableLogType != null)
            {
                requestCloudwatchLogsExportConfiguration_cloudwatchLogsExportConfiguration_DisableLogType = cmdletContext.CloudwatchLogsExportConfiguration_DisableLogType;
            }
            if (requestCloudwatchLogsExportConfiguration_cloudwatchLogsExportConfiguration_DisableLogType != null)
            {
                request.CloudwatchLogsExportConfiguration.DisableLogTypes = requestCloudwatchLogsExportConfiguration_cloudwatchLogsExportConfiguration_DisableLogType;
                requestCloudwatchLogsExportConfigurationIsNull = false;
            }
            List<System.String> requestCloudwatchLogsExportConfiguration_cloudwatchLogsExportConfiguration_EnableLogType = null;
            if (cmdletContext.CloudwatchLogsExportConfiguration_EnableLogType != null)
            {
                requestCloudwatchLogsExportConfiguration_cloudwatchLogsExportConfiguration_EnableLogType = cmdletContext.CloudwatchLogsExportConfiguration_EnableLogType;
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
            if (cmdletContext.DBInstanceClass != null)
            {
                request.DBInstanceClass = cmdletContext.DBInstanceClass;
            }
            if (cmdletContext.DBInstanceIdentifier != null)
            {
                request.DBInstanceIdentifier = cmdletContext.DBInstanceIdentifier;
            }
            if (cmdletContext.DBParameterGroupName != null)
            {
                request.DBParameterGroupName = cmdletContext.DBParameterGroupName;
            }
            if (cmdletContext.DBPortNumber != null)
            {
                request.DBPortNumber = cmdletContext.DBPortNumber.Value;
            }
            if (cmdletContext.DBSecurityGroup != null)
            {
                request.DBSecurityGroups = cmdletContext.DBSecurityGroup;
            }
            if (cmdletContext.DBSubnetGroupName != null)
            {
                request.DBSubnetGroupName = cmdletContext.DBSubnetGroupName;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            if (cmdletContext.DomainIAMRoleName != null)
            {
                request.DomainIAMRoleName = cmdletContext.DomainIAMRoleName;
            }
            if (cmdletContext.EnableIAMDatabaseAuthentication != null)
            {
                request.EnableIAMDatabaseAuthentication = cmdletContext.EnableIAMDatabaseAuthentication.Value;
            }
            if (cmdletContext.EnablePerformanceInsight != null)
            {
                request.EnablePerformanceInsights = cmdletContext.EnablePerformanceInsight.Value;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.Iops != null)
            {
                request.Iops = cmdletContext.Iops.Value;
            }
            if (cmdletContext.LicenseModel != null)
            {
                request.LicenseModel = cmdletContext.LicenseModel;
            }
            if (cmdletContext.MasterUserPassword != null)
            {
                request.MasterUserPassword = cmdletContext.MasterUserPassword;
            }
            if (cmdletContext.MonitoringInterval != null)
            {
                request.MonitoringInterval = cmdletContext.MonitoringInterval.Value;
            }
            if (cmdletContext.MonitoringRoleArn != null)
            {
                request.MonitoringRoleArn = cmdletContext.MonitoringRoleArn;
            }
            if (cmdletContext.MultiAZ != null)
            {
                request.MultiAZ = cmdletContext.MultiAZ.Value;
            }
            if (cmdletContext.NewDBInstanceIdentifier != null)
            {
                request.NewDBInstanceIdentifier = cmdletContext.NewDBInstanceIdentifier;
            }
            if (cmdletContext.OptionGroupName != null)
            {
                request.OptionGroupName = cmdletContext.OptionGroupName;
            }
            if (cmdletContext.PerformanceInsightsKMSKeyId != null)
            {
                request.PerformanceInsightsKMSKeyId = cmdletContext.PerformanceInsightsKMSKeyId;
            }
            if (cmdletContext.PreferredBackupWindow != null)
            {
                request.PreferredBackupWindow = cmdletContext.PreferredBackupWindow;
            }
            if (cmdletContext.PreferredMaintenanceWindow != null)
            {
                request.PreferredMaintenanceWindow = cmdletContext.PreferredMaintenanceWindow;
            }
            if (cmdletContext.PromotionTier != null)
            {
                request.PromotionTier = cmdletContext.PromotionTier.Value;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.PubliclyAccessible != null)
            {
                request.PubliclyAccessible = cmdletContext.PubliclyAccessible.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.StorageType != null)
            {
                request.StorageType = cmdletContext.StorageType;
            }
            if (cmdletContext.TdeCredentialArn != null)
            {
                request.TdeCredentialArn = cmdletContext.TdeCredentialArn;
            }
            if (cmdletContext.TdeCredentialPassword != null)
            {
                request.TdeCredentialPassword = cmdletContext.TdeCredentialPassword;
            }
            if (cmdletContext.VpcSecurityGroupId != null)
            {
                request.VpcSecurityGroupIds = cmdletContext.VpcSecurityGroupId;
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
        
        private Amazon.Neptune.Model.ModifyDBInstanceResponse CallAWSServiceOperation(IAmazonNeptune client, Amazon.Neptune.Model.ModifyDBInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Neptune", "ModifyDBInstance");
            try
            {
                #if DESKTOP
                return client.ModifyDBInstance(request);
                #elif CORECLR
                return client.ModifyDBInstanceAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? AllocatedStorage { get; set; }
            public System.Boolean? AllowMajorVersionUpgrade { get; set; }
            public System.Boolean? ApplyImmediately { get; set; }
            public System.Boolean? AutoMinorVersionUpgrade { get; set; }
            public System.Int32? BackupRetentionPeriod { get; set; }
            public System.String CACertificateIdentifier { get; set; }
            public List<System.String> CloudwatchLogsExportConfiguration_DisableLogType { get; set; }
            public List<System.String> CloudwatchLogsExportConfiguration_EnableLogType { get; set; }
            public System.Boolean? CopyTagsToSnapshot { get; set; }
            public System.String DBInstanceClass { get; set; }
            public System.String DBInstanceIdentifier { get; set; }
            public System.String DBParameterGroupName { get; set; }
            public System.Int32? DBPortNumber { get; set; }
            public List<System.String> DBSecurityGroup { get; set; }
            public System.String DBSubnetGroupName { get; set; }
            public System.String Domain { get; set; }
            public System.String DomainIAMRoleName { get; set; }
            public System.Boolean? EnableIAMDatabaseAuthentication { get; set; }
            public System.Boolean? EnablePerformanceInsight { get; set; }
            public System.String EngineVersion { get; set; }
            public System.Int32? Iops { get; set; }
            public System.String LicenseModel { get; set; }
            public System.String MasterUserPassword { get; set; }
            public System.Int32? MonitoringInterval { get; set; }
            public System.String MonitoringRoleArn { get; set; }
            public System.Boolean? MultiAZ { get; set; }
            public System.String NewDBInstanceIdentifier { get; set; }
            public System.String OptionGroupName { get; set; }
            public System.String PerformanceInsightsKMSKeyId { get; set; }
            public System.String PreferredBackupWindow { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.Int32? PromotionTier { get; set; }
            [System.ObsoleteAttribute]
            public System.Boolean? PubliclyAccessible { get; set; }
            public System.String StorageType { get; set; }
            public System.String TdeCredentialArn { get; set; }
            public System.String TdeCredentialPassword { get; set; }
            public List<System.String> VpcSecurityGroupId { get; set; }
            public System.Func<Amazon.Neptune.Model.ModifyDBInstanceResponse, EditNPTDBInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBInstance;
        }
        
    }
}
