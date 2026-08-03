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
using Amazon.TimestreamInfluxDB;
using Amazon.TimestreamInfluxDB.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.TIDB
{
    /// <summary>
    /// Restores a Timestream for InfluxDB resource from a backup. By default, a new resource
    /// is created. You can optionally restore to the same resource using the REPLACE_EXISTING
    /// restore mode.
    /// </summary>
    [Cmdlet("Restore", "TIDBFromDbBackup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TimestreamInfluxDB.Model.RestoreFromDbBackupResponse")]
    [AWSCmdlet("Calls the Amazon Timestream InfluxDB RestoreFromDbBackup API operation.", Operation = new[] {"RestoreFromDbBackup"}, SelectReturnType = typeof(Amazon.TimestreamInfluxDB.Model.RestoreFromDbBackupResponse))]
    [AWSCmdletOutput("Amazon.TimestreamInfluxDB.Model.RestoreFromDbBackupResponse",
        "This cmdlet returns an Amazon.TimestreamInfluxDB.Model.RestoreFromDbBackupResponse object containing multiple properties."
    )]
    public partial class RestoreTIDBFromDbBackupCmdlet : AmazonTimestreamInfluxDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LogDeliveryConfiguration_S3Configuration_BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket to deliver logs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogDeliveryConfiguration_S3Configuration_BucketName { get; set; }
        #endregion
        
        #region Parameter DbBackupConfiguration
        /// <summary>
        /// <para>
        /// <para>A list of backup configurations to apply to the restored resource.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DbBackupConfigurations")]
        public Amazon.TimestreamInfluxDB.Model.DbBackupConfiguration[] DbBackupConfiguration { get; set; }
        #endregion
        
        #region Parameter DbBackupId
        /// <summary>
        /// <para>
        /// <para>The identifier of the backup to restore from.</para>
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
        public System.String DbBackupId { get; set; }
        #endregion
        
        #region Parameter DeploymentType
        /// <summary>
        /// <para>
        /// <para>Specifies the deployment type of the restored resource. Valid values are SINGLE_AZ,
        /// WITH_MULTIAZ_STANDBY, and MULTI_NODE_READ_REPLICAS.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.ResourceDeploymentType")]
        public Amazon.TimestreamInfluxDB.ResourceDeploymentType DeploymentType { get; set; }
        #endregion
        
        #region Parameter LogDeliveryConfiguration_S3Configuration_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether log delivery to the S3 bucket is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LogDeliveryConfiguration_S3Configuration_Enabled { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services KMS key identifier to use for encryption of the restored resource.
        /// Can be a key ID, key ARN, alias name, or alias ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the new resource to create from the restore. If restoring to an existing
        /// resource, the name must match the existing resource name.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter NetworkType
        /// <summary>
        /// <para>
        /// <para>Specifies the network type of the restored resource. Valid values are IPV4 and DUAL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.NetworkType")]
        public Amazon.TimestreamInfluxDB.NetworkType NetworkType { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port number on which the restored InfluxDB resource accepts connections.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter MaintenanceSchedule_PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>The preferred maintenance window in the format ddd:HH:MM-ddd:HH:MM (UTC). Day must
        /// be one of: Mon, Tue, Wed, Thu, Fri, Sat, Sun. For example, Sun:02:00-Sun:06:00. Provide
        /// an empty string to let the system choose a window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaintenanceSchedule_PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// <para>Specifies whether the restored resource is publicly accessible.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter RestoreMode
        /// <summary>
        /// <para>
        /// <para>Specifies whether to restore to a new resource or replace the existing resource. Valid
        /// values are NEW_RESOURCE (default) and REPLACE_EXISTING.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.RestoreMode")]
        public Amazon.TimestreamInfluxDB.RestoreMode RestoreMode { get; set; }
        #endregion
        
        #region Parameter RestoreToTime
        /// <summary>
        /// <para>
        /// <para>The point in time to restore to, for continuous backups. Must be within the backup's
        /// retention window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? RestoreToTime { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs to associate with the restored resource.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter MaintenanceSchedule_Timezone
        /// <summary>
        /// <para>
        /// <para>The IANA timezone identifier for the maintenance window. Format: Region/City or UTC.
        /// For example, America/New_York or UTC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MaintenanceSchedule_Timezone { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of VPC security group IDs for the restored resource. If not specified, the
        /// restored resource uses the same security groups as the backup.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcSubnetId
        /// <summary>
        /// <para>
        /// <para>A list of VPC subnet IDs for the restored resource. If not specified, the restored
        /// resource uses the same subnets as the backup.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcSubnetIds")]
        public System.String[] VpcSubnetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TimestreamInfluxDB.Model.RestoreFromDbBackupResponse).
        /// Specifying the name of a property of type Amazon.TimestreamInfluxDB.Model.RestoreFromDbBackupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.DbBackupId),
                nameof(this.Name)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-TIDBFromDbBackup (RestoreFromDbBackup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TimestreamInfluxDB.Model.RestoreFromDbBackupResponse, RestoreTIDBFromDbBackupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.DbBackupConfiguration != null)
            {
                context.DbBackupConfiguration = new List<Amazon.TimestreamInfluxDB.Model.DbBackupConfiguration>(this.DbBackupConfiguration);
            }
            context.DbBackupId = this.DbBackupId;
            #if MODULAR
            if (this.DbBackupId == null && ParameterWasBound(nameof(this.DbBackupId)))
            {
                WriteWarning("You are passing $null as a value for parameter DbBackupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeploymentType = this.DeploymentType;
            context.KmsKeyId = this.KmsKeyId;
            context.LogDeliveryConfiguration_S3Configuration_BucketName = this.LogDeliveryConfiguration_S3Configuration_BucketName;
            context.LogDeliveryConfiguration_S3Configuration_Enabled = this.LogDeliveryConfiguration_S3Configuration_Enabled;
            context.MaintenanceSchedule_PreferredMaintenanceWindow = this.MaintenanceSchedule_PreferredMaintenanceWindow;
            context.MaintenanceSchedule_Timezone = this.MaintenanceSchedule_Timezone;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NetworkType = this.NetworkType;
            context.Port = this.Port;
            context.PubliclyAccessible = this.PubliclyAccessible;
            context.RestoreMode = this.RestoreMode;
            context.RestoreToTime = this.RestoreToTime;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            if (this.VpcSecurityGroupId != null)
            {
                context.VpcSecurityGroupId = new List<System.String>(this.VpcSecurityGroupId);
            }
            if (this.VpcSubnetId != null)
            {
                context.VpcSubnetId = new List<System.String>(this.VpcSubnetId);
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
            var request = new Amazon.TimestreamInfluxDB.Model.RestoreFromDbBackupRequest();
            
            if (cmdletContext.DbBackupConfiguration != null)
            {
                request.DbBackupConfigurations = cmdletContext.DbBackupConfiguration;
            }
            if (cmdletContext.DbBackupId != null)
            {
                request.DbBackupId = cmdletContext.DbBackupId;
            }
            if (cmdletContext.DeploymentType != null)
            {
                request.DeploymentType = cmdletContext.DeploymentType;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            
             // populate LogDeliveryConfiguration
            var requestLogDeliveryConfigurationIsNull = true;
            request.LogDeliveryConfiguration = new Amazon.TimestreamInfluxDB.Model.LogDeliveryConfiguration();
            Amazon.TimestreamInfluxDB.Model.S3Configuration requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration = null;
            
             // populate S3Configuration
            var requestLogDeliveryConfiguration_logDeliveryConfiguration_S3ConfigurationIsNull = true;
            requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration = new Amazon.TimestreamInfluxDB.Model.S3Configuration();
            System.String requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_logDeliveryConfiguration_S3Configuration_BucketName = null;
            if (cmdletContext.LogDeliveryConfiguration_S3Configuration_BucketName != null)
            {
                requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_logDeliveryConfiguration_S3Configuration_BucketName = cmdletContext.LogDeliveryConfiguration_S3Configuration_BucketName;
            }
            if (requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_logDeliveryConfiguration_S3Configuration_BucketName != null)
            {
                requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration.BucketName = requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_logDeliveryConfiguration_S3Configuration_BucketName;
                requestLogDeliveryConfiguration_logDeliveryConfiguration_S3ConfigurationIsNull = false;
            }
            System.Boolean? requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_logDeliveryConfiguration_S3Configuration_Enabled = null;
            if (cmdletContext.LogDeliveryConfiguration_S3Configuration_Enabled != null)
            {
                requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_logDeliveryConfiguration_S3Configuration_Enabled = cmdletContext.LogDeliveryConfiguration_S3Configuration_Enabled.Value;
            }
            if (requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_logDeliveryConfiguration_S3Configuration_Enabled != null)
            {
                requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration.Enabled = requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_logDeliveryConfiguration_S3Configuration_Enabled.Value;
                requestLogDeliveryConfiguration_logDeliveryConfiguration_S3ConfigurationIsNull = false;
            }
             // determine if requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration should be set to null
            if (requestLogDeliveryConfiguration_logDeliveryConfiguration_S3ConfigurationIsNull)
            {
                requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration = null;
            }
            if (requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration != null)
            {
                request.LogDeliveryConfiguration.S3Configuration = requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration;
                requestLogDeliveryConfigurationIsNull = false;
            }
             // determine if request.LogDeliveryConfiguration should be set to null
            if (requestLogDeliveryConfigurationIsNull)
            {
                request.LogDeliveryConfiguration = null;
            }
            
             // populate MaintenanceSchedule
            var requestMaintenanceScheduleIsNull = true;
            request.MaintenanceSchedule = new Amazon.TimestreamInfluxDB.Model.MaintenanceSchedule();
            System.String requestMaintenanceSchedule_maintenanceSchedule_PreferredMaintenanceWindow = null;
            if (cmdletContext.MaintenanceSchedule_PreferredMaintenanceWindow != null)
            {
                requestMaintenanceSchedule_maintenanceSchedule_PreferredMaintenanceWindow = cmdletContext.MaintenanceSchedule_PreferredMaintenanceWindow;
            }
            if (requestMaintenanceSchedule_maintenanceSchedule_PreferredMaintenanceWindow != null)
            {
                request.MaintenanceSchedule.PreferredMaintenanceWindow = requestMaintenanceSchedule_maintenanceSchedule_PreferredMaintenanceWindow;
                requestMaintenanceScheduleIsNull = false;
            }
            System.String requestMaintenanceSchedule_maintenanceSchedule_Timezone = null;
            if (cmdletContext.MaintenanceSchedule_Timezone != null)
            {
                requestMaintenanceSchedule_maintenanceSchedule_Timezone = cmdletContext.MaintenanceSchedule_Timezone;
            }
            if (requestMaintenanceSchedule_maintenanceSchedule_Timezone != null)
            {
                request.MaintenanceSchedule.Timezone = requestMaintenanceSchedule_maintenanceSchedule_Timezone;
                requestMaintenanceScheduleIsNull = false;
            }
             // determine if request.MaintenanceSchedule should be set to null
            if (requestMaintenanceScheduleIsNull)
            {
                request.MaintenanceSchedule = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NetworkType != null)
            {
                request.NetworkType = cmdletContext.NetworkType;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.PubliclyAccessible != null)
            {
                request.PubliclyAccessible = cmdletContext.PubliclyAccessible.Value;
            }
            if (cmdletContext.RestoreMode != null)
            {
                request.RestoreMode = cmdletContext.RestoreMode;
            }
            if (cmdletContext.RestoreToTime != null)
            {
                request.RestoreToTime = cmdletContext.RestoreToTime.Value;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VpcSecurityGroupId != null)
            {
                request.VpcSecurityGroupIds = cmdletContext.VpcSecurityGroupId;
            }
            if (cmdletContext.VpcSubnetId != null)
            {
                request.VpcSubnetIds = cmdletContext.VpcSubnetId;
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
        
        private Amazon.TimestreamInfluxDB.Model.RestoreFromDbBackupResponse CallAWSServiceOperation(IAmazonTimestreamInfluxDB client, Amazon.TimestreamInfluxDB.Model.RestoreFromDbBackupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Timestream InfluxDB", "RestoreFromDbBackup");
            try
            {
                return client.RestoreFromDbBackupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.TimestreamInfluxDB.Model.DbBackupConfiguration> DbBackupConfiguration { get; set; }
            public System.String DbBackupId { get; set; }
            public Amazon.TimestreamInfluxDB.ResourceDeploymentType DeploymentType { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String LogDeliveryConfiguration_S3Configuration_BucketName { get; set; }
            public System.Boolean? LogDeliveryConfiguration_S3Configuration_Enabled { get; set; }
            public System.String MaintenanceSchedule_PreferredMaintenanceWindow { get; set; }
            public System.String MaintenanceSchedule_Timezone { get; set; }
            public System.String Name { get; set; }
            public Amazon.TimestreamInfluxDB.NetworkType NetworkType { get; set; }
            public System.Int32? Port { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public Amazon.TimestreamInfluxDB.RestoreMode RestoreMode { get; set; }
            public System.DateTime? RestoreToTime { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<System.String> VpcSecurityGroupId { get; set; }
            public List<System.String> VpcSubnetId { get; set; }
            public System.Func<Amazon.TimestreamInfluxDB.Model.RestoreFromDbBackupResponse, RestoreTIDBFromDbBackupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
