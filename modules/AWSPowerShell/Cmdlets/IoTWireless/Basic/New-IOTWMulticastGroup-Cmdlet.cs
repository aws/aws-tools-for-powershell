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
    /// Creates a multicast group.
    /// </summary>
    [Cmdlet("New", "IOTWMulticastGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTWireless.Model.CreateMulticastGroupResponse")]
    [AWSCmdlet("Calls the AWS IoT Wireless CreateMulticastGroup API operation.", Operation = new[] {"CreateMulticastGroup"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.CreateMulticastGroupResponse))]
    [AWSCmdletOutput("Amazon.IoTWireless.Model.CreateMulticastGroupResponse",
        "This cmdlet returns an Amazon.IoTWireless.Model.CreateMulticastGroupResponse object containing multiple properties."
    )]
    public partial class NewIOTWMulticastGroupCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
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
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the multicast group.</para>
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
        /// <para>The list of gateways that you want to use for sending the multicast downlink. Each
        /// downlink will be sent to all the gateways in the list with transmission interval between
        /// them. If list is empty the gateway list will be dynamically selected similar to the
        /// case of no ParticipatingGateways </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoRaWAN_ParticipatingGateways_GatewayList")]
        public System.String[] ParticipatingGateways_GatewayList { get; set; }
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoTWireless.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ParticipatingGateways_TransmissionInterval
        /// <summary>
        /// <para>
        /// <para>The duration of time for which AWS IoT Core for LoRaWAN will wait before transmitting
        /// the multicast payload to the next gateway in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoRaWAN_ParticipatingGateways_TransmissionInterval")]
        public System.Int32? ParticipatingGateways_TransmissionInterval { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.CreateMulticastGroupResponse).
        /// Specifying the name of a property of type Amazon.IoTWireless.Model.CreateMulticastGroupResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTWMulticastGroup (CreateMulticastGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.CreateMulticastGroupResponse, NewIOTWMulticastGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.Description = this.Description;
            context.LoRaWAN_DlClass = this.LoRaWAN_DlClass;
            if (this.ParticipatingGateways_GatewayList != null)
            {
                context.ParticipatingGateways_GatewayList = new List<System.String>(this.ParticipatingGateways_GatewayList);
            }
            context.ParticipatingGateways_TransmissionInterval = this.ParticipatingGateways_TransmissionInterval;
            context.LoRaWAN_RfRegion = this.LoRaWAN_RfRegion;
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
            var request = new Amazon.IoTWireless.Model.CreateMulticastGroupRequest();
            
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
        
        private Amazon.IoTWireless.Model.CreateMulticastGroupResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.CreateMulticastGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "CreateMulticastGroup");
            try
            {
                #if DESKTOP
                return client.CreateMulticastGroup(request);
                #elif CORECLR
                return client.CreateMulticastGroupAsync(request).GetAwaiter().GetResult();
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
            public Amazon.IoTWireless.DlClass LoRaWAN_DlClass { get; set; }
            public List<System.String> ParticipatingGateways_GatewayList { get; set; }
            public System.Int32? ParticipatingGateways_TransmissionInterval { get; set; }
            public Amazon.IoTWireless.SupportedRfRegion LoRaWAN_RfRegion { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.IoTWireless.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.IoTWireless.Model.CreateMulticastGroupResponse, NewIOTWMulticastGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
