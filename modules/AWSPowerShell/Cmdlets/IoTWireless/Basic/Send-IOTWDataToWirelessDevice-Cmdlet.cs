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
using Amazon.IoTWireless;
using Amazon.IoTWireless.Model;

namespace Amazon.PowerShell.Cmdlets.IOTW
{
    /// <summary>
    /// Sends a decrypted application data frame to a device.
    /// </summary>
    [Cmdlet("Send", "IOTWDataToWirelessDevice", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS IoT Wireless SendDataToWirelessDevice API operation.", Operation = new[] {"SendDataToWirelessDevice"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.SendDataToWirelessDeviceResponse))]
    [AWSCmdletOutput("System.String or Amazon.IoTWireless.Model.SendDataToWirelessDeviceResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IoTWireless.Model.SendDataToWirelessDeviceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SendIOTWDataToWirelessDeviceCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Sidewalk_AckModeRetryDurationSec
        /// <summary>
        /// <para>
        /// <para>The duration of time in seconds to retry sending the ACK.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WirelessMetadata_Sidewalk_AckModeRetryDurationSecs")]
        public System.Int32? Sidewalk_AckModeRetryDurationSec { get; set; }
        #endregion
        
        #region Parameter ParticipatingGateways_DownlinkMode
        /// <summary>
        /// <para>
        /// <para>Indicates whether to send the downlink message in sequential mode or concurrent mode,
        /// or to use only the chosen gateways from the previous uplink message transmission.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WirelessMetadata_LoRaWAN_ParticipatingGateways_DownlinkMode")]
        [AWSConstantClassSource("Amazon.IoTWireless.DownlinkMode")]
        public Amazon.IoTWireless.DownlinkMode ParticipatingGateways_DownlinkMode { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_FPort
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WirelessMetadata_LoRaWAN_FPort")]
        public System.Int32? LoRaWAN_FPort { get; set; }
        #endregion
        
        #region Parameter ParticipatingGateways_GatewayList
        /// <summary>
        /// <para>
        /// <para>The list of gateways that you want to use for sending the downlink data traffic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WirelessMetadata_LoRaWAN_ParticipatingGateways_GatewayList")]
        public Amazon.IoTWireless.Model.GatewayListItem[] ParticipatingGateways_GatewayList { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the wireless device to receive the data.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Sidewalk_MessageType
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WirelessMetadata_Sidewalk_MessageType")]
        [AWSConstantClassSource("Amazon.IoTWireless.MessageType")]
        public Amazon.IoTWireless.MessageType Sidewalk_MessageType { get; set; }
        #endregion
        
        #region Parameter PayloadData
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String PayloadData { get; set; }
        #endregion
        
        #region Parameter Sidewalk_Seq
        /// <summary>
        /// <para>
        /// <para>The sequence number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WirelessMetadata_Sidewalk_Seq")]
        public System.Int32? Sidewalk_Seq { get; set; }
        #endregion
        
        #region Parameter ParticipatingGateways_TransmissionInterval
        /// <summary>
        /// <para>
        /// <para>The duration of time for which AWS IoT Core for LoRaWAN will wait before transmitting
        /// the payload to the next gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WirelessMetadata_LoRaWAN_ParticipatingGateways_TransmissionInterval")]
        public System.Int32? ParticipatingGateways_TransmissionInterval { get; set; }
        #endregion
        
        #region Parameter TransmitMode
        /// <summary>
        /// <para>
        /// <para>The transmit mode to use to send data to the wireless device. Can be: <c>0</c> for
        /// UM (unacknowledge mode) or <c>1</c> for AM (acknowledge mode).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? TransmitMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MessageId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.SendDataToWirelessDeviceResponse).
        /// Specifying the name of a property of type Amazon.IoTWireless.Model.SendDataToWirelessDeviceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MessageId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-IOTWDataToWirelessDevice (SendDataToWirelessDevice)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.SendDataToWirelessDeviceResponse, SendIOTWDataToWirelessDeviceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PayloadData = this.PayloadData;
            #if MODULAR
            if (this.PayloadData == null && ParameterWasBound(nameof(this.PayloadData)))
            {
                WriteWarning("You are passing $null as a value for parameter PayloadData which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TransmitMode = this.TransmitMode;
            #if MODULAR
            if (this.TransmitMode == null && ParameterWasBound(nameof(this.TransmitMode)))
            {
                WriteWarning("You are passing $null as a value for parameter TransmitMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoRaWAN_FPort = this.LoRaWAN_FPort;
            context.ParticipatingGateways_DownlinkMode = this.ParticipatingGateways_DownlinkMode;
            if (this.ParticipatingGateways_GatewayList != null)
            {
                context.ParticipatingGateways_GatewayList = new List<Amazon.IoTWireless.Model.GatewayListItem>(this.ParticipatingGateways_GatewayList);
            }
            context.ParticipatingGateways_TransmissionInterval = this.ParticipatingGateways_TransmissionInterval;
            context.Sidewalk_AckModeRetryDurationSec = this.Sidewalk_AckModeRetryDurationSec;
            context.Sidewalk_MessageType = this.Sidewalk_MessageType;
            context.Sidewalk_Seq = this.Sidewalk_Seq;
            
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
            var request = new Amazon.IoTWireless.Model.SendDataToWirelessDeviceRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.PayloadData != null)
            {
                request.PayloadData = cmdletContext.PayloadData;
            }
            if (cmdletContext.TransmitMode != null)
            {
                request.TransmitMode = cmdletContext.TransmitMode.Value;
            }
            
             // populate WirelessMetadata
            var requestWirelessMetadataIsNull = true;
            request.WirelessMetadata = new Amazon.IoTWireless.Model.WirelessMetadata();
            Amazon.IoTWireless.Model.LoRaWANSendDataToDevice requestWirelessMetadata_wirelessMetadata_LoRaWAN = null;
            
             // populate LoRaWAN
            var requestWirelessMetadata_wirelessMetadata_LoRaWANIsNull = true;
            requestWirelessMetadata_wirelessMetadata_LoRaWAN = new Amazon.IoTWireless.Model.LoRaWANSendDataToDevice();
            System.Int32? requestWirelessMetadata_wirelessMetadata_LoRaWAN_loRaWAN_FPort = null;
            if (cmdletContext.LoRaWAN_FPort != null)
            {
                requestWirelessMetadata_wirelessMetadata_LoRaWAN_loRaWAN_FPort = cmdletContext.LoRaWAN_FPort.Value;
            }
            if (requestWirelessMetadata_wirelessMetadata_LoRaWAN_loRaWAN_FPort != null)
            {
                requestWirelessMetadata_wirelessMetadata_LoRaWAN.FPort = requestWirelessMetadata_wirelessMetadata_LoRaWAN_loRaWAN_FPort.Value;
                requestWirelessMetadata_wirelessMetadata_LoRaWANIsNull = false;
            }
            Amazon.IoTWireless.Model.ParticipatingGateways requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGateways = null;
            
             // populate ParticipatingGateways
            var requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGatewaysIsNull = true;
            requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGateways = new Amazon.IoTWireless.Model.ParticipatingGateways();
            Amazon.IoTWireless.DownlinkMode requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGateways_participatingGateways_DownlinkMode = null;
            if (cmdletContext.ParticipatingGateways_DownlinkMode != null)
            {
                requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGateways_participatingGateways_DownlinkMode = cmdletContext.ParticipatingGateways_DownlinkMode;
            }
            if (requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGateways_participatingGateways_DownlinkMode != null)
            {
                requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGateways.DownlinkMode = requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGateways_participatingGateways_DownlinkMode;
                requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGatewaysIsNull = false;
            }
            List<Amazon.IoTWireless.Model.GatewayListItem> requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGateways_participatingGateways_GatewayList = null;
            if (cmdletContext.ParticipatingGateways_GatewayList != null)
            {
                requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGateways_participatingGateways_GatewayList = cmdletContext.ParticipatingGateways_GatewayList;
            }
            if (requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGateways_participatingGateways_GatewayList != null)
            {
                requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGateways.GatewayList = requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGateways_participatingGateways_GatewayList;
                requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGatewaysIsNull = false;
            }
            System.Int32? requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGateways_participatingGateways_TransmissionInterval = null;
            if (cmdletContext.ParticipatingGateways_TransmissionInterval != null)
            {
                requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGateways_participatingGateways_TransmissionInterval = cmdletContext.ParticipatingGateways_TransmissionInterval.Value;
            }
            if (requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGateways_participatingGateways_TransmissionInterval != null)
            {
                requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGateways.TransmissionInterval = requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGateways_participatingGateways_TransmissionInterval.Value;
                requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGatewaysIsNull = false;
            }
             // determine if requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGateways should be set to null
            if (requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGatewaysIsNull)
            {
                requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGateways = null;
            }
            if (requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGateways != null)
            {
                requestWirelessMetadata_wirelessMetadata_LoRaWAN.ParticipatingGateways = requestWirelessMetadata_wirelessMetadata_LoRaWAN_wirelessMetadata_LoRaWAN_ParticipatingGateways;
                requestWirelessMetadata_wirelessMetadata_LoRaWANIsNull = false;
            }
             // determine if requestWirelessMetadata_wirelessMetadata_LoRaWAN should be set to null
            if (requestWirelessMetadata_wirelessMetadata_LoRaWANIsNull)
            {
                requestWirelessMetadata_wirelessMetadata_LoRaWAN = null;
            }
            if (requestWirelessMetadata_wirelessMetadata_LoRaWAN != null)
            {
                request.WirelessMetadata.LoRaWAN = requestWirelessMetadata_wirelessMetadata_LoRaWAN;
                requestWirelessMetadataIsNull = false;
            }
            Amazon.IoTWireless.Model.SidewalkSendDataToDevice requestWirelessMetadata_wirelessMetadata_Sidewalk = null;
            
             // populate Sidewalk
            var requestWirelessMetadata_wirelessMetadata_SidewalkIsNull = true;
            requestWirelessMetadata_wirelessMetadata_Sidewalk = new Amazon.IoTWireless.Model.SidewalkSendDataToDevice();
            System.Int32? requestWirelessMetadata_wirelessMetadata_Sidewalk_sidewalk_AckModeRetryDurationSec = null;
            if (cmdletContext.Sidewalk_AckModeRetryDurationSec != null)
            {
                requestWirelessMetadata_wirelessMetadata_Sidewalk_sidewalk_AckModeRetryDurationSec = cmdletContext.Sidewalk_AckModeRetryDurationSec.Value;
            }
            if (requestWirelessMetadata_wirelessMetadata_Sidewalk_sidewalk_AckModeRetryDurationSec != null)
            {
                requestWirelessMetadata_wirelessMetadata_Sidewalk.AckModeRetryDurationSecs = requestWirelessMetadata_wirelessMetadata_Sidewalk_sidewalk_AckModeRetryDurationSec.Value;
                requestWirelessMetadata_wirelessMetadata_SidewalkIsNull = false;
            }
            Amazon.IoTWireless.MessageType requestWirelessMetadata_wirelessMetadata_Sidewalk_sidewalk_MessageType = null;
            if (cmdletContext.Sidewalk_MessageType != null)
            {
                requestWirelessMetadata_wirelessMetadata_Sidewalk_sidewalk_MessageType = cmdletContext.Sidewalk_MessageType;
            }
            if (requestWirelessMetadata_wirelessMetadata_Sidewalk_sidewalk_MessageType != null)
            {
                requestWirelessMetadata_wirelessMetadata_Sidewalk.MessageType = requestWirelessMetadata_wirelessMetadata_Sidewalk_sidewalk_MessageType;
                requestWirelessMetadata_wirelessMetadata_SidewalkIsNull = false;
            }
            System.Int32? requestWirelessMetadata_wirelessMetadata_Sidewalk_sidewalk_Seq = null;
            if (cmdletContext.Sidewalk_Seq != null)
            {
                requestWirelessMetadata_wirelessMetadata_Sidewalk_sidewalk_Seq = cmdletContext.Sidewalk_Seq.Value;
            }
            if (requestWirelessMetadata_wirelessMetadata_Sidewalk_sidewalk_Seq != null)
            {
                requestWirelessMetadata_wirelessMetadata_Sidewalk.Seq = requestWirelessMetadata_wirelessMetadata_Sidewalk_sidewalk_Seq.Value;
                requestWirelessMetadata_wirelessMetadata_SidewalkIsNull = false;
            }
             // determine if requestWirelessMetadata_wirelessMetadata_Sidewalk should be set to null
            if (requestWirelessMetadata_wirelessMetadata_SidewalkIsNull)
            {
                requestWirelessMetadata_wirelessMetadata_Sidewalk = null;
            }
            if (requestWirelessMetadata_wirelessMetadata_Sidewalk != null)
            {
                request.WirelessMetadata.Sidewalk = requestWirelessMetadata_wirelessMetadata_Sidewalk;
                requestWirelessMetadataIsNull = false;
            }
             // determine if request.WirelessMetadata should be set to null
            if (requestWirelessMetadataIsNull)
            {
                request.WirelessMetadata = null;
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
        
        private Amazon.IoTWireless.Model.SendDataToWirelessDeviceResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.SendDataToWirelessDeviceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "SendDataToWirelessDevice");
            try
            {
                #if DESKTOP
                return client.SendDataToWirelessDevice(request);
                #elif CORECLR
                return client.SendDataToWirelessDeviceAsync(request).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.String PayloadData { get; set; }
            public System.Int32? TransmitMode { get; set; }
            public System.Int32? LoRaWAN_FPort { get; set; }
            public Amazon.IoTWireless.DownlinkMode ParticipatingGateways_DownlinkMode { get; set; }
            public List<Amazon.IoTWireless.Model.GatewayListItem> ParticipatingGateways_GatewayList { get; set; }
            public System.Int32? ParticipatingGateways_TransmissionInterval { get; set; }
            public System.Int32? Sidewalk_AckModeRetryDurationSec { get; set; }
            public Amazon.IoTWireless.MessageType Sidewalk_MessageType { get; set; }
            public System.Int32? Sidewalk_Seq { get; set; }
            public System.Func<Amazon.IoTWireless.Model.SendDataToWirelessDeviceResponse, SendIOTWDataToWirelessDeviceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageId;
        }
        
    }
}
