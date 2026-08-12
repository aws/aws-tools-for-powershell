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
    /// Creates an Exascale VM cluster.
    /// </summary>
    [Cmdlet("New", "ODBExadbVmCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Odb.Model.CreateExadbVmClusterResponse")]
    [AWSCmdlet("Calls the Oracle Database@Amazon Web Services CreateExadbVmCluster API operation.", Operation = new[] {"CreateExadbVmCluster"}, SelectReturnType = typeof(Amazon.Odb.Model.CreateExadbVmClusterResponse))]
    [AWSCmdletOutput("Amazon.Odb.Model.CreateExadbVmClusterResponse",
        "This cmdlet returns an Amazon.Odb.Model.CreateExadbVmClusterResponse object containing multiple properties."
    )]
    public partial class NewODBExadbVmClusterCmdlet : AmazonOdbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>A name for the Grid Infrastructure cluster. The name isn't case sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>A user-friendly name for the Exascale VM cluster.</para>
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
        
        #region Parameter EnabledEcpuCount
        /// <summary>
        /// <para>
        /// <para>The number of ECPUs to enable for the Exascale VM cluster.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? EnabledEcpuCount { get; set; }
        #endregion
        
        #region Parameter ExascaleDbStorageVaultId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Exascale storage vault for this Exascale VM cluster.</para>
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
        public System.String ExascaleDbStorageVaultId { get; set; }
        #endregion
        
        #region Parameter GridImageId
        /// <summary>
        /// <para>
        /// <para>The Grid Infrastructure software image ID for the Exascale VM cluster.</para>
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
        public System.String GridImageId { get; set; }
        #endregion
        
        #region Parameter Hostname
        /// <summary>
        /// <para>
        /// <para>The host name for the Exascale VM cluster.</para>
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
        
        #region Parameter LicenseModel
        /// <summary>
        /// <para>
        /// <para>The Oracle license model to apply to the Exascale VM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.LicenseModel")]
        public Amazon.Odb.LicenseModel LicenseModel { get; set; }
        #endregion
        
        #region Parameter NodeCount
        /// <summary>
        /// <para>
        /// <para>The number of nodes in the Exascale VM cluster.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? NodeCount { get; set; }
        #endregion
        
        #region Parameter OdbNetworkId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the ODB network for the Exascale VM cluster.</para>
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
        /// <para>The port number for TCP connections to the single client access name (SCAN) listener.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScanListenerPortTcp { get; set; }
        #endregion
        
        #region Parameter ScanListenerPortTcpSsl
        /// <summary>
        /// <para>
        /// <para>The port number for TCP connections with SSL to the single client access name (SCAN)
        /// listener.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScanListenerPortTcpSsl { get; set; }
        #endregion
        
        #region Parameter Shape
        /// <summary>
        /// <para>
        /// <para>The shape of the Exascale VM cluster.</para>
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
        public System.String Shape { get; set; }
        #endregion
        
        #region Parameter ShapeAttribute
        /// <summary>
        /// <para>
        /// <para>The shape attribute for the Exascale VM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.ShapeAttribute")]
        public Amazon.Odb.ShapeAttribute ShapeAttribute { get; set; }
        #endregion
        
        #region Parameter SshPublicKey
        /// <summary>
        /// <para>
        /// <para>The public key portion of one or more key pairs used for SSH access to the Exascale
        /// VM cluster.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// <para>The version of the operating system of the image for the Exascale VM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SystemVersion { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The list of resource tags to apply to the Exascale VM cluster.</para><para />
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
        
        #region Parameter TimeZone
        /// <summary>
        /// <para>
        /// <para>The time zone for the Exascale VM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TimeZone { get; set; }
        #endregion
        
        #region Parameter TotalEcpuCount
        /// <summary>
        /// <para>
        /// <para>The total number of ECPUs for the Exascale VM cluster.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? TotalEcpuCount { get; set; }
        #endregion
        
        #region Parameter VmFileSystemStorageTotalSizeInGBs
        /// <summary>
        /// <para>
        /// <para>The total amount of file system storage, in gigabytes (GB), for the Exascale VM cluster.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? VmFileSystemStorageTotalSizeInGBs { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If you don't specify a client token, the Amazon Web Services SDK automatically
        /// generates one and uses it for the request to ensure idempotency. The client token
        /// is valid for up to 24 hours after it's first used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Odb.Model.CreateExadbVmClusterResponse).
        /// Specifying the name of a property of type Amazon.Odb.Model.CreateExadbVmClusterResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ODBExadbVmCluster (CreateExadbVmCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Odb.Model.CreateExadbVmClusterResponse, NewODBExadbVmClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ClusterName = this.ClusterName;
            context.DataCollectionOptions_IsDiagnosticsEventsEnabled = this.DataCollectionOptions_IsDiagnosticsEventsEnabled;
            context.DataCollectionOptions_IsHealthMonitoringEnabled = this.DataCollectionOptions_IsHealthMonitoringEnabled;
            context.DataCollectionOptions_IsIncidentLogsEnabled = this.DataCollectionOptions_IsIncidentLogsEnabled;
            context.DisplayName = this.DisplayName;
            #if MODULAR
            if (this.DisplayName == null && ParameterWasBound(nameof(this.DisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter DisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnabledEcpuCount = this.EnabledEcpuCount;
            #if MODULAR
            if (this.EnabledEcpuCount == null && ParameterWasBound(nameof(this.EnabledEcpuCount)))
            {
                WriteWarning("You are passing $null as a value for parameter EnabledEcpuCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExascaleDbStorageVaultId = this.ExascaleDbStorageVaultId;
            #if MODULAR
            if (this.ExascaleDbStorageVaultId == null && ParameterWasBound(nameof(this.ExascaleDbStorageVaultId)))
            {
                WriteWarning("You are passing $null as a value for parameter ExascaleDbStorageVaultId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GridImageId = this.GridImageId;
            #if MODULAR
            if (this.GridImageId == null && ParameterWasBound(nameof(this.GridImageId)))
            {
                WriteWarning("You are passing $null as a value for parameter GridImageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Hostname = this.Hostname;
            #if MODULAR
            if (this.Hostname == null && ParameterWasBound(nameof(this.Hostname)))
            {
                WriteWarning("You are passing $null as a value for parameter Hostname which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LicenseModel = this.LicenseModel;
            context.NodeCount = this.NodeCount;
            #if MODULAR
            if (this.NodeCount == null && ParameterWasBound(nameof(this.NodeCount)))
            {
                WriteWarning("You are passing $null as a value for parameter NodeCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OdbNetworkId = this.OdbNetworkId;
            #if MODULAR
            if (this.OdbNetworkId == null && ParameterWasBound(nameof(this.OdbNetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter OdbNetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScanListenerPortTcp = this.ScanListenerPortTcp;
            context.ScanListenerPortTcpSsl = this.ScanListenerPortTcpSsl;
            context.Shape = this.Shape;
            #if MODULAR
            if (this.Shape == null && ParameterWasBound(nameof(this.Shape)))
            {
                WriteWarning("You are passing $null as a value for parameter Shape which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShapeAttribute = this.ShapeAttribute;
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
            context.TotalEcpuCount = this.TotalEcpuCount;
            #if MODULAR
            if (this.TotalEcpuCount == null && ParameterWasBound(nameof(this.TotalEcpuCount)))
            {
                WriteWarning("You are passing $null as a value for parameter TotalEcpuCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VmFileSystemStorageTotalSizeInGBs = this.VmFileSystemStorageTotalSizeInGBs;
            #if MODULAR
            if (this.VmFileSystemStorageTotalSizeInGBs == null && ParameterWasBound(nameof(this.VmFileSystemStorageTotalSizeInGBs)))
            {
                WriteWarning("You are passing $null as a value for parameter VmFileSystemStorageTotalSizeInGBs which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.Odb.Model.CreateExadbVmClusterRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
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
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.EnabledEcpuCount != null)
            {
                request.EnabledEcpuCount = cmdletContext.EnabledEcpuCount.Value;
            }
            if (cmdletContext.ExascaleDbStorageVaultId != null)
            {
                request.ExascaleDbStorageVaultId = cmdletContext.ExascaleDbStorageVaultId;
            }
            if (cmdletContext.GridImageId != null)
            {
                request.GridImageId = cmdletContext.GridImageId;
            }
            if (cmdletContext.Hostname != null)
            {
                request.Hostname = cmdletContext.Hostname;
            }
            if (cmdletContext.LicenseModel != null)
            {
                request.LicenseModel = cmdletContext.LicenseModel;
            }
            if (cmdletContext.NodeCount != null)
            {
                request.NodeCount = cmdletContext.NodeCount.Value;
            }
            if (cmdletContext.OdbNetworkId != null)
            {
                request.OdbNetworkId = cmdletContext.OdbNetworkId;
            }
            if (cmdletContext.ScanListenerPortTcp != null)
            {
                request.ScanListenerPortTcp = cmdletContext.ScanListenerPortTcp.Value;
            }
            if (cmdletContext.ScanListenerPortTcpSsl != null)
            {
                request.ScanListenerPortTcpSsl = cmdletContext.ScanListenerPortTcpSsl.Value;
            }
            if (cmdletContext.Shape != null)
            {
                request.Shape = cmdletContext.Shape;
            }
            if (cmdletContext.ShapeAttribute != null)
            {
                request.ShapeAttribute = cmdletContext.ShapeAttribute;
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
            if (cmdletContext.TotalEcpuCount != null)
            {
                request.TotalEcpuCount = cmdletContext.TotalEcpuCount.Value;
            }
            if (cmdletContext.VmFileSystemStorageTotalSizeInGBs != null)
            {
                request.VmFileSystemStorageTotalSizeInGBs = cmdletContext.VmFileSystemStorageTotalSizeInGBs.Value;
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
        
        private Amazon.Odb.Model.CreateExadbVmClusterResponse CallAWSServiceOperation(IAmazonOdb client, Amazon.Odb.Model.CreateExadbVmClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Oracle Database@Amazon Web Services", "CreateExadbVmCluster");
            try
            {
                return client.CreateExadbVmClusterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClusterName { get; set; }
            public System.Boolean? DataCollectionOptions_IsDiagnosticsEventsEnabled { get; set; }
            public System.Boolean? DataCollectionOptions_IsHealthMonitoringEnabled { get; set; }
            public System.Boolean? DataCollectionOptions_IsIncidentLogsEnabled { get; set; }
            public System.String DisplayName { get; set; }
            public System.Int32? EnabledEcpuCount { get; set; }
            public System.String ExascaleDbStorageVaultId { get; set; }
            public System.String GridImageId { get; set; }
            public System.String Hostname { get; set; }
            public Amazon.Odb.LicenseModel LicenseModel { get; set; }
            public System.Int32? NodeCount { get; set; }
            public System.String OdbNetworkId { get; set; }
            public System.Int32? ScanListenerPortTcp { get; set; }
            public System.Int32? ScanListenerPortTcpSsl { get; set; }
            public System.String Shape { get; set; }
            public Amazon.Odb.ShapeAttribute ShapeAttribute { get; set; }
            public List<System.String> SshPublicKey { get; set; }
            public System.String SystemVersion { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String TimeZone { get; set; }
            public System.Int32? TotalEcpuCount { get; set; }
            public System.Int32? VmFileSystemStorageTotalSizeInGBs { get; set; }
            public System.Func<Amazon.Odb.Model.CreateExadbVmClusterResponse, NewODBExadbVmClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
