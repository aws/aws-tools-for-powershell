/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// parameters by specifying these parameters and the new values in the request.
    /// </summary>
    [Cmdlet("Edit", "RDSDBInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBInstance")]
    [AWSCmdlet("Invokes the ModifyDBInstance operation against Amazon Relational Database Service.", Operation = new[] {"ModifyDBInstance"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBInstance",
        "This cmdlet returns a DBInstance object.",
        "The service call response (type Amazon.RDS.Model.ModifyDBInstanceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditRDSDBInstanceCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter AllocatedStorage
        /// <summary>
        /// <para>
        /// <para> The new storage capacity of the RDS instance. Changing this setting does not result
        /// in an outage and the change is applied during the next maintenance window unless <code>ApplyImmediately</code>
        /// is set to <code>true</code> for this request. </para><para><b>MySQL</b></para><para>Default: Uses existing setting</para><para>Valid Values: 5-6144</para><para>Constraints: Value supplied must be at least 10% greater than the current value. Values
        /// that are not at least 10% greater than the existing value are rounded up so that they
        /// are 10% greater than the current value.</para><para>Type: Integer</para><para><b>MariaDB</b></para><para>Default: Uses existing setting</para><para>Valid Values: 5-6144</para><para>Constraints: Value supplied must be at least 10% greater than the current value. Values
        /// that are not at least 10% greater than the existing value are rounded up so that they
        /// are 10% greater than the current value.</para><para>Type: Integer</para><para><b>PostgreSQL</b></para><para>Default: Uses existing setting</para><para>Valid Values: 5-6144</para><para>Constraints: Value supplied must be at least 10% greater than the current value. Values
        /// that are not at least 10% greater than the existing value are rounded up so that they
        /// are 10% greater than the current value.</para><para>Type: Integer</para><para><b>Oracle</b></para><para>Default: Uses existing setting</para><para>Valid Values: 10-6144</para><para>Constraints: Value supplied must be at least 10% greater than the current value. Values
        /// that are not at least 10% greater than the existing value are rounded up so that they
        /// are 10% greater than the current value.</para><para><b>SQL Server</b></para><para>Cannot be modified.</para><para>If you choose to migrate your DB instance from using standard storage to using Provisioned
        /// IOPS, or from using Provisioned IOPS to using standard storage, the process can take
        /// time. The duration of the migration depends on several factors such as database load,
        /// storage size, storage type (standard or Provisioned IOPS), amount of IOPS provisioned
        /// (if any), and the number of prior scale storage operations. Typical migration times
        /// are under 24 hours, but the process can take up to several days in some cases. During
        /// the migration, the DB instance will be available for use, but might experience performance
        /// degradation. While the migration takes place, nightly backups for the instance will
        /// be suspended. No other Amazon RDS operations can take place for the instance, including
        /// modifying the instance, rebooting the instance, deleting the instance, creating a
        /// Read Replica for the instance, and creating a DB snapshot of the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 AllocatedStorage { get; set; }
        #endregion
        
        #region Parameter AllowMajorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>Indicates that major version upgrades are allowed. Changing this parameter does not
        /// result in an outage and the change is asynchronously applied as soon as possible.</para><para>Constraints: This parameter must be set to true when specifying a value for the EngineVersion
        /// parameter that is a different major version than the DB instance's current version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AllowMajorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter ApplyImmediately
        /// <summary>
        /// <para>
        /// <para>Specifies whether the modifications in this request and any pending modifications
        /// are asynchronously applied as soon as possible, regardless of the <code>PreferredMaintenanceWindow</code>
        /// setting for the DB instance. </para><para> If this parameter is set to <code>false</code>, changes to the DB instance are applied
        /// during the next maintenance window. Some parameter changes can cause an outage and
        /// will be applied on the next call to <a>RebootDBInstance</a>, or the next failure reboot.
        /// Review the table of parameters in <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Overview.DBInstance.Modifying.html">Modifying
        /// a DB Instance and Using the Apply Immediately Parameter</a> to see the impact that
        /// setting <code>ApplyImmediately</code> to <code>true</code> or <code>false</code> has
        /// for each modified parameter and to determine when the changes will be applied. </para><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ApplyImmediately { get; set; }
        #endregion
        
        #region Parameter AutoMinorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para> Indicates that minor version upgrades will be applied automatically to the DB instance
        /// during the maintenance window. Changing this parameter does not result in an outage
        /// except in the following case and the change is asynchronously applied as soon as possible.
        /// An outage will result if this parameter is set to <code>true</code> during the maintenance
        /// window, and a newer minor version is available, and RDS has enabled auto patching
        /// for that engine version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AutoMinorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter BackupRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days to retain automated backups. Setting this parameter to a positive
        /// number enables backups. Setting this parameter to 0 disables automated backups.</para><para>Changing this parameter can result in an outage if you change from 0 to a non-zero
        /// value or from a non-zero value to 0. These changes are applied during the next maintenance
        /// window unless the <code>ApplyImmediately</code> parameter is set to <code>true</code>
        /// for this request. If you change the parameter from one non-zero value to another non-zero
        /// value, the change is asynchronously applied as soon as possible.</para><para>Default: Uses existing setting</para><para>Constraints:</para><ul><li><para>Must be a value from 0 to 35</para></li><li><para>Can be specified for a MySQL Read Replica only if the source is running MySQL 5.6</para></li><li><para>Can be specified for a PostgreSQL Read Replica only if the source is running PostgreSQL
        /// 9.3.5</para></li><li><para>Cannot be set to 0 if the DB instance is a source to Read Replicas</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 BackupRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter CACertificateIdentifier
        /// <summary>
        /// <para>
        /// <para>Indicates the certificate that needs to be associated with the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CACertificateIdentifier { get; set; }
        #endregion
        
        #region Parameter CopyTagsToSnapshot
        /// <summary>
        /// <para>
        /// <para>True to copy all tags from the DB instance to snapshots of the DB instance; otherwise
        /// false. The default is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean CopyTagsToSnapshot { get; set; }
        #endregion
        
        #region Parameter DBInstanceClass
        /// <summary>
        /// <para>
        /// <para> The new compute and memory capacity of the DB instance. To determine the instance
        /// classes that are available for a particular DB engine, use the <a>DescribeOrderableDBInstanceOptions</a>
        /// action. Note that not all instance classes are available in all regions for all DB
        /// engines. </para><para> Passing a value for this setting causes an outage during the change and is applied
        /// during the next maintenance window, unless <code>ApplyImmediately</code> is specified
        /// as <code>true</code> for this request. </para><para>Default: Uses existing setting</para><para>Valid Values: <code>db.t1.micro | db.m1.small | db.m1.medium | db.m1.large | db.m1.xlarge
        /// | db.m2.xlarge | db.m2.2xlarge | db.m2.4xlarge | db.m3.medium | db.m3.large | db.m3.xlarge
        /// | db.m3.2xlarge | db.m4.large | db.m4.xlarge | db.m4.2xlarge | db.m4.4xlarge | db.m4.10xlarge
        /// | db.r3.large | db.r3.xlarge | db.r3.2xlarge | db.r3.4xlarge | db.r3.8xlarge | db.t2.micro
        /// | db.t2.small | db.t2.medium | db.t2.large</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBInstanceClass { get; set; }
        #endregion
        
        #region Parameter DBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The DB instance identifier. This value is stored as a lowercase string.</para><para>Constraints:</para><ul><li><para>Must be the identifier for an existing DB instance</para></li><li><para>Must contain from 1 to 63 alphanumeric characters or hyphens</para></li><li><para>First character must be a letter</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter DBParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the DB parameter group to apply to the DB instance. Changing this setting
        /// does not result in an outage. The parameter group name itself is changed immediately,
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
        /// of the value of the <code>ApplyImmediately</code> parameter.</para><para><b>MySQL</b></para><para> Default: <code>3306</code></para><para> Valid Values: <code>1150-65535</code></para><para><b>MariaDB</b></para><para> Default: <code>3306</code></para><para> Valid Values: <code>1150-65535</code></para><para><b>PostgreSQL</b></para><para> Default: <code>5432</code></para><para> Valid Values: <code>1150-65535</code></para><para>Type: Integer</para><para><b>Oracle</b></para><para> Default: <code>1521</code></para><para> Valid Values: <code>1150-65535</code></para><para><b>SQL Server</b></para><para> Default: <code>1433</code></para><para> Valid Values: <code>1150-65535</code> except for <code>1434</code>, <code>3389</code>,
        /// <code>47001</code>, <code>49152</code>, and <code>49152</code> through <code>49156</code>.
        /// </para><para><b>Amazon Aurora</b></para><para> Default: <code>3306</code></para><para> Valid Values: <code>1150-65535</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 DBPortNumber { get; set; }
        #endregion
        
        #region Parameter DBSecurityGroup
        /// <summary>
        /// <para>
        /// <para>A list of DB security groups to authorize on this DB instance. Changing this setting
        /// does not result in an outage and the change is asynchronously applied as soon as possible.</para><para>Constraints:</para><ul><li><para>Must be 1 to 255 alphanumeric characters</para></li><li><para>First character must be a letter</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DBSecurityGroups")]
        public System.String[] DBSecurityGroup { get; set; }
        #endregion
        
        #region Parameter DBSubnetGroupName
        /// <summary>
        /// <para>
        /// <para>The new DB subnet group for the DB instance. You can use this parameter to move your
        /// DB instance to a different VPC. If your DB instance is not in a VPC, you can also
        /// use this parameter to move your DB instance into a VPC. For more information, see
        /// <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_VPC.WorkingWithRDSInstanceinaVPC.html#USER_VPC.Non-VPC2VPC">Updating
        /// the VPC for a DB Instance</a>. </para><para>Changing the subnet group causes an outage during the change. The change is applied
        /// during the next maintenance window, unless you specify <code>true</code> for the <code>ApplyImmediately</code>
        /// parameter. </para><para>Constraints: Must contain no more than 255 alphanumeric characters, periods, underscores,
        /// spaces, or hyphens.</para><para>Example: <code>mySubnetGroup</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBSubnetGroupName { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The Active Directory Domain to move the instance to. Specify <code>none</code> to
        /// remove the instance from its current domain. The domain must be created prior to this
        /// operation. Currently only a Microsoft SQL Server instance can be created in a Active
        /// Directory Domain. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter DomainIAMRoleName
        /// <summary>
        /// <para>
        /// <para>The name of the IAM role to use when making API calls to the Directory Service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DomainIAMRoleName { get; set; }
        #endregion
        
        #region Parameter EnableIAMDatabaseAuthentication
        /// <summary>
        /// <para>
        /// <para>True to enable mapping of AWS Identity and Access Management (IAM) accounts to database
        /// accounts; otherwise false.</para><para> You can enable IAM database authentication for the following database engines</para><ul><li><para>For MySQL 5.6, minor version 5.6.34 or higher</para></li><li><para>For MySQL 5.7, minor version 5.7.16 or higher</para></li></ul><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EnableIAMDatabaseAuthentication { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para> The version number of the database engine to upgrade to. Changing this parameter
        /// results in an outage and the change is applied during the next maintenance window
        /// unless the <code>ApplyImmediately</code> parameter is set to <code>true</code> for
        /// this request. </para><para>For major version upgrades, if a non-default DB parameter group is currently in use,
        /// a new DB parameter group in the DB parameter group family for the new engine version
        /// must be specified. The new DB parameter group can be the default for that DB parameter
        /// group family.</para><para>For a list of valid engine versions, see <a>CreateDBInstance</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter Iops
        /// <summary>
        /// <para>
        /// <para> The new Provisioned IOPS (I/O operations per second) value for the RDS instance.
        /// Changing this setting does not result in an outage and the change is applied during
        /// the next maintenance window unless the <code>ApplyImmediately</code> parameter is
        /// set to <code>true</code> for this request. </para><para>Default: Uses existing setting</para><para>Constraints: Value supplied must be at least 10% greater than the current value. Values
        /// that are not at least 10% greater than the existing value are rounded up so that they
        /// are 10% greater than the current value. If you are migrating from Provisioned IOPS
        /// to standard storage, set this value to 0. The DB instance will require a reboot for
        /// the change in storage type to take effect.</para><para><b>SQL Server</b></para><para>Setting the IOPS value for the SQL Server database engine is not supported.</para><para>Type: Integer</para><para>If you choose to migrate your DB instance from using standard storage to using Provisioned
        /// IOPS, or from using Provisioned IOPS to using standard storage, the process can take
        /// time. The duration of the migration depends on several factors such as database load,
        /// storage size, storage type (standard or Provisioned IOPS), amount of IOPS provisioned
        /// (if any), and the number of prior scale storage operations. Typical migration times
        /// are under 24 hours, but the process can take up to several days in some cases. During
        /// the migration, the DB instance will be available for use, but might experience performance
        /// degradation. While the migration takes place, nightly backups for the instance will
        /// be suspended. No other Amazon RDS operations can take place for the instance, including
        /// modifying the instance, rebooting the instance, deleting the instance, creating a
        /// Read Replica for the instance, and creating a DB snapshot of the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Iops { get; set; }
        #endregion
        
        #region Parameter LicenseModel
        /// <summary>
        /// <para>
        /// <para>The license model for the DB instance.</para><para>Valid values: <code>license-included</code> | <code>bring-your-own-license</code>
        /// | <code>general-public-license</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LicenseModel { get; set; }
        #endregion
        
        #region Parameter MasterUserPassword
        /// <summary>
        /// <para>
        /// <para>The new password for the DB instance master user. Can be any printable ASCII character
        /// except "/", """, or "@".</para><para> Changing this parameter does not result in an outage and the change is asynchronously
        /// applied as soon as possible. Between the time of the request and the completion of
        /// the request, the <code>MasterUserPassword</code> element exists in the <code>PendingModifiedValues</code>
        /// element of the operation response. </para><para>Default: Uses existing setting</para><para>Constraints: Must be 8 to 41 alphanumeric characters (MySQL, MariaDB, and Amazon Aurora),
        /// 8 to 30 alphanumeric characters (Oracle), or 8 to 128 alphanumeric characters (SQL
        /// Server).</para><note><para>Amazon RDS API actions never return the password, so this action provides a way to
        /// regain access to a primary instance user if the password is lost. This includes restoring
        /// privileges that might have been accidentally revoked.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public System.Int32 MonitoringInterval { get; set; }
        #endregion
        
        #region Parameter MonitoringRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN for the IAM role that permits RDS to send enhanced monitoring metrics to CloudWatch
        /// Logs. For example, <code>arn:aws:iam:123456789012:role/emaccess</code>. For information
        /// on creating a monitoring role, go to <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_Monitoring.html#USER_Monitoring.OS.IAMRole">To
        /// create an IAM role for Amazon RDS Enhanced Monitoring</a>.</para><para>If <code>MonitoringInterval</code> is set to a value other than 0, then you must supply
        /// a <code>MonitoringRoleArn</code> value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MonitoringRoleArn { get; set; }
        #endregion
        
        #region Parameter MultiAZ
        /// <summary>
        /// <para>
        /// <para> Specifies if the DB instance is a Multi-AZ deployment. Changing this parameter does
        /// not result in an outage and the change is applied during the next maintenance window
        /// unless the <code>ApplyImmediately</code> parameter is set to <code>true</code> for
        /// this request. </para><para>Constraints: Cannot be specified if the DB instance is a Read Replica.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean MultiAZ { get; set; }
        #endregion
        
        #region Parameter NewDBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para> The new DB instance identifier for the DB instance when renaming a DB instance. When
        /// you change the DB instance identifier, an instance reboot will occur immediately if
        /// you set <code>Apply Immediately</code> to true, or will occur during the next maintenance
        /// window if <code>Apply Immediately</code> to false. This value is stored as a lowercase
        /// string. </para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 alphanumeric characters or hyphens</para></li><li><para>First character must be a letter</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewDBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter OptionGroupName
        /// <summary>
        /// <para>
        /// <para> Indicates that the DB instance should be associated with the specified option group.
        /// Changing this parameter does not result in an outage except in the following case
        /// and the change is applied during the next maintenance window unless the <code>ApplyImmediately</code>
        /// parameter is set to <code>true</code> for this request. If the parameter change results
        /// in an option group that enables OEM, this change can cause a brief (sub-second) period
        /// during which new connections are rejected but existing connections are not interrupted.
        /// </para><para>Permanent options, such as the TDE option for Oracle Advanced Security TDE, cannot
        /// be removed from an option group, and that option group cannot be removed from a DB
        /// instance once it is associated with a DB instance</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OptionGroupName { get; set; }
        #endregion
        
        #region Parameter PreferredBackupWindow
        /// <summary>
        /// <para>
        /// <para> The daily time range during which automated backups are created if automated backups
        /// are enabled, as determined by the <code>BackupRetentionPeriod</code> parameter. Changing
        /// this parameter does not result in an outage and the change is asynchronously applied
        /// as soon as possible. </para><para>Constraints:</para><ul><li><para>Must be in the format hh24:mi-hh24:mi</para></li><li><para>Times should be in Universal Time Coordinated (UTC)</para></li><li><para>Must not conflict with the preferred maintenance window</para></li><li><para>Must be at least 30 minutes</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreferredBackupWindow { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>The weekly time range (in UTC) during which system maintenance can occur, which might
        /// result in an outage. Changing this parameter does not result in an outage, except
        /// in the following situation, and the change is asynchronously applied as soon as possible.
        /// If there are pending actions that cause a reboot, and the maintenance window is changed
        /// to include the current time, then changing this parameter will cause a reboot of the
        /// DB instance. If moving this window to the current time, there must be at least 30
        /// minutes between the current time and end of the window to ensure pending changes are
        /// applied.</para><para>Default: Uses existing setting</para><para>Format: ddd:hh24:mi-ddd:hh24:mi</para><para>Valid Days: Mon | Tue | Wed | Thu | Fri | Sat | Sun</para><para>Constraints: Must be at least 30 minutes</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter PromotionTier
        /// <summary>
        /// <para>
        /// <para>A value that specifies the order in which an Aurora Replica is promoted to the primary
        /// instance after a failure of the existing primary instance. For more information, see
        /// <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Aurora.Managing.html#Aurora.Managing.FaultTolerance">
        /// Fault Tolerance for an Aurora DB Cluster</a>. </para><para>Default: 1</para><para>Valid Values: 0 - 15</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 PromotionTier { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>Boolean value that indicates if the DB instance has a publicly resolvable DNS name.
        /// Set to <code>True</code> to make the DB instance Internet-facing with a publicly resolvable
        /// DNS name, which resolves to a public IP address. Set to <code>False</code> to make
        /// the DB instance internal with a DNS name that resolves to a private IP address. </para><para><code>PubliclyAccessible</code> only applies to DB instances in a VPC. The DB instance
        /// must be part of a public subnet and <code>PubliclyAccessible</code> must be true in
        /// order for it to be publicly accessible. </para><para>Changes to the <code>PubliclyAccessible</code> parameter are applied immediately regardless
        /// of the value of the <code>ApplyImmediately</code> parameter.</para><para>Default: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter StorageType
        /// <summary>
        /// <para>
        /// <para>Specifies the storage type to be associated with the DB instance.</para><para> Valid values: <code>standard | gp2 | io1</code></para><para> If you specify <code>io1</code>, you must also include a value for the <code>Iops</code>
        /// parameter. </para><para> Default: <code>io1</code> if the <code>Iops</code> parameter is specified; otherwise
        /// <code>standard</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StorageType { get; set; }
        #endregion
        
        #region Parameter TdeCredentialArn
        /// <summary>
        /// <para>
        /// <para>The ARN from the Key Store with which to associate the instance for TDE encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TdeCredentialArn { get; set; }
        #endregion
        
        #region Parameter TdeCredentialPassword
        /// <summary>
        /// <para>
        /// <para>The password for the given ARN from the Key Store in order to access the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TdeCredentialPassword { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of EC2 VPC security groups to authorize on this DB instance. This change is
        /// asynchronously applied as soon as possible.</para><para>Constraints:</para><ul><li><para>Must be 1 to 255 alphanumeric characters</para></li><li><para>First character must be a letter</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens</para></li></ul>
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DBInstanceIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSDBInstance (ModifyDBInstance)"))
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
            
            if (ParameterWasBound("AllocatedStorage"))
                context.AllocatedStorage = this.AllocatedStorage;
            if (ParameterWasBound("AllowMajorVersionUpgrade"))
                context.AllowMajorVersionUpgrade = this.AllowMajorVersionUpgrade;
            if (ParameterWasBound("ApplyImmediately"))
                context.ApplyImmediately = this.ApplyImmediately;
            if (ParameterWasBound("AutoMinorVersionUpgrade"))
                context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            if (ParameterWasBound("BackupRetentionPeriod"))
                context.BackupRetentionPeriod = this.BackupRetentionPeriod;
            context.CACertificateIdentifier = this.CACertificateIdentifier;
            if (ParameterWasBound("CopyTagsToSnapshot"))
                context.CopyTagsToSnapshot = this.CopyTagsToSnapshot;
            context.DBInstanceClass = this.DBInstanceClass;
            context.DBInstanceIdentifier = this.DBInstanceIdentifier;
            context.DBParameterGroupName = this.DBParameterGroupName;
            if (ParameterWasBound("DBPortNumber"))
                context.DBPortNumber = this.DBPortNumber;
            if (this.DBSecurityGroup != null)
            {
                context.DBSecurityGroups = new List<System.String>(this.DBSecurityGroup);
            }
            context.DBSubnetGroupName = this.DBSubnetGroupName;
            context.Domain = this.Domain;
            context.DomainIAMRoleName = this.DomainIAMRoleName;
            if (ParameterWasBound("EnableIAMDatabaseAuthentication"))
                context.EnableIAMDatabaseAuthentication = this.EnableIAMDatabaseAuthentication;
            context.EngineVersion = this.EngineVersion;
            if (ParameterWasBound("Iops"))
                context.Iops = this.Iops;
            context.LicenseModel = this.LicenseModel;
            context.MasterUserPassword = this.MasterUserPassword;
            if (ParameterWasBound("MonitoringInterval"))
                context.MonitoringInterval = this.MonitoringInterval;
            context.MonitoringRoleArn = this.MonitoringRoleArn;
            if (ParameterWasBound("MultiAZ"))
                context.MultiAZ = this.MultiAZ;
            context.NewDBInstanceIdentifier = this.NewDBInstanceIdentifier;
            context.OptionGroupName = this.OptionGroupName;
            context.PreferredBackupWindow = this.PreferredBackupWindow;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            if (ParameterWasBound("PromotionTier"))
                context.PromotionTier = this.PromotionTier;
            if (ParameterWasBound("PubliclyAccessible"))
                context.PubliclyAccessible = this.PubliclyAccessible;
            context.StorageType = this.StorageType;
            context.TdeCredentialArn = this.TdeCredentialArn;
            context.TdeCredentialPassword = this.TdeCredentialPassword;
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
            if (cmdletContext.DBSecurityGroups != null)
            {
                request.DBSecurityGroups = cmdletContext.DBSecurityGroups;
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
            if (cmdletContext.PubliclyAccessible != null)
            {
                request.PubliclyAccessible = cmdletContext.PubliclyAccessible.Value;
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
                object pipelineOutput = response.DBInstance;
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
        
        private Amazon.RDS.Model.ModifyDBInstanceResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ModifyDBInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ModifyDBInstance");
            #if DESKTOP
            return client.ModifyDBInstance(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ModifyDBInstanceAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.Int32? AllocatedStorage { get; set; }
            public System.Boolean? AllowMajorVersionUpgrade { get; set; }
            public System.Boolean? ApplyImmediately { get; set; }
            public System.Boolean? AutoMinorVersionUpgrade { get; set; }
            public System.Int32? BackupRetentionPeriod { get; set; }
            public System.String CACertificateIdentifier { get; set; }
            public System.Boolean? CopyTagsToSnapshot { get; set; }
            public System.String DBInstanceClass { get; set; }
            public System.String DBInstanceIdentifier { get; set; }
            public System.String DBParameterGroupName { get; set; }
            public System.Int32? DBPortNumber { get; set; }
            public List<System.String> DBSecurityGroups { get; set; }
            public System.String DBSubnetGroupName { get; set; }
            public System.String Domain { get; set; }
            public System.String DomainIAMRoleName { get; set; }
            public System.Boolean? EnableIAMDatabaseAuthentication { get; set; }
            public System.String EngineVersion { get; set; }
            public System.Int32? Iops { get; set; }
            public System.String LicenseModel { get; set; }
            public System.String MasterUserPassword { get; set; }
            public System.Int32? MonitoringInterval { get; set; }
            public System.String MonitoringRoleArn { get; set; }
            public System.Boolean? MultiAZ { get; set; }
            public System.String NewDBInstanceIdentifier { get; set; }
            public System.String OptionGroupName { get; set; }
            public System.String PreferredBackupWindow { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.Int32? PromotionTier { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public System.String StorageType { get; set; }
            public System.String TdeCredentialArn { get; set; }
            public System.String TdeCredentialPassword { get; set; }
            public List<System.String> VpcSecurityGroupIds { get; set; }
        }
        
    }
}
