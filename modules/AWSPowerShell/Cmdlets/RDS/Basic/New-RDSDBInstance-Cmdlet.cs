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
    /// Creates a new DB instance.
    /// </summary>
    [Cmdlet("New", "RDSDBInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBInstance")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CreateDBInstance API operation.", Operation = new[] {"CreateDBInstance"}, SelectReturnType = typeof(Amazon.RDS.Model.CreateDBInstanceResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBInstance or Amazon.RDS.Model.CreateDBInstanceResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBInstance object.",
        "The service call response (type Amazon.RDS.Model.CreateDBInstanceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewRDSDBInstanceCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter AllocatedStorage
        /// <summary>
        /// <para>
        /// <para>The amount of storage (in gibibytes) to allocate for the DB instance.</para><para>Type: Integer</para><para><b>Amazon Aurora</b></para><para>Not applicable. Aurora cluster volumes automatically grow as the amount of data in
        /// your database increases, though you are only charged for the space that you use in
        /// an Aurora cluster volume.</para><para><b>MySQL</b></para><para>Constraints to the amount of storage for each storage type are the following: </para><ul><li><para>General Purpose (SSD) storage (gp2): Must be an integer from 20 to 65536.</para></li><li><para>Provisioned IOPS storage (io1): Must be an integer from 100 to 65536.</para></li><li><para>Magnetic storage (standard): Must be an integer from 5 to 3072.</para></li></ul><para><b>MariaDB</b></para><para>Constraints to the amount of storage for each storage type are the following: </para><ul><li><para>General Purpose (SSD) storage (gp2): Must be an integer from 20 to 65536.</para></li><li><para>Provisioned IOPS storage (io1): Must be an integer from 100 to 65536.</para></li><li><para>Magnetic storage (standard): Must be an integer from 5 to 3072.</para></li></ul><para><b>PostgreSQL</b></para><para>Constraints to the amount of storage for each storage type are the following: </para><ul><li><para>General Purpose (SSD) storage (gp2): Must be an integer from 20 to 65536.</para></li><li><para>Provisioned IOPS storage (io1): Must be an integer from 100 to 65536.</para></li><li><para>Magnetic storage (standard): Must be an integer from 5 to 3072.</para></li></ul><para><b>Oracle</b></para><para>Constraints to the amount of storage for each storage type are the following: </para><ul><li><para>General Purpose (SSD) storage (gp2): Must be an integer from 20 to 65536.</para></li><li><para>Provisioned IOPS storage (io1): Must be an integer from 100 to 65536.</para></li><li><para>Magnetic storage (standard): Must be an integer from 10 to 3072.</para></li></ul><para><b>SQL Server</b></para><para>Constraints to the amount of storage for each storage type are the following: </para><ul><li><para>General Purpose (SSD) storage (gp2):</para><ul><li><para>Enterprise and Standard editions: Must be an integer from 200 to 16384.</para></li><li><para>Web and Express editions: Must be an integer from 20 to 16384.</para></li></ul></li><li><para>Provisioned IOPS storage (io1):</para><ul><li><para>Enterprise and Standard editions: Must be an integer from 200 to 16384.</para></li><li><para>Web and Express editions: Must be an integer from 100 to 16384.</para></li></ul></li><li><para>Magnetic storage (standard):</para><ul><li><para>Enterprise and Standard editions: Must be an integer from 200 to 1024.</para></li><li><para>Web and Express editions: Must be an integer from 20 to 1024.</para></li></ul></li></ul>
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
        /// applied automatically.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoMinorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para> The Availability Zone (AZ) where the database will be created. For information on
        /// AWS Regions and Availability Zones, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Concepts.RegionsAndAvailabilityZones.html">Regions
        /// and Availability Zones</a>. </para><para>Default: A random, system-chosen Availability Zone in the endpoint's AWS Region.</para><para> Example: <code>us-east-1d</code></para><para> Constraint: The <code>AvailabilityZone</code> parameter can't be specified if the
        /// DB instance is a Multi-AZ deployment. The specified Availability Zone must be in the
        /// same AWS Region as the current endpoint. </para><note><para>If you're creating a DB instance in an RDS on VMware environment, specify the identifier
        /// of the custom Availability Zone to create the DB instance in.</para><para>For more information about RDS on VMware, see the <a href="https://docs.aws.amazon.com/AmazonRDS/latest/RDSonVMwareUserGuide/rds-on-vmware.html"><i>RDS on VMware User Guide.</i></a></para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter BackupRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days for which automated backups are retained. Setting this parameter
        /// to a positive number enables backups. Setting this parameter to 0 disables automated
        /// backups.</para><para><b>Amazon Aurora</b></para><para>Not applicable. The retention period for automated backups is managed by the DB cluster.</para><para>Default: 1</para><para>Constraints:</para><ul><li><para>Must be a value from 0 to 35</para></li><li><para>Can't be set to 0 if the DB instance is a source to read replicas</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BackupRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter CharacterSetName
        /// <summary>
        /// <para>
        /// <para>For supported engines, indicates that the DB instance should be associated with the
        /// specified CharacterSet.</para><para><b>Amazon Aurora</b></para><para>Not applicable. The character set is managed by the DB cluster. For more information,
        /// see <code>CreateDBCluster</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CharacterSetName { get; set; }
        #endregion
        
        #region Parameter CopyTagsToSnapshot
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to copy tags from the DB instance to snapshots of the
        /// DB instance. By default, tags are not copied.</para><para><b>Amazon Aurora</b></para><para>Not applicable. Copying tags to snapshots is managed by the DB cluster. Setting this
        /// value for an Aurora DB instance has no effect on the DB cluster setting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CopyTagsToSnapshot { get; set; }
        #endregion
        
        #region Parameter DBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the DB cluster that the instance will belong to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter DBInstanceClass
        /// <summary>
        /// <para>
        /// <para>The compute and memory capacity of the DB instance, for example, <code>db.m4.large</code>.
        /// Not all DB instance classes are available in all AWS Regions, or for all database
        /// engines. For the full list of DB instance classes, and availability for your engine,
        /// see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Concepts.DBInstanceClass.html">DB
        /// Instance Class</a> in the <i>Amazon RDS User Guide.</i></para>
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
        /// <para>The meaning of this parameter differs according to the database engine you use.</para><para><b>MySQL</b></para><para>The name of the database to create when the DB instance is created. If this parameter
        /// isn't specified, no database is created in the DB instance.</para><para>Constraints:</para><ul><li><para>Must contain 1 to 64 letters or numbers.</para></li><li><para>Must begin with a letter. Subsequent characters can be letters, underscores, or digits
        /// (0-9).</para></li><li><para>Can't be a word reserved by the specified database engine</para></li></ul><para><b>MariaDB</b></para><para>The name of the database to create when the DB instance is created. If this parameter
        /// isn't specified, no database is created in the DB instance.</para><para>Constraints:</para><ul><li><para>Must contain 1 to 64 letters or numbers.</para></li><li><para>Must begin with a letter. Subsequent characters can be letters, underscores, or digits
        /// (0-9).</para></li><li><para>Can't be a word reserved by the specified database engine</para></li></ul><para><b>PostgreSQL</b></para><para>The name of the database to create when the DB instance is created. If this parameter
        /// isn't specified, the default "postgres" database is created in the DB instance.</para><para>Constraints:</para><ul><li><para>Must contain 1 to 63 letters, numbers, or underscores.</para></li><li><para>Must begin with a letter. Subsequent characters can be letters, underscores, or digits
        /// (0-9).</para></li><li><para>Can't be a word reserved by the specified database engine</para></li></ul><para><b>Oracle</b></para><para>The Oracle System ID (SID) of the created DB instance. If you specify <code>null</code>,
        /// the default value <code>ORCL</code> is used. You can't specify the string NULL, or
        /// any other reserved word, for <code>DBName</code>. </para><para>Default: <code>ORCL</code></para><para>Constraints:</para><ul><li><para>Can't be longer than 8 characters</para></li></ul><para><b>SQL Server</b></para><para>Not applicable. Must be null.</para><para><b>Amazon Aurora</b></para><para>The name of the database to create when the primary instance of the DB cluster is
        /// created. If this parameter isn't specified, no database is created in the DB instance.</para><para>Constraints:</para><ul><li><para>Must contain 1 to 64 letters or numbers.</para></li><li><para>Can't be a word reserved by the specified database engine</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DBName { get; set; }
        #endregion
        
        #region Parameter DBParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the DB parameter group to associate with this DB instance. If you do not
        /// specify a value, then the default DB parameter group for the specified DB engine and
        /// version is used.</para><para>Constraints:</para><ul><li><para>Must be 1 to 255 letters, numbers, or hyphens.</para></li><li><para>First character must be a letter</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens</para></li></ul>
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
        /// <para>A DB subnet group to associate with this DB instance.</para><para>If there is no DB subnet group, then it is a non-VPC DB instance.</para>
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
        /// protection is disabled. For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_DeleteInstance.html">
        /// Deleting a DB Instance</a>. </para><para><b>Amazon Aurora</b></para><para>Not applicable. You can enable or disable deletion protection for the DB cluster.
        /// For more information, see <code>CreateDBCluster</code>. DB instances in a DB cluster
        /// can be deleted even when deletion protection is enabled for the DB cluster. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtection { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The Active Directory directory ID to create the DB instance in. Currently, only MySQL,
        /// Microsoft SQL Server, Oracle, and PostgreSQL DB instances can be created in an Active
        /// Directory Domain.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/kerberos-authentication.html">
        /// Kerberos Authentication</a> in the <i>Amazon RDS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter DomainIAMRoleName
        /// <summary>
        /// <para>
        /// <para>Specify the name of the IAM role to be used when making API calls to the Directory
        /// Service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainIAMRoleName { get; set; }
        #endregion
        
        #region Parameter EnableCloudwatchLogsExport
        /// <summary>
        /// <para>
        /// <para>The list of log types that need to be enabled for exporting to CloudWatch Logs. The
        /// values in the list depend on the DB engine being used. For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_LogAccess.html#USER_LogAccess.Procedural.UploadtoCloudWatch">Publishing
        /// Database Logs to Amazon CloudWatch Logs </a> in the <i>Amazon Relational Database
        /// Service User Guide</i>.</para><para><b>Amazon Aurora</b></para><para>Not applicable. CloudWatch Logs exports are managed by the DB cluster. </para><para><b>MariaDB</b></para><para>Possible values are <code>audit</code>, <code>error</code>, <code>general</code>,
        /// and <code>slowquery</code>. </para><para><b>Microsoft SQL Server</b></para><para>Possible values are <code>agent</code> and <code>error</code>. </para><para><b>MySQL</b></para><para>Possible values are <code>audit</code>, <code>error</code>, <code>general</code>,
        /// and <code>slowquery</code>. </para><para><b>Oracle</b></para><para>Possible values are <code>alert</code>, <code>audit</code>, <code>listener</code>,
        /// and <code>trace</code>. </para><para><b>PostgreSQL</b></para><para>Possible values are <code>postgresql</code> and <code>upgrade</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnableCloudwatchLogsExports")]
        public System.String[] EnableCloudwatchLogsExport { get; set; }
        #endregion
        
        #region Parameter EnableIAMDatabaseAuthentication
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to enable mapping of AWS Identity and Access Management
        /// (IAM) accounts to database accounts. By default, mapping is disabled.</para><para>You can enable IAM database authentication for the following database engines:</para><para><b>Amazon Aurora</b></para><para>Not applicable. Mapping AWS IAM accounts to database accounts is managed by the DB
        /// cluster.</para><para><b>MySQL</b></para><ul><li><para>For MySQL 5.6, minor version 5.6.34 or higher</para></li><li><para>For MySQL 5.7, minor version 5.7.16 or higher</para></li><li><para>For MySQL 8.0, minor version 8.0.16 or higher</para></li></ul><para><b>PostgreSQL</b></para><ul><li><para>For PostgreSQL 9.5, minor version 9.5.15 or higher</para></li><li><para>For PostgreSQL 9.6, minor version 9.6.11 or higher</para></li><li><para>PostgreSQL 10.6, 10.7, and 10.9</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/UsingWithRDS.IAMDBAuth.html">
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
        /// <para>A value that indicates whether to enable Performance Insights for the DB instance.
        /// </para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_PerfInsights.html">Using
        /// Amazon Performance Insights</a> in the <i>Amazon Relational Database Service User
        /// Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnablePerformanceInsights")]
        public System.Boolean? EnablePerformanceInsight { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The name of the database engine to be used for this instance. </para><para>Not every database engine is available for every AWS Region. </para><para>Valid Values: </para><ul><li><para><code>aurora</code> (for MySQL 5.6-compatible Aurora)</para></li><li><para><code>aurora-mysql</code> (for MySQL 5.7-compatible Aurora)</para></li><li><para><code>aurora-postgresql</code></para></li><li><para><code>mariadb</code></para></li><li><para><code>mysql</code></para></li><li><para><code>oracle-ee</code></para></li><li><para><code>oracle-se2</code></para></li><li><para><code>oracle-se1</code></para></li><li><para><code>oracle-se</code></para></li><li><para><code>postgres</code></para></li><li><para><code>sqlserver-ee</code></para></li><li><para><code>sqlserver-se</code></para></li><li><para><code>sqlserver-ex</code></para></li><li><para><code>sqlserver-web</code></para></li></ul>
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
        /// <para>The version number of the database engine to use.</para><para>For a list of valid engine versions, use the <code>DescribeDBEngineVersions</code>
        /// action.</para><para>The following are the database engines and links to information about the major and
        /// minor versions that are available with Amazon RDS. Not every database engine is available
        /// for every AWS Region.</para><para><b>Amazon Aurora</b></para><para>Not applicable. The version number of the database engine to be used by the DB instance
        /// is managed by the DB cluster.</para><para><b>MariaDB</b></para><para>See <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_MariaDB.html#MariaDB.Concepts.VersionMgmt">MariaDB
        /// on Amazon RDS Versions</a> in the <i>Amazon RDS User Guide.</i></para><para><b>Microsoft SQL Server</b></para><para>See <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_SQLServer.html#SQLServer.Concepts.General.VersionSupport">Microsoft
        /// SQL Server Versions on Amazon RDS</a> in the <i>Amazon RDS User Guide.</i></para><para><b>MySQL</b></para><para>See <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_MySQL.html#MySQL.Concepts.VersionMgmt">MySQL
        /// on Amazon RDS Versions</a> in the <i>Amazon RDS User Guide.</i></para><para><b>Oracle</b></para><para>See <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Appendix.Oracle.PatchComposition.html">Oracle
        /// Database Engine Release Notes</a> in the <i>Amazon RDS User Guide.</i></para><para><b>PostgreSQL</b></para><para>See <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_PostgreSQL.html#PostgreSQL.Concepts.General.DBVersions">Supported
        /// PostgreSQL Database Versions</a> in the <i>Amazon RDS User Guide.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter Iops
        /// <summary>
        /// <para>
        /// <para>The amount of Provisioned IOPS (input/output operations per second) to be initially
        /// allocated for the DB instance. For information about valid Iops values, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_Storage.html#USER_PIOPS">Amazon
        /// RDS Provisioned IOPS Storage to Improve Performance</a> in the <i>Amazon RDS User
        /// Guide</i>. </para><para>Constraints: For MariaDB, MySQL, Oracle, and PostgreSQL DB instances, must be a multiple
        /// between .5 and 50 of the storage amount for the DB instance. For SQL Server DB instances,
        /// must be a multiple between 1 and 50 of the storage amount for the DB instance. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Iops { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The AWS KMS key identifier for an encrypted DB instance.</para><para>The KMS key identifier is the Amazon Resource Name (ARN) for the KMS encryption key.
        /// If you are creating a DB instance with the same AWS account that owns the KMS encryption
        /// key used to encrypt the new DB instance, then you can use the KMS key alias instead
        /// of the ARN for the KM encryption key.</para><para><b>Amazon Aurora</b></para><para>Not applicable. The KMS key identifier is managed by the DB cluster. For more information,
        /// see <code>CreateDBCluster</code>.</para><para>If <code>StorageEncrypted</code> is enabled, and you do not specify a value for the
        /// <code>KmsKeyId</code> parameter, then Amazon RDS will use your default encryption
        /// key. AWS KMS creates the default encryption key for your AWS account. Your AWS account
        /// has a different default encryption key for each AWS Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter LicenseModel
        /// <summary>
        /// <para>
        /// <para>License model information for this DB instance.</para><para> Valid values: <code>license-included</code> | <code>bring-your-own-license</code>
        /// | <code>general-public-license</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LicenseModel { get; set; }
        #endregion
        
        #region Parameter MasterUsername
        /// <summary>
        /// <para>
        /// <para>The name for the master user.</para><para><b>Amazon Aurora</b></para><para>Not applicable. The name for the master user is managed by the DB cluster. </para><para><b>MariaDB</b></para><para>Constraints:</para><ul><li><para>Required for MariaDB.</para></li><li><para>Must be 1 to 16 letters or numbers.</para></li><li><para>Can't be a reserved word for the chosen database engine.</para></li></ul><para><b>Microsoft SQL Server</b></para><para>Constraints:</para><ul><li><para>Required for SQL Server.</para></li><li><para>Must be 1 to 128 letters or numbers.</para></li><li><para>The first character must be a letter.</para></li><li><para>Can't be a reserved word for the chosen database engine.</para></li></ul><para><b>MySQL</b></para><para>Constraints:</para><ul><li><para>Required for MySQL.</para></li><li><para>Must be 1 to 16 letters or numbers.</para></li><li><para>First character must be a letter.</para></li><li><para>Can't be a reserved word for the chosen database engine.</para></li></ul><para><b>Oracle</b></para><para>Constraints:</para><ul><li><para>Required for Oracle.</para></li><li><para>Must be 1 to 30 letters or numbers.</para></li><li><para>First character must be a letter.</para></li><li><para>Can't be a reserved word for the chosen database engine.</para></li></ul><para><b>PostgreSQL</b></para><para>Constraints:</para><ul><li><para>Required for PostgreSQL.</para></li><li><para>Must be 1 to 63 letters or numbers.</para></li><li><para>First character must be a letter.</para></li><li><para>Can't be a reserved word for the chosen database engine.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MasterUsername { get; set; }
        #endregion
        
        #region Parameter MasterUserPassword
        /// <summary>
        /// <para>
        /// <para>The password for the master user. The password can include any printable ASCII character
        /// except "/", """, or "@".</para><para><b>Amazon Aurora</b></para><para>Not applicable. The password for the master user is managed by the DB cluster.</para><para><b>MariaDB</b></para><para>Constraints: Must contain from 8 to 41 characters.</para><para><b>Microsoft SQL Server</b></para><para>Constraints: Must contain from 8 to 128 characters.</para><para><b>MySQL</b></para><para>Constraints: Must contain from 8 to 41 characters.</para><para><b>Oracle</b></para><para>Constraints: Must contain from 8 to 30 characters.</para><para><b>PostgreSQL</b></para><para>Constraints: Must contain from 8 to 128 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MasterUserPassword { get; set; }
        #endregion
        
        #region Parameter MaxAllocatedStorage
        /// <summary>
        /// <para>
        /// <para>The upper limit to which Amazon RDS can automatically scale the storage of the DB
        /// instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxAllocatedStorage { get; set; }
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
        /// <para>The ARN for the IAM role that permits RDS to send enhanced monitoring metrics to Amazon
        /// CloudWatch Logs. For example, <code>arn:aws:iam:123456789012:role/emaccess</code>.
        /// For information on creating a monitoring role, go to <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_Monitoring.OS.html#USER_Monitoring.OS.Enabling">Setting
        /// Up and Enabling Enhanced Monitoring</a> in the <i>Amazon RDS User Guide</i>.</para><para>If <code>MonitoringInterval</code> is set to a value other than 0, then you must supply
        /// a <code>MonitoringRoleArn</code> value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MonitoringRoleArn { get; set; }
        #endregion
        
        #region Parameter MultiAZ
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether the DB instance is a Multi-AZ deployment. You can't
        /// set the <code>AvailabilityZone</code> parameter if the DB instance is a Multi-AZ deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MultiAZ { get; set; }
        #endregion
        
        #region Parameter NcharCharacterSetName
        /// <summary>
        /// <para>
        /// <para>The name of the NCHAR character set for the Oracle DB instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NcharCharacterSetName { get; set; }
        #endregion
        
        #region Parameter OptionGroupName
        /// <summary>
        /// <para>
        /// <para>Indicates that the DB instance should be associated with the specified option group.</para><para>Permanent options, such as the TDE option for Oracle Advanced Security TDE, can't
        /// be removed from an option group. Also, that option group can't be removed from a DB
        /// instance once it is associated with a DB instance</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OptionGroupName { get; set; }
        #endregion
        
        #region Parameter PerformanceInsightsKMSKeyId
        /// <summary>
        /// <para>
        /// <para>The AWS KMS key identifier for encryption of Performance Insights data. The KMS key
        /// ID is the Amazon Resource Name (ARN), KMS key identifier, or the KMS key alias for
        /// the KMS encryption key.</para><para>If you do not specify a value for <code>PerformanceInsightsKMSKeyId</code>, then Amazon
        /// RDS uses your default encryption key. AWS KMS creates the default encryption key for
        /// your AWS account. Your AWS account has a different default encryption key for each
        /// AWS Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PerformanceInsightsKMSKeyId { get; set; }
        #endregion
        
        #region Parameter PerformanceInsightsRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The amount of time, in days, to retain Performance Insights data. Valid values are
        /// 7 or 731 (2 years). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PerformanceInsightsRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port number on which the database accepts connections.</para><para><b>MySQL</b></para><para> Default: <code>3306</code></para><para> Valid values: <code>1150-65535</code></para><para>Type: Integer</para><para><b>MariaDB</b></para><para> Default: <code>3306</code></para><para> Valid values: <code>1150-65535</code></para><para>Type: Integer</para><para><b>PostgreSQL</b></para><para> Default: <code>5432</code></para><para> Valid values: <code>1150-65535</code></para><para>Type: Integer</para><para><b>Oracle</b></para><para> Default: <code>1521</code></para><para> Valid values: <code>1150-65535</code></para><para><b>SQL Server</b></para><para> Default: <code>1433</code></para><para> Valid values: <code>1150-65535</code> except <code>1234</code>, <code>1434</code>,
        /// <code>3260</code>, <code>3343</code>, <code>3389</code>, <code>47001</code>, and <code>49152-49156</code>.</para><para><b>Amazon Aurora</b></para><para> Default: <code>3306</code></para><para> Valid values: <code>1150-65535</code></para><para>Type: Integer</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter PreferredBackupWindow
        /// <summary>
        /// <para>
        /// <para> The daily time range during which automated backups are created if automated backups
        /// are enabled, using the <code>BackupRetentionPeriod</code> parameter. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_WorkingWithAutomatedBackups.html#USER_WorkingWithAutomatedBackups.BackupWindow">The
        /// Backup Window</a> in the <i>Amazon RDS User Guide</i>. </para><para><b>Amazon Aurora</b></para><para>Not applicable. The daily time range for creating automated backups is managed by
        /// the DB cluster.</para><para> The default is a 30-minute window selected at random from an 8-hour block of time
        /// for each AWS Region. To see the time blocks available, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_UpgradeDBInstance.Maintenance.html#AdjustingTheMaintenanceWindow">
        /// Adjusting the Preferred DB Instance Maintenance Window</a> in the <i>Amazon RDS User
        /// Guide</i>. </para><para>Constraints:</para><ul><li><para>Must be in the format <code>hh24:mi-hh24:mi</code>.</para></li><li><para>Must be in Universal Coordinated Time (UTC).</para></li><li><para>Must not conflict with the preferred maintenance window.</para></li><li><para>Must be at least 30 minutes.</para></li></ul>
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
        /// RDS Maintenance Window</a>. </para><para> Format: <code>ddd:hh24:mi-ddd:hh24:mi</code></para><para>The default is a 30-minute window selected at random from an 8-hour block of time
        /// for each AWS Region, occurring on a random day of the week. </para><para>Valid Days: Mon, Tue, Wed, Thu, Fri, Sat, Sun.</para><para>Constraints: Minimum 30-minute window.</para>
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
        
        #region Parameter PromotionTier
        /// <summary>
        /// <para>
        /// <para>A value that specifies the order in which an Aurora Replica is promoted to the primary
        /// instance after a failure of the existing primary instance. For more information, see
        /// <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/Aurora.Managing.Backups.html#Aurora.Managing.FaultTolerance">
        /// Fault Tolerance for an Aurora DB Cluster</a> in the <i>Amazon Aurora User Guide</i>.
        /// </para><para>Default: 1</para><para>Valid Values: 0 - 15</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PromotionTier { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether the DB instance is publicly accessible.</para><para>When the DB instance is publicly accessible, its DNS endpoint resolves to the private
        /// IP address from within the DB instance's VPC, and to the public IP address from outside
        /// of the DB instance's VPC. Access to the DB instance is ultimately controlled by the
        /// security group it uses, and that public access is not permitted if the security group
        /// assigned to the DB instance doesn't permit it.</para><para>When the DB instance isn't publicly accessible, it is an internal DB instance with
        /// a DNS name that resolves to a private IP address.</para><para>Default: The default behavior varies depending on whether <code>DBSubnetGroupName</code>
        /// is specified.</para><para>If <code>DBSubnetGroupName</code> isn't specified, and <code>PubliclyAccessible</code>
        /// isn't specified, the following applies:</para><ul><li><para>If the default VPC in the target region doesn’t have an Internet gateway attached
        /// to it, the DB instance is private.</para></li><li><para>If the default VPC in the target region has an Internet gateway attached to it, the
        /// DB instance is public.</para></li></ul><para>If <code>DBSubnetGroupName</code> is specified, and <code>PubliclyAccessible</code>
        /// isn't specified, the following applies:</para><ul><li><para>If the subnets are part of a VPC that doesn’t have an Internet gateway attached to
        /// it, the DB instance is private.</para></li><li><para>If the subnets are part of a VPC that has an Internet gateway attached to it, the
        /// DB instance is public.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter StorageEncrypted
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether the DB instance is encrypted. By default, it isn't
        /// encrypted.</para><para><b>Amazon Aurora</b></para><para>Not applicable. The encryption for DB instances is managed by the DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? StorageEncrypted { get; set; }
        #endregion
        
        #region Parameter StorageType
        /// <summary>
        /// <para>
        /// <para>Specifies the storage type to be associated with the DB instance.</para><para> Valid values: <code>standard | gp2 | io1</code></para><para> If you specify <code>io1</code>, you must also include a value for the <code>Iops</code>
        /// parameter. </para><para> Default: <code>io1</code> if the <code>Iops</code> parameter is specified, otherwise
        /// <code>gp2</code></para>
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
        
        #region Parameter Timezone
        /// <summary>
        /// <para>
        /// <para>The time zone of the DB instance. The time zone parameter is currently supported only
        /// by <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_SQLServer.html#SQLServer.Concepts.General.TimeZone">Microsoft
        /// SQL Server</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Timezone { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of Amazon EC2 VPC security groups to associate with this DB instance.</para><para><b>Amazon Aurora</b></para><para>Not applicable. The associated list of EC2 VPC security groups is managed by the DB
        /// cluster.</para><para>Default: The default EC2 VPC security group for the DB subnet group's VPC.</para>
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
            context.CharacterSetName = this.CharacterSetName;
            context.CopyTagsToSnapshot = this.CopyTagsToSnapshot;
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
            context.DeletionProtection = this.DeletionProtection;
            context.Domain = this.Domain;
            context.DomainIAMRoleName = this.DomainIAMRoleName;
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
            context.MasterUsername = this.MasterUsername;
            context.MasterUserPassword = this.MasterUserPassword;
            context.MaxAllocatedStorage = this.MaxAllocatedStorage;
            context.MonitoringInterval = this.MonitoringInterval;
            context.MonitoringRoleArn = this.MonitoringRoleArn;
            context.MultiAZ = this.MultiAZ;
            context.NcharCharacterSetName = this.NcharCharacterSetName;
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
            if (cmdletContext.CharacterSetName != null)
            {
                request.CharacterSetName = cmdletContext.CharacterSetName;
            }
            if (cmdletContext.CopyTagsToSnapshot != null)
            {
                request.CopyTagsToSnapshot = cmdletContext.CopyTagsToSnapshot.Value;
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
            if (cmdletContext.DeletionProtection != null)
            {
                request.DeletionProtection = cmdletContext.DeletionProtection.Value;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            if (cmdletContext.DomainIAMRoleName != null)
            {
                request.DomainIAMRoleName = cmdletContext.DomainIAMRoleName;
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
            if (cmdletContext.MasterUsername != null)
            {
                request.MasterUsername = cmdletContext.MasterUsername;
            }
            if (cmdletContext.MasterUserPassword != null)
            {
                request.MasterUserPassword = cmdletContext.MasterUserPassword;
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
            if (cmdletContext.NcharCharacterSetName != null)
            {
                request.NcharCharacterSetName = cmdletContext.NcharCharacterSetName;
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
            public System.String CharacterSetName { get; set; }
            public System.Boolean? CopyTagsToSnapshot { get; set; }
            public System.String DBClusterIdentifier { get; set; }
            public System.String DBInstanceClass { get; set; }
            public System.String DBInstanceIdentifier { get; set; }
            public System.String DBName { get; set; }
            public System.String DBParameterGroupName { get; set; }
            public List<System.String> DBSecurityGroup { get; set; }
            public System.String DBSubnetGroupName { get; set; }
            public System.Boolean? DeletionProtection { get; set; }
            public System.String Domain { get; set; }
            public System.String DomainIAMRoleName { get; set; }
            public List<System.String> EnableCloudwatchLogsExport { get; set; }
            public System.Boolean? EnableIAMDatabaseAuthentication { get; set; }
            public System.Boolean? EnablePerformanceInsight { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineVersion { get; set; }
            public System.Int32? Iops { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String LicenseModel { get; set; }
            public System.String MasterUsername { get; set; }
            public System.String MasterUserPassword { get; set; }
            public System.Int32? MaxAllocatedStorage { get; set; }
            public System.Int32? MonitoringInterval { get; set; }
            public System.String MonitoringRoleArn { get; set; }
            public System.Boolean? MultiAZ { get; set; }
            public System.String NcharCharacterSetName { get; set; }
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
