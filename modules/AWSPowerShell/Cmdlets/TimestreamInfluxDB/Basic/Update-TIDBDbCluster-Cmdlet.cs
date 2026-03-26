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
using Amazon.TimestreamInfluxDB;
using Amazon.TimestreamInfluxDB.Model;

namespace Amazon.PowerShell.Cmdlets.TIDB
{
    /// <summary>
    /// Updates a Timestream for InfluxDB cluster.
    /// </summary>
    [Cmdlet("Update", "TIDBDbCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TimestreamInfluxDB.ClusterStatus")]
    [AWSCmdlet("Calls the Amazon Timestream InfluxDB UpdateDbCluster API operation.", Operation = new[] {"UpdateDbCluster"}, SelectReturnType = typeof(Amazon.TimestreamInfluxDB.Model.UpdateDbClusterResponse))]
    [AWSCmdletOutput("Amazon.TimestreamInfluxDB.ClusterStatus or Amazon.TimestreamInfluxDB.Model.UpdateDbClusterResponse",
        "This cmdlet returns an Amazon.TimestreamInfluxDB.ClusterStatus object.",
        "The service call response (type Amazon.TimestreamInfluxDB.Model.UpdateDbClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateTIDBDbClusterCmdlet : AmazonTimestreamInfluxDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3Configuration_BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket to deliver logs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogDeliveryConfiguration_S3Configuration_BucketName")]
        public System.String S3Configuration_BucketName { get; set; }
        #endregion
        
        #region Parameter DbClusterId
        /// <summary>
        /// <para>
        /// <para>Service-generated unique identifier of the DB cluster to update.</para>
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
        public System.String DbClusterId { get; set; }
        #endregion
        
        #region Parameter DbInstanceType
        /// <summary>
        /// <para>
        /// <para>Update the DB cluster to use the specified DB instance Type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.DbInstanceType")]
        public Amazon.TimestreamInfluxDB.DbInstanceType DbInstanceType { get; set; }
        #endregion
        
        #region Parameter DbParameterGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>Update the DB cluster to use the specified DB parameter group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DbParameterGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter S3Configuration_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether log delivery to the S3 bucket is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogDeliveryConfiguration_S3Configuration_Enabled")]
        public System.Boolean? S3Configuration_Enabled { get; set; }
        #endregion
        
        #region Parameter FailoverMode
        /// <summary>
        /// <para>
        /// <para>Update the DB cluster's failover behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.FailoverMode")]
        public Amazon.TimestreamInfluxDB.FailoverMode FailoverMode { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>Update the DB cluster to use the specified port.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DbClusterStatus'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TimestreamInfluxDB.Model.UpdateDbClusterResponse).
        /// Specifying the name of a property of type Amazon.TimestreamInfluxDB.Model.UpdateDbClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DbClusterStatus";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DbClusterId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DbClusterId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DbClusterId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DbClusterId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-TIDBDbCluster (UpdateDbCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TimestreamInfluxDB.Model.UpdateDbClusterResponse, UpdateTIDBDbClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DbClusterId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DbClusterId = this.DbClusterId;
            #if MODULAR
            if (this.DbClusterId == null && ParameterWasBound(nameof(this.DbClusterId)))
            {
                WriteWarning("You are passing $null as a value for parameter DbClusterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DbInstanceType = this.DbInstanceType;
            context.DbParameterGroupIdentifier = this.DbParameterGroupIdentifier;
            context.FailoverMode = this.FailoverMode;
            context.S3Configuration_BucketName = this.S3Configuration_BucketName;
            context.S3Configuration_Enabled = this.S3Configuration_Enabled;
            context.MaintenanceSchedule_PreferredMaintenanceWindow = this.MaintenanceSchedule_PreferredMaintenanceWindow;
            context.MaintenanceSchedule_Timezone = this.MaintenanceSchedule_Timezone;
            context.Port = this.Port;
            
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
            var request = new Amazon.TimestreamInfluxDB.Model.UpdateDbClusterRequest();
            
            if (cmdletContext.DbClusterId != null)
            {
                request.DbClusterId = cmdletContext.DbClusterId;
            }
            if (cmdletContext.DbInstanceType != null)
            {
                request.DbInstanceType = cmdletContext.DbInstanceType;
            }
            if (cmdletContext.DbParameterGroupIdentifier != null)
            {
                request.DbParameterGroupIdentifier = cmdletContext.DbParameterGroupIdentifier;
            }
            if (cmdletContext.FailoverMode != null)
            {
                request.FailoverMode = cmdletContext.FailoverMode;
            }
            
             // populate LogDeliveryConfiguration
            var requestLogDeliveryConfigurationIsNull = true;
            request.LogDeliveryConfiguration = new Amazon.TimestreamInfluxDB.Model.LogDeliveryConfiguration();
            Amazon.TimestreamInfluxDB.Model.S3Configuration requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration = null;
            
             // populate S3Configuration
            var requestLogDeliveryConfiguration_logDeliveryConfiguration_S3ConfigurationIsNull = true;
            requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration = new Amazon.TimestreamInfluxDB.Model.S3Configuration();
            System.String requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_s3Configuration_BucketName = null;
            if (cmdletContext.S3Configuration_BucketName != null)
            {
                requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_s3Configuration_BucketName = cmdletContext.S3Configuration_BucketName;
            }
            if (requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_s3Configuration_BucketName != null)
            {
                requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration.BucketName = requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_s3Configuration_BucketName;
                requestLogDeliveryConfiguration_logDeliveryConfiguration_S3ConfigurationIsNull = false;
            }
            System.Boolean? requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_s3Configuration_Enabled = null;
            if (cmdletContext.S3Configuration_Enabled != null)
            {
                requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_s3Configuration_Enabled = cmdletContext.S3Configuration_Enabled.Value;
            }
            if (requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_s3Configuration_Enabled != null)
            {
                requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration.Enabled = requestLogDeliveryConfiguration_logDeliveryConfiguration_S3Configuration_s3Configuration_Enabled.Value;
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
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
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
        
        private Amazon.TimestreamInfluxDB.Model.UpdateDbClusterResponse CallAWSServiceOperation(IAmazonTimestreamInfluxDB client, Amazon.TimestreamInfluxDB.Model.UpdateDbClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Timestream InfluxDB", "UpdateDbCluster");
            try
            {
                #if DESKTOP
                return client.UpdateDbCluster(request);
                #elif CORECLR
                return client.UpdateDbClusterAsync(request).GetAwaiter().GetResult();
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
            public System.String DbClusterId { get; set; }
            public Amazon.TimestreamInfluxDB.DbInstanceType DbInstanceType { get; set; }
            public System.String DbParameterGroupIdentifier { get; set; }
            public Amazon.TimestreamInfluxDB.FailoverMode FailoverMode { get; set; }
            public System.String S3Configuration_BucketName { get; set; }
            public System.Boolean? S3Configuration_Enabled { get; set; }
            public System.String MaintenanceSchedule_PreferredMaintenanceWindow { get; set; }
            public System.String MaintenanceSchedule_Timezone { get; set; }
            public System.Int32? Port { get; set; }
            public System.Func<Amazon.TimestreamInfluxDB.Model.UpdateDbClusterResponse, UpdateTIDBDbClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DbClusterStatus;
        }
        
    }
}
