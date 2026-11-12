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
using Amazon.Odb;
using Amazon.Odb.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ODB
{
    /// <summary>
    /// Updates the properties of the specified VM cluster.
    /// </summary>
    [Cmdlet("Update", "ODBCloudVmCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Odb.Model.UpdateCloudVmClusterResponse")]
    [AWSCmdlet("Calls the Oracle Database@Amazon Web Services UpdateCloudVmCluster API operation.", Operation = new[] {"UpdateCloudVmCluster"}, SelectReturnType = typeof(Amazon.Odb.Model.UpdateCloudVmClusterResponse))]
    [AWSCmdletOutput("Amazon.Odb.Model.UpdateCloudVmClusterResponse",
        "This cmdlet returns an Amazon.Odb.Model.UpdateCloudVmClusterResponse object containing multiple properties."
    )]
    public partial class UpdateODBCloudVmClusterCmdlet : AmazonOdbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CloudVmClusterId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the VM cluster to update.</para>
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
        public System.String CloudVmClusterId { get; set; }
        #endregion
        
        #region Parameter CpuCoreCount
        /// <summary>
        /// <para>
        /// <para>The number of CPU cores to enable on the VM cluster. If you don't specify a value,
        /// the existing number of CPU cores is retained.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? CpuCoreCount { get; set; }
        #endregion
        
        #region Parameter DataStorageSizeInTBs
        /// <summary>
        /// <para>
        /// <para>The size of the data disk group, in terabytes (TB), to allocate for the VM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? DataStorageSizeInTBs { get; set; }
        #endregion
        
        #region Parameter DbNodeStorageSizeInGBs
        /// <summary>
        /// <para>
        /// <para>The amount of local node storage, in gigabytes (GB), to allocate for the VM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DbNodeStorageSizeInGBs { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>A new user-friendly name for the VM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter DataCollectionOptions_IsDiagnosticsEventsEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether diagnostic collection is enabled for the VM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DataCollectionOptions_IsDiagnosticsEventsEnabled { get; set; }
        #endregion
        
        #region Parameter DataCollectionOptions_IsHealthMonitoringEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether health monitoring is enabled for the VM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DataCollectionOptions_IsHealthMonitoringEnabled { get; set; }
        #endregion
        
        #region Parameter DataCollectionOptions_IsIncidentLogsEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether incident logs are enabled for the cloud VM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DataCollectionOptions_IsIncidentLogsEnabled { get; set; }
        #endregion
        
        #region Parameter LicenseModel
        /// <summary>
        /// <para>
        /// <para>The Oracle license model to apply to the VM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.LicenseModel")]
        public Amazon.Odb.LicenseModel LicenseModel { get; set; }
        #endregion
        
        #region Parameter MemorySizeInGBs
        /// <summary>
        /// <para>
        /// <para>The amount of memory, in gigabytes (GB), to allocate for the VM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MemorySizeInGBs { get; set; }
        #endregion
        
        #region Parameter SshPublicKey
        /// <summary>
        /// <para>
        /// <para>The public key portion of one or more key pairs used for SSH access to the VM cluster.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SshPublicKeys")]
        public System.String[] SshPublicKey { get; set; }
        #endregion
        
        #region Parameter StorageSizeInGBs
        /// <summary>
        /// <para>
        /// <para>The amount of local node storage, in gigabytes (GB), to allocate to the VM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StorageSizeInGBs { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Odb.Model.UpdateCloudVmClusterResponse).
        /// Specifying the name of a property of type Amazon.Odb.Model.UpdateCloudVmClusterResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CloudVmClusterId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ODBCloudVmCluster (UpdateCloudVmCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Odb.Model.UpdateCloudVmClusterResponse, UpdateODBCloudVmClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CloudVmClusterId = this.CloudVmClusterId;
            #if MODULAR
            if (this.CloudVmClusterId == null && ParameterWasBound(nameof(this.CloudVmClusterId)))
            {
                WriteWarning("You are passing $null as a value for parameter CloudVmClusterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CpuCoreCount = this.CpuCoreCount;
            context.DataCollectionOptions_IsDiagnosticsEventsEnabled = this.DataCollectionOptions_IsDiagnosticsEventsEnabled;
            context.DataCollectionOptions_IsHealthMonitoringEnabled = this.DataCollectionOptions_IsHealthMonitoringEnabled;
            context.DataCollectionOptions_IsIncidentLogsEnabled = this.DataCollectionOptions_IsIncidentLogsEnabled;
            context.DataStorageSizeInTBs = this.DataStorageSizeInTBs;
            context.DbNodeStorageSizeInGBs = this.DbNodeStorageSizeInGBs;
            context.DisplayName = this.DisplayName;
            context.LicenseModel = this.LicenseModel;
            context.MemorySizeInGBs = this.MemorySizeInGBs;
            if (this.SshPublicKey != null)
            {
                context.SshPublicKey = new List<System.String>(this.SshPublicKey);
            }
            context.StorageSizeInGBs = this.StorageSizeInGBs;
            
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
            var request = new Amazon.Odb.Model.UpdateCloudVmClusterRequest();
            
            if (cmdletContext.CloudVmClusterId != null)
            {
                request.CloudVmClusterId = cmdletContext.CloudVmClusterId;
            }
            if (cmdletContext.CpuCoreCount != null)
            {
                request.CpuCoreCount = cmdletContext.CpuCoreCount.Value;
            }
            
             // populate DataCollectionOptions
            var requestDataCollectionOptionsIsNull = true;
            request.DataCollectionOptions = new Amazon.Odb.Model.DataCollectionOptions();
            System.Boolean? requestDataCollectionOptions_dataCollectionOptions_IsDiagnosticsEventsEnabled = null;
            if (cmdletContext.DataCollectionOptions_IsDiagnosticsEventsEnabled != null)
            {
                requestDataCollectionOptions_dataCollectionOptions_IsDiagnosticsEventsEnabled = cmdletContext.DataCollectionOptions_IsDiagnosticsEventsEnabled.Value;
            }
            if (requestDataCollectionOptions_dataCollectionOptions_IsDiagnosticsEventsEnabled != null)
            {
                request.DataCollectionOptions.IsDiagnosticsEventsEnabled = requestDataCollectionOptions_dataCollectionOptions_IsDiagnosticsEventsEnabled.Value;
                requestDataCollectionOptionsIsNull = false;
            }
            System.Boolean? requestDataCollectionOptions_dataCollectionOptions_IsHealthMonitoringEnabled = null;
            if (cmdletContext.DataCollectionOptions_IsHealthMonitoringEnabled != null)
            {
                requestDataCollectionOptions_dataCollectionOptions_IsHealthMonitoringEnabled = cmdletContext.DataCollectionOptions_IsHealthMonitoringEnabled.Value;
            }
            if (requestDataCollectionOptions_dataCollectionOptions_IsHealthMonitoringEnabled != null)
            {
                request.DataCollectionOptions.IsHealthMonitoringEnabled = requestDataCollectionOptions_dataCollectionOptions_IsHealthMonitoringEnabled.Value;
                requestDataCollectionOptionsIsNull = false;
            }
            System.Boolean? requestDataCollectionOptions_dataCollectionOptions_IsIncidentLogsEnabled = null;
            if (cmdletContext.DataCollectionOptions_IsIncidentLogsEnabled != null)
            {
                requestDataCollectionOptions_dataCollectionOptions_IsIncidentLogsEnabled = cmdletContext.DataCollectionOptions_IsIncidentLogsEnabled.Value;
            }
            if (requestDataCollectionOptions_dataCollectionOptions_IsIncidentLogsEnabled != null)
            {
                request.DataCollectionOptions.IsIncidentLogsEnabled = requestDataCollectionOptions_dataCollectionOptions_IsIncidentLogsEnabled.Value;
                requestDataCollectionOptionsIsNull = false;
            }
             // determine if request.DataCollectionOptions should be set to null
            if (requestDataCollectionOptionsIsNull)
            {
                request.DataCollectionOptions = null;
            }
            if (cmdletContext.DataStorageSizeInTBs != null)
            {
                request.DataStorageSizeInTBs = cmdletContext.DataStorageSizeInTBs.Value;
            }
            if (cmdletContext.DbNodeStorageSizeInGBs != null)
            {
                request.DbNodeStorageSizeInGBs = cmdletContext.DbNodeStorageSizeInGBs.Value;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.LicenseModel != null)
            {
                request.LicenseModel = cmdletContext.LicenseModel;
            }
            if (cmdletContext.MemorySizeInGBs != null)
            {
                request.MemorySizeInGBs = cmdletContext.MemorySizeInGBs.Value;
            }
            if (cmdletContext.SshPublicKey != null)
            {
                request.SshPublicKeys = cmdletContext.SshPublicKey;
            }
            if (cmdletContext.StorageSizeInGBs != null)
            {
                request.StorageSizeInGBs = cmdletContext.StorageSizeInGBs.Value;
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
        
        private Amazon.Odb.Model.UpdateCloudVmClusterResponse CallAWSServiceOperation(IAmazonOdb client, Amazon.Odb.Model.UpdateCloudVmClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Oracle Database@Amazon Web Services", "UpdateCloudVmCluster");
            try
            {
                return client.UpdateCloudVmClusterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CloudVmClusterId { get; set; }
            public System.Int32? CpuCoreCount { get; set; }
            public System.Boolean? DataCollectionOptions_IsDiagnosticsEventsEnabled { get; set; }
            public System.Boolean? DataCollectionOptions_IsHealthMonitoringEnabled { get; set; }
            public System.Boolean? DataCollectionOptions_IsIncidentLogsEnabled { get; set; }
            public System.Double? DataStorageSizeInTBs { get; set; }
            public System.Int32? DbNodeStorageSizeInGBs { get; set; }
            public System.String DisplayName { get; set; }
            public Amazon.Odb.LicenseModel LicenseModel { get; set; }
            public System.Int32? MemorySizeInGBs { get; set; }
            public List<System.String> SshPublicKey { get; set; }
            public System.Int32? StorageSizeInGBs { get; set; }
            public System.Func<Amazon.Odb.Model.UpdateCloudVmClusterResponse, UpdateODBCloudVmClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
