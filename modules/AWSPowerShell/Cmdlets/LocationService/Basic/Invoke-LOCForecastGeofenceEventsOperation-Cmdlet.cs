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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LOC
{
    /// <summary>
    /// Evaluates device positions against geofence geometries from a given geofence collection.
    /// The event forecasts three states for which a device can be in relative to a geofence:
    /// 
    ///  
    /// <para><c>ENTER</c>: If a device is outside of a geofence, but would breach the fence if
    /// the device is moving at its current speed within time horizon window.
    /// </para><para><c>EXIT</c>: If a device is inside of a geofence, but would breach the fence if the
    /// device is moving at its current speed within time horizon window.
    /// </para><para><c>IDLE</c>: If a device is inside of a geofence, and the device is not moving.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "LOCForecastGeofenceEventsOperation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LocationService.Model.ForecastGeofenceEventsResponse")]
    [AWSCmdlet("Calls the Amazon Location Service ForecastGeofenceEvents API operation.", Operation = new[] {"ForecastGeofenceEvents"}, SelectReturnType = typeof(Amazon.LocationService.Model.ForecastGeofenceEventsResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.ForecastGeofenceEventsResponse",
        "This cmdlet returns an Amazon.LocationService.Model.ForecastGeofenceEventsResponse object containing multiple properties."
    )]
    public partial class InvokeLOCForecastGeofenceEventsOperationCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CollectionName
        /// <summary>
        /// <para>
        /// <para>The name of the geofence collection.</para>
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
        public System.String CollectionName { get; set; }
        #endregion
        
        #region Parameter DistanceUnit
        /// <summary>
        /// <para>
        /// <para>The distance unit used for the <c>NearestDistance</c> property returned in a forecasted
        /// event. The measurement system must match for <c>DistanceUnit</c> and <c>SpeedUnit</c>;
        /// if <c>Kilometers</c> is specified for <c>DistanceUnit</c>, then <c>SpeedUnit</c> must
        /// be <c>KilometersPerHour</c>. </para><para>Default Value: <c>Kilometers</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LocationService.DistanceUnit")]
        public Amazon.LocationService.DistanceUnit DistanceUnit { get; set; }
        #endregion
        
        #region Parameter DeviceState_Position
        /// <summary>
        /// <para>
        /// <para>The device's position.</para>
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
        
        #region Parameter DeviceState_Speed
        /// <summary>
        /// <para>
        /// <para>The device's speed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? DeviceState_Speed { get; set; }
        #endregion
        
        #region Parameter SpeedUnit
        /// <summary>
        /// <para>
        /// <para>The speed unit for the device captured by the device state. The measurement system
        /// must match for <c>DistanceUnit</c> and <c>SpeedUnit</c>; if <c>Kilometers</c> is specified
        /// for <c>DistanceUnit</c>, then <c>SpeedUnit</c> must be <c>KilometersPerHour</c>.</para><para>Default Value: <c>KilometersPerHour</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LocationService.SpeedUnit")]
        public Amazon.LocationService.SpeedUnit SpeedUnit { get; set; }
        #endregion
        
        #region Parameter TimeHorizonMinute
        /// <summary>
        /// <para>
        /// <para>Specifies the time horizon in minutes for the forecasted events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeHorizonMinutes")]
        public System.Double? TimeHorizonMinute { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>An optional limit for the number of resources returned in a single call.</para><para>Default value: <c>20</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token specifying which page of results to return in the response. If
        /// no token is provided, the default page is the first page.</para><para>Default value: <c>null</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.ForecastGeofenceEventsResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.ForecastGeofenceEventsResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CollectionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-LOCForecastGeofenceEventsOperation (ForecastGeofenceEvents)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.ForecastGeofenceEventsResponse, InvokeLOCForecastGeofenceEventsOperationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CollectionName = this.CollectionName;
            #if MODULAR
            if (this.CollectionName == null && ParameterWasBound(nameof(this.CollectionName)))
            {
                WriteWarning("You are passing $null as a value for parameter CollectionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            context.DeviceState_Speed = this.DeviceState_Speed;
            context.DistanceUnit = this.DistanceUnit;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SpeedUnit = this.SpeedUnit;
            context.TimeHorizonMinute = this.TimeHorizonMinute;
            
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
            var request = new Amazon.LocationService.Model.ForecastGeofenceEventsRequest();
            
            if (cmdletContext.CollectionName != null)
            {
                request.CollectionName = cmdletContext.CollectionName;
            }
            
             // populate DeviceState
            var requestDeviceStateIsNull = true;
            request.DeviceState = new Amazon.LocationService.Model.ForecastGeofenceEventsDeviceState();
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
            System.Double? requestDeviceState_deviceState_Speed = null;
            if (cmdletContext.DeviceState_Speed != null)
            {
                requestDeviceState_deviceState_Speed = cmdletContext.DeviceState_Speed.Value;
            }
            if (requestDeviceState_deviceState_Speed != null)
            {
                request.DeviceState.Speed = requestDeviceState_deviceState_Speed.Value;
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
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.SpeedUnit != null)
            {
                request.SpeedUnit = cmdletContext.SpeedUnit;
            }
            if (cmdletContext.TimeHorizonMinute != null)
            {
                request.TimeHorizonMinutes = cmdletContext.TimeHorizonMinute.Value;
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
        
        private Amazon.LocationService.Model.ForecastGeofenceEventsResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.ForecastGeofenceEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "ForecastGeofenceEvents");
            try
            {
                return client.ForecastGeofenceEventsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CollectionName { get; set; }
            public List<System.Double> DeviceState_Position { get; set; }
            public System.Double? DeviceState_Speed { get; set; }
            public Amazon.LocationService.DistanceUnit DistanceUnit { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.LocationService.SpeedUnit SpeedUnit { get; set; }
            public System.Double? TimeHorizonMinute { get; set; }
            public System.Func<Amazon.LocationService.Model.ForecastGeofenceEventsResponse, InvokeLOCForecastGeofenceEventsOperationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
