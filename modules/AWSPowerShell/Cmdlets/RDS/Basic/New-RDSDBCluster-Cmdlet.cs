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
    /// Creates a new Amazon Aurora DB cluster or Multi-AZ DB cluster.
    /// 
    ///  
    /// <para>
    /// If you create an Aurora DB cluster, the request creates an empty cluster. You must
    /// explicitly create the writer instance for your DB cluster using the <a href="https://docs.aws.amazon.com/AmazonRDS/latest/APIReference/API_CreateDBInstance.html">CreateDBInstance</a>
    /// operation. If you create a Multi-AZ DB cluster, the request creates a writer and two
    /// reader DB instances for you, each in a different Availability Zone.
    /// </para><para>
    /// You can use the <code>ReplicationSourceIdentifier</code> parameter to create an Amazon
    /// Aurora DB cluster as a read replica of another DB cluster or Amazon RDS for MySQL
    /// or PostgreSQL DB instance. For more information about Amazon Aurora, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/CHAP_AuroraOverview.html">What
    /// is Amazon Aurora?</a> in the <i>Amazon Aurora User Guide</i>.
    /// </para><para>
    /// You can also use the <code>ReplicationSourceIdentifier</code> parameter to create
    /// a Multi-AZ DB cluster read replica with an RDS for MySQL or PostgreSQL DB instance
    /// as the source. For more information about Multi-AZ DB clusters, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/multi-az-db-clusters-concepts.html">Multi-AZ
    /// DB cluster deployments</a> in the <i>Amazon RDS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "RDSDBCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBCluster")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CreateDBCluster API operation.", Operation = new[] {"CreateDBCluster"}, SelectReturnType = typeof(Amazon.RDS.Model.CreateDBClusterResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBCluster or Amazon.RDS.Model.CreateDBClusterResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBCluster object.",
        "The service call response (type Amazon.RDS.Model.CreateDBClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewRDSDBClusterCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter AllocatedStorage
        /// <summary>
        /// <para>
        /// <para>The amount of storage in gibibytes (GiB) to allocate to each DB instance in the Multi-AZ
        /// DB cluster.</para><para>This setting is required to create a Multi-AZ DB cluster.</para><para>Valid for: Multi-AZ DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AllocatedStorage { get; set; }
        #endregion
        
        #region Parameter AutoMinorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether minor engine upgrades are applied automatically to
        /// the DB cluster during the maintenance window. By default, minor engine upgrades are
        /// applied automatically.</para><para>Valid for: Multi-AZ DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoMinorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter ScalingConfiguration_AutoPause
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to allow or disallow automatic pause for an Aurora
        /// DB cluster in <code>serverless</code> DB engine mode. A DB cluster can be paused only
        /// when it's idle (it has no connections).</para><note><para>If a DB cluster is paused for more than seven days, the DB cluster might be backed
        /// up with a snapshot. In this case, the DB cluster is restored when there is a request
        /// to connect to it.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ScalingConfiguration_AutoPause { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>A list of Availability Zones (AZs) where DB instances in the DB cluster can be created.</para><para>For information on Amazon Web Services Regions and Availability Zones, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/Concepts.RegionsAndAvailabilityZones.html">Choosing
        /// the Regions and Availability Zones</a> in the <i>Amazon Aurora User Guide</i>.</para><para>Valid for: Aurora DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AvailabilityZones")]
        public System.String[] AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter BacktrackWindow
        /// <summary>
        /// <para>
        /// <para>The target backtrack window, in seconds. To disable backtracking, set this value to
        /// 0.</para><para>Default: 0</para><para>Constraints:</para><ul><li><para>If specified, this value must be set to a number from 0 to 259,200 (72 hours).</para></li></ul><para>Valid for: Aurora MySQL DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? BacktrackWindow { get; set; }
        #endregion
        
        #region Parameter BackupRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days for which automated backups are retained.</para><para>Default: 1</para><para>Constraints:</para><ul><li><para>Must be a value from 1 to 35</para></li></ul><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BackupRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter CharacterSetName
        /// <summary>
        /// <para>
        /// <para>A value that indicates that the DB cluster should be associated with the specified
        /// CharacterSet.</para><para>Valid for: Aurora DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CharacterSetName { get; set; }
        #endregion
        
        #region Parameter CopyTagsToSnapshot
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to copy all tags from the DB cluster to snapshots of
        /// the DB cluster. The default is not to copy them.</para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CopyTagsToSnapshot { get; set; }
        #endregion
        
        #region Parameter DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name for your database of up to 64 alphanumeric characters. If you do not provide
        /// a name, Amazon RDS doesn't create a database in the DB cluster you are creating.</para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatabaseName { get; set; }
        #endregion
        
        #region Parameter DBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The DB cluster identifier. This parameter is stored as a lowercase string.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 letters, numbers, or hyphens.</para></li><li><para>First character must be a letter.</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens.</para></li></ul><para>Example: <code>my-cluster1</code></para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
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
        public System.String DBClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter DBClusterInstanceClass
        /// <summary>
        /// <para>
        /// <para>The compute and memory capacity of each DB instance in the Multi-AZ DB cluster, for
        /// example db.m6gd.xlarge. Not all DB instance classes are available in all Amazon Web
        /// Services Regions, or for all database engines.</para><para>For the full list of DB instance classes and availability for your engine, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Concepts.DBInstanceClass.html">DB
        /// instance class</a> in the <i>Amazon RDS User Guide</i>.</para><para>This setting is required to create a Multi-AZ DB cluster.</para><para>Valid for: Multi-AZ DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBClusterInstanceClass { get; set; }
        #endregion
        
        #region Parameter DBClusterParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the DB cluster parameter group to associate with this DB cluster. If you
        /// do not specify a value, then the default DB cluster parameter group for the specified
        /// DB engine and version is used.</para><para>Constraints:</para><ul><li><para>If supplied, must match the name of an existing DB cluster parameter group.</para></li></ul><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBClusterParameterGroupName { get; set; }
        #endregion
        
        #region Parameter DBSubnetGroupName
        /// <summary>
        /// <para>
        /// <para>A DB subnet group to associate with this DB cluster.</para><para>This setting is required to create a Multi-AZ DB cluster.</para><para>Constraints: Must match the name of an existing DBSubnetGroup. Must not be default.</para><para>Example: <code>mydbsubnetgroup</code></para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBSubnetGroupName { get; set; }
        #endregion
        
        #region Parameter DBSystemId
        /// <summary>
        /// <para>
        /// <para>Reserved for future use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBSystemId { get; set; }
        #endregion
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether the DB cluster has deletion protection enabled. The
        /// database can't be deleted when deletion protection is enabled. By default, deletion
        /// protection isn't enabled.</para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtection { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The Active Directory directory ID to create the DB cluster in.</para><para>For Amazon Aurora DB clusters, Amazon RDS can use Kerberos authentication to authenticate
        /// users that connect to the DB cluster.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/kerberos-authentication.html">Kerberos
        /// authentication</a> in the <i>Amazon Aurora User Guide</i>.</para><para>Valid for: Aurora DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter DomainIAMRoleName
        /// <summary>
        /// <para>
        /// <para>Specify the name of the IAM role to be used when making API calls to the Directory
        /// Service.</para><para>Valid for: Aurora DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainIAMRoleName { get; set; }
        #endregion
        
        #region Parameter EnableCloudwatchLogsExport
        /// <summary>
        /// <para>
        /// <para>The list of log types that need to be enabled for exporting to CloudWatch Logs. The
        /// values in the list depend on the DB engine being used.</para><para><b>RDS for MySQL</b></para><para>Possible values are <code>error</code>, <code>general</code>, and <code>slowquery</code>.</para><para><b>RDS for PostgreSQL</b></para><para>Possible values are <code>postgresql</code> and <code>upgrade</code>.</para><para><b>Aurora MySQL</b></para><para>Possible values are <code>audit</code>, <code>error</code>, <code>general</code>,
        /// and <code>slowquery</code>.</para><para><b>Aurora PostgreSQL</b></para><para>Possible value is <code>postgresql</code>.</para><para>For more information about exporting CloudWatch Logs for Amazon RDS, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_LogAccess.html#USER_LogAccess.Procedural.UploadtoCloudWatch">Publishing
        /// Database Logs to Amazon CloudWatch Logs</a> in the <i>Amazon RDS User Guide</i>.</para><para>For more information about exporting CloudWatch Logs for Amazon Aurora, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/USER_LogAccess.html#USER_LogAccess.Procedural.UploadtoCloudWatch">Publishing
        /// Database Logs to Amazon CloudWatch Logs</a> in the <i>Amazon Aurora User Guide</i>.</para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnableCloudwatchLogsExports")]
        public System.String[] EnableCloudwatchLogsExport { get; set; }
        #endregion
        
        #region Parameter EnableGlobalWriteForwarding
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to enable this DB cluster to forward write operations
        /// to the primary cluster of an Aurora global database (<a>GlobalCluster</a>). By default,
        /// write operations are not allowed on Aurora DB clusters that are secondary clusters
        /// in an Aurora global database.</para><para>You can set this value only on Aurora DB clusters that are members of an Aurora global
        /// database. With this parameter enabled, a secondary cluster can forward writes to the
        /// current primary cluster and the resulting changes are replicated back to this cluster.
        /// For the primary DB cluster of an Aurora global database, this value is used immediately
        /// if the primary is demoted by the <a>FailoverGlobalCluster</a> API operation, but it
        /// does nothing until then.</para><para>Valid for: Aurora DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableGlobalWriteForwarding { get; set; }
        #endregion
        
        #region Parameter EnableHttpEndpoint
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to enable the HTTP endpoint for an Aurora Serverless
        /// v1 DB cluster. By default, the HTTP endpoint is disabled.</para><para>When enabled, the HTTP endpoint provides a connectionless web service API for running
        /// SQL queries on the Aurora Serverless v1 DB cluster. You can also query your database
        /// from inside the RDS console with the query editor.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/data-api.html">Using
        /// the Data API for Aurora Serverless v1</a> in the <i>Amazon Aurora User Guide</i>.</para><para>Valid for: Aurora DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableHttpEndpoint { get; set; }
        #endregion
        
        #region Parameter EnableIAMDatabaseAuthentication
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to enable mapping of Amazon Web Services Identity and
        /// Access Management (IAM) accounts to database accounts. By default, mapping isn't enabled.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/UsingWithRDS.IAMDBAuth.html">
        /// IAM Database Authentication</a> in the <i>Amazon Aurora User Guide</i>.</para><para>Valid for: Aurora DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableIAMDatabaseAuthentication { get; set; }
        #endregion
        
        #region Parameter EnablePerformanceInsight
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to turn on Performance Insights for the DB cluster.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_PerfInsights.html">
        /// Using Amazon Performance Insights</a> in the <i>Amazon RDS User Guide</i>.</para><para>Valid for: Multi-AZ DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnablePerformanceInsights")]
        public System.Boolean? EnablePerformanceInsight { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The name of the database engine to be used for this DB cluster.</para><para>Valid Values:</para><ul><li><para><code>aurora-mysql</code></para></li><li><para><code>aurora-postgresql</code></para></li><li><para><code>mysql</code></para></li><li><para><code>postgres</code></para></li></ul><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
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
        
        #region Parameter EngineMode
        /// <summary>
        /// <para>
        /// <para>The DB engine mode of the DB cluster, either <code>provisioned</code> or <code>serverless</code>.</para><para>The <code>serverless</code> engine mode only applies for Aurora Serverless v1 DB clusters.</para><para>For information about limitations and requirements for Serverless DB clusters, see
        /// the following sections in the <i>Amazon Aurora User Guide</i>:</para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/aurora-serverless.html#aurora-serverless.limitations">Limitations
        /// of Aurora Serverless v1</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/aurora-serverless-v2.requirements.html">Requirements
        /// for Aurora Serverless v2</a></para></li></ul><para>Valid for: Aurora DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineMode { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The version number of the database engine to use.</para><para>To list all of the available engine versions for Aurora MySQL version 2 (5.7-compatible)
        /// and version 3 (MySQL 8.0-compatible), use the following command:</para><para><code>aws rds describe-db-engine-versions --engine aurora-mysql --query "DBEngineVersions[].EngineVersion"</code></para><para>You can supply either <code>5.7</code> or <code>8.0</code> to use the default engine
        /// version for Aurora MySQL version 2 or version 3, respectively.</para><para>To list all of the available engine versions for Aurora PostgreSQL, use the following
        /// command:</para><para><code>aws rds describe-db-engine-versions --engine aurora-postgresql --query "DBEngineVersions[].EngineVersion"</code></para><para>To list all of the available engine versions for RDS for MySQL, use the following
        /// command:</para><para><code>aws rds describe-db-engine-versions --engine mysql --query "DBEngineVersions[].EngineVersion"</code></para><para>To list all of the available engine versions for RDS for PostgreSQL, use the following
        /// command:</para><para><code>aws rds describe-db-engine-versions --engine postgres --query "DBEngineVersions[].EngineVersion"</code></para><para><b>Aurora MySQL</b></para><para>For information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/AuroraMySQL.Updates.html">Database
        /// engine updates for Amazon Aurora MySQL</a> in the <i>Amazon Aurora User Guide</i>.</para><para><b>Aurora PostgreSQL</b></para><para>For information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/AuroraPostgreSQL.Updates.20180305.html">Amazon
        /// Aurora PostgreSQL releases and engine versions</a> in the <i>Amazon Aurora User Guide</i>.</para><para><b>MySQL</b></para><para>For information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_MySQL.html#MySQL.Concepts.VersionMgmt">Amazon
        /// RDS for MySQL</a> in the <i>Amazon RDS User Guide</i>.</para><para><b>PostgreSQL</b></para><para>For information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_PostgreSQL.html#PostgreSQL.Concepts">Amazon
        /// RDS for PostgreSQL</a> in the <i>Amazon RDS User Guide</i>.</para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter GlobalClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The global cluster ID of an Aurora cluster that becomes the primary cluster in the
        /// new global database cluster.</para><para>Valid for: Aurora DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GlobalClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter Iops
        /// <summary>
        /// <para>
        /// <para>The amount of Provisioned IOPS (input/output operations per second) to be initially
        /// allocated for each DB instance in the Multi-AZ DB cluster.</para><para>For information about valid IOPS values, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_Storage.html#USER_PIOPS">Provisioned
        /// IOPS storage</a> in the <i>Amazon RDS User Guide</i>.</para><para>This setting is required to create a Multi-AZ DB cluster.</para><para>Constraints: Must be a multiple between .5 and 50 of the storage amount for the DB
        /// cluster.</para><para>Valid for: Multi-AZ DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Iops { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services KMS key identifier for an encrypted DB cluster.</para><para>The Amazon Web Services KMS key identifier is the key ARN, key ID, alias ARN, or alias
        /// name for the KMS key. To use a KMS key in a different Amazon Web Services account,
        /// specify the key ARN or alias ARN.</para><para>When a KMS key isn't specified in <code>KmsKeyId</code>:</para><ul><li><para>If <code>ReplicationSourceIdentifier</code> identifies an encrypted source, then Amazon
        /// RDS will use the KMS key used to encrypt the source. Otherwise, Amazon RDS will use
        /// your default KMS key.</para></li><li><para>If the <code>StorageEncrypted</code> parameter is enabled and <code>ReplicationSourceIdentifier</code>
        /// isn't specified, then Amazon RDS will use your default KMS key.</para></li></ul><para>There is a default KMS key for your Amazon Web Services account. Your Amazon Web Services
        /// account has a different default KMS key for each Amazon Web Services Region.</para><para>If you create a read replica of an encrypted DB cluster in another Amazon Web Services
        /// Region, you must set <code>KmsKeyId</code> to a KMS key identifier that is valid in
        /// the destination Amazon Web Services Region. This KMS key is used to encrypt the read
        /// replica in that Amazon Web Services Region.</para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter ManageMasterUserPassword
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to manage the master user password with Amazon Web
        /// Services Secrets Manager.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/rds-secrets-manager.html">Password
        /// management with Amazon Web Services Secrets Manager</a> in the <i>Amazon RDS User
        /// Guide</i> and <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/rds-secrets-manager.html">Password
        /// management with Amazon Web Services Secrets Manager</a> in the <i>Amazon Aurora User
        /// Guide.</i></para><para>Constraints:</para><ul><li><para>Can't manage the master user password with Amazon Web Services Secrets Manager if
        /// <code>MasterUserPassword</code> is specified.</para></li></ul><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ManageMasterUserPassword { get; set; }
        #endregion
        
        #region Parameter MasterUsername
        /// <summary>
        /// <para>
        /// <para>The name of the master user for the DB cluster.</para><para>Constraints:</para><ul><li><para>Must be 1 to 16 letters or numbers.</para></li><li><para>First character must be a letter.</para></li><li><para>Can't be a reserved word for the chosen database engine.</para></li></ul><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MasterUsername { get; set; }
        #endregion
        
        #region Parameter MasterUserPassword
        /// <summary>
        /// <para>
        /// <para>The password for the master database user. This password can contain any printable
        /// ASCII character except "/", """, or "@".</para><para>Constraints:</para><ul><li><para>Must contain from 8 to 41 characters.</para></li><li><para>Can't be specified if <code>ManageMasterUserPassword</code> is turned on.</para></li></ul><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
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
        /// Web Services Secrets Manager for the DB cluster.</para><para>The Amazon Web Services KMS key identifier is the key ARN, key ID, alias ARN, or alias
        /// name for the KMS key. To use a KMS key in a different Amazon Web Services account,
        /// specify the key ARN or alias ARN.</para><para>If you don't specify <code>MasterUserSecretKmsKeyId</code>, then the <code>aws/secretsmanager</code>
        /// KMS key is used to encrypt the secret. If the secret is in a different Amazon Web
        /// Services account, then you can't use the <code>aws/secretsmanager</code> KMS key to
        /// encrypt the secret, and you must use a customer managed KMS key.</para><para>There is a default KMS key for your Amazon Web Services account. Your Amazon Web Services
        /// account has a different default KMS key for each Amazon Web Services Region.</para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MasterUserSecretKmsKeyId { get; set; }
        #endregion
        
        #region Parameter ScalingConfiguration_MaxCapacity
        /// <summary>
        /// <para>
        /// <para>The maximum capacity for an Aurora DB cluster in <code>serverless</code> DB engine
        /// mode.</para><para>For Aurora MySQL, valid capacity values are <code>1</code>, <code>2</code>, <code>4</code>,
        /// <code>8</code>, <code>16</code>, <code>32</code>, <code>64</code>, <code>128</code>,
        /// and <code>256</code>.</para><para>For Aurora PostgreSQL, valid capacity values are <code>2</code>, <code>4</code>, <code>8</code>,
        /// <code>16</code>, <code>32</code>, <code>64</code>, <code>192</code>, and <code>384</code>.</para><para>The maximum capacity must be greater than or equal to the minimum capacity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingConfiguration_MaxCapacity { get; set; }
        #endregion
        
        #region Parameter ServerlessV2ScalingConfiguration_MaxCapacity
        /// <summary>
        /// <para>
        /// <para>The maximum number of Aurora capacity units (ACUs) for a DB instance in an Aurora
        /// Serverless v2 cluster. You can specify ACU values in half-step increments, such as
        /// 40, 40.5, 41, and so on. The largest value that you can use is 128.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? ServerlessV2ScalingConfiguration_MaxCapacity { get; set; }
        #endregion
        
        #region Parameter ScalingConfiguration_MinCapacity
        /// <summary>
        /// <para>
        /// <para>The minimum capacity for an Aurora DB cluster in <code>serverless</code> DB engine
        /// mode.</para><para>For Aurora MySQL, valid capacity values are <code>1</code>, <code>2</code>, <code>4</code>,
        /// <code>8</code>, <code>16</code>, <code>32</code>, <code>64</code>, <code>128</code>,
        /// and <code>256</code>.</para><para>For Aurora PostgreSQL, valid capacity values are <code>2</code>, <code>4</code>, <code>8</code>,
        /// <code>16</code>, <code>32</code>, <code>64</code>, <code>192</code>, and <code>384</code>.</para><para>The minimum capacity must be less than or equal to the maximum capacity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingConfiguration_MinCapacity { get; set; }
        #endregion
        
        #region Parameter ServerlessV2ScalingConfiguration_MinCapacity
        /// <summary>
        /// <para>
        /// <para>The minimum number of Aurora capacity units (ACUs) for a DB instance in an Aurora
        /// Serverless v2 cluster. You can specify ACU values in half-step increments, such as
        /// 8, 8.5, 9, and so on. The smallest value that you can use is 0.5.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? ServerlessV2ScalingConfiguration_MinCapacity { get; set; }
        #endregion
        
        #region Parameter MonitoringInterval
        /// <summary>
        /// <para>
        /// <para>The interval, in seconds, between points when Enhanced Monitoring metrics are collected
        /// for the DB cluster. To turn off collecting Enhanced Monitoring metrics, specify 0.
        /// The default is 0.</para><para>If <code>MonitoringRoleArn</code> is specified, also set <code>MonitoringInterval</code>
        /// to a value other than 0.</para><para>Valid Values: <code>0, 1, 5, 10, 15, 30, 60</code></para><para>Valid for: Multi-AZ DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MonitoringInterval { get; set; }
        #endregion
        
        #region Parameter MonitoringRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the IAM role that permits RDS to send Enhanced
        /// Monitoring metrics to Amazon CloudWatch Logs. An example is <code>arn:aws:iam:123456789012:role/emaccess</code>.
        /// For information on creating a monitoring role, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_Monitoring.OS.html#USER_Monitoring.OS.Enabling">Setting
        /// up and enabling Enhanced Monitoring</a> in the <i>Amazon RDS User Guide</i>.</para><para>If <code>MonitoringInterval</code> is set to a value other than 0, supply a <code>MonitoringRoleArn</code>
        /// value.</para><para>Valid for: Multi-AZ DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MonitoringRoleArn { get; set; }
        #endregion
        
        #region Parameter NetworkType
        /// <summary>
        /// <para>
        /// <para>The network type of the DB cluster.</para><para>Valid values:</para><ul><li><para><code>IPV4</code></para></li><li><para><code>DUAL</code></para></li></ul><para>The network type is determined by the <code>DBSubnetGroup</code> specified for the
        /// DB cluster. A <code>DBSubnetGroup</code> can support only the IPv4 protocol or the
        /// IPv4 and the IPv6 protocols (<code>DUAL</code>).</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/USER_VPC.WorkingWithRDSInstanceinaVPC.html">
        /// Working with a DB instance in a VPC</a> in the <i>Amazon Aurora User Guide.</i></para><para>Valid for: Aurora DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkType { get; set; }
        #endregion
        
        #region Parameter OptionGroupName
        /// <summary>
        /// <para>
        /// <para>A value that indicates that the DB cluster should be associated with the specified
        /// option group.</para><para>DB clusters are associated with a default option group that can't be modified.</para>
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
        /// name for the KMS key.</para><para>If you don't specify a value for <code>PerformanceInsightsKMSKeyId</code>, then Amazon
        /// RDS uses your default KMS key. There is a default KMS key for your Amazon Web Services
        /// account. Your Amazon Web Services account has a different default KMS key for each
        /// Amazon Web Services Region.</para><para>Valid for: Multi-AZ DB clusters only</para>
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
        /// an error.</para><para>Valid for: Multi-AZ DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PerformanceInsightsRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port number on which the instances in the DB cluster accept connections.</para><para><b>RDS for MySQL and Aurora MySQL</b></para><para>Default: <code>3306</code></para><para>Valid values: <code>1150-65535</code></para><para><b>RDS for PostgreSQL and Aurora PostgreSQL</b></para><para>Default: <code>5432</code></para><para>Valid values: <code>1150-65535</code></para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter PreferredBackupWindow
        /// <summary>
        /// <para>
        /// <para>The daily time range during which automated backups are created if automated backups
        /// are enabled using the <code>BackupRetentionPeriod</code> parameter.</para><para>The default is a 30-minute window selected at random from an 8-hour block of time
        /// for each Amazon Web Services Region. To view the time blocks available, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/Aurora.Managing.Backups.html#Aurora.Managing.Backups.BackupWindow">
        /// Backup window</a> in the <i>Amazon Aurora User Guide</i>.</para><para>Constraints:</para><ul><li><para>Must be in the format <code>hh24:mi-hh24:mi</code>.</para></li><li><para>Must be in Universal Coordinated Time (UTC).</para></li><li><para>Must not conflict with the preferred maintenance window.</para></li><li><para>Must be at least 30 minutes.</para></li></ul><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredBackupWindow { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>The weekly time range during which system maintenance can occur, in Universal Coordinated
        /// Time (UTC).</para><para>Format: <code>ddd:hh24:mi-ddd:hh24:mi</code></para><para>The default is a 30-minute window selected at random from an 8-hour block of time
        /// for each Amazon Web Services Region, occurring on a random day of the week. To see
        /// the time blocks available, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/USER_UpgradeDBInstance.Maintenance.html#AdjustingTheMaintenanceWindow.Aurora">
        /// Adjusting the Preferred DB Cluster Maintenance Window</a> in the <i>Amazon Aurora
        /// User Guide</i>.</para><para>Valid Days: Mon, Tue, Wed, Thu, Fri, Sat, Sun.</para><para>Constraints: Minimum 30-minute window.</para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter PreSignedUrl
        /// <summary>
        /// <para>
        /// <para>When you are replicating a DB cluster from one Amazon Web Services GovCloud (US) Region
        /// to another, an URL that contains a Signature Version 4 signed request for the <code>CreateDBCluster</code>
        /// operation to be called in the source Amazon Web Services Region where the DB cluster
        /// is replicated from. Specify <code>PreSignedUrl</code> only when you are performing
        /// cross-Region replication from an encrypted DB cluster.</para><para>The presigned URL must be a valid request for the <code>CreateDBCluster</code> API
        /// operation that can run in the source Amazon Web Services Region that contains the
        /// encrypted DB cluster to copy.</para><para>The presigned URL request must contain the following parameter values:</para><ul><li><para><code>KmsKeyId</code> - The KMS key identifier for the KMS key to use to encrypt
        /// the copy of the DB cluster in the destination Amazon Web Services Region. This should
        /// refer to the same KMS key for both the <code>CreateDBCluster</code> operation that
        /// is called in the destination Amazon Web Services Region, and the operation contained
        /// in the presigned URL.</para></li><li><para><code>DestinationRegion</code> - The name of the Amazon Web Services Region that
        /// Aurora read replica will be created in.</para></li><li><para><code>ReplicationSourceIdentifier</code> - The DB cluster identifier for the encrypted
        /// DB cluster to be copied. This identifier must be in the Amazon Resource Name (ARN)
        /// format for the source Amazon Web Services Region. For example, if you are copying
        /// an encrypted DB cluster from the us-west-2 Amazon Web Services Region, then your <code>ReplicationSourceIdentifier</code>
        /// would look like Example: <code>arn:aws:rds:us-west-2:123456789012:cluster:aurora-cluster1</code>.</para></li></ul><para>To learn how to generate a Signature Version 4 signed request, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/sigv4-query-string-auth.html">
        /// Authenticating Requests: Using Query Parameters (Amazon Web Services Signature Version
        /// 4)</a> and <a href="https://docs.aws.amazon.com/general/latest/gr/signature-version-4.html">
        /// Signature Version 4 Signing Process</a>.</para><note><para>If you are using an Amazon Web Services SDK tool or the CLI, you can specify <code>SourceRegion</code>
        /// (or <code>--source-region</code> for the CLI) instead of specifying <code>PreSignedUrl</code>
        /// manually. Specifying <code>SourceRegion</code> autogenerates a presigned URL that
        /// is a valid request for the operation that can run in the source Amazon Web Services
        /// Region.</para></note><para>Valid for: Aurora DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreSignedUrl { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether the DB cluster is publicly accessible.</para><para>When the DB cluster is publicly accessible, its Domain Name System (DNS) endpoint
        /// resolves to the private IP address from within the DB cluster's virtual private cloud
        /// (VPC). It resolves to the public IP address from outside of the DB cluster's VPC.
        /// Access to the DB cluster is ultimately controlled by the security group it uses. That
        /// public access isn't permitted if the security group assigned to the DB cluster doesn't
        /// permit it.</para><para>When the DB cluster isn't publicly accessible, it is an internal DB cluster with a
        /// DNS name that resolves to a private IP address.</para><para>Default: The default behavior varies depending on whether <code>DBSubnetGroupName</code>
        /// is specified.</para><para>If <code>DBSubnetGroupName</code> isn't specified, and <code>PubliclyAccessible</code>
        /// isn't specified, the following applies:</para><ul><li><para>If the default VPC in the target Region doesn’t have an internet gateway attached
        /// to it, the DB cluster is private.</para></li><li><para>If the default VPC in the target Region has an internet gateway attached to it, the
        /// DB cluster is public.</para></li></ul><para>If <code>DBSubnetGroupName</code> is specified, and <code>PubliclyAccessible</code>
        /// isn't specified, the following applies:</para><ul><li><para>If the subnets are part of a VPC that doesn’t have an internet gateway attached to
        /// it, the DB cluster is private.</para></li><li><para>If the subnets are part of a VPC that has an internet gateway attached to it, the
        /// DB cluster is public.</para></li></ul><para>Valid for: Multi-AZ DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter ReplicationSourceIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the source DB instance or DB cluster if this DB
        /// cluster is created as a read replica.</para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReplicationSourceIdentifier { get; set; }
        #endregion
        
        #region Parameter ScalingConfiguration_SecondsBeforeTimeout
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, that Aurora Serverless v1 tries to find a scaling
        /// point to perform seamless scaling before enforcing the timeout action. The default
        /// is 300.</para><para>Specify a value between 60 and 600 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingConfiguration_SecondsBeforeTimeout { get; set; }
        #endregion
        
        #region Parameter ScalingConfiguration_SecondsUntilAutoPause
        /// <summary>
        /// <para>
        /// <para>The time, in seconds, before an Aurora DB cluster in <code>serverless</code> mode
        /// is paused.</para><para>Specify a value between 300 and 86,400 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingConfiguration_SecondsUntilAutoPause { get; set; }
        #endregion
        
        #region Parameter SourceRegion
        /// <summary>
        /// <para>
        ///  The SourceRegion for generating the PreSignedUrl property.
        /// 
        ///  If SourceRegion is set and the PreSignedUrl property is not,
        ///  then PreSignedUrl will be automatically generated by the client.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceRegion { get; set; }
        #endregion
        
        #region Parameter StorageEncrypted
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether the DB cluster is encrypted.</para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? StorageEncrypted { get; set; }
        #endregion
        
        #region Parameter StorageType
        /// <summary>
        /// <para>
        /// <para>Specifies the storage type to be associated with the DB cluster.</para><para>This setting is required to create a Multi-AZ DB cluster.</para><para>When specified for a Multi-AZ DB cluster, a value for the <code>Iops</code> parameter
        /// is required.</para><para>Valid values: <code>aurora</code>, <code>aurora-iopt1</code> (Aurora DB clusters);
        /// <code>io1</code> (Multi-AZ DB clusters)</para><para>Default: <code>aurora</code> (Aurora DB clusters); <code>io1</code> (Multi-AZ DB clusters)</para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para><para>For more information on storage types for Aurora DB clusters, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/Aurora.Overview.StorageReliability.html#aurora-storage-type">Storage
        /// configurations for Amazon Aurora DB clusters</a>. For more information on storage
        /// types for Multi-AZ DB clusters, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/create-multi-az-db-cluster.html#create-multi-az-db-cluster-settings">Settings
        /// for creating Multi-AZ DB clusters</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to assign to the DB cluster.</para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ScalingConfiguration_TimeoutAction
        /// <summary>
        /// <para>
        /// <para>The action to take when the timeout is reached, either <code>ForceApplyCapacityChange</code>
        /// or <code>RollbackCapacityChange</code>.</para><para><code>ForceApplyCapacityChange</code> sets the capacity to the specified value as
        /// soon as possible.</para><para><code>RollbackCapacityChange</code>, the default, ignores the capacity change if
        /// a scaling point isn't found in the timeout period.</para><important><para>If you specify <code>ForceApplyCapacityChange</code>, connections that prevent Aurora
        /// Serverless v1 from finding a scaling point might be dropped.</para></important><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/aurora-serverless.how-it-works.html#aurora-serverless.how-it-works.auto-scaling">
        /// Autoscaling for Aurora Serverless v1</a> in the <i>Amazon Aurora User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScalingConfiguration_TimeoutAction { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of EC2 VPC security groups to associate with this DB cluster.</para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBCluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.CreateDBClusterResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.CreateDBClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBCluster";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DBClusterIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DBClusterIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DBClusterIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBClusterIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RDSDBCluster (CreateDBCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.CreateDBClusterResponse, NewRDSDBClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DBClusterIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SourceRegion = this.SourceRegion;
            context.AllocatedStorage = this.AllocatedStorage;
            context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            if (this.AvailabilityZone != null)
            {
                context.AvailabilityZone = new List<System.String>(this.AvailabilityZone);
            }
            context.BacktrackWindow = this.BacktrackWindow;
            context.BackupRetentionPeriod = this.BackupRetentionPeriod;
            context.CharacterSetName = this.CharacterSetName;
            context.CopyTagsToSnapshot = this.CopyTagsToSnapshot;
            context.DatabaseName = this.DatabaseName;
            context.DBClusterIdentifier = this.DBClusterIdentifier;
            #if MODULAR
            if (this.DBClusterIdentifier == null && ParameterWasBound(nameof(this.DBClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DBClusterInstanceClass = this.DBClusterInstanceClass;
            context.DBClusterParameterGroupName = this.DBClusterParameterGroupName;
            context.DBSubnetGroupName = this.DBSubnetGroupName;
            context.DBSystemId = this.DBSystemId;
            context.DeletionProtection = this.DeletionProtection;
            context.Domain = this.Domain;
            context.DomainIAMRoleName = this.DomainIAMRoleName;
            if (this.EnableCloudwatchLogsExport != null)
            {
                context.EnableCloudwatchLogsExport = new List<System.String>(this.EnableCloudwatchLogsExport);
            }
            context.EnableGlobalWriteForwarding = this.EnableGlobalWriteForwarding;
            context.EnableHttpEndpoint = this.EnableHttpEndpoint;
            context.EnableIAMDatabaseAuthentication = this.EnableIAMDatabaseAuthentication;
            context.EnablePerformanceInsight = this.EnablePerformanceInsight;
            context.Engine = this.Engine;
            #if MODULAR
            if (this.Engine == null && ParameterWasBound(nameof(this.Engine)))
            {
                WriteWarning("You are passing $null as a value for parameter Engine which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EngineMode = this.EngineMode;
            context.EngineVersion = this.EngineVersion;
            context.GlobalClusterIdentifier = this.GlobalClusterIdentifier;
            context.Iops = this.Iops;
            context.KmsKeyId = this.KmsKeyId;
            context.ManageMasterUserPassword = this.ManageMasterUserPassword;
            context.MasterUsername = this.MasterUsername;
            context.MasterUserPassword = this.MasterUserPassword;
            context.MasterUserSecretKmsKeyId = this.MasterUserSecretKmsKeyId;
            context.MonitoringInterval = this.MonitoringInterval;
            context.MonitoringRoleArn = this.MonitoringRoleArn;
            context.NetworkType = this.NetworkType;
            context.OptionGroupName = this.OptionGroupName;
            context.PerformanceInsightsKMSKeyId = this.PerformanceInsightsKMSKeyId;
            context.PerformanceInsightsRetentionPeriod = this.PerformanceInsightsRetentionPeriod;
            context.Port = this.Port;
            context.PreferredBackupWindow = this.PreferredBackupWindow;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            context.PreSignedUrl = this.PreSignedUrl;
            context.PubliclyAccessible = this.PubliclyAccessible;
            context.ReplicationSourceIdentifier = this.ReplicationSourceIdentifier;
            context.ScalingConfiguration_AutoPause = this.ScalingConfiguration_AutoPause;
            context.ScalingConfiguration_MaxCapacity = this.ScalingConfiguration_MaxCapacity;
            context.ScalingConfiguration_MinCapacity = this.ScalingConfiguration_MinCapacity;
            context.ScalingConfiguration_SecondsBeforeTimeout = this.ScalingConfiguration_SecondsBeforeTimeout;
            context.ScalingConfiguration_SecondsUntilAutoPause = this.ScalingConfiguration_SecondsUntilAutoPause;
            context.ScalingConfiguration_TimeoutAction = this.ScalingConfiguration_TimeoutAction;
            context.ServerlessV2ScalingConfiguration_MaxCapacity = this.ServerlessV2ScalingConfiguration_MaxCapacity;
            context.ServerlessV2ScalingConfiguration_MinCapacity = this.ServerlessV2ScalingConfiguration_MinCapacity;
            context.StorageEncrypted = this.StorageEncrypted;
            context.StorageType = this.StorageType;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
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
            var request = new Amazon.RDS.Model.CreateDBClusterRequest();
            
            if (cmdletContext.SourceRegion != null)
            {
                request.SourceRegion = cmdletContext.SourceRegion;
            }
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
                request.AvailabilityZones = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.BacktrackWindow != null)
            {
                request.BacktrackWindow = cmdletContext.BacktrackWindow.Value;
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
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            if (cmdletContext.DBClusterIdentifier != null)
            {
                request.DBClusterIdentifier = cmdletContext.DBClusterIdentifier;
            }
            if (cmdletContext.DBClusterInstanceClass != null)
            {
                request.DBClusterInstanceClass = cmdletContext.DBClusterInstanceClass;
            }
            if (cmdletContext.DBClusterParameterGroupName != null)
            {
                request.DBClusterParameterGroupName = cmdletContext.DBClusterParameterGroupName;
            }
            if (cmdletContext.DBSubnetGroupName != null)
            {
                request.DBSubnetGroupName = cmdletContext.DBSubnetGroupName;
            }
            if (cmdletContext.DBSystemId != null)
            {
                request.DBSystemId = cmdletContext.DBSystemId;
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
            if (cmdletContext.EnableGlobalWriteForwarding != null)
            {
                request.EnableGlobalWriteForwarding = cmdletContext.EnableGlobalWriteForwarding.Value;
            }
            if (cmdletContext.EnableHttpEndpoint != null)
            {
                request.EnableHttpEndpoint = cmdletContext.EnableHttpEndpoint.Value;
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
            if (cmdletContext.EngineMode != null)
            {
                request.EngineMode = cmdletContext.EngineMode;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.GlobalClusterIdentifier != null)
            {
                request.GlobalClusterIdentifier = cmdletContext.GlobalClusterIdentifier;
            }
            if (cmdletContext.Iops != null)
            {
                request.Iops = cmdletContext.Iops.Value;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
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
            if (cmdletContext.MonitoringInterval != null)
            {
                request.MonitoringInterval = cmdletContext.MonitoringInterval.Value;
            }
            if (cmdletContext.MonitoringRoleArn != null)
            {
                request.MonitoringRoleArn = cmdletContext.MonitoringRoleArn;
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
            if (cmdletContext.PreSignedUrl != null)
            {
                request.PreSignedUrl = cmdletContext.PreSignedUrl;
            }
            if (cmdletContext.PubliclyAccessible != null)
            {
                request.PubliclyAccessible = cmdletContext.PubliclyAccessible.Value;
            }
            if (cmdletContext.ReplicationSourceIdentifier != null)
            {
                request.ReplicationSourceIdentifier = cmdletContext.ReplicationSourceIdentifier;
            }
            
             // populate ScalingConfiguration
            var requestScalingConfigurationIsNull = true;
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
            System.Int32? requestScalingConfiguration_scalingConfiguration_SecondsBeforeTimeout = null;
            if (cmdletContext.ScalingConfiguration_SecondsBeforeTimeout != null)
            {
                requestScalingConfiguration_scalingConfiguration_SecondsBeforeTimeout = cmdletContext.ScalingConfiguration_SecondsBeforeTimeout.Value;
            }
            if (requestScalingConfiguration_scalingConfiguration_SecondsBeforeTimeout != null)
            {
                request.ScalingConfiguration.SecondsBeforeTimeout = requestScalingConfiguration_scalingConfiguration_SecondsBeforeTimeout.Value;
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
            
             // populate ServerlessV2ScalingConfiguration
            var requestServerlessV2ScalingConfigurationIsNull = true;
            request.ServerlessV2ScalingConfiguration = new Amazon.RDS.Model.ServerlessV2ScalingConfiguration();
            System.Double? requestServerlessV2ScalingConfiguration_serverlessV2ScalingConfiguration_MaxCapacity = null;
            if (cmdletContext.ServerlessV2ScalingConfiguration_MaxCapacity != null)
            {
                requestServerlessV2ScalingConfiguration_serverlessV2ScalingConfiguration_MaxCapacity = cmdletContext.ServerlessV2ScalingConfiguration_MaxCapacity.Value;
            }
            if (requestServerlessV2ScalingConfiguration_serverlessV2ScalingConfiguration_MaxCapacity != null)
            {
                request.ServerlessV2ScalingConfiguration.MaxCapacity = requestServerlessV2ScalingConfiguration_serverlessV2ScalingConfiguration_MaxCapacity.Value;
                requestServerlessV2ScalingConfigurationIsNull = false;
            }
            System.Double? requestServerlessV2ScalingConfiguration_serverlessV2ScalingConfiguration_MinCapacity = null;
            if (cmdletContext.ServerlessV2ScalingConfiguration_MinCapacity != null)
            {
                requestServerlessV2ScalingConfiguration_serverlessV2ScalingConfiguration_MinCapacity = cmdletContext.ServerlessV2ScalingConfiguration_MinCapacity.Value;
            }
            if (requestServerlessV2ScalingConfiguration_serverlessV2ScalingConfiguration_MinCapacity != null)
            {
                request.ServerlessV2ScalingConfiguration.MinCapacity = requestServerlessV2ScalingConfiguration_serverlessV2ScalingConfiguration_MinCapacity.Value;
                requestServerlessV2ScalingConfigurationIsNull = false;
            }
             // determine if request.ServerlessV2ScalingConfiguration should be set to null
            if (requestServerlessV2ScalingConfigurationIsNull)
            {
                request.ServerlessV2ScalingConfiguration = null;
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
        
        private Amazon.RDS.Model.CreateDBClusterResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.CreateDBClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "CreateDBCluster");
            try
            {
                #if DESKTOP
                return client.CreateDBCluster(request);
                #elif CORECLR
                return client.CreateDBClusterAsync(request).GetAwaiter().GetResult();
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
            public System.String SourceRegion { get; set; }
            public System.Int32? AllocatedStorage { get; set; }
            public System.Boolean? AutoMinorVersionUpgrade { get; set; }
            public List<System.String> AvailabilityZone { get; set; }
            public System.Int64? BacktrackWindow { get; set; }
            public System.Int32? BackupRetentionPeriod { get; set; }
            public System.String CharacterSetName { get; set; }
            public System.Boolean? CopyTagsToSnapshot { get; set; }
            public System.String DatabaseName { get; set; }
            public System.String DBClusterIdentifier { get; set; }
            public System.String DBClusterInstanceClass { get; set; }
            public System.String DBClusterParameterGroupName { get; set; }
            public System.String DBSubnetGroupName { get; set; }
            public System.String DBSystemId { get; set; }
            public System.Boolean? DeletionProtection { get; set; }
            public System.String Domain { get; set; }
            public System.String DomainIAMRoleName { get; set; }
            public List<System.String> EnableCloudwatchLogsExport { get; set; }
            public System.Boolean? EnableGlobalWriteForwarding { get; set; }
            public System.Boolean? EnableHttpEndpoint { get; set; }
            public System.Boolean? EnableIAMDatabaseAuthentication { get; set; }
            public System.Boolean? EnablePerformanceInsight { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineMode { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String GlobalClusterIdentifier { get; set; }
            public System.Int32? Iops { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.Boolean? ManageMasterUserPassword { get; set; }
            public System.String MasterUsername { get; set; }
            public System.String MasterUserPassword { get; set; }
            public System.String MasterUserSecretKmsKeyId { get; set; }
            public System.Int32? MonitoringInterval { get; set; }
            public System.String MonitoringRoleArn { get; set; }
            public System.String NetworkType { get; set; }
            public System.String OptionGroupName { get; set; }
            public System.String PerformanceInsightsKMSKeyId { get; set; }
            public System.Int32? PerformanceInsightsRetentionPeriod { get; set; }
            public System.Int32? Port { get; set; }
            public System.String PreferredBackupWindow { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.String PreSignedUrl { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public System.String ReplicationSourceIdentifier { get; set; }
            public System.Boolean? ScalingConfiguration_AutoPause { get; set; }
            public System.Int32? ScalingConfiguration_MaxCapacity { get; set; }
            public System.Int32? ScalingConfiguration_MinCapacity { get; set; }
            public System.Int32? ScalingConfiguration_SecondsBeforeTimeout { get; set; }
            public System.Int32? ScalingConfiguration_SecondsUntilAutoPause { get; set; }
            public System.String ScalingConfiguration_TimeoutAction { get; set; }
            public System.Double? ServerlessV2ScalingConfiguration_MaxCapacity { get; set; }
            public System.Double? ServerlessV2ScalingConfiguration_MinCapacity { get; set; }
            public System.Boolean? StorageEncrypted { get; set; }
            public System.String StorageType { get; set; }
            public List<Amazon.RDS.Model.Tag> Tag { get; set; }
            public List<System.String> VpcSecurityGroupId { get; set; }
            public System.Func<Amazon.RDS.Model.CreateDBClusterResponse, NewRDSDBClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBCluster;
        }
        
    }
}
