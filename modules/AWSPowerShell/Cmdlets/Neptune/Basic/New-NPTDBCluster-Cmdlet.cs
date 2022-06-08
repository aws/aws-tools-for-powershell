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
using Amazon.Neptune;
using Amazon.Neptune.Model;

namespace Amazon.PowerShell.Cmdlets.NPT
{
    /// <summary>
    /// Creates a new Amazon Neptune DB cluster.
    /// 
    ///  
    /// <para>
    /// You can use the <code>ReplicationSourceIdentifier</code> parameter to create the DB
    /// cluster as a Read Replica of another DB cluster or Amazon Neptune DB instance.
    /// </para><para>
    /// Note that when you create a new cluster using <code>CreateDBCluster</code> directly,
    /// deletion protection is disabled by default (when you create a new production cluster
    /// in the console, deletion protection is enabled by default). You can only delete a
    /// DB cluster if its <code>DeletionProtection</code> field is set to <code>false</code>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "NPTDBCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Neptune.Model.DBCluster")]
    [AWSCmdlet("Calls the Amazon Neptune CreateDBCluster API operation.", Operation = new[] {"CreateDBCluster"}, SelectReturnType = typeof(Amazon.Neptune.Model.CreateDBClusterResponse))]
    [AWSCmdletOutput("Amazon.Neptune.Model.DBCluster or Amazon.Neptune.Model.CreateDBClusterResponse",
        "This cmdlet returns an Amazon.Neptune.Model.DBCluster object.",
        "The service call response (type Amazon.Neptune.Model.CreateDBClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewNPTDBClusterCmdlet : AmazonNeptuneClientCmdlet, IExecutor
    {
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>A list of EC2 Availability Zones that instances in the DB cluster can be created in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AvailabilityZones")]
        public System.String[] AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter BackupRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days for which automated backups are retained. You must specify a minimum
        /// value of 1.</para><para>Default: 1</para><para>Constraints:</para><ul><li><para>Must be a value from 1 to 35</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BackupRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter CharacterSetName
        /// <summary>
        /// <para>
        /// <para><i>(Not supported by Neptune)</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CharacterSetName { get; set; }
        #endregion
        
        #region Parameter CopyTagsToSnapshot
        /// <summary>
        /// <para>
        /// <para><i>If set to <code>true</code>, tags are copied to any snapshot of the DB cluster
        /// that is created.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CopyTagsToSnapshot { get; set; }
        #endregion
        
        #region Parameter DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name for your database of up to 64 alpha-numeric characters. If you do not provide
        /// a name, Amazon Neptune will not create a database in the DB cluster you are creating.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatabaseName { get; set; }
        #endregion
        
        #region Parameter DBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The DB cluster identifier. This parameter is stored as a lowercase string.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 letters, numbers, or hyphens.</para></li><li><para>First character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li></ul><para>Example: <code>my-cluster1</code></para>
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
        
        #region Parameter DBClusterParameterGroupName
        /// <summary>
        /// <para>
        /// <para> The name of the DB cluster parameter group to associate with this DB cluster. If
        /// this argument is omitted, the default is used.</para><para>Constraints:</para><ul><li><para>If supplied, must match the name of an existing DBClusterParameterGroup.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether the DB cluster has deletion protection enabled. The
        /// database can't be deleted when deletion protection is enabled. By default, deletion
        /// protection is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtection { get; set; }
        #endregion
        
        #region Parameter EnableCloudwatchLogsExport
        /// <summary>
        /// <para>
        /// <para>The list of log types that need to be enabled for exporting to CloudWatch Logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnableCloudwatchLogsExports")]
        public System.String[] EnableCloudwatchLogsExport { get; set; }
        #endregion
        
        #region Parameter EnableIAMDatabaseAuthentication
        /// <summary>
        /// <para>
        /// <para>If set to <code>true</code>, enables Amazon Identity and Access Management (IAM) authentication
        /// for the entire DB cluster (this cannot be set at an instance level).</para><para>Default: <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableIAMDatabaseAuthentication { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The name of the database engine to be used for this DB cluster.</para><para>Valid Values: <code>neptune</code></para>
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
        /// <para>The version number of the database engine to use for the new DB cluster.</para><para>Example: <code>1.0.2.1</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter GlobalClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the Neptune global database to which this new DB cluster should be added.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GlobalClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon KMS key identifier for an encrypted DB cluster.</para><para>The KMS key identifier is the Amazon Resource Name (ARN) for the KMS encryption key.
        /// If you are creating a DB cluster with the same Amazon account that owns the KMS encryption
        /// key used to encrypt the new DB cluster, then you can use the KMS key alias instead
        /// of the ARN for the KMS encryption key.</para><para>If an encryption key is not specified in <code>KmsKeyId</code>:</para><ul><li><para>If <code>ReplicationSourceIdentifier</code> identifies an encrypted source, then Amazon
        /// Neptune will use the encryption key used to encrypt the source. Otherwise, Amazon
        /// Neptune will use your default encryption key.</para></li><li><para>If the <code>StorageEncrypted</code> parameter is true and <code>ReplicationSourceIdentifier</code>
        /// is not specified, then Amazon Neptune will use your default encryption key.</para></li></ul><para>Amazon KMS creates the default encryption key for your Amazon account. Your Amazon
        /// account has a different default encryption key for each Amazon Region.</para><para>If you create a Read Replica of an encrypted DB cluster in another Amazon Region,
        /// you must set <code>KmsKeyId</code> to a KMS key ID that is valid in the destination
        /// Amazon Region. This key is used to encrypt the Read Replica in that Amazon Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter MasterUsername
        /// <summary>
        /// <para>
        /// <para>Not supported by Neptune.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MasterUsername { get; set; }
        #endregion
        
        #region Parameter MasterUserPassword
        /// <summary>
        /// <para>
        /// <para>Not supported by Neptune.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MasterUserPassword { get; set; }
        #endregion
        
        #region Parameter OptionGroupName
        /// <summary>
        /// <para>
        /// <para><i>(Not supported by Neptune)</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OptionGroupName { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port number on which the instances in the DB cluster accept connections.</para><para> Default: <code>8182</code></para>
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
        /// for each Amazon Region. To see the time blocks available, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/AdjustingTheMaintenanceWindow.html">
        /// Adjusting the Preferred Maintenance Window</a> in the <i>Amazon Neptune User Guide.</i></para><para>Constraints:</para><ul><li><para>Must be in the format <code>hh24:mi-hh24:mi</code>.</para></li><li><para>Must be in Universal Coordinated Time (UTC).</para></li><li><para>Must not conflict with the preferred maintenance window.</para></li><li><para>Must be at least 30 minutes.</para></li></ul>
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
        /// for each Amazon Region, occurring on a random day of the week. To see the time blocks
        /// available, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/AdjustingTheMaintenanceWindow.html">
        /// Adjusting the Preferred Maintenance Window</a> in the <i>Amazon Neptune User Guide.</i></para><para>Valid Days: Mon, Tue, Wed, Thu, Fri, Sat, Sun.</para><para>Constraints: Minimum 30-minute window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter PreSignedUrl
        /// <summary>
        /// <para>
        /// <para>This parameter is not currently supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreSignedUrl { get; set; }
        #endregion
        
        #region Parameter ReplicationSourceIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the source DB instance or DB cluster if this DB
        /// cluster is created as a Read Replica.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReplicationSourceIdentifier { get; set; }
        #endregion
        
        #region Parameter SourceRegion
        /// <summary>
        /// <para>
        /// The SourceRegion for generating the PreSignedUrl property.
        /// If SourceRegion is set and the PreSignedUrl property is not,
        /// then PreSignedUrl will be automatically generated by the client.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceRegion { get; set; }
        #endregion
        
        #region Parameter StorageEncrypted
        /// <summary>
        /// <para>
        /// <para>Specifies whether the DB cluster is encrypted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? StorageEncrypted { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the new DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Neptune.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of EC2 VPC security groups to associate with this DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBCluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Neptune.Model.CreateDBClusterResponse).
        /// Specifying the name of a property of type Amazon.Neptune.Model.CreateDBClusterResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBClusterIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NPTDBCluster (CreateDBCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Neptune.Model.CreateDBClusterResponse, NewNPTDBClusterCmdlet>(Select) ??
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
            if (this.AvailabilityZone != null)
            {
                context.AvailabilityZone = new List<System.String>(this.AvailabilityZone);
            }
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
            context.DBClusterParameterGroupName = this.DBClusterParameterGroupName;
            context.DBSubnetGroupName = this.DBSubnetGroupName;
            context.DeletionProtection = this.DeletionProtection;
            if (this.EnableCloudwatchLogsExport != null)
            {
                context.EnableCloudwatchLogsExport = new List<System.String>(this.EnableCloudwatchLogsExport);
            }
            context.EnableIAMDatabaseAuthentication = this.EnableIAMDatabaseAuthentication;
            context.Engine = this.Engine;
            #if MODULAR
            if (this.Engine == null && ParameterWasBound(nameof(this.Engine)))
            {
                WriteWarning("You are passing $null as a value for parameter Engine which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EngineVersion = this.EngineVersion;
            context.GlobalClusterIdentifier = this.GlobalClusterIdentifier;
            context.KmsKeyId = this.KmsKeyId;
            context.MasterUsername = this.MasterUsername;
            context.MasterUserPassword = this.MasterUserPassword;
            context.OptionGroupName = this.OptionGroupName;
            context.Port = this.Port;
            context.PreferredBackupWindow = this.PreferredBackupWindow;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            context.PreSignedUrl = this.PreSignedUrl;
            context.ReplicationSourceIdentifier = this.ReplicationSourceIdentifier;
            context.StorageEncrypted = this.StorageEncrypted;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Neptune.Model.Tag>(this.Tag);
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
            var request = new Amazon.Neptune.Model.CreateDBClusterRequest();
            
            if (cmdletContext.SourceRegion != null)
            {
                request.SourceRegion = cmdletContext.SourceRegion;
            }
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZones = cmdletContext.AvailabilityZone;
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
            if (cmdletContext.EnableCloudwatchLogsExport != null)
            {
                request.EnableCloudwatchLogsExports = cmdletContext.EnableCloudwatchLogsExport;
            }
            if (cmdletContext.EnableIAMDatabaseAuthentication != null)
            {
                request.EnableIAMDatabaseAuthentication = cmdletContext.EnableIAMDatabaseAuthentication.Value;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.GlobalClusterIdentifier != null)
            {
                request.GlobalClusterIdentifier = cmdletContext.GlobalClusterIdentifier;
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
            if (cmdletContext.StorageEncrypted != null)
            {
                request.StorageEncrypted = cmdletContext.StorageEncrypted.Value;
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
        
        private Amazon.Neptune.Model.CreateDBClusterResponse CallAWSServiceOperation(IAmazonNeptune client, Amazon.Neptune.Model.CreateDBClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Neptune", "CreateDBCluster");
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
            public List<System.String> AvailabilityZone { get; set; }
            public System.Int32? BackupRetentionPeriod { get; set; }
            public System.String CharacterSetName { get; set; }
            public System.Boolean? CopyTagsToSnapshot { get; set; }
            public System.String DatabaseName { get; set; }
            public System.String DBClusterIdentifier { get; set; }
            public System.String DBClusterParameterGroupName { get; set; }
            public System.String DBSubnetGroupName { get; set; }
            public System.Boolean? DeletionProtection { get; set; }
            public List<System.String> EnableCloudwatchLogsExport { get; set; }
            public System.Boolean? EnableIAMDatabaseAuthentication { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String GlobalClusterIdentifier { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String MasterUsername { get; set; }
            public System.String MasterUserPassword { get; set; }
            public System.String OptionGroupName { get; set; }
            public System.Int32? Port { get; set; }
            public System.String PreferredBackupWindow { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.String PreSignedUrl { get; set; }
            public System.String ReplicationSourceIdentifier { get; set; }
            public System.Boolean? StorageEncrypted { get; set; }
            public List<Amazon.Neptune.Model.Tag> Tag { get; set; }
            public List<System.String> VpcSecurityGroupId { get; set; }
            public System.Func<Amazon.Neptune.Model.CreateDBClusterResponse, NewNPTDBClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBCluster;
        }
        
    }
}
