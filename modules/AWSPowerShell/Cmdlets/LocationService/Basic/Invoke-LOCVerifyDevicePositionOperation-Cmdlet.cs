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
using Amazon.LocationService;
using Amazon.LocationService.Model;

namespace Amazon.PowerShell.Cmdlets.LOC
{
    /// <summary>
    /// Verifies the integrity of the device's position by determining if it was reported
    /// behind a proxy, and by comparing it to an inferred position estimated based on the
    /// device's state.
    /// </summary>
    [Cmdlet("Invoke", "LOCVerifyDevicePositionOperation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LocationService.Model.VerifyDevicePositionResponse")]
    [AWSCmdlet("Calls the Amazon Location Service VerifyDevicePosition API operation.", Operation = new[] {"VerifyDevicePosition"}, SelectReturnType = typeof(Amazon.LocationService.Model.VerifyDevicePositionResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.VerifyDevicePositionResponse",
        "This cmdlet returns an Amazon.LocationService.Model.VerifyDevicePositionResponse object containing multiple properties."
    )]
    public partial class InvokeLOCVerifyDevicePositionOperationCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DeviceState_DeviceId
        /// <summary>
        /// <para>
        /// <para>The device identifier.</para>
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
        public System.String DeviceState_DeviceId { get; set; }
        #endregion
        
        #region Parameter DistanceUnit
        /// <summary>
        /// <para>
        /// <para>The distance unit for the verification request.</para><para>Default Value: <c>Kilometers</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LocationService.DistanceUnit")]
        public Amazon.LocationService.DistanceUnit DistanceUnit { get; set; }
        #endregion
        
        #region Parameter Accuracy_Horizontal
        /// <summary>
        /// <para>
        /// <para>Estimated maximum distance, in meters, between the measured position and the true
        /// position of a device, along the Earth's surface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeviceState_Accuracy_Horizontal")]
        public System.Double? Accuracy_Horizontal { get; set; }
        #endregion
        
        #region Parameter DeviceState_Ipv4Address
        /// <summary>
        /// <para>
        /// <para>The device's Ipv4 address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceState_Ipv4Address { get; set; }
        #endregion
        
        #region Parameter CellSignals_LteCellDetail
        /// <summary>
        /// <para>
        /// <para>Information about the Long-Term Evolution (LTE) network the device is connected to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeviceState_CellSignals_LteCellDetails")]
        public Amazon.LocationService.Model.LteCellDetails[] CellSignals_LteCellDetail { get; set; }
        #endregion
        
        #region Parameter DeviceState_Position
        /// <summary>
        /// <para>
        /// <para>The last known device position.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Double[] DeviceState_Position { get; set; }
        #endregion
        
        #region Parameter DeviceState_SampleTime
        /// <summary>
        /// <para>
        /// <para>The timestamp at which the device's position was determined. Uses <a href="https://www.iso.org/iso-8601-date-and-time-format.html">
        /// ISO 8601 </a> format: <c>YYYY-MM-DDThh:mm:ss.sssZ</c>. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? DeviceState_SampleTime { get; set; }
        #endregion
        
        #region Parameter TrackerName
        /// <summary>
        /// <para>
        /// <para>The name of the tracker resource to be associated with verification request.</para>
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
        public System.String TrackerName { get; set; }
        #endregion
        
        #region Parameter DeviceState_WiFiAccessPoint
        /// <summary>
        /// <para>
        /// <para>The Wi-Fi access points the device is using.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeviceState_WiFiAccessPoints")]
        public Amazon.LocationService.Model.WiFiAccessPoint[] DeviceState_WiFiAccessPoint { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.VerifyDevicePositionResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.VerifyDevicePositionResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrackerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-LOCVerifyDevicePositionOperation (VerifyDevicePosition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.VerifyDevicePositionResponse, InvokeLOCVerifyDevicePositionOperationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Accuracy_Horizontal = this.Accuracy_Horizontal;
            if (this.CellSignals_LteCellDetail != null)
            {
                context.CellSignals_LteCellDetail = new List<Amazon.LocationService.Model.LteCellDetails>(this.CellSignals_LteCellDetail);
            }
            context.DeviceState_DeviceId = this.DeviceState_DeviceId;
            #if MODULAR
            if (this.DeviceState_DeviceId == null && ParameterWasBound(nameof(this.DeviceState_DeviceId)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceState_DeviceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeviceState_Ipv4Address = this.DeviceState_Ipv4Address;
            if (this.DeviceState_Position != null)
            {
                context.DeviceState_Position = new List<System.Double>(this.DeviceState_Position);
            }
            #if MODULAR
            if (this.DeviceState_Position == null && ParameterWasBound(nameof(this.DeviceState_Position)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceState_Position which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeviceState_SampleTime = this.DeviceState_SampleTime;
            #if MODULAR
            if (this.DeviceState_SampleTime == null && ParameterWasBound(nameof(this.DeviceState_SampleTime)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceState_SampleTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DeviceState_WiFiAccessPoint != null)
            {
                context.DeviceState_WiFiAccessPoint = new List<Amazon.LocationService.Model.WiFiAccessPoint>(this.DeviceState_WiFiAccessPoint);
            }
            context.DistanceUnit = this.DistanceUnit;
            context.TrackerName = this.TrackerName;
            #if MODULAR
            if (this.TrackerName == null && ParameterWasBound(nameof(this.TrackerName)))
            {
                WriteWarning("You are passing $null as a value for parameter TrackerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LocationService.Model.VerifyDevicePositionRequest();
            
            
             // populate DeviceState
            var requestDeviceStateIsNull = true;
            request.DeviceState = new Amazon.LocationService.Model.DeviceState();
            System.String requestDeviceState_deviceState_DeviceId = null;
            if (cmdletContext.DeviceState_DeviceId != null)
            {
                requestDeviceState_deviceState_DeviceId = cmdletContext.DeviceState_DeviceId;
            }
            if (requestDeviceState_deviceState_DeviceId != null)
            {
                request.DeviceState.DeviceId = requestDeviceState_deviceState_DeviceId;
                requestDeviceStateIsNull = false;
            }
            System.String requestDeviceState_deviceState_Ipv4Address = null;
            if (cmdletContext.DeviceState_Ipv4Address != null)
            {
                requestDeviceState_deviceState_Ipv4Address = cmdletContext.DeviceState_Ipv4Address;
            }
            if (requestDeviceState_deviceState_Ipv4Address != null)
            {
                request.DeviceState.Ipv4Address = requestDeviceState_deviceState_Ipv4Address;
                requestDeviceStateIsNull = false;
            }
            List<System.Double> requestDeviceState_deviceState_Position = null;
            if (cmdletContext.DeviceState_Position != null)
            {
                requestDeviceState_deviceState_Position = cmdletContext.DeviceState_Position;
            }
            if (requestDeviceState_deviceState_Position != null)
            {
                request.DeviceState.Position = requestDeviceState_deviceState_Position;
                requestDeviceStateIsNull = false;
            }
            System.DateTime? requestDeviceState_deviceState_SampleTime = null;
            if (cmdletContext.DeviceState_SampleTime != null)
            {
                requestDeviceState_deviceState_SampleTime = cmdletContext.DeviceState_SampleTime.Value;
            }
            if (requestDeviceState_deviceState_SampleTime != null)
            {
                request.DeviceState.SampleTime = requestDeviceState_deviceState_SampleTime.Value;
                requestDeviceStateIsNull = false;
            }
            List<Amazon.LocationService.Model.WiFiAccessPoint> requestDeviceState_deviceState_WiFiAccessPoint = null;
            if (cmdletContext.DeviceState_WiFiAccessPoint != null)
            {
                requestDeviceState_deviceState_WiFiAccessPoint = cmdletContext.DeviceState_WiFiAccessPoint;
            }
            if (requestDeviceState_deviceState_WiFiAccessPoint != null)
            {
                request.DeviceState.WiFiAccessPoints = requestDeviceState_deviceState_WiFiAccessPoint;
                requestDeviceStateIsNull = false;
            }
            Amazon.LocationService.Model.PositionalAccuracy requestDeviceState_deviceState_Accuracy = null;
            
             // populate Accuracy
            var requestDeviceState_deviceState_AccuracyIsNull = true;
            requestDeviceState_deviceState_Accuracy = new Amazon.LocationService.Model.PositionalAccuracy();
            System.Double? requestDeviceState_deviceState_Accuracy_accuracy_Horizontal = null;
            if (cmdletContext.Accuracy_Horizontal != null)
            {
                requestDeviceState_deviceState_Accuracy_accuracy_Horizontal = cmdletContext.Accuracy_Horizontal.Value;
            }
            if (requestDeviceState_deviceState_Accuracy_accuracy_Horizontal != null)
            {
                requestDeviceState_deviceState_Accuracy.Horizontal = requestDeviceState_deviceState_Accuracy_accuracy_Horizontal.Value;
                requestDeviceState_deviceState_AccuracyIsNull = false;
            }
             // determine if requestDeviceState_deviceState_Accuracy should be set to null
            if (requestDeviceState_deviceState_AccuracyIsNull)
            {
                requestDeviceState_deviceState_Accuracy = null;
            }
            if (requestDeviceState_deviceState_Accuracy != null)
            {
                request.DeviceState.Accuracy = requestDeviceState_deviceState_Accuracy;
                requestDeviceStateIsNull = false;
            }
            Amazon.LocationService.Model.CellSignals requestDeviceState_deviceState_CellSignals = null;
            
             // populate CellSignals
            var requestDeviceState_deviceState_CellSignalsIsNull = true;
            requestDeviceState_deviceState_CellSignals = new Amazon.LocationService.Model.CellSignals();
            List<Amazon.LocationService.Model.LteCellDetails> requestDeviceState_deviceState_CellSignals_cellSignals_LteCellDetail = null;
            if (cmdletContext.CellSignals_LteCellDetail != null)
            {
                requestDeviceState_deviceState_CellSignals_cellSignals_LteCellDetail = cmdletContext.CellSignals_LteCellDetail;
            }
            if (requestDeviceState_deviceState_CellSignals_cellSignals_LteCellDetail != null)
            {
                requestDeviceState_deviceState_CellSignals.LteCellDetails = requestDeviceState_deviceState_CellSignals_cellSignals_LteCellDetail;
                requestDeviceState_deviceState_CellSignalsIsNull = false;
            }
             // determine if requestDeviceState_deviceState_CellSignals should be set to null
            if (requestDeviceState_deviceState_CellSignalsIsNull)
            {
                requestDeviceState_deviceState_CellSignals = null;
            }
            if (requestDeviceState_deviceState_CellSignals != null)
            {
                request.DeviceState.CellSignals = requestDeviceState_deviceState_CellSignals;
                requestDeviceStateIsNull = false;
            }
             // determine if request.DeviceState should be set to null
            if (requestDeviceStateIsNull)
            {
                request.DeviceState = null;
            }
            if (cmdletContext.DistanceUnit != null)
            {
                request.DistanceUnit = cmdletContext.DistanceUnit;
            }
            if (cmdletContext.TrackerName != null)
            {
                request.TrackerName = cmdletContext.TrackerName;
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
        
        private Amazon.LocationService.Model.VerifyDevicePositionResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.VerifyDevicePositionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "VerifyDevicePosition");
            try
            {
                return client.VerifyDevicePositionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Double? Accuracy_Horizontal { get; set; }
            public List<Amazon.LocationService.Model.LteCellDetails> CellSignals_LteCellDetail { get; set; }
            public System.String DeviceState_DeviceId { get; set; }
            public System.String DeviceState_Ipv4Address { get; set; }
            public List<System.Double> DeviceState_Position { get; set; }
            public System.DateTime? DeviceState_SampleTime { get; set; }
            public List<Amazon.LocationService.Model.WiFiAccessPoint> DeviceState_WiFiAccessPoint { get; set; }
            public Amazon.LocationService.DistanceUnit DistanceUnit { get; set; }
            public System.String TrackerName { get; set; }
            public System.Func<Amazon.LocationService.Model.VerifyDevicePositionResponse, InvokeLOCVerifyDevicePositionOperationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
