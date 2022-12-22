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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Amazon Relational Database Service (Amazon RDS) supports importing MySQL databases
    /// by using backup files. You can create a backup of your on-premises database, store
    /// it on Amazon Simple Storage Service (Amazon S3), and then restore the backup file
    /// onto a new Amazon RDS DB instance running MySQL. For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/MySQL.Procedural.Importing.html">Importing
    /// Data into an Amazon RDS MySQL DB Instance</a> in the <i>Amazon RDS User Guide.</i><para>
    /// This command doesn't apply to RDS Custom.
    /// </para>
    /// </summary>
    [Cmdlet("Restore", "RDSDBInstanceFromS3", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBInstance")]
    [AWSCmdlet("Calls the Amazon Relational Database Service RestoreDBInstanceFromS3 API operation.", Operation = new[] {"RestoreDBInstanceFromS3"}, SelectReturnType = typeof(Amazon.RDS.Model.RestoreDBInstanceFromS3Response))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBInstance or Amazon.RDS.Model.RestoreDBInstanceFromS3Response",
        "This cmdlet returns an Amazon.RDS.Model.DBInstance object.",
        "The service call response (type Amazon.RDS.Model.RestoreDBInstanceFromS3Response) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RestoreRDSDBInstanceFromS3Cmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter AllocatedStorage
        /// <summary>
        /// <para>
        /// <para>The amount of storage (in gigabytes) to allocate initially for the DB instance. Follow
        /// the allocation rules specified in <code>CreateDBInstance</code>.</para><note><para>Be sure to allocate enough memory for your new DB instance so that the restore operation
        /// can succeed. You can also allocate additional memory for future growth.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AllocatedStorage { get; set; }
        #endregion
        
        #region Parameter AutoMinorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether minor engine upgrades are applied automatically to
        /// the DB instance during the maintenance window. By default, minor engine upgrades are
        /// not applied automatically.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoMinorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone that the DB instance is created in. For information about Amazon
        /// Web Services Regions and Availability Zones, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Concepts.RegionsAndAvailabilityZones.html">Regions
        /// and Availability Zones</a> in the <i>Amazon RDS User Guide.</i></para><para>Default: A random, system-chosen Availability Zone in the endpoint's Amazon Web Services
        /// Region.</para><para>Example: <code>us-east-1d</code></para><para>Constraint: The <code>AvailabilityZone</code> parameter can't be specified if the
        /// DB instance is a Multi-AZ deployment. The specified Availability Zone must be in the
        /// same Amazon Web Services Region as the current endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter BackupRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days for which automated backups are retained. Setting this parameter
        /// to a positive number enables backups. For more information, see <code>CreateDBInstance</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BackupRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter CopyTagsToSnapshot
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to copy all tags from the DB instance to snapshots
        /// of the DB instance. By default, tags are not copied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CopyTagsToSnapshot { get; set; }
        #endregion
        
        #region Parameter DBInstanceClass
        /// <summary>
        /// <para>
        /// <para>The compute and memory capacity of the DB instance, for example db.m4.large. Not all
        /// DB instance classes are available in all Amazon Web Services Regions, or for all database
        /// engines. For the full list of DB instance classes, and availability for your engine,
        /// see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Concepts.DBInstanceClass.html">DB
        /// Instance Class</a> in the <i>Amazon RDS User Guide.</i></para><para>Importing from Amazon S3 isn't supported on the db.t2.micro DB instance class.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DBInstanceClass { get; set; }
        #endregion
        
        #region Parameter DBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The DB instance identifier. This parameter is stored as a lowercase string.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 letters, numbers, or hyphens.</para></li><li><para>First character must be a letter.</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens.</para></li></ul><para>Example: <code>mydbinstance</code></para>
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
        
        #region Parameter DBName
        /// <summary>
        /// <para>
        /// <para>The name of the database to create when the DB instance is created. Follow the naming
        /// rules specified in <code>CreateDBInstance</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBName { get; set; }
        #endregion
        
        #region Parameter DBParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the DB parameter group to associate with this DB instance.</para><para>If you do not specify a value for <code>DBParameterGroupName</code>, then the default
        /// <code>DBParameterGroup</code> for the specified DB engine is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBParameterGroupName { get; set; }
        #endregion
        
        #region Parameter DBSecurityGroup
        /// <summary>
        /// <para>
        /// <para>A list of DB security groups to associate with this DB instance.</para><para>Default: The default DB security group for the database engine.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DBSecurityGroups")]
        public System.String[] DBSecurityGroup { get; set; }
        #endregion
        
        #region Parameter DBSubnetGroupName
        /// <summary>
        /// <para>
        /// <para>A DB subnet group to associate with this DB instance.</para><para>Constraints: If supplied, must match the name of an existing DBSubnetGroup.</para><para>Example: <code>mydbsubnetgroup</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBSubnetGroupName { get; set; }
        #endregion
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether the DB instance has deletion protection enabled. The
        /// database can't be deleted when deletion protection is enabled. By default, deletion
        /// protection isn't enabled. For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_DeleteInstance.html">
        /// Deleting a DB Instance</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtection { get; set; }
        #endregion
        
        #region Parameter EnableCloudwatchLogsExport
        /// <summary>
        /// <para>
        /// <para>The list of logs that the restored DB instance is to export to CloudWatch Logs. The
        /// values in the list depend on the DB engine being used. For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_LogAccess.html#USER_LogAccess.Procedural.UploadtoCloudWatch">Publishing
        /// Database Logs to Amazon CloudWatch Logs</a> in the <i>Amazon RDS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnableCloudwatchLogsExports")]
        public System.String[] EnableCloudwatchLogsExport { get; set; }
        #endregion
        
        #region Parameter EnableIAMDatabaseAuthentication
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to enable mapping of Amazon Web Services Identity and
        /// Access Management (IAM) accounts to database accounts. By default, mapping isn't enabled.</para><para>For more information about IAM database authentication, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/UsingWithRDS.IAMDBAuth.html">
        /// IAM Database Authentication for MySQL and PostgreSQL</a> in the <i>Amazon RDS User
        /// Guide.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableIAMDatabaseAuthentication { get; set; }
        #endregion
        
        #region Parameter EnablePerformanceInsight
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to enable Performance Insights for the DB instance.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_PerfInsights.html">Using
        /// Amazon Performance Insights</a> in the <i>Amazon RDS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnablePerformanceInsights")]
        public System.Boolean? EnablePerformanceInsight { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The name of the database engine to be used for this instance.</para><para>Valid Values: <code>mysql</code></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The version number of the database engine to use. Choose the latest minor version
        /// of your database engine. For information about engine versions, see <code>CreateDBInstance</code>,
        /// or call <code>DescribeDBEngineVersions</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter Iops
        /// <summary>
        /// <para>
        /// <para>The amount of Provisioned IOPS (input/output operations per second) to allocate initially
        /// for the DB instance. For information about valid IOPS values, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_Storage.html#USER_PIOPS">Amazon
        /// RDS Provisioned IOPS storage</a> in the <i>Amazon RDS User Guide.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Iops { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services KMS key identifier for an encrypted DB instance.</para><para>The Amazon Web Services KMS key identifier is the key ARN, key ID, alias ARN, or alias
        /// name for the KMS key. To use a KMS key in a different Amazon Web Services account,
        /// specify the key ARN or alias ARN.</para><para>If the <code>StorageEncrypted</code> parameter is enabled, and you do not specify
        /// a value for the <code>KmsKeyId</code> parameter, then Amazon RDS will use your default
        /// KMS key. There is a default KMS key for your Amazon Web Services account. Your Amazon
        /// Web Services account has a different default KMS key for each Amazon Web Services
        /// Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter LicenseModel
        /// <summary>
        /// <para>
        /// <para>The license model for this DB instance. Use <code>general-public-license</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LicenseModel { get; set; }
        #endregion
        
        #region Parameter ManageMasterUserPassword
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to manage the master user password with Amazon Web
        /// Services Secrets Manager.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/rds-secrets-manager.html">Password
        /// management with Amazon Web Services Secrets Manager</a> in the <i>Amazon RDS User
        /// Guide.</i></para><para>Constraints:</para><ul><li><para>Can't manage the master user password with Amazon Web Services Secrets Manager if
        /// <code>MasterUserPassword</code> is specified.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ManageMasterUserPassword { get; set; }
        #endregion
        
        #region Parameter MasterUsername
        /// <summary>
        /// <para>
        /// <para>The name for the master user.</para><para>Constraints:</para><ul><li><para>Must be 1 to 16 letters or numbers.</para></li><li><para>First character must be a letter.</para></li><li><para>Can't be a reserved word for the chosen database engine.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MasterUsername { get; set; }
        #endregion
        
        #region Parameter MasterUserPassword
        /// <summary>
        /// <para>
        /// <para>The password for the master user. The password can include any printable ASCII character
        /// except "/", """, or "@".</para><para>Constraints: Can't be specified if <code>ManageMasterUserPassword</code> is turned
        /// on.</para><para><b>MariaDB</b></para><para>Constraints: Must contain from 8 to 41 characters.</para><para><b>Microsoft SQL Server</b></para><para>Constraints: Must contain from 8 to 128 characters.</para><para><b>MySQL</b></para><para>Constraints: Must contain from 8 to 41 characters.</para><para><b>Oracle</b></para><para>Constraints: Must contain from 8 to 30 characters.</para><para><b>PostgreSQL</b></para><para>Constraints: Must contain from 8 to 128 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MasterUserPassword { get; set; }
        #endregion
        
        #region Parameter MasterUserSecretKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services KMS key identifier to encrypt a secret that is automatically
        /// generated and managed in Amazon Web Services Secrets Manager.</para><para>This setting is valid only if the master user password is managed by RDS in Amazon
        /// Web Services Secrets Manager for the DB instance.</para><para>The Amazon Web Services KMS key identifier is the key ARN, key ID, alias ARN, or alias
        /// name for the KMS key. To use a KMS key in a different Amazon Web Services account,
        /// specify the key ARN or alias ARN.</para><para>If you don't specify <code>MasterUserSecretKmsKeyId</code>, then the <code>aws/secretsmanager</code>
        /// KMS key is used to encrypt the secret. If the secret is in a different Amazon Web
        /// Services account, then you can't use the <code>aws/secretsmanager</code> KMS key to
        /// encrypt the secret, and you must use a customer managed KMS key.</para><para>There is a default KMS key for your Amazon Web Services account. Your Amazon Web Services
        /// account has a different default KMS key for each Amazon Web Services Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MasterUserSecretKmsKeyId { get; set; }
        #endregion
        
        #region Parameter MaxAllocatedStorage
        /// <summary>
        /// <para>
        /// <para>The upper limit in gibibytes (GiB) to which Amazon RDS can automatically scale the
        /// storage of the DB instance.</para><para>For more information about this setting, including limitations that apply to it, see
        /// <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_PIOPS.StorageTypes.html#USER_PIOPS.Autoscaling">
        /// Managing capacity automatically with Amazon RDS storage autoscaling</a> in the <i>Amazon
        /// RDS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxAllocatedStorage { get; set; }
        #endregion
        
        #region Parameter MonitoringInterval
        /// <summary>
        /// <para>
        /// <para>The interval, in seconds, between points when Enhanced Monitoring metrics are collected
        /// for the DB instance. To disable collecting Enhanced Monitoring metrics, specify 0.</para><para>If <code>MonitoringRoleArn</code> is specified, then you must also set <code>MonitoringInterval</code>
        /// to a value other than 0.</para><para>Valid Values: 0, 1, 5, 10, 15, 30, 60</para><para>Default: <code>0</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MonitoringInterval { get; set; }
        #endregion
        
        #region Parameter MonitoringRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN for the IAM role that permits RDS to send enhanced monitoring metrics to Amazon
        /// CloudWatch Logs. For example, <code>arn:aws:iam:123456789012:role/emaccess</code>.
        /// For information on creating a monitoring role, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_Monitoring.OS.html#USER_Monitoring.OS.Enabling">Setting
        /// Up and Enabling Enhanced Monitoring</a> in the <i>Amazon RDS User Guide.</i></para><para>If <code>MonitoringInterval</code> is set to a value other than 0, then you must supply
        /// a <code>MonitoringRoleArn</code> value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MonitoringRoleArn { get; set; }
        #endregion
        
        #region Parameter MultiAZ
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether the DB instance is a Multi-AZ deployment. If the DB
        /// instance is a Multi-AZ deployment, you can't set the <code>AvailabilityZone</code>
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MultiAZ { get; set; }
        #endregion
        
        #region Parameter NetworkType
        /// <summary>
        /// <para>
        /// <para>The network type of the DB instance.</para><para>Valid values:</para><ul><li><para><code>IPV4</code></para></li><li><para><code>DUAL</code></para></li></ul><para>The network type is determined by the <code>DBSubnetGroup</code> specified for the
        /// DB instance. A <code>DBSubnetGroup</code> can support only the IPv4 protocol or the
        /// IPv4 and the IPv6 protocols (<code>DUAL</code>).</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_VPC.WorkingWithRDSInstanceinaVPC.html">
        /// Working with a DB instance in a VPC</a> in the <i>Amazon RDS User Guide.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkType { get; set; }
        #endregion
        
        #region Parameter OptionGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the option group to associate with this DB instance. If this argument
        /// is omitted, the default option group for the specified engine is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OptionGroupName { get; set; }
        #endregion
        
        #region Parameter PerformanceInsightsKMSKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services KMS key identifier for encryption of Performance Insights
        /// data.</para><para>The Amazon Web Services KMS key identifier is the key ARN, key ID, alias ARN, or alias
        /// name for the KMS key.</para><para>If you do not specify a value for <code>PerformanceInsightsKMSKeyId</code>, then Amazon
        /// RDS uses your default KMS key. There is a default KMS key for your Amazon Web Services
        /// account. Your Amazon Web Services account has a different default KMS key for each
        /// Amazon Web Services Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PerformanceInsightsKMSKeyId { get; set; }
        #endregion
        
        #region Parameter PerformanceInsightsRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days to retain Performance Insights data. The default is 7 days. The
        /// following values are valid:</para><ul><li><para>7</para></li><li><para><i>month</i> * 31, where <i>month</i> is a number of months from 1-23</para></li><li><para>731</para></li></ul><para>For example, the following values are valid:</para><ul><li><para>93 (3 months * 31)</para></li><li><para>341 (11 months * 31)</para></li><li><para>589 (19 months * 31)</para></li><li><para>731</para></li></ul><para>If you specify a retention period such as 94, which isn't a valid value, RDS issues
        /// an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PerformanceInsightsRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port number on which the database accepts connections.</para><para>Type: Integer</para><para>Valid Values: <code>1150</code>-<code>65535</code></para><para>Default: <code>3306</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter PreferredBackupWindow
        /// <summary>
        /// <para>
        /// <para>The time range each day during which automated backups are created if automated backups
        /// are enabled. For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_WorkingWithAutomatedBackups.html#USER_WorkingWithAutomatedBackups.BackupWindow">Backup
        /// window</a> in the <i>Amazon RDS User Guide.</i></para><para>Constraints:</para><ul><li><para>Must be in the format <code>hh24:mi-hh24:mi</code>.</para></li><li><para>Must be in Universal Coordinated Time (UTC).</para></li><li><para>Must not conflict with the preferred maintenance window.</para></li><li><para>Must be at least 30 minutes.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredBackupWindow { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>The time range each week during which system maintenance can occur, in Universal Coordinated
        /// Time (UTC). For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_UpgradeDBInstance.Maintenance.html#Concepts.DBMaintenance">Amazon
        /// RDS Maintenance Window</a> in the <i>Amazon RDS User Guide.</i></para><para>Constraints:</para><ul><li><para>Must be in the format <code>ddd:hh24:mi-ddd:hh24:mi</code>.</para></li><li><para>Valid Days: Mon, Tue, Wed, Thu, Fri, Sat, Sun.</para></li><li><para>Must be in Universal Coordinated Time (UTC).</para></li><li><para>Must not conflict with the preferred backup window.</para></li><li><para>Must be at least 30 minutes.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter ProcessorFeature
        /// <summary>
        /// <para>
        /// <para>The number of CPU cores and the number of threads per core for the DB instance class
        /// of the DB instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProcessorFeatures")]
        public Amazon.RDS.Model.ProcessorFeature[] ProcessorFeature { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether the DB instance is publicly accessible.</para><para>When the DB instance is publicly accessible, its Domain Name System (DNS) endpoint
        /// resolves to the private IP address from within the DB instance's virtual private cloud
        /// (VPC). It resolves to the public IP address from outside of the DB instance's VPC.
        /// Access to the DB instance is ultimately controlled by the security group it uses.
        /// That public access is not permitted if the security group assigned to the DB instance
        /// doesn't permit it.</para><para>When the DB instance isn't publicly accessible, it is an internal DB instance with
        /// a DNS name that resolves to a private IP address.</para><para>For more information, see <a>CreateDBInstance</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter S3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of your Amazon S3 bucket that contains your database backup file.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String S3BucketName { get; set; }
        #endregion
        
        #region Parameter S3IngestionRoleArn
        /// <summary>
        /// <para>
        /// <para>An Amazon Web Services Identity and Access Management (IAM) role to allow Amazon RDS
        /// to access your Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String S3IngestionRoleArn { get; set; }
        #endregion
        
        #region Parameter S3Prefix
        /// <summary>
        /// <para>
        /// <para>The prefix of your Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3Prefix { get; set; }
        #endregion
        
        #region Parameter SourceEngine
        /// <summary>
        /// <para>
        /// <para>The name of the engine of your source database.</para><para>Valid Values: <code>mysql</code></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SourceEngine { get; set; }
        #endregion
        
        #region Parameter SourceEngineVersion
        /// <summary>
        /// <para>
        /// <para>The version of the database that the backup files were created from.</para><para>MySQL versions 5.6 and 5.7 are supported.</para><para>Example: <code>5.6.40</code></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SourceEngineVersion { get; set; }
        #endregion
        
        #region Parameter StorageEncrypted
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether the new DB instance is encrypted or not.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? StorageEncrypted { get; set; }
        #endregion
        
        #region Parameter StorageThroughput
        /// <summary>
        /// <para>
        /// <para>Specifies the storage throughput value for the DB instance.</para><para>This setting doesn't apply to RDS Custom or Amazon Aurora.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StorageThroughput { get; set; }
        #endregion
        
        #region Parameter StorageType
        /// <summary>
        /// <para>
        /// <para>Specifies the storage type to be associated with the DB instance.</para><para>Valid values: <code>gp2 | gp3 | io1 | standard</code></para><para>If you specify <code>io1</code> or <code>gp3</code>, you must also include a value
        /// for the <code>Iops</code> parameter.</para><para>Default: <code>io1</code> if the <code>Iops</code> parameter is specified; otherwise
        /// <code>gp2</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to associate with this DB instance. For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_Tagging.html">Tagging
        /// Amazon RDS Resources</a> in the <i>Amazon RDS User Guide.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter UseDefaultProcessorFeature
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether the DB instance class of the DB instance uses its default
        /// processor features.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UseDefaultProcessorFeatures")]
        public System.Boolean? UseDefaultProcessorFeature { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of VPC security groups to associate with this DB instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBInstance'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.RestoreDBInstanceFromS3Response).
        /// Specifying the name of a property of type Amazon.RDS.Model.RestoreDBInstanceFromS3Response will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBInstanceIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-RDSDBInstanceFromS3 (RestoreDBInstanceFromS3)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.RestoreDBInstanceFromS3Response, RestoreRDSDBInstanceFromS3Cmdlet>(Select) ??
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
            context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            context.AvailabilityZone = this.AvailabilityZone;
            context.BackupRetentionPeriod = this.BackupRetentionPeriod;
            context.CopyTagsToSnapshot = this.CopyTagsToSnapshot;
            context.DBInstanceClass = this.DBInstanceClass;
            #if MODULAR
            if (this.DBInstanceClass == null && ParameterWasBound(nameof(this.DBInstanceClass)))
            {
                WriteWarning("You are passing $null as a value for parameter DBInstanceClass which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DBInstanceIdentifier = this.DBInstanceIdentifier;
            #if MODULAR
            if (this.DBInstanceIdentifier == null && ParameterWasBound(nameof(this.DBInstanceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBInstanceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DBName = this.DBName;
            context.DBParameterGroupName = this.DBParameterGroupName;
            if (this.DBSecurityGroup != null)
            {
                context.DBSecurityGroup = new List<System.String>(this.DBSecurityGroup);
            }
            context.DBSubnetGroupName = this.DBSubnetGroupName;
            context.DeletionProtection = this.DeletionProtection;
            if (this.EnableCloudwatchLogsExport != null)
            {
                context.EnableCloudwatchLogsExport = new List<System.String>(this.EnableCloudwatchLogsExport);
            }
            context.EnableIAMDatabaseAuthentication = this.EnableIAMDatabaseAuthentication;
            context.EnablePerformanceInsight = this.EnablePerformanceInsight;
            context.Engine = this.Engine;
            #if MODULAR
            if (this.Engine == null && ParameterWasBound(nameof(this.Engine)))
            {
                WriteWarning("You are passing $null as a value for parameter Engine which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EngineVersion = this.EngineVersion;
            context.Iops = this.Iops;
            context.KmsKeyId = this.KmsKeyId;
            context.LicenseModel = this.LicenseModel;
            context.ManageMasterUserPassword = this.ManageMasterUserPassword;
            context.MasterUsername = this.MasterUsername;
            context.MasterUserPassword = this.MasterUserPassword;
            context.MasterUserSecretKmsKeyId = this.MasterUserSecretKmsKeyId;
            context.MaxAllocatedStorage = this.MaxAllocatedStorage;
            context.MonitoringInterval = this.MonitoringInterval;
            context.MonitoringRoleArn = this.MonitoringRoleArn;
            context.MultiAZ = this.MultiAZ;
            context.NetworkType = this.NetworkType;
            context.OptionGroupName = this.OptionGroupName;
            context.PerformanceInsightsKMSKeyId = this.PerformanceInsightsKMSKeyId;
            context.PerformanceInsightsRetentionPeriod = this.PerformanceInsightsRetentionPeriod;
            context.Port = this.Port;
            context.PreferredBackupWindow = this.PreferredBackupWindow;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            if (this.ProcessorFeature != null)
            {
                context.ProcessorFeature = new List<Amazon.RDS.Model.ProcessorFeature>(this.ProcessorFeature);
            }
            context.PubliclyAccessible = this.PubliclyAccessible;
            context.S3BucketName = this.S3BucketName;
            #if MODULAR
            if (this.S3BucketName == null && ParameterWasBound(nameof(this.S3BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter S3BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3IngestionRoleArn = this.S3IngestionRoleArn;
            #if MODULAR
            if (this.S3IngestionRoleArn == null && ParameterWasBound(nameof(this.S3IngestionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter S3IngestionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Prefix = this.S3Prefix;
            context.SourceEngine = this.SourceEngine;
            #if MODULAR
            if (this.SourceEngine == null && ParameterWasBound(nameof(this.SourceEngine)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceEngine which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceEngineVersion = this.SourceEngineVersion;
            #if MODULAR
            if (this.SourceEngineVersion == null && ParameterWasBound(nameof(this.SourceEngineVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceEngineVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StorageEncrypted = this.StorageEncrypted;
            context.StorageThroughput = this.StorageThroughput;
            context.StorageType = this.StorageType;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
            context.UseDefaultProcessorFeature = this.UseDefaultProcessorFeature;
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
            var request = new Amazon.RDS.Model.RestoreDBInstanceFromS3Request();
            
            if (cmdletContext.AllocatedStorage != null)
            {
                request.AllocatedStorage = cmdletContext.AllocatedStorage.Value;
            }
            if (cmdletContext.AutoMinorVersionUpgrade != null)
            {
                request.AutoMinorVersionUpgrade = cmdletContext.AutoMinorVersionUpgrade.Value;
            }
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.BackupRetentionPeriod != null)
            {
                request.BackupRetentionPeriod = cmdletContext.BackupRetentionPeriod.Value;
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
            if (cmdletContext.DBName != null)
            {
                request.DBName = cmdletContext.DBName;
            }
            if (cmdletContext.DBParameterGroupName != null)
            {
                request.DBParameterGroupName = cmdletContext.DBParameterGroupName;
            }
            if (cmdletContext.DBSecurityGroup != null)
            {
                request.DBSecurityGroups = cmdletContext.DBSecurityGroup;
            }
            if (cmdletContext.DBSubnetGroupName != null)
            {
                request.DBSubnetGroupName = cmdletContext.DBSubnetGroupName;
            }
            if (cmdletContext.DeletionProtection != null)
            {
                request.DeletionProtection = cmdletContext.DeletionProtection.Value;
            }
            if (cmdletContext.EnableCloudwatchLogsExport != null)
            {
                request.EnableCloudwatchLogsExports = cmdletContext.EnableCloudwatchLogsExport;
            }
            if (cmdletContext.EnableIAMDatabaseAuthentication != null)
            {
                request.EnableIAMDatabaseAuthentication = cmdletContext.EnableIAMDatabaseAuthentication.Value;
            }
            if (cmdletContext.EnablePerformanceInsight != null)
            {
                request.EnablePerformanceInsights = cmdletContext.EnablePerformanceInsight.Value;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.Iops != null)
            {
                request.Iops = cmdletContext.Iops.Value;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.LicenseModel != null)
            {
                request.LicenseModel = cmdletContext.LicenseModel;
            }
            if (cmdletContext.ManageMasterUserPassword != null)
            {
                request.ManageMasterUserPassword = cmdletContext.ManageMasterUserPassword.Value;
            }
            if (cmdletContext.MasterUsername != null)
            {
                request.MasterUsername = cmdletContext.MasterUsername;
            }
            if (cmdletContext.MasterUserPassword != null)
            {
                request.MasterUserPassword = cmdletContext.MasterUserPassword;
            }
            if (cmdletContext.MasterUserSecretKmsKeyId != null)
            {
                request.MasterUserSecretKmsKeyId = cmdletContext.MasterUserSecretKmsKeyId;
            }
            if (cmdletContext.MaxAllocatedStorage != null)
            {
                request.MaxAllocatedStorage = cmdletContext.MaxAllocatedStorage.Value;
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
            if (cmdletContext.NetworkType != null)
            {
                request.NetworkType = cmdletContext.NetworkType;
            }
            if (cmdletContext.OptionGroupName != null)
            {
                request.OptionGroupName = cmdletContext.OptionGroupName;
            }
            if (cmdletContext.PerformanceInsightsKMSKeyId != null)
            {
                request.PerformanceInsightsKMSKeyId = cmdletContext.PerformanceInsightsKMSKeyId;
            }
            if (cmdletContext.PerformanceInsightsRetentionPeriod != null)
            {
                request.PerformanceInsightsRetentionPeriod = cmdletContext.PerformanceInsightsRetentionPeriod.Value;
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
            if (cmdletContext.ProcessorFeature != null)
            {
                request.ProcessorFeatures = cmdletContext.ProcessorFeature;
            }
            if (cmdletContext.PubliclyAccessible != null)
            {
                request.PubliclyAccessible = cmdletContext.PubliclyAccessible.Value;
            }
            if (cmdletContext.S3BucketName != null)
            {
                request.S3BucketName = cmdletContext.S3BucketName;
            }
            if (cmdletContext.S3IngestionRoleArn != null)
            {
                request.S3IngestionRoleArn = cmdletContext.S3IngestionRoleArn;
            }
            if (cmdletContext.S3Prefix != null)
            {
                request.S3Prefix = cmdletContext.S3Prefix;
            }
            if (cmdletContext.SourceEngine != null)
            {
                request.SourceEngine = cmdletContext.SourceEngine;
            }
            if (cmdletContext.SourceEngineVersion != null)
            {
                request.SourceEngineVersion = cmdletContext.SourceEngineVersion;
            }
            if (cmdletContext.StorageEncrypted != null)
            {
                request.StorageEncrypted = cmdletContext.StorageEncrypted.Value;
            }
            if (cmdletContext.StorageThroughput != null)
            {
                request.StorageThroughput = cmdletContext.StorageThroughput.Value;
            }
            if (cmdletContext.StorageType != null)
            {
                request.StorageType = cmdletContext.StorageType;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.UseDefaultProcessorFeature != null)
            {
                request.UseDefaultProcessorFeatures = cmdletContext.UseDefaultProcessorFeature.Value;
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
        
        private Amazon.RDS.Model.RestoreDBInstanceFromS3Response CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.RestoreDBInstanceFromS3Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "RestoreDBInstanceFromS3");
            try
            {
                #if DESKTOP
                return client.RestoreDBInstanceFromS3(request);
                #elif CORECLR
                return client.RestoreDBInstanceFromS3Async(request).GetAwaiter().GetResult();
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
            public System.Boolean? AutoMinorVersionUpgrade { get; set; }
            public System.String AvailabilityZone { get; set; }
            public System.Int32? BackupRetentionPeriod { get; set; }
            public System.Boolean? CopyTagsToSnapshot { get; set; }
            public System.String DBInstanceClass { get; set; }
            public System.String DBInstanceIdentifier { get; set; }
            public System.String DBName { get; set; }
            public System.String DBParameterGroupName { get; set; }
            public List<System.String> DBSecurityGroup { get; set; }
            public System.String DBSubnetGroupName { get; set; }
            public System.Boolean? DeletionProtection { get; set; }
            public List<System.String> EnableCloudwatchLogsExport { get; set; }
            public System.Boolean? EnableIAMDatabaseAuthentication { get; set; }
            public System.Boolean? EnablePerformanceInsight { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineVersion { get; set; }
            public System.Int32? Iops { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String LicenseModel { get; set; }
            public System.Boolean? ManageMasterUserPassword { get; set; }
            public System.String MasterUsername { get; set; }
            public System.String MasterUserPassword { get; set; }
            public System.String MasterUserSecretKmsKeyId { get; set; }
            public System.Int32? MaxAllocatedStorage { get; set; }
            public System.Int32? MonitoringInterval { get; set; }
            public System.String MonitoringRoleArn { get; set; }
            public System.Boolean? MultiAZ { get; set; }
            public System.String NetworkType { get; set; }
            public System.String OptionGroupName { get; set; }
            public System.String PerformanceInsightsKMSKeyId { get; set; }
            public System.Int32? PerformanceInsightsRetentionPeriod { get; set; }
            public System.Int32? Port { get; set; }
            public System.String PreferredBackupWindow { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public List<Amazon.RDS.Model.ProcessorFeature> ProcessorFeature { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public System.String S3BucketName { get; set; }
            public System.String S3IngestionRoleArn { get; set; }
            public System.String S3Prefix { get; set; }
            public System.String SourceEngine { get; set; }
            public System.String SourceEngineVersion { get; set; }
            public System.Boolean? StorageEncrypted { get; set; }
            public System.Int32? StorageThroughput { get; set; }
            public System.String StorageType { get; set; }
            public List<Amazon.RDS.Model.Tag> Tag { get; set; }
            public System.Boolean? UseDefaultProcessorFeature { get; set; }
            public List<System.String> VpcSecurityGroupId { get; set; }
            public System.Func<Amazon.RDS.Model.RestoreDBInstanceFromS3Response, RestoreRDSDBInstanceFromS3Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBInstance;
        }
        
    }
}
