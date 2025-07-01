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
using Amazon.Odb;
using Amazon.Odb.Model;

namespace Amazon.PowerShell.Cmdlets.ODB
{
    /// <summary>
    /// Creates a VM cluster on the specified Exadata infrastructure.
    /// </summary>
    [Cmdlet("New", "ODBCloudVmCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Odb.Model.CreateCloudVmClusterResponse")]
    [AWSCmdlet("Calls the Oracle Database@Amazon Web Services CreateCloudVmCluster API operation.", Operation = new[] {"CreateCloudVmCluster"}, SelectReturnType = typeof(Amazon.Odb.Model.CreateCloudVmClusterResponse))]
    [AWSCmdletOutput("Amazon.Odb.Model.CreateCloudVmClusterResponse",
        "This cmdlet returns an Amazon.Odb.Model.CreateCloudVmClusterResponse object containing multiple properties."
    )]
    public partial class NewODBCloudVmClusterCmdlet : AmazonOdbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CloudExadataInfrastructureId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Exadata infrastructure for this VM cluster.</para>
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
        public System.String CloudExadataInfrastructureId { get; set; }
        #endregion
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>A name for the Grid Infrastructure cluster. The name isn't case sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter CpuCoreCount
        /// <summary>
        /// <para>
        /// <para>The number of CPU cores to enable on the VM cluster.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? CpuCoreCount { get; set; }
        #endregion
        
        #region Parameter DataStorageSizeInTBs
        /// <summary>
        /// <para>
        /// <para>The size of the data disk group, in terabytes (TBs), to allocate for the VM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? DataStorageSizeInTBs { get; set; }
        #endregion
        
        #region Parameter DbNodeStorageSizeInGBs
        /// <summary>
        /// <para>
        /// <para>The amount of local node storage, in gigabytes (GBs), to allocate for the VM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DbNodeStorageSizeInGBs { get; set; }
        #endregion
        
