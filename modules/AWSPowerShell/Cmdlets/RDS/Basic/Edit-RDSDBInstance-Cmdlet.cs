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
    /// Modifies settings for a DB instance. You can change one or more database configuration
    /// parameters by specifying these parameters and the new values in the request. To learn
    /// what modifications you can make to your DB instance, call <code>DescribeValidDBInstanceModifications</code>
    /// before you call <code>ModifyDBInstance</code>.
    /// </summary>
    [Cmdlet("Edit", "RDSDBInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBInstance")]
    [AWSCmdlet("Calls the Amazon Relational Database Service ModifyDBInstance API operation.", Operation = new[] {"ModifyDBInstance"}, SelectReturnType = typeof(Amazon.RDS.Model.ModifyDBInstanceResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBInstance or Amazon.RDS.Model.ModifyDBInstanceResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBInstance object.",
        "The service call response (type Amazon.RDS.Model.ModifyDBInstanceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditRDSDBInstanceCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllocatedStorage
        /// <summary>
        /// <para>
        /// <para>The new amount of storage in gibibytes (GiB) to allocate for the DB instance.</para><para>For RDS for MariaDB, RDS for MySQL, RDS for Oracle, and RDS for PostgreSQL, the value
        /// supplied must be at least 10% greater than the current value. Values that are not
        /// at least 10% greater than the existing value are rounded up so that they are 10% greater
        /// than the current value.</para><para>For the valid values for allocated storage for each engine, see <code>CreateDBInstance</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AllocatedStorage { get; set; }
        #endregion
        
        #region Parameter AllowMajorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>Specifies whether major version upgrades are allowed. Changing this parameter doesn't
        /// result in an outage and the change is asynchronously applied as soon as possible.</para><para>This setting doesn't apply to RDS Custom DB instances.</para><para>Constraints:</para><ul><li><para>Major version upgrades must be allowed when specifying a value for the <code>EngineVersion</code>
        /// parameter that's a different major version than the DB instance's current version.</para></li></ul>
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
        /// setting for the DB instance. By default, this parameter is disabled.</para><para>If this parameter is disabled, changes to the DB instance are applied during the next
        /// maintenance window. Some parameter changes can cause an outage and are applied on
        /// the next call to <a>RebootDBInstance</a>, or the next failure reboot. Review the table
        /// of parameters in <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Overview.DBInstance.Modifying.html">Modifying
        /// a DB Instance</a> in the <i>Amazon RDS User Guide</i> to see the impact of enabling
        /// or disabling <code>ApplyImmediately</code> for each modified parameter and to determine
        /// when the changes are applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ApplyImmediately { get; set; }
        #endregion
        
        #region Parameter AutomationMode
        /// <summary>
        /// <para>
        /// <para>The automation mode of the RDS Custom DB instance. If <code>full</code>, the DB instance
        /// automates monitoring and instance recovery. If <code>all paused</code>, the instance
        /// pauses automation for the duration set by <code>ResumeFullAutomationModeMinutes</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RDS.AutomationMode")]
        public Amazon.RDS.AutomationMode AutomationMode { get; set; }
        #endregion
        
        #region Parameter AutoMinorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>Specifies whether minor version upgrades are applied automatically to the DB instance
        /// during the maintenance window. An outage occurs when all the following conditions
        /// are met:</para><ul><li><para>The automatic upgrade is enabled for the maintenance window.</para></li><li><para>A newer minor version is available.</para></li><li><para>RDS has enabled automatic patching for the engine version.</para></li></ul><para>If any of the preceding conditions isn't met, Amazon RDS applies the change as soon
        /// as possible and doesn't cause an outage.</para><para>For an RDS Custom DB instance, don't enable this setting. Otherwise, the operation
        /// returns an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoMinorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter AwsBackupRecoveryPointArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the recovery point in Amazon Web Services Backup.</para><para>This setting doesn't apply to RDS Custom DB instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AwsBackupRecoveryPointArn { get; set; }
        #endregion
        
        #region Parameter BackupRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days to retain automated backups. Setting this parameter to a positive
        /// number enables backups. Setting this parameter to 0 disables automated backups.</para><note><para>Enabling and disabling backups can result in a brief I/O suspension that lasts from
        /// a few seconds to a few minutes, depending on the size and class of your DB instance.</para></note><para>These changes are applied during the next maintenance window unless the <code>ApplyImmediately</code>
        /// parameter is enabled for this request. If you change the parameter from one non-zero
        /// value to another non-zero value, the change is asynchronously applied as soon as possible.</para><para>This setting doesn't apply to Amazon Aurora DB instances. The retention period for
        /// automated backups is managed by the DB cluster. For more information, see <code>ModifyDBCluster</code>.</para><para>Default: Uses existing setting</para><para>Constraints:</para><ul><li><para>Must be a value from 0 to 35.</para></li><li><para>Can't be set to 0 if the DB instance is a source to read replicas.</para></li><li><para>Can't be set to 0 for an RDS Custom for Oracle DB instance.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BackupRetentionPeriod { get; set; }
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
        
        #region Parameter CertificateRotationRestart
        /// <summary>
        /// <para>
        /// <para>Specifies whether the DB instance is restarted when you rotate your SSL/TLS certificate.</para><para>By default, the DB instance is restarted when you rotate your SSL/TLS certificate.
        /// The certificate is not updated until the DB instance is restarted.</para><important><para>Set this parameter only if you are <i>not</i> using SSL/TLS to connect to the DB instance.</para></important><para>If you are using SSL/TLS to connect to the DB instance, follow the appropriate instructions
        /// for your DB engine to rotate your SSL/TLS certificate:</para><ul><li><para>For more information about rotating your SSL/TLS certificate for RDS DB engines, see
        /// <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/UsingWithRDS.SSL-certificate-rotation.html">
        /// Rotating Your SSL/TLS Certificate.</a> in the <i>Amazon RDS User Guide.</i></para></li><li><para>For more information about rotating your SSL/TLS certificate for Aurora DB engines,
        /// see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/UsingWithRDS.SSL-certificate-rotation.html">
        /// Rotating Your SSL/TLS Certificate</a> in the <i>Amazon Aurora User Guide</i>.</para></li></ul><para>This setting doesn't apply to RDS Custom DB instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CertificateRotationRestart { get; set; }
        #endregion
        
        #region Parameter CopyTagsToSnapshot
        /// <summary>
        /// <para>
        /// <para>Specifies whether to copy all tags from the DB instance to snapshots of the DB instance.
        /// By default, tags aren't copied.</para><para>This setting doesn't apply to Amazon Aurora DB instances. Copying tags to snapshots
        /// is managed by the DB cluster. Setting this value for an Aurora DB instance has no
        /// effect on the DB cluster setting. For more information, see <code>ModifyDBCluster</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CopyTagsToSnapshot { get; set; }
        #endregion
        
        #region Parameter DBInstanceClass
        /// <summary>
        /// <para>
        /// <para>The new compute and memory capacity of the DB instance, for example <code>db.m4.large</code>.
        /// Not all DB instance classes are available in all Amazon Web Services Regions, or for
        /// all database engines. For the full list of DB instance classes, and availability for
        /// your engine, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Concepts.DBInstanceClass.html">DB
        /// Instance Class</a> in the <i>Amazon RDS User Guide</i> or <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/Concepts.DBInstanceClass.html">Aurora
        /// DB instance classes</a> in the <i>Amazon Aurora User Guide</i>. For RDS Custom, see
        /// <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/custom-reqs-limits.html#custom-reqs-limits.instances">DB
        /// instance class support for RDS Custom for Oracle</a> and <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/custom-reqs-limits-MS.html#custom-reqs-limits.instancesMS">
        /// DB instance class support for RDS Custom for SQL Server</a>.</para><para>If you modify the DB instance class, an outage occurs during the change. The change
        /// is applied during the next maintenance window, unless you specify <code>ApplyImmediately</code>
        /// in your request. </para><para>Default: Uses existing setting</para><para>Constraints:</para><ul><li><para>If you are modifying the DB instance class and upgrading the engine version at the
        /// same time, the currently running engine version must be supported on the specified
        /// DB instance class. Otherwise, the operation returns an error. In this case, first
        /// run the operation to modify the DB instance class, and then run it again to upgrade
        /// the engine version.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBInstanceClass { get; set; }
        #endregion
        
        #region Parameter DBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of DB instance to modify. This value is stored as a lowercase string.</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing DB instance.</para></li></ul>
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
        /// <para>The name of the DB parameter group to apply to the DB instance.</para><para>Changing this setting doesn't result in an outage. The parameter group name itself
        /// is changed immediately, but the actual parameter changes are not applied until you
        /// reboot the instance without failover. In this case, the DB instance isn't rebooted
        /// automatically, and the parameter changes aren't applied during the next maintenance
        /// window. However, if you modify dynamic parameters in the newly associated DB parameter
        /// group, these changes are applied immediately without a reboot.</para><para>This setting doesn't apply to RDS Custom DB instances.</para><para>Default: Uses existing setting</para><para>Constraints:</para><ul><li><para>Must be in the same DB parameter group family as the DB instance.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBParameterGroupName { get; set; }
        #endregion
        
        #region Parameter DBPortNumber
        /// <summary>
        /// <para>
        /// <para>The port number on which the database accepts connections.</para><para>The value of the <code>DBPortNumber</code> parameter must not match any of the port
        /// values specified for options in the option group for the DB instance.</para><para>If you change the <code>DBPortNumber</code> value, your database restarts regardless
        /// of the value of the <code>ApplyImmediately</code> parameter.</para><para>This setting doesn't apply to RDS Custom DB instances.</para><para>Valid Values: <code>1150-65535</code></para><para>Default:</para><ul><li><para>Amazon Aurora - <code>3306</code></para></li><li><para>RDS for MariaDB - <code>3306</code></para></li><li><para>RDS for Microsoft SQL Server - <code>1433</code></para></li><li><para>RDS for MySQL - <code>3306</code></para></li><li><para>RDS for Oracle - <code>1521</code></para></li><li><para>RDS for PostgreSQL - <code>5432</code></para></li></ul><para>Constraints:</para><ul><li><para>For RDS for Microsoft SQL Server, the value can't be <code>1234</code>, <code>1434</code>,
        /// <code>3260</code>, <code>3343</code>, <code>3389</code>, <code>47001</code>, or <code>49152-49156</code>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DBPortNumber { get; set; }
        #endregion
        
        #region Parameter DBSecurityGroup
        /// <summary>
        /// <para>
        /// <para>A list of DB security groups to authorize on this DB instance. Changing this setting
        /// doesn't result in an outage and the change is asynchronously applied as soon as possible.</para><para>This setting doesn't apply to RDS Custom DB instances.</para><para>Constraints:</para><ul><li><para>If supplied, must match existing DB security groups.</para></li></ul>
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
        /// DB instance to a different VPC. If your DB instance isn't in a VPC, you can also use
        /// this parameter to move your DB instance into a VPC. For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_VPC.WorkingWithRDSInstanceinaVPC.html#USER_VPC.Non-VPC2VPC">Working
        /// with a DB instance in a VPC</a> in the <i>Amazon RDS User Guide</i>.</para><para>Changing the subnet group causes an outage during the change. The change is applied
        /// during the next maintenance window, unless you enable <code>ApplyImmediately</code>.</para><para>This parameter doesn't apply to RDS Custom DB instances.</para><para>Constraints:</para><ul><li><para>If supplied, must match existing DB subnet group.</para></li></ul><para>Example: <code>mydbsubnetgroup</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBSubnetGroupName { get; set; }
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
        /// Deleting a DB Instance</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtection { get; set; }
        #endregion
        
        #region Parameter DisableDomain
        /// <summary>
        /// <para>
        /// <para>Specifies whether to remove the DB instance from the Active Directory domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DisableDomain { get; set; }
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
        /// <para>The Active Directory directory ID to move the DB instance to. Specify <code>none</code>
        /// to remove the instance from its current domain. You must create the domain before
        /// this operation. Currently, you can create only MySQL, Microsoft SQL Server, Oracle,
        /// and PostgreSQL DB instances in an Active Directory Domain.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/kerberos-authentication.html">
        /// Kerberos Authentication</a> in the <i>Amazon RDS User Guide</i>.</para><para>This setting doesn't apply to RDS Custom DB instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter DomainAuthSecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN for the Secrets Manager secret with the credentials for the user joining the
        /// domain.</para><para>Example: <code>arn:aws:secretsmanager:region:account-number:secret:myselfmanagedADtestsecret-123456</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainAuthSecretArn { get; set; }
        #endregion
        
        #region Parameter DomainDnsIp
        /// <summary>
        /// <para>
        /// <para>The IPv4 DNS IP addresses of your primary and secondary Active Directory domain controllers.</para><para>Constraints:</para><ul><li><para>Two IP addresses must be provided. If there isn't a secondary domain controller, use
        /// the IP address of the primary domain controller for both entries in the list.</para></li></ul><para>Example: <code>123.124.125.126,234.235.236.237</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainDnsIps")]
        public System.String[] DomainDnsIp { get; set; }
        #endregion
        
        #region Parameter DomainFqdn
        /// <summary>
        /// <para>
        /// <para>The fully qualified domain name (FQDN) of an Active Directory domain.</para><para>Constraints:</para><ul><li><para>Can't be longer than 64 characters.</para></li></ul><para>Example: <code>mymanagedADtest.mymanagedAD.mydomain</code></para>
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
        /// <para>The Active Directory organizational unit for your DB instance to join.</para><para>Constraints:</para><ul><li><para>Must be in the distinguished name format.</para></li><li><para>Can't be longer than 64 characters.</para></li></ul><para>Example: <code>OU=mymanagedADtestOU,DC=mymanagedADtest,DC=mymanagedAD,DC=mydomain</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainOu { get; set; }
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
        /// (IAM) accounts to database accounts. By default, mapping isn't enabled.</para><para>This setting doesn't apply to Amazon Aurora. Mapping Amazon Web Services IAM accounts
        /// to database accounts is managed by the DB cluster.</para><para>For more information about IAM database authentication, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/UsingWithRDS.IAMDBAuth.html">
        /// IAM Database Authentication for MySQL and PostgreSQL</a> in the <i>Amazon RDS User
        /// Guide.</i></para><para>This setting doesn't apply to RDS Custom DB instances.</para>
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
        /// <para>Specifies whether to enable Performance Insights for the DB instance.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_PerfInsights.html">Using
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
        /// <para>The target Oracle DB engine when you convert a non-CDB to a CDB. This intermediate
        /// step is necessary to upgrade an Oracle Database 19c non-CDB to an Oracle Database
        /// 21c CDB.</para><para>Note the following requirements:</para><ul><li><para>Make sure that you specify <code>oracle-ee-cdb</code> or <code>oracle-se2-cdb</code>.</para></li><li><para>Make sure that your DB engine runs Oracle Database 19c with an April 2021 or later
        /// RU.</para></li></ul><para>Note the following limitations:</para><ul><li><para>You can't convert a CDB to a non-CDB.</para></li><li><para>You can't convert a replica database.</para></li><li><para>You can't convert a non-CDB to a CDB and upgrade the engine version in the same command.</para></li><li><para>You can't convert the existing custom parameter or option group when it has options
        /// or parameters that are permanent or persistent. In this situation, the DB instance
        /// reverts to the default option and parameter group. To avoid reverting to the default,
        /// specify a new parameter group with <code>--db-parameter-group-name</code> and a new
        /// option group with <code>--option-group-name</code>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The version number of the database engine to upgrade to. Changing this parameter results
        /// in an outage and the change is applied during the next maintenance window unless the
        /// <code>ApplyImmediately</code> parameter is enabled for this request.</para><para>For major version upgrades, if a nondefault DB parameter group is currently in use,
        /// a new DB parameter group in the DB parameter group family for the new engine version
        /// must be specified. The new DB parameter group can be the default for that DB parameter
        /// group family.</para><para>If you specify only a major version, Amazon RDS updates the DB instance to the default
        /// minor version if the current minor version is lower. For information about valid engine
        /// versions, see <code>CreateDBInstance</code>, or call <code>DescribeDBEngineVersions</code>.</para><para>If the instance that you're modifying is acting as a read replica, the engine version
        /// that you specify must be the same or higher than the version that the source DB instance
        /// or cluster is running.</para><para>In RDS Custom for Oracle, this parameter is supported for read replicas only if they
        /// are in the <code>PATCH_DB_FAILURE</code> lifecycle.</para><para>Constraints:</para><ul><li><para>If you are upgrading the engine version and modifying the DB instance class at the
        /// same time, the currently running engine version must be supported on the specified
        /// DB instance class. Otherwise, the operation returns an error. In this case, first
        /// run the operation to modify the DB instance class, and then run it again to upgrade
        /// the engine version.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter Iops
        /// <summary>
        /// <para>
        /// <para>The new Provisioned IOPS (I/O operations per second) value for the RDS instance.</para><para>Changing this setting doesn't result in an outage and the change is applied during
        /// the next maintenance window unless the <code>ApplyImmediately</code> parameter is
        /// enabled for this request. If you are migrating from Provisioned IOPS to standard storage,
        /// set this value to 0. The DB instance will require a reboot for the change in storage
        /// type to take effect.</para><para>If you choose to migrate your DB instance from using standard storage to using Provisioned
        /// IOPS, or from using Provisioned IOPS to using standard storage, the process can take
        /// time. The duration of the migration depends on several factors such as database load,
        /// storage size, storage type (standard or Provisioned IOPS), amount of IOPS provisioned
        /// (if any), and the number of prior scale storage operations. Typical migration times
        /// are under 24 hours, but the process can take up to several days in some cases. During
        /// the migration, the DB instance is available for use, but might experience performance
        /// degradation. While the migration takes place, nightly backups for the instance are
        /// suspended. No other Amazon RDS operations can take place for the instance, including
        /// modifying the instance, rebooting the instance, deleting the instance, creating a
        /// read replica for the instance, and creating a DB snapshot of the instance.</para><para>Constraints:</para><ul><li><para>For RDS for MariaDB, RDS for MySQL, RDS for Oracle, and RDS for PostgreSQL - The value
        /// supplied must be at least 10% greater than the current value. Values that are not
        /// at least 10% greater than the existing value are rounded up so that they are 10% greater
        /// than the current value.</para></li></ul><para>Default: Uses existing setting</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Iops { get; set; }
        #endregion
        
        #region Parameter LicenseModel
        /// <summary>
        /// <para>
        /// <para>The license model for the DB instance.</para><para>This setting doesn't apply to Amazon Aurora or RDS Custom DB instances.</para><para>Valid Values:</para><ul><li><para>RDS for MariaDB - <code>general-public-license</code></para></li><li><para>RDS for Microsoft SQL Server - <code>license-included</code></para></li><li><para>RDS for MySQL - <code>general-public-license</code></para></li><li><para>RDS for Oracle - <code>bring-your-own-license | license-included</code></para></li><li><para>RDS for PostgreSQL - <code>postgresql-license</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LicenseModel { get; set; }
        #endregion
        
        #region Parameter ManageMasterUserPassword
        /// <summary>
        /// <para>
        /// <para>Specifies whether to manage the master user password with Amazon Web Services Secrets
        /// Manager.</para><para>If the DB instance doesn't manage the master user password with Amazon Web Services
        /// Secrets Manager, you can turn on this management. In this case, you can't specify
        /// <code>MasterUserPassword</code>.</para><para>If the DB instance already manages the master user password with Amazon Web Services
        /// Secrets Manager, and you specify that the master user password is not managed with
        /// Amazon Web Services Secrets Manager, then you must specify <code>MasterUserPassword</code>.
        /// In this case, Amazon RDS deletes the secret and uses the new password for the master
        /// user specified by <code>MasterUserPassword</code>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/rds-secrets-manager.html">Password
        /// management with Amazon Web Services Secrets Manager</a> in the <i>Amazon RDS User
        /// Guide.</i></para><para>Constraints:</para><ul><li><para>Can't manage the master user password with Amazon Web Services Secrets Manager if
        /// <code>MasterUserPassword</code> is specified.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ManageMasterUserPassword { get; set; }
        #endregion
        
        #region Parameter MasterUserPassword
        /// <summary>
        /// <para>
        /// <para>The new password for the master user.</para><para>Changing this parameter doesn't result in an outage and the change is asynchronously
        /// applied as soon as possible. Between the time of the request and the completion of
        /// the request, the <code>MasterUserPassword</code> element exists in the <code>PendingModifiedValues</code>
        /// element of the operation response.</para><note><para>Amazon RDS API operations never return the password, so this action provides a way
        /// to regain access to a primary instance user if the password is lost. This includes
        /// restoring privileges that might have been accidentally revoked.</para></note><para>This setting doesn't apply to the following DB instances:</para><ul><li><para>Amazon Aurora (The password for the master user is managed by the DB cluster. For
        /// more information, see <code>ModifyDBCluster</code>.)</para></li><li><para>RDS Custom</para></li></ul><para>Default: Uses existing setting</para><para>Constraints:</para><ul><li><para>Can't be specified if <code>ManageMasterUserPassword</code> is turned on.</para></li><li><para>Can include any printable ASCII character except "/", """, or "@".</para></li></ul><para>Length Constraints:</para><ul><li><para>RDS for MariaDB - Must contain from 8 to 41 characters.</para></li><li><para>RDS for Microsoft SQL Server - Must contain from 8 to 128 characters.</para></li><li><para>RDS for MySQL - Must contain from 8 to 41 characters.</para></li><li><para>RDS for Oracle - Must contain from 8 to 30 characters.</para></li><li><para>RDS for PostgreSQL - Must contain from 8 to 128 characters.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MasterUserPassword { get; set; }
        #endregion
        
        #region Parameter MasterUserSecretKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services KMS key identifier to encrypt a secret that is automatically
        /// generated and managed in Amazon Web Services Secrets Manager.</para><para>This setting is valid only if both of the following conditions are met:</para><ul><li><para>The DB instance doesn't manage the master user password in Amazon Web Services Secrets
        /// Manager.</para><para>If the DB instance already manages the master user password in Amazon Web Services
        /// Secrets Manager, you can't change the KMS key used to encrypt the secret.</para></li><li><para>You are turning on <code>ManageMasterUserPassword</code> to manage the master user
        /// password in Amazon Web Services Secrets Manager.</para><para>If you are turning on <code>ManageMasterUserPassword</code> and don't specify <code>MasterUserSecretKmsKeyId</code>,
        /// then the <code>aws/secretsmanager</code> KMS key is used to encrypt the secret. If
        /// the secret is in a different Amazon Web Services account, then you can't use the <code>aws/secretsmanager</code>
        /// KMS key to encrypt the secret, and you must use a customer managed KMS key.</para></li></ul><para>The Amazon Web Services KMS key identifier is the key ARN, key ID, alias ARN, or alias
        /// name for the KMS key. To use a KMS key in a different Amazon Web Services account,
        /// specify the key ARN or alias ARN.</para><para>There is a default KMS key for your Amazon Web Services account. Your Amazon Web Services
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
        /// RDS User Guide</i>.</para><para>This setting doesn't apply to RDS Custom DB instances.</para>
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
        /// <code>0</code>.</para><para>If <code>MonitoringRoleArn</code> is specified, set <code>MonitoringInterval</code>
        /// to a value other than <code>0</code>.</para><para>This setting doesn't apply to RDS Custom DB instances.</para><para>Valid Values: <code>0 | 1 | 5 | 10 | 15 | 30 | 60</code></para><para>Default: <code>0</code></para>
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
        /// For information on creating a monitoring role, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_Monitoring.html#USER_Monitoring.OS.IAMRole">To
        /// create an IAM role for Amazon RDS Enhanced Monitoring</a> in the <i>Amazon RDS User
        /// Guide.</i></para><para>If <code>MonitoringInterval</code> is set to a value other than <code>0</code>, supply
        /// a <code>MonitoringRoleArn</code> value.</para><para>This setting doesn't apply to RDS Custom DB instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MonitoringRoleArn { get; set; }
        #endregion
        
        #region Parameter MultiAZ
        /// <summary>
        /// <para>
        /// <para>Specifies whether the DB instance is a Multi-AZ deployment. Changing this parameter
        /// doesn't result in an outage. The change is applied during the next maintenance window
        /// unless the <code>ApplyImmediately</code> parameter is enabled for this request.</para><para>This setting doesn't apply to RDS Custom DB instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MultiAZ { get; set; }
        #endregion
        
        #region Parameter NetworkType
        /// <summary>
        /// <para>
        /// <para>The network type of the DB instance.</para><para>The network type is determined by the <code>DBSubnetGroup</code> specified for the
        /// DB instance. A <code>DBSubnetGroup</code> can support only the IPv4 protocol or the
        /// IPv4 and the IPv6 protocols (<code>DUAL</code>).</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_VPC.WorkingWithRDSInstanceinaVPC.html">
        /// Working with a DB instance in a VPC</a> in the <i>Amazon RDS User Guide.</i></para><para>Valid Values: <code>IPV4 | DUAL</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkType { get; set; }
        #endregion
        
        #region Parameter NewDBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The new identifier for the DB instance when renaming a DB instance. When you change
        /// the DB instance identifier, an instance reboot occurs immediately if you enable <code>ApplyImmediately</code>,
        /// or will occur during the next maintenance window if you disable <code>ApplyImmediately</code>.
        /// This value is stored as a lowercase string.</para><para>This setting doesn't apply to RDS Custom DB instances.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 letters, numbers, or hyphens.</para></li><li><para>The first character must be a letter.</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens.</para></li></ul><para>Example: <code>mydbinstance</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewDBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter OptionGroupName
        /// <summary>
        /// <para>
        /// <para>The option group to associate the DB instance with.</para><para>Changing this parameter doesn't result in an outage, with one exception. If the parameter
        /// change results in an option group that enables OEM, it can cause a brief period, lasting
        /// less than a second, during which new connections are rejected but existing connections
        /// aren't interrupted.</para><para>The change is applied during the next maintenance window unless the <code>ApplyImmediately</code>
        /// parameter is enabled for this request.</para><para>Permanent options, such as the TDE option for Oracle Advanced Security TDE, can't
        /// be removed from an option group, and that option group can't be removed from a DB
        /// instance after it is associated with a DB instance.</para><para>This setting doesn't apply to RDS Custom DB instances.</para>
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
        /// Amazon Web Services Region.</para><para>This setting doesn't apply to RDS Custom DB instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PerformanceInsightsKMSKeyId { get; set; }
        #endregion
        
        #region Parameter PerformanceInsightsRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days to retain Performance Insights data.</para><para>This setting doesn't apply to RDS Custom DB instances.</para><para>Valid Values:</para><ul><li><para><code>7</code></para></li><li><para><i>month</i> * 31, where <i>month</i> is a number of months from 1-23. Examples:
        /// <code>93</code> (3 months * 31), <code>341</code> (11 months * 31), <code>589</code>
        /// (19 months * 31)</para></li><li><para><code>731</code></para></li></ul><para>Default: <code>7</code> days</para><para>If you specify a retention period that isn't valid, such as <code>94</code>, Amazon
        /// RDS returns an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PerformanceInsightsRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter PreferredBackupWindow
        /// <summary>
        /// <para>
        /// <para>The daily time range during which automated backups are created if automated backups
        /// are enabled, as determined by the <code>BackupRetentionPeriod</code> parameter. Changing
        /// this parameter doesn't result in an outage and the change is asynchronously applied
        /// as soon as possible. The default is a 30-minute window selected at random from an
        /// 8-hour block of time for each Amazon Web Services Region. For more information, see
        /// <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_WorkingWithAutomatedBackups.html#USER_WorkingWithAutomatedBackups.BackupWindow">Backup
        /// window</a> in the <i>Amazon RDS User Guide</i>.</para><para>This setting doesn't apply to Amazon Aurora DB instances. The daily time range for
        /// creating automated backups is managed by the DB cluster. For more information, see
        /// <code>ModifyDBCluster</code>.</para><para>Constraints:</para><ul><li><para>Must be in the format <code>hh24:mi-hh24:mi</code>.</para></li><li><para>Must be in Universal Coordinated Time (UTC).</para></li><li><para>Must not conflict with the preferred maintenance window.</para></li><li><para>Must be at least 30 minutes.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredBackupWindow { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>The weekly time range during which system maintenance can occur, which might result
        /// in an outage. Changing this parameter doesn't result in an outage, except in the following
        /// situation, and the change is asynchronously applied as soon as possible. If there
        /// are pending actions that cause a reboot, and the maintenance window is changed to
        /// include the current time, then changing this parameter causes a reboot of the DB instance.
        /// If you change this window to the current time, there must be at least 30 minutes between
        /// the current time and end of the window to ensure pending changes are applied.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_UpgradeDBInstance.Maintenance.html#Concepts.DBMaintenance">Amazon
        /// RDS Maintenance Window</a> in the <i>Amazon RDS User Guide.</i></para><para>Default: Uses existing setting</para><para>Constraints:</para><ul><li><para>Must be in the format <code>ddd:hh24:mi-ddd:hh24:mi</code>.</para></li><li><para>The day values must be <code>mon | tue | wed | thu | fri | sat | sun</code>. </para></li><li><para>Must be in Universal Coordinated Time (UTC).</para></li><li><para>Must not conflict with the preferred backup window.</para></li><li><para>Must be at least 30 minutes.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter ProcessorFeature
        /// <summary>
        /// <para>
        /// <para>The number of CPU cores and the number of threads per core for the DB instance class
        /// of the DB instance.</para><para>This setting doesn't apply to RDS Custom DB instances.</para>
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
        /// Fault Tolerance for an Aurora DB Cluster</a> in the <i>Amazon Aurora User Guide</i>.</para><para>This setting doesn't apply to RDS Custom DB instances.</para><para>Default: <code>1</code></para><para>Valid Values: <code>0 - 15</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PromotionTier { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>Specifies whether the DB instance is publicly accessible.</para><para>When the DB cluster is publicly accessible, its Domain Name System (DNS) endpoint
        /// resolves to the private IP address from within the DB cluster's virtual private cloud
        /// (VPC). It resolves to the public IP address from outside of the DB cluster's VPC.
        /// Access to the DB cluster is ultimately controlled by the security group it uses. That
        /// public access isn't permitted if the security group assigned to the DB cluster doesn't
        /// permit it.</para><para>When the DB instance isn't publicly accessible, it is an internal DB instance with
        /// a DNS name that resolves to a private IP address.</para><para><code>PubliclyAccessible</code> only applies to DB instances in a VPC. The DB instance
        /// must be part of a public subnet and <code>PubliclyAccessible</code> must be enabled
        /// for it to be publicly accessible.</para><para>Changes to the <code>PubliclyAccessible</code> parameter are applied immediately regardless
        /// of the value of the <code>ApplyImmediately</code> parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter ReplicaMode
        /// <summary>
        /// <para>
        /// <para>A value that sets the open mode of a replica database to either mounted or read-only.</para><note><para>Currently, this parameter is only supported for Oracle DB instances.</para></note><para>Mounted DB replicas are included in Oracle Enterprise Edition. The main use case for
        /// mounted replicas is cross-Region disaster recovery. The primary database doesn't use
        /// Active Data Guard to transmit information to the mounted replica. Because it doesn't
        /// accept user connections, a mounted replica can't serve a read-only workload. For more
        /// information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/oracle-read-replicas.html">Working
        /// with Oracle Read Replicas for Amazon RDS</a> in the <i>Amazon RDS User Guide</i>.</para><para>This setting doesn't apply to RDS Custom DB instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RDS.ReplicaMode")]
        public Amazon.RDS.ReplicaMode ReplicaMode { get; set; }
        #endregion
        
        #region Parameter ResumeFullAutomationModeMinute
        /// <summary>
        /// <para>
        /// <para>The number of minutes to pause the automation. When the time period ends, RDS Custom
        /// resumes full automation.</para><para>Default: <code>60</code></para><para>Constraints:</para><ul><li><para>Must be at least 60.</para></li><li><para>Must be no more than 1,440.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResumeFullAutomationModeMinutes")]
        public System.Int32? ResumeFullAutomationModeMinute { get; set; }
        #endregion
        
        #region Parameter RotateMasterUserPassword
        /// <summary>
        /// <para>
        /// <para>Specifies whether to rotate the secret managed by Amazon Web Services Secrets Manager
        /// for the master user password.</para><para>This setting is valid only if the master user password is managed by RDS in Amazon
        /// Web Services Secrets Manager for the DB cluster. The secret value contains the updated
        /// password.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/rds-secrets-manager.html">Password
        /// management with Amazon Web Services Secrets Manager</a> in the <i>Amazon RDS User
        /// Guide.</i></para><para>Constraints:</para><ul><li><para>You must apply the change immediately when rotating the master user password.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RotateMasterUserPassword { get; set; }
        #endregion
        
        #region Parameter StorageThroughput
        /// <summary>
        /// <para>
        /// <para>The storage throughput value for the DB instance.</para><para>This setting applies only to the <code>gp3</code> storage type.</para><para>This setting doesn't apply to Amazon Aurora or RDS Custom DB instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StorageThroughput { get; set; }
        #endregion
        
        #region Parameter StorageType
        /// <summary>
        /// <para>
        /// <para>The storage type to associate with the DB instance.</para><para>If you specify Provisioned IOPS (<code>io1</code>), you must also include a value
        /// for the <code>Iops</code> parameter.</para><para>If you choose to migrate your DB instance from using standard storage to using Provisioned
        /// IOPS, or from using Provisioned IOPS to using standard storage, the process can take
        /// time. The duration of the migration depends on several factors such as database load,
        /// storage size, storage type (standard or Provisioned IOPS), amount of IOPS provisioned
        /// (if any), and the number of prior scale storage operations. Typical migration times
        /// are under 24 hours, but the process can take up to several days in some cases. During
        /// the migration, the DB instance is available for use, but might experience performance
        /// degradation. While the migration takes place, nightly backups for the instance are
        /// suspended. No other Amazon RDS operations can take place for the instance, including
        /// modifying the instance, rebooting the instance, deleting the instance, creating a
        /// read replica for the instance, and creating a DB snapshot of the instance.</para><para>Valid Values: <code>gp2 | gp3 | io1 | standard</code></para><para>Default: <code>io1</code>, if the <code>Iops</code> parameter is specified. Otherwise,
        /// <code>gp2</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageType { get; set; }
        #endregion
        
        #region Parameter TdeCredentialArn
        /// <summary>
        /// <para>
        /// <para>The ARN from the key store with which to associate the instance for TDE encryption.</para><para>This setting doesn't apply to RDS Custom DB instances.</para>
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
        
        #region Parameter UseDefaultProcessorFeature
        /// <summary>
        /// <para>
        /// <para>Specifies whether the DB instance class of the DB instance uses its default processor
        /// features.</para><para>This setting doesn't apply to RDS Custom DB instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UseDefaultProcessorFeatures")]
        public System.Boolean? UseDefaultProcessorFeature { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of Amazon EC2 VPC security groups to associate with this DB instance. This
        /// change is asynchronously applied as soon as possible.</para><para>This setting doesn't apply to the following DB instances:</para><ul><li><para>Amazon Aurora (The associated list of EC2 VPC security groups is managed by the DB
        /// cluster. For more information, see <code>ModifyDBCluster</code>.)</para></li><li><para>RDS Custom</para></li></ul><para>Constraints:</para><ul><li><para>If supplied, must match existing VPC security group IDs.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBInstance'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.ModifyDBInstanceResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.ModifyDBInstanceResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSDBInstance (ModifyDBInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.ModifyDBInstanceResponse, EditRDSDBInstanceCmdlet>(Select) ??
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
            context.AutomationMode = this.AutomationMode;
            context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            context.AwsBackupRecoveryPointArn = this.AwsBackupRecoveryPointArn;
            context.BackupRetentionPeriod = this.BackupRetentionPeriod;
            context.CACertificateIdentifier = this.CACertificateIdentifier;
            context.CertificateRotationRestart = this.CertificateRotationRestart;
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
            context.DedicatedLogVolume = this.DedicatedLogVolume;
            context.DeletionProtection = this.DeletionProtection;
            context.DisableDomain = this.DisableDomain;
            context.Domain = this.Domain;
            context.DomainAuthSecretArn = this.DomainAuthSecretArn;
            if (this.DomainDnsIp != null)
            {
                context.DomainDnsIp = new List<System.String>(this.DomainDnsIp);
            }
            context.DomainFqdn = this.DomainFqdn;
            context.DomainIAMRoleName = this.DomainIAMRoleName;
            context.DomainOu = this.DomainOu;
            context.EnableCustomerOwnedIp = this.EnableCustomerOwnedIp;
            context.EnableIAMDatabaseAuthentication = this.EnableIAMDatabaseAuthentication;
            context.EnablePerformanceInsight = this.EnablePerformanceInsight;
            context.Engine = this.Engine;
            context.EngineVersion = this.EngineVersion;
            context.Iops = this.Iops;
            context.LicenseModel = this.LicenseModel;
            context.ManageMasterUserPassword = this.ManageMasterUserPassword;
            context.MasterUserPassword = this.MasterUserPassword;
            context.MasterUserSecretKmsKeyId = this.MasterUserSecretKmsKeyId;
            context.MaxAllocatedStorage = this.MaxAllocatedStorage;
            context.MonitoringInterval = this.MonitoringInterval;
            context.MonitoringRoleArn = this.MonitoringRoleArn;
            context.MultiAZ = this.MultiAZ;
            context.NetworkType = this.NetworkType;
            context.NewDBInstanceIdentifier = this.NewDBInstanceIdentifier;
            context.OptionGroupName = this.OptionGroupName;
            context.PerformanceInsightsKMSKeyId = this.PerformanceInsightsKMSKeyId;
            context.PerformanceInsightsRetentionPeriod = this.PerformanceInsightsRetentionPeriod;
            context.PreferredBackupWindow = this.PreferredBackupWindow;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            if (this.ProcessorFeature != null)
            {
                context.ProcessorFeature = new List<Amazon.RDS.Model.ProcessorFeature>(this.ProcessorFeature);
            }
            context.PromotionTier = this.PromotionTier;
            context.PubliclyAccessible = this.PubliclyAccessible;
            context.ReplicaMode = this.ReplicaMode;
            context.ResumeFullAutomationModeMinute = this.ResumeFullAutomationModeMinute;
            context.RotateMasterUserPassword = this.RotateMasterUserPassword;
            context.StorageThroughput = this.StorageThroughput;
            context.StorageType = this.StorageType;
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
            var request = new Amazon.RDS.Model.ModifyDBInstanceRequest();
            
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
            if (cmdletContext.AutomationMode != null)
            {
                request.AutomationMode = cmdletContext.AutomationMode;
            }
            if (cmdletContext.AutoMinorVersionUpgrade != null)
            {
                request.AutoMinorVersionUpgrade = cmdletContext.AutoMinorVersionUpgrade.Value;
            }
            if (cmdletContext.AwsBackupRecoveryPointArn != null)
            {
                request.AwsBackupRecoveryPointArn = cmdletContext.AwsBackupRecoveryPointArn;
            }
            if (cmdletContext.BackupRetentionPeriod != null)
            {
                request.BackupRetentionPeriod = cmdletContext.BackupRetentionPeriod.Value;
            }
            if (cmdletContext.CACertificateIdentifier != null)
            {
                request.CACertificateIdentifier = cmdletContext.CACertificateIdentifier;
            }
            if (cmdletContext.CertificateRotationRestart != null)
            {
                request.CertificateRotationRestart = cmdletContext.CertificateRotationRestart.Value;
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
            if (cmdletContext.DedicatedLogVolume != null)
            {
                request.DedicatedLogVolume = cmdletContext.DedicatedLogVolume.Value;
            }
            if (cmdletContext.DeletionProtection != null)
            {
                request.DeletionProtection = cmdletContext.DeletionProtection.Value;
            }
            if (cmdletContext.DisableDomain != null)
            {
                request.DisableDomain = cmdletContext.DisableDomain.Value;
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
            if (cmdletContext.PerformanceInsightsRetentionPeriod != null)
            {
                request.PerformanceInsightsRetentionPeriod = cmdletContext.PerformanceInsightsRetentionPeriod.Value;
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
            if (cmdletContext.ReplicaMode != null)
            {
                request.ReplicaMode = cmdletContext.ReplicaMode;
            }
            if (cmdletContext.ResumeFullAutomationModeMinute != null)
            {
                request.ResumeFullAutomationModeMinutes = cmdletContext.ResumeFullAutomationModeMinute.Value;
            }
            if (cmdletContext.RotateMasterUserPassword != null)
            {
                request.RotateMasterUserPassword = cmdletContext.RotateMasterUserPassword.Value;
            }
            if (cmdletContext.StorageThroughput != null)
            {
                request.StorageThroughput = cmdletContext.StorageThroughput.Value;
            }
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
        
        private Amazon.RDS.Model.ModifyDBInstanceResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ModifyDBInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ModifyDBInstance");
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
            public Amazon.RDS.AutomationMode AutomationMode { get; set; }
            public System.Boolean? AutoMinorVersionUpgrade { get; set; }
            public System.String AwsBackupRecoveryPointArn { get; set; }
            public System.Int32? BackupRetentionPeriod { get; set; }
            public System.String CACertificateIdentifier { get; set; }
            public System.Boolean? CertificateRotationRestart { get; set; }
            public List<System.String> CloudwatchLogsExportConfiguration_DisableLogType { get; set; }
            public List<System.String> CloudwatchLogsExportConfiguration_EnableLogType { get; set; }
            public System.Boolean? CopyTagsToSnapshot { get; set; }
            public System.String DBInstanceClass { get; set; }
            public System.String DBInstanceIdentifier { get; set; }
            public System.String DBParameterGroupName { get; set; }
            public System.Int32? DBPortNumber { get; set; }
            public List<System.String> DBSecurityGroup { get; set; }
            public System.String DBSubnetGroupName { get; set; }
            public System.Boolean? DedicatedLogVolume { get; set; }
            public System.Boolean? DeletionProtection { get; set; }
            public System.Boolean? DisableDomain { get; set; }
            public System.String Domain { get; set; }
            public System.String DomainAuthSecretArn { get; set; }
            public List<System.String> DomainDnsIp { get; set; }
            public System.String DomainFqdn { get; set; }
            public System.String DomainIAMRoleName { get; set; }
            public System.String DomainOu { get; set; }
            public System.Boolean? EnableCustomerOwnedIp { get; set; }
            public System.Boolean? EnableIAMDatabaseAuthentication { get; set; }
            public System.Boolean? EnablePerformanceInsight { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineVersion { get; set; }
            public System.Int32? Iops { get; set; }
            public System.String LicenseModel { get; set; }
            public System.Boolean? ManageMasterUserPassword { get; set; }
            public System.String MasterUserPassword { get; set; }
            public System.String MasterUserSecretKmsKeyId { get; set; }
            public System.Int32? MaxAllocatedStorage { get; set; }
            public System.Int32? MonitoringInterval { get; set; }
            public System.String MonitoringRoleArn { get; set; }
            public System.Boolean? MultiAZ { get; set; }
            public System.String NetworkType { get; set; }
            public System.String NewDBInstanceIdentifier { get; set; }
            public System.String OptionGroupName { get; set; }
            public System.String PerformanceInsightsKMSKeyId { get; set; }
            public System.Int32? PerformanceInsightsRetentionPeriod { get; set; }
            public System.String PreferredBackupWindow { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public List<Amazon.RDS.Model.ProcessorFeature> ProcessorFeature { get; set; }
            public System.Int32? PromotionTier { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public Amazon.RDS.ReplicaMode ReplicaMode { get; set; }
            public System.Int32? ResumeFullAutomationModeMinute { get; set; }
            public System.Boolean? RotateMasterUserPassword { get; set; }
            public System.Int32? StorageThroughput { get; set; }
            public System.String StorageType { get; set; }
            public System.String TdeCredentialArn { get; set; }
            public System.String TdeCredentialPassword { get; set; }
            public System.Boolean? UseDefaultProcessorFeature { get; set; }
            public List<System.String> VpcSecurityGroupId { get; set; }
            public System.Func<Amazon.RDS.Model.ModifyDBInstanceResponse, EditRDSDBInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBInstance;
        }
        
    }
}
