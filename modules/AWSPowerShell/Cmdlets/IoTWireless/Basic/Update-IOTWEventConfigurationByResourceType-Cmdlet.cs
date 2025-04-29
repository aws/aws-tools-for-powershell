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
using Amazon.IoTWireless;
using Amazon.IoTWireless.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTW
{
    /// <summary>
    /// Update the event configuration based on resource types.
    /// </summary>
    [Cmdlet("Update", "IOTWEventConfigurationByResourceType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT Wireless UpdateEventConfigurationByResourceTypes API operation.", Operation = new[] {"UpdateEventConfigurationByResourceTypes"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.UpdateEventConfigurationByResourceTypesResponse))]
    [AWSCmdletOutput("None or Amazon.IoTWireless.Model.UpdateEventConfigurationByResourceTypesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoTWireless.Model.UpdateEventConfigurationByResourceTypesResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateIOTWEventConfigurationByResourceTypeCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DeviceRegistrationState_Sidewalk_WirelessDeviceEventTopic
        /// <summary>
        /// <para>
        /// <para>Denotes whether the wireless device join event topic is enabled or disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SidewalkDeviceRegistrationState_WirelessDeviceEventTopic")]
        [AWSConstantClassSource("Amazon.IoTWireless.EventNotificationTopicStatus")]
        public Amazon.IoTWireless.EventNotificationTopicStatus DeviceRegistrationState_Sidewalk_WirelessDeviceEventTopic { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_WirelessDeviceEventTopic
        /// <summary>
        /// <para>
        /// <para>Denotes whether the wireless device join event topic is enabled or disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Join_LoRaWAN_WirelessDeviceEventTopic")]
        [AWSConstantClassSource("Amazon.IoTWireless.EventNotificationTopicStatus")]
        public Amazon.IoTWireless.EventNotificationTopicStatus LoRaWAN_WirelessDeviceEventTopic { get; set; }
        #endregion
        
        #region Parameter Sidewalk_WirelessDeviceEventTopic
        /// <summary>
        /// <para>
        /// <para>Denotes whether the wireless device join event topic is enabled or disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageDeliveryStatus_Sidewalk_WirelessDeviceEventTopic")]
        [AWSConstantClassSource("Amazon.IoTWireless.EventNotificationTopicStatus")]
        public Amazon.IoTWireless.EventNotificationTopicStatus Sidewalk_WirelessDeviceEventTopic { get; set; }
        #endregion
        
        #region Parameter Proximity_Sidewalk_WirelessDeviceEventTopic
        /// <summary>
        /// <para>
        /// <para>Denotes whether the wireless device join event topic is enabled or disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SidewalkProximity_WirelessDeviceEventTopic")]
        [AWSConstantClassSource("Amazon.IoTWireless.EventNotificationTopicStatus")]
        public Amazon.IoTWireless.EventNotificationTopicStatus Proximity_Sidewalk_WirelessDeviceEventTopic { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_WirelessGatewayEventTopic
        /// <summary>
        /// <para>
        /// <para>Denotes whether the wireless gateway connection status event topic is enabled or disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectionStatus_LoRaWAN_WirelessGatewayEventTopic")]
        [AWSConstantClassSource("Amazon.IoTWireless.EventNotificationTopicStatus")]
        public Amazon.IoTWireless.EventNotificationTopicStatus LoRaWAN_WirelessGatewayEventTopic { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.UpdateEventConfigurationByResourceTypesResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTWEventConfigurationByResourceType (UpdateEventConfigurationByResourceTypes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.UpdateEventConfigurationByResourceTypesResponse, UpdateIOTWEventConfigurationByResourceTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LoRaWAN_WirelessGatewayEventTopic = this.LoRaWAN_WirelessGatewayEventTopic;
            context.DeviceRegistrationState_Sidewalk_WirelessDeviceEventTopic = this.DeviceRegistrationState_Sidewalk_WirelessDeviceEventTopic;
            context.LoRaWAN_WirelessDeviceEventTopic = this.LoRaWAN_WirelessDeviceEventTopic;
            context.Sidewalk_WirelessDeviceEventTopic = this.Sidewalk_WirelessDeviceEventTopic;
            context.Proximity_Sidewalk_WirelessDeviceEventTopic = this.Proximity_Sidewalk_WirelessDeviceEventTopic;
            
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
            var request = new Amazon.IoTWireless.Model.UpdateEventConfigurationByResourceTypesRequest();
            
            
             // populate ConnectionStatus
            var requestConnectionStatusIsNull = true;
            request.ConnectionStatus = new Amazon.IoTWireless.Model.ConnectionStatusResourceTypeEventConfiguration();
            Amazon.IoTWireless.Model.LoRaWANConnectionStatusResourceTypeEventConfiguration requestConnectionStatus_connectionStatus_LoRaWAN = null;
            
             // populate LoRaWAN
            var requestConnectionStatus_connectionStatus_LoRaWANIsNull = true;
            requestConnectionStatus_connectionStatus_LoRaWAN = new Amazon.IoTWireless.Model.LoRaWANConnectionStatusResourceTypeEventConfiguration();
            Amazon.IoTWireless.EventNotificationTopicStatus requestConnectionStatus_connectionStatus_LoRaWAN_loRaWAN_WirelessGatewayEventTopic = null;
            if (cmdletContext.LoRaWAN_WirelessGatewayEventTopic != null)
            {
                requestConnectionStatus_connectionStatus_LoRaWAN_loRaWAN_WirelessGatewayEventTopic = cmdletContext.LoRaWAN_WirelessGatewayEventTopic;
            }
            if (requestConnectionStatus_connectionStatus_LoRaWAN_loRaWAN_WirelessGatewayEventTopic != null)
            {
                requestConnectionStatus_connectionStatus_LoRaWAN.WirelessGatewayEventTopic = requestConnectionStatus_connectionStatus_LoRaWAN_loRaWAN_WirelessGatewayEventTopic;
                requestConnectionStatus_connectionStatus_LoRaWANIsNull = false;
            }
             // determine if requestConnectionStatus_connectionStatus_LoRaWAN should be set to null
            if (requestConnectionStatus_connectionStatus_LoRaWANIsNull)
            {
                requestConnectionStatus_connectionStatus_LoRaWAN = null;
            }
            if (requestConnectionStatus_connectionStatus_LoRaWAN != null)
            {
                request.ConnectionStatus.LoRaWAN = requestConnectionStatus_connectionStatus_LoRaWAN;
                requestConnectionStatusIsNull = false;
            }
             // determine if request.ConnectionStatus should be set to null
            if (requestConnectionStatusIsNull)
            {
                request.ConnectionStatus = null;
            }
            
             // populate DeviceRegistrationState
            var requestDeviceRegistrationStateIsNull = true;
            request.DeviceRegistrationState = new Amazon.IoTWireless.Model.DeviceRegistrationStateResourceTypeEventConfiguration();
            Amazon.IoTWireless.Model.SidewalkResourceTypeEventConfiguration requestDeviceRegistrationState_deviceRegistrationState_Sidewalk = null;
            
             // populate Sidewalk
            var requestDeviceRegistrationState_deviceRegistrationState_SidewalkIsNull = true;
            requestDeviceRegistrationState_deviceRegistrationState_Sidewalk = new Amazon.IoTWireless.Model.SidewalkResourceTypeEventConfiguration();
            Amazon.IoTWireless.EventNotificationTopicStatus requestDeviceRegistrationState_deviceRegistrationState_Sidewalk_deviceRegistrationState_Sidewalk_WirelessDeviceEventTopic = null;
            if (cmdletContext.DeviceRegistrationState_Sidewalk_WirelessDeviceEventTopic != null)
            {
                requestDeviceRegistrationState_deviceRegistrationState_Sidewalk_deviceRegistrationState_Sidewalk_WirelessDeviceEventTopic = cmdletContext.DeviceRegistrationState_Sidewalk_WirelessDeviceEventTopic;
            }
            if (requestDeviceRegistrationState_deviceRegistrationState_Sidewalk_deviceRegistrationState_Sidewalk_WirelessDeviceEventTopic != null)
            {
                requestDeviceRegistrationState_deviceRegistrationState_Sidewalk.WirelessDeviceEventTopic = requestDeviceRegistrationState_deviceRegistrationState_Sidewalk_deviceRegistrationState_Sidewalk_WirelessDeviceEventTopic;
                requestDeviceRegistrationState_deviceRegistrationState_SidewalkIsNull = false;
            }
             // determine if requestDeviceRegistrationState_deviceRegistrationState_Sidewalk should be set to null
            if (requestDeviceRegistrationState_deviceRegistrationState_SidewalkIsNull)
            {
                requestDeviceRegistrationState_deviceRegistrationState_Sidewalk = null;
            }
            if (requestDeviceRegistrationState_deviceRegistrationState_Sidewalk != null)
            {
                request.DeviceRegistrationState.Sidewalk = requestDeviceRegistrationState_deviceRegistrationState_Sidewalk;
                requestDeviceRegistrationStateIsNull = false;
            }
             // determine if request.DeviceRegistrationState should be set to null
            if (requestDeviceRegistrationStateIsNull)
            {
                request.DeviceRegistrationState = null;
            }
            
             // populate Join
            var requestJoinIsNull = true;
            request.Join = new Amazon.IoTWireless.Model.JoinResourceTypeEventConfiguration();
            Amazon.IoTWireless.Model.LoRaWANJoinResourceTypeEventConfiguration requestJoin_join_LoRaWAN = null;
            
             // populate LoRaWAN
            var requestJoin_join_LoRaWANIsNull = true;
            requestJoin_join_LoRaWAN = new Amazon.IoTWireless.Model.LoRaWANJoinResourceTypeEventConfiguration();
            Amazon.IoTWireless.EventNotificationTopicStatus requestJoin_join_LoRaWAN_loRaWAN_WirelessDeviceEventTopic = null;
            if (cmdletContext.LoRaWAN_WirelessDeviceEventTopic != null)
            {
                requestJoin_join_LoRaWAN_loRaWAN_WirelessDeviceEventTopic = cmdletContext.LoRaWAN_WirelessDeviceEventTopic;
            }
            if (requestJoin_join_LoRaWAN_loRaWAN_WirelessDeviceEventTopic != null)
            {
                requestJoin_join_LoRaWAN.WirelessDeviceEventTopic = requestJoin_join_LoRaWAN_loRaWAN_WirelessDeviceEventTopic;
                requestJoin_join_LoRaWANIsNull = false;
            }
             // determine if requestJoin_join_LoRaWAN should be set to null
            if (requestJoin_join_LoRaWANIsNull)
            {
                requestJoin_join_LoRaWAN = null;
            }
            if (requestJoin_join_LoRaWAN != null)
            {
                request.Join.LoRaWAN = requestJoin_join_LoRaWAN;
                requestJoinIsNull = false;
            }
             // determine if request.Join should be set to null
            if (requestJoinIsNull)
            {
                request.Join = null;
            }
            
             // populate MessageDeliveryStatus
            var requestMessageDeliveryStatusIsNull = true;
            request.MessageDeliveryStatus = new Amazon.IoTWireless.Model.MessageDeliveryStatusResourceTypeEventConfiguration();
            Amazon.IoTWireless.Model.SidewalkResourceTypeEventConfiguration requestMessageDeliveryStatus_messageDeliveryStatus_Sidewalk = null;
            
             // populate Sidewalk
            var requestMessageDeliveryStatus_messageDeliveryStatus_SidewalkIsNull = true;
            requestMessageDeliveryStatus_messageDeliveryStatus_Sidewalk = new Amazon.IoTWireless.Model.SidewalkResourceTypeEventConfiguration();
            Amazon.IoTWireless.EventNotificationTopicStatus requestMessageDeliveryStatus_messageDeliveryStatus_Sidewalk_sidewalk_WirelessDeviceEventTopic = null;
            if (cmdletContext.Sidewalk_WirelessDeviceEventTopic != null)
            {
                requestMessageDeliveryStatus_messageDeliveryStatus_Sidewalk_sidewalk_WirelessDeviceEventTopic = cmdletContext.Sidewalk_WirelessDeviceEventTopic;
            }
            if (requestMessageDeliveryStatus_messageDeliveryStatus_Sidewalk_sidewalk_WirelessDeviceEventTopic != null)
            {
                requestMessageDeliveryStatus_messageDeliveryStatus_Sidewalk.WirelessDeviceEventTopic = requestMessageDeliveryStatus_messageDeliveryStatus_Sidewalk_sidewalk_WirelessDeviceEventTopic;
                requestMessageDeliveryStatus_messageDeliveryStatus_SidewalkIsNull = false;
            }
             // determine if requestMessageDeliveryStatus_messageDeliveryStatus_Sidewalk should be set to null
            if (requestMessageDeliveryStatus_messageDeliveryStatus_SidewalkIsNull)
            {
                requestMessageDeliveryStatus_messageDeliveryStatus_Sidewalk = null;
            }
            if (requestMessageDeliveryStatus_messageDeliveryStatus_Sidewalk != null)
            {
                request.MessageDeliveryStatus.Sidewalk = requestMessageDeliveryStatus_messageDeliveryStatus_Sidewalk;
                requestMessageDeliveryStatusIsNull = false;
            }
             // determine if request.MessageDeliveryStatus should be set to null
            if (requestMessageDeliveryStatusIsNull)
            {
                request.MessageDeliveryStatus = null;
            }
            
             // populate Proximity
            var requestProximityIsNull = true;
            request.Proximity = new Amazon.IoTWireless.Model.ProximityResourceTypeEventConfiguration();
            Amazon.IoTWireless.Model.SidewalkResourceTypeEventConfiguration requestProximity_proximity_Sidewalk = null;
            
             // populate Sidewalk
            var requestProximity_proximity_SidewalkIsNull = true;
            requestProximity_proximity_Sidewalk = new Amazon.IoTWireless.Model.SidewalkResourceTypeEventConfiguration();
            Amazon.IoTWireless.EventNotificationTopicStatus requestProximity_proximity_Sidewalk_proximity_Sidewalk_WirelessDeviceEventTopic = null;
            if (cmdletContext.Proximity_Sidewalk_WirelessDeviceEventTopic != null)
            {
                requestProximity_proximity_Sidewalk_proximity_Sidewalk_WirelessDeviceEventTopic = cmdletContext.Proximity_Sidewalk_WirelessDeviceEventTopic;
            }
            if (requestProximity_proximity_Sidewalk_proximity_Sidewalk_WirelessDeviceEventTopic != null)
            {
                requestProximity_proximity_Sidewalk.WirelessDeviceEventTopic = requestProximity_proximity_Sidewalk_proximity_Sidewalk_WirelessDeviceEventTopic;
                requestProximity_proximity_SidewalkIsNull = false;
            }
             // determine if requestProximity_proximity_Sidewalk should be set to null
            if (requestProximity_proximity_SidewalkIsNull)
            {
                requestProximity_proximity_Sidewalk = null;
            }
            if (requestProximity_proximity_Sidewalk != null)
            {
                request.Proximity.Sidewalk = requestProximity_proximity_Sidewalk;
                requestProximityIsNull = false;
            }
             // determine if request.Proximity should be set to null
            if (requestProximityIsNull)
            {
                request.Proximity = null;
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
        
        private Amazon.IoTWireless.Model.UpdateEventConfigurationByResourceTypesResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.UpdateEventConfigurationByResourceTypesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "UpdateEventConfigurationByResourceTypes");
            try
            {
                return client.UpdateEventConfigurationByResourceTypesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.IoTWireless.EventNotificationTopicStatus LoRaWAN_WirelessGatewayEventTopic { get; set; }
            public Amazon.IoTWireless.EventNotificationTopicStatus DeviceRegistrationState_Sidewalk_WirelessDeviceEventTopic { get; set; }
            public Amazon.IoTWireless.EventNotificationTopicStatus LoRaWAN_WirelessDeviceEventTopic { get; set; }
            public Amazon.IoTWireless.EventNotificationTopicStatus Sidewalk_WirelessDeviceEventTopic { get; set; }
            public Amazon.IoTWireless.EventNotificationTopicStatus Proximity_Sidewalk_WirelessDeviceEventTopic { get; set; }
            public System.Func<Amazon.IoTWireless.Model.UpdateEventConfigurationByResourceTypesResponse, UpdateIOTWEventConfigurationByResourceTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