        #region Parameter DbServer
        /// <summary>
        /// <para>
        /// <para>The list of database servers for the VM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DbServers")]
        public System.String[] DbServer { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>A user-friendly name for the VM cluster.</para>
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
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter GiVersion
        /// <summary>
        /// <para>
        /// <para>A valid software version of Oracle Grid Infrastructure (GI). To get the list of valid
        /// values, use the <c>ListGiVersions</c> operation and specify the shape of the Exadata
        /// infrastructure.</para><para>Example: <c>19.0.0.0</c></para>
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
        public System.String GiVersion { get; set; }
        #endregion
        
        #region Parameter Hostname
        /// <summary>
        /// <para>
        /// <para>The host name for the VM cluster.</para><para>Constraints:</para><ul><li><para>Can't be "localhost" or "hostname".</para></li><li><para>Can't contain "-version".</para></li><li><para>The maximum length of the combined hostname and domain is 63 characters.</para></li><li><para>The hostname must be unique within the subnet.</para></li></ul>
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
        public System.String Hostname { get; set; }
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
        
        #region Parameter IsLocalBackupEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable database backups to local Exadata storage for the VM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsLocalBackupEnabled { get; set; }
        #endregion
        
        #region Parameter IsSparseDiskgroupEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to create a sparse disk group for the VM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsSparseDiskgroupEnabled { get; set; }
        #endregion
        
        #region Parameter LicenseModel
        /// <summary>
        /// <para>
        /// <para>The Oracle license model to apply to the VM cluster.</para><para>Default: <c>LICENSE_INCLUDED</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.LicenseModel")]
        public Amazon.Odb.LicenseModel LicenseModel { get; set; }
        #endregion
        
        #region Parameter MemorySizeInGBs
        /// <summary>
        /// <para>
        /// <para>The amount of memory, in gigabytes (GBs), to allocate for the VM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MemorySizeInGBs { get; set; }
        #endregion
        
        #region Parameter OdbNetworkId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the ODB network for the VM cluster.</para>
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
        public System.String OdbNetworkId { get; set; }
        #endregion
        
        #region Parameter ScanListenerPortTcp
        /// <summary>
        /// <para>
        /// <para>The port number for TCP connections to the single client access name (SCAN) listener.
        /// </para><para>Valid values: <c>1024–8999</c> with the following exceptions: <c>2484</c>, <c>6100</c>,
        /// <c>6200</c>, <c>7060</c>, <c>7070</c>, <c>7085</c>, and <c>7879</c></para><para>Default: <c>1521</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScanListenerPortTcp { get; set; }
        #endregion
        
        #region Parameter SshPublicKey
        /// <summary>
        /// <para>
        /// <para>The public key portion of one or more key pairs used for SSH access to the VM cluster.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SshPublicKeys")]
        public System.String[] SshPublicKey { get; set; }
        #endregion
        
        #region Parameter SystemVersion
        /// <summary>
        /// <para>
        /// <para>The version of the operating system of the image for the VM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SystemVersion { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The list of resource tags to apply to the VM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter TimeZone
        /// <summary>
        /// <para>
        /// <para>The time zone for the VM cluster. For a list of valid values for time zone, you can
        /// check the options in the console.</para><para>Default: UTC</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TimeZone { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If you don't specify a client token, the Amazon Web Services SDK automatically
        /// generates a client token and uses it for the request to ensure idempotency. The client
        /// token is valid for up to 24 hours after it's first used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Odb.Model.CreateCloudVmClusterResponse).
        /// Specifying the name of a property of type Amazon.Odb.Model.CreateCloudVmClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CloudExadataInfrastructureId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CloudExadataInfrastructureId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CloudExadataInfrastructureId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CloudExadataInfrastructureId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ODBCloudVmCluster (CreateCloudVmCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Odb.Model.CreateCloudVmClusterResponse, NewODBCloudVmClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CloudExadataInfrastructureId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.CloudExadataInfrastructureId = this.CloudExadataInfrastructureId;
            #if MODULAR
            if (this.CloudExadataInfrastructureId == null && ParameterWasBound(nameof(this.CloudExadataInfrastructureId)))
            {
                WriteWarning("You are passing $null as a value for parameter CloudExadataInfrastructureId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClusterName = this.ClusterName;
            context.CpuCoreCount = this.CpuCoreCount;
            #if MODULAR
            if (this.CpuCoreCount == null && ParameterWasBound(nameof(this.CpuCoreCount)))
            {
                WriteWarning("You are passing $null as a value for parameter CpuCoreCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataCollectionOptions_IsDiagnosticsEventsEnabled = this.DataCollectionOptions_IsDiagnosticsEventsEnabled;
            context.DataCollectionOptions_IsHealthMonitoringEnabled = this.DataCollectionOptions_IsHealthMonitoringEnabled;
            context.DataCollectionOptions_IsIncidentLogsEnabled = this.DataCollectionOptions_IsIncidentLogsEnabled;
            context.DataStorageSizeInTBs = this.DataStorageSizeInTBs;
            context.DbNodeStorageSizeInGBs = this.DbNodeStorageSizeInGBs;
            if (this.DbServer != null)
            {
                context.DbServer = new List<System.String>(this.DbServer);
            }
            context.DisplayName = this.DisplayName;
            #if MODULAR
            if (this.DisplayName == null && ParameterWasBound(nameof(this.DisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter DisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GiVersion = this.GiVersion;
            #if MODULAR
            if (this.GiVersion == null && ParameterWasBound(nameof(this.GiVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter GiVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Hostname = this.Hostname;
            #if MODULAR
            if (this.Hostname == null && ParameterWasBound(nameof(this.Hostname)))
            {
                WriteWarning("You are passing $null as a value for parameter Hostname which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IsLocalBackupEnabled = this.IsLocalBackupEnabled;
            context.IsSparseDiskgroupEnabled = this.IsSparseDiskgroupEnabled;
            context.LicenseModel = this.LicenseModel;
            context.MemorySizeInGBs = this.MemorySizeInGBs;
            context.OdbNetworkId = this.OdbNetworkId;
            #if MODULAR
            if (this.OdbNetworkId == null && ParameterWasBound(nameof(this.OdbNetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter OdbNetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScanListenerPortTcp = this.ScanListenerPortTcp;
            if (this.SshPublicKey != null)
            {
                context.SshPublicKey = new List<System.String>(this.SshPublicKey);
            }
            #if MODULAR
            if (this.SshPublicKey == null && ParameterWasBound(nameof(this.SshPublicKey)))
            {
                WriteWarning("You are passing $null as a value for parameter SshPublicKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SystemVersion = this.SystemVersion;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.TimeZone = this.TimeZone;
            
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
            var request = new Amazon.Odb.Model.CreateCloudVmClusterRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CloudExadataInfrastructureId != null)
            {
                request.CloudExadataInfrastructureId = cmdletContext.CloudExadataInfrastructureId;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
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
            if (cmdletContext.DbServer != null)
            {
                request.DbServers = cmdletContext.DbServer;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.GiVersion != null)
            {
                request.GiVersion = cmdletContext.GiVersion;
            }
            if (cmdletContext.Hostname != null)
            {
                request.Hostname = cmdletContext.Hostname;
            }
            if (cmdletContext.IsLocalBackupEnabled != null)
            {
                request.IsLocalBackupEnabled = cmdletContext.IsLocalBackupEnabled.Value;
            }
            if (cmdletContext.IsSparseDiskgroupEnabled != null)
            {
                request.IsSparseDiskgroupEnabled = cmdletContext.IsSparseDiskgroupEnabled.Value;
            }
            if (cmdletContext.LicenseModel != null)
            {
                request.LicenseModel = cmdletContext.LicenseModel;
            }
            if (cmdletContext.MemorySizeInGBs != null)
            {
                request.MemorySizeInGBs = cmdletContext.MemorySizeInGBs.Value;
            }
            if (cmdletContext.OdbNetworkId != null)
            {
                request.OdbNetworkId = cmdletContext.OdbNetworkId;
            }
            if (cmdletContext.ScanListenerPortTcp != null)
            {
                request.ScanListenerPortTcp = cmdletContext.ScanListenerPortTcp.Value;
            }
            if (cmdletContext.SshPublicKey != null)
            {
                request.SshPublicKeys = cmdletContext.SshPublicKey;
            }
            if (cmdletContext.SystemVersion != null)
            {
                request.SystemVersion = cmdletContext.SystemVersion;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TimeZone != null)
            {
                request.TimeZone = cmdletContext.TimeZone;
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
        
        private Amazon.Odb.Model.CreateCloudVmClusterResponse CallAWSServiceOperation(IAmazonOdb client, Amazon.Odb.Model.CreateCloudVmClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Oracle Database@Amazon Web Services", "CreateCloudVmCluster");
            try
            {
                #if DESKTOP
                return client.CreateCloudVmCluster(request);
                #elif CORECLR
                return client.CreateCloudVmClusterAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String CloudExadataInfrastructureId { get; set; }
            public System.String ClusterName { get; set; }
            public System.Int32? CpuCoreCount { get; set; }
            public System.Boolean? DataCollectionOptions_IsDiagnosticsEventsEnabled { get; set; }
            public System.Boolean? DataCollectionOptions_IsHealthMonitoringEnabled { get; set; }
            public System.Boolean? DataCollectionOptions_IsIncidentLogsEnabled { get; set; }
            public System.Double? DataStorageSizeInTBs { get; set; }
            public System.Int32? DbNodeStorageSizeInGBs { get; set; }
            public List<System.String> DbServer { get; set; }
            public System.String DisplayName { get; set; }
            public System.String GiVersion { get; set; }
            public System.String Hostname { get; set; }
            public System.Boolean? IsLocalBackupEnabled { get; set; }
            public System.Boolean? IsSparseDiskgroupEnabled { get; set; }
            public Amazon.Odb.LicenseModel LicenseModel { get; set; }
            public System.Int32? MemorySizeInGBs { get; set; }
            public System.String OdbNetworkId { get; set; }
            public System.Int32? ScanListenerPortTcp { get; set; }
            public List<System.String> SshPublicKey { get; set; }
            public System.String SystemVersion { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String TimeZone { get; set; }
            public System.Func<Amazon.Odb.Model.CreateCloudVmClusterResponse, NewODBCloudVmClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
