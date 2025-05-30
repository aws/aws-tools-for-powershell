/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.Neptune;
using Amazon.Neptune.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NPT
{
    /// <summary>
    /// Modify a setting for a DB cluster. You can change one or more database configuration
    /// parameters by specifying these parameters and the new values in the request.
    /// </summary>
    [Cmdlet("Edit", "NPTDBCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Neptune.Model.DBCluster")]
    [AWSCmdlet("Calls the Amazon Neptune ModifyDBCluster API operation.", Operation = new[] {"ModifyDBCluster"}, SelectReturnType = typeof(Amazon.Neptune.Model.ModifyDBClusterResponse))]
    [AWSCmdletOutput("Amazon.Neptune.Model.DBCluster or Amazon.Neptune.Model.ModifyDBClusterResponse",
        "This cmdlet returns an Amazon.Neptune.Model.DBCluster object.",
        "The service call response (type Amazon.Neptune.Model.ModifyDBClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditNPTDBClusterCmdlet : AmazonNeptuneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AllowMajorVersionUpgrade
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether upgrades between different major versions are allowed.</para><para>Constraints: You must set the allow-major-version-upgrade flag when providing an <c>EngineVersion</c>
        /// parameter that uses a different major version than the DB cluster's current version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowMajorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter ApplyImmediately
        /// <summary>
        /// <para>
        /// <para>A value that specifies whether the modifications in this request and any pending modifications
        /// are asynchronously applied as soon as possible, regardless of the <c>PreferredMaintenanceWindow</c>
        /// setting for the DB cluster. If this parameter is set to <c>false</c>, changes to the
        /// DB cluster are applied during the next maintenance window.</para><para>The <c>ApplyImmediately</c> parameter only affects <c>NewDBClusterIdentifier</c> values.
        /// If you set the <c>ApplyImmediately</c> parameter value to false, then changes to <c>NewDBClusterIdentifier</c>
        /// values are applied during the next maintenance window. All other changes are applied
        /// immediately, regardless of the value of the <c>ApplyImmediately</c> parameter.</para><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ApplyImmediately { get; set; }
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
        
        #region Parameter CopyTagsToSnapshot
        /// <summary>
        /// <para>
        /// <para><i>If set to <c>true</c>, tags are copied to any snapshot of the DB cluster that
        /// is created.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CopyTagsToSnapshot { get; set; }
        #endregion
        
        #region Parameter DBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The DB cluster identifier for the cluster being modified. This parameter is not case-sensitive.</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing DBCluster.</para></li></ul>
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
        /// <para>The name of the DB cluster parameter group to use for the DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBClusterParameterGroupName { get; set; }
        #endregion
        
        #region Parameter DBInstanceParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the DB parameter group to apply to all instances of the DB cluster. </para><note><para>When you apply a parameter group using <c>DBInstanceParameterGroupName</c>, parameter
        /// changes aren't applied during the next maintenance window but instead are applied
        /// immediately.</para></note><para>Default: The existing name setting</para><para>Constraints:</para><ul><li><para>The DB parameter group must be in the same DB parameter group family as the target
        /// DB cluster version.</para></li><li><para>The <c>DBInstanceParameterGroupName</c> parameter is only valid in combination with
        /// the <c>AllowMajorVersionUpgrade</c> parameter.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBInstanceParameterGroupName { get; set; }
        #endregion
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether the DB cluster has deletion protection enabled. The
        /// database can't be deleted when deletion protection is enabled. By default, deletion
        /// protection is disabled.</para>
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
        
        #region Parameter EnableIAMDatabaseAuthentication
        /// <summary>
        /// <para>
        /// <para>True to enable mapping of Amazon Identity and Access Management (IAM) accounts to
        /// database accounts, and otherwise false.</para><para>Default: <c>false</c></para>
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
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The version number of the database engine to which you want to upgrade. Changing this
        /// parameter results in an outage. The change is applied during the next maintenance
        /// window unless the <c>ApplyImmediately</c> parameter is set to true.</para><para>For a list of valid engine versions, see <a href="https://docs.aws.amazon.com/neptune/latest/userguide/engine-releases.html">Engine
        /// Releases for Amazon Neptune</a>, or call <a>DescribeDBEngineVersions</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
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
        
        #region Parameter ServerlessV2ScalingConfiguration_MaxCapacity
        /// <summary>
        /// <para>
        /// <para>The maximum number of Neptune capacity units (NCUs) for a DB instance in a Neptune
        /// Serverless cluster. You can specify NCU values in half-step increments, such as 40,
        /// 40.5, 41, and so on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? ServerlessV2ScalingConfiguration_MaxCapacity { get; set; }
        #endregion
        
        #region Parameter ServerlessV2ScalingConfiguration_MinCapacity
        /// <summary>
        /// <para>
        /// <para>The minimum number of Neptune capacity units (NCUs) for a DB instance in a Neptune
        /// Serverless cluster. You can specify NCU values in half-step increments, such as 8,
        /// 8.5, 9, and so on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? ServerlessV2ScalingConfiguration_MinCapacity { get; set; }
        #endregion
        
        #region Parameter NewDBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The new DB cluster identifier for the DB cluster when renaming a DB cluster. This
        /// value is stored as a lowercase string.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 letters, numbers, or hyphens</para></li><li><para>The first character must be a letter</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens</para></li></ul><para>Example: <c>my-cluster2</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewDBClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter OptionGroupName
        /// <summary>
        /// <para>
        /// <para><i>Not supported by Neptune.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OptionGroupName { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port number on which the DB cluster accepts connections.</para><para>Constraints: Value must be <c>1150-65535</c></para><para>Default: The same port as the original DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter PreferredBackupWindow
        /// <summary>
        /// <para>
        /// <para>The daily time range during which automated backups are created if automated backups
        /// are enabled, using the <c>BackupRetentionPeriod</c> parameter.</para><para>The default is a 30-minute window selected at random from an 8-hour block of time
        /// for each Amazon Region.</para><para>Constraints:</para><ul><li><para>Must be in the format <c>hh24:mi-hh24:mi</c>.</para></li><li><para>Must be in Universal Coordinated Time (UTC).</para></li><li><para>Must not conflict with the preferred maintenance window.</para></li><li><para>Must be at least 30 minutes.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredBackupWindow { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>The weekly time range during which system maintenance can occur, in Universal Coordinated
        /// Time (UTC).</para><para>Format: <c>ddd:hh24:mi-ddd:hh24:mi</c></para><para>The default is a 30-minute window selected at random from an 8-hour block of time
        /// for each Amazon Region, occurring on a random day of the week.</para><para>Valid Days: Mon, Tue, Wed, Thu, Fri, Sat, Sun.</para><para>Constraints: Minimum 30-minute window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter StorageType
        /// <summary>
        /// <para>
        /// <para>The storage type to associate with the DB cluster.</para><para>Valid Values:</para><ul><li><para><b><c>standard</c></b>   –   ( <i>the default</i> ) Configures cost-effective database
        /// storage for applications with moderate to small I/O usage.</para></li><li><para><b><c>iopt1</c></b>   –   Enables <a href="https://docs.aws.amazon.com/neptune/latest/userguide/storage-types.html#provisioned-iops-storage">I/O-Optimized
        /// storage</a> that's designed to meet the needs of I/O-intensive graph workloads that
        /// require predictable pricing with low I/O latency and consistent I/O throughput.</para><para>Neptune I/O-Optimized storage is only available starting with engine release 1.3.0.0.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageType { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of VPC security groups that the DB cluster will belong to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBCluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Neptune.Model.ModifyDBClusterResponse).
        /// Specifying the name of a property of type Amazon.Neptune.Model.ModifyDBClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBCluster";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBClusterIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-NPTDBCluster (ModifyDBCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Neptune.Model.ModifyDBClusterResponse, EditNPTDBClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AllowMajorVersionUpgrade = this.AllowMajorVersionUpgrade;
            context.ApplyImmediately = this.ApplyImmediately;
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
            context.DBClusterParameterGroupName = this.DBClusterParameterGroupName;
            context.DBInstanceParameterGroupName = this.DBInstanceParameterGroupName;
            context.DeletionProtection = this.DeletionProtection;
            context.EnableIAMDatabaseAuthentication = this.EnableIAMDatabaseAuthentication;
            context.EngineVersion = this.EngineVersion;
            context.MasterUserPassword = this.MasterUserPassword;
            context.NewDBClusterIdentifier = this.NewDBClusterIdentifier;
            context.OptionGroupName = this.OptionGroupName;
            context.Port = this.Port;
            context.PreferredBackupWindow = this.PreferredBackupWindow;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
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
            var request = new Amazon.Neptune.Model.ModifyDBClusterRequest();
            
            if (cmdletContext.AllowMajorVersionUpgrade != null)
            {
                request.AllowMajorVersionUpgrade = cmdletContext.AllowMajorVersionUpgrade.Value;
            }
            if (cmdletContext.ApplyImmediately != null)
            {
                request.ApplyImmediately = cmdletContext.ApplyImmediately.Value;
            }
            if (cmdletContext.BackupRetentionPeriod != null)
            {
                request.BackupRetentionPeriod = cmdletContext.BackupRetentionPeriod.Value;
            }
            
             // populate CloudwatchLogsExportConfiguration
            var requestCloudwatchLogsExportConfigurationIsNull = true;
            request.CloudwatchLogsExportConfiguration = new Amazon.Neptune.Model.CloudwatchLogsExportConfiguration();
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
            if (cmdletContext.EnableIAMDatabaseAuthentication != null)
            {
                request.EnableIAMDatabaseAuthentication = cmdletContext.EnableIAMDatabaseAuthentication.Value;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.MasterUserPassword != null)
            {
                request.MasterUserPassword = cmdletContext.MasterUserPassword;
            }
            if (cmdletContext.NewDBClusterIdentifier != null)
            {
                request.NewDBClusterIdentifier = cmdletContext.NewDBClusterIdentifier;
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
            
             // populate ServerlessV2ScalingConfiguration
            var requestServerlessV2ScalingConfigurationIsNull = true;
            request.ServerlessV2ScalingConfiguration = new Amazon.Neptune.Model.ServerlessV2ScalingConfiguration();
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
        
        private Amazon.Neptune.Model.ModifyDBClusterResponse CallAWSServiceOperation(IAmazonNeptune client, Amazon.Neptune.Model.ModifyDBClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Neptune", "ModifyDBCluster");
            try
            {
                return client.ModifyDBClusterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AllowMajorVersionUpgrade { get; set; }
            public System.Boolean? ApplyImmediately { get; set; }
            public System.Int32? BackupRetentionPeriod { get; set; }
            public List<System.String> CloudwatchLogsExportConfiguration_DisableLogType { get; set; }
            public List<System.String> CloudwatchLogsExportConfiguration_EnableLogType { get; set; }
            public System.Boolean? CopyTagsToSnapshot { get; set; }
            public System.String DBClusterIdentifier { get; set; }
            public System.String DBClusterParameterGroupName { get; set; }
            public System.String DBInstanceParameterGroupName { get; set; }
            public System.Boolean? DeletionProtection { get; set; }
            public System.Boolean? EnableIAMDatabaseAuthentication { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String MasterUserPassword { get; set; }
            public System.String NewDBClusterIdentifier { get; set; }
            public System.String OptionGroupName { get; set; }
            public System.Int32? Port { get; set; }
            public System.String PreferredBackupWindow { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.Double? ServerlessV2ScalingConfiguration_MaxCapacity { get; set; }
            public System.Double? ServerlessV2ScalingConfiguration_MinCapacity { get; set; }
            public System.String StorageType { get; set; }
            public List<System.String> VpcSecurityGroupId { get; set; }
            public System.Func<Amazon.Neptune.Model.ModifyDBClusterResponse, EditNPTDBClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBCluster;
        }
        
    }
}
