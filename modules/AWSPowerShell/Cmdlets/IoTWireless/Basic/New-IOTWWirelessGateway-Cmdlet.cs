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
    /// Provisions a wireless gateway.
    /// 
    ///  <note><para>
    /// When provisioning a wireless gateway, you might run into duplication errors for the
    /// following reasons.
    /// </para><ul><li><para>
    /// If you specify a <c>GatewayEui</c> value that already exists.
    /// </para></li><li><para>
    /// If you used a <c>ClientRequestToken</c> with the same parameters within the last 10
    /// minutes.
    /// </para></li></ul><para>
    /// To avoid this error, make sure that you use unique identifiers and parameters for
    /// each request within the specified time period.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "IOTWWirelessGateway", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTWireless.Model.CreateWirelessGatewayResponse")]
    [AWSCmdlet("Calls the AWS IoT Wireless CreateWirelessGateway API operation.", Operation = new[] {"CreateWirelessGateway"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.CreateWirelessGatewayResponse))]
    [AWSCmdletOutput("Amazon.IoTWireless.Model.CreateWirelessGatewayResponse",
        "This cmdlet returns an Amazon.IoTWireless.Model.CreateWirelessGatewayResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIOTWWirelessGatewayCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter Beaconing_DataRate
        /// <summary>
        /// <para>
        /// <para>The data rate for gateways that are sending the beacons.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoRaWAN_Beaconing_DataRate")]
        public System.Int32? Beaconing_DataRate { get; set; }
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
        
        #region Parameter Beaconing_Frequency
        /// <summary>
        /// <para>
        /// <para>The frequency list for the gateways to send the beacons.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoRaWAN_Beaconing_Frequencies")]
        public System.Int32[] Beaconing_Frequency { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_GatewayEui
        /// <summary>
        /// <para>
        /// <para>The gateway's EUI value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoRaWAN_GatewayEui { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_JoinEuiFilter
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoRaWAN_JoinEuiFilters")]
        public System.String[][] LoRaWAN_JoinEuiFilter { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_MaxEirp
        /// <summary>
        /// <para>
        /// <para>The MaxEIRP value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? LoRaWAN_MaxEirp { get; set; }
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
        
        #region Parameter LoRaWAN_NetIdFilter
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoRaWAN_NetIdFilters")]
        public System.String[] LoRaWAN_NetIdFilter { get; set; }
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
        
        #region Parameter LoRaWAN_SubBand
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoRaWAN_SubBands")]
        public System.Int32[] LoRaWAN_SubBand { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to attach to the new wireless gateway. Tags are metadata that you can use
        /// to manage a resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoTWireless.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.CreateWirelessGatewayResponse).
        /// Specifying the name of a property of type Amazon.IoTWireless.Model.CreateWirelessGatewayResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTWWirelessGateway (CreateWirelessGateway)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.CreateWirelessGatewayResponse, NewIOTWWirelessGatewayCmdlet>(Select) ??
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
            context.Description = this.Description;
            context.Beaconing_DataRate = this.Beaconing_DataRate;
            if (this.Beaconing_Frequency != null)
            {
                context.Beaconing_Frequency = new List<System.Int32>(this.Beaconing_Frequency);
            }
            context.LoRaWAN_GatewayEui = this.LoRaWAN_GatewayEui;
            if (this.LoRaWAN_JoinEuiFilter != null)
            {
                context.LoRaWAN_JoinEuiFilter = new List<List<System.String>>();
                foreach (var innerList in this.LoRaWAN_JoinEuiFilter)
                {
                    context.LoRaWAN_JoinEuiFilter.Add(new List<System.String>(innerList));
                }
            }
            context.LoRaWAN_MaxEirp = this.LoRaWAN_MaxEirp;
            if (this.LoRaWAN_NetIdFilter != null)
            {
                context.LoRaWAN_NetIdFilter = new List<System.String>(this.LoRaWAN_NetIdFilter);
            }
            context.LoRaWAN_RfRegion = this.LoRaWAN_RfRegion;
            if (this.LoRaWAN_SubBand != null)
            {
                context.LoRaWAN_SubBand = new List<System.Int32>(this.LoRaWAN_SubBand);
            }
            context.Name = this.Name;
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
            var request = new Amazon.IoTWireless.Model.CreateWirelessGatewayRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate LoRaWAN
            var requestLoRaWANIsNull = true;
            request.LoRaWAN = new Amazon.IoTWireless.Model.LoRaWANGateway();
            System.String requestLoRaWAN_loRaWAN_GatewayEui = null;
            if (cmdletContext.LoRaWAN_GatewayEui != null)
            {
                requestLoRaWAN_loRaWAN_GatewayEui = cmdletContext.LoRaWAN_GatewayEui;
            }
            if (requestLoRaWAN_loRaWAN_GatewayEui != null)
            {
                request.LoRaWAN.GatewayEui = requestLoRaWAN_loRaWAN_GatewayEui;
                requestLoRaWANIsNull = false;
            }
            List<List<System.String>> requestLoRaWAN_loRaWAN_JoinEuiFilter = null;
            if (cmdletContext.LoRaWAN_JoinEuiFilter != null)
            {
                requestLoRaWAN_loRaWAN_JoinEuiFilter = cmdletContext.LoRaWAN_JoinEuiFilter;
            }
            if (requestLoRaWAN_loRaWAN_JoinEuiFilter != null)
            {
                request.LoRaWAN.JoinEuiFilters = requestLoRaWAN_loRaWAN_JoinEuiFilter;
                requestLoRaWANIsNull = false;
            }
            System.Single? requestLoRaWAN_loRaWAN_MaxEirp = null;
            if (cmdletContext.LoRaWAN_MaxEirp != null)
            {
                requestLoRaWAN_loRaWAN_MaxEirp = cmdletContext.LoRaWAN_MaxEirp.Value;
            }
            if (requestLoRaWAN_loRaWAN_MaxEirp != null)
            {
                request.LoRaWAN.MaxEirp = requestLoRaWAN_loRaWAN_MaxEirp.Value;
                requestLoRaWANIsNull = false;
            }
            List<System.String> requestLoRaWAN_loRaWAN_NetIdFilter = null;
            if (cmdletContext.LoRaWAN_NetIdFilter != null)
            {
                requestLoRaWAN_loRaWAN_NetIdFilter = cmdletContext.LoRaWAN_NetIdFilter;
            }
            if (requestLoRaWAN_loRaWAN_NetIdFilter != null)
            {
                request.LoRaWAN.NetIdFilters = requestLoRaWAN_loRaWAN_NetIdFilter;
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
            List<System.Int32> requestLoRaWAN_loRaWAN_SubBand = null;
            if (cmdletContext.LoRaWAN_SubBand != null)
            {
                requestLoRaWAN_loRaWAN_SubBand = cmdletContext.LoRaWAN_SubBand;
            }
            if (requestLoRaWAN_loRaWAN_SubBand != null)
            {
                request.LoRaWAN.SubBands = requestLoRaWAN_loRaWAN_SubBand;
                requestLoRaWANIsNull = false;
            }
            Amazon.IoTWireless.Model.Beaconing requestLoRaWAN_loRaWAN_Beaconing = null;
            
             // populate Beaconing
            var requestLoRaWAN_loRaWAN_BeaconingIsNull = true;
            requestLoRaWAN_loRaWAN_Beaconing = new Amazon.IoTWireless.Model.Beaconing();
            System.Int32? requestLoRaWAN_loRaWAN_Beaconing_beaconing_DataRate = null;
            if (cmdletContext.Beaconing_DataRate != null)
            {
                requestLoRaWAN_loRaWAN_Beaconing_beaconing_DataRate = cmdletContext.Beaconing_DataRate.Value;
            }
            if (requestLoRaWAN_loRaWAN_Beaconing_beaconing_DataRate != null)
            {
                requestLoRaWAN_loRaWAN_Beaconing.DataRate = requestLoRaWAN_loRaWAN_Beaconing_beaconing_DataRate.Value;
                requestLoRaWAN_loRaWAN_BeaconingIsNull = false;
            }
            List<System.Int32> requestLoRaWAN_loRaWAN_Beaconing_beaconing_Frequency = null;
            if (cmdletContext.Beaconing_Frequency != null)
            {
                requestLoRaWAN_loRaWAN_Beaconing_beaconing_Frequency = cmdletContext.Beaconing_Frequency;
            }
            if (requestLoRaWAN_loRaWAN_Beaconing_beaconing_Frequency != null)
            {
                requestLoRaWAN_loRaWAN_Beaconing.Frequencies = requestLoRaWAN_loRaWAN_Beaconing_beaconing_Frequency;
                requestLoRaWAN_loRaWAN_BeaconingIsNull = false;
            }
             // determine if requestLoRaWAN_loRaWAN_Beaconing should be set to null
            if (requestLoRaWAN_loRaWAN_BeaconingIsNull)
            {
                requestLoRaWAN_loRaWAN_Beaconing = null;
            }
            if (requestLoRaWAN_loRaWAN_Beaconing != null)
            {
                request.LoRaWAN.Beaconing = requestLoRaWAN_loRaWAN_Beaconing;
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
        
        private Amazon.IoTWireless.Model.CreateWirelessGatewayResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.CreateWirelessGatewayRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "CreateWirelessGateway");
            try
            {
                #if DESKTOP
                return client.CreateWirelessGateway(request);
                #elif CORECLR
                return client.CreateWirelessGatewayAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? Beaconing_DataRate { get; set; }
            public List<System.Int32> Beaconing_Frequency { get; set; }
            public System.String LoRaWAN_GatewayEui { get; set; }
            public List<List<System.String>> LoRaWAN_JoinEuiFilter { get; set; }
            public System.Single? LoRaWAN_MaxEirp { get; set; }
            public List<System.String> LoRaWAN_NetIdFilter { get; set; }
            public System.String LoRaWAN_RfRegion { get; set; }
            public List<System.Int32> LoRaWAN_SubBand { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.IoTWireless.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.IoTWireless.Model.CreateWirelessGatewayResponse, NewIOTWWirelessGatewayCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
