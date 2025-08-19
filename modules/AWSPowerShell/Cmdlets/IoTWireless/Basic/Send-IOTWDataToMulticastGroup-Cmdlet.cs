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
    /// Sends the specified data to a multicast group.
    /// </summary>
    [Cmdlet("Send", "IOTWDataToMulticastGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS IoT Wireless SendDataToMulticastGroup API operation.", Operation = new[] {"SendDataToMulticastGroup"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.SendDataToMulticastGroupResponse))]
    [AWSCmdletOutput("System.String or Amazon.IoTWireless.Model.SendDataToMulticastGroupResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IoTWireless.Model.SendDataToMulticastGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SendIOTWDataToMulticastGroupCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter Id
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
        public System.String Id { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MessageId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.SendDataToMulticastGroupResponse).
        /// Specifying the name of a property of type Amazon.IoTWireless.Model.SendDataToMulticastGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MessageId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-IOTWDataToMulticastGroup (SendDataToMulticastGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.SendDataToMulticastGroupResponse, SendIOTWDataToMulticastGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.LoRaWAN_FPort = this.LoRaWAN_FPort;
            
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
            var request = new Amazon.IoTWireless.Model.SendDataToMulticastGroupRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.PayloadData != null)
            {
                request.PayloadData = cmdletContext.PayloadData;
            }
            
             // populate WirelessMetadata
            request.WirelessMetadata = new Amazon.IoTWireless.Model.MulticastWirelessMetadata();
            Amazon.IoTWireless.Model.LoRaWANMulticastMetadata requestWirelessMetadata_wirelessMetadata_LoRaWAN = null;
            
             // populate LoRaWAN
            var requestWirelessMetadata_wirelessMetadata_LoRaWANIsNull = true;
            requestWirelessMetadata_wirelessMetadata_LoRaWAN = new Amazon.IoTWireless.Model.LoRaWANMulticastMetadata();
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
             // determine if requestWirelessMetadata_wirelessMetadata_LoRaWAN should be set to null
            if (requestWirelessMetadata_wirelessMetadata_LoRaWANIsNull)
            {
                requestWirelessMetadata_wirelessMetadata_LoRaWAN = null;
            }
            if (requestWirelessMetadata_wirelessMetadata_LoRaWAN != null)
            {
                request.WirelessMetadata.LoRaWAN = requestWirelessMetadata_wirelessMetadata_LoRaWAN;
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
        
        private Amazon.IoTWireless.Model.SendDataToMulticastGroupResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.SendDataToMulticastGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "SendDataToMulticastGroup");
            try
            {
                return client.SendDataToMulticastGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? LoRaWAN_FPort { get; set; }
            public System.Func<Amazon.IoTWireless.Model.SendDataToMulticastGroupResponse, SendIOTWDataToMulticastGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageId;
        }
        
    }
}
