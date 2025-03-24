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
    /// Updates properties of a multicast group session.
    /// </summary>
    [Cmdlet("Update", "IOTWMulticastGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT Wireless UpdateMulticastGroup API operation.", Operation = new[] {"UpdateMulticastGroup"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.UpdateMulticastGroupResponse))]
    [AWSCmdletOutput("None or Amazon.IoTWireless.Model.UpdateMulticastGroupResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoTWireless.Model.UpdateMulticastGroupResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateIOTWMulticastGroupCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_DlClass
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTWireless.DlClass")]
        public Amazon.IoTWireless.DlClass LoRaWAN_DlClass { get; set; }
        #endregion
        
        #region Parameter ParticipatingGateways_GatewayList
        /// <summary>
        /// <para>
        /// <para>The list of gateways that you want to use for sending the multicast downlink message.
        /// Each downlink message will be sent to all the gateways in the list in the order that
        /// you provided. If the gateway list is empty, then AWS IoT Core for LoRaWAN chooses
        /// the gateways that were most recently used by the devices to send an uplink message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoRaWAN_ParticipatingGateways_GatewayList")]
        public System.String[] ParticipatingGateways_GatewayList { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_RfRegion
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTWireless.SupportedRfRegion")]
        public Amazon.IoTWireless.SupportedRfRegion LoRaWAN_RfRegion { get; set; }
        #endregion
        
        #region Parameter ParticipatingGateways_TransmissionInterval
        /// <summary>
        /// <para>
        /// <para>The duration of time in milliseconds for which AWS IoT Core for LoRaWAN will wait
        /// before transmitting the multicast payload to the next gateway in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoRaWAN_ParticipatingGateways_TransmissionInterval")]
        public System.Int32? ParticipatingGateways_TransmissionInterval { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.UpdateMulticastGroupResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTWMulticastGroup (UpdateMulticastGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.UpdateMulticastGroupResponse, UpdateIOTWMulticastGroupCmdlet>(Select) ??
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
            context.Description = this.Description;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoRaWAN_DlClass = this.LoRaWAN_DlClass;
            if (this.ParticipatingGateways_GatewayList != null)
            {
                context.ParticipatingGateways_GatewayList = new List<System.String>(this.ParticipatingGateways_GatewayList);
            }
            context.ParticipatingGateways_TransmissionInterval = this.ParticipatingGateways_TransmissionInterval;
            context.LoRaWAN_RfRegion = this.LoRaWAN_RfRegion;
            context.Name = this.Name;
            
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
            var request = new Amazon.IoTWireless.Model.UpdateMulticastGroupRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            
             // populate LoRaWAN
            var requestLoRaWANIsNull = true;
            request.LoRaWAN = new Amazon.IoTWireless.Model.LoRaWANMulticast();
            Amazon.IoTWireless.DlClass requestLoRaWAN_loRaWAN_DlClass = null;
            if (cmdletContext.LoRaWAN_DlClass != null)
            {
                requestLoRaWAN_loRaWAN_DlClass = cmdletContext.LoRaWAN_DlClass;
            }
            if (requestLoRaWAN_loRaWAN_DlClass != null)
            {
                request.LoRaWAN.DlClass = requestLoRaWAN_loRaWAN_DlClass;
                requestLoRaWANIsNull = false;
            }
            Amazon.IoTWireless.SupportedRfRegion requestLoRaWAN_loRaWAN_RfRegion = null;
            if (cmdletContext.LoRaWAN_RfRegion != null)
            {
                requestLoRaWAN_loRaWAN_RfRegion = cmdletContext.LoRaWAN_RfRegion;
            }
            if (requestLoRaWAN_loRaWAN_RfRegion != null)
            {
                request.LoRaWAN.RfRegion = requestLoRaWAN_loRaWAN_RfRegion;
                requestLoRaWANIsNull = false;
            }
            Amazon.IoTWireless.Model.ParticipatingGatewaysMulticast requestLoRaWAN_loRaWAN_ParticipatingGateways = null;
            
             // populate ParticipatingGateways
            var requestLoRaWAN_loRaWAN_ParticipatingGatewaysIsNull = true;
            requestLoRaWAN_loRaWAN_ParticipatingGateways = new Amazon.IoTWireless.Model.ParticipatingGatewaysMulticast();
            List<System.String> requestLoRaWAN_loRaWAN_ParticipatingGateways_participatingGateways_GatewayList = null;
            if (cmdletContext.ParticipatingGateways_GatewayList != null)
            {
                requestLoRaWAN_loRaWAN_ParticipatingGateways_participatingGateways_GatewayList = cmdletContext.ParticipatingGateways_GatewayList;
            }
            if (requestLoRaWAN_loRaWAN_ParticipatingGateways_participatingGateways_GatewayList != null)
            {
                requestLoRaWAN_loRaWAN_ParticipatingGateways.GatewayList = requestLoRaWAN_loRaWAN_ParticipatingGateways_participatingGateways_GatewayList;
                requestLoRaWAN_loRaWAN_ParticipatingGatewaysIsNull = false;
            }
            System.Int32? requestLoRaWAN_loRaWAN_ParticipatingGateways_participatingGateways_TransmissionInterval = null;
            if (cmdletContext.ParticipatingGateways_TransmissionInterval != null)
            {
                requestLoRaWAN_loRaWAN_ParticipatingGateways_participatingGateways_TransmissionInterval = cmdletContext.ParticipatingGateways_TransmissionInterval.Value;
            }
            if (requestLoRaWAN_loRaWAN_ParticipatingGateways_participatingGateways_TransmissionInterval != null)
            {
                requestLoRaWAN_loRaWAN_ParticipatingGateways.TransmissionInterval = requestLoRaWAN_loRaWAN_ParticipatingGateways_participatingGateways_TransmissionInterval.Value;
                requestLoRaWAN_loRaWAN_ParticipatingGatewaysIsNull = false;
            }
             // determine if requestLoRaWAN_loRaWAN_ParticipatingGateways should be set to null
            if (requestLoRaWAN_loRaWAN_ParticipatingGatewaysIsNull)
            {
                requestLoRaWAN_loRaWAN_ParticipatingGateways = null;
            }
            if (requestLoRaWAN_loRaWAN_ParticipatingGateways != null)
            {
                request.LoRaWAN.ParticipatingGateways = requestLoRaWAN_loRaWAN_ParticipatingGateways;
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
        
        private Amazon.IoTWireless.Model.UpdateMulticastGroupResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.UpdateMulticastGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "UpdateMulticastGroup");
            try
            {
                #if DESKTOP
                return client.UpdateMulticastGroup(request);
                #elif CORECLR
                return client.UpdateMulticastGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Id { get; set; }
            public Amazon.IoTWireless.DlClass LoRaWAN_DlClass { get; set; }
            public List<System.String> ParticipatingGateways_GatewayList { get; set; }
            public System.Int32? ParticipatingGateways_TransmissionInterval { get; set; }
            public Amazon.IoTWireless.SupportedRfRegion LoRaWAN_RfRegion { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.IoTWireless.Model.UpdateMulticastGroupResponse, UpdateIOTWMulticastGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
