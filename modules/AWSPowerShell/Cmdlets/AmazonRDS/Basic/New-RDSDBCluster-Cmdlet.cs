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
    /// Creates a new Amazon Aurora DB cluster.
    /// 
    ///  
    /// <para>
    /// You can use the <code>ReplicationSourceIdentifier</code> parameter to create the DB
    /// cluster as a Read Replica of another DB cluster or Amazon RDS MySQL DB instance. For
    /// cross-region replication where the DB cluster identified by <code>ReplicationSourceIdentifier</code>
    /// is encrypted, you must also specify the <code>PreSignedUrl</code> parameter.
    /// </para><para>
    /// For more information on Amazon Aurora, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/CHAP_AuroraOverview.html">
    /// What Is Amazon Aurora?</a> in the <i>Amazon Aurora User Guide.</i></para>
    /// </summary>
    [Cmdlet("New", "RDSDBCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBCluster")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CreateDBCluster API operation.", Operation = new[] {"CreateDBCluster"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBCluster",
        "This cmdlet returns a DBCluster object.",
        "The service call response (type Amazon.RDS.Model.CreateDBClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewRDSDBClusterCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter ScalingConfiguration_AutoPause
        /// <summary>
        /// <para>
        /// <para>A value that specifies whether to allow or disallow automatic pause for an Aurora
        /// DB cluster in <code>serverless</code> DB engine mode. A DB cluster can be paused only
        /// when it's idle (it has no connections).</para><note><para>If a DB cluster is paused for more than seven days, the DB cluster might be backed
        /// up with a snapshot. In this case, the DB cluster is restored when there is a request
        /// to connect to it. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ScalingConfiguration_AutoPause { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>A list of EC2 Availability Zones that instances in the DB cluster can be created in.
        /// For information on AWS Regions and Availability Zones, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/Concepts.RegionsAndAvailabilityZones.html">Choosing
        /// the Regions and Availability Zones</a> in the <i>Amazon Aurora User Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AvailabilityZones")]
        public System.String[] AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter BacktrackWindow
        /// <summary>
        /// <para>
        /// <para>The target backtrack window, in seconds. To disable backtracking, set this value to
        /// 0. </para><para>Default: 0</para><para>Constraints:</para><ul><li><para>If specified, this value must be set to a number from 0 to 259,200 (72 hours).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 BacktrackWindow { get; set; }
        #endregion
        
        #region Parameter BackupRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days for which automated backups are retained. You must specify a minimum
        /// value of 1.</para><para>Default: 1</para><para>Constraints:</para><ul><li><para>Must be a value from 1 to 35</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 BackupRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter CharacterSetName
        /// <summary>
        /// <para>
        /// <para>A value that indicates that the DB cluster should be associated with the specified
        /// CharacterSet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CharacterSetName { get; set; }
        #endregion
        
        #region Parameter DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name for your database of up to 64 alpha-numeric characters. If you do not provide
        /// a name, Amazon RDS will not create a database in the DB cluster you are creating.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DatabaseName { get; set; }
        #endregion
        
        #region Parameter DBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The DB cluster identifier. This parameter is stored as a lowercase string.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 letters, numbers, or hyphens.</para></li><li><para>First character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li></ul><para>Example: <code>my-cluster1</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DBClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter DBClusterParameterGroupName
        /// <summary>
        /// <para>
        /// <para> The name of the DB cluster parameter group to associate with this DB cluster. If
        /// this argument is omitted, <code>default.aurora5.6</code> is used. </para><para>Constraints:</para><ul><li><para>If supplied, must match the name of an existing DBClusterParameterGroup.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DBClusterParameterGroupName { get; set; }
        #endregion
        
        #region Parameter DBSubnetGroupName
        /// <summary>
        /// <para>
        /// <para>A DB subnet group to associate with this DB cluster.</para><para>Constraints: Must match the name of an existing DBSubnetGroup. Must not be default.</para><para>Example: <code>mySubnetgroup</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBSubnetGroupName { get; set; }
        #endregion
        
        #region Parameter EnableCloudwatchLogsExport
        /// <summary>
        /// <para>
        /// <para>The list of log types that need to be enabled for exporting to CloudWatch Logs. The
        /// values in the list depend on the DB engine being used. For more information, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/USER_LogAccess.html#USER_LogAccess.Procedural.UploadtoCloudWatch">Publishing
        /// Database Logs to Amazon CloudWatch Logs</a> in the <i>Amazon Aurora User Guide</i>.</para>
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
        /// accounts, and otherwise false.</para><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EnableIAMDatabaseAuthentication { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The name of the database engine to be used for this DB cluster.</para><para>Valid Values: <code>aurora</code> (for MySQL 5.6-compatible Aurora), <code>aurora-mysql</code>
        /// (for MySQL 5.7-compatible Aurora), and <code>aurora-postgresql</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter EngineMode
        /// <summary>
        /// <para>
        /// <para>The DB engine mode of the DB cluster, either <code>provisioned</code>, <code>serverless</code>,
        /// or <code>parallelquery</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EngineMode { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The version number of the database engine to use.</para><para><b>Aurora MySQL</b></para><para>Example: <code>5.6.10a</code>, <code>5.7.12</code></para><para><b>Aurora PostgreSQL</b></para><para>Example: <code>9.6.3</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The AWS KMS key identifier for an encrypted DB cluster.</para><para>The KMS key identifier is the Amazon Resource Name (ARN) for the KMS encryption key.
        /// If you are creating a DB cluster with the same AWS account that owns the KMS encryption
        /// key used to encrypt the new DB cluster, then you can use the KMS key alias instead
        /// of the ARN for the KMS encryption key.</para><para>If an encryption key is not specified in <code>KmsKeyId</code>:</para><ul><li><para>If <code>ReplicationSourceIdentifier</code> identifies an encrypted source, then Amazon
        /// RDS will use the encryption key used to encrypt the source. Otherwise, Amazon RDS
        /// will use your default encryption key. </para></li><li><para>If the <code>StorageEncrypted</code> parameter is true and <code>ReplicationSourceIdentifier</code>
        /// is not specified, then Amazon RDS will use your default encryption key.</para></li></ul><para>AWS KMS creates the default encryption key for your AWS account. Your AWS account
        /// has a different default encryption key for each AWS Region.</para><para>If you create a Read Replica of an encrypted DB cluster in another AWS Region, you
        /// must set <code>KmsKeyId</code> to a KMS key ID that is valid in the destination AWS
        /// Region. This key is used to encrypt the Read Replica in that AWS Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter MasterUsername
        /// <summary>
        /// <para>
        /// <para>The name of the master user for the DB cluster.</para><para>Constraints:</para><ul><li><para>Must be 1 to 16 letters or numbers.</para></li><li><para>First character must be a letter.</para></li><li><para>Cannot be a reserved word for the chosen database engine.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MasterUsername { get; set; }
        #endregion
        
        #region Parameter MasterUserPassword
        /// <summary>
        /// <para>
        /// <para>The password for the master database user. This password can contain any printable
        /// ASCII character except "/", """, or "@".</para><para>Constraints: Must contain from 8 to 41 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MasterUserPassword { get; set; }
        #endregion
        
        #region Parameter ScalingConfiguration_MaxCapacity
        /// <summary>
        /// <para>
        /// <para>The maximum capacity for an Aurora DB cluster in <code>serverless</code> DB engine
        /// mode.</para><para>Valid capacity values are <code>2</code>, <code>4</code>, <code>8</code>, <code>16</code>,
        /// <code>32</code>, <code>64</code>, <code>128</code>, and <code>256</code>.</para><para>The maximum capacity must be greater than or equal to the minimum capacity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ScalingConfiguration_MaxCapacity { get; set; }
        #endregion
        
        #region Parameter ScalingConfiguration_MinCapacity
        /// <summary>
        /// <para>
        /// <para>The minimum capacity for an Aurora DB cluster in <code>serverless</code> DB engine
        /// mode.</para><para>Valid capacity values are <code>2</code>, <code>4</code>, <code>8</code>, <code>16</code>,
        /// <code>32</code>, <code>64</code>, <code>128</code>, and <code>256</code>.</para><para>The minimum capacity must be less than or equal to the maximum capacity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ScalingConfiguration_MinCapacity { get; set; }
        #endregion
        
        #region Parameter OptionGroupName
        /// <summary>
        /// <para>
        /// <para>A value that indicates that the DB cluster should be associated with the specified
        /// option group.</para><para>Permanent options can't be removed from an option group. The option group can't be
        /// removed from a DB cluster once it is associated with a DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OptionGroupName { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port number on which the instances in the DB cluster accept connections.</para><para> Default: <code>3306</code> if engine is set as aurora or <code>5432</code> if set
        /// to aurora-postgresql. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Port { get; set; }
        #endregion
        
        #region Parameter PreferredBackupWindow
        /// <summary>
        /// <para>
        /// <para>The daily time range during which automated backups are created if automated backups
        /// are enabled using the <code>BackupRetentionPeriod</code> parameter. </para><para>The default is a 30-minute window selected at random from an 8-hour block of time
        /// for each AWS Region. To see the time blocks available, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/USER_UpgradeDBInstance.Maintenance.html#AdjustingTheMaintenanceWindow.Aurora">
        /// Adjusting the Preferred DB Cluster Maintenance Window</a> in the <i>Amazon Aurora
        /// User Guide.</i></para><para>Constraints:</para><ul><li><para>Must be in the format <code>hh24:mi-hh24:mi</code>.</para></li><li><para>Must be in Universal Coordinated Time (UTC).</para></li><li><para>Must not conflict with the preferred maintenance window.</para></li><li><para>Must be at least 30 minutes.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreferredBackupWindow { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>The weekly time range during which system maintenance can occur, in Universal Coordinated
        /// Time (UTC).</para><para>Format: <code>ddd:hh24:mi-ddd:hh24:mi</code></para><para>The default is a 30-minute window selected at random from an 8-hour block of time
        /// for each AWS Region, occurring on a random day of the week. To see the time blocks
        /// available, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/USER_UpgradeDBInstance.Maintenance.html#AdjustingTheMaintenanceWindow.Aurora">
        /// Adjusting the Preferred DB Cluster Maintenance Window</a> in the <i>Amazon Aurora
        /// User Guide.</i></para><para>Valid Days: Mon, Tue, Wed, Thu, Fri, Sat, Sun.</para><para>Constraints: Minimum 30-minute window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter PreSignedUrl
        /// <summary>
        /// <para>
        /// <para>A URL that contains a Signature Version 4 signed request for the <code>CreateDBCluster</code>
        /// action to be called in the source AWS Region where the DB cluster is replicated from.
        /// You only need to specify <code>PreSignedUrl</code> when you are performing cross-region
        /// replication from an encrypted DB cluster.</para><para>The pre-signed URL must be a valid request for the <code>CreateDBCluster</code> API
        /// action that can be executed in the source AWS Region that contains the encrypted DB
        /// cluster to be copied.</para><para>The pre-signed URL request must contain the following parameter values:</para><ul><li><para><code>KmsKeyId</code> - The AWS KMS key identifier for the key to use to encrypt
        /// the copy of the DB cluster in the destination AWS Region. This should refer to the
        /// same KMS key for both the <code>CreateDBCluster</code> action that is called in the
        /// destination AWS Region, and the action contained in the pre-signed URL.</para></li><li><para><code>DestinationRegion</code> - The name of the AWS Region that Aurora Read Replica
        /// will be created in.</para></li><li><para><code>ReplicationSourceIdentifier</code> - The DB cluster identifier for the encrypted
        /// DB cluster to be copied. This identifier must be in the Amazon Resource Name (ARN)
        /// format for the source AWS Region. For example, if you are copying an encrypted DB
        /// cluster from the us-west-2 AWS Region, then your <code>ReplicationSourceIdentifier</code>
        /// would look like Example: <code>arn:aws:rds:us-west-2:123456789012:cluster:aurora-cluster1</code>.</para></li></ul><para>To learn how to generate a Signature Version 4 signed request, see <a href="http://docs.aws.amazon.com/AmazonS3/latest/API/sigv4-query-string-auth.html">
        /// Authenticating Requests: Using Query Parameters (AWS Signature Version 4)</a> and
        /// <a href="http://docs.aws.amazon.com/general/latest/gr/signature-version-4.html"> Signature
        /// Version 4 Signing Process</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreSignedUrl { get; set; }
        #endregion
        
        #region Parameter ReplicationSourceIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the source DB instance or DB cluster if this DB
        /// cluster is created as a Read Replica.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ReplicationSourceIdentifier { get; set; }
        #endregion
        
        #region Parameter ScalingConfiguration_SecondsUntilAutoPause
        /// <summary>
        /// <para>
        /// <para>The time, in seconds, before an Aurora DB cluster in <code>serverless</code> mode
        /// is paused.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ScalingConfiguration_SecondsUntilAutoPause { get; set; }
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
        [System.Management.Automation.Parameter]
        public System.String SourceRegion { get; set; }
        #endregion
        
        #region Parameter StorageEncrypted
        /// <summary>
        /// <para>
        /// <para>Specifies whether the DB cluster is encrypted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean StorageEncrypted { get; set; }
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
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of EC2 VPC security groups to associate with this DB cluster.</para>
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DBClusterIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RDSDBCluster (CreateDBCluster)"))
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
            
            context.SourceRegion = this.SourceRegion;
            if (this.AvailabilityZone != null)
            {
                context.AvailabilityZones = new List<System.String>(this.AvailabilityZone);
            }
            if (ParameterWasBound("BacktrackWindow"))
                context.BacktrackWindow = this.BacktrackWindow;
            if (ParameterWasBound("BackupRetentionPeriod"))
                context.BackupRetentionPeriod = this.BackupRetentionPeriod;
            context.CharacterSetName = this.CharacterSetName;
            context.DatabaseName = this.DatabaseName;
            context.DBClusterIdentifier = this.DBClusterIdentifier;
            context.DBClusterParameterGroupName = this.DBClusterParameterGroupName;
            context.DBSubnetGroupName = this.DBSubnetGroupName;
            if (this.EnableCloudwatchLogsExport != null)
            {
                context.EnableCloudwatchLogsExports = new List<System.String>(this.EnableCloudwatchLogsExport);
            }
            if (ParameterWasBound("EnableIAMDatabaseAuthentication"))
                context.EnableIAMDatabaseAuthentication = this.EnableIAMDatabaseAuthentication;
            context.Engine = this.Engine;
            context.EngineMode = this.EngineMode;
            context.EngineVersion = this.EngineVersion;
            context.KmsKeyId = this.KmsKeyId;
            context.MasterUsername = this.MasterUsername;
            context.MasterUserPassword = this.MasterUserPassword;
            context.OptionGroupName = this.OptionGroupName;
            if (ParameterWasBound("Port"))
                context.Port = this.Port;
            context.PreferredBackupWindow = this.PreferredBackupWindow;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            context.PreSignedUrl = this.PreSignedUrl;
            context.ReplicationSourceIdentifier = this.ReplicationSourceIdentifier;
            if (ParameterWasBound("ScalingConfiguration_AutoPause"))
                context.ScalingConfiguration_AutoPause = this.ScalingConfiguration_AutoPause;
            if (ParameterWasBound("ScalingConfiguration_MaxCapacity"))
                context.ScalingConfiguration_MaxCapacity = this.ScalingConfiguration_MaxCapacity;
            if (ParameterWasBound("ScalingConfiguration_MinCapacity"))
                context.ScalingConfiguration_MinCapacity = this.ScalingConfiguration_MinCapacity;
            if (ParameterWasBound("ScalingConfiguration_SecondsUntilAutoPause"))
                context.ScalingConfiguration_SecondsUntilAutoPause = this.ScalingConfiguration_SecondsUntilAutoPause;
            if (ParameterWasBound("StorageEncrypted"))
                context.StorageEncrypted = this.StorageEncrypted;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
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
            var request = new Amazon.RDS.Model.CreateDBClusterRequest();
            
            if (cmdletContext.SourceRegion != null)
            {
                request.SourceRegion = cmdletContext.SourceRegion;
            }
            if (cmdletContext.AvailabilityZones != null)
            {
                request.AvailabilityZones = cmdletContext.AvailabilityZones;
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
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            if (cmdletContext.DBClusterIdentifier != null)
            {
                request.DBClusterIdentifier = cmdletContext.DBClusterIdentifier;
            }
            if (cmdletContext.DBClusterParameterGroupName != null)
            {
                request.DBClusterParameterGroupName = cmdletContext.DBClusterParameterGroupName;
            }
            if (cmdletContext.DBSubnetGroupName != null)
            {
                request.DBSubnetGroupName = cmdletContext.DBSubnetGroupName;
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
            if (cmdletContext.EngineMode != null)
            {
                request.EngineMode = cmdletContext.EngineMode;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.MasterUsername != null)
            {
                request.MasterUsername = cmdletContext.MasterUsername;
            }
            if (cmdletContext.MasterUserPassword != null)
            {
                request.MasterUserPassword = cmdletContext.MasterUserPassword;
            }
            if (cmdletContext.OptionGroupName != null)
            {
                request.OptionGroupName = cmdletContext.OptionGroupName;
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
            if (cmdletContext.ReplicationSourceIdentifier != null)
            {
                request.ReplicationSourceIdentifier = cmdletContext.ReplicationSourceIdentifier;
            }
            
             // populate ScalingConfiguration
            bool requestScalingConfigurationIsNull = true;
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
             // determine if request.ScalingConfiguration should be set to null
            if (requestScalingConfigurationIsNull)
            {
                request.ScalingConfiguration = null;
            }
            if (cmdletContext.StorageEncrypted != null)
            {
                request.StorageEncrypted = cmdletContext.StorageEncrypted.Value;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
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
                object pipelineOutput = response.DBCluster;
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
        
        private Amazon.RDS.Model.CreateDBClusterResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.CreateDBClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "CreateDBCluster");
            try
            {
                #if DESKTOP
                return client.CreateDBCluster(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateDBClusterAsync(request);
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
            public System.String SourceRegion { get; set; }
            public List<System.String> AvailabilityZones { get; set; }
            public System.Int64? BacktrackWindow { get; set; }
            public System.Int32? BackupRetentionPeriod { get; set; }
            public System.String CharacterSetName { get; set; }
            public System.String DatabaseName { get; set; }
            public System.String DBClusterIdentifier { get; set; }
            public System.String DBClusterParameterGroupName { get; set; }
            public System.String DBSubnetGroupName { get; set; }
            public List<System.String> EnableCloudwatchLogsExports { get; set; }
            public System.Boolean? EnableIAMDatabaseAuthentication { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineMode { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String MasterUsername { get; set; }
            public System.String MasterUserPassword { get; set; }
            public System.String OptionGroupName { get; set; }
            public System.Int32? Port { get; set; }
            public System.String PreferredBackupWindow { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.String PreSignedUrl { get; set; }
            public System.String ReplicationSourceIdentifier { get; set; }
            public System.Boolean? ScalingConfiguration_AutoPause { get; set; }
            public System.Int32? ScalingConfiguration_MaxCapacity { get; set; }
            public System.Int32? ScalingConfiguration_MinCapacity { get; set; }
            public System.Int32? ScalingConfiguration_SecondsUntilAutoPause { get; set; }
            public System.Boolean? StorageEncrypted { get; set; }
            public List<Amazon.RDS.Model.Tag> Tags { get; set; }
            public List<System.String> VpcSecurityGroupIds { get; set; }
        }
        
    }
}
