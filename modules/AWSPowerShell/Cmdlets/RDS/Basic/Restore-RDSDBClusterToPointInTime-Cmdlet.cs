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
    /// Restores a DB cluster to an arbitrary point in time. Users can restore to any point
    /// in time before <c>LatestRestorableTime</c> for up to <c>BackupRetentionPeriod</c>
    /// days. The target DB cluster is created from the source DB cluster with the same configuration
    /// as the original DB cluster, except that the new DB cluster is created with the default
    /// DB security group.
    /// 
    ///  <note><para>
    /// For Aurora, this operation only restores the DB cluster, not the DB instances for
    /// that DB cluster. You must invoke the <c>CreateDBInstance</c> operation to create DB
    /// instances for the restored DB cluster, specifying the identifier of the restored DB
    /// cluster in <c>DBClusterIdentifier</c>. You can create DB instances only after the
    /// <c>RestoreDBClusterToPointInTime</c> operation has completed and the DB cluster is
    /// available.
    /// </para></note><para>
    /// For more information on Amazon Aurora DB clusters, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/CHAP_AuroraOverview.html">
    /// What is Amazon Aurora?</a> in the <i>Amazon Aurora User Guide</i>.
    /// </para><para>
    /// For more information on Multi-AZ DB clusters, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/multi-az-db-clusters-concepts.html">
    /// Multi-AZ DB cluster deployments</a> in the <i>Amazon RDS User Guide.</i></para>
    /// </summary>
    [Cmdlet("Restore", "RDSDBClusterToPointInTime", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBCluster")]
    [AWSCmdlet("Calls the Amazon Relational Database Service RestoreDBClusterToPointInTime API operation.", Operation = new[] {"RestoreDBClusterToPointInTime"}, SelectReturnType = typeof(Amazon.RDS.Model.RestoreDBClusterToPointInTimeResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBCluster or Amazon.RDS.Model.RestoreDBClusterToPointInTimeResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBCluster object.",
        "The service call response (type Amazon.RDS.Model.RestoreDBClusterToPointInTimeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RestoreRDSDBClusterToPointInTimeCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ScalingConfiguration_AutoPause
        /// <summary>
        /// <para>
        /// <para>Indicates whether to allow or disallow automatic pause for an Aurora DB cluster in
        /// <c>serverless</c> DB engine mode. A DB cluster can be paused only when it's idle (it
        /// has no connections).</para><note><para>If a DB cluster is paused for more than seven days, the DB cluster might be backed
        /// up with a snapshot. In this case, the DB cluster is restored when there is a request
        /// to connect to it.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ScalingConfiguration_AutoPause { get; set; }
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
        
        #region Parameter CopyTagsToSnapshot
        /// <summary>
        /// <para>
        /// <para>Specifies whether to copy all tags from the restored DB cluster to snapshots of the
        /// restored DB cluster. The default is not to copy them.</para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CopyTagsToSnapshot { get; set; }
        #endregion
        
        #region Parameter DBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The name of the new DB cluster to be created.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 letters, numbers, or hyphens</para></li><li><para>First character must be a letter</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens</para></li></ul><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
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
        /// <para>The compute and memory capacity of the each DB instance in the Multi-AZ DB cluster,
        /// for example db.m6gd.xlarge. Not all DB instance classes are available in all Amazon
        /// Web Services Regions, or for all database engines.</para><para>For the full list of DB instance classes, and availability for your engine, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Concepts.DBInstanceClass.html">DB
        /// instance class</a> in the <i>Amazon RDS User Guide</i>.</para><para>Valid for: Multi-AZ DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBClusterInstanceClass { get; set; }
        #endregion
        
        #region Parameter DBClusterParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the custom DB cluster parameter group to associate with this DB cluster.</para><para>If the <c>DBClusterParameterGroupName</c> parameter is omitted, the default DB cluster
        /// parameter group for the specified engine is used.</para><para>Constraints:</para><ul><li><para>If supplied, must match the name of an existing DB cluster parameter group.</para></li><li><para>Must be 1 to 255 letters, numbers, or hyphens.</para></li><li><para>First character must be a letter.</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens.</para></li></ul><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBClusterParameterGroupName { get; set; }
        #endregion
        
        #region Parameter DBSubnetGroupName
        /// <summary>
        /// <para>
        /// <para>The DB subnet group name to use for the new DB cluster.</para><para>Constraints: If supplied, must match the name of an existing DBSubnetGroup.</para><para>Example: <c>mydbsubnetgroup</c></para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBSubnetGroupName { get; set; }
        #endregion
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable deletion protection for the DB cluster. The database can't
        /// be deleted when deletion protection is enabled. By default, deletion protection isn't
        /// enabled.</para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtection { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The Active Directory directory ID to restore the DB cluster in. The domain must be
        /// created prior to this operation.</para><para>For Amazon Aurora DB clusters, Amazon RDS can use Kerberos Authentication to authenticate
        /// users that connect to the DB cluster. For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/kerberos-authentication.html">Kerberos
        /// Authentication</a> in the <i>Amazon Aurora User Guide</i>.</para><para>Valid for: Aurora DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter DomainIAMRoleName
        /// <summary>
        /// <para>
        /// <para>The name of the IAM role to be used when making API calls to the Directory Service.</para><para>Valid for: Aurora DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainIAMRoleName { get; set; }
        #endregion
        
        #region Parameter EnableCloudwatchLogsExport
        /// <summary>
        /// <para>
        /// <para>The list of logs that the restored DB cluster is to export to CloudWatch Logs. The
        /// values in the list depend on the DB engine being used.</para><para><b>RDS for MySQL</b></para><para>Possible values are <c>error</c>, <c>general</c>, and <c>slowquery</c>.</para><para><b>RDS for PostgreSQL</b></para><para>Possible values are <c>postgresql</c> and <c>upgrade</c>.</para><para><b>Aurora MySQL</b></para><para>Possible values are <c>audit</c>, <c>error</c>, <c>general</c>, and <c>slowquery</c>.</para><para><b>Aurora PostgreSQL</b></para><para>Possible value is <c>postgresql</c>.</para><para>For more information about exporting CloudWatch Logs for Amazon RDS, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_LogAccess.html#USER_LogAccess.Procedural.UploadtoCloudWatch">Publishing
        /// Database Logs to Amazon CloudWatch Logs</a> in the <i>Amazon RDS User Guide</i>.</para><para>For more information about exporting CloudWatch Logs for Amazon Aurora, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/USER_LogAccess.html#USER_LogAccess.Procedural.UploadtoCloudWatch">Publishing
        /// Database Logs to Amazon CloudWatch Logs</a> in the <i>Amazon Aurora User Guide</i>.</para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnableCloudwatchLogsExports")]
        public System.String[] EnableCloudwatchLogsExport { get; set; }
        #endregion
        
        #region Parameter EnableIAMDatabaseAuthentication
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable mapping of Amazon Web Services Identity and Access Management
        /// (IAM) accounts to database accounts. By default, mapping isn't enabled.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/UsingWithRDS.IAMDBAuth.html">
        /// IAM Database Authentication</a> in the <i>Amazon Aurora User Guide</i> or <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/UsingWithRDS.IAMDBAuth.html">
        /// IAM database authentication for MariaDB, MySQL, and PostgreSQL</a> in the <i>Amazon
        /// RDS User Guide</i>.</para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableIAMDatabaseAuthentication { get; set; }
        #endregion
        
        #region Parameter EnablePerformanceInsight
        /// <summary>
        /// <para>
        /// <para>Specifies whether to turn on Performance Insights for the DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnablePerformanceInsights")]
        public System.Boolean? EnablePerformanceInsight { get; set; }
        #endregion
        
        #region Parameter EngineLifecycleSupport
        /// <summary>
        /// <para>
        /// <para>The life cycle type for this DB cluster.</para><note><para>By default, this value is set to <c>open-source-rds-extended-support</c>, which enrolls
        /// your DB cluster into Amazon RDS Extended Support. At the end of standard support,
        /// you can avoid charges for Extended Support by setting the value to <c>open-source-rds-extended-support-disabled</c>.
        /// In this case, RDS automatically upgrades your restored DB cluster to a higher engine
        /// version, if the major engine version is past its end of standard support date.</para></note><para>You can use this setting to enroll your DB cluster into Amazon RDS Extended Support.
        /// With RDS Extended Support, you can run the selected major engine version on your DB
        /// cluster past the end of standard support for that engine version. For more information,
        /// see the following sections:</para><ul><li><para>Amazon Aurora - <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/extended-support.html">Using
        /// Amazon RDS Extended Support</a> in the <i>Amazon Aurora User Guide</i></para></li><li><para>Amazon RDS - <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/extended-support.html">Using
        /// Amazon RDS Extended Support</a> in the <i>Amazon RDS User Guide</i></para></li></ul><para>Valid for Cluster Type: Aurora DB clusters and Multi-AZ DB clusters</para><para>Valid Values: <c>open-source-rds-extended-support | open-source-rds-extended-support-disabled</c></para><para>Default: <c>open-source-rds-extended-support</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineLifecycleSupport { get; set; }
        #endregion
        
        #region Parameter EngineMode
        /// <summary>
        /// <para>
        /// <para>The engine mode of the new cluster. Specify <c>provisioned</c> or <c>serverless</c>,
        /// depending on the type of the cluster you are creating. You can create an Aurora Serverless
        /// v1 clone from a provisioned cluster, or a provisioned clone from an Aurora Serverless
        /// v1 cluster. To create a clone that is an Aurora Serverless v1 cluster, the original
        /// cluster must be an Aurora Serverless v1 cluster or an encrypted provisioned cluster.
        /// To create a full copy that is an Aurora Serverless v1 cluster, specify the engine
        /// mode <c>serverless</c>.</para><para>Valid for: Aurora DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineMode { get; set; }
        #endregion
        
        #region Parameter RdsCustomClusterConfiguration_InterconnectSubnetId
        /// <summary>
        /// <para>
        /// <para>Reserved for future use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RdsCustomClusterConfiguration_InterconnectSubnetId { get; set; }
        #endregion
        
        #region Parameter Iops
        /// <summary>
        /// <para>
        /// <para>The amount of Provisioned IOPS (input/output operations per second) to be initially
        /// allocated for each DB instance in the Multi-AZ DB cluster.</para><para>For information about valid IOPS values, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_Storage.html#USER_PIOPS">Amazon
        /// RDS Provisioned IOPS storage</a> in the <i>Amazon RDS User Guide</i>.</para><para>Constraints: Must be a multiple between .5 and 50 of the storage amount for the DB
        /// instance.</para><para>Valid for: Multi-AZ DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Iops { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services KMS key identifier to use when restoring an encrypted DB cluster
        /// from an encrypted DB cluster.</para><para>The Amazon Web Services KMS key identifier is the key ARN, key ID, alias ARN, or alias
        /// name for the KMS key. To use a KMS key in a different Amazon Web Services account,
        /// specify the key ARN or alias ARN.</para><para>You can restore to a new DB cluster and encrypt the new DB cluster with a KMS key
        /// that is different from the KMS key used to encrypt the source DB cluster. The new
        /// DB cluster is encrypted with the KMS key identified by the <c>KmsKeyId</c> parameter.</para><para>If you don't specify a value for the <c>KmsKeyId</c> parameter, then the following
        /// occurs:</para><ul><li><para>If the DB cluster is encrypted, then the restored DB cluster is encrypted using the
        /// KMS key that was used to encrypt the source DB cluster.</para></li><li><para>If the DB cluster isn't encrypted, then the restored DB cluster isn't encrypted.</para></li></ul><para>If <c>DBClusterIdentifier</c> refers to a DB cluster that isn't encrypted, then the
        /// restore request is rejected.</para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter ScalingConfiguration_MaxCapacity
        /// <summary>
        /// <para>
        /// <para>The maximum capacity for an Aurora DB cluster in <c>serverless</c> DB engine mode.</para><para>For Aurora MySQL, valid capacity values are <c>1</c>, <c>2</c>, <c>4</c>, <c>8</c>,
        /// <c>16</c>, <c>32</c>, <c>64</c>, <c>128</c>, and <c>256</c>.</para><para>For Aurora PostgreSQL, valid capacity values are <c>2</c>, <c>4</c>, <c>8</c>, <c>16</c>,
        /// <c>32</c>, <c>64</c>, <c>192</c>, and <c>384</c>.</para><para>The maximum capacity must be greater than or equal to the minimum capacity.</para>
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
        /// 32, 32.5, 33, and so on. The largest value that you can use is 256 for recent Aurora
        /// versions, or 128 for older versions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? ServerlessV2ScalingConfiguration_MaxCapacity { get; set; }
        #endregion
        
        #region Parameter ScalingConfiguration_MinCapacity
        /// <summary>
        /// <para>
        /// <para>The minimum capacity for an Aurora DB cluster in <c>serverless</c> DB engine mode.</para><para>For Aurora MySQL, valid capacity values are <c>1</c>, <c>2</c>, <c>4</c>, <c>8</c>,
        /// <c>16</c>, <c>32</c>, <c>64</c>, <c>128</c>, and <c>256</c>.</para><para>For Aurora PostgreSQL, valid capacity values are <c>2</c>, <c>4</c>, <c>8</c>, <c>16</c>,
        /// <c>32</c>, <c>64</c>, <c>192</c>, and <c>384</c>.</para><para>The minimum capacity must be less than or equal to the maximum capacity.</para>
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
        /// 8, 8.5, 9, and so on. For Aurora versions that support the Aurora Serverless v2 auto-pause
        /// feature, the smallest value that you can use is 0. For versions that don't support
        /// Aurora Serverless v2 auto-pause, the smallest value that you can use is 0.5. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? ServerlessV2ScalingConfiguration_MinCapacity { get; set; }
        #endregion
        
        #region Parameter MonitoringInterval
        /// <summary>
        /// <para>
        /// <para>The interval, in seconds, between points when Enhanced Monitoring metrics are collected
        /// for the DB cluster. To turn off collecting Enhanced Monitoring metrics, specify <c>0</c>.</para><para>If <c>MonitoringRoleArn</c> is specified, also set <c>MonitoringInterval</c> to a
        /// value other than <c>0</c>.</para><para>Valid Values: <c>0 | 1 | 5 | 10 | 15 | 30 | 60</c></para><para>Default: <c>0</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MonitoringInterval { get; set; }
        #endregion
        
        #region Parameter MonitoringRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the IAM role that permits RDS to send Enhanced
        /// Monitoring metrics to Amazon CloudWatch Logs. An example is <c>arn:aws:iam:123456789012:role/emaccess</c>.</para><para>If <c>MonitoringInterval</c> is set to a value other than <c>0</c>, supply a <c>MonitoringRoleArn</c>
        /// value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MonitoringRoleArn { get; set; }
        #endregion
        
        #region Parameter NetworkType
        /// <summary>
        /// <para>
        /// <para>The network type of the DB cluster.</para><para>Valid Values:</para><ul><li><para><c>IPV4</c></para></li><li><para><c>DUAL</c></para></li></ul><para>The network type is determined by the <c>DBSubnetGroup</c> specified for the DB cluster.
        /// A <c>DBSubnetGroup</c> can support only the IPv4 protocol or the IPv4 and the IPv6
        /// protocols (<c>DUAL</c>).</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/USER_VPC.WorkingWithRDSInstanceinaVPC.html">
        /// Working with a DB instance in a VPC</a> in the <i>Amazon Aurora User Guide.</i></para><para>Valid for: Aurora DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkType { get; set; }
        #endregion
        
        #region Parameter OptionGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the option group for the new DB cluster.</para><para>DB clusters are associated with a default option group that can't be modified.</para>
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
        /// Amazon Web Services Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PerformanceInsightsKMSKeyId { get; set; }
        #endregion
        
        #region Parameter PerformanceInsightsRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days to retain Performance Insights data.</para><para>Valid Values:</para><ul><li><para><c>7</c></para></li><li><para><i>month</i> * 31, where <i>month</i> is a number of months from 1-23. Examples:
        /// <c>93</c> (3 months * 31), <c>341</c> (11 months * 31), <c>589</c> (19 months * 31)</para></li><li><para><c>731</c></para></li></ul><para>Default: <c>7</c> days</para><para>If you specify a retention period that isn't valid, such as <c>94</c>, Amazon RDS
        /// issues an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PerformanceInsightsRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port number on which the new DB cluster accepts connections.</para><para>Constraints: A value from <c>1150-65535</c>.</para><para>Default: The default port for the engine.</para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>Specifies whether the DB cluster is publicly accessible.</para><para>When the DB cluster is publicly accessible, its Domain Name System (DNS) endpoint
        /// resolves to the private IP address from within the DB cluster's virtual private cloud
        /// (VPC). It resolves to the public IP address from outside of the DB cluster's VPC.
        /// Access to the DB cluster is ultimately controlled by the security group it uses. That
        /// public access is not permitted if the security group assigned to the DB cluster doesn't
        /// permit it.</para><para>When the DB cluster isn't publicly accessible, it is an internal DB cluster with a
        /// DNS name that resolves to a private IP address.</para><para>Default: The default behavior varies depending on whether <c>DBSubnetGroupName</c>
        /// is specified.</para><para>If <c>DBSubnetGroupName</c> isn't specified, and <c>PubliclyAccessible</c> isn't specified,
        /// the following applies:</para><ul><li><para>If the default VPC in the target Region doesn’t have an internet gateway attached
        /// to it, the DB cluster is private.</para></li><li><para>If the default VPC in the target Region has an internet gateway attached to it, the
        /// DB cluster is public.</para></li></ul><para>If <c>DBSubnetGroupName</c> is specified, and <c>PubliclyAccessible</c> isn't specified,
        /// the following applies:</para><ul><li><para>If the subnets are part of a VPC that doesn’t have an internet gateway attached to
        /// it, the DB cluster is private.</para></li><li><para>If the subnets are part of a VPC that has an internet gateway attached to it, the
        /// DB cluster is public.</para></li></ul><para>Valid for: Multi-AZ DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter RdsCustomClusterConfiguration_ReplicaMode
        /// <summary>
        /// <para>
        /// <para>Reserved for future use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RDS.ReplicaMode")]
        public Amazon.RDS.ReplicaMode RdsCustomClusterConfiguration_ReplicaMode { get; set; }
        #endregion
        
        #region Parameter UtcRestoreToTime
        /// <summary>
        /// <para>
        /// <para>The date and time to restore the DB cluster to.</para><para>Valid Values: Value must be a time in Universal Coordinated Time (UTC) format</para><para>Constraints:</para><ul><li><para>Must be before the latest restorable time for the DB instance</para></li><li><para>Must be specified if <c>UseLatestRestorableTime</c> parameter isn't provided</para></li><li><para>Can't be specified if the <c>UseLatestRestorableTime</c> parameter is enabled</para></li><li><para>Can't be specified if the <c>RestoreType</c> parameter is <c>copy-on-write</c></para></li></ul><para>Example: <c>2015-03-07T23:45:00Z</c></para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? UtcRestoreToTime { get; set; }
        #endregion
        
        #region Parameter RestoreType
        /// <summary>
        /// <para>
        /// <para>The type of restore to be performed. You can specify one of the following values:</para><ul><li><para><c>full-copy</c> - The new DB cluster is restored as a full copy of the source DB
        /// cluster.</para></li><li><para><c>copy-on-write</c> - The new DB cluster is restored as a clone of the source DB
        /// cluster.</para></li></ul><para>If you don't specify a <c>RestoreType</c> value, then the new DB cluster is restored
        /// as a full copy of the source DB cluster.</para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestoreType { get; set; }
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
        /// <para>The time, in seconds, before an Aurora DB cluster in <c>serverless</c> mode is paused.</para><para>Specify a value between 300 and 86,400 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingConfiguration_SecondsUntilAutoPause { get; set; }
        #endregion
        
        #region Parameter ServerlessV2ScalingConfiguration_SecondsUntilAutoPause
        /// <summary>
        /// <para>
        /// <para>Specifies the number of seconds an Aurora Serverless v2 DB instance must be idle before
        /// Aurora attempts to automatically pause it. </para><para>Specify a value between 300 seconds (five minutes) and 86,400 seconds (one day). The
        /// default is 300 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ServerlessV2ScalingConfiguration_SecondsUntilAutoPause { get; set; }
        #endregion
        
        #region Parameter SourceDBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the source DB cluster from which to restore.</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing DBCluster.</para></li></ul><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceDBClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter SourceDbClusterResourceId
        /// <summary>
        /// <para>
        /// <para>The resource ID of the source DB cluster from which to restore.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceDbClusterResourceId { get; set; }
        #endregion
        
        #region Parameter StorageType
        /// <summary>
        /// <para>
        /// <para>Specifies the storage type to be associated with the DB cluster.</para><para>When specified for a Multi-AZ DB cluster, a value for the <c>Iops</c> parameter is
        /// required.</para><para>Valid Values: <c>aurora</c>, <c>aurora-iopt1</c> (Aurora DB clusters); <c>io1</c>
        /// (Multi-AZ DB clusters)</para><para>Default: <c>aurora</c> (Aurora DB clusters); <c>io1</c> (Multi-AZ DB clusters)</para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
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
        
        #region Parameter ScalingConfiguration_TimeoutAction
        /// <summary>
        /// <para>
        /// <para>The action to take when the timeout is reached, either <c>ForceApplyCapacityChange</c>
        /// or <c>RollbackCapacityChange</c>.</para><para><c>ForceApplyCapacityChange</c> sets the capacity to the specified value as soon
        /// as possible.</para><para><c>RollbackCapacityChange</c>, the default, ignores the capacity change if a scaling
        /// point isn't found in the timeout period.</para><important><para>If you specify <c>ForceApplyCapacityChange</c>, connections that prevent Aurora Serverless
        /// v1 from finding a scaling point might be dropped.</para></important><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/aurora-serverless.how-it-works.html#aurora-serverless.how-it-works.auto-scaling">
        /// Autoscaling for Aurora Serverless v1</a> in the <i>Amazon Aurora User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScalingConfiguration_TimeoutAction { get; set; }
        #endregion
        
        #region Parameter RdsCustomClusterConfiguration_TransitGatewayMulticastDomainId
        /// <summary>
        /// <para>
        /// <para>Reserved for future use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RdsCustomClusterConfiguration_TransitGatewayMulticastDomainId { get; set; }
        #endregion
        
        #region Parameter UseLatestRestorableTime
        /// <summary>
        /// <para>
        /// <para>Specifies whether to restore the DB cluster to the latest restorable backup time.
        /// By default, the DB cluster isn't restored to the latest restorable backup time.</para><para>Constraints: Can't be specified if <c>RestoreToTime</c> parameter is provided.</para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UseLatestRestorableTime { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of VPC security groups that the new DB cluster belongs to.</para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter RestoreToTime
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use RestoreToTimeUtc instead. Setting either RestoreToTime
        /// or RestoreToTimeUtc results in both RestoreToTime and RestoreToTimeUtc being assigned,
        /// the latest assignment to either one of the two property is reflected in the value
        /// of both. RestoreToTime is provided for backwards compatibility only and assigning
        /// a non-Utc DateTime to it results in the wrong timestamp being passed to the service.</para><para>The date and time to restore the DB cluster to.</para><para>Valid Values: Value must be a time in Universal Coordinated Time (UTC) format</para><para>Constraints:</para><ul><li><para>Must be before the latest restorable time for the DB instance</para></li><li><para>Must be specified if <c>UseLatestRestorableTime</c> parameter isn't provided</para></li><li><para>Can't be specified if the <c>UseLatestRestorableTime</c> parameter is enabled</para></li><li><para>Can't be specified if the <c>RestoreType</c> parameter is <c>copy-on-write</c></para></li></ul><para>Example: <c>2015-03-07T23:45:00Z</c></para><para>Valid for: Aurora DB clusters and Multi-AZ DB clusters</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed to the service, use UtcRestoreToTime instead.")]
        public System.DateTime? RestoreToTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBCluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.RestoreDBClusterToPointInTimeResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.RestoreDBClusterToPointInTimeResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-RDSDBClusterToPointInTime (RestoreDBClusterToPointInTime)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.RestoreDBClusterToPointInTimeResponse, RestoreRDSDBClusterToPointInTimeCmdlet>(Select) ??
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
            context.BacktrackWindow = this.BacktrackWindow;
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
            context.EngineLifecycleSupport = this.EngineLifecycleSupport;
            context.EngineMode = this.EngineMode;
            context.Iops = this.Iops;
            context.KmsKeyId = this.KmsKeyId;
            context.MonitoringInterval = this.MonitoringInterval;
            context.MonitoringRoleArn = this.MonitoringRoleArn;
            context.NetworkType = this.NetworkType;
            context.OptionGroupName = this.OptionGroupName;
            context.PerformanceInsightsKMSKeyId = this.PerformanceInsightsKMSKeyId;
            context.PerformanceInsightsRetentionPeriod = this.PerformanceInsightsRetentionPeriod;
            context.Port = this.Port;
            context.PubliclyAccessible = this.PubliclyAccessible;
            context.RdsCustomClusterConfiguration_InterconnectSubnetId = this.RdsCustomClusterConfiguration_InterconnectSubnetId;
            context.RdsCustomClusterConfiguration_ReplicaMode = this.RdsCustomClusterConfiguration_ReplicaMode;
            context.RdsCustomClusterConfiguration_TransitGatewayMulticastDomainId = this.RdsCustomClusterConfiguration_TransitGatewayMulticastDomainId;
            context.UtcRestoreToTime = this.UtcRestoreToTime;
            context.RestoreType = this.RestoreType;
            context.ScalingConfiguration_AutoPause = this.ScalingConfiguration_AutoPause;
            context.ScalingConfiguration_MaxCapacity = this.ScalingConfiguration_MaxCapacity;
            context.ScalingConfiguration_MinCapacity = this.ScalingConfiguration_MinCapacity;
            context.ScalingConfiguration_SecondsBeforeTimeout = this.ScalingConfiguration_SecondsBeforeTimeout;
            context.ScalingConfiguration_SecondsUntilAutoPause = this.ScalingConfiguration_SecondsUntilAutoPause;
            context.ScalingConfiguration_TimeoutAction = this.ScalingConfiguration_TimeoutAction;
            context.ServerlessV2ScalingConfiguration_MaxCapacity = this.ServerlessV2ScalingConfiguration_MaxCapacity;
            context.ServerlessV2ScalingConfiguration_MinCapacity = this.ServerlessV2ScalingConfiguration_MinCapacity;
            context.ServerlessV2ScalingConfiguration_SecondsUntilAutoPause = this.ServerlessV2ScalingConfiguration_SecondsUntilAutoPause;
            context.SourceDBClusterIdentifier = this.SourceDBClusterIdentifier;
            context.SourceDbClusterResourceId = this.SourceDbClusterResourceId;
            context.StorageType = this.StorageType;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
            context.UseLatestRestorableTime = this.UseLatestRestorableTime;
            if (this.VpcSecurityGroupId != null)
            {
                context.VpcSecurityGroupId = new List<System.String>(this.VpcSecurityGroupId);
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.RestoreToTime = this.RestoreToTime;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
            var request = new Amazon.RDS.Model.RestoreDBClusterToPointInTimeRequest();
            
            if (cmdletContext.BacktrackWindow != null)
            {
                request.BacktrackWindow = cmdletContext.BacktrackWindow.Value;
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
            if (cmdletContext.EngineLifecycleSupport != null)
            {
                request.EngineLifecycleSupport = cmdletContext.EngineLifecycleSupport;
            }
            if (cmdletContext.EngineMode != null)
            {
                request.EngineMode = cmdletContext.EngineMode;
            }
            if (cmdletContext.Iops != null)
            {
                request.Iops = cmdletContext.Iops.Value;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
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
            if (cmdletContext.PubliclyAccessible != null)
            {
                request.PubliclyAccessible = cmdletContext.PubliclyAccessible.Value;
            }
            
             // populate RdsCustomClusterConfiguration
            var requestRdsCustomClusterConfigurationIsNull = true;
            request.RdsCustomClusterConfiguration = new Amazon.RDS.Model.RdsCustomClusterConfiguration();
            System.String requestRdsCustomClusterConfiguration_rdsCustomClusterConfiguration_InterconnectSubnetId = null;
            if (cmdletContext.RdsCustomClusterConfiguration_InterconnectSubnetId != null)
            {
                requestRdsCustomClusterConfiguration_rdsCustomClusterConfiguration_InterconnectSubnetId = cmdletContext.RdsCustomClusterConfiguration_InterconnectSubnetId;
            }
            if (requestRdsCustomClusterConfiguration_rdsCustomClusterConfiguration_InterconnectSubnetId != null)
            {
                request.RdsCustomClusterConfiguration.InterconnectSubnetId = requestRdsCustomClusterConfiguration_rdsCustomClusterConfiguration_InterconnectSubnetId;
                requestRdsCustomClusterConfigurationIsNull = false;
            }
            Amazon.RDS.ReplicaMode requestRdsCustomClusterConfiguration_rdsCustomClusterConfiguration_ReplicaMode = null;
            if (cmdletContext.RdsCustomClusterConfiguration_ReplicaMode != null)
            {
                requestRdsCustomClusterConfiguration_rdsCustomClusterConfiguration_ReplicaMode = cmdletContext.RdsCustomClusterConfiguration_ReplicaMode;
            }
            if (requestRdsCustomClusterConfiguration_rdsCustomClusterConfiguration_ReplicaMode != null)
            {
                request.RdsCustomClusterConfiguration.ReplicaMode = requestRdsCustomClusterConfiguration_rdsCustomClusterConfiguration_ReplicaMode;
                requestRdsCustomClusterConfigurationIsNull = false;
            }
            System.String requestRdsCustomClusterConfiguration_rdsCustomClusterConfiguration_TransitGatewayMulticastDomainId = null;
            if (cmdletContext.RdsCustomClusterConfiguration_TransitGatewayMulticastDomainId != null)
            {
                requestRdsCustomClusterConfiguration_rdsCustomClusterConfiguration_TransitGatewayMulticastDomainId = cmdletContext.RdsCustomClusterConfiguration_TransitGatewayMulticastDomainId;
            }
            if (requestRdsCustomClusterConfiguration_rdsCustomClusterConfiguration_TransitGatewayMulticastDomainId != null)
            {
                request.RdsCustomClusterConfiguration.TransitGatewayMulticastDomainId = requestRdsCustomClusterConfiguration_rdsCustomClusterConfiguration_TransitGatewayMulticastDomainId;
                requestRdsCustomClusterConfigurationIsNull = false;
            }
             // determine if request.RdsCustomClusterConfiguration should be set to null
            if (requestRdsCustomClusterConfigurationIsNull)
            {
                request.RdsCustomClusterConfiguration = null;
            }
            if (cmdletContext.UtcRestoreToTime != null)
            {
                request.RestoreToTimeUtc = cmdletContext.UtcRestoreToTime.Value;
            }
            if (cmdletContext.RestoreType != null)
            {
                request.RestoreType = cmdletContext.RestoreType;
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
            System.Int32? requestServerlessV2ScalingConfiguration_serverlessV2ScalingConfiguration_SecondsUntilAutoPause = null;
            if (cmdletContext.ServerlessV2ScalingConfiguration_SecondsUntilAutoPause != null)
            {
                requestServerlessV2ScalingConfiguration_serverlessV2ScalingConfiguration_SecondsUntilAutoPause = cmdletContext.ServerlessV2ScalingConfiguration_SecondsUntilAutoPause.Value;
            }
            if (requestServerlessV2ScalingConfiguration_serverlessV2ScalingConfiguration_SecondsUntilAutoPause != null)
            {
                request.ServerlessV2ScalingConfiguration.SecondsUntilAutoPause = requestServerlessV2ScalingConfiguration_serverlessV2ScalingConfiguration_SecondsUntilAutoPause.Value;
                requestServerlessV2ScalingConfigurationIsNull = false;
            }
             // determine if request.ServerlessV2ScalingConfiguration should be set to null
            if (requestServerlessV2ScalingConfigurationIsNull)
            {
                request.ServerlessV2ScalingConfiguration = null;
            }
            if (cmdletContext.SourceDBClusterIdentifier != null)
            {
                request.SourceDBClusterIdentifier = cmdletContext.SourceDBClusterIdentifier;
            }
            if (cmdletContext.SourceDbClusterResourceId != null)
            {
                request.SourceDbClusterResourceId = cmdletContext.SourceDbClusterResourceId;
            }
            if (cmdletContext.StorageType != null)
            {
                request.StorageType = cmdletContext.StorageType;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.UseLatestRestorableTime != null)
            {
                request.UseLatestRestorableTime = cmdletContext.UseLatestRestorableTime.Value;
            }
            if (cmdletContext.VpcSecurityGroupId != null)
            {
                request.VpcSecurityGroupIds = cmdletContext.VpcSecurityGroupId;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.RestoreToTime != null)
            {
                if (cmdletContext.UtcRestoreToTime != null)
                {
                    throw new System.ArgumentException("Parameters RestoreToTime and UtcRestoreToTime are mutually exclusive.", nameof(this.RestoreToTime));
                }
                request.RestoreToTime = cmdletContext.RestoreToTime.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
        
        private Amazon.RDS.Model.RestoreDBClusterToPointInTimeResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.RestoreDBClusterToPointInTimeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "RestoreDBClusterToPointInTime");
            try
            {
                #if DESKTOP
                return client.RestoreDBClusterToPointInTime(request);
                #elif CORECLR
                return client.RestoreDBClusterToPointInTimeAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? BacktrackWindow { get; set; }
            public System.Boolean? CopyTagsToSnapshot { get; set; }
            public System.String DBClusterIdentifier { get; set; }
            public System.String DBClusterInstanceClass { get; set; }
            public System.String DBClusterParameterGroupName { get; set; }
            public System.String DBSubnetGroupName { get; set; }
            public System.Boolean? DeletionProtection { get; set; }
            public System.String Domain { get; set; }
            public System.String DomainIAMRoleName { get; set; }
            public List<System.String> EnableCloudwatchLogsExport { get; set; }
            public System.Boolean? EnableIAMDatabaseAuthentication { get; set; }
            public System.Boolean? EnablePerformanceInsight { get; set; }
            public System.String EngineLifecycleSupport { get; set; }
            public System.String EngineMode { get; set; }
            public System.Int32? Iops { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.Int32? MonitoringInterval { get; set; }
            public System.String MonitoringRoleArn { get; set; }
            public System.String NetworkType { get; set; }
            public System.String OptionGroupName { get; set; }
            public System.String PerformanceInsightsKMSKeyId { get; set; }
            public System.Int32? PerformanceInsightsRetentionPeriod { get; set; }
            public System.Int32? Port { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public System.String RdsCustomClusterConfiguration_InterconnectSubnetId { get; set; }
            public Amazon.RDS.ReplicaMode RdsCustomClusterConfiguration_ReplicaMode { get; set; }
            public System.String RdsCustomClusterConfiguration_TransitGatewayMulticastDomainId { get; set; }
            public System.DateTime? UtcRestoreToTime { get; set; }
            public System.String RestoreType { get; set; }
            public System.Boolean? ScalingConfiguration_AutoPause { get; set; }
            public System.Int32? ScalingConfiguration_MaxCapacity { get; set; }
            public System.Int32? ScalingConfiguration_MinCapacity { get; set; }
            public System.Int32? ScalingConfiguration_SecondsBeforeTimeout { get; set; }
            public System.Int32? ScalingConfiguration_SecondsUntilAutoPause { get; set; }
            public System.String ScalingConfiguration_TimeoutAction { get; set; }
            public System.Double? ServerlessV2ScalingConfiguration_MaxCapacity { get; set; }
            public System.Double? ServerlessV2ScalingConfiguration_MinCapacity { get; set; }
            public System.Int32? ServerlessV2ScalingConfiguration_SecondsUntilAutoPause { get; set; }
            public System.String SourceDBClusterIdentifier { get; set; }
            public System.String SourceDbClusterResourceId { get; set; }
            public System.String StorageType { get; set; }
            public List<Amazon.RDS.Model.Tag> Tag { get; set; }
            public System.Boolean? UseLatestRestorableTime { get; set; }
            public List<System.String> VpcSecurityGroupId { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? RestoreToTime { get; set; }
            public System.Func<Amazon.RDS.Model.RestoreDBClusterToPointInTimeResponse, RestoreRDSDBClusterToPointInTimeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBCluster;
        }
        
    }
}
