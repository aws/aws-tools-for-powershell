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
using Amazon.GroundStation;
using Amazon.GroundStation.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GS
{
    /// <summary>
    /// Updates the <c>Config</c> used when scheduling contacts.
    /// 
    ///  
    /// <para>
    /// Updating a <c>Config</c> will not update the execution parameters for existing future
    /// contacts scheduled with this <c>Config</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "GSConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GroundStation.Model.UpdateConfigResponse")]
    [AWSCmdlet("Calls the AWS Ground Station UpdateConfig API operation.", Operation = new[] {"UpdateConfig"}, SelectReturnType = typeof(Amazon.GroundStation.Model.UpdateConfigResponse))]
    [AWSCmdletOutput("Amazon.GroundStation.Model.UpdateConfigResponse",
        "This cmdlet returns an Amazon.GroundStation.Model.UpdateConfigResponse object containing multiple properties."
    )]
    public partial class UpdateGSConfigCmdlet : AmazonGroundStationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConfigData_AntennaDownlinkConfig
        /// <summary>
        /// <para>
        /// <para>Information about how AWS Ground Station should configure an antenna for downlink
        /// during a contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.GroundStation.Model.AntennaDownlinkConfig ConfigData_AntennaDownlinkConfig { get; set; }
        #endregion
        
        #region Parameter ConfigData_AntennaDownlinkDemodDecodeConfig
        /// <summary>
        /// <para>
        /// <para>Information about how AWS Ground Station should conﬁgure an antenna for downlink demod
        /// decode during a contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.GroundStation.Model.AntennaDownlinkDemodDecodeConfig ConfigData_AntennaDownlinkDemodDecodeConfig { get; set; }
        #endregion
        
        #region Parameter ConfigData_AntennaUplinkConfig
        /// <summary>
        /// <para>
        /// <para>Information about how AWS Ground Station should conﬁgure an antenna for uplink during
        /// a contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.GroundStation.Model.AntennaUplinkConfig ConfigData_AntennaUplinkConfig { get; set; }
        #endregion
        
        #region Parameter S3RecordingConfig_BucketArn
        /// <summary>
        /// <para>
        /// <para>ARN of the bucket to record to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigData_S3RecordingConfig_BucketArn")]
        public System.String S3RecordingConfig_BucketArn { get; set; }
        #endregion
        
        #region Parameter ConfigId
        /// <summary>
        /// <para>
        /// <para>UUID of a <c>Config</c>.</para>
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
        public System.String ConfigId { get; set; }
        #endregion
        
        #region Parameter ConfigType
        /// <summary>
        /// <para>
        /// <para>Type of a <c>Config</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.GroundStation.ConfigCapabilityType")]
        public Amazon.GroundStation.ConfigCapabilityType ConfigType { get; set; }
        #endregion
        
        #region Parameter ConfigData_DataflowEndpointConfig
        /// <summary>
        /// <para>
        /// <para>Information about the dataflow endpoint <c>Config</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.GroundStation.Model.DataflowEndpointConfig ConfigData_DataflowEndpointConfig { get; set; }
        #endregion
        
        #region Parameter ConfigData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisDataStreamArn
        /// <summary>
        /// <para>
        /// <para>ARN of the Kinesis Data Stream to deliver telemetry to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisDataStreamArn { get; set; }
        #endregion
        
        #region Parameter ConfigData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisRoleArn
        /// <summary>
        /// <para>
        /// <para>ARN of the IAM Role used by AWS Ground Station to deliver telemetry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisRoleArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Name of a <c>Config</c>.</para>
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
        
        #region Parameter S3RecordingConfig_Prefix
        /// <summary>
        /// <para>
        /// <para>S3 Key prefix to prefice data files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigData_S3RecordingConfig_Prefix")]
        public System.String S3RecordingConfig_Prefix { get; set; }
        #endregion
        
        #region Parameter S3RecordingConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>ARN of the role Ground Station assumes to write data to the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigData_S3RecordingConfig_RoleArn")]
        public System.String S3RecordingConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter ConfigData_TelemetrySinkConfig_TelemetrySinkType
        /// <summary>
        /// <para>
        /// <para>The type of telemetry sink.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GroundStation.TelemetrySinkType")]
        public Amazon.GroundStation.TelemetrySinkType ConfigData_TelemetrySinkConfig_TelemetrySinkType { get; set; }
        #endregion
        
        #region Parameter ConfigData_TrackingConfig
        /// <summary>
        /// <para>
        /// <para>Object that determines whether tracking should be used during a contact executed with
        /// this <c>Config</c> in the mission profile. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.GroundStation.Model.TrackingConfig ConfigData_TrackingConfig { get; set; }
        #endregion
        
        #region Parameter ConfigData_UplinkEchoConfig
        /// <summary>
        /// <para>
        /// <para>Information about an uplink echo <c>Config</c>.</para><para>Parameters from the <c>AntennaUplinkConfig</c>, corresponding to the specified <c>
        /// AntennaUplinkConfigArn</c>, are used when this <c>UplinkEchoConfig</c> is used in
        /// a contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.GroundStation.Model.UplinkEchoConfig ConfigData_UplinkEchoConfig { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GroundStation.Model.UpdateConfigResponse).
        /// Specifying the name of a property of type Amazon.GroundStation.Model.UpdateConfigResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GSConfig (UpdateConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GroundStation.Model.UpdateConfigResponse, UpdateGSConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigData_AntennaDownlinkConfig = this.ConfigData_AntennaDownlinkConfig;
            context.ConfigData_AntennaDownlinkDemodDecodeConfig = this.ConfigData_AntennaDownlinkDemodDecodeConfig;
            context.ConfigData_AntennaUplinkConfig = this.ConfigData_AntennaUplinkConfig;
            context.ConfigData_DataflowEndpointConfig = this.ConfigData_DataflowEndpointConfig;
            context.S3RecordingConfig_BucketArn = this.S3RecordingConfig_BucketArn;
            context.S3RecordingConfig_Prefix = this.S3RecordingConfig_Prefix;
            context.S3RecordingConfig_RoleArn = this.S3RecordingConfig_RoleArn;
            context.ConfigData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisDataStreamArn = this.ConfigData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisDataStreamArn;
            context.ConfigData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisRoleArn = this.ConfigData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisRoleArn;
            context.ConfigData_TelemetrySinkConfig_TelemetrySinkType = this.ConfigData_TelemetrySinkConfig_TelemetrySinkType;
            context.ConfigData_TrackingConfig = this.ConfigData_TrackingConfig;
            context.ConfigData_UplinkEchoConfig = this.ConfigData_UplinkEchoConfig;
            context.ConfigId = this.ConfigId;
            #if MODULAR
            if (this.ConfigId == null && ParameterWasBound(nameof(this.ConfigId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConfigType = this.ConfigType;
            #if MODULAR
            if (this.ConfigType == null && ParameterWasBound(nameof(this.ConfigType)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GroundStation.Model.UpdateConfigRequest();
            
            
             // populate ConfigData
            var requestConfigDataIsNull = true;
            request.ConfigData = new Amazon.GroundStation.Model.ConfigTypeData();
            Amazon.GroundStation.Model.AntennaDownlinkConfig requestConfigData_configData_AntennaDownlinkConfig = null;
            if (cmdletContext.ConfigData_AntennaDownlinkConfig != null)
            {
                requestConfigData_configData_AntennaDownlinkConfig = cmdletContext.ConfigData_AntennaDownlinkConfig;
            }
            if (requestConfigData_configData_AntennaDownlinkConfig != null)
            {
                request.ConfigData.AntennaDownlinkConfig = requestConfigData_configData_AntennaDownlinkConfig;
                requestConfigDataIsNull = false;
            }
            Amazon.GroundStation.Model.AntennaDownlinkDemodDecodeConfig requestConfigData_configData_AntennaDownlinkDemodDecodeConfig = null;
            if (cmdletContext.ConfigData_AntennaDownlinkDemodDecodeConfig != null)
            {
                requestConfigData_configData_AntennaDownlinkDemodDecodeConfig = cmdletContext.ConfigData_AntennaDownlinkDemodDecodeConfig;
            }
            if (requestConfigData_configData_AntennaDownlinkDemodDecodeConfig != null)
            {
                request.ConfigData.AntennaDownlinkDemodDecodeConfig = requestConfigData_configData_AntennaDownlinkDemodDecodeConfig;
                requestConfigDataIsNull = false;
            }
            Amazon.GroundStation.Model.AntennaUplinkConfig requestConfigData_configData_AntennaUplinkConfig = null;
            if (cmdletContext.ConfigData_AntennaUplinkConfig != null)
            {
                requestConfigData_configData_AntennaUplinkConfig = cmdletContext.ConfigData_AntennaUplinkConfig;
            }
            if (requestConfigData_configData_AntennaUplinkConfig != null)
            {
                request.ConfigData.AntennaUplinkConfig = requestConfigData_configData_AntennaUplinkConfig;
                requestConfigDataIsNull = false;
            }
            Amazon.GroundStation.Model.DataflowEndpointConfig requestConfigData_configData_DataflowEndpointConfig = null;
            if (cmdletContext.ConfigData_DataflowEndpointConfig != null)
            {
                requestConfigData_configData_DataflowEndpointConfig = cmdletContext.ConfigData_DataflowEndpointConfig;
            }
            if (requestConfigData_configData_DataflowEndpointConfig != null)
            {
                request.ConfigData.DataflowEndpointConfig = requestConfigData_configData_DataflowEndpointConfig;
                requestConfigDataIsNull = false;
            }
            Amazon.GroundStation.Model.TrackingConfig requestConfigData_configData_TrackingConfig = null;
            if (cmdletContext.ConfigData_TrackingConfig != null)
            {
                requestConfigData_configData_TrackingConfig = cmdletContext.ConfigData_TrackingConfig;
            }
            if (requestConfigData_configData_TrackingConfig != null)
            {
                request.ConfigData.TrackingConfig = requestConfigData_configData_TrackingConfig;
                requestConfigDataIsNull = false;
            }
            Amazon.GroundStation.Model.UplinkEchoConfig requestConfigData_configData_UplinkEchoConfig = null;
            if (cmdletContext.ConfigData_UplinkEchoConfig != null)
            {
                requestConfigData_configData_UplinkEchoConfig = cmdletContext.ConfigData_UplinkEchoConfig;
            }
            if (requestConfigData_configData_UplinkEchoConfig != null)
            {
                request.ConfigData.UplinkEchoConfig = requestConfigData_configData_UplinkEchoConfig;
                requestConfigDataIsNull = false;
            }
            Amazon.GroundStation.Model.TelemetrySinkConfig requestConfigData_configData_TelemetrySinkConfig = null;
            
             // populate TelemetrySinkConfig
            var requestConfigData_configData_TelemetrySinkConfigIsNull = true;
            requestConfigData_configData_TelemetrySinkConfig = new Amazon.GroundStation.Model.TelemetrySinkConfig();
            Amazon.GroundStation.TelemetrySinkType requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkType = null;
            if (cmdletContext.ConfigData_TelemetrySinkConfig_TelemetrySinkType != null)
            {
                requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkType = cmdletContext.ConfigData_TelemetrySinkConfig_TelemetrySinkType;
            }
            if (requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkType != null)
            {
                requestConfigData_configData_TelemetrySinkConfig.TelemetrySinkType = requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkType;
                requestConfigData_configData_TelemetrySinkConfigIsNull = false;
            }
            Amazon.GroundStation.Model.TelemetrySinkData requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData = null;
            
             // populate TelemetrySinkData
            var requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkDataIsNull = true;
            requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData = new Amazon.GroundStation.Model.TelemetrySinkData();
            Amazon.GroundStation.Model.KinesisDataStreamData requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData = null;
            
             // populate KinesisDataStreamData
            var requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamDataIsNull = true;
            requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData = new Amazon.GroundStation.Model.KinesisDataStreamData();
            System.String requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisDataStreamArn = null;
            if (cmdletContext.ConfigData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisDataStreamArn != null)
            {
                requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisDataStreamArn = cmdletContext.ConfigData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisDataStreamArn;
            }
            if (requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisDataStreamArn != null)
            {
                requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData.KinesisDataStreamArn = requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisDataStreamArn;
                requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamDataIsNull = false;
            }
            System.String requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisRoleArn = null;
            if (cmdletContext.ConfigData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisRoleArn != null)
            {
                requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisRoleArn = cmdletContext.ConfigData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisRoleArn;
            }
            if (requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisRoleArn != null)
            {
                requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData.KinesisRoleArn = requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisRoleArn;
                requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamDataIsNull = false;
            }
             // determine if requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData should be set to null
            if (requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamDataIsNull)
            {
                requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData = null;
            }
            if (requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData != null)
            {
                requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData.KinesisDataStreamData = requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData_configData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData;
                requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkDataIsNull = false;
            }
             // determine if requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData should be set to null
            if (requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkDataIsNull)
            {
                requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData = null;
            }
            if (requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData != null)
            {
                requestConfigData_configData_TelemetrySinkConfig.TelemetrySinkData = requestConfigData_configData_TelemetrySinkConfig_configData_TelemetrySinkConfig_TelemetrySinkData;
                requestConfigData_configData_TelemetrySinkConfigIsNull = false;
            }
             // determine if requestConfigData_configData_TelemetrySinkConfig should be set to null
            if (requestConfigData_configData_TelemetrySinkConfigIsNull)
            {
                requestConfigData_configData_TelemetrySinkConfig = null;
            }
            if (requestConfigData_configData_TelemetrySinkConfig != null)
            {
                request.ConfigData.TelemetrySinkConfig = requestConfigData_configData_TelemetrySinkConfig;
                requestConfigDataIsNull = false;
            }
            Amazon.GroundStation.Model.S3RecordingConfig requestConfigData_configData_S3RecordingConfig = null;
            
             // populate S3RecordingConfig
            var requestConfigData_configData_S3RecordingConfigIsNull = true;
            requestConfigData_configData_S3RecordingConfig = new Amazon.GroundStation.Model.S3RecordingConfig();
            System.String requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_BucketArn = null;
            if (cmdletContext.S3RecordingConfig_BucketArn != null)
            {
                requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_BucketArn = cmdletContext.S3RecordingConfig_BucketArn;
            }
            if (requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_BucketArn != null)
            {
                requestConfigData_configData_S3RecordingConfig.BucketArn = requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_BucketArn;
                requestConfigData_configData_S3RecordingConfigIsNull = false;
            }
            System.String requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_Prefix = null;
            if (cmdletContext.S3RecordingConfig_Prefix != null)
            {
                requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_Prefix = cmdletContext.S3RecordingConfig_Prefix;
            }
            if (requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_Prefix != null)
            {
                requestConfigData_configData_S3RecordingConfig.Prefix = requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_Prefix;
                requestConfigData_configData_S3RecordingConfigIsNull = false;
            }
            System.String requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_RoleArn = null;
            if (cmdletContext.S3RecordingConfig_RoleArn != null)
            {
                requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_RoleArn = cmdletContext.S3RecordingConfig_RoleArn;
            }
            if (requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_RoleArn != null)
            {
                requestConfigData_configData_S3RecordingConfig.RoleArn = requestConfigData_configData_S3RecordingConfig_s3RecordingConfig_RoleArn;
                requestConfigData_configData_S3RecordingConfigIsNull = false;
            }
             // determine if requestConfigData_configData_S3RecordingConfig should be set to null
            if (requestConfigData_configData_S3RecordingConfigIsNull)
            {
                requestConfigData_configData_S3RecordingConfig = null;
            }
            if (requestConfigData_configData_S3RecordingConfig != null)
            {
                request.ConfigData.S3RecordingConfig = requestConfigData_configData_S3RecordingConfig;
                requestConfigDataIsNull = false;
            }
             // determine if request.ConfigData should be set to null
            if (requestConfigDataIsNull)
            {
                request.ConfigData = null;
            }
            if (cmdletContext.ConfigId != null)
            {
                request.ConfigId = cmdletContext.ConfigId;
            }
            if (cmdletContext.ConfigType != null)
            {
                request.ConfigType = cmdletContext.ConfigType;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.GroundStation.Model.UpdateConfigResponse CallAWSServiceOperation(IAmazonGroundStation client, Amazon.GroundStation.Model.UpdateConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Ground Station", "UpdateConfig");
            try
            {
                return client.UpdateConfigAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.GroundStation.Model.AntennaDownlinkConfig ConfigData_AntennaDownlinkConfig { get; set; }
            public Amazon.GroundStation.Model.AntennaDownlinkDemodDecodeConfig ConfigData_AntennaDownlinkDemodDecodeConfig { get; set; }
            public Amazon.GroundStation.Model.AntennaUplinkConfig ConfigData_AntennaUplinkConfig { get; set; }
            public Amazon.GroundStation.Model.DataflowEndpointConfig ConfigData_DataflowEndpointConfig { get; set; }
            public System.String S3RecordingConfig_BucketArn { get; set; }
            public System.String S3RecordingConfig_Prefix { get; set; }
            public System.String S3RecordingConfig_RoleArn { get; set; }
            public System.String ConfigData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisDataStreamArn { get; set; }
            public System.String ConfigData_TelemetrySinkConfig_TelemetrySinkData_KinesisDataStreamData_KinesisRoleArn { get; set; }
            public Amazon.GroundStation.TelemetrySinkType ConfigData_TelemetrySinkConfig_TelemetrySinkType { get; set; }
            public Amazon.GroundStation.Model.TrackingConfig ConfigData_TrackingConfig { get; set; }
            public Amazon.GroundStation.Model.UplinkEchoConfig ConfigData_UplinkEchoConfig { get; set; }
            public System.String ConfigId { get; set; }
            public Amazon.GroundStation.ConfigCapabilityType ConfigType { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.GroundStation.Model.UpdateConfigResponse, UpdateGSConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
