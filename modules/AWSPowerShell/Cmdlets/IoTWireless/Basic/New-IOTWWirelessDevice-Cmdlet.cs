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
using Amazon.IoTWireless;
using Amazon.IoTWireless.Model;

namespace Amazon.PowerShell.Cmdlets.IOTW
{
    /// <summary>
    /// Provisions a wireless device.
    /// </summary>
    [Cmdlet("New", "IOTWWirelessDevice", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTWireless.Model.CreateWirelessDeviceResponse")]
    [AWSCmdlet("Calls the AWS IoT Wireless CreateWirelessDevice API operation.", Operation = new[] {"CreateWirelessDevice"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.CreateWirelessDeviceResponse))]
    [AWSCmdletOutput("Amazon.IoTWireless.Model.CreateWirelessDeviceResponse",
        "This cmdlet returns an Amazon.IoTWireless.Model.CreateWirelessDeviceResponse object containing multiple properties."
    )]
    public partial class NewIOTWWirelessDeviceCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LoRaWAN_OtaaV1_0_x_AppEui
        /// <summary>
        /// <para>
        /// <para>The AppEUI value. You specify this value when using LoRaWAN versions v1.0.2 or v1.0.3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoRaWAN_OtaaV1_0_x_AppEui { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_OtaaV1_0_x_AppKey
        /// <summary>
        /// <para>
        /// <para>The AppKey value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoRaWAN_OtaaV1_0_x_AppKey { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_OtaaV1_1_AppKey
        /// <summary>
        /// <para>
        /// <para>The AppKey value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoRaWAN_OtaaV1_1_AppKey { get; set; }
        #endregion
        
        #region Parameter FPorts_Application
        /// <summary>
        /// <para>
        /// <para>Optional LoRaWAN application information, which can be used for geolocation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoRaWAN_FPorts_Applications")]
        public Amazon.IoTWireless.Model.ApplicationConfig[] FPorts_Application { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_AbpV1_0_x_SessionKeys_AppSKey
        /// <summary>
        /// <para>
        /// <para>The AppSKey value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoRaWAN_AbpV1_0_x_SessionKeys_AppSKey { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_AbpV1_1_SessionKeys_AppSKey
        /// <summary>
        /// <para>
        /// <para>The AppSKey value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoRaWAN_AbpV1_1_SessionKeys_AppSKey { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Each resource must have a unique client request token. The client token is used to
        /// implement idempotency. It ensures that the request completes no more than one time.
        /// If you retry a request with the same token and the same parameters, the request will
        /// complete successfully. However, if you try to create a new resource using the same
        /// token but different parameters, an HTTP 409 conflict occurs. If you omit this value,
        /// AWS SDKs will automatically generate a unique client request. For more information
        /// about idempotency, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">Ensuring
        /// idempotency in Amazon EC2 API requests</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter FPorts_ClockSync
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoRaWAN_FPorts_ClockSync")]
        public System.Int32? FPorts_ClockSync { get; set; }
        #endregion
        
        #region Parameter Positioning_ClockSync
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoRaWAN_FPorts_Positioning_ClockSync")]
        public System.Int32? Positioning_ClockSync { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the new resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DestinationName
        /// <summary>
        /// <para>
        /// <para>The name of the destination to assign to the new wireless device.</para>
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
        public System.String DestinationName { get; set; }
        #endregion
        
        #region Parameter Positioning_DestinationName
        /// <summary>
        /// <para>
        /// <para>The location destination name of the Sidewalk device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Sidewalk_Positioning_DestinationName")]
        public System.String Positioning_DestinationName { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_AbpV1_0_x_DevAddr
        /// <summary>
        /// <para>
        /// <para>The DevAddr value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoRaWAN_AbpV1_0_x_DevAddr { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_AbpV1_1_DevAddr
        /// <summary>
        /// <para>
        /// <para>The DevAddr value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoRaWAN_AbpV1_1_DevAddr { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_DevEui
        /// <summary>
        /// <para>
        /// <para>The DevEUI value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoRaWAN_DevEui { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_DeviceProfileId
        /// <summary>
        /// <para>
        /// <para>The ID of the device profile for the new wireless device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoRaWAN_DeviceProfileId { get; set; }
        #endregion
        
        #region Parameter Sidewalk_DeviceProfileId
        /// <summary>
        /// <para>
        /// <para>The ID of the Sidewalk device profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Sidewalk_DeviceProfileId { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_AbpV1_0_x_FCntStart
        /// <summary>
        /// <para>
        /// <para>The FCnt init value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LoRaWAN_AbpV1_0_x_FCntStart { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_AbpV1_1_FCntStart
        /// <summary>
        /// <para>
        /// <para>The FCnt init value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LoRaWAN_AbpV1_1_FCntStart { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_AbpV1_1_SessionKeys_FNwkSIntKey
        /// <summary>
        /// <para>
        /// <para>The FNwkSIntKey value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoRaWAN_AbpV1_1_SessionKeys_FNwkSIntKey { get; set; }
        #endregion
        
        #region Parameter FPorts_Fuota
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoRaWAN_FPorts_Fuota")]
        public System.Int32? FPorts_Fuota { get; set; }
        #endregion
        
        #region Parameter x_GenAppKey
        /// <summary>
        /// <para>
        /// <para>The GenAppKey value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoRaWAN_OtaaV1_0_x_GenAppKey")]
        public System.String x_GenAppKey { get; set; }
        #endregion
        
        #region Parameter Positioning_Gnss
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoRaWAN_FPorts_Positioning_Gnss")]
        public System.Int32? Positioning_Gnss { get; set; }
        #endregion
        
        #region Parameter x_JoinEui
        /// <summary>
        /// <para>
        /// <para>The JoinEUI value. You specify this value instead of the AppEUI when using LoRaWAN
        /// version v1.0.4.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoRaWAN_OtaaV1_0_x_JoinEui")]
        public System.String x_JoinEui { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_OtaaV1_1_JoinEui
        /// <summary>
        /// <para>
        /// <para>The JoinEUI value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoRaWAN_OtaaV1_1_JoinEui { get; set; }
        #endregion
        
        #region Parameter FPorts_Multicast
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoRaWAN_FPorts_Multicast")]
        public System.Int32? FPorts_Multicast { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the new resource.</para><note><para>The following special characters aren't accepted: <c>&lt;&gt;^#~$</c></para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_OtaaV1_1_NwkKey
        /// <summary>
        /// <para>
        /// <para>The NwkKey value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoRaWAN_OtaaV1_1_NwkKey { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_AbpV1_1_SessionKeys_NwkSEncKey
        /// <summary>
        /// <para>
        /// <para>The NwkSEncKey value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoRaWAN_AbpV1_1_SessionKeys_NwkSEncKey { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_AbpV1_0_x_SessionKeys_NwkSKey
        /// <summary>
        /// <para>
        /// <para>The NwkSKey value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoRaWAN_AbpV1_0_x_SessionKeys_NwkSKey { get; set; }
        #endregion
        
        #region Parameter Positioning
        /// <summary>
        /// <para>
        /// <para>The integration status of the Device Location feature for LoRaWAN and Sidewalk devices.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTWireless.PositioningConfigStatus")]
        public Amazon.IoTWireless.PositioningConfigStatus Positioning { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_ServiceProfileId
        /// <summary>
        /// <para>
        /// <para>The ID of the service profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoRaWAN_ServiceProfileId { get; set; }
        #endregion
        
        #region Parameter Sidewalk_SidewalkManufacturingSn
        /// <summary>
        /// <para>
        /// <para>The Sidewalk manufacturing serial number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Sidewalk_SidewalkManufacturingSn { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_AbpV1_1_SessionKeys_SNwkSIntKey
        /// <summary>
        /// <para>
        /// <para>The SNwkSIntKey value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoRaWAN_AbpV1_1_SessionKeys_SNwkSIntKey { get; set; }
        #endregion
        
        #region Parameter Positioning_Stream
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoRaWAN_FPorts_Positioning_Stream")]
        public System.Int32? Positioning_Stream { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to attach to the new wireless device. Tags are metadata that you can use
        /// to manage a resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoTWireless.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The wireless device type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTWireless.WirelessDeviceType")]
        public Amazon.IoTWireless.WirelessDeviceType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.CreateWirelessDeviceResponse).
        /// Specifying the name of a property of type Amazon.IoTWireless.Model.CreateWirelessDeviceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Type parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Type' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Type' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DestinationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTWWirelessDevice (CreateWirelessDevice)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.CreateWirelessDeviceResponse, NewIOTWWirelessDeviceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Type;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.Description = this.Description;
            context.DestinationName = this.DestinationName;
            #if MODULAR
            if (this.DestinationName == null && ParameterWasBound(nameof(this.DestinationName)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoRaWAN_AbpV1_0_x_DevAddr = this.LoRaWAN_AbpV1_0_x_DevAddr;
            context.LoRaWAN_AbpV1_0_x_FCntStart = this.LoRaWAN_AbpV1_0_x_FCntStart;
            context.LoRaWAN_AbpV1_0_x_SessionKeys_AppSKey = this.LoRaWAN_AbpV1_0_x_SessionKeys_AppSKey;
            context.LoRaWAN_AbpV1_0_x_SessionKeys_NwkSKey = this.LoRaWAN_AbpV1_0_x_SessionKeys_NwkSKey;
            context.LoRaWAN_AbpV1_1_DevAddr = this.LoRaWAN_AbpV1_1_DevAddr;
            context.LoRaWAN_AbpV1_1_FCntStart = this.LoRaWAN_AbpV1_1_FCntStart;
            context.LoRaWAN_AbpV1_1_SessionKeys_AppSKey = this.LoRaWAN_AbpV1_1_SessionKeys_AppSKey;
            context.LoRaWAN_AbpV1_1_SessionKeys_FNwkSIntKey = this.LoRaWAN_AbpV1_1_SessionKeys_FNwkSIntKey;
            context.LoRaWAN_AbpV1_1_SessionKeys_NwkSEncKey = this.LoRaWAN_AbpV1_1_SessionKeys_NwkSEncKey;
            context.LoRaWAN_AbpV1_1_SessionKeys_SNwkSIntKey = this.LoRaWAN_AbpV1_1_SessionKeys_SNwkSIntKey;
            context.LoRaWAN_DevEui = this.LoRaWAN_DevEui;
            context.LoRaWAN_DeviceProfileId = this.LoRaWAN_DeviceProfileId;
            if (this.FPorts_Application != null)
            {
                context.FPorts_Application = new List<Amazon.IoTWireless.Model.ApplicationConfig>(this.FPorts_Application);
            }
            context.FPorts_ClockSync = this.FPorts_ClockSync;
            context.FPorts_Fuota = this.FPorts_Fuota;
            context.FPorts_Multicast = this.FPorts_Multicast;
            context.Positioning_ClockSync = this.Positioning_ClockSync;
            context.Positioning_Gnss = this.Positioning_Gnss;
            context.Positioning_Stream = this.Positioning_Stream;
            context.LoRaWAN_OtaaV1_0_x_AppEui = this.LoRaWAN_OtaaV1_0_x_AppEui;
            context.LoRaWAN_OtaaV1_0_x_AppKey = this.LoRaWAN_OtaaV1_0_x_AppKey;
            context.x_GenAppKey = this.x_GenAppKey;
            context.x_JoinEui = this.x_JoinEui;
            context.LoRaWAN_OtaaV1_1_AppKey = this.LoRaWAN_OtaaV1_1_AppKey;
            context.LoRaWAN_OtaaV1_1_JoinEui = this.LoRaWAN_OtaaV1_1_JoinEui;
            context.LoRaWAN_OtaaV1_1_NwkKey = this.LoRaWAN_OtaaV1_1_NwkKey;
            context.LoRaWAN_ServiceProfileId = this.LoRaWAN_ServiceProfileId;
            context.Name = this.Name;
            context.Positioning = this.Positioning;
            context.Sidewalk_DeviceProfileId = this.Sidewalk_DeviceProfileId;
            context.Positioning_DestinationName = this.Positioning_DestinationName;
            context.Sidewalk_SidewalkManufacturingSn = this.Sidewalk_SidewalkManufacturingSn;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IoTWireless.Model.Tag>(this.Tag);
            }
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTWireless.Model.CreateWirelessDeviceRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DestinationName != null)
            {
                request.DestinationName = cmdletContext.DestinationName;
            }
            
             // populate LoRaWAN
            var requestLoRaWANIsNull = true;
            request.LoRaWAN = new Amazon.IoTWireless.Model.LoRaWANDevice();
            System.String requestLoRaWAN_loRaWAN_DevEui = null;
            if (cmdletContext.LoRaWAN_DevEui != null)
            {
                requestLoRaWAN_loRaWAN_DevEui = cmdletContext.LoRaWAN_DevEui;
            }
            if (requestLoRaWAN_loRaWAN_DevEui != null)
            {
                request.LoRaWAN.DevEui = requestLoRaWAN_loRaWAN_DevEui;
                requestLoRaWANIsNull = false;
            }
            System.String requestLoRaWAN_loRaWAN_DeviceProfileId = null;
            if (cmdletContext.LoRaWAN_DeviceProfileId != null)
            {
                requestLoRaWAN_loRaWAN_DeviceProfileId = cmdletContext.LoRaWAN_DeviceProfileId;
            }
            if (requestLoRaWAN_loRaWAN_DeviceProfileId != null)
            {
                request.LoRaWAN.DeviceProfileId = requestLoRaWAN_loRaWAN_DeviceProfileId;
                requestLoRaWANIsNull = false;
            }
            System.String requestLoRaWAN_loRaWAN_ServiceProfileId = null;
            if (cmdletContext.LoRaWAN_ServiceProfileId != null)
            {
                requestLoRaWAN_loRaWAN_ServiceProfileId = cmdletContext.LoRaWAN_ServiceProfileId;
            }
            if (requestLoRaWAN_loRaWAN_ServiceProfileId != null)
            {
                request.LoRaWAN.ServiceProfileId = requestLoRaWAN_loRaWAN_ServiceProfileId;
                requestLoRaWANIsNull = false;
            }
            Amazon.IoTWireless.Model.AbpV1_0_x requestLoRaWAN_loRaWAN_AbpV1_0_x = null;
            
             // populate AbpV1_0_x
            var requestLoRaWAN_loRaWAN_AbpV1_0_xIsNull = true;
            requestLoRaWAN_loRaWAN_AbpV1_0_x = new Amazon.IoTWireless.Model.AbpV1_0_x();
            System.String requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_DevAddr = null;
            if (cmdletContext.LoRaWAN_AbpV1_0_x_DevAddr != null)
            {
                requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_DevAddr = cmdletContext.LoRaWAN_AbpV1_0_x_DevAddr;
            }
            if (requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_DevAddr != null)
            {
                requestLoRaWAN_loRaWAN_AbpV1_0_x.DevAddr = requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_DevAddr;
                requestLoRaWAN_loRaWAN_AbpV1_0_xIsNull = false;
            }
            System.Int32? requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_FCntStart = null;
            if (cmdletContext.LoRaWAN_AbpV1_0_x_FCntStart != null)
            {
                requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_FCntStart = cmdletContext.LoRaWAN_AbpV1_0_x_FCntStart.Value;
            }
            if (requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_FCntStart != null)
            {
                requestLoRaWAN_loRaWAN_AbpV1_0_x.FCntStart = requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_FCntStart.Value;
                requestLoRaWAN_loRaWAN_AbpV1_0_xIsNull = false;
            }
            Amazon.IoTWireless.Model.SessionKeysAbpV1_0_x requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_SessionKeys = null;
            
             // populate SessionKeys
            var requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_SessionKeysIsNull = true;
            requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_SessionKeys = new Amazon.IoTWireless.Model.SessionKeysAbpV1_0_x();
            System.String requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_SessionKeys_loRaWAN_AbpV1_0_x_SessionKeys_AppSKey = null;
            if (cmdletContext.LoRaWAN_AbpV1_0_x_SessionKeys_AppSKey != null)
            {
                requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_SessionKeys_loRaWAN_AbpV1_0_x_SessionKeys_AppSKey = cmdletContext.LoRaWAN_AbpV1_0_x_SessionKeys_AppSKey;
            }
            if (requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_SessionKeys_loRaWAN_AbpV1_0_x_SessionKeys_AppSKey != null)
            {
                requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_SessionKeys.AppSKey = requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_SessionKeys_loRaWAN_AbpV1_0_x_SessionKeys_AppSKey;
                requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_SessionKeysIsNull = false;
            }
            System.String requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_SessionKeys_loRaWAN_AbpV1_0_x_SessionKeys_NwkSKey = null;
            if (cmdletContext.LoRaWAN_AbpV1_0_x_SessionKeys_NwkSKey != null)
            {
                requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_SessionKeys_loRaWAN_AbpV1_0_x_SessionKeys_NwkSKey = cmdletContext.LoRaWAN_AbpV1_0_x_SessionKeys_NwkSKey;
            }
            if (requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_SessionKeys_loRaWAN_AbpV1_0_x_SessionKeys_NwkSKey != null)
            {
                requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_SessionKeys.NwkSKey = requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_SessionKeys_loRaWAN_AbpV1_0_x_SessionKeys_NwkSKey;
                requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_SessionKeysIsNull = false;
            }
             // determine if requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_SessionKeys should be set to null
            if (requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_SessionKeysIsNull)
            {
                requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_SessionKeys = null;
            }
            if (requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_SessionKeys != null)
            {
                requestLoRaWAN_loRaWAN_AbpV1_0_x.SessionKeys = requestLoRaWAN_loRaWAN_AbpV1_0_x_loRaWAN_AbpV1_0_x_SessionKeys;
                requestLoRaWAN_loRaWAN_AbpV1_0_xIsNull = false;
            }
             // determine if requestLoRaWAN_loRaWAN_AbpV1_0_x should be set to null
            if (requestLoRaWAN_loRaWAN_AbpV1_0_xIsNull)
            {
                requestLoRaWAN_loRaWAN_AbpV1_0_x = null;
            }
            if (requestLoRaWAN_loRaWAN_AbpV1_0_x != null)
            {
                request.LoRaWAN.AbpV1_0_x = requestLoRaWAN_loRaWAN_AbpV1_0_x;
                requestLoRaWANIsNull = false;
            }
            Amazon.IoTWireless.Model.AbpV1_1 requestLoRaWAN_loRaWAN_AbpV1_1 = null;
            
             // populate AbpV1_1
            var requestLoRaWAN_loRaWAN_AbpV1_1IsNull = true;
            requestLoRaWAN_loRaWAN_AbpV1_1 = new Amazon.IoTWireless.Model.AbpV1_1();
            System.String requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_DevAddr = null;
            if (cmdletContext.LoRaWAN_AbpV1_1_DevAddr != null)
            {
                requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_DevAddr = cmdletContext.LoRaWAN_AbpV1_1_DevAddr;
            }
            if (requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_DevAddr != null)
            {
                requestLoRaWAN_loRaWAN_AbpV1_1.DevAddr = requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_DevAddr;
                requestLoRaWAN_loRaWAN_AbpV1_1IsNull = false;
            }
            System.Int32? requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_FCntStart = null;
            if (cmdletContext.LoRaWAN_AbpV1_1_FCntStart != null)
            {
                requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_FCntStart = cmdletContext.LoRaWAN_AbpV1_1_FCntStart.Value;
            }
            if (requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_FCntStart != null)
            {
                requestLoRaWAN_loRaWAN_AbpV1_1.FCntStart = requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_FCntStart.Value;
                requestLoRaWAN_loRaWAN_AbpV1_1IsNull = false;
            }
            Amazon.IoTWireless.Model.SessionKeysAbpV1_1 requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys = null;
            
             // populate SessionKeys
            var requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeysIsNull = true;
            requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys = new Amazon.IoTWireless.Model.SessionKeysAbpV1_1();
            System.String requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys_loRaWAN_AbpV1_1_SessionKeys_AppSKey = null;
            if (cmdletContext.LoRaWAN_AbpV1_1_SessionKeys_AppSKey != null)
            {
                requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys_loRaWAN_AbpV1_1_SessionKeys_AppSKey = cmdletContext.LoRaWAN_AbpV1_1_SessionKeys_AppSKey;
            }
            if (requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys_loRaWAN_AbpV1_1_SessionKeys_AppSKey != null)
            {
                requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys.AppSKey = requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys_loRaWAN_AbpV1_1_SessionKeys_AppSKey;
                requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeysIsNull = false;
            }
            System.String requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys_loRaWAN_AbpV1_1_SessionKeys_FNwkSIntKey = null;
            if (cmdletContext.LoRaWAN_AbpV1_1_SessionKeys_FNwkSIntKey != null)
            {
                requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys_loRaWAN_AbpV1_1_SessionKeys_FNwkSIntKey = cmdletContext.LoRaWAN_AbpV1_1_SessionKeys_FNwkSIntKey;
            }
            if (requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys_loRaWAN_AbpV1_1_SessionKeys_FNwkSIntKey != null)
            {
                requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys.FNwkSIntKey = requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys_loRaWAN_AbpV1_1_SessionKeys_FNwkSIntKey;
                requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeysIsNull = false;
            }
            System.String requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys_loRaWAN_AbpV1_1_SessionKeys_NwkSEncKey = null;
            if (cmdletContext.LoRaWAN_AbpV1_1_SessionKeys_NwkSEncKey != null)
            {
                requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys_loRaWAN_AbpV1_1_SessionKeys_NwkSEncKey = cmdletContext.LoRaWAN_AbpV1_1_SessionKeys_NwkSEncKey;
            }
            if (requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys_loRaWAN_AbpV1_1_SessionKeys_NwkSEncKey != null)
            {
                requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys.NwkSEncKey = requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys_loRaWAN_AbpV1_1_SessionKeys_NwkSEncKey;
                requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeysIsNull = false;
            }
            System.String requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys_loRaWAN_AbpV1_1_SessionKeys_SNwkSIntKey = null;
            if (cmdletContext.LoRaWAN_AbpV1_1_SessionKeys_SNwkSIntKey != null)
            {
                requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys_loRaWAN_AbpV1_1_SessionKeys_SNwkSIntKey = cmdletContext.LoRaWAN_AbpV1_1_SessionKeys_SNwkSIntKey;
            }
            if (requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys_loRaWAN_AbpV1_1_SessionKeys_SNwkSIntKey != null)
            {
                requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys.SNwkSIntKey = requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys_loRaWAN_AbpV1_1_SessionKeys_SNwkSIntKey;
                requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeysIsNull = false;
            }
             // determine if requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys should be set to null
            if (requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeysIsNull)
            {
                requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys = null;
            }
            if (requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys != null)
            {
                requestLoRaWAN_loRaWAN_AbpV1_1.SessionKeys = requestLoRaWAN_loRaWAN_AbpV1_1_loRaWAN_AbpV1_1_SessionKeys;
                requestLoRaWAN_loRaWAN_AbpV1_1IsNull = false;
            }
             // determine if requestLoRaWAN_loRaWAN_AbpV1_1 should be set to null
            if (requestLoRaWAN_loRaWAN_AbpV1_1IsNull)
            {
                requestLoRaWAN_loRaWAN_AbpV1_1 = null;
            }
            if (requestLoRaWAN_loRaWAN_AbpV1_1 != null)
            {
                request.LoRaWAN.AbpV1_1 = requestLoRaWAN_loRaWAN_AbpV1_1;
                requestLoRaWANIsNull = false;
            }
            Amazon.IoTWireless.Model.OtaaV1_1 requestLoRaWAN_loRaWAN_OtaaV1_1 = null;
            
             // populate OtaaV1_1
            var requestLoRaWAN_loRaWAN_OtaaV1_1IsNull = true;
            requestLoRaWAN_loRaWAN_OtaaV1_1 = new Amazon.IoTWireless.Model.OtaaV1_1();
            System.String requestLoRaWAN_loRaWAN_OtaaV1_1_loRaWAN_OtaaV1_1_AppKey = null;
            if (cmdletContext.LoRaWAN_OtaaV1_1_AppKey != null)
            {
                requestLoRaWAN_loRaWAN_OtaaV1_1_loRaWAN_OtaaV1_1_AppKey = cmdletContext.LoRaWAN_OtaaV1_1_AppKey;
            }
            if (requestLoRaWAN_loRaWAN_OtaaV1_1_loRaWAN_OtaaV1_1_AppKey != null)
            {
                requestLoRaWAN_loRaWAN_OtaaV1_1.AppKey = requestLoRaWAN_loRaWAN_OtaaV1_1_loRaWAN_OtaaV1_1_AppKey;
                requestLoRaWAN_loRaWAN_OtaaV1_1IsNull = false;
            }
            System.String requestLoRaWAN_loRaWAN_OtaaV1_1_loRaWAN_OtaaV1_1_JoinEui = null;
            if (cmdletContext.LoRaWAN_OtaaV1_1_JoinEui != null)
            {
                requestLoRaWAN_loRaWAN_OtaaV1_1_loRaWAN_OtaaV1_1_JoinEui = cmdletContext.LoRaWAN_OtaaV1_1_JoinEui;
            }
            if (requestLoRaWAN_loRaWAN_OtaaV1_1_loRaWAN_OtaaV1_1_JoinEui != null)
            {
                requestLoRaWAN_loRaWAN_OtaaV1_1.JoinEui = requestLoRaWAN_loRaWAN_OtaaV1_1_loRaWAN_OtaaV1_1_JoinEui;
                requestLoRaWAN_loRaWAN_OtaaV1_1IsNull = false;
            }
            System.String requestLoRaWAN_loRaWAN_OtaaV1_1_loRaWAN_OtaaV1_1_NwkKey = null;
            if (cmdletContext.LoRaWAN_OtaaV1_1_NwkKey != null)
            {
                requestLoRaWAN_loRaWAN_OtaaV1_1_loRaWAN_OtaaV1_1_NwkKey = cmdletContext.LoRaWAN_OtaaV1_1_NwkKey;
            }
            if (requestLoRaWAN_loRaWAN_OtaaV1_1_loRaWAN_OtaaV1_1_NwkKey != null)
            {
                requestLoRaWAN_loRaWAN_OtaaV1_1.NwkKey = requestLoRaWAN_loRaWAN_OtaaV1_1_loRaWAN_OtaaV1_1_NwkKey;
                requestLoRaWAN_loRaWAN_OtaaV1_1IsNull = false;
            }
             // determine if requestLoRaWAN_loRaWAN_OtaaV1_1 should be set to null
            if (requestLoRaWAN_loRaWAN_OtaaV1_1IsNull)
            {
                requestLoRaWAN_loRaWAN_OtaaV1_1 = null;
            }
            if (requestLoRaWAN_loRaWAN_OtaaV1_1 != null)
            {
                request.LoRaWAN.OtaaV1_1 = requestLoRaWAN_loRaWAN_OtaaV1_1;
                requestLoRaWANIsNull = false;
            }
            Amazon.IoTWireless.Model.OtaaV1_0_x requestLoRaWAN_loRaWAN_OtaaV1_0_x = null;
            
             // populate OtaaV1_0_x
            var requestLoRaWAN_loRaWAN_OtaaV1_0_xIsNull = true;
            requestLoRaWAN_loRaWAN_OtaaV1_0_x = new Amazon.IoTWireless.Model.OtaaV1_0_x();
            System.String requestLoRaWAN_loRaWAN_OtaaV1_0_x_loRaWAN_OtaaV1_0_x_AppEui = null;
            if (cmdletContext.LoRaWAN_OtaaV1_0_x_AppEui != null)
            {
                requestLoRaWAN_loRaWAN_OtaaV1_0_x_loRaWAN_OtaaV1_0_x_AppEui = cmdletContext.LoRaWAN_OtaaV1_0_x_AppEui;
            }
            if (requestLoRaWAN_loRaWAN_OtaaV1_0_x_loRaWAN_OtaaV1_0_x_AppEui != null)
            {
                requestLoRaWAN_loRaWAN_OtaaV1_0_x.AppEui = requestLoRaWAN_loRaWAN_OtaaV1_0_x_loRaWAN_OtaaV1_0_x_AppEui;
                requestLoRaWAN_loRaWAN_OtaaV1_0_xIsNull = false;
            }
            System.String requestLoRaWAN_loRaWAN_OtaaV1_0_x_loRaWAN_OtaaV1_0_x_AppKey = null;
            if (cmdletContext.LoRaWAN_OtaaV1_0_x_AppKey != null)
            {
                requestLoRaWAN_loRaWAN_OtaaV1_0_x_loRaWAN_OtaaV1_0_x_AppKey = cmdletContext.LoRaWAN_OtaaV1_0_x_AppKey;
            }
            if (requestLoRaWAN_loRaWAN_OtaaV1_0_x_loRaWAN_OtaaV1_0_x_AppKey != null)
            {
                requestLoRaWAN_loRaWAN_OtaaV1_0_x.AppKey = requestLoRaWAN_loRaWAN_OtaaV1_0_x_loRaWAN_OtaaV1_0_x_AppKey;
                requestLoRaWAN_loRaWAN_OtaaV1_0_xIsNull = false;
            }
            System.String requestLoRaWAN_loRaWAN_OtaaV1_0_x_x_GenAppKey = null;
            if (cmdletContext.x_GenAppKey != null)
            {
                requestLoRaWAN_loRaWAN_OtaaV1_0_x_x_GenAppKey = cmdletContext.x_GenAppKey;
            }
            if (requestLoRaWAN_loRaWAN_OtaaV1_0_x_x_GenAppKey != null)
            {
                requestLoRaWAN_loRaWAN_OtaaV1_0_x.GenAppKey = requestLoRaWAN_loRaWAN_OtaaV1_0_x_x_GenAppKey;
                requestLoRaWAN_loRaWAN_OtaaV1_0_xIsNull = false;
            }
            System.String requestLoRaWAN_loRaWAN_OtaaV1_0_x_x_JoinEui = null;
            if (cmdletContext.x_JoinEui != null)
            {
                requestLoRaWAN_loRaWAN_OtaaV1_0_x_x_JoinEui = cmdletContext.x_JoinEui;
            }
            if (requestLoRaWAN_loRaWAN_OtaaV1_0_x_x_JoinEui != null)
            {
                requestLoRaWAN_loRaWAN_OtaaV1_0_x.JoinEui = requestLoRaWAN_loRaWAN_OtaaV1_0_x_x_JoinEui;
                requestLoRaWAN_loRaWAN_OtaaV1_0_xIsNull = false;
            }
             // determine if requestLoRaWAN_loRaWAN_OtaaV1_0_x should be set to null
            if (requestLoRaWAN_loRaWAN_OtaaV1_0_xIsNull)
            {
                requestLoRaWAN_loRaWAN_OtaaV1_0_x = null;
            }
            if (requestLoRaWAN_loRaWAN_OtaaV1_0_x != null)
            {
                request.LoRaWAN.OtaaV1_0_x = requestLoRaWAN_loRaWAN_OtaaV1_0_x;
                requestLoRaWANIsNull = false;
            }
            Amazon.IoTWireless.Model.FPorts requestLoRaWAN_loRaWAN_FPorts = null;
            
             // populate FPorts
            var requestLoRaWAN_loRaWAN_FPortsIsNull = true;
            requestLoRaWAN_loRaWAN_FPorts = new Amazon.IoTWireless.Model.FPorts();
            List<Amazon.IoTWireless.Model.ApplicationConfig> requestLoRaWAN_loRaWAN_FPorts_fPorts_Application = null;
            if (cmdletContext.FPorts_Application != null)
            {
                requestLoRaWAN_loRaWAN_FPorts_fPorts_Application = cmdletContext.FPorts_Application;
            }
            if (requestLoRaWAN_loRaWAN_FPorts_fPorts_Application != null)
            {
                requestLoRaWAN_loRaWAN_FPorts.Applications = requestLoRaWAN_loRaWAN_FPorts_fPorts_Application;
                requestLoRaWAN_loRaWAN_FPortsIsNull = false;
            }
            System.Int32? requestLoRaWAN_loRaWAN_FPorts_fPorts_ClockSync = null;
            if (cmdletContext.FPorts_ClockSync != null)
            {
                requestLoRaWAN_loRaWAN_FPorts_fPorts_ClockSync = cmdletContext.FPorts_ClockSync.Value;
            }
            if (requestLoRaWAN_loRaWAN_FPorts_fPorts_ClockSync != null)
            {
                requestLoRaWAN_loRaWAN_FPorts.ClockSync = requestLoRaWAN_loRaWAN_FPorts_fPorts_ClockSync.Value;
                requestLoRaWAN_loRaWAN_FPortsIsNull = false;
            }
            System.Int32? requestLoRaWAN_loRaWAN_FPorts_fPorts_Fuota = null;
            if (cmdletContext.FPorts_Fuota != null)
            {
                requestLoRaWAN_loRaWAN_FPorts_fPorts_Fuota = cmdletContext.FPorts_Fuota.Value;
            }
            if (requestLoRaWAN_loRaWAN_FPorts_fPorts_Fuota != null)
            {
                requestLoRaWAN_loRaWAN_FPorts.Fuota = requestLoRaWAN_loRaWAN_FPorts_fPorts_Fuota.Value;
                requestLoRaWAN_loRaWAN_FPortsIsNull = false;
            }
            System.Int32? requestLoRaWAN_loRaWAN_FPorts_fPorts_Multicast = null;
            if (cmdletContext.FPorts_Multicast != null)
            {
                requestLoRaWAN_loRaWAN_FPorts_fPorts_Multicast = cmdletContext.FPorts_Multicast.Value;
            }
            if (requestLoRaWAN_loRaWAN_FPorts_fPorts_Multicast != null)
            {
                requestLoRaWAN_loRaWAN_FPorts.Multicast = requestLoRaWAN_loRaWAN_FPorts_fPorts_Multicast.Value;
                requestLoRaWAN_loRaWAN_FPortsIsNull = false;
            }
            Amazon.IoTWireless.Model.Positioning requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_Positioning = null;
            
             // populate Positioning
            var requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_PositioningIsNull = true;
            requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_Positioning = new Amazon.IoTWireless.Model.Positioning();
            System.Int32? requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_Positioning_positioning_ClockSync = null;
            if (cmdletContext.Positioning_ClockSync != null)
            {
                requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_Positioning_positioning_ClockSync = cmdletContext.Positioning_ClockSync.Value;
            }
            if (requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_Positioning_positioning_ClockSync != null)
            {
                requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_Positioning.ClockSync = requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_Positioning_positioning_ClockSync.Value;
                requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_PositioningIsNull = false;
            }
            System.Int32? requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_Positioning_positioning_Gnss = null;
            if (cmdletContext.Positioning_Gnss != null)
            {
                requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_Positioning_positioning_Gnss = cmdletContext.Positioning_Gnss.Value;
            }
            if (requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_Positioning_positioning_Gnss != null)
            {
                requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_Positioning.Gnss = requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_Positioning_positioning_Gnss.Value;
                requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_PositioningIsNull = false;
            }
            System.Int32? requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_Positioning_positioning_Stream = null;
            if (cmdletContext.Positioning_Stream != null)
            {
                requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_Positioning_positioning_Stream = cmdletContext.Positioning_Stream.Value;
            }
            if (requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_Positioning_positioning_Stream != null)
            {
                requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_Positioning.Stream = requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_Positioning_positioning_Stream.Value;
                requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_PositioningIsNull = false;
            }
             // determine if requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_Positioning should be set to null
            if (requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_PositioningIsNull)
            {
                requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_Positioning = null;
            }
            if (requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_Positioning != null)
            {
                requestLoRaWAN_loRaWAN_FPorts.Positioning = requestLoRaWAN_loRaWAN_FPorts_loRaWAN_FPorts_Positioning;
                requestLoRaWAN_loRaWAN_FPortsIsNull = false;
            }
             // determine if requestLoRaWAN_loRaWAN_FPorts should be set to null
            if (requestLoRaWAN_loRaWAN_FPortsIsNull)
            {
                requestLoRaWAN_loRaWAN_FPorts = null;
            }
            if (requestLoRaWAN_loRaWAN_FPorts != null)
            {
                request.LoRaWAN.FPorts = requestLoRaWAN_loRaWAN_FPorts;
                requestLoRaWANIsNull = false;
            }
             // determine if request.LoRaWAN should be set to null
            if (requestLoRaWANIsNull)
            {
                request.LoRaWAN = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Positioning != null)
            {
                request.Positioning = cmdletContext.Positioning;
            }
            
             // populate Sidewalk
            var requestSidewalkIsNull = true;
            request.Sidewalk = new Amazon.IoTWireless.Model.SidewalkCreateWirelessDevice();
            System.String requestSidewalk_sidewalk_DeviceProfileId = null;
            if (cmdletContext.Sidewalk_DeviceProfileId != null)
            {
                requestSidewalk_sidewalk_DeviceProfileId = cmdletContext.Sidewalk_DeviceProfileId;
            }
            if (requestSidewalk_sidewalk_DeviceProfileId != null)
            {
                request.Sidewalk.DeviceProfileId = requestSidewalk_sidewalk_DeviceProfileId;
                requestSidewalkIsNull = false;
            }
            System.String requestSidewalk_sidewalk_SidewalkManufacturingSn = null;
            if (cmdletContext.Sidewalk_SidewalkManufacturingSn != null)
            {
                requestSidewalk_sidewalk_SidewalkManufacturingSn = cmdletContext.Sidewalk_SidewalkManufacturingSn;
            }
            if (requestSidewalk_sidewalk_SidewalkManufacturingSn != null)
            {
                request.Sidewalk.SidewalkManufacturingSn = requestSidewalk_sidewalk_SidewalkManufacturingSn;
                requestSidewalkIsNull = false;
            }
            Amazon.IoTWireless.Model.SidewalkPositioning requestSidewalk_sidewalk_Positioning = null;
            
             // populate Positioning
            var requestSidewalk_sidewalk_PositioningIsNull = true;
            requestSidewalk_sidewalk_Positioning = new Amazon.IoTWireless.Model.SidewalkPositioning();
            System.String requestSidewalk_sidewalk_Positioning_positioning_DestinationName = null;
            if (cmdletContext.Positioning_DestinationName != null)
            {
                requestSidewalk_sidewalk_Positioning_positioning_DestinationName = cmdletContext.Positioning_DestinationName;
            }
            if (requestSidewalk_sidewalk_Positioning_positioning_DestinationName != null)
            {
                requestSidewalk_sidewalk_Positioning.DestinationName = requestSidewalk_sidewalk_Positioning_positioning_DestinationName;
                requestSidewalk_sidewalk_PositioningIsNull = false;
            }
             // determine if requestSidewalk_sidewalk_Positioning should be set to null
            if (requestSidewalk_sidewalk_PositioningIsNull)
            {
                requestSidewalk_sidewalk_Positioning = null;
            }
            if (requestSidewalk_sidewalk_Positioning != null)
            {
                request.Sidewalk.Positioning = requestSidewalk_sidewalk_Positioning;
                requestSidewalkIsNull = false;
            }
             // determine if request.Sidewalk should be set to null
            if (requestSidewalkIsNull)
            {
                request.Sidewalk = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.IoTWireless.Model.CreateWirelessDeviceResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.CreateWirelessDeviceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "CreateWirelessDevice");
            try
            {
                #if DESKTOP
                return client.CreateWirelessDevice(request);
                #elif CORECLR
                return client.CreateWirelessDeviceAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String Description { get; set; }
            public System.String DestinationName { get; set; }
            public System.String LoRaWAN_AbpV1_0_x_DevAddr { get; set; }
            public System.Int32? LoRaWAN_AbpV1_0_x_FCntStart { get; set; }
            public System.String LoRaWAN_AbpV1_0_x_SessionKeys_AppSKey { get; set; }
            public System.String LoRaWAN_AbpV1_0_x_SessionKeys_NwkSKey { get; set; }
            public System.String LoRaWAN_AbpV1_1_DevAddr { get; set; }
            public System.Int32? LoRaWAN_AbpV1_1_FCntStart { get; set; }
            public System.String LoRaWAN_AbpV1_1_SessionKeys_AppSKey { get; set; }
            public System.String LoRaWAN_AbpV1_1_SessionKeys_FNwkSIntKey { get; set; }
            public System.String LoRaWAN_AbpV1_1_SessionKeys_NwkSEncKey { get; set; }
            public System.String LoRaWAN_AbpV1_1_SessionKeys_SNwkSIntKey { get; set; }
            public System.String LoRaWAN_DevEui { get; set; }
            public System.String LoRaWAN_DeviceProfileId { get; set; }
            public List<Amazon.IoTWireless.Model.ApplicationConfig> FPorts_Application { get; set; }
            public System.Int32? FPorts_ClockSync { get; set; }
            public System.Int32? FPorts_Fuota { get; set; }
            public System.Int32? FPorts_Multicast { get; set; }
            public System.Int32? Positioning_ClockSync { get; set; }
            public System.Int32? Positioning_Gnss { get; set; }
            public System.Int32? Positioning_Stream { get; set; }
            public System.String LoRaWAN_OtaaV1_0_x_AppEui { get; set; }
            public System.String LoRaWAN_OtaaV1_0_x_AppKey { get; set; }
            public System.String x_GenAppKey { get; set; }
            public System.String x_JoinEui { get; set; }
            public System.String LoRaWAN_OtaaV1_1_AppKey { get; set; }
            public System.String LoRaWAN_OtaaV1_1_JoinEui { get; set; }
            public System.String LoRaWAN_OtaaV1_1_NwkKey { get; set; }
            public System.String LoRaWAN_ServiceProfileId { get; set; }
            public System.String Name { get; set; }
            public Amazon.IoTWireless.PositioningConfigStatus Positioning { get; set; }
            public System.String Sidewalk_DeviceProfileId { get; set; }
            public System.String Positioning_DestinationName { get; set; }
            public System.String Sidewalk_SidewalkManufacturingSn { get; set; }
            public List<Amazon.IoTWireless.Model.Tag> Tag { get; set; }
            public Amazon.IoTWireless.WirelessDeviceType Type { get; set; }
            public System.Func<Amazon.IoTWireless.Model.CreateWirelessDeviceResponse, NewIOTWWirelessDeviceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
