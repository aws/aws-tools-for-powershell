/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Restores a DB instance to an arbitrary point in time. You can restore to any point
    /// in time before the time identified by the LatestRestorableTime property. You can restore
    /// to a point up to the number of days specified by the BackupRetentionPeriod property.
    /// 
    ///  
    /// <para>
    /// The target database is created with most of the original configuration, but in a system-selected
    /// Availability Zone, with the default security group, the default subnet group, and
    /// the default DB parameter group. By default, the new DB instance is created as a single-AZ
    /// deployment except when the instance is a SQL Server instance that has an option group
    /// that is associated with mirroring; in this case, the instance becomes a mirrored deployment
    /// and not a single-AZ deployment.
    /// </para><note><para>
    /// This command doesn't apply to Aurora MySQL and Aurora PostgreSQL. For Aurora, use
    /// <a>RestoreDBClusterToPointInTime</a>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Restore", "RDSDBInstanceToPointInTime", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBInstance")]
    [AWSCmdlet("Calls the Amazon Relational Database Service RestoreDBInstanceToPointInTime API operation.", Operation = new[] {"RestoreDBInstanceToPointInTime"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBInstance",
        "This cmdlet returns a DBInstance object.",
        "The service call response (type Amazon.RDS.Model.RestoreDBInstanceToPointInTimeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RestoreRDSDBInstanceToPointInTimeCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter AutoMinorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>Indicates that minor version upgrades are applied automatically to the DB instance
        /// during the maintenance window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AutoMinorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The EC2 Availability Zone that the DB instance is created in.</para><para>Default: A random, system-chosen Availability Zone.</para><para>Constraint: You can't specify the AvailabilityZone parameter if the MultiAZ parameter
        /// is set to true.</para><para>Example: <code>us-east-1a</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter CopyTagsToSnapshot
        /// <summary>
        /// <para>
        /// <para>True to copy all tags from the restored DB instance to snapshots of the DB instance,
        /// and otherwise false. The default is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean CopyTagsToSnapshot { get; set; }
        #endregion
        
        #region Parameter DBInstanceClass
        /// <summary>
        /// <para>
        /// <para>The compute and memory capacity of the Amazon RDS DB instance, for example, <code>db.m4.large</code>.
        /// Not all DB instance classes are available in all AWS Regions, or for all database
        /// engines. For the full list of DB instance classes, and availability for your engine,
        /// see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Concepts.DBInstanceClass.html">DB
        /// Instance Class</a> in the <i>Amazon RDS User Guide.</i></para><para>Default: The same DBInstanceClass as the original DB instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBInstanceClass { get; set; }
        #endregion
        
        #region Parameter DBName
        /// <summary>
        /// <para>
        /// <para>The database name for the restored DB instance.</para><note><para>This parameter is not used for the MySQL or MariaDB engines.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DBName { get; set; }
        #endregion
        
        #region Parameter DBParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the DB parameter group to associate with this DB instance. If this argument
        /// is omitted, the default DBParameterGroup for the specified engine is used.</para><para>Constraints:</para><ul><li><para>If supplied, must match the name of an existing DBParameterGroup.</para></li><li><para>Must be 1 to 255 letters, numbers, or hyphens.</para></li><li><para>First character must be a letter.</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBParameterGroupName { get; set; }
        #endregion
        
        #region Parameter DBSubnetGroupName
        /// <summary>
        /// <para>
        /// <para>The DB subnet group name to use for the new instance.</para><para>Constraints: If supplied, must match the name of an existing DBSubnetGroup.</para><para>Example: <code>mySubnetgroup</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBSubnetGroupName { get; set; }
        #endregion
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para>Indicates if the DB instance should have deletion protection enabled. The database
        /// can't be deleted when this value is set to true. The default is false. For more information,
        /// see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_DeleteInstance.html">
        /// Deleting a DB Instance</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean DeletionProtection { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>Specify the Active Directory Domain to restore the instance in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter DomainIAMRoleName
        /// <summary>
        /// <para>
        /// <para>Specify the name of the IAM role to be used when making API calls to the Directory
        /// Service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DomainIAMRoleName { get; set; }
        #endregion
        
        #region Parameter EnableCloudwatchLogsExport
        /// <summary>
        /// <para>
        /// <para>The list of logs that the restored DB instance is to export to CloudWatch Logs. The
        /// values in the list depend on the DB engine being used. For more information, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_LogAccess.html#USER_LogAccess.Procedural.UploadtoCloudWatch">Publishing
        /// Database Logs to Amazon CloudWatch Logs</a> in the <i>Amazon RDS User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EnableCloudwatchLogsExports")]
        public System.String[] EnableCloudwatchLogsExport { get; set; }
        #endregion
        
        #region Parameter EnableIAMDatabaseAuthentication
        /// <summary>
        /// <para>
        /// <para>True to enable mapping of AWS Identity and Access Management (IAM) accounts to database
        /// accounts, and otherwise false.</para><para>You can enable IAM database authentication for the following database engines</para><ul><li><para>For MySQL 5.6, minor version 5.6.34 or higher</para></li><li><para>For MySQL 5.7, minor version 5.7.16 or higher</para></li></ul><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EnableIAMDatabaseAuthentication { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The database engine to use for the new instance.</para><para>Default: The same as source</para><para>Constraint: Must be compatible with the engine of the source</para><para>Valid Values:</para><ul><li><para><code>mariadb</code></para></li><li><para><code>mysql</code></para></li><li><para><code>oracle-ee</code></para></li><li><para><code>oracle-se2</code></para></li><li><para><code>oracle-se1</code></para></li><li><para><code>oracle-se</code></para></li><li><para><code>postgres</code></para></li><li><para><code>sqlserver-ee</code></para></li><li><para><code>sqlserver-se</code></para></li><li><para><code>sqlserver-ex</code></para></li><li><para><code>sqlserver-web</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter Iops
        /// <summary>
        /// <para>
        /// <para>The amount of Provisioned IOPS (input/output operations per second) to be initially
        /// allocated for the DB instance.</para><para>Constraints: Must be an integer greater than 1000.</para><para><b>SQL Server</b></para><para>Setting the IOPS value for the SQL Server database engine is not supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Iops { get; set; }
        #endregion
        
        #region Parameter LicenseModel
        /// <summary>
        /// <para>
        /// <para>License model information for the restored DB instance.</para><para>Default: Same as source.</para><para> Valid values: <code>license-included</code> | <code>bring-your-own-license</code>
        /// | <code>general-public-license</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LicenseModel { get; set; }
        #endregion
        
        #region Parameter MultiAZ
        /// <summary>
        /// <para>
        /// <para>Specifies if the DB instance is a Multi-AZ deployment.</para><para>Constraint: You can't specify the AvailabilityZone parameter if the MultiAZ parameter
        /// is set to <code>true</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean MultiAZ { get; set; }
        #endregion
        
        #region Parameter OptionGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the option group to be used for the restored DB instance.</para><para>Permanent options, such as the TDE option for Oracle Advanced Security TDE, can't
        /// be removed from an option group, and that option group can't be removed from a DB
        /// instance once it is associated with a DB instance</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OptionGroupName { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port number on which the database accepts connections.</para><para>Constraints: Value must be <code>1150-65535</code></para><para>Default: The same port as the original DB instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Port { get; set; }
        #endregion
        
        #region Parameter ProcessorFeature
        /// <summary>
        /// <para>
        /// <para>The number of CPU cores and the number of threads per core for the DB instance class
        /// of the DB instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ProcessorFeatures")]
        public Amazon.RDS.Model.ProcessorFeature[] ProcessorFeature { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>Specifies the accessibility options for the DB instance. A value of true specifies
        /// an Internet-facing instance with a publicly resolvable DNS name, which resolves to
        /// a public IP address. A value of false specifies an internal instance with a DNS name
        /// that resolves to a private IP address. For more information, see <a>CreateDBInstance</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter RestoreTime
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use RestoreTimeUtc instead. Setting either RestoreTime
        /// or RestoreTimeUtc results in both RestoreTime and RestoreTimeUtc being assigned, the
        /// latest assignment to either one of the two property is reflected in the value of both.
        /// RestoreTime is provided for backwards compatibility only and assigning a non-Utc DateTime
        /// to it results in the wrong timestamp being passed to the service.</para><para>The date and time to restore from.</para><para>Valid Values: Value must be a time in Universal Coordinated Time (UTC) format</para><para>Constraints:</para><ul><li><para>Must be before the latest restorable time for the DB instance</para></li><li><para>Can't be specified if UseLatestRestorableTime parameter is true</para></li></ul><para>Example: <code>2009-09-07T23:45:00Z</code></para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed t" +
            "o the service, use UtcRestoreTime instead.")]
        public System.DateTime RestoreTime { get; set; }
        #endregion
        
        #region Parameter UtcRestoreTime
        /// <summary>
        /// <para>
        /// <para>The date and time to restore from.</para><para>Valid Values: Value must be a time in Universal Coordinated Time (UTC) format</para><para>Constraints:</para><ul><li><para>Must be before the latest restorable time for the DB instance</para></li><li><para>Can't be specified if UseLatestRestorableTime parameter is true</para></li></ul><para>Example: <code>2009-09-07T23:45:00Z</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime UtcRestoreTime { get; set; }
        #endregion
        
        #region Parameter SourceDBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the source DB instance from which to restore.</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing DB instance.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SourceDBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter StorageType
        /// <summary>
        /// <para>
        /// <para>Specifies the storage type to be associated with the DB instance.</para><para> Valid values: <code>standard | gp2 | io1</code></para><para> If you specify <code>io1</code>, you must also include a value for the <code>Iops</code>
        /// parameter. </para><para> Default: <code>io1</code> if the <code>Iops</code> parameter is specified, otherwise
        /// <code>standard</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StorageType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetDBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The name of the new DB instance to be created.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 letters, numbers, or hyphens</para></li><li><para>First character must be a letter</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String TargetDBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter TdeCredentialArn
        /// <summary>
        /// <para>
        /// <para>The ARN from the key store with which to associate the instance for TDE encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TdeCredentialArn { get; set; }
        #endregion
        
        #region Parameter TdeCredentialPassword
        /// <summary>
        /// <para>
        /// <para>The password for the given ARN from the key store in order to access the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TdeCredentialPassword { get; set; }
        #endregion
        
        #region Parameter UseDefaultProcessorFeature
        /// <summary>
        /// <para>
        /// <para>A value that specifies that the DB instance class of the DB instance uses its default
        /// processor features.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UseDefaultProcessorFeatures")]
        public System.Boolean UseDefaultProcessorFeature { get; set; }
        #endregion
        
        #region Parameter UseLatestRestorableTime
        /// <summary>
        /// <para>
        /// <para> Specifies whether (<code>true</code>) or not (<code>false</code>) the DB instance
        /// is restored from the latest backup time. </para><para>Default: <code>false</code></para><para>Constraints: Can't be specified if RestoreTime parameter is provided.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean UseLatestRestorableTime { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SourceDBInstanceIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-RDSDBInstanceToPointInTime (RestoreDBInstanceToPointInTime)"))
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
            
            if (ParameterWasBound("AutoMinorVersionUpgrade"))
                context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            context.AvailabilityZone = this.AvailabilityZone;
            if (ParameterWasBound("CopyTagsToSnapshot"))
                context.CopyTagsToSnapshot = this.CopyTagsToSnapshot;
            context.DBInstanceClass = this.DBInstanceClass;
            context.DBName = this.DBName;
            context.DBParameterGroupName = this.DBParameterGroupName;
            context.DBSubnetGroupName = this.DBSubnetGroupName;
            if (ParameterWasBound("DeletionProtection"))
                context.DeletionProtection = this.DeletionProtection;
            context.Domain = this.Domain;
            context.DomainIAMRoleName = this.DomainIAMRoleName;
            if (this.EnableCloudwatchLogsExport != null)
            {
                context.EnableCloudwatchLogsExports = new List<System.String>(this.EnableCloudwatchLogsExport);
            }
            if (ParameterWasBound("EnableIAMDatabaseAuthentication"))
                context.EnableIAMDatabaseAuthentication = this.EnableIAMDatabaseAuthentication;
            context.Engine = this.Engine;
            if (ParameterWasBound("Iops"))
                context.Iops = this.Iops;
            context.LicenseModel = this.LicenseModel;
            if (ParameterWasBound("MultiAZ"))
                context.MultiAZ = this.MultiAZ;
            context.OptionGroupName = this.OptionGroupName;
            if (ParameterWasBound("Port"))
                context.Port = this.Port;
            if (this.ProcessorFeature != null)
            {
                context.ProcessorFeatures = new List<Amazon.RDS.Model.ProcessorFeature>(this.ProcessorFeature);
            }
            if (ParameterWasBound("PubliclyAccessible"))
                context.PubliclyAccessible = this.PubliclyAccessible;
            if (ParameterWasBound("UtcRestoreTime"))
                context.UtcRestoreTime = this.UtcRestoreTime;
            context.SourceDBInstanceIdentifier = this.SourceDBInstanceIdentifier;
            context.StorageType = this.StorageType;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
            context.TargetDBInstanceIdentifier = this.TargetDBInstanceIdentifier;
            context.TdeCredentialArn = this.TdeCredentialArn;
            context.TdeCredentialPassword = this.TdeCredentialPassword;
            if (ParameterWasBound("UseDefaultProcessorFeature"))
                context.UseDefaultProcessorFeatures = this.UseDefaultProcessorFeature;
            if (ParameterWasBound("UseLatestRestorableTime"))
                context.UseLatestRestorableTime = this.UseLatestRestorableTime;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound("RestoreTime"))
                context.RestoreTime = this.RestoreTime;
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
            var request = new Amazon.RDS.Model.RestoreDBInstanceToPointInTimeRequest();
            
            if (cmdletContext.AutoMinorVersionUpgrade != null)
            {
                request.AutoMinorVersionUpgrade = cmdletContext.AutoMinorVersionUpgrade.Value;
            }
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.CopyTagsToSnapshot != null)
            {
                request.CopyTagsToSnapshot = cmdletContext.CopyTagsToSnapshot.Value;
            }
            if (cmdletContext.DBInstanceClass != null)
            {
                request.DBInstanceClass = cmdletContext.DBInstanceClass;
            }
            if (cmdletContext.DBName != null)
            {
                request.DBName = cmdletContext.DBName;
            }
            if (cmdletContext.DBParameterGroupName != null)
            {
                request.DBParameterGroupName = cmdletContext.DBParameterGroupName;
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
            if (cmdletContext.EnableCloudwatchLogsExports != null)
            {
                request.EnableCloudwatchLogsExports = cmdletContext.EnableCloudwatchLogsExports;
            }
            if (cmdletContext.EnableIAMDatabaseAuthentication != null)
            {
                request.EnableIAMDatabaseAuthentication = cmdletContext.EnableIAMDatabaseAuthentication.Value;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
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
            if (cmdletContext.OptionGroupName != null)
            {
                request.OptionGroupName = cmdletContext.OptionGroupName;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.ProcessorFeatures != null)
            {
                request.ProcessorFeatures = cmdletContext.ProcessorFeatures;
            }
            if (cmdletContext.PubliclyAccessible != null)
            {
                request.PubliclyAccessible = cmdletContext.PubliclyAccessible.Value;
            }
            if (cmdletContext.UtcRestoreTime != null)
            {
                request.RestoreTimeUtc = cmdletContext.UtcRestoreTime.Value;
            }
            if (cmdletContext.SourceDBInstanceIdentifier != null)
            {
                request.SourceDBInstanceIdentifier = cmdletContext.SourceDBInstanceIdentifier;
            }
            if (cmdletContext.StorageType != null)
            {
                request.StorageType = cmdletContext.StorageType;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.TargetDBInstanceIdentifier != null)
            {
                request.TargetDBInstanceIdentifier = cmdletContext.TargetDBInstanceIdentifier;
            }
            if (cmdletContext.TdeCredentialArn != null)
            {
                request.TdeCredentialArn = cmdletContext.TdeCredentialArn;
            }
            if (cmdletContext.TdeCredentialPassword != null)
            {
                request.TdeCredentialPassword = cmdletContext.TdeCredentialPassword;
            }
            if (cmdletContext.UseDefaultProcessorFeatures != null)
            {
                request.UseDefaultProcessorFeatures = cmdletContext.UseDefaultProcessorFeatures.Value;
            }
            if (cmdletContext.UseLatestRestorableTime != null)
            {
                request.UseLatestRestorableTime = cmdletContext.UseLatestRestorableTime.Value;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.RestoreTime != null)
            {
                if (cmdletContext.UtcRestoreTime != null)
                {
                    throw new ArgumentException("Parameters RestoreTime and UtcRestoreTime are mutually exclusive.");
                }
                request.RestoreTime = cmdletContext.RestoreTime.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
        
        private Amazon.RDS.Model.RestoreDBInstanceToPointInTimeResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.RestoreDBInstanceToPointInTimeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "RestoreDBInstanceToPointInTime");
            try
            {
                #if DESKTOP
                return client.RestoreDBInstanceToPointInTime(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RestoreDBInstanceToPointInTimeAsync(request);
                return task.Result;
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
            public System.Boolean? AutoMinorVersionUpgrade { get; set; }
            public System.String AvailabilityZone { get; set; }
            public System.Boolean? CopyTagsToSnapshot { get; set; }
            public System.String DBInstanceClass { get; set; }
            public System.String DBName { get; set; }
            public System.String DBParameterGroupName { get; set; }
            public System.String DBSubnetGroupName { get; set; }
            public System.Boolean? DeletionProtection { get; set; }
            public System.String Domain { get; set; }
            public System.String DomainIAMRoleName { get; set; }
            public List<System.String> EnableCloudwatchLogsExports { get; set; }
            public System.Boolean? EnableIAMDatabaseAuthentication { get; set; }
            public System.String Engine { get; set; }
            public System.Int32? Iops { get; set; }
            public System.String LicenseModel { get; set; }
            public System.Boolean? MultiAZ { get; set; }
            public System.String OptionGroupName { get; set; }
            public System.Int32? Port { get; set; }
            public List<Amazon.RDS.Model.ProcessorFeature> ProcessorFeatures { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public System.DateTime? UtcRestoreTime { get; set; }
            public System.String SourceDBInstanceIdentifier { get; set; }
            public System.String StorageType { get; set; }
            public List<Amazon.RDS.Model.Tag> Tags { get; set; }
            public System.String TargetDBInstanceIdentifier { get; set; }
            public System.String TdeCredentialArn { get; set; }
            public System.String TdeCredentialPassword { get; set; }
            public System.Boolean? UseDefaultProcessorFeatures { get; set; }
            public System.Boolean? UseLatestRestorableTime { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? RestoreTime { get; set; }
        }
        
    }
}
