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
    /// Updates properties of a wireless device.
    /// </summary>
    [Cmdlet("Update", "IOTWWirelessDevice", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT Wireless UpdateWirelessDevice API operation.", Operation = new[] {"UpdateWirelessDevice"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.UpdateWirelessDeviceResponse))]
    [AWSCmdletOutput("None or Amazon.IoTWireless.Model.UpdateWirelessDeviceResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoTWireless.Model.UpdateWirelessDeviceResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIOTWWirelessDeviceCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A new description of the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DestinationName
        /// <summary>
        /// <para>
        /// <para>The name of the new destination for the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationName { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_DeviceProfileId
        /// <summary>
        /// <para>
        /// <para>The ID of the device profile for the wireless device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoRaWAN_DeviceProfileId { get; set; }
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
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the resource to update.</para>
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
        /// <para>The new name of the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.UpdateWirelessDeviceResponse).
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTWWirelessDevice (UpdateWirelessDevice)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.UpdateWirelessDeviceResponse, UpdateIOTWWirelessDeviceCmdlet>(Select) ??
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
            context.DestinationName = this.DestinationName;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoRaWAN_AbpV1_0_x_FCntStart = this.LoRaWAN_AbpV1_0_x_FCntStart;
            context.LoRaWAN_AbpV1_1_FCntStart = this.LoRaWAN_AbpV1_1_FCntStart;
            context.LoRaWAN_DeviceProfileId = this.LoRaWAN_DeviceProfileId;
            context.LoRaWAN_ServiceProfileId = this.LoRaWAN_ServiceProfileId;
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
            var request = new Amazon.IoTWireless.Model.UpdateWirelessDeviceRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DestinationName != null)
            {
                request.DestinationName = cmdletContext.DestinationName;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            
             // populate LoRaWAN
            var requestLoRaWANIsNull = true;
            request.LoRaWAN = new Amazon.IoTWireless.Model.LoRaWANUpdateDevice();
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
            Amazon.IoTWireless.Model.UpdateAbpV1_0_x requestLoRaWAN_loRaWAN_AbpV1_0_x = null;
            
             // populate AbpV1_0_x
            var requestLoRaWAN_loRaWAN_AbpV1_0_xIsNull = true;
            requestLoRaWAN_loRaWAN_AbpV1_0_x = new Amazon.IoTWireless.Model.UpdateAbpV1_0_x();
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
            Amazon.IoTWireless.Model.UpdateAbpV1_1 requestLoRaWAN_loRaWAN_AbpV1_1 = null;
            
             // populate AbpV1_1
            var requestLoRaWAN_loRaWAN_AbpV1_1IsNull = true;
            requestLoRaWAN_loRaWAN_AbpV1_1 = new Amazon.IoTWireless.Model.UpdateAbpV1_1();
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
        
        private Amazon.IoTWireless.Model.UpdateWirelessDeviceResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.UpdateWirelessDeviceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "UpdateWirelessDevice");
            try
            {
                #if DESKTOP
                return client.UpdateWirelessDevice(request);
                #elif CORECLR
                return client.UpdateWirelessDeviceAsync(request).GetAwaiter().GetResult();
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
            public System.String DestinationName { get; set; }
            public System.String Id { get; set; }
            public System.Int32? LoRaWAN_AbpV1_0_x_FCntStart { get; set; }
            public System.Int32? LoRaWAN_AbpV1_1_FCntStart { get; set; }
            public System.String LoRaWAN_DeviceProfileId { get; set; }
            public System.String LoRaWAN_ServiceProfileId { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.IoTWireless.Model.UpdateWirelessDeviceResponse, UpdateIOTWWirelessDeviceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
