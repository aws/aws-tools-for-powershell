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
    /// Creates a new DB instance that acts as a Read Replica for an existing source DB instance.
    /// You can create a Read Replica for a DB instance running MySQL, MariaDB, or PostgreSQL.
    /// For more information, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_ReadRepl.html">Working
    /// with PostgreSQL, MySQL, and MariaDB Read Replicas</a>. 
    /// 
    ///  
    /// <para>
    /// Amazon Aurora doesn't support this action. You must call the <code>CreateDBInstance</code>
    /// action to create a DB instance for an Aurora DB cluster. 
    /// </para><para>
    /// All Read Replica DB instances are created with backups disabled. All other DB instance
    /// attributes (including DB security groups and DB parameter groups) are inherited from
    /// the source DB instance, except as specified following. 
    /// </para><important><para>
    /// Your source DB instance must have backup retention enabled. 
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "RDSDBInstanceReadReplica", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBInstance")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CreateDBInstanceReadReplica API operation.", Operation = new[] {"CreateDBInstanceReadReplica"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBInstance",
        "This cmdlet returns a DBInstance object.",
        "The service call response (type Amazon.RDS.Model.CreateDBInstanceReadReplicaResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewRDSDBInstanceReadReplicaCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter AutoMinorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>Indicates that minor engine upgrades are applied automatically to the Read Replica
        /// during the maintenance window.</para><para>Default: Inherits from the source DB instance</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AutoMinorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 Availability Zone that the Read Replica is created in.</para><para>Default: A random, system-chosen Availability Zone in the endpoint's AWS Region.</para><para> Example: <code>us-east-1d</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter CopyTagsToSnapshot
        /// <summary>
        /// <para>
        /// <para>True to copy all tags from the Read Replica to snapshots of the Read Replica, and
        /// otherwise false. The default is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean CopyTagsToSnapshot { get; set; }
        #endregion
        
        #region Parameter DBInstanceClass
        /// <summary>
        /// <para>
        /// <para>The compute and memory capacity of the Read Replica, for example, <code>db.m4.large</code>.
        /// Not all DB instance classes are available in all AWS Regions, or for all database
        /// engines. For the full list of DB instance classes, and availability for your engine,
        /// see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/Concepts.DBInstanceClass.html">DB
        /// Instance Class</a> in the Amazon RDS User Guide. </para><para>Default: Inherits from the source DB instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBInstanceClass { get; set; }
        #endregion
        
        #region Parameter DBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The DB instance identifier of the Read Replica. This identifier is the unique key
        /// that identifies a DB instance. This parameter is stored as a lowercase string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter DBSubnetGroupName
        /// <summary>
        /// <para>
        /// <para>Specifies a DB subnet group for the DB instance. The new DB instance is created in
        /// the VPC associated with the DB subnet group. If no DB subnet group is specified, then
        /// the new DB instance is not created in a VPC.</para><para>Constraints:</para><ul><li><para>Can only be specified if the source DB instance identifier specifies a DB instance
        /// in another AWS Region.</para></li><li><para>If supplied, must match the name of an existing DBSubnetGroup.</para></li><li><para>The specified DB subnet group must be in the same AWS Region in which the operation
        /// is running.</para></li><li><para>All Read Replicas in one AWS Region that are created from the same source DB instance
        /// must either:&gt;</para><ul><li><para>Specify DB subnet groups from the same VPC. All these Read Replicas are created in
        /// the same VPC.</para></li><li><para>Not specify a DB subnet group. All these Read Replicas are created outside of any
        /// VPC.</para></li></ul></li></ul><para>Example: <code>mySubnetgroup</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBSubnetGroupName { get; set; }
        #endregion
        
        #region Parameter EnableCloudwatchLogsExport
        /// <summary>
        /// <para>
        /// <para>The list of logs that the new DB instance is to export to CloudWatch Logs.</para>
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
        /// accounts, and otherwise false.</para><para>You can enable IAM database authentication for the following database engines</para><ul><li><para>For MySQL 5.6, minor version 5.6.34 or higher</para></li><li><para>For MySQL 5.7, minor version 5.7.16 or higher</para></li><li><para>Aurora 5.6 or higher.</para></li></ul><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EnableIAMDatabaseAuthentication { get; set; }
        #endregion
        
        #region Parameter EnablePerformanceInsight
        /// <summary>
        /// <para>
        /// <para>True to enable Performance Insights for the read replica, and otherwise false. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EnablePerformanceInsights")]
        public System.Boolean EnablePerformanceInsight { get; set; }
        #endregion
        
        #region Parameter Iops
        /// <summary>
        /// <para>
        /// <para>The amount of Provisioned IOPS (input/output operations per second) to be initially
        /// allocated for the DB instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Iops { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The AWS KMS key ID for an encrypted Read Replica. The KMS key ID is the Amazon Resource
        /// Name (ARN), KMS key identifier, or the KMS key alias for the KMS encryption key. </para><para>If you specify this parameter when you create a Read Replica from an unencrypted DB
        /// instance, the Read Replica is encrypted. </para><para>If you create an encrypted Read Replica in the same AWS Region as the source DB instance,
        /// then you do not have to specify a value for this parameter. The Read Replica is encrypted
        /// with the same KMS key as the source DB instance. </para><para>If you create an encrypted Read Replica in a different AWS Region, then you must specify
        /// a KMS key for the destination AWS Region. KMS encryption keys are specific to the
        /// AWS Region that they are created in, and you can't use encryption keys from one AWS
        /// Region in another AWS Region. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter MonitoringInterval
        /// <summary>
        /// <para>
        /// <para>The interval, in seconds, between points when Enhanced Monitoring metrics are collected
        /// for the Read Replica. To disable collecting Enhanced Monitoring metrics, specify 0.
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
        /// <para>The ARN for the IAM role that permits RDS to send enhanced monitoring metrics to Amazon
        /// CloudWatch Logs. For example, <code>arn:aws:iam:123456789012:role/emaccess</code>.
        /// For information on creating a monitoring role, go to <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_Monitoring.html#USER_Monitoring.OS.IAMRole">To
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
        /// <para>Specifies whether the Read Replica is in a Multi-AZ deployment. </para><para>You can create a Read Replica as a Multi-AZ DB instance. RDS creates a standby of
        /// your replica in another Availability Zone for failover support for the replica. Creating
        /// your Read Replica as a Multi-AZ DB instance is independent of whether the source database
        /// is a Multi-AZ DB instance. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean MultiAZ { get; set; }
        #endregion
        
        #region Parameter OptionGroupName
        /// <summary>
        /// <para>
        /// <para>The option group the DB instance is associated with. If omitted, the default option
        /// group for the engine specified is used.</para>
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
        /// the KMS encryption key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PerformanceInsightsKMSKeyId { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port number that the DB instance uses for connections.</para><para>Default: Inherits from the source DB instance</para><para>Valid Values: <code>1150-65535</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Port { get; set; }
        #endregion
        
        #region Parameter PreSignedUrl
        /// <summary>
        /// <para>
        /// <para>The URL that contains a Signature Version 4 signed request for the <code>CreateDBInstanceReadReplica</code>
        /// API action in the source AWS Region that contains the source DB instance. </para><para>You must specify this parameter when you create an encrypted Read Replica from another
        /// AWS Region by using the Amazon RDS API. You can specify the <code>--source-region</code>
        /// option instead of this parameter when you create an encrypted Read Replica from another
        /// AWS Region by using the AWS CLI. </para><para>The presigned URL must be a valid request for the <code>CreateDBInstanceReadReplica</code>
        /// API action that can be executed in the source AWS Region that contains the encrypted
        /// source DB instance. The presigned URL request must contain the following parameter
        /// values: </para><ul><li><para><code>DestinationRegion</code> - The AWS Region that the encrypted Read Replica is
        /// created in. This AWS Region is the same one where the <code>CreateDBInstanceReadReplica</code>
        /// action is called that contains this presigned URL. </para><para>For example, if you create an encrypted DB instance in the us-west-1 AWS Region, from
        /// a source DB instance in the us-east-2 AWS Region, then you call the <code>CreateDBInstanceReadReplica</code>
        /// action in the us-east-1 AWS Region and provide a presigned URL that contains a call
        /// to the <code>CreateDBInstanceReadReplica</code> action in the us-west-2 AWS Region.
        /// For this example, the <code>DestinationRegion</code> in the presigned URL must be
        /// set to the us-east-1 AWS Region. </para></li><li><para><code>KmsKeyId</code> - The AWS KMS key identifier for the key to use to encrypt
        /// the Read Replica in the destination AWS Region. This is the same identifier for both
        /// the <code>CreateDBInstanceReadReplica</code> action that is called in the destination
        /// AWS Region, and the action contained in the presigned URL. </para></li><li><para><code>SourceDBInstanceIdentifier</code> - The DB instance identifier for the encrypted
        /// DB instance to be replicated. This identifier must be in the Amazon Resource Name
        /// (ARN) format for the source AWS Region. For example, if you are creating an encrypted
        /// Read Replica from a DB instance in the us-west-2 AWS Region, then your <code>SourceDBInstanceIdentifier</code>
        /// looks like the following example: <code>arn:aws:rds:us-west-2:123456789012:instance:mysql-instance1-20161115</code>.
        /// </para></li></ul><para>To learn how to generate a Signature Version 4 signed request, see <a href="http://docs.aws.amazon.com/AmazonS3/latest/API/sigv4-query-string-auth.html">Authenticating
        /// Requests: Using Query Parameters (AWS Signature Version 4)</a> and <a href="http://docs.aws.amazon.com/general/latest/gr/signature-version-4.html">Signature
        /// Version 4 Signing Process</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreSignedUrl { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>Specifies the accessibility options for the DB instance. A value of true specifies
        /// an Internet-facing instance with a publicly resolvable DNS name, which resolves to
        /// a public IP address. A value of false specifies an internal instance with a DNS name
        /// that resolves to a private IP address.</para><para>Default: The default behavior varies depending on whether a VPC has been requested
        /// or not. The following list shows the default behavior in each case.</para><ul><li><para><b>Default VPC:</b>true</para></li><li><para><b>VPC:</b>false</para></li></ul><para>If no DB subnet group has been specified as part of the request and the PubliclyAccessible
        /// value has not been set, the DB instance is publicly accessible. If a specific DB subnet
        /// group has been specified as part of the request and the PubliclyAccessible value has
        /// not been set, the DB instance is private.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter SourceDBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the DB instance that will act as the source for the Read Replica.
        /// Each DB instance can have up to five Read Replicas.</para><para>Constraints:</para><ul><li><para>Must be the identifier of an existing MySQL, MariaDB, or PostgreSQL DB instance.</para></li><li><para>Can specify a DB instance that is a MySQL Read Replica only if the source is running
        /// MySQL 5.6.</para></li><li><para>Can specify a DB instance that is a PostgreSQL DB instance only if the source is running
        /// PostgreSQL 9.3.5 or later (9.4.7 and higher for cross-region replication).</para></li><li><para>The specified DB instance must have automatic backups enabled, its backup retention
        /// period must be greater than 0.</para></li><li><para>If the source DB instance is in the same AWS Region as the Read Replica, specify a
        /// valid DB instance identifier.</para></li><li><para>If the source DB instance is in a different AWS Region than the Read Replica, specify
        /// a valid DB instance ARN. For more information, go to <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_Tagging.ARN.html#USER_Tagging.ARN.Constructing">
        /// Constructing a Amazon RDS Amazon Resource Name (ARN)</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String SourceDBInstanceIdentifier { get; set; }
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
        
        #region Parameter StorageType
        /// <summary>
        /// <para>
        /// <para>Specifies the storage type to be associated with the Read Replica.</para><para> Valid values: <code>standard | gp2 | io1</code></para><para> If you specify <code>io1</code>, you must also include a value for the <code>Iops</code>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RDSDBInstanceReadReplica (CreateDBInstanceReadReplica)"))
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
            if (ParameterWasBound("AutoMinorVersionUpgrade"))
                context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            context.AvailabilityZone = this.AvailabilityZone;
            if (ParameterWasBound("CopyTagsToSnapshot"))
                context.CopyTagsToSnapshot = this.CopyTagsToSnapshot;
            context.DBInstanceClass = this.DBInstanceClass;
            context.DBInstanceIdentifier = this.DBInstanceIdentifier;
            context.DBSubnetGroupName = this.DBSubnetGroupName;
            if (this.EnableCloudwatchLogsExport != null)
            {
                context.EnableCloudwatchLogsExports = new List<System.String>(this.EnableCloudwatchLogsExport);
            }
            if (ParameterWasBound("EnableIAMDatabaseAuthentication"))
                context.EnableIAMDatabaseAuthentication = this.EnableIAMDatabaseAuthentication;
            if (ParameterWasBound("EnablePerformanceInsight"))
                context.EnablePerformanceInsights = this.EnablePerformanceInsight;
            if (ParameterWasBound("Iops"))
                context.Iops = this.Iops;
            context.KmsKeyId = this.KmsKeyId;
            if (ParameterWasBound("MonitoringInterval"))
                context.MonitoringInterval = this.MonitoringInterval;
            context.MonitoringRoleArn = this.MonitoringRoleArn;
            if (ParameterWasBound("MultiAZ"))
                context.MultiAZ = this.MultiAZ;
            context.OptionGroupName = this.OptionGroupName;
            context.PerformanceInsightsKMSKeyId = this.PerformanceInsightsKMSKeyId;
            if (ParameterWasBound("Port"))
                context.Port = this.Port;
            context.PreSignedUrl = this.PreSignedUrl;
            if (ParameterWasBound("PubliclyAccessible"))
                context.PubliclyAccessible = this.PubliclyAccessible;
            context.SourceDBInstanceIdentifier = this.SourceDBInstanceIdentifier;
            context.StorageType = this.StorageType;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.RDS.Model.Tag>(this.Tag);
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
            var request = new Amazon.RDS.Model.CreateDBInstanceReadReplicaRequest();
            
            if (cmdletContext.SourceRegion != null)
            {
                request.SourceRegion = cmdletContext.SourceRegion;
            }
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
            if (cmdletContext.DBInstanceIdentifier != null)
            {
                request.DBInstanceIdentifier = cmdletContext.DBInstanceIdentifier;
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
            if (cmdletContext.EnablePerformanceInsights != null)
            {
                request.EnablePerformanceInsights = cmdletContext.EnablePerformanceInsights.Value;
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
            if (cmdletContext.MultiAZ != null)
            {
                request.MultiAZ = cmdletContext.MultiAZ.Value;
            }
            if (cmdletContext.OptionGroupName != null)
            {
                request.OptionGroupName = cmdletContext.OptionGroupName;
            }
            if (cmdletContext.PerformanceInsightsKMSKeyId != null)
            {
                request.PerformanceInsightsKMSKeyId = cmdletContext.PerformanceInsightsKMSKeyId;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.PreSignedUrl != null)
            {
                request.PreSignedUrl = cmdletContext.PreSignedUrl;
            }
            if (cmdletContext.PubliclyAccessible != null)
            {
                request.PubliclyAccessible = cmdletContext.PubliclyAccessible.Value;
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
        
        private Amazon.RDS.Model.CreateDBInstanceReadReplicaResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.CreateDBInstanceReadReplicaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "CreateDBInstanceReadReplica");
            try
            {
                #if DESKTOP
                return client.CreateDBInstanceReadReplica(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateDBInstanceReadReplicaAsync(request);
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
            public System.Boolean? AutoMinorVersionUpgrade { get; set; }
            public System.String AvailabilityZone { get; set; }
            public System.Boolean? CopyTagsToSnapshot { get; set; }
            public System.String DBInstanceClass { get; set; }
            public System.String DBInstanceIdentifier { get; set; }
            public System.String DBSubnetGroupName { get; set; }
            public List<System.String> EnableCloudwatchLogsExports { get; set; }
            public System.Boolean? EnableIAMDatabaseAuthentication { get; set; }
            public System.Boolean? EnablePerformanceInsights { get; set; }
            public System.Int32? Iops { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.Int32? MonitoringInterval { get; set; }
            public System.String MonitoringRoleArn { get; set; }
            public System.Boolean? MultiAZ { get; set; }
            public System.String OptionGroupName { get; set; }
            public System.String PerformanceInsightsKMSKeyId { get; set; }
            public System.Int32? Port { get; set; }
            public System.String PreSignedUrl { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public System.String SourceDBInstanceIdentifier { get; set; }
            public System.String StorageType { get; set; }
            public List<Amazon.RDS.Model.Tag> Tags { get; set; }
        }
        
    }
}
