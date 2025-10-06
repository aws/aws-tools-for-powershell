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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Creates a new DB instance.
    /// 
    ///  
    /// <para>
    /// The new DB instance can be an RDS DB instance, or it can be a DB instance in an Aurora
    /// DB cluster. For an Aurora DB cluster, you can call this operation multiple times to
    /// add more than one DB instance to the cluster.
    /// </para><para>
    /// For more information about creating an RDS DB instance, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_CreateDBInstance.html">
    /// Creating an Amazon RDS DB instance</a> in the <i>Amazon RDS User Guide</i>.
    /// </para><para>
    /// For more information about creating a DB instance in an Aurora DB cluster, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/Aurora.CreateInstance.html">
    /// Creating an Amazon Aurora DB cluster</a> in the <i>Amazon Aurora User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "RDSDBInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBInstance")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CreateDBInstance API operation.", Operation = new[] {"CreateDBInstance"}, SelectReturnType = typeof(Amazon.RDS.Model.CreateDBInstanceResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBInstance or Amazon.RDS.Model.CreateDBInstanceResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBInstance object.",
        "The service call response (type Amazon.RDS.Model.CreateDBInstanceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewRDSDBInstanceCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllocatedStorage
        /// <summary>
        /// <para>
        /// <para>The amount of storage in gibibytes (GiB) to allocate for the DB instance.</para><para>This setting doesn't apply to Amazon Aurora DB instances. Aurora cluster volumes automatically
        /// grow as the amount of data in your database increases, though you are only charged
        /// for the space that you use in an Aurora cluster volume.</para><dl><dt>Amazon RDS Custom</dt><dd><para>Constraints to the amount of storage for each storage type are the following:</para><ul><li><para>General Purpose (SSD) storage (gp2, gp3): Must be an integer from 40 to 65536 for
        /// RDS Custom for Oracle, 16384 for RDS Custom for SQL Server.</para></li><li><para>Provisioned IOPS storage (io1, io2): Must be an integer from 40 to 65536 for RDS Custom
        /// for Oracle, 16384 for RDS Custom for SQL Server.</para></li></ul></dd><dt>RDS for Db2</dt><dd><para>Constraints to the amount of storage for each storage type are the following:</para><ul><li><para>General Purpose (SSD) storage (gp3): Must be an integer from 20 to 65536.</para></li><li><para>Provisioned IOPS storage (io1, io2): Must be an integer from 100 to 65536.</para></li></ul></dd><dt>RDS for MariaDB</dt><dd><para>Constraints to the amount of storage for each storage type are the following:</para><ul><li><para>General Purpose (SSD) storage (gp2, gp3): Must be an integer from 20 to 65536.</para></li><li><para>Provisioned IOPS storage (io1, io2): Must be an integer from 100 to 65536.</para></li><li><para>Magnetic storage (standard): Must be an integer from 5 to 3072.</para></li></ul></dd><dt>RDS for MySQL</dt><dd><para>Constraints to the amount of storage for each storage type are the following:</para><ul><li><para>General Purpose (SSD) storage (gp2, gp3): Must be an integer from 20 to 65536.</para></li><li><para>Provisioned IOPS storage (io1, io2): Must be an integer from 100 to 65536.</para></li><li><para>Magnetic storage (standard): Must be an integer from 5 to 3072.</para></li></ul></dd><dt>RDS for Oracle</dt><dd><para>Constraints to the amount of storage for each storage type are the following:</para><ul><li><para>General Purpose (SSD) storage (gp2, gp3): Must be an integer from 20 to 65536.</para></li><li><para>Provisioned IOPS storage (io1, io2): Must be an integer from 100 to 65536.</para></li><li><para>Magnetic storage (standard): Must be an integer from 10 to 3072.</para></li></ul></dd><dt>RDS for PostgreSQL</dt><dd><para>Constraints to the amount of storage for each storage type are the following:</para><ul><li><para>General Purpose (SSD) storage (gp2, gp3): Must be an integer from 20 to 65536.</para></li><li><para>Provisioned IOPS storage (io1, io2): Must be an integer from 100 to 65536.</para></li><li><para>Magnetic storage (standard): Must be an integer from 5 to 3072.</para></li></ul></dd><dt>RDS for SQL Server</dt><dd><para>Constraints to the amount of storage for each storage type are the following:</para><ul><li><para>General Purpose (SSD) storage (gp2, gp3):</para><ul><li><para>Enterprise and Standard editions: Must be an integer from 20 to 16384.</para></li><li><para>Web and Express editions: Must be an integer from 20 to 16384.</para></li></ul></li><li><para>Provisioned IOPS storage (io1, io2):</para><ul><li><para>Enterprise and Standard editions: Must be an integer from 100 to 16384.</para></li><li><para>Web and Express editions: Must be an integer from 100 to 16384.</para></li></ul></li><li><para>Magnetic storage (standard):</para><ul><li><para>Enterprise and Standard editions: Must be an integer from 20 to 1024.</para></li><li><para>Web and Express editions: Must be an integer from 20 to 1024.</para></li></ul></li></ul></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AllocatedStorage { get; set; }
        #endregion
        
        #region Parameter AutoMinorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>Specifies whether minor engine upgrades are applied automatically to the DB instance
        /// during the maintenance window. By default, minor engine upgrades are applied automatically.</para><para>If you create an RDS Custom DB instance, you must set <c>AutoMinorVersionUpgrade</c>
        /// to <c>false</c>.</para><para>For more information about automatic minor version upgrades, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_UpgradeDBInstance.Upgrading.html#USER_UpgradeDBInstance.Upgrading.AutoMinorVersionUpgrades">Automatically
        /// upgrading the minor engine version</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoMinorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone (AZ) where the database will be created. For information on
        /// Amazon Web Services Regions and Availability Zones, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Concepts.RegionsAndAvailabilityZones.html">Regions
        /// and Availability Zones</a>.</para><para>For Amazon Aurora, each Aurora DB cluster hosts copies of its storage in three separate
        /// Availability Zones. Specify one of these Availability Zones. Aurora automatically
        /// chooses an appropriate Availability Zone if you don't specify one.</para><para>Default: A random, system-chosen Availability Zone in the endpoint's Amazon Web Services
        /// Region.</para><para>Constraints:</para><ul><li><para>The <c>AvailabilityZone</c> parameter can't be specified if the DB instance is a Multi-AZ
        /// deployment.</para></li><li><para>The specified Availability Zone must be in the same Amazon Web Services Region as
        /// the current endpoint.</para></li></ul><para>Example: <c>us-east-1d</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter BackupRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days for which automated backups are retained. Setting this parameter
        /// to a positive number enables backups. Setting this parameter to <c>0</c> disables
        /// automated backups.</para><para>This setting doesn't apply to Amazon Aurora DB instances. The retention period for
        /// automated backups is managed by the DB cluster.</para><para>Default: <c>1</c></para><para>Constraints:</para><ul><li><para>Must be a value from 0 to 35.</para></li><li><para>Can't be set to 0 if the DB instance is a source to read replicas.</para></li><li><para>Can't be set to 0 for an RDS Custom for Oracle DB instance.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BackupRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter BackupTarget
        /// <summary>
        /// <para>
        /// <para>The location for storing automated backups and manual snapshots.</para><para>Valid Values:</para><ul><li><para><c>local</c> (Dedicated Local Zone)</para></li><li><para><c>outposts</c> (Amazon Web Services Outposts)</para></li><li><para><c>region</c> (Amazon Web Services Region)</para></li></ul><para>Default: <c>region</c></para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/rds-on-outposts.html">Working
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
        
        #region Parameter CharacterSetName
        /// <summary>
        /// <para>
        /// <para>For supported engines, the character set (<c>CharacterSet</c>) to associate the DB
        /// instance with.</para><para>This setting doesn't apply to the following DB instances:</para><ul><li><para>Amazon Aurora - The character set is managed by the DB cluster. For more information,
        /// see <c>CreateDBCluster</c>.</para></li><li><para>RDS Custom - However, if you need to change the character set, you can change it on
        /// the database itself.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CharacterSetName { get; set; }
        #endregion
        
        #region Parameter CopyTagsToSnapshot
        /// <summary>
        /// <para>
        /// <para>Specifies whether to copy tags from the DB instance to snapshots of the DB instance.
        /// By default, tags are not copied.</para><para>This setting doesn't apply to Amazon Aurora DB instances. Copying tags to snapshots
        /// is managed by the DB cluster. Setting this value for an Aurora DB instance has no
        /// effect on the DB cluster setting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CopyTagsToSnapshot { get; set; }
        #endregion
        
        #region Parameter CustomIamInstanceProfile
        /// <summary>
        /// <para>
        /// <para>The instance profile associated with the underlying Amazon EC2 instance of an RDS
        /// Custom DB instance.</para><para>This setting is required for RDS Custom.</para><para>Constraints:</para><ul><li><para>The profile must exist in your account.</para></li><li><para>The profile must have an IAM role that Amazon EC2 has permissions to assume.</para></li><li><para>The instance profile name and the associated IAM role name must start with the prefix
        /// <c>AWSRDSCustom</c>.</para></li></ul><para>For the list of permissions required for the IAM role, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/custom-setup-orcl.html#custom-setup-orcl.iam-vpc">
        /// Configure IAM and your VPC</a> in the <i>Amazon RDS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomIamInstanceProfile { get; set; }
        #endregion
        
        #region Parameter DatabaseInsightsMode
        /// <summary>
        /// <para>
        /// <para>The mode of Database Insights to enable for the DB instance.</para><note><para>Aurora DB instances inherit this value from the DB cluster, so you can't change this
        /// value.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RDS.DatabaseInsightsMode")]
        public Amazon.RDS.DatabaseInsightsMode DatabaseInsightsMode { get; set; }
        #endregion
        
        #region Parameter DBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the DB cluster that this DB instance will belong to.</para><para>This setting doesn't apply to RDS Custom DB instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter DBInstanceClass
        /// <summary>
        /// <para>
        /// <para>The compute and memory capacity of the DB instance, for example <c>db.m5.large</c>.
        /// Not all DB instance classes are available in all Amazon Web Services Regions, or for
        /// all database engines. For the full list of DB instance classes, and availability for
        /// your engine, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Concepts.DBInstanceClass.html">DB
        /// instance classes</a> in the <i>Amazon RDS User Guide</i> or <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/Concepts.DBInstanceClass.html">Aurora
        /// DB instance classes</a> in the <i>Amazon Aurora User Guide</i>.</para>
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
        /// <para>The identifier for this DB instance. This parameter is stored as a lowercase string.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 letters, numbers, or hyphens.</para></li><li><para>First character must be a letter.</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens.</para></li></ul><para>Example: <c>mydbinstance</c></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter DBName
        /// <summary>
        /// <para>
        /// <para>The meaning of this parameter differs according to the database engine you use.</para><dl><dt>Amazon Aurora MySQL</dt><dd><para>The name of the database to create when the primary DB instance of the Aurora MySQL
        /// DB cluster is created. If this parameter isn't specified for an Aurora MySQL DB cluster,
        /// no database is created in the DB cluster.</para><para>Constraints:</para><ul><li><para>Must contain 1 to 64 alphanumeric characters.</para></li><li><para>Must begin with a letter. Subsequent characters can be letters, underscores, or digits
        /// (0-9).</para></li><li><para>Can't be a word reserved by the database engine.</para></li></ul></dd><dt>Amazon Aurora PostgreSQL</dt><dd><para>The name of the database to create when the primary DB instance of the Aurora PostgreSQL
        /// DB cluster is created. A database named <c>postgres</c> is always created. If this
        /// parameter is specified, an additional database with this name is created.</para><para>Constraints:</para><ul><li><para>It must contain 1 to 63 alphanumeric characters.</para></li><li><para>Must begin with a letter. Subsequent characters can be letters, underscores, or digits
        /// (0 to 9).</para></li><li><para>Can't be a word reserved by the database engine.</para></li></ul></dd><dt>Amazon RDS Custom for Oracle</dt><dd><para>The Oracle System ID (SID) of the created RDS Custom DB instance. If you don't specify
        /// a value, the default value is <c>ORCL</c> for non-CDBs and <c>RDSCDB</c> for CDBs.</para><para>Default: <c>ORCL</c></para><para>Constraints:</para><ul><li><para>Must contain 1 to 8 alphanumeric characters.</para></li><li><para>Must contain a letter.</para></li><li><para>Can't be a word reserved by the database engine.</para></li></ul></dd><dt>Amazon RDS Custom for SQL Server</dt><dd><para>Not applicable. Must be null.</para></dd><dt>RDS for Db2</dt><dd><para>The name of the database to create when the DB instance is created. If this parameter
        /// isn't specified, no database is created in the DB instance. In some cases, we recommend
        /// that you don't add a database name. For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/db2-db-instance-prereqs.html#db2-prereqs-additional-considerations">Additional
        /// considerations</a> in the <i>Amazon RDS User Guide</i>.</para><para>Constraints:</para><ul><li><para>Must contain 1 to 64 letters or numbers.</para></li><li><para>Must begin with a letter. Subsequent characters can be letters, underscores, or digits
        /// (0-9).</para></li><li><para>Can't be a word reserved by the specified database engine.</para></li></ul></dd><dt>RDS for MariaDB</dt><dd><para>The name of the database to create when the DB instance is created. If this parameter
        /// isn't specified, no database is created in the DB instance.</para><para>Constraints:</para><ul><li><para>Must contain 1 to 64 letters or numbers.</para></li><li><para>Must begin with a letter. Subsequent characters can be letters, underscores, or digits
        /// (0-9).</para></li><li><para>Can't be a word reserved by the specified database engine.</para></li></ul></dd><dt>RDS for MySQL</dt><dd><para>The name of the database to create when the DB instance is created. If this parameter
        /// isn't specified, no database is created in the DB instance.</para><para>Constraints:</para><ul><li><para>Must contain 1 to 64 letters or numbers.</para></li><li><para>Must begin with a letter. Subsequent characters can be letters, underscores, or digits
        /// (0-9).</para></li><li><para>Can't be a word reserved by the specified database engine.</para></li></ul></dd><dt>RDS for Oracle</dt><dd><para>The Oracle System ID (SID) of the created DB instance. If you don't specify a value,
        /// the default value is <c>ORCL</c>. You can't specify the string <c>null</c>, or any
        /// other reserved word, for <c>DBName</c>.</para><para>Default: <c>ORCL</c></para><para>Constraints:</para><ul><li><para>Can't be longer than 8 characters.</para></li></ul></dd><dt>RDS for PostgreSQL</dt><dd><para>The name of the database to create when the DB instance is created. A database named
        /// <c>postgres</c> is always created. If this parameter is specified, an additional database
        /// with this name is created.</para><para>Constraints:</para><ul><li><para>Must contain 1 to 63 letters, numbers, or underscores.</para></li><li><para>Must begin with a letter. Subsequent characters can be letters, underscores, or digits
        /// (0-9).</para></li><li><para>Can't be a word reserved by the specified database engine.</para></li></ul></dd><dt>RDS for SQL Server</dt><dd><para>Not applicable. Must be null.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DBName { get; set; }
        #endregion
        
        #region Parameter DBParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the DB parameter group to associate with this DB instance. If you don't
        /// specify a value, then Amazon RDS uses the default DB parameter group for the specified
        /// DB engine and version.</para><para>This setting doesn't apply to RDS Custom DB instances.</para><para>Constraints:</para><ul><li><para>Must be 1 to 255 letters, numbers, or hyphens.</para></li><li><para>The first character must be a letter.</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBParameterGroupName { get; set; }
        #endregion
        
        #region Parameter DBSecurityGroup
        /// <summary>
        /// <para>
        /// <para>A list of DB security groups to associate with this DB instance.</para><para>This setting applies to the legacy EC2-Classic platform, which is no longer used to
        /// create new DB instances. Use the <c>VpcSecurityGroupIds</c> setting instead.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DBSecurityGroups")]
        public System.String[] DBSecurityGroup { get; set; }
        #endregion
        
        #region Parameter DBSubnetGroupName
        /// <summary>
        /// <para>
        /// <para>A DB subnet group to associate with this DB instance.</para><para>Constraints:</para><ul><li><para>Must match the name of an existing DB subnet group.</para></li></ul><para>Example: <c>mydbsubnetgroup</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBSubnetGroupName { get; set; }
        #endregion
        
        #region Parameter DBSystemId
        /// <summary>
        /// <para>
        /// <para>The Oracle system identifier (SID), which is the name of the Oracle database instance
        /// that manages your database files. In this context, the term "Oracle database instance"
        /// refers exclusively to the system global area (SGA) and Oracle background processes.
        /// If you don't specify a SID, the value defaults to <c>RDSCDB</c>. The Oracle SID is
        /// also the name of your CDB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBSystemId { get; set; }
        #endregion
        
        #region Parameter DedicatedLogVolume
        /// <summary>
        /// <para>
        /// <para>Indicates whether the DB instance has a dedicated log volume (DLV) enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DedicatedLogVolume { get; set; }
        #endregion
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para>Specifies whether the DB instance has deletion protection enabled. The database can't
        /// be deleted when deletion protection is enabled. By default, deletion protection isn't
        /// enabled. For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_DeleteInstance.html">
        /// Deleting a DB Instance</a>.</para><para>This setting doesn't apply to Amazon Aurora DB instances. You can enable or disable
        /// deletion protection for the DB cluster. For more information, see <c>CreateDBCluster</c>.
        /// DB instances in a DB cluster can be deleted even when deletion protection is enabled
        /// for the DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtection { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The Active Directory directory ID to create the DB instance in. Currently, you can
        /// create only Db2, MySQL, Microsoft SQL Server, Oracle, and PostgreSQL DB instances
        /// in an Active Directory Domain.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/kerberos-authentication.html">
        /// Kerberos Authentication</a> in the <i>Amazon RDS User Guide</i>.</para><para>This setting doesn't apply to the following DB instances:</para><ul><li><para>Amazon Aurora (The domain is managed by the DB cluster.)</para></li><li><para>RDS Custom</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter DomainAuthSecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN for the Secrets Manager secret with the credentials for the user joining the
        /// domain.</para><para>Example: <c>arn:aws:secretsmanager:region:account-number:secret:myselfmanagedADtestsecret-123456</c></para>
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
        /// <para>The name of the IAM role to use when making API calls to the Directory Service.</para><para>This setting doesn't apply to the following DB instances:</para><ul><li><para>Amazon Aurora (The domain is managed by the DB cluster.)</para></li><li><para>RDS Custom</para></li></ul>
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
        /// <para>The list of log types to enable for exporting to CloudWatch Logs. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_LogAccess.html#USER_LogAccess.Procedural.UploadtoCloudWatch">
        /// Publishing Database Logs to Amazon CloudWatch Logs</a> in the <i>Amazon RDS User Guide</i>.</para><para>This setting doesn't apply to the following DB instances:</para><ul><li><para>Amazon Aurora (CloudWatch Logs exports are managed by the DB cluster.)</para></li><li><para>RDS Custom</para></li></ul><para>The following values are valid for each DB engine:</para><ul><li><para>RDS for Db2 - <c>diag.log | notify.log | iam-db-auth-error</c></para></li><li><para>RDS for MariaDB - <c>audit | error | general | slowquery | iam-db-auth-error</c></para></li><li><para>RDS for Microsoft SQL Server - <c>agent | error</c></para></li><li><para>RDS for MySQL - <c>audit | error | general | slowquery | iam-db-auth-error</c></para></li><li><para>RDS for Oracle - <c>alert | audit | listener | trace | oemagent</c></para></li><li><para>RDS for PostgreSQL - <c>postgresql | upgrade | iam-db-auth-error</c></para></li></ul>
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
        /// (VPC) on your local network.</para><para>For more information about RDS on Outposts, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/rds-on-outposts.html">Working
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
        /// (IAM) accounts to database accounts. By default, mapping isn't enabled.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/UsingWithRDS.IAMDBAuth.html">
        /// IAM Database Authentication for MySQL and PostgreSQL</a> in the <i>Amazon RDS User
        /// Guide</i>.</para><para>This setting doesn't apply to the following DB instances:</para><ul><li><para>Amazon Aurora (Mapping Amazon Web Services IAM accounts to database accounts is managed
        /// by the DB cluster.)</para></li><li><para>RDS Custom</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableIAMDatabaseAuthentication { get; set; }
        #endregion
        
        #region Parameter EnablePerformanceInsight
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable Performance Insights for the DB instance. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_PerfInsights.html">Using
        /// Amazon Performance Insights</a> in the <i>Amazon RDS User Guide</i>.</para><para>This setting doesn't apply to RDS Custom DB instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnablePerformanceInsights")]
        public System.Boolean? EnablePerformanceInsight { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The database engine to use for this DB instance.</para><para>Not every database engine is available in every Amazon Web Services Region.</para><para>Valid Values:</para><ul><li><para><c>aurora-mysql</c> (for Aurora MySQL DB instances)</para></li><li><para><c>aurora-postgresql</c> (for Aurora PostgreSQL DB instances)</para></li><li><para><c>custom-oracle-ee</c> (for RDS Custom for Oracle DB instances)</para></li><li><para><c>custom-oracle-ee-cdb</c> (for RDS Custom for Oracle DB instances)</para></li><li><para><c>custom-oracle-se2</c> (for RDS Custom for Oracle DB instances)</para></li><li><para><c>custom-oracle-se2-cdb</c> (for RDS Custom for Oracle DB instances)</para></li><li><para><c>custom-sqlserver-ee</c> (for RDS Custom for SQL Server DB instances)</para></li><li><para><c>custom-sqlserver-se</c> (for RDS Custom for SQL Server DB instances)</para></li><li><para><c>custom-sqlserver-web</c> (for RDS Custom for SQL Server DB instances)</para></li><li><para><c>custom-sqlserver-dev</c> (for RDS Custom for SQL Server DB instances)</para></li><li><para><c>db2-ae</c></para></li><li><para><c>db2-se</c></para></li><li><para><c>mariadb</c></para></li><li><para><c>mysql</c></para></li><li><para><c>oracle-ee</c></para></li><li><para><c>oracle-ee-cdb</c></para></li><li><para><c>oracle-se2</c></para></li><li><para><c>oracle-se2-cdb</c></para></li><li><para><c>postgres</c></para></li><li><para><c>sqlserver-ee</c></para></li><li><para><c>sqlserver-se</c></para></li><li><para><c>sqlserver-ex</c></para></li><li><para><c>sqlserver-web</c></para></li></ul>
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
        
        #region Parameter EngineLifecycleSupport
        /// <summary>
        /// <para>
        /// <para>The life cycle type for this DB instance.</para><note><para>By default, this value is set to <c>open-source-rds-extended-support</c>, which enrolls
        /// your DB instance into Amazon RDS Extended Support. At the end of standard support,
        /// you can avoid charges for Extended Support by setting the value to <c>open-source-rds-extended-support-disabled</c>.
        /// In this case, creating the DB instance will fail if the DB major version is past its
        /// end of standard support date.</para></note><para>This setting applies only to RDS for MySQL and RDS for PostgreSQL. For Amazon Aurora
        /// DB instances, the life cycle type is managed by the DB cluster.</para><para>You can use this setting to enroll your DB instance into Amazon RDS Extended Support.
        /// With RDS Extended Support, you can run the selected major engine version on your DB
        /// instance past the end of standard support for that engine version. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/extended-support.html">Amazon
        /// RDS Extended Support with Amazon RDS</a> in the <i>Amazon RDS User Guide</i>.</para><para>Valid Values: <c>open-source-rds-extended-support | open-source-rds-extended-support-disabled</c></para><para>Default: <c>open-source-rds-extended-support</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineLifecycleSupport { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The version number of the database engine to use.</para><para>This setting doesn't apply to Amazon Aurora DB instances. The version number of the
        /// database engine the DB instance uses is managed by the DB cluster.</para><para>For a list of valid engine versions, use the <c>DescribeDBEngineVersions</c> operation.</para><para>The following are the database engines and links to information about the major and
        /// minor versions that are available with Amazon RDS. Not every database engine is available
        /// for every Amazon Web Services Region.</para><dl><dt>Amazon RDS Custom for Oracle</dt><dd><para>A custom engine version (CEV) that you have previously created. This setting is required
        /// for RDS Custom for Oracle. The CEV name has the following format: 19.<i>customized_string</i>.
        /// A valid CEV name is <c>19.my_cev1</c>. For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/custom-creating.html#custom-creating.create">
        /// Creating an RDS Custom for Oracle DB instance</a> in the <i>Amazon RDS User Guide</i>.</para></dd><dt>Amazon RDS Custom for SQL Server</dt><dd><para>See <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/custom-reqs-limits-MS.html">RDS
        /// Custom for SQL Server general requirements</a> in the <i>Amazon RDS User Guide</i>.</para></dd><dt>RDS for Db2</dt><dd><para>For information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_Db2.html#Db2.Concepts.VersionMgmt">Db2
        /// on Amazon RDS versions</a> in the <i>Amazon RDS User Guide</i>.</para></dd><dt>RDS for MariaDB</dt><dd><para>For information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_MariaDB.html#MariaDB.Concepts.VersionMgmt">MariaDB
        /// on Amazon RDS versions</a> in the <i>Amazon RDS User Guide</i>.</para></dd><dt>RDS for Microsoft SQL Server</dt><dd><para>For information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_SQLServer.html#SQLServer.Concepts.General.VersionSupport">Microsoft
        /// SQL Server versions on Amazon RDS</a> in the <i>Amazon RDS User Guide</i>.</para></dd><dt>RDS for MySQL</dt><dd><para>For information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_MySQL.html#MySQL.Concepts.VersionMgmt">MySQL
        /// on Amazon RDS versions</a> in the <i>Amazon RDS User Guide</i>.</para></dd><dt>RDS for Oracle</dt><dd><para>For information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Appendix.Oracle.PatchComposition.html">Oracle
        /// Database Engine release notes</a> in the <i>Amazon RDS User Guide</i>.</para></dd><dt>RDS for PostgreSQL</dt><dd><para>For information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_PostgreSQL.html#PostgreSQL.Concepts">Amazon
        /// RDS for PostgreSQL versions and extensions</a> in the <i>Amazon RDS User Guide</i>.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter Iops
        /// <summary>
        /// <para>
        /// <para>The amount of Provisioned IOPS (input/output operations per second) to initially allocate
        /// for the DB instance. For information about valid IOPS values, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_Storage.html">Amazon
        /// RDS DB instance storage</a> in the <i>Amazon RDS User Guide</i>.</para><para>This setting doesn't apply to Amazon Aurora DB instances. Storage is managed by the
        /// DB cluster.</para><para>Constraints:</para><ul><li><para>For RDS for Db2, MariaDB, MySQL, Oracle, and PostgreSQL - Must be a multiple between
        /// .5 and 50 of the storage amount for the DB instance.</para></li><li><para>For RDS for SQL Server - Must be a multiple between 1 and 50 of the storage amount
        /// for the DB instance.</para></li></ul>
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
        /// specify the key ARN or alias ARN.</para><para>This setting doesn't apply to Amazon Aurora DB instances. The Amazon Web Services
        /// KMS key identifier is managed by the DB cluster. For more information, see <c>CreateDBCluster</c>.</para><para>If <c>StorageEncrypted</c> is enabled, and you do not specify a value for the <c>KmsKeyId</c>
        /// parameter, then Amazon RDS uses your default KMS key. There is a default KMS key for
        /// your Amazon Web Services account. Your Amazon Web Services account has a different
        /// default KMS key for each Amazon Web Services Region.</para><para>For Amazon RDS Custom, a KMS key is required for DB instances. For most RDS engines,
        /// if you leave this parameter empty while enabling <c>StorageEncrypted</c>, the engine
        /// uses the default KMS key. However, RDS Custom doesn't use the default key when this
        /// parameter is empty. You must explicitly specify a key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter LicenseModel
        /// <summary>
        /// <para>
        /// <para>The license model information for this DB instance.</para><note><para>License models for RDS for Db2 require additional configuration. The bring your own
        /// license (BYOL) model requires a custom parameter group and an Amazon Web Services
        /// License Manager self-managed license. The Db2 license through Amazon Web Services
        /// Marketplace model requires an Amazon Web Services Marketplace subscription. For more
        /// information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/db2-licensing.html">Amazon
        /// RDS for Db2 licensing options</a> in the <i>Amazon RDS User Guide</i>.</para><para>The default for RDS for Db2 is <c>bring-your-own-license</c>.</para></note><para>This setting doesn't apply to Amazon Aurora or RDS Custom DB instances.</para><para>Valid Values:</para><ul><li><para>RDS for Db2 - <c>bring-your-own-license | marketplace-license</c></para></li><li><para>RDS for MariaDB - <c>general-public-license</c></para></li><li><para>RDS for Microsoft SQL Server - <c>license-included</c></para></li><li><para>RDS for MySQL - <c>general-public-license</c></para></li><li><para>RDS for Oracle - <c>bring-your-own-license | license-included</c></para></li><li><para>RDS for PostgreSQL - <c>postgresql-license</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LicenseModel { get; set; }
        #endregion
        
        #region Parameter ManageMasterUserPassword
        /// <summary>
        /// <para>
        /// <para>Specifies whether to manage the master user password with Amazon Web Services Secrets
        /// Manager.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/rds-secrets-manager.html">Password
        /// management with Amazon Web Services Secrets Manager</a> in the <i>Amazon RDS User
        /// Guide.</i></para><para>Constraints:</para><ul><li><para>Can't manage the master user password with Amazon Web Services Secrets Manager if
        /// <c>MasterUserPassword</c> is specified.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ManageMasterUserPassword { get; set; }
        #endregion
        
        #region Parameter MasterUserAuthenticationType
        /// <summary>
        /// <para>
        /// <para>Specifies the authentication type for the master user. With IAM master user authentication,
        /// you can configure the master DB user with IAM database authentication when you create
        /// a DB instance.</para><para>You can specify one of the following values:</para><ul><li><para><c>password</c> - Use standard database authentication with a password.</para></li><li><para><c>iam-db-auth</c> - Use IAM database authentication for the master user.</para></li></ul><para>This option is only valid for RDS for PostgreSQL and Aurora PostgreSQL engines.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RDS.MasterUserAuthenticationType")]
        public Amazon.RDS.MasterUserAuthenticationType MasterUserAuthenticationType { get; set; }
        #endregion
        
        #region Parameter MasterUsername
        /// <summary>
        /// <para>
        /// <para>The name for the master user.</para><para>This setting doesn't apply to Amazon Aurora DB instances. The name for the master
        /// user is managed by the DB cluster.</para><para>This setting is required for RDS DB instances.</para><para>Constraints:</para><ul><li><para>Must be 1 to 16 letters, numbers, or underscores.</para></li><li><para>First character must be a letter.</para></li><li><para>Can't be a reserved word for the chosen database engine.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MasterUsername { get; set; }
        #endregion
        
        #region Parameter MasterUserPassword
        /// <summary>
        /// <para>
        /// <para>The password for the master user.</para><para>This setting doesn't apply to Amazon Aurora DB instances. The password for the master
        /// user is managed by the DB cluster.</para><para>Constraints:</para><ul><li><para>Can't be specified if <c>ManageMasterUserPassword</c> is turned on.</para></li><li><para>Can include any printable ASCII character except "/", """, or "@". For RDS for Oracle,
        /// can't include the "&amp;" (ampersand) or the "'" (single quotes) character.</para></li></ul><para>Length Constraints:</para><ul><li><para>RDS for Db2 - Must contain from 8 to 255 characters.</para></li><li><para>RDS for MariaDB - Must contain from 8 to 41 characters.</para></li><li><para>RDS for Microsoft SQL Server - Must contain from 8 to 128 characters.</para></li><li><para>RDS for MySQL - Must contain from 8 to 41 characters.</para></li><li><para>RDS for Oracle - Must contain from 8 to 30 characters.</para></li><li><para>RDS for PostgreSQL - Must contain from 8 to 128 characters.</para></li></ul>
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
        /// specify the key ARN or alias ARN.</para><para>If you don't specify <c>MasterUserSecretKmsKeyId</c>, then the <c>aws/secretsmanager</c>
        /// KMS key is used to encrypt the secret. If the secret is in a different Amazon Web
        /// Services account, then you can't use the <c>aws/secretsmanager</c> KMS key to encrypt
        /// the secret, and you must use a customer managed KMS key.</para><para>There is a default KMS key for your Amazon Web Services account. Your Amazon Web Services
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
        /// RDS User Guide</i>.</para><para>This setting doesn't apply to the following DB instances:</para><ul><li><para>Amazon Aurora (Storage is managed by the DB cluster.)</para></li><li><para>RDS Custom</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxAllocatedStorage { get; set; }
        #endregion
        
        #region Parameter MonitoringInterval
        /// <summary>
        /// <para>
        /// <para>The interval, in seconds, between points when Enhanced Monitoring metrics are collected
        /// for the DB instance. To disable collection of Enhanced Monitoring metrics, specify
        /// <c>0</c>.</para><para>If <c>MonitoringRoleArn</c> is specified, then you must set <c>MonitoringInterval</c>
        /// to a value other than <c>0</c>.</para><para>This setting doesn't apply to RDS Custom DB instances.</para><para>Valid Values: <c>0 | 1 | 5 | 10 | 15 | 30 | 60</c></para><para>Default: <c>0</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MonitoringInterval { get; set; }
        #endregion
        
        #region Parameter MonitoringRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN for the IAM role that permits RDS to send enhanced monitoring metrics to Amazon
        /// CloudWatch Logs. For example, <c>arn:aws:iam:123456789012:role/emaccess</c>. For information
        /// on creating a monitoring role, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_Monitoring.OS.html#USER_Monitoring.OS.Enabling">Setting
        /// Up and Enabling Enhanced Monitoring</a> in the <i>Amazon RDS User Guide</i>.</para><para>If <c>MonitoringInterval</c> is set to a value other than <c>0</c>, then you must
        /// supply a <c>MonitoringRoleArn</c> value.</para><para>This setting doesn't apply to RDS Custom DB instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MonitoringRoleArn { get; set; }
        #endregion
        
        #region Parameter MultiAZ
        /// <summary>
        /// <para>
        /// <para>Specifies whether the DB instance is a Multi-AZ deployment. You can't set the <c>AvailabilityZone</c>
        /// parameter if the DB instance is a Multi-AZ deployment.</para><para>This setting doesn't apply to Amazon Aurora because the DB instance Availability Zones
        /// (AZs) are managed by the DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MultiAZ { get; set; }
        #endregion
        
        #region Parameter MultiTenant
        /// <summary>
        /// <para>
        /// <para>Specifies whether to use the multi-tenant configuration or the single-tenant configuration
        /// (default). This parameter only applies to RDS for Oracle container database (CDB)
        /// engines.</para><para>Note the following restrictions: </para><ul><li><para>The DB engine that you specify in the request must support the multi-tenant configuration.
        /// If you attempt to enable the multi-tenant configuration on a DB engine that doesn't
        /// support it, the request fails.</para></li><li><para>If you specify the multi-tenant configuration when you create your DB instance, you
        /// can't later modify this DB instance to use the single-tenant configuration.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MultiTenant { get; set; }
        #endregion
        
        #region Parameter NcharCharacterSetName
        /// <summary>
        /// <para>
        /// <para>The name of the NCHAR character set for the Oracle DB instance.</para><para>This setting doesn't apply to RDS Custom DB instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NcharCharacterSetName { get; set; }
        #endregion
        
        #region Parameter NetworkType
        /// <summary>
        /// <para>
        /// <para>The network type of the DB instance.</para><para>The network type is determined by the <c>DBSubnetGroup</c> specified for the DB instance.
        /// A <c>DBSubnetGroup</c> can support only the IPv4 protocol or the IPv4 and the IPv6
        /// protocols (<c>DUAL</c>).</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_VPC.WorkingWithRDSInstanceinaVPC.html">
        /// Working with a DB instance in a VPC</a> in the <i>Amazon RDS User Guide.</i></para><para>Valid Values: <c>IPV4 | DUAL</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkType { get; set; }
        #endregion
        
        #region Parameter OptionGroupName
        /// <summary>
        /// <para>
        /// <para>The option group to associate the DB instance with.</para><para>Permanent options, such as the TDE option for Oracle Advanced Security TDE, can't
        /// be removed from an option group. Also, that option group can't be removed from a DB
        /// instance after it is associated with a DB instance.</para><para>This setting doesn't apply to Amazon Aurora or RDS Custom DB instances.</para>
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
        /// name for the KMS key.</para><para>If you don't specify a value for <c>PerformanceInsightsKMSKeyId</c>, then Amazon RDS
        /// uses your default KMS key. There is a default KMS key for your Amazon Web Services
        /// account. Your Amazon Web Services account has a different default KMS key for each
        /// Amazon Web Services Region.</para><para>This setting doesn't apply to RDS Custom DB instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PerformanceInsightsKMSKeyId { get; set; }
        #endregion
        
        #region Parameter PerformanceInsightsRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days to retain Performance Insights data.</para><para>This setting doesn't apply to RDS Custom DB instances.</para><para>Valid Values:</para><ul><li><para><c>7</c></para></li><li><para><i>month</i> * 31, where <i>month</i> is a number of months from 1-23. Examples:
        /// <c>93</c> (3 months * 31), <c>341</c> (11 months * 31), <c>589</c> (19 months * 31)</para></li><li><para><c>731</c></para></li></ul><para>Default: <c>7</c> days</para><para>If you specify a retention period that isn't valid, such as <c>94</c>, Amazon RDS
        /// returns an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PerformanceInsightsRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port number on which the database accepts connections.</para><para>This setting doesn't apply to Aurora DB instances. The port number is managed by the
        /// cluster.</para><para>Valid Values: <c>1150-65535</c></para><para>Default:</para><ul><li><para>RDS for Db2 - <c>50000</c></para></li><li><para>RDS for MariaDB - <c>3306</c></para></li><li><para>RDS for Microsoft SQL Server - <c>1433</c></para></li><li><para>RDS for MySQL - <c>3306</c></para></li><li><para>RDS for Oracle - <c>1521</c></para></li><li><para>RDS for PostgreSQL - <c>5432</c></para></li></ul><para>Constraints:</para><ul><li><para>For RDS for Microsoft SQL Server, the value can't be <c>1234</c>, <c>1434</c>, <c>3260</c>,
        /// <c>3343</c>, <c>3389</c>, <c>47001</c>, or <c>49152-49156</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter PreferredBackupWindow
        /// <summary>
        /// <para>
        /// <para>The daily time range during which automated backups are created if automated backups
        /// are enabled, using the <c>BackupRetentionPeriod</c> parameter. The default is a 30-minute
        /// window selected at random from an 8-hour block of time for each Amazon Web Services
        /// Region. For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_WorkingWithAutomatedBackups.html#USER_WorkingWithAutomatedBackups.BackupWindow">Backup
        /// window</a> in the <i>Amazon RDS User Guide</i>.</para><para>This setting doesn't apply to Amazon Aurora DB instances. The daily time range for
        /// creating automated backups is managed by the DB cluster.</para><para>Constraints:</para><ul><li><para>Must be in the format <c>hh24:mi-hh24:mi</c>.</para></li><li><para>Must be in Universal Coordinated Time (UTC).</para></li><li><para>Must not conflict with the preferred maintenance window.</para></li><li><para>Must be at least 30 minutes.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredBackupWindow { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>The time range each week during which system maintenance can occur. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_UpgradeDBInstance.Maintenance.html#Concepts.DBMaintenance">Amazon
        /// RDS Maintenance Window</a> in the <i>Amazon RDS User Guide.</i></para><para>The default is a 30-minute window selected at random from an 8-hour block of time
        /// for each Amazon Web Services Region, occurring on a random day of the week.</para><para>Constraints:</para><ul><li><para>Must be in the format <c>ddd:hh24:mi-ddd:hh24:mi</c>.</para></li><li><para>The day values must be <c>mon | tue | wed | thu | fri | sat | sun</c>. </para></li><li><para>Must be in Universal Coordinated Time (UTC).</para></li><li><para>Must not conflict with the preferred backup window.</para></li><li><para>Must be at least 30 minutes.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter ProcessorFeature
        /// <summary>
        /// <para>
        /// <para>The number of CPU cores and the number of threads per core for the DB instance class
        /// of the DB instance.</para><para>This setting doesn't apply to Amazon Aurora or RDS Custom DB instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProcessorFeatures")]
        public Amazon.RDS.Model.ProcessorFeature[] ProcessorFeature { get; set; }
        #endregion
        
        #region Parameter PromotionTier
        /// <summary>
        /// <para>
        /// <para>The order of priority in which an Aurora Replica is promoted to the primary instance
        /// after a failure of the existing primary instance. For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/Concepts.AuroraHighAvailability.html#Aurora.Managing.FaultTolerance">
        /// Fault Tolerance for an Aurora DB Cluster</a> in the <i>Amazon Aurora User Guide</i>.</para><para>This setting doesn't apply to RDS Custom DB instances.</para><para>Default: <c>1</c></para><para>Valid Values: <c>0 - 15</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PromotionTier { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>Specifies whether the DB instance is publicly accessible.</para><para>When the DB instance is publicly accessible and you connect from outside of the DB
        /// instance's virtual private cloud (VPC), its domain name system (DNS) endpoint resolves
        /// to the public IP address. When you connect from within the same VPC as the DB instance,
        /// the endpoint resolves to the private IP address. Access to the DB instance is controlled
        /// by its security group settings.</para><para>When the DB instance isn't publicly accessible, it is an internal DB instance with
        /// a DNS name that resolves to a private IP address.</para><para>The default behavior when <c>PubliclyAccessible</c> is not specified depends on whether
        /// a <c>DBSubnetGroup</c> is specified.</para><para>If <c>DBSubnetGroup</c> isn't specified, <c>PubliclyAccessible</c> defaults to <c>false</c>
        /// for Aurora instances and <c>true</c> for non-Aurora instances.</para><para>If <c>DBSubnetGroup</c> is specified, <c>PubliclyAccessible</c> defaults to <c>false</c>
        /// unless the value of <c>DBSubnetGroup</c> is <c>default</c>, in which case <c>PubliclyAccessible</c>
        /// defaults to <c>true</c>.</para><para>If <c>PubliclyAccessible</c> is true and the VPC that the <c>DBSubnetGroup</c> is
        /// in doesn't have an internet gateway attached to it, Amazon RDS returns an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter StorageEncrypted
        /// <summary>
        /// <para>
        /// <para>Specifes whether the DB instance is encrypted. By default, it isn't encrypted.</para><para>For RDS Custom DB instances, either enable this setting or leave it unset. Otherwise,
        /// Amazon RDS reports an error.</para><para>This setting doesn't apply to Amazon Aurora DB instances. The encryption for DB instances
        /// is managed by the DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? StorageEncrypted { get; set; }
        #endregion
        
        #region Parameter StorageThroughput
        /// <summary>
        /// <para>
        /// <para>The storage throughput value, in mebibyte per second (MiBps), for the DB instance.</para><para>This setting applies only to the <c>gp3</c> storage type.</para><para>This setting doesn't apply to Amazon Aurora or RDS Custom DB instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StorageThroughput { get; set; }
        #endregion
        
        #region Parameter StorageType
        /// <summary>
        /// <para>
        /// <para>The storage type to associate with the DB instance.</para><para>If you specify <c>io1</c>, <c>io2</c>, or <c>gp3</c>, you must also include a value
        /// for the <c>Iops</c> parameter.</para><para>This setting doesn't apply to Amazon Aurora DB instances. Storage is managed by the
        /// DB cluster.</para><para>Valid Values: <c>gp2 | gp3 | io1 | io2 | standard</c></para><para>Default: <c>io1</c>, if the <c>Iops</c> parameter is specified. Otherwise, <c>gp3</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to assign to the DB instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TdeCredentialArn
        /// <summary>
        /// <para>
        /// <para>The ARN from the key store with which to associate the instance for TDE encryption.</para><para>This setting doesn't apply to Amazon Aurora or RDS Custom DB instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TdeCredentialArn { get; set; }
        #endregion
        
        #region Parameter TdeCredentialPassword
        /// <summary>
        /// <para>
        /// <para>The password for the given ARN from the key store in order to access the device.</para><para>This setting doesn't apply to RDS Custom DB instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TdeCredentialPassword { get; set; }
        #endregion
        
        #region Parameter Timezone
        /// <summary>
        /// <para>
        /// <para>The time zone of the DB instance. The time zone parameter is currently supported only
        /// by <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/db2-time-zone">RDS
        /// for Db2</a> and <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_SQLServer.html#SQLServer.Concepts.General.TimeZone">RDS
        /// for SQL Server</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Timezone { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of Amazon EC2 VPC security groups to associate with this DB instance.</para><para>This setting doesn't apply to Amazon Aurora DB instances. The associated list of EC2
        /// VPC security groups is managed by the DB cluster.</para><para>Default: The default EC2 VPC security group for the DB subnet group's VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBInstance'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.CreateDBInstanceResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.CreateDBInstanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBInstance";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DBName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DBName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DBName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RDSDBInstance (CreateDBInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.CreateDBInstanceResponse, NewRDSDBInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DBName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AllocatedStorage = this.AllocatedStorage;
            context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            context.AvailabilityZone = this.AvailabilityZone;
            context.BackupRetentionPeriod = this.BackupRetentionPeriod;
            context.BackupTarget = this.BackupTarget;
            context.CACertificateIdentifier = this.CACertificateIdentifier;
            context.CharacterSetName = this.CharacterSetName;
            context.CopyTagsToSnapshot = this.CopyTagsToSnapshot;
            context.CustomIamInstanceProfile = this.CustomIamInstanceProfile;
            context.DatabaseInsightsMode = this.DatabaseInsightsMode;
            context.DBClusterIdentifier = this.DBClusterIdentifier;
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
            context.DBSystemId = this.DBSystemId;
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
            context.EnablePerformanceInsight = this.EnablePerformanceInsight;
            context.Engine = this.Engine;
            #if MODULAR
            if (this.Engine == null && ParameterWasBound(nameof(this.Engine)))
            {
                WriteWarning("You are passing $null as a value for parameter Engine which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EngineLifecycleSupport = this.EngineLifecycleSupport;
            context.EngineVersion = this.EngineVersion;
            context.Iops = this.Iops;
            context.KmsKeyId = this.KmsKeyId;
            context.LicenseModel = this.LicenseModel;
            context.ManageMasterUserPassword = this.ManageMasterUserPassword;
            context.MasterUserAuthenticationType = this.MasterUserAuthenticationType;
            context.MasterUsername = this.MasterUsername;
            context.MasterUserPassword = this.MasterUserPassword;
            context.MasterUserSecretKmsKeyId = this.MasterUserSecretKmsKeyId;
            context.MaxAllocatedStorage = this.MaxAllocatedStorage;
            context.MonitoringInterval = this.MonitoringInterval;
            context.MonitoringRoleArn = this.MonitoringRoleArn;
            context.MultiAZ = this.MultiAZ;
            context.MultiTenant = this.MultiTenant;
            context.NcharCharacterSetName = this.NcharCharacterSetName;
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
            context.PromotionTier = this.PromotionTier;
            context.PubliclyAccessible = this.PubliclyAccessible;
            context.StorageEncrypted = this.StorageEncrypted;
            context.StorageThroughput = this.StorageThroughput;
            context.StorageType = this.StorageType;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
            context.TdeCredentialArn = this.TdeCredentialArn;
            context.TdeCredentialPassword = this.TdeCredentialPassword;
            context.Timezone = this.Timezone;
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
            var request = new Amazon.RDS.Model.CreateDBInstanceRequest();
            
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
            if (cmdletContext.BackupTarget != null)
            {
                request.BackupTarget = cmdletContext.BackupTarget;
            }
            if (cmdletContext.CACertificateIdentifier != null)
            {
                request.CACertificateIdentifier = cmdletContext.CACertificateIdentifier;
            }
            if (cmdletContext.CharacterSetName != null)
            {
                request.CharacterSetName = cmdletContext.CharacterSetName;
            }
            if (cmdletContext.CopyTagsToSnapshot != null)
            {
                request.CopyTagsToSnapshot = cmdletContext.CopyTagsToSnapshot.Value;
            }
            if (cmdletContext.CustomIamInstanceProfile != null)
            {
                request.CustomIamInstanceProfile = cmdletContext.CustomIamInstanceProfile;
            }
            if (cmdletContext.DatabaseInsightsMode != null)
            {
                request.DatabaseInsightsMode = cmdletContext.DatabaseInsightsMode;
            }
            if (cmdletContext.DBClusterIdentifier != null)
            {
                request.DBClusterIdentifier = cmdletContext.DBClusterIdentifier;
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
            if (cmdletContext.DBSystemId != null)
            {
                request.DBSystemId = cmdletContext.DBSystemId;
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
            if (cmdletContext.EnablePerformanceInsight != null)
            {
                request.EnablePerformanceInsights = cmdletContext.EnablePerformanceInsight.Value;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.EngineLifecycleSupport != null)
            {
                request.EngineLifecycleSupport = cmdletContext.EngineLifecycleSupport;
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
            if (cmdletContext.MasterUserAuthenticationType != null)
            {
                request.MasterUserAuthenticationType = cmdletContext.MasterUserAuthenticationType;
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
            if (cmdletContext.MultiTenant != null)
            {
                request.MultiTenant = cmdletContext.MultiTenant.Value;
            }
            if (cmdletContext.NcharCharacterSetName != null)
            {
                request.NcharCharacterSetName = cmdletContext.NcharCharacterSetName;
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
            if (cmdletContext.PromotionTier != null)
            {
                request.PromotionTier = cmdletContext.PromotionTier.Value;
            }
            if (cmdletContext.PubliclyAccessible != null)
            {
                request.PubliclyAccessible = cmdletContext.PubliclyAccessible.Value;
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
            if (cmdletContext.TdeCredentialArn != null)
            {
                request.TdeCredentialArn = cmdletContext.TdeCredentialArn;
            }
            if (cmdletContext.TdeCredentialPassword != null)
            {
                request.TdeCredentialPassword = cmdletContext.TdeCredentialPassword;
            }
            if (cmdletContext.Timezone != null)
            {
                request.Timezone = cmdletContext.Timezone;
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
        
        private Amazon.RDS.Model.CreateDBInstanceResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.CreateDBInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "CreateDBInstance");
            try
            {
                #if DESKTOP
                return client.CreateDBInstance(request);
                #elif CORECLR
                return client.CreateDBInstanceAsync(request).GetAwaiter().GetResult();
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
            public System.String BackupTarget { get; set; }
            public System.String CACertificateIdentifier { get; set; }
            public System.String CharacterSetName { get; set; }
            public System.Boolean? CopyTagsToSnapshot { get; set; }
            public System.String CustomIamInstanceProfile { get; set; }
            public Amazon.RDS.DatabaseInsightsMode DatabaseInsightsMode { get; set; }
            public System.String DBClusterIdentifier { get; set; }
            public System.String DBInstanceClass { get; set; }
            public System.String DBInstanceIdentifier { get; set; }
            public System.String DBName { get; set; }
            public System.String DBParameterGroupName { get; set; }
            public List<System.String> DBSecurityGroup { get; set; }
            public System.String DBSubnetGroupName { get; set; }
            public System.String DBSystemId { get; set; }
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
            public System.Boolean? EnablePerformanceInsight { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineLifecycleSupport { get; set; }
            public System.String EngineVersion { get; set; }
            public System.Int32? Iops { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String LicenseModel { get; set; }
            public System.Boolean? ManageMasterUserPassword { get; set; }
            public Amazon.RDS.MasterUserAuthenticationType MasterUserAuthenticationType { get; set; }
            public System.String MasterUsername { get; set; }
            public System.String MasterUserPassword { get; set; }
            public System.String MasterUserSecretKmsKeyId { get; set; }
            public System.Int32? MaxAllocatedStorage { get; set; }
            public System.Int32? MonitoringInterval { get; set; }
            public System.String MonitoringRoleArn { get; set; }
            public System.Boolean? MultiAZ { get; set; }
            public System.Boolean? MultiTenant { get; set; }
            public System.String NcharCharacterSetName { get; set; }
            public System.String NetworkType { get; set; }
            public System.String OptionGroupName { get; set; }
            public System.String PerformanceInsightsKMSKeyId { get; set; }
            public System.Int32? PerformanceInsightsRetentionPeriod { get; set; }
            public System.Int32? Port { get; set; }
            public System.String PreferredBackupWindow { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public List<Amazon.RDS.Model.ProcessorFeature> ProcessorFeature { get; set; }
            public System.Int32? PromotionTier { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public System.Boolean? StorageEncrypted { get; set; }
            public System.Int32? StorageThroughput { get; set; }
            public System.String StorageType { get; set; }
            public List<Amazon.RDS.Model.Tag> Tag { get; set; }
            public System.String TdeCredentialArn { get; set; }
            public System.String TdeCredentialPassword { get; set; }
            public System.String Timezone { get; set; }
            public List<System.String> VpcSecurityGroupId { get; set; }
            public System.Func<Amazon.RDS.Model.CreateDBInstanceResponse, NewRDSDBInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBInstance;
        }
        
    }
}
