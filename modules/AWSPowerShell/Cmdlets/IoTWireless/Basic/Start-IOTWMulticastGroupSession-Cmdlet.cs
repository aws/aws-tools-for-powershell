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
    /// Starts a multicast group session.
    /// </summary>
    [Cmdlet("Start", "IOTWMulticastGroupSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT Wireless StartMulticastGroupSession API operation.", Operation = new[] {"StartMulticastGroupSession"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.StartMulticastGroupSessionResponse))]
    [AWSCmdletOutput("None or Amazon.IoTWireless.Model.StartMulticastGroupSessionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoTWireless.Model.StartMulticastGroupSessionResponse) be returned by specifying '-Select *'."
    )]
    public partial class StartIOTWMulticastGroupSessionCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LoRaWAN_DlDr
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LoRaWAN_DlDr { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_DlFreq
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LoRaWAN_DlFreq { get; set; }
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
        
        #region Parameter LoRaWAN_PingSlotPeriod
        /// <summary>
        /// <para>
        /// <para>The PingSlotPeriod value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LoRaWAN_PingSlotPeriod { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_SessionStartTime
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? LoRaWAN_SessionStartTime { get; set; }
        #endregion
        
        #region Parameter LoRaWAN_SessionTimeout
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LoRaWAN_SessionTimeout { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.StartMulticastGroupSessionResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-IOTWMulticastGroupSession (StartMulticastGroupSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.StartMulticastGroupSessionResponse, StartIOTWMulticastGroupSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoRaWAN_DlDr = this.LoRaWAN_DlDr;
            context.LoRaWAN_DlFreq = this.LoRaWAN_DlFreq;
            context.LoRaWAN_PingSlotPeriod = this.LoRaWAN_PingSlotPeriod;
            context.LoRaWAN_SessionStartTime = this.LoRaWAN_SessionStartTime;
            context.LoRaWAN_SessionTimeout = this.LoRaWAN_SessionTimeout;
            
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
            var request = new Amazon.IoTWireless.Model.StartMulticastGroupSessionRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            
             // populate LoRaWAN
            var requestLoRaWANIsNull = true;
            request.LoRaWAN = new Amazon.IoTWireless.Model.LoRaWANMulticastSession();
            System.Int32? requestLoRaWAN_loRaWAN_DlDr = null;
            if (cmdletContext.LoRaWAN_DlDr != null)
            {
                requestLoRaWAN_loRaWAN_DlDr = cmdletContext.LoRaWAN_DlDr.Value;
            }
            if (requestLoRaWAN_loRaWAN_DlDr != null)
            {
                request.LoRaWAN.DlDr = requestLoRaWAN_loRaWAN_DlDr.Value;
                requestLoRaWANIsNull = false;
            }
            System.Int32? requestLoRaWAN_loRaWAN_DlFreq = null;
            if (cmdletContext.LoRaWAN_DlFreq != null)
            {
                requestLoRaWAN_loRaWAN_DlFreq = cmdletContext.LoRaWAN_DlFreq.Value;
            }
            if (requestLoRaWAN_loRaWAN_DlFreq != null)
            {
                request.LoRaWAN.DlFreq = requestLoRaWAN_loRaWAN_DlFreq.Value;
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
            System.DateTime? requestLoRaWAN_loRaWAN_SessionStartTime = null;
            if (cmdletContext.LoRaWAN_SessionStartTime != null)
            {
                requestLoRaWAN_loRaWAN_SessionStartTime = cmdletContext.LoRaWAN_SessionStartTime.Value;
            }
            if (requestLoRaWAN_loRaWAN_SessionStartTime != null)
            {
                request.LoRaWAN.SessionStartTime = requestLoRaWAN_loRaWAN_SessionStartTime.Value;
                requestLoRaWANIsNull = false;
            }
            System.Int32? requestLoRaWAN_loRaWAN_SessionTimeout = null;
            if (cmdletContext.LoRaWAN_SessionTimeout != null)
            {
                requestLoRaWAN_loRaWAN_SessionTimeout = cmdletContext.LoRaWAN_SessionTimeout.Value;
            }
            if (requestLoRaWAN_loRaWAN_SessionTimeout != null)
            {
                request.LoRaWAN.SessionTimeout = requestLoRaWAN_loRaWAN_SessionTimeout.Value;
                requestLoRaWANIsNull = false;
            }
             // determine if request.LoRaWAN should be set to null
            if (requestLoRaWANIsNull)
            {
                request.LoRaWAN = null;
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
        
        private Amazon.IoTWireless.Model.StartMulticastGroupSessionResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.StartMulticastGroupSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "StartMulticastGroupSession");
            try
            {
                return client.StartMulticastGroupSessionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? LoRaWAN_DlDr { get; set; }
            public System.Int32? LoRaWAN_DlFreq { get; set; }
            public System.Int32? LoRaWAN_PingSlotPeriod { get; set; }
            public System.DateTime? LoRaWAN_SessionStartTime { get; set; }
            public System.Int32? LoRaWAN_SessionTimeout { get; set; }
            public System.Func<Amazon.IoTWireless.Model.StartMulticastGroupSessionResponse, StartIOTWMulticastGroupSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
