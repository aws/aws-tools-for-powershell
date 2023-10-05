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
    /// Modifies the settings of an Amazon Aurora DB cluster or a Multi-AZ DB cluster. You
    /// can change one or more settings by specifying these parameters and the new values
    /// in the request.
    /// 
    ///  
    /// <para>
    /// For more information on Amazon Aurora DB clusters, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/CHAP_AuroraOverview.html">
    /// What is Amazon Aurora?</a> in the <i>Amazon Aurora User Guide</i>.
    /// </para><para>
    /// For more information on Multi-AZ DB clusters, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/multi-az-db-clusters-concepts.html">
    /// Multi-AZ DB cluster deployments</a> in the <i>Amazon RDS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "RDSDBCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBCluster")]
    [AWSCmdlet("Calls the Amazon Relational Database Service ModifyDBCluster API operation.", Operation = new[] {"ModifyDBCluster"}, SelectReturnType = typeof(Amazon.RDS.Model.ModifyDBClusterResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBCluster or Amazon.RDS.Model.ModifyDBClusterResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBCluster object.",
        "The service call response (type Amazon.RDS.Model.ModifyDBClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditRDSDBClusterCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllocatedStorage
        /// <summary>
        /// <para>
        /// <para>The amount of storage in gibibytes (GiB) to allocate to each DB instance in the Multi-AZ
        /// DB cluster.</para><para>Valid for Cluster Type: Multi-AZ DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AllocatedStorage { get; set; }
        #endregion
        
        #region Parameter AllowEngineModeChange
        /// <summary>
        /// <para>
        /// <para>Specifies whether engine mode changes from <code>serverless</code> to <code>provisioned</code>
        /// are allowed.</para><para>Valid for Cluster Type: Aurora Serverless v1 DB clusters only</para><para>Constraints:</para><ul><li><para>You must allow engine mode changes when specifying a different value for the <code>EngineMode</code>
        /// parameter from the DB cluster's current engine mode.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowEngineModeChange { get; set; }
        #endregion
        
        #region Parameter AllowMajorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>Specifies whether major version upgrades are allowed.</para><para>Valid for Cluster Type: Aurora DB clusters and Multi-AZ DB clusters</para><para>Constraints:</para><ul><li><para>You must allow major version upgrades when specifying a value for the <code>EngineVersion</code>
        /// parameter that is a different major version than the DB cluster's current version.</para></li></ul>
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
        /// setting for the DB cluster. If this parameter is disabled, changes to the DB cluster
        /// are applied during the next maintenance window.</para><para>Most modifications can be applied immediately or during the next scheduled maintenance
        /// window. Some modifications, such as turning on deletion protection and changing the
        /// master password, are applied immediately—regardless of when you choose to apply them.</para><para>By default, this parameter is disabled.</para><para>Valid for Cluster Type: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ApplyImmediately { get; set; }
        #endregion
        
        #region Parameter AutoMinorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>Specifies whether minor engine upgrades are applied automatically to the DB cluster
        /// during the maintenance window. By default, minor engine upgrades are applied automatically.</para><para>Valid for Cluster Type: Multi-AZ DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoMinorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter ScalingConfiguration_AutoPause
        /// <summary>
        /// <para>
        /// <para>Indicates whether to allow or disallow automatic pause for an Aurora DB cluster in
        /// <code>serverless</code> DB engine mode. A DB cluster can be paused only when it's
        /// idle (it has no connections).</para><note><para>If a DB cluster is paused for more than seven days, the DB cluster might be backed
        /// up with a snapshot. In this case, the DB cluster is restored when there is a request
        /// to connect to it.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ScalingConfiguration_AutoPause { get; set; }
        #endregion
        
        #region Parameter AwsBackupRecoveryPointArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the recovery point in Amazon Web Services Backup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AwsBackupRecoveryPointArn { get; set; }
        #endregion
        
        #region Parameter BacktrackWindow
        /// <summary>
        /// <para>
        /// <para>The target backtrack window, in seconds. To disable backtracking, set this value to
        /// <code>0</code>.</para><para>Valid for Cluster Type: Aurora MySQL DB clusters only</para><para>Default: <code>0</code></para><para>Constraints:</para><ul><li><para>If specified, this value must be set to a number from 0 to 259,200 (72 hours).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? BacktrackWindow { get; set; }
        #endregion
        
        #region Parameter BackupRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days for which automated backups are retained. Specify a minimum value
        /// of <code>1</code>.</para><para>Valid for Cluster Type: Aurora DB clusters and Multi-AZ DB clusters</para><para>Default: <code>1</code></para><para>Constraints:</para><ul><li><para>Must be a value from 1 to 35.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BackupRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter CopyTagsToSnapshot
        /// <summary>
        /// <para>
        /// <para>Specifies whether to copy all tags from the DB cluster to snapshots of the DB cluster.
        /// The default is not to copy them.</para><para>Valid for Cluster Type: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CopyTagsToSnapshot { get; set; }
        #endregion
        
        #region Parameter DBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The DB cluster identifier for the cluster being modified. This parameter isn't case-sensitive.</para><para>Valid for Cluster Type: Aurora DB clusters and Multi-AZ DB clusters</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing DB cluster.</para></li></ul>
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
        /// example <code>db.m6gd.xlarge</code>. Not all DB instance classes are available in
        /// all Amazon Web Services Regions, or for all database engines.</para><para>For the full list of DB instance classes and availability for your engine, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Concepts.DBInstanceClass.html">
        /// DB Instance Class</a> in the <i>Amazon RDS User Guide</i>.</para><para>Valid for Cluster Type: Multi-AZ DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBClusterInstanceClass { get; set; }
        #endregion
        
        #region Parameter DBClusterParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the DB cluster parameter group to use for the DB cluster.</para><para>Valid for Cluster Type: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBClusterParameterGroupName { get; set; }
        #endregion
        
        #region Parameter DBInstanceParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the DB parameter group to apply to all instances of the DB cluster.</para><note><para>When you apply a parameter group using the <code>DBInstanceParameterGroupName</code>
        /// parameter, the DB cluster isn't rebooted automatically. Also, parameter changes are
        /// applied immediately rather than during the next maintenance window.</para></note><para>Valid for Cluster Type: Aurora DB clusters only</para><para>Default: The existing name setting</para><para>Constraints:</para><ul><li><para>The DB parameter group must be in the same DB parameter group family as this DB cluster.</para></li><li><para>The <code>DBInstanceParameterGroupName</code> parameter is valid in combination with
        /// the <code>AllowMajorVersionUpgrade</code> parameter for a major version upgrade only.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBInstanceParameterGroupName { get; set; }
        #endregion
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para>Specifies whether the DB cluster has deletion protection enabled. The database can't
        /// be deleted when deletion protection is enabled. By default, deletion protection isn't
        /// enabled.</para><para>Valid for Cluster Type: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtection { get; set; }
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
        /// <para>The Active Directory directory ID to move the DB cluster to. Specify <code>none</code>
        /// to remove the cluster from its current domain. The domain must be created prior to
        /// this operation.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/kerberos-authentication.html">Kerberos
        /// Authentication</a> in the <i>Amazon Aurora User Guide</i>.</para><para>Valid for Cluster Type: Aurora DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter DomainIAMRoleName
        /// <summary>
        /// <para>
        /// <para>The name of the IAM role to use when making API calls to the Directory Service.</para><para>Valid for Cluster Type: Aurora DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainIAMRoleName { get; set; }
        #endregion
        
        #region Parameter EnableGlobalWriteForwarding
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable this DB cluster to forward write operations to the primary
        /// cluster of a global cluster (Aurora global database). By default, write operations
        /// are not allowed on Aurora DB clusters that are secondary clusters in an Aurora global
        /// database.</para><para>You can set this value only on Aurora DB clusters that are members of an Aurora global
        /// database. With this parameter enabled, a secondary cluster can forward writes to the
        /// current primary cluster, and the resulting changes are replicated back to this cluster.
        /// For the primary DB cluster of an Aurora global database, this value is used immediately
        /// if the primary is demoted by a global cluster API operation, but it does nothing until
        /// then.</para><para>Valid for Cluster Type: Aurora DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableGlobalWriteForwarding { get; set; }
        #endregion
        
        #region Parameter EnableHttpEndpoint
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable the HTTP endpoint for an Aurora Serverless v1 DB cluster.
        /// By default, the HTTP endpoint is disabled.</para><para>When enabled, the HTTP endpoint provides a connectionless web service API for running
        /// SQL queries on the Aurora Serverless v1 DB cluster. You can also query your database
        /// from inside the RDS console with the query editor.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/data-api.html">Using
        /// the Data API for Aurora Serverless v1</a> in the <i>Amazon Aurora User Guide</i>.</para><para>Valid for Cluster Type: Aurora DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableHttpEndpoint { get; set; }
        #endregion
        
        #region Parameter EnableIAMDatabaseAuthentication
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable mapping of Amazon Web Services Identity and Access Management
        /// (IAM) accounts to database accounts. By default, mapping isn't enabled.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/UsingWithRDS.IAMDBAuth.html">
        /// IAM Database Authentication</a> in the <i>Amazon Aurora User Guide</i>.</para><para>Valid for Cluster Type: Aurora DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableIAMDatabaseAuthentication { get; set; }
        #endregion
        
        #region Parameter EnableLocalWriteForwarding
        /// <summary>
        /// <para>
        /// <para>Specifies whether read replicas can forward write operations to the writer DB instance
        /// in the DB cluster. By default, write operations aren't allowed on reader DB instances.</para><para>Valid for: Aurora DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableLocalWriteForwarding { get; set; }
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
        /// <para>Specifies whether to turn on Performance Insights for the DB cluster.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_PerfInsights.html">
        /// Using Amazon Performance Insights</a> in the <i>Amazon RDS User Guide</i>.</para><para>Valid for Cluster Type: Multi-AZ DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnablePerformanceInsights")]
        public System.Boolean? EnablePerformanceInsight { get; set; }
        #endregion
        
        #region Parameter EngineMode
        /// <summary>
        /// <para>
        /// <para>The DB engine mode of the DB cluster, either <code>provisioned</code> or <code>serverless</code>.</para><note><para>The DB engine mode can be modified only from <code>serverless</code> to <code>provisioned</code>.</para></note><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/APIReference/API_CreateDBCluster.html">
        /// CreateDBCluster</a>.</para><para>Valid for Cluster Type: Aurora DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineMode { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The version number of the database engine to which you want to upgrade. Changing this
        /// parameter results in an outage. The change is applied during the next maintenance
        /// window unless <code>ApplyImmediately</code> is enabled.</para><para>If the cluster that you're modifying has one or more read replicas, all replicas must
        /// be running an engine version that's the same or later than the version you specify.</para><para>To list all of the available engine versions for Aurora MySQL, use the following command:</para><para><code>aws rds describe-db-engine-versions --engine aurora-mysql --query "DBEngineVersions[].EngineVersion"</code></para><para>To list all of the available engine versions for Aurora PostgreSQL, use the following
        /// command:</para><para><code>aws rds describe-db-engine-versions --engine aurora-postgresql --query "DBEngineVersions[].EngineVersion"</code></para><para>To list all of the available engine versions for RDS for MySQL, use the following
        /// command:</para><para><code>aws rds describe-db-engine-versions --engine mysql --query "DBEngineVersions[].EngineVersion"</code></para><para>To list all of the available engine versions for RDS for PostgreSQL, use the following
        /// command:</para><para><code>aws rds describe-db-engine-versions --engine postgres --query "DBEngineVersions[].EngineVersion"</code></para><para>Valid for Cluster Type: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter Iops
        /// <summary>
        /// <para>
        /// <para>The amount of Provisioned IOPS (input/output operations per second) to be initially
        /// allocated for each DB instance in the Multi-AZ DB cluster.</para><para>For information about valid IOPS values, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_Storage.html#USER_PIOPS">Amazon
        /// RDS Provisioned IOPS storage</a> in the <i>Amazon RDS User Guide</i>.</para><para>Valid for Cluster Type: Multi-AZ DB clusters only</para><para>Constraints:</para><ul><li><para>Must be a multiple between .5 and 50 of the storage amount for the DB cluster.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Iops { get; set; }
        #endregion
        
        #region Parameter ManageMasterUserPassword
        /// <summary>
        /// <para>
        /// <para>Specifies whether to manage the master user password with Amazon Web Services Secrets
        /// Manager.</para><para>If the DB cluster doesn't manage the master user password with Amazon Web Services
        /// Secrets Manager, you can turn on this management. In this case, you can't specify
        /// <code>MasterUserPassword</code>.</para><para>If the DB cluster already manages the master user password with Amazon Web Services
        /// Secrets Manager, and you specify that the master user password is not managed with
        /// Amazon Web Services Secrets Manager, then you must specify <code>MasterUserPassword</code>.
        /// In this case, RDS deletes the secret and uses the new password for the master user
        /// specified by <code>MasterUserPassword</code>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/rds-secrets-manager.html">Password
        /// management with Amazon Web Services Secrets Manager</a> in the <i>Amazon RDS User
        /// Guide</i> and <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/rds-secrets-manager.html">Password
        /// management with Amazon Web Services Secrets Manager</a> in the <i>Amazon Aurora User
        /// Guide.</i></para><para>Valid for Cluster Type: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ManageMasterUserPassword { get; set; }
        #endregion
        
        #region Parameter MasterUserPassword
        /// <summary>
        /// <para>
        /// <para>The new password for the master database user.</para><para>Valid for Cluster Type: Aurora DB clusters and Multi-AZ DB clusters</para><para>Constraints:</para><ul><li><para>Must contain from 8 to 41 characters.</para></li><li><para>Can contain any printable ASCII character except "/", """, or "@".</para></li><li><para>Can't be specified if <code>ManageMasterUserPassword</code> is turned on.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MasterUserPassword { get; set; }
        #endregion
        
        #region Parameter MasterUserSecretKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services KMS key identifier to encrypt a secret that is automatically
        /// generated and managed in Amazon Web Services Secrets Manager.</para><para>This setting is valid only if both of the following conditions are met:</para><ul><li><para>The DB cluster doesn't manage the master user password in Amazon Web Services Secrets
        /// Manager.</para><para>If the DB cluster already manages the master user password in Amazon Web Services
        /// Secrets Manager, you can't change the KMS key that is used to encrypt the secret.</para></li><li><para>You are turning on <code>ManageMasterUserPassword</code> to manage the master user
        /// password in Amazon Web Services Secrets Manager.</para><para>If you are turning on <code>ManageMasterUserPassword</code> and don't specify <code>MasterUserSecretKmsKeyId</code>,
        /// then the <code>aws/secretsmanager</code> KMS key is used to encrypt the secret. If
        /// the secret is in a different Amazon Web Services account, then you can't use the <code>aws/secretsmanager</code>
        /// KMS key to encrypt the secret, and you must use a customer managed KMS key.</para></li></ul><para>The Amazon Web Services KMS key identifier is the key ARN, key ID, alias ARN, or alias
        /// name for the KMS key. To use a KMS key in a different Amazon Web Services account,
        /// specify the key ARN or alias ARN.</para><para>There is a default KMS key for your Amazon Web Services account. Your Amazon Web Services
        /// account has a different default KMS key for each Amazon Web Services Region.</para><para>Valid for Cluster Type: Aurora DB clusters and Multi-AZ DB clusters</para>
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
        /// for the DB cluster. To turn off collecting Enhanced Monitoring metrics, specify <code>0</code>.</para><para>If <code>MonitoringRoleArn</code> is specified, also set <code>MonitoringInterval</code>
        /// to a value other than <code>0</code>.</para><para>Valid for Cluster Type: Multi-AZ DB clusters only</para><para>Valid Values: <code>0 | 1 | 5 | 10 | 15 | 30 | 60</code></para><para>Default: <code>0</code></para>
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
        /// For information on creating a monitoring role, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_Monitoring.html#USER_Monitoring.OS.IAMRole">To
        /// create an IAM role for Amazon RDS Enhanced Monitoring</a> in the <i>Amazon RDS User
        /// Guide.</i></para><para>If <code>MonitoringInterval</code> is set to a value other than <code>0</code>, supply
        /// a <code>MonitoringRoleArn</code> value.</para><para>Valid for Cluster Type: Multi-AZ DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MonitoringRoleArn { get; set; }
        #endregion
        
        #region Parameter NetworkType
        /// <summary>
        /// <para>
        /// <para>The network type of the DB cluster.</para><para>The network type is determined by the <code>DBSubnetGroup</code> specified for the
        /// DB cluster. A <code>DBSubnetGroup</code> can support only the IPv4 protocol or the
        /// IPv4 and the IPv6 protocols (<code>DUAL</code>).</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/USER_VPC.WorkingWithRDSInstanceinaVPC.html">
        /// Working with a DB instance in a VPC</a> in the <i>Amazon Aurora User Guide.</i></para><para>Valid for Cluster Type: Aurora DB clusters only</para><para>Valid Values: <code>IPV4 | DUAL</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkType { get; set; }
        #endregion
        
        #region Parameter NewDBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The new DB cluster identifier for the DB cluster when renaming a DB cluster. This
        /// value is stored as a lowercase string.</para><para>Valid for Cluster Type: Aurora DB clusters and Multi-AZ DB clusters</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 letters, numbers, or hyphens.</para></li><li><para>The first character must be a letter.</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens.</para></li></ul><para>Example: <code>my-cluster2</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewDBClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter OptionGroupName
        /// <summary>
        /// <para>
        /// <para>The option group to associate the DB cluster with.</para><para>DB clusters are associated with a default option group that can't be modified.</para>
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
        /// Amazon Web Services Region.</para><para>Valid for Cluster Type: Multi-AZ DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PerformanceInsightsKMSKeyId { get; set; }
        #endregion
        
        #region Parameter PerformanceInsightsRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days to retain Performance Insights data.</para><para>Valid for Cluster Type: Multi-AZ DB clusters only</para><para>Valid Values:</para><ul><li><para><code>7</code></para></li><li><para><i>month</i> * 31, where <i>month</i> is a number of months from 1-23. Examples:
        /// <code>93</code> (3 months * 31), <code>341</code> (11 months * 31), <code>589</code>
        /// (19 months * 31)</para></li><li><para><code>731</code></para></li></ul><para>Default: <code>7</code> days</para><para>If you specify a retention period that isn't valid, such as <code>94</code>, Amazon
        /// RDS issues an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PerformanceInsightsRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port number on which the DB cluster accepts connections.</para><para>Valid for Cluster Type: Aurora DB clusters only</para><para>Valid Values: <code>1150-65535</code></para><para>Default: The same port as the original DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter PreferredBackupWindow
        /// <summary>
        /// <para>
        /// <para>The daily time range during which automated backups are created if automated backups
        /// are enabled, using the <code>BackupRetentionPeriod</code> parameter.</para><para>The default is a 30-minute window selected at random from an 8-hour block of time
        /// for each Amazon Web Services Region. To view the time blocks available, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/Aurora.Managing.Backups.html#Aurora.Managing.Backups.BackupWindow">
        /// Backup window</a> in the <i>Amazon Aurora User Guide</i>.</para><para>Valid for Cluster Type: Aurora DB clusters and Multi-AZ DB clusters</para><para>Constraints:</para><ul><li><para>Must be in the format <code>hh24:mi-hh24:mi</code>.</para></li><li><para>Must be in Universal Coordinated Time (UTC).</para></li><li><para>Must not conflict with the preferred maintenance window.</para></li><li><para>Must be at least 30 minutes.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredBackupWindow { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>The weekly time range during which system maintenance can occur, in Universal Coordinated
        /// Time (UTC).</para><para>Valid for Cluster Type: Aurora DB clusters and Multi-AZ DB clusters</para><para>The default is a 30-minute window selected at random from an 8-hour block of time
        /// for each Amazon Web Services Region, occurring on a random day of the week. To see
        /// the time blocks available, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/USER_UpgradeDBInstance.Maintenance.html#AdjustingTheMaintenanceWindow.Aurora">
        /// Adjusting the Preferred DB Cluster Maintenance Window</a> in the <i>Amazon Aurora
        /// User Guide</i>.</para><para>Constraints:</para><ul><li><para>Must be in the format <code>ddd:hh24:mi-ddd:hh24:mi</code>.</para></li><li><para>Days must be one of <code>Mon | Tue | Wed | Thu | Fri | Sat | Sun</code>.</para></li><li><para>Must be in Universal Coordinated Time (UTC).</para></li><li><para>Must be at least 30 minutes.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter RotateMasterUserPassword
        /// <summary>
        /// <para>
        /// <para>Specifies whether to rotate the secret managed by Amazon Web Services Secrets Manager
        /// for the master user password.</para><para>This setting is valid only if the master user password is managed by RDS in Amazon
        /// Web Services Secrets Manager for the DB cluster. The secret value contains the updated
        /// password.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/rds-secrets-manager.html">Password
        /// management with Amazon Web Services Secrets Manager</a> in the <i>Amazon RDS User
        /// Guide</i> and <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/rds-secrets-manager.html">Password
        /// management with Amazon Web Services Secrets Manager</a> in the <i>Amazon Aurora User
        /// Guide.</i></para><para>Valid for Cluster Type: Aurora DB clusters and Multi-AZ DB clusters</para><para>Constraints:</para><ul><li><para>You must apply the change immediately when rotating the master user password.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RotateMasterUserPassword { get; set; }
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
        
        #region Parameter StorageType
        /// <summary>
        /// <para>
        /// <para>The storage type to associate with the DB cluster.</para><para>For information on storage types for Aurora DB clusters, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/Aurora.Overview.StorageReliability.html#aurora-storage-type">Storage
        /// configurations for Amazon Aurora DB clusters</a>. For information on storage types
        /// for Multi-AZ DB clusters, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/create-multi-az-db-cluster.html#create-multi-az-db-cluster-settings">Settings
        /// for creating Multi-AZ DB clusters</a>.</para><para>When specified for a Multi-AZ DB cluster, a value for the <code>Iops</code> parameter
        /// is required.</para><para>Valid for Cluster Type: Aurora DB clusters and Multi-AZ DB clusters</para><para>Valid Values:</para><ul><li><para>Aurora DB clusters - <code>aurora | aurora-iopt1</code></para></li><li><para>Multi-AZ DB clusters - <code>io1</code></para></li></ul><para>Default:</para><ul><li><para>Aurora DB clusters - <code>aurora</code></para></li><li><para>Multi-AZ DB clusters - <code>io1</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageType { get; set; }
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
        /// <para>A list of EC2 VPC security groups to associate with this DB cluster.</para><para>Valid for Cluster Type: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBCluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.ModifyDBClusterResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.ModifyDBClusterResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSDBCluster (ModifyDBCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.ModifyDBClusterResponse, EditRDSDBClusterCmdlet>(Select) ??
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
            context.AllocatedStorage = this.AllocatedStorage;
            context.AllowEngineModeChange = this.AllowEngineModeChange;
            context.AllowMajorVersionUpgrade = this.AllowMajorVersionUpgrade;
            context.ApplyImmediately = this.ApplyImmediately;
            context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            context.AwsBackupRecoveryPointArn = this.AwsBackupRecoveryPointArn;
            context.BacktrackWindow = this.BacktrackWindow;
            context.BackupRetentionPeriod = this.BackupRetentionPeriod;
            if (this.CloudwatchLogsExportConfiguration_DisableLogType != null)
            {
                context.CloudwatchLogsExportConfiguration_DisableLogType = new List<System.String>(this.CloudwatchLogsExportConfiguration_DisableLogType);
            }
            if (this.CloudwatchLogsExportConfiguration_EnableLogType != null)
            {
                context.CloudwatchLogsExportConfiguration_EnableLogType = new List<System.String>(this.CloudwatchLogsExportConfiguration_EnableLogType);
            }
            context.CopyTagsToSnapshot = this.CopyTagsToSnapshot;
            context.DBClusterIdentifier = this.DBClusterIdentifier;
            #if MODULAR
            if (this.DBClusterIdentifier == null && ParameterWasBound(nameof(this.DBClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DBClusterInstanceClass = this.DBClusterInstanceClass;
            context.DBClusterParameterGroupName = this.DBClusterParameterGroupName;
            context.DBInstanceParameterGroupName = this.DBInstanceParameterGroupName;
            context.DeletionProtection = this.DeletionProtection;
            context.Domain = this.Domain;
            context.DomainIAMRoleName = this.DomainIAMRoleName;
            context.EnableGlobalWriteForwarding = this.EnableGlobalWriteForwarding;
            context.EnableHttpEndpoint = this.EnableHttpEndpoint;
            context.EnableIAMDatabaseAuthentication = this.EnableIAMDatabaseAuthentication;
            context.EnableLocalWriteForwarding = this.EnableLocalWriteForwarding;
            context.EnablePerformanceInsight = this.EnablePerformanceInsight;
            context.EngineMode = this.EngineMode;
            context.EngineVersion = this.EngineVersion;
            context.Iops = this.Iops;
            context.ManageMasterUserPassword = this.ManageMasterUserPassword;
            context.MasterUserPassword = this.MasterUserPassword;
            context.MasterUserSecretKmsKeyId = this.MasterUserSecretKmsKeyId;
            context.MonitoringInterval = this.MonitoringInterval;
            context.MonitoringRoleArn = this.MonitoringRoleArn;
            context.NetworkType = this.NetworkType;
            context.NewDBClusterIdentifier = this.NewDBClusterIdentifier;
            context.OptionGroupName = this.OptionGroupName;
            context.PerformanceInsightsKMSKeyId = this.PerformanceInsightsKMSKeyId;
            context.PerformanceInsightsRetentionPeriod = this.PerformanceInsightsRetentionPeriod;
            context.Port = this.Port;
            context.PreferredBackupWindow = this.PreferredBackupWindow;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            context.RotateMasterUserPassword = this.RotateMasterUserPassword;
            context.ScalingConfiguration_AutoPause = this.ScalingConfiguration_AutoPause;
            context.ScalingConfiguration_MaxCapacity = this.ScalingConfiguration_MaxCapacity;
            context.ScalingConfiguration_MinCapacity = this.ScalingConfiguration_MinCapacity;
            context.ScalingConfiguration_SecondsBeforeTimeout = this.ScalingConfiguration_SecondsBeforeTimeout;
            context.ScalingConfiguration_SecondsUntilAutoPause = this.ScalingConfiguration_SecondsUntilAutoPause;
            context.ScalingConfiguration_TimeoutAction = this.ScalingConfiguration_TimeoutAction;
            context.ServerlessV2ScalingConfiguration_MaxCapacity = this.ServerlessV2ScalingConfiguration_MaxCapacity;
            context.ServerlessV2ScalingConfiguration_MinCapacity = this.ServerlessV2ScalingConfiguration_MinCapacity;
            context.StorageType = this.StorageType;
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
            var request = new Amazon.RDS.Model.ModifyDBClusterRequest();
            
            if (cmdletContext.AllocatedStorage != null)
            {
                request.AllocatedStorage = cmdletContext.AllocatedStorage.Value;
            }
            if (cmdletContext.AllowEngineModeChange != null)
            {
                request.AllowEngineModeChange = cmdletContext.AllowEngineModeChange.Value;
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
            if (cmdletContext.AwsBackupRecoveryPointArn != null)
            {
                request.AwsBackupRecoveryPointArn = cmdletContext.AwsBackupRecoveryPointArn;
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
            var requestCloudwatchLogsExportConfigurationIsNull = true;
            request.CloudwatchLogsExportConfiguration = new Amazon.RDS.Model.CloudwatchLogsExportConfiguration();
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
            if (cmdletContext.DBInstanceParameterGroupName != null)
            {
                request.DBInstanceParameterGroupName = cmdletContext.DBInstanceParameterGroupName;
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
            if (cmdletContext.EnableLocalWriteForwarding != null)
            {
                request.EnableLocalWriteForwarding = cmdletContext.EnableLocalWriteForwarding.Value;
            }
            if (cmdletContext.EnablePerformanceInsight != null)
            {
                request.EnablePerformanceInsights = cmdletContext.EnablePerformanceInsight.Value;
            }
            if (cmdletContext.EngineMode != null)
            {
                request.EngineMode = cmdletContext.EngineMode;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.Iops != null)
            {
                request.Iops = cmdletContext.Iops.Value;
            }
            if (cmdletContext.ManageMasterUserPassword != null)
            {
                request.ManageMasterUserPassword = cmdletContext.ManageMasterUserPassword.Value;
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
            if (cmdletContext.NewDBClusterIdentifier != null)
            {
                request.NewDBClusterIdentifier = cmdletContext.NewDBClusterIdentifier;
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
            if (cmdletContext.RotateMasterUserPassword != null)
            {
                request.RotateMasterUserPassword = cmdletContext.RotateMasterUserPassword.Value;
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
            if (cmdletContext.StorageType != null)
            {
                request.StorageType = cmdletContext.StorageType;
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
            public System.Int32? AllocatedStorage { get; set; }
            public System.Boolean? AllowEngineModeChange { get; set; }
            public System.Boolean? AllowMajorVersionUpgrade { get; set; }
            public System.Boolean? ApplyImmediately { get; set; }
            public System.Boolean? AutoMinorVersionUpgrade { get; set; }
            public System.String AwsBackupRecoveryPointArn { get; set; }
            public System.Int64? BacktrackWindow { get; set; }
            public System.Int32? BackupRetentionPeriod { get; set; }
            public List<System.String> CloudwatchLogsExportConfiguration_DisableLogType { get; set; }
            public List<System.String> CloudwatchLogsExportConfiguration_EnableLogType { get; set; }
            public System.Boolean? CopyTagsToSnapshot { get; set; }
            public System.String DBClusterIdentifier { get; set; }
            public System.String DBClusterInstanceClass { get; set; }
            public System.String DBClusterParameterGroupName { get; set; }
            public System.String DBInstanceParameterGroupName { get; set; }
            public System.Boolean? DeletionProtection { get; set; }
            public System.String Domain { get; set; }
            public System.String DomainIAMRoleName { get; set; }
            public System.Boolean? EnableGlobalWriteForwarding { get; set; }
            public System.Boolean? EnableHttpEndpoint { get; set; }
            public System.Boolean? EnableIAMDatabaseAuthentication { get; set; }
            public System.Boolean? EnableLocalWriteForwarding { get; set; }
            public System.Boolean? EnablePerformanceInsight { get; set; }
            public System.String EngineMode { get; set; }
            public System.String EngineVersion { get; set; }
            public System.Int32? Iops { get; set; }
            public System.Boolean? ManageMasterUserPassword { get; set; }
            public System.String MasterUserPassword { get; set; }
            public System.String MasterUserSecretKmsKeyId { get; set; }
            public System.Int32? MonitoringInterval { get; set; }
            public System.String MonitoringRoleArn { get; set; }
            public System.String NetworkType { get; set; }
            public System.String NewDBClusterIdentifier { get; set; }
            public System.String OptionGroupName { get; set; }
            public System.String PerformanceInsightsKMSKeyId { get; set; }
            public System.Int32? PerformanceInsightsRetentionPeriod { get; set; }
            public System.Int32? Port { get; set; }
            public System.String PreferredBackupWindow { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.Boolean? RotateMasterUserPassword { get; set; }
            public System.Boolean? ScalingConfiguration_AutoPause { get; set; }
            public System.Int32? ScalingConfiguration_MaxCapacity { get; set; }
            public System.Int32? ScalingConfiguration_MinCapacity { get; set; }
            public System.Int32? ScalingConfiguration_SecondsBeforeTimeout { get; set; }
            public System.Int32? ScalingConfiguration_SecondsUntilAutoPause { get; set; }
            public System.String ScalingConfiguration_TimeoutAction { get; set; }
            public System.Double? ServerlessV2ScalingConfiguration_MaxCapacity { get; set; }
            public System.Double? ServerlessV2ScalingConfiguration_MinCapacity { get; set; }
            public System.String StorageType { get; set; }
            public List<System.String> VpcSecurityGroupId { get; set; }
            public System.Func<Amazon.RDS.Model.ModifyDBClusterResponse, EditRDSDBClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBCluster;
        }
        
    }
}
