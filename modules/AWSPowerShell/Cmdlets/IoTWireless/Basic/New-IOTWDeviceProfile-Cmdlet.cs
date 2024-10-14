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
    /// Creates a new device profile.
    /// </summary>
    [Cmdlet("New", "IOTWDeviceProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTWireless.Model.CreateDeviceProfileResponse")]
    [AWSCmdlet("Calls the AWS IoT Wireless CreateDeviceProfile API operation.", Operation = new[] {"CreateDeviceProfile"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.CreateDeviceProfileResponse))]
    [AWSCmdletOutput("Amazon.IoTWireless.Model.CreateDeviceProfileResponse",
        "This cmdlet returns an Amazon.IoTWireless.Model.CreateDeviceProfileResponse object containing multiple properties."
    )]
    public partial class NewIOTWDeviceProfileCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LoRaWAN_ClassBTimeout
        /// <summary>
        /// <para>
        /// <para>The ClassBTimeout value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LoRaWAN_ClassBTimeout { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_ClassCTimeout
        /// <summary>
        /// <para>
        /// <para>The ClassCTimeout value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LoRaWAN_ClassCTimeout { get; set; }
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
        
        #region Parameter LoRaWAN_FactoryPresetFreqsList
        /// <summary>
        /// <para>
        /// <para>The list of values that make up the FactoryPresetFreqs value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32[] LoRaWAN_FactoryPresetFreqsList { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_MacVersion
        /// <summary>
        /// <para>
        /// <para>The MAC version (such as OTAA 1.1 or OTAA 1.0.3) to use with this device profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoRaWAN_MacVersion { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_MaxDutyCycle
        /// <summary>
        /// <para>
        /// <para>The MaxDutyCycle value. It ranges from 0 to 15.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LoRaWAN_MaxDutyCycle { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_MaxEirp
        /// <summary>
        /// <para>
        /// <para>The MaxEIRP value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LoRaWAN_MaxEirp { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the new resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_PingSlotDr
        /// <summary>
        /// <para>
        /// <para>The PingSlotDR value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LoRaWAN_PingSlotDr { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_PingSlotFreq
        /// <summary>
        /// <para>
        /// <para>The PingSlotFreq value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LoRaWAN_PingSlotFreq { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_PingSlotPeriod
        /// <summary>
        /// <para>
        /// <para>The PingSlotPeriod value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LoRaWAN_PingSlotPeriod { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_RegParamsRevision
        /// <summary>
        /// <para>
        /// <para>The version of regional parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoRaWAN_RegParamsRevision { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_RfRegion
        /// <summary>
        /// <para>
        /// <para>The frequency band (RFRegion) value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoRaWAN_RfRegion { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_RxDataRate2
        /// <summary>
        /// <para>
        /// <para>The RXDataRate2 value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LoRaWAN_RxDataRate2 { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_RxDelay1
        /// <summary>
        /// <para>
        /// <para>The RXDelay1 value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LoRaWAN_RxDelay1 { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_RxDrOffset1
        /// <summary>
        /// <para>
        /// <para>The RXDROffset1 value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LoRaWAN_RxDrOffset1 { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_RxFreq2
        /// <summary>
        /// <para>
        /// <para>The RXFreq2 value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LoRaWAN_RxFreq2 { get; set; }
        #endregion
        
        #region Parameter Sidewalk
        /// <summary>
        /// <para>
        /// <para>The Sidewalk-related information for creating the Sidewalk device profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.IoTWireless.Model.SidewalkCreateDeviceProfile Sidewalk { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_Supports32BitFCnt
        /// <summary>
        /// <para>
        /// <para>The Supports32BitFCnt value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LoRaWAN_Supports32BitFCnt { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_SupportsClassB
        /// <summary>
        /// <para>
        /// <para>The SupportsClassB value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LoRaWAN_SupportsClassB { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_SupportsClassC
        /// <summary>
        /// <para>
        /// <para>The SupportsClassC value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LoRaWAN_SupportsClassC { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_SupportsJoin
        /// <summary>
        /// <para>
        /// <para>The SupportsJoin value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LoRaWAN_SupportsJoin { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to attach to the new device profile. Tags are metadata that you can use to
        /// manage a resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoTWireless.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.CreateDeviceProfileResponse).
        /// Specifying the name of a property of type Amazon.IoTWireless.Model.CreateDeviceProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTWDeviceProfile (CreateDeviceProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.CreateDeviceProfileResponse, NewIOTWDeviceProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.LoRaWAN_ClassBTimeout = this.LoRaWAN_ClassBTimeout;
            context.LoRaWAN_ClassCTimeout = this.LoRaWAN_ClassCTimeout;
            if (this.LoRaWAN_FactoryPresetFreqsList != null)
            {
                context.LoRaWAN_FactoryPresetFreqsList = new List<System.Int32>(this.LoRaWAN_FactoryPresetFreqsList);
            }
            context.LoRaWAN_MacVersion = this.LoRaWAN_MacVersion;
            context.LoRaWAN_MaxDutyCycle = this.LoRaWAN_MaxDutyCycle;
            context.LoRaWAN_MaxEirp = this.LoRaWAN_MaxEirp;
            context.LoRaWAN_PingSlotDr = this.LoRaWAN_PingSlotDr;
            context.LoRaWAN_PingSlotFreq = this.LoRaWAN_PingSlotFreq;
            context.LoRaWAN_PingSlotPeriod = this.LoRaWAN_PingSlotPeriod;
            context.LoRaWAN_RegParamsRevision = this.LoRaWAN_RegParamsRevision;
            context.LoRaWAN_RfRegion = this.LoRaWAN_RfRegion;
            context.LoRaWAN_RxDataRate2 = this.LoRaWAN_RxDataRate2;
            context.LoRaWAN_RxDelay1 = this.LoRaWAN_RxDelay1;
            context.LoRaWAN_RxDrOffset1 = this.LoRaWAN_RxDrOffset1;
            context.LoRaWAN_RxFreq2 = this.LoRaWAN_RxFreq2;
            context.LoRaWAN_Supports32BitFCnt = this.LoRaWAN_Supports32BitFCnt;
            context.LoRaWAN_SupportsClassB = this.LoRaWAN_SupportsClassB;
            context.LoRaWAN_SupportsClassC = this.LoRaWAN_SupportsClassC;
            context.LoRaWAN_SupportsJoin = this.LoRaWAN_SupportsJoin;
            context.Name = this.Name;
            context.Sidewalk = this.Sidewalk;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IoTWireless.Model.Tag>(this.Tag);
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
            var request = new Amazon.IoTWireless.Model.CreateDeviceProfileRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate LoRaWAN
            var requestLoRaWANIsNull = true;
            request.LoRaWAN = new Amazon.IoTWireless.Model.LoRaWANDeviceProfile();
            System.Int32? requestLoRaWAN_loRaWAN_ClassBTimeout = null;
            if (cmdletContext.LoRaWAN_ClassBTimeout != null)
            {
                requestLoRaWAN_loRaWAN_ClassBTimeout = cmdletContext.LoRaWAN_ClassBTimeout.Value;
            }
            if (requestLoRaWAN_loRaWAN_ClassBTimeout != null)
            {
                request.LoRaWAN.ClassBTimeout = requestLoRaWAN_loRaWAN_ClassBTimeout.Value;
                requestLoRaWANIsNull = false;
            }
            System.Int32? requestLoRaWAN_loRaWAN_ClassCTimeout = null;
            if (cmdletContext.LoRaWAN_ClassCTimeout != null)
            {
                requestLoRaWAN_loRaWAN_ClassCTimeout = cmdletContext.LoRaWAN_ClassCTimeout.Value;
            }
            if (requestLoRaWAN_loRaWAN_ClassCTimeout != null)
            {
                request.LoRaWAN.ClassCTimeout = requestLoRaWAN_loRaWAN_ClassCTimeout.Value;
                requestLoRaWANIsNull = false;
            }
            List<System.Int32> requestLoRaWAN_loRaWAN_FactoryPresetFreqsList = null;
            if (cmdletContext.LoRaWAN_FactoryPresetFreqsList != null)
            {
                requestLoRaWAN_loRaWAN_FactoryPresetFreqsList = cmdletContext.LoRaWAN_FactoryPresetFreqsList;
            }
            if (requestLoRaWAN_loRaWAN_FactoryPresetFreqsList != null)
            {
                request.LoRaWAN.FactoryPresetFreqsList = requestLoRaWAN_loRaWAN_FactoryPresetFreqsList;
                requestLoRaWANIsNull = false;
            }
            System.String requestLoRaWAN_loRaWAN_MacVersion = null;
            if (cmdletContext.LoRaWAN_MacVersion != null)
            {
                requestLoRaWAN_loRaWAN_MacVersion = cmdletContext.LoRaWAN_MacVersion;
            }
            if (requestLoRaWAN_loRaWAN_MacVersion != null)
            {
                request.LoRaWAN.MacVersion = requestLoRaWAN_loRaWAN_MacVersion;
                requestLoRaWANIsNull = false;
            }
            System.Int32? requestLoRaWAN_loRaWAN_MaxDutyCycle = null;
            if (cmdletContext.LoRaWAN_MaxDutyCycle != null)
            {
                requestLoRaWAN_loRaWAN_MaxDutyCycle = cmdletContext.LoRaWAN_MaxDutyCycle.Value;
            }
            if (requestLoRaWAN_loRaWAN_MaxDutyCycle != null)
            {
                request.LoRaWAN.MaxDutyCycle = requestLoRaWAN_loRaWAN_MaxDutyCycle.Value;
                requestLoRaWANIsNull = false;
            }
            System.Int32? requestLoRaWAN_loRaWAN_MaxEirp = null;
            if (cmdletContext.LoRaWAN_MaxEirp != null)
            {
                requestLoRaWAN_loRaWAN_MaxEirp = cmdletContext.LoRaWAN_MaxEirp.Value;
            }
            if (requestLoRaWAN_loRaWAN_MaxEirp != null)
            {
                request.LoRaWAN.MaxEirp = requestLoRaWAN_loRaWAN_MaxEirp.Value;
                requestLoRaWANIsNull = false;
            }
            System.Int32? requestLoRaWAN_loRaWAN_PingSlotDr = null;
            if (cmdletContext.LoRaWAN_PingSlotDr != null)
            {
                requestLoRaWAN_loRaWAN_PingSlotDr = cmdletContext.LoRaWAN_PingSlotDr.Value;
            }
            if (requestLoRaWAN_loRaWAN_PingSlotDr != null)
            {
                request.LoRaWAN.PingSlotDr = requestLoRaWAN_loRaWAN_PingSlotDr.Value;
                requestLoRaWANIsNull = false;
            }
            System.Int32? requestLoRaWAN_loRaWAN_PingSlotFreq = null;
            if (cmdletContext.LoRaWAN_PingSlotFreq != null)
            {
                requestLoRaWAN_loRaWAN_PingSlotFreq = cmdletContext.LoRaWAN_PingSlotFreq.Value;
            }
            if (requestLoRaWAN_loRaWAN_PingSlotFreq != null)
            {
                request.LoRaWAN.PingSlotFreq = requestLoRaWAN_loRaWAN_PingSlotFreq.Value;
                requestLoRaWANIsNull = false;
            }
            System.Int32? requestLoRaWAN_loRaWAN_PingSlotPeriod = null;
            if (cmdletContext.LoRaWAN_PingSlotPeriod != null)
            {
                requestLoRaWAN_loRaWAN_PingSlotPeriod = cmdletContext.LoRaWAN_PingSlotPeriod.Value;
            }
            if (requestLoRaWAN_loRaWAN_PingSlotPeriod != null)
            {
                request.LoRaWAN.PingSlotPeriod = requestLoRaWAN_loRaWAN_PingSlotPeriod.Value;
                requestLoRaWANIsNull = false;
            }
            System.String requestLoRaWAN_loRaWAN_RegParamsRevision = null;
            if (cmdletContext.LoRaWAN_RegParamsRevision != null)
            {
                requestLoRaWAN_loRaWAN_RegParamsRevision = cmdletContext.LoRaWAN_RegParamsRevision;
            }
            if (requestLoRaWAN_loRaWAN_RegParamsRevision != null)
            {
                request.LoRaWAN.RegParamsRevision = requestLoRaWAN_loRaWAN_RegParamsRevision;
                requestLoRaWANIsNull = false;
            }
            System.String requestLoRaWAN_loRaWAN_RfRegion = null;
            if (cmdletContext.LoRaWAN_RfRegion != null)
            {
                requestLoRaWAN_loRaWAN_RfRegion = cmdletContext.LoRaWAN_RfRegion;
            }
            if (requestLoRaWAN_loRaWAN_RfRegion != null)
            {
                request.LoRaWAN.RfRegion = requestLoRaWAN_loRaWAN_RfRegion;
                requestLoRaWANIsNull = false;
            }
            System.Int32? requestLoRaWAN_loRaWAN_RxDataRate2 = null;
            if (cmdletContext.LoRaWAN_RxDataRate2 != null)
            {
                requestLoRaWAN_loRaWAN_RxDataRate2 = cmdletContext.LoRaWAN_RxDataRate2.Value;
            }
            if (requestLoRaWAN_loRaWAN_RxDataRate2 != null)
            {
                request.LoRaWAN.RxDataRate2 = requestLoRaWAN_loRaWAN_RxDataRate2.Value;
                requestLoRaWANIsNull = false;
            }
            System.Int32? requestLoRaWAN_loRaWAN_RxDelay1 = null;
            if (cmdletContext.LoRaWAN_RxDelay1 != null)
            {
                requestLoRaWAN_loRaWAN_RxDelay1 = cmdletContext.LoRaWAN_RxDelay1.Value;
            }
            if (requestLoRaWAN_loRaWAN_RxDelay1 != null)
            {
                request.LoRaWAN.RxDelay1 = requestLoRaWAN_loRaWAN_RxDelay1.Value;
                requestLoRaWANIsNull = false;
            }
            System.Int32? requestLoRaWAN_loRaWAN_RxDrOffset1 = null;
            if (cmdletContext.LoRaWAN_RxDrOffset1 != null)
            {
                requestLoRaWAN_loRaWAN_RxDrOffset1 = cmdletContext.LoRaWAN_RxDrOffset1.Value;
            }
            if (requestLoRaWAN_loRaWAN_RxDrOffset1 != null)
            {
                request.LoRaWAN.RxDrOffset1 = requestLoRaWAN_loRaWAN_RxDrOffset1.Value;
                requestLoRaWANIsNull = false;
            }
            System.Int32? requestLoRaWAN_loRaWAN_RxFreq2 = null;
            if (cmdletContext.LoRaWAN_RxFreq2 != null)
            {
                requestLoRaWAN_loRaWAN_RxFreq2 = cmdletContext.LoRaWAN_RxFreq2.Value;
            }
            if (requestLoRaWAN_loRaWAN_RxFreq2 != null)
            {
                request.LoRaWAN.RxFreq2 = requestLoRaWAN_loRaWAN_RxFreq2.Value;
                requestLoRaWANIsNull = false;
            }
            System.Boolean? requestLoRaWAN_loRaWAN_Supports32BitFCnt = null;
            if (cmdletContext.LoRaWAN_Supports32BitFCnt != null)
            {
                requestLoRaWAN_loRaWAN_Supports32BitFCnt = cmdletContext.LoRaWAN_Supports32BitFCnt.Value;
            }
            if (requestLoRaWAN_loRaWAN_Supports32BitFCnt != null)
            {
                request.LoRaWAN.Supports32BitFCnt = requestLoRaWAN_loRaWAN_Supports32BitFCnt.Value;
                requestLoRaWANIsNull = false;
            }
            System.Boolean? requestLoRaWAN_loRaWAN_SupportsClassB = null;
            if (cmdletContext.LoRaWAN_SupportsClassB != null)
            {
                requestLoRaWAN_loRaWAN_SupportsClassB = cmdletContext.LoRaWAN_SupportsClassB.Value;
            }
            if (requestLoRaWAN_loRaWAN_SupportsClassB != null)
            {
                request.LoRaWAN.SupportsClassB = requestLoRaWAN_loRaWAN_SupportsClassB.Value;
                requestLoRaWANIsNull = false;
            }
            System.Boolean? requestLoRaWAN_loRaWAN_SupportsClassC = null;
            if (cmdletContext.LoRaWAN_SupportsClassC != null)
            {
                requestLoRaWAN_loRaWAN_SupportsClassC = cmdletContext.LoRaWAN_SupportsClassC.Value;
            }
            if (requestLoRaWAN_loRaWAN_SupportsClassC != null)
            {
                request.LoRaWAN.SupportsClassC = requestLoRaWAN_loRaWAN_SupportsClassC.Value;
                requestLoRaWANIsNull = false;
            }
            System.Boolean? requestLoRaWAN_loRaWAN_SupportsJoin = null;
            if (cmdletContext.LoRaWAN_SupportsJoin != null)
            {
                requestLoRaWAN_loRaWAN_SupportsJoin = cmdletContext.LoRaWAN_SupportsJoin.Value;
            }
            if (requestLoRaWAN_loRaWAN_SupportsJoin != null)
            {
                request.LoRaWAN.SupportsJoin = requestLoRaWAN_loRaWAN_SupportsJoin.Value;
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
            if (cmdletContext.Sidewalk != null)
            {
                request.Sidewalk = cmdletContext.Sidewalk;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.IoTWireless.Model.CreateDeviceProfileResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.CreateDeviceProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "CreateDeviceProfile");
            try
            {
                #if DESKTOP
                return client.CreateDeviceProfile(request);
                #elif CORECLR
                return client.CreateDeviceProfileAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? LoRaWAN_ClassBTimeout { get; set; }
            public System.Int32? LoRaWAN_ClassCTimeout { get; set; }
            public List<System.Int32> LoRaWAN_FactoryPresetFreqsList { get; set; }
            public System.String LoRaWAN_MacVersion { get; set; }
            public System.Int32? LoRaWAN_MaxDutyCycle { get; set; }
            public System.Int32? LoRaWAN_MaxEirp { get; set; }
            public System.Int32? LoRaWAN_PingSlotDr { get; set; }
            public System.Int32? LoRaWAN_PingSlotFreq { get; set; }
            public System.Int32? LoRaWAN_PingSlotPeriod { get; set; }
            public System.String LoRaWAN_RegParamsRevision { get; set; }
            public System.String LoRaWAN_RfRegion { get; set; }
            public System.Int32? LoRaWAN_RxDataRate2 { get; set; }
            public System.Int32? LoRaWAN_RxDelay1 { get; set; }
            public System.Int32? LoRaWAN_RxDrOffset1 { get; set; }
            public System.Int32? LoRaWAN_RxFreq2 { get; set; }
            public System.Boolean? LoRaWAN_Supports32BitFCnt { get; set; }
            public System.Boolean? LoRaWAN_SupportsClassB { get; set; }
            public System.Boolean? LoRaWAN_SupportsClassC { get; set; }
            public System.Boolean? LoRaWAN_SupportsJoin { get; set; }
            public System.String Name { get; set; }
            public Amazon.IoTWireless.Model.SidewalkCreateDeviceProfile Sidewalk { get; set; }
            public List<Amazon.IoTWireless.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.IoTWireless.Model.CreateDeviceProfileResponse, NewIOTWDeviceProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
