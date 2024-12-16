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
    /// Creates a new DB instance from a DB snapshot. The target database is created from
    /// the source database restore point with most of the source's original configuration,
    /// including the default security group and DB parameter group. By default, the new DB
    /// instance is created as a Single-AZ deployment, except when the instance is a SQL Server
    /// instance that has an option group associated with mirroring. In this case, the instance
    /// becomes a Multi-AZ deployment, not a Single-AZ deployment.
    /// 
    ///  
    /// <para>
    /// If you want to replace your original DB instance with the new, restored DB instance,
    /// then rename your original DB instance before you call the <c>RestoreDBInstanceFromDBSnapshot</c>
    /// operation. RDS doesn't allow two DB instances with the same name. After you have renamed
    /// your original DB instance with a different identifier, then you can pass the original
    /// name of the DB instance as the <c>DBInstanceIdentifier</c> in the call to the <c>RestoreDBInstanceFromDBSnapshot</c>
    /// operation. The result is that you replace the original DB instance with the DB instance
    /// created from the snapshot.
    /// </para><para>
    /// If you are restoring from a shared manual DB snapshot, the <c>DBSnapshotIdentifier</c>
    /// must be the ARN of the shared DB snapshot.
    /// </para><para>
    /// To restore from a DB snapshot with an unsupported engine version, you must first upgrade
    /// the engine version of the snapshot. For more information about upgrading a RDS for
    /// MySQL DB snapshot engine version, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/mysql-upgrade-snapshot.html">Upgrading
    /// a MySQL DB snapshot engine version</a>. For more information about upgrading a RDS
    /// for PostgreSQL DB snapshot engine version, <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_UpgradeDBSnapshot.PostgreSQL.html">Upgrading
    /// a PostgreSQL DB snapshot engine version</a>.
    /// </para><note><para>
    /// This command doesn't apply to Aurora MySQL and Aurora PostgreSQL. For Aurora, use
    /// <c>RestoreDBClusterFromSnapshot</c>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Restore", "RDSDBInstanceFromDBSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBInstance")]
    [AWSCmdlet("Calls the Amazon Relational Database Service RestoreDBInstanceFromDBSnapshot API operation.", Operation = new[] {"RestoreDBInstanceFromDBSnapshot"}, SelectReturnType = typeof(Amazon.RDS.Model.RestoreDBInstanceFromDBSnapshotResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBInstance or Amazon.RDS.Model.RestoreDBInstanceFromDBSnapshotResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBInstance object.",
        "The service call response (type Amazon.RDS.Model.RestoreDBInstanceFromDBSnapshotResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RestoreRDSDBInstanceFromDBSnapshotCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllocatedStorage
        /// <summary>
        /// <para>
        /// <para>The amount of storage (in gibibytes) to allocate initially for the DB instance. Follow
        /// the allocation rules specified in CreateDBInstance.</para><note><para>Be sure to allocate enough storage for your new DB instance so that the restore operation
        /// can succeed. You can also allocate additional storage for future growth.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AllocatedStorage { get; set; }
        #endregion
        
        #region Parameter AutoMinorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>Specifies whether to automatically apply minor version upgrades to the DB instance
        /// during the maintenance window.</para><para>If you restore an RDS Custom DB instance, you must disable this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoMinorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone (AZ) where the DB instance will be created.</para><para>Default: A random, system-chosen Availability Zone.</para><para>Constraint: You can't specify the <c>AvailabilityZone</c> parameter if the DB instance
        /// is a Multi-AZ deployment.</para><para>Example: <c>us-east-1a</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter BackupTarget
        /// <summary>
        /// <para>
        /// <para>Specifies where automated backups and manual snapshots are stored for the restored
        /// DB instance.</para><para>Possible values are <c>outposts</c> (Amazon Web Services Outposts) and <c>region</c>
        /// (Amazon Web Services Region). The default is <c>region</c>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/rds-on-outposts.html">Working
        /// with Amazon RDS on Amazon Web Services Outposts</a> in the <i>Amazon RDS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BackupTarget { get; set; }
        #endregion
        
        #region Parameter CACertificateIdentifier
        /// <summary>
        /// <para>
        /// <para>The CA certificate identifier to use for the DB instance's server certificate.</para><para>This setting doesn't apply to RDS Custom DB instances.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/UsingWithRDS.SSL.html">Using
        /// SSL/TLS to encrypt a connection to a DB instance</a> in the <i>Amazon RDS User Guide</i>
        /// and <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/UsingWithRDS.SSL.html">
        /// Using SSL/TLS to encrypt a connection to a DB cluster</a> in the <i>Amazon Aurora
        /// User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CACertificateIdentifier { get; set; }
        #endregion
        
        #region Parameter CopyTagsToSnapshot
        /// <summary>
        /// <para>
        /// <para>Specifies whether to copy all tags from the restored DB instance to snapshots of the
        /// DB instance.</para><para>In most cases, tags aren't copied by default. However, when you restore a DB instance
        /// from a DB snapshot, RDS checks whether you specify new tags. If yes, the new tags
        /// are added to the restored DB instance. If there are no new tags, RDS looks for the
        /// tags from the source DB instance for the DB snapshot, and then adds those tags to
        /// the restored DB instance.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_Tagging.html#USER_Tagging.CopyTags">
        /// Copying tags to DB instance snapshots</a> in the <i>Amazon RDS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CopyTagsToSnapshot { get; set; }
        #endregion
        
        #region Parameter CustomIamInstanceProfile
        /// <summary>
        /// <para>
        /// <para>The instance profile associated with the underlying Amazon EC2 instance of an RDS
        /// Custom DB instance. The instance profile must meet the following requirements:</para><ul><li><para>The profile must exist in your account.</para></li><li><para>The profile must have an IAM role that Amazon EC2 has permissions to assume.</para></li><li><para>The instance profile name and the associated IAM role name must start with the prefix
        /// <c>AWSRDSCustom</c>.</para></li></ul><para>For the list of permissions required for the IAM role, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/custom-setup-orcl.html#custom-setup-orcl.iam-vpc">
        /// Configure IAM and your VPC</a> in the <i>Amazon RDS User Guide</i>.</para><para>This setting is required for RDS Custom.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomIamInstanceProfile { get; set; }
        #endregion
        
        #region Parameter DBClusterSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the Multi-AZ DB cluster snapshot to restore from.</para><para>For more information on Multi-AZ DB clusters, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/multi-az-db-clusters-concepts.html">
        /// Multi-AZ DB cluster deployments</a> in the <i>Amazon RDS User Guide</i>.</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing Multi-AZ DB cluster snapshot.</para></li><li><para>Can't be specified when <c>DBSnapshotIdentifier</c> is specified.</para></li><li><para>Must be specified when <c>DBSnapshotIdentifier</c> isn't specified.</para></li><li><para>If you are restoring from a shared manual Multi-AZ DB cluster snapshot, the <c>DBClusterSnapshotIdentifier</c>
        /// must be the ARN of the shared snapshot.</para></li><li><para>Can't be the identifier of an Aurora DB cluster snapshot.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBClusterSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter DBInstanceClass
        /// <summary>
        /// <para>
        /// <para>The compute and memory capacity of the Amazon RDS DB instance, for example db.m4.large.
        /// Not all DB instance classes are available in all Amazon Web Services Regions, or for
        /// all database engines. For the full list of DB instance classes, and availability for
        /// your engine, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Concepts.DBInstanceClass.html">DB
        /// Instance Class</a> in the <i>Amazon RDS User Guide.</i></para><para>Default: The same DBInstanceClass as the original DB instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBInstanceClass { get; set; }
        #endregion
        
        #region Parameter DBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The name of the DB instance to create from the DB snapshot. This parameter isn't case-sensitive.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 numbers, letters, or hyphens.</para></li><li><para>First character must be a letter.</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens.</para></li></ul><para>Example: <c>my-snapshot-id</c></para>
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
        /// <para>The name of the database for the restored DB instance.</para><para>This parameter only applies to RDS for Oracle and RDS for SQL Server DB instances.
        /// It doesn't apply to the other engines or to RDS Custom DB instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBName { get; set; }
        #endregion
        
        #region Parameter DBParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the DB parameter group to associate with this DB instance.</para><para>If you don't specify a value for <c>DBParameterGroupName</c>, then RDS uses the default
        /// <c>DBParameterGroup</c> for the specified DB engine.</para><para>This setting doesn't apply to RDS Custom.</para><para>Constraints:</para><ul><li><para>If supplied, must match the name of an existing DB parameter group.</para></li><li><para>Must be 1 to 255 letters, numbers, or hyphens.</para></li><li><para>First character must be a letter.</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBParameterGroupName { get; set; }
        #endregion
        
        #region Parameter DBSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the DB snapshot to restore from.</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing DB snapshot.</para></li><li><para>Can't be specified when <c>DBClusterSnapshotIdentifier</c> is specified.</para></li><li><para>Must be specified when <c>DBClusterSnapshotIdentifier</c> isn't specified.</para></li><li><para>If you are restoring from a shared manual DB snapshot, the <c>DBSnapshotIdentifier</c>
        /// must be the ARN of the shared DB snapshot.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String DBSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter DBSubnetGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the DB subnet group to use for the new instance.</para><para>Constraints:</para><ul><li><para>If supplied, must match the name of an existing DB subnet group.</para></li></ul><para>Example: <c>mydbsubnetgroup</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBSubnetGroupName { get; set; }
        #endregion
        
        #region Parameter DedicatedLogVolume
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable a dedicated log volume (DLV) for the DB instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DedicatedLogVolume { get; set; }
        #endregion
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable deletion protection for the DB instance. The database
        /// can't be deleted when deletion protection is enabled. By default, deletion protection
        /// isn't enabled. For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_DeleteInstance.html">
        /// Deleting a DB Instance</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtection { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The Active Directory directory ID to restore the DB instance in. The domain/ must
        /// be created prior to this operation. Currently, you can create only Db2, MySQL, Microsoft
        /// SQL Server, Oracle, and PostgreSQL DB instances in an Active Directory Domain.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/kerberos-authentication.html">
        /// Kerberos Authentication</a> in the <i>Amazon RDS User Guide</i>.</para><para>This setting doesn't apply to RDS Custom.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter DomainAuthSecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN for the Secrets Manager secret with the credentials for the user joining the
        /// domain.</para><para>Constraints:</para><ul><li><para>Can't be longer than 64 characters.</para></li></ul><para>Example: <c>arn:aws:secretsmanager:region:account-number:secret:myselfmanagedADtestsecret-123456</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainAuthSecretArn { get; set; }
        #endregion
        
        #region Parameter DomainDnsIp
        /// <summary>
        /// <para>
        /// <para>The IPv4 DNS IP addresses of your primary and secondary Active Directory domain controllers.</para><para>Constraints:</para><ul><li><para>Two IP addresses must be provided. If there isn't a secondary domain controller, use
        /// the IP address of the primary domain controller for both entries in the list.</para></li></ul><para>Example: <c>123.124.125.126,234.235.236.237</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainDnsIps")]
        public System.String[] DomainDnsIp { get; set; }
        #endregion
        
        #region Parameter DomainFqdn
        /// <summary>
        /// <para>
        /// <para>The fully qualified domain name (FQDN) of an Active Directory domain.</para><para>Constraints:</para><ul><li><para>Can't be longer than 64 characters.</para></li></ul><para>Example: <c>mymanagedADtest.mymanagedAD.mydomain</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainFqdn { get; set; }
        #endregion
        
        #region Parameter DomainIAMRoleName
        /// <summary>
        /// <para>
        /// <para>The name of the IAM role to use when making API calls to the Directory Service.</para><para>This setting doesn't apply to RDS Custom DB instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainIAMRoleName { get; set; }
        #endregion
        
        #region Parameter DomainOu
        /// <summary>
        /// <para>
        /// <para>The Active Directory organizational unit for your DB instance to join.</para><para>Constraints:</para><ul><li><para>Must be in the distinguished name format.</para></li><li><para>Can't be longer than 64 characters.</para></li></ul><para>Example: <c>OU=mymanagedADtestOU,DC=mymanagedADtest,DC=mymanagedAD,DC=mydomain</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainOu { get; set; }
        #endregion
        
        #region Parameter EnableCloudwatchLogsExport
        /// <summary>
        /// <para>
        /// <para>The list of logs for the restored DB instance to export to CloudWatch Logs. The values
        /// in the list depend on the DB engine. For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_LogAccess.html#USER_LogAccess.Procedural.UploadtoCloudWatch">Publishing
        /// Database Logs to Amazon CloudWatch Logs</a> in the <i>Amazon RDS User Guide</i>.</para><para>This setting doesn't apply to RDS Custom.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnableCloudwatchLogsExports")]
        public System.String[] EnableCloudwatchLogsExport { get; set; }
        #endregion
        
        #region Parameter EnableCustomerOwnedIp
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable a customer-owned IP address (CoIP) for an RDS on Outposts
        /// DB instance.</para><para>A <i>CoIP</i> provides local or external connectivity to resources in your Outpost
        /// subnets through your on-premises network. For some use cases, a CoIP can provide lower
        /// latency for connections to the DB instance from outside of its virtual private cloud
        /// (VPC) on your local network.</para><para>This setting doesn't apply to RDS Custom.</para><para>For more information about RDS on Outposts, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/rds-on-outposts.html">Working
        /// with Amazon RDS on Amazon Web Services Outposts</a> in the <i>Amazon RDS User Guide</i>.</para><para>For more information about CoIPs, see <a href="https://docs.aws.amazon.com/outposts/latest/userguide/routing.html#ip-addressing">Customer-owned
        /// IP addresses</a> in the <i>Amazon Web Services Outposts User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableCustomerOwnedIp { get; set; }
        #endregion
        
        #region Parameter EnableIAMDatabaseAuthentication
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable mapping of Amazon Web Services Identity and Access Management
        /// (IAM) accounts to database accounts. By default, mapping is disabled.</para><para>For more information about IAM database authentication, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/UsingWithRDS.IAMDBAuth.html">
        /// IAM Database Authentication for MySQL and PostgreSQL</a> in the <i>Amazon RDS User
        /// Guide.</i></para><para>This setting doesn't apply to RDS Custom.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableIAMDatabaseAuthentication { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The database engine to use for the new instance.</para><para>This setting doesn't apply to RDS Custom.</para><para>Default: The same as source</para><para>Constraint: Must be compatible with the engine of the source. For example, you can
        /// restore a MariaDB 10.1 DB instance from a MySQL 5.6 snapshot.</para><para>Valid Values:</para><ul><li><para><c>db2-ae</c></para></li><li><para><c>db2-se</c></para></li><li><para><c>mariadb</c></para></li><li><para><c>mysql</c></para></li><li><para><c>oracle-ee</c></para></li><li><para><c>oracle-ee-cdb</c></para></li><li><para><c>oracle-se2</c></para></li><li><para><c>oracle-se2-cdb</c></para></li><li><para><c>postgres</c></para></li><li><para><c>sqlserver-ee</c></para></li><li><para><c>sqlserver-se</c></para></li><li><para><c>sqlserver-ex</c></para></li><li><para><c>sqlserver-web</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter EngineLifecycleSupport
        /// <summary>
        /// <para>
        /// <para>The life cycle type for this DB instance.</para><note><para>By default, this value is set to <c>open-source-rds-extended-support</c>, which enrolls
        /// your DB instance into Amazon RDS Extended Support. At the end of standard support,
        /// you can avoid charges for Extended Support by setting the value to <c>open-source-rds-extended-support-disabled</c>.
        /// In this case, RDS automatically upgrades your restored DB instance to a higher engine
        /// version, if the major engine version is past its end of standard support date.</para></note><para>You can use this setting to enroll your DB instance into Amazon RDS Extended Support.
        /// With RDS Extended Support, you can run the selected major engine version on your DB
        /// instance past the end of standard support for that engine version. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/extended-support.html">Using
        /// Amazon RDS Extended Support</a> in the <i>Amazon RDS User Guide</i>.</para><para>This setting applies only to RDS for MySQL and RDS for PostgreSQL. For Amazon Aurora
        /// DB instances, the life cycle type is managed by the DB cluster.</para><para>Valid Values: <c>open-source-rds-extended-support | open-source-rds-extended-support-disabled</c></para><para>Default: <c>open-source-rds-extended-support</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineLifecycleSupport { get; set; }
        #endregion
        
        #region Parameter Iops
        /// <summary>
        /// <para>
        /// <para>Specifies the amount of provisioned IOPS for the DB instance, expressed in I/O operations
        /// per second. If this parameter isn't specified, the IOPS value is taken from the backup.
        /// If this parameter is set to 0, the new instance is converted to a non-PIOPS instance.
        /// The conversion takes additional time, though your DB instance is available for connections
        /// before the conversion starts.</para><para>The provisioned IOPS value must follow the requirements for your database engine.
        /// For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_Storage.html#USER_PIOPS">Amazon
        /// RDS Provisioned IOPS storage</a> in the <i>Amazon RDS User Guide.</i></para><para>Constraints: Must be an integer greater than 1000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Iops { get; set; }
        #endregion
        
        #region Parameter LicenseModel
        /// <summary>
        /// <para>
        /// <para>License model information for the restored DB instance.</para><note><para>License models for RDS for Db2 require additional configuration. The Bring Your Own
        /// License (BYOL) model requires a custom parameter group and an Amazon Web Services
        /// License Manager self-managed license. The Db2 license through Amazon Web Services
        /// Marketplace model requires an Amazon Web Services Marketplace subscription. For more
        /// information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/db2-licensing.html">Amazon
        /// RDS for Db2 licensing options</a> in the <i>Amazon RDS User Guide</i>.</para></note><para>This setting doesn't apply to Amazon Aurora or RDS Custom DB instances.</para><para>Valid Values:</para><ul><li><para>RDS for Db2 - <c>bring-your-own-license | marketplace-license</c></para></li><li><para>RDS for MariaDB - <c>general-public-license</c></para></li><li><para>RDS for Microsoft SQL Server - <c>license-included</c></para></li><li><para>RDS for MySQL - <c>general-public-license</c></para></li><li><para>RDS for Oracle - <c>bring-your-own-license | license-included</c></para></li><li><para>RDS for PostgreSQL - <c>postgresql-license</c></para></li></ul><para>Default: Same as the source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LicenseModel { get; set; }
        #endregion
        
        #region Parameter MultiAZ
        /// <summary>
        /// <para>
        /// <para>Specifies whether the DB instance is a Multi-AZ deployment.</para><para>This setting doesn't apply to RDS Custom.</para><para>Constraint: You can't specify the <c>AvailabilityZone</c> parameter if the DB instance
        /// is a Multi-AZ deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MultiAZ { get; set; }
        #endregion
        
        #region Parameter NetworkType
        /// <summary>
        /// <para>
        /// <para>The network type of the DB instance.</para><para>Valid Values:</para><ul><li><para><c>IPV4</c></para></li><li><para><c>DUAL</c></para></li></ul><para>The network type is determined by the <c>DBSubnetGroup</c> specified for the DB instance.
        /// A <c>DBSubnetGroup</c> can support only the IPv4 protocol or the IPv4 and the IPv6
        /// protocols (<c>DUAL</c>).</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_VPC.WorkingWithRDSInstanceinaVPC.html">
        /// Working with a DB instance in a VPC</a> in the <i>Amazon RDS User Guide.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkType { get; set; }
        #endregion
        
        #region Parameter OptionGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the option group to be used for the restored DB instance.</para><para>Permanent options, such as the TDE option for Oracle Advanced Security TDE, can't
        /// be removed from an option group, and that option group can't be removed from a DB
        /// instance after it is associated with a DB instance.</para><para>This setting doesn't apply to RDS Custom.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OptionGroupName { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port number on which the database accepts connections.</para><para>Default: The same port as the original DB instance</para><para>Constraints: Value must be <c>1150-65535</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter ProcessorFeature
        /// <summary>
        /// <para>
        /// <para>The number of CPU cores and the number of threads per core for the DB instance class
        /// of the DB instance.</para><para>This setting doesn't apply to RDS Custom.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProcessorFeatures")]
        public Amazon.RDS.Model.ProcessorFeature[] ProcessorFeature { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>Specifies whether the DB instance is publicly accessible.</para><para>When the DB instance is publicly accessible, its Domain Name System (DNS) endpoint
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
        /// <para>Specifies the storage type to be associated with the DB instance.</para><para>Valid Values: <c>gp2 | gp3 | io1 | io2 | standard</c></para><para>If you specify <c>io1</c>, <c>io2</c>, or <c>gp3</c>, you must also include a value
        /// for the <c>Iops</c> parameter.</para><para>Default: <c>io1</c> if the <c>Iops</c> parameter is specified, otherwise <c>gp2</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TdeCredentialArn
        /// <summary>
        /// <para>
        /// <para>The ARN from the key store with which to associate the instance for TDE encryption.</para><para>This setting doesn't apply to RDS Custom.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TdeCredentialArn { get; set; }
        #endregion
        
        #region Parameter TdeCredentialPassword
        /// <summary>
        /// <para>
        /// <para>The password for the given ARN from the key store in order to access the device.</para><para>This setting doesn't apply to RDS Custom.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TdeCredentialPassword { get; set; }
        #endregion
        
        #region Parameter UseDefaultProcessorFeature
        /// <summary>
        /// <para>
        /// <para>Specifies whether the DB instance class of the DB instance uses its default processor
        /// features.</para><para>This setting doesn't apply to RDS Custom.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UseDefaultProcessorFeatures")]
        public System.Boolean? UseDefaultProcessorFeature { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of EC2 VPC security groups to associate with this DB instance.</para><para>Default: The default EC2 VPC security group for the DB subnet group's VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBInstance'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.RestoreDBInstanceFromDBSnapshotResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.RestoreDBInstanceFromDBSnapshotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBInstance";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-RDSDBInstanceFromDBSnapshot (RestoreDBInstanceFromDBSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.RestoreDBInstanceFromDBSnapshotResponse, RestoreRDSDBInstanceFromDBSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AllocatedStorage = this.AllocatedStorage;
            context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            context.AvailabilityZone = this.AvailabilityZone;
            context.BackupTarget = this.BackupTarget;
            context.CACertificateIdentifier = this.CACertificateIdentifier;
            context.CopyTagsToSnapshot = this.CopyTagsToSnapshot;
            context.CustomIamInstanceProfile = this.CustomIamInstanceProfile;
            context.DBClusterSnapshotIdentifier = this.DBClusterSnapshotIdentifier;
            context.DBInstanceClass = this.DBInstanceClass;
            context.DBInstanceIdentifier = this.DBInstanceIdentifier;
            #if MODULAR
            if (this.DBInstanceIdentifier == null && ParameterWasBound(nameof(this.DBInstanceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBInstanceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DBName = this.DBName;
            context.DBParameterGroupName = this.DBParameterGroupName;
            context.DBSnapshotIdentifier = this.DBSnapshotIdentifier;
            context.DBSubnetGroupName = this.DBSubnetGroupName;
            context.DedicatedLogVolume = this.DedicatedLogVolume;
            context.DeletionProtection = this.DeletionProtection;
            context.Domain = this.Domain;
            context.DomainAuthSecretArn = this.DomainAuthSecretArn;
            if (this.DomainDnsIp != null)
            {
                context.DomainDnsIp = new List<System.String>(this.DomainDnsIp);
            }
            context.DomainFqdn = this.DomainFqdn;
            context.DomainIAMRoleName = this.DomainIAMRoleName;
            context.DomainOu = this.DomainOu;
            if (this.EnableCloudwatchLogsExport != null)
            {
                context.EnableCloudwatchLogsExport = new List<System.String>(this.EnableCloudwatchLogsExport);
            }
            context.EnableCustomerOwnedIp = this.EnableCustomerOwnedIp;
            context.EnableIAMDatabaseAuthentication = this.EnableIAMDatabaseAuthentication;
            context.Engine = this.Engine;
            context.EngineLifecycleSupport = this.EngineLifecycleSupport;
            context.Iops = this.Iops;
            context.LicenseModel = this.LicenseModel;
            context.MultiAZ = this.MultiAZ;
            context.NetworkType = this.NetworkType;
            context.OptionGroupName = this.OptionGroupName;
            context.Port = this.Port;
            if (this.ProcessorFeature != null)
            {
                context.ProcessorFeature = new List<Amazon.RDS.Model.ProcessorFeature>(this.ProcessorFeature);
            }
            context.PubliclyAccessible = this.PubliclyAccessible;
            context.StorageThroughput = this.StorageThroughput;
            context.StorageType = this.StorageType;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
            context.TdeCredentialArn = this.TdeCredentialArn;
            context.TdeCredentialPassword = this.TdeCredentialPassword;
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
            var request = new Amazon.RDS.Model.RestoreDBInstanceFromDBSnapshotRequest();
            
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
            if (cmdletContext.BackupTarget != null)
            {
                request.BackupTarget = cmdletContext.BackupTarget;
            }
            if (cmdletContext.CACertificateIdentifier != null)
            {
                request.CACertificateIdentifier = cmdletContext.CACertificateIdentifier;
            }
            if (cmdletContext.CopyTagsToSnapshot != null)
            {
                request.CopyTagsToSnapshot = cmdletContext.CopyTagsToSnapshot.Value;
            }
            if (cmdletContext.CustomIamInstanceProfile != null)
            {
                request.CustomIamInstanceProfile = cmdletContext.CustomIamInstanceProfile;
            }
            if (cmdletContext.DBClusterSnapshotIdentifier != null)
            {
                request.DBClusterSnapshotIdentifier = cmdletContext.DBClusterSnapshotIdentifier;
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
            if (cmdletContext.DBSnapshotIdentifier != null)
            {
                request.DBSnapshotIdentifier = cmdletContext.DBSnapshotIdentifier;
            }
            if (cmdletContext.DBSubnetGroupName != null)
            {
                request.DBSubnetGroupName = cmdletContext.DBSubnetGroupName;
            }
            if (cmdletContext.DedicatedLogVolume != null)
            {
                request.DedicatedLogVolume = cmdletContext.DedicatedLogVolume.Value;
            }
            if (cmdletContext.DeletionProtection != null)
            {
                request.DeletionProtection = cmdletContext.DeletionProtection.Value;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            if (cmdletContext.DomainAuthSecretArn != null)
            {
                request.DomainAuthSecretArn = cmdletContext.DomainAuthSecretArn;
            }
            if (cmdletContext.DomainDnsIp != null)
            {
                request.DomainDnsIps = cmdletContext.DomainDnsIp;
            }
            if (cmdletContext.DomainFqdn != null)
            {
                request.DomainFqdn = cmdletContext.DomainFqdn;
            }
            if (cmdletContext.DomainIAMRoleName != null)
            {
                request.DomainIAMRoleName = cmdletContext.DomainIAMRoleName;
            }
            if (cmdletContext.DomainOu != null)
            {
                request.DomainOu = cmdletContext.DomainOu;
            }
            if (cmdletContext.EnableCloudwatchLogsExport != null)
            {
                request.EnableCloudwatchLogsExports = cmdletContext.EnableCloudwatchLogsExport;
            }
            if (cmdletContext.EnableCustomerOwnedIp != null)
            {
                request.EnableCustomerOwnedIp = cmdletContext.EnableCustomerOwnedIp.Value;
            }
            if (cmdletContext.EnableIAMDatabaseAuthentication != null)
            {
                request.EnableIAMDatabaseAuthentication = cmdletContext.EnableIAMDatabaseAuthentication.Value;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.EngineLifecycleSupport != null)
            {
                request.EngineLifecycleSupport = cmdletContext.EngineLifecycleSupport;
            }
            if (cmdletContext.Iops != null)
            {
                request.Iops = cmdletContext.Iops.Value;
            }
            if (cmdletContext.LicenseModel != null)
            {
                request.LicenseModel = cmdletContext.LicenseModel;
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
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.ProcessorFeature != null)
            {
                request.ProcessorFeatures = cmdletContext.ProcessorFeature;
            }
            if (cmdletContext.PubliclyAccessible != null)
            {
                request.PubliclyAccessible = cmdletContext.PubliclyAccessible.Value;
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
            if (cmdletContext.TdeCredentialArn != null)
            {
                request.TdeCredentialArn = cmdletContext.TdeCredentialArn;
            }
            if (cmdletContext.TdeCredentialPassword != null)
            {
                request.TdeCredentialPassword = cmdletContext.TdeCredentialPassword;
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
        
        private Amazon.RDS.Model.RestoreDBInstanceFromDBSnapshotResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.RestoreDBInstanceFromDBSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "RestoreDBInstanceFromDBSnapshot");
            try
            {
                #if DESKTOP
                return client.RestoreDBInstanceFromDBSnapshot(request);
                #elif CORECLR
                return client.RestoreDBInstanceFromDBSnapshotAsync(request).GetAwaiter().GetResult();
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
            public System.String BackupTarget { get; set; }
            public System.String CACertificateIdentifier { get; set; }
            public System.Boolean? CopyTagsToSnapshot { get; set; }
            public System.String CustomIamInstanceProfile { get; set; }
            public System.String DBClusterSnapshotIdentifier { get; set; }
            public System.String DBInstanceClass { get; set; }
            public System.String DBInstanceIdentifier { get; set; }
            public System.String DBName { get; set; }
            public System.String DBParameterGroupName { get; set; }
            public System.String DBSnapshotIdentifier { get; set; }
            public System.String DBSubnetGroupName { get; set; }
            public System.Boolean? DedicatedLogVolume { get; set; }
            public System.Boolean? DeletionProtection { get; set; }
            public System.String Domain { get; set; }
            public System.String DomainAuthSecretArn { get; set; }
            public List<System.String> DomainDnsIp { get; set; }
            public System.String DomainFqdn { get; set; }
            public System.String DomainIAMRoleName { get; set; }
            public System.String DomainOu { get; set; }
            public List<System.String> EnableCloudwatchLogsExport { get; set; }
            public System.Boolean? EnableCustomerOwnedIp { get; set; }
            public System.Boolean? EnableIAMDatabaseAuthentication { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineLifecycleSupport { get; set; }
            public System.Int32? Iops { get; set; }
            public System.String LicenseModel { get; set; }
            public System.Boolean? MultiAZ { get; set; }
            public System.String NetworkType { get; set; }
            public System.String OptionGroupName { get; set; }
            public System.Int32? Port { get; set; }
            public List<Amazon.RDS.Model.ProcessorFeature> ProcessorFeature { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public System.Int32? StorageThroughput { get; set; }
            public System.String StorageType { get; set; }
            public List<Amazon.RDS.Model.Tag> Tag { get; set; }
            public System.String TdeCredentialArn { get; set; }
            public System.String TdeCredentialPassword { get; set; }
            public System.Boolean? UseDefaultProcessorFeature { get; set; }
            public List<System.String> VpcSecurityGroupId { get; set; }
            public System.Func<Amazon.RDS.Model.RestoreDBInstanceFromDBSnapshotResponse, RestoreRDSDBInstanceFromDBSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBInstance;
        }
        
    }
}
